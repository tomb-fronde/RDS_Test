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
    [MapInfo("piece_rate_description", "_piece_rate_description", "")]
    [MapInfo("prd_cost", "_pr_rate", "")]
    [MapInfo("prd_quantity", "_prd_quantity", "")]
    [System.Serializable()]

    public class PieceRateBreakdown : Entity<PieceRateBreakdown>
    {
        #region Business Methods
        [DBField()]
        private string _piece_rate_description;

        [DBField()]
        private decimal? _pr_rate;

        [DBField()]
        private int? _prd_quantity;


        public virtual string PieceRateDescription
        {
            get
            {
                CanReadProperty("PieceRateDescription", true);
                return _piece_rate_description;
            }
            set
            {
                CanWriteProperty("PieceRateDescription", true);
                if (_piece_rate_description != value)
                {
                    _piece_rate_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? PrRate
        {
            get
            {
                CanReadProperty("PrRate", true);
                return _pr_rate;
            }
            set
            {
                CanWriteProperty("PrRate", true);
                if (_pr_rate != value)
                {
                    _pr_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PrdQuantity
        {
            get
            {
                CanReadProperty("PrdQuantity", true);
                return _prd_quantity;
            }
            set
            {
                CanWriteProperty("PrdQuantity", true);
                if (_prd_quantity != value)
                {
                    _prd_quantity = value;
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
        public static PieceRateBreakdown NewPieceRateBreakdown(int? in_Contract, int? in_Supplier, DateTime? in_Date)
        {
            return Create(in_Contract, in_Supplier, in_Date);
        }

        public static PieceRateBreakdown[] GetAllPieceRateBreakdown(int? in_Contract, int? in_Supplier, DateTime? in_Date)
        {
            return Fetch(in_Contract, in_Supplier, in_Date).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_Contract, int? in_Supplier, DateTime? in_Date)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Contract", in_Contract);
                    pList.Add(cm, "in_Supplier", in_Supplier);
                    pList.Add(cm, "in_Date", in_Date);
                    cm.CommandText = "sp_GetPieceRateBreakDown";

                    List<PieceRateBreakdown> _list = new List<PieceRateBreakdown>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PieceRateBreakdown instance = new PieceRateBreakdown();
                            instance._piece_rate_description = GetValueFromReader<String>(dr,0);
                            instance._pr_rate = GetValueFromReader<Decimal?>(dr,1);
                            instance._prd_quantity = GetValueFromReader<Int32?>(dr,2);

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
