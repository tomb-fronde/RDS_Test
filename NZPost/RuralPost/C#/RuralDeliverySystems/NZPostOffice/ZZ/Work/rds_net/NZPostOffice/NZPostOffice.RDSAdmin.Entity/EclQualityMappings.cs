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
	[MapInfo("ecl_column_name", "_ecl_column_name", "ecl_quality_mappings")]
	[MapInfo("ecl_match_string", "_ecl_match_string", "ecl_quality_mappings")]
	[MapInfo("ecl_match_type", "_ecl_match_type", "ecl_quality_mappings")]
	[MapInfo("ecl_substitute", "_ecl_substitute", "ecl_quality_mappings")]
	[System.Serializable()]

	public class EclQualityMappings : Entity<EclQualityMappings>
	public class PieceRateType : Entity<PieceRateType>
	{
		#region Business Methods
		[DBField()]
		private string  _ecl_column_name;

		[DBField()]
		private string  _ecl_match_string;

		[DBField()]
		private string  _ecl_match_type;

		[DBField()]
		private string  _ecl_substitute;


		public virtual string EclColumnName
		{
			get
			{
				CanReadProperty(true);
				return _ecl_column_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ecl_column_name != value )
				{
					_ecl_column_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string EclMatchString
		{
			get
			{
				CanReadProperty(true);
				return _ecl_match_string;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ecl_match_string != value )
				{
					_ecl_match_string = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string EclMatchType
		{
			get
			{
				CanReadProperty(true);
				return _ecl_match_type;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ecl_match_type != value )
				{
					_ecl_match_type = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string EclSubstitute
		{
			get
			{
				CanReadProperty(true);
				return _ecl_substitute;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ecl_substitute != value )
				{
					_ecl_substitute = value;
					PropertyHasChanged();
				}
			}
		}
		private EclQualityMappings[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _ecl_column_name );
		}
		#endregion

		#region Factory Methods
		public static EclQualityMappings NewEclQualityMappings(string ecl_column_name)
		{
			return Create(ecl_column_name);
		}

		public static EclQualityMappings[] GetAllEclQualityMappings(  )
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
					GenerateSelectCommandText(cm, "ecl_quality_mappings");

					List<EclQualityMappings> list = new List<EclQualityMappings>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							EclQualityMappings instance = new EclQualityMappings();
							instance.StoreFieldValues(dr, "ecl_quality_mappings");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new EclQualityMappings[list.Count];
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
				if (GenerateUpdateCommandText(cm, "ecl_quality_mappings", ref pList))
				{
					cm.CommandText += " WHERE ecl_quality_mappings.ecl_column_name = @ecl_column_name "
					                  + " AND ecl_quality_mappings.ecl_match_string = @ecl_match_string "
					                  + " AND ecl_quality_mappings.ecl_match_type = @ecl_match_type "
					                  ;
					pList.Add(cm,"ecl_column_name", GetInitialValue("_ecl_column_name"));
					pList.Add(cm,"ecl_match_string", GetInitialValue("_ecl_match_string"));
					pList.Add(cm,"ecl_match_type", GetInitialValue("_ecl_match_type"));
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
				if (GenerateInsertCommandText(cm, "ecl_quality_mappings", pList))
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
					cm.CommandText = "DELETE FROM ecl_quality_mappings " 
					                + "WHERE ecl_quality_mappings.ecl_column_name = @ecl_column_name "
					                + "  AND ecl_quality_mappings.ecl_match_string = @ecl_match_string "
					                + "  AND ecl_quality_mappings.ecl_match_type = @ecl_match_type "
					                ;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm,"ecl_column_name", GetInitialValue("_ecl_column_name"));
					pList.Add(cm,"ecl_match_string", GetInitialValue("_ecl_match_string"));
					pList.Add(cm,"ecl_match_type", GetInitialValue("_ecl_match_type"));
					
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( string ecl_column_name )
		{
			_ecl_column_name = ecl_column_name;
		}
	}
}
