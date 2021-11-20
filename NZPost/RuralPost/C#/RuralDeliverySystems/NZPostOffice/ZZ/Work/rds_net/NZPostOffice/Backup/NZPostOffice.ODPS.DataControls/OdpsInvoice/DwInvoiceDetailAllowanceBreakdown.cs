using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    // TJB  RPCR_056  June-2013: New
    // DW for allowance breakdown section of invoice report
    // (REDwInvoiceDetailAllowanceBreakdown.rpt)

    public partial class DwInvoiceDetailAllowanceBreakdown : Metex.Windows.DataUserControl
    {
        private decimal? sum;
        public decimal? Compute1
        {
            get
            {
                return sum;
            }
        }

        private int row;
        public int Row
        {
            get
            {
                return row;
            }
        }
        public DwInvoiceDetailAllowanceBreakdown()
        {
            InitializeComponent();
        }

        private void DwInvoiceDetailAllowanceBreakdown_RetrieveEnd(object sender, System.EventArgs e)
        {
            decimal? _sum = 0;
            int rowCount = 0;
            for (int i = 0; i < this.grid.RowCount; i++)
            {
                if (this.GetItem<InvoiceDetailAllowanceBreakdown>(i).AltValue == null)
                {
                    this.GetItem<InvoiceDetailAllowanceBreakdown>(i).AltValue = 0;
                }
                _sum += this.GetItem<InvoiceDetailAllowanceBreakdown>(i).AltValue;
            }
            sum = _sum;
            if (this.grid.Rows.Count > 0)
            {
                if (this.grid.Rows[this.grid.RowCount - 1].Cells[1].Value == null)
                {
                    this.grid.Rows[this.grid.RowCount - 1].Cells[1].Value = "Total£º";
                    this.grid.Rows[this.grid.RowCount - 1].Cells[2].Value = sum;
                }
                rowCount = this.grid.RowCount - 1;
                row = rowCount;
            }
            this.rowcount.Text = rowCount.ToString();
        }

        public int Retrieve(int? invoiceid)
        {
            return RetrieveCore<InvoiceDetailAllowanceBreakdown>(new List<InvoiceDetailAllowanceBreakdown>
                (InvoiceDetailAllowanceBreakdown.GetAllInvoiceDetailAllowanceBreakdown(invoiceid)));
        }
    }
}
