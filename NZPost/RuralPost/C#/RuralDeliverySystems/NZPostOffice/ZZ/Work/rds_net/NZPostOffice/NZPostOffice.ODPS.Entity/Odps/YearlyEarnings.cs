using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.Odps
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("region", "_region", "")]
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("name", "_c_surname_company", "")]
	[MapInfo("c_ird_no", "_c_ird_no", "")]
	[MapInfo("grossearnings", "_grossearnings", "")]
	[MapInfo("withholdingtax", "_withholdingtax", "")]
	[MapInfo("gst", "_gst", "")]
	[System.Serializable()]

	public class YearlyEarnings : Entity<YearlyEarnings>
	{
		#region Business Methods
		[DBField()]
		private string  _region;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _c_surname_company;

		[DBField()]
		private string  _c_ird_no;

		[DBField()]
		private decimal?  _grossearnings;

		[DBField()]
		private decimal?  _withholdingtax;

		[DBField()]
		private decimal?  _gst;


		public virtual string Region
		{
			get
			{
				CanReadProperty("Region",true);
				return _region;
			}
			set
			{
				CanWriteProperty("Region",true);
				if ( _region != value )
				{
					_region = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ContractNo
		{
			get
			{
				CanReadProperty("ContractNo",true);
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

		public virtual string CSurnameCompany
		{
			get
			{
				CanReadProperty("CSurnameCompany",true);
				return _c_surname_company;
			}
			set
			{
				CanWriteProperty("CSurnameCompany",true);
				if ( _c_surname_company != value )
				{
					_c_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CIrdNo
		{
			get
			{
				CanReadProperty("CIrdNo",true);
				return _c_ird_no;
			}
			set
			{
				CanWriteProperty("CIrdNo",true);
				if ( _c_ird_no != value )
				{
					_c_ird_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Grossearnings
		{
			get
			{
                CanReadProperty("Grossearnings", true);
				return _grossearnings;
			}
			set
			{
				CanWriteProperty("Grossearnings",true);
				if ( _grossearnings != value )
				{
					_grossearnings = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Withholdingtax
		{
			get
			{
				CanReadProperty("Withholdingtax",true);
				return _withholdingtax;
			}
			set
			{
				CanWriteProperty("Withholdingtax",true);
				if ( _withholdingtax != value )
				{
					_withholdingtax = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Gst
		{
			get
			{
                CanReadProperty("Gst", true);
				return _gst;
			}
			set
			{
				CanWriteProperty("Gst",true);
				if ( _gst != value )
				{
					_gst = value;
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
		public static YearlyEarnings NewYearlyEarnings( DateTime? sdate, DateTime? edate, int? inregion )
		{
			return Create(sdate, edate, inregion);
		}

		public static YearlyEarnings[] GetAllYearlyEarnings( DateTime? sdate, DateTime? edate, int? inregion )
		{
			return Fetch(sdate, edate, inregion).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( DateTime? sdate, DateTime? edate, int? inregion )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					//cm.CommandType = CommandType.Text;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_yearlyearnings";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "sdate", sdate);
					pList.Add(cm, "edate", edate);
					pList.Add(cm, "inregion", inregion);

					List<YearlyEarnings> _list = new List<YearlyEarnings>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							YearlyEarnings instance = new YearlyEarnings();
                            instance._region = GetValueFromReader<string>(dr, 0);
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 1);
                            instance._c_surname_company = GetValueFromReader<string>(dr, 2);
                            instance._c_ird_no = GetValueFromReader<string>(dr, 3);
                            instance._grossearnings = GetValueFromReader<decimal?>(dr, 4);
                            instance._withholdingtax = GetValueFromReader<decimal?>(dr, 5);
                            instance._gst = GetValueFromReader<decimal?>(dr, 6);

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
