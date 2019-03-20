using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using WeifenLuo.WinFormsUI.Docking;
using Microsoft.Win32;
using Nemo.Core;
using System.Net;
using System.Media;

namespace Nemo.GUI
{
	public partial class MainForm : Form
	{
		private Options _options;
		private FiltersForm _filtersForm;
		private FlowsForm _flowsForm;
        private StatisticsForm _statForm;
        private MapForm _mapForm;
        private PcapParser _offlineParser;
        private PcapParser _onlineParser;
        private Flows _flows;
        private bool _autoRefresh = false;

        public static Dictionary<uint, string> ServiceMap;

public MainForm()
{
	InitializeComponent();
    _offlineParser = new PcapParser();
    _onlineParser = new PcapParser();
    _flows = new Flows();
    DynamicFilter.WorkingDir = Directory.GetCurrentDirectory();
    _options = new Options();

	this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
    this.DragDrop += new DragEventHandler(Form_DragDrop);

	DateTime now = DateTime.Now;
	fromDateTimePicker.Value = now.AddHours(-now.Hour).AddMinutes(-now.Minute).AddSeconds(-now.Second);
	toDateTimePicker.Value = fromDateTimePicker.Value.AddDays(1).AddSeconds(-1);
	_filtersForm = new FiltersForm(_options, this);
	_filtersForm.FiltersTree.AfterSelect += new TreeViewEventHandler(FiltersTree_AfterSelect);

	_flowsForm = new FlowsForm(this);
    _mapForm = new MapForm();
    _statForm = new StatisticsForm();

	_filtersForm.Show(dockPanel, DockState.DockLeft);
	_flowsForm.Show(dockPanel, DockState.Document);
    _statForm.Show(dockPanel, DockState.Document);

	DockPane pane = dockPanel.DockPaneFactory.CreateDockPane(
        _flowsForm, DockState.Document, true);
    DockPane pane1 = dockPanel.DockPaneFactory.CreateDockPane(
        _statForm, pane, DockAlignment.Bottom, 0.5, true);
    _mapForm.Show(pane1, _statForm);
}

		private void MainForm_Load(object sender, EventArgs e)
		{
            Flows.ServiceMap = Constants.GetDefaultServiceMap();
            _filtersForm.CreateFilterNodes(_options.CheckedFilters);
            RefreshFiltersTree();
            _flowsForm.FillFlowsTable(null);
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
            stopCapture();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OptionsForm options = new OptionsForm(_options, _flows);
			options.ShowDialog(this);
            _filtersForm.CreateFilterNodes(_options.CheckedFilters);
            _mapForm.Clear();
            _statForm.Clear();
			RefreshFiltersTree();
        	_flowsForm.FlowsTable.Items.Clear();
		}

        private void setAliasNames()
        {
            string ip;
            foreach (Flow flw in _flows._Flows)
            {
                ip = flw.IpA.ToString();
                if (_options.Aliases.ContainsKey(ip))
                {
                    flw.NameA = _options.Aliases[ip];
                }
                else
                {
                    flw.NameA = string.Empty;
                }
                ip = flw.IpB.ToString();
                if (_options.Aliases.ContainsKey(ip))
                {
                    flw.NameB = _options.Aliases[ip];
                }
                else
                {
                    flw.NameB = string.Empty;
                }
            }
        }

        private void setLocalFlags()
        {
            foreach (Flow flw in _flows._Flows)
            {
                foreach (IPRange range in _options.Locals)
                {
                    if (!flw.IsLocalA && range.Match(flw.IpA))
                    {
                        flw.IsLocalA = true;
                    }
                    if (!flw.IsLocalB && range.Match(flw.IpB))
                    {
                        flw.IsLocalB = true;
                    }
                }
            }
        }

		private void evtTimer_Tick(object sender, EventArgs e)
		{
			RefreshFiltersTree();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
            AboutForm about = new AboutForm();
            about.ShowDialog(this);
		}

