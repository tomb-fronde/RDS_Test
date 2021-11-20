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
	[MapInfo("make", "_make", "")]
	[MapInfo("model", "_model", "")]
	[MapInfo("modelyear", "_modelyear", "")]
	[MapInfo("odometer", "_odometer", "")]
	[MapInfo("cc_rating", "_cc_rating", "")]
	[MapInfo("reg_number", "_reg_number", "")]
	[MapInfo("date_purchased", "_date_purchased", "")]
	[MapInfo("ruc", "_ruc", "")]
	[MapInfo("purchase_value", "_purchase_value", "")]
	[MapInfo("ft_description", "_ft_description", "")]
	[MapInfo("vt_description", "_vt_description", "")]
	[System.Serializable()]

	public class ContractSummaryVehicle : Entity<ContractSummaryVehicle>
	{
		#region Business Methods
		[DBField()]
		private string  _make;

		[DBField()]
		private string  _model;

		[DBField()]
		private int?  _modelyear;

		[DBField()]
		private int?  _odometer;

		[DBField()]
		private int?  _cc_rating;

		[DBField()]
		private string  _reg_number;

		[DBField()]
		private DateTime?  _date_purchased;

		[DBField()]
		private string  _ruc;

		[DBField()]
		private int?  _purchase_value;

		[DBField()]
		private string  _ft_description;

		[DBField()]
		private string  _vt_description;


		public virtual string Make
		{
			get
			{
                CanReadProperty("Make", true);
				return _make;
			}
			set
			{
                CanWriteProperty("Make", true);
				if ( _make != value )
				{
					_make = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Model
		{
			get
			{
                CanReadProperty("Model", true);
				return _model;
			}
			set
			{
                CanWriteProperty("Model", true);
				if ( _model != value )
				{
					_model = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Modelyear
		{
			get
			{
                CanReadProperty("Modelyear", true);
				return _modelyear;
			}
			set
			{
                CanWriteProperty("Modelyear", true);
				if ( _modelyear != value )
				{
					_modelyear = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Odometer
		{
			get
			{
                CanReadProperty("Odometer", true);
				return _odometer;
			}
			set
			{
                CanWriteProperty("Odometer", true);
				if ( _odometer != value )
				{
					_odometer = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? CcRating
		{
			get
			{
                CanReadProperty("CcRating", true);
				return _cc_rating;
			}
			set
			{
                CanWriteProperty("CcRating", true);
				if ( _cc_rating != value )
				{
					_cc_rating = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RegNumber
		{
			get
			{
                CanReadProperty("RegNumber", true);
				return _reg_number;
			}
			set
			{
                CanWriteProperty("RegNumber", true);
				if ( _reg_number != value )
				{
					_reg_number = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? DatePurchased
		{
			get
			{
                CanReadProperty("DatePurchased", true);
				return _date_purchased;
			}
			set
			{
                CanWriteProperty("DatePurchased", true);
				if ( _date_purchased != value )
				{
					_date_purchased = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Ruc
		{
			get
			{
                CanReadProperty("Ruc", true);
				return _ruc;
			}
			set
			{
                CanWriteProperty("Ruc", true);
				if ( _ruc != value )
				{
					_ruc = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? PurchaseValue
		{
			get
			{
                CanReadProperty("PurchaseValue", true);
				return _purchase_value;
			}
			set
			{
                CanWriteProperty("PurchaseValue", true);
				if ( _purchase_value != value )
				{
					_purchase_value = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string FtDescription
		{
			get
			{
                CanReadProperty("FtDescription", true);
				return _ft_description;
			}
			set
			{
                CanWriteProperty("FtDescription", true);
				if ( _ft_description != value )
				{
					_ft_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string VtDescription
		{
			get
			{
                CanReadProperty("VtDescription", true);
				return _vt_description;
			}
			set
			{
                CanWriteProperty("VtDescription", true);
				if ( _vt_description != value )
				{
					_vt_description = value;
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
		public static ContractSummaryVehicle NewContractSummaryVehicle( int? contract, int? renewal )
		{
			return Create(contract, renewal);
		}

		public static ContractSummaryVehicle[] GetAllContractSummaryVehicle( int? contract, int? renewal )
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
                    cm.CommandText = "sp_Vehicle";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContract", contract);
                    pList.Add(cm, "inSequence", renewal);

					List<ContractSummaryVehicle> _list = new List<ContractSummaryVehicle>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractSummaryVehicle instance = new ContractSummaryVehicle();
                            instance._make = GetValueFromReader<string>(dr,0);
                            instance._model = GetValueFromReader<string>(dr,1);
                            instance._modelyear = GetValueFromReader<int?>(dr,2);
                            instance._odometer = GetValueFromReader<int?>(dr,3);
                            instance._cc_rating = GetValueFromReader<int?>(dr,4);
                            instance._reg_number = GetValueFromReader<string>(dr,5);
                            instance._date_purchased = GetValueFromReader<DateTime?>(dr,6);
                            instance._ruc = GetValueFromReader<string>(dr,7);
                            instance._purchase_value = GetValueFromReader<int?>(dr,8);
                            instance._ft_description = GetValueFromReader<string>(dr,9);
                            instance._vt_description = GetValueFromReader<string>(dr,10);
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
