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
    [MapInfo("vehicle_number", "_contract_vehical_vehicle_number", "contract_vehical")]
    [MapInfo("contract_no", "_contract_no", "contract_vehical")]
    [MapInfo("contract_seq_number", "_contract_seq_number", "contract_vehical")]
    [MapInfo("start_kms", "_contract_vehical_start_kms", "contract_vehical")]
    [MapInfo("vehicle_allowance_paid_to_dat", "_contract_vehical_vehicle_allowance_paid_", "contract_vehical")]
    [MapInfo("vt_key", "_vehicle_vt_key", "vehicle")]
    [MapInfo("ft_key", "_vehicle_ft_key", "vehicle")]
    [MapInfo("v_vehicle_make", "_vehicle_v_vehicle_make", "vehicle")]
    [MapInfo("v_vehicle_model", "_vehicle_v_vehicle_model", "vehicle")]
    [MapInfo("v_vehicle_registration_number", "_vehicle_v_vehicle_registration_number", "vehicle")]
    [MapInfo("v_vehicle_year", "_vehicle_v_vehicle_year", "vehicle")]
    [MapInfo("v_vehicle_cc_rating", "_vehicle_v_vehicle_cc_rating", "vehicle")]
    [MapInfo("v_road_user_charges_indicator", "_vehicle_v_road_user_charges_indicator", "vehicle")]
    [MapInfo("v_purchased_date", "_vehicle_v_purchased_date", "vehicle")]
    [MapInfo("v_purchase_value", "_vehicle_v_purchase_value", "vehicle")]
    [MapInfo("v_leased", "_vehicle_v_leased", "vehicle")]
    [MapInfo("v_vehicle_month", "_vehicle_v_vehicle_month", "vehicle")]
    [System.Serializable()]

    public class ContractVehicalForm : Entity<ContractVehicalForm>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_vehical_vehicle_number;

        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _contract_seq_number;

        [DBField()]
        private int? _contract_vehical_start_kms;

        [DBField()]
        private decimal? _contract_vehical_vehicle_allowance_paid_;

        [DBField()]
        private int? _vehicle_vt_key;

        [DBField()]
        private int? _vehicle_ft_key;

        [DBField()]
        private string _vehicle_v_vehicle_make;

        [DBField()]
        private string _vehicle_v_vehicle_model;

        [DBField()]
        private string _vehicle_v_vehicle_registration_number;

        [DBField()]
        private int? _vehicle_v_vehicle_year;

        [DBField()]
        private int? _vehicle_v_vehicle_cc_rating;

        [DBField()]
        private string _vehicle_v_road_user_charges_indicator;

        [DBField()]
        private DateTime? _vehicle_v_purchased_date;

        [DBField()]
        private int? _vehicle_v_purchase_value;

        [DBField()]
        private string _vehicle_v_leased;

        [DBField()]
        private int? _vehicle_v_vehicle_month;

        public virtual int? ContractVehicalVehicleNumber
        {
            get
            {
                CanReadProperty("ContractVehicalVehicleNumber", true);
                return _contract_vehical_vehicle_number;
            }
            set
            {
                CanWriteProperty("ContractVehicalVehicleNumber", true);
                if (_contract_vehical_vehicle_number != value)
                {
                    _contract_vehical_vehicle_number = value;
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

        public virtual int? ContractVehicalStartKms
        {
            get
            {
                CanReadProperty("ContractVehicalStartKms", true);
                return _contract_vehical_start_kms;
            }
            set
            {
                CanWriteProperty("ContractVehicalStartKms", true);
                if (_contract_vehical_start_kms != value)
                {
                    _contract_vehical_start_kms = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? ContractVehicalVehicleAllowancePaid
        {
            get
            {
                CanReadProperty("ContractVehicalVehicleAllowancePaid", true);
                return _contract_vehical_vehicle_allowance_paid_;
            }
            set
            {
                CanWriteProperty("ContractVehicalVehicleAllowancePaid", true);
                if (_contract_vehical_vehicle_allowance_paid_ != value)
                {
                    _contract_vehical_vehicle_allowance_paid_ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VehicleVtKey
        {
            get
            {
                CanReadProperty("VehicleVtKey", true);
                return _vehicle_vt_key;
            }
            set
            {
                CanWriteProperty("VehicleVtKey", true);
                if (_vehicle_vt_key != value)
                {
                    _vehicle_vt_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VehicleFtKey
        {
            get
            {
                CanReadProperty("VehicleFtKey", true);
                return _vehicle_ft_key;
            }
            set
            {
                CanWriteProperty("VehicleFtKey", true);
                if (_vehicle_ft_key != value)
                {
                    _vehicle_ft_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string VehicleVVehicleMake
        {
            get
            {
                CanReadProperty("VehicleVVehicleMake", true);
                return _vehicle_v_vehicle_make;
            }
            set
            {
                CanWriteProperty("VehicleVVehicleMake", true);
                if (_vehicle_v_vehicle_make != value)
                {
                    _vehicle_v_vehicle_make = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string VehicleVVehicleModel
        {
            get
            {
                CanReadProperty("VehicleVVehicleModel", true);
                return _vehicle_v_vehicle_model;
            }
            set
            {
                CanWriteProperty("VehicleVVehicleModel", true);
                if (_vehicle_v_vehicle_model != value)
                {
                    _vehicle_v_vehicle_model = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string VehicleVVehicleRegistrationNumber
        {
            get
            {
                CanReadProperty("VehicleVVehicleRegistrationNumber", true);
                return _vehicle_v_vehicle_registration_number;
            }
            set
            {
                CanWriteProperty("VehicleVVehicleRegistrationNumber", true);
                if (_vehicle_v_vehicle_registration_number != value)
                {
                    _vehicle_v_vehicle_registration_number = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VehicleVVehicleYear
        {
            get
            {
                CanReadProperty("VehicleVVehicleYear", true);
                return _vehicle_v_vehicle_year;
            }
            set
            {
                CanWriteProperty("VehicleVVehicleYear", true);
                if (_vehicle_v_vehicle_year != value)
                {
                    _vehicle_v_vehicle_year = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VehicleVVehicleCcRating
        {
            get
            {
                CanReadProperty("VehicleVVehicleCcRating", true);
                return _vehicle_v_vehicle_cc_rating;
            }
            set
            {
                CanWriteProperty("VehicleVVehicleCcRating", true);
                if (_vehicle_v_vehicle_cc_rating != value)
                {
                    _vehicle_v_vehicle_cc_rating = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string VehicleVRoadUserChargesIndicator
        {
            get
            {
                CanReadProperty("VehicleVRoadUserChargesIndicator", true);
                return _vehicle_v_road_user_charges_indicator;
            }
            set
            {
                CanWriteProperty("VehicleVRoadUserChargesIndicator", true);
                if (_vehicle_v_road_user_charges_indicator != value)
                {
                    _vehicle_v_road_user_charges_indicator = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? VehicleVPurchasedDate
        {
            get
            {
                CanReadProperty("VehicleVPurchasedDate", true);
                return _vehicle_v_purchased_date;
            }
            set
            {
                CanWriteProperty("VehicleVPurchasedDate", true);
                if (_vehicle_v_purchased_date != value)
                {
                    _vehicle_v_purchased_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VehicleVPurchaseValue
        {
            get
            {
                CanReadProperty("VehicleVPurchaseValue", true);
                return _vehicle_v_purchase_value;
            }
            set
            {
                CanWriteProperty("VehicleVPurchaseValue", true);
                if (_vehicle_v_purchase_value != value)
                {
                    _vehicle_v_purchase_value = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string VehicleVLeased
        {
            get
            {
                CanReadProperty("VehicleVLeased", true);
                return _vehicle_v_leased;
            }
            set
            {
                CanWriteProperty("VehicleVLeased", true);
                if (_vehicle_v_leased != value)
                {
                    _vehicle_v_leased = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VehicleVVehicleMonth
        {
            get
            {
                CanReadProperty("VehicleVVehicleMonth", true);
                return _vehicle_v_vehicle_month;
            }
            set
            {
                CanWriteProperty("VehicleVVehicleMonth", true);
                if (_vehicle_v_vehicle_month != value)
                {
                    _vehicle_v_vehicle_month = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static ContractVehicalForm NewContractVehicalForm(int? contract_no, int? contract_seq_number)
        {
            return Create(contract_no, contract_seq_number);
        }

        public static ContractVehicalForm[] GetAllContractVehicalForm(int? contract_no, int? contract_seq_number)
        {
            return Fetch(contract_no, contract_seq_number).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? contract_no, int? contract_seq_number)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "contract_no", contract_no);
                    pList.Add(cm, "contract_seq_number", contract_seq_number);
                    cm.CommandText = "  SELECT contract_vehical.vehicle_number,   " +
                        "contract_vehical.contract_no,   " +
                        "contract_vehical.contract_seq_number,   " +
                        "contract_vehical.start_kms,   " +
                        "contract_vehical.vehicle_allowance_paid_to_date,   " +
                        "vehicle.vt_key,   " +
                        "vehicle.ft_key,   " +
                        "vehicle.v_vehicle_make,   " +
                        "vehicle.v_vehicle_model,   " +
                        "vehicle.v_vehicle_registration_number,   " +
                        "vehicle.v_vehicle_year,   " +
                        "vehicle.v_vehicle_cc_rating,   " +
                        "vehicle.v_road_user_charges_indicator,   " +
                        "vehicle.v_purchased_date,   " +
                        "vehicle.v_purchase_value,   " +
                        "vehicle.v_leased,   " +
                        "vehicle.v_vehicle_month  " +
                        "FROM contract_vehical,vehicle  " +
                        "WHERE ( contract_vehical.vehicle_number = vehicle.vehicle_number ) and  " +
                        "( ( contract_vehical.contract_no = @contract_no ) AND  " +
                        "( contract_vehical.contract_seq_number = @contract_seq_number ) )    ";

                    List<ContractVehicalForm> _list = new List<ContractVehicalForm>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ContractVehicalForm instance = new ContractVehicalForm();
                            instance.ContractVehicalVehicleNumber = GetValueFromReader<Int32?>(dr, 0);
                            instance.ContractNo = GetValueFromReader<Int32?>(dr, 1);
                            instance.ContractSeqNumber = GetValueFromReader<Int32?>(dr, 2);
                            instance.ContractVehicalStartKms = GetValueFromReader<Int32?>(dr, 3);
                            instance.ContractVehicalVehicleAllowancePaid = GetValueFromReader<Int32?>(dr, 4);
                            instance.VehicleVtKey = GetValueFromReader<Int32?>(dr, 5);
                            instance.VehicleFtKey = GetValueFromReader<Int32?>(dr, 6);
                            instance.VehicleVVehicleMake = GetValueFromReader<String>(dr, 7);
                            instance.VehicleVVehicleModel = GetValueFromReader<String>(dr, 8);
                            instance.VehicleVVehicleRegistrationNumber = GetValueFromReader<String>(dr, 9);
                            instance.VehicleVVehicleYear = GetValueFromReader<Int16?>(dr, 10);
                            instance.VehicleVVehicleCcRating = GetValueFromReader<Int16?>(dr, 11);
                            instance.VehicleVRoadUserChargesIndicator = GetValueFromReader<String>(dr, 12);
                            instance.VehicleVPurchasedDate = GetValueFromReader<DateTime?>(dr, 13);
                            instance.VehicleVPurchaseValue = GetValueFromReader<Int32?>(dr, 14);
                            instance.VehicleVLeased = GetValueFromReader<String>(dr, 15);
                            instance.VehicleVVehicleMonth = GetValueFromReader<Int16?>(dr, 16);
                            //instance.StoreFieldValues(dr, "contract_vehical");
                            //instance.StoreFieldValues(dr, "vehicle");
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
