using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.DataService
{
    [Serializable()]
    public class LoginService : CommandEntity<LoginService>
    {
        #region Factory Methods
        private string oldPassword;
        private bool bRetValue;
        private int iRetValue;
        private int uiId;
        private short graceLoginsRemaining;
        private DateTime? passwordExpiryDate;
        private DateTime? accountLockedDate;

        private DateTime dRetValue;

        private int _sqlCode;
        private string _sqlErrText;
        private int lNextValue;
        private int nNextValue;
        //add by mkwang 
        public int intVal;
        public string strVal;
        //end add
        public static int sqlCode = -1;
        public short GraceLoginsRemaining
        {
            get
            {
                return graceLoginsRemaining;
            }
        }

        public DateTime? PasswordExpiryDate
        {
            get
            {
                return passwordExpiryDate;
            }
        }

        public DateTime? AccountLockedDate
        {
            get
            {
                return accountLockedDate;
            }
        }

        public int RetValue
        {
            get
            {
                return iRetValue;
            }
        }

        public int LNextValue
        {
            get
            {
                return lNextValue;
            }
        }

        public int NNextValue
        {
            get
            {
                return nNextValue;
            }
        }

        public static bool TryConnectNZPO()
        {
            LoginService obj = Execute("_TryConnectNZPO");
            return obj.bRetValue;
        }

        public static LoginService LoginUser(string UserId, string PassWd, ref int uiId)
        {
            LoginService obj = Execute("_LoginUser", UserId, PassWd);
            uiId = obj.uiId;
            return obj;
        }

        public static void UpdateUser(string UserId, int GraceLogins, DateTime? ExpiryDate)
        {
            Execute("_UpdateUser", UserId, GraceLogins, ExpiryDate);
        }

        public static void UpdatePassword(DateTime? dExpiry, string UserId, int UiId, string sOldPassword, string sNewPassword)
        {
            Execute("_UpdatePassword", dExpiry, UserId, UiId, sOldPassword, sNewPassword);
        }

        public static void GetUiId(string UserId, ref int uiId)
        {
            LoginService obj = Execute("_GetUiId", UserId);
            uiId = obj.uiId;
        }

        public static void GetOldPass(int ui_id, string newPassword, ref string oldPass)
        {
            LoginService obj = Execute("_GetOldPass", ui_id, newPassword);
            oldPass = obj.oldPassword;
        }

        /// <summary> 
        /// UPDATE 	rd.rds_user_id SET ui_locked_date = today(*) WHERE ui_userid = :ls_UserId;
        /// </summary>
        /// 
        public static bool UpdateRdsUserIdUILockedDate(string ll_ui_id)
        {
            LoginService obj = Execute("_UpdateRdsUserIdUILockedDate", ll_ui_id);
            return obj.bRetValue;
        }

        /// <summary>
        /// select count ( *) into :li_priv_count from rds_user_rights rur, rds_user_id_group rui, rds_component rc, rds_user_id rid  where rc.rc_name = :as_component and rid.ui_userid = :as_user_id and  rui.ui_id = rid.ui_id and rur.ug_id = rui.ug_id and rc.rc_id = rur.rc_id and  rur.rur_read = 'Y' and rur.ug_id = rui.ug_id ;
        /// 
        public static int GetRdsUserRightsMoreValue(string as_component, string as_user_id, ref int sqlCode, ref string sqlErrText)
        {
            LoginService obj = Execute("_GetRdsUserRightsMoreValue", as_component, as_user_id);
            sqlCode = obj._sqlCode;
            sqlErrText = obj._sqlErrText;
            return obj.iRetValue;
        }

        /// <summary>
        //select count ( *) into :li_priv_count from rds_user_rights rur, rds_user_id_group rui, rds_component rc, rds_user_id rid where rc.rc_name = :as_component and rid.ui_userid = :as_user_id and rui.ui_id = rid.ui_id and rur.ug_id = rui.ug_id and rc.rc_id = rur.rc_id and rur.rur_modify = 'Y' and rur.ug_id = rui.ug_id using sqlca;
        /// </summary>
        public static int GetRdsUserRightsMoreValue2(string as_component, string as_user_id, ref int sqlCode, ref string sqlErrText)
        {
            LoginService obj = Execute("_GetRdsUserRightsMoreValue2", as_component, as_user_id);
            sqlCode = obj._sqlCode;
            sqlErrText = obj._sqlErrText;
            return obj.iRetValue;
        }
        /// <summary>
        /// select npad_enabled, npad_directory into :ll_npadEnabled, :is_npad_Directory from npad_parameters  where npad_userid = :ls_userid
        /// <summary>
        public static LoginService GetNPADParameters(string ls_userid,ref int SQLCode,ref string SQLErrText)
        {
            LoginService obj = Execute("_GetNPADParameters", ls_userid);
            SQLCode = obj._sqlCode;
            SQLErrText = obj._sqlErrText;
            return obj;
        }
        /// <summary>
        /// select npad_enabled, npad_directory into :ll_npadEnabled, :is_npad_Directory from npad_parameters  where npad_userid = 'default'
        /// <summary>
        public static LoginService GetNpadParametersDefault(ref int SQLCode, ref string SQLErrText)
        {
            LoginService obj = Execute("_GetNpadParametersDefault");
            SQLCode = obj._sqlCode;
            SQLErrText = obj._sqlErrText;
            return obj;
        }
        /// <summary>
        /// Complex sql 
        /// </summary>
        public static int SetComplexSql(string sequencename)
        {
            LoginService obj = Execute("_SetComplexSql", sequencename);
            return obj.iRetValue;
        }

        /// <summary>
        /// Select count ( *) into :il_NumRegions from region;
        /// 
        public static int GetRegionCount()
        {
            LoginService obj = Execute("_GetRegionCount");
            return obj.iRetValue;
        }

        /// <summary>
        /// Select count ( *) into :il_total_contract_types from contract_type;
        /// 
        public static int GetContractTypeCount()
        {
            LoginService obj = Execute("_GetContractTypeCount");
            return obj.iRetValue;
        }

        /// <summary>
        /// select getdate() ct;
        /// </summary>
        public static DateTime GetCurDateTime()
        {
            LoginService obj = Execute("_GetCurDateTime");
            return obj.dRetValue;
        }

        /// <summary>
        ///"select count(*) from " + aTables + " where " + aWhere
        /// </summary>
        public static int ExecuteSqlString(string ls_select)
        {
            LoginService obj = Execute("_ExecuteSqlString", ls_select);
            return obj.iRetValue;
        }
        /// <summary>
        ///"SELECT ct_next_contract  FROM contract_type  WHERE ct_key = :aContractType"
        /// </summary>
        public static int GetCTContract(int aContractType, ref int sqlCode)
        {
            LoginService obj = Execute("_GetCTContract", aContractType);
            sqlCode = obj._sqlCode;
            return obj.lNextValue;
        }

        /// <summary>
        ///"UPDATE contract_type SET ct_next_contract = :lNextValue + 1 WHERE ct_key = :aContractType"
        /// </summary>
        public static void UpdateContractType(int lNextValue, int aContractType)
        {
            LoginService obj = Execute("_UpdateContractType", lNextValue, aContractType);
        }

        /// <summary>
        ///"select next_value from id_codes where sequence_name = :sequencename"
        /// </summary>
        public static int GetIdCodes(string sequencename,ref int sqlcode)
        {
            LoginService obj = Execute("_GetIdCodes", sequencename);
            sqlcode = obj._sqlCode;
            return obj.nNextValue;
        }

        /// <summary>
        ///"insert into id_codes( sequence_name, next_value) values  ( :sequencename, 2)"
        /// </summary>
        public static void InsertIdCodes(string sequencename)
        {
            LoginService obj = Execute("_InsertIdCodes", sequencename);
        }

        /// <summary>
        ///"UPDATE id_codes set next_value = :nNextValue + 1 where sequence_name = :sequencename "
        /// </summary>
        public static void UpdateIdCodes(int nNextValue, string sequencename)
        {
            LoginService obj = Execute("_UpdateIdCodes", nNextValue, sequencename);
        }

        #endregion

        #region Server-side Code
        [ServerMethod()]
        private void _GetRegionCount()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "Select count ( *)  from region";
                    ParameterCollection param = new ParameterCollection();

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, param))
                    {
                        if (dr.Read())
                        {
                            iRetValue = dr.GetInt32(0);
                        }
                    }
                }
            }
        }


        [ServerMethod()]
        private void _TryConnectNZPO()
        {
            DbConnectionFactory.SetSessionDbConnection(System.Threading.Thread.CurrentPrincipal.Identity);
            try
            {
                bRetValue = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO").State == ConnectionState.Open;
            }
            catch (DbException)
            {
                bRetValue = false;
            }
        }

        [ServerMethod()]
        private void _LoginUser(string UserId, string PassWd)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT ui_id, ui_password_expiry, " +
                        "ui_grace_logins, ui_locked_date " +
                        "FROM rd.rds_user_id " +
                        "WHERE ((ui_userid = '" + UserId + "') AND " +
                        "(ui_password = '" + PassWd + "'))";

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, null))
                    {
                        if (dr.Read())
                        {
                            uiId = dr.GetInt32("ui_id");
                            graceLoginsRemaining = dr.GetInt16("ui_grace_logins");
                            passwordExpiryDate = dr.GetDateTime("ui_password_expiry");
                            accountLockedDate = dr.GetDateTime("ui_locked_date");

                            if (accountLockedDate != null && accountLockedDate != DateTime.MinValue)
                            {
                                // account is locked
                                iRetValue = -2;
                            }
                            else
                            {
                                //if (passwordExpiryDate != DateTime.MinValue &&
                                //    passwordExpiryDate < DateTime.Today)
                                //comment by hhuang on 09/08/2007
                                if(passwordExpiryDate == DateTime.MinValue || passwordExpiryDate < DateTime.Today)
                                {
                                    // password has expired return # of grace logins
                                    iRetValue = 10 + graceLoginsRemaining;
                                }
                                else
                                {
                                    // success
                                    iRetValue = 1;
                                }
                            }
                        }
                        else
                        {
                            iRetValue = -1;
                        }
                    }
                }
            }
        }

        [ServerMethod()]
        private void _UpdateUser(string UserId, int GraceLogins, DateTime? ExpiryDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    using (DbCommand cm = cn.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "UPDATE rd.rds_user_id" +
                            " SET ui_last_login_date=dateadd(dd,0, datediff(dd,0,GetDate()))," +
                            " ui_last_login_time=GetDate() - dateadd(dd,0, datediff(dd,0,GetDate())), " +
                            " ui_password_expiry=:ldt_ExpiryDate," +
                            " ui_grace_logins=:li_GraceLogins" +
                            " WHERE ui_userid=:as_UserId";

                        ParameterCollection param = new ParameterCollection();
                        param.Add(cm, "ldt_ExpiryDate", ExpiryDate);
                        param.Add(cm, "li_GraceLogins", GraceLogins);
                        param.Add(cm, "as_UserId", UserId);

                        DBHelper.ExecuteNonQuery(cm, param);
                        tr.Commit();
                    }
                }
            }
        }

        [ServerMethod()]
        private void _UpdatePassword(DateTime dExpiry, string UserId, int UiId, string sOldPassword, string sNewPassword)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    using (DbCommand cm = cn.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "UPDATE rd.rds_user_id" +
                            " SET ui_password = :sNewPassword," +
                            " ui_password_expiry = :dExpiry," +
                            " ui_grace_logins = 4" +
                            " WHERE ui_userid = :ls_ui_userid" +
                            " INSERT INTO rd.used_password ( ui_id,up_password) VALUES ( :ll_ui_id,:sOldPassword)";

                        ParameterCollection param = new ParameterCollection();
                        param.Add(cm, "dExpiry", dExpiry);
                        param.Add(cm, "sNewPassword", sNewPassword);
                        param.Add(cm, "ls_ui_userid", UserId);
                        param.Add(cm, "ll_ui_id", UiId);
                        param.Add(cm, "sOldPassword", sOldPassword);
                        DBHelper.ExecuteNonQuery(cm, param);
                        tr.Commit();
                    }
                }
            }
        }

        [ServerMethod()]
        private void _GetUiId(string userId)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT ui_id FROM rd.rds_user_id WHERE " +
                        "ui_userid = @ls_ui_userid";
                    ParameterCollection param = new ParameterCollection();
                    param.Add(cm, "ls_ui_userid", userId);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, param))
                    {
                        if (dr.Read())
                        {
                            uiId = dr.GetInt32("ui_id");
                        }
                        else
                            uiId = -1;

                    }
                }
            }
        }

        [ServerMethod()]
        private void _GetOldPass(int ui_id, string newPassword)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT up_password FROM rd.used_password WHERE ui_id = :ll_ui_id AND up_password = :sNewPassword";
                    ParameterCollection param = new ParameterCollection();
                    param.Add(cm, "ll_ui_id", ui_id);
                    param.Add(cm, "sNewPassword", newPassword);

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, param))
                    {
                        if (dr.Read())
                        {
                            oldPassword = dr.GetString(0);
                        }
                        else
                            oldPassword = null;

                    }
                }
            }
        }

        [ServerMethod()]
        private void _UpdateRdsUserIdUILockedDate(string ll_ui_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    using (DbCommand cm = cn.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "UPDATE rd.rds_user_id SET ui_locked_date = getdate() WHERE ui_userid = @ls_UserId;";
                        ParameterCollection pList = new ParameterCollection();
                        pList.Add(cm, "ls_UserId", ll_ui_id);
                        try
                        {
                            DBHelper.ExecuteNonQuery(cm, pList);
                            bRetValue = true;
                        }
                        catch (Exception e)
                        {
                            bRetValue = false;
                        }
                    }
                    tr.Commit();
                }
            }
        }

        [ServerMethod()]
        private void _GetRdsUserRightsMoreValue(string as_component, string as_user_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select count(*) from rds_user_rights rur, rds_user_id_group rui, rds_component rc, rds_user_id rid " +
                        "where rc.rc_name = @as_component and rid.ui_userid = @as_user_id and rui.ui_id = rid.ui_id and rur.ug_id = rui.ug_id and rc.rc_id = rur.rc_id and " +
                        "rur.rur_read = 'Y' and rur.ug_id = rui.ug_id";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "as_component", as_component);
                    pList.Add(cm, "as_user_id", as_user_id);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                iRetValue = dr.GetInt32(0);
                                _sqlCode = 0;
                            }
                            else
                                _sqlCode = 100;
                        }

                    }
                    catch (Exception e)
                    {
                        _sqlCode = -1;
                        _sqlErrText = e.Message;
                    }
                }
            }
        }

        [ServerMethod()]
        private void _GetRdsUserRightsMoreValue2(string as_component, string as_user_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select count(*) from rds_user_rights rur, rds_user_id_group rui, rds_component rc, rds_user_id rid " +
                        " where rc.rc_name = @as_component and rid.ui_userid = @as_user_id and rui.ui_id = rid.ui_id and rur.ug_id = rui.ug_id and rc.rc_id = rur.rc_id and rur.rur_modify = 'Y' and rur.ug_id = rui.ug_id ";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "as_component", as_component);
                    pList.Add(cm, "as_user_id", as_user_id);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                iRetValue = dr.GetInt32(0);
                                _sqlCode = 0;
                            }
                            else
                                _sqlCode = 100;
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlCode = -1;
                        _sqlErrText = e.Message;
                    }
                }
            }
        }

        [ServerMethod()]
        private void _GetNPADParameters(string ls_userid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select npad_enabled, npad_directory from npad_parameters  where npad_userid = @ls_userid";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ls_userid", ls_userid);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                                strVal = dr.GetString(1);
                                _sqlCode = 0;
                            }
                            else
                                _sqlCode = 100;
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlCode = -1;
                        _sqlErrText = e.Message;
                    }
                }
            }
        }

        [ServerMethod()]
        private void _GetNpadParametersDefault()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select npad_enabled, npad_directory from npad_parameters  where npad_userid = 'default'";

                    ParameterCollection pList = new ParameterCollection();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                intVal = dr.GetInt32(0);
                                strVal = dr.GetString(1);
                                _sqlCode = 0;
                            }
                            else
                                _sqlCode = 100;
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlCode = -1;
                        _sqlErrText = e.Message;
                    }
                }
            }
        }

        [ServerMethod()]
        private void _GetContractTypeCount()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    using (DbCommand cm = cn.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "Select count ( *) from contract_type";

                        ParameterCollection pList = new ParameterCollection();

                        try
                        {
                            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                            {
                                if (dr.Read())
                                {
                                    iRetValue = dr.GetInt32(0);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                        }
                    }
                    tr.Commit();
                }
            }
        }

        [ServerMethod()]
        private void _SetComplexSql(string sequencename)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    using (DbCommand cm = cn.CreateCommand())
                    {
                        int nNextValue = 0;
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.Text;

                        cm.CommandText = "select next_value from id_codes where sequence_name = @sequencename ";
                        ParameterCollection pList = new ParameterCollection();
                        pList.Add(cm, "sequencename", sequencename);
                        try
                        {
                            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                            {
                                if (dr.Read())
                                {
                                    nNextValue = dr.GetInt32(0);
                                    _sqlCode = 0;
                                }
                                else
                                    _sqlCode = 100;
                            }
                        }
                        catch (Exception e)
                        {
                            _sqlCode = -1;
                            _sqlErrText = e.Message;
                        }

                        if (_sqlCode != 0)
                        {
                            try
                            {
                                cm.CommandText = "insert into id_codes (sequence_name, next_value) values (@sequencename, 2) ";
                                DBHelper.ExecuteNonQuery(cm, pList);
                                iRetValue = 1;
                            }
                            catch
                            {
                                tr.Rollback();
                            }
                        }
                        else
                        {
                            try
                            {
                                cm.CommandText = "UPDATE id_codes set next_value = @nNextValue + 1 where sequence_name = @sequencename";
                                pList.Add(cm, "nNextValue", nNextValue);
                                DBHelper.ExecuteNonQuery(cm, pList);
                                iRetValue = nNextValue;
                            }
                            catch
                            {
                                tr.Rollback();
                            }
                        }
                        tr.Commit();
                    }
                }
            }
        }

        [ServerMethod()]
        private void _GetCurDateTime()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select getdate() ct";
                    ParameterCollection param = new ParameterCollection();

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, param))
                    {
                        if (dr.Read())
                        {
                            dRetValue = dr.GetDateTime(0);
                        }
                    }
                }
            }
        }

        [ServerMethod()]
        private void _ExecuteSqlString(string ls_select)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = ls_select;
                    ParameterCollection param = new ParameterCollection();

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, param))
                    {
                        if (dr.Read())
                        {
                            iRetValue = dr.GetInt32(0);
                        }
                    }
                }
            }
        }

        [ServerMethod()]
        private void _GetCTContract(int aContractType)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT ct_next_contract  FROM contract_type  WHERE ct_key = :aContractType";
                    ParameterCollection param = new ParameterCollection();
                    param.Add(cm, "aContractType", aContractType);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, param))
                    {
                        if (dr.Read())
                        {
                            lNextValue = dr.GetInt32(0);
                            sqlCode = 0;
                        }
                    }
                }
            }
        }

        [ServerMethod()]
        private void _UpdateContractType(int lNextValue, int aContractType)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "UPDATE contract_type SET ct_next_contract = :lNextValue + 1 WHERE ct_key = :aContractType";
                    ParameterCollection param = new ParameterCollection();
                    param.Add(cm, "lNextValue", lNextValue);
                    param.Add(cm, "aContractType", aContractType);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, param);
                    }
                    catch
                    { }
                }
            }
        }

        [ServerMethod()]
        private void _GetIdCodes(string sequencename)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select next_value from id_codes where sequence_name = :sequencename";
                    ParameterCollection param = new ParameterCollection();
                    param.Add(cm, "sequencename", sequencename);
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, param))
                    {
                        if (dr.Read())
                        {
                            nNextValue = dr.GetInt32(0);
                            sqlCode = 0;
                        }
                    }
                }
            }
        }

        [ServerMethod()]
        private void _InsertIdCodes(string sequencename)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "insert into id_codes( sequence_name, next_value) values  ( :sequencename, 2)";
                    ParameterCollection param = new ParameterCollection();
                    param.Add(cm, "sequencename", sequencename);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, param);
                    }
                    catch
                    { }
                }
            }
        }

        [ServerMethod()]
        private void _UpdateIdCodes(int nNextValue, string sequencename)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "UPDATE id_codes set next_value = :nNextValue + 1 where sequence_name = :sequencename";
                    ParameterCollection param = new ParameterCollection();
                    param.Add(cm, "nNextValue", nNextValue);
                    param.Add(cm, "sequencename", sequencename);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, param);
                    }
                    catch
                    { }
                }
            }
        }
        #endregion
    }
}
