using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.Shared.VisualComponents;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using Metex.Windows;
using NZPostOffice.RDS.Entity.Ruralwin2;
using NZPostOffice.RDS.DataService;
using System.Reflection;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    // TJB  Jan-2021
    // Added Label1 (window name) to aid debugging
    //
    // TJB  Aug-2013
    // Minor formatting and comment changes

    public class WWhatifFreqs2001 : WMaster
    {
        #region Define
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        private WWhatifCalc2001 Iw_whatif_calc;

        public int iContract;

        public int iContractRow;

        public int il_row;

        public int il_rgcode;

        public DateTime id_EffectiveDate = DateTime.MinValue;

        public decimal id_RateOf;

        public Dictionary<int, decimal> idec_Current = new Dictionary<int, decimal>();// DecimalArray idec_Current = new DecimalArray();

        public Button cb_ok;

        public Button cb_cancel;

        public Button cb_1;

        public NumericalMaskedTextBox em_1;

        public Label st_1;

        public NumericalMaskedTextBox em_2;

        public Label st_2;

        public URdsDw dw_1;

        private Label label1;

        public GroupBox gb_2;

        public GroupBox gb_1;

        #endregion

        public WWhatifFreqs2001()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;

            this.dw_1.DataObject = new DWhatifFreqs();
            dw_1.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //jlwang:moved from IC
            dw_1.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_1_constructor);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //jlwang:end
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_ok = new System.Windows.Forms.Button();
            this.cb_cancel = new System.Windows.Forms.Button();
            this.cb_1 = new System.Windows.Forms.Button();
            this.em_1 = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.st_1 = new System.Windows.Forms.Label();
            this.em_2 = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.st_2 = new System.Windows.Forms.Label();
            this.dw_1 = new NZPostOffice.RDS.Controls.URdsDw();
            this.gb_2 = new System.Windows.Forms.GroupBox();
            this.gb_1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_ok
            // 
            this.cb_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_ok.Location = new System.Drawing.Point(273, 306);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(53, 22);
            this.cb_ok.TabIndex = 5;
            this.cb_ok.Text = "&Ok";
            this.cb_ok.Click += new System.EventHandler(this.cb_ok_clicked);
            // 
            // cb_cancel
            // 
            this.cb_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_cancel.Location = new System.Drawing.Point(344, 306);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(54, 22);
            this.cb_cancel.TabIndex = 7;
            this.cb_cancel.Text = "&Cancel";
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_clicked);
            // 
            // cb_1
            // 
            this.cb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_1.Location = new System.Drawing.Point(154, 202);
            this.cb_1.Name = "cb_1";
            this.cb_1.Size = new System.Drawing.Size(100, 22);
            this.cb_1.TabIndex = 6;
            this.cb_1.Text = "Insert Frequency";
            this.cb_1.Click += new System.EventHandler(this.cb_1_clicked);
            // 
            // em_1
            // 
            this.em_1.EditMask = "#0.00";
            this.em_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.em_1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.em_1.Location = new System.Drawing.Point(299, 261);
            this.em_1.Name = "em_1";
            this.em_1.PromptChar = ' ';
            this.em_1.Size = new System.Drawing.Size(64, 20);
            this.em_1.TabIndex = 2;
            this.em_1.Text = "0.00";
            this.em_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.em_1.Value = "0.00";
            this.em_1.LostFocus += new System.EventHandler(this.em_1_LostFocus);
            // 
            // st_1
            // 
            this.st_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_1.Location = new System.Drawing.Point(220, 264);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(80, 18);
            this.st_1.TabIndex = 8;
            this.st_1.Text = "Delivery Hours";
            // 
            // em_2
            // 
            this.em_2.EditMask = "#,###,###";
            this.em_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.em_2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.em_2.Location = new System.Drawing.Point(63, 261);
            this.em_2.Name = "em_2";
            this.em_2.PromptChar = ' ';
            this.em_2.Size = new System.Drawing.Size(83, 20);
            this.em_2.TabIndex = 4;
            this.em_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.em_2.Value = "";
            this.em_2.LostFocus += new System.EventHandler(this.em_2_LostFocus);
            // 
            // st_2
            // 
            this.st_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_2.Location = new System.Drawing.Point(17, 264);
            this.st_2.Name = "st_2";
            this.st_2.Size = new System.Drawing.Size(43, 18);
            this.st_2.TabIndex = 9;
            this.st_2.Text = "Volume";
            // 
            // dw_1
            // 
            this.dw_1.DataObject = null;
            this.dw_1.FireConstructor = false;
            this.dw_1.Location = new System.Drawing.Point(17, 27);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(369, 167);
            this.dw_1.TabIndex = 1;
            // 
            // gb_2
            // 
            this.gb_2.BackColor = System.Drawing.SystemColors.Control;
            this.gb_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_2.Location = new System.Drawing.Point(7, 6);
            this.gb_2.Name = "gb_2";
            this.gb_2.Size = new System.Drawing.Size(391, 228);
            this.gb_2.TabIndex = 1;
            this.gb_2.TabStop = false;
            this.gb_2.Text = "Frequencies";
            // 
            // gb_1
            // 
            this.gb_1.BackColor = System.Drawing.SystemColors.Control;
            this.gb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_1.Location = new System.Drawing.Point(7, 242);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(391, 53);
            this.gb_1.TabIndex = 3;
            this.gb_1.TabStop = false;
            this.gb_1.Text = "Volume and Hours";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "WWhatifFreqs2001";
            // 
            // WWhatifFreqs2001
            // 
            this.AcceptButton = this.cb_ok;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.cb_cancel;
            this.ClientSize = new System.Drawing.Size(404, 343);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_ok);
            this.Controls.Add(this.cb_cancel);
            this.Controls.Add(this.cb_1);
            this.Controls.Add(this.em_1);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.em_2);
            this.Controls.Add(this.st_2);
            this.Controls.Add(this.dw_1);
            this.Controls.Add(this.gb_2);
            this.Controls.Add(this.gb_1);
            this.Location = new System.Drawing.Point(46, 55);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WWhatifFreqs2001";
            this.Text = "What If Frequency Changer";
            this.Controls.SetChildIndex(this.gb_1, 0);
            this.Controls.SetChildIndex(this.gb_2, 0);
            this.Controls.SetChildIndex(this.dw_1, 0);
            this.Controls.SetChildIndex(this.st_2, 0);
            this.Controls.SetChildIndex(this.em_2, 0);
            this.Controls.SetChildIndex(this.st_1, 0);
            this.Controls.SetChildIndex(this.em_1, 0);
            this.Controls.SetChildIndex(this.cb_1, 0);
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.cb_ok, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void em_1_LostFocus(object sender, EventArgs e)
        {
            string ls = em_1.Value;
        }

        void em_2_LostFocus(object sender, EventArgs e)
        {
            string ls = em_2.Value;
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

        public override void open()
        {
            base.open();
            int lLoop;
            int ll_Row;
            int ll_ConRow;
            int ll_ConRowCount;
            string sDelDays;
            NRdsMsg lnv_msg;
            NCriteria lnv_Criteria;
            lnv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            lnv_Criteria = lnv_msg.of_getcriteria();
            //?dw_1.settransobject(StaticVariables.sqlca);
            iContract = System.Convert.ToInt32(lnv_Criteria.of_getcriteria("contract_no"));
            Iw_whatif_calc = (WWhatifCalc2001)lnv_Criteria.of_getcriteria("caller");
            id_RateOf = System.Convert.ToDecimal(lnv_Criteria.of_getcriteria("rateofreturn_1"));
            ll_ConRow = System.Convert.ToInt32(lnv_Criteria.of_getcriteria("conrow"));
            ll_ConRowCount = System.Convert.ToInt32(lnv_Criteria.of_getcriteria("rowcount"));
            em_1.Value = System.Convert.ToDouble(lnv_Criteria.of_getcriteria("deliveryhours")).ToString("#0.00"); //em_1.Text = lnv_Criteria.of_getcriteria("deliveryhours").ToString();
            em_2.Value = System.Convert.ToDouble(lnv_Criteria.of_getcriteria("volume")).ToString("#,###,###");//em_2.Text = lnv_Criteria.of_getcriteria("volume").ToString();
            id_EffectiveDate = System.Convert.ToDateTime(lnv_Criteria.of_getcriteria("effectivedate"));
            il_rgcode = System.Convert.ToInt32(lnv_Criteria.of_getcriteria("rgcode"));
            iContractRow = ll_ConRow;
            if (ll_ConRow >= 0)
            {
                for (lLoop = 0; lLoop < ll_ConRowCount; lLoop++)
                {
                    // Set data from caller
                    ll_Row = 0;
                    dw_1.InsertItem<WhatifFreqs>(0);
                    dw_1.SetValue(ll_Row, "sf_key", Iw_whatif_calc.idw_summary.GetItem<WhatifCalulator2005>(ll_ConRow).SfKey);// "sf_key"));
                    dw_1.SetValue(ll_Row, "rf_distance", Iw_whatif_calc.idw_summary.GetItem<WhatifCalulator2005>(ll_ConRow).RfDistance);// "rf_distance"));
                    dw_1.SetValue(ll_Row, "rf_active", Iw_whatif_calc.idw_summary.GetItem<WhatifCalulator2005>(ll_ConRow).RfActive);// "rf_active"));
                    sDelDays = Iw_whatif_calc.idw_summary.GetItem<WhatifCalulator2005>(ll_ConRow).RfDeliverydays;//, "rf_deliverydays");
                    // Set delivery days from caller
                    dw_1.SetValue(ll_Row, "rf_monday", sDelDays.Substring(0, 1));
                    dw_1.SetValue(ll_Row, "rf_tuesday", sDelDays.Substring(1, 1));
                    dw_1.SetValue(ll_Row, "rf_wednesday", sDelDays.Substring(2, 1));
                    dw_1.SetValue(ll_Row, "rf_thursday", sDelDays.Substring(3, 1));
                    dw_1.SetValue(ll_Row, "rf_friday", sDelDays.Substring(4, 1));
                    dw_1.SetValue(ll_Row, "rf_saturday", sDelDays.Substring(5, 1));
                    dw_1.SetValue(ll_Row, "rf_sunday", sDelDays.Substring(6, 1));
                    ll_ConRow++;
                    if (ll_ConRow < ll_ConRowCount)
                    {
                        if (Iw_whatif_calc.idw_summary.GetItem<WhatifCalulator2005>(ll_ConRow).ContractNo != iContract)
                        {
                            lLoop = ll_ConRowCount;
                        }
                    }
                    else
                    {
                        lLoop = ll_ConRowCount;
                    }
                }
            }
            dw_1.DataObject.SortString = "sf_key A,rf_active A,rf_distance A";
            dw_1.Sort<WhatifFreqs>();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname("What-If Frequencies");
        }

        public virtual void dw_1_constructor()
        {
            dw_1.of_SetUpdateable(false);
        }

        public virtual void ue_dwnrbuttonclk()
        {
            // m_Main_Menu mCurrent
            // 
            // mCurrent = g_system.w_active_sheet.menuid
            // 
            // //! Defect. PaulA. 30July.  Null Object reference. 
            // 
            // if isValid ( mCurrent) then
            // 	mCurrent.m_record.PopMenu ( This.PointerX ( ),This.PointerY ( ))
            // end if
            // 
        }

        #region Events
        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            int lRow;
            int lRowCount;
            int lConRow;
            int lDelDays = 0;
            int lSFKey;
            int? lNumDays;
            int lRow2;
            int lBaseRow;
            int ll_count = 0;
            string sDelDays;
            string[] sCalcDelDays = new string[7];
            string sDay = string.Empty;
            decimal decDelHrs;
            decimal d2RateofReturnCost;
            decimal decVolume;
            decimal? decItems;

            DataUserControl dwChild;
            int iDelDays = 0;
            int iWeekDelDays;
            int iDays;
            int li_delivery;
            int li_max;
            int ll_RowCount;
            string ls_Active;
            ll_RowCount = dw_1.RowCount;
            // Get rf_active for the last row??????
            ls_Active = dw_1.GetItem<WhatifFreqs>(ll_RowCount-1).RfActive;//.getitemstring(ll_RowCount, "rf_active");
            // Delete nothing?????
            if (il_row == 1 && ls_Active == "N")
            {
                dw_1.DataObject.DeleteItemAt(ll_count);
            }
            // Accept changes
            dw_1.AcceptText();
            // Loop 3 times?
            ll_count = 1;
            while (!(ll_count == 3))
            {
                // Initally set up del days to N's
                sCalcDelDays = new string[] { "N", "N", "N", "N", "N", "N", "N" };

                // Set up contract number to what has been 'highlighted' on the calling window!
                lConRow = iContractRow;
                lBaseRow = iContractRow;
                decDelHrs = System.Convert.ToDecimal(em_1.Text);
                decVolume = System.Convert.ToDecimal(em_2.Text);

             //   dwChild = dw_1.DataObject.GetChild("sf_key");

                dwChild = new DDddwStandardFrequency();
                dwChild.BindingSource.DataSource = ((Metex.Windows.DataGridViewEntityComboColumn)(((Metex.Windows.DataEntityGrid)(dw_1.GetControlByName("grid"))).Columns["sf_key"])).DataSource;
             
                // Check delivery days
                lRowCount = dw_1.RowCount;

                 
                for (lRow = 0; lRow < lRowCount; lRow++)
                {
                    lNumDays = dw_1.GetItem<WhatifFreqs>(lRow).CalcDeldays;
                    lSFKey = dw_1.GetItem<WhatifFreqs>(lRow).SfKey.Value;
                    // 
                    lRow2 = dwChild.Find("sf_key", lSFKey.ToString());//.Length);
                    if (lRow2 > 0)
                    {

                        if (dwChild.GetValue<int>(lRow2, "sf_days_week") != lNumDays)
                        {
                            MessageBox.Show("The delivery days selected does not equal the number of days specified for this frequency", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);//parent.Title );
                            return;
                        }

                    }
                    // ! Defect###. PaulA. 29July. Delivery days not being recalulated 
                    if (dw_1.GetItem<WhatifFreqs>(lRow).RfActive == "Y")
                    {
                        for (iDays = 1; iDays <= 7; iDays += 1)
                        {
                            // PowerBuilder 'Choose Case' statement converted into 'if' statement
                            long TestExpr = iDays;
                            if (TestExpr == 1)      sDay = "monday";
                            else if (TestExpr == 2) sDay = "tuesday";
                            else if (TestExpr == 3) sDay = "wednesday";
                            else if (TestExpr == 4) sDay = "thursday";
                            else if (TestExpr == 5) sDay = "friday";
                            else if (TestExpr == 6) sDay = "saturday";
                            else if (TestExpr == 7) sDay = "sunday";
                            if (dw_1.GetValue(lRow, "rf_" + sDay).ToString() == "Y")
                            {
                                sCalcDelDays[iDays] = "Y";
                            }
                        }
                    }
                    // end defect
                }
                // !### Count del days total
                iWeekDelDays = 0;
                for (iDays = 1; iDays <= 7; iDays += 1)
                {
                    if (sCalcDelDays[iDays - 1] == "Y")
                    {
                        iWeekDelDays++;
                    }
                }
                // find days per annum for rg with selected date
                //SELECT max(rtd_days_per_annum) INTO :iDelDays FROM standard_frequency join rate_days on standard_frequency.sf_key 	= rate_days.sf_key 	and rate_days.rg_code = :il_RgCode and rate_days.rr_rates_effective_date= :id_EffectiveDate and standard_frequency.sf_days_week	= :iWeekDelDays;
                iDelDays = RDSDataService.GetStandardFrequencyValues(il_rgcode, id_EffectiveDate, iWeekDelDays);

                //  PBY SR#4466 If route frequency is 5 days or above, prorata using 6/6 instead of 5/6
                if (iWeekDelDays > 4)
                {
                    iDelDays = System.Convert.ToInt32(Iw_whatif_calc.idw_summary.GetValue(lConRow, "Maxdeliverydays"));
                }
                for (lRow = 0; lRow < lRowCount; lRow++)
                {
                    if (Iw_whatif_calc.idw_summary.RowCount <= lConRow)
                    {
                        //?Iw_whatif_calc.idw_summary.RowsCopy(iContractRow, iContractRow, primary!, Iw_whatif_calc.idw_summary, Iw_whatif_calc.idw_summary.RowCount + 1, primary!);
                        WhatifCalulator2005 l_old = Iw_whatif_calc.idw_summary.GetItem<WhatifCalulator2005>(iContractRow);
                        WhatifCalulator2005 l_new = new WhatifCalulator2005();
                        foreach (PropertyInfo var in typeof(WhatifCalulator2005).GetProperties())
                        {
                            if (var.CanWrite)
                            {
                                var.SetValue(l_new, var.GetValue(l_old, null), null);
                            }
                        }
                        Iw_whatif_calc.idw_summary.InsertItem<WhatifCalulator2005>(Iw_whatif_calc.idw_summary.RowCount,l_new);
                        lConRow = Iw_whatif_calc.idw_summary.RowCount - 1;
                        Iw_whatif_calc.idw_summary.SetValue(lConRow, "firstrow", "N");
                    }
                    else if (Iw_whatif_calc.idw_summary.GetItem<WhatifCalulator2005>(lConRow).ContractNo != iContract)
                    {
                        //?Iw_whatif_calc.idw_summary.RowsCopy(iContractRow, iContractRow, primary!, Iw_whatif_calc.idw_summary, lConRow, primary!);
                        WhatifCalulator2005 l_old = Iw_whatif_calc.idw_summary.GetItem<WhatifCalulator2005>(iContractRow);
                        WhatifCalulator2005 l_new = new WhatifCalulator2005();
                        foreach (PropertyInfo var in typeof(WhatifCalulator2005).GetProperties(System.Reflection.BindingFlags.SetProperty))
                        {
                            if (var.CanWrite)
                            {
                                var.SetValue(l_new, var.GetValue(l_old, null), null);
                            }
                        }
                        Iw_whatif_calc.idw_summary.InsertItem<WhatifCalulator2005>(lConRow,l_new);
                        Iw_whatif_calc.idw_summary.SetValue(lConRow, "firstrow", "N");
                    }
                    if (Iw_whatif_calc.idw_summary.GetValue(lConRow, "deliverydays") == null)
                    {
                        Iw_whatif_calc.idw_summary.SetValue(lConRow, "deliverydays",System.Convert.ToDecimal(0));
                    }
                    if (Iw_whatif_calc.idw_summary.GetValue(lConRow, "maxdeliverydays") == null)
                    {
                        Iw_whatif_calc.idw_summary.SetValue(lConRow, "maxdeliverydays",System.Convert.ToDecimal(0));
                    }
                    if (Iw_whatif_calc.idw_summary.GetItem<WhatifCalulator2005>(lConRow).Deliverydays == 0 
                        || Iw_whatif_calc.idw_summary.GetItem<WhatifCalulator2005>(lConRow).Maxdeliverydays == 0)
                    {
                        d2RateofReturnCost = 0;
                    }
                    else
                    {
                        d2RateofReturnCost = Iw_whatif_calc.idw_summary.GetItem<WhatifCalulator2005>(lConRow).Rateofreturn1.Value 
                                                 / (Math.Max(Iw_whatif_calc.idw_summary.GetItem<WhatifCalulator2005>(lConRow).Deliverydays.Value, 1m) / Math.Max(Iw_whatif_calc.idw_summary.GetItem<WhatifCalulator2005>(lConRow).Maxdeliverydays.Value, 1m));
                        d2RateofReturnCost = d2RateofReturnCost * iDelDays / Math.Max(Iw_whatif_calc.idw_summary.GetItem<WhatifCalulator2005>(lConRow).Maxdeliverydays.Value, 1m);
                    }
                    Iw_whatif_calc.idw_summary.SetValue(lConRow, "rateofreturn_1", d2RateofReturnCost);
                    Iw_whatif_calc.idw_summary.SetValue(lConRow, "rf_distance", dw_1.GetItem<WhatifFreqs>(lRow).RfDistance);
                    Iw_whatif_calc.idw_summary.SetValue(lConRow, "sf_key", dw_1.GetItem<WhatifFreqs>(lRow).SfKey);
                    Iw_whatif_calc.idw_summary.SetValue(lConRow, "rf_active", dw_1.GetItem<WhatifFreqs>(lRow).RfActive);
                    Iw_whatif_calc.idw_summary.SetValue(lConRow, "deliveryhours", decDelHrs);
                    decItems = decVolume / Iw_whatif_calc.idw_summary.GetItem<WhatifCalulator2005>(lConRow).Numberboxholders;
                    Iw_whatif_calc.idw_summary.SetValue(lConRow, "itemspercust", decItems);
                    sDelDays = dw_1.GetItem<WhatifFreqs>(lRow).RfMonday + dw_1.GetItem<WhatifFreqs>(lRow).RfTuesday + dw_1.GetItem<WhatifFreqs>(lRow).RfWednesday + dw_1.GetItem<WhatifFreqs>(lRow).RfThursday + dw_1.GetItem<WhatifFreqs>(lRow).RfFriday + dw_1.GetItem<WhatifFreqs>(lRow).RfSaturday + dw_1.GetItem<WhatifFreqs>(lRow).RfSunday;
                    Iw_whatif_calc.idw_summary.SetValue(lConRow, "deliverydays", System.Convert.ToDecimal(iDelDays));
                    lSFKey = dw_1.GetItem<WhatifFreqs>(lRow).SfKey.Value;

                    //SELECT rtd_days_per_annum INTO :lDelDays FROM rate_days WHERE rg_code = :il_RgCode AND rr_rates_effective_date = :id_EffectiveDate AND sf_key = :lSfKey;
                    lDelDays = RDSDataService.GetRateDaysValue(il_rgcode, id_EffectiveDate, lSFKey);

                    Iw_whatif_calc.idw_summary.SetValue(lConRow, "rf_deliverydays", sDelDays);
                    Iw_whatif_calc.idw_summary.SetValue(lConRow, "rf_daysyear", lDelDays);
                    lConRow++;
                }
                lRowCount = Iw_whatif_calc.idw_summary.RowCount;
                if (lRowCount > 0)
                {
                    for (lRow = 0; lRow < lRowCount; lRow++)
                    {
                        idec_Current[lRow] = Iw_whatif_calc.idw_summary.GetValue<decimal>(lRow, "opcost");
                    }
                }
                ll_count = ll_count + 1;
            }
            Iw_whatif_calc.store_group_value();
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            //il_row = dw_1.scrolltorow(dw_1.insertrow(0));
            dw_1.InsertRow(dw_1.RowCount);
            dw_1.SetCurrent(dw_1.RowCount - 1);
            il_row = 0;
        }
        #endregion
    }
}
