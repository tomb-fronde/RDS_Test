using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsCodes
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("pct_id", "_pct_id", "payment_component_type")]
    [MapInfo("pct_description", "_pct_description", "payment_component_type")]
    [System.Serializable()]

    public class DddwPtaCode : Entity<DddwPtaCode>
    {
        #region Business Methods
        [DBField()]
        private int? _pct_id;

        [DBField()]
        private string _pct_description;

        public virtual int? PctId
        {
            get
            {
                CanReadProperty("PctId", true);
                return _pct_id;
            }
            set
            {
                CanWriteProperty("PctId", true);
                if (_pct_id != value)
                {
                    _pct_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PctDescription
        {
            get
            {
                CanReadProperty("PctDescription", true);
                return _pct_description;
            }
            set
            {
                CanWriteProperty("PctDescription", true);
                if (_pct_description != value)
                {
                    _pct_description = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}", _pct_id);
        }
        #endregion

        #region Factory Methods
        public static DddwPtaCode NewDddwPtaCode()
        {
            return Create();
        }

        public static DddwPtaCode[] GetAllDddwPtaCode()
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
                    //GenerateSelectCommandText(cm, "odps.payment_component_type");
                    cm.CommandText = @"  SELECT odps.payment_component_type.pct_id,odps.payment_component_type.pct_description  
                                    FROM odps.payment_component_type 
                                    WHERE odps.payment_component_type.pct_description like 'Post-tax adj%' ";

                    List<DddwPtaCode> _list = new List<DddwPtaCode>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            DddwPtaCode instance = new DddwPtaCode();
                            instance._pct_id = GetValueFromReader<Int32?>(dr, 0);
                            instance._pct_description = GetValueFromReader<string>(dr, 1);
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
                if (GenerateUpdateCommandText(cm, "payment_component_type", ref pList))
                {
                    cm.CommandText += " WHERE  payment_component_type.pct_id = @pct_id ";

                    pList.Add(cm, "pct_id", GetInitialValue("_pct_id"));
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
                if (GenerateInsertCommandText(cm, "payment_component_type", pList))
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
                    pList.Add(cm, "pct_id", GetInitialValue("_pct_id"));
                    cm.CommandText = "DELETE FROM payment_component_type WHERE " +
                    "payment_component_type.pct_id = @pct_id ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? pct_id)
        {
            _pct_id = pct_id;
        }
    }
}
