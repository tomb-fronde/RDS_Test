using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RDeedCompliance
    {
        public string A
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class DeedComplianceDataSet : ReportDataSet<DeedCompliance>
    {

        public DataColumn A = new DataColumn("A", typeof(string));


        public DeedComplianceDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				A
				});

        }

        public DeedComplianceDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<DeedCompliance> datas = dataSource as Metex.Core.EntityBindingList<DeedCompliance>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(DeedCompliance data)
        {
            DataRow row = this.NewRow();
            row["A"] = GetFieldValue(data.A);
            return row;
        }
    }
}
