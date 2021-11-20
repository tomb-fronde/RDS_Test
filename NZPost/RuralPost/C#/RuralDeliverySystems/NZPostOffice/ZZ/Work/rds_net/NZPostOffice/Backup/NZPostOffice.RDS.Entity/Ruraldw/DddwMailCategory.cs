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
    [MapInfo("mc_key", "_mc_key", "")]
    [MapInfo("mc_description", "_mc_description", "")]
    [MapInfo("mc_mail_category", "_mc_mail_category", "")]
    [System.Serializable()]

    public class DddwMailCategory : Entity<DddwMailCategory>
    {
        #region Business Methods
        [DBField()]
        private int? _mc_key;

        [DBField()]
        private string _mc_description;

        [DBField()]
        private string _mc_mail_category;

        [DBField()]
        private string _in_Business;

        [DBField()]
        private string _in_Residential;

        [DBField()]
        private string _in_Farmer;
        
        public virtual int? McKey
        {
            get
            {
                CanReadProperty("McKey", true);
                return _mc_key;
            }
            set
            {
                CanWriteProperty("McKey", true);
                if (_mc_key != value)
                {
                    _mc_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string McDescription
        {
            get
            {
                CanReadProperty("McDescription", true);
                return _mc_description;
            }
            set
            {
                CanWriteProperty("McDescription", true);
                if (_mc_description != value)
                {
                    _mc_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string McMailCategory
        {
            get
            {
                CanReadProperty("McMailCategory", true);
                return _mc_mail_category;
            }
            set
            {
                CanWriteProperty("McMailCategory", true);
                if (_mc_mail_category != value)
                {
                    _mc_mail_category = value;
                    PropertyHasChanged();
                }
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[busflag]
        //in_Business
        public virtual string Busflag
        {
            get
            {
                CanReadProperty("Busflag", true);
                return _in_Business;
            }
            
        }
        // needs to implement compute expression manually:
        // compute control name=[resflag]
        //in_Residential
        public virtual string Resflag
        {
            get
            {
                CanReadProperty("Resflag", true);
                return _in_Residential;
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[farflag]
        //in_Farmer
        public virtual string Farflag
        {
            get
            {
                CanReadProperty("Farflag", true);
                return _in_Farmer;
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static DddwMailCategory NewDddwMailCategory(string in_Business, string in_Residential, string in_Farmer)
        {
            return Create(in_Business, in_Residential, in_Farmer);
        }

        public static DddwMailCategory[] GetAllDddwMailCategory(string in_Business, string in_Residential, string in_Farmer)
        {
            return Fetch(in_Business, in_Residential, in_Farmer).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(string in_Business, string in_Residential, string in_Farmer)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Business", in_Business);
                    pList.Add(cm, "in_Residential", in_Residential);
                    pList.Add(cm, "in_Farmer", in_Farmer);
                    cm.CommandText = "sp_DDDW_MailCategory";

                    List<DddwMailCategory> _list = new List<DddwMailCategory>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            DddwMailCategory instance = new DddwMailCategory();
                            instance._in_Business = in_Business;
                            instance._in_Residential = in_Residential;
                            instance._in_Farmer = in_Farmer;
                            instance._mc_key = GetValueFromReader<Int32?>(dr,0);
                            instance._mc_description = GetValueFromReader<String>(dr,1);
                            instance._mc_mail_category = GetValueFromReader<String>(dr,2);
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
