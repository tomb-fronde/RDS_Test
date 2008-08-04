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
	[MapInfo("suppno", "_suppno", "")]
	[MapInfo("suppname", "_suppname", "")]
	[System.Serializable()]

	public class QsContractorCriteria : Entity<QsContractorCriteria>
	{
		#region Business Methods
		[DBField()]
		private int?  _suppno;

		[DBField()]
		private string  _suppname;


		public virtual int? Suppno
		{
			get
			{
                CanReadProperty("Suppno", true);
				return _suppno;
			}
			set
			{
                CanWriteProperty("Suppno", true);
				if ( _suppno != value )
				{
					_suppno = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Suppname
		{
			get
			{
                CanReadProperty("Suppname", true);
				return _suppname;
			}
			set
			{
                CanWriteProperty("Suppname", true);
				if ( _suppname != value )
				{
					_suppname = value;
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
		public static QsContractorCriteria NewQsContractorCriteria(  )
		{
			return Create();
		}

		public static QsContractorCriteria[] GetAllQsContractorCriteria(  )
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

        //            List<QsContractorCriteria> _list = new List<QsContractorCriteria>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    QsContractorCriteria instance = new QsContractorCriteria();
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
