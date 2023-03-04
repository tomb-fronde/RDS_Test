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
	[MapInfo("ot_code", "_ot_code", "outlet_type")]
	[MapInfo("ot_outlet_type", "_ot_outlet_type", "outlet_type")]
	[System.Serializable()]

	public class DddwOutletType : Entity<DddwOutletType>
	{
		#region Business Methods
		[DBField()]
		private int?  _ot_code;

		[DBField()]
		private string  _ot_outlet_type;


		public virtual int? OtCode
		{
			get
			{
				CanReadProperty(true);
				return _ot_code;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ot_code != value )
				{
					_ot_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OtOutletType
		{
			get
			{
				CanReadProperty(true);
				return _ot_outlet_type;
			}
			set
			{
				CanWriteProperty(true);
				if ( _ot_outlet_type != value )
				{
					_ot_outlet_type = value;
					PropertyHasChanged();
				}
			}
		}
		private DddwOutletType[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _ot_code );
		}
		#endregion

		#region Factory Methods
		public static DddwOutletType NewDddwOutletType(  )
		{
			return Create();
		}

		public static DddwOutletType[] GetAllDddwOutletType(  )
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
					GenerateSelectCommandText(cm, "outlet_type");

					List<DddwOutletType> list = new List<DddwOutletType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwOutletType instance = new DddwOutletType();
							instance.StoreFieldValues(dr, "outlet_type");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new DddwOutletType[list.Count];
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
				if (GenerateUpdateCommandText(cm, "outlet_type", ref pList))
				{
					cm.CommandText += " WHERE  outlet_type.ot_code = @ot_code ";

					pList.Add(cm, "ot_code", GetInitialValue("_ot_code"));
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
				if (GenerateInsertCommandText(cm, "outlet_type", pList))
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
					pList.Add(cm,"ot_code", GetInitialValue("_ot_code"));
						cm.CommandText = "DELETE FROM outlet_type WHERE " +
						"outlet_type.ot_code = @ot_code ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? ot_code )
		{
			_ot_code = ot_code;
		}
	}
}
