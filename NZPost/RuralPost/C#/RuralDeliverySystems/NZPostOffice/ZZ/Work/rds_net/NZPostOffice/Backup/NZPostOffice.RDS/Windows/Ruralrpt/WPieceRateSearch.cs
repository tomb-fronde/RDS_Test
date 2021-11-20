using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataService;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WPieceRateSearch : WGenericReportSearch
    {
        public WPieceRateSearch()
        {
            InitializeComponent();

            dw_results.DataObject = new DReportGenericResults();
            // TJB  RD7_0043  Aug2009
            // Moved line instantiating dw_criteria
            dw_criteria.DataObject = new DReportGenericCriteriaWithMonth();
            ((TextBox)dw_criteria.GetControlByName("monthyear1")).GotFocus += new EventHandler(dw_criteria_GotFocus);

            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            ((DReportGenericCriteriaWithMonth)dw_criteria.DataObject).TextBoxLostFocus += new System.EventHandler(dw_criteria_ItemChange);
            ((Metex.Windows.DataEntityGrid)dw_results.GetControlByName("grid")).CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(pb_open_clicked);

            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dw_results.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        public override void pfc_preopen()
        {           
            base.pfc_preopen();
            DateTime dDate = DateTime.Today;
            ((TextBox)dw_criteria.GetControlByName("monthyear1")).Enabled = false;
            //?dDate = StaticMethods.RelativeDate(Today(), 0 - Day(Today()));
            if (dw_criteria.DataObject.RowCount > 0)
            {
                dw_criteria.SetValue(0, "monthyear", dDate);
                dw_criteria.AcceptText();
                dw_criteria.GetControlByName("st_report").Text = "\'Yearly/ Monthly Piece Rate Report\'";
                dw_criteria.SetValue(0, "ct_key", 1);
            }
        }

        public virtual string wf_getparms()
        {
            string sRegion;
            string sOutlet;
            string sRenGroup;
            string sContract;
            string sParm = string.Empty;
            string sTemp = string.Empty;
            int? lRegion;
            int? lOutlet;
            int? lRenGroup;
            int? lContract;
            int lRow;
            int lcount;
            int sqlCode = -1;
            string sqlErrText = string.Empty;

            // get region, outlet, renewal group codes
            lRegion = dw_criteria.GetItem<ReportGenericCriteriaWithMonth>(0).RegionId;
            lOutlet = dw_criteria.GetItem<ReportGenericCriteriaWithMonth>(0).OutletId;
            lRenGroup = dw_criteria.GetItem<ReportGenericCriteriaWithMonth>(0).RgCode;
            // get region, outlet, renewal group description
            if (lRegion == null)
            {
                sParm = "All Regions";
            }
            else
            {
                // SELECT region.rgn_name  INTO :sParm FROM region WHERE region.region_id = :lRegion;
                sParm = RDSDataService.GetRegionValue(lRegion, ref sqlCode, ref sqlErrText);
            }
            if (lOutlet == null)
            {
                sParm += "\nAll Outlets";
            }
            else
            {
                //SELECT outlet.o_name  INTO :sTemp  FROM outlet  WHERE outlet.outlet_id = :lOutlet;
                sTemp = RDSDataService.GetOutletValue(lOutlet);
                sParm += "\n" + sTemp;
            }
            if (lRenGroup == null)
            {
                sParm += "\nAll Renewal Groups";
            }
            else
            {
                //SELECT renewal_group.rg_description  INTO :sTemp  FROM renewal_group  WHERE renewal_group.rg_code = :lRenGroup   ;
                sTemp = RDSDataService.GetRenewalGroupValue(lRenGroup, ref sqlCode, ref sqlErrText);
                sParm += "\n" + sTemp;
            }
            // get contract
            lRow = dw_results.GetSelectedRow(0);
            if (lRow == 0)
            {
                sParm += "\nAll Contracts";
            }
            else
            {
                // see if there is more than 1 selected
                if (dw_results.GetSelectedRow(lRow + 1) == -1)      //only one selected:  ygu
                {
                    lContract = dw_results.GetItem<ReportGenericResults>(dw_results.GetSelectedRow(0)).ContractNo;//, "contract_no");
                    //SELECT contract.con_title INTO :sTemp  FROM contract  WHERE contract.contract_no = :lContract   ;
                    sTemp = RDSDataService.GetContractValue(lContract, ref sqlCode, ref sqlErrText);
                    sParm += "\n" + sTemp + " (" + lContract.ToString() + ")";
                }
                //else
                //{
                //    // sParm+='\nSelected Contracts'
                //}
            }
            return sParm;
        }

        #region Events
        public void dw_criteria_GotFocus(object sender, EventArgs e)
        {           
            ((MaskedTextBox)dw_criteria.GetControlByName("monthyear")).BringToFront();
            dw_criteria.GetControlByName("monthyear").Text = ((System.Windows.Forms.TextBox)dw_criteria.GetControlByName("monthyear1")).Text;
            ((MaskedTextBox)dw_criteria.GetControlByName("monthyear")).Focus();
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {           

            //WPieceRateReport wNewReport;
            //!if (dw_results.GetSelectedRow(0) == 0)
            if (dw_results.GetSelectedRow(0) < 0)
            {
                MessageBox.Show("You must select a contract"
                               , ""
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            StaticVariables.gnv_app.of_get_parameters().miscstringparm = wf_getparms();
            //added by ygu
            StaticVariables.gnv_app.of_get_parameters().regionIdPram = dw_criteria.GetItem<ReportGenericCriteriaWithMonth>(0).RegionId;
            //add by mkwang
            string date;
            DateTime? dt_edate;
            date = ((System.Windows.Forms.TextBox)dw_criteria.GetControlByName("monthyear1")).Text;
            if (date != "")
            {
                dt_edate = System.Convert.ToDateTime(("01" + "," + date.Substring(0, 2) + "," + "20" + date.Substring(3, 2)));
                StaticVariables.gnv_app.of_get_parameters().monthyearParm = dt_edate;
            }
            else
            {
                StaticVariables.gnv_app.of_get_parameters().monthyearParm = dw_criteria.GetItem<ReportGenericCriteriaWithMonth>(0).Monthyear;
            }
            StaticVariables.gnv_app.of_get_parameters().outletIdParm = dw_criteria.GetItem<ReportGenericCriteriaWithMonth>(0).OutletId;
            StaticVariables.gnv_app.of_get_parameters().resultdwparm = dw_results.DataObject;
            //
            if (dw_results.GetSelectedRow(0) >= 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                //OpenSheet(wNewReport, w_main_mdi, 0, original!);
                OpenSheet<WPieceRateReport>(StaticVariables.MainMDI);
            }
        }

        public virtual void dw_criteria_ItemChange(object sender, EventArgs e)
        {           
            ((TextBox)dw_criteria.GetControlByName("monthyear1")).Text 
                = dw_criteria.GetControlByName("monthyear").Text;
            ((TextBox)dw_criteria.GetControlByName("monthyear1")).BringToFront();
            ((TextBox)dw_criteria.GetControlByName("monthyear1")).Enabled = true;
        }
        #endregion

        // TJB  RD7_0043  Aug2009
        // Added (accidentally)
        private void dw_results_Click(object sender, EventArgs e)
        {
        }
    }
}