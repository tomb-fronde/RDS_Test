using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.RDS.DataService;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    // TJB  RPCR_057  Jan-2014
    // Added parameter to wf_gosearch function (ignored) to match 
    // overridden function in WGenericReportSearch

    public partial class WMailCountSearch : WGenericReportSearch
    {  
        public bool bdatechanged = false;

        public WMailCountSearch()
        {
            InitializeComponent();

            this.pb_1.BringToFront();
            dw_criteria.DataObject = new DReportGenericRegOutletCriteria();
            dw_results.DataObject = new DMailCountSearchResults();

            dw_criteria.EditChanged += new System.EventHandler(dw_criteria_editchanged);
            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            ((DMailCountSearchResults)dw_results.DataObject).DoubleClick += new System.EventHandler(dw_results_doubleclicked);
            this.pb_1.Click += new System.EventHandler(pb_1_clicked);

            dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            Metex.Windows.DataUserControl dwChild;
            int? lNull;
            lNull = null;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            //dw_criteria.InsertRow(0);
            isDataWindow = StaticVariables.gnv_app.of_get_parameters().stringparm;
            dw_criteria.GetControlByName("st_report").Text = StaticMessage.StringParm;
            dw_criteria.SetValue(0, "Checked1", true);
            dw_criteria.SetValue(0, "Checked2", true);

            //?dw_results.SetRowFocusIndicator(focusrect!);
            dw_criteria.GetControlByName("region_id").Visible = true;
            dw_criteria.GetControlByName("blankforms").Enabled = true;

            // Mail count date
            DateTime mcdate;

            /*SELECT mail_count_date.mail_count_date  INTO 	:mcdate  FROM 	mail_count_date  ;*/
            mcdate = RDSDataService.GetMailCountDateMailCountDate().GetValueOrDefault();
            //?dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).MailCountDate = mcdate;
            dw_criteria.SetValue(0, "mail_count_date", mcdate);

            int? rg_code;
            // Expiring renewal Groups
            // 1. Setup
            dwChild = dw_criteria.GetChild("rg_code1");
            ((DDddwRenewalgroup)dwChild).Retrieve();

            dwChild = dw_criteria.GetChild("rg_code2");
            ((DDddwRenewalgroup)dwChild).Retrieve();
            // 2. get values
            rg_code = null;
            /*SELECT min ( nvr.rg_code) INTO :rg_code FROM non_vehicle_rate nvr WHERE nvr.nvr_contract_end = ( SELECT min (  nvr2.nvr_contract_end ) FROM non_vehicle_rate nvr2 WHERE nvr2.nvr_contract_end >= :mcdate)  ;*/
            rg_code = RDSDataService.GetNonVehicleRateRgCodeMin(mcdate, ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                Console.Beep();
            }
            dw_criteria.SetValue(0, "rg_code1", rg_code);

            //  Get the 2nd renewal date after the mail count date
            int? rgcode2;

            rgcode2 = null;
            /*SELECT min ( nvr.rg_code) INTO :rgcode2 FROM non_vehicle_rate nvr WHERE 	nvr.rg_code <> :rg_code and  nvr.nvr_contract_end =  ( SELECT min ( nvr2.nvr_contract_end ) FROM non_vehicle_rate nvr2 WHERE nvr2.nvr_contract_end > :mcdate and nvr2.nvr_contract_end >  ( select min ( nvr3.nvr_contract_end) from 	non_vehicle_rate nvr3 where nvr3.nvr_contract_end >= :mcdate));*/
            rgcode2 = RDSDataService.GetNonVehicleRateRgCodeMin1(rg_code, mcdate, ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                Console.Beep();
            }
            dw_criteria.SetValue(0, "rg_code2", rgcode2);
            //added by ybfan
            dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
            //added by jlwang 
            dw_criteria.SetCurrent(0);
        }

        public virtual string wf_getparms()
        {
            string sRegion;
            string sOutlet;
            string sRenGroup;
            string sContract;
            string sParm;
            string sTemp;
            int? lRegion;
            int? lOutlet;
            int lRenGroup;
            int lContract;
            int lRow;
            int lcount;
            // get region, outlet codes
            lRegion = dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).RegionId;
            lOutlet = dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).OutletId;
            // get region, outlet description
            if ((lRegion == null))
            {
                sParm = "All Regions";
            }
            else
            {
                /*SELECT region.rgn_name  INTO :sParm FROM region  WHERE region.region_id = :lRegion;*/
                sParm = RDSDataService.GetRegion(lRegion);
            }
            if ((lOutlet == null))
            {
                sParm += "\r\nAll Outlets";
            }
            else
            {
                /*SELECT outlet.o_name  INTO :sTemp  FROM outlet  WHERE outlet.outlet_id = :lOutlet;*/
                sTemp = RDSDataService.GetOutletValue(lOutlet);
                sParm += "\r\n" + sTemp;
            }
            return sParm;
        }

        public override int wf_gosearch(bool bAllowAll)
        {
            DateTime mcdate;
            int? rg_code;
            int? rgcode2;
            int? lnull;
            lnull = null;
            rg_code = null;
            rgcode2 = null;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            dw_criteria.AcceptText();
            //  bdatechanged is set at editchanged event of dw_criteria.  
            if (bdatechanged)
            {
                MessageBox.Show("You have changed the date, Please save before searching.", "Date Changed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return 0;
            }
            mcdate = dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).MailCountDate.GetValueOrDefault().Date;
            //  Get the 1st renewal date where expiry date is after the mail count date
            /*SELECT min ( nvr.rg_code) INTO :rg_code FROM non_vehicle_rate nvr WHERE 	nvr.nvr_contract_end = ( SELECT min (  nvr.nvr_contract_end ) FROM non_vehicle_rate WHERE nvr.nvr_contract_end >= :mcdate)  ;*/
            rg_code = RDSDataService.GetNonVehicleRateRgCodeMin(mcdate, ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                Console.Beep();//Beep(1);
            }
            dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).RgCode1 = rg_code;
            //  Get the 2nd renewal date after the mail count date
            /*SELECT min ( non_vehicle_rate.rg_code) INTO :rgcode2 FROM non_vehicle_rate  WHERE non_vehicle_rate.rg_code <> :rg_code and  non_vehicle_rate.nvr_contract_end = ( SELECT min ( rg2.nvr_contract_end ) FROM non_vehicle_rate  rg2 WHERE rg2.nvr_contract_end > :mcdate and rg2.nvr_contract_end >  ( select min ( rg3.nvr_contract_end) from 	non_vehicle_rate  rg3 where rg3.nvr_contract_end >= :mcdate));*/
            rgcode2 = RDSDataService.GetNonVehicleRateRgCodeMin1(rg_code, mcdate, ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                Console.Beep();
            }
            dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).RgCode2 = rgcode2;
            dw_criteria.AcceptText();
            if ((dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).RgCode1 == null) && (dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).RgCode2 == null))
            {
                MessageBox.Show("No expiring renewal group found", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            // Find out which rg_code is checked
            // if checked1 = checked then use rg_code1
            // if checked2 = checked then use rg_code2
            // or use both if both check boxes  are checked
            if (dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).Checked1.GetValueOrDefault())//=="Y")
            {
                rg_code = dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).RgCode1;
            }
            else
            {
                rg_code = -(99999);
            }
            if (dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).Checked2.GetValueOrDefault())// == "Y")
            {
                rgcode2 = dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).RgCode2.GetValueOrDefault();
            }
            else
            {
                rgcode2 = -(99999);
            }
            ((DMailCountSearchResults)dw_results.DataObject).Retrieve(rg_code, rgcode2, dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).RegionId, dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).OutletId);
            //  Display results
            //  TJB  SR4650   Feb 2005
            //  Add <no contracts found> to search results
            //  and hide the pb_open button.
            pb_open.Visible = true;
            if (dw_results.RowCount == 0)
            {
                dw_results.InsertRow(0);
                dw_results.GetItem<MailCountSearchResults>(0).ConTitle = "<No Contracts Found>";
                dw_results.GetItem<MailCountSearchResults>(0).ContractNo = lnull;
                dw_results.GetItem<MailCountSearchResults>(0).ConActiveSequence = lnull;
                MessageBox.Show("Search Unsuccessful", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Question);
                pb_open.Visible = false;
                dw_criteria.Focus();
            }
            else
            {
                dw_results.InsertRow(0);
                lnull = null;
                dw_results.GetItem<MailCountSearchResults>(0).ConTitle = "<All Contracts>";
                dw_results.GetItem<MailCountSearchResults>(0).ContractNo = 0;
                dw_results.Focus();
            }
            return 1;
        }

        #region Events

        public override void dw_criteria_itemchanged(object sender, EventArgs e)
        {
            base.dw_criteria_itemchanged(sender, e);
        }

        public virtual void dw_criteria_ue_postitemchanged(object sender, EventArgs e)
        {
            // Mail count date
            DateTime mcdate;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            mcdate = dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).MailCountDate.GetValueOrDefault().Date;
            int? rg_code;
            rg_code = null;
            /*SELECT min ( nvr.rg_code) INTO :rg_code FROM non_vehicle_rate nvr WHERE nvr.nvr_contract_end = ( SELECT min (  nvr1.nvr_contract_end ) FROM non_vehicle_rate nvr1 WHERE nvr1.nvr_contract_end >= :mcdate)  ;*/
            rg_code = RDSDataService.GetNonVehicleRateRgCodeMin(mcdate, ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                Console.Beep();
            }
            dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).RgCode1 = rg_code;
            //  Get the 2nd renewal date after the mail count date
            int? rgcode2;
            rgcode2 = null;
            /*SELECT min ( nvr.rg_code) INTO :rgcode2 FROM non_vehicle_rate nvr WHERE nvr.rg_code <> :rg_code and  nvr.nvr_contract_end =  ( SELECT min ( nvr2.nvr_contract_end) FROM non_vehicle_rate nvr2 WHERE nvr2.nvr_contract_end > :mcdate and  nvr2.nvr_contract_end >   ( select min ( nvr3.nvr_contract_end)  from 	non_vehicle_rate nvr3  where nvr3.nvr_contract_end >= :mcdate));*/
            rgcode2 = RDSDataService.GetNonVehicleRateRgCodeMin1(rg_code, mcdate, ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                Console.Beep();
            }
            dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).RgCode2 = rgcode2;
            dw_results.Reset();
            // pb_search_clicked(this, null)
            return;//return 1;
        }

        public virtual void dw_criteria_losefocus(object sender, EventArgs e)
        {
            //?base.dw_criteria_losefocus();
            //  18Dec96 Mike Vautier 
            //  This is so dw_criteria contains the correct field values when search button pressed.  
            dw_criteria.AcceptText();
        }

        public virtual void dw_criteria_editchanged(object sender, EventArgs e)
        {
            if (dw_criteria.GetColumnName() == "mail_count_date")
            {
                bdatechanged = true;
            }
            //?base.editchanged();
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            string sTitle = string.Empty;
            dw_criteria.AcceptText();
            if (((dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).Blankforms == null) || dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).Blankforms.GetValueOrDefault() == 0) && dw_results.GetSelectedRow(0) == -1)
            {
                MessageBox.Show("You must select a contract or indicate a number of blank forms to print", "Blank Forms", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            StaticVariables.gnv_app.of_get_parameters().dwparm = dw_criteria.DataObject;
            StaticVariables.gnv_app.of_get_parameters().miscdwparm = dw_results.DataObject;
            //OpenSheetWithParm(w_report_mail_count_preview, sTitle, w_main_mdi, 0, original!);
            StaticMessage.StringParm = sTitle;
            WReportMailCountPreview w_report_mail_count_preview = new WReportMailCountPreview();
            w_report_mail_count_preview.MdiParent = StaticVariables.MainMDI;
            w_report_mail_count_preview.Show();
        }

        public virtual void pb_1_clicked(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            dw_criteria.AcceptText();
            DateTime mcdate;
            int LCOUNT;
            mcdate = dw_criteria.GetItem<ReportGenericRegOutletCriteria>(0).MailCountDate.GetValueOrDefault().Date;
            /*SELECT count ( mail_count_date.mail_count_date) INTO :lcount  FROM mail_count_date  ;*/
            LCOUNT = RDSDataService.GetMailCountDateMailCountDateCount();
            if (LCOUNT == 0)
            {
                /*INSERT INTO mail_count_date ( mail_count_date ) VALUES ( :mcdate )  ;*/
                RDSDataService.InsertMailCountDate(mcdate);
            }
            else
            {
                /*UPDATE mail_count_date SET mail_count_date = :mcdate  ;*/
                RDSDataService.UpdateMailCountDateMailCountDate(mcdate);
            }
            //?commit;
            bdatechanged = false;
        }
        #endregion
    }
}