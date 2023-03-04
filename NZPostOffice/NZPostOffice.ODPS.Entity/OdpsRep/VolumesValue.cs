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
	[MapInfo("conttype", "_conttype", "")]
	[System.Serializable()]

	public class VolumesValue : Entity<VolumesValue>
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
		private string  _conttype;

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

        public int REContractNo
        {
            get
            {
                return (int)_contract_no;
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

        public decimal REAdpostvolume
        {
            get
            {
                return (decimal)_adpostvolume;
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

        public decimal REAdpostvalue
        {
            get
            {
                return (decimal)_adpostvalue;
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

        public decimal RECourierpostvolume
        {
            get
            {
                return (decimal)_courierpostvolume;
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

        public decimal RECourierpostvalue
        {
            get
            {
                return (decimal)_courierpostvalue;
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

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static VolumesValue NewVolumesValue( DateTime? sdate, DateTime? edate, int? inregion )
		{
			return Create(sdate, edate, inregion);
		}

		public static VolumesValue[] GetAllVolumesValue( DateTime? sdate, DateTime? edate, int? inregion )
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
                    cm.CommandText = "odps.od_rps_volumesvalues";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "sdate", sdate);
					pList.Add(cm, "edate", edate);
					pList.Add(cm, "inregion", inregion);

					List<VolumesValue> _list = new List<VolumesValue>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							VolumesValue instance = new VolumesValue();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._region = GetValueFromReader<string>(dr, 1);
                            instance._c_surname_company = GetValueFromReader<string>(dr, 2);
                            instance._adpostvolume = GetValueFromReader<decimal?>(dr, 3);
                            instance._adpostvalue = GetValueFromReader<decimal?>(dr, 4);
                            instance._courierpostvolume = GetValueFromReader<decimal?>(dr, 5);
                            instance._courierpostvalue = GetValueFromReader<decimal?>(dr, 6);
                            instance._conttype = GetValueFromReader<string>(dr, 7);
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
