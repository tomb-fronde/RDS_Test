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
using System;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WGenericReportPreview : WReportAncestor
    {
        private const string DEFAULT_ASSEMBLY = "NZPostOffice.RDS.DataControls";
        private const string DEFAULT_VERSION = "1.0.0.0";

        public WGenericReportPreview()
        {
            InitializeComponent();
        }

        public override void ue_abort()
        {
            base.ue_abort();
            ib_Abort = true;
        }

        public override void ue_report()
        {
            int lRow = 0;
            int lSingleCounter;
            int lRowCount;
            int lContract;
            int lSequence;
            URdsDw dwResults = null;
            //  TJB SR4615 17 May 2004
            int ll_num_dispatches;
            bool lb_doreport;
            string ls_message;
            string ls_reportname;
            lSingleCounter = 0;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            if (StaticVariables.gnv_app.of_get_parameters().stringparm.Length == 0)
            {
                return;
            }
            //dwResults.DataObject = (DataUserControl)StaticVariables.gnv_app.of_get_parameters().dwparm;
            dwResults = (URdsDw)StaticVariables.window;
            StaticVariables.window = null;
            if (dwResults == null)
            {
                return;
            }
            ls_reportname = StaticVariables.gnv_app.of_get_parameters().stringparm;
            dw_report.SetDataObject(DEFAULT_ASSEMBLY, DEFAULT_VERSION, (StaticFunctions.migrateName(ls_reportname)).Trim());
            //.DataObject = (DataUserControl)StaticVariables.gnv_app.of_get_parameters().dwparm;
            //dwResults.DataObject = (DataUserControl)StaticVariables.gnv_app.of_get_parameters().dwparm;

            //jlwang:
            if (StaticFunctions.migrateName(ls_reportname) == "RSchedulebSingleContract")
                dw_report.DataObject = new RSchedulebSingleContract();
            else if (StaticFunctions.migrateName(ls_reportname) == "RMailCarriedSingleContract")
                dw_report.DataObject = new RMailCarriedSingleContract();



            lRow = dwResults.GetSelectedRow(0);
            dw_report.Reset();
            if (lRow >= 0)
            {
                if (dwResults.GetValue<int>(lRow, "contract_no") == 0)
                {
                    //  All contracts
                    lRowCount = dwResults.RowCount;
                    lSingleCounter = 0;
                    for (lRow = 0; lRow < lRowCount; lRow++)
                    {
                        lContract = dwResults.GetValue<int>(lRow, "contract_no");
                        lSequence = dwResults.GetValue<int>(lRow, "con_active_Sequence");
                        //  TJB SR4615 17 May 2004
                        //  Added to check where there's anything to report iff this
                        //  is a Mails Carried report.
                        if (ls_reportname == "r_mail_carried_single_contract")
                        {
                            /* select count ( mail_carried.mc_dispatch_carried)
                             into :ll_num_dispatches
                             from contract
                             , outlet
                             , contract_renewals
                             , mail_carried
                             where contract.contract_no = :lContract
                             and contract.con_base_office=outlet.outlet_id
                             and  ( contract.contract_no=contract_renewals.contract_no
                             and contract_renewals.contract_seq_number=:lSequence)
                             and  ( contract.contract_no=mail_carried.contract_no
                             and mail_carried.mc_disbanded_date is null)
                             using sqlca;*/
                            ll_num_dispatches = RDSDataService.GetLlNumDispatchesInfo(lContract, lSequence, ref SQLCode, ref SQLErrText);
                            if (SQLCode != 0)
                            {
                                // MessageBox.Show(ls_message + Char(10) + app.sqlca.SQLErrText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                MessageBox.Show(SQLErrText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                //?rollback;
                                ib_Abort = true;
                                break;
                            }
                            if (ll_num_dispatches > 0)
                            {
                                lb_doreport = true;
                            }
                            else
                            {
                                lb_doreport = false;
                            }
                        }
                        else
                        {
                            //  generate the report the 'original' way.
                            lb_doreport = true;
                        }
                        if (lContract > 0 && lb_doreport == true)
                        {
                            // dw_report.Retrieve(lContract, lSequence);
                            dw_report.Retrieve(new object[] { lContract, lSequence });
                        }
                        // Exit when aborted
                        if (ib_Abort)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    //  Specific contract
                    while (lRow > 0)
                    {
                        lContract = dwResults.GetValue<int>(lRow, "contract_no");
                        lSequence = dwResults.GetValue<int>(lRow, "con_active_Sequence");
                        //  TJB SR4615 17 May 2004
                        //  Added to check where there's anything to report.
                        if (ls_reportname == "r_mail_carried_single_contract")
                        {
                            /*select count ( mail_carried.mc_dispatch_carried)
                            into :ll_num_dispatches
                            from contract
                            , outlet
                            , contract_renewals
                            , mail_carried
                            where contract.contract_no = :lContract
                            and contract.con_base_office=outlet.outlet_id
                            and  ( contract.contract_no=contract_renewals.contract_no
                            and contract_renewals.contract_seq_number=:lSequence)
                            and  ( contract.contract_no=mail_carried.contract_no
                            and mail_carried.mc_disbanded_date is null)
                            using sqlca;*/
                            ll_num_dispatches = RDSDataService.GetLlNumDispatchesInfo(lContract, lSequence, ref SQLCode, ref SQLErrText);
                            if (SQLCode != 0)
                            {
                                // MessageBox.Show(ls_message + Char(10) + app.sqlca.SQLErrText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                MessageBox.Show(SQLErrText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                //?rollback;
                                ib_Abort = true;
                                break;
                            }
                            if (ll_num_dispatches > 0)
                            {
                                lb_doreport = true;
                            }
                            else
                            {
                                lb_doreport = false;
                            }
                        }
                        else
                        {
                            //  generate the report the 'original' way.
                            lb_doreport = true;
                        }
                        if (lContract > 0 && lb_doreport == true)
                        {
                            // dw_report.Retrieve(lContract, lSequence);
                            dw_report.Retrieve(new object[] { lContract, lSequence });
                            lSingleCounter++;
                        }
                        lRow = dwResults.GetSelectedRow(lRow + 1);
                        // Exit when aborted
                        if (ib_Abort)
                        {
                            break;
                        }
                    }
                }
            }
            if (lSingleCounter == 1)
            {
                if (dw_report.DataObject.Name == "r_route_description_single_contract" || dw_report.DataObject.Name == "r_mail_carried_single_contract")
                {
                    if (!((StaticVariables.gnv_app.of_get_parameters().dateparm == null)))
                    {
                        dw_report.SetValue(0, "Con_Start_date", StaticVariables.gnv_app.of_get_parameters().dateparm);
                        //  dw_report.modify ( "ft.expression='This description is effective from " + string ( gnv_App.of_Get_Parameters ( ).dateparm, "dd/mm/yyyy") + " and may not be altered without the approval of New Zealand Post Limited\r\r\nSignature of Owner Driver_______________________________   Date ____________'")
                    }
                }
            }
            if (StaticVariables.gnv_app.of_get_parameters().booleanparm)
            {
                StaticVariables.gnv_app.of_get_parameters().booleanparm = false;
                //dw_report.DataControl["print_kms"].Text = "\'N\'";
                dw_report.GetControlByName("print_kms").Text = "\'N\'";
            }
            //? dw_report.Modify("DataWindow.Print.Preview=Yes");
            dw_report.DataObject.RetrieveEnd += new EventHandler(dw_report_retrieveend);
        }

        public virtual void constructor()
        {
            dw_report.of_SetUpdateable(false);
        }

        public virtual bool wf_set_pending_date()
        {
            //  called from w_route_frequency_report_search.  
            //  Instead of the date for the current contract, uses the pending contract.
            return true;
        }

        public void dw_report_retrieveend()
        {
            if (StaticVariables.gnv_app.of_get_parameters().stringparm.IndexOf("single") == 0 && StaticVariables.gnv_app.of_get_parameters().stringparm != "r_contract_summary")
            {
                if (w_print_abort != null)
                {
                    w_print_abort.Close();
                }
            }
        }

        public int dw_report_retrievestart()
        {
            return 2;
        }

        public int dw_report_dberror(object sender, EventArgs e)
        {
            return 1;
        }
    }
}
