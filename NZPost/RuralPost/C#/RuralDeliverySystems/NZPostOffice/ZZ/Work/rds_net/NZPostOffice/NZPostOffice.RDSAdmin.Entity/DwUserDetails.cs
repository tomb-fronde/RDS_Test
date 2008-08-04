using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Metex.Core;
using Metex.Core.Security;
using NZPostOffice.Entity;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("u_id", "_rds_user_u_id", "rds_user")]
	[MapInfo("u_name", "_rds_user_u_name", "rds_user")]
	[MapInfo("u_location", "_rds_user_u_location", "rds_user")]
	[MapInfo("u_phone", "_rds_user_u_phone", "rds_user")]
	[MapInfo("u_mobile", "_rds_user_u_mobile", "rds_user")]
	[MapInfo("region_id", "_rds_user_region_id", "rds_user")]
	[MapInfo("ui_userid", "_rds_user_id_ui_userid", "rds_user_id")]
	[MapInfo("ui_password", "_rds_user_id_ui_password", "rds_user_id")]
	[MapInfo("ui_id", "_rds_user_id_ui_id", "rds_user_id")]
	[System.Serializable()]

    public class UserDetails : RDSEntityBase<UserDetails>
	{
		#region Business Methods
		[DBField()]
		private int?  _rds_user_u_id;

		[DBField()]
		private string  _rds_user_u_name;

		[DBField()]
		private string  _rds_user_u_location;

		[DBField()]
		private string  _rds_user_u_phone;

		[DBField()]
		private string  _rds_user_u_mobile;

		[DBField()]
		private int?  _rds_user_region_id;

		[DBField()]
		private string  _rds_user_id_ui_userid;

		[DBField()]
		private string  _rds_user_id_ui_password;

		[DBField()]
		private int?  _rds_user_id_ui_id;


		public virtual int? RdsUserUId
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_u_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_u_id != value )
				{
					_rds_user_u_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdsUserUName
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_u_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_u_name != value )
				{
					_rds_user_u_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdsUserULocation
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_u_location;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_u_location != value )
				{
					_rds_user_u_location = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdsUserUPhone
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_u_phone;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_u_phone != value )
				{
					_rds_user_u_phone = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdsUserUMobile
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_u_mobile;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_u_mobile != value )
				{
					_rds_user_u_mobile = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RdsUserRegionId
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_region_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_region_id != value )
				{
					_rds_user_region_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdsUserIdUiUserid
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_userid;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_userid != value )
				{
					_rds_user_id_ui_userid = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdsUserIdUiPassword
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_password;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_password != value )
				{
					_rds_user_id_ui_password = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RdsUserIdUiId
		{
			get
			{
				CanReadProperty(true);
				return _rds_user_id_ui_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rds_user_id_ui_id != value )
				{
					_rds_user_id_ui_id = value;
					PropertyHasChanged();
				}
			}
		}
        private UserDetails[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _rds_user_u_id );
		}

        public new void MarkDirty()
        {
            base.MarkDirty();
        }
        private bool _newModified = false;
        public bool NewModified
        {
            get
            {
                return _newModified;
            }
        }

		#endregion

		#region Factory Methods
        public static UserDetails NewUserDetails(int u_id)
		{
            return Create(u_id);
		}

        public static UserDetails[] GetAllUserDetails(int al_user_id)
		{
            return Fetch(al_user_id).dataList;
		}
		#endregion

		#region Data Access
        protected override void PropertyHasChanged(string propertyName)
        {
            base.PropertyHasChanged(propertyName);
            _newModified = true;
        }
		[ServerMethod]
        private void FetchEntity(int al_user_id)
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT rds_user.u_id,  rds_user.u_name,  rds_user.u_location,  rds_user.u_phone,  rds_user.u_mobile,  rds_user.region_id,  rds_user_id.ui_userid,  rds_user_id.ui_password,  rds_user_id.ui_id  FROM rds_user,  rds_user_id  WHERE ( rds_user_id.u_id = rds_user.u_id ) and  ( ( rds_user_id.ui_id = :al_user_id ) )  ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_user_id", al_user_id);

                    List<UserDetails> list = new List<UserDetails>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
                            UserDetails instance = new UserDetails();
							instance.StoreFieldValues(dr, "rds_user");
							instance.StoreFieldValues(dr, "rds_user_id");
							instance.MarkOld();
							list.Add(instance);
						}
                        dataList = new UserDetails[list.Count];
						list.CopyTo(dataList);
                        StoreInitialValues();
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
                    try
                    {
                        cm.CommandText = "update  rds_user set u_name=@u_name,u_location=@u_location,u_phone=@u_phone,u_mobile=@u_mobile,region_id=@region_id  where   rds_user.u_id = @u_id ";
                        pList.Add(cm,"u_name",_rds_user_u_name);
                        pList.Add(cm,"u_location",_rds_user_u_location);
                        pList.Add(cm,"u_phone",_rds_user_u_phone);
                        pList.Add(cm,"u_mobile",_rds_user_u_mobile);
                        pList.Add(cm,"region_id",_rds_user_region_id);
                        pList.Add(cm,"u_id",_rds_user_u_id);

                        DBHelper.ExecuteNonQuery(cm, pList);

                    }
                    catch (Exception e) { Console.WriteLine(e.StackTrace); }
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
                //if (_rds_user_id_ui_id == null)
                //{
                //    _rds_user_id_ui_id = GetNextSequence(cm, "rdsUser");
                //}
				ParameterCollection pList = new ParameterCollection();
                //_rds_user_u_id = _rds_user_id_ui_id;
				if (GenerateInsertCommandText(cm, "rds_user",pList))
				{
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e) { Console.WriteLine(e.StackTrace); }
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
					pList.Add(cm,"u_id", GetInitialValue("_rds_user_u_id"));
						cm.CommandText = "DELETE FROM rds_user WHERE " +
						"rds_user.u_id = @u_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? u_id )
		{
            _rds_user_u_id = u_id;
		}
	}
}
