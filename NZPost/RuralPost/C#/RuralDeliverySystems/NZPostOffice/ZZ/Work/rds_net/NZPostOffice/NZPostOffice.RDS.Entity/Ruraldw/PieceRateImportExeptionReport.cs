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
    [MapInfo("contract", "_contract", "")]
    [MapInfo("prd_date", "_prd_date", "")]
    [MapInfo("prcode", "_prt_code", "")]
    [MapInfo("prd_quantity", "_prd_quantity", "")]
    [MapInfo("prd_cost", "_prd_cost", "")]
    [MapInfo("prd_rd_cost", "_prd_rd_cost", "")]
    [MapInfo("prt_key", "_prt_key", "")]
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("errormsg", "_errormsg", "")]
    [System.Serializable()]

    public class PieceRateImportExeptionReport : Entity<PieceRateImportExeptionReport>
    {
        #region Business Methods
        [DBField()]
        private string _contract;

        [DBField()]
        private DateTime? _prd_date;

        [DBField()]
        private string _prt_code;

        [DBField()]
        private int? _prd_quantity;

        [DBField()]
        private decimal? _prd_cost;

        [DBField()]
        private decimal? _prd_rd_cost;

        [DBField()]
        private int? _prt_key;

        [DBField()]
        private string _prt_description;

        [DBField()]
        private int? _contract_no;

        [DBField()]
        private string _errormsg;

        public virtual string Contract
        {
            get
            {
                CanReadProperty("Contract", true);
                return _contract;
            }
            set
            {
                CanWriteProperty("Contract", true);
                if (_contract != value)
                {
                    _contract = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PrtDescription
        {
            get
            {
                CanReadProperty("PrtDescription", true);
                return _prt_description;
            }
            set
            {
                CanWriteProperty("PrtDescription", true);
                if (_prt_description != value)
                {
                    _prt_description = value;
                    PropertyHasChanged();
                }
            }
        }

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

        public virtual string PrtCode
        {
            get
            {
                CanReadProperty("PrtCode", true);
                return _prt_code;
            }
            set
            {
                CanWriteProperty("PrtCode", true);
                if (_prt_code != value)
                {
                    _prt_code = value;
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

        public virtual decimal? PrdCost
        {
            get
            {
                CanReadProperty("PrdCost", true);
                return _prd_cost;
            }
            set
            {
                CanWriteProperty("PrdCost", true);
                if (_prd_cost != value)
                {
                    _prd_cost = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? PrdRdCost
        {
            get
            {
                CanReadProperty("PrdRdCost", true);
                return _prd_rd_cost;
            }
            set
            {
                CanWriteProperty("PrdRdCost", true);
                if (_prd_rd_cost != value)
                {
                    _prd_rd_cost = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PrtKey
        {
            get
            {
                CanReadProperty("PrtKey", true);
                return _prt_key;
            }
            set
            {
                CanWriteProperty("PrtKey", true);
                if (_prt_key != value)
                {
                    _prt_key = value;
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

        public virtual string Errormsg
        {
            get
            {
                CanReadProperty("Errormsg", true);
                return _errormsg;
            }
            set
            {
                CanWriteProperty("Errormsg", true);
                if (_errormsg != value)
                {
                    _errormsg = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}/{2}", _prd_date, _prt_key, _contract_no);
        }
        #endregion

        #region Factory Methods
        public static PieceRateImportExeptionReport NewPieceRateImportExeptionReport()
        {
            return Create();
        }

        public static PieceRateImportExeptionReport[] GetAllPieceRateImportExeptionReport()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access
        //Exterior Data
        //[ServerMethod]
        //private void FetchEntity(  )
        //{
        //    using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
        //    {
        //        using (DbCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.Text;
        //            ParameterCollection pList = new ParameterCollection();

        //            List<PieceRateImportExeptionReport> _list = new List<PieceRateImportExeptionReport>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    PieceRateImportExeptionReport instance = new PieceRateImportExeptionReport();
        //                    instance.MarkOld();
        //                    _list.Add(instance);
        //                }
        //                list = _list.ToArray();
        //            }
        //        }
        //    }
        //}

        #endregion

        [ServerMethod()]
        private void CreateEntity(DateTime? prd_date, int? prt_key, int? contract_no)
        {
            _prd_date = prd_date;
            _prt_key = prt_key;
            _contract_no = contract_no;
        }
    }
}
