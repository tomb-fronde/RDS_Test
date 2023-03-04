using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using System.Collections.Generic;
using NZPostOffice.RDS.DataService;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Windows.Ruralwin2;
//************************************************************************************************
// Modifications
// 21 Jul 2008  Metex  Fix2 for Renewal bug.  See wf_assign
//************************************************************************************************

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WAssignArticleCountsBulk2001 : NZPostOffice.RDS.Controls.WMaster
    {
        // TJB RPCR_014 Oct-2010: Changed function name
        //    "UpdateArticalCountContractSeqNumber" to "ClearArticalCountContractSeqNumber"

        #region Define

        public Dictionary<int, int> lclist = new Dictionary<int, int>();//public IntArray lclist = new IntArray();

        public Dictionary<int, int> rlist = new Dictionary<int, int>();//public IntArray rlist = new IntArray();

        private System.ComponentModel.IContainer components = null;

        public RadioButton rb_last;

        public RadioButton rb_lastbutone;

        public RadioButton rb_ave;

        public GroupBox gb_1;

        public Button cb_1;

        public Button cb_2;

        #endregion

        public WAssignArticleCountsBulk2001()
        {
            this.InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        public override void pfc_postopen()
        {
            WRenewalProcess2006 w_caller;
            w_caller = StaticMessage.PowerObjectParm as WRenewalProcess2006;
            lclist = w_caller.lcontractlist;
            rlist = w_caller.lrenewallist;
            //this.ShowInTaskbar = false;
        }

        public virtual int wf_assign(string atype)
        {
            int lctr;
            int? lcount;
            int lcontract;
            int lrenewal;
            DateTime ldt_YearAgo;
            DateTime? ldt_LastCountDate;
            int li_Year;
            int li_Month;
            int li_Day;
            DateTime dStartDate = DateTime.MinValue;
            DateTime? t_dStartDate;
            int? lVolAtRen;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            for (lctr = 1; lctr <= lclist.Count; lctr++)
            {
                lcontract = lclist[lctr];
                lrenewal = rlist[lctr];
                li_Year = DateTime.Today.Year;
                li_Month = DateTime.Today.Month;
                li_Day = DateTime.Today.Day;
                if (li_Month == 2 && li_Day == 29)
                {
                    li_Day = 28;
                }
                // System.Convert.ToDateTime(li_Year - 1, li_Month, li_Day);
                ldt_YearAgo = new DateTime(li_Year - 1, li_Month, li_Day);

                //UPDATE artical_count 
                //   set contract_seq_number = null 
                // where contract_no = :lContract 
                //   and contract_seq_number = :lrenewal
                // TJB RPCR_014 Oct-2010: Changed function name ("UpdateArt..." to "ClearArt...")
                //RDSDataService.UpdateArticalCountContractSeqNumber(lcontract, lrenewal, ref SQLCode, ref SQLErrText);
                RDSDataService.ClearArticalCountContractSeqNumber(lcontract, lrenewal
                                                                 , ref SQLCode, ref SQLErrText);
                if (SQLCode < 0)
                {
                    MessageBox.Show(SQLErrText
                                   , "Error 1 - clear out assignments"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -(1);
                }
                //select count(contract_no) into :lcount 
                //  from artical_count 
                // where contract_no = :lContract 
                //   and contract_seq_number is null 
                //   and ac_start_week_period > :ldt_YearAgo
                lcount = RDSDataService.GetArticalCountConut(lcontract, ldt_YearAgo
                                                            , ref SQLCode, ref SQLErrText);
                if (SQLCode < 0)
                {
                    MessageBox.Show(SQLErrText
                                   , "Error 2- find article counts 1"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -(1);
                }
                int? TestExpr = lcount;
                if (TestExpr == 0)
                {
                    //select con_start_date into :dStartDate 
                    //  from contract_renewals 
                    // where contract_no = :lContract 
                    //   and contract_seq_number = :lrenewal - 1
                    //
                    // 21-Jul-2008  Metex Renewals fix2:  add "dStartDate ="
                    //        TJB   Added t_dStartDate to allow for possible null values
                    t_dStartDate = RDSDataService.GetContractRenewalsConStartDate(lcontract, lrenewal
                                                                                 , ref SQLCode, ref SQLErrText);
                    if (t_dStartDate != null)
                    {
                        dStartDate = (DateTime)t_dStartDate;
                    }
                    if (SQLCode < 0)
                    {
                        MessageBox.Show(SQLErrText + "\n\n" 
                                         + "The con_volume_at_renewal for the pending must be manually adjusted."
                                       , "Error 3a- update article count - case 0 for " + lcontract.ToString()
                                       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // 	return -1
                    }
                    /*select contract_renewals.con_volume_at_renewal 
                     *           + sum(ifnull(frequency_distances.fd_volume,0,frequency_distances.fd_volume)) 
                     *  into :lVolAtRen 
                     *  from contract_renewals
                     *     , route_frequency left outer join frequency_distances 
                     *                       on route_frequency.contract_no=frequency_distances.contract_no and
                     *                          route_frequency.sf_key=frequency_distances.sf_key and 
                     *                          route_frequency.rf_delivery_days=frequency_distances.rf_delivery_days and 
                     *                          frequency_distances.fd_effective_date>=:dStartDate 
                     *     , rate_days 
                     * where contract_renewals.contract_no = route_frequency.contract_no and
                     *       route_frequency.sf_key = rate_days.sf_key and
                     *       contract_renewals.con_rates_effective_date = rate_days.rr_rates_effective_date and	
                     *       contract_renewals.con_rg_code_at_renewal = rate_days.rg_code and
                     *       contract_renewals.contract_no = :lContract and	
                     *       contract_renewals.contract_seq_number = (:lrenewal - 1) 
                     * group by 
                     *       contract_renewals.contract_no, contract_renewals.con_volume_at_renewal;*/
                    lVolAtRen = RDSDataService.GetContractRenewalsConVolumeAtRenewal(dStartDate, lcontract, lrenewal, ref SQLCode, ref SQLErrText);
                    if (SQLCode < 0)
                    {
                        MessageBox.Show(SQLErrText + "\n" 
                                         + "The con_volume_at_renewal for the pending must be manually adjusted."
                                       , "Error 3b- update article count - case 0 for " + lcontract.ToString()
                                       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // return -1
                    }
                    /*UPDATE contract_renewals set con_volume_at_renewal = :lVolAtRen 
                     * where contract_no = :lContract and contract_seq_number = :lrenewal;*/
                    RDSDataService.UpdateContractRenewalsConVolumeAtRenewal(lVolAtRen, lcontract, lrenewal, ref SQLCode, ref SQLErrText);
                    if (SQLCode < 0)
                    {
                        MessageBox.Show(SQLErrText + "\n"
                                         + "The con_volume_at_renewal for the pending must be manually adjusted."
                                       , "Error 3c- update article count - case 0 for " + lcontract.ToString()
                                       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // return -1
                    }
                }
                else if (TestExpr == 1)
                {
                    /*UPDATE artical_count set contract_seq_number = :lrenewal 
                     * where contract_no = :lContract and
                     *       contract_seq_number is null and 
                     *       artical_count.ac_start_week_period > :ldt_YearAgo;*/
                    RDSDataService.UpdateArticalCountContractSeqNumber1(lrenewal, lcontract, ldt_YearAgo, ref SQLCode, ref SQLErrText);
                    if (SQLCode < 0)
                    {
                        MessageBox.Show(SQLErrText
                                       , "Error 3- update article count - case 1"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -(1);
                    }
                }
                else
                {
                    string TestExpr1 = atype.ToString();
                    if (TestExpr1 == "last")
                    {
                        /*UPDATE artical_count set contract_seq_number=:lrenewal 
                         * where contract_no = :lContract and 
                         *       (contract_seq_number is null 
                         *          or contract_seq_number = :lrenewal) and 
                         *       ac_start_week_period = (select max(ac_start_week_period) 
                         *                                 from artical_count as a2 
                         *                                where a2.contract_no = :lContract and 
                         *                                      (contract_seq_number is null 
                         *                                         or contract_seq_number = :lrenewal) and 
                         *                                      ac_start_week_period > :ldt_YearAgo);*/
                        RDSDataService.UpdateArticalCountContractSeqNumber2(lrenewal, lcontract, ldt_YearAgo, ref SQLCode, ref SQLErrText);
                        if (SQLCode < 0)
                        {
                            //rollback;
                            MessageBox.Show(SQLErrText
                                           , "Error 4- update article count - case last 1"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -(1);
                        }
                    }
                    else if (TestExpr1 == "lastbutone")
                    {
                        /*select max(ac_start_week_period) into	:ldt_LastCountDate 
                         *  from artical_count as a2 
                         * where a2.contract_no = :lContract and 
                         *       (contract_seq_number is null or contract_seq_number = :lrenewal) and
                         *       ac_start_week_period > :ldt_YearAgo;*/
                        ldt_LastCountDate = RDSDataService.GetArticalCountAcStartWeekPeriodMax(lcontract, lrenewal, ldt_YearAgo, ref SQLCode, ref SQLErrText);
                        if (SQLCode < 0)
                        {
                            //rollback;
                            MessageBox.Show(SQLErrText
                                           , "Error 5- select max(ac_start_week_period) - case last but one"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -(1);
                        }
                        //UPDATE artical_count set contract_seq_number=lrenewal 
                        // where contract_no=lContract  
                        //   and (contract_seq_number is null 
                        //         or contract_seq_number=lrenewal)
                        //   and ac_start_week_period = 
                        //               (select max(ac_start_week_period) 
                        //                  from artical_count as a2 
                        //                 where a2.contract_no = lContract 
                        //                   and (contract_seq_number is null 
                        //                        or contract_seq_number = lrenewal) 
                        //                   and ac_start_week_period > ldt_YearAgo  
                        //                   and ac_start_week_period < ldt_LastCountDate)
                        RDSDataService.UpdateArticalCountContractSeqNumber3(lrenewal, lcontract, ldt_YearAgo, ldt_LastCountDate, ref SQLCode, ref SQLErrText);
                        if (SQLCode < 0)
                        {
                            //rollback;
                            MessageBox.Show(SQLErrText
                                           , "Error 6- update article count - case last but one"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -(1);
                        }
                    }
                    else if (TestExpr1 == "average")
                    {
                        //UPDATE artical_count set contract_seq_number=:lrenewal 
                        // where contract_no=:lContract 
                        //   and (contract_seq_number is null or contract_seq_number=:lrenewal) 
                        //   and ac_start_week_period = 
                        //                (select max(ac_start_week_period) 
                        //                   from artical_count as a2 
                        //                  where a2.contract_no = :lContract 
                        //                    and (contract_seq_number is null 
                        //                          or contract_seq_number = :lrenewal)  
                        //                    and ac_start_week_period > :ldt_YearAgo)
                        RDSDataService.UpdateArticalCountContractSeqNumber2(lrenewal, lcontract, ldt_YearAgo, ref SQLCode, ref SQLErrText);
                        if (SQLCode < 0)
                        {
                            //rollback;
                            MessageBox.Show(SQLErrText
                                           , "Error 7- update article count - case average"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -(1);
                        }
                        /*select max(ac_start_week_period) into	:ldt_LastCountDate 
                         *  from artical_count as a2 
                         * where a2.contract_no = :lContract and
                         *      (contract_seq_number is null or contract_seq_number = :lrenewal) and
                         *      ac_start_week_period > :ldt_YearAgo;*/
                        ldt_LastCountDate = RDSDataService.GetArticalCountAcStartWeekPeriodMax(lcontract, lrenewal, ldt_YearAgo, ref SQLCode, ref SQLErrText);
                        if (SQLCode < 0)
                        {
                            //rollback;
                            MessageBox.Show(SQLErrText
                                           , "Error 8- max ac_start_week_period 2"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -(1);
                        }
                        /*UPDATE artical_count set contract_seq_number=:lrenewal 
                         * where contract_no = :lContract and 
                         *       (contract_seq_number is null or contract_seq_number=:lrenewal) and 
                         *       ac_start_week_period = (select max(ac_start_week_period) 
                         *                                 from artical_count as a2 
                         *                                where a2.contract_no = :lContract and 
                         *                                      (contract_seq_number is null 
                         *                                         or contract_seq_number = :lrenewal) and 
                         *                                      ac_start_week_period > :ldt_YearAgo and 
                         *                                      ac_start_week_period < :ldt_LastCountDate);*/
                        RDSDataService.UpdateArticalCountContractSeqNumber3(lrenewal, lcontract, ldt_YearAgo, ldt_LastCountDate, ref SQLCode, ref SQLErrText);
                        if (SQLCode < 0)
                        {
                            //rollback;
                            MessageBox.Show(SQLErrText
                                           , "Error 9- update article count - last article count but one 2"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -(1);
                        }
                    }
                }
            }
            //commit;
            return 1;
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.rb_last = new RadioButton();
            this.rb_lastbutone = new RadioButton();
            this.rb_ave = new RadioButton();
            this.gb_1 = new GroupBox();
            this.cb_1 = new Button();
            this.cb_2 = new Button();
            Controls.Add(rb_last);
            Controls.Add(rb_lastbutone);
            Controls.Add(rb_ave);
            Controls.Add(gb_1);
            Controls.Add(cb_1);
            Controls.Add(cb_2);
            this.Text = "Assign Volumes to Pending";
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(226, 118);
            this.Location = new System.Drawing.Point(46, 55);

            // 
            // rb_last
            // 
            rb_last.Text = "Last";
            rb_last.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            rb_last.Size = new System.Drawing.Size(54, 19);
            rb_last.Location = new System.Drawing.Point(10, 22);
            // 
            // rb_lastbutone
            // 
            rb_lastbutone.Text = "Last But One";
            rb_lastbutone.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            rb_lastbutone.Size = new System.Drawing.Size(97, 19);
            rb_lastbutone.Location = new System.Drawing.Point(10, 39);
            // 
            // rb_ave
            // 
            rb_ave.Text = "Average of Last Two";
            rb_ave.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            rb_ave.Size = new System.Drawing.Size(126, 19);
            rb_ave.Location = new System.Drawing.Point(10, 57);
            // 
            // gb_1
            // 
            gb_1.Text = "Article count";
            gb_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            gb_1.TabIndex = 2;
            gb_1.Size = new System.Drawing.Size(135, 81);
            gb_1.Location = new System.Drawing.Point(5, 5);
            // 
            // cb_1
            // 
            cb_1.Text = "&Assign";
            cb_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_1.TabIndex = 3;
            cb_1.Size = new System.Drawing.Size(61, 25);
            cb_1.Location = new System.Drawing.Point(149, 26);
            cb_1.Click += new EventHandler(cb_1_clicked);
            // 
            // cb_2
            // 
            cb_2.Text = "&Close";
            cb_2.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_2.TabIndex = 1;
            cb_2.Size = new System.Drawing.Size(61, 25);
            cb_2.Location = new System.Drawing.Point(149, 62);
            cb_2.Click += new EventHandler(cb_2_clicked);
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
        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            int lret = 0;
            if (rb_last.Checked)
            {
                lret = wf_assign("last");
            }
            else if (rb_lastbutone.Checked)
            {
                lret = wf_assign("lastbutone");
            }
            else if (rb_ave.Checked)
            {
                lret = wf_assign("average");
            }
            StaticMessage.DoubleParm = lret;//CloseWithReturn(parent, lret);
            this.Close();
            return;
        }

        public virtual void cb_2_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}