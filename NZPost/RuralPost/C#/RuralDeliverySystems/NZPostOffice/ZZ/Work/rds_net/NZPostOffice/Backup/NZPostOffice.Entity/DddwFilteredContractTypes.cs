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
	[MapInfo("contract_type", "_contract_type", "contract_type")]
	[MapInfo("ct_key", "_ct_key", "contract_type")]
	[MapInfo("ct_rd_ref_mandatory", "_ct_rd_ref_mandatory", "contract_type")]
	[System.Serializable()]

    public class FilteredContractTypes : Entity<FilteredContractTypes>
	{
		#region Business Methods
		[DBField()]
		private string  _contract_type;

		[DBField()]
		private int?  _ct_key;

		[DBField()]
		private string  _ct_rd_ref_mandatory;


		public virtual string ContractType
		{
			get
			{
				CanReadProperty(true);
				return _contract_type;
			}
			set
			{
				CanWriteProperty(true);
				if ( _contract_type != value )
				{
					_contract_type = value;
					PropertyHasChanged();
				}
			}
		}

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

		public virtual string CtRdRefMandatory
		{
			get
			{
				CanReadProperty(true);
				return _ct_rd_ref_mandatory;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ct_rd_ref_mandatory != value )
				{
					_ct_rd_ref_mandatory = value;
					PropertyHasChanged();
				}
			}
		}
		private FilteredContractTypes[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static FilteredContractTypes NewDddwFilteredContractTypes()
		{
			return Create();
		}

		public static FilteredContractTypes[] GetAllDddwFilteredContractTypes( int? al_ui_id )
		{
			return Fetch(al_ui_id).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? al_ui_id )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT contract_type.contract_type,  contract_type.ct_key,  contract_type.ct_rd_ref_mandatory  FROM rd.contract_type,  rd.rds_user_contract_type  WHERE ( rds_user_contract_type.ct_key = contract_type.ct_key ) and  ( ( rds_user_contract_type.ui_id = :al_ui_id ) )  ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_ui_id", al_ui_id);

					List<FilteredContractTypes> list = new List<FilteredContractTypes>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							FilteredContractTypes instance = new FilteredContractTypes();
							instance.StoreFieldValues(dr, "contract_type");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new FilteredContractTypes[list.Count];
						list.CopyTo(dataList);
					}
				}
			}
		}

		#endregion

		[ServerMethod()]
        private void CreateEntity()
		{
		}
	}
}
