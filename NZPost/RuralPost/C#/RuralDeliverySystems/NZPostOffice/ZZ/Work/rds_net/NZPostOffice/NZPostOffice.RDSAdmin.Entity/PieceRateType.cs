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
	[MapInfo("prt_key", "_prt_key", "piece_rate_type", true)]
	[MapInfo("prt_description", "_prt_description", "piece_rate_type")]
	[MapInfo("prt_code", "_prt_code", "piece_rate_type")]
	[MapInfo("prt_print_on_schedule", "_prt_print_on_schedule", "piece_rate_type")]
	[MapInfo("prs_key", "_prs_key", "piece_rate_type")]
	[MapInfo("prs_true_value", "_prs_true_value", "piece_rate_type")]
	[System.Serializable()]

	public class PieceRateType : Entity<PieceRateType>
	{
		#region Business Methods
		[DBField()]
		private int?  _prt_key;

		[DBField()]
		private string  _prt_description;

		[DBField()]
		private string  _prt_code;

		[DBField()]
		private string  _prt_print_on_schedule;

		[DBField()]
		private int?  _prs_key;

		[DBField()]
		private string  _prs_true_value;


		public virtual int? PrtKey
		{
			get
			{
				CanReadProperty(true);
				return _prt_key;
			}
			set
			{
				CanWriteProperty(true);
				if ( _prt_key != value )
				{
					_prt_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PrtDescription
		{
			get
			{
				CanReadProperty(true);
				return _prt_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _prt_description != value )
				{
					_prt_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PrtCode
		{
			get
			{
				CanReadProperty(true);
				return _prt_code;
			}
			set
			{
				CanWriteProperty(true);
				if ( _prt_code != value )
				{
					_prt_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PrtPrintOnSchedule
		{
			get
			{
				CanReadProperty(true);
				return _prt_print_on_schedule;
			}
			set
			{
				CanWriteProperty(true);
				if ( _prt_print_on_schedule != value )
				{
					_prt_print_on_schedule = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? PrsKey
		{
			get
			{
				CanReadProperty(true);
				return _prs_key;
			}
			set
			{
				CanWriteProperty(true);
				if ( _prs_key != value )
				{
					_prs_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PrsTrueValue
		{
			get
			{
				CanReadProperty(true);
				return _prs_true_value;
			}
			set
			{
				CanWriteProperty(true);
				if ( _prs_true_value != value )
				{
					_prs_true_value = value;
					PropertyHasChanged();
				}
			}
		}
		private PieceRateType[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _prt_key );
		}
		#endregion

		#region Factory Methods
        public static PieceRateType NewPieceRateType(int? prt_key)
		{
            return Create(prt_key);
		}

		public static PieceRateType[] GetAllPieceRateType(  )
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
					GenerateSelectCommandText(cm, "piece_rate_type");

					List<PieceRateType> list = new List<PieceRateType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							PieceRateType instance = new PieceRateType();
							instance.StoreFieldValues(dr, "piece_rate_type");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new PieceRateType[list.Count];
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
				if (GenerateUpdateCommandText(cm, "piece_rate_type", ref pList))
				{
					cm.CommandText += " WHERE  piece_rate_type.prt_key = @prt_key ";

					pList.Add(cm, "prt_key", GetInitialValue("_prt_key"));
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
				if (GenerateInsertCommandText(cm, "piece_rate_type", pList))
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
					pList.Add(cm,"prt_key", GetInitialValue("_prt_key"));
						cm.CommandText = "DELETE FROM piece_rate_type WHERE " +
						"piece_rate_type.prt_key = @prt_key ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? prt_key )
		{
			_prt_key = prt_key;
		}
	}
}
