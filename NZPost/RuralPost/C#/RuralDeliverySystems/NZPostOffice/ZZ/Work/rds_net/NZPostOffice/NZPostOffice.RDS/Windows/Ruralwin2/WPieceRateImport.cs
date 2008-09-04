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
    public class WPieceRateImport : WAncestorWindow
    {
        #region Define
        public string isIgnoreWrongRates = "UNDEF";

        public bool bprocessing = false;

        public string is_Flag = String.Empty;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_1;

        public TextBox sle_1;

        public Label st_1;

        public Button cb_1;

        public Button cb_2;

        public Button cb_3;

        public URdsDw dw_wrong_rate;
        public List<PieceRateImportDiffRateReport> dw_wrong_rateList = new List<PieceRateImportDiffRateReport>();

        public URdsDw dw_errors;
        public List<PieceRateImportExeptionReport> dw_errorsList = new List<PieceRateImportExeptionReport>();


        public PictureBox p_abort;

        public Button cb_stop;

        public Button cb_4;

        public URdsDw dw_invalid;

        public URdsDw dw_invalid_date;
        public List<PieceRateImportInvalidDate> dw_InvalidDateList = new List<PieceRateImportInvalidDate>();

        #endregion

        public WPieceRateImport()
        {
            this.InitializeComponent();

            dw_1.DataObject = new DPieceRateImport();
            //jlwang:moved from IC
            dw_wrong_rate.DataObject = new DPieceRateImportDiffRateReport();
            dw_wrong_rate.Constructor += new UserEventDelegate(dw_wrong_rate_constructor);

            dw_errors.DataObject = new DPieceRateImportExeptionReport();

            dw_invalid.Constructor += new UserEventDelegate(dw_invalid_constructor);
            dw_invalid.DataObject = new DPieceRateImportInvalidDate();

            dw_invalid_date.Constructor += new UserEventDelegate(dw_invalid_date_constructor);
            dw_invalid_date.DataObject = new DPieceRateImportInvalidDate();
            //jlwang:end
        }

        public override void open()
        {
            base.open();

            //?dw_1.settransobject(StaticVariables.sqlca);
            /*?dw_1.DataObject.InsertItem<PieceRateImport>(0);
            dw_1.DataObject.DeleteItemAt(0);
            
            //?dw_errors.settransobject(StaticVariables.sqlca);
            dw_errors.DataObject.InsertItem<PieceRateImportExeptionReport>(0);
            dw_errors.DataObject.DeleteItemAt(0);
            //?dw_wrong_rate.settransobject(StaticVariables.sqlca);
            dw_wrong_rate.DataObject.InsertItem<PieceRateImportDiffRateReport>(0);
            dw_wrong_rate.DataObject.DeleteItemAt(0);
            //?dw_invalid.settransobject(StaticVariables.sqlca);
            dw_invalid.DataObject.InsertItem<PieceRateImportInvalidDate>(0);
            dw_invalid.DataObject.DeleteItemAt(0);
            //?dw_invalid_date.settransobject(StaticVariables.sqlca);
             */
        }

        public override int closequery()
        {
            return base.closequery();
            // if bprocessing then
            // 	messagebox ( title,"Importing data...cannot close window")
            // 	return 1
            // end if
            //?return 0;
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
//!            dw_1.DataObject = new DPieceRateImport();
            dw_1.TabIndex = 1;

            this.sle_1 = new TextBox();
            this.st_1 = new Label();
            this.cb_1 = new Button();
            this.cb_2 = new Button();
            this.cb_3 = new Button();

            this.dw_wrong_rate = new URdsDw();
            //dw_wrong_rate.DataObject = new DPieceRateImportDiffRateReport();

            this.dw_errors = new URdsDw();
            //dw_errors.DataObject = new DPieceRateImportExeptionReport();

            this.p_abort = new PictureBox();
            this.cb_stop = new Button();
            this.cb_4 = new Button();

            this.dw_invalid = new URdsDw();
            //dw_invalid.DataObject = new DPieceRateImportInvalidDate();

            this.dw_invalid_date = new URdsDw();
            //dw_invalid_date.DataObject = new DPieceRateImportInvalidDate();

            Controls.Add(dw_1);
            Controls.Add(sle_1);
            Controls.Add(st_1);
            Controls.Add(cb_1);
            Controls.Add(cb_4);
            Controls.Add(cb_2);
            Controls.Add(cb_3);
            Controls.Add(dw_wrong_rate);
            Controls.Add(dw_errors);
            Controls.Add(p_abort);
            Controls.Add(cb_stop);

            Controls.Add(dw_invalid);
            Controls.Add(dw_invalid_date);

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
            // cb_1
            // 
            cb_1.Text = "&Import with values";
            cb_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_1.TabIndex = 4;
            cb_1.Size = new System.Drawing.Size(101, 21);
            cb_1.Location = new System.Drawing.Point(254, 2);
            cb_1.Click += new EventHandler(cb_1_clicked);

            // 
            // cb_2
            // 
            cb_2.Text = "...";
            cb_2.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_2.TabIndex = 3;
            cb_2.Location = new System.Drawing.Point(229, 2);
            cb_2.Size = new System.Drawing.Size(21, 21);
            cb_2.Click += new EventHandler(cb_2_clicked);

            // 
            // cb_3
            // 
            cb_3.Text = "&Save";
            cb_3.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_3.TabIndex = 6;
            cb_3.Location = new System.Drawing.Point(417, 360);
            cb_3.Size = new System.Drawing.Size(52, 21);
            cb_3.Click += new EventHandler(cb_3_clicked);

            // 
            // dw_wrong_rate
            // 
            dw_wrong_rate.Location = new System.Drawing.Point(659, 133);
            dw_wrong_rate.Size = new System.Drawing.Size(128, 130);
            dw_wrong_rate.Visible = false;
            //dw_wrong_rate.Constructor += new UserEventDelegate(dw_wrong_rate_constructor);

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
            cb_stop.TabIndex = 7;
            cb_stop.Location = new System.Drawing.Point(366, 2);
            cb_stop.Size = new System.Drawing.Size(65, 21);
            cb_stop.Visible = false;
            cb_stop.Click += new EventHandler(cb_stop_clicked);

            // 
            // cb_4
            // 
            cb_4.Text = "&Import without values";
            cb_4.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_4.TabIndex = 5;
            cb_4.Location = new System.Drawing.Point(358, 2);
            cb_4.Size = new System.Drawing.Size(110, 21);
            cb_4.Click += new EventHandler(cb_4_clicked);

            // 
            // dw_invalid
            // 
            dw_invalid.TabIndex = 2;
            dw_invalid.Location = new System.Drawing.Point(692, 206);
            dw_invalid.Size = new System.Drawing.Size(84, 109);
            dw_invalid.Visible = false;
            //dw_invalid.Constructor += new UserEventDelegate(dw_invalid_constructor);

            // 
            // dw_invalid_date
            // 
            dw_invalid_date.TabIndex = 2;
            dw_invalid_date.Location = new System.Drawing.Point(485, 12);
            dw_invalid_date.Size = new System.Drawing.Size(262, 315);
            //dw_invalid_date.Constructor += new UserEventDelegate(dw_invalid_date_constructor);
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
        public virtual bool wf_check_contract(int arow)
        {
            string sMSNumber;
            int lContract;
            int lCount;
            bool bReturn = true;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            sMSNumber = dw_1.DataObject.GetItem<PieceRateImport>(arow).Contract;//, "contract");
            //if (IsNumber(sMSNumber)) {
            if (int.TryParse(sMSNumber, out lContract))
            {
                lContract = Convert.ToInt32(sMSNumber);
            }
            else
            {
                // select contract_no into :lContract from contract where con_old_mail_service_no = :sMSNumber;
                lContract = RDSDataService.GetContractNo(sMSNumber);
            }
            // select count(*) into :lCount from contract where contract_no = :lContract;
            lCount = RDSDataService.GetContractCount(lContract, ref SQLCode);
            if (SQLCode == 0 && lCount > 0)
            {
                dw_1.DataObject.GetItem<PieceRateImport>(arow).ContractNo = lContract;
            }
            else
            {
                dw_1.DataObject.GetItem<PieceRateImport>(arow).Errormsg = "Contract not found on database";
                PieceRateImport current = dw_1.GetItem<PieceRateImport>(arow);
                //dw_1.rowsmove(arow, arow, primary!, dw_errors, 1, primary!);
                //dw_errors.InsertItem<PieceRateImportExeptionReport>(0);
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).Contract = dw_1.GetItem<PieceRateImport>(arow).Contract;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).ContractNo = dw_1.GetItem<PieceRateImport>(arow).ContractNo;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdCost = dw_1.GetItem<PieceRateImport>(arow).PrdCost;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdDate = dw_1.GetItem<PieceRateImport>(arow).PrdDate;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdQuantity = dw_1.GetItem<PieceRateImport>(arow).PrdQuantity;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrtCode = dw_1.GetItem<PieceRateImport>(arow).PrtCode;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrtKey = dw_1.GetItem<PieceRateImport>(arow).PrtKey;
                PieceRateImportExeptionReport record = new PieceRateImportExeptionReport();
                record.Contract = current.Contract;
                record.ContractNo = current.ContractNo;
                record.PrdCost = current.PrdCost;
                record.PrdDate = current.PrdDate;
                record.PrdQuantity = current.PrdQuantity;
                record.PrtCode = current.PrtCode;
                record.PrtKey = current.PrtKey;
                dw_errorsList.Insert(0,record);

                dw_1.DeleteItemAt(arow);
                bReturn = false;
            }
            return bReturn;
        }

        public virtual bool wf_check_piece_rate(int arow)
        {
            string sPRCode;
            DateTime? dPRDate;
            int lPRKey;
            bool bReturn = true;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            PieceRateImport current = dw_1.DataObject.GetItem<PieceRateImport>(arow);

            //!sPRCode = current.PrtCode;
            sPRCode = current.PrtCode;

            //!dPRDate = dw_1.DataObject.GetItem<PieceRateImport>(arow).PrdDate;
            dPRDate = current.PrdDate;

            // select prt_key into :lPRKey from piece_rate_type where prt_code = :sPRCode;
            lPRKey = RDSDataService.GetPrtKey(sPRCode, ref SQLCode);
            if (SQLCode == 0)
            {
                dw_1.SetValue(arow, "prt_key", lPRKey);
                //dw_1.DataObject.GetItem<PieceRateImport>(arow).PrtKey = lPRKey;
            }
            else
            {
                dw_1.DataObject.GetItem<PieceRateImport>(arow).Errormsg = "Piece rate code not found on database";
                
                //dw_1.DataObject.rowsmove(arow, arow, primary!, dw_errors, 1, primary!);
                //dw_errors.InsertItem<PieceRateImportExeptionReport>(0);
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).Contract = dw_1.GetItem<PieceRateImport>(arow).Contract;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).ContractNo = dw_1.GetItem<PieceRateImport>(arow).ContractNo;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdCost = dw_1.GetItem<PieceRateImport>(arow).PrdCost;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdDate = dw_1.GetItem<PieceRateImport>(arow).PrdDate;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdQuantity = dw_1.GetItem<PieceRateImport>(arow).PrdQuantity;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrtCode = dw_1.GetItem<PieceRateImport>(arow).PrtCode;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrtKey = dw_1.GetItem<PieceRateImport>(arow).PrtKey;
                PieceRateImportExeptionReport record = new PieceRateImportExeptionReport();
                record.Contract = current.Contract;
                record.ContractNo = current.ContractNo;
                record.PrdCost = current.PrdCost;
                record.PrdDate = current.PrdDate;
                record.PrdQuantity = current.PrdQuantity;
                record.PrtCode = current.PrtCode;
                record.PrtKey = current.PrtKey;
                dw_errorsList.Insert(0, record);

                dw_1.DeleteItemAt(arow);
                bReturn = false;
            }
            return bReturn;
        }

        public virtual bool wf_confirm_rate(int arow)
        {
            int? lContract;
            DateTime? dPRDDate;
            DateTime? dPrEffDate;
            Decimal? decRate = Decimal.MinValue;
            int? lPRKey;
            bool bReturn = true;
            int lCount = int.MinValue;
            lContract = dw_1.DataObject.GetItem<PieceRateImport>(arow).ContractNo;
            lPRKey = dw_1.DataObject.GetItem<PieceRateImport>(arow).PrtKey;
            dPRDDate = dw_1.DataObject.GetItem<PieceRateImport>(arow).PrdDate;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            /*SELECT piece_rate.pr_rate, piece_rate.pr_effective_date
            INTO :decRate, :dPrEffDate 
            FROM contract key join contract_renewals,
            contract_renewals join piece_rate
            on  contract_renewals.con_rg_code_at_renewal   = piece_rate.rg_code
            and contract_renewals.con_rates_effective_date = piece_rate.pr_effective_date
            and piece_rate.prt_key = :lPRKey
            WHERE contract.contract_no = :lContract 
            AND contract_renewals.contract_seq_number = ( SELECT max ( contract_seq_number) FROM contract_renewals 
            WHERE contract_renewals.con_start_date <= :dPRDDate and contract_renewals.contract_no = contract.contract_no);*/
            RDSDataService dataService = RDSDataService.GetContractList(lPRKey, lContract, dPRDDate, ref SQLCode, ref SQLErrText);
            List<ContractItem> list = dataService.ContractItemList;
            if (list != null && list.Count > 0)
            {
                decRate = list[0].Pr_rate;
                dPrEffDate = list[0].Pr_effective_date;
            }

            if (SQLCode == 0)
            {
                dw_1.DataObject.GetItem<PieceRateImport>(arow).PrdRdCost = decRate;

                // select count(prt_key) into :lCount from piece_rate_delivery  where contract_no = :lContract and prt_key = :lPRKey and prd_date= :dPRDDate;
                lCount = RDSDataService.GetPieceRateDeliveryCount(lContract, lPRKey, dPRDDate);

                // 	if lCount>0 then
                if (!(StaticFunctions.f_nempty(lCount)))
                {
                    dw_1.DataObject.GetItem<PieceRateImport>(arow).Errormsg = "A piece rate for this contract on this date has already been defined on the datab" + "ase";

                    //dw_1.rowsmove(arow, arow, primary!, dw_errors, 1, primary!);
                    PieceRateImport current = dw_1.DataObject.GetItem<PieceRateImport>(arow);
                    //!dw_errors.InsertItem<PieceRateImportExeptionReport>(0);
                    DataEntityGrid dwchild = (DataEntityGrid)dw_1.GetControlByName("grid");
                    //!dw_errors.GetItem<PieceRateImportExeptionReport>(0).Contract = dw_1.GetItem<PieceRateImport>(arow).Contract;
                    //dw_errors.GetItem<PieceRateImportExeptionReport>(0).ContractNo = dw_1.GetItem<PieceRateImport>(arow).ContractNo;
                    //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdCost = dw_1.GetItem<PieceRateImport>(arow).PrdCost;
                    //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdDate = dw_1.GetItem<PieceRateImport>(arow).PrdDate;
                    //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdQuantity = dw_1.GetItem<PieceRateImport>(arow).PrdQuantity;
                    //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrtCode = dw_1.GetItem<PieceRateImport>(arow).PrtCode;
                    //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrtDescription = dwchild.Rows[arow].Cells["prt_key"].FormattedValue.ToString();//add by mkwang
                    //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdRdCost = dw_1.GetItem<PieceRateImport>(arow).PrdRdCost;
                    //!dw_errors.GetItem<PieceRateImportExeptionReport>(0).Errormsg = dw_1.DataObject.GetItem<PieceRateImport>(arow).Errormsg;
                    PieceRateImportExeptionReport record = new PieceRateImportExeptionReport();
                    record.Contract = current.Contract;
                    record.ContractNo = current.ContractNo;
                    record.PrdCost = current.PrdCost;
                    record.PrdDate = current.PrdDate;
                    record.PrdQuantity = current.PrdQuantity;
                    record.PrtCode = current.PrtCode;
                    record.PrtDescription = dwchild.Rows[arow].Cells["prt_key"].FormattedValue.ToString();
                    record.Errormsg = current.Errormsg;
                    dw_errorsList.Insert(0, record);

                    dw_1.DeleteItemAt(arow);
                    bReturn = false;
                }
                else if (dw_1.DataObject.GetItem<PieceRateImport>(arow).PrdCost != null && dw_1.DataObject.GetItem<PieceRateImport>(arow).PrdCost != Decimal.Round(dw_1.DataObject.GetItem<PieceRateImport>(arow).Totalcost.Value, 2) && !(StaticFunctions.f_nempty(decRate)))
                {
                    // 	and decRate>0 then 
                    System.Decimal? ltemp1;
                    System.Decimal? ltemp2;
                    System.Decimal? ltemp3;
                    ltemp1 = dw_1.DataObject.GetItem<PieceRateImport>(arow).PrdCost;
                    ltemp2 = Decimal.Round(dw_1.DataObject.GetItem<PieceRateImport>(arow).Totalcost.Value, 2);
                    ltemp3 = decRate;
                    if (isIgnoreWrongRates == "UNDEF")
                    {
                        if (MessageBox.Show("Piece Rate costs have been found that do not match the rates defined for this con" + "tract.\r\rDo you want to write them to another file for later processing?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            isIgnoreWrongRates = "NO";
                        }
                        else
                        {
                            isIgnoreWrongRates = "YES";
                        }
                    }
                    if (isIgnoreWrongRates == "NO")
                    {
                        //dw_1.rowsmove(arow, arow, primary!, dw_wrong_rate, 1, primary!);
                        PieceRateImport current = dw_1.GetItem<PieceRateImport>(arow);

                        //!dw_wrong_rate.InsertItem<PieceRateImportDiffRateReport>(0);
                        //dw_wrong_rate.GetItem<PieceRateImportDiffRateReport>(0).Contract = dw_1.GetItem<PieceRateImport>(arow).Contract;
                        //dw_wrong_rate.GetItem<PieceRateImportDiffRateReport>(0).ContractNo = dw_1.GetItem<PieceRateImport>(arow).ContractNo;
                        //dw_wrong_rate.GetItem<PieceRateImportDiffRateReport>(0).PrdCost = dw_1.GetItem<PieceRateImport>(arow).PrdCost;
                        //dw_wrong_rate.GetItem<PieceRateImportDiffRateReport>(0).PrdDate = dw_1.GetItem<PieceRateImport>(arow).PrdDate;
                        //dw_wrong_rate.GetItem<PieceRateImportDiffRateReport>(0).PrdQuantity = dw_1.GetItem<PieceRateImport>(arow).PrdQuantity;
                        //dw_wrong_rate.GetItem<PieceRateImportDiffRateReport>(0).PrtCode = dw_1.GetItem<PieceRateImport>(arow).PrtCode;
                        //!dw_wrong_rate.GetItem<PieceRateImportDiffRateReport>(0).PrtKey = dw_1.GetItem<PieceRateImport>(arow).PrtKey;
                        PieceRateImportDiffRateReport record = new PieceRateImportDiffRateReport();
                        record.Contract = current.Contract;
                        record.ContractNo = current.ContractNo;
                        record.PrdCost = current.PrdCost;
                        record.PrdDate = current.PrdDate;
                        record.PrdQuantity = current.PrdQuantity;
                        record.PrtCode = current.PrtCode;
                        record.PrtKey = current.PrtKey;
                        dw_wrong_rateList.Insert(0, record);

                        dw_1.DeleteItemAt(arow);
                    }
                }
            }
            else
            {
                dw_1.DataObject.GetItem<PieceRateImport>(arow).Errormsg = "Piece rate type does not have a rate defined for this contract";
                PieceRateImport current = dw_1.GetItem<PieceRateImport>(arow);
                //dw_1.rowsmove(arow, arow, primary!, dw_errors, 1, primary!);
                dw_errors.InsertItem<PieceRateImportExeptionReport>(0);
                //!dw_errors.GetItem<PieceRateImportExeptionReport>(0).Contract = dw_1.GetItem<PieceRateImport>(arow).Contract;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).ContractNo = dw_1.GetItem<PieceRateImport>(arow).ContractNo;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdCost = dw_1.GetItem<PieceRateImport>(arow).PrdCost;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdDate = dw_1.GetItem<PieceRateImport>(arow).PrdDate;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdQuantity = dw_1.GetItem<PieceRateImport>(arow).PrdQuantity;
                //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrtCode = dw_1.GetItem<PieceRateImport>(arow).PrtCode;
                //!dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrtKey = dw_1.GetItem<PieceRateImport>(arow).PrtKey;
                PieceRateImportExeptionReport record = new PieceRateImportExeptionReport();
                record.Contract = current.Contract;
                record.ContractNo = current.ContractNo;
                record.PrdCost = current.PrdCost;
                record.PrdDate = current.PrdDate;
                record.PrdQuantity = current.PrdQuantity;
                record.PrtCode = current.PrtCode;
                record.PrtKey = current.PrtKey;
                dw_errorsList.Insert(0, record);

                dw_1.DeleteItemAt(arow);
                bReturn = false;
            }
            return bReturn;
        }

        public virtual bool wf_check_duplicates(int arow)
        {
            bool bReturn = true;
            int lLastRow;
            int lLoop;
            if (dw_1.DataObject.GetItem<PieceRateImport>(arow).Nextdup == "Y")
            {
                if (arow == 0)
                {
                    bReturn = false;
                }
                else if (dw_1.DataObject.GetItem<PieceRateImport>(arow - 1).Nextdup == "N")
                {
                    bReturn = false;
                }
            }
            if (!bReturn)
            {
                lLastRow = arow;
                //while (dw_1.DataObject.GetItem<PieceRateImport>(lLastRow).Nextdup == "Y")
                //{
                //    lLastRow++;
                //}
                //for (lLoop = lLastRow; lLoop >= arow; lLoop -= 1)
                //{
                dw_1.DataObject.GetItem<PieceRateImport>(arow).Errormsg = "This row contains a duplicated contract number and piece rate";
                //}
                //dw_1.rowsmove(arow, lLastRow, primary!, dw_errors, 1, primary!);

                for (int i = arow; i < lLastRow; i++)
                {
                    PieceRateImport current = dw_1.DataObject.GetItem<PieceRateImport>(i);

                    //!dw_errors.InsertItem<PieceRateImportExeptionReport>(0);
                    //dw_errors.GetItem<PieceRateImportExeptionReport>(0).Contract = dw_1.GetItem<PieceRateImport>(i).Contract;
                    //dw_errors.GetItem<PieceRateImportExeptionReport>(0).ContractNo = dw_1.GetItem<PieceRateImport>(i).ContractNo;
                    //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdCost = dw_1.GetItem<PieceRateImport>(i).PrdCost;
                    //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdDate = dw_1.GetItem<PieceRateImport>(i).PrdDate;
                    //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrdQuantity = dw_1.GetItem<PieceRateImport>(i).PrdQuantity;
                    //dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrtCode = dw_1.GetItem<PieceRateImport>(i).PrtCode;
                    //!dw_errors.GetItem<PieceRateImportExeptionReport>(0).PrtKey = dw_1.GetItem<PieceRateImport>(i).PrtKey;
                    PieceRateImportExeptionReport record = new PieceRateImportExeptionReport();
                    record.Contract = current.Contract;
                    record.ContractNo = current.ContractNo;
                    record.PrdCost = current.PrdCost;
                    record.PrdDate = current.PrdDate;
                    record.PrdQuantity = current.PrdQuantity;
                    record.PrtCode = current.PrtCode;
                    record.PrtKey = current.PrtKey;
                    dw_errorsList.Insert(0, record);

                    dw_1.DeleteItemAt(i);
                }

            }
            
            //pp! changed after performance issues
            //!pp moved to cb_1_clicked, cb_4_clicked event handler to write the content of dw_errorsList only once - the last time after the loop
            //!dw_errors.SaveAs("C:\\temp\\duplicate.txt", "text");
            //==! this.SaveErrors("C:\\temp\\duplicate.txt", "text");

            return bReturn;
        }

        //pp! using private function as the performance deteriorates severely if function form URdsDw is used
        private int SaveErrors(string filename, string saveastype)
        {
            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename))//null;
                {
                    // set separator charatcer
                    char sep = '\t';                                  
                  
                    //sw = new StreamWriter(filename);
                    //!for (int r = 0; r < dw_errors.DataObject.RowCount; r++)
                    for (int r = 0; r < dw_errorsList.Count; r++)
                    {

                        PieceRateImportExeptionReport current = dw_errorsList[r];//!dw_errors.DataObject.GetItem<PieceRateImportExeptionReport>(r); 
                        
                        //!sw.Write(this.ValidateExportValue(column_fields[i].GetValue(DataObject.BindingSource.List[r])));
                        sw.Write(this.ValidateExportValue(current.Contract));
                        sw.Write(sep);
                        sw.Write(this.ValidateExportValue(current.PrtDescription));
                        sw.Write(sep);
                        sw.Write(this.ValidateExportValue(current.PrdDate));
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
                        if (r != dw_errorsList.Count - 1)
                        {
                            sw.Write("\r\n");
                        }                        
                    }
                   
                    if (sw != null)
                    {
                        sw.Close();
                    }
                }
                //!return 1;
                return dw_errorsList.Count;
            }
            catch
            {
                return -1;
            }
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


        public virtual bool wf_calculate_rate(int arow)
        {
            DateTime ld_start = new DateTime();
            DateTime ld_end = new DateTime();
            DateTime? ld_prd_date = new DateTime();
            DateTime? ld_con_rates_effective_date = new DateTime();
            DateTime ld_prev_start = new DateTime();
            DateTime ld_prev_end = new DateTime();
            int li_seq_num = int.MinValue;
            int li_rg_code = int.MinValue;
            int? li_contract_no = int.MinValue;
            int li_prt_key = int.MinValue;
            int? li_prd_quantity = int.MinValue;
            int li_seq_num_min_one = int.MinValue;
            int test = int.MinValue;
            string ls_prt_code = string.Empty;
            System.Decimal? ldec_pr_rate;
            System.Decimal? ldec_prd_cost = Decimal.MinValue;
            int SQLCode = 0;
            
            PieceRateImport current = dw_1.DataObject.GetItem<PieceRateImport>(arow);

            // Get the required valued off dw_1.
            //!li_contract_no = dw_1.DataObject.GetItem<PieceRateImport>(arow).ContractNo;
            li_contract_no = current.ContractNo;

            //!ls_prt_code = dw_1.DataObject.GetItem<PieceRateImport>(arow).PrtCode.Trim();
            if (!string.IsNullOrEmpty(current.PrtCode))
            {
                ls_prt_code = current.PrtCode.Trim();
            }

            //!ld_prd_date = dw_1.DataObject.GetItem<PieceRateImport>(arow).PrdDate;//, "prd_date").Date;
            ld_prd_date = current.PrdDate;//, "prd_date").Date;

            //!li_prd_quantity = dw_1.DataObject.GetItem<PieceRateImport>(arow).PrdQuantity;//, "prd_quantity");
            li_prd_quantity = current.PrdQuantity;//, "prd_quantity");
            // Get the max seq number to determine what renewal a contract is in
            // select max(contract_seq_number) into :li_seq_num  from contract_renewals where contract_no = :li_contract_no;
            li_seq_num = RDSDataService.GetMaxContractSeqNumber(li_contract_no);

            // Get the start and end date of the current renewal
            //select con_start_date, con_expiry_date  into :ld_start, :ld_end  from contract_renewals  where contract_seq_number = :li_seq_num  and contract_no = :li_contract_no;

            RDSDataService dataService = RDSDataService.GetContractRenewalsDate(li_seq_num, li_contract_no);
            List<ContractRenewalsDateItem> list = dataService.ContractRenewalsDateItemList;
            ld_start = list[0].Con_start_date;
            ld_end = list[0].Con_expiry_date;

            // Use the prt code from dw_1 to determine the prt_key
            // select prt_key into :li_prt_key from piece_rate_type where prt_code = :ls_prt_code;
            li_prt_key = RDSDataService.GetPrtKey(ls_prt_code, ref SQLCode);

            // Get the contract rates' effective date to narrow down the search for the correct rate
            //select con_rates_effective_date into :ld_con_rates_effective_date  from contract_renewals where contract_no = :li_contract_no and contract_seq_number = :li_seq_num;
            ld_con_rates_effective_date = RDSDataService.GetConRatesEffDate(li_contract_no, li_seq_num);

            // Use the prt_key to determine the the rate
            // select pr_rate into :ldec_pr_rate from piece_rate  where prt_key = :li_prt_key and pr_effective_date = :ld_con_rates_effective_date;
            ldec_pr_rate = RDSDataService.GetPrRateFromPieceRate(li_prt_key, ld_con_rates_effective_date);

            // Check that the prd date is in the current renewal
            if (ld_prd_date >= ld_start && ld_prd_date <= ld_end)
            {
                ldec_prd_cost = li_prd_quantity * ldec_pr_rate;

                // Display the answer on the dw_1
                //!dw_1.DataObject.GetItem<PieceRateImport>(arow).PrdCost = ldec_prd_cost;
                dw_1.DataObject.GetItem<PieceRateImport>(arow).PrdCost = ldec_prd_cost;
            }
            else
            {
                //!li_contract_no = dw_1.DataObject.GetItem<PieceRateImport>(arow).ContractNo;
                li_contract_no = current.ContractNo;

                //!ls_prt_code = dw_1.DataObject.GetItem<PieceRateImport>(arow).PrtCode;
                ls_prt_code = current.PrtCode;


                //!ld_prd_date = dw_1.DataObject.GetItem<PieceRateImport>(arow).PrdDate;
                ld_prd_date = current.PrdDate;


                //!li_prd_quantity = dw_1.DataObject.GetItem<PieceRateImport>(arow).PrdQuantity;
                li_prd_quantity = current.PrdQuantity;


                // Minus 1 from the current renewal 
                li_seq_num_min_one = li_seq_num - 1;
                // select con_start_date, con_expiry_date  into :ld_prev_start, :ld_prev_end from contract_renewals  where contract_no = :li_contract_no  and contract_seq_number = :li_seq_num_min_one;
                dataService = RDSDataService.GetContractRenewalsDate(li_seq_num_min_one, li_contract_no);
                list = dataService.ContractRenewalsDateItemList;
                if (list != null && list.Count > 0)
                {
                    ld_prev_start = list[0].Con_start_date;
                    ld_prev_end = list[0].Con_expiry_date;
                }

                if (ld_prd_date >= ld_prev_start && ld_prd_date <= ld_prev_end)
                {
                    // Use the prt code from dw_1 to determine the prt_key
                    // select prt_key into :li_prt_key from piece_rate_type where prt_code = :ls_prt_code;
                    li_prt_key = RDSDataService.GetPrtKey(ls_prt_code, ref SQLCode);

                    // Get the contract rates effective date to norrow down the search for the correct rate
                    //select con_rates_effective_date into :ld_con_rates_effective_date from contract_renewals where contract_no = :li_contract_no and contract_seq_number = :li_seq_num_min_one;
                    ld_con_rates_effective_date = RDSDataService.GetConRatesEffDate(li_contract_no, li_seq_num_min_one);

                    //  TJB  20 Jul 2005
                    //  Fix bug: use the correct contract sequence number
                    // 		   and contract_seq_number = :li_seq_num;
                    // Use the prt_key to determine the the rate
                    //select pr_rate into :ldec_pr_rate from piece_rate where prt_key = :li_prt_key and pr_effective_date = :ld_con_rates_effective_date;
                    ldec_pr_rate = RDSDataService.GetPrRateFromPieceRate(li_prt_key, ld_con_rates_effective_date);
                    ldec_prd_cost = li_prd_quantity * ldec_pr_rate;

                    // Display the answer on the dw_1
                    dw_1.DataObject.GetItem<PieceRateImport>(arow).PrdCost = ldec_prd_cost;
                }
                else
                {
                    is_Flag = "yes";
                    //dw_1.rowsmove(arow, arow, primary!, dw_invalid, 1, primary!);                                       

                    //! replaced by list of BEntities for performace reasons
                    //!dw_invalid.InsertItem<PieceRateImportInvalidDate>(0);
                    //!dw_invalid.GetItem<PieceRateImportInvalidDate>(0).Contract = dw_1.GetItem<PieceRateImport>(arow).Contract;
                    //!dw_invalid.GetItem<PieceRateImportInvalidDate>(0).ContractNo = dw_1.GetItem<PieceRateImport>(arow).ContractNo;
                    //!dw_invalid.GetItem<PieceRateImportInvalidDate>(0).PrdCost = dw_1.GetItem<PieceRateImport>(arow).PrdCost;
                    //!dw_invalid.GetItem<PieceRateImportInvalidDate>(0).PrdDate = dw_1.GetItem<PieceRateImport>(arow).PrdDate;
                    //!dw_invalid.GetItem<PieceRateImportInvalidDate>(0).PrdQuantity = dw_1.GetItem<PieceRateImport>(arow).PrdQuantity;
                    //!dw_invalid.GetItem<PieceRateImportInvalidDate>(0).PrtCode = dw_1.GetItem<PieceRateImport>(arow).PrtCode;
                    //!dw_invalid.GetItem<PieceRateImportInvalidDate>(0).PrtKey = dw_1.GetItem<PieceRateImport>(arow).PrtKey;

                    PieceRateImportInvalidDate newInvalidRec = new PieceRateImportInvalidDate();
                    newInvalidRec.Contract = current.Contract;
                    newInvalidRec.ContractNo = current.ContractNo;
                    newInvalidRec.PrdCost = current.PrdRdCost;
                    newInvalidRec.PrdDate = current.PrdDate;
                    newInvalidRec.PrdQuantity = current.PrdQuantity;
                    newInvalidRec.PrtCode = current.PrtCode;
                    newInvalidRec.PrtKey = current.PrtKey;
                    dw_InvalidDateList.Insert(0, newInvalidRec);

                    dw_1.DeleteItemAt(arow);
                }
            }
            return true;
        }

        private bool filterWithEmptystring(PieceRateImport item)
        {
            return true;
        }

        private bool dw_1_filter(PieceRateImport t)
        {
            if (t.PrdDate > DateTime.Today)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual int wf_checkdates()
        {
            int ll_Ret;
            int ll_Count;
            //?dw_1.setredraw(false);
            // dw_1.DataObject.SuspendLayout();
            dw_1.DataObject.FilterString = " prd_date >" + DateTime.Today;
            dw_1.DataObject.FilterOnce<PieceRateImport>(dw_1_filter);
            if (dw_1.RowCount > 0)
            {
                MessageBox.Show("Piece rates with invalid dates detected. Please save the invalid records to a tex" + "t file for later editing", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dw_1.SaveAs("", "text") != 1)
                {
                    dw_1.SaveAs("c:\\PieceratesInvalidDates.txt", "text");
                }
            }
            ll_Count = dw_1.RowCount;

            for (ll_Ret = 0; ll_Ret < ll_Count; ll_Ret++)
            {
                dw_1.DataObject.DeleteItemAt(0);
            }
            //dw_1.DataObject.BindingSource.List.Add(l_array);
            dw_1.DataObject.FilterString = "";
            dw_1.DataObject.FilterOnce<PieceRateImport>(filterWithEmptystring);
            dw_1.DataObject.ResumeLayout(false);
            return 1;
        }

        public virtual void post_yield()
        {
            bprocessing = false;
            cb_1.Enabled = true;
            cb_2.Enabled = true;
            dw_1.Enabled = true;
            cb_3.Enabled = true;
            dw_errors.Enabled = true;
            dw_wrong_rate.Enabled = true;
            sle_1.Enabled = true;
            st_1.Enabled = true;
            st_label.Enabled = true;
            p_abort.Visible = false;
            return;
        }

        public virtual void dw_wrong_rate_constructor()
        {
            dw_wrong_rate.of_SetUpdateable(false);
        }

        public virtual void dw_errors_constructor()
        {
            dw_errors.of_SetUpdateable(false);
        }

        public virtual void dw_invalid_constructor()
        {
            dw_invalid.of_SetUpdateable(false);
        }

        public virtual void dw_invalid_date_constructor()
        {
            dw_invalid_date.of_SetUpdateable(false);
        }

        #endregion

        #region Events
        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            int lRowCount;
            int lPRKey;
            int lRow;
            int lContract;
            int lCounter = 0;
            string sPRCode;
            string sMSNumber;
            string sPathname = string.Empty;
            string sFileName = string.Empty;
            string sIgnoreWrongRates = "UNDEF";
            string ls_test;
            System.Decimal decRate;
            DateTime dPRDate;
            ls_test = sle_1.Text;
            if (ls_test == "")
            {
                MessageBox.Show("Please select a file to import", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dw_1.DataObject.Reset();
                dw_errors.DataObject.Reset();
                dw_wrong_rate.DataObject.Reset();
                Cursor.Current = Cursors.WaitCursor;

                dw_1.InsertItem<PieceRateImport>(0);
                dw_1.Reset();
                ImportFile(sle_1.Text);
                if (dw_1.RowCount <= 0 || dw_1.DataObject.GetItem<PieceRateImport>(0).PrdCost == null)
                {
                    MessageBox.Show("You cannot import because there are no values!", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_1.DataObject.Reset();
                    return;
                }
                //  TWC - fix for 4511 - need to re-set the sort criteria before sorting again
                dw_1.DataObject.SortString = "Contract A, PrdDate A, PrtCode A";
                dw_1.DataObject.Sort<PieceRateImport>();
               
                wf_checkdates();
                lRowCount = dw_1.RowCount;
                isIgnoreWrongRates = "UNDEF";
                if (lRowCount > 0)
                {
                    bprocessing = true;

                    //pp! performance problem:                    
                    for (int i = 0; i < dw_1.DataObject.RowCount - 1; i++)
                    {
                        //! dw_1 has calculated columns, calculate values here

                        // nextdup = if((contract_no = contract_no[1] and  prt_code =  prt_code [1] and  prd_date =  prd_date[1]),'Y','N')
                        PieceRateImport current = dw_1.DataObject.GetItem<PieceRateImport>(i);

                        PieceRateImport nextRec = dw_1.DataObject.GetItem<PieceRateImport>(i + 1);
                        if (current.ContractNo == nextRec.ContractNo && current.PrtCode == nextRec.PrtCode && current.PrdDate == nextRec.PrdDate)
                        {
                            current.Nextdup = "Y";
                        }
                        else
                        {
                            current.Nextdup = "N";
                        }


                    }
                    for (lRow = lRowCount - 1; lRow >= 0; lRow -= 1)
                    {
                        if (!bprocessing)
                        {
                            break;
                        }
                        lCounter++;
                        if (/*Mod(lCounter, 10)*/ (lCounter / 10) == 0)
                        {
                            //?w_main_mdi.SetMicroHelp("Processing row " + lCounter.ToString() + " of " + lRowCount).ToString();
                        }
                        if (wf_check_contract(lRow))
                        {
                            if (wf_check_piece_rate(lRow))
                            {
                                if (wf_check_duplicates(lRow))
                                {
                                    if (wf_confirm_rate(lRow))
                                    {
                                    }
                                }
                            }
                        }
                    }
                    //P!! line moved from wf_check_duplicates to write last record in dw_errorList to file
                    this.SaveErrors("C:\\temp\\duplicate.txt", "text");
                }               

                //?!if (dw_errors.RowCount == 0 && bprocessing)
                if (dw_errorsList.Count == 0 && bprocessing)
                {
                    //!dw_errors.DataObject.InsertItem<PieceRateImportExeptionReport>(0);                    
                    //!dw_errors.DataObject.GetItem<PieceRateImportExeptionReport>(0).Errormsg = "No errors found in import file";
                    PieceRateImportExeptionReport record = new PieceRateImportExeptionReport();
                    record.Errormsg = "No errors found in import file";
                    dw_errorsList.Insert(0, record);
                }
                dw_errors.ResumeLayout(false);
                dw_wrong_rate.ResumeLayout(false);
                if (bprocessing)
                {
                    //dw_errors.Print();
                    ((DPieceRateImportExeptionReport)(dw_errors.DataObject)).Retrieve(dw_errorsList);
                    ((DPieceRateImportExeptionReport)dw_errors.DataObject).Print();

                    //!if (dw_wrong_rate.RowCount > 0)
                    if (dw_wrong_rateList.Count > 0)
                    {
                        ((DPieceRateImportDiffRateReport)(dw_wrong_rate.DataObject)).Retrieve(dw_wrong_rateList);
                        ((DPieceRateImportDiffRateReport)dw_wrong_rate.DataObject).Print();

                        //!while (StaticVariables.gnv_app.of_isempty(sPathname))
                        while (/*StaticVariables.gnv_app.of_isempty(sPathname) || */StaticVariables.gnv_app.of_isempty(sFileName))
                        {
                            //GetFileSaveName("Enter the \'Wrong Rates\' Filename", sPathname, sFileName);
                            SaveFileDialog file_dia = new SaveFileDialog();
                            file_dia.Title = "Enter the \'Wrong Rates\' Filename";
                            file_dia.InitialDirectory = sPathname;
                            file_dia.FileName = sFileName;
                            file_dia.Filter = "All files (*.*)|*.*";
                            file_dia.ShowDialog();

                            
                            sFileName = file_dia.FileName;
                            if (/*!StaticVariables.gnv_app.of_isempty(sPathname) || */StaticVariables.gnv_app.of_isempty(sFileName))
                            {
                                MessageBox.Show("A file must be specified so the piece rates with different costs can be saved.", this.Text/*parent.Title */, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                ((DPieceRateImportDiffRateReport)(dw_wrong_rate.DataObject)).Retrieve(dw_wrong_rateList);
                                //!dw_wrong_rate.SaveAs(sPathname, "text");
                                dw_wrong_rate.SaveAs(sFileName, "text");
                            }
                        }
                    }
                }
                //?w_main_mdi.SetMicroHelp("");
                post_yield();
                cb_stop.Visible = false;
                p_abort.Visible = false;
            }
        }

        public virtual void cb_2_clicked(object sender, EventArgs e)
        {
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

        public virtual void cb_3_clicked(object sender, EventArgs e)
        {
            dw_1.Save();
            //?commit;
            MessageBox.Show("The piece rate information has been saved to the database", base.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            ib_disableclosequery = true;
            this.Close();
        }

        public virtual void p_abort_clicked(object sender, EventArgs e)
        {
            if (MessageBox.Show(base.Text, "Do you want to stop processing?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                post_yield();
            }
        }

        public virtual void cb_stop_clicked(object sender, EventArgs e)
        {
            if (MessageBox.Show(base.Text, "Do you want to stop processing?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                post_yield();
            }
        }

        public virtual void cb_4_clicked(object sender, EventArgs e)
        {
            int lRowCount;
            int lPRKey;
            int lRow;
            int lContract;
            int lCounter = 0;
            string sPRCode;
            string sMSNumber;
            string sPathname = string.Empty;
            string sFileName = string.Empty;
            string sIgnoreWrongRates = "UNDEF";
            string ls_test;
            System.Decimal decRate;
            DateTime dPRDate;
            is_Flag = "";
            ls_test = sle_1.Text;
            if (ls_test == "")
            {
                MessageBox.Show("Please select a file to import", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Reset all 3 datawindows.
                dw_1.InsertItem<PieceRateImport>(0);
                dw_1.DataObject.Reset();
                dw_errors.DataObject.Reset();
                dw_wrong_rate.DataObject.Reset();
                dw_invalid.DataObject.Reset();
                Cursor.Current = Cursors.WaitCursor;
                ImportFile(sle_1.Text);
                if (dw_1.RowCount > 0 && dw_1.DataObject.GetItem<PieceRateImport>(0).PrdCost != null)
                {
                    MessageBox.Show("You cannot import because there are values!", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_1.DataObject.Reset();
                    return;
                }
                //  TWC - fix for 4511 - need to re-set the sort criteria before sorting again
                dw_1.DataObject.SortString = "Contract A, PrdDate A, PrtCode A";
                dw_1.DataObject.Sort<PieceRateImport>();
                wf_checkdates();
                lRowCount = dw_1.RowCount;
                isIgnoreWrongRates = "UNDEF";
                if (lRowCount > 0)
                {
                    bprocessing = true;

                    //pp! performance problem:                    
                    for(int i = 0; i < dw_1.DataObject.RowCount-1; i++)
                    {
                        //! dw_1 has calculated columns, calculate values here
                        
                        // nextdup = if((contract_no = contract_no[1] and  prt_code =  prt_code [1] and  prd_date =  prd_date[1]),'Y','N')
                        PieceRateImport current = dw_1.DataObject.GetItem<PieceRateImport>(i);                        

                        PieceRateImport nextRec = dw_1.DataObject.GetItem<PieceRateImport>(i + 1);
                        if (current.ContractNo == nextRec.ContractNo && current.PrtCode == nextRec.PrtCode && current.PrdDate == nextRec.PrdDate)
                        {
                            current.Nextdup = "Y";
                        }
                        else 
                        {
                            current.Nextdup = "N";
                        }

                        
                    }


                    for (lRow = lRowCount - 1; lRow >= 0; lRow -= 1)
                    {                                             
                       
                        if (!bprocessing)
                        {
                            break;
                        }
                        lCounter++;
                        if (/*Mod(lCounter, 10)*/ (lCounter / 10) == 0)
                        {
                            //?w_main_mdi.SetMicroHelp("Processing row " + lCounter.ToString() + " of " + lRowCount).ToString();
                        }

                        if (wf_check_contract(lRow))
                        {
                            if (wf_check_piece_rate(lRow))
                            {
                                if (wf_check_duplicates(lRow))
                                {
                                    if (wf_confirm_rate(lRow))
                                    {
                                        wf_calculate_rate(lRow);
                                    }
                                }
                            }
                        }
                    }
                    //P!! line moved from wf_check_duplicates to write last record in dw_errorList to file
                    this.SaveErrors("C:\\temp\\duplicate.txt", "text");
                }

                //!if (dw_errors.RowCount == 0 && bprocessing)
                if (dw_errorsList.Count == 0 && bprocessing)
                {
                    //!dw_errors.DataObject.InsertItem<PieceRateImportExeptionReport>(0);
                    //!dw_errors.DataObject.GetItem<PieceRateImportExeptionReport>(0).Errormsg = "No errors found in import file";
                    PieceRateImportExeptionReport newError = new PieceRateImportExeptionReport();
                    newError.Errormsg = "No errors found in import file";
                    dw_errorsList.Insert(0, newError);
                }
               

                if (bprocessing)
                {
                    //?dw_errors.Print();
                    ((DPieceRateImportExeptionReport)(dw_errors.DataObject)).Retrieve(dw_errorsList);
                    ((DPieceRateImportExeptionReport)dw_errors.DataObject).Print();
                    //!if (dw_wrong_rate.RowCount > 0)
                    if (dw_wrong_rateList.Count > 0)
                    {
                        //!dw_wrong_rate.Print();
                        ((DPieceRateImportDiffRateReport)(dw_wrong_rate.DataObject)).Retrieve(dw_wrong_rateList);
                        ((DPieceRateImportDiffRateReport)dw_wrong_rate.DataObject).Print();

                        //!while (StaticVariables.gnv_app.of_isempty(sPathname))
                         while (/*StaticVariables.gnv_app.of_isempty(sPathname) || */StaticVariables.gnv_app.of_isempty(sFileName))
                        {
                            //GetFileSaveName("Enter the \'Wrong Rates\' Filename", sPathname, sFileName);
                            SaveFileDialog file_dia = new SaveFileDialog();
                            file_dia.Title = "Enter the \'Wrong Rates\' Filename";
                            file_dia.InitialDirectory = sPathname;
                            file_dia.FileName = sFileName;
                            file_dia.Filter = "All files (*.*)|*.*";
                            file_dia.ShowDialog();
                            
                            sFileName = file_dia.FileName;
                            //!if (StaticVariables.gnv_app.of_isempty(sPathname))
                            if (/*!StaticVariables.gnv_app.of_isempty(sPathname) ||*/ StaticVariables.gnv_app.of_isempty(sFileName))
                            {
                                MessageBox.Show("A file must be specified so the piece rates with different costs can be saved.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                //!dw_wrong_rate.saveas(sPathname, text!, false);
                                //!dw_wrong_rate.SaveAs(sPathname, "text");
                                dw_wrong_rate.SaveAs(sFileName, "text");
                            }
                        }
                    }
                }
                //?w_main_mdi.SetMicroHelp("");
                post_yield();
                cb_stop.Visible = false;
                p_abort.Visible = false;
                if (is_Flag == "yes")
                {
                    MessageBox.Show("There have been rows that have a delivery date too far in the future.\r" + "They have been saved as Invalid.txt in your C:\\temp directory for future importin" + "g !", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ((DPieceRateImportInvalidDate)(dw_invalid.DataObject)).Retrieve(dw_InvalidDateList);
                    dw_invalid.SaveAs("C:\\Temp\\invalid.txt", "text");
                }
            }
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

                for (int i = 0; i < buffer.Count; i++)
                {
                    UpdateStatusText(i, buffer.Count);
                    dw_1.DataObject.AddItem<PieceRateImport>(ParseStringToPieceRateImport(buffer[i]));
                }
                return dw_1.RowCount;
            }
            else
            {
                return -8;
            }
        }

        private PieceRateImport ParseStringToPieceRateImport(string text)
        {
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
