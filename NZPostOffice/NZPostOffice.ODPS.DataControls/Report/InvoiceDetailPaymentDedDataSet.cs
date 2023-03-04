using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RInvoiceDetailPaymentDed
    {
        public DateTime PcdDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime REPcdDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string DedDescription
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
        public int InvoiceId
        {
            get { return 0; }
        }
    }
    public class InvoiceDetailPaymentDedDataSet : ReportDataSet<InvoiceDetailPaymentDed>
    {
        public DataColumn PcdDate = new DataColumn("PcdDate", typeof(DateTime));

        public DataColumn REPcdDate = new DataColumn("REPcdDate", typeof(DateTime));

        public DataColumn DedDescription = new DataColumn("DedDescription", typeof(string));

        public DataColumn PcdAmount = new DataColumn("PcdAmount", typeof(decimal));

        public DataColumn REPcdAmount = new DataColumn("REPcdAmount", typeof(decimal));

        public DataColumn InvoiceId = new DataColumn("InvoiceId", typeof(int));

        public InvoiceDetailPaymentDedDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				PcdDate,REPcdDate,DedDescription,PcdAmount,REPcdAmount,InvoiceId
				});
        }

        public InvoiceDetailPaymentDedDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<InvoiceDetailPaymentDed> datas = dataSource as Metex.Core.EntityBindingList<InvoiceDetailPaymentDed>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(InvoiceDetailPaymentDed data)
        {
            DataRow row = this.NewRow();
            row["PcdDate"] = GetFieldValue(data.PcdDate);
            row["REPcdDate"] = GetFieldValue(data.REPcdDate);
            row["DedDescription"] = GetFieldValue(data.DedDescription);
            row["PcdAmount"] = GetFieldValue(data.PcdAmount);
            row["REPcdAmount"] = GetFieldValue(data.REPcdAmount);
            row["InvoiceId"] = GetFieldValue(data.InvoiceId);
            return row;
        }
    }
}
