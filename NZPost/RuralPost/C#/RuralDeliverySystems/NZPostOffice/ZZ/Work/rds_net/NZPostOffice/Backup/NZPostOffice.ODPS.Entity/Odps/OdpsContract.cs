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
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("ac_id", "_ac_id", "")]
	[MapInfo("pbu_id", "_pbu_id", "")]
	[MapInfo("message_for_invoice", "_message_for_invoice", "")]
	[MapInfo("con_title", "_con_title", "")]
	[MapInfo("c_surname_company", "_c_surname_company", "")]
	[MapInfo("c_first_names", "_c_first_names", "")]
	[System.Serializable()]

	public class OdpsContract : Entity<OdpsContract>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _ac_id;

		[DBField()]
		private int?  _pbu_id;

		[DBField()]
		private string  _message_for_invoice;

		[DBField()]
		private string  _con_title;

		[DBField()]
		private string  _c_surname_company;

		[DBField()]
		private string  _c_first_names;

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

		public virtual int? AcId
		{
			get
			{
				CanReadProperty("AcId",true);
				return _ac_id;
			}
			set
			{
				CanWriteProperty("AcId",true);
				if ( _ac_id != value )
				{
					_ac_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? PbuId
		{
			get
			{
				CanReadProperty("PbuId",true);
				return _pbu_id;
			}
			set
			{
                CanWriteProperty("PbuId", true);
				if ( _pbu_id != value )
				{
					_pbu_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string MessageForInvoice
		{
			get
			{
				CanReadProperty("MessageForInvoice",true);
				return _message_for_invoice;
			}
			set
			{
				CanWriteProperty("MessageForInvoice",true);
				if ( _message_for_invoice != value )
				{
					_message_for_invoice = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ConTitle
		{
			get
			{
				CanReadProperty("ConTitle",true);
				return _con_title;
			}
			set
			{
				CanWriteProperty("ConTitle",true);
				if ( _con_title != value )
				{
					_con_title = value;
					PropertyHasChanged();
				}
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

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _contract_no );
		}
		#endregion

		#region Factory Methods
		public static OdpsContract NewOdpsContract( int? in_Contract )
		{
			return Create(in_Contract);
		}

		public static OdpsContract[] GetAllOdpsContract( int? in_Contract )
		{
			return Fetch(in_Contract).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_Contract )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.sp_odps_getcontract";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_Contract", in_Contract);

					List<OdpsContract> _list = new List<OdpsContract>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							OdpsContract instance = new OdpsContract();
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
		private void CreateEntity( int? contract_no )
		{
			_contract_no = contract_no;
		}
	}
}
