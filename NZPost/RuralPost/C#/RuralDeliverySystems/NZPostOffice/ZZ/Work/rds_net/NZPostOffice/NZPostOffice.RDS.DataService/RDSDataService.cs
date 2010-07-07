using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using Metex.Core;
using Metex.Core.Security;
//************************************************************************************************
// Modifications
// 21 Jul 2008  Metex  Fix2 for Renewal bug.  See _GetContractRenewalsConVolumeAtRenewal
//************************************************************************************************
namespace NZPostOffice.RDS.DataService
{
    // TJB RPCR_001 July-2010
    // Added lSafety, lEmissions, and lConsumption to InsertVehicle and UpdateVehicle
    // Added sqlCode, sqlErrText parameters for error handling
    //
    // TJB  ECL Data Import  June-2010
    // Multiple additions in labelled sections.
    //
    // TJB  ECL Data Import  June-2010
    // Added struct to hold data row being imported into database
    // (see InsertIntoECLUploadData and _InsertIntoECLUploadData)
    public struct EclImportData
    {
        public int EclBatchNo;
        public string EclTicketNo;
        public string EclTicketPart;
        public string EclCustomerName;
        public string EclCustomerCode;
        public int EclSeq;
        public int EclDriverId;
        public int EclRateCode;
        public string EclRateDescr;
        public string EclPkgDescr;
        public int EclBatchId;
        public int EclRunID;
        public string EclRunNo;
        public DateTime EclDriverDate;
        public DateTime EclDateEntered;
        public string EclTicketPayable;
        public string EclRuralPayable;
        public int EclScanCount;
        public string EclSigReqFlag;
        public string EclSigCaptured;
        public string EclSigName;
        public string EclPrCode;
        public string EclRo5Flag;
        public DateTime EclEffectiveDate;
    }

    [Serializable()]
    public class RDSDataService : CommandEntity<RDSDataService>
    {
        #region Factory Methods

        public bool ret = false;
        private string dataObject;
        public int intVal;
//        private int ll_count;
        public DateTime? dtVal;
        public string strVal;
        public decimal? decVal;

        private int _sqlcode = -1;
        public int SQLCode
        {
            get
            {
                return _sqlcode;
            }
        }

        private int _sqldbcode = -1;
        public int SQLDBCode
        {
            get
            {
                return _sqldbcode;
            }
        }

        private string _sqlerrtext = "";
        public string SQLErrText
        {
            get
            {
                return _sqlerrtext;
            }
        }

        private int SQLNRows = 0;

        private List<CaLoadResultsItem> _CaLoadResultsList;
        public List<CaLoadResultsItem> CaLoadResultsList
        {
            get
            {
                return _CaLoadResultsList;
            }
        }

        private List<ContractItem> _contractItemList;
        public List<ContractItem> ContractItemList
        {
            get
            {
                return _contractItemList;
            }
        }

        private List<ContractRenewalsDateItem> _contractRenewalsDateItemList;
        public List<ContractRenewalsDateItem> ContractRenewalsDateItemList
        {
            get
            {
                return _contractRenewalsDateItemList;
            }
        }

        private List<VehicleItem> _vehicleList;
        public List<VehicleItem> VehicleList
        {
            get
            {
                return _vehicleList;
            }
        }

        private List<RouteFrequencyItem> _routeFrequencyList;
        public List<RouteFrequencyItem> RoutFrequencyList
        {
            get
            {
                return _routeFrequencyList;
            }
        }

        private List<VehicleTypeItem> _vehicleTypeList;
        public List<VehicleTypeItem> VehicleTypeList
        {
            get
            {
                return _vehicleTypeList;
            }
        }

        private List<VehicleRateNonVehicleRateItem> _vehicleRateNonVehicleRateList;
        public List<VehicleRateNonVehicleRateItem> VehicleRateNonVehicleRateList
        {
            get
            {
                return _vehicleRateNonVehicleRateList;
            }
        }

        private List<VehicleOverrideRateItem> _vehicleOverrideRateList;
        public List<VehicleOverrideRateItem> VehicleOverrideRateList
        {
            get
            {
                return _vehicleOverrideRateList;
            }
        }

        private OutletItem _outletItem;
        public OutletItem OutletItem
        {
            get
            {
                return _outletItem;
            }
        }

        private FixedAssetRegisterItem _fixedAssetRegisterItem;
        public FixedAssetRegisterItem FixedAssetRegisterItem
        {
            get
            {
                return _fixedAssetRegisterItem;
            }
        }

        private AddressPostCodeTowncityItem _addressPostCodeTowncityItem;
        public AddressPostCodeTowncityItem AddressPostCodeTowncityItem
        {
            get
            {
                return _addressPostCodeTowncityItem;
            }
        }

        private List<FirstRouteFrequenctSfKeyItem> _FirstRouteFrequenctSfKeyList;
        public List<FirstRouteFrequenctSfKeyItem> FirstRouteFrequenctSfKeyList
        {
            get
            {
                return _FirstRouteFrequenctSfKeyList;
            }
        }

        private List<ContractInfoByNoItem> _ContractInfoByNoList;
        public List<ContractInfoByNoItem> ContractInfoByNoList
        {
            get
            {
                return _ContractInfoByNoList;
            }
        }

        private List<RdsCustomInfoItem> _RdsCustomInfoList;
        public List<RdsCustomInfoItem> RdsCustomInfoList
        {
            get
            {
                return _RdsCustomInfoList;
            }
        }

        private List<CustomerAddressMovesDpIdCustIdItem> _CustomerAddressMovesDpIdCustIdList;
        public List<CustomerAddressMovesDpIdCustIdItem> CustomerAddressMovesDpIdCustIdList
        {
            get
            {
                return _CustomerAddressMovesDpIdCustIdList;
            }
        }

        private List<FirstPostCodeIdCodeItem> _FirstPostCodeIdCodeList;
        public List<FirstPostCodeIdCodeItem> FirstPostCodeIdCodeList
        {
            get
            {
                return _FirstPostCodeIdCodeList;
            }
        }

        private List<PostCodeIdCodeItem> _PostCodeIdCodeList;
        public List<PostCodeIdCodeItem> PostCodeIdCodeList
        {
            get
            {
                return _PostCodeIdCodeList;
            }
        }

        public static RDSDataService GetContractNoConDateTerminated(int? al_contractNo)
        {
            RDSDataService obj = Execute("_GetContractNoConDateTerminated", al_contractNo);
            return obj;
        }

        private List<ContractNoConDateTerminatedItem> _ContractNoConDateTerminatedList;
        public List<ContractNoConDateTerminatedItem> ContractNoConDateTerminatedList
        {
            get
            {
                return _ContractNoConDateTerminatedList;
            }
        }

        private List<ContractRenewalsItem> _contractRenewalsList;
        public List<ContractRenewalsItem> ContractRenewalsList
        {
            get
            {
                return _contractRenewalsList;
            }
        }

        public static RDSDataService LoadContractAdjustments()
        {
            RDSDataService obj = Execute("_LoadContractAdjustments");
            return obj;
        }

        public static RDSDataService GetCustomerAddressMovesCountByIdMoveOutDate(int? ll_new_adr_id)
        {
            RDSDataService obj = Execute("_GetCustomerAddressMovesCountByIdMoveOutDate", ll_new_adr_id);
            return obj;
        }

        public static RDSDataService DeleteAddressByAdrId(int? ll_old_adr_id)
        {
            RDSDataService obj = Execute("_DeleteAddressByAdrId", ll_old_adr_id);
            return obj;
        }

        public static RDSDataService GetCreateRoadId(string ls_userid, int? ll_rs_id, int? ll_tc_id, string ls_sl_name, string ls_road_name, int? ll_rt_id)
        {
            RDSDataService obj = Execute("_GetCreateRoadId", ls_userid, ll_rs_id, ll_tc_id, ls_sl_name, ls_road_name, ll_rt_id);
            return obj;
        }

        public static RDSDataService CheckValidateRoad(int? ll_tc_id, string ls_sl_name, string ls_road_name, int? ll_rt_id, int? ll_rs_id)
        {
            RDSDataService obj = Execute("_CheckValidateRoad", ll_tc_id, ls_sl_name, ls_road_name, ll_rt_id, ll_rs_id);
            return obj;
        }

        public static RDSDataService GetContractComplex3(string ls_and, string ls_town_name, string ls_rd_no, string ls_space, string ls_percent, string ls_comma)
        {
            RDSDataService obj = Execute("_GetContractComplex3", ls_and, ls_town_name, ls_rd_no, ls_space, ls_percent, ls_comma);
            return obj;
        }

        public static RDSDataService GetContractComplex2(string ls_and, string ls_town_name, string ls_rd_no, string ls_space, string ls_percent, int? ll_contract_no, string ls_comma)
        {
            RDSDataService obj = Execute("_GetContractComplex2", ls_and, ls_town_name, ls_rd_no, ls_space, ls_percent, ll_contract_no, ls_comma);
            return obj;
        }

        public static RDSDataService GetContractComplex(string ls_and, string ls_town_name, string ls_rd_no, string ls_space, string ls_percent, string ls_comma)
        {
            RDSDataService obj = Execute("_GetContractComplex", ls_and, ls_town_name, ls_rd_no, ls_space, ls_percent, ls_comma);
            return obj;
        }

        public static RDSDataService GetAddressCountByAdrId(int? al_adrID, int ll_contract_type_rd)
        {
            RDSDataService obj = Execute("_GetAddressCountByAdrId", al_adrID, ll_contract_type_rd);
            return obj;
        }

        public static RDSDataService GetRdsNpadAddrOccupied(string as_occupied, string is_npadoutfile, int? al_dpid, string is_userid, string as_description)
        {
            RDSDataService obj = Execute("_GetRdsNpadAddrOccupied", as_occupied, is_npadoutfile, al_dpid, is_userid, as_description);
            return obj;
        }

        public static RDSDataService GetContractRenewalsExists(int? al_contractNo)
        {
            RDSDataService obj = Execute("_GetContractRenewalsExists", al_contractNo);
            return obj;
        }

        public static RDSDataService GetPostCodeIdCode(int? al_tc_id)
        {
            RDSDataService obj = Execute("_GetPostCodeIdCode", al_tc_id);
            return obj;
        }

        public static RDSDataService GetAddressDpIdByAdrId(int? al_adrid)
        {
            RDSDataService obj = Execute("_GetAddressDpIdByAdrId", al_adrid);
            return obj;
        }

        public static RDSDataService GetFirstPostCodeIdCode(int? al_tcid, string ls_rdno)
        {
            RDSDataService obj = Execute("_GetFirstPostCodeIdCode", al_tcid, ls_rdno);
            return obj;
        }

        public static RDSDataService GetFirstPostCodeIdCode(int? al_tcid)
        {
            RDSDataService obj = Execute("_GetFirstPostCodeIdCode1", al_tcid);
            return obj;
        }

        public static RDSDataService GetTownSuburSlIdBySlName(int? al_tcid, string as_slname)
        {
            RDSDataService obj = Execute("_GetTownSuburSlIdBySlName", al_tcid, as_slname);
            return obj;
        }

        public static RDSDataService GetRdsNpadModifyCustomer(int? al_dpid, string is_userid, string is_npadoutfile, string ls_description)
        {
            RDSDataService obj = Execute("_GetRdsNpadModifyCustomer", al_dpid, is_userid, is_npadoutfile, ls_description);
            return obj;
        }

        public static RDSDataService UpdateAddressDpIdByAdrId(int? al_new_master_dpid, int? al_new_adr_id)
        {
            RDSDataService obj = Execute("_UpdateAddressDpIdByAdrId", al_new_master_dpid, al_new_adr_id);
            return obj;
        }

        public static RDSDataService GetRdsNpadDeleteCustomer(string is_npadoutfile, int? ll_dpid, string is_userid, string as_description)
        {
            RDSDataService obj = Execute("_GetRdsNpadDeleteCustomer", is_npadoutfile, ll_dpid, is_userid, as_description);
            return obj;
        }
       
        ///<summary>
        /// select f_getNextSequence('NPADFileSeq',1,10000) into :ll_npadfileseq from dummy
        public static RDSDataService GetRdsFGetNextSequence()
        {
            RDSDataService obj = Execute("_GetRdsFGetNextSequence");
            return obj;
        }

        /// <summary>
        /// select count(*) into :ll_at_adr from customer_address_moves where adr_id = :al_adr_id  and move_out_date is null
        /// 
        public static int GetRdsCustomerAddressMoves(int? al_adr_id)
        {
            RDSDataService obj = Execute("_GetRdsCustomerAddressMoves", al_adr_id);
            return obj.intVal;
        }

        public static RDSDataService GetCustomerAddressMovesDpIdCustId(int? al_adrid)
        {
            RDSDataService obj = Execute("_GetCustomerAddressMovesDpIdCustId", al_adrid);
            return obj;
        }

        public static RDSDataService GetManyRdsCustomInfo(int? al_adrid)
        {
            RDSDataService obj = Execute("_GetManyRdsCustomInfo", al_adrid);
            return obj;
        }

        public static RDSDataService UpdateCustomerAddressMovesByCustId(int? al_cust)
        {
            RDSDataService obj = Execute("_UpdateCustomerAddressMovesByCustId", al_cust);
            return obj;
        }

        public static RDSDataService GetRdsNpadTransferCustomer(string is_userid, string is_npadoutfile, int? al_old_dpid, string as_description, int? al_new_dpid)
        {
            RDSDataService obj = Execute("_GetRdsNpadTransferCustomer", is_userid, is_npadoutfile, al_old_dpid, as_description, al_new_dpid);
            return obj;
        }

        public static RDSDataService GetCustomerAddressMovesAdrIdByCustId(int? al_custID)
        {
            RDSDataService obj = Execute("_GetCustomerAddressMovesAdrIdByCustId", al_custID);
            return obj;
        }

        public static RDSDataService GetAddressAdrNo(int? al_adr_id)
        {
            RDSDataService obj = Execute("_GetAddressAdrNo", al_adr_id);
            return obj;
        }

        public static RDSDataService GetCustomerAddressMovesByCustId(int? al_custID)
        {
            RDSDataService obj = Execute("_GetCustomerAddressMovesByCustId", al_custID);
            return obj;
        }

        public static RDSDataService GetTownCityTcId(string as_tcname)
        {
            RDSDataService obj = Execute("_GetTownCityTcId", as_tcname);
            return obj;
        }

        public static RDSDataService GetTypesForContractCount(int? al_contract_no, int? ll_contract_type_rd)
        {
            RDSDataService obj = Execute("_GetTypesForContractCount", al_contract_no, ll_contract_type_rd);
            return obj;
        }

        public static RDSDataService SpExtensionDeliveryTime()
        {
            RDSDataService obj = Execute("_SpExtensionDeliveryTime");
            return obj;
        }

        public static RDSDataService InsertCustomerAddressMoves(int? il_addrid, int? ll_custid, DateTime? ldt_movein)
        {
            RDSDataService obj = Execute("_InsertCustomerAddressMoves", il_addrid, ll_custid, ldt_movein);
            return obj;
        }

        public static RDSDataService UpdateRdsCustomerById(int? al_master, int? al_custID)
        {
            RDSDataService obj = Execute("_UpdateRdsCustomerById", al_master, al_custID);
            return obj;
        }

        public static RDSDataService SpExtenstionRFDistance(int? lContract, string param2, int? param1)
        {
            RDSDataService obj = Execute("_SpExtenstionRFDistance", lContract, param2, param1);
            return obj;
        }

        public static RDSDataService SpExtensionDaysPerAnnum(int? ll_key, int? lContract)
        {
            RDSDataService obj = Execute("_SpExtensionDaysPerAnnum", ll_key, lContract);
            return obj;
        }

        public static RDSDataService SpGetCurrentRenewal(int? lContract)
        {
            RDSDataService obj = Execute("_SpGetCurrentRenewal", lContract);
            return obj;
        }

        public static RDSDataService GetContractCountByRenewalAndRgCode(int? lContract)
        {
            RDSDataService obj = Execute("_GetContractCountByRenewalAndRgCode", lContract);
            return obj;
        }

        public static RDSDataService SpExtensionCustCount2(string ls_ui_userid, int? lContract, int? ll_rc_id)
        {
            RDSDataService obj = Execute("_SpExtensionCustCount2", ls_ui_userid, lContract, ll_rc_id);
            return obj;
        }

        public static RDSDataService GetMaxContractRenewals(int? li_contract)
        {
            RDSDataService obj = Execute("_GetMaxContractRenewals", li_contract);
            return obj;
        }

        public static RDSDataService GetPrevBench(int? li_contract)
        {
            RDSDataService obj = Execute("_GetPrevBench", li_contract);
            return obj;
        }

        public static RDSDataService InsertFreqAdjustments(decimal? dBenchmark, int? lNextSeq, DateTime? dEffectiveDate, int? lSequence, int? lSFKey, string sDeliveryDays, decimal? dAmountToPay, int? lContract)
        {
            RDSDataService obj = Execute("_InsertFreqAdjustments", dBenchmark, lNextSeq, dEffectiveDate, lSequence, lSFKey, sDeliveryDays, dAmountToPay, lContract);
            return obj;
        }

        public static RDSDataService GetMaxFreqAdjustmentsSeqNumber(int? lSequence, int? lContract)
        {
            RDSDataService obj = Execute("_GetMaxFreqAdjustmentsSeqNumber", lSequence, lContract);
            return obj;
        }

        public static RDSDataService GetMaxContractRenewalsSeqNumber(int? lContract)
        {
            RDSDataService obj = Execute("_GetMaxContractRenewalsSeqNumber", lContract);
            return obj;
        }

        public static RDSDataService UpdateRouteFreqRfDist(int? lContract, decimal? dDistance, int? lSFKey, string sDeliveryDays)
        {
            RDSDataService obj = Execute("_UpdateRouteFreqRfDist", lContract, dDistance, lSFKey, sDeliveryDays);
            return obj;
        }

        public static RDSDataService InsertIntoFreqDist(int? lNoOtherBags, int? lVolume, int? lNoRuralBags, int? lNoCMBCustomers, DateTime? dEffectiveDate, int? lNoCMBS, int? lNoPostOffices, decimal? decDelHrs, string sReason, decimal? dDistance, int? lNoPrivateBags, int? lSFKey, string sDeliveryDays, int? lNoBoxes, int? lContract, decimal? decProcHrs)
        {
            RDSDataService obj = Execute("_InsertIntoFreqDist", lNoOtherBags, lVolume, lNoRuralBags, lNoCMBCustomers, dEffectiveDate, lNoCMBS, lNoPostOffices, decDelHrs, sReason, dDistance, lNoPrivateBags, lSFKey, sDeliveryDays, lNoBoxes, lContract, decProcHrs);
            return obj;
        }

        public static RDSDataService GetFreqDistCount(DateTime? dEffectiveDate, int? lContract, int? lSFKey, string sDeliveryDays)
        {
            RDSDataService obj = Execute("_GetFreqDistCount", dEffectiveDate, lContract, lSFKey, sDeliveryDays);
            return obj;
        }

        public static RDSDataService GetContractCountWithRenewals(DateTime? dEffectiveDate, int? lContract)
        {
            RDSDataService obj = Execute("_GetContractCountWithRenewals", dEffectiveDate, lContract);
            return obj;
        }

        public static RDSDataService DeleteFromTempContractAdjustments()
        {
            RDSDataService obj = Execute("_DeleteFromTempContractAdjustments");
            return obj;
        }

        public static RDSDataService DeleteAddressFreqSeqByContractNo(int? il_oldcontractno)
        {
            RDSDataService obj = Execute("_DeleteAddressFreqSeqByContractNo", il_oldcontractno);
            return obj;
        }

        public static RDSDataService UpdateAddressContractNo(int? ll_newcontractno, int? il_oldcontractno)
        {
            RDSDataService obj = Execute("_UpdateAddressContractNo", ll_newcontractno, il_oldcontractno);
            return obj;
        }

        public static RDSDataService GetContractCountByNo(int? ll_newcontractno)
        {
            RDSDataService obj = Execute("_GetContractCountByNo", ll_newcontractno);
            return obj;
        }

        public static RDSDataService GetContractInfoByNo(int? il_contract_no)
        {
            RDSDataService obj = Execute("_GetContractInfoByNo", il_contract_no);
            return obj;
        }

        public static RDSDataService InsertAddressFreqSeq(int? il_sf_key, int? ll_sequence_no, int? il_contract_no, int? ll_address_id, string is_delivery_days)
        {
            RDSDataService obj = Execute("_InsertAddressFreqSeq", il_sf_key, ll_sequence_no, il_contract_no, ll_address_id, is_delivery_days);
            return obj;
        }

        public static RDSDataService DeleteFromAddressFreqSeq(int? il_sf_key, int? il_contract_no, string is_delivery_days)
        {
            RDSDataService obj = Execute("_DeleteFromAddressFreqSeq", il_sf_key, il_contract_no, is_delivery_days);
            return obj;
        }

        public static RDSDataService GetContractConTitle(int? il_contract_no)
        {
            RDSDataService obj = Execute("_GetContractConTitle", il_contract_no);
            return obj;
        }

        public static RDSDataService UpdateCustomerAddressMovesDpId(int? il_customer, int? al_dpid)
        {
            RDSDataService obj = Execute("_UpdateCustomerAddressMovesDpId", il_customer, al_dpid);
            return obj;
        }

        public static RDSDataService InsertCustomerAddressMoves2(int? ll_cust, int? il_adrid)
        {
            RDSDataService obj = Execute("_InsertCustomerAddressMoves2", ll_cust, il_adrid);
            return obj;
        }

        public static RDSDataService GetNextSequence(string seqname)
        {
            RDSDataService obj = Execute("_GetNextSequence", seqname);
            return obj;
        }

        public static RDSDataService InsertCustomerAddressMoves3(int? ll_cust, int? il_adrid, int? ll_dpid)
        {
            RDSDataService obj = Execute("_InsertCustomerAddressMoves3", ll_cust, il_adrid, ll_dpid);
            return obj;
        }

        public static RDSDataService GetCustomerAddressMovesTemp(int? il_cust_id)
        {
            RDSDataService obj = Execute("_GetCustomerAddressMovesTemp", il_cust_id);
            return obj;
        }

        public static RDSDataService GetCustomerAddressMovesDpId(int? al_custId)
        {
            RDSDataService obj = Execute("_GetCustomerAddressMovesDpId", al_custId);
            return obj;
        }

        public static RDSDataService GetVovEffectiveDate(DateTime? ld_effective_date, int? il_sequence, int? il_contract)
        {
            RDSDataService obj = Execute("_GetVovEffectiveDate", ld_effective_date, il_sequence, il_contract);
            return obj;
        }

        public static RDSDataService GetContractCountByNoAndSeq(int? il_sequence, int? il_contract)
        {
            RDSDataService obj = Execute("_GetContractCountByNoAndSeq", il_sequence, il_contract);
            return obj;
        }

        public static RDSDataService GetFrequencyDistancesCount2(int? ll_sfkey, string ls_deldays, DateTime? ld_next_date, int? al_contract)
        {
            RDSDataService obj = Execute("_GetFrequencyDistancesCount2", ll_sfkey, ls_deldays, ld_next_date, al_contract);
            return obj;
        }

        public static RDSDataService GetFrequencyDistancesCount(int? ll_sfkey, string ls_deldays, DateTime? ld_next_date, int? al_contract)
        {
            RDSDataService obj = Execute("_GetFrequencyDistancesCount1", ll_sfkey, ls_deldays, ld_next_date, al_contract);
            return obj;
        }

        public static RDSDataService GetFirstRouteFrequenctSfKey(int? al_contract)
        {
            RDSDataService obj = Execute("_GetFirstRouteFrequenctSfKey", al_contract);
            return obj;
        }

        public static RDSDataService GetContractDateTerminated(int? al_contract)
        {
            RDSDataService obj = Execute("_GetContractDateTerminated", al_contract);
            return obj;
        }

        public static RDSDataService GetVehicleLifeCode(int? il_sequence, int? il_contract)
        {
            RDSDataService obj = Execute("_GetVehicleLifeCode", il_sequence, il_contract);
            return obj;
        }

        public static RDSDataService GetBenchmarkCalc2005(int? il_sequence, int? il_contract)
        {
            RDSDataService obj = Execute("_GetBenchmarkCalc2005", il_sequence, il_contract);
            return obj;
        }

        public static RDSDataService GetCaLoadResults()
        {
            RDSDataService obj = Execute("_GetCaLoadResults");
            return obj;
        }

        public static RDSDataService InsertTempContractAdjustments(string ls_date, string ls_reason, string ls_value, string ls_contract)
        {
            RDSDataService obj = Execute("_InsertTempContractAdjustments", ls_date, ls_reason, ls_value, ls_contract);
            return obj;
        }

        public static RDSDataService AddUsedPassword(string sOldPassword, int? ll_ui_id)
        {
            RDSDataService obj = Execute("_AddUsedPassword", sOldPassword, ll_ui_id);
            return obj;
        }

        public static RDSDataService UpdatePassword(string ls_ui_userid, DateTime dExpiry, string sNewPassword)
        {
            RDSDataService obj = Execute("_UpdatePassword", ls_ui_userid, dExpiry, sNewPassword);
            return obj;
        }

        public static RDSDataService GetUpPassword(int? ll_ui_id, string sNewPassword)
        {
            RDSDataService obj = Execute("_GetUpPassword", ll_ui_id, sNewPassword);
            return obj;
        }

        public static RDSDataService GetUiid(string ls_ui_userid)
        {
            RDSDataService obj = Execute("_GetUiid", ls_ui_userid);
            return obj;
        }
       
        public static RDSDataService InsertReportTemp(string sql)
        {
            RDSDataService obj = Execute("_InsertReportTemp", sql);
            return obj;
        }
       
        /// <summary> 
        ///  select count(*) into @ll_temp from address 
        ///   where adr_id = @ll_addressID using SQLCA;
        /// </summary>
        public static int SelectAddressCount(int? ll_addressID)
        {
            RDSDataService obj = Execute("_SelectAddressCount", ll_addressID);
            return obj.intVal; ;
        }

        ///<summary>
        /// UPDATE rds_customer 
        ///    SET printedon = (select today(*) from sys.dummy) 
        ///  WHERE customer.cust_id = @lCustId 
        public static bool UpdatePrintedon(int? lCustID)
        {
            RDSDataService obj = Execute("_UpdatePrintedon", lCustID);
            return obj.ret;
        }

        ///<summary>
        /// UPDATE rds_customer 
        ///    SET printedon = select today(*) 
        ///  WHERE customer.cust_id = @lcust ;
        public static bool UpdateRdsCustomerPrintedon(int lcust, ref int SQLCode)
        {
            RDSDataService obj = Execute("_UpdateRdsCustomerPrintedon", lcust);
            SQLCode = obj.SQLCode;
            return obj.ret;
        }

        ///<summary>
        /// update rd.contract
        ///    set cust_list_printed = today(*)
        ///  where contract_no in (select rds_id from rds_temp)
        public static bool UpdateRdContract(ref int SQLCode, ref string SQLErrText)
        {
            RDSDataService obj = Execute("_UpdateRdContract");
            SQLCode = obj.SQLCode;
            SQLErrText = obj.SQLErrText;
            return obj.ret;
        }

        /// <summary>
        /// UPDATE artical_count SET ac_scale_factor = @decScalingFactor  
        /// WHERE artical_count.ac_start_week_period = @dDate  
        /// AND artical_count.contract_seq_number is null ;
        /// </summary>
        public static int UpdateArticalCountValue(decimal? decScalingFactor, DateTime? dDate)
        {
            RDSDataService obj = Execute("_UpdateArticalCountValue", decScalingFactor, dDate);
            return obj.SQLNRows;
        }

        /// <summary>
        ///UPDATE artical_count SET ac_scale_factor = @decScalingFactor  
        ///WHERE artical_count.ac_start_week_period = @dDate  
        ///AND ac_scale_factor is null 
        ///AND contract_seq_number is null;      
        /// </summary>
        public static int UpdateArticalCountValue2(decimal? decScalingFactor, DateTime? dDate)
        {
            RDSDataService obj = Execute("_UpdateArticalCountValue2", decScalingFactor, dDate);
            return obj.SQLNRows;
        }

        /// <summary>
        /// select outlet_id
        ///   into @lOutletId
        ///   from outlet
        ///  where o_name = @sOutlet
        /// </summary>
        public static int? GetOutlet(string sOutlet, ref int SQLCode)
        {
            RDSDataService obj = Execute("_GetOutlet", sOutlet);
            SQLCode = obj.SQLCode;
            return obj.intVal;
        }

        /// <summary>
        /// SELECT count(*) INTO @ll_Count 
        /// FROM non_vehicle_rate  
        /// WHERE rg_code = @ll_rgCode AND nvr_rates_effective_date > @ld_EffDate;
        /// </summary>
        public static int GetNonVehicleRateCount(int? ll_rgCode, DateTime? ld_EffDate)
        {
            RDSDataService obj = Execute("_GetNonVehicleRateCount", ll_rgCode, ld_EffDate);
            return obj.intVal;
        }

        /// <summary>
        /// select min(tc_id)
        ///   into @ll_tc_id
        ///   from towncity
        ///  where towncity.tc_name = @ls_town
        /// </summary>
        public static int GetTowncityLlTcId(string ls_town)
        {
            RDSDataService obj = Execute("_GetTowncityLlTcId", ls_town);
            return obj.intVal;
        }

        /// <summary>
        ///SELECT count(*) INTO @ll_Count FROM non_vehicle_rate 
        /// WHERE rg_code = @ll_rgcode AND 
        /// (nvr_frozen_indicator = 'N' or nvr_frozen_indicator is null);
        /// </summary>
        public static int GetNonVehicleRateCount2(int? ll_rgcode)
        {
            RDSDataService obj = Execute("_GetNonVehicleRateCount2", ll_rgcode);
            return obj.intVal;
        }

        /// <summary>
        ///SELECT count(*)  INTO @ll_Count  FROM non_vehicle_rate 
        /// WHERE non_vehicle_rate.rg_code = @ll_rgcode AND 
        /// non_vehicle_rate.nvr_rates_effective_date = @ld_EffDate ;
        /// </summary>
        public static int GetNonVehicleRateCount3(int? ll_rgcode, DateTime? ld_EffDate)
        {
            RDSDataService obj = Execute("_GetNonVehicleRateCount3", ll_rgcode, ld_EffDate);
            return obj.intVal;
        }

        /// <summary>
        /// SELECT count ( non_vehicle_rate.rg_code) into @ll_Cnt FROM non_vehicle_rate,vehicle_rate  
        /// WHERE non_vehicle_rate.nvr_rates_effective_date = vehicle_rate.vr_rates_effective_date  and  
        /// (  non_vehicle_rate.nvr_frozen_indicator is null  OR  non_vehicle_rate.nvr_frozen_indicator = 'N' ) 
        /// and vehicle_rate.vr_rates_effective_date = @id_renewaldate;
        /// </summary>
        public static int GetNonVehicleRateVehicleRateCount(DateTime? id_renewaldate)
        {
            RDSDataService obj = Execute("_GetNonVehicleRateVehicleRateCount", id_renewaldate);
            return obj.intVal;
        }

        /// <summary>
        /// SELECT max(vr_rates_effective_date) INTO @ld_Max_Effective_Date FROM vehicle_rate WHERE vt_key = @ll_vtKey;
        /// </summary>
        public static DateTime? GetVehicleRateMax(int? ll_vtKey)
        {
            RDSDataService obj = Execute("_GetVehicleRateMax", ll_vtKey);
            return obj.dtVal;
        }

        /// <summary>
        /// select cust_list_updated
        ///   into @ld_con_actioned
        ///   from rd.contract 
        ///  where contract_no = @ll_selected_contracts
        ///    and cust_list_updated is not null
        /// </summary>
        public static DateTime? GetLdConActioned(int? ll_selected_contracts)
        {
            RDSDataService obj = Execute("_GetLdConActioned", ll_selected_contracts);
            return obj.dtVal;
        }

        ///<summary>
        /// insert into rds_temp	
        ///      (rds_id, rds_code)
        /// values
        ///      (@ll_selected_contracts, @ll_recip)
        /// </summary>
        public static void InsertRdsTemp(int? ll_selected_contracts, int? ll_recip)
        {
            RDSDataService obj = Execute("_InsertRdsTemp", ll_selected_contracts, ll_recip);
        }

