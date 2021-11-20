using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RInvoiceHeaderv5
    {
        public string ContractStartDate
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
        public string CGstNumber
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
        public string CAddress
        {
            get
            {
                return string.Empty;
            }
        }
        public string CinvoiceNo
        {
            get
            {
                return string.Empty;
            }
        }
        public int PaymentInvoiceId
        {
            get
            {
                return 0;
            }
        }
        public int REPaymentInvoiceId
        {
            get
            {
                return 0;
            }
        }
        public int ContractorContractorSupplierNo
        {
            get
            {
                return 0;
            }
        }
        public int REContractorContractorSupplierNo
        {
            get
            {
                return 0;
            }
        }
        public string Prc
        {
            get
            {
                return string.Empty;
            }
        }
        public int Compute0012
        {
            get
            {
                return 0;
            }
        }
        public int RECompute0012
        {
            get
            {
                return 0;
            }
        }
        public string DsNo
        {
            get
            {
                return string.Empty;
            }
        }
        public string Cinvmessage
        {
            get
            {
                return string.Empty;
            }
        }
        public int Cxpc
        {
            get
            {
                return 0;
            }
        }
        public int RECxpc
        {
            get
            {
                return 0;
            }
        }
        public string Compute4
        {
            get
            {
                return string.Empty;
            }
        }
        public int Compute1
        {
            get
            {
                return 0;
            }
        }
        public int RECompute1
        {
            get
            {
                return 0;
            }
        }
    }
    public class InvoiceHeaderv5DataSet : ReportDataSet<InvoiceHeaderv5>
    {

        public DataColumn ContractStartDate = new DataColumn("ContractStartDate", typeof(string));

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn REContractNo = new DataColumn("REContractNo", typeof(int));

        public DataColumn CGstNumber = new DataColumn("CGstNumber", typeof(string));

        public DataColumn ConTitle = new DataColumn("ConTitle", typeof(string));

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CFirstNames = new DataColumn("CFirstNames", typeof(string));

        public DataColumn CAddress = new DataColumn("CAddress", typeof(string));

        public DataColumn CinvoiceNo = new DataColumn("CinvoiceNo", typeof(string));

        public DataColumn PaymentInvoiceId = new DataColumn("PaymentInvoiceId", typeof(int));

        public DataColumn REPaymentInvoiceId = new DataColumn("REPaymentInvoiceId", typeof(int));

        public DataColumn ContractorContractorSupplierNo = new DataColumn("ContractorContractorSupplierNo", typeof(int));

        public DataColumn REContractorContractorSupplierNo = new DataColumn("REContractorContractorSupplierNo", typeof(int));

        public DataColumn Prc = new DataColumn("Prc", typeof(string));

        public DataColumn Compute0012 = new DataColumn("Compute0012", typeof(int));

        public DataColumn RECompute0012 = new DataColumn("RECompute0012", typeof(int));

        public DataColumn DsNo = new DataColumn("DsNo", typeof(string));

        public DataColumn Cinvmessage = new DataColumn("Cinvmessage", typeof(string));

        public DataColumn Cxpc = new DataColumn("Cxpc", typeof(int));

        public DataColumn RECxpc = new DataColumn("RECxpc", typeof(int));

        public DataColumn Compute4 = new DataColumn("Compute4", typeof(string));

        public DataColumn Compute1 = new DataColumn("Compute1", typeof(int));

        public DataColumn RECompute1 = new DataColumn("RECompute1", typeof(int));


        public InvoiceHeaderv5DataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractStartDate,ContractNo,REContractNo,CGstNumber,ConTitle,CSurnameCompany,CFirstNames,CAddress,CinvoiceNo,PaymentInvoiceId,REPaymentInvoiceId,ContractorContractorSupplierNo,REContractorContractorSupplierNo,Prc,Compute0012,RECompute0012,DsNo,Cinvmessage,Cxpc,RECxpc,Compute4,Compute1,RECompute1
				});
            ContractNo.AllowDBNull = true;
            PaymentInvoiceId.AllowDBNull = true;
            ContractorContractorSupplierNo.AllowDBNull = true;
            Compute0012.AllowDBNull = true;
            Cxpc.AllowDBNull = true;
            Compute1.AllowDBNull = true;

        }

        public InvoiceHeaderv5DataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<InvoiceHeaderv5> datas = dataSource as Metex.Core.EntityBindingList<InvoiceHeaderv5>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(InvoiceHeaderv5 data)
        {
            DataRow row = this.NewRow();
            row["ContractStartDate"] = GetFieldValue(data.ContractStartDate);
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["REContractNo"] = GetFieldValue(data.REContractNo);
            row["CGstNumber"] = GetFieldValue(data.CGstNumber);
            row["ConTitle"] = GetFieldValue(data.ConTitle);
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CFirstNames"] = GetFieldValue(data.CFirstNames);
            row["CAddress"] = GetFieldValue(data.CAddress);
            row["CinvoiceNo"] = GetFieldValue(data.CinvoiceNo);
            row["PaymentInvoiceId"] = GetFieldValue(data.PaymentInvoiceId);
            row["REPaymentInvoiceId"] = GetFieldValue(data.REPaymentInvoiceId);
            row["ContractorContractorSupplierNo"] = GetFieldValue(data.ContractorContractorSupplierNo);
            row["REContractorContractorSupplierNo"] = GetFieldValue(data.REContractorContractorSupplierNo);
            row["Prc"] = GetFieldValue(data.Prc);
            row["Compute0012"] = GetFieldValue(data.Compute0012);
            row["RECompute0012"] = GetFieldValue(data.RECompute0012);
            row["DsNo"] = GetFieldValue(data.DsNo);
            row["Cinvmessage"] = GetFieldValue(data.Cinvmessage);
            row["Cxpc"] = GetFieldValue(data.Cxpc);
            row["RECxpc"] = GetFieldValue(data.RECxpc);
            row["Compute4"] = GetFieldValue(data.Compute4);
            row["Compute1"] = GetFieldValue(data.Compute1);
            row["RECompute1"] = GetFieldValue(data.RECompute1);
            return row;
        }
    }
}
