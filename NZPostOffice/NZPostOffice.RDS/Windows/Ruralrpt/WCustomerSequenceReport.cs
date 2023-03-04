using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared;
using Metex.Windows;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralwin2;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.DataControls.Ruralsec;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WCustomerSequenceReport : WReportAncestor
    {
        public WCustomerSequenceReport()
        {
            InitializeComponent();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            int lRow;
            int lRowCount;
            int lContract;
            int lFrequency;
            string sDeliveryDays;
            string ls_sortOrder = string.Empty;
            DataUserControl dwCriteria;
            //  TJB  Release 6.8.9 fixup
            //  Moved sort to stored procs
            // 		sp_summary_cust_list_hdr
            // 		sp_summary_cust_list_seq
            // 		sp_summary_cust_list_unseq
            //   ( also changed "dwRwsults" to "dwCriteria"
            //  Split reports into two datawindows:
            // 		r_summary_cust_list			 ( sequence order)
            // 		r_summary_cust_list_cust	 ( customer order)
            //  and created new datawindow and stored procedure for 
            //  the cust-order list:
            // 		r_summary_cust_list_cust_SEQ	 ( customer order)
            // 		sp_summary_cust_list_cust_seq
            dwCriteria = StaticVariables.gnv_app.of_get_parameters().dwparm;
            lContract = dwCriteria.GetValue<int>(0, "contract_no"); 
            lFrequency = dwCriteria.GetValue<int>(0, "sf_key");
            sDeliveryDays = dwCriteria.GetValue<string>(0, "delivery_days");
            ls_sortOrder = dwCriteria.GetValue<string>(0, "sortorder");
            if (ls_sortOrder == "S")
            {
                dw_report.DataObject = new RSummaryCustList();
            }
            else
            {
                dw_report.DataObject = new RSummaryCustListCust();
            }
            dw_report.Retrieve(new object[] { lContract, lFrequency, sDeliveryDays, ls_sortOrder });
            dw_report.Dock = DockStyle.Fill;

            //? dw_report.Modify("DataWindow.Print.Preview=No");
        }

        public override void retrieverow()
        {
            Application.DoEvents();
        }

        public virtual void dw_report_retrievestart()
        {
            return; //?2;
        }
    }
}
