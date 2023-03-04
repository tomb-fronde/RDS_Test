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
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("contract_seq_number", "_contract_seq_number", "")]
	[MapInfo("outdate", "_outdate", "")]
	[System.Serializable()]

	public class ContractSummary : Entity<ContractSummary>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _contract_seq_number;

		[DBField()]
		private DateTime?  _outdate;


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

		public virtual DateTime? Outdate
		{
			get
			{
                CanReadProperty("Outdate", true);
				return _outdate;
			}
			set
			{
                CanWriteProperty("Outdate", true);
				if ( _outdate != value )
				{
					_outdate = value;
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
		public static ContractSummary NewContractSummary( int? inContract, int? inSequence, DateTime? indate )
		{
			return Create(inContract, inSequence, indate);
		}

		public static ContractSummary[] GetAllContractSummary( int? inContract, int? inSequence, DateTime? indate )
		{
			return Fetch(inContract, inSequence, indate).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inContract, int? inSequence, DateTime? indate )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_contractsummarylist";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContract", inContract);
					pList.Add(cm, "inSequence", inSequence);
					pList.Add(cm, "indate", indate);

					List<ContractSummary> _list = new List<ContractSummary>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractSummary instance = new ContractSummary();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
                            instance._contract_seq_number = GetValueFromReader<int?>(dr,1);
                            instance._outdate = GetValueFromReader<DateTime?>(dr,2);
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
