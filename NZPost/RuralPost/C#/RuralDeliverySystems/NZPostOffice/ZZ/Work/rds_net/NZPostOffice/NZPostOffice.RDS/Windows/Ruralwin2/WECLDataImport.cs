using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Metex.Core;
using Metex.Windows;

using NZPostOffice.Shared;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruralwin2;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Entity.Ruralwin2;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WEclDataImport : WAncestorWindow
    {
        #region Define

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_1;

        public TextBox sle_1;

        public Label st_1;

        public Button cb_import;

        public Button cb_select;

        public Button cb_save;

        public Button cb_import_novalues;

        public Button cb_cancel;

        public Button cb_stop;

        public URdsDw dw_errors;

        public List<EclDataImportExeptionReport> dw_errorsList = new List<EclDataImportExeptionReport>();
        
        public PictureBox p_abort;

        public string isIgnoreWrongRates = "UNDEF";
        private Label label1;
        private MaskedTextBox tb_batch_no;
        public int nInputRecords;

        #endregion

        public WEclDataImport()
        {
            this.InitializeComponent();

            dw_1.DataObject = new DEclDataImport();
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
            //?base.pfc_postopen();
            dw_1.URdsDw_GetFocus(new object(), new EventArgs());
            tb_batch_no.Text = "1001";
            this.cb_import_novalues.Visible = false;
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WEclDataImport));
            this.dw_1 = new NZPostOffice.RDS.Controls.URdsDw();
            this.sle_1 = new System.Windows.Forms.TextBox();
            this.st_1 = new System.Windows.Forms.Label();
            this.cb_import = new System.Windows.Forms.Button();
            this.cb_select = new System.Windows.Forms.Button();
            this.cb_save = new System.Windows.Forms.Button();
            this.cb_import_novalues = new System.Windows.Forms.Button();
            this.cb_cancel = new System.Windows.Forms.Button();
            this.dw_errors = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_stop = new System.Windows.Forms.Button();
            this.p_abort = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_batch_no = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.p_abort)).BeginInit();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(3, 367);
            this.st_label.Size = new System.Drawing.Size(132, 21);
            this.st_label.Text = "wEclDataImport";
            // 
            // dw_1
            // 
            this.dw_1.DataObject = null;
            this.dw_1.FireConstructor = false;
            this.dw_1.Location = new System.Drawing.Point(3, 30);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(653, 325);
            this.dw_1.TabIndex = 5;
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
            // cb_save
            // 
            this.cb_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_save.Location = new System.Drawing.Point(606, 360);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(52, 21);
            this.cb_save.TabIndex = 6;
            this.cb_save.Text = "&Save";
            this.cb_save.Click += new System.EventHandler(this.cb_save_clicked);
            // 
            // cb_import_novalues
            // 
            this.cb_import_novalues.Enabled = false;
            this.cb_import_novalues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_import_novalues.Location = new System.Drawing.Point(358, 2);
            this.cb_import_novalues.Name = "cb_import_novalues";
            this.cb_import_novalues.Size = new System.Drawing.Size(110, 21);
            this.cb_import_novalues.TabIndex = 4;
            this.cb_import_novalues.Text = "&Import without values";
            this.cb_import_novalues.Visible = false;
            this.cb_import_novalues.Click += new System.EventHandler(this.cb_import_novalues_clicked);
            // 
            // cb_cancel
            // 
            this.cb_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_cancel.Location = new System.Drawing.Point(534, 360);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(52, 21);
            this.cb_cancel.TabIndex = 7;
            this.cb_cancel.Text = "&Cancel";
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_clicked);
            // 
            // dw_errors
            // 
            this.dw_errors.DataObject = null;
            this.dw_errors.FireConstructor = false;
            this.dw_errors.Location = new System.Drawing.Point(662, 0);
            this.dw_errors.Name = "dw_errors";
            this.dw_errors.Size = new System.Drawing.Size(433, 144);
            this.dw_errors.TabIndex = 8;
            this.dw_errors.Visible = false;
            // 
            // cb_stop
            // 
            this.cb_stop.Enabled = false;
            this.cb_stop.Font = new System.Drawing.Font("Arial", 8F);
            this.cb_stop.Location = new System.Drawing.Point(366, 2);
            this.cb_stop.Name = "cb_stop";
            this.cb_stop.Size = new System.Drawing.Size(65, 21);
            this.cb_stop.TabIndex = 8;
            this.cb_stop.Text = "Sto&p";
            this.cb_stop.Visible = false;
            this.cb_stop.Click += new System.EventHandler(this.cb_stop_clicked);
            // 
            // p_abort
            // 
            this.p_abort.Enabled = false;
            this.p_abort.Image = ((System.Drawing.Image)(resources.GetObject("p_abort.Image")));
            this.p_abort.Location = new System.Drawing.Point(369, 5);
            this.p_abort.Name = "p_abort";
            this.p_abort.Size = new System.Drawing.Size(17, 14);
            this.p_abort.TabIndex = 9;
            this.p_abort.TabStop = false;
            this.p_abort.Visible = false;
            this.p_abort.Click += new System.EventHandler(this.p_abort_clicked);
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
            this.Controls.Add(this.dw_1);
            this.Controls.Add(this.sle_1);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.cb_import);
            this.Controls.Add(this.cb_select);
            this.Controls.Add(this.cb_save);
            this.Controls.Add(this.cb_import_novalues);
            this.Controls.Add(this.cb_cancel);
            this.Controls.Add(this.dw_errors);
            this.Controls.Add(this.p_abort);
            this.Controls.Add(this.cb_stop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WEclDataImport";
            this.Text = "ECL Data Import";
            this.Controls.SetChildIndex(this.cb_stop, 0);
            this.Controls.SetChildIndex(this.p_abort, 0);
            this.Controls.SetChildIndex(this.dw_errors, 0);
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.cb_import_novalues, 0);
            this.Controls.SetChildIndex(this.cb_save, 0);
            this.Controls.SetChildIndex(this.cb_select, 0);
            this.Controls.SetChildIndex(this.cb_import, 0);
            this.Controls.SetChildIndex(this.st_1, 0);
            this.Controls.SetChildIndex(this.sle_1, 0);
            this.Controls.SetChildIndex(this.dw_1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tb_batch_no, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            ((System.ComponentModel.ISupportInitialize)(this.p_abort)).EndInit();
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
            DataEntityGrid dwchild = (DataEntityGrid)dw_1.GetControlByName("grid");
            EclDataImportExeptionReport record = new EclDataImportExeptionReport();

            record.Contract = dw_1.GetItem<EclDataImport>(pRow).Contract;
            record.PrdDate = dw_1.GetItem<EclDataImport>(pRow).PrdDate;
            record.PrtCode = dw_1.GetItem<EclDataImport>(pRow).PrtCode;
            record.PrdQuantity = dw_1.GetItem<EclDataImport>(pRow).PrdQuantity;
            record.PrdCost = dw_1.GetItem<EclDataImport>(pRow).PrdCost;
            record.ContractNo = dw_1.GetItem<EclDataImport>(pRow).ContractNo;
            record.PrtKey = dw_1.GetItem<EclDataImport>(pRow).PrtKey;
            record.PrdRdCost = dw_1.GetItem<EclDataImport>(pRow).PrdRdCost;
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

            thisPrdDate = (DateTime)dw_1.DataObject.GetItem<EclDataImport>(pRow).PrdDate;
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

            sMSNumber = dw_1.DataObject.GetItem<EclDataImport>(pRow).Contract;
            if ( ! int.TryParse(sMSNumber, out lContract) )
            {
                // select contract_no into :lContract from contract where con_old_mail_service_no = :sMSNumber;
                lContract = RDSDataService.GetContractNo(sMSNumber);
            }
            // select count(*) into :lCount from contract where contract_no = :lContract;
            lCount = RDSDataService.GetContractCount(lContract, ref SQLCode);
            if (SQLCode == 0 && lCount > 0)
            {
                dw_1.DataObject.GetItem<EclDataImport>(pRow).ContractNo = lContract;
            }
            else
            {
                dw_1.DataObject.GetItem<EclDataImport>(pRow).ContractNo = -1;
                wf_saveerror_info(pRow, "Contract not found on database");
                return false;
            }
*/
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
/*
            string thisPrtCode;
            int thisContractNo;
            DateTime? thisPrdDate;

            thisContractNo = (int)dw_1.DataObject.GetItem<EclDataImport>(pRow).ContractNo;
            thisPrtCode = dw_1.DataObject.GetItem<EclDataImport>(pRow).PrtCode;
            thisPrdDate = dw_1.DataObject.GetItem<EclDataImport>(pRow).PrdDate;
            if (( thisContractNo == pContractNo
                 && thisPrtCode == pPrtCode
                 && thisPrdDate == pPrdDate) )
            {
                wf_saveerror_info(pRow, "Duplicate data row (contract, date, prt_code)");
                return false;
            }
*/
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
/*
            string thisPrtCode;
            int thisPrtKey;
            int SQLCode = 0;

            thisPrtCode = dw_1.DataObject.GetItem<EclDataImport>(pRow).PrtCode;

            // select prt_key into :lPRKey from piece_rate_type where prt_code = :sPRCode;
            thisPrtKey = RDSDataService.GetPrtKey(thisPrtCode, ref SQLCode);
            if (SQLCode == 0)
            {
                //dw_1.DataObject.GetItem<EclDataImport>(arow).PrtKey = lPRKey;
                dw_1.SetValue(pRow, "prt_key", thisPrtKey);
            }
            else
            {
                wf_saveerror_info( pRow, "Piece rate key not found on database" );
                return false;
            }
*/            return true;
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
/*
            int thisContractNo;
            DateTime thisPrdDate;
            Decimal? thisPrRate;
            Decimal? thisPrdCost;
            Decimal? thisTotalcost;
            int thisPrtKey;
            int thisCount = int.MinValue;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            thisContractNo = (int)dw_1.DataObject.GetItem<EclDataImport>(pRow).ContractNo;
            thisPrdCost = dw_1.DataObject.GetItem<EclDataImport>(pRow).PrdCost;
            thisPrtKey = (int)dw_1.DataObject.GetItem<EclDataImport>(pRow).PrtKey;
            thisPrdDate = (DateTime)dw_1.DataObject.GetItem<EclDataImport>(pRow).PrdDate;
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
                dw_1.DataObject.GetItem<EclDataImport>(pRow).PrdRdCost = thisPrRate;

                // Totalcost is a derived value, depending on the PrRdCost (= _prd_quantity * _prd_rd_cost)
                // Don't reference it till the PrRdCost has been set.
                thisTotalcost = dw_1.DataObject.GetItem<EclDataImport>(pRow).Totalcost;

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
 */
            return true;
        }

        //pp! using private function as the performance deteriorates severely if function from URdsDw is used
        private int SaveErrorFile(string filename, string saveastype)
        {
/*
            int nErrorRows;
            DateTime prdDate;
            //((DEclDataImportExeptionReport)(dw_errors.DataObject)).Retrieve(dw_errorsList);

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
                            //!dw_errors.DataObject.GetItem<EclDataImportExeptionReport>(r); 
                            EclDataImportExeptionReport current = 
                                 dw_errors.DataObject.GetItem<EclDataImportExeptionReport>(row); 

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
*/
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

            EclDataImport current = dw_1.DataObject.GetItem<EclDataImport>(pRow);

            // Get the required values from dw_1.
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

            // Use the prt code from dw_1 to determine the prt_key
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

                // Display the answer on the dw_1
                //!dw_1.DataObject.GetItem<EclDataImport>(arow).PrdCost = ldec_prd_cost;
                dw_1.DataObject.GetItem<EclDataImport>(pRow).PrdCost = thisPrdCost;
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
                    // Use the prt code from dw_1 to determine the prt_key
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

                    // Display the answer on the dw_1
                    dw_1.DataObject.GetItem<EclDataImport>(pRow).PrdCost = prevPrdCost;
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

        private bool dw_1_filter(EclDataImport t)
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
        {    // List current records in dw_1
             // TJB  22-Jul-2009 testing

            int nRows;
            string sData = String.Empty;
            string sFilter = String.Empty;

            sFilter = dw_1.DataObject.FilterString;
            nRows = dw_1.RowCount;
/*
            for (int i = 0; i < nRows; i++)
            {
                sData = sData + "Row " + i;
                EclDataImport current = dw_1.DataObject.GetItem<EclDataImport>(i);
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
*/
            return nRows;
        }

        public virtual void post_yield()
        {
            cb_import.Enabled = true;
            cb_select.Enabled = true;
            dw_1.Enabled = true;
            cb_save.Enabled = true;
            //dw_errors.Enabled = true;
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
        public virtual void cb_import_clicked(object sender, EventArgs e)
        {                 // Import with values
            int batch_no, n;
            string inFilename;

            //dw_1.InsertItem<EclDataImport>(0);
            dw_1.DataObject.Reset();

            if (int.TryParse(tb_batch_no.Text, out n))
            {
                batch_no = n;
            }
            else
            {
                MessageBox.Show("Invalid batch number - please enter a correct one."
                              , "Warning"
                              , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            inFilename = sle_1.Text;
            if (inFilename == "")
            {
                MessageBox.Show("Please select a file to import"
                              , "Import"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Cursor.Current = Cursors.WaitCursor;

            int rc = ImportFile(inFilename, batch_no);
            if (rc < 0)
            {
                MessageBox.Show("Error " + rc + " encountered reading input file.\n"
                               , "Input error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dw_1.RowCount <= 0 )
            {
                MessageBox.Show("You cannot import because there are no values!"
                               , "Import"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Reset();
                return;
            }

            wf_process_input();
        }

        public virtual void cb_select_clicked(object sender, EventArgs e)
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
        {   // Save
            int nRows;
            nRows = dw_1.RowCount;
            dw_1.Save();
            //?commit;
            MessageBox.Show("The ECL data information has been saved to the database\n"
                           + "(" + nRows.ToString() + " rows)\n"
                           , base.Text
                           , MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        public virtual void cb_import_novalues_clicked(object sender, EventArgs e)
        {   // Import without values - tjb version
            int batch_no, n;
            string inFilename;

            //            dw_1.InsertItem<EclDataImport>(0);
            dw_1.DataObject.Reset();

            if (int.TryParse(tb_batch_no.Text, out n))
            {
                batch_no = n;
            }
            else
            {
                MessageBox.Show("Invalid batch number - please enter a correct one."
                              , "Warning"
                              , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
            int rc = ImportFile(inFilename, batch_no);
            if (rc < 0)
            {
                MessageBox.Show("Error " + rc + " encountered reading input file.\n"
                               , "Input error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
/*
            if (dw_1.RowCount > 0 
                && dw_1.DataObject.GetItem<EclDataImport>(0).PrdCost != null)
            {
                MessageBox.Show("You cannot import because there are values!"
                              , "Import without values"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Reset();
                return;
            }
*/
            //wf_process_input();
        }

        public virtual void wf_process_input()
        {   
            int nRows, nRow;
            int lPRKey;
            int lRow;
            int lContract;
            string sPRCode;
            string sMSNumber;
            string sFileName = string.Empty;
            string sIgnoreWrongRates = "UNDEF";
            string ls_test;
            System.Decimal decRate;
            DateTime dPRDate;
            DateTime dToday = DateTime.Today;
            int prevContractNo;
            string prevPrtCode;
            DateTime prevPrdDate;
            int nErrors = 0;
            int nData = 0;
            bool delRow = false;
            string inFilename, outFilenameDefault;

            inFilename = sle_1.Text;
/*
            // Reset all 3 datawindows.
            dw_errors.DataObject.Reset();
            //dw_errorsList.Clear();

            //  TWC - fix for 4511 - need to re-set the sort criteria before sorting again
            dw_1.DataObject.SortString = "Contract A, PrdDate A, PrtCode A";
            dw_1.DataObject.Sort<EclDataImport>();
          //      wf_dump_records("cb_import_novalues_clicked: before calling checkdates");
          //      int nDateErrors = wf_checkdates();
          //      wf_dump_records("cb_import_novalues_clicked: Starting");
            isIgnoreWrongRates = "UNDEF";
*/
            nErrors = 0;
            nRows = dw_1.RowCount;
            if (nRows > 0)
            {
                // Scan each input record, applying various validations
                //for (lRow = lRowCount - 1; lRow >= 0; lRow -= 1)
                // We do the loop this way because the number of rows (nRows) may decrease
                // as we delete faulty records.
                string errName = "";
                nRow = 0;
                while(nRow < nRows)
                {
                    errName = "";
                    delRow = false;
                    // NOTE: These conditions are the negated condition
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
   
                        // If we haven't deleted a row, the number of rows is th same and
                        // we increment the row number to the next unprocessed row.
                        nRow++;
                    }
                }  // End record-scanning loop
                //P!! line moved from wf_check_duplicates to write last record in dw_errorList to file
            }
            //nErrors = dw_errorsList.Count;
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
/*
            if (nErrors == 0)
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
*/
            DialogResult answer;
            string errcountmsg;
            if (nErrors == 0)
            {
                MessageBox.Show(nData.ToString() + " records read,\n"
                               + "No errors encountered.\n"
                               , "");
                answer = DialogResult.OK;
            }
            else
            {
                errcountmsg = ((nErrors == 1) ? "1 error" : nErrors + " errors") + " encountered.";
                answer = MessageBox.Show(nData.ToString() + " records read\n"
                             + errcountmsg + "\n\n"
                             + "Do you want to print the error report?"
                             , "Error"
                             , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
/*
            if (answer == DialogResult.Yes)
            {
                //((DEclDataImportExeptionReport)(dw_errors.DataObject)).Retrieve(dw_errorsList);
                ((DEclDataImportExeptionReport)dw_errors.DataObject).Print();
            }
            //?w_main_mdi.SetMicroHelp("");
            post_yield();
*/
            cb_stop.Visible = false;
            p_abort.Visible = false;
        }
        #endregion

        #region Code added by John Mao
        //private char[] separator = new char[] { '\t', ',' };
        private char[] separator = new char[] { '\t' };

        private void UpdateStatusText(int current, int total)
        {
            ((NZPostOffice.RDS.Windows.Ruralwin.WMainMdi)StaticVariables.MainMDI).toolStripStatusLabel1.Text = 
                string.Format("Processing row {0} of {1}", current + 1, total);
            Application.DoEvents();
        }
        // Data Import
        private int ImportFile(string path, int batch_no)
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
                }
                sr.Close();
                #endregion

                //int err_count = 0;
                //string err_msg;
                // The first row (i = 0) is column headings: skip them
                for (int i = 1; i < buffer.Count; i++)
                {
                    UpdateStatusText(i, buffer.Count);
                    dw_1.DataObject.AddItem<EclDataImport>(ParseStringToEclDataImport(buffer[i], batch_no));
                    nInputRecords++;
                    //err_msg = ParseStringToEclDataImport(buffer[i]);
                    //if (!string.IsNullOrEmpty(err_msg))
                    //{
                    //    err_count++;
                    //    MessageBox.Show("Row " + i.ToString() + ": \n" + err_msg
                    //                   , "ImportFile");
                    //}
                }
                dw_1.DataObject.Refresh();
                return dw_1.RowCount;
                //return err_count;
            }
            else
            {
                return -8;
            }
        }

        private EclDataImport ParseStringToEclDataImport(string text, int batch_no)
        //private string ParseStringToEclDataImport(string text)
        {   
            // Fields are <tab> separated
            // Missing data represented with the string "NULL" (not <null>)
            // Ticket_number + ticket_part is a unique key
            //
            // Format expected:
            // customer_name    varchar
            // customer_code    number
            // ticket_number    varchar
            // ticket_part      char        D, P, or N
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
