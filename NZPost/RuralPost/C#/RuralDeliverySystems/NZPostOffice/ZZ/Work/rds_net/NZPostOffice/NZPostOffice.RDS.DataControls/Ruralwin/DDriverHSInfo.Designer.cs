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
            this.hstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsiDateCheckedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsiPassfailIndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdditionalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsiNotesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hstNameDataGridViewTextBoxColumn,
            this.hsiDateCheckedDataGridViewTextBoxColumn,
            this.hsiPassfailIndDataGridViewTextBoxColumn,
            this.AdditionalDate,
            this.hsiNotesDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(8, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 44;
            this.dataGridView1.Size = new System.Drawing.Size(602, 252);
            this.dataGridView1.TabIndex = 55;
            // 
            // hstNameDataGridViewTextBoxColumn
            // 
            this.hstNameDataGridViewTextBoxColumn.DataPropertyName = "HstName";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.hstNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.hstNameDataGridViewTextBoxColumn.HeaderText = "Check Type";
            this.hstNameDataGridViewTextBoxColumn.Name = "hstNameDataGridViewTextBoxColumn";
            this.hstNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.hstNameDataGridViewTextBoxColumn.Width = 144;
            // 
            // hsiDateCheckedDataGridViewTextBoxColumn
            // 
            this.hsiDateCheckedDataGridViewTextBoxColumn.DataPropertyName = "HsiDateChecked";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.hsiDateCheckedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.hsiDateCheckedDataGridViewTextBoxColumn.HeaderText = "Date Checked";
            this.hsiDateCheckedDataGridViewTextBoxColumn.Name = "hsiDateCheckedDataGridViewTextBoxColumn";
            this.hsiDateCheckedDataGridViewTextBoxColumn.Width = 80;
            // 
            // hsiPassfailIndDataGridViewTextBoxColumn
            // 
            this.hsiPassfailIndDataGridViewTextBoxColumn.DataPropertyName = "HsiPassfailInd";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.hsiPassfailIndDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.hsiPassfailIndDataGridViewTextBoxColumn.HeaderText = "P/F";
            this.hsiPassfailIndDataGridViewTextBoxColumn.Name = "hsiPassfailIndDataGridViewTextBoxColumn";
            this.hsiPassfailIndDataGridViewTextBoxColumn.Width = 40;
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
            // hsiNotesDataGridViewTextBoxColumn
            // 
            this.hsiNotesDataGridViewTextBoxColumn.DataPropertyName = "HsiNotes";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.hsiNotesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.hsiNotesDataGridViewTextBoxColumn.HeaderText = "Notes";
            this.hsiNotesDataGridViewTextBoxColumn.MinimumWidth = 254;
            this.hsiNotesDataGridViewTextBoxColumn.Name = "hsiNotesDataGridViewTextBoxColumn";
            this.hsiNotesDataGridViewTextBoxColumn.Width = 254;
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
        private DataGridViewTextBoxColumn hstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn hsiDateCheckedDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn hsiPassfailIndDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn AdditionalDate;
        private DataGridViewTextBoxColumn hsiNotesDataGridViewTextBoxColumn;


    }
}
