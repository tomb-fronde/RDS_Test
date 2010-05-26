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
            public int? EclCustomerCode;
            public int? EclSeq;
            public int? EclDriverId;
            public int? EclRateCode;
            public string EclRateDescr;
            public string EclPkgDescr;
            public int? EclBatchId;
            public int? EclRunID;
            public string EclRunNo;
            public DateTime? EclDriverDate;
            public DateTime? EclDateEntered;
            public string EclTicketPayable;
            public string EclRuralPayable;
            public int? EclScanCount;
            public string EclSigReqFlag;
            public string EclSigCaptured;
            public string EclSigName;
            public string EclPrCode;
            public string ErrorMsgText;
        }

        public List<EclImportError> ecl_import_error_list;

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

        public Button cb_cancel;

        public Button cb_stop;

        //public URdsDw dw_errors;

        public List<EclDataImportExeptionReport> dw_errorsList = new List<EclDataImportExeptionReport>();

        public string isIgnoreWrongRates = "UNDEF";
        private Label label1;
        private MaskedTextBox tb_batch_no;
        public int nImportedRecords;
        public int nImportedErrors;
        public int currentBatchNo = 0;
        public int newBatchNo = 0;
        string sBlankLine = "                              \n";
        string sTopLine = "---------------------------------------\n\n";
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
            int sqlCode=0;
            string sqlErrText="";

            // The 'current' batch number is the newest one that has been loaded but not inserted
            currentBatchNo = l_batchNo = RDSDataService.GetECLUploadHistoryCurrentBatchNo(ref sqlCode, ref sqlErrText);
            if ((l_batchNo == 0))
            {
                // If there is no current batch, get the next one
                newBatchNo = l_batchNo = RDSDataService.GetECLUploadHistoryNextBatchNo(ref sqlCode, ref sqlErrText);
            }
            string s_BatchNo = l_batchNo.ToString();
            //MessageBox.Show("l_batch_no = " + s_BatchNo + "\n"
            //               , "Debugging");

            //?base.pfc_postopen();
            dw_import.URdsDw_GetFocus(new object(), new EventArgs());
            tb_batch_no.Text = s_BatchNo;
            this.cb_insert.Visible = false;

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
            this.cb_cancel = new System.Windows.Forms.Button();
            //this.dw_errors = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_batch_no = new System.Windows.Forms.MaskedTextBox();
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
            // cb_cancel
            // 
            this.cb_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_cancel.Location = new System.Drawing.Point(604, 361);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(52, 21);
            this.cb_cancel.TabIndex = 7;
            this.cb_cancel.Text = "&Cancel";
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_clicked);
            // 
            // dw_errors
            // 
            /*
                this.dw_errors.DataObject = null;
                this.dw_errors.FireConstructor = false;
                this.dw_errors.Location = new System.Drawing.Point(662, 0);
                this.dw_errors.Name = "dw_errors";
                this.dw_errors.Size = new System.Drawing.Size(433, 144);
                this.dw_errors.TabIndex = 8;
                this.dw_errors.Visible = false;
            */
            // 
            // cb_stop
            // 
            this.cb_stop.Enabled = false;
            this.cb_stop.Font = new System.Drawing.Font("Arial", 8F);
            this.cb_stop.Location = new System.Drawing.Point(522, 361);
            this.cb_stop.Name = "cb_stop";
            this.cb_stop.Size = new System.Drawing.Size(65, 21);
            this.cb_stop.TabIndex = 8;
            this.cb_stop.Text = "Sto&p";
            this.cb_stop.Visible = false;
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
            // 
            // WEclDataImport
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(665, 386);
            this.Controls.Add(this.tb_batch_no);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dw_import);
            this.Controls.Add(this.sle_1);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.cb_import);
            this.Controls.Add(this.cb_select);
            this.Controls.Add(this.cb_upload);
            this.Controls.Add(this.cb_insert);
            //this.Controls.Add(this.dw_errors);
            this.Controls.Add(this.cb_cancel);
            this.Controls.Add(this.cb_stop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WEclDataImport";
            this.Text = "ECL Data Import";
            this.Controls.SetChildIndex(this.cb_stop, 0);
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            //this.Controls.SetChildIndex(this.dw_errors, 0);
            this.Controls.SetChildIndex(this.cb_insert, 0);
            this.Controls.SetChildIndex(this.cb_upload, 0);
            this.Controls.SetChildIndex(this.cb_select, 0);
            this.Controls.SetChildIndex(this.cb_import, 0);
            this.Controls.SetChildIndex(this.st_1, 0);
            this.Controls.SetChildIndex(this.sle_1, 0);
            this.Controls.SetChildIndex(this.dw_import, 0);
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

        public virtual bool wf_checkdate(int pRow, DateTime pToday)
        {   // Validate the contract date
            // If valid
            //    Return TRUE
            // If invalid
            //    Return FALSE
            //    Add record to ErrorList
            //    (but do not delete - done by calling routine)
/*
            DateTime thisPrdDate;

            thisPrdDate = (DateTime)dw_import.DataObject.GetItem<EclDataImport>(pRow).PrdDate;
            if ( thisPrdDate > pToday )
            {
                wf_saveerror_info( pRow, "Invalid date" );
                return false;
            }
*/
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
/*
            string sMSNumber;
            int lContract;
            int lCount;
            int SQLCode = 0;

            sMSNumber = dw_import.DataObject.GetItem<EclDataImport>(pRow).Contract;
            if ( ! int.TryParse(sMSNumber, out lContract) )
            {
                // select contract_no into :lContract from contract where con_old_mail_service_no = :sMSNumber;
                lContract = RDSDataService.GetContractNo(sMSNumber);
            }
            // select count(*) into :lCount from contract where contract_no = :lContract;
            lCount = RDSDataService.GetContractCount(lContract, ref SQLCode);
            if (SQLCode == 0 && lCount > 0)
            {
                dw_import.DataObject.GetItem<EclDataImport>(pRow).ContractNo = lContract;
            }
            else
            {
                dw_import.DataObject.GetItem<EclDataImport>(pRow).ContractNo = -1;
                wf_saveerror_info(pRow, "Contract not found on database");
                return false;
            }
*/
            return true;
        }
        public virtual int wf_select_invalid(int pRow )
        {
            // Select duplicate row to reject
            //Called when record pRow - 1 matches record pRow (matched by wf_is_duplicate)
            // Returns
            //    1    Previous record (pRow - 1) is rejected
            //    2    Current record (pRow) is rejected
            return 2;
        }

        public virtual bool wf_is_duplicate(int pRow, string pTicketNo, string pTicketPart, int pSeqNo)
        {   // Check for duplicate records.  Parameters contain previous record's values.
            //If duplicate
            //   Return true

            string thisTicketNo;
            string thisTicketPart;
            int? tBatchId;
            //int? tSeqNo;
            //int thisSeqNo;
            //string msg, t;

            thisTicketNo   = dw_import.DataObject.GetItem<EclDataImport>(pRow).EclTicketNo;
            thisTicketPart = dw_import.DataObject.GetItem<EclDataImport>(pRow).EclTicketPart;
            tBatchId = dw_import.DataObject.GetItem<EclDataImport>(pRow).EclBatchId;
            //tSeqNo = dw_import.DataObject.GetItem<EclDataImport>(pRow).EclSeq;
            //thisSeqNo = (int)dw_import.DataObject.GetItem<EclDataImport>(pRow).EclSeq;
            //thisSeqNo = (thisSeqNo == null) ? -2 : thisSeqNo;

            //msg = (tSeqNo == null) ? "Seq No is null\n" : "";
            //msg += (tBatchId == null) ? "Batch ID is null\n" : "";
            //if (msg.Length != 0)
            //{
            //    t = "Row " + pRow.ToString() + "\n" + msg; 
            //}

            //if ((thisTicketNo == pTicketNo
            //     && thisTicketPart == pTicketPart
            //     && thisSeqNo == pSeqNo))
            if ((thisTicketNo == pTicketNo
                 && thisTicketPart == pTicketPart))
            {
                //wf_saveerror_info(pRow, "Duplicate data row (contract, date, prt_code)");
                //MessageBox.Show("Duplicate data row " + pRow.ToString() + "\n"
                //                + "Ticket No " + thisTicketNo + "\n"
                //                + "Ticket Part " + thisTicketPart + "\n"
                //                , "Error"
                //                );
                return true;
            }
            return false;
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
/*
            string thisPrtCode;
            int thisPrtKey;
            int SQLCode = 0;

            thisPrtCode = dw_import.DataObject.GetItem<EclDataImport>(pRow).PrtCode;

            // select prt_key into :lPRKey from piece_rate_type where prt_code = :sPRCode;
            thisPrtKey = RDSDataService.GetPrtKey(thisPrtCode, ref SQLCode);
            if (SQLCode == 0)
            {
                //dw_import.DataObject.GetItem<EclDataImport>(arow).PrtKey = lPRKey;
                dw_import.SetValue(pRow, "prt_key", thisPrtKey);
            }
            else
            {
                wf_saveerror_info( pRow, "Piece rate key not found on database" );
                return false;
            }
*/            return true;
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
                        sw.Write(ecl_import_header + "\r\n");

                        // Extract the list elements in reverse order - this writes them to the file
                        // in the order they were added to the list (and so match the input file order).
                        for (nOut = 0; nOut < nErrors; nOut++)
                        {
                            sDriverDate = null;
                            sDateEntered = null;
                            dtDriverDate = (DateTime)ecl_import_error_list[nOut].EclDriverDate;
                            dtDateEntered = (DateTime)ecl_import_error_list[nOut].EclDateEntered;
                            if (dtDriverDate != null)
                            {
                                sDriverDate = dtDriverDate.ToString(sDateFmt);
                            }
                            if (dtDateEntered != null)
                            {
                                sDateEntered = dtDateEntered.ToString(sDateFmt);
                            }

                            sBuffer = ecl_import_error_list[nOut].EclCustomerName + sep
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
                                         + ecl_import_error_list[nOut].EclRateCode
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

        public virtual bool wf_calculate_rate(int pRow)
        {   // 
            // Assumes the PrtKey value for the record has been set (in wf_check_piece_rate)
            // Save the pr_rate in PrRdCost
            // If valid
            //    Return TRUE
            // If invalid
            //    Return FALSE
            //    Add record to ErrorList
            //    (but do not delete - done by calling routine)
/*
            DateTime thisConStartDate = new DateTime();
            DateTime thisConEndDate = new DateTime();
            DateTime prevConStartDate = new DateTime();
            DateTime prevConEndDate = new DateTime();
            DateTime? thisConRatesEffectiveDate = new DateTime();
            DateTime? prevConRatesEffectiveDate = new DateTime();
            DateTime? thisPrdDate = new DateTime();
            int thisConSeqNum = int.MinValue;
            int prevConSeqNum = int.MinValue;
            int thisRgCode;
            int thisPrtKey;
            int? thisPrdQuantity;
            int? thisContractNo;
            string thisPrtCode;
            System.Decimal prevPrRate;
            System.Decimal prevPrdCost;
            System.Decimal? thisPrRate;
            System.Decimal? thisPrdCost = Decimal.MinValue;
            int SQLCode = 0;

            EclDataImport current = dw_import.DataObject.GetItem<EclDataImport>(pRow);

            // Get the required values from dw_import.
            thisContractNo  = current.ContractNo;
            thisPrdDate     = current.PrdDate;
            thisPrdQuantity = current.PrdQuantity;
            thisPrtCode = (string.IsNullOrEmpty(current.PrtCode)) ? "" : current.PrtCode.Trim();
            //if (!string.IsNullOrEmpty(current.PrtCode))
            //    {
            //    thisPrtCode = current.PrtCode.Trim();
            //}

            // Get the max seq number to determine what renewal a contract is in
            // select max(contract_seq_number) into :li_seq_num  from contract_renewals where contract_no = :li_contract_no;
            thisConSeqNum = RDSDataService.GetMaxContractSeqNumber(thisContractNo);

            // Get the start and end date of the current renewal
            //select con_start_date, con_expiry_date  into :ld_start, :ld_end  from contract_renewals  where contract_seq_number = :li_seq_num  and contract_no = :li_contract_no;

            RDSDataService dataService 
                           = RDSDataService.GetContractRenewalsDate(thisConSeqNum, thisContractNo);
            List<ContractRenewalsDateItem> list = dataService.ContractRenewalsDateItemList;
            thisConStartDate = list[0].Con_start_date;
            thisConEndDate   = list[0].Con_expiry_date;

            // Use the prt code from dw_import to determine the prt_key
            // select prt_key into :li_prt_key from piece_rate_type where prt_code = :ls_prt_code;
            thisPrtKey = RDSDataService.GetPrtKey(thisPrtCode, ref SQLCode);

            // Get the contract rates' effective date to narrow down the search for the correct rate
            //select con_rates_effective_date into :ld_con_rates_effective_date  from contract_renewals where contract_no = :li_contract_no and contract_seq_number = :li_seq_num;
            thisConRatesEffectiveDate 
                           = RDSDataService.GetConRatesEffDate(thisContractNo, thisConSeqNum);

            // Use the prt_key to determine the the rate
            // select pr_rate into :ldec_pr_rate from piece_rate  where prt_key = :li_prt_key and pr_effective_date = :ld_con_rates_effective_date;
            thisPrRate = RDSDataService.GetPrRateFromPieceRate(thisPrtKey, thisConRatesEffectiveDate);

            // Check that the prd date is in the current renewal
            if (thisPrdDate >= thisConStartDate && thisPrdDate <= thisConEndDate)
            {
                thisPrdCost = thisPrdQuantity * thisPrRate;

                // Display the answer on the dw_import
                //!dw_import.DataObject.GetItem<EclDataImport>(arow).PrdCost = ldec_prd_cost;
                dw_import.DataObject.GetItem<EclDataImport>(pRow).PrdCost = thisPrdCost;
            }
            else
            {
                // Minus 1 from the current renewal 
                //li_seq_num_min_one = li_seq_num - 1;
                prevConSeqNum = thisConSeqNum - 1;

                // select con_start_date, con_expiry_date  into :ld_prev_start, :ld_prev_end from contract_renewals  where contract_no = :li_contract_no  and contract_seq_number = :li_seq_num_min_one;
                dataService = RDSDataService.GetContractRenewalsDate(prevConSeqNum, thisContractNo);
                list = dataService.ContractRenewalsDateItemList;
                if (list != null && list.Count > 0)
                {
                    prevConStartDate = list[0].Con_start_date;
                    prevConEndDate   = list[0].Con_expiry_date;
                }

                //if (ld_prd_date >= ld_prev_start && ld_prd_date <= ld_prev_end)
                if (thisPrdDate >= prevConStartDate && thisPrdDate <= prevConEndDate)
                {
                    // Use the prt code from dw_import to determine the prt_key
                    // select prt_key into :li_prt_key from piece_rate_type where prt_code = :ls_prt_code;
                    thisPrtKey = RDSDataService.GetPrtKey(thisPrtCode, ref SQLCode);

                    // Get the contract rates effective date to norrow down the search for the correct rate
                    //select con_rates_effective_date into :ld_con_rates_effective_date from contract_renewals where contract_no = :li_contract_no and contract_seq_number = :li_seq_num_min_one;
                    prevConRatesEffectiveDate = RDSDataService.GetConRatesEffDate(thisContractNo, prevConSeqNum);

                    //  TJB  20 Jul 2005
                    //  Fix bug: use the correct contract sequence number
                    // 		   and contract_seq_number = :li_seq_num;
                    // Use the prt_key to determine the the rate
                    //select pr_rate into :ldec_pr_rate from piece_rate where prt_key = :li_prt_key and pr_effective_date = :ld_con_rates_effective_date;
                    prevPrRate = (decimal)RDSDataService.GetPrRateFromPieceRate(thisPrtKey, prevConRatesEffectiveDate);
                    prevPrdCost = (decimal)(thisPrdQuantity * prevPrRate);

                    // Display the answer on the dw_import
                    dw_import.DataObject.GetItem<EclDataImport>(pRow).PrdCost = prevPrdCost;
                }
                else
                {
                    wf_saveerror_info(pRow, "Prd_cost not determined");
                    return false;
                }
            }
*/
            return true;
        }

        private bool filterWithEmptystring(EclDataImport item)
        {
            return true;
        }

        private bool dw_import_filter(EclDataImport t)
        {
/*
            {if (t.PrdDate > DateTime.Today)
                {
                    return true;
                }
                else
                {
                    return false;
                }
*/
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
            cb_stop.Enabled = false;
            cb_stop.Visible = false;
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
            int lBatchNo=0;
            string inFilename;

            //dw_import.InsertItem<EclDataImport>(0);
            dw_import.DataObject.Reset();
            //ecl_import_errors = new EclImportError[20];
            ecl_import_error_list = new List<EclImportError>();

            if (!getBatchNo(ref lBatchNo))
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
            Cursor.Current = Cursors.WaitCursor;

            int rc = ImportFile(inFilename, lBatchNo);
            if (rc < 0)
            {
                MessageBox.Show(sTopLine
                               + "Error " + rc + " encountered reading input file."
                               + sBottomLine
                               , "ECL Data Import: Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dw_import.RowCount <= 0 )
            {
                MessageBox.Show(sTopLine
                               + "You cannot import because there are no values!"
                               + sBottomLine
                               , "ECL Data Import"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_import.DataObject.Reset();
                return;
            }

            wf_process_input();
        }

        public virtual void cb_select_clicked(object sender, EventArgs e)
        {       // Select input file
            string sFileName = string.Empty;
            string sDirectory = string.Empty;

            // Clear the datawindow
            dw_import.DataObject.Reset();

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
                              + "Invalid batch number - please enter a correct one."
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
            int rc;
            int lBatchNo=0;
            int nUploadRows;
            DateTime dtDateUploaded;
            int sqlCode=0;
            string sqlErrText="";

            string firstTicketNo;
            string firstTicketPart;

            if (! getBatchNo(ref lBatchNo))
                return;

            dtDateUploaded = DateTime.Today;
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
                               + sBottomLine
                               , "ECL Data Upload: Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            rc = dw_import.Save();
            //?commit;
            MessageBox.Show(sTopLine
                           + "The ECL data has been saved to the database\n"
                           + "    Batch " + lBatchNo.ToString() + "\n"
                           + "    " + nUploadRows.ToString() + " rows"
                           + sBottomLine
                           , "ECL Data Upload"
                           , MessageBoxButtons.OK, MessageBoxIcon.Information);

            RC = RDSDataService.InsertIntoECLUploadHistory(lBatchNo, dtDateUploaded, nUploadRows, nImportedErrors
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

        public virtual void cb_insert_clicked(object sender, EventArgs e)
        {   // Insert loaded values
            int lBatchNo=0;
            int nBatch, nRecords, nErrors;
            int sqlCode = 0;
            string sqlErrText = "";

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
            if (nBatch == 0)
            {
                MessageBox.Show(sTopLine 
                               + sBatchNo + " has already been inserted."
                //                               + " \n"
                //                               + "No records inserted."
                               + sBottomLine
                               , "ECL Data Insert: Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (nBatch < 0)
            {
                MessageBox.Show(sTopLine
                               + sBatchNo + " has not been uploaded."
                //                               + " \n"
                //                               + "No records inserted."
                               + sBottomLine
                               , "ECL Data Insert: Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            nRecords = RDSDataService.SpInsertECLUploadedData(lBatchNo, ref sqlCode, ref sqlErrText);
            nErrors = nBatch - nRecords;
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
                               + "    " + nRecords.ToString() + " records inserted.\n"
                               + "    " + nErrors.ToString() + " errors."
                               + sBottomLine
                               , "ECL Data Insert"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sTopLine
                               + sBatchNo + " processed.\n"
                               + " \n"
                               + "    " + "No records inserted.\n"
                               + "    " + nErrors.ToString() + " errors."
                               + sBottomLine
                               , "ECL Data Insert: Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public virtual void wf_process_input()
        {   
            int nRows, nRow;
            string sFileName = string.Empty;
            DateTime dToday = DateTime.Today;
            string prevTicketNo;
            string prevTicketPart;
            string sRuralPayable;
            int prevSeqNo;
            int nData = 0;
            //bool delRow = false;
            int delRow = 0;  // 1 = delete prev; 2 = delete this
            string inFilename, outFilenameDefault;
            string errName = "";
            DialogResult answer;

            inFilename = sle_1.Text;
/*
            // Reset all 3 datawindows.
            dw_errors.DataObject.Reset();
            //dw_errorsList.Clear();
*/
            dw_import.DataObject.SortString = "EclTicketNo A, EclTicketPart A, EclSeq A";
            dw_import.DataObject.Sort<EclDataImport>();

            prevTicketNo   = "";
            prevTicketPart = "";
            prevSeqNo = -1;
            nImportedErrors = 0;
            nImportedRecords = dw_import.RowCount;
            nRows = dw_import.RowCount;
            if (nRows > 0)
            {
                // Scan each input record, applying various validations
                //for (lRow = lRowCount - 1; lRow >= 0; lRow -= 1)
                // We do the loop this way because the number of rows (nRows) may decrease
                // as we delete faulty records.
                nRow = 0;
                while(nRow < nRows)
                {
                    delRow = 0;             // false;
                    if (((nRow % 10) == 0))
                    {
                        UpdateStatusText("Processing", nRow, nRows, nImportedErrors);
                    }
                    //errName = "";
                    sRuralPayable = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclRuralPayable;
                    if (sRuralPayable == "N")
                    {
                        errName = "Rural payable = N";
                        delRow = 2;          // true;
                    }
                    if (wf_is_duplicate(nRow, prevTicketNo, prevTicketPart, prevSeqNo))
                    {
                        errName = "Duplicate ticket";
                        delRow = wf_select_invalid(nRow);
                    }
                    //    - the code fragments are executed only if the validation is FALSE
/*
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
                    else if (! wf_calculate_rate(nRow))
                    {
                        errName = "check_calculate_rate";
                        delRow = true;
                    }
 */
                    if (delRow > 0)
                    {
                        //ecl_import_errors[nImportedErrors] = CopyEclDataImportItem(dw_import.DataObject.GetItem<EclDataImport>(nRow));
                        ecl_import_error_list.Add(CopyEclDataImportItem(dw_import.DataObject.GetItem<EclDataImport>(nRow), errName));

                        nImportedErrors++;
                        dw_import.DeleteItemAt(nRow);
                            // If we've deleted a row, the number of rows is less and
                            // the current row number points to the next unprocessed row.
                        nRows = dw_import.RowCount;
                    }
                    else
                    {
                        // If we haven't deleted a row
                        // Save some of the current processed row's data to use to
                        // check the next record to see if it a duplicate.  If the current row 
                        // was deleted, ignore it - - we only look for duplicate good records.

                        prevTicketNo = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclTicketNo;
                        prevTicketPart = dw_import.DataObject.GetItem<EclDataImport>(nRow).EclTicketPart;
                        prevSeqNo = (int)dw_import.DataObject.GetItem<EclDataImport>(nRow).EclSeq;
                        prevSeqNo = (prevSeqNo == null) ? -2 : prevSeqNo;
                        // Increment the row number to the next unprocessed row.
                        nRow++;
                    }
                }  // End record-scanning loop
                UpdateStatusText("Processed", nRow, nRows, nImportedErrors);
            }
            //nImportedErrors = dw_errorsList.Count;
            nData = dw_import.RowCount;
            if (nImportedRecords != (nImportedErrors + nData))
            {
                MessageBox.Show(sTopLine
                               + "Incorrect number of records after validation.\n"
                               + "   " + nImportedRecords + " records imported.\n"
                               + "   " + nImportedErrors + " error records found.\n"
                               + "   " + "(last) Error message: " + errName + "\n"
                               + "   " + nData + " records validated (nRows = " + nRows.ToString() + ")."
                               + sBottomLine
                               , "ECL Data Import: WARNING"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
/*
            if (nImportedErrors == 0)
            {
                //!dw_errors.DataObject.InsertItem<EclDataImportExeptionReport>(0);
                //!dw_errors.DataObject.GetItem<EclDataImportExeptionReport>(0).Errormsg = "No errors found in import file";
                EclDataImportExeptionReport newError = new EclDataImportExeptionReport();
                newError.Errormsg = "No errors found in import file";
                dw_errorsList.Insert(0, newError);
            }
            ((DEclDataImportExeptionReport)(dw_errors.DataObject)).Retrieve(dw_errorsList);

            //dw_errors.DataObject.SortString = "Contract A, PrdDate A, PrtCode A";
            //dw_errors.DataObject.Sort<EclDataImportExeptionReport>();
            if (nImportedErrors > 0)
            {
                MessageBox.Show(nImportedErrors + " Errors encountered.  Saving error records.\n"
                             + "Please select a file to save the faulty records to."
                             , ""
                             , MessageBoxButtons.OK, MessageBoxIcon.Information);
                int i = inFilename.LastIndexOf('.');
                outFilenameDefault = inFilename.Substring(0,i) + "-errors";
                this.SaveErrorFile(outFilenameDefault, "text");
            }
*/
            if (nImportedErrors == 0)
            {
                MessageBox.Show(sTopLine
                               + nData.ToString() + " records imported,\n"
                               + "No errors encountered."
                               + sBottomLine
                               , "ECL Data Import"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string errcountmsg;
                errcountmsg = ((nImportedErrors == 1) ? "1 error" : nImportedErrors + " errors") + " encountered.";

                answer = MessageBox.Show(sTopLine
                               + nImportedRecords.ToString() + " records imported\n"
                               + "    " + nData.ToString() + " records validated\n"
                               + "    " + errcountmsg + "\n"
                               + "    (last) Error message: " + errName + "\n"
                               + "\n"
                               + "Do you want to print the error report?"
                               + sBottomLine
                               , "ECL Data Import"
                               , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (answer == DialogResult.Yes)
                {
                    StaticVariables.gnv_app.of_get_parameters().longparm = ecl_import_error_list.Count;
                    StaticMessage.PowerObjectParm = this;
                    //OpenSheet<WEclDataImportExceptionReport>(StaticVariables.MainMDI);

                    WEclExceptionReportTest w_ecl_exception_report = new WEclExceptionReportTest();
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
            cb_stop.Visible = false;
        }
        #endregion

        #region Code added by John Mao
        //private char[] separator = new char[] { '\t', ',' };
        private char[] separator = new char[] { '\t' };

        private void UpdateStatusText(string sCaption)
        {
            ((NZPostOffice.RDS.Windows.Ruralwin.WMainMdi)StaticVariables.MainMDI).toolStripStatusLabel1.Text =
                sCaption;
            Application.DoEvents();
        }

        private void UpdateStatusText(string sCaption, int current, int total)
        {
            ((NZPostOffice.RDS.Windows.Ruralwin.WMainMdi)StaticVariables.MainMDI).toolStripStatusLabel1.Text =
                string.Format("{0} row {1} of {2}", sCaption, current, total);
            Application.DoEvents();
        }

        private void UpdateStatusText(string sCaption, int current, int total, int nErrors)
        {
            ((NZPostOffice.RDS.Windows.Ruralwin.WMainMdi)StaticVariables.MainMDI).toolStripStatusLabel1.Text =
                string.Format("{0} row {1} of {2} Errors {3}", sCaption, current, total, nErrors);
            Application.DoEvents();
        }

        // Data Import
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

                for (i = 1; i < buffer.Count; i++)
                {
                    // Update the number of records processed periodically
                    if (((i % 10) == 0))
                    {
                        UpdateStatusText("Importing", i, buffer.Count);
                    }
                    dw_import.DataObject.AddItem<EclDataImport>(ParseStringToEclDataImport(buffer[i], batch_no));
                    nImportedRecords++;

                    // Check the first record to see if the batch has already been loaded
                    // Do it now since the data files are very large and take a long time
                    // to import.  Its better to check at the beginning than to wait.
                    if (i == 1)
                    {
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

                    }
                    //err_msg = ParseStringToEclDataImport(buffer[i]);
                    //if (!string.IsNullOrEmpty(err_msg))
                    //{
                    //    err_count++;
                    //    MessageBox.Show("Row " + i.ToString() + ": \n" + err_msg
                    //                   , "ImportFile");
                    //}
                }
                UpdateStatusText("Imported", i, buffer.Count);

                dw_import.DataObject.Refresh();
                return dw_import.RowCount;
                //return err_count;
            }
            else
            {
                return -8;
            }
        }

        private EclImportError CopyEclDataImportItem(EclDataImport bad_item, string sErrorMsg)
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
            item.ErrorMsgText = sErrorMsg;
            return item;
        }

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
        #endregion

    }
}
