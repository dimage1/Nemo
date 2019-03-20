using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace Nemo.GUI
{
	public interface INodesContainer
	{
		TreeListNodeCollection Nodes
		{
			get;
		}
	}

	public class TreeListView : ListView, INodesContainer
	{
		public const string cPlus = "Plus";
		public const string cMinus = "Minus";

		private TreeListNodeCollection _nodes;
		private bool _imageListsInitialized = false;
        public bool ExpandedAll = false;

		public bool ImageListsInitialized
		{
			get { return _imageListsInitialized; }
			set { _imageListsInitialized = value; }
		}

		public TreeListNodeCollection Nodes
		{
			get { return _nodes; }
		}

		public TreeListView()
		{
			this.View = View.Details;
			InitializeImageLists();
			_nodes = new TreeListNodeCollection(this);
		}

		public void InitializeImageLists()
		{
			this.StateImageList = new ImageList();
            this.StateImageList.Images.Add(cMinus, global::Nemo.Properties.Resources.Minus);
            this.StateImageList.Images.Add(cPlus, global::Nemo.Properties.Resources.Plus);
			//this.SmallImageList = ImageListProvider.ImageList;
		}

protected override void OnMouseClick(MouseEventArgs e)
{
	if (e.Button == MouseButtons.Left)
	{
		ListViewItem listViewItem = this.GetItemAt(e.X, e.Y);
		if (listViewItem != null)
		{
			Rectangle rectangle = new Rectangle(
				listViewItem.Position.X - 
                SystemInformation.SmallIconSize.Width,
				listViewItem.Position.Y,
				SystemInformation.SmallIconSize.Width,
				SystemInformation.SmallIconSize.Height);
			if (rectangle.Contains(e.X, e.Y))
				(listViewItem as TreeListNode).Toggle();
		}
	}
	base.OnMouseClick(e);
}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			try
			{
				switch (e.KeyCode)
				{
					case Keys.Enter:
						(this.SelectedItems[0] as TreeListNode).Toggle();
						break;
					case Keys.Right:
					case Keys.Add:
						(this.SelectedItems[0] as TreeListNode).Expand();
						break;
					case Keys.Left:
					case Keys.Subtract:
						(this.SelectedItems[0] as TreeListNode).Collapse();
						break;
					default:
						base.OnKeyDown(e);
						break;
				}
			}
			catch { }
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		public void ExpandAll()
		{
            ExpandedAll = true;
            foreach (TreeListNode node in _nodes)
			{
				node.Expand();
			}
            _nodes[_nodes.Count - 1].EnsureVisible();
		}

        public void CollapseAll()
        {
            ExpandedAll = false;
            foreach (TreeListNode node in _nodes)
            {
                node.Collapse();
            }
            _nodes[_nodes.Count - 1].EnsureVisible();
        }
	}

	public class TreeListNode : ListViewItem, INodesContainer
	{
		private TreeListNode _parentNode;
		private bool _expanded;
		private TreeListNodeCollection _nodes;

		public TreeListNode ParentNode
		{
			get { return _parentNode; }
			set { _parentNode = value; }
		}

		public bool Expanded
		{
			get { return _expanded; }
		}

		public TreeListNodeCollection Nodes
		{
			get { return _nodes; }
		}

		public TreeListNode(string[] items)
			: base(items)
		{
			_nodes = new TreeListNodeCollection(this);
			_expanded = false;
			_parentNode = null;
		}

		public TreeListNode(string item)
			: base(item)
		{
			_nodes = new TreeListNodeCollection(this);
			_expanded = false;
			_parentNode = null;
		}

		public void Expand()
		{
			if (_expanded || _nodes.Count == 0 || this.ListView == null)
				return;

			//this.ListView.BeginUpdate();

			int index = this.Index;
			foreach (TreeListNode node in _nodes)
			{
				this.ListView.Items.Insert(++index, node);
				if (node.Expanded)
					ExpandNode(node, ref index);
			}
			_expanded = true;
			this.StateImageIndex = 0;// TreeListView.cMinus;
			//this.ListView.EndUpdate();
		}


		private void ExpandNode(TreeListNode node, ref int index)
		{
            foreach (TreeListNode childNode in node.Nodes)
			{
				node.ListView.Items.Insert(++index, childNode);
				if (childNode.Expanded)
					ExpandNode(childNode, ref index);
			}
		}

		public void Collapse()
		{
            if (!_expanded || _nodes.Count == 0 || this.ListView == null)
				return;

			//this.ListView.BeginUpdate();

			foreach (TreeListNode node in _nodes)
			{
				CollapseNode(node);
			}

			_expanded = false;
			this.StateImageIndex = 1;
			//this.ListView.EndUpdate();
		}

		private void CollapseNode(TreeListNode node)
		{
			if (node.Expanded)
			{
				foreach (TreeListNode childNode in node.Nodes)
				{
					CollapseNode(childNode);
				}
			}
			node.ListView.Items.RemoveAt(node.Index);
		}

		public void Toggle()
		{
			if (_nodes.Count == 0)
				return;
			if (_expanded)
				Collapse();
			else
				Expand();
		}
	}

	public class TreeListNodeCollection : BaseCollection
	{
		private INodesContainer _parent;
		private ArrayList _list;

		protected override ArrayList List
		{
			get { return _list; }
		}

		public override int Count
		{
			get { return _list.Count; }
		}


		public TreeListNodeCollection(INodesContainer parent)
		{
			_parent = parent;
			_list = new ArrayList();
		}

		public void Insert(int index, TreeListNode node)
		{
			TreeListNode parent = _parent as TreeListNode;
			if (parent != null)
			{
				node.IndentCount = parent.IndentCount + 1;
				IncreaseChildrenIndentation(node);
				parent.StateImageIndex = parent.Expanded ? 0 : 1;
				if (parent.Expanded && parent.ListView != null)
					parent.ListView.Items.Insert(parent.Index + index, node);
				node.ParentNode = parent;
			}
			else
				(_parent as ListView).Items.Insert(index, node);

			_list.Insert(index, node);
		}

		public void Add(TreeListNode node)
		{
			TreeListNode parent = _parent as TreeListNode;
			if (parent != null)
			{
				Point pos = node.Position;
				pos.X = pos.X / 2 - 10;
				node.Position = pos;
				node.IndentCount = parent.IndentCount + 1;
				IncreaseChildrenIndentation(node);
				parent.StateImageIndex = parent.Expanded ? 0 : 1;
				int index = _list.Add(node);
				if (parent.Expanded && parent.ListView != null)
					parent.ListView.Items.Insert(parent.Index + index, node);
				node.ParentNode = parent;
			}
			else
			{
				(_parent as ListView).Items.Add(node);
				_list.Add(node);
			}
		}

		private static void IncreaseChildrenIndentation(TreeListNode parentNode)
		{
			foreach (TreeListNode node in parentNode.Nodes)
			{
				node.IndentCount = parentNode.IndentCount + 1;
				IncreaseChildrenIndentation(node);
			}
		}

		public void Remove(TreeListNode node)
		{
			_list.Remove(node);
			TreeListNode parent = _parent as TreeListNode;
			if (parent != null)
			{
				//parent.StateImageIndex = -1;
				if (parent.Expanded && parent.ListView != null)
				{
					if (node.Expanded)
						node.Collapse();
					parent.ListView.Items.RemoveAt(node.Index);
				}

				if (parent.Nodes.Count > 0)
					parent.StateImageIndex = parent.Expanded ? 0 : 1;
				else
					parent.StateImageIndex = -1;
			}
			else
				(_parent as ListView).Items.RemoveAt(node.Index);
			node.ParentNode = null;
		}

		public TreeListNode this[int index]
		{
			get { return _list[index] as TreeListNode; }
		}

		public void Clear()
		{
			TreeListNode parent = _parent as TreeListNode;
			if (parent != null)
			{
				if (parent.Expanded && parent.ListView != null)
					parent.Collapse();
				parent.StateImageIndex = -1;
			}
			else
				(_parent as ListView).Items.Clear();
			foreach (TreeListNode node in _list)
			{
				node.ParentNode = null;
			}
			_list.Clear();
		}
	}
}
