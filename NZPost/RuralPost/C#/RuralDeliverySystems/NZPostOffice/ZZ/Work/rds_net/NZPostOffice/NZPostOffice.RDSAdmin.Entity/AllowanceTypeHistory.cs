using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
    // TJB Allowances 1-June-2021: New
    // Data access for allowance_type_history table

    // Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("alt_key", "_alt_key", "allowance_type_history")]
    [MapInfo("alt_description", "_alt_description", "allowance_type_history")]
    [MapInfo("alt_rate", "_alt_rate", "allowance_type_history")]
    [MapInfo("alt_wks_yr", "_alt_wks_yr", "allowance_type_history")]
    [MapInfo("alt_acc", "_alt_acc", "allowance_type_history")]
    [MapInfo("alct_id", "_alct_id", "allowance_type_history")]
    [MapInfo("alt_effective_date", "_alt_effective_date", "allowance_type_history")]
    [MapInfo("alt_notes", "_alt_notes", "allowance_type_history")]
    [MapInfo("alct_description", "_alct_description", "")]
    [System.Serializable()]

	public class AllowanceTypeHistory : Entity<AllowanceTypeHistory>
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
        private int? _alct_id;

        [DBField()]
        private DateTime? _alt_effective_date;

        [DBField()]
        private string _alt_notes;

        [DBField()]
        private string _alct_description;

        private int _sqlcode;
        private string _sqlerrmsg;


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

        public virtual string AltNotes
        {
            get
            {
                CanReadProperty("AltNotes",true);
                return _alt_notes;
            }
            set
            {
                CanWriteProperty("AltNotes", true);
                if (_alt_notes != value)
                {
                    _alt_notes = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? AltEffectiveDate
        {
            get
            {
                CanReadProperty("AltEffectiveDate", true);
                return _alt_effective_date;
            }
            set
            {
                CanWriteProperty("AltEffectiveDate", true);
                if (_alt_effective_date != value)
                {
                    _alt_effective_date = value;
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

        public virtual int SqlCode
        {
            get
            {
                return _sqlcode;
            }
        }

        public virtual string SqlErrmsg
        {
            get
            {
                return _sqlerrmsg;
            }
        }


 private AllowanceTypeHistory[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _alt_key );
		}
		#endregion

		#region Factory Methods
        public static AllowanceTypeHistory NewAllowanceTypeHistory(int? AltKey)
		{
            return Create(AltKey);
		}

		public static AllowanceTypeHistory[] GetAllAllowanceTypeHistory(int? AltKey  )
		{
			return Fetch(AltKey).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(int? AltKey  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT alt.alt_key "
                                   + "     , alt.alt_description "
                                   + "     , alt.alct_id"
                                   + "     , alt.alt_rate "
                                   + "     , alt.alt_wks_yr "
                                   + "     , alt.alt_acc "
                                   + "     , alt.alt_effective_date  "
                                   + "     , alt.alt_notes "
                                   + "     , alct.alct_description "
                                   + "  FROM allowance_type_history alt "
                                   + "     , rd.allowance_calc_type alct "
                                   + " WHERE alt.alt_key = @alt_key "
                                   + "   AND alct.alct_id = alt.alct_id ";

                    pList.Add(cm, "@alt_key", AltKey);
                    List<AllowanceTypeHistory> _list = new List<AllowanceTypeHistory>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
                        while (dr.Read())
                        {
                            AllowanceTypeHistory instance = new AllowanceTypeHistory();
                            instance._alt_key = GetValueFromReader<int?>(dr, 0);
                            instance._alt_description = GetValueFromReader<string>(dr, 1);
                            instance._alct_id = GetValueFromReader<int?>(dr, 2);
                            instance._alt_rate = GetValueFromReader<decimal?>(dr, 3);
                            instance._alt_wks_yr = GetValueFromReader<decimal?>(dr, 4);
                            instance._alt_acc = GetValueFromReader<decimal?>(dr, 5);
                            instance._alt_effective_date = GetValueFromReader<DateTime?>(dr, 6);
                            instance._alt_notes = GetValueFromReader<string>(dr, 7);
                            instance._alct_description = GetValueFromReader<string>(dr, 8);
                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        dataList = new AllowanceTypeHistory[_list.Count];
						_list.CopyTo(dataList);
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
                if (GenerateUpdateCommandText(cm, "allowance_type_history", ref pList))
				{
					cm.CommandText += " WHERE allowance_type_history.alt_key = @alt_key "
                                     +"   and allowance_type_history.alt_effective_date = @alt_effective_date";

					pList.Add(cm, "alt_key", GetInitialValue("_alt_key"));
                    pList.Add(cm, "alt_effective_date", GetInitialValue("_alt_effective_date"));
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
				if (GenerateInsertCommandText(cm, "allowance_type_history", pList))
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
                    pList.Add(cm, "alt_key", GetInitialValue("_alt_key"));
                    pList.Add(cm, "alt_effective_date", GetInitialValue("_alt_effective_date"));
                    cm.CommandText = "DELETE FROM allowance_type_history " 
						             + "WHERE allowance_type_history.alt_key = @alt_key "
                                     + "  and allowance_type_history.alt_effective_date = @alt_effective_date";
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
