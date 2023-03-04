using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  RPCR_077  May-2016
    // Added variables to match those in SeqAddresses
    // Replaced Fetch query with adapted one from SeqAddresses
    // Changed fetch to use (new) stored procedure rd.sp_getUnseqAddresses
    //    based on the SeqAddresses query.
    //
    // TJB  Jan-2011  Sequencing review
    // Modified GetAllUnseqAddresses, FetchEntity
    // Remove reference to address_frequency_sequence table
    // Add seq_num from address table
    
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("adr_id", "_adr_id", "address")]
    [MapInfo("adr_num", "_adr_num", "address")]
    [MapInfo("adr_alpha", "_adr_alpha", "address")]
    [MapInfo("adr_num_alpha", "_adr_num_alpha", "address")]
    [MapInfo("road_name", "_road_name", "address")]
    [MapInfo("customer", "_customer", "address")]
    [MapInfo("cust_surname_company", "_cust_surname_company", "address")]
    [MapInfo("cust_initials", "_cust_initials", "address")]
    [MapInfo("seq_num", "_seq_num", "address")]
    [MapInfo("sequence", "_sequence", "address")]
    [MapInfo("road_name_id", "_road_name_id", "address")]
    [MapInfo("adr_unit", "_adr_unit", "address")]
    [MapInfo("adr_no", "_adr_no", "address")]
    [MapInfo("contract_no", "_contract_no", "address")]
    [MapInfo("cust_case_name", "_cust_case_name", "rds_customer")]
    [MapInfo("cust_slot_allocation", "_cust_slot_allocation", "rds_customer")]
    [MapInfo("cust_id", "_cust_id", "rds_customer")]
    [MapInfo("cust_stripmaker_seq", "_cust_stripmaker_seq", "rds_customer")]
    [System.Serializable()]

    public class UnseqAddresses : Entity<UnseqAddresses>
    {
        #region Business Methods
        [DBField()]
        private int? _adr_id;

        [DBField()]
        private string _adr_num;

        [DBField()]
        private string _adr_alpha;

        [DBField()]
        private string _adr_num_alpha;

        [DBField()]
        private string _road_name;

        [DBField()]
        private string _customer;

        [DBField()]
        private string _cust_surname_company;

        [DBField()]
        private string _cust_initials;

        [DBField()]
        private int? _seq_num;

        [DBField()]
        private int? _sequence;

        [DBField()]
        private int? _road_name_id;

        [DBField()]
        private string _adr_unit;

        [DBField()]
        private string _adr_no;

        [DBField()]
        private int? _contract_no;

        [DBField()]
        private string _cust_case_name;

        [DBField()]
        private int? _cust_slot_allocation;

        [DBField()]
        private int? _cust_id;

        [DBField()]
        private int? _cust_stripmaker_seq;

//----------------------------------------------------------------------------

        public virtual int? AdrId
        {
            get
            {
                CanReadProperty("AdrId", true);
                return _adr_id;
            }
            set
            {
                CanWriteProperty("AdrId", true);
                if (_adr_id != value)
                {
                    _adr_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AdrNum
        {
            get
            {
                CanReadProperty("AdrNum", true);
                return _adr_num;
            }
            set
            {
                CanWriteProperty("AdrNum", true);
                if (_adr_num != value)
                {
                    _adr_num = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AdrAlpha
        {
            get
            {
                CanReadProperty("AdrAlpha", true);
                return _adr_alpha;
            }
            set
            {
                CanWriteProperty("AdrAlpha", true);
                if (_adr_alpha != value)
                {
                    _adr_alpha = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AdrNumAlpha
        {
            get
            {
                CanReadProperty("AdrNumAlpha", true);
                return _adr_num_alpha;
            }
            set
            {
                CanWriteProperty("AdrNumAlpha", true);
                if (_adr_num_alpha != value)
                {
                    _adr_num_alpha = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RoadName
        {
            get
            {
                CanReadProperty("RoadName", true);
                return _road_name;
            }
            set
            {
                CanWriteProperty("RoadName", true);
                if (_road_name != value)
                {
                    _road_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Customer
        {
            get
            {
                CanReadProperty("Customer", true);
                return _customer;
            }
            set
            {
                CanWriteProperty("Customer", true);
                if (_customer != value)
                {
                    _customer = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustSurnameCompany
        {
            get
            {
                CanReadProperty("CustSurnameCompany", true);
                return _cust_surname_company;
            }
            set
            {
                CanWriteProperty("CustSurnameCompany", true);
                if (_cust_surname_company != value)
                {
                    _cust_surname_company = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CustInitials
        {
            get
            {
                CanReadProperty("CustInitials", true);
                return _cust_initials;
            }
            set
            {
                CanWriteProperty("CustInitials", true);
                if (_cust_initials != value)
                {
                    _cust_initials = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? SeqNum
        {
            get
            {
                CanReadProperty("SeqNum", true);
                return _seq_num;
            }
            set
            {
                CanWriteProperty("SeqNum", true);
                if (_seq_num != value)
                {
                    _seq_num = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Sequence
        {
            get
            {
                CanReadProperty("Sequence", true);
                return _sequence;
            }
            set
            {
                CanWriteProperty("Sequence", true);
                if (_sequence != value)
                {
                    _sequence = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RoadNameId
        {
            get
            {
                CanReadProperty("RoadNameId", true);
                return _road_name_id;
            }
            set
            {
                CanWriteProperty("RoadNameId", true);
                if (_road_name_id != value)
                {
                    _road_name_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AdrUnit
        {
            get
            {
                CanReadProperty("AdrUnit", true);
                return _adr_unit;
            }
            set
            {
                CanWriteProperty("AdrUnit", true);
                if (_adr_unit != value)
                {
                    _adr_unit = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AdrNo
        {
            get
            {
                CanReadProperty("AdrNo", true);
                return _adr_no;
            }
            set
            {
                CanWriteProperty("AdrNo", true);
                if (_adr_no != value)
                {
                    _adr_no = value;
                    PropertyHasChanged();
                }
            }
        }

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

        public virtual string CustCaseName
        {
            get
            {
                CanReadProperty("CustCaseName", true);
                return _cust_case_name;
            }
            set
            {
                CanWriteProperty("CustCaseName", true);
                if (_cust_case_name != value)
                {
                    _cust_case_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CustSlotAllocation
        {
            get
            {
                CanReadProperty("CustSlotAllocation", true);
                return _cust_slot_allocation;
            }
            set
            {
                CanWriteProperty("CustSlotAllocation", true);
                if (_cust_slot_allocation != value)
                {
                    _cust_slot_allocation = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CustId
        {
            get
            {
                CanReadProperty("CustId", true);
                return _cust_id;
            }
            set
            {
                CanWriteProperty("CustId", true);
                if (_cust_id != value)
                {
                    _cust_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CustStripmakerSeq
        {
            get
            {
                CanReadProperty("CustStripmakerSeq", true);
                return _cust_stripmaker_seq;
            }
            set
            {
                CanWriteProperty("CustStripmakerSeq", true);
                if (_cust_stripmaker_seq != value)
                {
                    _cust_stripmaker_seq = value;
                    PropertyHasChanged();
                }
            }
        }

//------------------------------------------------------------------------------------

        // Need to implement compute expression manually:
        // compute control name=[adr_no_numeric]
        //?if(isNumber(adr_no), integer(adr_no), 0)
        public virtual int? AdrNoNumeric
        {
            get
            {
                CanReadProperty("AdrNoNumeric", true);
                int li_temp;
                if (_adr_no == null)
                {
                    return null;
                }
                else
                {
                    return (int.TryParse(_adr_no, out li_temp) ? System.Convert.ToInt32(_adr_no) : (_adr_no.IndexOf('-') > 0 ? System.Convert.ToInt32(_adr_no.Substring(_adr_no.IndexOf('-') + 1)) : 0));
                }
            }
            set { }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static UnseqAddresses NewUnseqAddresses(int? al_contract_no)
        {
            return Create(al_contract_no);
        }

        public static UnseqAddresses[] GetAllUnseqAddresses(int? al_contract_no)
        {
            return Fetch(al_contract_no).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? al_contract_no)
        {
            // TJB  Jan-2011  Sequencing review
            // Remove reference to address_frequency_sequence table
            // Add seq_num from address table
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 120;

                    // TJB  RPCR_077  May-2016
                    // Changed fetch to use (new) stored procedure rd.sp_getUnseqAddresses
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_getUnseqAddresses";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_contract_no", al_contract_no);
                    
                    List<UnseqAddresses> _list = new List<UnseqAddresses>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            UnseqAddresses instance = new UnseqAddresses();

                            instance._adr_id = GetValueFromReader<Int32?>(dr, 0);
                            instance._adr_num = GetValueFromReader<String>(dr, 1);
                            instance._adr_alpha = GetValueFromReader<String>(dr, 2);
                            instance._adr_num_alpha = GetValueFromReader<String>(dr, 3);
                            instance._road_name = GetValueFromReader<String>(dr, 4);

                            instance._customer = GetValueFromReader<String>(dr, 5);
                            instance._cust_surname_company = GetValueFromReader<String>(dr, 6);
                            instance._cust_initials = GetValueFromReader<String>(dr, 7);
                            instance._seq_num = GetValueFromReader<Int32?>(dr, 8);
                            instance._sequence = GetValueFromReader<Int32?>(dr, 9);
                            instance._road_name_id = GetValueFromReader<Int32?>(dr, 10);
                            instance._adr_unit = GetValueFromReader<String>(dr, 11);

                            instance._adr_no = GetValueFromReader<String>(dr, 12);
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 13);

                            instance._cust_case_name = GetValueFromReader<String>(dr, 14);
                            instance._cust_slot_allocation = GetValueFromReader<Int32?>(dr, 15);
                            instance._cust_id = GetValueFromReader<Int32?>(dr, 16);
                            instance._cust_stripmaker_seq = GetValueFromReader<Int32?>(dr, 17);

                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        list = _list.ToArray();
                    }
                }
            }
        }

        #endregion

        [ServerMethod()]
        private void CreateEntity()
        {
        }
    }
}
