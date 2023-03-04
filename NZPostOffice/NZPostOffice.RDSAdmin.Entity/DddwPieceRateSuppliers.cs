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
    [MapInfo("prs_key", "_prs_key", "piece_rate_supplier")]
    [MapInfo("prs_description", "_prs_description", "piece_rate_supplier")]
	[System.Serializable()]

	public class PieceRateSuppliers : Entity<PieceRateSuppliers>
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
		private PieceRateSuppliers[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static PieceRateSuppliers NewDddwPieceRateSuppliers(  )
		{
			return Create();
		}

		public static PieceRateSuppliers[] GetAllDddwPieceRateSuppliers(  )
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
                    GenerateSelectCommandText(cm, "piece_rate_supplier");
					ParameterCollection pList = new ParameterCollection();

					List<PieceRateSuppliers> list = new List<PieceRateSuppliers>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							PieceRateSuppliers instance = new PieceRateSuppliers();
                            instance.StoreFieldValues(dr, "piece_rate_supplier");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new PieceRateSuppliers[list.Count];
						list.CopyTo(dataList);
					}
				}
			}
		}

		#endregion

		[ServerMethod()]
		private void CreateEntity(  )
		{
		}
	}
}