        public void DeleteFlow(Flow flow)
        {
            _flows.DeleteFlow(flow);
        }

		public void RefreshFiltersTree()
		{
    		_filtersForm.FiltersTree.ClearNodes();
            setAliasNames();
            setLocalFlags();
			DateTime startDate = fromDateTimePicker.Value;
			DateTime endDate = toDateTimePicker.Value;
            _filtersForm.Filter = "";

			Dictionary<string, int> sizes = new Dictionary<string, int>();
			sizes.Add(Constants.FilterSize[0], 0);
            sizes.Add(Constants.FilterSize[1], 0);
            sizes.Add(Constants.FilterSize[2], 0);
            sizes.Add(Constants.FilterSize[3], 0);
          	Dictionary<string, int> addressesSrc = new Dictionary<string, int>();
            Dictionary<string, int> addressesDst = new Dictionary<string, int>();
			Dictionary<string, int> portsSrcTcp = new Dictionary<string, int>();
            Dictionary<string, int> portsDstTcp = new Dictionary<string, int>();
            Dictionary<string, int> portsSrcUdp = new Dictionary<string, int>();
            Dictionary<string, int> portsDstUdp = new Dictionary<string, int>();
			Dictionary<string, int> services = new Dictionary<string, int>();
			Dictionary<string, int> timeStart = new Dictionary<string, int>();
            Dictionary<string, int> timeLength = new Dictionary<string, int>();
            timeLength.Add(Constants.FilterLength[0], 0);
            timeLength.Add(Constants.FilterLength[1], 0);
            timeLength.Add(Constants.FilterLength[2], 0);
            timeLength.Add(Constants.FilterLength[3], 0);
			Dictionary<string, int> customFilters = new Dictionary<string, int>();
            //get custom filter names
            List<string> customNames = _options.CustomFilters.FilterNames;
            foreach(string name in customNames)
            {
                customFilters.Add(name, 0);
            }

			Flow[] flows = _flows.GetFlowsByDate(startDate, endDate);

            foreach (Flow flow in flows)
            {
                string address;
                if (!string.IsNullOrEmpty(flow.NameA))
                {
                    address = flow.NameA;
                }
                else
                {
                    address = flow.IpA.ToString();
                }
                if (addressesSrc.ContainsKey(address))
                    addressesSrc[address]++;
                else
                    addressesSrc.Add(address, 1);

                if (!string.IsNullOrEmpty(flow.NameB))
                {
                    address = flow.NameB;
                }
                else
                {
                    address = flow.IpB.ToString();
                }
                if (addressesDst.ContainsKey(address))
                    addressesDst[address]++;
                else
                    addressesDst.Add(address, 1);

                //fill ports map. separates statistics for Destion(TCP/UDP) - Source (TCP/UDP)
                string portSrc = flow.PortA.ToString();
                string portDst = flow.PortB.ToString();
                if (flow.TransportProto == TransportProtocol.TCP)
                {
                    if (portsSrcTcp.ContainsKey(portSrc))
                        portsSrcTcp[portSrc]++;
                    else
                        portsSrcTcp.Add(portSrc, 1);
                    
                    if (portsDstTcp.ContainsKey(portDst))
                        portsDstTcp[portDst]++;
                    else
                        portsDstTcp.Add(portDst, 1);
                }
                else
                {
                    if (portsSrcUdp.ContainsKey(portSrc))
                        portsSrcUdp[portSrc]++;
                    else
                        portsSrcUdp.Add(portSrc, 1);
                    if (portsDstUdp.ContainsKey(portDst))
                        portsDstUdp[portDst]++;
                    else
                        portsDstUdp.Add(portDst, 1);
                }

                string service = flow.ApplicationProto;
                if (services.ContainsKey(service))
                    services[service]++;
                else
                    services.Add(service, 1);

                string time = flow.StartTime.AddMinutes(-flow.StartTime.Minute).ToString("yyyy-MM-dd HH:mm");
                if (timeStart.ContainsKey(time))
                    timeStart[time]++;
                else
                    timeStart.Add(time, 1);

                TimeSpan length = flow.Length;
                if (length.CompareTo(Constants.MIN) <= 0)
                    timeLength[Constants.FilterLength[0]]++;
                else if (length.CompareTo(Constants.MIN10) <= 0)
                    timeLength[Constants.FilterLength[1]]++;
                else if (length.CompareTo(Constants.HOUR) <= 0)
                    timeLength[Constants.FilterLength[2]]++;
                else
                    timeLength[Constants.FilterLength[3]]++;

                int flowSize = (int)(flow.BytesAB + flow.BytesBA);
                if (flowSize <= Constants.KB64)
                    sizes[Constants.FilterSize[0]]++;
                else if (flowSize <= Constants.MB)
                    sizes[Constants.FilterSize[1]]++;
                else if (flowSize <= Constants.MB10)
                    sizes[Constants.FilterSize[2]]++;
                else
                    sizes[Constants.FilterSize[3]]++;

                foreach (string name in customNames)
                {
                    if (_options.CustomFilters.MatchFilter(name, flow))
                    {
                        //play sound if custom filter notification set and first flow occured
                        if (customFilters[name] == 0 && _options.CustomFilters.DoNotify(name))
                        {
                            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.DOORBL);
                            simpleSound.Play();
                        }
                        customFilters[name]++;
                    }
                }
                
            }

