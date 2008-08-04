using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Metex.Windows;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WReportMailCountPreview : WGenericReportPreview
    {
        DataUserControl dwResults = new DataUserControl();
        DataUserControl dwCriteria = new DataUserControl();

        public WReportMailCountPreview()
        {
            InitializeComponent();
        }

        public override void ue_report()
        {
            int? lnull;
            int lRow = 0;
            int lRowCount;
            int? lContract;
            int lSequence;
            WMailCountSearch w_mc_search;
            string ls_mc_date;
            string ls_mc_year;
            lnull = null;
            dwCriteria = StaticVariables.gnv_app.of_get_parameters().dwparm;
            dwResults = StaticVariables.gnv_app.of_get_parameters().miscdwparm;

            //  tjb  SR4650  Feb 2005
            //  Get the year from the entered mail count date
            ls_mc_date = dwCriteria.GetValue(0, "mail_count_date").ToString();
            ls_mc_year = ls_mc_date.Substring(ls_mc_date.Length - 4);// TextUtil.Right(ls_mc_date, 4);
            if (dwCriteria.GetValue(0, "blankforms") != null && (int)dwCriteria.GetValue(0, "blankforms") > 0)
            {
                // 
            }
            else
            {
                // Open abort window

                if (!(w_print_abort != null))
                {
                    //?OpenWithParm(w_print_abort, this);
                }
                dw_report.Reset();
                lRow = GetSelectedRow(0);
                if (lRow > 0)
                {
                    if (dwResults.GetValue(lRow, "contract_no") == null || (int)dwResults.GetValue(lRow, "contract_no") == 0)
                    {
                        lRowCount = dwResults.RowCount;
                        for (lRow = 0; lRow < lRowCount; lRow++)
                        {
                            lContract = (int)dwResults.GetValue(lRow, "contract_no");
                            if (lContract > 0)
                            {
                                ((RMailCount)dw_report.DataObject).Retrieve(lContract);
                            }
                        }
                    }
                    else
                    {
                        while (lRow > 0)
                        {
                            lContract = (int)dwResults.GetValue(lRow, "contract_no");
                            ((RMailCount)dw_report.DataObject).Retrieve(lContract);
                            lRow = GetSelectedRow(lRow + 1);
                        }
                    }
                }
            }
            if (StaticVariables.gnv_app.of_get_parameters().booleanparm)
            {
                StaticVariables.gnv_app.of_get_parameters().booleanparm = false;
                //dw_report.DataControl["print_kms"].Text = "\'N\'";
                dw_report.GetControlByName("print_kms").Text = "\'N\'";
            }
            //?dw_report.Modify("DataWindow.Print.Preview=Yes");
            //? dw_report.ResumeLayout(false);
            if (dwCriteria.GetValue(0, "blankforms") != null && (int)dwCriteria.GetValue(0, "blankforms") > 0)
            {
                int i;
                /*?
                if (!(w_printpage_abort != null))
                {
                    OpenWithParm(w_printpage_abort, this);
                }
                 
                dw_report.modify("datawindow.print.copies=" + String(dwCriteria.GetItemNumber(1, "blankforms")));
                dw_report.Print();
                PostEvent("ue_closewindow"); 
                */
            }
        }

        public int GetSelectedRow(int row)//added by ygu
        {
            if (dwResults.GetControlByName("grid") == null || row < 0 || row > dwResults.RowCount || ((DataEntityGrid)dwResults.GetControlByName("grid")).RowCount <= 0)
            {
                return -1;
            }

            for (int i = row; i < dwResults.RowCount; i++)
            {
                if (((DataEntityGrid)dwResults.GetControlByName("grid")).Rows[i].Selected)
                    return i;
            }
            return -1;
        }

        public override void printstart()
        {

        }

        public virtual void dw_report_retrieveend()
        {

        }
    }
}