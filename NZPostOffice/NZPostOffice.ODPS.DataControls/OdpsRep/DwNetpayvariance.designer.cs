namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwNetpayvariance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn var;
        private System.Windows.Forms.DataGridViewTextBoxColumn contract_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastmonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn thismonth;


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
            components = new System.ComponentModel.Container();
            grid = new Metex.Windows.DataEntityGrid();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.Netpayvariance);

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
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;

            //
            // lastmonth
            //
            lastmonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastmonth.DataPropertyName = "Lastmonth";
            this.lastmonth.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.lastmonth.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lastmonth.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.lastmonth.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.lastmonth.DefaultCellStyle.Format = "#,##0.00;(#,##0.00)";
            this.lastmonth.HeaderText = "Last Month";
            this.lastmonth.Name = "lastmonth";
            this.lastmonth.ReadOnly = true;
            this.lastmonth.Width = 106;
            this.grid.Columns.Add(lastmonth);


            //
            // thismonth
            //
            thismonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thismonth.DataPropertyName = "Thismonth";
            this.thismonth.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.thismonth.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.thismonth.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.thismonth.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.thismonth.DefaultCellStyle.Format = "#,##0.00;(#,##0.00)";
            this.thismonth.HeaderText = "This Month";
            this.thismonth.Name = "thismonth";
            this.thismonth.ReadOnly = true;
            this.thismonth.Width = 106;
            this.grid.Columns.Add(thismonth);


            //
            // contract_no
            //
            contract_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contract_no.DataPropertyName = "ContractNo";
            this.contract_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.contract_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contract_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.contract_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.contract_no.HeaderText = "rural";
            this.contract_no.Name = "contract_no";
            this.contract_no.ReadOnly = true;
            this.contract_no.Width = 75;
            this.grid.Columns.Add(contract_no);


            //
            // var
            //
            var = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.var.DataPropertyName = "Var";
            this.var.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.var.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.var.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.var.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.var.DefaultCellStyle.Format = "#,##0.00";
            this.var.HeaderText = "Variance (%)";
            this.var.Name = "var";
            this.var.Width = 85;
            this.grid.Columns.Add(var);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(grid);
        }
        #endregion

    }
}
