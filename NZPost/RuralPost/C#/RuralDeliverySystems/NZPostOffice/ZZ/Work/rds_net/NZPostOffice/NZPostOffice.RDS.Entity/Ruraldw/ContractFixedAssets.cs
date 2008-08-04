using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("fa_fixed_asset_no", "_fa_fixed_asset_no", "contract_fixed_assets")]
    [MapInfo("fat_id", "_fat_id", "fixed_asset_register")]
    [MapInfo("fa_owner", "_fa_owner", "fixed_asset_register")]
    [MapInfo("fa_purchase_date", "_fa_purchase_date", "fixed_asset_register")]
    [MapInfo("fa_purchase_price", "_fa_purchase_price", "fixed_asset_register")]
    [MapInfo("contract_no", "_contract_no", "contract_fixed_assets")]
    [System.Serializable()]

    public class ContractFixedAssets : Entity<ContractFixedAssets>
    {
        #region Business Methods
        [DBField()]
        private string _fa_fixed_asset_no;

        [DBField()]
        private int? _fat_id;

        [DBField()]
        private string _fa_owner;

        [DBField()]
        private DateTime? _fa_purchase_date;

        [DBField()]
        private decimal? _fa_purchase_price;

        [DBField()]
        private int? _contract_no;

        public virtual string FaFixedAssetNo
        {
            get
            {
                CanReadProperty("FaFixedAssetNo", true);
                return _fa_fixed_asset_no;
            }
            set
            {
                CanWriteProperty("FaFixedAssetNo", true);
                if (_fa_fixed_asset_no != value)
                {
                    _fa_fixed_asset_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? FatId
        {
            get
            {
                CanReadProperty("FatId", true);
                return _fat_id;
            }
            set
            {
                CanWriteProperty("FatId", true);
                if (_fat_id != value)
                {
                    _fat_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string FaOwner
        {
            get
            {
                CanReadProperty("FaOwner", true);
                return _fa_owner;
            }
            set
            {
                CanWriteProperty("FaOwner", true);
                if (_fa_owner != value)
                {
                    _fa_owner = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? FaPurchaseDate
        {
            get
            {
                CanReadProperty("FaPurchaseDate", true);
                return _fa_purchase_date;
            }
            set
            {
                CanWriteProperty("FaPurchaseDate", true);
                if (_fa_purchase_date != value)
                {
                    _fa_purchase_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? FaPurchasePrice
        {
            get
            {
                CanReadProperty("FaPurchasePrice", true);
                return _fa_purchase_price;
            }
            set
            {
                CanWriteProperty("FaPurchasePrice", true);
                if (_fa_purchase_price != value)
                {
                    _fa_purchase_price = value;
                    PropertyHasChanged();
                }
            }
        }

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

        //protected override object GetIdValue()
        //{
        //    return string.Format("{0}/{1}", _fa_fixed_asset_no, _contract_no);
        //}
        public ContractFixedAssets()
        {
            idValue = new object().GetHashCode();
        }

        private object idValue;

        protected override object GetIdValue()
        {
            return idValue;
        }
        #endregion

        #region Factory Methods
        public static ContractFixedAssets NewContractFixedAssets(int? contract_no)
        {
            return Create(contract_no);
        }

        public static ContractFixedAssets[] GetAllContractFixedAssets(int? contract_no)
        {
            return Fetch(contract_no).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? contract_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "contract_no", contract_no);
                    cm.CommandText = "  SELECT fixed_asset_register.fa_fixed_asset_no,   " +
                        "fixed_asset_register.fat_id,   " +
                        "fixed_asset_register.fa_owner,   " +
                        "fixed_asset_register.fa_purchase_date,   " +
                        "fixed_asset_register.fa_purchase_price,   " +
                        "contract_fixed_assets.contract_no  " +
                        "FROM fixed_asset_register,contract_fixed_assets  " +
                        "WHERE ( fixed_asset_register.fa_fixed_asset_no = contract_fixed_assets.fa_fixed_asset_no ) and  ( ( contract_fixed_assets.contract_no = @contract_no ) )    ";

                    List<ContractFixedAssets> _list = new List<ContractFixedAssets>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ContractFixedAssets instance = new ContractFixedAssets();
                            instance._fa_fixed_asset_no = GetValueFromReader<String>(dr, 0);
                            instance._fat_id = GetValueFromReader<Int32?>(dr, 1);
                            instance._fa_owner = GetValueFromReader<String>(dr, 2);
                            instance._fa_purchase_date = GetValueFromReader<DateTime?>(dr, 3);
                            instance._fa_purchase_price = GetValueFromReader<Decimal?>(dr, 4);
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 5);

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
                if (GenerateUpdateCommandText(cm, "contract_fixed_assets", ref pList))
                {
                    cm.CommandText += " WHERE  contract_fixed_assets.fa_fixed_asset_no = @fa_fixed_asset_no AND " +
                        "contract_fixed_assets.contract_no = @contract_no ";

                    pList.Add(cm, "fa_fixed_asset_no", GetInitialValue("_fa_fixed_asset_no"));
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                // reinitialize original key/value list
                StoreInitialValues();
                MarkOld();
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
                if (GenerateInsertCommandText(cm, "contract_fixed_assets", pList))
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
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
                    pList.Add(cm, "fa_fixed_asset_no", GetInitialValue("_fa_fixed_asset_no"));
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    cm.CommandText = "DELETE FROM contract_fixed_assets WHERE " +
                    "contract_fixed_assets.fa_fixed_asset_no = @fa_fixed_asset_no AND " +
                    "contract_fixed_assets.contract_no = @contract_no ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(string fa_fixed_asset_no, int? contract_no)
        {
            _fa_fixed_asset_no = fa_fixed_asset_no;
            _contract_no = contract_no;
        }
    }
}
