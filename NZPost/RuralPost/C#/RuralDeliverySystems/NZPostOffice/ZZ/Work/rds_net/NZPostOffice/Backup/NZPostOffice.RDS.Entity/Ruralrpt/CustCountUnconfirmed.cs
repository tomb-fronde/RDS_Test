using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("rgn_name", "_rgn_name", "")]
	[MapInfo("o_name", "_o_name", "")]
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("con_title", "_con_title", "")]
	[MapInfo("count1", "_count1", "")]
	[System.Serializable()]

	public class CustCountUnconfirmed : Entity<CustCountUnconfirmed>
	{
		#region Business Methods
		[DBField()]
		private string  _rgn_name;

		[DBField()]
		private string  _o_name;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _con_title;

		[DBField()]
		private int?  _count1;


		public virtual string RgnName
		{
			get
			{
                CanReadProperty("RgnName", true);
				return _rgn_name;
			}
			set
			{
                CanWriteProperty("RgnName", true);
				if ( _rgn_name != value )
				{
					_rgn_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OName
		{
			get
			{
                CanReadProperty("OName", true);
				return _o_name;
			}
			set
			{
                CanWriteProperty("OName", true);
				if ( _o_name != value )
				{
					_o_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ContractNo
		{
			get
			{
                CanReadProperty("ContractNo", true);
				return _contract_no;
			}
			set
			{
                CanWriteProperty("ContractNo", true);
				if ( _contract_no != value )
				{
					_contract_no = value;
					PropertyHasChanged();
				}
			}
		}

        public  int REContractNo
        {
            get
            {
                return (int)_contract_no;
            }
        }

		public virtual string ConTitle
		{
			get
			{
                CanReadProperty("ConTitle", true);
				return _con_title;
			}
			set
			{
                CanWriteProperty("ConTitle", true);
				if ( _con_title != value )
				{
					_con_title = value;
					PropertyHasChanged();
				}
			}
		}

		public  int RECount1
		{
			get
			{
         		return (int)_count1;
			}
		}

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static CustCountUnconfirmed NewCustCountUnconfirmed( int? Inregion, int? inOutlet, int? inContract, DateTime? indate )
		{
			return Create(Inregion, inOutlet, inContract, indate);
		}

		public static CustCountUnconfirmed[] GetAllCustCountUnconfirmed( int? Inregion, int? inOutlet, int? inContract, DateTime? indate )
		{
			return Fetch(Inregion, inOutlet, inContract, indate).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? Inregion, int? inOutlet, int? inContract, DateTime? indate )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_GetUnconfirmedCustomers";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "Inregion", Inregion);
					pList.Add(cm, "inOutlet", inOutlet);
					pList.Add(cm, "inContract", inContract);
					pList.Add(cm, "indate", indate);

					List<CustCountUnconfirmed> _list = new List<CustCountUnconfirmed>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							CustCountUnconfirmed instance = new CustCountUnconfirmed();
                            instance._rgn_name = GetValueFromReader<string>(dr,0);
	                        instance._o_name = GetValueFromReader<string>(dr,1);
                            instance._contract_no = GetValueFromReader<int?>(dr,2);
	                        instance._con_title = GetValueFromReader<string>(dr,3);
                            instance._count1 = GetValueFromReader<int?>(dr, 4);
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
