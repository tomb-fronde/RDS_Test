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
	[MapInfo("ded_id", "_ded_id", "post_tax_deductions")]
	[MapInfo("ded_description", "_ded_description", "post_tax_deductions")]
	[MapInfo("ded_reference", "_ded_reference", "post_tax_deductions")]
	[MapInfo("ded_type_period", "_ded_type_period", "post_tax_deductions")]
	[MapInfo("ded_start_balance", "_ded_start_balance", "post_tax_deductions")]
	[MapInfo("ded_end_balance", "_ded_end_balance", "post_tax_deductions",true)]
	[System.Serializable()]

	public class AllPostTaxDeductions : Entity<AllPostTaxDeductions>
	{
		#region Business Methods
		[DBField()]
		private int?  _ded_id;

		[DBField()]
		private string  _ded_description;

		[DBField()]
		private string  _ded_reference;

		[DBField()]
		private string  _ded_type_period;

		[DBField()]
		private decimal?  _ded_start_balance;

		[DBField()]
		private decimal?  _ded_end_balance;


		public virtual int? DedId
		{
			get
			{
                CanReadProperty("DedId", true);
				return _ded_id;
			}
			set
			{
                CanWriteProperty("DedId", true);
				if ( _ded_id != value )
				{
					_ded_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string DedDescription
		{
			get
			{
                CanReadProperty("DedDescription", true);
				return _ded_description;
			}
			set
			{
                CanWriteProperty("DedDescription", true);
				if ( _ded_description != value )
				{
					_ded_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string DedReference
		{
			get
			{
                CanReadProperty("DedReference", true);
				return _ded_reference;
			}
			set
			{
                CanWriteProperty("DedReference", true);
				if ( _ded_reference != value )
				{
					_ded_reference = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string DedTypePeriod
		{
			get
			{
                CanReadProperty("DedTypePeriod", true);
				return _ded_type_period;
			}
			set
			{
                CanWriteProperty("DedTypePeriod", true);
				if ( _ded_type_period != value )
				{
					_ded_type_period = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? DedStartBalance
		{
			get
			{
                CanReadProperty("DedStartBalance", true);
				return _ded_start_balance;
			}
			set
			{
                CanWriteProperty("DedStartBalance", true);
				if ( _ded_start_balance != value )
				{
					_ded_start_balance = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? DedEndBalance
		{
			get
			{
                CanReadProperty("DedEndBalance", true);
				return _ded_end_balance;
			}
			set
			{
                CanWriteProperty("DedEndBalance", true);
				if ( _ded_end_balance != value )
				{
					_ded_end_balance = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _ded_id );
		}
		#endregion

		#region Factory Methods
		public static AllPostTaxDeductions NewAllPostTaxDeductions( int? as_contractor_supplier_no )
		{
			return Create(as_contractor_supplier_no);
		}

		public static AllPostTaxDeductions[] GetAllAllPostTaxDeductions( int? as_contractor_supplier_no )
		{
			return Fetch(as_contractor_supplier_no).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? as_contractor_supplier_no )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT ded_id,  ded_description,  ded_reference,  ded_type_period,  ded_start_balance,  ded_end_balance  FROM odps.post_tax_deductions  WHERE contractor_supplier_no = @as_contractor_supplier_no  ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "as_contractor_supplier_no", as_contractor_supplier_no);

					List<AllPostTaxDeductions> _list = new List<AllPostTaxDeductions>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							AllPostTaxDeductions instance = new AllPostTaxDeductions();
                            instance._ded_id = GetValueFromReader<Int32?>(dr,0);
                            instance._ded_description = GetValueFromReader<String>(dr,1);
                            instance._ded_reference = GetValueFromReader<String>(dr,2);
                            instance._ded_type_period = GetValueFromReader<String>(dr,3);
                            instance._ded_start_balance = GetValueFromReader<Decimal?>(dr,4);
                            instance._ded_end_balance = GetValueFromReader<Decimal?>(dr,5);
                            
							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
						list = _list.ToArray();
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
				if (GenerateUpdateCommandText(cm, "odps.post_tax_deductions", ref pList))
				{
					cm.CommandText += " WHERE  odps.post_tax_deductions.ded_id = @ded_id ";

					pList.Add(cm, "ded_id", GetInitialValue("_ded_id"));
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "odps.post_tax_deductions", pList))
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
					pList.Add(cm,"ded_id", GetInitialValue("_ded_id"));
						cm.CommandText = "DELETE FROM odps.post_tax_deductions WHERE " +
						"odps.post_tax_deductions.ded_id = @ded_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? ded_id )
		{
			_ded_id = ded_id;
		}
	}
}
