//qtdong
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
    [MapInfo("tname", "_tname", "sys.syscolumns")]
    [MapInfo("cname", "_cname", "sys.syscolumns")]
    [MapInfo("coltype", "_coltype", "sys.syscolumns")]
    [MapInfo("length", "_length", "sys.syscolumns")]
    [MapInfo("syslength", "_syslength", "sys.syscolumns")]
    [MapInfo("nulls", "_nulls", "sys.syscolumns")]
    [MapInfo("in_primary_key", "_in_primary_key", "sys.syscolumns")]
    [MapInfo("colno", "_colno", "sys.syscolumns")]
    [System.Serializable()]

    public class Datadict : Entity<Datadict>
    {
        #region Business Methods
        [DBField()]
        private string _tname;

        [DBField()]
        private string _cname;

        [DBField()]
        private string _coltype;

        [DBField()]
        private int? _length;

        [DBField()]
        private int? _syslength;

        [DBField()]
        private string _nulls;

        [DBField()]
        private string _in_primary_key;

        [DBField()]
        private int? _colno;

        public virtual string Tname
        {
            get
            {
                CanReadProperty("Tname", true);
                return _tname;
            }
            set
            {
                CanWriteProperty("Tname", true);
                if (_tname != value)
                {
                    _tname = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Cname
        {
            get
            {
                CanReadProperty("Cname", true);
                return _cname;
            }
            set
            {
                CanWriteProperty("Cname", true);
                if (_cname != value)
                {
                    _cname = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Coltype
        {
            get
            {
                CanReadProperty("Coltype", true);
                return _coltype;
            }
            set
            {
                CanWriteProperty("Coltype", true);
                if (_coltype != value)
                {
                    _coltype = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Length
        {
            get
            {
                CanReadProperty("Length", true);
                return _length;
            }
            set
            {
                CanWriteProperty("Length", true);
                if (_length != value)
                {
                    _length = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Syslength
        {
            get
            {
                CanReadProperty("Syslength", true);
                return _syslength;
            }
            set
            {
                CanWriteProperty("Syslength", true);
                if (_syslength != value)
                {
                    _syslength = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Nulls
        {
            get
            {
                CanReadProperty("Nulls", true);
                return _nulls;
            }
            set
            {
                CanWriteProperty("Nulls", true);
                if (_nulls != value)
                {
                    _nulls = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string InPrimaryKey
        {
            get
            {
                CanReadProperty("InPrimaryKey", true);
                return _in_primary_key;
            }
            set
            {
                CanWriteProperty("InPrimaryKey", true);
                if (_in_primary_key != value)
                {
                    _in_primary_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Colno
        {
            get
            {
                CanReadProperty("Colno", true);
                return _colno;
            }
            set
            {
                CanWriteProperty("Colno", true);
                if (_colno != value)
                {
                    _colno = value;
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
        public static Datadict NewDatadict(string user)
        {
            return Create(user);
        }

        public static Datadict[] GetAllDatadict(string user)
        {
            return Fetch(user).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(string user)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "user", user);
                    //GenerateSelectCommandText(cm, "sys.syscolumns");
                    cm.CommandText = "SELECT  syscolumns.tname ,"
                                               + "syscolumns.cname ,"
                                               + "syscolumns.coltype,"
                                               + "syscolumns.length,"
                                               + "syscolumns.syslength,"
                                               + "syscolumns.nulls,"
                                               + "syscolumns.in_primary_key,"
                                               + "syscolumns.colno"
                                               + " FROM sys.syscolumns"
                                               + "WHERE ( sys.syscolumns.creator like @user )   ";
                    List<Datadict> _list = new List<Datadict>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Datadict instance = new Datadict();
                            //instance.StoreFieldValues(dr, "sys.syscolumns");
                            instance._tname = GetValueFromReader<string>(dr, 0);
                            instance._cname = GetValueFromReader<string>(dr, 1);
                            instance._coltype = GetValueFromReader<string>(dr, 2);
                            instance._length = GetValueFromReader<Int32?>(dr, 3);
                            instance._syslength = GetValueFromReader<Int32?>(dr, 4);
                            instance._nulls = GetValueFromReader<string>(dr, 5);
                            instance._in_primary_key = GetValueFromReader<string>(dr, 6);
                            instance._colno = GetValueFromReader<Int32?>(dr, 7);
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
