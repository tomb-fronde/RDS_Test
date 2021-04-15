using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.Shared.Security;
using NZPostOffice.Shared.VisualComponents;
using System.Windows.Forms;
using NZPostOffice.DataService;
using System.IO;

namespace NZPostOffice.Shared.Managers
{
    // TJB  NPAD2  December 2005  
    // Added variables to specify the state of NPAD processing  
    // Retrieved from NPAD_parameters table in database on login 
    // of_get_npadenabled(), of_get_npaddirectory() New

    public class AppManager
    {
        #region For ODPS

        public NCstObjectMsg inv_ObjectMsg = new NCstObjectMsg();

        #endregion

        #region For RDS

        // Constant 
        //?public NRdsConstant inv_Constant;

        // Secure On Flag 
        public bool ib_Secure = true;

        public NDdeParameters ist_dde_parameters = new NDdeParameters();

        public string is_helpURL = "";

        public string is_startupDir = String.Empty;

        public SecurityManager inv_Security_Manager;

        public string is_npadfilename = String.Empty;

        public string is_npadoutfile = String.Empty;

        public string is_npadoutdir = String.Empty;

        public string is_Title = String.Empty;

        public string is_version = String.Empty;

        public string is_Type = String.Empty;

        //?public WAncestorWindow iw_Active_Sheet;

        public NParameters inv_parameters=new NParameters();

        public string is_Commandline = String.Empty;

        public int il_total_contract_types = -(1);

        //?public n_MenuCache inv_MenuCache;

        public object inv_Road;

        public string is_ComponentToOpen = String.Empty;

        public int il_NumRegions;

        //  TJB  NPAD2  December 2005  Variables to specify the state of NPAD processing  Retrieved from NPAD_parameters table in database on login 
        public bool ib_npad_enabled = true;

        public string is_npad_directory = "";

        //?private st_system ist_system;
        private FormBase iw_frame;

        public string is_userid = String.Empty;

        private string is_appinifile = String.Empty;

        private string is_stripmakerFile = string.Empty;

        public AppManager()
        {
            pfc_open();
        }

