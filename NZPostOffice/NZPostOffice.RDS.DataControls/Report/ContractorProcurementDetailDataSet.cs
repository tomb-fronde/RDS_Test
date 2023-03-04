using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RContractorProcurementDetail
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
        public string Contract
        {
            get
            {
                return string.Empty;
            }
        }
        public int Contractor
        {
            get
            {
                return 0;
            }
        }
        public string ContractorName
        {
            get
            {
                return string.Empty;
            }
        }
        public int RegionRegionId
        {
            get
            {
                return 0;
            }
        }
        public int ProcurementProcid
        {
            get
            {
                return 0;
            }
        }
    }
    public class ContractorProcurementDetailDataSet : ReportDataSet<ContractorProcurementDetail>
    {

        public DataColumn Region = new DataColumn("Region", typeof(string));

        public DataColumn Procurement = new DataColumn("Procurement", typeof(string));

        public DataColumn Contract = new DataColumn("Contract", typeof(string));

        public DataColumn Contractor = new DataColumn("Contractor", typeof(int));

        public DataColumn ContractorName = new DataColumn("ContractorName", typeof(string));

        public DataColumn RegionRegionId = new DataColumn("RegionRegionId", typeof(int));

        public DataColumn ProcurementProcid = new DataColumn("ProcurementProcid", typeof(int));


        public ContractorProcurementDetailDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Region,Procurement,Contract,Contractor,ContractorName,RegionRegionId,ProcurementProcid
				});
            Contractor.AllowDBNull = true;
            RegionRegionId.AllowDBNull = true;
            ProcurementProcid.AllowDBNull = true;

        }

        public ContractorProcurementDetailDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ContractorProcurementDetail> datas = dataSource as Metex.Core.EntityBindingList<ContractorProcurementDetail>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(ContractorProcurementDetail data)
        {
            DataRow row = this.NewRow();
            row["Region"] = GetFieldValue(data.Region);
            row["Procurement"] = GetFieldValue(data.Procurement);
            row["Contract"] = GetFieldValue(data.Contract);
            row["Contractor"] = GetFieldValue(data.Contractor);
            row["ContractorName"] = GetFieldValue(data.ContractorName);
            row["RegionRegionId"] = GetFieldValue(data.RegionRegionId);
            row["ProcurementProcid"] = GetFieldValue(data.ProcurementProcid);
            return row;
        }
    }
}