			for (int i = 0; i < _options.CheckedFilters.Count; i++)
			{
				switch (_options.CheckedFilters[i])
				{
					case FilterName.Address:
                        _filtersForm.FiltersTree.RefreshNodeChildren(FilterName.AddressSrc, addressesSrc, null, _options.CustomFilters);
                        _filtersForm.FiltersTree.RefreshNodeChildren(FilterName.AddressDst, addressesDst, null, _options.CustomFilters); break;
					case FilterName.Port:
                        _filtersForm.FiltersTree.RefreshNodeChildren(FilterName.PortSrcTcp, portsSrcTcp, null, _options.CustomFilters);
                        _filtersForm.FiltersTree.RefreshNodeChildren(FilterName.PortSrcUdp, portsSrcUdp, null, _options.CustomFilters);
                        _filtersForm.FiltersTree.RefreshNodeChildren(FilterName.PortDstTcp, portsDstTcp, null, _options.CustomFilters);
                        _filtersForm.FiltersTree.RefreshNodeChildren(FilterName.PortDstUdp, portsDstUdp, null, _options.CustomFilters); break;
					case FilterName.Service:
                        _filtersForm.FiltersTree.RefreshNodeChildren(FilterName.Service, services, null, _options.CustomFilters); break;
					case FilterName.Time:
                        _filtersForm.FiltersTree.RefreshNodeChildren(FilterName.TimeStart, timeStart, null, _options.CustomFilters);
                        _filtersForm.FiltersTree.RefreshNodeChildren(FilterName.TimeLength, timeLength, null, _options.CustomFilters); break;
					case FilterName.Custom:
                        _filtersForm.FiltersTree.RefreshNodeChildren(FilterName.Custom, customFilters, CustomFiltersContextMenuStrip, _options.CustomFilters); break;
					case FilterName.Size:
                        _filtersForm.FiltersTree.RefreshNodeChildren(FilterName.Size, sizes, null, _options.CustomFilters); break;
                    default:
						break;
				}
			}
			_filtersForm.FiltersTree.ExpandAll();
		}

