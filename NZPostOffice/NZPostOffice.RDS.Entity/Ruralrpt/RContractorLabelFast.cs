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
	[MapInfo("c_title", "_c_title", "")]
	[MapInfo("c_surname_company", "_c_surname_company", "")]
	[MapInfo("c_first_names", "_c_first_names", "")]
	[MapInfo("c_initials", "_c_initials", "")]
	[MapInfo("c_address", "_c_address", "")]
	[MapInfo("label", "_label", "")]
	[System.Serializable()]

	public class ContractorLabelFast : Entity<ContractorLabelFast>
	{
		#region Business Methods
		[DBField()]
		private string  _c_title;

		[DBField()]
		private string  _c_surname_company;

		[DBField()]
		private string  _c_first_names;

		[DBField()]
		private string  _c_initials;

		[DBField()]
		private string  _c_address;

		[DBField()]
		private string  _label;


		public virtual string CTitle
		{
			get
			{
                CanReadProperty("CTitle", true);
				return _c_title;
			}
			set
			{
                CanWriteProperty("CTitle", true);
				if ( _c_title != value )
				{
					_c_title = value;
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

		public virtual string CInitials
		{
			get
			{
                CanReadProperty("CInitials", true);
				return _c_initials;
			}
			set
			{
                CanWriteProperty("CInitials", true);
				if ( _c_initials != value )
				{
					_c_initials = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CAddress
		{
			get
			{
                CanReadProperty("CAddress", true);
				return _c_address;
			}
			set
			{
                CanWriteProperty("CAddress", true);
				if ( _c_address != value )
				{
					_c_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Label
		{
			get
			{
                CanReadProperty("Label", true);
				return _label;
			}
			set
			{
                CanWriteProperty("Label", true);
				if ( _label != value )
				{
					_label = value;
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
		public static ContractorLabelFast NewContractorLabelFast( int? inregion, string incontractor, int? incontracttype, int? inrengroup, int? inoutlet, int? incontracts, string incontractflag )
		{
			return Create(inregion, incontractor, incontracttype, inrengroup, inoutlet, incontracts, incontractflag);
		}

		public static ContractorLabelFast[] GetAllContractorLabelFast( int? inregion, string incontractor, int? incontracttype, int? inrengroup, int? inoutlet, int? incontracts, string incontractflag )
		{
			return Fetch(inregion, incontractor, incontracttype, inrengroup, inoutlet, incontracts, incontractflag).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inregion, string incontractor, int? incontracttype, int? inrengroup, int? inoutlet, int? incontracts, string incontractflag )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_contractor_labels";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inregion", inregion);
					pList.Add(cm, "incontractor", incontractor);
					pList.Add(cm, "incontracttype", incontracttype);
					pList.Add(cm, "inrengroup", inrengroup);
					pList.Add(cm, "inoutlet", inoutlet);
					pList.Add(cm, "incontracts", incontracts);
					pList.Add(cm, "incontractflag", incontractflag);

					List<ContractorLabelFast> _list = new List<ContractorLabelFast>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractorLabelFast instance = new ContractorLabelFast();
                            instance._c_title = GetValueFromReader<string>(dr,0);
                            instance._c_surname_company = GetValueFromReader<string>(dr,1);
                            instance._c_first_names = GetValueFromReader<string>(dr,2);
                            instance._c_initials = GetValueFromReader<string>(dr,3);
                            instance._c_address = GetValueFromReader<string>(dr,4);
                            instance._label = GetValueFromReader<string>(dr,5);
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
