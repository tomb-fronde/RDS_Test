using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.Menus;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.Windows.Odps
{
    // TJB  RPCR_128 July-2019
    // Disabled <delete> for National tab (ue_4)
    // - appeared to work but didn't?
    //
    // TJB  RPCR_113  July 2018
    // Added event handler dw_selection_ItemChanged
    // and PbuCode_validation to validate email addresses as entered.
    //
    // TJB  RPCR_054  June-2013
    // Added code to manipulate visibility of uo_1.cb_save

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

            uo_3 = new UoPaymentComponentType();
            tabpage_pct.Controls.Add(uo_3);

            uo_3.TabIndex = 0;
            uo_3.Location = new System.Drawing.Point(0, 8);
            uo_3.Size = new System.Drawing.Size(733, 292);

            uo_4 = new UoNational();
            tabpage_national.Controls.Add(uo_4);

            uo_4.TabIndex = 0;
            uo_4.Size = new System.Drawing.Size(733, 300);
            uo_4.Location = new System.Drawing.Point(0, 8);

            m_odps_maintenance = new MOdpsMaintenance(this);

            //? m_odps_maintenance_menu.SetFunctionalPart(m_odps_maintenance);
            //? m_odps_maintenance_toolbar.SetFunctionalPart(m_odps_maintenance);

            uo_2.dw_selection.ItemChanged += new EventHandler(dw_selection_ItemChanged);
        }

        // TJB  RPCR_113  July 2018  New
        void dw_selection_ItemChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("WCodeTableMaintenance.dw_selection_itemchanged\n");
            int rc = PbuCode_validation();
            //MessageBox.Show("WCodeTableMaintenance.dw_selection_itemchanged\n"
            //               + " PbuCode_validation returned " + rc.ToString() + "\n");
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            // 	Object:			w_CodeTables
            // 	Method:			pfc_PreOpen
            // 	Description:	perform the open logic, start the window services desired
            // This.of_SetResize ( TRUE )
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
            int TestExpr = tab_folder.SelectedIndex + 1;
            if (TestExpr == 1) // Account code
            {
                //tab_folder.tabpage_account_code.uo_1.triggerevent("ue_delete");
                uo_1.ue_delete();
            }
            else if (TestExpr == 2)  // PBU code
            {
                //tab_folder.tabpage_pbu_code.uo_2.triggerevent("ue_delete");
                uo_2.ue_delete();
            }
            else if (TestExpr == 3)  //PCT
            {
                //tab_folder.tabpage_pct.uo_3.triggerevent("ue_delete");
                uo_3.ue_delete();
            }
            else if (TestExpr == 4)  // National
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

        // TJB  RPCR_113  July 2018  New
        // Validates each email address as entered 
        // (also validates during save in UoPbuCode)
        public virtual int PbuCode_validation()
        {
            int iRet = 1;
            string pbu_email_1 = "", pbu_email_2 = "", pbu_email_3 = "";
            string email_error = "";
            string sError = "";

            //this.ProcessDialogKey(Keys.Tab);
            int nRow = uo_2.dw_selection.GetRow();

            /* Debugging
                string pbu_row = " ";
                string spbu_email_1 = "", spbu_email_2 = "", spbu_email_3 = "";
                pbu_row += (uo_2.dw_selection.GetItem<PbuCode>(nRow).IsDirty) 
                             ? "is dirty"
                             : "is not dirty";

                pbu_email_1 = uo_2.dw_selection.GetItem<PbuCode>(nRow).PbuEmail1;
                pbu_email_2 = uo_2.dw_selection.GetItem<PbuCode>(nRow).PbuEmail2;
                pbu_email_3 = uo_2.dw_selection.GetItem<PbuCode>(nRow).PbuEmail3;

                spbu_email_1 = NullOrEmpty(pbu_email_1);
                spbu_email_2 = NullOrEmpty(pbu_email_2);
                spbu_email_3 = NullOrEmpty(pbu_email_3);
                
                MessageBox.Show("WCodeTableMaintenance.PbuCode_validation\n"
                                + "Row = " + nRow.ToString() + pbu_row + "\n"
                                + "pbu_email_1 = " + spbu_email_1 + "\n"
                                + "pbu_email_2 = " + spbu_email_2 + "\n"
                                + "pbu_email_3 = " + spbu_email_3 + "\n"
                                );
            */
            if (uo_2.dw_selection.GetItem<PbuCode>(nRow).IsDirty)
            {
                email_error = "";
                if (!string.IsNullOrEmpty(pbu_email_1)) // && !string.IsNullOrEmpty(pbu_email_1.Trim()))
                {
                    if (!Regex.IsMatch(pbu_email_1, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$"))
                    {
                        sError = NullOrEmpty(pbu_email_1);
                        email_error += "pbu_email_1 = " + sError + "\n";
                        //email_error += spbu_email_1 + "\n";
                    }
                }
                if (!string.IsNullOrEmpty(pbu_email_2)) // && !string.IsNullOrEmpty(pbu_email_2.Trim()))
                {
                    if (!Regex.IsMatch(pbu_email_2, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$"))
                    {
                        sError = NullOrEmpty(pbu_email_2);
                        email_error += "pbu_email_2 = " + sError + "\n";
                        //email_error += spbu_email_2 + "\n";
                    }
                }
                if (!string.IsNullOrEmpty(pbu_email_3)) // && !string.IsNullOrEmpty(pbu_email_2.Trim()))
                {
                    if (!Regex.IsMatch(pbu_email_3, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$"))
                    {
                        sError = NullOrEmpty(pbu_email_3);
                        email_error += "pbu_email_3 = " + sError + "\n";
                        //email_error += spbu_email_3 + "\n";
                    }
                }
                if (email_error != "")
                {
                    MessageBox.Show("Incorrect format for email address.\n"
                                    + "Format should be name@address with no spaces\n\n"
                                    + email_error + "\n"
                                    + "Please correct before saving."
                                    , "Validation Error"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    iRet = -1;
                }
            }
            return iRet;
        }

        // TJB  RPCR_113  July 2018  New
        string NullOrEmpty(string pTemp)
        {
            string sTemp;

            sTemp = pTemp;
            if (pTemp == null)
                sTemp = "null";
            else if (pTemp.Trim() == "")
                sTemp = "empty";

            return sTemp;
        }

        public virtual int tab_pfc_validation()
        {
            int iRet = 1;
            string pbu_email_1 = "", pbu_email_2 = "", pbu_email_3 = "";
            string email_error;

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
                    if (uo_3.dw_selection.GetItem<NZPostOffice.ODPS.Entity.OdpsRep.PaymentComponentType>(i).PctDescription == null)// || uo_2.dw_selection.GetItem<NZPostOffice.ODPS.Entity.OdpsRep.PaymentComponentType>(i).AcDescription == null)
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

        public virtual int of_retrievedw(URdsDw adwv_control)
        {
            // 	Object:			w_CodeTable
            // 	Method:			of_Retrievedw
            // 	Description:	retrieve the datawindow stuff
            // 	Arguments:		adwv_Control - datawindow of type u_dw
            // 	Returns:			0
            int ll_RowCount;
            // 	HELP:	setup the retrieval arguments (if any) for the datawindow
            ll_RowCount = adwv_control.Retrieve();
            adwv_control.Focus();
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
                uo_1.cb_save.Visible = true;
            }
            if (newindex == 2 && !ib_pbu_retrieve)
            {
                //tabpage_pbu_code.uo_2.dw_selection.retrieve();
                uo_2.dw_selection.Retrieve();
                ib_pbu_retrieve = true;
                uo_2.cb_save.Visible = true;
            }
            if (newindex == 3 && !ib_pct_retrieve)
            {
                //tabpage_pct.uo_3.dw_selection.retrieve();
                uo_3.dw_selection.Retrieve();
                ib_pct_retrieve = true;
                uo_3.cb_save.Visible = true;
            }
            if (newindex == 4 && !ib_national_retrieve)
            {
                //tabpage_national.uo_4.dw_selection.retrieve();
                uo_4.dw_selection.Retrieve();
                ib_national_retrieve = true;
                // tabpage_national.uo_4.of_show(tabpage_national.uo_4.cb_delete,false)
                uo_4.cb_save.Visible = false;
                uo_4.cb_delete.Visible = false;  // TJB  RPCR_128 July-2019: Added - appeared to, but didn't work!
            }
        }
    }
}