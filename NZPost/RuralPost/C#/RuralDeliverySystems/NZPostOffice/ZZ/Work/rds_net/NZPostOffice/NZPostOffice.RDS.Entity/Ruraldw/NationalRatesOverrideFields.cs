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
	[MapInfo("ruc_rate", "_ruc_rate", "")]
	[System.Serializable()]

	public class NationalRatesOverrideFields : Entity<NationalRatesOverrideFields>
	{
		#region Business Methods
		[DBField()]
		private decimal?  _ruc_rate;

		public virtual decimal? RucRate
		{
			get
			{
                CanReadProperty("RucRate", true);
				return _ruc_rate;
			}
			set
			{
                CanWriteProperty("RucRate", true);
				if ( _ruc_rate != value )
				{
					_ruc_rate = value;
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
		public static NationalRatesOverrideFields NewNationalRatesOverrideFields(  )
		{
			return Create();
		}

		public static NationalRatesOverrideFields[] GetAllNationalRatesOverrideFields(  )
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

        //            List<NationalRatesOverrideFields> _list = new List<NationalRatesOverrideFields>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    NationalRatesOverrideFields instance = new NationalRatesOverrideFields();
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
