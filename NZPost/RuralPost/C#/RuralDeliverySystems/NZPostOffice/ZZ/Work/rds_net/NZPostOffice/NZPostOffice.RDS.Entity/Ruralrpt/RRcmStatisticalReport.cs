using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("sort_order", "_sort_order", "")]
	[MapInfo("description", "_description", "")]
	[MapInfo("val", "_val", "")]
    [MapInfo("region", "_region", "")]
	[System.Serializable()]

	public class RcmStatisticalReport : Entity<RcmStatisticalReport>
	{
		#region Business Methods
		[DBField()]
		private int?  _sort_order;

		[DBField()]
		private string  _description;

		[DBField()]
		private string  _val;

        [DBField()]
        private string _region;

		public virtual int? SortOrder
		{
			get
			{
                CanReadProperty("SortOrder", true);
				return _sort_order;
			}
			set
			{
                CanWriteProperty("SortOrder", true);
				if ( _sort_order != value )
				{
					_sort_order = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Description
		{
			get
			{
                CanReadProperty("Description", true);
				return _description;
			}
			set
			{
                CanWriteProperty("Description", true);
				if ( _description != value )
				{
					_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Val
		{
			get
			{
                string retVal= string.Empty;
                double testVal = 0;

                CanReadProperty("Val", true);

                if (!string.IsNullOrEmpty(_description) &&
                        (_description == "Ave. Density (Boxes/ KM)" ||
                        _description == "Cost per Customer($)" ||
                        _description == "Cost per Km($)" ||
                        _description == "No Road Number %" ||
                        _description == "Vehicles meeting replacement %" ||
                        _description == "Vehicles meeting Specs / livery %" ||
                        _description == "Privacy Opt out %"
                        )
                    )
                {                    
                    retVal =  _val;
                    if (!string.IsNullOrEmpty(_val))
                    {
                        if (double.TryParse(_val.Trim(), out testVal))
                        {
                            if (testVal != 0)//pp! show null for 0 double values
                            {
                                retVal = string.Format("{0:###,##0.00}", testVal);
                            }
                            else {
                                retVal = null; //pp! show null for 0 double values
                            }
                        }                       
                    }                  
                }
                else //! truncate the decimals of the rest of the values
                {
                    if (!string.IsNullOrEmpty(_val))
                    {
                        if (double.TryParse(_val.Trim(), out testVal))
                        {
                            retVal = string.Format("{0:###,###}", testVal);
                        }                    
                    }                    
                }                
                return retVal;
			}
			set
			{
                CanWriteProperty("Val", true);
				if ( _val != value )
				{
					_val = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string Region
        {
            get
            {
                CanReadProperty("Region", true);
                return _region;
            }
            set
            {
                CanWriteProperty("Region", true);
                if (_region != value)
                {
                    _region = value;
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
		public static RcmStatisticalReport NewRcmStatisticalReport( int? inRegion, int? inOutlet, int? inRengroup, int? inContractType )
		{
			return Create(inRegion, inOutlet, inRengroup, inContractType);
		}

		public static RcmStatisticalReport[] GetAllRcmStatisticalReport( int? inRegion, int? inOutlet, int? inRengroup, int? inContractType )
		{
            return Fetch(inRegion, inOutlet, inRengroup, inContractType).list;
		}
		#endregion

		#region Data Access
        [ServerMethod]
        private void FetchEntity(int? inRegion, int? inOutlet, int? inRengroup, int? inContractType)
        {
            using (SqlConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO") as SqlConnection)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    //cm.CommandText = "sp_GetRCMStatReportv2";
                    cm.CommandText = "rd.sp_GetRCMStatReport";
                    cm.CommandTimeout = 500;
                    cm.Parameters.Add(new SqlParameter("inRegion", inRegion));
                    cm.Parameters.Add(new SqlParameter("inOutlet", inOutlet));
                    cm.Parameters.Add(new SqlParameter("inRengroup", inRengroup));
                    cm.Parameters.Add(new SqlParameter("inContractType", inContractType));

                    List<RcmStatisticalReport> _list = new List<RcmStatisticalReport>();
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            RcmStatisticalReport instance = new RcmStatisticalReport();
                            instance._sort_order = GetValueFromReader<int?>(dr, "sort_order");
                            instance._description = GetValueFromReader<string>(dr, "description");
                            instance._val = GetValueFromReader<string>(dr, "sumamount");

                            instance._region = GetValueFromReader<string>(dr, "region");
                            //pp! added to get "National" column at end
                            if (instance._region != "National")
                            {
                                instance._region = " " + instance._region;
                            }                          

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
