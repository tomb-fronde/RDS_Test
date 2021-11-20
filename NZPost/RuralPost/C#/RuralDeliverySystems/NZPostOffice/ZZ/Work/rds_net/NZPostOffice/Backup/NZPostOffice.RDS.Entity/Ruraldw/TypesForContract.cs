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
    [MapInfo("ct_key", "_ct_key", "types_for_contract")]
    [MapInfo("contract_no", "_contract_no", "types_for_contract")]
	[System.Serializable()]

	public class TypesForContract : Entity<TypesForContract>
	{
		#region Business Methods
		[DBField()]
		private int?  _ct_key;

		[DBField()]
		private int?  _contract_no;


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

		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}", _ct_key,_contract_no );
		}
		#endregion

		#region Factory Methods
		public static TypesForContract NewTypesForContract( int? in_Contract )
		{
			return Create(in_Contract);
		}

		public static TypesForContract[] GetAllTypesForContract( int? in_Contract )
		{
			return Fetch(in_Contract).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_Contract )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_GetTypesForContract";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_Contract", in_Contract);

					List<TypesForContract> _list = new List<TypesForContract>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							TypesForContract instance = new TypesForContract();
                            instance._ct_key = GetValueFromReader<Int32?>(dr,0);
                            instance._contract_no = GetValueFromReader<Int32?>(dr,1);
							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
						list = _list.ToArray();
					}
				}
			}
		}

        [ServerMethod]
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();

                if (GenerateUpdateCommandText(cm, "types_for_contract", ref pList))
                {
                    cm.CommandText += " WHERE  ct_key= @ct_key AND " +
                        "contract_no= @contract_no ";

                    pList.Add(cm, "ct_key", GetInitialValue("_ct_key"));
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                // reinitialize original key/value list
                StoreInitialValues();
            }
        }

        [ServerMethod()]
        private void InsertEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;

                ParameterCollection pList = new ParameterCollection();

                if (GenerateInsertCommandText(cm, "types_for_contract", pList))
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                StoreInitialValues();
            }
        }
        [ServerMethod()]
        private void DeleteEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    DbCommand cm = cn.CreateCommand();
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "ct_key", GetInitialValue("_ct_key"));
                    cm.CommandText = "DELETE FROM types_for_contract WHERE " +
                    "types_for_contract.contract_no = @contract_no AND " +
                    "types_for_contract.ct_key = @ct_key ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? ct_key, int? contract_no )
		{
			_ct_key = ct_key;
			_contract_no = contract_no;
		}
	}
}
