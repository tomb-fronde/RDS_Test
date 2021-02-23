using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  Frequencies & Vehicles  15-Feb-2021
    // Removed references to default vehicle (removed from design)
    // Changed sort order - put active vehicles (status = 'A') first
    //
    // TJB  Frequencies & Vehicles  16-Jan-2021
    // Changed type of CvVehicalStatus to bool (was string)
    // Changed sort order - put default vehicle first
    //
    // TJB  RPCR_001  July-2010
    // Added _v_vehicle_safety, _v_vehicle_emissions, _v_vehicle_consumption_rate 
    // and related code.

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("vehicle_number", "_vehicle_number", "contract_vehical")]
    [MapInfo("contract_no", "_contract_no", "contract_vehical")]
    [MapInfo("contract_seq_number", "_contract_seq_number", "contract_vehical")]
    [MapInfo("start_kms", "_start_kms", "contract_vehical")]
    [MapInfo("vehicle_allowance_paid_to_date", "_vehicle_allowance_paid_", "contract_vehical")]
    [MapInfo("cv_vehical_status", "_cv_vehical_status", "contract_vehical")]
    [MapInfo("vt_key", "_vt_key", "vehicle")]
    [MapInfo("ft_key", "_ft_key", "vehicle")]
    [MapInfo("v_vehicle_make", "_v_vehicle_make", "vehicle")]
    [MapInfo("v_vehicle_model", "_v_vehicle_model", "vehicle")]
    [MapInfo("v_vehicle_registration_number", "_v_vehicle_registration_number", "vehicle")]
    [MapInfo("v_vehicle_year", "_v_vehicle_year", "vehicle")]
    [MapInfo("v_vehicle_cc_rating", "_v_vehicle_cc_rating", "vehicle")]
    [MapInfo("v_road_user_charges_indicator", "_v_road_user_charges_indicator", "vehicle")]
    [MapInfo("v_purchased_date", "_v_purchased_date", "vehicle")]
    [MapInfo("v_purchase_value", "_v_purchase_value", "vehicle")]
    [MapInfo("v_leased", "_v_leased", "vehicle")]
    [MapInfo("v_vehicle_month", "_v_vehicle_month", "vehicle")]
    [MapInfo("v_vehicle_transmission", "_v_vehicle_transmission", "vehicle")]
    [MapInfo("v_remaining_economic_life", "_v_remaining_economic_life", "vehicle")]
    [MapInfo("vs_key", "_vs_key", "vehicle")]
    [MapInfo("signage_compliant", "_signage_compliant", "contract_vehical")]
    [MapInfo("v_vehicle_speedo_kms", "_v_vehicle_speedo_kms", "vehicle")]
    [MapInfo("v_vehicle_speedo_date", "_v_vehicle_speedo_date", "vehicle")]
    [MapInfo("v_salvage_value", "_v_salvage_value", "vehicle")]
    [MapInfo("v_vehicle_safety", "_v_vehicle_safety", "vehicle")]
    [MapInfo("v_vehicle_emissions", "_v_vehicle_emissions", "vehicle")]
    [MapInfo("v_vehicle_consumption_rate", "_v_vehicle_consumption_rate", "vehicle")]

    [System.Serializable()]

    public class ContractVehicle : Entity<ContractVehicle>
    {
        #region Business Methods
        [DBField()]
        private int? _vehicle_number;

        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _contract_seq_number;

        [DBField()]
        private int? _start_kms;

        [DBField()]
        private decimal? _vehicle_allowance_paid_;

        [DBField()]
        private int? _vt_key;

        [DBField()]
        private int? _ft_key;

        [DBField()]
        private string _v_vehicle_make;

        [DBField()]
        private string _v_vehicle_model;

        [DBField()]
        private string _v_vehicle_registration_number;

        [DBField()]
        private int? _v_vehicle_year;

        [DBField()]
        private int? _v_vehicle_cc_rating;

        [DBField()]
        private string _v_road_user_charges_indicator;

        [DBField()]
        private DateTime? _v_purchased_date;

        [DBField()]
        private int? _v_purchase_value;

        [DBField()]
        private string _v_leased;

        [DBField()]
        private string _cv_vehical_status="N";

        [DBField()]
        private int? _v_vehicle_month;

        [DBField()]
        private string _v_vehicle_transmission;

        [DBField()]
        private int? _v_remaining_economic_life = 0;

        [DBField()]
        private int? _vs_key;

        [DBField()]
        private string _signage_compliant="N";

        [DBField()]
        private int? _v_vehicle_speedo_kms;

        [DBField()]
        private DateTime? _v_vehicle_speedo_date;

        [DBField()]
        private int? _v_salvage_value;

        [DBField()]
        private int? _v_vehicle_safety;

        [DBField()]
        private int? _v_vehicle_emissions;

        [DBField()]
        private decimal? _v_vehicle_consumption_rate;

        private string _cv_vehical_initial_status = "N";

        
        //-------------------------------------------------------------------------
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

        public virtual int? StartKms
        {
            get
            {
                CanReadProperty("StartKms", true);
                return _start_kms;
            }
            set
            {
                CanWriteProperty("StartKms", true);
                if (_start_kms != value)
                {
                    _start_kms = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VehicleAllowancePaid
        {
            get
            {
                CanReadProperty("VehicleAllowancePaid", true);
                return _vehicle_allowance_paid_;
            }
            set
            {
                CanWriteProperty("VehicleAllowancePaid", true);
                if (_vehicle_allowance_paid_ != value)
                {
                    _vehicle_allowance_paid_ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VtKey
        {
            get
            {
                CanReadProperty("VtKey", true);
                return _vt_key;
            }
            set
            {
                CanWriteProperty("VtKey", true);
                if (_vt_key != value)
                {
                    _vt_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? FtKey
        {
            get
            {
                CanReadProperty("FtKey", true);
                return _ft_key;
            }
            set
            {
                CanWriteProperty("FtKey", true);
                if (_ft_key != value)
                {
                    _ft_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string VVehicleMake
        {
            get
            {
                CanReadProperty("VVehicleMake", true);
                return _v_vehicle_make;
            }
            set
            {
                CanWriteProperty("VVehicleMake", true);
                if (_v_vehicle_make != value)
                {
                    _v_vehicle_make = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string VVehicleModel
        {
            get
            {
                CanReadProperty("VVehicleModel", true);
                return _v_vehicle_model;
            }
            set
            {
                CanWriteProperty("VVehicleModel", true);
                if (_v_vehicle_model != value)
                {
                    _v_vehicle_model = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string VVehicleRegistrationNumber
        {
            get
            {
                CanReadProperty("VVehicleRegistrationNumber", true);
                return _v_vehicle_registration_number;
            }
            set
            {
                CanWriteProperty("VVehicleRegistrationNumber", true);
                if (_v_vehicle_registration_number != value)
                {
                    _v_vehicle_registration_number = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VVehicleYear
        {
            get
            {
                CanReadProperty("VVehicleYear", true);
                return _v_vehicle_year;
            }
            set
            {
                CanWriteProperty("VVehicleYear", true);
                if (_v_vehicle_year != value)
                {
                    _v_vehicle_year = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VVehicleCcRating
        {
            get
            {
                CanReadProperty("VVehicleCcRating", true);
                return _v_vehicle_cc_rating;
            }
            set
            {
                CanWriteProperty("VVehicleCcRating", true);
                if (_v_vehicle_cc_rating != value)
                {
                    _v_vehicle_cc_rating = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool VRoadUserChargesIndicator
        {
            get
            {
                CanReadProperty("VRoadUserChargesIndicator", true);
                return _v_road_user_charges_indicator == "Y";
            }
            set
            {
                CanWriteProperty("VRoadUserChargesIndicator", true);
                string new_value = value ? "Y" : "N";
                if (_v_road_user_charges_indicator != new_value)
                {
                    _v_road_user_charges_indicator = new_value;
                    PropertyHasChanged("_v_road_user_charges_indicator");
                }
            }
        }

        public virtual DateTime? VPurchasedDate
        {
            get
            {
                CanReadProperty("VPurchasedDate", true);
                return _v_purchased_date;
            }
            set
            {
                CanWriteProperty("VPurchasedDate", true);
                if (_v_purchased_date != value)
                {
                    _v_purchased_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VPurchaseValue
        {
            get
            {
                CanReadProperty("VPurchaseValue", true);
                return _v_purchase_value;
            }
            set
            {
                CanWriteProperty("VPurchaseValue", true);
                if (_v_purchase_value != value)
                {
                    _v_purchase_value = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool VLeased
        {
            get
            {
                CanReadProperty("VLeased", true);
                return _v_leased == "Y";
            }
            set
            {
                CanWriteProperty("VLeased", true);
                string new_value = value ? "Y" : "N";
                if (_v_leased != new_value)
                {
                    _v_leased = new_value;
                    PropertyHasChanged("_v_leased");
                }
            }
        }

        public virtual bool CvVehicalStatus
        {
            get
            {
                CanReadProperty("CvVehicalStatus", true);
                return _cv_vehical_status == "A";
            }
            set
            {
                CanWriteProperty("CvVehicalStatus", true);
                string new_value = value ? "A" : "N";
                if (_cv_vehical_status != new_value)
                {
                    _cv_vehical_status = new_value;
                    PropertyHasChanged("_cv_vehical_status");
                }
            }
        }

        public virtual int? VVehicleMonth
        {
            get
            {
                CanReadProperty("VVehicleMonth", true);
                return _v_vehicle_month;
            }
            set
            {
                CanWriteProperty("VVehicleMonth", true);
                if (_v_vehicle_month != value)
                {
                    _v_vehicle_month = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string VVehicleTransmission
        {
            get
            {
                CanReadProperty("VVehicleTransmission", true);
                return _v_vehicle_transmission;
            }
            set
            {
                CanWriteProperty("VVehicleTransmission", true);
                if (_v_vehicle_transmission != value)
                {
                    _v_vehicle_transmission = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VRemainingEconomicLife
        {
            get
            {
                CanReadProperty("VRemainingEconomicLife", true);
                return _v_remaining_economic_life == null ? 0 : _v_remaining_economic_life;
            }
            set
            {
                CanWriteProperty("VRemainingEconomicLife", true);
                if (_v_remaining_economic_life != value)
                {
                    _v_remaining_economic_life = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VsKey
        {
            get
            {
                CanReadProperty("VsKey", true);
                return _vs_key;
            }
            set
            {
                CanWriteProperty("VsKey", true);
                if (_vs_key != value)
                {
                    _vs_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool SignageCompliant
        {
            get
            {
                CanReadProperty("SignageCompliant", true);
                return _signage_compliant == "Y";
            }
            set
            {
                CanWriteProperty("SignageCompliant", true);
                string new_value = value ? "Y" : "N";
                if (_signage_compliant != new_value)
                {
                    _signage_compliant = new_value;
                    PropertyHasChanged("_signage_compliant");
                }
            }
        }

        public virtual int? VVehicleSpeedoKms
        {
            get
            {
                CanReadProperty("VVehicleSpeedoKms", true);
                return _v_vehicle_speedo_kms;
            }
            set
            {
                CanWriteProperty("VVehicleSpeedoKms", true);
                if (_v_vehicle_speedo_kms != value)
                {
                    _v_vehicle_speedo_kms = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? VVehicleSpeedoDate
        {
            get
            {
                CanReadProperty("VVehicleSpeedoDate", true);
                return _v_vehicle_speedo_date;
            }
            set
            {
                CanWriteProperty("VVehicleSpeedoDate", true);
                if (_v_vehicle_speedo_date != value)
                {
                    _v_vehicle_speedo_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VSalvageValue
        {
            get
            {
                CanReadProperty("VSalvageValue", true);
                return _v_salvage_value;
            }
            set
            {
                CanWriteProperty("VSalvageValue", true);
                if (_v_salvage_value != value)
                {
                    _v_salvage_value = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VVehicleSafety
        {
            get
            {
                CanReadProperty("VVehicleSafety", true);
                return _v_vehicle_safety;
            }
            set
            {
                CanWriteProperty("VVehicleSafety", true);
                if (_v_vehicle_safety != value)
                {
                    _v_vehicle_safety = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? VVehicleEmissions
        {
            get
            {
                CanReadProperty("VVehicleEmissions", true);
                return _v_vehicle_emissions;
            }
            set
            {
                CanWriteProperty("VVehicleEmissions", true);
                if (_v_vehicle_emissions != value)
                {
                    _v_vehicle_emissions = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VVehicleConsumptionRate
        {
            get
            {
                CanReadProperty("VVehicleConsumptionRate", true);
                return _v_vehicle_consumption_rate;
            }
            set
            {
                CanWriteProperty("VVehicleConsumptionRate", true);
                if (_v_vehicle_consumption_rate != value)
                {
                    _v_vehicle_consumption_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool VVehicleTransmission1
        {
            get
            {
                CanReadProperty("VSalvageValue", true);
                return _v_vehicle_transmission == "M";
            }
            set
            {
                CanWriteProperty("VSalvageValue", true);
                string new_value = value ? "M" : "A";
                if (_v_vehicle_transmission != new_value)
                {
                    _v_vehicle_transmission = new_value;
                    PropertyHasChanged("v_vehicle_transmission");
                }
            }
        }

        public virtual bool VVehicleTransmission2
        {
            get
            {
                CanReadProperty("VSalvageValue", true);
                return _v_vehicle_transmission == "A";
            }
            set
            {
                CanWriteProperty("VSalvageValue", true);
                string new_value = value ? "A" : "M";
                if (_v_vehicle_transmission != new_value)
                {
                    _v_vehicle_transmission = new_value;
                    PropertyHasChanged("v_vehicle_transmission");
                }
            }
        }

        public virtual bool CvVehicalInitialStatus   // manipulated via cb_active checkbox
        {
            get
            {
                string old_val = _cv_vehical_initial_status ?? "N";
                CanReadProperty("CvVehicalInitialStatus", true);
                return old_val == "A";
            }
            set
            {
                CanWriteProperty("CvVehicalInitialStatus", true);
                string new_value = value ? "A" : "N";
                if (_cv_vehical_initial_status != new_value)
                {
                    _cv_vehical_initial_status = new_value;
                    PropertyHasChanged("_cv_vehical_initial_status");
                }
            }
        }

        //-------------------------------------------------------------------------
        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}/{2}", _vehicle_number, _contract_no, _contract_seq_number);
        }
        #endregion

        #region Factory Methods
        public static ContractVehicle NewContractVehicle(int? contract_no, int? contract_seq_number)
        {
            return Create(contract_no, contract_seq_number);
        }

        public static ContractVehicle[] GetAllContractVehicle(int? contract_no, int? contract_seq_number)
        {
            return Fetch(contract_no, contract_seq_number).list;
        }
        #endregion

        //-------------------------------------------------------------------------
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
                    cm.CommandText = "SELECT " + 
                                "contract_vehical.vehicle_number " +
                                ",contract_vehical.contract_no " +
                                ",contract_vehical.contract_seq_number " +
                                ",contract_vehical.start_kms " +
                                ",contract_vehical.vehicle_allowance_paid_to_date " +
                                ",vehicle.vt_key " +
                                ",vehicle.ft_key " +
                                ",vehicle.v_vehicle_make " +
                                ",vehicle.v_vehicle_model " +
                                ",vehicle.v_vehicle_registration_number " +
                                ",vehicle.v_vehicle_year " +
                                ",vehicle.v_vehicle_cc_rating " +
                                ",vehicle.v_road_user_charges_indicator " +
                                ",vehicle.v_purchased_date " +
                                ",vehicle.v_purchase_value " +
                                ",vehicle.v_leased " +
                                ",contract_vehical.cv_vehical_status " +
                                ",vehicle.v_vehicle_month " +
                                ",vehicle.v_vehicle_transmission " +
                                ",vehicle.v_remaining_economic_life " +
                                ",vehicle.vs_key " +
                                ",contract_vehical.signage_compliant " +
                                ",vehicle.v_vehicle_speedo_kms " +
                                ",vehicle.v_vehicle_speedo_date " +
                                ",vehicle.v_salvage_value " +
                                ",vehicle.v_vehicle_safety " +
                                ",vehicle.v_vehicle_emissions " +
                                ",vehicle.v_vehicle_consumption_rate " +
                         "  FROM contract_vehical " + 
                         "     , vehicle " +
                         " WHERE contract_vehical.vehicle_number = vehicle.vehicle_number " +
                         "   AND contract_vehical.contract_no = @contract_no " +
                         "   AND contract_vehical.contract_seq_number = @contract_seq_number " +
                         " ORDER BY contract_vehical.cv_vehical_status" +
                         "        , contract_vehical.vehicle_number";

                    List<ContractVehicle> _list = new List<ContractVehicle>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        int? val;
                        while (dr.Read())
                        {
                            ContractVehicle instance = new ContractVehicle();
                            instance._vehicle_number = GetValueFromReader<Int32?>(dr, 0);
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 1);
                            instance._contract_seq_number = GetValueFromReader<Int32?>(dr, 2);
                            instance._start_kms = GetValueFromReader<Int32?>(dr, 3);
                            instance._vehicle_allowance_paid_ = GetValueFromReader<Decimal?>(dr, 4);

                            instance._vt_key = GetValueFromReader<Int32?>(dr, 5);
                            instance._ft_key = GetValueFromReader<Int32?>(dr, 6);
                            instance._v_vehicle_make = GetValueFromReader<String>(dr, 7);
                            instance._v_vehicle_model = GetValueFromReader<String>(dr, 8);
                            instance._v_vehicle_registration_number = GetValueFromReader<String>(dr, 9);

                            instance._v_vehicle_year = GetValueFromReader<Int32?>(dr, 10);
                            instance._v_vehicle_cc_rating = GetValueFromReader<Int32?>(dr, 11);
                            instance._v_road_user_charges_indicator = GetValueFromReader<String>(dr, 12);
                            instance._v_purchased_date = GetValueFromReader<DateTime?>(dr, 13);
                            instance._v_purchase_value = GetValueFromReader<Int32?>(dr, 14);

                            instance._v_leased = GetValueFromReader<String>(dr, 15);
                            instance._cv_vehical_status = GetValueFromReader<String>(dr, 16);
                            instance._v_vehicle_month = GetValueFromReader<Int32?>(dr, 17);
                            instance._v_vehicle_transmission = GetValueFromReader<String>(dr, 18);
                            instance._v_remaining_economic_life = GetValueFromReader<Int32?>(dr, 19);

                            instance._vs_key = GetValueFromReader<Int32?>(dr, 20);
                            instance._signage_compliant = GetValueFromReader<String>(dr, 21);
                            instance._v_vehicle_speedo_kms = GetValueFromReader<Int32?>(dr, 22);
                            instance._v_vehicle_speedo_date = GetValueFromReader<DateTime?>(dr, 23);
                            instance._v_salvage_value = GetValueFromReader<Int32?>(dr, 24);
                            instance._v_vehicle_safety = GetValueFromReader<Int32?>(dr, 25);
                            instance._v_vehicle_emissions = GetValueFromReader<Int32?>(dr, 26);
                            instance._v_vehicle_consumption_rate = GetValueFromReader<Decimal?>(dr, 27);

                            // TJB  Frequencies & Vehicles  Jan-2021: Added
                            instance._cv_vehical_initial_status = instance._cv_vehical_status;

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
            // TJB July-2010
            // Note: the vehicle table is updated separately in RDS.DataService.RDSDataService.UpdateVehicle
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm= cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "contract_vehical", ref pList))
                {
                    cm.CommandText += " WHERE contract_vehical.vehicle_number = @vehicle_number AND " +
                        "contract_vehical.contract_no = @contract_no AND " +
                        "contract_vehical.contract_seq_number = @contract_seq_number ";

                    pList.Add(cm, "vehicle_number", GetInitialValue("_vehicle_number"));
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "contract_seq_number", GetInitialValue("_contract_seq_number"));
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                // reinitialize original key/value list
                StoreInitialValues();
            }
        }
        [ServerMethod()]
        private void InsertEntity()
        {
            // TJB July-2010
            // Note: the vehicle table is updated separately in RDS.DataService.RDSDataService.InsertVehicle
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateInsertCommandText(cm, "contract_vehical", pList))
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
                    pList.Add(cm, "vehicle_number", GetInitialValue("_vehicle_number"));
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "contract_seq_number", GetInitialValue("_contract_seq_number"));
                    cm.CommandText = "DELETE FROM contract_vehical WHERE " +
                    "contract_vehical.vehicle_number = @vehicle_number AND " +
                    "contract_vehical.contract_no = @contract_no AND " +
                    "contract_vehical.contract_seq_number = @contract_seq_number ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? vehicle_number, int? contract_no, int? contract_seq_number)
        {
            _vehicle_number = vehicle_number;
            _contract_no = contract_no;
            _contract_seq_number = contract_seq_number;
        }
    }
}
