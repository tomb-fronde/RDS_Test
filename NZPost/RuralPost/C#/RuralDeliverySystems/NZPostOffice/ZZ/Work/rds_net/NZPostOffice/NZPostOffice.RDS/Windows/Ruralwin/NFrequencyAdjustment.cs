using System;
using NZPostOffice.RDS.DataService;
using System.Collections.Generic;
using NZPostOffice.Shared;
using System.Windows.Forms;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class NFrequencyAdjustment
    {
        #region Define

        public string is_reason = "";

        public int? il_contract_no = -(1);

        public int? il_sequence_no = -(1);

        public DateTime? id_effective_date = DateTime.MinValue;

        public System.Decimal? idc_adjustment_amount;

        public System.Decimal? idc_amount_to_pay;

        public System.Decimal? idc_new_benchmark;

        public int il_sf_key;

        public string is_delivery_days = String.Empty;

        //  TJB SR4632 29-July-2004 - Added is_confirmed variable 
        public string is_confirmed = "Y";

        public const int ii_SUCCESS = 1;

        public const int ii_FAILURE = -(1);

        public const string is_ERROR_TITLE = "Frequency Adjustment Error";

        #endregion

        public NFrequencyAdjustment()
        {
        }

        public virtual void constructor()
        {
            of_reset();
        }

        public virtual int of_set_contract(int? al_contract_no, int? al_sequence_no)
        {
            il_contract_no = al_contract_no;
            il_sequence_no = al_sequence_no;
            return ii_SUCCESS;
        }

        public virtual int of_set_effective_date(DateTime? ad_effective_date)
        {
            DateTime id_date_exists;
            System.Decimal ldc_benchmark;
            int lnextseq;
            System.Decimal ldc_amount_to_pay;
            int ll_Return;
            int ll_count;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            if (ad_effective_date == null)
            {
                MessageBox.Show("Invalid effective date passed in", is_ERROR_TITLE);
            }
            //  if contract number is not set, return failure
            if (il_contract_no == null 
                || il_contract_no <= 0 
                || il_sequence_no == null
                || il_sequence_no <= 0)
            {
                MessageBox.Show("Please supply a contract number first", is_ERROR_TITLE);
                return ii_FAILURE;
            }
            //  PBY SR#4405
            //  Need to grab the first available "active" sf_key!
            //  Get the route frequency and delivery dates from the Route_Frequency table

            //SELECT FIRST sf_key, rf_delivery_days INTO :il_sf_key, :is_delivery_days 
            // FROM	route_frequency WHERE contract_no = :il_contract_no AND	rf_active = 'Y'
            RDSDataService dataService = RDSDataService.GetRouteFrequencyList(il_contract_no.Value);
            List<RouteFrequencyItem> list = dataService.RoutFrequencyList;
            il_sf_key = list[0].SfKey;
            is_delivery_days = list[0].RfDeliveryDays;

            if (dataService.SQLCode != 0)
            {
                MessageBox.Show("Unable to obtain route frequency details for the contract.\n\n" 
                                 + "Error Text: " + dataService.SQLErrText
                               , "Database Error");
                return ii_FAILURE;
            }
            //  Check that no other extensions are made to the database
            //SELECT count(*) INTO :ll_Count FROM frequency_distances 
            // WHERE contract_no = :il_Contract_no AND sf_key = :il_SF_Key				
            //  AND	rf_delivery_days = :is_Delivery_Days 
            //  AND fd_effective_date = :ad_Effective_Date
            ll_count = RDSDataService.GetFrequencyDistancesCount(il_contract_no
                                                                , il_sf_key
                                                                , is_delivery_days
                                                                , ad_effective_date
                                                                , ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                MessageBox.Show(SQLErrText, is_ERROR_TITLE);
                return ii_FAILURE;
            }
            if (ll_count > 0)
            {
                //  there is already an extension defined for this effective date. 
                //  Will get the next available effecitve date
                while (SQLCode == 0 && ll_count > 0)
                {
                    //StaticFunctions.RelativeDate(ad_effective_date, -(1));
                    ad_effective_date = ad_effective_date.GetValueOrDefault().AddDays(-1);
                    //SELECT count(*) INTO	:ll_Count FROM frequency_distances 
                    // WHERE contract_no = :il_Contract_no AND sf_key = :il_SF_Key 
                    //   AND rf_delivery_days = :is_Delivery_Days 
                    //   AND fd_effective_date = :ad_Effective_Date;
                    ll_count = RDSDataService.GetFrequencyDistancesCount(
                                                            il_contract_no, il_sf_key
                                                          , is_delivery_days, ad_effective_date
                                                          , ref SQLCode, ref SQLErrText);
                }
                if (SQLCode == -(1))
                {
                    MessageBox.Show(SQLErrText, is_ERROR_TITLE);
                    return ii_FAILURE;
                }
                // 	MessageBox("Please choose a different effective date because there\n" 
                //              + "is already an extension defined for this effective date."
                //            ,is_ERROR_TITLE)
            }
            id_effective_date = ad_effective_date;
            return ii_SUCCESS;
        }

        public virtual int of_save(/*?SqlConnection atr_tran_object*/)
        {
            DateTime id_date_exists;
            System.Decimal ldc_benchmark;
            int lnextseq;
            System.Decimal ldc_amount_to_pay;
            int ll_Return;
            int ll_count;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            if ((id_effective_date == null) 
                || (idc_adjustment_amount == null) 
                || (idc_amount_to_pay == null) 
                || (idc_new_benchmark == null) 
                || (il_contract_no == null) 
                || il_contract_no <= 0 
                || (il_sequence_no == null) 
                || il_sequence_no <= 0 
                || (is_reason == null) 
                || is_reason == "")
            {
                MessageBox.Show("Please set the instance variables before saving", is_ERROR_TITLE);
                return ii_FAILURE;
            }
            //INSERT INTO frequency_distances (fd_effective_date, contract_no, sf_key, rf_delivery_days, fd_change_reason)
            //VALUES (:id_Effective_Date, :il_Contract_no, :il_sf_key, :is_Delivery_Days, :is_Reason);
            RDSDataService.InsertIntoFrequencyDistances(id_effective_date
                                                        , il_contract_no
                                                        , il_sf_key
                                                        , is_delivery_days
                                                        , is_reason
                                                        , ref SQLCode, ref SQLErrText);
            if (SQLCode != 0)
            {
                MessageBox.Show("Error saving frequency_distances record\n\n" 
                                 + "Error Text: " + SQLErrText
                               , "Database Error (NFrequencyAdjustment.of_save)");
                //?ROLLBACK USING atr_tran_object;
                return ii_FAILURE;
            }
            ///SELECT max ( fd_unique_seq_number) INTO :lNextSeq FROM frequency_adjustments
            //  WHERE contract_no = :il_Contract_no AND contract_seq_number = :il_Sequence_no 
            //  USING atr_tran_object;
            lnextseq = RDSDataService.GetMaxFdUniqueSeqNumber(il_contract_no
                                                             , il_sequence_no
                                                             , ref SQLCode, ref SQLErrText);
            if (SQLCode < 0)
            {
                MessageBox.Show("Error obtaining fd_unique_seq_number.\n\n" 
                                 + "Error Text: " + SQLErrText
                               , "Database Error (NFrequencyAdjustment.of_save)");
                //?ROLLBACK USING atr_tran_object;
                return ii_FAILURE;
            }
            if (lnextseq == null)
            {
                lnextseq = 1;
            }
            else
            {
                lnextseq++;
            }
            //  TJB SR4632 29-July-2004
            //  Replaced hard-coded 'Y' with is_confirmed
            //  TJB  SR4695  Jan-2007
            //  Added sf_key to inserted values  ( new field)
            /*INSERT INTO frequency_adjustments  
                     ( contract_no,   
                    contract_seq_number,   
                    fd_unique_seq_number,   
                    fd_adjustment_amount,   
                    fd_paid_to_date,   
                    fd_bm_after_extn,   
                    fd_confirmed,   
                    fd_amount_to_pay,
                    fd_effective_date,
                    sf_key, 
                    rf_delivery_days) 
                    VALUES 
                     ( :il_Contract_no,   
                    :il_Sequence_no,   
                    :lNextSeq,   
                    :idc_adjustment_amount,
                    null,   
                    :idc_new_benchmark,   
                    :is_confirmed,   
                    :idc_amount_to_pay,
                    :id_Effective_Date, 
                    :il_sf_key,
                    :is_Delivery_Days)  ;*/
            RDSDataService.InsertIntoFrequencyAdjustments(il_contract_no
                                                         , il_sequence_no
                                                         , lnextseq
                                                         , idc_adjustment_amount
                                                         , idc_new_benchmark
                                                         , is_confirmed
                                                         , idc_amount_to_pay
                                                         , id_effective_date
                                                         , il_sf_key
                                                         , is_delivery_days
                                                         , ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                MessageBox.Show("Error saving frequency_adjustment record\n" 
                                 + "Error Text: " + SQLErrText
                               , "Database Error (NFrequencyAdjustment.of_save)");
                //?ROLLBACK USING atr_tran_object;
                return ii_FAILURE;
            }
            return ii_SUCCESS;
        }

        //?public virtual int of_save() 
        //{
        //    return of_save(StaticVariables.sqlca);
        //}

        public virtual void of_reset()
        {
            id_effective_date = null;
            idc_adjustment_amount = null;
            idc_amount_to_pay = null;
            idc_new_benchmark = null;
            il_contract_no = null;
            il_sequence_no = null;
            is_reason = null;
            //  TJB SR4632 29-July-2004
            is_confirmed = "Y";
        }
    }
}