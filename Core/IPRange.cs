using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

namespace Nemo.Core
{
    public class IPRange
    {
        public uint     MinIP = 0; // нижняя граница
        public uint     MaxIP = 0; // верхняя граница
        public string   Text;      // строка диапозона

        public IPRange() { }

        public bool Parse(string range)
        {
            Text = range;
            return (checkDoubleRange() || checkMaskedRange() || checkSingleRange()) && 
                MinIP <= MaxIP;
        }

        public bool Match(IPAddress ip)
        {
            return Match((uint)ip.Address);
        }

        public bool Match(string ip)
        {
            try
            {
                return Match((uint)IPAddress.Parse(ip).Address);
            }
            catch
            {
                return false;
            }
        }

        public bool Match(uint ip)
        {
            ip = (uint)IPAddress.NetworkToHostOrder((int)ip);
            return ip <= MaxIP && ip >= MinIP;
        }

        private bool checkDoubleRange()
        {
            try
            {
                //10.0.0.1-10.0.0.2
                Match reg = Regex.Match(Text, @"(.+)-(.+)");
                if (reg.Success)
                {
                    MinIP = (uint)IPAddress.NetworkToHostOrder((int)IPAddress.Parse(reg.Groups[1].Value).Address);
                    MaxIP = (uint)IPAddress.NetworkToHostOrder((int)IPAddress.Parse(reg.Groups[2].Value).Address);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private bool checkMaskedRange()
        {
            try
            {
                //10.0.0.0/24
                Match reg = Regex.Match(Text, @"(.+)/(.+)");
                if (reg.Success)
                {
                    int mask = Int32.Parse(reg.Groups[2].Value);
                    mask = (mask == 0) ? 0 : ((int)1 << (int)(32 - mask)) - 1;
                    MinIP = (uint)((IPAddress.NetworkToHostOrder(
                        (int)IPAddress.Parse(reg.Groups[1].Value).Address)) & ( 0xffffffff - mask));
                    MaxIP = (uint)(MinIP | mask);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private bool checkSingleRange()
        {
            try
            {
                //10.0.0.0
                MinIP = MaxIP = (uint)IPAddress.NetworkToHostOrder((int)IPAddress.Parse(Text).Address);
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
