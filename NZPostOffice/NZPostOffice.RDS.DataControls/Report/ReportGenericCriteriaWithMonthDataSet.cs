using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RReportGenericCriteriaWithMonth
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
        public DateTime Monthyear
        {
            get
            {
                return DateTime.MinValue;
            }
        }
    }
    public class ReportGenericCriteriaWithMonthDataSet : ReportDataSet<ReportGenericCriteriaWithMonth>
    {

        public DataColumn RegionId = new DataColumn("RegionId", typeof(int));

        public DataColumn OutletId = new DataColumn("OutletId", typeof(int));

        public DataColumn OName = new DataColumn("OName", typeof(string));

        public DataColumn OutletPicklist = new DataColumn("OutletPicklist", typeof(int));

        public DataColumn CtKey = new DataColumn("CtKey", typeof(int));

        public DataColumn RgCode = new DataColumn("RgCode", typeof(int));

        public DataColumn SfKey = new DataColumn("SfKey", typeof(int));

        public DataColumn Monthyear = new DataColumn("Monthyear", typeof(DateTime));


        public ReportGenericCriteriaWithMonthDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				RegionId,OutletId,OName,OutletPicklist,CtKey,RgCode,SfKey,Monthyear
				});
            RegionId.AllowDBNull = true;
            OutletId.AllowDBNull = true;
            OutletPicklist.AllowDBNull = true;
            CtKey.AllowDBNull = true;
            RgCode.AllowDBNull = true;
            SfKey.AllowDBNull = true;
            Monthyear.AllowDBNull = true;

        }

        public ReportGenericCriteriaWithMonthDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ReportGenericCriteriaWithMonth> datas = dataSource as Metex.Core.EntityBindingList<ReportGenericCriteriaWithMonth>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(ReportGenericCriteriaWithMonth data)
        {
            DataRow row = this.NewRow();
            row["RegionId"] = GetFieldValue(data.RegionId);
            row["OutletId"] = GetFieldValue(data.OutletId);
            row["OName"] = GetFieldValue(data.OName);
            row["OutletPicklist"] = GetFieldValue(data.OutletPicklist);
            row["CtKey"] = GetFieldValue(data.CtKey);
            row["RgCode"] = GetFieldValue(data.RgCode);
            row["SfKey"] = GetFieldValue(data.SfKey);
            row["Monthyear"] = GetFieldValue(data.Monthyear);
            return row;
        }
    }
}
