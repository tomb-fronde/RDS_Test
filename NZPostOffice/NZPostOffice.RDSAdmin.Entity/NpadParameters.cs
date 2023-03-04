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
	[MapInfo("npad_userid", "_npad_userid", "npad_parameters")]
	[MapInfo("npad_enabled", "_npad_enabled", "npad_parameters")]
	[MapInfo("npad_directory", "_npad_directory", "npad_parameters")]
	[System.Serializable()]

	public class NpadParameters : Entity<NpadParameters>
	{
		#region Business Methods
		[DBField()]
		private string  _npad_userid;

		[DBField()]
		private int?  _npad_enabled;

		[DBField()]
		private string  _npad_directory;


		public virtual string NpadUserid
		{
			get
			{
				CanReadProperty(true);
                return _npad_userid;// == "default" ? "default" : _npad_userid;
			}
			set
			{
				CanWriteProperty(true);
				if ( _npad_userid != value )
				{
					_npad_userid = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? NpadEnabled
		{
			get
			{
				CanReadProperty(true);
				return _npad_enabled;
			}
			set
			{
				CanWriteProperty(true);
				if ( _npad_enabled != value )
				{
					_npad_enabled = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string NpadDirectory
		{
			get
			{
				CanReadProperty(true);
				return _npad_directory;
			}
			set
			{
				CanWriteProperty(true);
				if ( _npad_directory != value )
				{
					_npad_directory = value;
					PropertyHasChanged();
				}
			}
		}
		private NpadParameters[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _npad_userid );
		}
		#endregion

		#region Factory Methods
        public static NpadParameters NewNpadParameters(string npad_userid)
		{
            return Create(npad_userid);
		}

		public static NpadParameters[] GetAllNpadParameters(  )
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
					GenerateSelectCommandText(cm, "npad_parameters");

					List<NpadParameters> list = new List<NpadParameters>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							NpadParameters instance = new NpadParameters();
							instance.StoreFieldValues(dr, "npad_parameters");
                            if(instance._npad_userid != null)
                                instance._npad_userid = instance._npad_userid.Trim();
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new NpadParameters[list.Count];
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
                if (GetInitialValue("_npad_userid") != null)
                {
                    cm.CommandText = "DELETE FROM npad_parameters WHERE " +
                        "npad_parameters.npad_userid = @npad_userid ";
                    pList.Add(cm, "npad_userid", GetInitialValue("_npad_userid"));
                }
                else
                    cm.CommandText = "DELETE FROM npad_parameters WHERE " +
                        "npad_parameters.npad_userid is null ";
                DBHelper.ExecuteNonQuery(cm, pList);
                if (GenerateInsertCommandText(cm, "npad_parameters", pList))
                {
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
				if (GenerateInsertCommandText(cm, "npad_parameters", pList))
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
					pList.Add(cm,"npad_userid", GetInitialValue("_npad_userid"));
						cm.CommandText = "DELETE FROM npad_parameters WHERE " +
						"npad_parameters.npad_userid = @npad_userid ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( string npad_userid )
		{
			_npad_userid = npad_userid;
		}
	}
}
