namespace NZPostOffice.RDSAdmin.Menus
{
    using System;
    using System.Windows.Forms;
    using NZPostOffice.Shared;
    using NZPostOffice.Shared.VisualComponents;


    // Security Application Frame Menu
    public class MSecurityTvs : ContextMenuStrip //: MTvs
    {
        private System.ComponentModel.IContainer components = null;

        /// Reference to the menu functions

        public ToolStripMenuItem m_add;

        public ToolStripMenuItem m_delete;

        private NZPostOffice.RDSAdmin.WMainMdi mainForm;

        public MSecurityTvs(NZPostOffice.RDSAdmin.WMainMdi _mainForm)
        {
            mainForm = _mainForm;
            this.InitializeComponent();            
        }

        private void InitializeComponent()
        {
            m_delete = new ToolStripMenuItem();
            m_delete.Visible = true;
            m_delete.Enabled = true;
            m_delete.Text = "Delete";
            m_delete.ToolTipText = "Deletes selected rows";
            m_delete.Click += new EventHandler(m_delete_Click);
            // 
            // m_viewitem
            // 
            m_add = new ToolStripMenuItem();
            // m_viewitem.MenuItems.Add(m_add);
            // 
            // m_add
            // 
            m_add.Text = "Add";
            m_add.Enabled = true;
            m_add.Visible = true;
            m_add.Click += new EventHandler(m_add_clicked);
            Items.Add(m_add);
            Items.Add(m_delete);
        }

        private void m_delete_Click(object sender, EventArgs e)
        {
            UTvs tv_1 = (UTvs)mainForm.Controls["tv_1"];
            TreeNode parent_node = tv_1.SelectedNode.Parent;
            int parent_node_child_count = parent_node.Nodes.Count;
            int curr_index = tv_1.SelectedNode.Index;
            string node_text = tv_1.SelectedNode.Text;
            mainForm.pfc_deleteitem();
            if (parent_node.Nodes.Count < parent_node_child_count)
            {
                if (parent_node.Nodes.Count > curr_index)
                    tv_1.SelectedNode = parent_node.Nodes[curr_index];
                else
                    mainForm.ue_navigated();
                if (parent_node.Level == 1)
                {
                    if (parent_node.Parent.Index == 0)
                    {
                        TreeNode other_node = parent_node.Parent.NextNode.FirstNode;
                        while (other_node != null)
                        {
                            if (other_node.Text == node_text)
                            {
                                other_node.Nodes.Clear();
                                tv_1.Populate(other_node, true);
                                break;
                            }
                            other_node = other_node.NextNode;
                        }
                    }
                    else if (parent_node.Parent.Index == 1)
                    {
                        TreeNode other_node = parent_node.Parent.PrevNode.FirstNode;
                        while (other_node != null)
                        {
                            if (other_node.Text == node_text)
                            {
                                other_node.Nodes.Clear();
                                tv_1.Populate(other_node, true);
                                break;
                            }
                            other_node = other_node.NextNode;
                        }
                    }
                }
            }
       }

        public virtual void SetFunctionalPart(MSecurityTvs _m_security_tvs)
        {
            //!base.SetFunctionalPart(_m_security_tvs);
        }
        //public override void ToolBarButtonClick(object sender, ToolBarButtonClickEventArgs e)
        public virtual void ToolBarButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            /*!
            switch (this.Buttons.IndexOf(e.Button))
            {
                default:
                    //!base.ToolBarButtonClick(sender, e);
                    break;
            }
             */
        }
        public virtual void m_add_clicked(object sender, EventArgs e)
        {            
            mainForm.ue_additem();
        }
        //protected override void Dispose(bool disposing)
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
