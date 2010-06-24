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
using NZPostOffice.RDS.DataControls.Report;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WEclDataImport : WAncestorWindow
    {
        #region Define

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public struct EclImportError
        {
            public string EclTicketNo;
            public string EclTicketPart;
            public string EclCustomerName;
            public string EclCustomerCode;
            public string EclSeq;
            public string EclDriverId;
            public string EclRateCode;
            public string EclRateDescr;
            public string EclPkgDescr;
            public string EclBatchId;
            public string EclRunID;
            public string EclRunNo;
            public DateTime? EclDriverDate;
            public string EclDateEntered;
            public string EclTicketPayable;
            public string EclRuralPayable;
            public string EclScanCount;
            public string EclSigReqFlag;
            public string EclSigCaptured;
            public string EclSigName;
            public string EclPrCode;
            public string ErrorValue;
            public string ErrorMsgText;
        }
        
        public struct EclImportText
        {
            public int    nEclBatchNo;
            public string sEclTicketNo;
            public string sEclTicketPart;
            public string sEclCustomerName;
            public string sEclCustomerCode;
            public string sEclSeq;
            public string sEclDriverId;
            public string sEclRateCode;
            public string sEclRateDescr;
            public string sEclPkgDescr;
            public string sEclBatchId;
            public string sEclRunID;
            public string sEclRunNo;
            public DateTime? dEclDriverDate;
            public string sEclDateEntered;
            public string sEclTicketPayable;
            public string sEclRuralPayable;
            public string sEclScanCount;
            public string sEclSigReqFlag;
            public string sEclSigCaptured;
            public string sEclSigName;
            public string sEclPrCode;
        }

        public List<EclImportError> ecl_import_error_list;

        public List<EclImportText> ecl_import_data_list;

        public List<EclQualityMappingItem> ecl_quality_mappings_list;
        public List<EclOldBatchItem> ecl_old_batch_list;

        public URdsDw dw_import;

        //public URdsDw dw_import_errors;
        public EclImportError [] ecl_import_errors;
        public string ecl_import_header;

        public TextBox sle_1;

        public Label st_1;

        public Button cb_import;

        public Button cb_select;

        public Button cb_upload;

        public Button cb_insert;

        public Button cb_close;

        public Button cb_stop;

        //public URdsDw dw_errors;

        public List<EclDataImportExeptionReport> dw_errorsList = new List<EclDataImportExeptionReport>();

        public string isIgnoreWrongRates = "UNDEF";
        private Label label1;
        private MaskedTextBox tb_batch_no;
        public int nImportedRecords;
        public int nImportedErrors;
        public int currentBatchNo = 0;
        string sBlankLine = "                              \n";
        string sTopLine = "---------------------------------------\n\n";
        private Label st_status;
        string sBottomLine = "\n\n---------------------------------------";

        #endregion

        public WEclDataImport()
        {
            this.InitializeComponent();

            dw_import.DataObject = new DEclDataImport();
            //dw_errors.DataObject = new DEclDataImportExeptionReport();
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
            this.of_set_componentname("ECL Data Import");
            // Tell security that the user must have national access (Own region=National)
            this.of_set_nationalaccess(true);
        }
        //added by jlwang for implement menu
        public override void pfc_postopen()
        {
            int l_batchNo;
            int SQLCode = 0;
            string SQLErrText = "";

            // The 'current' batch number is the newest one that has been loaded but not inserted
            currentBatchNo = l_batchNo = RDSDataService.GetECLUploadHistoryCurrentBatchNo(ref SQLCode, ref SQLErrText);
            if ((l_batchNo == 0))
            {
                // If there is no current batch, get the next one
                currentBatchNo = l_batchNo = RDSDataService.GetECLUploadHistoryNextBatchNo(ref SQLCode, ref SQLErrText);
            }

            RDSDataService dataService = RDSDataService.GetEclQualityMappings(
                                         ref SQLCode,
                                         ref SQLErrText);
            if (SQLCode != 0)
            {
                MessageBox.Show("Error getting the quality mappings.\n"
                                + "SQLCode = " + SQLCode.ToString() + "\n"
                                + SQLErrText
                                , "ERROR: pfc_postOpen");
            }
            ecl_quality_mappings_list = dataService.EclQualityMappingsList;

            //?base.pfc_postopen();
            dw_import.URdsDw_GetFocus(new object(), new EventArgs());
            tb_batch_no.Text = currentBatchNo.ToString();

            cb_upload.Visible = true;
            cb_insert.Visible = true;
            cb_stop.Visible = false;
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dw_import = new NZPostOffice.RDS.Controls.URdsDw();
            this.sle_1 = new System.Windows.Forms.TextBox();
            this.st_1 = new System.Windows.Forms.Label();
            this.cb_import = new System.Windows.Forms.Button();
            this.cb_select = new System.Windows.Forms.Button();
            this.cb_upload = new System.Windows.Forms.Button();
            this.cb_insert = new System.Windows.Forms.Button();
            this.cb_close = new System.Windows.Forms.Button();
            this.cb_stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_batch_no = new System.Windows.Forms.MaskedTextBox();
            this.st_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(3, 367);
            this.st_label.Size = new System.Drawing.Size(132, 21);
            this.st_label.Text = "wEclDataImport";
            // 
            // dw_import
            // 
            this.dw_import.DataObject = null;
            this.dw_import.FireConstructor = false;
            this.dw_import.Location = new System.Drawing.Point(3, 30);
            this.dw_import.Name = "dw_import";
            this.dw_import.Size = new System.Drawing.Size(653, 325);
            this.dw_import.TabIndex = 5;
            // 
            // sle_1
            // 
            this.sle_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sle_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sle_1.Location = new System.Drawing.Point(53, 3);
            this.sle_1.Name = "sle_1";
            this.sle_1.Size = new System.Drawing.Size(174, 20);
            this.sle_1.TabIndex = 1;
            // 
            // st_1
            // 
            this.st_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_1.Location = new System.Drawing.Point(2, 4);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(51, 16);
            this.st_1.TabIndex = 6;
            this.st_1.Text = "Filename";
            this.st_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb_import
            // 
            this.cb_import.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_import.Location = new System.Drawing.Point(254, 2);
            this.cb_import.Name = "cb_import";
            this.cb_import.Size = new System.Drawing.Size(59, 21);
            this.cb_import.TabIndex = 3;
            this.cb_import.Text = "&Import";
            this.cb_import.Click += new System.EventHandler(this.cb_import_clicked);
            // 
            // cb_select
            // 
            this.cb_select.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_select.Location = new System.Drawing.Point(229, 2);
            this.cb_select.Name = "cb_select";
            this.cb_select.Size = new System.Drawing.Size(21, 21);
            this.cb_select.TabIndex = 2;
            this.cb_select.Text = "...";
            this.cb_select.Click += new System.EventHandler(this.cb_select_clicked);
            // 
            // cb_upload
            // 
            this.cb_upload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_upload.Location = new System.Drawing.Point(319, 2);
            this.cb_upload.Name = "cb_upload";
            this.cb_upload.Size = new System.Drawing.Size(52, 21);
            this.cb_upload.TabIndex = 6;
            this.cb_upload.Text = "&Load";
            this.cb_upload.Click += new System.EventHandler(this.cb_upload_clicked);
            // 
            // cb_insert
            // 
            this.cb_insert.Enabled = false;
            this.cb_insert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_insert.Location = new System.Drawing.Point(377, 2);
            this.cb_insert.Name = "cb_insert";
            this.cb_insert.Size = new System.Drawing.Size(52, 21);
            this.cb_insert.TabIndex = 4;
            this.cb_insert.Text = "I&nsert";
            this.cb_insert.Click += new System.EventHandler(this.cb_insert_clicked);
            // 
            // cb_close
            // 
            this.cb_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_close.Location = new System.Drawing.Point(604, 361);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(52, 21);
            this.cb_close.TabIndex = 7;
            this.cb_close.Text = "&Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            // 
            // cb_stop
            // 
            this.cb_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_stop.Font = new System.Drawing.Font("Arial", 8F);
            this.cb_stop.Location = new System.Drawing.Point(543, 361);
            this.cb_stop.Name = "cb_stop";
            this.cb_stop.Size = new System.Drawing.Size(52, 21);
            this.cb_stop.TabIndex = 8;
            this.cb_stop.Text = "Sto&p";
            this.cb_stop.Click += new System.EventHandler(this.cb_stop_clicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(485, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Batch No";
            // 
            // tb_batch_no
            // 
            this.tb_batch_no.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.tb_batch_no.HidePromptOnLeave = true;
            this.tb_batch_no.Location = new System.Drawing.Point(543, 4);
            this.tb_batch_no.Mask = "#####";
            this.tb_batch_no.Name = "tb_batch_no";
            this.tb_batch_no.Size = new System.Drawing.Size(100, 20);
            this.tb_batch_no.TabIndex = 11;
            this.tb_batch_no.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.tb_batch_no.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.tb_batch_no_MaskInputRejected);
            this.tb_batch_no.Leave += new System.EventHandler(this.tb_batch_no_Leave);
            // 
            // st_status
            // 
            this.st_status.Location = new System.Drawing.Point(141, 361);
            this.st_status.Name = "st_status";
            this.st_status.Size = new System.Drawing.Size(353, 23);
            this.st_status.TabIndex = 12;
            this.st_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WEclDataImport
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(665, 386);
            this.Controls.Add(this.tb_batch_no);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.st_status);
            this.Controls.Add(this.dw_import);
            this.Controls.Add(this.sle_1);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.cb_import);
            this.Controls.Add(this.cb_select);
            this.Controls.Add(this.cb_upload);
            this.Controls.Add(this.cb_insert);
            this.Controls.Add(this.cb_close);
            this.Controls.Add(this.cb_stop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WEclDataImport";
            this.Text = "ECL Data Import";
            this.Controls.SetChildIndex(this.cb_stop, 0);
            this.Controls.SetChildIndex(this.cb_close, 0);
            this.Controls.SetChildIndex(this.cb_insert, 0);
            this.Controls.SetChildIndex(this.cb_upload, 0);
            this.Controls.SetChildIndex(this.cb_select, 0);
            this.Controls.SetChildIndex(this.cb_import, 0);
            this.Controls.SetChildIndex(this.st_1, 0);
            this.Controls.SetChildIndex(this.sle_1, 0);
            this.Controls.SetChildIndex(this.dw_import, 0);
            this.Controls.SetChildIndex(this.st_status, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tb_batch_no, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

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
/*
            DataEntityGrid dwchild = (DataEntityGrid)dw_import.GetControlByName("grid");
            EclDataImportExeptionReport record = new EclDataImportExeptionReport();

            record.Contract = dw_import.GetItem<EclDataImport>(pRow).Contract;
            record.PrdDate = dw_import.GetItem<EclDataImport>(pRow).PrdDate;
            record.PrtCode = dw_import.GetItem<EclDataImport>(pRow).PrtCode;
            record.PrdQuantity = dw_import.GetItem<EclDataImport>(pRow).PrdQuantity;
            record.PrdCost = dw_import.GetItem<EclDataImport>(pRow).PrdCost;
            record.ContractNo = dw_import.GetItem<EclDataImport>(pRow).ContractNo;
            record.PrtKey = dw_import.GetItem<EclDataImport>(pRow).PrtKey;
            record.PrdRdCost = dw_import.GetItem<EclDataImport>(pRow).PrdRdCost;
            record.PrtDescription = dwchild.Rows[pRow].Cells["prt_key"].FormattedValue.ToString();

            record.Errormsg = pErrormsg;
            dw_errorsList.Insert(0, record);
*/
        }

        //pp! using private function as the performance deteriorates severely if function from URdsDw is used
        private int SaveErrorFile(string filename, string saveastype, int nErrors)
        {
            int nOut;
            string sBuffer;
            DateTime dtDriverDate, dtDateEntered;
            string sDriverDate, sDateEntered;
            string sErrmsg, t;
            char sep = '\t';       // set separator character
            string sDateFmt = "yyyy-MM-dd HH:mm:ssss";

            nOut = ecl_import_error_list.Count;
            if (nErrors > 0)
            {
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
                }
                catch( Exception e)
                {
                    sErrmsg = e.Message;
                    t = sErrmsg;
                    return -1;
                }

                try
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename))
                    {
                        // Write out the header saved from the input file
                        sw.Write("Error Text" + sep + "Error Value" + sep + ecl_import_header + "\r\n");

                        // Extract the list elements in reverse order - this writes them to the file
                        // in the order they were added to the list (and so match the input file order).
                        for (nOut = 0; nOut < nErrors; nOut++)
                        {
                            sDriverDate = null;
                            sDateEntered = null;
                            dtDriverDate = (DateTime)ecl_import_error_list[nOut].EclDriverDate;
                            if (dtDriverDate != null)
                            {
                                sDriverDate = dtDriverDate.ToString(sDateFmt);
                            }
                            sDateEntered = ecl_import_error_list[nOut].EclDateEntered;
                            //dtDateEntered = (DateTime)ecl_import_error_list[nOut].EclDateEntered;
                            //if (dtDateEntered != null)
                            //{
                            //    sDateEntered = dtDateEntered.ToString(sDateFmt);
                            //}

                            sBuffer = ecl_import_error_list[nOut].ErrorMsgText + sep
                                         + ecl_import_error_list[nOut].ErrorValue + sep
                                         + ecl_import_error_list[nOut].EclCustomerName + sep
                                         + ecl_import_error_list[nOut].EclCustomerCode.ToString() + sep
                                         + ecl_import_error_list[nOut].EclTicketNo + sep
                                         + ecl_import_error_list[nOut].EclTicketPart + sep
                                         + ecl_import_error_list[nOut].EclSeq.ToString() + sep
                                         + ecl_import_error_list[nOut].EclDriverId.ToString() + sep
                                         + ecl_import_error_list[nOut].EclRateCode.ToString() + sep
                                         + ecl_import_error_list[nOut].EclRateDescr + sep
                                         + ecl_import_error_list[nOut].EclPkgDescr + sep
                                         + ecl_import_error_list[nOut].EclBatchId.ToString() + sep
                                         + ecl_import_error_list[nOut].EclRunID.ToString() + sep
                                         + ecl_import_error_list[nOut].EclRunNo + sep
                                         + sDriverDate + sep
                                         + sDateEntered + sep
                                         + ecl_import_error_list[nOut].EclTicketPayable + sep
                                         + ecl_import_error_list[nOut].EclRuralPayable + sep
                                         + ecl_import_error_list[nOut].EclScanCount.ToString() + sep
                                         + ecl_import_error_list[nOut].EclSigReqFlag + sep
                                         + ecl_import_error_list[nOut].EclSigCaptured + sep
                                         + ecl_import_error_list[nOut].EclSigName + sep
                                         + ecl_import_error_list[nOut].EclPrCode;
                            ;
                            sw.Write(sBuffer);
                            sw.Write("\r\n");
                        }
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch( Exception e)
                {
                    sErrmsg = e.Message;
                    t = sErrmsg;
                    return -1;
                }
                // Return the number of lines output.  
                // nOut will = nError; add 1 for the header
                return (nOut + 1);
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

        private bool filterWithEmptystring(EclDataImport item)
        {
            return true;
        }

        private bool dw_import_filter(EclDataImport t)
        {
            return true;
        }

        public virtual int wf_dump_records(string pMsg)
        {    // List current records in dw_import
             // TJB  22-Jul-2009 testing

            int nRows;
            string sData = String.Empty;
            string sFilter = String.Empty;

            sFilter = dw_import.DataObject.FilterString;
            nRows = dw_import.RowCount;
/*
            for (int i = 0; i < nRows; i++)
            {
                sData = sData + "Row " + i;
                EclDataImport current = dw_import.DataObject.GetItem<EclDataImport>(i);
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
                           , "dw_import dump"
                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
*/
            return nRows;
        }

        public virtual void post_yield()
        {
            cb_import.Enabled = true;
            cb_select.Enabled = true;
            dw_import.Enabled = true;
            cb_upload.Enabled = true;
            //dw_errors.Enabled = true;
            sle_1.Enabled = true;
            st_1.Enabled = true;
            st_label.Enabled = true;
            //cb_stop.Enabled = false;
            //cb_stop.Visible = false;
            return;
        }
/*
        public virtual void dw_errors_constructor()
        {
            dw_errors.of_SetUpdateable(false);
        }
*/
        #endregion

        #region Events
        public virtual void cb_import_clicked(object sender, EventArgs e)
        {
            // Import raw data from selected file into dw_import.  This is
            // done in the ImportFile routine.
            // The data is then quality-checked in the wf_process_input routine 
            // with errors reported and saved to an error file.
            //
            // Subsequently, the user can upload the data to a staging table 
            // in the database (cb_upload_clicked - button marked "Save").  When
            // all elements of the batch have been imported and uploaded 
            // (including errors corrected), the batch can be "Inserted"
            // (cb_insert_clicked).
            int nBatchNo = 0;
            string inFilename;

            UpdateStatusText("");

            //dw_import.InsertItem<EclDataImport>(0);
            dw_import.DataObject.Reset();
            //ecl_import_errors = new EclImportError[20];
            ecl_import_error_list = new List<EclImportError>();
            ecl_import_data_list = new List<EclImportText>();

            if (!getBatchNo(ref nBatchNo))
                return;

            inFilename = sle_1.Text;
            if (inFilename == "")
            {
                MessageBox.Show(sTopLine
                               + "Please select a file to import"
                               + sBottomLine
                               , "ECL Data Import"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cb_stop.Visible = true;
            was_cb_stop_clicked = false;
            Cursor.Current = Cursors.WaitCursor;

            DateTime dtStartImport = DateTime.Now;

            int rc = ImportFile(inFilename, nBatchNo);
            //int rc = ImportFileAsText(inFilename, nBatchNo);

            if (rc < 0)
            {
                MessageBox.Show(sTopLine
                               + "Error " + rc + " encountered reading input file."
                               + sBottomLine
                               , "ECL Data Import: Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (rc == 1)
            {
                cb_stop.Visible = false;
                return;
            }
            DateTime dtEndImport = DateTime.Now;
            TimeSpan tsTimeImport = dtEndImport.Subtract(dtStartImport);
            string sTimeImport = tsToString(tsTimeImport);
            AppendStatusText("  In " + sTimeImport);

            int nImportedRows = dw_import.RowCount;
            //nImportedRows = 0;          // Testing import times
            if (nImportedRows <= 0)
            {
                MessageBox.Show(sTopLine
                               + "You cannot import because there are no values!"
                               + sBottomLine
                               , "ECL Data Import"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_import.DataObject.Reset();
                return;
            }

            wf_process_input(dtStartImport);
        }

        public virtual void cb_select_clicked(object sender, EventArgs e)
        {       // Select input file
            string sFileName = string.Empty;
            string sDirectory = string.Empty;

            // Clear the datawindow
            dw_import.DataObject.Reset();

            UpdateStatusText("");

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

        public bool getBatchNo(ref int pBatchNo)
        {
            int n;
            if (int.TryParse(tb_batch_no.Text, out n))
            {
                pBatchNo = n;
            }
            else
            {
                MessageBox.Show(sTopLine
                              + "Invalid batch number - must be a simple integer."
                              + sBottomLine
                              , "ECL Data Processing: Warning"
                              , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public virtual void cb_upload_clicked(object sender, EventArgs e)
        {   // Save
            bool RC;
            int rc=0;
            int lBatchNo=0;
            int nUploadRows;
            DateTime dtDateUploaded;
            int sqlCode=0;
            string sqlErrText="";

            string firstTicketNo;
            string firstTicketPart;

            UpdateStatusText("");

            if (!getBatchNo(ref lBatchNo))
                return;

            if (was_cb_stop_clicked)
            {
                MessageBox.Show("The previous import was stopped before it finished.\n"
                                + "Only completed imports can be loaded."
                                , "Warning");
                return;
            }

            string inFilename = sle_1.Text;
            int i = inFilename.LastIndexOf('\\');
            inFilename = inFilename.Substring(i + 1);

            //dtDateUploaded = DateTime.Today;
            dtDateUploaded = DateTime.Now;
            nUploadRows = dw_import.RowCount;
            if (nUploadRows > 0)
            {
                firstTicketNo = dw_import.DataObject.GetItem<EclDataImport>(0).EclTicketNo;
                firstTicketPart = dw_import.DataObject.GetItem<EclDataImport>(0).EclTicketPart;
                RC = RDSDataService.IsDuplicateECLUploadData( firstTicketNo, firstTicketPart
                                                      , ref sqlCode, ref sqlErrText);
                if (sqlCode != 0)
                {
                    MessageBox.Show("Error checking for already-uploaded data\n"
                        + "  Sql Code = " + sqlCode.ToString() + "\n"
                        + "  Sql Text = " + sqlErrText
                        , "ECL Data Upload: Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (RC)
                {
                    MessageBox.Show(sTopLine 
                                   + "This data appears to have already been loaded!\n\n"
                                   + "File  " + inFilename + "\n"
                                   + "Not saved."
                                   + sBottomLine
                                   , "ECL Data Upload: Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show(sTopLine 
                               + "No data to upload?"
                               + "File  " + inFilename + "\n"
                               + sBottomLine
                               , "ECL Data Upload: Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime dtStartUpload = DateTime.Now;
            UpdateStatusText("Uploading data - please wait");

            rc = wf_UploadData();
            int nUploadedRows = Math.Abs(rc);
            //rc = dw_import.Save();

            DateTime dtEndUpload = DateTime.Now;
            TimeSpan tsUploadTime = dtEndUpload.Subtract(dtStartUpload);
            string sUploadTime = tsToString(tsUploadTime);
            string sMessage = "Uploaded " + nUploadedRows.ToString() + " records in " + sUploadTime;
            UpdateStatusText(sMessage);

            sMessage = nUploadedRows.ToString();
            if (nUploadedRows < nUploadRows)
                sMessage += " of " + nUploadRows.ToString();
            string sUploadStatus = "";
            if (rc < 0) sUploadStatus = " with errors";
            UpdateStatusText("");
            //?commit;
            MessageBox.Show(sTopLine
                           + "The ECL data has been saved to the database" + sUploadStatus + ".\n"
                           + "    Batch " + lBatchNo.ToString() + "\n"
                           + "    File  " + inFilename + "\n"
                           + "    " + sMessage + " records\n"
                           + "    Upload time: " + sUploadTime
                           + sBottomLine
                           , "ECL Data Upload"
                           , MessageBoxButtons.OK, MessageBoxIcon.Information);

            RC = RDSDataService.InsertIntoECLUploadHistory(lBatchNo, dtDateUploaded
                                                    , nUploadRows, nImportedErrors
                                                    , inFilename 
                                                    , ref sqlCode, ref sqlErrText);
            if (sqlCode != 0)
            {
                MessageBox.Show("Error inserting record into the ECL upload history table\n"
                               + "  Sql Code = " + sqlCode.ToString() + "\n"
                               + "  Sql Text = " + sqlErrText
                               , "ECL Data Upload: Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ib_disableclosequery = true;
            //this.Close();
        }
        private int stringToInt(string s)
        {
            int n;
            if (int.TryParse(s, out n))
            {
                return n;
            }
            return 0;
        }

        private string tsToString(TimeSpan ts)
        {
            int HH = ts.Hours;
            int MM = ts.Minutes;
            int SS = ts.Seconds;
            return HH.ToString("00:") + MM.ToString("00:") + SS.ToString("00");
        }

        private DateTime stringToDate(string s)
        {
            DateTime dt;
            if (DateTime.TryParse(s, out dt))
            {
                return dt;
            }
            return DateTime.MinValue;
        }

        private int wf_UploadData()
        {
            int nRows;
            int nSqlCode = 0;
            string sSqlError = "";
            NZPostOffice.RDS.DataService.EclImportData ImportItem = new NZPostOffice.RDS.DataService.EclImportData();
            //EclDataImport ImportItem = new EclDataImport();

            nRows = dw_import.RowCount;
            for (int nRow = 0; nRow < nRows; nRow++)
            {
                // Update the number of records processed periodically
                if (((nRow % 100) == 0))
                {
                    UpdateStatusText("Uploading data", nRow, nRows);
                    if (was_cb_stop_clicked)
                    {
                        AppendStatusText(" - Stopped");
                        return nRow;
                    }
                }

                ImportItem.EclBatchNo = dw_import.DataObject.GetItem<EclDataImport>(0).EclBatchNo;
                ImportItem.EclTicketNo = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclTicketNo;
                ImportItem.EclTicketPart = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclTicketPart;
                ImportItem.EclCustomerName = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclCustomerName;
                ImportItem.EclCustomerCode = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclCustomerCode;
                ImportItem.EclSeq = stringToInt(dw_import.DataObject.GetItem<EclDataImport>(nRow).EclSeq);
                ImportItem.EclDriverId = stringToInt(dw_import.DataObject.GetItem<EclDataImport>(nRow).EclDriverId);
                ImportItem.EclRateCode = stringToInt(dw_import.DataObject.GetItem<EclDataImport>(nRow).EclRateCode);
                ImportItem.EclRateDescr = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclRateDescr;
                ImportItem.EclPkgDescr = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclPkgDescr;
                ImportItem.EclBatchId = stringToInt(dw_import.DataObject.GetItem<EclDataImport>(nRow).EclBatchId);
                ImportItem.EclRunID = stringToInt(dw_import.DataObject.GetItem<EclDataImport>(nRow).EclRunID);
                ImportItem.EclRunNo = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclRunNo;
                ImportItem.EclDriverDate = (DateTime)dw_import.DataObject.GetItem<EclDataImport>(nRow).EclDriverDate;
                ImportItem.EclDateEntered = stringToDate(dw_import.DataObject.GetItem<EclDataImport>(nRow).EclDateEntered);
                ImportItem.EclTicketPayable = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclTicketPayable;
                ImportItem.EclRuralPayable = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclRuralPayable;
                ImportItem.EclScanCount = stringToInt(dw_import.DataObject.GetItem<EclDataImport>(nRow).EclScanCount);
                ImportItem.EclSigReqFlag = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclSigReqFlag;
                ImportItem.EclSigCaptured = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclSigCaptured;
                ImportItem.EclSigName = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclSigName;
                ImportItem.EclPrCode = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclPrCode;
                ImportItem.EclRo5Flag = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclRo5Flag;
                ImportItem.EclEffectiveDate = (DateTime)dw_import.DataObject.GetItem<EclDataImport>(nRow).EclEffectiveDate;

                RDSDataService.InsertIntoECLUploadData(ImportItem, ref nSqlCode, ref sSqlError);

                if (nSqlCode != 0)
                {
                    MessageBox.Show("Error uploading row " + nRow.ToString() + "\n"
                                    + sSqlError + "\n"
                                    , "Error"
                                    );
                    return (nRow * -1);
                }
            }
            return nRows;
        }

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {     // Close
            UpdateStatusText("");
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

        private bool was_cb_stop_clicked = false;
        public virtual void cb_stop_clicked(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Do you want to stop processing?"
                                                 , base.Text
                                                 , MessageBoxButtons.YesNo
                                                 , MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                was_cb_stop_clicked = true;
                //post_yield();
            }
        }

        public virtual void cb_insert_clicked(object sender, EventArgs e)
        {   // Insert loaded values
            int lBatchNo=0;
            int nBatch, nRecords, nErrors;
            int sqlCode = 0;
            string sqlErrText = "";

            UpdateStatusText("");

            if (!getBatchNo(ref lBatchNo))
                return;

            string sBatchNo = "Batch " + lBatchNo.ToString();
            nBatch = RDSDataService.GetECLUploadedBatchSize( lBatchNo, ref sqlCode, ref sqlErrText);
            if (sqlCode != 0)
            {
                MessageBox.Show("Error checking" + lBatchNo.ToString() + " for records to insert\n"
                               + "  Sql Code = " + sqlCode.ToString() + "\n"
                               + "  Sql Text = " + sqlErrText
                               , "ECL Data Insert: Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (nBatch == -2)
            {
                MessageBox.Show(sTopLine
                               + sBatchNo + " does not exist."
                               + sBottomLine
                               , "ECL Data Insert: Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (nBatch == -1)
            {
                MessageBox.Show(sTopLine 
                               + sBatchNo + " has already been inserted."
                               + sBottomLine
                               , "ECL Data Insert: Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (nBatch == 0)
            {
                MessageBox.Show(sTopLine
                               + sBatchNo + " has no records to insert?"
                               + sBottomLine
                               , "ECL Data Insert: Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DateTime dtStartInsert = DateTime.Now;
            UpdateStatusText("Inserting " + sBatchNo + " - please wait");
            nRecords = RDSDataService.sp_ECLInsertData(lBatchNo, ref sqlCode, ref sqlErrText);
            DateTime dtEndInsert = DateTime.Now;
            TimeSpan tsInsertTime = dtEndInsert.Subtract(dtStartInsert);
            string sInsertTime = tsToString(tsInsertTime);
            UpdateStatusText("");
            //nErrors = nBatch - nRecords;
            if (sqlCode != 0)
            {
                MessageBox.Show("Error inserting batch" + lBatchNo.ToString() + " \n"
                               + "  Sql Code = " + sqlCode.ToString() + "\n"
                               + "  Sql Text = " + sqlErrText
                               , "ECL Data Insert: Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (nRecords > 0)
            {
                MessageBox.Show(sTopLine
                               + sBatchNo + " processed.\n"
                               + " \n"
                               + "    " + nBatch.ToString() + " records in batch.\n"
                               + "    " + nRecords.ToString() + " summarised records inserted.\n"
                               + "    Insert time: " + sInsertTime
                               + sBottomLine
                               , "ECL Data Insert"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (nRecords == 0)
            {
                MessageBox.Show(sTopLine
                               + sBatchNo + " processed.\n"
                               + " \n"
                               + "    " + nBatch.ToString() + " records in batch.\n"
                               + "    " + "No records inserted.\n"
                               + sBottomLine
                               , "ECL Data Insert: Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (nRecords < 0)
            {
                MessageBox.Show(sTopLine
                               + sBatchNo + " has already been processed."
                               + sBottomLine
                               , "ECL Data Insert: Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Update the batch no 
            lBatchNo++;
            tb_batch_no.Text = lBatchNo.ToString();

            // Check to see if there are any batches past their archive date
            DateTime dtArchiveDate = DateTime.Today.AddMonths(-13);
            RDSDataService dataservice = RDSDataService.GetECLUploadHistoryOldBatchNos(dtArchiveDate, ref sqlCode, ref sqlErrText);
            if (sqlCode < 0)
            {
                MessageBox.Show(sTopLine 
                                + "Error checking for batches past their archive date.\n" 
                                + sqlErrText
                                + sBottomLine
                                , "Error");
                return;
            }
            ecl_old_batch_list = dataservice.EclOldBatchList;
            string s_old_batch_list = "";
            int i = 0, nBatchNo;
            for (i = 0; i < ecl_old_batch_list.Count; i++)
            {
                s_old_batch_list += "   " + ecl_old_batch_list[i].Batch_No.ToString() + "     "
                                    + ecl_old_batch_list[i].Date_Inserted.ToShortDateString()
                                    + "\n";
            }
            DialogResult answer = MessageBox.Show(sTopLine
                            + "Archive date = " + dtArchiveDate.ToShortDateString() + "\n"
                            + "These batches have passed their archive date (13 months ago)\n"
                            + s_old_batch_list + "\n"
                            + "Do you want to archive them now?\n"
                            + sBottomLine
                            , "Question"
                            , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                for (i = 0; i < ecl_old_batch_list.Count; i++)
                {
                    nBatchNo = ecl_old_batch_list[i].Batch_No;
                    RDSDataService.sp_ECLPurgeBatch( nBatchNo, ref sqlCode, ref sqlErrText);
                    
                    if (sqlCode < 0)
                    {
                        MessageBox.Show(sTopLine 
                                        + "Error purging batch " + nBatchNo.ToString() + ".\n" 
                                        + sqlErrText
                                        + sBottomLine
                                        , "Error");
                        break;
                    }
                    MessageBox.Show(sTopLine 
                                    + "Batch " + nBatchNo.ToString() + " purged.\n" 
                                    + sBottomLine
                                    , "");
                }
            }
        }

        private bool wf_blankFields(int pRow, ref string pErrName)
        {
            // Check for blank fields
            // Return TRUE if any found, and message passed back in pErrName
            // Otherwise, return FALSE
            //
            // Exceptions
            //    Batch ID may be blank
            //    SigName msy be blank
            //    Piece Rate Code may be blank in some cases (checked separately

            EclDataImport item = dw_import.DataObject.GetItem<EclDataImport>(pRow);
            if (item.EclCustomerName.Length == 0)
            {
                pErrName += "Blank Customer Name";
                return true;
            }
            if (item.EclCustomerCode.Length == 0)
            {
                pErrName += "Blank Customer Code";
                return true;
            }
            if (item.EclTicketNo.Length == 0)
            {
                pErrName += "Blank Ticket Number";
                return true;
            }
            if (item.EclTicketPart.Length == 0)
            {
                pErrName += "Blank Ticket Part";
                return true;
            }
            if (item.EclSeq.Length == 0)
            {
                pErrName += "Blank Sequence";
                return true;
            }
            if (item.EclDriverId.Length == 0)
            {
                pErrName += "Blank Driver ID";
                return true;
            }
            if (item.EclRateCode.Length == 0)
            {
                pErrName += "Blank ECL Rate Code";
                return true;
            }
            if (item.EclRateDescr.Length == 0)
            {
                pErrName += "Blank Rate Description";
                return true;
            }
            //if (item.EclPkgDescr.Length == 0)
            //{
            //    pErrName += "Blank Product Description";
            //    return true;
            //}
            if (item.EclRunID.Length == 0)
            {
                pErrName += "Blank Run ID";
                return true;
            }
            if (item.EclRunNo.Length == 0)
            {
                pErrName += "Blank Ticket Part";
                return true;
            }
            if (!item.EclDriverDate.HasValue)
            {
                pErrName += "Blank Driver Date";
                return true;
            }
            if (item.EclDateEntered.Length == 0)
            {
                pErrName += "Blank Date Entered";
                return true;
            };
            if (item.EclTicketPayable.Length == 0)
            {
                pErrName += "Blank Ticket Payable";
                return true;
            }
            if (item.EclRuralPayable.Length == 0)
            {
                pErrName += "Blank Rural Payable";
                return true;
            }
            if (item.EclScanCount.Length == 0)
            {
                pErrName += "Blank Scan Count";
                return true;
            }
            if (item.EclSigReqFlag.Length == 0)
            {
                pErrName += "Blank Signature Required";
                return true;
            }
            if (item.EclSigCaptured.Length == 0)
            {
                pErrName += "Blank Signature Captured";
                return true;
            }
            return false;
        }

        private bool wf_MatchMapping(string pColName, string pMatchString)
        {
            // Match the pMatchString against the mapping file strings
            // for pColName.
            // 
            // Returns
            //    true    If pMatchString matches a mapping value
            //    false   otherwise

            string sThisColName = "";
            string sThisMatchString = "";
            string sThisMatchType = "";
            for (int i = 0; i < ecl_quality_mappings_list.Count; i++)
            {
                sThisColName = ecl_quality_mappings_list[i].Column_name;
                if (sThisColName == pColName)
                {
                    sThisMatchString = ecl_quality_mappings_list[i].Match_string;
                    sThisMatchType = ecl_quality_mappings_list[i].Match_type;
                    if (sThisMatchType == "S")
                    {
                        if (pMatchString.StartsWith(sThisMatchString))
                            return true;
                    }
                    else if (sThisMatchType == "C")
                    {
                        if (pMatchString.Contains(sThisMatchString))
                            return true;
                    }
                    else if (sThisMatchType == "E")
                    {
                        if (pMatchString.EndsWith(sThisMatchString))
                            return true;
                    }
                    else if (sThisMatchType == "M")
                    {
                        if (pMatchString.Equals(sThisMatchString))
                            return true;
                    }
                }
            }
            return false;      // No match
        }

        private bool wf_ValidPrCode(string pRateDescr)
        {
            // If EclPrCode is blank, check the Rate Description.
            // 
            // Returns
            //    true    If the Rate Description matches a specified value
            //    false   otherwise

            return wf_MatchMapping("ecl_rate_descr", pRateDescr);
        }

        private bool wf_ValidCust(string pCustomerName)
        {
            // If the ScanCount is > 2, sometimes this is OK.
            //
            // Return
            //   true    If the Customer Name is "DHL%", it is OK
            //   false   Otherwise the Scan Count is invalid

            return wf_MatchMapping("ecl_customer_name", pCustomerName);
        }

        public virtual bool wf_is_duplicate(int pRow, string pPrevTicketNo, string pPrevTicketPart)
        {   // Check for duplicate records.  Parameters contain previous record's values.
            // Return true if the previous ticket number and part are the same as this ticket's
            // A separate routine determines which of the two is to be kept  

            if (pPrevTicketNo == dw_import.DataObject.GetItem<EclDataImport>(pRow).EclTicketNo
                && pPrevTicketPart == dw_import.DataObject.GetItem<EclDataImport>(pRow).EclTicketPart)
            {
                return true;
            }
            return false;
        }

        private bool wf_Check_RO5_Eligibility(string pEclSigName)
        {
            // If ecl_sig_req _flag is "SIG REQ", we checj to see if a signiture has been 
            // recorded.  A valid signiture is any non-blank string (a blank signiture is 
            // currently [June 2010] treated as valid due to a bug in the supplier's system)
            // that isn't a "No Signiture Obtained" equivalent.
            //
            // Returns
            //    true    if the signiture is valid
            //    false   otherwise
            //
            // NOTE: This returns the reverse of some other matches because
            //       the mapping strings are equivalents of "No Signiture Obtained"

            return (! wf_MatchMapping("ecl_sig_name", pEclSigName));
        }

        public virtual int wf_select_invalid(int pRow)
        {
            // Select duplicate row to reject
            //Called when record pRow - 1 matches record pRow (matched by wf_is_duplicate)
            // Returns
            //    1    Previous record (pRow - 1) is rejected
            //    2    Current record (pRow) is rejected
            int prevRow = pRow - 1;

            // If either the SigName of the previous or current record are empty, 
            // that record is invalid (if both are empty, we flag the current record)
            string sThisSigName = dw_import.DataObject.GetItem<EclDataImport>(pRow).EclSigName;
            if (sThisSigName.Length == 0)
                return 2;
            string sPrevSigName = dw_import.DataObject.GetItem<EclDataImport>(prevRow).EclSigName;
            if (sPrevSigName.Length == 0)
                return 1;
            // If neither is empty ...

            // If either the TicketPayable flag of the previous or current record is "N", 
            // that record is invalid (if both are "N", we flag the current record)
            string sThisTicketPayable = dw_import.DataObject.GetItem<EclDataImport>(pRow).EclTicketPayable;
            if (sThisTicketPayable == "N")
                return 2;
            string sPrevTicketPayable = dw_import.DataObject.GetItem<EclDataImport>(prevRow).EclTicketPayable;
            if (sPrevTicketPayable == "N")
                return 1;
            // If neither is "N" ...

            // We keep the record with the earliest Driver Date.  Since the records 
            // were sorted in Driver Date order, the "Previous" record will either be
            // dated earlier than the current one, or the same.  Reject the current one.
            return 2;
        }

        private int wf_quality_check_input(int pRow, string pPrevTicketNo, string pPrevTicketPart, ref string pErrValue, ref string pErrName)
        {
            // Do "Quality checking" - validate input data
            int n;

            // Skip any with EclRuralPayable == "N"
            string sRuralPayable = dw_import.DataObject.GetItem<EclDataImport>(pRow).EclRuralPayable;
            if (sRuralPayable == "N")
            {
                pErrName += "Rural payable=N";
                return 1;          // Skip this row
            }
            if (wf_blankFields(pRow, ref pErrName))
            {
                // If any fields are blank (that aren't supposed to be) the
                // errName is populated by the checking routine, which then
                // returns TRUE.
                return 2;
            }
            string sPrCode = dw_import.DataObject.GetItem<EclDataImport>(pRow).EclPrCode;
            string sRateDescr = dw_import.DataObject.GetItem<EclDataImport>(pRow).EclRateDescr;
            if (sPrCode.Length == 0)
            {
                // If the PrCode is blank, the Rate Description is used to determine the
                // appropriate value.  Otherwise an error is raised.
                if (sPrCode.Length == 0)
                {
                    //if (wf_ValidPrCode(sRateDescr))
                    if(wf_MatchMapping("ecl_rate_descr", sRateDescr))
                    {
                        return 0;
                    }
                    else
                    {
                        int len = sRateDescr.Length;
                        if (len == 0)
                        {
                            pErrValue = "Rate Descr empty";
                        }
                        else
                        {
                            len = (len > 10) ? 10 : len;
                            pErrValue = "Rate Descr: " + sRateDescr.Substring(0,len);
                        }
                    }
                    pErrName = "Blank Piece Rate Code";
                    return 2;
                }
            }
            //int nScanCount = (int)dw_import.DataObject.GetItem<EclDataImport>(pRow).EclScanCount;
            string sScanCount = dw_import.DataObject.GetItem<EclDataImport>(pRow).EclScanCount;
            int nScanCount = int.TryParse( sScanCount, out n ) ? n : 0;
            if (nScanCount != 1)
            {
                // If the Scan Count is 0, or doesn't match a specified customer name 
                // (eg the customer name doesn't start with "DHL"), this is an error.
                string sCustomerName = dw_import.DataObject.GetItem<EclDataImport>(pRow).EclCustomerName;
                //if (nScanCount == 0 || (! wf_ValidCust(sCustomerName)))
                if (nScanCount == 0 || (! wf_MatchMapping("ecl_customer_name", sCustomerName)))
                {
                    int len = sCustomerName.Length;
                    if (len > 1)
                    {
                        len = (len > 10) ? 10 : len;
                        pErrValue = sScanCount + " - Cust: " + sCustomerName.Substring(0, len);
                    }
                    else
                    {
                        pErrValue = sScanCount + " - Cust name empty";
                    }
                    pErrName += "Invalid Scan Count";
                    return 2;
                }
            }
            string sThisTicketNo = dw_import.DataObject.GetItem<EclDataImport>(pRow).EclTicketNo;
            string sThisTicketPart = dw_import.DataObject.GetItem<EclDataImport>(pRow).EclTicketPart;
            if (pPrevTicketNo == sThisTicketNo
                && pPrevTicketPart == sThisTicketPart)
            {
                // Check for duplicate records.
                // Return true if the previous ticket number and part are the same as this ticket's
                // A separate routine determines which of the two is to be kept  
                pErrName += "Duplicate ticket";
                return wf_select_invalid(pRow);
            }
            string sSigReqFlag = dw_import.DataObject.GetItem<EclDataImport>(pRow).EclSigReqFlag;
            string sSigName = dw_import.DataObject.GetItem<EclDataImport>(pRow).EclSigName;
            if (sSigReqFlag == "SIG REQ" && sThisTicketPart == "D")
            {
                //if (wf_Check_RO5_Eligibility(sSigName))
                if(! wf_MatchMapping("ecl_sig_name", sSigName.Trim().ToUpper()))
                {
                    dw_import.DataObject.GetItem<EclDataImport>(pRow).EclRo5Flag = "Y";
                }
                else
                    dw_import.DataObject.GetItem<EclDataImport>(pRow).EclRo5Flag = "N";
            }
            else
            {
                dw_import.DataObject.GetItem<EclDataImport>(pRow).EclRo5Flag = "N";
            }
            return 0;
        }

        public virtual void wf_process_input(DateTime pStartImport)
        {
            // This routine does input data quality checking following importation 
            // of the raw data from the input file.
            int tRows, nRows, nRow;
            string sFileName = string.Empty;
            DateTime dToday = DateTime.Today;
            string sErrValue = string.Empty;
            string sErrName = string.Empty;
            string sLastErrName = string.Empty;
            string sPrevTicketNo = string.Empty;
            string sPrevTicketPart = string.Empty;
            int nData = 0;
            //bool delRow = false;
            int delRow = 0;  // 1 = delete prev; 2 = delete this
            string inFilename, outFilenameDefault;
            DialogResult answer;
            int nImportedSkipped;

            DateTime dtStartSort = DateTime.Now;
            DateTime dtStartProcess;
            DateTime dtEndProcess;

            inFilename = sle_1.Text;

            // NOTE: Duplicates are identified as having the same EclTicketNo and EclTicketPart
            //       Where duplicates are encountered, in general, the earliest (EclDriverDate) 
            //       may be used.
            dw_import.DataObject.SortString = "EclTicketNo A, EclTicketPart A, EclDriverDate A";
            dw_import.DataObject.Sort<EclDataImport>();

            dtStartProcess = DateTime.Now;

            sPrevTicketNo = "";
            sPrevTicketPart = "";
            nImportedErrors  = 0;
            nImportedSkipped = 0;
            nImportedRecords = dw_import.RowCount;
            nRows = dw_import.RowCount;
            tRows = dw_import.RowCount;   // Remember how many we started with
            if (nRows > 0)
            {
                // Scan each input record, applying various validations
                //for (lRow = lRowCount - 1; lRow >= 0; lRow -= 1)
                // We do the loop this way because the number of rows (nRows) may decrease
                // as we delete faulty records.
                nRow = 0;
                while(nRow < nRows)
                {
                    delRow = 0;             // The row is OK
                    sErrValue = sErrName = "";
                    if (((nRow % 100) == 0))
                    {
                        UpdateStatusText("Processing", nRow, tRows, nImportedErrors);
                        if (was_cb_stop_clicked)
                        {
                            AppendStatusText(" - Stopped");
                            return;
                        }
                    }
                    delRow = wf_quality_check_input(nRow, sPrevTicketNo, sPrevTicketPart, ref sErrValue, ref sErrName);

                    if (delRow == 1)   // Skip this row
                    {
                        nImportedSkipped++;
                        dw_import.DeleteItemAt(nRow);
                        // If we've deleted a row, the number of rows is less and
                        // the current row number points to the next unprocessed row.
                        nRows = dw_import.RowCount;
                    }
                    else if (delRow > 0)  // Error in this row
                    {
                        //ecl_import_errors[nImportedErrors] = CopyEclDataImportItem(dw_import.DataObject.GetItem<EclDataImport>(nRow));
                        ecl_import_error_list.Add(CopyEclDataImportItem(dw_import.DataObject.GetItem<EclDataImport>(nRow), sErrValue, sErrName));

                        nImportedErrors++;
                        dw_import.DeleteItemAt(nRow);
                        // If we've deleted a row, the number of rows is less and
                        // the current row number points to the next unprocessed row.
                        nRows = dw_import.RowCount;
                        sLastErrName = sErrName;
                    }
                    else
                    {
                        // If we haven't deleted a row
                        // Save some of the current processed row's data to use to
                        // check the next record to see if it a duplicate.  If the current row 
                        // was deleted, ignore it - we only look for duplicate good records.

                        sPrevTicketNo = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclTicketNo;
                        sPrevTicketPart = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclTicketPart;
                        // Increment the row number to the next unprocessed row.
                        nRow++;
                    }
                }  // End record-scanning loop
                UpdateStatusText("Processed", nRow, nRows, nImportedErrors);
                dtEndProcess = DateTime.Now;
                TimeSpan tsProcessTime = dtEndProcess.Subtract(dtStartProcess);
                string sProcessTime = tsToString(tsProcessTime);
                AppendStatusText( "  In " + sProcessTime);

            }
            cb_stop.Visible = false;
            //nImportedErrors = dw_errorsList.Count;
            nData = dw_import.RowCount;
            if (nImportedRecords != (nImportedErrors + nImportedSkipped + nData))
            {
                MessageBox.Show(sTopLine
                               + "Incorrect number of records after validation.\n"
                               + "   " + nImportedRecords + " records imported.\n"
                               + "   " + nImportedErrors + " error records found.\n"
                               + "   " + nImportedSkipped + " records skipped.\n"
                               + "   " + "(last) Error message: " + sLastErrName + "\n"
                               + "   " + nData + " records validated (nRows = " + nRows.ToString() + ")."
                               + sBottomLine
                               , "ECL Data Import: WARNING"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (nImportedErrors == 0)
            {
                string skippedMsg = (nImportedSkipped == 0) 
                                         ? "No records skipped.\n" 
                                         : nImportedSkipped + " records skipped.\n";
                MessageBox.Show(sTopLine
                               + nData.ToString() + " records imported,\n"
                               + "   " + "No errors encountered.\n"
                               + "   " + skippedMsg
                               + sBottomLine
                               , "ECL Data Import"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string errcountmsg;
                errcountmsg = ((nImportedErrors == 1) 
                                     ? "1 error" 
                                     : nImportedErrors + " errors") 
                              + " encountered.";
                DateTime dtNow = DateTime.Now;
                TimeSpan tsImportTime = dtStartSort.Subtract(pStartImport);
                TimeSpan tsSortTime = dtStartProcess.Subtract(dtStartSort);
                TimeSpan tsProcessTime = dtNow.Subtract(dtStartProcess);
                TimeSpan tsTotalTime = dtNow.Subtract(pStartImport);
                answer = MessageBox.Show(sTopLine
                               + nImportedRecords.ToString() + " records imported\n"
                               + "   " + nData.ToString() + " records validated\n"
                               + "   " + errcountmsg + "\n"
                               + "   " + nImportedSkipped + " records skipped.\n"
                               + "   (last) Error message: " + sLastErrName + "\n"
                               + "   Timings: \n"
                               + "      Import time  " + tsToString(tsImportTime) + "     \n"
                               + "      Sort time    " + tsToString(tsSortTime)   + "     \n"
                               + "      Process time " + tsToString(tsProcessTime)+ "     \n"
                               + "      Total time   " + tsToString(tsTotalTime)  + "     \n"
                               + "\n"
                               + "Do you want to see the error report?"
                               + sBottomLine
                               , "ECL Data Import"
                               , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (answer == DialogResult.Yes)
                {
                    StaticVariables.gnv_app.of_get_parameters().longparm = ecl_import_error_list.Count;
                    StaticMessage.PowerObjectParm = this;
                    StaticMessage.StringParm = currentBatchNo.ToString();
                    //OpenSheet<WEclDataImportExceptionReport>(StaticVariables.MainMDI);

                    WEclExceptionReport w_ecl_exception_report = new WEclExceptionReport();
                    w_ecl_exception_report.ShowDialog();
                    string test = StaticVariables.gnv_app.of_get_parameters().stringparm;
                    string t = test;
                }
                answer = DialogResult.OK;
                answer = MessageBox.Show(sTopLine
                               + "Please select a file to save the faulty records to."
                               + sBottomLine
                               , "ECL Data Import"
                               , MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (answer == DialogResult.OK)
                {
                    int i = inFilename.LastIndexOf('.');
                    outFilenameDefault = inFilename.Substring(0, i) + "-errors";
                    this.SaveErrorFile(outFilenameDefault, "text", nImportedErrors);
                }
            }
            //?w_main_mdi.SetMicroHelp("");
            //post_yield();
            //cb_stop.Visible = false;
        }
        #endregion

        private System.Data.DataTable EclErrDatatable;
        //        public List<EclImportError> ecl_import_error_list;

        private bool cr_error_datatable()
        {
            string sTicketNo = "";
            string sTicketPart = "";
            string sBatchId = "";
            string sErrorText = "";
            System.Data.DataRow r;

            EclErrDatatable = new System.Data.DataTable();
            try
            {
                EclErrDatatable.Columns.Add("EclTicketNo", Type.GetType("System.String"));
                EclErrDatatable.Columns.Add("EclTicketPart", Type.GetType("System.String"));
                EclErrDatatable.Columns.Add("EclBatchId", Type.GetType("System.String"));
                EclErrDatatable.Columns.Add("EclErrorText", Type.GetType("System.String"));

                int nRows = ecl_import_error_list.Count;
                for (int i = 0; i < nRows; i++)
                {
                    sTicketNo = ecl_import_error_list[i].EclTicketNo;
                    sTicketPart = ecl_import_error_list[i].EclTicketPart;
                    sBatchId = ecl_import_error_list[i].EclBatchId;
                    sErrorText = ecl_import_error_list[i].ErrorMsgText;

                    r = EclErrDatatable.NewRow();
                    r["EclTicketNo"] = sTicketNo;
                    r["EclTicketPart"] = sTicketPart;
                    r["EclBatchId"] = sBatchId;
                    r["EclErrorText"] = sErrorText;
                    EclErrDatatable.Rows.Add(r);
                }
                return true;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                string t = msg;
                return false;
            }
        }

        #region Code added by John Mao
        //private char[] separator = new char[] { '\t', ',' };
        private char[] separator = new char[] { '\t' };

        private void AppendStatusText(string sCaption)
        {
            ((NZPostOffice.RDS.Windows.Ruralwin.WMainMdi)StaticVariables.MainMDI).toolStripStatusLabel1.Text
                               += sCaption;
            //this.st_status.Text = sCaption;
            Application.DoEvents();
        }

        private void UpdateStatusText(string sCaption)
        {
            ((NZPostOffice.RDS.Windows.Ruralwin.WMainMdi)StaticVariables.MainMDI).toolStripStatusLabel1.Text
                               = sCaption;
            //this.st_status.Text = sCaption;
            Application.DoEvents();
        }

        private void UpdateStatusText(string sCaption, int current, int total)
        {
            ((NZPostOffice.RDS.Windows.Ruralwin.WMainMdi)StaticVariables.MainMDI).toolStripStatusLabel1.Text 
                               = string.Format("{0} row {1} of {2}", sCaption, current, total);
            //this.st_status.Text = string.Format("{0} row {1} of {2}", sCaption, current, total);
            Application.DoEvents();
        }

        private void UpdateStatusText(string sCaption, int current, int total, int nErrors)
        {
            ((NZPostOffice.RDS.Windows.Ruralwin.WMainMdi)StaticVariables.MainMDI).toolStripStatusLabel1.Text
                               = string.Format("{0} row {1} of {2} Errors {3}", sCaption, current, total, nErrors);
            //this.st_status.Text = string.Format("{0} row {1} of {2} Errors {3}", sCaption, current, total, nErrors);
            Application.DoEvents();
        }

        // Data Import
        //private int ImportFile(string path, int batch_no)
        private int ImportFile(string path, int batch_no)
        {
            nImportedRecords = 0;
            if (!string.IsNullOrEmpty(path))
            {
                int i;

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
                }
                sr.Close();
                #endregion

                //int err_count = 0;
                //string err_msg;
                // The first row (i = 0) is column headings: save them for adding to the error file (if any)
                ecl_import_header = buffer[0];

                // Check the first record to see if the batch has already been loaded
                // Do it now since the data files are very large and take a long time
                // to import.  Its better to check at the beginning than to wait.
                dw_import.DataObject.AddItem<EclDataImport>(ParseStringToEclDataImport(buffer[1], batch_no));
                nImportedRecords++;

                int sqlCode = 0;
                string sqlErrText = "";
                string firstTicketNo = dw_import.DataObject.GetItem<EclDataImport>(0).EclTicketNo;
                string firstTicketPart = dw_import.DataObject.GetItem<EclDataImport>(0).EclTicketPart;
                bool RC = RDSDataService.IsDuplicateECLUploadData(firstTicketNo, firstTicketPart
                                                      , ref sqlCode, ref sqlErrText);
                if (sqlCode != 0)
                {
                    MessageBox.Show("Error checking for already-uploaded data\n"
                        + "  Sql Code = " + sqlCode.ToString() + "\n"
                        + "  Sql Text = " + sqlErrText
                        , "ECL Data Import: Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (RC)
                {
                    DialogResult answer = MessageBox.Show(sTopLine
                                   + "This data appears to have already been loaded!\n\n"
                                   + "Do you want to continue importing the file?"
                                   + sBottomLine
                                   , "ECL Data Import: Warning"
                                   , MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (answer == DialogResult.No)
                    {
                        return 1;
                    }
                }

                dw_import.SuspendLayout();
                for (i = 2; i < buffer.Count; i++)
                {
                    // Update the number of records processed periodically
                    if (((i % 100) == 0))
                    {
                        UpdateStatusText("Importing", i, buffer.Count);
                        if (was_cb_stop_clicked)
                        {
                            AppendStatusText(" - Stopped");
                            return 1;
                        }
                        dw_import.SuspendLayout();
                    }
                    dw_import.DataObject.AddItem<EclDataImport>(ParseStringToEclDataImport(buffer[i], batch_no));
                    nImportedRecords++;

                    //err_msg = ParseStringToEclDataImport(buffer[i]);
                    //if (!string.IsNullOrEmpty(err_msg))
                    //{
                    //    err_count++;
                    //    MessageBox.Show("Row " + i.ToString() + ": \n" + err_msg
                    //                   , "ImportFile");
                    //}
                }
                UpdateStatusText("Imported", i, buffer.Count);
                dw_import.ResumeLayout();

                //dw_import.DataObject.Refresh();
                return dw_import.RowCount;
                //return err_count;
            }
            else
            {
                return -8;
            }
        }

        private int ImportFileAsText(string path, int batch_no)
        {
            int sqlCode = 0;
            string sqlErrText = "";

            nImportedRecords = 0;
            if (!string.IsNullOrEmpty(path))
            {
                int i;

                #region open the stream
                StreamReader sr;
                try
                {
                    sr = new StreamReader(path);
                }
                catch (Exception e)
                {
                    sqlErrText = e.Message;
                    MessageBox.Show("Error opening input file.\n"
                                   + sqlErrText
                                   , "ERROR: ImportFileAsText");
                    return -4;
                }
                #endregion

                #region populate the buffer
                List<string> buffer = new List<string>();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    buffer.Add(line);
                }
                sr.Close();
                #endregion

                //int err_count = 0;
                //string err_msg;
                // The first row (i = 0) is column headings: save them for adding to the error file (if any)
                ecl_import_header = buffer[0];

                for (i = 1; i < buffer.Count; i++)
                {
                    // Update the number of records processed periodically
                    if (((i % 100) == 0))
                    {
                        UpdateStatusText("Importing", i, buffer.Count);
                    }
                    ecl_import_data_list.Add(ParseStringToEclImportText(buffer[i],batch_no));
                    //dw_import.DataObject.AddItem<EclDataImport>(ParseStringToEclDataImport(buffer[i], batch_no));
                    nImportedRecords++;

                    //err_msg = ParseStringToEclDataImport(buffer[i]);
                    //if (!string.IsNullOrEmpty(err_msg))
                    //{
                    //    err_count++;
                    //    MessageBox.Show("Row " + i.ToString() + ": \n" + err_msg
                    //                   , "ImportFile");
                    //}
                }
                UpdateStatusText("Imported", i, buffer.Count);

                //dw_import.DataObject.Refresh();
                return dw_import.RowCount;
                //return err_count;
            }
            else
            {
                return -8;
            }
        }

        private EclImportError CopyEclDataImportItem(EclDataImport bad_item, string sErrorValue, string sErrorText)
        {
            // Copy a bad EclDataImport item to an EclImportError item
            // The only difference is that EclDataImport has a Batch_no field
            EclImportError item = new EclImportError();
            item.EclCustomerName = bad_item.EclCustomerName;
            item.EclCustomerCode = bad_item.EclCustomerCode;
            item.EclTicketNo = bad_item.EclTicketNo;
            item.EclTicketPart = bad_item.EclTicketPart;
            item.EclSeq = bad_item.EclSeq;
            item.EclDriverId = bad_item.EclDriverId;
            item.EclRateCode = bad_item.EclRateCode;
            item.EclRateDescr = bad_item.EclRateDescr;
            item.EclPkgDescr = bad_item.EclPkgDescr;
            item.EclBatchId = bad_item.EclBatchId;
            item.EclRunID = bad_item.EclRunID;
            item.EclRunNo = bad_item.EclRunNo;
            item.EclDriverDate = bad_item.EclDriverDate;
            item.EclDateEntered = bad_item.EclDateEntered;
            item.EclTicketPayable = bad_item.EclTicketPayable;
            item.EclRuralPayable = bad_item.EclRuralPayable;
            item.EclScanCount = bad_item.EclScanCount;
            item.EclSigReqFlag = bad_item.EclSigReqFlag;
            item.EclSigCaptured = bad_item.EclSigCaptured;
            item.EclSigName = bad_item.EclSigName;
            item.EclPrCode = bad_item.EclPrCode;
            item.ErrorValue   = sErrorValue;
            item.ErrorMsgText = sErrorText;
            return item;
        }
/*
        private EclDataImport ParseStringToEclDataImport(string text, int batch_no)
        //private string ParseStringToEclDataImport(string text)
        {
            // Fields are <tab> separated
            // Missing data represented with the string "NULL" (not <null>)
            // Ticket_number + ticket_part is a unique key
            //
            // Format expected:
            // ticket_number    varchar
            // ticket_part      char        D, P, or N
            // customer_name    varchar
            // customer_code    number
            // seq              number
            // driver_id        number
            // rate_code        number
            // rate_description varchar
            // package_desc     varchar
            // batch_entry_id   number
            // run_id           number
            // run_number       number
            // driver_date      timestamp   yyy-mm-dd hh:mm:ss.xxx
            // date_entered     timestamp   yyy-mm-dd hh:mm:ss.xxx
            // ticket_payable   char        Y or N
            // rural_payable    char        Y or N
            // scan_count       number
            // signature_flag   varchar
            // sig_captured     varchar
            // signame          varchar
            // rc_piece_rate_code   varchar

            int i, n;
            string s;
            DateTime dt;
            int err_count = 0;
            string err_msg = "";

            EclDataImport item = new EclDataImport();
            text = text.Replace("\"", "");
            text = text.Replace("\'", "");

            item.EclBatchNo = batch_no;

            string[] fields = text.Split(separator);
            for (i = 0; i < fields.Length; i++)
            {
                s = fields[i];
                err_msg = "";
                err_count = 0;

                if (s == "NULL")
                {
                    s = "";
                }
                switch (i)
                {
                    case 0:    // customer_name
                        item.EclCustomerName = s;
                        break;
                    case 1:    // customer_code
                        if (int.TryParse(s, out n))
                        {
                            item.EclCustomerCode = n;
                        }
                        else
                        {
                            err_count++;
                            err_msg = err_msg + "   customer_code = " + s + "\n";
                        }
                        break;
                    case 2:    // ticket_number
                        item.EclTicketNo = s;
                        break;
                    case 3:    // ticket_part
                        item.EclTicketPart = s;
                        break;
                    case 4:    // seq
                        if (int.TryParse(s, out n))
                        {
                            item.EclSeq = n;
                        }
                        else
                        {
                            err_count++;
                            err_msg = err_msg + "   seq = " + s + "\n";
                        }
                        break;
                    case 5:    // driver_id
                        if (int.TryParse(s, out n))
                        {
                            item.EclDriverId = n;
                        }
                        else
                        {
                            err_count++;
                            err_msg = err_msg + "   driver_id = " + s + "\n";
                        }
                        break;
                    case 6:    // rate_code
                        if (int.TryParse(s, out n))
                        {
                            item.EclRateCode = n;
                        }
                        else
                        {
                            err_count++;
                            err_msg = err_msg + "   err_count = " + s + "\n";
                        }
                        break;
                    case 7:    // rate_descr
                        item.EclRateDescr = s;
                        break;
                    case 8:    // pkg_descr
                        item.EclPkgDescr = s;
                        break;
                    case 9:    // batch_id
                        if (int.TryParse(s, out n))
                        {
                            item.EclBatchId = n;
                        }
                        else
                        {
                            err_count++;
                            err_msg = err_msg + "   batch_id = " + s + "\n";
                        }
                        break;
                    case 10:   // run_id
                        if (int.TryParse(s, out n))
                        {
                            item.EclRunID = n;
                        }
                        else
                        {
                            err_count++;
                            err_msg = err_msg + "   run_id = " + s + "\n";
                        }
                        break;
                    case 11:   // run_no
                        item.EclRunNo = s;
                        break;
                    case 12:   // driver_date
                        if (DateTime.TryParse(s, out dt))
                        {
                            item.EclDriverDate = dt;
                        }
                        else
                        {
                            err_count++;
                            err_msg = err_msg + "   driver_date = " + s + "\n";
                        }
                        break;
                    case 13:   // date_entered
                        if (DateTime.TryParse(s, out dt))
                        {
                            item.EclDateEntered = dt;
                        }
                        else
                        {
                            err_count++;
                            err_msg = err_msg + "   date_entered = " + s + "\n";
                        }
                        break;
                    case 14:   // ticket_payable
                        item.EclTicketPayable = s;
                        break;
                    case 15:   // rural_payable
                        item.EclRuralPayable = s;
                        break;
                    case 16:   // scan_count
                        if (int.TryParse(s, out n))
                        {
                            item.EclScanCount = n;
                        }
                        else
                        {
                            err_count++;
                            err_msg = err_msg + "   scan_count = " + s + "\n";
                        }
                        break;
                    case 17:   // sig_req_flag
                        item.EclSigReqFlag = s;
                        break;
                    case 18:   // sig_captured
                        item.EclSigCaptured = s;
                        break;
                    case 19:   // sig_name
                        item.EclSigName = s;
                        break;
                    case 20:   // rc_pr_code
                        item.EclPrCode = s;
                        break;
                    default:
                        err_count++;
                        err_msg = err_msg + "  Field " + i.ToString() + ": default\n";
                        break;
                }
            }
            //if (err_count < 1)
            //{
            //    err_msg = "";
            //}
            //return err_msg;
            return item;
        }
*/
        private EclDataImport ParseStringToEclDataImport(string text, int batch_no)
        //private string ParseStringToEclDataImport(string text)
        {
            // Fields are <tab> separated
            // Missing data represented with the string "NULL" (not <null>)
            // Ticket_number + ticket_part is a unique key
            //
            // Format expected:
            // ticket_number    varchar
            // ticket_part      char        D, P, or N
            // customer_name    varchar
            // customer_code    number
            // seq              number
            // driver_id        number
            // rate_code        number
            // rate_description varchar
            // package_desc     varchar
            // batch_entry_id   number
            // run_id           number
            // run_number       number
            // driver_date      timestamp   yyyy-mm-dd hh:mm:ss.xxx
            // date_entered     timestamp   yyyy-mm-dd hh:mm:ss.xxx
            // ticket_payable   char        Y or N
            // rural_payable    char        Y or N
            // scan_count       number
            // signature_flag   varchar
            // sig_captured     varchar
            // signame          varchar
            // rc_piece_rate_code   varchar

            int i;
            string s;
            DateTime dt;
            DateTime DriverDate = DateTime.MinValue;
            int err_count = 0;
            string err_msg = "";

            EclDataImport item = new EclDataImport();
            text = text.Replace("\"", "");
            text = text.Replace("\'", "");

            item.EclBatchNo = batch_no;

            string[] fields = text.Split(separator);
            for (i = 0; i < fields.Length; i++)
            {
                err_msg = "";
                err_count = 0;

                // s = fields[i];
                // if (s == "NULL")
                // {
                //     s = "";
                // }
                s = (fields[i] == "NULL") ? "" : fields[i];
                switch (i)
                {
                    case 0:    // customer_name
                        item.EclCustomerName = s;
                        break;
                    case 1:    // customer_code
                        item.EclCustomerCode = s;
                        break;
                    case 2:    // ticket_number
                        item.EclTicketNo = s;
                        break;
                    case 3:    // ticket_part
                        item.EclTicketPart = s;
                        break;
                    case 4:    // seq
                        item.EclSeq = s;
                        break;
                    case 5:    // driver_id
                        item.EclDriverId = s;
                        break;
                    case 6:    // rate_code
                        item.EclRateCode = s;
                        break;
                    case 7:    // rate_descr
                        item.EclRateDescr = s;
                        break;
                    case 8:    // pkg_descr
                        item.EclPkgDescr = s;
                        break;
                    case 9:    // batch_id
                        item.EclBatchId = s;
                        break;
                    case 10:   // run_id
                        item.EclRunID = s;
                        break;
                    case 11:   // run_no
                        item.EclRunNo = s;
                        break;
                    case 12:   // driver_date
                        if (DateTime.TryParse(s, out dt))
                        {
                            item.EclDriverDate = dt;
                            DriverDate = dt;
                        }
                        else
                        {
                            err_count++;
                            err_msg = err_msg + "   driver_date = " + s + "\n";
                        }
                        break;
                    case 13:   // date_entered
                        item.EclDateEntered = s;
                        break;
                    case 14:   // ticket_payable
                        item.EclTicketPayable = s;
                        break;
                    case 15:   // rural_payable
                        item.EclRuralPayable = s;
                        break;
                    case 16:   // scan_count
                        item.EclScanCount = s;
                        break;
                    case 17:   // sig_req_flag
                        item.EclSigReqFlag = s;
                        break;
                    case 18:   // sig_captured
                        item.EclSigCaptured = s;
                        break;
                    case 19:   // sig_name
                        item.EclSigName = s;
                        break;
                    case 20:   // rc_pr_code
                        item.EclPrCode = s;
                        break;
                    default:
                        err_count++;
                        err_msg = err_msg + "  Field " + i.ToString() + ": default\n";
                        break;
                }
            }
            item.EclEffectiveDate = lastDayOfMonth(DriverDate);
            return item;
        }

        private DateTime lastDayOfMonth(DateTime pDate)
        {
            DateTime dt = DateTime.MinValue;
            TimeSpan OneDay = TimeSpan.FromDays(1);
            int mth = pDate.Month;
            int yr = pDate.Year;
            mth++;
            if (mth > 12)
            {
                mth = 1;
                yr++;
            }
            string t = "1-" + mth.ToString() + "-" + yr.ToString();
            if (DateTime.TryParse(t, out dt))
            {
                dt = dt.Subtract(OneDay);
            }
            return dt;
        }
        private EclImportText ParseStringToEclImportText(string pText, int pBatchNo)
        //private string ParseStringToEclDataImport(string text)
        {   
            // Fields are <tab> separated
            // Missing data represented with the string "NULL" (not <null>)
            // Ticket_number + ticket_part is a unique key
            //
            // Format expected:
            // ticket_number    varchar
            // ticket_part      char        D, P, or N
            // customer_name    varchar
            // customer_code    number
            // seq              number
            // driver_id        number
            // rate_code        number
            // rate_description varchar
            // package_desc     varchar
            // batch_entry_id   number
            // run_id           number
            // run_number       number
            // driver_date      timestamp   yyy-mm-dd hh:mm:ss.xxx
            // date_entered     timestamp   yyy-mm-dd hh:mm:ss.xxx
            // ticket_payable   char        Y or N
            // rural_payable    char        Y or N
            // scan_count       number
            // signature_flag   varchar
            // sig_captured     varchar
            // signame          varchar
            // rc_piece_rate_code   varchar

            int i;
            string s;
            DateTime dt;
            int err_count = 0;
            string err_msg = "";

            pText = pText.Replace("\"", "");
            pText = pText.Replace("\'", "");

            EclImportText item = new EclImportText();
            item.nEclBatchNo = pBatchNo;
            
            string[] fields = pText.Split(separator);
            for (i = 0; i < fields.Length; i++)
            {
                s = fields[i];
                err_msg = "";
                err_count = 0;

                if (s == "NULL")
                {
                    s = "";
                }
                switch (i)
                {
                    case 0:    // customer_name
                        item.sEclCustomerName = s;
                        break;
                    case 1:    // customer_code
                        item.sEclCustomerCode = s;
                        break;
                    case 2:    // ticket_number
                        item.sEclTicketNo = s;
                        break;
                    case 3:    // ticket_part
                        item.sEclTicketPart = s;
                        break;
                    case 4:    // seq
                        item.sEclSeq = s;
                        break;
                    case 5:    // driver_id
                        item.sEclDriverId = s;
                        break;
                    case 6:    // rate_code
                        item.sEclRateCode = s;
                        break;
                    case 7:    // rate_descr
                        item.sEclRateDescr = s;
                        break;
                    case 8:    // pkg_descr
                        item.sEclPkgDescr = s;
                        break;
                    case 9:    // batch_id
                        item.sEclBatchId = s;
                        break;
                    case 10:   // run_id
                        item.sEclRunID = s;
                        break;
                    case 11:   // run_no
                        item.sEclRunNo = s;
                        break;
                    case 12:   // driver_date
                        if (DateTime.TryParse(s, out dt))
                        {
                            item.dEclDriverDate = dt;
                        }
                        else
                        {
                            err_count++;
                            err_msg = err_msg + "   driver_date = " + s + "\n";
                        }
                        break;
                    case 13:   // date_entered
                        item.sEclDateEntered = s;
                        break;
                    case 14:   // ticket_payable
                        item.sEclTicketPayable = s;
                        break;
                    case 15:   // rural_payable
                        item.sEclRuralPayable = s;
                        break;
                    case 16:   // scan_count
                        item.sEclScanCount = s;
                        break;
                    case 17:   // sig_req_flag
                        item.sEclSigReqFlag = s;
                        break;
                    case 18:   // sig_captured
                        item.sEclSigCaptured = s;
                        break;
                    case 19:   // sig_name
                        item.sEclSigName = s;
                        break;
                    case 20:   // rc_pr_code
                        item.sEclPrCode = s;
                        break;
                    default:
                        err_count++;
                        err_msg = err_msg + "  Field " + i.ToString() + ": default\n";
                        break;
                }
            }
            return item;
        }
        #endregion

        private void tb_batch_no_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("Bad batch number.  Must be a simple integer."
                            , "Error");
        }

        private void tb_batch_no_Leave(object sender, EventArgs e)
        {
            string sBatchNo = tb_batch_no.Text;
            int n;
            if (int.TryParse(sBatchNo, out n))
                currentBatchNo = n;
            else
            {
                MessageBox.Show("Bad batch number.  Must be a simple integer."
                                , "Error"
                                );
                tb_batch_no.Text = currentBatchNo.ToString();
            }
        }
    }
}
