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
    [MapInfo("prs_key", "_prs_key", "")]
    [MapInfo("prs_description", "_prs_description", "")]
    [System.Serializable()]

    public class DddwPieceRateSuppliers : Entity<DddwPieceRateSuppliers>
    {
        #region Business Methods
        [DBField()]
        private int? _prs_key;

        [DBField()]
        private string _prs_description;


        public virtual int? PrsKey
        {
            get
            {
                CanReadProperty("PrsKey", true);
                return _prs_key;
            }
            set
            {
                CanWriteProperty("PrsKey", true);
                if (_prs_key != value)
                {
                    _prs_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PrsDescription
        {
            get
            {
                CanReadProperty("PrsDescription", true);
                return _prs_description;
            }
            set
            {
                CanWriteProperty("PrsDescription", true);
                if (_prs_description != value)
                {
                    _prs_description = value;
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
        public static DddwPieceRateSuppliers NewDddwPieceRateSuppliers()
        {
            return Create();
        }

        public static DddwPieceRateSuppliers[] GetAllDddwPieceRateSuppliers()
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
                    cm.CommandText = "sp_DDDW_PieceRateSuppliers";

                    List<DddwPieceRateSuppliers> _list = new List<DddwPieceRateSuppliers>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            DddwPieceRateSuppliers instance = new DddwPieceRateSuppliers();
                            instance._prs_key = GetValueFromReader<Int32?>(dr,0);
                            instance._prs_description = GetValueFromReader<String>(dr,1);
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
