using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamir.IPLib;
using System.Threading;
using Tamir.IPLib.Packets;

namespace Nemo.Core
{

    public class PcapParser
    {
        #region Public properties
        public volatile uint Packets;
        public volatile uint FlowsNum;
        public volatile uint KBytes;
        public volatile bool IsCapturing = false;
        public string DeviceName = string.Empty;
        public string ErrorMsg = string.Empty;
        #endregion

        #region Private properties
        private volatile PcapDevice _device = null;
        private uint _bytes;
        private Flows _flows;
        Thread _runningThread = null;
        private List<string> _offlineDevs;
        private Object _lock = new Object();
        #endregion

        public Flows Flows
        {
            get
            {
                Flows res;
                //critical section for flows
                lock (_lock)
                {
                    res = _flows;
                    _flows = new Flows();
                }
                //clear all stored statistics
                ClearStatistics();
                return res;
            }
        }
        #region Constructor
        public PcapParser()
        {
            _flows = new Flows();
            _offlineDevs = new List<string>();
        }
        #endregion

        #region Public Methods
        public PcapDeviceList GetInterfaces()
        {
            /* Retrieve the device list */
            return SharpPcap.GetAllDevices();
        }

        public bool TestDevice(PcapDevice device)
        {
            try
            {
                device.PcapOpen();
                device.PcapClose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void StartCapture()
        {
            lock (_lock)
            {
                if (!IsCapturing)
                    startThread();
            }
        }

        public void AddOfflineDevice(string dev)
        {
            lock (_lock)
            {
                _offlineDevs.Add(dev);
            }
        }

        public void SetDevice(PcapDevice dev)
        {
            lock (_lock)
            {
                _device = dev;
            }
        }

        public void StopCapture()
        {
            lock (_lock)
            {
                if (!IsCapturing)
                    return;
                //if device exists and opened - close it
                if (_device != null && _device.PcapOpened)
                {
                    _device.PcapClose();
                }
                IsCapturing = false;
                _device = null;
                DeviceName = null;
                try
                {
                    _runningThread.Abort();
                }
                finally
                {
                    _runningThread = null;
                }
            }
        }
        #endregion

        #region Private Methods

        private void startThread()
        {
            _runningThread = new Thread(new ThreadStart(startCapture));
            _runningThread.IsBackground = true;
            IsCapturing = true;
            _runningThread.Start();
        }
 
        private void startCapture()
        {
            while (IsCapturing)
            {
                if (_device == null)
                {
                    if (_offlineDevs.Count > 0)
                    {
                        DeviceName = _offlineDevs[0];
                        _device = SharpPcap.GetPcapOfflineDevice(DeviceName);
                        _offlineDevs.RemoveAt(0);
                    }
                    else
                    {
                        StopCapture();
                    }
                }
                else
                {
                    DeviceName = ((NetworkDevice)_device).Description;
                }
                try
                {
                    _device.PcapOpen(); 

                }
                catch (Exception ee)
                {
                    ErrorMsg = ee.Message;
                    StopCapture();
                    return;

                }
                //Register our handler function to the 
                //'packet arrival' event
                _device.PcapOnPacketArrival += new SharpPcap.PacketArrivalEvent(pcapOnPacketArrival);
                //Start the capturing process
                _device.PcapCapture(SharpPcap.INFINITE);
                //Close the pcap device
                _device.PcapClose();
                _device = null;
            }
        }

        private void pcapOnPacketArrival(object sender, Packet packet)
        {
            if (packet is TCPPacket || packet is UDPPacket)
            {
                try
                {
                    Flow flow = GetFlowFromPacket(packet);
                    if (flow == null)
                    {
                        return;
                    }
                    UpdateStatistics(packet);
                    //критическая секция для потока
                    lock (_lock)
                    {
                        //пробуем найти потока для данного пакета
                        if (!_flows.MergeFlow(flow))
                        {
                            FlowsNum++;
                        }
                    }
                }
                catch { }
            }
        }

        private Flow GetFlowFromPacket(Packet packet)
        {
            Flow flow;
            if (packet is TCPPacket)
            {
                TCPPacket tcpPacket = (TCPPacket)packet;
                //наполняем атрибуты для TCP пакета
                flow = new Flow(System.Net.IPAddress.Parse(tcpPacket.SourceAddress), 
                    (ushort)tcpPacket.SourcePort, 
                    System.Net.IPAddress.Parse(tcpPacket.DestinationAddress), 
                    (ushort)tcpPacket.DestinationPort, TransportProtocol.TCP);
            }
            else if (packet is UDPPacket)
            {
                UDPPacket udpPacket = (UDPPacket)packet;
                //наполняем атрибуты для UDP пакета
                flow = new Flow(System.Net.IPAddress.Parse(udpPacket.SourceAddress),
                    (ushort)udpPacket.SourcePort,
                    System.Net.IPAddress.Parse(udpPacket.DestinationAddress),
                    (ushort)udpPacket.DestinationPort, TransportProtocol.UDP);
            }
            else
            {
                return null;
            }
            flow.BytesAB = (uint)packet.PcapHeader.PacketLength;
            flow.StartTime = packet.Timeval.Date;
            return flow;
        }

        private void UpdateStatistics(Packet packet)
        {
            //сохраняем статистику
            _bytes += (uint)packet.PcapHeader.PacketLength;
            KBytes += _bytes / 1024;
            _bytes = _bytes % 1024;
            Packets++;
        }

        private void ClearStatistics()
        {
            _bytes = 0;
            KBytes = 0;
            Packets = 0;
            FlowsNum = 0;
        }
        #endregion
    }
}
