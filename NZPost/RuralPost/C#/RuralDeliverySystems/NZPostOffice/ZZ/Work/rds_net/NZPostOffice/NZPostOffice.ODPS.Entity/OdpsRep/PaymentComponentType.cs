using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsRep
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("pct_id", "_pct_id", "odps.payment_component_type", true)]
    [MapInfo("ac_id", "_ac_id", "odps.payment_component_type")]
    [MapInfo("pct_description", "_pct_description", "odps.payment_component_type")]
    [MapInfo("pct_witholding_tax_status", "_pct_witholding_tax_status", "odps.payment_component_type")]
    [MapInfo("pcg_id", "_pcg_id", "odps.payment_component_type")]
    [System.Serializable()]

    public class PaymentComponentType : Entity<PaymentComponentType>
    {
        #region Business Methods
        [DBField()]
        private int? _pct_id;

        [DBField()]
        private int? _ac_id;

        [DBField()]
        private string _pct_description;

        [DBField()]
        private string _pct_witholding_tax_status;

        [DBField()]
        private int? _pcg_id;

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

        public virtual int? AcId
        {
            get
            {
                CanReadProperty("AcId", true);
                return _ac_id;
            }
            set
            {
                CanWriteProperty("AcId", true);
                if (_ac_id != value)
                {
                    _ac_id = value;
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

        public virtual string PctWitholdingTaxStatus
        {
            get
            {
                CanReadProperty("PctWitholdingTaxStatus", true);
                return _pct_witholding_tax_status;
            }
            set
            {
                CanWriteProperty("PctWitholdingTaxStatus", true);
                if (_pct_witholding_tax_status != value)
                {
                    _pct_witholding_tax_status = value;
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

        protected override object GetIdValue()
        {
            return string.Format("{0}", _pct_id);
        }
        #endregion

        #region Factory Methods
        public static PaymentComponentType NewPaymentComponentType()
        {
            return Create();
        }

        public static PaymentComponentType[] GetAllPaymentComponentType()
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
                    cm.CommandText = "  SELECT payment_component_type.pct_id," +
                                     "payment_component_type.ac_id," +
                                     "payment_component_type.pct_description," +
                                     "payment_component_type.pct_witholding_tax_status," +
                                     "payment_component_type.pcg_id " +
                                    "FROM odps.payment_component_type";
                    ParameterCollection pList = new ParameterCollection();
                    //GenerateSelectCommandText(cm, "payment_component_type");

                    List<PaymentComponentType> _list = new List<PaymentComponentType>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PaymentComponentType instance = new PaymentComponentType();
                            //instance.StoreFieldValues(dr, "odps.payment_component_type");
                            instance._pct_id = GetValueFromReader<Int32?>(dr, 0);
                            instance._ac_id = GetValueFromReader<Int32?>(dr, 1);
                            instance._pct_description = GetValueFromReader<string>(dr, 2);
                            instance._pct_witholding_tax_status = GetValueFromReader<string>(dr, 3);
                            instance._pcg_id = GetValueFromReader<Int32?>(dr, 4);
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
                if (GenerateUpdateCommandText(cm, "odps.payment_component_type", ref pList))
                {
                    cm.CommandText += " WHERE  payment_component_type.pct_id =@pct_id";
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
                if (GenerateInsertCommandText(cm, "odps.payment_component_type", pList))
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
                    cm.CommandText = "DELETE FROM payment_component_type WHERE payment_component_type.pct_id = @pct_id ";
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
