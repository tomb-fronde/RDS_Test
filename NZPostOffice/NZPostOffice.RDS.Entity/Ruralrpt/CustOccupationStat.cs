using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("region", "_region", "")]
    [MapInfo("interest", "_interest", "")]
    [MapInfo("interestcount", "_interestcount", "")]
    [System.Serializable()]

    public class CustOccupationStat : Entity<CustOccupationStat>
    {
        #region Business Methods
        [DBField()]
        private string _region;

        [DBField()]
        private string _interest;

        [DBField()]
        private int? _interestcount;

        public virtual string Region
        {
            get
            {
                CanReadProperty("Region", true);
                return _region;
            }
            set
            {
                CanWriteProperty("Region", true);
                if (_region != value)
                {
                    _region = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Interest
        {
            get
            {
                CanReadProperty("Interest", true);
                return _interest;
            }
            set
            {
                CanWriteProperty("Interest", true);
                if (_interest != value)
                {
                    _interest = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Interestcount
        {
            get
            {
                CanReadProperty("Interestcount", true);
                return _interestcount;
            }
            set
            {
                CanWriteProperty("Interestcount", true);
                if (_interestcount != value)
                {
                    _interestcount = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REInterestcount
        {
            get
            {
                return _interestcount;
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static CustOccupationStat NewCustOccupationStat(int? inRegion, int? inOutlet, int? inContractType, int? inPrivacy)
        {
            return Create(inRegion, inOutlet, inContractType, inPrivacy);
        }

        public static CustOccupationStat[] GetAllCustOccupationStat(int? inRegion, int? inOutlet, int? inContractType, int? inPrivacy)
        {
            return Fetch(inRegion, inOutlet, inContractType, inPrivacy).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? inRegion, int? inOutlet, int? inContractType, int? inPrivacy)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_GetCustoccupationStatV2";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inRegion", inRegion);
                    pList.Add(cm, "inOutlet", inOutlet);
                    pList.Add(cm, "inContractType", inContractType);
                    pList.Add(cm, "inPrivacy", inPrivacy);

                    List<CustOccupationStat> _list = new List<CustOccupationStat>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            CustOccupationStat instance = new CustOccupationStat();
                            instance._region = GetValueFromReader<string>(dr, 0);
                            instance._interest = GetValueFromReader<string>(dr, 1);
                            instance._interestcount = GetValueFromReader<int?>(dr, 2);
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
