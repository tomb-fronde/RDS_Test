using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.RDS.Entity.Ruralrpt;
using System.Data;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RAllowanceReport
    {
        public string A
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class AllowanceReportDataSet : ReportDataSet<AllowanceReport>
    {

        public DataColumn A = new DataColumn("A", typeof(string));


        public AllowanceReportDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				A
				});

        }

        public AllowanceReportDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<AllowanceReport> datas = dataSource as Metex.Core.EntityBindingList<AllowanceReport>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(AllowanceReport data)
        {
            DataRow row = this.NewRow();
            row["A"] = GetFieldValue(data.A);
            return row;
        }
    }
}
