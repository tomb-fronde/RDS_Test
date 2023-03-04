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
    [MapInfo("rc_id", "_id", "rds_component")]
    [MapInfo("rc_name", "_name", "rds_component")]
    [MapInfo("rc_description", "_description", "rds_component")]
    [System.Serializable()]

    public class Componentlist : Entity<Componentlist>
    {
        #region Business Methods
        [DBField()]
        private int? _id;

        [DBField()]
        private string _name;

        [DBField()]
        private string _description;

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

        protected override object GetIdValue()
        {
            return string.Format("{0}", _id);
        }
        #endregion

        #region Factory Methods
        public static Componentlist NewComponentlist()
        {
            return Create();
        }

        public static Componentlist[] GetAllComponentlist()
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
                    cm.CommandText = "SELECT rds_component.rc_id, rds_component.rc_name, rds_component.rc_description  FROM rd.rds_component  ";
                    ParameterCollection pList = new ParameterCollection();

                    List<Componentlist> _list = new List<Componentlist>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Componentlist instance = new Componentlist();
                            instance._id = GetValueFromReader<int?>(dr, 0);
                            instance._name = GetValueFromReader<string>(dr, 1);
                            instance._description = GetValueFromReader<string>(dr, 2);
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
                if (GenerateUpdateCommandText(cm, "rds_component", ref pList))
                {
                    cm.CommandText += " WHERE  rds_component.rc_id = @rc_id ";

                    pList.Add(cm, "rc_id", GetInitialValue("_id"));
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
                if (GenerateInsertCommandText(cm, "rds_component", pList))
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
                    pList.Add(cm, "rc_id", GetInitialValue("_id"));
                    cm.CommandText = "DELETE FROM rds_component WHERE " +
                    "rds_component.rc_id = @rc_id ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? id)
        {
            _id = id;
        }
    }
}
