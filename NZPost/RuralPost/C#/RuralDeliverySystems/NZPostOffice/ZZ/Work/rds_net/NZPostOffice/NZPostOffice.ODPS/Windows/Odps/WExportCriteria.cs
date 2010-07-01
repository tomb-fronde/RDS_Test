using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.ODPS.DataControls.OdpsInvoice;
using NZPostOffice.ODPS.Entity.Odps;
using NZPostOffice.ODPS.DataControls.OdpsRep;
using NZPostOffice.ODPS.DataControls.Odps;
using NZPostOffice.ODPS.Entity.OdpsRep;
using CrystalDecisions.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using CrystalDecisions.CrystalReports.Engine;

namespace NZPostOffice.ODPS.Windows.Odps
{
    public partial class WExportCriteria : WMaster
    {
        // TJB  RPI_004  June-2010
        // Changed decimal? fields to strings in object definition (Ir348Detail)
        // Changed related variables below to non-nullable decimals.
        // Added str2dec() function above to convert the strings.
        //
        // TJB  RPI_005  June 2010
        // Changed AP Interface filename prompt and removed unnecessary check 
        // for existing filename.
        //
        // TJB  RPI_003  June 2010
        // Change filename for GL Payments and GL Accruals
        public WExportCriteria()
        {
            InitializeComponent();

            this.dw_1.DataObject = new DwReportCriteria();

            ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("edate")).LostFocus += new EventHandler(dw_1_itemchanged);
            ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("edate")).KeyPress += new KeyPressEventHandler(WReportCriteria_KeyPress1);
            ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("sdate")).KeyPress += new KeyPressEventHandler(WReportCriteria_KeyPress);
        }

        public override void open()
        {
            // base.open();
            DateTime dt_sdate;
            DateTime dt_edate;
            DateTime ldt_fsdate;
            DateTime ldt_fedate;
            ls_report_name = StaticMessage.StringParm;
            dt_edate = DateTime.Now;// Today();
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = ls_report_name;
            if (TestExpr == "GL Interface-Payments")
            {
                dw_1.Height = 68;
                this.Text = "General Ledger Interface-Payments";
                dw_primary.DataObject = new DwGlInterfaceForPayment();
                //? dw_1.Modify("sdate.TabIndex=\'0\'");
            }
            else if (TestExpr == "GL Interface-Accruals")
            {
                dw_1.Height = 68;
                this.Text = "General Ledger Interface-Accruals";
                dw_primary.DataObject = new DwGlInterfaceForAccruals();
                dw_secondary.DataObject = new DwGlAccrualsAudit();
                //? dw_1.Modify("sdate.TabIndex=\'0\'");
            }
            else if (TestExpr == "Accounts Payable Interface")
            {
                dw_1.Height = 68;
                this.Text = "Accounts Payable Interface";
                dw_primary.DataObject = new DwApInterfaceHeaderRows();
                dw_secondary.DataObject = new DwApInterfaceDetailRows();
            }
            else if (TestExpr == "Invoice Mailing")
            {
                dw_1.Height = 68;
                this.Text = "Invoice Mailing";
                dw_primary.DataObject = new DwInvoiceInterfaceHeader();
                dw_secondary.DataObject = new DwInvoiceInterfaceDetail();
            }
            else if (TestExpr == "IR13 Interface")
            {
                dw_1.Height = 69;
                this.Text = "IR13 Interface";
                dw_1.DataObject = new DwReportCriteriaFinancial();
                dw_primary.DataObject = new DwIr13InterfaceHeader();
                dw_secondary.DataObject = new DwIr13InterfaceDetail();
            }
            else if (TestExpr == "IR348 Interface")
            {
                dw_1.Height = 69;
                this.Text = "IR348 Interface";
                dw_primary.DataObject = new DwIr348Header();
                dw_secondary.DataObject = new DwIr348Detail();
                dw_tertiary.DataObject = new DwIr348DetailException();
            }
            else if (TestExpr == "Updated Contractors")
            {
                dw_1.Height = 69;
                this.Text = "Updated Contractors Export";
                dw_primary.DataObject = new DwUpdatedContractors();
                ((System.Windows.Forms.MaskedTextBox)dw_1.GetControlByName("sdate")).ReadOnly = false;
                //? dw_1.Modify("sdate.TabIndex=\'1\'");
                //dw_1.Object.sdate.Background.Color = RGB(255, 255, 255);
                dw_1.GetControlByName("sdate").BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            }
            //? dw_primary.settransobject(StaticVariables.sqlca);
            //? dw_secondary.settransobject(StaticVariables.sqlca);
            //? dw_tertiary.settransobject(StaticVariables.sqlca);

            dw_1.InsertRow(0);//dw_1.insertrow(1);

            if (dt_edate.Day >= 20)
            {
                dt_edate = System.Convert.ToDateTime(dt_edate.Year + "," + dt_edate.Month + ", 20");
                dt_sdate = dt_edate.AddDays(-30);
                dt_sdate = System.Convert.ToDateTime(dt_sdate.Year + ", " + dt_sdate.Month + ", 21");
            }
            else
            {
                dt_edate = dt_edate.AddDays(-20);
                dt_edate = System.Convert.ToDateTime(dt_edate.Year + "," + dt_edate.Month + ", 20");
                dt_sdate = dt_edate.AddDays(-30);
                dt_sdate = System.Convert.ToDateTime(dt_sdate.Year + "," + dt_sdate.Month + ", 21");
            }
            dw_1.SetValue(0, "sdate", dt_sdate);
            dw_1.SetValue(0, "edate", dt_edate);
            if (dw_1.Height == 68)
            {
                //? dw_1.Modify("fsdate.TabIndex=\'0\' fedate.TabIndex=\'0\'");
            }
            else
            {
                if (dt_edate.Month > 3)
                {
                    ldt_fsdate = System.Convert.ToDateTime(dt_edate.Year.ToString() + "/04/01");
                    ldt_fedate = System.Convert.ToDateTime((dt_edate.Year + 1) + "/03/31");
                }
                else
                {
                    ldt_fsdate = System.Convert.ToDateTime((dt_edate.Year - 1) + "/04/01");
                    ldt_fedate = System.Convert.ToDateTime(dt_edate.Year + "/03/31");
                }
                dw_1.SetValue(0, "fsdate", ldt_fsdate);
                dw_1.SetValue(0, "fedate", ldt_fedate);

            }
            cb_ok.Location = new Point(cb_ok.Left, 8 + dw_1.Height);
            cb_cancel.Location = new Point(cb_cancel.Left, cb_ok.Top);
            this.Height = cb_ok.Top + cb_ok.Height + 35;
        }

        public override int closequery()
        {
            return 0;
        }

        public override void pfc_preopen()
        {
            //? this.of_triggerpostconstructor(this.Control);
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            // if this.title = 'Updated Contractors Export' then 
            // 	dw_1.Object.fsdate.TabIndex=1
            //    dw_1.Object.fsdate.Background.Color=rgb ( 255,255,255)
            // 	return
            // end if
            // 
            DateTime dstart;
            DateTime dEnd;
            string sStartMonth;
            string sStartYear;

            if (DateTime.Now.Month == 1)
            {
                sStartMonth = "12";
                sStartYear = Convert.ToString(DateTime.Now.Year - 1);
            }
            else
            {
                sStartMonth = Convert.ToString(DateTime.Now.Month - 1);
                sStartYear = DateTime.Now.Year.ToString();
            }
            dstart = System.Convert.ToDateTime(sStartYear + "/" + sStartMonth + "/21");
            dEnd = System.Convert.ToDateTime(DateTime.Now.Year + "/" + DateTime.Now.Month + "/20");
            dw_1.SetValue(0, "sdate", dstart);
            dw_1.SetValue(0, "edate", dEnd);

            dw_1.DataObject.BindingSource.CurrencyManager.Refresh(); //added by jlwang
        }

        #region Methods
        public virtual void ue_afterchanged()
        {
            DateTime dstart;
            DateTime? dEnd;
            DateTime ldt_sdate;
            DateTime ldt_edate;
            if (ls_report_name == "Updated Contractors" || ls_report_name == "IR13 Interface")
            {
                // 
            }
            else
            {
                dEnd = dw_1.GetValue<DateTime?>(0, "edate");
                if (dEnd.HasValue)
                {
                    //dstart = System.Convert.ToDateTime(String(Year(StaticMethods.RelativeDate(dEnd, -(28)))) + '/' + String(Month(StaticMethods.RelativeDate(dEnd, -(28)))) + "/21");
                    dstart = Convert.ToDateTime(dEnd.Value.AddDays(-28).Year + "/" + dEnd.Value.AddDays(-28).Month + "/21");

                    dw_1.SetValue(0, "sdate", dstart);
                }
                dw_1.DataObject.BindingSource.CurrencyManager.Refresh();
            }
            // 		dEnd = dw_1.GetItemDateTime( 1,"fedate").Date
            // 		if month ( date ( dEnd)) > 3 then
            // 			ldt_sdate = date ( string ( year ( date ( dEnd)))+'/04/01')
            // 			ldt_edate = date ( string ( year ( date ( dEnd))+1)+'/03/31')
            // 		else
            // 			ldt_sdate = date ( string ( year ( date ( dEnd))-1)+'/04/01')
            // 			ldt_edate = date ( string ( year ( date ( dEnd)))+'/03/31')
            // 		end if
            // 
            // 		dw_1.setitem ( 1,'fsdate',ldt_sdate)
            // 		dw_1.setitem ( 1,'fedate',ldt_edate)
        }

        private delegate void delegateInvoke();

        public virtual void CallUeAfterchanged()
        {
            ue_afterchanged();
        }

        private bool GetFileSaveName(string title, string initFileName, ref string sReturnedFIleName, string ext, string filter)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = title;// "Save to File";
            dialog.Filter = filter;// "Text files (*.TXT)|*.TXT";
            if (ext != "")
            {
                dialog.AddExtension = true;
                dialog.DefaultExt = ext;// smonth_prefix + dt_edate.Year.ToString("yy");//TextUtil.Right(Year(dt_edate).ToString(), 2);
            }
            dialog.FileName = initFileName;// sInitFileName;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sReturnedFIleName = dialog.FileName;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string interfacealphaprefix(DateTime indate)
        {
            string smonth_prefix;
            switch (indate.Month)
            {
                case 1:
                    smonth_prefix = "a";
                    break;
                case 2:
                    smonth_prefix = "b";
                    break;
                case 3:
                    smonth_prefix = "c";
                    break;
                case 4:
                    smonth_prefix = "d";
                    break;
                case 5:
                    smonth_prefix = "e";
                    break;
                case 6:
                    smonth_prefix = "f";
                    break;
                case 7:
                    smonth_prefix = "g";
                    break;
                case 8:
                    smonth_prefix = "h";
                    break;
                case 9:
                    smonth_prefix = "i";
                    break;
                case 10:
                    smonth_prefix = "j";
                    break;
                case 11:
                    smonth_prefix = "k";
                    break;
                default:
                    smonth_prefix = "l";
                    break;
            }
            return smonth_prefix;
        }

        public string of_translate(string astring, string aoldchars, string anewchars)
        {
            return astring.Replace(aoldchars, anewchars);
        }

        #endregion

        #region Events
        private void WReportCriteria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((DateTimeMaskedTextBox)this.dw_1.GetControlByName("sdate")).SelectionStart == 10)
            {
                ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("edate")).Focus();
                ((DateTimeMaskedTextBox)this.dw_1.GetControlByName("edate")).SelectionStart = 0;
            }
        }

        private void WReportCriteria_KeyPress1(object sender, KeyPressEventArgs e)
        {
            if (((DateTimeMaskedTextBox)this.dw_1.GetControlByName("edate")).SelectionStart == 10)
            {
                this.ProcessDialogKey(Keys.Tab);
            }
        }

        // TJB  RPI_004  June-2010: Added
        private decimal str2dec(string val)
        {
            decimal n = 0;
            if (!decimal.TryParse(val, out n))
                n = 0;
            return n;
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            //? base.clicked();
            //  PBY 06-08-2002 SR#4442  Changed the file default name from rd_APInt.x?? to ap_rurl1_ddmmyyyy.txt"
            Cursor.Current = Cursors.WaitCursor;

            ue_afterchanged(); //dw_1.triggerevent("ue_afterchanged");
            int ll_Ctr;
            int ll_Ret = 0;
            DateTime dt_sdate;
            DateTime dt_edate;
            string smonth_prefix = "";
            string sReturnedFIleName = "";
            string sInitFileName;
            dw_1.AcceptText();
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            String TestExpr = this.Text;//parent.Title;
            if (TestExpr == "Updated Contractors Export")
            {
                dt_edate = dw_1.GetValue<DateTime>(0, "edate");
                dt_sdate = dw_1.GetValue<DateTime>(0, "sdate");
                ll_Ret = ((DwUpdatedContractors)dw_primary.DataObject).Retrieve(dt_sdate, dt_edate);

                sInitFileName = "UpdContractors" + dt_edate.Month.ToString() + dt_edate.Year.ToString();
                if (GetFileSaveName("Save to File", sInitFileName, ref sReturnedFIleName
                        , smonth_prefix + dt_edate.Year.ToString().Substring(2, 2)
                        , "Text files (*.TXT)|*.TXT"))
                {
                    if (System.IO.File.Exists(sReturnedFIleName))
                    {
                        DialogResult reasult = MessageBox.Show("Do you want to replace the existing file " + sReturnedFIleName + "?", "Save to File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (reasult == DialogResult.Yes)
                        {
                            dw_primary.SaveAs(sReturnedFIleName, "text");
                        }
                    }
                    else
                    {
                        dw_primary.SaveAs(sReturnedFIleName, "text");
                    }
                    dw_primary.SaveAs(sReturnedFIleName, "text");
                }
            }
            else if (TestExpr == "General Ledger Interface-Payments")
            {
                dt_edate = dw_1.GetValue<DateTime>(0, "edate");

                ((DwGlInterfaceForPayment)dw_primary.DataObject).Retrieve(dt_edate);
                for (ll_Ctr = 0; ll_Ctr < dw_primary.RowCount; ll_Ctr++)
                {
                    dw_primary.SetValue(ll_Ctr, "journal_line_number_5", ll_Ctr + 1);
                }
                // TJB  RPI_003 June-2010: Changed base filename to current standard
                //sInitFileName = "rd_glint." + interfacealphaprefix(dt_edate) + dt_edate.Year.ToString().Substring(2, 2);//TextUtil.Right(Year(dt_edate).ToString(), 2);
                DateTime dt_today = DateTime.Today;
                sInitFileName = "gl_rdpa1_" + dt_today.ToString("ddMMyyyy");

                if (GetFileSaveName("Save to File", sInitFileName, ref sReturnedFIleName
                                   , smonth_prefix + dt_edate.Year.ToString().Substring(2, 2)
                                   , "Text Files (*.TXT)|*.TXT"))
                {
                    //    if (FileExists(sReturnedFIleName)) 
                    //    {
                    //        if (MessageBox("Save to File", "Do you want to replace the existing file " + sReturnedFIleName + '?', question!, yesno!, 2) == 1) {
                    //            dw_primary.saveas(sReturnedFIleName, text!, true);
                    //        }
                    //    }
                    //    else {
                    //        dw_primary.saveas(sReturnedFIleName, text!, true);
                    //    }
                    dw_primary.SaveAs(sReturnedFIleName, "text");
                }
            }
            else if (TestExpr == "General Ledger Interface-Accruals")
            {
                int iNoTransD = 0;
                int iNoTransC = 0;
                string sfname;

                dt_edate = dw_1.GetValue<DateTime>(0, "edate");
                ((DwGlInterfaceForAccruals)dw_primary.DataObject).Retrieve(dt_edate);

                // count no. of trans
                for (ll_Ctr = 0; ll_Ctr < dw_primary.RowCount; ll_Ctr++)
                {
                    if (dw_primary.GetValue(ll_Ctr, "primary_dr_cr_code_11").ToString() == "C")
                        iNoTransC++;
                    else
                        iNoTransD++;

                    dw_primary.SetValue(ll_Ctr, "journal_line_number_5", ll_Ctr + 1);
                }

                // Save the file and grab the filename
                // TJB  RPI_003 June-2010: Changed base filename to current standard
                //sInitFileName = "rd_gaint." + interfacealphaprefix(dt_edate) + dt_edate.Year.ToString().Substring(2, 2);//TextUtil.Right(Year(dt_edate).ToString(), 2);
                DateTime dt_today = DateTime.Today;
                sInitFileName = "gl_rdpc1_" + dt_today.ToString("ddMMyyyy");
                if (GetFileSaveName("Save to File", sInitFileName, ref sReturnedFIleName
                                   , smonth_prefix + dt_edate.Year.ToString().Substring(2, 2)
                                   , "Text Files (*.TXT)|*.TXT"))
                {
                    //if (FileExists(sReturnedFIleName)) 
                    //{
                    //    if (MessageBox("Save to File", "Do you want to replace the existing file " + sReturnedFIleName + '?', question!, yesno!, 2) == 1)
                    //        dw_primary.saveas(sReturnedFIleName, text!, true);
                    //}
                    //else 
                    //    dw_primary.saveas(sReturnedFIleName, text!, true);
                    //
                    dw_primary.SaveAs(sReturnedFIleName, "text");
                }
                if (MessageBox.Show("Do you want to print the General Ledger Accruals Audit report?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)// question!, yesno!, 1) == 1)
                {
                    ((DwGlAccrualsAudit)dw_secondary.DataObject).Retrieve(dt_edate);
                    //?dw_secondary.SetValue(0, "trans1", iNoTransD);
                    //?dw_secondary.SetValue(0, "trans2", iNoTransC);
                    sfname = "file_name.Text=\'" + sInitFileName + '\'';
                    //?dw_secondary.Modify(sfname);
                    //?dw_secondary.Print();
                    TextObject obj = ((DwGlAccrualsAudit)dw_secondary.DataObject).ReportDocument.ReportDefinition.ReportObjects["Text3"] as TextObject;
                    TextObject t1 = ((DwGlAccrualsAudit)dw_secondary.DataObject).ReportDocument.ReportDefinition.ReportObjects["T1"] as TextObject;
                    TextObject t2 = ((DwGlAccrualsAudit)dw_secondary.DataObject).ReportDocument.ReportDefinition.ReportObjects["T2"] as TextObject;
                    if (obj != null)
                    {
                        obj.Text = sReturnedFIleName;
                    }
                    if (t1 != null)
                    {
                        t1.Text = iNoTransD.ToString();
                    }
                    if (t2 != null)
                    {
                        t2.Text = iNoTransC.ToString();
                    }
                    CrystalReportViewer viewer = (CrystalReportViewer)dw_secondary.DataObject.GetControlByName("viewer");
                    if (viewer != null)
                    {
                        viewer.RefreshReport();
                        viewer.PrintReport();
                    }
                }
            }
            else if (TestExpr == "IR13 Interface")
            {
                dt_sdate = dw_1.GetValue<DateTime>(0, "fsdate");
                dt_edate = dw_1.GetValue<DateTime>(0, "fedate");
                ((DwIr13InterfaceHeader)dw_primary.DataObject).Retrieve(dt_edate);
                ((DwIr13InterfaceDetail)dw_secondary.DataObject).Retrieve(dt_sdate, dt_edate);
                sInitFileName = "rd_IR13h." + interfacealphaprefix(dt_edate) + dt_edate.Year.ToString().Substring(2, 2);//TextUtil.Right(Year(dt_edate).ToString(), 2);
                if (GetFileSaveName("Save Header to File", sInitFileName, ref sReturnedFIleName
                                   , smonth_prefix + dt_sdate.Year.ToString().Substring(2, 2)
                                   , "Text Files (*.TXT)|*.TXT|CSV Files (*.CSV)|*.CSV"))
                {
                    //if (FileExists(sReturnedFIleName))
                    //{
                    //    if (MessageBox("Save to File", "Do you want to replace the existing file " + sReturnedFIleName + '?', question!, yesno!, 2) == 1)
                    //    {
                    //        dw_primary.saveas(sReturnedFIleName, text!, true);
                    //    }
                    //}
                    //else {
                    //    dw_primary.saveas(sReturnedFIleName, text!, true);
                    //}
                    dw_primary.SaveAs(sReturnedFIleName, "text");

                    sInitFileName = "rd_IR13d." + interfacealphaprefix(dt_edate) + dt_edate.Year.ToString().Substring(2, 2);//TextUtil.Right(Year(dt_edate).ToString(), 2);
                    if (GetFileSaveName("Save Detail to File", sInitFileName, ref sReturnedFIleName
                                       , smonth_prefix + dt_sdate.Year.ToString().Substring(2, 2)
                                       , "Text Files (*.TXT)|*.TXT| CSV Files (*.CSV)|*.CSV"))
                    {
                        //if (FileExists(sReturnedFIleName)) {
                        //    if (MessageBox("Save to File", "Do you want to replace the existing file " + sReturnedFIleName + '?', question!, yesno!, 2) == 1) {
                        //        dw_secondary.saveas(sReturnedFIleName, text!, true);
                        //    }
                        //}
                        //else {
                        //    dw_secondary.saveas(sReturnedFIleName, text!, true);
                        //}
                        dw_secondary.SaveAs(sReturnedFIleName, "text");
                    }
                }
            }
            else if (TestExpr == "Invoice Mailing")
            {
                dt_sdate = dw_1.GetValue<DateTime>(0, "sdate");
                dt_edate = dw_1.GetValue<DateTime>(0, "edate");
                ((DwInvoiceInterfaceHeader)dw_primary.DataObject).Retrieve(dt_sdate);
                ((DwInvoiceInterfaceDetail)dw_secondary.DataObject).Retrieve(dt_sdate, dt_edate);
                sInitFileName = "rd_Invh." + interfacealphaprefix(dt_edate) + dt_edate.Year.ToString().Substring(2, 2);//TextUtil.Right(Year(dt_edate).ToString(), 2);
                if (GetFileSaveName("Save Header to File", sInitFileName, ref sReturnedFIleName
                                   , smonth_prefix + dt_edate.Year.ToString().Substring(2, 2)
                                   , "Text Files (*.TXT)|*.TXT| CSV Files (*.CSV)| *.CSV"))
                {
                    //if (FileExists(sReturnedFIleName)) {
                    //    if (MessageBox("Save to File", "Do you want to replace the existing file " + sReturnedFIleName + '?', question!, yesno!, 2) == 1) {
                    //        dw_primary.saveas(sReturnedFIleName, text!, true);
                    //    }
                    //}
                    //else {
                    //    dw_primary.saveas(sReturnedFIleName, text!, true);
                    //}
                    dw_primary.SaveAs(sReturnedFIleName, "text");
                    sInitFileName = "rd_Invd." + interfacealphaprefix(dt_edate) + dt_edate.Year.ToString().Substring(2, 2);//TextUtil.Right(Year(dt_edate).ToString(), 2);
                    if (GetFileSaveName("Save Detail to File", sInitFileName, ref sReturnedFIleName
                                       , smonth_prefix + dt_edate.Year.ToString().Substring(2, 2)
                                       , "Text Files (*.TXT)|*.TXT| CSV Files (*.CSV)|*.CSV"))
                    {
                        //if (FileExists(sReturnedFIleName)) {
                        //    if (MessageBox("Save to File", "Do you want to replace the existing file " + sReturnedFIleName + '?', question!, yesno!, 2) == 1) {
                        //        dw_secondary.saveas(sReturnedFIleName, text!, true);
                        //    }
                        //}
                        //else {
                        //    dw_secondary.saveas(sReturnedFIleName, text!, true);
                        //}
                        dw_secondary.SaveAs(sReturnedFIleName, "text");
                    }
                }
            }
            else if (TestExpr == "Accounts Payable Interface")
            {
                dt_edate = dw_1.GetValue<DateTime>(0, "edate");
                dt_sdate = dw_1.GetValue<DateTime>(0, "sdate");
                ((DwApInterfaceHeaderRows)dw_primary.DataObject).Retrieve(dt_edate);
                ((DwApInterfaceDetailRows)dw_secondary.DataObject).Retrieve(dt_edate);
                // move rows here
                int imoveres;
                //? imoveres = dw_secondary.rowscopy(1, dw_secondary.RowCount, primary!, dw_primary, 1, primary!);
                for (int i = 0; i < dw_secondary.RowCount; i++)
                {
                    dw_primary.InsertItem<ApInterfaceHeaderRows>(0);
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).TransactionId1 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).TransactionId1;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Vendor2 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Vendor2;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).VendorLocation3 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).VendorLocation3;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).InvoiceNo4 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).InvoiceNo4;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).InvoiceDate5 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).InvoiceDate5;

                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).PaymentNumber6 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).PaymentNumber6;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column7 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column7;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column8 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column8;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column9 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column9;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column10 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column10;

                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column11 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column11;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column12 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column12;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column13 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column13;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column14 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column14;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column15 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column15;

                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column16 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column16;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column17 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column17;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column18 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column18;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column19 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column19;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column20 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column20;

                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column21 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column21;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column22 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column22;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column23 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column23;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column24 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column24;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column25 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column25;

                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column26 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column26;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column27 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column27;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column28 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column28;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column29 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column29;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column30 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column30;

                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column31 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column31;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column32 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column32;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column33 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column33;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column34 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column34;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column35 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column35;

                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column36 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column36;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column37 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column37;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column38 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column38;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column39 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column39;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column40 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column40;

                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column41 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column41;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column42 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column42;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column43 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column43;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column44 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column44;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column45 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column45;

                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column46 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column46;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column47 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column47;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column48 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column48;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column49 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column49;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column50 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column50;

                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column51 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column51;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column52 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column52;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column53 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column53;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column54 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column54;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column55 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column55;

                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column56 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column56;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column57 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column57;
                    dw_primary.GetItem<ApInterfaceHeaderRows>(0).Column58 = dw_secondary.GetItem<ApInterfaceDetailRows>(i).Column58;
                }
                //? imoveres = dw_primary.SortString = "invoice_no_4,column_58,column_7";
                dw_primary.DataObject.SortString = "invoice_no_4,column_58,column_7";
                //? dw_primary.sort();
                dw_primary.DataObject.Sort<ApInterfaceHeaderRows>();

                // save
                //  PBY 06/08/2002 SR#4442
                //sInitFileName="rd_APInt."+InterfaceAlphaPrefix ( dt_edate)+right ( string ( year ( dt_edate)),2)
                sInitFileName = "ap_rurl1_" + dt_edate.ToString("ddMMyyyy");
                // TJB  RPI_005  Jne 2010
                // Changed prompt string
                //if (GetFileSaveName("Save Header to File", sInitFileName, ref sReturnedFIleName, smonth_prefix + dt_sdate.Year.ToString().Substring(2, 2), "Text Files (*.TXT)|*.TXT|CSV Files (*.CSV)|*.CSV"))

                if (GetFileSaveName("Save to File", sInitFileName, ref sReturnedFIleName
                                    , smonth_prefix + dt_sdate.Year.ToString().Substring(2, 2)
                                    , "Text Files (*.TXT)|*.TXT|CSV Files (*.CSV)|*.CSV"))
                {
                    // TJB  RPI_005  Jne 2010
                    // This is not needed:  the GetFileSaveName checks for overwrite
                    // (and the save was being done twice - once within the IF blocks and at the end??)
                    //if (System.IO.File.Exists(sReturnedFIleName))
                    //{
                    //    DialogResult reasult = MessageBox.Show("Do you want to replace the existing file " + sReturnedFIleName + "?", "Save to File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //    if (reasult == DialogResult.Yes)
                    //    {
                    //        dw_primary.SaveAs(sReturnedFIleName, "text", false);
                    //    }
                    //}
                    //else
                    //{
                    //    dw_primary.SaveAs(sReturnedFIleName, "text", false);
                    //}
                    dw_primary.SaveAs(sReturnedFIleName, "text", false);
                }
            }
            else if (TestExpr == "IR348 Interface")
            {
                // long  ll_Ret
                // long  ll_Ctr
                string ls_Gross = string.Empty;
                string ls_NotLiable = string.Empty;
                string ls_FamilyAssistance = string.Empty;
                string ls_StudentLoan = string.Empty;
                string ls_ChildSupport = string.Empty;
                string ls_PAYE = string.Empty;
                string ls_Name = string.Empty;
                string ls_CleanName = string.Empty;

                // TJB  RPI_004  June-2010
                // Changed these fields to strings in object definition (Ir348Detail)
                // from decimal? so changed these to non-nullable decimals.
                // Added str2dec() function above to convert the strings.
                decimal i_Gross = 0;
                decimal i_NotLiable = 0;
                decimal i_FamilyAssistance = 0;
                decimal i_StudentLoan = 0;
                decimal i_ChildSupport = 0;
                decimal i_PAYE = 0;

                dt_sdate = dw_1.GetValue<DateTime>(0, "sdate");
                dt_edate = dw_1.GetValue<DateTime>(0, "edate");
                ((DwIr348Header)dw_primary.DataObject).Retrieve(dt_sdate, dt_edate);
                ((DwIr348Detail)dw_secondary.DataObject).Retrieve(dt_sdate, dt_edate);
                ((DwIr348DetailException)dw_tertiary.DataObject).Retrieve(dt_sdate, dt_edate);
                // Strip all special characters from the names of the contractors
                // Easy! If you know what to do

                for (ll_Ctr = 0; ll_Ctr < dw_secondary.RowCount; ll_Ctr++)
                {
                    ls_Name = dw_secondary.GetValue<string>(ll_Ctr, "employee_full_name");
                    ls_CleanName = of_translate(ls_Name, "&", "");
                    ls_CleanName = of_translate(ls_CleanName, "-", "");
                    ls_CleanName = of_translate(ls_CleanName, "/", "");
                    ls_CleanName = of_translate(ls_CleanName, "(", "");
                    ls_CleanName = of_translate(ls_CleanName, ")", "");
                    ls_CleanName = of_translate(ls_CleanName, "\"", "");
                    ls_CleanName = of_translate(ls_CleanName, "\"", "");
                    dw_secondary.SetValue(ll_Ctr, "employee_full_name", ls_CleanName);

                    //i_Gross += dw_secondary.GetItem<Ir348Detail>(ll_Ctr).GrossEarnings;
                    //i_NotLiable += dw_secondary.GetItem<Ir348Detail>(ll_Ctr).NotLiable;
                    //i_FamilyAssistance += dw_secondary.GetItem<Ir348Detail>(ll_Ctr).FamilyAssistance;
                    //i_StudentLoan += dw_secondary.GetItem<Ir348Detail>(ll_Ctr).SlDeductions;
                    //i_ChildSupport += dw_secondary.GetItem<Ir348Detail>(ll_Ctr).CsDeductions;
                    //i_PAYE += dw_secondary.GetItem<Ir348Detail>(ll_Ctr).TotalPaye;

                    // TJB  RPI_004  June-2010
                    i_Gross += str2dec(dw_secondary.GetItem<Ir348Detail>(ll_Ctr).GrossEarnings);
                    i_NotLiable += str2dec(dw_secondary.GetItem<Ir348Detail>(ll_Ctr).NotLiable);
                    i_FamilyAssistance += str2dec(dw_secondary.GetItem<Ir348Detail>(ll_Ctr).FamilyAssistance);
                    i_StudentLoan += str2dec(dw_secondary.GetItem<Ir348Detail>(ll_Ctr).SlDeductions);
                    i_ChildSupport += str2dec(dw_secondary.GetItem<Ir348Detail>(ll_Ctr).CsDeductions);
                    i_PAYE += str2dec(dw_secondary.GetItem<Ir348Detail>(ll_Ctr).TotalPaye);
                }
                ls_Gross = i_Gross == null ? "0" : i_Gross.ToString();                                 //? ls_Gross = dw_secondary.describe("Evaluate ( \'Sum ( gross_earnings for all)\',1)");
                ls_NotLiable = i_NotLiable == null ? "0" : i_NotLiable.ToString();                      //? ls_NotLiable = dw_secondary.describe("Evaluate ( \'Sum ( not_liable for all)\',1)");
                ls_FamilyAssistance = i_FamilyAssistance == null ? "0" : i_FamilyAssistance.ToString(); //? ls_FamilyAssistance = dw_secondary.describe("Evaluate ( \'Sum ( family_assistance for all)\',1)");
                ls_StudentLoan = i_StudentLoan == null ? "0" : i_StudentLoan.ToString();                //? ls_StudentLoan = dw_secondary.describe("Evaluate ( \'Sum ( sl_deductions for all)\',1)");
                ls_ChildSupport = i_ChildSupport == null ? "0" : i_ChildSupport.ToString();            //? ls_ChildSupport = dw_secondary.describe("Evaluate ( \'Sum ( cs_deductions for all)\',1)");
                ls_PAYE = i_PAYE == null ? "0" : i_PAYE.ToString();                                    //? ls_PAYE = dw_secondary.describe("Evaluate ( \'Sum ( total_paye for all)\',1)");

                if (ls_Gross == "!" || ls_NotLiable == "!" || ls_FamilyAssistance == "!" || ls_StudentLoan == "!" || ls_ChildSupport == "!" || ls_PAYE == "!")
                {
                    MessageBox.Show("Error processing detail record", "IR348", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (ls_Gross != "" && StaticFunctions.IsNumber(ls_Gross))
                {
                    dw_primary.SetValue(0, "gross", ls_Gross);
                }
                if (ll_Ret == -1)
                {
                    MessageBox.Show("Error processing header record", "IR348", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (ls_NotLiable != "" && StaticFunctions.IsNumber(ls_NotLiable))
                {
                    dw_primary.SetValue(0, "not_liable", ls_NotLiable);
                }
                if (ll_Ret == -1)
                {
                    MessageBox.Show("Error processing header record", "IR348", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (ls_FamilyAssistance != "" && StaticFunctions.IsNumber(ls_FamilyAssistance))
                {
                    dw_primary.SetValue(0, "family_assistance", ls_FamilyAssistance);
                }
                if (ll_Ret == -1)
                {
                    MessageBox.Show("Error processing header record", "IR348", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (ls_StudentLoan != "" && StaticFunctions.IsNumber(ls_StudentLoan))
                {
                    dw_primary.SetValue(0, "student_loan", ls_StudentLoan);
                }
                if (ll_Ret == -1)
                {
                    MessageBox.Show("Error processing header record", "IR348", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (ls_ChildSupport != "" && StaticFunctions.IsNumber(ls_ChildSupport))
                {
                    dw_primary.SetValue(0, "child_support", ls_ChildSupport);
                }
                if (ll_Ret == -1)
                {
                    MessageBox.Show("Error processing header record", "IR348", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (ls_PAYE != "" && StaticFunctions.IsNumber(ls_PAYE))
                {
                    dw_primary.SetValue(0, "total_paye", ls_PAYE);
                }
                if (ll_Ret == -1)
                {
                    MessageBox.Show("Error processing header record", "IR348", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                sInitFileName = "IR348header_" + dt_edate.Month + dt_edate.Year.ToString().Substring(2, 2) + ".csv";
                if (GetFileSaveName("Save Header to File", sInitFileName, ref sReturnedFIleName, smonth_prefix + dt_sdate.Year, "CSV Files  ( *.CSV)|*.CSV|All Files  ( *.*)|*.*"))
                {
                    //if (FileExists(sReturnedFIleName)) {
                    //    if (MessageBox("Save to File", "Do you want to replace the existing file " + sReturnedFIleName + '?', question!, yesno!, 2) == 1) {
                    //        dw_primary.saveas(sReturnedFIleName, csv!, true);
                    //    }
                    //}
                    //else {
                    //    dw_primary.saveas(sReturnedFIleName, csv!, true);
                    //}
                    dw_primary.SaveAs(sReturnedFIleName, "csv");//!, true);

                    sInitFileName = "IR348detail_" + dt_edate.Month + dt_edate.Year.ToString().Substring(2, 2) + ".csv";
                    if (GetFileSaveName("Save Detail to File", sInitFileName, ref sReturnedFIleName, smonth_prefix + dt_sdate.Year.ToString().Substring(2, 2), "CSV Files  ( *.CSV)|*.CSV|All Files  ( *.*)| *.*"))
                    {
                        //if (FileExists(sReturnedFIleName))
                        //{
                        //    if (MessageBox("Save to File", "Do you want to replace the existing file " + sReturnedFIleName + '?', question!, yesno!, 2) == 1)
                        //    {
                        dw_secondary.SaveAs(sReturnedFIleName, "csv");//!, true);

                        sInitFileName = "IR348detail_exception" + dt_edate.Month + dt_edate.Year.ToString().Substring(2, 2) + ".csv";
                        if (GetFileSaveName("Save detail exception to File", sInitFileName, ref sReturnedFIleName, smonth_prefix + dt_sdate.Year.ToString().Substring(2, 2), "CSV Files  ( *.CSV)|*.CSV| All Files  ( *.*)|*.*"))
                        {
                            //if (FileExists(sReturnedFIleName)) 
                            //{
                            //    if (MessageBox("Save to File", "Do you want to replace the existing file " + sReturnedFIleName + '?', question!, yesno!, 2) == 1) 
                            //    {
                            //        dw_tertiary.saveas(sReturnedFIleName, csv!, true);
                            //    }
                            //}
                            //else
                            //{
                            //    dw_tertiary.saveas(sReturnedFIleName, csv!, true);
                            //}
                            dw_tertiary.SaveAs(sReturnedFIleName, "csv");

                        }
                        MessageBox.Show("Please combine the header and detail records into one file.\n" +
                                        "1) Copy the second line of the header file into the clipboard\n" +
                                        "2) Paste it into the first line (replace) of the detail file\n" +
                                        "3) Save the file using another filename then send it to IRFile\n" +
                                        "4) Do not forget to archive all files"
                                        , "IR348"
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    }
                        //}
                        //else 
                        //{
                        //    dw_secondary.saveas(sReturnedFIleName, csv!, true);
                        //    sInitFileName = "IR348detail_exception" + Month(dt_edate).ToString() +  TextUtil.Right(Year(dt_edate).ToString(), 2) + ".csv";
                        //    if (GetFileSaveName("Save detail exception to File", sInitFileName, sReturnedFIleName, smonth_prefix +  TextUtil.Right(Year(dt_sdate).ToString(), 2), "CSV Files  ( *.CSV),*.CSV," + " All Files  ( *.*), *.*") == 1) 
                        //    {
                        //        if (FileExists(sReturnedFIleName)) 
                        //        {
                        //            if (MessageBox("Save to File", "Do you want to replace the existing file " + sReturnedFIleName + '?', question!, yesno!, 2) == 1)
                        //            {
                        //                dw_tertiary.saveas(sReturnedFIleName, csv!, true);
                        //            }
                        //        }
                        //        else 
                        //        {
                        //            dw_tertiary.saveas(sReturnedFIleName, csv!, true);
                        //        }
                        //    }
                        //    MessageBox.Show ( @"Please combine the header and detail records into one file.\r~n1) Copy the second line of the header file into the clipboard\r~n2) Paste it into the first line  ( replace) of the detail file\r~n3) Save the file using another filename then send it to IRFile\r~n4) Do not forget to archive all files", "IR348" );
                        //}
                    }
                }
            }
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void dw_1_itemchanged(object sender, EventArgs e)
        {
            ue_afterchanged();
            BeginInvoke(new delegateInvoke(CallUeAfterchanged));//dw_1.PostEvent("ue_afterchanged");
        }

        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            int imoveres;
            //?imoveres = dw_secondary.rowscopy(1, dw_secondary.RowCount, primary!, dw_primary, 1, primary!);
            //?dw_primary.SortString = "invoice_no_4,column_7 d";
            //?dw_primary.Sort();
        }

        #endregion
    }
}