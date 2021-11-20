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
	[MapInfo("ct_key", "_ct_key", "")]
	[MapInfo("contract_type", "_contract_type", "")]
	[System.Serializable()]

	public class DddwContractTypesNew : Entity<DddwContractTypesNew>
	{
		#region Business Methods
		[DBField()]
		private int?  _ct_key;

		[DBField()]
		private string  _contract_type;


		public virtual int? CtKey
		{
			get
			{
                CanReadProperty("CtKey", true);
				return _ct_key;
			}
			set
			{
                CanWriteProperty("CtKey", true);
				if ( _ct_key != value )
				{
					_ct_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractType
		{
			get
			{
                CanReadProperty("ContractType", true);
				return _contract_type;
			}
			set
			{
                CanWriteProperty("ContractType", true);
				if ( _contract_type != value )
				{
					_contract_type = value;
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
		public static DddwContractTypesNew NewDddwContractTypesNew(  )
		{
			return Create();
		}

		public static DddwContractTypesNew[] GetAllDddwContractTypesNew(  )
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
                    cm.CommandText = "sp_dddw_contracttypes_new";

					List<DddwContractTypesNew> _list = new List<DddwContractTypesNew>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwContractTypesNew instance = new DddwContractTypesNew();
                            instance._ct_key = GetValueFromReader<Int32?>(dr,0);
                            instance._contract_type = GetValueFromReader<String>(dr,1);
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
