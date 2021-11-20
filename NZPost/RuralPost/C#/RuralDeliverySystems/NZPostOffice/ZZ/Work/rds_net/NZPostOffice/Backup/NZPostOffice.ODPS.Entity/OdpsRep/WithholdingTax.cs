using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsRep
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("c_surname_company", "_c_surname_company", "")]
	[MapInfo("c_first_names", "_c_first_names", "")]
	[MapInfo("c_initials", "_c_initials", "")]
	[MapInfo("pbu_code", "_pbu_code", "")]
	[MapInfo("ac_code", "_ac_code", "")]
	[MapInfo("amount", "_amount", "")]
	[MapInfo("yearamount", "_yearamount", "")]
	[System.Serializable()]

	public class WithholdingTax : Entity<WithholdingTax>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _c_surname_company;

		[DBField()]
		private string  _c_first_names;

		[DBField()]
		private string  _c_initials;

		[DBField()]
		private string  _pbu_code;

		[DBField()]
		private string  _ac_code;

		[DBField()]
		private decimal?  _amount;

		[DBField()]
		private decimal?  _yearamount;

		public virtual int? ContractNo
		{
			get
			{
				CanReadProperty("ContractNo",true);
				return _contract_no;
			}
			set
			{
				CanWriteProperty("ContractNo",true);
				if ( _contract_no != value )
				{
					_contract_no = value;
					PropertyHasChanged();
				}
			}
		}

        public int REContractNo
        {
            get
            {
                return 0;// (int)_contract_no;
            }
        }

		public virtual string CSurnameCompany
		{
			get
			{
				CanReadProperty("CSurnameCompany",true);
				return _c_surname_company;
			}
			set
			{
				CanWriteProperty("CSurnameCompany",true);
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
				CanReadProperty("CFirstNames",true);
				return _c_first_names;
			}
			set
			{
				CanWriteProperty("CFirstNames",true);
				if ( _c_first_names != value )
				{
					_c_first_names = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CInitials
		{
			get
			{
				CanReadProperty("CInitials",true);
				return _c_initials;
			}
			set
			{
				CanWriteProperty("CInitials",true);
				if ( _c_initials != value )
				{
					_c_initials = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PbuCode
		{
			get
			{
				CanReadProperty("PbuCode",true);
				return _pbu_code;
			}
			set
			{
				CanWriteProperty("PbuCode",true);
				if ( _pbu_code != value )
				{
					_pbu_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AcCode
		{
			get
			{
				CanReadProperty("AcCode",true);
				return _ac_code;
			}
			set
			{
				CanWriteProperty("AcCode",true);
				if ( _ac_code != value )
				{
					_ac_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Amount
		{
			get
			{
				CanReadProperty("Amount",true);
				return _amount;
			}
			set
			{
				CanWriteProperty("Amount",true);
				if ( _amount != value )
				{
					_amount = value;
					PropertyHasChanged();
				}
			}
		}

        public decimal REAmount
        {
            get
            {
                return 0m;// (decimal)Amount;
            }
        }

		public virtual decimal? Yearamount
		{
			get
			{
				CanReadProperty("Yearamount",true);
				return _yearamount;
			}
			set
			{
				CanWriteProperty("Yearamount",true);
				if ( _yearamount != value )
				{
					_yearamount = value;
					PropertyHasChanged();
				}
			}
		}

        public decimal REYearamount
        {
            get
            {
                return 0m; //(decimal)_yearamount;
            }
        }

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static WithholdingTax NewWithholdingTax( DateTime? sdate, DateTime? edate, DateTime? fin_sdate, DateTime? fin_edate )
		{
			return Create(sdate, edate, fin_sdate, fin_edate);
		}

		public static WithholdingTax[] GetAllWithholdingTax( DateTime? sdate, DateTime? edate, DateTime? fin_sdate, DateTime? fin_edate )
		{
			return Fetch(sdate, edate, fin_sdate, fin_edate).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( DateTime? sdate, DateTime? edate, DateTime? fin_sdate, DateTime? fin_edate )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_withholdingtax";
                    cm.CommandTimeout = 180;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "sdate", sdate);
					pList.Add(cm, "edate", edate);
					pList.Add(cm, "fin_sdate", fin_sdate);
					pList.Add(cm, "fin_edate", fin_edate);

					List<WithholdingTax> _list = new List<WithholdingTax>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							WithholdingTax instance = new WithholdingTax();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._c_surname_company = GetValueFromReader<string>(dr, 1);
                            instance._c_first_names = GetValueFromReader<string>(dr, 2);
                            instance._c_initials = GetValueFromReader<string>(dr, 3);
                            instance._pbu_code = GetValueFromReader<string>(dr, 4);
                            instance._ac_code = GetValueFromReader<string>(dr, 5);
                            instance._amount = GetValueFromReader<decimal?>(dr, 6);
                            instance._yearamount = GetValueFromReader<decimal?>(dr, 7);
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
