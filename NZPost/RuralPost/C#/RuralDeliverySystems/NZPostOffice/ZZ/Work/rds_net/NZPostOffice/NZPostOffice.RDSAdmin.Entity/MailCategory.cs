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
	[MapInfo("mc_key", "_mc_key", "mail_category")]
	[MapInfo("mc_description", "_mc_description", "mail_category")]
	[MapInfo("mc_mail_category", "_mc_mail_category", "mail_category")]
	[System.Serializable()]

	public class MailCategory : Entity<MailCategory>
	{
		#region Business Methods
		[DBField()]
		private int?  _mc_key;

		[DBField()]
		private string  _mc_description;

		[DBField()]
		private string  _mc_mail_category;


		public virtual int? McKey
		{
			get
			{
				CanReadProperty(true);
				return _mc_key;
			}
			set
			{
				CanWriteProperty(true);
				if ( _mc_key != value )
				{
					_mc_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string McDescription
		{
			get
			{
				CanReadProperty(true);
				return _mc_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _mc_description != value )
				{
					_mc_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string McMailCategory
		{
			get
			{
				CanReadProperty(true);
				return _mc_mail_category;
			}
			set
			{
				CanWriteProperty(true);
				if ( _mc_mail_category != value )
				{
					_mc_mail_category = value;
					PropertyHasChanged();
				}
			}
		}
		private MailCategory[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _mc_key );
		}
		#endregion

		#region Factory Methods
		public static MailCategory NewMailCategory(  )
		{
			return Create();
		}

		public static MailCategory[] GetAllMailCategory(  )
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
					GenerateSelectCommandText(cm, "mail_category");

					List<MailCategory> list = new List<MailCategory>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							MailCategory instance = new MailCategory();
							instance.StoreFieldValues(dr, "mail_category");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new MailCategory[list.Count];
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
				if (GenerateUpdateCommandText(cm, "mail_category", ref pList))
				{
					cm.CommandText += " WHERE  mail_category.mc_key = @mc_key ";

					pList.Add(cm, "mc_key", GetInitialValue("_mc_key"));
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
				if (GenerateInsertCommandText(cm, "mail_category", pList))
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
					pList.Add(cm,"mc_key", GetInitialValue("_mc_key"));
						cm.CommandText = "DELETE FROM mail_category WHERE " +
						"mail_category.mc_key = @mc_key ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? mc_key )
		{
			_mc_key = mc_key;
		}
	}
}
