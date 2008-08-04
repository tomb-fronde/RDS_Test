using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "address")]
    [MapInfo("adr_rd_no", "_rd_no", "address")]
    [MapInfo("post_code", "_post_code", "post_code")]
    [MapInfo("post_mail_town", "_mail_town", "post_code")]
    [MapInfo("tc_id", "_tc_id", "towncity")]
    [MapInfo("post_code_id", "_post_code_id", "post_code")]
    [System.Serializable()]

    public class DddwContractRd : Entity<DddwContractRd>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private string _rd_no;

        [DBField()]
        private string _post_code;

        [DBField()]
        private string _mail_town;

        [DBField()]
        private int? _tc_id;

        [DBField()]
        private int? _post_code_id;


        public virtual int? ContractNo
        {
            get
            {
                CanReadProperty("ContractNo", true);
                return _contract_no;
            }
            set
            {
                CanWriteProperty("ContractNo", true);
                if (_contract_no != value)
                {
                    _contract_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RdNo
        {
            get
            {
                CanReadProperty("RdNo", true);
                return _rd_no;
            }
            set
            {
                CanWriteProperty("RdNo", true);
                if (_rd_no != value)
                {
                    _rd_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PostCode
        {
            get
            {
                CanReadProperty("PostCode", true);
                return _post_code;
            }
            set
            {
                CanWriteProperty("PostCode", true);
                if (_post_code != value)
                {
                    _post_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string MailTown
        {
            get
            {
                CanReadProperty("MailTown", true);
                return _mail_town;
            }
            set
            {
                CanWriteProperty("MailTown", true);
                if (_mail_town != value)
                {
                    _mail_town = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? TcId
        {
            get
            {
                CanReadProperty("TcId", true);
                return _tc_id;
            }
            set
            {
                CanWriteProperty("TcId", true);
                if (_tc_id != value)
                {
                    _tc_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PostCodeId
        {
            get
            {
                CanReadProperty("PostCodeId", true);
                return _post_code_id;
            }
            set
            {
                CanWriteProperty("PostCodeId", true);
                if (_post_code_id != value)
                {
                    _post_code_id = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return RdNo;
        }
        #endregion

        #region Factory Methods
        public static DddwContractRd NewDddwContractRd()
        {
            return Create();
        }

        public static DddwContractRd[] GetAllDddwContractRd()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "SELECT DISTINCT address.contract_no ,address.adr_rd_no ,post_code.post_code ," +
                        "post_code.post_mail_town ,towncity.tc_id ,post_code.post_code_id " +
                        " FROM rd.address ,rd.post_code ,rd.towncity " +
                        " WHERE (address.post_code_id = post_code.post_code_id) and " +
                        "(post_code.post_mail_town = towncity.tc_name ) " +
                        " ORDER BY address.contract_no ASC,post_code.post_mail_town ASC,address.adr_rd_no ASC";

                    List<DddwContractRd> _list = new List<DddwContractRd>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            DddwContractRd instance = new DddwContractRd();
                            instance._contract_no = GetValueFromReader<int?>(dr, 0);
                            instance._rd_no = GetValueFromReader<string>(dr, 1);
                            instance._post_code = GetValueFromReader<string>(dr, 2);
                            instance._mail_town = GetValueFromReader<string>(dr, 3);
                            instance._tc_id = GetValueFromReader<int?>(dr, 4);
                            instance._post_code_id = GetValueFromReader<int?>(dr, 5);
                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        list = _list.ToArray();
                    }
                }
            }
        }

        #endregion

        [ServerMethod()]
        private void CreateEntity()
        {
        }
    }
}
