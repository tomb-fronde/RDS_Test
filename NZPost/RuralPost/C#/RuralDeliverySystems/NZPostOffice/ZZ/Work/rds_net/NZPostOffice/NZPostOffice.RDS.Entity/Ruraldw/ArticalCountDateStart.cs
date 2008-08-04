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
    [MapInfo("region_id", "_region_id", "")]
    [MapInfo("rg_code", "_rg_code", "")]
    [MapInfo("weekstart", "_weekstart", "")]
    [System.Serializable()]

    public class ArticalCountDateStart : Entity<ArticalCountDateStart>
    {
        #region Business Methods
        [DBField()]
        private int? _region_id;

        [DBField()]
        private int? _rg_code;

        [DBField()]
        private DateTime? _weekstart;

        public virtual int? RegionId
        {
            get
            {
                CanReadProperty("RegionId", true);
                return _region_id;
            }
            set
            {
                CanWriteProperty("RegionId", true);
                if (_region_id != value)
                {
                    _region_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RgCode
        {
            get
            {
                CanReadProperty("RgCode", true);
                return _rg_code;
            }
            set
            {
                CanWriteProperty("RgCode", true);
                if (_rg_code != value)
                {
                    _rg_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? Weekstart
        {
            get
            {
                CanReadProperty("Weekstart", true);
                return _weekstart;
            }
            set
            {
                CanWriteProperty("Weekstart", true);
                if (_weekstart != value)
                {
                    _weekstart = value;
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
        public static ArticalCountDateStart NewArticalCountDateStart()
        {
            return Create();
        }

        public static ArticalCountDateStart[] GetAllArticalCountDateStart()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access
        //Exterior Data
        //[ServerMethod]
        //private void FetchEntity(  )
        //{
        //    using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( ))
        //    {
        //        using (DbCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.Text;
        //            ParameterCollection pList = new ParameterCollection();

        //            List<ArticalCountDateStart> _list = new List<ArticalCountDateStart>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    ArticalCountDateStart instance = new ArticalCountDateStart();
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
        private void CreateEntity()
        {
        }
    }
}
