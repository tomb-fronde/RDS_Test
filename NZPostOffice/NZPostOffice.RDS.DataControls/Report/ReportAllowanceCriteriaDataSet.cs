using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RReportAllowanceCriteria
    {
        public int RgCode
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
        public int RegionId
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
        public int OutletId
        {
            get
            {
                return 0;
            }
        }
    }
    public class ReportAllowanceCriteriaDataSet : ReportDataSet<ReportAllowanceCriteria>
    {

        public DataColumn RgCode = new DataColumn("RgCode", typeof(int));

        public DataColumn CtKey = new DataColumn("CtKey", typeof(int));

        public DataColumn RegionId = new DataColumn("RegionId", typeof(int));

        public DataColumn SfKey = new DataColumn("SfKey", typeof(int));

        public DataColumn OutletId = new DataColumn("OutletId", typeof(int));


        public ReportAllowanceCriteriaDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				RgCode,CtKey,RegionId,SfKey,OutletId
				});
            RgCode.AllowDBNull = true;
            CtKey.AllowDBNull = true;
            RegionId.AllowDBNull = true;
            SfKey.AllowDBNull = true;
            OutletId.AllowDBNull = true;

        }

        public ReportAllowanceCriteriaDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ReportAllowanceCriteria> datas = dataSource as Metex.Core.EntityBindingList<ReportAllowanceCriteria>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(ReportAllowanceCriteria data)
        {
            DataRow row = this.NewRow();
            row["RgCode"] = GetFieldValue(data.RgCode);
            row["CtKey"] = GetFieldValue(data.CtKey);
            row["RegionId"] = GetFieldValue(data.RegionId);
            row["SfKey"] = GetFieldValue(data.SfKey);
            row["OutletId"] = GetFieldValue(data.OutletId);
            return row;
        }
    }
}
