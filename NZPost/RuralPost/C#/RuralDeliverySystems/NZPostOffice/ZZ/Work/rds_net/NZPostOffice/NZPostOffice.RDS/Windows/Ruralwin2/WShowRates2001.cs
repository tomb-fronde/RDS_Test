using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.RDS.Controls;
using System.Windows.Forms;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataService;
using Metex.Windows;
using NZPostOffice.RDS.Menus;
using NZPostOffice.RDS.Windows.Ruralwin;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WShowRates2001 : WAncestorWindow
    {
        #region Define

        public URdsDw iuo_nonvehiclerates;

        public URdsDw iuo_vehiclerates;

        public URdsDw iuo_vehiclerates_list;

        public URdsDw iuo_fuelrates;

        public URdsDw iuo_piecerates;

        public URdsDw iuo_ratedays;

        public URdsDw iuo_miscrates;

        public NCriteria inv_Criteria;

        public NRdsMsg inv_msg;

        public DateTime? id_renewaldate = DateTime.MinValue;

        public int? il_rg_code;

        public string is_editable = String.Empty;

        public bool ib_RetrievingVehicleList;

        public int il_Rates_Complete;

        public Button icb_freeze;

        public Button icb_delete;

        public WBenchmarkRates2001 iw_caller;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_save;

        public Button cb_close;

        public Label st_1;

        public NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox sle_effdate;

        public TabControl tab_main;

        public TabPage tabpage_renewalrates;

        public TabControl tab_nonvehiclerates;

        public TabPage tabpage_nonvehiclerates;

        public URdsDw dw_nonvehicle;

        public TabPage tabpage_piecerates;

        public URdsDw dw_piecerate;

        public TabPage tabpage_fuelrates;

        public URdsDw dw_fuelrate;

        public TabPage tabpage_ratedays;

        public URdsDw dw_ratedays;

        public TabPage tabpage_miscrates;

        public URdsDw dw_other;

        public Button cb_freeze;

        public TabPage tabpage_vehiclerates;

        public URdsDw dw_vehiclerates;

        public URdsDw dw_vehicletypes;

        public Label st_warn;

        public Button cb_delete;

        public Label st_2;

        #endregion

        public WShowRates2001()
        {
            this.InitializeComponent();

            dw_vehiclerates.DataObject = new DVehicleRates2001();
            dw_vehicletypes.DataObject = new DVehicalTypesList();
            dw_nonvehicle.DataObject = new DNonVehicleRates2005();
            dw_piecerate.DataObject = new DPieceRates2001();
            dw_fuelrate.DataObject = new DFuelRates2001();
            dw_ratedays.DataObject = new DRateDays2001();
            dw_other.DataObject = new DMiscRates2001();

            //? this.tab_main.Controls[0].Controls[0].Controls[4].Visible = false;

            //jlwang:moved from IC
            dw_nonvehicle.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_nonvehicle_constructor);
            dw_piecerate.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_piecerate_constructor);
            dw_ratedays.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_ratedays_constructor);
            dw_fuelrate.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_fuelrate_constructor);
            dw_other.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_other_constructor);
            dw_vehiclerates.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_vehiclerates_constructor);

            dw_vehiclerates.URdsDwEditChanged += new NZPostOffice.RDS.Controls.EventDelegate(dw_vehiclerates_editchanged);
            ((NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox)(
                dw_vehiclerates.DataObject.GetControlByName("vr_salvage_ratio"))).Validated +=
                new EventHandler(dw_vehiclerates_editchanged);
            ((NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox)(
                dw_vehiclerates.DataObject.GetControlByName("vr_nominal_vehicle_value"))).Validated +=
                new EventHandler(dw_vehiclerates_editchanged);

            dw_vehicletypes.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_vehicletypes_constructor);
            dw_vehicletypes.DataObject.RetrieveEnd += new EventHandler(dw_vehicletypes_retrieveend);
            //jlwang:end
            constructor();
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // st_label
            // 
            st_label.Text = "w_show_rates2001";
            st_label.Location = new System.Drawing.Point(8, 400);
            st_label.Visible = false;
            // 
            // cb_save
            // 
            this.cb_save = new Button();
            cb_save.Text = "&Save";
            cb_save.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_save.TabIndex = 1;
            cb_save.Size = new System.Drawing.Size(63, 22);
            cb_save.Location = new System.Drawing.Point(563, 403);
            cb_save.Click += new EventHandler(cb_save_clicked);
            this.Controls.Add(cb_save);
            // 
            // cb_close
            //
            this.cb_close = new Button();
            this.CancelButton = cb_close;
            cb_close.Text = "&Close";
            cb_close.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_close.TabIndex = 3;
            cb_close.Visible = false;
            cb_close.Size = new System.Drawing.Size(67, 22);
            cb_close.Location = new System.Drawing.Point(389, 399);
            cb_close.Click += new EventHandler(cb_close_clicked);
            this.Controls.Add(cb_close);
            // 
            // st_1
            // 
            this.st_1 = new Label();
            st_1.TabStop = false;
            st_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            st_1.Text = "Effec&tive Date:";
            st_1.BackColor = System.Drawing.SystemColors.Control;
            st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_1.Size = new System.Drawing.Size(80, 16);
            st_1.Location = new System.Drawing.Point(421, 8);
            this.Controls.Add(st_1);
            // 
            // sle_effdate
            // 
            this.sle_effdate = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            sle_effdate.Mask = "00/00/0000";//"dd/mm/yyyy";
            sle_effdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            sle_effdate.Enabled = false;
            sle_effdate.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_effdate.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            sle_effdate.TabIndex = 5;
            sle_effdate.Size = new System.Drawing.Size(73, 19);
            sle_effdate.Location = new System.Drawing.Point(503, 4);
            sle_effdate.LostFocus += new EventHandler(sle_effdate_modified);
            this.Controls.Add(sle_effdate);
            // 
            // tab_main
            // 
            tab_main = new TabControl();
            tabpage_renewalrates = new TabPage();
            tab_main.Controls.Add(tabpage_renewalrates);
            tabpage_vehiclerates = new TabPage();
            tab_main.Controls.Add(tabpage_vehiclerates);
            tab_main.Name = "tab_main";
            tab_main.Size = new System.Drawing.Size(623, 390);
            tab_main.Location = new System.Drawing.Point(3, 9);
            tab_main.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.Controls.Add(tab_main);
            // 
            // tabpage_renewalrates
            // 
            this.tab_nonvehiclerates = new TabControl();
            tabpage_renewalrates.Controls.Add(tab_nonvehiclerates);
            cb_freeze = new Button();
            tabpage_renewalrates.Controls.Add(cb_freeze);
            //tabpage_renewalrates.powertiptext = "All rates specific to the renewal group";
            tabpage_renewalrates.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_renewalrates.Text = "Renewal Rates";
            tabpage_renewalrates.Name = tabpage_renewalrates.Text;//

            tabpage_renewalrates.Size = new System.Drawing.Size(615, 377);
            this.tabpage_renewalrates.Location = new System.Drawing.Point(3, 25);
            // 
            // tabpage_vehiclerates
            // 
            dw_vehiclerates = new URdsDw();
            //!dw_vehiclerates.DataObject = new DVehicleRates2001();

            dw_vehicletypes = new URdsDw();
            //!dw_vehicletypes.DataObject = new DVehicalTypesList();

            tabpage_vehiclerates.Controls.Add(dw_vehiclerates);
            tabpage_vehiclerates.Controls.Add(dw_vehicletypes);
            //?tabpage_vehiclerates.powertiptext = "Rates for all vehicle types";
            tabpage_vehiclerates.Text = "Vehicle Rates";
            tabpage_vehiclerates.Name = tabpage_vehiclerates.Text;//

            tabpage_vehiclerates.Size = new System.Drawing.Size(615, 347);
            tabpage_vehiclerates.Location = new System.Drawing.Point(3, 25);
            // 
            // tab_nonvehiclerates
            // 
            this.tab_nonvehiclerates.Name = "tab_nonvehiclerates";
            this.tab_nonvehiclerates.Location = new System.Drawing.Point(5, 4);
            this.tab_nonvehiclerates.Size = new System.Drawing.Size(601, 353);
            tabpage_nonvehiclerates = new TabPage();
            tabpage_piecerates = new TabPage();
            tabpage_fuelrates = new TabPage();
            tabpage_ratedays = new TabPage();
            tabpage_miscrates = new TabPage();
            tab_nonvehiclerates.Controls.Add(tabpage_nonvehiclerates);
            tab_nonvehiclerates.Controls.Add(tabpage_piecerates);
            tab_nonvehiclerates.Controls.Add(tabpage_fuelrates);
            tab_nonvehiclerates.Controls.Add(tabpage_ratedays);
            tab_nonvehiclerates.Controls.Add(tabpage_miscrates);//modyfy by ylwang
            // 
            // tabpage_nonvehiclerates
            //
            dw_nonvehicle = new URdsDw();
            //!dw_nonvehicle.DataObject = new DNonVehicleRates2005();
            tabpage_nonvehiclerates.Controls.Add(dw_nonvehicle);
            tabpage_nonvehiclerates.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_nonvehiclerates.Text = "Non-Vehicle Rates";
            tabpage_nonvehiclerates.Name = tabpage_nonvehiclerates.Text;//

            tabpage_nonvehiclerates.Size = new System.Drawing.Size(593, 300);
            tabpage_nonvehiclerates.Location = new System.Drawing.Point(3, 25);
            // 
            // dw_nonvehicle
            // 
            //?dw_nonvehicle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_nonvehicle.TabIndex = 4;
            dw_nonvehicle.Size = new System.Drawing.Size(508, 330);
            dw_nonvehicle.Location = new System.Drawing.Point(32, 2);
            dw_nonvehicle.GotFocus += new EventHandler(dw_nonvehicle_getfocus);

            //dw_nonvehicle.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_nonvehicle_constructor);

            // 
            // tabpage_piecerates
            // 
            dw_piecerate = new URdsDw();
            //!dw_piecerate.DataObject = new DPieceRates2001();
            tabpage_piecerates.Controls.Add(dw_piecerate);
            //?tabpage_piecerates.powertiptext = "Piece rates for the renewal group";
            tabpage_piecerates.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_piecerates.Text = "Piece Rates";
            tabpage_piecerates.Name = tabpage_piecerates.Text;//

            tabpage_piecerates.Size = new System.Drawing.Size(593, 301);
            tabpage_piecerates.Location = new System.Drawing.Point(3, 25);
            // 
            // dw_piecerate
            // 
            dw_piecerate.TabIndex = 1;
            dw_piecerate.Size = new System.Drawing.Size(581, 263);
            dw_piecerate.Location = new System.Drawing.Point(3, 5);
            dw_piecerate.GotFocus += new EventHandler(dw_piecerate_getfocus);

            //dw_piecerate.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_piecerate_constructor);

            // 
            // tabpage_fuelrates
            // 
            dw_fuelrate = new URdsDw();
            //!dw_fuelrate.DataObject = new DFuelRates2001();

            tabpage_fuelrates.Controls.Add(dw_fuelrate);
            tabpage_fuelrates.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_fuelrates.Text = "Fuel Rates";
            tabpage_fuelrates.Name = tabpage_fuelrates.Text;//

            tabpage_fuelrates.Size = new System.Drawing.Size(593, 301);
            tabpage_fuelrates.Location = new System.Drawing.Point(3, 25);
            // 
            // dw_fuelrate
            // 
            dw_fuelrate.TabIndex = 3;
            dw_fuelrate.Size = new System.Drawing.Size(581, 263);
            dw_fuelrate.Location = new System.Drawing.Point(3, 5);
            dw_fuelrate.GotFocus += new EventHandler(dw_fuelrate_getfocus);

            //dw_fuelrate.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_fuelrate_constructor);
            // 
            // tabpage_ratedays
            // 
            dw_ratedays = new URdsDw();
            //!dw_ratedays.DataObject = new DRateDays2001();
            tabpage_ratedays.Controls.Add(dw_ratedays);
            //?tabpage_ratedays.powertiptext = "Days per annum for the renewal group";
            tabpage_ratedays.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_ratedays.Text = "Days Per Annum";
            tabpage_ratedays.Name = tabpage_ratedays.Text;//

            tabpage_ratedays.Size = new System.Drawing.Size(593, 301);
            tabpage_ratedays.Location = new System.Drawing.Point(3, 25);
            // 
            // dw_ratedays
            // 
            dw_ratedays.TabIndex = 1;
            dw_ratedays.Size = new System.Drawing.Size(581, 263);
            dw_ratedays.Location = new System.Drawing.Point(3, 5);
            dw_ratedays.GotFocus += new EventHandler(dw_ratedays_getfocus);

            //dw_ratedays.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_ratedays_constructor);

            // 
            // tabpage_miscrates
            // 
            dw_other = new URdsDw();
            //!dw_other.DataObject = new DMiscRates2001();
            tabpage_miscrates.Controls.Add(dw_other);
            tabpage_miscrates.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_miscrates.Text = "Other Rates";
            tabpage_miscrates.Size = new System.Drawing.Size(593, 301);
            tabpage_miscrates.Location = new System.Drawing.Point(3, 25);
            tabpage_miscrates.Visible = false;
            tabpage_miscrates.Width = 0;
            // 
            // dw_other
            // 
            dw_other.TabIndex = 4;
            dw_other.Size = new System.Drawing.Size(581, 263);
            dw_other.Location = new System.Drawing.Point(3, 5);

            //dw_other.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_other_constructor);

            // 
            // cb_freeze
            // 
            cb_freeze.Text = "Free&ze Rates";
            cb_freeze.Enabled = false;
            cb_freeze.Visible = true;
            cb_freeze.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_freeze.TabIndex = 2;
            cb_freeze.BringToFront();
            cb_freeze.Size = new System.Drawing.Size(98, 24);
            cb_freeze.Location = new System.Drawing.Point(502, 322);
            cb_freeze.Click += new EventHandler(cb_freeze_clicked);
            // 
            // dw_vehiclerates
            // 
            //?dw_vehiclerates.vscrollbar = false;
            dw_vehiclerates.TabIndex = 1;
            dw_vehiclerates.Size = new System.Drawing.Size(349, 328);
            dw_vehiclerates.Location = new System.Drawing.Point(210, 10);
            dw_vehiclerates.GotFocus += new EventHandler(dw_vehiclerates_getfocus);

            //dw_vehiclerates.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_vehiclerates_constructor);

            // 
            // dw_vehicletypes
            // 
            dw_vehicletypes.TabIndex = 2;
            dw_vehicletypes.Size = new System.Drawing.Size(199, 328);
            dw_vehicletypes.Location = new System.Drawing.Point(3, 10);
            dw_vehicletypes.Click += new EventHandler(dw_vehicletypes_clicked);

            //?dw_vehicletypes.RowFocusChanged += new EventHandler(dw_vehicletypes_rowfocuschanged);

            //dw_vehicletypes.DataObject.RetrieveEnd += new EventHandler(dw_vehicletypes_retrieveend);
            // dw_vehicletypes.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_vehicletypes_constructor);

            // 
            // st_warn
            // 
            this.st_warn = new Label();
            this.st_warn.TabStop = false;
            this.st_warn.Text = "Please complete this set of rates before using it for What-If calculations.";
            this.st_warn.ForeColor = System.Drawing.Color.Red;
            this.st_warn.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.st_warn.Size = new System.Drawing.Size(355, 27);
            this.st_warn.Location = new System.Drawing.Point(3, 403);
            this.st_warn.Visible = false;
            this.Controls.Add(st_warn);
            // 
            // cb_delete
            // 
            this.cb_delete = new Button();
            this.cb_delete.Text = "&Delete Rates";
            this.cb_delete.Enabled = false;
            this.cb_delete.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.cb_delete.TabIndex = 4;
            this.cb_delete.Size = new System.Drawing.Size(93, 22);
            this.cb_delete.Location = new System.Drawing.Point(464, 403);
            this.cb_delete.Click += new EventHandler(cb_delete_clicked);
            this.Controls.Add(cb_delete);
            // 
            // st_2
            //
            this.st_2 = new Label();
            this.st_2.TabStop = false;
            this.st_2.Text = "w_show_rates2001";
            this.st_2.ForeColor = System.Drawing.Color.Gray;
            this.st_2.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.st_2.Size = new System.Drawing.Size(150, 13);
            this.st_2.Location = new System.Drawing.Point(8, 412);
            this.Controls.Add(st_2);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Text = "Rates";
            this.Size = new System.Drawing.Size(638, 460);
            this.Location = new System.Drawing.Point(1, 1);
            this.ResumeLayout();
            this.tab_nonvehiclerates.Selecting += new TabControlCancelEventHandler(tab_nonvehiclerates_Selecting);
            this.tab_nonvehiclerates.SelectedIndexChanged += new EventHandler(tab_nonvehiclerates_SelectedIndexChanged);
        }

        bool dw_piecerate_1_select = false;
        bool dw_fuelrate_1_select = false;
        bool dw_ratedays_1_select = false;
        void tab_nonvehiclerates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tab_nonvehiclerates.SelectedIndex == 1)
            {
                ((Metex.Windows.DataEntityGrid)(dw_piecerate.GetControlByName("grid"))).Rows[0].Selected = dw_piecerate_1_select;
            }
            if (this.tab_nonvehiclerates.SelectedIndex == 2)
            {
                ((Metex.Windows.DataEntityGrid)(dw_fuelrate.GetControlByName("grid"))).Rows[0].Selected = dw_fuelrate_1_select;
            }
            if (this.tab_nonvehiclerates.SelectedIndex == 3)
            {
                ((Metex.Windows.DataEntityGrid)(dw_ratedays.GetControlByName("grid"))).Rows[0].Selected = dw_ratedays_1_select;
            }
        }

        void tab_nonvehiclerates_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                dw_piecerate_1_select = ((Metex.Windows.DataEntityGrid)(dw_piecerate.GetControlByName("grid"))).Rows[0].Selected;
            }
            if (e.TabPageIndex == 2)
            {
                dw_fuelrate_1_select = ((Metex.Windows.DataEntityGrid)(dw_fuelrate.GetControlByName("grid"))).Rows[0].Selected;
            }
            if (e.TabPageIndex == 3)
            {
                dw_ratedays_1_select = ((Metex.Windows.DataEntityGrid)(dw_ratedays.GetControlByName("grid"))).Rows[0].Selected;
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

        public override int closequery()
        {
            base.closequery();
            if (iw_caller != null)
            {
                iw_caller.of_retrievelist();
            }
            return 0;
        }

        public override void pfc_postopen()
        {
            // grab any criteria passed to us
            inv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            inv_Criteria = inv_msg.of_getcriteria();
            id_renewaldate = System.Convert.ToDateTime(inv_Criteria.of_getcriteria("effective_date"));
            il_rg_code = System.Convert.ToInt32(inv_Criteria.of_getcriteria("rg_code"));
            is_editable = inv_Criteria.of_getcriteria("editable").ToString();
            iw_caller = (WBenchmarkRates2001)inv_Criteria.of_getcriteria("caller");
            il_Rates_Complete = System.Convert.ToInt32(inv_Criteria.of_getcriteria("rates_complete"));
            this.of_setup();
            // If new set of rates, copy old vehicle rates for the first vehicle on vehicle rates tab
            if (is_editable == "W")
            {
                of_getvehiclerate();
            }
            if (is_editable == "N")
            {
                cb_save.Enabled = false;
                cb_delete.Enabled = false;
            }
            tab_nonvehiclerates.Controls.Remove(tabpage_miscrates);//added by ylwang
            dw_nonvehicle.DataObject.BindingSource.CurrencyManager.Refresh();
        }

        public override int pfc_preclose()
        {
            base.pfc_preclose();
            //  TJB  SR4661  May 2005
            //  If the non-vehicle rates have been modified, set the 
            //  old hourly wage rate to the new processing wage rate.
            // 
            //  Most of this is repeated in the cb_save.clicked event.
            //  The code here catches a change in the processing wage rate
            //  when the user uses the close-window button.
            int ll_row;
            decimal ldc_temp;
            //?dwitemStatus lis_temp;
            iuo_nonvehiclerates.DataObject.AcceptText();

            if (iuo_nonvehiclerates.ModifiedCount() > 0)
            {
                for (ll_row = 0; ll_row < iuo_nonvehiclerates.RowCount; ll_row++)
                {
                    //lis_temp = iuo_nonvehiclerates.GetItemStatus(ll_row, "nvr_processing_wage_rate", primary!);
                    if (iuo_nonvehiclerates.GetItem<NonVehicleRates2005>(ll_row).IsDirty)// (lis_temp == datamodified!) 
                    {
                        ldc_temp = iuo_nonvehiclerates.GetValue<decimal>(ll_row, "nvr_processing_wage_rate");
                        iuo_nonvehiclerates.SetValue(ll_row, "nvr_wage_hourly_rate", ldc_temp);
                    }
                }
            }
            return SUCCESS;
        }

        #region Methods
        public override int pfc_save()
        {
            //?base.pfc_save();
            return wf_save();
        }

        public virtual int of_setdates()
        {
            int ll_Row;
            DateTime? ld_temp = null;
            for (ll_Row = 0; ll_Row < iuo_fuelrates.RowCount; ll_Row++)
            {
                if (iuo_fuelrates.ModifiedCount() > 0)//? || iuo_fuelrates.DeletedCount() > 0) 
                {
                    iuo_fuelrates.SetValue(ll_Row, "rr_rates_effective_date", id_renewaldate);
                    if (is_editable == "W")
                    {
                        // iuo_fuelrates.SetItemStatus(ll_Row, 0, primary!, newmodified!);
                        ((FuelRates2001)iuo_fuelrates.GetItem<FuelRates2001>(ll_Row)).MarkNewEntity();
                        ((FuelRates2001)iuo_fuelrates.GetItem<FuelRates2001>(ll_Row)).MarkDirtyEntity();
                    }
                }

            }
            for (ll_Row = 0; ll_Row < iuo_nonvehiclerates.RowCount; ll_Row++)
            {
                iuo_nonvehiclerates.SetValue(ll_Row, "nvr_rates_effective_date", id_renewaldate);

                if (is_editable == "W")
                {
                    //iuo_nonvehiclerates.SetItemStatus(ll_Row, "nvr_rates_effective_date", primary!, notmodified!);
                    //?((NonVehicleRates2005)iuo_nonvehiclerates.GetItem<NonVehicleRates2005>(ll_Row)).MarkNotModifiedEntity();
                }
            }
            for (ll_Row = 0; ll_Row < iuo_miscrates.RowCount; ll_Row++)
            {

                if (iuo_miscrates.ModifiedCount() > 0)//?|| iuo_miscrates.DeletedCount() > 0)
                {
                    iuo_miscrates.SetValue(ll_Row, "mr_effective_date", id_renewaldate);
                }

            }
            for (ll_Row = 0; ll_Row < iuo_piecerates.RowCount; ll_Row++)
            {
                ld_temp = iuo_piecerates.GetItem<PieceRates2001>(ll_Row).PrEffectiveDate;//.GetItemDateTime(ll_Row, "pr_effective_date").Date;
                if ((ld_temp == null) || ld_temp != id_renewaldate)
                {
                    iuo_piecerates.SetValue(ll_Row, "pr_effective_date", id_renewaldate);
                }
                if (is_editable == "W")
                {
                    //iuo_piecerates.SetItemStatus(ll_Row, "pr_effective_date", primary!, notmodified!);
                    //?((PieceRates2001)iuo_piecerates.GetItem<PieceRates2001>(ll_Row)).MarkNotModifiedEntity();
                }
            }
            for (ll_Row = 0; ll_Row < iuo_ratedays.RowCount; ll_Row++)
            {
                iuo_ratedays.SetValue(ll_Row, "rr_rates_effective_date"/* "rate_days_rr_rates_effective_date"*/, id_renewaldate);//iuo_ratedays.SetItem(ll_Row, "rate_days_rr_rates_effective_date", id_renewaldate);
                if (is_editable == "W")
                {
                    //iuo_ratedays.SetItemStatus(ll_Row, "rate_days_rr_rates_effective_date", primary!, notmodified!);
                    //?((RateDays2001)iuo_ratedays.GetItem<RateDays2001>(ll_Row)).MarkNotModifiedEntity();
                }
            }
            return 0;
        }

        public override bool of_validate()
        {
            bool bReturn = true;
            int? ll_rgcode;
            int ll_Count;
            DateTime? ld_EffDate;
            int ll_Row;
            ll_rgcode = iuo_nonvehiclerates.GetItem<NonVehicleRates2005>(0).RgCode;
            ld_EffDate = iuo_nonvehiclerates.GetItem<NonVehicleRates2005>(0).NvrRatesEffectiveDate;
            //  Check rg_code
            if (ll_rgcode == 0 || ll_rgcode == null)
            {
                MessageBox.Show("A renewal groups must be specified", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                iuo_nonvehiclerates.DataObject.GetControlByName("rg_code").Focus();
                return false;
            }
            //  Are we entering a date which is earlier than a previous one?
            //SELECT count(*) INTO :ll_Count FROM non_vehicle_rate  WHERE rg_code = :ll_rgCode AND nvr_rates_effective_date > :ld_EffDate;
            ll_Count = RDSDataService.GetNonVehicleRateCount(ll_rgcode, ld_EffDate);

            if (ll_Count > 0)
            {
                MessageBox.Show("A renewal groups rates cannot be defined for a group before a current set of rate" + "s", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //iuo_nonvehiclerates.DataControl["nvr_rates_effective_date"].Focus();
                iuo_nonvehiclerates.DataObject.GetControlByName("nvr_rates_effective_date").Focus();
                return false;
            }
            //  Do we already have a non-frozen rate for a renewal group?
            if (iuo_nonvehiclerates.DataObject.GetItem<NonVehicleRates2005>(0).IsDirty)// (iuo_nonvehiclerates.GetItemStatus(1, 0, primary!) == newmodified!)
            {
                //SELECT count(*) INTO :ll_Count FROM non_vehicle_rate WHERE rg_code = :ll_rgcode AND (nvr_frozen_indicator = 'N' or nvr_frozen_indicator is null);
                ll_Count = RDSDataService.GetNonVehicleRateCount2(ll_rgcode);

                if (ll_Count > 0)
                {
                    MessageBox.Show("A renewal group can only have one non frozen set of renewal rates at any one time" + "", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    iuo_nonvehiclerates.DataObject.GetControlByName("rg_code").Focus();//.DataControl["rg_code"].Focus();
                    return false;
                }
            }
            // Is already one with the same date?
            //SELECT count(*)  INTO :ll_Count  FROM non_vehicle_rate WHERE non_vehicle_rate.rg_code = :ll_rgcode AND non_vehicle_rate.nvr_rates_effective_date = :ld_EffDate ;

            ll_Count = RDSDataService.GetNonVehicleRateCount3(ll_rgcode, ld_EffDate);
            if (ll_Count >= 1 && is_editable == "W")
            {
                MessageBox.Show("There are already rates defined for this renewal group on the entered date", "Rates Already Defined", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //iuo_nonvehiclerates.DataControl["nvr_rates_effective_date"].Focus();
                iuo_nonvehiclerates.DataObject.GetControlByName("nvr_rates_effective_date").Focus();
                return false;
            }
            return true;
        }

        public virtual bool of_set_rgcode(int? al_rgcode)
        {
            int ll_Row;
            // Make sure Misc rates and fuel rates get their rg_codes
            // used by of_validate
            for (ll_Row = 0; ll_Row < iuo_fuelrates.RowCount; ll_Row++)
            {
                if (iuo_fuelrates.ModifiedCount() > 0)//?|| iuo_fuelrates.DeletedCount() > 0) 
                {
                    iuo_fuelrates.SetValue(ll_Row, "rg_code", al_rgcode);
                }
            }
            for (ll_Row = 0; ll_Row < iuo_miscrates.RowCount; ll_Row++)
            {
                if (iuo_miscrates.ModifiedCount() > 0)//?|| iuo_miscrates.DeletedCount() > 0) 
                {
                    iuo_miscrates.SetValue(ll_Row, "rg_code", al_rgcode);
                }
            }
            for (ll_Row = 0; ll_Row < iuo_piecerates.RowCount; ll_Row++)
            {
                if (iuo_piecerates.ModifiedCount() > 0)
                {
                    iuo_piecerates.SetValue(ll_Row, "rg_code", al_rgcode);
                    if (iuo_piecerates.GetValue(ll_Row, "pr_active_status") == null)
                    {
                        iuo_piecerates.SetValue(ll_Row, "pr_active_status", "Y");
                    }
                }
            }
            for (ll_Row = 0; ll_Row < iuo_ratedays.RowCount; ll_Row++)
            {
                if (iuo_ratedays.ModifiedCount() > 0)
                {
                    iuo_ratedays.SetValue(ll_Row, "rg_code"/*"rate_days_rg_code"*/, al_rgcode);
                }
            }
            return true;
        }

        public virtual int of_setup()
        {
            int ll_Cnt;
            this.SuspendLayout();

            // Set our tag
            Tag = il_rg_code.ToString() + id_renewaldate.ToString();

            // Process effective date
            if (id_renewaldate == System.Convert.ToDateTime("1900,1,1") || is_editable == "W")
            {
                id_renewaldate = System.DateTime.Today;
            }
            sle_effdate.Text = id_renewaldate.Value.ToString("dd/MM/yyyy");

            ib_RetrievingVehicleList = true;
            ((DVehicalTypesList)(iuo_vehiclerates_list.DataObject)).Retrieve();
            ll_Cnt = iuo_vehiclerates_list.RowCount;

            ib_RetrievingVehicleList = false;
            sle_effdate.Enabled = false;
            cb_save.Enabled = false;

            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = is_editable;
            if (TestExpr == "Y")
            {
                sle_effdate.Enabled = false;
                cb_save.Enabled = true;

                ((DFuelRates2001)iuo_fuelrates.DataObject).Retrieve(il_rg_code, id_renewaldate);
                ((DPieceRates2001)iuo_piecerates.DataObject).Retrieve(il_rg_code, id_renewaldate);
                ((DRateDays2001)iuo_ratedays.DataObject).Retrieve(il_rg_code, id_renewaldate);
                ((DNonVehicleRates2005)iuo_nonvehiclerates.DataObject).Retrieve(il_rg_code, id_renewaldate);
                ((DMiscRates2001)iuo_miscrates.DataObject).Retrieve(il_rg_code, id_renewaldate);

                //iuo_nonvehiclerates.Modify("rg_code.Protect=\"0~tif ( isRowNew ( ),1,1)\"");
                //?iuo_nonvehiclerates.(7)DataControl["rg_code"].BackColor =\'79216776\'");
                iuo_nonvehiclerates.DataObject.GetControlByName("rg_code").Enabled = false;

                //  icb_delete = tab_main.tabpage_renewalrates.cb_delete
                icb_delete = cb_delete;
                icb_freeze = cb_freeze;//tab_main.tabpage_renewalrates.cb_freeze;
                // set other attributes
                if (iuo_miscrates.RowCount == 0)
                {
                    iuo_miscrates.InsertRow(0);
                }
                icb_delete.Enabled = true;
                icb_freeze.Enabled = true;
                if (!(of_are_rates_complete(false)))
                {
                    st_warn.Visible = true;
                }
            }
            else if (TestExpr == "W")
            {
                sle_effdate.Enabled = true;
                cb_save.Enabled = true;
                // copy previous non-vehicle rates
                if (of_copy_prev_nonvehicle() == 0)
                {
                    iuo_nonvehiclerates.InsertRow(0);
                }
                // set attributes
                iuo_nonvehiclerates.SetValue(0, "rg_code", il_rg_code);
                //?iuo_nonvehiclerates.Modify("rg_code.Protect=\"0~tif ( isRowNew ( ),0,0)\"");
                iuo_nonvehiclerates.ResetUpdate();//of_setstatus(iuo_nonvehiclerates, "notmodified");

                // Grab vehicle rates
                ((DVehicalTypesList)iuo_vehiclerates_list.DataObject).Retrieve();
                ll_Cnt = iuo_vehiclerates_list.RowCount;

                // copy previous rates
                of_copy_prev_piecerates();
                of_copy_prev_miscrates();
                of_copy_prev_fuelrates();
                of_copy_prev_ratedays();

                // set status to new!
                //?of_setstatus(iuo_fuelrates,new!);
                //?of_setstatus(iuo_piecerates,new!);
                //?of_setstatus(iuo_ratedays,new!);
                //?of_setstatus(iuo_miscrates,new!);
            }
            else
            {
                sle_effdate.Enabled = false;
                cb_save.Enabled = false;

                ((DFuelRates2001)iuo_fuelrates.DataObject).Retrieve(il_rg_code, id_renewaldate);
                iuo_fuelrates.SelectAllRows(false);//added by ybfan
                ((DPieceRates2001)iuo_piecerates.DataObject).Retrieve(il_rg_code, id_renewaldate);
                iuo_piecerates.SelectAllRows(false);//added by ybfan
                ((Metex.Windows.DataEntityGrid)iuo_piecerates.GetControlByName("grid")).DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Control;
                ((Metex.Windows.DataEntityGrid)iuo_piecerates.GetControlByName("grid")).DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
                ((DataGridView)iuo_piecerates.DataObject.Controls["grid"]).Columns["pr_rate"].DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
                ((DataGridView)iuo_piecerates.DataObject.Controls["grid"]).Columns["pr_active_status"].DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
                ((DRateDays2001)iuo_ratedays.DataObject).Retrieve(il_rg_code, id_renewaldate);
                iuo_ratedays.SelectAllRows(false);//added by ybfan
                ((DNonVehicleRates2005)iuo_nonvehiclerates.DataObject).Retrieve(il_rg_code, id_renewaldate);
                ((DMiscRates2001)iuo_miscrates.DataObject).Retrieve(il_rg_code, id_renewaldate);

                iuo_nonvehiclerates.of_protectcolumns();
                iuo_fuelrates.of_protectcolumns();
                iuo_miscrates.of_protectcolumns();
                iuo_ratedays.of_protectcolumns();
                iuo_piecerates.of_protectcolumns();
                //((Metex.Windows.DataEntityGrid)iuo_piecerates.DataObject.GetControlByName("grid")).ClearSelection();
                //((Metex.Windows.DataEntityGrid)iuo_piecerates.DataObject.GetControlByName("grid")).Enabled = false;//added by ylwang
                //((Metex.Windows.DataEntityGrid)iuo_fuelrates.DataObject.GetControlByName("grid")).Enabled = false;//added by ybfan

                // Depending on whether rates are new
                //SELECT count ( non_vehicle_rate.rg_code) into :ll_Cnt FROM non_vehicle_rate,vehicle_rate  WHERE non_vehicle_rate.nvr_rates_effective_date = vehicle_rate.vr_rates_effective_date  and (  non_vehicle_rate.nvr_frozen_indicator is null  OR  non_vehicle_rate.nvr_frozen_indicator = 'N' ) and vehicle_rate.vr_rates_effective_date = :id_renewaldate;
                ll_Cnt = RDSDataService.GetNonVehicleRateVehicleRateCount(id_renewaldate);
                if (ll_Cnt == 0)
                {
                    iuo_vehiclerates.of_protectcolumns();
                }
                //iuo_nonvehiclerates.Modify("rg_code.Protect=\"0~tif ( isRowNew ( ),1,1)\"");
                //?iuo_nonvehiclerates.(7)DataControl["rg_code"].BackColor =\'79216776\'");
                iuo_nonvehiclerates.GetControlByName("rg_code").Enabled = false;
            }
            this.Text = of_gettitle();
            /*?
            tab_main.tabpage_renewalrates.PowerTipText = "All rates specific to the " + of_getrengroup();
            tab_main.tabpage_renewalrates.tab_nonvehiclerates.tabpage_nonvehiclerates.PowerTipText = "Non-vehicle related rates for " + of_getrengroup();
            tab_main.tabpage_renewalrates.tab_nonvehiclerates.tabpage_piecerates.PowerTipText = "Piece rates for " + of_getrengroup();
            tab_main.tabpage_renewalrates.tab_nonvehiclerates.tabpage_fuelrates.PowerTipText = "Fuel rates for " + of_getrengroup();
            tab_main.tabpage_renewalrates.tab_nonvehiclerates.tabpage_ratedays.PowerTipText = "Days per annum for " + of_getrengroup();
             */
            this.ResumeLayout(false);

            return 0;
        }

        //public virtual int of_setstatus(URdsDw adw_datawindow, string adwis_status)// dwitemstatus adwis_status)
        //{
        //    int ll_Ctr;
        //    for (ll_Ctr = 0; ll_Ctr < adw_datawindow.RowCount; ll_Ctr++)
        //    {
        //        adw_datawindow.SetItemStatus(ll_Ctr, 0, primary!, adwis_status);
        //    }
        //    return 0;
        //}

        public virtual int of_freeze()
        {
            int ll_Count;
            int ll_RGCode;
            DateTime ld_Date;
            if (!(of_validate()))
            {
                return 0;
            }
            if (of_are_rates_complete(true))
            {
                //?iuo_nonvehiclerates.Modify("rg_code.dddw.useasborder=no");
                //!iuo_nonvehiclerates.SetValue(0, "nvr_frozen_indicator", 'Y');
                iuo_nonvehiclerates.SetValue(0, "nvr_frozen_indicator", true);
                iuo_nonvehiclerates.of_protectcolumns();
                iuo_fuelrates.of_protectcolumns();
                iuo_miscrates.of_protectcolumns();
                iuo_ratedays.of_protectcolumns();
                iuo_piecerates.of_protectcolumns();
                ((Metex.Windows.DataEntityGrid)iuo_piecerates.DataObject.GetControlByName("grid")).Enabled = false;//added by ylwang
                cb_save_clicked(null, null);
                st_warn.Visible = false;
            }
            return 0;
        }

        public virtual int of_getvehiclerate()
        {
            int? ll_vtKey;
            int vrl_row, vrl_rows;
            DateTime? ld_Max_Effective_Date;

            if (ib_RetrievingVehicleList)
            {
                return 1;
            }
            if (iuo_vehiclerates.Save() == -1)
                return 0;

            vrl_rows = iuo_vehiclerates_list.RowCount;
            if (vrl_rows == 0)
            {
                return 0;
            }
            vrl_row = iuo_vehiclerates_list.GetSelectedRow(0);
            if (vrl_row >= 0)
            {
                //GetItemNumber(iuo_vehiclerates_list.GetSelectedRow(0), "vt_key");
                ll_vtKey = iuo_vehiclerates_list.GetItem<VehicalTypesList>(vrl_row).VtKey;
                ((DVehicleRates2001)iuo_vehiclerates.DataObject).Retrieve(ll_vtKey, of_getdate());
                if (iuo_vehiclerates.RowCount == 0)
                {
                    // insert a new row
                    iuo_vehiclerates.InsertRow(0);
                    if (is_editable == "W")
                    {
                        //SELECT max(vr_rates_effective_date) INTO :ld_Max_Effective_Date FROM vehicle_rate WHERE vt_key = :ll_vtKey;
                        ld_Max_Effective_Date = RDSDataService.GetVehicleRateMax(ll_vtKey);
                        if (!(ld_Max_Effective_Date == null) && ld_Max_Effective_Date != System.Convert.ToDateTime("1900,1,1"))
                        {
                            ((DVehicleRates2001)iuo_vehiclerates.DataObject).Retrieve(ll_vtKey, ld_Max_Effective_Date);

                            iuo_vehiclerates.ResetUpdate();
                            //.SetItem(1,"vr_rates_effective_date", of_getdate());
                            iuo_vehiclerates.SetValue(0, "vr_rates_effective_date", of_getdate());
                            //iuo_vehiclerates.SetItemStatus(1, 0, primary!, new!);
                            ((VehicleRates2001)iuo_vehiclerates.GetItem<VehicleRates2001>(0)).MarkNewEntity();
                        }
                    }
                }
            } 
            return 1;
        }

        public virtual int? of_getrgcode()
        {
            int? ll_RGCode = 0;
            if (iuo_nonvehiclerates.RowCount > 0)  //added by jlwang
                //.GetItemNumber(1, "rg_code");
                ll_RGCode = iuo_nonvehiclerates.GetItem<NonVehicleRates2005>(0).RgCode;
            if (ll_RGCode == null)
            {
                ll_RGCode = il_rg_code;
            }
            return ll_RGCode;
        }

        public virtual DateTime? of_getdate()
        {
            //!return System.Convert.ToDateTime(sle_effdate.Text);
            if (!string.IsNullOrEmpty(sle_effdate.Text))
            {
                //! if sle_effdate.Text is '20/08/2000' change to '08/20/2000' or exception occurs in Convert
                string[] dateElements = sle_effdate.Text.Split(new char[] { '/' });
                if (dateElements != null && dateElements.Length >= 3)
                {
                    int day = Convert.ToInt32(dateElements[0]);
                    int month = Convert.ToInt32(dateElements[1]);
                    int year = Convert.ToInt32(dateElements[2]);
                    return new DateTime(year, month, day);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        public virtual int of_delete()
        {
            DialogResult dlg = DialogResult.None;
            dlg = MessageBox.Show("Are you sure you want to delete this renewal?", "Rates", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//, question!, yesno!, 2)
            if (dlg == DialogResult.Yes)// 1)
            {
                //move  to service
                //SqlConnection mytran;
                //mytran = new SqlConnection();
                //mytran = StaticVariables.sqlca;
                //connect using mytran;

                //DELETE 	FROM non_vehicle_rate WHERE non_vehicle_rate.nvr_rates_effective_date =:id_renewaldate AND non_vehicle_rate.rg_code = :il_rg_code     USING mytran;

                //if (mytran.SQLCode == -(1)) 
                //{
                //    rollback using mytran;
                //    MessageBox.Show (  mytran.SQLErrText, "Delete Non-Vehicle Rates Error" );
                //    return 0;
                //}

                //DELETE FROM piece_rate WHERE 	piece_rate.pr_effective_date =  :id_renewaldate AND piece_rate.rg_code =  :il_rg_code USING mytran;
                //if (mytran.SQLCode == -(1))
                //{
                //    rollback using mytran;
                //    MessageBox.Show (  mytran.SQLErrText, "Delete Piece Rates Error" );
                //    return 0;
                //}

                //DELETE 	FROM fuel_rates  WHERE 	fuel_rates.rg_code = :il_rg_code AND fuel_rates.rr_rates_effective_date = :id_renewaldate USING mytran;
                //if (mytran.SQLCode == -(1)) 
                //{
                //    rollback using mytran;
                //    MessageBox.Show (  mytran.SQLErrText, "Delete Fuel Rates Error" );
                //    return 0;
                //}
                //DELETE 	FROM rate_days  WHERE 	rate_days.rg_code =:il_rg_code  AND  rate_days.rr_rates_effective_date =  :id_renewaldate  USING mytran ;
                //if (mytran.SQLCode == -(1))
                //{
                //    rollback using mytran;
                //    MessageBox.Show (  mytran.SQLErrText, "Delete Rate Days Error" );
                //    return 0;
                //}
                //DELETE 	FROM misc_rate  WHERE 	misc_rate.rg_code = :il_rg_code  AND  misc_rate.mr_effective_date =   :id_renewaldate  USING mytran ;
                //if (mytran.SQLCode == -(1)) 
                //{
                //    rollback using mytran;
                //    MessageBox.Show (  mytran.SQLErrText, "Delete Other Rates Error" );
                //    return 0;
                //}
                ////  TWC 22/09/2003 
                ////  call 4565 - deleting vehicle rates also
                //DELETE FROM vehicle_rate  WHERE vr_rates_effective_date = :id_renewaldate  USING mytran;
                //if (mytran.SQLCode == -(1))
                //{
                //    rollback using mytran;
                //    MessageBox.Show (  mytran.SQLErrText, "Delete Vehicle Rate Error" );
                //    return 0;
                //}
                //commit USING mytran ;

                string str = RDSDataService.ComplexSqlState(id_renewaldate, il_rg_code);
                if (str != "")
                {
                    MessageBox.Show(str.Substring(0, str.LastIndexOf(",") - 1), str.Substring(str.LastIndexOf(",") - 1, str.Length), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
            }
            return 1;
        }

        public virtual int of_copy_prev_nonvehicle()
        {
            DateTime? ld_Max_Effective_Date;
            DateTime? ld_Date_To;
            DateTime? ld_Date_From = null;
            int li_yy;
            int li_dd;
            int li_mm;
            int ll_Rows;
            // The user has clicked on New Rates
            // Use the rg_code to get the max effective date for that Renewal Group

            //SELECT max ( nvr_rates_effective_date) INTO :ld_Max_Effective_Date  FROM non_vehicle_rate WHERE rg_code = :il_rg_code;

            ld_Max_Effective_Date = RDSDataService.GetNonVehicleRateMax(il_rg_code);
            if ((ld_Max_Effective_Date == null) || (ld_Max_Effective_Date == System.Convert.ToDateTime("1900,1,1")))
            {
                ld_Max_Effective_Date = of_getdate();
            }

            /* Use li_Renewal_Group and ld_Max_Effective_Date to retrieve the latest values for the Renewal Group as default values */
            ll_Rows = ((DNonVehicleRates2005)iuo_nonvehiclerates.DataObject).Retrieve(il_rg_code, ld_Max_Effective_Date);
            //iuo_nonvehiclerates.SetValue(0, "nvr_frozen_indicator", false);// "N");
            // .SetItem(1, "nvr_frozen_indicator", 'N');--no nvr_frozen_indicator
            iuo_nonvehiclerates.GetItem<NonVehicleRates2005>(0).NvrFrozenIndicator = false;
            iuo_nonvehiclerates.ResetUpdate();
            //iuo_nonvehiclerates.SetItemStatus(1, 0, primary!, new!);
            ((NonVehicleRates2005)iuo_nonvehiclerates.GetItem<NonVehicleRates2005>(0)).MarkNewEntity();
            //  now use the max effective date to get the end of contract date 

            //SELECT nvr_contract_end  INTO :ld_Date_To FROM non_vehicle_rate 
            // WHERE rg_code = :il_rg_code AND nvr_rates_effective_date = :ld_Max_Effective_Date;
            ld_Date_To = RDSDataService.GetNonVehicleRateValue(il_rg_code, ld_Max_Effective_Date);
            //ld_Date_From =RelativeDate(ld_Date_To, 1);
            ld_Date_From = ld_Date_To.GetValueOrDefault().AddDays(1);
            li_yy = ld_Date_To.Value.Year + 1;
            li_dd = ld_Date_To.Value.Day;
            li_mm = ld_Date_To.Value.Month;
            ld_Date_To = System.Convert.ToDateTime(li_yy + "," + li_mm + "," + li_dd);
            //.SetItem(1, "nvr_rates_effective_date", ld_Date_From);--no nvr_rates_effective_date
            iuo_nonvehiclerates.SetValue(0, "nvr_rates_effective_date", ld_Date_From);
            //.SetItem(1, "nvr_contract_end", ld_Date_To);--no nvr_contract_end
            iuo_nonvehiclerates.SetValue(0, "nvr_contract_end", ld_Date_To);
            //.SetItem(1, "nvr_contract_start", ld_Date_From);--no nvr_contract_start
            iuo_nonvehiclerates.SetValue(0, "nvr_contract_start", ld_Date_From);
            return ll_Rows;
        }

        public virtual int of_copy_prev_fuelrates()
        {
            DateTime? ld_Max_Effective_Date = null;
            DateTime? ld_Effective_Date;
            int ll_Ctr;
            // The user has clicked on New Rates, so show the must current fuel rates as defaults

            //SELECT max(rr_rates_effective_date) INTO :ld_Max_Effective_Date FROM Fuel_rates where rg_code = :il_rg_code;
            int sqlCode = -1;
            string sqlErrText = "";
            ld_Max_Effective_Date = RDSDataService.GetFuelRatesMax(il_rg_code, ref sqlCode, ref sqlErrText);
            if (sqlCode != 0)//(StaticVariables.sqlca.SQLCode != 0)
            {
                MessageBox.Show(sqlErrText /*?app.sqlca.SQLErrText*/
                              , "Copy prev fuelrates"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            if ((ld_Max_Effective_Date == null) && ld_Max_Effective_Date != System.Convert.ToDateTime("1900,1,1"))
            {
                ld_Max_Effective_Date = of_getdate();
            }
            ((DFuelRates2001)iuo_fuelrates.DataObject).Retrieve(of_getrgcode(), ld_Max_Effective_Date);
            iuo_fuelrates.ResetUpdate();

            for (ll_Ctr = 0; ll_Ctr < iuo_fuelrates.RowCount; ll_Ctr++)
            {
                iuo_fuelrates.SetValue(ll_Ctr, "rr_rates_effective_date", of_getdate());
                iuo_fuelrates.SetValue(ll_Ctr, "rg_code", of_getrgcode());
                //iuo_fuelrates.SetItemStatus(ll_Ctr, 0, primary!, new!);
                ((FuelRates2001)iuo_fuelrates.GetItem<FuelRates2001>(ll_Ctr)).MarkNewEntity();
            }
            return 1;
        }

        public virtual int of_copy_prev_piecerates()
        {
            DateTime? ld_Max_PrEffective_Date = null;
            DateTime? ld_Effective_Date = null;
            int ll_Ctr;
            //  The user has clicked on New Rates, so show 
            //  the most current fuel rates as defaults.

            // SELECT max(pr_effective_date) INTO :ld_Max_PrEffective_Date FROM piece_rate WHERE rg_code = :il_rg_code;
            int sqlCode = -1;
            string sqlErrText = "";
            ld_Max_PrEffective_Date = RDSDataService.GetPieceRateMax(il_rg_code, ref sqlCode, ref sqlErrText);
            if (sqlCode != 0)// (StaticVariables.sqlca.SQLCode != 0)
            {
                MessageBox.Show(sqlErrText   /*?app.sqlca.SQLErrText*/
                              , "Copy prev piecerates"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }

            if ((ld_Max_PrEffective_Date == null) || ld_Max_PrEffective_Date == System.Convert.ToDateTime("1900,1,1"))
            {
                ld_Max_PrEffective_Date = of_getdate();
            }
            ((DPieceRates2001)iuo_piecerates.DataObject).Retrieve(of_getrgcode(), ld_Max_PrEffective_Date);
            iuo_piecerates.ResetUpdate();
            for (ll_Ctr = 0; ll_Ctr < iuo_piecerates.RowCount; ll_Ctr++)
            {
                iuo_piecerates.SetValue(ll_Ctr, "pr_effective_date", of_getdate());
                iuo_piecerates.SetValue(ll_Ctr, "rg_code", of_getrgcode());
                //iuo_piecerates.SetItemStatus(ll_Ctr, 0, primary!, new!);
                ((PieceRates2001)iuo_piecerates.GetItem<PieceRates2001>(ll_Ctr)).MarkNewEntity();
            }
            return 1;
        }

        public virtual int of_copy_prev_ratedays()
        {
            DateTime? ld_Max_PrEffective_Date = null;
            DateTime? ld_Effective_Date;
            int ll_Ctr;
            // The user has clicked on New Rates, so show the must current fuel rates as defaults

            //SELECT max(rr_rates_effective_date) INTO :ld_Max_PrEffective_Date FROM rate_days WHERE rg_code =:il_rg_code;
            int sqlCode = -1;
            string sqlErrText = "";
            ld_Max_PrEffective_Date = RDSDataService.GetRateDaysMax(il_rg_code, ref sqlCode, ref sqlErrText);
            if (sqlCode != 0)// (StaticVariables.sqlca.SQLCode != 0)
            {
                MessageBox.Show(sqlErrText   /*?app.sqlca.SQLErrText*/
                               , "Copy prev ratedays"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }

            if ((ld_Max_PrEffective_Date == null) || ld_Max_PrEffective_Date == System.Convert.ToDateTime("1900,1,1"))
            {
                ld_Max_PrEffective_Date = of_getdate();
            }
            ((DRateDays2001)iuo_ratedays.DataObject).Retrieve(of_getrgcode(), ld_Max_PrEffective_Date);
            iuo_ratedays.ResetUpdate();
            for (ll_Ctr = 0; ll_Ctr < iuo_ratedays.RowCount; ll_Ctr++)
            {
                // .SetItem(ll_Ctr, "rr_rates_effective_date", of_getdate());
                iuo_ratedays.SetValue(ll_Ctr, "rr_rates_effective_date", of_getdate());
                //.SetItem(ll_Ctr, "rg_code", of_getrgcode());
                iuo_ratedays.SetValue(ll_Ctr, "rg_code", of_getrgcode());
                //iuo_ratedays.SetItemStatus(ll_Ctr, 0, primary!, new!);
                ((RateDays2001)iuo_ratedays.GetItem<RateDays2001>(ll_Ctr)).MarkNewEntity();
            }
            return 1;
        }

        public virtual int of_copy_prev_miscrates()
        {
            DateTime? ld_Max_Effective_Date = null;
            DateTime? ld_Effective_Date;
            int ll_Ctr;
            // The user has clicked on New Rates, so show the must current fuel rates as defaults

            // SELECT max( mr_effective_date) INTO :ld_Max_Effective_Date FROM misc_rate WHERE rg_code = :il_rg_code;
            int sqlCode = -1;
            string sqlErrText = "";
            ld_Max_Effective_Date = RDSDataService.GetMiscRateMax(il_rg_code, ref sqlCode, ref sqlErrText);

            if (sqlCode != 0)  //(StaticVariables.sqlca.SQLCode != 0)
            {
                MessageBox.Show(sqlErrText   /*?app.sqlca.SQLErrText*/
                               , "Copy prev miscrates"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }

            if ((ld_Max_Effective_Date == null) || ld_Max_Effective_Date == System.Convert.ToDateTime("1900,1,1"))
            {
                ld_Max_Effective_Date = of_getdate();
            }
            ((DMiscRates2001)iuo_miscrates.DataObject).Retrieve(of_getrgcode(), ld_Max_Effective_Date);
            iuo_miscrates.ResetUpdate();

            for (ll_Ctr = 0; ll_Ctr < iuo_miscrates.RowCount; ll_Ctr++)
            {
                iuo_miscrates.SetValue(ll_Ctr, "mr_effective_date", of_getdate());
                iuo_miscrates.SetValue(ll_Ctr, "rg_code", of_getrgcode());
                //iuo_miscrates.SetItemStatus(ll_Ctr, 0, primary!, new!);
                ((MiscRates2001)iuo_miscrates.GetItem<MiscRates2001>(ll_Ctr)).MarkNewEntity();
            }
            return 1;
        }

        public virtual int wf_save()
        {
            int ll_Ret = 0;
            /*?ll_Ret = */
            cb_save_clicked(null, null);
            return ll_Ret;
        }

        public virtual string of_getrengroup()
        {
            string ls_Group;
            int ll_Row;
            DataUserControl dwc;//  DataControlBuilder dwc;
            //.GetChild("rg_code", dwc);
            dwc = iuo_nonvehiclerates.DataObject.GetChild("rg_code");
            ll_Row = dwc.Find("rg_code  ", of_getrgcode().ToString());
            if (ll_Row > 0)
            {
                ls_Group = dwc.GetValue(ll_Row, "rg_description").ToString();
            }
            else
            {
                ls_Group = "";
            }
            return ls_Group;
        }

        public virtual string of_gettitle()
        {
            string ls_Title;
            string ls_RenGroup;
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = is_editable;
            if (TestExpr == "Y")
            {
                ls_Title = "Edit Existing Rates";
            }
            else if (TestExpr == "W")
            {
                ls_Title = "Create New Rates";
            }
            else
            {
                ls_Title = "Show Rates";
            }
            ls_RenGroup = of_getrengroup();
            if (ls_RenGroup.Length > 0)
            {
                ls_Title = ls_Title + "  ( " + ls_RenGroup + ")";
            }
            return ls_Title;
        }

        public virtual bool of_are_rates_complete(bool ab_withmessage)
        {
            int ll_Count1 = 0;
            int ll_Count2 = 0;
            int ll_Count3 = 0;
            int? ll_RGCode;
            DateTime? ld_Date;
            int ll_NumVehicleTypes = 0;
            int? ll_NumVehicleTypesFilled = 0;
            ld_Date = of_getdate();
            ll_RGCode = of_getrgcode();

            // Check fuel rates

            //select count(*) into :ll_Count1 from fuel_type ,fuel_rates 
            // where fuel_type.ft_key = fuel_rates.ft_key and fuel_rates.rr_rates_effective_date = :ld_Date and fuel_rates.rg_code = :ll_RGCode and (fuel_rates.fr_fuel_rate is null or fuel_rates.fr_fuel_consumtion_rate is null);
            ll_Count1 = RDSDataService.GetFuelTypeFuelRatesCount(ld_Date, ll_RGCode);
            if (ll_Count1 > 0)
            {
                //tab_main.tabpage_renewalrates.tab_nonvehiclerates.tabpage_fuelrates.text = "Fuel Rates (Incomplete)";
                tabpage_fuelrates.Text = "Fuel Rates (Incomplete)";
            }
            else
            {
                //tab_main.tabpage_renewalrates.tab_nonvehiclerates.tabpage_fuelrates.text = "Fuel Rates";
                tabpage_fuelrates.Text = "Fuel Rates";
            }
            // check rate days

            //select count(*) into :ll_Count2 from standard_frequency ,rate_days 
            // where standard_frequency.sf_key = rate_days.sf_key 
            //   and rate_days.rr_rates_effective_date = :ld_Date 
            //   and rate_days.rg_code = :ll_RGCode and rate_days.rtd_days_per_annum is null;
            ll_Count2 = RDSDataService.GetStandardFrequencyRateDaysCount(ld_Date, ll_RGCode);
            if (ll_Count2 > 0)
            {
                //tab_main.tabpage_renewalrates.tab_nonvehiclerates.tabpage_ratedays.text = "Rate Days (Incomplete)";
                tabpage_ratedays.Text = "Rate Days (Incomplete)";
            }
            else
            {
                //tab_main.tabpage_renewalrates.tab_nonvehiclerates.tabpage_ratedays.text = "Rate Days";
                tabpage_ratedays.Text = "Rate Days";
            }

            //SELECT count(*) INTO :ll_Count3  FROM piece_rate WHERE piece_rate.pr_effective_date = :ld_Date AND piece_rate.rg_code =  :ll_RGCode  AND pr_active_status = 'Y' AND pr_rate is null;
            ll_Count3 = RDSDataService.GetPieceRateCount(ld_Date, ll_RGCode);

            if (ll_Count3 > 0)
            {
                //tab_main.tabpage_renewalrates.tab_nonvehiclerates.tabpage_piecerates.text = "Piece Rates (Incomplete)";
                tabpage_piecerates.Text = "Piece Rates (Incomplete)";
            }
            else
            {
                //tab_main.tabpage_renewalrates.tab_nonvehiclerates.tabpage_piecerates.text = "Piece Rates";
                tabpage_piecerates.Text = "Piece Rates";
            }

            // Count vehicle types
            //SELECT count ( *) INTO :ll_NumVehicleTypes  FROM vehicle_type;

            ll_NumVehicleTypes = RDSDataService.GetVehicleTypeCount();

            // Count vehicle types already entered
            //SELECT count ( vehicle_rate.vt_key) INTO :ll_NumVehicleTypesFilled  FROM vehicle_rate 
            // WHERE vehicle_rate.vr_rates_effective_date = :ld_Date  
            //   AND vehicle_rate.vr_nominal_vehicle_value is not null  
            //   AND vehicle_rate.vr_repairs_maintenance_rate is not null 
            //   AND vehicle_rate.vr_tyre_tubes_rate is not null 
            //   AND vehicle_rate.vr_vehicle_allowance_rate is not null 
            //   AND vehicle_rate.vr_licence_rate is not null 
            //   AND vehicle_rate.vr_vehicle_rate_of_return_pct is not null 
            //   AND vehicle_rate.vr_salvage_ratio is not null 
            //   AND vehicle_rate.vr_ruc is not null 
            //   AND vehicle_rate.vr_sundries_k is not null 
            //   AND vehicle_rate.vr_vehicle_value_insurance_pct is not null;

            ll_NumVehicleTypesFilled = RDSDataService.GetVehicleRateCount(ld_Date);

            if ((ll_NumVehicleTypesFilled == null) || (ll_NumVehicleTypesFilled < ll_NumVehicleTypes))
            {
                tabpage_vehiclerates.Text = "Vehicle Rates (Incomplete)";
            }
            else
            {
                tabpage_vehiclerates.Text = "Vehicle Rates";
            }
            if (ll_Count1 > 0)
            {
                if (ab_withmessage)
                {
                    MessageBox.Show("This renewal rate cannot be frozen because not all \n"
                                     + "fuel rates have been defined for it yet."
                                   , "title"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return false;
            }
            if (ll_Count2 > 0)
            {
                if (ab_withmessage)
                {
                    MessageBox.Show("This renewal rate cannot be frozen because not all \n"
                                     + "days per annum have been defined for it yet."
                                   , "title", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return false;
            }
            if ((ll_NumVehicleTypesFilled == null) || ll_NumVehicleTypesFilled < ll_NumVehicleTypes)
            {
                if (ab_withmessage)
                {
                    MessageBox.Show("This renewal rate cannot be frozen because not all \n"
                                     + "vehicle rates have been defined for it yet."
                                   , "title", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return false;
            }
            if (ll_Count3 > 0)
            {
                if (ab_withmessage)
                {
                    // question!, yesno!, 2) == 2)
                    DialogResult dlg = MessageBox.Show("Not all piece rates have been defined for it yet. \n"
                                                        + "Continue anyway?"
                                                      , "title"
                                                      , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dlg == DialogResult.No)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }
            return true;
        }

        public virtual void of_close()
        {
            this.Close();
        }

        private void acceptTextDiy() //added by ygu:modify statue
        {
            if (is_editable == "W")
            {
                for (int row = 0; row < iuo_nonvehiclerates.RowCount; row++)
                {
                    iuo_nonvehiclerates.GetItem<NonVehicleRates2005>(row).SetMarkDirty();
                }
            }
            iuo_nonvehiclerates.AcceptText();
        }

        public virtual void dw_nonvehicle_constructor()
        {
            iuo_nonvehiclerates = dw_nonvehicle;
        }

        public virtual void ue_dwnrbuttonclk()
        {
            // //
            // m_Main_Menu mCurrent
            // 
            // mCurrent = g_system.w_active_sheet.menuid
            // 
            // //! Defect. PaulA. 30July.  Null Object reference. 
            // 
            // if isValid ( mCurrent) then
            // 	mCurrent.m_eh.PopMenu ( g_System.w_Active_MDI.PointerX ( ),g_System.w_Active_MDI.PointerY ( ))
            // end if
            // 
        }

        public virtual void dw_piecerate_constructor()
        {
            iuo_piecerates = dw_piecerate;
            // dw_piecerate.GetItem<PieceRates2001>(0).PrRate.GetValueOrDefault().ToString("##.000");
        }

        //public virtual void ue_dwnrbuttonclk()
        //{
        //    // 
        //}

        public virtual void ue_vscroll()
        {
            // 
        }

        public virtual void dw_fuelrate_constructor()
        {
            iuo_fuelrates = dw_fuelrate;
        }

        public virtual void dw_ratedays_constructor()
        {
            iuo_ratedays = dw_ratedays;
        }

        public virtual void dw_other_constructor()
        {
            iuo_miscrates = dw_other;
        }

        public virtual void constructor()
        {
            icb_freeze = cb_freeze;
            icb_delete = cb_delete;
        }

        public virtual void dw_vehiclerates_constructor()
        {
            iuo_vehiclerates = dw_vehiclerates;
        }

        public virtual void dw_vehicletypes_constructor()
        {
            iuo_vehiclerates_list = dw_vehicletypes;
            dw_vehicletypes.of_SetUpdateable(false);
        }

        public virtual void rowfocuschanging()
        {
            of_getvehiclerate();
        }

        public virtual void ue_setuprow()
        {
            // of_GetVehiclerate ( )
        }

        //public virtual void constructor()
        //{
        //    icb_delete = cb_delete;
        //}

        #endregion

        #region Events
        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            int? ll_rgcode;
            if (is_editable == "N")
            {
                return;// -(1);
            }
            //.GetItemNumber(1, "rg_code");
            ll_rgcode = iuo_nonvehiclerates.GetItem<NonVehicleRates2005>(0).RgCode;
            iuo_nonvehiclerates.DataObject.AcceptText();
            iuo_fuelrates.DataObject.AcceptText();
            iuo_miscrates.DataObject.AcceptText();
            iuo_piecerates.DataObject.AcceptText();
            iuo_vehiclerates.DataObject.AcceptText();
            iuo_ratedays.DataObject.AcceptText();
            // Make sure Misc rates and fuel rates get their rg_codes
            of_set_rgcode(ll_rgcode);
            of_setdates();
            //iuo_nonvehiclerates.DataObject.AcceptText();
            acceptTextDiy();
            iuo_fuelrates.DataObject.AcceptText();
            iuo_miscrates.DataObject.AcceptText();
            iuo_piecerates.DataObject.AcceptText();
            iuo_vehiclerates.DataObject.AcceptText();
            iuo_ratedays.DataObject.AcceptText();

            if (!(of_validate()))
            {
                return;// -(1);
            }
            //  TJB  SR4661  May 2005
            //  If the non-vehicle rates have been modified, set the 
            //  old hourly wage rate to the new processing wage rate.
            int ll_row;
            decimal? ldc_temp;

            //?dwItemStatus lis_temp;
            if (iuo_nonvehiclerates.ModifiedCount() > 0)
            {
                for (ll_row = 0; ll_row < iuo_nonvehiclerates.RowCount; ll_row++)
                {
                    //lis_temp = iuo_nonvehiclerates.GetItemStatus(ll_row, "nvr_processing_wage_rate", primary!);
                    if (iuo_nonvehiclerates.GetItem<NonVehicleRates2005>(ll_row).IsDirty) //(lis_temp == datamodified!) 
                    {
                        ldc_temp = iuo_nonvehiclerates.GetValue<decimal>(ll_row, "nvr_processing_wage_rate");
                        iuo_nonvehiclerates.SetValue(ll_row, "nvr_wage_hourly_rate", ldc_temp);
                    }
                }
            }
            iuo_nonvehiclerates.Save();
            iuo_fuelrates.Save();
            iuo_miscrates.Save();
            // TJB  RD7_0036  Aug 2009
            // Changed to save_vehiclerates
            // iuo_vehiclerates.RowCount;
            // iuo_vehiclerates.Save();
            save_vehiclerates();
            iuo_ratedays.Save();
            iuo_piecerates.Save();

            if (iw_caller != null)
            {
                iw_caller.of_retrievelist();
            }

            sle_effdate.Enabled = false;
            if (is_editable == "W")
            {
                is_editable = "Y";
                icb_delete.Enabled = true;
                icb_freeze.Enabled = true;
            }
            //?iuo_nonvehiclerates.Modify("rg_code.Protect=\"0~tif ( isRowNew ( ),1,1)\"");
            //?iuo_nonvehiclerates.(7)DataControl["rg_code"].BackColor =\'13160660\'");
            iuo_nonvehiclerates.DataObject.GetControlByName("rg_code").Enabled = false;
            this.Text = of_gettitle();//parent.Title = of_gettitle();
            if (!(of_are_rates_complete(false)))
            {
                st_warn.Visible = true;
                il_Rates_Complete = 0;
            }
            else
            {
                il_Rates_Complete = 1;
                st_warn.Visible = false;
            }
            //?commit;
            return;// 1;
        }

        public virtual void save_vehiclerates()
        {
            // TJB  RD7_0036  Aug 2009
            // iuo_vehiclerates contains the rates for only one vehicle type, 
            //    while iuo_vehiclerates identifies all vehicle types.  Initially, only
            //    the rates for the currect vehicle type were being saved, which could cause
            //    errors.  This code saves the rates for all vehicle types.
            int rc, vrl_rows, vrl_row, selected_vrl_row;
            selected_vrl_row = iuo_vehiclerates_list.GetSelectedRow(0);
            iuo_vehiclerates.Save();
            vrl_rows = iuo_vehiclerates_list.RowCount;
            for (vrl_row = 0; vrl_row < vrl_rows; vrl_row++)
            {
                if (vrl_row != selected_vrl_row)
                {
                    iuo_vehiclerates_list.SelectRow(vrl_row, false) ;
                    rc = of_getvehiclerate();
                }
            }
            iuo_vehiclerates_list.SelectRow(selected_vrl_row, false);
            rc = of_getvehiclerate();
            int i = rc;
        }

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            // Boolean bReturnValue = True
            // Long    lMessageReturn = 0
            // 
            // if This.AcceptText  ( ) = 1 then
            //    If This.DeletedCount  (  ) > 0 &
            //    Or This.ModifiedCount  (  ) > 0 Then
            //       If aAutoUpdate Then
            //          bReturnValue =  (  This.Update  ( ) = 1 )
            //       Else
            //          lMessageReturn = MessageBox("Update?", "Do you want to update the database?", Information!, YesNoCancel! )
            // 			Choose Case lMessageReturn
            // 			Case 1
            // 				bReturnValue = (This.Update() = 1)
            // 			Case 2
            // 				bReturnValue = True
            // 			Case 3
            // 				bReturnValue = False
            // 			End Choose
            //       End If
            //    End If
            // Else
            //    bReturnValue = False
            // End If
            // if bReturnValue then 
            //    g_System.dddw_update = datetime(today(), now())
            //    ist_instance.last_updated = datetime(today(), now())
            //    Commit;
            // else
            //    RollBack;
            // end if
            // Return bReturnValue
        }

        public virtual void sle_effdate_modified(object sender, EventArgs e)
        {
            //!id_renewaldate = DateTime.Parse(sle_effdate.Text);//this.Text);
            //! text box stores as dd/MM/yyyy - to be parsed succesfully needs to be in format 
            //! MM/dd/yyyy depending from regional settings maybe or otherwise throw exception
            if (!string.IsNullOrEmpty(sle_effdate.Text))
            {
                string[] dateElements = sle_effdate.Text.Split(new char[] { '/' });
                if (dateElements.Length >= 3)
                {
                    int day = Convert.ToInt32(dateElements[0]);
                    int month = Convert.ToInt32(dateElements[1]);
                    int year = Convert.ToInt32(dateElements[2]);

                    if (day > 0 && day <= 31 && month > 0 && month <= 12 && year > 0 && year <= 9999)
                    {
                        id_renewaldate = new DateTime(year, month, day);
                    }
                }
            }


            this.of_setdates();
            return;// 0;
        }

        public virtual void dw_nonvehicle_getfocus(object sender, EventArgs e)
        {
            //?base.getfocus();
            // If g_security.u_usergroup = 'RuralPost Manager' and g_security.userid = "GROOMEJ" or g_security.userid = "DRYSDALEP" Then
            // 	//Do nothing
            // Else
            // 	of_ProtectColumns ( )
            // End if
        }

        public virtual void dw_piecerate_getfocus(object sender, EventArgs e)
        {
            // If g_security.u_usergroup = 'RuralPost Manager' and g_security.userid = "GROOMEJ" or g_security.userid = "DRYSDALEP" Then
            // 	//Do nothing
            // Else
            // 	of_ProtectColumns ( )
            // End if
        }

        public virtual void dw_fuelrate_getfocus(object sender, EventArgs e)
        {
            // If g_security.u_usergroup = 'RuralPost Manager' and g_security.userid = "GROOMEJ" or g_security.userid = "DRYSDALEP" Then
            // 	//Do nothing
            // Else
            // 	of_ProtectColumns ( )
            // End if
        }

        public virtual void dw_ratedays_getfocus(object sender, EventArgs e)
        {
            // If g_security.u_usergroup = 'RuralPost Manager' and g_security.userid = "GROOMEJ" or g_security.userid = "DRYSDALEP" Then
            // 	//Do nothing
            // Else
            // 	of_ProtectColumns ( )
            // End if
        }

        public virtual void cb_freeze_clicked(object sender, EventArgs e)
        {
            of_freeze();

            if (iw_caller != null)
            {
                iw_caller.of_retrievelist();
            }
        }

        public virtual void dw_vehiclerates_editchanged(object sender, EventArgs e)
        {
            decimal? ldec_SalvageRatio;
            decimal? ldec_NominalVehical;
            int ll_baseRemainingEconomicLife = 200000;
            dw_vehiclerates.DataObject.AcceptText();

            iuo_vehiclerates.SetValue(0, "vt_key", iuo_vehiclerates_list.GetItem<VehicalTypesList>(iuo_vehiclerates_list.GetRow()).VtKey);//.GetItemNumber(iuo_vehiclerates_list.GetRow(), "vt_key"));
            iuo_vehiclerates.SetValue(0, "vr_rates_effective_date", of_getdate());
            //if ((DVehicleRates2001)iuo_vehiclerates.GetItemStatus(1, "vr_nominal_vehicle_value", primary!) == newmodified! || 
            //    (DVehicleRates2001)iuo_vehiclerates.GetItemStatus(1, "vr_nominal_vehicle_value", primary!) == datamodified! || 
            //        (DVehicleRates2001)iuo_vehiclerates.GetItemStatus(1, "vr_salvage_ratio", primary!) == newmodified! ||
            //            (DVehicleRates2001)iuo_vehiclerates.GetItemStatus(1, "vr_salvage_ratio", primary!) == datamodified!) 
            if (iuo_vehiclerates.GetItem<VehicleRates2001>(0).IsDirty)
            {
                ldec_SalvageRatio = iuo_vehiclerates.GetItem<VehicleRates2001>(0).VrSalvageRatio;//.GetItemNumber(1, "vr_salvage_ratio");
                ldec_NominalVehical = iuo_vehiclerates.GetItem<VehicleRates2001>(0).VrNominalVehicleValue;//.GetItemNumber(1, "vr_nominal_vehicle_value");
                //!iuo_vehiclerates.SetValue(0, "vr_vehicle_allowance_rate", (1 - ldec_SalvageRatio / 100) * ldec_NominalVehical * 1000 / ll_baseRemainingEconomicLife);
                iuo_vehiclerates.GetItem<VehicleRates2001>(0).VrVehicleAllowanceRate =
                    (1 - ldec_SalvageRatio / 100) * ldec_NominalVehical * 1000 / ll_baseRemainingEconomicLife;

                iuo_vehiclerates.DataObject.BindingSource.CurrencyManager.Refresh();
            }
        }

        public virtual void dw_vehiclerates_getfocus(object sender, EventArgs e)
        {
            // If g_security.u_usergroup = 'RuralPost Manager' and g_security.userid = "GROOMEJ" or g_security.userid = "DRYSDALEP" Then
            // 	//Do nothing
            // Else
            // 	of_ProtectColumns ( )
            // End if
        }

        public virtual void dw_vehicletypes_clicked(object sender, EventArgs e)
        {
            if (dw_vehicletypes.GetRow() < 0)
            {
                return;
            }

            this.SuspendLayout();//parent.SetRedraw(false);
            dw_vehicletypes.SelectRow(dw_vehicletypes.GetSelectedRow(0), false);
            dw_vehicletypes.SelectRow(dw_vehicletypes.GetRow() + 1, true);
            of_getvehiclerate();
            this.ResumeLayout();//parent.ResumeLayout(false);
        }

        public virtual void dw_vehicletypes_retrieveend(object sender, EventArgs e)
        {
            int? ll_vtKey;
            //?Sort();
            if (dw_vehicletypes.RowCount > 0)
            {
                dw_vehicletypes.SelectRow(0, true);
                // GetItemNumber(1, "vt_key");
                ll_vtKey = dw_vehicletypes.GetValue<int?>(0, "vt_key");
                ((DVehicleRates2001)iuo_vehiclerates.DataObject).Retrieve(ll_vtKey, id_renewaldate);
                if (iuo_vehiclerates.RowCount == 0)
                {
                    iuo_vehiclerates.InsertRow(0);
                }
            }
        }

        public virtual void dw_vehicletypes_rowfocuschanged(object sender, EventArgs e)
        {
            dw_vehicletypes.SelectRow(0, false);
            //?dw_vehicletypes.SelectRow(dw_vehicletypes.GetRow(), true); //dw_vehicletypes has no row
            of_getvehiclerate();
        }

        public virtual void cb_delete_clicked(object sender, EventArgs e)
        {
            if (of_delete() == 1)
            {
                dw_piecerate.Reset();
                if (iw_caller != null)
                {
                    iw_caller.of_retrievelist();
                }
                of_close();
            }
        }

        #endregion
    }
}
