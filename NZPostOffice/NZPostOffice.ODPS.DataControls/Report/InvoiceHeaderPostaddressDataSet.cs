using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RInvoiceHeaderPostaddress
    {
        public string NatRuralPostAddress
        {
            get
            {
                return string.Empty;
            }
        }
        public string NatRuralPostGstNo
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class InvoiceHeaderPostaddressDataSet : ReportDataSet<InvoiceHeaderPostaddress>
    {
        public DataColumn NatRuralPostAddress = new DataColumn("NatRuralPostAddress", typeof(string));

        public DataColumn NatRuralPostGstNo = new DataColumn("NatRuralPostGstNo", typeof(string));

        public InvoiceHeaderPostaddressDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				NatRuralPostAddress,NatRuralPostGstNo
				});
        }

        public InvoiceHeaderPostaddressDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<InvoiceHeaderPostaddress> datas = dataSource as Metex.Core.EntityBindingList<InvoiceHeaderPostaddress>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(InvoiceHeaderPostaddress data)
        {
            DataRow row = this.NewRow();
            row["NatRuralPostAddress"] = GetFieldValue(data.NatRuralPostAddress);
            row["NatRuralPostGstNo"] = GetFieldValue(data.NatRuralPostGstNo);
            return row;
        }
    }
}
