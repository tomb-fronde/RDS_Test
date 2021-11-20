using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
    // TJB  July-2018
    // Reformatted fetch select statement for clarity

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("rgn_name", "_region_name", "region")]
	[MapInfo("region_id", "_region_id", "region")]
	[MapInfo("compute_0003", "_sel_ind", "region")]
	[System.Serializable()]

    public class UserRegion : Entity<UserRegion>
	{
		#region Business Methods
		[DBField()]
		private string  _region_name;

		[DBField()]
		private int?  _region_id;

		[DBField()]
		private int?  _sel_ind;


		public virtual string RegionName
		{
			get
			{
				CanReadProperty(true);
				return _region_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _region_name != value )
				{
					_region_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RegionId
		{
			get
			{
				CanReadProperty(true);
				return _region_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _region_id != value )
				{
					_region_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? SelInd
		{
			get
			{
				CanReadProperty(true);
				return _sel_ind;
			}
			set
			{
				CanWriteProperty(true);
				if ( _sel_ind != value )
				{
					_sel_ind = value;
					PropertyHasChanged();
				}
			}
		}
        private UserRegion[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
        public void MarkAsOld()
        {
            MarkOld();
        }
        public static UserRegion NewUserRegion()
		{
			return Create();
		}

        public static UserRegion[] GetAllUserRegion(int user_id)
		{
            return Fetch(user_id).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
        private void FetchEntity(int user_id)
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "user_id", user_id);
                    cm.CommandText = "SELECT region.rgn_name" 
                                    + "    , region.region_id" 
                                    + "    , 0 compute_0003 " 
                                    + " FROM region" 
                                    + "    , rds_user " 
                                    + "WHERE region.region_id <> rds_user.region_id" 
                                    + "  and rds_user.u_id = @user_id";

                    List<UserRegion> list = new List<UserRegion>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
                            UserRegion instance = new UserRegion();
							instance.StoreFieldValues(dr, "region");
							instance.MarkOld();
							list.Add(instance);
						}
                        dataList = new UserRegion[list.Count];
						list.CopyTo(dataList);
					}
				}
			}
		}

        [ServerMethod()]
        private void InsertEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("BAGPUSS"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandType = CommandType.Text;
                    GenerateInsertCommandText(cm, "region", pList);

                    DBHelper.ExecuteNonQuery(cm, pList);
                }
            }
            StoreInitialValues();
        }

		#endregion

		[ServerMethod()]
		private void CreateEntity(  )
		{
		}
	}
}
