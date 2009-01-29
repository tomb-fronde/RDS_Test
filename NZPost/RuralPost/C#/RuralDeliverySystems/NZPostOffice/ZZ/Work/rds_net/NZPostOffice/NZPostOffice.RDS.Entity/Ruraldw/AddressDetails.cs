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
    [MapInfo("adr_id", "_adr_id", "address")]
    [MapInfo("tc_id", "_tc_id", "address")]
    [MapInfo("road_id", "_road_id", "address")]
    [MapInfo("road_name", "_road_name", "road")]
    [MapInfo("rt_id", "_rt_id", "road")]
    [MapInfo("sl_id", "_sl_id", "address")]
    [MapInfo("contract_no", "_contract_no", "address")]
    [MapInfo("post_code_id", "_post_code_id", "address")]
    [MapInfo("post_code", "_post_code", "post_code")]
    [MapInfo("adr_rd_no", "_adr_rd_no", "address")]
    [MapInfo("adr_no", "_adr_no", "address")]
    [MapInfo("adr_alpha", "_adr_alpha", "address")]
    [MapInfo("dp_id", "_dp_id", "address")]
    [MapInfo("adr_old_delivery_days", "_adr_old_delivery_days", "address")]
    [MapInfo("adr_property_identification", "_adr_property_identification", "address")]
    [MapInfo("adr_freq", "_adr_freq", "post_code")]
    [MapInfo("adr_num", "_adr_num", "post_code")]
    [MapInfo("adr_freq_terminal", "_adr_freq_terminal", "post_code")]
    [MapInfo("adr_last_amended_date", "_adr_last_amended_date", "address")]
    [MapInfo("adr_last_amended_user", "_adr_last_amended_user", "address")]
    [MapInfo("adr_unit", "_adr_unit", "address")]
    [MapInfo("rs_id", "_rs_id", "road")]
    [MapInfo("sl_name", "_sl_name", "suburblocality")]
    [System.Serializable()]

    public class AddressDetails : Entity<AddressDetails>
    {
        #region Business Methods
        [DBField()]
        private int? _adr_id;

        [DBField()]
        private int? _tc_id;

        [DBField()]
        private int? _road_id;

        [DBField()]
        private string _road_name;

        [DBField()]
        private int? _rt_id;

        [DBField()]
        private int? _sl_id;

        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _post_code_id;

        [DBField()]
        private string _post_code;

        [DBField()]
        private string _adr_rd_no;

        [DBField()]
        private string _adr_no;

        [DBField()]
        private string _adr_alpha;

        [DBField()]
        private int? _dp_id;

        [DBField()]
        private string _adr_old_delivery_days;

        [DBField()]
        private string _adr_property_identification;

        [DBField()]
        private string _adr_freq;

        [DBField()]
        private string _adr_num;

        [DBField()]
        private string _adr_freq_terminal;

        [DBField()]
        private DateTime? _adr_last_amended_date;

        [DBField()]
        private string _adr_last_amended_user;

        [DBField()]
        private string _adr_unit;

        [DBField()]
        private int? _rs_id;

        [DBField()]
        private string _sl_name;


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

        public virtual int? RtId
        {
            get
            {
                CanReadProperty("RtId", true);
                return _rt_id;
            }
            set
            {
                CanWriteProperty("RtId", true);
                if (_rt_id != value)
                {
                    _rt_id = value;
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

        public virtual int? PostCodeId
        {
            get
            {
                CanReadProperty("PostCodeId", true);
                return _post_code_id;
            }
            set
            {
                CanWriteProperty("PostCodeId", true);
                if (_post_code_id != value)
                {
                    _post_code_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PostCode
        {
            get
            {
                CanReadProperty("PostCode", true);
                return _post_code;
            }
            set
            {
                CanWriteProperty("PostCode", true);
                if (_post_code != value)
                {
                    _post_code = value;
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

        public virtual int? DpId
        {
            get
            {
                CanReadProperty("DpId", true);
                return _dp_id;
            }
            set
            {
                CanWriteProperty("DpId", true);
                if (_dp_id != value)
                {
                    _dp_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AdrOldDeliveryDays
        {
            get
            {
                CanReadProperty("AdrOldDeliveryDays", true);
                return _adr_old_delivery_days;
            }
            set
            {
                CanWriteProperty("AdrOldDeliveryDays", true);
                if (_adr_old_delivery_days != value)
                {
                    _adr_old_delivery_days = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AdrPropertyIdentification
        {
            get
            {
                CanReadProperty("AdrPropertyIdentification", true);
                return _adr_property_identification;
            }
            set
            {
                CanWriteProperty("AdrPropertyIdentification", true);
                if (_adr_property_identification != value)
                {
                    _adr_property_identification = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AdrFreq
        {
            get
            {
                CanReadProperty("AdrFreq", true);
                return _adr_freq;
            }
            set
            {
                CanWriteProperty("AdrFreq", true);
                if (_adr_freq != value)
                {
                    _adr_freq = value;
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

        public virtual string AdrFreqTerminal
        {
            get
            {
                CanReadProperty("AdrFreqTerminal", true);
                return _adr_freq_terminal;
            }
            set
            {
                CanWriteProperty("AdrFreqTerminal", true);
                if (_adr_freq_terminal != value)
                {
                    _adr_freq_terminal = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? AdrLastAmendedDate
        {
            get
            {
                CanReadProperty("AdrLastAmendedDate", true);
                return _adr_last_amended_date;
            }
            set
            {
                CanWriteProperty("AdrLastAmendedDate", true);
                if (_adr_last_amended_date != value)
                {
                    _adr_last_amended_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AdrLastAmendedUser
        {
            get
            {
                CanReadProperty("AdrLastAmendedUser", true);
                return _adr_last_amended_user;
            }
            set
            {
                CanWriteProperty("AdrLastAmendedUser", true);
                if (_adr_last_amended_user != value)
                {
                    _adr_last_amended_user = value;
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

        public virtual int? RsId
        {
            get
            {
                CanReadProperty("RsId", true);
                return _rs_id;
            }
            set
            {
                CanWriteProperty("RsId", true);
                if (_rs_id != value)
                {
                    _rs_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string SlName
        {
            get
            {
                CanReadProperty("SlName", true);
                return _sl_name;
            }
            set
            {
                CanWriteProperty("SlName", true);
                if (_sl_name != value)
                {
                    _sl_name = value;
                    PropertyHasChanged();
                }
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[town_name]
        //LookupDisplay(tc_id)
        private string _town_name;
        public virtual string TownName
        {
            get
            {
                CanReadProperty("TownName", true);
                return _town_name;
            }
            set
            {
                // TJB  RD7_0019  Jan 2009
                //    Probably a bug but not called so not tested.  Looks like code
                //    Metex added as a place-holder but never implemented the lookup!
                //    Change code to save town name.
                //CanWriteProperty("SlName", true);
                //if (_town_name != value)
                //{
                //    _sl_name = value;
                //}
                CanWriteProperty("TownName", true);
                if (_town_name != value)
                {
                    _town_name = value;
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[title_address]
        //if(pos(lower(if(isnull(adr_property_identification), '', adr_property_identification)) , 'private')>;0, adr_property_identification + ' ', '') + if(isnull(adr_num), '', adr_num+' ') + if(isnull(road_name), '', road_name) + if(lookupdisplay(rt_id)='', '', ' '+lookupdisplay(rt_id)) + if(lookupdisplay(rs_id)='', '', ' '+lookupdisplay(rs_id)) + if(lookupdisplay(sl_id)='', '', ', ' + lookupdisplay(sl_id)) + if(lookupdisplay(tc_id)='', '', ', ' + lookupdisplay(tc_id))
        private string _title_address;
        public virtual string TitleAddress
        {
            get
            {
                CanReadProperty("TitleAddress", true);
                return _title_address;
            }
            set
            {
                // TJB  RD7_0019  Jan 2009
                //    Probably a bug but not called so not tested.  Looks like code
                //    Metex added as a place-holder but never implemented the lookup!
                //    Change code to save Title Address.
                // CanWriteProperty("SlName", true);
                // if (_title_address != value)
                // {
                //     _title_address = value;
                // }
                CanWriteProperty("TitleAddress", true);
                if (_title_address != value)
                {
                    _title_address = value;
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[days]
        //'[' + if(mid(adr_freq,8,1)='','0',  mid(adr_freq,8,1))+ ']'
        public virtual string Days
        {
            get
            {
                CanReadProperty("Days", true);
                return (_adr_freq != null) ? "[" + ((_adr_freq.Substring(7, 1) == "") ? "0" : _adr_freq.Substring(7, 1)) + "]" : "";
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[mon]
        //if(mid(adr_freq,1,1)='Y','Y','N')
        public virtual string Mon
        {
            get
            {
                CanReadProperty("Mon", true);
                return (_adr_freq != null && _adr_freq.Substring(0, 1) == "Y") ? "Y" : "N";
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[tue]
        //if(mid(adr_freq,2,1)='Y','Y','N')
        public virtual string Tue
        {
            get
            {
                CanReadProperty("Tue", true);
                return (_adr_freq != null && _adr_freq.Substring(1, 1) == "Y") ? "Y" : "N";
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[wed]
        //if(mid(adr_freq,3,1)='Y','Y','N')
        public virtual string Wed
        {
            get
            {
                CanReadProperty("Wed", true);
                return (_adr_freq != null && _adr_freq.Substring(2, 1) == "Y") ? "Y" : "N";
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[thur]
        //if(mid(adr_freq,4,1)='Y','Y','N')
        public virtual string Thur
        {
            get
            {
                CanReadProperty("Thur", true);
                return (_adr_freq != null && _adr_freq.Substring(3, 1) == "Y") ? "Y" : "N";
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[fri]
        //if(mid(adr_freq,5,1)='Y','Y','N')
        public virtual string Fri
        {
            get
            {
                CanReadProperty("Fri", true);
                return (_adr_freq != null && _adr_freq.Substring(4, 1) == "Y") ? "Y" : "N";
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[sat]
        //if(mid(adr_freq,6,1)='Y','Y','N')
        public virtual string Sat
        {
            get
            {
                CanReadProperty("Sat", true);
                return (_adr_freq != null && _adr_freq.Substring(5, 1) == "Y") ? "Y" : "N";
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[sunday]
        //if(mid(adr_freq,7,1)='Y','Y','N')
        public virtual string Sunday
        {
            get
            {
                CanReadProperty("Sunday", true);
                return (_adr_freq != null && _adr_freq.Substring(6, 1) == "Y") ? "Y" : "N";
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_1]
        //'[' + if(mid(adr_freq_terminal,8,1)='','0',  mid(adr_freq_terminal,8,1))+ ']'
        public virtual string Compute1
        {
            get
            {
                CanReadProperty("Compute1", true);
                //return (_adr_freq_terminal != null) ? "[" + ((_adr_freq_terminal.Substring(7, 1) == "")? "0" : _adr_freq_terminal.Substring(7, 1)) + "]" : "";
                return (_adr_freq_terminal != null) ? ("[" + ((_adr_freq_terminal.Substring(7, 1) == " ") ? "0" : _adr_freq_terminal.Substring(7, 1)) + "]") : "";
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_2]
        //if(mid(adr_freq_terminal,1,1)='Y','Y','N')
        public virtual string Compute2
        {
            get
            {
                CanReadProperty("Compute2", true);
                return (_adr_freq_terminal != null && _adr_freq_terminal.Substring(0, 1) == "Y") ? "Y" : "N";
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_3]
        //if(mid(adr_freq_terminal,2,1)='Y','Y','N')
        public virtual string Compute3
        {
            get
            {
                CanReadProperty("Compute3", true);
                return (_adr_freq_terminal != null && _adr_freq_terminal.Substring(1, 1) == "Y") ? "Y" : "N";
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_4]
        //if(mid(adr_freq_terminal,3,1)='Y','Y','N')
        public virtual string Compute4
        {
            get
            {
                CanReadProperty("Compute4", true);
                return (_adr_freq_terminal != null && _adr_freq_terminal.Substring(2, 1) == "Y") ? "Y" : "N";
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_5]
        //if(mid(adr_freq_terminal,4,1)='Y','Y','N')
        public virtual string Compute5
        {
            get
            {
                CanReadProperty("Compute5", true);
                return (_adr_freq_terminal != null && _adr_freq_terminal.Substring(3, 1) == "Y") ? "Y" : "N";
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_6]
        //if(mid(adr_freq_terminal,5,1)='Y','Y','N')
        public virtual string Compute6
        {
            get
            {
                CanReadProperty("Compute6", true);
                return (_adr_freq_terminal != null && _adr_freq_terminal.Substring(4, 1) == "Y") ? "Y" : "N";
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_7]
        //if(mid(adr_freq_terminal,6,1)='Y','Y','N')
        public virtual string Compute7
        {
            get
            {
                CanReadProperty("Compute7", true);
                return (_adr_freq_terminal != null && _adr_freq_terminal.Substring(5, 1) == "Y") ? "Y" : "N";
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_8]
        //if(mid(adr_freq_terminal,7,1)='Y','Y','N')
        public virtual string Compute8
        {
            get
            {
                CanReadProperty("Compute8", true);
                return (_adr_freq_terminal != null && _adr_freq_terminal.Substring(6, 1) == "Y") ? "Y" : "N";
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}", _adr_id);
        }
        #endregion

        public void SetEntityClean()
        {
            base.MarkClean();
        }

        #region Factory Methods
        public static AddressDetails NewAddressDetails(int? al_adr_id)
        {
            return Create(al_adr_id);
        }

        public static AddressDetails[] GetAllAddressDetails(int? al_adr_id)
        {
            return Fetch(al_adr_id).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? al_adr_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = @"SELECT address.adr_id,
                                              address.tc_id,
                                              address.road_id,
                                              road.road_name,
                                              road.rt_id,
                                              address.sl_id,
                                              address.contract_no,
                                              address.post_code_id,
                                              (select post_code from post_code where post_code_id = address.post_code_id) as post_code,
                                              address.adr_rd_no,
                                              address.adr_no,
                                              address.adr_alpha,
                                              address.dp_id,
                                              address.adr_old_delivery_days,
                                              address.adr_property_identification ,
                                              rd.f_getFrequency(address.adr_id, 0, 'N') as adr_freq,
                                              (CASE WHEN address.adr_unit IS NULL THEN ''+ address.adr_no + isnull(address.adr_alpha,'') ELSE address.adr_unit+'/' + address.adr_no + isnull(address.adr_alpha,'') END) as adr_num,
                                              rd.f_getFrequency(address.adr_id, address.contract_no, 'Y') as adr_freq_terminal,
                                              address.adr_last_amended_date,
                                              address.adr_last_amended_user,
                                              address.adr_unit,
                                              road.rs_id,
                                              sl_name  
                                            FROM address 
                                            left outer join road on address.road_id = road.road_id 
                                            left outer join suburblocality on address.sl_id = suburblocality.sl_id 
                                            WHERE ( address.adr_id = @al_adr_id )";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_adr_id", al_adr_id);

                    List<AddressDetails> _list = new List<AddressDetails>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            AddressDetails instance = new AddressDetails();

                            instance._adr_id = GetValueFromReader<Int32?>(dr,0);
                            instance._tc_id = GetValueFromReader<Int32?>(dr,1);
                            instance._road_id = GetValueFromReader<Int32?>(dr,2);
                            instance._road_name = GetValueFromReader<String>(dr,3);
                            instance._rt_id = GetValueFromReader<Int32?>(dr,4);

                            instance._sl_id = GetValueFromReader<Int32?>(dr,5);
                            instance._contract_no = GetValueFromReader<Int32?>(dr,6);
                            instance._post_code_id = GetValueFromReader<Int32?>(dr,7);
                            instance._post_code = GetValueFromReader<String>(dr,8);
                            instance._adr_rd_no = GetValueFromReader<String>(dr,9);

                            instance._adr_no = GetValueFromReader<String>(dr,10);
                            instance._adr_alpha = GetValueFromReader<String>(dr,11);
                            instance._dp_id = GetValueFromReader<Int32?>(dr,12);
                            instance._adr_old_delivery_days = GetValueFromReader<String>(dr,13);
                            instance._adr_property_identification = GetValueFromReader<String>(dr,14);

                            instance._adr_freq = dr.GetString(15);
                            instance._adr_num = dr.GetString(16);
                            instance._adr_freq_terminal = dr.GetString(17);
                            instance._adr_last_amended_date = dr.GetDateTime(18);
                            instance._adr_last_amended_user = dr.GetString(19);

                            instance._adr_unit = dr.GetString(20);
                            instance._rs_id = dr.GetInt32(21);
                            instance._sl_name = dr.GetString(22);

                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                    }
                    //foreach (AddressDetails instance in _list)
                    //{
                    //    cm.CommandType = CommandType.StoredProcedure;
                    //    cm.CommandText = "rd.f_getFrequency";
                    //    pList.Clear();
                    //    pList.Add(cm, "address_id", instance._adr_id);
                    //    pList.Add(cm, "pi_contract_no", 0);
                    //    pList.Add(cm, "ps_terminal", "N");
                    //    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    //    {
                    //        if (dr.Read())
                    //        {
                    //            instance._adr_freq = dr.GetString(0);
                    //        }
                    //    }
                    //    pList.Clear();
                    //    pList.Add(cm, "address_id", instance._adr_id);
                    //    pList.Add(cm, "pi_contract_no", instance._contract_no);
                    //    pList.Add(cm, "ps_terminal", "Y");
                    //    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    //    {
                    //        if (dr.Read())
                    //        {
                    //            instance._adr_freq_terminal = dr.GetString(0);
                    //        }
                    //    }
                    //}
                    list = _list.ToArray();
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
                if (GenerateUpdateCommandText(cm, "address", ref pList))
                {
                    cm.CommandText += " WHERE  address.adr_id = @adr_id ";
                    pList.Add(cm, "adr_id", GetInitialValue("_adr_id"));
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                // reinitialize original key/value list
                this.MarkClean();
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
                if (GenerateInsertCommandText(cm, "address", pList))
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                this.MarkClean();
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
                    pList.Add(cm, "adr_id", GetInitialValue("_adr_id"));
                    cm.CommandText = "DELETE FROM address WHERE " +
                    "address.adr_id = @adr_id ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
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
