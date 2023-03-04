using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;using Metex.Core;using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("rc_name", "_rc_name", "rds_component")]
	[MapInfo("rc_id", "_rc_id", "rds_component")]
	[MapInfo("rc_description", "_rc_description", "rds_component")]
	[MapInfo("rc_allowcreate", "_rc_allowcreate", "rds_component")]
	[MapInfo("rc_allowread", "_rc_allowread", "rds_component")]
	[MapInfo("rc_allowmodify", "_rc_allowmodify", "rds_component")]
	[MapInfo("rc_allowdelete", "_rc_allowdelete", "rds_component")]
	[System.Serializable()]

	public class ComponentList : Entity<ComponentList>
	{
		#region Business Methods
		[DBField()]
		private string  _rc_name;

		[DBField()]
		private int?  _rc_id;

		[DBField()]
		private string  _rc_description;

		[DBField()]
		private string  _rc_allowcreate;

		[DBField()]
		private string  _rc_allowread;

		[DBField()]
		private string  _rc_allowmodify;

		[DBField()]
		private string  _rc_allowdelete;


		public virtual string RcName
		{
			get
			{
				CanReadProperty(true);
				return _rc_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rc_name != value )
				{
					_rc_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RcId
		{
			get
			{
				CanReadProperty(true);
				return _rc_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rc_id != value )
				{
					_rc_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RcDescription
		{
			get
			{
				CanReadProperty(true);
				return _rc_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rc_description != value )
				{
					_rc_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RcAllowcreate
		{
			get
			{
				CanReadProperty(true);
				return _rc_allowcreate;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rc_allowcreate != value )
				{
					_rc_allowcreate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RcAllowread
		{
			get
			{
				CanReadProperty(true);
				return _rc_allowread;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rc_allowread != value )
				{
					_rc_allowread = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RcAllowmodify
		{
			get
			{
				CanReadProperty(true);
				return _rc_allowmodify;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rc_allowmodify != value )
				{
					_rc_allowmodify = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RcAllowdelete
		{
			get
			{
				CanReadProperty(true);
				return _rc_allowdelete;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rc_allowdelete != value )
				{
					_rc_allowdelete = value;
					PropertyHasChanged();
				}
			}
		}
        private ComponentList[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _rc_id );
		}
		#endregion

		#region Factory Methods
        public static ComponentList NewComponentList()
		{
			return Create();
		}

        public static ComponentList[] GetAllComponentList()
		{
			return Fetch().dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					GenerateSelectCommandText(cm, "rds_component");

                    List<ComponentList> list = new List<ComponentList>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
                            ComponentList instance = new ComponentList();
							instance.StoreFieldValues(dr, "rds_component");
							instance.MarkOld();
							list.Add(instance);
						}
                        dataList = new ComponentList[list.Count];
						list.CopyTo(dataList);
					}
				}
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
				if (GenerateInsertCommandText(cm, "rds_component", pList))
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
					pList.Add(cm,"rc_id", GetInitialValue("_rc_id"));
						cm.CommandText = "DELETE FROM rds_component WHERE " +
						"rds_component.rc_id = @rc_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? rc_id )
		{
			_rc_id = rc_id;
		}
	}
}
