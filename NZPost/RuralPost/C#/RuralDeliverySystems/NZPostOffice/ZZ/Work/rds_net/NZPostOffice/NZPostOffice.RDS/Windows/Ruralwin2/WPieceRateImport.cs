using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Metex.Core;
using Metex.Windows;

using NZPostOffice.Shared;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    // TJB  RPCR_054  June-2013 
    // wf_calculate_cost rewritten and renamed (was wf_calculate_rate)

    public class WPieceRateImport : WAncestorWindow
    {
        #region Define

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_1;

        public TextBox sle_1;

        public Label st_1;

        public Button cb_import_values;

        public Button cb_select_infile;

        public Button cb_save;

        public Button cb_import_novalues;

        public Button cb_cancel;

        public Button cb_stop;

        public URdsDw dw_errors;

        public List<PieceRateImportExeptionReport> dw_errorsList = new List<PieceRateImportExeptionReport>();
        
        public PictureBox p_abort;

        public string isIgnoreWrongRates = "UNDEF";

        public int nInputRecords;

        #endregion

        public WPieceRateImport()
        {
            this.InitializeComponent();

            dw_1.DataObject = new DPieceRateImport();
            dw_errors.DataObject = new DPieceRateImportExeptionReport();
        }

        public override void open()
        {
            base.open();
        }

        public override int closequery()
        {
            return base.closequery();
        }

        public override void pfc_preopen()
        {
            //? base.pfc_preopen();
            // Set the component name 
            this.of_set_componentname("Piece Rate Import");
            // Tell security that the user must have national access  ( Own region=National)
            this.of_set_nationalaccess(true);
        }

        //added by jlwang for implement menu
        public override void pfc_postopen()
        {
            //?base.pfc_postopen();
            dw_1.URdsDw_GetFocus(new object(), new EventArgs());
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.dw_1 = new URdsDw();
            this.sle_1 = new TextBox();
            this.st_1 = new Label();
            this.cb_import_values = new Button();
            this.cb_select_infile = new Button();
            this.cb_save = new Button();
            this.cb_import_novalues = new Button();
            this.cb_cancel = new Button();
            this.dw_errors = new URdsDw();
            this.p_abort = new PictureBox();
            this.cb_stop = new Button();

            Controls.Add(dw_1);
            Controls.Add(sle_1);
            Controls.Add(st_1);
            Controls.Add(cb_import_values);
            Controls.Add(cb_select_infile);
            Controls.Add(cb_save);
            Controls.Add(cb_import_novalues);
            Controls.Add(cb_cancel);
            Controls.Add(dw_errors);
            Controls.Add(p_abort);
            Controls.Add(cb_stop);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Text = "Piece Rate Import";
            this.Size = new System.Drawing.Size(478, 424);

            // 
            // st_label
            // 
            st_label.Text = "w_piece_rate_import";
            st_label.Location = new System.Drawing.Point(3, 358);

            // 
            // dw_1
            // 
            dw_1.Location = new System.Drawing.Point(3, 30);
            dw_1.Size = new System.Drawing.Size(466, 325);
            dw_1.TabIndex = 5;

            // 
            // sle_1
            // 
            sle_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            sle_1.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            sle_1.TabIndex = 1;
            sle_1.Location = new System.Drawing.Point(53, 3);
            sle_1.Size = new System.Drawing.Size(174, 18);

            // 
            // st_1
            // 
            st_1.TabStop = false;
            st_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            st_1.Text = "Filename";
            st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_1.Location = new System.Drawing.Point(2, 4);
            st_1.Size = new System.Drawing.Size(51, 16);

            // 
            // cb_import_values   = "&Import with values"
            // 
            cb_import_values.Text = "&Import with values";
            cb_import_values.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_import_values.TabIndex = 3;
            cb_import_values.Size = new System.Drawing.Size(101, 21);
            cb_import_values.Location = new System.Drawing.Point(254, 2);
            cb_import_values.Click += new EventHandler(cb_import_values_clicked);

            // 
            // cb_select_infile   == Select input file ("..." button)
            // 
            cb_select_infile.Text = "...";
            cb_select_infile.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_select_infile.TabIndex = 2;
            cb_select_infile.Location = new System.Drawing.Point(229, 2);
            cb_select_infile.Size = new System.Drawing.Size(21, 21);
            cb_select_infile.Click += new EventHandler(cb_select_infile_clicked);

            // 
            // cb_save   "&Save"
            // 
            cb_save.Text = "&Save";
            cb_save.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_save.TabIndex = 6;
            cb_save.Location = new System.Drawing.Point(417, 360);
            cb_save.Size = new System.Drawing.Size(52, 21);
            cb_save.Click += new EventHandler(cb_save_clicked);

            // 
            // cb_import_novalues   "&Import without values"
            // 
            cb_import_novalues.Text = "&Import without values";
            cb_import_novalues.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_import_novalues.TabIndex = 4;
            cb_import_novalues.Location = new System.Drawing.Point(358, 2);
            cb_import_novalues.Size = new System.Drawing.Size(110, 21);
            cb_import_novalues.Click += new EventHandler(cb_import_novalues_clicked);

            // 
            // cb_cancel   "&Cancel"
            // 
            cb_cancel.Text = "&Cancel";
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_cancel.TabIndex = 7;
            cb_cancel.Location = new System.Drawing.Point(345, 360);
            cb_cancel.Size = new System.Drawing.Size(52, 21);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);

            // 
            // dw_errors
            // 
            dw_errors.Left = 662;
            dw_errors.Size = new System.Drawing.Size(433, 144);
            dw_errors.Visible = false;

            // 
            // p_abort
            // 
            p_abort.TabStop = false;
            p_abort.Image = global::NZPostOffice.Shared.Properties.Resources.ABORTPRV;
            p_abort.Location = new System.Drawing.Point(369, 5);
            p_abort.Size = new System.Drawing.Size(17, 14);
            p_abort.Visible = false;
            p_abort.Click += new EventHandler(p_abort_clicked);

            // 
            // cb_stop
            // 
            cb_stop.Text = "Sto&p";
            cb_stop.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_stop.TabIndex = 8;
            cb_stop.Location = new System.Drawing.Point(366, 2);
            cb_stop.Size = new System.Drawing.Size(65, 21);
            cb_stop.Visible = false;
            cb_stop.Click += new EventHandler(cb_stop_clicked);

            this.ResumeLayout();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Methods
        public virtual void wf_saveerror_info(int pRow, string pErrormsg)
        {
            DataEntityGrid dwchild = (DataEntityGrid)dw_1.GetControlByName("grid");
            PieceRateImportExeptionReport record = new PieceRateImportExeptionReport();
            record.Contract = dw_1.GetItem<PieceRateImport>(pRow).Contract;
            record.PrdDate = dw_1.GetItem<PieceRateImport>(pRow).PrdDate;
            record.PrtCode = dw_1.GetItem<PieceRateImport>(pRow).PrtCode;
            record.PrdQuantity = dw_1.GetItem<PieceRateImport>(pRow).PrdQuantity;
            record.PrdCost = dw_1.GetItem<PieceRateImport>(pRow).PrdCost;
            record.ContractNo = dw_1.GetItem<PieceRateImport>(pRow).ContractNo;
            record.PrtKey = dw_1.GetItem<PieceRateImport>(pRow).PrtKey;
            record.PrdRdCost = dw_1.GetItem<PieceRateImport>(pRow).PrdRdCost;
            record.PrtDescription = dwchild.Rows[pRow].Cells["prt_key"].FormattedValue.ToString();
            record.Errormsg = pErrormsg;
            dw_errorsList.Insert(0, record);
        }

        public virtual bool wf_checkdate(int pRow, DateTime pToday)
        {   // Validate the contract date
            // If valid
            //    Return TRUE
            // If invalid
            //    Return FALSE
            //    Add record to ErrorList
            //    (but do not delete - done by calling routine)

            DateTime thisPrdDate;

            thisPrdDate = (DateTime)dw_1.DataObject.GetItem<PieceRateImport>(pRow).PrdDate;
            if ( thisPrdDate > pToday )
            {
                wf_saveerror_info( pRow, "Invalid date" );
                return false;
            }
            return true;
        }

        public virtual bool wf_check_contract(int pRow)
        {   // Validate the contract number
            // Save the number (as a number) in ContractNo
            // If valid
            //    Return TRUE
            // If invalid
            //    Return FALSE
            //    Add record to ErrorList
            //    (but do not delete - done by calling routine)

            string sMSNumber;
            int lContract;
            int lCount;
            int SQLCode = 0;

            sMSNumber = dw_1.DataObject.GetItem<PieceRateImport>(pRow).Contract;
            if ( ! int.TryParse(sMSNumber, out lContract) )
            {
                // select contract_no into :lContract from contract where con_old_mail_service_no = :sMSNumber;
                lContract = RDSDataService.GetContractNo(sMSNumber);
            }
            // select count(*) into :lCount from contract where contract_no = :lContract;
            lCount = RDSDataService.GetContractCount(lContract, ref SQLCode);
            if (SQLCode == 0 && lCount > 0)
            {
                dw_1.DataObject.GetItem<PieceRateImport>(pRow).ContractNo = lContract;
            }
            else
            {
                dw_1.DataObject.GetItem<PieceRateImport>(pRow).ContractNo = -1;
                wf_saveerror_info(pRow, "Contract not found on database");
                return false;
            }
            return true;
        }

        public virtual bool wf_check_duplicate(int pRow, int pContractNo, string pPrtCode, DateTime? pPrdDate)
        {   // Check for duplicate records.  Parameters contain previous record's values.
            // MUST follow checkdate routine which sets the ContractNo value 
            //     (otherwise throws an unhandled exception)
            // If valid
            //    Return TRUE
            // If invalid
            //    Return FALSE
            //    Add record to ErrorList
            //    (but do not delete - done by calling routine)

            string thisPrtCode;
            int thisContractNo;
            DateTime? thisPrdDate;

            thisContractNo = (int)dw_1.DataObject.GetItem<PieceRateImport>(pRow).ContractNo;
            thisPrtCode = dw_1.DataObject.GetItem<PieceRateImport>(pRow).PrtCode;
            thisPrdDate = dw_1.DataObject.GetItem<PieceRateImport>(pRow).PrdDate;
            if (( thisContractNo == pContractNo
                 && thisPrtCode == pPrtCode
                 && thisPrdDate == pPrdDate) )
            {
                wf_saveerror_info(pRow, "Duplicate data row (contract, date, prt_code)");
                return false;
            }
            return true;
        }

        public virtual bool wf_check_piece_rate(int pRow)
        {   // Validate the piecerate
            // Set the PrtKey value for the record
            // Save the number (as a number) in ContractNo
            // If valid
            //    Return TRUE
            // If invalid
            //    Return FALSE
            //    Add record to ErrorList
            //    (but do not delete - done by calling routine)

            string thisPrtCode;
            int thisPrtKey;
            int SQLCode = 0;

            thisPrtCode = dw_1.DataObject.GetItem<PieceRateImport>(pRow).PrtCode;

            // select prt_key into :lPRKey from piece_rate_type where prt_code = :sPRCode;
            thisPrtKey = RDSDataService.GetPrtKey(thisPrtCode, ref SQLCode);
            if (SQLCode == 0)
            {
                dw_1.SetValue(pRow, "prt_key", thisPrtKey);
            }
            else
            {
                wf_saveerror_info( pRow, "Piece rate key for " + thisPrtCode + "not found on database" );
                return false;
            }
            return true;
        }

        public virtual bool wf_confirm_rate(int pRow)
        {   // Validate the piecerate cost
            // Assumes the PrtKey value for the record has been set (in wf_check_piece_rate)
            // Save the pr_rate in PrdRdCost
            // If valid
            //    Return TRUE
            // If invalid
            //    Return FALSE
            //    Add record to ErrorList
            //    (but do not delete - done by calling routine)

            int thisContractNo;
            DateTime thisPrdDate;
            Decimal? thisPrRate;
            Decimal? thisPrdCost;
            Decimal? thisTotalcost;
            int thisPrtKey;
            int thisCount = int.MinValue;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            thisContractNo = (int)dw_1.DataObject.GetItem<PieceRateImport>(pRow).ContractNo;
            thisPrdCost = dw_1.DataObject.GetItem<PieceRateImport>(pRow).PrdCost;
            thisPrtKey = (int)dw_1.DataObject.GetItem<PieceRateImport>(pRow).PrtKey;
            thisPrdDate = (DateTime)dw_1.DataObject.GetItem<PieceRateImport>(pRow).PrdDate;
            RDSDataService dataService = RDSDataService.GetContractList(
                                                     thisPrtKey, 
                                                     thisContractNo, 
                                                     thisPrdDate, 
                                                     ref SQLCode, 
                                                     ref SQLErrText);
            List<ContractItem> list = dataService.ContractItemList;
            thisPrRate = 0;
            if (list != null && list.Count > 0)
            {
                thisPrRate = list[0].Pr_rate;
            }
            if (SQLCode == 0)
            {
                dw_1.DataObject.GetItem<PieceRateImport>(pRow).PrdRdCost = thisPrRate;

                // Totalcost is a derived value, depending on the PrRdCost (= _prd_quantity * _prd_rd_cost)
                // Don't reference it till the PrRdCost has been set.
                thisTotalcost = dw_1.DataObject.GetItem<PieceRateImport>(pRow).Totalcost;

                // select count(prt_key) into :lCount from piece_rate_delivery where contract_no = :lContract and prt_key = :lPRKey and prd_date= :dPRDDate;
                thisCount = RDSDataService.GetPieceRateDeliveryCount( thisContractNo, 
                                                                      thisPrtKey, 
                                                                      thisPrdDate);

                // if lCount>0 then
                if (!(StaticFunctions.f_nempty(thisCount)))
                {
                    // sErrormsg = "A piece rate for this contract on this date has already been defined on the database";
                    wf_saveerror_info(pRow, "Piece rate already defined on database");
                    return false;
                }
                else if (thisPrdCost != null
                         && Decimal.Round((Decimal)thisPrdCost.Value,2) 
                                               != Decimal.Round(thisTotalcost.Value, 2)
                         && ! (StaticFunctions.f_nempty(thisPrRate)))
                {
                    if (isIgnoreWrongRates == "UNDEF")
                    {
                        isIgnoreWrongRates = "YES";
                        DialogResult answer = MessageBox.Show(
                                                 "Piece Rate costs have been found that do not match the rates defined for this contract.\n\n"
                                                + "Do you want to write them to another file for later processing?"
                                                , this.Text
                                                , MessageBoxButtons.YesNo
                                                , MessageBoxIcon.Question);
                        if (answer == DialogResult.Yes)
                        {
                            isIgnoreWrongRates = "NO";
                        }
                    }
                    if (isIgnoreWrongRates == "NO")
                    {
                        // sErrormsg = "Piece Rate cost does not match the rates defined for this contract.";
                        wf_saveerror_info(pRow, "Piece Rate cost does not match");
                        return false;
                    }
                }
            }
            else
            {
                //sErrormsg = "Piece rate type does not have a rate defined for this contract";
                wf_saveerror_info(pRow, "Piece rate not defined");
                return false;
            }
            return true;
        }

        public virtual bool wf_calculate_cost(int pRow)
        {
            // TJB  RPCR_054  June-2013
            // Rewritten and renamed (was wf_calculate_rate)
            // Most of the original duplicated work done in wf_check_piece_rate
            // This gets rid of the extraneous stuff (and is MUCH simpler)
            //
            // Checks the piece rate and displays the cost
            //
            // Assumes the prt_key value has been set in PrtKey
            // and the pr_rate value has been set in PrRdCost (in wf_check_piece_rate)
            // If everything is as expected
            //    Put the calculated prd_cost in PrdCost (for display)
            //    Return TRUE
            // If pr_rate was not found (PrRdCost is null)
            //    Return FALSE
            //    Add record to ErrorList
            //    (but do not delete - done by calling routine)

            int thisPrdQuantity;
            decimal thisPrdCost;
            decimal? thisPrdRdCost;
            decimal? thisTotalcost;

            thisPrdRdCost = dw_1.DataObject.GetItem<PieceRateImport>(pRow).PrdRdCost;
            thisTotalcost = dw_1.DataObject.GetItem<PieceRateImport>(pRow).Totalcost;
            thisPrdQuantity = (int)dw_1.DataObject.GetItem<PieceRateImport>(pRow).PrdQuantity;

            if (thisPrdRdCost == null)
            {
                wf_saveerror_info(pRow, "Prd_cost not determined");
                return false;
            }

            // Calculate the cost (this has already been calculated and saved in Totalcost)
            thisPrdCost = thisPrdQuantity * (decimal)thisPrdRdCost;
            // Display the answer on the dw_1
            dw_1.DataObject.GetItem<PieceRateImport>(pRow).PrdCost = thisPrdCost;

            return true;
        }

        //pp! using private function as the performance deteriorates severely if function from URdsDw is used
        private int SaveErrorFile(string filename, string saveastype)
        {
            int nErrorRows;
            DateTime prdDate;
            //((DPieceRateImportExeptionReport)(dw_errors.DataObject)).Retrieve(dw_errorsList);

            nErrorRows = dw_errors.RowCount;
            if (nErrorRows > 0)
            {
                //        MessageBox.Show( nErrorRows + " errors found.\n"
                //                       + "Please select a file to save the error records to."
                //                       , "Import Error"
                //                       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    SaveFileDialog savedlg = new SaveFileDialog();
                    savedlg.Filter = "Text (*.txt) |*.txt";
                    savedlg.DefaultExt = saveastype;
                    if (filename.Length > 0)
                    {
                        savedlg.FileName = filename;
                    }
                    if (savedlg.ShowDialog() == DialogResult.OK)
                    {
                        filename = savedlg.FileName.Trim();
                    }
                    else
                    {
                        return -1;
                    }

                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename))
                    {
                        int row;
                        char sep = '\t';       // set separator charatcer

                        // Extract the list elements in reverse order - this writes them to the file
                        // in the order they were added to the list (and so match the input file order).
                        //for (r = (nErrorRows - 1); r >= 0; r--)
                        nErrorRows = nErrorRows - 1;
                        for (row = 0; row <= nErrorRows; row++)
                        {
                            //!dw_errors.DataObject.GetItem<PieceRateImportExeptionReport>(r); 
                            PieceRateImportExeptionReport current = 
                                 dw_errors.DataObject.GetItem<PieceRateImportExeptionReport>(row); 

                            sw.Write(this.ValidateExportValue(current.Contract));
                            sw.Write(sep);
                            //sw.Write(this.ValidateExportValue(current.PrdDate));
                            prdDate = (DateTime)current.PrdDate;
                            sw.Write(prdDate.ToString("dd/MM/yyyy"));
                            sw.Write(sep);
                            sw.Write(this.ValidateExportValue(current.PrtCode));
                            sw.Write(sep);
                            sw.Write(this.ValidateExportValue(current.PrdQuantity));
                            sw.Write(sep);
                            sw.Write(this.ValidateExportValue(current.PrdCost));
                            sw.Write(sep);
                            sw.Write(this.ValidateExportValue(current.PrdRdCost));
                            sw.Write(sep);
                            sw.Write(this.ValidateExportValue(current.PrtKey));
                            sw.Write(sep);
                            sw.Write(this.ValidateExportValue(current.ContractNo));
                            sw.Write(sep);
                            sw.Write(this.ValidateExportValue(current.Errormsg));

                            //!if (r != dw_errors.DataObject.RowCount - 1)
                            if (row < nErrorRows)
                            {
                                sw.Write("\r\n");
                            }
                        }
                        if (sw != null)
                        {
                            sw.Close();
                        }
                    }
                    // return dw_errorsList.Count;
                    return (nErrorRows + 1);
                }
                catch
                {
                    return -1;
                }
            }
            return 0;
        }

        private string ValidateExportValue(object value)
        {
            System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("[,\"\\t\\r\\n]");
            if (value == null)
                return "";
            else if (!(value is string))
                return value.ToString();
            else
            {
                if (rx.Match((string)value).Success)
                    return '"' + ((string)value).Replace("\"", "\"\"") + '"';
                else
                    return (string)value;
            }
        }

        private bool filterWithEmptystring(PieceRateImport item)
        {
            return true;
        }

        private bool dw_1_filter(PieceRateImport t)
        {if (t.PrdDate > DateTime.Today)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual int wf_dump_records(string pMsg)
        {    // List current records in dw_1
             // TJB  22-Jul-2009 testing

            int nRows;
            string sData = String.Empty;
            string sFilter = String.Empty;

            sFilter = dw_1.DataObject.FilterString;
            nRows = dw_1.RowCount;
            for (int i = 0; i < nRows; i++)
            {
                sData = sData + "Row " + i;
                PieceRateImport current = dw_1.DataObject.GetItem<PieceRateImport>(i);
                sData = sData + ": " + current.Contract
                              + ", " + ((DateTime)current.PrdDate).ToString("dd/MM/yyyy")
                              + ", " + current.PrtCode
                              + ", " + current.PrdQuantity
                              + ", " + current.PrdCost
                              + ", " + current.PrtKey
                              + "\n";
            }
            MessageBox.Show( pMsg + "\n"
                           + nRows + " Rows found\n"
                           + "Filter = " + sFilter + "\n"
                           + sData
                           , "dw_1 dump"
                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
            return nRows;
        }

        public virtual void post_yield()
        {
            cb_import_values.Enabled = true;
            cb_select_infile.Enabled = true;
            dw_1.Enabled = true;
            cb_save.Enabled = true;
            dw_errors.Enabled = true;
            sle_1.Enabled = true;
            st_1.Enabled = true;
            st_label.Enabled = true;
            p_abort.Visible = false;
            return;
        }

        public virtual void dw_errors_constructor()
        {
            dw_errors.of_SetUpdateable(false);
        }

        #endregion

        #region Events
        public virtual void cb_import_values_clicked(object sender, EventArgs e)
        {                 // Import with values
            string inFilename;

            // dw_1.InsertItem<PieceRateImport>(0);
            dw_1.DataObject.Reset();

            inFilename = sle_1.Text;
            if (inFilename == "")
            {
                MessageBox.Show("Please select a file to import"
                              , "Import"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Cursor.Current = Cursors.WaitCursor;

            int rc = ImportFile(inFilename);
            if (rc < 0)
            {
                MessageBox.Show("Error " + rc + " encountered reading input file.\n"
                               , "Input error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dw_1.RowCount <= 0 
                || dw_1.DataObject.GetItem<PieceRateImport>(0).PrdCost == null)
            {
                MessageBox.Show("You cannot import because there are no values!"
                               , "Import with values"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Reset();
                return;
            }
            wf_process_input();
        }

        public virtual void cb_select_infile_clicked(object sender, EventArgs e)
        {       // Select input file
            string sFileName = string.Empty;
            string sDirectory = string.Empty;
            //GetFileOpenName("Select the import file", sFileName, sDirectory, "txt", "Tab Delimited Files,*.TXT,dBase III Files,*.DBF");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tab Delimited Files|*.TXT|dBase III Files|*.DBF";
            openFileDialog.Title = "Select the import file";
            openFileDialog.DefaultExt = "txt";
            openFileDialog.InitialDirectory = sDirectory;
            openFileDialog.FileName = sFileName;
            openFileDialog.ShowDialog();
            sFileName = openFileDialog.FileName;

            sle_1.Text = sFileName;
        }

        public virtual void cb_save_clicked(object sender, EventArgs e)
        {      // Save
            dw_1.Save();
            //?commit;
            MessageBox.Show("The piece rate information has been saved to the database"
                           , base.Text
                           , MessageBoxButtons.OK, MessageBoxIcon.Information);

            ib_disableclosequery = true;
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {     // Cancel
            ib_disableclosequery = true;
            this.Close();
        }

        public virtual void p_abort_clicked(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Do you want to stop processing?"
                                                 , base.Text
                                                 , MessageBoxButtons.YesNo
                                                 , MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                post_yield();
            }
        }

        public virtual void cb_stop_clicked(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Do you want to stop processing?"
                                                 , base.Text
                                                 , MessageBoxButtons.YesNo
                                                 , MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                post_yield();
            }
        }

        public virtual void cb_import_novalues_clicked(object sender, EventArgs e)
        {   // Import without values - tjb version
            string inFilename;

            //            dw_1.InsertItem<PieceRateImport>(0);
            dw_1.DataObject.Reset();

            inFilename = sle_1.Text;
            if (inFilename == "")
            {
                MessageBox.Show("Please select a file to import"
                              , "Import"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            inFilename = sle_1.Text;
            int rc = ImportFile(inFilename);
            if (rc < 0)
            {
                MessageBox.Show("Error " + rc + " encountered reading input file.\n"
                               , "Input error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dw_1.RowCount > 0 
                && dw_1.DataObject.GetItem<PieceRateImport>(0).PrdCost != null)
            {
                MessageBox.Show("You cannot import because there are values!"
                              , "Import without values"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Reset();
                return;
            }
            wf_process_input();
        }

        public virtual void wf_process_input()
        {   // Import without values - tjb version
            int nRows, nRow;
            string sFileName = string.Empty;
            DateTime dToday = DateTime.Today;
            int prevContractNo;
            string prevPrtCode;
            DateTime prevPrdDate;
            int nErrors = 0;
            int nData = 0;
            bool delRow = false;
            string inFilename, outFilenameDefault;

            inFilename = sle_1.Text;

            // Reset all 3 datawindows.
            dw_errors.DataObject.Reset();
            dw_errorsList.Clear();

            //  TWC - fix for 4511 - need to re-set the sort criteria before sorting again
            dw_1.DataObject.SortString = "Contract A, PrdDate A, PrtCode A";
            dw_1.DataObject.Sort<PieceRateImport>();
          //      wf_dump_records("cb_import_novalues_clicked: before calling checkdates");
          //      int nDateErrors = wf_checkdates();
          //      wf_dump_records("cb_import_novalues_clicked: Starting");
            isIgnoreWrongRates = "UNDEF";
            nRows = dw_1.RowCount;
            if (nRows > 0)
            {
                // Scan each input record, applying various validations
                // for (lRow = lRowCount - 1; lRow >= 0; lRow -= 1)
                // We do the loop this way because the number of rows (nRows) may decrease
                // as we delete faulty records.
                string errName = "";
                prevContractNo = 0;
                prevPrtCode    = "";
                prevPrdDate    = DateTime.MinValue;
                nRow = 0;
                while(nRow < nRows)
                {
                    errName = "";
                    delRow = false;
                    // NOTE: These conditions are the negated condition
                    //    - the code fragments are executed only if the validation is FALSE
                    if (! wf_checkdate(nRow, dToday))
                    {
                        errName = "checkdate";
                        delRow = true;
                    }
                    else if (! wf_check_contract(nRow))
                    {
                        errName = "check_contract";
                        delRow = true;
                    }
                    else if (! wf_check_duplicate(nRow, prevContractNo, prevPrtCode, prevPrdDate))
                    {
                        errName = "check_duplicate";
                        delRow = true;
                    }
                    else if (! wf_check_piece_rate(nRow))
                    {
                        errName = "check_piece_rate";
                        delRow = true;
                    }
                    else if (! wf_confirm_rate(nRow))
                    {
                        errName = "check_confirm_rate";
                        delRow = true;
                    }
                    else if (! wf_calculate_cost(nRow))
                    {
                        errName = "check_calculate_cost";
                        delRow = true;
                    }
                    if (delRow)
                    {
                        dw_1.DeleteItemAt(nRow);
                            // If we've deleted a row, the number of rows is less and
                            // the current row number points to the next unprocessed row.
                        nRows = dw_1.RowCount;
                    }
                    else
                    {
                        // If we haven't deleted a row
                        // Save some of the current processed row's data to use to
                        // check the next record to see if it a duplicate.  If the current row 
                        // was deleted, ignore it - - we only look for duplicate good records.
                        prevContractNo = (int)dw_1.DataObject.GetItem<PieceRateImport>(nRow).ContractNo;
                        prevPrtCode = dw_1.DataObject.GetItem<PieceRateImport>(nRow).PrtCode;
                        prevPrdDate = (DateTime)dw_1.DataObject.GetItem<PieceRateImport>(nRow).PrdDate;
                        // If we haven't deleted a row, the number of rows is th same and
                        // we increment the row number to the next unprocessed row.
                        nRow++;
                    }
                }  // End record-scanning loop
            }
            nErrors = dw_errorsList.Count;
            nData = dw_1.RowCount;
            if (nInputRecords != (nErrors + nData))
            {
                MessageBox.Show("Incorrect number of records after validation.\n"
                             + "   " + nInputRecords + " records input.\n"
                             + "   " + nErrors + " error records found.\n"
                             + "   " + nData + " records validated.\n"
                             , "WARNING"
                             , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (nErrors == 0)
            {
                PieceRateImportExeptionReport newError = new PieceRateImportExeptionReport();
                newError.Errormsg = "No errors found in import file";
                dw_errorsList.Insert(0, newError);
            }
            ((DPieceRateImportExeptionReport)(dw_errors.DataObject)).Retrieve(dw_errorsList);
            dw_errors.DataObject.SortString = "Contract A, PrdDate A, PrtCode A";
            dw_errors.DataObject.Sort<PieceRateImportExeptionReport>();
            if (nErrors > 0)
            {
                MessageBox.Show(nErrors + " Errors encountered.  Saving error records.\n"
                             + "Please select a file to save the faulty records to."
                             , ""
                             , MessageBoxButtons.OK, MessageBoxIcon.Information);
                int i = inFilename.LastIndexOf('.');
                outFilenameDefault = inFilename.Substring(0,i) + "-errors";
                this.SaveErrorFile(outFilenameDefault, "text");
            }
            DialogResult answer;
            string errcountmsg;
            if (nErrors == 0)
            {
                errcountmsg = "No errors encountered.";
            }
            else
            {
                errcountmsg = ((nErrors == 1) ? "1 error" : nErrors + " errors") + " encountered.";
            }
            answer = MessageBox.Show(errcountmsg + "\n\n"
                         + "Do you want to print the error report?"
                         , ""
                         , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                ((DPieceRateImportExeptionReport)dw_errors.DataObject).Print();
            }
            post_yield();
            cb_stop.Visible = false;
            p_abort.Visible = false;
        }
        #endregion

        #region Code added by John Mao
        private char[] separator = new char[] { '\t', ',' };

        private void UpdateStatusText(int current, int total)
        {
            ((NZPostOffice.RDS.Windows.Ruralwin.WMainMdi)StaticVariables.MainMDI).toolStripStatusLabel1.Text = 
                string.Format("Processing row {0} of {1}", current + 1, total);
            Application.DoEvents();
        }
        // Data Import
        private int ImportFile(string path)
        {
            nInputRecords = 0;
            if (!string.IsNullOrEmpty(path))
            {
                #region open the stream
                StreamReader sr;
                try
                {
                    sr = new StreamReader(path);
                }
                catch (ArgumentException)
                {
                    return -3;
                }
                catch (DirectoryNotFoundException)
                {
                    return -5;
                }
                catch (FileNotFoundException)
                {
                    return -5;
                }
                catch (IOException)
                {
                    return -7;
                }
                catch (Exception)
                {
                    return -4;
                }
                #endregion

                #region populate the buffer
                List<string> buffer = new List<string>();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    buffer.Add(line);
                    nInputRecords++;
                }
                sr.Close();
                #endregion

                for (int i = 0; i < buffer.Count; i++)
                {
                    UpdateStatusText(i, buffer.Count);
                    dw_1.DataObject.AddItem<PieceRateImport>(ParseStringToPieceRateImport(buffer[i]));
                }
                dw_1.DataObject.Refresh();
                return dw_1.RowCount;
            }
            else
            {
                return -8;
            }
        }

        private PieceRateImport ParseStringToPieceRateImport(string text)
        {   // TJB  22-Jul-2009: added comment about expected input format
            // Format expected:
            //    Contract    (contract_no as a string)
            //    PrdDate     (date in dd/mm/yyyy format)
            //    PrtCode     (string)
            //    PrdQuantity (int)
            //    PrdCost     (decimal)
            PieceRateImport item = new PieceRateImport();
            text = text.Replace("\"", "");
            text = text.Replace("\'", "");

            string[] fields = text.Split(separator);
            for (int i = 0; i < fields.Length; i++)
            {
                string s = fields[i];
                switch (i)
                {
                    case 0:
                        item.Contract = s;
                        break;
                    case 1:
                        DateTime dt;
                        if(DateTime.TryParse(s, out dt))
                        {
                            item.PrdDate = dt;
                        }
                        break;
                    case 2:
                        item.PrtCode = s;
                        break;
                    case 3:
                        int n;
                        if (int.TryParse(s, out n))
                        {
                            item.PrdQuantity = n;
                        }
                        break;
                    case 4:
                        decimal d;
                        if(decimal.TryParse(s, out d))
                        {
                            item.PrdCost = d;
                        }
                        break;
                }
            }
            return item;
        }
        #endregion
    }
}
