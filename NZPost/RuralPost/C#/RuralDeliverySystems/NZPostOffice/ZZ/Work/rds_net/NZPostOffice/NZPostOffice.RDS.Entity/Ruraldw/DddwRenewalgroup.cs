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

	public class DddwRenewalgroup : Entity<DddwRenewalgroup>
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
            return _rg_code.GetValueOrDefault()+ " ";// "";
		}
		#endregion

		#region Factory Methods
		public static DddwRenewalgroup NewDddwRenewalgroup(  )
		{
			return Create();
		}

		public static DddwRenewalgroup[] GetAllDddwRenewalgroup(  )
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
                    cm.CommandText = "rd.sp_DDDW_RenewalGroupList";

					List<DddwRenewalgroup> _list = new List<DddwRenewalgroup>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwRenewalgroup instance = new DddwRenewalgroup();
                            instance._rg_code = GetValueFromReader<Int32?>(dr,0);
                            instance._rg_description = GetValueFromReader<String>(dr,1);
							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
                        //! added a record to avoid initial value non empty in dropdown list
                        DddwRenewalgroup emptyRecord = new DddwRenewalgroup();
                        emptyRecord._rg_code = null;
                        emptyRecord._rg_description = string.Empty;
                        _list.Add(emptyRecord);


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