        /// <summary>
        /// Complex sql state
        /// </summary>
        /// <param name="ll_addressID"></param>
        public static string ComplexSqlState(DateTime? id_renewaldate, int? il_rg_code)
        {
            RDSDataService obj = Execute("_ComplexSqlState", id_renewaldate, il_rg_code);
            return obj._sqlerrtext;
        }

        /// <summary>
        /// SELECT max(nvr_rates_effective_date) INTO @ld_Max_Effective_Date  FROM non_vehicle_rate WHERE rg_code = @il_rg_code;
        /// </summary>
        public static DateTime? GetNonVehicleRateMax(int? il_rg_code)
        {
            RDSDataService obj = Execute("_GetNonVehicleRateMax", il_rg_code);
            return obj.dtVal;
        }

        /// <summary>
        /// SELECT nvr_contract_end  INTO @ld_Date_To FROM non_vehicle_rate WHERE rg_code = @il_rg_code AND nvr_rates_effective_date = @ld_Max_Effective_Date;
        /// </summary>
        /// <param name="ll_addressID"></param>
        public static DateTime? GetNonVehicleRateValue(int? il_rg_code, DateTime? ld_Max_Effective_Date)
        {
            RDSDataService obj = Execute("_GetNonVehicleRateValue", il_rg_code, ld_Max_Effective_Date);
            return obj.dtVal;
        }

        /// <summary>
        /// SELECT max(rr_rates_effective_date) 
        ///   INTO @ld_Max_Effective_Date 
        ///   FROM Fuel_rates 
        ///   where rg_code = @il_rg_code;
        /// </summary>
        /// <param name="lCustID"></param>
        public static DateTime? GetFuelRatesMax(int? il_rg_code, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetFuelRatesMax", il_rg_code);// ref sqlCode,ref sqlErrText);
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
            return obj.dtVal;
        }

        /// <summary>
        /// SELECT max(pr_effective_date) INTO @ld_Max_PrEffective_Date FROM piece_rate WHERE rg_code = @il_rg_code;
        /// </summary>
        public static DateTime? GetPieceRateMax(int? il_rg_code, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetPieceRateMax", il_rg_code);//, ref sqlCode, ref sqlErrText);
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
            return obj.dtVal;
        }

        /// <summary>
        /// SELECT max(rr_rates_effective_date) INTO @ld_Max_PrEffective_Date FROM rate_days WHERE rg_code =@il_rg_code;
        /// </summary>
        public static DateTime? GetRateDaysMax(int? il_rg_code, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetRateDaysMax", il_rg_code);//, ref sqlCode, ref sqlErrText);
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
            return obj.dtVal;
        }

        /// <summary>
        /// SELECT max(mr_effective_date) INTO @ld_Max_Effective_Date FROM misc_rate WHERE rg_code = @il_rg_code;
        /// </summary>
        public static DateTime? GetMiscRateMax(int? il_rg_code, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetMiscRateMax", il_rg_code);//, ref sqlCode, ref sqlErrText);
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
            return obj.dtVal;
        }

        /// <summary>
        /// select count(*) into @ll_Count1 from fuel_type ,fuel_rates where fuel_type.ft_key = fuel_rates.ft_key and fuel_rates.rr_rates_effective_date = @ld_Date and fuel_rates.rg_code = @ll_RGCode and (fuel_rates.fr_fuel_rate is null or fuel_rates.fr_fuel_consumtion_rate is null);
        /// </summary>
        public static int GetFuelTypeFuelRatesCount(DateTime? ld_Date, int? ll_RGCode)
        {
            RDSDataService obj = Execute("_GetFuelTypeFuelRatesCount", ld_Date, ll_RGCode);
            return obj.intVal;
        }

        /// <summary>
        /// select count(*) into @ll_Count2  from standard_frequency ,rate_days where standard_frequency.sf_key = rate_days.sf_key and rate_days.rr_rates_effective_date = @ld_Date and rate_days.rg_code = @ll_RGCode and rate_days.rtd_days_per_annum is null;
        /// </summary>
        public static int GetStandardFrequencyRateDaysCount(DateTime? ld_Date, int? ll_RGCode)
        {
            RDSDataService obj = Execute("_GetStandardFrequencyRateDaysCount", ld_Date, ll_RGCode);
            return obj.intVal;
        }

        /// <summary>
        /// SELECT count(*) INTO @ll_Count3  FROM piece_rate WHERE piece_rate.pr_effective_date = @ld_Date AND piece_rate.rg_code =  @ll_RGCode  AND pr_active_status = 'Y' AND pr_rate is null;
        /// </summary>
        public static int GetPieceRateCount(DateTime? ld_Date, int? ll_RGCode)
        {
            RDSDataService obj = Execute("_GetPieceRateCount", ld_Date, ll_RGCode);
            return obj.intVal;
        }

        /// <summary>
        /// SELECT count(*) INTO @ll_NumVehicleTypes  FROM vehicle_type;
        /// </summary>
        public static int GetVehicleTypeCount()
        {
            RDSDataService obj = Execute("_GetVehicleTypeCount");
            return obj.intVal;
        }

        /// <summary>
        /// SELECT count(vehicle_rate.vt_key)
        ///   INTO @ll_NumVehicleTypesFilled
        ///   FROM vehicle_rate
        ///  WHERE vehicle_rate.vr_rates_effective_date = @ld_Date  AND 
        ///        vehicle_rate.vr_nominal_vehicle_value is not null  AND 
        ///        vehicle_rate.vr_repairs_maintenance_rate is not null AND 
        ///        vehicle_rate.vr_tyre_tubes_rate is not null AND 
        ///        vehicle_rate.vr_vehicle_allowance_rate is not null AND 
        ///        vehicle_rate.vr_licence_rate is not null AND 
        ///        vehicle_rate.vr_vehicle_rate_of_return_pct is not null AND 
        ///        vehicle_rate.vr_salvage_ratio is not null AND 
        ///        vehicle_rate.vr_ruc is not null AND 
        ///        vehicle_rate.vr_sundries_k is not null AND 
        ///        vehicle_rate.vr_vehicle_value_insurance_pct is not null;
        /// </summary>
        public static int GetVehicleRateCount(DateTime? ld_Date)
        {
            RDSDataService obj = Execute("_GetVehicleRateCount", ld_Date);
            return obj.intVal;
        }

        /// <summary> 
        ///  select max(ca_effective_date) into @ld_maxdate from contract_allowance where contract_no = @il_contract and alt_key = @ll_altkey
        /// </summary>
        public static DateTime? GetContractAllownceMaxCaEffective(int? il_contract, int? ll_altkey, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetContractAllownceMaxCaEffective", il_contract, ll_altkey);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.dtVal; ;
        }

        ///<summary>
        /// UPDATE artical_count set contract_seq_number = null 
        ///  where contract_no = @lContract and contract_seq_number	= @lrenewal;
        /// </summary>
        public static bool UpdateArticalCountContractSeqNumber(int? lContract, int? lrenewal, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_UpdateArticalCountContractSeqNumber", lContract, lrenewal);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.ret;
        }

        ///<summary>
        /// UPDATE contract set cust_list_printed = today() 
        ///  where contract_no = @il_id
        /// </summary>
        public static bool UpdateCustListPrinted(int? il_id, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_UpdateCustListPrinted", il_id);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.ret;
        }

        /// <summary> 
        /// select count(artical_count.contract_no) 
        ///   into @lcount 
        ///   from artical_count 
        ///  where artical_count.contract_no = @lContract and 
        ///        artical_count.contract_seq_number is null and 
        ///        artical_count.ac_start_week_period > @ldt_YearAgo
        /// </summary>
        public static int? GetArticalCountConut(int? lContract, DateTime? ldt_YearAgo, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetArticalCountConut", lContract, ldt_YearAgo);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.intVal; ;
        }

        /// <summary> 
        /// select count(*) 
        ///   into @row_count
        ///   from address addr 
        ///  where addr.tc_id = @il_long_parm
        /// </summary>
        public static int GetAddrTcId(int? il_long_parm, ref int SQLCode, ref string SQLErrText)
        {
            RDSDataService obj = Execute("_GetAddrTcId", il_long_parm);
            SQLCode = obj.SQLCode;
            SQLErrText = obj.SQLErrText;
            return obj.intVal; ;
        }

        /// <summary> 
        ///  select count (*) into @row_count from address addr 
        ///   where addr.contract_no = @il_long_parm
        /// </summary>
        public static int GetAddrContractNo(int? il_long_parm, ref int SQLCode, ref string SQLErrText)
        {
            RDSDataService obj = Execute("_GetAddrContractNo", il_long_parm);
            SQLCode = obj.SQLCode;
            SQLErrText = obj.SQLErrText;
            return obj.intVal; ;
        }

        /// <summary> 
        /// select con_start_date into @dStartDate from	contract_renewals 
        ///  where contract_renewals.contract_no = @lContract and
        ///        contract_renewals.contract_seq_number = @lrenewal - 1;
        /// </summary>
        public static DateTime? GetContractRenewalsConStartDate(int? lContract, int? lrenewal, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetContractRenewalsConStartDate1", lContract, lrenewal);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.dtVal; ;
        }

        /// <summary> 
        ///  select contract_renewals.con_volume_at_renewal 
        ///             + sum(ifnull(frequency_distances.fd_volume,0,frequency_distances.fd_volume)) 
        ///    into @lVolAtRen 
        ///    from contract_renewals, 
        ///         route_frequency left outer join frequency_distances 
        ///             on route_frequency.contract_no = frequency_distances.contract_no and 
        ///                route_frequency.sf_key = frequency_distances.sf_key and 
        ///                route_frequency.rf_delivery_days = frequency_distances.rf_delivery_days and 
        ///                frequency_distances.fd_effective_date> = @dStartDate, 
        ///         rate_days 
        ///   where contract_renewals.contract_no = route_frequency.contract_no and	
        ///         route_frequency.sf_key = rate_days.sf_key and 
        ///         contract_renewals.con_rates_effective_date = rate_days.rr_rates_effective_date and 
        ///         contract_renewals.con_rg_code_at_renewal = rate_days.rg_code and
        ///         contract_renewals.contract_no = @lContract and
        ///         contract_renewals.contract_seq_number = (@lrenewal - 1) 
        ///   group by 
        ///         contract_renewals.contract_no, contract_renewals.con_volume_at_renewal;
        /// </summary>
        public static int? GetContractRenewalsConVolumeAtRenewal(DateTime? dStartDate, int? lContract, int? lrenewal, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetContractRenewalsConVolumeAtRenewal", dStartDate, lContract, lrenewal);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.intVal; ;
        }

        ///<summary>
        /// UPDATE contract_renewals set con_volume_at_renewal = @lVolAtRen where contract_no = @lContract and contract_seq_number = @lrenewal;
        /// </summary>
        public static void UpdateContractRenewalsConVolumeAtRenewal(int? lVolAtRen, int? lContract, int? lrenewal, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_UpdateContractRenewalsConVolumeAtRenewal", lVolAtRen, lContract, lrenewal);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
        }

        ///<summary>
        /// UPDATE artical_count set contract_seq_number = @lrenewal where contract_no = @lContract and	 contract_seq_number is null and artical_count.ac_start_week_period > @ldt_YearAgo
        /// </summary>
        public static void UpdateArticalCountContractSeqNumber1(int? lrenewal, int? lContract, DateTime? ldt_YearAgo, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_UpdateArticalCountContractSeqNumber1", lrenewal, lContract, ldt_YearAgo);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
        }

        ///<summary>
        /// UPDATE artical_count set contract_seq_number=@lrenewal where contract_no=@lContract and ( contract_seq_number is null or contract_seq_number=@lrenewal) and ac_start_week_period = ( select max(ac_start_week_period) from artical_count as a2 where  a2.contract_no = @lContract and ( contract_seq_number is null or contract_seq_number = @lrenewal) and  ac_start_week_period > @ldt_YearAgo);
        /// </summary>
        public static void UpdateArticalCountContractSeqNumber2(int? lrenewal, int? lContract, DateTime? ldt_YearAgo, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_UpdateArticalCountContractSeqNumber21", lrenewal, lContract, ldt_YearAgo);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
        }

        /// <summary> 
        /// select max(ac_start_week_period) 
        ///   into @ldt_LastCountDate 
        ///   from artical_count as a2 
        ///  where a2.contract_no = @lContract and 
        ///        (contract_seq_number is null or contract_seq_number = @lrenewal) and
        ///        ac_start_week_period > @ldt_YearAgo;
        /// </summary>
        public static DateTime? GetArticalCountAcStartWeekPeriodMax(int? lContract, int? lrenewal, DateTime? ldt_YearAgo, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetArticalCountAcStartWeekPeriodMax", lContract, lrenewal, ldt_YearAgo);
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
            return obj.dtVal; ;
        }

        /// <summary>
        /// SELECT	route_frequency.sf_key, route_frequency.rf_delivery_days, route_frequency.rf_distance  
        //  FROM route_frequency WHERE 	route_frequency.rf_active = 'Y' AND route_frequency.contract_no = @ll_Contract;
        /// </summary>
        public static RDSDataService GetRouteFrequencyList(int ll_Contract)
        {
            RDSDataService obj = Execute("_GetRouteFrequencyList", ll_Contract);
            return obj;
        }

        /// <summary>
        /// select rtd_days_per_annum into @ll_DaysYear from rate_days where rg_code = @il_RGCode and rr_rates_effective_date = @ld_EffectDate and sf_key = @ll_SfKey;
        /// </summary>
        public static int GetRateDaysValue(int il_RGCode, DateTime ld_EffectDate, int ll_SfKey)
        {
            RDSDataService obj = Execute("_GetRateDaysValue", il_RGCode, ld_EffectDate, ll_SfKey);
            return obj.intVal;
        }

        /// <summary>
        /// SELECT  vt_key,vt_description FROM vehicle_type where vt_key = 2 
        /// union SELECT  vt_key, vt_description FROM vehicle_type where vt_key = 1
        /// union SELECT  vt_key, vt_description FROM vehicle_type where vt_key not in  ( 1, 2);
        /// </summary>
        public static RDSDataService GetVehicleTypeList()
        {
            RDSDataService obj = Execute("_GetVehicleTypeList");
            return obj;
        }

        ///<summary>
        /// UPDATE artical_count set contract_seq_number=@lrenewal where contract_no=@lContract and ( contract_seq_number is null  or contract_seq_number=@lrenewal) and ac_start_week_period =  ( select max(ac_start_week_period) from artical_count as a2 where  a2.contract_no = @lContract and ( contract_seq_number is null or contract_seq_number = @lrenewal) and  ac_start_week_period > @ldt_YearAgo and  ac_start_week_period @ldt_LastCountDate);
        /// </summary>
        public static void UpdateArticalCountContractSeqNumber3(int? lrenewal, int? lContract, DateTime? ldt_YearAgo, DateTime? ldt_LastCountDate, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_UpdateArticalCountContractSeqNumber2", lrenewal, lContract, ldt_YearAgo, ldt_LastCountDate);
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
        }

        /// <summary> 
        /// select top 1 cmb_id into @ll_cmb_id2 from cmb_address where contract_no  = @il_contract and post_code_id = @ll_pcid and cmb_box_no   = @ls_box_no using SQLCA;
        /// </summary>
        public static int? GetCmbAddressCmbIdFirst(int? il_contract, int? ll_pcid, string ls_box_no)
        {
            RDSDataService obj = Execute("_GetCmbAddressCmbIdFirst", il_contract, ll_pcid, ls_box_no);
            return obj.intVal; ;
        }

        /// <summary> 
        /// select top 1 cmb_id into @ll_cmb_id2 from cmb_address where contract_no  = @il_contract and post_code_id = @ll_pcid and cmb_box_no   = @ls_box_no and not cmb_id   = @ll_cmb_id using SQLCA;
        /// </summary>
        public static int? GetCmbAddressCmbIdFirst1(int? il_contract, int? ll_pcid, string ls_box_no, int? ll_cmb_id)
        {
            RDSDataService obj = Execute("_GetCmbAddressCmbIdFirst1", il_contract, ll_pcid, ls_box_no, ll_cmb_id);
            return obj.intVal; ;
        }

        /// <summary> 
        /// select top 1 adr_rd_no into @ll_rd_no from address where contract_no  = @al_contract and post_code_id = @al_pcid using SQLCA;
        /// </summary>
        public static int? GetAddressAdrRdNoFirst(int? al_contract, int? al_pcid)
        {
            RDSDataService obj = Execute("_GetAddressAdrRdNoFirst", al_contract, al_pcid);
            return obj.intVal; ;
        }

        /// <summary> 
        /* SELECT rgn_name  INTO @ls_Temp  FROM region  WHERE region_id = @ll_regionId;*/
        /// </summary>
        public static string GetRegion(int? ll_regionId)
        {
            RDSDataService obj = Execute("_GetRegion", ll_regionId);
            return obj.strVal; ;
        }

        /// <summary> 
        /* SELECT outlet.o_name  INTO @sTemp  FROM outlet  WHERE outlet.outlet_id = @lOutlet;*/
        /// </summary>
        public static string GetOutletId(int? lOutlet)
        {
            RDSDataService obj = Execute("_GetOutletId", lOutlet);
            return obj.strVal; ;
        }

        /// <summary> 
        /* SELECT contract_type.contract_type  INTO @sTemp  FROM contract_type  WHERE contract_type.ct_key = @lContractType;*/
        /// </summary>
        public static string GetCtKey(int? lContractType)
        {
            RDSDataService obj = Execute("_GetCtKey", lContractType);
            return obj.strVal; ;
        }

        /// <summary> 
        /* SELECT rg_description  INTO @ls_Temp  FROM renewal_group  WHERE rg_code = @ll_rgCode;*/
        /// </summary>
        public static string GetRenewalGroup(int? ll_rgCode)
        {
            RDSDataService obj = Execute("_GetRenewalGroup", ll_rgCode);
            return obj.strVal; ;
        }

        /// <summary> 
        /* SELECT contract_type INTO @ls_Temp  FROM contract_type  WHERE ct_key = @ll_ctKey;*/
        /// </summary>
        public static string GetContractType(int? ll_ctKey)
        {
            RDSDataService obj = Execute("_GetContractType", ll_ctKey);
            return obj.strVal; ;
        }

        /// <summary> 
        /// select tc_name into @ls_town from towncity where tc_id = @al_tcid;
        /// </summary>
        public static string GetTowncityTcName(int? al_tcid)
        {
            RDSDataService obj = Execute("_GetTowncityTcName", al_tcid);
            return obj.dataObject; ;
        }

        /// <summary> 
        /// select post_code into @ls_postcode from post_code where post_code_id = @al_pcid;
        /// </summary>
        public static string GetPostCodePostCode(int? al_pcid)
        {
            RDSDataService obj = Execute("_GetPostCodePostCode", al_pcid);
            return obj.dataObject; ;
        }

        // TJB  RD7_CR001  Nov-2009: Added
        /// <summary> 
        /// select contract_no into @ll_contract from post_code where post_code = @as_postcode;
        /// </summary>
        public static int GetPostCodeContractNo(string as_postcode)
        {
            RDSDataService obj = Execute("_GetPostCodeContractNo", as_postcode);
            return obj.intVal; ;
        }

        /// <summary>
        /// SELECT vr_nominal_vehicle_value, vr_repairs_maintenance_rate, vr_tyre_tubes_rate,vr_vehicle_allowance_rate, 
        /// vr_licence_rate, vr_vehicle_rate_of_return_pct,vr_salvage_ratio, vr_ruc, 
        /// vr_sundries_k,  vr_vehicle_value_insurance_pct,vr_livery, nvr_vehicle_insurance_base_premium
        /// INTO @ldec_nominal_vehicle_value, @ldec_repairs_maintenance_rate, @ldec_tyre_tubes_rate,@ldec_vehicle_allowance_rate,
        /// @ldec_licence_rate, @ldec_vehicle_rate_of_return_pct,@ldec_salvage_ratio, @ldec_ruc, 
        /// @ldec_sundries_k, @ldec_vehicle_value_insurance_pct,@ldec_livery, @ldec_vehicle_insurance_base_premium
        /// FROM vehicle_rate, non_vehicle_rate 
        /// WHERE vt_key = @ll_vtkey AND vr_rates_effective_date =  @id_effectdate 
        /// AND non_vehicle_rate.nvr_rates_effective_date  = vehicle_rate.vr_rates_effective_date 
        /// AND non_vehicle_rate.rg_code = @il_rgcode ;
        /// </summary>
        public static RDSDataService GetMoreValues1(int ll_vtkey, DateTime id_effectdate, int il_rgcode)
        {
            RDSDataService obj = Execute("_GetMoreValues1", ll_vtkey, id_effectdate, il_rgcode);
            return obj;
        }

        /// <summary>
        ///   SELECT top 1
        ///   vor_nominal_vehicle_value ,vor_repairs_maintenance_rate ,vor_tyre_tubes_rate,vor_vehical_allowance_rate ,
        ///   vor_licence_rate ,vor_vehicle_rate_of_return_pct ,vor_salvage_ratio ,vor_ruc ,
        ///   vor_sundries_k ,vor_vehicle_insurance_premium ,vor_livery
        ///   INTO @ldec_vor_nominal_vehicle_value , @ldec_vor_repairs_maintenance_rate , @ldec_vor_tyre_tubes_rate ,
        ///   @ldec_vor_vehicle_allowance_rate , @ldec_vor_licence_rate , @ldec_vor_vehicle_rate_of_return_pct ,
        ///   @ldec_vor_salvage_ratio , @ldec_vor_ruc , @ldec_vor_sundries_k , 
        ///   @ldec_vor_vehicle_insurance_premium , @ldec_vor_livery 
        ///   FROM vehicle_override_rate
        ///   WHERE contract_no = @il_contract and contract_seq_number = @il_sequence 
        ///   order by vor_effective_date desc;
        /// </summary>
        public static RDSDataService GetVehicleOverrideRateList(int? il_contract, int? il_sequence)
        {
            RDSDataService obj = Execute("_GetVehicleOverrideRateList", il_contract, il_sequence);
            return obj;
        }

        /// <summary> 
        /// select count (mail_carried.mc_dispatch_carried)
        ///   into @ll_num_dispatches
        ///   from contract, outlet, contract_renewals, mail_carried
        ///  where contract.contract_no = @lContract
        ///    and contract.con_base_office=outlet.outlet_id
        ///    and contract.contract_no=contract_renewals.contract_no
        ///    and contract_renewals.contract_seq_number=@lSequence
        ///    and contract.contract_no=mail_carried.contract_no
        ///    and mail_carried.mc_disbanded_date is null
        /// </summary>
        public static int GetLlNumDispatchesInfo(int lContract, int lSequence, ref int SQLCode, ref string SQLErrText)
        {
            RDSDataService obj = Execute("_GetLlNumDispatchesInfo", lContract, lSequence);
            SQLCode = obj.SQLCode;
            SQLErrText = obj.SQLErrText;
            return obj.intVal;
        }

        /// <summary> 
        ///SELECT count (*) INTO @ll_dup 
        ///  FROM contractor 
        /// WHERE Upper(c_surname_company).Trim() = @sSurname AND
        ///       (@sFirstName IS NULL OR Upper(c_first_names).Trim() = @sFirstName) 
        /// </summary>
        public static int? GetContractorCount(string sSurname, string sFirstName, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetContractorCount", sSurname, sFirstName);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.intVal;
        }

        /// <summary> 
        ///Select count (*) Into @lCount 
        ///  From contractor_renewals cr, contract c, outlet o 
        /// Where cr.contract_no=c.contract_no And 
        ///       c.con_base_office=o.outlet_id And 
        ///       o.region_id=@ll_Region And 
        ///       cr.contractor_supplier_no = @ii_contractor;
        /// </summary>
        public static int? GetContractorRenewalsCount(int? ll_Region, int? ii_contractor)
        {
            RDSDataService obj = Execute("_GetContractorRenewalsCount", ll_Region, ii_contractor);
            return obj.intVal; ;
        }

        /// <summary>
        /// SELECT 	max(rtd_days_per_annum) INTO @iDelDays 
        /// FROM standard_frequency join rate_days on standard_frequency.sf_key = rate_days.sf_key 	and 
        /// rate_days.rg_code = @il_RgCode and rate_days.rr_rates_effective_date= @id_EffectiveDate and 
        /// standard_frequency.sf_days_week	= @iWeekDelDays;
        /// </summary>
        public static int GetStandardFrequencyValues(int il_RgCode, DateTime id_EffectiveDate, int iWeekDelDays)
        {
            RDSDataService obj = Execute("_GetStandardFrequencyValues", il_RgCode, id_EffectiveDate, iWeekDelDays);
            return obj.intVal;
        }

        /// <summary>
        /// select region_id into @lRegionId from outlet where outlet_id = @ll_Outlet;
        /// </summary>
        public static int GetOutletRegionId(int? ll_Outlet)
        {
            RDSDataService obj = Execute("_GetOutletRegionId", ll_Outlet);
            return obj.intVal;
        }

        ///<summary>
        /// Insert into fixed_asset_register (fa_fixed_asset_no,fat_id,fa_owner,fa_purchase_date,fa_purchase_price) Values ( @sFixedAssetKey,@lFatId, @sFAOwner,@dFAPurchaseDate,@decFAPurchasePrice);
        /// </summary>
        public static void InsertFixedAssetRegister(string sFixedAssetKey, int? lFatId, string sFAOwner, DateTime? dFAPurchaseDate, decimal? decFAPurchasePrice)
        {
            RDSDataService obj = Execute("_InsertFixedAssetRegister", sFixedAssetKey, lFatId, sFAOwner, dFAPurchaseDate, decFAPurchasePrice);
        }

        ///<summary>
        /// UPDATE fixed_asset_register set fat_id = @lFatId,fa_owner = @sFAOwner,fa_purchase_date = @dFAPurchaseDate,fa_purchase_price = @decFAPurchasePrice where 	fa_fixed_asset_no = @sFixedAssetKey;
        /// </summary>
        public static void UpdateFixedAssetRegister(int? lFatId, string sFAOwner, DateTime? dFAPurchaseDate, decimal? decFAPurchasePrice, string sFixedAssetKey)
        {
            RDSDataService obj = Execute("_UpdateFixedAssetRegister", lFatId, sFAOwner, dFAPurchaseDate, decFAPurchasePrice, sFixedAssetKey);
        }

        /// <summary>
        /// select cust_list_printed into @ld_cust_printed from contract where contract_no = @il_Contract_no using SQLCA;
        /// </summary>
        public static DateTime? GetContractCustListPrinted(int il_Contract_no)
        {
            RDSDataService obj = Execute("_GetContractCustListPrinted", il_Contract_no);
            return obj.dtVal;
        }

        /// <summary>
        /// select cust_list_updated into @ld_cust_updated from contract where contract_no = @il_Contract_no using SQLCA;
        /// </summary>
        public static DateTime? GetContractCustListUpdated(int il_Contract_no)
        {
            RDSDataService obj = Execute("_GetContractCustListUpdated", il_Contract_no);
            return obj.dtVal;
        }

        ///<summary>
        /// UPDATE contract set cust_list_updated = @ld_custlist_updated where contract_no = @il_contract_no using SQLCA;
        /// </summary>
        public static void UpdateContractCustListUpdated(DateTime? ld_custlist_updated, int? il_contract_no, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_UpdateContractCustListUpdated", ld_custlist_updated, il_contract_no);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
        }

        ///<summary>
        /// INSERT INTO contract_cust_transfer 
        ///     (from_contract_no, to_contract_no, transfer_date)
        /// VALUES 
        ///     (@lContractNo, @ln, @tod);
        /// </summary>
        public static void InsertContractCustTransfer(int? lContractNo, int? ln, DateTime? tod, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_InsertContractCustTransfer", lContractNo, ln, tod);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
        }

        ///<summary>
        /// insert into t_custstat (id) values (@lID);
        /// </summary>
        public static void InsertTCuststat(int? lID, ref int SQLCode, ref string SQLErrText)
        {
            RDSDataService obj = Execute("_InsertTCuststat", lID);
            SQLCode = obj.SQLCode;
            SQLErrText = obj.SQLErrText;
        }

        /// <summary>
        /// select top 1 (tc_id) into @li_tc_id from address 
        ///  where contract_no = @ai_contract_no;
        /// </summary>
        public static int GetAddressTcIdFirst(int ai_contract_no)
        {
            RDSDataService obj = Execute("_GetAddressTcIdFirst", ai_contract_no);
            return obj.intVal;
        }

        /// <summary>
        /// SELECT max(pc.post_code_id) INTO @li_postcode_id FROM post_code pc, towncity tc WHERE tc.tc_id = @ai_tc_id AND pc.post_mail_town = tc.tc_name;
        /// </summary>
        public static int GetPostCodePostCodeIdMax(int ai_tc_id)
        {
            RDSDataService obj = Execute("_GetPostCodePostCodeIdMax", ai_tc_id);
            return obj.intVal;
        }

        /// <summary>
        /// select top 1 address.adr_rd_no INTO @ls_tmp_rdno FROM address WHERE tc_id = @al_tcid AND post_code_id = @al_pcid;
        /// </summary>
        public static string GetAddressAdrRdNoFirst1(int al_tcid, int al_pcid)
        {
            RDSDataService obj = Execute("_GetAddressAdrRdNoFirst1", al_tcid, al_pcid);
            return obj.dataObject;
        }

        /// <summary>
        /// SELECT Count (*) INTO @lCustCount FROM  address 
        ///  WHERE contract_no = @lContractNo;
        /// </summary>
        public static int GetAddressCount(int lContractNo, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetAddressCount", lContractNo);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;

            return obj.intVal;
        }

        /// <summary>
        /// select rr_frozen_indicator into @sFrozenInd from renewal_rate where rg_code = @lRGCode and rr_rates_effective_date  =  ( select max(rr_rates_effective_date) from renewal_rate where rg_code = @lRGCode);
        /// </summary>
        public static string GetRenewalRateRrFrozenIndicator(int lRGCode)
        {
            RDSDataService obj = Execute("_GetRenewalRateRrFrozenIndicator", lRGCode);
            return obj.dataObject;
        }

        /// <summary>
        /// Select outlet_id, region_id Into @lOutletCode, @lRegionId From outlet Where o_name = @sOutlet;
        /// </summary>
        public static RDSDataService GetOutletInfo(string sOutlet)
        {
            RDSDataService obj = Execute("_GetOutletInfo", sOutlet);
            return obj;
        }

        /// <summary>
        /// Select outlet_id Into @lOutletCode From outlet Where o_name = @sOutlet;
        /// </summary>
        public static int GetOutletOutletId(string sOutlet, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetOutletOutletId", sOutlet);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;

            return obj.intVal;
        }

        /// <summary>
        /// select count (*) into @ll_count 
        ///   from contract, contract_renewals 
        ///  where contract.contract_no = @il_Contract_no and
        ///        contract.contract_no = contract_renewals.contract_no and 
        ///        (contract.con_active_sequence is null 
        ///          or contract.con_active_sequence = contract_renewals.contract_seq_number);
        /// </summary>
        public static int GetContractCount(int il_Contract_no)
        {
            RDSDataService obj = Execute("_GetContractCount", il_Contract_no);
            return obj.intVal;
        }

        ///<summary>
        /// DECLARE CreateTFC PROCEDURE FOR sp_CreateTFC  ;
        /// </summary>
        public static void ProcesureSpCreatetfc()
        {
            RDSDataService obj = Execute("_ProcesureSpCreatetfc");
        }

        ///<summary>
        /// delete from contract_renewals where contract_no=@lcontract and contract_seq_number=@lsequence;
        /// </summary>
        public static void DeleteContractRenewals(int? lcontract, int lsequence, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_DeleteContractRenewals", lcontract, lsequence);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
        }

        ///<summary>
        /// delete from t_custstat;
        /// </summary>
        public static void DeleteTCuststat(ref int SQLCode, ref string SQLErrText)
        {
            RDSDataService obj = Execute("_DeleteTCuststat");
            SQLCode = obj.SQLCode;
            SQLErrText = obj.SQLErrText;
        }

