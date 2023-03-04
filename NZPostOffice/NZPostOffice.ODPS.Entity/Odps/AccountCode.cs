using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.Odps
{
    [MapInfo("ac_id", "_ac_id", "odps.account_codes", true)]
    [MapInfo("ac_code", "_ac_code", "odps.account_codes")]
    [MapInfo("ac_description", "_ac_description", "odps.account_codes")]
    [System.Serializable()]
    public class AccountCode : Entity<AccountCode>
    {
        #region Business Methods
        [DBField()]
        private int? _ac_id;

        [DBField()]
        private string _ac_code;

        [DBField()]
        private string _ac_description;

        public virtual int? AcId
        {
            get
            {
                CanReadProperty("AcId", true);
                return _ac_id;
            }
            set
            {
                CanWriteProperty("AcId", true);
                if (_ac_id != value)
                {
                    _ac_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AcCode
        {
            get
            {
                CanReadProperty("AcCode", true);
                return _ac_code;
            }
            set
            {
                CanWriteProperty("AcCode", true);
                if (_ac_code != value)
                {
                    _ac_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AcDescription
        {
            get
            {
                CanReadProperty("AcDescription", true);
                return _ac_description;
            }
            set
            {
                CanWriteProperty("AcDescription", true);
                if (_ac_description != value)
                {
                    _ac_description = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}", _ac_id);
        }
        #endregion

        #region Factory Methods
        public static AccountCode NewAccountCode()
        {
            return Create();
        }

        public static AccountCode[] GetAllAccountCode()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity()
        {
            //? using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection())
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    //GenerateSelectCommandText(cm, "odps.account_codes");
                    cm.CommandText = "SELECT account_codes.ac_id , account_codes.ac_code ,account_codes.ac_description  FROM odps.account_codes";

                    List<AccountCode> _list = new List<AccountCode>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            AccountCode instance = new AccountCode();
                            instance._ac_id = GetValueFromReader<Int32?>(dr, 0);
                            instance._ac_code = GetValueFromReader<string>(dr, 1);
                            instance._ac_description = GetValueFromReader<string>(dr, 2);
                            //instance.StoreFieldValues(dr, "odps.account_codes");
                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        list = _list.ToArray();
                    }
                }
            }
        }

        [ServerMethod()]
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "odps.account_codes", ref pList))
                {
                    cm.CommandText += " WHERE  account_codes.ac_id = @ac_id ";

                    pList.Add(cm, "ac_id", GetInitialValue("_ac_id"));
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception ex)
                    {
                        this.sqlCode = -1;
                        this.sqlErrText = ex.Message.ToString();
                    }
                }
                // reinitialize original key/value list
                StoreInitialValues();
            }
        }

        [ServerMethod()]
        private void InsertEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                //  cm.CommandText = "insert into account_codes(ac_code,ac_description) values(@ac_code,@ac_description) ";

                if (GenerateInsertCommandText(cm, "odps.account_codes", pList))
                {
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch(Exception ex)
                    {
                        this.sqlCode = -1;
                        this.sqlErrText = ex.Message.ToString();
                    }
                }
                StoreInitialValues();
            }
        }

        [ServerMethod()]
        private void DeleteEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    DbCommand cm = cn.CreateCommand();
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ac_id", GetInitialValue("_ac_id"));
                    cm.CommandText = "DELETE FROM account_codes WHERE account_codes.ac_id = @ac_id ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? ac_id)
        {
            _ac_id = ac_id;
        }
    }
}
