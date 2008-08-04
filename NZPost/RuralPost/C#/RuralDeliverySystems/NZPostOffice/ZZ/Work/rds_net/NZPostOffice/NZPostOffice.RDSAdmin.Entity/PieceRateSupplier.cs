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
	[MapInfo("prs_key", "_prs_key", "piece_rate_supplier", true)]
	[MapInfo("prs_description", "_prs_description", "piece_rate_supplier")]
	[System.Serializable()]

	public class PieceRateSupplier : Entity<PieceRateSupplier>
	{
		#region Business Methods
		[DBField()]
		private int?  _prs_key;

		[DBField()]
		private string  _prs_description;


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

		public virtual string PrsDescription
		{
			get
			{
				CanReadProperty(true);
				return _prs_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _prs_description != value )
				{
					_prs_description = value;
					PropertyHasChanged();
				}
			}
		}
		private PieceRateSupplier[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _prs_key );
		}
		#endregion

		#region Factory Methods
        public static PieceRateSupplier NewPieceRateSupplier(int? prs_key)
		{
            return Create(prs_key);
		}

		public static PieceRateSupplier[] GetAllPieceRateSupplier(  )
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
					GenerateSelectCommandText(cm, "piece_rate_supplier");

					List<PieceRateSupplier> list = new List<PieceRateSupplier>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							PieceRateSupplier instance = new PieceRateSupplier();
							instance.StoreFieldValues(dr, "piece_rate_supplier");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new PieceRateSupplier[list.Count];
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
				if (GenerateUpdateCommandText(cm, "piece_rate_supplier", ref pList))
				{
					cm.CommandText += " WHERE  piece_rate_supplier.prs_key = @prs_key ";

					pList.Add(cm, "prs_key", GetInitialValue("_prs_key"));
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
				if (GenerateInsertCommandText(cm, "piece_rate_supplier", pList))
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
					pList.Add(cm,"prs_key", GetInitialValue("_prs_key"));
						cm.CommandText = "DELETE FROM piece_rate_supplier WHERE " +
						"piece_rate_supplier.prs_key = @prs_key ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? prs_key )
		{
			_prs_key = prs_key;
		}
	}
}
