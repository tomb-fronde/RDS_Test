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
	[MapInfo("ug_id", "_ug_id", "rds_user_group")]
	[MapInfo("ug_name", "_ug_name", "rds_user_group")]
	[MapInfo("ug_description", "_ug_description", "rds_user_group")]
	[MapInfo("ug_privacy_override", "_ug_privacy_override", "rds_user_group")]
	[MapInfo("ug_created_date", "_ug_created_date", "rds_user_group")]
	[MapInfo("ug_created_by", "_ug_created_by", "rds_user_group")]
	[MapInfo("ug_modified_date", "_ug_modified_date", "rds_user_group")]
	[MapInfo("ug_modified_by", "_ug_modified_by", "rds_user_group")]
	[System.Serializable()]

	public class GroupHeader : RDSEntityBase<GroupHeader>
	{
		#region Business Methods
		[DBField()]
		private int?  _ug_id;

		[DBField()]
		private string  _ug_name;

		[DBField()]
		private string  _ug_description;

		[DBField()]
		private string  _ug_privacy_override;

		[DBField()]
		private DateTime?  _ug_created_date;

		[DBField()]
		private string  _ug_created_by;

		[DBField()]
		private DateTime?  _ug_modified_date;

		[DBField()]
		private string  _ug_modified_by;


		public virtual int? UgId
		{
			get
			{
				CanReadProperty(true);
				return _ug_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ug_id != value )
				{
					_ug_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string UgName
		{
			get
			{
				CanReadProperty(true);
				return _ug_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ug_name != value )
				{
					_ug_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string UgDescription
		{
			get
			{
				CanReadProperty(true);
				return _ug_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ug_description != value )
				{
					_ug_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual bool? UgPrivacyOverride
		{
			get
			{
				CanReadProperty(true);				
                return GetBoolean(_ug_privacy_override, "Y", "N", false);
			}
			set
			{
				CanWriteProperty(true);
                SetFromBoolean(ref _ug_privacy_override, value, "Y", "N");
			}
		}

		public virtual DateTime? UgCreatedDate
		{
			get
			{
				CanReadProperty(true);
				return _ug_created_date;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ug_created_date != value )
				{
					_ug_created_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string UgCreatedBy
		{
			get
			{
				CanReadProperty(true);
				return _ug_created_by;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ug_created_by != value )
				{
					_ug_created_by = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? UgModifiedDate
		{
			get
			{
				CanReadProperty(true);
				return _ug_modified_date;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ug_modified_date != value )
				{
					_ug_modified_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string UgModifiedBy
		{
			get
			{
				CanReadProperty(true);
				return _ug_modified_by;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ug_modified_by != value )
				{
					_ug_modified_by = value;
					PropertyHasChanged();
				}
			}
		}
		private GroupHeader[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _ug_id );
		}
		#endregion

		#region Factory Methods
		public static GroupHeader NewGroupHeader( int? al_group_id, string userId)
		{
            return Create(al_group_id, userId);
		}

		public static GroupHeader[] GetAllGroupHeader( int? al_group_id )
		{
			return Fetch(al_group_id).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? al_group_id )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_group_id", al_group_id);
					GenerateSelectCommandText(cm, "rds_user_group");
                    cm.CommandText += " where  rds_user_group.ug_id = @al_group_id";

					List<GroupHeader> list = new List<GroupHeader>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							GroupHeader instance = new GroupHeader();
							instance.StoreFieldValues(dr, "rds_user_group");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new GroupHeader[list.Count];
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
                _ug_modified_date = DateTime.Now;
				if (GenerateUpdateCommandText(cm, "rds_user_group", ref pList))
				{
					cm.CommandText += " WHERE  rds_user_group.ug_id = @ug_id ";

					pList.Add(cm, "ug_id", GetInitialValue("_ug_id"));
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {

                    }
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
                //_ug_id = GetNextSequence(cm, "rdsUserGroup");
                _ug_created_date = DateTime.Now;
				ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "rds_user_group", pList))
				{
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				StoreInitialValues();
			}
        }
        //[ServerMethod()]
        //private int GetNextSequence(string sequenceName)
        //{
        //    int sequence = 0;
        //    using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
        //    {
        //        DbCommand cm = cn.CreateCommand();
        //        cm.CommandType = CommandType.Text;
        //        ParameterCollection pList = new ParameterCollection();
        //        cm.CommandText = "select next_value from id_codes where sequence_name = @sequenceName";
        //        pList.Add(cm, "sequenceName", sequenceName);
        //        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //        {
        //            if (dr.Read())
        //            {
        //                sequence = dr.GetInt32(0);
        //            }
        //        }
        //        if (sequence == 0)
        //        {
        //            cm.CommandText = "insert into id_codes (sequence_name, next_value) values (@sequenceName, 2)";
        //            DBHelper.ExecuteNonQuery(cm, pList);
        //            sequence = 1;
        //        }
        //        else
        //        {
        //            cm.CommandText = "update id_codes set next_value = @next_value  where sequence_name = @sequenceName";
        //            pList.Add(cm, "next_value", (sequence + 1));
        //            DBHelper.ExecuteNonQuery(cm, pList);
        //        }
        //    }
        //    return sequence--;
        //}
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
					pList.Add(cm,"ug_id", GetInitialValue("_ug_id"));
						cm.CommandText = "DELETE FROM rds_user_group WHERE " +
						"rds_user_group.ug_id = @ug_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
        private void CreateEntity(int? ug_id, string userId)
		{
			_ug_id = ug_id;
            _ug_created_by = userId;
		}
	}
}
