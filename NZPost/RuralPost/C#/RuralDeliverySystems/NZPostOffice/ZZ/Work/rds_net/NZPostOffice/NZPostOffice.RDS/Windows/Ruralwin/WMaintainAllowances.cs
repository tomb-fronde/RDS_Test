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
        private int newRow, oldRow;

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
            //dw_fixed_allowance.ItemChanged += new EventHandler(dw_fixed_allowance_ItemChanged);
            idw_fixed_allowance = dw_fixed_allowance;

            this.dw_roi_allowance.DataObject = new DMaintainROIAllowance();
            dw_roi_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_roi_allowance.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_roi_allowance_constructor);
            //dw_roi_allowance.ItemChanged += new EventHandler(dw_roi_allowance_ItemChanged);
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
            dw_distance_allowance.DoubleClick += new EventHandler(dw_distance_allowance_DoubleClick);
            idw_distance_allowance = dw_distance_allowance;

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
            this.st_label.Location = new System.Drawing.Point(2, 318);
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
            this.dw_fixed_allowance.Size = new System.Drawing.Size(979, 266);
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
            this.cb_save.Location = new System.Drawing.Point(609, 313);
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
            this.cb_cancel.Location = new System.Drawing.Point(695, 313);
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
            this.tabControl1.Size = new System.Drawing.Size(997, 304);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dw_fixed_allowance);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(989, 278);
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
            this.cb_delete.Location = new System.Drawing.Point(528, 313);
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
            this.Total.Location = new System.Drawing.Point(308, 318);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(100, 20);
            this.Total.TabIndex = 6;
            // 
            // Total_t
            // 
            this.Total_t.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Total_t.AutoSize = true;
            this.Total_t.Location = new System.Drawing.Point(205, 323);
            this.Total_t.Name = "Total_t";
            this.Total_t.Size = new System.Drawing.Size(87, 13);
            this.Total_t.TabIndex = 0;
            this.Total_t.Text = "Total allowances";
            // 
            // WMaintainAllowances
            // 
            this.AcceptButton = this.cb_save;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1009, 344);
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
            NRdsMsg lnv_msg;
            NCriteria lvn_Criteria;

            this.of_set_componentname("Allowance");

            lnv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            lvn_Criteria = lnv_msg.of_getcriteria();
            il_contract = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("contract_no"));
            il_contract_seq = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("con_active_seq"));
            il_altKey = (int?)System.Convert.ToInt32(lvn_Criteria.of_getcriteria("alt_key"));
            il_alctId = (int?)System.Convert.ToInt32(lvn_Criteria.of_getcriteria("alct_id"));
            //dtEffDate = (DateTime)lvn_Criteria.of_getcriteria("effective_date");
            ls_title = lvn_Criteria.of_getcriteria("contract_title") as string;
            isOptype = lvn_Criteria.of_getcriteria("optype") as string;
            this.Text += " - " + ls_title;

            // The following relationship between alct_id and datawindows is hard-coded
            // See table allowance_calc_type (yes, I konw its very bad practice ;(
            dw_fixed_allowance.DataObject.Reset();
            ((DMaintainFixedAllowance)dw_fixed_allowance.DataObject).Retrieve(il_contract, FIXED);
            dw_roi_allowance.DataObject.Reset();
            ((DMaintainROIAllowance)dw_roi_allowance.DataObject).Retrieve(il_contract, ROI);
            dw_activity_allowance.DataObject.Reset();
            ((DMaintainActivityAllowance)dw_activity_allowance.DataObject).Retrieve(il_contract, ACTIVITY);
            dw_time_allowance.DataObject.Reset();
            ((DMaintainTimeAllowance)dw_time_allowance.DataObject).Retrieve(il_contract, TIME);
            dw_distance_allowance.DataObject.Reset();
            ((DMaintainDistanceAllowance)dw_distance_allowance.DataObject).Retrieve(il_contract, DISTANCE);

            // Set idw_current to the appropriate Datacontrol
            if (il_alctId == null || (int)il_alctId <= FIXED || (int)il_alctId > DISTANCE)
                idw_Current = dw_fixed_allowance;
            else if (il_alctId == ROI)
                idw_Current = dw_roi_allowance;
            else if (il_alctId == ACTIVITY)
                idw_Current = dw_activity_allowance;
            else if (il_alctId == TIME)
                idw_Current = dw_time_allowance;
            else if (il_alctId == DISTANCE)
                idw_Current = dw_distance_allowance;

            if (isOptype == "Insert")
            {
                // Find the newly-added record.  It will be the most-recent ecord of its allowance type,
                // but not necessarily the first of the displayed record (at row 0) since the records
                // will have been sorted into description order.
                newRow = of_find_inserted(il_altKey, idw_Current, il_alctId);
                if (newRow < 0)
                {
                    MessageBox.Show("?? Inserted allowance not found ??");
                }

                // We then add the current net amount into the record.  This is used in the Datacontrol 
                // to calculate the change amount (ca_annual_amount)
                Decimal? netAmt = RDSDataService.GetAllowanceNetAmount(il_contract, il_altKey);
                idw_Current.GetItem<MaintainAllowanceV2>(newRow).NetAmount = netAmt;
            }

            // Check whether the user has permission to approve allowances, and
            // set the ca_approved column readonly if not.
            set_approvability();
