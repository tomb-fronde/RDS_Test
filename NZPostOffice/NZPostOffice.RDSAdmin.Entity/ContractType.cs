using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("ct_key", "_ct_key", "contract_type", true)]
	[MapInfo("contract_type", "_contract_type", "contract_type")]
	[MapInfo("ct_next_contract", "_ct_next_contract", "contract_type")]
	[MapInfo("ct_rd_ref_mandatory", "_ct_rd_ref_mandatory", "contract_type")]
	[System.Serializable()]

    public class ContractTypeBE : Entity<ContractTypeBE>
	{
		#region Business Methods
		[DBField()]
		private int?  _ct_key;

		[DBField()]
		private string  _contract_type;

		[DBField()]
		private int?  _ct_next_contract;

		[DBField()]
		private string  _ct_rd_ref_mandatory;


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

		public virtual int? CtNextContract
		{
			get
			{
				CanReadProperty(true);
				return _ct_next_contract;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ct_next_contract != value )
				{
					_ct_next_contract = value;
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
        private ContractTypeBE[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _ct_key );
		}
		#endregion

		#region Factory Methods
        public static ContractTypeBE NewContractType(int? ct_key)
		{
            return Create(ct_key);
		}

        public static ContractTypeBE[] GetAllContractType()
		{
			return Fetch().dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					GenerateSelectCommandText(cm, "contract_type");

                    List<ContractTypeBE> list = new List<ContractTypeBE>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
                            ContractTypeBE instance = new ContractTypeBE();
							instance.StoreFieldValues(dr, "contract_type");
							instance.MarkOld();
							list.Add(instance);
						}
                        dataList = new ContractTypeBE[list.Count];
						list.CopyTo(dataList);
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
					ParameterCollection pList = new ParameterCollection();
				if (GenerateUpdateCommandText(cm, "contract_type", ref pList))
				{
					cm.CommandText += " WHERE  contract_type.ct_key = @ct_key ";

					pList.Add(cm, "ct_key", GetInitialValue("_ct_key"));
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
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
						cm.CommandText = "DELETE FROM contract_type WHERE " +
						"contract_type.ct_key = @ct_key ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? ct_key )
		{
			_ct_key = ct_key;
		}
	}
}
