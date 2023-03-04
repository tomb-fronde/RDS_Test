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

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    // TJB  RPCR_098  Jan-2016: Created from WShellImport
    // Loads a file into memory, then calls stored procedure rd.insert_PTDs
    //   to insert them into the odps.post_tax_deductions table.
    // Allows files to be imported to be TXT or CSV
    // Browse button also loads the file
    // Stored procedure checks for valid, not-terminated contract, otherwise anything goes
    // 
    public partial class WPTDImport : WMaster
    {
        public string is_docname = String.Empty;

        public WPTDImport()
        {
            InitializeComponent();

            this.dw_import.DataObject = new DPTDImport();
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

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            dw_import.Reset();
            this.Close();
        }

        // TJB  RPCR_098  Jan-2016
        // Browse for a file to import, then load it
        // NOTE: No error checking!
        // Contract_no is checked for terminated in stored procedure (rd.insert_PTD)
        public virtual void cb_browse_clicked(object sender, EventArgs e)
        {
            dw_import.Reset();
            sle_filename.Text = "";

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select File";
            dialog.AddExtension = true;
            dialog.DefaultExt = "TXT";
            dialog.Filter = "Text Files (*.TXT)|*.TXT";
            dialog.Filter = "TXT Files (*.TXT)|*.TXT|CSV Files (*.CSV)|*.CSV";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                is_docname = dialog.FileName;
                sle_filename.Text = is_docname;

                load_file();
            }
            else
                sle_filename.Text = "";
        }

        
        public virtual void load_file()
        {
            int nRow, nRows;
            System.Decimal? ldc_amount;
            System.Decimal? ldc_total_amount;

            // Get the name of the file to import
            if (sle_filename.Text == "")
            {
                MessageBox.Show("Please click browse and select a file you wish to import."
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            // Clear out dw_import to load data from the input file
            dw_import.InsertItem<PTDImport>(0);
            dw_import.Reset();

            // Import the file's contents
            // The file can be either CSV format, or text (*.txt with tab-separated values)
            int n = dw_import.ImportFile(sle_filename.Text, 0);

            ldc_total_amount = 0m;
            nRows = dw_import.RowCount;
            for (nRow = 0; nRow < nRows; nRow++)
            {
                ldc_amount = (decimal)dw_import.GetItem<PTDImport>(nRow).Amount;
                ldc_total_amount += ldc_amount;
            }
            
            MessageBox.Show("                                                               \n"
                            + "        Records loaded = " + nRows.ToString() + "\n"
                            + "        Total amount = $" + ldc_total_amount.ToString() + "\n\n"
                            , "Load Summary");

            this.Cursor = Cursors.Arrow;

            /*
                        int nRowcount;
                        int nContracts;
                        int? ll_prev_contract;
                        int? ll_contract;
                        string ls_description;
                        string ls_reference;
             
                        //Scan the data imported, calculating summary totals
                        nRowcount = dw_import.RowCount;
                        ldc_total_amount = 0;
                        ll_prev_contract = 0;
                        nContracts = 0;

                        nRow = 0;
                        while (nRow < nRowcount)
                        {
                            ll_contract = dw_import.GetItem<PTDImport>(nRow).ContractNo;
                            ldc_amount = dw_import.GetItem<PTDImport>(nRow).Amount;
                            ls_description = dw_import.GetItem<PTDImport>(nRow).Description;
                            ls_reference = dw_import.GetItem<PTDImport>(nRow).Reference;

                            ldc_total_amount += ldc_amount;
                            ll_contract = (ll_contract == null) ? 0 : ll_contract;
                            if (ll_contract != ll_prev_contract) 
                                nContracts++;

                            nRow++;
                        }

                        this.Cursor = Cursors.Arrow;
                        MessageBox.Show("Totals: " + "\n"
                                       + "Records  " + nRow.ToString() + "\n"
                                       + "Contracts  " + nContracts.ToString() + "\n"
                                       + "Value   " + ldc_total_amount.ToString() + "\n"
                                       , "Summary" );
            */
        }

        // TJB  RPCR_098  Jan-2016
        // Heavily modified insert (from shellImpost)
        // Step through the records, inserting them one-by-one
        private void cb_insert_Click(object sender, EventArgs e)
        {
            int ll_contract;
            decimal ldc_amount, ldc_total_imported, ldc_total_skipped;
            string ls_description;
            string ls_reference;
            int nRow, nRows, nRowsImported, nErrors;

            nRows = dw_import.RowCount;
            if (nRows < 1)
            {
                MessageBox.Show("Please click browse and select a file you wish to import."
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            ldc_total_imported = 0m;
            ldc_total_skipped = 0m;
            nErrors = 0;
            nRowsImported = 0;
            for (nRow = 0; nRow < nRows; nRow++)
            {
                ll_contract = (int)dw_import.GetItem<PTDImport>(nRow).ContractNo;
                ldc_amount = (decimal)dw_import.GetItem<PTDImport>(nRow).Amount;
                ls_description = dw_import.GetItem<PTDImport>(nRow).Description;
                ls_reference = dw_import.GetItem<PTDImport>(nRow).Reference;
                
                ODPSDataService service = ODPSDataService.InsertPTDs(ll_contract, ldc_amount, ls_description, ls_reference);
                if (service.SQLCode != 0)
                {
                    MessageBox.Show("SQL Error inserting PTD \n\n"
                                    + "Row "+nRow.ToString() + "\n"
                                    + "Contract "+ll_contract.ToString() + "\n"
                                    + "Amount $"+ldc_amount.ToString() + "\n\n"
                                    + "SQLCode = "+service.SQLCode.ToString()+"\n"
                                    + "SQLErrText = " + service.SQLErrText+"\n\n"
                                    + "Skipping error record"
                                   , "SQL Error");
                }
                if (service.LReturn != 1)
                {
                    string errmsg= "Stored procedure InsertPTD returned " + service.LReturn.ToString();
                    if (service.LReturn == -1)
                        errmsg = "Error code returned " + service.LReturn.ToString() + " (contract not found)";
                    if (service.LReturn == -2)
                        errmsg = "Error code returned " + service.LReturn.ToString() + " (terminated contract)";
                    
                    MessageBox.Show("Error inserting PTD \n\n"
                                    + "Row " + nRow.ToString() + "\n"
                                    + "Contract " + ll_contract.ToString() + "\n"
                                    + "Amount $" + ldc_amount.ToString() + "\n\n"
                                    + errmsg + "\n\n"
                                    + "Skipping error record"
                                   , "Error");
                }
                if (service.SQLCode == 0 && service.LReturn == 1)
                {
                    nRowsImported++;
                    ldc_total_imported += ldc_amount;
                }
                else
                {
                    nErrors++;
                    ldc_total_skipped += ldc_amount;
                }
            }

            this.Cursor = Cursors.Arrow;

            // Prepare a "this is what we did" message
            string records = (nRowsImported == 1) ? "Record" : "Records";
            string errors  = (nErrors == 1) ? "Error" : "Errors";
            string sErrors = (nErrors == 0) ? "No" : nErrors.ToString();
            string s_total_skipped = (ldc_total_skipped == 0m) ? "0.00" : ldc_total_skipped.ToString();

            MessageBox.Show("                                                               \n"
                            + nRowsImported.ToString() + "  " + records + " imported\n"
                            + "$"+ldc_total_imported.ToString() + "  Total amount imported\n\n"
                            + sErrors + "  " + errors + " encountered \n"
                            + "$"+s_total_skipped + "  Total amount not loaded\n"
                            , "Load Summary");
        }
    }
}