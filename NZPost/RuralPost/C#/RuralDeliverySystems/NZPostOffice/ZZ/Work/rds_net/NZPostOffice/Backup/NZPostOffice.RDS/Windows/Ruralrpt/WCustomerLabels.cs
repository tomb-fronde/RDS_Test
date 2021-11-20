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
    public partial class WCustomerLabels : WReportAncestor
    {
        #region Define
        public bool bInOne;

        public int ilRow;

        public bool? ibprintedonparm;

        #endregion

        public WCustomerLabels()
        {
            InitializeComponent();
            dw_report.DataObject = new RCustlistLabelFast();

            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = "Rural Delivery System with NPAD Extensions (enabled)";
            }
        }

        public override void close()
        {
            base.close();
            //? rollback;
        }

        public override void pfc_postopen()
        {
            //! added code for he title of form which appears empty after parent class assigns ""                        
            this.Text = "Rural Delivery System with NPAD Extensions (enabled)";
            
            this.Width += 80;        


            int lRand;
            int lCount;
            int ll_Ret;
            int lIndex;
            int lRowCount;
            int lRow;
            Dictionary<int, int> lRands = new Dictionary<int, int>();
            bool bFound;
            bool bDone;
            int? iInt;
            int lCustId;
            string sSQLStatement;
            dw_report.Show();
            ibprintedonparm = StaticVariables.gnv_app.of_get_parameters().printedonparm;
            //this.SetRedraw(false);
            this.SuspendLayout();
            //  TJB  SR4646  Jan 2005
            //  Customer select moved to calling routine
            sSQLStatement = StaticVariables.gnv_app.of_get_parameters().stringparm;
            // 	LongParm used to identify the type of report/labels
            // 			-2			detailed report
            // 			-1			Address labels
            // 			>0			Random labels
            if (StaticVariables.gnv_app.of_get_parameters().longparm == -(1))
            {
                // 	time tnow
                // 	tnow=now ( )
                // 
                // 	execute immediate "delete from report_temp";
                // 	if sqlca.sqlcode = -1 then 
                // 		ROLLBACK;
                // 		messagebox ( this.title,"Warning: Unable to delete from temporary table")
                // 		RETURN
                // 	END IF
                // 
                // 		// TJB SR4646 - 'insert' now added in calling routine
                // 		// sSQLStatement = 'insert into report_temp '+sSQLStatement 
                // 	execute immediate :sSQLStatement ;
                // 	if sqlca.sqlcode = -1 then 
                // 		ROLLBACK;
                // 		messagebox ( this.title,"Warning: Unable to insert into temporary table")
                // 		RETURN
                // 	END IF
                // 
                // 	COMMIT;
                ll_Ret = dw_report.Retrieve(new Object[] { });
                // 	setmicrohelp ( 'Retrieve time: '+string ( secondsafter ( tnow,now ( )))+ 'second ( s)')
            }
            else
            {
                // 	EXECUTE IMMEDIATE "DELETE from tmp_rand_cust_list";
                // 	if sqlca.sqlcode = -1 then 
                // 		ROLLBACK;
                // 		messagebox ( this.title,"Warning: Unable to delete from temporary table")
                // 		RETURN
                // 	END IF
                // 	EXECUTE IMMEDIATE :sSQLStatement;
                // 	if sqlca.sqlcode = -1 then 
                // 		ROLLBACK;
                // 		messagebox ( this.title,"Warning: Unable to insert into temporary table")
                // 		RETURN
                // 	END IF
                //    COMMIT;
                dw_report.Reset();
                //dw_report.DataObject = new DwGroupDetails(r_custlist_random_label);
                dw_report.DataObject = new RCustlistRandomLabel();
                //? dw_report.Modify("DataWindow.Print.Preview=Yes");
                bInOne = true;
                iInt = StaticVariables.gnv_app.of_get_parameters().longparm;
                int ll_Count;
                /* select count(*) into :ll_Count from tmp_rand_cust_list;*/
                ll_Count = RDSDataService.GetTmpRandCustList();
                if (ll_Count < iInt)
                {
                    iInt = ll_Count;
                }
                ll_Ret = dw_report.Retrieve(new object[] { iInt });
 //?               dw_report.Sort<CustlistRandomLabel>();
            }
            Form frm = Application.OpenForms["WPrintAbort"];
            if (frm != null)
            {
                frm.Close();
            }
            this.ResumeLayout(false);
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            Cursor.Current = Cursors.WaitCursor;
            //?dw_report.Modify("DataWindow.Print.Preview=Yes");
            if (StaticVariables.gnv_app.of_get_parameters().integerparm < 1)
            {
                //dw_report.GetControlByName("r_recipients").Visible = false;
            }
        }

        public override void activate()
        {
            //? base.activate();
            if (m_sheet != null)
            {
                m_sheet._m_contractors.Visible = false;
                m_sheet._m_contracts.Visible = false;
                m_sheet._m_addresses.Visible = false;
            }
        }

        public virtual void dw_report_retrievestart()
        {
            if (!bInOne)
            {
                return;//2
            }
        }

        public virtual void printend()
        {
            Cursor.Current = Cursors.WaitCursor;
            int i;
            int lcust = 0;
            int SQLCode = 0;
            if (ibprintedonparm.GetValueOrDefault())
            {
                for (i = 0; i < dw_report.RowCount; i++)
                {
                    lcust = dw_report.GetValue<int>(i, "cust_id");
                    /* UPDATE rds_customer SET printedon = today(*) WHERE customer.cust_id = :lcust;*/
                }
                //?commit;
                RDSDataService.UpdateRdsCustomerPrintedon(lcust, ref SQLCode);
                if (SQLCode == -(1))
                {
                    MessageBox.Show("Cannot update customer printed date", "Date Printed");
                }
            }
        }
    }
}
