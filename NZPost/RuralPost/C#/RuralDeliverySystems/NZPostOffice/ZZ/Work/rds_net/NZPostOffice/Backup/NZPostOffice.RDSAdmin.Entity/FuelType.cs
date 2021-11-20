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
	[MapInfo("ft_key", "_ft_key", "fuel_type", true)]
	[MapInfo("ft_description", "_ft_description", "fuel_type")]
	[System.Serializable()]

	public class FuelType : Entity<FuelType>
	{
		#region Business Methods
		[DBField()]
		private int?  _ft_key;

		[DBField()]
		private string  _ft_description;


		public virtual int? FtKey
		{
			get
			{
				CanReadProperty(true);
				return _ft_key;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ft_key != value )
				{
					_ft_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string FtDescription
		{
			get
			{
				CanReadProperty(true);
				return _ft_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ft_description != value )
				{
					_ft_description = value;
					PropertyHasChanged();
				}
			}
		}
        private FuelType[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _ft_key );
		}
		#endregion

		#region Factory Methods
        public static FuelType NewFuelType(int? ft_key)
		{
            return Create(ft_key);
		}

		public static FuelType[] GetAllFuelType(  )
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
					GenerateSelectCommandText(cm, "fuel_type");

					List<FuelType> list = new List<FuelType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							FuelType instance = new FuelType();
							instance.StoreFieldValues(dr, "fuel_type");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new FuelType[list.Count];
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
				if (GenerateUpdateCommandText(cm, "fuel_type", ref pList))
				{
					cm.CommandText += " WHERE  fuel_type.ft_key = @ft_key ";

					pList.Add(cm, "ft_key", GetInitialValue("_ft_key"));
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
				if (GenerateInsertCommandText(cm, "fuel_type", pList))
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
					pList.Add(cm,"ft_key", GetInitialValue("_ft_key"));
						cm.CommandText = "DELETE FROM fuel_type WHERE " +
						"fuel_type.ft_key = @ft_key ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? ft_key )
		{
			_ft_key = ft_key;
		}
	}
}
