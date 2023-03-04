using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsPayrun;

namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    public partial class DwAcceptRejectMainrunGrid : Metex.Windows.DataUserControl
    {
        private AcceptRejectMainrunGrid[] list;
        private decimal? compute_0002total;
        private decimal? compute_0003total;
        private decimal? compute_0004total;
        private decimal? compute_0005total;

        public DwAcceptRejectMainrunGrid()
        {
            InitializeComponent();
        }

        public override int Retrieve()
        {
            return RetrieveCore<AcceptRejectMainrunGrid>(new List<AcceptRejectMainrunGrid>
                (AcceptRejectMainrunGrid.GetAllAcceptRejectMainrunGrid()));
        }

        void DwAcceptRejectMainrunGrid_RetrieveEnd(object sender, System.EventArgs e)
        {
            //throw new System.Exception("The method or operation is not implemented.");
            compute_0002total = 0;
            compute_0003total = 0;
            compute_0004total = 0;
            compute_0005total = 0;
            list = AcceptRejectMainrunGrid.GetAllAcceptRejectMainrunGrid();
            if (list != null)
            {
                for (int i = 0; i < list.Length - 1; i++)
                {
                    compute_0002total += list[i].Compute0002 == null ? 0 : list[i].Compute0002;
                    compute_0003total += list[i].Compute0003 == null ? 0 : list[i].Compute0003;
                    compute_0004total += list[i].Compute0004 == null ? 0 : list[i].Compute0004;
                    compute_0005total += list[i].Compute0005 == null ? 0 : list[i].Compute0005;

                }
            }

  
        }
        private void Grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        { 
            /*
            compute_0002total = 0;
            compute_0003total = 0;
            compute_0004total = 0;
            compute_0005total = 0;
            list = AcceptRejectMainrunGrid.GetAllAcceptRejectMainrunGrid();
            if (list != null)
            {
                for (int i = 0; i < list.Length - 1; i++)
                {
                    compute_0002total += list[i].Compute0002 == null ? 0 : list[i].Compute0002;
                    compute_0003total += list[i].Compute0003 == null ? 0 : list[i].Compute0003;
                    compute_0004total += list[i].Compute0004 == null ? 0 : list[i].Compute0004;
                    compute_0005total += list[i].Compute0005 == null ? 0 : list[i].Compute0005;

                }
            }
            */          

            #region
            if (e.RowIndex > 0 && this.grid.Columns[0].Index == e.ColumnIndex && e.RowIndex == this.grid.Rows.Count - 1)
            {
                Rectangle newRect = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                using (Brush gridBrush = new SolidBrush(this.grid.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor), fontColorBrush = new SolidBrush(this.grid.ForeColor))
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
                        e.Graphics.DrawString("", e.CellStyle.Font,
                                fontColorBrush, e.CellBounds.X + 2,
                                e.CellBounds.Y + 2, StringFormat.GenericDefault);
                        e.Handled = true;
                    }
                }

            }

            if (e.RowIndex > 0 && this.grid.Columns[1].Index == e.ColumnIndex && e.RowIndex == this.grid.Rows.Count - 1)
            {
                Rectangle newRect = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                using (Brush gridBrush = new SolidBrush(this.grid.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor), fontColorBrush = new SolidBrush(this.grid.ForeColor))
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
                        Font newFont = new Font(e.CellStyle.Font, FontStyle.Bold);
                        e.Graphics.DrawString("Total", newFont,
                                fontColorBrush, e.CellBounds.X + 2,
                                e.CellBounds.Y + 2, StringFormat.GenericDefault);
                        e.Handled = true;
                    }
                }
            }
            if (e.RowIndex > 0 && this.grid.Columns[2].Index == e.ColumnIndex && e.RowIndex == this.grid.Rows.Count - 1)
            {
                Rectangle newRect = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                using (Brush gridBrush = new SolidBrush(this.grid.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor) 
                    //!, fontColorBrush = new SolidBrush(this.grid.ForeColor)
                    )
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        SolidBrush fontColorBrush = new SolidBrush(this.grid.ForeColor);

                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                            e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                            e.CellBounds.Top, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom);
                        //e.Graphics.DrawRectangle(Pens.Blue, newRect);

                        string total = Convert.ToDouble(compute_0002total).ToString("###,###,###.##;(###,###,###.##)");
                        if (compute_0002total < 0)
                        {
                            fontColorBrush = new SolidBrush(Color.Red);
                        }

                        if (total == "")
                            total = "0.00";
                        float width = (e.CellBounds.Width - e.Graphics.MeasureString(total, e.CellStyle.Font).Width);                                                

                        //e.Graphics.DrawString(Convert.ToDouble(compute_0002total).ToString("###,###,###.##"), e.CellStyle.Font,
                        //        fontColorBrush, e.CellBounds.X + 2,
                        //        e.CellBounds.Y + 2,StringFormat.GenericDefault);
                        Font newFont = new Font(e.CellStyle.Font, FontStyle.Bold);
                        e.Graphics.DrawString(total, newFont,
                                fontColorBrush, e.CellBounds.X + width - 2,
                                e.CellBounds.Y + 2, StringFormat.GenericDefault);

                        e.Handled = true;
                    }
                }
            }
            if (e.RowIndex > 0 && this.grid.Columns[3].Index == e.ColumnIndex && e.RowIndex == this.grid.Rows.Count - 1)
            {
                Rectangle newRect = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                using (Brush gridBrush = new SolidBrush(this.grid.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor)
                    //!, fontColorBrush = new SolidBrush(this.grid.ForeColor)
                    )
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        SolidBrush fontColorBrush = new SolidBrush(this.grid.ForeColor);

                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                            e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                            e.CellBounds.Top, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom);
                        //e.Graphics.DrawRectangle(Pens.Blue, newRect);

                        string total = Convert.ToDouble(compute_0003total).ToString("###,###,###.##;(###,###,###.##)");
                        if (compute_0003total < 0)
                        {
                            fontColorBrush = new SolidBrush(Color.Red);
                        }

                        if (total == "")
                            total = "0.00";
                        float width = (e.CellBounds.Width - e.Graphics.MeasureString(total, e.CellStyle.Font).Width);


                        Font newFont = new Font(e.CellStyle.Font, FontStyle.Bold);
                        e.Graphics.DrawString(total, newFont,
                                fontColorBrush, e.CellBounds.X + width - 2,
                                e.CellBounds.Y + 2, StringFormat.GenericDefault);
                        e.Handled = true;
                    }
                }
            }
            if (e.RowIndex > 0 && this.grid.Columns[4].Index == e.ColumnIndex && e.RowIndex == this.grid.Rows.Count - 1)
            {
                Rectangle newRect = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                using (Brush gridBrush = new SolidBrush(this.grid.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor)
                    //!, fontColorBrush = new SolidBrush(this.grid.ForeColor)
                    )
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        SolidBrush fontColorBrush = new SolidBrush(this.grid.ForeColor);

                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                            e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                            e.CellBounds.Top, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom);
                        //e.Graphics.DrawRectangle(Pens.Blue, newRect);
                        //e.Graphics.DrawString(compute_0004total.ToString(), e.CellStyle.Font,
                        //        fontColorBrush, e.CellBounds.X + 2,
                        //        e.CellBounds.Y + 2, StringFormat.GenericDefault);
                        string total = Convert.ToDouble(compute_0004total).ToString("###,###,###.00;(###,###,###.00)");
                        if (compute_0004total < 0)
                        {
                            fontColorBrush = new SolidBrush(Color.Red);
                        }                        

                        if (total == "")
                            total = "0.00";
                        float width = (e.CellBounds.Width - e.Graphics.MeasureString(total, e.CellStyle.Font).Width);


                        Font newFont = new Font(e.CellStyle.Font, FontStyle.Bold);
                        e.Graphics.DrawString(total, newFont,
                                fontColorBrush, e.CellBounds.X + width - 2,
                                e.CellBounds.Y + 2, StringFormat.GenericDefault);

                        e.Handled = true;
                    }
                }
            }
            if (e.RowIndex > 0 && this.grid.Columns[5].Index == e.ColumnIndex && e.RowIndex == this.grid.Rows.Count - 1)
            {
                Rectangle newRect = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                using (Brush gridBrush = new SolidBrush(this.grid.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                    //!, fontColorBrush = new SolidBrush(this.grid.ForeColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        SolidBrush fontColorBrush = new SolidBrush(this.grid.ForeColor);

                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                            e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                            e.CellBounds.Top, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom);
                        //e.Graphics.DrawRectangle(Pens.Blue, newRect);
                        //e.Graphics.DrawString(compute_0005total.ToString(), e.CellStyle.Font,
                        //        fontColorBrush, e.CellBounds.X + 2,
                        //        e.CellBounds.Y + 2, StringFormat.GenericDefault);
                        string total = Convert.ToDouble(compute_0005total).ToString("###,###,###.00;(###,###,###.00)");
                        if (compute_0005total < 0)
                        {
                            fontColorBrush = new SolidBrush(Color.Red);
                        }                       

                        if (total == "")
                            total = "0.00";
                        float width = (e.CellBounds.Width - e.Graphics.MeasureString(total, e.CellStyle.Font).Width);


                        Font newFont = new Font(e.CellStyle.Font, FontStyle.Bold);
                        e.Graphics.DrawString(total, newFont,
                                fontColorBrush, e.CellBounds.X + width - 2,
                                e.CellBounds.Y + 2, StringFormat.GenericDefault);

                        e.Handled = true;
                    }
                }
            }

            if (e.RowIndex > 0 && (e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5))
            { 
                decimal test = 0;

                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out test) && test < 0)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
            #endregion
        }
    }
}
