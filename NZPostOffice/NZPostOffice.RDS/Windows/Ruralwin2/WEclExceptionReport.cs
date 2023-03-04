using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public partial class WEclExceptionReport : WMaster
    {
        private WEclDataImport lw_parent;
        private string sBatchNo;

        public WEclExceptionReport()
        {
            InitializeComponent();
            lw_parent = (WEclDataImport)StaticMessage.PowerObjectParm;
            sBatchNo = StaticMessage.StringParm;
            showreport();
        }

        private System.Data.DataSet EclErrDataset;
        private System.Data.DataTable EclErrDatatable;
        //        public List<EclImportError> ecl_import_error_list;

        private bool cr_error_datatable(string pBatchNo)
        {
            int nRows;
            string sTicketNo   = "";
            string sTicketPart = "";
            string sBatchId    = "";
            string sErrorValue = "";
            string sErrorText = "";
            System.Data.DataRow r;

            EclErrDatatable = new DataTable("EclErrorList");
            
            try
            {
                EclErrDatatable.Columns.Add("EclBatchNo", Type.GetType("System.String"));
                EclErrDatatable.Columns.Add("EclTicketNo", Type.GetType("System.String"));
                EclErrDatatable.Columns.Add("EclTicketPart", Type.GetType("System.String"));
                EclErrDatatable.Columns.Add("EclBatchId", Type.GetType("System.String"));
                EclErrDatatable.Columns.Add("EclErrorValue", Type.GetType("System.String"));
                EclErrDatatable.Columns.Add("EclErrorText", Type.GetType("System.String"));

                nRows = lw_parent.ecl_import_error_list.Count;
                for (int i = 0; i < nRows; i++)
                {
                    sTicketNo = lw_parent.ecl_import_error_list[i].EclTicketNo;
                    sTicketPart = lw_parent.ecl_import_error_list[i].EclTicketPart;
                    sBatchId = lw_parent.ecl_import_error_list[i].EclBatchId;
                    sErrorValue = lw_parent.ecl_import_error_list[i].ErrorValue;
                    sErrorText = lw_parent.ecl_import_error_list[i].ErrorMsgText;

                    r = EclErrDatatable.NewRow();
                    r["EclBatchNo"] = pBatchNo;
                    r["EclTicketNo"] = sTicketNo;
                    r["EclTicketPart"] = sTicketPart;
                    r["EclBatchId"] = sBatchId;
                    r["EclErrorValue"] = sErrorValue;
                    r["EclErrorText"] = sErrorText;
                    EclErrDatatable.Rows.Add(r);
                }
            }

            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private void showreport()
        {
            int nRows = 0;
            string sTopLine = "---------------------------------------\n\n";
            string sBottomLine = "\n\n---------------------------------------";

            if (!cr_error_datatable(sBatchNo))
            {
                MessageBox.Show(sTopLine + "Oops\n" + sBottomLine
                                , "ECL Data Import");
            }
            EclErrDataset = new DataSet();
            EclErrDataset.Tables.Add(EclErrDatatable);

            nRows = EclErrDataset.Tables.Count;
            nRows = EclErrDatatable.Rows.Count;

            this.rEclDataImportExeption1.SetDataSource(EclErrDataset.Tables[0]);
            this.crystalReportViewer1.ReportSource = this.rEclDataImportExeption1;
            this.crystalReportViewer1.Refresh();
        }

        private void cb_cancel_Click(object sender, EventArgs e)
        {
            StaticVariables.gnv_app.of_get_parameters().stringparm = "Bye Bye";
            this.Close();
        }
    }
}