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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.st_title = new System.Windows.Forms.Label();
            this.st_protect_confirm = new System.Windows.Forms.Label();
            this.alt_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_effective_date = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
            this.ca_var1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_annual_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.net_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_approved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ca_paid_to_date = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
            this.ca_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_doc_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_row_changed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calc_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.MaintainAllowanceV2);
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
            this.ca_var1,
            this.alt_rate,
            this.ca_annual_amount,
            this.net_amount,
            this.ca_approved,
            this.ca_paid_to_date,
            this.ca_notes,
            this.ca_doc_description,
            this.ca_row_changed,
            this.calc_amount});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.Size = new System.Drawing.Size(880, 291);
            this.grid.TabIndex = 0;
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
            this.alt_key.DataPropertyName = "AltDescription";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.alt_key.DefaultCellStyle = dataGridViewCellStyle2;
            this.alt_key.HeaderText = "Allowance";
            this.alt_key.Name = "alt_key";
            this.alt_key.ReadOnly = true;
            this.alt_key.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.alt_key.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.alt_key.Width = 140;
            // 
            // ca_effective_date
            // 
            this.ca_effective_date.DataPropertyName = "EffectiveDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            dataGridViewCellStyle3.NullValue = "00/00/0000";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_effective_date.DefaultCellStyle = dataGridViewCellStyle3;
            this.ca_effective_date.HeaderText = "Effective Date";
            this.ca_effective_date.IncludeLiterals = false;
            this.ca_effective_date.IncludePrompt = false;
            this.ca_effective_date.Mask = null;
            this.ca_effective_date.Name = "ca_effective_date";
            this.ca_effective_date.PromptChar = '\0';
            this.ca_effective_date.ValidatingType = null;
            this.ca_effective_date.Width = 70;
            // 
            // ca_var1
            // 
            this.ca_var1.DataPropertyName = "CaVar1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Format = "##,###.00";
            dataGridViewCellStyle4.NullValue = "0.00";
            this.ca_var1.DefaultCellStyle = dataGridViewCellStyle4;
            this.ca_var1.HeaderText = "Investment Amount";
            this.ca_var1.Name = "ca_var1";
            this.ca_var1.Width = 64;
            // 
            // alt_rate
            // 
            this.alt_rate.DataPropertyName = "AltRate";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Format = "##,###.00";
            dataGridViewCellStyle5.NullValue = "0.00";
            this.alt_rate.DefaultCellStyle = dataGridViewCellStyle5;
            this.alt_rate.HeaderText = "ROI%";
            this.alt_rate.Name = "alt_rate";
            this.alt_rate.ReadOnly = true;
            this.alt_rate.Width = 50;
            // 
            // ca_annual_amount
            // 
            this.ca_annual_amount.DataPropertyName = "AnnualAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.Format = "$#,##0.00;$-#,##0.00";
            dataGridViewCellStyle6.NullValue = "0.00";
            this.ca_annual_amount.DefaultCellStyle = dataGridViewCellStyle6;
            this.ca_annual_amount.HeaderText = "Annual Amount";
            this.ca_annual_amount.Name = "ca_annual_amount";
            this.ca_annual_amount.ReadOnly = true;
            this.ca_annual_amount.Width = 73;
            // 
            // net_amount
            // 
            this.net_amount.DataPropertyName = "NetAmount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Format = "$#,##0.00;$-#,##0.00";
            dataGridViewCellStyle7.NullValue = "0.00";
            this.net_amount.DefaultCellStyle = dataGridViewCellStyle7;
            this.net_amount.HeaderText = "   Net Amount";
            this.net_amount.Name = "net_amount";
            this.net_amount.ReadOnly = true;
            this.net_amount.Width = 73;
            // 
            // ca_approved
            // 
            this.ca_approved.DataPropertyName = "Approved";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.NullValue = "false";
            this.ca_approved.DefaultCellStyle = dataGridViewCellStyle8;
            this.ca_approved.FalseValue = "N";
            this.ca_approved.HeaderText = "Approved";
            this.ca_approved.Name = "ca_approved";
            this.ca_approved.TrueValue = "Y";
            this.ca_approved.Width = 60;
            // 
            // ca_paid_to_date
            // 
            this.ca_paid_to_date.DataPropertyName = "PaidToDate";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.Format = "dd/MM/yy";
            dataGridViewCellStyle9.NullValue = "00/00/00";
            this.ca_paid_to_date.DefaultCellStyle = dataGridViewCellStyle9;
            this.ca_paid_to_date.HeaderText = "Paid to Date";
            this.ca_paid_to_date.IncludeLiterals = false;
            this.ca_paid_to_date.IncludePrompt = false;
            this.ca_paid_to_date.Mask = null;
            this.ca_paid_to_date.Name = "ca_paid_to_date";
            this.ca_paid_to_date.PromptChar = '\0';
            this.ca_paid_to_date.ReadOnly = true;
            this.ca_paid_to_date.ValidatingType = null;
            this.ca_paid_to_date.Width = 70;
            // 
            // ca_notes
            // 
            this.ca_notes.DataPropertyName = "Notes";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ca_notes.DefaultCellStyle = dataGridViewCellStyle10;
            this.ca_notes.HeaderText = "Notes";
            this.ca_notes.Name = "ca_notes";
            this.ca_notes.Width = 120;
            // 
            // ca_doc_description
            // 
            this.ca_doc_description.DataPropertyName = "DocDescription";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.NullValue = null;
            this.ca_doc_description.DefaultCellStyle = dataGridViewCellStyle11;
            this.ca_doc_description.HeaderText = "Doc Description";
            this.ca_doc_description.Name = "ca_doc_description";
            this.ca_doc_description.Width = 140;
            // 
            // ca_row_changed
            // 
            this.ca_row_changed.DataPropertyName = "RowChanged";
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ca_row_changed.DefaultCellStyle = dataGridViewCellStyle12;
            this.ca_row_changed.HeaderText = "Row Changed";
            this.ca_row_changed.Name = "ca_row_changed";
            this.ca_row_changed.Visible = false;
            this.ca_row_changed.Width = 20;
            // 
            // calc_amount
            // 
            this.calc_amount.DataPropertyName = "CalcAmount";
            this.calc_amount.HeaderText = "CalcAmount";
            this.calc_amount.Name = "calc_amount";
            this.calc_amount.Visible = false;
            this.calc_amount.Width = 50;
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
            this.Size = new System.Drawing.Size(880, 291);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        // TJB 19-June-2021: Disabled; may want to t5ab over "required" fields without
        // being told to provide a value, especially during transition to calculated
        // annual amounts.
        void grid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // This gets around a problem where the user has entered one of the
            // fields then cleared it and wants to move on.  Without this,
            // the focus would stay in the field without 'saying' anything about why.
            string column;
            column = this.grid.CurrentColumnName;
            int nRow = this.grid.CurrentCell.RowIndex;
            string row_changed = (string)this.grid.Rows[nRow].Cells["ca_row_changed"].Value;
            if (column == "ca_effective_date" || column == "ca_var1" || column == "alt_key")
            {
                object alt_key = this.grid.Rows[nRow].Cells["alt_key"].Value;
                object value1 = this.grid.CurrentCell.EditedFormattedValue;
                if ((value1 == null || (string)value1 == "") && (alt_key != null))
                {
                    // When a new record is created, row_changed for the row it was 
                    // generated from is set to 'Y' (it is set to 'X' in the new row itself)
                    // grid_validating is called twice - once for the new row and once for 
                    // the row the new one was generated from.  That row may be from the 
                    // time when allowance calculations were done offline and it may not 
                    // (legitimately) have any calculation factors (ca_var1 in particular).
                    // This check here avoids a warning message in those cases.
                    if (row_changed != "Y")
                    {
                        string column_type = "";
                        if (column == "ca_effective_date") column_type = "effective date";
                        else if (column == "ca_var1") column_type = "investment amount";
                        else if (column == "alt_key") column_type = "allowance type";
                        MessageBox.Show("    Please enter an " + column_type + " value.    ", ""
                                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // SetGridCellFocus(int pRow, string pColumnName, bool pValue
                        SetGridCellFocus(nRow, column, true);
                    }
                }
            }
            // row_changed set to 'Y' is used here to set the previous row readonly
            // It is placed here because the column identified may not be one of those
            // identified above.
            if (row_changed == "Y")
            {
                // Put row_changed back to the default 'not changed' ('X')
                this.grid.Rows[nRow].Cells["ca_row_changed"].Value = "X";
                if (!(this.grid.Rows[nRow].Cells["ca_effective_date"].ReadOnly))
                    set_row_readonly(nRow, true);
            }
        }

        public void set_row_readonly(int pRow, bool pValue)
        {
            System.Drawing.Color ReadonlyColour, ReadWriteColour;
            ReadonlyColour = System.Drawing.SystemColors.Control;
            ReadWriteColour = System.Drawing.SystemColors.Window;

            if (pValue == true)
            {
                for (int i = 0; i < this.grid.ColumnCount; i++)
                {
                    this.grid.Rows[pRow].Cells[i].ReadOnly = pValue;
                    this.grid.Rows[pRow].Cells[i].Style.BackColor = ReadonlyColour;
                }
            }
            if (pValue == false)
            {
                this.grid.Rows[pRow].Cells["alt_key"].ReadOnly = true;
                this.grid.Rows[pRow].Cells["alt_key"].Style.BackColor = ReadonlyColour;
                this.grid.Rows[pRow].Cells["alt_rate"].ReadOnly = true;
                this.grid.Rows[pRow].Cells["alt_rate"].Style.BackColor = ReadonlyColour;
                this.grid.Rows[pRow].Cells["ca_annual_amount"].ReadOnly = true;
                this.grid.Rows[pRow].Cells["ca_annual_amount"].Style.BackColor = ReadonlyColour;
                this.grid.Rows[pRow].Cells["net_amount"].ReadOnly = true;
                this.grid.Rows[pRow].Cells["net_amount"].Style.BackColor = ReadonlyColour;
                this.grid.Rows[pRow].Cells["ca_paid_to_date"].ReadOnly = true;
                this.grid.Rows[pRow].Cells["ca_paid_to_date"].Style.BackColor = ReadonlyColour;

                this.grid.Rows[pRow].Cells["ca_effective_date"].ReadOnly = false;
                this.grid.Rows[pRow].Cells["ca_effective_date"].Style.BackColor = ReadWriteColour;
                this.grid.Rows[pRow].Cells["ca_var1"].ReadOnly = false;
                this.grid.Rows[pRow].Cells["ca_var1"].Style.BackColor = ReadWriteColour;
                this.grid.Rows[pRow].Cells["ca_approved"].ReadOnly = false;
                this.grid.Rows[pRow].Cells["ca_approved"].Style.BackColor = ReadWriteColour;
                this.grid.Rows[pRow].Cells["ca_notes"].ReadOnly = false;
                this.grid.Rows[pRow].Cells["ca_notes"].Style.BackColor = ReadWriteColour;
                this.grid.Rows[pRow].Cells["ca_doc_description"].ReadOnly = false;
                this.grid.Rows[pRow].Cells["ca_doc_description"].Style.BackColor = ReadWriteColour;
            }
        }

        void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.grid.CurrentColumnName == "ca_paid_to_date")
            {
                //this.grid.EndEdit();
            }
        }

        private string stringValue(string value)
        {
            if (value == null)
                return "null";
            else if (value == "")
                return "empty";
            return value;
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
            //   0   this.alt_key,
            //   1   this.ca_effective_date,
            //   2   this.ca_var1      (investment amount)
            //   3   this.alt_rate     (roi%)
            //   4   this.ca_annual_amount,
            //   5   this.ca_approved,
            //   6   this.ca_paid_to_date,
            //   7   this.ca_doc_description,
            //   8   this.ca_notes
            //   9   this.ca_row_changed
            int nRow = e.RowIndex;
            int nCol = e.ColumnIndex;
            string column = grid.CurrentColumnName;
            string sAllowance = (string)grid.Rows[nRow].Cells["alt_key"].EditedFormattedValue;
            string sValue = (string)((DataGridView)sender).CurrentCell.EditedFormattedValue;
            sAllowance = stringValue(sAllowance);
            sValue = stringValue(sValue);

            if (grid.Rows[nRow].Cells["ca_paid_to_date"].Value != null)
            {
                e.Cancel = true;
            }
            if (column == "alt_key")
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
                    MessageBox.Show("Allowance type '" + sAllowance + "' does not pass validation.\n"
                            + "Please enter a valid Allowance."
                            , "ROI Allowance Validation Error"
                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
            else if (column == "ca_effective_date")
            {
                MessageBox.Show("Effective Date does not pass validation.\n"
                        + "Allowance type '" + sAllowance + "'\n"
                        + "Value " + sValue + "\n"
                        + "Please enter a valid Date."
                        , "ROI Allowance Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (column == "ca_var1")
            {
                MessageBox.Show("Investment Ammount does not pass validation.\n"
                        + "Allowance type '" + sAllowance + "'\n"
                        + "Value " + sValue + "\n"
                        + "Please enter a valid numeric value."
                        , "ROI Allowance Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (column == "ca_annual_amount")
            {
                MessageBox.Show("Annual Amount does not pass validation.\n"
                        + "Allowance type '" + sAllowance + "'\n"
                        + "Value " + sValue + "\n"
                        + "Please correct."
                        , "ROI Allowance Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        void set_row_readability()
        {
            int nRows = grid.RowCount;
            for (int i = 0; i < nRows; i++)
            {
                if (grid.Rows[i].Cells["ca_paid_to_date"].Value == null)
                {
                    grid.Rows[i].Cells["ca_var1"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_var1"].Style.BackColor = System.Drawing.SystemColors.Window; // Not Readonly = white
                    grid.Rows[i].Cells["ca_effective_date"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_effective_date"].Style.BackColor = System.Drawing.SystemColors.Window;
                    grid.Rows[i].Cells["ca_notes"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_notes"].Style.BackColor = System.Drawing.SystemColors.Window;
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_approved"].Style.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    grid.Rows[i].Cells["ca_var1"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_var1"].Style.BackColor = System.Drawing.SystemColors.Control; // Readonly = Grey
                    grid.Rows[i].Cells["ca_effective_date"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_effective_date"].Style.BackColor = System.Drawing.SystemColors.Control;
                    grid.Rows[i].Cells["ca_notes"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_notes"].Style.BackColor = System.Drawing.SystemColors.Control;
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_approved"].Style.BackColor = System.Drawing.SystemColors.Control;
                }

                grid.Rows[i].Cells["alt_key"].ReadOnly = true;
                grid.Rows[i].Cells["alt_key"].Style.BackColor = System.Drawing.SystemColors.Control; // Readonly = Grey
                grid.Rows[i].Cells["ca_paid_to_date"].ReadOnly = true;
                grid.Rows[i].Cells["ca_paid_to_date"].Style.BackColor = System.Drawing.SystemColors.Control; // Readonly = Grey
            }
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (grid.RowCount <= 0)
                return;

            for (int i = 0; i < grid.RowCount; i++)
            {
                if (grid.Rows[i].Cells["ca_paid_to_date"].Value == null)
                {
                    grid.Rows[i].Cells["ca_var1"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_var1"].Style.BackColor = System.Drawing.SystemColors.Window; // Not Readonly = white
                    grid.Rows[i].Cells["ca_effective_date"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_effective_date"].Style.BackColor = System.Drawing.SystemColors.Window;
                    grid.Rows[i].Cells["ca_notes"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_notes"].Style.BackColor = System.Drawing.SystemColors.Window;
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_approved"].Style.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    grid.Rows[i].Cells["ca_var1"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_var1"].Style.BackColor = System.Drawing.SystemColors.Control; // Readonly = Grey
                    grid.Rows[i].Cells["ca_effective_date"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_effective_date"].Style.BackColor = System.Drawing.SystemColors.Control;
                    grid.Rows[i].Cells["ca_notes"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_notes"].Style.BackColor = System.Drawing.SystemColors.Control;
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_approved"].Style.BackColor = System.Drawing.SystemColors.Control;
                }

                grid.Rows[i].Cells["alt_key"].ReadOnly = true;
                grid.Rows[i].Cells["alt_key"].Style.BackColor = System.Drawing.SystemColors.Control; // Readonly = Grey
                grid.Rows[i].Cells["ca_paid_to_date"].ReadOnly = true;
                grid.Rows[i].Cells["ca_paid_to_date"].Style.BackColor = System.Drawing.SystemColors.Control; // Readonly = Grey

                if (grid.Rows[i].Cells["ca_approved"].Value != null
                    && grid.Rows[i].Cells["ca_approved"].Value.ToString() == "Y")
                {
                    grid.Rows[i].Cells["ca_annual_amount"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_annual_amount"].Style.BackColor = System.Drawing.SystemColors.Control;
                }
                else
                {
                    grid.Rows[i].Cells["ca_annual_amount"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_annual_amount"].Style.BackColor = System.Drawing.SystemColors.Window;
                }

                if (this.st_protect_confirm.Text == "Y")
                {
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_approved"].Style.BackColor = System.Drawing.SystemColors.Control;
                }
                else if (grid.Rows[i].Cells["ca_paid_to_date"].Value == null)
                {
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_approved"].Style.BackColor = System.Drawing.SystemColors.Window;
                }
                else if (grid.Rows[i].Cells["ca_approved"].Value != null 
                         && grid.Rows[i].Cells["ca_approved"].Value.ToString() == "Y")
                {
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_approved"].Style.BackColor = System.Drawing.SystemColors.Control;
                }
                else
                {
                    grid.Rows[i].Cells["ca_approved"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_approved"].Style.BackColor = System.Drawing.SystemColors.Window;
                }
            }
        }
        #endregion

        private DataGridViewTextBoxColumn alt_key;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn ca_effective_date;
        private DataGridViewTextBoxColumn ca_var1;
        private DataGridViewTextBoxColumn alt_rate;
        private DataGridViewTextBoxColumn ca_annual_amount;
        private DataGridViewTextBoxColumn net_amount;
        private DataGridViewCheckBoxColumn ca_approved;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn ca_paid_to_date;
        private DataGridViewTextBoxColumn ca_notes;
        private DataGridViewTextBoxColumn ca_doc_description;
        private DataGridViewTextBoxColumn ca_row_changed;
        private DataGridViewTextBoxColumn calc_amount;























    }
}
