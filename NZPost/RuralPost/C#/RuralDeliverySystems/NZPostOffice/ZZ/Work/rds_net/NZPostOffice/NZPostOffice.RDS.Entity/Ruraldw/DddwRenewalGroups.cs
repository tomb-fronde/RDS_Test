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
	[MapInfo("rg_description", "_rg_description", "")]
	[System.Serializable()]

	public class DddwRenewalGroups : Entity<DddwRenewalGroups>
	{
		#region Business Methods
		[DBField()]
		private int?  _rg_code;

		[DBField()]
		private string  _rg_description;


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

		public virtual string RgDescription
		{
			get
			{
                CanReadProperty("RgDescription", true);
				return _rg_description;
			}
			set
			{
                CanWriteProperty("RgDescription", true);
				if ( _rg_description != value )
				{
					_rg_description = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
            return _rg_code.GetValueOrDefault() + " ";// "";
		}
		#endregion

		#region Factory Methods
		public static DddwRenewalGroups NewDddwRenewalGroups(  )
		{
			return Create();
		}

		public static DddwRenewalGroups[] GetAllDddwRenewalGroups(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
					ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "sp_DDDW_RenewalGroups";

					List<DddwRenewalGroups> _list = new List<DddwRenewalGroups>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwRenewalGroups instance = new DddwRenewalGroups();
                            instance._rg_code = GetValueFromReader<Int32?>(dr,0);
                            instance._rg_description = GetValueFromReader<String>(dr,1);
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
