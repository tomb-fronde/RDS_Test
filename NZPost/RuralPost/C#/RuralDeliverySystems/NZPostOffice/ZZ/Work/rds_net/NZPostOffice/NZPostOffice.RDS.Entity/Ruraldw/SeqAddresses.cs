using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
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
    [MapInfo("cust_case_name", "_cust_case_name", "")]
    [MapInfo("cust_slot_allocation", "_cust_slot_allocation", "")]

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
                return _cust_case_name;
            }
        }

        public virtual int? CustSlotAllocation
        {
            get
            {
                return _cust_slot_allocation;
            }
        }

        // needs to implement compute expression manually:
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
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    // TJB  RD7_0039  Sept2009:  Added timeout
                    cm.CommandTimeout = 120;
                    cm.CommandText = "select adr.adr_id, "
                                   + "       (CASE WHEN adr.adr_unit is null THEN '' ELSE adr.adr_unit+'/' END)  "
                                   + "             + adr.adr_no as adr_num, "
                                   + "       adr.adr_alpha as adr_alpha, "
                                   + "       (CASE WHEN adr.adr_unit is null THEN '' ELSE adr.adr_unit+'/' END)  "
                                   + "             + adr.adr_no + isnull(adr.adr_alpha,'') as adr_num_alpha, "
                                   + "       road.road_name "
                                   + "               + (CASE WHEN road_type.rt_name is null   THEN '' ELSE ' '+road_type.rt_name end)  "
                                   + "               + (CASE WHEN road_suffix.rs_name is null THEN '' ELSE ' '+road_suffix.rs_name END) "
                                   + "            as road_name, "
                                   + "       (CASE WHEN rc.cust_surname_company is null "
                                   + "             THEN rc.cust_initials "
                                   + "             ELSE (CASE WHEN rc.cust_initials is null  OR rc.cust_initials = ''  "
                                   + "                        THEN rc.cust_surname_company  "
                                   + "                        ELSE rc.cust_surname_company + ', '+rc.cust_initials END)  "
                                   + "             END)   as customer, "
                                   + "       rc.cust_surname_company as cust_surname_company, "
                                   + "       rc.cust_initials as cust_initials, "
                                   + "       adr.seq_num as seq_num, "
                                   + "       sequence = null, "
                                   + "       0 as road_name_id, "
                                   + "       adr.adr_unit as adr_unit, "
                                   + "       convert(int,adr.adr_no) as adr_no, "
                                   + "       adr.contract_no as contract_no "
                                   + "     , rc.cust_case_name "
                                   + "     , rc.cust_slot_allocation "
                                   + "  from address adr  "
                                   + "               left outer join customer_address_moves cam "
                                   + "                    on cam.adr_id = adr.adr_id "
                                   + "                   and cam.move_out_date is null "
                                   + "               left outer join rds_customer rc "
                                   + "                    on rc.cust_id = cam.cust_id "
                                   + "      , road LEFT OUTER JOIN road_type "
                                   + "                  ON road_type.rt_id = road.rt_id "
                                   + "             LEFT OUTER JOIN road_suffix "
                                   + "                  ON road_suffix.rs_id = road.rs_id "
                                   + " where adr.seq_num is not null "
                                   + "   and adr.road_id = road.road_id "
                                   + "   and (cam.cust_id is not null  "
                                   + "        and (rc.cust_surname_company != 'Dummy' OR rc.cust_initials is not null)) "
                                   + "   and rc.master_cust_id is null "
                                   + "   and adr.contract_no = @al_contract_no "
                                   + "UNION "
                                   + "select adr.adr_id, "
                                   + "       (CASE WHEN adr.adr_unit is null THEN '' ELSE adr.adr_unit+'/' END)  "
                                   + "             + adr.adr_no as adr_num, "
                                   + "       adr.adr_alpha as adr_alpha, "
                                   + "       (CASE WHEN adr.adr_unit is null THEN '' ELSE adr.adr_unit+'/' END)  "
                                   + "             + adr.adr_no + isnull(adr.adr_alpha,'') as adr_num_alpha, "
                                   + "       road.road_name "
                                   + "               + (CASE WHEN road_type.rt_name is null   THEN '' ELSE ' '+road_type.rt_name end)  "
                                   + "               + (CASE WHEN road_suffix.rs_name is null THEN '' ELSE ' '+road_suffix.rs_name END) "
                                   + "            as road_name, "
                                   + "       null as customer, "
                                   + "       rc.cust_surname_company as cust_surname_company, "
                                   + "       rc.cust_initials as cust_initials, "
                                   + "       adr.seq_num as seq_num, "
                                   + "       sequence = null, "
                                   + "       0 as road_name_id, "
                                   + "       adr.adr_unit as adr_unit, "
                                   + "       convert(int,adr.adr_no) as adr_no, "
                                   + "       adr.contract_no as contract_no "
                                   + "     , rc.cust_case_name "
                                   + "     , rc.cust_slot_allocation "
                                   + "  from address adr  "
                                   + "               left outer join customer_address_moves cam "
                                   + "                    on cam.adr_id = adr.adr_id "
                                   + "                   and cam.move_out_date is null "
                                   + "               left outer join rds_customer rc "
                                   + "                    on rc.cust_id = cam.cust_id "
                                   + "      , road LEFT OUTER JOIN road_type "
                                   + "                  ON road_type.rt_id = road.rt_id "
                                   + "             LEFT OUTER JOIN road_suffix "
                                   + "                  ON road_suffix.rs_id = road.rs_id "
                                   + " where adr.seq_num is not null "
                                   + "   and adr.road_id = road.road_id "
                                   + "   and (cam.cust_id is null or rc.cust_surname_company = 'Dummy') "
                                   + "   and adr.contract_no = @al_contract_no "
                        ;
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
                int? t1 = _adr_id;
                int? t2 = t1;
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "address", ref pList))
                {
                    cm.CommandText += " WHERE  address.contract_no = @adr_id ";

                    pList.Add(cm, "adr_id", GetInitialValue("_adr_id"));
//                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                // reinitialize original key/value list
                StoreInitialValues();
                MarkOld();
            }
        }

        [ServerMethod()]
        private void InsertEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                int? t1 = _adr_id;
                int? t2 = t1;

                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateInsertCommandText(cm, "address", pList))
                {
//                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                StoreInitialValues();
            }
        }
        [ServerMethod()]
        private void DeleteEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                int? t1 = _adr_id;
                int? t2 = t1;
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    DbCommand cm = cn.CreateCommand();
                    cm.Transaction = tr;

                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "adr_id", GetInitialValue("_adr_id"));

                    cm.CommandText = "DELETE FROM address "
                                    + "WHERE address.contract_no = @adr_id ";

//                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
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
