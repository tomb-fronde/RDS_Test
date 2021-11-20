using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.Report
{
    // TJB  RPCR_056  June-2013: New
    // Dataset definition for REDwInvoiceDetailAllowanceBreakdown.rpt 
    // subreport added into InvoiceHeaderv5 report.
    // Derived from REDwInvoiceDetailPaymentDetailkmDataset.cs

    public class RInvoiceDetailAllowanceBreakdown
    {
        public int ContractNo
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
        public int AltKey
        {
            get
            {
                return 0;
            }
        }
        public string AltDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal AltValue
        {
            get
            {
                return 0;
            }
        }
    }

    public class InvoiceDetailAllowanceBreakdownDataSet : ReportDataSet<InvoiceDetailAllowanceBreakdown>
    {
        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn InvoiceId = new DataColumn("InvoiceId", typeof(int));

        public DataColumn AltKey = new DataColumn("AltKey", typeof(int));

        public DataColumn AltDescription = new DataColumn("AltDescription", typeof(string));

        public DataColumn AltValue = new DataColumn("AltValue", typeof(decimal));

        public InvoiceDetailAllowanceBreakdownDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,InvoiceId,AltKey,AltDescription,AltValue
				});
        }
        
        public InvoiceDetailAllowanceBreakdownDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<InvoiceDetailAllowanceBreakdown> datas = dataSource as Metex.Core.EntityBindingList<InvoiceDetailAllowanceBreakdown>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(InvoiceDetailAllowanceBreakdown data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["InvoiceId"] = GetFieldValue(data.InvoiceId);
            row["AltKey"] = GetFieldValue(data.AltKey);
            row["AltDescription"] = GetFieldValue(data.AltDescription);
            row["AltValue"] = GetFieldValue(data.AltValue);
            return row;
        }
    }
}
