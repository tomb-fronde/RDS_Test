using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WPieceRateSummary : WGenericReportPreview
    {
        public WPieceRateSummary()
        {
            InitializeComponent();
        }

        public override void pfc_preopen()
        {
            //?base.pfc_preopen();

            // long lRow
            // long lRowCount
            // long aContract[]
            // long lRegion
            // long lOutlet
            // date dReportMonth
            // date dBOFY
            // 
            // datawindow dwResults
            // 
            // 
            // dw_report.DataObject = gnv_App.of_Get_Parameters ( ).StringParm
            // dw_Report.Modify ( "DataWindow.Print.Preview=Yes")
            // 
            // 
            // dwResults = w_Generic_Report_Search_with_date.dw_Results
            // 
            // lRow = dwResults.GetSelectedRow ( 0)
            // 
            // if lRow > 0 then
            // 	if dwResults.GetItemNumber ( lRow, "contract_no") = 0 then
            // 		lRowCount = dwResults.RowCount
            // 		for lRow = 1 to lRowCount
            // 
            // 			lContract = dwResults.GetItemNumber ( lRow, "contract_no")
            // 			lSequence = dwResults.GetItemNumber ( lRow, "con_active_Sequence")
            // 
            // 			if lContract > 0 then
            // 				dw_Report.Retrieve ( lContract, lSequence, gnv_App.of_Get_Parameters ( ).dateparm)
            // 			end if
            // 		next
            // 	end if
            // else
            // 	do while lRow > 0
            // 		lContract = dwResults.GetItemNumber ( lRow, "contract_no")
            // 		lSequence = dwResults.GetItemNumber ( lRow, "con_active_Sequence")
            // 
            // 		dw_Report.Retrieve ( lContract, lSequence, gnv_App.of_Get_Parameters ( ).dateparm)
            // 
            // 		lRow = dwResults.GetSelectedRow ( lRow)
            // 	loop
            // end if
        }
    }
}