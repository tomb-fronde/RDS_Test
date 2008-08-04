using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    partial class DDddwContractRd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //private System.Windows.Forms.DataGridViewTextBoxColumn rd_no;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.TextBox rd_no;
        //private Metex.Windows.DataEntityGrid grid;
        #region Component Designer generated code
        private void InitializeComponent()
        {
            //components = new System.ComponentModel.Container();
            //grid = new Metex.Windows.DataEntityGrid();
            //((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            //this.SuspendLayout();

            //// 
            //// bindingSource
            ////
            //this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.DddwContractRd);

            //// 
            //// grid
            //// 
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

            //this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //this.grid.DataSource = this.bindingSource;
            //this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            //this.grid.Location = new System.Drawing.Point(0, 0);
            //this.grid.MultiSelect = true;
            //this.grid.Name = "grid";
            //this.grid.RowHeadersVisible = false;
            //this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //this.grid.Size = new System.Drawing.Size(638, 252);
            //this.grid.ColumnHeadersVisible = false;
            //this.grid.TabIndex = 0;

            ////
            //// rd_no
            ////
            //rd_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            //this.rd_no.DataPropertyName = "RdNo";
            //this.rd_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //this.rd_no.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
            //this.rd_no.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            //this.rd_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            //this.rd_no.HeaderText = "";
            //this.rd_no.Name = "rd_no";
            //this.rd_no.ReadOnly = true;
            //this.rd_no.Width = 40;
            //this.grid.Columns.Add(rd_no);

            //((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            //this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.Size = new System.Drawing.Size(638, 252);
            //this.BackColor = System.Drawing.SystemColors.Window;
            //this.Controls.Add(grid);
            components = new System.ComponentModel.Container();
            this.Name = "DDddwContractRd";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwContractRd);
            //
            // rgn_name
            //
            rd_no = new System.Windows.Forms.TextBox();
            this.rd_no.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rd_no.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rd_no.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rd_no.Location = new System.Drawing.Point(0, 1);
            this.rd_no.MaxLength = 40;
            this.rd_no.Name = "rd_no";
            this.rd_no.Size = new System.Drawing.Size(246, 13);
            this.rd_no.TextAlign = HorizontalAlignment.Left;
            //?this.rd_no.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.rd_no.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "RdNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rd_no.TabIndex = 20;
            this.Controls.Add(rd_no);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //?this.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
        }
        #endregion
    }
}
