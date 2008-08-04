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
	[MapInfo("scaling_factor", "_scaling_factor", "")]
	[System.Serializable()]

	public class SetArticalCountsScalingFactor : Entity<SetArticalCountsScalingFactor>
	{
		#region Business Methods
		[DBField()]
		private double?  _scaling_factor;


		public virtual double? ScalingFactor
		{
			get
			{
                CanReadProperty("ScalingFactor", true);
				return _scaling_factor;
			}
			set
			{
                CanWriteProperty("ScalingFactor", true);
				if ( _scaling_factor != value )
				{
					_scaling_factor = value;
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
		public static SetArticalCountsScalingFactor NewSetArticalCountsScalingFactor(  )
		{
			return Create();
		}

		public static SetArticalCountsScalingFactor[] GetAllSetArticalCountsScalingFactor(  )
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

        //            List<SetArticalCountsScalingFactor> _list = new List<SetArticalCountsScalingFactor>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    SetArticalCountsScalingFactor instance = new SetArticalCountsScalingFactor();
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
