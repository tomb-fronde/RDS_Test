using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  RPCR_026  June-2011: New
    // Adapted from DddwPbuCodes
	
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("sh_id", "_sh_id", "")]
    [MapInfo("sh_height", "_sh_height", "")]
    [MapInfo("sh_default", "_sh_default", "")]
    [System.Serializable()]

    public class DddwStripHeight : Entity<DddwStripHeight>
    {
        #region Business Methods
        [DBField()]
        private int? _sh_id;

        [DBField()]
        private int? _sh_height;

        [DBField()]
        private int? _sh_default;

        public virtual int? ShId
        {
            get
            {
                CanReadProperty("ShId", true);
                return _sh_id;
            }
            set
            {
                CanWriteProperty("ShId", true);
                if (_sh_id != value)
                {
                    _sh_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ShHeight
        {
            get
            {
                CanReadProperty("ShHeight", true);
                return _sh_height;
            }
            set
            {
                CanWriteProperty("ShHeight", true);
                if (_sh_height != value)
                {
                    _sh_height = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ShDefault
        {
            get
            {
                CanReadProperty("ShDefault", true);
                return _sh_default;
            }
            set
            {
                CanWriteProperty("ShDefault", true);
                if (_sh_default != value)
                {
                    _sh_default = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return _sh_height;
        }
        
        //ToString
        //public override string  ToString()
        //{
        //    return PbuCode.PadRight(15,' ') + PbuDescription;
        //} 
        #endregion

        #region Factory Methods
        public static DddwStripHeight NewDddwStripHeight()
        {
            return Create();
        }

        public static DddwStripHeight[] GetAllDddwStripHeight()
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
                    cm.CommandType = CommandType.Text;;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select sh_id, sh_height, sh_default "
                                   + "  from rd.strip_height "
                                   + " order by sh_default desc, sh_height";

                    List<DddwStripHeight> _list = new List<DddwStripHeight>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            DddwStripHeight instance = new DddwStripHeight();
                            instance._sh_id = GetValueFromReader<Int32?>(dr,0);
                            instance._sh_height = GetValueFromReader<Int32?>(dr,1);
                            instance._sh_default = GetValueFromReader<Int32?>(dr,2);
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
