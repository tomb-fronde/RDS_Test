using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB  RPCR_060  Jan-2014: NEW
    // Datacontrol for Driver Health & Safety info

    partial class DDriverHSInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.hstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsiDateChecked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsiPassfailInd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdditionalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsiNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hstHelp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.DriverHSInfo);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hstName,
            this.hsiDateChecked,
            this.hsiPassfailInd,
            this.AdditionalDate,
            this.hsiNotes,
            this.hstHelp});
            this.dataGridView1.DataSource = this.bindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(8, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 44;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(602, 252);
            this.dataGridView1.TabIndex = 55;
            // 
            // hstName
            // 
            this.hstName.DataPropertyName = "HstName";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.hstName.DefaultCellStyle = dataGridViewCellStyle1;
            this.hstName.HeaderText = "Check Type";
            this.hstName.Name = "hstName";
            this.hstName.ReadOnly = true;
            this.hstName.Width = 144;
            // 
            // hsiDateChecked
            // 
            this.hsiDateChecked.DataPropertyName = "HsiDateChecked";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.hsiDateChecked.DefaultCellStyle = dataGridViewCellStyle2;
            this.hsiDateChecked.HeaderText = "Date Checked";
            this.hsiDateChecked.MaxInputLength = 12;
            this.hsiDateChecked.Name = "hsiDateChecked";
            this.hsiDateChecked.Width = 80;
            // 
            // hsiPassfailInd
            // 
            this.hsiPassfailInd.DataPropertyName = "HsiPassfailInd";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.hsiPassfailInd.DefaultCellStyle = dataGridViewCellStyle3;
            this.hsiPassfailInd.HeaderText = "P/F";
            this.hsiPassfailInd.Name = "hsiPassfailInd";
            this.hsiPassfailInd.Width = 40;
            // 
            // AdditionalDate
            // 
            this.AdditionalDate.DataPropertyName = "HsiAdditionalDate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.AdditionalDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.AdditionalDate.HeaderText = "Additional Date";
            this.AdditionalDate.Name = "AdditionalDate";
            this.AdditionalDate.Width = 80;
            // 
            // hsiNotes
            // 
            this.hsiNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.hsiNotes.DataPropertyName = "HsiNotes";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.hsiNotes.DefaultCellStyle = dataGridViewCellStyle5;
            this.hsiNotes.HeaderText = "Notes";
            this.hsiNotes.MinimumWidth = 254;
            this.hsiNotes.Name = "hsiNotes";
            this.hsiNotes.Width = 254;
            // 
            // hstHelp
            // 
            this.hstHelp.DataPropertyName = "HstHelp";
            this.hstHelp.HeaderText = "HS Type Help";
            this.hstHelp.Name = "HstHelp";
            this.hstHelp.Visible = false;
            // 
            // DDriverHSInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.dataGridView1);
            this.Name = "DDriverHSInfo";
            this.Size = new System.Drawing.Size(624, 265);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

		}
        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn hstName;
        private DataGridViewTextBoxColumn hsiDateChecked;
        private DataGridViewTextBoxColumn hsiPassfailInd;
        private DataGridViewTextBoxColumn AdditionalDate;
        private DataGridViewTextBoxColumn hsiNotes;
        private DataGridViewTextBoxColumn hstHelp;
    }
}
