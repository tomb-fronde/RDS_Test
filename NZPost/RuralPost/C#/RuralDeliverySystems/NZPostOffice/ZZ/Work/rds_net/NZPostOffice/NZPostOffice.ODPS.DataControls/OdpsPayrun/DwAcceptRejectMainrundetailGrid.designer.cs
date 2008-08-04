using System.Drawing;
using System;
namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    partial class DwAcceptRejectMainrundetailGrid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn contract_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn pc_amount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Metex.Windows.DataEntityGrid grid;

        #region Component Designer generated code
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.contract_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pc_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsPayrun.AcceptRejectMainrundetailGrid);

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 33;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.contract_no,
            this.name,
            this.pc_amount,
            this.comments});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(grid_CellPainting);
            this.grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;

            // 
            // contract_no
            // 
            this.contract_no.DataPropertyName = "ContractNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.contract_no.DefaultCellStyle = dataGridViewCellStyle2;
            this.contract_no.HeaderText = "Contract No";
            this.contract_no.Name = "contract_no";
            this.contract_no.ReadOnly = true;
            this.contract_no.Width = 72;

            // 
            // name
            // 
            this.name.DataPropertyName = "Name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.name.DefaultCellStyle = dataGridViewCellStyle3;
            this.name.HeaderText = "Owner-Driver";
            this.name.Name = "name";
            this.name.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.name.ReadOnly = true;
            this.name.Width = 156;

            // 
            // pc_amount
            // 
            this.pc_amount.DataPropertyName = "PcAmount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.pc_amount.DefaultCellStyle = dataGridViewCellStyle4;
            //this.pc_amount.DefaultCellStyle.Format = "#,##0.00;[RED](#,##0.00)";
            //!this.pc_amount.DefaultCellStyle.Format = "#,##0;[RED](#,##0)";
            this.pc_amount.DefaultCellStyle.Format = "#,##0.00";
            this.pc_amount.HeaderText = "Amount";
            this.pc_amount.Name = "pc_amount";
            this.pc_amount.ReadOnly = true;
            this.pc_amount.Width = 60;

            // 
            // comments
            // 
            this.comments.DataPropertyName = "Comments";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.comments.DefaultCellStyle = dataGridViewCellStyle5;
            this.comments.HeaderText = "Comments";
            this.comments.Name = "comments";
            this.comments.ReadOnly = true;
            this.comments.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comments.Width = 264;

            // 
            // DwAcceptRejectMainrundetailGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grid);
            this.Name = "DwAcceptRejectMainrundetailGrid";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }
        string str;

        //jlwang:merge cell
        private void grid_CellPainting(object sender, System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 0 || e.ColumnIndex == 1) && e.RowIndex != -1)
            {
                using (Brush gridBrush = new SolidBrush(this.grid.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                        if (e.RowIndex < grid.Rows.Count - 1 && grid.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString() != e.Value.ToString())
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);

                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

                        if (e.Value != null)
                        {
                            if (e.RowIndex > 0 && grid.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.ToString() == e.Value.ToString())
                            { }
                            else
                            {
                                if (e.ColumnIndex == 1 && e.Value.ToString().Trim().Length >= 30)
                                    str = e.Value.ToString().Trim().Substring(0, 30) + "\r\n" + e.Value.ToString().Trim().Substring(30);
                                else
                                    str = e.Value.ToString();
                                e.Graphics.DrawString(str, e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericTypographic);

                            }
                        }

                        if (e.RowIndex == grid.Rows.Count - 1)
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                        e.Handled = true;                        
                    }
                }
            }
        }

        #endregion
    }
}
