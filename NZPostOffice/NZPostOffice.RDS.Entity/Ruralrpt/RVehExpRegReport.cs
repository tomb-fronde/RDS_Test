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
	[MapInfo("expiry", "_expiry", "")]
	[MapInfo("con_num", "_con_num", "")]
	[MapInfo("rego", "_rego", "")]
	[MapInfo("vmake", "_vmake", "")]
	[MapInfo("vmodel", "_vmodel", "")]
	[MapInfo("vyear", "_vyear", "")]
	[MapInfo("vdesc", "_vdesc", "")]
	[MapInfo("vfuel", "_vfuel", "")]
	[MapInfo("reg_name", "_reg_name", "")]
	[MapInfo("month_6", "_month_6", "")]
	[System.Serializable()]

	public class VehExpRegReport : Entity<VehExpRegReport>
	{
		#region Business Methods
		[DBField()]
		private DateTime?  _expiry;

		[DBField()]
		private int?  _con_num;

		[DBField()]
		private string  _rego;

		[DBField()]
		private string  _vmake;

		[DBField()]
		private string  _vmodel;

		[DBField()]
		private int?  _vyear;

		[DBField()]
		private string  _vdesc;

		[DBField()]
		private string  _vfuel;

		[DBField()]
		private string  _reg_name;

		[DBField()]
		private DateTime?  _month_6;


		public virtual DateTime? Expiry
		{
			get
			{
                CanReadProperty("Expiry", true);
				return _expiry;
			}
			set
			{
                CanWriteProperty("Expiry", true);
				if ( _expiry != value )
				{
					_expiry = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ConNum
		{
			get
			{
                CanReadProperty("ConNum", true);
				return _con_num;
			}
			set
			{
                CanWriteProperty("ConNum", true);
				if ( _con_num != value )
				{
					_con_num = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Rego
		{
			get
			{
                CanReadProperty("Rego", true);
				return _rego;
			}
			set
			{
                CanWriteProperty("Rego", true);
				if ( _rego != value )
				{
					_rego = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Vmake
		{
			get
			{
                CanReadProperty("Vmake", true);
				return _vmake;
			}
			set
			{
                CanWriteProperty("Vmake", true);
				if ( _vmake != value )
				{
					_vmake = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Vmodel
		{
			get
			{
                CanReadProperty("Vmodel", true);
				return _vmodel;
			}
			set
			{
                CanWriteProperty("Vmodel", true);
				if ( _vmodel != value )
				{
					_vmodel = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Vyear
		{
			get
			{
                CanReadProperty("Vyear", true);
				return _vyear;
			}
			set
			{
                CanWriteProperty("Vyear", true);
				if ( _vyear != value )
				{
					_vyear = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Vdesc
		{
			get
			{
                CanReadProperty("Vdesc", true);
				return _vdesc;
			}
			set
			{
                CanWriteProperty("Vdesc", true);
				if ( _vdesc != value )
				{
					_vdesc = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Vfuel
		{
			get
			{
                CanReadProperty("Vfuel", true);
				return _vfuel;
			}
			set
			{
                CanWriteProperty("Vfuel", true);
				if ( _vfuel != value )
				{
					_vfuel = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RegName
		{
			get
			{
                CanReadProperty("RegName", true);
				return _reg_name;
			}
			set
			{
                CanWriteProperty("RegName", true);
				if ( _reg_name != value )
				{
					_reg_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? Month6
		{
			get
			{
                CanReadProperty("Month6", true);
				return _month_6;
			}
			set
			{
                CanWriteProperty("Month6", true);
				if ( _month_6 != value )
				{
					_month_6 = value;
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
		public static VehExpRegReport NewVehExpRegReport( int? reg_id )
		{
			return Create(reg_id);
		}

		public static VehExpRegReport[] GetAllVehExpRegReport( int? reg_id )
		{
			return Fetch(reg_id).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? reg_id )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_v_exp_region";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "reg_id", reg_id);

					List<VehExpRegReport> _list = new List<VehExpRegReport>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							VehExpRegReport instance = new VehExpRegReport();
                            instance._expiry = GetValueFromReader<DateTime?>(dr,0);
                            instance._con_num = GetValueFromReader<int?>(dr,1);
                            instance._rego = GetValueFromReader<string>(dr,2);
                            instance._vmake = GetValueFromReader<string>(dr,3);
                            instance._vmodel = GetValueFromReader<string>(dr,4);
                            instance._vyear = GetValueFromReader<int?>(dr,5);
                            instance._vdesc = GetValueFromReader<string>(dr,6);
                            instance._vfuel = GetValueFromReader<string>(dr,7);
                            instance._reg_name = GetValueFromReader<string>(dr,8);
                            instance._month_6 = GetValueFromReader<DateTime?>(dr,9);
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
