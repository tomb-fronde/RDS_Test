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
	[MapInfo("acdate", "_acdate", "")]
	[MapInfo("scaling_factor", "_scaling_factor", "")]
	[MapInfo("updateall", "_updateall", "")]
	[System.Serializable()]

	public class SetScalingFactor : Entity<SetScalingFactor>
	{
		#region Business Methods
		[DBField()]
		private DateTime?  _acdate;

		[DBField()]
		private decimal?  _scaling_factor;

		[DBField()]
		private string  _updateall="Y";


		public virtual DateTime? Acdate
		{
			get
			{
                CanReadProperty("Acdate", true);
				return _acdate;
			}
			set
			{
                CanWriteProperty("Acdate", true);
				if ( _acdate != value )
				{
					_acdate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? ScalingFactor
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

        //public virtual string Updateall
        //{
        //    get
        //    {
        //        CanReadProperty("Updateall", true);
        //        return _updateall;
        //    }
        //    set
        //    {
        //        CanWriteProperty("Updateall", true);
        //        if ( _updateall != value )
        //        {
        //            _updateall = value;
        //            PropertyHasChanged();
        //        }
        //    }
        //}

        public virtual bool? Updateall
        {
            get
            {
                CanReadProperty(true);
                return GetBoolean<string>(_updateall, "Y", "N");
            }
            set
            {
                CanWriteProperty(true);
                SetFromBoolean<string>(ref _updateall, value, "Y", "N");
            }
        }

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static SetScalingFactor NewSetScalingFactor(  )
		{
			return Create();
		}

		public static SetScalingFactor[] GetAllSetScalingFactor(  )
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

        //            List<SetScalingFactor> _list = new List<SetScalingFactor>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    SetScalingFactor instance = new SetScalingFactor();
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
