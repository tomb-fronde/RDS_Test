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
    [MapInfo("coldef", "_coldef", "")]
    [System.Serializable()]

    public class Coldef : Entity<Coldef>
    {
        #region Business Methods
        [DBField()]
        private string _coldef;

        public virtual string ColdeF
        {
            get
            {
                CanReadProperty("ColdeF", true);
                return _coldef;
            }
            set
            {
                CanWriteProperty("ColdeF", true);
                if (_coldef != value)
                {
                    _coldef = value;
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
        public static Coldef NewColdef(string inTable, string inCreator)
        {
            return Create(inTable, inCreator);
        }

        public static Coldef[] GetAllColdef(string inTable, string inCreator)
        {
            return Fetch(inTable, inCreator).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(string inTable, string inCreator)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inTable", inTable);
                    pList.Add(cm, "inCreator", inCreator);
                    cm.CommandText = "sp_GetColDef";

                    List<Coldef> _list = new List<Coldef>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Coldef instance = new Coldef();
                            instance._coldef = GetValueFromReader<String>(dr, 0);
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
