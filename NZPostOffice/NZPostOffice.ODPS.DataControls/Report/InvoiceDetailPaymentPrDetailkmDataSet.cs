using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.Report
{
    public class RInvoiceDetailPaymentPrDetailkm
    {
        // TJB RPCR_012 2-July-2010
        // Added 'Atype' (piece rate supplier name) to values returned
        // Used in Invoice section headers

        public int InvoiceId
        {
            get
            {
                return 0;
            }
        }
        public DateTime PrdDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string PrtCode
        {
            get
            {
                return string.Empty;
            }
        }
        public int PrdQuantity
        {
            get
            {
                return 0;
            }
        }
        public decimal Rate
        {
            get
            {
                return 0;
            }
        }
        public decimal Cost
        {
            get
            {
                return 0;
            }
        }
        public string Atype
        {
            get
            {
                return string.Empty;
            }
        }
        public int ContractNo
        {
            get { return 0; }
        }
        public int ContractorNo
        {
            get { return 0; }
        }
    }
    public class InvoiceDetailPaymentPrDetailkmDataSet : ReportDataSet<InvoiceDetailPaymentPrDetailkm>
    {
        public DataColumn InvoiceId = new DataColumn("InvoiceId", typeof(int));

        public DataColumn PrdDate = new DataColumn("PrdDate", typeof(DateTime));

        public DataColumn PrtCode = new DataColumn("PrtCode", typeof(string));

        public DataColumn PrdQuantity = new DataColumn("PrdQuantity", typeof(int));

        public DataColumn Rate = new DataColumn("Rate", typeof(decimal));

        public DataColumn Cost = new DataColumn("Cost", typeof(decimal));

        public DataColumn Atype = new DataColumn("Atype", typeof(string));

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));
        public DataColumn ContractorNo = new DataColumn("ContractorNo", typeof(int));

        public InvoiceDetailPaymentPrDetailkmDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				InvoiceId,PrdDate,PrtCode,PrdQuantity,Rate,Cost,Atype,ContractNo,ContractorNo
				});
        }

        public InvoiceDetailPaymentPrDetailkmDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<InvoiceDetailPaymentPrDetailkm> datas = dataSource as Metex.Core.EntityBindingList<InvoiceDetailPaymentPrDetailkm>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(InvoiceDetailPaymentPrDetailkm data)
        {
            DataRow row = this.NewRow();
            row["InvoiceId"] = GetFieldValue(data.InvoiceId);
            row["PrdDate"] = GetFieldValue(data.PrdDate);
            row["PrtCode"] = GetFieldValue(data.PrtCode);
            row["PrdQuantity"] = GetFieldValue(data.PrdQuantity);
            row["Rate"] = GetFieldValue(data.Rate);
            row["Cost"] = GetFieldValue(data.Cost);
            row["Atype"] = GetFieldValue(data.Atype);
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["ContractorNo"] = GetFieldValue(data.ContractorNo);
            return row;
        }
    }
}
