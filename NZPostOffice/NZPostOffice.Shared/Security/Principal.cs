using System;
using System.Collections.Generic;
using System.Text;

namespace NZPostOffice.Shared.Security
{
    [Serializable()]
    public class Principal : System.Security.Principal.GenericPrincipal
    {

        private Identity ID;
        public Principal(Identity id)
            : base(id, null)
        {
            this.ID = id;
        }

        #region IPrincipal Members

        public override System.Security.Principal.IIdentity Identity
        {
            get
            {
                return ID;
            }
        }

        public override bool IsInRole(string role)
        {
            return true;
        }

        #endregion
    }
}
