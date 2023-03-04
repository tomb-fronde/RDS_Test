using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  RPCR_054  June-2013: New
    // Retrieve the list of piece rate types, ordered in reverse prt_key
    // order so that new ones are first in the list (for DDddwPieceRateTypes).
    
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("prt_key", "_prt_key", "")]
    [MapInfo("prt_description", "_prt_description", "")]
    [MapInfo("prt_code", "_prt_code", "")]
    [System.Serializable()]

    public class DddwPieceRateTypes : Entity<DddwPieceRateTypes>
    {
        #region Business Methods
        [DBField()]
        private int? _prt_key;

        [DBField()]
        private string _prt_description;

        [DBField()]
        private string _prt_code;


        public virtual int? PrtKey
        {
            get
            {
                CanReadProperty("PrtKey", true);
                return _prt_key;
            }
            set
            {
                CanWriteProperty("PrtKey", true);
                if (_prt_key != value)
                {
                    _prt_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PrtDescription
        {
            get
            {
                CanReadProperty("PrtDescription", true);
                return _prt_description;
            }
            set
            {
                CanWriteProperty("PrtDescription", true);
                if (_prt_description != value)
                {
                    _prt_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PrtCode
        {
            get
            {
                CanReadProperty("PrtCode", true);
                return _prt_code;
            }
            set
            {
                CanWriteProperty("PrtCode", true);
                if (_prt_code != value)
                {
                    _prt_code = value;
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
        public static DddwPieceRateTypes NewDddwPieceRateTypes()
        {
            return Create();
        }

        public static DddwPieceRateTypes[] GetAllDddwPieceRateTypes()
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
                    cm.CommandText = "select prt_key, prt_description, prt_code "
                                   + "  from rd.piece_rate_type "
                                   + " order by prt_key desc";

                    List<DddwPieceRateTypes> _list = new List<DddwPieceRateTypes>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            DddwPieceRateTypes instance = new DddwPieceRateTypes();
                            instance._prt_key = GetValueFromReader<Int32?>(dr,0);
                            instance._prt_description = GetValueFromReader<String>(dr, 1);
                            instance._prt_code = GetValueFromReader<String>(dr, 2);
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
