using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // TJB  RPCR_091  17-Dec-2014
    // Changed FindEntity sort order 
    //    from 'selected, occupation_id' to 'selected, occupation_description'

    // TJB  RPCR_023  Feb-2011  :New

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("co_selected", "_co_selected", "customer_occupation")]
	[MapInfo("cust_id", "_cust_id", "customer_occupation")]
	[MapInfo("occupation_id", "_occupation_id", "customer_occupation")]
	[MapInfo("occupation_description", "_occupation_description", "customer_occupation")]
	[System.Serializable()]

	public class CustomerOccupations : Entity<CustomerOccupations>
	{
		private int _sqlerrcode = 0;
		private string _sqlerrtext = "";

		public int SQLErrCode
		{
			get
			{
				return _sqlerrcode;
			}
		}

		public string SQLErrText
		{
			get
			{
			return _sqlerrtext;
			}
		}

		private int? _co_selected_initialValue = 0;

		#region Business Methods
		[DBField()]
		private int? _co_selected = 0;
	
		[DBField()]
		private int? _cust_id;

		[DBField()]
		private int? _occupation_id;

		[DBField()]
		private string  _occupation_description;

		public virtual int? CoSelected
		{
			get
			{
				CanReadProperty(true);
				return _co_selected;
			}
			set
			{
				CanWriteProperty(true);
				if ( _co_selected != value )
				{
					_co_selected = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? CustId
		{
			get
			{
				CanReadProperty(true);
				return _cust_id;
			}
			set
			{
				CanWriteProperty(true);
				if (_cust_id != value)
				{
					_cust_id = value;
					PropertyHasChanged();
				}
			}
		}
	
		public virtual int? OccupationId
		{
			get
			{
				CanReadProperty(true);
				return _occupation_id;
			}
			set
			{
				CanWriteProperty(true);
				if (_occupation_id != value)
				{
					_occupation_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OccupationDescription
		{
			get
			{
				CanReadProperty(true);
				return _occupation_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _occupation_description != value )
				{
					_occupation_description = value;
					PropertyHasChanged();
				}
			}
		}


		private CustomerOccupations[] list;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _occupation_id );
		}
		#endregion

		#region Factory Methods
		public static CustomerOccupations NewCustomerOccupation(int? in_cust_id, int? in_occupation_id)
		{
			return Create(in_cust_id, in_occupation_id);
		}

		public static CustomerOccupations[] GetAllCustomerOccupations(int? in_cust_id)
		{
			return Fetch(in_cust_id).list;
			//return Fetch(in_cust_id).datalist;
		}
		#endregion

		#region Data Access
		[ServerMethod]
        // TJB  RPCR_091  17-Dec-2014
        // Changed sort order from 'selected, occupation_id' to 'selected, occupation_description'
		private void FetchEntity(int? in_cust_id)
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					cm.CommandText = "select 1 as selected, o.occupation_id, o.occupation_description"
							+ "  from occupation o join customer_occupation co "
							+ "                    on o.occupation_id = co.occupation_id "
							+ "                    and co.cust_id = @in_cust_id "
							+ "UNION "
							+ "select 0 as selected, o.occupation_id, o.occupation_description "
							+ "  from occupation o "
							+ " where o.occupation_id not in " 
							+ "             (select o2.occupation_id "
							+ "                from occupation o2 join customer_occupation co "
							+ "                                   on o2.occupation_id = co.occupation_id "
							+ "               where o2.occupation_id = o.occupation_id "
							+ "                 and co.cust_id = @in_cust_id) "
                            + "order by selected desc, occupation_description ";

					pList.Add(cm,"in_cust_id", in_cust_id);

					List<CustomerOccupations> _list = new List<CustomerOccupations>();
					try
					{
						using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
						{
							while (dr.Read())
							{
								CustomerOccupations instance = new CustomerOccupations();

								instance._co_selected = GetValueFromReader<Int32?>(dr, 0);
								instance._co_selected_initialValue = instance._co_selected;
								instance._occupation_id = GetValueFromReader<Int32?>(dr, 1);
								instance._occupation_description = GetValueFromReader<String>(dr, 2);
								instance._cust_id = in_cust_id;

								instance.MarkOld();
								instance.StoreInitialValues();
								_list.Add(instance);
							}
							list = _list.ToArray();
							//dataList = new CustomerOccupations[list.Count];
							//_list.CopyTo(dataList);
						}
					}
					catch (Exception e)
					{
						_sqlerrcode = -1;
						_sqlerrtext = e.Message;
					}
				}
			}
		}

		[ServerMethod()]
		private void UpdateEntity()
		{
			using ( DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;

				bool ok = false;
				if ( _co_selected_initialValue == 1 && _co_selected == 0 )
				{
					cm.CommandText = "delete from customer_occupation "
						       + " where cust_id = @cust_id and occupation_id = @occupation_id";
					ok = true;
				}
				else if ( _co_selected_initialValue == 0 && _co_selected == 1)
				{
					cm.CommandText = "insert into customer_occupation "
						       + "  ( cust_id, occupation_id )"
						       + " values ( @cust_id, @occupation_id )";
					ok = true;
				}

				if ( ! ok )
					return;

				ParameterCollection pList = new ParameterCollection();
				pList.Add(cm, "cust_id", _cust_id);
				pList.Add(cm, "occupation_id", _occupation_id);

				try
				{
					DBHelper.ExecuteNonQuery(cm, pList);
					StoreInitialValues();
				}
				catch ( Exception e )
				{
					_sqlerrcode = -1;
					_sqlerrtext = e.Message;
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity(int? in_cust_id, int? in_occupation_id)
		{
			_cust_id = in_cust_id;
			_occupation_id = in_occupation_id;
		}
	}
}
