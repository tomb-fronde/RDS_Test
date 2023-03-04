using System;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDSAdmin.DataService;
using NZPostOffice.RDSAdmin.DataControls.Security;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin
{
    public class WSecurityOutletDetails : WResponse
    {
        public int il_region_id;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public DOutletForm dw_outlet_details;

        public Button cb_close;

        public Button cb_save;

        public WSecurityOutletDetails(int ll_outlet_id)
        {
            this.InitializeComponent();
            if (!DesignMode)
            {
                this.of_bypass_security(true);
                dw_outlet_details.Retrieve(ll_outlet_id);                
            }
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            //this.of_bypass_security(true);
            //int ll_outlet_id;
            //ll_outlet_id = System.Convert.ToInt32(StaticMessage.DoubleParm);
            //dw_outlet_details.Retrieve(ll_outlet_id);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dw_outlet_details = new NZPostOffice.RDSAdmin.DataControls.Security.DOutletForm();
            this.cb_close = new System.Windows.Forms.Button();
            this.cb_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dw_outlet_details
            // 
            this.dw_outlet_details.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dw_outlet_details.FilterString = "";
            this.dw_outlet_details.Location = new System.Drawing.Point(0, 0);
            this.dw_outlet_details.Name = "dw_outlet_details";
            this.dw_outlet_details.Size = new System.Drawing.Size(312, 210);
            this.dw_outlet_details.SortString = "";
            this.dw_outlet_details.TabIndex = 1;
            // 
            // cb_close
            // 
            this.cb_close.Location = new System.Drawing.Point(236, 216);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(75, 23);
            this.cb_close.TabIndex = 2;
            this.cb_close.Text = "&Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            // 
            // cb_save
            // 
            this.cb_save.Location = new System.Drawing.Point(155, 216);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(75, 23);
            this.cb_save.TabIndex = 1;
            this.cb_save.Text = "&Save";
            this.cb_save.Click += new System.EventHandler(this.cb_save_clicked);
            // 
            // WSecurityOutletDetails
            // 
            this.AcceptButton = this.cb_close;
            this.ClientSize = new System.Drawing.Size(315, 242);
            this.ControlBox = false;
            this.Controls.Add(this.dw_outlet_details);
            this.Controls.Add(this.cb_close);
            this.Controls.Add(this.cb_save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WSecurityOutletDetails";
            this.Text = "Outlet Information";
            this.ResumeLayout(false);

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

        //!        protected class DwOutletDetails : URadDW
        //        {
        //            WSecurityOutletDetails window;

        //            public DwOutletDetails(WSecurityOutletDetails wsq)
        //            {
        //                window = wsq;
        //            }

        //            public virtual void pfc_prermbmenu()
        //            {
        //                //! base.pfc_prermbmenu();
        //                /*!
        //                MRdsDw m_SecDw;
        //                // We create our own rmb menu inherited from m_tvs
        //                m_SecDw = new MRdsDw();
        //                m_SecDw.m_table.m_delete.visible = false;
        //                m_SecDw.m_table.m_Insert.visible = true;
        //                // Assign a parent because assignment below resets the parent
        //                m_SecDw.of_setparent(dw_outlet_details);
        //                // Assign our own menu 
        //                am_dw = m_SecDw;
        //                // Let ancestor do its normal processing
        //                base.dw_outlet_details_pfc_prermbmenu(am_dw);*/
        //            }
        //        }


        private int dw_outlet_details_pfc_preupdate()
        {
            int ll_outlet_id;
            int ll_max_outlet_id = 0;
            int ll_row;
            ll_row = dw_outlet_details.GetRow();
            ll_outlet_id = dw_outlet_details.GetValue<int>(ll_row, "Outlet_id");
            //il_region_id = w_main_mdi.dw_header.getitemnumber(1, "region_id");
            WMainMdi w_main_mdi = this.Owner as WMainMdi;
            if (w_main_mdi != null)
            {
                il_region_id = w_main_mdi.dw_header.GetValue<int>(0, "region_id");
            }
            // If no outlet_id exists then a row has been inserted
            if (ll_outlet_id == 0)
            {
                /*select max ( outlet_id)
into :ll_max_outlet_id
from outlet*/
                //int SQLCode = 0;
                //string SQLErrText = string.Empty;
                //StaticVariables.ServiceInterface.WSecurityOutletDetails_DwOutletDetails_pfc_preupdate_1(ref ll_max_outlet_id, ref SQLErrText, ref SQLCode);
                //if (SQLCode != 100 && SQLCode != 0)
                //{
                //    MessageBox.Show("Database Error", "Unable to Select the max outlet_id.  ~n~n" + "Error Code: " + SQLCode.ToString() + "~n~nError Text: " + SQLErrText);
                //    return FAILURE;
                //}
                MainMdiService.GetMaxOutletId(ref ll_max_outlet_id);

                // If an id was found - increment
                ll_max_outlet_id = ll_max_outlet_id + 1;
                dw_outlet_details.SetValue(0, "outlet_id", ll_max_outlet_id);
                dw_outlet_details.SetValue(0, "region_id", il_region_id);
                return il_region_id;
            }
            else
            {
                return il_region_id;
            }
        }
        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            //! base.clicked();
            int? ll_region_id;
            int ll_outlet_type = 0;
            int ll_row;
            int ll_rc = SUCCESS;
            string ls_outlet_name;
            OutletForm outlet = dw_outlet_details.Current as OutletForm;
            dw_outlet_details.AcceptText();
            if (StaticFunctions.IsDirty(dw_outlet_details))
            {
                ls_outlet_name = outlet.OName;
                if (string.IsNullOrEmpty(ls_outlet_name))
                {
                    MessageBox.Show("An outlet name must be specified.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ll_rc = FAILURE;
                }
                ll_outlet_type = outlet.OtCode.GetValueOrDefault();
                if (ll_outlet_type == 0)
                {
                    MessageBox.Show("An outlet type must be specified.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ll_rc = FAILURE;
                }
            }
            else
            {
                StaticMessage.DoubleParm = 0;
                this.Close();
                return;
            }
            if (ll_rc == SUCCESS)
            {
                ll_region_id = ((WMainMdi)this.Owner).dw_header.DataObject.GetItem<NZPostOffice.RDSAdmin.Entity.Security.Region>(0).RegionId;
                //  CloseWithReturn ( parent, ll_region_id)
                //  if save is not clicked - need to send back delete code
                //CloseWithReturn(parent, 0);

                int closevalue;
                closevalue = closeRequest();
                if (closevalue == 1)
                {
                    dw_outlet_details.Save();
                    StaticMessage.DoubleParm = 0;
                    this.Close();
                }
                else if (closevalue == 2)
                {
                    StaticMessage.DoubleParm = 0;
                    this.Close();
                }
                else
                {
                    return;
                }
                
            }
        }

        public int closeRequest()
        {
            DialogResult rlt;
            int returnvalue=0;
            rlt = MessageBox.Show("Do you want to save changes", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            switch(rlt)
            {
                case DialogResult.Yes:
                    returnvalue = 1;
                    break;
                case DialogResult.No:
                    returnvalue = 2;
                    break;
                case DialogResult.Cancel:
                    returnvalue = 3;
                    break;
            }
            return returnvalue;
        }

        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            //! base.clicked();
            int? ll_outlet_type;
            int ll_row;
            int ll_rc = SUCCESS;
            string ls_outlet_name;
            ll_row = dw_outlet_details.GetRow();
            dw_outlet_details.AcceptText();
            ls_outlet_name = dw_outlet_details.GetValue<string>(ll_row, "o_name");
            if (string.IsNullOrEmpty(ls_outlet_name))
            {
                MessageBox.Show("An outlet name must be specified.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ll_rc = FAILURE;
            }
            ll_outlet_type = dw_outlet_details.GetValue<int?>(ll_row, "ot_code");
            if (ll_outlet_type == 0 || ll_outlet_type == null )
            {
                MessageBox.Show("An outlet type must be specified.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ll_rc = FAILURE;
            }
            if (ll_rc == SUCCESS)
            {
                dw_outlet_details_pfc_preupdate();
                //dw_outlet_details.pfc_update(true, true);
                dw_outlet_details.Save();
                //CloseWithReturn(parent, il_region_id);
                StaticMessage.DoubleParm = il_region_id;
                this.Close();
            }
        }
    }
}
