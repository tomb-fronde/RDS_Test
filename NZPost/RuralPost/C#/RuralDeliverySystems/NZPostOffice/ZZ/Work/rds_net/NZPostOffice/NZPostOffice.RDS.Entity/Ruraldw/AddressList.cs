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
    [MapInfo("adr_no", "_adr_no", "address")]
    [MapInfo("adr_alpha", "_adr_alpha", "address")]
    [MapInfo("road_name", "_road_name", "suburblocality")]
    [MapInfo("road_type", "_road_type", "suburblocality")]
    [MapInfo("sl_name", "_sl_name", "suburblocality")]
    [MapInfo("tc_name", "_tc_name", "suburblocality")]
    [MapInfo("private_bag", "_private_bag", "suburblocality")]
    [MapInfo("property_id", "_property_id", "suburblocality")]
    [MapInfo("adr_unit", "_adr_unit", "suburblocality")]
    [MapInfo("adr_num", "_adr_num", "suburblocality")]
    [MapInfo("dp_id", "_dp_id", "address")]
    [System.Serializable()]

    public class AddressList : Entity<AddressList>
    {
        #region Business Methods
        [DBField()]
        private int? _adr_id;

        [DBField()]
        private string _adr_no;

        [DBField()]
        private string _adr_alpha;

        [DBField()]
        private string _road_name;

        [DBField()]
        private string _road_type;

        [DBField()]
        private string _sl_name;

        [DBField()]
        private string _tc_name;

        [DBField()]
        private string _private_bag;

        [DBField()]
        private string _property_id;

        [DBField()]
        private string _adr_unit;

        [DBField()]
        private string _adr_num;

        [DBField()]
        private int? _dp_id;


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

        public virtual string RoadType
        {
            get
            {
                CanReadProperty("RoadType", true);
                return _road_type;
            }
            set
            {
                CanWriteProperty("RoadType", true);
                if (_road_type != value)
                {
                    _road_type = value;
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

        public virtual string TcName
        {
            get
            {
                CanReadProperty("TcName", true);
                return _tc_name;
            }
            set
            {
                CanWriteProperty("TcName", true);
                if (_tc_name != value)
                {
                    _tc_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PrivateBag
        {
            get
            {
                CanReadProperty("PrivateBag", true);
                return _private_bag;
            }
            set
            {
                CanWriteProperty("PrivateBag", true);
                if (_private_bag != value)
                {
                    _private_bag = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PropertyId
        {
            get
            {
                CanReadProperty("PropertyId", true);
                return _property_id;
            }
            set
            {
                CanWriteProperty("PropertyId", true);
                if (_property_id != value)
                {
                    _property_id = value;
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

        // needs to implement compute expression manually:
        // compute control name=[address]
        //if( len(private_bag) >; 0 ,  private_bag + ', ' , '') + if(adr_no<;>;'',   Upper(adr_no)+if(adr_alpha='', ' ', adr_alpha) , '') + if(adr_alpha ='',   adr_alpha , ' ') + if(len( road_name )>;0,  road_name + if(road_type='', ', ', ''), '') + if(len(  road_type )>;0,   ' ' + road_type + ', ', '') + if(len(  property_id ) >;0,  property_id + ', ', '') +if(len(  sl_name )>;0,   sl_name + ', ', '') + if(len(  tc_name )>;0,   tc_name , '') /* road_name + '  ' +  road_type  + ',  ' +   sl_name    + ',  ' +    tc_name  */
        public virtual string Address
        {
            get
            {
                CanReadProperty("Address", true);
                //if( len(private_bag) >; 0 ,  private_bag + ', ' , '') + if(adr_no<;>;'',   Upper(adr_no)+if(adr_alpha='', ' ', adr_alpha) , '') + if(adr_alpha ='',   adr_alpha , ' ') + if(len( road_name )>;0,  road_name + if(road_type='', ', ', ''), '') + if(len(  road_type )>;0,   ' ' + road_type + ', ', '') + if(len(  property_id ) >;0,  property_id + ', ', '') +if(len(  sl_name )>;0,   sl_name + ', ', '') + if(len(  tc_name )>;0,   tc_name , '') /* road_name + '  ' +  road_type  + ',  ' +   sl_name    + ',  ' +    tc_name  */
                return (_private_bag == null || _private_bag.Length > 0 ? _private_bag + ", " : "") + (_adr_no == null || _adr_no != "" ? _adr_no.ToUpper() + (_adr_alpha == null || _adr_alpha == "" ? " " : _adr_alpha) : "") + (_adr_alpha == null || _adr_alpha == "" ? _adr_alpha : " ") + (_road_name == null || _road_name.Length > 0 ? _road_name + (_road_type == "" ? ", " : "") : "") + (_road_type == null || _road_type.Length > 0 ? " " + _road_type + ", " : "") + (_property_id == null || _property_id.Length > 0 ? _property_id + ", " : "") + (_sl_name == null || _sl_name.Length > 0 ? _sl_name + ", " : "") + (_tc_name == null || _tc_name.Length > 0 ? _tc_name : "");
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static AddressList NewAddressList(int? al_contract_no)
        {
            return Create(al_contract_no);
        }

        public static AddressList[] GetAllAddressList(int? al_contract_no)
        {
            return Fetch(al_contract_no).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? al_contract_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    //IfNull(address.adr_unit, '', address.adr_unit+'/') + IsNull(address.adr_no, '') as adr_no
                    cm.CommandText = @"SELECT address.adr_id   as adr_id, 
                                            adr_no = case when address.adr_unit is null then '' + isnull(address.adr_no,'') else address.adr_unit +'/' + isnull(address.adr_no,'') end ,
                                            IsNull(address.adr_alpha, '') as adr_alpha,
                                            IsNull(road.road_name, '') as road_name,  
                                            road_type = case when address.adr_unit is null then isNull(road_type.rt_name,'') + '' else isNull(road_type.rt_name,'') + ' '+road_suffix.rs_name end, 
                                            IsNull((SELECT sl_name FROM suburblocality WHERE sl_id = address.sl_id), '') AS sl_name, 
                                            IsNull((SELECT tc_name FROM towncity WHERE tc_id = address.tc_id), '')       AS tc_name,  
                                            (case when charindex('private bag',isNull(lower(adr_property_identification),''))> 0 then adr_property_identification else ''  end ) AS private_bag,
                                            (case when charindex('private bag',isNull(lower(adr_property_identification),'')) > 0 then '' else adr_property_identification  end) AS property_id, 
                                            right(space(10)+address.adr_unit,10) as adr_unit,
                                            right(space(10)+address.adr_no,10)   as adr_num,
                                            address.dp_id 
                                       FROM address
                                            left outer JOIN road on address.road_id = road.road_id  
                                            left outer JOIN road_type on road.rt_id=road_type.rt_id 
                                            left outer JOIN road_suffix  on road.rs_id=road_suffix.rs_id 
                                      WHERE address.contract_no = @al_contract_no";
                    cm.CommandText += " order by road_name asc ,road_type asc,tc_name asc,adr_num asc,adr_alpha asc,adr_unit asc,sl_name asc,private_bag asc";
                    //    "SELECT address.adr_id   as adr_id,  adr_no = case when address.adr_unit is null then '' + isnull(address.adr_no,'') else address.adr_unit +'/' + isnull(address.adr_no,'') end,  IsNull(address.adr_alpha, '') as adr_alpha,  IsNull(road.road_name, '')    as road_name,  road_type = case when address.adr_unit is null then isNull(road_type.rt_name,'') + '' else isNull(road_type.rt_name,'') + ' '+road_suffix.rs_name end,  IsNull((SELECT sl_name FROM suburblocality WHERE sl_id = address.sl_id), '') AS sl_name,  IsNull((SELECT tc_name FROM towncity WHERE tc_id = address.tc_id), '')       AS tc_name,  (if Locate(isNull(lower(adr_property_identification),''),'private bag') >; 0 then adr_property_identification else '' endif)  AS private_bag,  (if Locate(isNull(lower(adr_property_identification),''),'private bag') >; 0 then '' else adr_property_identification  endif) AS property_id,  right(space(10)+address.adr_unit,10) as adr_unit,  right(space(10)+address.adr_no,10)   as adr_num,  address.dp_id  FROM address  LEFT OUTER JOIN road  LEFT OUTER JOIN road_type  LEFT OUTER JOIN road_suffix  WHERE address.contract_no = @al_contract_no  ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_contract_no", al_contract_no);

                    List<AddressList> _list = new List<AddressList>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            AddressList instance = new AddressList();
                            instance._adr_id = GetValueFromReader<Int32?>(dr, 0);
                            instance._adr_no = GetValueFromReader<String>(dr, 1);
                            instance._adr_alpha = GetValueFromReader<String>(dr, 2);
                            instance._road_name = GetValueFromReader<String>(dr, 3);
                            instance._road_type = GetValueFromReader<String>(dr, 4);
                            instance._sl_name = GetValueFromReader<String>(dr, 5);
                            instance._tc_name = GetValueFromReader<String>(dr, 6);
                            instance._private_bag = GetValueFromReader<String>(dr, 7);
                            instance._property_id = GetValueFromReader<String>(dr, 8);
                            instance._adr_unit = GetValueFromReader<String>(dr, 9);
                            instance._adr_num = GetValueFromReader<String>(dr, 10);
                            instance._dp_id = GetValueFromReader<Int32?>(dr, 11);

                            //instance.StoreFieldValues(dr, "suburblocality");
                            //instance.StoreFieldValues(dr, "address");
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
