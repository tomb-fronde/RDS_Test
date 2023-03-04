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
	[MapInfo("contractor_supplier_no", "_contractor_supplier_no", "contractor")]
	[MapInfo("c_surname_company", "_c_surname_company", "contractor")]
	[MapInfo("c_first_names", "_c_first_names", "contractor")]
	[System.Serializable()]

	public class QsContractorList : Entity<QsContractorList>
	{
		#region Business Methods
		[DBField()]
		private int?  _contractor_supplier_no;

		[DBField()]
		private string  _c_surname_company;

		[DBField()]
		private string  _c_first_names;


		public virtual int? ContractorSupplierNo
		{
			get
			{
                CanReadProperty("ContractorSupplierNo", true);
				return _contractor_supplier_no;
			}
			set
			{
                CanWriteProperty("ContractorSupplierNo", true);
				if ( _contractor_supplier_no != value )
				{
					_contractor_supplier_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CSurnameCompany
		{
			get
			{
                CanReadProperty("CSurnameCompany", true);
				return _c_surname_company;
			}
			set
			{
                CanWriteProperty("CSurnameCompany", true);
				if ( _c_surname_company != value )
				{
					_c_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CFirstNames
		{
			get
			{
                CanReadProperty("CFirstNames", true);
				return _c_first_names;
			}
			set
			{
                CanWriteProperty("CFirstNames", true);
				if ( _c_first_names != value )
				{
					_c_first_names = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[contractor_name]
			//c_surname_company + if(isnull( c_first_names ), '', ', ' +  c_first_names )
        public virtual string ContractorName
        {
            get
            {
                CanReadProperty("ContractorName", true);
                return _c_surname_company.Trim() + (_c_first_names == null ? "" : ", " + _c_first_names.Trim());
            }
        }

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _contractor_supplier_no );
		}
		#endregion

		#region Factory Methods
		public static QsContractorList NewQsContractorList( int? supplierno, string suppliername )
		{
			return Create(supplierno, suppliername);
		}

		public static QsContractorList[] GetAllQsContractorList( int? supplierno, string suppliername )
		{
			return Fetch(supplierno, suppliername).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? supplierno, string suppliername )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "supplierno", supplierno);
                    if (suppliername == null)
                        suppliername = "";
					pList.Add(cm, "suppliername", suppliername);
                    cm.CommandText = "  SELECT contractor.contractor_supplier_no,   " +
                        "contractor.c_surname_company,   " +
                        "contractor.c_first_names  " +
                        "FROM contractor  " +
                        "WHERE (@supplierno is null OR  " +
                        "contractor.contractor_supplier_no = @supplierno) AND  " +
                        "(@suppliername is null OR  " +
                        "contractor.c_surname_company like @suppliername + '%' )   " +
                        "ORDER BY contractor.c_surname_company ASC,   " +
                        "contractor.c_first_names ASC   ";

					List<QsContractorList> _list = new List<QsContractorList>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							QsContractorList instance = new QsContractorList();
                            instance._contractor_supplier_no = GetValueFromReader<Int32?>(dr,0);
                            instance._c_surname_company = GetValueFromReader<String>(dr,1);
                            instance._c_first_names = GetValueFromReader<String>(dr,2);

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
				if (GenerateUpdateCommandText(cm, "contractor", ref pList))
				{
					cm.CommandText += " WHERE  contractor.contractor_supplier_no = @contractor_supplier_no ";

					pList.Add(cm, "contractor_supplier_no", GetInitialValue("_contractor_supplier_no"));
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
				if (GenerateInsertCommandText(cm, "contractor", pList))
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
					pList.Add(cm,"contractor_supplier_no", GetInitialValue("_contractor_supplier_no"));
						cm.CommandText = "DELETE FROM contractor WHERE " +
						"contractor.contractor_supplier_no = @contractor_supplier_no ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? contractor_supplier_no )
		{
			_contractor_supplier_no = contractor_supplier_no;
		}
	}
}
