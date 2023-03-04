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
    [MapInfo("grossearnings", "_grossearnings", "")]
    [MapInfo("payedeductions", "_payedeductions", "")]
    [System.Serializable()]

    public class Ir66n : Entity<Ir66n>
    {
        #region Business Methods
        [DBField()]
        private decimal? _grossearnings;

        [DBField()]
        private decimal? _payedeductions;

        public virtual decimal? Grossearnings
        {
            get
            {
                CanReadProperty("Grossearnings", true);
                return _grossearnings;
            }
            set
            {
                CanWriteProperty("Grossearnings", true);
                if (_grossearnings != value)
                {
                    _grossearnings = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REGrossearnings
        {
            get
            {
                return (decimal)_grossearnings;
            }
        }

        public virtual decimal? Payedeductions
        {
            get
            {
                CanReadProperty("Payedeductions", true);
                return _payedeductions;
            }
            set
            {
                CanWriteProperty("Payedeductions", true);
                if (_payedeductions != value)
                {
                    _payedeductions = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REPayedeductions
        {
            get
            {
                return (decimal)_payedeductions;
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }

        #endregion

        #region Factory Methods
        public static Ir66n NewIr66n(DateTime? sdate, DateTime? edate)
        {
            return Create(sdate, edate);
        }

        public static Ir66n[] GetAllIr66n(DateTime? sdate, DateTime? edate)
        {
            return Fetch(sdate, edate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? sdate, DateTime? edate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_ir66n";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "sdate", sdate);
                    pList.Add(cm, "edate", edate);

                    List<Ir66n> _list = new List<Ir66n>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Ir66n instance = new Ir66n();
                            instance._grossearnings = GetValueFromReader<decimal?>(dr, 0);
                            instance._payedeductions = GetValueFromReader<decimal?>(dr, 1);
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
