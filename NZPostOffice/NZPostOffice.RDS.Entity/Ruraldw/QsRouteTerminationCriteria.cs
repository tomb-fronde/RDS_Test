using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("Street", "_street_name", "")]
	[System.Serializable()]

	public class QsRouteTerminationCriteria : Entity<QsRouteTerminationCriteria>
	{
		#region Business Methods
		[DBField()]
		private string  _street_name;


		public virtual string StreetName
		{
			get
			{
                CanReadProperty("StreetName", true);
				return _street_name;
			}
			set
			{
                CanWriteProperty("StreetName", true);
				if ( _street_name != value )
				{
					_street_name = value;
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
		public static QsRouteTerminationCriteria NewQsRouteTerminationCriteria(  )
		{
			return Create();
		}

		public static QsRouteTerminationCriteria[] GetAllQsRouteTerminationCriteria(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
        //Exterior Data
        //[ServerMethod]
        //private void FetchEntity(  )
        //{
        //    using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
        //    {
        //        using (DbCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.Text;
        //            ParameterCollection pList = new ParameterCollection();

        //            List<QsRouteTerminationCriteria> _list = new List<QsRouteTerminationCriteria>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    QsRouteTerminationCriteria instance = new QsRouteTerminationCriteria();
        //                    instance.MarkOld();
        //                    _list.Add(instance);
        //                }
        //                list = _list.ToArray();
        //            }
        //        }
        //    }
        //}

		#endregion

		[ServerMethod()]
		private void CreateEntity(  )
		{
		}
	}
}
