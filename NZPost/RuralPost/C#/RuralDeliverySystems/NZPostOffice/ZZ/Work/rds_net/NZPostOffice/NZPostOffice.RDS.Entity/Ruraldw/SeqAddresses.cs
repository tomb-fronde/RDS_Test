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
    // Added cust_id and cust_stripmaker_seq to retrieved values.
    // Removed UpdateEntity, DeleteEntity and InsertEntity (they are unused)
    // Changed fetch to use (new) stored procedure rd.sp_getSeqAddresses
    //
    // TJB  RPCR_026  Aug-2011: Release fixups
    // Missed changing unit/number character from "/" to "-"
    //
    // TJB  Jan-2011  Sequencing review
    // Modified GetAllSeqAddresses, FetchEntity
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
    [MapInfo("customer", "_customer", "")]
    [MapInfo("cust_surname_company", "_cust_surname_company", "address")]
    [MapInfo("cust_initials", "_cust_initials", "address")]
    [MapInfo("seq_num", "_seq_num", "address")]
    [MapInfo("sequence", "_sequence","")]
    [MapInfo("road_name_id", "_road_name_id", "address")]
    [MapInfo("adr_unit", "_adr_unit", "address")]
    [MapInfo("adr_no", "_adr_no", "address")]
    [MapInfo("contract_no", "_contract_no", "address")]
    [MapInfo("cust_case_name", "_cust_case_name", "rds_customer")]
    [MapInfo("cust_slot_allocation", "_cust_slot_allocation", "rds_customer")]
    [MapInfo("cust_id", "_cust_id", "rds_customer")]
    [MapInfo("cust_stripmaker_seq", "_cust_stripmaker_seq", "rds_customer")]

    [System.Serializable()]

    public class SeqAddresses : Entity<SeqAddresses>
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

//------------------------------------------------------------------------
        // Need to implement compute expression manually:
        // compute control name=[sequence_no]
        private int _sequence_no;
        public virtual int SequenceNo
        {
            get
            {
                CanReadProperty("SequenceNo", true);
                return _sequence_no;
            }
            set
            {
                _sequence_no = value;
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }

        #endregion

        #region Factory Methods
        public static SeqAddresses NewSeqAddresses2(int? al_contract_no)
        {
            return Create(al_contract_no);
        }

        public static SeqAddresses[] GetAllSeqAddresses(int? al_contract_no)
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
            //
            // TJB  RPCR_026  Aug-2011: Release fixups
            // Missed changing unit/number character from "/" to "-" for 2nd
            // part of the union.

            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    // TJB  RD7_0039  Sept2009:  Added timeout
                    cm.CommandTimeout = 120;
                    
                    // TJB  RPCR_077  May-2016
                    // Changed fetch to use (new) stored procedure rd.sp_getSeqAddresses
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_getSeqAddresses";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_contract_no", al_contract_no);
                    
                    List<SeqAddresses> _list = new List<SeqAddresses>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            SeqAddresses instance = new SeqAddresses();
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
