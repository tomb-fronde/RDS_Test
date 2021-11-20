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
    [MapInfo("adr_id", "_adr_id", "")]
    [MapInfo("cust_id", "_cust_id", "")]
    [MapInfo("cust_surname_company", "_cust_surname_company", "")]
    [MapInfo("cust_initials", "_cust_initials", "")]
    [MapInfo("adr_num", "_adr_num", "")]
    [MapInfo("road_name", "_road_name", "")]
    [MapInfo("sl_id", "_sl_id", "")]
    [MapInfo("tc_id", "_tc_id", "")]
    [MapInfo("adr_rd_no", "_adr_rd_no", "")]
    [MapInfo("road_id", "_road_id", "")]
    [MapInfo("adr_unit", "_adr_unit", "")]
    [MapInfo("adr_no", "_adr_no", "")]
    [MapInfo("adr_alpha", "_adr_alpha", "")]
    [System.Serializable()]

    public class SearchAddressResults : Entity<SearchAddressResults>
    {
        #region Business Methods
        [DBField()]
        private int? _adr_id;

        [DBField()]
        private int? _cust_id;

        [DBField()]
        private string _cust_surname_company;

        [DBField()]
        private string _cust_initials;

        [DBField()]
        private string _adr_num;

        [DBField()]
        private string _road_name;

        [DBField()]
        private int? _sl_id;

        [DBField()]
        private int? _tc_id;

        [DBField()]
        private string _adr_rd_no;

        [DBField()]
        private int? _road_id;

        [DBField()]
        private string _adr_unit;

        [DBField()]
        private string _adr_no;

        [DBField()]
        private string _adr_alpha;


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

        public virtual int? SlId
        {
            get
            {
                CanReadProperty("SlId", true);
                return _sl_id;
            }
            set
            {
                CanWriteProperty("SlId", true);
                if (_sl_id != value)
                {
                    _sl_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? TcId
        {
            get
            {
                CanReadProperty("TcId", true);
                return _tc_id;
            }
            set
            {
                CanWriteProperty("TcId", true);
                if (_tc_id != value)
                {
                    _tc_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AdrRdNo
        {
            get
            {
                CanReadProperty("AdrRdNo", true);
                return _adr_rd_no;
            }
            set
            {
                CanWriteProperty("AdrRdNo", true);
                if (_adr_rd_no != value)
                {
                    _adr_rd_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RoadId
        {
            get
            {
                CanReadProperty("RoadId", true);
                return _road_id;
            }
            set
            {
                CanWriteProperty("RoadId", true);
                if (_road_id != value)
                {
                    _road_id = value;
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
        // needs to implement compute expression manually:
        // compute control name=[multiple_prime]
        //?iF(road_id[-1] = road_id AND len(trim(adr_num[-1])) >; 0 AND len(trim(adr_num)) >; 0 AND adr_num[-1] = adr_num AND tc_id[-1] = tc_id AND adr_rd_no[-1] =  adr_rd_no AND adr_id[-1] = adr_id, '-', '')

        // needs to implement compute expression manually:
        // compute control name=[indicator]
        //?iF(road_id[-1] = road_id AND len(trim(adr_num[-1])) >; 0 AND len(trim(adr_num)) >; 0 AND adr_num[-1] = adr_num AND tc_id[-1] = tc_id AND adr_rd_no[-1] =  adr_rd_no AND adr_id[-1] <;>; adr_id, '?, '')

        // needs to implement compute expression manually:
        // compute control name=[primary_contract]
        //if( isNull(cust_initials) OR Len(Trim(cust_initials))<;=0, cust_surname_company,  cust_surname_company + ', ' + cust_initials )
        public virtual string PrimaryContract
        {
            get
            {
                CanReadProperty("PrimaryContract", true);
                return ( _cust_initials == null || _cust_initials.Trim().Length <=0 ? _cust_surname_company :  _cust_surname_company + ", " + _cust_initials );
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}", _adr_id);
        }
        #endregion

        #region Factory Methods
        public static SearchAddressResults NewSearchAddressResults(string in_AdrNum, int? in_RoadId, int? in_SuburbId, int? in_TownId, int? in_Contract, string in_RDNo, string in_Surname, string in_Initials, string in_UI_UserId, int? in_ComponentId)
        {
            return Create(in_AdrNum, in_RoadId, in_SuburbId, in_TownId, in_Contract, in_RDNo, in_Surname, in_Initials, in_UI_UserId, in_ComponentId);
        }

        public static SearchAddressResults[] GetAllSearchAddressResults(string in_AdrNum, int? in_RoadId, int? in_SuburbId, int? in_TownId, int? in_Contract, string in_RDNo, string in_Surname, string in_Initials, string in_UI_UserId, int? in_ComponentId)
        {
            return Fetch(in_AdrNum, in_RoadId, in_SuburbId, in_TownId, in_Contract, in_RDNo, in_Surname, in_Initials, in_UI_UserId, in_ComponentId).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(string in_AdrNum, int? in_RoadId, int? in_SuburbId, int? in_TownId, int? in_Contract, string in_RDNo, string in_Surname, string in_Initials, string in_UI_UserId, int? in_ComponentId)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_AdrNum", in_AdrNum);
                    pList.Add(cm, "in_RoadId", in_RoadId);
                    pList.Add(cm, "in_SuburbId", in_SuburbId);
                    pList.Add(cm, "in_TownId", in_TownId);
                    pList.Add(cm, "in_Contract", in_Contract);
                    pList.Add(cm, "in_RDNo", in_RDNo);
                    pList.Add(cm, "in_Surname", in_Surname);
                    pList.Add(cm, "in_Initials", in_Initials);
                    pList.Add(cm, "in_UI_UserId", in_UI_UserId);
                    pList.Add(cm, "in_ComponentId", in_ComponentId);
                    cm.CommandText = "rd.sp_searchforaddress";
                    List<SearchAddressResults> _list = new List<SearchAddressResults>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            SearchAddressResults instance = new SearchAddressResults();
                            instance._adr_id = GetValueFromReader<Int32?>(dr,0);
                            instance._cust_id = GetValueFromReader<Int32?>(dr,1);
                            instance._cust_surname_company = GetValueFromReader<String>(dr,2);
                            instance._cust_initials = GetValueFromReader<String>(dr,3);
                            instance._adr_num = GetValueFromReader<String>(dr,4);
                            instance._road_name = GetValueFromReader<String>(dr,5);
                            instance._sl_id = GetValueFromReader<Int32?>(dr,6);
                            instance._tc_id = GetValueFromReader<Int32?>(dr,7);
                            instance._adr_rd_no = GetValueFromReader<String>(dr,8);
                            instance._road_id = GetValueFromReader<Int32?>(dr,9);
                            instance._adr_unit = GetValueFromReader<String>(dr,10);
                            instance._adr_no = GetValueFromReader<String>(dr,11);
                            instance._adr_alpha = GetValueFromReader<String>(dr,12);
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
        private void CreateEntity(int? adr_id)
        {
            _adr_id = adr_id;
        }
    }
}
