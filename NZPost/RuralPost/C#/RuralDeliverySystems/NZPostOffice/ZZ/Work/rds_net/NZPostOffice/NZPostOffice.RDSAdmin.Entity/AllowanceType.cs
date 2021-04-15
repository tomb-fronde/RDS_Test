using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
    // TJB Allowances Apr-2021
    // Include new columns

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("alt_key", "_alt_key", "allowance_type", true)]
	[MapInfo("alt_description", "_alt_description", "allowance_type")]
    [MapInfo("alt_rate", "_alt_rate", "allowance_type")]
    [MapInfo("alt_wks_yr", "_alt_wks_yr", "allowance_type")]
    [MapInfo("alt_acc", "_alt_acc", "allowance_type")]
    [MapInfo("alt_fuel_pk", "_alt_fuel_pk", "allowance_type")]
    [MapInfo("alt_ruc_pk", "_alt_ruc_pk", "allowance_type")]
    [MapInfo("alct_id", "_alct_id", "allowance_type")]
    [MapInfo("alct_description", "_alct_description", "")]
    [System.Serializable()]

	public class AllowanceType : Entity<AllowanceType>
	{
		#region Business Methods
		[DBField()]
		private int?  _alt_key;

		[DBField()]
		private string  _alt_description;

        [DBField()]
        private decimal? _alt_rate;

        [DBField()]
        private decimal? _alt_wks_yr;

        [DBField()]
        private decimal? _alt_acc;

        [DBField()]
        private decimal? _alt_fuel_pk;

        [DBField()]
        private decimal? _alt_ruc_pk;

        [DBField()]
        private int? _alct_id;

        [DBField]
        private string _alct_description;


		public virtual int? AltKey
		{
			get
			{
				CanReadProperty(true);
				return _alt_key;
			}
			set
			{
				CanWriteProperty(true);
				if ( _alt_key != value )
				{
					_alt_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AltDescription
		{
			get
			{
				CanReadProperty(true);
				return _alt_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _alt_description != value )
				{
					_alt_description = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? AltRate
        {
            get
            {
                CanReadProperty("AltRate", true);
                return _alt_rate;
            }
            set
            {
                CanWriteProperty("AltRate", true);
                if (_alt_rate != value)
                {
                    _alt_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? AltWksYr
        {
            get
            {
                CanReadProperty("AltWksYr", true);
                return _alt_wks_yr;
            }
            set
            {
                CanWriteProperty("AltWksYr", true);
                if (_alt_wks_yr != value)
                {
                    _alt_wks_yr = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? AltAcc
        {
            get
            {
                CanReadProperty("AltAcc", true);
                return _alt_acc;
            }
            set
            {
                CanWriteProperty("AltAcc", true);
                if (_alt_acc != value)
                {
                    _alt_acc = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? AltFuelPk
        {
            get
            {
                CanReadProperty("AltFuelPk", true);
                return _alt_fuel_pk;
            }
            set
            {
                CanWriteProperty("AltFuelPk", true);
                if (_alt_fuel_pk != value)
                {
                    _alt_fuel_pk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? AltRucPk
        {
            get
            {
                CanReadProperty("AltrucPk", true);
                return _alt_ruc_pk;
            }
            set
            {
                CanWriteProperty("AltRucPk", true);
                if (_alt_ruc_pk != value)
                {
                    _alt_ruc_pk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AlctId
        {
            get
            {
                CanReadProperty("AlctId", true);
                return _alct_id;
            }
            set
            {
                CanWriteProperty("AlctId", true);
                if (_alct_id != value)
                {
                    _alct_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AlctDescription
        {
            get
            {
                CanReadProperty(true);
                return _alct_description;
            }
            set
            {
                CanWriteProperty(true);
                if (_alct_description != value)
                {
                    _alct_description = value;
                    PropertyHasChanged();
                }
            }
        }


		private AllowanceType[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _alt_key );
		}
		#endregion

		#region Factory Methods
        public static AllowanceType NewAllowanceType(int? alt_key)
		{
            return Create(alt_key);
		}

		public static AllowanceType[] GetAllAllowanceType(  )
		{
			return Fetch().dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					GenerateSelectCommandText(cm, "allowance_type");

					List<AllowanceType> list = new List<AllowanceType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							AllowanceType instance = new AllowanceType();
							instance.StoreFieldValues(dr, "allowance_type");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new AllowanceType[list.Count];
						list.CopyTo(dataList);
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
				if (GenerateUpdateCommandText(cm, "allowance_type", ref pList))
				{
					cm.CommandText += " WHERE  allowance_type.alt_key = @alt_key ";

					pList.Add(cm, "alt_key", GetInitialValue("_alt_key"));
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "allowance_type", pList))
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
					pList.Add(cm,"alt_key", GetInitialValue("_alt_key"));
						cm.CommandText = "DELETE FROM allowance_type WHERE " +
						"allowance_type.alt_key = @alt_key ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? alt_key )
		{
			_alt_key = alt_key;
		}
	}
}
