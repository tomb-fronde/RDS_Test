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
    [MapInfo("Copys", "_copys", "")]
    [MapInfo("PageRange", "_pagerange", "")]
    [MapInfo("PageFrom", "_pagefrom", "")]
    [MapInfo("PageTo", "_pageto", "")]
    [System.Serializable()]

    public class PrintOptions : Entity<PrintOptions>
    {
        #region Business Methods
        [DBField()]
        private int? _copys;

        [DBField()]
        private string _pagerange;

        [DBField()]
        private int? _pagefrom;

        [DBField()]
        private int? _pageto;

        public virtual int? Copys
        {
            get
            {
                CanReadProperty("Copys", true);
                return _copys;
            }
            set
            {
                CanWriteProperty("Copys", true);
                if (_copys != value)
                {
                    _copys = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Pagerange
        {
            get
            {
                CanReadProperty("Pagerange", true);
                return _pagerange;
            }
            set
            {
                CanWriteProperty("Pagerange", true);
                if (_pagerange != value)
                {
                    _pagerange = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Pagefrom
        {
            get
            {
                CanReadProperty("Pagefrom", true);
                return _pagefrom;
            }
            set
            {
                CanWriteProperty("Pagefrom", true);
                if (_pagefrom != value)
                {
                    _pagefrom = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Pageto
        {
            get
            {
                CanReadProperty("Pageto", true);
                return _pageto;
            }
            set
            {
                CanWriteProperty("Pageto", true);
                if (_pageto != value)
                {
                    _pageto = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool PageRange1
        {
            get
            {
                return this._pagerange == "A";
            }
            set
            {
                this._pagerange = "A";
            }
        }

        public virtual bool PageRange2
        {
            get
            {
                return this._pagerange == "C";
            }
            set
            {
                this._pagerange = "C";
            }
        }

        public virtual bool PageRange3
        {
            get
            {
                return this._pagerange == "R";
            }
            set
            {
                this._pagerange = "R";
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static PrintOptions NewPrintOptions()
        {
            return Create();
        }

        public static PrintOptions[] GetAllPrintOptions()
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

                    List<PrintOptions> _list = new List<PrintOptions>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PrintOptions instance = new PrintOptions();
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
