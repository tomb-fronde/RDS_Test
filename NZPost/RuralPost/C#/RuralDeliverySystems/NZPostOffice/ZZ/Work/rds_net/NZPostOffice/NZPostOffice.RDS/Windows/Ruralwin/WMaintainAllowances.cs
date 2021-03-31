using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.DataService;
using System.Collections.Generic;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    // TJB Allowances 9-Mar-2021: New
    // Updated from WAddAllowance
    // Maintenance screen for allowance calculations

    public class WMaintainAllowances : WAncestorWindow
    {
        #region Define
        public int il_contract, il_contract_seq;
        public string isOptype = "";
        public int oldTabIndex = -1;

        public string is_errmsg = String.Empty;

        private System.ComponentModel.IContainer components = null;

        public URdsDw idw_Current;  // Used to represent the currently selected tabpage/DataControl

        public URdsDw dw_fixed_allowance;
        public URdsDw idw_fixed_allowance;

        public URdsDw dw_roi_allowance;
        public URdsDw idw_roi_allowance;

        public URdsDw dw_activity_allowance;
        public URdsDw idw_activity_allowance;

        public URdsDw dw_time_allowance;
        public URdsDw idw_time_allowance;

        public URdsDw dw_distance_allowance;
        public URdsDw idw_distance_allowance;

        public Button cb_save;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Button cb_delete;
        private TextBox Total;
        private Label Total_t;

        public Button cb_cancel;

        #endregion

        public WMaintainAllowances()
        {
            this.InitializeComponent();

            int nFixedCalcId = RDSDataService.LookupAllowanceCalcType("Fixed");
            int nRoiCalcId = RDSDataService.LookupAllowanceCalcType("Return ");
            int nActivityCalcId = RDSDataService.LookupAllowanceCalcType("Activity");
            int nTimeCalcId = RDSDataService.LookupAllowanceCalcType("Time");
            int nDistanceCalcId = RDSDataService.LookupAllowanceCalcType("Distance");

            this.dw_fixed_allowance.DataObject = new DMaintainFixedAllowance();
            dw_fixed_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_fixed_allowance.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_fixed_allowance_constructor);
            idw_fixed_allowance = dw_fixed_allowance;

            this.dw_roi_allowance.DataObject = new DMaintainROIAllowance();
            dw_roi_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_roi_allowance.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_roi_allowance_constructor);
            idw_roi_allowance = dw_roi_allowance;

            this.dw_activity_allowance.DataObject = new DMaintainActivityAllowance(nActivityCalcId);
            dw_activity_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_activity_allowance.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_activity_allowance_constructor);
            idw_activity_allowance = dw_activity_allowance;

            this.dw_time_allowance.DataObject = new DMaintainTimeAllowance();
            dw_time_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_time_allowance.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_time_allowance_constructor);
            idw_time_allowance = dw_time_allowance;

            this.dw_distance_allowance.DataObject = new DMaintainDistanceAllowance();
            dw_distance_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_distance_allowance.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_distance_allowance_constructor);
            idw_distance_allowance = dw_distance_allowance;

            this.Total.Visible = false;
            this.Total_t.Visible = false;
        }

        #region FormDesign
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dw_fixed_allowance = new NZPostOffice.RDS.Controls.URdsDw();
            this.dw_roi_allowance = new NZPostOffice.RDS.Controls.URdsDw();
            this.dw_activity_allowance = new NZPostOffice.RDS.Controls.URdsDw();
            this.dw_time_allowance = new NZPostOffice.RDS.Controls.URdsDw();
            this.dw_distance_allowance = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_save = new System.Windows.Forms.Button();
            this.cb_cancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cb_delete = new System.Windows.Forms.Button();
            this.Total = new System.Windows.Forms.TextBox();
            this.Total_t = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.st_label.Location = new System.Drawing.Point(2, 316);
            this.st_label.Size = new System.Drawing.Size(136, 18);
            this.st_label.Text = "WMaintainAllowances";
            // 
            // dw_fixed_allowance
            // 
            this.dw_fixed_allowance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_fixed_allowance.DataObject = null;
            this.dw_fixed_allowance.FireConstructor = false;
            this.dw_fixed_allowance.Location = new System.Drawing.Point(7, 6);
            this.dw_fixed_allowance.Name = "dw_fixed_allowance";
            this.dw_fixed_allowance.Size = new System.Drawing.Size(959, 264);
            this.dw_fixed_allowance.TabIndex = 1;
            // 
            // dw_roi_allowance
            // 
            this.dw_roi_allowance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_roi_allowance.DataObject = null;
            this.dw_roi_allowance.FireConstructor = false;
            this.dw_roi_allowance.Location = new System.Drawing.Point(6, 6);
            this.dw_roi_allowance.Name = "dw_roi_allowance";
            this.dw_roi_allowance.Size = new System.Drawing.Size(725, 292);
            this.dw_roi_allowance.TabIndex = 1;
            // 
            // dw_activity_allowance
            // 
            this.dw_activity_allowance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_activity_allowance.DataObject = null;
            this.dw_activity_allowance.FireConstructor = false;
            this.dw_activity_allowance.Location = new System.Drawing.Point(7, 6);
            this.dw_activity_allowance.Name = "dw_activity_allowance";
            this.dw_activity_allowance.Size = new System.Drawing.Size(724, 292);
            this.dw_activity_allowance.TabIndex = 1;
            // 
            // dw_time_allowance
            // 
            this.dw_time_allowance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_time_allowance.DataObject = null;
            this.dw_time_allowance.FireConstructor = false;
            this.dw_time_allowance.Location = new System.Drawing.Point(7, 6);
            this.dw_time_allowance.Name = "dw_time_allowance";
            this.dw_time_allowance.Size = new System.Drawing.Size(724, 292);
            this.dw_time_allowance.TabIndex = 1;
            // 
            // dw_distance_allowance
            // 
            this.dw_distance_allowance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_distance_allowance.DataObject = null;
            this.dw_distance_allowance.FireConstructor = false;
            this.dw_distance_allowance.Location = new System.Drawing.Point(7, 6);
            this.dw_distance_allowance.Name = "dw_distance_allowance";
            this.dw_distance_allowance.Size = new System.Drawing.Size(724, 292);
            this.dw_distance_allowance.TabIndex = 1;
            // 
            // cb_save
            // 
            this.cb_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_save.Location = new System.Drawing.Point(817, 311);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(75, 23);
            this.cb_save.TabIndex = 2;
            this.cb_save.Text = "Save";
            this.cb_save.Click += new System.EventHandler(this.cb_save_clicked);
            // 
            // cb_cancel
            // 
            this.cb_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_cancel.Location = new System.Drawing.Point(903, 311);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(75, 23);
            this.cb_cancel.TabIndex = 3;
            this.cb_cancel.Text = "Cancel";
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_clicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(977, 302);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dw_fixed_allowance);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(969, 276);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Fixed";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dw_roi_allowance);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(734, 304);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ROI";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dw_activity_allowance);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(734, 304);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Activity";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dw_time_allowance);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(734, 304);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Time";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dw_distance_allowance);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(734, 304);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Distance";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // cb_delete
            // 
            this.cb_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_delete.Location = new System.Drawing.Point(736, 311);
            this.cb_delete.Name = "cb_delete";
            this.cb_delete.Size = new System.Drawing.Size(75, 23);
            this.cb_delete.TabIndex = 5;
            this.cb_delete.Text = "Delete";
            this.cb_delete.UseVisualStyleBackColor = true;
            this.cb_delete.Click += new System.EventHandler(this.cb_delete_Click);
            // 
            // Total
            // 
            this.Total.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Total.BackColor = System.Drawing.SystemColors.Control;
            this.Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Total.Location = new System.Drawing.Point(439, 316);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(100, 20);
            this.Total.TabIndex = 6;
            // 
            // Total_t
            // 
            this.Total_t.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Total_t.AutoSize = true;
            this.Total_t.Location = new System.Drawing.Point(336, 321);
            this.Total_t.Name = "Total_t";
            this.Total_t.Size = new System.Drawing.Size(87, 13);
            this.Total_t.TabIndex = 0;
            this.Total_t.Text = "Total allowances";
            // 
            // WMaintainAllowances
            // 
            this.AcceptButton = this.cb_save;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(989, 342);
            this.Controls.Add(this.Total_t);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.cb_save);
            this.Controls.Add(this.cb_delete);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cb_cancel);
            this.Location = new System.Drawing.Point(46, 55);
            this.Name = "WMaintainAllowances";
            this.Text = "Maintain Contract Allowances";
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.cb_delete, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.Controls.SetChildIndex(this.cb_save, 0);
            this.Controls.SetChildIndex(this.Total, 0);
            this.Controls.SetChildIndex(this.Total_t, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
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
            base.pfc_preopen();
            this.of_bypass_security(true);
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            string ls_title;
            DateTime? tmpDate;
            DateTime dtEffDate;
            NRdsMsg lnv_msg;
            NCriteria lvn_Criteria;

            this.of_set_componentname("Allowance");
            lnv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            lvn_Criteria = lnv_msg.of_getcriteria();
            il_contract = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("contract_no"));
            il_contract_seq = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("con_active_seq"));
            ls_title = lvn_Criteria.of_getcriteria("contract_title") as string;
            isOptype = lvn_Criteria.of_getcriteria("optype") as string;

            // Get the Effective Date for this contract.
            // We only list those allowances whose effective date falls in the Contract's current period
            tmpDate = RDSDataService.GetConRatesEffDate((int?)il_contract, (int?)il_contract_seq);
            dtEffDate = (DateTime)tmpDate;

            // TJB 
            // The following relationship between alct_id and datawindows is hard-coded
            // (yes, I konw its very bad practice ;(
            idw_fixed_allowance.DataObject.Reset();
            ((DMaintainFixedAllowance)idw_fixed_allowance.DataObject).Retrieve(il_contract, dtEffDate, 1);
            idw_roi_allowance.DataObject.Reset();
            ((DMaintainROIAllowance)idw_roi_allowance.DataObject).Retrieve(il_contract, dtEffDate, 2);
            idw_activity_allowance.DataObject.Reset();
            ((DMaintainActivityAllowance)idw_activity_allowance.DataObject).Retrieve(il_contract, dtEffDate, 3);
            idw_time_allowance.DataObject.Reset();
            ((DMaintainTimeAllowance)idw_time_allowance.DataObject).Retrieve(il_contract, dtEffDate, 4);
            idw_distance_allowance.DataObject.Reset();
            ((DMaintainDistanceAllowance)idw_distance_allowance.DataObject).Retrieve(il_contract, dtEffDate, 5);
