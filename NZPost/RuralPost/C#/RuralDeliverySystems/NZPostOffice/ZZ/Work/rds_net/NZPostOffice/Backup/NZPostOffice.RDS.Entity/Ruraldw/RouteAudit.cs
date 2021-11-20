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
    [MapInfo("contract_no", "_contract_no", "route_audit")]
    [MapInfo("ra_day_of_check", "_ra_day_of_check", "route_audit")]
    [MapInfo("ra_date_of_check", "_ra_date_of_check", "route_audit")]
    [MapInfo("ra_time_started_sort", "_ra_time_started_sort", "route_audit")]
    [MapInfo("ra_time_finished_sort", "_ra_time_finished_sort", "route_audit")]
    [MapInfo("ra_time_left_base", "_ra_time_left_base", "route_audit")]
    [MapInfo("ra_time_returned", "_ra_time_returned", "route_audit")]
    [MapInfo("ra_time_departed", "_ra_time_departed", "route_audit")]
    [MapInfo("ra_finish_odometer", "_ra_finish_odometer", "route_audit")]
    [MapInfo("ra_start_odometer", "_ra_start_odometer", "route_audit")]
    [MapInfo("ra_meal_breaks", "_ra_meal_breaks", "route_audit")]
    [MapInfo("ra_extra_time", "_ra_extra_time", "route_audit")]
    [MapInfo("ra_extra_distance", "_ra_extra_distance", "route_audit")]
    [MapInfo("ra_othr_gds_before", "_ra_othr_gds_before", "route_audit")]
    [MapInfo("ra_othr_gds_during", "_ra_othr_gds_during", "route_audit")]
    [MapInfo("ra_othr_gds_after", "_ra_othr_gds_after", "route_audit")]
    [MapInfo("ra_pr_before", "_ra_pr_before", "route_audit")]
    [MapInfo("ra_pr_during", "_ra_pr_during", "route_audit")]
    [MapInfo("ra_pr_after", "_ra_pr_after", "route_audit")]
    [System.Serializable()]

    public class RouteAudit : Entity<RouteAudit>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _ra_day_of_check;

        [DBField()]
        private DateTime? _ra_date_of_check;

        [DBField()]
        private DateTime? _ra_time_started_sort;

        [DBField()]
        private DateTime? _ra_time_finished_sort;

        [DBField()]
        private DateTime? _ra_time_left_base;

        [DBField()]
        private DateTime? _ra_time_returned;

        [DBField()]
        private DateTime? _ra_time_departed;

        [DBField()]
        private decimal? _ra_finish_odometer;

        [DBField()]
        private decimal? _ra_start_odometer;

        [DBField()]
        private DateTime? _ra_meal_breaks;

        [DBField()]
        private DateTime? _ra_extra_time;

        [DBField()]
        private decimal? _ra_extra_distance;

        [DBField()]
        private DateTime? _ra_othr_gds_before;

        [DBField()]
        private DateTime? _ra_othr_gds_during;

        [DBField()]
        private DateTime? _ra_othr_gds_after;

        [DBField()]
        private DateTime? _ra_pr_before;

        [DBField()]
        private DateTime? _ra_pr_during;

        [DBField()]
        private DateTime? _ra_pr_after;

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

        public virtual int? RaDayOfCheck
        {
            get
            {
                CanReadProperty("RaDayOfCheck", true);
                return _ra_day_of_check;
            }
            set
            {
                CanWriteProperty("RaDayOfCheck", true);
                if (_ra_day_of_check != value)
                {
                    _ra_day_of_check = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? RaDateOfCheck
        {
            get
            {
                CanReadProperty("RaDateOfCheck", true);
                return _ra_date_of_check;
            }
            set
            {
                CanWriteProperty("RaDateOfCheck", true);
                if (_ra_date_of_check != value)
                {
                    _ra_date_of_check = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? RaTimeStartedSort
        {
            get
            {
                CanReadProperty("RaTimeStartedSort", true);
                return _ra_time_started_sort;
            }
            set
            {
                CanWriteProperty("RaTimeStartedSort", true);
                if (_ra_time_started_sort != value)
                {
                    _ra_time_started_sort = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? RaTimeFinishedSort
        {
            get
            {
                CanReadProperty("RaTimeFinishedSort", true);
                return _ra_time_finished_sort;
            }
            set
            {
                CanWriteProperty("RaTimeFinishedSort", true);
                if (_ra_time_finished_sort != value)
                {
                    _ra_time_finished_sort = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? RaTimeLeftBase
        {
            get
            {
                CanReadProperty("RaTimeLeftBase", true);
                return _ra_time_left_base;
            }
            set
            {
                CanWriteProperty("RaTimeLeftBase", true);
                if (_ra_time_left_base != value)
                {
                    _ra_time_left_base = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? RaTimeReturned
        {
            get
            {
                CanReadProperty("RaTimeReturned", true);
                return _ra_time_returned;
            }
            set
            {
                CanWriteProperty("RaTimeReturned", true);
                if (_ra_time_returned != value)
                {
                    _ra_time_returned = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? RaTimeDeparted
        {
            get
            {
                CanReadProperty("RaTimeDeparted", true);
                return _ra_time_departed;
            }
            set
            {
                CanWriteProperty("RaTimeDeparted", true);
                if (_ra_time_departed != value)
                {
                    _ra_time_departed = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RaFinishOdometer
        {
            get
            {
                CanReadProperty("RaFinishOdometer", true);
                return _ra_finish_odometer;
            }
            set
            {
                CanWriteProperty("RaFinishOdometer", true);
                if (_ra_finish_odometer != value)
                {
                    _ra_finish_odometer = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RaStartOdometer
        {
            get
            {
                CanReadProperty("RaStartOdometer", true);
                return _ra_start_odometer;
            }
            set
            {
                CanWriteProperty("RaStartOdometer", true);
                if (_ra_start_odometer != value)
                {
                    _ra_start_odometer = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? RaMealBreaks
        {
            get
            {
                CanReadProperty("RaMealBreaks", true);
                return _ra_meal_breaks;
            }
            set
            {
                CanWriteProperty("RaMealBreaks", true);
                if (_ra_meal_breaks != value)
                {
                    _ra_meal_breaks = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? RaExtraTime
        {
            get
            {
                CanReadProperty("RaExtraTime", true);
                return _ra_extra_time;
            }
            set
            {
                CanWriteProperty("RaExtraTime", true);
                if (_ra_extra_time != value)
                {
                    _ra_extra_time = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RaExtraDistance
        {
            get
            {
                CanReadProperty("RaExtraDistance", true);
                return _ra_extra_distance;
            }
            set
            {
                CanWriteProperty("RaExtraDistance", true);
                if (_ra_extra_distance != value)
                {
                    _ra_extra_distance = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? RaOthrGdsBefore
        {
            get
            {
                CanReadProperty("RaOthrGdsBefore", true);
                return _ra_othr_gds_before;
            }
            set
            {
                CanWriteProperty("RaOthrGdsBefore", true);
                if (_ra_othr_gds_before != value)
                {
                    _ra_othr_gds_before = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? RaOthrGdsDuring
        {
            get
            {
                CanReadProperty("RaOthrGdsDuring", true);
                return _ra_othr_gds_during;
            }
            set
            {
                CanWriteProperty("RaOthrGdsDuring", true);
                if (_ra_othr_gds_during != value)
                {
                    _ra_othr_gds_during = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? RaOthrGdsAfter
        {
            get
            {
                CanReadProperty("RaOthrGdsAfter", true);
                return _ra_othr_gds_after;
            }
            set
            {
                CanWriteProperty("RaOthrGdsAfter", true);
                if (_ra_othr_gds_after != value)
                {
                    _ra_othr_gds_after = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? RaPrBefore
        {
            get
            {
                CanReadProperty("RaPrBefore", true);
                return _ra_pr_before;
            }
            set
            {
                CanWriteProperty("RaPrBefore", true);
                if (_ra_pr_before != value)
                {
                    _ra_pr_before = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? RaPrDuring
        {
            get
            {
                CanReadProperty("RaPrDuring", true);
                return _ra_pr_during;
            }
            set
            {
                CanWriteProperty("RaPrDuring", true);
                if (_ra_pr_during != value)
                {
                    _ra_pr_during = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? RaPrAfter
        {
            get
            {
                CanReadProperty("RaPrAfter", true);
                return _ra_pr_after;
            }
            set
            {
                CanWriteProperty("RaPrAfter", true);
                if (_ra_pr_after != value)
                {
                    _ra_pr_after = value;
                    PropertyHasChanged();
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[delseconds]
        //?			secondsafter( ra_time_departed , ra_time_returned )
        public virtual double? Delseconds
        {
            get
            {
                CanReadProperty("Delseconds", true);
                return ((TimeSpan)(_ra_time_returned - _ra_time_departed)).TotalSeconds;
            }
        }

        public virtual TimeSpan Compute1
        {
            get
            {
                CanReadProperty("Compute1", true);
                return new TimeSpan(((TimeSpan)(_ra_time_returned - _ra_time_departed)).Hours, ((TimeSpan)(_ra_time_returned - _ra_time_departed)).Minutes, 0);
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _contract_no, _ra_date_of_check);
        }
        #endregion

        #region Factory Methods
        public static RouteAudit NewRouteAudit()
        {
            return Create();
        }

        public static RouteAudit[] GetAllRouteAudit()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = @"SELECT  route_audit.contract_no ,
                                               route_audit.ra_day_of_check ,
                                               route_audit.ra_date_of_check ,
                                               route_audit.ra_time_started_sort ,
                                               route_audit.ra_time_finished_sort ,
                                               route_audit.ra_time_left_base ,
                                               route_audit.ra_time_returned ,
                                               route_audit.ra_time_departed ,
                                               route_audit.ra_finish_odometer ,
                                               route_audit.ra_start_odometer ,
                                               route_audit.ra_meal_breaks ,
                                               route_audit.ra_extra_time ,
                                               route_audit.ra_extra_distance ,
                                               route_audit.ra_othr_gds_before ,
                                               route_audit.ra_othr_gds_during ,
                                               route_audit.ra_othr_gds_after ,
                                               route_audit.ra_pr_before ,
                                               route_audit.ra_pr_during ,
                                               route_audit.ra_pr_after     
                                          FROM route_audit";

                    List<RouteAudit> _list = new List<RouteAudit>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            RouteAudit instance = new RouteAudit();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._ra_day_of_check = GetValueFromReader<Int32?>(dr, 1);
                            instance._ra_date_of_check = GetValueFromReader<DateTime?>(dr, 2);
                            instance._ra_time_started_sort = GetValueFromReader<DateTime>(dr, 3);
                            instance._ra_time_finished_sort = GetValueFromReader<DateTime>(dr, 4);

                            instance._ra_time_left_base = GetValueFromReader<DateTime>(dr, 5);
                            instance._ra_time_returned = GetValueFromReader<DateTime>(dr, 6);
                            instance._ra_time_departed = GetValueFromReader<DateTime>(dr, 7);
                            instance._ra_finish_odometer = GetValueFromReader<Decimal>(dr, 8);
                            instance._ra_start_odometer = GetValueFromReader<Decimal>(dr, 9);

                            instance._ra_meal_breaks = GetValueFromReader<DateTime>(dr, 10);
                            instance._ra_extra_time = GetValueFromReader<DateTime>(dr, 11);
                            instance._ra_extra_distance = GetValueFromReader<Decimal?>(dr, 12);
                            instance._ra_othr_gds_before = GetValueFromReader<DateTime>(dr, 13);
                            instance._ra_othr_gds_during = GetValueFromReader<DateTime>(dr, 14);

                            instance._ra_othr_gds_after = GetValueFromReader<DateTime>(dr, 15);
                            instance._ra_pr_before = GetValueFromReader<DateTime>(dr, 16);
                            instance._ra_pr_during = GetValueFromReader<DateTime>(dr, 17);
                            instance._ra_pr_after = GetValueFromReader<DateTime>(dr, 18);

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
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "route_audit", ref pList))
                {
                    cm.CommandText += " WHERE  route_audit.contract_no = @contract_no AND " +
                        "route_audit.ra_date_of_check = @ra_date_of_check ";

                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "ra_date_of_check", GetInitialValue("_ra_date_of_check"));
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                // reinitialize original key/value list
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
                if (GenerateInsertCommandText(cm, "route_audit", pList))
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
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "ra_date_of_check", GetInitialValue("_ra_date_of_check"));
                    cm.CommandText = "DELETE FROM route_audit WHERE " +
                    "route_audit.contract_no = @contract_no AND " +
                    "route_audit.ra_date_of_check = @ra_date_of_check ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? contract_no, DateTime? ra_date_of_check)
        {
            _contract_no = contract_no;
            _ra_date_of_check = ra_date_of_check;
        }
    }
}
