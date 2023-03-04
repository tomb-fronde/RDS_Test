using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract_no", "_contract_no", "route_audit")]
	[MapInfo("ra_date_of_check", "_ra_date_of_check", "route_audit")]
	[MapInfo("ra_frequency", "_ra_frequency", "route_audit")]
	[MapInfo("ra_contractor", "_ra_contractor", "route_audit")]
	[System.Serializable()]

	public class RouteAuditListing : Entity<RouteAuditListing>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private DateTime?  _ra_date_of_check;

		[DBField()]
		private string  _ra_frequency;

		[DBField()]
		private string  _ra_contractor;


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

		public virtual DateTime? RaDateOfCheck
		{
			get
			{
                CanReadProperty("RaDateOfCheck", true);
				return _ra_date_of_check;
			}
			set
			{
                CanWriteProperty("RaDateOfCheck", true);
				if ( _ra_date_of_check != value )
				{
					_ra_date_of_check = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaFrequency
		{
			get
			{
                CanReadProperty("RaFrequency", true);
				return _ra_frequency;
			}
			set
			{
                CanWriteProperty("RaFrequency", true);
				if ( _ra_frequency != value )
				{
					_ra_frequency = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RaContractor
		{
			get
			{
                CanReadProperty("RaContractor", true);
				return _ra_contractor;
			}
			set
			{
                CanWriteProperty("RaContractor", true);
				if ( _ra_contractor != value )
				{
					_ra_contractor = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}", _contract_no,_ra_date_of_check );
		}
		#endregion

		#region Factory Methods
		public static RouteAuditListing NewRouteAuditListing( int? contract )
		{
			return Create(contract);
		}

		public static RouteAuditListing[] GetAllRouteAuditListing( int? contract )
		{
			return Fetch(contract).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? contract )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "contract", contract);

                    cm.CommandText = @"SELECT route_audit.contract_no,   
                                             route_audit.ra_date_of_check,   
                                             route_audit.ra_frequency,   
                                             route_audit.ra_contractor  
                                        FROM route_audit  
                                       WHERE route_audit.contract_no = @contract ";

					List<RouteAuditListing> _list = new List<RouteAuditListing>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							RouteAuditListing instance = new RouteAuditListing();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._ra_date_of_check = GetValueFromReader<DateTime?>(dr,1);
                            instance._ra_frequency = GetValueFromReader<String>(dr,2);
                            instance._ra_contractor = GetValueFromReader<String>(dr,3);

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
			using ( DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateUpdateCommandText(cm, "route_audit", ref pList))
				{
					cm.CommandText += " WHERE  route_audit.contract_no = @contract_no AND " + 
						"route_audit.ra_date_of_check = @ra_date_of_check ";

					pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
					pList.Add(cm, "ra_date_of_check", GetInitialValue("_ra_date_of_check"));
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
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
				if (GenerateInsertCommandText(cm, "route_audit", pList))
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
					pList.Add(cm,"contract_no", GetInitialValue("_contract_no"));
					pList.Add(cm,"ra_date_of_check", GetInitialValue("_ra_date_of_check"));
						cm.CommandText = "DELETE FROM route_audit WHERE " +
						"route_audit.contract_no = @contract_no AND " + 
						"route_audit.ra_date_of_check = @ra_date_of_check ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? contract_no, DateTime? ra_date_of_check )
		{
			_contract_no = contract_no;
			_ra_date_of_check = ra_date_of_check;
		}
	}
}
