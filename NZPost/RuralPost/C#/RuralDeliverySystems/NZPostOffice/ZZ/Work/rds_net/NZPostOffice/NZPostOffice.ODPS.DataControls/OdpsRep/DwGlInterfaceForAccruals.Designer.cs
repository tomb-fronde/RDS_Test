namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    partial class DwGlInterfaceForAccruals
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn primary_dr_cr_code_11;
        private System.Windows.Forms.DataGridViewTextBoxColumn description_17;
        private System.Windows.Forms.DataGridViewTextBoxColumn transaction_amount_12;
        private System.Windows.Forms.DataGridViewTextBoxColumn account_number_8;
        private System.Windows.Forms.DataGridViewTextBoxColumn line_entity_id_6;
        private System.Windows.Forms.DataGridViewTextBoxColumn journal_sequence_4;
        private System.Windows.Forms.DataGridViewTextBoxColumn journal_line_number_5;
        private System.Windows.Forms.DataGridViewTextBoxColumn analysis_code_10;
        private System.Windows.Forms.DataGridViewTextBoxColumn entity_id_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn misc_cr_dr_code_13;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_code_9;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_created_16;
        private System.Windows.Forms.DataGridViewTextBoxColumn jrnl_user_alpha_fld_15;
        private System.Windows.Forms.DataGridViewTextBoxColumn journal_id_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn misc_amount_14;
        private System.Windows.Forms.DataGridViewTextBoxColumn rc_number_7;
        private System.Windows.Forms.DataGridViewTextBoxColumn effective_date_3;


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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsRep.GlInterfaceForAccruals);

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
            this.grid.ColumnHeadersHeight = 33;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle.BackColor = System.Drawing.Color.White;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
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
            this.grid.BackgroundColor = System.Drawing.Color.White;

            //
            // entity_id_1
            //
            entity_id_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entity_id_1.DataPropertyName = "EntityId1";
            this.entity_id_1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.entity_id_1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.entity_id_1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.entity_id_1.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.entity_id_1.HeaderText = "Entity Id 1";
            this.entity_id_1.Name = "entity_id_1";
            this.entity_id_1.ReadOnly = true;
            this.entity_id_1.Width = 88;
            this.grid.Columns.Add(entity_id_1);


            //
            // journal_id_2
            //
            journal_id_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.journal_id_2.DataPropertyName = "JournalId2";
            this.journal_id_2.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.journal_id_2.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.journal_id_2.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.journal_id_2.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.journal_id_2.HeaderText = "Journal Id 2";
            this.journal_id_2.Name = "journal_id_2";
            this.journal_id_2.ReadOnly = true;
            this.journal_id_2.Width = 100;
            this.grid.Columns.Add(journal_id_2);


            //
            // effective_date_3
            //
            effective_date_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.effective_date_3.DataPropertyName = "EffectiveDate3";
            this.effective_date_3.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.effective_date_3.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.effective_date_3.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.effective_date_3.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.effective_date_3.HeaderText = "Effective Date 3";
            this.effective_date_3.Name = "effective_date_3";
            this.effective_date_3.ReadOnly = true;
            this.effective_date_3.Width = 100;
            this.grid.Columns.Add(effective_date_3);


            //
            // journal_sequence_4
            //
            journal_sequence_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.journal_sequence_4.DataPropertyName = "JournalSequence4";
            this.journal_sequence_4.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.journal_sequence_4.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.journal_sequence_4.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.journal_sequence_4.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.journal_sequence_4.HeaderText = "Journal Sequence 4";
            this.journal_sequence_4.Name = "journal_sequence_4";
            this.journal_sequence_4.ReadOnly = true;
            this.journal_sequence_4.Width = 110;
            this.grid.Columns.Add(journal_sequence_4);


            //
            // journal_line_number_5
            //
            journal_line_number_5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.journal_line_number_5.DataPropertyName = "JournalLineNumber5";
            this.journal_line_number_5.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.journal_line_number_5.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.journal_line_number_5.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.journal_line_number_5.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.journal_line_number_5.HeaderText = "Journal Line Number 5";
            this.journal_line_number_5.Name = "journal_line_number_5";
            this.journal_line_number_5.ReadOnly = true;
            this.journal_line_number_5.Width = 125;
            this.grid.Columns.Add(journal_line_number_5);


            //
            // line_entity_id_6
            //
            line_entity_id_6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line_entity_id_6.DataPropertyName = "LineEntityId6";
            this.line_entity_id_6.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.line_entity_id_6.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.line_entity_id_6.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.line_entity_id_6.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.line_entity_id_6.HeaderText = "Line Entity Id 6";
            this.line_entity_id_6.Name = "line_entity_id_6";
            this.line_entity_id_6.ReadOnly = true;
            this.line_entity_id_6.Width = 87;
            this.grid.Columns.Add(line_entity_id_6);


            //
            // rc_number_7
            //
            rc_number_7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rc_number_7.DataPropertyName = "RcNumber7";
            this.rc_number_7.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rc_number_7.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.rc_number_7.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rc_number_7.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.rc_number_7.HeaderText = "Rc Number 7";
            this.rc_number_7.Name = "rc_number_7";
            this.rc_number_7.ReadOnly = true;
            this.rc_number_7.Width = 88;
            this.grid.Columns.Add(rc_number_7);


            //
            // account_number_8
            //
            account_number_8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.account_number_8.DataPropertyName = "AccountNumber8";
            this.account_number_8.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.account_number_8.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.account_number_8.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.account_number_8.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.account_number_8.HeaderText = "Account Number 8";
            this.account_number_8.Name = "account_number_8";
            this.account_number_8.ReadOnly = true;
            this.account_number_8.Width = 103;
            this.grid.Columns.Add(account_number_8);


            //
            // product_code_9
            //
            product_code_9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_code_9.DataPropertyName = "ProductCode9";
            this.product_code_9.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.product_code_9.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.product_code_9.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.product_code_9.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.product_code_9.HeaderText = "Product Code 9";
            this.product_code_9.Name = "product_code_9";
            this.product_code_9.ReadOnly = true;
            this.product_code_9.Width = 90;
            this.grid.Columns.Add(product_code_9);


            //
            // analysis_code_10
            //
            analysis_code_10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.analysis_code_10.DataPropertyName = "AnalysisCode10";
            this.analysis_code_10.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.analysis_code_10.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.analysis_code_10.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.analysis_code_10.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.analysis_code_10.HeaderText = "Analysis Code 10";
            this.analysis_code_10.Name = "analysis_code_10";
            this.analysis_code_10.ReadOnly = true;
            this.analysis_code_10.Width = 102;
            this.grid.Columns.Add(analysis_code_10);


            //
            // primary_dr_cr_code_11
            //
            primary_dr_cr_code_11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primary_dr_cr_code_11.DataPropertyName = "PrimaryDrCrCode11";
            this.primary_dr_cr_code_11.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.primary_dr_cr_code_11.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.primary_dr_cr_code_11.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.primary_dr_cr_code_11.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.primary_dr_cr_code_11.HeaderText = "Primary Dr Cr Code 11";
            this.primary_dr_cr_code_11.Name = "primary_dr_cr_code_11";
            this.primary_dr_cr_code_11.ReadOnly = true;
            this.primary_dr_cr_code_11.Width = 131;
            this.grid.Columns.Add(primary_dr_cr_code_11);


            //
            // transaction_amount_12
            //
            transaction_amount_12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transaction_amount_12.DataPropertyName = "TransactionAmount12";
            this.transaction_amount_12.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.transaction_amount_12.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.transaction_amount_12.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.transaction_amount_12.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.transaction_amount_12.HeaderText = "Transaction Amount 12";
            this.transaction_amount_12.Name = "transaction_amount_12";
            this.transaction_amount_12.ReadOnly = true;
            this.transaction_amount_12.Width = 134;
            this.grid.Columns.Add(transaction_amount_12);


            //
            // misc_cr_dr_code_13
            //
            misc_cr_dr_code_13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.misc_cr_dr_code_13.DataPropertyName = "MiscCrDrCode13";
            this.misc_cr_dr_code_13.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.misc_cr_dr_code_13.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.misc_cr_dr_code_13.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.misc_cr_dr_code_13.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.misc_cr_dr_code_13.HeaderText = "Misc Cr Dr Code 13";
            this.misc_cr_dr_code_13.Name = "misc_cr_dr_code_13";
            this.misc_cr_dr_code_13.ReadOnly = true;
            this.misc_cr_dr_code_13.Width = 114;
            this.grid.Columns.Add(misc_cr_dr_code_13);


            //
            // misc_amount_14
            //
            misc_amount_14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.misc_amount_14.DataPropertyName = "MiscAmount14";
            this.misc_amount_14.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.misc_amount_14.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.misc_amount_14.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.misc_amount_14.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.misc_amount_14.HeaderText = "Misc Amount 14";
            this.misc_amount_14.Name = "misc_amount_14";
            this.misc_amount_14.ReadOnly = true;
            this.misc_amount_14.Width = 100;
            this.grid.Columns.Add(misc_amount_14);


            //
            // jrnl_user_alpha_fld_15
            //
            jrnl_user_alpha_fld_15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jrnl_user_alpha_fld_15.DataPropertyName = "JrnlUserAlphaFld15";
            this.jrnl_user_alpha_fld_15.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.jrnl_user_alpha_fld_15.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.jrnl_user_alpha_fld_15.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.jrnl_user_alpha_fld_15.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.jrnl_user_alpha_fld_15.HeaderText = "Jrnl User Alpha Fld 15";
            this.jrnl_user_alpha_fld_15.Name = "jrnl_user_alpha_fld_15";
            this.jrnl_user_alpha_fld_15.ReadOnly = true;
            this.jrnl_user_alpha_fld_15.Width = 128;
            this.grid.Columns.Add(jrnl_user_alpha_fld_15);


            //
            // date_created_16
            //
            date_created_16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_created_16.DataPropertyName = "DateCreated16";
            this.date_created_16.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.date_created_16.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.date_created_16.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.date_created_16.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.date_created_16.HeaderText = "Date Created 16";
            this.date_created_16.Name = "date_created_16";
            this.date_created_16.ReadOnly = true;
            this.date_created_16.Width = 94;
            this.grid.Columns.Add(date_created_16);


            //
            // description_17
            //
            description_17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description_17.DataPropertyName = "Description17";
            this.description_17.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.description_17.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.description_17.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.description_17.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.description_17.HeaderText = "Description 17";
            this.description_17.Name = "description_17";
            this.description_17.ReadOnly = true;
            this.description_17.Width = 180;
            this.grid.Columns.Add(description_17);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(grid);
        }
        #endregion

    }
}
