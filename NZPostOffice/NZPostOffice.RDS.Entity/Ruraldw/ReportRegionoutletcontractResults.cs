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
    [System.Serializable()]

    public class ReportRegionoutletcontractResults : Entity<ReportRegionoutletcontractResults>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private string _con_title;


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

        public virtual string Compute1
        {
            get
            {
                CanReadProperty("Compute1", true);
                return (_contract_no.GetValueOrDefault().ToString());
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static ReportRegionoutletcontractResults NewReportRegionoutletcontractResults(int? Inregion, int? inOutlet, int? inContract)
        {
            return Create(Inregion, inOutlet, inContract);
        }

        public static ReportRegionoutletcontractResults[] GetAllReportRegionoutletcontractResults(int? Inregion, int? inOutlet, int? inContract)
        {
            return Fetch(Inregion, inOutlet, inContract).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? Inregion, int? inOutlet, int? inContract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "Inregion", Inregion);
                    pList.Add(cm, "inOutlet", inOutlet);
                    pList.Add(cm, "inContract", inContract);
                    cm.CommandText = "rd.sp_getregionoutletcontracts";

                    List<ReportRegionoutletcontractResults> _list = new List<ReportRegionoutletcontractResults>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ReportRegionoutletcontractResults instance = new ReportRegionoutletcontractResults();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._con_title = GetValueFromReader<String>(dr,1);
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
