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
	[MapInfo("surname", "_surname", "")]
	[MapInfo("firstname", "_firstname", "")]
	[MapInfo("address", "_address", "")]
	[MapInfo("nightphone", "_nightphone", "")]
	[MapInfo("dayphone", "_dayphone", "")]
	[System.Serializable()]

	public class ContractSummaryOwnerDriver : Entity<ContractSummaryOwnerDriver>
	{
		#region Business Methods
		[DBField()]
		private string  _surname;

		[DBField()]
		private string  _firstname;

		[DBField()]
		private string  _address;

		[DBField()]
		private string  _nightphone;

		[DBField()]
		private string  _dayphone;


		public virtual string Surname
		{
			get
			{
                CanReadProperty("Surname", true);
				return _surname;
			}
			set
			{
                CanWriteProperty("Surname", true);
				if ( _surname != value )
				{
					_surname = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Firstname
		{
			get
			{
                CanReadProperty("Firstname", true);
				return _firstname;
			}
			set
			{
                CanWriteProperty("Firstname", true);
				if ( _firstname != value )
				{
					_firstname = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Address
		{
			get
			{
                CanReadProperty("Address", true);
				return _address;
			}
			set
			{
                CanWriteProperty("Address", true);
				if ( _address != value )
				{
					_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Nightphone
		{
			get
			{
                CanReadProperty("Nightphone", true);
				return _nightphone;
			}
			set
			{
                CanWriteProperty("Nightphone", true);
				if ( _nightphone != value )
				{
					_nightphone = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Dayphone
		{
			get
			{
                CanReadProperty("Dayphone", true);
				return _dayphone;
			}
			set
			{
                CanWriteProperty("Dayphone", true);
				if ( _dayphone != value )
				{
					_dayphone = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[compute_1]
			//?trim( if(isnull(surname),'',surname )  ) + IF(ISNULL(firstname ),'',', ')+trim( if(isnull(firstname ),'',firstname ) )


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static ContractSummaryOwnerDriver NewContractSummaryOwnerDriver( int? contract, int? renewal )
		{
			return Create(contract, renewal);
		}

		public static ContractSummaryOwnerDriver[] GetAllContractSummaryOwnerDriver( int? contract, int? renewal )
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
                    cm.CommandText = "sp_Contractor32";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContract", contract);
					pList.Add(cm, "inRenewal", renewal);

					List<ContractSummaryOwnerDriver> _list = new List<ContractSummaryOwnerDriver>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractSummaryOwnerDriver instance = new ContractSummaryOwnerDriver();
                            instance._surname = GetValueFromReader<string>(dr,0);
                            instance._firstname = GetValueFromReader<string>(dr,1);
                            instance._address = GetValueFromReader<string>(dr,2);
                            instance._nightphone = GetValueFromReader<string>(dr,3);
                            instance._dayphone = GetValueFromReader<string>(dr,4);
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
