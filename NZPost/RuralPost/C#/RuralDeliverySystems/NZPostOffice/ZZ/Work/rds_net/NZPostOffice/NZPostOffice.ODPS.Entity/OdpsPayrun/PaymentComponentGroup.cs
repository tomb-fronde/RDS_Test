using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsPayrun
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("pcg_description", "_pcg_description", "payment_component_group")]
    [MapInfo("pcg_id", "_pcg_id", "payment_component_group")]
    [MapInfo("pcg_short_code", "_pcg_short_code", "payment_component_group")]
    [System.Serializable()]

    public class PaymentComponentGroup : Entity<PaymentComponentGroup>
    {

        #region Business Methods
        [DBField()]
        private string _pcg_description;

        [DBField()]
        private int? _pcg_id;

        [DBField()]
        private string _pcg_short_code;

        public virtual string PcgDescription
        {
            get
            {
                CanReadProperty("PcgDescription", true);
                return _pcg_description;
            }
            set
            {
                CanWriteProperty("PcgDescription", true);
                if (_pcg_description != value)
                {
                    _pcg_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PcgId
        {
            get
            {
                CanReadProperty("PcgId", true);
                return _pcg_id;
            }
            set
            {
                CanWriteProperty("PcgId", true);
                if (_pcg_id != value)
                {
                    _pcg_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PcgShortCode
        {
            get
            {
                CanReadProperty("PcgShortCode", true);
                return _pcg_short_code;
            }
            set
            {
                CanWriteProperty("PcgShortCode", true);
                if (_pcg_short_code != value)
                {
                    _pcg_short_code = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}", _pcg_id);
        }
        #endregion

        #region Factory Methods
        public static PaymentComponentGroup NewPaymentComponentGroup()
        {
            return Create();
        }

        public static PaymentComponentGroup[] GetAllPaymentComponentGroup()
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
                    //GenerateSelectCommandText(cm, "payment_component_group");
                    cm.CommandText = " SELECT payment_component_group.pcg_description," +
                        "payment_component_group.pcg_id," +
                        "payment_component_group.pcg_short_code " +
                        "FROM odps.payment_component_group";

                    List<PaymentComponentGroup> _list = new List<PaymentComponentGroup>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PaymentComponentGroup instance = new PaymentComponentGroup();
                            //instance.StoreFieldValues(dr, "payment_component_group");
                            instance._pcg_description = GetValueFromReader<string>(dr, 0);
                            instance._pcg_id = GetValueFromReader<Int32?>(dr, 1);
                            instance._pcg_short_code = GetValueFromReader<string>(dr, 2);
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
                if (GenerateUpdateCommandText(cm, "payment_component_group", ref pList))
                {
                    cm.CommandText += " WHERE  payment_component_group.pcg_id = @pcg_id ";

                    pList.Add(cm, "pcg_id", GetInitialValue("_pcg_id"));
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
                if (GenerateInsertCommandText(cm, "payment_component_group", pList))
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
                    pList.Add(cm, "pcg_id", GetInitialValue("_pcg_id"));
                    cm.CommandText = "DELETE FROM payment_component_group WHERE " +
                    "payment_component_group.pcg_id = @pcg_id ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? pcg_id)
        {
            _pcg_id = pcg_id;
        }
    }
}
