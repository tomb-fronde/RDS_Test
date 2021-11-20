//qtdong
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
    [MapInfo("compute_0001", "_compute_0001", "")]
    [MapInfo("compute_0002", "_compute_0002", "")]
    [MapInfo("compute_0003", "_compute_0003", "")]
    [MapInfo("compute_0004", "_compute_0004", "")]
    [MapInfo("compute_0005", "_compute_0005", "")]
    [MapInfo("contract_no", "_contract_no", "")]
    [System.Serializable()]

    public class AcceptRejectMainrunGrid : Entity<AcceptRejectMainrunGrid>
    {

        #region Business Methods
        [DBField()]
        private string _compute_0001;

        [DBField()]
        private decimal? _compute_0002;

        [DBField()]
        private decimal? _compute_0003;

        [DBField()]
        private decimal? _compute_0004;

        [DBField()]
        private decimal? _compute_0005;

        [DBField()]
        private int? _contract_no;

        public virtual string Compute0001
        {
            get
            {
                CanReadProperty("Compute0001", true);
                return _compute_0001;
            }
            set
            {
                CanWriteProperty("Compute0001", true);
                if (_compute_0001 != value)
                {
                    _compute_0001 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Compute0002
        {
            get
            {
                CanReadProperty("Compute0002", true);
                return _compute_0002;
            }
            set
            {
                CanWriteProperty("Compute0002", true);
                if (_compute_0002 != value)
                {
                    _compute_0002 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Compute0003
        {
            get
            {
                CanReadProperty("Compute0003", true);
                return _compute_0003;
            }
            set
            {
                CanWriteProperty("Compute0003", true);
                if (_compute_0003 != value)
                {
                    _compute_0003 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Compute0004
        {
            get
            {
                CanReadProperty("Compute0004", true);
                return _compute_0004;
            }
            set
            {
                CanWriteProperty("Compute0004", true);
                if (_compute_0004 != value)
                {
                    _compute_0004 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Compute0005
        {
            get
            {
                CanReadProperty("Compute0005", true);
                return _compute_0005;
            }
            set
            {
                CanWriteProperty("Compute0005", true);
                if (_compute_0005 != value)
                {
                    _compute_0005 = value;
                    PropertyHasChanged();
                }
            }
        }

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

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static AcceptRejectMainrunGrid NewAcceptRejectMainrunGrid()
        {
            return Create();
        }

        public static AcceptRejectMainrunGrid[] GetAllAcceptRejectMainrunGrid()
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
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_dws_netpay_before_acceptance";
                    cm.CommandTimeout = 600;
                    ParameterCollection pList = new ParameterCollection();

                    List<AcceptRejectMainrunGrid> _list = new List<AcceptRejectMainrunGrid>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            AcceptRejectMainrunGrid instance = new AcceptRejectMainrunGrid();
                            instance._compute_0001 = GetValueFromReader<string>(dr, 0);
                            instance._compute_0002 = GetValueFromReader<decimal?>(dr, 1);
                            instance._compute_0003 = GetValueFromReader<decimal?>(dr, 2);
                            instance._compute_0004 = GetValueFromReader<decimal?>(dr, 3);
                            instance._compute_0005 = GetValueFromReader<decimal?>(dr, 4);
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 5);
                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        AcceptRejectMainrunGrid item = new AcceptRejectMainrunGrid();
                        _list.Add(item);
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
