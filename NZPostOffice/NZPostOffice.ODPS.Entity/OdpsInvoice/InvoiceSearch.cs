//qtdong
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsInvoice
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("region_id", "_region_id", "region")]
    [MapInfo("end_date", "_end_date", "region")]
    [MapInfo("ct_key", "_ct_key", "region")]
    [MapInfo("owner_driver", "_owner_driver", "region")]
    [MapInfo("contract_no", "_contract_no", "region")]
    [MapInfo("start_date", "_start_date", "region")]
    [System.Serializable()]

    public class InvoiceSearch : Entity<InvoiceSearch>
    {
        #region Business Methods
        [DBField()]
        private int? _region_id;

        [DBField()]
        private DateTime? _end_date;

        [DBField()]
        private int? _ct_key;

        [DBField()]
        private string _owner_driver;

        [DBField()]
        private string _contract_no;

        [DBField()]
        private DateTime? _start_date;

        public virtual int? RegionId
        {
            get
            {
                CanReadProperty("RegionId",true);
                return _region_id;
            }
            set
            {
                CanWriteProperty("RegionId",true);
                if (_region_id != value)
                {
                    _region_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? EndDate
        {
            get
            {
                CanReadProperty("EndDate",true);
                return _end_date;
            }
            set
            {
                CanWriteProperty("EndDate",true);
                if (_end_date != value)
                {
                    _end_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CtKey
        {
            get
            {
                CanReadProperty("CtKey",true);
                return _ct_key;
            }
            set
            {
                CanWriteProperty("CtKey",true);
                if (_ct_key != value)
                {
                    _ct_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OwnerDriver
        {
            get
            {
                CanReadProperty("OwnerDriver",true);
                return _owner_driver;
            }
            set
            {
                CanWriteProperty("OwnerDriver", true);
                if (_owner_driver != value)
                {
                    _owner_driver = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContractNo
        {
            get
            {
                CanReadProperty("ContractNo",true);
                return _contract_no;
            }
            set
            {
                CanWriteProperty("ContractNo",true);
                if (_contract_no != value)
                {
                    _contract_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? StartDate
        {
            get
            {
                CanReadProperty("StartDate",true);
                return _start_date;
            }
            set
            {
                CanWriteProperty("StartDate",true);
                if (_start_date != value)
                {
                    _start_date = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}", _region_id);
        }

        #endregion

        #region Factory Methods
        public static InvoiceSearch NewInvoiceSearch()
        {
            return Create();
        }

        public static InvoiceSearch[] GetAllInvoiceSearch()
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
                    //GenerateSelectCommandText(cm, "region");
                    cm.CommandText = @"SELECT  rd.region.region_id ,
                                   CONVERT(varchar(12),getdate(),103) end_date,
                                   1 ct_key,
                                   '' owner_driver,
                                   '' contract_no,
                                   CONVERT(varchar(12),getdate(),103) start_date
                                  FROM rd.region";
                    List<InvoiceSearch> _list = new List<InvoiceSearch>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            InvoiceSearch instance = new InvoiceSearch();
                            //instance.StoreFieldValues(dr, "region");
                            instance._region_id = GetValueFromReader<Int32?>(dr, 0);
                            instance._end_date = GetValueFromReader<DateTime?>(dr, 1);
                            instance._ct_key = GetValueFromReader<Int32?>(dr, 2);
                            instance._owner_driver = GetValueFromReader<string>(dr, 3);
                            instance._contract_no = GetValueFromReader<string>(dr, 4);
                            instance._start_date = GetValueFromReader<DateTime?>(dr, 5);
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
                if (GenerateInsertCommandText(cm, "rd.region", pList))
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
                    pList.Add(cm, "region_id", GetInitialValue("_region_id"));
                    cm.CommandText = "DELETE FROM rd.region WHERE " +
                    "region.region_id = @region_id ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? region_id)
        {
            _region_id = region_id;
        }
    }
}
