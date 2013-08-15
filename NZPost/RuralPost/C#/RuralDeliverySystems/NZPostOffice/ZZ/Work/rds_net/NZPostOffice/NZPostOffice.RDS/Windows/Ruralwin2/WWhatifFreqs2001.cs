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
            this.SuspendLayout();
            this.cb_ok = new Button();
            this.cb_cancel = new Button();
            this.cb_1 = new Button();
            this.em_1 = new NumericalMaskedTextBox();
            this.st_1 = new Label();
            this.em_2 = new NumericalMaskedTextBox();
            this.st_2 = new Label();
            dw_1 = new URdsDw();
//!            this.dw_1.DataObject = new DWhatifFreqs();
            this.gb_2 = new GroupBox();
            this.gb_1 = new GroupBox();
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            Controls.Add(cb_1);
            Controls.Add(em_1);
            Controls.Add(st_1);
            Controls.Add(em_2);
            Controls.Add(st_2);
            Controls.Add(dw_1);
            Controls.Add(gb_2);
            Controls.Add(gb_1);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Text = "What If Frequency Changer";
            this.Size = new System.Drawing.Size(412, 370);
            this.Location = new System.Drawing.Point(46, 55);
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // 
            // cb_ok
            // 
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&Ok";
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_ok.TabIndex = 5;
            cb_ok.Size = new System.Drawing.Size(53, 22);
            cb_ok.Location = new System.Drawing.Point(273, 306);
            cb_ok.Click += new EventHandler(cb_ok_clicked);

            // 
            // cb_cancel
            // 
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_cancel.TabIndex = 7;
            cb_cancel.Size = new System.Drawing.Size(54, 22);
            cb_cancel.Location = new System.Drawing.Point(344, 306);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);

            // 
            // cb_1
            // 
            cb_1.Text = "Insert Frequency";
            cb_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_1.TabIndex = 6;
            cb_1.Size = new System.Drawing.Size(100, 22);
            cb_1.Location = new System.Drawing.Point(154, 202);
            cb_1.Click += new EventHandler(cb_1_clicked);

            // 
            // em_1
            // 
            em_1.EditMask = "#0.00";
            em_1.TextAlign = HorizontalAlignment.Right;
            em_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            em_1.TabIndex = 2;
            em_1.Size = new System.Drawing.Size(64, 21);
            em_1.Location = new System.Drawing.Point(299, 261);
            em_1.LostFocus += new EventHandler(em_1_LostFocus);

            // 
            // st_1
            // 
            st_1.TabStop = false;
            st_1.Text = "Delivery Hours";
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_1.Size = new System.Drawing.Size(80, 18);
            st_1.Location = new System.Drawing.Point(220, 264);
        
            // 
            // em_2
            // 
            em_2.EditMask = "#,###,###";
            em_2.TextAlign = HorizontalAlignment.Right; 
            em_2.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            em_2.TabIndex = 4;
            em_2.Size = new System.Drawing.Size(83, 21);
            em_2.Location = new System.Drawing.Point(63, 261);
            em_2.LostFocus += new EventHandler(em_2_LostFocus);
            
            // 
            // st_2
            // 
            st_2.TabStop = false;
            st_2.Text = "Volume";
            st_2.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_2.Size = new System.Drawing.Size(43, 18);
            st_2.Location = new System.Drawing.Point(17, 264);
          
            // 
            // dw_1
            // 
//!            dw_1.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_1.TabIndex = 1;
            dw_1.Size = new System.Drawing.Size(369, 167);
            dw_1.Location=new System.Drawing.Point(17,27);
            //dw_1.Constructor +=new NZPostOffice.RDS.Controls.UserEventDelegate(dw_1_constructor);
        
            // 
            // gb_2
            // 
            gb_2.Text = "Frequencies";
            gb_2.BackColor = System.Drawing.SystemColors.Control;
            gb_2.ForeColor = System.Drawing.SystemColors.WindowText;
            gb_2.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            gb_2.TabIndex = 1;
            gb_2.Size = new System.Drawing.Size(391, 228);
            gb_2.Location = new System.Drawing.Point(7, 6);
           
            // 
            // gb_1
            // 
            gb_1.Text = "Volume and Hours";
            gb_1.BackColor = System.Drawing.SystemColors.Control;
            gb_1.ForeColor = System.Drawing.SystemColors.WindowText;
            gb_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            gb_1.TabIndex = 3;
            gb_1.Size = new System.Drawing.Size(391, 53);
            gb_1.Location = new System.Drawing.Point(7, 242);
         
            this.ResumeLayout();
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
