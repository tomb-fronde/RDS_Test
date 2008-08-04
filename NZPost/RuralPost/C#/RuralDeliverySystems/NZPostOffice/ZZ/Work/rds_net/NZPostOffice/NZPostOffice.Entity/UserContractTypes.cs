using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;using Metex.Core.Security;using Metex.Core;

namespace NZPostOffice.Entity
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("ct_key", "_ct_key", "rds_user_contract_type")]
	[MapInfo("ui_id", "_ui_id", "rds_user_contract_type")]
	[MapInfo("contract_type", "_contract_type_contract_type", "contract_type")]
	[System.Serializable()]

	public class UserContractTypes : Entity<UserContractTypes>
	{
		#region Business Methods
		[DBField()]
		private int?  _ct_key;

		[DBField()]
		private int?  _ui_id;

		[DBField()]
		private string  _contract_type_contract_type;


		public virtual int? CtKey
		{
			get
			{
				CanReadProperty(true);
				return _ct_key;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ct_key != value )
				{
					_ct_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? UiId
		{
			get
			{
				CanReadProperty(true);
				return _ui_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ui_id != value )
				{
					_ui_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractTypeContractType
		{
			get
			{
				CanReadProperty(true);
				return _contract_type_contract_type;
			}
			set
			{
				CanWriteProperty(true);
				if ( _contract_type_contract_type != value )
				{
					_contract_type_contract_type = value;
					PropertyHasChanged();
				}
			}
		}
		private UserContractTypes[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static UserContractTypes NewUserContractTypes( int? al_userid )
		{
			return Create(al_userid);
		}

		public static UserContractTypes[] GetAllUserContractTypes( int? al_userid )
		{
			return Fetch(al_userid).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? al_userid )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT rds_user_contract_type.ct_key,  rds_user_contract_type.ui_id,  contract_type.contract_type  FROM rd.rds_user_contract_type,  rd.contract_type  WHERE ( contract_type.ct_key = rds_user_contract_type.ct_key ) and  ( ( rds_user_contract_type.ui_id = :al_userid ) )  ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_userid", al_userid);

					List<UserContractTypes> list = new List<UserContractTypes>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							UserContractTypes instance = new UserContractTypes();
							instance.StoreFieldValues(dr, "rd.rds_user_contract_type");
							instance.StoreFieldValues(dr, "rd.contract_type");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new UserContractTypes[list.Count];
						list.CopyTo(dataList);
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
