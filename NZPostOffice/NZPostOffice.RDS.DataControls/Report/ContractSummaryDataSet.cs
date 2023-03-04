using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RContractSummary
    {
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public int ContractSeqNumber
        {
            get
            {
                return 0;
            }
        }
        public DateTime Outdate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
    }
    public class ContractSummaryDataSet : ReportDataSet<ContractSummary>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn ContractSeqNumber = new DataColumn("ContractSeqNumber", typeof(int));

        public DataColumn Outdate = new DataColumn("Outdate", typeof(DateTime));


        public ContractSummaryDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,ContractSeqNumber,Outdate
				});
            ContractNo.AllowDBNull = true;
            ContractSeqNumber.AllowDBNull = true;
            Outdate.AllowDBNull = true;

        }

        public ContractSummaryDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ContractSummary> datas = dataSource as Metex.Core.EntityBindingList<ContractSummary>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(ContractSummary data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["ContractSeqNumber"] = GetFieldValue(data.ContractSeqNumber);
            row["Outdate"] = GetFieldValue(data.Outdate);
            return row;
        }
    }
}
