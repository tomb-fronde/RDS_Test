using System;
using System.Data;
using System.Windows.Forms;
using NZPostOffice.Shared.Windows;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDSAdmin.DataControls.Security;
using NZPostOffice.RDSAdmin.Entity.Security;
using NZPostOffice.RDSAdmin.DataService;

namespace NZPostOffice.RDSAdmin
{
    public class WSecurityComponent : WResponse
    {
        public bool ib_Action = false;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_close;

        public Label st_1;

        public Button cb_select;

        public DwComponentList dw_component_search;

        public DwSearchComponent dw_1;

        public WSecurityComponent()
        {
            this.InitializeComponent();
            Control col = dw_1.GetControlByName("search");
            col.TextChanged += new EventHandler(this.dw_1_EditChanged);
            dw_component_search.DoubleClick += new EventHandler(dw_component_search_DoubleClick);
            dw_component_search.Retrieve();
            col.Focus();
        }

        private void dw_component_search_DoubleClick(object sender, EventArgs e)
        {
            if (dw_component_search.Grid.SelectedRows.Count > 0)
            {
                cb_select_clicked(null, null);
            }
        }

        public override void open()
        {
            base.open();
            //SetFocus(dw_1);
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_bypass_security(true);
        }

        public override void close()
        {
            base.close();
            Structures.StrInfo lstr_info = new NZPostOffice.RDSAdmin.Structures.StrInfo();
            if (ib_Action == false)
            {
                // 	Message.PowerObjectParm = lstr_info
                //CloseWithReturn(this, lstr_info);
                StaticMessage.PowerObjectParm = lstr_info;
                this.Close();
            }
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_close = new System.Windows.Forms.Button();
            this.st_1 = new System.Windows.Forms.Label();
            this.cb_select = new System.Windows.Forms.Button();
            this.dw_component_search = new NZPostOffice.RDSAdmin.DataControls.Security.DwComponentList();
            this.dw_1 = new NZPostOffice.RDSAdmin.DataControls.Security.DwSearchComponent();
            this.SuspendLayout();
            // 
            // cb_close
            // 
            this.cb_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_close.Location = new System.Drawing.Point(163, 390);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(75, 23);
            this.cb_close.TabIndex = 3;
            this.cb_close.Text = "&Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            // 
            // st_1
            // 
            this.st_1.BackColor = System.Drawing.SystemColors.Control;
            this.st_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_1.Location = new System.Drawing.Point(7, 9);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(33, 16);
            this.st_1.TabIndex = 4;
            this.st_1.Text = "Find";
            // 
            // cb_select
            // 
            this.cb_select.Location = new System.Drawing.Point(80, 390);
            this.cb_select.Name = "cb_select";
            this.cb_select.Size = new System.Drawing.Size(75, 23);
            this.cb_select.TabIndex = 1;
            this.cb_select.Text = "&Select";
            this.cb_select.Click += new System.EventHandler(this.cb_select_clicked);
            // 
            // dw_component_search
            // 
            this.dw_component_search.BackColor = System.Drawing.SystemColors.Window;
            this.dw_component_search.FilterString = "";
            this.dw_component_search.Location = new System.Drawing.Point(10, 37);
            this.dw_component_search.Name = "dw_component_search";
            this.dw_component_search.Size = new System.Drawing.Size(228, 346);
            this.dw_component_search.SortString = "";
            this.dw_component_search.TabIndex = 2;
            // 
            // dw_1
            // 
            this.dw_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dw_1.FilterString = "";
            this.dw_1.Location = new System.Drawing.Point(39, 7);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(207, 26);
            this.dw_1.SortString = "";
            this.dw_1.TabIndex = 1;
            this.dw_1.EditChanged += new System.EventHandler(this.dw_1_EditChanged);
            // 
            // WSecurityComponent
            // 
            this.AcceptButton = this.cb_select;
            this.CancelButton = this.cb_close;
            this.ClientSize = new System.Drawing.Size(246, 417);
            this.Controls.Add(this.cb_close);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.cb_select);
            this.Controls.Add(this.dw_component_search);
            this.Controls.Add(this.dw_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WSecurityComponent";
            this.Text = "Component Search";
            this.ResumeLayout(false);

        }

        private void dw_1_EditChanged(object sender, EventArgs e)
        {
            int ll_Found = -1;
            string searchString = ((Control)sender).Text;
            if (string.IsNullOrEmpty(searchString))
            {
                return;
            }
            //s_find = "Trim ( Upper ( rc_description)) Like \'" + ((this.GetItemString(1, "search")).ToUpper()).Trim() + "%\'";
            for (int i = 0; i < dw_component_search.RowCount; i++)
            {
                if(dw_component_search.GetValue<string>(i, "rc_description").Trim().ToUpper().StartsWith(searchString.ToUpper().Trim()))
                {
                    ll_Found = i;
                    break;
                }
            }
            if (ll_Found >= 0)
            {
                dw_component_search.SetCurrent(ll_Found);
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            //! base.clicked();
            ib_Action = false;
            //close(parent);
            this.Close();
        }

        public virtual void cb_select_clicked(object sender, EventArgs e)
        {
            // Return the selected row
            int ll_component_id;
            string ls_component_name;
            Structures.StrInfo lstr_info = new NZPostOffice.RDSAdmin.Structures.StrInfo();
            if (dw_component_search.Grid.SelectedRows.Count == 0)
            {
                //MessageBox(parent.Title, "Please select a component.", information!, ok!, 1);
                System.Windows.Forms.MessageBox.Show(/*this.Title*/this.Text, "Please select a component.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            lstr_info.p_id = new System.Collections.Generic.List<int>();
            lstr_info.p_name = new System.Collections.Generic.List<string>();
            lstr_info.p_create = new System.Collections.Generic.List<string>();
            lstr_info.p_read = new System.Collections.Generic.List<string>();
            lstr_info.p_modify = new System.Collections.Generic.List<string>();
            lstr_info.p_delete = new System.Collections.Generic.List<string>();
            for (int i = 0; i < dw_component_search.Grid.SelectedRows.Count; i++)
            {
                ComponentList BE = dw_component_search.GetItem<ComponentList>(dw_component_search.Grid.SelectedRows[i].Index);
                ls_component_name = BE.RcDescription;
                ll_component_id = BE.RcId.GetValueOrDefault();
                lstr_info.p_id.Add(ll_component_id);
                lstr_info.p_name.Add(ls_component_name);
                lstr_info.p_create.Add(BE.RcAllowcreate);
                lstr_info.p_read.Add(BE.RcAllowread);
                lstr_info.p_modify.Add(BE.RcAllowmodify);
                lstr_info.p_delete.Add(BE.RcAllowdelete);
             }
            ib_Action = true;
            StaticMessage.PowerObjectParm = lstr_info;
            this.Close();


        }

        //protected class DwComponentSearch : URadDW
        //{
        //    WSecurityComponent window;

        //    public DwComponentSearch(DataControlPanel dcp)
        //        : base(dcp)
        //    {
        //        window = dcp.FindForm() as WSecurityComponent;
        //    }

        //    public override void constructor()
        //    {
        //        base.constructor();
        //        //!dw_component_search.SetTransObject(sqlca);
        //        //1dw_component_search.of_SetRowSelect(true);
        //        //!inv_rowselect.of_SetStyle(inv_rowselect.EXTENDED);
        //    }

        //    public override void doubleclicked(int xpos, int ypos, int row, DataColumn dwo)
        //    {
        //        base.doubleclicked(xpos, ypos, row, dwo);
        //        //!cb_select.TriggerEvent(clicked!);
        //    }
        //}

    }
}
