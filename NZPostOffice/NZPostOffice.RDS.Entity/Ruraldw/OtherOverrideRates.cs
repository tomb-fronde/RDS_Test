using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  Frequencies & Vehicles  22-Jan-2021
    // Added vehicle_number to Fetch etc parameters and to returned values

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "misc_override_rate")]
    [MapInfo("contract_seq_number", "_contract_seq_number", "misc_override_rate")]
    [MapInfo("mor_name", "_mor_name", "misc_override_rate")]
    [MapInfo("mor_value", "_mor_value", "misc_override_rate")]
    [MapInfo("mor_km_flag", "_mor_km_flag", "misc_override_rate")]
    [MapInfo("mor_annual_flag", "_mor_annual_flag", "misc_override_rate")]
    [MapInfo("vehicle_number", "_vehicle_number", "misc_override_rate")]
    [System.Serializable()]

    public class OtherOverrideRates : Entity<OtherOverrideRates>
    {
        private string SQLErrText;

        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _contract_seq_number;

        [DBField()]
        private string _mor_name;

        [DBField()]
        private decimal? _mor_value;

        [DBField()]
        private string _mor_km_flag;

        [DBField()]
        private string _mor_annual_flag;

        [DBField()]
        private int? _vehicle_number;

//-------------------------------------------------------------------------------
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

        public virtual int? ContractSeqNumber
        {
            get
            {
                CanReadProperty("ContractSeqNumber", true);
                return _contract_seq_number;
            }
            set
            {
                CanWriteProperty("ContractSeqNumber", true);
                if (_contract_seq_number != value)
                {
                    _contract_seq_number = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string MorName
        {
            get
            {
                CanReadProperty("MorName", true);
                return _mor_name;
            }
            set
            {
                CanWriteProperty("MorName", true);
                if (_mor_name != value)
                {
                    _mor_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? MorValue
        {
            get
            {
                CanReadProperty("MorValue", true);
                return _mor_value;
            }
            set
            {
                CanWriteProperty("MorValue", true);
                if (_mor_value != value)
                {
                    _mor_value = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string MorKmFlag
        {
            get
            {
                CanReadProperty("MorKmFlag", true);
                return _mor_km_flag;
            }
            set
            {
                CanWriteProperty("MorKmFlag", true);
                if (_mor_km_flag != value)
                {
                    _mor_km_flag = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string MorAnnualFlag
        {
            get
            {
                CanReadProperty("MorAnnualFlag", true);
                return _mor_annual_flag;
            }
            set
            {
                CanWriteProperty("MorAnnualFlag", true);
                if (_mor_annual_flag != value)
                {
                    _mor_annual_flag = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VehicleNumber
        {
            get
            {
                CanReadProperty("VehicleNumber", true);
                return _vehicle_number;
            }
            set
            {
                CanWriteProperty("VehicleNumber", true);
                if (_vehicle_number != value)
                {
                    _vehicle_number = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _contract_no, _contract_seq_number);
        }
//-------------------------------------------------------------------------------
        #endregion

        #region Factory Methods
        public static OtherOverrideRates NewOtherOverrideRates(int? incontract_no, int? incontract_seq_number, int? invehicle_number)
        {
            return Create(incontract_no, incontract_seq_number, invehicle_number);
        }

        public static OtherOverrideRates[] GetAllOtherOverrideRates(int? incontract_no, int? incontract_seq_number, int? invehicle_number)
        {
            return Fetch(incontract_no, incontract_seq_number, invehicle_number).list;
        }
//-------------------------------------------------------------------------------
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? incontract_no, int? incontract_seq_number, int? invehicle_number)
        {
            // TJB  Frequencies & Vehicles  22-Jan-2021
            // Added vehicle_number to parameters and returned values
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inContractNo", incontract_no);
                    pList.Add(cm, "inSequenceNo", incontract_seq_number);
                    pList.Add(cm, "inVehicleNo",  invehicle_number);
                    cm.CommandText = "rd.sp_get_other_override_rates";

                    List<OtherOverrideRates> _list = new List<OtherOverrideRates>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            OtherOverrideRates instance = new OtherOverrideRates();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._contract_seq_number = GetValueFromReader<Int32?>(dr,1);
                            instance._mor_name = GetValueFromReader<String>(dr,2);
                            instance._mor_value = GetValueFromReader<Decimal?>(dr,3);
                            instance._mor_km_flag = GetValueFromReader<String>(dr,4);
                            instance._mor_annual_flag = GetValueFromReader<String>(dr,5);
                            instance._vehicle_number = GetValueFromReader<Int32?>(dr, 6);
                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        list = _list.ToArray();
                    }
                }
            }
        }

        // TJB  Frequencies & Vehicles  22-Jan-2021 
        // Added InsertEntity()
        [ServerMethod()]
        private void InsertEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateInsertCommandText(cm, "misc_override_rate", pList))
                {
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                        SQLErrText = e.Message;
                    }
                }
                StoreInitialValues();
            }
        }

        // TJB  Frequencies & Vehicles  22-Jan-2021 
        // Added UpdateEntity()
        [ServerMethod()]
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "misc_override_rate", ref pList))
                {
                    cm.CommandText += " WHERE contract_no         = @contract_no"
                                      + " AND contract_seq_number = @contract_seq_number"
                                      + " AND vehicle_number      = @vehicle_number";
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "contract_seq_number", GetInitialValue("_contract_seq_number"));
                    pList.Add(cm, "vehicle_number", GetInitialValue("_vehicle_number"));
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                        SQLErrText = e.Message;
                    }
                }
                StoreInitialValues();
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? contract_no, int? contract_seq_number, int? vehicle_number)
        {
            _contract_no = contract_no;
            _contract_seq_number = contract_seq_number;
            _vehicle_number = vehicle_number;
        }
    }
}
