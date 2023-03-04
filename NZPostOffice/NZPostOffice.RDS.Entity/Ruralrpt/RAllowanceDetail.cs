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
    [MapInfo("rgn_name", "_rgn_name", "region")]
    [MapInfo("allowance_type_alt_description", "_allowance_type_alt_description", "allowance_type")]
    [MapInfo("contract_allowance_ca_annual_amount", "_contract_allowance_ca_annual_amount", "contract_allowance")]
	[System.Serializable()]

	public class AllowanceDetail : Entity<AllowanceDetail>
	{
		#region Business Methods
		[DBField()]
		private string  _allowance_type_alt_description;

		[DBField()]
		private decimal?  _contract_allowance_ca_annual_amount;

        [DBField()]
        private string _rgn_name;

        public string RgnName
        {
            get
            {
                CanReadProperty("RgnName", true);
                return _rgn_name;
            }
            set
            {
                CanWriteProperty("RgnName", true);
                if (_rgn_name != value)
                {
                    _rgn_name = value;
                    PropertyHasChanged();
                }
            }
        }

		public virtual string AllowanceTypeAltDescription
		{
			get
			{
                CanReadProperty("AllowanceTypeAltDescription", true);
				return _allowance_type_alt_description;
			}
			set
			{
                CanWriteProperty("AllowanceTypeAltDescription", true);
				if ( _allowance_type_alt_description != value )
				{
					_allowance_type_alt_description = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? ContractAllowanceCaAnnualAmount
		{
			get
			{
                CanReadProperty("ContractAllowanceCaAnnualAmount", true);
				return _contract_allowance_ca_annual_amount;
			}
			set
			{
                CanWriteProperty("ContractAllowanceCaAnnualAmount", true);
				if ( _contract_allowance_ca_annual_amount != value )
				{
					_contract_allowance_ca_annual_amount = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[comp1]
			//?crosstabsum(1)


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static AllowanceDetail NewAllowanceDetail( int? inRegionId, int? inRgCode, int? inCtKey )
		{
			return Create(inRegionId, inRgCode, inCtKey);
		}

		public static AllowanceDetail[] GetAllAllowanceDetail( int? inRegionId, int? inRgCode, int? inCtKey )
		{
			return Fetch(inRegionId, inRgCode, inCtKey).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inRegionId, int? inRgCode, int? inCtKey )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
                    cm.CommandText = " SELECT  region.rgn_name ,"
                        +" allowance_type.alt_description ,"
                        +" contract_allowance.ca_annual_amount"
                        +" FROM contract ,"
                        +" outlet ,"
                        +" region ,"
                        +" renewal_group ,"
                        +" types_for_contract ,"
                        +" contract_allowance ,"
                        +" allowance_type"
                        +" WHERE ( outlet.outlet_id = contract.con_base_office ) and          ( region.region_id = outlet.region_id ) and          ( renewal_group.rg_code = contract.rg_code ) and          ( types_for_contract.contract_no = contract.contract_no ) and          ( contract_allowance.contract_no = contract.contract_no ) and          ( allowance_type.alt_key = contract_allowance.alt_key ) and          ( outlet.region_id = :inRegionId or          ( isnull(:inRegionId,"
                        +" -1) = -1 ) ) And          ( renewal_group.rg_code = :inRgCode or          ( isnull(:inRgCode,"
                        +" -1) = -1 ) ) And          ( types_for_contract.ct_key = :inCtKey or          ( isnull(:inCtKey,"
                        +" -1) = -1)  ) and          ( contract.con_date_terminated is null )";

					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inRegionId", inRegionId);
					pList.Add(cm, "inRgCode", inRgCode);
					pList.Add(cm, "inCtKey", inCtKey);

					List<AllowanceDetail> _list = new List<AllowanceDetail>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							AllowanceDetail instance = new AllowanceDetail();
                            instance._rgn_name = GetValueFromReader<string>(dr,0);
                            instance._allowance_type_alt_description = GetValueFromReader<string>(dr,1);
                            instance._contract_allowance_ca_annual_amount = GetValueFromReader<decimal?>(dr, 2);
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
