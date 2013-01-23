using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruraldw;
using Metex.Windows;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralrpt;
using System.Collections.Generic;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    // TJB  RPCR_047  Jan-2013
    // Added Show/Hide Details button (pb_outlet_details) and outlet details panel (dw_details)
    // Added outlet ID to passed parameters (in StaticMessage.LongParm)
    // Changed to initially display outlet detail panel (rather than search results panel)

    public class WQsOutlet : WMaster
    {
        #region Define
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Label st_1;
        public URdsDw dw_criteria;
        public URdsDw dw_results;
        public URdsDw dw_details;
        public Button pb_search;
        public Button pb_cancel;
        public Button pb_return;
        private Button pb_details;
        public Panel l_1;

        #endregion

        // TJB  RPCR_047  Jan-2013: Added
        string sOutlet;
        int    nOutlet;

        public WQsOutlet()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;
            dw_criteria.DataObject = new DQsOutletsCriteria();
            dw_results.DataObject = new DQsOutlets();
            dw_details.DataObject = new DQsOutletDetails();
            dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            dw_criteria.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_criteria_constructor);

            ((DQsOutlets)dw_results.DataObject).CellDoubleClick += new EventHandler(dw_results_doubleclicked);
            dw_results.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_results_constructor);
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WQsOutlet));
            this.st_1 = new System.Windows.Forms.Label();
            this.l_1 = new System.Windows.Forms.Panel();
            this.dw_criteria = new NZPostOffice.RDS.Controls.URdsDw();
            this.dw_details = new NZPostOffice.RDS.Controls.URdsDw();
            this.dw_results = new NZPostOffice.RDS.Controls.URdsDw();
            this.pb_details = new System.Windows.Forms.Button();
            this.pb_search = new System.Windows.Forms.Button();
            this.pb_cancel = new System.Windows.Forms.Button();
            this.pb_return = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // st_1
            // 
            this.st_1.BackColor = System.Drawing.SystemColors.Control;
            this.st_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_1.Location = new System.Drawing.Point(3, 302);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(75, 13);
            this.st_1.TabIndex = 1;
            this.st_1.Text = "WQsOutlet";
            // 
            // l_1
            // 
            this.l_1.BackColor = System.Drawing.Color.Black;
            this.l_1.Location = new System.Drawing.Point(3, 88);
            this.l_1.Name = "l_1";
            this.l_1.Size = new System.Drawing.Size(325, 1);
            this.l_1.TabIndex = 2;
            // 
            // dw_criteria
            // 
            this.dw_criteria.DataObject = null;
            this.dw_criteria.FireConstructor = false;
            this.dw_criteria.Location = new System.Drawing.Point(3, 0);
            this.dw_criteria.Name = "dw_criteria";
            this.dw_criteria.Size = new System.Drawing.Size(327, 64);
            this.dw_criteria.TabIndex = 1;
            // 
            // dw_details
            // 
            this.dw_details.DataObject = null;
            this.dw_details.FireConstructor = false;
            this.dw_details.Location = new System.Drawing.Point(3, 67);
            this.dw_details.Name = "dw_details";
            this.dw_details.Size = new System.Drawing.Size(327, 235);
            this.dw_details.TabIndex = 6;
            this.dw_details.Visible = false;
            // 
            // dw_results
            // 
            this.dw_results.DataObject = null;
            this.dw_results.FireConstructor = false;
            this.dw_results.Location = new System.Drawing.Point(3, 67);
            this.dw_results.Name = "dw_results";
            this.dw_results.Size = new System.Drawing.Size(327, 235);
            this.dw_results.TabIndex = 5;
            this.dw_results.Visible = true;
            this.dw_results.RowFocusChanged += new System.EventHandler(this.dw_results_rowfocuschanged);
            this.dw_results.Click += new System.EventHandler(this.dw_results_clicked);
            // 
            // pb_details
            // 
            this.pb_details.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pb_details.Location = new System.Drawing.Point(336, 87);
            this.pb_details.Name = "pb_details";
            this.pb_details.Size = new System.Drawing.Size(60, 41);
            this.pb_details.TabIndex = 0;
            this.pb_details.Text = "Show Details";
            this.pb_details.Click += new System.EventHandler(this.pb_details_clicked);
            // 
            // pb_search
            // 
            this.pb_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pb_search.Image = ((System.Drawing.Image)(resources.GetObject("pb_search.Image")));
            this.pb_search.Location = new System.Drawing.Point(337, 4);
            this.pb_search.Name = "pb_search";
            this.pb_search.Size = new System.Drawing.Size(59, 31);
            this.pb_search.TabIndex = 2;
            this.pb_search.Click += new System.EventHandler(this.pb_search_clicked);
            // 
            // pb_cancel
            // 
            this.pb_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.pb_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pb_cancel.Image = ((System.Drawing.Image)(resources.GetObject("pb_cancel.Image")));
            this.pb_cancel.Location = new System.Drawing.Point(337, 140);
            this.pb_cancel.Name = "pb_cancel";
            this.pb_cancel.Size = new System.Drawing.Size(59, 31);
            this.pb_cancel.TabIndex = 4;
            this.pb_cancel.Click += new System.EventHandler(this.pb_cancel_clicked);
            // 
            // pb_return
            // 
            this.pb_return.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pb_return.Image = ((System.Drawing.Image)(resources.GetObject("pb_return.Image")));
            this.pb_return.Location = new System.Drawing.Point(337, 45);
            this.pb_return.Name = "pb_return";
            this.pb_return.Size = new System.Drawing.Size(59, 31);
            this.pb_return.TabIndex = 3;
            this.pb_return.Click += new System.EventHandler(this.pb_return_clicked);
            // 
            // WQsOutlet
            // 
            this.AcceptButton = this.pb_search;
            this.CancelButton = this.pb_cancel;
            this.ClientSize = new System.Drawing.Size(399, 323);
            this.Controls.Add(this.pb_details);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.l_1);
            this.Controls.Add(this.dw_criteria);
            this.Controls.Add(this.dw_details);
            this.Controls.Add(this.dw_results);
            this.Controls.Add(this.pb_search);
            this.Controls.Add(this.pb_cancel);
            this.Controls.Add(this.pb_return);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WQsOutlet";
            this.Text = "Outlet Search";
            this.Controls.SetChildIndex(this.pb_return, 0);
            this.Controls.SetChildIndex(this.pb_cancel, 0);
            this.Controls.SetChildIndex(this.pb_search, 0);
            this.Controls.SetChildIndex(this.dw_results, 0);
            this.Controls.SetChildIndex(this.dw_details, 0);
            this.Controls.SetChildIndex(this.dw_criteria, 0);
            this.Controls.SetChildIndex(this.l_1, 0);
            this.Controls.SetChildIndex(this.st_1, 0);
            this.Controls.SetChildIndex(this.pb_details, 0);
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

        public override void pfc_postopen()
        {
            DataUserControl dwChild;

            sOutlet = StaticMessage.StringParm;
            nOutlet = (int)StaticMessage.LongParm;

            dw_criteria.InsertRow(0);
            if (!(StaticVariables.gnv_app.of_isempty(sOutlet)))
            {
                //dw_criteria.Modify("o_name.initial=\'" + sOutlet + '\'');
                dw_criteria.GetItem<QsOutletsCriteria>(0).OName = sOutlet;
            }
            dwChild = dw_criteria.DataObject.GetChild("region_id");
            dwChild.Retrieve();
            if (StaticVariables.gnv_app.of_get_parameters().integerparm > 0)
            {
                //dw_criteria.Modify("region_id.initial=\'" + StaticVariables.gnv_app.of_get_parameters().integerparm.ToString() + '\'');
                dw_criteria.GetItem<QsOutletsCriteria>(0).RegionId = StaticVariables.gnv_app.of_get_parameters().integerparm;
            }

            dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
            StaticVariables.gnv_app.of_get_parameters().longparm = -(1);
            // TJB 29 Mar 2004 - Temp fix? Stops outlet query 
            // crashing when called by RCM (only group) user
            // dw_criteria.of_filter_regions(This.of_Get_ComponentName())
            ((DataEntityCombo)dw_criteria.GetControlByName("region_id")).SelectedValueChanged += new EventHandler(dw_criteria_itemchanged);

            // TJB  RPCR_047  Jan-2013
            // On startup, display the address details of the current outlet (if there is one)
            this.SuspendLayout();
            hide_outlet_details();
            if (nOutlet != 0)
                display_outlet_details(nOutlet);
            
            this.PerformLayout();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname(StaticVariables.gnv_app.of_get_componentopened());
        }

        public virtual void dw_criteria_constructor()
        {
            dw_criteria.of_SetUpdateable(false);
        }

        public virtual void dw_results_constructor()
        {
            dw_results.of_SetUpdateable(false);
        }

        #region Events
        public virtual void dw_criteria_itemchanged(object sender, EventArgs e)
        {
            if (dw_criteria.GetColumnName() == "region_id")
            {
                dw_criteria.DataObject.SetValue(0, "o_name", "");
                dw_criteria.DataObject.AcceptText();
                dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
            }
        }

        public virtual void dw_results_doubleclicked(object sender, EventArgs e)
        {
            dw_results.URdsDw_DoubleClick(sender, e);
            if (dw_results.GetRow() >= 0)
            {
                dw_results.SelectRow(dw_results.GetRow() + 1/*row*/, true);
                pb_return_clicked(this, null);
            }
        }

        public virtual void dw_results_clicked(object sender, EventArgs e)
        {
            string sOName;

            if (dw_results.GetRow() >= 0)
            {
                //dw_results.ScrollToRow(row);
                dw_results.SetCurrent(dw_results.GetRow());

                // TJB  RPCR_047  Jan-2013
                // Added: display selected office name in selection criteria
                sOName = dw_results.DataObject.GetItem<QsOutlets>(dw_results.GetRow()).OName;
                dw_criteria.GetItem<QsOutletsCriteria>(0).OName = sOName;
                dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
            }
        }

        public virtual void dw_results_rowfocuschanged(object sender, EventArgs e)
        {
            //dw_results.SelectRow(0, false);
            //?dw_results.SelectRow(dw_results.GetRow(), true);
        }

        public virtual void pb_search_clicked(object sender, EventArgs e)
        {
            string sOutlet;
            int? lRegion;

            dw_criteria.DataObject.AcceptText();
            lRegion = dw_criteria.DataObject.GetItem<QsOutletsCriteria>(0).RegionId;
            sOutlet = dw_criteria.DataObject.GetItem<QsOutletsCriteria>(0).OName;
            if (lRegion == null)
            {
                lRegion = 0;
            }
            if (sOutlet == null)
            {
                sOutlet = "";
            }
            this.SuspendLayout();
            dw_results.DataObject.Reset();

            // TJB  RPCR_047  Jan-2013
            // Hide details and display search results
            hide_outlet_details();

            ((DQsOutlets)dw_results.DataObject).Retrieve(lRegion, sOutlet);
            //dw_results.TriggerEvent(rowfocuschanged!);
            dw_results_rowfocuschanged(null, null);

            // TJB  RPCR_047  Jan-2013
            // Added: display selected office name in selection criteria
            sOutlet = dw_results.DataObject.GetItem<QsOutlets>(dw_results.GetRow()).OName;
            dw_criteria.GetItem<QsOutletsCriteria>(0).OName = sOutlet;
            dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();

            this.PerformLayout();
            //l_1.Width = 309;
        }

        // TJB  RPCR_047  Jan-2013:  Added
        public virtual void hide_outlet_details()
        {
            dw_details.Visible = false;
            dw_results.Visible = true;
            pb_details.Text = "Show Details";
        }

        // TJB  RPCR_047  Jan-2013:  Added
        public virtual void display_outlet_details(int nOutlet)
        {
            dw_details.DataObject.Reset();
            ((DQsOutletDetails)dw_details.DataObject).Retrieve(nOutlet);
            dw_results.Visible = false;
            dw_details.Visible = true;
            this.pb_details.Text = "Hide Details";
        }

        // TJB  RPCR_047  Jan-2013:  Added
        // pb_details is a flip-flop: we want to be able to hide the details 
        // after selecting a search result and displaying its details in case 
        // we want to change the one we first selected without doing another search.
        public virtual void pb_details_clicked(object sender, EventArgs e)
        {
            this.SuspendLayout();

            // If the details are being displayed, hide them
            if (dw_details.Visible == true)
            {
                hide_outlet_details();
                return;
            }

            // Check to see if there's anything to display
            // The selection criteria outlet name will be blank if there isn't anything
            string sOName = dw_criteria.GetItem<QsOutletsCriteria>(0).OName;
            if (sOName == "")
            {
                MessageBox.Show("Please search for and select an office", "");
                hide_outlet_details();
            }
            else
            {
                // If there is something, its either a search result, or the initial office name
                // Start with the initial office ID (it will be zero if started with nothing)
                int nOutletId = nOutlet;
                // See if there's anything selected
                int nRow = dw_results.GetRow();
                if (nRow >= 0)  // yes there was
                {
                    int? nOutletIdSelected = dw_results.DataObject.GetItem<QsOutlets>(dw_results.GetRow()).OutletId;
                    // The selected office SHOULD have an ID, but if not, use 0
                    nOutletId = (nOutletIdSelected == null) ? 0 : (int)nOutletIdSelected;
                }

                display_outlet_details(nOutletId);
            }
            this.PerformLayout();
        }

        public virtual void pb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void pb_return_clicked(object sender, EventArgs e)
        {
            if (dw_results.GetRow() >= 0)
            {
                StaticVariables.gnv_app.of_get_parameters().longparm = dw_results.DataObject.GetItem<QsOutlets>(dw_results.GetRow()).OutletId;
                StaticVariables.gnv_app.of_get_parameters().integerparm = dw_criteria.DataObject.GetItem<QsOutletsCriteria>(0).RegionId;
                StaticVariables.gnv_app.of_get_parameters().stringparm = dw_results.DataObject.GetItem<QsOutlets>(dw_results.GetRow()).OName;
                //  TJB SR4579 - Pass back the office type
                StaticVariables.gnv_app.of_get_parameters().miscstringparm = dw_results.DataObject.GetItem<QsOutlets>(dw_results.GetRow()).OType;
                //  TWC - force retrieval of arguments in the search window
                int ll_sheetcount = int.MinValue;

                List<WGenericReportSearch> lw_opensheets = new List<WGenericReportSearch>();
                FormBase lw_frame;// WFrame lw_frame;
                lw_frame = StaticVariables.gnv_app.of_getframe();
                /*?if (IsValid(lw_frame.inv_sheetmanager) == false) 
                {
                    lw_frame.inv_sheetmanager = new NCstWinsrvSheetmanager();
                }*/
                //?ll_sheetcount = lw_frame.inv_sheetmanager.of_getsheetsbyclass(lw_opensheets, "w_mailmerge_customer_download_search");
                int? li_region;
                int? li_outlet;
                string ls_name;
                li_region = dw_criteria.DataObject.GetItem<QsOutletsCriteria>(0).RegionId;
                li_outlet = dw_results.DataObject.GetItem<QsOutlets>(dw_results.GetRow()).OutletId;
                ls_name = dw_results.DataObject.GetItem<QsOutlets>(dw_results.GetRow()).OName;
                if (ll_sheetcount > 0)
                {
                    //  get the window to reset the outlet
                    //?lw_opensheets[1].of_get_outlet(li_region, li_outlet, ls_name);
                }
                this.Close();
            }
            else
            {
                pb_cancel_clicked(this, null);
            }
        }
        #endregion
    }
}
