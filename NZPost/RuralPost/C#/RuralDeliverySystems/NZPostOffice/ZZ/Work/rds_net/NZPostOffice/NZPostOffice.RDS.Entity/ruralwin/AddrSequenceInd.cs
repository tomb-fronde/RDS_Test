using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // TJB Jan-2011 Sequencing Review
    // Added handling of inSFkey == null to FetchEnity
    // Changed Update to call Update_frequency_ind stored procedure
    
    // Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("rf_valid_ind", "_rf_valid_ind", "route_frequency")]
	[MapInfo("rf_valid_date", "_rf_valid_date", "route_frequency")]
	[MapInfo("rf_valid_user", "_rf_valid_user", "route_frequency")]
	[MapInfo("contract_no", "_contract_no", "route_frequency")]
	[MapInfo("sf_key", "_sf_key", "route_frequency")]
	[MapInfo("rf_delivery_days", "_rf_delivery_days", "route_frequency")]
	[System.Serializable()]

	public class AddrSequenceInd : Entity<AddrSequenceInd>
	{
		#region Business Methods
		[DBField()]
		private int?  _rf_valid_ind;

		[DBField()]
		private DateTime?  _rf_valid_date;

		[DBField()]
		private string  _rf_valid_user;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private string  _rf_delivery_days;


		public virtual int? RfValidInd
		{
			get
			{
                CanReadProperty("RfValidInd", true);
				return _rf_valid_ind;
			}
			set
			{
                CanWriteProperty("RfValidInd", true);
				if ( _rf_valid_ind != value )
				{
					_rf_valid_ind = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RfValidDate
		{
			get
			{
                CanReadProperty("RfValidDate", true);
				return _rf_valid_date;
			}
			set
			{
                CanWriteProperty("RfValidDate", true);
				if ( _rf_valid_date != value )
				{
					_rf_valid_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfValidUser
		{
			get
			{
                CanReadProperty("RfValidUser", true);
				return _rf_valid_user;
			}
			set
			{
                CanWriteProperty("RfValidUser", true);
				if ( _rf_valid_user != value )
				{
					_rf_valid_user = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ContractNo
		{
			get
			{
                CanReadProperty("ContractNo", true);
				return _contract_no;
			}
			set
			{
                CanWriteProperty("ContractNo", true);
				if ( _contract_no != value )
				{
					_contract_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? SfKey
		{
			get
			{
                CanReadProperty("SfKey", true);
				return _sf_key;
			}
			set
			{
                CanWriteProperty("SfKey", true);
				if ( _sf_key != value )
				{
					_sf_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfDeliveryDays
		{
			get
			{
                CanReadProperty("RfDeliveryDays", true);
				return _rf_delivery_days;
			}
			set
			{
                CanWriteProperty("RfDeliveryDays", true);
				if ( _rf_delivery_days != value )
				{
					_rf_delivery_days = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual bool isVisible
        {
            get
            {
                CanReadProperty("RfDeliveryDays", true);
                if (RfValidInd == null || RfValidInd == 0)
                    return false;
                return true;
            }
        }

		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}/{2}", _contract_no,_sf_key,_rf_delivery_days );
		}
		#endregion

		#region Factory Methods
		public static AddrSequenceInd NewAddrSequenceInd( int? inContractNo, int? inSFkey, string inDeliveryDays )
		{
			return Create(inContractNo, inSFkey, inDeliveryDays);
		}

		public static AddrSequenceInd[] GetAllAddrSequenceInd( int? inContractNo, int? inSFkey, string inDeliveryDays )
		{
			return Fetch(inContractNo, inSFkey, inDeliveryDays).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inContractNo, int? inSFkey, string inDeliveryDays )
		{
            // TJB Jan-2011 Sequencing Review
            // Added handling of inSFkey == null
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inContractNo", inContractNo);

                    if (inSFkey != null)
                    {
                        cm.CommandText = " SELECT route_frequency.rf_valid_ind," +
                                                 "route_frequency.rf_valid_date," +
                                                 "route_frequency.rf_valid_user," +
                                                 "route_frequency.contract_no," +
                                                 "route_frequency.sf_key," +
                                                 "route_frequency.rf_delivery_days " +
                                            "FROM route_frequency " +
                                           "WHERE route_frequency.contract_no = @inContractNo " +
                                             "AND route_frequency.sf_key = @inSFkey " +
                                             "AND route_frequency.rf_delivery_days = @inDeliveryDays";
                        pList.Add(cm, "inSFkey", inSFkey);
                        pList.Add(cm, "inDeliveryDays", inDeliveryDays);
                    }
                    else   // Called from WCustomerSequencer2 with sf_key == null
                    {      // Get valid ind, date, user for the contract's first active frequency
                           //  (they should all be the same)
                        cm.CommandText = " SELECT TOP(1) " + 
                                                 "route_frequency.rf_valid_ind," +
                                                 "route_frequency.rf_valid_date," +
                                                 "route_frequency.rf_valid_user," +
                                                 "route_frequency.contract_no," +
                                                 "route_frequency.sf_key," +
                                                 "route_frequency.rf_delivery_days " +
                                            "FROM route_frequency " +
                                           "WHERE route_frequency.contract_no = @inContractNo " +
                                             "AND rf_active = 'Y'" + 
                                           "ORDER BY sf_key ";
                    }

                    List<AddrSequenceInd> _list = new List<AddrSequenceInd>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							AddrSequenceInd instance = new AddrSequenceInd();
                            instance._rf_valid_ind = GetValueFromReader<int?>(dr,0);
                            instance._rf_valid_date = GetValueFromReader<DateTime?>(dr,1);
                            instance._rf_valid_user = GetValueFromReader<string>(dr,2);
                            instance._contract_no = GetValueFromReader<int?>(dr,3);
                            instance._sf_key = GetValueFromReader<int?>(dr,4);
                            instance._rf_delivery_days = GetValueFromReader<string>(dr,5);
							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
						list = _list.ToArray();
					}
				}
			}
		}

        [ServerMethod()]
        private void UpdateEntity()
		{
            // TJB Dec-2010 Sequencing Review
            // Changed call Update_frequency_ind stored procedure
            // (see UpdateEntity_v1 (below) for original code)
            // Needed to use stored proc to use cursor to change each record separately
            // (trigger complained)
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    DbCommand cm = cn.CreateCommand();
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "EXEC rd.Update_Frequency_Ind "
                                           + "@contract_no, "
                                           + "@rf_valid_date, "
                                           + "@rf_valid_ind, "
                                           + "@rf_valid_user";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "contract_no", _contract_no);
                    pList.Add(cm, "rf_valid_date", _rf_valid_date);
                    pList.Add(cm, "rf_valid_ind", _rf_valid_ind);
                    pList.Add(cm, "rf_valid_user", _rf_valid_user);

                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
		}

        [ServerMethod()]
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
				ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "route_frequency", pList))
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
					cm.CommandText = "DELETE FROM route_frequency " + 
                                      "WHERE route_frequency.contract_no = @contract_no " + 
					                    "AND route_frequency.sf_key = @sf_key " + 
					                    "AND route_frequency.rf_delivery_days = @rf_delivery_days ";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "sf_key", GetInitialValue("_sf_key"));
                    pList.Add(cm, "rf_delivery_days", GetInitialValue("_rf_delivery_days"));

                    DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? contract_no, int? sf_key, string rf_delivery_days )
		{
			_contract_no = contract_no;
			_sf_key = sf_key;
			_rf_delivery_days = rf_delivery_days;
		}
	}
}
