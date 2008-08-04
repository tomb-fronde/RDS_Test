using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core.Security;
using Metex.Core;

namespace NZPostOffice.Entity
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("old_password", "_old_password", "old_password")]
    [MapInfo("new_password", "_new_password", "new_password")]
    [MapInfo("new_password_check", "_new_password_check", "new_password_check")]
    [System.Serializable()]
    public class Password : Entity<GroupDetails>
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
                CanReadProperty(true);
                return _old_password;
            }
            set
            {
                CanWriteProperty(true);
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
                CanReadProperty(true);
                return _new_password;
            }
            set
            {
                CanWriteProperty(true);
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
                CanReadProperty(true);
                return _new_password_check;
            }
            set
            {
                CanWriteProperty(true);
                if (_new_password_check != value)
                {
                    _new_password_check = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return _old_password;
        }
        
        #endregion
    }
}
