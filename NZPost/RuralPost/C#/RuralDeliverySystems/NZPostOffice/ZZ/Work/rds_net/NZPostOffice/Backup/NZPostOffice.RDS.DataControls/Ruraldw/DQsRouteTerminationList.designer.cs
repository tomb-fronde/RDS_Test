using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DQsRouteTerminationList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_cust_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccust_name;

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
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.QsRouteTerminationList);

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
            // ccust_name
            //
            ccust_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccust_name.DataPropertyName = "CcustName";
            this.ccust_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ccust_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ccust_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.ccust_name.HeaderText = "";
            this.ccust_name.Name = "ccust_name";
            this.ccust_name.ReadOnly = true;
            this.ccust_name.Width = 38;
            this.grid.Columns.Add(ccust_name);

            //
            // customer_cust_id
            //
            customer_cust_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_cust_id.DataPropertyName = "CustomerCustId";
            this.customer_cust_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.customer_cust_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.customer_cust_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.customer_cust_id.HeaderText = "";
            this.customer_cust_id.Name = "customer_cust_id";
            this.customer_cust_id.ReadOnly = true;
            this.customer_cust_id.Width = 7;
            this.grid.Columns.Add(customer_cust_id);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.Controls.Add(grid);
        }
        #endregion
    }
}
