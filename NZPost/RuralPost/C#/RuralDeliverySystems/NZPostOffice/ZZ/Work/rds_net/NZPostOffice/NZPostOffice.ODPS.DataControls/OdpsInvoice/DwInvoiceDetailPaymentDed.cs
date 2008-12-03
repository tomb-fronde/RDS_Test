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
    public partial class DwInvoiceDetailPaymentDed : Metex.Windows.DataUserControl
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
        public DwInvoiceDetailPaymentDed()
        {
            InitializeComponent();
        }

        private void DwInvoiceDetailPaymentDed_RetrieveEnd(object sender, System.EventArgs e)
        {
            decimal? _sum = 0;
            int rowCount = 0;
            for (int i = 0; i < this.grid.RowCount; i++)
            {
                if (this.GetItem<InvoiceDetailPaymentDed>(i).PcdAmount==null)
                {
                    this.GetItem<InvoiceDetailPaymentDed>(i).PcdAmount = 0;
                }
                _sum += this.GetItem < InvoiceDetailPaymentDed>(i).PcdAmount;
            }
            sum = _sum;
            if (this.grid.RowCount > 0)  //jlwang
            {
                if (this.grid.Rows[this.grid.RowCount - 1].Cells[1].Value == null)
                {
                    this.grid.Rows[this.grid.RowCount - 1].Cells[1].Value = "Total£º";
                }
                // TJB  Dec08  RD7_0017
                //this.grid.Rows[this.grid.RowCount - 1].Cells[1].Value = sum;
                this.grid.Rows[this.grid.RowCount - 1].Cells[1].Value = sum;
                rowCount = this.grid.RowCount - 1;
            }
            this.rowcount.Text = rowCount.ToString();
        }

        public int Retrieve(int? invoiceid)
        {
            return RetrieveCore<InvoiceDetailPaymentDed>(new List<InvoiceDetailPaymentDed>
                (InvoiceDetailPaymentDed.GetAllInvoiceDetailPaymentDed(invoiceid)));
        }
    }
}
