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
	[MapInfo("contract_seq_number", "_contract_seq_number", "")]
	[System.Serializable()]

	public class AssignArticalCountToRenewal : Entity<AssignArticalCountToRenewal>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_seq_number;

        private int? _in_Contract;

		public virtual int? ContractSeqNumber
		{
			get
			{
                CanReadProperty("ContractSeqNumber", true);
				return _contract_seq_number;
			}
			set
			{
                CanWriteProperty("ContractSeqNumber", true);
				if ( _contract_seq_number != value )
				{
					_contract_seq_number = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string Compute1
        {
            get
            {
                CanReadProperty("Compute1", true);
                return _in_Contract.GetValueOrDefault().ToString() + "/" + _contract_seq_number.GetValueOrDefault().ToString("##");
            }
        }

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static AssignArticalCountToRenewal NewAssignArticalCountToRenewal( int? in_Contract )
		{
			return Create(in_Contract);
		}

		public static AssignArticalCountToRenewal[] GetAllAssignArticalCountToRenewal( int? in_Contract )
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
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_Contract", in_Contract);
                    cm.CommandText = "sp_GetRenewalListing";

					List<AssignArticalCountToRenewal> _list = new List<AssignArticalCountToRenewal>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							AssignArticalCountToRenewal instance = new AssignArticalCountToRenewal();
                            instance._in_Contract = in_Contract;
                            instance._contract_seq_number = GetValueFromReader<Int32?>(dr,0);
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
