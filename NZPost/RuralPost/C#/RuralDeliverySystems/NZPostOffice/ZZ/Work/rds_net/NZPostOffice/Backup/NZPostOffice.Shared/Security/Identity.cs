using System;
using System.Collections.Generic;
using System.Text;

namespace NZPostOffice.Shared.Security
{
    [Serializable()]
    public class Identity : Metex.Core.Security.ISessionIdentity
    {

        private string sUser;
        private string sPassword;
        private string connectionName;
        private string _sessionID; // field for serialize object
        private static Guid sessionID = Guid.Empty;

        public Identity(string sUser, string sPassword, string connectionName)
        {
            this.sUser = sUser;
            this.sPassword = sPassword;
            this.connectionName = connectionName;
            if (sessionID.Equals(Guid.Empty))
            {
                sessionID = Guid.NewGuid();
            }
            _sessionID = sessionID.ToString();
        }

        public string Password
        {
            get
            {
                return sPassword;
            }
        }

        public string SessionID
        {
            get
            {
                return _sessionID;
            }
        }

        public string DbConnectionName
        {
            get
            {
                return connectionName;
            }
        }

        #region IIdentity Members
        public string AuthenticationType
        {
            get
            {
                return "NZPOUser";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                //
                // To do: add LDAP authentication here
                //
                return true;
            }
        }

        public string Name
        {
            get
            {
                return sUser;
            }
        }
        #endregion
    }
}
