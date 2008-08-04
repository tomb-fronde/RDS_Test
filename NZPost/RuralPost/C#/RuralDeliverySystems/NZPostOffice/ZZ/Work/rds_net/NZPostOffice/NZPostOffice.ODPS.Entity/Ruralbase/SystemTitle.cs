using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.Ruralbase
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("SystemTitle", "_systemtitle", "")]
    [MapInfo("SystemVersion", "_systemversion", "")]
    [System.Serializable()]

    public class SystemTitle : Entity<SystemTitle>
    {
        #region Business Methods
        [DBField()]
        private string _systemtitle = "Lightning Test Application";

        [DBField()]
        private string _systemversion = "1.1";


        public virtual string Systemtitle
        {
            get
            {
                CanReadProperty("Systemtitle", true);
                return _systemtitle;
            }
            set
            {
                CanWriteProperty("Systemtitle", true);
                if (_systemtitle != value)
                {
                    _systemtitle = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Compute1
        {
            get
            {
                CanReadProperty("Compute1", true);
                return "Version " + _systemversion.Trim();
            }

        }

        public virtual string Systemversion
        {
            get
            {
                CanReadProperty("Systemversion", true);
                return _systemversion;
            }
            set
            {
                CanWriteProperty("Systemversion", true);
                if (_systemversion != value)
                {
                    _systemversion = value;
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
        public static SystemTitle NewSystemTitle()
        {
            return Create();
        }

        public static SystemTitle[] GetAllSystemTitle()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();

                    List<SystemTitle> _list = new List<SystemTitle>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            SystemTitle instance = new SystemTitle();
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
