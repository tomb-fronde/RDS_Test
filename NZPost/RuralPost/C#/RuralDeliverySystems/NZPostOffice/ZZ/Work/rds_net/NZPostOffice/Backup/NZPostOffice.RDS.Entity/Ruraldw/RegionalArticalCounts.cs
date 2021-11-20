using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  RPCR_093  Feb-2015
    // Changed total deliveries calculations (Compute_1 and Compute_2)

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
    [MapInfo("ac_row_type", "_ac_row_type", "")]
    [System.Serializable()]

    public class RegionalArticalCounts : Entity<RegionalArticalCounts>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private DateTime? _ac_start_week_period;

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

        [DBField()]
        private string _ac_row_type;


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

        public virtual DateTime? AcStartWeekPeriod
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

        public virtual string AcRowType
        {
            get
            {
                CanReadProperty("AcRowType", true);
                return _ac_row_type;
            }
            set
            {
                CanWriteProperty("AcRowType", true);
                if (_ac_row_type != value)
                {
                    _ac_row_type = value;
                    PropertyHasChanged();
                }
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[compute_2]
        public virtual int? Compute2
        {
            get
            {
                int? total_w1_deliveries = (_ac_w1_medium_letters == null ? 0 : _ac_w1_medium_letters) 
                                + (_ac_w1_other_envelopes == null ? 0 : _ac_w1_other_envelopes) 
                                + (_ac_w1_small_parcels == null ? 0 : _ac_w1_small_parcels);
                CanReadProperty("Compute2", true);
                return total_w1_deliveries;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_1]
        public virtual int? Compute1
        {
            get
            {
                int? total_w2_deliveries = (_ac_w2_medium_letters == null ? 0 : _ac_w2_medium_letters)
                                + (_ac_w2_other_envelopes == null ? 0 : _ac_w2_other_envelopes)
                                + (_ac_w2_small_parcels == null ? 0 : _ac_w2_small_parcels);
                CanReadProperty("Compute1", true);
                return total_w2_deliveries;
            }
        }


        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _contract_no, _ac_start_week_period);
        }
        #endregion

        #region Factory Methods
        public static RegionalArticalCounts NewRegionalArticalCounts(int? in_Region, int? in_RenewalGroup, DateTime? in_Period)
        {
            return Create(in_Region, in_RenewalGroup, in_Period);
        }

        public static RegionalArticalCounts[] GetAllRegionalArticalCounts(int? in_Contract, int? in_Region, int? in_RenewalGroup, DateTime? in_Period)
        {
            return Fetch(in_Region, in_RenewalGroup, in_Period).list;
        }

        public void MarkAsNewAndModified()
        {
            base.MarkNew();
            //base.MarkDirty();
            base.MarkClean();
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_Region, int? in_RenewalGroup, DateTime? in_Period)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Region", in_Region);
                    pList.Add(cm, "in_RenewalGroup", in_RenewalGroup);
                    pList.Add(cm, "in_Period", in_Period);
                    cm.CommandText = "sp_GetRegionArticalCounts";

                    List<RegionalArticalCounts> _list = new List<RegionalArticalCounts>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            RegionalArticalCounts instance = new RegionalArticalCounts();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._ac_start_week_period = GetValueFromReader<DateTime?>(dr,1);
                            instance._ac_w1_medium_letters = GetValueFromReader<Int32?>(dr,2);
                            instance._ac_w1_other_envelopes = GetValueFromReader<Int32?>(dr,3);
                            instance._ac_w1_small_parcels = GetValueFromReader<Int32?>(dr,4);
                            instance._ac_w1_large_parcels = GetValueFromReader<Int32?>(dr,5);
                            instance._ac_w1_inward_mail = GetValueFromReader<Int32?>(dr,6);
                            instance._ac_w2_medium_letters = GetValueFromReader<Int32?>(dr,7);
                            instance._ac_w2_other_envelopes = GetValueFromReader<Int32?>(dr,8);
                            instance._ac_w2_small_parcels = GetValueFromReader<Int32?>(dr,9);
                            instance._ac_w2_large_parcels = GetValueFromReader<Int32?>(dr,10);
                            instance._ac_w2_inward_mail = GetValueFromReader<Int32?>(dr,11);
                            instance._ac_row_type = GetValueFromReader<String>(dr,12);
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
        private void InsertEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "insert into artical_count(contract_no,ac_start_week_period,ac_w1_medium_letters,ac_w1_other_envelopes," +
                "ac_w1_small_parcels,ac_w1_large_parcels,ac_w1_inward_mail,ac_w2_medium_letters,ac_w2_other_envelopes," +
                "ac_w2_small_parcels,ac_w2_large_parcels,ac_w2_inward_mail) values(@contract_no,@ac_start_week_period," + 
                "@ac_w1_medium_letters,@ac_w1_other_envelopes,@ac_w1_small_parcels,@ac_w1_large_parcels,@ac_w1_inward_mail,@ac_w2_medium_letters,@ac_w2_other_envelopes," +
                "@ac_w2_small_parcels,@ac_w2_large_parcels,@ac_w2_inward_mail)";


                ParameterCollection pList = new ParameterCollection();
                pList.Add(cm, "contract_no", _contract_no);
                pList.Add(cm, "ac_start_week_period", _ac_start_week_period);
                pList.Add(cm, "ac_w1_medium_letters", _ac_w1_medium_letters);
                pList.Add(cm, "ac_w1_other_envelopes", _ac_w1_other_envelopes);
                pList.Add(cm, "ac_w1_small_parcels", _ac_w1_small_parcels);
                pList.Add(cm, "ac_w1_large_parcels", _ac_w1_large_parcels);
                pList.Add(cm, "ac_w1_inward_mail", _ac_w1_inward_mail);
                pList.Add(cm, "ac_w2_medium_letters", _ac_w2_medium_letters);
                pList.Add(cm, "ac_w2_other_envelopes", _ac_w2_other_envelopes);
                pList.Add(cm, "ac_w2_small_parcels", _ac_w2_small_parcels);
                pList.Add(cm, "ac_w2_large_parcels", _ac_w2_large_parcels);
                pList.Add(cm, "ac_w2_inward_mail", _ac_w2_inward_mail);

                DBHelper.ExecuteNonQuery(cm, pList);
                // reinitialize original key/value list
                StoreInitialValues();
            }
        }
        [ServerMethod()]
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "update artical_count set ac_w1_medium_letters=@ac_w1_medium_letters,ac_w1_other_envelopes=@ac_w1_other_envelopes, " +
                " ac_w1_small_parcels=@ac_w1_small_parcels,ac_w1_large_parcels=@ac_w1_large_parcels,ac_w1_inward_mail=@ac_w1_inward_mail," +
                " ac_w2_medium_letters=@ac_w2_medium_letters,ac_w2_other_envelopes=@ac_w2_other_envelopes," +
                " ac_w2_small_parcels=@ac_w2_small_parcels,ac_w2_large_parcels=@ac_w2_large_parcels,ac_w2_inward_mail=@ac_w2_inward_mail " +
                " where contract_no=@contract_no and ac_start_week_period=@ac_start_week_period";

                ParameterCollection pList = new ParameterCollection();
                pList.Add(cm, "contract_no", _contract_no);
                pList.Add(cm, "ac_start_week_period", _ac_start_week_period);
                pList.Add(cm, "ac_w1_medium_letters", _ac_w1_medium_letters);
                pList.Add(cm, "ac_w1_other_envelopes", _ac_w1_other_envelopes);
                pList.Add(cm, "ac_w1_small_parcels", _ac_w1_small_parcels);
                pList.Add(cm, "ac_w1_large_parcels", _ac_w1_large_parcels);
                pList.Add(cm, "ac_w1_inward_mail", _ac_w1_inward_mail);
                pList.Add(cm, "ac_w2_medium_letters", _ac_w2_medium_letters);
                pList.Add(cm, "ac_w2_other_envelopes", _ac_w2_other_envelopes);
                pList.Add(cm, "ac_w2_small_parcels", _ac_w2_small_parcels);
                pList.Add(cm, "ac_w2_large_parcels", _ac_w2_large_parcels);
                pList.Add(cm, "ac_w2_inward_mail", _ac_w2_inward_mail);

                DBHelper.ExecuteNonQuery(cm, pList);
                // reinitialize original key/value list
                StoreInitialValues();
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? contract_no, DateTime? ac_start_week_period)
        {
            _contract_no = contract_no;
            _ac_start_week_period = ac_start_week_period;
        }




    }
}
