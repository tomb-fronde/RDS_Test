using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using Metex.Windows;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruralwin2;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Entity.Ruralwin2;
using System.Collections.Generic;
using NZPostOffice.RDS.Menus;
using NZPostOffice.RDS.Windows.Ruralwin;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WRenewal2001 : WAncestorWindow
    {
        // TJB RPCR_01 July-2010
        // Added most functions to DContractVehicle with support here
        // Added error handling to vehicle insert & update

        #region Define
        private WRenewal2001 iw_renewal;

        public int il_contract;

        public int il_sequence;

        public int il_newvehicle;

        public int il_row;

        public URdsDw idw_renewal;

        public URdsDw idw_frequency_adjustment;

        public URdsDw idw_contract_adjustment;

        public URdsDw idw_owner_drivers;

        public URdsDw idw_vehicle;

        public URdsDw idw_article_count;

        public bool ib_new_veh_added = false;

        //  TJB 7-Oct-2004  SR4633 
        public bool ib_new_veh_validated = false;

        //  TJB  Jan-2007 SR4695 
        public int il_del_record = 0;

        //   0  = nothing to delete   1  = delete associated frequency_distances record   2  = delete associated vehicle_override_rates record   3  = delete associated nonvehicle_override_rates record  These are used to pass selection information from the pfc_predelete  event to the pfc_delete event for dw_renewal_freq_adjust  contract_seq_number of the currently active il_contract 
        public int il_current_seq;

        //   ( il_sequence is the sequence for the selected contract    which may be inactive)  effective date of the selected frequency adjustment 
        public DateTime? id_effective = DateTime.MinValue;

        //  sf_key of the the selected frequency adjustment 
        public int? il_sfKey;

        //  rf_delivery_days of the the selected frequency adjustment 
        public string is_delDays = String.Empty;

        //  fd_change_reason from associated frequency_distances record 
        public string is_reason = String.Empty;

        //  Date this renewal started 
        public DateTime? id_renewal_start = DateTime.MinValue;

        public int il_fd_row;

        public int? il_vor_row;

        public int il_nvor_row;

        public int? il_nvorh_row;

        public DataUserControl ids_route_frequency;

        public DataUserControl ids_frequency_distances;

        public DataUserControl ids_vehicle_override_rate;

        public DataUserControl ids_non_vehicle_override_rate;

        public DataUserControl ids_non_vehicle_override_rate_history;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public TabControl tab_renewal;

        public TabPage tabpage_renewal;

        public URdsDw dw_renewal;

        public TabPage tabpage_frequency_adjustment;

        public URdsDw dw_renewal_freq_adjust;

        public TabPage tabpage_contract_adjustment;

        public URdsDw dw_renewal_cont_adjustments;

        public TabPage tabpage_owners_drivers;

        public URdsDw dw_contract_contractor;

        public TabPage tabpage_vehicles;

        public URdsDw dw_contract_vehicle;

        public TabPage tabpage_article_count;

        public URdsDw dw_renewal_artical_counts;

        public TableLayoutPanel tbPanel;

        public URdsDw t;

        private int? nPrevVehicle;
        private int? nPrevFtKey;
        private System.Decimal dcPrevVehBenchmark = -1;

        // TJB  RD7_0040  Aug2009  -- Added --
        private int? nPrevVolume, nPrevRgCode;

        #endregion

        public WRenewal2001()
        {
            this.InitializeComponent();

            dw_renewal_freq_adjust.DataObject = new DRenewalFreqAdjust();
            dw_renewal_freq_adjust.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_renewal_cont_adjustments.DataObject = new DRenewalAdjustments();
            dw_renewal_cont_adjustments.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_renewal.DataObject = new DRenewal();
            dw_renewal.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;

            dw_contract_contractor.DataObject = new DContractContractor();
            dw_contract_contractor.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_contract_vehicle.DataObject = new DContractVehicle();
            dw_contract_vehicle.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_renewal_artical_counts.DataObject = new DRenewalArticalCounts();
            dw_renewal_artical_counts.DataObject.BorderStyle = BorderStyle.Fixed3D;

            // TJB RPCR_001 July-2010: removed (event not found?, didn't do anything useful)
            //((DContractVehicle)dw_contract_vehicle.DataObject).SelectedItemChanged += new EventHandler(dw_contract_vehicle_itemchanged);
            //((DContractVehicle)dw_contract_vehicle.DataObject).TextChanged += new EventHandler(dw_contract_vehicle_itemchanged);

            dw_renewal.Constructor += new UserEventDelegate(dw_renewal_constructor);
            dw_renewal.WinPfcSave += new UserEventDelegate1(this.pfc_save); //added by jlwang

            // TJB  RD7_0040  Aug2009  -- Added --
            dw_renewal.EditChanged += new EventHandler(dw_renewal_editchanged);

            dw_renewal_freq_adjust.DataObject.RetrieveStart += new RetrieveEventHandler(dw_renewal_freq_adjust_retrievestart);
            dw_renewal_freq_adjust.Constructor += new UserEventDelegate(dw_renewal_freq_adjust_constructor);
            ((DataEntityGrid)dw_renewal_freq_adjust.GetControlByName("grid")).CellValueChanged += new DataGridViewCellEventHandler(dw_renewal_freq_adjust_itemchanged);
            dw_renewal_freq_adjust.PfcPreDeleteRow += new UserEventDelegate1(dw_renewal_freq_adjust_pfc_predeleterow);
            dw_renewal_freq_adjust.PfcDeleteRow += new UserEventDelegate(dw_renewal_freq_adjust_pfc_deleterow);
            dw_renewal_freq_adjust.WinPfcSave += new UserEventDelegate1(this.pfc_save); //added by jlwang
            dw_renewal_freq_adjust.Click += new EventHandler(dw_renewal_freq_adjust_clicked);

            dw_renewal_cont_adjustments.Constructor += new UserEventDelegate(dw_renewal_cont_adjustments_constructor);
            dw_renewal_cont_adjustments.PfcPreDeleteRow += new UserEventDelegate1(dw_renewal_cont_adjustments_pfc_predeleterow);
            dw_renewal_cont_adjustments.PfcValidation += new UserEventDelegate1(dw_renewal_cont_adjustments_pfc_validation);
            dw_renewal_cont_adjustments.WinPfcSave += new UserEventDelegate1(this.pfc_save);  //added by jlwang

            ((DContractContractor)dw_contract_contractor.DataObject).CellClick += new EventHandler(dw_contract_contractor_clicked);
            //dw_contract_contractor.ItemChanged += new EventHandler(dw_contract_contractor_itemchanged);
            ((DContractContractor)dw_contract_contractor.DataObject).CellValueChanged += new EventHandler(dw_contract_contractor_itemchanged);
            //((Metex.Windows.DataEntityGrid)dw_contract_contractor.DataObject.GetControlByName("grid")).CellEnter  +=new DataGridViewCellEventHandler(WRenewal2001_CellLeave);

            dw_contract_contractor.PfcValidation += new UserEventDelegate1(dw_contract_contractor_pfc_validation);
            dw_contract_contractor.Constructor += new UserEventDelegate(dw_contract_contractor_constructor);
            dw_contract_contractor.WinPfcSave += new UserEventDelegate1(pfc_save); //added by jlwang

            dw_contract_vehicle.Constructor += new UserEventDelegate(dw_contract_vehicle_constructor);
            dw_contract_vehicle.PfcPreInsertRow += new UserEventDelegate1(dw_contract_vehicle_pfc_preinsertrow);
            dw_contract_vehicle.PfcPreDeleteRow += new UserEventDelegate1(dw_contract_vehicle_pfc_predeleterow);
            dw_contract_vehicle.PfcInsertRow += new UserEventDelegate(dw_contract_vehicle_pfc_insertrow);
            dw_contract_vehicle.PfcPostUpdate += new UserEventDelegate(dw_contract_vehicle_pfc_postupdate);
            dw_contract_vehicle.PfcValidation += new UserEventDelegate1(dw_contract_vehicle_pfc_validation);
            dw_contract_vehicle.UpdateStart += new UserEventDelegate1(updatestart);
            dw_contract_vehicle.WinPfcSave += new UserEventDelegate1(pfc_save);
            // TJB RPCR_01 July-2010
            // Added to detect change in number of stars selected
            dw_contract_vehicle.Validated += new System.EventHandler(this.dw_contract_vehicle_Validated);

            ((DRenewalArticalCounts)dw_renewal_artical_counts.DataObject).DoubleClick += new EventHandler(dw_renewal_artical_counts_doubleclicked);
            dw_renewal_artical_counts.Constructor += new UserEventDelegate(dw_renewal_artical_counts_constructor);
            dw_renewal_artical_counts.PfcPreInsertRow += new UserEventDelegate1(dw_renewal_artical_counts_pfc_preinsertrow);
            dw_renewal_artical_counts.WinPfcSave += new UserEventDelegate1(this.pfc_save);

            //jlwang:end
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab_renewal = new System.Windows.Forms.TabControl();
            this.tabpage_renewal = new System.Windows.Forms.TabPage();
            this.dw_renewal = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_frequency_adjustment = new System.Windows.Forms.TabPage();
            this.dw_renewal_freq_adjust = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_contract_adjustment = new System.Windows.Forms.TabPage();
            this.dw_renewal_cont_adjustments = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_owners_drivers = new System.Windows.Forms.TabPage();
            this.dw_contract_contractor = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_vehicles = new System.Windows.Forms.TabPage();
            this.dw_contract_vehicle = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_article_count = new System.Windows.Forms.TabPage();
            this.dw_renewal_artical_counts = new NZPostOffice.RDS.Controls.URdsDw();
            this.tab_renewal.SuspendLayout();
            this.tabpage_renewal.SuspendLayout();
            this.tabpage_frequency_adjustment.SuspendLayout();
            this.tabpage_contract_adjustment.SuspendLayout();
            this.tabpage_owners_drivers.SuspendLayout();
            this.tabpage_vehicles.SuspendLayout();
            this.tabpage_article_count.SuspendLayout();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(13, 400);
            this.st_label.Size = new System.Drawing.Size(171, 21);
            this.st_label.Text = "w_renewal2001";
            // 
            // tab_renewal
            // 
            this.tab_renewal.Controls.Add(this.tabpage_renewal);
            this.tab_renewal.Controls.Add(this.tabpage_frequency_adjustment);
            this.tab_renewal.Controls.Add(this.tabpage_contract_adjustment);
            this.tab_renewal.Controls.Add(this.tabpage_owners_drivers);
            this.tab_renewal.Controls.Add(this.tabpage_vehicles);
            this.tab_renewal.Controls.Add(this.tabpage_article_count);
            this.tab_renewal.Location = new System.Drawing.Point(10, 5);
            this.tab_renewal.Multiline = true;
            this.tab_renewal.Name = "tab_renewal";
            this.tab_renewal.SelectedIndex = 0;
            this.tab_renewal.Size = new System.Drawing.Size(590, 390);
            this.tab_renewal.TabIndex = 1;
            this.tab_renewal.SelectedIndexChanged += new System.EventHandler(this.tab_renewal_selectionchanged);
            // 
            // tabpage_renewal
            // 
            this.tabpage_renewal.Controls.Add(this.dw_renewal);
            this.tabpage_renewal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_renewal.Location = new System.Drawing.Point(4, 22);
            this.tabpage_renewal.Name = "tabpage_renewal";
            this.tabpage_renewal.Size = new System.Drawing.Size(582, 364);
            this.tabpage_renewal.TabIndex = 0;
            this.tabpage_renewal.Tag = "ComponentName=Renewal;";
            this.tabpage_renewal.Text = "Renewal";
            this.tabpage_renewal.Visible = false;
            // 
            // dw_renewal
            // 
            this.dw_renewal.DataObject = null;
            this.dw_renewal.FireConstructor = false;
            this.dw_renewal.Location = new System.Drawing.Point(5, 5);
            this.dw_renewal.Name = "dw_renewal";
            this.dw_renewal.Size = new System.Drawing.Size(600, 320);
            this.dw_renewal.TabIndex = 1;
            this.dw_renewal.Visible = false;
            this.dw_renewal.ItemChanged += new System.EventHandler(this.dw_renewal_itemchanged);
            // 
            // tabpage_frequency_adjustment
            // 
            this.tabpage_frequency_adjustment.Controls.Add(this.dw_renewal_freq_adjust);
            this.tabpage_frequency_adjustment.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_frequency_adjustment.Location = new System.Drawing.Point(4, 22);
            this.tabpage_frequency_adjustment.Name = this.tabpage_frequency_adjustment.Text;
            this.tabpage_frequency_adjustment.Size = new System.Drawing.Size(582, 364);
            this.tabpage_frequency_adjustment.TabIndex = 1;
            this.tabpage_frequency_adjustment.Tag = "ComponentName=Frequency Adjustment;";
            this.tabpage_frequency_adjustment.Text = "Frequency Adjustment";
            // 
            // dw_renewal_freq_adjust
            // 
            this.dw_renewal_freq_adjust.DataObject = null;
            this.dw_renewal_freq_adjust.FireConstructor = false;
            this.dw_renewal_freq_adjust.Location = new System.Drawing.Point(5, 7);
            this.dw_renewal_freq_adjust.Name = "dw_renewal_freq_adjust";
            this.dw_renewal_freq_adjust.Size = new System.Drawing.Size(571, 326);
            this.dw_renewal_freq_adjust.TabIndex = 1;
            // 
            // tabpage_contract_adjustment
            // 
            this.tabpage_contract_adjustment.Controls.Add(this.dw_renewal_cont_adjustments);
            this.tabpage_contract_adjustment.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_contract_adjustment.Location = new System.Drawing.Point(4, 22);
            this.tabpage_contract_adjustment.Name = "tabpage_contract_adjustment";
            this.tabpage_contract_adjustment.Size = new System.Drawing.Size(582, 364);
            this.tabpage_contract_adjustment.TabIndex = 2;
            this.tabpage_contract_adjustment.Tag = "ComponentName=Contract Adjustment;";
            this.tabpage_contract_adjustment.Text = "Contract Adjustment";
            this.tabpage_contract_adjustment.Visible = false;
            // 
            // dw_renewal_cont_adjustments
            // 
            this.dw_renewal_cont_adjustments.DataObject = null;
            this.dw_renewal_cont_adjustments.FireConstructor = false;
            this.dw_renewal_cont_adjustments.Location = new System.Drawing.Point(5, 7);
            this.dw_renewal_cont_adjustments.Name = "dw_renewal_cont_adjustments";
            this.dw_renewal_cont_adjustments.Size = new System.Drawing.Size(571, 326);
            this.dw_renewal_cont_adjustments.TabIndex = 1;
            this.dw_renewal_cont_adjustments.ItemChanged += new System.EventHandler(this.dw_renewal_cont_adjustments_itemchanged);
            // 
            // tabpage_owners_drivers
            // 
            this.tabpage_owners_drivers.Controls.Add(this.dw_contract_contractor);
            this.tabpage_owners_drivers.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_owners_drivers.Location = new System.Drawing.Point(4, 22);
            this.tabpage_owners_drivers.Name = "tabpage_owners_drivers";
            this.tabpage_owners_drivers.Size = new System.Drawing.Size(582, 364);
            this.tabpage_owners_drivers.TabIndex = 3;
            this.tabpage_owners_drivers.Tag = "ComponentName=Renewal Owner Drivers;";
            this.tabpage_owners_drivers.Text = "Owner Drivers";
            this.tabpage_owners_drivers.Visible = false;
            // 
            // dw_contract_contractor
            // 
            this.dw_contract_contractor.DataObject = null;
            this.dw_contract_contractor.FireConstructor = false;
            this.dw_contract_contractor.Location = new System.Drawing.Point(5, 7);
            this.dw_contract_contractor.Name = "dw_contract_contractor";
            this.dw_contract_contractor.Size = new System.Drawing.Size(571, 326);
            this.dw_contract_contractor.TabIndex = 1;
            this.dw_contract_contractor.GotFocus += new System.EventHandler(this.dw_contract_contractor_getfocus);
            // 
            // tabpage_vehicles
            // 
            this.tabpage_vehicles.Controls.Add(this.dw_contract_vehicle);
            this.tabpage_vehicles.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_vehicles.Location = new System.Drawing.Point(4, 22);
            this.tabpage_vehicles.Name = "tabpage_vehicles";
            this.tabpage_vehicles.Size = new System.Drawing.Size(582, 364);
            this.tabpage_vehicles.TabIndex = 4;
            this.tabpage_vehicles.Tag = "ComponentName=Renewal Vehicles;";
            this.tabpage_vehicles.Text = "Vehicles";
            this.tabpage_vehicles.Visible = false;
            // 
            // dw_contract_vehicle
            // 
            this.dw_contract_vehicle.DataObject = null;
            this.dw_contract_vehicle.FireConstructor = false;
            this.dw_contract_vehicle.Location = new System.Drawing.Point(5, 7);
            this.dw_contract_vehicle.Name = "dw_contract_vehicle";
            this.dw_contract_vehicle.Size = new System.Drawing.Size(578, 350);
            this.dw_contract_vehicle.TabIndex = 1;
            // 
            // tabpage_article_count
            // 
            this.tabpage_article_count.Controls.Add(this.dw_renewal_artical_counts);
            this.tabpage_article_count.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_article_count.Location = new System.Drawing.Point(4, 22);
            this.tabpage_article_count.Name = "tabpage_article_count";
            this.tabpage_article_count.Size = new System.Drawing.Size(582, 364);
            this.tabpage_article_count.TabIndex = 5;
            this.tabpage_article_count.Tag = "ComponentName=Renewal Article Counts;";
            this.tabpage_article_count.Text = "Article Counts";
            // 
            // dw_renewal_artical_counts
            // 
            this.dw_renewal_artical_counts.DataObject = null;
            this.dw_renewal_artical_counts.FireConstructor = false;
            this.dw_renewal_artical_counts.Location = new System.Drawing.Point(5, 7);
            this.dw_renewal_artical_counts.Name = "dw_renewal_artical_counts";
            this.dw_renewal_artical_counts.Size = new System.Drawing.Size(571, 326);
            this.dw_renewal_artical_counts.TabIndex = 1;
            this.dw_renewal_artical_counts.Click += new System.EventHandler(this.dw_renewal_artical_counts_clicked);
            this.dw_renewal_artical_counts.GotFocus += new System.EventHandler(this.dw_renewal_artical_counts_getfocus);
            // 
            // WRenewal2001
            // 
            this.ClientSize = new System.Drawing.Size(609, 419);
            this.Controls.Add(this.tab_renewal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "WRenewal2001";
            this.Controls.SetChildIndex(this.tab_renewal, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.tab_renewal.ResumeLayout(false);
            this.tabpage_renewal.ResumeLayout(false);
            this.tabpage_frequency_adjustment.ResumeLayout(false);
            this.tabpage_contract_adjustment.ResumeLayout(false);
            this.tabpage_owners_drivers.ResumeLayout(false);
            this.tabpage_vehicles.ResumeLayout(false);
            this.tabpage_article_count.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void WRenewal2001_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int? lContractor = 0;
            string sContractorName = string.Empty;
            ContractContractor CC = dw_contract_contractor.DataObject.Current as ContractContractor;
            if (dw_contract_contractor.ModifiedCount() > 0 || dw_contract_contractor.NewCount() > 0 || dw_contract_contractor.DataObject.DeletedCount > 0)
            {
                if (((Metex.Windows.DataEntityGrid)dw_contract_contractor.DataObject.GetControlByName("grid")).Columns[e.ColumnIndex].Name == "contractor_supplier_no")
                {
                    sContractorName = CC.CcontractorName;
                    lContractor = RDSDataService.GetContractorSupplierNoFormContractor(sContractorName);
                    dw_contract_contractor.SetValue(dw_contract_contractor.GetRow(), "contractor_supplier_no", lContractor);
                    dw_contract_contractor.Refresh();
                }
                else if (((Metex.Windows.DataEntityGrid)dw_contract_contractor.DataObject.GetControlByName("grid")).Columns[e.ColumnIndex].Name == "ccontractor_name")
                {
                    lContractor = CC.ContractorSupplierNo;
                    sContractorName = RDSDataService.GetContractorNameFormContractor(lContractor);
                    dw_contract_contractor.SetValue(dw_contract_contractor.GetRow(), "ccontractor_name", sContractorName);

                    dw_contract_contractor.Refresh();
                }
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

        #endregion

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname("Renewal");
            string ls_Title;
            int ll_Null;
            NRdsMsg lnv_msg;
            NCriteria lvn_Criteria;
            lnv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            lvn_Criteria = lnv_msg.of_getcriteria();
            il_contract = Convert.ToInt32(lvn_Criteria.of_getcriteria("Contract_no"));
            il_sequence = Convert.ToInt32(lvn_Criteria.of_getcriteria("Contract_seq_number"));
            // Retrieve first tab
            ((DRenewal)idw_renewal.DataObject).Retrieve(il_contract, il_sequence);
            // Set window title
            ls_Title = "Renewal: " + il_contract.ToString() + '/' + il_sequence.ToString() + ' ' + idw_renewal.GetItem<Renewal>(0).ConTitle;
            // Insert a blank row if no rows are retrieved
            if (idw_renewal.RowCount == 0)
            {
                idw_renewal.InsertRow(0);
            }
            this.Text = ls_Title;
            iw_renewal = this;
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            // Additional security settings
            int? ll_Null;
            // Manually allow maintenance of override rates
            idw_renewal.of_set_deletepriv(false);
            idw_renewal.of_set_createpriv(false);
            // Check if user has edit privileges for the renewal component
            ll_Null = null;
            if (StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege("Renewal Rates", 0, "", true))
            {
                //MSheet lm_sheet = new MSheet(this); ;
                //lm_sheet = this.MenuID;
                //lm_sheet.m_renewalrates.show();

                //?m_sheet.m_renewalrates = new ToolStripMenuItem();
                //? m_sheet.m_renewalrates.Visible = true;
                //?m_sheet.m_renewalrates.Enabled = true;
                //?lm_sheet.m_renewalrates.toolbaritemvisible = true;
                m_sheet._m_renewalrates.Visible = true;

            }
            //  TWC 13/06/2003 Manually showing the article count tab if have privilege
          
            this.tabpage_article_count.Show();

            //  TJB  SR4695  Jan-2007
            //  Create datastores for frequency_distances, [non_]vehicle_override_rate[_history]
            //  tables
            ids_frequency_distances = new DsFrequencyDistances();
            ids_vehicle_override_rate = new DsVehicleOverrideRate();
            ids_non_vehicle_override_rate = new DsNonVehicleOverrideRate();
            ids_non_vehicle_override_rate_history = new DsNonVehicleOverrideRateHistory();
            ids_route_frequency = new DsRouteFrequency();

            // TJB  RD7_0037  Aug2009
            // Get the current vehicle details
            il_contract = (il_contract == null) ? 0 : il_contract;
            il_sequence = (il_sequence == null) ? 0 : il_sequence;
            if (dw_contract_vehicle.RowCount == 0 && il_contract > 0 && il_sequence > 0)
            {
                //((DContractVehicle)dw_contract_vehicle.DataObject).Retrieve(il_contract, il_sequence);
                ((DContractVehicle)dw_contract_vehicle.DataObject).Retrieve(il_contract, il_sequence);
            }
            // TJB  RD7_0037  Aug2009
            // Determine initial vehicle benchmark
            // Save the fuel type and original vehicle number (so we can tell
            // if there's any change).
            dcPrevVehBenchmark = -1;
            int nRow = dw_contract_vehicle.GetRow();
            if (nRow >= 0)
            {
                nPrevVehicle = dw_contract_vehicle.GetItem<ContractVehicle>(nRow).VehicleNumber;
                nPrevFtKey = dw_contract_vehicle.GetItem<ContractVehicle>(nRow).FtKey;
                dcPrevVehBenchmark = wf_getVehBenchmark();
            }

            // TJB RPCR_001 July-2010: implemented
            // TJB  Dec-2009:  Test using stars to display Vehicle Safety Rating
            //  - For testing, use vehicle year to determine the number of stars
            int? VSafety = 0;
            int nStars = 0;
            VSafety = idw_vehicle.GetItem<ContractVehicle>(nRow).VVehicleSafety;
            nStars = (VSafety == null) ? 0 : (int)VSafety;
            ((DContractVehicle)dw_contract_vehicle.DataObject).set_stars(nStars);

            nRow = dw_renewal.RowCount;
            nRow = dw_renewal.GetRow();
            nPrevRgCode = idw_renewal.GetItem<Renewal>(0).ConRgCodeAtRenewal;
            nPrevVolume = idw_renewal.GetItem<Renewal>(0).ConVolumeAtRenewal;
            int? n = nPrevRgCode;
            n = nPrevVolume;

            dw_renewal.URdsDw_GetFocus(null, null);
        }

        #region Methods
        public virtual void ue_open_rates()
        {
            StaticVariables.gnv_app.of_get_parameters().stringparm = this.Text;
            StaticVariables.gnv_app.of_get_parameters().longparm = il_contract;
            StaticVariables.gnv_app.of_get_parameters().integerparm = il_sequence;
            // if g_security.Access_Groups[1] = 7 then
            // 	gnv_App.of_Get_Parameters().booleanparm = (tab_renewal.tabpage_renewal.dw_renewal.getitemstring(1,"con_acceptance_flag") = 'Y')
            // else
            // 	gnv_App.of_Get_Parameters().BooleanParm = True
            // end if
            //  tjb  SR4695  Jan-2007
            if (il_contract > 5999)
            {
                MessageBox.Show("Override rates may only be entered for rural delivery contracts."
                               , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //open(w_contract_rate2001);
            WContractRate2001 w_contract_rate2001 = new WContractRate2001();
            w_contract_rate2001.ShowDialog();
        }

        public override int pfc_save()
        {
            base.pfc_save();
            DialogResult ll_response;
            //  TWC - 4528 - trigger messagebox
            //  TJB  7-Oct-2004  SR4633
            //  Added ib_new_veh_validated to the condition to stop
            //  the message being displayed when the new vehicle
            //  details don't pass validation.
            //   ( See dw_contract_vehicle.updatestart)
            if (ib_new_veh_added && ib_new_veh_validated)
            {
                ll_response = MessageBox.Show("Do you wish to review the overrides for this contract?"
                                             , this.Text
                                             , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ll_response == DialogResult.Yes)
                {
                    ib_new_veh_added = false;
                    //  open the contract_rates2001 window		
                    ue_open_rates();
                }
            }
            //  TJB  SR4695  Jan-2007
            //  Check to see if any of the datastores need to be updated
            //  as a result of deleting a frequency adjustment.
            int ll_fd_delcount;
            int ll_vor_delcount;
            int ll_nvorh_delcount;
            int ll_nvor_modcount = 0;
            int ll_rf_modcount = 0;
            ll_fd_delcount = ids_frequency_distances.DeletedCount;
            ll_vor_delcount = ids_vehicle_override_rate.DeletedCount;
            ll_nvorh_delcount = ids_non_vehicle_override_rate_history.DeletedCount;
            //?ll_nvor_modcount = ids_non_vehicle_override_rate.ModifiedCount;
            //?ll_rf_modcount = ids_route_frequency.ModifiedCount;
            /*  ------------------------- Debugging ------------------------- //
            string	ds_msg
            ds_msg = ""
            if ll_fd_delcount > 0 then
            ds_msg = ds_msg + "Deleting "+ll_fd_delcount.ToString()  &
            + " records from frequency_distances \n"
            end if
            if ll_vor_delcount > 0 then
            ds_msg = ds_msg + "Deleting record "+ll_vor_delcount.ToString()  &
            + " records from vehicle_override_rate \n"
            end if
            if ll_nvorh_delcount > 0 then
            ds_msg = ds_msg + "Deleting "+ll_nvorh_delcount.ToString()  &
            + " records from non_vehicle_override_rate_history \n"
            end if
            if ll_nvor_modcount > 0 then
            ds_msg = ds_msg + "Updating "+ll_nvor_modcount.ToString()  &
            + " records in non_vehicle_override_rate \n"
            end if
            if ll_rf_modcount > 0 then
            ds_msg = ds_msg + "Updating "+ll_rf_modcount.ToString()  &
            + " records in route_frequency \n"
            end if
            MessageBox.Show(ds_msg, "w_renewal2001.pfc_save" )
            // -------------------------------------------------------------  */
            if (ll_fd_delcount > 0)
            {
                //! ids_frequency_distances.Update();
                ids_frequency_distances.Save();
            }
            if (ll_vor_delcount > 0)
            {
                //! ids_vehicle_override_rate.Update();
                ids_vehicle_override_rate.Save();
            }
            if (ll_nvorh_delcount > 0)
            {
                //!ids_non_vehicle_override_rate_history.Update();
                ids_non_vehicle_override_rate_history.Save();
            }
            if (ll_nvor_modcount > 0)
            {
                //!ids_non_vehicle_override_rate.Update();
                ids_non_vehicle_override_rate.Save();
            }
            if (ll_rf_modcount > 0)
            {
                //!ids_route_frequency.Update();
                ids_route_frequency.Save();
            }
            return SUCCESS;
        }

        public virtual string wf_validate_adjustments(int arow)
        {
            string ls_Return = "";
            if (idw_contract_adjustment.GetItem<RenewalAdjustments>(arow).IsDirty/*, 0, primary!) == newmodified!*/)
            {
                idw_contract_adjustment.GetItem<RenewalAdjustments>(arow).CaKey = StaticVariables.gnv_app.of_get_nextsequence("ContractAdjust");
            }
            return ls_Return;
        }

        public virtual string wf_validate_vehicle(int arow)
        {
            string sReturn = "";
            string sMake;
            string sModel;
            string sRegistration;
            string sUserCharge;
            string sLeased;
            string sNull;
            string sTransmission;
            string sStatus;
            int? lvehicleNumber = 0;
            int? lVTKey;
            int? lFTKey;
            int? lCount;
            int? lVNum;
            int? lYear;
            int? lMonth;
            int? lCCRate;
            int? lPurchase;
            int? ldist;
            int? ll_remaining_economic_life;
            int? lSpeedoKms;
            int? ll_salvage;
            int? lSafety;
            int? lEmissions;
            int? lConsumption;
            DateTime? dPurchase;
            DateTime? dSpeedoDate;
            DateTime? ld_purchased_date;
            int? ll_VSKey;
            string s_Null = string.Empty;
            int SQLCode = 0;
            string SQLErrText = "";

            //  TJB  SR4441, 9 May 2004
            //  Added speedo kms, date columns to vehicle table
            //  Added them to d_contract_vehicle
            //  Added to update/insert code below
            //  TJB  SR4665  Aug 2005
            //  Added salvage value
            sNull = null;
            /*?if (idw_vehicle.uf_not_entered(arow, "v_vehicle_registration_number", "reg no")) {
                sReturn = "v_vehicle_registration_number";
                return sReturn;
            }*/
            lVTKey = idw_vehicle.GetItem<ContractVehicle>(arow).VtKey;
            lFTKey = idw_vehicle.GetItem<ContractVehicle>(arow).FtKey;
            sMake = idw_vehicle.GetItem<ContractVehicle>(arow).VVehicleMake;
            sModel = idw_vehicle.GetItem<ContractVehicle>(arow).VVehicleModel;
            lYear = idw_vehicle.GetItem<ContractVehicle>(arow).VVehicleYear;
            lMonth = idw_vehicle.GetItem<ContractVehicle>(arow).VVehicleMonth;
            sRegistration = idw_vehicle.GetItem<ContractVehicle>(arow).VVehicleRegistrationNumber;
            lCCRate = idw_vehicle.GetItem<ContractVehicle>(arow).VVehicleCcRating;
            sUserCharge = idw_vehicle.GetItem<ContractVehicle>(arow).VRoadUserChargesIndicator ? "Y" : "N";
            dPurchase = idw_vehicle.GetItem<ContractVehicle>(arow).VPurchasedDate;
            lPurchase = idw_vehicle.GetItem<ContractVehicle>(arow).VPurchaseValue;
            ll_salvage = idw_vehicle.GetItem<ContractVehicle>(arow).VSalvageValue;
            sLeased = idw_vehicle.GetItem<ContractVehicle>(arow).VLeased ? "Y" : "N";
            ll_VSKey = idw_vehicle.GetItem<ContractVehicle>(arow).VsKey;
            ll_remaining_economic_life = idw_vehicle.GetItem<ContractVehicle>(arow).VRemainingEconomicLife;
            sTransmission = idw_vehicle.GetItem<ContractVehicle>(arow).VVehicleTransmission;
            lSpeedoKms = idw_vehicle.GetItem<ContractVehicle>(arow).VVehicleSpeedoKms;
            dSpeedoDate = idw_vehicle.GetItem<ContractVehicle>(arow).VVehicleSpeedoDate;
            // TJB RPCR_001 July-2010
            // Added Safety (stars) Emissions and Consumption
            lSafety = idw_vehicle.GetItem<ContractVehicle>(arow).VVehicleSafety;
            lEmissions = idw_vehicle.GetItem<ContractVehicle>(arow).VVehicleEmissions;
            lConsumption = idw_vehicle.GetItem<ContractVehicle>(arow).VVehicleConsumptionRate;
            // TJB  RPCR_001  July-2010
            // Added error checking (SQLCode, SQLErrText)
            if (StaticFunctions.f_nempty(idw_vehicle.GetItem<ContractVehicle>(arow).VehicleNumber))
            {
                lvehicleNumber = StaticVariables.gnv_app.of_get_nextsequence("vehicles");
                idw_vehicle.DataObject.SetValue(arow, "vehicle_number", lvehicleNumber);

                RDSDataService.InsertIntoVehicle(lvehicleNumber, lVTKey, lFTKey, sMake, sModel, lYear
                              , sRegistration, lCCRate, sUserCharge, dPurchase, lPurchase, sLeased
                              , lMonth, sTransmission, ll_VSKey, ll_remaining_economic_life, lSpeedoKms
                              , dSpeedoDate, ll_salvage, lSafety, lEmissions, lConsumption
                              , ref SQLCode, ref SQLErrText);

                if (SQLCode != 0)
                    MessageBox.Show("Error inserting new vehicle\n" + SQLErrText, "Error");
            }
            else
            {
                lvehicleNumber = idw_vehicle.GetItem<ContractVehicle>(arow).VehicleNumber;

                RDSDataService.UpdateVehicle(lVTKey, lFTKey, sMake, sModel, lYear, lMonth, sRegistration
                              , lCCRate, sUserCharge, dPurchase, lPurchase, sLeased, sTransmission
                              , ll_VSKey, ll_remaining_economic_life, lSpeedoKms, dSpeedoDate, ll_salvage
                              , lSafety, lEmissions, lConsumption, lvehicleNumber
                              , ref SQLCode, ref SQLErrText);

                if (SQLCode != 0)
                    MessageBox.Show("Error updatinging vehicle details\n" + SQLErrText, "Error");
            }
            //  14/06/2002 PBY SR#4402
            //  Need to make sure the purchased date for the new entry is later
            //  than any prevous entries
            if (idw_vehicle.GetItem<ContractVehicle>(arow).IsDirty 
                && idw_vehicle.GetItem<ContractVehicle>(arow).IsNew/* 0, primary!) == newmodified!*/)
            {
                ld_purchased_date = idw_vehicle.GetItem<ContractVehicle>(arow).VPurchasedDate;
                //  SR#4423 If this is the first vehicle to be inserted, skip the test below
                if (idw_vehicle.RowCount > 1)
                {
                    //if (ld_purchased_date != null && idw_vehicle.DataObject.Find(new KeyValuePair<string, object>("v_purchased_date", ld_purchased_date)) > 0)
                    if (ld_purchased_date != null && find_pruchased_date(1, idw_vehicle.RowCount, ld_purchased_date))
                    {
                        MessageBox.Show("The purchased date has to be later than other existing vehicles' purchase date."
                                       , ""
                                       , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //?is_dberrormsg = "The purchased date has to be later than other existing vehicles\' purchase date.";
                        //idw_vehicle.GetItem<ContractVehicle>(arow).VPurchasedDate = null;
                        return "v_purchased_date";
                    }
                }
            }
            return sReturn;
        }

        private bool find_pruchased_date(int startrow, int endrow, DateTime? ld_purchased_date)
        {
            for (int i = startrow; i < endrow; i++)
            {
                if (idw_vehicle.GetItem<ContractVehicle>(i).VPurchasedDate >= ld_purchased_date)
                    return true;
            }
            return false;
        }

        public virtual bool wf_checkaccepted()
        {
            string sColumn = "";
            string sText = "";
            DateTime? dDate = null;
            int? lContract;
            int? lSequence;
            int lCount = 0;
            if (idw_renewal.GetItem<Renewal>(0).ConStartDate == null)
            {
                sColumn = "con_start_date";
                MessageBox.Show("This renewal cannot be accepted because there is no contract start date entered."
                               , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((idw_renewal.GetItem<Renewal>(0).ConExpiryDate == null))
            {
                sColumn = "con_expiry_date";
                MessageBox.Show("This renewal cannot be accepted because there is no contract expiry date."
                               , this.Text
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (idw_renewal.GetItem<Renewal>(0).ConStartDate > idw_renewal.GetItem<Renewal>(0).ConExpiryDate)
            {
                sColumn = "con_start_date";
                MessageBox.Show("This renewal cannot be accepted because its start date is greater then its expiry date"
                               , this.Text
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (StaticFunctions.f_nempty(idw_renewal.GetItem<Renewal>(0).ConProcessingHoursPerWeek))
            {
                MessageBox.Show("This renewal cannot be accepted because the processing hours per week have not been defined yet."
                               , this.Text
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                sColumn = "con_acceptance_flag";
            }
            else if (StaticFunctions.f_nempty(idw_renewal.GetItem<Renewal>(0).ConRenewalBenchmarkPrice))
            {
                MessageBox.Show("This renewal cannot be accepted because the benchmark price has not been defined yet."
                               , this.Text
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                sColumn = "con_acceptance_flag";
            }
            else if (StaticFunctions.f_nempty(idw_renewal.GetItem<Renewal>(0).ConRenewalPaymentValue))
            {
                MessageBox.Show("This renewal cannot be accepted because the payment value has not been entered yet."
                                , this.Text
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                sColumn = "con_renewal_payment_value";
            }
            else if (StaticFunctions.f_nempty(idw_renewal.GetItem<Renewal>(0).ConVolumeAtRenewal))
            {
                MessageBox.Show("This renewal cannot be accepted because the volume has not been entered yet."
                               , this.Text
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                sColumn = "con_volume_at_renewal";
            }
            else if (StaticFunctions.f_nempty(idw_renewal.GetItem<Renewal>(0).ConDelHrsWeekAtRenewal))
            {
                MessageBox.Show("This renewal cannot be accepted because the delivery hours per week has not been entered yet."
                               , this.Text
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                sColumn = "con_del_hrs_week_at_renewal";
            }
            else if (StaticFunctions.f_nempty(idw_renewal.GetItem<Renewal>(0).ConDistanceAtRenewal))
            {
                MessageBox.Show("This renewal cannot be accepted because the distance has not been entered yet."
                               , this.Text
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                sColumn = "con_distance_at_renewal";
            }
            else if (StaticFunctions.f_nempty(idw_renewal.GetItem<Renewal>(0).ConNoCustomersAtRenewal))
            {
                MessageBox.Show("This renewal cannot be accepted because the number of customers has not been entered yet."
                               , this.Text
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                sColumn = "con_no_customers_at_renewal";
            }
            else
            {
                lContract = idw_renewal.GetItem<Renewal>(0).ContractNo;
                lSequence = idw_renewal.GetItem<Renewal>(0).ContractSeqNumber;
                //select con_expiry_date into :dDate from contract_renewals 
                // where contract_no = :lContract and contract_seq_number = :lSequence;
                dDate = RDSDataService.GetConExpiryDateFromContractRenewals(lContract, lSequence);
                if (dDate < idw_renewal.GetItem<Renewal>(0).ConStartDate)
                {
                    sColumn = "con_start_date";
                    MessageBox.Show("This renewal cannot be accepted because its start date occurs before the previous renewals expiry date."
                                   , this.Text
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //select count(*) into :lCount from contractor_renewals 
                    // where contract_no = :lContract and contract_seq_number = :lSequence;
                    lCount = RDSDataService.GetContractorRenewalsCount2(lContract, lSequence);
                    if (StaticFunctions.f_nempty(lCount))
                    {
                        MessageBox.Show("This renewal cannot be accepted because there are no owner drivers attached to it yet."
                                       , this.Text
                                       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sColumn = "con_acceptance_flag";
                    }
                    else
                    {
                        //  PBY 12/06/2002 SR#4402			
                        // select count(*) into :lCount
                        //   from contract_vehical
                        //  where contract_no = :lContract
                        //    and contract_seq_number = :lSequence
                        //    and cv_vehical_status = 'A';

                        //select f_GetLatestVehicle ( :lContract, :lSequence) into :lCount from dummy;
                        lCount = RDSDataService.GetLatestVehicleFormDummy(lContract, lSequence);
                        if (StaticFunctions.f_nempty(lCount))
                        {
                            MessageBox.Show("This renewal cannot be accepted because there are no vehicles attached to it yet."
                                           , this.Text
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sColumn = "con_acceptance_flag";
                        }
                    }
                }
            }
            if (sColumn != "")
            {
                idw_renewal.DataObject.GetControlByName(sColumn).Focus();
            }
            return sColumn == "";
        }

        public virtual int wf_add_frequency_adjustment(int ai_contractno, int ai_sequenceno, System.Decimal adc_newbenchmark, System.Decimal adc_prevbenchmark)
        {
            //  TJB  8-Oct-2004  SR4633   ( new)
            //  Called from dw_contract_vehicle.pfc_postupdate when a new 
            //  vehicle has been entered and a frequency adjustment is needed.
            // 
            //  Return code
            //    1    Successfully added a frequency adjustment
            //    0    Didn't add a frequency adjustment
            //   -1    Error preparing for or actually adding the adjusment
            System.Decimal ldc_ruc_amount;
            int li_return = 0;
            NFrequencyAdjustment n_freq;
            //  Calculate the adjustment amount
            ldc_ruc_amount = adc_newbenchmark - adc_prevbenchmark;
            //  Create the adjustment
            //  Note: the of_save function creates both a frequency_adjustment 
            //  record and a corresponding frequency_distances record.
            n_freq = new NFrequencyAdjustment();
            n_freq.of_set_contract(ai_contractno, ai_sequenceno);
            //  TJB  RD7_0037  Aug2009: Changed wording
            n_freq.is_reason = "Change in value resulting from change in vehicle.";
            //  Use today's date as the effective date
            n_freq.of_set_effective_date(DateTime.Today);
            n_freq.is_confirmed = "N";
            n_freq.idc_new_benchmark = adc_newbenchmark;
            n_freq.idc_amount_to_pay = ldc_ruc_amount;
            n_freq.idc_adjustment_amount = ldc_ruc_amount;
            li_return = n_freq.of_save();
            //  Tell the user what's been done.
            if (li_return > 0)
            {
                //?Commit;
                li_return = 1;
            }
            else
            {
                //?Rollback;
                MessageBox.Show("A frequency adjustment insert failed. \n" 
                                  + "The sql error code was " + li_return.ToString() + "\n" 
                                  + "The insert has been rolled back."
                               , "ERROR"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                li_return = -(1);
            }
            return li_return;
        }

        public virtual int of_check_veh_override(int al_contract, int al_seq, DateTime ad_effective)
        {
            //  TJB  SR4695  Jan-2007
            //  Looks for a record in the vehicle_override_rate table
            //  Returns
            // 		-1		Error
            // 		 0		Record not found
            // 		>0		Record found
            int ll_distance;
            int ll_boxes;
            int ll_rural;
            int ll_other;
            int ll_private;
            int ll_POs;
            int ll_cmbs;
            int ll_cmb_custs;
            int ll_del_hrs;
            int ll_proc_hrs;
            int ll_volume;
            int ll_row;
            int ll_rows;
            string ls_search;
            //ls_search = "vor_effective_date = " + String(ad_effective, "yyyy-mm-dd");
            ll_rows = ids_vehicle_override_rate.RowCount;
            ll_row = ids_vehicle_override_rate.Find(new KeyValuePair<string, object>("vor_effective_date", ad_effective));
            //  ll_row will be -1 or -5 if an error occurs,
            //  0 if the record was not found
            if (ll_row < 0)
            {
                ll_row = -(1);
            }
            return ll_row;
        }

        public virtual int of_check_nonveh_override_history(int al_contract, int al_seq, DateTime ad_effective)
        {
            //  TJB  SR4695  Jan-2007
            //  Looks for a record in the non_vehicle_override_rate_history table
            //  Returns
            // 		-1		Error
            // 		 0		Record not found
            // 		>0		Record found
            int ll_distance;
            int ll_boxes;
            int ll_rural;
            int ll_other;
            int ll_private;
            int ll_POs;
            int ll_cmbs;
            int ll_cmb_custs;
            int ll_del_hrs;
            int ll_proc_hrs;
            int ll_volume;
            int ll_row;
            int ll_rows;
            string ls_search;
            //ls_search = "nvor_effective_date = " + String(ad_effective, "yyyy-mm-dd");
            ll_rows = ids_non_vehicle_override_rate_history.RowCount;
            ll_row = ids_non_vehicle_override_rate_history.Find(new KeyValuePair<string, object>("nvor_effective_date", ad_effective));
            //  ll_row will be -1 or -5 if an error occurs,
            //  0 if the record was not found
            if (ll_row < 0)
            {
                ll_row = -(1);
            }
            return ll_row;
        }

        public virtual int of_copy_nvor(int al_nvorh_row, int al_nvor_row)
        {
            //  TJB  SR4695  Jan-2007
            // 
            //  Copy data from non_vehicle_override_rate_history 
            //       to non_vehicle_override_rate
            // 
            //  If the nvorh row is 0  ( it won't be less), set the NVOR values to null 
            //   ( because there wasn't a previous NVOR record before before an override 
            //   rate was added that is now being deleted).
            int? ll_wage;
            int? ll_public;
            int? ll_carrier;
            int? ll_acc;
            int? ll_item;
            string ls_frozen;
            int? ll_accounting;
            int? ll_telephone;
            int? ll_sundries;
            int? ll_acc_amount;
            int? ll_uniform;
            int? ll_delivery;
            int? ll_processing;
            if (al_nvorh_row < 1)
            {
                ll_wage = null;
                ll_public = null;
                ll_carrier = null;
                ll_acc = null;
                ll_item = null;
                ls_frozen = null;
                ll_accounting = null;
                ll_telephone = null;
                ll_sundries = null;
                ll_acc_amount = null;
                ll_uniform = null;
                ll_delivery = null;
                ll_processing = null;
            }
            else
            {
                ll_wage = Convert.ToInt32(ids_non_vehicle_override_rate_history.GetItem<NonVehicleOverrideRateHistory>(al_nvorh_row).NvorWageHourlyRate);
                ll_public = Convert.ToInt32(ids_non_vehicle_override_rate_history.GetItem<NonVehicleOverrideRateHistory>(al_nvorh_row).NvorPublicLiabilityRate2);
                ll_carrier = Convert.ToInt32(ids_non_vehicle_override_rate_history.GetItem<NonVehicleOverrideRateHistory>(al_nvorh_row).NvorCarrierRiskRate);
                ll_acc = Convert.ToInt32(ids_non_vehicle_override_rate_history.GetItem<NonVehicleOverrideRateHistory>(al_nvorh_row).NvorAccRate);
                ll_item = Convert.ToInt32(ids_non_vehicle_override_rate_history.GetItem<NonVehicleOverrideRateHistory>(al_nvorh_row).NvorItemProcRatePerHour);
                ls_frozen = ids_non_vehicle_override_rate_history.GetItem<NonVehicleOverrideRateHistory>(al_nvorh_row).NvorFrozen;
                ll_accounting = Convert.ToInt32(ids_non_vehicle_override_rate_history.GetItem<NonVehicleOverrideRateHistory>(al_nvorh_row).NvorAccounting);
                ll_telephone = Convert.ToInt32(ids_non_vehicle_override_rate_history.GetItem<NonVehicleOverrideRateHistory>(al_nvorh_row).NvorTelephone);
                ll_sundries = Convert.ToInt32(ids_non_vehicle_override_rate_history.GetItem<NonVehicleOverrideRateHistory>(al_nvorh_row).NvorSundries);
                ll_acc_amount = Convert.ToInt32(ids_non_vehicle_override_rate_history.GetItem<NonVehicleOverrideRateHistory>(al_nvorh_row).NvorAccRateAmount);
                ll_uniform = Convert.ToInt32(ids_non_vehicle_override_rate_history.GetItem<NonVehicleOverrideRateHistory>(al_nvorh_row).NvorUniform);
                ll_delivery = Convert.ToInt32(ids_non_vehicle_override_rate_history.GetItem<NonVehicleOverrideRateHistory>(al_nvorh_row).NvorDeliveryWageRate);
                ll_processing = Convert.ToInt32(ids_non_vehicle_override_rate_history.GetItem<NonVehicleOverrideRateHistory>(al_nvorh_row).NvorProcessingWageRate);
            }

            ids_non_vehicle_override_rate.GetItem<NonVehicleOverrideRate>(al_nvor_row).NvorWageHourlyRate = ll_wage;
            ids_non_vehicle_override_rate.GetItem<NonVehicleOverrideRate>(al_nvor_row).NvorPublicLiabilityRate2 = ll_public;
            ids_non_vehicle_override_rate.GetItem<NonVehicleOverrideRate>(al_nvor_row).NvorCarrierRiskRate = ll_carrier;
            ids_non_vehicle_override_rate.GetItem<NonVehicleOverrideRate>(al_nvor_row).NvorAccRate = ll_acc;
            ids_non_vehicle_override_rate.GetItem<NonVehicleOverrideRate>(al_nvor_row).NvorItemProcRatePerHour = ll_item;
            ids_non_vehicle_override_rate.GetItem<NonVehicleOverrideRate>(al_nvor_row).NvorFrozen = ls_frozen;
            ids_non_vehicle_override_rate.GetItem<NonVehicleOverrideRate>(al_nvor_row).NvorAccounting = ll_accounting;
            ids_non_vehicle_override_rate.GetItem<NonVehicleOverrideRate>(al_nvor_row).NvorTelephone = ll_telephone;
            ids_non_vehicle_override_rate.GetItem<NonVehicleOverrideRate>(al_nvor_row).NvorSundries = ll_sundries;
            ids_non_vehicle_override_rate.GetItem<NonVehicleOverrideRate>(al_nvor_row).NvorAccRateAmount = ll_acc_amount;
            ids_non_vehicle_override_rate.GetItem<NonVehicleOverrideRate>(al_nvor_row).NvorUniform = ll_uniform;
            ids_non_vehicle_override_rate.GetItem<NonVehicleOverrideRate>(al_nvor_row).NvorDeliveryWageRate = ll_delivery;
            ids_non_vehicle_override_rate.GetItem<NonVehicleOverrideRate>(al_nvor_row).NvorProcessingWageRate = ll_processing;
            return SUCCESS;
        }

        public virtual int of_update_route_frequency(System.Decimal adc_distance)
        {
            //   TJB  SR4695  Feb-2007			New
            //  Update the route_frequency table  ( via its datastore), by subtracting
            //  the adc_distance from its rf_distance.
            //  This is called when a frequency_distances record is deleted.
            //  Global values for the contract, sf_key and rf_delivery_days are used 
            //  to identify the record to adjust.  
            // 
            //  Returns
            // 		-1		Error
            // 		 0		No matching row to update
            // 		>1		Route frequency datastore row updated
            int ll_row;
            int ll_rows;
            System.Decimal? ldc_rf_distance;
            System.Decimal? ldc_new_distance;
            string ls_find;
            //  The datastore will have been populated only with records for the 
            //  right contract so we don't need to include the contract number 
            //  in the search string.
            ls_find = "sf_key = " + il_sfKey.ToString() + " and rf_delivery_days = \'" + is_delDays + '\'';
            ll_rows = ((DsRouteFrequency)ids_route_frequency).Retrieve(il_contract);
            if (ll_rows < 0)
            {
                MessageBox.Show("No route_frequency data found for this contract.\n"
                               , "Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                ll_row = -(1);
            }
            else
            {
                ll_row = ids_route_frequency.Find(new KeyValuePair<string, Object>("sf_key", il_sfKey), new KeyValuePair<string, object>("rf_delivery_days", is_delDays));//.Find( ls_find ).Length;
                if (ll_row < 0)
                {
                    MessageBox.Show("Error finding route_frequency row to update.\n" 
                                     + "Searching for\n" 
                                     + "     sf_key        = " + (il_sfKey.ToString()) + '\n' 
                                     + "     delivery_days = " + is_delDays
                                   , "ERROR"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (ll_row == 0)
                {
                    MessageBox.Show("No matching route_frequency row found to update.\n" 
                                     + "Searching for\n" 
                                     + "     sf_key        = " + il_sfKey.ToString() + '\n' 
                                     + "     delivery_days = " + is_delDays
                                   , "Warning"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    ldc_rf_distance = ids_route_frequency.GetItem<NZPostOffice.RDS.Entity.Ruralwin2.RouteFrequency>(ll_row).RfDistance;
                    ldc_new_distance = ldc_rf_distance - adc_distance;
                    ids_route_frequency.GetItem<NZPostOffice.RDS.Entity.Ruralwin2.RouteFrequency>(ll_row).RfDistance = ldc_new_distance;
                }
            }
            return ll_row;
        }

        public virtual int of_check_freq_distances(int al_contract, DateTime ad_effective, int al_sfkey, string as_deldays)
        {
            //  TJB  SR4695  Jan-2007
            //  Looks for a record in the frequency_distances table
            //  Returns
            // 		-1		Error
            // 		 0		Record not found
            // 		 1		Record found: has adjustment values
            // 		 2		Record found: is a global adjustment
            // 		 3		Record found: has no adjustment values
            // 							 ( probably a vehicle or nonvehicle override)
            int? ll_distance;
            int? ll_boxes;
            int? ll_rural;
            int? ll_other;
            int? ll_private;
            int? ll_POs;
            int? ll_cmbs;
            int? ll_cmb_custs;
            int? ll_del_hrs;
            int? ll_proc_hrs;
            int? ll_volume;
            int? ll_rows;
            string ls_search;
            //ls_search = "fd_effective_date = " + String(ad_effective, "yyyy-mm-dd") + " and sf_key = " + al_sfkey.ToString() + " and rf_delivery_days = \'" + as_deldays + '\'';
            ll_rows = ids_frequency_distances.RowCount;
            il_fd_row = ids_frequency_distances.Find(new KeyValuePair<string, object>("fd_effective_date", ad_effective), new KeyValuePair<string, object>("sf_key", al_sfkey), new KeyValuePair<string, object>("rf_delivery_days", as_deldays));// ls_search ).Length;
            //  il_fd_row will be -1 or -5 if an error occurs,
            //  0 if the record was not found
            if (il_fd_row == 0)
            {
                return 0;
            }
            else if (il_fd_row < 0)
            {
                return -(1);
            }
            ll_distance = Convert.ToInt32(ids_frequency_distances.GetItem<FrequencyDistances>(il_fd_row).FdDistance);
            ll_boxes = ids_frequency_distances.GetItem<FrequencyDistances>(il_fd_row).FdNoOfBoxes;
            ll_rural = ids_frequency_distances.GetItem<FrequencyDistances>(il_fd_row).FdNoRuralBags;
            ll_other = ids_frequency_distances.GetItem<FrequencyDistances>(il_fd_row).FdNoOtherBags;
            ll_private = ids_frequency_distances.GetItem<FrequencyDistances>(il_fd_row).FdNoPrivateBags;
            ll_POs = ids_frequency_distances.GetItem<FrequencyDistances>(il_fd_row).FdNoPostOffices;
            ll_cmbs = ids_frequency_distances.GetItem<FrequencyDistances>(il_fd_row).FdNoCmbs;
            ll_cmb_custs = ids_frequency_distances.GetItem<FrequencyDistances>(il_fd_row).FdNoCmbCustomers;
            ll_del_hrs = Convert.ToInt32(ids_frequency_distances.GetItem<FrequencyDistances>(il_fd_row).FdDeliveryHrsPerWeek);
            ll_proc_hrs = Convert.ToInt32(ids_frequency_distances.GetItem<FrequencyDistances>(il_fd_row).FdProcessingHrsWeek);
            ll_volume = Convert.ToInt32(ids_frequency_distances.GetItem<FrequencyDistances>(il_fd_row).FdVolume);
            is_reason = ids_frequency_distances.GetItem<FrequencyDistances>(il_fd_row).FdChangeReason;
            if (is_reason == null)
            {
                is_reason = "null";
            }
            if ((ll_distance == null) && (ll_boxes == null) && (ll_rural == null) && (ll_other == null) && (ll_private == null) && (ll_POs == null) && (ll_cmbs == null) && (ll_cmb_custs == null) && (ll_del_hrs == null) && (ll_proc_hrs == null) && (ll_volume == null))
            {
                if (is_reason.Substring(0, 6) == "Global")
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }
            return 1;
        }

        public virtual void wf_set_security(string ainsert, string adelete, string aupdate)
        {
            // m_Main_Menu mCurrent
            // mCurrent = this.MenuId
            // 
            // If aInsert = 'insert' Then
            // 	mCurrent.m_Record.m_InsertRow.Enabled = True
            // else
            // 	mCurrent.m_Record.m_InsertRow.Enabled = False
            // End If
            // 
            // If aDelete = 'delete' Then
            // 	mCurrent.m_Record.m_DeleteRow.Enabled = True
            // Else
            // 	mCurrent.m_Record.m_DeleteRow.Enabled = False
            // End If
            // 
            // If aUpdate = 'update' Then
            // 	mCurrent.m_Record.m_UpdateDatabase.Enabled = True
            // Else
            // 	mCurrent.m_Record.m_UpdateDatabase.Enabled = False
            // End If
            // 
        }
 
        public virtual void dw_renewal_constructor()
        {
            //?base.constructor();
            dw_renewal.of_setautoinsert(true);
            idw_renewal = dw_renewal;
            dw_renewal.uf_setaudit(true);
            dw_renewal.uf_settag("Renewal");
            dw_renewal.uf_setauditcolumns("con_acceptance_flag");
        }

        public virtual void pfc_preinsertrow()
        {
            //?base.pfc_preinsertrow();
            // Prevent a row from being inserted
            //?return 0;
        }

        public delegate void constructorDelegate();

        public virtual void dw_renewal_freq_adjust_constructor()
        {
            dw_renewal_freq_adjust.of_setautoinsert(true);
            BeginInvoke(new constructorDelegate(dw_renewal_freq_adjust_invoke));
            

            //pp! added extra code to be able to check the Confirmed checkbox only if is HQ, Payroll, System Administrators
            string is_group_list = "HQ, Payroll, System Administrators";
            bool ib_ismemberof = false;
            ib_ismemberof = StaticVariables.gnv_app.inv_Security_Manager.inv_User.of_ismemberof_list(is_group_list);
            
            if (ib_ismemberof)
            {
                ((DRenewalFreqAdjust)(dw_renewal_freq_adjust.DataObject)).StConfirmAccess.Text = "N";
            }
            else
            {
                ((DRenewalFreqAdjust)(dw_renewal_freq_adjust.DataObject)).StConfirmAccess.Text = "Y";
            }//! EO added code

            idw_frequency_adjustment = dw_renewal_freq_adjust;
        }

        //added by jlwang 
        public virtual void dw_renewal_freq_adjust_invoke()
        {
            dw_renewal_freq_adjust.of_set_createpriv(false);
        }

        public virtual void retrieverow()
        {
            il_row++;
        }

        public virtual void dw_renewal_freq_adjust_pfc_deleterow()
        {
            //  TJB  SR4695  Jan-2007
            //  If the frequency adjustment has been deleted OK, delete any 
            //  corresponding frequency distances and override records  ( see pfs_preDeleteRow)
            int ll_rc;
            System.Decimal? ldc_fd_distance;

            //if (ancestorreturnvalue == 1) {
            if (true)
            {
                if (il_del_record >= 1)
                {
                    //  If a frequency_distances record is deleted, the route_distances 
                    //  table needs to be updated as well.
                    ldc_fd_distance = ids_frequency_distances.GetItem<FrequencyDistances>(il_fd_row).FdDistance;
                    if (!((ldc_fd_distance == null)))
                    {
                        ll_rc = of_update_route_frequency(ldc_fd_distance.Value);
                    }
                    ids_frequency_distances.DeleteItemAt(il_fd_row);
                }
                if (il_del_record >= 2)
                {
                    if (il_vor_row > 0)
                    {
                        ids_vehicle_override_rate.DeleteItemAt(il_vor_row.Value);
                    }
                }
                if (il_del_record == 3 && il_nvorh_row > 0)
                {
                    of_copy_nvor(il_nvorh_row.Value - 1, il_nvor_row);
                    ids_non_vehicle_override_rate_history.DeleteItemAt(il_nvorh_row.Value);
                }

                // modified by jlwang: pls check the logic of pb,make sure it the same to pb
                this.pfc_save();         //iw_renewal.pfc_save();
                ll_rc = 0;
                if (ll_rc < 0)
                {
                    MessageBox.Show("Database updates failed!"
                                   , "Warning"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; //return FAILURE;
                }
            }
            return;//return SUCCESS;
        }

        public virtual int dw_renewal_freq_adjust_pfc_predeleterow()
        {
            //?base.pfc_predeleterow();
            //  TJB  SR4695  Jan-2007
            //  If deleting a frequency adjustment, validate the deletion and if OK, 
            //  check for related records in the frequency_distances and vehicle and 
            //  non-vehicle override tables  ( implemented via datastores)
            int ll_row;
            int ll_row2;
            int ll_rows;
            int? ll_seq;
            int? ll_adjustment;
            int? ll_rc;
            int? ll_rc1;
            int? ll_rc2;
            string ls_confirmed;
            string ls_user = string.Empty;
            string ds_table;
            string ds_adjustment;
            string ds_msg = string.Empty;
            DateTime? ld_paid;
            ls_user = StaticVariables.gnv_app.of_getuserid();
            if (ls_user == null || !(ls_user == "sysadmin"))
            {
                MessageBox.Show("Only the system administrator may delete frequency adjustments. "
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;// PREVENT_ACTION;

            }
            il_del_record = 0;
            ll_row = idw_frequency_adjustment.GetSelectedRow(0);
            ll_row2 = idw_frequency_adjustment.GetSelectedRow(ll_row);
            ll_rows = idw_frequency_adjustment.RowCount;
            //  Check that a row has been selected
            if ((ll_row == null) || ll_row < 0)
            {
                MessageBox.Show("Please select an adjustment to be deleted \n"
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;// PREVENT_ACTION;

            }
            ll_seq = idw_frequency_adjustment.GetItem<RenewalFreqAdjust>(ll_row).ContractSeqNumber;
            ll_adjustment = Convert.ToInt32(idw_frequency_adjustment.GetItem<RenewalFreqAdjust>(ll_row).FdAdjustmentAmount);
            ls_confirmed = idw_frequency_adjustment.GetItem<RenewalFreqAdjust>(ll_row).FdConfirmed;
            ld_paid = idw_frequency_adjustment.GetItem<RenewalFreqAdjust>(ll_row).FdPaidToDate;
            id_effective = idw_frequency_adjustment.GetItem<RenewalFreqAdjust>(ll_row).FdEffectiveDate;
            il_sfKey = idw_frequency_adjustment.GetItem<RenewalFreqAdjust>(ll_row).SfKey;
            is_delDays = idw_frequency_adjustment.GetItem<RenewalFreqAdjust>(ll_row).RfDeliveryDays;
            /*select con_active_sequence into :il_current_seq
                    from contract where contract_no = :il_contract using SQLCA;*/
            il_current_seq = RDSDataService.GetConActiveSequenceFromContract(il_contract);

            //  Check that we're dealing with the correct contract renewal
            if (!(ll_seq >= il_current_seq))
            {
                MessageBox.Show("Frequency adjustments may only be deleted \n" 
                                 + " from the current or pending contract renewal."
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;//PREVENT_ACTION;
            }
            //  Check to see if more than one row has been selected
            if (!(ll_row2 == null) && ll_row2 > ll_row)
            {
                MessageBox.Show("Only one frequency adjustment may only be deleted at a time. \n" 
                                 + "Please select the frequency adjustment you want to delete."
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                //  Unselect the rows
                idw_frequency_adjustment.SelectRow(ll_row, false);
                while (ll_row2 > 0)
                {
                    idw_frequency_adjustment.SelectRow(ll_row2, false);
                    ll_row = ll_row2;
                    ll_row2 = idw_frequency_adjustment.GetSelectedRow(ll_row);
                }
                return -1;// PREVENT_ACTION;

            }
            //  Only the last row may be deleted
            if (!(ll_row == ll_rows - 1))
            {
                MessageBox.Show("Only the last frequency adjustment may be deleted."
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                //  Unselect the row
                idw_frequency_adjustment.SelectRow(ll_row, false);
                return -1;// PREVENT_ACTION;
            }
            //  Check that the frequency adjustment has not been confirmed
            if (!(ls_confirmed == null || ls_confirmed == "N"))
            {
                MessageBox.Show("Only frequency adjustments that have not been confirmed may be deleted. \n"
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                //  Unselect the row
                idw_frequency_adjustment.SelectRow(ll_row, false);
                return -1;// PREVENT_ACTION;

            }
            //  Check that the frequency adjustment has not been paid
            if (!(ld_paid == null))
            {
                MessageBox.Show("Only frequency adjustments that have not been paid may be deleted. \n"
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                //  Unselect the row
                idw_frequency_adjustment.SelectRow(ll_row, false);
                return -1;// PREVENT_ACTION;

            }
            //  Check that the selected row is the last unconfirmed adjustment.
            if (!(ll_row == ll_rows))
            {
                //  If the last row isn't the selected row...
                for (ll_row2 = ll_rows - 1; ll_row2 >= 0; ll_row2 -= 1)  //for (ll_row2 = ll_rows; ll_row2 >= 1; ll_row2 -= 1)
                {
                    //  Search back from the end to find the last un-confirmed adjustment.
                    ls_confirmed = idw_frequency_adjustment.GetItem<RenewalFreqAdjust>(ll_row2).FdConfirmed;
                    if (ls_confirmed == null || ls_confirmed == "N")
                    {
                        //  At this point, ll_row2 is the last unconfirmed adjustment
                        //  Break out of the search loop.
                        break;
                    }
                }
                //  At this point, we've found the last unconfirmed adjustment  ( ll_row2).
                //  If this isn't the selected row  ( ll_row), then don't allow
                //  it to be deleted.  
                //  We know there's at least one unconfirmed adjustment since the
                //  selected row  ( ll_row) has already passed that test.  Thus we'll 
                //  never come out of the loop without ll_row2 referring to an 
                //  unconfirmed adjustment.
                if (!(ll_row == ll_row2))
                {
                    MessageBox.Show("Only the last unconfirmed adjustment may be deleted. \n"
                                   , "Warning"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //  Unselect the row.
                    idw_frequency_adjustment.SelectRow(ll_row, false);
                    return -1;// PREVENT_ACTION;

                }
            }
            //  Check for a matching frequency_distances record to also be deleted
            ds_table = "";
            ll_rc = of_check_freq_distances(il_contract, id_effective.Value, il_sfKey.Value, is_delDays);
            //  Returns
            // 	  -1	Error  ( already reported)
            // 		0	No matching record: we won't delete these
            // 		1	There was a matching adjustment: we'll delete it in the 
            // 				pfc_delete if the delete succeeds
            // 		2	There was a matching global adjustment: we can't delete those
            // 		3	There was a null-valued adjustment: if there's a 
            // 				corresponding vehicle override, we may be able to delete it
            if (ll_rc < 0)
            {
                MessageBox.Show("No frequency_distances record found. \n" 
                                 + "Unable to delete the adjustment."
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ll_rc == 1)
            {
                //  There was a matching frequency_distances record
                //  Flag that it and the frequency_adjustments records
                //  can be deleted.
                il_del_record = 1;
                ds_table = "frequency_distances";
            }
            else if (ll_rc == 2)
            {
                MessageBox.Show("Global frequency adjustments may not be deleted. \n"
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ll_rc == 3)
            {
                //  There was a null-valued frequency distances record; 
                // 	check for matching vehicle override records
                //  messagebox ( "Warning",  &
                //  			"Override rate frequency adjustments cannot be deleted at this time. \n" )
                ll_rc = of_check_veh_override(il_contract, il_current_seq, id_effective.Value);
                if (ll_rc < 0)
                {
                    //  Error: already reported
                    il_del_record = 0;
                }
                else if (ll_rc == 0)
                {
                    //  There wasn't a matching vehicle_override_rates record
                    MessageBox.Show("This adjustment is not associated with either a vehicle or non-vehicle override. \n" 
                                     + "Unable to delete the adjustment."
                                   , "Warning"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //  There was a matching vehicle override record
                    //  Flag that it and the frequency_adjustments records
                    //  can be deleted.
                    il_del_record = 2;
                    il_vor_row = ll_rc;
                    ds_table = "vehicle_override_rate";
                    ll_rc = of_check_nonveh_override_history(il_contract, il_current_seq, id_effective.Value);
                    if (ll_rc < 0)
                    {
                        //  Error: already reported
                        il_del_record = 0;
                    }
                    else if (ll_rc > 0)
                    {
                        //  There was a matching non-vehicle override history record
                        //  Flag that it and the frequency_adjustments records
                        //  can be deleted.
                        il_del_record = 3;
                        il_nvorh_row = ll_rc;
                        ds_table = "non_vehicle_override_rate";
                    }
                }
            }
            if (il_del_record > 0)
            {
                ds_adjustment = ll_adjustment.ToString();// String(ll_adjustment, "0.00");
                if (ll_adjustment == null)
                {
                    ds_adjustment = "null";
                }
                if (il_del_record == 1)
                {
                    ds_msg = " record.";
                }
                else if (il_del_record == 2)
                {
                    ds_msg = "\nand vehicle_override_rate records.";
                }
                else if (il_del_record == 3)
                {
                    ds_msg = ",\nvehicle_override_rate and \nnon_vehicle_override_rate records.";
                }
                DialogResult il_rc = MessageBox.Show("Please confirm the deletion:  \n" 
                                                      + "     Renewal  " + il_contract.ToString() + '/' + il_sequence.ToString() + '\n' 
                                                      + "  Adjustment  " + ds_adjustment + '\n' 
                                                      + "      Reason  " + is_reason + "\n\n" 
                                                      + "and associated frequency_distances" + ds_msg
                                                    , "Confirm"
                                                    , MessageBoxButtons.OKCancel, MessageBoxIcon.Question
                                                    , MessageBoxDefaultButton.Button2);
                if (!(il_rc == DialogResult.OK))
                {
                    il_del_record = 0;
                }
            }
            if (il_del_record == 0)
            {
                idw_frequency_adjustment.SelectRow(ll_row, false);

                return -1;// PREVENT_ACTION;
            }
            return SUCCESS;

            //  return PREVENT_ACTION   // testing
        }

        public virtual void dw_renewal_cont_adjustments_constructor()
        {
            string is_group_list = "HQ, Payroll, System Administrators";
            bool ib_ismemberof = false;
            dw_renewal_cont_adjustments.of_setautoinsert(true);
            idw_contract_adjustment = dw_renewal_cont_adjustments;
            ib_ismemberof = StaticVariables.gnv_app.inv_Security_Manager.inv_User.of_ismemberof_list(is_group_list);
            if (ib_ismemberof)
            {
                dw_renewal_cont_adjustments.DataObject.GetControlByName("st_protect_confirm").Text = "N";
            }
            else
            {
                dw_renewal_cont_adjustments.DataObject.GetControlByName("st_protect_confirm").Text = "Y";
            }
        }

        public virtual int dw_renewal_cont_adjustments_pfc_predeleterow()
        {
            if (!(dw_renewal_cont_adjustments.GetItem<RenewalAdjustments>(dw_renewal_cont_adjustments.GetRow()).CaDatePaid == null))
            {
                MessageBox.Show("You may not delete contract adjustments that have been paid."
                               , "Renewal"
                               , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -(1);

            }
            else
            {
                is_delete = true;
                return 1;
            }
        }

        public virtual int dw_renewal_cont_adjustments_pfc_validation()
        {
            string sColumn = "";
            int ll_Row;
            int ll_RowCount;
            ll_RowCount = dw_renewal_cont_adjustments.RowCount;
            dw_renewal_cont_adjustments.DataObject.AcceptText();
            for (ll_Row = 0; ll_Row < ll_RowCount; ll_Row++)
            {
                if (dw_renewal_cont_adjustments.GetItem<RenewalAdjustments>(ll_Row).ContractNo == null)
                {
                    dw_renewal_cont_adjustments.SetValue(ll_Row, "contract_no", il_contract);
                    dw_renewal_cont_adjustments.SetValue(ll_Row, "contract_seq_number", il_sequence);
                }
                sColumn = wf_validate_adjustments(ll_Row);
                if (!(StaticVariables.gnv_app.of_isempty(sColumn)))
                {
                    dw_renewal_cont_adjustments.SetCurrent(ll_Row);
                    dw_renewal_cont_adjustments.DataObject.GetControlByName(sColumn).Focus();
                    return -(1);

                }
            }
            return 1;
        }

        public virtual void dw_contract_contractor_constructor()
        {
            dw_contract_contractor.of_setautoinsert(true);
            idw_owner_drivers = dw_contract_contractor;
            dw_contract_contractor.uf_setaudit(true);
            dw_contract_contractor.uf_settag("Transfer");
            dw_contract_contractor.uf_setauditcolumns("contractor_supplier_no");
            dw_contract_contractor.uf_setauditcolumns("ccontractor_name");
            dw_contract_contractor.uf_setauditcolumns("cr_effective_date");
        }

        public virtual int dw_contract_contractor_pfc_validation()
        {
            int ll_Row;
            int ll_RowCount;
            int lCount = 0;
            int? lSupplier;
            DateTime dMaxDate;
            string sDate = string.Empty;
            string ls_ErrorColumn = "";
            dw_contract_contractor.DataObject.AcceptText();
            ll_RowCount = dw_contract_contractor.RowCount;
            for (ll_Row = 0; ll_Row < ll_RowCount; ll_Row++)
            {
                if (dw_contract_contractor.GetItem<ContractContractor>(ll_Row).ContractNo == null)
                {
                    dw_contract_contractor.SetValue(ll_Row, "Contract_no", il_contract);
                    dw_contract_contractor.SetValue(ll_Row, "Contract_seq_number", il_sequence);
                    dw_contract_contractor.SetValue(ll_Row, "contractor_supplier_no", dw_contract_contractor.GetItem<ContractContractor>(ll_Row).ContractorSupplierNo);
                }
                if (dw_contract_contractor.uf_not_entered(ll_Row, "contractor_supplier_no", "supplier no"))
                {
                    ls_ErrorColumn = "contractor_supplier_no";
                }
                else if (dw_contract_contractor.uf_not_unique(ll_Row, "contractor_supplier_no", "supplier no"))
                {
                    ls_ErrorColumn = "contractor_supplier_no";
                }
                else if (StaticVariables.gnv_app.of_isempty(dw_contract_contractor.GetItem<ContractContractor>(ll_Row).CcontractorName))
                {
                    MessageBox.Show("The supplier entered does not exist on the database"
                                   , "Renewal"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ls_ErrorColumn = "ccontractor_name";
                }
                else if (dw_contract_contractor.uf_not_entered(ll_Row, "cr_effective_date", "effective date"))
                {
                    ls_ErrorColumn = "cr_effective_date";
                }
                else if (dw_contract_contractor.uf_not_unique(ll_Row, "cr_effective_date", "effective date"))
                {
                    ls_ErrorColumn = "cr_effective_date";
                }
                else
                {
                    lSupplier = dw_contract_contractor.GetItem<ContractContractor>(ll_Row).ContractorSupplierNo;
                    //Select count(*) Into :lCount From contractor Where contractor_supplier_no = :lSupplier;
                    lCount = RDSDataService.GetContractorCount2(lSupplier);
                    if (lCount == 0)
                    {
                        MessageBox.Show("The supplier entered does not exist on the database"
                                       , "Renewal"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ls_ErrorColumn = "contractor_supplier_no";
                    }
                    else if (dw_contract_contractor.DataObject.GetItem<ContractContractor>(ll_Row).IsDirty/*, 0, primary!) == newmodified!*/)
                    {
                        //?sDate = dw_contract_contractor.Describe("evaluate(\'string(max(if(contractor_supplier_no=" + lSupplier.ToString() + ", date(\"1900-1-1\")" + ", cr_effective_date))," + "\"YYYY-MM-DD\")" + "\',1)");

                        DateTime? tDate = DateTime.MinValue;
                        foreach (ContractContractor var in dw_contract_contractor.DataObject.BindingSource.List)
                        {
                            if (var.ContractorSupplierNo != lSupplier)
                            {
                                if (tDate < var.CrEffectiveDate)
                                    tDate = var.CrEffectiveDate;
                            }
                        }

                        sDate = tDate.ToString();
                        dMaxDate = DateTime.MinValue;//? System.Convert.ToDateTime(sDate.Substring(0, sDate.IndexOf(' ') - 1));
                        if (!(dMaxDate == null))
                        {
                            if (dw_contract_contractor.GetItem<ContractContractor>(ll_Row).CrEffectiveDate <= dMaxDate)
                            {
                                MessageBox.Show("The effective date for this new owner driver must be greater \n" 
                                                 + "than the effective dates of the other owner drivers."
                                               , "Renewal"
                                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ls_ErrorColumn = "cr_effective_date";
                            }
                            if (dw_contract_contractor.GetValue<DateTime>(ll_Row, "cr_effective_date") < idw_renewal.GetItem<Renewal>(0).ConStartDate)//idw_renewal.GetValue<DateTime>(0, "con_start_date"))
                            {
                                MessageBox.Show("The effective date for this new owner driver must be greater " 
                                                 + "than the renewal start date."
                                               , "Renewal"
                                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ls_ErrorColumn = "cr_effective_date";
                            }
                        }
                        idw_renewal.SetValue(0, "con_date_last_assigned", dw_contract_contractor.GetItem<ContractContractor>(ll_Row).CrEffectiveDate);
                        idw_renewal.DataObject.AcceptText();
                    }
                }
                if (ls_ErrorColumn.Length == 0)
                {
                    return 1;
                }
                else
                {
                    return -(1);
                }
            }
            return 0;
        }

        //added by jlwang
        public virtual void dw_contract_vehicle_invoke()
        {
            dw_contract_vehicle.of_set_deletepriv(false);
        }

        public virtual void dw_contract_vehicle_constructor()
        {
            dw_contract_vehicle.of_setautoinsert(true);
            idw_vehicle = dw_contract_vehicle;
            //  PBY 13/06/2002 SR#4402
            //dw_contract_vehicle.of_set_deletepriv(false);
            BeginInvoke(new constructorDelegate(dw_contract_vehicle_invoke));

            //  TJB  SR4696  Dec 2006
            // 	The system administrator is authorised to change anything (almost)
            //  on the vehicle screen (not vehicle_allowance_paid_to_date).
            //  Here we check to see if the user is a system administrator, 
            //  and if so, set st_systemadmin (and hide it regardless). Each
            //  of the fields turns update protection off if the st_sysadmin
            //  flag is set to "Y". There is no visible indication until the
            //  user clicks on one of the fields.
            string ls_group_list = "System Administrators";
            bool lb_ismember = false;
            lb_ismember = StaticVariables.gnv_app.inv_Security_Manager.inv_User.of_ismemberof_list(ls_group_list);

            if (lb_ismember)
            {
                dw_contract_vehicle.DataObject.GetControlByName("st_sysadmin").Text = "Y";
            }
            else
            {
                dw_contract_vehicle.DataObject.GetControlByName("st_sysadmin").Text = "N";
            }
            dw_contract_vehicle.DataObject.GetControlByName("st_sysadmin").Visible = false;

        }

        public virtual void scrollvertical()
        {
            //  PBY 12/06/2002 SR#4402
            //  Since the Status field is a legacy field and is no longer required,
            //  the following code becomes redundant too.
            // 
            // String 	sRow
            // Long		lRow
            // 
            // This.SetRedraw ( False)
            // 
            // 
            // sRow = This.Describe ( "DataWindow.FirstRowOnPage")
            // 
            // If isNumber ( sRow) Then
            // 	This.SetRow ( Metex.Common.Convert.ToInt32( sRow))
            // End If
            // 
            // If idw_renewal.getitemstring ( 1, "con_acceptance_flag") = "Y" Then
            // 	If idw_Vehicle.GetItemString ( This.GetRow ( ),"cv_vehical_status") = "N" 		&
            // 	Or	gnv_App.of_IsEmpty ( idw_Vehicle.GetItemString ( This.GetRow ( ),"cv_vehical_status"))	Then
            // 		idw_Vehicle.Modify ( "cv_vehical_status.Values='New~tN'")
            // 	Else
            // 		idw_Vehicle.Modify ( "cv_vehical_status.Values='New~tN/Current~tA/Old~tO'")
            // 	End if
            // Else
            // 	idw_Vehicle.Modify ( "cv_vehical_status.Values='New~tN/Current~tA/Old~tO'")
            // End if
            // 
            // This.TriggerEvent ( 'ue_setuprow')
        }

        public virtual void ue_deletestart()
        {
            //  PBY 12/06/2002 SR#4402
            //  Code commented out
            // If  idw_Renewal.getitemstring ( 1, "con_acceptance_flag") = 'Y' &
            // And This.getitemstring ( This.getrow ( ), "cv_vehical_status") = 'A' Then
            // 	MessageBox ( 'Renewal', "This vehicle cannot be deleted because it is defined as being the current one on this renewal and the renewal has been accepted.")
            // 	message.returnvalue = 1
            // ElseIf MessageBox ( "Delete Row", "Do you want to delete the current row?", Question!, YesNo!) = 2 Then
            // 	Message.ReturnValue = 1
            // End If
        }

        public virtual void ue_setuprow()
        {
            //  PBY 12/06/2002 SR#4402
            //  Since status does not hold any meanings, it is not possible to protect the
            //  record based on the status. Instead, all but the latest row is protected.
            // 
            // This.SetRedraw ( False)
            // 
            // If idw_Renewal.getitemstring ( 1, "con_acceptance_flag") = 'Y' &
            // And This.getitemstring ( This.getrow ( ), "cv_vehical_status") = 'A' then
            // 	This.modify ( "datawindow.readonly=yes")
            // End if
            // 
            // This.ResumeLayout ( false )
            // 
        }

        public virtual int updatestart()
        {
            int lRow = 0;
            string sColumn = "";
            int lActionCode = 0;
            lRow = dw_contract_vehicle.GetNextModified(-1);

            while (lRow >= 0)
            {
                sColumn = wf_validate_vehicle(lRow);
                if (!(sColumn == null || sColumn.Trim().Length == 0))
                {
                    dw_contract_vehicle.SetCurrent(lRow);
                    dw_contract_vehicle.DataObject.GetControlByName(sColumn).Focus();
                    lRow = -1;
                    lActionCode = 1;
                    //  TJB  7-Oct-2004  SR4633
                    ib_new_veh_validated = false;
                }
                else
                {
                    lRow = dw_contract_vehicle.GetNextModified(lRow);
                    //  TJB  7-Oct-2004  SR4633
                    ib_new_veh_validated = true;
                }
            }
            return lActionCode;
        }

        public virtual int dw_contract_vehicle_pfc_preinsertrow()
        {
            int li_ReturnCode = 1;
            int li_x;
            int li_rows = 0;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            //li_ReturnCode = ancestorreturnvalue;
            //  TJB  8-Oct-2004  SR4633
            //  Don't allow new vehicles to be added to non-current contracts
            //SELECT count(*) INTO :li_rows FROM contract WHERE contract_no = :il_contract AND con_active_sequence = :il_sequence USING SQLCA;
            li_rows = RDSDataService.GetContractorCount3(il_contract, il_sequence, ref SQLCode, ref SQLErrText);
            if (SQLCode != 0)
            {
                MessageBox.Show("Unable to determine the contract status.\n\n" 
                                 + "Error Text: " + SQLErrText
                               , "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            if (li_rows <= 0)
            {
                //  This is not an active contract
                //  do not create any frequency adjustments
                MessageBox.Show("Adding a new vehicle to an expired or pending contract is not allowed. "
                               , "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;

            }
            //  PBY 12/06/2002 SR#4402
            // if Idw_Renewal.GetItemString ( 1, "con_acceptance_flag") = "Y" then
            // 	idw_Vehicle.Modify ( "cv_vehical_status.Values='New~tN'")
            // 	il_newvehicle = This.GetRow ( )
            // end if
            // 
            // return 1
            //  PBY 14/06/2002 SR#4402
            //  If there is already a new row in the datawindow, do not allow
            //  another new row to be created
            if (li_ReturnCode == 1)
            {
                for (li_x = 0; li_x < dw_contract_vehicle.RowCount; li_x++)
                {
                    if (dw_contract_vehicle.GetItem<ContractVehicle>(li_x).IsNew 
                        || dw_contract_vehicle.GetItem<ContractVehicle>(li_x).IsDirty)
                    {
                        li_ReturnCode = 0;
                        break;
                    }
                }
                //  PBY 20/06/2002 SR#4409
                //  Also need to make sure the row inserted is the very first row in the datawindow
                dw_contract_vehicle.SetCurrent(0);
            }
            return li_ReturnCode;
        }

        // TJB RPCR_01 July-2010
        // Added to detect change in number of stars selected
        private void dw_contract_vehicle_Validated(object sender, EventArgs e)
        {
            // Set VVehicleSafety which marks the record 'Dirty' and triggers an update.
            int nRow, nStars;
            nRow = dw_contract_vehicle.GetRow();
            nStars = ((DContractVehicle)dw_contract_vehicle.DataObject).get_stars();
            dw_contract_vehicle.GetItem<ContractVehicle>(nRow).VVehicleSafety = nStars;
        }

        public virtual int dw_contract_vehicle_pfc_validation()
        {
            int ll_RowCount;
            int ll_Row;
            int ll_start_km;
            string ls_ErrorColumn = "";
            dw_contract_vehicle.DataObject.AcceptText();
            ll_RowCount = dw_contract_vehicle.RowCount;
            //  TJB  7-Oct-2004  SR4633
            ib_new_veh_validated = true;
            for (ll_Row = 0; ll_Row < ll_RowCount; ll_Row++)
            {
                if ((dw_contract_vehicle.GetItem<ContractVehicle>(ll_Row).ContractNo == null))
                {
                    dw_contract_vehicle.SetValue(ll_Row, "Contract_no", il_contract);
                    dw_contract_vehicle.SetValue(ll_Row, "Contract_seq_number", il_sequence);
                    dw_contract_vehicle.SetValue(ll_Row, "vehicle_number", dw_contract_vehicle.GetItem<ContractVehicle>(ll_Row).VehicleNumber);
                }
                if (dw_contract_vehicle.uf_not_entered(ll_Row, "v_vehicle_registration_number", "reg number"))
                {
                    ls_ErrorColumn = "v_vehicle_registration_number";    //"vehicle_v_vehicle_registration_number";
                }
                else if (dw_contract_vehicle.uf_not_entered(ll_Row, "vt_key", "vehicle type"))
                {
                    ls_ErrorColumn = "vt_key";                          //"vehicle_vt_key"
                }
                else if (dw_contract_vehicle.uf_not_entered(ll_Row, "v_vehicle_make", "make"))
                {
                    ls_ErrorColumn = "v_vehicle_make";                  // "vehicle_v_vehicle_make";
                }
                else if (dw_contract_vehicle.uf_not_entered(ll_Row, "ft_key", "fuel type"))
                {
                    ls_ErrorColumn = "ft_key";                          // "vehicle_ft_key";
                    //  PBY 12/06/2002 SR#4402
                    // 	Elseif This.uf_not_entered ( ll_Row, "cv_vehical_status", "status") Then
                    // ls_ErrorColumn = "cv_vehical_status"
                }
                else if (dw_contract_vehicle.uf_not_entered(ll_Row, "v_purchased_date", "purchased date"))
                {
                    ls_ErrorColumn = "v_purchased_date";
                }
                if (ls_ErrorColumn.Length != 0)
                {
                    dw_contract_vehicle.SetCurrent(ll_Row);
                    dw_contract_vehicle.DataObject.GetControlByName(ls_ErrorColumn).Focus();
                    //  TJB  7-Oct-2004  SR4633
                    ib_new_veh_validated = false;
                    return -(1);
                }
            }
            return 1;
        }

        public virtual int dw_contract_vehicle_pfc_predeleterow()
        {
            //  PBY 12/06/2002 SR#4402
            //  Code added
            int li_return_code = 1;// ancestorreturnvalue;
            if (li_return_code == 1/*CONTINUE_ACTION*/)
            {
                //  Check if this row can be deleted
                //  A row cannot be deleted if it is read only, or if it is the only row
                //  left in the datawindow
                if (dw_contract_vehicle.GetRow() > 0)
                {
                    //  this row would be protected
                    li_return_code = 0;// PREVENT_ACTION;
                }
                else if (dw_contract_vehicle.RowCount == 1)
                {
                    //  Cannot delete the only row
                    li_return_code = 0;// PREVENT_ACTION;
                }
            }
            return li_return_code;
        }

        //  TJB  RD7_0037  Aug2009
        //  dw_contract_vehicle_pfc_postupdate() rewritten
        public virtual void dw_contract_vehicle_pfc_postupdate()
        {
            int? nThisFtKey;
            int? nThisVehicle;
            int nRow;
            string adj_type;
            System.Decimal dcThisVehBenchmark;

            nRow = idw_vehicle.GetRow();
            nThisVehicle = idw_vehicle.GetItem<ContractVehicle>(nRow).VehicleNumber;
            nThisFtKey = idw_vehicle.GetItem<ContractVehicle>(nRow).FtKey;
            dcThisVehBenchmark = wf_getVehBenchmark();

            if (ib_new_veh_added)
            {
                adj_type = "new vehicle";
            }
            else if (nPrevFtKey != nThisFtKey)
            {
                adj_type = "fuel type change";
            }
            else
            {
                adj_type = "vehicle change";
            }

            //  If the previous and current benchmarks differ, create a frequency adjustment
            if (dcThisVehBenchmark != dcPrevVehBenchmark)
            {
                int li_rc = wf_add_frequency_adjustment(il_contract, il_sequence, dcThisVehBenchmark, dcPrevVehBenchmark);
                //  If successful, tell the user
                if (li_rc > 0)
                {
                    MessageBox.Show("A frequency adjustment for the " + adj_type + " has been made.\n"
                                     + "Please check and confirm it."
                                   , ""
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (li_rc == 0)
                {
                    MessageBox.Show("A frequency adjustment for the " + adj_type + " was not created."
                                   , "ERROR"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
            // TJB  Feb-2010
            //   Removed this Re-retrieval of the Vehicle records.  It was triggering an 
            //   itemchanged event with a null dw_contract (why??) in some cases and causing 
            //   the application to crash.
            ////  PBY 25/06/2002 SR#4409 Make sure no column is editable after a save
            //((DContractVehicle)dw_contract_vehicle.DataObject).Retrieve(il_contract, il_sequence);
            // TJB  RD7_0037  Aug 2007
            // These are the new "Previous" values
            nPrevVehicle = nThisVehicle;
            nPrevFtKey   = nThisFtKey;
            dcPrevVehBenchmark = dcThisVehBenchmark;
        }

        public virtual void dw_contract_vehicle_pfc_insertrow()
        {
            //  TWC - set inserted vehicle boolean
            ib_new_veh_added = true;
            //?return 1;
        }

        public virtual void dw_renewal_artical_counts_constructor()
        {
            BeginInvoke(new constructorDelegate(dw_renewal_artical_counts_invoke));
            idw_article_count = dw_renewal_artical_counts;
        }

        public virtual void dw_renewal_artical_counts_invoke()
        {
            dw_renewal_artical_counts.of_set_createpriv(false);
            dw_renewal_artical_counts.of_set_deletepriv(false);
        }

        public virtual int dw_renewal_artical_counts_pfc_preinsertrow()
        {
            // Prevent a row from being inserted
            return 0;
        }
        #endregion

        #region Events
        public virtual System.Decimal wf_getVehBenchmark()
        {
                // TJB  RD7_0037  Aug 2007  (New)
                // Determine the vehicle benchmark for the current vehicle
                // Returns -1 if unable to.
            int? nContract;
            int? nSequence;
            int? nVehicle;
            int nRow;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            System.Decimal dcVehBenchmark = -1;

            nRow = idw_vehicle.GetRow();
            if (nRow >= 0)
            {
                nContract = idw_vehicle.GetItem<ContractVehicle>(nRow).ContractNo;
                nSequence = idw_vehicle.GetItem<ContractVehicle>(nRow).ContractSeqNumber;
                nVehicle = idw_vehicle.GetItem<ContractVehicle>(nRow).VehicleNumber;
                dcVehBenchmark = RDSDataService.GetBenchMarkCalcVeh2005(
                                                                       nContract
                                                                     , nSequence
                                                                     , nVehicle
                                                                     , ref SQLCode
                                                                     , ref SQLErrText);
                if (SQLCode != 0)
                {
                    MessageBox.Show("Unable to determine current benchmark.\n\n"
                                     + "Error Code: " + Convert.ToString(SQLCode) + "\n"
                                     + "Error Text: " + SQLErrText
                                   , "Database Error (WRenewal2001.pfc_postupdate)"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dcVehBenchmark = -1;
                }
            }
            return dcVehBenchmark;
        }

        public override void resize(object sender, EventArgs args)
        {
            // override
        }

        //jlwang:change selectindex to name 
        // log in app with different user, the tabpage should be invisible or visible
        // if we use select index to get tagepage it will throw exception. 
        public virtual void tab_renewal_selectionchanged(object sender, EventArgs e)
        {
            int ll_fd_rc;
            int ll_vor_rc;
            int ll_nvor_rc;
            int ll_nvorh_rc;
            int ll_row;

            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            int TestExpr = tab_renewal.SelectedIndex;// newindex;
            string str = tab_renewal.TabPages[tab_renewal.SelectedIndex].Text.ToLower().Trim();
            if (str == "renewal")//(TestExpr == 0)
            {
                idw_renewal.URdsDw_GetFocus(null, null);  //added by jlwang
                // ist_maintenance.dwCurrent = idw_renewal
            }
            else if (str == "frequency adjustment")//(TestExpr == 1)
            {
                idw_frequency_adjustment.URdsDw_GetFocus(null, null); //added by jlwang
                if (idw_frequency_adjustment.RowCount == 0)
                {
                    ((DRenewalFreqAdjust)idw_frequency_adjustment.DataObject).Retrieve(il_contract, il_sequence);
                    //  TJB SR4695  Jan-2007
                    //  If we populate the frequency adjustments, 
                    //  also populate the frequency distances, vehicle and non-vehicle override,
                    //  and non-vehicle override history datastores
                    if (idw_renewal.GetRow() != -1)
                    {
                        id_renewal_start = idw_renewal.GetItem<Renewal>(idw_renewal.GetRow()).ConRatesEffectiveDate;
                    }
                    ll_fd_rc = ((DsFrequencyDistances)ids_frequency_distances).Retrieve(il_contract, id_renewal_start);
                    ll_vor_rc = ((DsVehicleOverrideRate)ids_vehicle_override_rate).Retrieve(il_contract, il_sequence);
                    ll_nvor_rc = ((DsNonVehicleOverrideRate)ids_non_vehicle_override_rate).Retrieve(il_contract, il_sequence);
                    ll_nvorh_rc = ((DsNonVehicleOverrideRateHistory)ids_non_vehicle_override_rate_history).Retrieve(il_contract, il_sequence);
                    //  NOTE: for any particular contract, there will only be one NVOR row
                    il_nvor_row = ids_non_vehicle_override_rate.RowCount;
                }
                if (idw_renewal.RowCount > 0)
                    idw_frequency_adjustment.DataObject.GetControlByName("st_title").Text = idw_renewal.GetItem<Renewal>(0).Contracttitle;
                    ((DRenewalFreqAdjust)idw_frequency_adjustment.DataObject).Retrieve(il_contract, il_sequence);
                // ist_maintenance.dwCurrent = idw_frequency_adjustment
            }
            else if (str == "contract adjustment")//(TestExpr == 2)
            {
                idw_contract_adjustment.Focus();//addded by jlwang

                if (idw_contract_adjustment.RowCount == 0)
                {
                    ((DRenewalAdjustments)idw_contract_adjustment.DataObject).Retrieve(il_contract, il_sequence);
                }
                idw_contract_adjustment.SelectRow(0, false);
                // ist_maintenance.dwCurrent = idw_contract_adjustment
            }
            else if (str == "owner drivers")//(TestExpr == 3)
            {
                dw_contract_contractor_getfocus(null, null); //added by jlwang

                if (idw_owner_drivers.RowCount == 0)
                {
                    ((DContractContractor)idw_owner_drivers.DataObject).Retrieve(il_contract, il_sequence);
                }
                if (idw_renewal.RowCount > 0)
                    idw_owner_drivers.DataObject.GetControlByName("st_title").Text = idw_renewal.GetItem<Renewal>(0).Contracttitle;
                // ist_maintenance.dwCurrent = idw_owner_drivers
            }
            else if (str == "vehicles")//(TestExpr == 4)
            {
                idw_vehicle.URdsDw_GetFocus(null, null); //added by jlwang

                //if (idw_vehicle.RowCount == 0)
                ll_row = idw_vehicle.RowCount;
                if (ll_row == 0)
                {
                    //((DContractVehicle)idw_vehicle.DataObject).Retrieve(il_contract, il_sequence);
                    ((DContractVehicle)idw_vehicle.DataObject).Retrieve(il_contract, il_sequence);
                }
                if (idw_renewal.RowCount > 0)
                {
                    idw_vehicle.DataObject.GetControlByName("st_title").Text = idw_renewal.GetItem<Renewal>(0).Contracttitle;
                }
                // ist_maintenance.dwCurrent = idw_vehicle
            }
            else if (str == "article counts")//(TestExpr == 5)
            {
                //added by jlwang
                dw_renewal_artical_counts_getfocus(null, null);
                if (idw_article_count.RowCount == 0)
                {
                    ((DRenewalArticalCounts)idw_article_count.DataObject).Retrieve(il_contract, il_sequence);
                }
                // ist_maintenance.dwCurrent = idw_article_count
            }
        }

        public virtual void tab_renewal_selectionchanging(object sender, EventArgs e)
        {
            int ll_Ret;
            int ll_Row;
            DialogResult di_ret;

            //?idw_renewal.DataObject.AcceptText();
            //if (idw_renewal.DeletedCount() > 0 || idw_renewal.ModifiedCount() > 0) {
            if (StaticFunctions.IsDirty(idw_renewal.DataObject))
            {
                di_ret = MessageBox.Show("Do you want to update database?"
                                        , "Renewal Update"
                                        , MessageBoxButtons.YesNo
                                        , MessageBoxIcon.Question);
                ll_Row = idw_renewal.GetRow();
                if (di_ret == DialogResult.Yes)
                {
                    // base.pfc_save();
                    ll_Ret = idw_renewal.Save();
                    ((DRenewal)idw_renewal.DataObject).Retrieve(il_contract, il_sequence);
                    if (ll_Ret < 0)
                        return;
                }
                else
                    idw_renewal.DataObject.Reset();
            }
            //?idw_frequency_adjustment.DataObject.AcceptText();
            //if (idw_frequency_adjustment.DeletedCount() > 0 || idw_frequency_adjustment.ModifiedCount() > 0) {
            if (StaticFunctions.IsDirty(idw_frequency_adjustment.DataObject))
            {
                di_ret = MessageBox.Show("Do you want to update database?"
                                        , "Frequency Adjustment Update"
                                        , MessageBoxButtons.YesNo
                                        , MessageBoxIcon.Question);
                ll_Row = idw_frequency_adjustment.GetRow();
                if (di_ret == DialogResult.Yes)
                {
                    //ll_Ret = base.pfc_save();
                    ll_Ret = idw_frequency_adjustment.Save();

                    if (ll_Ret < 0)
                        return;
                }
                else
                    idw_frequency_adjustment.DataObject.Reset();
            }
            //?idw_contract_adjustment.DataObject.AcceptText();
            //if (idw_contract_adjustment.DeletedCount() > 0 || idw_contract_adjustment.ModifiedCount() > 0) {
            if (StaticFunctions.IsDirty(idw_contract_adjustment.DataObject))
            {
                di_ret = MessageBox.Show("Do you want to update database?"
                                        , "Contract Adjustment Update"
                                        , MessageBoxButtons.YesNo
                                        , MessageBoxIcon.Question);
                ll_Row = idw_contract_adjustment.GetRow();
                if (di_ret == DialogResult.Yes)
                {
                    // ll_Ret = base.pfc_save();
                    ll_Ret = idw_contract_adjustment.Save(); 
                    if (ll_Ret < 0)
                        return;
                }
                else
                    idw_contract_adjustment.DataObject.Reset();
            }
            //?idw_owner_drivers.DataObject.AcceptText();
            //if (idw_owner_drivers.DeletedCount() > 0 || idw_owner_drivers.ModifiedCount() > 0) {
            if (StaticFunctions.IsDirty(idw_owner_drivers.DataObject))
            {
                di_ret = MessageBox.Show("Do you want to update database?"
                                        , "Owner Driver Update"
                                        , MessageBoxButtons.YesNo
                                        , MessageBoxIcon.Question);
                ll_Row = idw_owner_drivers.GetRow();
                if (di_ret == DialogResult.Yes)
                {
                    //ll_Ret = base.pfc_save();
                    ll_Ret = idw_owner_drivers.Save();
                    if (ll_Ret < 0)
                        return;
                }
                else
                    idw_owner_drivers.DataObject.Reset();
            }
            //?idw_vehicle.DataObject.AcceptText();
            //if (idw_vehicle.DeletedCount() > 0 || idw_vehicle.ModifiedCount() > 0) {
            ll_Row = idw_vehicle.GetRow();
            if (StaticFunctions.IsDirty(idw_vehicle.DataObject))
            {
                di_ret = MessageBox.Show("Do you want to update the contract_vehicle database?"
                                        , "Vehicle Update"
                                        , MessageBoxButtons.YesNo
                                        , MessageBoxIcon.Question);
                if (di_ret == DialogResult.Yes)
                {
                    //ll_Ret = base.pfc_save();
                    ll_Ret = idw_vehicle.Save();
                    if (ll_Ret < 0)
                        return;
                }
                else
                    idw_vehicle.DataObject.Reset();
            }
        }

        public virtual void dw_renewal_editchanged(object sender, EventArgs e)
        {
            // TJB  RD7_0040  Aug2009   -- New --
            update_con_proc_hrs_wk();
            return;
        }

        public virtual void update_con_proc_hrs_wk()
        {
            // TJB  RD7_0040  Aug2009   -- New --
            int nRow, n;
            int? nRgCode, nVolume, nContractNo, nContractSeqNumber;

            nRow = dw_renewal.GetRow();
            // TJB  RD7_0051  Oct-2009
            // Added ContractNo and ContractSeqNumber parameters 
            // to GetNvrItemProcRatePerHrFromNonVehicleRate call.
            nContractNo = idw_renewal.GetItem<Renewal>(nRow).ContractNo;
            nContractSeqNumber = idw_renewal.GetItem<Renewal>(nRow).ContractSeqNumber;
            nRgCode = idw_renewal.GetItem<Renewal>(nRow).ConRgCodeAtRenewal;
            nVolume = idw_renewal.GetItem<Renewal>(nRow).ConVolumeAtRenewal;
            if (nVolume != nPrevVolume || nRgCode != nPrevRgCode)
            {
                int nProcRatePerHr;
                System.Decimal dProcHours, dVolume, dProcRatePerHr;
                decimal? dProcHrsWk, dpw;
                DateTime? dEffDate;

                dEffDate = idw_renewal.GetItem<Renewal>(nRow).ConRatesEffectiveDate;
                nProcRatePerHr = RDSDataService.GetNvrItemProcRatePerHrFromNonVehicleRate(nContractNo, nContractSeqNumber, nRgCode, dEffDate);
                dProcRatePerHr = Convert.ToDecimal(nProcRatePerHr);
                dVolume = Convert.ToDecimal(dw_renewal.DataObject.GetValue(nRow, "con_volume_at_renewal"));
                System.Decimal dWeeksPerYr = 52.1429M;
                dProcHours = (dProcRatePerHr == null || dProcRatePerHr == 0)
                                     ? 0 
                                     : (dVolume / dProcRatePerHr) / dWeeksPerYr;
                dProcHours = Math.Round(dProcHours, 2);
                dw_renewal.SetValue(nRow, "con_processing_hours_per_week", dProcHours);
                nPrevVolume = nVolume;
                nPrevRgCode = nRgCode;
            }
            return;
        }

        public virtual void dw_renewal_itemchanged(object sender, EventArgs e)
        {
            // TJB  RD7_0040  Aug2009
            // Modified to use new update_con_proc_hrs_wk subroutine (above)

            // base.itemchanged();
            dw_renewal.URdsDw_Itemchanged(sender, e);

            string changed_column = dw_renewal.GetColumnName();
            int nRow = dw_renewal.GetRow();
            if (changed_column == "con_acceptance_flag")
            {
                if (!(wf_checkaccepted()))
                {
                    dw_renewal.SetValue(nRow, "con_acceptance_flag", false);
                }
            }
            else if (changed_column == "con_volume_at_renewal")
            {
                // TJB  RD7_0040  Aug2009
                // Moved code to separate function
                // (suspect code here is never executed)
                update_con_proc_hrs_wk();
            }
            return;
        }

        public virtual void dw_renewal_freq_adjust_itemchanged(object sender, DataGridViewCellEventArgs e)
        {
            dw_renewal_freq_adjust.URdsDw_Itemchanged(sender, e);
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = dw_renewal_freq_adjust.GetColumnName();
            if (TestExpr == "ca_date_occured")
            {
                if (!(StaticVariables.gnv_app.of_sanedate(System.Convert.ToDateTime(dw_renewal_freq_adjust.DataObject.GetValue(dw_renewal_freq_adjust.GetRow(), "ca_date_occured")), "date occurred")))
                {
                    return;//return 2;
                }
            }
        }

        public virtual void dw_renewal_freq_adjust_retrievestart(object sender, RetrieveEventArgs e)
        {
            il_row = 0;
        }

        public virtual void dw_renewal_freq_adjust_clicked(object sender, EventArgs e)
        {
            if (idw_frequency_adjustment.GetRow() >= 0)
            {
                if (idw_frequency_adjustment.IsSelected(idw_frequency_adjustment.GetRow()))
                {
                    idw_frequency_adjustment.SelectRow(idw_frequency_adjustment.GetRow() + 1, false);
                }
                else
                {
                    idw_frequency_adjustment.SelectRow(idw_frequency_adjustment.GetRow() + 1, true);
                }
                // TJB  Jan 2009
                // Added below line (no longer sure why).
                idw_frequency_adjustment.SelectRow(idw_frequency_adjustment.GetRow()+1, true);
                idw_frequency_adjustment.DataObject.SetCurrent(idw_frequency_adjustment.GetRow());
            }
        }

        private bool is_delete = false;
        public virtual void dw_renewal_cont_adjustments_itemchanged(object sender, EventArgs e)
        {
            if (!is_delete)
            {
                // base.itemchanged();
                dw_renewal_cont_adjustments.URdsDw_Itemchanged(sender, e);
                // PowerBuilder 'Choose Case' statement converted into 'if' statement
                string TestExpr = ((DataEntityGrid)dw_renewal_cont_adjustments.GetControlByName("grid")).CurrentColumnName;// dw_renewal_cont_adjustments.GetColumnName();
                if (TestExpr == "ca_date_occured")
                {
                    if (!(StaticVariables.gnv_app.of_sanedate(
                        (dw_renewal_cont_adjustments.DataObject.Current as RenewalAdjustments).CaDateOccured, "date occurred")))
                    {
                        dw_renewal_cont_adjustments.GetItem<RenewalAdjustments>(dw_renewal_cont_adjustments.GetRow()).CaDateOccured = null;

                        return; //return 2;
                    }
                }
            }
            is_delete = false;
        }

        public virtual void dw_contract_contractor_clicked(object sender, EventArgs e)
        {
            //if (Left(dw_contract_contractor.GetObjectAtPointer(), 8) == "pcklst_p") {
            //if (((DataEntityGrid)dw_contract_contractor.GetControlByName("grid")).SelectedColumns.GetColumnName().Substring(0, 8) == "pcklst_p")
            //{
            StaticVariables.gnv_app.of_get_parameters().stringparm = dw_contract_contractor.GetItem<ContractContractor>(dw_contract_contractor.GetRow()).CcontractorName;
            //open(w_qs_contractor);
            WQsContractor w_qs_contractor = new WQsContractor();
            w_qs_contractor.ShowDialog();
            if (StaticVariables.gnv_app.of_get_parameters().longparm > 0)
            {
                dw_contract_contractor.SetValue(dw_contract_contractor.GetRow(), "contractor_supplier_no", StaticVariables.gnv_app.of_get_parameters().longparm);
                dw_contract_contractor.SetValue(dw_contract_contractor.GetRow(), "ccontractor_name", StaticVariables.gnv_app.of_get_parameters().stringparm);
                //?dw_contract_contractor.DataObject.BindingSource.CurrencyManager.Refresh();
            }
            //}
        }

        public virtual void dw_contract_contractor_itemchanged(object sender, EventArgs e)
        {
            //?dw_contract_contractor.URdsDw_Itemchanged(sender, e);
            int? lContractor = 0;
            string sContractorName = string.Empty;
            if ((((DataEntityGrid)dw_contract_contractor.GetControlByName("grid"))).CurrentColumnName == "contractor_supplier_no")
            {
                // lContractor = Convert.ToInt32(dw_contract_contractor.DataObject.GetValue(dw_contract_contractor.GetRow(), "contractor_supplier_no"));
                ContractContractor CC = dw_contract_contractor.DataObject.Current as ContractContractor;
                lContractor = CC.ContractorSupplierNo;

                /*SELECT contractor.c_surname_company || ifnull ( contractor.c_first_names,'',', ' || contractor.c_first_names)  
                    INTO :sContractorName FROM contractor WHERE contractor.contractor_supplier_no = :lContractor   ;*/
                sContractorName = RDSDataService.GetContractorNameFormContractor(lContractor);
                dw_contract_contractor.SetValue(dw_contract_contractor.GetRow(), "ccontractor_name", sContractorName);

            }
            else if ((((DataEntityGrid)dw_contract_contractor.GetControlByName("grid"))).CurrentColumnName == "ccontractor_name")
            {
                if (dw_contract_contractor.DataObject.GetValue(dw_contract_contractor.GetRow(), "ccontractor_name") != null)
                    sContractorName = dw_contract_contractor.DataObject.GetValue(dw_contract_contractor.GetRow(), "ccontractor_name").ToString();
                /*SELECT contractor.contractor_supplier_no into :lContractor 
                   FROM contractor WHERE contractor.c_surname_company || ifnull ( contractor.c_first_names,'',', ' || contractor.c_first_names) = :sContractorName;*/
                lContractor = RDSDataService.GetContractorSupplierNoFormContractor(sContractorName);
                dw_contract_contractor.SetValue(dw_contract_contractor.GetRow(), "contractor_supplier_no", lContractor);
            }
        }

        public virtual void dw_contract_contractor_getfocus(object sender, EventArgs e)
        {
            dw_contract_contractor.URdsDw_GetFocus(null, null);
            // if g_security.u_usergroup = 'National Operations Manager' then
            // 	wf_set_security ( 'insert','','update')
            // elseif g_security.u_usergroup = 'Regional Contracts Managers' then
            // 	wf_set_security ( 'insert','','update')		
            // elseif g_security.u_usergroup = 'RuralPost Manager' and g_security.userid = "GROOMEJ" or g_security.userid = "DRYSDALEP" then
            // 	wf_set_security ( 'insert','delete','update')
            // elseif g_security.u_usergroup = 'RuralPost Manager' and g_security.userid = "GARDINERE" then
            // 	uf_protect ( )
            // 	wf_set_security ( '','','update')
            // elseif g_security.u_usergroup = 'RuralPost Manager' and g_security.userid = "SHOTTERI" then
            // 	uf_protect ( )
            // 	wf_set_security ( '','','')
            // elseif g_security.u_usergroup = 'HO Staff' and g_security.userid = "MCKAYT" or g_security.userid = "HOCKLYJ" then
            // 	uf_protect ( )	
            // 	wf_set_security ( '','','')
            // else
            // 	uf_protect ( )	
            // 	wf_set_security ( '','','')
            // end if
        }

        public virtual void dw_contract_vehicle_itemchanged(object sender, EventArgs e)
        {
            // base.itemchanged();
            dw_contract_vehicle.URdsDw_Itemchanged(sender, e);
            int? lVehicleNo = 0;
            int? lVTKey = 0;
            int? lFTKey = 0;
            int? lYear = 0;
            int? lCCRate = 0;
            int? lPurchase = 0;
            int? lMonth = 0;
            string sRegNo = string.Empty;
            string sMake = string.Empty;
            string sModel = string.Empty;
            string sRoadUSer = string.Empty;
            string sLeased = string.Empty;
            DateTime? dPurchase = new DateTime();
            int SQLCode = 0;

            string column_name = ((Control)sender).Name;
            if (column_name == "v_vehicle_registration_number")
            {
                //int nRow = idw_vehicle.GetRow();
                int nRow = dw_contract_vehicle.GetRow();
                //sRegNo = Convert.ToString(dw_contract_vehicle.DataObject.GetValue(nRow, "v_vehicle_registration_number"));
                sRegNo = (string)dw_contract_vehicle.DataObject.GetValue(nRow, "v_vehicle_registration_number");
                List<VehicleItem> list = new List<VehicleItem>();
                RDSDataService dataService = RDSDataService.GetVehicleList(sRegNo, ref SQLCode);
                list = dataService.VehicleList;
                if (list.Count > 0)
                {
                    lVehicleNo = list[0].Vehicle_number;
                    lVTKey = list[0].Vt_key;
                    lFTKey = list[0].Ft_key;
                    sMake = list[0].V_vehicle_make;
                    sModel = list[0].V_vehicle_model;
                    lYear = list[0].V_vehicle_year;
                    lCCRate = list[0].V_vehicle_cc_rating;
                    sRoadUSer = list[0].V_road_user_charges_indicator;
                    dPurchase = list[0].V_purchased_date;
                    lPurchase = list[0].V_purchase_value;
                    sLeased = list[0].V_leased;
                    lMonth = list[0].V_vehicle_month;
                }
                if (SQLCode == 100)
                {
                    lVehicleNo = null;
                    lVTKey = null;
                    lFTKey = null;
                    sMake = null;
                    sModel = null;
                    lYear = null;
                    lCCRate = null;
                    sRoadUSer = null;
                    dPurchase = null;
                    lPurchase = null;
                    sLeased = null;
                    lMonth = null;
                }
                else
                {
                    dw_contract_vehicle.DataObject.SetValue(nRow, "vehicle_number", lVehicleNo);
                    dw_contract_vehicle.DataObject.SetValue(nRow, "vt_key", lVTKey);
                    dw_contract_vehicle.DataObject.SetValue(nRow, "ft_key", lFTKey);
                    dw_contract_vehicle.DataObject.SetValue(nRow, "v_vehicle_make", sMake);
                    dw_contract_vehicle.DataObject.SetValue(nRow, "v_vehicle_model", sModel);
                    dw_contract_vehicle.DataObject.SetValue(nRow, "v_vehicle_year", lYear);
                    dw_contract_vehicle.DataObject.SetValue(nRow, "v_vehicle_cc_rating", lCCRate);
                    dw_contract_vehicle.GetItem<ContractVehicle>(nRow).VRoadUserChargesIndicator = ("Y" == sRoadUSer);
                    dw_contract_vehicle.DataObject.SetValue(nRow, "v_purchased_date", dPurchase);
                    dw_contract_vehicle.DataObject.SetValue(nRow, "v_purchase_value", lPurchase);
                    dw_contract_vehicle.GetItem<ContractVehicle>(nRow).VLeased = ("Y" == sLeased);
                    dw_contract_vehicle.DataObject.SetValue(nRow, "v_vehicle_month", lMonth);
                }
                //  PBY 12/06/2002 SR#4402
            }
            else if (column_name == "ft_key")      /*"vehicle_ft_key"*/
            {
                int l_ft_key;

                l_ft_key = Convert.ToInt32(dw_contract_vehicle.GetItem<ContractVehicle>(dw_contract_vehicle.GetRow()).FtKey);
                if (l_ft_key == 4)
                {
                    //  This is diesel
                    dw_contract_vehicle.GetItem<ContractVehicle>(dw_contract_vehicle.GetRow()).VRoadUserChargesIndicator = true;// "Y";
                }
                else
                {
                    dw_contract_vehicle.GetItem<ContractVehicle>(dw_contract_vehicle.GetRow()).VRoadUserChargesIndicator = false;// 'N');
                }
            }
            if ( ((DContractVehicle)dw_contract_vehicle.DataObject).Controls.Count > 0 )
            {
                (dw_contract_vehicle.DataObject).BindingSource.CurrencyManager.Refresh();
            }
        }

        public virtual void dw_renewal_artical_counts_doubleclicked(object sender, EventArgs e)
        {
            //  TJB  RD7_0040  Aug 2009
            // Ignore if there's nothing to display
            if (dw_renewal_artical_counts.RowCount < 1) return;

            // if This.RowCount > 0 then
            // 	SetPointer ( HourGlass!)
            // 	if g_Security.Access_Groups[7] > -1 then  // Does the user have access to full functions
            //OpenWithParm(w_full_artical_count_form, dw_renewal_artical_counts);
            StaticMessage.PowerObjectParm = dw_renewal_artical_counts.DataObject;
            WFullArticalCountForm w_full_artical_count_form = new WFullArticalCountForm();
            w_full_artical_count_form.ShowDialog();
            // 	else
            // 		OpenWithParm ( w_Artical_Count_Form, This)
            // 	end if
            // end if
        }

        public virtual void dw_renewal_artical_counts_getfocus(object sender, EventArgs e)
        {
            dw_renewal_artical_counts.URdsDw_GetFocus(null, null);
            //?base.getfocus();
            // if g_security.u_usergroup = 'National Operations Manager' then
            // 	wf_set_security ( '','','update')		
            // end if
            // 
            // if g_security.u_usergroup = 'Regional Contracts Managers' then
            // 	wf_set_security ( '','','update')
            // end if
            // 
            // if g_security.u_usergroup = 'RuralPost Manager' and g_security.userid = "GROOMEJ" or g_security.userid = "DRYSDALEP" then
            // 	wf_set_security ( '','','update')
            // end if
            // 
            // if g_security.u_usergroup = 'RuralPost Manager' and g_security.userid = "GARDINERE" then
            // 	uf_protect ( )
            // 	wf_set_security ( '','','')
            // end if			
            // 
            // if g_security.u_usergroup = 'RuralPost Manager' and g_security.userid = "SHOTTERI" then
            // 	uf_protect ( )
            // 	wf_set_security ( '','','')
            // end if			
            // 
            // if g_security.u_usergroup = 'HO Staff' and g_security.userid = "MCKAYT" or g_security.userid = "HOCKLYJ" then
            // 	uf_protect ( )
            // 	wf_set_security ( '','','')
            // end if
        }

        public virtual void dw_renewal_artical_counts_clicked(object sender, EventArgs e)
        {
            if (dw_renewal_artical_counts.GetRow() >= 0)
            {
                //dw_renewal_artical_counts.SelectRow(0, false);
                //dw_renewal_artical_counts.SelectRow(row, true);

                dw_renewal_artical_counts.SelectAllRows(false);
                dw_renewal_artical_counts.SelectRow(dw_renewal_artical_counts.GetRow() + 1, true);
            }
        }

        #endregion
    }
}
