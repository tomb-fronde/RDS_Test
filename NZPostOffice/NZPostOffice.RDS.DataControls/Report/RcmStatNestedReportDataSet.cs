using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RRcmStatNestedReport
    {
        public string A
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class RcmStatNestedReportDataSet : ReportDataSet<RcmStatNestedReport>
    {

        public DataColumn A = new DataColumn("A", typeof(string));


        public RcmStatNestedReportDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				A
				});

        }

        public RcmStatNestedReportDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<RcmStatNestedReport> datas = dataSource as Metex.Core.EntityBindingList<RcmStatNestedReport>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(RcmStatNestedReport data)
        {
            DataRow row = this.NewRow();
            row["A"] = GetFieldValue(data.A);
            return row;
        }
    }
}
