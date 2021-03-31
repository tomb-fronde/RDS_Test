using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB Allowances 9-Mar-2021: New

    partial class DContractAllowancesV3
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label allowance_total;
        private System.Windows.Forms.Label t_1;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.t_1 = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.GroupBox();
            this.allowance_total = new System.Windows.Forms.Label();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.alt_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.net_amount = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn();
            this.ca_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaEffectiveDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaPaidToDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alct_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.ContractAllowancesV3);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // t_1
            // 
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(0, 0);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(500, 14);
            this.t_1.TabIndex = 1;
            this.t_1.Text = "Rural Delivery Contracts";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // line
            // 
            this.line.Location = new System.Drawing.Point(300, 0);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(75, 3);
            this.line.TabIndex = 2;
            this.line.TabStop = false;
            // 
            // allowance_total
            // 
            this.allowance_total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.allowance_total.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.allowance_total.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allowance_total.ForeColor = System.Drawing.Color.Black;
            this.allowance_total.Location = new System.Drawing.Point(70, 242);
            this.allowance_total.Name = "allowance_total";
            this.allowance_total.Size = new System.Drawing.Size(100, 20);
            this.allowance_total.TabIndex = 1;
            this.allowance_total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alt_description,
            this.net_amount,
            this.ca_notes,
            this.CaEffectiveDate,
            this.CaPaidToDate,
            this.alct_id});
            this.grid.DataSource = this.bindingSource;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 14);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(504, 211);
            this.grid.TabIndex = 0;
            // 
            // alt_description
            // 
            this.alt_description.DataPropertyName = "AltDescription";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.NullValue = null;
            this.alt_description.DefaultCellStyle = dataGridViewCellStyle2;
            this.alt_description.HeaderText = "Allowance";
            this.alt_description.Name = "alt_description";
            this.alt_description.ReadOnly = true;
            this.alt_description.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.alt_description.Width = 120;
            // 
            // net_amount
            // 
            this.net_amount.DataPropertyName = "NetAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Format = "$#,##0.00";
            this.net_amount.DefaultCellStyle = dataGridViewCellStyle3;
            this.net_amount.HeaderText = "  Net Amount";
            this.net_amount.IncludeLiterals = false;
            this.net_amount.IncludePrompt = false;
            this.net_amount.Mask = null;
            this.net_amount.Name = "net_amount";
            this.net_amount.PromptChar = '\0';
            this.net_amount.ReadOnly = true;
            this.net_amount.ValidatingType = null;
            this.net_amount.Width = 78;
            // 
            // ca_notes
            // 
            this.ca_notes.DataPropertyName = "CaNotes";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ca_notes.DefaultCellStyle = dataGridViewCellStyle4;
            this.ca_notes.HeaderText = "Notes";
            this.ca_notes.Name = "ca_notes";
            this.ca_notes.ReadOnly = true;
            this.ca_notes.Width = 176;
            // 
            // CaEffectiveDate
            // 
            this.CaEffectiveDate.DataPropertyName = "CaEffectiveDate";
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = "null";   // "00/00/0000";
            this.CaEffectiveDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.CaEffectiveDate.HeaderText = "Effective Date";
            this.CaEffectiveDate.Name = "CaEffectiveDate";
            this.CaEffectiveDate.ReadOnly = true;
            this.CaEffectiveDate.Width = 78;
            // 
            // CaPaidToDate
            // 
            this.CaPaidToDate.DataPropertyName = "CaPaidToDate";
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = "null";   // "00/00/0000";
            this.CaPaidToDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.CaPaidToDate.HeaderText = "Paid To Date";
            this.CaPaidToDate.Name = "CaPaidToDate";
            this.CaPaidToDate.ReadOnly = true;
            this.CaPaidToDate.Width = 70;
            // 
            // alct_id
            // 
            this.alct_id.DataPropertyName = "AlctId";
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.alct_id.DefaultCellStyle = dataGridViewCellStyle7;
            this.alct_id.HeaderText = "AlctId";
            this.alct_id.Name = "alct_id";
            this.alct_id.ReadOnly = true;
            this.alct_id.Width = 50;
            // 
            // DContractAllowancesV3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.line);
            this.Controls.Add(this.allowance_total);
            this.Name = "DContractAllowancesV3";
            this.Size = new System.Drawing.Size(507, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

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
                li += this.GetItem<ContractAllowancesV3>(i).NetAmount.GetValueOrDefault();
            }
            this.allowance_total.Text = li.ToString("$#,##0.00");
        }
        #endregion

        private Metex.Windows.DataEntityGrid grid;
        private DataGridViewTextBoxColumn alt_description;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn net_amount;
        private DataGridViewTextBoxColumn ca_notes;
        private DataGridViewTextBoxColumn CaEffectiveDate;
        private DataGridViewTextBoxColumn CaPaidToDate;
        private DataGridViewTextBoxColumn alct_id;

    }
}
