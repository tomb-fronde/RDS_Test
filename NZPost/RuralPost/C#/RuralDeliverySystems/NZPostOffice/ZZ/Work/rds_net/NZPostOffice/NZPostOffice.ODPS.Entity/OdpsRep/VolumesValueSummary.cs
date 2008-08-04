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
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("region", "_region", "")]
	[MapInfo("name", "_c_surname_company", "")]
	[MapInfo("adpostvolume", "_adpostvolume", "")]
	[MapInfo("adpostvalue", "_adpostvalue", "")]
	[MapInfo("courierpostvolume", "_courierpostvolume", "")]
	[MapInfo("courierpostvalue", "_courierpostvalue", "")]
	[MapInfo("xpvolume", "_xpvolume", "")]
	[MapInfo("xpvalue", "_xpvalue", "")]
	[MapInfo("conttype", "_conttype", "")]
	[MapInfo("parcelpostvolume", "_parcelpostvolume", "")]
	[MapInfo("parcelpostvalue", "_parcelpostvalue", "")]
	[System.Serializable()]

	public class VolumesValueSummary : Entity<VolumesValueSummary>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _region;

		[DBField()]
		private string  _c_surname_company;

		[DBField()]
		private decimal?  _adpostvolume;

		[DBField()]
		private decimal?  _adpostvalue;

		[DBField()]
		private decimal?  _courierpostvolume;

		[DBField()]
		private decimal?  _courierpostvalue;

		[DBField()]
		private decimal?  _xpvolume;

		[DBField()]
		private decimal?  _xpvalue;

		[DBField()]
		private string  _conttype;

		[DBField()]
		private decimal?  _parcelpostvolume;

		[DBField()]
		private decimal?  _parcelpostvalue;

		public virtual int? ContractNo
		{
			get
			{
				CanReadProperty("ContractNo",true);
				return _contract_no;
			}
			set
			{
				CanWriteProperty("ContractNo",true);
				if ( _contract_no != value )
				{
					_contract_no = value;
					PropertyHasChanged();
				}
			}
		}

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

		public virtual decimal? Adpostvolume
		{
			get
			{
				CanReadProperty("Adpostvolume",true);
				return _adpostvolume;
			}
			set
			{
				CanWriteProperty("Adpostvolume",true);
				if ( _adpostvolume != value )
				{
					_adpostvolume = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Adpostvalue
		{
			get
			{
				CanReadProperty("Adpostvalue",true);
				return _adpostvalue;
			}
			set
			{
				CanWriteProperty("Adpostvalue",true);
				if ( _adpostvalue != value )
				{
					_adpostvalue = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Courierpostvolume
		{
			get
			{
				CanReadProperty("Courierpostvolume",true);
				return _courierpostvolume;
			}
			set
			{
				CanWriteProperty("Courierpostvolume",true);
				if ( _courierpostvolume != value )
				{
					_courierpostvolume = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Courierpostvalue
		{
			get
			{
				CanReadProperty("Courierpostvalue",true);
				return _courierpostvalue;
			}
			set
			{
				CanWriteProperty("Courierpostvalue",true);
				if ( _courierpostvalue != value )
				{
					_courierpostvalue = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Xpvolume
		{
			get
			{
				CanReadProperty("Xpvolume",true);
				return _xpvolume;
			}
			set
			{
				CanWriteProperty("Xpvolume",true);
				if ( _xpvolume != value )
				{
					_xpvolume = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Xpvalue
		{
			get
			{
				CanReadProperty("Xpvalue",true);
				return _xpvalue;
			}
			set
			{
				CanWriteProperty("Xpvalue",true);
				if ( _xpvalue != value )
				{
					_xpvalue = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Conttype
		{
			get
			{
				CanReadProperty("Conttype",true);
				return _conttype;
			}
			set
			{
				CanWriteProperty("Conttype",true);
				if ( _conttype != value )
				{
					_conttype = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Parcelpostvolume
		{
			get
			{
				CanReadProperty("Parcelpostvolume",true);
				return _parcelpostvolume;
			}
			set
			{
				CanWriteProperty("Parcelpostvolume",true);
				if ( _parcelpostvolume != value )
				{
					_parcelpostvolume = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Parcelpostvalue
		{
			get
			{
				CanReadProperty("Parcelpostvalue",true);
				return _parcelpostvalue;
			}
			set
			{
				CanWriteProperty("Parcelpostvalue",true);
				if ( _parcelpostvalue != value )
				{
					_parcelpostvalue = value;
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
		public static VolumesValueSummary NewVolumesValueSummary( DateTime? sdate, DateTime? edate, int? inregion )
		{
			return Create(sdate, edate, inregion);
		}

		public static VolumesValueSummary[] GetAllVolumesValueSummary( DateTime? sdate, DateTime? edate, int? inregion )
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
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.OD_RPS_VolumesValues_Summary";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "sdate", sdate);
					pList.Add(cm, "edate", edate);
					pList.Add(cm, "inregion", inregion);

					List<VolumesValueSummary> _list = new List<VolumesValueSummary>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							VolumesValueSummary instance = new VolumesValueSummary();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._region = GetValueFromReader<string>(dr, 1);
                            instance._c_surname_company = GetValueFromReader<string>(dr, 2);
                            instance._adpostvolume = GetValueFromReader<decimal?>(dr, 3);
                            instance._adpostvalue = GetValueFromReader<decimal?>(dr, 4);
                            instance._courierpostvolume = GetValueFromReader<decimal?>(dr, 5);
                            instance._courierpostvalue = GetValueFromReader<decimal?>(dr, 6);
                            instance._xpvolume = GetValueFromReader<decimal?>(dr, 7);
                            instance._xpvalue = GetValueFromReader<decimal?>(dr, 8);
                            instance._conttype = GetValueFromReader<string>(dr, 9);
                            instance._parcelpostvolume = GetValueFromReader<decimal?>(dr, 10);
                            instance._parcelpostvalue = GetValueFromReader<decimal?>(dr, 11);
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
