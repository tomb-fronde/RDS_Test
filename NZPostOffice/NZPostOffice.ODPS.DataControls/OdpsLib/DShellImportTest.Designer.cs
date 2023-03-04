namespace NZPostOffice.ODPS.DataControls.OdpsLib
{
    partial class DShellImportTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum3;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum4;
        private System.Windows.Forms.DataGridViewTextBoxColumn column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn column18;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsLib.ShellImportTest);

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
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;

            //
            // column15
            //
            column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column15.DataPropertyName = "Column15";
            this.column15.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column15.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.column15.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column15.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column15.HeaderText = "";
            this.column15.Name = "column15";
            this.column15.ReadOnly = true;
            this.column15.Width = 140;
            this.grid.Columns.Add(column15);


            //
            // column16
            //
            column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column16.DataPropertyName = "Column16";
            this.column16.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column16.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.column16.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column16.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column16.HeaderText = "";
            this.column16.Name = "column16";
            this.column16.ReadOnly = true;
            this.column16.Width = 56;
            this.grid.Columns.Add(column16);


            //
            // column17
            //
            column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column17.DataPropertyName = "Column17";
            this.column17.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column17.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.column17.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column17.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column17.HeaderText = "";
            this.column17.Name = "column17";
            this.column17.ReadOnly = true;
            this.column17.Width = 56;
            this.grid.Columns.Add(column17);


            //
            // column18
            //
            column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column18.DataPropertyName = "Column18";
            this.column18.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.column18.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.column18.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.column18.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.column18.HeaderText = "";
            this.column18.Name = "column18";
            this.column18.ReadOnly = true;
            this.column18.Width = 56;
            this.grid.Columns.Add(column18);


            //
            // sum1
            //
            sum1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum1.DataPropertyName = "Sum1";
            this.sum1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sum1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.sum1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.sum1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.sum1.HeaderText = "";
            this.sum1.Name = "sum1";
            this.sum1.Width = 56;
            this.grid.Columns.Add(sum1);


            //
            // sum2
            //
            sum2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum2.DataPropertyName = "Sum2";
            this.sum2.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sum2.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.sum2.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.sum2.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.sum2.HeaderText = "";
            this.sum2.Name = "sum2";
            this.sum2.Width = 0;
            this.grid.Columns.Add(sum2);


            //
            // sum3
            //
            sum3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum3.DataPropertyName = "Sum3";
            this.sum3.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sum3.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.sum3.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.sum3.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.sum3.HeaderText = "";
            this.sum3.Name = "sum3";
            this.sum3.Width = 0;
            this.grid.Columns.Add(sum3);


            //
            // sum4
            //
            sum4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum4.DataPropertyName = "Sum4";
            this.sum4.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.sum4.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.sum4.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.sum4.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.sum4.HeaderText = "";
            this.sum4.Name = "sum4";
            this.sum4.Width = 0;
            this.grid.Columns.Add(sum4);

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
