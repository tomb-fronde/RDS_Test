using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  Allowances  14-Mar-2021
    // Get only Distance-based allowance calc Allowance_types
    // for activity type dropdown list.
    // Updated DddwAllowanceTypes to add inAlctId as parameter 
    // for sp_DDDW_AllowanceTypeV2.
    // Couldn't figure out a way to pass inAlctID as a parameter
    // and have had to hard-code its value.

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("alt_key", "_alt_key", "")]
	[MapInfo("alt_description", "_alt_description", "")]
	[System.Serializable()]

	public class DddwAllowanceTypesDistance : Entity<DddwAllowanceTypesDistance>
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
		public static DddwAllowanceTypesDistance NewDddwAllowanceTypesDistance(  )
		{
			return Create();
		}

		public static DddwAllowanceTypesDistance[] GetAllDddwAllowanceTypesDistance()
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
        private void FetchEntity()
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
                try
                {
                    using (DbCommand cm = cn.CreateCommand())
                    {
                        int inAlctId = 5; 
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "sp_DDDW_AllowanceTypeV2";
                        ParameterCollection pList = new ParameterCollection();
                        pList.Add(cm, "inAlctId", inAlctId);

                        List<DddwAllowanceTypesDistance> _list = new List<DddwAllowanceTypesDistance>();
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                DddwAllowanceTypesDistance instance = new DddwAllowanceTypesDistance();
                                instance._alt_key = GetValueFromReader<Int32?>(dr, 0);
                                instance._alt_description = GetValueFromReader<String>(dr, 1);
                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                            list = _list.ToArray();
                        }
                    }
                }
                catch(Exception e)
                {
                    sqlErrText = e.Message;
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
