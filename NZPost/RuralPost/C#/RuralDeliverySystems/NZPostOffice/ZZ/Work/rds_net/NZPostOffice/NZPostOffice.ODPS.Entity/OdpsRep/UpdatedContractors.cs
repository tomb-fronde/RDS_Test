using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;
using NZPostOffice.Shared.LogicUnits;

namespace NZPostOffice.ODPS.Entity.OdpsRep
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("ds_no", "_ds_no", "")]
    [MapInfo("title", "_title", "")]
    [MapInfo("initials", "_initials", "")]
    [MapInfo("surname_company", "_surname_company", "")]
    [MapInfo("address1", "_address1", "")]
    [MapInfo("bank_account_no", "_bank_account_no", "")]
    [MapInfo("bank", "_bank", "")]
    [MapInfo("branch", "_branch", "")]
    [MapInfo("changetype", "_changetype", "")]
    [MapInfoIndex(new string[] { "ds_no", "title", "initials", "surname_company", "address1", "bank_account_no",
        "bank", "branch", "changetype" })]
    [System.Serializable()]

    public class UpdatedContractors : Entity<UpdatedContractors>
    {
        #region Business Methods
        [DBField()]
        private string _ds_no;

        [DBField()]
        private string _title;

        [DBField()]
        private string _initials;

        [DBField()]
        private string _surname_company;

        [DBField()]
        private string _address1;

        [DBField()]
        private string _bank_account_no;

        [DBField()]
        private string _bank;

        [DBField()]
        private string _branch;

        [DBField()]
        private string _changetype;


        public virtual string DsNo
        {
            get
            {
                CanReadProperty("DsNo", true);
                return _ds_no;
            }
            set
            {
                CanWriteProperty("DsNo", true);
                if (_ds_no != value)
                {
                    _ds_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Title
        {
            get
            {
                CanReadProperty("Title", true);
                return _title;
            }
            set
            {
                CanWriteProperty("Title", true);
                if (_title != value)
                {
                    _title = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Initials
        {
            get
            {
                CanReadProperty("Initials", true);
                return _initials;
            }
            set
            {
                CanWriteProperty("Initials", true);
                if (_initials != value)
                {
                    _initials = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string SurnameCompany
        {
            get
            {
                CanReadProperty("SurnameCompany", true);
                return _surname_company;
            }
            set
            {
                CanWriteProperty("SurnameCompany", true);
                if (_surname_company != value)
                {
                    _surname_company = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Address1
        {
            get
            {
                CanReadProperty("Address1", true);
                return _address1;
            }
            set
            {
                CanWriteProperty("Address1", true);
                if (_address1 != value)
                {
                    _address1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string BankAccountNo
        {
            get
            {
                CanReadProperty("BankAccountNo", true);
                return _bank_account_no;
            }
            set
            {
                CanWriteProperty("BankAccountNo", true);
                if (_bank_account_no != value)
                {
                    _bank_account_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Bank
        {
            get
            {
                CanReadProperty("Bank", true);
                return _bank;
            }
            set
            {
                CanWriteProperty("Bank", true);
                if (_bank != value)
                {
                    _bank = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Branch
        {
            get
            {
                CanReadProperty("Branch", true);
                return _branch;
            }
            set
            {
                CanWriteProperty("Branch", true);
                if (_branch != value)
                {
                    _branch = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Changetype
        {
            get
            {
                CanReadProperty("Changetype", true);
                return _changetype;
            }
            set
            {
                CanWriteProperty("Changetype", true);
                if (_changetype != value)
                {
                    _changetype = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static UpdatedContractors NewUpdatedContractors(DateTime? FromDate, DateTime? ToDate)
        {
            return Create(FromDate, ToDate);
        }

        public static UpdatedContractors[] GetAllUpdatedContractors(DateTime? FromDate, DateTime? ToDate)
        {
            return Fetch(FromDate, ToDate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? FromDate, DateTime? ToDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_updatedcontractors";
                    cm.CommandTimeout = 300;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "FromDate", FromDate);
                    pList.Add(cm, "ToDate", ToDate);

                    List<UpdatedContractors> _list = new List<UpdatedContractors>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            UpdatedContractors instance = new UpdatedContractors();
                            instance.DsNo = GetValueFromReader<string>(dr, 0);
                            instance.Title = GetValueFromReader<string>(dr, 1);
                            instance.Initials = GetValueFromReader<string>(dr, 2);
                            instance.SurnameCompany = GetValueFromReader<string>(dr, 3);
                            instance.Address1 = GetValueFromReader<string>(dr, 4);
                            instance.BankAccountNo = GetValueFromReader<string>(dr, 5);
                            instance.Bank = GetValueFromReader<string>(dr, 6);
                            instance.Branch = GetValueFromReader<string>(dr, 7);
                            instance.Changetype = GetValueFromReader<string>(dr, 8);
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
