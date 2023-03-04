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
	[MapInfo("prt_key", "_prt_key", "")]
	[MapInfo("prt_description", "_prt_description", "")]
	[MapInfo("prs_description", "_prs_description", "")]
	[System.Serializable()]

	public class DddwPieceRates : Entity<DddwPieceRates>
	{
		#region Business Methods
		[DBField()]
		private int?  _prt_key;

		[DBField()]
		private string  _prt_description;

		[DBField()]
		private string  _prs_description;


		public virtual int? PrtKey
		{
			get
			{
                CanReadProperty("PrtKey", true);
				return _prt_key;
			}
			set
			{
                CanWriteProperty("PrtKey", true);
				if ( _prt_key != value )
				{
					_prt_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PrtDescription
		{
			get
			{
                CanReadProperty("PrtDescription", true);
				return _prt_description;
			}
			set
			{
                CanWriteProperty("PrtDescription", true);
				if ( _prt_description != value )
				{
					_prt_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PrsDescription
		{
			get
			{
                CanReadProperty("PrsDescription", true);
				return _prs_description;
			}
			set
			{
                CanWriteProperty("PrsDescription", true);
				if ( _prs_description != value )
				{
					_prs_description = value;
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
		public static DddwPieceRates NewDddwPieceRates(  )
		{
			return Create();
		}

		public static DddwPieceRates[] GetAllDddwPieceRates(  )
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
                    cm.CommandText = "sp_DDDW_PieceRates";
					List<DddwPieceRates> _list = new List<DddwPieceRates>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwPieceRates instance = new DddwPieceRates();
                            instance._prt_key = GetValueFromReader<Int32?>(dr,0);
                            instance._prt_description = GetValueFromReader<String>(dr,1);
                            instance._prs_description = GetValueFromReader<String>(dr,2);
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
