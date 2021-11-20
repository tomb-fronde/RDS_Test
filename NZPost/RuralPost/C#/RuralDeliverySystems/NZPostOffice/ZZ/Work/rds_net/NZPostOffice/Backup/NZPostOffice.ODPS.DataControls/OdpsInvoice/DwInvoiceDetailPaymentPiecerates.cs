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
    // TJB  RPCR_054 June-2013: NEW
    // DW for selected piecerates for export
    // Adapted from DwInvoiceDetailPaymentPrKm

    public partial class DwInvoiceDetailPaymentPiecerates : Metex.Windows.DataUserControl
    {
        private decimal? sum;
        public decimal? Sum
        {
            get
            {
                return sum;
            }
        }

        public DwInvoiceDetailPaymentPiecerates()
        {
            InitializeComponent();
        }

        private void DwInvoiceDetailPaymentPiecerates_RetrieveEnd(object sender, System.EventArgs e)
        {
            this.grid.Height = this.grid.Rows.Count * this.grid.RowTemplate.Height;
            this.compute.Top = this.grid.Top + this.grid.Height;
            this.total.Top = this.grid.Top + this.grid.Height;

            this.compute.Visible = true;
            this.total.Visible = true;

            if (this.grid.RowCount > 0)
            {
                decimal? _sum = 0;
                int rowCount = 0;
                for (int i = 0; i < this.grid.RowCount; i++)
                {
                    if (this.GetItem<InvoiceDetailPaymentPiecerates>(i).Cost == null)
                    {
                        this.GetItem<InvoiceDetailPaymentPiecerates>(i).Cost = 0;
                    }
                    _sum += this.GetItem<InvoiceDetailPaymentPiecerates>(i).Cost;
                }
                sum = _sum;
                this.compute.Text = String.Format("{0:#,###.00}", sum);
            }
        }

        public int Retrieve(int? invoiceid)
        {
            return RetrieveCore<InvoiceDetailPaymentPiecerates>(new List<InvoiceDetailPaymentPiecerates>
                (InvoiceDetailPaymentPiecerates.GetAllInvoiceDetailPaymentPiecerates(invoiceid)));
        }
    }
}
