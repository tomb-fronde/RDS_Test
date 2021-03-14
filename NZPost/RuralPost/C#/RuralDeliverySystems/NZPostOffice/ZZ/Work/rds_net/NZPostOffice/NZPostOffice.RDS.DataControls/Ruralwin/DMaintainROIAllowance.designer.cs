using System;
using System.Windows.Forms;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB Allowances 9-Mar-2021: New

    partial class DMaintainROIAllowance
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label st_title;
        private System.Windows.Forms.Label st_protect_confirm;
        private Metex.Windows.DataGridViewEntityComboColumn alt_key;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn ca_effective_date;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn ca_paid_to_date;
        private DataGridViewTextBoxColumn ca_annual_amount;
        private DataGridViewCheckBoxColumn ca_approved;
        private DataGridViewTextBoxColumn ca_notes;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();

            this.grid = new Metex.Windows.DataEntityGrid();
            this.st_title = new System.Windows.Forms.Label();
            this.st_protect_confirm = new System.Windows.Forms.Label();
            this.alt_key = new Metex.Windows.DataGridViewEntityComboColumn();
            this.ca_effective_date = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
            this.ca_paid_to_date = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
            this.ca_annual_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_approved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ca_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.MaintainAllowance);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.alt_key,
                this.ca_effective_date,
                this.ca_annual_amount,
                this.ca_approved,
                this.ca_paid_to_date,
                this.ca_notes});
            this.grid.Columns[4].ReadOnly = true;

            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            //this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.Size = new System.Drawing.Size(570, 252);
            this.grid.TabIndex = 0;
            this.grid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grid_Validating);
            this.grid.CurrentCellDirtyStateChanged += new System.EventHandler(this.grid_CurrentCellDirtyStateChanged);
            this.grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // st_title
            // 
            this.st_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_title.Location = new System.Drawing.Point(0, 0);
            this.st_title.Name = "st_title";
            this.st_title.Size = new System.Drawing.Size(638, 14);
            this.st_title.TabIndex = 1;
            this.st_title.Text = "Renewal:";
            // 
            // st_protect_confirm
            // 
            this.st_protect_confirm.Location = new System.Drawing.Point(0, 0);
            this.st_protect_confirm.Name = "st_protect_confirm";
            this.st_protect_confirm.Size = new System.Drawing.Size(10, 14);
            this.st_protect_confirm.TabIndex = 2;
            this.st_protect_confirm.Text = "N";
            this.st_protect_confirm.Visible = false;
            // 
            // alt_key
            // 
            this.alt_key.DataPropertyName = "AltKey";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = null;
            this.alt_key.DefaultCellStyle = dataGridViewCellStyle2;
            this.alt_key.HeaderText = "Allowance";
            this.alt_key.Name = "alt_key";
            this.alt_key.Width = 140;
            this.alt_key.DefaultCellStyle.NullValue = null;
            this.alt_key.DefaultCellStyle.DataSourceNullValue = null;
            this.alt_key.ValueMember = "AltKey";
            this.alt_key.DisplayMember = "AltDescription";
            this.alt_key.DropDownWidth = 210;
            // 
            // ca_effective_date
            // 
            this.ca_effective_date.DataPropertyName = "EffectiveDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            dataGridViewCellStyle3.NullValue = "00/00/0000";
            this.ca_effective_date.DefaultCellStyle = dataGridViewCellStyle3;
            this.ca_effective_date.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.ca_effective_date.HeaderText = "Effective Date";
            //this.ca_effective_date.IncludeLiterals = false;
            //this.ca_effective_date.IncludePrompt = false;
            this.ca_effective_date.Mask = "00/00/0000";
            this.ca_effective_date.Name = "ca_effective_date";
            this.ca_effective_date.PromptChar = '0';
            this.ca_effective_date.ValidatingType = null;
            this.ca_effective_date.ValueType = typeof(System.DateTime);
            this.ca_effective_date.Width = 70;
            // 
            // ca_annual_amount
            // 
            this.ca_annual_amount.DataPropertyName = "AnnualAmount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Format = "##,###.00";
            dataGridViewCellStyle4.NullValue = ".00";
            this.ca_annual_amount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ca_annual_amount.HeaderText = "Amount";
            this.ca_annual_amount.Name = "ca_annual_amount";
            this.ca_annual_amount.Width = 60;
            // 
            // ca_approved
            // 
            this.ca_approved.DataPropertyName = "Approved";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.NullValue = false;
            this.ca_approved.DefaultCellStyle = dataGridViewCellStyle5;
            this.ca_approved.HeaderText = "Approved";
            this.ca_approved.Name = "ca_approved";
            this.ca_approved.TrueValue  = "Y";
            this.ca_approved.FalseValue = "N";
            this.ca_approved.Width = 60;
            // 
            // ca_paid_to_date
            // 
            this.ca_paid_to_date.DataPropertyName = "PaidToDate";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Format = "dd/MM/yy";
            dataGridViewCellStyle6.NullValue = "00/00/00";
            this.ca_paid_to_date.DefaultCellStyle = dataGridViewCellStyle6;
            this.ca_paid_to_date.HeaderText = "Paid to Date";
            this.ca_paid_to_date.IncludeLiterals = false;
            this.ca_paid_to_date.IncludePrompt = false;
            this.ca_paid_to_date.Mask = null;
            this.ca_paid_to_date.Name = "ca_paid_to_date";
            //this.ca_paid_to_date.PromptChar = '\0';
            this.ca_paid_to_date.PromptChar = '_';
            this.ca_paid_to_date.ReadOnly = true;
            this.ca_paid_to_date.ValidatingType = null;
            this.ca_paid_to_date.Width = 70;
            // 
            // ca_notes
            // 
            this.ca_notes.DataPropertyName = "Notes";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.ca_notes.DefaultCellStyle = dataGridViewCellStyle7;
            this.ca_notes.HeaderText = "Notes";
            this.ca_notes.Name = "ca_notes";
            this.ca_notes.Width = 138;
            // 
            // DMaintainROIAllowance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.st_title);
            this.Controls.Add(this.st_protect_confirm);
            this.Name = "DMaintainROIAllowance";
            this.Size = new System.Drawing.Size(570, 252);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
        }

        void grid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // This gets around a problem where the user has entered 
            // an allowance then cleared it and wants to move on.  Without this,
            // the focus would stay in the field without 'saying' anything about why.
        //  if (this.grid.CurrentColumnName == "alt_key")
        //  {
        //      this.grid.CancelEdit();
        //  }
        }

        void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.grid.CurrentColumnName == "ca_paid_to_date")
            {
                //this.grid.EndEdit();
            }
        }

        // TJB RPCR_017 July-2010
        // alt_key_err_count is a hack.  If the user sets the allowance type on the new record
        // then removes it, the 'syste,' still shows it as having the value (presumably the
        // error is that it isn't supposed to have a null value).  This code (grid_DataError)
        // is executed repeatedly waiting for the user to select an acceptable valu - the net
        // effect being that the user cannot tab away from the allowance type field (on the new
        // record).  This hack counts the number of times the user tries to tab away, and when 
        // that number is reached, forces the value to NULL and the 'error' doesn't recur, 
        // allowing the user to change focus away from the field.
        // There may be a better way to do this ...
        //
        // NOTE:
        //   1.  This code assumes the record at row 0 is the new record.  If this is changed
        //       eg the new record is added at the end of the list) the test of the nRow will 
        //       need to be changed.
        //   2.  It is important that the allowance type be set to null.  The system sometimes 
        //       tries to save the added record even when told to delete it.  The insert (of the
        //       new record) fails when the allowance type is null, and this failure is ignored 
        //       the code.  If the Allowance type is non-null, an invalid record may be saved 
        //       to the database.
        private int alt_key_err_count = 0;
        void grid_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            // this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            //  0    this.alt_key,
            //  1    this.ca_effective_date,
            //  2    this.ca_annual_amount,
            //  3    this.ca_approved,
            //  4    this.ca_paid_to_date,
            //  5    this.ca_notes});
            int nRow = e.RowIndex;
            int nCol = e.ColumnIndex;
            if (grid.Rows[nRow].Cells["ca_paid_to_date"].Value != null)
            {
                e.Cancel = true;
            }
            if (nCol == 0)
            {
                if (nRow == 0)
                {
                    alt_key_err_count++;
                    if (grid.Rows[nRow].Cells["alt_key"].Value == null
                        || alt_key_err_count >= 3)
                    {
                        grid.Rows[nRow].Cells["alt_key"].Value = null;
                        //this.grid.CancelEdit();
                        alt_key_err_count = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Allowance type does not pass validation.\n"
                            + "Please enter a valid Allowance."
                            , "Validation Error"
                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
            if (nCol == 1)
            {
                MessageBox.Show("Effective Date does not pass validation.\n"
                        + "Please enter a valid Date."
                        , "Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            if (nCol == 4)
            {
                MessageBox.Show("Paid-to Date does not pass validation.\n"
                        + "Please enter a valid Date."
                        , "Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (e.ColumnIndex == 2)
            {
                MessageBox.Show("Annual Amount does not pass validation.\n"
                        + "Please enter a valid numeric value."
                        , "Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        void set_row_readability()
        {
            int nRows = grid.RowCount;
            for (int i = 0; i < nRows; i++)
            {
                //if(isNull( ca_paid_to_date ) ,0,1)
                if (grid.Rows[i].Cells["ca_paid_to_date"].Value == null)
                {
                    grid.Rows[i].Cells["ca_effective_date"].ReadOnly = false;
                    //grid.Rows[i].Cells["ca_effective_date"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_notes"].ReadOnly = false;
                    grid.Rows[i].Cells["alt_key"].ReadOnly = false;

                    grid.Rows[i].Cells["ca_annual_amount"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = false;
                    //grid.Rows[i].Cells["ca_paid_to_date"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_paid_to_date"].ReadOnly = true;

                }
                else
                {
                    grid.Rows[i].Cells["ca_effective_date"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_notes"].ReadOnly = true;
                    grid.Rows[i].Cells["alt_key"].ReadOnly = true;

                    grid.Rows[i].Cells["ca_annual_amount"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_paid_to_date"].ReadOnly = true;
                }
            }
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (grid.RowCount <= 0)
                return;

            for (int i = 0; i < grid.RowCount; i++)
            {
                //if(isNull( ca_paid_to_date ) ,0,1)
                if (grid.Rows[i].Cells["ca_paid_to_date"].Value == null)
                {
                    grid.Rows[i].Cells["ca_effective_date"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_notes"].ReadOnly = false;
                    grid.Rows[i].Cells["alt_key"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_annual_amount"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_paid_to_date"].ReadOnly = true;

                }
                else
                {
                    grid.Rows[i].Cells["ca_effective_date"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_notes"].ReadOnly = true;
                    grid.Rows[i].Cells["alt_key"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_annual_amount"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_paid_to_date"].ReadOnly = true;
                }

                //if(ca_approved = "Y",1,0)
                if (grid.Rows[i].Cells["ca_approved"].Value != null
                    && grid.Rows[i].Cells["ca_approved"].Value.ToString() == "Y")
                {
                    grid.Rows[i].Cells["ca_annual_amount"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_annual_amount"].Style.BackColor = System.Drawing.SystemColors.Control;
                }
                else
                {
                    grid.Rows[i].Cells["ca_annual_amount"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_annual_amount"].Style.BackColor = System.Drawing.Color.White;
                }

                //if(DESCRIBE("st_protect_confirm.text")="Y", 1, if( isnull(ca_paid_to_date ),0,if(ca_approved = "Y",1,0))) 
                if (this.st_protect_confirm.Text == "Y")
                {
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = true;
                }
                else if (grid.Rows[i].Cells["ca_paid_to_date"].Value == null)
                {
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = false;
                }
                else if (grid.Rows[i].Cells["ca_approved"].Value != null 
                         && grid.Rows[i].Cells["ca_approved"].Value.ToString() == "Y")
                {
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = true;
                }
                else
                {
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = false;
                }
            }
        }
        #endregion
    }
}
