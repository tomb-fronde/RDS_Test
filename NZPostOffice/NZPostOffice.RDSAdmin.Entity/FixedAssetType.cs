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
	[MapInfo("fat_id", "_fat_id", "fixed_asset_type",true)]
	[MapInfo("fat_description", "_fat_description", "fixed_asset_type")]
	[System.Serializable()]

	public class FixedAssetType : Entity<FixedAssetType>
	{
		#region Business Methods
		[DBField()]
		private int?  _fat_id;

		[DBField()]
		private string  _fat_description;


		public virtual int? FatId
		{
			get
			{
				CanReadProperty(true);
				return _fat_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _fat_id != value )
				{
					_fat_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string FatDescription
		{
			get
			{
				CanReadProperty(true);
				return _fat_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _fat_description != value )
				{
					_fat_description = value;
					PropertyHasChanged();
				}
			}
		}
		private FixedAssetType[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _fat_id );
		}
		#endregion

		#region Factory Methods
        public static FixedAssetType NewFixedAssetType(int? fat_id)
		{
            return Create(fat_id);
		}

		public static FixedAssetType[] GetAllFixedAssetType(  )
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
					GenerateSelectCommandText(cm, "fixed_asset_type");

					List<FixedAssetType> list = new List<FixedAssetType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							FixedAssetType instance = new FixedAssetType();
							instance.StoreFieldValues(dr, "fixed_asset_type");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new FixedAssetType[list.Count];
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
				if (GenerateUpdateCommandText(cm, "fixed_asset_type", ref pList))
				{
					cm.CommandText += " WHERE  fixed_asset_type.fat_id = @fat_id ";

					pList.Add(cm, "fat_id", GetInitialValue("_fat_id"));
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
				if (GenerateInsertCommandText(cm, "fixed_asset_type", pList))
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
					pList.Add(cm,"fat_id", GetInitialValue("_fat_id"));
						cm.CommandText = "DELETE FROM fixed_asset_type WHERE " +
						"fixed_asset_type.fat_id = @fat_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? fat_id )
		{
			_fat_id = fat_id;
		}
	}
}
