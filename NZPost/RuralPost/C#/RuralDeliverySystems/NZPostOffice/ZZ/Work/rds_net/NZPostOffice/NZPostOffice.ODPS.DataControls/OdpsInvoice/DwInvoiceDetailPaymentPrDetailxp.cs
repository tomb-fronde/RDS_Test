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
    public partial class DwInvoiceDetailPaymentPrDetailxp : Metex.Windows.DataUserControl
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
        public DwInvoiceDetailPaymentPrDetailxp()
        {
            InitializeComponent();
        }

        private void DwInvoiceDetailPaymentPrDetailxp_RetrieveEnd(object sender, System.EventArgs e)
        {
            if (this.grid.RowCount > 0)
            {
                decimal? _sum = 0;
                int rowCount = 0;
                for (int i = 0; i < this.grid.RowCount; i++)
                {
                    if (this.GetItem<InvoiceDetailPaymentPrDetailxp>(i).Cost == null)
                    {
                        this.GetItem<InvoiceDetailPaymentPrDetailxp>(i).Cost = 0;
                    }
                    _sum += this.GetItem<InvoiceDetailPaymentPrDetailxp>(i).Cost;
                }
                sum = _sum;
                this.grid.Rows[this.grid.RowCount - 1].Cells[4].Value = sum;
                rowCount = this.grid.RowCount - 1;
                row = rowCount;
                this.rowcount.Text = rowCount.ToString();
                this.grid.InvalidateCell(3, this.grid.RowCount - 1);
            }
        }

        private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (this.grid.RowCount > 0)
            {
                if (e.RowIndex > 0 && this.grid.Columns[3].Index == e.ColumnIndex && e.RowIndex == this.grid.Rows.Count - 1)
                {
                    Rectangle newRect = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                    using (Brush gridBrush = new SolidBrush(this.grid.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                    {
                        using (Pen gridLinePen = new Pen(gridBrush))
                        {
                            e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                                e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                                e.CellBounds.Bottom - 1);
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                                e.CellBounds.Top, e.CellBounds.Right - 1,
                                e.CellBounds.Bottom);
                            //e.Graphics.DrawRectangle(Pens.Blue, newRect);
                            e.Graphics.DrawString("Total£º", e.CellStyle.Font,
                                    Brushes.Crimson, e.CellBounds.X + 2,
                                    e.CellBounds.Y + 2, StringFormat.GenericDefault);
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        public int Retrieve(int? invoiceid, int? contractno, int? contractorno, DateTime? payperiod_start, DateTime? payperiod_end)
        {
            return RetrieveCore<InvoiceDetailPaymentPrDetailxp>(new List<InvoiceDetailPaymentPrDetailxp>
                (InvoiceDetailPaymentPrDetailxp.GetAllInvoiceDetailPaymentPrDetailxp(invoiceid, contractno, contractorno, payperiod_start, payperiod_end)));
        }
    }
}
