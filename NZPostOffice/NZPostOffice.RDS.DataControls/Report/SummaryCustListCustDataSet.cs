using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RSummaryCustListCust
    {
        public string A
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class SummaryCustListCustDataSet : ReportDataSet<SummaryCustListCust>
    {

        public DataColumn A = new DataColumn("A", typeof(string));


        public SummaryCustListCustDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				A
				});

        }

        public SummaryCustListCustDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<SummaryCustListCust> datas = dataSource as Metex.Core.EntityBindingList<SummaryCustListCust>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(SummaryCustListCust data)
        {
            DataRow row = this.NewRow();
            row["A"] = GetFieldValue(data.A);
            return row;
        }
    }
}
