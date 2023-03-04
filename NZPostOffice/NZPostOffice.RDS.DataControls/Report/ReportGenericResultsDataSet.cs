using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RReportGenericResults
    {
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public int ConActiveSequence
        {
            get
            {
                return 0;
            }
        }
        public string Compute1
        {
            get
            {
                return string.Empty;
            }
        }
        public string ConTitle
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class ReportGenericResultsDataSet : ReportDataSet<ReportGenericResults>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn ConActiveSequence = new DataColumn("ConActiveSequence", typeof(int));

        public DataColumn Compute1 = new DataColumn("Compute1", typeof(string));

        public DataColumn ConTitle = new DataColumn("ConTitle", typeof(string));


        public ReportGenericResultsDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,ConActiveSequence,Compute1,ConTitle
				});
            ContractNo.AllowDBNull = true;
            ConActiveSequence.AllowDBNull = true;

        }

        public ReportGenericResultsDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ReportGenericResults> datas = dataSource as Metex.Core.EntityBindingList<ReportGenericResults>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(ReportGenericResults data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["ConActiveSequence"] = GetFieldValue(data.ConActiveSequence);
            row["Compute1"] = GetFieldValue(data.Compute1);
            row["ConTitle"] = GetFieldValue(data.ConTitle);
            return row;
        }
    }
}
