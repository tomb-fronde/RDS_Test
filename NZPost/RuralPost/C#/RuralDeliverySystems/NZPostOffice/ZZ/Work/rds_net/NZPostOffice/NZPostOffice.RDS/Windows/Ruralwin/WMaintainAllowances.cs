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
    // [8-June-2021] Added 'Terminate' button: 
    // [23-Jun-2021] Refine effective date checking
    // [29-June-2021] Fixed issue with DISTANCE records Approved readonly setting (with a hack)
    // [8-Jul-2021] Added pop-up message when reinstating a terminated allowance

    public class WMaintainAllowances : WAncestorWindow
    {
        #region Define
        public int il_contract, il_contract_seq;
        public int? il_altKey, il_alctId;
        public DateTime idt_effDate = DateTime.MinValue;
        public string isOptype = "";
        public int oldTabIndex = -1;
        private int newRow, oldRow;

        // Define values for the different calculation types
        public readonly int FIXED = RDSDataService.LookupAllowanceCalcType("Fixed");
        public readonly int ROI = RDSDataService.LookupAllowanceCalcType("Return ");
        public readonly int ACTIVITY = RDSDataService.LookupAllowanceCalcType("Activity");
        public readonly int TIME = RDSDataService.LookupAllowanceCalcType("Time");
        public readonly int DISTANCE = RDSDataService.LookupAllowanceCalcType("Distance");

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
        private TextBox Total_approved;
        private Label label1;
        private Button cb_terminate;

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
            //dw_activity_allowance.ItemChanged += new EventHandler(dw_activity_allowance_ItemChanged);
            idw_activity_allowance = dw_activity_allowance;

            this.dw_time_allowance.DataObject = new DMaintainTimeAllowance();
            dw_time_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_time_allowance.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_time_allowance_constructor);
            //dw_time_allowance.ItemChanged += new EventHandler(dw_time_allowance_ItemChanged);
            idw_time_allowance = dw_time_allowance;

            this.dw_distance_allowance.DataObject = new DMaintainDistanceAllowance();
            dw_distance_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_distance_allowance.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_distance_allowance_constructor);
            //dw_distance_allowance.ItemChanged += new EventHandler(dw_distance_allowance_ItemChanged);
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
            this.Total_approved = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_terminate = new System.Windows.Forms.Button();
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
            this.st_label.Location = new System.Drawing.Point(2, 326);
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
            this.dw_roi_allowance.Size = new System.Drawing.Size(980, 266);
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
            this.dw_activity_allowance.Size = new System.Drawing.Size(979, 266);
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
            this.dw_time_allowance.Size = new System.Drawing.Size(979, 266);
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
            this.dw_distance_allowance.Size = new System.Drawing.Size(979, 266);
            this.dw_distance_allowance.TabIndex = 1;
            // 
            // cb_save
            // 
            this.cb_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_save.Location = new System.Drawing.Point(614, 317);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(75, 23);
            this.cb_save.TabIndex = 2;
            this.cb_save.Text = "Save";
            this.cb_save.Click += new System.EventHandler(this.cb_save_clicked);
            // 
            // cb_cancel
            // 
            this.cb_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_cancel.Location = new System.Drawing.Point(695, 317);
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
            this.tabPage2.Size = new System.Drawing.Size(989, 278);
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
            this.tabPage3.Size = new System.Drawing.Size(989, 278);
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
            this.tabPage4.Size = new System.Drawing.Size(989, 278);
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
            this.tabPage5.Size = new System.Drawing.Size(989, 278);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Distance";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // cb_delete
            // 
            this.cb_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_delete.Location = new System.Drawing.Point(533, 317);
            this.cb_delete.Name = "cb_delete";
            this.cb_delete.Size = new System.Drawing.Size(75, 23);
            this.cb_delete.TabIndex = 5;
            this.cb_delete.Text = "Delete";
            this.cb_delete.UseVisualStyleBackColor = true;
            this.cb_delete.Click += new System.EventHandler(this.cb_delete_Click);
            // 
            // Total
            // 
            this.Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Total.BackColor = System.Drawing.SystemColors.Control;
            this.Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Total.Location = new System.Drawing.Point(217, 318);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(100, 20);
            this.Total.TabIndex = 0;
            // 
            // Total_t
            // 
            this.Total_t.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Total_t.AutoSize = true;
            this.Total_t.Location = new System.Drawing.Point(126, 323);
            this.Total_t.Name = "Total_t";
            this.Total_t.Size = new System.Drawing.Size(87, 13);
            this.Total_t.TabIndex = 0;
            this.Total_t.Text = "Total allowances";
            // 
            // Total_approved
            // 
            this.Total_approved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Total_approved.BackColor = System.Drawing.SystemColors.Control;
            this.Total_approved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Total_approved.Location = new System.Drawing.Point(418, 317);
            this.Total_approved.Name = "Total_approved";
            this.Total_approved.Size = new System.Drawing.Size(100, 20);
            this.Total_approved.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total approved";
            // 
            // cb_terminate
            // 
            this.cb_terminate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_terminate.Location = new System.Drawing.Point(811, 316);
            this.cb_terminate.Name = "cb_terminate";
            this.cb_terminate.Size = new System.Drawing.Size(115, 23);
            this.cb_terminate.TabIndex = 0;
            this.cb_terminate.Text = "Terminate allowance";
            this.cb_terminate.UseVisualStyleBackColor = true;
            this.cb_terminate.Click += new System.EventHandler(this.cb_terminate_Click);
            // 
            // WMaintainAllowances
            // 
            this.AcceptButton = this.cb_save;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1009, 344);
            this.Controls.Add(this.cb_terminate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Total_approved);
            this.Controls.Add(this.Total_t);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.cb_save);
            this.Controls.Add(this.cb_delete);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cb_cancel);
            this.Location = new System.Drawing.Point(46, 55);
            this.Name = "WMaintainAllowances";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Maintain Contract Allowances";
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.cb_delete, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.Controls.SetChildIndex(this.cb_save, 0);
            this.Controls.SetChildIndex(this.Total, 0);
            this.Controls.SetChildIndex(this.Total_t, 0);
            this.Controls.SetChildIndex(this.Total_approved, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cb_terminate, 0);
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
            idt_effDate = (DateTime)(lvn_Criteria.of_getcriteria("effective_date") ?? DateTime.MinValue);
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
                // Find the newly-added record.  It will be the most-recent record of its allowance type,
                // but not necessarily the first of the displayed records (at row 0) since the records
                // will have been sorted into description order.
                newRow = of_find_inserted(idw_Current, il_altKey, idt_effDate);
                if (newRow < 0)
                {
                    MessageBox.Show("?? Inserted allowance not found ??");
                }
                else
                {
                    // We then add the current net amount into the record.  
                    // This is used in the DataControl to calculate the change 
                    // amount (ca_annual_amount)

                    decimal? netAmt = RDSDataService.GetAllowanceNetAmount(il_contract, il_altKey);
                    idw_Current.GetItem<MaintainAllowanceV2>(newRow).NetAmount = netAmt;
                    of_setCellFocus((int)il_alctId, newRow, "ca_effective_date");
                }
            }
            else
            {
                int thisRow = of_find_inserted(idw_Current, il_altKey, idt_effDate);
                if( thisRow >= 0 )
                    of_setCellFocus((int)il_alctId, thisRow, "alt_key");
                    //of_setCellFocus((int)il_alctId, thisRow, "ca_effective_date");
            }
            // Check whether the user has permission to approve allowances, and
            // set the ca_approved column readonly if not.
            set_approvability();

            // Updating the allowance totals has marked all allowances "dirty"
            // Mark them "Clean" to avoid being asked about saving changes
            of_markAllClean(dw_distance_allowance, DISTANCE);
            of_markAllClean(dw_fixed_allowance, FIXED);
            of_markAllClean(dw_roi_allowance, ROI);
            of_markAllClean(dw_activity_allowance, ACTIVITY);
            of_markAllClean(dw_time_allowance, TIME);

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

            decimal dTotalAmt;
            decimal dTotalApproved;
            of_calc_allowance_total(out dTotalAmt, out dTotalApproved);

            // Display the totals
            this.Total.Text = dTotalAmt.ToString("###,###.00");
            this.Total_approved.Text = dTotalApproved.ToString("###,###.00");

            //of_set_row_readonly();
        }

        private int of_find_inserted(URdsDw thisDw, int? inAltKey, DateTime? inEffDate)
        {
            // Returns the row number of the added record or -1 if not found.
            
            int? thisAltKey;
            DateTime? thisEffDate;

            for (int nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                thisAltKey = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                if (thisAltKey != inAltKey)
                    continue;

                thisEffDate = (thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate ?? DateTime.MinValue);
                if (thisEffDate == inEffDate)
                    return nRow;
            }
            // If we didn't find the record with the right effective date
            // return the first record of the allowance type
            for (int nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                thisAltKey = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                if (thisAltKey != inAltKey)
                    continue;
                return nRow;
            }
            // If we didn't find the right allowance, return an error
            return -1;
        }

        private string of_add_new_record(URdsDw thisDw, int inRow, int dwType)
        {
            // If the user makes a change to a record (at oldRow), create a copy of 
            // that record (at row nRow).  The old record will become the history record.
            // Also needed so that the old record remains as its annual_amount 
            // contributes to the allowance totals as changes are made.
            //
            // Returns an empty string if successful, or an error message if not

            Decimal? tmpAmount = 0.0M;  // for debugging
            string errmsg = "";
            int? contractNo = thisDw.GetItem<MaintainAllowanceV2>(inRow).ContractNo;

            newRow = inRow;
            // Create the new row in the relevant tab/DW
            // Do everything in a try block so we can catch any errors that might occur
            try
            {
                thisDw.DataObject.InsertItem<MaintainAllowanceV2>(newRow, new MaintainAllowanceV2());
                thisDw.GetItem<MaintainAllowanceV2>(newRow).ContractNo = contractNo;
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
            thisDw.GetItem<MaintainAllowanceV2>(oldRow).RowChanged = "Y";
            thisDw.GetItem<MaintainAllowanceV2>(oldRow).MarkClean();
            of_set_this_row_readonly(thisDw, oldRow, true);


            // Update the display
            of_setCellFocus(dwType, newRow, "alt_key");
            //of_setselect(dwType, newRow, "alt_key");
            thisDw.Refresh();

            return errmsg;
        }

        private void of_markAllClean(URdsDw thisDw, int dwType)
        {
            for (int nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                thisDw.GetItem<MaintainAllowanceV2>(nRow).MarkClean();
            }
        }

        private void of_markNewDirty(URdsDw thisDw, int dwType)
        {
            // Change the record state marking to Modified ("M") so that it will be updated
            // when being saved and not re-inserted.
            for (int nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
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

        private void of_set_this_row_readonly(URdsDw thisdw, int thisRow, bool thisOnOff)
        {   // Sets a single row's readonly state and highlightling on or off

            int thisDwType = of_getDwType(thisdw);

            if (thisDwType == FIXED)
            {
                //((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridRowReadOnly(thisRow, thisOnOff);
                ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).set_row_readonly(thisRow, thisOnOff);
            }
            else if (thisDwType == ROI)
            {
                //((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).SetGridRowReadOnly(thisRow, thisOnOff);
                ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).set_row_readonly(thisRow, thisOnOff);
            }
            else if (thisDwType == ACTIVITY)
            {
                //((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).SetGridRowReadOnly(thisRow, thisOnOff);
                ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).set_row_readonly(thisRow, thisOnOff);
            }
            else if (thisDwType == TIME)
            {
                //((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).SetGridRowReadOnly(thisRow, thisOnOff);
                ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).set_row_readonly(thisRow, thisOnOff);
            }
            else if (thisDwType == DISTANCE)
            {
                //((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).SetGridRowReadOnly(thisRow, thisOnOff);
                ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).set_row_readonly(thisRow, thisOnOff);
            }
        }

        private void of_set_allowance_readonly(URdsDw thisDw)
        {   // Sets the most-recent allowance type readwrite and the others in the type read only
            // Applies to a single allowance calc type (tab page)

            int prevAltKey, thisAltKey;

            prevAltKey = -1;
            for (int nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                thisAltKey = (int)(thisDw.GetItem<MaintainAllowanceV2>(nRow).AltKey ?? -1);
                if (thisAltKey == prevAltKey)
                {
                    of_set_this_row_readonly(thisDw, nRow, true);
                }
                else
                {
                    of_set_this_row_readonly(thisDw, nRow, false);
                }
                prevAltKey = thisAltKey;
            }
        }

        public override void close()
        {
            //  Tell the parent to refresh
            ((WContract2001)StaticVariables.window).idw_allowances.Reset();
            ((WContract2001)StaticVariables.window).idw_allowances.Retrieve(new object[] { il_contract });
            StaticVariables.window = null;
        }

        public virtual string of_validate_fields(URdsDw thisDw, int dwType, int nRow
                        , out string err_column )
        {
            // Check that values are present in required fields
            string sAltDescription, sCaNotes;
            DateTime? ld_effdate;
            int nErrors = 0;
            string ErrMsg = "";

            sAltDescription = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
            err_column = "";

            // Ensure an effective date has been specified
            // (We do more detailed validation in of_validate_effdate)
            ld_effdate = thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
            if (ld_effdate == null)
            {
                nErrors++;
                ErrMsg += sAltDescription + " - Please enter an effective date.\n";
                err_column = "ca_effective_date";
            }

            sCaNotes = thisDw.GetItem<MaintainAllowanceV2>(nRow).Notes;
            if (sCaNotes == null || sCaNotes.Trim().Length == 0)
            {
                nErrors++;
                ErrMsg += sAltDescription + " - Please enter a note.\n";
                err_column = "ca_notes";
            }
            if( thisDw.GetItem<MaintainAllowanceV2>(nRow).CaVar1 == null )
            {
                string errtype = "";
                if (dwType == FIXED) errtype = "the total amount";
                else if(dwType == ROI) errtype = "an investment amount";
                else if(dwType == ACTIVITY) errtype = "a count per week";
                else if(dwType == TIME)     errtype = "an hours per week";
                else if(dwType == DISTANCE) errtype = "a days per year";

                nErrors++;
                ErrMsg += sAltDescription + " - Please enter " + errtype + " value.\n";
                err_column = "ca_var1";
            }

            if (dwType == DISTANCE)
            {
                if (thisDw.GetItem<MaintainAllowanceV2>(nRow).CaHrsWk == null)
                {
                    nErrors++;
                    ErrMsg += sAltDescription + " - Please enter an hours per week value.\n";
                    err_column = "ca_hrs_wk";
                }
                if (thisDw.GetItem<MaintainAllowanceV2>(nRow).CaDistDay == null)
                {
                    nErrors++;
                    ErrMsg += sAltDescription + " - Please enter an distance per day value.\n";
                    err_column = "ca_dist_day";
                }
            }
            if (nErrors > 1)
                err_column = "alt_key";  // for the row as a whole

            return ErrMsg;
        }

        private DateTime of_GetMaxEffectiveDate(URdsDw thisDw, int inContract, int inAltKey)
        {
            // Get the maximum effective date of the paid allowances of the type (inAltKey)
            int thisAltKey;
            DateTime? thisPaidDate, dMaxDate, thisEffDate;

            // Scan the rows in thisDw (which contains a single allowance type)
            dMaxDate = DateTime.MinValue;
            for (int nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                // Skip this row if it isn't the same type
                thisAltKey = (int)(thisDw.GetItem<MaintainAllowanceV2>(nRow).AltKey ?? -1);
                if (thisAltKey != inAltKey)
                    continue;

                // Skip this row if it isn't paid
                thisPaidDate = (DateTime?)thisDw.GetItem<MaintainAllowanceV2>(nRow).PaidToDate;
                if (thisPaidDate == null)
                    continue;

                // If this row's effective date is greater than the saved one, save it
                thisEffDate = (DateTime?)(thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate ?? DateTime.MinValue);
                if (thisEffDate > dMaxDate)
                    dMaxDate = thisEffDate;
            }
            return (DateTime)dMaxDate;
        }

        public virtual int of_validate_effdate(URdsDw thisDw, int dwType, int inRow
                                                , int? inAltKey, DateTime? inEffDate)
        {
            // Check that the effective date is unique for this allowance type
            // Return
            //    0    OK
            //    1    Error, no message
            //   -1    Error message displayed

            DateTime? thisPaidDate, initialEffDate;
            DateTime dEffDate, dInitialEffDate, dMaxDate;
            string sAltDescription, sRowChanged;
            bool thisIsNew;

            sAltDescription = thisDw.GetItem<MaintainAllowanceV2>(inRow).AltDescription;
            initialEffDate = thisDw.GetItem<MaintainAllowanceV2>(inRow).InitialEffDate;
            sRowChanged = thisDw.GetItem<MaintainAllowanceV2>(inRow).RowChanged;
            thisIsNew = thisDw.GetItem<MaintainAllowanceV2>(inRow).IsNew;

            // Convert the dates to DateTime from DateTime?, so we don't run into trouble with nulls
            dEffDate = (DateTime)(inEffDate ?? DateTime.MinValue);
            dInitialEffDate = (DateTime)(initialEffDate ?? DateTime.MinValue);
            dMaxDate = (DateTime)of_GetMaxEffectiveDate(thisDw, il_contract, (int)inAltKey);
            thisPaidDate = (DateTime?)thisDw.GetItem<MaintainAllowanceV2>(inRow).PaidToDate;

            // If the date we're checking is greater than the max date (maximum of all paid allowances 
            // of the same type (alt_key)) then the date is OK regardless of whether this allowance 
            // has been paid or not.
            if( dEffDate > dMaxDate )
            {
                // Do the sanedate check to warn if the date entered is +/- 90 days from the present
                // (returns TRUE if within 90 days of today and if its outside that and the user said it was OK)
                if (StaticVariables.gnv_app.of_sanedate(inEffDate, sAltDescription + " Effective Date"))
                    return 0;
                else
                    return -1;
            }

            // If the record we're checking has not been paid and the date we're checking is not 
            // greater than the max date (maximum of all paid allowances of the same type) the 
            // user needs to enter a more-recent date regardless of whatever else may have changed.
            if ( (thisPaidDate == null) && (dEffDate <= dMaxDate) )
            {
                MessageBox.Show(sAltDescription + " - The effective date must be greater than "
                                    + dMaxDate.ToString("dd/MM/yyyy") + ".\n"
                               , "Validation Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                of_setCellFocus(dwType, inRow, "ca_effective_date");
                return -1;
            }

            // At this point, the record we're checking has been paid, and its effective date
            // is the same as the max date (it can't be less and isn't greater). What we do now 
            // depends on whether a new record will be created or not (if so the effective date 
            // must be greater than the max date) and that depends on what is being changed.
            // This is checked in of_create_new_record().

            // If all else fails and there's a duplicate effective date when inserting
            // a new record, the insert will throw an error that is caught, and the user 
            // told about it.

            return 0;
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
                ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).BackColor  = System.Drawing.SystemColors.Control;  // Grey
                ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", true);
                ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", true);
                ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", true);
                ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", true);
                ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
            }
        }

        private void set_approved_readonly()
        {
            // Called if the user can approve an allowance; all allowances will have been 
            // made modifiable (readonly = false).
            // If the allowance has already been approved, make it readonly
            string sApproved = "N";
            DateTime? paid;
            for (int i = 0; i < dw_fixed_allowance.RowCount; i++)
            {
                sApproved = dw_fixed_allowance.GetItem<MaintainAllowanceV2>(i).Approved;
                if (!(sApproved == null) && sApproved == "Y")
                {
                    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridCellReadonly(i, "ca_approved", true);
                    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                }
                //paid = dw_fixed_allowance.GetItem<MaintainAllowanceV2>(i).PaidToDate;
                //if ( paid != null && paid > DateTime.MinValue)
                //{
                //    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridCellReadonly(i,"ca_approved",true);
                //    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                //}
                //else
                //{
                //    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridCellReadonly(i, "ca_approved", false);
                //    ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Window; 
                //}

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
                //paid = dw_distance_allowance.GetItem<MaintainAllowanceV2>(i).PaidToDate;
                //if (paid != null && paid > DateTime.MinValue)
                //{
                //    ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).SetGridCellReadonly(i, "ca_approved", true);
                //    ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Control;  // Grey
                //}
                //else
                //{
                //    ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).SetGridCellReadonly(i, "ca_approved", false);
                //    ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).BackColor = System.Drawing.SystemColors.Window;
                //}
            }
        }

        #region Events

        private void of_show_record(URdsDw thisDw, int dwType, int nRow, bool bInitial, string msg)
        {
            // ...used for debugging
            int? altKey;
            string altDescription;
            DateTime? effDate;
            decimal? annualAmount;
            decimal? netAmount;

            if( ! bInitial )
            {
                altKey = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                altDescription = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
                effDate = thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
                annualAmount = thisDw.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount;
                netAmount = thisDw.GetItem<MaintainAllowanceV2>(nRow).NetAmount;
            }
            else
            {
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

        public int of_getDwType(URdsDw thisDw)
        {
            string dwName = thisDw.Name;
            if (dwName == "dw_fixed_allowance")
                return FIXED;
            else if (dwName == "dw_roi_allowance")
                return ROI;
            else if (dwName == "dw_activity_allowance")
                return ACTIVITY;
            else if (dwName == "dw_time_allowance")
                return TIME;
            else if (dwName == "dw_distance_allowance")
                return DISTANCE;

            return 0;
        }

        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            int thisRow = idw_Current.GetRow();
            int result = of_save();
            if (result == 1)  // There was an error with no message displayed
            {                 // so we tell the user
                MessageBox.Show("    Save failed    ", ""
                     , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            of_setCellFocus( of_getDwType(idw_Current), thisRow, "alt_key");
        }

        private bool is_eff_date_unique( URdsDw thisDw, int dwType, DateTime? inEffDate, int? inAltKey, int inRow )
        {
            // Check whether the effective date for this allowance type (AltKey) is unique 
            // in the DataControl
            // Returns true if it is unique, 
            //         false if not

            int thisRow;
            int? thisAltKey;
            DateTime? thisEffDate, initialEffDate;

            // Check the date to see if it has changed.  The check for uniqueness is in
            // preparation for creating a new record.  The new record cannot be created 
            // with the same effective date as the record we're creating it from.
            thisEffDate = thisDw.GetItem<MaintainAllowanceV2>(inRow).EffectiveDate ?? DateTime.MinValue;
            initialEffDate = thisDw.GetItem<MaintainAllowanceV2>(inRow).InitialEffDate ?? DateTime.MinValue;
            if (thisEffDate == initialEffDate)
                return false;

            // Scan the DW
            for( thisRow = 0; thisRow < thisDw.RowCount; thisRow++ )
            {
                // Skip the row containing the date we're checking (naturally it should match)
                if (thisRow != inRow)
                {
                    // Get the this row's effective date 
                    // (use GetValueOrDefault in case it's null (which it shouldn't be))
                    thisAltKey = thisDw.GetItem<MaintainAllowanceV2>(thisRow).AltKey;

                    // If this record is the same allowance type check the date
                    if (thisAltKey == inAltKey)
                    {
                        thisEffDate = thisDw.GetItem<MaintainAllowanceV2>(thisRow).EffectiveDate ?? DateTime.MinValue;
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

        private void of_setCellFocus(int dwType, int nRow, string sColumn)
        {
            if (dwType == FIXED)
                ((DMaintainFixedAllowance)(idw_fixed_allowance.DataObject)).SetGridCellFocus(nRow, sColumn, true);
            else if (dwType == ROI)
                ((DMaintainROIAllowance)(idw_roi_allowance.DataObject)).SetGridCellFocus(nRow, sColumn, true);
            else if (dwType == ACTIVITY)
                ((DMaintainActivityAllowance)(idw_activity_allowance.DataObject)).SetGridCellFocus(nRow, sColumn, true);
            else if (dwType == TIME)
                ((DMaintainTimeAllowance)(idw_time_allowance.DataObject)).SetGridCellFocus(nRow, sColumn, true);
            else if (dwType == DISTANCE)
                ((DMaintainDistanceAllowance)(idw_distance_allowance.DataObject)).SetGridCellFocus(nRow, sColumn, true);
        }

        private int of_validate_records(URdsDw thisDw, int dwType)
        {
            // Does some validation
            // Returns 
            //    0    OK
            //    1    Failed without a message displayed
            //   -1    Failed with message displayed
            int? thisAltKey;
            DateTime? thisEffDate;
            string sRowChanged, altDescription;
            bool isNew, isDirty;
            //Decimal thisNetAmt;

            for (int nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                // Get some values we'll use below
                altDescription = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
                isNew = thisDw.GetItem<MaintainAllowanceV2>(nRow).IsNew;
                isDirty = thisDw.GetItem<MaintainAllowanceV2>(nRow).IsDirty;

                // Skip records that haven't been changed (New, Changed, Modified)
                if ((!isNew) && (!isDirty))
                    continue;

                sRowChanged = (thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged) ?? "X";
                if (sRowChanged != "N" && sRowChanged != "C" && sRowChanged != "M")
                    continue;

                // Skip records where the net amount is 0 (primarily terminated records)
                // Do this to avoid checking that required values have been entered
                //thisNetAmt = (thisDw.GetItem<MaintainAllowanceV2>(nRow).NetAmount) ?? 0;
                //if (thisNetAmt == 0)
                //    continue;

                // Do this early to avoid checking and finding other errors first
                if (dwType == DISTANCE)
                {
                    int? varId = thisDw.GetItem<MaintainAllowanceV2>(nRow).VarId;
                    if (varId == null || varId <= 0)
                    {
                        MessageBox.Show("A vehicle type is required.\n"
                                        + " Please INSERT a new " + altDescription + " allowance"
                                        + " and select its vehicle type.\n"
                                        , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        of_reinstate_record(idw_distance_allowance, nRow, true, DISTANCE);
                        return -1;
                    }
                }

                // Check that values are present in required fields
                string errColumn = "alt_key";
                string errMsg = of_validate_fields(thisDw, dwType, nRow, out errColumn);
                if (errMsg.Length != 0)
                {
                    of_setCellFocus(dwType, nRow, errColumn);
                    MessageBox.Show(errMsg, "Validation Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }

                // Validation of the effective date is complicated.
                // of_validate_fields has checked that a  date is present.
                // of_validate_effdate does some value and sanity checking, but 
                // leaves an important check for later (see comments in of_validate_effdate).
                thisAltKey = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                thisEffDate = thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
                int errcode = of_validate_effdate(thisDw, dwType, nRow, thisAltKey, thisEffDate);
                if( errcode != 0 )
                {
                    if (errcode > 0)
                    {
                        string sAltDescription = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
                        MessageBox.Show(sAltDescription + " - invalid effective date"
                                       , "Validation Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        of_setCellFocus(dwType, nRow, "ca_effective_date");
                    }
                    return errcode;
                }
            } // (end for loop)
            return 0;
        }

        private void of_reinstate_record(URdsDw thisDw, int nRow, bool bMarkClean, int dwType)
        {
            // Return the record to its pre-modified start (its modifiable values) 
            // and mark clean (if bMarkClean is true) so it doesn't trigger a save.
            thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate
                  = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialEffDate;
            thisDw.GetItem<MaintainAllowanceV2>(nRow).CaVar1
                  = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialCaVar1;
            thisDw.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount
                  = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialAmount;
            thisDw.GetItem<MaintainAllowanceV2>(nRow).NetAmount
                  = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialNetAmount;
            thisDw.GetItem<MaintainAllowanceV2>(nRow).Notes
                  = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialNotes;
            thisDw.GetItem<MaintainAllowanceV2>(nRow).DocDescription
                  = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialDocDescr;

            if (dwType == DISTANCE)
            {
                thisDw.GetItem<MaintainAllowanceV2>(nRow).CaHrsWk
                      = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialHrsWk;
                thisDw.GetItem<MaintainAllowanceV2>(nRow).CaDistDay
                      = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialDistDay;
                thisDw.GetItem<MaintainAllowanceV2>(nRow).CaCostsCovered
                      = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialCostsCovered;
            }

            if (bMarkClean)
                thisDw.GetItem<MaintainAllowanceV2>(nRow).MarkClean();

            thisDw.Refresh();
        }

        private int of_create_new_record(URdsDw thisDw, int nRow, int dwType)
        {
            // Check to see if a new record should be created
            //  Returns
            //     0     Yes
            //     1     No
            //    -1     Error (message displayed)

            bool result;
            int? AltKey;
            DateTime? EffDate;

            // Although the effective date has been validated its left the situation 
            // where it may be the same as the max effective date (for this allowance).
            // If a new record is generated, this is not OK as that would result in 
            // a database duplicate key error.  Otherwise, if the record is to be 
            // updated (eg approved or the Notes os Doc Description upodated) is should
            // be left as is.
            // NOTE: of_need_new_record returns 1 if no new record needed, 0 otherwise
            if (of_need_new_record(thisDw, dwType, nRow) == 1)
                return 1;

            // Finally we check the case where the record has been paid.  The user has
            // made some changes that mean a new record is to be generated.  The effective
            // date must be greater than the record's original effective date.
            DateTime thisEffDate = (DateTime)(thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate ?? DateTime.MinValue);
            DateTime initialEffDate = (DateTime)(thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialEffDate ?? DateTime.MinValue);
            if (thisEffDate <= initialEffDate)
            {
                int contractNo = (int)thisDw.GetItem<MaintainAllowanceV2>(nRow).ContractNo;
                int altKey = (int)thisDw.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                string sAltDescription = thisDw.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
                DateTime dMaxDate = (DateTime)RDSDataService.GetAllowanceMaxEffectiveDate(contractNo, altKey);
                MessageBox.Show(sAltDescription + " - The effective date must be greater than "
                             + dMaxDate.ToString("dd/MM/yyyy") + ".\n");
                of_setCellFocus(dwType, nRow, "ca_effective_date");
                return -1;
            }
            // We can go ahead and create a new record with the changed details
            string errmsg = of_add_new_record(thisDw, nRow, dwType);
            if (errmsg != "")
            { // If an error occurs at this point, its usually a primary Key error
                // (non-unique effective date) but that has usually been caught in
                // is_eff_date_unique() ... so this error 'shouldn't' happen
                of_setCellFocus(dwType, nRow, "ca_effective_date");
                // The new record was not added successfully
                MessageBox.Show("New record insert failed \n"
                               + "Error = " + errmsg
                               , "Save error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
            
            return 0;
        }

        private int of_insert_new_records(URdsDw thisDw, int dwType)
        {
            // Scan the DW inserting new records for any that have changed the net amount
            // Return 
            //   >=0    The number of rows added 
            //    -1    on error (message displayed)

            int nRow = 0, nRows, NewRows = 0, startRows;
            Decimal NetAmt, initialNetAmt;
            int? AltKey;
            DateTime? EffDate, initialEffDate, PaidToDate;
            string sRowChanged, Approved;
            int result;
            bool RowIsDirty;

            startRows = thisDw.RowCount;
            nRows = thisDw.RowCount;
            for (nRow = 0; nRow < nRows; nRow++)
            {
                AltKey = (int)thisDw.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                sRowChanged = (thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged) ?? "X";

                // In the DataControl (DMaintainFixedAllowance etc) RowChanged is set to 
                // "M" (Modified), "N" (New) or "C" (Changed).  Anything else (usually "X") 
                // means the record hasn't been changed.
                //if (sRowChanged != "N" && sRowChanged != "C" && sRowChanged != "M")
                //    continue;

                // Check to see if the only thing changed is one of the things that 
                // is allowed to be changed whether or not the allowance has already 
                // been paid (eg Approved, Notes and Doc Descriptions)
                RowIsDirty = thisDw.GetItem<MaintainAllowanceV2>(nRow).IsDirty;
                if (RowIsDirty)
                {   // of_need_new_record returns 1 if no new record needed, 0 otherwise
                    if( of_need_new_record( thisDw, dwType, nRow) == 1 )
                        continue;
                }

                // Check to see if the net amount has changed
                EffDate = thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
                initialEffDate = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialEffDate;
                PaidToDate = thisDw.GetItem<MaintainAllowanceV2>(nRow).PaidToDate;
                Approved = thisDw.GetItem<MaintainAllowanceV2>(nRow).Approved;
                NetAmt = (thisDw.GetItem<MaintainAllowanceV2>(nRow).NetAmount) ?? 0.0M;
                initialNetAmt = (thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialNetAmount) ?? 0.0M;

                // If this record has been paid, any change means that a new record is to be created.
                if (PaidToDate != null && PaidToDate != DateTime.MinValue)
                {
                    result = of_create_new_record( thisDw, nRow, dwType );
                    // If there was a problem, quit now
                    if (result < 0)
                        return result;
                }
                
                //Has there been a change in the net amount or the effective date?
                // Note: If this record hasn't been paid, the only other fields (apart 
                // from the effective date) that might be changed won't affect the net 
                // amount and can be changed without generating a new record. Even if 
                // they're the only things changed, they will trigger a save().
                else if (NetAmt != initialNetAmt || EffDate != initialEffDate)
                {
                    // Check to see if this is a modified existing record ("M" as opposed
                    // to a new record "N")
                    if (sRowChanged == "M" && Approved != "Y")
                    {
                        // If the row has been marked as Modified and it hasn't been marked Approved
                        // change its mark to Changed so it won't be inserted.
                        thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged = "C";
                    }

                    // See if this is a modified existing record ("M") that has been approved. 
                    // If so, this is a candidate for the creation of a new record.
                    if (sRowChanged == "M" && Approved == "Y")
                    {
                        result = of_create_new_record(thisDw, nRow, dwType);
                        // If there was a problem, quit now
                        if (result < 0)
                            return result;
                    }
                }

                // If there has been a record added, re-calculate the allowance's net_amount
                if( nRows != thisDw.RowCount )
                {
                    Decimal allowance_total = 0;
                    of_calc_allowance_type(thisDw, (int)AltKey, dwType, out allowance_total);
                }
                
                // NOTE: if any new records are added, the RowCount will increase
                nRows = thisDw.RowCount;
                of_setCellFocus(dwType, nRow, "alt_key");
            }
            NewRows = thisDw.RowCount - startRows;

            return NewRows;
        }

        private int of_need_new_record( URdsDw thisDw, int dwType, int nRow)
        {
            // Check to see what has changed.  If its only some columns (specifically 
            // the Notes and Doc Description columns) then no new record will be required.
            // Return 
            //    0   if any columns other than these have changed
            //    1   No new record required
            //   -1   Error (message displayed)
            // Checking has to be done on a calc type by calc type basis as what the user 
            // can change varies by calc type.
            // What we'll check are the things that, if changed, may require a new record
            // to be generated.  If they are all unchanged, then a new record won't be 
            // needed and whatever else that might have been changed we don't need to check.
            // NOTE: some columns cannot be changed: allowance_type, Paid-to date, and vehicle type
            //       and so don't need to be checked.

            // If this record has not been paid, no new record will be needed
            DateTime? PaidDate = thisDw.GetItem<MaintainAllowanceV2>(nRow).PaidToDate;
            if (PaidDate == null)
                return 1;

            // Some things are common to all calc types
            // Check the effective date
            if( (thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate ?? DateTime.MinValue)
                    != (thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialEffDate ?? DateTime.MinValue) )
            {
                return 0;
            }
            // All calc types use ca_var1 in their calculation (for FIXED this is the calculated amount)
            // If has changed
            if ((thisDw.GetItem<MaintainAllowanceV2>(nRow).CaVar1 ?? 0.0M)
                    != (thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialCaVar1 ?? 0.0M))
            {
                return 0;
            }
            if (dwType == DISTANCE)
            {   // These are specific to the DISTANCE calc type
                if( (thisDw.GetItem<MaintainAllowanceV2>(nRow).CaHrsWk ?? 0.0M)
                        != (thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialHrsWk ?? 0.0M) )
                {
                    return 0;
                }
                if( (thisDw.GetItem<MaintainAllowanceV2>(nRow).CaDistDay ?? 0.0M)
                        != (thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialDistDay ?? 0.0M) )
                {
                    return 0;
                }
                if ((thisDw.GetItem<MaintainAllowanceV2>(nRow).CaCostsCovered ?? "N")
                        != (thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialCostsCovered ?? "N"))
                {
                    return 0;
                }
            }
            return 1;
        }

        private int of_save_changes(URdsDw thisDw)
        {
            // Save any changed records
            // Return number saved or -1 if error
            string sRowChanged, SQLErrText, errmsg;
            int nRow, SQLCode;
            DateTime effdate;
            int nUpdated = 0, savedRow = -1;
            bool isNew, isDirty;

            // Scan the list and save any changed records
            for (nRow = 0; nRow < thisDw.RowCount; nRow++)
            {
                isNew = thisDw.GetItem<MaintainAllowanceV2>(nRow).IsNew;
                isDirty = thisDw.GetItem<MaintainAllowanceV2>(nRow).IsDirty;
                if (!(isNew || isDirty))
                    continue;
                sRowChanged = (thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged) ?? "X";
                if (!(sRowChanged == "N" || sRowChanged == "C" || sRowChanged == "M"))
                {
                    //continue;
                }

                // Save the record as a clean one.
                thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged = "X";

                //if (sRowChanged == "M")
                if (isNew)
                    thisDw.GetItem<MaintainAllowanceV2>(nRow).MarkNewEntity();

                nUpdated = thisDw.Save();

                SQLCode = thisDw.GetItem<MaintainAllowanceV2>(nRow).SQLCode;
                SQLErrText = thisDw.GetItem<MaintainAllowanceV2>(nRow).SQLErrText;

                if( SQLCode != 0 )
                {
                    if (SQLErrText.Contains("PRIMARY KEY"))
                    {
                        effdate = (DateTime)thisDw.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;

                        errmsg = "Please change the effective date to a date later than "
                                    + effdate.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        errmsg = "Error text: " + SQLErrText;
                    }
                    //of_setselect(FIXED, nRow, "alt_key");
                    //of_setCellFocus(FIXED, nRow, "alt_key");
                    MessageBox.Show("Failed to update Allowance. \n\n"
                                   + errmsg, "Database Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    // NOTE: the Save could involve more than one change
                    // If the save failed, reset the RowChanged value so its current value is "remembered" if
                    // we manage to save the record later.
                    thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged = sRowChanged;

                    return -1;
                }
                savedRow = nRow;
            }
            int thisDwType = of_getDwType(thisDw);
            of_setCellFocus(thisDwType, savedRow, "ca_effective_date");
            return nUpdated;
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


        public virtual int of_save()
        {
            // Processes the records in all tabs, looking for changes.  Velidates
            // the records and inserts new ones and updates existing records that
            // have been changed.
            // Returns
            //     0    OK
            //     1    Error with no message displayed
            //    -1    Error with message displayed

            cb_save.Focus();
            int nSaved, mDeleted;
            int nChanged, nDeleted;
            int nInserted, nUpdated;
            int errcode = 0;

            idw_fixed_allowance.DataObject.AcceptText();
            idw_roi_allowance.DataObject.AcceptText();
            idw_activity_allowance.DataObject.AcceptText();
            idw_time_allowance.DataObject.AcceptText();
            idw_distance_allowance.DataObject.AcceptText();

            decimal dTotalAmt;
            decimal dTotalApproved;
            of_calc_allowance_total(out dTotalAmt, out dTotalApproved);

            // Display the totals
            this.Total.Text = dTotalAmt.ToString("###,###.00");
            this.Total_approved.Text = dTotalApproved.ToString("###,###.00");

            nSaved = 0;
            mDeleted = 0;

            // Check each tab for changes
            /*************************
             * Fixed Allowances
             * ***********************/
            nChanged = idw_fixed_allowance.ModifiedCount();
            nDeleted = (idw_fixed_allowance.DataObject).DeletedCount;
            // We can't rely on the user having focus on the changed row(s), 
            // so nRow = idw_fixed_allowance.GetRow() isn't useful.

            // If there are changed fixed allowance records ...
            if ((nChanged > 0) && !(isTerminated(idw_fixed_allowance)))
            {
                // Check to see if the user is trying to reinstate a terminated allowance
                for (int nRow = 0; nRow < idw_fixed_allowance.RowCount; nRow++)
                {
                    if (idw_fixed_allowance.GetItem<MaintainAllowanceV2>(nRow).IsDirty )
                        if (wasTerminated(idw_fixed_allowance, nRow) )
                        {
                            string sAltDescr = idw_fixed_allowance.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
                            MessageBox.Show("To reinstate the terminated " + sAltDescr + " allowance, \n\n"
                                            + "please use the INSERT button to create a new allowance."
                                            , "Warning"
                                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            of_reinstate_record(idw_fixed_allowance, nRow, true, FIXED);
                            return -1;
                        }
                }

                // Scan the list for changed records and validate any that are found
                errcode = of_validate_records(idw_fixed_allowance, FIXED);
                if (errcode != 0)
                    return errcode;

                // Now, scan the list again and insert any new records required
                nInserted = of_insert_new_records(dw_fixed_allowance, FIXED);
                if (nInserted < 0)
                {
                    return nInserted;
                }
                nSaved += nInserted;

                // Now, scan the list again and save any changed records
                nUpdated = of_save_changes(dw_fixed_allowance);
                if (nUpdated < 0)
                {
                    return nUpdated;
                }
                else if (nUpdated > 0)
                {
                    nSaved += nUpdated;
                    MessageBox.Show("Saved fixed allowance changes");
                }
            }
            // If there are any records to delete, do so
            else if (nDeleted > 0)
            {
                idw_fixed_allowance.Save();
                //MessageBox.Show("Fixed allowance record deleted.");
                mDeleted++;
            }

            /*******************************************************************
             * ROI Allowances
             *******************************************************************/
            nChanged = idw_roi_allowance.ModifiedCount();
            nDeleted = (idw_roi_allowance.DataObject).DeletedCount;
            // We can't rely on the user having focus on the changed row(s), 
            // so nRow = idw_roi_allowance.GetRow() isn't useful.

            // If there are changed ROI allowance records ...
            if ((nChanged > 0) && !(isTerminated(idw_roi_allowance)))
            {
                // Check to see if the user is trying to reinstate a terminated allowance
                for (int nRow = 0; nRow < idw_roi_allowance.RowCount; nRow++)
                {
                    if (idw_roi_allowance.GetItem<MaintainAllowanceV2>(nRow).IsDirty)
                        if (wasTerminated(idw_roi_allowance, nRow))
                        {
                            string sAltDescr = idw_roi_allowance.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
                            MessageBox.Show("To reinstate the terminated " + sAltDescr + " allowance, \n\n"
                                            + "please use the INSERT button to create a new allowance."
                                            , "Warning"
                                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            of_reinstate_record(idw_roi_allowance, nRow, true, ROI);
                            return -1;
                        }
                }

                // Scan the list for changed records and validate any that are found
                errcode = of_validate_records(idw_roi_allowance, ROI);
                if (errcode != 0)
                    return errcode;

                // Now, scan the list again and insert new records for any that have changed the net amount
                nInserted = of_insert_new_records(dw_roi_allowance, ROI);
                if (nInserted < 0)
                {
                    return nInserted;
                }
                nSaved += nInserted;

                // Now, scan the list again and save any changed records
                nUpdated = of_save_changes(dw_roi_allowance);
                if (nUpdated < 0)
                {
                    return nUpdated;
                }
                else if (nUpdated > 0)
                {
                    nSaved += nUpdated;
                    MessageBox.Show("Saved ROI allowance changes");
                }
            }
            // If there are any records to delete, do so
            else if (nDeleted > 0)
            {
                idw_roi_allowance.Save();
                //MessageBox.Show("ROI Allowance record deleted");
                mDeleted++;
            }

            /*******************************************************************
             * Activity Allowances
             *******************************************************************/
            nChanged = idw_activity_allowance.ModifiedCount();
            nDeleted = (idw_activity_allowance.DataObject).DeletedCount;

            // If there are changed activity allowance records ...
            if ((nChanged > 0) && !(isTerminated(idw_activity_allowance)))
            {
                // Check to see if the user is trying to reinstate a terminated allowance
                for (int nRow = 0; nRow < idw_activity_allowance.RowCount; nRow++)
                {
                    if (idw_activity_allowance.GetItem<MaintainAllowanceV2>(nRow).IsDirty)
                        if (wasTerminated(idw_activity_allowance, nRow))
                        {
                            string sAltDescr = idw_activity_allowance.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
                            MessageBox.Show("To reinstate the terminated " + sAltDescr + " allowance, \n\n"
                                            + "please use the INSERT button to create a new allowance."
                                            , "Warning"
                                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            of_reinstate_record(idw_activity_allowance, nRow, true, ACTIVITY);
                            return -1;
                        }
                }

                // Scan the list for changed records and validate any that are found
                errcode = of_validate_records(idw_activity_allowance, ACTIVITY);
                if (errcode != 0)
                    return errcode;

                // Now, scan the list again and insert new records for any that have 
                // changed the net amount
                nInserted = of_insert_new_records(dw_activity_allowance, ACTIVITY);
                if (nInserted< 0)
                {
                    return nInserted;
                }
                nSaved += nInserted;

                // Now, scan the list again and save any changed records
                nUpdated = of_save_changes(dw_activity_allowance);
                if (nUpdated < 0)
                {
                    return nUpdated;
                }
                else if (nUpdated > 0)
                {
                    nSaved += nUpdated;
                    MessageBox.Show("Saved Activity allowance changes");
                }
            }
            // If there are any records to delete, do so
            else if (nDeleted > 0)
            {
                idw_activity_allowance.Save();
                //MessageBox.Show("Activity Allowance record deleted");
                mDeleted++;
            }

            /*******************************************************************
             * Time Allowances
             *******************************************************************/
            nChanged = idw_time_allowance.ModifiedCount();
            nDeleted = (idw_time_allowance.DataObject).DeletedCount;

            // If there are changed time allowance records ...
            if ((nChanged > 0) && !(isTerminated(idw_time_allowance)))
            {
                // Check to see if the user is trying to reinstate a terminated allowance
                for (int nRow = 0; nRow < idw_time_allowance.RowCount; nRow++)
                {
                    if (idw_time_allowance.GetItem<MaintainAllowanceV2>(nRow).IsDirty)
                        if (wasTerminated(idw_time_allowance, nRow))
                        {
                            string sAltDescr = idw_time_allowance.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
                            MessageBox.Show("To reinstate the terminated " + sAltDescr + " allowance, \n\n"
                                            + "please use the INSERT button to create a new allowance."
                                            , "Warning"
                                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            of_reinstate_record(idw_time_allowance, nRow, true, TIME);
                            return -1;
                        }
                }

                // Scan the list for changed records and validate any that are found
                errcode = of_validate_records(idw_time_allowance, TIME);
                if (errcode != 0)
                    return errcode;

                // Now, scan the list again and insert new records for any that have 
                // changed the net amount
                nInserted = of_insert_new_records(idw_time_allowance, TIME);
                if (nInserted < 0)
                {
                    return nInserted;
                }
                nSaved += nInserted;

                // Now, scan the list again and save any changed records
                nUpdated = of_save_changes(dw_time_allowance);
                if (nUpdated < 0)
                {
                    return nUpdated;
                }
                else if (nUpdated > 0)
                {
                    nSaved += nUpdated;
                    MessageBox.Show("Saved Time allowance changes");
                }
            }
            // If there are any records to delete, do so
            else if (nDeleted > 0)
            {
                idw_time_allowance.Save();
                //MessageBox.Show("Time Allowance record deleted");
                mDeleted++;
            }

            /*******************************************************************
             * Distance Allowances
             *******************************************************************/
            nChanged = idw_distance_allowance.ModifiedCount();
            nDeleted = (idw_distance_allowance.DataObject).DeletedCount;

            // If there are changed distance allowance records ...
            if ((nChanged > 0) && !(isTerminated(idw_distance_allowance)))
            {
                // Check to see if the user is trying to reinstate a terminated allowance
                for (int nRow = 0; nRow < idw_distance_allowance.RowCount; nRow++)
                {
                    if (idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).IsDirty)
                        if (wasTerminated(idw_distance_allowance, nRow))
                        {
                            string sAltDescr = idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
                            MessageBox.Show("To reinstate the terminated " + sAltDescr + " allowance, \n\n"
                                            + "please use the INSERT button to create a new allowance."
                                            , "Warning"
                                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            of_reinstate_record(idw_distance_allowance, nRow, true, DISTANCE);
                            return -1;
                        }
                }

                // Scan the list for changed records and validate any that are found
                errcode = of_validate_records(idw_distance_allowance, DISTANCE);
                if (errcode != 0)
                    return errcode;

                // Now, scan the list again and insert new records for any that have 
                // changed the net amount
                nInserted = of_insert_new_records(dw_distance_allowance, DISTANCE);
                if (nInserted < 0)
                {
                    return nInserted;
                }
                nSaved += nInserted;

                // Now, scan the list again and save any changed records
                nUpdated = of_save_changes(dw_distance_allowance);
                if (nUpdated < 0)
                {
                    return nUpdated;
                }
                else if (nUpdated > 0)
                {
                    nSaved += nUpdated;
                    MessageBox.Show("Saved Distance allowance changes");
                }
            }
            // If there are any records to delete, do so
            else if (nDeleted > 0)
            {
                idw_distance_allowance.Save();
                //MessageBox.Show("Distance Allowance record deleted");
                mDeleted++;
            }

            if ((nSaved + mDeleted) == 0)
                MessageBox.Show("   Nothing to save.   ");

            return 0;
        }

        private bool isTerminated(URdsDw thisDw)
        {
            int nRow = thisDw.GetRow();
            Decimal? thisAnnualAmt = thisDw.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount;
            Decimal? thisNetAmt = thisDw.GetItem<MaintainAllowanceV2>(nRow).NetAmount;
            if ((thisNetAmt == null || thisNetAmt == 0)
                && (thisAnnualAmt != null && thisAnnualAmt != 0))
                return true;
            return false;
        }

        private bool wasTerminated(URdsDw thisDw, int nRow)
        {   // Check whether this record was terminated
            Decimal? initialAnnualAmt = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialAmount;
            Decimal? initialNetAmt = thisDw.GetItem<MaintainAllowanceV2>(nRow).InitialNetAmount;
            if ((initialNetAmt == null || initialNetAmt == 0)
                && (initialAnnualAmt != null && initialAnnualAmt != 0))
                return true;
            return false;
        }

        private bool isDwNewOrDirty(URdsDw thisDw, int dwType)
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
                if( thisDw.GetItem<MaintainAllowanceV2>(nRow).RowChanged == "N")
                return true;
            }
            return false;
        }

        private bool isDwRowComplete(URdsDw thisDw, int inRow, int dwType)
        {
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

            if( nModified > 0 || nDeleted > 0 )
            {
                DialogResult ans;
                ans = MessageBox.Show("Do you want to save changes?", ""
                            , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (ans == DialogResult.Cancel)
                    return false;
                else if (ans == DialogResult.Yes)
                {
                    int bSaveResult = of_save();
                    if (bSaveResult == 1)  // There was an error with no error message displayed
                    {                      // so we tell the user
                        MessageBox.Show("    Save failed    ", ""
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
            DateTime? effectiveDate, paidToDate;
            string sEffDate;

            dwName = idw_Current.Name;
            nRow = idw_Current.DataObject.GetRow();
            sAltDescription = "null";
            
            sAltDescription = idw_Current.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
            effectiveDate = idw_Current.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
            paidToDate = idw_Current.GetItem<MaintainAllowanceV2>(nRow).PaidToDate;

            if (effectiveDate == null)
                sEffDate = " not set";
            else
                sEffDate = ((DateTime)effectiveDate).ToString("dd/MM/yyyy");
            
            if (paidToDate != null && paidToDate > DateTime.MinValue)
            {
                MessageBox.Show("You may not delete an allowance that has been paid");
            }
            else
            {
                DialogResult ans;
                ans = MessageBox.Show("Please confirm that you want to delete allowance \n\n"
                                    + "     " + sAltDescription 
                                    + " Effective " + sEffDate + "."
                                    , "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    idw_Current.DataObject.DeleteItemAt(nRow);
                    int result = idw_Current.Save();
                    string msg = "";
                    if (result != 1)
                    {
                        msg = "\n (Save returned " + result.ToString() + ")";
                        MessageBox.Show("Record deleted" + msg);
                    }
                    of_set_allowance_readonly(idw_Current);

                    decimal dTotalAmt;
                    decimal dTotalApproved;
                    of_calc_allowance_total(out dTotalAmt, out dTotalApproved);

                    // Display the totals
                    this.Total.Text = dTotalAmt.ToString("###,###.00");
                    this.Total_approved.Text = dTotalApproved.ToString("###,###.00");
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
            }
            if (ToTabName == "roi")
            {
                idw_Current = idw_roi_allowance;
                if (idw_roi_allowance.RowCount > 0)
                    idw_roi_allowance.Refresh();
            }
            if (ToTabName == "activity")
            {
                idw_Current = idw_activity_allowance;
                if (idw_activity_allowance.RowCount > 0)
                    idw_activity_allowance.Refresh();
            }
            if (ToTabName == "time")
            {
                idw_Current = idw_time_allowance;
                if (idw_time_allowance.RowCount > 0)
                    idw_time_allowance.Refresh();
            }
            if (ToTabName == "distance")
            {
                idw_Current = idw_distance_allowance;
                if (idw_distance_allowance.RowCount > 0)
                    idw_distance_allowance.Refresh();
                // TJB 7-July-2021
                // For some reason currently not understood, the Distance tab's rows 
                // are not set to the proper ReadOnly settings properly. This specific
                // call to of_set_allowance_readonly seems to correct the problem.
             //   of_set_allowance_readonly(idw_distance_allowance);
            }
        }

        void dw_distance_allowance_DoubleClick(object sender, EventArgs e)
        {
            // From contract_allowances
            decimal days_yr = 0.0M;
            decimal hours_wk = 0.0M;
            decimal dist_day = 0.0M;
            string  costs_covered = "N";

            // From allowance_type
            decimal rate_hr = 0.0M;
            decimal weeks_yr = 0.0M;
            decimal ACC = 0.0M;

            // From vehicle_allowance_rates
            // [8-Jul-2021] Bug fix: fuel_use_pk changed to fuel_use_p100
            //      + Change Fuel cost calculation and name to FuelAllowance    
            decimal fuel_use_p100 = 0.0M;
            decimal fuel_rate = 0.0M;
            decimal ruc_rate_pk = 0.0M;
            decimal repairs_pk = 0.0M;
            decimal tyres_pk = 0.0M;
            decimal allowance_pk = 0.0M;
            decimal licence_pa = 0.0M;
            decimal carrier_pa = 0.0M;
            decimal insurance_pa = 0.0M;
            decimal ror_pa = 0.0M;

            // Intermediate calculated velues
            decimal TimeAmt = 0.0M;
            decimal DistAmt = 0.0M;
            decimal Dist_yr = 0.0M;
            decimal VehAmt = 0.0M;
            decimal NetAmount = 0.0M;
            decimal Dist_yr_k = 0.0M;
            //decimal Dist_yr_100 = 0.0M;
            decimal Fuel_allowance = 0.0M;
            decimal Ruc_pk = 0.0M;

            int nRow = idw_distance_allowance.GetRow();

            days_yr  = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).CaVar1);
            hours_wk = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).CaHrsWk);
            weeks_yr = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).AltWksYr);
            rate_hr  = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).AltRate);
            ACC      = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).AltAcc);
            TimeAmt  = ((hours_wk * weeks_yr) * rate_hr) * (1 + (ACC/100));

            dist_day = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).CaDistDay);
            Dist_yr  = dist_day * days_yr;

            repairs_pk  = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarRepairsPk);
            tyres_pk    = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarTyresPk);
            allowance_pk = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarAllowancePk);
            fuel_use_p100 = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarFuelUsePk);
            fuel_rate   = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarFuelRate);
            ruc_rate_pk = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarRucRatePk);
            
            Dist_yr_k  = Dist_yr / 1000.0M;
            Fuel_allowance = (fuel_use_p100 * fuel_rate) * (Dist_yr / 100.0M);
            DistAmt = (ruc_rate_pk + repairs_pk + tyres_pk + allowance_pk)
                       * (Dist_yr / 1000.0M)
                       + Fuel_allowance;

            costs_covered = idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).CaCostsCovered;
            costs_covered = (costs_covered == null || costs_covered != "Y") ? "N" : costs_covered;
            carrier_pa    = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarCarrierPa);
            licence_pa    = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarLicencePa);
            insurance_pa  = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarInsurancePa);
            ror_pa        = of_getDecimalValue(idw_distance_allowance.GetItem<MaintainAllowanceV2>(nRow).VarRorPa);
            VehAmt        = (costs_covered == "N") ? (carrier_pa + licence_pa + insurance_pa + ror_pa) : 0.0M;

            NetAmount = TimeAmt + DistAmt + VehAmt;

            MessageBox.Show("Time amount = ((Hours/wk * Weeks/yr) * Rate/Hr) * (1 + (ACC/100)) = $" + TimeAmt.ToString("###,##0.00") + "\n"
                          + "  Hours/wk = " + hours_wk.ToString("##0.0") + ",  Weeks/yr = " + weeks_yr.ToString("##0.0")
                          + ",  Rate/hr = $" + rate_hr.ToString("##0.00") + ", ACC% = " + ACC.ToString("##.00") + "% \n\n"
                          + "Distance amount = (Distance/Yr / 1000) * (RUC/1000km + Repairs/1000km + Tyres/1000km + Allowance/1000km) + Fuel_allowance = $" + DistAmt.ToString("###,##0.00") + "\n"
                          + "  Distance/Yr/1000 = " + Dist_yr_k.ToString("###,##0.000") + "\n"
                          + "  RUC/1000km = $" + ruc_rate_pk.ToString("#,##0.00") + ",  Repairs/1000km = $" + repairs_pk.ToString("#,##0.00")
                          + ",  Tyres/1000km = $" + tyres_pk.ToString("#,##0.00") + ",  Allowance/1000km = $" + allowance_pk.ToString("##0.00") + "\n\n"
                          + "Distance/Yr = (Dist/Day * Days/yr) = " + Dist_yr.ToString("###,##0.0") + "Km \n"
                          + "  Dist/Day = " + dist_day.ToString("##0.0") + ",  Days/yr = " + days_yr.ToString("##0.0")+"\n\n"
                          + "Fuel_allowance = (Fuel_use/100km * Fuel_rate) * (Distance/Yr / 100) = $" + Fuel_allowance.ToString("##,##0.00") + "\n"
                          + "  Fuel_use/100km = " + fuel_use_p100.ToString("##0.00") + "ltr, Fuel_rate = $" + fuel_rate.ToString("##0.00") + "\n\n"
                          + "If Costs_covered = 'Y', Vehicle amount = $0.00 \n"
                          + "If Costs_covered = 'N', Vehicle amount = (Carrier/yr + Licence/yr + Insurance/yr + RoR/yr) = $" + VehAmt.ToString("###,##0.00") + "\n"
                          + "  Costs_covered = '" + costs_covered + "'\n"
                          + "  Carrier/yr = $"+carrier_pa.ToString("#,##0.00") + ",  Licence/yr = $"+licence_pa.ToString("##,##0.00")
                          + ",  Insurance/yr = $" + insurance_pa.ToString("#,##0.00") + ",  RoR/yr = $" + ror_pa.ToString("##,##0.00") + "\n\n"
                          + "Net amount = (Time amount + Distance amount + Vehicle amount) = $" + NetAmount.ToString("###,##0.00") + "\n"
                          + " Time amount = $" + TimeAmt.ToString("###,##0.00") + ", Distance amount = $" + DistAmt.ToString("###,##0.00")
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

        #endregion

        private void of_calc_allowance_type(URdsDw thisDw, int inAltKey, int dwType, out decimal type_total)
        {
            // Calculate the total allowance (net amount) for an individual allowance type,
            // update the running total for each row, and return the final net amount.
            int nRow, startRow;
            int thisAltKey;

            decimal? dTotalAmt = 0.0M;
            decimal? dThisAmt = 0.0M;
 
            // Re-calculate the total of the AnnualPayments for the specified allowance type
            dTotalAmt = 0.0M;
            startRow = thisDw.RowCount - 1;
            for (nRow = startRow; nRow >= 0; nRow--)
            {
                thisAltKey = (int)thisDw.GetItem<MaintainAllowanceV2>(nRow).AltKey;
                if (thisAltKey == inAltKey)
                {
                    dThisAmt = thisDw.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount;
                    dTotalAmt += dThisAmt ?? 0.0M;
                    thisDw.GetItem<MaintainAllowanceV2>(nRow).NetAmount = dTotalAmt;
                }
            }
            // Return the total
            type_total = (decimal)(dTotalAmt ?? 0.0M);
        }

        private void of_calc_allowance(URdsDw tab_dw, out decimal allowance_total, out decimal approved_total)
        {   // Calculate the allowance totals for an allowance calc type
            // This does it for a single allowance calc type (via the tab's DataContron tab_dw)
            decimal dThisAmt = 0.0M;
            decimal dTotalAmt = 0.0M;
            decimal dApprovedTotal = 0.0M;
            string  thisApproved = "N";

            // Calculate the total of the AnnualAmounts 
            for (int nRow = 0; nRow < tab_dw.RowCount; nRow++)
            {
                dThisAmt = (decimal)(tab_dw.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount ?? 0.0M);
                thisApproved = (tab_dw.GetItem<MaintainAllowanceV2>(nRow).Approved) ?? "N";

                dTotalAmt += dThisAmt;
                if( thisApproved == "Y" )
                    dApprovedTotal += dThisAmt;
            }
            // Return the totals
            allowance_total = dTotalAmt;
            approved_total = dApprovedTotal;
        }

        private void of_calc_allowance_total(out decimal allowance_total, out decimal approved_total)
        {
            decimal dTotalAmt = 0.0M;
            decimal dTotalApproved = 0.0M;
            decimal dThisAmt = 0.0M;
            decimal dThisApproved = 0.0M;

            of_calc_allowance(idw_fixed_allowance, out dThisAmt, out dThisApproved);
            dTotalAmt += dThisAmt;
            dTotalApproved += dThisApproved;

            of_calc_allowance(idw_roi_allowance, out dThisAmt, out dThisApproved);
            dTotalAmt += dThisAmt;
            dTotalApproved += dThisApproved;

            of_calc_allowance(idw_activity_allowance, out dThisAmt, out dThisApproved);
            dTotalAmt += dThisAmt;
            dTotalApproved += dThisApproved;

            of_calc_allowance(idw_time_allowance, out dThisAmt, out dThisApproved);
            dTotalAmt += dThisAmt;
            dTotalApproved += dThisApproved;

            of_calc_allowance(idw_distance_allowance, out dThisAmt, out dThisApproved);
            dTotalAmt += dThisAmt;
            dTotalApproved += dThisApproved;

            allowance_total = dTotalAmt;
            approved_total = dTotalApproved;
        }

        private void cb_terminate_Click(object sender, EventArgs e)
        {
            // TJB Allowances 8-June-2021: New
            // Determine the net allowance amount for this allowance and 
            // create a new record with the negative of the net amount as 
            // its 'annual amount' (thus reducing the net amount to $0.00
            // and 'terminating' the allowance.  This overrides the calculation 
            // of the annual amount from the user and system factors.
            int nRow = 0;
            string sAltDescription, dwName;
            DateTime? effectiveDate, initialEffDate;
            DateTime dtEffectiveDate, dtInitialEffDate;
            decimal? dNetAmt, dAnnualAmt;
            int dwType = -1;
            int? varId;
            string rowChanged = "";

            DateTime? dtPaidDate = idw_Current.GetItem<MaintainAllowanceV2>(nRow).PaidToDate;
            if (dtPaidDate == null || dtPaidDate == DateTime.MinValue)
            {
                MessageBox.Show("An allowance that has not been paid may not be terminated."
                                , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                of_reinstate_record(idw_Current, nRow, true, of_getDwType(idw_Current));
                return;
            }

            dwName = idw_Current.Name;
            nRow   = idw_Current.DataObject.GetRow();
            if (dwName == "dw_fixed_allowance") dwType = FIXED;
            else if (dwName == "dw_roi_allowance") dwType = ROI;
            else if (dwName == "dw_activity_allowance") dwType = ACTIVITY;
            else if (dwName == "dw_time_allowance") dwType = TIME;
            else if (dwName == "dw_distance_allowance") dwType = DISTANCE;

            effectiveDate = idw_Current.GetItem<MaintainAllowanceV2>(nRow).EffectiveDate;
            initialEffDate = idw_Current.GetItem<MaintainAllowanceV2>(nRow).InitialEffDate;
            rowChanged = idw_Current.GetItem<MaintainAllowanceV2>(nRow).RowChanged;

            dtEffectiveDate = (DateTime)effectiveDate;
            dtInitialEffDate = (DateTime)initialEffDate;
            if (dtEffectiveDate == dtInitialEffDate)
            {
                MessageBox.Show("Please enter an effective date for the termination date.");
                of_setCellFocus(dwType, nRow, "ca_effective_date");
                return;
            }

            string thisNotes = idw_Current.GetItem<MaintainAllowanceV2>(nRow).Notes;
            string initialNotes = idw_Current.GetItem<MaintainAllowanceV2>(nRow).InitialNotes;
            if (thisNotes == initialNotes || thisNotes == null)
            {
                MessageBox.Show("Please enter a note for the termination.");
                of_setCellFocus(dwType, nRow, "ca_notes");
                return;
            }

            sAltDescription = idw_Current.GetItem<MaintainAllowanceV2>(nRow).AltDescription;
            dNetAmt = idw_Current.GetItem<MaintainAllowanceV2>(nRow).NetAmount;
            dAnnualAmt = (dNetAmt * -1);
            idw_Current.GetItem<MaintainAllowanceV2>(nRow).AnnualAmount = dAnnualAmt;
            idw_Current.GetItem<MaintainAllowanceV2>(nRow).NetAmount = 0;
            idw_Current.GetItem<MaintainAllowanceV2>(nRow).RowChanged = "M";

            DialogResult ans;
            ans = MessageBox.Show("Please confirm that you want to terminate allowance \n\n"
                                + "     " + sAltDescription 
                                + " Effective " + effectiveDate + "."
                                , "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                string errmsg = of_add_new_record(idw_Current, nRow, dwType);
                if (errmsg != "")
                { // If an error occurs at this point, its usually a primary Key error
                    // (non-unique effective date) but that has usually been caught in
                    // is_eff_date_unique() ... so this error 'shouldn't' happen
                    //of_setselect(dwType, nRow, "ca_effective_date");
                    //of_setCellFocus(dwType, nRow, "ca_effective_date");
                    // The new record was not added successfully
                    MessageBox.Show("New record insert failed \n"
                                   + "Error = " + errmsg
                                   , "Save error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //of_save_changes(idw_Current);
                int result = idw_Current.Save();
                string msg = "";
                if (result != 1)
                {
                    msg = "\n (Save returned " + result.ToString() + ")";
                    MessageBox.Show("Allowance terminated " + msg);
                }
                of_setCellFocus(dwType, nRow, "alt_key");

                decimal dTotalAmt;
                decimal dTotalApproved;
                of_calc_allowance_total(out dTotalAmt, out dTotalApproved);

                // Display the totals
                this.Total.Text = dTotalAmt.ToString("###,###.00");
                this.Total_approved.Text = dTotalApproved.ToString("###,###.00");
            }
        }
    }
}
