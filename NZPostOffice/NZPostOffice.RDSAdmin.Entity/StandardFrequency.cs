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
	[MapInfo("sf_key", "_sf_key", "standard_frequency", true)]
	[MapInfo("sf_description", "_sf_description", "standard_frequency")]
	[MapInfo("sf_days_week", "_sf_days_week", "standard_frequency")]
	[System.Serializable()]

	public class StandardFrequency : Entity<StandardFrequency>
	{
		#region Business Methods
		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private string  _sf_description;

		[DBField()]
		private int?  _sf_days_week;


		public virtual int? SfKey
		{
			get
			{
				CanReadProperty(true);
				return _sf_key;
			}
			set
			{
				CanWriteProperty(true);
				if ( _sf_key != value )
				{
					_sf_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string SfDescription
		{
			get
			{
				CanReadProperty(true);
				return _sf_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _sf_description != value )
				{
					_sf_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? SfDaysWeek
		{
			get
			{
				CanReadProperty(true);
				return _sf_days_week;
			}
			set
			{
				CanWriteProperty(true);
				if ( _sf_days_week != value )
				{
					_sf_days_week = value;
					PropertyHasChanged();
				}
			}
		}
		private StandardFrequency[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _sf_key );
		}
		#endregion

		#region Factory Methods
        public static StandardFrequency NewStandardFrequency(int? sf_key)
		{
            return Create(sf_key);
		}

		public static StandardFrequency[] GetAllStandardFrequency(  )
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
					GenerateSelectCommandText(cm, "standard_frequency");

					List<StandardFrequency> list = new List<StandardFrequency>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							StandardFrequency instance = new StandardFrequency();
							instance.StoreFieldValues(dr, "standard_frequency");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new StandardFrequency[list.Count];
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
				if (GenerateUpdateCommandText(cm, "standard_frequency", ref pList))
				{
					cm.CommandText += " WHERE  standard_frequency.sf_key = @sf_key ";

					pList.Add(cm, "sf_key", GetInitialValue("_sf_key"));
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
				if (GenerateInsertCommandText(cm, "standard_frequency", pList))
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
					pList.Add(cm,"sf_key", GetInitialValue("_sf_key"));
						cm.CommandText = "DELETE FROM standard_frequency WHERE " +
						"standard_frequency.sf_key = @sf_key ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? sf_key )
		{
			_sf_key = sf_key;
		}
	}
}
