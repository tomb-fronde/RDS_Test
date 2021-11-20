using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.DataService;
using NZPostOffice.ODPS.Entity.OdpsLib;
using NZPostOffice.ODPS.DataControls.OdpsLib;
using System.IO;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    // TJB  RPCR_094  Mar-2015
    // Changed 'Telecom deduction' to 'Mobile phone deduction'
    //     (see ODPSDataServices.InsertTelecomPostTaxDeductions())
    // Added parameter 2 to SelectPostTaxDeductions2 and SelectPostTaxDeductions
    // Changed InsertPostTaxDeductions to InsertTelecomPostTaxDeductions

    public partial class WTelecomImport : WMaster
    {
        public string is_docname = String.Empty;
        public bool ib_loaded = false;
        public int ii_errcount;
        public int il_supplier;
        public int il_contract;

        public WTelecomImport()
        {
            InitializeComponent();

            this.dw_import.DataObject = new DTelecomImport();
            dw_import.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        public override void close()
        {
            base.close();
        }

        public override int closequery()
        {
            return base.closequery();
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            //  TJB  SR4674  July 2004
            //  Disable the Import button until a file has been read
            cb_import.Enabled = false;
        }

        public virtual int uf_importfile(string as_infile, int ai_start)
        {
            //  TJB  Feb 2005  SR4648
            //  Function reads in the rows of the Telecom data
            //  to the dw_import datawindow.  The file is in CVS format 
            //  (so the builtin importfile function can't be used).
            //  The field interpretation and datawindow-updating 
            //  are specific to this file/datawindow.
            int li_rowcount;
            int li_row;
            int li_rc;
            int ll_len;
            int i;
            int j;
            int k;
            int li_infile;
            string ls_line;
            string ls_item;
            //StringArray ls_field = new StringArray();

            string ls_char;
            int ll_item;
            Decimal ldc_item;
            int ll_columns_per_record = 11;
            string[] ls_field = new string[ll_columns_per_record];
            li_rowcount = 0;
            dw_import.Reset();
            ib_loaded = false;
            for (k = 0; k <= 10; k++)
            {
                ls_field[k] = "";
            }
            //  Get the name of the file to load and try to open it
            //li_infile = FileOpen(as_infile, linemode!, read!, shared!);
            //if (li_infile < 0) 
            //{
            //    MessageBox.Show("Failed to open input file \r" + "      " + as_infile, "Error" );
            //    return li_infile;
            //}
            if (!File.Exists(as_infile))
            {
                MessageBox.Show("Failed to open input file \n" 
                               + "      " + as_infile
                               , "Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }
            //  Read in the lines, parse into fields, and copy the field info
            //  into the datawindow. Report and count any errors encountered.
            using (StreamReader sr = File.OpenText(as_infile))
            {
                while ((ls_line = sr.ReadLine()) != null)
                {
                    ls_char = ls_line.Substring(0, 1);
                    if (ls_char == "#" 
                        || ls_char == ";" 
                        || ls_char == "-" 
                        || ls_char == "/")
                    {
                        continue;
                    }
                    li_rowcount++;
                    string[] v = ls_line.Split(',');
                    for (j = 0; j <= 10; j++)
                    {
                        if (j < v.Length)
                        {
                            if (v[j] == "")
                            {
                                ls_field[j] = " ";
                            }
                            else
                            {
                                ls_field[j] = v[j];
                            }
                        }
                        else
                        {
                            ls_field[j] = " ";
                        }
                    }
                    dw_import.InsertItem<TelecomImport>(li_rowcount - 1);
                    li_row = dw_import.RowCount;
                    if (li_row < 0)
                    {
                        MessageBox.Show("Error adding row to datawindow \n" 
                                       + "at input row " + li_rowcount.ToString() + " (" + ls_field[5] + ")  "
                                       , "Net Error");
                        ii_errcount++;
                    }
                    else
                    {
                        dw_import.GetItem<TelecomImport>(li_rowcount - 1).BillMonth = ls_field[0];
                        try
                        {
                            dw_import.GetItem<TelecomImport>(li_rowcount - 1).BillCycle = Convert.ToInt32(ls_field[1]);
                        }
                        catch
                        {
                            dw_import.GetItem<TelecomImport>(li_rowcount - 1).BillCycle = 0;
                        }
                        dw_import.GetItem<TelecomImport>(li_rowcount - 1).CustNo = Convert.ToInt32(ls_field[2]);
                        dw_import.GetItem<TelecomImport>(li_rowcount - 1).AccountNo = Convert.ToInt32(ls_field[3]);
                        dw_import.GetItem<TelecomImport>(li_rowcount - 1).AccountName = ls_field[4];
                        dw_import.GetItem<TelecomImport>(li_rowcount - 1).OpenBal = Convert.ToDecimal(ls_field[5]);
                        dw_import.GetItem<TelecomImport>(li_rowcount - 1).Payments = Convert.ToDecimal(ls_field[6]);
                        dw_import.GetItem<TelecomImport>(li_rowcount - 1).AdjTran = Convert.ToDecimal(ls_field[7]);
                        dw_import.GetItem<TelecomImport>(li_rowcount - 1).BalBf = Convert.ToDecimal(ls_field[8]);
                        dw_import.GetItem<TelecomImport>(li_rowcount - 1).CurrChg = Convert.ToDecimal(ls_field[9]);
                        dw_import.GetItem<TelecomImport>(li_rowcount - 1).TotalDue = Convert.ToDecimal(ls_field[10]);
                    }
                    if (v.Length > ll_columns_per_record)
                    {
                        MessageBox.Show("Line " + li_rowcount.ToString() + " has an incorrect number of fields:  \n\n" + ls_line
                                       , "Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ii_errcount++;
                    }
                }
                sr.Close();
            }
            return li_rowcount;
        }

        public virtual int uf_checkaccount(string as_accountname)
        {
            //  TJB  Feb 2005  SR4648
            //  Validate the account_name field.  Look for format errors,
            //  and check validity of supplier_no/contract_no relationship.
            // 
            //  Return codes (reported by calling routine)
            //    0	OK
            //    1	Format error in field
            //    2	SQL error checking supplier_no/contract_no
            //    3	Invalid supplier_no/contract_no
            // 
            //    As a kluge, the function also returns the supplier and contract numbers
            //    from the account name in the global variables il_supplier and il_contract.
            int ll_len;
            int i;
            int j;
            int k;
            int ll_supplier = -1;
            int ll_contract = -1;
            string ls_surname;
            int li_exists;
            il_supplier = 0;
            il_contract = 0;
            ll_len = as_accountname.Length;
            //  Parse the account name
            //  Format is SSSS_CCCC_NNNN
            //  where SSSS = supplier number
            //        CCCC = contract number
            //    and NNNN = the first 4 characters of the contractor's surname
            //  Return 1 if the format is incorrect
            string[] val = as_accountname.Split('_');
            if (val.Length == 0)
            {
                return 1;
            }
            else
            {
                if (val.Length >= 1)
                {
                    ll_supplier = Convert.ToInt32(val[0]);
                }
                if (val.Length >= 2)
                {
                    ll_contract = Convert.ToInt32(val[1]);
                }
                if (val.Length >= 3)
                {
                    ls_surname = val[2];
                }
            }
            //  Check to see whether the contractor has the contract (or ever had).
            //   select count(*) into :li_exists
            //     from rd.contractor_renewals
            //    where contractor_supplier_no = :ll_supplier
            //      and contract_no = :ll_contract
            //
            //if (StaticVariables.sqlca.SQLCode != 0) {
            //    return 2;
            //}
            ODPSDataService service = ODPSDataService.SelectCountContractorRenewals(ll_supplier, ll_contract);
            if (service.SQLCode != 0)
            {
                return 2;
            }
            li_exists = service.RowCount;
            if (li_exists < 1)
            {
                return 3;
            }
            il_supplier = ll_supplier;
            il_contract = ll_contract;
            return 0;
        }

        #region Events
        public virtual void cb_read_clicked(object sender, EventArgs e)
        {
            //  TJB  Feb 2005  SR4648
            //  Checks that there is a file selected then
            // 		- imports its data into the dw_import datawindow
            // 		- validates the account name field
            // 		- Writes the data to the t_telecom_import table
            // 		- Reports any errors encountered
            // 		- reports the number of records found, the number of errors,
            // 		  a hash total of the current charges column, and tells the 
            // 		  user what to do next.
            //  The actual data import is done by the cb_import.clicked event.
            // 
            //  TJB  SR4674  July 2006
            //  Change the date processing to support any PB date formats
            //  Fix re-entry check
            int ll_import = 0;
            int ll_rowcount;
            int ll_row;
            string ls_bill_month;
            int? li_bill_cycle;
            int? ll_customer_no;
            int? ll_account_no;
            string ls_account_name;
            System.Decimal? dc_open_bal;
            System.Decimal? dc_payments;
            System.Decimal? dc_adj_tran;
            System.Decimal? dc_bal_bf;
            System.Decimal? dc_curr_chg;
            System.Decimal? dc_total_due;
            System.Decimal dc_hashtotal = 0;
            //StringArray ls_monthname = new StringArray();
            string[] ls_monthname = new string[12];
            int li_ok;
            int li_i;
            string ls_message = "";
            string ls_temp1, ls_temp2;
            DateTime ld_billMonth;
            string ls_this_month;
            string ls_this_year;

            if (sle_filename.Text == "")
            {
                MessageBox.Show("Select a file you wish to import (in the Browse box)\n" 
                               + "then press Read."
                               , "Import");
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            ib_loaded = false;
            ii_errcount = 0;
            ls_monthname[0] = "Jan";
            ls_monthname[1] = "Feb";
            ls_monthname[2] = "Mar";
            ls_monthname[3] = "Apr";
            ls_monthname[4] = "May";
            ls_monthname[5] = "Jun";
            ls_monthname[6] = "Jul";
            ls_monthname[7] = "Aug";
            ls_monthname[8] = "Sep";
            ls_monthname[9] = "Oct";
            ls_monthname[10] = "Nov";
            ls_monthname[11] = "Dec";

            //  TJB  SR4675  July 2006
            //  Determine this month's year and month to use as a default
            ls_bill_month = DateTime.Today.ToString("yyyy-MM-dd");
            li_i = DateTime.Now.Month;
            ls_this_month = ls_monthname[li_i - 1];
            ls_this_year = DateTime.Now.Year.ToString();

            // ll_import = dw_import.importfile(sle_filename.text,1)
            ll_rowcount = uf_importfile(sle_filename.Text, 1);
            if (ll_rowcount < 0)
            {
                MessageBox.Show("Read from " + sle_filename.Text + " failed."
                               , "Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            //  Check to see if the file has already been imported (assume that
            //  if the first record has been imported, the rest have been too).
            ii_errcount = 0;
            ll_row = 0;

            ls_bill_month = dw_import.GetItem<TelecomImport>(ll_row).BillMonth;

            DateTime tempDT;
            if (DateTime.TryParse(ls_bill_month, out tempDT))
            {
                li_i = tempDT.Month;
                ls_bill_month = ls_monthname[li_i - 1] + " " + tempDT.Year.ToString();
            }
            else
            {
                MessageBox.Show("Bad date format on row " + (ll_row + 1).ToString()
                               , "Validation Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                ii_errcount++;
            }
            if (ii_errcount == 0)
            {
                // TJB  RPCR_094  Mar-2015
                // Added parameter 2 to SelectPostTaxDeductions2

                ls_temp1 = "Telecom Deduction Month " + ls_bill_month;
                ls_temp2 = "Mobile Phone Deduction Month " + ls_bill_month;
                // select count(*) into :ll_import 
                //   from odps.post_tax_deductions 
                //  where ded_description like :ls_temp1 or ded_description like :ls_temp2
                ODPSDataService serv = ODPSDataService.SelectPostTaxDeductions2(ls_temp1, ls_temp2);
                ll_import = serv.RowCount;
                if (serv.SQLCode != 0)
                {
                    MessageBox.Show("Error checking for previous import \n\n"
                                   + serv.SQLErrText
                                   , "SQL Error "
                                   , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (ll_import > 0)
                {
                    MessageBox.Show("This file appears to have already been imported."
                                   , "Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                // Prepare the t_telecom_import table for upload
                //  delete from odps.t_telecom_import
                serv = ODPSDataService.DeleteTelecomImport();
                if (serv.SQLCode != 0)
                {
                    MessageBox.Show("Delete from t_telecom_import failed."
                                   + serv.SQLErrText + "\n\n"
                                   , "SQL Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //  Validate the data and upload the data into the t_telecom_import table
                ll_row = 0;
                while (ll_rowcount > ll_row)
                {
                    ls_bill_month = dw_import.GetItem<TelecomImport>(ll_row).BillMonth;
                    li_bill_cycle = dw_import.GetItem<TelecomImport>(ll_row).BillCycle;
                    ll_customer_no = dw_import.GetItem<TelecomImport>(ll_row).CustNo;
                    ll_account_no = dw_import.GetItem<TelecomImport>(ll_row).AccountNo;

                    ls_account_name = dw_import.GetItem<TelecomImport>(ll_row).AccountName;
                    dc_open_bal = dw_import.GetItem<TelecomImport>(ll_row).OpenBal;
                    dc_payments = dw_import.GetItem<TelecomImport>(ll_row).Payments;
                    dc_adj_tran = dw_import.GetItem<TelecomImport>(ll_row).AdjTran;

                    dc_bal_bf = dw_import.GetItem<TelecomImport>(ll_row).BalBf;
                    dc_curr_chg = dw_import.GetItem<TelecomImport>(ll_row).CurrChg;
                    dc_total_due = dw_import.GetItem<TelecomImport>(ll_row).TotalDue;
                    li_ok = uf_checkaccount(ls_account_name);
                    if (!(li_ok == 0))
                    {
                        if (li_ok == 1)
                        {
                            ls_message = "Invalid format";
                        }
                        else if (li_ok == 2)
                        {
                            ls_message = "SQL error checking supplier/contract";
                        }
                        else if (li_ok == 3)
                        {
                            ls_message = "Supplier/contract invalid";
                        }
                        else
                        {
                            ls_message = "Undefined";
                        }
                        MessageBox.Show("Account name " + ls_account_name + " on row " + ll_row.ToString() + "\n\n" 
                                       + "Error code " + li_ok.ToString() + " (" + ls_message + ")"
                                       , "Validation Error");
                        ii_errcount++;
                    }
                    //if (IsDate(ls_bill_month)) {
                    //    ld_billMonth = System.Convert.ToDateTime(ls_bill_month );
                    //    ls_bill_month = String(ld_billMonth, "yyyy-mm-dd");
                    //    li_i = System.Conver.ToInt32(TextUtil.Mid(ls_bill_month, 6, TextUtil.Pos(ls_bill_month, '-', 6 ) - 6));
                    //    ls_bill_month = ls_monthname[li_i] + ' ' +  TextUtil.Mid(ls_bill_month, 1, 4);
                    //}
                    //else {
                    //    MessageBox.Show("Bad date format on row " + String(ll_row, "Validation Error" );
                    //    ls_bill_month = ls_this_month + ' ' + ls_this_year;
                    //    ii_errcount++;
                    //}
                    if (DateTime.TryParse(ls_bill_month, out tempDT))
                    {
                        li_i = tempDT.Month;
                        ls_bill_month = ls_monthname[li_i - 1] + " " + tempDT.Year.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Bad date format on row " + ll_row.ToString()
                                       , "Validation Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ii_errcount++;
                    }

                    //insert into odps.t_telecom_import(bill_month, bill_cycle, customer_no, account_no, account_name, open_bal, payments, adj_tran, bal_bf, curr_chg, total_due, supplier_no, contract_no )
                    //values(:ls_bill_month, :li_bill_cycle, :ll_customer_no, :ll_account_no, :ls_account_name, :dc_open_bal, :dc_payments,   :dc_adj_tran, 	 :dc_bal_bf, 
                    //:dc_curr_chg,:dc_total_due,:il_supplier, :il_contract )

                    serv = ODPSDataService.InsertTelecomImport(
                        ls_bill_month,
                        li_bill_cycle,
                        ll_customer_no,
                        ll_account_no,
                        ls_account_name,
                        dc_open_bal,
                        dc_payments,
                        dc_adj_tran,
                        dc_bal_bf,
                        dc_curr_chg,
                        dc_total_due,
                        il_supplier,
                        il_contract);

                    if (serv.SQLCode != 0)
                    {
                        MessageBox.Show("Error inserting row " + ll_row.ToString() 
                                           + " (" + ls_account_name + ")" 
                                           + " into t_telecom_import table \n\n"
                                       + serv.SQLErrText
                                       ,"SQL Error");
                        return;
                    }
                    ll_row++;
                }
                // Collect and present summary info about what has been done
                //   select count(*), sum(curr_chg) into :ll_rowcount, :dc_hashtotal 
                //     from odps.t_telecom_import;
                serv = ODPSDataService.CountTelecomImport();
                if (serv.SQLCode != 0)
                {
                    MessageBox.Show("Error obtaining summary totals from t_telecom_import table \n\n"
                                   + serv.SQLErrText
                                   , "SQL Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                ll_rowcount = serv.telecomImport.LlRowCount;
                dc_hashtotal = serv.telecomImport.DcHashtotal;
                ls_message = "\nRows read:  " + ll_rowcount.ToString() + "\n" 
                                + "Errors encountered: " + ii_errcount.ToString() + "\n" 
                                + "Sum(Current charges) = " + dc_hashtotal.ToString() + "\n\n";
            }
            if (ii_errcount == 0)
            {
                ls_message += "Press Import to import this data into the database   \n" 
                                + "or Close to cancel this import.\n";
            }
            else
            {
                ls_message += "Please correct the errors before importing the data.  \n";
            }
            MessageBox.Show(ls_message
                            , "Summary"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
            //  Set the flag to say the load step has been done
            //  TJB  SR4674  July 2004
            //  Enable the Import button only if there are no errors
            if (ii_errcount == 0)
            {
                ib_loaded = true;
                cb_import.Enabled = true;
            }
            else
            {
                ib_loaded = false;
                cb_import.Enabled = false;
            }
        }

        public virtual void cb_import_clicked(object sender, EventArgs e)
        {
            //  TJB  Feb 2005  SR4648
            //  Checks that data from an input file has been loaded 
            //  and performs the import into the database.  Initial 
            //  validation is performed in the cb_read.clicked event.
            //int li_ok;
            DialogResult li_ok;
            int li_imported = 0;
            string ls_today;
            string ls_select1, ls_select2;
            System.Decimal dc_hashtotal = 0;
            if (!ib_loaded)
            {
                MessageBox.Show("Select a file you wish to import (in the Browse box)\n" 
                                + "then press Read."
                                , "Warning");
                return;
            }
            if (ii_errcount > 0)
            {
                li_ok = MessageBox.Show(ii_errcount.ToString() + " errors were encountered in the import file  \n" 
                                        + "Are you sure you want to import the data? \n"
                                        , "Warning" 
                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question
                                        , MessageBoxDefaultButton.Button2);

                if (!(li_ok == DialogResult.Yes))
                {
                    return;
                }
            }
            // Insert Telecom data into post_tax_adjustments
            //    SELECT string(today()) INTO :ls_today FROM dummy
            ODPSDataService service = ODPSDataService.SelectDateDummy();
            ls_today = service.DataObject;
            if (service.SQLCode != 0)
            {
                MessageBox.Show("Error obtaining today\'s date.\n"
                                + "- Import aborted! \n\n"
                                + service.SQLErrText
                                , "SQL Error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            // TJB  RPCR_094  Mar-2015
            // Changed InsertPostTaxDeductions to InsertTelecomPostTaxDeductions
            service = ODPSDataService.InsertTelecomPostTaxDeductions(ls_today);
            if (service.SQLCode != 0)
            {
                MessageBox.Show("Error inserting into post_tax_deductions "
                                + "- Import aborted! \n\n"
                                + service.SQLErrText 
                                , "SQL Error "
                                , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            // TJB  RPCR_094  Mar-2015
            // Added parameter 2 to SelectPostTaxDeductions

            ls_select1 = "Telecom Deduction % imported on " + ls_today;
            ls_select2 = "Mobile Phone Deduction % imported on " + ls_today;
            //SELECT count(*), sum(ded_fixed_amount) 
            //  INTO :li_imported, :dc_hashtotal 
            //  FROM odps.post_tax_deductions 
            // WHERE ded_reference like :ls_select1 or ded_reference like :ls_select2

            service = ODPSDataService.SelectPostTaxDeductions(ls_select1, ls_select2);
            
            li_imported = service.LiImported;
            dc_hashtotal = service.DcHashtotal;

            if (service.SQLCode != 0)
            {
                MessageBox.Show("Error obtaining insert count. \n" 
                                + "(" + ls_select1 + " or " + ls_select2 + ") \n\n"
                                + service.SQLErrText
                                ,"SQL Error");
                li_imported = -1;
            }
            // Setpointer(arrow!)
            //  if (IsNull(dc_hashtotal)) {
            //    dc_hashtotal = 0;
            //  }
            MessageBox.Show("Import complete                          \n\n" 
                            + "    " + li_imported.ToString() + " rows imported \n" 
                            + "   $" + dc_hashtotal.ToString() + " total value."
                            , "");
            ib_loaded = false;
            // TJB  SR4674  July 2004
            // Disable the Import button when file has been read
            cb_import.Enabled = false;
        }

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            //  TJB  Feb 2005  SR4648
            dw_import.Reset();
            this.Close();
        }

        public virtual void cb_browse_clicked(object sender, EventArgs e)
        {
            // TJB  Feb 2005  SR4648
            //  Gets the name of a file to import
            //  Resets the import status
            string ls_named;
            int li_value;
            dw_import.Reset();
            ib_loaded = false;
            //li_value = GetFileOpenName("Select File", is_docname, ls_named,
            //    "csv", "CSV Files (*.CSV),*.CSV, " + "DBF Files (*.DBF),*.DBF, " + "TXT Files (*.TXT),*.TXT");
            //sle_filename.text = is_docname;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select File";
            dialog.AddExtension = true;
            dialog.DefaultExt = "csv";
            dialog.Filter = "CSV Files (*.CSV)|*.CSV|DBF Files (*.DBF)|*.DBF|TXT Files (*.TXT)|*.TXT";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                is_docname = dialog.FileName;
                sle_filename.Text = is_docname;
            }
        }
        #endregion
    }
}