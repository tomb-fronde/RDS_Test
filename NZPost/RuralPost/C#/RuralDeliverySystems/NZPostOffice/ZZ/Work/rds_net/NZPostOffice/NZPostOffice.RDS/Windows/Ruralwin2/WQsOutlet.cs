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
    public class WQsOutlet : WMaster
    {
        #region Define
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Label st_1;

        public URdsDw dw_criteria;

        public URdsDw dw_results;

        public Button pb_search;

        public Button pb_cancel;

        public Button pb_return;

        public Panel l_1;

        #endregion

        public WQsOutlet()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;

            //jlwang:moved from IC
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            dw_criteria.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_criteria_constructor);

            ((DQsOutlets)dw_results.DataObject).CellDoubleClick += new EventHandler(dw_results_doubleclicked);
            dw_results.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_results_constructor);
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
            this.st_1 = new Label();
            this.l_1 = new Panel();
            this.dw_criteria = new URdsDw();
            dw_criteria.DataObject = new DQsOutletsCriteria();
            this.dw_results = new URdsDw();
            dw_results.DataObject = new DQsOutlets();
            this.pb_search = new Button();
            this.pb_cancel = new Button();
            this.pb_return = new Button();
            Controls.Add(st_1);
            Controls.Add(l_1);
            Controls.Add(dw_criteria);
            Controls.Add(dw_results);
            Controls.Add(pb_search);
            Controls.Add(pb_cancel);
            Controls.Add(pb_return);
            this.Text = "Outlet Search";
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(407, 350);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // 
            // st_1
            // 
            st_1.TabStop = false;
            st_1.Text = "w_qs_outlet";
            st_1.BackColor = System.Drawing.SystemColors.Control;
            st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_1.Location = new System.Drawing.Point(3, 302);
            st_1.Size = new System.Drawing.Size(75, 13);
            // 
            // dw_criteria
            // 
            dw_criteria.TabIndex = 1;
            dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_criteria.Location = new System.Drawing.Point(3, 0);
            dw_criteria.Size = new System.Drawing.Size(327, 64);
            //((DataEntityCombo)dw_criteria.GetControlByName("region_id")).SelectedValueChanged += new EventHandler(dw_criteria_itemchanged);
            //dw_criteria.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_criteria_constructor);

            // 
            // l_1
            //
            l_1.Height = 1;
            l_1.Width = 325;
            l_1.BackColor = System.Drawing.Color.Black;
            l_1.BorderStyle = BorderStyle.None;
            l_1.Location = new System.Drawing.Point(3, 88);

            // 
            // dw_results
            // 
            dw_results.TabIndex = 5;
            dw_results.Location = new System.Drawing.Point(3, 67);
            dw_results.Size = new System.Drawing.Size(327, 235);
            dw_results.Click += new EventHandler(dw_results_clicked);
            dw_results.RowFocusChanged += new EventHandler(dw_results_rowfocuschanged);
            //((DQsOutlets)dw_results.DataObject).CellDoubleClick += new EventHandler(dw_results_doubleclicked);
            //dw_results.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_results_constructor);

            // 
            // pb_search
            // 
            pb_search.Image = global::NZPostOffice.Shared.Properties.Resources.SEARCH;
            this.AcceptButton = pb_search;
            pb_search.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            pb_search.TabIndex = 2;
            pb_search.Location = new System.Drawing.Point(337, 4);
            pb_search.Size = new System.Drawing.Size(59, 31);
            pb_search.Click += new EventHandler(pb_search_clicked);

            // 
            // pb_cancel
            // 
            pb_cancel.Image = global::NZPostOffice.Shared.Properties.Resources.CANCEL;
            this.CancelButton = pb_cancel;
            pb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            pb_cancel.TabIndex = 4;
            pb_cancel.Location = new System.Drawing.Point(337, 86);
            pb_cancel.Size = new System.Drawing.Size(59, 31);
            pb_cancel.Click += new EventHandler(pb_cancel_clicked);

            // 
            // pb_return
            // 
            pb_return.Image = global::NZPostOffice.Shared.Properties.Resources.RETURN;
            pb_return.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            pb_return.TabIndex = 3;
            pb_return.Location = new System.Drawing.Point(337, 45);
            pb_return.Size = new System.Drawing.Size(59, 31);
            pb_return.Click += new EventHandler(pb_return_clicked);
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

        public override void pfc_postopen()
        {
            DataUserControl dwChild;
            string sOutlet;
            sOutlet = StaticMessage.StringParm;
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
            //?dw_results.SetRowFocusIndicator(focusrect!);
            StaticVariables.gnv_app.of_get_parameters().longparm = -(1);
            // TJB 29 Mar 2004 - Temp fix? Stops outlet query 
            // crashing when called by RCM  ( only group) user
            // dw_criteria.of_filter_regions ( This.of_Get_ComponentName ( ))
            ((DataEntityCombo)dw_criteria.GetControlByName("region_id")).SelectedValueChanged += new EventHandler(dw_criteria_itemchanged);//ttjin.
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
            if (dw_results.GetRow() >= 0)
            {
                //dw_results.ScrollToRow(row);
                dw_results.SetCurrent(dw_results.GetRow());
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
            dw_results.DataObject.Reset();
            ((DQsOutlets)dw_results.DataObject).Retrieve(lRegion, sOutlet);
            //dw_results.TriggerEvent(rowfocuschanged!);
            dw_results_rowfocuschanged(null, null);
            l_1.Width = 309;
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
