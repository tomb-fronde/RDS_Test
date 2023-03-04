using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RInvoiceDetailPaymentPr
    {
        public DateTime InDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime REInDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string PrsDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public int Pvolume
        {
            get
            {
                return 0;
            }
        }
        public int REPvolume
        {
            get
            {
                return 0;
            }
        }
        public decimal Pvalue
        {
            get
            {
                return 0;
            }
        }
        public decimal REPvalue
        {
            get
            {
                return 0;
            }
        }
        public int InvoiceId
        {
            get
            {
                return 0;
            }
        }
    }
    public class InvoiceDetailPaymentPrDataSet : ReportDataSet<InvoiceDetailPaymentPr>
    {
        public DataColumn InDate = new DataColumn("InDate", typeof(DateTime));

        public DataColumn REInDate = new DataColumn("REInDate", typeof(DateTime));

        public DataColumn PrsDescription = new DataColumn("PrsDescription", typeof(string));

        public DataColumn Pvolume = new DataColumn("Pvolume", typeof(int));

        public DataColumn REPvolume = new DataColumn("REPvolume", typeof(int));

        public DataColumn Pvalue = new DataColumn("Pvalue", typeof(decimal));

        public DataColumn REPvalue = new DataColumn("REPvalue", typeof(decimal));

        public DataColumn InvoiceId = new DataColumn("InvoiceId", typeof(int));

        public InvoiceDetailPaymentPrDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				InDate,REInDate,PrsDescription,Pvolume,REPvolume,Pvalue,REPvalue,InvoiceId
				});
        }

        public InvoiceDetailPaymentPrDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<InvoiceDetailPaymentPr> datas = dataSource as Metex.Core.EntityBindingList<InvoiceDetailPaymentPr>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(InvoiceDetailPaymentPr data)
        {
            DataRow row = this.NewRow();
            row["InDate"] = GetFieldValue(data.InDate);
            row["REInDate"] = GetFieldValue(data.REInDate);
            row["PrsDescription"] = GetFieldValue(data.PrsDescription);
            row["Pvolume"] = GetFieldValue(data.Pvolume);
            row["REPvolume"] = GetFieldValue(data.REPvolume);
            row["Pvalue"] = GetFieldValue(data.Pvalue);
            row["REPvalue"] = GetFieldValue(data.REPvalue);

            row["InvoiceId"] = GetFieldValue(data.InvoiceId);
            return row;
        }
    }
}
