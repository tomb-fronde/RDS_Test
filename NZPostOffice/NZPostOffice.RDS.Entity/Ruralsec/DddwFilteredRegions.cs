using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralsec
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("region_id", "_region_id", "")]
    [MapInfo("rgn_name", "_rgn_name", "")]
    [System.Serializable()]

    public class DddwFilteredRegions : Entity<DddwFilteredRegions>
    {
        #region Business Methods
        [DBField()]
        private int? _region_id;

        [DBField()]
        private string _rgn_name;

        public virtual int? RegionId
        {
            get
            {
                CanReadProperty("RegionId", true);
                return _region_id;
            }
            set
            {
                CanWriteProperty("RegionId", true);
                if (_region_id != value)
                {
                    _region_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RgnName
        {
            get
            {
                CanReadProperty("RgnName", true);
                return _rgn_name;
            }
            set
            {
                CanWriteProperty("RgnName", true);
                if (_rgn_name != value)
                {
                    _rgn_name = value;
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
        public static DddwFilteredRegions NewDddwFilteredRegions()
        {
            return Create();
        }

        public static DddwFilteredRegions[] GetAllDddwFilteredRegions()
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
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_DDDW_Regions";
                    ParameterCollection pList = new ParameterCollection();

                    List<DddwFilteredRegions> _list = new List<DddwFilteredRegions>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            DddwFilteredRegions instance = new DddwFilteredRegions();
                            instance._region_id = GetValueFromReader<int?>(dr, 0);
                            instance._rgn_name = GetValueFromReader<string>(dr, 1);
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
