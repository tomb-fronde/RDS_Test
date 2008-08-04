using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DwTowncity
	{

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        private System.Windows.Forms.DataGridViewTextBoxColumn tc_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tc_id;
        private Metex.Windows.DataEntityGrid grid;
		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
            components = new System.ComponentModel.Container();
            grid = new Metex.Windows.DataEntityGrid();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit(); 
            this.SuspendLayout();
            this.tc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sl_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.Towncity);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            //this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            //this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
            //this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            //this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            //this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.grid.ColumnHeadersHeight = 28;
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
            // tc_name
            // 
            //this.tc_name.BackColor = System.Drawing.SystemColors.Window;
            //this.tc_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //this.tc_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "TcName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.tc_name.Font = new System.Drawing.Font("Arial", 8F);
            //this.tc_name.ForeColor = System.Drawing.SystemColors.WindowText;
            //this.tc_name.Location = new System.Drawing.Point(1, 0);
            //this.tc_name.MaxLength = 50;
            //this.tc_name.Name = "tc_name";
            //this.tc_name.Size = new System.Drawing.Size(306, 13);
            //this.tc_name.TabIndex = 10;
            this.tc_name.DataPropertyName = "TcName";
			this.tc_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.tc_name.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
			this.tc_name.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tc_name.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.tc_name.HeaderText = "";
			this.tc_name.Name = "tc_name";
            this.tc_name.MaxInputLength = 50;
            this.tc_name.Width = 205;
            this.grid.Columns.Add(tc_name);
            // 
            // tc_id
            // 
            //this.tc_id.BackColor = System.Drawing.SystemColors.Window;
            //this.tc_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //this.tc_id.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "TcId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.tc_id.Font = new System.Drawing.Font("Arial", 8F);
            //this.tc_id.ForeColor = System.Drawing.SystemColors.WindowText;
            //this.tc_id.Location = new System.Drawing.Point(338, 0);
            //this.tc_id.MaxLength = 0;
            //this.tc_id.Name = "tc_id";
            //this.tc_id.ReadOnly = true;
            //this.tc_id.Size = new System.Drawing.Size(46, 13);
            //this.tc_id.TabIndex = 11;
            this.tc_id.DataPropertyName = "TcId";
            this.tc_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.tc_id.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tc_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.tc_id.HeaderText = "";
            this.tc_id.Name = "tc_id";
            this.tc_id.Width = 46;
            this.tc_id.Visible = false;
            this.grid.Columns.Add(tc_id);
            // 
            // sl_id
            // 
            //this.sl_id.BackColor = System.Drawing.SystemColors.Window;
            //this.sl_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //this.sl_id.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "SlId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.sl_id.Font = new System.Drawing.Font("Arial", 8F);
            //this.sl_id.ForeColor = System.Drawing.SystemColors.WindowText;
            //this.sl_id.Location = new System.Drawing.Point(400, 0);
            //this.sl_id.MaxLength = 0;
            //this.sl_id.Name = "sl_id";
            //this.sl_id.ReadOnly = true;
            //this.sl_id.Size = new System.Drawing.Size(46, 13);
            //this.sl_id.TabIndex = 12;
            this.sl_id.DataPropertyName = "SlId";
            this.sl_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.sl_id.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sl_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.sl_id.HeaderText = "";
            this.sl_id.Visible = false;
            this.sl_id.Name = "tc_id";
            this.sl_id.Width = 46;            
            this.grid.Columns.Add(sl_id);
            // 
            // DwTowncity
            // 
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
            this.Controls.Add(grid);

            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.BackColor = System.Drawing.SystemColors.Window;
            //this.Controls.Add(this.tc_name);
            //this.Controls.Add(this.tc_id);
            //this.Controls.Add(this.sl_id);
            //this.Name = "DwTowncity";
            //this.Size = new System.Drawing.Size(650, 300);
            //((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            //this.ResumeLayout(false);
            //this.PerformLayout();

		}
		#endregion

	}
}
