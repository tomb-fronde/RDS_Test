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
    [MapInfo("interest_id", "_id", "")]
    [MapInfo("interest_description", "_description", "")]
    [System.Serializable()]

    public class Interestlist : Entity<Interestlist>
    {
        #region Business Methods
        [DBField()]
        private int? _id;

        [DBField()]
        private string _description;


        public virtual int? Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
            set
            {
                CanWriteProperty("Id", true);
                if (_id != value)
                {
                    _id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Description
        {
            get
            {
                CanReadProperty("Description", true);
                return _description;
            }
            set
            {
                CanWriteProperty("Description", true);
                if (_description != value)
                {
                    _description = value;
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
        public static Interestlist NewInterestlist()
        {
            return Create();
        }

        public static Interestlist[] GetAllInterestlist()
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
                    cm.CommandText = "rd.sp_interest";
                    List<Interestlist> _list = new List<Interestlist>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Interestlist instance = new Interestlist();
                            instance._id = GetValueFromReader<Int32?>(dr,0);
                            instance._description = GetValueFromReader<String>(dr,1);
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
