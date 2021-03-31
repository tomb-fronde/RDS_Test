using System;
using System.Windows.Forms;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB Allowances 9-Mar-2021: New

    partial class DMaintainActivityAllowance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.st_title = new System.Windows.Forms.Label();
            this.st_protect_confirm = new System.Windows.Forms.Label();
            this.alt_key = new Metex.Windows.DataGridViewEntityComboColumn();
            this.ca_effective_date = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
            this.ca_var1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt_wks_yr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_annual_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_end_date = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
            this.ca_approved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ca_paid_to_date = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
            this.ca_doc_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.row_changed = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8F);
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
            this.alt_wks_yr,
            this.ca_annual_amount,
            this.ca_end_date,
            this.ca_approved,
            this.ca_paid_to_date,
            this.ca_doc_description,
            this.ca_notes,
            this.row_changed});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.Size = new System.Drawing.Size(901, 252);
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
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.NullValue = null;
            this.alt_key.DefaultCellStyle = dataGridViewCellStyle2;
            this.alt_key.DropDownWidth = 210;
            this.alt_key.HeaderText = "Allowance";
            this.alt_key.Name = "alt_key";
            this.alt_key.Width = 140;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            this.ca_var1.DefaultCellStyle = dataGridViewCellStyle4;
            this.ca_var1.HeaderText = "Count per Wk";
            this.ca_var1.Name = "ca_var1";
            this.ca_var1.Width = 48;
            // 
            // alt_rate
            // 
            this.alt_rate.DataPropertyName = "AltRate";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.alt_rate.DefaultCellStyle = dataGridViewCellStyle5;
            this.alt_rate.HeaderText = "Rate";
            this.alt_rate.Name = "alt_rate";
            this.alt_rate.ReadOnly = true;
            this.alt_rate.Width = 40;
            // 
            // alt_wks_yr
            // 
            this.alt_wks_yr.DataPropertyName = "AltWksYr";
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.alt_wks_yr.DefaultCellStyle = dataGridViewCellStyle6;
            this.alt_wks_yr.HeaderText = "Wks/Yr";
            this.alt_wks_yr.Name = "alt_wks_yr";
            this.alt_wks_yr.ReadOnly = true;
            this.alt_wks_yr.Visible = false;
            this.alt_wks_yr.Width = 40;
            // 
            // ca_annual_amount
            // 
            this.ca_annual_amount.DataPropertyName = "AnnualAmount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Format = "##,###.00";
            dataGridViewCellStyle7.NullValue = ".00";
            this.ca_annual_amount.DefaultCellStyle = dataGridViewCellStyle7;
            this.ca_annual_amount.HeaderText = "Annual Amount";
            this.ca_annual_amount.Name = "ca_annual_amount";
            this.ca_annual_amount.ReadOnly = true;
            this.ca_annual_amount.Width = 60;
            // 
            // ca_end_date
            // 
            this.ca_end_date.DataPropertyName = "EndDate";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Format = "dd/MM/yyyy";
            dataGridViewCellStyle8.NullValue = "00/00/0000";
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_end_date.DefaultCellStyle = dataGridViewCellStyle8;
            this.ca_end_date.HeaderText = "End Date";
            this.ca_end_date.IncludeLiterals = false;
            this.ca_end_date.IncludePrompt = false;
            this.ca_end_date.Mask = null;
            this.ca_end_date.Name = "ca_end_date";
            this.ca_end_date.PromptChar = '\0';
            this.ca_end_date.ValidatingType = null;
            this.ca_end_date.Visible = false;
            this.ca_end_date.Width = 70;
            // 
            // ca_approved
            // 
            this.ca_approved.DataPropertyName = "Approved";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.NullValue = false;
            this.ca_approved.DefaultCellStyle = dataGridViewCellStyle9;
            this.ca_approved.FalseValue = "N";
            this.ca_approved.HeaderText = "Approved";
            this.ca_approved.Name = "ca_approved";
            this.ca_approved.ReadOnly = true;
            this.ca_approved.TrueValue = "Y";
            this.ca_approved.Width = 60;
            // 
            // ca_paid_to_date
            // 
            this.ca_paid_to_date.DataPropertyName = "PaidToDate";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.Format = "dd/MM/yyyy";
            dataGridViewCellStyle10.NullValue = "00/00/0000";
            this.ca_paid_to_date.DefaultCellStyle = dataGridViewCellStyle10;
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
            // ca_doc_description
            // 
            this.ca_doc_description.DataPropertyName = "DocDescription";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ca_doc_description.DefaultCellStyle = dataGridViewCellStyle11;
            this.ca_doc_description.HeaderText = "Doc Description";
            this.ca_doc_description.Name = "ca_doc_description";
            this.ca_doc_description.Width = 120;
            // 
            // ca_notes
            // 
            this.ca_notes.DataPropertyName = "Notes";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            this.ca_notes.DefaultCellStyle = dataGridViewCellStyle12;
            this.ca_notes.HeaderText = "Notes";
            this.ca_notes.Name = "ca_notes";
            this.ca_notes.Width = 138;
            // 
            // row_changed
            // 
            this.row_changed.DataPropertyName = "RowChanged";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            this.row_changed.DefaultCellStyle = dataGridViewCellStyle13;
            this.row_changed.HeaderText = "Row Changed";
            this.row_changed.Name = "row_changed";
            this.row_changed.Visible = false;
            this.row_changed.Width = 20;
            // 
            // DMaintainActivityAllowance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.st_title);
            this.Controls.Add(this.st_protect_confirm);
            this.Name = "DMaintainActivityAllowance";
            this.Size = new System.Drawing.Size(901, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        void grid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // This gets around a problem where the user has entered 
            // an allowance then cleared it and wants to move on.  Without this,
            // the focus would stay in the field without 'saying' anything about why.
        //  if (this.grid.CurrentColumnName == "alt_description")
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
            //  0    this.alt_description,
            //  1    this.activity_count,
            //  2    this.activity_rate,
            //  3    this.ca_annual_amount,
            //  4    this.ca_effective_date,
            //  5    this.ca_approved,
            //  6    this.ca_paid_to_date,
            //  7    this.ca_notes});
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
                            + "Please select a valid Allowance."
                            , "Validation Error"
                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
            if (nCol == 4)
            {
                MessageBox.Show("Effective Date does not pass validation.\n"
                        + "Please enter a valid Date."
                        , "Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            if (nCol == 6)
            {
                MessageBox.Show("Paid-to Date does not pass validation.\n"
                        + "Please enter a valid Date."
                        , "Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (e.ColumnIndex == 3)
            {
                MessageBox.Show("Annual Amount does not pass validation.\n"
                        + "Please enter a valid numeric value."
                        , "Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (e.ColumnIndex == 1)
            {
                MessageBox.Show("Activity Count does not pass validation.\n"
                        + "Please enter a valid numeric value."
                        , "Validation Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (e.ColumnIndex == 3)
            {
                MessageBox.Show("Activity Rate does not pass validation.\n"
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

        private DataGridViewTextBoxColumn activity_count;
        private DataGridViewTextBoxColumn activity_rate;
        private DataGridViewTextBoxColumn wks_per_year;
        private Metex.Windows.DataGridViewEntityComboColumn alt_key;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn ca_effective_date;
        private DataGridViewTextBoxColumn ca_var1;
        private DataGridViewTextBoxColumn alt_rate;
        private DataGridViewTextBoxColumn alt_wks_yr;
        private DataGridViewTextBoxColumn ca_annual_amount;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn ca_end_date;
        private DataGridViewCheckBoxColumn ca_approved;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn ca_paid_to_date;
        private DataGridViewTextBoxColumn ca_doc_description;
        private DataGridViewTextBoxColumn ca_notes;
        private DataGridViewTextBoxColumn row_changed;













    }
}
