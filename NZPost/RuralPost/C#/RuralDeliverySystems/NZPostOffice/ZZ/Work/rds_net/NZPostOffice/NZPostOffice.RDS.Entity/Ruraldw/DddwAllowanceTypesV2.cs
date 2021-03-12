using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  Allowances  13-Mar-2021
    // Updated DddwAllowanceTypes to add parameter inAlctId
    // and changed stored proc to sp_DDDW_AllowanceTypeV2

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("alt_key", "_alt_key", "")]
	[MapInfo("alt_description", "_alt_description", "")]
	[System.Serializable()]

	public class DddwAllowanceTypesV2 : Entity<DddwAllowanceTypesV2>
	{
		#region Business Methods
		[DBField()]
		private int?  _alt_key;

		[DBField()]
		private string  _alt_description;


		public virtual int? AltKey
		{
			get
			{
                CanReadProperty("AltKey", true);
				return _alt_key;
			}
			set
			{
                CanWriteProperty("AltKey", true);
				if ( _alt_key != value )
				{
					_alt_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AltDescription
		{
			get
			{
                CanReadProperty("AltDescription", true);
				return _alt_description;
			}
			set
			{
                CanWriteProperty("AltDescription", true);
				if ( _alt_description != value )
				{
					_alt_description = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return _alt_key + " ";
		}
		#endregion

		#region Factory Methods
		public static DddwAllowanceTypesV2 NewDddwAllowanceTypesV2(  )
		{
			return Create();
		}

		public static DddwAllowanceTypesV2[] GetAllDddwAllowanceTypesV2(int? inAlctId)
		{
			return Fetch(inAlctId).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
        private void FetchEntity(int? inAlctId)
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_DDDW_AllowanceTypeV2";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inAlctId", inAlctId);

					List<DddwAllowanceTypesV2> _list = new List<DddwAllowanceTypesV2>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwAllowanceTypesV2 instance = new DddwAllowanceTypesV2();
                            instance._alt_key = GetValueFromReader<Int32?>(dr,0);
                            instance._alt_description = GetValueFromReader<String>(dr,1);
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
