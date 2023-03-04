using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RSummaryCustList
    {
        public string A
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class SummaryCustListDataSet : ReportDataSet<SummaryCustList>
    {

        public DataColumn A = new DataColumn("A", typeof(string));


        public SummaryCustListDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				A
				});

        }

        public SummaryCustListDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<SummaryCustList> datas = dataSource as Metex.Core.EntityBindingList<SummaryCustList>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(SummaryCustList data)
        {
            DataRow row = this.NewRow();
            row["A"] = GetFieldValue(data.A);
            return row;
        }
    }
}