/*
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
*/
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
            if (il_alctId == null || (int)il_alctId < FIXED || (int)il_alctId > DISTANCE)
            {
                il_alctId = of_getPopulatedAllowance();
                tabControl1.SelectedIndex = (int)il_alctId;
                il_alctId++;
            }
            else
                tabControl1.SelectedIndex = ((int)il_alctId - 1);

            // of_set_row_readonly();
        }

        private int of_find_inserted(int? in_altKey, URdsDw thisDw, int? in_alctId)
        {
            // Returns the row number of the added record.  The added record will
            // be marked new (ca_row_changed == "N")
            int foundRow = -1; // not found

            for (int nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                //if (in_alctId == DISTANCE)
                //{
                //    if (thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged == "N")
                //    {
                //        foundRow = nRow;
                //        break;
                //    }
                //}
                //else
                //{
                //    if (thisDw.GetItem<MaintainAllowance>(nRow).RowChanged == "N")
                //    {
                //        foundRow = nRow;
                //        break;
                //    }
                //}
                if (thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged == "N")
                {
                    foundRow = nRow;
                    break;
                }
            }
            return foundRow;
        }

        private string of_add_new_record(URdsDw thisDw, int dwType, int inRow)
        {
            // If the user makes a change to a record (at oldRow), create a copy of 
            // that record (at row nRow).  The old record will become the history record.
            // Also needed so that the old record remains as its annual_amount 
            // contributes to the allowance totals as changes are made.
            //
            // Returns an empty string if successful, or an error message if not

            Decimal? tmpAmount = 0.0M;  // for debugging
            string errmsg = "";

            newRow = inRow;
            // Create the new row in the relevant tab/DW
            // Do everything in a try block so we can catch any errors that might occur
            try
            {
/*
                if (dwType == DISTANCE)
                    thisDw.DataObject.InsertItem<MaintainVehAllowance>(newRow, new MaintainVehAllowance());
                else // its one of FIXED, ROI, ACTIVITY, TIME
                    thisDw.DataObject.InsertItem<MaintainAllowance>(newRow, new MaintainAllowance());
*/
                thisDw.DataObject.InsertItem<MaintainAllowanceV2>(newRow, new MaintainAllowanceV2());
            }
            catch (Exception e)
            {
                errmsg = e.Message;
                thisDw.DataObject.DeleteItemAt(newRow);
                return  errmsg;
            }

            // Copy the contents of the old row to the new row with the new annual_amount,
            // updated net amount, and set Approved = "N" and PaidToDate = null
            oldRow = inRow + 1;

            // contract_allowance elements
            thisDw.GetItem<MaintainAllowanceV2>(newRow).ContractTitle
                       = thisDw.GetItem<MaintainAllowanceV2>(oldRow).ContractTitle;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).ContractNo
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).ContractNo;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).AltKey
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).AltKey;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).EffectiveDate
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).EffectiveDate;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).AnnualAmount
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).AnnualAmount;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).PaidToDate = null;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).Approved = "N";
            thisDw.GetItem<MaintainAllowanceV2>(newRow).DocDescription
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).DocDescription;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).Notes
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).Notes;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).CaVar1
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).CaVar1;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).CaDistDay
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).CaDistDay;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).CaHrsWk
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).CaHrsWk;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).CaCostsCovered
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).CaCostsCovered;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).VarId
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).VarId;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).NetAmount
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).NetAmount;

            // allowance_type elements
            thisDw.GetItem<MaintainAllowanceV2>(newRow).AltDescription
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).AltDescription;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).AltRate
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).AltRate;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).AltWksYr
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).AltWksYr;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).AltAcc
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).AltAcc;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).AlctId
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).AlctId;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).AlctDescription
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).AlctDescription;

            // vehicle_allowance_rates elements
            thisDw.GetItem<MaintainAllowanceV2>(newRow).VarId
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).VarId;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).VarDescription
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).VarDescription;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).VarCarrierPa
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).VarCarrierPa;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).VarRepairsPk
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).VarRepairsPk;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).VarLicencePa
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).VarLicencePa;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).VarTyresPk
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).VarTyresPk;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).VarAllowancePk
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).VarAllowancePk;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).VarInsurancePa
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).VarInsurancePa;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).VarRorPa
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).VarRorPa;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).VarFuelUsePk
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).VarFuelUsePk;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).VarFuelRate
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).VarFuelRate;
            thisDw.GetItem<MaintainAllowanceV2>(newRow).VarRucRatePk
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).VarRucRatePk;

            // Mark the new record as New ("N")
            thisDw.GetItem<MaintainAllowanceV2>(newRow).RowChanged = "M";
            thisDw.GetItem<MaintainAllowanceV2>(newRow).MarkNewEntity();

            // Put the old record's changed values back to their initial values
            // (there are only a few possibilities) and mark it clean
            // contract_allowance elements
            thisDw.GetItem<MaintainAllowanceV2>(oldRow).EffectiveDate
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).InitialEffDate;
            thisDw.GetItem<MaintainAllowanceV2>(oldRow).AnnualAmount
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).InitialAmount;
            thisDw.GetItem<MaintainAllowanceV2>(oldRow).NetAmount
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).InitialNetAmount;
            thisDw.GetItem<MaintainAllowanceV2>(oldRow).Approved
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).InitialApproved;
            thisDw.GetItem<MaintainAllowanceV2>(oldRow).DocDescription
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).InitialDocDescr;
            thisDw.GetItem<MaintainAllowanceV2>(oldRow).Notes
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).InitialNotes;
            thisDw.GetItem<MaintainAllowanceV2>(oldRow).CaVar1
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).InitialCaVar1;
            thisDw.GetItem<MaintainAllowanceV2>(oldRow).CaDistDay
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).InitialDistDay;
            thisDw.GetItem<MaintainAllowanceV2>(oldRow).CaHrsWk
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).InitialHrsWk;
            thisDw.GetItem<MaintainAllowanceV2>(oldRow).CaCostsCovered
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).InitialCostsCovered;
            thisDw.GetItem<MaintainAllowanceV2>(oldRow).VarId
                     = thisDw.GetItem<MaintainAllowanceV2>(oldRow).InitialVarId;

            // Mark the old record "clean" so it doesn't trigger an update
            thisDw.GetItem<MaintainAllowanceV2>(oldRow).RowChanged = "X";
            thisDw.GetItem<MaintainAllowanceV2>(oldRow).MarkClean();

            //if (dwType == DISTANCE)
            //{
            //    // contract_allowance elements
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).ContractTitle
            //               = thisDw.GetItem<MaintainVehAllowance>(oldRow).ContractTitle;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).ContractNo
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).ContractNo;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).AltKey
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).AltKey;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).EffectiveDate
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).EffectiveDate;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).AnnualAmount
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).AnnualAmount;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).PaidToDate = null;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).Approved = "N";
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).DocDescription
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).DocDescription;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).Notes
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).Notes;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).CaVar1
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).CaVar1;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).CaDistDay
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).CaDistDay;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).CaHrsWk
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).CaHrsWk;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).EndDate
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).EndDate;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).CaCostsCovered
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).CaCostsCovered;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).VarId
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).VarId;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).NetAmount
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).NetAmount;

            //    // allowance_type elements
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).AltDescription
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).AltDescription;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).AltRate
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).AltRate;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).AltWksYr
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).AltWksYr;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).AltAcc
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).AltAcc;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).AlctId
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).AlctId;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).AlctDescription
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).AlctDescription;

            //    // vehicle_allowance_rates elements
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).VarId
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).VarId;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).VarDescription
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).VarDescription;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).VarCarrierPa
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).VarCarrierPa;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).VarRepairsPk
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).VarRepairsPk;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).VarLicencePa
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).VarLicencePa;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).VarTyresPk
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).VarTyresPk;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).VarAllowancePk
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).VarAllowancePk;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).VarInsurancePa
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).VarInsurancePa;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).VarRorPa
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).VarRorPa;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).VarFuelUsePk
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).VarFuelUsePk;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).VarFuelRate
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).VarFuelRate;
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).VarRucRatePk
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).VarRucRatePk;

            //    // Mark the new record as New ("N")
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).RowChanged = "M";
            //    thisDw.GetItem<MaintainVehAllowance>(newRow).MarkNewEntity();
            //}
            //else // its one of FIXED, ROI, ACTIVITY, TIME
            //{
            //    // contract_allowance elements
            //    thisDw.GetItem<MaintainAllowance>(newRow).ContractTitle
            //               = thisDw.GetItem<MaintainAllowance>(oldRow).ContractTitle;
            //    thisDw.GetItem<MaintainAllowance>(newRow).ContractNo
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).ContractNo;
            //    thisDw.GetItem<MaintainAllowance>(newRow).AltKey
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).AltKey;
            //    thisDw.GetItem<MaintainAllowance>(newRow).EffectiveDate
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).EffectiveDate;
            //    thisDw.GetItem<MaintainAllowance>(newRow).AnnualAmount
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).AnnualAmount;
            //    thisDw.GetItem<MaintainAllowance>(newRow).NetAmount
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).NetAmount;
            //    thisDw.GetItem<MaintainAllowance>(newRow).PaidToDate = null;
            //    thisDw.GetItem<MaintainAllowance>(newRow).Approved = "N";
            //    thisDw.GetItem<MaintainAllowance>(newRow).DocDescription
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).DocDescription;
            //    thisDw.GetItem<MaintainAllowance>(newRow).Notes
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).Notes;
            //    thisDw.GetItem<MaintainAllowance>(newRow).CaVar1
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).CaVar1;
            //    thisDw.GetItem<MaintainAllowance>(newRow).CaDistDay
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).CaDistDay;
            //    thisDw.GetItem<MaintainAllowance>(newRow).CaHrsWk
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).CaHrsWk;
            //    thisDw.GetItem<MaintainAllowance>(newRow).EndDate
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).EndDate;
            //    thisDw.GetItem<MaintainAllowance>(newRow).CaCostsCovered
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).CaCostsCovered;

            //    // allowance_type elements
            //    thisDw.GetItem<MaintainAllowance>(newRow).AltDescription
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).AltDescription;
            //    thisDw.GetItem<MaintainAllowance>(newRow).AltRate
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).AltRate;
            //    thisDw.GetItem<MaintainAllowance>(newRow).AltWksYr
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).AltWksYr;
            //    thisDw.GetItem<MaintainAllowance>(newRow).AltAcc
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).AltAcc;
            //    thisDw.GetItem<MaintainAllowance>(newRow).AltFuelPk
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).AltFuelPk;
            //    thisDw.GetItem<MaintainAllowance>(newRow).AltRucPk
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).AltRucPk;
            //    thisDw.GetItem<MaintainAllowance>(newRow).AlctId
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).AlctId;
            //    thisDw.GetItem<MaintainAllowance>(newRow).AlctDescription
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).AlctDescription;

            //    // Mark the new record 'New' ("N")
            //    thisDw.GetItem<MaintainAllowance>(newRow).RowChanged = "N";
            //    thisDw.GetItem<MaintainAllowance>(newRow).MarkNewEntity();
            //}

            //// Put the old record's changed values back to their initial values
            //// (there are only a few possibilities) and mark it clean
            //if (dwType == DISTANCE)
            //{
            //    // contract_allowance elements
            //    thisDw.GetItem<MaintainVehAllowance>(oldRow).EffectiveDate
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).InitialEffDate;
            //    thisDw.GetItem<MaintainVehAllowance>(oldRow).AnnualAmount
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).InitialAmount;
            //    thisDw.GetItem<MaintainVehAllowance>(oldRow).NetAmount
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).InitialNetAmount;
            //    thisDw.GetItem<MaintainVehAllowance>(oldRow).Approved
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).InitialApproved;
            //    thisDw.GetItem<MaintainVehAllowance>(oldRow).DocDescription
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).InitialDocDescr;
            //    thisDw.GetItem<MaintainVehAllowance>(oldRow).Notes
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).InitialNotes;
            //    thisDw.GetItem<MaintainVehAllowance>(oldRow).CaVar1
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).InitialCaVar1;
            //    thisDw.GetItem<MaintainVehAllowance>(oldRow).CaDistDay
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).InitialDistDay;
            //    thisDw.GetItem<MaintainVehAllowance>(oldRow).CaHrsWk
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).InitialHrsWk;
            //    thisDw.GetItem<MaintainVehAllowance>(oldRow).CaCostsCovered
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).InitialCostsCovered;
            //    thisDw.GetItem<MaintainVehAllowance>(oldRow).VarId
            //             = thisDw.GetItem<MaintainVehAllowance>(oldRow).InitialVarId;

            //    // Mark the old record "clean" so it doesn't trigger an update
            //    thisDw.GetItem<MaintainVehAllowance>(oldRow).RowChanged = "X";
            //    thisDw.GetItem<MaintainVehAllowance>(oldRow).MarkClean();
            //}
            //else // its one of FIXED, ROI, ACTIVITY, TIME
            //{
            //    thisDw.GetItem<MaintainAllowance>(oldRow).EffectiveDate
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).InitialEffDate;
            //    thisDw.GetItem<MaintainAllowance>(oldRow).AnnualAmount
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).InitialAmount;
            //    thisDw.GetItem<MaintainAllowance>(oldRow).NetAmount
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).InitialNetAmount;
            //    thisDw.GetItem<MaintainAllowance>(oldRow).Approved
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).InitialApproved;
            //    thisDw.GetItem<MaintainAllowance>(oldRow).DocDescription
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).InitialDocDescr;
            //    thisDw.GetItem<MaintainAllowance>(oldRow).Notes
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).InitialNotes;
            //    thisDw.GetItem<MaintainAllowance>(oldRow).CaVar1
            //             = thisDw.GetItem<MaintainAllowance>(oldRow).InitialCaVar1;

            //    // Mark the old record "clean" so it doesn't trigger an update
            //    thisDw.GetItem<MaintainAllowance>(oldRow).RowChanged = "X";
            //    thisDw.GetItem<MaintainAllowance>(oldRow).MarkClean();

            //    //of_show_record(thisDw, dwType, oldRow, true, "Fix Old row");
            //    MessageBox.Show("New record isNew " + (thisDw.GetItem<MaintainAllowance>(newRow).IsNew).ToString()
            //                         + ", isDirty " + (thisDw.GetItem<MaintainAllowance>(newRow).IsDirty).ToString() + "\n"
            //                   + "Old record isNew " + (thisDw.GetItem<MaintainAllowance>(oldRow).IsNew).ToString()
            //                         + ", isDirty " + (thisDw.GetItem<MaintainAllowance>(oldRow).IsDirty).ToString()
            //                   , "of_add_new_record - Debugging");

            //}

            // Update the display
            thisDw.Refresh();

            return errmsg;
        }

        private void of_markAllClean(URdsDw thisDw, int dwType)
        {
            for (int nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                //if (dwType == DISTANCE)
                //    thisDw.GetItem<MaintainVehAllowance>(nRow).MarkClean();
                //else
                //    thisDw.GetItem<MaintainAllowance>(nRow).MarkClean();
                thisDw.GetItem<MaintainAllowanceV2>(nRow).MarkClean();
            }
        }

        private void of_markNewDirty(URdsDw thisDw, int dwType)
        {
            // Change the record state marking to Modified ("M") so that it will be updated
            // when being saved and not re-inserted.
            for (int nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                //if (dwType == DISTANCE
                //    && thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged == "N")
                //{
                //    thisDw.GetItem<MaintainVehAllowance>(nRow).MarkDirtyEntity();
                //    //thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged = "M";
                //}
                //else
                //    if (dwType != DISTANCE
                //        && thisDw.GetItem<MaintainAllowance>(nRow).RowChanged == "N")
                //    {
                //        thisDw.GetItem<MaintainAllowance>(nRow).MarkDirtyEntity();
                //      //  thisDw.GetItem<MaintainAllowance>(nRow).RowChanged = "M";
                //    }
                if(thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged == "N")
                    thisDw.GetItem<MaintainAllowanceV2>(nRow).MarkDirtyEntity();

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
            // Sets all rows in all tabs to readonly if the allowance has been paid (PaidTo date not null)
            for (int nRow = 0; nRow < idw_fixed_allowance.RowCount; nRow++)
            {
                //if ((idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).PaidToDate) == null)
                if ((idw_fixed_allowance.GetItem<MaintainAllowanceV2>(nRow).PaidToDate) == null)
                {
                    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridRowReadOnly(nRow, true);
                    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
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
                //if ((idw_roi_allowance.GetItem<MaintainAllowance>(nRow).PaidToDate) == null)
                if ((idw_roi_allowance.GetItem<MaintainAllowanceV2>(nRow).PaidToDate) == null)
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
                //if ((idw_activity_allowance.GetItem<MaintainAllowance>(nRow).PaidToDate) == null)
                if ((idw_activity_allowance.GetItem<MaintainAllowanceV2>(nRow).PaidToDate) == null)
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
                //if ((idw_time_allowance.GetItem<MaintainAllowance>(nRow).PaidToDate) == null)
                if ((idw_time_allowance.GetItem<MaintainAllowanceV2>(nRow).PaidToDate) == null)
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
                //if ((idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow).PaidToDate) == null)
                if ((idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).PaidToDate) == null)
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
                                       , string inAltDescription, string inRowChanged
                                       , URdsDw thisDw, int dwType, int thisRow
                                       , ref int inErrors, ref string inErrmsg)
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

            // Ensure an effective date has been specified
            if (inEffDate == null)
            {
                sRowError += inAltDescription + " - Please enter an effective date.\n";
                nRowErrors++;
            }
/*
            // If the effective date hasn't changed, don't need to check it further
            DateTime? initialEffDate;
            if( dwType == DISTANCE )
                initialEffDate = thisDw.GetItem<MaintainVehAllowance>(thisRow).InitialEffDate;
            else
                initialEffDate = thisDw.GetItem<MaintainAllowance>(thisRow).InitialEffDate;
            if (!(inEffDate == initialEffDate))
            {
*/
                // Check that we won't duplicate the effective date 
                // (leading to a database duplicate key error)
                DateTime dEffDate = (DateTime)inEffDate;
                DateTime dMaxDate = (DateTime)RDSDataService.GetAllowanceMaxEffectiveDate(inContract, inAltKey);
                if ((DateTime)inEffDate <= dMaxDate)
                {
                    sRowError += inAltDescription + " - The effective date must be greater than " 
                                 + dMaxDate.ToString("dd/MM/yyyy")+ ".\n";
                    nRowErrors++;
                }
                else
                {   // of_sanedate returning True means the date is either OK or acceptable
                    if (!(StaticVariables.gnv_app.of_sanedate(inEffDate.GetValueOrDefault()
                                                , inAltDescription + " effective date")))
                    {
                        nRowErrors++;
                    }
                }
/*
            }
*/
            if (inNotes == null || inNotes.Trim() == "")
            {
                sRowError += inAltDescription + " - Please enter a note.\n";
                nRowErrors++;
            }

            inErrors += nRowErrors;
            inErrmsg += sRowError;
        }

        public virtual string of_validate_fields(URdsDw thisDw, int dwType, int nRow
                        , out string column_name )
        {
            // Check that values are present in required fields
            int? ll_altkey;
            string sAltDescription;
            DateTime? ld_effdate;
            Decimal? ldc_amount;
            string sCaNotes;
            string ErrMsg;
            int nErrors;

            nErrors = 0;
            ErrMsg = "";
            column_name = "";
            
            // Get some data to check
            //if (dwType == DISTANCE)
            //{
            //    ll_altkey = thisDw.GetItem<MaintainVehAllowance>(nRow).AltKey;
            //    sAltDescription = thisDw.GetItem<MaintainVehAllowance>(nRow).AltDescription;
            //    ld_effdate = thisDw.GetItem<MaintainVehAllowance>(nRow).EffectiveDate;
            //    ldc_amount = thisDw.GetItem<MaintainVehAllowance>(nRow).AnnualAmount;
            //    sCaNotes = thisDw.GetItem<MaintainVehAllowance>(nRow).Notes;
            //}
            //else
            //{
            //    ll_altkey = thisDw.GetItem<MaintainAllowance>(nRow).AltKey;
            //    sAltDescription = thisDw.GetItem<MaintainAllowance>(nRow).AltDescription;
            //    ld_effdate = thisDw.GetItem<MaintainAllowance>(nRow).EffectiveDate;
            //    ldc_amount = thisDw.GetItem<MaintainAllowance>(nRow).AnnualAmount;
            //    sCaNotes = thisDw.GetItem<MaintainAllowance>(nRow).Notes;
            //}
            ll_altkey = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltKey;
            sAltDescription = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
            ld_effdate = thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
            ldc_amount = thisDw.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount;
            sCaNotes = thisDw.GetItem<MaintainAllowanceV2>(nRow).Notes;

            // First check some common things
            if (ldc_amount == null)
            {
                ErrMsg += sAltDescription + " - Please enter an amount.\n";
                nErrors++;
                column_name = "ca_annual_amount";
            }

            // Ensure an effective date has been specified
            if (ld_effdate == null)
            {
                ErrMsg += sAltDescription + " - Please enter an effective date.\n";
                nErrors++;
                column_name = "ca_effective_date";
            }

            if (sCaNotes == null || sCaNotes.Trim().Length == 0)
            {
                ErrMsg += sAltDescription + " - Please enter a note.\n";
                nErrors++;
                column_name = "ca_notes";
            }

            if( nErrors > 1 )
                column_name = "alt_key";  // for the row as a whole

            return ErrMsg;
        }

        public virtual bool of_validate_effdate(URdsDw thisDw, int dwType, int nRow
                                                , int? inAltKey, DateTime? inEffDate
                                                , out string ErrMsg)
        {
            // Check that the effective date is unique for this allowance type

            int? thisAltKey;
            DateTime? EffDate, initialEffDate;
            DateTime dEffDate, dInitialEffDate, dMaxDate, thisEffDate;
            string sAltDescription, sRowChanged;
            bool thisIsNew;

            ErrMsg = "";
            //if (dwType == DISTANCE)
            //{
            //    sAltDescription = thisDw.GetItem<MaintainVehAllowance>(nRow).AltDescription;
            //    initialEffDate = thisDw.GetItem<MaintainVehAllowance>(nRow).InitialEffDate;
            //    sRowChanged = thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged;
            //    thisIsNew = thisDw.GetItem<MaintainVehAllowance>(nRow).IsNew;
            //}
            //else
            //{
            //    sAltDescription = thisDw.GetItem<MaintainAllowance>(nRow).AltDescription;
            //    initialEffDate = thisDw.GetItem<MaintainAllowance>(nRow).InitialEffDate;
            //    sRowChanged = thisDw.GetItem<MaintainAllowance>(nRow).RowChanged;
            //    thisIsNew = thisDw.GetItem<MaintainAllowance>(nRow).IsNew;
            //}
            sAltDescription = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
            initialEffDate = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialEffDate;
            sRowChanged = thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged;
            thisIsNew = thisDw.GetItem<MaintainAllowanceV2>(nRow).IsNew;

            // Convert the dates to DateTime from DateTime?, so we don't run into trouble with nulls
            dEffDate = (DateTime)(inEffDate ?? DateTime.MinValue);
            dInitialEffDate = (DateTime)(initialEffDate ?? DateTime.MinValue);
            dMaxDate = (DateTime)RDSDataService.GetAllowanceMaxEffectiveDate(il_contract, inAltKey);
            bool b = thisIsNew;

            // Check that we won't duplicate the effective date if we're going to create a new record
            // (leading to a database duplicate key error)
            for (int i = 0; i < thisDw.RowCount; i++)
            {
                // If this is the row of the date we're checking, skip it.
                //if( i == nRow ) continue;

                //// Get some values we need below
                //if( dwType == DISTANCE )
                //{
                //    thisAltKey = thisDw.GetItem<MaintainVehAllowance>(i).AltKey;
                //    thisEffDate = (DateTime)thisDw.GetItem<MaintainVehAllowance>(i).EffectiveDate;
                //}
                //else
                //{
                //    thisAltKey = thisDw.GetItem<MaintainAllowance>(i).AltKey;
                //    thisEffDate = (DateTime)thisDw.GetItem<MaintainAllowance>(i).EffectiveDate;
                //}
                thisAltKey = thisDw.GetItem<MaintainAllowanceV2>(i).AltKey;
                thisEffDate = (DateTime)thisDw.GetItem<MaintainAllowanceV2>(i).EffectiveDate;

                // Skip if this record is for a different allowance type
                if( thisAltKey != inAltKey ) continue;

                // If this record's date matches the date we're checking, we've found a duplicate
                // Tell the user.
                if( thisEffDate == inEffDate )
                {
                    ErrMsg += sAltDescription + " - The effective date must be unique.";
                    return false;
                }
            }

            // If the user has changed the Annual Amount, the record will be marked Modified ("M")
            // meaning that a new record is to be created.  If the effective date hasn't been changed,
            // the new record will have a duplicated date which the other checks won't catch;
            // this test will.
            if (sRowChanged == "M" && dEffDate == dInitialEffDate)
            {
                ErrMsg += sAltDescription + " - Please enter a new effective date greater than "
                                          + dEffDate.ToString("dd/MM/yyyy");
                return false;
            }
/*
            // Check that the effective date is at least as recent as the most-recent
            // (this record may be the most-recent).
            if (dEffDate < dMaxDate)
            {
                ErrMsg += sAltDescription + " - The effective date must be greater than "
                             + dMaxDate.ToString("dd/MM/yyyy") + ".\n";
                return false;
            }

            // If the effective date hasn't changed, don't need to check it further at this stage.
            // (The user may just be changing the Notes or DocDescription).
            if (!(dEffDate == dInitialEffDate))
            {

               // of_sanedate returning True means the date is either OK or acceptable
                // NOTE: of_sanedate reports an error if found, and asks whether to 
                //       allow it, returning true if so, or false if not
                return StaticVariables.gnv_app.of_sanedate(EffDate.GetValueOrDefault()
                                         , sAltDescription + " Effective Date" );
            }
*/
            // Finally, check that the date is "sane"
            return StaticVariables.gnv_app.of_sanedate(inEffDate, sAltDescription + " Effective Date" );

            // If all else fails and there's a duplicate effective date when inserting
            // a new record, the insert will throw an error that is caught, and the user 
            // told about it.

            return true;
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
                    sRowChanged = idw_fixed_allowance.GetItem<MaintainAllowanceV2>(nRow).RowChanged;
                    // If sRowChanged is not one of C, N, M (Changed, New, Modified - value changed)
                    // no need to validate it.
                    if (sRowChanged == null || !(sRowChanged == "C" || sRowChanged == "N" || sRowChanged == "M"))
                        continue;

                    nRowErrors = 0;
                    ld_effdate = idw_fixed_allowance.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
                    ldc_amount = idw_fixed_allowance.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount;
                    ll_altkey = idw_fixed_allowance.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                    sAltDescription = idw_fixed_allowance.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
                    sCaNotes = idw_fixed_allowance.GetItem<MaintainAllowanceV2>(nRow).Notes;

                    wf_checkBasicErrors(il_contract, ll_altkey, ld_effdate, ldc_amount, sCaNotes
                                    , sAltDescription, sRowChanged
                                    , idw_fixed_allowance, FIXED, nRow
                                    , ref nRowErrors, ref is_errmsg);
                    
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
                    sRowChanged = idw_roi_allowance.GetItem<MaintainAllowanceV2>(nRow).RowChanged;
                    // If sRowChanged is not one of C, N, M (Changed, New, Modified - value changed)
                    // no need to validate it.
                    if (sRowChanged == null || !(sRowChanged == "C" || sRowChanged == "N" || sRowChanged == "M"))
                        continue;

                    nRowErrors = 0;
                    ld_effdate = idw_roi_allowance.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
                    ldc_amount = idw_roi_allowance.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount;
                    ll_altkey = idw_roi_allowance.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                    sAltDescription = idw_roi_allowance.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
                    sCaNotes = idw_roi_allowance.GetItem<MaintainAllowanceV2>(nRow).Notes;

                    wf_checkBasicErrors(il_contract, ll_altkey, ld_effdate, ldc_amount, sCaNotes
                                    , sAltDescription, sRowChanged
                                    , idw_roi_allowance, ROI, nRow
                                    , ref nRowErrors, ref is_errmsg);
                    
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
                    sRowChanged = idw_activity_allowance.GetItem<MaintainAllowanceV2>(nRow).RowChanged;
                    // If sRowChanged is not one of C, N, M (Changed, New, Modified - value changed)
                    // no need to validate it.
                    if (sRowChanged == null || !(sRowChanged == "C" || sRowChanged == "N" || sRowChanged == "M"))
                        continue;

                    nRowErrors = 0;
                    ld_effdate = idw_activity_allowance.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
                    ldc_amount = idw_activity_allowance.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount;
                    ll_altkey = idw_activity_allowance.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                    sAltDescription = idw_activity_allowance.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
                    sCaNotes = idw_activity_allowance.GetItem<MaintainAllowanceV2>(nRow).Notes;

                    wf_checkBasicErrors(il_contract, ll_altkey, ld_effdate, ldc_amount, sCaNotes
                                    , sAltDescription, sRowChanged
                                    , idw_activity_allowance, ACTIVITY, nRow
                                    , ref nRowErrors, ref is_errmsg);

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
                    sRowChanged = idw_time_allowance.GetItem<MaintainAllowanceV2>(nRow).RowChanged;
                    // If sRowChanged is not one of C, N, M (Changed, New, Modified - value changed)
                    // no need to validate it.
                    if (sRowChanged == null || !(sRowChanged == "C" || sRowChanged == "N" || sRowChanged == "M"))
                        continue;

                    nRowErrors = 0;
                    ld_effdate = idw_time_allowance.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
                    ldc_amount = idw_time_allowance.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount;
                    ll_altkey = idw_time_allowance.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                    sAltDescription = idw_time_allowance.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
                    sCaNotes = idw_time_allowance.GetItem<MaintainAllowanceV2>(nRow).Notes;

                    wf_checkBasicErrors(il_contract, ll_altkey, ld_effdate, ldc_amount, sCaNotes
                                    , sAltDescription, sRowChanged
                                    , idw_time_allowance, TIME, nRow
                                    , ref nRowErrors, ref is_errmsg);

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
                    sRowChanged = idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).RowChanged;
                    // If sRowChanged is not one of C, N, M (Changed, New, Modified - value changed)
                    // no need to validate it.
                    if (sRowChanged == null || !(sRowChanged == "C" || sRowChanged == "N" || sRowChanged == "M") )
                        continue;

                    nRowErrors = 0;
                    ld_effdate = idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
                    ldc_amount = idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount;
                    ll_altkey = idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                    sAltDescription = idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
                    sCaNotes = idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).Notes;

                    wf_checkBasicErrors(il_contract, ll_altkey, ld_effdate, ldc_amount, sCaNotes
                                    , sAltDescription, sRowChanged
                                    , idw_distance_allowance, DISTANCE, nRow
                                    , ref nRowErrors, ref is_errmsg);

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
                sApproved = dw_fixed_allowance.GetItem<MaintainAllowanceV2>(i).Approved;
                if (!(sApproved == null) && sApproved == "Y")
                {
                    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridCellReadonly(i,"ca_approved",true);
                    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
            }
            for (int i = 0; i < dw_roi_allowance.RowCount; i++)
            {
                sApproved = dw_roi_allowance.GetItem<MaintainAllowanceV2>(i).Approved;
                if (!(sApproved == null) && sApproved == "Y")
                {
                    ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).SetGridCellReadonly(i, "ca_approved", true);
                    ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
            }
            for (int i = 0; i < dw_activity_allowance.RowCount; i++)
            {
                sApproved = dw_activity_allowance.GetItem<MaintainAllowanceV2>(i).Approved;
                if (!(sApproved == null) && sApproved == "Y")
                {
                    ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).SetGridCellReadonly(i, "ca_approved", true);
                    ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
            }
            for (int i = 0; i < dw_time_allowance.RowCount; i++)
            {
                sApproved = dw_time_allowance.GetItem<MaintainAllowanceV2>(i).Approved;
                if (!(sApproved == null) && sApproved == "Y")
                {
                    ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).SetGridCellReadonly(i, "ca_approved", true);
                    ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
            }
            for (int i = 0; i < dw_distance_allowance.RowCount; i++)
            {
                sApproved = dw_distance_allowance.GetItem<MaintainAllowanceV2>(i).Approved;
                if (!(sApproved == null) && sApproved == "Y")
                {
                    ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).SetGridCellReadonly(i, "ca_approved", true);
                    ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
            }
        }

        #region Events

        private void of_show_record(URdsDw thisDw, int dwType, int nRow, bool bInitial, string msg)
        {
            int? altKey;
            string altDescription;
            DateTime? effDate;
            decimal? annualAmount;
            decimal? netAmount;

            if( ! bInitial )
            {
                //if( dwType == DISTANCE )
                //{
                //    altKey = thisDw.GetItem<MaintainVehAllowance>(nRow).AltKey;
                //    altDescription = thisDw.GetItem<MaintainVehAllowance>(nRow).AltDescription;
                //    effDate = thisDw.GetItem<MaintainVehAllowance>(nRow).EffectiveDate;
                //    annualAmount = thisDw.GetItem<MaintainVehAllowance>(nRow).AnnualAmount;
                //    netAmount = thisDw.GetItem<MaintainVehAllowance>(nRow).NetAmount;
                //}
                //else
                //{
                //    altKey = thisDw.GetItem<MaintainAllowance>(nRow).AltKey;
                //    altDescription = thisDw.GetItem<MaintainAllowance>(nRow).AltDescription;
                //    effDate = thisDw.GetItem<MaintainAllowance>(nRow).EffectiveDate;
                //    annualAmount = thisDw.GetItem<MaintainAllowance>(nRow).AnnualAmount;
                //    netAmount = thisDw.GetItem<MaintainAllowance>(nRow).NetAmount;
                //}
                altKey = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                altDescription = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
                effDate = thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
                annualAmount = thisDw.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount;
                netAmount = thisDw.GetItem<MaintainAllowanceV2>(nRow).NetAmount;
            }
            else
            {
                //if( dwType == DISTANCE )
                //{
                //    altKey = thisDw.GetItem<MaintainVehAllowance>(nRow).InitialAltKey;
                //    altDescription = thisDw.GetItem<MaintainVehAllowance>(nRow).InitialAltDescr;
                //    effDate = thisDw.GetItem<MaintainVehAllowance>(nRow).InitialEffDate;
                //    annualAmount = thisDw.GetItem<MaintainVehAllowance>(nRow).InitialAmount;
                //    netAmount = thisDw.GetItem<MaintainVehAllowance>(nRow).InitialNetAmount;
                //}
                //else
                //{
                //    altKey = thisDw.GetItem<MaintainAllowance>(nRow).InitialAltKey;
                //    altDescription = thisDw.GetItem<MaintainAllowance>(nRow).InitialAltDescr;
                //    effDate = thisDw.GetItem<MaintainAllowance>(nRow).InitialEffDate;
                //    annualAmount = thisDw.GetItem<MaintainAllowance>(nRow).InitialAmount;
                //    netAmount = thisDw.GetItem<MaintainAllowance>(nRow).InitialNetAmount;
                //}
                altKey = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialAltKey;
                altDescription = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialAltDescr;
                effDate = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialEffDate;
                annualAmount = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialAmount;
                netAmount = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialNetAmount;
            }
            string heading;
            if( bInitial )
                heading = "Initial values ";
            else
                heading = "Current values ";

            MessageBox.Show(heading + msg + "\n"
                          + "Row = " + nRow.ToString() + "\n"
                          + "AltKey = " + altKey.ToString() + "\n"
                          + "AltDescription = " + altDescription + "\n"
                          + "Effective_date = " + ((DateTime)effDate).ToString("dd/MM/yyyy") + "\n"
                          + "Annual_amount = " + ((decimal)annualAmount).ToString("##,##0.00") + "\n"
                          + "Net_amount = " + ((decimal)netAmount).ToString("##,##0.00")
                        , "Debugging");
        }

        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            bool result = of_save();
            if( result == false )
                // If there were errors, tell the user and exit without closing
                MessageBox.Show("Save failed        ", ""
                     ,MessageBoxButtons.OK, MessageBoxIcon.Warning);  
            //else 
            //    // If there were no errors, we close the window
            //    this.Close();
        }

        private bool is_eff_date_unique( URdsDw thisDw, int dwType, DateTime? inEffDate, int? inAltKey, int inRow )
        {
            // Check whether the effective date for this allowance type (AltKey) is unique in the DataControl
            // Returns true if it is unique, 
            //         false if not

            int thisRow;
            int? thisAltKey;
            DateTime? thisEffDate;

            // Scan the DW
            for( thisRow = 0; thisRow < thisDw.RowCount; thisRow++ )
            {
                // Skip the row containing the date we're checking (naturally it should match)
                if (thisRow != inRow)
                {
                    // Get the this row's effective date 
                    // (use GetValueOrDefault in case it's null (which it shouldn't be))
                    //if (dwType == DISTANCE)
                    //{
                    //    thisAltKey  = thisDw.GetItem<MaintainVehAllowance>(thisRow).AltKey;
                    //    thisEffDate = thisDw.GetItem<MaintainVehAllowance>(thisRow).EffectiveDate.GetValueOrDefault();
                    //}
                    //else
                    //{
                    //    thisAltKey = thisDw.GetItem<MaintainAllowance>(thisRow).AltKey;
                    //    thisEffDate = thisDw.GetItem<MaintainAllowance>(thisRow).EffectiveDate.GetValueOrDefault();
                    //}
                    thisAltKey = thisDw.GetItem<MaintainAllowanceV2>(thisRow).AltKey;
                    thisEffDate = thisDw.GetItem<MaintainAllowanceV2>(thisRow).EffectiveDate.GetValueOrDefault();

                    // If this record is the same allowance type check the date
                    if (thisAltKey == inAltKey)
                    {
                        // If this record matches the date we're checking, return false
                        if (thisEffDate == inEffDate)
                            return false;
                    }
                }
            }
            // If we get here, there was no match and the date is unique
            return true;
        }

        private void of_setselect(int dwType, int nRow, string sColumn)
        {
            if( dwType == FIXED )
                ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SelectGridCell(nRow, sColumn, true);
            else if( dwType == ROI )
                ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).SelectGridCell(nRow, sColumn, true);
            else if (dwType == ACTIVITY)
                ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).SetGridCellSelected(nRow, sColumn, true);
            else if (dwType == TIME)
                ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).SetGridCellSelected(nRow, sColumn, true);
            else if (dwType == DISTANCE)
                ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).SetGridCellSelected(nRow, sColumn, true);
        }

        private bool of_validate_records(URdsDw thisDw, int dwType)
        {
            int? thisAltKey;
            DateTime? thisEffDate;
            string sRowChanged, Approved;
            bool isNew;

            for (int nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                // Get some values we'll use below
                //if (dwType == DISTANCE)
                //{
                //    thisAltKey  = thisDw.GetItem<MaintainVehAllowance>(nRow).AltKey;
                //    thisEffDate = thisDw.GetItem<MaintainVehAllowance>(nRow).EffectiveDate;
                //    sRowChanged = (thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged) ?? "X";
                //    Approved    = (thisDw.GetItem<MaintainVehAllowance>(nRow).Approved) ?? "N";
                //    isNew       = thisDw.GetItem<MaintainVehAllowance>(nRow).IsNew;
                //}
                //else
                //{
                //    thisAltKey  = thisDw.GetItem<MaintainAllowance>(nRow).AltKey;
                //    thisEffDate = thisDw.GetItem<MaintainAllowance>(nRow).EffectiveDate;
                //    sRowChanged = (thisDw.GetItem<MaintainAllowance>(nRow).RowChanged) ?? "X";
                //    Approved    = (thisDw.GetItem<MaintainAllowance>(nRow).Approved) ?? "N";
                //    isNew       = thisDw.GetItem<MaintainAllowance>(nRow).IsNew;
                //}
                thisAltKey = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                thisEffDate = thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
                sRowChanged = (thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged) ?? "X";
                Approved = (thisDw.GetItem<MaintainAllowanceV2>(nRow).Approved) ?? "N";
                isNew = thisDw.GetItem<MaintainAllowanceV2>(nRow).IsNew;

                // Skip records that haven't been changed (New, Changed, Modified)
                if (sRowChanged != "N" && sRowChanged != "C" && sRowChanged != "M")
                    continue;

                // Check that values are present in required fields
                string errColumn = "alt_key";
                is_errmsg = of_validate_fields(thisDw, dwType, nRow, out errColumn);
                if (is_errmsg.Length != 0)
                {
                    of_setselect(dwType, nRow, errColumn);
                    MessageBox.Show(is_errmsg, "Allowance Validation Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                // Check that the effective date is unique if a new record is going
                // to be saved (avoiding a primary key (duplicate) error).
                // Note: One of the tests displays its own error message and doesn't return 
                //       it in is_errmsg. of_validate_effdate returns false in this case with 
                //       no error message to display.
                // Only validate the effective date if a new record will be created
                if( (sRowChanged == "M" && Approved == "Y") || isNew )
                {
                    if (!of_validate_effdate(thisDw, ROI, nRow, thisAltKey, thisEffDate, out is_errmsg))
                    {
                        if (is_errmsg.Length != 0)
                        {
                            of_setselect(dwType, nRow, "ca_effective_date");
                            MessageBox.Show(is_errmsg, "Allowance Validation Error"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        of_setselect(dwType, nRow, "ca_effective_date");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool of_insert_new_records(URdsDw thisDw, int dwType)
        {
            // Scan the DW inserting new records for any that have changed the net amount
            int nRow = 0, nRows = thisDw.RowCount;
            Decimal NetAmt, initialNetAmt;
            int? AltKey;
            DateTime? EffDate;
            string sRowChanged, Approved;
            bool result;

            for (nRow = 0; nRow < nRows; nRow++ )
            {
                //if (dwType == DISTANCE)
                //    sRowChanged = (thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged) ?? "X";
                //else
                //    sRowChanged = (thisDw.GetItem<MaintainAllowance>(nRow).RowChanged) ?? "X";
                sRowChanged = (thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged) ?? "X";

                if (sRowChanged != "N" && sRowChanged != "C" && sRowChanged != "M")
                    continue;

                // Check to see if the net amount has changed
                //if (dwType == DISTANCE)
                //{
                //    AltKey = thisDw.GetItem<MaintainVehAllowance>(nRow).AltKey;
                //    EffDate = thisDw.GetItem<MaintainVehAllowance>(nRow).EffectiveDate;
                //    Approved = thisDw.GetItem<MaintainVehAllowance>(nRow).Approved;
                //    NetAmt = (thisDw.GetItem<MaintainVehAllowance>(nRow).NetAmount) ?? 0.0M;
                //    initialNetAmt = (thisDw.GetItem<MaintainVehAllowance>(nRow).InitialNetAmount) ?? 0.0M;
                //}
                //else
                //{
                //    AltKey = thisDw.GetItem<MaintainAllowance>(nRow).AltKey;
                //    EffDate = thisDw.GetItem<MaintainAllowance>(nRow).EffectiveDate;
                //    Approved = thisDw.GetItem<MaintainAllowance>(nRow).Approved;
                //    NetAmt = (thisDw.GetItem<MaintainAllowance>(nRow).NetAmount) ?? 0.0M;
                //    initialNetAmt = (thisDw.GetItem<MaintainAllowance>(nRow).InitialNetAmount) ?? 0.0M;
                //}
                AltKey = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                EffDate = thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
                Approved = thisDw.GetItem<MaintainAllowanceV2>(nRow).Approved;
                NetAmt = (thisDw.GetItem<MaintainAllowanceV2>(nRow).NetAmount) ?? 0.0M;
                initialNetAmt = (thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialNetAmount) ?? 0.0M;
                if (NetAmt != initialNetAmt)
                {
                    // The Net amount has been changed.  
                    if (sRowChanged == "M" && Approved != "Y")
                    {
                        // If the row has been marked as Modified and it hasn't been marked Approved
                        // change its mark to Changed so it won't be inserted.
                        //if (dwType == DISTANCE)
                        //    thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged = "C";
                        //else
                        //    thisDw.GetItem<MaintainAllowance>(nRow).RowChanged = "C";
                        thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged = "C";
                    }

                    // See if this is a modified existing 
                    // record ("M") that has been approved. If so, this is a candidate for
                    // the creation of a new record.
                    if (sRowChanged == "M" && Approved == "Y")
                    {
                        // Although the effective date has been validated, that process hasn't 
                        // ensured that it is unique.  It needs to be unique or there will be 
                        // a primary key violation when creating the new record.
                        result = is_eff_date_unique(thisDw, dwType, EffDate, AltKey, nRow);
                        if (result == false)
                        {
                            of_setselect(dwType, nRow, "ca_effective_date");
                            // The new record was not added successfully
                            MessageBox.Show("The effective date is not unique; please enter a new date \n"
                                           , "Validation error"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return false;
                        }
                        else // the effdate is unique
                        {
                            // The effective date is unique; we can go ahead and create a new record with the changed details
                            string errmsg = of_add_new_record(thisDw, dwType, nRow);
                            if (errmsg != "")
                            { // If an error occurs at this point, its usually a primary Key error
                                // (non-unique effective date) but that has usually been caught in
                                // is_eff_date_unique() ... so this error 'shouldn't' happen
                                of_setselect(dwType, nRow, "ca_effective_date");
                                // The new record was not added successfully
                                MessageBox.Show("New record insert failed \n"
                                               + "Error = " + errmsg
                                               , "Save error"
                                               , MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return false;
                            }
                        }
                    }
                }

                // NOTE: if any new records are added, the RowCount will increase
                nRows = thisDw.RowCount;
            }
            return true;
        }

        private bool of_save_changes(URdsDw thisDw, int dwType)
        {
            string sRowChanged, SQLErrText, errmsg;
            int nRow, SQLCode;
            DateTime effdate;

            // Scan the list and save any changed records
            for (nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                //if( dwType == DISTANCE )
                //    sRowChanged = (thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged) ?? "X";
                //else
                //    sRowChanged = (thisDw.GetItem<MaintainAllowance>(nRow).RowChanged) ?? "X";
                sRowChanged = (thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged) ?? "X";

                if (!(sRowChanged == "N" || sRowChanged == "C" || sRowChanged == "M"))
                    continue;

                // Save the record as a clean one.
                //if (dwType == DISTANCE)
                //    thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged = "X";
                //else
                //    thisDw.GetItem<MaintainAllowance>(nRow).RowChanged = "X";
                thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged = "X";

                if (sRowChanged == "M")
                {
                    //if (dwType == DISTANCE)
                    //    thisDw.GetItem<MaintainVehAllowance>(nRow).MarkNewEntity();
                    //else
                    //    thisDw.GetItem<MaintainAllowance>(nRow).MarkNewEntity();
                    thisDw.GetItem<MaintainAllowanceV2>(nRow).MarkNewEntity();
                }

                thisDw.Save();

                //if (dwType == DISTANCE)
                //{
                //    SQLCode = thisDw.GetItem<MaintainVehAllowance>(nRow).SQLCode;
                //    SQLErrText = thisDw.GetItem<MaintainVehAllowance>(nRow).SQLErrText;
                //}
                //else
                //{
                //    SQLCode = thisDw.GetItem<MaintainAllowance>(nRow).SQLCode;
                //    SQLErrText = thisDw.GetItem<MaintainAllowance>(nRow).SQLErrText;
                //}
                SQLCode = thisDw.GetItem<MaintainAllowanceV2>(nRow).SQLCode;
                SQLErrText = thisDw.GetItem<MaintainAllowanceV2>(nRow).SQLErrText;

                if( SQLCode != 0 )
                {
                    if (SQLErrText.Contains("PRIMARY KEY"))
                    {
                        //if (dwType == DISTANCE)
                        //    effdate = (DateTime)thisDw.GetItem<MaintainVehAllowance>(nRow).EffectiveDate;
                        //else
                        //    effdate = (DateTime)thisDw.GetItem<MaintainAllowance>(nRow).EffectiveDate;
                        effdate = (DateTime)thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;

                        errmsg = "Please change the effective date to a date later than "
                                    + effdate.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        errmsg = "Error text: " + SQLErrText;
                    }
                    of_setselect(FIXED, nRow, "alt_key");
                    MessageBox.Show("Failed to update Allowance. \n\n"
                                   + errmsg, "Database Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    // NOTE: the Save could involve more than one change
                    // If the save failed, reset the RowChanged value so its current value is "remembered" if
                    // we manage to save the record later.
                    //if (dwType == DISTANCE)
                    //    thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged = sRowChanged;
                    //else
                    //    thisDw.GetItem<MaintainAllowance>(nRow).RowChanged = sRowChanged;
                    thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged = sRowChanged;

                    return false;
                }
            }
            return true;
        }

        public void of_list_records(URdsDw thisDw, int dwType)
        {   // This is for debugging: list all records (summary) in a tab's DW
            string msg = "";
            for (int i = 0; i < thisDw.RowCount; i++)
            {
                int? altKey = thisDw.GetItem<MaintainAllowanceV2>(i).AltKey;
                string altDescr = thisDw.GetItem<MaintainAllowanceV2>(i).AltDescription;
                string rowChanged = thisDw.GetItem<MaintainAllowanceV2>(i).RowChanged;
                DateTime effDate = (DateTime)thisDw.GetItem<MaintainAllowanceV2>(i).EffectiveDate;

                msg += "Row " + i.ToString() + ", "
                              + "AltKey = " + altKey.ToString() + ", "
                              + "Description = " + altDescr + ", "
                              + "Eff Date = " + effDate.ToString("dd/MM/yyyy") + ", "
                              + "RowChanged = " + rowChanged + "\n";
            }
            MessageBox.Show(msg, "Debugging");
        }


        public virtual bool of_save()
        {
            // Processes the records in all tabs, looking for changes.  Velidates
            // the records and inserts new ones and updates existing records that
            // have been changed.
            // Returns false if errors are detected, true otherwise

            cb_save.Focus();
            int nRow, ll_error;
            is_errmsg = "";
            bool bSaveOK = true;
            int nChanged, nDeleted;
            Decimal? dAmount = null;
            string sRowChanged;

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
            /*************************
             * Fixed Allowances
             * ***********************/
            nChanged = idw_fixed_allowance.ModifiedCount();
            nDeleted = (idw_fixed_allowance.DataObject).DeletedCount;
            // We can't rely on the user having focus on the changed row(s), 
            // so nRow = idw_fixed_allowance.GetRow() isn't useful.

            // If there are changed fixed allowance records ...
            if (nChanged > 0)
            {
                // Scan the list for changed records and validate any that are found
                if (of_validate_records(idw_fixed_allowance, FIXED) == false)
                {
                    return false;
                }

                // Now, scan the list again and insert new records for any that have 
                // changed the net amount
                if (of_insert_new_records(dw_fixed_allowance, FIXED) == false)
                {
                    return false;
                }

                // Now, scan the list again and save any changed records
                if (of_save_changes(dw_fixed_allowance, FIXED) == false)
                {
                    return false;
                }

/* [This is the "new" code, replaced with of_validate_records(), of_insert_new_records() and of_save_changes()]
                for (nRow = 0; nRow < dw_fixed_allowance.RowCount; nRow++)
                {
                    sRowChanged = ((MaintainAllowance)idw_fixed_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged ?? "X";
                    if (!(sRowChanged == "N" || sRowChanged == "C" || sRowChanged == "M"))
                        continue;

                    is_errmsg = of_validate_fields(dw_fixed_allowance, FIXED, nRow);

                    if (is_errmsg.Length != 0)
                    {
                        of_setselect(FIXED, nRow, "ca_effective_date");
                        //((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridCellSelected(nRow, "ca_effective_date", true);
                        MessageBox.Show(is_errmsg, "Fixed Allowance Validation Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (!of_validate_effdate(dw_fixed_allowance, FIXED, nRow, out is_errmsg))
                    {
                        if (is_errmsg.Length != 0)
                        {
                            of_setselect(FIXED, nRow, "ca_effective_date");
                            MessageBox.Show(is_errmsg, "Fixed Allowance Validation Error"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        of_setselect(FIXED, nRow, "ca_effective_date");
                        //((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridCellSelected(nRow, "ca_effective_date", true);
                        return false;
                    }
                }

                // Now, scan the list again and insert new records for any that have changed the net amount
                int nRows = dw_fixed_allowance.RowCount;
                Decimal NetAmt, initialNetAmt;
                for (nRow = 0; nRow < nRows; nRow++)
                {
                    sRowChanged = ((MaintainAllowance)idw_fixed_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged ?? "X";
                    if (!(sRowChanged == "N" || sRowChanged == "C" || sRowChanged == "M"))
                        continue;

                    // Check to see if the net amount has changed
                    NetAmt = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).NetAmount.GetValueOrDefault();
                    initialNetAmt = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).InitialNetAmount.GetValueOrDefault();
                    if (NetAmt != initialNetAmt)
                    {
                        // The Net amount has been changed.  See if this is a modified existing record ("M").
                        // If so, this is a candidate for the creation of a new record.
                        string RowChanged = (idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).RowChanged) ?? "X";
                        if (RowChanged == "M")
                        {
                            // Although the effective date has been validated, that process hasn't 
                            // ensured that it is unique.  It needs to be unique or there will be 
                            // a primary key violation when creating the new record.
                            int? AltKey = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).AltKey;
                            DateTime? EffDate = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).EffectiveDate;
                            if (is_eff_date_unique( idw_fixed_allowance, FIXED, EffDate, AltKey, nRow ))
                            {
                                // The effective date is unique; we can go ahead and create a new record with the changed details
                                //Decimal changeAmt;
                                //changeAmt = NetAmt - initialNetAmt;
                                string errmsg = of_add_new_record(idw_fixed_allowance, FIXED, nRow);
                                if ( errmsg != "")
                                {
                                    of_setselect(FIXED, nRow, "ca_effective_date");
                                    //((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridCellSelected(nRow, "alt_key", true);
                                    // The new record was not added successfully
                                    MessageBox.Show("New FIXED record insert failed \n"
                                                   + "Error = " + errmsg
                                                   , "Save error");

                                    return false;
                                }
                            }
                        }
                    }

                    // NOTE: if any new records are added, the rowcount will increase
                    nRows = dw_fixed_allowance.RowCount;
                }

                // Now, scan the list again and save any changed records
                for (nRow = 0; nRow < dw_fixed_allowance.RowCount; nRow++)
                {
                    sRowChanged = ((MaintainAllowance)idw_fixed_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged ?? "X";
                    if (!(sRowChanged == "N" || sRowChanged == "C" || sRowChanged == "M"))
                        continue;

                    // Save the record as a clean one.
                    ((MaintainAllowance)idw_fixed_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged = "X";
                    if (sRowChanged == "N")
                        ((MaintainAllowance)idw_fixed_allowance.GetItem<MaintainAllowance>(nRow)).MarkNewEntity();
                    idw_fixed_allowance.Save();
                    if (idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).SQLCode != 0)
                    {
                        string errmsg = idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).SQLErrText;
                        if (errmsg.Contains("PRIMARY KEY"))
                        {
                            DateTime errdate = (DateTime)idw_fixed_allowance.GetItem<MaintainAllowance>(nRow).EffectiveDate;
                            errmsg = "Please change the effective date to a date later than "
                                        + errdate.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            errmsg = "Error text: " + errmsg;
                        }
                        of_setselect(FIXED, nRow, "alt_key");
                        //((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridCellSelected(nRow, "alt_key", true);
                        MessageBox.Show("Failed to update ROI Allowance. \n\n"
                                       + errmsg, "Database Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        // NOTE: the Save could involve more than one change
                        // If the save failed, reset the RowChanged value so its current value is "remembered" if
                        // we manage to save the record later.
                        ((MaintainAllowance)idw_fixed_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged = sRowChanged;

                        return false;
                    }
                }
*/
                if( bSaveOK )
                    MessageBox.Show("Saved fixed allowance changes");
            }
            // If there are any records to delete, do so
            else if (nDeleted > 0)
            {
                idw_fixed_allowance.Save();
                //MessageBox.Show("Fixed allowance record deleted.");
            }

            /*******************************************************************
             * ROI Allowances
             *******************************************************************/
            nChanged = idw_roi_allowance.ModifiedCount();
            nDeleted = (idw_roi_allowance.DataObject).DeletedCount;
            // We can't rely on the user having focus on the changed row(s), 
            // so nRow = idw_roi_allowance.GetRow() isn't useful.

            if (nChanged > 0)
            {
                // Scan the list for changed records and validate any that are found
                if( of_validate_records(idw_roi_allowance, ROI) == false )
                {
                    return false;
                }

                // Now, scan the list again and insert new records for any that have changed the net amount
                if (of_insert_new_records(dw_roi_allowance, ROI) == false)
                {
                    return false;
                }

                // Now, scan the list again and save any changed records
                if (of_save_changes(dw_roi_allowance, ROI) == false)
                {
                    return false;
                }

/* [This is the "new" code, replaced with of_validate_records(), of_insert_new_records() and of_save_changes]
                for (nRow = 0; nRow < dw_roi_allowance.RowCount; nRow++)
                {
                    sRowChanged = ((MaintainAllowance)idw_roi_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged ?? "X";
                    if (!(sRowChanged == "N" || sRowChanged == "C" || sRowChanged == "M"))
                        continue;

                    is_errmsg = of_validate_fields(dw_roi_allowance, ROI, nRow);

                    if (is_errmsg.Length != 0)
                    {
                        of_setselect(ROI, nRow, "ca_effective_date");
                        //((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).SetGridCellSelected(nRow, "ca_effective_date", true);
                        MessageBox.Show(is_errmsg, "ROI Allowance Validation Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (!of_validate_effdate(dw_roi_allowance, ROI, nRow, out is_errmsg))
                    {
                        if (is_errmsg.Length != 0)
                        {
                            of_setselect(ROI, nRow, "ca_effective_date");
                            //((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).SetGridCellSelected(nRow, "ca_effective_date", true);
                            MessageBox.Show(is_errmsg, "ROI Allowance Validation Error"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        of_setselect(ROI, nRow, "ca_effective_date");
                        return false;
                    }
                }

                // Now, scan the list again and insert new records for any that have changed the net amount
                int nRows = dw_roi_allowance.RowCount;
                Decimal NetAmt, initialNetAmt;
                for (nRow = 0; nRow < nRows; nRow++)
                {
                    sRowChanged = ((MaintainAllowance)idw_roi_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged ?? "X";
                    if (!(sRowChanged == "N" || sRowChanged == "C" || sRowChanged == "M"))
                        continue;

                    // Check to see if the net amount has changed
                    NetAmt = idw_roi_allowance.GetItem<MaintainAllowance>(nRow).NetAmount.GetValueOrDefault();
                    initialNetAmt = idw_roi_allowance.GetItem<MaintainAllowance>(nRow).InitialNetAmount.GetValueOrDefault();
                    if (NetAmt != initialNetAmt)
                    {
                        // The Net amount has been changed.  See if this is a modified existing record ("M").
                        // If so, this is a candidate for the creation of a new record.
                        string RowChanged = (idw_roi_allowance.GetItem<MaintainAllowance>(nRow).RowChanged) ?? "X";
                        if (RowChanged == "M")
                        {
                            // Although the effective date has been validated, that process hasn't 
                            // ensured that it is unique.  It needs to be unique or there will be 
                            // a primary key violation when creating the new record.
                            int? AltKey = idw_roi_allowance.GetItem<MaintainAllowance>(nRow).AltKey;
                            DateTime? EffDate = dw_roi_allowance.GetItem<MaintainAllowance>(nRow).EffectiveDate;
                            if (is_eff_date_unique(dw_roi_allowance, ROI, EffDate, AltKey, nRow))
                            {
                                // The effective date is unique; we can go ahead and create a new record with the changed details
                                string errmsg = of_add_new_record(idw_roi_allowance, ROI, nRow);
                                if (errmsg != "")
                                {
                                    of_setselect(ROI, nRow, "alt_key");
                                    //((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).SetGridCellSelected(nRow, "alt_key", true);
                                    // The new record was not added successfully
                                    MessageBox.Show("New ROI record insert failed \n"
                                                   + "Error = " + errmsg
                                                   , "Save error");
                                    return false;
                                }
                            }
                        }
                    }
                    // NOTE: if any new records are added, the rowcount will increase
                    nRows = dw_roi_allowance.RowCount;
                }

                // Now, scan the list again and save any changed records
                for (nRow = 0; nRow < dw_roi_allowance.RowCount; nRow++)
                {
                    sRowChanged = ((MaintainAllowance)idw_roi_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged ?? "X";
                    if (!(sRowChanged == "N" || sRowChanged == "C" || sRowChanged == "M"))
                        continue;

                    // Save the record as a clean one.
                    ((MaintainAllowance)idw_roi_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged = "X";
                    if (sRowChanged == "N")
                        ((MaintainAllowance)idw_roi_allowance.GetItem<MaintainAllowance>(nRow)).MarkNewEntity();
                    idw_roi_allowance.Save();
                    if (idw_roi_allowance.GetItem<MaintainAllowance>(nRow).SQLCode != 0)
                    {
                        string errmsg = idw_roi_allowance.GetItem<MaintainAllowance>(nRow).SQLErrText;
                        if (errmsg.Contains("PRIMARY KEY"))
                        {
                            DateTime errdate = (DateTime)idw_roi_allowance.GetItem<MaintainAllowance>(nRow).EffectiveDate;
                            errmsg = "Please change the effective date to a date later than "
                                        + errdate.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            errmsg = "Error text: " + errmsg;
                        }
                        of_setselect(ROI, nRow, "alt_key");
                        //((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).SetGridCellSelected(nRow, "alt_key", true);
                        MessageBox.Show("Failed to update ROI Allowance. \n\n"
                                       + errmsg, "Database Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        // NOTE: the Save could involve more than one change
                        // If the save failed, reset the RowChanged value so its current value is "remembered" if
                        // we manage to save the record later.
                        ((MaintainAllowance)idw_roi_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged = sRowChanged;

                        //bSaveOK = false;
                         return false;
                    }
                }
*/
                if (bSaveOK)
                    MessageBox.Show("Saved ROI allowance changes");
            }
            // If there are any records to delete, do so
            else if (nDeleted > 0)
            {
                idw_roi_allowance.Save();
                MessageBox.Show("ROI Allowance record deleted");
            }

            /*******************************************************************
             * Activity Allowances
             *******************************************************************/
            nChanged = idw_activity_allowance.ModifiedCount();
            nDeleted = (idw_activity_allowance.DataObject).DeletedCount;

            // If there are changed fixed allowance records ...
            if (nChanged > 0)
            {
                // Scan the list for changed records and validate any that are found
                if (of_validate_records(idw_activity_allowance, ACTIVITY) == false)
                {
                    return false;
                }

                // Now, scan the list again and insert new records for any that have 
                // changed the net amount
                if (of_insert_new_records(dw_activity_allowance, ACTIVITY) == false)
                {
                    return false;
                }

                // Now, scan the list again and save any changed records
                if (of_save_changes(dw_activity_allowance, ACTIVITY) == false)
                {
                    return false;
                }

/* This is the older method
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
                    sRowChanged = ((MaintainAllowance)idw_activity_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged ?? "X";
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
 */
                if (bSaveOK)
                    MessageBox.Show("Saved ROI allowance changes");
            }
            // If there are any records to delete, do so
            else if (nDeleted > 0)
            {
                idw_activity_allowance.Save();
                MessageBox.Show("Activity Allowance record deleted");
            }

            /*******************************************************************
             * Time Allowances
             *******************************************************************/
            nChanged = idw_time_allowance.ModifiedCount();
            nDeleted = (idw_time_allowance.DataObject).DeletedCount;

            // If there are changed fixed allowance records ...
            if (nChanged > 0)
            {
                // Scan the list for changed records and validate any that are found
                if (of_validate_records(idw_activity_allowance, ACTIVITY) == false)
                {
                    return false;
                }

                // Now, scan the list again and insert new records for any that have 
                // changed the net amount
                if (of_insert_new_records(dw_activity_allowance, ACTIVITY) == false)
                {
                    return false;
                }

                // Now, scan the list again and save any changed records
                if (of_save_changes(dw_activity_allowance, ACTIVITY) == false)
                {
                    return false;
                }

/* This is the older method
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
                    sRowChanged = ((MaintainAllowance)idw_time_allowance.GetItem<MaintainAllowance>(nRow)).RowChanged ?? "X";
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
 */
                if (bSaveOK)
                    MessageBox.Show("Saved ROI allowance changes");
            }
            // If there are any records to delete, do so
            else if (nDeleted > 0)
            {
                idw_activity_allowance.Save();
                MessageBox.Show("Activity Allowance record deleted");
            }

            /*******************************************************************
             * Distance Allowances
             *******************************************************************/
            nChanged = idw_distance_allowance.ModifiedCount();
            nDeleted = (idw_distance_allowance.DataObject).DeletedCount;

            // If there are changed fixed allowance records ...
            if (nChanged > 0)
            {
                // Scan the list for changed records and validate any that are found
                if (of_validate_records(idw_activity_allowance, ACTIVITY) == false)
                {
                    return false;
                }

                // Now, scan the list again and insert new records for any that have 
                // changed the net amount
                if (of_insert_new_records(dw_activity_allowance, ACTIVITY) == false)
                {
                    return false;
                }

                // Now, scan the list again and save any changed records
                if (of_save_changes(dw_activity_allowance, ACTIVITY) == false)
                {
                    return false;
                }

/* This is the older method
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
                    sRowChanged = ((MaintainVehAllowance)idw_distance_allowance.GetItem<MaintainVehAllowance>(nRow)).RowChanged ?? "X";
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
 */
                if (bSaveOK)
                    MessageBox.Show("Saved ROI allowance changes");
            }
            // If there are any records to delete, do so
            else if (nDeleted > 0)
            {
                idw_activity_allowance.Save();
                MessageBox.Show("Activity Allowance record deleted");
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
                //if( dwType == DISTANCE
                //      && thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged == "N")
                //    return true;
                //else
                //if( dwType != DISTANCE
                //      && thisDw.GetItem<MaintainAllowance>(nRow).RowChanged == "N")
                //    return true;
                if( thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged == "N")
                return true;
            }
            return false;
        }

        private bool isDwRowComplete(URdsDw thisDw, int inRow, int dwType)
        {
            //if( dwType == DISTANCE )
            //{
            //    if (thisDw.GetItem<MaintainVehAllowance>(inRow).CaVar1 == null
            //        || thisDw.GetItem<MaintainVehAllowance>(inRow).CaHrsWk == null
            //        || thisDw.GetItem<MaintainVehAllowance>(inRow).CaDistDay == null
            //        || thisDw.GetItem<MaintainVehAllowance>(inRow).Notes == null
            //        || (string)thisDw.GetItem<MaintainVehAllowance>(inRow).Notes == "")
            //    {
            //        return false;
            //    }
            //}
            //else if( dwType != DISTANCE )
            //{
            //    if (thisDw.GetItem<MaintainAllowance>(inRow).CaVar1 == null
            //        || thisDw.GetItem<MaintainAllowance>(inRow).Notes == null
            //        || (string)thisDw.GetItem<MaintainAllowance>(inRow).Notes == "")
            //    {
            //        return false;
            //    }
            //}
            if (thisDw.GetItem<MaintainAllowanceV2>(inRow).CaVar1 == null
                || thisDw.GetItem<MaintainAllowanceV2>(inRow).Notes == null
                || (string)thisDw.GetItem<MaintainAllowanceV2>(inRow).Notes == "")
            {
                return false;
            }
            if (dwType == DISTANCE
                && (thisDw.GetItem<MaintainAllowanceV2>(inRow).CaHrsWk == null
                    || thisDw.GetItem<MaintainAllowanceV2>(inRow).CaDistDay == null))
            {
                return false;
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
                //if (dwType == DISTANCE
                //        && thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged == "N"
                //        && isDwRowComplete( thisDw, nRow, dwType ) == false )
                //{
                //    thisDw.DataObject.DeleteItemAt(nRow);
                //    rc = thisDw.Save();
                //    i = rc;
                //}
                //else 
                //if (dwType != DISTANCE
                //        && thisDw.GetItem<MaintainAllowance>(nRow).RowChanged == "N"
                //        && isDwRowComplete( thisDw, nRow, dwType ) == false )
                //{
                //    thisDw.DataObject.DeleteItemAt(nRow);
                //    rc = thisDw.Save();
                //    i = rc;
                //}
                if( thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged == "N"
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

            int nModified = 0, nDeleted;
            nModified = dw_fixed_allowance.ModifiedCount() + dw_roi_allowance.ModifiedCount()
                      + dw_activity_allowance.ModifiedCount() + dw_time_allowance.ModifiedCount() 
                      + dw_distance_allowance.ModifiedCount();
            nDeleted = (dw_fixed_allowance.DataObject).DeletedCount + (dw_roi_allowance.DataObject).DeletedCount
                      + (dw_activity_allowance.DataObject).DeletedCount + (dw_time_allowance.DataObject).DeletedCount
                      + (dw_distance_allowance.DataObject).DeletedCount;

//            if (isDwNewOrDirty(idw_fixed_allowance, FIXED)
//                || isDwNewOrDirty(idw_roi_allowance, ROI)
//                || isDwNewOrDirty(idw_activity_allowance, ACTIVITY)
//                || isDwNewOrDirty(idw_time_allowance, TIME)
//                || isDwNewOrDirty(idw_distance_allowance, DISTANCE)
//               )
            if( nModified > 0 || nDeleted > 0 )
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
                    if (isDwNew(idw_roi_allowance,ROI))
                        of_delete_new_row(idw_roi_allowance,ROI);
                    if (isDwNew(idw_activity_allowance,ACTIVITY))
                        of_delete_new_row(idw_activity_allowance,ACTIVITY);
                    if (isDwNew(idw_time_allowance,TIME))
                        of_delete_new_row(idw_time_allowance,TIME);
                    if (isDwNew(idw_distance_allowance,DISTANCE))
                        of_delete_new_row(idw_distance_allowance,DISTANCE);

                    of_mark_dw_clean(dw_fixed_allowance, FIXED);
                    of_mark_dw_clean(dw_roi_allowance, ROI);
                    of_mark_dw_clean(dw_activity_allowance, ACTIVITY);
                    of_mark_dw_clean(dw_time_allowance, TIME);
                    of_mark_dw_clean(dw_distance_allowance, DISTANCE);
                }
            }
            return true;
        }

        private void of_mark_dw_clean(URdsDw thisDw, int dwType)
        {
            if (thisDw.ModifiedCount() > 0 || (thisDw.DataObject).DeletedCount > 0)
            {
                //if (dwType == DISTANCE)
                //{
                //    for (int i = 0; i < thisDw.RowCount; i++)
                //        thisDw.GetItem<MaintainVehAllowance>(i).MarkClean();
                //}
                //else
                //{
                //    for (int i = 0; i < thisDw.RowCount; i++)
                //        thisDw.GetItem<MaintainAllowance>(i).MarkClean();
                //}
                for (int i = 0; i < thisDw.RowCount; i++)
                    thisDw.GetItem<MaintainAllowanceV2>(i).MarkClean();
            }
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
            string sAltDescription, dwName;
            DateTime? effectiveDate;
            string sEffDate;

            dwName = idw_Current.Name;
            nRow = idw_Current.DataObject.GetRow();
            sAltDescription = "null";
            
            bool isReadonly = false;
            if (dwName == "dw_fixed_allowance")
                isReadonly = ((DMaintainFixedAllowance)(idw_Current.DataObject)).GetGridRowReadOnly(nRow);
            else if (dwName == "dw_roi_allowance")
                isReadonly = ((DMaintainROIAllowance)(idw_Current.DataObject)).GetGridRowReadOnly(nRow);
            else if (dwName == "dw_activity_allowance")
                isReadonly = ((DMaintainActivityAllowance)(idw_Current.DataObject)).GetGridRowReadOnly(nRow);
            else if (dwName == "dw_time_allowance")
                isReadonly = ((DMaintainTimeAllowance)(idw_Current.DataObject)).GetGridRowReadOnly(nRow);
            
            sAltDescription = idw_Current.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
            effectiveDate = idw_Current.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;

            if (dwName == "dw_distance_allowance")
            {
                isReadonly = ((DMaintainDistanceAllowance)(idw_Current.DataObject)).GetGridRowReadOnly(nRow);
                //sAltDescription = idw_Current.GetItem<MaintainVehAllowance>(nRow).AltDescription;
                sAltDescription = idw_Current.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
            }
            if (effectiveDate == null)
                sEffDate = " not set";
            else
                sEffDate = ((DateTime)effectiveDate).ToString("dd/MM/yyyy");
            
            if (isReadonly)
            {
                MessageBox.Show("You do not have premission to delete this allowance");
            }
            else{
                DialogResult ans;
                ans = MessageBox.Show("Please confirm that you want to delete allowance \n"
                                    + "       " + sAltDescription 
                                    + " Effective " + sEffDate + "."
                                    , "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    idw_Current.DataObject.DeleteItemAt(nRow);
                    int result = idw_Current.Save();
                    string msg = "";
                    if (result != 1)
                        msg = " (Save returned " + result.ToString() + ")";
                    MessageBox.Show("Record deleted" + msg);

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
                if (idw_fixed_allowance.RowCount > 0)
                    idw_fixed_allowance.Refresh();
//                if ( dw_fixed_allowance.RowCount <= 0 )
//                    ((DMaintainFixedAllowance)dw_fixed_allowance.DataObject).Retrieve(il_contract, FIXED);
            }
            if (ToTabName == "roi")
            {
                idw_Current = idw_roi_allowance;
                if (idw_roi_allowance.RowCount > 0)
                    idw_roi_allowance.Refresh();
//                if (idw_roi_allowance.RowCount <= 0)
//                    ((DMaintainROIAllowance)idw_roi_allowance.DataObject).Retrieve(il_contract, ROI);
            }
            if (ToTabName == "activity")
            {
                idw_Current = idw_activity_allowance;
                if (idw_activity_allowance.RowCount > 0)
                    idw_activity_allowance.Refresh();
//                if (idw_activity_allowance.RowCount <= 0)
//                    ((DMaintainActivityAllowance)idw_activity_allowance.DataObject).Retrieve(il_contract, ACTIVITY);
            }
            if (ToTabName == "time")
            {
                idw_Current = idw_time_allowance;
                if (idw_time_allowance.RowCount > 0)
                    idw_time_allowance.Refresh();
//                if (idw_time_allowance.RowCount <= 0)
//                    ((DMaintainTimeAllowance)idw_time_allowance.DataObject).Retrieve(il_contract, TIME);
            }
            if (ToTabName == "distance")
            {
                idw_Current = idw_distance_allowance;
                if (idw_distance_allowance.RowCount > 0)
                    idw_distance_allowance.Refresh();
//                    ((DMaintainDistanceAllowance)idw_distance_allowance.DataObject).Retrieve(il_contract, DISTANCE);
            }
        }

        void dw_distance_allowance_DoubleClick(object sender, EventArgs e)
        {
            // From contract_allowances
            decimal days_wk = 0.0M;
            decimal hours_wk = 0.0M;
            decimal dist_day = 0.0M;
            string  costs_covered = "N";

            // From allowance_type
            decimal rate_hr = 0.0M;
            decimal weeks_yr = 0.0M;
            decimal ACC = 0.0M;

            // From vehicle_allowance_rates
            decimal carrier_pa = 0.0M;
            decimal repairs_pk = 0.0M;
            decimal licence_pa = 0.0M;
            decimal tyres_pk = 0.0M;
            decimal allowance_pk = 0.0M;
            decimal insurance_pa = 0.0M;
            decimal ror_pa = 0.0M;
            decimal fuel_use_pk = 0.0M;
            decimal fuel_rate = 0.0M;
            decimal ruc_rate_pk = 0.0M;

            // Intermediate calculated velues
            decimal HoursAmt = 0.0M;
            decimal DistAmt = 0.0M;
            decimal Dist_yr = 0.0M;
            decimal VehAmt = 0.0M;
            decimal YrAmount = 0.0M;
            decimal Dist_yr_k = 0.0M;
            decimal Dist_yr_100 = 0.0M;
            decimal Fuel_pk = 0.0M;
            decimal Ruc_pk = 0.0M;

            int nRow = idw_distance_allowance.GetRow();

            days_wk = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).CaVar1);
            hours_wk = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).CaHrsWk);
            weeks_yr = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).AltWksYr);
            rate_hr = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).AltRate);
            HoursAmt = (hours_wk * weeks_yr) * rate_hr;

            dist_day = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).CaDistDay);
            Dist_yr = dist_day * days_wk * weeks_yr;

            repairs_pk = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarRepairsPk);
            tyres_pk = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarTyresPk);
            allowance_pk = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarAllowancePk);
            fuel_use_pk = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarFuelUsePk);
            fuel_rate = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarFuelRate);
            ruc_rate_pk = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarRucRatePk);
            
            Dist_yr_k = Dist_yr / 1000.0M;
            Dist_yr_100 = Dist_yr / 100.0M;
            Fuel_pk   = (Dist_yr_100 * fuel_use_pk) * fuel_rate;
            Ruc_pk    = Dist_yr_k * ruc_rate_pk;
            DistAmt   = (Ruc_pk + Fuel_pk + repairs_pk + tyres_pk + allowance_pk) * Dist_yr_k;

            costs_covered = idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).CaCostsCovered;
            carrier_pa = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarCarrierPa);
            licence_pa = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarLicencePa);
            insurance_pa = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarInsurancePa);
            ror_pa = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarRorPa);
            VehAmt = (costs_covered == "N") ? (carrier_pa + licence_pa + insurance_pa + ror_pa) : 0.0M;

            YrAmount = HoursAmt + DistAmt + VehAmt;

            MessageBox.Show("Labour amount = (Hours/wk * Weeks/yr * Rate/Hr) = $" + HoursAmt.ToString("###,##0.00") + "\n"
                          + "  Hours/wk = " + hours_wk.ToString("##0.0") + ",  Weeks/yr = " + weeks_yr.ToString("##0.0")
                          + ",  Rate/hr = $" + rate_hr.ToString("##0.00") + "\n\n"
                          + "DistancePerYr = (Dist/day * Days/wk * Weeks/yr) = " + Dist_yr.ToString("###,##0.0") + "Km \n"
                          + "  Dist/day = "+dist_day.ToString("##0.0")+",  Days/wk = "+days_wk.ToString("##0.0") 
                          + ",  Weeks/yr = " + weeks_yr.ToString("##0.0")+"\n"
                          + "Fuel/K = (DistancePerYr/100 * fuel_use_p100) * Fuel_rate = $" + Fuel_pk.ToString("##,##0.00") + "\n"
                          + "  DistancePerYr/100 = " + Dist_yr_100.ToString("##,##0.0")
                          + ", Fuel_use_100k = " + fuel_use_pk.ToString("##0.00") + "ltr, Fuel_rate = $" + fuel_rate.ToString("##0.00") + "\n"
                          + "Ruc/K  = DistancePerYr * Ruc_rate = $" + Ruc_pk.ToString("##,##0.00") + "\n"
                          + "  DistancePerYr/1000 = " + Dist_yr_k.ToString("##,##0.0") + ", Ruc_rate = $" + ruc_rate_pk.ToString("##0.00") + "\n\n"
                          + "Distance amount = (DistancePerYr/1000) * (Fuel/K + RUC/K + Repairs/K + Tyres/K + Allowance/K) = $" + DistAmt.ToString("###,##0.00") + "\n"
                          + "  DistancePerYr/1000 = " + Dist_yr_k.ToString("##,##0.0") + "\n"
                          + "  Fuel/K = $" + Fuel_pk.ToString("#,##0.00") + ",  RUC/K = $" + Ruc_pk.ToString("#,##0.00")+ ",  Repairs/K = $" + repairs_pk.ToString("#,##0.00")
                          + ",  Tyres/K = $"+tyres_pk.ToString("#,##0.00") + ",  Allowance/K = $" + allowance_pk.ToString("##0.00") + "\n\n"
                          + "If Costs_covered = 'Y', Vehicle amount = $0.00 \n"
                          + "If Costs_covered = 'N', Vehicle amount = (Carrier/yr + Licence/yr + Insurance/yr + RoR/yr) \n"
                          + "Vehicle amount = $" + VehAmt.ToString("###,##0.00") + "\n"
                          + "  Costs_covered = '" + costs_covered + "'"
                          + ",  Carrier/yr = $"+carrier_pa.ToString("#,##0.00") + ",  Licence/yr = $"+licence_pa.ToString("#,##0.00")
                          + ",  Insurance/yr = $" + insurance_pa.ToString("#,##0.00") + ",  RoR/yr = $" + ror_pa.ToString("#,##0.00") + "\n\n"
                          + "Annual_amount = (Distance amount + Labour amount + Vehicle amount) = $" + YrAmount.ToString("##,##0.00") + "\n"
                          + "  Distance amount = $" + DistAmt.ToString("###,##0.00") + ", Labour amount = $" + HoursAmt.ToString("###,##0.00")
                          + ",  Vehicle amount = $" + VehAmt.ToString("###,##0.00") + "\n"
                          , "Distance-based calculation details"
                          , MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private decimal of_getDecimalValue(decimal? value)
        {
            decimal dValue;
            dValue = (value == null) ? 0.0M : (decimal)value;
            return dValue;
        }

        void dw_fixed_allowance_EditChanged(object sender, EventArgs e)
        {
            //of_ItemChanged(dw_fixed_allowance, FIXED);
        }

        void dw_fixed_allowance_ItemChanged(object sender, EventArgs e)
        {
            of_ItemChanged(dw_fixed_allowance, FIXED);
        }

        void dw_roi_allowance_ItemChanged(object sender, EventArgs e)
        {
            of_ItemChanged(dw_roi_allowance, ROI);
        }

        void dw_activity_allowance_ItemChanged(object sender, EventArgs e)
        {
            of_ItemChanged(dw_activity_allowance, ACTIVITY);
        }

        void dw_time_allowance_ItemChanged(object sender, EventArgs e)
        {
            of_ItemChanged(dw_time_allowance, TIME);
        }

        void dw_distance_allowance_ItemChanged(object sender, EventArgs e)
        {
            of_ItemChanged(dw_distance_allowance, DISTANCE);
        }

        Decimal of_GetPrevNetAmount(URdsDw thisDw, int? nAltKey, DateTime? dEffDate, int dwType)
        {
            // Get the Net Amount from the most-recent change record
            Decimal PrevNetAmount = 0.0M;
            DateTime effDate, maxEffDate;
            int altKey;

            // Scal thisDw looking for the most recent record of this allowance type
            maxEffDate = DateTime.MinValue;
            int nRows = thisDw.RowCount;
            for (int nRow = 0; nRow < nRows; nRow++)
            {
                // Get this record's allowance type and effective date
                //if (dwType == DISTANCE)
                //{
                //    altKey = (int)thisDw.GetItem<MaintainVehAllowance>(nRow).AltKey;
                //    effDate = (DateTime)thisDw.GetItem<MaintainVehAllowance>(nRow).EffectiveDate;
                //}
                //else
                //{
                //    altKey = (int)thisDw.GetItem<MaintainAllowance>(nRow).AltKey;
                //    effDate = (DateTime)thisDw.GetItem<MaintainAllowance>(nRow).EffectiveDate;
                //}
                altKey = (int)thisDw.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                effDate = (DateTime)thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;

                // If this is the right allowance type and not the changed record
                if( (altKey == (int)nAltKey) && (effDate < (DateTime)dEffDate) )
                {
                    // If its effective date is more recent that any we've seen so far ...
                    if (effDate > maxEffDate)
                    {
                        // Save the date as the most-recent
                        maxEffDate = effDate;
                        // and get the record's Net Amount
                        //if (dwType == DISTANCE)
                        //    PrevNetAmount = (Decimal)thisDw.GetItem<MaintainVehAllowance>(nRow).NetAmount;
                        //else
                        //    PrevNetAmount = (Decimal)thisDw.GetItem<MaintainAllowance>(nRow).NetAmount;
                        PrevNetAmount = (Decimal)thisDw.GetItem<MaintainAllowanceV2>(nRow).NetAmount;
                    }
                }
            }
            // Return the PrevNetAmount value.  If no other allowance records were found,
            // we'll return 0.0.
            return PrevNetAmount;
        }

        private string of_checkEffDate(int? inContract, int? inAltKey, DateTime? inEffDate )
        {
            string errmsg = "";
            
            if (inEffDate == null)
                errmsg = "Please enter an effective date.";
            else
            {
                DateTime dMaxDate = (DateTime)RDSDataService.GetAllowanceMaxEffectiveDate(inContract, inAltKey);
                if( (DateTime)inEffDate <= dMaxDate)
                    errmsg = "The effective date must be greater than " + dMaxDate.ToString("dd/MM/yyyy");
            }
            return errmsg;
        }

        int of_findChangedRow(URdsDw thisDw, int dwType)
        {
            // Find the changed row; we can't rely on the current focus being
            // on the row with the change.
            // Returns -1 if not found.
            string sRowChanged;
            for (int i = 0; i < thisDw.RowCount; i++)
            {
                //if (dwType == DISTANCE)
                //    sRowChanged = thisDw.GetItem<MaintainVehAllowance>(i).RowChanged;
                //else
                //    sRowChanged = thisDw.GetItem<MaintainAllowance>(i).RowChanged;
                sRowChanged = thisDw.GetItem<MaintainAllowanceV2>(i).RowChanged;

                if (sRowChanged == "M")
                    return i;
            }
            return -1;
        }
        void of_ItemChanged(URdsDw thisDw, int dwType)
        {
            // Implements ItemChanged actions for all tabs
            decimal dThisAmt = 0.0M;
            decimal dTotalAmt = 0.0M;
            int thisAltKey;
            bool thisDwIsNew = false;
            string thisRowChanged, thisApproved;
            decimal? thisAmt, netAmt, calcAmt;
            decimal prevNetAmt, newNetAmt, changeAmt;
            DateTime? thisEffDate;

            // Get the allowance key for the changed item
            // Can't rely on focus being on the changed row, so getRow() is unreliable.
            //int nRow = thisDw.GetRow();
            int nRow = of_findChangedRow(thisDw, dwType);
            if (nRow < 0) return;   // Exit if no changed row found

            //if (dwType == DISTANCE)
            //{
            //    thisAltKey    = (int)thisDw.GetItem<MaintainVehAllowance>(nRow).AltKey;
            //    thisEffDate = thisDw.GetItem<MaintainVehAllowance>(nRow).EffectiveDate;
            //    thisApproved = thisDw.GetItem<MaintainVehAllowance>(nRow).Approved; ;
            //    string errmsg = of_checkEffDate(il_contract, thisAltKey, thisEffDate);
            //    if (!(errmsg.Length == 0))
            //    {
            //        MessageBox.Show(errmsg + " - please correct", "Warning"
            //                       , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    thisRowChanged = thisDw.GetItem<MaintainVehAllowance>(nRow).RowChanged;
            //    thisDwIsNew = thisDw.GetItem<MaintainVehAllowance>(nRow).IsNew
            //                    || thisRowChanged == "N";
            //    thisAmt = thisDw.GetItem<MaintainVehAllowance>(nRow).AnnualAmount;
            //    calcAmt = thisDw.GetItem<MaintainVehAllowance>(nRow).CalcAmount;
            //    netAmt  = thisDw.GetItem<MaintainVehAllowance>(nRow).NetAmount;
            //    prevNetAmt = RDSDataService.GetAllowanceNetAmount(il_contract, thisAltKey);
            //    changeAmt = (decimal)(calcAmt ?? 0.0M) - prevNetAmt;
            //} 
            //else
            //{
            //    thisAltKey = (int)thisDw.GetItem<MaintainAllowance>(nRow).AltKey;
            //    thisEffDate = thisDw.GetItem<MaintainAllowance>(nRow).EffectiveDate;
            //    thisApproved = thisDw.GetItem<MaintainAllowance>(nRow).Approved; ;
            //    string errmsg = of_checkEffDate(il_contract, thisAltKey, thisEffDate);
            //    if( !(errmsg.Length == 0))
            //    {
            //        MessageBox.Show(errmsg + " - please correct", "Warning"
            //                       , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    thisRowChanged = thisDw.GetItem<MaintainAllowance>(nRow).RowChanged;
            //    thisDwIsNew = thisDw.GetItem<MaintainAllowance>(nRow).IsNew
            //                    || thisRowChanged == "N";
            //    thisAmt = thisDw.GetItem<MaintainAllowance>(nRow).AnnualAmount;
            //    calcAmt = thisDw.GetItem<MaintainAllowance>(nRow).CalcAmount;
            //    netAmt = thisDw.GetItem<MaintainAllowance>(nRow).NetAmount;
            //    prevNetAmt = RDSDataService.GetAllowanceNetAmount(il_contract, thisAltKey);
            //    if (dwType == FIXED)
            //    {
            //        //changeAmt = (decimal)(thisAmt ?? 0.0M);
            //        changeAmt = (decimal)(netAmt ?? 0.0M) - prevNetAmt;
            //    }
            //    else  // dwType = ROI, ACTIVITY or TIME
            //    {
            //        //changeAmt = (decimal)(calcAmt ?? 0.0M) - prevNetAmt;
            //        changeAmt = (decimal)(netAmt ?? 0.0M) - prevNetAmt;
            //    }
            //}
            thisAltKey = (int)thisDw.GetItem<MaintainAllowanceV2>(nRow).AltKey;
            thisEffDate = thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
            thisApproved = thisDw.GetItem<MaintainAllowanceV2>(nRow).Approved; ;
            string errmsg = of_checkEffDate(il_contract, thisAltKey, thisEffDate);
            if( !(errmsg.Length == 0))
            {
                MessageBox.Show(errmsg + " - please correct", "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            thisRowChanged = thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged;
            thisDwIsNew = thisDw.GetItem<MaintainAllowanceV2>(nRow).IsNew
                            || thisRowChanged == "N";
            thisAmt = thisDw.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount;
            calcAmt = thisDw.GetItem<MaintainAllowanceV2>(nRow).CalcAmount;
            netAmt = thisDw.GetItem<MaintainAllowanceV2>(nRow).NetAmount;
            prevNetAmt = RDSDataService.GetAllowanceNetAmount(il_contract, thisAltKey);
            if (dwType == FIXED)
            {
                //changeAmt = (decimal)(thisAmt ?? 0.0M);
                changeAmt = (decimal)(netAmt ?? 0.0M) - prevNetAmt;
            }
            else  // dwType = ROI, ACTIVITY or TIME
            {
                //changeAmt = (decimal)(calcAmt ?? 0.0M) - prevNetAmt;
                changeAmt = (decimal)(netAmt ?? 0.0M) - prevNetAmt;
            }
/*
            newNetAmt = prevNetAmt + changeAmt;
            MessageBox.Show("AltKey = " + thisAltKey.ToString()
                               + ", EffDate = " + ((DateTime)thisEffDate).ToString("dd/MM/yyyy")
                               + ", CalcId = " + dwType.ToString() + "\n"
                           + "thisApproved = " + thisApproved + "\n"
                           + "thisRowChanged = " + thisRowChanged
                               + ", IsNew = " + thisDwIsNew.ToString() + "\n"
                           + "thisAmt = $" + (thisAmt ?? 0.0M).ToString("###,##0.00") + "\n"
                           + "calcAmt = $" + (calcAmt ?? 0.0M).ToString("###,##0.00") + "\n"
                           + "netAmt = $"  + (netAmt ?? 0.0M).ToString("###,##0.00") + "\n"
                           + "prevNetAmt = $" + prevNetAmt.ToString("###,##0.00") + "\n"
                           + "\n"
                           + "ChangeAmt = $" + changeAmt.ToString("###,##0.00") + "\n"
                           + "newNetAmt = $" + newNetAmt.ToString("###,##0.00") + "\n"
                           , "of_ItemChanged - Debugging");
*/
            // If the record change has affected the annual_amount, see if we need
            // to add the change as a new record (to preserve history).  Only amount
            // changes need to be preserved  and only if approved.
            if( (!(changeAmt == 0.0M)) && thisApproved == "Y")
            {
                if (!thisDwIsNew)  // If we're changing an existing record (thisDwIsNew == false)
                {                  // insert the change as a new record
                    of_add_new_record(thisDw, dwType, nRow);
                }
/*
                if (dwType == DISTANCE)
                {
                    //thisDw.GetItem<MaintainVehAllowance>(nRow).AnnualAmount = changeAmt;
                    //thisDw.GetItem<MaintainVehAllowance>(nRow).NetAmount = prevNetAmt + changeAmt;
                }
                else if (dwType == FIXED)
                {
                    //thisDw.GetItem<MaintainAllowance>(nRow).NetAmount = prevNetAmt + changeAmt;
                }
                else  // dwType = ROI, ACTIVITY or TIME
                {
                    //thisDw.GetItem<MaintainAllowance>(nRow).AnnualAmount = changeAmt;
                    //thisDw.GetItem<MaintainAllowance>(nRow).NetAmount = prevNetAmt + changeAmt;
                }
*/
            }
/*
            // Calculate the new allowance total for this allowance type
            // Note: this updates the total for all rows of the same type
            //of_calc_allowance_type(thisDw, nAltKey, dwType, out dThisAmt);

            // Update the overall total
            of_calc_allowance_total(out dTotalAmt);
            this.Total.Text = dTotalAmt.ToString("###,###.00");
*/
            // Refresh the display to show all changes
            thisDw.Refresh();
            thisDw.SelectRow(nRow, true);

//            MessageBox.Show("Pause");
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
                //if (dwType == DISTANCE)
                //    nAltKey = (int)tab_dw.GetItem<MaintainVehAllowance>(nRow).AltKey;
                //else
                //    nAltKey = (int)tab_dw.GetItem<MaintainAllowance>(nRow).AltKey;
                nAltKey = (int)tab_dw.GetItem<MaintainAllowanceV2>(nRow).AltKey;

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
                //if (dwType == DISTANCE)
                //{
                //    dThisAmt = tab_dw.GetItem<MaintainVehAllowance>(nRow).AnnualAmount;
                //    thisAltKey = (int)tab_dw.GetItem<MaintainVehAllowance>(nRow).AltKey;
                //}
                //else
                //{
                //    dThisAmt = tab_dw.GetItem<MaintainAllowance>(nRow).AnnualAmount;
                //    thisAltKey = (int)tab_dw.GetItem<MaintainAllowance>(nRow).AltKey;
                //}
                dThisAmt = tab_dw.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount;
                thisAltKey = (int)tab_dw.GetItem<MaintainAllowanceV2>(nRow).AltKey;

                if (thisAltKey == inAltKey)
                {
                    if (dThisAmt != null)
                        dTotalAmt += (decimal)dThisAmt;
                }
            }

            // Update the allowance types' totals for each row of that type
            for (nRow = 0; nRow < tab_dw.RowCount; nRow++)
            {
                //if (dwType == DISTANCE)
                //{
                //    thisAltKey = (int)tab_dw.GetItem<MaintainVehAllowance>(nRow).AltKey;
                //    if (thisAltKey == inAltKey)
                //        tab_dw.GetItem<MaintainVehAllowance>(nRow).NetAmount = dTotalAmt;
                //}
                //else
                //{
                //    thisAltKey = (int)tab_dw.GetItem<MaintainAllowance>(nRow).AltKey;
                //    if (thisAltKey == inAltKey)
                //        tab_dw.GetItem<MaintainAllowance>(nRow).NetAmount = dTotalAmt;
                //}
                thisAltKey = (int)tab_dw.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                if (thisAltKey == inAltKey)
                    tab_dw.GetItem<MaintainAllowanceV2>(nRow).NetAmount = dTotalAmt;
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
                //if( dwType == DISTANCE)
                //    dThisAmt = tab_dw.GetItem<MaintainVehAllowance>(nRow).AnnualAmount;
                //else
                //    dThisAmt = tab_dw.GetItem<MaintainAllowance>(nRow).AnnualAmount;
                dThisAmt = tab_dw.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount;

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
