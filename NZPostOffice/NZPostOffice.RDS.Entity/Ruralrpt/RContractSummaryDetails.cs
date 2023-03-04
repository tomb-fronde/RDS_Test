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
	[MapInfo("con_old_mail_service_no", "_con_old_mail_service_no", "")]
	[MapInfo("con_title", "_con_title", "")]
	[MapInfo("con_renewal_payment_value", "_con_renewal_payment_value", "")]
	[MapInfo("rgn_name", "_rgn_name", "")]
	[MapInfo("rgn_rcm_manager", "_rgn_rcm_manager", "")]
	[MapInfo("rgn_telephone", "_rgn_telephone", "")]
	[MapInfo("o_name", "_o_name", "")]
	[MapInfo("con_start_date", "_con_start_date", "")]
	[MapInfo("con_expiry_date", "_con_expiry_date", "")]
	[MapInfo("con_last_work_msrmnt_check", "_con_last_work_msrmnt_check", "")]
	[MapInfo("con_last_delivery_check", "_con_last_delivery_check", "")]
	[MapInfo("ext_amt", "_ext_amt", "")]
	[MapInfo("lodgement", "_lodgement", "")]
	[MapInfo("con_active_sequence", "_con_active_sequence", "")]
	[MapInfo("con_rcm_paper_file_text", "_con_rcm_paper_file_text", "")]
	[MapInfo("con_rd_ref_text", "_con_rd_ref_text", "")]
	[MapInfo("con_rd_paper_file_text", "_con_rd_paper_file_text", "")]
	[MapInfo("con_acceptance_flag", "_con_acceptance_flag", "")]
	[MapInfo("lastdate", "_lastdate", "")]
	[System.Serializable()]

	public class ContractSummaryDetails : Entity<ContractSummaryDetails>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _con_old_mail_service_no;

		[DBField()]
		private string  _con_title;

		[DBField()]
		private decimal?  _con_renewal_payment_value;

		[DBField()]
		private string  _rgn_name;

		[DBField()]
		private string  _rgn_rcm_manager;

		[DBField()]
		private string  _rgn_telephone;

		[DBField()]
		private string  _o_name;

		[DBField()]
		private DateTime?  _con_start_date;

		[DBField()]
		private DateTime?  _con_expiry_date;

		[DBField()]
		private DateTime?  _con_last_work_msrmnt_check;

		[DBField()]
		private DateTime?  _con_last_delivery_check;

		[DBField()]
		private decimal?  _ext_amt;

		[DBField()]
		private string  _lodgement;

		[DBField()]
		private int?  _con_active_sequence;

		[DBField()]
		private string  _con_rcm_paper_file_text;

		[DBField()]
		private string  _con_rd_ref_text;

		[DBField()]
		private string  _con_rd_paper_file_text;

		[DBField()]
		private string  _con_acceptance_flag;

		[DBField()]
		private DateTime?  _lastdate;


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

		public virtual string ConOldMailServiceNo
		{
			get
			{
                CanReadProperty("ConOldMailServiceNo", true);
				return _con_old_mail_service_no;
			}
			set
			{
                CanWriteProperty("ConOldMailServiceNo", true);
				if ( _con_old_mail_service_no != value )
				{
					_con_old_mail_service_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ConTitle
		{
			get
			{
                CanReadProperty("ConTitle", true);
				return _con_title;
			}
			set
			{
                CanWriteProperty("ConTitle", true);
				if ( _con_title != value )
				{
					_con_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? ConRenewalPaymentValue
		{
			get
			{
                CanReadProperty("ConRenewalPaymentValue", true);
				return _con_renewal_payment_value;
			}
			set
			{
                CanWriteProperty("ConRenewalPaymentValue", true);
				if ( _con_renewal_payment_value != value )
				{
					_con_renewal_payment_value = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgnName
		{
			get
			{
                CanReadProperty("RgnName", true);
				return _rgn_name;
			}
			set
			{
                CanWriteProperty("RgnName", true);
				if ( _rgn_name != value )
				{
					_rgn_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgnRcmManager
		{
			get
			{
                CanReadProperty("RgnRcmManager", true);
				return _rgn_rcm_manager;
			}
			set
			{
                CanWriteProperty("RgnRcmManager", true);
				if ( _rgn_rcm_manager != value )
				{
					_rgn_rcm_manager = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgnTelephone
		{
			get
			{
                CanReadProperty("RgnTelephone", true);
				return _rgn_telephone;
			}
			set
			{
                CanWriteProperty("RgnTelephone", true);
				if ( _rgn_telephone != value )
				{
					_rgn_telephone = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OName
		{
			get
			{
                CanReadProperty("OName", true);
				return _o_name;
			}
			set
			{
                CanWriteProperty("OName", true);
				if ( _o_name != value )
				{
					_o_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? ConStartDate
		{
			get
			{
                CanReadProperty("ConStartDate", true);
				return _con_start_date;
			}
			set
			{
                CanWriteProperty("ConStartDate", true);
				if ( _con_start_date != value )
				{
					_con_start_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? ConExpiryDate
		{
			get
			{
                CanReadProperty("ConExpiryDate", true);
				return _con_expiry_date;
			}
			set
			{
                CanWriteProperty("ConExpiryDate", true);
				if ( _con_expiry_date != value )
				{
					_con_expiry_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? ConLastWorkMsrmntCheck
		{
			get
			{
                CanReadProperty("ConLastWorkMsrmntCheck", true);
				return _con_last_work_msrmnt_check;
			}
			set
			{
                CanWriteProperty("ConLastWorkMsrmntCheck", true);
				if ( _con_last_work_msrmnt_check != value )
				{
					_con_last_work_msrmnt_check = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? ConLastDeliveryCheck
		{
			get
			{
                CanReadProperty("ConLastDeliveryCheck", true);
				return _con_last_delivery_check;
			}
			set
			{
                CanWriteProperty("ConLastDeliveryCheck", true);
				if ( _con_last_delivery_check != value )
				{
					_con_last_delivery_check = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? ExtAmt
		{
			get
			{
                CanReadProperty("ExtAmt", true);
				return _ext_amt;
			}
			set
			{
                CanWriteProperty("ExtAmt", true);
				if ( _ext_amt != value )
				{
					_ext_amt = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Lodgement
		{
			get
			{
                CanReadProperty("Lodgement", true);
				return _lodgement;
			}
			set
			{
                CanWriteProperty("Lodgement", true);
				if ( _lodgement != value )
				{
					_lodgement = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ConActiveSequence
		{
			get
			{
                CanReadProperty("ConActiveSequence", true);
				return _con_active_sequence;
			}
			set
			{
                CanWriteProperty("ConActiveSequence", true);
				if ( _con_active_sequence != value )
				{
					_con_active_sequence = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ConRcmPaperFileText
		{
			get
			{
                CanReadProperty("ConRcmPaperFileText", true);
				return _con_rcm_paper_file_text;
			}
			set
			{
                CanWriteProperty("ConRcmPaperFileText", true);
				if ( _con_rcm_paper_file_text != value )
				{
					_con_rcm_paper_file_text = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ConRdRefText
		{
			get
			{
                CanReadProperty("ConRdRefText", true);
				return _con_rd_ref_text;
			}
			set
			{
                CanWriteProperty("ConRdRefText", true);
				if ( _con_rd_ref_text != value )
				{
					_con_rd_ref_text = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ConRdPaperFileText
		{
			get
			{
                CanReadProperty("ConRdPaperFileText", true);
				return _con_rd_paper_file_text;
			}
			set
			{
                CanWriteProperty("ConRdPaperFileText", true);
				if ( _con_rd_paper_file_text != value )
				{
					_con_rd_paper_file_text = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ConAcceptanceFlag
		{
			get
			{
                CanReadProperty("ConAcceptanceFlag", true);
				return _con_acceptance_flag;
			}
			set
			{
                CanWriteProperty("ConAcceptanceFlag", true);
				if ( _con_acceptance_flag != value )
				{
					_con_acceptance_flag = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? Lastdate
		{
			get
			{
                CanReadProperty("Lastdate", true);
				return _lastdate;
			}
			set
			{
                CanWriteProperty("Lastdate", true);
				if ( _lastdate != value )
				{
					_lastdate = value;
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
		public static ContractSummaryDetails NewContractSummaryDetails( int? inContract, int? inSequence )
		{
			return Create(inContract, inSequence);
		}

		public static ContractSummaryDetails[] GetAllContractSummaryDetails( int? inContract, int? inSequence )
		{
			return Fetch(inContract, inSequence).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inContract, int? inSequence )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_contractsummarydetails";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContract", inContract);
					pList.Add(cm, "inSequence", inSequence);

					List<ContractSummaryDetails> _list = new List<ContractSummaryDetails>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractSummaryDetails instance = new ContractSummaryDetails();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
                            instance._con_old_mail_service_no = GetValueFromReader<string>(dr,1);
                            instance._con_title = GetValueFromReader<string>(dr,2);
                            instance._con_renewal_payment_value = GetValueFromReader<decimal?>(dr,3);
                            instance._rgn_name = GetValueFromReader<string>(dr,4);
                            instance._rgn_rcm_manager = GetValueFromReader<string>(dr,5);
                            instance._rgn_telephone = GetValueFromReader<string>(dr,6);
                            instance._o_name = GetValueFromReader<string>(dr,7);
                            instance._con_start_date = GetValueFromReader<DateTime?>(dr,8);
                            instance._con_expiry_date = GetValueFromReader<DateTime?>(dr,9);
                            instance._con_last_work_msrmnt_check = GetValueFromReader<DateTime?>(dr,10);
                            instance._con_last_delivery_check = GetValueFromReader<DateTime?>(dr,11);
                            instance._ext_amt = GetValueFromReader<decimal?>(dr,12);
                            instance._lodgement = GetValueFromReader<string>(dr,13);
                            instance._con_active_sequence = GetValueFromReader<int?>(dr,14);
                            instance._con_rcm_paper_file_text = GetValueFromReader<string>(dr,15);
                            instance._con_rd_ref_text = GetValueFromReader<string>(dr,16);
                            instance._con_rd_paper_file_text = GetValueFromReader<string>(dr,17);
                            instance._con_acceptance_flag = GetValueFromReader<string>(dr,18);
                            instance._lastdate = GetValueFromReader<DateTime?>(dr,19);
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
