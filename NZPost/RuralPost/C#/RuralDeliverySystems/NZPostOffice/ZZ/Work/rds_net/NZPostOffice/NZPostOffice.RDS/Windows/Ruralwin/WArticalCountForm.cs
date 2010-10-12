using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralwin2;
using NZPostOffice.RDS.DataService;
using Metex.Windows;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WArticalCountForm : WMaster
    {
        // TJB RPCR_014 Oct-2010
        // Moved database and datawindow changes from WFullArticalCountForm to cb_ok_clicked
        // so that changes are made only when the user accepts the "Do you [really] want to ...".

        #region Define
        // TJB RPCR_014 Oct-2010
        // Added to provide for deferred artical_count table updates
        public Boolean bAssignToPending = false;

        public DataUserControl idw_Parent;

        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_artical_count;

        public Button cb_ok;

        public Button cb_cancel;

        // TJB RPCR_014 Oct-2010: Changed name from cb_1
        public Button cb_scaling;

        #endregion

        public WArticalCountForm()
        {
            this.InitializeComponent();
            this.dw_artical_count.DataObject = new DContractArticalCountForm();
            dw_artical_count.DataObject.BorderStyle = BorderStyle.Fixed3D;

            this.ShowInTaskbar = false;
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname("Article Count");
            int lRow;
            idw_Parent = StaticMessage.PowerObjectParm as DataUserControl;// URdsDw;
            lRow = idw_Parent.GetRow();
            //idw_Parent.RowsCopy(lRow, lRow, primary!, dw_artical_count, 10, primary!);
            //idw_Parent.DataObject.RowCopy<ContractArticalCountForm>(lRow, lRow, dw_artical_count.DataObject);
            dw_artical_count.InsertItem<ContractArticalCountForm>(0);
            if (idw_Parent.GetValue(lRow, "ac_scale_factor") == null)
                dw_artical_count.GetItem<ContractArticalCountForm>(0).AcScaleFactor = null;
            else
                dw_artical_count.GetItem<ContractArticalCountForm>(0).AcScaleFactor = Convert.ToDecimal(idw_Parent.GetValue(lRow, "ac_scale_factor"));

            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcStartWeekPeriod  = Convert.ToDateTime(idw_Parent.GetValue(lRow, "AcStartWeekPeriod"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1InwardMail     = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW1InwardMail"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1LargeParcels   = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW1LargeParcels"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1MediumLetters  = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW1MediumLetters"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1OtherEnvelopes = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW1OtherEnvelopes"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1SmallParcels   = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW1SmallParcels"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2InwardMail     = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW2InwardMail"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2LargeParcels   = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW2LargeParcels"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2MediumLetters  = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW2MediumLetters"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2OtherEnvelopes = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW2OtherEnvelopes"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2SmallParcels   = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW2SmallParcels"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).ContractNo         = Convert.ToInt32(idw_Parent.GetValue(lRow, "ContractNo"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).CustRdNumber       = Convert.ToString(idw_Parent.GetValue(lRow, "CustRdNumber"));
            if (idw_Parent.GetValue(lRow, "ContractSeqNumber") == null)
            {
                dw_artical_count.GetItem<ContractArticalCountForm>(0).ContractSeqNumber = null;
            }
            else
            {
                dw_artical_count.GetItem<ContractArticalCountForm>(0).ContractSeqNumber = Convert.ToInt32(idw_Parent.GetValue(lRow, "ContractSeqNumber"));
            }
            dw_artical_count.DataObject.GetControlByName("st_contract").Text = "";
            ((DContractArticalCountForm)dw_artical_count.DataObject).InitializeControl();
            dw_artical_count.ResetUpdate();
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_artical_count = new URdsDw();
            //!this.dw_artical_count.DataObject = new DContractArticalCountForm();
            this.cb_ok = new Button();
            this.cb_cancel = new Button();
            this.cb_scaling = new Button();
            Controls.Add(dw_artical_count);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            Controls.Add(cb_scaling);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Text = "Article Count";
            this.ControlBox = true;
            this.Size = new System.Drawing.Size(487, 172);
            // 
            // dw_artical_count
            // 
            dw_artical_count.VerticalScroll.Visible = false;
            dw_artical_count.TabIndex = 1;
            //!dw_artical_count.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_artical_count.Size = new System.Drawing.Size(474, 120);
            dw_artical_count.Location = new System.Drawing.Point(3, 4);

            // 
            // cb_ok
            // 
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&OK";
            cb_ok.TabIndex = 2;
            cb_ok.Size = new System.Drawing.Size(54, 22);
            cb_ok.Location = new System.Drawing.Point(121, 148);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.TabIndex = 3;
            cb_cancel.Size = new System.Drawing.Size(54, 22);
            cb_cancel.Location = new System.Drawing.Point(183, 148);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            // 
            // cb_scaling
            // 
            cb_scaling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_scaling.Text = "&View Scaling Factor";
            // Metex Migrator Warning: property tag was not converted
            cb_scaling.Tag = "ComponentName=View Factor;";
            cb_scaling.Enabled = false;
            cb_scaling.Visible = false;
            cb_scaling.TabIndex = 4;
            cb_scaling.Height = 22;
            cb_scaling.Width = 115;
            cb_scaling.Top = 148;
            cb_scaling.Left = 245;
            cb_scaling.Click += new EventHandler(cb_scaling_clicked);
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

        #region Events
        private void uf_update_parent(int? pContractNo, int? pRenewal)
        {
            // TJB RPCR_014 Oct-2010: New
            // Search idw_parent for rows matching the contract and renewal.
            // Set the renewal for that/those row(s) to null.

            int nRow, nRows, nSelectedRow;
            int? nContractNo, nRenewal;

            // The selected row is the one that has just been assigned to the renewal
            // Skip it (its the one we want to keep).
            nSelectedRow = idw_Parent.GetRow();

            nRows = idw_Parent.RowCount;
            for (nRow = 0; nRow < nRows; nRow++)
            {
                if (nRow == nSelectedRow) continue;
                nContractNo = idw_Parent.GetItem<ContractArticalCounts>(nRow).ContractNo;
                nRenewal = idw_Parent.GetItem<ContractArticalCounts>(nRow).ContractSeqNumber;
                if ( nContractNo == pContractNo )
                    if ( ! (nRenewal == null) )        // Some of the rows may already have null for the renewal
                        if ( nRenewal == pRenewal )
                            idw_Parent.GetItem<ContractArticalCounts>(nRow).ContractSeqNumber = null;
            }
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            dw_artical_count.DataObject.AcceptText();

            if (idw_Parent is DContractArticalCounts)
            {

                int lRow = idw_Parent.GetRow();
                idw_Parent.GetItem<ContractArticalCounts>(lRow).ContractSeqNumber = dw_artical_count.GetItem<ContractArticalCountForm>(0).ContractSeqNumber;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcScaleFactor = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcScaleFactor;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcStartWeekPeriod = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcStartWeekPeriod;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW1InwardMail = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1InwardMail;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW1LargeParcels = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1LargeParcels;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW1MediumLetters = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1MediumLetters;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW1OtherEnvelopes = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1OtherEnvelopes;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW1SmallParcels = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1SmallParcels;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW2InwardMail = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2InwardMail;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW2LargeParcels = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2LargeParcels;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW2MediumLetters = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2MediumLetters;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW2OtherEnvelopes = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2OtherEnvelopes;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW2SmallParcels = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2SmallParcels;

                // TJB RPCR_014 Oct-2010
                // Added bAssignToPending condition
                // If the user has two or more article counts assigned to the renewal and has selected to 
                // replace them with one of the set of counts, the ModifiedCount will be 0 but bAssignToPending 
                // will be set and the database changes will need to be made.
                if (dw_artical_count.ModifiedCount() > 0 || bAssignToPending)
                {
                    DialogResult Answer;
                    int SQLCode = 0;
                    string SQLErrText = string.Empty;

                    int? nContractNo = dw_artical_count.GetItem<ContractArticalCountForm>(0).ContractNo;
                    int? nRenewal = dw_artical_count.GetItem<ContractArticalCountForm>(0).ContractSeqNumber;
                    DateTime? dtStartWeek = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcStartWeekPeriod;
                    Decimal? dScaleFactor = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcScaleFactor;

                    Answer = MessageBox.Show("Do you want to save the changes?"
                                   , StaticVariables.MainMDI.Text
                                   , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (Answer == DialogResult.Yes)
                    {
                        if (bAssignToPending)
                        {
                            // TJB RPCR_014 Oct-2010: Added
                            // Deferred from cb_assign_to_pending in WFullArticalCountForm
                            // 'UnAssign' the old article count renewals
                            //UPDATE artical_count 
                            //   SET contract_seq_number = null 
                            // WHERE artical_count.contract_no = :lContract
                            //   AND artical_count.contract_seq_number = :ilRenewal 
                            RDSDataService.ClearArticalCountContractSeqNumber(nContractNo, nRenewal
                                                                             , ref SQLCode, ref SQLErrText);
                            if (SQLCode != 0)
                            {
                                MessageBox.Show("Error clearing previous article count renewal \n\n"
                                               + SQLErrText
                                               , "SQL Error"
                                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            // The above changes the database but doesn't update the retrieved data
                            // uf_update_parent searches the parent list and nulls the renewal
                            // This is picked up in WContract to update the article count tab display
                            // to reflect all the changes.
                            uf_update_parent(nContractNo, nRenewal);
                        }

                        // Assign tthese article counts to the renewal
                        //UPDATE artical_count 
                        //   SET contract_seq_number = :nRenewal 
                        // WHERE contract_no = :nContractNo
                        //   AND ac_start_week_period = :dtStartWeek 
                        RDSDataService.UpdateArticalCountContractSeqNumber(nContractNo, nRenewal, dtStartWeek, dScaleFactor
                                                                          , ref SQLCode, ref SQLErrText);
                        if (SQLCode != 0)
                        {
                            MessageBox.Show("Error updating artical_count renewal \n\n"
                                           + SQLErrText
                                           , "SQL Error"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        dw_artical_count.GetItem<ContractArticalCountForm>(0).MarkClean();
                        idw_Parent.GetItem<ContractArticalCounts>(lRow).MarkClean();
                    }
                    else if (Answer == DialogResult.No)
                    {
                        dw_artical_count.GetItem<ContractArticalCountForm>(0).MarkClean();
                        idw_Parent.GetItem<ContractArticalCounts>(lRow).MarkClean();
                    }
                    else
                        return;
                }
            }
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            // TJB RPCR_014  Oct-2010: Changed
            // Added 'MarkClean' so Close doesn't ask about changing any changes that are being abandonned
            int lRow = idw_Parent.GetRow();
            dw_artical_count.GetItem<ContractArticalCountForm>(0).MarkClean();
            idw_Parent.GetItem<ContractArticalCounts>(lRow).MarkClean();
            this.Close();
        }

        public virtual void cb_scaling_clicked(object sender, EventArgs e)
        {
            double dScale;
            dScale = System.Convert.ToDouble(dw_artical_count.GetItem<ContractArticalCountForm>(0).AcScaleFactor.GetValueOrDefault());//dScale = dw_artical_count.GetItemSystem.Conver.ToDouble ( 1, "ac_scale_factor" );
            Cursor.Current = Cursors.WaitCursor;
            //OpenWithParm(w_set_artical_counts_scaling_factor, dScale);
            StaticMessage.DoubleParm = dScale;
            WSetArticalCountsScalingFactor w_set_artical_counts_scaling_factor = new WSetArticalCountsScalingFactor();
            w_set_artical_counts_scaling_factor.ShowDialog();
        }
        #endregion
    }
}