		void FiltersTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			TreeNode selectedNode = _filtersForm.FiltersTree.SelectedNode;
            _mapForm.Clear();
            _statForm.Clear();
            if ((NodeTag)selectedNode.Tag != NodeTag.Viewable)
            {
                _flowsForm.FillFlowsTable(null);
                _filtersForm.Filter = string.Empty;
                return;
            }
			FilterName filter = (FilterName)Enum.Parse(typeof(FilterName), selectedNode.Parent.Name);
            _filtersForm.Filter = (filter == FilterName.Custom) ? _options.CustomFilters.GetFilterText(selectedNode.Name) : 
                _filtersForm.Filter = string.Empty;
			ShowFlowsForFilter(filter, selectedNode.Name);
		}

		private void ShowFlowsForFilter(FilterName filterName, string filterValue)
		{
			Flow []flows = {};
			DateTime start = fromDateTimePicker.Value;
			DateTime end = toDateTimePicker.Value;
            IPAddress ip;

			switch (filterName)
			{
				case FilterName.Size:
                    if (filterValue.Equals(Constants.FilterSize[0]))
                        flows = _flows.GetFlowsBySize((uint)0, (uint)Constants.KB64, start, end);
                    else if (filterValue.Equals(Constants.FilterSize[1]))
                        flows = _flows.GetFlowsBySize((uint)Constants.KB64, (uint)Constants.MB, start, end);
                    else if (filterValue.Equals(Constants.FilterSize[2]))
                        flows = _flows.GetFlowsBySize((uint)Constants.MB, (uint)Constants.MB10, start, end);
					else
                        flows = _flows.GetFlowsBySize((uint)Constants.MB10, (uint)0, start, end);
					break;
				case FilterName.AddressSrc:
                    if (IPAddress.TryParse(filterValue, out ip))
                    {
                        flows = _flows.GetFlowsBySrcAddress(ip, start, end);
                    }
                    else
                    {
                        flows = _flows.GetFlowsBySrcName(filterValue, start, end);
                    }
                    break;
                case FilterName.AddressDst:
                    if (IPAddress.TryParse(filterValue, out ip))
                    {
                        flows = _flows.GetFlowsByDstAddress(ip, start, end);
                    }
                    else
                    {
                        flows = _flows.GetFlowsByDstName(filterValue, start, end);
                    }
					break;
				case FilterName.PortSrcTcp:
					flows = _flows.GetFlowsBySrcPortAndTransport(ushort.Parse(filterValue), TransportProtocol.TCP, start, end);
					break;
                case FilterName.PortSrcUdp:
                    flows = _flows.GetFlowsBySrcPortAndTransport(ushort.Parse(filterValue), TransportProtocol.UDP, start, end);
                    break;
                case FilterName.PortDstTcp:
                    flows = _flows.GetFlowsByDstPortAndTransport(ushort.Parse(filterValue), TransportProtocol.TCP, start, end);
                    break;
                case FilterName.PortDstUdp:
                    flows = _flows.GetFlowsByDstPortAndTransport(ushort.Parse(filterValue), TransportProtocol.UDP, start, end);
                    break;
				case FilterName.Service:
					flows = _flows.GetFlowsByService(filterValue, start, end);
					break;
				case FilterName.TimeStart:
					start = DateTime.Parse(filterValue);
					end = start.Add(new TimeSpan(0, 59, 59));
                    flows = _flows.GetFlowsByDate(start, end);
					break;
                case FilterName.TimeLength:
                    if (filterValue.Equals(Constants.FilterLength[0])) 
                        flows = _flows.GetFlowsByLength(new TimeSpan(0, 0, 0), Constants.MIN, start, end);
                    else if (filterValue.Equals(Constants.FilterLength[1]))
                        flows = _flows.GetFlowsByLength(Constants.MIN, Constants.MIN10, start, end);
                    else if (filterValue.Equals(Constants.FilterLength[2]))
                        flows = _flows.GetFlowsByLength(Constants.MIN10, Constants.HOUR, start, end);
                    else
                        flows = _flows.GetFlowsByLength(Constants.HOUR, new TimeSpan(0, 0, 0), start, end);
                    break;
				case FilterName.Custom:
					flows = _options.CustomFilters.FilterFlows(filterValue, _flows._Flows, start, end);
					break;
				default:
					break;
			}
			_flowsForm.FillFlowsTable(flows);
            _mapForm.ShowMap(flows);
            _statForm.ShowStatistics(flows);
		}

        private void stopCapture()
        {
            if (_onlineParser.IsCapturing)
            {
                _onlineParser.StopCapture();
            }
        }

        private void StartStopToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (StartStopToolStripMenuItem.Text == "Start")
                {
                    InterfacesForm inter = new InterfacesForm(_onlineParser);
                    inter.ShowDialog(this);
                    if (_onlineParser.IsCapturing)
                    {
                        StartStopToolStripMenuItem.Text = "Stop";
                    }
                }
                else
                {
                    stopCapture();
                    StartStopToolStripMenuItem.Text = "Start";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error");
            }
        }

        private void GetParsersStat()
        {
            InfoStatusLabel.Text = "";
            InfoStatusLabel.ToolTipText = "";
            if (_onlineParser.IsCapturing)
            {
                InfoStatusLabel.Text += "Capturing from network device";
                InfoStatusLabel.ToolTipText += _onlineParser.DeviceName;
            }
            InfoStatusLabel.Text += " / ";
            InfoStatusLabel.ToolTipText += " / ";
            if (_offlineParser.IsCapturing)
            {
                InfoStatusLabel.Text += "Parsing file";
                InfoStatusLabel.ToolTipText += _offlineParser.DeviceName;
            }
            PacketsStatusLabel.Text = "Packets: " + (_onlineParser.Packets + _offlineParser.Packets);
            BytesStatusLabel.Text = "KBytes: " + (_onlineParser.KBytes + _offlineParser.KBytes);
            FlowsStatusLabel.Text = "Flows: " + (_onlineParser.FlowsNum + _offlineParser.FlowsNum);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            GetParsersStat();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnLoadButton();
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            MemorizeRefresh(true);
        }

        private void OnLoadButton()
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            loadFiles(openFileDialog.FileNames);
        }

        private void loadFiles(string []files)
        {
            bool needCapture = false;
            foreach (string name in files)
            {
                if (Path.GetExtension(name).ToLower().Equals(".xml"))
                {
                    FlowsXmlStorage loader = new FlowsXmlStorage();
                    //загрузка потоков из XML
                    try
                    {
                        _flows.MergeFlows(loader.Load(name));
                        _flowsForm.ClearFlowsTable();
                        _mapForm.Clear();
                        _statForm.Clear();
                        RefreshFiltersTree();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(String.Format
                            ("File '{0}': loading flows error - {1}",
                            Path.GetFileName(name), e.Message), "Error");
                    }
                }
                else
                {
                    _offlineParser.AddOfflineDevice(name);
                    needCapture = true;
                }
            }
            //старт захвата потоков
            if (needCapture)
                _offlineParser.StartCapture();
        }

        private void OnSaveButton()
        {
            if (saveFlowsDialog.ShowDialog() == DialogResult.OK)
            {
                FlowsXmlStorage saver = new FlowsXmlStorage();
                try
                {
                    saver.Store(_flows._Flows, saveFlowsDialog.FileName);
                }
                catch(Exception ee)
                {
                    MessageBox.Show("Failed to save flows: " + ee.Message, "Error");
                }
            }
        }

