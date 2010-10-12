using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Windows.Ruralwin;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataService;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WFullArticalCountForm : WArticalCountForm
    {
        // TJB RPI_014 Oct-2010: (see cb_assign_to_pending_clicked)
        // Deferred 'assign_to_pending' function to cb+ok_clicked in WArticalCountForm
        // Fixed crash bug caused by incorrect index used.

        #region Define

        // TJB RPI_014 Oct-2010: Added
        public int ilRenewal = 0;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_scaling_factor;

        // TJB RPI_014 Oct-2010: Changed name from "...renewal" to "...pending"
        public Button cb_assign_to_pending;

        #endregion

        public WFullArticalCountForm()
        {
            this.InitializeComponent();
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            int lRenewal = 0;
            int? lContract = 0;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            if (dw_artical_count.DataObject.GetItem<ContractArticalCountForm>(0).GetInitialValue<int?>("contract_seq_number") == null)
            {
                lContract = dw_artical_count.GetItem<ContractArticalCountForm>(0).ContractNo;
                //select contract_renewals.contract_seq_number
                //  into :lRenewal 
                //  from contract key join contract_renewals
                // where contract.contract_no = :lContract
                //   and (contract_renewals.contract_seq_number = (contract.con_active_sequence + 1)
                //        or (contract.con_active_sequence is null 
                //            and contract_renewals.contract_seq_number = 1))
                lRenewal = RDSDataService.GetContractSeqNumber(lContract, ref SQLCode);
                if (SQLCode == 0)
                {
                    ilRenewal = lRenewal;
                    if (dw_artical_count.GetItem<ContractArticalCountForm>(0).AcScaleFactor == null)
                        cb_assign_to_pending.Enabled = false;
                }
                else
                    cb_assign_to_pending.Enabled = false;
            }
            else
                cb_assign_to_pending.Enabled = false;

            //added by jlwang
            dw_artical_count.DataObject.BindingSource.CurrencyManager.Refresh();

            //p! added to make shortcut menu happen
            this.dw_artical_count.URdsDw_GetFocus(null, null);
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.cb_scaling_factor = new Button();
            this.cb_assign_to_pending = new Button();
            Controls.Add(cb_scaling_factor);
            Controls.Add(cb_assign_to_pending);
            this.Height = 190;
            this.Width = 550;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;

            dw_artical_count.Width = 530;
            // 
            // cb_ok
            // 
            cb_ok.Left = 361;
            cb_ok.Top = 130;
            // 
            // cb_cancel
            // 
            cb_cancel.Left = 424;
            cb_cancel.Top = 130;
            // 
            // cb_scaling
            // 
            cb_scaling.Tag = "ComponentName=Disabled;";
            cb_scaling.Left = 60;
            // 
            // cb_scaling_factor
            // 
            cb_scaling_factor.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_scaling_factor.Text = "View Scaling Factor";
            cb_scaling_factor.Tag = "ComponentName=View Factor;";
            cb_scaling_factor.Enabled = false;
            cb_scaling_factor.Visible = false;
            cb_scaling_factor.TabIndex = 4;
            cb_scaling_factor.Location = new System.Drawing.Point(3, 130);
            cb_scaling_factor.Size = new System.Drawing.Size(109, 22);
            cb_scaling_factor.Click += new EventHandler(cb_scaling_factor_clicked);
            // 
            // cb_assign_to_pending
            // 
            cb_assign_to_pending.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_assign_to_pending.Text = "Assign To Pending";
            cb_assign_to_pending.Tag = "ComponentName=Assign Article Count;";
            cb_assign_to_pending.Enabled = false;
            cb_assign_to_pending.Visible = false;
            cb_assign_to_pending.TabIndex = 5;
            cb_assign_to_pending.Location = new System.Drawing.Point(123, 130);
            cb_assign_to_pending.Size = new System.Drawing.Size(106, 22);
            cb_assign_to_pending.Click += new EventHandler(cb_assign_to_pending_clicked);
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
        public virtual void cb_scaling_factor_clicked(object sender, EventArgs e)
        {
            double? dScale;
            dScale = Convert.ToDouble(dw_artical_count.GetItem<ContractArticalCountForm>(0).AcScaleFactor);
            Cursor.Current = Cursors.WaitCursor;
            if (dw_artical_count.GetItem<ContractArticalCountForm>(0).ContractSeqNumber == null)
            {
                StaticVariables.gnv_app.of_get_parameters().stringparm = "ReadWrite";
            }
            else
            {
                StaticVariables.gnv_app.of_get_parameters().stringparm = "ReadOnly";
            }
            //OpenWithParm(w_set_artical_counts_scaling_factor, dScale);
            StaticMessage.DoubleParm = dScale.Value;
            WSetArticalCountsScalingFactor w_set_artical_counts_scaling_factor = new WSetArticalCountsScalingFactor();
            w_set_artical_counts_scaling_factor.ShowDialog();
            dScale = StaticVariables.gnv_app.of_get_parameters().doubleparm;
            if (dScale > 0)
            {
                // dw_artical_count.GetItem<ContractArticalCountForm>(0).AcScaleFactor = 0;
                // dw_Artical_Count.SetItem(1, "ac_scale_factor", dScale)
                dw_artical_count.GetItem<ContractArticalCountForm>(0).AcScaleFactor = Convert.ToDecimal(dScale);
                if (ilRenewal > 0)
                {
                    cb_assign_to_pending.Enabled = true;
                }
            }
            else
            {
                cb_assign_to_pending.Enabled = false;
            }
        }

        public virtual void cb_assign_to_pending_clicked(object sender, EventArgs e)
        {
            // CR 4182
            int? lContract;
            int lCount = 0;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            lContract = dw_artical_count.GetItem<ContractArticalCountForm>(0).ContractNo;

            // SELECT count(artical_count.contract_no)
            //  WHERE artical_count.contract_no = lContract
            //    AND artical_count.contract_seq_number = ilRenewal
            lCount = RDSDataService.GetArticalCountCount2(lContract, ilRenewal);
            if (lCount > 0)
            {
                // TJB RPI_014 Oct-2010: Changed order of strings
                // (question was in title bar)
                if (MessageBox.Show("Warning: Article count already allocated for this contract. \n" 
                                    + "Do you wish to change?"
                                    ,"Assign to Pending"
                                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question
                                    , MessageBoxDefaultButton.Button2) 
                    == DialogResult.Yes)
                {
                    // PowerBuilder 'Choose Case' statement converted into 'if' statement
                    // TJB RPI_014 Oct-2010: Changed order of strings
                    // (question was in title bar)
                    DialogResult TestExpr;
                    bAssignToPending = false;
                    TestExpr = MessageBox.Show("Do you want to replace ALL existing assignments?\n\n" 
                                              + "Click Yes to REPLACE ALL, No to ADD TO EXISTING, \n" 
                                              + "or Cancel to abort."
                                              , "Assign to Pending"
                                              , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                                              , MessageBoxDefaultButton.Button3);
                    if (TestExpr == DialogResult.Yes)
                    {
                        bAssignToPending = true;
                        // TJB RPI_014 Oct-2010: Moved this to cb_ok_clicked in WArticalCountForm
                        // Set flag to defer clearing the renewal until the user clicks the 'OK'
                        // 
                        // 'UnAssign' the old one(s)
                        //UPDATE artical_count 
                        //   SET contract_seq_number = null 
                        // WHERE artical_count.contract_no = :lContract
                        //   AND artical_count.contract_seq_number = :ilRenewal 
                        //RDSDataService.ClearArticalCountContractSeqNumber(lContract, ilRenewal, ref SQLCode, ref SQLErrText);
                        //if (SQLCode != 0)
                        //{
                        //    MessageBox.Show("Error clearing previous article count renewal \n\n"
                        //                   + SQLErrText
                        //                   , "SQL Error"
                        //                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}

                        // TJB RPI_014 Oct-2010: Changed index from 1 to 0
                        dw_artical_count.SetValue(0, "contract_seq_number", ilRenewal);
                    }
                    else if (TestExpr == DialogResult.No)    // ADD!
                    {
                        // TJB RPI_014 Oct-2010: Changed index from 1 to 0
                        dw_artical_count.SetValue(0, "contract_seq_number", ilRenewal);
                    }
                    else
                    {
                        // nothin!
                    }
                }
                // END CR 4182
            }
            else
            {
                // original
                dw_artical_count.SetValue(0, "contract_seq_number", ilRenewal);
            }
            cb_assign_to_pending.Enabled = false;
        }

        #endregion
    }
}