using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  RPCR_026  June-2011
    // Changed fixed asset info to reside in contract_fixed_assets (was fixed_asset_register)
    //
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("fa_fixed_asset_no", "_fa_fixed_asset_no", "contract_fixed_assets")]
    [MapInfo("fa_fixed_asset_num", "_fa_fixed_asset_num", "contract_fixed_assets")]
    [MapInfo("fat_id", "_fat_id", "contract_fixed_assets")]
    [MapInfo("fa_owner", "_fa_owner", "contract_fixed_assets")]
    [MapInfo("fa_purchase_date", "_fa_purchase_date", "contract_fixed_assets")]
    [MapInfo("fa_purchase_price", "_fa_purchase_price", "contract_fixed_assets")]
    [MapInfo("contract_no", "_contract_no", "contract_fixed_assets")]
    [MapInfo("sh_id", "_sh_id", "contract_fixed_assets")]
    [System.Serializable()]

    public class ContractFixedAssets : Entity<ContractFixedAssets>
    {
        #region Business Methods
        [DBField()]
        private int? _fa_fixed_asset_no;

        [DBField()]
        private string _fa_fixed_asset_num;

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

        [DBField()]
        private int? _sh_id;

        private int? _sh_height;

        private int _sql_code;
        private string _sql_errtext;

        //===========================================================================
        public virtual int? FaFixedAssetNo
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

        public virtual string FaFixedAssetNum
        {
            get
            {
                CanReadProperty("FaFixedAssetNum", true);
                return _fa_fixed_asset_num;
            }
            set
            {
                CanWriteProperty("FaFixedAssetNum", true);
                if (_fa_fixed_asset_num != value)
                {
                    _fa_fixed_asset_num = value;
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

        public virtual int? ShId
        {
            get
            {
                CanReadProperty("ShId", true);
                return _sh_id;
            }
            set
            {
                CanWriteProperty("ShId", true);
                if (_sh_id != value)
                {
                    _sh_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ShHeight
        {
            get
            {
                return _sh_height;
            }
            set
            {
                if (_sh_height != value)
                {
                    _sh_height = value;
                }
            }
        }

        public virtual int SqlCode
        {
            get
            {
                return _sql_code;
            }
            set
            {
                if (_sql_code != value)
                {
                    _sql_code = value;
                }
            }
        }

        public virtual string SqlErrText
        {
            get
            {
                return _sql_errtext;
            }
            set
            {
                if (_sql_errtext != value)
                {
                    _sql_errtext = value;
                }
            }
        }

        //protected override object GetIdValue()
        //{
        //    return string.Format("{0}/{1}", _fa_fixed_asset_num, _contract_no);
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
                    cm.CommandText = "SELECT contract_fixed_assets.fa_fixed_asset_num, "
                                          + "contract_fixed_assets.fat_id, "
                                          + "contract_fixed_assets.fa_owner, "
                                          + "contract_fixed_assets.fa_purchase_date, "
                                          + "contract_fixed_assets.fa_purchase_price, "
                                          + "contract_fixed_assets.contract_no, "
                                          + "contract_fixed_assets.sh_id, "
                                          + "strip_height.sh_height "
                                    + " FROM contract_fixed_assets left outer join strip_height "
                                       + "        on  strip_height.sh_id = contract_fixed_assets.sh_id "
                                    + "WHERE contract_fixed_assets.contract_no = @contract_no ";

                    List<ContractFixedAssets> _list = new List<ContractFixedAssets>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                ContractFixedAssets instance = new ContractFixedAssets();
                                instance._fa_fixed_asset_num = GetValueFromReader<String>(dr, 0);
                                instance._fat_id = GetValueFromReader<Int32?>(dr, 1);
                                instance._fa_owner = GetValueFromReader<String>(dr, 2);
                                instance._fa_purchase_date = GetValueFromReader<DateTime?>(dr, 3);
                                instance._fa_purchase_price = GetValueFromReader<Decimal?>(dr, 4);
                                instance._contract_no = GetValueFromReader<Int32?>(dr, 5);
                                instance._sh_id = GetValueFromReader<Int32?>(dr, 6);
                                instance._sh_height = GetValueFromReader<Int32?>(dr, 7);

                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                            list = _list.ToArray();
                            _sql_code = 0;
                            _sql_errtext = "Succeeded";
                        }
                    }
                    catch (Exception e)
                    {
                        _sql_code = -1;
                        _sql_errtext = e.Message;
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
                    cm.CommandText += " WHERE contract_fixed_assets.fa_fixed_asset_num = @fa_fixed_asset_num "
                                      + " AND contract_fixed_assets.contract_no = @contract_no ";
                    string asset_no_initialvalue = (string)GetInitialValue("_fa_fixed_asset_num");
                    int? contract_no_initialvalue = (int?)GetInitialValue("_contract_no");
                    string s = asset_no_initialvalue;
                    int? t = contract_no_initialvalue;
                    pList.Add(cm, "fa_fixed_asset_num", GetInitialValue("_fa_fixed_asset_num"));
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sql_code = 0;
                        _sql_errtext = "Succeeded";
                    }
                    catch (Exception e)
                    {
                        _sql_code = -1;
                        _sql_errtext = e.Message;
                    }
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
                pList.Add(cm, "contract_no", _contract_no);
                pList.Add(cm, "fa_fixed_asset_num", _fa_fixed_asset_num);
                pList.Add(cm, "fat_id", _fat_id);
                pList.Add(cm, "fa_purchase_date", _fa_purchase_date);
                pList.Add(cm, "fa_purchase_price", _fa_purchase_price);
                pList.Add(cm, "fa_owner", _fa_owner);
                pList.Add(cm, "sh_id", _sh_id);

                cm.CommandText = "INSERT INTO contract_fixed_assets "
                                + "  (contract_no, fa_fixed_asset_num, fat_id, fa_purchase_date, "
                                + "   fa_purchase_price, fa_owner, sh_id ) "
                                + "VALUES "
                                + "  (@contract_no, @fa_fixed_asset_num, @fat_id, @fa_purchase_date, "
                                + "   @fa_purchase_price, @fa_owner, @sh_id ) ";
                int? t1 = _sh_id;
                int? t2 = t1;

                //if (GenerateInsertCommandText(cm, "contract_fixed_assets", pList))
                //{
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sql_code = 0;
                        _sql_errtext = "Succeeded";
                        StoreInitialValues();
                    }
                    catch (Exception e)
                    {
                        _sql_code = -1;
                        _sql_errtext = e.Message;
                    }
                //}
                //StoreInitialValues();
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
                    pList.Add(cm, "fa_fixed_asset_num", GetInitialValue("_fa_fixed_asset_num"));
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    cm.CommandText = "DELETE FROM contract_fixed_assets "
                                   + " WHERE contract_fixed_assets.fa_fixed_asset_num = @fa_fixed_asset_num "
                                   + "   AND contract_fixed_assets.contract_no = @contract_no ";
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sql_code = 0;
                        _sql_errtext = "Succeeded";
                        tr.Commit();
                    }
                    catch (Exception e)
                    {
                        _sql_code = -1;
                        _sql_errtext = e.Message;
                        tr.Rollback();
                    }
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? contract_no)
        {
            _contract_no = contract_no;
        }
    }
}
