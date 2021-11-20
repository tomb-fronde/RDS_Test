using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DwNationalFuelOverride
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //private System.Windows.Forms.DataGridViewTextBoxColumn fuel_rate;
        private System.Windows.Forms.Panel panel1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            //grid = new Metex.Windows.DataEntityGrid();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.NationalFuelOverride);

            // 
            // grid
            // 
            //this.grid.AllowUserToAddRows = false;
            //this.grid.AllowUserToResizeRows = false;
            //this.grid.AutoGenerateColumns = false;
            //this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            //this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            //this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            //this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            //this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.grid.ColumnHeadersVisible = false;
            ////this.grid.Columns[0].DefaultCellStyle.Format = "0000.00";
            //this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //this.grid.DataSource = this.bindingSource;
            //this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            //this.grid.Location = new System.Drawing.Point(0, 0);
            //this.grid.MultiSelect = true;
            //this.grid.Name = "grid";
            //this.grid.RowHeadersVisible = false;
            //this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            //this.grid.Size = new System.Drawing.Size(638, 252);
            //this.grid.TabIndex = 0;

            //
            // fuel_rate
            //
            //fuel_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            //this.fuel_rate.DataPropertyName = "FuelRate";
            //this.fuel_rate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            ////this.fuel_rate.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            //this.fuel_rate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            //this.fuel_rate.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            //this.fuel_rate.HeaderText = "";
            //this.fuel_rate.Name = "fuel_rate";
            //this.fuel_rate.Width = 85;
            //this.grid.Columns.Add(fuel_rate);

            // 
            // panel1
            // 
            panel1 = new Panel();
            //this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(0, 1);
            //this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //            | System.Windows.Forms.AnchorStyles.Left)
            //            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(86, 224);
            this.panel1.TabIndex = 1;
            this.Controls.Add(this.panel1);
            this.RetrieveEnd += new EventHandler(DwNationalFuelOverride_RetrieveEnd);
            //((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            //this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.Size = new System.Drawing.Size(638, 252);
            //this.BackColor = System.Drawing.ColorTranslator.FromWin32(79216776);
            //this.Controls.Add(grid);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
    }
}
