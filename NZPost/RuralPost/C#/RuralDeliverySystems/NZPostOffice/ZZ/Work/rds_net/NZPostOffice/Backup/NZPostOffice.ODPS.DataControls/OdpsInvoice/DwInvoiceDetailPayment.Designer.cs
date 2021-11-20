using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    partial class DwInvoiceDetailPayment
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

        private System.Windows.Forms.TextBox compute_1;
        private System.Windows.Forms.TextBox compute_2;
        private System.Windows.Forms.TextBox m_wtax_value;
        private System.Windows.Forms.TextBox m_gst_rate;
        private System.Windows.Forms.TextBox m_standard;
        private System.Windows.Forms.Label t_10;
        private System.Windows.Forms.Label t_11;
        private System.Windows.Forms.Label t_12;
        private System.Windows.Forms.Label t_13;
        private System.Windows.Forms.TextBox m_gst_value;
        private System.Windows.Forms.Label t_14;
        private System.Windows.Forms.Label t_15;
        private System.Windows.Forms.Label t_16;
        private System.Windows.Forms.Label t_17;
        private System.Windows.Forms.Label t_18;
        private System.Windows.Forms.TextBox y_gst_value;
        private System.Windows.Forms.TextBox m_total_before_tax;
        private System.Windows.Forms.Label t_19;
        private System.Windows.Forms.TextBox y_wtax_value;
        private System.Windows.Forms.TextBox y_taxable_adjustments;
        private System.Windows.Forms.TextBox m_taxable_adjustments;
        private System.Windows.Forms.TextBox m_wtax_rate;
        private System.Windows.Forms.TextBox y_total_before_tax;
        private System.Windows.Forms.Label t_20;
        private System.Windows.Forms.TextBox m_adj_notax;
        private System.Windows.Forms.Label t_21;
        private System.Windows.Forms.TextBox m_allowance;
        private System.Windows.Forms.TextBox y_adj_notax;
        private System.Windows.Forms.TextBox y_allowance;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.Label t_3;
        private System.Windows.Forms.Label t_4;
        private System.Windows.Forms.Label t_5;
        private System.Windows.Forms.Label t_6;
        private System.Windows.Forms.Label t_7;
        private System.Windows.Forms.Label t_8;
        private System.Windows.Forms.Label t_9;
        private System.Windows.Forms.TextBox y_standard;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DwInvoiceDetailPayment";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsInvoice.InvoiceDetailPayment);
            //
            // t_1
            //
            this.t_1 = new System.Windows.Forms.Label();
            //?this.t_1.BorderStyle = BorderStyle.FixedSingle;
            this.t_1.Font = new System.Drawing.Font("Times New Roman", 10F,System.Drawing.FontStyle.Bold);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(8, 4);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(312, 22);
            this.t_1.Text = "Payment for Month";
            this.t_1.TextAlign = ContentAlignment.MiddleLeft;
            this.t_1.BackColor = System.Drawing.Color.White;//.ButtonFace;
            this.Controls.Add(t_1);

            //
            // t_2
            //
            this.t_2 = new System.Windows.Forms.Label();
            this.t_2.Font = new System.Drawing.Font("Times New Roman", 10F,System.Drawing.FontStyle.Bold);
            //?this.t_2.BorderStyle = BorderStyle.FixedSingle;
            this.t_2.ForeColor = System.Drawing.Color.Black;
            this.t_2.Location = new System.Drawing.Point(320, 4);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(297, 22);
            this.t_2.Text = "Payment Year to Date";
            this.t_2.TextAlign = ContentAlignment.MiddleLeft;
            this.t_2.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_2);

            //
            // m_standard
            //
            m_standard = new System.Windows.Forms.TextBox();
            //?this.m_standard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_standard.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.m_standard.ForeColor = System.Drawing.Color.Black;
            this.m_standard.Location = new System.Drawing.Point(214, 26);
            this.m_standard.MaxLength = 0;
            this.m_standard.Name = "m_standard";
            this.m_standard.Size = new System.Drawing.Size(106, 23);
            this.m_standard.TextAlign = HorizontalAlignment.Right;
            this.m_standard.BackColor = System.Drawing.Color.White;
            this.m_standard.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "MStandard", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.m_standard.ReadOnly = true;
            this.Controls.Add(m_standard);

            //
            // y_standard
            //
            y_standard = new System.Windows.Forms.TextBox();
            //?this.y_standard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.y_standard.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.y_standard.ForeColor = System.Drawing.Color.Black;
            this.y_standard.Location = new System.Drawing.Point(526, 26);
            this.y_standard.MaxLength = 0;
            this.y_standard.Name = "y_standard";
            this.y_standard.Size = new System.Drawing.Size(91, 23);
            this.y_standard.TextAlign = HorizontalAlignment.Right;
            this.y_standard.BackColor = System.Drawing.Color.White;
            this.y_standard.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "YStandard", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.y_standard.ReadOnly = true;
            this.Controls.Add(y_standard);

            //
            // m_allowance
            //
            m_allowance = new System.Windows.Forms.TextBox();
            //?this.m_allowance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //?this.m_allowance.BorderStyle = BorderStyle.FixedSingle;
            this.m_allowance.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.m_allowance.ForeColor = System.Drawing.Color.Black;
            this.m_allowance.Location = new System.Drawing.Point(214, 49);
            this.m_allowance.MaxLength = 0;
            this.m_allowance.Name = "m_allowance";
            this.m_allowance.Size = new System.Drawing.Size(106, 23);
            this.m_allowance.TextAlign = HorizontalAlignment.Right;
            this.m_allowance.BackColor = System.Drawing.Color.White;
            this.m_allowance.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "MAllowance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.m_allowance.ReadOnly = true;
            this.Controls.Add(m_allowance);

            //
            // y_allowance
            //
            y_allowance = new System.Windows.Forms.TextBox();
            //?this.y_allowance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.y_allowance.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.y_allowance.ForeColor = System.Drawing.Color.Black;
            this.y_allowance.Location = new System.Drawing.Point(526, 49);
            this.y_allowance.MaxLength = 0;
            this.y_allowance.Name = "y_allowance";
            this.y_allowance.Size = new System.Drawing.Size(91, 23);
            this.y_allowance.TextAlign = HorizontalAlignment.Right;
            this.y_allowance.BackColor = System.Drawing.Color.White;
            this.y_allowance.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "YAllowance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.y_allowance.ReadOnly = true;
            this.Controls.Add(y_allowance);

            //
            // m_taxable_adjustments
            //
            m_taxable_adjustments = new System.Windows.Forms.TextBox();
            //?this.m_taxable_adjustments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_taxable_adjustments.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.m_taxable_adjustments.ForeColor = System.Drawing.Color.Black;
            this.m_taxable_adjustments.Location = new System.Drawing.Point(214, 72);
            this.m_taxable_adjustments.MaxLength = 0;
            this.m_taxable_adjustments.Name = "m_taxable_adjustments";
            this.m_taxable_adjustments.Size = new System.Drawing.Size(106, 23);
            this.m_taxable_adjustments.TextAlign = HorizontalAlignment.Right;
            this.m_taxable_adjustments.BackColor = System.Drawing.Color.White;
            this.m_taxable_adjustments.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "MTaxableAdjustments", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.m_taxable_adjustments.ReadOnly = true;
            this.Controls.Add(m_taxable_adjustments);

            //
            // y_taxable_adjustments
            //
            y_taxable_adjustments = new System.Windows.Forms.TextBox();
            //?this.y_taxable_adjustments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.y_taxable_adjustments.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.y_taxable_adjustments.ForeColor = System.Drawing.Color.Black;
            this.y_taxable_adjustments.Location = new System.Drawing.Point(526, 72);
            this.y_taxable_adjustments.MaxLength = 0;
            this.y_taxable_adjustments.Name = "y_taxable_adjustments";
            this.y_taxable_adjustments.Size = new System.Drawing.Size(91, 23);
            this.y_taxable_adjustments.TextAlign = HorizontalAlignment.Right;
            this.y_taxable_adjustments.BackColor = System.Drawing.Color.White;
            this.y_taxable_adjustments.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "YTaxableAdjustments", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.y_taxable_adjustments.ReadOnly = true;
            this.Controls.Add(y_taxable_adjustments);

            //
            // m_total_before_tax
            //
            m_total_before_tax = new System.Windows.Forms.TextBox();
            //?this.m_total_before_tax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_total_before_tax.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.m_total_before_tax.ForeColor = System.Drawing.Color.Black;
            this.m_total_before_tax.Location = new System.Drawing.Point(214, 95);
            this.m_total_before_tax.Name = "m_total_before_tax";
            this.m_total_before_tax.Size = new System.Drawing.Size(106, 23);
            this.m_total_before_tax.TextAlign = HorizontalAlignment.Right;
            //?     this.m_total_before_tax.TextAlign = System.Windows.Forms.ContentAlignment.MiddleRight;
            this.m_total_before_tax.BackColor = System.Drawing.Color.White;
            this.m_total_before_tax.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "MTotalBeforeTax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(m_total_before_tax);

            //
            // y_total_before_tax
            //
            y_total_before_tax = new System.Windows.Forms.TextBox();
           //? //?this.y_total_before_tax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.y_total_before_tax.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.y_total_before_tax.ForeColor = System.Drawing.Color.Black;
            this.y_total_before_tax.Location = new System.Drawing.Point(526, 95);
            this.y_total_before_tax.Name = "y_total_before_tax";
            this.y_total_before_tax.Size = new System.Drawing.Size(91, 23);
            this.y_total_before_tax.TextAlign = HorizontalAlignment.Right;
            //?     this.y_total_before_tax.TextAlign = System.Windows.Forms.ContentAlignment.MiddleRight;
            this.y_total_before_tax.BackColor = System.Drawing.Color.White;
            this.y_total_before_tax.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "YTotalBeforeTax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(y_total_before_tax);

            //
            // t_4
            //
            this.t_4 = new System.Windows.Forms.Label();
            //?this.t_4.BorderStyle = BorderStyle.FixedSingle;
            this.t_4.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_4.ForeColor = System.Drawing.Color.Black;
            this.t_4.Location = new System.Drawing.Point(8, 118);
            this.t_4.Name = "t_4";
            this.t_4.Size = new System.Drawing.Size(56, 23);
            this.t_4.Text = "GST @";
            this.t_4.TextAlign = ContentAlignment.MiddleLeft;
            this.t_4.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_4);

            //
            // m_gst_rate
            //
            m_gst_rate = new System.Windows.Forms.TextBox();
            //?this.m_gst_rate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_gst_rate.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.m_gst_rate.ForeColor = System.Drawing.Color.Black;
            this.m_gst_rate.Location = new System.Drawing.Point(64, 118);
            this.m_gst_rate.MaxLength = 0;
            this.m_gst_rate.Name = "m_gst_rate";
            this.m_gst_rate.Size = new System.Drawing.Size(150, 23);
            this.m_gst_rate.TextAlign = HorizontalAlignment.Left;
            this.m_gst_rate.BackColor = System.Drawing.Color.White;
            this.m_gst_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "MGstRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.m_gst_rate.ReadOnly = true;
            this.Controls.Add(m_gst_rate);

            //
            // m_gst_value
            //
            m_gst_value = new System.Windows.Forms.TextBox();
            //?this.m_gst_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_gst_value.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.m_gst_value.ForeColor = System.Drawing.Color.Black;
            this.m_gst_value.Location = new System.Drawing.Point(214, 118);
            this.m_gst_value.MaxLength = 0;
            this.m_gst_value.Name = "m_gst_value";
            this.m_gst_value.Size = new System.Drawing.Size(106, 23);
            this.m_gst_value.TextAlign = HorizontalAlignment.Right;
            this.m_gst_value.BackColor = System.Drawing.Color.White;
            this.m_gst_value.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "MGstValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.m_gst_value.ReadOnly = true;
            this.Controls.Add(m_gst_value);

            //
            // y_gst_value
            //
            y_gst_value = new System.Windows.Forms.TextBox();
            //?this.y_gst_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.y_gst_value.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.y_gst_value.ForeColor = System.Drawing.Color.Black;
            this.y_gst_value.Location = new System.Drawing.Point(526, 118);
            this.y_gst_value.MaxLength = 0;
            this.y_gst_value.Name = "y_gst_value";
            this.y_gst_value.Size = new System.Drawing.Size(91, 23);
            this.y_gst_value.TextAlign = HorizontalAlignment.Right;
            this.y_gst_value.BackColor = System.Drawing.Color.White;
            this.y_gst_value.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "YGstValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.y_gst_value.ReadOnly = true;
            this.Controls.Add(y_gst_value);

            //
            // t_5
            //
            this.t_5 = new System.Windows.Forms.Label();
            //?this.t_5.BorderStyle = BorderStyle.FixedSingle;
            this.t_5.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_5.ForeColor = System.Drawing.Color.Black;
            this.t_5.Location = new System.Drawing.Point(8, 141);
            this.t_5.Name = "t_5";
            this.t_5.Size = new System.Drawing.Size(120, 23);
            this.t_5.Text = "Withholding tax @";
            this.t_5.TextAlign = ContentAlignment.MiddleLeft;
            this.t_5.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_5);

            //
            // m_wtax_rate
            //
            m_wtax_rate = new System.Windows.Forms.TextBox();
            //?this.m_wtax_rate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_wtax_rate.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.m_wtax_rate.ForeColor = System.Drawing.Color.Black;
            this.m_wtax_rate.Location = new System.Drawing.Point(128, 141);
            this.m_wtax_rate.MaxLength = 0;
            this.m_wtax_rate.Name = "m_wtax_rate";
            this.m_wtax_rate.Size = new System.Drawing.Size(86, 23);
            this.m_wtax_rate.TextAlign = HorizontalAlignment.Left;
            this.m_wtax_rate.BackColor = System.Drawing.Color.White;
            this.m_wtax_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "MWtaxRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.m_wtax_rate.ReadOnly = true;
            this.Controls.Add(m_wtax_rate);

            //
            // m_wtax_value
            //
            m_wtax_value = new System.Windows.Forms.TextBox();
            //?this.m_wtax_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_wtax_value.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.m_wtax_value.ForeColor = System.Drawing.Color.Black;
            this.m_wtax_value.Location = new System.Drawing.Point(214, 141);
            this.m_wtax_value.MaxLength = 0;
            this.m_wtax_value.Name = "m_wtax_value";
            this.m_wtax_value.Size = new System.Drawing.Size(106, 23);
            this.m_wtax_value.TextAlign = HorizontalAlignment.Right;
            this.m_wtax_value.BackColor = System.Drawing.Color.White;
            this.m_wtax_value.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "MWtaxValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.m_wtax_value.ReadOnly = true;
            this.Controls.Add(m_wtax_value);

            //
            // y_wtax_value
            //
            y_wtax_value = new System.Windows.Forms.TextBox();
            //?this.y_wtax_value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.y_wtax_value.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.y_wtax_value.ForeColor = System.Drawing.Color.Black;
            this.y_wtax_value.Location = new System.Drawing.Point(526, 141);
            this.y_wtax_value.MaxLength = 0;
            this.y_wtax_value.Name = "y_wtax_value";
            this.y_wtax_value.Size = new System.Drawing.Size(91, 23);
            this.y_wtax_value.TextAlign = HorizontalAlignment.Right;
            this.y_wtax_value.BackColor = System.Drawing.Color.White;
            this.y_wtax_value.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "YWtaxValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.y_wtax_value.ReadOnly = true;
            this.Controls.Add(y_wtax_value);

            //
            // m_adj_notax
            //
            m_adj_notax = new System.Windows.Forms.TextBox();
            //?this.m_adj_notax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_adj_notax.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.m_adj_notax.ForeColor = System.Drawing.Color.Black;
            this.m_adj_notax.Location = new System.Drawing.Point(214, 164);
            this.m_adj_notax.MaxLength = 0;
            this.m_adj_notax.Name = "m_adj_notax";
            this.m_adj_notax.Size = new System.Drawing.Size(106, 23);
            this.m_adj_notax.TextAlign = HorizontalAlignment.Right;
            this.m_adj_notax.BackColor = System.Drawing.Color.White;
            this.m_adj_notax.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "MAdjNotax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.m_adj_notax.ReadOnly = true;
            this.Controls.Add(m_adj_notax);

            //
            // y_adj_notax
            //
            y_adj_notax = new System.Windows.Forms.TextBox();
            //?this.y_adj_notax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.y_adj_notax.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.y_adj_notax.ForeColor = System.Drawing.Color.Black;
            this.y_adj_notax.Location = new System.Drawing.Point(526, 164);
            this.y_adj_notax.MaxLength = 0;
            this.y_adj_notax.Name = "y_adj_notax";
            this.y_adj_notax.Size = new System.Drawing.Size(91, 23);
            this.y_adj_notax.TextAlign = HorizontalAlignment.Right;
            this.y_adj_notax.BackColor = System.Drawing.Color.White;
            this.y_adj_notax.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "YAdjNotax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.y_adj_notax.ReadOnly = true;
            this.Controls.Add(y_adj_notax);

            //
            // compute_1
            //
            compute_1 = new System.Windows.Forms.TextBox();
            //?this.compute_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.compute_1.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.compute_1.ForeColor = System.Drawing.Color.Black;
            this.compute_1.Location = new System.Drawing.Point(8, 187);
            this.compute_1.Name = "compute_1";
            this.compute_1.Size = new System.Drawing.Size(312, 23);
            //?      this.compute_1.TextAlign = System.Windows.Forms.ContentAlignment.MiddleRight;
            this.compute_1.BackColor = System.Drawing.Color.Silver;
            this.compute_1.TextAlign = HorizontalAlignment.Right;
            this.compute_1.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Compute1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(compute_1);

            //
            // t_3
            //
            this.t_3 = new System.Windows.Forms.Label();
            //?this.t_3.BorderStyle = BorderStyle.FixedSingle;
            this.t_3.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_3.ForeColor = System.Drawing.Color.Black;
            this.t_3.Location = new System.Drawing.Point(8, 187);
            this.t_3.Name = "t_3";
            this.t_3.Size = new System.Drawing.Size(130, 22);
            this.t_3.Text = "Amount for Payment";
            this.t_3.TextAlign = ContentAlignment.MiddleRight;
            this.t_3.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_3);

            //
            // compute_2
            //
            compute_2 = new System.Windows.Forms.TextBox();
            //?this.compute_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.compute_2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.compute_2.ForeColor = System.Drawing.Color.Black;
            this.compute_2.Location = new System.Drawing.Point(526, 187);
            this.compute_2.Name = "compute_2";
            this.compute_2.Size = new System.Drawing.Size(91, 23);
            this.compute_2.TextAlign = HorizontalAlignment.Right;
            //?       this.compute_2.TextAlign = System.Windows.Forms.ContentAlignment.MiddleRight;
            this.compute_2.BackColor = System.Drawing.Color.White;
            this.compute_2.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Compute2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(compute_2);

            //
            // t_6
            //
            this.t_6 = new System.Windows.Forms.Label();
            //?this.t_6.BorderStyle = BorderStyle.FixedSingle;
            this.t_6.Font = new System.Drawing.Font("Times New Roman", 10F,System.Drawing.FontStyle.Bold);
            this.t_6.ForeColor = System.Drawing.Color.Black;
            this.t_6.Location = new System.Drawing.Point(8, 210);
            this.t_6.Name = "t_6";
            this.t_6.Size = new System.Drawing.Size(609, 23);
            this.t_6.Text = "Details of Monthly Adjustments";
            this.t_6.TextAlign = ContentAlignment.MiddleCenter;
            this.t_6.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_6);

            //
            // t_7
            //
            this.t_7 = new System.Windows.Forms.Label();
            //?this.t_7.BorderStyle = BorderStyle.FixedSingle;
            this.t_7.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_7.ForeColor = System.Drawing.Color.Black;
            this.t_7.Location = new System.Drawing.Point(8, 233);
            this.t_7.Name = "t_7";
            this.t_7.Size = new System.Drawing.Size(312, 23);
            this.t_7.Text = "Taxable";
            this.t_7.TextAlign = ContentAlignment.MiddleCenter;
            this.t_7.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_7);

            //
            // t_8
            //
            this.t_8 = new System.Windows.Forms.Label();
            //?this.t_8.BorderStyle = BorderStyle.FixedSingle;
            this.t_8.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_8.ForeColor = System.Drawing.Color.Black;
            this.t_8.Location = new System.Drawing.Point(320, 233);
            this.t_8.Name = "t_8";
            this.t_8.Size = new System.Drawing.Size(297, 23);
            this.t_8.Text = "Non Taxable";
            this.t_8.TextAlign = ContentAlignment.MiddleCenter;
            this.t_8.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_8);

            //
            // t_9
            //
            this.t_9 = new System.Windows.Forms.Label();
            //?this.t_9.BorderStyle = BorderStyle.FixedSingle;
            this.t_9.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_9.ForeColor = System.Drawing.Color.Black;
            this.t_9.Location = new System.Drawing.Point(320, 26);
            this.t_9.Name = "t_9";
            this.t_9.Size = new System.Drawing.Size(206, 23);
            this.t_9.Text = "Standard";
            this.t_9.TextAlign = ContentAlignment.MiddleLeft;
            this.t_9.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_9);

            //
            // t_10
            //
            this.t_10 = new System.Windows.Forms.Label();
            //?this.t_10.BorderStyle = BorderStyle.FixedSingle;
            this.t_10.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_10.ForeColor = System.Drawing.Color.Black;
            this.t_10.Location = new System.Drawing.Point(320, 49);
            this.t_10.Name = "t_10";
            this.t_10.Size = new System.Drawing.Size(206, 23);
            this.t_10.Text = "Allowance";
            this.t_10.TextAlign = ContentAlignment.MiddleLeft;
            this.t_10.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_10);

            //
            // t_11
            //
            this.t_11 = new System.Windows.Forms.Label();
            //?this.t_11.BorderStyle = BorderStyle.FixedSingle;
            this.t_11.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_11.ForeColor = System.Drawing.Color.Black;
            this.t_11.Location = new System.Drawing.Point(320, 72);
            this.t_11.Name = "t_11";
            this.t_11.Size = new System.Drawing.Size(206, 23);
            this.t_11.Text = "Adjustments (taxable)";
            this.t_11.TextAlign = ContentAlignment.MiddleLeft;
            this.t_11.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_11);

            //
            // t_12
            //
            this.t_12 = new System.Windows.Forms.Label();
            //?this.t_12.BorderStyle = BorderStyle.FixedSingle;
            this.t_12.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_12.ForeColor = System.Drawing.Color.Black;
            this.t_12.Location = new System.Drawing.Point(320, 95);
            this.t_12.Name = "t_12";
            this.t_12.Size = new System.Drawing.Size(206, 23);
            this.t_12.Text = "Total to date tax";
            this.t_12.TextAlign = ContentAlignment.MiddleLeft;
            this.t_12.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_12);

            //
            // t_13
            //
            this.t_13 = new System.Windows.Forms.Label();
            //?this.t_13.BorderStyle = BorderStyle.FixedSingle;
            this.t_13.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_13.ForeColor = System.Drawing.Color.Black;
            this.t_13.Location = new System.Drawing.Point(320, 118);
            this.t_13.Name = "t_13";
            this.t_13.Size = new System.Drawing.Size(206, 23);
            this.t_13.Text = "GST to date";
            this.t_13.TextAlign = ContentAlignment.MiddleLeft;
            this.t_13.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_13);

            //
            // t_14
            //
            this.t_14 = new System.Windows.Forms.Label();
            //?this.t_14.BorderStyle = BorderStyle.FixedSingle;
            this.t_14.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_14.ForeColor = System.Drawing.Color.Black;
            this.t_14.Location = new System.Drawing.Point(320, 141);
            this.t_14.Name = "t_14";
            this.t_14.Size = new System.Drawing.Size(206, 23);
            this.t_14.Text = "Withholding tax";
            this.t_14.TextAlign = ContentAlignment.MiddleLeft;
            this.t_14.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_14);

            //
            // t_15
            //
            this.t_15 = new System.Windows.Forms.Label();
            //?this.t_15.BorderStyle = BorderStyle.FixedSingle;
            this.t_15.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_15.ForeColor = System.Drawing.Color.Black;
            this.t_15.Location = new System.Drawing.Point(320, 164);
            this.t_15.Name = "t_15";
            this.t_15.Size = new System.Drawing.Size(206, 23);
            this.t_15.Text = "Adjustments (non-taxable)";
            this.t_15.TextAlign = ContentAlignment.MiddleLeft;
            this.t_15.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_15);

            //
            // t_16
            //
            this.t_16 = new System.Windows.Forms.Label();
            //?this.t_16.BorderStyle = BorderStyle.FixedSingle;
            this.t_16.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_16.ForeColor = System.Drawing.Color.Black;
            this.t_16.Location = new System.Drawing.Point(320, 187);
            this.t_16.Name = "t_16";
            this.t_16.Size = new System.Drawing.Size(206, 23);
            this.t_16.Text = "Amount paid to date";
            this.t_16.TextAlign = ContentAlignment.MiddleLeft;
            this.t_16.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_16);

            //
            // t_17
            //
            this.t_17 = new System.Windows.Forms.Label();
            //?this.t_17.BorderStyle = BorderStyle.FixedSingle;
            this.t_17.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_17.ForeColor = System.Drawing.Color.Black;
            this.t_17.Location = new System.Drawing.Point(8, 26);
            this.t_17.Name = "t_17";
            this.t_17.Size = new System.Drawing.Size(206, 23);
            this.t_17.Text = "Standard";
            this.t_17.TextAlign = ContentAlignment.MiddleLeft;
            this.t_17.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_17);

            //
            // t_18
            //
            this.t_18 = new System.Windows.Forms.Label();
            //?this.t_18.BorderStyle = BorderStyle.FixedSingle;
            this.t_18.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_18.ForeColor = System.Drawing.Color.Black;
            this.t_18.Location = new System.Drawing.Point(8, 49);
            this.t_18.Name = "t_18";
            this.t_18.Size = new System.Drawing.Size(206, 23);
            this.t_18.Text = "Allowance";
            this.t_18.TextAlign = ContentAlignment.MiddleLeft;
            this.t_18.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_18);

            //
            // t_19
            //
            this.t_19 = new System.Windows.Forms.Label();
            //?this.t_19.BorderStyle = BorderStyle.FixedSingle;
            this.t_19.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_19.ForeColor = System.Drawing.Color.Black;
            this.t_19.Location = new System.Drawing.Point(8, 72);
            this.t_19.Name = "t_19";
            this.t_19.Size = new System.Drawing.Size(206, 23);
            this.t_19.Text = "Adjustments (taxable)";
            this.t_19.TextAlign = ContentAlignment.MiddleLeft;
            this.t_19.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_19);

            //
            // t_20
            //
            this.t_20 = new System.Windows.Forms.Label();
            //?this.t_20.BorderStyle = BorderStyle.FixedSingle;
            this.t_20.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_20.ForeColor = System.Drawing.Color.Black;
            this.t_20.Location = new System.Drawing.Point(8, 95);
            this.t_20.Name = "t_20";
            this.t_20.Size = new System.Drawing.Size(206, 23);
            this.t_20.Text = "Total before tax";
            this.t_20.TextAlign = ContentAlignment.MiddleLeft;
            this.t_20.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_20);

            //
            // t_21
            //
            this.t_21 = new System.Windows.Forms.Label();
            //?this.t_21.BorderStyle = BorderStyle.FixedSingle;
            this.t_21.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.t_21.ForeColor = System.Drawing.Color.Black;
            this.t_21.Location = new System.Drawing.Point(8, 164);
            this.t_21.Name = "t_21";
            this.t_21.Size = new System.Drawing.Size(206, 23);
            this.t_21.Text = "Adjustments (non-taxable)";
            this.t_21.TextAlign = ContentAlignment.MiddleLeft;
            this.t_21.BackColor = System.Drawing.Color.White;
            this.Controls.Add(t_21);

            this.Size = new System.Drawing.Size(660, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
        }
        #endregion

    }
}
