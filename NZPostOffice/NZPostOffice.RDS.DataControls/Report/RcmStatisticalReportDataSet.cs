using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RRcmStatisticalReport
    {
        public int SortOrder
        {
            get
            {
                return 0;
            }
        }
        public string Description
        {
            get
            {
                return string.Empty;
            }
        }
        public string Val
        {
            get
            {
                return string.Empty;
            }
        }
        public string Region
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class RcmStatisticalReportDataSet : ReportDataSet<RcmStatisticalReport>
    {

        public DataColumn SortOrder = new DataColumn("SortOrder", typeof(int));

        public DataColumn Description = new DataColumn("Description", typeof(string));

        public DataColumn Val = new DataColumn("Val", typeof(string));

        public DataColumn Region = new DataColumn("Region", typeof(string));

        public RcmStatisticalReportDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				SortOrder,Description,Val,Region
				});
            SortOrder.AllowDBNull = true;

        }

        public RcmStatisticalReportDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<RcmStatisticalReport> datas = dataSource as Metex.Core.EntityBindingList<RcmStatisticalReport>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        public RcmStatisticalReportDataSet(RcmStatisticalReport obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<RcmStatisticalReport> list = new Metex.Core.EntityBindingList<RcmStatisticalReport>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public RcmStatisticalReportDataSet(RcmStatisticalReport[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<RcmStatisticalReport> list = new Metex.Core.EntityBindingList<RcmStatisticalReport>();
            foreach (RcmStatisticalReport d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }

        protected override DataRow ApplyRow(RcmStatisticalReport data)
        {
            DataRow row = this.NewRow();
            row["SortOrder"] = GetFieldValue(data.SortOrder);
            row["Description"] = GetFieldValue(data.Description);
            row["Val"] = GetFieldValue(data.Val);
            row["Region"] = GetFieldValue(data.Region);
            return row;
        }
    }
}
