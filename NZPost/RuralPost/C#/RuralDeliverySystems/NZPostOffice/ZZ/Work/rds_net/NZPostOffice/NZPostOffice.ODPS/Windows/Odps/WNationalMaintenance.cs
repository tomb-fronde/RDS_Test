using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.Entity.Odps;
using NZPostOffice.ODPS.Menus;
using Metex.Windows;
using NZPostOffice.ODPS.DataControls.Odps;

using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Windows.Odps
{
    public partial class WNationalMaintenance : WMaster
    {
        #region Define
        public MOdpsMaintenance m_odps_maintenance;

        public UoNational iu_national;
        #endregion

        public WNationalMaintenance()
        {
            m_odps_maintenance = new MOdpsMaintenance(this);
            this.InitializeComponent();

            //? m_odps_maintenance_menu.SetFunctionalPart(m_odps_maintenance);
            //? m_odps_maintenance_toolbar.SetFunctionalPart(m_odps_maintenance);
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            // 	Object:			cs_Template_w_Singledw
            // 	Method:			pfc_PostOpen
            // 	Description:	retrieve the datawindow stuff
            // 	HELP:	 perform the retrieval after the initial window display
            if (StaticMessage.IntegerParm != 0)
            {
                //? this.SetMicroHelp("Retrieving Information . . .");
                //dw_single.pfc_retrieve();
                ((DwNationalDetail)dw_single.DataObject).Retrieve(StaticMessage.IntegerParm);

                dw_single.Focus();
            }

            // TJB  OD7_0001  Aug 2008
            // Commented out.  Leave StringParm = "New" to be used to 
            // tell this is a record insert and not an update.

            //if (StaticMessage.StringParm == "New")
            //{
            //    StaticMessage.StringParm = "";
            //    dw_single.InsertItem<NationalDetail>(0);
            //}

            //? this.SetMicroHelp("Ready");
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            // //	Object:			cs_Template_w_Singledw
            // //	Method:			pfc_PreOpen
            // //	Description:	start any window services desired
            // 
            // //	HELP:	first set the original size of the control before starting the resize service,
            // //	HELP:	use this if you want the datawindow to fill the screen
            // dw_Single.Resize  (  This.WorkSpaceWidth  (  ), This.WorkSpaceHeight  (  ) )
            // 
            // //	HELP:	start any window services desired
            // This.of_SetResize  (  TRUE )
            // 
            MenuStrip lm;
            DataUserControl ldwc_account;
            DataUserControl ldwc_pbu;
            DataUserControl ldwc_pct;
            DataUserControl ldwc_acca;
            DataUserControl ldwc_accb;
            DataUserControl ldwc_accc;
            DataUserControl ldwc_accd;
            DataUserControl ldwc_acce;
            DataUserControl ldwc_pbua;
            DataUserControl ldwc_pbub;
            DataUserControl ldwc_pbuc;
            DataUserControl ldwc_pbud;
            DataUserControl ldwc_pcta;
            DataUserControl ldwc_pctb;
            DataUserControl ldwc_pctc;
            DataUserControl ldwc_pctd;
            DataUserControl ldwc_pcte;
            DataUserControl ldwc_pctf;
            DataUserControl ldwc_pctg;

            ldwc_account = dw_single.GetChild("nat_ac_id_gst_gl");
            ldwc_acca = dw_single.GetChild("nat_ac_id_whtax_gl");
            ldwc_accb = dw_single.GetChild("nat_ac_id_postax_adj_gl");
            ldwc_accc = dw_single.GetChild("nat_ac_id_contprice_gl");
            ldwc_accd = dw_single.GetChild("nat_ac_id_netpay_gl");
            ldwc_acce = dw_single.GetChild("nat_ac_id_accrualbalance_gl");
            ldwc_pbu = dw_single.GetChild("nat_pbu_code_postax_gl");
            ldwc_pbua = dw_single.GetChild("nat_pbu_code_whtax_gl");
            ldwc_pbub = dw_single.GetChild("nat_pbu_code_gst_gl");
            ldwc_pbuc = dw_single.GetChild("nat_pbu_code_netpay_gl");
            ldwc_pbud = dw_single.GetChild("nat_pbu_code_accrualbalance_g");
            ldwc_pct = dw_single.GetChild("nat_freqadj_defaultcomptype");
            ldwc_pcta = dw_single.GetChild("nat_contadj_defaultcomptype");
            ldwc_pctb = dw_single.GetChild("nat_contallow_defaultcomptype");
            ldwc_pctc = dw_single.GetChild("nat_deductions_defaultcomptyp");
            ldwc_pctd = dw_single.GetChild("nat_courierpost_defaultcompty");
            ldwc_pcte = dw_single.GetChild("nat_adpost_defaultcomptype");
            ldwc_pctf = dw_single.GetChild("nat_xp_defaultcomptype");
            ldwc_pctg = dw_single.GetChild("nat_pp_defaultcomptype");

            //  Set the transaction object for the child
            //  Retrieve the child datawindow
            ldwc_account.Retrieve();
            ldwc_pbu.Retrieve();

            //remarked by jlwang( does not need)
            ////  Share the child datawindows
            //ldwc_account.ShareData(ldwc_acca);
            //ldwc_account.ShareData(ldwc_accb);
            //ldwc_account.ShareData(ldwc_accc);
            //ldwc_account.ShareData(ldwc_accd);
            //ldwc_account.ShareData(ldwc_acce);
            //ldwc_pbu.ShareData(ldwc_pbua);
            //ldwc_pbu.ShareData(ldwc_pbub);
            //ldwc_pbu.ShareData(ldwc_pbuc);
            //ldwc_pbu.ShareData(ldwc_pbud);  //need remark
            //ldwc_pct.ShareData(ldwc_pcta);
            //ldwc_pct.ShareData(ldwc_pctb);
            //ldwc_pct.ShareData(ldwc_pctc);//need remark
            //ldwc_pct.ShareData(ldwc_pctd);//need remark
            //ldwc_pct.ShareData(ldwc_pcte);

            //  disable the addrow and deleterow menu

            m_odps_maintenance.m_addrow.Enabled = false;
            m_odps_maintenance._m_addrow.Enabled = false;
            m_odps_maintenance.m_deleterow.Enabled = false;
            m_odps_maintenance._m_deleterow.Enabled = false;

            object any_var = null;
            //gnv_app.inv_ObjectMsg.of_GetMsg("uo", "callinguo", any_var, 'Y');
            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("uo", "callinguo", ref any_var, "Y");
            iu_national = (UoNational)any_var;
            //dw_1.settransobject(StaticVariables.sqlca);
        }

        public override void close()
        {
            StaticMessage.StringParm = "";
            base.close();
            // if isvalid ( lds_national) then destroy ( lds_national)
        }

        public override int pfc_save()
        {
            int  ll = 0;

            if (!dw_single.AcceptText())
            {
                return -1;
            }

            if (StaticMessage.StringParm == "New")
            {
                InsertRecord();
                ll = 1;
            }
            else
            {
                if (dw_single.DataObject.DeletedCount > 0 || StaticFunctions.IsDirty(dw_single.DataObject))  //(dw_single.modifiedcount() > 0) 
                {
                    if (dw_single.DataObject.GetItem<NationalDetail>(0).IsDirty)//(dw_single.GetItemStatus(1, 0, primary!) == datamodified!) 
                    {

                        // remarked by jlwang:abnormal logic
                        //dw_1.Reset();
                        //// dw_single.rowscopy(1, 1, primary!, dw_1, 1, primary!);
                        //dw_1.InsertItem<NationalDetail>(0);
                        //dw_1.GetItem<NationalDetail>(0).NatId = dw_single.GetItem<NationalDetail>(0).NatId;
                        //dw_1.GetItem<NationalDetail>(0).AcId = dw_single.GetItem<NationalDetail>(0).AcId;
                        //dw_1.GetItem<NationalDetail>(0).NatAcIdGstGl = dw_single.GetItem<NationalDetail>(0).NatAcIdGstGl;

                        //dw_1.GetItem<NationalDetail>(0).NatAcIdWhtaxGl = dw_single.GetItem<NationalDetail>(0).NatAcIdWhtaxGl;
                        //dw_1.GetItem<NationalDetail>(0).NatAcIdPostaxAdjGl = dw_single.GetItem<NationalDetail>(0).NatAcIdPostaxAdjGl;
                        //dw_1.GetItem<NationalDetail>(0).NatRuralPostGstNo = dw_single.GetItem<NationalDetail>(0).NatRuralPostGstNo;

                        //dw_1.GetItem<NationalDetail>(0).NatGstRate = dw_single.GetItem<NationalDetail>(0).NatGstRate;
                        //dw_1.GetItem<NationalDetail>(0).NatIrdNo = dw_single.GetItem<NationalDetail>(0).NatIrdNo;
                        //dw_1.GetItem<NationalDetail>(0).NatRuralPostAddress = dw_single.GetItem<NationalDetail>(0).NatRuralPostAddress;

                        //dw_1.GetItem<NationalDetail>(0).NatRuralPostPayerName = dw_single.GetItem<NationalDetail>(0).NatRuralPostPayerName;
                        //dw_1.GetItem<NationalDetail>(0).NatAccPercentage = dw_single.GetItem<NationalDetail>(0).NatAccPercentage;
                        //dw_1.GetItem<NationalDetail>(0).NatStandardTaxRate = dw_single.GetItem<NationalDetail>(0).NatStandardTaxRate;

                        //dw_1.GetItem<NationalDetail>(0).NatDayOfMonth = dw_single.GetItem<NationalDetail>(0).NatDayOfMonth;
                        //dw_1.GetItem<NationalDetail>(0).NatMessageForInvoice = dw_single.GetItem<NationalDetail>(0).NatMessageForInvoice;
                        //dw_1.GetItem<NationalDetail>(0).NatNetPctChangeWarn = dw_single.GetItem<NationalDetail>(0).NatNetPctChangeWarn;

                        //dw_1.GetItem<NationalDetail>(0).NatSeqNoForKeys = dw_single.GetItem<NationalDetail>(0).NatSeqNoForKeys;
                        //dw_1.GetItem<NationalDetail>(0).NatOdStandardGstRate = dw_single.GetItem<NationalDetail>(0).NatOdStandardGstRate;
                        //dw_1.GetItem<NationalDetail>(0).NatOdTaxRateIr13 = dw_single.GetItem<NationalDetail>(0).NatOdTaxRateIr13;

                        //dw_1.GetItem<NationalDetail>(0).NatOdTaxRateNoIr13 = dw_single.GetItem<NationalDetail>(0).NatOdTaxRateNoIr13;
                        //dw_1.GetItem<NationalDetail>(0).ApNetPayClearingAccount = dw_single.GetItem<NationalDetail>(0).ApNetPayClearingAccount;
                        //dw_1.GetItem<NationalDetail>(0).NatEffectiveDate = dw_single.GetItem<NationalDetail>(0).NatEffectiveDate;

                        //dw_1.GetItem<NationalDetail>(0).NatAcIdContpriceGl = dw_single.GetItem<NationalDetail>(0).NatAcIdContpriceGl;
                        //dw_1.GetItem<NationalDetail>(0).NatAcIdNetpayGl = dw_single.GetItem<NationalDetail>(0).NatAcIdNetpayGl;
                        //dw_1.GetItem<NationalDetail>(0).NatAcIdAccrualbalanceGl = dw_single.GetItem<NationalDetail>(0).NatAcIdAccrualbalanceGl;

                        //dw_1.GetItem<NationalDetail>(0).NatPbuCodePostaxGl = dw_single.GetItem<NationalDetail>(0).NatPbuCodePostaxGl;
                        //dw_1.GetItem<NationalDetail>(0).NatPbuCodeWhtaxGl = dw_single.GetItem<NationalDetail>(0).NatPbuCodeWhtaxGl;
                        //dw_1.GetItem<NationalDetail>(0).NatPbuCodeGstGl = dw_single.GetItem<NationalDetail>(0).NatPbuCodeGstGl;

                        //dw_1.GetItem<NationalDetail>(0).NatPbuCodeNetpayGl = dw_single.GetItem<NationalDetail>(0).NatPbuCodeNetpayGl;
                        //dw_1.GetItem<NationalDetail>(0).NatInvoiceNumberPrefix = dw_single.GetItem<NationalDetail>(0).NatInvoiceNumberPrefix;
                        //dw_1.GetItem<NationalDetail>(0).NatPbuCodeAccrualbalanceGl = dw_single.GetItem<NationalDetail>(0).NatPbuCodeAccrualbalanceGl;

                        //dw_1.GetItem<NationalDetail>(0).NatFreqadjDefaultcomptype = dw_single.GetItem<NationalDetail>(0).NatFreqadjDefaultcomptype;
                        //dw_1.GetItem<NationalDetail>(0).NatAdpostDefaultcomptype = dw_single.GetItem<NationalDetail>(0).NatAdpostDefaultcomptype;
                        //dw_1.GetItem<NationalDetail>(0).NatContadjDefaultcomptype = dw_single.GetItem<NationalDetail>(0).NatContadjDefaultcomptype;

                        //dw_1.GetItem<NationalDetail>(0).NatContallowDefaultcomptype = dw_single.GetItem<NationalDetail>(0).NatContallowDefaultcomptype;
                        //dw_1.GetItem<NationalDetail>(0).NatDeductionsDefaultcomptype = dw_single.GetItem<NationalDetail>(0).NatDeductionsDefaultcomptype;
                        //dw_1.GetItem<NationalDetail>(0).NatCourierpostDefaultcomptype = dw_single.GetItem<NationalDetail>(0).NatCourierpostDefaultcomptype;

                        //dw_1.GetItem<NationalDetail>(0).NatXpDefaultcomptype = dw_single.GetItem<NationalDetail>(0).NatXpDefaultcomptype;

                        //if (dw_1.GetValue<DateTime?>(0, "nat_effective_date") == null)// (IsNull(dw_1.GetItemDateTime(1, "nat_effective_date").Date))
                        //{
                        //    dw_1.SetValue(0, "nat_effective_date", System.DateTime.Today);// dw_1.setitem(1, "nat_effective_date", Today());
                        //}
                        //dw_single.Reset();

                        //// dw_1.rowscopy(1, 1, primary!, dw_single, 1, primary!);
                        //dw_single.InsertItem<NationalDetail>(0);
                        //dw_single.GetItem<NationalDetail>(0).NatId = dw_1.GetItem<NationalDetail>(0).NatId;
                        //dw_single.GetItem<NationalDetail>(0).AcId = dw_1.GetItem<NationalDetail>(0).AcId;
                        //dw_single.GetItem<NationalDetail>(0).NatAcIdGstGl = dw_1.GetItem<NationalDetail>(0).NatAcIdGstGl;

                        //dw_single.GetItem<NationalDetail>(0).NatAcIdWhtaxGl = dw_1.GetItem<NationalDetail>(0).NatAcIdWhtaxGl;
                        //dw_single.GetItem<NationalDetail>(0).NatAcIdPostaxAdjGl = dw_1.GetItem<NationalDetail>(0).NatAcIdPostaxAdjGl;
                        //dw_single.GetItem<NationalDetail>(0).NatRuralPostGstNo = dw_1.GetItem<NationalDetail>(0).NatRuralPostGstNo;

                        //dw_single.GetItem<NationalDetail>(0).NatGstRate = dw_1.GetItem<NationalDetail>(0).NatGstRate;
                        //dw_single.GetItem<NationalDetail>(0).NatIrdNo = dw_1.GetItem<NationalDetail>(0).NatIrdNo;
                        //dw_single.GetItem<NationalDetail>(0).NatRuralPostAddress = dw_1.GetItem<NationalDetail>(0).NatRuralPostAddress;

                        //dw_single.GetItem<NationalDetail>(0).NatRuralPostPayerName = dw_1.GetItem<NationalDetail>(0).NatRuralPostPayerName;
                        //dw_single.GetItem<NationalDetail>(0).NatAccPercentage = dw_1.GetItem<NationalDetail>(0).NatAccPercentage;
                        //dw_single.GetItem<NationalDetail>(0).NatStandardTaxRate = dw_1.GetItem<NationalDetail>(0).NatStandardTaxRate;

                        //dw_single.GetItem<NationalDetail>(0).NatDayOfMonth = dw_1.GetItem<NationalDetail>(0).NatDayOfMonth;
                        //dw_single.GetItem<NationalDetail>(0).NatMessageForInvoice = dw_1.GetItem<NationalDetail>(0).NatMessageForInvoice;
                        //dw_single.GetItem<NationalDetail>(0).NatNetPctChangeWarn = dw_1.GetItem<NationalDetail>(0).NatNetPctChangeWarn;

                        //dw_single.GetItem<NationalDetail>(0).NatSeqNoForKeys = dw_1.GetItem<NationalDetail>(0).NatSeqNoForKeys;
                        //dw_single.GetItem<NationalDetail>(0).NatOdStandardGstRate = dw_1.GetItem<NationalDetail>(0).NatOdStandardGstRate;
                        //dw_single.GetItem<NationalDetail>(0).NatOdTaxRateIr13 = dw_1.GetItem<NationalDetail>(0).NatOdTaxRateIr13;

                        //dw_single.GetItem<NationalDetail>(0).NatOdTaxRateNoIr13 = dw_1.GetItem<NationalDetail>(0).NatOdTaxRateNoIr13;
                        //dw_single.GetItem<NationalDetail>(0).ApNetPayClearingAccount = dw_1.GetItem<NationalDetail>(0).ApNetPayClearingAccount;
                        //dw_single.GetItem<NationalDetail>(0).NatEffectiveDate = dw_1.GetItem<NationalDetail>(0).NatEffectiveDate;

                        //dw_single.GetItem<NationalDetail>(0).NatAcIdContpriceGl = dw_1.GetItem<NationalDetail>(0).NatAcIdContpriceGl;
                        //dw_single.GetItem<NationalDetail>(0).NatAcIdNetpayGl = dw_1.GetItem<NationalDetail>(0).NatAcIdNetpayGl;
                        //dw_single.GetItem<NationalDetail>(0).NatAcIdAccrualbalanceGl = dw_1.GetItem<NationalDetail>(0).NatAcIdAccrualbalanceGl;

                        //dw_single.GetItem<NationalDetail>(0).NatPbuCodePostaxGl = dw_1.GetItem<NationalDetail>(0).NatPbuCodePostaxGl;
                        //dw_single.GetItem<NationalDetail>(0).NatPbuCodeWhtaxGl = dw_1.GetItem<NationalDetail>(0).NatPbuCodeWhtaxGl;
                        //dw_single.GetItem<NationalDetail>(0).NatPbuCodeGstGl = dw_1.GetItem<NationalDetail>(0).NatPbuCodeGstGl;

                        //dw_single.GetItem<NationalDetail>(0).NatPbuCodeNetpayGl = dw_1.GetItem<NationalDetail>(0).NatPbuCodeNetpayGl;
                        //dw_single.GetItem<NationalDetail>(0).NatInvoiceNumberPrefix = dw_1.GetItem<NationalDetail>(0).NatInvoiceNumberPrefix;
                        //dw_single.GetItem<NationalDetail>(0).NatPbuCodeAccrualbalanceGl = dw_1.GetItem<NationalDetail>(0).NatPbuCodeAccrualbalanceGl;

                        //dw_single.GetItem<NationalDetail>(0).NatFreqadjDefaultcomptype = dw_1.GetItem<NationalDetail>(0).NatFreqadjDefaultcomptype;
                        //dw_single.GetItem<NationalDetail>(0).NatAdpostDefaultcomptype = dw_1.GetItem<NationalDetail>(0).NatAdpostDefaultcomptype;
                        //dw_single.GetItem<NationalDetail>(0).NatContadjDefaultcomptype = dw_1.GetItem<NationalDetail>(0).NatContadjDefaultcomptype;

                        //dw_single.GetItem<NationalDetail>(0).NatContallowDefaultcomptype = dw_1.GetItem<NationalDetail>(0).NatContallowDefaultcomptype;
                        //dw_single.GetItem<NationalDetail>(0).NatDeductionsDefaultcomptype = dw_1.GetItem<NationalDetail>(0).NatDeductionsDefaultcomptype;
                        //dw_single.GetItem<NationalDetail>(0).NatCourierpostDefaultcomptype = dw_1.GetItem<NationalDetail>(0).NatCourierpostDefaultcomptype;

                        //dw_single.GetItem<NationalDetail>(0).NatXpDefaultcomptype = dw_1.GetItem<NationalDetail>(0).NatXpDefaultcomptype;
                        //dw_1.Reset();

                        if (dw_single.GetValue<DateTime?>(0, "nat_effective_date") == null)
                            dw_single.SetValue(0, "nat_effective_date", System.DateTime.Today);
                    }
                }
                ll = dw_single.Save();   //ll = base.pfc_save();
            }


            if (ll == 1)
                iu_national.dw_selection.Retrieve();
            return ll;
        }

        public virtual void dw_single_constructor()
        {
            //?dw_single.of_settransobject(StaticVariables.sqlca);
            //? dw_single.of_setreqcolumn(true);
            //? dw_single.of_setvalidation(true);
        }

        public virtual int pfc_retrieve()
        {
            return ((DwNationalDetail)dw_single.DataObject).Retrieve(StaticMessage.IntegerParm);
        }

       #region Events
        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            if (this.pfc_save() >= 0)
            {
                this.Close();
            }
        }

        public virtual void cb_2_clicked(object sender, EventArgs e)
        {
            //parent.TriggerEvent("pfc_close");
            this.Close();
        }
        #endregion

        //[ServerMethod()]
        private void InsertRecord()
        {
            // Whole method added, based on InsertEntity and FetchEntity - TJB Aug 2008
            // Called via cb_1.clicked (OK) event when a new record has been selected.
            // There's probably a more elegant way to do this within the Metex 
            // libraries, but this will do (for now).
            // Reverse-engineered Metex library calls are used since the actual 
            // database I/O appears to be embedded in the Metex packages.

            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    // Create the command to be executed.  The "@<name>" items are names for values in 
                    // the 'pList' parameter collection
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "INSERT INTO odps.[national] "
                                     + "(ac_id, nat_ac_id_gst_gl, nat_ac_id_whtax_gl, nat_ac_id_postax_adj_gl, nat_pbu_code_netpay_gl, "
                                     + " nat_effective_date, nat_ac_id_contprice_gl, nat_ac_id_netpay_gl, nat_ac_id_accrualbalance_gl, "
                                     + " nat_pbu_code_postax_gl, nat_pbu_code_whtax_gl, nat_pbu_code_gst_gl, nat_contadj_defaultcomptype, "
                                     + " nat_pp_defaultcomptype, nat_freqadj_defaultcomptype, nat_adpost_defaultcomptype, "
                                     + " nat_contallow_defaultcomptype, nat_deductions_defaultcomptype, nat_courierpost_defaultcomptype, "
                                     + " nat_xp_defaultcomptype, "
                                     + " nat_rural_post_gst_no, nat_gst_rate, nat_ird_no, nat_rural_post_address, "
                                     + " nat_rural_post_payer_name, nat_acc_percentage, nat_standard_tax_rate, "
                                     + " nat_day_of_month, nat_message_for_invoice, nat_net_pct_change_warn, "
                                     + " nat_seq_no_for_keys, nat_od_standard_gst_rate, nat_od_tax_rate_ir13, "
                                     + " nat_od_tax_rate_no_ir13, ap_net_pay_clearing_account, nat_invoice_number_prefix)"
                                     + " VALUES "
                                     + "(@ac_id, @nat_ac_id_gst_gl, @nat_ac_id_whtax_gl, @nat_ac_id_postax_adj_gl, @nat_pbu_code_netpay_gl, "
                                     + " @nat_effective_date, @nat_ac_id_contprice_gl, @nat_ac_id_netpay_gl, @nat_ac_id_accrualbalance_gl, "
                                     + " @nat_pbu_code_postax_gl, @nat_pbu_code_whtax_gl, @nat_pbu_code_gst_gl, @nat_contadj_defaultcomptype, "
                                     + " @nat_pp_defaultcomptype, @nat_freqadj_defaultcomptype, @nat_adpost_defaultcomptype, "
                                     + " @nat_contallow_defaultcomptype, @nat_deductions_defaultcomptype, @nat_courierpost_defaultcomptype, "
                                     + " @nat_xp_defaultcomptype, "
                                     + " @nat_rural_post_gst_no, @nat_gst_rate, @nat_ird_no, @nat_rural_post_address, "
                                     + " @nat_rural_post_payer_name, @nat_acc_percentage, @nat_standard_tax_rate, "
                                     + " @nat_day_of_month, @nat_message_for_invoice, @nat_net_pct_change_warn, "
                                     + " @nat_seq_no_for_keys, @nat_od_standard_gst_rate, @nat_od_tax_rate_ir13, "
                                     + " @nat_od_tax_rate_no_ir13, @ap_net_pay_clearing_account, @nat_invoice_number_prefix)";

                    // Load the parameter collection with variables and values
                    // The nat_effective_date is a 'Not Null' column, so we have to be sure it has a value.
                    //
                    // The 'nat_id' is an identity column, so we don't attempt to supply one.
                    if (dw_single.GetValue<DateTime?>(0, "nat_effective_date") != null)
                        pList.Add(cm, "@nat_effective_date", dw_single.GetItem<NationalDetail>(0).NatEffectiveDate);
                    else
                        pList.Add(cm, "@nat_effective_date", System.DateTime.Today);

                    pList.Add(cm, "@ac_id", dw_single.GetItem<NationalDetail>(0).AcId);
                    pList.Add(cm, "@nat_gst_rate", dw_single.GetValue<decimal>(0, "nat_gst_rate"));
                    pList.Add(cm, "@nat_ird_no", dw_single.GetValue<string>(0, "nat_ird_no"));
                    pList.Add(cm, "@nat_ac_id_gst_gl", dw_single.GetValue<int>(0, "nat_ac_id_gst_gl"));
                    pList.Add(cm, "@nat_ac_id_whtax_gl", dw_single.GetValue<int>(0, "nat_ac_id_whtax_gl"));
                    pList.Add(cm, "@nat_ac_id_postax_adj_gl", dw_single.GetValue<int>(0, "nat_ac_id_postax_adj_gl"));
                    pList.Add(cm, "@nat_pbu_code_netpay_gl", dw_single.GetValue<int>(0, "nat_pbu_code_netpay_gl"));
                    pList.Add(cm, "@nat_ac_id_contprice_gl", dw_single.GetValue<int>(0, "nat_ac_id_contprice_gl"));
                    pList.Add(cm, "@nat_ac_id_netpay_gl", dw_single.GetValue<int>(0, "nat_ac_id_netpay_gl"));
                    pList.Add(cm, "@nat_ac_id_accrualbalance_gl", dw_single.GetValue<int>(0, "nat_ac_id_accrualbalance_gl"));
                    pList.Add(cm, "@nat_pbu_code_postax_gl", dw_single.GetValue<int>(0, "nat_pbu_code_postax_gl"));
                    pList.Add(cm, "@nat_pbu_code_whtax_gl", dw_single.GetValue<int>(0, "nat_pbu_code_whtax_gl"));
                    pList.Add(cm, "@nat_pbu_code_gst_gl", dw_single.GetValue<int>(0, "nat_pbu_code_gst_gl"));
                    pList.Add(cm, "@nat_contadj_defaultcomptype", dw_single.GetValue<int>(0, "nat_contadj_defaultcomptype"));
                    pList.Add(cm, "@nat_pp_defaultcomptype", dw_single.GetValue<int>(0, "nat_pp_defaultcomptype"));
                    pList.Add(cm, "@nat_freqadj_defaultcomptype", dw_single.GetValue<int>(0, "nat_freqadj_defaultcomptype"));
                    pList.Add(cm, "@nat_adpost_defaultcomptype", dw_single.GetValue<int>(0, "nat_adpost_defaultcomptype"));
                    pList.Add(cm, "@nat_contallow_defaultcomptype", dw_single.GetValue<int>(0, "nat_contallow_defaultcomptype"));
                    pList.Add(cm, "@nat_deductions_defaultcomptype", dw_single.GetValue<int>(0, "nat_deductions_defaultcomptype"));
                    pList.Add(cm, "@nat_courierpost_defaultcomptype", dw_single.GetValue<int>(0, "nat_courierpost_defaultcomptype"));
                    pList.Add(cm, "@nat_xp_defaultcomptype", dw_single.GetValue<int>(0, "nat_xp_defaultcomptype"));
                    pList.Add(cm, "@nat_rural_post_gst_no", dw_single.GetValue<string>(0, "nat_rural_post_gst_no"));
                    pList.Add(cm, "@nat_rural_post_address", dw_single.GetValue<string>(0, "nat_rural_post_address"));
                    pList.Add(cm, "@nat_rural_post_payer_name", dw_single.GetValue<string>(0, "nat_rural_post_payer_name"));
                    pList.Add(cm, "@nat_acc_percentage", dw_single.GetValue<decimal>(0, "nat_acc_percentage"));
                    pList.Add(cm, "@nat_standard_tax_rate", dw_single.GetValue<decimal>(0, "nat_standard_tax_rate"));
                    pList.Add(cm, "@nat_day_of_month", dw_single.GetValue<int>(0, "nat_day_of_month"));
                    pList.Add(cm, "@nat_message_for_invoice", dw_single.GetValue<string>(0, "nat_message_for_invoice"));
                    pList.Add(cm, "@nat_net_pct_change_warn", dw_single.GetValue<decimal>(0, "nat_net_pct_change_warn"));
                    pList.Add(cm, "@nat_seq_no_for_keys", dw_single.GetValue<int>(0, "nat_seq_no_for_keys"));
                    pList.Add(cm, "@nat_od_standard_gst_rate", dw_single.GetValue<decimal>(0, "nat_od_standard_gst_rate"));
                    pList.Add(cm, "@nat_od_tax_rate_ir13", dw_single.GetValue<decimal>(0, "nat_od_tax_rate_ir13"));
                    pList.Add(cm, "@nat_od_tax_rate_no_ir13", dw_single.GetValue<decimal>(0, "nat_od_tax_rate_no_ir13"));
                    pList.Add(cm, "@ap_net_pay_clearing_account", dw_single.GetValue<int>(0, "ap_net_pay_clearing_account"));
                    pList.Add(cm, "@nat_invoice_number_prefix", dw_single.GetValue<string>(0, "nat_invoice_number_prefix"));

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                        string ls_errmsg;
                        ls_errmsg = e.Message.ToString();
                        MessageBox.Show("SQL error inserting new national table record\n"
                                        + ls_errmsg
                                        , "ERROR");
                    }
                }
            }
        }
    }
}