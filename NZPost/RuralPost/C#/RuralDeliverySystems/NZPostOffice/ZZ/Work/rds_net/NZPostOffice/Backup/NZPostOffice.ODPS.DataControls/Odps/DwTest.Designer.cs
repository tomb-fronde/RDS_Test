namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class DwTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn rc_first_names;
        private System.Windows.Forms.DataGridViewTextBoxColumn rc_surname_company;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipient_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_id;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.Test);

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
            this.grid.ColumnHeadersHeight = 28;
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
            // cust_id
            //
            cust_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_id.DataPropertyName = "CustId";
            this.cust_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cust_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cust_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.cust_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.cust_id.HeaderText = "Cust Id";
            this.cust_id.Name = "cust_id";
            this.cust_id.Width = 72;
            this.grid.Columns.Add(cust_id);


            //
            // recipient_id
            //
            recipient_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipient_id.DataPropertyName = "RecipientId";
            this.recipient_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.recipient_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.recipient_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.recipient_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.recipient_id.HeaderText = "Recipient Id";
            this.recipient_id.Name = "recipient_id";
            this.recipient_id.Width = 72;
            this.grid.Columns.Add(recipient_id);


            //
            // rc_surname_company
            //
            rc_surname_company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rc_surname_company.DataPropertyName = "RcSurnameCompany";
            this.rc_surname_company.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rc_surname_company.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rc_surname_company.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rc_surname_company.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.rc_surname_company.HeaderText = "Rc Surname Company";
            this.rc_surname_company.Name = "rc_surname_company";
            this.rc_surname_company.Width = 187;
            this.grid.Columns.Add(rc_surname_company);


            //
            // rc_first_names
            //
            rc_first_names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rc_first_names.DataPropertyName = "RcFirstNames";
            this.rc_first_names.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rc_first_names.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rc_first_names.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rc_first_names.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
            this.rc_first_names.HeaderText = "Rc First Names";
            this.rc_first_names.Name = "rc_first_names";
            this.rc_first_names.Width = 186;
            this.grid.Columns.Add(rc_first_names);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(grid);
        }
        #endregion

    }
}
