using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;
using NZPostOffice.Shared.LogicUnits;

using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract", "_contract", "")]
    [MapInfo("prd_date", "_prd_date", "piece_rate_delivery")]
	[MapInfo("prcode", "_prt_code", "")]
    [MapInfo("prd_quantity", "_prd_quantity", "piece_rate_delivery")]
    [MapInfo("prd_cost", "_prd_cost", "piece_rate_delivery")]
	[MapInfo("prd_rd_cost", "_prd_rd_cost", "")]
    [MapInfo("prt_key", "_prt_key", "piece_rate_delivery")]
    [MapInfo("contract_no", "_contract_no", "piece_rate_delivery")]
	[MapInfo("errormsg", "_errormsg", "")]
    [MapInfoIndex(new string[] { "contract", "prd_date", "prt_code", "prd_quantity", "prd_cost" ,
       "prd_rd_cost", "prt_key", "contract_no", "errormsg" })]
    [System.Serializable()]

	public class PieceRateImport : Entity<PieceRateImport>
	{
		#region Business Methods
		[DBField()]
		private string  _contract;

		[DBField()]
		private DateTime?  _prd_date;

		[DBField()]
		private string  _prt_code;

		[DBField()]
		private int?  _prd_quantity;

		[DBField()]
		private decimal?  _prd_cost;

		[DBField()]
		private decimal?  _prd_rd_cost;

		[DBField()]
		private int?  _prt_key;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _errormsg;


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
				if ( _contract != value )
				{
					_contract = value;
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
				if ( _prd_date != value )
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
				if ( _prt_code != value )
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
				if ( _prd_quantity != value )
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
				if ( _prd_cost != value )
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
				if ( _prd_rd_cost != value )
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
				if ( _prt_key != value )
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
				if ( _contract_no != value )
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
				if ( _errormsg != value )
				{
					_errormsg = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[nextdup]
            //if((contract_no = contract_no[1] and  prt_code =  prt_code [1] and  prd_date =  prd_date[1]),'Y','N')
        private string _nextdup;
        public virtual string Nextdup
        {
            get
            {
                CanReadProperty("Nextdup", true);
                return _nextdup;
            }
            set
            {
                if (_nextdup != value)
                {
                    _nextdup = value;
                }
            }
        }

			// needs to implement compute expression manually:
			// compute control name=[totalcost]
            //prd_quantity  *  prd_rd_cost
        public virtual decimal? Totalcost
        {
            get
            {
                CanReadProperty("Totalcost", true);
                return _prd_quantity * _prd_rd_cost;
            }
        }


		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}/{2}", _prd_date,_prt_key,_contract_no );
		}
		#endregion

		#region Factory Methods
		public static PieceRateImport NewPieceRateImport(  )
		{
			return Create();
		}

		public static PieceRateImport[] GetAllPieceRateImport(  )
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

        //            List<PieceRateImport> _list = new List<PieceRateImport>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    PieceRateImport instance = new PieceRateImport();
        //                    instance.MarkOld();
        //                    _list.Add(instance);
        //                }
        //                list = _list.ToArray();
        //            }
        //        }
        //    }
        //}
        [ServerMethod()]
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "piece_rate_delivery", ref pList))
                {
                    cm.CommandText += " WHERE  piece_rate_delivery.prd_date = @prd_date and " +
                        " piece_rate_delivery.prt_key = @prt_key and " +
                        " piece_rate_delivery.contract_no = @contract_no";

                    pList.Add(cm, "prd_date", GetInitialValue("_prd_date"));
                    pList.Add(cm, "prt_key", GetInitialValue("_prt_key"));
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                // reinitialize original key/value list
                StoreInitialValues();
                MarkClean();
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
                if (GenerateInsertCommandText(cm, "piece_rate_delivery", pList))
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                StoreInitialValues();
                MarkClean();
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
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    cm.CommandText = "DELETE FROM piece_rate_delivery  WHERE  piece_rate_delivery.prd_date = @prd_date and " +
                        " piece_rate_delivery.prt_key = @prt_key and " +
                        " piece_rate_delivery.contract_no = @contract_no";
                    pList.Add(cm, "prd_date", GetInitialValue("_prd_date"));
                    pList.Add(cm, "prt_key", GetInitialValue("_prt_key"));
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }

		#endregion

		[ServerMethod()]
		private void CreateEntity( DateTime? prd_date, int? prt_key, int? contract_no )
		{
			_prd_date = prd_date;
			_prt_key = prt_key;
			_contract_no = contract_no;
		}
	}
}
