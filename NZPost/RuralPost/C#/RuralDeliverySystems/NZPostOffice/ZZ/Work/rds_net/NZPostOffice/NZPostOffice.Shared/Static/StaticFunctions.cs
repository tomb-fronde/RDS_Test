 using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;
using NZPostOffice.DataService;

namespace NZPostOffice.Shared
{
    public class StaticFunctions
    {
        /// <summary>
        /// Convert PB naming style to .NET
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetPBName(string s)
        {
            string tmps = s.ToLower();

            int i = s.IndexOf("_");
            if (i < 0)
                return (InitCap(s));
            s = InitCap(tmps);
            while (i > 0)
            {
                tmps = s.Substring(0, i) + InitCap(s.Substring(i + 1, s.Length - i - 1));
                s = tmps;
                i = s.IndexOf("_");
            }
            return (s);
        }


        /// <summary>
        /// make first letter upcase
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string InitCap(string s)
        {
            string ret = s.ToUpper();
            if (s.Length > 1)
            {
                ret = ret[0] + s.Substring(1, s.Length - 1);
            }
            return ret;
        }

        public static int GetNextSequence(string sequencename)
        {
            // Purpose: 	Get the next sequence number for a given table name
            // Author:	Lightning author
            int nReturn = 0;
            int nNextValue;
            if (sequencename == null || sequencename.Trim() == "")
            {
                nReturn = -(1);
            }
            else 
            {
                /*select next_value
                into :nNextValue
                from id_codes
                where sequence_name = :sequencename ;
                 */
                int sqlcode = -1;
                nNextValue = LoginService.GetIdCodes(sequencename,ref sqlcode);
                if (sqlcode != 0) 
                {
                    /*insert into id_codes
                     ( sequence_name, next_value)
                    values  ( :sequencename, 2) ;*/
                    LoginService.InsertIdCodes(sequencename);
                    nReturn = 1;
                }
                else 
                {
                    nReturn = nNextValue;
                    /*UPDATE id_codes set next_value = :nNextValue + 1
                    where sequence_name = :sequencename ;*/
                    LoginService.UpdateIdCodes(nNextValue, sequencename);
                }
            }
            return nReturn;
        }

        public static string GetCurrentDirectory()
        {
            string strdir = string.Empty;

            strdir = AppDomain.CurrentDomain.BaseDirectory;

            return strdir;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vkKey);
        public enum KeyIndexes { KeyDelete = 0x2e, KeyCtrl = 0x11, KeyAlt = 0x12, KeyShift = 0x10, KeyEscape = 0x1b };

        public static bool KeyDown(KeyIndexes idx)
        {
            return GetAsyncKeyState((int)idx) < 0;
        }

        public static bool IsNull(object val)
        {
            if (val == null)
                return true;
            else if ((val is DateTime? || val is DateTime) && ((DateTime)val).Ticks == 0)
                return true;
            return false;
        }

        //
        //  Function: IsNumber()
        //
        //  Purpose: checks to see if the contents of a string are a valid
        //           number.  Returns true or false.
        //
        public static bool IsNumber(string testValue)
        {
            bool retValue = true;
            int numericValue = 0;

            try
            {
                numericValue = System.Convert.ToInt32(testValue);
            }
            catch (Exception)
            {
                retValue = false;
            }

            return retValue;
        }

        public static int? ToInt32(string data)
        {
            int result;
            try
            {
                return int.Parse(data);
            }
            catch(Exception)
            {
                return null;
            }
        }

        public static string ConfigString(string filename, string section, string key, string defaults)
        {
               System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
               try
               {
                   KeyValueConfigurationElement setting = config.AppSettings.Settings[key];
                   if (setting != null)
                       return setting.Value;
                   else
                       return defaults;
               }
               catch (Exception)
               {
                   return defaults;
               }
        }

