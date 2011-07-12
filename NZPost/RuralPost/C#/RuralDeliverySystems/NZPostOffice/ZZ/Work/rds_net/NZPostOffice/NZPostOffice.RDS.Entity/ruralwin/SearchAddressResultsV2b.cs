using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // TJB  RPCR_026  July-2011
    // Added seq_num

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

    public class SearchAddressResultsV2b : Entity<SearchAddressResultsV2b>
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

        [DBField()]
        private int? _seq_num;

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

        /*?
		    // needs to implement compute expression manually:
			// compute control name=[multiple_prime]
			//IF(road_id[-1] = road_id AND len(trim(adr_num[-1])) >; 0 AND len(trim(adr_num)) >; 0 AND adr_num[-1] = adr_num AND tc_id[-1] = tc_id AND adr_rd_no[-1] =  adr_rd_no AND adr_id[-1] = adr_id, '-', '')
               
			// needs to implement compute expression manually:
			// compute control name=[indicator]
			//IF(road_id[-1] = road_id AND len(trim(adr_num[-1])) >; 0 AND len(trim(adr_num)) >; 0 AND adr_num[-1] = adr_num AND tc_id[-1] = tc_id AND adr_rd_no[-1] =  adr_rd_no AND adr_id[-1] <;>; adr_id, '?, '')
           */
        private string _multiple_prime;
        public virtual string MultiplePrime
        {
            get
            {
                CanReadProperty("MultiplePrime", true);
                return _multiple_prime;
            }
            set
            {
                CanWriteProperty("MultiplePrime", true);
                if (_multiple_prime != value)
                {
                    _multiple_prime = value;
                    PropertyHasChanged();
                }
            }
        }
        private string _indicator;
        public virtual string Indicator
        {
            get
            {
                CanReadProperty("Indicator", true);
                return _indicator;
            }
            set
            {
                CanWriteProperty("Indicator", true);
                if (Indicator != value)
                {
                    _indicator = value;
                    PropertyHasChanged();
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[primary_contract]
        public virtual string PrimaryContract
        {
            get
            {
                CanReadProperty(true);
                //if( isNull(cust_initials) OR Len(Trim(cust_initials))<;=0, cust_surname_company,  cust_surname_company + ', ' + cust_initials )
                return _cust_initials == null || _cust_initials.Trim().Length <= 0 ? _cust_surname_company : (_cust_surname_company + "," + _cust_initials);
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}", _adr_id);
        }
        #endregion

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

        #region Factory Methods
        public static SearchAddressResultsV2b NewSearchAddressResultsV2b(string in_AdrNum, string in_roadName, int? in_roadType, int? in_roadSuffix, string in_Suburb, string in_Town, int? in_Contract, string in_RDNo, string in_Surname, string in_Initials, string in_UI_UserId, int? in_ComponentId, int? in_rd_contract, int? in_dpid)
        {
            return Create(in_AdrNum, in_roadName, in_roadType, in_roadSuffix, in_Suburb, in_Town, in_Contract, in_RDNo, in_Surname, in_Initials, in_UI_UserId, in_ComponentId, in_rd_contract, in_dpid);
        }

        public static SearchAddressResultsV2b[] GetAllSearchAddressResultsV2b(string in_AdrNum, string in_roadName, int? in_roadType, int? in_roadSuffix, string in_Suburb, string in_Town, int? in_Contract, string in_RDNo, string in_Surname, string in_Initials, string in_UI_UserId, int? in_ComponentId, int? in_rd_contract, int? in_dpid)
        {
            return Fetch(in_AdrNum, in_roadName, in_roadType, in_roadSuffix, in_Suburb, in_Town, in_Contract, in_RDNo, in_Surname, in_Initials, in_UI_UserId, in_ComponentId, in_rd_contract, in_dpid).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(string in_AdrNum, string in_roadName, int? in_roadType, int? in_roadSuffix, 
            string in_Suburb, string in_Town, int? in_Contract, string in_RDNo, string in_Surname, 
            string in_Initials, string in_UI_UserId, int? in_ComponentId, int? in_rd_contract, int? in_dpid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    // TJB RD7_0042 Feb-2010: Changed 150 --> 200
                    //     Occasional unexplained crashes; assumed to be due to timeout
                    cm.CommandTimeout = 200;

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_AdrNum", in_AdrNum);
                    pList.Add(cm, "in_roadName", in_roadName);
                    pList.Add(cm, "in_roadType", in_roadType);
                    pList.Add(cm, "in_roadSuffix", in_roadSuffix);
                    pList.Add(cm, "in_Suburb", in_Suburb);
                    pList.Add(cm, "in_Town", in_Town);
                    pList.Add(cm, "in_Contract", in_Contract);
                    pList.Add(cm, "in_RDNo", in_RDNo);
                    pList.Add(cm, "in_Surname", in_Surname);
                    pList.Add(cm, "in_Initials", in_Initials);
                    pList.Add(cm, "in_UI_UserId", in_UI_UserId);
                    pList.Add(cm, "in_ComponentId", in_ComponentId);
                    pList.Add(cm, "in_rd_contract", in_rd_contract);
                    pList.Add(cm, "in_dpid", in_dpid);
                    cm.CommandText = "rd.sp_SearchForAddress_v2b";


                    List<SearchAddressResultsV2b> _list = new List<SearchAddressResultsV2b>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        // TJB RD7_0042 Feb-2010
                        //   Tried 'try' block for debugging; disabled for now ...
                        // try
                        // {
                            while (dr.Read())
                            {
                                SearchAddressResultsV2b instance = new SearchAddressResultsV2b();
                                instance._adr_id = GetValueFromReader<int?>(dr, 0);
                                instance._cust_id = GetValueFromReader<int?>(dr, 1);
                                instance._cust_surname_company = GetValueFromReader<string>(dr, 2);
                                instance._cust_initials = GetValueFromReader<string>(dr, 3);
                                instance._adr_num = GetValueFromReader<string>(dr, 4);
                                instance._road_name = GetValueFromReader<string>(dr, 5);
                                instance._sl_id = GetValueFromReader<int?>(dr, 6);
                                instance._tc_id = GetValueFromReader<int?>(dr, 7);
                                instance._adr_rd_no = GetValueFromReader<string>(dr, 8);
                                instance._road_id = GetValueFromReader<int?>(dr, 9);
                                instance._adr_unit = GetValueFromReader<string>(dr, 10);
                                instance._adr_no = GetValueFromReader<string>(dr, 11);
                                instance._adr_alpha = GetValueFromReader<string>(dr, 12);
                                instance._seq_num = GetValueFromReader<int?>(dr, 13);

                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                            list = _list.ToArray();
                        // }
                        // catch (Exception e)
                        // {
                        //     _sqlerrtext = e.Message;
                        // }
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
