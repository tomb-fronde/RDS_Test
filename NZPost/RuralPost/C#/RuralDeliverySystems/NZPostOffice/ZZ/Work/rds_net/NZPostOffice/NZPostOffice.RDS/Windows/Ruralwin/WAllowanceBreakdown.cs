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
    public class WAllowanceBreakdown : WMaster
    {
        #region Define
        public int il_contract;

        public int il_altKey;

        public int il_caRow;

        public URdsDw idw_1;//public dw_1 idw_1;

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
            this.SuspendLayout();

            this.cb_close = new Button();
            this.dw_1 = new URdsDw();
            //!dw_1.DataObject = new DAllowanceBreakdown();
            Controls.Add(cb_close);
            Controls.Add(dw_1);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(182, 89);
            this.Size = new System.Drawing.Size(649, 297);
            // 
            // cb_close
            // 
            this.AcceptButton = cb_close;
            cb_close.Text = "Close";
            cb_close.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_close.TabIndex = 1;
            cb_close.Location = new System.Drawing.Point(553, 4);
            cb_close.Size = new System.Drawing.Size(72, 20);
            cb_close.Click += new EventHandler(cb_close_clicked);
            // 
            // dw_1
            // 
            //!this.dw_1.DataObject.BorderStyle = BorderStyle.None;
            dw_1.VerticalScroll.Visible = false;
            dw_1.Size = new System.Drawing.Size(641, 272);
            dw_1.RowFocusChanged += new EventHandler(dw_1_rowfocuschanged);
            //dw_1.Constructor +=new NZPostOffice.RDS.Controls.UserEventDelegate(dw_1_constructor);
            //dw_1.PfcPreDeleteRow +=new NZPostOffice.RDS.Controls.UserEventDelegate1(dw_1_pfc_predeleterow);
            //dw_1.PfcDeleteRow +=new NZPostOffice.RDS.Controls.UserEventDelegate(dw_1_pfc_deleterow);
            this.ResumeLayout();
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
            il_caRow = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("allowance_row"));
            //?dw_1.settransobject(StaticVariables.sqlca);
            //?dw_1.setrowfocusindicator(focusrect!);

            dw_1.DataObject.Reset();
            ((DAllowanceBreakdown)dw_1.DataObject).Retrieve(il_contract, il_altKey);
            //ll_dwHeight = dw_1.RowCount * Metex.Common.Convert.ToInt32(dw_1.Describe("datawindow.detail.height")) + Metex.Common.Convert.ToInt32(dw_1.Describe("datawindow.header.height")) + Metex.Common.Convert.ToInt32(dw_1.Describe("datawindow.summary.height")) + PixelsToUnits(4, ypixelstounits!);
            ll_dwHeight = (dw_1.RowCount + 1) * 22 + 28 + 20;
            this.Height = ll_dwHeight;
            this.dw_1.Height = ll_dwHeight;
            this.Left = Cursor.Position.X;
            this.Top = Cursor.Position.Y - 50;
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            bool lb_hasDelPriv = false;
            this.of_set_componentname("Allowance");
            lb_hasDelPriv = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentid("Allowance"), this.of_get_regionid(), "D", false);
            idw_1.of_set_createpriv(false);
            idw_1.of_set_modifypriv(false);
            idw_1.of_set_deletepriv(lb_hasDelPriv);
            idw_1.Focus();//idw_1.postevent("getfocus");
        }

        public override int pfc_save()
        {
            base.pfc_save();
            idw_1.Save();//idw_1.update();
            //?commit;
            this.Close();
            return 1;
        }

        public override void close()
        {
            base.close();
            int ll_sheetcount;
            int ll_rc;
            Dictionary<int, WContract2001> lw_opensheets = new Dictionary<int, WContract2001>();//Cl_w_contract2001Array lw_opensheets = new Cl_w_contract2001Array();
            FormBase lw_frame;//w_frame lw_frame;
            lw_frame = StaticVariables.gnv_app.of_getframe();
            //?if (IsValid(lw_frame.inv_sheetmanager) == false)
            //{
            //    lw_frame.inv_sheetmanager = new n_cst_winsrv_sheetmanager();
            //}
            //ll_sheetcount = lw_frame.inv_sheetmanager.of_getsheetsbyclass(lw_opensheets, "w_contract2001");
            //if (ll_sheetcount < 2 && ll_sheetcount > 0)
            //{
            //    ll_rc = lw_opensheets[1].idw_allowances.Reset();
            //    ll_rc = lw_opensheets[1].idw_allowances.Retrieve(new object[] { il_contract });
            //    ll_rc = lw_opensheets[1].idw_allowances.SelectRow(0, false);
            //    ll_rc = lw_opensheets[1].idw_allowances.SelectRow(il_caRow, true);
            //}
            //?this.Close();//close(this);
        }

        public virtual void dw_1_constructor()
        {
            idw_1 = dw_1;
            dw_1.of_SetUpdateable(true);
        }

        public virtual int dw_1_pfc_predeleterow()
        {
            int ll_row;
            DateTime? ld_paidToDate;
            int DODELETE = 1;
            int DONTDELETE = 0;
            ll_row = idw_1.GetRow();
            //ld_paidToDate = idw_1.GetItemDateTime(ll_row, "paid_to_date").Date;
            ld_paidToDate = idw_1.GetItem<AllowanceBreakdown>(0).PaidToDate;
            if ((ld_paidToDate == null))
            {
                return 1;//return DODELETE;
            }
            MessageBox.Show("You cannot delete an allowance that has been paid.  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return -1;//return DONTDELETE;
        }

        public virtual void dw_1_pfc_deleterow()
        {
            //?if (ancestorreturnvalue == 1) {
            //    idw_1.of_Set_ModifyPriv(true);
            //    idw_1.postevent("getfocus");
            //}
            dw_1.SelectRow(0, false);
            dw_1.SelectRow(dw_1.GetRow() + 1, true);
            return;//return 1;
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
