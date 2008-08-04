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
    [MapInfo("pbu_code", "_pbu_code", "")]
    [MapInfo("pbu_description", "_pbu_description", "")]
    [MapInfo("pbu_id", "_pbu_id", "")]
    [System.Serializable()]

    public class DddwPbuCodes : Entity<DddwPbuCodes>
    {
        #region Business Methods
        [DBField()]
        private string _pbu_code;

        [DBField()]
        private string _pbu_description;

        [DBField()]
        private int? _pbu_id;


        public virtual string PbuCode
        {
            get
            {
                CanReadProperty("PbuCode", true);
                return _pbu_code;
            }
            set
            {
                CanWriteProperty("PbuCode", true);
                if (_pbu_code != value)
                {
                    _pbu_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PbuDescription
        {
            get
            {
                CanReadProperty("PbuDescription", true);
                return _pbu_description;
            }
            set
            {
                CanWriteProperty("PbuDescription", true);
                if (_pbu_description != value)
                {
                    _pbu_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PbuId
        {
            get
            {
                CanReadProperty("PbuId", true);
                return _pbu_id;
            }
            set
            {
                CanWriteProperty("PbuId", true);
                if (_pbu_id != value)
                {
                    _pbu_id = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return _pbu_id;
        }
        
        //ToString
        public override string  ToString()
        {
            return PbuCode.PadRight(15,' ') + PbuDescription;
        } 
        #endregion

        #region Factory Methods
        public static DddwPbuCodes NewDddwPbuCodes()
        {
            return Create();
        }

        public static DddwPbuCodes[] GetAllDddwPbuCodes()
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
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "odps.od_cts_pbucodes";

                    List<DddwPbuCodes> _list = new List<DddwPbuCodes>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            DddwPbuCodes instance = new DddwPbuCodes();
                            instance._pbu_code = GetValueFromReader<String>(dr,0);
                            instance._pbu_description = GetValueFromReader<String>(dr,1);
                            instance._pbu_id = GetValueFromReader<Int32?>(dr,2);
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
