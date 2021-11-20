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
    [MapInfo("old_password", "_old_password", "")]
    [MapInfo("new_password", "_new_password", "")]
    [MapInfo("new_password_check", "_new_password_check", "")]
    [System.Serializable()]

    public class Password : Entity<Password>
    {
        #region Business Methods
        [DBField()]
        private string _old_password;

        [DBField()]
        private string _new_password;

        [DBField()]
        private string _new_password_check;

        public virtual string OldPassword
        {
            get
            {
                CanReadProperty("OldPassword", true);
                return _old_password;
            }
            set
            {
                CanWriteProperty("OldPassword", true);
                if (_old_password != value)
                {
                    _old_password = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string NewPassword
        {
            get
            {
                CanReadProperty("NewPassword", true);
                return _new_password;
            }
            set
            {
                CanWriteProperty("NewPassword", true);
                if (_new_password != value)
                {
                    _new_password = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string NewPasswordCheck
        {
            get
            {
                CanReadProperty("NewPasswordCheck", true);
                return _new_password_check;
            }
            set
            {
                CanWriteProperty("NewPasswordCheck", true);
                if (_new_password_check != value)
                {
                    _new_password_check = value;
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
        public static Password CreateNewPassword()
        {
            return Create();
        }

        public static Password[] GetAllPassword()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access

        //[ServerMethod]
        //private void FetchEntity()
        //{
        //    using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
        //    {
        //        using (DbCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.Text;
        //            ParameterCollection pList = new ParameterCollection();

        //            List<Password> _list = new List<Password>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    Password instance = new Password();
        //                    instance.MarkOld();
        //                    instance.StoreInitialValues();
        //                    _list.Add(instance);
        //                }
        //                list = _list.ToArray();
        //            }
        //        }
        //    }
        //}

        #endregion

        [ServerMethod()]
        private void CreateEntity()
        {
        }
    }
}
