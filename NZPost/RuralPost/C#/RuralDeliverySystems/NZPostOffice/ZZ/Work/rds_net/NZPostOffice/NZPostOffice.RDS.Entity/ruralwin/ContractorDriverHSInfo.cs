using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // TJB APR-2014
    // Added Trim() when returning _driver_name
    //
    // TJB  RPCR_060  Jan-2014:  NEW
    // Retrieves summary H&S information about a contractor's drivers
    // for the DContractorDriverHSInfo DataControl

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("contractor_supplier_no", "_contractor_supplier_no", "")]
    [MapInfo("driver_no", "_driver_no", "")]
    [MapInfo("driver_name", "_driver_name", "")]
    [MapInfo("hst_name", "_hst_name", "")]
    [MapInfo("hsi_date_checked", "_hsi_date_checked", "")]
    [MapInfo("hsi_passfail_ind", "_hsi_passfail_ind", "")]
	[System.Serializable()]

	public class ContractorDriverHSInfo : Entity<ContractorDriverHSInfo>
	{
		#region Business Methods
		[DBField()]
        private int? _contractor_supplier_no;

		[DBField()]
		private int?  _driver_no;

        [DBField()]
        private string _driver_name;

        [DBField()]
        private string _hst_name;

        [DBField()]
        private DateTime? _hsi_date_checked;

		[DBField()]
		private string  _hsi_passfail_ind;


		public virtual int? ContractorSupplierNo
		{
			get
			{
                CanReadProperty("ContractorSupplierNo", true);
                return _contractor_supplier_no;
			}
			set
			{
                CanWriteProperty("ContractorSupplierNo", true);
                if (_contractor_supplier_no != value)
				{
                    _contractor_supplier_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? DriverNo
		{
			get
			{
                CanReadProperty("DriverNo", true);
                return _driver_no;
			}
			set
			{
                CanWriteProperty("DriverNo", true);
                if (_driver_no != value)
				{
                    _driver_no = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string DriverName
        {
            get
            {   // TJB APR-2014: Added Trim()
                CanReadProperty("DriverName", true);
                return _driver_name.Trim();
            }
            set
            {
                CanWriteProperty("DriverName", true);
                if (_driver_name != value)
                {
                    _driver_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string HstName
        {
            get
            {
                CanReadProperty("HstName", true);
                return _hst_name;
            }
            set
            {
                CanWriteProperty("HstName", true);
                if (_hst_name != value)
                {
                    _hst_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? HsiDateChecked
		{
			get
			{
                CanReadProperty("HsiDateChecked", true);
                return _hsi_date_checked;
			}
			set
			{
                CanWriteProperty("HsiDateChecked", true);
                if (_hsi_date_checked != value)
				{
                    _hsi_date_checked = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string HsiPassfailInd
		{
			get
			{
                CanReadProperty("HsiPassfailInd", true);
                return _hsi_passfail_ind;
			}
			set
			{
                CanWriteProperty("HsiPassfailInd", true);
                if (_hsi_passfail_ind != value)
				{
                    _hsi_passfail_ind = value;
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
		public static ContractorDriverHSInfo NewContractorDriverHSInfo()
		{
			return Create();
		}

		public static ContractorDriverHSInfo[] GetAllContractorDriverHSInfo( int? in_contractor )
		{
			return Fetch(in_contractor).list;
		}
		#endregion

		#region Data Access

        public int SqlErrCode = 0;
        public string SqlErrMsg = "";

		[ServerMethod]
		private void FetchEntity( int? in_contractor )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_getContractorDriverHSInfo";
                    ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContractorSupplierNo", in_contractor);

                    try
                    {
                        SqlErrCode = 0;
                        List<ContractorDriverHSInfo> _list = new List<ContractorDriverHSInfo>();
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                ContractorDriverHSInfo instance = new ContractorDriverHSInfo();
                                instance._contractor_supplier_no = GetValueFromReader<int?>(dr, 0);
                                instance._driver_no = GetValueFromReader<int?>(dr, 1);
                                instance._driver_name = GetValueFromReader<string>(dr, 2);
                                instance._hst_name = GetValueFromReader<string>(dr, 3);
                                instance._hsi_date_checked = GetValueFromReader<DateTime?>(dr, 4);
                                instance._hsi_passfail_ind = GetValueFromReader<string>(dr, 5);
                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                            list = _list.ToArray();
                        }
                    }
                    catch (Exception e)
                    {
                        SqlErrCode = -1;
                        SqlErrMsg  = e.Message;
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
