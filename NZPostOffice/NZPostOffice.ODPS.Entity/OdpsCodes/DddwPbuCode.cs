using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsCodes
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("pbu_id", "_pbu_id", "")]
    [MapInfo("pbu_code", "_pbu_code", "")]
    [MapInfo("pbu_description", "_pbu_description", "")]
	[System.Serializable()]

	public class PbuCode : Entity<PbuCode>
	{
		#region Business Methods
		[DBField()]
		private int?  _pbu_id;

		[DBField()]
		private string  _pbu_code;

		[DBField()]
		private string  _pbu_description;

		public virtual int? PbuId
		{
			get
			{
				CanReadProperty("PbuId",true);
				return _pbu_id;
			}
			set
			{
				CanWriteProperty("PbuId",true);
				if ( _pbu_id != value )
				{
					_pbu_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Pbucode
		{
			get
			{
				CanReadProperty("Pbucode",true);
				return _pbu_code;
			}
			set
			{
				CanWriteProperty("Pbucode",true);
				if ( _pbu_code != value )
				{
					_pbu_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PbuDescription
		{
			get
			{
				CanReadProperty("PbuDescription",true);
				return _pbu_description;
			}
			set
			{
				CanWriteProperty("PbuDescription",true);
				if ( _pbu_description != value )
				{
					_pbu_description = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static PbuCode NewPbuCode(  )
		{
			return Create();
		}

		public static PbuCode[] GetAllPbuCode(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.sp_odps_dddw_pbu_codes";
                    ParameterCollection pList = new ParameterCollection();

                    List<PbuCode> _list = new List<PbuCode>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PbuCode instance = new PbuCode();
                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        list = _list.ToArray();
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
