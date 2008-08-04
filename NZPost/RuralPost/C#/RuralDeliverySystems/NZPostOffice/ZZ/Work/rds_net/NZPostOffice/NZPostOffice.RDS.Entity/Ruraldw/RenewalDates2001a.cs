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
	[MapInfo("rg_code", "_rg_code", "")]
	[MapInfo("rr_rates_effective_date", "_rr_rates_effective_date", "")]
	[MapInfo("rr_frozen_indicator", "_rr_frozen_indicator", "")]
	[MapInfo("rates_complete", "_rates_complete", "")]
	[System.Serializable()]

	public class RenewalDates2001a : Entity<RenewalDates2001a>
	{
		#region Business Methods
		[DBField()]
		private int?  _rg_code;

		[DBField()]
		private DateTime?  _rr_rates_effective_date;

		[DBField()]
		private string  _rr_frozen_indicator;

		[DBField()]
		private int?  _rates_complete;


		public virtual int? RgCode
		{
			get
			{
                CanReadProperty("RgCode", true);
				return _rg_code;
			}
			set
			{
                CanWriteProperty("RgCode", true);
				if ( _rg_code != value )
				{
					_rg_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RrRatesEffectiveDate
		{
			get
			{
                CanReadProperty("RrRatesEffectiveDate", true);
				return _rr_rates_effective_date;
			}
			set
			{
                CanWriteProperty("RrRatesEffectiveDate", true);
				if ( _rr_rates_effective_date != value )
				{
					_rr_rates_effective_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RrFrozenIndicator
		{
			get
			{
                CanReadProperty("RrFrozenIndicator", true);
				return _rr_frozen_indicator;
			}
			set
			{
                CanWriteProperty("RrFrozenIndicator", true);
				if ( _rr_frozen_indicator != value )
				{
					_rr_frozen_indicator = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RatesComplete
		{
			get
			{
                CanReadProperty("RatesComplete", true);
				return _rates_complete;
			}
			set
			{
                CanWriteProperty("RatesComplete", true);
				if ( _rates_complete != value )
				{
					_rates_complete = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[status]
			//?if(rr_frozen_indicator='Y','Frozen',   if ( rates_complete =0, 'Editable (Incomplete)','Editable'   ))
        public virtual string Status
        {
            get
            {
                CanReadProperty("Status", true);
                return (_rr_frozen_indicator == "Y" ? "Frozen" : (_rates_complete == 0 ? "Editable (Incomplete)" : "Editable"));
            }
        }

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static RenewalDates2001a NewRenewalDates2001a( int? inregion )
		{
			return Create(inregion);
		}

		public static RenewalDates2001a[] GetAllRenewalDates2001a( int? inregion )
		{
			return Fetch(inregion).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inregion )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inregion", inregion);
                    cm.CommandText = "rd.sp_getrenewalrateswithregion2001a";

					List<RenewalDates2001a> _list = new List<RenewalDates2001a>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
                        while (dr.Read())
                        {
                            RenewalDates2001a instance = new RenewalDates2001a();
                            instance._rg_code = GetValueFromReader<Int32?>(dr, 0);
                            instance._rr_rates_effective_date = GetValueFromReader<DateTime?>(dr, 1);
                            instance._rr_frozen_indicator = GetValueFromReader<String>(dr, 2);
                            instance._rates_complete = GetValueFromReader<Int32?>(dr, 3);

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
