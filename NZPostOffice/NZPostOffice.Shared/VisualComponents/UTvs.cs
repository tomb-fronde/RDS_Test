using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Metex.Windows;

namespace NZPostOffice.Shared.VisualComponents
{
    // TJB Frequencies and Allowances Mar-2022
    // Fixed issue when debugging - disabled break on exception
    // (occurred in Populate(); exception caught and handled)

    public partial class UTvs : TreeView
    {
        public UTvs()
        {
            InitializeComponent();
            //this.AfterSelect += new TreeViewEventHandler(UTvs_AfterSelect);
            this.BeforeExpand += new TreeViewCancelEventHandler(UTvs_BeforeExpand);
        }

        void UTvs_AfterSelect(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.Nodes.Count == 0)
            {
                Populate(node,true);
            }
        }

        void UTvs_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            for(int i = 0; i< node.Nodes.Count;i++)
            {
                if (node.Nodes[i].Nodes.Count == 0)
                    Populate(node.Nodes[i], true);
            }
        }

        public virtual int Populate(TreeNode al_parent,bool retrievenext)
        {
            DataUserControlContainer lds_data = new DataUserControlContainer();
            Cursor.Current = Cursors.WaitCursor;
            //  retrieve the data into the services datastore
            if (this.Retrieve(al_parent, lds_data) < 0)
            {
                return -(1);
            }
            //  add the treeview data
            //return this.pfc_addall(al_parent, lds_data);
            if (lds_data != null && lds_data.DataObject!= null && lds_data.RowCount > 0)
            {
                for (int i = 0; i < lds_data.RowCount; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Tag = lds_data.DataObject.GetItem<Metex.Core.EntityBase>(i);
                    node.Text = (lds_data.GetValue<string>(i, "label")==null)?"":lds_data.GetValue<string>(i, "label").Trim();
                    node.ImageIndex = lds_data.GetValue<int>(i, "pictindex") - 1;
                    try
                    {
                        node.SelectedImageIndex = lds_data.GetValue<int>(i, "selectedpictindex") - 1;
                    }
                    catch
                    {
                        node.SelectedImageIndex = node.ImageIndex;
                    }
                    if (al_parent == null)
                    {                        
                        if(retrievenext)
                            Populate(node, false);
                        this.Nodes.Add(node);
                    }
                    else
                    {
                        al_parent.Nodes.Add(node);
                        if(retrievenext && al_parent.IsExpanded)
                            Populate(al_parent.Nodes[al_parent.Nodes.Count - 1], false);
                        
                    }
                }
            }
            return 1;
        }

        public virtual int Retrieve(TreeNode al_parent, DataUserControlContainer ads_data)
        {
            return -1;
        }
    }
}
