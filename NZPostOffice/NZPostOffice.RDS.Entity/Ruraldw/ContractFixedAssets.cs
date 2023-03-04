using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  RPCR_026  July-2011
    // Added sh_id
    // Major changes to Fetch, Insert, Update, Delete functions to 
    // implement changes to contract_fixed_assets and fixed_asset_register.
    
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    // NOTE: Only the contract_no, fa_fixed_asset_no and sh_id columns are actual 
    //       members of the contract_fixed_assets table.  The others are actually 
    //       in the fixed_assets_register table, but are shown as here so that the 
    //       URdsDw routines will call the update function if any of their values
    //       are changed.
    [MapInfo("fa_fixed_asset_no", "_fa_fixed_asset_no", "contract_fixed_assets")]
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

        [DBField()]
        private int? _sh_id;

        private int? _sh_height;

        private int _sql_code;
        private string _sql_errtext;

        //===========================================================================
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
        //    return string.Format("{0}/{1}", _fa_fixed_asset_no, _contract_no);
        //}
        private object idValue;

        public ContractFixedAssets()
        {
            idValue = new object().GetHashCode();
        }

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
                    cm.CommandText = "SELECT contract_fixed_assets.fa_fixed_asset_no, "
                                          + "fixed_asset_register.fat_id, "
                                          + "fixed_asset_register.fa_owner, "
                                          + "fixed_asset_register.fa_purchase_date, "
                                          + "fixed_asset_register.fa_purchase_price, "
                                          + "contract_fixed_assets.contract_no, "
                                          + "contract_fixed_assets.sh_id, "
                                          + "strip_height.sh_height "
                                    + " FROM contract_fixed_assets left outer join strip_height "
                                       + "       on  strip_height.sh_id = contract_fixed_assets.sh_id "
                                       + " , fixed_asset_register "
                                    + "WHERE contract_fixed_assets.contract_no = @contract_no "
                                    + "  AND fixed_asset_register.fa_fixed_asset_no = contract_fixed_assets.fa_fixed_asset_no "
                                    + "ORDER BY fa_fixed_asset_no desc";

                    List<ContractFixedAssets> _list = new List<ContractFixedAssets>();
                    try
                    {
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
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    DbCommand cm = cn.CreateCommand();
                    ParameterCollection pList = new ParameterCollection();
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.Text;

                    cm.CommandText = "update fixed_asset_register "
                                      + " set fat_id = @fat_id "
                                      + "   , fa_purchase_date = @fa_purchase_date "
                                      + "   , fa_purchase_price = @fa_purchase_price "
                                      + "   , fa_owner = @fa_owner "
                                      + "where fa_fixed_asset_no = @fa_fixed_asset_no ";

                    pList.Add(cm, "fat_id", _fat_id);
                    pList.Add(cm, "fa_purchase_date", _fa_purchase_date);
                    pList.Add(cm, "fa_purchase_price", _fa_purchase_price);
                    pList.Add(cm, "fa_owner", _fa_owner);
                    pList.Add(cm, "fa_fixed_asset_no", _fa_fixed_asset_no);

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
                        tr.Rollback();
                        return;
                    }

                    // Some assets can not be associated with any contract. 
                    // We might be saving one of these.  
                    int? _initial_contract_no = (int?)GetInitialValue("_contract_no");
                    int? _initial_sh_id = (int?)GetInitialValue("_sh_id");

                    pList.Add(cm, "initial_contract_no", _initial_contract_no);
                    pList.Add(cm, "sh_id", _sh_id);
                    if (_contract_no == 0 || _contract_no == null)
                        pList.Add(cm, "contract_no", null);
                    else
                        pList.Add(cm, "contract_no", _contract_no);

                    // If we're removing an existing asset from any contract, we
                    // delete the customer_fixed_assets record.
                    if (_contract_no == null || _contract_no == 0)
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "delete from contract_fixed_assets "
                                         + "where contract_no = @initial_contract_no "
                                         + "  and fa_fixed_asset_no = @fa_fixed_asset_no ";
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
                            tr.Rollback();
                            return;
                        }
                    }
                    // If we're not switching the asset to a different contract, the sh_id
                    // may have changed.  Update all customer_fixed_assets records of the
                    // contract with the new sh_id.
                    else if (_initial_contract_no == _contract_no)
                    {
                        if (_initial_sh_id != _sh_id)
                        {
                            cm.CommandType = CommandType.Text;
                            cm.CommandText = "update contract_fixed_assets "
                                             + " set sh_id = @sh_id "
                                             + "where contract_no = @contract_no ";
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
                                tr.Rollback();
                                return;
                            }
                        }
                    }

                    // If we are switching the asset to a different contract, we can
                    // update the customer_fixed_assets record.  
                    // An issue here is that the sh_id for the new contract may be 
                    // different than the sh_id of the old contract, so we can't 
                    // simply transfer the sh_id along with the asset number via an 
                    // update of the contract_no in the contract_fixed_assets record.
                    if ( _contract_no  != null && _contract_no > 0 && _contract_no != _initial_contract_no)
                    {
                        // First, update the contract number
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "update contract_fixed_assets "
                                         + " set contract_no = @contract_no "
                                         + "where contract_no = @initial_contract_no "
                                         + "  and fa_fixed_asset_no = @fa_fixed_asset_no ";

                        pList.Add(cm, "contract_no", _contract_no);
                        pList.Add(cm, "sh_id", _sh_id);

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
                            tr.Rollback();
                            return;
                        }

                        // Now update the sh_id (it may not actually change, but this is 
                        // better than trying to decide if it will).
                        // The "1 < (select count(*) ..." takes care of the case where the 
                        // asset has been transferred to a contract that had no assets to 
                        // begin with (and hence doesn't have a strip height).
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "update contract_fixed_assets "
                                         + " set sh_id = (select top(1) sh_id from contract_fixed_assets "
                                         + "               where contract_no = @contract_no "
                                         + "                 and fa_fixed_asset_no != @fa_fixed_asset_no) "
                                         + "where contract_no = @contract_no "
                                         + "  and 1 < (select count(*) from contract_fixed_assets "
                                         + "            where contract_no = @contract_no)";

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
                            tr.Rollback();
                            return;
                        }
                    }

                    tr.Commit();
                    StoreInitialValues();
                    MarkOld();
                }
            }
        }

        [ServerMethod()]
        private void InsertEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    DbCommand cm = cn.CreateCommand();
                    ParameterCollection pList = new ParameterCollection();
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "INSERT INTO fixed_asset_register "
                                    + "  (fa_fixed_asset_no, fat_id, fa_purchase_date, fa_purchase_price, fa_owner) "
                                    + "VALUES "
                                    + "  (@fa_fixed_asset_no, @fat_id, @fa_purchase_date, @fa_purchase_price, @fa_owner) ";

                    pList.Add(cm, "fa_fixed_asset_no", _fa_fixed_asset_no);
                    pList.Add(cm, "fat_id", _fat_id);
                    pList.Add(cm, "fa_purchase_date", _fa_purchase_date);
                    pList.Add(cm, "fa_purchase_price", _fa_purchase_price);
                    pList.Add(cm, "fa_owner", _fa_owner);

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
                        tr.Rollback();
                        return;
                    }

                    // Some assets can not be associated with any contract.  We 
                    // might be saving one of these.  Only create a new 
                    // contract_fixed_assets record if there is a contract number.
                    if (_contract_no != null && _contract_no > 0)
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "INSERT INTO contract_fixed_assets "
                                        + "  (contract_no, fa_fixed_asset_no, sh_id) "
                                        + "VALUES "
                                        + "  (@contract_no, @fa_fixed_asset_no, @sh_id) ";

                        pList.Add(cm, "contract_no", _contract_no);
                        pList.Add(cm, "sh_id", _sh_id);
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
                            tr.Rollback();
                            return;
                        }
                    }

                    tr.Commit();
                    StoreInitialValues();
                    MarkOld();
                }
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
                    ParameterCollection pList = new ParameterCollection();
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.Text;

                    // Some assets can not be associated with any contract.  We might 
                    // be deleting one of these.  Only delete a contract_fixed_assets 
                    // record if there is a contract number.
                    int? _initial_contract_no = (int?)GetInitialValue("_contract_no");
                    if (_initial_contract_no != null && _initial_contract_no > 0)
                    {
                        cm.CommandText = "DELETE FROM contract_fixed_assets "
                                       + " WHERE contract_no = @contract_no "
                                       + "   AND fa_fixed_asset_no = @fa_fixed_asset_no ";
                        pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                        pList.Add(cm, "fa_fixed_asset_no", GetInitialValue("_fa_fixed_asset_no"));
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
                            tr.Rollback();
                            return;
                        }
                    }

                    cm.CommandText = "DELETE FROM fixed_asset_register "
                                   + " WHERE fa_fixed_asset_no = @fa_fixed_asset_no ";
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
                        tr.Rollback();
                        return;
                    }
                    tr.Commit();
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
