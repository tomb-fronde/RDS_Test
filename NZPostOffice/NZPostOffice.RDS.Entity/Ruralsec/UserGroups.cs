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
    [MapInfo("ug_id", "_group_id", "rd.rds_user_id_group")]
    [MapInfo("ug_name", "_group_name", "rd.rds_user_group")]
    [MapInfo("ug_description", "_group_description", "rd.rds_user_group")]
    [MapInfo("ug_created_date", "_created_date", "rd.rds_user_group")]
    [MapInfo("ug_created_by", "_created_by", "rd.rds_user_group")]
    [MapInfo("ug_modified_date", "_modified_date", "rd.rds_user_group")]
    [MapInfo("ug_modified_by", "_modified_by", "rd.rds_user_group")]
    [MapInfo("ug_privacy_override", "_privacy_override", "rd.rds_user_group")]
    [System.Serializable()]

    public class UserGroups : Entity<UserGroups>
    {
        #region Business Methods
        [DBField()]
        private int? _group_id;

        [DBField()]
        private string _group_name;

        [DBField()]
        private string _group_description;

        [DBField()]
        private DateTime? _created_date;

        [DBField()]
        private string _created_by;

        [DBField()]
        private DateTime? _modified_date;

        [DBField()]
        private string _modified_by;

        [DBField()]
        private string _privacy_override;

        public virtual int? GroupId
        {
            get
            {
                CanReadProperty("GroupId", true);
                return _group_id;
            }
            set
            {
                CanWriteProperty("GroupId", true);
                if (_group_id != value)
                {
                    _group_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string GroupName
        {
            get
            {
                CanReadProperty("GroupName", true);
                return _group_name;
            }
            set
            {
                CanWriteProperty("GroupName", true);
                if (_group_name != value)
                {
                    _group_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string GroupDescription
        {
            get
            {
                CanReadProperty("GroupDescription", true);
                return _group_description;
            }
            set
            {
                CanWriteProperty("GroupDescription", true);
                if (_group_description != value)
                {
                    _group_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? CreatedDate
        {
            get
            {
                CanReadProperty("CreatedDate", true);
                return _created_date;
            }
            set
            {
                CanWriteProperty("CreatedDate", true);
                if (_created_date != value)
                {
                    _created_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CreatedBy
        {
            get
            {
                CanReadProperty("CreatedBy", true);
                return _created_by;
            }
            set
            {
                CanWriteProperty("CreatedBy", true);
                if (_created_by != value)
                {
                    _created_by = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? ModifiedDate
        {
            get
            {
                CanReadProperty("ModifiedDate", true);
                return _modified_date;
            }
            set
            {
                CanWriteProperty("ModifiedDate", true);
                if (_modified_date != value)
                {
                    _modified_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ModifiedBy
        {
            get
            {
                CanReadProperty("ModifiedBy", true);
                return _modified_by;
            }
            set
            {
                CanWriteProperty("ModifiedBy", true);
                if (_modified_by != value)
                {
                    _modified_by = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PrivacyOverride
        {
            get
            {
                CanReadProperty("PrivacyOverride", true);
                return _privacy_override;
            }
            set
            {
                CanWriteProperty("PrivacyOverride", true);
                if (_privacy_override != value)
                {
                    _privacy_override = value;
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
        public static UserGroups NewUserGroups(string as_userid)
        {
            return Create(as_userid);
        }

        public static UserGroups[] GetAllUserGroups(string as_userid)
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
                    cm.CommandText = "SELECT rds_user_id_group.ug_id, rds_user_group.ug_name, rds_user_group.ug_description, " +
                        "rds_user_group.ug_created_date, rds_user_group.ug_created_by, rds_user_group.ug_modified_date," +
                        "rds_user_group.ug_modified_by, rds_user_group.ug_privacy_override " +
                        "FROM rd.rds_user_id_group, rd.rds_user_group, rd.rds_user_id " +
                        "WHERE ( rds_user_group.ug_id = rds_user_id_group.ug_id ) and " +
                        "( rds_user_id.ui_id = rds_user_id_group.ui_id ) and " +
                        "(( rds_user_id.ui_userid = @as_userid ))";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "as_userid", as_userid);

                    List<UserGroups> _list = new List<UserGroups>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            UserGroups instance = new UserGroups();
                            instance._group_id = GetValueFromReader<int?>(dr, 0);
                            instance._group_name = GetValueFromReader<string>(dr, 1);
                            instance._group_description = GetValueFromReader<string>(dr, 2);
                            instance._created_date = GetValueFromReader<DateTime?>(dr, 3);
                            instance._created_by = GetValueFromReader<string>(dr, 4);
                            instance._modified_date = GetValueFromReader<DateTime?>(dr, 5);
                            instance._modified_by = GetValueFromReader<string>(dr, 6);
                            instance._privacy_override = GetValueFromReader<string>(dr, 7);
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
