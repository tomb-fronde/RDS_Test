using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DPieceRates2001
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn prt_description;
        // private System.Windows.Forms.DataGridViewTextBoxColumn pr_rate;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn pr_rate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pr_active_status;
        //private System.Windows.Forms.DataGridViewTextBoxColumn pr_effective_date;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn pr_effective_date;
        //        private System.Windows.Forms.DataGridViewTextBoxColumn grp;

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
            grid = new Metex.Windows.DataEntityGrid();
            this.prt_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pr_rate = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn();
            this.pr_active_status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            //this.pr_effective_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pr_effective_date = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
            
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.PieceRates2001);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prt_description,
            this.pr_rate,
            this.pr_active_status,
            this.pr_effective_date});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 10;
            this.grid.DataError += new DataGridViewDataErrorEventHandler(grid_DataError);
            //
            // prt_description
            //
            this.prt_description.DataPropertyName = "PrtDescription";
            this.prt_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.prt_description.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.prt_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.prt_description.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.prt_description.HeaderText = "Piece Rate";
            this.prt_description.Name = "prt_description";
            this.prt_description.ReadOnly = true;
            this.prt_description.Width = 174;
            //
            // pr_rate
            //
            this.pr_rate.DataPropertyName = "PrRate";
            this.pr_rate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pr_rate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.pr_rate.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.pr_rate.DefaultCellStyle.Format = "###.00000";
            this.pr_rate.HeaderText = "Rate ($)";
            this.pr_rate.Mask = "###.00000";
            this.pr_rate.Name = "pr_rate";
            this.pr_rate.Width = 67;
            //
            // pr_active_status
            //
            this.pr_active_status.DataPropertyName = "PrActiveStatus";
            this.pr_active_status.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.pr_active_status.DefaultCellStyle.ForeColor = System.Drawing.Color.Black; ;
            this.pr_active_status.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.pr_active_status.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
            this.pr_active_status.DefaultCellStyle.NullValue = false;
            this.pr_active_status.FalseValue = "Y";
            this.pr_active_status.HeaderText = "Inactive";
            this.pr_active_status.Name = "pr_active_status";
            this.pr_active_status.TrueValue = "N";
            this.pr_active_status.Width = 48;
            // 
            // pr_effective_date
            // 
            this.pr_effective_date.DataPropertyName = "PrEffectiveDate";
            this.pr_effective_date.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.pr_effective_date.DefaultCellStyle.NullValue = "00/00/0000";
            this.pr_effective_date.HeaderText = "Effective Date";
            this.pr_effective_date.Name = "pr_effective_date";
            this.pr_effective_date.Mask = "00/00/0000";
            this.pr_effective_date.PromptChar = '0';
            this.pr_effective_date.ValueType = typeof(DateTime);
            // 
            // DPieceRates2001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Name = "DPieceRates2001";
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); 
        }

        // void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        // {
        //     throw new Exception("The method or operation is not implemented.");
        // }

        void grid_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 3)    // pr_effective_date
            {
                MessageBox.Show("The date does not pass validation.\n" 
                                + "Please enter a valid Date."
                                , "Validation Error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (e.ColumnIndex == 1) // pr_rate
            {
                MessageBox.Show("The value does not pass validation.\n" 
                                + "Please enter a valid numeric value."
                                , "Validation Error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        #endregion

        void DPieceRates2001_SizeChanged(object sender, System.EventArgs e)
        {
            this.grid.Width = this.Width - this.grid.Left - 3;
            this.grid.Height = this.Height - this.grid.Top - 3;
        }
    }
}
