using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  Allowances  2-Apr-2021:  New
    // Data for dropdown list of ratable vehicle types (table vehicle_allowance_rates)

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("var_id", "_var_id", "vehicle_allowance_rates")]
    [MapInfo("var_description", "_var_description", "vehicle_allowance_rates")]
    [System.Serializable()]

    public class DddwVehicleAllowanceRates : Entity<DddwVehicleAllowanceRates>
	{
		#region Business Methods
		[DBField()]
		private int?  _var_id;

		[DBField()]
		private string  _var_description;


		public virtual int? VarId
		{
			get
			{
                CanReadProperty("VarId", true);
				return _var_id;
			}
			set
			{
                CanWriteProperty("VarId", true);
                if (_var_id != value)
				{
                    _var_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string VarDescription
		{
			get
			{
                CanReadProperty("VarDescription", true);
				return _var_description;
			}
			set
			{
                CanWriteProperty("VarDescription", true);
                if (_var_description != value)
				{
                    _var_description = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
            return _var_id + " ";
		}
		#endregion

		#region Factory Methods
		public static DddwVehicleAllowanceRates NewDddwVehicleAllowanceRates(  )
		{
			return Create();
		}

		public static DddwVehicleAllowanceRates[] GetAllDddwVehicleAllowanceRates(  )
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
                    cm.CommandType = CommandType.Text;
                    cm.CommandText =
                        " SELECT var_id"
                        + "    , var_description "
                        + " FROM rd.vehicle_allowance_rates ";

                    ParameterCollection pList = new ParameterCollection();
					List<DddwVehicleAllowanceRates> _list = new List<DddwVehicleAllowanceRates>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwVehicleAllowanceRates instance = new DddwVehicleAllowanceRates();
                            instance._var_id = GetValueFromReader<int?>(dr, 0);
                            instance._var_description = GetValueFromReader<string>(dr, 1);
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
