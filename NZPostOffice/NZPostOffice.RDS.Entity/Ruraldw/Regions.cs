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
    [MapInfo("region_id", "_region_id", "")]
    [MapInfo("rgn_name", "_rgn_name", "")]
    [System.Serializable()]

    public class Regions : Entity<Regions>
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
        public static Regions NewRegions()
        {
            return Create();
        }

        public static Regions[] GetAllRegions()
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
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "rd.sp_getregions";
                    List<Regions> _list = new List<Regions>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Regions instance = new Regions();
                            instance._region_id = GetValueFromReader<Int32?>(dr,0);
                            instance._rgn_name = GetValueFromReader<String>(dr,1);
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
