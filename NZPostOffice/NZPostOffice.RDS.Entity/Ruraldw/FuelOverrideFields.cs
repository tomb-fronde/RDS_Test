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
	[MapInfo("ad_effective_date", "_ad_effective_date", "")]
	[MapInfo("al_renewal_group", "_al_renewal_group", "")]
	[System.Serializable()]

	public class FuelOverrideFields : Entity<FuelOverrideFields>
	{
		#region Business Methods
		[DBField()]
		private DateTime?  _ad_effective_date;

		[DBField()]
		private int?  _al_renewal_group;


		public virtual DateTime? AdEffectiveDate
		{
			get
			{
                CanReadProperty("AdEffectiveDate", true);
				return _ad_effective_date;
			}
			set
			{
                CanWriteProperty("AdEffectiveDate", true);
				if ( _ad_effective_date != value )
				{
					_ad_effective_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? AlRenewalGroup
		{
			get
			{
                CanReadProperty("AlRenewalGroup", true);
				return _al_renewal_group;
			}
			set
			{
                CanWriteProperty("AlRenewalGroup", true);
				if ( _al_renewal_group != value )
				{
					_al_renewal_group = value;
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
		public static FuelOverrideFields NewFuelOverrideFields(  )
		{
			return Create();
		}

		public static FuelOverrideFields[] GetAllFuelOverrideFields(  )
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

        //            List<FuelOverrideFields> _list = new List<FuelOverrideFields>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    FuelOverrideFields instance = new FuelOverrideFields();
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
