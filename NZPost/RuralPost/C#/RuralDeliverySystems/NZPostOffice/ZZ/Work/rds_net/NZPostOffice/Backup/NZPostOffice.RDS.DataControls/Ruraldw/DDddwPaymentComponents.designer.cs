using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;


namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DDddwPaymentComponents
	{

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn pct_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcg_short_code;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.DddwPaymentComponents);

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
            this.grid.ColumnHeadersVisible = false;
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
            // pct_description
            //
            pct_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pct_description.DataPropertyName = "PctDescription";
            this.pct_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.pct_description.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pct_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.pct_description.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.pct_description.HeaderText = "";
            this.pct_description.Name = "pct_description";
            this.pct_description.ReadOnly = true;
            this.pct_description.Width = 200;
            this.grid.Columns.Add(pct_description);


            //
            // pcg_short_code
            //
            pcg_short_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcg_short_code.DataPropertyName = "PcgShortCode";
            this.pcg_short_code.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.pcg_short_code.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pcg_short_code.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.pcg_short_code.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.pcg_short_code.HeaderText = "";
            this.pcg_short_code.Name = "pcg_short_code";
            this.pcg_short_code.ReadOnly = true;
            this.pcg_short_code.Width = 25;
            this.grid.Columns.Add(pcg_short_code);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            //this.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
        }
        #endregion


	}
}
