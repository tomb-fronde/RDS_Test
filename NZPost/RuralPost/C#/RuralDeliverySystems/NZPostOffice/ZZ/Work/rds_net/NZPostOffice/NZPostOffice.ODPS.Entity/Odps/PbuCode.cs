using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.Odps
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("pbu_code", "_pbu_code", "pbu_code")]
    [MapInfo("pbu_description", "_pbu_description", "pbu_code")]
    [MapInfo("pbu_id", "_pbu_id", "pbu_code", true)]
    [System.Serializable()]

    public class PbuCode : Entity<PbuCode>
    {
        #region Business Methods
        [DBField()]
        private string _pbu_code;

        [DBField()]
        private string _pbu_description;

        [DBField()]
        private int? _pbu_id;

        public virtual string Pbucode
        {
            get
            {
                CanReadProperty(true);
                return _pbu_code;
            }
            set
            {
                CanWriteProperty(true);
                if (_pbu_code != value)
                {
                    _pbu_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PbuDescription
        {
            get
            {
                CanReadProperty(true);
                return _pbu_description;
            }
            set
            {
                CanWriteProperty(true);
                if (_pbu_description != value)
                {
                    _pbu_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PbuId
        {
            get
            {
                CanReadProperty(true);
                return _pbu_id;
            }
            set
            {
                CanWriteProperty(true);
                if (_pbu_id != value)
                {
                    _pbu_id = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}", _pbu_id);
        }
        #endregion

        #region Factory Methods
        public static PbuCode NewPbuCode()
        {
            return Create();
        }

        public static PbuCode[] GetAllPbuCode()
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
                    ParameterCollection pList = new ParameterCollection();
                    //GenerateSelectCommandText(cm, "odps.pbu_code");
                    cm.CommandText = @"  SELECT odps.pbu_code.pbu_code,odps.pbu_code.pbu_description,odps.pbu_code.pbu_id  FROM odps.pbu_code";

                    List<PbuCode> _list = new List<PbuCode>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PbuCode instance = new PbuCode();
                            instance.Pbucode = GetValueFromReader<string>(dr, 0);
                            instance.PbuDescription = GetValueFromReader<string>(dr, 1);
                            instance.PbuId = GetValueFromReader<Int32?>(dr, 2);
                            //instance.StoreFieldValues(dr, "odps.pbu_code");
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
                if (GenerateUpdateCommandText(cm, "pbu_code", ref pList))
                {
                    cm.CommandText += " WHERE  pbu_code.pbu_id =@pbu_id";
                    pList.Add(cm, "pbu_id", GetInitialValue("_pbu_id"));
                    
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception ex)
                    {
                        this.sqlCode = -1;
                        this.sqlErrText = ex.Message.ToString();
                    }
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
                if (GenerateInsertCommandText(cm, "pbu_code", pList))
                {
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception ex)
                    {
                        this.sqlCode = -1;
                        this.sqlErrText = ex.Message.ToString();
                    }
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
                    pList.Add(cm, "pbu_id", GetInitialValue("_pbu_id"));
                    cm.CommandText = "DELETE FROM pbu_code WHERE pbu_code.pbu_id = @pbu_id ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? pbu_id)
        {
            _pbu_id = pbu_id;
        }
    }
}
