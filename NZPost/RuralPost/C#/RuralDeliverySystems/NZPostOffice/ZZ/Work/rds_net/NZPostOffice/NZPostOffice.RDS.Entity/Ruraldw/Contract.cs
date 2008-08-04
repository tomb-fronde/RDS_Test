using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "contract")]
    [MapInfo("rg_code", "_rg_code", "contract")]
    [MapInfo("con_old_mail_service_no", "_con_old_mail_service_no", "contract")]
    [MapInfo("con_title", "_con_title", "contract")]
    [MapInfo("con_rd_paper_file_text", "_con_rd_paper_file_text", "contract")]
    [MapInfo("con_rcm_paper_file_text", "_con_rcm_paper_file_text", "contract")]
    [MapInfo("con_base_office", "_con_base_office", "contract")]
    [MapInfo("con_base_office_name", "_con_base_office_name", "")]
    [MapInfo("region_id", "_region_id", "")]
    [MapInfo("con_lodgement_office", "_con_lodgement_office", "contract")]
    [MapInfo("con_lodgement_office_name", "_con_lodgement_office_name", "")]
    [MapInfo("con_active_sequence", "_con_active_sequence", "contract")]
    [MapInfo("con_base_cont_type", "_ct_key", "contract")]
    [MapInfo("con_rd_ref_text", "_con_rd_ref_text", "contract")]
    [MapInfo("con_last_service_review", "_con_last_service_review", "contract")]
    [MapInfo("con_last_delivery_check", "_con_last_delivery_check", "contract")]
    [MapInfo("con_last_work_msrmnt_check", "_con_last_work_msrmnt_check", "contract")]
    [MapInfo("con_lngth_sealed_road", "_con_lngth_sealed_road", "contract")]
    [MapInfo("con_lngth_unsealed_road", "_con_lngth_unsealed_road", "contract")]
    [MapInfo("con_date_terminated", "_con_date_terminated", "contract")]
    [MapInfo("bo_picklist", "_bo_picklist", "")]
    [MapInfo("lo_picklist", "_lo_picklist", "")]
    [MapInfo("ac_id", "_ac_id", "contract")]
    [MapInfo("message_for_invoice", "_message_for_invoice", "contract")]
    [MapInfo("PBU_ID", "_pbu_id", "contract")]
    [MapInfo("con_base_office_type", "_con_base_office_type", "")]
    [MapInfo("con_lodgement_office_type", "_con_lodgement_office_type", "")]
    [System.Serializable()]

    public class Contract : Entity<Contract>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _rg_code;

        [DBField()]
        private string _con_old_mail_service_no;

        [DBField()]
        private string _con_title;

        [DBField()]
        private string _con_rd_paper_file_text;

        [DBField()]
        private string _con_rcm_paper_file_text;

        [DBField()]
        private int? _con_base_office;

        [DBField()]
        private string _con_base_office_name;

        [DBField()]
        private int? _region_id;

        [DBField()]
        private int? _con_lodgement_office;

        [DBField()]
        private string _con_lodgement_office_name;

        [DBField()]
        private int? _con_active_sequence;

        [DBField()]
        private int? _ct_key;

        [DBField()]
        private string _con_rd_ref_text;

        [DBField()]
        private DateTime? _con_last_service_review;

        [DBField()]
        private DateTime? _con_last_delivery_check;

        [DBField()]
        private DateTime? _con_last_work_msrmnt_check;

        [DBField()]
        private int? _con_lngth_sealed_road;

        [DBField()]
        private int? _con_lngth_unsealed_road;

        [DBField()]
        private DateTime? _con_date_terminated;

        [DBField()]
        private string _bo_picklist;

        [DBField()]
        private string _lo_picklist;

        [DBField()]
        private int? _ac_id;

        [DBField()]
        private string _message_for_invoice;

        [DBField()]
        private int? _pbu_id;

        [DBField()]
        private string _con_base_office_type;

        [DBField()]
        private string _con_lodgement_office_type;

        public virtual int? ContractNo
        {
            get
            {
                CanReadProperty("ContractNo", true);
                return _contract_no;
            }
            set
            {
                CanWriteProperty("ContractNo", true);
                if (_contract_no != value)
                {
                    _contract_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RgCode
        {
            get
            {
                CanReadProperty("RgCode", true);
                return _rg_code;
            }
            set
            {
                CanWriteProperty("RgCode", true);
                if (_rg_code != value)
                {
                    _rg_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConOldMailServiceNo
        {
            get
            {
                CanReadProperty("ConOldMailServiceNo", true);
                return _con_old_mail_service_no;
            }
            set
            {
                CanWriteProperty("ConOldMailServiceNo", true);
                if (_con_old_mail_service_no != value)
                {
                    _con_old_mail_service_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConTitle
        {
            get
            {
                CanReadProperty("ConTitle", true);
                return _con_title;
            }
            set
            {
                CanWriteProperty("ConTitle", true);
                if (_con_title != value)
                {
                    _con_title = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConRdPaperFileText
        {
            get
            {
                CanReadProperty("ConRdPaperFileText", true);
                return _con_rd_paper_file_text;
            }
            set
            {
                CanWriteProperty("ConRdPaperFileText", true);
                if (_con_rd_paper_file_text != value)
                {
                    _con_rd_paper_file_text = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConRcmPaperFileText
        {
            get
            {
                CanReadProperty("ConRcmPaperFileText", true);
                return _con_rcm_paper_file_text;
            }
            set
            {
                CanWriteProperty("ConRcmPaperFileText", true);
                if (_con_rcm_paper_file_text != value)
                {
                    _con_rcm_paper_file_text = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ConBaseOffice
        {
            get
            {
                CanReadProperty("ConBaseOffice", true);
                return _con_base_office;
            }
            set
            {
                CanWriteProperty("ConBaseOffice", true);
                if (_con_base_office != value)
                {
                    _con_base_office = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConBaseOfficeName
        {
            get
            {
                CanReadProperty("ConBaseOfficeName", true);
                return _con_base_office_name;
            }
            set
            {
                CanWriteProperty("ConBaseOfficeName", true);
                if (_con_base_office_name != value)
                {
                    _con_base_office_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RegionId
        {
            get
            {
                CanReadProperty("RegionId", true);
                return _region_id;
            }
            set
            {
                CanWriteProperty("RegionId", true);
                if (_region_id != value)
                {
                    _region_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ConLodgementOffice
        {
            get
            {
                CanReadProperty("ConLodgementOffice", true);
                return _con_lodgement_office;
            }
            set
            {
                CanWriteProperty("ConLodgementOffice", true);
                if (_con_lodgement_office != value)
                {
                    _con_lodgement_office = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConLodgementOfficeName
        {
            get
            {
                CanReadProperty("ConLodgementOfficeName", true);
                return _con_lodgement_office_name;
            }
            set
            {
                CanWriteProperty("ConLodgementOfficeName", true);
                if (_con_lodgement_office_name != value)
                {
                    _con_lodgement_office_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ConActiveSequence
        {
            get
            {
                CanReadProperty("ConActiveSequence", true);
                return _con_active_sequence;
            }
            set
            {
                CanWriteProperty("ConActiveSequence", true);
                if (_con_active_sequence != value)
                {
                    _con_active_sequence = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CtKey
        {
            get
            {
                CanReadProperty("CtKey", true);
                return _ct_key;
            }
            set
            {
                CanWriteProperty("CtKey", true);
                if (_ct_key != value)
                {
                    _ct_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConRdRefText
        {
            get
            {
                CanReadProperty("ConRdRefText", true);
                return _con_rd_ref_text;
            }
            set
            {
                CanWriteProperty("ConRdRefText", true);
                if (_con_rd_ref_text != value)
                {
                    _con_rd_ref_text = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? ConLastServiceReview
        {
            get
            {
                CanReadProperty("ConLastServiceReview", true);
                return _con_last_service_review;
            }
            set
            {
                CanWriteProperty("ConLastServiceReview", true);
                if (_con_last_service_review != value)
                {
                    _con_last_service_review = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? ConLastDeliveryCheck
        {
            get
            {
                CanReadProperty("ConLastDeliveryCheck", true);
                return _con_last_delivery_check;
            }
            set
            {
                CanWriteProperty("ConLastDeliveryCheck", true);
                if (_con_last_delivery_check != value)
                {
                    _con_last_delivery_check = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? ConLastWorkMsrmntCheck
        {
            get
            {
                CanReadProperty("ConLastWorkMsrmntCheck", true);
                return _con_last_work_msrmnt_check;
            }
            set
            {
                CanWriteProperty("ConLastWorkMsrmntCheck", true);
                if (_con_last_work_msrmnt_check != value)
                {
                    _con_last_work_msrmnt_check = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ConLngthSealedRoad
        {
            get
            {
                CanReadProperty("ConLngthSealedRoad", true);
                return _con_lngth_sealed_road;
            }
            set
            {
                CanWriteProperty("ConLngthSealedRoad", true);
                if (_con_lngth_sealed_road != value)
                {
                    _con_lngth_sealed_road = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ConLngthUnsealedRoad
        {
            get
            {
                CanReadProperty("ConLngthUnsealedRoad", true);
                return _con_lngth_unsealed_road;
            }
            set
            {
                CanWriteProperty("ConLngthUnsealedRoad", true);
                if (_con_lngth_unsealed_road != value)
                {
                    _con_lngth_unsealed_road = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? ConDateTerminated
        {
            get
            {
                CanReadProperty("ConDateTerminated", true);
                return _con_date_terminated;
            }
            set
            {
                CanWriteProperty("ConDateTerminated", true);
                if (_con_date_terminated != value)
                {
                    _con_date_terminated = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool BoPicklist
        {
            get
            {
                CanReadProperty("BoPicklist", true);
                return _bo_picklist == "Y";
            }
            set
            {
                CanWriteProperty("BoPicklist", true);
                string new_value = value ? "Y" : "N";
                if (_bo_picklist != new_value)
                {
                    _bo_picklist = new_value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool LoPicklist
        {
            get
            {
                CanReadProperty("LoPicklist", true);
                return _lo_picklist == "Y";
            }
            set
            {
                CanWriteProperty("LoPicklist", true);
                string new_value = value ? "Y" : "N";
                if (_lo_picklist != new_value)
                {
                    _lo_picklist = new_value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcId
        {
            get
            {
                CanReadProperty("AcId", true);
                return _ac_id;
            }
            set
            {
                CanWriteProperty("AcId", true);
                if (_ac_id != value)
                {
                    _ac_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string MessageForInvoice
        {
            get
            {
                CanReadProperty("MessageForInvoice", true);
                return _message_for_invoice;
            }
            set
            {
                CanWriteProperty("MessageForInvoice", true);
                if (_message_for_invoice != value)
                {
                    _message_for_invoice = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PbuId
        {
            get
            {
                CanReadProperty("PbuId", true);
                return _pbu_id;
            }
            set
            {
                CanWriteProperty("PbuId", true);
                if (_pbu_id != value)
                {
                    _pbu_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConBaseOfficeType
        {
            get
            {
                CanReadProperty("ConBaseOfficeType", true);
                return _con_base_office_type;
            }
            set
            {
                CanWriteProperty("ConBaseOfficeType", true);
                if (_con_base_office_type != value)
                {
                    _con_base_office_type = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConLodgementOfficeType
        {
            get
            {
                CanReadProperty("ConLodgementOfficeType", true);
                return _con_lodgement_office_type;
            }
            set
            {
                CanWriteProperty("ConLodgementOfficeType", true);
                if (_con_lodgement_office_type != value)
                {
                    _con_lodgement_office_type = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool CtKeyEnabled
        {
            get
            {
                CanReadProperty("CtKeyEnabled", true);
                return !(_contract_no > 0);
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}", _contract_no);
        }
        #endregion

        #region Factory Methods
        public static Contract NewContract(int? in_Contract)
        {
            return Create(in_Contract);
        }

        public static Contract[] GetAllContract(int? in_Contract)
        {
            return Fetch(in_Contract).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_Contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Contract", in_Contract);
                    cm.CommandText = "sp_getcontractodps";
                    List<Contract> _list = new List<Contract>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Contract instance = new Contract();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._rg_code = GetValueFromReader<Int32?>(dr, 1);
                            instance._con_old_mail_service_no = GetValueFromReader<String>(dr, 2);
                            instance._con_title = GetValueFromReader<String>(dr, 3);
                            instance._con_rd_paper_file_text = GetValueFromReader<String>(dr, 4);
                            instance._con_rcm_paper_file_text = GetValueFromReader<String>(dr, 5);
                            instance._con_base_office = GetValueFromReader<Int32?>(dr, 6);
                            instance._con_base_office_name = GetValueFromReader<String>(dr, 7);
                            instance._region_id = GetValueFromReader<Int32?>(dr, 8);
                            instance._con_lodgement_office = GetValueFromReader<Int32?>(dr, 9);
                            instance._con_lodgement_office_name = GetValueFromReader<String>(dr, 10);
                            instance._con_active_sequence = GetValueFromReader<Int32?>(dr, 11);
                            instance._ct_key = GetValueFromReader<Int32?>(dr, 12);
                            instance._con_rd_ref_text = GetValueFromReader<String>(dr, 13);
                            instance._con_last_service_review = GetValueFromReader<DateTime?>(dr, 14);
                            instance._con_last_delivery_check = GetValueFromReader<DateTime?>(dr, 15);
                            instance._con_last_work_msrmnt_check = GetValueFromReader<DateTime?>(dr, 16);
                            instance._con_lngth_sealed_road = GetValueFromReader<Int32?>(dr, 17);
                            instance._con_lngth_unsealed_road = GetValueFromReader<Int32?>(dr, 18);
                            instance._con_date_terminated = GetValueFromReader<DateTime?>(dr, 19);
                            instance._bo_picklist = GetValueFromReader<String>(dr, 20);
                            instance._lo_picklist = GetValueFromReader<String>(dr, 21);
                            instance._ac_id = GetValueFromReader<Int32?>(dr, 22);
                            instance._message_for_invoice = GetValueFromReader<String>(dr, 23);
                            instance._pbu_id = GetValueFromReader<Int32?>(dr, 24);
                            instance._con_base_office_type = GetValueFromReader<String>(dr, 25);
                            instance._con_lodgement_office_type = GetValueFromReader<String>(dr, 26);
                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        list = _list.ToArray();
                    }
                }
            }
        }

        [ServerMethod()]
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "contract", ref pList))
                {
                    cm.CommandText += " WHERE  contract.contract_no = @contract_no";

                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                // reinitialize original key/value list
                StoreInitialValues();
            }
        }
        [ServerMethod()]
        private void InsertEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateInsertCommandText(cm, "contract", pList))
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                StoreInitialValues();
            }
        }
        [ServerMethod()]
        private void DeleteEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    DbCommand cm = cn.CreateCommand();
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    cm.CommandText = "DELETE FROM contract WHERE " +
                    "contract.contract_no = @contract_no ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }

        #endregion

        [ServerMethod()]
        private void CreateEntity(int? contract_no)
        {
            _contract_no = contract_no;
        }
    }
}
