using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("customer_title_name", "_customer_title", "customer_title")]
	[MapInfo("customer_title_id", "_customer_title_id", "customer_title")]
	[System.Serializable()]

	public class DddwCustTitle : Entity<DddwCustTitle>
	{
		#region Business Methods
		[DBField()]
		private string  _customer_title;

		[DBField()]
		private int?  _customer_title_id;


		public virtual string CustomerTitle
		{
			get
			{
                CanReadProperty("CustomerTitle", true);
				return _customer_title;
			}
			set
			{
                CanWriteProperty("CustomerTitle", true);
				if ( _customer_title != value )
				{
					_customer_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? CustomerTitleId
		{
			get
			{
                CanReadProperty("CustomerTitleId", true);
				return _customer_title_id;
			}
			set
			{
                CanWriteProperty("CustomerTitleId", true);
				if ( _customer_title_id != value )
				{
					_customer_title_id = value;
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
		public static DddwCustTitle NewDddwCustTitle(  )
		{
			return Create();
		}

		public static DddwCustTitle[] GetAllDddwCustTitle(  )
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
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT customer_title_name ,customer_title_id " 
                                     + "FROM customer_title " 
                                     + "ORDER BY customer_title_id ASC";

					List<DddwCustTitle> _list = new List<DddwCustTitle>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwCustTitle instance = new DddwCustTitle();
                            instance._customer_title = GetValueFromReader<string>(dr,0);
                            //! remove null value otherwise dropdown throws exception
                            if (instance._customer_title != null)
                            {
                                instance._customer_title_id = GetValueFromReader<int?>(dr, 1);
							    instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
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
