using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.Shared.Managers;
using System.Windows.Forms;
using NZPostOffice.Shared.Components;

namespace NZPostOffice.Shared
{
    public class StaticVariables
    {
        public static int userId = 0;
        public static string LoginId = "";
        public static string DisplayName = "";

        public static bool gb_cust_list_seq;
        public static bool gb_cust_list_recip;
        public static bool gb_cust_list_cat;
        public static bool gb_cust_list_kiwi;
        public static string gs_cust_list_sort;
        public static string gs_report_sort;
        public static object URdsDwName =null;

        public static Form MainMDI
        {
            get 
            {
                return curAppContext.MainForm as Form;
            }
        }

        private static ApplicationContext curAppContext;
        public static ApplicationContext CurAppContext
        {
            set 
            {
                curAppContext=value;
            }
        }
        private static Security.SecurityManager _securitymanager;

        public static Security.SecurityManager securitymanager
        {
            get
            {
                if (_securitymanager == null && gnv_app != null)
                    _securitymanager = gnv_app.of_get_securitymanager();
                return _securitymanager;
            }
        }

        public static AppManager gnv_app = new AppManager();

        public static StSecurity g_security = new StSecurity();

        public static Object window;//added by ylwang use to pass the window
    }
}
