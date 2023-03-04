using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  Allowances March-2021
    // Added alct_id

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("alt_key", "_alt_key", "")]
	[MapInfo("alt_description", "_alt_description", "")]
    [MapInfo("alct_id", "_alct_id", "")]
    [System.Serializable()]

	public class DddwAllowanceTypes : Entity<DddwAllowanceTypes>
	{
		#region Business Methods
		[DBField()]
		private int?  _alt_key;

		[DBField()]
		private string  _alt_description;

        [DBField()]
        private int? _alct_id;


		public virtual int? AltKey
		{
			get
			{
                CanReadProperty("AltKey", true);
				return _alt_key;
			}
			set
			{
                CanWriteProperty("AltKey", true);
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
                string tmp;
                tmp = (_alct_id == null) ? "" : (new string(' ', 70)) + ',' + _alct_id.ToString() + '.';
                   
                CanReadProperty("AltDescription", true);
                return _alt_description + tmp;
			}
			set
			{
                CanWriteProperty("AltDescription", true);
				if ( _alt_description != value )
				{
					_alt_description = value;
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

        protected override object GetIdValue()
		{
			return _alt_key + " ";
		}
		#endregion

		#region Factory Methods
		public static DddwAllowanceTypes NewDddwAllowanceTypes(  )
		{
			return Create();
		}

		public static DddwAllowanceTypes[] GetAllDddwAllowanceTypes(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					//cm.CommandType = CommandType.StoredProcedure;
                    //cm.CommandText = "sp_DDDW_AllowanceType";
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select alt_key "
                                   + "     , alt_description "
                                   + "     , alct_id "
                                   + "  from allowance_type "
                                   + " order by alt_description";
                    
                    ParameterCollection pList = new ParameterCollection();
                    List<DddwAllowanceTypes> _list = new List<DddwAllowanceTypes>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwAllowanceTypes instance = new DddwAllowanceTypes();
                            instance._alt_key = GetValueFromReader<Int32?>(dr,0);
                            instance._alt_description = GetValueFromReader<String>(dr,1);
                            instance._alct_id = GetValueFromReader<Int32?>(dr, 2);
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