        public static bool SetConfigString(string filename, string section, string key, string value)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            try
            {
                config.AppSettings.Settings.Remove(key);
            }
            catch (Exception)
            { }
            try
            {
                config.AppSettings.Settings.Add(key, value);
                config.Save();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static string f_translate(string astring, string aoldchars, string anewchars)
        {
            string sNewString = "";
            int lPos;
            lPos = astring.IndexOf(aoldchars);
            while (lPos > 0)
            {
                sNewString = sNewString + astring.Substring(0, lPos - 1) + anewchars;
                astring = astring.Substring(lPos + aoldchars.Length);
                lPos = astring.IndexOf(aoldchars);
            }
            sNewString = sNewString + astring;
            return sNewString;
        }

        //! public static int f_stdmessage(string message_type, string message_title, string message_text1, string message_text2, button message_buttons) {
        //    string cMessage = "";
        //    icon iMessageIcon = stopsign!;
        //    // PowerBuilder 'Choose Case' statement converted into 'if' statement
        //    unknown TestExpr = Lower(message_type);
        //    if (TestExpr == "mandatory") {
        //        cMessage = "The " + message_text1 + " must be entered.";
        //    }
        //    else if (TestExpr == "cannot delete") {
        //        cMessage = "The current " + message_text1 + " cannot be deleted " + "because it has " + message_text2 + " attached to it.";
        //    }
        //    else if (TestExpr == "already saved") {
        //        cMessage = "The current " + message_text1 + " cannot be saved " + "because it already exists on the database.";
        //    }
        //    else if (TestExpr == "no parent") {
        //        cMessage = "The current " + message_text1 + " cannot be opened " + "because its " + message_text2 + " parent has not been " + "saved to the database.";
        //    }
        //    else if (TestExpr == "not exist") {
        //        cMessage = "The " + message_text1 + " does not exist on the database.";
        //    }
        //    else if (TestExpr == "picklist not found") {
        //        cMessage = "There are no " + message_text1 + " which match the value entered.";
        //    }
        //    else if (TestExpr == "duplicate") {
        //        cMessage = "The current " + message_text1 + " already has been defined.";
        //    }
        //    else if (TestExpr == "negative") {
        //        cMessage = "The " + message_text1 + " cannot contain a negative value.";
        //    }
        //    else {
        //        cMessage = message_text1 + '~' + message_text2;
        //    }
        //    return MessageBox(message_title, cMessage, iMessageIcon, message_buttons);
        //}

        public static int f_set_menu_items()
        {
            return 0;
        }

        public static int f_seekkey(string aTables, string aWhere)
        {
            string sSqlStatement;
            int lCount = 0;
            //!sSqlStatement = "select count ( *) from " + aTables + " where " + aWhere;
            //DECLARE counter_cursor DYNAMIC CURSOR FOR SQLSA ;
            //PREPARE SQLSA FROM :sSqlStatement;
            //OPEN counter_cursor
            //FETCH counter_cursor INTO :lCount ;
            //CLOSE counter_cursor
            sSqlStatement = "select count ( *) from " + aTables + " where " + aWhere;
            lCount = LoginService.ExecuteSqlString(sSqlStatement);
            return lCount;
        }


        public static bool f_nempty(object nvalue)
        {
            int i = 0;
            int.TryParse(string.Format("{0}", nvalue), out i);
            return System.Convert.ToInt32(nvalue) == 0;
        }

        public static bool f_isempty(string cstring)
        {
            return (cstring == null) || cstring.Trim().Length == 0;
        }

        public static string f_encrypt(string a_string)
        {
            string sOldCodes = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890 ";
            string sNewCodes = "p31o6GWPNCnRfiTOvmSjUwJ4e528YHD0dlbIrgZM@VktFEu9hqKxQyXaBs7cLzA";
            int nPos;
            int nLoop;
            string sReturn = "";
            if (!(f_isempty(a_string)))
            {
                for (nLoop = 0; nLoop < a_string.Length; nLoop++)
                {
                    nPos = sOldCodes.IndexOf(a_string.Substring(nLoop, 1));
                    if (nPos >= 0)
                    {
                        nPos = nPos + nLoop + 2;
                        if (nPos > sOldCodes.Length)
                        {
                            nPos = nPos - sOldCodes.Length;
                        }
                        sReturn = sReturn + sNewCodes.Substring(nPos - 1, 1);
                    }
                    else
                    {
                        sReturn = sReturn + a_string.Substring(nLoop, 1);
                    }
                }
            }
            return sReturn;
        }

        public static string f_decrypt(string a_string)
        {
            string sNewCodes = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890 ";
            string sOldCodes = "p31o6GWPNCnRfiTOvmSjUwJ4e528YHD0dlbIrgZM@VktFEu9hqKxQyXaBs7cLzA";
            int lPos;
            int lLoop;
            string sReturn = "";
            if (!(f_isempty(a_string)))
            {
                for (lLoop = 0; lLoop < a_string.Length; lLoop++)
                {
                    lPos = sOldCodes.IndexOf(a_string.Substring(lLoop, 1));
                    if (lPos >= 0)
                    {
                        lPos = lPos - lLoop;
                        if (lPos < 1)
                        {
                            lPos = lPos + sOldCodes.Length;
                        }
                        sReturn = sReturn + sNewCodes.Substring(lPos - 1, 1);
                    }
                    else
                    {
                        sReturn = sReturn + a_string.Substring(lLoop, 1);
                    }
                }
            }
            return sReturn;
        }

        public static int f_stdmessage(string message_type, string message_title, string message_text1, string message_text2, MessageBoxButtons message_buttons) {
            string cMessage = "";
            MessageBoxIcon iMessageIcon = MessageBoxIcon.Stop;
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = message_type.ToLower();
            if (TestExpr == "mandatory") {
                cMessage = "The " + message_text1 + " must be entered.";
            }
            else if (TestExpr == "cannot delete") {
                cMessage = "The current " + message_text1 + " cannot be deleted " + "because it has " + message_text2 + " attached to it.";
            }
            else if (TestExpr == "already saved") {
                cMessage = "The current " + message_text1 + " cannot be saved " + "because it already exists on the database.";
            }
            else if (TestExpr == "no parent") {
                cMessage = "The current " + message_text1 + " cannot be opened " + "because its " + message_text2 + " parent has not been " + "saved to the database.";
            }
            else if (TestExpr == "not exist") {
                cMessage = "The " + message_text1 + " does not exist on the database.";
            }
            else if (TestExpr == "picklist not found") {
                cMessage = "There are no " + message_text1 + " which match the value entered.";
            }
            else if (TestExpr == "duplicate") {
                cMessage = "The current " + message_text1 + " already has been defined.";
            }
            else if (TestExpr == "negative") {
                cMessage = "The " + message_text1 + " cannot contain a negative value.";
            }
            else {
                cMessage = message_text1 + '~' + message_text2;
            }
            return (int) MessageBox.Show(cMessage, message_title, message_buttons, iMessageIcon);
        }

        public static bool IsDirty(Metex.Windows.DataUserControlContainer dw_container)
        {
            return IsDirty(dw_container.DataObject);
        }

        public static bool IsDirty(Metex.Windows.DataUserControl dw)
        {
            if (dw == null)
            {
                return false;
            }
            else if (dw.DeletedCount > 0)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < dw.RowCount; i++)
                {
                    Metex.Core.EntityBase BE = dw.GetItem<Metex.Core.EntityBase>(i);
                    if (BE.IsNew)
                    {
                        /*?? System.Reflection.FieldInfo field = BE.GetType().GetField("_newModified", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                        if (field != null && field.GetValue(BE).ToString().ToLower() == "false")
                        {
                            return false;
                        }
                        return true; */
                        if (BE.IsDirty)
                            return true;
                    }
                    else if (BE.IsDirty)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool IsModified(Metex.Windows.DataUserControl dw)
        {
            if (dw == null)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < dw.RowCount; i++)
                {
                    Metex.Core.EntityBase BE = dw.GetItem<Metex.Core.EntityBase>(i);
                    
                     System.Reflection.FieldInfo field = BE.GetType().GetField("_newModified", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    if (field != null && field.GetValue(BE).ToString().ToLower() == "true")
                    {
                        return true;
                    }
                }
            }
            return false;
        }



        // general purpose exception-safe function to get field/property value from a data control
        public static object GetValueUsingReflection(Metex.Windows.DataUserControl control, int row, string field_name)
        {
          

            if (control.BindingSource.List.Count <= row)
                return null;
            else
            {
                object entity = control.BindingSource.List[row];
                System.Reflection.FieldInfo field = entity.GetType().GetField(field_name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
                if (field != null)
                {
                    return field.GetValue(entity);
                }
                else
                {
                    System.Reflection.PropertyInfo prop = entity.GetType().GetProperty( field_name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
                    if (prop != null)
                        return prop.GetValue(entity, null);
                    else
                        return null;
                }
            }
        }

        public static int GetValueUsingReflectionDecmi(Metex.Windows.DataUserControl control, int row, string field_name)
        {


            if (control.BindingSource.List.Count <= row)
                return 0;
            else
            {
                object entity = control.BindingSource.List[row];
                System.Reflection.FieldInfo field = entity.GetType().GetField(field_name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
                if (field != null)
                {
                    return Convert.ToInt32(field.GetValue(entity));
                }
                else
                {
                    System.Reflection.PropertyInfo prop = entity.GetType().GetProperty(field_name, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
                    if (prop != null)
                        return Convert.ToInt32(prop.GetValue(entity, null));
                    else
                        return 0;
                }
            }
        }

        public static void ClearDeleteBuffer(Metex.Windows.DataUserControl control)
        {
            System.Reflection.FieldInfo field = typeof(Metex.Windows.DataUserControl).GetField("deletedList", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            ((IList<Metex.Core.ISavableEntity>)field.GetValue(control)).Clear();
        }

        public static bool f_hqaccess()
        {
            if(StaticVariables.g_security.access_groups[7] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool f_regreportaccess()
        {
            if (StaticVariables.g_security.access_groups[6] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string migrateName(string pbname)
        {

            while (pbname.IndexOf('_') >= 0)
            {
                pbname = pbname.Substring(0, 1).ToUpper() + pbname.Substring(1, pbname.IndexOf('_') - 1) + pbname.Substring(pbname.IndexOf('_') + 1, 1).ToUpper() + pbname.Substring(pbname.IndexOf('_') + 2).ToLower();
            }

            if (pbname.Length > 1)
                pbname = pbname.Substring(0, 1).ToUpper() + pbname.Substring(1, pbname.Length - 1);
            return pbname;
        }
    }
}
