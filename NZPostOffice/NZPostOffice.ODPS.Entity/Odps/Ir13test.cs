using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.Odps
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("employee_full_name", "_employee_full_name", "")]
	[MapInfo("employee_address", "_employee_address", "")]
	[MapInfo("occupation", "_occupation", "")]
	[MapInfo("allowance_tax_free_type", "_allowance_tax_free_type", "")]
	[MapInfo("allowance_tax_free_amounts", "_allowance_tax_free_amounts", "")]
	[MapInfo("employer_full_name", "_employer_full_name", "")]
	[MapInfo("employer_full_address", "_employer_full_address", "")]
	[MapInfo("employer_trade_name", "_employer_trade_name", "")]
	[MapInfo("name_of_payer", "_name_of_payer", "")]
	[MapInfo("date_signed", "_date_signed", "")]
	[MapInfo("period_start_date", "_period_start_date", "")]
	[MapInfo("period_end_date", "_period_end_date", "")]
	[MapInfo("ird_number", "_ird_number", "")]
	[MapInfo("tax_code", "_tax_code", "")]
	[MapInfo("extra_pays", "_extra_pays", "")]
	[MapInfo("total_paye_deduction", "_total_paye_deduction", "")]
	[MapInfo("earnings_liable_for_premium", "_earnings_liable_for_premium", "")]
	[MapInfo("acc_earner_premium", "_acc_earner_premium", "")]
	[MapInfo("tax_deductions", "_tax_deductions", "")]
	[MapInfo("gross_earnings", "_gross_earnings", "")]
	[MapInfo("student_loan_repayment", "_student_loan_repayment", "")]
	[MapInfo("employer_ird_number", "_employer_ird_number", "")]
	[MapInfo("start_date", "_start_date", "")]
	[MapInfo("end_date", "_end_date", "")]
	[System.Serializable()]

	public class Ir13test : Entity<Ir13test>
	{
		#region Business Methods
		[DBField()]
		private string  _employee_full_name;

		[DBField()]
		private string  _employee_address;

		[DBField()]
		private string  _occupation;

		[DBField()]
		private string  _allowance_tax_free_type;

		[DBField()]
		private string  _allowance_tax_free_amounts;

		[DBField()]
		private string  _employer_full_name;

		[DBField()]
		private string  _employer_full_address;

		[DBField()]
		private string  _employer_trade_name;

		[DBField()]
		private string  _name_of_payer;

		[DBField()]
		private string  _date_signed;

		[DBField()]
		private string  _period_start_date;

		[DBField()]
		private string  _period_end_date;

		[DBField()]
		private string  _ird_number;

		[DBField()]
		private string  _tax_code;

		[DBField()]
		private string  _extra_pays;

		[DBField()]
		private decimal?  _total_paye_deduction;

		[DBField()]
		private decimal?  _earnings_liable_for_premium;

		[DBField()]
		private decimal?  _acc_earner_premium;

		[DBField()]
		private decimal?  _tax_deductions;

		[DBField()]
		private decimal?  _gross_earnings;

		[DBField()]
		private string  _student_loan_repayment;

		[DBField()]
		private string  _employer_ird_number;

		[DBField()]
		private string  _start_date;

		[DBField()]
		private string  _end_date;

		public virtual string EmployeeFullName
		{
			get
			{
				CanReadProperty("EmployeeFullName",true);
				return _employee_full_name;
			}
			set
			{
				CanWriteProperty("EmployeeFullName",true);
				if ( _employee_full_name != value )
				{
					_employee_full_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string EmployeeAddress
		{
			get
			{
				CanReadProperty("EmployeeAddress",true);
				return _employee_address;
			}
			set
			{
				CanWriteProperty("EmployeeAddress",true);
				if ( _employee_address != value )
				{
					_employee_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Occupation
		{
			get
			{
				CanReadProperty("Occupation",true);
				return _occupation;
			}
			set
			{
				CanWriteProperty("Occupation",true);
				if ( _occupation != value )
				{
					_occupation = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AllowanceTaxFreeType
		{
			get
			{
				CanReadProperty("AllowanceTaxFreeType",true);
				return _allowance_tax_free_type;
			}
			set
			{
				CanWriteProperty("AllowanceTaxFreeType",true);
				if ( _allowance_tax_free_type != value )
				{
					_allowance_tax_free_type = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AllowanceTaxFreeAmounts
		{
			get
			{
				CanReadProperty("AllowanceTaxFreeAmounts",true);
				return _allowance_tax_free_amounts;
			}
			set
			{
				CanWriteProperty("AllowanceTaxFreeAmounts",true);
				if ( _allowance_tax_free_amounts != value )
				{
					_allowance_tax_free_amounts = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string EmployerFullName
		{
			get
			{
				CanReadProperty("EmployerFullName",true);
				return _employer_full_name;
			}
			set
			{
				CanWriteProperty("EmployerFullName",true);
				if ( _employer_full_name != value )
				{
					_employer_full_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string EmployerFullAddress
		{
			get
			{
				CanReadProperty("EmployerFullAddress",true);
				return _employer_full_address;
			}
			set
			{
				CanWriteProperty("EmployerFullAddress",true);
				if ( _employer_full_address != value )
				{
					_employer_full_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string EmployerTradeName
		{
			get
			{
				CanReadProperty("EmployerTradeName",true);
				return _employer_trade_name;
			}
			set
			{
				CanWriteProperty("EmployerTradeName",true);
				if ( _employer_trade_name != value )
				{
					_employer_trade_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string NameOfPayer
		{
			get
			{
				CanReadProperty("NameOfPayer",true);
				return _name_of_payer;
			}
			set
			{
				CanWriteProperty("NameOfPayer",true);
				if ( _name_of_payer != value )
				{
					_name_of_payer = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string DateSigned
		{
			get
			{
				CanReadProperty("DateSigned",true);
				return _date_signed;
			}
			set
			{
				CanWriteProperty("DateSigned",true);
				if ( _date_signed != value )
				{
					_date_signed = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PeriodStartDate
		{
			get
			{
				CanReadProperty("PeriodStartDate",true);
				return _period_start_date;
			}
			set
			{
				CanWriteProperty("PeriodStartDate",true);
				if ( _period_start_date != value )
				{
					_period_start_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PeriodEndDate
		{
			get
			{
				CanReadProperty("PeriodEndDate",true);
				return _period_end_date;
			}
			set
			{
				CanWriteProperty("PeriodEndDate",true);
				if ( _period_end_date != value )
				{
					_period_end_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string IrdNumber
		{
			get
			{
				CanReadProperty("IrdNumber",true);
				return _ird_number;
			}
			set
			{
				CanWriteProperty("IrdNumber",true);
				if ( _ird_number != value )
				{
					_ird_number = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string TaxCode
		{
			get
			{
				CanReadProperty("TaxCode",true);
				return _tax_code;
			}
			set
			{
				CanWriteProperty("TaxCode",true);
				if ( _tax_code != value )
				{
					_tax_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ExtraPays
		{
			get
			{
				CanReadProperty("ExtraPays",true);
				return _extra_pays;
			}
			set
			{
				CanWriteProperty("ExtraPays",true);
				if ( _extra_pays != value )
				{
					_extra_pays = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? TotalPayeDeduction
		{
			get
			{
				CanReadProperty("TotalPayeDeduction",true);
				return _total_paye_deduction;
			}
			set
			{
				CanWriteProperty("TotalPayeDeduction",true);
				if ( _total_paye_deduction != value )
				{
					_total_paye_deduction = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? EarningsLiableForPremium
		{
			get
			{
				CanReadProperty("EarningsLiableForPremium",true);
				return _earnings_liable_for_premium;
			}
			set
			{
				CanWriteProperty("EarningsLiableForPremium",true);
				if ( _earnings_liable_for_premium != value )
				{
					_earnings_liable_for_premium = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? AccEarnerPremium
		{
			get
			{
				CanReadProperty("AccEarnerPremium",true);
				return _acc_earner_premium;
			}
			set
			{
				CanWriteProperty("AccEarnerPremium",true);
				if ( _acc_earner_premium != value )
				{
					_acc_earner_premium = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? TaxDeductions
		{
			get
			{
				CanReadProperty("TaxDeductions",true);
				return _tax_deductions;
			}
			set
			{
				CanWriteProperty("TaxDeductions",true);
				if ( _tax_deductions != value )
				{
					_tax_deductions = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? GrossEarnings
		{
			get
			{
				CanReadProperty("GrossEarnings",true);
				return _gross_earnings;
			}
			set
			{
				CanWriteProperty("GrossEarnings",true);
				if ( _gross_earnings != value )
				{
					_gross_earnings = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string StudentLoanRepayment
		{
			get
			{
				CanReadProperty("StudentLoanRepayment",true);
				return _student_loan_repayment;
			}
			set
			{
				CanWriteProperty("StudentLoanRepayment",true);
				if ( _student_loan_repayment != value )
				{
					_student_loan_repayment = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string EmployerIrdNumber
		{
			get
			{
				CanReadProperty("EmployerIrdNumber",true);
				return _employer_ird_number;
			}
			set
			{
				CanWriteProperty("EmployerIrdNumber",true);
				if ( _employer_ird_number != value )
				{
					_employer_ird_number = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string StartDate
		{
			get
			{
				CanReadProperty("StartDate",true);
				return _start_date;
			}
			set
			{
				CanWriteProperty("StartDate",true);
				if ( _start_date != value )
				{
					_start_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string EndDate
		{
			get
			{
				CanReadProperty("EndDate",true);
				return _end_date;
			}
			set
			{
				CanWriteProperty("EndDate",true);
				if ( _end_date != value )
				{
					_end_date = value;
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
		public static Ir13test New(  )
		{
			return Create();
		}

		public static Ir13test[] GetAll(  )
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
                    cm.CommandText = "odps.od_rps_ir13";
					ParameterCollection pList = new ParameterCollection();

					List<Ir13test> _list = new List<Ir13test>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							Ir13test instance = new Ir13test();
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
