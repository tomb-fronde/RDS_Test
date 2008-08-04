using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    partial class DContractAllowancesV2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label allowance_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn net_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn compute_0004;
        private System.Windows.Forms.DataGridViewTextBoxColumn alt_description;
        private System.Windows.Forms.Label t_1;

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
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.ContractAllowancesV2);

            //
            // t_1
            //
            this.t_1 = new System.Windows.Forms.Label();
            this.t_1.Font = new System.Drawing.Font("Arial", 8F, FontStyle.Bold);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(0, 0);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(500, 14);
            this.t_1.Text = "Rural Delivery Contracts";
            this.t_1.TextAlign = ContentAlignment.MiddleLeft;
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                 | System.Windows.Forms.AnchorStyles.Left)
                 | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F, FontStyle.Bold);
            this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.DataSource = this.bindingSource;
            //this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 14);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 210);
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grid.TabIndex = 0;
            this.grid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.grid.BorderStyle = BorderStyle.None;
            this.grid.ScrollBars = ScrollBars.Vertical;

            //
            // alt_description
            //
            alt_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_description.DataPropertyName = "AltDescription";
            this.alt_description.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.alt_description.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.alt_description.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.alt_description.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.alt_description.HeaderText = "Allowance";
            this.alt_description.Name = "alt_description";
            this.alt_description.ReadOnly = true;
            this.alt_description.Width = 300;
            this.grid.Columns.Add(alt_description);

            //
            // net_amount
            //
            net_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.net_amount.DataPropertyName = "NetAmount";
            this.net_amount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.net_amount.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.net_amount.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.net_amount.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.net_amount.DefaultCellStyle.Format = "$#,##0.00";
            this.net_amount.HeaderText = "Net amount";
            this.net_amount.Name = "net_amount";
            this.net_amount.ReadOnly = true;
            this.net_amount.Width = 78;
            this.grid.Columns.Add(net_amount);

            //
            // compute_0004
            //
            compute_0004 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compute_0004.DataPropertyName = "Compute0004";
            this.compute_0004.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.compute_0004.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.compute_0004.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.compute_0004.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_0004.HeaderText = "";
            this.compute_0004.Name = "compute_0004";
            this.compute_0004.ReadOnly = true;
            this.compute_0004.Width = 217;
            this.compute_0004.Visible = false;
            this.grid.Columns.Add(compute_0004);
            line = new GroupBox();
            line.Height = 3;
            line.Width = 75;
            line.Left = 300;

            //
            // allowance_total
            //
            this.allowance_total = new System.Windows.Forms.Label();
            this.allowance_total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.allowance_total.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.allowance_total.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.allowance_total.BorderStyle = BorderStyle.None;
            this.allowance_total.ForeColor = System.Drawing.Color.Black;
            this.allowance_total.Location = new System.Drawing.Point(380, 244);
            this.allowance_total.Name = "allowance_total";
            this.allowance_total.Size = new System.Drawing.Size(100, 20);
            this.allowance_total.TabIndex = 1;
            this.allowance_total.TextAlign = ContentAlignment.MiddleRight;

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.SystemColors.ButtonFace;

            this.Controls.Add(grid);
            this.Controls.Add(t_1);
            this.Controls.Add(line);
            this.Controls.Add(allowance_total);
            this.bindingSource.ListChanged += new ListChangedEventHandler(bindingSource_ListChanged);
        }
        private System.Windows.Forms.GroupBox line;
        void bindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            //this.grid.Height = this.RowCount * 20 + 28;
            //this.grid.Height = this.RowCount * this.grid.RowTemplate.Height + this.grid.ColumnHeadersHeight;
            this.line.Top = this.grid.Top + this.grid.Height;
            this.allowance_total.Top = this.line.Top + 3;

            decimal li = 0;
            for (int i = 0; i < this.RowCount; i++)
            {
                li += this.GetItem<ContractAllowancesV2>(i).NetAmount.GetValueOrDefault();
            }
            this.allowance_total.Text = li.ToString("$#,##0.00");
        }
        #endregion
    }
}
