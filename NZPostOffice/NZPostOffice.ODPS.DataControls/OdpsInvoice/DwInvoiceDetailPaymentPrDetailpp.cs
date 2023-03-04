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
    public partial class DwInvoiceDetailPaymentPrDetailpp : Metex.Windows.DataUserControl
    {
        private decimal? sum;
        public decimal? Compute1
        {
            get
            {
                return sum;
            }
        }

        //private decimal? row;
        //public decimal? Row
        //{
        //    get
        //    {
        //        return row;
        //    }
        //}
        public DwInvoiceDetailPaymentPrDetailpp()
        {
            InitializeComponent();
        }

        private void DwInvoiceDetailPaymentPrDetailpp_RetrieveEnd(object sender, System.EventArgs e)
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
                    if (this.GetItem<InvoiceDetailPaymentPrDetailpp>(i).Cost == null)
                    {
                        this.GetItem<InvoiceDetailPaymentPrDetailpp>(i).Cost = 0;
                    }
                    _sum += this.GetItem<InvoiceDetailPaymentPrDetailpp>(i).Cost;
                }
                sum = _sum;
                this.compute.Text = String.Format("{0:#,###.00}", sum);
            }
        }

        public int Retrieve(int? invoiceid, int? contractno, int? contractorno, DateTime? payperiod_start, DateTime? payperiod_end)
        {
            return RetrieveCore<InvoiceDetailPaymentPrDetailpp>(new List<InvoiceDetailPaymentPrDetailpp>
                (InvoiceDetailPaymentPrDetailpp.GetAllInvoiceDetailPaymentPrDetailpp(invoiceid, contractno, contractorno, payperiod_start, payperiod_end)));
        }
    }
}
