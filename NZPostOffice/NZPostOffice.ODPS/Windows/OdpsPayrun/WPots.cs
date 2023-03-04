using System;
using System.Windows.Forms;
using NZPostOffice.ODPS.DataService;
using NZPostOffice.ODPS.Windows.OdpsPayrun;
using NZPostOffice.Shared;
using System.IO;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.ODPS.Windows.OdpsPayrun
{
    public partial class WPots : FormBase
    {
        public string is_delimiter = ",";

        public WPots()
        {
            this.InitializeComponent();
            constructor();
        }

        public virtual int of_process_file(int al_file_handle)
        {
            int ll_return = 1;
            int ll_file_handle = 0;
            int ll_reading_status = 0;
            string ls_filepath = null;
            string ls_filename = null;
            bool error_check = false;
            string ls_name = null;
            string ls_ird = null;
            string ls_contract_no = null;
            string ls_vendor = null;
            string ls_supplier = null;
            string ls_gross = null;
            string ls_tax = null;
            string ls_gst = null;
            string ls_net = null;
            int ll_contract_no;
            int ll_supplier;
            System.Decimal ld_gross;
            System.Decimal ld_tax;
            System.Decimal ld_gst;
            System.Decimal ld_net;
            int ll_invoice_no;
            int insert_count = 0;
            string ls_temp_read = null;
            DateTime ld_input_date;
            ld_input_date = System.Convert.ToDateTime(sle_date.Text);
            //  open a file browser and load up a file
            //      ll_return = GetFileOpenName("Please select file to import for POTS operation", ls_filepath, ls_filename);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Please select file to import for POTS operation";
            openFileDialog.FileName = ls_filename;
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            ls_filepath = openFileDialog.FileName;

            //  set up the invoice_no 
            ll_invoice_no = 1;
            //?  if (ll_return > 0 && ls_filepath.Length > 0)
            //? {
            //?ll_file_handle = FileOpen(ls_filepath, linemode!);
            //?File.Open(ls_filepath, FileMode.Open);

            //?  if ((ll_file_handle == null) == false && ll_file_handle > 0)
            //? {
            //  get on and read file
            //?ll_reading_status = FileRead(ll_file_handle, ls_temp_read);
            try
            {
                using (StreamReader sread = new StreamReader(new FileStream(ls_filepath, FileMode.Open), System.Text.Encoding.Default))//new StreamReader(ls_filepath,false ))
                {
                    //?  while ((ll_reading_status == null) == false && ll_reading_status > 0)
                    //?{
                    while ((ls_temp_read = sread.ReadLine()) != null)
                    {
                        //?ls_temp_read = sread.ReadLine();
                        //  do insert of the data - put into error file otherwise  ( to be saved into same filepath as read file)
                        //  build the data
                        ls_name = this.of_get_token(ls_temp_read, 1);
                        ls_ird = this.of_get_token(ls_temp_read, 2);
                        ls_contract_no = this.of_get_token(ls_temp_read, 3);
                        ls_vendor = this.of_get_token(ls_temp_read, 4);
                        ls_supplier = this.of_get_token(ls_temp_read, 5);
                        ls_gross = this.of_get_token(ls_temp_read, 6);
                        ls_tax = this.of_get_token(ls_temp_read, 7);
                        ls_gst = this.of_get_token(ls_temp_read, 8);
                        ls_net = this.of_get_token(ls_temp_read, 9);
                        //  see if there were any problems with the tokenising of the line - if so write to file
                        if (ls_name == null || ls_ird == null || ls_contract_no == null || ls_vendor == null || ls_supplier == null || ls_gross == null || ls_tax == null || ls_gst == null || ls_net == null)
                        {
                            //  need to warn the user
                            MessageBox.Show("The following line in the file was not a valid data line : \n" + ls_temp_read + "\nThis line was not processed, and was not inserted into the database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            //  execute the insertion procedure in the database
                            string ls_sql_insert;
                            ls_sql_insert = "select odps.new_pots ( \'" + ls_name + "\', \'" + ls_ird + "\', " + ls_contract_no + ", \'" + ls_vendor + "\', " + ls_supplier + ", " + ls_gross + ", " + ls_tax + ", " + ls_gst + ", " + ls_net + ')';
                            int li_return;
                            ll_contract_no = Convert.ToInt32(ls_contract_no);
                            ll_supplier = Convert.ToInt32(ls_supplier);
                            ld_gross = Convert.ToDecimal(ls_gross);
                            ld_tax = Convert.ToDecimal(ls_tax);
                            ld_gst = Convert.ToDecimal(ls_gst);
                            ld_net = Convert.ToDecimal(ls_net);
                            //EXECUTE IMMEDIATE ls_sql_insert;
                            //DECLARE insertproc procedure for odps.new_pots
                            //            name = :ls_name,
                            //            ird_no = :ls_ird,
                            //            con_no = :ll_contract_no,
                            //            vendor_id = :ls_vendor,
                            //            supplier_no = :ll_supplier,
                            //            gross = :ld_gross,
                            //            tax = :ld_tax,
                            //            gst = :ld_gst,
                            //            net = :ld_net,
                            //            invoice_number = :ll_invoice_no,
                            //            input_date = :ld_input_Date;
                            //execute insertproc;
                            ODPSDataService dataService = ODPSDataService.NewPots(
                                ls_name, 
                                ls_ird,
                                ll_contract_no, 
                                ls_vendor,
                                ll_supplier,
                                ld_gross, 
                                ld_tax,
                                ld_gst,
                                ld_net, 
                                ll_invoice_no, 
                                ld_input_date);
                            if (dataService.SQLCode < 0)
                            {
                                MessageBox.Show("There was a problem loading the line : \n" + ls_temp_read + "\nThis line of your file was not loaded.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                insert_count++;
                                ll_invoice_no++;
                            }

                            //? CLOSE insertproc
                        }
                        //?ll_reading_status = FileRead(ll_file_handle, ls_temp_read);
                    }

                    //  close the file
                    //?FileClose(ll_file_handle);
                    //  tell the suer how many new entries where written to the database

                    MessageBox.Show(Convert.ToString(insert_count) + " new payment entries have been written to the database.", "Message");
                }
            }
            catch //?else
            {
                //?MessageBox.Show("There was an error selecting your file. Please try again.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //  close the window and make them start again
                ll_return = -(1);
            }
            return ll_return;
        }

        public virtual string of_get_token(string as_line, int ai_pos)
        {
            //  Tim Chan - 27/05/2003
            //  initial version
            //  This function will take a string and a position - from a set delimiter return the token at pos
            //  counting of pos - starts at 1  ( so 1 is the first token)
            string ls_temp_token = string.Empty;
            string ls_return_token = string.Empty;
            string ls_temp_line = string.Empty;
            string ls_temp_line2 = string.Empty;
            int counter;
            bool lb_error;
            lb_error = false;
            //n_cst_string lnv_string;
            NCstString lnv_string = new NCstString();
            ls_temp_line = as_line;
            for (counter = 1; counter <= ai_pos; counter++)
            {
                ls_temp_line2 = ls_temp_line2;
                ls_temp_token = lnv_string.of_gettoken(ref ls_temp_line, is_delimiter);
                //  check if no token was found 
                if ((ls_temp_line2 == ls_temp_line) && (counter != ai_pos))
                {
                    lb_error = true;
                }
            }
            if (lb_error)
            {
                ls_return_token = null;
            }
            else
            {
                ls_return_token = ls_temp_token;
            }
            return ls_return_token;
        }

        public virtual DateTime of_get_date()
        {
            //  Tim Chan - 11/06/2003
            //  This function will return a date that is either the 20th of this month or the next month if we are past the 20th
            DateTime ld_date = new DateTime();
            string ls_date;
            ls_date = "20/";

            int ls_date1 = 20;//! added


            if (Convert.ToInt16(DateTime.Today.Day) > 20)
            {
                if (Convert.ToInt16(DateTime.Today.Month) + 1 == 13)
                {
                    ls_date = "20/01/" + DateTime.Today.Year.ToString() + "1";
                }
                else
                {
                    ls_date = ls_date + DateTime.Today.Month.ToString() + '/' + DateTime.Today.Year.ToString();
                    ld_date = System.Convert.ToDateTime(ls_date);
                }
            }
            else
            {
                ls_date = ls_date + DateTime.Today.Month.ToString() + '/' + DateTime.Today.Year.ToString();
                //! ld_date = System.Convert.ToDateTime(ls_date);
                ld_date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, ls_date1);

            }
            return ld_date;
        }

        public virtual void constructor()
        {
            sle_date.Text = string.Format("{0:dd/MM/yyyy}", of_get_date());
        }

        #region Events
        public virtual void open(object sender, EventArgs e)
        {
            //  23/05/2003 - TWC - initial version
            //  make call to process
            //  of_process_file ( 1)
            //  close ( this)
            //  populate the sle_date with current date
        }

        public virtual void close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //  see if need to open the payrun now
            if (MessageBox.Show("Do you wish to do a Pay Run now?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //OpenSheet(w_payment_run_search, gnv_app.of_getframe(), 0, original!);
                OpenSheet<WPaymentRunSearch>(StaticVariables.MainMDI);
            }
        }

        public virtual void cb_import_clicked(object sender, EventArgs e)
        {
            //  check to see if date is valid - and if so proceed
            //  will count date as invalid if it is prior to 98 - the earliest date in the database
            DateTime sle_date_temp;
            if (DateTime.TryParse(sle_date.Text, out sle_date_temp) && System.Convert.ToDateTime(sle_date.Text).Year > 1998)
            {
                //  parent.of_process_file(1);
                this.of_process_file(1);
                this.Close();
            }
            else
            {
                MessageBox.Show("The date entered is not valid. Please enter a valid date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                sle_date.Text = string.Format("0:dd/MM/yyyy", of_get_date());
            }
        }
        #endregion
    }
}
