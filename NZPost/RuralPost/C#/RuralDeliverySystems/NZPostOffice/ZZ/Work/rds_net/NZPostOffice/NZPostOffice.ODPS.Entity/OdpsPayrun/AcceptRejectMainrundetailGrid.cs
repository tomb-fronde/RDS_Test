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
    [MapInfo("pc_amount", "_pc_amount", "")]
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("ac_code", "_ac_code", "")]
    [MapInfo("comments", "_comments", "")]
    [MapInfo("name", "_name", "")]

    [System.Serializable()]

    public class AcceptRejectMainrundetailGrid : Entity<AcceptRejectMainrundetailGrid>
    {

        #region Business Methods
        [DBField()]
        private decimal? _pc_amount;

        [DBField()]
        private int? _contract_no;

        [DBField()]
        private string _ac_code;

        [DBField()]
        private string _comments;

        [DBField()]
        private string _name;

        public virtual decimal? PcAmount
        {
            get
            {
                CanReadProperty("PcAmount", true);
                return _pc_amount;
            }
            set
            {
                CanWriteProperty("PcAmount", true);
                if (_pc_amount != value)
                {
                    _pc_amount = value;
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

        public virtual string AcCode
        {
            get
            {
                CanReadProperty("AcCode", true);
                return _ac_code;
            }
            set
            {
                CanWriteProperty("AcCode", true);
                if (_ac_code != value)
                {
                    _ac_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Comments
        {
            get
            {
                CanReadProperty("Comments", true);
                return _comments;
            }
            set
            {
                CanWriteProperty("Comments", true);
                if (_comments != value)
                {
                    _comments = value;
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

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static AcceptRejectMainrundetailGrid NewAcceptRejectMainrundetailGrid()
        {
            return Create();
        }

        public static AcceptRejectMainrundetailGrid[] GetAllAcceptRejectMainrundetailGrid()
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
                    cm.CommandText = "odps.od_dws_netpaydet_before_acceptance";
                    cm.CommandTimeout = 700;                    
                    ParameterCollection pList = new ParameterCollection();

                    List<AcceptRejectMainrundetailGrid> _list = new List<AcceptRejectMainrundetailGrid>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            AcceptRejectMainrundetailGrid instance = new AcceptRejectMainrundetailGrid();
                            instance._pc_amount = GetValueFromReader<decimal?>(dr, 0);
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 1);
                            instance._ac_code = GetValueFromReader<string>(dr, 2);
                            instance._comments = GetValueFromReader<string>(dr, 3);
                            instance._name = GetValueFromReader<string>(dr, 4);
                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
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
