using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  RPCR_025  8-June-2011: New
    // See also  RDS/Windows/Ruralwin/WContract2001
    //      and  DataControls/Ruraldw/DFreightAllocations


    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no",    "_contract_no",    "freight_allocations")]
    [MapInfo("fr_active_ind",  "_fr_active_ind",  "freight_allocations")]
    [MapInfo("pbu_id",         "_pbu_id",         "freight_allocations")]
    [MapInfo("fr_ecl_pct",     "_fr_ecl_pct",     "freight_allocations")]
    [MapInfo("fr_reachmedia_pct",  "_fr_reachmedia_pct",  "freight_allocations")]
    [MapInfo("fr_psg_pct",     "_fr_psg_pct",     "freight_allocations")]
    [System.Serializable()]

    public class FreightAllocations : Entity<FreightAllocations>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _fr_active_ind;

        [DBField()]
        private int? _pbu_id;

        [DBField()]
        private int? _fr_ecl_pct;

        [DBField()]
        private int? _fr_reachmedia_pct;

        [DBField()]
        private int? _fr_psg_pct;


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

        public virtual int? FrActiveInd
        {
            get
            {
                CanReadProperty("FrActiveInd", true);
                return _fr_active_ind;
            }
            set
            {
                CanWriteProperty("FrActiveInd", true);
                if (_fr_active_ind != value)
                {
                    _fr_active_ind = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PbuId
        {
            get
            {
                CanReadProperty("PbuId", true);
                return _pbu_id;
            }
            set
            {
                CanWriteProperty("PbuId", true);
                if (_pbu_id != value)
                {
                    _pbu_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? FrEclPct
        {
            get
            {
                CanReadProperty("FrEclPct", true);
                return _fr_ecl_pct;
            }
            set
            {
                CanWriteProperty("FrEclPct", true);
                if (_fr_ecl_pct != value)
                {
                    _fr_ecl_pct = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? FrReachmediaPct
        {
            get
            {
                CanReadProperty("FrReachmediaPct", true);
                return _fr_reachmedia_pct;
            }
            set
            {
                CanWriteProperty("FrReachmediaPct", true);
                if (_fr_reachmedia_pct != value)
                {
                    _fr_reachmedia_pct = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? FrPsgPct
        {
            get
            {
                CanReadProperty("FrPsgPct", true);
                return _fr_psg_pct;
            }
            set
            {
                CanWriteProperty("FrPsgPct", true);
                if (_fr_psg_pct != value)
                {
                    _fr_psg_pct = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? TotalAlloc
        {
            get
            {
                CanReadProperty("ContractNo", true);
                return (_fr_ecl_pct == null ? 0 : _fr_ecl_pct)
                        + (_fr_reachmedia_pct == null ? 0 : _fr_reachmedia_pct)
                        + (_fr_psg_pct == null ? 0 : _fr_psg_pct);
            }
        }

        //protected override object GetIdValue()
        //{
        //    return string.Format("{0}", _contract_no);
        //}

        public FreightAllocations()
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
        public static FreightAllocations NewFreightAllocations(int? contract_no)
        {
            return Create(contract_no);
        }

        public static FreightAllocations[] GetAllFreightAllocations(int? contract_no)
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

                    cm.CommandText = "SELECT freight_allocations.contract_no, "
                                     + "freight_allocations.fr_active_ind, "
                                     + "freight_allocations.pbu_id, "
                                     + "freight_allocations.fr_ecl_pct, "
                                     + "freight_allocations.fr_reachmedia_pct, "
                                     + "freight_allocations.fr_psg_pct "
                                + "FROM freight_allocations "
                               + "WHERE freight_allocations.contract_no = @contract_no ";

                    List<FreightAllocations> _list = new List<FreightAllocations>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            FreightAllocations instance = new FreightAllocations();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._fr_active_ind = GetValueFromReader<Int32?>(dr, 1);
                            instance._pbu_id = GetValueFromReader<Int32?>(dr, 2);
                            instance._fr_ecl_pct = GetValueFromReader<Int32?>(dr, 3);
                            instance._fr_reachmedia_pct = GetValueFromReader<Int32?>(dr, 4);
                            instance._fr_psg_pct = GetValueFromReader<Int32?>(dr, 5);

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
                if (GenerateUpdateCommandText(cm, "freight_allocations", ref pList))
                {
                    cm.CommandText += " WHERE  freight_allocations.contract_no = @contract_no ";

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
                if (GenerateInsertCommandText(cm, "freight_allocations", pList))
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
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    
                    cm.CommandText = "DELETE FROM freight_allocations " 
                                    + "WHERE freight_allocations.contract_no = @contract_no ";
                                     
                    DBHelper.ExecuteNonQuery(cm, pList);
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
