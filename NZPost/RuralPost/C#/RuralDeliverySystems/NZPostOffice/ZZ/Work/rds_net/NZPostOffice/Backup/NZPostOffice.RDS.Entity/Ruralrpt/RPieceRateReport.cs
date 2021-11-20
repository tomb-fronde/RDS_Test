using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("prs_description", "_prs_description", "piece_rate_supplier")]
	[MapInfo("prt_description", "_prt_description", "piece_rate_type")]
	[MapInfo("prt_code", "_prt_code", "piece_rate_type")]
	[MapInfo("compute_0004", "_monthvol", "piece_rate_delivery")]
	[MapInfo("compute_0005", "_monthcost", "piece_rate_delivery")]
	[MapInfo("compute_0006", "_ytdvol", "piece_rate_delivery")]
	[MapInfo("compute_0007", "_ytdcost", "piece_rate_delivery")]
	[System.Serializable()]

	public class PieceRateReport : Entity<PieceRateReport>
	{
		#region Business Methods
		[DBField()]
		private string  _prs_description;

		[DBField()]
		private string  _prt_description;

		[DBField()]
		private string  _prt_code;

		[DBField()]
		private int?  _monthvol;

		[DBField()]
		private decimal?  _monthcost;

		[DBField()]
		private int?  _ytdvol;

		[DBField()]
		private decimal?  _ytdcost;


		public virtual string PrsDescription
		{
			get
			{
                CanReadProperty("PrsDescription", true);
				return _prs_description;
			}
			set
			{
                CanWriteProperty("PrsDescription", true);
				if ( _prs_description != value )
				{
					_prs_description = value;
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
				if ( _prt_description != value )
				{
					_prt_description = value;
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

		public virtual int? Monthvol
		{
			get
			{
                CanReadProperty("Monthvol", true);
                if (_monthvol == null)
                {
                    return 0;
                }
				return _monthvol;
			}
			set
			{
                CanWriteProperty("Monthvol", true);
				if ( _monthvol != value )
				{
					_monthvol = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Monthcost
		{
			get
			{
                CanReadProperty("Monthcost", true);
                if (_monthcost == null)
                {
                    return 0;
                }
				return _monthcost;
			}
			set
			{
                CanWriteProperty("Monthcost", true);
				if ( _monthcost != value )
				{
					_monthcost = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Ytdvol
		{
			get
			{
                CanReadProperty("Ytdvol", true);
                if (_ytdvol == null)
                {
                    return 0;
                }
				return _ytdvol;
			}
			set
			{
                CanWriteProperty("Ytdvol", true);
				if ( _ytdvol != value )
				{
					_ytdvol = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Ytdcost
		{
			get
			{
                CanReadProperty("Ytdcost", true);
                if (_ytdcost == null)
                {
                    return 0;
                }
				return _ytdcost;
			}
			set
			{
                CanWriteProperty("Ytdcost", true);
				if ( _ytdcost != value )
				{
					_ytdcost = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[compute_2]
		/*?	prt_code + ' (' +  prt_description + ')'

			// needs to implement compute expression manually:
			// compute control name=[compute_3]
			(ytdvol / sum(ytdvol for group 1)) * 100

			// needs to implement compute expression manually:
			// compute control name=[compute_4]
			ytdcost  /  ytdvol

			// needs to implement compute expression manually:
			// compute control name=[compute_5]
			monthcost  /  monthvol

			// needs to implement compute expression manually:
			// compute control name=[compute_6]
			(monthvol / sum(monthvol for group 1)) * 100*/


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static PieceRateReport NewPieceRateReport( int? lContract, int? lRegion, int? lOutlet, DateTime? dPrMonth )
		{
			return Create(lContract, lRegion, lOutlet, dPrMonth);
		}

		//public static PieceRateReport[] GetAllPieceRateReport( int? lContract, int? lRegion, int? lOutlet, DateTime? dPrMonth )
        public static PieceRateReport[] GetAllPieceRateReport(string lContract, int? lRegion, int? lOutlet, DateTime? dPrMonth)
		{
			return Fetch(lContract, lRegion, lOutlet, dPrMonth).list;
		}

		#endregion

		#region Data Access
		[ServerMethod]
		//private void FetchEntity( int? lContract, int? lRegion, int? lOutlet, DateTime? dPrMonth )
        private void FetchEntity(string lContract, int? lRegion, int? lOutlet, DateTime? dPrMonth)
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
                    //:lContract  -->lContract
                    cm.CommandText = "SELECT piece_rate_supplier.prs_description,  piece_rate_type.prt_description,  piece_rate_type.prt_code, " + 
                        " (select sum(prd.prd_quantity)  from piece_rate_delivery prd join contract on prd.contract_no = contract.contract_no join outlet " + 
                        " on contract.con_base_office = outlet.outlet_id  where (contract.contract_no in ( " + lContract + " ) or 0 in " + 
                        " ( " + lContract + " )) and  (outlet.region_id = :lRegion or :lRegion = 0) and  " + 
                        " (outlet.outlet_id = :lOutlet or :lOutlet = 0) and  prd.prt_key = piece_rate_type.prt_key and  prd.prd_date between " + 
                        " rd.GetFirstDayofMonth(:dPrMonth)  and rd.GetLastDayofMonth(:dPrMonth)  ),  (select sum(prd.prd_cost)  " + 
                        " from piece_rate_delivery prd join contract on prd.contract_no = contract.contract_no join outlet on " + 
                        " contract.con_base_office = outlet.outlet_id  where (contract.contract_no in ( " + lContract + " ) or 0 in " + 
                        " ( " + lContract + " )) and  (outlet.region_id = :lRegion or :lRegion = 0) and  " + 
                        " (outlet.outlet_id = :lOutlet or :lOutlet = 0) and  prd.prt_key = piece_rate_type.prt_key and  " + 
                        " prd.prd_date between rd.GetFirstDayofMonth(:dPrMonth)  and rd.GetLastDayofMonth(:dPrMonth)  ),  " + 
                        " (select sum(prd.prd_quantity)  from piece_rate_delivery prd join contract on prd.contract_no = contract.contract_no " + 
                        " join outlet on contract.con_base_office = outlet.outlet_id  where (contract.contract_no in ( " + lContract + " ) or " + 
                        " 0 in ( " + lContract + " )) and  (outlet.region_id = :lRegion or :lRegion = 0) and  " + 
                        " (outlet.outlet_id = :lOutlet or :lOutlet = 0) and  prd.prt_key = piece_rate_type.prt_key and  " + 
                        " prd.prd_date between rd.GetFinYear(:dPrMonth,'S')  and rd.GetLastDayofMonth(:dPrMonth)  ),  " + 
                        " (select sum(prd.prd_cost)  from piece_rate_delivery prd join contract on prd.contract_no = contract.contract_no join " + 
                        " outlet on contract.con_base_office = outlet.outlet_id  where (contract.contract_no in ( " + lContract + " ) or " + 
                        " 0 in ( " + lContract + " )) and  (outlet.region_id = :lRegion or :lRegion = 0) and  " + 
                        " (outlet.outlet_id = :lOutlet or :lOutlet = 0) and  prd.prt_key = piece_rate_type.prt_key and  prd.prd_date " + 
                        " between rd.GetFinYear(:dPrMonth,'S')  and rd.GetLastDayofMonth(:dPrMonth)  )  FROM piece_rate_supplier, piece_rate_type  " + 
                        " WHERE piece_rate_supplier.prs_key = piece_rate_type.prs_key  AND prs_true_value='Y'";
					ParameterCollection pList = new ParameterCollection();
					//pList.Add(cm, "lContract", lContract);
					pList.Add(cm, "lRegion", lRegion);
					pList.Add(cm, "lOutlet", lOutlet);
					pList.Add(cm, "dPrMonth", dPrMonth);

					List<PieceRateReport> _list = new List<PieceRateReport>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PieceRateReport instance = new PieceRateReport();
                            instance._prs_description = GetValueFromReader<string>(dr, 0);
                            instance._prt_description = GetValueFromReader<string>(dr, 1);
                            instance._prt_code = GetValueFromReader<string>(dr, 2);
                            instance._monthvol = GetValueFromReader<int?>(dr, 3);
                            instance._monthcost = GetValueFromReader<decimal?>(dr, 4);
                            instance._ytdvol = GetValueFromReader<int?>(dr, 5);
                            instance._ytdcost = GetValueFromReader<decimal?>(dr, 6);
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
		private void CreateEntity(  )
		{
		}
	}
}
