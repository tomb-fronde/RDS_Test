using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // TJB  Feb-2011  RPCR_023  :New

    // Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("ci_selected", "_ci_selected", "customer_interest")]
    [MapInfo("cust_id", "_cust_id", "customer_interest")]
    [MapInfo("interest_id", "_interest_id", "customer_interest")]
    [MapInfo("interest_description", "_interest_description", "customer_interest")]
	[System.Serializable()]

	public class CustomerInterests : Entity<CustomerInterests>
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

        private int? _ci_selected_initialValue = 0;

        #region Business Methods
		[DBField()]
		private int? _ci_selected = 0;

        [DBField()]
        private int? _cust_id;

        [DBField()]
        private int? _interest_id;

		[DBField()]
		private string  _interest_description;

		public virtual int? CiSelected
		{
			get
			{
				CanReadProperty(true);
				return _ci_selected;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ci_selected != value )
				{
					_ci_selected = value;
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

        public virtual int? InterestId
        {
            get
            {
                CanReadProperty(true);
                return _interest_id;
            }
            set
            {
                CanWriteProperty(true);
                if (_interest_id != value)
                {
                    _interest_id = value;
                    PropertyHasChanged();
                }
            }
        }

		public virtual string InterestDescription
		{
			get
			{
				CanReadProperty(true);
                return _interest_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _interest_description != value )
				{
					_interest_description = value;
					PropertyHasChanged();
				}
			}
		}


        private CustomerInterests[] list;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _interest_id );
		}
		#endregion

		#region Factory Methods
        public static CustomerInterests NewCustomerInterest(int? in_cust_id, int? in_interest_id)
		{
			return Create(in_cust_id, in_interest_id);
		}

        public static CustomerInterests[] GetAllCustomerInterests(int? in_cust_id)
		{
			return Fetch(in_cust_id).list;
			//return Fetch(in_cust_id).datalist;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(int? in_cust_id)
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					cm.CommandText = "select 1 as selected, i.interest_id, i.interest_description"
                                   + "  from interest i join customer_interest ci "
                                   + "                   on i.interest_id = ci.interest_id "
                                   + "                  and ci.cust_id = @in_cust_id "
                                   + "UNION "
                                   + "select 0 as selected, i1.interest_id, i1.interest_description "
                                   + "  from interest i1 "
                                   + " where i1.interest_id not in " 
                                   + "            (select i2.interest_id "
                                   + "               from interest i2 join customer_interest ci "
                                   + "                                on i2.interest_id = ci.interest_id "
                                   + "              where i2.interest_id = i1.interest_id "
                                   + "                and ci.cust_id = @in_cust_id) "
                                   + "order by selected desc, interest_id ";

					pList.Add(cm,"in_cust_id", in_cust_id);

                    List<CustomerInterests> _list = new List<CustomerInterests>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                CustomerInterests instance = new CustomerInterests();

                                instance._ci_selected = GetValueFromReader<Int32?>(dr, 0);
                                instance._ci_selected_initialValue = instance._ci_selected;
                                instance._interest_id = GetValueFromReader<Int32?>(dr, 1);
                                instance._interest_description = GetValueFromReader<String>(dr, 2);
                                instance._cust_id = in_cust_id;

                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                            list = _list.ToArray();
                            //dataList = new CustomerInterests[list.Count];
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
                if ( _ci_selected_initialValue == 1 && _ci_selected == 0 )
                {
                    cm.CommandText = "delete from customer_interest "
                                   + " where cust_id = @cust_id and interest_id = @interest_id";
                    ok = true;
                }
                else if ( _ci_selected_initialValue == 0 && _ci_selected == 1)
                {
                    cm.CommandText = "insert into customer_interest "
                                   + "  ( cust_id, interest_id )"
                                   + " values ( @cust_id, @interest_id )";
                    ok = true;
                }

                if ( ! ok )
                    return;

                ParameterCollection pList = new ParameterCollection();
                pList.Add(cm, "cust_id", _cust_id);
                pList.Add(cm, "interest_id", _interest_id);

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
		[ServerMethod()]
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
				ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "contract_type", pList))
				{
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void DeleteEntity()
		{
			using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbTransaction tr = cn.BeginTransaction())
				{
					DbCommand cm=cn.CreateCommand();
					cm.Transaction = tr;
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm,"ct_key", GetInitialValue("_ct_key"));
					cm.CommandText = "DELETE FROM contract_type WHERE "
							 + "contract_type.ct_key = @ct_key ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
        private void CreateEntity(int? in_cust_id, int? in_interest_id)
		{
            _cust_id = in_cust_id;
            _interest_id = in_interest_id;
		}
	}
}
