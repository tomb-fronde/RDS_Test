using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.OdpsCodes;

namespace NZPostOffice.ODPS.DataControls.OdpsCodes
{
	partial class DDddwRenewalgroup
	{
        // TJB RPCR_141 June-2019: Copied from RDS.DataControls.Ruraldw

        private System.ComponentModel.IContainer components = null;
        private Metex.Windows.DataEntityListBox listBox;
        //private System.Windows.Forms.DataGridViewTextBoxColumn rg_description;
        private TextBox rg_description;

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
            //components = new System.ComponentModel.Container();
            //grid = new Metex.Windows.DataEntityGrid();
            //((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            //this.SuspendLayout();
            
            //// 
            //// bindingSource
            ////
            //this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Ruraldw.DddwRenewalgroup);

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
            //this.grid.ColumnHeadersVisible = false;
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
            //this.grid.TabIndex = 0;

            ////
            //// rg_description
            ////
            //rg_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            //this.rg_description.DataPropertyName = "RgDescription";
            //this.rg_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //this.rg_description.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            //this.rg_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            //this.rg_description.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            //this.rg_description.HeaderText = "";
            //this.rg_description.Name = "rg_description";
            //this.rg_description.ReadOnly = true;
            //this.rg_description.Width = 200;
            //this.grid.Columns.Add(rg_description);

            //((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            //this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.Size = new System.Drawing.Size(638, 252);
            //this.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            //this.Controls.Add(grid);

            components = new System.ComponentModel.Container();
            this.listBox = new Metex.Windows.DataEntityListBox();
            this.Name = "DDddwRenewalgroup";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwRenewalgroup);
            //
            // rg_description
            //
            //rg_description = new System.Windows.Forms.TextBox();
            //this.rg_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //this.rg_description.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            //this.rg_description.ForeColor = System.Drawing.SystemColors.WindowText;
            //this.rg_description.Location = new System.Drawing.Point(0, 1);
            //this.rg_description.MaxLength = 40;
            //this.rg_description.Name = "rg_description";
            //this.rg_description.Size = new System.Drawing.Size(246, 13);
            //this.rg_description.TextAlign = HorizontalAlignment.Left;
            //this.rg_description.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            //this.rg_description.DataBindings.Add(new System.Windows.Forms.Binding("Text",
            //    this.bindingSource, "RgDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.rg_description.TabIndex = 20;
            //this.Controls.Add(rg_description);

            // 
            // listBox
            // 
            this.listBox.DataSource = this.bindingSource;
            this.listBox.DisplayMember = "RgDescription";
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(199, 173);
            this.listBox.TabIndex = 0;

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //?this.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
        }
        #endregion

	}
}
