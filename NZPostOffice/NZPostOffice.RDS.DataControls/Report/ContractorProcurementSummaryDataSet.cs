using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RContractorProcurementSummary
    {
        public string Region
        {
            get
            {
                return string.Empty;
            }
        }
        public string Procurement
        {
            get
            {
                return string.Empty;
            }
        }
        public int Contractors
        {
            get
            {
                return 0;
            }
        }
        public int Procid
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
    }
    public class ContractorProcurementSummaryDataSet : ReportDataSet<ContractorProcurementSummary>
    {

        public DataColumn Region = new DataColumn("Region", typeof(string));

        public DataColumn Procurement = new DataColumn("Procurement", typeof(string));

        public DataColumn Contractors = new DataColumn("Contractors", typeof(int));

        public DataColumn Procid = new DataColumn("Procid", typeof(int));

        public DataColumn RegionId = new DataColumn("RegionId", typeof(int));


        public ContractorProcurementSummaryDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Region,Procurement,Contractors,Procid,RegionId
				});
            Contractors.AllowDBNull = true;
            Procid.AllowDBNull = true;
            RegionId.AllowDBNull = true;

        }

        public ContractorProcurementSummaryDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ContractorProcurementSummary> datas = dataSource as Metex.Core.EntityBindingList<ContractorProcurementSummary>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(ContractorProcurementSummary data)
        {
            DataRow row = this.NewRow();
            row["Region"] = GetFieldValue(data.Region);
            row["Procurement"] = GetFieldValue(data.Procurement);
            row["Contractors"] = GetFieldValue(data.Contractors);
            row["Procid"] = GetFieldValue(data.Procid);
            row["RegionId"] = GetFieldValue(data.RegionId);
            return row;
        }
    }
}