        ///<summary>
        /// delete from tmp_rand_cust_list;
        /// </summary>
        public static void DeleteTmpRandCustList(ref int SQLCode, ref string SQLErrText)
        {
            RDSDataService obj = Execute("_DeleteTmpRandCustList");
            SQLCode = obj.SQLCode;
            SQLErrText = obj.SQLErrText;
        }

        ///<summary>
        /// delete from report_temp;
        /// </summary>
        public static void DeleteReportTemp(ref int SQLCode, ref string SQLErrText)
        {
            RDSDataService obj = Execute("_DeleteReportTemp1");
            SQLCode = obj.SQLCode;
            SQLErrText = obj.SQLErrText;
        }

        ///<summary>
        /// delete from rds_temp
        /// </summary>
        public static void DeleteRdsTemp(ref int SQLCode, ref string SQLErrText)
        {
            RDSDataService obj = Execute("_DeleteRdsTemp");
            SQLCode = obj.SQLCode;
            SQLErrText = obj.SQLErrText;
        }

        /// <summary>
        /// select count (*) into @icount 
        ///   from contract_fixed_assets 
        ///  where fa_fixed_asset_no = @sFixedAssetno and 
        ///        contract_no <> @il_Contract_no;
        /// </summary>
        public static int GetContractFixedAssetsCount(string sFixedAssetno, int il_Contract_no)
        {
            RDSDataService obj = Execute("_GetContractFixedAssetsCount", sFixedAssetno, il_Contract_no);
            return obj.intVal;
        }

        /// <summary>
        /// select fat_id, fa_owner, fa_purchase_date, fa_purchase_price 
        ///   into @lFatId, @sOwner, @dFAPurchaseDate, @decFAPurchaseprice 
        ///   from fixed_asset_register 
        ///  where fa_fixed_asset_no = @sFixedAssetno;
        /// </summary>
        public static RDSDataService GetFixedAssetRegisterInfo(string sFixedAssetno, ref int SQLCode, ref string SQLErrText)
        {
            RDSDataService obj = Execute("_GetFixedAssetRegisterInfo", sFixedAssetno);
            SQLCode = obj.SQLCode;
            SQLErrText = obj.SQLErrText;
            return obj;
        }

        /// <summary>
        /// select top 1 a.adr_rd_no, p.post_code_id, t.tc_id 
        ///   into @ls_rdno, @ll_postcode_id, @ll_tc_id 
        ///   from address a, post_code p, towncity t 
        ///   where a.post_code_id = p.post_code_id and 
        ///         t.tc_name = p.post_mail_town and 
        ///         a.contract_no = @il_contract_no;
        /// </summary>
        public static RDSDataService GetAddressInfoFirst(int il_contract_no)
        {
            RDSDataService obj = Execute("_GetAddressInfoFirst", il_contract_no);
            return obj;
        }

        /// <summary>
        /// UPDATE contract SET con_last_delivery_check = @checkdate 
        ///  WHERE contract.contract_no = @ilcontract
        /// </summary>
        public static RDSDataService UpdateContract(DateTime? checkdate, int ilcontract)
        {
            RDSDataService obj = Execute("_UpdateContract", checkdate, ilcontract);
            return obj;
        }

        /// <summary>
        /// UPDATE contract SET con_last_work_msrmnt_check = @checkdate 
        ///  WHERE contract.contract_no = @ilcontract
        /// </summary>
        public static RDSDataService UpdateContract2(DateTime? checkdate, int ilcontract)
        {
            RDSDataService obj = Execute("_UpdateContract2", checkdate, ilcontract);
            return obj;
        }

        /// <summary>
        /// select count (*) into @icount from route_audit where ra_date_of_check = @dtCheck 	and contract_no = @ll_Contract 
        /// </summary>        
        public static int GetRouteAuditCount(DateTime? dtCheck, int? ll_Contract)
        {
            RDSDataService obj = Execute("_GetRouteAuditCount", dtCheck, ll_Contract);
            return obj.intVal;
        }

        /// <summary>
        /// SELECT contract.con_date_terminated INTO @dtermdate FROM contract 
        ///  WHERE contract.contract_no = @lContract 
        /// </summary>
        public static DateTime? GetConDateTerminatedFromContract(int? lContract, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetConDateTerminatedFromContract", lContract);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.dtVal;
        }

        /// <summary>
        /// SELECT contract_renewals.con_relief_driver_name, contract_renewals.con_relief_driver_address, contract_renewals.con_relief_driver_home_phone
        ///   INTO @sname, @saddr, @sphone
        ///   FROM contract_renewals
        ///  WHERE (contract_renewals.contract_no = @lcontract) AND (contract_renewals.contract_seq_number = @lsequence )
        /// </summary>
        public static RDSDataService GetContractRenewalsList(int? lcontract, int? lsequence, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetContractRenewalsList", lcontract, lsequence);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj;
        }

        /// <summary>
        /// insert into contract_renewals 
        ///            ( contract_no, contract_seq_number, con_relief_driver_name,con_relief_driver_address, con_relief_driver_home_phone)
        ///            values( @lContract, @lSequence, @sname,@saddr, @sphone);
        /// </summary>
        public static void InsertIntoContractRenewals(int? lcontract, int? lsequence, string sname, string saddr, string sphone, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_InsertIntoContractRenewals", lcontract, lsequence, sname, saddr, sphone);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
        }

        /// <summary>
        /// UPDATE contract_renewals set con_renewal_benchmark_price = BenchmarkCalc2005 ( contract_no, contract_seq_number)
        /// where contract_no = @lContract and contract_seq_number = @lSequence;
        /// </summary>
        public static void UpdateContractRenewals(int? lContract, int? lSequence, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_UpdateContractRenewals", lContract, lSequence);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
        }

        /// <summary>
        /// UPDATE contract_renewals 
        ///    SET con_renewal_payment_value = con_renewal_benchmark_price  
        ///  WHERE contract_renewals.contract_no = @lContract AND contract_renewals.contract_seq_number = @lSequence
        /// </summary>
        public static void UpdateContractRenewals2(int? lContract, int? lSequence, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_UpdateContractRenewals2", lContract, lSequence);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
        }

        /// <summary>
        /// select nvr_frozen_indicator into @sIndicator from non_vehicle_rate where rg_code = @lRenewal
        /// and nvr_rates_effective_date = (select max(nvr_rates_effective_date) from non_vehicle_rate where rg_code = @lRenewal)
        /// </summary>
        public static string GetNvrForzenIndicatorFormNonVehicle(int? lRenewal)
        {
            RDSDataService obj = Execute("_GetNvrForzenIndicatorFormNonVehicle", lRenewal);
            return obj.dataObject;
        }

        /// <summary>
        /// INSERT INTO vehicle
        ///             (  vehicle_number, vt_key, ft_key, v_vehicle_make, v_vehicle_model, v_vehicle_year,   
        ///            v_vehicle_registration_number, v_vehicle_cc_rating, v_road_user_charges_indicator,   
        ///            v_purchased_date, v_purchase_value, v_leased, v_vehicle_month, v_vehicle_transmission, 
        ///            vs_key, v_remaining_economic_life, v_vehicle_speedo_kms, v_vehicle_speedo_date, v_salvage_value)
        ///            VALUES  (  @lvehicleNumber, @lVTKey, @lFTKey, @sMake, @sModel, @lYear, @sRegistration,   
        ///            @lCCRate, @sUserCharge, @dPurchase, @lPurchase, @sLeased , @lMonth, @sTransmission, 
        ///            @ll_VSKey, @ll_remaining_economic_life, @lSpeedoKms, @dSpeedoDate, @ll_salvage )
        /// </summary>
        public static void InsertIntoVehicle(int? lvehicleNumber, int? lVTKey, int? lFTKey, string sMake, string sModel
                                            , int? lYear, string sRegistration, int? lCCRate, string sUserCharge
                                            , DateTime? dPurchase, int? lPurchase, string sLeased, int? lMonth
                                            , string sTransmission, int? ll_VSKey, int? ll_remaining_economic_life
                                            , int? lSpeedoKms, DateTime? dSpeedoDate, int? ll_salvage, int? lSafety
                                            , int? lEmissions, int? lConsumption
                                            , ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_InsertIntoVehicle", lvehicleNumber, lVTKey, lFTKey, sMake, sModel, lYear
                                            , sRegistration, lCCRate, sUserCharge, dPurchase, lPurchase, sLeased
                                            , lMonth, sTransmission, ll_VSKey, ll_remaining_economic_life, lSpeedoKms
                                            , dSpeedoDate, ll_salvage, lSafety, lEmissions, lConsumption);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
        }

