using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RPostTaxAdjustmentsRegion
    {
        public string CSurnameCompany
        {
            get
            {
                return string.Empty;
            }
        }
        public string CFirstNames
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal PcdAmount
        {
            get
            {
                return 0;
            }
        }
        public decimal REPcdAmount
        {
            get
            {
                return 0;
            }
        }
        public string DedDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public int REContractNo
        {
            get
            {
                return 0;
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
    public class PostTaxAdjustmentsRegionDataSet : ReportDataSet<PostTaxAdjustmentsRegion>
    {

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CFirstNames = new DataColumn("CFirstNames", typeof(string));

        public DataColumn PcdAmount = new DataColumn("PcdAmount", typeof(decimal));

        public DataColumn REPcdAmount = new DataColumn("REPcdAmount", typeof(decimal));

        public DataColumn DedDescription = new DataColumn("DedDescription", typeof(string));

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn REContractNo = new DataColumn("REContractNo", typeof(int));

        public DataColumn Region = new DataColumn("Region", typeof(string));


        public PostTaxAdjustmentsRegionDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				CSurnameCompany,CFirstNames,PcdAmount,REPcdAmount,DedDescription,ContractNo,REContractNo,Region
				});
            PcdAmount.AllowDBNull = true;
            ContractNo.AllowDBNull = true;

        }

        public PostTaxAdjustmentsRegionDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<PostTaxAdjustmentsRegion> datas = dataSource as Metex.Core.EntityBindingList<PostTaxAdjustmentsRegion>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(PostTaxAdjustmentsRegion data)
        {
            DataRow row = this.NewRow();
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CFirstNames"] = GetFieldValue(data.CFirstNames);
            row["PcdAmount"] = GetFieldValue(data.PcdAmount);
            row["REPcdAmount"] = GetFieldValue(data.REPcdAmount);
            row["DedDescription"] = GetFieldValue(data.DedDescription);
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["REContractNo"] = GetFieldValue(data.REContractNo);
            row["Region"] = GetFieldValue(data.Region);
            return row;
        }
    }
}
