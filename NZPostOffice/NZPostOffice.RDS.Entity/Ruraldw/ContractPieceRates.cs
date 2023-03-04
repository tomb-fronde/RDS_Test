using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("prd_date", "_prd_date", "")]
    [MapInfo("prs_key", "_prs_key", "")]
    [MapInfo("piece_rate_quantity", "_piece_rate_quantity", "")]
    [MapInfo("piece_rate_cost", "_piece_rate_cost", "")]
    [MapInfo("paid_to_date", "_paid_to_date", "")]
    [System.Serializable()]

    public class ContractPieceRates : Entity<ContractPieceRates>
    {
        #region Business Methods
        [DBField()]
        private DateTime? _prd_date;

        [DBField()]
        private int? _prs_key;

        [DBField()]
        private int? _piece_rate_quantity;

        [DBField()]
        private Decimal? _piece_rate_cost;

        [DBField()]
        private DateTime? _paid_to_date;

        public virtual DateTime? PrdDate
        {
            get
            {
                CanReadProperty("PrdDate", true);
                return _prd_date;
            }
            set
            {
                CanWriteProperty("PrdDate", true);
                if (_prd_date != value)
                {
                    _prd_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PrsKey
        {
            get
            {
                CanReadProperty("PrsKey", true);
                return _prs_key;
            }
            set
            {
                CanWriteProperty("PrsKey", true);
                if (_prs_key != value)
                {
                    _prs_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PieceRateQuantity
        {
            get
            {
                CanReadProperty("PieceRateQuantity", true);
                return _piece_rate_quantity;
            }
            set
            {
                CanWriteProperty("PieceRateQuantity", true);
                if (_piece_rate_quantity != value)
                {
                    _piece_rate_quantity = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? PieceRateCost
        {
            get
            {
                CanReadProperty("PieceRateCost", true);
                return _piece_rate_cost;
            }
            set
            {
                CanWriteProperty("PieceRateCost", true);
                if (_piece_rate_cost != value)
                {
                    _piece_rate_cost = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? PaidToDate
        {
            get
            {
                CanReadProperty("PaidToDate", true);
                return _paid_to_date;
            }
            set
            {
                CanWriteProperty("PaidToDate", true);
                if (_paid_to_date != value)
                {
                    _paid_to_date = value;
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
        public static ContractPieceRates NewContractPieceRates(int? in_Contract)
        {
            return Create(in_Contract);
        }

        public static ContractPieceRates[] GetAllContractPieceRates(int? in_Contract)
        {
            return Fetch(in_Contract).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_Contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Contract", in_Contract);
                    // in_RetrieveType = 'A', in_DateStart = '1900-01-01' in_DateEnd = '1900-01-01'"
                    pList.Add(cm, "in_RetrieveType", 'A');
                    pList.Add(cm, "in_DateStart", System.Convert.ToDateTime("1/1/1900"));
                    pList.Add(cm, "in_DateEnd", System.Convert.ToDateTime("1/1/1900"));
                    cm.CommandText = "sp_GetContractPieceRatesODPS";
                    List<ContractPieceRates> _list = new List<ContractPieceRates>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ContractPieceRates instance = new ContractPieceRates();
                            instance._prd_date = GetValueFromReader<DateTime?>(dr, 0);
                            instance._prs_key = GetValueFromReader<Int32?>(dr, 1);
                            instance._piece_rate_quantity = GetValueFromReader<Int32?>(dr, 2);
                            instance._piece_rate_cost = GetValueFromReader<Decimal?>(dr, 3);
                            instance._paid_to_date = GetValueFromReader<DateTime?>(dr, 4);
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
