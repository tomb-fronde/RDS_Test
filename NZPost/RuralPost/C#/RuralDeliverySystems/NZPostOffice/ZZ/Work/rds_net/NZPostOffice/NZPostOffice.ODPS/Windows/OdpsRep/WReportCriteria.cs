using NZPostOffice.Shared.VisualComponents;
using System;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.Shared;
using Microsoft.Win32;
using NZPostOffice.ODPS.DataControls.Odps;

namespace NZPostOffice.ODPS.Windows.OdpsRep
{
    public partial class WReportCriteria : WMaster
    {
        #region Define
        public string is_datawindow_object = String.Empty;

        public bool ib_grosspayvariance;

        public string is_report_name = String.Empty;

        public bool bnational = false;

        #endregion

        public WReportCriteria()
        {
            this.InitializeComponent();

            dw_1.DataObject = new DwReportCriteria();
            dw_1.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;

            ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("edate")).LostFocus += new EventHandler(dw_1_itemchanged);
            ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("edate")).KeyPress += new KeyPressEventHandler(WReportCriteria_KeyPress1);
            ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("sdate")).KeyPress += new KeyPressEventHandler(WReportCriteria_KeyPress);
        }

        public virtual void ue_aftershow()
        {
            if (DesignMode)
            {
                return;
            }

            string ls_saccess;
            ls_saccess = of_getaccess();
            /*?
            if (of_getaccess() == "Regional")
            {
                Metex.Windows.DataUserControl dwc;
                dwc = dw_1.GetChild("region_id");
                dwc.Retrieve();
                if (StaticFunctions.f_hqaccess())
                {
                    dw_1.Modify("region_id.TabIndex=\'1\'");
                    dwc.InsertItem<NZPostOffice.ODPS.Entity.OdpsInvoice.DddwRegions>(0);
                    dwc.SetValue(0, "region_id", 0);
                    dwc.SetValue(0, "rgn_name", "<All Regions>");
                    dw_1.SetValue(0, "region_id", 0);
                }
                else if (StaticFunctions.f_regreportaccess() && of_getaccess() == "Regional")
                {
                    dw_1.Modify("region_id.TabIndex=\'1\'");
                    dw_1.SetValue(0, "region_id", StaticFunctions.f_getregion());
                    dw_1.Modify("region_id.TabIndex=\'0\'");
                }
                else
                {
                    MessageBox.Show("Sorry, you do not have access to this report", Text);
                    this.Close();
                }
            }
            else if (StaticFunctions.f_hqaccess())
            {
                // ok
            }
            else if (StaticFunctions.f_regreportaccess() && of_getaccess() == "Regional")
            {
                // ok
            }
            else
            {
                MessageBox.Show("Sorry, you do not have access to this report", Text);
                this.Close();
            }
             */
            //  PBY 03/09/2002 SR#4449
            dw_1.of_filter_regions("ODPS Reports");

            //jlwang: for different user 
            if (dw_1.ll_row >= 0)
                dw_1.SetValue(0, "region_id", dw_1.ll_row);
            else if (dw_1.ll_row == -99)
                dw_1.SetValue(0, "region_id", -99);
        }

        public override void open()
        {
            if (DesignMode)
            {
                return;
            }

            base.open();
            string ls_saccess;
            DateTime dt_sdate = new DateTime();
            DateTime dt_edate;
            DateTime ldt_fsdate;
            DateTime ldt_fedate;
            //  store the report name passed
            // is_report_name = message.stringparm
            dt_edate = DateTime.Today;
            //  Calculate the financial year based on today's date
            if (dt_edate.Month > 3)
            {
                ldt_fsdate = System.Convert.ToDateTime(dt_edate.Year.ToString() + "/04/01");
                ldt_fedate = System.Convert.ToDateTime((dt_edate.Year + 1) + "/03/31");
            }
            else
            {
                ldt_fsdate = System.Convert.ToDateTime((dt_edate.Year - 1) + "/04/01");
                ldt_fedate = System.Convert.ToDateTime((dt_edate.Year.ToString()) + "/03/31");
            }
            //  Calculate the payperiod date based on today's date
            if (dt_edate.Day >= 20)
            {
                dt_edate = new DateTime(dt_edate.Year, dt_edate.Month, 20);
                dt_sdate = dt_edate.AddDays(-30);// StaticFunctions.RelativeDate(dt_edate, -(30));
                dt_sdate = new DateTime(dt_sdate.Year, dt_sdate.Month, 21);
            }
            else
            {
                dt_edate = dt_edate.AddDays(-20);//StaticFunctions.RelativeDate(dt_edate, -(20));
                dt_edate = System.Convert.ToDateTime(dt_edate.Year + "," + dt_edate.Month + ", 20");
                dt_sdate = dt_edate.AddDays(-30);//StaticFunctions.RelativeDate(dt_edate, -(30));
                dt_sdate = System.Convert.ToDateTime(dt_sdate.Year + "," + dt_sdate.Month + ", 21");
            }
            dw_1.InsertItem<NZPostOffice.ODPS.Entity.Odps.ReportCriteria>(0);
            dw_1.SetValue(0, "sdate", dt_sdate);
            dw_1.SetValue(0, "edate", dt_edate);
            dw_1.DataObject.BindingSource.CurrencyManager.Refresh();
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = is_report_name;
            if (TestExpr == "HistoryOfChanges")
            {
                //  Both the dates need to be enabled.
                this.Text = "History of Changes Report";
                is_datawindow_object = "dw_national_history_changes";
                ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("sdate")).ReadOnly = false;//.Enabled = true;
                //? dw_1.Modify("sdate.TabIndex=\'1\'");
                //? dw_1.(7)DataControl["sdate"].BackColor =\'" + String(RGB(255, 255, 255)) + '\'');
                dw_1.GetControlByName("sdate").Focus();
            }
            else if (TestExpr == "NegativePay")
            {
                this.Text = "Negative Pay Report";
                is_datawindow_object = "dw_negativepay";
            }
            else if (TestExpr == "GrossPayVariance")
            {
                this.Text = "Gross Pay Variance Report";
                is_datawindow_object = "dw_grosspayvariance";
                ib_grosspayvariance = true;
            }
            else if (TestExpr == "IR66N")
            {
                this.Text = "IR345 Report";
                is_datawindow_object = "dw_ir66n";
            }
            else if (TestExpr == "PostTaxAdjustments")
            {
                //  Both the dates need to be enabled.
                this.Text = "Post Tax Adjustments Summary";
                is_datawindow_object = "dw_post_tax_adjustments";
                ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("sdate")).ReadOnly = false;//.Enabled = true;
                ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("sdate")).BackColor = System.Drawing.Color.White;
                //? dw_1.Modify("sdate.TabIndex=\'1\'");
                //? dw_1.(7)DataControl["sdate"].BackColor =\'" + String(RGB(255, 255, 255)) + '\'');

                dw_1.GetControlByName("sdate").Focus();
            }
            else if (TestExpr == "PostTaxAdjustments2")
            {
                //  Both the dates need to be enabled.
                this.Text = "Post Tax Adjustments Detail";
                is_datawindow_object = "dw_post_tax_adjustments_region";
                // 		dw_1.Modify ( "sdate.TabIndex='1'")
                // 		dw_1.Modify ( "sdate.Background.Color='"+string ( rgb ( 255,255,255))+"'")
                // 		dw_1.setcolumn ( 'sdate')
                // 
                //  TJB  SR4684  June-2006
                //  Changed datawindows to include Parcel Post
            }
            else if (TestExpr == "VolumesValues")
            {
                this.Text = "Piece Rate Summary Report";
                //  is_datawindow_object = 'dw_volumes_valuev2'
                is_datawindow_object = "dw_volumes_value_summary";
            }
            else if (TestExpr == "VolumesValues2")
            {
                this.Text = "Piece Rate Detail Report";
                //  is_datawindow_object = 'dw_volumes_value_detail'
                is_datawindow_object = "dw_volumes_value_detail";
            }
            else if (TestExpr == "WithholdingTax")
            {
                this.Text = "Withholding Tax Report";
                is_datawindow_object = "dw_withholding_tax";
            }
            else if (TestExpr == "YearlyEarnings")
            {
                //  This report is based on the financial year 
                this.Text = "Yearly Earnings Report";
                is_datawindow_object = "dw_yearly_earnings";
                dw_1.SetValue(0, "sdate", ldt_fsdate);
                dw_1.SetValue(0, "edate", ldt_fedate);
                dw_1.DataObject.BindingSource.CurrencyManager.Refresh();
            }
            else if (TestExpr == "AuditRecordChanges")
            {
                this.Text = "Audit Record Changes Report";
                is_datawindow_object = "dw_audit_log";
                ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("sdate")).ReadOnly = false;//.Enabled = true;
                ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("sdate")).BackColor = System.Drawing.Color.White;
                //? dw_1.Modify("sdate.TabIndex=\'1\' edate.TabIndex=\'1\'");
                //? dw_1.(7)DataControl["sdate"].BackColor =" + String(RGB(255, 255, 255)));
                // this.Text=message.stringparm
            }
            else if (TestExpr == "ContractorAddressChanges")
            {
                this.Text = "Contractor Address Changes Report";
                is_datawindow_object = "dw_audit_log_addresschange";
                ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("sdate")).ReadOnly = false;
                ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("sdate")).BackColor = System.Drawing.Color.White;
                //? dw_1.Modify("sdate.TabIndex=\'1\' edate.TabIndex=\'1\'");
                //? dw_1.(7)DataControl["sdate"].BackColor =" + String(RGB(255, 255, 255)));
                // this.Text=message.stringparm
            }
            else if (TestExpr == "IR68A&IR68P")
            {
                //  This report is based on the financial year 
                this.Text = "IR68A and IR68P Report";
                is_datawindow_object = "dw_ir68a_ir68p";
                dw_1.SetValue(0, "sdate", ldt_fsdate);
                dw_1.SetValue(0, "edate", ldt_fedate);
                dw_1.DataObject.BindingSource.CurrencyManager.Refresh();
            }
            else if (TestExpr == "IR66ES")
            {
                this.Text = "IR66ES Report";
                is_datawindow_object = "dw_ir66es";
            }
            else if (TestExpr == "PaymentSummary")
            {
                this.Text = "Payment Summary Report";
                is_datawindow_object = "dw_payment_summary";
            }
            else if (TestExpr == "IR348")
            {
                this.Text = "IR348";
                is_datawindow_object = "dw_ir348_header";
            }
            if (!(is_report_name == "PaymentSummary"))
            {
                ls_saccess = of_getaccess();
                if (!(ls_saccess == "Regional"))
                {
                    dw_1.Height = 65;
                    //cb_ok.y = dw_1.Height + 33;
                    cb_ok.Location = new System.Drawing.Point(5, dw_1.Height + 15);

                    //cb_cancel.y = cb_ok.y;
                    cb_cancel.Top = cb_ok.Top;
                    //this.Height = cb_ok.y + cb_ok.Height + 140;
                    this.Height = cb_ok.Location.Y + cb_ok.Height + 40;
                }
            }
            //PostEvent("ue_aftershow");
            this.ue_aftershow();
        }

        public override int closequery()
        {
            return 1;
        }

        public override void pfc_preopen()
        {
            string[] ls_printerlist = new string[] { };
            string[] ls_datasourcelist = new string[] { };
            // Detect printers - NT
            //RegistryKeys("HKEY_CURRENT_USER\\Printers\\Connections", ls_printerlist);
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Printers").OpenSubKey("Connections");
            ls_printerlist = registryKey.GetSubKeyNames();

            if (ls_printerlist.GetLength(0) == 0)
            {
                // Detect printers - Win 95
                //RegistryKeys("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\control\\Print\\Printers", ls_printerlist);
                registryKey = Registry.LocalMachine.OpenSubKey("System").OpenSubKey("CurrentControlSet").OpenSubKey("control").OpenSubKey("Print").OpenSubKey("Printers");
                ls_printerlist = registryKey.GetSubKeyNames();

                if (ls_printerlist.GetLength(0) == 0)
                {
                    MessageBox.Show("No printer connections set. Reports may not be retrieved properly", "Warning");
                }
            }
            is_report_name = StaticMessage.StringParm;
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = is_report_name;
            if (TestExpr == "HistoryOfChanges")
            {
                of_setaccess("National");
            }
            else if (TestExpr == "NegativePay")
            {
                of_setaccess("National");
            }
            else if (TestExpr == "GrossPayVariance")
            {
                of_setaccess("National");
            }
            else if (TestExpr == "IR66N")
            {
                of_setaccess("National");
            }
            else if (TestExpr == "WithholdingTax")
            {
                of_setaccess("National");
            }
            else if (TestExpr == "AuditRecordChanges")
            {
                of_setaccess("National");
            }
            else if (TestExpr == "ContractorAddressChanges")
            {
                of_setaccess("National");
            }
            else if (TestExpr == "IR68A&IR68P")
            {
                of_setaccess("National");
            }
            else if (TestExpr == "IR66ES")
            {
                of_setaccess("National");
            }
            else if (TestExpr == "PostTaxAdjustments")
            {
                of_setaccess("National");
            }
            else if (TestExpr == "IR348")
            {
                of_setaccess("National");
            }
            else
            {
                of_setaccess("Regional");
            }
            //? if (StaticFunctions.f_hqaccess())
            {
                //? dw_1.Modify("region_id.protect=0");
            }
            //? else if (StaticFunctions.f_regreportaccess())
            {
                //? dw_1.Modify("region_id.protect=1");
                //? dw_1.object.region_id.background.color = RGB(192, 192, 192);
            }
            //? this.of_triggerpostconstructor(this.Control);
        }

        public virtual void itemerror()
        {
            return;// 1;
        }

        private delegate void deleInvoke();

        public void deleAfterChg()
        {
            this.ue_aftershow();
        }

        #region Events
        //jlwang:
        private void WReportCriteria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((DateTimeMaskedTextBox)this.dw_1.GetControlByName("sdate")).SelectionStart == 10)
            {
                ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("edate")).Focus();
                ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("edate")).SelectionStart = 0;
            }
        }

        //jlwang:
        private void WReportCriteria_KeyPress1(object sender, KeyPressEventArgs e)
        {
            if (((DateTimeMaskedTextBox)this.dw_1.GetControlByName("edate")).SelectionStart == 10)
            {
                this.ProcessDialogKey(Keys.Tab);
            }
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            WReport w_window = new WReport();
            DateTime dt_sdate = new DateTime();
            int? lregion_id;
            bnational = false;
            if (!dw_1.AcceptText())
            {
                return;
            }
            //lregion_id = dw_1.getitemnumber(1, "region_id");
            lregion_id = dw_1.GetItem<NZPostOffice.ODPS.Entity.Odps.ReportCriteria>(0).RegionId;
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = is_report_name;
            if (TestExpr == "HistoryOfChanges")
            {
                //  This report requires payperiod dates
                lregion_id = -(1);
            }
            else if (TestExpr == "NegativePay")
            {
                //  This report requires payperiod dates
                lregion_id = -(1);
            }
            else if (TestExpr == "GrossPayVariance")
            {
                //  This report requires current payperiod dates as well as the previous payperiod
                dw_1.SetValue(0, "fedate", dw_1.GetItem<NZPostOffice.ODPS.Entity.Odps.ReportCriteria>(0).Sdate.Value.AddDays(-1)); //StaticFunctions.RelativeDate(dw_1.GetItemDateTime(1, "sdate").Date, -(1)));
                dt_sdate = dw_1.GetItem<NZPostOffice.ODPS.Entity.Odps.ReportCriteria>(0).Fedate.Value.AddDays(-30);//StaticFunctions.RelativeDate(dw_1.GetItemDateTime(1, "fedate").Date, -(30));
                dt_sdate = System.Convert.ToDateTime(dt_sdate.Year.ToString() + "-" + dt_sdate.Month.ToString() + "-" + "21");
                dw_1.SetValue(0, "fsdate", dt_sdate);
                lregion_id = -(1);
            }
            else if (TestExpr == "IR66N")
            {
                //  This report requires payperiod dates
                lregion_id = -(1);
            }
            else if (TestExpr == "PostTaxAdjustments")
            {
                //  This report requires payperiod dates
                lregion_id = -(1);
            }
            else if (TestExpr == "PostTaxAdjustments2")
            {
                //  This report requires payperiod dates
                if (lregion_id == null)
                {
                    lregion_id = 0;
                }
            }
            else if (TestExpr == "VolumesValues")
            {
                //  This report requires payperiod dates
                if (lregion_id == null)
                {
                    lregion_id = 0;
                }
            }
            else if (TestExpr == "WithholdingTax")
            {
                //  This report requires current payperiod dates as well as the financial year dates
                //dt_sdate = dw_1.GetItemDateTime(1, "edate").Date;
                dt_sdate = System.Convert.ToDateTime(dw_1.GetItem<NZPostOffice.ODPS.Entity.Odps.ReportCriteria>(0).Edate);
                if (dt_sdate.Month > 3)
                {
                    dw_1.SetValue(0, "fsdate", System.Convert.ToDateTime(dt_sdate.Year.ToString() + "/04/01"));
                    dw_1.SetValue(0, "fedate", System.Convert.ToDateTime((dt_sdate.Year + 1) + "/03/31"));
                }
                else
                {
                    dw_1.SetValue(0, "fsdate", System.Convert.ToDateTime((dt_sdate.Year - 1) + "/04/01"));
                    dw_1.SetValue(0, "fedate", System.Convert.ToDateTime(dt_sdate.Year.ToString() + "/03/31"));
                }
                lregion_id = -(1);
            }
            else if (TestExpr == "YearlyEarnings")
            {
                //  This report requires the financial year dates
                if (lregion_id == null)
                {
                    lregion_id = 0;
                }
            }
            else if (TestExpr == "AuditRecordChanges")
            {
                //  This report requires payperiod dates
                lregion_id = -(1);
            }
            else if (TestExpr == "IR68A&IR68P")
            {
                //  This report requires the financial year dates
                lregion_id = -(1);
            }
            else if (TestExpr == "IR66ES")
            {
                //  This report requires payperiod dates
                lregion_id = -(1);
            }
            else if (TestExpr == "PaymentSummary")
            {
                //  This report requires payperiod dates
                if (lregion_id == null)
                {
                    lregion_id = 0;
                }
            }
            else if (TestExpr == "IR348")
            {
                lregion_id = -(1);
            }

            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "DatawindowObject", is_datawindow_object);
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "StartDate", string.Format("{0:yyyy-MM-dd}", dw_1.GetValue(0, "sdate")));
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "EndDate", string.Format("{0:yyyy-MM-dd}", dw_1.GetValue(0, "edate")));
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "FinStartDate", string.Format("{0:yyyy-MM-dd}", dw_1.GetValue(0, "fsdate")));
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "FinEndDate", string.Format("{0:yyyy-MM-dd}", dw_1.GetValue(0, "fedate")));
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "Title", this.Text + " ");//parent.Title + ' ');
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "National", bnational);
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_report", "Region", lregion_id);

            // if (!(StaticVariables.gnv_app.of_getframe().menuid.mf_check_window(parent.Title + ' ')))
            foreach (Form frm in StaticVariables.MainMDI.MdiChildren)
            {
                if ((frm is WReport) && (frm.Text.Trim() == this.Text.Trim()))
                {
                    frm.Activate();
                    return;
                }
            }
            Cursor.Current = Cursors.WaitCursor;
            w_window.MdiParent = StaticVariables.MainMDI;
            w_window.Show();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void dw_1_itemchanged(object sender, EventArgs e)
        {
            this.ProcessDialogKey(Keys.Tab);
            if (this.dw_1.GetColumnName() == "region_id")
            {
                //? PostEvent("ue_afterchanged");
                BeginInvoke(new deleInvoke(deleAfterChg));
                return;
            }
            DateTime ldt_sdate;
            DateTime ldt_edate;
            //  Validate the year
            if (this.dw_1.GetItem<NZPostOffice.ODPS.Entity.Odps.ReportCriteria>(0).Edate == null)
            {
                this.dw_1.GetItem<NZPostOffice.ODPS.Entity.Odps.ReportCriteria>(0).Sdate = null;
                this.dw_1.DataObject.BindingSource.CurrencyManager.Refresh();
                return;
            }

            string data = this.dw_1.GetItem<NZPostOffice.ODPS.Entity.Odps.ReportCriteria>(0).Edate.Value.ToString();
            if (System.Convert.ToDateTime(data).Year < 1990)
            {
                MessageBox.Show("Date cannot be earlier than 1990", "Owner-Driver Payment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;// 1;
            }
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = is_report_name;
            if (TestExpr == "HistoryOfChanges")
            {
                //  No Changes
            }
            else if (TestExpr == "NegativePay" || TestExpr == "GrossPayVariance" || TestExpr == "IR66N" || TestExpr == "VolumesValues" || TestExpr == "WithholdingTax" || TestExpr == "IR66ES" || TestExpr == "PaymentSummary" || TestExpr == "PostTaxAdjustments2" || TestExpr == "VolumesValues2")
            {
                //  Only One Month is allowed
                //  Calculate the payperiod based on the date entered
                ldt_sdate = System.Convert.ToDateTime(System.Convert.ToDateTime(data).Year.ToString() + '/' + System.Convert.ToDateTime(data).Month.ToString() + "/20");
                dw_1.SetValue(0, "edate", ldt_sdate);
                //? dw_1.settext(ldt_sdate).ToString();
                ldt_sdate = ldt_sdate.AddDays(-30);//StaticFunctions.RelativeDate(ldt_sdate, -(30));
                ldt_sdate = new DateTime(ldt_sdate.Year, ldt_sdate.Month, 21);
                dw_1.SetValue(0, "sdate", ldt_sdate);
                dw_1.DataObject.BindingSource.CurrencyManager.Refresh();
                return;// 2;
            }
            else if (TestExpr == "PostTaxAdjustments")
            {
                //  No Changes
            }
            else if (TestExpr == "YearlyEarnings" || TestExpr == "IR68A&IR68P")
            {
                //  Only One Year is allowed
                //  Calculate the financial year based on the date entered
                if (System.Convert.ToDateTime(data).Month > 3)
                {
                    ldt_sdate = System.Convert.ToDateTime(System.Convert.ToDateTime(data).Year.ToString() + "/04/01");
                    ldt_edate = System.Convert.ToDateTime(System.Convert.ToString(System.Convert.ToDateTime(data).Year + 1) + "/03/31");
                }
                else
                {
                    ldt_sdate = System.Convert.ToDateTime((System.Convert.ToDateTime(data).Year - 1) + "/04/01");
                    ldt_edate = System.Convert.ToDateTime(System.Convert.ToDateTime(data).Year.ToString() + "/03/31");
                }
                dw_1.SetValue(0, "sdate", ldt_sdate);
                dw_1.SetValue(0, "edate", ldt_edate);

                dw_1.DataObject.BindingSource.CurrencyManager.Refresh(); //jlwang:
                //? dw_1.settext(ldt_edate).ToString();
                return;// 2;
            }
        }
        #endregion
    }
}
