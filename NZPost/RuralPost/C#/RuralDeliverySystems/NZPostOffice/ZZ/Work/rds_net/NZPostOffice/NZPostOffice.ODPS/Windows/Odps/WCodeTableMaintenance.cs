using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.Menus;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.Windows.Odps
{
    public partial class WCodeTableMaintenance : WMaster
    {
        #region Define
        public bool ib_account_retrieve;
        public bool ib_pbu_retrieve;
        public bool ib_pct_retrieve;
        public bool ib_national_retrieve;

        public MOdpsMaintenance m_odps_maintenance;
        #endregion

        public WCodeTableMaintenance()
        {
            this.InitializeComponent();
            m_odps_maintenance = new MOdpsMaintenance(this);

            //? m_odps_maintenance_menu.SetFunctionalPart(m_odps_maintenance);
            //? m_odps_maintenance_toolbar.SetFunctionalPart(m_odps_maintenance);
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            // 	Object:			w_CodeTables
            // 	Method:			pfc_PreOpen
            // 	Description:	perform the open logic, start the window services desired
            // This.of_SetResize  (  TRUE )
        }

        public override void pfc_postopen()
        {
            uo_1.dw_selection.Retrieve();
        }

        public virtual void pfc_addrow()
        {
            //? base.pfc_addrow();
            //  pfc_addrow is triggered by the menu and is trapped here
            //  from where it is redirected to the required tab
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            int TestExpr = tab_folder.SelectedIndex + 1;
            if (TestExpr == 1)
            {
                //tab_folder.tabpage_account_code.uo_1.triggerevent("ue_new");
                uo_1.ue_new();
            }
            else if (TestExpr == 2)
            {
                //tab_folder.tabpage_pbu_code.uo_2.triggerevent("ue_new");
                uo_2.ue_new();
            }
            else if (TestExpr == 3)
            {
                //tab_folder.tabpage_pct.uo_3.triggerevent("ue_new");
                uo_3.ue_new();
            }
            else if (TestExpr == 4)
            {
                //tab_folder.tabpage_national.uo_4.triggerevent("ue_new");
                uo_4.ue_new();
            }
        }

        public virtual void pfc_deleterow()
        {
            //? base.pfc_deleterow();
            //  pfc_deleterow is triggered by the menu and is trapped here
            //  from where it is redirected to the required tab
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            int TestExpr = tab_folder.SelectedIndex + 1;//.selectedtab;
            if (TestExpr == 1)
            {
                //tab_folder.tabpage_account_code.uo_1.triggerevent("ue_delete");
                uo_1.ue_delete();
            }
            else if (TestExpr == 2)
            {
                //tab_folder.tabpage_pbu_code.uo_2.triggerevent("ue_delete");
                uo_2.ue_delete();
            }
            else if (TestExpr == 3)
            {
                //tab_folder.tabpage_pct.uo_3.triggerevent("ue_delete");
                uo_3.ue_delete();
            }
            else if (TestExpr == 4)
            {
                //tab_folder.tabpage_national.uo_4.triggerevent("ue_delete");
                uo_4.ue_delete();
            }
        }

        //added by jlwang
        public override int pfc_save()
        {
            //must check validation if pass call save
            if (tab_pfc_validation() == 1)
            {
                uo_1.dw_selection.Save();

                //if (uo_1.dw_selection.GetItem<AccountCode>(uo_1.dw_selection.GetRow()).SQLErrText != "")
                //{
                //    MessageBox.Show(uo_1.dw_selection.GetItem<AccountCode>(uo_1.dw_selection.GetRow()).SQLErrText, "Error/Warning Message(s)");
                //    return -1;
                //}
                uo_2.dw_selection.Save();
                //if (uo_2.dw_selection.GetItem<PbuCode>(uo_2.dw_selection.GetRow()).SQLErrText != "")
                //{
                //    MessageBox.Show(uo_2.dw_selection.GetItem<PbuCode>(uo_2.dw_selection.GetRow()).SQLErrText, "Error/Warning Message(s)");
                //    return -1;
                //}
                uo_3.dw_selection.Save();
            }
            return 1;
        }

        //jlwang:validate 
        public virtual int tab_pfc_validation()
        {
            int iRet = 1;
            this.ProcessDialogKey(Keys.Tab);

            for (int i = 0; i < uo_1.dw_selection.RowCount; i++)
            {
                if (uo_1.dw_selection.GetItem<AccountCode>(i).IsDirty)
                {
                    if (uo_1.dw_selection.GetItem<AccountCode>(i).AcCode == null ||
                        uo_1.dw_selection.GetItem<AccountCode>(i).AcDescription == null)
                    {
                        //store the error information for display
                        iRet = -1;
                    }
                    else
                    {
                        int iRow = uo_1.dw_selection.Find("ac_code", uo_1.dw_selection.GetItem<AccountCode>(i).AcCode);
                        if (i > 0 && i != iRow && iRow >= 0)
                        {
                            //store the error information for display
                            iRet = -1;
                        }
                    }
                }
            }


            for (int i = 0; i < uo_2.dw_selection.RowCount; i++)
            {
                if (uo_2.dw_selection.GetItem<PbuCode>(i).IsDirty)
                {
                    if (uo_2.dw_selection.GetItem<PbuCode>(i).Pbucode == null ||
                        uo_2.dw_selection.GetItem<PbuCode>(i).PbuDescription == null)
                    {
                        //store the error information for display
                        iRet = -1;
                    }
                    else
                    {
                        int iRow = uo_2.dw_selection.Find("pbucode", uo_2.dw_selection.GetItem<PbuCode>(i).Pbucode);
                        if (i > 0 && i != iRow && iRow >= 0)
                        {
                            //store the error information for display
                            iRet = -1;
                        }
                    }
                }
            }

            for (int i = 0; i < uo_3.dw_selection.RowCount; i++)
            {
                if (uo_3.dw_selection.GetItem<NZPostOffice.ODPS.Entity.OdpsRep.PaymentComponentType>(i).IsDirty)
                {
                    if (uo_3.dw_selection.GetItem<NZPostOffice.ODPS.Entity.OdpsRep.PaymentComponentType>(i).PctDescription == null)// ||                            uo_2.dw_selection.GetItem<NZPostOffice.ODPS.Entity.OdpsRep.PaymentComponentType>(i).AcDescription == null)
                    {
                        //store the error information for display
                        iRet = -1;
                    }
                }
            }

            if (iRet == -1)
            {
                WValidationerror w_error = new WValidationerror();
                w_error.Show();
                w_error.Location = new Point(this.Location.X + 115, this.Location.Y + 300);
            }
            return iRet;
        }

        //?public virtual void pfc_endtran(int ai_update_results) 
        //{
        //    base.pfc_endtran();
        //    // 	Object:			w_CodeTables
        //    // 	Method:			pfc_EndTran
        //    // 	Description:	issue the commit or rollback accordingly
        //    int li_Return;
        //    if (ai_update_results < 0) 
        //    {
        //        ROLLBACK USING SQLCA;
        //        li_Return = -(1);
        //    }
        //    else {
        //        COMMIT USING SQLCA;
        //        if (StaticVariables.sqlca.SQLCode != 0)
        //        {
        //            ROLLBACK USING SQLCA;
        //            li_Return = -(1);
        //        }
        //        else {
        //            li_Return = 1;
        //        }
        //    }
        //    return li_Return;
        //}

        public virtual int of_retrievedw(URdsDw adwv_control)
        {
            // 	Object:			w_CodeTable
            // 	Method:			of_Retrievedw
            // 	Description:	retrieve the datawindow stuff
            // 	Arguments:		adwv_Control - datawindow of type u_dw
            // 	Returns:			0
            int ll_RowCount;
            // 	HELP:	setup the retrieval arguments  (  if any ) for the datawindow
            //? this.SetMicroHelp("Retrieving Information . . .");
            ll_RowCount = adwv_control.Retrieve();
            adwv_control.Focus();
            //? this.SetMicroHelp("Ready");
            return ll_RowCount;
        }

        public virtual int of_setupdw(URdsDw adwv_control)
        {
            // 	Object:			w_CodeTable
            // 	Method:			of_Setupdw
            // 	Description:	start the specific services for the datawindow
            // 	Arguments:		adwv_Control - datawindow of type u_dw
            // 	Returns:			0
            //? adwv_control.of_settransobject(StaticVariables.sqlca);
            //? adwv_control.of_setgenerateuniquenbr(true);
            //? adwv_control.of_setcolumnmanager(true);
            //? adwv_control.of_setrowmanager(true);
            //? adwv_control.of_setvalidation(true);
            return 0;
        }

        public virtual void cs_setup()
        {
        }

        public virtual void tab_folder_selectionchanged(object sender, EventArgs e)
        {
            int newindex = tab_folder.SelectedIndex + 1;

            if (newindex == 1 && !ib_account_retrieve)
            {
                //tabpage_account_code.uo_1.dw_selection.retrieve();
                uo_1.dw_selection.Retrieve();
                ib_account_retrieve = true;
            }
            if (newindex == 2 && !ib_pbu_retrieve)
            {
                //tabpage_pbu_code.uo_2.dw_selection.retrieve();
                uo_2.dw_selection.Retrieve();
                ib_pbu_retrieve = true;
            }
            if (newindex == 3 && !ib_pct_retrieve)
            {
                //tabpage_pct.uo_3.dw_selection.retrieve();
                uo_3.dw_selection.Retrieve();
                ib_pct_retrieve = true;
            }
            if (newindex == 4 && !ib_national_retrieve)
            {
                //tabpage_national.uo_4.dw_selection.retrieve();
                uo_4.dw_selection.Retrieve();
                ib_national_retrieve = true;
                // tabpage_national.uo_4.of_show ( tabpage_national.uo_4.cb_delete,false)
            }
        }
    }
}