using System;
using System.Collections.Generic;
using System.Text;

namespace NZPostOffice.Shared.Components
{
    public struct StSecurity
    {
        public bool security_on;
        //?     transaction		dbms_access
        public string userid;
        public string password;
        public long[] access_groups;
        public bool system_administrator;
        public string groupcargo;
        public string usercargo;
        public int region_id;
        public int u_usercode;
    }
}
