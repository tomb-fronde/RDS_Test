using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.OdpsPayrun;

namespace NZPostOffice.ODPS.DataControls.OdpsPayrun
{
    partial class DwPostTaxDeductions
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

        private System.Windows.Forms.TextBox ded_percent_start_balance;
        private System.Windows.Forms.TextBox ded_end_balance;
        private Metex.Windows.DataEntityCombo pct_id;
        private System.Windows.Forms.TextBox ded_id;
        private System.Windows.Forms.Label ded_percent_gross_t;
        private System.Windows.Forms.TextBox ded_max_threshold_net_pct;
        private System.Windows.Forms.Label ded_percent_net_t;
        private System.Windows.Forms.TextBox ded_percent_net;
        private System.Windows.Forms.Label ded_percent_start_balance_t;
        private System.Windows.Forms.TextBox ded_fixed_amount;
        private System.Windows.Forms.TextBox ded_min_threshold_gross;
        private System.Windows.Forms.TextBox ded_percent_gross;
        private System.Windows.Forms.Label ded_reference_t;
        private System.Windows.Forms.CheckBox ded_pay_highest_value;
        private System.Windows.Forms.Label pct_id_t;
        private System.Windows.Forms.Label ded_priority_t;
        private System.Windows.Forms.Label ded_min_threshold_gross_t;
        private System.Windows.Forms.Label ded_default_minimum_t;
        private System.Windows.Forms.Label ded_end_balance_t;
        private System.Windows.Forms.Label ded_start_balance_t;
        private System.Windows.Forms.RichTextBox t_posttax_deductions_not_applied_comment;
        private System.Windows.Forms.TextBox t_posttax_deductions_not_applied_invoice;
        private System.Windows.Forms.TextBox ded_reference;
        private System.Windows.Forms.Label ded_description_t;
        private System.Windows.Forms.MaskedTextBox ded_priority;
        private System.Windows.Forms.TextBox ded_start_balance;
        private System.Windows.Forms.Label ded_fixed_amount_t;
        private System.Windows.Forms.TextBox ded_description;
        private System.Windows.Forms.TextBox ded_default_minimum;
        private System.Windows.Forms.Label ded_type_period_t;
        private System.Windows.Forms.Label ded_max_threshold_net_pct_t;
        private System.Windows.Forms.Label t_1;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.t_posttax_deductions_not_applied_invoice = new System.Windows.Forms.TextBox();
            this.ded_description_t = new System.Windows.Forms.Label();
            this.ded_description = new System.Windows.Forms.TextBox();
            this.ded_id = new System.Windows.Forms.TextBox();
            this.pct_id_t = new System.Windows.Forms.Label();
            this.pct_id = new Metex.Windows.DataEntityCombo();
            this.ded_priority_t = new System.Windows.Forms.Label();
            this.ded_priority = new System.Windows.Forms.MaskedTextBox();
            this.ded_reference_t = new System.Windows.Forms.Label();
            this.ded_reference = new System.Windows.Forms.TextBox();
            this.ded_type_period_t = new System.Windows.Forms.Label();
            this.ded_start_balance_t = new System.Windows.Forms.Label();
            this.ded_start_balance = new System.Windows.Forms.TextBox();
            this.ded_end_balance_t = new System.Windows.Forms.Label();
            this.ded_end_balance = new System.Windows.Forms.TextBox();
            this.ded_pay_highest_value = new System.Windows.Forms.CheckBox();
            this.ded_percent_gross_t = new System.Windows.Forms.Label();
            this.ded_percent_net_t = new System.Windows.Forms.Label();
            this.ded_fixed_amount_t = new System.Windows.Forms.Label();
            this.ded_percent_start_balance_t = new System.Windows.Forms.Label();
            this.ded_default_minimum_t = new System.Windows.Forms.Label();
            this.ded_percent_gross = new System.Windows.Forms.TextBox();
            this.ded_percent_net = new System.Windows.Forms.TextBox();
            this.ded_fixed_amount = new System.Windows.Forms.TextBox();
            this.ded_percent_start_balance = new System.Windows.Forms.TextBox();
            this.ded_default_minimum = new System.Windows.Forms.TextBox();
            this.ded_min_threshold_gross_t = new System.Windows.Forms.Label();
            this.ded_min_threshold_gross = new System.Windows.Forms.TextBox();
            this.ded_max_threshold_net_pct_t = new System.Windows.Forms.Label();
            this.ded_max_threshold_net_pct = new System.Windows.Forms.TextBox();
            this.t_posttax_deductions_not_applied_comment = new System.Windows.Forms.RichTextBox();
            this.ded_type_period = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.t_1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsPayrun.PostTaxDeductions);
            // 
            // t_posttax_deductions_not_applied_invoice
            // 
            this.t_posttax_deductions_not_applied_invoice.BackColor = System.Drawing.SystemColors.Window;
            this.t_posttax_deductions_not_applied_invoice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.t_posttax_deductions_not_applied_invoice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "TPosttaxDeductionsNotAppliedInvoice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.t_posttax_deductions_not_applied_invoice.Font = new System.Drawing.Font("Arial", 8F);
            this.t_posttax_deductions_not_applied_invoice.ForeColor = System.Drawing.Color.Black;
            this.t_posttax_deductions_not_applied_invoice.Location = new System.Drawing.Point(115, 258);
            this.t_posttax_deductions_not_applied_invoice.MaxLength = 0;
            this.t_posttax_deductions_not_applied_invoice.Name = "t_posttax_deductions_not_applied_invoice";
            this.t_posttax_deductions_not_applied_invoice.Size = new System.Drawing.Size(216, 13);
            this.t_posttax_deductions_not_applied_invoice.TabIndex = 10;
            // 
            // ded_description_t
            // 
            this.ded_description_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_description_t.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_description_t.ForeColor = System.Drawing.Color.Black;
            this.ded_description_t.Location = new System.Drawing.Point(3, 4);
            this.ded_description_t.Name = "ded_description_t";
            this.ded_description_t.Size = new System.Drawing.Size(66, 14);
            this.ded_description_t.TabIndex = 11;
            this.ded_description_t.Text = "Description:";
            this.ded_description_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ded_description
            // 
            this.ded_description.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ded_description.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_description.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_description.ForeColor = System.Drawing.Color.Black;
            this.ded_description.Location = new System.Drawing.Point(118, 3);
            this.ded_description.MaxLength = 10;
            this.ded_description.Name = "ded_description";
            this.ded_description.ReadOnly = true;
            this.ded_description.Size = new System.Drawing.Size(333, 13);
            this.ded_description.TabIndex = 12;
            // 
            // ded_id
            // 
            this.ded_id.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ded_id.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_id.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.ded_id.ForeColor = System.Drawing.Color.Black;
            this.ded_id.Location = new System.Drawing.Point(495, 3);
            this.ded_id.MaxLength = 0;
            this.ded_id.Name = "ded_id";
            this.ded_id.ReadOnly = true;
            this.ded_id.Size = new System.Drawing.Size(46, 13);
            this.ded_id.TabIndex = 13;
            this.ded_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pct_id_t
            // 
            this.pct_id_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pct_id_t.Font = new System.Drawing.Font("Arial", 8F);
            this.pct_id_t.ForeColor = System.Drawing.Color.Black;
            this.pct_id_t.Location = new System.Drawing.Point(-10, 27);
            this.pct_id_t.Name = "pct_id_t";
            this.pct_id_t.Size = new System.Drawing.Size(126, 15);
            this.pct_id_t.TabIndex = 14;
            this.pct_id_t.Text = "Pay Component Type:";
            this.pct_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pct_id
            // 
            this.pct_id.AutoRetrieve = true;
            this.pct_id.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pct_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "PctId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pct_id.DisplayMember = "PctDescription";
            this.pct_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pct_id.DropDownWidth = 200;
            this.pct_id.Font = new System.Drawing.Font("Arial", 8F);
            this.pct_id.ForeColor = System.Drawing.Color.Black;
            this.pct_id.Location = new System.Drawing.Point(118, 27);
            this.pct_id.Name = "pct_id";
            this.pct_id.Size = new System.Drawing.Size(200, 22);
            this.pct_id.TabIndex = 32766;
            this.pct_id.Value = null;
            this.pct_id.ValueMember = "PctId";
            // 
            // ded_priority_t
            // 
            this.ded_priority_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_priority_t.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_priority_t.ForeColor = System.Drawing.Color.Black;
            this.ded_priority_t.Location = new System.Drawing.Point(370, 28);
            this.ded_priority_t.Name = "ded_priority_t";
            this.ded_priority_t.Size = new System.Drawing.Size(43, 15);
            this.ded_priority_t.TabIndex = 32767;
            this.ded_priority_t.Text = "Priority:";
            this.ded_priority_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ded_priority
            // 
            this.ded_priority.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_priority.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ded_priority.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedPriority", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_priority.Location = new System.Drawing.Point(419, 27);
            this.ded_priority.Name = "ded_priority";
            this.ded_priority.ReadOnly = true;
            this.ded_priority.Size = new System.Drawing.Size(31, 13);
            this.ded_priority.TabIndex = 32768;
            // 
            // ded_reference_t
            // 
            this.ded_reference_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_reference_t.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_reference_t.ForeColor = System.Drawing.Color.Black;
            this.ded_reference_t.Location = new System.Drawing.Point(3, 50);
            this.ded_reference_t.Name = "ded_reference_t";
            this.ded_reference_t.Size = new System.Drawing.Size(63, 15);
            this.ded_reference_t.TabIndex = 32769;
            this.ded_reference_t.Text = "Reference:";
            this.ded_reference_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ded_reference
            // 
            this.ded_reference.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_reference.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ded_reference.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedReference", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_reference.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_reference.ForeColor = System.Drawing.Color.Black;
            this.ded_reference.Location = new System.Drawing.Point(118, 50);
            this.ded_reference.MaxLength = 200;
            this.ded_reference.Name = "ded_reference";
            this.ded_reference.ReadOnly = true;
            this.ded_reference.Size = new System.Drawing.Size(333, 13);
            this.ded_reference.TabIndex = 32770;
            // 
            // ded_type_period_t
            // 
            this.ded_type_period_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_type_period_t.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_type_period_t.ForeColor = System.Drawing.Color.Black;
            this.ded_type_period_t.Location = new System.Drawing.Point(3, 72);
            this.ded_type_period_t.Name = "ded_type_period_t";
            this.ded_type_period_t.Size = new System.Drawing.Size(71, 14);
            this.ded_type_period_t.TabIndex = 32771;
            this.ded_type_period_t.Text = "Period Type:";
            this.ded_type_period_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ded_start_balance_t
            // 
            this.ded_start_balance_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_start_balance_t.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_start_balance_t.ForeColor = System.Drawing.Color.Black;
            this.ded_start_balance_t.Location = new System.Drawing.Point(3, 93);
            this.ded_start_balance_t.Name = "ded_start_balance_t";
            this.ded_start_balance_t.Size = new System.Drawing.Size(74, 15);
            this.ded_start_balance_t.TabIndex = 32772;
            this.ded_start_balance_t.Text = "Total Amount:";
            this.ded_start_balance_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ded_start_balance
            // 
            this.ded_start_balance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_start_balance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ded_start_balance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedStartBalance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_start_balance.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_start_balance.ForeColor = System.Drawing.Color.Black;
            this.ded_start_balance.Location = new System.Drawing.Point(117, 95);
            this.ded_start_balance.MaxLength = 0;
            this.ded_start_balance.Name = "ded_start_balance";
            this.ded_start_balance.ReadOnly = true;
            this.ded_start_balance.Size = new System.Drawing.Size(65, 13);
            this.ded_start_balance.TabIndex = 32773;
            this.ded_start_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ded_end_balance_t
            // 
            this.ded_end_balance_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_end_balance_t.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_end_balance_t.ForeColor = System.Drawing.Color.Black;
            this.ded_end_balance_t.Location = new System.Drawing.Point(307, 96);
            this.ded_end_balance_t.Name = "ded_end_balance_t";
            this.ded_end_balance_t.Size = new System.Drawing.Size(77, 15);
            this.ded_end_balance_t.TabIndex = 32774;
            this.ded_end_balance_t.Text = "Ending Balance:";
            this.ded_end_balance_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ded_end_balance
            // 
            this.ded_end_balance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_end_balance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ded_end_balance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedEndBalance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_end_balance.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_end_balance.ForeColor = System.Drawing.Color.Black;
            this.ded_end_balance.Location = new System.Drawing.Point(391, 95);
            this.ded_end_balance.MaxLength = 0;
            this.ded_end_balance.Name = "ded_end_balance";
            this.ded_end_balance.ReadOnly = true;
            this.ded_end_balance.Size = new System.Drawing.Size(60, 13);
            this.ded_end_balance.TabIndex = 32775;
            this.ded_end_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ded_pay_highest_value
            // 
            this.ded_pay_highest_value.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_pay_highest_value.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "DedPayHighestValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_pay_highest_value.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_pay_highest_value.ForeColor = System.Drawing.Color.Black;
            this.ded_pay_highest_value.Location = new System.Drawing.Point(13, 124);
            this.ded_pay_highest_value.Name = "ded_pay_highest_value";
            this.ded_pay_highest_value.Size = new System.Drawing.Size(103, 32);
            this.ded_pay_highest_value.TabIndex = 32766;
            this.ded_pay_highest_value.Text = "Pay highest value";
            this.ded_pay_highest_value.UseVisualStyleBackColor = false;
            // 
            // ded_percent_gross_t
            // 
            this.ded_percent_gross_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_percent_gross_t.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_percent_gross_t.ForeColor = System.Drawing.Color.Black;
            this.ded_percent_gross_t.Location = new System.Drawing.Point(122, 124);
            this.ded_percent_gross_t.Name = "ded_percent_gross_t";
            this.ded_percent_gross_t.Size = new System.Drawing.Size(53, 14);
            this.ded_percent_gross_t.TabIndex = 32776;
            this.ded_percent_gross_t.Text = "%of Gross";
            this.ded_percent_gross_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ded_percent_net_t
            // 
            this.ded_percent_net_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_percent_net_t.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_percent_net_t.ForeColor = System.Drawing.Color.Black;
            this.ded_percent_net_t.Location = new System.Drawing.Point(196, 126);
            this.ded_percent_net_t.Name = "ded_percent_net_t";
            this.ded_percent_net_t.Size = new System.Drawing.Size(42, 14);
            this.ded_percent_net_t.TabIndex = 32777;
            this.ded_percent_net_t.Text = "% of Net";
            this.ded_percent_net_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ded_fixed_amount_t
            // 
            this.ded_fixed_amount_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_fixed_amount_t.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_fixed_amount_t.ForeColor = System.Drawing.Color.Black;
            this.ded_fixed_amount_t.Location = new System.Drawing.Point(255, 126);
            this.ded_fixed_amount_t.Name = "ded_fixed_amount_t";
            this.ded_fixed_amount_t.Size = new System.Drawing.Size(66, 14);
            this.ded_fixed_amount_t.TabIndex = 32778;
            this.ded_fixed_amount_t.Text = "Fixed Amount";
            this.ded_fixed_amount_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ded_percent_start_balance_t
            // 
            this.ded_percent_start_balance_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_percent_start_balance_t.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_percent_start_balance_t.ForeColor = System.Drawing.Color.Black;
            this.ded_percent_start_balance_t.Location = new System.Drawing.Point(332, 127);
            this.ded_percent_start_balance_t.Name = "ded_percent_start_balance_t";
            this.ded_percent_start_balance_t.Size = new System.Drawing.Size(89, 14);
            this.ded_percent_start_balance_t.TabIndex = 32779;
            this.ded_percent_start_balance_t.Text = "% of Total Amount";
            this.ded_percent_start_balance_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ded_default_minimum_t
            // 
            this.ded_default_minimum_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_default_minimum_t.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_default_minimum_t.ForeColor = System.Drawing.Color.Black;
            this.ded_default_minimum_t.Location = new System.Drawing.Point(433, 126);
            this.ded_default_minimum_t.Name = "ded_default_minimum_t";
            this.ded_default_minimum_t.Size = new System.Drawing.Size(93, 14);
            this.ded_default_minimum_t.TabIndex = 32780;
            this.ded_default_minimum_t.Text = "Default Min Amount";
            this.ded_default_minimum_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ded_percent_gross
            // 
            this.ded_percent_gross.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_percent_gross.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ded_percent_gross.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedPercentGross", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_percent_gross.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_percent_gross.ForeColor = System.Drawing.Color.Black;
            this.ded_percent_gross.Location = new System.Drawing.Point(119, 145);
            this.ded_percent_gross.MaxLength = 0;
            this.ded_percent_gross.Name = "ded_percent_gross";
            this.ded_percent_gross.ReadOnly = true;
            this.ded_percent_gross.Size = new System.Drawing.Size(60, 13);
            this.ded_percent_gross.TabIndex = 32781;
            this.ded_percent_gross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ded_percent_net
            // 
            this.ded_percent_net.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_percent_net.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ded_percent_net.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedPercentNet", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_percent_net.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_percent_net.ForeColor = System.Drawing.Color.Black;
            this.ded_percent_net.Location = new System.Drawing.Point(188, 145);
            this.ded_percent_net.MaxLength = 0;
            this.ded_percent_net.Name = "ded_percent_net";
            this.ded_percent_net.ReadOnly = true;
            this.ded_percent_net.Size = new System.Drawing.Size(60, 13);
            this.ded_percent_net.TabIndex = 32782;
            this.ded_percent_net.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ded_fixed_amount
            // 
            this.ded_fixed_amount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_fixed_amount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ded_fixed_amount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedFixedAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_fixed_amount.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_fixed_amount.ForeColor = System.Drawing.Color.Black;
            this.ded_fixed_amount.Location = new System.Drawing.Point(260, 145);
            this.ded_fixed_amount.MaxLength = 0;
            this.ded_fixed_amount.Name = "ded_fixed_amount";
            this.ded_fixed_amount.ReadOnly = true;
            this.ded_fixed_amount.Size = new System.Drawing.Size(60, 13);
            this.ded_fixed_amount.TabIndex = 32783;
            this.ded_fixed_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ded_percent_start_balance
            // 
            this.ded_percent_start_balance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_percent_start_balance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ded_percent_start_balance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedPercentStartBalance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_percent_start_balance.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_percent_start_balance.ForeColor = System.Drawing.Color.Black;
            this.ded_percent_start_balance.Location = new System.Drawing.Point(343, 145);
            this.ded_percent_start_balance.MaxLength = 0;
            this.ded_percent_start_balance.Name = "ded_percent_start_balance";
            this.ded_percent_start_balance.ReadOnly = true;
            this.ded_percent_start_balance.Size = new System.Drawing.Size(60, 13);
            this.ded_percent_start_balance.TabIndex = 32784;
            this.ded_percent_start_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ded_default_minimum
            // 
            this.ded_default_minimum.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_default_minimum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ded_default_minimum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedDefaultMinimum", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_default_minimum.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_default_minimum.ForeColor = System.Drawing.Color.Black;
            this.ded_default_minimum.Location = new System.Drawing.Point(453, 145);
            this.ded_default_minimum.MaxLength = 0;
            this.ded_default_minimum.Name = "ded_default_minimum";
            this.ded_default_minimum.ReadOnly = true;
            this.ded_default_minimum.Size = new System.Drawing.Size(60, 13);
            this.ded_default_minimum.TabIndex = 32785;
            this.ded_default_minimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ded_min_threshold_gross_t
            // 
            this.ded_min_threshold_gross_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_min_threshold_gross_t.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_min_threshold_gross_t.ForeColor = System.Drawing.Color.Black;
            this.ded_min_threshold_gross_t.Location = new System.Drawing.Point(115, 166);
            this.ded_min_threshold_gross_t.Name = "ded_min_threshold_gross_t";
            this.ded_min_threshold_gross_t.Size = new System.Drawing.Size(158, 28);
            this.ded_min_threshold_gross_t.TabIndex = 32786;
            this.ded_min_threshold_gross_t.Text = "Min Gross/Net Threshold($)if % of Gross or Net is specified";
            this.ded_min_threshold_gross_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ded_min_threshold_gross
            // 
            this.ded_min_threshold_gross.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_min_threshold_gross.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ded_min_threshold_gross.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedMinThresholdGross", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_min_threshold_gross.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_min_threshold_gross.ForeColor = System.Drawing.Color.Black;
            this.ded_min_threshold_gross.Location = new System.Drawing.Point(281, 171);
            this.ded_min_threshold_gross.MaxLength = 0;
            this.ded_min_threshold_gross.Name = "ded_min_threshold_gross";
            this.ded_min_threshold_gross.ReadOnly = true;
            this.ded_min_threshold_gross.Size = new System.Drawing.Size(55, 13);
            this.ded_min_threshold_gross.TabIndex = 32787;
            this.ded_min_threshold_gross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ded_max_threshold_net_pct_t
            // 
            this.ded_max_threshold_net_pct_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_max_threshold_net_pct_t.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_max_threshold_net_pct_t.ForeColor = System.Drawing.Color.Black;
            this.ded_max_threshold_net_pct_t.Location = new System.Drawing.Point(367, 166);
            this.ded_max_threshold_net_pct_t.Name = "ded_max_threshold_net_pct_t";
            this.ded_max_threshold_net_pct_t.Size = new System.Drawing.Size(159, 14);
            this.ded_max_threshold_net_pct_t.TabIndex = 32788;
            this.ded_max_threshold_net_pct_t.Text = "Min Net Threshold(%)";
            this.ded_max_threshold_net_pct_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ded_max_threshold_net_pct
            // 
            this.ded_max_threshold_net_pct.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ded_max_threshold_net_pct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ded_max_threshold_net_pct.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DedMaxThresholdNetPct", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ded_max_threshold_net_pct.Font = new System.Drawing.Font("Arial", 8F);
            this.ded_max_threshold_net_pct.ForeColor = System.Drawing.Color.Black;
            this.ded_max_threshold_net_pct.Location = new System.Drawing.Point(470, 169);
            this.ded_max_threshold_net_pct.MaxLength = 0;
            this.ded_max_threshold_net_pct.Name = "ded_max_threshold_net_pct";
            this.ded_max_threshold_net_pct.ReadOnly = true;
            this.ded_max_threshold_net_pct.Size = new System.Drawing.Size(43, 13);
            this.ded_max_threshold_net_pct.TabIndex = 32789;
            this.ded_max_threshold_net_pct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_posttax_deductions_not_applied_comment
            // 
            this.t_posttax_deductions_not_applied_comment.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_posttax_deductions_not_applied_comment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "TPosttaxDeductionsNotAppliedComment", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.t_posttax_deductions_not_applied_comment.Font = new System.Drawing.Font("Arial", 8F);
            this.t_posttax_deductions_not_applied_comment.ForeColor = System.Drawing.Color.Black;
            this.t_posttax_deductions_not_applied_comment.Location = new System.Drawing.Point(115, 195);
            this.t_posttax_deductions_not_applied_comment.MaxLength = 0;
            this.t_posttax_deductions_not_applied_comment.Name = "t_posttax_deductions_not_applied_comment";
            this.t_posttax_deductions_not_applied_comment.ReadOnly = true;
            this.t_posttax_deductions_not_applied_comment.Size = new System.Drawing.Size(414, 60);
            this.t_posttax_deductions_not_applied_comment.TabIndex = 32790;
            // 
            // ded_type_period
            // 
            this.ded_type_period.AutoSize = true;
            this.ded_type_period.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "DedTypePeriod", true));
            this.ded_type_period.Location = new System.Drawing.Point(121, 72);
            this.ded_type_period.Name = "ded_type_period";
            this.ded_type_period.Size = new System.Drawing.Size(54, 17);
            this.ded_type_period.TabIndex = 32791;
            this.ded_type_period.TabStop = true;
            this.ded_type_period.Text = "Week";
            this.ded_type_period.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "DedTypePeriod", true));
            this.radioButton1.Location = new System.Drawing.Point(183, 72);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(55, 17);
            this.radioButton1.TabIndex = 32792;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Month";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // t_1
            // 
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_1.Font = new System.Drawing.Font("Arial", 8F);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(457, 4);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(25, 15);
            this.t_1.TabIndex = 32769;
            this.t_1.Text = "ID:";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DwPostTaxDeductions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.ded_type_period);
            this.Controls.Add(this.t_posttax_deductions_not_applied_invoice);
            this.Controls.Add(this.ded_description_t);
            this.Controls.Add(this.ded_description);
            this.Controls.Add(this.ded_id);
            this.Controls.Add(this.pct_id_t);
            this.Controls.Add(this.pct_id);
            this.Controls.Add(this.ded_priority_t);
            this.Controls.Add(this.ded_priority);
            this.Controls.Add(this.ded_reference_t);
            this.Controls.Add(this.ded_reference);
            this.Controls.Add(this.ded_type_period_t);
            this.Controls.Add(this.ded_start_balance_t);
            this.Controls.Add(this.ded_start_balance);
            this.Controls.Add(this.ded_end_balance_t);
            this.Controls.Add(this.ded_end_balance);
            this.Controls.Add(this.ded_pay_highest_value);
            this.Controls.Add(this.ded_percent_gross_t);
            this.Controls.Add(this.ded_percent_net_t);
            this.Controls.Add(this.ded_fixed_amount_t);
            this.Controls.Add(this.ded_percent_start_balance_t);
            this.Controls.Add(this.ded_default_minimum_t);
            this.Controls.Add(this.ded_percent_gross);
            this.Controls.Add(this.ded_percent_net);
            this.Controls.Add(this.ded_fixed_amount);
            this.Controls.Add(this.ded_percent_start_balance);
            this.Controls.Add(this.ded_default_minimum);
            this.Controls.Add(this.ded_min_threshold_gross_t);
            this.Controls.Add(this.ded_min_threshold_gross);
            this.Controls.Add(this.ded_max_threshold_net_pct_t);
            this.Controls.Add(this.ded_max_threshold_net_pct);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.t_posttax_deductions_not_applied_comment);
            this.Name = "DwPostTaxDeductions";
            this.Size = new System.Drawing.Size(650, 300);
            this.Load += new System.EventHandler(this.DwPostTaxDeductions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private RadioButton ded_type_period;
        private RadioButton radioButton1;

    }
}
