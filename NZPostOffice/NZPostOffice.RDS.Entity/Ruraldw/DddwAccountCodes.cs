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
	[MapInfo("ac_id", "_ac_id", "")]
	[MapInfo("ac_code", "_ac_code", "")]
	[MapInfo("ac_description", "_ac_description", "")]
	[System.Serializable()]

	public class DddwAccountCodes : Entity<DddwAccountCodes>
	{
		#region Business Methods
		[DBField()]
		private int?  _ac_id;

		[DBField()]
		private string  _ac_code;

		[DBField()]
		private string  _ac_description;


		public virtual int? AcId
		{
			get
			{
                CanReadProperty("AcId", true);
				return _ac_id;
			}
			set
			{
                CanWriteProperty("AcId", true);
				if ( _ac_id != value )
				{
					_ac_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AcCode
		{
			get
			{
                CanReadProperty("AcCode", true);
				return _ac_code;
			}
			set
			{
                CanWriteProperty("AcCode", true);
				if ( _ac_code != value )
				{
					_ac_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AcDescription
		{
			get
			{
                CanReadProperty("AcDescription", true);
				return _ac_description;
			}
			set
			{
                CanWriteProperty("AcDescription", true);
				if ( _ac_description != value )
				{
					_ac_description = value;
					PropertyHasChanged();
				}
			}
		}

        //add by mkwang ToString
        public override string ToString()
        {
            return AcCode.PadRight(15, ' ') + AcDescription;
        } 

		protected override object GetIdValue()
		{
			return _ac_id;
		}
		#endregion

		#region Factory Methods
		public static DddwAccountCodes NewDddwAccountCodes(  )
		{
			return Create();
		}

		public static DddwAccountCodes[] GetAllDddwAccountCodes(  )
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
                    cm.CommandText = "odps.od_cts_accountcodes";

					List<DddwAccountCodes> _list = new List<DddwAccountCodes>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwAccountCodes instance = new DddwAccountCodes();
                            instance._ac_id = GetValueFromReader<Int32?>(dr,0);
                            instance._ac_code = GetValueFromReader<String>(dr,1);
                            instance._ac_description = GetValueFromReader<String>(dr,2);
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
