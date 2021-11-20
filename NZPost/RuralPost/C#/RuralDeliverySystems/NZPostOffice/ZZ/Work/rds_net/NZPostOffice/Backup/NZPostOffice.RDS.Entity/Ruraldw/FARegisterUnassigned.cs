using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  RPCR_026  June-2011: New
    // For listing unallocated fixed assets (those not assigned to a contract)
    // Associated with DFARegisterUnassigned
    //
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("fa_fixed_asset_no", "_fa_fixed_asset_no", "fixed_asset_register")]
    [MapInfo("fat_id", "_fat_id", "fixed_asset_register")]
    [MapInfo("fa_owner", "_fa_owner", "fixed_asset_register")]
    [MapInfo("fa_purchase_date", "_fa_purchase_date", "fixed_asset_register")]
    [MapInfo("fa_purchase_price", "_fa_purchase_price", "fixed_asset_register")]
    [System.Serializable()]

    public class FARegisterUnassigned : Entity<FARegisterUnassigned>
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
        //    return string.Format("{0}", _fa_fixed_asset_no);
        //}
        
        private object idValue;

        public FARegisterUnassigned()
        {
            idValue = new object().GetHashCode();
        }

        protected override object GetIdValue()
        {
            return idValue;
        }
        #endregion

        #region Factory Methods
        public static FARegisterUnassigned[] GetAllFARegisterUnassigned()
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

                    cm.CommandText = "SELECT fixed_asset_register.fa_fixed_asset_no, "
                                          + "fixed_asset_register.fat_id, "
                                          + "fixed_asset_register.fa_owner, "
                                          + "fixed_asset_register.fa_purchase_date, "
                                          + "fixed_asset_register.fa_purchase_price "
                                    + " FROM fixed_asset_register "
                                    + "WHERE fixed_asset_register.fa_fixed_asset_no not in "
                                    + "          (select fa_fixed_asset_no from contract_fixed_assets) "
                                    + "ORDER BY fa_fixed_asset_no desc";

                    List<FARegisterUnassigned> _list = new List<FARegisterUnassigned>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                FARegisterUnassigned instance = new FARegisterUnassigned();
                                instance._fa_fixed_asset_no = GetValueFromReader<String>(dr, 0);
                                instance._fat_id = GetValueFromReader<Int32?>(dr, 1);
                                instance._fa_owner = GetValueFromReader<String>(dr, 2);
                                instance._fa_purchase_date = GetValueFromReader<DateTime?>(dr, 3);
                                instance._fa_purchase_price = GetValueFromReader<Decimal?>(dr, 4);

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

                    cm.CommandText = "DELETE FROM fixed_asset_register "
                                   + " WHERE fa_fixed_asset_no = @fa_fixed_asset_no ";
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
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(string fixed_asset_no)
        {
            _fa_fixed_asset_no = fixed_asset_no;
        }
    }
}
