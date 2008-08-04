using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("region_id", "_region_id", "region")]
	[MapInfo("rgn_name", "_rgn_name", "region")]
	[MapInfo("rgn_rcm_manager", "_rgn_rcm_manager", "region")]
	[MapInfo("rgn_address", "_rgn_address", "region")]
	[MapInfo("rgn_telephone", "_rgn_telephone", "region")]
	[MapInfo("rgn_fax", "_rgn_fax", "region")]
	[MapInfo("rgn_responsibility_centre_no", "_rgn_responsibility_centre_no", "region")]
	[MapInfo("rgn_expenditure_code", "_rgn_expenditure_code", "region")]
	[MapInfo("rgn_mobile", "_rgn_mobile", "region")]
	[System.Serializable()]

	public class Region : Entity<Region>
	{
		#region Business Methods
		[DBField()]
		private int?  _region_id;

		[DBField()]
		private string  _rgn_name;

		[DBField()]
		private string  _rgn_rcm_manager;

		[DBField()]
		private string  _rgn_address;

		[DBField()]
		private string  _rgn_telephone;

		[DBField()]
		private string  _rgn_fax;

		[DBField()]
		private string  _rgn_responsibility_centre_no;

		[DBField()]
		private string  _rgn_expenditure_code;

		[DBField()]
		private string  _rgn_mobile;


		public virtual int? RegionId
		{
			get
			{
				CanReadProperty(true);
				return _region_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _region_id != value )
				{
					_region_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgnName
		{
			get
			{
				CanReadProperty(true);
				return _rgn_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rgn_name != value )
				{
					_rgn_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgnRcmManager
		{
			get
			{
				CanReadProperty(true);
				return _rgn_rcm_manager;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rgn_rcm_manager != value )
				{
					_rgn_rcm_manager = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgnAddress
		{
			get
			{
				CanReadProperty(true);
				return _rgn_address;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rgn_address != value )
				{
					_rgn_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgnTelephone
		{
			get
			{
				CanReadProperty(true);
				return _rgn_telephone;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rgn_telephone != value )
				{
					_rgn_telephone = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgnFax
		{
			get
			{
				CanReadProperty(true);
				return _rgn_fax;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rgn_fax != value )
				{
					_rgn_fax = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgnResponsibilityCentreNo
		{
			get
			{
				CanReadProperty(true);
				return _rgn_responsibility_centre_no;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rgn_responsibility_centre_no != value )
				{
					_rgn_responsibility_centre_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgnExpenditureCode
		{
			get
			{
				CanReadProperty(true);
				return _rgn_expenditure_code;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rgn_expenditure_code != value )
				{
					_rgn_expenditure_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgnMobile
		{
			get
			{
				CanReadProperty(true);
				return _rgn_mobile;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rgn_mobile != value )
				{
					_rgn_mobile = value;
					PropertyHasChanged();
				}
			}
		}
		private Region[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _region_id );
		}
		#endregion

		#region Factory Methods
		public static Region NewRegion( int? regionid )
		{
			return Create(regionid);
		}

		public static Region[] GetAllRegion( int? regionid )
		{
			return Fetch(regionid).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? regionid )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "regionid", regionid);
					GenerateSelectCommandText(cm, "region");
                    cm.CommandText += " where region_id = @regionid";

					List<Region> list = new List<Region>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							Region instance = new Region();
							instance.StoreFieldValues(dr, "region");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new Region[list.Count];
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
				if (GenerateUpdateCommandText(cm, "region", ref pList))
				{
					cm.CommandText += " WHERE  region.region_id = @region_id ";

					pList.Add(cm, "region_id", GetInitialValue("_region_id"));
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
				if (GenerateInsertCommandText(cm, "region", pList))
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
					pList.Add(cm,"region_id", GetInitialValue("_region_id"));
						cm.CommandText = "DELETE FROM region WHERE " +
						"region.region_id = @region_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? region_id )
		{
			_region_id = region_id;
		}
	}
}
