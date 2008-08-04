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
	[MapInfo("cust_id", "_cust_id", "")]
	[MapInfo("recipient_id", "_recipient_id", "")]
	[MapInfo("rc_surname_company", "_rc_surname_company", "")]
	[MapInfo("rc_first_names", "_rc_first_names", "")]
	[System.Serializable()]

	public class Sptest : Entity<Sptest>
	{
		#region Business Methods
		[DBField()]
		private int?  _cust_id;

		[DBField()]
		private int?  _recipient_id;

		[DBField()]
		private string  _rc_surname_company;

		[DBField()]
		private string  _rc_first_names;

		public virtual int? CustId
		{
			get
			{
				CanReadProperty("CustId",true);
				return _cust_id;
			}
			set
			{
                CanWriteProperty("CustId", true);
				if ( _cust_id != value )
				{
					_cust_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RecipientId
		{
			get
			{
				CanReadProperty("RecipientId",true);
				return _recipient_id;
			}
			set
			{
				CanWriteProperty("RecipientId",true);
				if ( _recipient_id != value )
				{
					_recipient_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RcSurnameCompany
		{
			get
			{
				CanReadProperty("RcSurnameCompany",true);
				return _rc_surname_company;
			}
			set
			{
                CanWriteProperty("RcSurnameCompany", true);
				if ( _rc_surname_company != value )
				{
					_rc_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RcFirstNames
		{
			get
			{
				CanReadProperty("RcFirstNames",true);
				return _rc_first_names;
			}
			set
			{
				CanWriteProperty("RcFirstNames",true);
				if ( _rc_first_names != value )
				{
					_rc_first_names = value;
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
		public static Sptest NewSptest(  )
		{
			return Create();
		}

		public static Sptest[] GetAllSptest(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.dwsptest";
					ParameterCollection pList = new ParameterCollection();

					List<Sptest> _list = new List<Sptest>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							Sptest instance = new Sptest();
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
