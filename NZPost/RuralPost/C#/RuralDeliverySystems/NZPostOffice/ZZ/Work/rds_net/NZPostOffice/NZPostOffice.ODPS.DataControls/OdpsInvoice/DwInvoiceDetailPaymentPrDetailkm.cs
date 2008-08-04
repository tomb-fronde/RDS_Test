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
    public partial class DwInvoiceDetailPaymentPrDetailkm : Metex.Windows.DataUserControl
    {
        private decimal? sum;
        public decimal? Sum
        {
            get
            {
                return sum;
            }
        }

        //private int row;
        //public int Row
        //{
        //    get
        //    {
        //        return row;
        //    }
        //}
        
        public DwInvoiceDetailPaymentPrDetailkm()
        {
            InitializeComponent();
        }

        private void DwInvoiceDetailPaymentPrDetailkm_RetrieveEnd(object sender, System.EventArgs e)
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
                    if (this.GetItem<InvoiceDetailPaymentPrDetailkm>(i).Cost == null)
                    {
                        this.GetItem<InvoiceDetailPaymentPrDetailkm>(i).Cost = 0;
                    }
                    _sum += this.GetItem<InvoiceDetailPaymentPrDetailkm>(i).Cost;
                }
                sum = _sum;
                this.compute.Text = String.Format("{0:#,###.00}", sum);
            }
        }

        public int Retrieve(int? invoiceid, int? contractno, int? contractorno, DateTime? payperiod_start, DateTime? payperiod_end)
        {
            return RetrieveCore<InvoiceDetailPaymentPrDetailkm>(new List<InvoiceDetailPaymentPrDetailkm>
                (InvoiceDetailPaymentPrDetailkm.GetAllInvoiceDetailPaymentPrDetailkm(invoiceid, contractno, contractorno, payperiod_start, payperiod_end)));
        }
    }
}
