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
    [MapInfo("region_id", "_region_id", "rds_user_rights")]
    [System.Serializable()]

    public class UserComponentRegionlist : Entity<UserComponentRegionlist>
    {
        #region Business Methods
        [DBField()]
        private int? _region_id;

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

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static UserComponentRegionlist NewUserComponentRegionlist(string as_userid, string as_componentname)
        {
            return Create(as_userid, as_componentname);
        }

        public static UserComponentRegionlist[] GetAllUserComponentRegionlist(string as_userid, string as_componentname)
        {
            return Fetch(as_userid, as_componentname).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(string as_userid, string as_componentname)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText += "select rd.rds_user_rights.region_id " +
                        "from  rd.rds_user_id left outer join  rd.rds_user_id_group on rd.rds_user_id.ui_id = rd.rds_user_id_group.ui_id  " +
                        "left outer join rd.rds_user_group  on rd.rds_user_group.ug_id = rd.rds_user_id_group.ug_id " +
                        "left outer join rd.rds_user_rights on rd.rds_user_group.ug_id = rd.rds_user_rights.ug_id  " +
                        "left outer join  rd.rds_component on rd.rds_user_rights.rc_id =rd.rds_component.rc_id " +
                        "WHERE rd.rds_user_id.ui_userid = @as_userid  and upper(rd.rds_component.rc_name) = Upper(@as_componentname) ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "as_userid", as_userid);
                    pList.Add(cm, "as_componentname", as_componentname);

                    List<UserComponentRegionlist> _list = new List<UserComponentRegionlist>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            UserComponentRegionlist instance = new UserComponentRegionlist();
                            instance._region_id = GetValueFromReader<int?>(dr, 0);
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
