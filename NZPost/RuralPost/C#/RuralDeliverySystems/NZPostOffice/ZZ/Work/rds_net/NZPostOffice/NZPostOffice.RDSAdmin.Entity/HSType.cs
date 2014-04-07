using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;using Metex.Core;using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
    // TJB  RPCR_060  Mar-2014: NEW
    // TJB  RPCR_060  Apr-2014
    // Added hst_additional_date_errmsg and hst_notes_errmsg columns

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("hst_id", "_hst_id", "hs_type")]
	[MapInfo("hst_name", "_hst_name", "hs_type")]
    [MapInfo("hst_description", "_hst_description", "hs_type")]
    [MapInfo("hst_help", "_hst_help", "hs_type")]
    [MapInfo("hst_additional_date_errmsg", "_hst_additional_date_errmsg", "hs_type")]
    [MapInfo("hst_notes_errmsg", "_hst_notes_errmsg", "hs_type")]
    [System.Serializable()]

	public class HSType : Entity<HSType>
	{
		#region Business Methods
		[DBField()]
		private int?  _hst_id;

		[DBField()]
		private string  _hst_name;

        [DBField()]
        private string _hst_description;

        [DBField()]
        private string _hst_help;

        [DBField()]
        private string _hst_additional_date_errmsg;

        [DBField()]
        private string _hst_notes_errmsg;


		public virtual int? HstId
		{
			get
			{
				CanReadProperty("HstId",true);
                return _hst_id;
			}
			set
			{
                CanWriteProperty("HstId", true);
				if ( _hst_id != value )
				{
					_hst_id = value;
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
				if ( _hst_name != value )
				{
					_hst_name = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string HstDescription
        {
            get
            {
                CanReadProperty("HstDescription", true);
                return _hst_description;
            }
            set
            {
                CanWriteProperty("HstDescription", true);
                if (_hst_description != value)
                {
                    _hst_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string HstHelp
        {
            get
            {
                CanReadProperty("HstHelp", true);
                return _hst_help;
            }
            set
            {
                CanWriteProperty("HstHelp", true);
                if (_hst_help != value)
                {
                    _hst_help = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string HstAdditionalDateErrmsg
        {
            get
            {
                CanReadProperty("HstAdditionalDateErrmsg", true);
                return _hst_additional_date_errmsg;
            }
            set
            {
                CanWriteProperty("HstAdditionalDateErrmsg", true);
                if (_hst_additional_date_errmsg != value)
                {
                    _hst_additional_date_errmsg = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string HstNotesErrmsg
        {
            get
            {
                CanReadProperty("HstNotesErrmsg", true);
                return _hst_notes_errmsg;
            }
            set
            {
                CanWriteProperty("HstNotesErrmsg", true);
                if (_hst_notes_errmsg != value)
                {
                    _hst_notes_errmsg = value;
                    PropertyHasChanged();
                }
            }
        }


        private HSType[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _hst_id );
		}
		#endregion

		#region Factory Methods
        public static HSType NewHSType(int? hst_id)
		{
            return Create(hst_id);
		}

		public static HSType[] GetAllHSType(  )
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
					GenerateSelectCommandText(cm, "hs_type");

					List<HSType> list = new List<HSType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							HSType instance = new HSType();
							instance.StoreFieldValues(dr, "hs_type");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new HSType[list.Count];
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
				if (GenerateUpdateCommandText(cm, "hs_type", ref pList))
				{
					cm.CommandText += " WHERE  hs_type.hst_id = @hst_id ";

					pList.Add(cm, "hst_id", GetInitialValue("_hst_id"));
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
				if (GenerateInsertCommandText(cm, "hs_type", pList))
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
					pList.Add(cm,"hst_id", GetInitialValue("_hst_id"));
					cm.CommandText = "DELETE FROM hs_type "
                                   + " WHERE hs_type.hst_id = @hst_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? hst_id )
		{
			_hst_id = hst_id;
		}
	}
}
