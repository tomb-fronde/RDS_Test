using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.RDS.Windows.Ruralwin2;
using NZPostOffice.RDS.DataService;
using Metex.Windows;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WDailyArticalCounts : WMaster
    {
        // TJB  RPCR_093  16-Jan-2015: NEW
        // Created from WArticalCountForm
        
        #region Define
        private System.ComponentModel.IContainer components = null;

        private int nContractNo;
        private int? nContractSeqNumber;
        private int nRenewal;
        private DateTime dtAcStartWeekPeriod;
        private decimal? dAcScaleFactor;
        int SQLCode = 0;

        // TJB RPCR_014 Oct-2010
        // Added to provide for deferred artical_count table updates
        private Boolean bAssignToPending = false;
        private DialogResult bAssignToPending_ReplaceAll = DialogResult.Cancel;

        private DataUserControl dw_Parent;

        // WDailyArticalCounts form objects
        // These only define the outer frames, column headings, and buttons
        // The contents (counts) are defined in dw_artical_count1 and 
        //     dw_artical_count2 in DDailyArticalCounts
        private URdsDw dw_artical_count1;
        private URdsDw dw_artical_count2;
        private Label label1;
        private Label Week1;
        private Label Mon1;
        private Label Mon1Date;
        private Label Tue1;
        private Label Tue1Date;
        private Label Wed1;
        private Label Wed1Date;
        private Label Thu1;
        private Label Thu1Date;
        private Label Fri1;
        private Label Fri1Date;
        private Label Sat1;
        private Label Sat1Date;
        private Label Week2;
        private Label Mon2;
        private Label Mon2Date;
        private Label Tue2;
        private Label Tue2Date;
        private Label Wed2;
        private Label Wed2Date;
        private Label Thu2;
        private Label Thu2Date;
        private Label Fri2;
        private Label Fri2Date;
        private Label Sat2;
        private Label Sat2Date;
        private Label Total1;
        private Label Total2;
        private Button cb_ok;
        private Button cb_cancel;
        private Button cb_scaling;
        private Button cb_pending;

        #endregion

        public WDailyArticalCounts()
        {
            this.InitializeComponent();

            dw_artical_count1.DataObject = new DDailyArticalCounts();
            dw_artical_count1.DataObject.BorderStyle = BorderStyle.FixedSingle;
            dw_artical_count2.DataObject = new DDailyArticalCounts();
            dw_artical_count2.DataObject.BorderStyle = BorderStyle.FixedSingle;

            this.cb_ok.Click += new System.EventHandler(this.cb_ok_clicked);
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_clicked);
            this.cb_scaling.Click += new System.EventHandler(this.cb_scaling_clicked);
            this.cb_pending.Click += new System.EventHandler(this.cb_pending_clicked);

            this.ShowInTaskbar = false;
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname("Article Count");
            int lRow;

            dw_Parent = StaticMessage.PowerObjectParm as DataUserControl;
            lRow = dw_Parent.GetRow();

            nContractNo = Convert.ToInt32(dw_Parent.GetValue(lRow, "ContractNo"));
            dtAcStartWeekPeriod = Convert.ToDateTime(dw_Parent.GetValue(lRow, "AcStartWeekPeriod"));

            if (dw_Parent.GetValue(lRow, "ContractSeqNumber") == null)
                nContractSeqNumber = null;
            else
                nContractSeqNumber = Convert.ToInt32(dw_Parent.GetValue(lRow, "ContractSeqNumber"));

            if (dw_Parent.GetValue(lRow, "ac_scale_factor") == null)
                dAcScaleFactor = null;
            else
                dAcScaleFactor = Convert.ToDecimal(dw_Parent.GetValue(lRow, "ac_scale_factor"));

            string sContractNo = nContractNo.ToString();
            string sContractSeqNumber = (nContractSeqNumber == null) ? "null" : nContractSeqNumber.ToString();
            string sAcStartWeekPeriod = dtAcStartWeekPeriod.ToShortDateString();
            string sAcScaleFactor = (dAcScaleFactor == null) ? "null" : dAcScaleFactor.ToString();

            /* 
                MessageBox.Show( "nContractNo = " + sContractNo + "\n"
                                + "nContractSeqNumber = " + sContractSeqNumber + "\n"
                                + "dtAcStartWeekPeriod = " + sAcStartWeekPeriod + "\n"
                                + "dAcScaleFactor = " + sAcScaleFactor + "\n"
                                , "WDailyArticalCounts.pfc_preopen");
            */
            dw_artical_count1.ResetUpdate();
        }

        public override void pfc_postopen()
        {
            base.pfc_preopen();
            //       MessageBox.Show("", "WDailyArticalCounts.pfc_postopen");
            dw_artical_count1.Retrieve(new object[] { nContractNo, dtAcStartWeekPeriod, 1 });
            dw_artical_count2.Retrieve(new object[] { nContractNo, dtAcStartWeekPeriod, 2 });

            int nWk1Rows = dw_artical_count1.RowCount;
            int nWk2Rows = dw_artical_count2.RowCount;

            this.Mon1Date.Text = dtAcStartWeekPeriod.ToString("dd MMM yyyy");
            this.Tue1Date.Text = (dtAcStartWeekPeriod.AddDays(1)).ToString("dd MMM yyyy");
            this.Wed1Date.Text = (dtAcStartWeekPeriod.AddDays(2)).ToString("dd MMM yyyy");
            this.Thu1Date.Text = (dtAcStartWeekPeriod.AddDays(3)).ToString("dd MMM yyyy");
            this.Fri1Date.Text = (dtAcStartWeekPeriod.AddDays(4)).ToString("dd MMM yyyy");
            this.Sat1Date.Text = (dtAcStartWeekPeriod.AddDays(5)).ToString("dd MMM yyyy");

            this.Mon2Date.Text = (dtAcStartWeekPeriod.AddDays(7)).ToString("dd MMM yyyy");
            this.Tue2Date.Text = (dtAcStartWeekPeriod.AddDays(8)).ToString("dd MMM yyyy");
            this.Wed2Date.Text = (dtAcStartWeekPeriod.AddDays(9)).ToString("dd MMM yyyy");
            this.Thu2Date.Text = (dtAcStartWeekPeriod.AddDays(10)).ToString("dd MMM yyyy");
            this.Fri2Date.Text = (dtAcStartWeekPeriod.AddDays(11)).ToString("dd MMM yyyy");
            this.Sat2Date.Text = (dtAcStartWeekPeriod.AddDays(12)).ToString("dd MMM yyyy");


            // Check whether to enable the 'Assign to Pending' button
            cb_pending.Enabled = true;

            // Don't enable if the scaling factor hasn't been set
            if (dAcScaleFactor == null)
            {
                cb_pending.Enabled = false;
            }

            // Don't enable if there are no daily counts
            if ( (nWk1Rows + nWk1Rows) == 0 )
            {
                cb_pending.Enabled = false;
            }

            if (nContractSeqNumber != null)
            {
                // If this group of article counts has been assigned a contract sequence number
                // don't enable the 'Assign to Pending' button
                cb_pending.Enabled = false;
            }
            else
            {
                // This group of article counts is unassigned
                // Check to see whether there is a pending renewal

                // GetContractSeqNumber returns the sequence number of this contract's 
                // pending renewal, or null if there isn't one.

                //select contract_renewals.contract_seq_number
                //  into nRenewal 
                //  from contract key join contract_renewals
                // where contract.contract_no = :lContract
                //   and (contract_renewals.contract_seq_number = (contract.con_active_sequence + 1)
                //        or (contract.con_active_sequence is null 
                //            and contract_renewals.contract_seq_number = 1))
                nRenewal = RDSDataService.GetContractSeqNumber(nContractNo, ref SQLCode);
                if (SQLCode != 0)
                {
                    // If there was trouble getting the renewal's sequence number, 
                    // don't enable the 'Assign to Pending' button
                    cb_pending.Enabled = false;
                }
                else if (nRenewal == null)
                    // If there's no renewal sequence number
                    // don't enable the 'Assign to Pending' button
                    cb_pending.Enabled = false;
            }

            dw_artical_count1.DataObject.BindingSource.CurrencyManager.Refresh();
            dw_artical_count2.DataObject.BindingSource.CurrencyManager.Refresh();

            this.dw_artical_count2.URdsDw_GetFocus(null, null);
            this.dw_artical_count1.URdsDw_GetFocus(null, null);
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dw_artical_count1 = new NZPostOffice.RDS.Controls.URdsDw();
            this.dw_artical_count2 = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_ok = new System.Windows.Forms.Button();
            this.cb_scaling = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Week1 = new System.Windows.Forms.Label();
            this.Mon1 = new System.Windows.Forms.Label();
            this.Mon1Date = new System.Windows.Forms.Label();
            this.Tue1 = new System.Windows.Forms.Label();
            this.Tue1Date = new System.Windows.Forms.Label();
            this.Wed1 = new System.Windows.Forms.Label();
            this.Wed1Date = new System.Windows.Forms.Label();
            this.Thu1 = new System.Windows.Forms.Label();
            this.Thu1Date = new System.Windows.Forms.Label();
            this.Fri1 = new System.Windows.Forms.Label();
            this.Fri1Date = new System.Windows.Forms.Label();
            this.Sat1 = new System.Windows.Forms.Label();
            this.Sat1Date = new System.Windows.Forms.Label();
            this.Week2 = new System.Windows.Forms.Label();
            this.Mon2 = new System.Windows.Forms.Label();
            this.Mon2Date = new System.Windows.Forms.Label();
            this.Tue2 = new System.Windows.Forms.Label();
            this.Tue2Date = new System.Windows.Forms.Label();
            this.Wed2 = new System.Windows.Forms.Label();
            this.Wed2Date = new System.Windows.Forms.Label();
            this.Thu2 = new System.Windows.Forms.Label();
            this.Thu2Date = new System.Windows.Forms.Label();
            this.Fri2 = new System.Windows.Forms.Label();
            this.Fri2Date = new System.Windows.Forms.Label();
            this.Sat2 = new System.Windows.Forms.Label();
            this.Sat2Date = new System.Windows.Forms.Label();
            this.Total1 = new System.Windows.Forms.Label();
            this.Total2 = new System.Windows.Forms.Label();
            this.cb_pending = new System.Windows.Forms.Button();
            this.cb_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dw_artical_count1
            // 
            this.dw_artical_count1.BackColor = System.Drawing.SystemColors.Window;
            this.dw_artical_count1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dw_artical_count1.DataObject = null;
            this.dw_artical_count1.FireConstructor = false;
            this.dw_artical_count1.Location = new System.Drawing.Point(7, 40);
            this.dw_artical_count1.Name = "dw_artical_count1";
            this.dw_artical_count1.Size = new System.Drawing.Size(572, 92);
            this.dw_artical_count1.TabIndex = 1;
            // 
            // dw_artical_count2
            // 
            this.dw_artical_count2.BackColor = System.Drawing.SystemColors.Window;
            this.dw_artical_count2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dw_artical_count2.DataObject = null;
            this.dw_artical_count2.FireConstructor = false;
            this.dw_artical_count2.Location = new System.Drawing.Point(7, 174);
            this.dw_artical_count2.Name = "dw_artical_count2";
            this.dw_artical_count2.Size = new System.Drawing.Size(572, 92);
            this.dw_artical_count2.TabIndex = 14;
            // 
            // cb_ok
            // 
            this.cb_ok.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cb_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_ok.Location = new System.Drawing.Point(424, 270);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(75, 23);
            this.cb_ok.TabIndex = 2;
            this.cb_ok.Text = "&OK";
            // 
            // cb_scaling
            // 
            this.cb_scaling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_scaling.Enabled = false;
            this.cb_scaling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_scaling.Location = new System.Drawing.Point(7, 271);
            this.cb_scaling.Name = "cb_scaling";
            this.cb_scaling.Size = new System.Drawing.Size(116, 22);
            this.cb_scaling.TabIndex = 4;
            this.cb_scaling.Tag = "ComponentName=View Factor;";
            this.cb_scaling.Text = "&View Scaling Factor";
            this.cb_scaling.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(5, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 9);
            this.label1.TabIndex = 5;
            this.label1.Text = "WDailyArticalCounts";
            // 
            // Week1
            // 
            this.Week1.BackColor = System.Drawing.SystemColors.Window;
            this.Week1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Week1.Location = new System.Drawing.Point(7, 8);
            this.Week1.Name = "Week1";
            this.Week1.Size = new System.Drawing.Size(123, 34);
            this.Week1.TabIndex = 13;
            this.Week1.Text = "Week 1";
            this.Week1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mon1
            // 
            this.Mon1.BackColor = System.Drawing.SystemColors.Window;
            this.Mon1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Mon1.Location = new System.Drawing.Point(129, 8);
            this.Mon1.Name = "Mon1";
            this.Mon1.Size = new System.Drawing.Size(65, 20);
            this.Mon1.TabIndex = 12;
            this.Mon1.Text = "Mon";
            this.Mon1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mon1Date
            // 
            this.Mon1Date.BackColor = System.Drawing.SystemColors.Window;
            this.Mon1Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Mon1Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mon1Date.Location = new System.Drawing.Point(129, 28);
            this.Mon1Date.Name = "Mon1Date";
            this.Mon1Date.Size = new System.Drawing.Size(65, 14);
            this.Mon1Date.TabIndex = 11;
            this.Mon1Date.Text = "MonDate";
            this.Mon1Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tue1
            // 
            this.Tue1.BackColor = System.Drawing.SystemColors.Window;
            this.Tue1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tue1.Location = new System.Drawing.Point(193, 8);
            this.Tue1.Name = "Tue1";
            this.Tue1.Size = new System.Drawing.Size(65, 20);
            this.Tue1.TabIndex = 10;
            this.Tue1.Text = "Tue";
            this.Tue1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tue1Date
            // 
            this.Tue1Date.BackColor = System.Drawing.SystemColors.Window;
            this.Tue1Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tue1Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tue1Date.Location = new System.Drawing.Point(193, 28);
            this.Tue1Date.Name = "Tue1Date";
            this.Tue1Date.Size = new System.Drawing.Size(65, 14);
            this.Tue1Date.TabIndex = 9;
            this.Tue1Date.Text = "TueDate";
            this.Tue1Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Wed1
            // 
            this.Wed1.BackColor = System.Drawing.SystemColors.Window;
            this.Wed1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Wed1.Location = new System.Drawing.Point(257, 8);
            this.Wed1.Name = "Wed1";
            this.Wed1.Size = new System.Drawing.Size(65, 20);
            this.Wed1.TabIndex = 8;
            this.Wed1.Text = "Wed";
            this.Wed1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Wed1Date
            // 
            this.Wed1Date.BackColor = System.Drawing.SystemColors.Window;
            this.Wed1Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Wed1Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wed1Date.Location = new System.Drawing.Point(257, 28);
            this.Wed1Date.Name = "Wed1Date";
            this.Wed1Date.Size = new System.Drawing.Size(65, 14);
            this.Wed1Date.TabIndex = 7;
            this.Wed1Date.Text = "WedDate";
            this.Wed1Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Thu1
            // 
            this.Thu1.BackColor = System.Drawing.SystemColors.Window;
            this.Thu1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Thu1.Location = new System.Drawing.Point(321, 8);
            this.Thu1.Name = "Thu1";
            this.Thu1.Size = new System.Drawing.Size(65, 20);
            this.Thu1.TabIndex = 6;
            this.Thu1.Text = "Thu";
            this.Thu1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Thu1Date
            // 
            this.Thu1Date.BackColor = System.Drawing.SystemColors.Window;
            this.Thu1Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Thu1Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Thu1Date.Location = new System.Drawing.Point(321, 28);
            this.Thu1Date.Name = "Thu1Date";
            this.Thu1Date.Size = new System.Drawing.Size(65, 14);
            this.Thu1Date.TabIndex = 5;
            this.Thu1Date.Text = "ThuDate";
            this.Thu1Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Fri1
            // 
            this.Fri1.BackColor = System.Drawing.SystemColors.Window;
            this.Fri1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Fri1.Location = new System.Drawing.Point(385, 8);
            this.Fri1.Name = "Fri1";
            this.Fri1.Size = new System.Drawing.Size(65, 20);
            this.Fri1.TabIndex = 4;
            this.Fri1.Text = "Fri";
            this.Fri1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Fri1Date
            // 
            this.Fri1Date.BackColor = System.Drawing.SystemColors.Window;
            this.Fri1Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Fri1Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fri1Date.Location = new System.Drawing.Point(385, 28);
            this.Fri1Date.Name = "Fri1Date";
            this.Fri1Date.Size = new System.Drawing.Size(65, 14);
            this.Fri1Date.TabIndex = 3;
            this.Fri1Date.Text = "FriDate";
            this.Fri1Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Sat1
            // 
            this.Sat1.BackColor = System.Drawing.SystemColors.Window;
            this.Sat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Sat1.Location = new System.Drawing.Point(449, 8);
            this.Sat1.Name = "Sat1";
            this.Sat1.Size = new System.Drawing.Size(65, 20);
            this.Sat1.TabIndex = 2;
            this.Sat1.Text = "Sat";
            this.Sat1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Sat1Date
            // 
            this.Sat1Date.BackColor = System.Drawing.SystemColors.Window;
            this.Sat1Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Sat1Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sat1Date.Location = new System.Drawing.Point(449, 28);
            this.Sat1Date.Name = "Sat1Date";
            this.Sat1Date.Size = new System.Drawing.Size(65, 14);
            this.Sat1Date.TabIndex = 1;
            this.Sat1Date.Text = "SatDate";
            this.Sat1Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Week2
            // 
            this.Week2.BackColor = System.Drawing.SystemColors.Window;
            this.Week2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Week2.Location = new System.Drawing.Point(7, 142);
            this.Week2.Name = "Week2";
            this.Week2.Size = new System.Drawing.Size(123, 34);
            this.Week2.TabIndex = 13;
            this.Week2.Text = "Week 2";
            this.Week2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mon2
            // 
            this.Mon2.BackColor = System.Drawing.SystemColors.Window;
            this.Mon2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Mon2.Location = new System.Drawing.Point(129, 142);
            this.Mon2.Name = "Mon2";
            this.Mon2.Size = new System.Drawing.Size(65, 20);
            this.Mon2.TabIndex = 12;
            this.Mon2.Text = "Mon";
            this.Mon2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mon2Date
            // 
            this.Mon2Date.BackColor = System.Drawing.SystemColors.Window;
            this.Mon2Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Mon2Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mon2Date.Location = new System.Drawing.Point(129, 162);
            this.Mon2Date.Name = "Mon2Date";
            this.Mon2Date.Size = new System.Drawing.Size(65, 14);
            this.Mon2Date.TabIndex = 11;
            this.Mon2Date.Text = "MonDate";
            this.Mon2Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tue2
            // 
            this.Tue2.BackColor = System.Drawing.SystemColors.Window;
            this.Tue2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tue2.Location = new System.Drawing.Point(193, 142);
            this.Tue2.Name = "Tue2";
            this.Tue2.Size = new System.Drawing.Size(65, 20);
            this.Tue2.TabIndex = 10;
            this.Tue2.Text = "Tue";
            this.Tue2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tue2Date
            // 
            this.Tue2Date.BackColor = System.Drawing.SystemColors.Window;
            this.Tue2Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tue2Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tue2Date.Location = new System.Drawing.Point(193, 162);
            this.Tue2Date.Name = "Tue2Date";
            this.Tue2Date.Size = new System.Drawing.Size(65, 14);
            this.Tue2Date.TabIndex = 9;
            this.Tue2Date.Text = "TueDate";
            this.Tue2Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Wed2
            // 
            this.Wed2.BackColor = System.Drawing.SystemColors.Window;
            this.Wed2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Wed2.Location = new System.Drawing.Point(257, 142);
            this.Wed2.Name = "Wed2";
            this.Wed2.Size = new System.Drawing.Size(65, 20);
            this.Wed2.TabIndex = 8;
            this.Wed2.Text = "Wed";
            this.Wed2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Wed2Date
            // 
            this.Wed2Date.BackColor = System.Drawing.SystemColors.Window;
            this.Wed2Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Wed2Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wed2Date.Location = new System.Drawing.Point(257, 162);
            this.Wed2Date.Name = "Wed2Date";
            this.Wed2Date.Size = new System.Drawing.Size(65, 14);
            this.Wed2Date.TabIndex = 7;
            this.Wed2Date.Text = "WedDate";
            this.Wed2Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Thu2
            // 
            this.Thu2.BackColor = System.Drawing.SystemColors.Window;
            this.Thu2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Thu2.Location = new System.Drawing.Point(321, 142);
            this.Thu2.Name = "Thu2";
            this.Thu2.Size = new System.Drawing.Size(65, 20);
            this.Thu2.TabIndex = 6;
            this.Thu2.Text = "Thu";
            this.Thu2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Thu2Date
            // 
            this.Thu2Date.BackColor = System.Drawing.SystemColors.Window;
            this.Thu2Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Thu2Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Thu2Date.Location = new System.Drawing.Point(321, 162);
            this.Thu2Date.Name = "Thu2Date";
            this.Thu2Date.Size = new System.Drawing.Size(65, 14);
            this.Thu2Date.TabIndex = 5;
            this.Thu2Date.Text = "ThuDate";
            this.Thu2Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Fri2
            // 
            this.Fri2.BackColor = System.Drawing.SystemColors.Window;
            this.Fri2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Fri2.Location = new System.Drawing.Point(385, 142);
            this.Fri2.Name = "Fri2";
            this.Fri2.Size = new System.Drawing.Size(65, 20);
            this.Fri2.TabIndex = 4;
            this.Fri2.Text = "Fri";
            this.Fri2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Fri2Date
            // 
            this.Fri2Date.BackColor = System.Drawing.SystemColors.Window;
            this.Fri2Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Fri2Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fri2Date.Location = new System.Drawing.Point(385, 162);
            this.Fri2Date.Name = "Fri2Date";
            this.Fri2Date.Size = new System.Drawing.Size(65, 14);
            this.Fri2Date.TabIndex = 3;
            this.Fri2Date.Text = "FriDate";
            this.Fri2Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Sat2
            // 
            this.Sat2.BackColor = System.Drawing.SystemColors.Window;
            this.Sat2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Sat2.Location = new System.Drawing.Point(449, 142);
            this.Sat2.Name = "Sat2";
            this.Sat2.Size = new System.Drawing.Size(65, 20);
            this.Sat2.TabIndex = 2;
            this.Sat2.Text = "Sat";
            this.Sat2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Sat2Date
            // 
            this.Sat2Date.BackColor = System.Drawing.SystemColors.Window;
            this.Sat2Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Sat2Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sat2Date.Location = new System.Drawing.Point(449, 162);
            this.Sat2Date.Name = "Sat2Date";
            this.Sat2Date.Size = new System.Drawing.Size(65, 14);
            this.Sat2Date.TabIndex = 1;
            this.Sat2Date.Text = "SatDate";
            this.Sat2Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Total1
            // 
            this.Total1.BackColor = System.Drawing.SystemColors.Window;
            this.Total1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Total1.Location = new System.Drawing.Point(513, 8);
            this.Total1.Name = "Total1";
            this.Total1.Size = new System.Drawing.Size(65, 34);
            this.Total1.TabIndex = 15;
            this.Total1.Text = "Total";
            this.Total1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Total2
            // 
            this.Total2.BackColor = System.Drawing.SystemColors.Window;
            this.Total2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Total2.Location = new System.Drawing.Point(513, 142);
            this.Total2.Name = "Total2";
            this.Total2.Size = new System.Drawing.Size(65, 34);
            this.Total2.TabIndex = 16;
            this.Total2.Text = "Total";
            this.Total2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_pending
            // 
            this.cb_pending.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_pending.Location = new System.Drawing.Point(129, 270);
            this.cb_pending.Name = "cb_pending";
            this.cb_pending.Size = new System.Drawing.Size(116, 23);
            this.cb_pending.TabIndex = 17;
            this.cb_pending.Text = "Assign to Pending";
            this.cb_pending.UseVisualStyleBackColor = true;
            // 
            // cb_cancel
            // 
            this.cb_cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cb_cancel.Location = new System.Drawing.Point(505, 269);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(75, 23);
            this.cb_cancel.TabIndex = 18;
            this.cb_cancel.Text = "Cancel";
            this.cb_cancel.UseVisualStyleBackColor = true;
            // 
            // WDailyArticalCounts
            // 
            this.AcceptButton = this.cb_ok;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(588, 304);
            this.Controls.Add(this.cb_cancel);
            this.Controls.Add(this.cb_pending);
            this.Controls.Add(this.Total2);
            this.Controls.Add(this.Total1);
            this.Controls.Add(this.Sat2Date);
            this.Controls.Add(this.Sat2);
            this.Controls.Add(this.Fri2Date);
            this.Controls.Add(this.Fri2);
            this.Controls.Add(this.Thu2Date);
            this.Controls.Add(this.Thu2);
            this.Controls.Add(this.Wed2Date);
            this.Controls.Add(this.Wed2);
            this.Controls.Add(this.Tue2Date);
            this.Controls.Add(this.Tue2);
            this.Controls.Add(this.Mon2Date);
            this.Controls.Add(this.Mon2);
            this.Controls.Add(this.Week2);
            this.Controls.Add(this.Sat1Date);
            this.Controls.Add(this.Sat1);
            this.Controls.Add(this.Fri1Date);
            this.Controls.Add(this.Fri1);
            this.Controls.Add(this.Thu1Date);
            this.Controls.Add(this.Thu1);
            this.Controls.Add(this.Wed1Date);
            this.Controls.Add(this.Wed1);
            this.Controls.Add(this.Tue1Date);
            this.Controls.Add(this.Tue1);
            this.Controls.Add(this.Mon1Date);
            this.Controls.Add(this.Mon1);
            this.Controls.Add(this.Week1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dw_artical_count2);
            this.Controls.Add(this.dw_artical_count1);
            this.Controls.Add(this.cb_ok);
            this.Controls.Add(this.cb_scaling);
            this.Name = "WDailyArticalCounts";
            this.Text = "Article Count Detail";
            this.Controls.SetChildIndex(this.cb_scaling, 0);
            this.Controls.SetChildIndex(this.cb_ok, 0);
            this.Controls.SetChildIndex(this.dw_artical_count1, 0);
            this.Controls.SetChildIndex(this.dw_artical_count2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.Week1, 0);
            this.Controls.SetChildIndex(this.Mon1, 0);
            this.Controls.SetChildIndex(this.Mon1Date, 0);
            this.Controls.SetChildIndex(this.Tue1, 0);
            this.Controls.SetChildIndex(this.Tue1Date, 0);
            this.Controls.SetChildIndex(this.Wed1, 0);
            this.Controls.SetChildIndex(this.Wed1Date, 0);
            this.Controls.SetChildIndex(this.Thu1, 0);
            this.Controls.SetChildIndex(this.Thu1Date, 0);
            this.Controls.SetChildIndex(this.Fri1, 0);
            this.Controls.SetChildIndex(this.Fri1Date, 0);
            this.Controls.SetChildIndex(this.Sat1, 0);
            this.Controls.SetChildIndex(this.Sat1Date, 0);
            this.Controls.SetChildIndex(this.Week2, 0);
            this.Controls.SetChildIndex(this.Mon2, 0);
            this.Controls.SetChildIndex(this.Mon2Date, 0);
            this.Controls.SetChildIndex(this.Tue2, 0);
            this.Controls.SetChildIndex(this.Tue2Date, 0);
            this.Controls.SetChildIndex(this.Wed2, 0);
            this.Controls.SetChildIndex(this.Wed2Date, 0);
            this.Controls.SetChildIndex(this.Thu2, 0);
            this.Controls.SetChildIndex(this.Thu2Date, 0);
            this.Controls.SetChildIndex(this.Fri2, 0);
            this.Controls.SetChildIndex(this.Fri2Date, 0);
            this.Controls.SetChildIndex(this.Sat2, 0);
            this.Controls.SetChildIndex(this.Sat2Date, 0);
            this.Controls.SetChildIndex(this.Total1, 0);
            this.Controls.SetChildIndex(this.Total2, 0);
            this.Controls.SetChildIndex(this.cb_pending, 0);
            this.Controls.SetChildIndex(this.cb_cancel, 0);
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

        #region Events
        private void uf_clear_parent_renewal(int? pContractNo, int? pRenewal)
        {
            // TJB  RPCR_093  Feb-2015
            // Changed name.  Removed skip of current row in parent.
            //
            // TJB RPCR_014 Oct-2010: New
            // Search dw_Parent for rows matching the contract and renewal.
            // Set the renewal for that/those row(s) to null.

            int nRow;
            int? nContractNo, nRenewal;

            for (nRow = 0; nRow < dw_Parent.RowCount; nRow++)
            {
                nContractNo = dw_Parent.GetItem<ContractArticalCounts>(nRow).ContractNo;
                nRenewal = dw_Parent.GetItem<ContractArticalCounts>(nRow).ContractSeqNumber;
                if (nContractNo == pContractNo)
                    if (!(nRenewal == null))        // Some of the rows may already have null for the renewal
                        if (nRenewal == pRenewal)
                            dw_Parent.GetItem<ContractArticalCounts>(nRow).ContractSeqNumber = null;
            }
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            int nRow;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            int? nContractNo;
            DateTime? dtStartWeek;
            Decimal? dScaleFactor;

            // bAssignToPending will be set if the user pressed the 'Assign To Pending' button.  
            // Acting on it is deferred to here.

            if (bAssignToPending)
            {
                // First, confirm the user still wants to do the assignment
                DialogResult Answer = MessageBox.Show("Please confirm that you want to add these counts to the pending contract."
                                                     , StaticVariables.MainMDI.Text
                                                     , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (Answer == DialogResult.Cancel)
                {
                    bAssignToPending = false;
                    cb_pending.Enabled = true;
                    return;
                }

                if (Answer == DialogResult.Yes)
                {
                    nRow = dw_Parent.GetRow();
                    nContractNo = Convert.ToInt32(dw_Parent.GetValue(nRow, "ContractNo"));
                    dtStartWeek = Convert.ToDateTime(dw_Parent.GetValue(nRow, "AcStartWeekPeriod"));
                    dScaleFactor = Convert.ToDecimal(dw_Parent.GetValue(nRow, "AcScaleFactor"));

                    // If the user has one or more article counts already assigned to the renewal,
                    // and the user has selected to make changes, bAssignToPending_ReplaceAll = YES
                    // If this contract has no counts already assigned, or none are to be replaced, 
                    // bAssignToPending_ReplaceAll = No
                    // In all cases the final thing is to add these counts to the renewal.

                    if (bAssignToPending_ReplaceAll == DialogResult.Yes)  // Replace all existing counts
                    {
                        // 'UnAssign' the old article count renewals
                        //UPDATE artical_count 
                        //   SET contract_seq_number = null 
                        // WHERE artical_count.contract_no = :lContract
                        //   AND artical_count.contract_seq_number = :ilRenewal 
                        RDSDataService.ClearArticalCountContractSeqNumber(nContractNo, nRenewal
                                                                          , ref SQLCode, ref SQLErrText);
                        if (SQLCode != 0)
                        {
                            MessageBox.Show("Error clearing previous weekly article counts \n\n"
                                           + SQLErrText
                                           , "SQL Error"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        // The above changes the database but doesn't update the retrieved data.
                        // uf_clear_parent_renewal searches the parent list and nulls the renewal.
                        // This is picked up in WContract to update the article count tab display
                        // to reflect all the changes.
                        uf_clear_parent_renewal(nContractNo, nRenewal);

                        //UPDATE artical_count_daily
                        //   SET contract_seq_number = null 
                        // WHERE artical_count.contract_no = :lContract
                        //   AND artical_count.contract_seq_number = :ilRenewal 
                        RDSDataService.ClearArticalCountDailyContractSeqNumber(nContractNo, nRenewal
                                                                          , ref SQLCode, ref SQLErrText);
                        if (SQLCode != 0)
                        {
                            MessageBox.Show("Error clearing previous daily article counts \n\n"
                                           + SQLErrText
                                           , "SQL Error"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // At this point, we know the user has asked to add this set of article counts to 
                    // the contract's pending renewal.  Any previous counts assigned will either have 
                    // been deassigned or left, as requested by the user.
                    // Now, all that's left to do is to assign these counts to the contract renewal. 

                    // First assign the weekly counts (in the Parent)

                    // Assign the weekly article counts to the renewal
                    //UPDATE artical_count 
                    //   SET contract_seq_number = :nRenewal 
                    // WHERE contract_no = :nContractNo
                    //   AND ac_start_week_period = :dtStartWeek 
                    RDSDataService.UpdateArticalCountContractSeqNumber(nContractNo, nRenewal, dtStartWeek, dScaleFactor
                                                                          , ref SQLCode, ref SQLErrText);
                    if (SQLCode != 0)
                    {
                        MessageBox.Show("Error assigning weekly artical counts to the renewal \n\n"
                                       + SQLErrText
                                       , "SQL Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Update the sequence number in the parent's datawindow
                    nRow = dw_Parent.GetRow();
                    dw_Parent.SetValue(nRow, "ContractSeqNumber", nRenewal);

                    // Now assign the daily counts (here)

                    // Assign the daily article counts to the renewal
                    //UPDATE artical_count_daily 
                    //   SET contract_seq_number = nRenewal 
                    // WHERE contract_no = nContractNo
                    //   AND ac_start_week_period = dtStartWeek 
                    RDSDataService.UpdateArticalCountDailyContractSeqNumber(nContractNo, nRenewal, dtStartWeek, dScaleFactor
                                                                                  , ref SQLCode, ref SQLErrText);
                    if (SQLCode != 0)
                    {
                        MessageBox.Show("Error assigning daily artical counts to the renewal \n\n"
                                       + SQLErrText
                                       , "SQL Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    nRow = dw_artical_count1.GetRow();
                    dw_artical_count1.GetItem<DailyArticalCounts>(nRow).MarkClean();
                    nRow = dw_artical_count2.GetRow();
                    dw_artical_count2.GetItem<DailyArticalCounts>(nRow).MarkClean();
                }
            }
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void cb_scaling_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dAcScaleFactor = dAcScaleFactor == null ? 0 : dAcScaleFactor;
            StaticMessage.DoubleParm = (double)dAcScaleFactor;
            WSetArticalCountsScalingFactor w_set_artical_counts_scaling_factor 
                        = new WSetArticalCountsScalingFactor();
            w_set_artical_counts_scaling_factor.ShowDialog();
        }
        #endregion

        private void cb_pending_clicked(object sender, EventArgs e)
        {
            int nRows = 0;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            bAssignToPending = true;

            // SELECT count(artical_count.contract_no)
            //  WHERE artical_count.contract_no = nContractNo
            //    AND artical_count.contract_seq_number = nRenewal
            nRows = RDSDataService.GetArticalCountRows(nContractNo, nRenewal);
            if (nRows > 0)
            {
                string sRows = (nRows > 1)
                             ? "are " + nRows.ToString() + " article counts"
                             : "is one article count";

                bAssignToPending_ReplaceAll
                    = MessageBox.Show("Warning: There " + sRows + " already assigned to this contract. \n"
                                     + "Do you wish to replace them?"
                                     , "Assign to Pending"
                                     , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                                     , MessageBoxDefaultButton.Button2);
                if (bAssignToPending_ReplaceAll == DialogResult.Cancel)
                {
                    bAssignToPending = false;
                    bAssignToPending_ReplaceAll = DialogResult.No;
                }
            }

            if (bAssignToPending)
                cb_pending.Enabled = false;
        }
    }
}