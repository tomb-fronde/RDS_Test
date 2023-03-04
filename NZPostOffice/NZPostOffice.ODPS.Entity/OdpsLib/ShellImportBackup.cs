using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsLib
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("column1", "_column1", "")]
    [MapInfo("column2", "_column2", "")]
    [MapInfo("column3", "_column3", "")]
    [MapInfo("column4", "_column4", "")]
    [MapInfo("column5", "_column5", "")]
    [MapInfo("column6", "_column6", "")]
    [MapInfo("column7", "_column7", "")]
    [MapInfo("column8", "_column8", "")]
    [MapInfo("column9", "_column9", "")]
    [MapInfo("column10", "_column10", "")]
    [MapInfo("column11", "_column11", "")]
    [MapInfo("column12", "_column12", "")]
    [MapInfo("column13", "_column13", "")]
    [MapInfo("column14", "_column14", "")]
    [MapInfo("column15", "_column15", "")]
    [MapInfo("column16", "_column16", "")]
    [MapInfo("column17", "_column17", "")]
    [MapInfo("column18", "_column18", "")]
    [System.Serializable()]

    public class ShellImportBackup : Entity<ShellImportBackup>
    {
        #region Business Methods
        [DBField()]
        private string _column1;

        [DBField()]
        private int? _column2;

        [DBField()]
        private int? _column3;

        [DBField()]
        private string _column4;

        [DBField()]
        private int? _column5;

        [DBField()]
        private string _column6;

        [DBField()]
        private string _column7;

        [DBField()]
        private string _column8;

        [DBField()]
        private int? _column9;

        [DBField()]
        private int? _column10;

        [DBField()]
        private int? _column11;

        [DBField()]
        private string _column12;

        [DBField()]
        private string _column13;

        [DBField()]
        private decimal? _column14;

        [DBField()]
        private decimal? _column15;

        [DBField()]
        private decimal? _column16;

        [DBField()]
        private decimal? _column17;

        [DBField()]
        private decimal? _column18;

        public virtual string Column1
        {
            get
            {
                CanReadProperty("Column1", true);
                return _column1;
            }
            set
            {
                CanWriteProperty("Column1", true);
                if (_column1 != value)
                {
                    _column1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Column2
        {
            get
            {
                CanReadProperty("Column2", true);
                return _column2;
            }
            set
            {
                CanWriteProperty("Column2", true);
                if (_column2 != value)
                {
                    _column2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Column3
        {
            get
            {
                CanReadProperty("Column3", true);
                return _column3;
            }
            set
            {
                CanWriteProperty("Column3", true);
                if (_column3 != value)
                {
                    _column3 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Column4
        {
            get
            {
                CanReadProperty("Column4", true);
                return _column4;
            }
            set
            {
                CanWriteProperty("Column4", true);
                if (_column4 != value)
                {
                    _column4 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Column5
        {
            get
            {
                CanReadProperty("Column5", true);
                return _column5;
            }
            set
            {
                CanWriteProperty("Column5", true);
                if (_column5 != value)
                {
                    _column5 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Column6
        {
            get
            {
                CanReadProperty("Column6", true);
                return _column6;
            }
            set
            {
                CanWriteProperty("Column6", true);
                if (_column6 != value)
                {
                    _column6 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Column7
        {
            get
            {
                CanReadProperty("Column7", true);
                return _column7;
            }
            set
            {
                CanWriteProperty("Column7", true);
                if (_column7 != value)
                {
                    _column7 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Column8
        {
            get
            {
                CanReadProperty("Column8", true);
                return _column8;
            }
            set
            {
                CanWriteProperty("Column8", true);
                if (_column8 != value)
                {
                    _column8 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Column9
        {
            get
            {
                CanReadProperty("Column9", true);
                return _column9;
            }
            set
            {
                CanWriteProperty("Column9", true);
                if (_column9 != value)
                {
                    _column9 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Column10
        {
            get
            {
                CanReadProperty("Column10", true);
                return _column10;
            }
            set
            {
                CanWriteProperty("Column10", true);
                if (_column10 != value)
                {
                    _column10 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Column11
        {
            get
            {
                CanReadProperty("Column11", true);
                return _column11;
            }
            set
            {
                CanWriteProperty("Column11", true);
                if (_column11 != value)
                {
                    _column11 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Column12
        {
            get
            {
                CanReadProperty("Column12", true);
                return _column12;
            }
            set
            {
                CanWriteProperty("Column12", true);
                if (_column12 != value)
                {
                    _column12 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Column13
        {
            get
            {
                CanReadProperty("Column13", true);
                return _column13;
            }
            set
            {
                CanWriteProperty("Column13", true);
                if (_column13 != value)
                {
                    _column13 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Column14
        {
            get
            {
                CanReadProperty("Column14", true);
                return _column14;
            }
            set
            {
                CanWriteProperty("Column14", true);
                if (_column14 != value)
                {
                    _column14 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Column15
        {
            get
            {
                CanReadProperty("Column15", true);
                return _column15;
            }
            set
            {
                CanWriteProperty("Column15", true);
                if (_column15 != value)
                {
                    _column15 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Column16
        {
            get
            {
                CanReadProperty("Column16", true);
                return _column16;
            }
            set
            {
                CanWriteProperty("Column16", true);
                if (_column16 != value)
                {
                    _column16 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Column17
        {
            get
            {
                CanReadProperty("Column17", true);
                return _column17;
            }
            set
            {
                CanWriteProperty("Column17", true);
                if (_column17 != value)
                {
                    _column17 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Column18
        {
            get
            {
                CanReadProperty("Column18", true);
                return _column18;
            }
            set
            {
                CanWriteProperty("Column18", true);
                if (_column18 != value)
                {
                    _column18 = value;
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
        public static ShellImportBackup NewShellImportBackup()
        {
            return Create();
        }

        public static ShellImportBackup[] GetAllShellImportBackup()
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

                    List<ShellImportBackup> _list = new List<ShellImportBackup>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ShellImportBackup instance = new ShellImportBackup();
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