public void MemorizeRefresh(bool getNewFlows)
{
    _mapForm.Clear();
    _statForm.Clear();
    List<string> nodes = new List<string>();
    TreeNode node = _filtersForm.FiltersTree.SelectedNode;
    TreeNode parentNode = node;
    //сохраняем выбранную иерархию
    while(parentNode != null)
    {
        nodes.Add(parentNode.Name);
        parentNode = parentNode.Parent;
    }
    //выби раем потоки из парсеров при необходимости
    if (getNewFlows)
    {
        _flows.MergeFlows(_offlineParser.Flows);
        _flows.MergeFlows(_onlineParser.Flows);
    }
    RefreshFiltersTree();
    //после обновления фильтрового дерева находим запомненый узел
    if (node == null || (NodeTag)node.Tag != NodeTag.Viewable)
       return;
    FilterName filter = FilterName.Custom;
    try
    {
        for (int i = nodes.Count - 1; i >= 0; i--)
        {
            node = ((i == nodes.Count - 1) ? 
                _filtersForm.FiltersTree.Nodes : 
                node.Nodes).Find(nodes[i], false)[0];
            node.Expand();
            //сохраняем имя родителя
            if (i == 1)
                filter = (FilterName)Enum.Parse(
                    FilterName.Custom.GetType(), node.Name);
        }
        if (node != null)
        {
            ShowFlowsForFilter(filter, node.Name);
            _filtersForm.FiltersTree.SelectedNode = node;
        }
    }
    catch { }
}

        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            // Handle FileDrop data.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Assign the file names to a string array, in 
                // case the user has selected multiple files.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                loadFiles(files);
                
            }
        }

        private void OnCleanButton()
        {
            _flows._Flows.Clear();
            _filtersForm.FiltersTree.ClearNodes();
            _flowsForm.ClearFlowsTable();
            _mapForm.Clear();
            _statForm.Clear();
        }

        private void MainForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            _onlineParser.StopCapture();
            _offlineParser.StopCapture();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OnCleanButton();
        }

        private void CleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnCleanButton();
        }

        private void AutoRefreshStripButton_Click(object sender, EventArgs e)
        {
            _autoRefresh = !_autoRefresh;
            RefreshTimer.Enabled = _autoRefresh;
            AutoRefreshStripButton.Checked = _autoRefresh;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            MemorizeRefresh(true);
            GetParsersStat();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCustomFilter();
        }

        public void DeleteCustomFilter()
        {
            TreeNode node = _filtersForm.ClickedNode;
            try
            {
                if ( node != null && node.Parent.Name.Equals(FilterName.Custom.ToString()))
                {
                    _options.CustomFilters.RemoveFilter(node.Name);
                    try
                    {
                        _options.store();
                    }
                    catch(Exception ee)
                    {
                        MessageBox.Show("Failed to store configuration: " + ee.Message, "Error");
                    }
                    RefreshFiltersTree();
                }
            }
            catch { }
        }

        private void filtersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltersHelpForm help = new FiltersHelpForm(_filtersForm);
            help.Show();
        }

        private void RefreshTimeStripTextBox_MouseEnter(object sender, EventArgs e)
        {
            RefreshTimeStripTextBox.BackColor = Color.White;
        }

        private void RefreshTimeStripTextBox_MouseLeave(object sender, EventArgs e)
        {
            RefreshTimeStripTextBox.BackColor = System.Drawing.SystemColors.Control;
            try
            {
                RefreshTimer.Interval = Int32.Parse(RefreshTimeStripTextBox.Text) * 1000;
            }
            catch
            {
                MessageBox.Show("Invalid refresh time specified. Set to default(15)", "Error");
            }
        }

        private void CustomFiltersContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            //show menu only if custom filter is selected
            try
            {
                if (_filtersForm.ClickedNode.Parent.Name.Equals(FilterName.Custom.ToString()))
                    return;
            }
            catch{}
            e.Cancel = true;

        }

        private void notifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = _filtersForm.FiltersTree.SelectedNode;
                _options.CustomFilters.ChangeNotify(node.Name);
                RefreshFiltersTree();
            }
            catch { }
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            OnSaveButton();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnSaveButton();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                RefreshFiltersTree();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _filtersForm.RenameFilter(_filtersForm.ClickedNode.Name);
        }
	}

	public enum FilterName {  Address, AddressSrc, AddressDst, Packets,
    Port, PortSrc, PortDst, PortSrcUdp, PortSrcTcp, PortDstTcp, PortDstUdp,
        Service, Time, TimeLength, TimeStart, Custom, Size}
}
