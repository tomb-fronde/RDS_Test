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
    [MapInfo("pct_id", "_pct_id", "")]
    [MapInfo("pct_description", "_pct_description", "")]
    [MapInfo("pcg_short_code", "_pcg_short_code", "")]
    [System.Serializable()]

    public class DddwPaymentComponents : Entity<DddwPaymentComponents>
    {
        #region Business Methods
        [DBField()]
        private int? _pct_id;

        [DBField()]
        private string _pct_description;

        [DBField()]
        private string _pcg_short_code;


        public virtual int? PctId
        {
            get
            {
                CanReadProperty("PctId", true);
                return _pct_id;
            }
            set
            {
                CanWriteProperty("PctId", true);
                if (_pct_id != value)
                {
                    _pct_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PctDescription
        {
            get
            {
                CanReadProperty("PctDescription", true);
                return _pct_description;
            }
            set
            {
                CanWriteProperty("PctDescription", true);
                if (_pct_description != value)
                {
                    _pct_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PcgShortCode
        {
            get
            {
                CanReadProperty("PcgShortCode", true);
                return _pcg_short_code;
            }
            set
            {
                CanWriteProperty("PcgShortCode", true);
                if (_pcg_short_code != value)
                {
                    _pcg_short_code = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return _pct_id + " ";
        }

        //ToString
        public override string ToString()
        {
            if (PctDescription != null)
                return PctDescription.PadRight(45, ' ') + PcgShortCode;
             return "";
        } 
        #endregion

        #region Factory Methods
        public static DddwPaymentComponents NewDddwPaymentComponents()
        {
            return Create();
        }

        public static DddwPaymentComponents[] GetAllDddwPaymentComponents()
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
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = "odps.od_cts_paymentcomponents";

                    List<DddwPaymentComponents> _list = new List<DddwPaymentComponents>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            DddwPaymentComponents instance = new DddwPaymentComponents();
                            instance._pct_id = GetValueFromReader<Int32?>(dr,0);
                            instance._pct_description = GetValueFromReader<String>(dr,1);
                            instance._pcg_short_code = GetValueFromReader<String>(dr,2);
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
