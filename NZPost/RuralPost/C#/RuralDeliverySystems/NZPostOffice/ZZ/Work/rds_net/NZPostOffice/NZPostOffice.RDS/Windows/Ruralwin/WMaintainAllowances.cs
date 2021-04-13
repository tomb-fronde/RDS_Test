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
        public int? il_altKey, il_alctId;
        public string isOptype = "";
        public int oldTabIndex = -1;
        private DateTime dtEffDate;

        // Define values for the different calculation types
        public readonly int FIXED = RDSDataService.LookupAllowanceCalcType("Fixed");
        public readonly int ROI = RDSDataService.LookupAllowanceCalcType("Return ");
        public readonly int ACTIVITY = RDSDataService.LookupAllowanceCalcType("Activity");
        public readonly int TIME = RDSDataService.LookupAllowanceCalcType("Time");
        public readonly int DISTANCE = RDSDataService.LookupAllowanceCalcType("Distance");

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

            this.dw_fixed_allowance.DataObject = new DMaintainFixedAllowance();
            dw_fixed_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_fixed_allowance.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_fixed_allowance_constructor);
            //dw_fixed_allowance.EditChanged += new EventHandler(dw_fixed_allowance_EditChanged);
            dw_fixed_allowance.ItemChanged += new EventHandler(dw_fixed_allowance_ItemChanged);
            idw_fixed_allowance = dw_fixed_allowance;

            this.dw_roi_allowance.DataObject = new DMaintainROIAllowance();
            dw_roi_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_roi_allowance.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_roi_allowance_constructor);
            dw_roi_allowance.ItemChanged += new EventHandler(dw_roi_allowance_ItemChanged);
            idw_roi_allowance = dw_roi_allowance;

            this.dw_activity_allowance.DataObject = new DMaintainActivityAllowance();
            dw_activity_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_activity_allowance.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_activity_allowance_constructor);
            dw_activity_allowance.ItemChanged += new EventHandler(dw_activity_allowance_ItemChanged);
            idw_activity_allowance = dw_activity_allowance;

            this.dw_time_allowance.DataObject = new DMaintainTimeAllowance();
            dw_time_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_time_allowance.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_time_allowance_constructor);
            dw_time_allowance.ItemChanged += new EventHandler(dw_time_allowance_ItemChanged);
            idw_time_allowance = dw_time_allowance;

            this.dw_distance_allowance.DataObject = new DMaintainDistanceAllowance();
            dw_distance_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_distance_allowance.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_distance_allowance_constructor);
            dw_distance_allowance.ItemChanged += new EventHandler(dw_distance_allowance_ItemChanged);
            idw_distance_allowance = dw_distance_allowance;
            dw_distance_allowance.DoubleClick += new EventHandler(dw_distance_allowance_DoubleClick);

            //this.Total.Visible = false;
            //this.Total_t.Visible = false;
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
            this.dw_roi_allowance.Size = new System.Drawing.Size(960, 264);
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
            this.dw_activity_allowance.Size = new System.Drawing.Size(959, 264);
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
            this.dw_time_allowance.Size = new System.Drawing.Size(959, 264);
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
            this.dw_distance_allowance.Size = new System.Drawing.Size(959, 264);
            this.dw_distance_allowance.TabIndex = 1;
            // 
            // cb_save
            // 
            this.cb_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_save.Location = new System.Drawing.Point(589, 311);
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
            this.cb_cancel.Location = new System.Drawing.Point(675, 311);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(81, 23);
            this.cb_cancel.TabIndex = 3;
            this.cb_cancel.Text = "Close/Cancel";
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
            this.tabPage2.Size = new System.Drawing.Size(969, 276);
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
            this.tabPage3.Size = new System.Drawing.Size(969, 276);
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
            this.tabPage4.Size = new System.Drawing.Size(969, 276);
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
            this.tabPage5.Size = new System.Drawing.Size(969, 276);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Distance";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // cb_delete
            // 
            this.cb_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_delete.Location = new System.Drawing.Point(508, 311);
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
            this.Total.Location = new System.Drawing.Point(298, 316);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(100, 20);
            this.Total.TabIndex = 6;
            // 
            // Total_t
            // 
            this.Total_t.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Total_t.AutoSize = true;
            this.Total_t.Location = new System.Drawing.Point(195, 321);
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
        public override void pfc_cancel()
        {
            base.pfc_cancel();
        }
        public override void pfc_postopen()
        {
            base.pfc_postopen();
            string ls_title;
            DateTime? tmpDate;
            NRdsMsg lnv_msg;
            NCriteria lvn_Criteria;

            this.of_set_componentname("Allowance");

            lnv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            lvn_Criteria = lnv_msg.of_getcriteria();
            il_contract = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("contract_no"));
            il_contract_seq = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("con_active_seq"));
            il_altKey = (int?)System.Convert.ToInt32(lvn_Criteria.of_getcriteria("alt_key"));
            il_alctId = (int?)System.Convert.ToInt32(lvn_Criteria.of_getcriteria("alct_id"));
            ls_title = lvn_Criteria.of_getcriteria("contract_title") as string;
            isOptype = lvn_Criteria.of_getcriteria("optype") as string;
            this.Text += " - " + ls_title;

            // Get the Effective Date for this contract.
            // We only list those allowances whose effective date falls in the Contract's current period
            tmpDate = RDSDataService.GetConRatesEffDate((int?)il_contract, (int?)il_contract_seq);
            dtEffDate = (DateTime)tmpDate;

            // TJB 
            // The following relationship between alct_id and datawindows is hard-coded
            // See table allowance_calc_type (yes, I konw its very bad practice ;(
            dw_fixed_allowance.DataObject.Reset();
            ((DMaintainFixedAllowance)dw_fixed_allowance.DataObject).Retrieve(il_contract, dtEffDate, FIXED);
            dw_roi_allowance.DataObject.Reset();
            ((DMaintainROIAllowance)dw_roi_allowance.DataObject).Retrieve(il_contract, dtEffDate, ROI);
            dw_activity_allowance.DataObject.Reset();
            ((DMaintainActivityAllowance)dw_activity_allowance.DataObject).Retrieve(il_contract, dtEffDate, ACTIVITY);
            dw_time_allowance.DataObject.Reset();
            ((DMaintainTimeAllowance)dw_time_allowance.DataObject).Retrieve(il_contract, dtEffDate, TIME);
            dw_distance_allowance.DataObject.Reset();
            ((DMaintainDistanceAllowance)dw_distance_allowance.DataObject).Retrieve(il_contract, dtEffDate, DISTANCE);

            // Check whether the user has permission to approve allowances, and
            // set the ca_approved column readonly if not.
            set_approvability();

            // Calculate the allowance totals for each tab
            of_calc_tab_allowances(dw_fixed_allowance, FIXED);
            of_calc_tab_allowances(dw_roi_allowance, ROI);
            of_calc_tab_allowances(dw_activity_allowance, ACTIVITY);
            of_calc_tab_allowances(dw_time_allowance, TIME);
            of_calc_tab_allowances(dw_distance_allowance, DISTANCE);

            // Calculate the total of all allowances and display it
            decimal dTotalAmt;
            of_calc_allowance_total(out dTotalAmt);
            this.Total.Text = dTotalAmt.ToString("###,###.00");

            // Updating the allowance totals has marked all allowances "dirty"
            // Mark them "Clean" to avoid being asked about saving changes
            of_markAllClean(dw_fixed_allowance, FIXED);
            of_markAllClean(dw_roi_allowance, ROI);
            of_markAllClean(dw_activity_allowance, ACTIVITY);
            of_markAllClean(dw_time_allowance, TIME);
            of_markAllClean(dw_distance_allowance, DISTANCE);

            // Mark any new records dirty
            // Note: of_calc_tab_allowances marks all rows clean when it updates their totals
            //       which would undo of_markNewDirty's work
            of_markNewDirty(dw_fixed_allowance, FIXED);
            of_markNewDirty(dw_roi_allowance, ROI);
            of_markNewDirty(dw_activity_allowance, ACTIVITY);
            of_markNewDirty(dw_time_allowance, TIME);
            of_markNewDirty(dw_distance_allowance, DISTANCE);

            this.Refresh();

            // If no allowance has been specified (via an insert), look up the first
            // allowance tab that has something to display as the starting tab
            // and set il_alctId to the related calc type index (one more than the tabindex).
            if (il_alctId == null || (int)il_alctId < 1)
            {
                il_alctId = of_getPopulatedAllowance();
                tabControl1.SelectedIndex = (int)il_alctId;
                il_alctId++;
            }
            else
                tabControl1.SelectedIndex = ((int)il_alctId - 1);

            // Set idw_current to the appropriate Datacontrol
            if (il_alctId == null || il_alctId <= 1)
                idw_Current = dw_fixed_allowance;
            else if (il_alctId == 2)
                idw_Current = dw_roi_allowance;
            else if (il_alctId == 3)
                idw_Current = dw_activity_allowance;
            else if (il_alctId == 4)
                idw_Current = dw_time_allowance;
            else if (il_alctId == 5)
                idw_Current = dw_distance_allowance;

            // of_set_row_readonly();
        }

        private void of_markAllClean(URdsDw thisDw, int dwType)
        {
            for (int nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                if (dwType == DISTANCE)
                    thisDw.GetItem<MaintainVehAllowance>(nRow).MarkClean();
                else
                    thisDw.GetItem<MaintainAllowance>(nRow).MarkClean();
            }
        }

        private void of_markNewDirty(URdsDw thisDw, int dwType)
        {
            for (int nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                if (dwType == DISTANCE
                    && thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged == "N")
                {
                    thisDw.GetItem<MaintainVehAllowance>(nRow).MarkDirtyEntity();
                }
                else
                    if (dwType != DISTANCE
                        && thisDw.GetItem<MaintainAllowance>(nRow).RowChanged == "N")
                    {
                        thisDw.GetItem<MaintainAllowance>(nRow).MarkDirtyEntity();
                    }
            }
        }

        private int of_getPopulatedAllowance()
        {
            // Check each tab's data to see which have allowances to show
            // Return the tab index of the first that has something.
            if (idw_fixed_allowance.RowCount > 0)
                return 0;
            if (idw_roi_allowance.RowCount > 0)
                return 1;
            if (idw_activity_allowance.RowCount > 0)
                return 2;
            if (idw_time_allowance.RowCount > 0)
                return 3;
            if (idw_distance_allowance.RowCount > 0)
                return 4;
            return 0;
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

            //int ll_sheetcount;
            //int ll_rc;
            //Dictionary<int, WContract2001> lw_opensheets = new Dictionary<int, WContract2001>();
            //FormBase lw_frame;
            //lw_frame = StaticVariables.gnv_app.of_getframe();
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

            //  Tell the parent to refresh
            ((WContract2001)StaticVariables.window).idw_allowances.Reset();
            ((WContract2001)StaticVariables.window).idw_allowances.Retrieve(new object[] { il_contract });
            StaticVariables.window = null;
        }

        private void wf_checkBasicErrors(int? inContract, int? inAltKey, DateTime? inEffDate, decimal? inAmount, string inNotes
                                       , string inAltDescription, string inRowChanged, ref int inErrors, ref string inErrmsg)
        {
            int SQLCode = 0;
            int nRowErrors = 0;
            string sRowError = string.Empty;
            string SQLErrText = string.Empty;
            DateTime? ld_maxdate = new DateTime();

            // Check that some essential values have been entered
            if (inAmount == null)
            {
                sRowError += inAltDescription + " - Please enter an amount.\n";
                nRowErrors++;
            }
            if (inEffDate == null)
            {
                sRowError += inAltDescription + " - Please enter an effective date.\n";
                nRowErrors++;
            }
/*
            else if (inEffDate != null)
            {
                // Check that we won't duplicate the effective date 
                // (leading to a database duplicate key error)
                DateTime dEffDate = (DateTime)inEffDate;
                DateTime dMaxDate = (DateTime)RDSDataService.GetAllowanceMaxEffectiveDate(inContract, inAltKey, dtEffDate);
                if( dEffDate <= dMaxDate )
                {
                    sRowError += inAltDescription + " - The effective date must be greater than " 
                                 + dMaxDate.ToString("dd/MM/yyyy")+ ".\n";
                    nRowErrors++;
                }
            }
*/
            else
            {   // True means the date is either OK or acceptable
                if (!(StaticVariables.gnv_app.of_sanedate(inEffDate.GetValueOrDefault(), "effective date")))
                    nRowErrors++;
                else
                {
/*
                    ld_maxdate = RDSDataService.GetContractAllownceMaxCaEffective(inContract, inAltKey
                                                                         , ref SQLCode, ref SQLErrText);

                    if (SQLCode != 0 && SQLCode != 100)
                    {
                        sRowError += inAltDescription + " DB Error: Failed looking up max(ca_effective_date).\n"
                                     + "Error Code: " + SQLCode.ToString() + "\n"
                                     + "Error Text: " + SQLErrText;
                        nRowErrors++;
                    }
*/
                    DateTime dEffDate = (DateTime)inEffDate;
                    DateTime dMaxDate = (DateTime)RDSDataService.GetAllowanceMaxEffectiveDate(inContract, inAltKey, dtEffDate);

                    // Don't need to check the effective date if updating
                    if (inRowChanged == "M" && (dEffDate <= dMaxDate))
                    {
                        sRowError += inAltDescription + " - The effective date must be greater than "
                                     + dMaxDate.ToString("dd/MM/yyyy") + ".\n";
                        nRowErrors++;
                    }
                }
            }
            if (inNotes == null || inNotes.Trim() == "")
            {
                sRowError += inAltDescription + " - Please enter a note.\n";
                nRowErrors++;
            }

            inErrors += nRowErrors;
            inErrmsg += sRowError;
        }

        public virtual int wf_validate(string sAllowanceType)
        {
            // Validate data in each tab where there have been modifications. 
            // Tell the user, then skip to the next tab.  
            // If there are no failures, return SUCCESS (1).
            // If there are some failures and no successes, return FAILURE (-1)

            DateTime? ld_effdate;
            DateTime? ld_maxdate;
            Decimal?  ldc_amount;
            int? ll_altkey;
            string sAltDescription;
            string sCaNotes;
            int nSucceeded;
            int nAllErrors;
            int nRowErrors, nTabErrors;
            int FAILURE2 = -(2);
            int nRow, nRows;
            string sRowChanged;
            
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
                    sRowChanged = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).RowChanged;
                    // If sRowChanged is not one of C, N, M (Changed, New, Modified - value changed)
                    // no need to validate it.
                    if (sRowChanged == null || !(sRowChanged == "C" || sRowChanged == "N" || sRowChanged == "M"))
                        continue;

                    nRowErrors = 0;
                    ld_effdate = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).EffectiveDate;
                    ldc_amount = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).AnnualAmount;
                    ll_altkey = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).AltKey;
                    sAltDescription = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).AltDescription;
                    sCaNotes = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).Notes;

                    wf_checkBasicErrors(il_contract, ll_altkey, ld_effdate, ldc_amount, sCaNotes
                                    , sAltDescription, sRowChanged, ref nRowErrors, ref is_errmsg);
                    
                    if( nRowErrors > 0 )
                    {
                        nTabErrors += nRowErrors;

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

                nRows = idw_roi_allowance.RowCount;
                for (nRow = 0; nRow < nRows; nRow++)
                {
                    // Check to see if this row has been changed
                    sRowChanged = idw_roi_allowance.GetItem<MaintainAllowance>(nRow).RowChanged;
                    // If sRowChanged is not one of C, N, M (Changed, New, Modified - value changed)
                    // no need to validate it.
                    if (sRowChanged == null || !(sRowChanged == "C" || sRowChanged == "N" || sRowChanged == "M"))
                        continue;

                    nRowErrors = 0;
                    ld_effdate = idw_roi_allowance.GetItem<MaintainAllowance>(nRow).EffectiveDate;
                    ldc_amount = idw_roi_allowance.GetItem<MaintainAllowance>(nRow).AnnualAmount;
                    ll_altkey = idw_roi_allowance.GetItem<MaintainAllowance>(nRow).AltKey;
                    sAltDescription = idw_roi_allowance.GetItem<MaintainAllowance>(nRow).AltDescription;
                    sCaNotes = idw_roi_allowance.GetItem<MaintainAllowance>(nRow).Notes;

                    wf_checkBasicErrors(il_contract, ll_altkey, ld_effdate, ldc_amount, sCaNotes
                                    , sAltDescription, sRowChanged, ref nRowErrors, ref is_errmsg);
                    
                    if( nRowErrors > 0 )
                    {
                        nTabErrors += nRowErrors;
                    }
                } // end for each fixed row loop

                if( nTabErrors > 0 )
                    nAllErrors += nTabErrors;
                else
                    nSucceeded++;
            }

            // Activity Allowances
            if (sAllowanceType == "Activity")
            {
                nTabErrors = 0;

                nRows = idw_activity_allowance.RowCount;
                for (nRow = 0; nRow < nRows; nRow++)
                {
                    // Check to see if this row has been changed
                    sRowChanged = idw_activity_allowance.GetItem<MaintainAllowance>(nRow).RowChanged;
                    // If sRowChanged is not one of C, N, M (Changed, New, Modified - value changed)
                    // no need to validate it.
                    if (sRowChanged == null || !(sRowChanged == "C" || sRowChanged == "N" || sRowChanged == "M"))
                        continue;

                    nRowErrors = 0;
                    ld_effdate = idw_activity_allowance.GetItem<MaintainAllowance>(nRow).EffectiveDate;
                    ldc_amount = idw_activity_allowance.GetItem<MaintainAllowance>(nRow).AnnualAmount;
                    ll_altkey = idw_activity_allowance.GetItem<MaintainAllowance>(nRow).AltKey;
                    sAltDescription = idw_activity_allowance.GetItem<MaintainAllowance>(nRow).AltDescription;
                    sCaNotes = idw_activity_allowance.GetItem<MaintainAllowance>(nRow).Notes;

                    wf_checkBasicErrors(il_contract, ll_altkey, ld_effdate, ldc_amount, sCaNotes
                                    , sAltDescription, sRowChanged, ref nRowErrors, ref is_errmsg);

                    if (nRowErrors > 0)
                    {
                        nTabErrors += nRowErrors;
                    }
                } // end for each fixed row loop

                if (nTabErrors > 0)
                    nAllErrors += nTabErrors;
                else
                    nSucceeded++;
            }

            // Time Allowances
            if (sAllowanceType == "Time")
            {
                nTabErrors = 0;

                nRows = idw_time_allowance.RowCount;
                for (nRow = 0; nRow < nRows; nRow++)
                {
                    // Check to see if this row has been changed
                    sRowChanged = idw_time_allowance.GetItem<MaintainAllowance>(nRow).RowChanged;
                    // If sRowChanged is not one of C, N, M (Changed, New, Modified - value changed)
                    // no need to validate it.
                    if (sRowChanged == null || !(sRowChanged == "C" || sRowChanged == "N" || sRowChanged == "M"))
                        continue;

                    nRowErrors = 0;
                    ld_effdate = idw_time_allowance.GetItem<MaintainAllowance>(nRow).EffectiveDate;
                    ldc_amount = idw_time_allowance.GetItem<MaintainAllowance>(nRow).AnnualAmount;
                    ll_altkey = idw_time_allowance.GetItem<MaintainAllowance>(nRow).AltKey;
                    sAltDescription = idw_time_allowance.GetItem<MaintainAllowance>(nRow).AltDescription;
                    sCaNotes = idw_time_allowance.GetItem<MaintainAllowance>(nRow).Notes;

                    wf_checkBasicErrors(il_contract, ll_altkey, ld_effdate, ldc_amount, sCaNotes
                                    , sAltDescription, sRowChanged, ref nRowErrors, ref is_errmsg);

                    if (nRowErrors > 0)
                    {
                        nTabErrors += nRowErrors;
                    }
                } // end for each fixed row loop

                if (nTabErrors > 0)
                    nAllErrors += nTabErrors;
                else
                    nSucceeded++;
            }

            // Distance Allowances
            if (sAllowanceType == "Distance")
            {
                nTabErrors = 0;

                nRows = idw_distance_allowance.RowCount;
                for (nRow = 0; nRow < nRows; nRow++)
                {
                    // Check to see if this row has been changed
                    sRowChanged = idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow).RowChanged;
                    // If sRowChanged is not one of C, N, M (Changed, New, Modified - value changed)
                    // no need to validate it.
                    if (sRowChanged == null || !(sRowChanged == "C" || sRowChanged == "N" || sRowChanged == "M") )
                        continue;

                    nRowErrors = 0;
                    ld_effdate = idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow).EffectiveDate;
                    ldc_amount = idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow).AnnualAmount;
                    ll_altkey = idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow).AltKey;
                    sAltDescription = idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow).AltDescription;
                    sCaNotes = idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow).Notes;

                    wf_checkBasicErrors(il_contract, ll_altkey, ld_effdate, ldc_amount, sCaNotes
                                    , sAltDescription, sRowChanged, ref nRowErrors, ref is_errmsg);

                    if (nRowErrors > 0)
                    {
                        nTabErrors += nRowErrors;
                    }
                } // end for each fixed row loop

                if (nTabErrors > 0)
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

                set_approved_readonly();
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

        private void set_approved_readonly()
        {
            // Called if the user can approve an allowance; all allowances will have been 
            // made modifiable (readonly = false).
            // If the allowance has already been approved, make it readonly
            string sApproved = "N";
            for (int i = 0; i < dw_fixed_allowance.RowCount; i++)
            {
                sApproved = dw_fixed_allowance.GetItem<MaintainAllowance>(i).Approved;
                if (!(sApproved == null) && sApproved == "Y")
                {
                    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridCellReadonly(i,"ca_approved",true);
                    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
            }
            for (int i = 0; i < dw_roi_allowance.RowCount; i++)
            {
                sApproved = dw_roi_allowance.GetItem<MaintainAllowance>(i).Approved;
                if (!(sApproved == null) && sApproved == "Y")
                {
                    ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).SetGridCellReadonly(i, "ca_approved", true);
                    ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
            }
            for (int i = 0; i < dw_activity_allowance.RowCount; i++)
            {
                sApproved = dw_activity_allowance.GetItem<MaintainAllowance>(i).Approved;
                if (!(sApproved == null) && sApproved == "Y")
                {
                    ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).SetGridCellReadonly(i, "ca_approved", true);
                    ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
            }
            for (int i = 0; i < dw_time_allowance.RowCount; i++)
            {
                sApproved = dw_time_allowance.GetItem<MaintainAllowance>(i).Approved;
                if (!(sApproved == null) && sApproved == "Y")
                {
                    ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).SetGridCellReadonly(i, "ca_approved", true);
                    ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
            }
            for (int i = 0; i < dw_distance_allowance.RowCount; i++)
            {
                sApproved = dw_distance_allowance.GetItem<MaintainVehAllowance>(i).Approved;
                if (!(sApproved == null) && sApproved == "Y")
                {
                    ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).SetGridCellReadonly(i, "ca_approved", true);
                    ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
            }
        }

        #region Events

        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            if( of_save() == false )
                // If there were errors, tell the user and exit without closing
                MessageBox.Show("Save failed        ", ""
                     ,MessageBoxButtons.OK, MessageBoxIcon.Warning);  
            else 
                // If there were no errors, we close the window
                this.Close();
        }

        public virtual bool of_save()
        {
            cb_save.Focus();
            int nRow, ll_error;
            is_errmsg = "";
            bool bSaveOK = true;
            int nChanged, nDeleted;
            Decimal? dAmount = null;

            idw_fixed_allowance.DataObject.AcceptText();
            idw_roi_allowance.DataObject.AcceptText();
            idw_activity_allowance.DataObject.AcceptText();
            idw_time_allowance.DataObject.AcceptText();
            idw_distance_allowance.DataObject.AcceptText();

            decimal dTotalAmt;
            of_calc_allowance_total(out dTotalAmt);

            // Display the total
            this.Total.Text = dTotalAmt.ToString("###,###.00");

            // Check each tab for changes
            // Fixed Allowances
            nChanged = idw_fixed_allowance.ModifiedCount();
            nDeleted = (idw_fixed_allowance.DataObject).DeletedCount;
            nRow     = idw_fixed_allowance.GetRow();
            if (nRow >= 0)
                dAmount = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).AnnualAmount;
            if (nChanged > 0 || nDeleted > 0 || (nRow >= 0 && dAmount == null))
            {
                ll_error = wf_validate("Fixed");

                if (ll_error == FAILURE)
                {
                    MessageBox.Show(is_errmsg, "Fixed Allowance Validation Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    bSaveOK = false;
                }
                else
                {
                    // If this row is marked Modified ("M") we want to insert it as a new row
                    // to preserve the change history.  Otherwise it will be updated.
                    string sRowChanged = ((MaintainAllowance)idw_fixed_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged ?? "X";
                    if (sRowChanged == "M" )
                        ((MaintainAllowance)idw_fixed_allowance.GetItem<MaintainAllowance>(nRow)).MarkNewEntity();
                    // Clear the RowChanged (to an arbitrary "X") so its current value isn't "remembered"
                    ((MaintainAllowance)idw_fixed_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged = "X";

                    idw_fixed_allowance.Save();
                    if (idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).SQLCode != 0)
                    {
                        MessageBox.Show("Failed to update Fixed Allowance. \n\n"
                                       + "Error Code: " + idw_fixed_allowance.GetItem<MaintainAllowance>(0).SQLCode.ToString() + "\n\n"
                                       + "Error Text: " + idw_fixed_allowance.GetItem<MaintainAllowance>(0).SQLErrText
                                       , "Database Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        bSaveOK = false;

                        // If the save failed, reset the RowChanged value so its current value is "remembered" if
                        // we manage to save the record later.
                        ((MaintainAllowance)idw_fixed_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged = sRowChanged;
                    }
                    else
                        MessageBox.Show("Saved fixed allowance changes");
                }
            }

            // ROI Allowances
            nChanged = idw_roi_allowance.ModifiedCount();
            nDeleted = (idw_roi_allowance.DataObject).DeletedCount;
            nRow     = idw_roi_allowance.GetRow();
            if (nRow >= 0)
                dAmount = idw_roi_allowance.GetItem<MaintainAllowance>(nRow).AnnualAmount;
            if (nChanged > 0 || nDeleted > 0 || (nRow >= 0 && dAmount == null))
            {
                ll_error = wf_validate("ROI");

                if (ll_error == FAILURE)
                {
                    MessageBox.Show(is_errmsg, "ROI Allowance Validation Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    bSaveOK = false;
                }
                else
                {
                    // If this row is marked Modified ("M") we want to insert it as a new row
                    // to preserve the change history.  Otherwise it will be updated.
                    string sRowChanged = ((MaintainAllowance)idw_roi_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged ?? "X";
                    if (sRowChanged == "M")
                        ((MaintainAllowance)idw_roi_allowance.GetItem<MaintainAllowance>(nRow)).MarkNewEntity();
                    // Clear the RowChanged (to an arbitrary "X") so its current value isn't "remembered"
                    ((MaintainAllowance)idw_roi_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged = "X";

                    idw_roi_allowance.Save();
                    if (idw_roi_allowance.GetItem<MaintainAllowance>(0).SQLCode != 0)
                    {
                        MessageBox.Show("Failed to update ROI Allowance.  \n\n"
                                       + "Error Code: " + idw_roi_allowance.GetItem<MaintainAllowance>(0).SQLCode.ToString() + "\n\n"
                                       + "Error Text: " + idw_roi_allowance.GetItem<MaintainAllowance>(0).SQLErrText
                                       , "Database Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        bSaveOK = false;

                        // If the save failed, reset the RowChanged value so its current value is "remembered" if
                        // we manage to save the record later.
                        ((MaintainAllowance)idw_roi_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged = sRowChanged;
                    }
                    else
                        MessageBox.Show("Saved ROI allowance changes");
                }
            }

            // Activity Allowances
            nChanged = idw_activity_allowance.ModifiedCount();
            nDeleted = (idw_activity_allowance.DataObject).DeletedCount;
            nRow     = idw_activity_allowance.GetRow();
            if (nRow >= 0)
                dAmount = idw_activity_allowance.GetItem<MaintainAllowance>(nRow).AnnualAmount;
            if (nChanged > 0 || nDeleted > 0 || (nRow >= 0 && dAmount == null))
            {
                ll_error = wf_validate("Activity");

                if (ll_error == FAILURE)
                {
                    MessageBox.Show(is_errmsg, "Activity Allowance Validation Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    bSaveOK = false;
                }
                else
                {
                    // If this row is marked Modified ("M") we want to insert it as a new row
                    // to preserve the change history.  Otherwise it will be updated.
                    string sRowChanged = ((MaintainAllowance)idw_activity_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged ?? "X";
                    if (sRowChanged == "M")
                        ((MaintainAllowance)idw_activity_allowance.GetItem<MaintainAllowance>(nRow)).MarkNewEntity();
                    // Clear the RowChanged (to an arbitrary "X") so its current value isn't "remembered"
                    ((MaintainAllowance)idw_activity_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged = "X";

                    idw_activity_allowance.Save();
                    if (idw_activity_allowance.GetItem<MaintainAllowance>(0).SQLCode != 0)
                    {
                        MessageBox.Show("Failked to update Activity Allowance.  \n\n"
                                       + "Error Code: " + idw_activity_allowance.GetItem<MaintainAllowance>(0).SQLCode.ToString() + "\n\n"
                                       + "Error Text: " + idw_activity_allowance.GetItem<MaintainAllowance>(0).SQLErrText
                                       , "Database Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        bSaveOK = false;

                        // If the save failed, reset the RowChanged value so its current value is "remembered" if
                        // we manage to save the record later.
                        ((MaintainAllowance)idw_activity_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged = sRowChanged;
                    }
                    else
                        MessageBox.Show("Saved activity allowance changes");
                }
            }

            // Time Allowances
            nChanged = idw_time_allowance.ModifiedCount();
            nDeleted = (idw_time_allowance.DataObject).DeletedCount;
            nRow     = idw_time_allowance.GetRow();
            if (nRow >= 0)
                dAmount = idw_time_allowance.GetItem<MaintainAllowance>(nRow).AnnualAmount;
            if (nChanged > 0 || nDeleted > 0 || (nRow >= 0 && dAmount == null))
            {
                ll_error = wf_validate("Time");

                if (ll_error == FAILURE)
                {
                    MessageBox.Show(is_errmsg, "Time Allowance Validation Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    bSaveOK = false;
                }
                else
                {
                    // If this row is marked Modified ("M") we want to insert it as a new row
                    // to preserve the change history.  Otherwise it will be updated.
                    string sRowChanged = ((MaintainAllowance)idw_time_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged ?? "X";
                    if (sRowChanged == "M")
                        ((MaintainAllowance)idw_time_allowance.GetItem<MaintainAllowance>(nRow)).MarkNewEntity();
                    // Clear the RowChanged (to an arbitrary "X") so its current value isn't "remembered"
                    ((MaintainAllowance)idw_time_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged = "X";

                    idw_time_allowance.Save();
                    if (idw_time_allowance.GetItem<MaintainAllowance>(0).SQLCode != 0)
                    {
                        MessageBox.Show("Failed to update Time Allowance.  \n\n"
                                       + "Error Code: " + idw_time_allowance.GetItem<MaintainAllowance>(0).SQLCode.ToString() + "\n\n"
                                       + "Error Text: " + idw_time_allowance.GetItem<MaintainAllowance>(0).SQLErrText
                                       , "Database Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        bSaveOK = false;

                        // If the save failed, reset the RowChanged value so its current value is "remembered" if
                        // we manage to save the record later.
                        ((MaintainAllowance)idw_time_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged = sRowChanged;
                    }
                    else
                        MessageBox.Show("Saved time allowance changes");
                }
            }

            // Distance Allowances
            nChanged = idw_distance_allowance.ModifiedCount();
            nDeleted = (idw_distance_allowance.DataObject).DeletedCount;
            nRow     = idw_distance_allowance.GetRow();
            if (nRow >= 0)
                dAmount = idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow).AnnualAmount;
            if (nChanged > 0 || nDeleted > 0 || (nRow >= 0 && dAmount == null))
            {
                ll_error = wf_validate("Distance");

                if (ll_error == FAILURE)
                {
                    MessageBox.Show(is_errmsg, "Distance Allowance Validation Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    bSaveOK = false;
                }
                else
                {
                    // If this row is marked Modified ("M") we want to insert it as a new row
                    // to preserve the change history.  Otherwise it will be updated.
                    string sRowChanged = ((MaintainVehAllowance)idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow)).RowChanged ?? "X";
                    if (sRowChanged == "M")
                        ((MaintainVehAllowance)idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow)).MarkNewEntity();
                    // Clear the RowChanged (to an arbitrary "X") so its current value isn't "remembered"
                    ((MaintainVehAllowance)idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow)).RowChanged = "X";

                    idw_distance_allowance.Save();
                    if (idw_distance_allowance.GetItem<MaintainVehAllowance>(0).SQLCode != 0)
                    {
                        MessageBox.Show("Failed to update Distance Allowance.  \n\n"
                                       + "Error Code: " + idw_distance_allowance.GetItem<MaintainVehAllowance>(0).SQLCode.ToString() + "\n\n"
                                       + "Error Text: " + idw_distance_allowance.GetItem<MaintainVehAllowance>(0).SQLErrText
                                       , "Database Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        bSaveOK = false;

                        // If the save failed, reset the RowChanged value so its current value is "remembered" if
                        // we manage to save the record later.
                        ((MaintainVehAllowance)idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow)).RowChanged = sRowChanged;
                    }
                    else
                        MessageBox.Show("Saved distance allowance changes");
                }
            }

            return bSaveOK;
        }

        private bool isDwNewOrDirty(URdsDw thisDw, int dwType )
        {   // Check to see if the DW is "New" or "dirty" (modified)
            // The user may try to save a new allowance without having completed it
            // and the record isn't "officially" dirty.

            if (StaticFunctions.IsDirty(thisDw)
                  || isDwNew(thisDw, dwType))
                return true;
            else return false;
        }

        private bool isDwNew( URdsDw thisDw, int dwType)
        {
            // Check to see if any rows in the DW are marked "N" (New)
            // NOTE: the Distance DW uses a different DataControl

            for (int nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                if( dwType == DISTANCE
                      && thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged == "N")
                    return true;
                else
                if( dwType != DISTANCE
                      && thisDw.GetItem<MaintainAllowance>(nRow).RowChanged == "N")
                    return true;
            }
            return false;
        }

        private bool isDwRowComplete(URdsDw thisDw, int inRow, int dwType)
        {
            if( dwType == DISTANCE )
            {
                if (thisDw.GetItem<MaintainVehAllowance>(inRow).CaVar1 == null
                    || thisDw.GetItem<MaintainVehAllowance>(inRow).CaHrsWk == null
                    || thisDw.GetItem<MaintainVehAllowance>(inRow).CaDistDay == null
                    || thisDw.GetItem<MaintainVehAllowance>(inRow).Notes == null
                    || (string)thisDw.GetItem<MaintainVehAllowance>(inRow).Notes == "")
                {
                    return false;
                }
            }
            else
            if( dwType != DISTANCE )
            {
                if (thisDw.GetItem<MaintainAllowance>(inRow).CaVar1 == null
                    || thisDw.GetItem<MaintainAllowance>(inRow).Notes == null
                    || (string)thisDw.GetItem<MaintainAllowance>(inRow).Notes == "")
                {
                    return false;
                }
            }
            return true;
        }

        private void of_delete_new_row(URdsDw thisDw, int dwType)
        {
            // If there are any records that are new and incomplete (fail verification)
            // delete them
            int rc, i;
            for (int nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                if (dwType == DISTANCE
                        && thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged == "N"
                        && isDwRowComplete( thisDw, nRow, dwType ) == false )
                {
                    thisDw.DataObject.DeleteItemAt(nRow);
                    rc = thisDw.Save();
                    i = rc;
                }
                else 
                if (dwType != DISTANCE
                        && thisDw.GetItem<MaintainAllowance>(nRow).RowChanged == "N"
                        && isDwRowComplete( thisDw, nRow, dwType ) == false )
                {
                    thisDw.DataObject.DeleteItemAt(nRow);
                    rc = thisDw.Save();
                    i = rc;
                }
            }
        }

        public bool of_preClose()
        {
            idw_fixed_allowance.DataObject.AcceptText();
            idw_roi_allowance.DataObject.AcceptText();
            idw_activity_allowance.DataObject.AcceptText();
            idw_time_allowance.DataObject.AcceptText();
            idw_distance_allowance.DataObject.AcceptText();

            if (isDwNewOrDirty(idw_fixed_allowance, FIXED)
                || isDwNewOrDirty(idw_roi_allowance, ROI)
                || isDwNewOrDirty(idw_activity_allowance, ACTIVITY)
                || isDwNewOrDirty(idw_time_allowance, TIME)
                || isDwNewOrDirty(idw_distance_allowance, DISTANCE)
               )
            {
                DialogResult ans;
                ans = MessageBox.Show("Do you want to save changes?", ""
                            , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (ans == DialogResult.Cancel)
                    return false;
                else if (ans == DialogResult.Yes)
                {
                    bool bSaveResult = of_save();
                    if (bSaveResult == false)
                    {
                        MessageBox.Show("Save failed        ", ""
                             , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else // ans == DialogResult.No
                {
                    // Delete any incomplete new records
                    if (isDwNew(idw_fixed_allowance,FIXED))
                        of_delete_new_row(idw_fixed_allowance,FIXED);
                    else if (isDwNew(idw_roi_allowance,ROI))
                        of_delete_new_row(idw_roi_allowance,ROI);
                    else if (isDwNew(idw_activity_allowance,ACTIVITY))
                        of_delete_new_row(idw_activity_allowance,ACTIVITY);
                    else if (isDwNew(idw_time_allowance,TIME))
                        of_delete_new_row(idw_time_allowance,TIME);
                    else if (isDwNew(idw_distance_allowance,DISTANCE))
                        of_delete_new_row(idw_distance_allowance,DISTANCE);
                }
            }
            return true;
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            if( of_preClose() == false )
                return;
/*
            idw_fixed_allowance.DataObject.Reset();
            idw_roi_allowance.DataObject.Reset();
            idw_activity_allowance.DataObject.Reset();
            idw_time_allowance.DataObject.Reset();
            idw_distance_allowance.DataObject.Reset();
*/
            this.Close();
        }

        private void cb_delete_Click(object sender, EventArgs e)
        {
            int nRow = 0;
            string sAltDescription, sDwName;

            sDwName = idw_Current.Name;
            nRow = idw_Current.DataObject.GetRow();
            sAltDescription = "null";
            
            bool isReadonly = false;
            if (sDwName == "dw_fixed_allowance")
            {
                isReadonly = ((DMaintainFixedAllowance)(idw_Current.DataObject)).GetGridRowReadOnly(nRow);
                sAltDescription = idw_Current.GetItem<MaintainAllowance>(nRow).AltDescription;
            }
            else if (sDwName == "dw_roi_allowance")
            {
                isReadonly = ((DMaintainROIAllowance)(idw_Current.DataObject)).GetGridRowReadOnly(nRow);
                sAltDescription = idw_Current.GetItem<MaintainAllowance>(nRow).AltDescription;
            }
            else if (sDwName == "dw_activity_allowance")
            {
                isReadonly = ((DMaintainActivityAllowance)(idw_Current.DataObject)).GetGridRowReadOnly(nRow);
                sAltDescription = idw_Current.GetItem<MaintainAllowance>(nRow).AltDescription;
            }
            else if (sDwName == "dw_time_allowance")
            {
                isReadonly = ((DMaintainTimeAllowance)(idw_Current.DataObject)).GetGridRowReadOnly(nRow);
                sAltDescription = idw_Current.GetItem<MaintainAllowance>(nRow).AltDescription;
            }
            else if (sDwName == "dw_distance_allowance")
            {
                isReadonly = ((DMaintainDistanceAllowance)(idw_Current.DataObject)).GetGridRowReadOnly(nRow);
                sAltDescription = idw_Current.GetItem<MaintainVehAllowance>(nRow).AltDescription;
            }


            if (isReadonly)
            {
                MessageBox.Show("You do not have premission to delete this allowance");
            }
            else{
                DialogResult ans;
                ans = MessageBox.Show("Please confirm that you want to delete allowance \n"
                                    + "       " + sAltDescription + "."
                                    , "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    idw_Current.DataObject.DeleteItemAt(nRow);

                    decimal dTotalAmt;
                    of_calc_allowance_total(out dTotalAmt);

                    // Display the total
                    this.Total.Text = dTotalAmt.ToString("###,###.00");
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
//                if ( dw_fixed_allowance.RowCount <= 0 )
//                    ((DMaintainFixedAllowance)dw_fixed_allowance.DataObject).Retrieve(il_contract, dtEffDate, 1);
            }
            if (ToTabName == "roi")
            {
                idw_Current = idw_roi_allowance;
//                if (idw_roi_allowance.RowCount <= 0)
//                    ((DMaintainROIAllowance)idw_roi_allowance.DataObject).Retrieve(il_contract, dtEffDate, 1);
            }
            if (ToTabName == "activity")
            {
                idw_Current = idw_activity_allowance;
//                if (idw_activity_allowance.RowCount <= 0)
//                    ((DMaintainActivityAllowance)idw_activity_allowance.DataObject).Retrieve(il_contract, dtEffDate, 1);
            }
            if (ToTabName == "time")
            {
                idw_Current = idw_time_allowance;
//                if (idw_time_allowance.RowCount <= 0)
//                    ((DMaintainTimeAllowance)idw_time_allowance.DataObject).Retrieve(il_contract, dtEffDate, 1);
            }
            if (ToTabName == "distance")
            {
                idw_Current = idw_distance_allowance;
                if (idw_distance_allowance.RowCount > 0)
                    idw_distance_allowance.Refresh();
//                    ((DMaintainDistanceAllowance)idw_distance_allowance.DataObject).Retrieve(il_contract, dtEffDate, 1);
            }
        }

        void dw_distance_allowance_DoubleClick(object sender, EventArgs e)
        {
            // From contract_allowances
            decimal days_wk = 0.0M;
            decimal hours_wk = 0.0M;
            decimal distance_day = 0.0M;
            string costs_covered = "N";

            // From allowance_type
            decimal rate_hr = 0.0M;
            decimal weeks_yr = 0.0M;
            decimal ACC = 0.0M;
            decimal fuel_pk = 0.0M;
            decimal ruc_pk = 0.0M;

            // From vehicle_allowance_rates
            decimal carrier_pa = 0.0M;
            decimal repairs_pk = 0.0M;
            decimal licence_pa = 0.0M;
            decimal tyres_pk = 0.0M;
            decimal allowance_pk = 0.0M;
            decimal insurance_pa = 0.0M;
            decimal ror_pa = 0.0M;

            // Intermediate calculated velues
            decimal HoursAmt = 0.0M;
            decimal DistAmt = 0.0M;
            decimal Dist_yr = 0.0M;
            decimal VehCosts = 0.0M;

            int nRow = idw_distance_allowance.GetRow();

            days_wk = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow).CaVar1);
            hours_wk = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow).CaHrsWk);
            weeks_yr = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow).AltWksYr);
            rate_hr = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow).AltRate);
            HoursAmt = (hours_wk * weeks_yr) * rate_hr;

            MessageBox.Show("Labour cost = (Hours/wk * Weeks/yr * Rate/Hr) = $" + HoursAmt.ToString("###,##0.00") + "\n"
                          + "  Hours/wk = " + hours_wk.ToString("###") + "  Weeks/yr = " + weeks_yr.ToString("###")
                               + "  Rate/hr = $" + rate_hr.ToString("##0.00") + "\n\n"
                          + "Distance cost = $" + DistAmt.ToString("###,##0.00") + "\n"
                          + "    (dist/day * days/wk * weeks/yr) * (RUC/K + Repairs/K + Tyres/K + Allowance/K) \n"
                          , "Distance-based calculation details"
                          , MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private decimal of_getDecimalValue(decimal? value)
        {
            decimal dValue;
            dValue = (value == null) ? 0.0M : (decimal)value;
            return dValue;
        }

        void dw_fixed_allowance_ItemChanged(object sender, EventArgs e)
        {
            of_allowance_ItemChanged(dw_fixed_allowance, FIXED);
        }

        void dw_roi_allowance_ItemChanged(object sender, EventArgs e)
        {
            of_allowance_ItemChanged(dw_roi_allowance, ROI);
        }

        void dw_activity_allowance_ItemChanged(object sender, EventArgs e)
        {
            of_allowance_ItemChanged(dw_activity_allowance, ACTIVITY);
        }

        void dw_time_allowance_ItemChanged(object sender, EventArgs e)
        {
            of_allowance_ItemChanged(dw_time_allowance, TIME);
        }

        void dw_distance_allowance_ItemChanged(object sender, EventArgs e)
        {
            of_allowance_ItemChanged(dw_distance_allowance, DISTANCE);
        }

        void of_allowance_ItemChanged(URdsDw thisDw, int dwType)
        {
            // Implements ItemChanged actions for all tabs
            decimal dThisAmt = 0.0M;
            decimal dTotalAmt = 0.0M;
            int nAltKey;

            // Get the allowance key for the changed item
            int nRow = thisDw.GetRow();
            if (dwType == DISTANCE)
                nAltKey = (int)thisDw.GetItem<MaintainVehAllowance>(nRow).AltKey;
            else
                nAltKey = (int)thisDw.GetItem<MaintainAllowance>(nRow).AltKey;

            // Calculate the new allowance total for this allowance type
            // Note: this updates the total for all rows of the same type
            of_calc_allowance_type(thisDw, nAltKey, dwType, out dThisAmt);

            // Update the overall total
            of_calc_allowance_total(out dTotalAmt);
            this.Total.Text = dTotalAmt.ToString("###,###.00");

            // Refresh the display to show all changes
            thisDw.Refresh();
        }
        #endregion

        private void of_calc_tab_allowances(URdsDw tab_dw, int dwType)
        {
            // Scans the allowance panel, updating the allowance totals for all allowances listed
            int nRow, nAltKey;
            List<int> keysSeen = new List<int>();
            decimal dThisTotal = 0.0M;

            // Scan through the DW
            for (nRow = 0; nRow < tab_dw.RowCount; nRow++)
            {
                // Get this row's alt_key
                if (dwType == DISTANCE)
                    nAltKey = (int)tab_dw.GetItem<MaintainVehAllowance>(nRow).AltKey;
                else
                    nAltKey = (int)tab_dw.GetItem<MaintainAllowance>(nRow).AltKey;

                // If we haven't seen it before ...
                if (!keysSeen.Contains(nAltKey))
                {
                    // Calculate the total allowance for this allowance type 
                    // (and update all rows of the same type with the value).
                    of_calc_allowance_type(tab_dw, nAltKey, dwType, out dThisTotal);

                    // Add the key to the list os 'seen' keys
                    keysSeen.Add(nAltKey);
                }
            }
        }

        private void of_calc_allowance_type(URdsDw tab_dw, int inAltKey, int dwType, out decimal type_total)
        {
            //Calculate the total allowance for an individual allowance type
            // and update the allowance total for each row
            int nRow;
            int thisAltKey;

            decimal dTotalAmt = 0.0M;
            decimal? dThisAmt = 0.0M;
 
            // Re-calculate the total of the AnnualPayments for the specified allowance type
            dTotalAmt = 0.0M;
            for (nRow = 0; nRow < tab_dw.RowCount; nRow++)
            {
                if (dwType == DISTANCE)
                {
                    dThisAmt = tab_dw.GetItem<MaintainVehAllowance>(nRow).AnnualAmount;
                    thisAltKey = (int)tab_dw.GetItem<MaintainVehAllowance>(nRow).AltKey;
                }
                else
                {
                    dThisAmt = tab_dw.GetItem<MaintainAllowance>(nRow).AnnualAmount;
                    thisAltKey = (int)tab_dw.GetItem<MaintainAllowance>(nRow).AltKey;
                }

                if (thisAltKey == inAltKey)
                {
                    if (dThisAmt != null)
                        dTotalAmt += (decimal)dThisAmt;
                }
            }

            // Update the allowance types' totals for each row of that type
            for (nRow = 0; nRow < tab_dw.RowCount; nRow++)
            {
                if (dwType == DISTANCE)
                {
                    thisAltKey = (int)tab_dw.GetItem<MaintainVehAllowance>(nRow).AltKey;
                    if (thisAltKey == inAltKey)
                        tab_dw.GetItem<MaintainVehAllowance>(nRow).TotalAmount = dTotalAmt;
                }
                else
                {
                    thisAltKey = (int)tab_dw.GetItem<MaintainAllowance>(nRow).AltKey;
                    if (thisAltKey == inAltKey)
                        tab_dw.GetItem<MaintainAllowance>(nRow).TotalAmount = dTotalAmt;
                }
            }

            // Return the total
            type_total = dTotalAmt;
        }

        private void of_calc_allowance(URdsDw tab_dw, int dwType, out decimal tab_total)
        {
            int nRow, nRows;
            decimal dTotalAmt = 0.0M;
            decimal? dThisAmt = 0.0M;

            // Re-calculate the total of the AnnualPayments
            dTotalAmt = 0.0M;
            nRows = tab_dw.RowCount;
            for (nRow = 0; nRow < nRows; nRow++)
            {
                if( dwType == DISTANCE)
                    dThisAmt = tab_dw.GetItem<MaintainVehAllowance>(nRow).AnnualAmount;
                else
                    dThisAmt = tab_dw.GetItem<MaintainAllowance>(nRow).AnnualAmount;

                if (dThisAmt != null)
                    dTotalAmt += (decimal)dThisAmt;
            }

            // Return the total
            tab_total = dTotalAmt;
        }

        private void of_calc_allowance_total(out decimal allowance_total)
        {
            decimal dTotalAmt = 0.0M;
            decimal dThisAmt  = 0.0M;

            of_calc_allowance(idw_fixed_allowance, FIXED, out dThisAmt);
            dTotalAmt += dThisAmt;
            of_calc_allowance(idw_roi_allowance, ROI, out dThisAmt);
            dTotalAmt += dThisAmt;
            of_calc_allowance(idw_activity_allowance, ACTIVITY, out dThisAmt);
            dTotalAmt += dThisAmt;
            of_calc_allowance(idw_time_allowance, TIME, out dThisAmt);
            dTotalAmt += dThisAmt;
            of_calc_allowance(idw_distance_allowance, DISTANCE, out dThisAmt);
            dTotalAmt += dThisAmt;

            allowance_total = dTotalAmt;
        }
    }
}
