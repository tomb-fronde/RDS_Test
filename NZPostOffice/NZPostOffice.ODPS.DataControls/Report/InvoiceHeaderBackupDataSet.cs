using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RInvoiceHeaderBackup
    {
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
        public string DsNo
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
        public string Compute0011
        {
            get
            {
                return string.Empty;
            }
        }
        public int PieceRateCount
        {
            get
            {
                return 0;
            }
        }
        public int REPieceRateCount
        {
            get
            {
                return 0;
            }
        }
    }
    public class InvoiceHeaderBackupDataSet : ReportDataSet<InvoiceHeaderBackup>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn REContractNo = new DataColumn("REContractNo", typeof(int));

        public DataColumn CGstNumber = new DataColumn("CGstNumber", typeof(string));

        public DataColumn ConTitle = new DataColumn("ConTitle", typeof(string));

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CFirstNames = new DataColumn("CFirstNames", typeof(string));

        public DataColumn CAddress = new DataColumn("CAddress", typeof(string));

        public DataColumn CinvoiceNo = new DataColumn("CinvoiceNo", typeof(string));

        public DataColumn DsNo = new DataColumn("DsNo", typeof(string));

        public DataColumn PaymentInvoiceId = new DataColumn("PaymentInvoiceId", typeof(int));

        public DataColumn REPaymentInvoiceId = new DataColumn("REPaymentInvoiceId", typeof(int));

        public DataColumn ContractorContractorSupplierNo = new DataColumn("ContractorContractorSupplierNo", typeof(int));

        public DataColumn REContractorContractorSupplierNo = new DataColumn("REContractorContractorSupplierNo", typeof(int));

        public DataColumn Compute0011 = new DataColumn("Compute0011", typeof(string));

        public DataColumn PieceRateCount = new DataColumn("PieceRateCount", typeof(int));

        public DataColumn REPieceRateCount = new DataColumn("REPieceRateCount", typeof(int));


        public InvoiceHeaderBackupDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,REContractNo,CGstNumber,ConTitle,CSurnameCompany,CFirstNames,CAddress,CinvoiceNo,DsNo,PaymentInvoiceId,REPaymentInvoiceId,ContractorContractorSupplierNo,REContractorContractorSupplierNo,Compute0011,PieceRateCount,REPieceRateCount
				});
            ContractNo.AllowDBNull = true;
            PaymentInvoiceId.AllowDBNull = true;
            ContractorContractorSupplierNo.AllowDBNull = true;
            PieceRateCount.AllowDBNull = true;

        }

        public InvoiceHeaderBackupDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<InvoiceHeaderBackup> datas = dataSource as Metex.Core.EntityBindingList<InvoiceHeaderBackup>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(InvoiceHeaderBackup data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["REContractNo"] = GetFieldValue(data.REContractNo);
            row["CGstNumber"] = GetFieldValue(data.CGstNumber);
            row["ConTitle"] = GetFieldValue(data.ConTitle);
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CFirstNames"] = GetFieldValue(data.CFirstNames);
            row["CAddress"] = GetFieldValue(data.CAddress);
            row["CinvoiceNo"] = GetFieldValue(data.CinvoiceNo);
            row["DsNo"] = GetFieldValue(data.DsNo);
            row["PaymentInvoiceId"] = GetFieldValue(data.PaymentInvoiceId);
            row["REPaymentInvoiceId"] = GetFieldValue(data.REPaymentInvoiceId);
            row["ContractorContractorSupplierNo"] = GetFieldValue(data.ContractorContractorSupplierNo);
            row["REContractorContractorSupplierNo"] = GetFieldValue(data.REContractorContractorSupplierNo);
            row["Compute0011"] = GetFieldValue(data.Compute0011);
            row["PieceRateCount"] = GetFieldValue(data.PieceRateCount);
            row["REPieceRateCount"] = GetFieldValue(data.REPieceRateCount);
            return row;
        }
    }
}
