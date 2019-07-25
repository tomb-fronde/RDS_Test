using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
    // TJB  July-2018
    // Reformatted fetch select statement for clarity

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("ct_key", "_contract_type_ct_key", "contract_type")]
	[MapInfo("contract_type", "_contract_type_contract_type", "contract_type")]
	[MapInfo("ui_id", "_rds_user_contract_type_ui_id", "rds_user_contract_type")]
	[MapInfo("dummy1", "_dummy1", "contract_type")]
	[System.Serializable()]

    public class ContractTypes : Entity<ContractTypes>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_type_ct_key;

		[DBField()]
		private string  _contract_type_contract_type;

		[DBField()]
		private int?  _rds_user_contract_type_ui_id;

		[DBField()]
		private string  _dummy1;


		public virtual int? ContractTypeCtKey
		{
			get
			{
				CanReadProperty(true);
				return _contract_type_ct_key;
			}
			set
			{
				CanWriteProperty(true);
				if ( _contract_type_ct_key != value )
				{
					_contract_type_ct_key = value;
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

		public virtual int? RdsUserContractTypeUiId
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_contract_type_ui_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_contract_type_ui_id != value )
				{
					_rds_user_contract_type_ui_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Dummy1
		{
			get
			{
				CanReadProperty(true);
				return _dummy1;
			}
			set
			{
				CanWriteProperty(true);
				if ( _dummy1 != value )
				{
					_dummy1 = value;
					PropertyHasChanged();
				}
			}
		}
        private ContractTypes[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
        public static ContractTypes NewContractTypes()
		{
			return Create();
		}

        public static ContractTypes[] GetAllContractTypes(int al_ui_id)
		{
            return Fetch(al_ui_id).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
        private void FetchEntity(int al_ui_id)
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT contract_type.ct_key"
                                    + "    , contract_type.contract_type"
                                    + "    , rds_user_contract_type.ui_id"
                                    + "    , 'Y' as dummy1 "
                                    + " FROM contract_type"
                                    + "    , rds_user_contract_type "
                                    + "WHERE rds_user_contract_type.ct_key = contract_type.ct_key"
                                    + "  and rds_user_contract_type.ui_id = :al_ui_id "
                                    + "UNION "
                                    + "SELECT contract_type.ct_key"
                                    + "    , contract_type.contract_type"
                                    + "    , 1"
                                    + "    , 'N'"
                                    + " FROM contract_type "
                                    + "WHERE contract_type.ct_key NOT IN "
                                    + "            (SELECT ct_key "
                                    + "               FROM rds_user_contract_type "
                                    + "              WHERE ui_id = :al_ui_id)";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_ui_id", al_ui_id);

                    List<ContractTypes> list = new List<ContractTypes>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
                            ContractTypes instance = new ContractTypes();
                            instance.ContractTypeCtKey = dr.GetInt32(0);
							instance.ContractTypeContractType = dr.GetString(1).Trim();
							instance.RdsUserContractTypeUiId = dr.GetInt32(2);
                            instance.Dummy1 = dr.GetString(3);
							instance.MarkOld();
							list.Add(instance);
						}
                        dataList = new ContractTypes[list.Count];
						list.CopyTo(dataList);
					}
				}
			}
		}

        [ServerMethod()]
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                
                pList = new ParameterCollection();
                cm.CommandText = "Update contract_type Set ct_rd_ref_mandatory=@dummy1 From contract_type,  rds_user_contract_type WHERE ( rds_user_contract_type.ct_key = contract_type.ct_key ) and  ( ( rds_user_contract_type.ui_id = @ui_id) ) and ( ( rds_user_contract_type.ct_key = @ct_key) )";

                pList.Add(cm, "dummy1", _dummy1);
                pList.Add(cm, "ui_id", GetInitialValue("_rds_user_contract_type_ui_id"));
                pList.Add(cm, "ct_key", GetInitialValue("_contract_type_ct_key"));
                try
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                catch
                {
                }

                StoreInitialValues();
            }
        }
		#endregion

		[ServerMethod()]
		private void CreateEntity(  )
		{
		}
	}
}
