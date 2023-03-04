using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RInvoiceDetailPaymentPrTitle
    {
        public string OutMessage
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class InvoiceDetailPaymentPrTitleDataSet : ReportDataSet<InvoiceDetailPaymentPrTitle>
    {
        public DataColumn OutMessage = new DataColumn("OutMessage", typeof(string));

        public InvoiceDetailPaymentPrTitleDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				OutMessage
				});
        }

        public InvoiceDetailPaymentPrTitleDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<InvoiceDetailPaymentPrTitle> datas = dataSource as Metex.Core.EntityBindingList<InvoiceDetailPaymentPrTitle>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(InvoiceDetailPaymentPrTitle data)
        {
            DataRow row = this.NewRow();
            row["OutMessage"] = GetFieldValue(data.OutMessage);
            return row;
        }
    }
}
