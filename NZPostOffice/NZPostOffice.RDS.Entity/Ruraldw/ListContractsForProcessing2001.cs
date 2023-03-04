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
    [MapInfo("con_active_sequence", "_con_active_sequence", "")]
    [MapInfo("max_sequence", "_max_sequence", "")]
    [MapInfo("con_title", "_con_title", "")]
    [MapInfo("con_acceptance_flag", "_con_acceptance_flag", "")]
    [System.Serializable()]

    public class ListContractsForProcessing2001 : Entity<ListContractsForProcessing2001>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _con_active_sequence;

        [DBField()]
        private int? _max_sequence;

        [DBField()]
        private string _con_title;

        [DBField()]
        private string _con_acceptance_flag;


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

        public virtual int? ConActiveSequence
        {
            get
            {
                CanReadProperty("ConActiveSequence", true);
                return _con_active_sequence;
            }
            set
            {
                CanWriteProperty("ConActiveSequence", true);
                if (_con_active_sequence != value)
                {
                    _con_active_sequence = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? MaxSequence
        {
            get
            {
                CanReadProperty("MaxSequence", true);
                return _max_sequence;
            }
            set
            {
                CanWriteProperty("MaxSequence", true);
                if (_max_sequence != value)
                {
                    _max_sequence = value;
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

        public virtual string ConAcceptanceFlag
        {
            get
            {
                CanReadProperty("ConAcceptanceFlag", true);
                return _con_acceptance_flag;
            }
            set
            {
                CanWriteProperty("ConAcceptanceFlag", true);
                if (_con_acceptance_flag != value)
                {
                    _con_acceptance_flag = value;
                    PropertyHasChanged();
                }
            }
        }
        // needs to implement compute expression manually:
        // compute control name=[rowstatus]
        //if( max_sequence = con_active_sequence,'Active',if( con_acceptance_flag ='Y','Accepted','Pending'))
        public virtual string Rowstatus
        {
            get
            {
                CanReadProperty("Rowstatus", true);
                return ( _max_sequence == _con_active_sequence ?"Active" :( _con_acceptance_flag == "Y"?"Accepted":"Pending"));
            }
        }

        public virtual string Compute1
        {
            get
            {
                CanReadProperty("Compute1", true);
                return _contract_no.GetValueOrDefault().ToString() + "/" + _max_sequence.GetValueOrDefault().ToString();
            }
        }
        
        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static ListContractsForProcessing2001 NewListContractsForProcessing2001(int? in_Region, int? in_RgCode, int? in_Contract)
        {
            return Create(in_Region, in_RgCode, in_Contract);
        }

        public static ListContractsForProcessing2001[] GetAllListContractsForProcessing2001(int? in_Region, int? in_RgCode, int? in_Contract)
        {
            return Fetch(in_Region, in_RgCode, in_Contract).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_Region, int? in_RgCode, int? in_Contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_Region", in_Region);
                    pList.Add(cm, "in_RgCode", in_RgCode);
                    pList.Add(cm, "in_Contract", in_Contract);
                    cm.CommandText = "sp_FindContractsForProc2001";

                    List<ListContractsForProcessing2001> _list = new List<ListContractsForProcessing2001>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ListContractsForProcessing2001 instance = new ListContractsForProcessing2001();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._con_active_sequence = GetValueFromReader<Int32?>(dr,1);
                            instance._max_sequence = GetValueFromReader<Int32?>(dr,2);
                            instance._con_title = GetValueFromReader<String>(dr,3);
                            instance._con_acceptance_flag = GetValueFromReader<String>(dr,4);
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