        public virtual void pfc_open()
        {
            this.of_setappinifile(AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE").ToString());
            this.of_load_dde_parameters();
            of_setstripmakerini(ist_dde_parameters.iniFile);
        }

        public virtual int of_load_dde_parameters()
        {
            ist_dde_parameters.ddetopicname = StaticFunctions.ConfigString(this.of_getappinifile(), "WordProcessor", "DDETopicName", "Winword");
            ist_dde_parameters.wordprocessorpath = StaticFunctions.ConfigString(this.of_getappinifile(), "WordProcessor", "WordProcessorPath", "C:\\Program Files\\Microsoft Office\\Office\\WINWORD.EXE");
            ist_dde_parameters.customertemplate = StaticFunctions.ConfigString(this.of_getappinifile(), "MailMergeFiles", "CustomerTemplate", "C:\\Program Files\\RuralPost\\RDS.NET\\CustomerTemplate.dot");
            ist_dde_parameters.ownerdrivertemplate = StaticFunctions.ConfigString(this.of_getappinifile(), "MailMergeFiles", "OwnerDriverTemplate", "C:\\Program Files\\RuralPost\\RDS.NET\\OwnerDriverTemplate.dot");
            ist_dde_parameters.custmailmergedumpfile = StaticFunctions.ConfigString(this.of_getappinifile(), "MailMergeFiles", "CustMailMergeDumpFile", "C:\\Temp\\CustomerData.xls");
            ist_dde_parameters.ownerdrivermailmergedumpfile = StaticFunctions.ConfigString(this.of_getappinifile(), "MailMergeFiles", "OwnerDriverMailMergeDumpFile", "C:\\Temp\\ODPSData.xls");
            ist_dde_parameters.iniFile = StaticFunctions.ConfigString(this.of_getappinifile(), "Stripmaker", "IniFile", "C:\\RDSRuntime\\stripmaker.ini");
            StaticFunctions.SetConfigString(this.of_getappinifile(), "WordProcessor", "DDETopicName", ist_dde_parameters.ddetopicname);
            StaticFunctions.SetConfigString(this.of_getappinifile(), "WordProcessor", "WordProcessorPath", ist_dde_parameters.wordprocessorpath);
            StaticFunctions.SetConfigString(this.of_getappinifile(), "MailMergeFiles", "CustomerTemplate", ist_dde_parameters.customertemplate);
            StaticFunctions.SetConfigString(this.of_getappinifile(), "MailMergeFiles", "OwnerDriverTemplate", ist_dde_parameters.ownerdrivertemplate);
            StaticFunctions.SetConfigString(this.of_getappinifile(), "MailMergeFiles", "CustMailMergeDumpFile", ist_dde_parameters.custmailmergedumpfile);
            StaticFunctions.SetConfigString(this.of_getappinifile(), "MailMergeFiles", "OwnerDriverMailMergeDumpFile", ist_dde_parameters.ownerdrivermailmergedumpfile);
            StaticFunctions.SetConfigString(this.of_getappinifile(), "Stripmaker", "IniFile", ist_dde_parameters.iniFile);
            return 0;
        }

        public virtual string of_getstripmakerini()
        {
            return is_stripmakerFile;
        }

        public virtual int of_getinivalue(string as_file, string as_section, string as_key, ref string as_value) {
           
            bool lb_sectionfound = false;
            bool lb_keyfound = false;
            string[] li_file;
            int li_rc;
            int li_keys;
            int ll_pos;
            int ll_first;
            int ll_last;
            int ll_equal;
            string ls_line;
            string ls_key;
            string ls_value;
            string ls_section;
            string ls_comment;
            //  SetPointer ( Hourglass!)
            // messagebox (  'tjb','of_getIniValue called with:\r' &
            // 			+ 'as_file    = ' + as_file + '\r' &
            // 			+ 'as_section = ' + as_section + '\r' &
            // 			+ 'as_key     = ' + as_key + '\r' &
            // 			+ 'as_value   = ' + as_value )
            //  Verify that .INI file name has been specified.
            if (!(File.Exists(as_file))) {
                return -(2);
            }
            //  Open file  ( check rc).
            li_file = File.ReadAllLines(as_file);//,FileOpen(as_file, linemode!);
            if (li_file.Length<= 0){// == -(1)) {
                return -(1);
            }
            //  reset the value coming in
            as_value = "";
            li_keys = 0;
            // ////////////////////////////////////////////////////////////////////////////
            //  Find the correct section name
            // ////////////////////////////////////////////////////////////////////////////
            //while (li_rc >= 0 && !lb_sectionfound) {
            li_rc = 0;
            while (li_rc < li_file.Length && !lb_sectionfound) {
                //  Read one line from the inifile  ( check rc).
                //li_rc = li_file.Read(ls_line,);
                ls_line = li_file[li_rc];
                li_rc++;
                //if (li_rc == -(1)) {
                //    return -(1);
                //}
                //  Check if any characters were read.
                if (li_rc > 0) {
                    //  Look for a section header components  ( the OpenBracket and CloseBracket  ( if any)).
                    ll_first = ls_line.IndexOf('[');
                    ll_last = ls_line.IndexOf( ']');
                    //  Was a section header found?		
                    if (ll_first >= 0 && ll_last >= 0) {
                        //  Yes, a section header has been found.
                        //  Get the name of the section.
                        ls_line = ls_line.TrimStart();// LeftTrim(ls_line);
                        if (ls_line.Substring(0, 1) == "[") {
                            ll_pos = ls_line.IndexOf(']');
                            ls_section = ls_line.Substring(1, ll_pos - 1);
                            //  Determine if this is the section being searched for.								
                            if (ls_section.ToLower() == as_section.ToLower()) {
                                //  The search for section has been found.
                                lb_sectionfound = true;
                                //  messagebox (  'tjb','of_getIniValue Section found' )
                            }
                        }
                    }
                }
            }
            // ////////////////////////////////////////////////////////////////////////////
            //  Retrieve all keys and their values for the section
            // ////////////////////////////////////////////////////////////////////////////
            if (lb_sectionfound) {
                lb_keyfound = false;
                while (li_rc < li_file.Length && !lb_keyfound)
                {
                    //  Read one line from the file  ( validate the rc).
                    //li_rc = li_file.Read(ls_line);
                    ls_line = li_file[li_rc];
                    li_rc++;
                    //if (li_rc == -(1)) {
                    //    return -(1);
                    //}
                    //  Check if any characters were read.		
                    if (li_rc > 0) {
                        //  Check for a "commented" line  ( skip if found).
                        ls_comment = ls_line.TrimStart();
                         if (ls_comment.StartsWith(";")) {
                            continue;
                        }
                        //  Parse the line.  Look for lines like
                        // 		key = value
                        // 		[ new_section ]
                        // 		key
                        //  Blank lines will be skipped
                        ll_equal = ls_line.IndexOf('=');
                        if (ll_equal > 0) {
                            ls_key = (ls_line.Substring(0, ll_equal - 1)).Trim();
                            ls_value = ls_line.Substring( ll_equal + 1).Trim();
                            if ( ls_key.Length > 0 && ls_key.ToLower() == as_key.ToLower()) {
                                if (ls_value.Length > 0)
                                {
                                    as_value = ls_value;
                                }
                                else {
                                    as_value = ".";
                                }
                                li_keys = 1;
                                lb_keyfound = true;
                                //  messagebox (  'tjb','of_getIniValue: Key found; Value = ' + ls_value )
                            }
                        }
                        else if (ls_line.IndexOf( '[') > 0) {
                            ll_first = ls_line.IndexOf( '[');
                            ll_last = ls_line.IndexOf(']');
                            if (ll_first > 0 && ll_last > 0) {
                                ls_line = ls_line.TrimStart();
                                if (ls_line.Substring(0, 1) == "[") {
                                    as_value = "";
                                    li_keys = 0;
                                    lb_keyfound = true;
                                    //  messagebox (  'tjb','of_getIniValue: Key not found' )
                                }
                            }
                        }
                        else {
                            ls_key =  ls_line.Trim();
                            if (ls_key.Length > 0 && ls_key.ToLower() == as_key.ToLower())
                            {
                                as_value = ".";
                                li_keys = 1;
                                lb_keyfound = true;
                                //  messagebox (  'tjb','of_getIniValue: Key found; Value = <none>' )
                            }
                        }
                    }
                }
            }
            // ////////////////////////////////////////////////////////////////////////////
            //  Close file and return
            // ////////////////////////////////////////////////////////////////////////////
            //?li_file.Close();
            return li_keys;
        }


        public virtual int of_setstripmakerini(string as_file)
        { 
            if(as_file == null)
            {
                is_stripmakerFile = "";
                return -1;
            }
            is_stripmakerFile = as_file;
            return 1;
        }
        public virtual int of_initialise_security()
        {
            // Enable Security Services
            inv_Security_Manager = new SecurityManager();
            inv_Security_Manager.of_initialise(ib_Secure);
            return 1;
        }

        public virtual SecurityManager of_get_securitymanager()
        {
            // Purpose: 	Return an instance of the security manager
            // Author:	Rex Bustria
            return inv_Security_Manager;
        }

        public virtual string of_getversion()
        {
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Function:  of_GetVersion
            // 
            // 	Access:  public
            // 
            // 	Arguments:  none
            // 
            // 	Returns:  String   the current application version.
            // 
            // 	Description:  Returns the application version.
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Revision History
            // 
            // 	Version
            // 	5.0   Initial version
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Copyright © 1996-1997 Sybase, Inc. and its subsidiaries.  All rights reserved.
            // 	Any distribution of the PowerBuilder Foundation Classes  ( PFC)
            // 	source code by other than Sybase, Inc. and its subsidiaries is prohibited.
            // 
            // ////////////////////////////////////////////////////////////////////////////
            return is_version;
        }

        public virtual string of_get_title()
        {
            // Purpose: 	Return the application title
            // Author:	Rex Bustria
            return is_Title;
        }

        public virtual bool of_isempty(string cString)
        {
            return (cString == null) || cString.Trim().Length == 0;
        }

        public virtual NParameters of_get_parameters()
        {
            return inv_parameters;
        }

        public virtual int of_set_componenttoopen(string as_ComponentName)
        {
            is_ComponentToOpen = as_ComponentName;
            return 1;
        }

        public virtual System.Drawing.Color of_getcolorcode(string aColor)
        {
            // //////////////////////////////////////////////////////////////////////////////////////////////
            // 
            //  Function: 	f_GetColorCode
            // 
            //  Purpose:
            //  Returns the color code belonging to the cpecified color
            // 
            //  Example:
            // 	st_password.color = f_GetColorCode ( "Black")		
            // 
            // 
            //  Scope:	Public
            // 
            //  Parameters:
            //  string	the color you want returned
            // 
            // 
            //  Returns:	long	the colors long code
            // 
            //  Log:
            // 
            //    DATE			WHO		WHAT
            //    ----------	-------	---------------------------------
            //    AUG 1994		DAR		Initial Development
            // 	  29/01/1995	DAR		Conversion to PB 4.0
            // 
            // //////////////////////////////////////////////////////////////////////////////////////////////
            System.Drawing.Color lReturn = System.Drawing.Color.Empty;
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = aColor.ToUpper();
            if (TestExpr == "WHITE")
            {
                lReturn = System.Drawing.Color.FromArgb(255, 255, 255);// 16777215;
            }
            else if (TestExpr == "GREY")
            {
                lReturn = System.Drawing.Color.FromArgb(192, 192, 192);//12632256;
            }
            else if (TestExpr == "DARK GREY")
            {
                lReturn = System.Drawing.Color.FromArgb(128, 128, 128);//8421504;
            }
            else if (TestExpr == "BLACK")
            {
                lReturn = System.Drawing.Color.FromArgb(0, 0, 0);// 0;
            }
            else if (TestExpr == "RED")
            {
                lReturn = System.Drawing.Color.FromArgb(0, 0, 500);//255;
            }
            else if (TestExpr == "YELLOW")
            {
                lReturn = System.Drawing.Color.FromArgb(0, 255, 255);//65535;
            }
            else if (TestExpr == "GREEN")
            {
                lReturn = System.Drawing.Color.FromArgb(0, 255, 0);//65280;
            }
            else if (TestExpr == "CYAN")
            {
                lReturn = System.Drawing.Color.FromArgb(255, 255, 0);//16776960;
            }
            else if (TestExpr == "BLUE")
            {
                lReturn = System.Drawing.Color.FromArgb(255, 0, 0);//16711680;
            }
            else if (TestExpr == "MAGENTA")
            {
                lReturn = System.Drawing.Color.FromArgb(255, 0, 255);//16711935;
            }
            else if (TestExpr == "DARK RED")
            {
                lReturn = System.Drawing.Color.FromArgb(0, 0, 128);//128;
            }
            else if (TestExpr == "DARK YELLOW")
            {
                lReturn = System.Drawing.Color.FromArgb(0, 128, 128);//32896;
            }
            else if (TestExpr == "DARK GREEN")
            {
                lReturn = System.Drawing.Color.FromArgb(0, 128, 0);//32768;
            }
            else if (TestExpr == "DARK CYAN")
            {
                lReturn = System.Drawing.Color.FromArgb(128, 128, 0);//8421376;
            }
            else if (TestExpr == "DARK BLUE")
            {
                lReturn = System.Drawing.Color.FromArgb(128, 0, 0);//8388608;
            }
            else if (TestExpr == "DARK MAGENTA")
            {
                lReturn = System.Drawing.Color.FromArgb(128, 0, 128);//8388736;
            }
            return lReturn;
        }

        public virtual FormBase of_getframe()
        {
            return iw_frame;
        }

        public virtual int of_setframe(FormBase aw_frame)
        {
            iw_frame = aw_frame;
            return 1;
        }

        public virtual string of_getuserid()
        {
            //return is_userid;
            return StaticVariables.LoginId;
        }

        public virtual bool of_get_npadenabled()
        {
            return ib_npad_enabled;
        }
        
        public virtual int of_get_nextcontract(int aContractType) 
        {
            int lReturn;
            int lNextValue;
            if (StaticFunctions.f_nempty(aContractType)) 
            {
                lReturn = -(1);
            }
            else 
            {
                /*SELECT ct_next_contract  
                INTO :lNextValue  
                FROM contract_type  
                WHERE ct_key = :aContractType;*/
                int sqlCode = -1;
                lNextValue = LoginService.GetCTContract(aContractType, ref sqlCode);
                if (sqlCode != 0) 
                {
                    lReturn = -(1);
                }
                else 
                {
                    lReturn = lNextValue;
                    /*UPDATE contract_type SET ct_next_contract = :lNextValue + 1
                    WHERE ct_key = :aContractType;*/
                    LoginService.UpdateContractType(lNextValue, aContractType);
                }
            }
            return lReturn;
        }
        public virtual bool of_sanedate(DateTime? adt_date, string as_column)
        {   // Returns true if date is OK
            DateTime dtCheck;
            DialogResult iBox;

            dtCheck = DateTime.Today.AddDays(90);
            iBox = DialogResult.Yes;

            // A null date is OK
            if (!adt_date.HasValue) 
            {
                return true;
            }

            if (dtCheck < adt_date)
            {
                iBox = MessageBox.Show("The date you have chosen for " + as_column 
                                      + " is more than 90 days in the future.\n" 
                                      + "Are you sure you want to use this date?"
                                      , "Date Sanity Check"
                                      , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                dtCheck = DateTime.Today.AddDays(-90);
                if (dtCheck > adt_date)
                {
                    iBox = MessageBox.Show("The date you have chosen for " + as_column 
                                          + " is more than 90 days in the past.\n" 
                                          + "Are you sure you want to use this date?"
                                          , "Date Sanity Check"
                                          , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
            }            
            if (iBox == DialogResult.Yes)
                return true;
            else
                return false;
        }

        public virtual int of_checkdigit(string aaccount)
        {
            int[] aWeightings = new int[14];
            int lLoop;
            int lLength;
            int lDivider = 0;
            int lNumber;
            int lTotal = 0;
            int iReturn = 1;
            string sNumber=string.Empty ;
            string TestExpr = aaccount.Substring(0, 2);
            if (TestExpr == "01" || TestExpr == "02" || TestExpr == "03" || TestExpr == "06" || TestExpr == "11" || TestExpr == "12" || TestExpr == "13" || TestExpr == "14" || TestExpr == "15" || TestExpr == "16" || TestExpr == "17" || TestExpr == "18" || TestExpr == "19" || TestExpr == "20" || TestExpr == "21" || TestExpr == "22" || TestExpr == "23" || TestExpr == "24" || TestExpr == "27" || TestExpr == "30" || TestExpr == "31" || TestExpr == "38")
            {
                aWeightings = new int[] { 6, 3, 7, 9, 0, 10, 5, 8, 4, 2, 1, 0, 0, 0 };
                lDivider = 11;
            }
            else if (TestExpr == "08")
            {
                aWeightings = new int[] { 0, 0, 0, 0, 7, 6, 5, 4, 3, 2, 1, 0, 0, 0 };
                lDivider = 11;
            }
            else if (TestExpr == "09")
            {
                aWeightings = new int[] { 0, 0, 0, 0, 0, 0, 0, 5, 4, 3, 2, 1, 0, 0 };
                lDivider = 11;
            }
            else if (TestExpr == "25" || TestExpr == "33")
            {
                aWeightings = new int[] { 0, 0, 0, 0, 1, 7, 3, 1, 7, 3, 1, 0, 0, 0 };
                lDivider = 10;
            }
            else if (TestExpr == "29")
            {
                aWeightings = new int[] { 0, 0, 0, 0, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1 };
                lDivider = 10;
            }
            else
            {
                iReturn = -(1);
            }
            if (iReturn == 1)
            {
                for (lLoop = 0; lLoop < 14; lLoop++)
                {
                    if (lLoop < aaccount.Length - 2)  //jlwang:for check the length
                        sNumber = aaccount.Substring(lLoop + 2, 1);
                    int l_temp = 0;
                    if (int.TryParse(sNumber, out l_temp))
                    {
                        lNumber = System.Convert.ToInt32(sNumber);
                        lTotal = lTotal + lNumber * aWeightings[lLoop];
                    }
                }
                iReturn = lTotal % lDivider;
            }
            return iReturn;
        }

        public virtual Form of_findwindow(string as_title, string as_classname, FormBase aw_sheet)
        {
            string sTitle;
            FormBase lw_Blank = null;
            FormBase lw_CurrentSheet;
            Cursor.Current = Cursors.WaitCursor;
            lw_CurrentSheet = aw_sheet;
            while ((lw_CurrentSheet != null))
            {
                if (lw_CurrentSheet.Name.ToUpper() == as_classname.ToUpper())
                {
                    if (as_title.Length > 0)
                    {
                        if (lw_CurrentSheet.Text.ToUpper() == as_title.ToUpper())
                        {
                            lw_CurrentSheet.BringToFront();
                            return lw_CurrentSheet;
                        }
                    }
                    else
                    {
                        lw_CurrentSheet.BringToFront();
                        return lw_CurrentSheet;
                    }
                }
                else
                {
                    // not found
                }
                lw_CurrentSheet = of_getframe().GetNextSheet(lw_CurrentSheet);
            }
            return lw_Blank;
        }

        public virtual Form of_findwindow(string as_title, string as_classname)
        {
            string sTitle;
            FormBase lw_Blank = null;
            FormBase lw_CurrentSheet;
            Cursor.Current = Cursors.WaitCursor;
            lw_CurrentSheet = of_getframe().GetFirstSheet();
            while ((lw_CurrentSheet != null))
            {
                if (lw_CurrentSheet.Name.ToUpper() == as_classname.ToUpper())
                {
                    if (as_title.Length > 0)
                    {
                        if (lw_CurrentSheet.Text.ToUpper() == as_title.ToUpper())
                        {
                            lw_CurrentSheet.BringToFront();
                            return lw_CurrentSheet;
                        }
                    }
                    else
                    {
                        lw_CurrentSheet.BringToFront();
                        return lw_CurrentSheet;
                    }
                }
                else
                {
                }
                lw_CurrentSheet = of_getframe().GetNextSheet(lw_CurrentSheet);
            }
            return lw_Blank;
        }

        public virtual int of_get_nextsequence(string sequencename)
        {
            int nReturn;
            int nNextValue = 0;
            if (StaticVariables.gnv_app.of_isempty(sequencename))
            {
                nReturn = -(1);
            }
            else
            {
                // move to loginservice
                ////select next_value into :nNextValue from id_codes where sequence_name = :sequencename ;
                //if (StaticVariables.sqlca.SQLCode != 0) 
                //{
                //    //insert into id_codes (sequence_name, next_value) values (:sequencename, 2) ;
                //    nReturn = 1;
                //}
                //else 
                //{
                //    nReturn = nNextValue;
                //    //UPDATE id_codes set next_value = :nNextValue + 1 where sequence_name = :sequencename ;
                //}
                nReturn = LoginService.SetComplexSql(sequencename);
            }
            //commit;
            return nReturn;
        }

        public virtual string of_get_componentopened()
        {
            return is_ComponentToOpen;
        }

        public virtual int of_get_numregions()
        {
            if (!(il_NumRegions > 0))
            {
                /*Select count ( *) into :il_NumRegions from region;*/
                il_NumRegions = LoginService.GetRegionCount();
            }
            return il_NumRegions;
        }

        public virtual int of_gettotalcontracttypes()
        {
            if (il_total_contract_types == -(1))
            {
                of_settotalcontracttypes();
            }
            return il_total_contract_types;
        }

        public virtual int of_settotalcontracttypes()
        {
            //?Metex.Windows.DataUserControl lds_temp;
            //lds_temp = new n_ds();
            //lds_temp.DataObject = "d_dddw_contract_types";
            //?lds_temp = new DDddwContractTypes();
            //?lds_temp.of_settransobject(StaticVariables.sqlca);
            //?lds_temp.Retrieve();
            //il_total_contract_types = lds_temp.RowCount;
            il_total_contract_types = LoginService.GetContractTypeCount();
            return 1;
        }

        public virtual string of_get_npaddirectory()
        {
            int ll_npadEnabled;
            string ls_userid;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            ls_userid = this.of_getuserid();
            /*select npad_enabled, npad_directory
            into :ll_npadEnabled, :is_npad_Directory
            from npad_parameters
            where npad_userid = :ls_userid
            using SQLCA;*/
                LoginService loginservice;
                loginservice = LoginService.GetNPADParameters(ls_userid, ref SQLCode, ref SQLErrText);
                ll_npadEnabled = loginservice.intVal;
                is_npad_directory = loginservice.strVal;
                if (SQLCode == 100)
                {
                    /* select npad_enabled, npad_directory
                     into :ll_npadEnabled, :is_npad_Directory
                     from npad_parameters
                     where npad_userid = 'default'
                     using SQLCA;*/
                    loginservice = LoginService.GetNpadParametersDefault(ref SQLCode, ref SQLErrText);
                    ll_npadEnabled = loginservice.intVal;
                    is_npad_directory = loginservice.strVal;
                    if (SQLCode == 100)
                    {
                        ll_npadEnabled = 0;
                        is_npad_directory = "";
                    }
                }
                if (SQLCode != 0 && SQLCode != 100)
                {
                    MessageBox.Show("Error Number: " + SQLCode.ToString() + "~" + "Error Text:   " + SQLErrText + "~n~n" + "Continuing using defaults.", "NPAD settings initialisation error");
                    ll_npadEnabled = 0;
                    is_npad_directory = "";
                }
                //  Set NPAD enabled flag only if the table value is non-zero
                //   ( null treated equivalent to 0).
                if (ll_npadEnabled != null && ll_npadEnabled != 0)
                {
                    ib_npad_enabled = true;
                    //?iapp_object.DisplayName += "  ( enabled)";
                }
                else
                {
                    ib_npad_enabled = false;
                    //?iapp_object.DisplayName += "  ( disabled)";
                }
            //  TJB  NPAD2  December 2005
            return is_npad_directory;
        }

        public virtual DateTime of_gettimestamp()
        {
            DateTime ldt_now;
            //SELECT CURRENT TIMESTAMP INTO :ldt_now FROM dummy USING SQLCA;
            //  select getdate() ct;
            ldt_now = LoginService.GetCurDateTime();
            return ldt_now;
        }

        public virtual object of_get_road_map()
        {
            return inv_Road;
        }

        public virtual object of_set_road_map(object l_road)
        {
            if (inv_Road == null)
            {
                inv_Road = l_road;
            }
            return inv_Road;
        }

        public virtual string of_getappinifile()
        {
            return is_appinifile;
        }

        public virtual int of_setappinifile(string as_appinifile)
        {
            //Check arguments
            if(as_appinifile == null) {
	            return -1;
            }

            is_appinifile = as_appinifile;
            return 1;
        }

        public virtual int of_showstatus(ref WStatus w_status, int al_counter, int al_count, string as_message)
        {
            // Purpose: 	Show status ( progress bar)  window and draw progress
            // Author:	Rex Bustria - requirement from old code
            if (w_status != null && al_count > 5)
            {
                w_status = new WStatus();
                w_status.Show();
            }
            if (w_status != null)
            {
                w_status.of_draw(al_counter, al_count, as_message);
            }
            return 1;
        }

        public virtual int of_hidestatus(ref WStatus w_status)
        {
            if (w_status != null)
            {
                w_status.Close();
                w_status = null;
            }
            return 1;
        }

        public virtual DateTime of_hoursafter(DateTime? astarttime, DateTime? aEndTime)
        {
            DateTime tReturn = DateTime.MinValue;
            int lHours = 0;
            int lMinutes = 0;
            int lSeconds = 0;
            if (astarttime < aEndTime)
            {
                lSeconds = Convert.ToInt32(((TimeSpan)(aEndTime - astarttime)).TotalSeconds);//SecondsAfter(astarttime, aEndTime);
                if (lSeconds > 3559)
                {
                    lHours = Convert.ToInt32(lSeconds / 3600);
                    lSeconds = lSeconds - lHours * 3600;
                }
                if (lSeconds > 59)
                {
                    lMinutes = Convert.ToInt32(lSeconds / 60);
                    lSeconds = lSeconds - lMinutes * 60;
                }
                tReturn = Convert.ToDateTime(lHours.ToString() + ": " + lMinutes.ToString() + ": " + lSeconds.ToString());//Time(lHours, lMinutes, lSeconds);
         
            }
            return tReturn;
        }

        public virtual DateTime? of_subhours(DateTime? atime1, DateTime? atime2)
        {
            int lSeconds = 0;
            int lMinutes = 0;
            int lHours = 0;
            DateTime? tReturn;
            if (atime1 == null)
            {
                tReturn = atime2;
            }
            else if (atime2 == null)
            {
                tReturn = atime1;
            }
            else
            {
                lSeconds = Convert.ToInt32(((TimeSpan)(atime1 - atime2)).TotalSeconds);// SecondsAfter(Time("00:00:00"), atime1) - SecondsAfter(Time("00:00:00"), atime2);
                if (lSeconds > 3559)
                {
                    lHours = Convert.ToInt32(lSeconds / 3600);
                    lSeconds = lSeconds - lHours * 3600;
                }
                if (lSeconds > 59)
                {
                    lMinutes = Convert.ToInt32(lSeconds / 60);
                    lSeconds = lSeconds - lMinutes * 60;
                }
                tReturn = Convert.ToDateTime(lHours.ToString() + ": " + lMinutes.ToString() + ": " + lSeconds.ToString());//Time(lHours, lMinutes, lSeconds);
            }
            return tReturn;
        }
        #endregion

        public static string ApplicationVersion
        {
            get
            {
                return System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            }
        }
        public static string ApplicationBuiltOn
        {
            get
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();
                DateTime createdDaye = new System.IO.FileInfo(assembly.CodeBase.Replace("/", @"\").Replace(@"file:\\\", "")).LastWriteTime;
                return "Built on " + createdDaye.Date.ToString("dd/MM/yyyy") + " at " + createdDaye.ToString("HH:mm:ss");
            }
        }
    }
}