//
            // If this is an insert ...
            int newRow = -1;
            if (isOptype == "Insert")
            {
                // Insert a new record at the beginning of the list for each tab
                //idw_allowance.DataObject.AddItem<AddAllowance>(new AddAllowance());
                newRow = 0;
                ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).InsertItem<MaintainAllowance>(newRow, new MaintainAllowance());
                // NOTE: 'newRow' is the row number of the added row.  If the row is added 
                // elsewhere (eg at the end of the list), newRow must be changed.
                // Set default values on the new row
                idw_fixed_allowance.GetItem<MaintainAllowance>(newRow).ContractTitle = ls_title;
                idw_fixed_allowance.GetItem<MaintainAllowance>(newRow).ContractNo = il_contract;
                idw_fixed_allowance.GetItem<MaintainAllowance>(newRow).EffectiveDate = dtEffDate;
            }
            idw_Current = idw_fixed_allowance;

            // Check whether the user has permission to approve allowances, and
            // set the ca_approved column readonly if not.
            set_approvability();

            idw_fixed_allowance.DataObject.BindingSource.CurrencyManager.Refresh();
            idw_roi_allowance.DataObject.BindingSource.CurrencyManager.Refresh();
            idw_activity_allowance.DataObject.BindingSource.CurrencyManager.Refresh();
            idw_time_allowance.DataObject.BindingSource.CurrencyManager.Refresh();
            idw_distance_allowance.DataObject.BindingSource.CurrencyManager.Refresh();

            of_calc_allowance_total();

            of_set_row_readonly();
        }

        private void of_set_row_readonly()
        {
            for (int nRow = 0; nRow < idw_fixed_allowance.RowCount; nRow++)
            {
                if ((idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).PaidToDate) == null)
                {
                    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridRowReadOnly(nRow, false);
                    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Window;  // white
                }
                else
                {
                    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridRowReadOnly(nRow, true);
                    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
            }
            idw_fixed_allowance.DataObject.Refresh();
            for (int nRow = 0; nRow < idw_roi_allowance.RowCount; nRow++)
            {
                if ((idw_roi_allowance.GetItem<MaintainAllowance>(nRow).PaidToDate) == null)
                {
                    ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).SetGridRowReadOnly(nRow, false);
                    ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Window;  // white
                }
                else
                {
                    ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).SetGridRowReadOnly(nRow, true);
                    ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
            }
            idw_roi_allowance.DataObject.Refresh();
            for (int nRow = 0; nRow < idw_activity_allowance.RowCount; nRow++)
            {
                if ((idw_activity_allowance.GetItem<MaintainAllowance>(nRow).PaidToDate) == null)
                {
                    ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).SetGridRowReadOnly(nRow, false);
                    ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Window;  // white
                }
                else
                {
                    ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).SetGridRowReadOnly(nRow, true);
                    ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
            }
            idw_activity_allowance.DataObject.Refresh();
            for (int nRow = 0; nRow < idw_time_allowance.RowCount; nRow++)
            {
                if ((idw_time_allowance.GetItem<MaintainAllowance>(nRow).PaidToDate) == null)
                {
                    ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).SetGridRowReadOnly(nRow, false);
                    ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Window;  // white
                }
                else
                {
                    ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).SetGridRowReadOnly(nRow, true);
                    ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
            }
            idw_time_allowance.DataObject.Refresh();
            for (int nRow = 0; nRow < idw_distance_allowance.RowCount; nRow++)
            {
                if ((idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow).PaidToDate) == null)
                {
                    ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).SetGridRowReadOnly(nRow, false);
                    ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Window;  // white
                }
                else
                {
                    ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).SetGridRowReadOnly(nRow, true);
                    ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
            }
            idw_distance_allowance.DataObject.Refresh();
        }

        public override void close()
        {
            //?base.close();
            //  Tell the parent to refresh
            int ll_sheetcount;
            int ll_rc;
            Dictionary<int, WContract2001> lw_opensheets = new Dictionary<int, WContract2001>();
            FormBase lw_frame;
            lw_frame = StaticVariables.gnv_app.of_getframe();
            //?if ((lw_frame.inv_sheetmanager != null) == false) {
            //    lw_frame.inv_sheetmanager = new NCstWinsrvSheetmanager();
            //}
            //?ll_sheetcount = lw_frame.inv_sheetmanager.of_getsheetsbyclass(lw_opensheets, "w_contract2001");
            //if (ll_sheetcount < 2 && ll_sheetcount > 0) {
            //    ll_rc = lw_opensheets[1].idw_fixed_allowances.Reset();
            //    ll_rc = lw_opensheets[1].idw_fixed_allowances.Retrieve(new object[]{il_contract});
            //    ll_rc = lw_opensheets[1].idw_fixed_allowances.SelectRow(0, false);
            //    ll_rc = lw_opensheets[1].idw_fixed_allowances.SelectRow(il_caRow, true);
            //}
            //? this.Close();//close(this);
            ((WContract2001)StaticVariables.window).idw_allowances.Reset();
            ((WContract2001)StaticVariables.window).idw_allowances.Retrieve(new object[] { il_contract });
            StaticVariables.window = null;
        }

        public virtual int wf_validate(string sAllowanceType)
        {
            // Validate data in each tab where there have been modifications. 
            // Tell the user, then skip to the next tab.  
            // If there are no failures, return SUCCESS (1).
            // If there are some failures and no successes, return FAILURE (-1)
            // If there are some failures and some successes, return FAILURE2 (-2)

            DateTime? ld_effdate;
            DateTime? ld_maxdate;
            Decimal?  ldc_amount;
            int? ll_altkey;
            string sAltDescription;
            int nSucceeded;
            int nAllErrors;
            int nRowErrors, nTabErrors;
            int FAILURE2 = -(2);
            int nRow, nRows;
            
            ll_altkey = null;
            sAltDescription = "";
            nSucceeded = 0;
            nAllErrors = 0;
            is_errmsg = "";

            // Validate each allowance type separately
            // Fixed Allowances
            if (sAllowanceType == "Fixed")
            {
                nTabErrors = 0;
                nRows = idw_fixed_allowance.RowCount;
                for (nRow = 0; nRow < nRows; nRow++)
                {
                    // Check to see if this row has been changed
                    // If not, no need to validate it
                    string sRowChanged = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).RowChanged;
                    if (sRowChanged == "N") continue;

                    nRowErrors = 0;
                    ld_effdate = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).EffectiveDate;
                    ldc_amount = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).AnnualAmount;
                    ll_altkey = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).AltKey;
                    sAltDescription = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).AltDescription;

                    // Check that some essential values have been entered
                    if( ldc_amount == null )
                    {
                        is_errmsg += sAltDescription + " - Please enter an amount.\n";
                        nRowErrors++;
                    }
                    if ((ld_effdate == null))
                    {
                        is_errmsg += sAltDescription + " - Please enter an effective date.\n";
                        nRowErrors++;
                    }
                    else
                    {   // True means the date is either OK or acceptable
                        if (!(StaticVariables.gnv_app.of_sanedate(ld_effdate.GetValueOrDefault(), "effective date")))
                            nRowErrors++;
                    }
                    if( nRowErrors <= 0 )
                    {
                        ld_maxdate = new DateTime();
                        int SQLCode = 0;
                        string SQLErrText = string.Empty;
                        ld_maxdate = RDSDataService.GetContractAllownceMaxCaEffective(il_contract, ll_altkey, ref SQLCode, ref SQLErrText);

                        if (SQLCode != 0 && SQLCode != 100)
                        {
                            is_errmsg += sAltDescription + " DB Error: Failed looking up max(ca_effective_date).\n"
                                         + "Error Code: " + SQLCode.ToString() + "\n" 
                                         + "Error Text: " + SQLErrText;
                            nRowErrors++;
                        }
                        // TJB 18-Mar-2021 Added: Don't check the effective date if updating
                        if (isOptype == "Insert" && ld_effdate <= ld_maxdate)
                        {
                            is_errmsg += sAltDescription + " - The effective date must be greater than " + ld_maxdate.GetValueOrDefault().ToString("dd/MM/yyyy") + ".\n";
                            nRowErrors++;
                        }
                    }
                    if( nRowErrors > 0 )
                    {
                        nTabErrors += nRowErrors;
/*
                        string sError = "error";
                        if( nRowErrors > 1 ) sError += "s";
                        MessageBox.Show(is_errmsg
                                       , sAltDescription + " allowance " + sError
                                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        nRowErrors = 0;
*/
                    }
                } // end for each fixed row loop
                if( nTabErrors > 0 )
                    nAllErrors += nTabErrors;
                else
                    nSucceeded++;
            } // end fixed allowances validation

            // ROI Allowances
            if (sAllowanceType == "ROI")
            {
                nTabErrors = 0;

                if( nTabErrors > 0 )
                    nAllErrors += nTabErrors;
                else
                    nSucceeded++;
            }

            // Activity Allowances
            if (sAllowanceType == "Activity")
            {
                nTabErrors = 0;

                if( nTabErrors > 0 )
                    nAllErrors += nTabErrors;
                else
                    nSucceeded++;
            }

            // Time Allowances
            if (sAllowanceType == "Time")
            {
                nTabErrors = 0;

                if( nTabErrors > 0 )
                    nAllErrors += nTabErrors;
                else
                    nSucceeded++;
            }

            // Distance Allowances
            if (sAllowanceType == "Distance")
            {
                nTabErrors = 0;

                if( nTabErrors > 0 )
                    nAllErrors += nTabErrors;
                else
                    nSucceeded++;
            }
            if( nAllErrors == 0 )
                return SUCCESS;  // Return SUCCESS if there were no errore
            else
            {
                if( nSucceeded > 0 )
                    return FAILURE2; // Return FAILURE2 if there was partial success

                return FAILURE;      // Otherwise return FAILURE
            }
        }

        public virtual void dw_fixed_allowance_constructor()
        {
            idw_fixed_allowance = dw_fixed_allowance;
        }

        public virtual void dw_roi_allowance_constructor()
        {
            idw_roi_allowance = dw_roi_allowance;
        }

        public virtual void dw_activity_allowance_constructor()
        {
            idw_activity_allowance = dw_activity_allowance;
        }

        public virtual void dw_time_allowance_constructor()
        {
            idw_time_allowance = dw_time_allowance;
        }

        public virtual void dw_distance_allowance_constructor()
        {
            idw_distance_allowance = dw_distance_allowance;
        }

        private void set_approvability()
        {
            // Check to see if this user is allowed to approve allowances
            // If not, set the 'Approved' column read-only
            string grouplist = "Payroll, System Administrators";
            bool ismemberofgroup = StaticVariables.gnv_app.inv_Security_Manager.inv_User.of_ismemberof_list(grouplist);
            if (ismemberofgroup)
            {
                ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", false);
                ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Window;  // White
                ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", false);
                ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Window;  // White
                ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", false);
                ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Window;  // White
                ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", false);
                ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Window;  // White
                ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", false);
                ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Window;  // White
            }
            else
            {
                ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", true);
                ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).BackColor  = System.Drawing.SystemColors.ButtonFace;  // Grey
                ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", true);
                ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).BackColor = System.Drawing.SystemColors.ButtonFace;  // Grey
                ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", true);
                ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).BackColor = System.Drawing.SystemColors.ButtonFace;  // Grey
                ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", true);
                ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).BackColor = System.Drawing.SystemColors.ButtonFace;  // Grey
                ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", true);
                ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).BackColor = System.Drawing.SystemColors.ButtonFace;  // Grey
            }
        }
        #region Events

        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            cb_save.Focus();
            int ll_error;
            is_errmsg = "";
            int nChanged, nDleted;

            idw_fixed_allowance.DataObject.AcceptText();
            idw_roi_allowance.DataObject.AcceptText();
            idw_activity_allowance.DataObject.AcceptText();
            idw_time_allowance.DataObject.AcceptText();
            idw_distance_allowance.DataObject.AcceptText();

            of_calc_allowance_total();

            // Check each tab for changes
            // Fixed Allowances
            nChanged = idw_fixed_allowance.ModifiedCount();
            nDleted  = (idw_fixed_allowance.DataObject).DeletedCount;
            if (nChanged > 0 || nDleted > 0)
            {
                ll_error = wf_validate("Fixed");

                if (ll_error == FAILURE)
                {
                    MessageBox.Show(is_errmsg, "Fixed Allowance Validation Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    idw_fixed_allowance.Save();
                    if (idw_fixed_allowance.GetItem<MaintainAllowance>(0).SQLCode != 0)
                    {
                        MessageBox.Show("Failed to update Fixed Allowance. \n\n"
                                       + "Error Code: " + idw_fixed_allowance.GetItem<MaintainAllowance>(0).SQLCode.ToString() + "\n\n"
                                       + "Error Text: " + idw_fixed_allowance.GetItem<MaintainAllowance>(0).SQLErrText
                                       , "Database Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

            // ROI Allowances
            nChanged = idw_roi_allowance.ModifiedCount();
            nDleted = (idw_roi_allowance.DataObject).DeletedCount;
            if (nChanged > 0 || nDleted > 0)
            {
                ll_error = wf_validate("ROI");

                if (ll_error == FAILURE)
                {
                    MessageBox.Show(is_errmsg, "ROI Allowance Validation Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    idw_roi_allowance.Save();
                    if (idw_roi_allowance.GetItem<MaintainAllowance>(0).SQLCode != 0)
                    {
                        MessageBox.Show("Failed to update ROI Allowance.  \n\n"
                                       + "Error Code: " + idw_roi_allowance.GetItem<MaintainAllowance>(0).SQLCode.ToString() + "\n\n"
                                       + "Error Text: " + idw_roi_allowance.GetItem<MaintainAllowance>(0).SQLErrText
                                       , "Database Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

            // Activity Allowances
            nChanged = idw_activity_allowance.ModifiedCount();
            nDleted = (idw_activity_allowance.DataObject).DeletedCount;
            if (nChanged > 0 || nDleted > 0)
            {
                ll_error = wf_validate("Activity");

                if (ll_error == FAILURE)
                {
                    MessageBox.Show(is_errmsg, "Activity Allowance Validation Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    idw_activity_allowance.Save();
                    if (idw_activity_allowance.GetItem<MaintainAllowance>(0).SQLCode != 0)
                    {
                        MessageBox.Show("Failked to update Activity Allowance.  \n\n"
                                       + "Error Code: " + idw_activity_allowance.GetItem<MaintainAllowance>(0).SQLCode.ToString() + "\n\n"
                                       + "Error Text: " + idw_activity_allowance.GetItem<MaintainAllowance>(0).SQLErrText
                                       , "Database Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

            // Time Allowances
            nChanged = idw_time_allowance.ModifiedCount();
            nDleted = (idw_time_allowance.DataObject).DeletedCount;
            if (nChanged > 0 || nDleted > 0)
            {
                ll_error = wf_validate("Time");

                if (ll_error == FAILURE)
                {
                    MessageBox.Show(is_errmsg, "Time Allowance Validation Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    idw_time_allowance.Save();
                    if (idw_time_allowance.GetItem<MaintainAllowance>(0).SQLCode != 0)
                    {
                        MessageBox.Show("Failed to update Time Allowance.  \n\n"
                                       + "Error Code: " + idw_time_allowance.GetItem<MaintainAllowance>(0).SQLCode.ToString() + "\n\n"
                                       + "Error Text: " + idw_time_allowance.GetItem<MaintainAllowance>(0).SQLErrText
                                       , "Database Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

            // Distance Allowances
            nChanged = idw_distance_allowance.ModifiedCount();
            nDleted = (idw_distance_allowance.DataObject).DeletedCount;
            if (nChanged > 0 || nDleted > 0)
            {
                ll_error = wf_validate("Distance");

                if (ll_error == FAILURE)
                {
                    MessageBox.Show(is_errmsg, "Distance Allowance Validation Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    idw_distance_allowance.Save();
                    if (idw_distance_allowance.GetItem<MaintainAllowance>(0).SQLCode != 0)
                    {
                        MessageBox.Show("Failed to update Distance Allowance.  \n\n"
                                       + "Error Code: " + idw_distance_allowance.GetItem<MaintainAllowance>(0).SQLCode.ToString() + "\n\n"
                                       + "Error Text: " + idw_distance_allowance.GetItem<MaintainAllowance>(0).SQLErrText
                                       , "Database Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

//            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            idw_fixed_allowance.DataObject.Reset();
            idw_roi_allowance.DataObject.Reset();
            idw_activity_allowance.DataObject.Reset();
            idw_time_allowance.DataObject.Reset();
            idw_distance_allowance.DataObject.Reset();
            this.Close();
        }

        private void cb_delete_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("cb_delete clicked");
            // idw_current
            int nRow = 0;
            string sDwName = idw_Current.Name;
            nRow = idw_Current.DataObject.GetRow();
            
            bool isReadonly = false;
            if (sDwName == "dw_fixed_allowance")
                isReadonly = ((DMaintainFixedAllowance)(idw_Current.DataObject)).GetGridRowReadOnly(nRow);
            else if (sDwName == "dw_roi_allowance")
                isReadonly = ((DMaintainROIAllowance)(idw_Current.DataObject)).GetGridRowReadOnly(nRow);
            else if (sDwName == "dw_activity_allowance")
                isReadonly = ((DMaintainActivityAllowance)(idw_Current.DataObject)).GetGridRowReadOnly(nRow);
            else if (sDwName == "dw_time_allowance")
                isReadonly = ((DMaintainTimeAllowance)(idw_Current.DataObject)).GetGridRowReadOnly(nRow);
            else if (sDwName == "dw_distance_allowance")
                isReadonly = ((DMaintainDistanceAllowance)(idw_Current.DataObject)).GetGridRowReadOnly(nRow);


            if (isReadonly)
            {
                MessageBox.Show("You do not have premission to delete this allowance");
            }
            else{
                DialogResult ans;
                ans = MessageBox.Show("Please confirm that you want to this allowance."
                                     , ""
                                     , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    //if ((nRow == newRow))
                    //{
                    //    newRow = -1;
                    //    idw_Current.GetItem<AddAllowance>(nRow).AltKey = null;
                    //}
                    idw_Current.DataObject.DeleteItemAt(nRow);
                    //idw_allowance.DataObject.BindingSource.CurrencyManager.Refresh();
                    // TJB Release 7.1.3 testing  Aug-2010: added
                    //     Found to be needed - read-only status lost when a row deleted.
                    //set_approvability();
                    of_calc_allowance_total();
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ToTabName is the name of the tab we've changed TO.
            // FromTabName is the name of the tab we've changed FROM.
            string FromTabName = "I don't know";
            string ToTabName = "I do not know";

            int thisTabIndex = tabControl1.SelectedIndex;
            if (oldTabIndex >= 0)
                FromTabName = tabControl1.TabPages[oldTabIndex].Text.ToLower().Trim();
            if (tabControl1.SelectedIndex >= 0)
                ToTabName   = tabControl1.TabPages[thisTabIndex].Text.ToLower().Trim();

            if (FromTabName == ToTabName)
            {
                return;
            }
            oldTabIndex = thisTabIndex;

            if (ToTabName == "fixed")
            {
                idw_Current = idw_fixed_allowance;
                of_set_row_readonly();
            }
            if (ToTabName == "rOI")
            {
                idw_Current = idw_roi_allowance;
                of_set_row_readonly();
            }
            if (ToTabName == "activity")
            {
                idw_Current = idw_activity_allowance;
                of_set_row_readonly();
            }
            if (ToTabName == "time")
            {
                idw_Current = idw_time_allowance;
                of_set_row_readonly();
            }
            if (ToTabName == "distance")
            {
                idw_Current = idw_distance_allowance;
                of_set_row_readonly();
            }
        }
        #endregion

        private void of_calc_allowance(URdsDw tab_dw, out decimal tab_total )
        {
            int nRow, nRows;
            decimal dTotalAmt = 0.0M;
            decimal? dThisAmt = 0.0M;

            // Re-calculate the total of the AnnualPayments
            dTotalAmt = 0.0M;
            nRows = tab_dw.RowCount;
            for (nRow = 0; nRow < nRows; nRow++)
            {
                dThisAmt = tab_dw.GetItem<MaintainAllowance>(nRow).AnnualAmount;
                if (dThisAmt != null)
                    dTotalAmt += (decimal)dThisAmt;
            }

            // Return the total
            tab_total = dTotalAmt;
        }

        private void of_calc_distance_allowance(out decimal tab_total)
        {
            int nRow, nRows;
            decimal dTotalAmt = 0.0M;
            decimal? dThisAmt = 0.0M;

            // Re-calculate the total of the AnnualPayments
            dTotalAmt = 0.0M;
            nRows = idw_distance_allowance.RowCount;
            for (nRow = 0; nRow < nRows; nRow++)
            {
                dThisAmt = idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow).AnnualAmount;
                if (dThisAmt != null)
                    dTotalAmt += (decimal)dThisAmt;
            }

            // Return the total
            tab_total = dTotalAmt;
        }

        private void of_calc_allowance_total()
        {
            decimal dTotalAmt = 0.0M;
            decimal dThisAmt  = 0.0M;

            of_calc_allowance(idw_fixed_allowance, out dThisAmt);
            dTotalAmt += dThisAmt;
            of_calc_allowance(idw_roi_allowance, out dThisAmt);
            dTotalAmt += dThisAmt;
            of_calc_allowance(idw_activity_allowance, out dThisAmt);
            dTotalAmt += dThisAmt;
            of_calc_allowance(idw_time_allowance, out dThisAmt);
            dTotalAmt += dThisAmt;
            of_calc_distance_allowance(out dThisAmt);
            dTotalAmt += dThisAmt;

            // Display the total
            this.Total.Text = dTotalAmt.ToString("###,###.00");
        }
    }
}
