using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("sl_name", "_sl_name", "suburblocality")]
    [System.Serializable()]

    public class DddwSuburbs : Entity<DddwSuburbs>
    {
        #region Business Methods
        [DBField()]
        private string _sl_name;

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

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static DddwSuburbs NewDddwSuburbs()
        {
            return Create();
        }

        public static DddwSuburbs[] GetAllDddwSuburbs()
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
                    cm.CommandText = "SELECT distinct sl_name " +
                        "from road  left outer join road_suburb on road.road_id= road_suburb.road_id " +
                        "left outer join suburblocality  on road_suburb.sl_id = suburblocality.sl_id " +
                        " where road.road_name like '%'  ";

                    ParameterCollection pList = new ParameterCollection();
                    List<DddwSuburbs> _list = new List<DddwSuburbs>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            DddwSuburbs instance = new DddwSuburbs();
                            instance._sl_name = GetValueFromReader<string>(dr, 0);
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
