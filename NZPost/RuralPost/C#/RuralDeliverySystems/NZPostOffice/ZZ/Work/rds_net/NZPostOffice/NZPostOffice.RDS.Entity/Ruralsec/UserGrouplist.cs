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
    [MapInfo("ug_id", "_id", "rd.rds_user_id_group")]
    [MapInfo("ug_name", "_rds_user_group_ug_name", "rd.rds_user_group")]
    [System.Serializable()]

    public class UserGrouplist : Entity<UserGrouplist>
    {
        #region Business Methods
        [DBField()]
        private int? _id;

        [DBField()]
        private string _rds_user_group_ug_name;

        public virtual int? Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
            set
            {
                CanWriteProperty("Id", true);
                if (_id != value)
                {
                    _id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RDSUserGroupUgName
        {
            get
            {
                CanReadProperty("RDSUserGroupUgName", true);
                return _rds_user_group_ug_name;
            }
            set
            {
                CanWriteProperty("RDSUserGroupUgName", true);
                if (_rds_user_group_ug_name != value)
                {
                    _rds_user_group_ug_name = value;
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
        public static UserGrouplist NewUserGrouplist(string as_userid)
        {
            return Create(as_userid);
        }

        public static UserGrouplist[] GetAllUserGrouplist(string as_userid)
        {
            return Fetch(as_userid).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(string as_userid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT rds_user_id_group.ug_id, rds_user_group.ug_name " +
                        "FROM rd.rds_user_id_group, rd.rds_user_id, rd.rds_user_group " +
                        "WHERE ( rds_user_id.ui_id = rds_user_id_group.ui_id ) and " +
                        "( rds_user_group.ug_id = rds_user_id_group.ug_id ) and (( rds_user_id.ui_userid = @as_userid ))";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "as_userid", as_userid);

                    List<UserGrouplist> _list = new List<UserGrouplist>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            UserGrouplist instance = new UserGrouplist();
                            instance._id = GetValueFromReader<int?>(dr, 0);
                            instance._rds_user_group_ug_name = GetValueFromReader<string>(dr, 1);
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
