using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Metex.Core;
using Metex.Core.Security;

using NZPostOffice.Entity;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("rc_name", "_rds_component_rc_name", "rds_component")]
    [MapInfo("rc_description", "_rds_component_rc_description", "rds_component")]
    [MapInfo("rc_id", "_rds_component_rc_id", "rds_component")]
    [MapInfo("rur_create", "_rds_user_rights_rur_create", "rds_user_rights")]
    [MapInfo("region_id", "_rds_user_rights_region_id", "rds_user_rights")]
    [MapInfo("rur_read", "_rds_user_rights_rur_read", "rds_user_rights")]
    [MapInfo("rur_modify", "_rds_user_rights_rur_modify", "rds_user_rights")]
    [MapInfo("rur_delete", "_rds_user_rights_rur_delete", "rds_user_rights")]
    [MapInfo("rur_id", "_rur_id", "rds_user_rights")]
    [MapInfo("ug_id", "_ug_id", "rds_user_rights")]
    [MapInfo("rc_id", "_rds_user_rights_rc_id", "rds_user_rights")]
    [MapInfo("rc_allowcreate", "_rds_component_rc_allowcreate", "rds_component")]
    [MapInfo("rc_allowread", "_rds_component_rc_allowread", "rds_component")]
    [MapInfo("rc_allowmodify", "_rds_component_rc_allowmodify", "rds_component")]
    [MapInfo("rc_allowdelete", "_rds_component_rc_allowdelete", "rds_component")]
    [System.Serializable()]

    public class GroupDetails : RDSEntityBase<GroupDetails>
    {
        #region Business Methods
        [DBField()]
        private string _rds_component_rc_name;

        [DBField()]
        private string _rds_component_rc_description;

        [DBField()]
        private int? _rds_component_rc_id;

        [DBField()]
        private string _rds_user_rights_rur_create;

        [DBField()]
        private int? _rds_user_rights_region_id;

        [DBField()]
        private string _rds_user_rights_rur_read;

        [DBField()]
        private string _rds_user_rights_rur_modify;

        [DBField()]
        private string _rds_user_rights_rur_delete;

        [DBField()]
        private int? _rur_id;

        [DBField()]
        private int? _ug_id;

        [DBField()]
        private int? _rds_user_rights_rc_id;

        [DBField()]
        private string _rds_component_rc_allowcreate;

        [DBField()]
        private string _rds_component_rc_allowread;

        [DBField()]
        private string _rds_component_rc_allowmodify;

        [DBField()]
        private string _rds_component_rc_allowdelete;


        public virtual string RdsComponentRcName
        {
            get
            {
                CanReadProperty(true);
                return _rds_component_rc_name;
            }
            set
            {
                CanWriteProperty(true);
                if (_rds_component_rc_name != value)
                {
                    _rds_component_rc_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RdsComponentRcDescription
        {
            get
            {
                CanReadProperty(true);
                return _rds_component_rc_description;
            }
            set
            {
                CanWriteProperty(true);
                if (_rds_component_rc_description != value)
                {
                    _rds_component_rc_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RdsComponentRcId
        {
            get
            {
                CanReadProperty(true);
                return _rds_component_rc_id;
            }
            set
            {
                CanWriteProperty(true);
                if (_rds_component_rc_id != value)
                {
                    _rds_component_rc_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RdsUserRightsRurCreate
        {
            get
            {
                CanReadProperty(true);
                return _rds_user_rights_rur_create;
            }
            set
            {
                CanWriteProperty(true);
                if (_rds_user_rights_rur_create != value)
                {
                    _rds_user_rights_rur_create = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RdsUserRightsRegionId
        {
            get
            {
                CanReadProperty(true);
                return _rds_user_rights_region_id;
            }
            set
            {
                CanWriteProperty(true);
                if (_rds_user_rights_region_id != value)
                {
                    _rds_user_rights_region_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RdsUserRightsRurRead
        {
            get
            {
                CanReadProperty(true);
                return _rds_user_rights_rur_read;
            }
            set
            {
                CanWriteProperty(true);
                if (_rds_user_rights_rur_read != value)
                {
                    _rds_user_rights_rur_read = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RdsUserRightsRurModify
        {
            get
            {
                CanReadProperty(true);
                return _rds_user_rights_rur_modify;
            }
            set
            {
                CanWriteProperty(true);
                if (_rds_user_rights_rur_modify != value)
                {
                    _rds_user_rights_rur_modify = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RdsUserRightsRurDelete
        {
            get
            {
                CanReadProperty(true);
                return _rds_user_rights_rur_delete;
            }
            set
            {
                CanWriteProperty(true);
                if (_rds_user_rights_rur_delete != value)
                {
                    _rds_user_rights_rur_delete = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RurId
        {
            get
            {
                CanReadProperty(true);
                return _rur_id;
            }
            set
            {
                CanWriteProperty(true);
                if (_rur_id != value)
                {
                    _rur_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? UgId
        {
            get
            {
                CanReadProperty(true);
                return _ug_id;
            }
            set
            {
                CanWriteProperty(true);
                if (_ug_id != value)
                {
                    _ug_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RdsUserRightsRcId
        {
            get
            {
                CanReadProperty(true);
                return _rds_user_rights_rc_id;
            }
            set
            {
                CanWriteProperty(true);
                if (_rds_user_rights_rc_id != value)
                {
                    _rds_user_rights_rc_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RdsComponentRcAllowcreate
        {
            get
            {
                CanReadProperty(true);
                return _rds_component_rc_allowcreate;
            }
            set
            {
                CanWriteProperty(true);
                if (_rds_component_rc_allowcreate != value)
                {
                    _rds_component_rc_allowcreate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RdsComponentRcAllowread
        {
            get
            {
                CanReadProperty(true);
                return _rds_component_rc_allowread;
            }
            set
            {
                CanWriteProperty(true);
                if (_rds_component_rc_allowread != value)
                {
                    _rds_component_rc_allowread = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RdsComponentRcAllowmodify
        {
            get
            {
                CanReadProperty(true);
                return _rds_component_rc_allowmodify;
            }
            set
            {
                CanWriteProperty(true);
                if (_rds_component_rc_allowmodify != value)
                {
                    _rds_component_rc_allowmodify = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RdsComponentRcAllowdelete
        {
            get
            {
                CanReadProperty(true);
                return _rds_component_rc_allowdelete;
            }
            set
            {
                CanWriteProperty(true);
                if (_rds_component_rc_allowdelete != value)
                {
                    _rds_component_rc_allowdelete = value;
                    PropertyHasChanged();
                }
            }
        }

        public string ButtonText
        {
            get
            {
                return "...";
            }
        }

        private GroupDetails[] dataList;

        protected override object GetIdValue()
        {
            return string.Format("{0}", _rur_id);
        }

        private bool _newModified = false;
        public bool NewModified
        {
            get
            {
                return _newModified;
            }
        }
        #endregion

        #region Factory Methods
        public static GroupDetails NewGroupDetails(int? rur_id)
        {
            return Create(rur_id);
        }

        public static GroupDetails[] GetAllGroupDetails(int al_group_id)
        {
            return Fetch(al_group_id).dataList;
        }
        #endregion

        #region Data Access
        protected override void PropertyHasChanged(string propertyName)
        {
            base.PropertyHasChanged(propertyName);
            _newModified = true;
        }
        [ServerMethod]
        private void FetchEntity(int al_group_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_group_id", al_group_id);
                    cm.CommandText = "SELECT  rds_component.rc_name , " +
                           "rds_component.rc_description , " +
                           "rds_component.rc_id , " +
                           "rds_user_rights.rur_create , " +
                           "rds_user_rights.region_id , " +
                           "rds_user_rights.rur_read , " +
                           "rds_user_rights.rur_modify , " +
                           "rds_user_rights.rur_delete , " +
                           "rds_user_rights.rur_id , " +
                           "rds_user_rights.ug_id , " +
                           "rds_user_rights.rc_id , " +
                           "rds_component.rc_allowcreate , " +
                           "rds_component.rc_allowread , " +
                           "rds_component.rc_allowmodify , " +
                           "rds_component.rc_allowdelete   " +
                        "FROM {oj rds_user_rights LEFT OUTER JOIN rds_component ON rds_user_rights.rc_id = rds_component.rc_id}    " +
                        "WHERE ( rds_user_rights.ug_id = @al_group_id ) " +
                        "order by rds_component.rc_description asc";

                    List<GroupDetails> list = new List<GroupDetails>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            GroupDetails instance = new GroupDetails();
                            instance.StoreFieldValues(dr, "rds_component");
                            instance.StoreFieldValues(dr, "rds_user_rights");
                            //instance._rds_component_rc_description = instance._rds_component_rc_description.Trim();
                            instance.MarkOld();
                            list.Add(instance);
                        }
                        StoreInitialValues();
                        dataList = new GroupDetails[list.Count];
                        list.CopyTo(dataList);
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
                if (_rds_component_rc_id.GetValueOrDefault() <= 0)
                {
                    if (_rds_user_rights_rc_id > 0)
                    {
                        _rds_component_rc_id = _rds_user_rights_rc_id;
                        if (string.IsNullOrEmpty(_rds_component_rc_name))
                        {
                            cm.CommandText = "select rc_name from rds_component where rc_id = @ll_rc_id";
                            pList.Add(cm, "ll_rc_id", _rds_component_rc_id);
                            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                            {
                                if (dr.Read())
                                {
                                    _rds_component_rc_name = dr.GetString(0);
                                }
                            }
                        }
                    }
                }
                pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "rds_user_rights", ref pList))
                {
                    cm.CommandText += " WHERE  rds_user_rights.rur_id = @rur_id ";
                    pList.Add(cm, "rur_id", GetInitialValue("_rur_id"));
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
                if (_rur_id == null)
                {
                    _rur_id = GetNextSequence(cm, "rdsUserRights");
                }
                if (_rds_component_rc_id.GetValueOrDefault() <= 0)
                {
                    if (_rds_user_rights_rc_id > 0)
                    {
                        _rds_component_rc_id = _rds_user_rights_rc_id;
                        if (string.IsNullOrEmpty(_rds_component_rc_name))
                        {
                            cm.CommandText = "select rc_name from rds_component where rc_id = @ll_rc_id";
                            pList.Add(cm, "ll_rc_id", _rds_component_rc_id);
                            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                            {
                                if (dr.Read())
                                {
                                    _rds_component_rc_name = dr.GetString(0);
                                }
                            }
                        }
                    }
                }
                if (GenerateInsertCommandText(cm, "rds_user_rights", pList))
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
                    pList.Add(cm, "rur_id", GetInitialValue("_rur_id"));
                    cm.CommandText = "DELETE FROM rds_user_rights WHERE " +
                    "rds_user_rights.rur_id = @rur_id ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? rur_id)
        {
            _rur_id = rur_id;
        }
    }
}
