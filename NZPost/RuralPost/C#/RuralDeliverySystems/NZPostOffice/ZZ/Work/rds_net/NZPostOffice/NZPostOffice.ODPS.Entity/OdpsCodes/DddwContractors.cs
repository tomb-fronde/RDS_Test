//qtdong
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsCodes
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contractor_supplier_no", "_contractor_supplier_no", "")]
	[MapInfo("contractor_name", "_contractor_name", "")]
	[System.Serializable()]

	public class DddwContractors : Entity<DddwContractors>
	{
		#region Business Methods
		[DBField()]
		private int?  _contractor_supplier_no;

		[DBField()]
		private string  _contractor_name;

		public virtual int? ContractorSupplierNo
		{
			get
			{
				CanReadProperty("ContractorSupplierNo",true);
				return _contractor_supplier_no;
			}
			set
			{
				CanWriteProperty("ContractorSupplierNo",true);
				if ( _contractor_supplier_no != value )
				{
					_contractor_supplier_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorName
		{
			get
			{
				CanReadProperty(true);
				return _contractor_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _contractor_name != value )
				{
					_contractor_name = value;
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
		public static DddwContractors NewDddwContractors(  )
		{
			return Create();
		}

		public static DddwContractors[] GetAllDddwContractors(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_dws_contractorlist";
					ParameterCollection pList = new ParameterCollection();

					List<DddwContractors> _list = new List<DddwContractors>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwContractors instance = new DddwContractors();
                            instance.ContractorSupplierNo =GetValueFromReader<Int32?>(dr,0);
                            instance.ContractorName = GetValueFromReader<string>(dr,1);
                            instance.StoreInitialValues();
                            instance.MarkOld();
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