        /// <summary>
        /// UPDATE vehicle SET vt_key = @lVTKey,   
        ///            ft_key = @lFTKey, v_vehicle_make = @sMake, v_vehicle_model = @sModel,   
        ///            v_vehicle_year = @lYear,   v_vehicle_month = @lmonth,   v_vehicle_registration_number = @sRegistration,   
        ///            v_vehicle_cc_rating = @lCCRate,  v_road_user_charges_indicator = @sUserCharge, v_purchased_date = @dPurchase,   
        ///            v_purchase_value = @lPurchase, v_leased = @sLeased, v_vehicle_transmission = @sTransmission,vs_key = @ll_VSKey,
        ///            v_remaining_economic_life = @ll_remaining_economic_life,v_vehicle_speedo_kms  = @lSpeedoKms ,
        ///            v_vehicle_speedo_date = @dSpeedoDate, v_salvage_value = @ll_salvage WHERE vehicle_number = @lVehicleNumber
        /// </summary>
        public static void UpdateVehicle(int? lVTKey, int? lFTKey, string sMake, string sModel, int? lYear, int? lMonth
                                            , string sRegistration, int? lCCRate, string sUserCharge, DateTime? dPurchase
                                            , int? lPurchase, string sLeased, string sTransmission, int? ll_VSKey
                                            , int? ll_remaining_economic_life, int? lSpeedoKms, DateTime? dSpeedoDate
                                            , int? ll_salvage, int? lSafety, int? lEmissions, int? lConsumption
                                            , int? lvehicleNumber, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_UpdateVehicle", lVTKey, lFTKey, sMake, sModel, lYear, lMonth, sRegistration
                                            , lCCRate, sUserCharge, dPurchase, lPurchase, sLeased, sTransmission, ll_VSKey
                                            , ll_remaining_economic_life, lSpeedoKms, dSpeedoDate, ll_salvage, lSafety
                                            , lEmissions, lConsumption, lvehicleNumber);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
        }

        /// <summary>
        /// select con_expiry_date into @dDate from contract_renewals where contract_no = @lContract and contract_seq_number = @lSequence
        /// </summary>
        public static DateTime? GetConExpiryDateFromContractRenewals(int? lContract, int? lSequence)
        {
            RDSDataService obj = Execute("_GetConExpiryDateFromContractRenewals", lContract, lSequence);
            return obj.dtVal;
        }

        /// <summary>
        /// select count (*) into @lCount from contractor_renewals where contract_no = @lContract and contract_seq_number = @lSequence
        /// </summary>
        public static int GetContractorRenewalsCount2(int? lContract, int? lSequence)
        {
            RDSDataService obj = Execute("_GetContractorRenewalsCount2", lContract, lSequence);
            return obj.intVal;
        }

        /// <summary>
        /// select f_GetLatestVehicle (@lContract, @lSequence) into @lCount from dummy
        /// </summary>
        public static int GetLatestVehicleFormDummy(int? lContract, int? lSequence)
        {
            RDSDataService obj = Execute("_GetLatestVehicleFormDummy", lContract, lSequence);
            return obj.intVal;
        }

        /// <summary>
        /// TJB  RD7_0051  Oct-2009: changed to
        /// select isnull(nvor_item_proc_rate_per_hour,nvr_item_proc_rate_per_hr)
        ///   into @lProcRate 
        ///   from non_vehicle_rate as nvr left outer join non_vehicle_override_rate as nvor 
        ///                on nvor.contract_no = @lContractNo and 
        ///                   nvor.contract_seq_number = @lSeqNo
        ///  where non_vehicle_rate.rg_code = @lRgCode
        ///    and non_vehicle_rate.nvr_rates_effective_date = @dDate
        /// </summary>
        // TJB  RD7_0051  Oct-2009
        // Added lContractNo, lSeqNo parameters
        public static int GetNvrItemProcRatePerHrFromNonVehicleRate(int? lContractNo, int? lSeqNo, int? lRgCode, DateTime? dDate)
        {
            RDSDataService obj = Execute("_GetNvrItemProcRatePerHrFromNonVehicleRate", lContractNo, lSeqNo, lRgCode, dDate);
            return obj.intVal;
        }

        /// <summary>
        ///select con_active_sequence into @il_current_seq   from contract   where contract_no = @il_contract
        /// </summary>
        public static int GetConActiveSequenceFromContract(int? il_contract)
        {
            RDSDataService obj = Execute("_GetConActiveSequenceFromContract", il_contract);
            return obj.intVal;
        }

        /// <summary>
        ///SELECT contractor.c_surname_company || ifnull ( contractor.c_first_names,'',', ' || contractor.c_first_names)  
        ///   INTO @sContractorName    FROM contractor    WHERE contractor.contractor_supplier_no = @lContractor
        /// </summary>
        public static string GetContractorNameFormContractor(int? lContractor)
        {
            RDSDataService obj = Execute("_GetContractorNameFormContractor", lContractor);
            return obj.dataObject;
        }

        /// <summary>
        ///SELECT contractor.contractor_supplier_no into @lContractor  FROM contractor  
        ///     WHERE contractor.c_surname_company || ifnull ( contractor.c_first_names,'',', ' || contractor.c_first_names) = @sContractorName
        /// </summary>
        public static int GetContractorSupplierNoFormContractor(string sContractorName)
        {
            RDSDataService obj = Execute("_GetContractorSupplierNoFormContractor", sContractorName);
            return obj.intVal;
        }

        /// <summary>
        ///Select count ( *)  Into @lCount From contractor Where contractor_supplier_no = @lSupplier
        /// </summary>
        public static int GetContractorCount2(int? lSupplier)
        {
            RDSDataService obj = Execute("_GetContractorCount2", lSupplier);
            return obj.intVal;
        }

        /// <summary>
        /// SELECT vehicle.vehicle_number, vehicle.vt_key,  vehicle.ft_key, vehicle.v_vehicle_make,  vehicle.v_vehicle_model,   
        ///            vehicle.v_vehicle_year,   vehicle.v_vehicle_cc_rating, vehicle.v_road_user_charges_indicator,   vehicle.v_purchased_date, vehicle.v_purchase_value,   
        ///            vehicle.v_leased, vehicle.v_vehicle_month FROM vehicle  WHERE vehicle.v_vehicle_registration_number = @sRegNo 
        /// </summary>
        public static RDSDataService GetVehicleList(string sRegNo, ref int sqlCode)
        {
            RDSDataService obj = Execute("_GetVehicleList", sRegNo);
            sqlCode = obj.SQLCode;
            return obj;
        }

        /// <summary>
        ///SELECT count ( *) INTO @li_rows FROM contract  WHERE contract_no = @il_contract AND con_active_sequence = @il_sequence
        /// </summary>
        public static int GetContractorCount3(int? il_contract, int? il_sequence, ref int SQLCode, ref string SQLErrText)
        {
            RDSDataService obj = Execute("_GetContractorCount3", il_contract, il_sequence);
            SQLCode = obj.SQLCode;
            SQLErrText = obj.SQLErrText;
            return obj.intVal;
        }

        /// <summary>
        ///select benchmarkCalcVeh2005 ( @il_contract, @il_sequence, @li_newVehNo)  into @ldc_newBenchmark   from dummy
        /// </summary>
        public static int GetBenchMarkCalcVeh2005(int? il_contract, int? il_sequence, int? li_newVehNo, ref int SQLCode, ref string SQLErrText)
        {
            RDSDataService obj = Execute("_GetBenchMarkCalcVeh2005", il_contract, il_sequence, li_newVehNo);
            SQLCode = obj.SQLCode;
            SQLErrText = obj.SQLErrText;
            return obj.intVal;
        }

        /// <summary>
        /// SELECT rgn_name  INTO @ls_Temp  FROM region  WHERE region_id = @ll_regionId;
        /// </summary>
        public static string GetRegionValue(int? ll_regionId, ref int SQLCode)
        {
            RDSDataService obj = Execute("_GetRegionValue", ll_regionId);
            SQLCode = obj.SQLCode;
            return obj.strVal;
        }

        /// <summary>
        /// SELECT rgn_name  INTO @ls_Temp  FROM region  WHERE region_id = @ll_regionId;
        /// </summary>
        public static string GetRegionValue(int? ll_regionId, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetRegionValue", ll_regionId);
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
            return obj.strVal;
        }

        /// <summary>
        /// select count ( *) into   @ll_Count from   tmp_rand_cust_list
        /// </summary>
        public static int GetTmpRandCustList()
        {
            RDSDataService obj = Execute("_GetTmpRandCustList");
            return obj.intVal;
        }

        /// <summary>
        /// SELECT outlet.o_name  INTO @sTemp  FROM outlet  WHERE outlet.outlet_id = @lOutlet;
        /// </summary>
        public static string GetOutletValue(int? lOutlet)
        {
            RDSDataService obj = Execute("_GetOutletValue", lOutlet);
            return obj.strVal;
        }

        /// <summary>
        /// SELECT renewal_group.rg_description  INTO @sTemp  FROM renewal_group  WHERE renewal_group.rg_code = @lRenGroup   ;
        /// </summary>
        public static string GetRenewalGroupValue(int? lRenGroup, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetRenewalGroupValue", lRenGroup);
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
            return obj.strVal;
        }

        /// <summary>
        ///SELECT	contract.con_title INTO @sTemp  FROM contract  WHERE contract.contract_no = @lContract   ;
        /// </summary>
        public static string GetContractValue(int? lContract, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetContractValue", lContract);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.strVal;
        }

        /// <summary>
        /// DELETE FROM rd.report_temp WHERE report_temp.customer_id = @ll_custid
        /// </summary>
        public static string DeleteReportTemp(int? ll_custid, ref int SQLCode, ref string SQLErrText)
        {
            RDSDataService obj = Execute("_DeleteReportTemp", ll_custid);
            SQLCode = obj.SQLCode;
            SQLErrText = obj.SQLErrText;
            return obj.strVal;
        }

        /// <summary>
        /// SELECT contract_type.contract_type  INTO @sTemp  FROM contract_type  WHERE contract_type.ct_key = @lContractType   ;
        /// </summary>
        public static string GetContractTypeValue(int? lContractType)
        {
            RDSDataService obj = Execute("_GetContractTypeValue", lContractType);
            return obj.strVal;
        }

        /// <summary>
        /// select outlet_id into @lOutletId from outlet where o_name = @sOutlet;
        /// </summary>
        public static int GetOutletValue2(string sOutlet, ref int sqlCode)
        {
            RDSDataService obj = Execute("_GetOutletValue2", sOutlet);
            sqlCode = obj.SQLCode;
            return obj.intVal;
        }

        /// <summary>
        /// SELECT count(*) INTO @ll_con_count FROM Contract WHERE Contract.contract_no = @ll_contract_num ;
        /// </summary>
        public static int GetContractCount(int? ll_contract_num)
        {
            RDSDataService obj = Execute("_GetContractCount2", ll_contract_num);
            return obj.intVal;
        }

        /// <summary>
        /// SELECT count(*) INTO @ll_con_count FROM Contract WHERE Contract.contract_no = @ll_contract_num ;
        /// </summary>
        public static int GetContractCount(int? ll_contract_num, ref int SQLCode)
        {
            RDSDataService obj = Execute("_GetContractCount2", ll_contract_num);
            SQLCode = obj._sqlcode;
            return obj.intVal;
        }

        /// <summary>
        /// SELECT tc_id INTO @ll_tc_num FROM TownCity WHERE TownCity.tc_name = @ls_tc_name  ;
        /// </summary>
        public static int GetTownCityValue(string ls_tc_name, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetTownCityValue", ls_tc_name);
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
            return obj.intVal;
        }

        /// <summary>
        /// SELECT min ( TownCity.tc_id) INTO @ll_tc_num FROM TownCity WHERE TownCity.tc_name = @ls_tc_name
        /// </summary>
        public static int GetTownCityValue2(string ls_tc_name, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetTownCityValue2", ls_tc_name);
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
            return obj.intVal;
        }

        /// <summary>
        /// select ru.region_id into @il_region  from rds_user ru, rds_user_id rui where rui.ui_userid = @ls_userid  and ru.u_id = rui.u_id
        /// </summary>
        public static int GetRegionId(string ls_userid, ref int sqlCode)
        {
            RDSDataService obj = Execute("_GetRegionId", ls_userid);
            sqlCode = obj.SQLCode;
            return obj.intVal;
        }

        /// <summary>
        /// select top 1 region_id into @li_rights_region from rds_user_rights rur, 
        ///        rds_user_id_group rui, rds_component rc,  rds_user_id rid where rc.rc_name = 'Private Bags' and rid.ui_userid = @ls_userid
        ///        and rui.ui_id = rid.ui_id and rur.ug_id = rui.ug_id and rc.rc_id = rur.rc_id and rur.rur_read = 'Y'  and rur.ug_id = rui.ug_id
        /// </summary>
        public static int GetFirstRegionId(string ls_userid, ref int sqlCode)
        {
            RDSDataService obj = Execute("_GetFirstRegionId", ls_userid);
            sqlCode = obj.SQLCode;
            return obj.intVal;
        }

        /// <summary>
        /// insert into rd.private_bags ( pvt_frequency, pvt_bag_count, region_id) values  ( 1, @ll_1, @il_region)
        /// </summary>
        public static void InsertIntoPRivateBages(int num, int? ll_1, int? il_region, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_InsertIntoPRivateBages", num, ll_1, il_region);
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
        }

        /// <summary>
        ///select top 1 pvt_bag_count into @li_1 from private_bags where pvt_frequency = 1 and region_id = @il_region order by pvt_date desc
        /// </summary>
        public static int GetTop1PvtBagCount(int num, int? il_region, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetTop1PvtBagCount", num, il_region);
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
            return obj.intVal;
        }

        /// <summary>
        ///SELECT count ( odps.post_tax_deductions_applied.pcd_id  ) INTO 	@lct  FROM 	odps.post_tax_deductions_applied WHERE odps.post_tax_deductions_applied.ded_id = @lded 
        /// </summary>
        public static int GetPostTaxDeductionsAppliedCount(int? lded)
        {
            RDSDataService obj = Execute("_GetPostTaxDeductionsAppliedCount", lded);
            return obj.intVal;
        }

        /// <summary>
        ///select contract_no into @lContract from contract where con_old_mail_service_no = @sMSNumber
        /// </summary>
        public static int GetContractNo(string sMSNumber)
        {
            RDSDataService obj = Execute("_GetContractNo", sMSNumber);
            return obj.intVal;
        }

        /// <summary>
        ///select prt_key into @lPRKey from piece_rate_type where prt_code = @sPRCode
        /// </summary>
        public static int GetPrtKey(string sPRCode, ref int SQLCode)
        {
            RDSDataService obj = Execute("_GetPrtKey", sPRCode);
            SQLCode = obj._sqlcode;
            return obj.intVal;
        }

        /// <summary>
        ///select count(prt_key) into @lCount from piece_rate_delivery where contract_no = @lContract and prt_key     = @lPRKey  and prd_date    = @dPRDDate
        /// </summary>
        public static int GetPieceRateDeliveryCount(int? lContract, int? lPRKey, DateTime? dPRDDate)
        {
            RDSDataService obj = Execute("_GetPieceRateDeliveryCount", lContract, lPRKey, dPRDDate);

            return obj.intVal;
        }

        /// <summary>
        ///select max(contract_seq_number) into @li_seq_num from contract_renewals  where contract_no = @li_contract_no
        /// </summary>
        public static int GetMaxContractSeqNumber(int? li_contract_no)
        {
            RDSDataService obj = Execute("_GetMaxContractSeqNumber", li_contract_no);

            return obj.intVal;
        }

        /// <summary>
        /// SELECT min(date(move_in_date)) INTO @ld_move_in_early FROM customer_address_moves WHERE move_out_date is null
        /// </summary>
        public static DateTime? GetCustomerAddressMovesMoveInDateMin(ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetCustomerAddressMovesMoveInDateMin1");
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
            return obj.dtVal;
        }

        /// <summary>
        /// SELECT mail_count_date.mail_count_date INTO @mcdate FROM mail_count_date;
        /// </summary>
        public static DateTime? GetMailCountDateMailCountDate()
        {
            RDSDataService obj = Execute("_GetMailCountDateMailCountDate");
            return obj.dtVal;
        }

        /// <summary>
        ///SELECT min(nvr.rg_code) INTO @rg_code FROM non_vehicle_rate nvr WHERE nvr.nvr_contract_end = ( SELECT min (  nvr2.nvr_contract_end ) FROM non_vehicle_rate nvr2 WHERE nvr2.nvr_contract_end >= @mcdate);
        /// </summary>
        public static int GetNonVehicleRateRgCodeMin(DateTime? mcdate, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetNonVehicleRateRgCodeMin", mcdate);
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
            return obj.intVal;
        }

        /// <summary>
        ///SELECT min(nvr.rg_code) INTO @rgcode2 FROM non_vehicle_rate nvr WHERE nvr.rg_code <> @rg_code and  nvr.nvr_contract_end =  ( SELECT min ( nvr2.nvr_contract_end ) FROM non_vehicle_rate nvr2 WHERE nvr2.nvr_contract_end > @mcdate and nvr2.nvr_contract_end >  ( select min ( nvr3.nvr_contract_end) from 	non_vehicle_rate nvr3 where nvr3.nvr_contract_end >= @mcdate));
        /// </summary>
        public static int GetNonVehicleRateRgCodeMin1(int? rg_code, DateTime? mcdate, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetNonVehicleRateRgCodeMin1", rg_code, mcdate);
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
            return obj.intVal;
        }

        /// <summary>
        ///SELECT count(mail_count_date.mail_count_date) INTO @lcount FROM mail_count_date;
        /// </summary>
        public static int GetMailCountDateMailCountDateCount()
        {
            RDSDataService obj = Execute("_GetMailCountDateMailCountDateCount");

            return obj.intVal;
        }

        /// <summary>
        /// INSERT INTO mail_count_date (mail_count_date) VALUES (@mcdate);
        /// </summary>
        public static void InsertMailCountDate(DateTime? mcdate)
        {
            RDSDataService obj = Execute("_InsertMailCountDate", mcdate);
        }

        /// <summary>
        /// UPDATE mail_count_date SET mail_count_date = @mcdate  ;
        /// </summary>
        public static void UpdateMailCountDateMailCountDate(DateTime? mcdate)
        {
            RDSDataService obj = Execute("_UpdateMailCountDateMailCountDate", mcdate);
        }

        /// <summary>
        /// select con_start_date, con_expiry_date into @ld_start, @ld_end from contract_renewals  where contract_seq_number = @li_seq_num  and contract_no = @li_contract_no
        /// </summary>
        public static RDSDataService GetContractRenewalsDate(int? li_seq_num, int? li_contract_no)
        {
            RDSDataService obj = Execute("_GetContractRenewalsDate1", li_seq_num, li_contract_no);
            return obj;
        }

        /// <summary>
        /// select con_rates_effective_date into @ld_con_rates_effective_date  from contract_renewals where contract_no = @li_contract_no and contract_seq_number = @li_seq_num
        /// </summary>
        public static DateTime? GetConRatesEffDate(int? li_contract_no, int? li_seq_num)
        {
            RDSDataService obj = Execute("_GetConRatesEffDate", li_contract_no, li_seq_num);
            return obj.dtVal;
        }

        /// <summary>
        /// select pr_rate into @ldec_pr_rate from piece_rate where prt_key = @li_prt_key and pr_effective_date = @ld_con_rates_effective_date
        /// </summary>
        public static Decimal? GetPrRateFromPieceRate(int? li_prt_key, DateTime? ld_con_rates_effective_date)
        {
            RDSDataService obj = Execute("_GetPrRateFromPieceRate", li_prt_key, ld_con_rates_effective_date);
            return obj.decVal;
        }

        /// <summary>
        /// UPDATE vehicle_override_rate vor1  
        ///    SET vor1.vor_fuel_rate = @ldc_new_override_fuel_rate 
        ///  WHERE vor1.contract_no = @ll_contract_no
        ///    AND vor1.contract_seq_number = @ll_sequence_no 
        ///    AND vor1.vor_effective_date >= @ld_rates_effective_date
        ///    AND vor1.vor_effective_date 
        ///             = (SELECT max(vor2.vor_effective_date)
        ///                  FROM vehicle_override_rate vor2 
        ///                 WHERE vor2.contract_no = vor1.contract_no 
        ///                   AND vor2.contract_seq_number = vor1.contract_seq_number)
        /// </summary>
        public static void UpdateVehicleOverrideRate(
            decimal? ldc_new_override_fuel_rate,
            int? ll_contract_no,
            int? ll_sequence_no,
            DateTime? ld_rates_effective_date,
            ref int sqlCode,
            ref string sqlErrText)
        {
            RDSDataService obj = Execute("_UpdateVehicleOverrideRate", ldc_new_override_fuel_rate, ll_contract_no, ll_sequence_no, ld_rates_effective_date);
            sqlCode = obj._sqlcode;
            sqlErrText = obj._sqlerrtext;
        }

        /// <summary>
        /// select contract_renewals.contract_seq_number 
        ///   into @lRenewal 
        ///   from contract key join contract_renewals 
        ///  where contract.contract_no = @lContract
        ///    and (contract_renewals.contract_seq_number = (contract.con_active_sequence + 1)
        ///          or (contract.con_active_sequence is null 
        ///               and contract_renewals.contract_seq_number = 1))
        /// </summary>
        public static int GetContractSeqNumber(int? lContract, ref int SQLCode)
        {
            RDSDataService obj = Execute("_GetContractSeqNumber", lContract);
            SQLCode = obj.SQLCode;
            return obj.intVal;
        }

        /// <summary>
        /// 
        /// SELECT count(artical_count.contract_no ) 
        ///   INTO @lCount  
        ///   FROM artical_count  
        ///  WHERE (artical_count.contract_no = @lContract) 
        ///    AND (artical_count.contract_seq_number = @ilRenewal )  
        /// </summary>
        public static int GetArticalCountCount2(int? lContract, int ilRenewal)
        {
            RDSDataService obj = Execute("_GetArticalCountCount2", lContract, ilRenewal);
            return obj.intVal;
        }

        /// <summary>
        /// SELECT route_freq_point_type.rfpt_description  INTO @s_rfpt_desc  FROM route_freq_point_type  WHERE route_freq_point_type.rfpt_id = @ai_rfpt_id 
        /// </summary>
        public static string GetRfptDescription(int? ai_rfpt_id)
        {
            RDSDataService obj = Execute("_GetRfptDescription", ai_rfpt_id);
            return obj.dataObject;
        }

        /// <summary>
        /// SELECT 	count ( *)  INTO	@ll_Count FROM	frequency_distances
        ///        WHERE	contract_no 		= 	@il_Contract_no AND	sf_key	= 	@il_SF_Key AND rf_delivery_days	= @is_Delivery_Days AND	fd_effective_date = 	@ad_Effective_Date
        /// </summary>
        public static int GetFrequencyDistancesCount(int? il_Contract_no, int il_SF_Key, string is_Delivery_Days, DateTime? ad_Effective_Date, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetFrequencyDistancesCount", il_Contract_no, il_SF_Key, is_Delivery_Days, ad_Effective_Date);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.intVal;
        }

        /// <summary>
        /// INSERT INTO frequency_distances ( fd_effective_date, contract_no, sf_key,  rf_delivery_days, fd_change_reason) VALUES ( @id_Effective_Date ,@il_Contract_no,@il_sf_key, @is_Delivery_Days, @is_Reason)
        /// </summary>
        public static void InsertIntoFrequencyDistances(DateTime? id_Effective_Date, int? il_Contract_no, int il_sf_key, string is_Delivery_Days, string is_Reason, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_InsertIntoFrequencyDistances", id_Effective_Date, il_Contract_no, il_sf_key, is_Delivery_Days, is_Reason);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;

        }

        /// <summary>
        ///  insert into NPAD_msg_log(msg_date,msg_username,msg_type,msg_dpid,msg_status,msg_description) 
        /// values(@now,@username,'transfer customer',@s_old_dpid,@status,@errmsg);
        /// </summary>
        public static void InsertIntoNPADMsgLog(DateTime? nowDate, string username, string msg_type, int? msg_dpid,
                                                    int msg_status, string errmsg )  //! , ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_InsertIntoNPADMsgLog", nowDate, username, msg_type, msg_dpid, msg_status, errmsg);
            //!sqlCode = obj.SQLCode;
            //!sqlErrText = obj.SQLErrText;

        }

        /// <summary>
        /// INSERT INTO frequency_adjustments ( contract_no,contract_seq_number,  fd_unique_seq_number, fd_adjustment_amount, fd_paid_to_date, fd_bm_after_extn,fd_confirmed, fd_amount_to_pay, fd_effective_date, sf_key,  rf_delivery_days) 
        ///            VALUES   ( @il_Contract_no,  @il_Sequence_no,  @lNextSeq,   @idc_adjustment_amount,  null,   @idc_new_benchmark, @is_confirmed, @idc_amount_to_pay, @id_Effective_Date, @il_sf_key, @is_Delivery_Days)
        /// </summary>
        public static void InsertIntoFrequencyAdjustments(int? il_Contract_no, int? il_Sequence_no, int lNextSeq, decimal? idc_adjustment_amount, decimal? idc_new_benchmark, string is_confirmed, decimal? idc_amount_to_pay, DateTime? id_Effective_Date, int il_sf_key, string is_Delivery_Days, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_InsertIntoFrequencyAdjustments", il_Contract_no, il_Sequence_no, lNextSeq, idc_adjustment_amount, idc_new_benchmark, is_confirmed, idc_amount_to_pay, id_Effective_Date, il_sf_key, is_Delivery_Days);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
        }

        /// <summary>
        /// SELECT max ( fd_unique_seq_number) INTO @lNextSeq  FROM frequency_adjustments WHERE contract_no = @il_Contract_no AND contract_seq_number = @il_Sequence_no
        /// </summary>
        public static int GetMaxFdUniqueSeqNumber(int? il_Contract_no, int? il_Sequence_no, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetMaxFdUniqueSeqNumber", il_Contract_no, il_Sequence_no);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.intVal;
        }

        /// <summary>
        ///  select count ( *)into @iCount from contract where contract_no = @lContract
        /// </summary>
        public static int GetContractICount(int? lContract, ref int SQLCode, ref string SQLErrText)
        {
            RDSDataService obj = Execute("_GetContractICount", lContract);
            SQLCode = obj.SQLCode;
            SQLErrText = obj.SQLErrText;
            return obj.intVal;
        }

        /// <summary>
        /// SELECT piece_rate.pr_rate, piece_rate.pr_effective_date
        ///    INTO @decRate, @dPrEffDate 
        ///    FROM contract key join contract_renewals,
        ///    contract_renewals join piece_rate
        ///    on  contract_renewals.con_rg_code_at_renewal   = piece_rate.rg_code
        ///    and contract_renewals.con_rates_effective_date = piece_rate.pr_effective_date
        ///    and piece_rate.prt_key = @lPRKey
        ///    WHERE contract.contract_no = @lContract 
        ///    AND contract_renewals.contract_seq_number = 
        ///     ( SELECT max ( contract_seq_number) 
        ///    FROM contract_renewals 
        ///    WHERE contract_renewals.con_start_date <= @dPRDDate 
        ///    and contract_renewals.contract_no = contract.contract_no)
        /// </summary>
        public static RDSDataService GetContractList(int? lPRKey, int? lContract, DateTime? dPRDDate, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetContractList", lPRKey, lContract, dPRDDate);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj;
        }

        /// <summary>
        /// select next_value into @nNextValue from id_codes where sequence_name = @sequencename ;
        /// </summary>
        public static int GetIdCodesNextValue(string sequencename, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetIdCodesNextValue", sequencename);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.intVal;
        }

        /// <summary>
        /// insert into id_codes ( sequence_name, next_value) values  ( @sequencename, 2) ;
        /// </summary>
        public static void InsertIdCodes(string sequencename)
        {
            RDSDataService obj = Execute("_InsertIdCodes", sequencename);

        }

        /// <summary>
        /// UPDATE id_codes set next_value = @nNextValue + 1 where sequence_name = @sequencename ;
        /// </summary>
        public static void UpdateIdCodes(int nNextValue, string sequencename)
        {
            RDSDataService obj = Execute("_UpdateIdCodes", nNextValue, sequencename);

        }

        /// <summary>
        /// UPDATE	vehicle_rate vr1 SET	vr1.vr_ruc = @ldc_new_standard_ruc_rate WHERE vr1.vr_rates_effective_date = @ld_rates_effective_date
        /// </summary>
        public static void UpdateVehicleRate(decimal? ldc_new_standard_ruc_rate, DateTime? ld_rates_effective_date, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_UpdateVehicleRate", ldc_new_standard_ruc_rate, ld_rates_effective_date);

        }

        /// <summary>
        ///EXECUTE IMMEDIATE @ls_select;
        /// </summary>
        public static void ExecuteSqlString(string ls_select, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_ExecuteSqlString", ls_select);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
        }

        /// <summary>
        /* DECLARE my_cursor DYNAMIC CURSOR FOR SQLSA ;
             PREPARE SQLSA FROM :sSQLSelect;
             OPEN my_cursor
             FETCH my_cursor INTO :lCount ;
             CLOSE my_cursor*/
        /// </summary>
        public static int? ExecuteSqlStringLcount(string sSQLSelect, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_ExecuteSqlStringLcount", sSQLSelect);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.intVal;
        }

        /// <summary>
        /* DECLARE Recip_cursor DYNAMIC CURSOR FOR SQLSA ;
                 PREPARE SQLSA FROM :sSQLSelectRecipients;
                 OPEN Recip_cursor
                 FETCH Recip_cursor INTO :lRecipientCount ;
                 CLOSE Recip_cursor*/
        /// </summary>
        public static int? ExecuteSqlStringlRecipientCount(string sSQLSelectRecipients, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_ExecuteSqlStringlRecipientCount", sSQLSelectRecipients);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.intVal;
        }

        /// <summary>
        /* DECLARE Recip_cursor DYNAMIC CURSOR FOR SQLSA ;
                 PREPARE SQLSA FROM :sSQLSelectRecipients;
                 OPEN Recip_cursor
                 FETCH Recip_cursor INTO :lRecipientCount ;
                 CLOSE Recip_cursor*/
        /// </summary>
        public static int? ExecuteSqlRecipients(string sSQLSelectRecipients, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_ExecuteSqlRecipients", sSQLSelectRecipients);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.intVal;
        }

        /// <summary>
        ///UPDATE rds_customer SET printedon = today(*) WHERE customer.cust_id = @lcust
        /// </summary>
        public static void UpdateCustId(int? lcust, ref int SQLCode)
        {
            RDSDataService obj = Execute("_UpdateCustId", lcust);
        }

        public static RDSDataService DeleteAdressByAdrId(int? al_adrID)
        {
            RDSDataService obj = Execute("_DeleteAdressByAdrId", al_adrID);
            return obj;
        }

        public static string FFreqInuse(int? contract_no, int? sf_key, string rf_delivery_days)
        {
            return Execute("_FFreqInuse", contract_no, sf_key, rf_delivery_days).strVal;
        }

        // TJB  RD7_0039  Sept2007:  added
        public static void CleanupFDRows(int? sf_key, int? contract_no, int? rd_sequence, string rf_delivery_days)
        {
            Execute("_CleanupFDRows", sf_key, contract_no, rd_sequence, rf_delivery_days);
        }

        // TJB  June-2010  ECL Data Upload -----------------------------------------------
        public static bool InsertIntoECLUploadHistory(int lBatchNo, DateTime dtDateUploaded
                                                     , int lRecordsUploaded, int lUploadErrors
                                                     , string sUploadFilename
                                                     , ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_InsertIntoECLUploadHistory", lBatchNo, dtDateUploaded, lRecordsUploaded, lUploadErrors, sUploadFilename);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.ret;
        }

        public static int GetECLUploadHistoryCurrentBatchNo(ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetECLUploadHistoryCurrentBatchNo");
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.intVal;
        }

        public static int GetECLUploadHistoryNextBatchNo( ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetECLUploadHistoryNextBatchNo");
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.intVal;
        }

        public static RDSDataService GetECLUploadHistoryOldBatchNos(DateTime inDate, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetECLUploadHistoryOldBatchNos", inDate);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj;
        }

        public static bool UpdateECLUploadHistoryUpload(int lBatchNo, DateTime dtDateUploaded, int lRecordsUploaded, int lUploadErrors
                                                      , ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_UpdateECLUploadHistoryUpload", lBatchNo, dtDateUploaded, lRecordsUploaded, lUploadErrors);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.ret;
        }

        public static bool UpdateECLUploadHistoryInsert(int lBatchNo, DateTime dtDateInserted, int lRecordsInserted, int lInsertErrors
                                                      , ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_UpdateECLUploadHistoryInsert", lBatchNo, dtDateInserted, lRecordsInserted, lInsertErrors);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.ret;
        }

        public static bool IsDuplicateECLUploadData(string sTicketNo, string sTicketPart
                                                      , ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_IsDuplicateECLUploadData", sTicketNo, sTicketPart);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.ret;
        }

        public static int GetECLUploadedBatchSize(int lBatchNo, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetECLUploadedBatchSize", lBatchNo);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.intVal;
        }

        public static int sp_ECLPurgeBatch(int lBatchNo, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_sp_ECLPurgeBatch", lBatchNo);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.intVal;
        }

        public static int sp_ECLInsertData(int lBatchNo, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_sp_ECLInsertData", lBatchNo);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj.intVal;
        }

        /// <summary>
        /// SELECT * from ecl_quality_mappings
        /// </summary>
        public static RDSDataService GetEclQualityMappings(ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_GetEclQualityMappings");
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj;
        }

        /// <summary>
        /// insert into ecl_upload_data (...) Values (...)
        /// </summary>
        public static RDSDataService InsertIntoECLUploadData(EclImportData item, ref int sqlCode, ref string sqlErrText)
        {
            RDSDataService obj = Execute("_InsertIntoECLUploadData", item);
            sqlCode = obj.SQLCode;
            sqlErrText = obj.SQLErrText;
            return obj;
        }
        // TJB  June-2010  ECL Data Upload --------------------- End ---------------------

        #endregion

        #region Server-side Code
        [ServerMethod]
        private void _GetTownSuburSlIdBySlName(int? al_tcid, string as_slname)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT sl.sl_id FROM rd.town_suburb join rd.suburblocality sl on town_suburb.sl_id=sl.sl_id " +
                        "WHERE sl_name = @as_slname AND tc_id = @al_tcid  " +
                        "ORDER BY sl_name";
                    pList.Add(cm, "al_tcid", al_tcid);
                    pList.Add(cm, "as_slname", as_slname);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _LoadContractAdjustments()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = cm.CommandText = "rd.loadContractAdjustments";
                    ParameterCollection pList = new ParameterCollection();

                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateVehicleRate(decimal? ldc_new_standard_ruc_rate, DateTime? ld_rates_effective_date)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "UPDATE rd.vehicle_rate  SET vr_ruc = @ldc_new_standard_ruc_rate " +
                        "WHERE vr_rates_effective_date = @ld_rates_effective_date";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ldc_new_standard_ruc_rate", ldc_new_standard_ruc_rate);
                    pList.Add(cm, "ld_rates_effective_date", ld_rates_effective_date);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateCustId(int? lcust)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "UPDATE rd.rds_customer SET printedon = getdate() WHERE customer.cust_id = @lcust";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lcust", lcust);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractList(int? lPRKey, int? lContract, DateTime? dPRDDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
               
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT piece_rate.pr_rate, piece_rate.pr_effective_date" +
                                    "    FROM rd.contract join rd.contract_renewals " +
                                                              " on (contract.contract_no = contract_renewals.contract_no)" + 
                                                        " join rd.piece_rate" +
                                                              " on  contract_renewals.con_rg_code_at_renewal = piece_rate.rg_code" +
                                                              " and contract_renewals.con_rates_effective_date = piece_rate.pr_effective_date" +
                                                              " and piece_rate.prt_key = @lPRKey" +
                                    "    WHERE contract.contract_no = @lContract " +
                                    "    AND contract_renewals.contract_seq_number = " +
                                                     " (SELECT max(contract_seq_number) " +
                                                        " FROM contract_renewals " +
                                                       " WHERE contract_renewals.con_start_date <= @dPRDDate " +
                                                         " and contract_renewals.contract_no = contract.contract_no) ";

                    pList.Add(cm, "lPRKey", lPRKey);
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "dPRDDate", dPRDDate);

                    _contractItemList = new List<ContractItem>();
                    try
                    {
                        _sqlcode = 100;
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                ContractItem rf = new ContractItem();
                                _contractItemList.Add(rf);
                                if (dr[0] == null)
                                {
                                    rf.pr_rate = null;
                                }
                                else
                                {
                                    rf.pr_rate = dr.GetDecimal(0);
                                }
                                if (dr[1] == null)
                                {
                                    rf.pr_effective_date = null;
                                }
                                else
                                {
                                    rf.pr_effective_date = dr.GetDateTime(1);
                                }
                                _sqlcode = 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _InsertIntoFrequencyAdjustments(int? il_Contract_no, int? il_Sequence_no, int lNextSeq, decimal? idc_adjustment_amount, decimal? idc_new_benchmark, string is_confirmed, decimal? idc_amount_to_pay, DateTime? id_Effective_Date, int il_sf_key, string is_Delivery_Days)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = "INSERT INTO rd.frequency_adjustments ( " +
                           "contract_no,contract_seq_number,  " +
                           "fd_unique_seq_number, " +
                           "fd_adjustment_amount, " +
                           "fd_paid_to_date, " +
                           "fd_bm_after_extn," +
                           "fd_confirmed, " +
                           "fd_amount_to_pay, " +
                           "fd_effective_date, " +
                           "sf_key,  " +
                           "rf_delivery_days) " +
                        "VALUES (@il_Contract_no, " +
                           "@il_Sequence_no, " +
                           "@lNextSeq, " +
                           "@idc_adjustment_amount, " +
                           "null, " +
                           "@idc_new_benchmark, " +
                           "@is_confirmed, " +
                           "@idc_amount_to_pay," +
                           "@id_Effective_Date, " +
                           "@il_sf_key, " +
                           "@is_Delivery_Days)";
                    pList.Add(cm, "il_Contract_no", il_Contract_no);
                    pList.Add(cm, "il_Sequence_no", il_Sequence_no);
                    pList.Add(cm, "lNextSeq", lNextSeq);
                    pList.Add(cm, "idc_adjustment_amount", idc_adjustment_amount);
                    pList.Add(cm, "idc_new_benchmark", idc_new_benchmark);
                    pList.Add(cm, "is_confirmed", is_confirmed);
                    pList.Add(cm, "idc_amount_to_pay", idc_amount_to_pay);
                    pList.Add(cm, "id_Effective_Date", id_Effective_Date);
                    pList.Add(cm, "il_sf_key", il_sf_key);
                    pList.Add(cm, "is_Delivery_Days", is_Delivery_Days);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }

                }
            }
        }

        [ServerMethod]
        private void _GetMaxFdUniqueSeqNumber(int? il_Contract_no, int il_Sequence_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    int sequence = 0;
                    cm.CommandText = "SELECT max(fd_unique_seq_number) " + 
                                       "FROM rd.frequency_adjustments " +
                                      "WHERE contract_no = @il_Contract_no " +
                                        "AND contract_seq_number = @il_Sequence_no";
                    pList.Add(cm, "il_Contract_no", il_Contract_no);
                    pList.Add(cm, "il_Sequence_no", il_Sequence_no);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractICount(int? lContract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    int sequence = 0;
                    cm.CommandText = "SELECT count(*) from rd.contract where contract_no = @lContract";
                    pList.Add(cm, "lContract", lContract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _InsertIntoFrequencyDistances(DateTime? id_Effective_Date, int? il_Contract_no, int il_sf_key, string is_Delivery_Days, string is_Reason)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = "INSERT INTO rd.frequency_distances ( " +
                            "fd_effective_date, " +
                            "contract_no, " +
                            "sf_key,  " +
                            "rf_delivery_days, " +
                            "fd_change_reason) " +
                        "VALUES ( " +
                            "@id_Effective_Date ," +
                            "@il_Contract_no, " +
                            "@il_sf_key, " +
                            "@is_Delivery_Days, " +
                            "@is_Reason)";
                    pList.Add(cm, "id_Effective_Date", id_Effective_Date);
                    pList.Add(cm, "il_Contract_no", il_Contract_no);
                    pList.Add(cm, "il_sf_key", il_sf_key);
                    pList.Add(cm, "is_Delivery_Days", is_Delivery_Days);
                    pList.Add(cm, "is_Reason", is_Reason);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }

                }
            }
        }

        [ServerMethod]
        private void _InsertIntoNPADMsgLog(DateTime? nowDate, string username, string msg_type, int? msg_dpid,
                                                    int msg_status, string errmsg)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = " insert into rd.NPAD_msg_log(msg_date, " + 
                            " msg_username,msg_type,msg_dpid,msg_status,msg_description) " + 
                        "values(@now,@username,'transfer customer',@s_old_dpid,@status,@errmsg)";
                    pList.Add(cm, "now", nowDate);
                    pList.Add(cm, "username", username);
                    pList.Add(cm, "username", msg_type); 
                    pList.Add(cm, "s_old_dpid", msg_dpid);
                    pList.Add(cm, "status", msg_status);
                    pList.Add(cm, "errmsg", errmsg);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }

                }
            }
        }

        [ServerMethod]
        private void _GetFrequencyDistancesCount(int? il_Contract_no, int il_SF_Key, string is_Delivery_Days, DateTime? ad_Effective_Date)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    int sequence = 0;
                    cm.CommandText = "SELECT count(*) FROM rd.frequency_distances " +
                        "WHERE contract_no = @il_Contract_no AND " +
                        "sf_key = @il_SF_Key AND " +
                        "rf_delivery_days = @is_Delivery_Days AND " +
                        "fd_effective_date = @ad_Effective_Date";
                    pList.Add(cm, "il_Contract_no", il_Contract_no);
                    pList.Add(cm, "il_SF_Key", il_SF_Key);
                    pList.Add(cm, "is_Delivery_Days", is_Delivery_Days);
                    pList.Add(cm, "ad_Effective_Date", ad_Effective_Date);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetRfptDescription(int? ai_rfpt_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    string sequence = string.Empty;
                    cm.CommandText = "SELECT route_freq_point_type.rfpt_description " +
                        "FROM rd.route_freq_point_type " +
                        "WHERE route_freq_point_type.rfpt_id = @ai_rfpt_id  ";
                    pList.Add(cm, "ai_rfpt_id", ai_rfpt_id);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetString(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    dataObject = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetArticalCountCount2(int? lContract, int ilRenewal)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    int sequence = 0;
                    cm.CommandText = "SELECT count(artical_count.contract_no) " + 
                                       "FROM rd.artical_count " +
                                      "WHERE artical_count.contract_no = @lContract AND " +
                                            "artical_count.contract_seq_number = @ilRenewal";
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "ilRenewal", ilRenewal);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractSeqNumber(int? lContract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    int sequence = 0;
                    cm.CommandText = "SELECT contract_renewals.contract_seq_number " +
                                       "FROM rd.contract JOIN rd.contract_renewals " + 
                                                        "ON contract.contract_no = contract_renewals.contract_no " +
                                      "WHERE contract.contract_no = @lContract " +
                                        "AND (contract_renewals.contract_seq_number = (contract.con_active_sequence + 1) " +
                                              "OR (contract.con_active_sequence IS NULL AND contract_renewals.contract_seq_number = 1))";
                    pList.Add(cm, "lContract", lContract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractRenewalsDate(decimal? ldc_new_override_fuel_rate, int? ll_contract_no, int? ll_sequence_no, DateTime? ld_rates_effective_dateref)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "UPDATE rd.vehicle_override_rate vor1 " +
                                        "SET vor1.vor_fuel_rate = @ldc_new_override_fuel_rate " +
                                      "WHERE vor1.contract_no = @ll_contract_no AND " +
                                            "vor1.contract_seq_number = @ll_sequence_no AND " +
                                            "vor1.vor_effective_date >= @ld_rates_effective_date AND " +
                                           "vor1.vor_effective_date = (SELECT max(vor2.vor_effective_date) " + 
                                                                        "FROM rd.vehicle_override_rate vor2 " +
                                                                       "WHERE vor2.contract_no = vor1.contract_no " + 
                                                                         "AND vor2.contract_seq_number = vor1.contract_seq_number)";

                    pList.Add(cm, "ldc_new_override_fuel_rate", ldc_new_override_fuel_rate);
                    pList.Add(cm, "ll_contract_no", ll_contract_no);
                    pList.Add(cm, "ll_sequence_no", ll_sequence_no);
                    pList.Add(cm, "ld_rates_effective_dateref", ld_rates_effective_dateref);

                    _vehicleList = new List<VehicleItem>();
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetPrRateFromPieceRate(int? li_prt_key, DateTime? ld_con_rates_effective_date)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    Decimal? sequence = null;
                    cm.CommandText = "SELECT pr_rate FROM rd.piece_rate " +
                                      "WHERE prt_key = @li_prt_key AND " +
                                            "pr_effective_date = @ld_con_rates_effective_date";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "li_prt_key", li_prt_key);
                    pList.Add(cm, "ld_con_rates_effective_date", ld_con_rates_effective_date);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetDecimal(0);
                        }

                    }
                    decVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetConRatesEffDate(int? li_contract_no, int? li_seq_num)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    DateTime? sequence = null;
                    cm.CommandText = "SELECT con_rates_effective_date " +
                                       "FROM rd.contract_renewals " + 
                                      "WHERE contract_no = @li_contract_no AND " +
                                            "contract_seq_number = @li_seq_num";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "li_contract_no", li_contract_no);
                    pList.Add(cm, "li_seq_num", li_seq_num);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetDateTime(0);
                        }

                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractRenewalsDate1(int? li_seq_num, int? li_contract_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT con_start_date, con_expiry_date " +
                                       "from rd.contract_renewals  " +
                                      "where contract_seq_number = @li_seq_num  and " +
                                            "contract_no = @li_contract_no";

                    pList.Add(cm, "li_seq_num", li_seq_num);
                    pList.Add(cm, "li_contract_no", li_contract_no);

                    _contractRenewalsDateItemList = new List<ContractRenewalsDateItem>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                ContractRenewalsDateItem rf = new ContractRenewalsDateItem();
                                _contractRenewalsDateItemList.Add(rf);
                                rf.con_start_date = dr.GetDateTime(0);
                                rf.con_expiry_date = dr.GetDateTime(1);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetCustomerAddressMovesCountByIdMoveOutDate(int? ll_new_adr_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(cam.cust_id) " +
                        "from rd.rds_customer c, rd.customer_address_moves cam " +
                        "where c.cust_id = cam.cust_id and cam.adr_id = @ll_new_adr_id and " +
                        "cam.move_out_date is null and c.cust_surname_company like 'Dummy%'";
                    pList.Add(cm, "ll_new_adr_id", ll_new_adr_id);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _DeleteAddressByAdrId(int? ll_old_adr_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "delete from rd.address where adr_id = @ll_old_adr_id";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ll_old_adr_id", ll_old_adr_id);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetCreateRoadId(string ls_userid, int? ll_rs_id, int? ll_tc_id, string ls_sl_name, string ls_road_name, int? ll_rt_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    //cm.CommandText = "select  rd.f_create_road (@ls_road_name, @ll_rt_id, @ll_rs_id, @ls_sl_name, @ll_tc_id,@ls_userid) from dummy";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.f_create_road";
                    pList.Add(cm, "in_user", ls_userid);
                    pList.Add(cm, "in_rsid", ll_rs_id);
                    pList.Add(cm, "in_tcid", ll_tc_id);
                    pList.Add(cm, "in_slname", ls_sl_name);
                    pList.Add(cm, "in_roadname", ls_road_name);
                    pList.Add(cm, "in_rtid", ll_rt_id);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _CheckValidateRoad(int? ll_tc_id, string ls_sl_name, string ls_road_name, int? ll_rt_id, int? ll_rs_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT rd.f_validate_road (@ls_road_name, @ll_rt_id, @ll_rs_id, @ls_sl_name,@ll_tc_id)";
                    pList.Add(cm, "ll_tc_id", ll_tc_id);
                    pList.Add(cm, "ls_sl_name", ls_sl_name);
                    pList.Add(cm, "ls_road_name", ls_road_name);
                    pList.Add(cm, "ll_rt_id", ll_rt_id);
                    pList.Add(cm, "ll_rs_id", ll_rs_id);

                    try
                    {
                        intVal = -1;
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractComplex3(string ls_and, string ls_town_name, string ls_rd_no, string ls_space, string ls_percent, string ls_comma)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT contract_no FROM rd.contract " +
                        " WHERE con_date_terminated IS NULL AND " +
                        "con_rd_ref_text LIKE @ls_percent + @ls_town_name + @ls_percent AND " +
                        "(con_rd_ref_text like @ls_rd_no + @ls_space + @ls_percent OR " +
                        "con_rd_ref_text like @ls_rd_no + @ls_comma + @ls_percent OR " +
                        "con_rd_ref_text like @ls_rd_no + @ls_and + @ls_percent OR " +
                        "con_rd_ref_text like @ls_percent + @ls_space + @ls_rd_no + @ls_percent OR " +
                        "con_rd_ref_text like @ls_percent + @ls_comma + @ls_rd_no + @ls_percent OR " +
                        "con_rd_ref_text like @ls_percent + @ls_and + @ls_rd_no + @ls_percent )";

                    pList.Add(cm, "ls_and", ls_and);
                    pList.Add(cm, "ls_town_name", ls_town_name);
                    pList.Add(cm, "ls_rd_no", ls_rd_no);
                    pList.Add(cm, "ls_space", ls_space);
                    pList.Add(cm, "ls_percent", ls_percent);
                    pList.Add(cm, "ls_comma", ls_comma);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractComplex2(string ls_and, string ls_town_name, string ls_rd_no, string ls_space, string ls_percent, int? ll_contract_no, string ls_comma)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT contract_no FROM rd.contract " +
                        "WHERE con_date_terminated IS NULL AND " +
                        "contract_no = @ll_contract_no AND " +
                        "con_rd_ref_text LIKE @ls_percent + @ls_town_name + @ls_percent AND " +
                        "( con_rd_ref_text like @ls_rd_no + @ls_space + @ls_percent OR " +
                        "con_rd_ref_text like @ls_rd_no + @ls_comma + @ls_percent OR " +
                        "con_rd_ref_text like @ls_rd_no + @ls_and + @ls_percent OR " +
                        "con_rd_ref_text like @ls_percent + @ls_space + @ls_rd_no + @ls_percent OR " +
                        "con_rd_ref_text like @ls_percent + @ls_comma + @ls_rd_no + @ls_percent OR " +
                        "con_rd_ref_text like @ls_percent + @ls_and + @ls_rd_no + @ls_percent )";

                    pList.Add(cm, "ls_and", ls_and);
                    pList.Add(cm, "ls_town_name", ls_town_name);
                    pList.Add(cm, "ls_rd_no", ls_rd_no);
                    pList.Add(cm, "ls_space", ls_space);
                    pList.Add(cm, "ls_percent", ls_percent);
                    pList.Add(cm, "ll_contract_no", ll_contract_no);
                    pList.Add(cm, "ls_comma", ls_comma);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractComplex(string ls_and, string ls_town_name, string ls_rd_no, string ls_space, string ls_percent, string ls_comma)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(*) FROM rd.contract " +
                        "WHERE con_date_terminated IS NULL AND " +
                        "con_rd_ref_text LIKE @ls_percent + @ls_town_name + @ls_percent AND " +
                        "(con_rd_ref_text like @ls_rd_no + @ls_space + @ls_percent OR " +
                        "con_rd_ref_text like @ls_rd_no + @ls_comma + @ls_percent OR " +
                        "con_rd_ref_text like @ls_rd_no + @ls_and + @ls_percent OR " +
                        "con_rd_ref_text like @ls_percent + @ls_space + @ls_rd_no + @ls_percent OR " +
                        "con_rd_ref_text like @ls_percent + @ls_comma + @ls_rd_no + @ls_percent OR " +
                        "con_rd_ref_text like @ls_percent + @ls_and + @ls_rd_no + @ls_percent )";
                    pList.Add(cm, "ls_and", ls_and);
                    pList.Add(cm, "ls_town_name", ls_town_name);
                    pList.Add(cm, "ls_rd_no", ls_rd_no);
                    pList.Add(cm, "ls_space", ls_space);
                    pList.Add(cm, "ls_percent", ls_percent);
                    pList.Add(cm, "ls_comma", ls_comma);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetAddressCountByAdrId(int? al_adrID, int ll_contract_type_rd)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(*) FROM rd.address a, rd.types_for_contract tfc " +
                        "WHERE a.adr_id = @al_adrID AND " +
                        "tfc.contract_no = a.contract_no AND " +
                        "ct_key = @ll_contract_type_rd";

                    pList.Add(cm, "al_adrID", al_adrID);
                    pList.Add(cm, "ll_contract_type_rd", ll_contract_type_rd);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetRdsNpadAddrOccupied(string as_occupied, string is_npadoutfile, int? al_dpid, string is_userid, string as_description)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    int intSWP_Re = 0;
                   // cm.CommandText = "select f_rds_npad_addr_occupied(@al_dpid, @as_occupied, @is_userid, @as_description, @is_npadoutfile) from dummy";
                    //add by mkwang
                    cm.CommandType = CommandType.Text; 
                    cm.CommandText = "declare @x int exec @x = rd.f_rds_npad_addr_occupied @al_dpid, @as_occupied, @is_userid, @as_description, " + 
                                        " @is_npadoutfile, @SWP_Re select @x";                    
                    //!cm.CommandText = "declare @x int exec @x = rd.f_rds_npad_addr_occupied " + al_dpid + ", " + "'" + as_occupied + "', " +
                    //!    "'" + is_userid + "', " + "'" + as_description + "', " +
                    //!        "'" + is_npadoutfile + "'," + SWP_Re + " select @x";                    
                    pList.Add(cm, "as_occupied", as_occupied);
                    pList.Add(cm, "is_npadoutfile", is_npadoutfile);
                    pList.Add(cm, "al_dpid", al_dpid);
                    pList.Add(cm, "is_userid", is_userid);
                    pList.Add(cm, "as_description", as_description);

                    pList.Add(cm, "SWP_Re", intSWP_Re);
                    pList["SWP_Re"].Direction = ParameterDirection.InputOutput;

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetAddressDpIdByAdrId(int? al_adrid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT dp_id FROM rd.address WHERE adr_id = @al_adrid";
                    pList.Add(cm, "al_adrid", al_adrid);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractRenewalsExists(int? al_contractNo)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select 1 from rd.contract_renewals " +
                        "where contract_renewals.contract_no = @al_contractNo and " +
                        "getdate() between contract_renewals.con_start_date and contract_renewals.con_expiry_date";
                    pList.Add(cm, "al_contractNo", al_contractNo);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractNoConDateTerminated(int? al_contractNo)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select contract_no, con_date_terminated from rd.contract " +
                        "where contract.contract_no = @al_contractNo";
                    pList.Add(cm, "al_contractNo", al_contractNo);
                    _ContractNoConDateTerminatedList = new List<ContractNoConDateTerminatedItem>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                ContractNoConDateTerminatedItem item = new ContractNoConDateTerminatedItem();
                                _ContractNoConDateTerminatedList.Add(item);
                                if (dr[0] == null)
                                {
                                    item._contract_no = null;
                                }
                                else
                                {
                                    item._contract_no = dr.GetInt32(0);
                                }
                                if (dr[1] == null)
                                {
                                    item._con_date_terminated = null;
                                }
                                else
                                {
                                    item._con_date_terminated = dr.GetDateTime(1);//dr.GetDateTime(1);
                                }
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetPostCodeIdCode(int? al_tc_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT post_code, post_code_id " 
                                   +   "FROM rd.post_code pc, towncity tc " 
                                   +  "WHERE post_code = (SELECT max(pc.post_code) "
                                   +                       "FROM rd.post_code pc, rd.towncity tc " 
                                   +                      "WHERE tc.tc_id = @al_tc_id " 
                                   +                        "AND pc.post_mail_town = tc.tc_name)";
                    pList.Add(cm, "al_tc_id", al_tc_id);
                    _PostCodeIdCodeList = new List<PostCodeIdCodeItem>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                PostCodeIdCodeItem item = new PostCodeIdCodeItem();
                                _PostCodeIdCodeList.Add(item);
                                item._post_code = dr.GetString(0);
                                item._post_code_id = dr.GetInt32(1);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetFirstPostCodeIdCode(int? al_tcid, string ls_rdno)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT TOP 1 post_code_id, post_code " 
                                   +   "FROM rd.post_code, rd.towncity " 
                                   +  "WHERE post_mail_town = tc_name " 
                                   +    "AND tc_id = @al_tcid " 
                                   +    "AND rd_no = @ls_rdno";
                    pList.Add(cm, "al_tcid", al_tcid);
                    pList.Add(cm, "ls_rdno", ls_rdno);
                    _FirstPostCodeIdCodeList = new List<FirstPostCodeIdCodeItem>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                FirstPostCodeIdCodeItem item = new FirstPostCodeIdCodeItem();
                                _FirstPostCodeIdCodeList.Add(item);
                                item._post_code_id = dr.GetInt32(0);
                                item._post_code = dr.GetString(1);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetFirstPostCodeIdCode1(int? al_tcid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT TOP 1 post_code_id, post_code "
                                   + "FROM rd.post_code pc, rd.towncity tc " 
                                   +  "WHERE post_mail_town = tc_name "
                                   +    "AND tc_id = @al_tcid "
                                   +    "AND rd_no is null";
                    pList.Add(cm, "al_tcid", al_tcid);
                    _FirstPostCodeIdCodeList = new List<FirstPostCodeIdCodeItem>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                FirstPostCodeIdCodeItem item = new FirstPostCodeIdCodeItem();
                                _FirstPostCodeIdCodeList.Add(item);
                                item._post_code_id = dr.GetInt32(0);
                                item._post_code = dr.GetString(1);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateAddressDpIdByAdrId(int? al_new_master_dpid, int? al_new_adr_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "UPDATE rd.address set dp_id = @al_new_master_dpid where adr_id = @al_new_adr_id";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_new_master_dpid", al_new_master_dpid);
                    pList.Add(cm, "al_new_adr_id", al_new_adr_id);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _DeleteAdressByAdrId(int? al_adrID)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "delete from rd.address where adr_id = @al_adrID";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_adrID", al_adrID);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetRdsNpadDeleteCustomer(string is_npadoutfile, int? ll_dpid, string is_userid, string as_description)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "declare @x int exec @x = rd.f_rds_npad_delete_customer @ll_dpid, @is_userid, @as_description, @is_npadoutfile select @x";
                    cm.CommandType = CommandType.Text;
                    pList.Add(cm, "is_npadoutfile", is_npadoutfile);
                    pList.Add(cm, "ll_dpid", ll_dpid);
                    pList.Add(cm, "is_userid", is_userid);
                    pList.Add(cm, "as_description", as_description);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetRdsFGetNextSequence()
        {
            using (SqlConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO") as SqlConnection)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    //add by mkwang
                    cm.CommandText = "declare @x  int exec @x = rd.f_getNextSequence 'NPADFileSeq',1,10000 select @x";
                    cm.CommandType = CommandType.Text;                    
                    
                    try
                    {
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetRdsCustomerAddressMoves(int? al_adr_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select count(*) from rd.customer_address_moves where adr_id = @al_adr_id  and move_out_date is null";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_adr_id", al_adr_id);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetCustomerAddressMovesDpIdCustId(int? al_adrid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select cam.dp_id, cam.cust_id " + 
                                       "from rd.rds_customer c, rd.customer_address_moves cam " +
                                      "where c.cust_id = cam.cust_id and cam.adr_id = @al_adrid and " +
                                            "cam.move_out_date is null and c.master_cust_id is null and " +
                                            "c.cust_surname_company like 'Dummy%'";
                    pList.Add(cm, "al_adrid", al_adrid);
                    _CustomerAddressMovesDpIdCustIdList = new List<CustomerAddressMovesDpIdCustIdItem>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                CustomerAddressMovesDpIdCustIdItem item = new CustomerAddressMovesDpIdCustIdItem();
                                _CustomerAddressMovesDpIdCustIdList.Add(item);
                                item._dp_id = dr.GetInt32(0);
                                item._cust_id = dr.GetInt32(1);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetManyRdsCustomInfo(int? al_adrid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select cam.dp_id, cam.cust_id " +
                                       "from rd.rds_customer c, rd.customer_address_moves cam " +
                                      "where c.cust_id = cam.cust_id and cam.adr_id = @al_adrid and " +
                                            "cam.move_out_date is null and c.master_cust_id is not null and " +
                                            "c.cust_surname_company like 'Dummy%'";

                    pList.Add(cm, "al_adrid", al_adrid);
                    _RdsCustomInfoList = new List<RdsCustomInfoItem>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                RdsCustomInfoItem item = new RdsCustomInfoItem();
                                _RdsCustomInfoList.Add(item);
                                item._dp_id = dr.GetInt32(0);
                                item._cust_id = dr.GetInt32(1);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateCustomerAddressMovesByCustId(int? al_cust)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "UPDATE rd.customer_address_moves " +
                        "SET move_out_date = CAST(FLOOR(CAST(GETDATE() AS FLOAT)) AS DATETIME) " +
                        "WHERE cust_id = @al_cust and move_out_date is null";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_cust", al_cust);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetRdsNpadTransferCustomer(string is_userid, string is_npadoutfile, int? al_old_dpid, string as_description, int? al_new_dpid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                   // cm.CommandText = "select f_rds_npad_transfer_customer(@al_old_dpid, @al_new_dpid, @is_userid, @as_description, @is_npadoutfile) from dummy";
                    //add by mkwang 
                    cm.CommandText = "declare @x int exec @x = rd.f_rds_npad_transfer_customer @al_old_dpid, @al_new_dpid, @is_userid, " + 
                                        " @as_description, @is_npadoutfile select @x";
                    cm.CommandType = CommandType.Text;
                    pList.Add(cm, "is_userid", is_userid);
                    pList.Add(cm, "is_npadoutfile", is_npadoutfile);
                    pList.Add(cm, "al_old_dpid", al_old_dpid);
                    pList.Add(cm, "as_description", as_description);
                    pList.Add(cm, "al_new_dpid", al_new_dpid);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetCustomerAddressMovesAdrIdByCustId(int? al_custID)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT adr_id FROM rd.customer_address_moves WHERE cust_id = @al_custID AND move_out_date is null";
                    pList.Add(cm, "al_custID", al_custID);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetAddressAdrNo(int? al_adr_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select adr_no from rd.address where adr_id = @al_adr_id";
                    pList.Add(cm, "al_adr_id", al_adr_id);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                strVal = GetValueFromReader<String>(dr, 0); //dr.GetString(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetCustomerAddressMovesByCustId(int? al_custID)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT dp_id FROM rd.customer_address_moves WHERE cust_id = @al_custID AND move_out_date is null";
                    pList.Add(cm, "al_custID", al_custID);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetTownCityTcId(string as_tcname)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT tc_id FROM rd.towncity WHERE tc_name = @as_tcname";
                    pList.Add(cm, "as_tcname", as_tcname);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetTypesForContractCount(int? al_contract_no, int? ll_contract_type_rd)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(*) FROM rd.types_for_contract " +
                        "WHERE contract_no = @al_contract_no AND " +
                        "ct_key = @ll_contract_type_rd";

                    pList.Add(cm, "al_contract_no", al_contract_no);
                    pList.Add(cm, "ll_contract_type_rd", ll_contract_type_rd);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _SpExtensionDeliveryTime()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_Extension_Deliverytime";

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                                decVal = dr.GetDecimal(1);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _InsertCustomerAddressMoves(int? il_addrid, int? ll_custid, int? ldt_movein)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "insert into rd.customer_address_moves " +
                        "( adr_id, cust_id, dp_id, move_in_date, move_out_date, move_out_source, move_out_user) " +
                        "values ( @il_addrid, @ll_custid, null, @ldt_movein, null, null, null )";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "il_addrid", il_addrid);
                    pList.Add(cm, "ll_custid", ll_custid);
                    pList.Add(cm, "ldt_movein", ldt_movein);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateRdsCustomerById(int? al_master, int? al_custID)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "UPDATE rd.rds_customer set master_cust_id = @al_master where cust_id = @al_custID";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_master", al_master);
                    pList.Add(cm, "al_custID", al_custID);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _SpExtenstionRFDistance(int? lContract, string param2, int? param1)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_Extension_RFDistance";
                    pList.Add(cm, "inContract", lContract);
                    pList.Add(cm, "indays", param2);
                    pList.Add(cm, "inkey", param1);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                decVal = dr.GetDecimal(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _SpExtensionDaysPerAnnum(int? ll_key, int? lContract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_Extension_DaysPerAnnum";
                    pList.Add(cm, "inkey", ll_key);
                    pList.Add(cm, "inContract", lContract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _SpGetCurrentRenewal(int? lContract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_GetCurrentrenewal";
                    pList.Add(cm, "inContract", lContract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractCountByRenewalAndRgCode(int? lContract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(*) FROM rd.non_vehicle_rate, rd.contract_renewals, rd.contract " +
                        "WHERE contract.contract_no = contract_renewals.contract_no and " +
                        "contract.rg_code = non_vehicle_rate.rg_code and " +
                        "contract_renewals.con_rates_effective_date = non_vehicle_rate.nvr_rates_effective_date and " +
                        "contract.contract_no = @lContract";
                    pList.Add(cm, "lContract", lContract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _SpExtensionCustCount2(string ls_ui_userid, int? lContract, int? ll_rc_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = cm.CommandText = "rd.sp_Extension_CustCount2";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inUIUserId", ls_ui_userid);
                    pList.Add(cm, "inContract", lContract);
                    pList.Add(cm, "inComponentId", ll_rc_id);
                    _sqlcode = -1;
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            ret = true;
                            if (dr.Read())
                            {
                                this.intVal = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetMaxContractRenewals(int? li_contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select max(contract_seq_number) from rd.contract_renewals where contract_no = @li_contract";
                    pList.Add(cm, "li_contract", li_contract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetPrevBench(int? li_contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT rd.get_prev_bench(@li_contract) FROM sys.dummy";
                    pList.Add(cm, "li_contract", li_contract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                decVal = dr.GetDecimal(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetNonVehicleRateRgCodeMin(DateTime? mcdate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT min(nvr.rg_code) FROM rd.non_vehicle_rate nvr " +
                        "WHERE nvr.nvr_contract_end = (SELECT min(nvr2.nvr_contract_end) FROM rd.non_vehicle_rate nvr2 WHERE nvr2.nvr_contract_end >= @mcdate) ";
                    pList.Add(cm, "mcdate", mcdate);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetNonVehicleRateRgCodeMin1(int? rg_code, DateTime? mcdate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT min(nvr.rg_code) " + 
                                       "FROM rd.non_vehicle_rate nvr " +
                                      "WHERE nvr.rg_code <> @rg_code and " +
                                            "nvr.nvr_contract_end = " + 
                                                   "(SELECT min(nvr2.nvr_contract_end) " + 
                                                      "FROM rd.non_vehicle_rate nvr2 " + 
                                                     "WHERE nvr2.nvr_contract_end > @mcdate and " + 
                                                           "nvr2.nvr_contract_end > " + 
                                                                   "(select min(nvr3.nvr_contract_end) " + 
                                                                      "from rd.non_vehicle_rate nvr3 " + 
                                                                     "where nvr3.nvr_contract_end >=@mcdate))";

                    pList.Add(cm, "rg_code", rg_code);
                    pList.Add(cm, "mcdate", mcdate);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _InsertFreqAdjustments(decimal? dBenchmark, int? lNextSeq, DateTime? dEffectiveDate, int? lSequence, int? lSFKey, string sDeliveryDays, decimal? dAmountToPay, int? lContract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "INSERT INTO rd.frequency_adjustments " +
                        "(contract_no, contract_seq_number, " +
                        "fd_unique_seq_number, fd_adjustment_amount, " +
                        "fd_paid_to_date, fd_bm_after_extn, " +
                        "fd_confirmed, fd_amount_to_pay, " +
                        "fd_effective_date, sf_key, rf_delivery_days) " +
                        "VALUES (@lContract, @lSequence, " +
                        "@lNextSeq, @dBenchmark, " +
                        "null, rd.BenchmarkCalc2005(@lContract, @lSequence), " +
                        "'N', @dAmountToPay, " +
                        "@dEffectiveDate, @lSFKey, @sDeliveryDays)";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "dBenchmark", dBenchmark);
                    pList.Add(cm, "lNextSeq", lNextSeq);
                    pList.Add(cm, "dEffectiveDate", dEffectiveDate);
                    pList.Add(cm, "lSequence", lSequence);
                    pList.Add(cm, "lSFKey", lSFKey);
                    pList.Add(cm, "sDeliveryDays", sDeliveryDays);
                    pList.Add(cm, "dAmountToPay", dAmountToPay);
                    pList.Add(cm, "lContract", lContract);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetMaxFreqAdjustmentsSeqNumber(int? lSequence, int? lContract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select max(fd_unique_seq_number) " +
                        "from rd.frequency_adjustments " +
                        "where contract_no = @lContract and contract_seq_number = @lSequence";

                    pList.Add(cm, "lSequence", lSequence);
                    pList.Add(cm, "lContract", lContract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetMaxContractRenewalsSeqNumber(int? lContract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select max(contract_seq_number) " +
                        "from rd.contract_renewals where contract_no = @lContract";
                    pList.Add(cm, "lContract", lContract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateRouteFreqRfDist(int? lContract, decimal dDistance, int? lSFKey, string sDeliveryDays)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "UPDATE rd.route_frequency " +
                        "SET rf_distance = rf_distance + @dDistance " +
                        "WHERE contract_no = @lContract AND " +
                        "sf_key = @lSFKey AND " +
                        "rf_delivery_days = @sDeliveryDays";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "dDistance", dDistance);
                    pList.Add(cm, "lSFKey", lSFKey);
                    pList.Add(cm, "sDeliveryDays", sDeliveryDays);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _InsertIntoFreqDist(int? lNoOtherBags, int? lVolume, int? lNoRuralBags, int? lNoCMBCustomers, DateTime? dEffectiveDate, int? lNoCMBS, int? lNoPostOffices, decimal? decDelHrs, string sReason, decimal dDistance, int? lNoPrivateBags, int? lSFKey, string sDeliveryDays, int? lNoBoxes, int? lContract, decimal? decProcHrs)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "INSERT INTO rd.frequency_distances " +
                        "( fd_effective_date, contract_no, sf_key, " +
                        "rf_delivery_days, fd_distance, fd_no_of_boxes, " +
                        "fd_no_rural_bags, fd_no_other_bags, fd_no_private_bags, " +
                        "fd_no_post_offices, fd_no_cmbs, fd_no_cmb_customers," +
                        "fd_volume, fd_change_reason, fd_delivery_hrs_per_week, " +
                        "fd_processing_hrs_week) " +
                        "VALUES ( @dEffectiveDate, @lContract, @lSFKey, " +
                        "@sDeliveryDays, @dDistance, @lNoBoxes," +
                        "@lNoRuralBags, @lNoOtherBags, @lNoPrivateBags," +
                        "@lNoPostOffices, @lNoCMBS, @lNoCMBCustomers," +
                        "@lVolume, @sReason, @decDelHrs," +
                        "@decProcHrs)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lNoOtherBags", lNoOtherBags);
                    pList.Add(cm, "lVolume", lVolume);
                    pList.Add(cm, "lNoRuralBags", lNoRuralBags);
                    pList.Add(cm, "lNoCMBCustomers", lNoCMBCustomers);
                    pList.Add(cm, "dEffectiveDate", dEffectiveDate);
                    pList.Add(cm, "lNoCMBS", lNoCMBS);
                    pList.Add(cm, "lNoPostOffices", lNoPostOffices);
                    pList.Add(cm, "decDelHrs", decDelHrs);
                    pList.Add(cm, "sReason", sReason);
                    pList.Add(cm, "dDistance", dDistance);
                    pList.Add(cm, "lNoPrivateBags", lNoPrivateBags);
                    pList.Add(cm, "lSFKey", lSFKey);
                    pList.Add(cm, "sDeliveryDays", sDeliveryDays);
                    pList.Add(cm, "lNoBoxes", lNoBoxes);
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "decProcHrs", decProcHrs);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetFreqDistCount(DateTime? dEffectiveDate, int? lContract, int? lSFKey, string sDeliveryDays)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select count (*) from rd.frequency_distances " +
                        "WHERE contract_no = @lContract and " +
                        "sf_key = @lSFKey and " +
                        "rf_delivery_days = @sDeliveryDays and " +
                        "fd_effective_date = @dEffectiveDate";

                    pList.Add(cm, "dEffectiveDate", dEffectiveDate);
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "lSFKey", lSFKey);
                    pList.Add(cm, "sDeliveryDays", sDeliveryDays);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractCountWithRenewals(DateTime? dEffectiveDate, int? lContract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select count(*) " +
                        "from rd.contract join rd.contract_renewals on contract.contract_no = contract_renewals.contract_no and " +
                        "contract.con_active_sequence = contract_renewals.contract_seq_number " +
                        "where @dEffectiveDate between contract_renewals.con_start_date and " +
                        "contract_renewals.con_expiry_date and contract.contract_no = @lContract";
                    pList.Add(cm, "dEffectiveDate", dEffectiveDate);
                    pList.Add(cm, "lContract", lContract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _DeleteFromTempContractAdjustments()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "delete from rd.temp_Contract_Adjustments";
                    ParameterCollection pList = new ParameterCollection();

                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _DeleteAddressFreqSeqByContractNo(int? il_oldcontractno)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "DELETE rd.address_frequency_sequence WHERE contract_no = @il_oldcontractno";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "il_oldcontractno", il_oldcontractno);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateAddressContractNo(int? ll_newcontractno, int? il_oldcontractno)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "UPDATE rd.Address SET contract_no = @ll_newcontractno WHERE contract_no = @il_oldcontractno";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ll_newcontractno", ll_newcontractno);
                    pList.Add(cm, "il_oldcontractno", il_oldcontractno);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractCountByNo(int? ll_newcontractno)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT Count(*) FROM rd.contract WHERE contract_no = @ll_newcontractno and con_date_terminated is null";
                    pList.Add(cm, "ll_newcontractno", ll_newcontractno);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractInfoByNo(int? il_contract_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select contract.con_title, outlet.o_name " + 
                        "from rd.contract, rd.outlet " +
                        "where contract.contract_no = @il_contract_no and " +
                        "contract.con_base_office = outlet.outlet_id";

                    pList.Add(cm, "il_contract_no", il_contract_no);
                    _ContractInfoByNoList = new List<ContractInfoByNoItem>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                ContractInfoByNoItem item = new ContractInfoByNoItem();
                                _ContractInfoByNoList.Add(item);
                                item._con_title = dr.GetString(0);
                                item._o_name = dr.GetString(1);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _InsertAddressFreqSeq(int? il_sf_key, int? ll_sequence_no, int? il_contract_no, int? ll_address_id, string is_delivery_days)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "Insert Into rd.address_frequency_sequence (adr_id, sf_key, rf_delivery_days, contract_no, seq_num) " +
                        "Values (@ll_address_id, @il_sf_key, @is_delivery_days, @il_contract_no, @ll_sequence_no)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "il_sf_key", il_sf_key);
                    pList.Add(cm, "ll_sequence_no", ll_sequence_no);
                    pList.Add(cm, "il_contract_no", il_contract_no);
                    pList.Add(cm, "ll_address_id", ll_address_id);
                    pList.Add(cm, "is_delivery_days", is_delivery_days);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _DeleteFromAddressFreqSeq(int? il_sf_key, int? il_contract_no, string is_delivery_days)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "Delete from rd.address_frequency_sequence " +
                        "where contract_no = @il_contract_no and " +
                        "sf_key = @il_sf_key and " +
                        "rf_delivery_days = @is_delivery_days";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "il_sf_key", il_sf_key);
                    pList.Add(cm, "il_contract_no", il_contract_no);
                    pList.Add(cm, "is_delivery_days", is_delivery_days);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractConTitle(int? il_contract_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select con_title from rd.contract where contract_no = @il_contract_no";
                    pList.Add(cm, "il_contract_no", il_contract_no);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                strVal = dr.GetString(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateCustomerAddressMovesDpId(int? il_customer, int? al_dpid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "UPDATE rd.customer_address_moves " +
                        "set dp_id = @al_dpid " +
                        "where cust_id = @il_customer and move_out_date is null";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "il_customer", il_customer);
                    pList.Add(cm, "al_dpid", al_dpid);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _InsertCustomerAddressMoves2(int? ll_cust, int? il_adrid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "insert into rd.customer_address_moves (adr_id, cust_id, dp_id, move_in_date, move_out_date, move_out_source, move_out_user) " +
                        "values ( @il_adrid, @ll_cust, NULL, getdate(), NULL, NULL, NULL )";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ll_cust", ll_cust);
                    pList.Add(cm, "il_adrid", il_adrid);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetRdsNpadModifyCustomer(int? al_dpid, string is_userid, string is_npadoutfile, string ls_description)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                   // cm.CommandText = "select f_rds_npad_modify_customer ( @al_dpid, @is_userid, @ls_description, @is_npadoutfile) from dummy";
                    cm.CommandText = "declare @x int exec @x = rd.f_rds_npad_modify_customer @al_dpid, @is_userid, @ls_description, @is_npadoutfile select @x";
                    cm.CommandType = CommandType.Text;
                    pList.Add(cm, "al_dpid", al_dpid);
                    pList.Add(cm, "is_userid", is_userid);
                    pList.Add(cm, "is_npadoutfile", is_npadoutfile);
                    pList.Add(cm, "ls_description", ls_description);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetNextSequence(string seqname)
        {
            using (SqlConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO") as SqlConnection)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {                 
                  
                    // add by mkwang
                    //!cm.CommandText = "declare @x  int exec @x = rd.f_getNextSequence 'NPADFileSeq',1,10000 select @x";
                    ////cm.CommandType = CommandType.StoredProcedure;
                    ////cm.CommandText = "rd.f_getNextSequence";                    

                    ////pList.Add(cm, "sequencename", seqname);
                    ////pList.Add(cm, "update_flag", 1);
                    ////pList.Add(cm, "wrapValue", 10000);
                    //pList.Add(cm, "RETURN_VALUE", intVal);                    
                    //pList["RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "declare @RETURN_VALUE  int exec @RETURN_VALUE = rd.f_getNextSequence '" + seqname + "',1,10000 select @RETURN_VALUE";                 

                    try
                    {
                        using (SqlDataReader dr = cm.ExecuteReader())
                        //!DBHelper.ExecuteNonQuery(cm, pList);                        
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                                //intVal = (int)(cm.Parameters["RETURN_VALUE"].Value);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _InsertCustomerAddressMoves3(int? ll_cust, int? il_adrid, int? ll_dpid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "insert into rd.customer_address_moves ( adr_id, cust_id, dp_id, move_in_date, move_out_date, move_out_source, move_out_user ) " +
                        "values ( @il_adrid, @ll_cust, @ll_dpid, CAST(FLOOR(CAST(GetDate() AS FLOAT)) AS DATETIME), NULL, NULL, NULL )";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ll_cust", ll_cust);
                    pList.Add(cm, "il_adrid", il_adrid);
                    pList.Add(cm, "ll_dpid", ll_dpid);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetCustomerAddressMovesTemp(int? il_cust_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select 1 from rd.customer_address_moves cam where cust_id = @il_cust_id and move_out_date is null";
                    pList.Add(cm, "il_cust_id", il_cust_id);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetCustomerAddressMovesDpId(int? al_custId)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select dp_id from rd.customer_address_moves where cust_id = @al_custId and move_out_date is null";
                    pList.Add(cm, "al_custId", al_custId);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetVovEffectiveDate(DateTime? ld_effective_date, int? il_sequence, int? il_contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select vor_effective_date from rd.vehicle_override_rate " +
                        "where contract_no = @il_contract and " +
                        "contract_seq_number = @il_sequence and " +
                        "vor_effective_date = @ld_effective_date";

                    pList.Add(cm, "ld_effective_date", ld_effective_date);
                    pList.Add(cm, "il_sequence", il_sequence);
                    pList.Add(cm, "il_contract", il_contract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                dtVal = dr.GetDateTime(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractCountByNoAndSeq(int? il_sequence, int? il_contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(*) FROM rd.contract WHERE contract_no = @il_contract AND con_active_sequence = @il_sequence";
                    pList.Add(cm, "il_sequence", il_sequence);
                    pList.Add(cm, "il_contract", il_contract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetFrequencyDistancesCount2(int? ll_sfkey, string ls_deldays, DateTime? ld_next_date, int? al_contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(*) FROM rd.frequency_distances " +
                        "WHERE contract_no = @al_contract AND " +
                        "sf_key = @ll_sfkey AND " +
                        "rf_delivery_days = @ls_deldays AND " +
                        "fd_effective_date = @ld_next_date";

                    pList.Add(cm, "ll_sfkey", ll_sfkey);
                    pList.Add(cm, "ls_deldays", ls_deldays);
                    pList.Add(cm, "ld_next_date", ld_next_date);
                    pList.Add(cm, "al_contract", al_contract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetFrequencyDistancesCount1(int? ll_sfkey, string ls_deldays, DateTime? ld_next_date, int? al_contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(*) FROM rd.frequency_distances " +
                        "WHERE contract_no = @al_contract AND " +
                        "sf_key = @ll_sfkey AND " +
                        "rf_delivery_days = @ls_deldays AND " +
                        "fd_effective_date = @ld_next_date";
                    pList.Add(cm, "ll_sfkey", ll_sfkey);
                    pList.Add(cm, "ls_deldays", ls_deldays);
                    pList.Add(cm, "ld_next_date", ld_next_date);
                    pList.Add(cm, "al_contract", al_contract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetFirstRouteFrequenctSfKey(int? al_contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT top 1 sf_key, rf_delivery_days FROM rd.route_frequency WHERE contract_no = @al_contract AND rf_active = 'Y'";
                    pList.Add(cm, "al_contract", al_contract);
                    _FirstRouteFrequenctSfKeyList = new List<FirstRouteFrequenctSfKeyItem>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                FirstRouteFrequenctSfKeyItem item = new FirstRouteFrequenctSfKeyItem();
                                _FirstRouteFrequenctSfKeyList.Add(item);
                                item._sf_key = dr.GetInt32(0);
                                item._rf_delivery_days = dr.GetString(1);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractDateTerminated(int? al_contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select con_date_terminated from rd.contract where contract_no = @al_contract";
                    pList.Add(cm, "al_contract", al_contract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                dtVal = dr.GetDateTime(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetVehicleLifeCode(int? il_sequence, int? il_contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT vehicle.v_remaining_economic_life " + 
                         "FROM rd.contract_vehical, rd.vehicle " +
                        "WHERE vehicle.vehicle_number = contract_vehical.vehicle_number and " +
                        "contract_vehical.contract_no = @il_contract AND " +
                        "contract_vehical.contract_seq_number = @il_sequence";
                    pList.Add(cm, "il_sequence", il_sequence);
                    pList.Add(cm, "il_contract", il_contract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetBenchmarkCalc2005(int? il_sequence, int? il_contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    //cm.CommandText = "exec BenchmarkCalc2005  @il_contract, @il_sequence ";
                    pList.Add(cm, "il_sequence", il_sequence);
                    pList.Add(cm, "il_contract", il_contract);

                    //using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    //{
                    //    if (dr.Read())
                    //    {
                    //        sequence = dr.GetInt32(0);
                    //    }
                    //    _sqlcode = 0;
                    //}

                    cm.CommandText = "SELECT rd.BenchmarkCalc2005 (:il_contract, :il_sequence)";

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                decVal = Convert.ToDecimal(dr.GetFloat(0));
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetCaLoadResults()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select rows_inserted, rows_skipped, row_errors, amount_inserted from rd.ca_load_results where load_name = 'ContractAdjust'";

                    _CaLoadResultsList = new List<CaLoadResultsItem>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                CaLoadResultsItem item = new CaLoadResultsItem();
                                _CaLoadResultsList.Add(item);
                                item._rows_inserted = dr.GetInt32(0);
                                item._rows_skipped = dr.GetInt32(1);
                                item._row_errors = dr.GetInt32(2);
                                item._amount_inserted = dr.GetDecimal(3);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _InsertTempContractAdjustments(string ls_date, string ls_reason, string ls_value, string ls_contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "insert into rd.temp_Contract_Adjustments ( contract_no,ca_date_occured,ca_amount,ca_reason) " +
                        "values ( @ls_contract,@ls_date,@ls_value,@ls_reason)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ls_date", ls_date);
                    pList.Add(cm, "ls_reason", ls_reason);
                    pList.Add(cm, "ls_value", ls_value);
                    pList.Add(cm, "ls_contract", ls_contract);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _AddUsedPassword(string sOldPassword, int? ll_ui_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "INSERT INTO rd.used_password ( ui_id,up_password) VALUES ( @ll_ui_id,@sOldPassword)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "sOldPassword", sOldPassword);
                    pList.Add(cm, "ll_ui_id", ll_ui_id);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdatePassword(string ls_ui_userid, DateTime dExpiry, string sNewPassword)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "UPDATE rd.rds_user_id " +
                        "SET ui_password = @sNewPassword, ui_password_expiry = @dExpiry, ui_grace_logins = 4 " +
                        "WHERE ui_userid = @ls_ui_userid";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ls_ui_userid", ls_ui_userid);
                    pList.Add(cm, "dExpiry", dExpiry);
                    pList.Add(cm, "sNewPassword", sNewPassword);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetUpPassword(int ll_ui_id, string sNewPassword)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT up_password FROM rd.used_password WHERE ui_id = @ll_ui_id AND up_password = @sNewPassword";
                    pList.Add(cm, "ll_ui_id", ll_ui_id);
                    pList.Add(cm, "sNewPassword", sNewPassword);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                strVal = dr.GetString(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetUiid(string ls_ui_userid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT ui_id FROM rd.rds_user_id WHERE ui_userid = @ls_ui_userid";
                    pList.Add(cm, "ls_ui_userid", ls_ui_userid);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetMaxContractSeqNumber(int? li_contract_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int sequence = 0;
                    cm.CommandText = "select max(contract_seq_number) from rd.contract_renewals where contract_no = @li_contract_no";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "li_contract_no", li_contract_no);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetPieceRateDeliveryCount(int? lContract, int? lPRKey, DateTime? dPRDDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int sequence = 0;
                    cm.CommandText = "select count(prt_key) from rd.piece_rate_delivery where contract_no = @lContract and prt_key = @lPRKey and prd_date = @dPRDDate";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "lPRKey", lPRKey);
                    pList.Add(cm, "dPRDDate", dPRDDate);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetPrtKey(string sPRCode)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int sequence = 0;
                    cm.CommandText = "select prt_key from rd.piece_rate_type where prt_code = @sPRCode";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "sPRCode", sPRCode);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractNo(string sMSNumber)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int sequence = 0;
                    cm.CommandText = "select contract_no from rd.contract where con_old_mail_service_no = @sMSNumber";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "sMSNumber", sMSNumber);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetPostTaxDeductionsAppliedCount(int? lded)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int sequence = 0;
                    cm.CommandText = "SELECT count(odps.post_tax_deductions_applied.pcd_id  ) " +
                        "FROM odps.post_tax_deductions_applied " +
                        "WHERE odps.post_tax_deductions_applied.ded_id = @lded ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lded", lded);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetTop1PvtBagCount(int num, int? il_region)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int sequence = 0;
                    cm.CommandText = "select top 1 pvt_bag_count " +
                        "from rd.private_bags where pvt_frequency =@num and " +
                        "region_id = @il_region order by pvt_date desc";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "num", num);
                    if (il_region.HasValue)
                    {
                        pList.Add(cm, "il_region", il_region);
                    }
                    else
                    {
                        cm.CommandText = "select top 1 pvt_bag_count  " +
                            "from rd.private_bags where pvt_frequency =@num and " +
                            "region_id is null order by pvt_date desc";
                    }

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _InsertIntoPRivateBages(int num, int? ll_1, int? il_region)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "insert into rd.private_bags (pvt_frequency, pvt_bag_count, region_id) " +
                        "values (@num, @ll_1, @il_region)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "num", num);
                    pList.Add(cm, "ll_1", ll_1);
                    pList.Add(cm, "il_region", il_region);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetFirstRegionId(string ls_userid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select top 1 region_id " + 
                        " from rd.rds_user_rights rur, rd.rds_user_id_group rui, rd.rds_component rc, rd.rds_user_id rid " +
                        "where rc.rc_name = 'Private Bags' and rid.ui_userid = @ls_userid" +
                        "  and rui.ui_id = rid.ui_id and rur.ug_id = rui.ug_id " +
                        "  and rc.rc_id = rur.rc_id and rur.rur_read = 'Y' and rur.ug_id = rui.ug_id";

                    pList.Add(cm, "ls_userid", ls_userid);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }

                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetRegionId(string ls_userid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select ru.region_id " + 
                        " from rd.rds_user ru, rd.rds_user_id rui " +
                        "where rui.ui_userid = @ls_userid  and ru.u_id = rui.u_id";
                    pList.Add(cm, "ls_userid", ls_userid);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }

                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetBenchMarkCalcVeh2005(int? il_contract, int? il_sequence, int? li_newVehNo)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "il_contract", il_contract);
                    pList.Add(cm, "il_sequence", il_sequence);
                    pList.Add(cm, "li_newVehNo", li_newVehNo);
                    //cm.CommandText = "exec benchmarkCalcVeh2005  @il_contract, @il_sequence, @li_newVehNo ";
                    //using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    //{
                    //    if (dr.Read())
                    //    {
                    //        sequence = dr.GetInt32(0);
                    //        _sqlcode = 0;
                    //    }
                    //}

                    cm.CommandText = "select rd.benchmarkCalcVeh2005(@il_contract, @il_sequence, @li_newVehNo)";

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = System.Convert.ToInt32(dr.GetFloat(0));
                                _sqlcode = 0;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }

                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractorCount3(int? il_contract, int? il_sequence)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(*) FROM rd.contract WHERE contract_no = @il_contract AND con_active_sequence = @il_sequence";
                    pList.Add(cm, "il_contract", il_contract);
                    pList.Add(cm, "il_sequence", il_sequence);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqldbcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }

                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetVehicleList(string sRegNo)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT vehicle.vehicle_number, vehicle.vt_key, "
                                           + "vehicle.ft_key, vehicle.v_vehicle_make, "
                                           + "vehicle.v_vehicle_model,vehicle.v_vehicle_year, " 
                                           + "vehicle.v_vehicle_cc_rating, vehicle.v_road_user_charges_indicator, "
                                           + "vehicle.v_purchased_date, vehicle.v_purchase_value, "
                                           + "vehicle.v_leased, vehicle.v_vehicle_month "
                                      + "FROM rd.vehicle " 
                                     + "WHERE vehicle.v_vehicle_registration_number = @sRegNo ";

                    pList.Add(cm, "sRegNo", sRegNo);

                    _vehicleList = new List<VehicleItem>();
                    try
                    {
                        _sqlcode = 100;
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                VehicleItem rf = new VehicleItem();
                                _vehicleList.Add(rf);
                                rf.vehicle_number = dr.GetInt32(0);
                                rf.vt_key = dr.GetInt32(1);
                                rf.ft_key = dr.GetInt32(2);
                                rf.v_vehicle_make = dr.GetString(3);
                                rf.v_vehicle_model = dr.GetString(4);
                                rf.v_vehicle_year = dr.GetInt16(5);
                                rf.v_vehicle_cc_rating = dr.GetInt16(6);
                                rf.v_road_user_charges_indicator = dr.GetString(7);
                                rf.v_purchased_date = dr.GetDateTime(8);
                                rf.v_purchase_value = dr.GetInt32(9);
                                rf.v_leased = dr.GetString(10);
                                rf.v_vehicle_month = dr.GetInt16(11);
                                _sqlcode = 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractorCount2(int? lSupplier)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "Select count(*) From rd.contractor Where contractor_supplier_no = @lSupplier";
                    pList.Add(cm, "lSupplier", lSupplier);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                            _sqlcode = 0;
                        }
                        else
                            _sqldbcode = 100;
                    }

                    intVal = sequence;
                }
            }
        }

        //remarked by jlwang because of the same name who will use this sql satate pls check it.02/08/2007

        //[ServerMethod]
        //private void _GetContractorSupplierNoFormContractor(int? lSupplier)
        //{
        //    using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
        //    {
        //        using (DbCommand cm = cn.CreateCommand())
        //        {
        //            int sequence = 0;
        //            ParameterCollection pList = new ParameterCollection();
        //            cm.CommandText = "Select count ( *)  From contractor Where contractor_supplier_no = @lSupplier";
        //            pList.Add(cm, "lSupplier", lSupplier);

        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                if (dr.Read())
        //                {
        //                    sequence = dr.GetInt32(0);
        //                    _sqlcode = 0;
        //                }
        //            }
        //
        //            intVal = sequence;
        //        }
        //    }
        //}

        [ServerMethod]
        private void _GetContractorSupplierNoFormContractor(string sContractorName)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT contractor.contractor_supplier_no FROM rd.contractor " +
                        " WHERE (contractor.c_surname_company  + case when contractor.c_first_names is null then '' else ',' end +  case when contractor.c_first_names is null then '' else contractor.c_first_names end) = @sContractorName";
                    pList.Add(cm, "sContractorName", sContractorName);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                            _sqlcode = 0;
                        }
                        else
                            _sqldbcode = 100;

                    }

                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractorNameFormContractor(int? lContractor)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = string.Empty;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT contractor.c_surname_company  + case when contractor.c_first_names is null then '' else ',' end +  case when contractor.c_first_names is null then '' else contractor.c_first_names end    " +
                        " FROM rd.contractor WHERE contractor.contractor_supplier_no = @lContractor";
                    pList.Add(cm, "lContractor", lContractor);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetString(0);
                            _sqlcode = 0;
                        }
                        else
                            _sqldbcode = 100;
                    }

                    dataObject = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetConActiveSequenceFromContract(int? il_contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select con_active_sequence from rd.contract where contract_no = @il_contract";
                    pList.Add(cm, "il_contract", il_contract);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                            _sqlcode = 0;
                        }
                        else
                            _sqlcode = 100;
                    }

                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        // TJB  RD7_0051  Oct-2009
        // Added nContractNo, nContractSeqNumber parameters
        private void _GetNvrItemProcRatePerHrFromNonVehicleRate(int? lContractNo, int? lSeqNo, int? lRgCode, DateTime? dDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    /* -----------------------------------------------------------
                     * TJB  RD7_0051  Oct-2009
                     * * Original ignores override rate:
                     * cm.CommandText = "select non_vehicle_rate.nvr_item_proc_rate_per_hr" 
                     *                 + " from rd.non_vehicle_rate"
                     *                 + " where non_vehicle_rate.rg_code = @lRgCode"
                     *                 + " and non_vehicle_rate.nvr_rates_effective_date = @dDate";
                     * ----------------------------------------------------------- */
                    cm.CommandText = "select isnull(nvor_item_proc_rate_per_hour,nvr_item_proc_rate_per_hr) "
                                     + "from rd.non_vehicle_rate as nvr left outer join rd.non_vehicle_override_rate as nvor "
                                     + "        on nvor.contract_no = @lContractNo and "
                                     + "           nvor.contract_seq_number = @lSeqNo "
                                     + "where rg_code = @lRgCode"
                                     + "  and nvr_rates_effective_date = @dDate";

                    pList.Add(cm, "lContractNo", lContractNo);
                    pList.Add(cm, "lSeqNo", lSeqNo);
                    pList.Add(cm, "lRgCode", lRgCode);
                    pList.Add(cm, "dDate", dDate);
                    // TJB  RD7_0040  Aug2009
                    // Added try/catch; changed result cast to int16
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                //sequence = dr.GetInt32(0);
                                sequence = dr.GetInt16(0);
                                _sqlcode = 0;
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetLatestVehicleFormDummy(int? lContract, int? lSequence)
        {
            // TJB  RD7_0040  Aug2009    -- Added --
            // This routine was missieg!
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "declare @x int exec @x = rd.f_GetLatestVehicle @lContract, @lSequence select @x";

                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "lSequence", lSequence);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractorRenewalsCount2(int? lContract, int? lSequence)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select count(*) from rd.contractor_renewals " 
                                    + "where contract_no = @lContract and contract_seq_number = @lSequence";
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "lSequence", lSequence);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                            _sqlcode = 0;
                        }
                        else
                            _sqlcode = 100;
                    }

                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetConExpiryDateFromContractRenewals(int? lContract, int? lSequence)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select con_expiry_date from rd.contract_renewals " 
                                    + "where contract_no = @lContract and contract_seq_number = @lSequence";
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "lSequence", lSequence);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetDateTime(0);
                            _sqlcode = 0;
                        }
                        else
                            _sqlcode = 100;
                    }

                    dtVal = sequence;
                }
            }
        }

        // TJB RPCR_001 July-2010
        // Added lSafety, lEmissions, and lConsumption
        [ServerMethod]
        private void _UpdateVehicle(int? lVTKey, int? lFTKey, string sMake, string sModel, int? lYear, int? lMonth
                                   , string sRegistration, int? lCCRate, string sUserCharge, DateTime? dPurchase
                                   , int? lPurchase, string sLeased, string sTransmission, int? ll_VSKey
                                   , int? ll_remaining_economic_life, int? lSpeedoKms, DateTime? dSpeedoDate
                                   , int? ll_salvage, int? lSafety, int? lEmissions, int? lConsumption
                                   , int? lvehicleNumber)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "UPDATE rd.vehicle " 
                                      + "SET vt_key = @lVTKey, ft_key = @lFTKey, v_vehicle_make = @sMake, "
                                      + " v_vehicle_model = @sModel, v_vehicle_year = @lYear, "
                                      + " v_vehicle_month = @lmonth, v_vehicle_registration_number = @sRegistration, "
                                      + " v_vehicle_cc_rating = @lCCRate, v_road_user_charges_indicator = @sUserCharge, "
                                      + " v_purchased_date = @dPurchase, v_purchase_value = @lPurchase, "
                                      + " v_leased = @sLeased, v_vehicle_transmission = @sTransmission, "
                                      + " vs_key = @ll_VSKey, v_remaining_economic_life = @ll_remaining_economic_life, "
                                      + " v_vehicle_speedo_kms  = @lSpeedoKms, v_vehicle_speedo_date = @dSpeedoDate, "
                                      + " v_salvage_value = @ll_salvage, v_vehicle_safety = @lSafety, "
                                      + " v_vehicle_emissions = @lEmissions, v_vehicle_consumption_rate = @lConsumption "
                                      + "WHERE vehicle_number = @lVehicleNumber";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lvehicleNumber", lvehicleNumber);
                    pList.Add(cm, "lVTKey", lVTKey);
                    pList.Add(cm, "lFTKey", lFTKey);
                    pList.Add(cm, "sMake", sMake);
                    pList.Add(cm, "sModel", sModel);
                    pList.Add(cm, "lYear", lYear);
                    pList.Add(cm, "sRegistration", sRegistration);
                    pList.Add(cm, "lCCRate", lCCRate);
                    pList.Add(cm, "sUserCharge", sUserCharge);
                    pList.Add(cm, "dPurchase", dPurchase);
                    pList.Add(cm, "lPurchase", lPurchase);
                    pList.Add(cm, "sLeased", sLeased);
                    pList.Add(cm, "lMonth", lMonth);
                    pList.Add(cm, "sTransmission", sTransmission);
                    pList.Add(cm, "ll_VSKey", ll_VSKey);
                    pList.Add(cm, "ll_remaining_economic_life", ll_remaining_economic_life);
                    pList.Add(cm, "lSpeedoKms", lSpeedoKms);
                    pList.Add(cm, "dSpeedoDate", dSpeedoDate);
                    pList.Add(cm, "ll_salvage", ll_salvage);
                    pList.Add(cm, "lSafety", lSafety);
                    pList.Add(cm, "lEmissions", lEmissions);
                    pList.Add(cm, "lConsumption", lConsumption);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        // TJB RPCR_001 July-2010
        // Added lSafety, lEmissions, and lConsumption
        [ServerMethod]
        private void _InsertIntoVehicle(int? lvehicleNumber, int? lVTKey, int? lFTKey, string sMake, string sModel
                                       , int? lYear, string sRegistration, int? lCCRate, string sUserCharge
                                       , DateTime? dPurchase, int? lPurchase, string sLeased, int? lMonth
                                       , string sTransmission, int? ll_VSKey, int? ll_remaining_economic_life
                                       , int? lSpeedoKms, DateTime? dSpeedoDate, int? ll_salvage, int? lSafety
                                       , int? lEmissions, int? lConsumption)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "INSERT INTO rd.vehicle (" +
                        " vehicle_number, vt_key, ft_key, v_vehicle_make, v_vehicle_model, v_vehicle_year," +
                        " v_vehicle_registration_number, v_vehicle_cc_rating, v_road_user_charges_indicator," +
                        " v_purchased_date, v_purchase_value, v_leased, v_vehicle_month, v_vehicle_transmission," +
                        " vs_key, v_remaining_economic_life, v_vehicle_speedo_kms, v_vehicle_speedo_date," + 
                        " v_salvage_value, v_vehicle_safety, v_vehicle_emissions, v_vehicle_consumption_rate" + 
                        ")" +
                        " VALUES ("  +
                        " @lvehicleNumber, @lVTKey, @lFTKey, @sMake, @sModel, @lYear, @sRegistration," +
                        " @lCCRate, @sUserCharge, @dPurchase, @lPurchase, @sLeased , @lMonth, @sTransmission," +
                        " @ll_VSKey, @ll_remaining_economic_life, @lSpeedoKms, @dSpeedoDate, @ll_salvage, " + 
                        " @lSafety, @lEmissions, @lConsumption" +
                        ")";
                    ParameterCollection pList = new ParameterCollection();

                    pList.Add(cm, "lvehicleNumber", lvehicleNumber);
                    pList.Add(cm, "lVTKey", lVTKey);
                    pList.Add(cm, "lFTKey", lFTKey);
                    pList.Add(cm, "sMake", sMake);
                    pList.Add(cm, "sModel", sModel);
                    pList.Add(cm, "lYear", lYear);
                    pList.Add(cm, "sRegistration", sRegistration);
                    pList.Add(cm, "lCCRate", lCCRate);
                    pList.Add(cm, "sUserCharge", sUserCharge);
                    pList.Add(cm, "dPurchase", dPurchase);
                    pList.Add(cm, "lPurchase", lPurchase);
                    pList.Add(cm, "sLeased", sLeased);
                    pList.Add(cm, "lMonth", lMonth);
                    pList.Add(cm, "sTransmission", sTransmission);
                    pList.Add(cm, "ll_VSKey", ll_VSKey);
                    pList.Add(cm, "ll_remaining_economic_life", ll_remaining_economic_life);
                    pList.Add(cm, "lSpeedoKms", lSpeedoKms);
                    pList.Add(cm, "dSpeedoDate", dSpeedoDate);
                    pList.Add(cm, "ll_salvage", ll_salvage);
                    pList.Add(cm, "lSafety", lSafety);
                    pList.Add(cm, "lEmissions", lEmissions);
                    pList.Add(cm, "lConsumption", lConsumption);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetNvrForzenIndicatorFormNonVehicle(int? lRenewal)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = string.Empty;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select nvr_frozen_indicator " 
                        + " from rd.non_vehicle_rate " 
                        + "where rg_code = @lRenewal "
                        + "  and nvr_rates_effective_date = " 
                                         + "(select max(nvr_rates_effective_date)" 
                                         + "   from rd.non_vehicle_rate" 
                                         + "  where rg_code = @lRenewal)";
                    pList.Add(cm, "lRenewal", lRenewal);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetString(0);
                            _sqlcode = 0;
                        }
                        else
                            _sqlcode = 100;
                    }

                    dataObject = sequence;
                }
            }
        }

        [ServerMethod]
        private void _UpdateContractRenewals2(int? lContract, int? lSequence)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "UPDATE rd.contract_renewals " 
                        + "  SET con_renewal_payment_value = con_renewal_benchmark_price " 
                        + "WHERE contract_renewals.contract_no = @lContract " 
                        + "  AND contract_renewals.contract_seq_number = @lSequence";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "lSequence", lSequence);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateContractRenewals(int? lContract, int? lSequence)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "UPDATE rd.contract_renewals " 
                        + "  SET con_renewal_benchmark_price = rd.BenchmarkCalc2005(@lContract, @lSequence) " 
                        + "WHERE contract_no = @lContract " 
                        + "  AND contract_seq_number = @lSequence";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "lSequence", lSequence);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _InsertIntoContractRenewals(int? lcontract, int? lsequence, string sname, string saddr, string sphone)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "insert into rd.contract_renewals " +
                        " ( contract_no, contract_seq_number, con_relief_driver_name,con_relief_driver_address, con_relief_driver_home_phone)" +
                        " values( @lContract, @lSequence, @sname,@saddr, @sphone)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lContract", lcontract);
                    pList.Add(cm, "lSequence", lsequence);
                    pList.Add(cm, "sname", sname);
                    pList.Add(cm, "saddr", saddr);
                    pList.Add(cm, "sphone", sphone);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractRenewalsList(int? lcontract, int? lsequence)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT contract_renewals.con_relief_driver_name," +
                        "contract_renewals.con_relief_driver_address," +
                        "contract_renewals.con_relief_driver_home_phone " +
                        "FROM rd.contract_renewals " + 
                        "WHERE contract_renewals.contract_no = @lcontract " +
                        "AND contract_renewals.contract_seq_number = @lsequence";

                    pList.Add(cm, "lcontract", lcontract);
                    pList.Add(cm, "lsequence", lsequence);
                    _contractRenewalsList = new List<ContractRenewalsItem>();
                    try
                    {
                        _sqlcode = 100;
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                ContractRenewalsItem rf = new ContractRenewalsItem();
                                _contractRenewalsList.Add(rf);
                                rf.con_relief_driver_name = dr.GetString(0);
                                rf.con_relief_driver_address = dr.GetString(1);
                                rf.con_relief_driver_home_phone = dr.GetString(2);
                                _sqlcode = 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetConDateTerminatedFromContract(int? lContract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT contract.con_date_terminated FROM rd.contract WHERE contract.contract_no = @lContract  ";
                    pList.Add(cm, "lContract", lContract);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                //!sequence = dr.GetDateTime(0);
                                sequence = (DateTime?)(dr.GetValue(0));

                                _sqlcode = 0;
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetRouteAuditCount(DateTime? dtCheck, int? ll_Contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select count(*) from rd.route_audit where ra_date_of_check = @dtCheck and contract_no = @ll_Contract ";
                    pList.Add(cm, "dtCheck", dtCheck);
                    pList.Add(cm, "ll_Contract", ll_Contract);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _UpdateContract2(DateTime? checkdate, int ilcontract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "UPDATE rd.contract SET con_last_work_msrmnt_check = @checkdate WHERE contract.contract_no = @ilcontract";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "checkdate", checkdate);
                    pList.Add(cm, "ilcontract", ilcontract);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        dataObject = e.Message.ToString();
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateContract(DateTime? checkdate, int ilcontract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "UPDATE rd.contract SET con_last_delivery_check = @checkdate WHERE contract.contract_no = @ilcontract";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "checkdate", checkdate);
                    pList.Add(cm, "ilcontract", ilcontract);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        dataObject = e.Message.ToString();
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdatePrintedon(int? lCustID)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "UPDATE rd.rds_customer SET printedon = getdate() WHERE cust_id = @lCustId ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lCustId", lCustID);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                    }
                    catch (Exception e)
                    {
                        dataObject = e.Message.ToString();
                        ret = false;
                    }
                }
            }
            ret = true;
        }

        [ServerMethod]
        private void _UpdateRdsCustomerPrintedon(int lcust)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "UPDATE rd.rds_customer SET printedon = getdate() WHERE customer.cust_id = @lcust ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lcust", lcust);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateRdContract()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "UPDATE rd.contract SET cust_list_printed = getdate() where contract_no in (select rds_id from rds_temp) ";
                    ParameterCollection pList = new ParameterCollection();
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _SelectAddressCount(int? ll_addressID)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select count(*) from rd.address where adr_id = @ll_addressID";
                    pList.Add(cm, "ll_addressID", ll_addressID);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _UpdateArticalCountValue(decimal? decScalingFactor, DateTime? dDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "UPDATE rd.artical_count SET ac_scale_factor = @decScalingFactor  " +
                        "WHERE artical_count.ac_start_week_period = @dDate  " +
                        "AND artical_count.contract_seq_number is null ";

                    pList.Add(cm, "decScalingFactor", decScalingFactor);
                    pList.Add(cm, "dDate", dDate);
                    SQLNRows = DBHelper.ExecuteNonQuery(cm, pList);
                }
            }
        }

        [ServerMethod]
        private void _UpdateArticalCountValue2(decimal? decScalingFactor, DateTime? dDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "UPDATE rd.artical_count SET ac_scale_factor = @decScalingFactor  " +
                        "WHERE artical_count.ac_start_week_period = @dDate  " +
                        "AND ac_scale_factor is null AND contract_seq_number is null;  ";

                    pList.Add(cm, "decScalingFactor", decScalingFactor);
                    pList.Add(cm, "dDate", dDate);
                    SQLNRows = DBHelper.ExecuteNonQuery(cm, pList);
                }
            }
        }

        [ServerMethod]
        private void _GetNonVehicleRateCount(int? ll_rgCode, DateTime? ld_EffDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(*) FROM rd.non_vehicle_rate " +
                        "WHERE rg_code = @ll_rgCode AND " +
                        "nvr_rates_effective_date > @ld_EffDate";

                    pList.Add(cm, "ll_rgCode", ll_rgCode);
                    pList.Add(cm, "ld_EffDate", ld_EffDate);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetOutlet(string sOutlet)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select outlet_id from rd.outlet where o_name = @sOutlet ";
                    pList.Add(cm, "sOutlet", sOutlet);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetNonVehicleRateCount2(int? ll_rgCode)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(*) FROM rd.non_vehicle_rate " +
                        "WHERE rg_code = @ll_rgcode AND " +
                        "(nvr_frozen_indicator = 'N' or nvr_frozen_indicator is null)";

                    pList.Add(cm, "ll_rgCode", ll_rgCode);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetTowncityLlTcId(string ls_town)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select min(tc_id) from rd.towncity  " +
                        "where towncity.tc_name = @ls_town";
                    pList.Add(cm, "ls_town", ls_town);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetNonVehicleRateCount3(int? ll_rgCode, DateTime? ld_EffDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(*) FROM rd.non_vehicle_rate " +
                        "WHERE non_vehicle_rate.rg_code = @ll_rgcode AND " +
                        "non_vehicle_rate.nvr_rates_effective_date = @ld_EffDate ";
                    pList.Add(cm, "ll_rgCode", ll_rgCode);
                    pList.Add(cm, "ld_EffDate", ld_EffDate);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetNonVehicleRateVehicleRateCount(DateTime? id_renewaldate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(non_vehicle_rate.rg_code) FROM rd.non_vehicle_rate,vehicle_rate " +
                        "WHERE non_vehicle_rate.nvr_rates_effective_date = vehicle_rate.vr_rates_effective_date  and  " +
                        "(non_vehicle_rate.nvr_frozen_indicator is null OR non_vehicle_rate.nvr_frozen_indicator = 'N' ) " +
                        "and vehicle_rate.vr_rates_effective_date = @id_renewaldate ";

                    pList.Add(cm, "id_renewaldate", id_renewaldate);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetVehicleRateMax(int? ll_vtKey)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime sequence = DateTime.MinValue;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT max(vr_rates_effective_date) FROM rd.vehicle_rate WHERE  vt_key = @ll_vtKey; ";
                    pList.Add(cm, "ll_vtKey", ll_vtKey);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetDateTime(0);
                        }
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetLdConActioned(int? ll_selected_contracts)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime sequence = DateTime.MinValue;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select cust_list_updated from rd.contract  " +
                        "where contract_no = @ll_selected_contracts and " +
                        "cust_list_updated is not null ";
                    pList.Add(cm, "ll_selected_contracts", ll_selected_contracts);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetDateTime(0);
                        }
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _InsertRdsTemp(int ll_selected_contracts, int? ll_recip)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "insert into rd.rds_temp (rds_id, rds_code) " +
                        "values (@ll_selected_contracts, @ll_recip)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ll_selected_contracts", ll_selected_contracts);
                    pList.Add(cm, "ll_recip", ll_recip);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
        }

        [ServerMethod]
        private void _ComplexSqlState(DateTime? id_renewaldate, int? il_rg_code)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tran = cn.BeginTransaction())
                {
                    using (DbCommand cm = cn.CreateCommand())
                    {
                        cm.Transaction = tran;
                        string str = "";
                        ParameterCollection pList = new ParameterCollection();
                        cm.CommandText = "DELETE FROM rd.non_vehicle_rate " +
                            "WHERE non_vehicle_rate.nvr_rates_effective_date =@id_renewaldate AND " +
                            "non_vehicle_rate.rg_code = @il_rg_code";
                        pList.Add(cm, "id_renewaldate", id_renewaldate);
                        pList.Add(cm, "il_rg_code", il_rg_code);

                        try
                        {
                            DBHelper.ExecuteNonQuery(cm, pList);
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            _sqlerrtext = ex.Message + ",Delete Non-Vehicle Rates Error";
                            return;
                        }
                        pList.Clear();
                        cm.CommandText = "DELETE FROM rd.piece_rate WHERE piece_rate.pr_effective_date = @id_renewaldate AND " +
                            "piece_rate.rg_code =  @il_rg_code";
                        pList.Add(cm, "id_renewaldate", id_renewaldate);
                        pList.Add(cm, "il_rg_code", il_rg_code);

                        try
                        {
                            DBHelper.ExecuteNonQuery(cm, pList);
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            _sqlerrtext = ex.Message + ",Delete Piece Rates Error";
                            return;
                        }

                        pList.Clear();
                        cm.CommandText = "DELETE FROM rd.fuel_rates WHERE fuel_rates.rg_code = @il_rg_code AND " +
                            "fuel_rates.rr_rates_effective_date = @id_renewaldate";

                        pList.Add(cm, "il_rg_code", il_rg_code);
                        pList.Add(cm, "id_renewaldate", id_renewaldate);
                        try
                        {
                            DBHelper.ExecuteNonQuery(cm, pList);
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            _sqlerrtext = ex.Message + ",Delete Fuel Rates Error";
                            return;
                        }

                        pList.Clear();
                        cm.CommandText = "DELETE FROM rd.rate_days WHERE rate_days.rg_code =@il_rg_code  AND " +
                            "rate_days.rr_rates_effective_date = @id_renewaldate";
                        pList.Add(cm, "il_rg_code", il_rg_code);
                        pList.Add(cm, "id_renewaldate", id_renewaldate);

                        try
                        {
                            DBHelper.ExecuteNonQuery(cm, pList);
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            _sqlerrtext = ex.Message + ",Delete Rate Days Error";
                            return;
                        }

                        pList.Clear();
                        cm.CommandText = "DELETE FROM rd.misc_rate WHERE misc_rate.rg_code = @il_rg_code  AND  " +
                            "misc_rate.mr_effective_date =@id_renewaldate ";
                        pList.Add(cm, "il_rg_code", il_rg_code);
                        pList.Add(cm, "id_renewaldate", id_renewaldate);

                        try
                        {
                            DBHelper.ExecuteNonQuery(cm, pList);
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            _sqlerrtext = ex.Message + ",Delete Other Rates Error";
                            return;
                        }
                        pList.Clear();
                        cm.CommandText = " DELETE FROM rd.vehicle_rate WHERE vr_rates_effective_date = @id_renewaldate ";
                        pList.Add(cm, "id_renewaldate", id_renewaldate);
                        try
                        {
                            DBHelper.ExecuteNonQuery(cm, pList);
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            _sqlerrtext = ex.Message + ",Delete Vehicle Rate Error";
                            return;
                        }
                        tran.Commit();
                        _sqlerrtext = "";
                        return;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetNonVehicleRateMax(int? il_rg_code)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT max(nvr_rates_effective_date) FROM rd.non_vehicle_rate WHERE rg_code = @il_rg_code;";
                    pList.Add(cm, "il_rg_code", il_rg_code);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetDateTime(0);
                        }
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetNonVehicleRateValue(int? il_rg_code, DateTime? ld_Max_Effective_Date)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT nvr_contract_end FROM rd.non_vehicle_rate WHERE rg_code = @il_rg_code AND " +
                        "nvr_rates_effective_date = @ld_Max_Effective_Date";

                    pList.Add(cm, "il_rg_code", il_rg_code);
                    pList.Add(cm, "ld_Max_Effective_Date", ld_Max_Effective_Date);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetDateTime(0);
                        }
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetFuelRatesMax(int? il_rg_code)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT max(rr_rates_effective_date) FROM rd.Fuel_rates where rg_code = @il_rg_code";
                    pList.Add(cm, "il_rg_code", il_rg_code);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetDateTime(0);
                                _sqlcode = 0;
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetPieceRateMax(int? il_rg_code)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT max(pr_effective_date) FROM rd.piece_rate WHERE rg_code = @il_rg_code;";
                    pList.Add(cm, "il_rg_code", il_rg_code);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _sqlcode = 0;
                                sequence = dr.GetDateTime(0);
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetRateDaysMax(int? il_rg_code)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT max(rr_rates_effective_date) FROM rd.rate_days WHERE rg_code =@il_rg_code";
                    pList.Add(cm, "il_rg_code", il_rg_code);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _sqlcode = 0;
                                sequence = dr.GetDateTime(0);
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetMiscRateMax(int? il_rg_code)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT max(mr_effective_date) FROM rd.misc_rate WHERE rg_code = @il_rg_code";
                    pList.Add(cm, "il_rg_code", il_rg_code);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _sqlcode = 0;
                                sequence = dr.GetDateTime(0);
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetFuelTypeFuelRatesCount(DateTime? ld_Date, int? ll_RGCode)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = "select count(*) from rd.fuel_type, rd.fuel_rates " +
                        " where fuel_type.ft_key = fuel_rates.ft_key and fuel_rates.rr_rates_effective_date = @ld_Date " +
                        " and fuel_rates.rg_code = @ll_RGCode and (fuel_rates.fr_fuel_rate is null or fuel_rates.fr_fuel_consumtion_rate is null)";

                    pList.Add(cm, "ld_Date", ld_Date);
                    pList.Add(cm, "ll_RGCode", ll_RGCode);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetStandardFrequencyRateDaysCount(DateTime? ld_Date, int? ll_RGCode)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = " select count(*) from rd.standard_frequency, rd.rate_days " +
                        "where standard_frequency.sf_key = rate_days.sf_key and " +
                        "rate_days.rr_rates_effective_date = @ld_Date and rate_days.rg_code = @ll_RGCode and " +
                        "rate_days.rtd_days_per_annum is null";

                    pList.Add(cm, "ld_Date", ld_Date);
                    pList.Add(cm, "ll_RGCode", ll_RGCode);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetPieceRateCount(DateTime? ld_Date, int? ll_RGCode)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = "SELECT count(*) FROM rd.piece_rate WHERE piece_rate.pr_effective_date = @ld_Date AND " +
                        "piece_rate.rg_code = @ll_RGCode AND pr_active_status = 'Y' AND pr_rate is null ";

                    pList.Add(cm, "ld_Date", ld_Date);
                    pList.Add(cm, "ll_RGCode", ll_RGCode);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetVehicleTypeCount()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = "SELECT count(*) FROM rd.vehicle_type ";

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetVehicleRateCount(DateTime? ld_Date)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = " SELECT count(vehicle_rate.vt_key) FROM rd.vehicle_rate " +
                        "WHERE vehicle_rate.vr_rates_effective_date = @ld_Date  AND  " +
                        "vehicle_rate.vr_nominal_vehicle_value is not null  AND " +
                        "vehicle_rate.vr_repairs_maintenance_rate is not null AND " +
                        "vehicle_rate.vr_tyre_tubes_rate is not null AND " +
                        "vehicle_rate.vr_vehicle_allowance_rate is not null AND " +
                        "vehicle_rate.vr_licence_rate is not null AND " +
                        "vehicle_rate.vr_vehicle_rate_of_return_pct is not null AND " +
                        "vehicle_rate.vr_salvage_ratio is not null AND vehicle_rate.vr_ruc is not null AND " +
                        "vehicle_rate.vr_sundries_k is not null AND vehicle_rate.vr_vehicle_value_insurance_pct is not null";

                    pList.Add(cm, "ld_Date", ld_Date);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractAllownceMaxCaEffective(int? il_contract, int? ll_altkey)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select max(ca_effective_date) from rd.contract_allowance " +
                        "where contract_no = @il_contract and alt_key = @ll_altkey";
                    pList.Add(cm, "il_contract", il_contract);
                    pList.Add(cm, "ll_altkey", ll_altkey);
                    _sqlcode = -1;
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                if (dr[0] == null)
                                {
                                    sequence = null;
                                }
                                else
                                {
                                    sequence = dr.GetDateTime(0);
                                }
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _UpdateArticalCountContractSeqNumber(int? lContract, int? lrenewal)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "UPDATE rd.artical_count set contract_seq_number = null " +
                        "where contract_no = @lContract and contract_seq_number = @lrenewal";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "lrenewal", lrenewal);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateCustListPrinted(int? il_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "UPDATE rd.contract set cust_list_printed = getdate() where contract_no = @il_id";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "il_id", il_id);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetArticalCountConut(int? lContract, DateTime? ldt_YearAgo)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select count(artical_count.contract_no) from rd.artical_count " +
                        "where artical_count.contract_no = @lContract  and " +
                        "artical_count.contract_seq_number is null and " +
                        "artical_count.ac_start_week_period > @ldt_YearAgo";

                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "ldt_YearAgo", ldt_YearAgo);
                    _sqlcode = -1;
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence.GetValueOrDefault();
                }
            }
        }

        [ServerMethod]
        private void _GetAddrTcId(int? il_long_parm)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select count(*) " +
                                   " from rd.address addr " +
                                  " where addr.tc_id = @il_long_parm";
                    pList.Add(cm, "il_long_parm", il_long_parm);
                    _sqlcode = -1;
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetAddrContractNo(int? il_long_parm)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select count(*) " +
                                   " from rd.address addr " +
                                  " where addr.contract_no = @il_long_parm";
                    pList.Add(cm, "il_long_parm", il_long_parm);
                    _sqlcode = -1;
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence.GetValueOrDefault();
                }
            }
        }

        [ServerMethod]
        private void _GetContractRenewalsConStartDate1(int? lContract, int? lrenewal)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select con_start_date from rd.contract_renewals " +
                        "where contract_renewals.contract_no = @lContract and " +
                        "contract_renewals.contract_seq_number = @lrenewal - 1;";
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "lrenewal", lrenewal);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetDateTime(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractRenewalsConVolumeAtRenewal(DateTime? dStartDate, int? lContract, int? lrenewal)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select contract_renewals.con_volume_at_renewal + sum(isnull(frequency_distances.fd_volume,0)) "
                                     + "from rd.contract_renewals, "
                                          + "rd.route_frequency left outer join rd.frequency_distances " 
                                     +           "on route_frequency.contract_no = frequency_distances.contract_no and " 
                                     +              "route_frequency.sf_key = frequency_distances.sf_key and " 
                                     +              "route_frequency.rf_delivery_days = frequency_distances.rf_delivery_days and " 
                                     +              "frequency_distances.fd_effective_date>= @dStartDate "
                                     +    ", rd.rate_days "
                                     + "where contract_renewals.contract_no = route_frequency.contract_no and "
                                     +       "route_frequency.sf_key = rate_days.sf_key and "
                                     +       "contract_renewals.con_rates_effective_date = rate_days.rr_rates_effective_date and "
                                     +       "contract_renewals.con_rg_code_at_renewal = rate_days.rg_code and "
                                     +       "contract_renewals.contract_no = @lContract and " 
                                     +       "contract_renewals.contract_seq_number = (@lrenewal - 1) "
                                     + "group by contract_renewals.contract_no, contract_renewals.con_volume_at_renewal";
                    pList.Add(cm, "dStartDate", dStartDate);
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "lrenewal", lrenewal);
                    _sqlcode = -1;
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                // 21-Jul-2008  Metex Renewals fix2
                                // sequence = dr.GetInt32(0);
                                sequence = (int?)dr.GetDecimal(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence.GetValueOrDefault();
                }
            }
        }

        [ServerMethod]
        private void _UpdateContractRenewalsConVolumeAtRenewal(int? lVolAtRen, int? lContract, int? lrenewal)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "UPDATE rd.contract_renewals set con_volume_at_renewal = @lVolAtRen " 
                                     + "where contract_no = @lContract and contract_seq_number = @lrenewal";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lVolAtRen", lVolAtRen);
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "lrenewal", lrenewal);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateArticalCountContractSeqNumber1(int? lrenewal, int? lContract, DateTime? ldt_YearAgo)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "UPDATE rd.artical_count " 
                                     +  "set contract_seq_number = @lrenewal " 
                                     + "where contract_no = @lContract and " 
                                     +       "contract_seq_number is null and " 
                                     +       "artical_count.ac_start_week_period > @ldt_YearAgo";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lrenewal", lrenewal);
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "ldt_YearAgo", ldt_YearAgo);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateArticalCountContractSeqNumber21(int? lrenewal, int? lContract, DateTime? ldt_YearAgo)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "UPDATE rd.artical_count set contract_seq_number=@lrenewal " +
                        "where contract_no=@lContract and (contract_seq_number is null or contract_seq_number=@lrenewal) " +
                        "and ac_start_week_period = (select max(ac_start_week_period) from rd.artical_count as a2 where a2.contract_no = @lContract and ( contract_seq_number is null or contract_seq_number = @lrenewal) and  ac_start_week_period > @ldt_YearAgo)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lrenewal", lrenewal);
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "ldt_YearAgo", ldt_YearAgo);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractRenewalsConStartDate(int? lContract, int? lrenewal, DateTime? ldt_YearAgo)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select max(ac_start_week_period) from rd.artical_count as a2 " +
                        "where a2.contract_no = @lContract and  " +
                        "(contract_seq_number is null or contract_seq_number = @lrenewal) and " +
                        "ac_start_week_period > @ldt_YearAgo";

                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "lrenewal", lrenewal);
                    pList.Add(cm, "ldt_YearAgo", ldt_YearAgo);
                    _sqlcode = -1;
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetDateTime(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetRouteFrequencyList(int ll_Contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = "SELECT route_frequency.sf_key, " +
                        "route_frequency.rf_delivery_days, " +
                        "route_frequency.rf_distance " +
                        "FROM rd.route_frequency " +
                        "WHERE route_frequency.rf_active = 'Y' AND " +
                        "route_frequency.contract_no = @ll_Contract";

                    pList.Add(cm, "ll_Contract", ll_Contract);
                    _routeFrequencyList = new List<RouteFrequencyItem>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                RouteFrequencyItem rf = new RouteFrequencyItem();
                                _routeFrequencyList.Add(rf);
                                rf._sf_key = dr.GetInt32(0);
                                rf._rf_delivery_days = dr.GetString(1);
                                rf._rf_distance = dr.GetDecimal(2);
                                _sqlcode = 0;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetRateDaysValue(int il_RGCode, DateTime ld_EffectDate, int ll_SfKey)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = "select rtd_days_per_annum from rd.rate_days " +
                        "where rg_code = @il_RGCode and " +
                        "rr_rates_effective_date = @ld_EffectDate and " +
                        "sf_key = @ll_SfKey ";

                    pList.Add(cm, "il_RGCode", il_RGCode);
                    pList.Add(cm, "ld_EffectDate", ld_EffectDate);
                    pList.Add(cm, "ll_SfKey", ll_SfKey);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetVehicleTypeList()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = "SELECT vt_key, vt_description FROM rd.vehicle_type ";
                    // union SELECT  vt_key, vt_description FROM vehicle_type where vt_key = 1
                    // union SELECT  vt_key, vt_description FROM vehicle_type where vt_key not in  ( 1, 2);";

                    _vehicleTypeList = new List<VehicleTypeItem>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            VehicleTypeItem vt = new VehicleTypeItem();
                            _vehicleTypeList.Add(vt);
                            vt._vt_key = dr.GetInt32(0);
                            vt._vt_description = dr.GetString(1);
                        }
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateArticalCountContractSeqNumber3(int? lrenewal, int? lContract, DateTime? ldt_YearAgo, DateTime? ldt_LastCountDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "UPDATE rd.artical_count set contract_seq_number=@lrenewal " +
                        "where contract_no=@lContract and (contract_seq_number is null or contract_seq_number=@lrenewal) " +
                        "and ac_start_week_period = (select max(ac_start_week_period) from rd.artical_count as a2 where a2.contract_no = @lContract and ( contract_seq_number is null or contract_seq_number = @lrenewal) " +
                        "and  ac_start_week_period > @ldt_YearAgo and  ac_start_week_period < @ldt_LastCountDate)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lrenewal", lrenewal);
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "ldt_YearAgo", ldt_YearAgo);
                    pList.Add(cm, "ldt_LastCountDate", ldt_LastCountDate);

                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetCmbAddressCmbIdFirst(int? il_contract, int? ll_pcid, string ls_box_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select top 1 cmb_id "
                                   +   "from rd.cmb_address "
                                   +  "where contract_no = @il_contract "
                                   +    "and post_code_id = @ll_pcid "
                                   +    "and cmb_box_no = @ls_box_no";

                    pList.Add(cm, "il_contract", il_contract);
                    pList.Add(cm, "ll_pcid", ll_pcid);
                    pList.Add(cm, "ls_box_no", ls_box_no);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                            }
                            else
                            {
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    intVal = sequence.GetValueOrDefault();
                }
            }
        }

        [ServerMethod]
        private void _GetCmbAddressCmbIdFirst1(int? il_contract, int? ll_pcid, string ls_box_no, int? ll_cmb_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select top 1 cmb_id "
                                   +   "from rd.cmb_address " 
                                   +  "where contract_no = @il_contract "
                                   +    "and post_code_id = @ll_pcid "
                                   +    "and cmb_box_no = @ls_box_no "
                                   +    "and not cmb_id = @ll_cmb_id";
                    pList.Add(cm, "il_contract", il_contract);
                    pList.Add(cm, "ll_pcid", ll_pcid);
                    pList.Add(cm, "ls_box_no", ls_box_no);
                    pList.Add(cm, "ll_cmb_id", ll_cmb_id);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                            }
                            else
                            {
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    intVal = sequence.GetValueOrDefault();
                }
            }
        }

        [ServerMethod]
        private void _GetAddressAdrRdNoFirst(int? al_contract, int? al_pcid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select top 1 adr_rd_no "
                                   +   "from rd.address "
                                   +  "where contract_no = @al_contract "
                                   +    "and post_code_id = @al_pcid";
                    pList.Add(cm, "al_contract", al_contract);
                    pList.Add(cm, "al_pcid", al_pcid);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                            }
                            else
                            {
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    intVal = sequence.GetValueOrDefault();
                }
            }
        }

        [ServerMethod]
        private void _GetRegion(int? ll_regionId)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = string.Empty;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT rgn_name FROM rd.region WHERE region_id = @ll_regionId";
                    pList.Add(cm, "ll_regionId", ll_regionId);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetString(0);
                            }
                            else
                            {
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    strVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetOutletId(int? lOutlet)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = string.Empty;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT outlet.o_name FROM rd.outlet WHERE outlet.outlet_id = @lOutlet";
                    pList.Add(cm, "lOutlet", lOutlet);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetString(0);
                            }
                            else
                            {
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    strVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetCtKey(int? lContractType)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = string.Empty;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT contract_type.contract_type " + 
                                       "FROM rd.contract_type " 
                                    + "WHERE contract_type.ct_key = @lContractType";
                    pList.Add(cm, "lContractType", lContractType);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetString(0);
                            }
                            else
                            {
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    strVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetRenewalGroup(int? ll_rgCode)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = string.Empty;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT rg_description FROM rd.renewal_group WHERE rg_code = @ll_rgCode";
                    pList.Add(cm, "ll_rgCode", ll_rgCode);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetString(0);
                            }
                            else
                            {
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    strVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractType(int? ll_ctKey)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = string.Empty;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT contract_type FROM rd.contract_type WHERE ct_key = @ll_ctKey;";
                    pList.Add(cm, "ll_ctKey", ll_ctKey);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetString(0);
                            }
                            else
                            {
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    strVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetTowncityTcName(int? al_tcid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select tc_name from rd.towncity where tc_id = @al_tcid;";
                    pList.Add(cm, "al_tcid", al_tcid);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetString(0);
                            }
                            else
                            {
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    dataObject = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetPostCodePostCode(int? al_pcid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select post_code "
                                   +   "from rd.post_code " 
                                   +  "where post_code_id = @al_pcid;";
                    pList.Add(cm, "al_pcid", al_pcid);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetString(0);
                            }
                            else
                            {
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    dataObject = sequence;
                }
            }
        }

        // TJB  RD7_CR001 Nov-2009:  Added
        // Based on _GetPostCodePostCode
        [ServerMethod]
        private void _GetPostCodeContractNo(string as_postcode)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    //string sequence = null;
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select contract_no "
                                   +   "from rd.post_code " 
                                   +  "where post_code = @as_postcode;";
                    pList.Add(cm, "as_postcode", as_postcode);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                //sequence = dr.GetString(0);
                                sequence = dr.GetInt32(0);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    //dataObject = sequence;
                    intVal = sequence;
                    ;
                }
            }
        }

        [ServerMethod]
        private void _GetMoreValues1(int ll_vtkey, DateTime id_effectdate, int il_rgcode)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = "SELECT vr_nominal_vehicle_value, vr_repairs_maintenance_rate, vr_tyre_tubes_rate, " +
                        " vr_vehicle_allowance_rate, vr_licence_rate, vr_vehicle_rate_of_return_pct," +
                        " vr_salvage_ratio, vr_ruc, vr_sundries_k, " +
                        " vr_vehicle_value_insurance_pct,vr_livery, nvr_vehicle_insurance_base_premium" +
                        " FROM rd.vehicle_rate, rd.non_vehicle_rate " +
                        " WHERE vt_key = @ll_vtkey AND vr_rates_effective_date = @id_effectdate " +
                        " AND non_vehicle_rate.nvr_rates_effective_date  = vehicle_rate.vr_rates_effective_date " +
                        " AND non_vehicle_rate.rg_code = @il_rgcode ";

                    pList.Add(cm, "ll_vtkey", ll_vtkey);
                    pList.Add(cm, "id_effectdate", id_effectdate);
                    pList.Add(cm, "il_rgcode", il_rgcode);

                    _vehicleRateNonVehicleRateList = new List<VehicleRateNonVehicleRateItem>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            VehicleRateNonVehicleRateItem vt = new VehicleRateNonVehicleRateItem();
                            _vehicleRateNonVehicleRateList.Add(vt);

                            vt.vr_nominal_vehicle_value = dr.GetDecimal(0);
                            vt.vr_repairs_maintenance_rate = dr.GetDecimal(1);
                            vt.vr_tyre_tubes_rate = dr.GetDecimal(2);
                            vt.vr_vehicle_allowance_rate = dr.GetDecimal(3);
                            vt.vr_licence_rate = dr.GetDecimal(4);
                            vt.vr_vehicle_rate_of_return_pct = dr.GetDecimal(5);

                            vt.vr_salvage_ratio = dr.GetDecimal(6);
                            vt.vr_ruc = dr.GetDecimal(7);
                            vt.vr_sundries_k = dr.GetDecimal(8);
                            vt.vr_vehicle_value_insurance_pct = dr.GetDecimal(9);
                            vt.vr_livery = dr.GetDecimal(10);
                            vt.nvr_vehicle_insurance_base_premium = dr.GetDecimal(11);

                        }
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetVehicleOverrideRateList(int? il_contract, int? il_sequence)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = "  SELECT top 1 vor_nominal_vehicle_value ,vor_repairs_maintenance_rate ,vor_tyre_tubes_rate,vor_vehical_allowance_rate ," +
                        "vor_licence_rate ,vor_vehicle_rate_of_return_pct ,vor_salvage_ratio ,vor_ruc ," +
                        "vor_sundries_k ,vor_vehicle_insurance_premium ,vor_livery " +
                        " FROM rd.vehicle_override_rate " +
                        " WHERE contract_no = @il_contract and contract_seq_number = @il_sequence " +
                        " order by vor_effective_date desc; ";
                    pList.Add(cm, "il_contract", il_contract);
                    pList.Add(cm, "il_sequence", il_sequence);

                    _vehicleOverrideRateList = new List<VehicleOverrideRateItem>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            VehicleOverrideRateItem vt = new VehicleOverrideRateItem();
                            _vehicleOverrideRateList.Add(vt);

                            vt.vor_nominal_vehicle_value = dr.GetDecimal(0);
                            vt.vor_repairs_maintenance_rate = dr.GetDecimal(1);
                            vt.vor_tyre_tubes_rate = dr.GetDecimal(2);
                            vt.vor_vehical_allowance_rate = dr.GetDecimal(3);
                            vt.vor_licence_rate = dr.GetDecimal(4);
                            vt.vor_vehicle_rate_of_return_pct = dr.GetDecimal(5);
                            vt.vor_salvage_ratio = dr.GetDecimal(6);
                            vt.vor_ruc = dr.GetDecimal(7);
                            vt.vor_sundries_k = dr.GetDecimal(8);
                            vt.vor_vehicle_insurance_premium = dr.GetDecimal(9);
                            vt.vor_livery = dr.GetDecimal(10);
                        }
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractorCount(string sSurname, string sFirstName)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(*) FROM rd.contractor " +
                        "WHERE	Upper(c_surname_company) = @sSurname AND	" +
                        "( @sFirstName IS NULL OR Upper(c_first_names) = @sFirstName)";
                    pList.Add(cm, "sSurname", sSurname);
                    pList.Add(cm, "sFirstName", sFirstName);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence.GetValueOrDefault();
                }
            }
        }

        [ServerMethod]
        private void _UpdateArticalCountContractSeqNumber2(int? lrenewal, int? lContract, DateTime? ldt_YearAgo, DateTime? ldt_LastCountDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = " UPDATE rd.artical_count set contract_seq_number=@lrenewal  " +
                                     " where contract_no=@lContract and " +
                                     " (contract_seq_number is null  or contract_seq_number=@lrenewal) and " +
                                     " ac_start_week_period = (select max(ac_start_week_period) from rd.artical_count as a2 " +
                                                               "where  a2.contract_no = @lContract and " + 
                                                                      "(contract_seq_number is null or contract_seq_number = @lrenewal) and " + 
                                                                      "ac_start_week_period > @ldt_YearAgo and " + 
                                                                      "ac_start_week_period @ldt_LastCountDate)";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lrenewal", lrenewal);
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "ldt_YearAgo", ldt_YearAgo);
                    pList.Add(cm, "ldt_LastCountDate", ldt_LastCountDate);

                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetLlNumDispatchesInfo(int lContract, int lSequence)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select count(mail_carried.mc_dispatch_carried) " +
                                    " from rd.contract " +
                                       " , rd.outlet " +
                                       " , rd.contract_renewals " +
                                       " , rd.mail_carried " +
                                    " where contract.contract_no = @lContract " +
                                      " and contract.con_base_office=outlet.outlet_id " +
                                      " and (contract.contract_no=contract_renewals.contract_no " +
                                      " and contract_renewals.contract_seq_number= @lSequence) " +
                                      " and (contract.contract_no=mail_carried.contract_no " +
                                      " and mail_carried.mc_disbanded_date is null)";
                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "lSequence", lSequence);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractorRenewalsCount(int? ll_Region, int? ii_contractor)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "Select count(*) From rd.contractor_renewals cr, rd.contract c, rd.outlet o " +
                        "Where cr.contract_no=c.contract_no And " +
                        "c.con_base_office=o.outlet_id And " +
                        "o.region_id=@ll_Region And " +
                        "cr.contractor_supplier_no = @ii_contractor;";
                    pList.Add(cm, "ll_Region", ll_Region);
                    pList.Add(cm, "ii_contractor", ii_contractor);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence.GetValueOrDefault();
                }
            }
        }

        [ServerMethod]
        private void _GetStandardFrequencyValues(int il_RgCode, DateTime id_EffectiveDate, int iWeekDelDays)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = " SELECT max(rtd_days_per_annum) " +
                        "FROM rd.standard_frequency join rd.rate_days on standard_frequency.sf_key = rate_days.sf_key " +
                        "and rate_days.rg_code = @il_RgCode and rate_days.rr_rates_effective_date= @id_EffectiveDate " +
                        "and standard_frequency.sf_days_week = @iWeekDelDays";

                    pList.Add(cm, "il_RgCode", il_RgCode);
                    pList.Add(cm, "id_EffectiveDate", id_EffectiveDate);
                    pList.Add(cm, "iWeekDelDays", iWeekDelDays);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetArticalCountAcStartWeekPeriodMax(int? lContract, int? lrenewal, DateTime? ldt_YearAgo)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime sequence = DateTime.MinValue;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = " select max(ac_start_week_period) from rd.artical_count as a2  " +
                        " where	 a2.contract_no = @lContract and " +
                        " (contract_seq_number is null or contract_seq_number = @lrenewal) and	 " +
                        " ac_start_week_period > @ldt_YearAgo";

                    pList.Add(cm, "lContract", lContract);
                    pList.Add(cm, "lrenewal", lrenewal);
                    pList.Add(cm, "ldt_YearAgo", ldt_YearAgo);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetDateTime(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetOutletRegionId(int? ll_Outlet)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select region_id from rd.outlet where outlet_id = @ll_Outlet";
                    pList.Add(cm, "ll_Outlet", ll_Outlet);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _InsertFixedAssetRegister(string sFixedAssetKey, int? lFatId, string sFAOwner, DateTime? dFAPurchaseDate, decimal? decFAPurchasePrice)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "Insert into rd.fixed_asset_register(fa_fixed_asset_no,fat_id,fa_owner,fa_purchase_date,fa_purchase_price) " +
                        "Values (@sFixedAssetKey,@lFatId, @sFAOwner,@dFAPurchaseDate,@decFAPurchasePrice)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "sFixedAssetKey", sFixedAssetKey);
                    pList.Add(cm, "lFatId", lFatId);
                    pList.Add(cm, "sFAOwner", sFAOwner);
                    pList.Add(cm, "dFAPurchaseDate", dFAPurchaseDate);
                    pList.Add(cm, "decFAPurchasePrice", decFAPurchasePrice);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateFixedAssetRegister(int? lFatId, string sFAOwner, DateTime? dFAPurchaseDate, decimal? decFAPurchasePrice, string sFixedAssetKey)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "UPDATE rd.fixed_asset_register " +
                        "set fat_id = @lFatId,fa_owner = @sFAOwner, " +
                            "fa_purchase_date = @dFAPurchaseDate," + 
                            "fa_purchase_price = @decFAPurchasePrice " +
                        "where fa_fixed_asset_no = @sFixedAssetKey";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lFatId", lFatId);
                    pList.Add(cm, "sFAOwner", sFAOwner);
                    pList.Add(cm, "dFAPurchaseDate", dFAPurchaseDate);
                    pList.Add(cm, "decFAPurchasePrice", decFAPurchasePrice);
                    pList.Add(cm, "sFixedAssetKey", sFixedAssetKey);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractCustListPrinted(int il_Contract_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime? sequence = DateTime.MinValue;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select cust_list_printed from rd.contract where contract_no = @il_Contract_no ";
                    pList.Add(cm, "il_Contract_no", il_Contract_no);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            if (dr[0] == null)
                            {
                                sequence = null;
                            }
                            else
                            {
                                sequence = dr.GetDateTime(0);
                            }
                        }
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractCustListUpdated(int il_Contract_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime? sequence = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select cust_list_updated from rd.contract where contract_no = @il_Contract_no";
                    pList.Add(cm, "il_Contract_no", il_Contract_no);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            if (dr.GetValue(0) != null)
                                sequence = dr.GetDateTime(0);
                        }
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _UpdateContractCustListUpdated(DateTime? ld_custlist_updated, int? il_contract_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "UPDATE rd.contract set cust_list_updated = @ld_custlist_updated " + 
                                      "where contract_no = @il_contract_no";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ld_custlist_updated", ld_custlist_updated);
                    pList.Add(cm, "il_contract_no", il_contract_no);

                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _InsertContractCustTransfer(int? lContractNo, int? ln, DateTime? tod)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "INSERT INTO rd.contract_cust_transfer" + 
                                           " (from_contract_no, to_contract_no, transfer_date) " + 
                                    " VALUES (@lContractNo, @ln, @tod)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lContractNo", lContractNo);
                    pList.Add(cm, "ln", ln);
                    pList.Add(cm, "tod", tod);

                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _InsertTCuststat(int? lID)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "insert into rd.t_custstat (id) values (@lID)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lID", lID);

                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetAddressTcIdFirst(int ai_contract_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select top 1 (tc_id) from rd.address where contract_no = @ai_contract_no";
                    pList.Add(cm, "ai_contract_no", ai_contract_no);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetPostCodePostCodeIdMax(int ai_tc_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT max(pc.post_code_id) FROM rd.post_code pc, rd.towncity tc " +
                        "WHERE tc.tc_id = @ai_tc_id AND pc.post_mail_town = tc.tc_name";
                    pList.Add(cm, "ai_tc_id", ai_tc_id);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetAddressAdrRdNoFirst1(int al_tcid, int al_pcid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = "";
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select top 1 address.adr_rd_no FROM rd.address " + 
                                      "WHERE tc_id = @al_tcid AND post_code_id = @al_pcid";
                    pList.Add(cm, "al_tcid", al_tcid);
                    pList.Add(cm, "al_pcid", al_pcid);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetString(0);
                        }
                    }
                    dataObject = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetAddressCount(int lContractNo)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT Count(*) FROM rd.address WHERE contract_no = @lContractNo";
                    pList.Add(cm, "lContractNo", lContractNo);
                    _sqlcode = -1;
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetRenewalRateRrFrozenIndicator(int lRGCode)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = "";
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select rr_frozen_indicator from rd.renewal_rate " +
                        "where rg_code = @lRGCode and " +
                        "rr_rates_effective_date = (select max(rr_rates_effective_date) " +
                                                     "from rd.renewal_rate where rg_code = @lRGCode);";
                    pList.Add(cm, "lRGCode", lRGCode);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetString(0);
                        }
                    }
                    dataObject = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetOutletInfo(string sOutlet)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select outlet_id, region_id from rd.outlet where o_name = @sOutlet";
                    pList.Add(cm, "sOutlet", sOutlet);
                    _outletItem = new OutletItem();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            _outletItem._outlet_id = dr.GetInt32(0);
                            _outletItem._region_id = dr.GetInt32(1);
                        }
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetOutletOutletId(string sOutlet)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "Select outlet_id From rd.outlet Where o_name = @sOutlet";
                    pList.Add(cm, "sOutlet", sOutlet);
                    _sqlcode = -1;
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _UpdateVehicleOverrideRate(
            decimal? ldc_new_override_fuel_rate,
            int? ll_contract_no,
            int? ll_sequence_no,
            DateTime? ld_rates_effective_date)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    //!pp - update does not support alias for tables
                    //!cm.CommandText = " UPDATE vehicle_override_rate vor1 " +
                    //! " SET vor1.vor_fuel_rate = @ldc_new_override_fuel_rate WHERE vor1.contract_no = @ll_contract_no " +
                    //! " AND vor1.contract_seq_number = @ll_sequence_no AND vor1.vor_effective_date >= @ld_rates_effective_date " +
                    //! " AND vor1.vor_effective_date = (SELECT max (vor2.vor_effective_date) FROM vehicle_override_rate vor2 " +
                    //! " WHERE vor2.contract_no = vor1.contract_no AND vor2.contract_seq_number = vor1.contract_seq_number)";
                    cm.CommandText = " UPDATE rd.vehicle_override_rate " +
                                        " SET vor_fuel_rate = @ldc_new_override_fuel_rate " + 
                                      " WHERE contract_no = @ll_contract_no " +
                                        " AND contract_seq_number = @ll_sequence_no " + 
                                        " AND vor_effective_date >= @ld_rates_effective_date " +
                                        " AND vor_effective_date = (SELECT	max(vor2.vor_effective_date) " +
                                                                    " FROM rd.vehicle_override_rate vor2 " +
                                                                   " WHERE vor2.contract_no = vehicle_override_rate.contract_no" + 
                                                                     " AND vor2.contract_seq_number = vehicle_override_rate.contract_seq_number)";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ldc_new_override_fuel_rate", ldc_new_override_fuel_rate);
                    pList.Add(cm, "ll_contract_no", ll_contract_no);
                    pList.Add(cm, "ll_sequence_no", ll_sequence_no);
                    pList.Add(cm, "ld_rates_effective_date", ld_rates_effective_date);
                    pList.Add(cm, "ll_contract_no", ll_contract_no);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractCount(int il_Contract_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select count(*) from rd.contract, contract_renewals " +
                        "where contract.contract_no = @il_Contract_no and " +
                        "contract.contract_no = contract_renewals.contract_no and  " +
                        "(contract.con_active_sequence is null or  " +
                        "contract.con_active_sequence < contract_renewals.contract_seq_number)";
                    pList.Add(cm, "il_Contract_no", il_Contract_no);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                            }
                            else
                            {
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _ProcesureSpCreatetfc()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_CreateTFC";
                    ParameterCollection pList = new ParameterCollection();

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
        }

        [ServerMethod]
        private void _DeleteContractRenewals(int? lcontract, int lsequence)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "delete from rd.contract_renewals where contract_no=@lcontract and contract_seq_number=@lsequence";
                    pList.Add(cm, "lcontract", lcontract);
                    pList.Add(cm, "lsequence", lsequence);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _DeleteTCuststat()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "delete from rd.t_custstat";
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _DeleteTmpRandCustList()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "delete from rd.tmp_rand_cust_list";
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _DeleteReportTemp1()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "delete from rd.report_temp";
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _DeleteRdsTemp()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "delete from rd.rds_temp ";
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetContractFixedAssetsCount(string sFixedAssetno, int il_Contract_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select count(*) from rd.contract_fixed_assets " +
                        "where fa_fixed_asset_no = @sFixedAssetno and " +
                        "contract_no <> @il_Contract_no";
                    pList.Add(cm, "sFixedAssetno", sFixedAssetno);
                    pList.Add(cm, "il_Contract_no", il_Contract_no);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                            }
                            else
                            {
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetFixedAssetRegisterInfo(string sFixedAssetno)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select fat_id, fa_owner,fa_purchase_date,fa_purchase_price " +
                        "from rd.fixed_asset_register " +
                        "where fa_fixed_asset_no = @sFixedAssetno";
                    pList.Add(cm, "sFixedAssetno", sFixedAssetno);
                    _fixedAssetRegisterItem = new FixedAssetRegisterItem();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _fixedAssetRegisterItem._fat_id = dr.GetInt32(0);
                                _fixedAssetRegisterItem._fa_owner = dr.GetString(1);
                                _fixedAssetRegisterItem._fa_purchase_date = dr.GetDateTime(2);
                                _fixedAssetRegisterItem._fa_purchase_price = dr.GetDecimal(3);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetAddressInfoFirst(int il_contract_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select top 1 a.adr_rd_no, p.post_code_id, t.tc_id " +
                        "from rd.address a, rd.post_code p, rd.towncity t " +
                        "where a.post_code_id = p.post_code_id and " +
                        "t.tc_name = p.post_mail_town and " +
                        "a.contract_no = @il_contract_no order by a.adr_rd_no";

                    pList.Add(cm, "il_contract_no", il_contract_no);
                    _addressPostCodeTowncityItem = new AddressPostCodeTowncityItem();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            _addressPostCodeTowncityItem._adr_rd_no = dr.GetString(0);
                            _addressPostCodeTowncityItem._post_code_id = dr.GetInt32(1);
                            _addressPostCodeTowncityItem._tc_id = dr.GetInt32(2);
                        }
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetRegionValue(int? ll_regionId)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = string.Empty;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT rgn_name FROM rd.region WHERE region_id = @ll_regionId";
                    pList.Add(cm, "ll_regionId", ll_regionId);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetString(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    strVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetOutletValue(int? lOutlet)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = string.Empty;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT outlet.o_name  FROM rd.outlet WHERE outlet.outlet_id = @lOutlet;";
                    pList.Add(cm, "lOutlet", lOutlet);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetString(0);
                        }

                    }

                    strVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetRenewalGroupValue(int? lRenGroup)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = string.Empty;
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = "SELECT renewal_group.rg_description FROM rd.renewal_group  " +
                        "WHERE renewal_group.rg_code = @lRenGroup";

                    pList.Add(cm, "lRenGroup", lRenGroup);

                    try
                    {
                        _sqlcode = 100;
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _sqlcode = 0;
                                sequence = dr.GetString(0);
                            }
                            else
                                _sqlcode = 100;

                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                    strVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractValue(int? lContract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = string.Empty;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT contract.con_title FROM rd.contract WHERE contract.contract_no = @lContract ";
                    pList.Add(cm, "lContract", lContract);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _sqlcode = 0;
                                sequence = dr.GetString(0);
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                    strVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _DeleteReportTemp(int? ll_custid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = string.Empty;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "DELETE FROM rd.report_temp WHERE report_temp.customer_id = @ll_custid ";
                    pList.Add(cm, "ll_custid", ll_custid);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _sqlcode = 0;
                                sequence = dr.GetString(0);
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                    strVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractTypeValue(int? lContractType)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sequence = string.Empty;
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = "SELECT contract_type.contract_type FROM rd.contract_type WHERE contract_type.ct_key = @lContractType ";

                    pList.Add(cm, "lContractType", lContractType);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetString(0);
                        }
                    }
                    strVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetOutletValue2(string sOutlet)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select outlet_id from rd.outlet where o_name = @sOutlet";
                    pList.Add(cm, "sOutlet", sOutlet);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _sqlcode = 0;
                                sequence = dr.GetInt32(0);
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetContractCount2(int? ll_contract_num)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(*) FROM rd.Contract WHERE Contract.contract_no = @ll_contract_num  ";
                    pList.Add(cm, "ll_contract_num", ll_contract_num);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetTmpRandCustList()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select count(*) from rd.tmp_rand_cust_list ";
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetTownCityValue(string ls_tc_name)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = " SELECT tc_id  FROM rd.TownCity WHERE TownCity.tc_name = @ls_tc_name   ";
                    pList.Add(cm, "ls_tc_name", ls_tc_name);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _sqlcode = 0;
                                sequence = dr.GetInt32(0);
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetTownCityValue2(string ls_tc_name)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = " SELECT min(TownCity.tc_id) FROM rd.TownCity WHERE TownCity.tc_name = @ls_tc_name   ";
                    pList.Add(cm, "ls_tc_name", ls_tc_name);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _sqlcode = 0;
                                sequence = dr.GetInt32(0);
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetCustomerAddressMovesMoveInDateMin1()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime sequence = DateTime.MinValue;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT min((move_in_date)) FROM rd.customer_address_moves WHERE move_out_date is null";
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _sqlcode = 0;
                                sequence = dr.GetDateTime(0);
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetMailCountDateMailCountDate()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime sequence = DateTime.MinValue;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT mail_count_date.mail_count_date FROM rd.mail_count_date ";
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetDateTime(0);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    dtVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetCustomerAddressMovesMoveInDateMin(DateTime? mcdate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT min(nvr.rg_code) FROM rd.non_vehicle_rate nvr " +
                        "WHERE nvr.nvr_contract_end = (SELECT min( nvr2.nvr_contract_end) " +
                                                        "FROM rd.non_vehicle_rate nvr2 " + 
                                                       "WHERE nvr2.nvr_contract_end >= @mcdate)  ";
                    pList.Add(cm, "mcdate", mcdate);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _sqlcode = 0;
                                sequence = dr.GetInt32(0);
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetCustomerAddressMovesMoveInDateMin1(int? rg_code, DateTime? mcdate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT min(nvr.rg_code) FROM rd.non_vehicle_rate nvr " +
                        "WHERE nvr.rg_code <> @rg_code and " + 
                              "nvr.nvr_contract_end = (SELECT min(nvr2.nvr_contract_end) " +
                                                        "FROM rd.non_vehicle_rate nvr2 " + 
                                                       "WHERE nvr2.nvr_contract_end > @mcdate and " + 
                                                             "nvr2.nvr_contract_end > (select min(nvr3.nvr_contract_end) " +
                                                                                        "from rd.non_vehicle_rate nvr3 " + 
                                                                                       "where nvr3.nvr_contract_end >= @mcdate))";
                    pList.Add(cm, "rg_code", rg_code);
                    pList.Add(cm, "mcdate", mcdate);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _sqlcode = 0;
                                sequence = dr.GetInt32(0);
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _GetMailCountDateMailCountDateCount()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT count(mail_count_date.mail_count_date) FROM rd.mail_count_date";

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                            }
                            else
                            {
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _InsertMailCountDate(DateTime? mcdate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = " INSERT INTO rd.mail_count_date (mail_count_date) VALUES (@mcdate) ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "mcdate", mcdate);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateMailCountDateMailCountDate(DateTime? mcdate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "UPDATE rd.mail_count_date SET mail_count_date = @mcdate";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "mcdate", mcdate);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetIdCodesNextValue(string sequencename)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT next_value from rd.id_codes where sequence_name = @sequencename ;";
                    pList.Add(cm, "sequencename", sequencename);
                    _sqlcode = 100;
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                sequence = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _InsertIdCodes(string sequencename)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "insert into rd.id_codes (sequence_name, next_value) values (@sequencename, 2) ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "sequencename", sequencename);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateIdCodes(int nNextValue, string sequencename)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "UPDATE rd.id_codes set next_value = @nNextValue + 1 where sequence_name = @sequencename ; ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "nNextValue", nNextValue);
                    pList.Add(cm, "sequencename", sequencename);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
        }

        [ServerMethod]
        private void _ExecuteSqlString(string ls_select)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = ls_select;
                    ParameterCollection pList = new ParameterCollection();

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _ExecuteSqlStringLcount(string sSQLSelect)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int sequence = 0;
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = sSQLSelect;
                    ParameterCollection pList = new ParameterCollection();
                    try
                    {
                        //DBHelper.ExecuteNonQuery(cm, pList);
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _sqlcode = 0;
                                sequence = dr.GetInt32(0);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _ExecuteSqlRecipients(string sSQLSelectRecipients)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int sequence = 0;
                    cm.CommandText = sSQLSelectRecipients;
                    ParameterCollection pList = new ParameterCollection();
                    try
                    {
                        _sqlcode = DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _ExecuteSqlStringlRecipientCount(string sSQLSelectRecipients)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int sequence = 0;
                    cm.CommandText = sSQLSelectRecipients;
                    ParameterCollection pList = new ParameterCollection();
                    try
                    {
                        //DBHelper.ExecuteNonQuery(cm, pList);
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _sqlcode = 0;
                                sequence = dr.GetInt32(0);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                    intVal = sequence;
                }
            }
        }

        [ServerMethod]
        private void _InsertReportTemp(string sql)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = sql;
                    ParameterCollection pList = new ParameterCollection();

                    DBHelper.ExecuteNonQuery(cm, pList);
                }
            }
        }

        [ServerMethod]
        private void _FFreqInuse(int? ai_contract, int? ai_sfkey, string as_deldays)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                int iCount = 0;
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ai_contract", ai_contract);
                    pList.Add(cm, "ai_sfkey", ai_sfkey);
                    pList.Add(cm, "as_deldays", as_deldays);
                    cm.CommandText = "SELECT count (*) FROM rd.frequency_distances fd, rd.contract c, rd.contract_renewals cr " + 
                                     "WHERE" +
                                          " fd.contract_no = :ai_contract AND " +
                                          " fd.sf_key = :ai_sfkey AND " +
                                          " fd.rf_delivery_days = :as_deldays AND " +
                                          " fd.contract_no = c.contract_no AND " +
                                          " c.con_active_sequence = cr.contract_seq_number;";
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            iCount = GetValueFromReader<Int32>(dr, 0);
                        }
                    }
                    if (iCount > 0)
                    {
                        strVal = "Yes";
                    }
                    else
                    {
                        strVal = "No";
                    }
                }
            }
        }

        // TJB  RD7_0039  Sept2009:  added
        [ServerMethod]
        private void _CleanupFDRows(int? sf_key, int? contract_no, int? rd_sequence, string rf_delivery_days)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    DbCommand cm = cn.CreateCommand();
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();

                    pList.Add(cm, "sf_key", sf_key);
                    pList.Add(cm, "contract_no", contract_no);
                    pList.Add(cm, "rd_sequence", rd_sequence);
                    pList.Add(cm, "rf_delivery_days", rf_delivery_days);

                    cm.CommandText = "DELETE FROM rd.route_description"
                                   + " WHERE route_description.sf_key = @sf_key"
                                     + " and route_description.contract_no = @contract_no"
                                     + " and route_description.rf_delivery_days = @rf_delivery_days"
                                     + " and (route_description.rd_sequence >= @rd_sequence"
                                     + "      or route_description.rd_sequence < 0)"
                                     ;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        tr.Commit();
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                    }
                }
            }
        }

        // TJB  June-2010  ECL Data Upload -----------------------------------------------
        [ServerMethod]
        private void _GetECLUploadHistoryCurrentBatchNo()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "select max(ecl_batch_no) from rd.ECL_upload_history " +
                        "WHERE ecl_date_inserted is null";
                    ParameterCollection pList = new ParameterCollection();

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                        intVal = 0;
                    }
                }
            }
        }

        private List<EclOldBatchItem> _eclOldBatchList;
        public List<EclOldBatchItem> EclOldBatchList
        {
            get
            {
                return _eclOldBatchList;
            }
        }

        [ServerMethod]
        private void _GetECLUploadHistoryOldBatchNos(DateTime inDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "select distinct euh1.ecl_batch_no, euh1.ecl_date_inserted "
                                    + " FROM rd.ECL_upload_history euh1 "
                                    + "WHERE euh1.ecl_date_inserted < @inDate "
                                    + "  AND euh1.ecl_date_purged is null "
                                    + "  AND euh1.ecl_date_uploaded = (select max(ecl_date_uploaded) "
                                    + " from ecl_upload_history euh2 "
                                    +                                  "where euh2.ecl_batch_no = euh1.ecl_batch_no)"
                                    ;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inDate", inDate);

                     _eclOldBatchList = new List<EclOldBatchItem>();

                    try
                    {
                        _sqlcode = 100;
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                EclOldBatchItem rf = new EclOldBatchItem();
                                rf.batch_no = dr.GetInt32(0);
                                rf.date_inserted = dr.GetDateTime(1);
                                _eclOldBatchList.Add(rf);
                            }
                            _sqlcode = 0;
                            intVal = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                        intVal = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetECLUploadHistoryNextBatchNo()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "select max(ecl_batch_no) from rd.ECL_upload_history";
                    ParameterCollection pList = new ParameterCollection();

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0) + 1;
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                        intVal = 1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _InsertIntoECLUploadHistory(int lBatchNo, DateTime dtDateUploaded, int lRecordsUploaded, int lUploadErrors, string sUploadFilename)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "INSERT INTO rd.ECL_upload_history "
                         + "( ecl_batch_no, ecl_date_uploaded, ecl_records_uploaded, ecl_upload_errors, ecl_upload_filename ) " +
                        "VALUES "
                         + "( @batchNo, @dateUploaded, @recordsUploaded, @uploadErrors, @uploadFilename )";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "batchNo", lBatchNo);
                    pList.Add(cm, "dateUploaded", dtDateUploaded);
                    pList.Add(cm, "recordsUploaded", lRecordsUploaded);
                    pList.Add(cm, "uploadErrors", lUploadErrors);
                    pList.Add(cm, "uploadFilename", sUploadFilename);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateECLUploadHistoryUpload(int lBatchNo, DateTime dtDateUploaded, int lRecordsUploaded, int lUploadErrors)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "UPDATE rd.ECL_upload_history " +
                        "SET ecl_date_uploaded = @dateUploaded " +
                          ", ecl_records_uploaded = @recordsUploaded " +
                          ", ecl_upload_errors = @uploadErrors" +
                        "WHERE ecl_batch_no = @batchNo";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "batchNo", lBatchNo);
                    pList.Add(cm, "dateUploaded", dtDateUploaded);
                    pList.Add(cm, "recordsUploaded", lRecordsUploaded);
                    pList.Add(cm, "uploadErrors", lUploadErrors);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        private void _UpdateECLUploadHistoryInsert(int lBatchNo, DateTime dtDateInserted, int lRecordsInserted, int lInsertErrors)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "UPDATE rd.ECL_upload_history " +
                        "SET ecl_date_inserted = @dateInserted " +
                          ", ecl_records_inserted = @recordsInserted " +
                          ", ecl_insert_errors = @insertErrors" +
                        "WHERE contract_no = @batchNo";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "batchNo", lBatchNo);
                    pList.Add(cm, "dateInserted", dtDateInserted);
                    pList.Add(cm, "recordsInserted", lRecordsInserted);
                    pList.Add(cm, "insertErrors", lInsertErrors);
                    _sqlcode = -1;
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _IsDuplicateECLUploadData(string sTicketNo, string sTicketPart)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = 
                        "select count(*) from rd.ECL_upload_data "
                         + "where ecl_ticket_no = @ticketNo "
                         + "  and ecl_ticket_part = @ticketPart ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ticketNo", sTicketNo);
                    pList.Add(cm, "ticketPart", sTicketPart);
                    _sqlcode = -1;
                    try
                    {
                        ret = false;
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            intVal = 0;
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                        if (intVal >= 1)
                        {
                            ret = true;
                        }
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetECLUploadedBatchSize(int lBatchNo)
        {   // Returns 
            //     n    the number of rcords in the batch that haven't been inserted
            //    -1    if the batch has already been inserted
            //    -2    If the batch doesn't exist (hasn't been loaded)

            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "IF not exists (SELECT 1 FROM rd.ECL_upload_history h "
                                                   + "WHERE h.ecl_batch_no = @batchNo) "
                                   + "   SELECT -2 "
                                   + "ELSE IF not exists (SELECT 1 FROM rd.ECL_upload_history h "
                                                    + "WHERE h.ecl_batch_no = @batchNo "
                                                    + "AND h.ecl_date_inserted is null)"
                                   + "   SELECT -1 "
                                   + "ELSE "
                                   + "   SELECT count(*) FROM rd.ECL_upload_data d"
                                   + "    WHERE d.ecl_batch_no = @batchNo "
                                   ;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "batchNo", lBatchNo);

                    try
                    {
                        intVal = 0;
                        _sqlcode = 0;
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            else  // No records found
                            {
                                intVal = -1;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                        intVal = 0;
                    }
                }
            }
        }

        [ServerMethod]
        private void _sp_ECLPurgeBatch(int in_batchNo)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_ECLPurgeBatch";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_batchNo", in_batchNo);

                    intVal = 0;
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _sp_ECLInsertData(int in_batchNo)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_ECLInsertData";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_batchNo", in_batchNo);

                    intVal = 0;
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                            _sqlcode = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        private List<EclQualityMappingItem> _eclQualityMappingsList;
        public List<EclQualityMappingItem> EclQualityMappingsList
        {
            get
            {
                return _eclQualityMappingsList;
            }
        }

        // This method returns a list of the entries in the ecl_quality_mappings table
        [ServerMethod]
        private void _GetEclQualityMappings()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {

                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = "SELECT * FROM ecl_quality_mappings";

                    _eclQualityMappingsList = new List<EclQualityMappingItem>();
                    try
                    {
                        _sqlcode = 100;
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                EclQualityMappingItem rf = new EclQualityMappingItem();
                                rf.column_name = dr.GetString(0);
                                rf.match_string = dr.GetString(1);
                                rf.match_type = dr.GetString(2);
                                rf.pr_code = dr.GetString(3);
                                _eclQualityMappingsList.Add(rf);
                                _sqlcode = 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = ex.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _InsertIntoECLUploadData( EclImportData item )
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cm.CommandText = "INSERT INTO rd.ECL_upload_data "
                         + "( ecl_batch_no, ecl_ticket_no, ecl_ticket_part, ecl_customer_name, "
                         + "  ecl_customer_code, ecl_seq, ecl_driver_id, ecl_rate_code, "
                         + "  ecl_rate_descr, ecl_pkg_descr, ecl_batch_id, ecl_run_id, "
                         + "  ecl_run_no, ecl_driver_date, ecl_date_entered, ecl_ticket_payable, "
                         + "  ecl_rural_payable, ecl_scan_count, ecl_sig_req_flag, ecl_sig_captured, "
                         + "  ecl_sig_name, ecl_pr_code, ecl_ro5_flag, ecl_effective_date )"
                        + "VALUES "
                         + "( @BatchNo, @TicketNo, @TicketPart, @CustomerName, "
                         + "  @CustomerCode, @Seq, @DriverId, @RateCode, "
                         + "  @RateDescr, @PkgDescr, @BatchId, @RunID, "
                         + "  @RunNo, @DriverDate, @DateEntered, @TicketPayable, "
                         + "  @RuralPayable, @ScanCount, @SigReqFlag, @SigCaptured, "
                         + "  @SigName, @PrCode, @Ro5Flag, @EffectiveDate )";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "BatchNo", item.EclBatchNo);
                    pList.Add(cm, "TicketNo", item.EclTicketNo);
                    pList.Add(cm, "TicketPart", item.EclTicketPart);
                    pList.Add(cm, "CustomerName", item.EclCustomerName);
                    pList.Add(cm, "CustomerCode", item.EclCustomerCode);
                    pList.Add(cm, "Seq", item.EclSeq);
                    pList.Add(cm, "DriverId", item.EclDriverId);
                    pList.Add(cm, "RateCode", item.EclRateCode);
                    pList.Add(cm, "RateDescr", item.EclRateDescr);
                    pList.Add(cm, "PkgDescr", item.EclPkgDescr);
                    pList.Add(cm, "BatchId", item.EclBatchId);
                    pList.Add(cm, "RunID", item.EclRunID);
                    pList.Add(cm, "RunNo", item.EclRunNo);
                    pList.Add(cm, "DriverDate", item.EclDriverDate);
                    pList.Add(cm, "DateEntered", item.EclDateEntered);
                    pList.Add(cm, "TicketPayable", item.EclTicketPayable);
                    pList.Add(cm, "RuralPayable", item.EclRuralPayable);
                    pList.Add(cm, "ScanCount", item.EclScanCount);
                    pList.Add(cm, "SigReqFlag", item.EclSigReqFlag);
                    pList.Add(cm, "SigCaptured", item.EclSigCaptured);
                    pList.Add(cm, "SigName", item.EclSigName);
                    pList.Add(cm, "PrCode", item.EclPrCode);
                    pList.Add(cm, "Ro5Flag", item.EclRo5Flag);
                    pList.Add(cm, "EffectiveDate", item.EclEffectiveDate);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        // TJB  June-2010  ECL Data Upload --------------------- End ---------------------
        #endregion
    }

    #region Method Class

    // TJB  June-2010  ECL Data Upload -----------------------------------------------
    [Serializable()]
    public class EclQualityMappingItem
    {
        internal string column_name;
        public string Column_name
        {
            get
            {
                return column_name;
            }
        }
        internal string match_string;
        public string Match_string
        {
            get
            {
                return match_string;
            }
        }
        internal string match_type;
        public string Match_type
        {
            get
            {
                return match_type;
            }
        }
        internal string pr_code;
        public string Pr_code
        {
            get
            {
                return pr_code;
            }
        }
    }

    [Serializable()]
    public class EclOldBatchItem
    {
        internal int batch_no;
        public int Batch_No
        {
            get
            {
                return batch_no;
            }
        }
        internal DateTime date_inserted;
        public DateTime Date_Inserted
        {
            get
            {
                return date_inserted;
            }
        }
    }
    // TJB  June-2010  ECL Data Upload --------------------- End ---------------------

    [Serializable()]
    public class VehicleItem
    {
        internal int? vehicle_number;
        public int? Vehicle_number
        {
            get
            {
                return vehicle_number;
            }
        }

        internal int? vt_key;
        public int? Vt_key
        {
            get
            {
                return vt_key;
            }
        }
        internal int? ft_key;
        public int? Ft_key
        {
            get
            {
                return ft_key;
            }
        }
        internal string v_vehicle_make;
        public string V_vehicle_make
        {
            get
            {
                return v_vehicle_make;
            }
        }
        internal string v_vehicle_model;
        public string V_vehicle_model
        {
            get
            {
                return v_vehicle_model;
            }
        }
        internal int? v_vehicle_year;
        public int? V_vehicle_year
        {
            get
            {
                return v_vehicle_year == 0 ? null : v_vehicle_year;
            }
        }
        internal int? v_vehicle_cc_rating;
        public int? V_vehicle_cc_rating
        {
            get
            {
                return v_vehicle_cc_rating == 0 ? null : v_vehicle_cc_rating;
            }
        }
        internal string v_road_user_charges_indicator;
        public string V_road_user_charges_indicator
        {
            get
            {
                return v_road_user_charges_indicator;
            }
        }
        internal DateTime? v_purchased_date;
        public DateTime? V_purchased_date
        {
            get
            {
                return v_purchased_date;
            }
        }
        internal int? v_purchase_value;
        public int? V_purchase_value
        {
            get
            {
                return v_purchase_value;
            }
        }

        internal string v_leased;
        public string V_leased
        {
            get
            {
                return v_leased;
            }
        }

        internal int? v_vehicle_month;
        public int? V_vehicle_month
        {
            get
            {
                return v_vehicle_month;
            }
        }
    }

    [Serializable()]
    public class ContractItem
    {
        internal decimal? pr_rate;
        public decimal? Pr_rate
        {
            get
            {
                return pr_rate;
            }
        }

        internal DateTime? pr_effective_date;
        public DateTime? Pr_effective_date
        {
            get
            {
                return pr_effective_date;
            }
        }
    }

    [Serializable()]
    public class ContractRenewalsDateItem
    {
        internal DateTime con_start_date;
        public DateTime Con_start_date
        {
            get
            {
                return con_start_date;
            }
        }

        internal DateTime con_expiry_date;
        public DateTime Con_expiry_date
        {
            get
            {
                return con_expiry_date;
            }
        }
    }

    [Serializable()]
    public class ContractRenewalsItem
    {
        internal string con_relief_driver_name;
        public string Con_relief_driver_name
        {
            get
            {
                return con_relief_driver_name;
            }
        }

        internal string con_relief_driver_address;
        public string Con_relief_driver_address
        {
            get
            {
                return con_relief_driver_address;
            }
        }

        internal string con_relief_driver_home_phone;
        public string Con_relief_driver_home_phone
        {
            get
            {
                return con_relief_driver_home_phone;
            }
        }
    }

    [Serializable()]
    public class RouteFrequencyItem
    {
        internal int _sf_key;
        public int SfKey
        {
            get
            {
                return _sf_key;
            }
        }

        internal string _rf_delivery_days;
        public string RfDeliveryDays
        {
            get
            {
                return _rf_delivery_days;
            }
        }

        internal decimal _rf_distance;
        public decimal RfDistance
        {
            get
            {
                return _rf_distance;
            }
        }
    }

    [Serializable()]
    public class VehicleTypeItem
    {
        internal int _vt_key;
        public int VtKey
        {
            get
            {
                return _vt_key;
            }
        }

        internal string _vt_description;
        public string VtDescription
        {
            get
            {
                return _vt_description;
            }
        }
    }

    [Serializable()]
    public class VehicleRateNonVehicleRateItem
    {
        internal decimal? vr_nominal_vehicle_value;
        public decimal? VrNominalVehicleValue
        {
            get
            {
                return vr_nominal_vehicle_value;
            }
        }

        internal decimal? vr_repairs_maintenance_rate;
        public decimal? VrRepairsMaintenanceRate
        {
            get
            {
                return vr_repairs_maintenance_rate;
            }
        }

        internal decimal? vr_tyre_tubes_rate;
        public decimal? VrTyreTubesRate
        {
            get
            {
                return vr_tyre_tubes_rate;
            }
        }

        internal decimal? vr_vehicle_allowance_rate;
        public decimal? VrVehicleAllowanceRate
        {
            get
            {
                return vr_vehicle_allowance_rate;
            }
        }

        internal decimal? vr_licence_rate;
        public decimal? VrLicenceRate
        {
            get
            {
                return vr_licence_rate;
            }
        }

        internal decimal? vr_vehicle_rate_of_return_pct;
        public decimal? VrVehicleRateOfReturnPct
        {
            get
            {
                return vr_vehicle_rate_of_return_pct;
            }
        }

        internal decimal? vr_salvage_ratio;
        public decimal? VrSalvageRatio
        {
            get
            {
                return vr_salvage_ratio;
            }
        }

        internal decimal? vr_ruc;
        public decimal? VrRuc
        {
            get
            {
                return vr_ruc;
            }
        }

        internal decimal? vr_sundries_k;
        public decimal? VrSundriesK
        {
            get
            {
                return vr_sundries_k;
            }
        }

        internal decimal? vr_vehicle_value_insurance_pct;
        public decimal? VrVehicleValueInsurancePct
        {
            get
            {
                return vr_vehicle_value_insurance_pct;
            }
        }

        internal decimal? vr_livery;
        public decimal? VrLivery
        {
            get
            {
                return vr_livery;
            }
        }

        internal decimal? nvr_vehicle_insurance_base_premium;
        public decimal? NvrVehicleInsuranceBasePremium
        {
            get
            {
                return nvr_vehicle_insurance_base_premium;
            }
        }
    }

    [Serializable()]
    public class VehicleOverrideRateItem
    {
        internal decimal? vor_nominal_vehicle_value;
        public decimal? VorNominalVehicleValue
        {
            get
            {
                return vor_nominal_vehicle_value;
            }
        }

        internal decimal? vor_repairs_maintenance_rate;
        public decimal? VorRepairsMaintenanceRate
        {
            get
            {
                return vor_repairs_maintenance_rate;
            }
        }

        internal decimal? vor_tyre_tubes_rate;
        public decimal? VorTyreTubesRate
        {
            get
            {
                return vor_tyre_tubes_rate;
            }
        }

        internal decimal? vor_vehical_allowance_rate;
        public decimal? VorVehicalAllowanceRate
        {
            get
            {
                return vor_vehical_allowance_rate;
            }
        }

        internal decimal? vor_licence_rate;
        public decimal? VorLicenceRate
        {
            get
            {
                return vor_licence_rate;
            }
        }

        internal decimal? vor_vehicle_rate_of_return_pct;
        public decimal? VorVehicleRateOfReturnPct
        {
            get
            {
                return vor_vehicle_rate_of_return_pct;
            }
        }

        internal decimal? vor_salvage_ratio;
        public decimal? VorSalvageRatio
        {
            get
            {
                return vor_salvage_ratio;
            }
        }

        internal decimal? vor_ruc;
        public decimal? VorRuc
        {
            get
            {
                return vor_ruc;
            }
        }

        internal decimal? vor_sundries_k;
        public decimal? VorSundriesK
        {
            get
            {
                return vor_sundries_k;
            }
        }

        internal decimal? vor_vehicle_insurance_premium;
        public decimal? VorVehicleInsurancePremium
        {
            get
            {
                return vor_vehicle_insurance_premium;
            }
        }

        internal decimal? vor_livery;
        public decimal? VorLivery
        {
            get
            {
                return vor_livery;
            }
        }
    }

    [Serializable()]
    public class OutletItem
    {
        internal int _outlet_id;
        public int OutletId
        {
            get
            {
                return _outlet_id;
            }
        }

        internal int _region_id;
        public int RegionId
        {
            get
            {
                return _region_id;
            }
        }
    }

    [Serializable()]
    public class FixedAssetRegisterItem
    {
        internal int _fat_id;
        public int FatId
        {
            get
            {
                return _fat_id;
            }
        }

        internal string _fa_owner;
        public string FaOwner
        {
            get
            {
                return _fa_owner;
            }
        }

        internal DateTime _fa_purchase_date;
        public DateTime FaPurchaseDate
        {
            get
            {
                return _fa_purchase_date;
            }
        }

        internal decimal _fa_purchase_price;
        public decimal FaPurchasePrice
        {
            get
            {
                return _fa_purchase_price;
            }
        }
    }

    [Serializable()]
    public class AddressPostCodeTowncityItem
    {
        internal string _adr_rd_no;
        public string AdrRdNo
        {
            get
            {
                return _adr_rd_no;
            }
        }

        internal int _post_code_id;
        public int PostCodeId
        {
            get
            {
                return _post_code_id;
            }
        }

        internal int _tc_id;
        public int TcId
        {
            get
            {
                return _tc_id;
            }
        }
    }

    [Serializable()]
    public class CaLoadResultsItem
    {
        internal int _rows_inserted;
        public int RowsInserted
        {
            get
            {
                return _rows_inserted;
            }
        }

        internal int _rows_skipped;
        public int RowsSkipped
        {
            get
            {
                return _rows_skipped;
            }
        }

        internal int _row_errors;
        public int RowErrors
        {
            get
            {
                return _row_errors;
            }
        }

        internal decimal _amount_inserted;
        public decimal AmountInserted
        {
            get
            {
                return _amount_inserted;
            }
        }
    }

    [Serializable()]
    public class FirstRouteFrequenctSfKeyItem
    {

        internal int _sf_key;
        public int SfKey
        {
            get
            {
                return _sf_key;
            }
        }

        internal string _rf_delivery_days;
        public string RfDeliveryDays
        {
            get
            {
                return _rf_delivery_days;
            }
        }
    }

    [Serializable()]
    public class ContractInfoByNoItem
    {
        internal string _con_title;
        public string ConTitle
        {
            get
            {
                return _con_title;
            }
        }

        internal string _o_name;
        public string OName
        {
            get
            {
                return _o_name;
            }
        }
    }

    [Serializable()]
    public class RdsCustomInfoItem
    {
        internal int? _dp_id;
        public int? DpId
        {
            get
            {
                return _dp_id;
            }
        }

        internal int? _cust_id;
        public int? CustId
        {
            get
            {
                return _cust_id;
            }
        }
    }

    [Serializable()]
    public class CustomerAddressMovesDpIdCustIdItem
    {
        internal int? _dp_id;
        public int? DpId
        {
            get
            {
                return _dp_id;
            }
        }

        internal int? _cust_id;
        public int? CustId
        {
            get
            {
                return _cust_id;
            }
        }
    }

    [Serializable()]
    public class FirstPostCodeIdCodeItem
    {
        internal int? _post_code_id;
        public int? PostCodeId
        {
            get
            {
                return _post_code_id;
            }
        }

        internal string _post_code;
        public string PostCode
        {
            get
            {
                return _post_code;
            }
        }
    }

    [Serializable()]
    public class PostCodeIdCodeItem
    {
        internal string _post_code;
        public string PostCode
        {
            get
            {
                return _post_code;
            }
        }

        internal int? _post_code_id;
        public int? PostCodeId
        {
            get
            {
                return _post_code_id;
            }
        }
    }

    [Serializable()]
    public class ContractNoConDateTerminatedItem
    {
        internal int? _contract_no;
        public int? ContractNo
        {
            get
            {
                return _contract_no;
            }
        }

        internal DateTime? _con_date_terminated;
        public DateTime? ConDateTerminated
        {
            get
            {
                return _con_date_terminated;
            }
        }
    }
    #endregion
}
