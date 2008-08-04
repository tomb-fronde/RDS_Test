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
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("ac_start_week_period", "_ac_start_week_period", "")]
    [MapInfo("ac_w1_medium_letters", "_ac_w1_medium_letters", "")]
    [MapInfo("ac_w1_other_envelopes", "_ac_w1_other_envelopes", "")]
    [MapInfo("ac_w1_small_parcels", "_ac_w1_small_parcels", "")]
    [MapInfo("ac_w1_large_parcels", "_ac_w1_large_parcels", "")]
    [MapInfo("ac_w1_inward_mail", "_ac_w1_inward_mail", "")]
    [MapInfo("ac_w2_medium_letters", "_ac_w2_medium_letters", "")]
    [MapInfo("ac_w2_other_envelopes", "_ac_w2_other_envelopes", "")]
    [MapInfo("ac_w2_small_parcels", "_ac_w2_small_parcels", "")]
    [MapInfo("ac_w2_large_parcels", "_ac_w2_large_parcels", "")]
    [MapInfo("ac_w2_inward_mail", "_ac_w2_inward_mail", "")]
    [System.Serializable()]

    public class AddArticalCounts : Entity<AddArticalCounts>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _ac_start_week_period;

        [DBField()]
        private int? _ac_w1_medium_letters;

        [DBField()]
        private int? _ac_w1_other_envelopes;

        [DBField()]
        private int? _ac_w1_small_parcels;

        [DBField()]
        private int? _ac_w1_large_parcels;

        [DBField()]
        private int? _ac_w1_inward_mail;

        [DBField()]
        private int? _ac_w2_medium_letters;

        [DBField()]
        private int? _ac_w2_other_envelopes;

        [DBField()]
        private int? _ac_w2_small_parcels;

        [DBField()]
        private int? _ac_w2_large_parcels;

        [DBField()]
        private int? _ac_w2_inward_mail;


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

        public virtual int? AcStartWeekPeriod
        {
            get
            {
                CanReadProperty("AcStartWeekPeriod", true);
                return _ac_start_week_period;
            }
            set
            {
                CanWriteProperty("AcStartWeekPeriod", true);
                if (_ac_start_week_period != value)
                {
                    _ac_start_week_period = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcW1MediumLetters
        {
            get
            {
                CanReadProperty("AcW1MediumLetters", true);
                return _ac_w1_medium_letters;
            }
            set
            {
                CanWriteProperty("AcW1MediumLetters", true);
                if (_ac_w1_medium_letters != value)
                {
                    _ac_w1_medium_letters = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcW1OtherEnvelopes
        {
            get
            {
                CanReadProperty("AcW1OtherEnvelopes", true);
                return _ac_w1_other_envelopes;
            }
            set
            {
                CanWriteProperty("AcW1OtherEnvelopes", true);
                if (_ac_w1_other_envelopes != value)
                {
                    _ac_w1_other_envelopes = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcW1SmallParcels
        {
            get
            {
                CanReadProperty("AcW1SmallParcels", true);
                return _ac_w1_small_parcels;
            }
            set
            {
                CanWriteProperty("AcW1SmallParcels", true);
                if (_ac_w1_small_parcels != value)
                {
                    _ac_w1_small_parcels = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcW1LargeParcels
        {
            get
            {
                CanReadProperty("AcW1LargeParcels", true);
                return _ac_w1_large_parcels;
            }
            set
            {
                CanWriteProperty("AcW1LargeParcels", true);
                if (_ac_w1_large_parcels != value)
                {
                    _ac_w1_large_parcels = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcW1InwardMail
        {
            get
            {
                CanReadProperty("AcW1InwardMail", true);
                return _ac_w1_inward_mail;
            }
            set
            {
                CanWriteProperty("AcW1InwardMail", true);
                if (_ac_w1_inward_mail != value)
                {
                    _ac_w1_inward_mail = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcW2MediumLetters
        {
            get
            {
                CanReadProperty("AcW2MediumLetters", true);
                return _ac_w2_medium_letters;
            }
            set
            {
                CanWriteProperty("AcW2MediumLetters", true);
                if (_ac_w2_medium_letters != value)
                {
                    _ac_w2_medium_letters = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcW2OtherEnvelopes
        {
            get
            {
                CanReadProperty("AcW2OtherEnvelopes", true);
                return _ac_w2_other_envelopes;
            }
            set
            {
                CanWriteProperty("AcW2OtherEnvelopes", true);
                if (_ac_w2_other_envelopes != value)
                {
                    _ac_w2_other_envelopes = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcW2SmallParcels
        {
            get
            {
                CanReadProperty("AcW2SmallParcels", true);
                return _ac_w2_small_parcels;
            }
            set
            {
                CanWriteProperty("AcW2SmallParcels", true);
                if (_ac_w2_small_parcels != value)
                {
                    _ac_w2_small_parcels = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcW2LargeParcels
        {
            get
            {
                CanReadProperty("AcW2LargeParcels", true);
                return _ac_w2_large_parcels;
            }
            set
            {
                CanWriteProperty("AcW2LargeParcels", true);
                if (_ac_w2_large_parcels != value)
                {
                    _ac_w2_large_parcels = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcW2InwardMail
        {
            get
            {
                CanReadProperty("AcW2InwardMail", true);
                return _ac_w2_inward_mail;
            }
            set
            {
                CanWriteProperty("AcW2InwardMail", true);
                if (_ac_w2_inward_mail != value)
                {
                    _ac_w2_inward_mail = value;
                    PropertyHasChanged();
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_2]
        //?if(isnull(ac_w2_medium_letters),0,ac_w2_medium_letters) + if(isnull(ac_w2_other_envelopes),0,ac_w2_other_envelopes) + if(isnull(ac_w2_small_parcels),0,ac_w2_small_parcels)
        public virtual int? Compute2
        {
            get
            {
                CanReadProperty("Compute2", true);
                return (_ac_w2_medium_letters == null ? 0 : _ac_w2_medium_letters) + (_ac_w2_other_envelopes == null ? 0 : _ac_w2_other_envelopes) + (_ac_w2_small_parcels == null ? 0 : _ac_w2_small_parcels) + (_ac_w2_large_parcels == null ? 0 : _ac_w2_large_parcels);

            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_1]
        //?if(isnull(ac_w1_medium_letters),0,ac_w1_medium_letters) + if(isnull(ac_w1_other_envelopes),0,ac_w1_other_envelopes) + if(isnull(ac_w1_small_parcels),0,ac_w1_small_parcels)
        public virtual int? Compute1
        {
            get
            {
                CanReadProperty("Compute1", true);
                return (_ac_w1_medium_letters == null ? 0 : _ac_w1_medium_letters) + (_ac_w1_other_envelopes == null ? 0 : _ac_w1_other_envelopes) + (_ac_w1_small_parcels == null ? 0 : _ac_w1_small_parcels) + (_ac_w1_large_parcels == null ? 0 : _ac_w1_large_parcels);

            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _contract_no, _ac_start_week_period);
        }
        #endregion

        #region Factory Methods
        public static AddArticalCounts NewAddArticalCounts(int? in_Contract, int? in_WeekPeriod)
        {
            return Create(in_Contract, in_WeekPeriod);
        }

        public static AddArticalCounts[] GetAllAddArticalCounts(int? in_Contract, int? in_WeekPeriod)
        {
            return Fetch(in_Contract, in_WeekPeriod).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_Contract, int? in_WeekPeriod)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_GetRawArticalCounts";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Contract", in_Contract);
                    pList.Add(cm, "in_WeekPeriod", in_WeekPeriod);

                    List<AddArticalCounts> _list = new List<AddArticalCounts>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            AddArticalCounts instance = new AddArticalCounts();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._ac_start_week_period = GetValueFromReader<Int32?>(dr, 1);
                            instance._ac_w1_medium_letters = GetValueFromReader<Int32?>(dr, 2);
                            instance._ac_w1_other_envelopes = GetValueFromReader<Int32?>(dr, 3);
                            instance._ac_w1_small_parcels = GetValueFromReader<Int32?>(dr, 4);
                            instance._ac_w1_large_parcels = GetValueFromReader<Int32?>(dr, 5);
                            instance._ac_w1_inward_mail = GetValueFromReader<Int32?>(dr, 6);
                            instance._ac_w2_medium_letters = GetValueFromReader<Int32?>(dr, 7);
                            instance._ac_w2_other_envelopes = GetValueFromReader<Int32?>(dr, 8);
                            instance._ac_w2_small_parcels = GetValueFromReader<Int32?>(dr, 9);
                            instance._ac_w2_large_parcels = GetValueFromReader<Int32?>(dr, 10);
                            instance._ac_w2_inward_mail = GetValueFromReader<Int32?>(dr, 11);
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
        private void CreateEntity(int? contract_no, int? ac_start_week_period)
        {
            _contract_no = contract_no;
            _ac_start_week_period = ac_start_week_period;
        }
    }
}
