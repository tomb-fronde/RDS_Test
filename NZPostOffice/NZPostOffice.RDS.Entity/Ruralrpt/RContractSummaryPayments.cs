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
	[MapInfo("c_amount", "_camount", "")]
	[MapInfo("c_type", "_ctype", "")]
	[MapInfo("c_sort", "_c_sort", "")]
	[System.Serializable()]

	public class ContractSummaryPayments : Entity<ContractSummaryPayments>
	{
		#region Business Methods
		[DBField()]
		private decimal?  _camount;

		[DBField()]
		private string  _ctype;

		[DBField()]
		private int?  _c_sort;


		public virtual decimal? Camount
		{
			get
			{
                CanReadProperty("Camount", true);
				return _camount;
			}
			set
			{
                CanWriteProperty("Camount", true);
				if ( _camount != value )
				{
					_camount = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Ctype
		{
			get
			{
                CanReadProperty("Ctype", true);
				return _ctype;
			}
			set
			{
                CanWriteProperty("Ctype", true);
				if ( _ctype != value )
				{
					_ctype = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? CSort
		{
			get
			{
                CanReadProperty("CSort", true);
				return _c_sort;
			}
			set
			{
                CanWriteProperty("CSort", true);
				if ( _c_sort != value )
				{
					_c_sort = value;
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
		public static ContractSummaryPayments NewContractSummaryPayments( int? contract, int? renewal )
		{
			return Create(contract, renewal);
		}

		public static ContractSummaryPayments[] GetAllContractSummaryPayments( int? contract, int? renewal )
		{
			return Fetch(contract, renewal).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? contract, int? renewal )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_Contract_Payments";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContract", contract);
					pList.Add(cm, "inRenewal", renewal);

					List<ContractSummaryPayments> _list = new List<ContractSummaryPayments>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractSummaryPayments instance = new ContractSummaryPayments();
                            instance._camount = GetValueFromReader<decimal?>(dr,0);
                            instance._ctype = GetValueFromReader<string>(dr,1);
                            instance._c_sort = GetValueFromReader<int?>(dr,2);
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
