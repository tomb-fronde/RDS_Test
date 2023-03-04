using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RInvoiceDetailPaymentPrMessage
    {
        public string OutMessage
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class InvoiceDetailPaymentPrMessageDataSet : ReportDataSet<InvoiceDetailPaymentPrMessage>
    {
        public DataColumn OutMessage = new DataColumn("OutMessage", typeof(string));

        public InvoiceDetailPaymentPrMessageDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				OutMessage
				});
        }

        public InvoiceDetailPaymentPrMessageDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<InvoiceDetailPaymentPrMessage> datas = dataSource as Metex.Core.EntityBindingList<InvoiceDetailPaymentPrMessage>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(InvoiceDetailPaymentPrMessage data)
        {
            DataRow row = this.NewRow();
            row["OutMessage"] = GetFieldValue(data.OutMessage);
            return row;
        }
    }
}
