using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;
using NZPostOffice.Shared.LogicUnits;

namespace NZPostOffice.ODPS.Entity.OdpsLib
{
    // TJB  RPCR_098  Jan-2016: NEW
    // Holds imported PTD data prior to updating the database 
    // via InsertPTDs() in ODPSDataService

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("amount", "_amount", "")]
    [MapInfo("description", "_description", "")]
    [MapInfo("reference", "_reference", "")]
    [MapInfoIndex(new string[] { "contract_no", "amount", "description", "reference" })]
    [System.Serializable()]

    public class PTDImport : Entity<PTDImport>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private decimal? _amount;

        [DBField()]
        private string _description;

        [DBField()]
        private string _reference;

        public virtual int? ContractNo
        {
            get
            {
                CanReadProperty("ContractNo", true);
                return _contract_no;
            }
            set
            {
                CanWriteProperty("ContractNo", true);
                if (_contract_no != value)
                {
                    _contract_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Amount
        {
            get
            {
                CanReadProperty("Amount", true);
                return _amount;
            }
            set
            {
                CanWriteProperty("Amount", true);
                if (_amount != value)
                {
                    _amount = value;
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

        public virtual string Reference
        {
            get
            {
                CanReadProperty("Reference", true);
                return _reference;
            }
            set
            {
                CanWriteProperty("Reference", true);
                if (_reference != value)
                {
                    _reference = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return  string.Format( "{0}", _contract_no);
        }

        #endregion

        #region Factory Methods
        public static PTDImport NewPTDImport()
        {
            return Create();
        }

        public static PTDImport[] GetAllPTDImport()
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

                    List<PTDImport> _list = new List<PTDImport>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PTDImport instance = new PTDImport();
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
        private void InsertEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateInsertCommandText(cm, "", pList))
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                StoreInitialValues();
                MarkClean();
            }
        }

        #endregion

        [ServerMethod()]
        private void CreateEntity()
        {
        }
    }
}
