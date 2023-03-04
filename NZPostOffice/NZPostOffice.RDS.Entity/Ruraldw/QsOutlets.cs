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
    [MapInfo("outlet_id", "_outlet_id", "")]
    [MapInfo("o_name", "_o_name", "")]
    [MapInfo("ot_outlet_type", "_o_type", "")]
    [System.Serializable()]

    public class QsOutlets : Entity<QsOutlets>
    {
        #region Business Methods
        [DBField()]
        private int? _outlet_id;

        [DBField()]
        private string _o_name;

        [DBField()]
        private string _o_type;


        public virtual int? OutletId
        {
            get
            {
                CanReadProperty("OutletId", true);
                return _outlet_id;
            }
            set
            {
                CanWriteProperty("OutletId", true);
                if (_outlet_id != value)
                {
                    _outlet_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OName
        {
            get
            {
                CanReadProperty("OName", true);
                return _o_name;
            }
            set
            {
                CanWriteProperty("OName", true);
                if (_o_name != value)
                {
                    _o_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OType
        {
            get
            {
                CanReadProperty("OType", true);
                return _o_type;
            }
            set
            {
                CanWriteProperty("OType", true);
                if (_o_type != value)
                {
                    _o_type = value;
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
        public static QsOutlets NewQsOutlets(int? in_Region, string in_Outlet)
        {
            return Create(in_Region, in_Outlet);
        }

        public static QsOutlets[] GetAllQsOutlets(int? in_Region, string in_Outlet)
        {
            return Fetch(in_Region, in_Outlet).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_Region, string in_Outlet)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Region", in_Region);
                    pList.Add(cm, "in_Outlet", in_Outlet);
                    cm.CommandText = "rd.sp_qs_outlets";
                    List<QsOutlets> _list = new List<QsOutlets>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            QsOutlets instance = new QsOutlets();
                            instance._outlet_id = GetValueFromReader<Int32?>(dr,0);
                            instance._o_name = GetValueFromReader<String>(dr,1);
                            instance._o_type = GetValueFromReader<String>(dr,2);
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
        private void CreateEntity()
        {
        }
    }
}
