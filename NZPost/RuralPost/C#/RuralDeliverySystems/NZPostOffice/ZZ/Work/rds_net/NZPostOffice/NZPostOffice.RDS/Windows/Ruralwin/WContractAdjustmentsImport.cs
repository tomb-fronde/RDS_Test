using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using Metex.Windows;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public partial class WContractAdjustmentsImport : WAncestorWindow
    {
        #region Define
        public string is_docname = String.Empty;

        public DataUserControl id_import;
        #endregion

        public WContractAdjustmentsImport()
        {
            this.InitializeComponent();
        }

        public override int closequery()
        {
            return base.closequery();
            //?this.Close();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            // Set the component name 
            this.of_set_componentname("Piece Rate Import");
            // Tell security that the user must have national access  ( Own region=National)
            this.of_set_nationalaccess(true);

        }

        public override void pfc_postopen()
        {
            dw_import.URdsDw_GetFocus(null, null);
        }

        public override void close()
        {
            base.close();
            //? this.Close() // infinite loop
        }

        #region Events
        public virtual void cb_import_clicked(object sender, EventArgs e)
        {
            //  TJB SR4562
            //  w_piecerate_import.cb_import.clicked
            int ll_import = -1;
            int ll_rowcount;
            int ll_row;
            int li;
            int lj;
            int lk;
            string ls_contract = "";
            string ls_date = "";
            string ls_value = "";
            string ls_reason = "";
            string ls_instring;
            string ls_message;
            int li_inserted = 0;
            int li_skipped = 0;
            int li_errors = 0;
            decimal ln_amount_inserted = 0;
            // DECLARE loadAdjustments PROCEDURE FOR rd.loadContractAdjustments;
            if (sle_filename.Text == "")
            {
                MessageBox.Show("Please click Browse and select a file you wish to import.", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dw_import.Reset();
            Cursor.Current = Cursors.WaitCursor;
            /* delete from rd.temp_Contract_Adjustments using sqlca; */
            RDSDataService dataService = RDSDataService.DeleteFromTempContractAdjustments();
            if (dataService.SQLCode != 0)
            {
                MessageBox.Show("Delete rd.temp_Contract_Adjustments failed. \n" + dataService.SQLErrText, "Error  " + dataService.SQLCode, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //? ROLLBACK;
                return; //? return -(1);
            }
            //? commit;
            ll_import = dw_import.ImportFile(sle_filename.Text);
            if (ll_import <= 0)
            {
                MessageBox.Show("Problem opening or reading import file.\n" + "File = " + sle_filename.Text + "\r\n" + "Error code = " + ll_import, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return; //? return -(1);
            }
            ll_rowcount = dw_import.RowCount;
            if (ll_rowcount <= 0)
            {
                MessageBox.Show("No data found in import file. \n" + "File = " + sle_filename.Text + '~' + "Rows found = " + ll_rowcount, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return; //? return -(1);
            }
            /* ------------------------ Debugging ------------------------ //
                MessageBox.Show ( &"Filename = "+sle_filename.text+'\n'   &+"ll_import = "+string ( ll_import)+'\n' & +"ll_rows = "+string ( ll_rowcount,  "w_contract_adjustments_import.cb_import.clicked" )
            // -----------------------------------------------------------  */
            ll_row = 0;
            while (!(ll_row >= ll_rowcount))
            {
                ls_instring = dw_import.GetItem<ContractAdjustmentsImport>(ll_row).Column1;
                // Parse the input string
                // Expecting
                // <contract number>,'<date>',<value>,'<reason>'
                li = ls_instring.IndexOf(',');
                if (li == -1)
                {
                    MessageBox.Show("Incorrect format: " + ls_instring, "Data error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string[] parts = ls_instring.Split(new char[] { ',' });
                    if (parts.Length == 4)
                    {
                        ls_contract = parts[0];
                        ls_date = parts[1].Substring(1, parts[1].Length - 2);
                        ls_value = parts[2];
                        ls_reason = parts[3].Substring(1, parts[3].Length - 2);
                    }
                    /* ------------------------ Debugging ------------------------ //
                        MessageBox.Show ( & "Input = "+ls_instring+'\n'		& +"ll_row = "+string ( ll_row)+'\n'	& +"ls_contract = "+ls_contract		,  "Debug" )
                    // -----------------------------------------------------------  */
                    /* insert into rd.temp_Contract_Adjustments ( contract_no,ca_date_occured,ca_amount,ca_reason)
                        values ( :ls_contract,:ls_date,:ls_value,:ls_reason) using sqlca; */
                    dataService = RDSDataService.InsertTempContractAdjustments(ls_date, ls_reason, ls_value, ls_contract);
                    if (dataService.SQLCode != 0)
                    {
                        MessageBox.Show(dataService.SQLErrText, "Insert Error: temp_Contract_Adjustments", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //? ROLLBACK;
                        return; //? return -1;
                    }
                }
                ll_row++;
            }
            //  commit;
            ll_row--;
            if (ll_row > 0)
            {
                //? execute loadAdjustments;
                dataService = RDSDataService.LoadContractAdjustments();
                if (dataService.SQLCode < 0)
                {
                    ls_message = "Error executing loadContractAdjustments. \n" + dataService.SQLErrText;
                    MessageBox.Show(ls_message, "Error " + dataService.SQLCode, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //? rollback;
                    return; //? return -1;
                }
                //? commit;
                /* select rows_inserted, rows_skipped, row_errors, amount_inserted
                    into :li_inserted, :li_skipped, :li_errors, :ln_amount_inserted
                    from rd.ca_load_results
                    where load_name = 'ContractAdjust'   using sqlca; */
                dataService = RDSDataService.GetCaLoadResults();
                if (dataService.CaLoadResultsList.Count > 0)
                {
                    CaLoadResultsItem item = dataService.CaLoadResultsList[0];
                    li_inserted = item.RowsInserted;
                    li_skipped = item.RowsSkipped;
                    li_errors = item.RowErrors;
                    ln_amount_inserted = item.AmountInserted;
                }
                if (dataService.SQLCode != 0)
                {
                    ls_message = "Error fetching status of load. \n" + dataService.SQLErrText;
                    MessageBox.Show(ls_message, "Error " + dataService.SQLCode, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //? commit;
            }
            Cursor.Current = Cursors.Arrow;
            MessageBox.Show("Inserted " + li_inserted + "\r\n   Skipped " + li_skipped + "\r\n     Errors " + li_errors + "\r\nTotal value " + string.Format("{0:$#,###,##0.00}", ln_amount_inserted) /**/, "Import Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return; //? return 0;
        }

        public virtual void cb_browse_clicked(object sender, EventArgs e)
        {
            //  TJB SR4562 - Import contract adjustments for NZ Herald
            // 
            //  w_contract_adjustments_import.cb_browse.clicked
            string ls_named;
            int li_value;
            dw_import.Reset();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select File";
            dlg.Filter = "CSV Files (*.TXT)|*.TXT";
            if (dlg.ShowDialog() == DialogResult.OK)
                is_docname = dlg.FileName;
            else
                is_docname = "";
            sle_filename.Text = is_docname;
        }

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}