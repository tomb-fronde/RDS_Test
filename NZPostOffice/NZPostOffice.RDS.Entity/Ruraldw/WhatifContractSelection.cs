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
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("con_title", "_con_title", "")]
    [MapInfo("contract_seq_number", "_contract_seq_number", "")]
    [System.Serializable()]

    public class WhatifContractSelection : Entity<WhatifContractSelection>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private string _con_title;

        [DBField()]
        private int? _contract_seq_number;


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

        public virtual string ConTitle
        {
            get
            {
                CanReadProperty("ConTitle", true);
                return _con_title;
            }
            set
            {
                CanWriteProperty("ConTitle", true);
                if (_con_title != value)
                {
                    _con_title = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ContractSeqNumber
        {
            get
            {
                CanReadProperty("ContractSeqNumber", true);
                return _contract_seq_number;
            }
            set
            {
                CanWriteProperty("ContractSeqNumber", true);
                if (_contract_seq_number != value)
                {
                    _contract_seq_number = value;
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
        public static WhatifContractSelection NewWhatifContractSelection(int? inRegion, int? inRGCode, int? inRegion1, int? inRGCode1)
        {
            return Create(inRegion, inRGCode, inRegion1, inRGCode1);
        }

        public static WhatifContractSelection[] GetAllWhatifContractSelection(int? inRegion, int? inRGCode, int? inRegion1, int? inRGCode1)
        {
            return Fetch(inRegion, inRGCode, inRegion1, inRGCode1).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? inRegion, int? inRGCode, int? inRegion1, int? inRGCode1)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inRegion", inRegion);
                    pList.Add(cm, "inRGCode", inRGCode);
                    pList.Add(cm, "inRegion", inRegion1);
                    pList.Add(cm, "inRGCode", inRGCode1);
                    cm.CommandText = "sp_GetContractsForWhatIf";

                    List<WhatifContractSelection> _list = new List<WhatifContractSelection>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            WhatifContractSelection instance = new WhatifContractSelection();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._con_title = GetValueFromReader<String>(dr,1);
                            instance._contract_seq_number = GetValueFromReader<Int32?>(dr,2);

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
