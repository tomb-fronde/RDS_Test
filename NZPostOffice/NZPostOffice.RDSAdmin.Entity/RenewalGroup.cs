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
	[MapInfo("rg_code", "_rg_code", "renewal_group",true)]
	[MapInfo("rg_description", "_rg_description", "renewal_group")]
	[MapInfo("rg_next_renewal_date", "_rg_next_renewal_date", "renewal_group")]
	[System.Serializable()]

	public class RenewalGroup : Entity<RenewalGroup>
	{
		#region Business Methods
		[DBField()]
		private int?  _rg_code;

		[DBField()]
		private string  _rg_description;

		[DBField()]
		private DateTime?  _rg_next_renewal_date;


		public virtual int? RgCode
		{
			get
			{
				CanReadProperty(true);
				return _rg_code;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rg_code != value )
				{
					_rg_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgDescription
		{
			get
			{
				CanReadProperty(true);
				return _rg_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rg_description != value )
				{
					_rg_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RgNextRenewalDate
		{
			get
			{
				CanReadProperty(true);
				return _rg_next_renewal_date;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rg_next_renewal_date != value )
				{
					_rg_next_renewal_date = value;
					PropertyHasChanged();
				}
			}
		}
		private RenewalGroup[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _rg_code );
		}
		#endregion

		#region Factory Methods
        public static RenewalGroup NewRenewalGroup(int? rg_code)
		{
            return Create(rg_code);
		}

		public static RenewalGroup[] GetAllRenewalGroup(  )
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
					GenerateSelectCommandText(cm, "renewal_group");

					List<RenewalGroup> list = new List<RenewalGroup>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							RenewalGroup instance = new RenewalGroup();
							instance.StoreFieldValues(dr, "renewal_group");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new RenewalGroup[list.Count];
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
				if (GenerateUpdateCommandText(cm, "renewal_group", ref pList))
				{
					cm.CommandText += " WHERE  renewal_group.rg_code = @rg_code ";

					pList.Add(cm, "rg_code", GetInitialValue("_rg_code"));
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
				if (GenerateInsertCommandText(cm, "renewal_group", pList))
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
					pList.Add(cm,"rg_code", GetInitialValue("_rg_code"));
						cm.CommandText = "DELETE FROM renewal_group WHERE " +
						"renewal_group.rg_code = @rg_code ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? rg_code )
		{
			_rg_code = rg_code;
		}
	}
}
