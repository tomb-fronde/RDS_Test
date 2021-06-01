using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;

using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.DataService
{
    // TJB Allowances May-2021
    // Added
    //    GenerateUpdatedAllowances
    //    UpdateAllowanceTypeHistory
    //    UpdateVehicleAllowanceRatesHistory
    //    GetAllowanceMaxDate
    //    GetVehicleAllowanceMaxDate
    //
    // TJB  RPCR_117  July-2018
    // Added CheckEmailAddress(string p_email) to validate email address format
    // Returns "OK", "null" if null, "empty" if it contains only spaces, 
    // or the address if there's an error.
    //
    // TJB  RPCR_060  Mar_2014
    // GetMaxHstId:  NEW

    [Serializable()]
    public class MainMdiService : CommandEntity<MainMdiService>
    {
        #region Factory Methods]
        private bool ret = false;
        private string dataObject;
        private int? intVal;
        private DateTime? dtVal;
        private int ll_count;
        private string _sqlerrmsg;

        public string SQLErrMsg
        {
            get
            {
                return _sqlerrmsg;
            }
        }
       
        public static bool DeleteUserGroup(int group_id)
        {
            MainMdiService obj = Execute("_DeleteUserGroup", group_id);
            return obj.ret;
        }
        
        public static bool DeleteUser(int user_id)
        {
            MainMdiService obj = Execute("_DeleteUser", user_id);
            return obj.ret;
        }
        
        public static bool DeleteUserRegion(int user_id)
        {
            MainMdiService obj = Execute("_DeleteUserRegion", user_id);
            return obj.ret;
        }
        
        public static bool DeleteUserGroup(int group_id, int user_id)
        {
            MainMdiService obj = Execute("_DeleteUserGroup", group_id, user_id);
            return obj.ret;
        }
        
        public static bool GetMtDataObject(int mt_id, ref string dataObject)
        {
            MainMdiService obj = Execute("_GetMtDataObject", mt_id);
            dataObject = obj.dataObject;
            return obj.ret;
        }
        
        public static bool GetRdsUserGroupDataObject(string ug_name, ref int ll_count)
        {
            MainMdiService obj = Execute("_GetRdsUserGroupDataObject", ug_name);
            ll_count = obj.ll_count;
            return obj.ret;
        }
        
        public static bool CheckUserExisting(int user_id,int region_id, ref int? IntVal)
        {
            MainMdiService obj = Execute("_CheckUserExisting", user_id, region_id);
            IntVal = obj.intVal;
            return obj.ret;
        }
        
        public static bool InsertUserGroup(int group_id, int user_id)
        {
            MainMdiService obj = Execute("_InsertUserGroup", group_id, user_id);
            return obj.ret;
        }

        /// <summary> 
        ///  insert into rds_user_region (u_id,region_id ) values(:ll_ui_id, :ll_regionId );*/
        /// </summary>
        /// 
        public static bool InsertUserRegionList(int ll_ui_id, int ll_regionId)
        {
            MainMdiService obj = Execute("_InsertUserRegionList",ll_ui_id,ll_regionId);
            return obj.ret;
        }
        
        public static bool InsertOutlet(int region_id)
        {
            MainMdiService obj = Execute("_InsertOutlet", region_id);
            return obj.ret;
        }
       
        public static bool DeleteOutlet(int outlet_id)
        {
            MainMdiService obj = Execute("_DeleteOutlet", outlet_id);
            return obj.ret;
        }
        
        public static bool InsertTownSuburb(int townId, int suburbId)
        {
            MainMdiService obj = Execute("_InsertTownSuburb", townId, suburbId);
            return obj.ret;
        }
        
        public static bool GetMaxOutletId(ref int outletId)
        {
            MainMdiService obj = Execute("_GetMaxOutletId");
            outletId = obj.intVal.GetValueOrDefault();
            return obj.ret;
        }

        // TJB  RPCR_060  Mar_2014: NEW
        public static bool GetMaxHstId(ref int hstId)
        {
            MainMdiService obj = Execute("_GetMaxHstId");
            hstId = obj.intVal.GetValueOrDefault();
            return obj.ret;
        }

        /// <summary> 
        ///  UPDATE rds_user_id SET	ui_locked_date = NULL WHERE	ui_id = :ll_ui_id
        /// </summary>
        /// 
        public static bool UpdateRdsUserIdUILockedDate(int? ll_ui_id)
        {
            MainMdiService obj = Execute("_UpdateRdsUserIdUILockedDate", ll_ui_id);
            return obj.ret;
        }

        /// <summary> 
        ///  Delete rds_user_contract_type Where ui_id = :ll_ui_id
        /// </summary>
        /// 
        public static bool DeleteRdsUserContractType(int? ui_id, ref string returnMessage)
        {
            MainMdiService obj = Execute("_DeleteRdsUserContractType", ui_id);
            returnMessage = obj.dataObject;
            return obj.ret;
        }
                
        /// <summary> 
        ///  INSERT INTO rds_user_contract_type ("ct_key", "ui_id") VALUES (:ll_ct_key, :ll_ui_id)
        /// </summary>
        /// 
        public static bool InsertRdsUserContractType(int? ct_key, int? ui_id, ref string returnMessage)
        {
            MainMdiService obj = Execute("_InsertRdsUserContractType",ct_key, ui_id);
            returnMessage = obj.dataObject;
            return obj.ret;
        }
        
        /// <summary> 
        ///  select next_value	into :nNextValue	from id_codes	where sequence_name = :sequencename
        /// </summary>
        /// 
        public static bool getNextValue(string sequencename, ref int? returnMessage)
        {
            MainMdiService obj = Execute("_getNextValue", sequencename);
            returnMessage = obj.intVal;
            return obj.ret;
        }
        
        /// <summary> 
        ///  update id_codes set next_value = :nNextValue + 1	where sequence_name = :sequencename
        /// </summary>
        /// 
        public static bool updateIdCodes(int? nNextValue, string sequencename)
        {
            MainMdiService obj = Execute("_updateIdCodes", nNextValue,sequencename);            
            return obj.ret;
        }
        
        /// <summary> 
        ///  INSERT INTO rds_user_id("ui_id","u_id","ui_userid","ui_password","ui_created_date","ui_created_by") VALUES  (:ll_ui_id,:ll_u_id,:ls_ui_userid,:ls_encrypted,today(*),:ls_created_by)
        /// </summary>
        /// 
        public static bool InsertIntoRdsUserId(int? ll_ui_id, int? ll_u_id, string ls_ui_userid, string ls_encrypted, DateTime today, string ls_created_by)
        {
            MainMdiService obj = Execute("_InsertIntoRdsUserId", ll_ui_id, ll_u_id, ls_ui_userid, ls_encrypted, today, ls_created_by);
            
            return obj.ret;
        }
        
        /// <summary> 
        ///  INSERT INTO used_password("up_password", "ui_id") VALUES  (:ls_ui_password, :ll_ui_id)
        /// </summary>
        /// 
        public static bool InsertIntoUsedPassword(string ls_ui_password, int? ll_ui_id)
        {
            MainMdiService obj = Execute("_InsertIntoUsedPassword", ls_ui_password, ll_ui_id);
            
            return obj.ret;
        }

        ///<summary>
        /// UPDATE rds_user_id set 	ui_password = :ls_encrypted Where ui_id = :ll_ui_id
        /// </summary>
        public static bool UpdateUIPassword(string ls_ui_password,string ls_ui_userid,int? ll_ui_id)
        {
            MainMdiService obj = Execute("_UpdateUIPassword", ls_ui_password, ls_ui_userid,ll_ui_id);
            return obj.ret;
        }

        ///<summary>
        /// UPDATE rds_user_id set ui_userid = :ls_ui_userid  Where ui_id = :ll_ui_id  
        /// </summary>
        public static bool UpdateUIUserid(string ls_ui_userid, int? ll_ui_id)
        {
            MainMdiService obj = Execute("_UpdateUIUserid", ls_ui_userid, ll_ui_id);
            return obj.ret;
        }
        
        ///<summary>
        /// UPDATE rds_user_region set 	region_id = :ll_regionId Where ui_id = :ll_ui_id
        /// </summary>
        public static bool UpdateUserRegionList(int ll_regionId, int ll_ui_id)
        {
            MainMdiService obj = Execute("_UpdateUserRegionList", ll_regionId, ll_ui_id);
            return obj.ret;
        }

        ///<summary>
        ///</summary>
        public static bool UpdateDateAndUser(string ls_created_by, int? ll_ui_id)
        {
            MainMdiService obj = Execute("_UpdateDateAndUser", ls_created_by,ll_ui_id);
            return obj.ret;
        }
        
        /// <summary> 
        ///  SELECT	count(*) INTO :ll_count FROM rds_user WHERE u_name = :ls_name
        /// </summary>
        /// 
        public static bool GetCountFormRdsUser(string ls_name,ref int returnMessage)
        {
            MainMdiService obj = Execute("_GetCountFormRdsUser", ls_name);
            returnMessage = obj.ll_count;
            return obj.ret;
        }
        
        /// <summary> 
        ///  SELECT	count(*) INTO :ll_count	FROM rds_user_id WHERE ui_userid = :ls_user_id
        /// </summary>
        /// 
        public static bool GetUiUseridCountFormRdsUser(string ls_user_id, ref int returnMessage)
        {
            MainMdiService obj = Execute("_GetUiUseridCountFormRdsUser", ls_user_id);
            returnMessage = obj.ll_count;
            return obj.ret;
        }
        
        /// <summary> 
        ///  Select up_password	Into :ls_used_password From used_password Where ui_id = :ll_id and up_password = :ls_password
        /// </summary>
        /// 
        public static bool GetUpPasswordFormRdsUser(int? ll_id, string ls_password, ref string returnMessage)
        {
            MainMdiService obj = Execute("_GetUpPasswordFormRdsUser", ll_id, ls_password);
            returnMessage = obj.dataObject;
            return obj.ret;
        }

        // TJB Allowances May-2021: New
        // Called to generate updated contract_allowance records when either an Allowance_type
        // factor changes, or when one of the vahicle_allowance_rates changes
        // Var_id <= 0 means its one of the allowance_type changes
        // Alt_key <= 0 means its one of the vahicle_allowance_rates changes
        public static int GenerateUpdatedAllowances(int alt_key, int var_id, DateTime new_effective_date, string new_notes, out string SQLerrmsg)
        {
            MainMdiService obj = Execute("_GenerateUpdatedAllowances", alt_key, var_id, new_effective_date, new_notes);
            SQLerrmsg = obj.SQLErrMsg;
            return (int)obj.intVal;
        }

        // TJB Allowances 1-June-2021: New
        // Check to see if the effective_date in the allowance_type record is unique
        public static DateTime? GetAllowanceMaxDate(int inAltKey)
        {
            MainMdiService obj = Execute("_GetAllowanceMaxDate", inAltKey);
            return obj.dtVal;
        }

        // TJB Allowances 1-June-2021: New
        // Check to see if the effective_date in the vehicle_allowance_rates record is unique
        public static DateTime? GetVehicleAllowanceMaxDate(int inVarId)
        {
            MainMdiService obj = Execute("_GetVehicleAllowanceMaxDate", inVarId);
            return obj.dtVal;
        }

        // TJB Allowances 31-May-2021: New
        // Update the allowance_type_history table with the values from the 
        // record in the allowance_type table that has alt_key = inAltKey
        public static int? UpdateAllowanceTypeHistory(int inAltKey)
        {
            MainMdiService obj = Execute("_UpdateAllowanceTypeHistory", inAltKey);
            return obj.intVal;
        }

        // TJB Allowances 31-May-2021: New
        // Update the vehicle_allowance_rates_history table with the values from the 
        // record in the vehicle_allowance_rates table that has var_id = inVarId
        public static int? UpdateVehicleAllowanceRatesHistory(int inVarId)
        {
            MainMdiService obj = Execute("_UpdateVehicleAllowanceRatesHistory", inVarId);
            return obj.intVal;
        }

        public static int? GetNextSequence(string sequenceName)
        {
            MainMdiService obj = Execute("_GetNextSequence", sequenceName);
            return obj.intVal;
        }

        // TJB  RPCR_117  July-2018
        // Check string for properly-formed email address
        // Return  "OK" 
        // or the string itself if not OK
        //         "null" if null
        //         "empty" if string only contains spaces
        public static string CheckEmailAddress(string p_email)
        {
            string result = "OK";

            result = "OK";
            if (!string.IsNullOrEmpty(p_email))
            {
                if (!Regex.IsMatch(p_email, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$"))
                {
                    result = p_email;
                    if (p_email == null) result = "null";
                    else if (p_email.Trim() == "") result = "empty"; 
                }
            }
            return result;
        }

 #endregion

        #region Server-side Code
        // TJB Allowances May-2021: New
        // Called to generate updated contract_allowance records when either an Allowance_type
        // factor changes, or when one of the vahicle_allowance_rates changes
        // Var_id <= 0 means its one of the allowance_type changes
        // Alt_key <= 0 means its one of the vahicle_allowance_rates changes
        [ServerMethod]
        private void _GenerateUpdatedAllowances(int in_alt_key, int in_var_id, DateTime in_new_eff_date, string in_new_notes)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_generate_updated_allowances";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_alt_key", in_alt_key);
                    pList.Add(cm, "in_var_id   ", in_var_id);
                    pList.Add(cm, "new_effective_date", in_new_eff_date);
                    pList.Add(cm, "new_notes", in_new_notes);

                    intVal = 0;
                    _sqlerrmsg = "";
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrmsg = e.Message;
                        intVal = -1;
                    }
                }
            }
        }


        // TJB Allowances 1-June-2021: New
        [ServerMethod]
        private void _GetAllowanceMaxDate(int inAltKey)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime? rc = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select max(alt_effective_date) "
                                    + " from [rd].[allowance_type] "
                                    + " where alt_key = @alt_key";
                    pList.Add(cm, "@alt_key", inAltKey);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                rc = dr.GetDateTime(0);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrmsg = e.Message;
                    }
                    dtVal = rc;
                }
            }
        }

        // TJB Allowances 1-June-2021: New
        [ServerMethod]
        private void _GetVehicleAllowanceMaxDate(int inVarId)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    DateTime? rc = null;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select max(var_effective_date) "
                                    + " from [rd].[vehicle_allowance_rates] "
                                    + " where var_id = @var_id";
                    pList.Add(cm, "@var_id", inVarId);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                rc = dr.GetDateTime(0);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrmsg = e.Message;
                    }
                    dtVal = rc;
                }
            }
        }

        // TJB Allowances 31-May-2021: New
        [ServerMethod]
        private  void _UpdateAllowanceTypeHistory(int inAltKey)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "insert into [rd].[allowance_type_history] "
                                     + "select * from [rd].[allowance_type] "
                                     + " where alt_key = @alt_key";
                    pList.Add(cm, "@alt_key", inAltKey);
                    DBHelper.ExecuteReader(cm, pList);
                    intVal = 0;
                }
            }
        }

        // TJB Allowances 31-May-2021: New
        [ServerMethod]
        private void _UpdateVehicleAllowanceRatesHistory(int inVarId)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "insert into [rd].[vehicle_allowance_rates_history] "
                                     + "select * from [rd].[vehicle_allowance_rates] "
                                     + " where var_id = @var_id";
                    pList.Add(cm, "@var_id", inVarId);
                    DBHelper.ExecuteReader(cm, pList);
                    intVal = 0;
                }
            }
        }

        [ServerMethod]
        private  void _GetNextSequence(string sequenceName)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int? sequence = 0;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "select next_value from id_codes where sequence_name = @sequenceName";
                    pList.Add(cm, "sequenceName", sequenceName);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            sequence = dr.GetInt32(0);
                        }
                    }
                    if (sequence == 0)
                    {
                        cm.CommandText = "insert into id_codes (sequence_name, next_value) values (@sequenceName, 2)";
                        DBHelper.ExecuteNonQuery(cm, pList);
                        sequence = 1;
                    }
                    else
                    {
                        cm.CommandText = "update id_codes set next_value = @next_value  where sequence_name = @sequenceName";
                        pList.Add(cm, "next_value", (sequence + 1));
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    intVal=sequence;
                }
            }
        }
       
        [ServerMethod]
        private void _UpdateDateAndUser(string ls_created_by, int? ll_ui_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = " UPDATE rds_user_id set 	ui_modified_date = getdate(),ui_modified_by = @ls_created_by Where ui_id = @ll_ui_id";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ls_created_by", ls_created_by);
                    pList.Add(cm, "ll_ui_id", ll_ui_id);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                    }
                    catch (Exception e)
                    {
                        dataObject = e.Message.ToString();
                        ret = false;
                    }
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _GetUpPasswordFormRdsUser(int? ll_id, string ls_password)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = " Select up_password	From used_password		Where ui_id = :ll_id	and up_password = :ls_password";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ll_id", ll_id);
                    pList.Add(cm, "ls_password", ls_password);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            dataObject = dr.GetString(0);
                        }
                    }
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _GetUiUseridCountFormRdsUser(string ls_user_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "SELECT	count(*) FROM		rds_user_id		WHERE		ui_userid = :ls_user_id";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ls_user_id", ls_user_id);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            ll_count = dr.GetInt32(0);
                        }
                    }
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _GetCountFormRdsUser(string ls_name)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "SELECT	count(*)	FROM		rds_user	WHERE		u_name = :ls_name";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ls_name", ls_name);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            ll_count = dr.GetInt32(0);
                        }
                    }
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _InsertIntoUsedPassword(string ls_ui_password, int? ll_ui_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "INSERT INTO used_password(up_password, ui_id) VALUES  (:ls_ui_password, :ll_ui_id)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ls_ui_password", ls_ui_password);
                    pList.Add(cm, "ll_ui_id", ll_ui_id);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                    }
                    catch (Exception e)
                    {
                        dataObject = e.Message.ToString();
                        ret = false;
                    }
                }
            }
            ret = true;
        }

        [ServerMethod]
        private void _UpdateUIPassword(string ls_ui_password,string ls_ui_userid,int? ll_ui_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "UPDATE rds_user_id set ui_password = @ls_encrypted, ui_userid=@ui_userid,ui_modified_date=@ui_modified_date Where ui_id = @ll_ui_id";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ls_encrypted", ls_ui_password);
                    pList.Add(cm, "ui_userid", ls_ui_userid);
                    pList.Add(cm, "ll_ui_id", ll_ui_id);
                    pList.Add(cm, "ui_modified_date", System.DateTime.Today);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                    }
                    catch (Exception e)
                    {
                        dataObject = e.Message.ToString();
                        ret = false;
                    }
                }
            }
            ret = true;
        }

        [ServerMethod]
        private void _UpdateUIUserid(string ls_ui_userid, int? ll_ui_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "UPDATE rds_user_id set ui_userid = @ls_ui_userid  Where ui_id = @ll_ui_id";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ui_userid", ls_ui_userid);
                    pList.Add(cm, "ll_ui_id", ll_ui_id);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                    }
                    catch (Exception e)
                    {
                        dataObject = e.Message.ToString();
                        ret = false;
                    }
                }
            }
            ret = true;
        }

        [ServerMethod]
        private void _UpdateUserRegionList(int ll_regionId, int ll_ui_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "UPDATE  rds_user_region  set region_id = @ll_regionId  Where u_id = @ll_ui_id";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ll_regionId", ll_regionId);
                    pList.Add(cm, "ll_ui_id", ll_ui_id);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                    }
                    catch (Exception e)
                    {
                        dataObject = e.Message.ToString();
                        ret = false;
                    }
                }
            }
            ret = true;
        }

        [ServerMethod()]
        private void _InsertIntoRdsUserId(int? ll_ui_id, int? ll_u_id, string ls_ui_userid, string ls_encrypted, DateTime today, string ls_created_by)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = " INSERT INTO rds_user_id(ui_id,u_id,ui_userid,ui_password,ui_created_date,ui_created_by,ui_modified_date,ui_modified_by) VALUES  (:ll_ui_id,:ll_u_id,:ls_ui_userid,:ls_encrypted,:today,:ls_created_by,:m_today,:m_ls_created_by)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ll_ui_id", ll_ui_id);
                    pList.Add(cm, "ll_u_id", ll_u_id);
                    pList.Add(cm, "ls_ui_userid", ls_ui_userid);
                    pList.Add(cm, "ls_encrypted", ls_encrypted);
                    pList.Add(cm, "today", today);
                    pList.Add(cm, "ls_created_by", ls_created_by);
                    pList.Add(cm, "m_today", today);
                    pList.Add(cm, "m_ls_created_by", ls_created_by);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                    }
                    catch (Exception e)
                    {
                        dataObject = e.Message.ToString();
                        ret = false;
                    }
                }
            }
            ret = true;
        }

        [ServerMethod()]
        private void _updateIdCodes(int? nNextValue, string sequencename)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "update id_codes set next_value = :nNextValue + 1	where sequence_name = :sequencename";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "sequencename", sequencename);
                    pList.Add(cm, "nNextValue", nNextValue);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                    }
                    catch (Exception e)
                    {
                        dataObject = e.Message.ToString();
                        ret = false;
                    }
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _getNextValue(string sequencename)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "select next_value	from id_codes	where sequence_name = :sequencename";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "sequencename", sequencename);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            intVal = dr.GetInt32(0);
                        }
                    }
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _GetMaxOutletId()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select max(outlet_id) from outlet";
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, null))
                    {
                        if (dr.Read())
                        {
                            intVal = dr.GetInt32(0);
                        }
                    }
                }
            }
        }

        // TJB  RPCR_060  Mar_2014: NEW
        [ServerMethod()]
        private void _GetMaxHstId()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select max(hst_id) from rd.hs_type";
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, null))
                    {
                        if (dr.Read())
                        {
                            intVal = dr.GetInt32(0);
                        }
                    }
                }
            }
        }

        [ServerMethod()]
        private void _InsertTownSuburb(int townId, int suburbId)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    bool exist = false; 
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "townId", townId);
                    pList.Add(cm, "suburbId", suburbId);
                    cm.CommandText = "select tc_id  from town_suburb  " +
                              "where tc_id = @townId   and sl_id = @suburbId";
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            exist = true;
                        }
                    }
                    if (!exist)
                    {
                        cm.CommandText = "insert into town_suburb  (  tc_id, sl_id )  values  (  @townId,  @suburbId)";

                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _InsertOutlet(int region_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    int outlet_id = 0;
                    cm.CommandText = "select max(outlet_id) from outlet";
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, null))
                    {
                        if (dr.Read())
                        {
                            outlet_id = dr.GetInt32(0);
                        }
                    }
                    outlet_id++;
                    cm.CommandText = "insert into outlet(outlet_id, region_id) values ( @outlet_id, @region_id)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "outlet_id", outlet_id);
                    pList.Add(cm, "region_id", region_id);
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _DeleteOutlet(int outlet_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "delete from outlet  where outlet_id = @outlet_id";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "outlet_id", outlet_id);
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _DeleteUserGroup(int group_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "Delete from rd.rds_user_group Where ug_id = @al_group_id";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_group_id", group_id);
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _DeleteUser(int user_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "Delete from rd.rds_user Where u_id = @al_user_id";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_user_id", user_id);
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _DeleteUserRegion(int user_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "Delete from rd.rds_user_region Where u_id = @al_user_id";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_user_id", user_id);
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _DeleteUserGroup(int group_id, int user_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "Delete from rds_user_id_group where ug_id = @al_group_id and ui_id = @al_ui_id";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_group_id", group_id);
                    pList.Add(cm, "al_ui_id", user_id);
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _GetMtDataObject(int mt_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "Select mt_dataobject From rds_maintenance_table Where mt_id = @ai_mt_id";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ai_mt_id", mt_id);
                    
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            dataObject = dr.GetString(0);
                        }
                    }
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _GetRdsUserGroupDataObject(string ug_name)
        {
            ll_count = -1;
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT count(*) FROM rds_user_group " 
                                   + "WHERE ug_name = @ug_name";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ug_name", ug_name);
                    
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            ll_count = dr.GetInt32(0);
                        }
                    }
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _CheckUserExisting(int user_id,int region_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select 1 from rds_user_region  where u_id= @ui_id  and region_id = @regionId";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ui_id", user_id);
                    pList.Add(cm, "regionId", region_id);
                    DBHelper.ExecuteNonQuery(cm, pList);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        if (dr.Read())
                        {
                            intVal = dr.GetInt32(0);
                        }
                    }
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _InsertUserGroup(int group_id, int user_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "Insert into rds_user_id_group ( ug_id, ui_id) values ( @group_id, @logon_id)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "group_id", group_id);
                    pList.Add(cm, "logon_id", user_id);
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
            }
            ret = true;
        }
        
        [ServerMethod()]
        private void _InsertUserRegionList(int ll_ui_id, int ll_regionId)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    using (DbCommand cm = cn.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.Text;

                        cm.CommandText = "insert into rds_user_region (u_id,region_id ) values(@ll_ui_id, @ll_regionId )";
                        ParameterCollection pList = new ParameterCollection();
                        pList.Add(cm, "ll_ui_id", ll_ui_id);
                        pList.Add(cm, "ll_regionId", ll_regionId);
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    tr.Commit();
                }
            }
            ret = true;
        }

        [ServerMethod()]
        private void _UpdateRdsUserIdUILockedDate(int? ll_ui_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    using (DbCommand cm = cn.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "UPDATE rds_user_id SET ui_locked_date = NULL WHERE ui_id = @ll_ui_id";
                        ParameterCollection pList = new ParameterCollection();
                        pList.Add(cm, "ll_ui_id", ll_ui_id);                        
                        try
                        {
                            DBHelper.ExecuteNonQuery(cm, pList);
                            ret = true;
                        }
                        catch (Exception e)
                        {
                            dataObject = e.Message.ToString();
                            ret = false;
                        }
                    }
                    tr.Commit();
                }
            }
        }
     
        [ServerMethod()]
        private void _DeleteRdsUserContractType(int? ui_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    using (DbCommand cm = cn.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "Delete rds_user_contract_type Where ui_id = @ui_id";
                        ParameterCollection pList = new ParameterCollection();
                        pList.Add(cm, "ui_id", ui_id);
                        try
                        {
                            DBHelper.ExecuteNonQuery(cm, pList);
                            ret = true;
                        }
                        catch (Exception e)
                        {
                            dataObject = e.Message.ToString();
                            ret = false;
                        }
                    }
                    tr.Commit();
                }
            }
            
        }

        [ServerMethod()]
        private void _InsertRdsUserContractType(int? ct_key, int? ui_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    using (DbCommand cm = cn.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "INSERT INTO rds_user_contract_type (ct_key, ui_id) VALUES (@ct_key, @ui_id)";
                        ParameterCollection pList = new ParameterCollection();
                        pList.Add(cm, "ui_id", ui_id);
                        pList.Add(cm, "ct_key", ct_key);
                        try
                        {
                            DBHelper.ExecuteNonQuery(cm, pList);
                            ret = true;
                        }
                        catch (Exception e)
                        {
                            dataObject = e.Message.ToString();
                            ret = false;
                        }
                    }
                    tr.Commit();
                }
            }
            
        }

        #endregion
    }
}
