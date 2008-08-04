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
    [MapInfo("ug_id", "_group_id", "rds_user_group")]
    [MapInfo("ug_name", "_name", "rds_user_group")]
    [MapInfo("ug_description", "_description", "rds_user_group")]
    [MapInfo("ug_created_date", "_created_date", "rds_user_group")]
    [MapInfo("ug_created_by", "_created_by", "rds_user_group")]
    [MapInfo("ug_modified_date", "_modified_date", "rds_user_group")]
    [MapInfo("ug_modified_by", "_modified_by", "rds_user_group")]
    [MapInfo("ug_privacy_override", "_privacy_override", "rds_user_group")]
    [System.Serializable()]

    public class GroupDetails : Entity<GroupDetails>
    {
        #region Business Methods
        [DBField()]
        private int? _group_id;

        [DBField()]
        private string _name;

        [DBField()]
        private string _description;

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

        public virtual string Name
        {
            get
            {
                CanReadProperty("Name", true);
                return _name;
            }
            set
            {
                CanWriteProperty("Name", true);
                if (_name != value)
                {
                    _name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Description
        {
            get
            {
                CanReadProperty("Description", true);
                return _description;
            }
            set
            {
                CanWriteProperty("Description", true);
                if (_description != value)
                {
                    _description = value;
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
            return string.Format("{0}", _group_id);
        }
        #endregion

        #region Factory Methods
        public static GroupDetails NewGroupDetails(int? al_group_id)
        {
            return Create(al_group_id);
        }

        public static GroupDetails[] GetAllGroupDetails(int? al_group_id)
        {
            return Fetch(al_group_id).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? al_group_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT rds_user_group.ug_id,  rds_user_group.ug_name, rds_user_group.ug_description, " +
                        "rds_user_group.ug_created_date, rds_user_group.ug_created_by, rds_user_group.ug_modified_date, " +
                        "rds_user_group.ug_modified_by,  rds_user_group.ug_privacy_override " +
                        "FROM rd.rds_user_group  WHERE rds_user_group.ug_id = @al_group_id  ";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_group_id", al_group_id);

                    List<GroupDetails> _list = new List<GroupDetails>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            GroupDetails instance = new GroupDetails();
                            instance._group_id = GetValueFromReader<int?>(dr, 0);
                            instance._name = GetValueFromReader<string>(dr, 1);
                            instance._description = GetValueFromReader<string>(dr, 2);
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

        [ServerMethod()]
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "rds_user_group", ref pList))
                {
                    cm.CommandText += " WHERE  rds_user_group.ug_id = @ug_id ";

                    pList.Add(cm, "ug_id", GetInitialValue("_group_id"));
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
                if (GenerateInsertCommandText(cm, "rds_user_group", pList))
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
                    pList.Add(cm, "ug_id", GetInitialValue("_group_id"));
                    cm.CommandText = "DELETE FROM rds_user_group WHERE " +
                    "rds_user_group.ug_id = @ug_id ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? group_id)
        {
            _group_id = group_id;
        }
    }
}
