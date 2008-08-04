using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("outlet_id", "_outlet_id", "outlet")]
	[MapInfo("ot_code", "_ot_code", "outlet")]
	[MapInfo("region_id", "_region_id", "outlet")]
	[MapInfo("o_name", "_o_name", "outlet")]
	[MapInfo("o_address", "_o_address", "outlet")]
	[MapInfo("o_telephone", "_o_telephone", "outlet")]
	[MapInfo("o_fax", "_o_fax", "outlet")]
	[MapInfo("o_manager", "_o_manager", "outlet")]
	[MapInfo("o_responsibility_code", "_o_responsibility_code", "outlet")]
	[System.Serializable()]

    public class OutletList : Entity<OutletList>
	{
		#region Business Methods
		[DBField()]
		private int?  _outlet_id;

		[DBField()]
		private int?  _ot_code;

		[DBField()]
		private int?  _region_id;

		[DBField()]
		private string  _o_name;

		[DBField()]
		private string  _o_address;

		[DBField()]
		private string  _o_telephone;

		[DBField()]
		private string  _o_fax;

		[DBField()]
		private string  _o_manager;

		[DBField()]
		private string  _o_responsibility_code;


		public virtual int? OutletId
		{
			get
			{
				CanReadProperty(true);
				return _outlet_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _outlet_id != value )
				{
					_outlet_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? OtCode
		{
			get
			{
				CanReadProperty(true);
				return _ot_code;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ot_code != value )
				{
					_ot_code = value;
					PropertyHasChanged();
				}
			}
		}

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

		public virtual string OName
		{
			get
			{
				CanReadProperty(true);
				return _o_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _o_name != value )
				{
					_o_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OAddress
		{
			get
			{
				CanReadProperty(true);
				return _o_address;
			}
			set
			{
				CanWriteProperty(true);
				if ( _o_address != value )
				{
					_o_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OTelephone
		{
			get
			{
				CanReadProperty(true);
				return _o_telephone;
			}
			set
			{
				CanWriteProperty(true);
				if ( _o_telephone != value )
				{
					_o_telephone = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OFax
		{
			get
			{
				CanReadProperty(true);
				return _o_fax;
			}
			set
			{
				CanWriteProperty(true);
				if ( _o_fax != value )
				{
					_o_fax = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OManager
		{
			get
			{
				CanReadProperty(true);
				return _o_manager;
			}
			set
			{
				CanWriteProperty(true);
				if ( _o_manager != value )
				{
					_o_manager = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OResponsibilityCode
		{
			get
			{
				CanReadProperty(true);
				return _o_responsibility_code;
			}
			set
			{
				CanWriteProperty(true);
				if ( _o_responsibility_code != value )
				{
					_o_responsibility_code = value;
					PropertyHasChanged();
				}
			}
		}
        private OutletList[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _outlet_id );
		}
		#endregion

		#region Factory Methods
        public static OutletList NewOutletList()
		{
			return Create();
		}

        public static OutletList[] GetAllOutletList(int region_id)
		{
            return Fetch(region_id).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
        private void FetchEntity(int region_id)
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "region_id", region_id);
					GenerateSelectCommandText(cm, "outlet");
                    cm.CommandText += " where region_id = @region_id";

                    List<OutletList> list = new List<OutletList>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
                            OutletList instance = new OutletList();
							instance.StoreFieldValues(dr, "outlet");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new OutletList[list.Count];
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
				if (GenerateUpdateCommandText(cm, "outlet", ref pList))
				{
					cm.CommandText += " WHERE  outlet.outlet_id = @outlet_id ";

					pList.Add(cm, "outlet_id", GetInitialValue("_outlet_id"));
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "outlet", pList))
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
					pList.Add(cm,"outlet_id", GetInitialValue("_outlet_id"));
						cm.CommandText = "DELETE FROM outlet WHERE " +
						"outlet.outlet_id = @outlet_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? outlet_id )
		{
			_outlet_id = outlet_id;
		}
	}
}
