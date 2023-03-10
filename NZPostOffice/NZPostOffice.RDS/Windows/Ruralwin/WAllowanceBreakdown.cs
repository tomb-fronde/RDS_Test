using System;
using System.Windows.Forms;
using NZPostOffice.Shared.Windows;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruralwin;
using System.Collections.Generic;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    // TJB  Allowances  26-Apr-2021
    // Adjusting size etc to accommodate changed DAllowanceBreakdown
    //
    // TJB RPCR_017 July-2010
    // Fixed delete row function
    // - Fixed bug in pfc_deleteRow that allowed a paid allowance to be deleted
    // - Added recalculation of allowance total when row deleted
    // - Added parent reset when row deleted

    public class WAllowanceBreakdown : WMaster
    {
        #region Define
        public int il_contract;
        public int il_altKey;
        public int il_caRow;
        public string is_altDescription;
        public URdsDw idw_1;

        private System.ComponentModel.IContainer components = null;

        public Button cb_close;
        public URdsDw dw_1;

        #endregion

        public WAllowanceBreakdown()
        {
            m_sheet = new MSheet(this);
            this.InitializeComponent();
            dw_1.DataObject = new DAllowanceBreakdown();
            this.dw_1.DataObject.BorderStyle = BorderStyle.None;

            idw_1 = dw_1;
            //m_sheet_menu.SetFunctionalPart(m_sheet);
            //m_sheet_toolbar.SetFunctionalPart(m_sheet);

            //jlwang:moved from IC
            dw_1.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_1_constructor);
            dw_1.PfcPreDeleteRow += new NZPostOffice.RDS.Controls.UserEventDelegate1(dw_1_pfc_predeleterow);
            dw_1.PfcDeleteRow += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_1_pfc_deleterow);
            //jlwang:end
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_close = new System.Windows.Forms.Button();
            this.dw_1 = new NZPostOffice.RDS.Controls.URdsDw();
            this.SuspendLayout();
            // 
            // cb_close
            // 
            this.cb_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_close.Location = new System.Drawing.Point(782, 7);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(72, 20);
            this.cb_close.TabIndex = 1;
            this.cb_close.Text = "Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            // 
            // dw_1
            // 
            this.dw_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_1.DataObject = null;
            this.dw_1.FireConstructor = false;
            this.dw_1.Location = new System.Drawing.Point(0, 0);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(766, 219);
            this.dw_1.TabIndex = 2;
            this.dw_1.RowFocusChanged += new System.EventHandler(this.dw_1_rowfocuschanged);
            // 
            // WAllowanceBreakdown
            // 
            this.AcceptButton = this.cb_close;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(867, 222);
            this.Controls.Add(this.cb_close);
            this.Controls.Add(this.dw_1);
            this.Location = new System.Drawing.Point(82, 89);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WAllowanceBreakdown";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Controls.SetChildIndex(this.dw_1, 0);
            this.Controls.SetChildIndex(this.cb_close, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

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

        #endregion

        public override void pfc_preopen()
        {
            int ll_dwHeight = 0;
            NRdsMsg lnv_msg;
            NCriteria lvn_Criteria;

            this.of_bypass_security(true);
            lnv_msg = StaticMessage.PowerObjectParm as NRdsMsg;
            lvn_Criteria = lnv_msg.of_getcriteria();
            il_contract = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("Contract_no"));
            il_altKey = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("alt_key"));
            is_altDescription = System.Convert.ToString(lvn_Criteria.of_getcriteria("alt_description"));
            il_caRow = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("allowance_row"));

            dw_1.DataObject.Reset();
            ((DAllowanceBreakdown)dw_1.DataObject).Retrieve(il_contract, il_altKey);
/*
            ll_dwHeight = (dw_1.RowCount + 1) * 22 + 28 + 20;
            this.Height = ll_dwHeight;
            this.dw_1.Height = ll_dwHeight;
*/
            this.Left = Cursor.Position.X - 20;
            this.Top = Cursor.Position.Y - 20;
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            bool lb_hasDelPriv = false;
            this.of_set_componentname("Allowance");
            this.Text = is_altDescription + " allowance history";
            lb_hasDelPriv = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentid("Allowance"), this.of_get_regionid(), "D", false);
            idw_1.of_set_createpriv(false);
            idw_1.of_set_modifypriv(false);
            idw_1.of_set_deletepriv(lb_hasDelPriv);
            idw_1.Focus();
        }

        public override int pfc_save()
        {
            base.pfc_save();
            idw_1.Save();
            this.Close();
            return 1;
        }

        public override void close()
        {
            base.close();
            // TJB RPCR_017 July 2010: Add
            // Tell parent to reset to pick up any changes
            // (the only change is a row deletion).
            if (rowDeleted)
            {
                ((WContract2001)StaticVariables.window).idw_allowances.Reset();
                ((WContract2001)StaticVariables.window).idw_allowances.Retrieve(new object[] { il_contract });
                StaticVariables.window = null;
            }
        }

        public virtual void dw_1_constructor()
        {
            idw_1 = dw_1;
            dw_1.of_SetUpdateable(true);
        }

        public virtual int dw_1_pfc_predeleterow()
        {
            int nRow;
            DateTime? ld_paidToDate;
            //int DODELETE = 1;
            //int DONTDELETE = 0;

            // TJB July 2010: bug fix
            // Changed index from 0 to index of selected row
            // Was allowing deletion of paid-to record if row 0 was deletable
            nRow = idw_1.GetRow();
            ld_paidToDate = idw_1.GetItem<AllowanceBreakdown>(nRow).PaidToDate;
            if ((ld_paidToDate == null))
            {
                return 1;  //return DODELETE;
            }
            MessageBox.Show("You cannot delete an allowance that has been paid.  "
                           , "Warning"
                           , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return -1;     //return DONTDELETE;
        }

        private bool rowDeleted = false;
        public virtual void dw_1_pfc_deleterow()
        {
            //?if (ancestorreturnvalue == 1) {
            //    idw_1.of_Set_ModifyPriv(true);
            //    idw_1.postevent("getfocus");
            //}
            dw_1.SelectRow(0, false);
            dw_1.SelectRow(dw_1.GetRow() + 1, true);
            // TJB RPCR_017 July-2010: added
            // Recalculate the total after deleting a record.
            decimal? TotalAmount = 0;
            decimal? A = 0;
            for (int i = 0; i < idw_1.RowCount; i++)
            {
                A = idw_1.GetItem<AllowanceBreakdown>(i).AnnualAmount;
                if (A == null) A = 0;
                TotalAmount += A;
            }
            ((DAllowanceBreakdown)dw_1.DataObject).setTotal(TotalAmount);
            rowDeleted = true;
            return;
        }

        #region Events

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void dw_1_rowfocuschanged(object sender, EventArgs e)
        {
            dw_1.SelectRow(0, false);
            dw_1.SelectRow(dw_1.GetRow() + 1, true);
        }
        #endregion
    }
}
