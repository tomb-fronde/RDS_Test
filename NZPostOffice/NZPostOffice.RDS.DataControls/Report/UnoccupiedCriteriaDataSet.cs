using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RUnoccupiedCriteria
    {
        public int RegionId
        {
            get
            {
                return 0;
            }
        }
        public int OutletId
        {
            get
            {
                return 0;
            }
        }
        public string OName
        {
            get
            {
                return string.Empty;
            }
        }
        public int OutletPicklist
        {
            get
            {
                return 0;
            }
        }
        public int CtKey
        {
            get
            {
                return 0;
            }
        }
        public int RgCode
        {
            get
            {
                return 0;
            }
        }
        public int SfKey
        {
            get
            {
                return 0;
            }
        }
        public DateTime Ceffectivedate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
    }
    public class UnoccupiedCriteriaDataSet : ReportDataSet<UnoccupiedCriteria>
    {

        public DataColumn RegionId = new DataColumn("RegionId", typeof(int));

        public DataColumn OutletId = new DataColumn("OutletId", typeof(int));

        public DataColumn OName = new DataColumn("OName", typeof(string));

        public DataColumn OutletPicklist = new DataColumn("OutletPicklist", typeof(int));

        public DataColumn CtKey = new DataColumn("CtKey", typeof(int));

        public DataColumn RgCode = new DataColumn("RgCode", typeof(int));

        public DataColumn SfKey = new DataColumn("SfKey", typeof(int));

        public DataColumn Ceffectivedate = new DataColumn("Ceffectivedate", typeof(DateTime));


        public UnoccupiedCriteriaDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				RegionId,OutletId,OName,OutletPicklist,CtKey,RgCode,SfKey,Ceffectivedate
				});
            RegionId.AllowDBNull = true;
            OutletId.AllowDBNull = true;
            OutletPicklist.AllowDBNull = true;
            CtKey.AllowDBNull = true;
            RgCode.AllowDBNull = true;
            SfKey.AllowDBNull = true;
            Ceffectivedate.AllowDBNull = true;

        }

        public UnoccupiedCriteriaDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<UnoccupiedCriteria> datas = dataSource as Metex.Core.EntityBindingList<UnoccupiedCriteria>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(UnoccupiedCriteria data)
        {
            DataRow row = this.NewRow();
            row["RegionId"] = GetFieldValue(data.RegionId);
            row["OutletId"] = GetFieldValue(data.OutletId);
            row["OName"] = GetFieldValue(data.OName);
            row["OutletPicklist"] = GetFieldValue(data.OutletPicklist);
            row["CtKey"] = GetFieldValue(data.CtKey);
            row["RgCode"] = GetFieldValue(data.RgCode);
            row["SfKey"] = GetFieldValue(data.SfKey);
            row["Ceffectivedate"] = GetFieldValue(data.Ceffectivedate);
            return row;
        }
    }
}
