using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class DwNationalDetailDs
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

        private Metex.Windows.DataEntityCombo nat_ac_id_postax_adj_gl;
        private System.Windows.Forms.TextBox nat_od_standard_gst_rate;
        private System.Windows.Forms.Label nat_seq_no_for_keys_t;
        private System.Windows.Forms.TextBox nat_acc_percentage;
        private Metex.Windows.DataEntityCombo nat_courierpost_defaultcompty;
        private System.Windows.Forms.TextBox nat_rural_post_gst_no;
        private Metex.Windows.DataEntityCombo nat_ac_id_whtax_gl;
        private System.Windows.Forms.Label nat_rural_post_payer_name_t;
        private System.Windows.Forms.Label nat_rural_post_gst_no_t;
        private System.Windows.Forms.Label nat_ird_no_t;
        private Metex.Windows.DataEntityCombo nat_ac_id_gst_gl;
        private System.Windows.Forms.TextBox nat_day_of_month;
        private System.Windows.Forms.Label nat_od_tax_rate_no_ir13_t;
        private System.Windows.Forms.Label nat_gst_rate_t;
        private System.Windows.Forms.Label nat_rural_post_address_t;
        private System.Windows.Forms.TextBox nat_net_pct_change_warn;
        private System.Windows.Forms.RichTextBox nat_message_for_invoice;
        private System.Windows.Forms.Label nat_pbu_code_whtax_gl_t;
        private Metex.Windows.DataEntityCombo ac_id;
        private Metex.Windows.DataEntityCombo nat_adpost_defaultcomptype;
        private System.Windows.Forms.RichTextBox nat_rural_post_address;
        private Metex.Windows.DataEntityCombo nat_ac_id_accrualbalance_gl;
        private System.Windows.Forms.Label nat_od_tax_rate_ir13_t;
        private System.Windows.Forms.TextBox nat_ird_no;
        private System.Windows.Forms.Label nat_pbu_code_gst_gl_t;
        private System.Windows.Forms.Label nat_ac_id_contprice_gl_t;
        private System.Windows.Forms.TextBox nat_seq_no_for_keys;
        private System.Windows.Forms.Label nat_standard_tax_rate_t;
        private System.Windows.Forms.Label nat_pbu_code_postax_gl_t;
        private System.Windows.Forms.Label nat_ac_id_whtax_gl_t;
        private System.Windows.Forms.TextBox nat_invoice_number_prefix;
        private System.Windows.Forms.Label nat_net_pct_change_warn_t;
        private System.Windows.Forms.TextBox nat_gst_rate;
        private System.Windows.Forms.Label nat_ac_id_gst_gl_t;
        private System.Windows.Forms.Label t_3;
        private System.Windows.Forms.Label t_7;
        private System.Windows.Forms.Label t_6;
        private System.Windows.Forms.Label t_5;
        private System.Windows.Forms.Label t_4;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.Label t_8;
        private System.Windows.Forms.Label nat_acc_percentage_t;
        private Metex.Windows.DataEntityCombo nat_pbu_code_accrualbalance_g;
        private Metex.Windows.DataEntityCombo nat_ac_id_netpay_gl;
        private Metex.Windows.DataEntityCombo nat_deductions_defaultcomptyp;
        private System.Windows.Forms.TextBox nat_od_tax_rate_ir13;
        private System.Windows.Forms.Label nat_ac_id_netpay_gl_t;
        private Metex.Windows.DataEntityCombo nat_ac_id_contprice_gl;
        private System.Windows.Forms.TextBox nat_od_tax_rate_no_ir13;
        private Metex.Windows.DataEntityCombo nat_pbu_code_netpay_gl;
        private System.Windows.Forms.TextBox nat_standard_tax_rate;
        private System.Windows.Forms.Label nat_pbu_code_netpay_gl_t;
        private System.Windows.Forms.Label t_1;
        private Metex.Windows.DataEntityCombo nat_contadj_defaultcomptype;
        private System.Windows.Forms.Label nat_effective_date_t;
        private System.Windows.Forms.TextBox nat_rural_post_payer_name;
        private System.Windows.Forms.Label nat_od_standard_gst_rate_t;
        private System.Windows.Forms.Label nat_ac_id_accrualbalance_gl_t;
        private System.Windows.Forms.MaskedTextBox nat_effective_date;
        private System.Windows.Forms.Label nat_day_of_month_t;
        private System.Windows.Forms.Label nat_ac_id_postax_adj_gl_t;
        private Metex.Windows.DataEntityCombo nat_pbu_code_whtax_gl;
        private Metex.Windows.DataEntityCombo nat_pbu_code_gst_gl;
        private Metex.Windows.DataEntityCombo nat_pbu_code_postax_gl;
        private System.Windows.Forms.Label nat_message_for_invoice_t;
        private Metex.Windows.DataEntityCombo nat_contallow_defaultcomptype;
        private Metex.Windows.DataEntityCombo nat_freqadj_defaultcomptype;
        private System.Windows.Forms.Label nat_invoice_number_prefix_t;
        private System.Windows.Forms.GroupBox gb_1;
        private System.Windows.Forms.GroupBox gb_2;
        private System.Windows.Forms.GroupBox gb_3;
        private System.Windows.Forms.GroupBox gb_4;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.gb_1 = new System.Windows.Forms.GroupBox();
            this.nat_ac_id_contprice_gl_t = new System.Windows.Forms.Label();
            this.nat_ac_id_accrualbalance_gl_t = new System.Windows.Forms.Label();
            this.nat_pbu_code_accrualbalance_g = new Metex.Windows.DataEntityCombo();
            this.nat_ac_id_netpay_gl_t = new System.Windows.Forms.Label();
            this.nat_pbu_code_netpay_gl = new Metex.Windows.DataEntityCombo();
            this.nat_pbu_code_gst_gl = new Metex.Windows.DataEntityCombo();
            this.nat_ac_id_postax_adj_gl_t = new System.Windows.Forms.Label();
            this.nat_pbu_code_whtax_gl = new Metex.Windows.DataEntityCombo();
            this.nat_ac_id_whtax_gl_t = new System.Windows.Forms.Label();
            this.nat_pbu_code_postax_gl = new Metex.Windows.DataEntityCombo();
            this.nat_ac_id_gst_gl_t = new System.Windows.Forms.Label();
            this.nat_ac_id_accrualbalance_gl = new Metex.Windows.DataEntityCombo();
            this.nat_pbu_code_postax_gl_t = new System.Windows.Forms.Label();
            this.nat_ac_id_netpay_gl = new Metex.Windows.DataEntityCombo();
            this.nat_pbu_code_whtax_gl_t = new System.Windows.Forms.Label();
            this.nat_ac_id_contprice_gl = new Metex.Windows.DataEntityCombo();
            this.nat_pbu_code_gst_gl_t = new System.Windows.Forms.Label();
            this.nat_ac_id_postax_adj_gl = new Metex.Windows.DataEntityCombo();
            this.nat_pbu_code_netpay_gl_t = new System.Windows.Forms.Label();
            this.t_1 = new System.Windows.Forms.Label();
            this.nat_ac_id_whtax_gl = new Metex.Windows.DataEntityCombo();
            this.nat_ac_id_gst_gl = new Metex.Windows.DataEntityCombo();
            this.t_3 = new System.Windows.Forms.Label();
            this.t_7 = new System.Windows.Forms.Label();
            this.t_6 = new System.Windows.Forms.Label();
            this.t_5 = new System.Windows.Forms.Label();
            this.t_4 = new System.Windows.Forms.Label();
            this.t_2 = new System.Windows.Forms.Label();
            this.t_8 = new System.Windows.Forms.Label();
            this.gb_2 = new System.Windows.Forms.GroupBox();
            this.nat_gst_rate_t = new System.Windows.Forms.Label();
            this.nat_gst_rate = new System.Windows.Forms.TextBox();
            this.nat_ird_no = new System.Windows.Forms.TextBox();
            this.nat_rural_post_gst_no = new System.Windows.Forms.TextBox();
            this.nat_od_standard_gst_rate = new System.Windows.Forms.TextBox();
            this.nat_rural_post_address = new System.Windows.Forms.RichTextBox();
            this.nat_od_tax_rate_ir13 = new System.Windows.Forms.TextBox();
            this.nat_rural_post_payer_name_t = new System.Windows.Forms.Label();
            this.nat_rural_post_gst_no_t = new System.Windows.Forms.Label();
            this.nat_message_for_invoice_t = new System.Windows.Forms.Label();
            this.nat_message_for_invoice = new System.Windows.Forms.RichTextBox();
            this.nat_ird_no_t = new System.Windows.Forms.Label();
            this.nat_rural_post_address_t = new System.Windows.Forms.Label();
            this.nat_od_standard_gst_rate_t = new System.Windows.Forms.Label();
            this.nat_rural_post_payer_name = new System.Windows.Forms.TextBox();
            this.nat_od_tax_rate_ir13_t = new System.Windows.Forms.Label();
            this.nat_od_tax_rate_no_ir13 = new System.Windows.Forms.TextBox();
            this.nat_od_tax_rate_no_ir13_t = new System.Windows.Forms.Label();
            this.gb_3 = new System.Windows.Forms.GroupBox();
            this.nat_freqadj_defaultcomptype = new Metex.Windows.DataEntityCombo();
            this.nat_deductions_defaultcomptyp = new Metex.Windows.DataEntityCombo();
            this.ac_id = new Metex.Windows.DataEntityCombo();
            this.nat_adpost_defaultcomptype = new Metex.Windows.DataEntityCombo();
            this.nat_contallow_defaultcomptype = new Metex.Windows.DataEntityCombo();
            this.nat_contadj_defaultcomptype = new Metex.Windows.DataEntityCombo();
            this.nat_courierpost_defaultcompty = new Metex.Windows.DataEntityCombo();
            this.gb_4 = new System.Windows.Forms.GroupBox();
            this.nat_seq_no_for_keys_t = new System.Windows.Forms.Label();
            this.nat_invoice_number_prefix_t = new System.Windows.Forms.Label();
            this.nat_seq_no_for_keys = new System.Windows.Forms.TextBox();
            this.nat_effective_date_t = new System.Windows.Forms.Label();
            this.nat_net_pct_change_warn = new System.Windows.Forms.TextBox();
            this.nat_acc_percentage_t = new System.Windows.Forms.Label();
            this.nat_net_pct_change_warn_t = new System.Windows.Forms.Label();
            this.nat_standard_tax_rate_t = new System.Windows.Forms.Label();
            this.nat_day_of_month = new System.Windows.Forms.TextBox();
            this.nat_day_of_month_t = new System.Windows.Forms.Label();
            this.nat_standard_tax_rate = new System.Windows.Forms.TextBox();
            this.nat_invoice_number_prefix = new System.Windows.Forms.TextBox();
            this.nat_acc_percentage = new System.Windows.Forms.TextBox();
            this.nat_effective_date = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.gb_1.SuspendLayout();
            this.gb_2.SuspendLayout();
            this.gb_3.SuspendLayout();
            this.gb_4.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.NationalDetailDs);
            // 
            // gb_1
            // 
            this.gb_1.Controls.Add(this.nat_ac_id_contprice_gl_t);
            this.gb_1.Controls.Add(this.nat_ac_id_accrualbalance_gl_t);
            this.gb_1.Controls.Add(this.nat_pbu_code_accrualbalance_g);
            this.gb_1.Controls.Add(this.nat_ac_id_netpay_gl_t);
            this.gb_1.Controls.Add(this.nat_pbu_code_netpay_gl);
            this.gb_1.Controls.Add(this.nat_pbu_code_gst_gl);
            this.gb_1.Controls.Add(this.nat_ac_id_postax_adj_gl_t);
            this.gb_1.Controls.Add(this.nat_pbu_code_whtax_gl);
            this.gb_1.Controls.Add(this.nat_ac_id_whtax_gl_t);
            this.gb_1.Controls.Add(this.nat_pbu_code_postax_gl);
            this.gb_1.Controls.Add(this.nat_ac_id_gst_gl_t);
            this.gb_1.Controls.Add(this.nat_ac_id_accrualbalance_gl);
            this.gb_1.Controls.Add(this.nat_pbu_code_postax_gl_t);
            this.gb_1.Controls.Add(this.nat_ac_id_netpay_gl);
            this.gb_1.Controls.Add(this.nat_pbu_code_whtax_gl_t);
            this.gb_1.Controls.Add(this.nat_ac_id_contprice_gl);
            this.gb_1.Controls.Add(this.nat_pbu_code_gst_gl_t);
            this.gb_1.Controls.Add(this.nat_ac_id_postax_adj_gl);
            this.gb_1.Controls.Add(this.nat_pbu_code_netpay_gl_t);
            this.gb_1.Controls.Add(this.t_1);
            this.gb_1.Controls.Add(this.nat_ac_id_whtax_gl);
            this.gb_1.Controls.Add(this.nat_ac_id_gst_gl);
            this.gb_1.Font = new System.Drawing.Font("Arial", 8F);
            this.gb_1.Location = new System.Drawing.Point(16, 14);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(321, 259);
            this.gb_1.TabIndex = 0;
            this.gb_1.TabStop = false;
            this.gb_1.Text = "Interface Accounts:";
            // 
            // nat_ac_id_contprice_gl_t
            // 
            this.nat_ac_id_contprice_gl_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_ac_id_contprice_gl_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_ac_id_contprice_gl_t.ForeColor = System.Drawing.Color.Black;
            this.nat_ac_id_contprice_gl_t.Location = new System.Drawing.Point(18, 82);
            this.nat_ac_id_contprice_gl_t.Name = "nat_ac_id_contprice_gl_t";
            this.nat_ac_id_contprice_gl_t.Size = new System.Drawing.Size(183, 14);
            this.nat_ac_id_contprice_gl_t.TabIndex = 3;
            this.nat_ac_id_contprice_gl_t.Text = "Contract Price Account for GL:";
            this.nat_ac_id_contprice_gl_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_ac_id_accrualbalance_gl_t
            // 
            this.nat_ac_id_accrualbalance_gl_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_ac_id_accrualbalance_gl_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_ac_id_accrualbalance_gl_t.ForeColor = System.Drawing.Color.Black;
            this.nat_ac_id_accrualbalance_gl_t.Location = new System.Drawing.Point(-2, 125);
            this.nat_ac_id_accrualbalance_gl_t.Name = "nat_ac_id_accrualbalance_gl_t";
            this.nat_ac_id_accrualbalance_gl_t.Size = new System.Drawing.Size(202, 16);
            this.nat_ac_id_accrualbalance_gl_t.TabIndex = 1;
            this.nat_ac_id_accrualbalance_gl_t.Text = "Balancing Account - Accruals for GL:";
            this.nat_ac_id_accrualbalance_gl_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_pbu_code_accrualbalance_g
            // 
            this.nat_pbu_code_accrualbalance_g.AutoRetrieve = true;
            this.nat_pbu_code_accrualbalance_g.BackColor = System.Drawing.Color.White;
            this.nat_pbu_code_accrualbalance_g.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatPbuCodeAccrualbalanceGl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_pbu_code_accrualbalance_g.DisplayMember = "PbuDescription";
            this.nat_pbu_code_accrualbalance_g.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_pbu_code_accrualbalance_g.DropDownWidth = 273;
            this.nat_pbu_code_accrualbalance_g.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_pbu_code_accrualbalance_g.ForeColor = System.Drawing.Color.Black;
            this.nat_pbu_code_accrualbalance_g.Location = new System.Drawing.Point(203, 232);
            this.nat_pbu_code_accrualbalance_g.Name = "nat_pbu_code_accrualbalance_g";
            this.nat_pbu_code_accrualbalance_g.Size = new System.Drawing.Size(109, 22);
            this.nat_pbu_code_accrualbalance_g.TabIndex = 110;
            this.nat_pbu_code_accrualbalance_g.Value = null;
            this.nat_pbu_code_accrualbalance_g.ValueMember = "PbuId";
            this.nat_pbu_code_accrualbalance_g.Click += new EventHandler(PbuCodes_Click);
            this.nat_pbu_code_accrualbalance_g.LostFocus += new EventHandler(PbuCodes_LostFocus);
            this.nat_pbu_code_accrualbalance_g.SelectedIndexChanged += new EventHandler(PbuCodes_SelectedIndexChanged);
            // 
            // nat_ac_id_netpay_gl_t
            // 
            this.nat_ac_id_netpay_gl_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_ac_id_netpay_gl_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_ac_id_netpay_gl_t.ForeColor = System.Drawing.Color.Black;
            this.nat_ac_id_netpay_gl_t.Location = new System.Drawing.Point(18, 104);
            this.nat_ac_id_netpay_gl_t.Name = "nat_ac_id_netpay_gl_t";
            this.nat_ac_id_netpay_gl_t.Size = new System.Drawing.Size(183, 14);
            this.nat_ac_id_netpay_gl_t.TabIndex = 2;
            this.nat_ac_id_netpay_gl_t.Text = "Net Pay Account for GL:";
            this.nat_ac_id_netpay_gl_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_pbu_code_netpay_gl
            // 
            this.nat_pbu_code_netpay_gl.AutoRetrieve = true;
            this.nat_pbu_code_netpay_gl.BackColor = System.Drawing.Color.White;
            this.nat_pbu_code_netpay_gl.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatPbuCodeNetpayGl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_pbu_code_netpay_gl.DisplayMember = "PbuDescription";
            this.nat_pbu_code_netpay_gl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_pbu_code_netpay_gl.DropDownWidth = 273;
            this.nat_pbu_code_netpay_gl.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_pbu_code_netpay_gl.ForeColor = System.Drawing.Color.Black;
            this.nat_pbu_code_netpay_gl.Location = new System.Drawing.Point(203, 210);
            this.nat_pbu_code_netpay_gl.Name = "nat_pbu_code_netpay_gl";
            this.nat_pbu_code_netpay_gl.Size = new System.Drawing.Size(109, 22);
            this.nat_pbu_code_netpay_gl.TabIndex = 100;
            this.nat_pbu_code_netpay_gl.Value = null;
            this.nat_pbu_code_netpay_gl.ValueMember = "PbuId";
            this.nat_pbu_code_netpay_gl.Click += new EventHandler(PbuCodes_Click);
            this.nat_pbu_code_netpay_gl.LostFocus += new EventHandler(PbuCodes_LostFocus);
            this.nat_pbu_code_netpay_gl.SelectedIndexChanged += new EventHandler(PbuCodes_SelectedIndexChanged);
            // 
            // nat_pbu_code_gst_gl
            // 
            this.nat_pbu_code_gst_gl.AutoRetrieve = true;
            this.nat_pbu_code_gst_gl.BackColor = System.Drawing.Color.White;
            this.nat_pbu_code_gst_gl.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatPbuCodeGstGl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_pbu_code_gst_gl.DisplayMember = "PbuDescription";
            this.nat_pbu_code_gst_gl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_pbu_code_gst_gl.DropDownWidth = 273;
            this.nat_pbu_code_gst_gl.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_pbu_code_gst_gl.ForeColor = System.Drawing.Color.Black;
            this.nat_pbu_code_gst_gl.Location = new System.Drawing.Point(203, 188);
            this.nat_pbu_code_gst_gl.Name = "nat_pbu_code_gst_gl";
            this.nat_pbu_code_gst_gl.Size = new System.Drawing.Size(109, 22);
            this.nat_pbu_code_gst_gl.TabIndex = 90;
            this.nat_pbu_code_gst_gl.Value = null;
            this.nat_pbu_code_gst_gl.ValueMember = "PbuId";
            this.nat_pbu_code_gst_gl.Click += new EventHandler(PbuCodes_Click);
            this.nat_pbu_code_gst_gl.LostFocus += new EventHandler(PbuCodes_LostFocus);
            this.nat_pbu_code_gst_gl.SelectedIndexChanged += new EventHandler(PbuCodes_SelectedIndexChanged);
            // 
            // nat_ac_id_postax_adj_gl_t
            // 
            this.nat_ac_id_postax_adj_gl_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_ac_id_postax_adj_gl_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_ac_id_postax_adj_gl_t.ForeColor = System.Drawing.Color.Black;
            this.nat_ac_id_postax_adj_gl_t.Location = new System.Drawing.Point(18, 61);
            this.nat_ac_id_postax_adj_gl_t.Name = "nat_ac_id_postax_adj_gl_t";
            this.nat_ac_id_postax_adj_gl_t.Size = new System.Drawing.Size(183, 14);
            this.nat_ac_id_postax_adj_gl_t.TabIndex = 4;
            this.nat_ac_id_postax_adj_gl_t.Text = "Postax Adj Account for GL:";
            this.nat_ac_id_postax_adj_gl_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_pbu_code_whtax_gl
            // 
            this.nat_pbu_code_whtax_gl.AutoRetrieve = true;
            this.nat_pbu_code_whtax_gl.BackColor = System.Drawing.Color.White;
            this.nat_pbu_code_whtax_gl.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatPbuCodeWhtaxGl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_pbu_code_whtax_gl.DisplayMember = "PbuDescription";
            this.nat_pbu_code_whtax_gl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_pbu_code_whtax_gl.DropDownWidth = 273;
            this.nat_pbu_code_whtax_gl.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_pbu_code_whtax_gl.ForeColor = System.Drawing.Color.Black;
            this.nat_pbu_code_whtax_gl.Location = new System.Drawing.Point(203, 166);
            this.nat_pbu_code_whtax_gl.Name = "nat_pbu_code_whtax_gl";
            this.nat_pbu_code_whtax_gl.Size = new System.Drawing.Size(109, 22);
            this.nat_pbu_code_whtax_gl.TabIndex = 80;
            this.nat_pbu_code_whtax_gl.Value = null;
            this.nat_pbu_code_whtax_gl.ValueMember = "PbuId";
            this.nat_pbu_code_whtax_gl.SelectedIndexChanged += new EventHandler(PbuCodes_SelectedIndexChanged);
            this.nat_pbu_code_whtax_gl.Click += new EventHandler(PbuCodes_Click);
            this.nat_pbu_code_whtax_gl.LostFocus += new EventHandler(PbuCodes_LostFocus);
            // 
            // nat_ac_id_whtax_gl_t
            // 
            this.nat_ac_id_whtax_gl_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_ac_id_whtax_gl_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_ac_id_whtax_gl_t.ForeColor = System.Drawing.Color.Black;
            this.nat_ac_id_whtax_gl_t.Location = new System.Drawing.Point(18, 40);
            this.nat_ac_id_whtax_gl_t.Name = "nat_ac_id_whtax_gl_t";
            this.nat_ac_id_whtax_gl_t.Size = new System.Drawing.Size(183, 14);
            this.nat_ac_id_whtax_gl_t.TabIndex = 5;
            this.nat_ac_id_whtax_gl_t.Text = "Whtax Account for GL:";
            this.nat_ac_id_whtax_gl_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_pbu_code_postax_gl
            // 
            this.nat_pbu_code_postax_gl.AutoRetrieve = true;
            this.nat_pbu_code_postax_gl.BackColor = System.Drawing.Color.White;
            this.nat_pbu_code_postax_gl.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatPbuCodePostaxGl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_pbu_code_postax_gl.DisplayMember = "PbuDescription";
            this.nat_pbu_code_postax_gl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_pbu_code_postax_gl.DropDownWidth = 273;
            this.nat_pbu_code_postax_gl.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_pbu_code_postax_gl.ForeColor = System.Drawing.Color.Black;
            this.nat_pbu_code_postax_gl.Location = new System.Drawing.Point(203, 144);
            this.nat_pbu_code_postax_gl.Name = "nat_pbu_code_postax_gl";
            this.nat_pbu_code_postax_gl.Size = new System.Drawing.Size(109, 22);
            this.nat_pbu_code_postax_gl.TabIndex = 70;
            this.nat_pbu_code_postax_gl.Value = null;
            this.nat_pbu_code_postax_gl.ValueMember = "PbuId";
            this.nat_pbu_code_postax_gl.SelectedIndexChanged += new EventHandler(PbuCodes_SelectedIndexChanged);
            this.nat_pbu_code_postax_gl.LostFocus += new EventHandler(PbuCodes_LostFocus);
            this.nat_pbu_code_postax_gl.Click += new EventHandler(PbuCodes_Click);
            // 
            // nat_ac_id_gst_gl_t
            // 
            this.nat_ac_id_gst_gl_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_ac_id_gst_gl_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_ac_id_gst_gl_t.ForeColor = System.Drawing.Color.Black;
            this.nat_ac_id_gst_gl_t.Location = new System.Drawing.Point(18, 18);
            this.nat_ac_id_gst_gl_t.Name = "nat_ac_id_gst_gl_t";
            this.nat_ac_id_gst_gl_t.Size = new System.Drawing.Size(183, 14);
            this.nat_ac_id_gst_gl_t.TabIndex = 6;
            this.nat_ac_id_gst_gl_t.Text = "GST Account for GL:";
            this.nat_ac_id_gst_gl_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_ac_id_accrualbalance_gl
            // 
            this.nat_ac_id_accrualbalance_gl.AutoRetrieve = true;
            this.nat_ac_id_accrualbalance_gl.BackColor = System.Drawing.Color.White;
            this.nat_ac_id_accrualbalance_gl.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatAcIdAccrualbalanceGl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_ac_id_accrualbalance_gl.DisplayMember = "AcDescription";
            this.nat_ac_id_accrualbalance_gl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_ac_id_accrualbalance_gl.DropDownWidth = 273;
            this.nat_ac_id_accrualbalance_gl.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_ac_id_accrualbalance_gl.ForeColor = System.Drawing.Color.Black;
            this.nat_ac_id_accrualbalance_gl.Location = new System.Drawing.Point(203, 122);
            this.nat_ac_id_accrualbalance_gl.Name = "nat_ac_id_accrualbalance_gl";
            this.nat_ac_id_accrualbalance_gl.Size = new System.Drawing.Size(109, 22);
            this.nat_ac_id_accrualbalance_gl.TabIndex = 60;
            this.nat_ac_id_accrualbalance_gl.Value = null;
            this.nat_ac_id_accrualbalance_gl.ValueMember = "AcId";
            this.nat_ac_id_accrualbalance_gl.SelectedIndexChanged += new EventHandler(AccountCodes_SelectedIndexChanged);
            this.nat_ac_id_accrualbalance_gl.LostFocus += new EventHandler(AccountCodes_LostFocus);
            this.nat_ac_id_accrualbalance_gl.Click += new EventHandler(AccountCodes_Click);
            // 
            // nat_pbu_code_postax_gl_t
            // 
            this.nat_pbu_code_postax_gl_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_pbu_code_postax_gl_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_pbu_code_postax_gl_t.ForeColor = System.Drawing.Color.Black;
            this.nat_pbu_code_postax_gl_t.Location = new System.Drawing.Point(18, 148);
            this.nat_pbu_code_postax_gl_t.Name = "nat_pbu_code_postax_gl_t";
            this.nat_pbu_code_postax_gl_t.Size = new System.Drawing.Size(183, 14);
            this.nat_pbu_code_postax_gl_t.TabIndex = 7;
            this.nat_pbu_code_postax_gl_t.Text = "PBU for Post-tax Adj for GL:";
            this.nat_pbu_code_postax_gl_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_ac_id_netpay_gl
            // 
            this.nat_ac_id_netpay_gl.AutoRetrieve = true;
            this.nat_ac_id_netpay_gl.BackColor = System.Drawing.Color.White;
            this.nat_ac_id_netpay_gl.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatAcIdNetpayGl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_ac_id_netpay_gl.DisplayMember = "AcDescription";
            this.nat_ac_id_netpay_gl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_ac_id_netpay_gl.DropDownWidth = 273;
            this.nat_ac_id_netpay_gl.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_ac_id_netpay_gl.ForeColor = System.Drawing.Color.Black;
            this.nat_ac_id_netpay_gl.Location = new System.Drawing.Point(203, 100);
            this.nat_ac_id_netpay_gl.Name = "nat_ac_id_netpay_gl";
            this.nat_ac_id_netpay_gl.Size = new System.Drawing.Size(109, 22);
            this.nat_ac_id_netpay_gl.TabIndex = 50;
            this.nat_ac_id_netpay_gl.Value = null;
            this.nat_ac_id_netpay_gl.ValueMember = "AcId";
            this.nat_ac_id_netpay_gl.SelectedIndexChanged += new EventHandler(AccountCodes_SelectedIndexChanged);
            this.nat_ac_id_netpay_gl.LostFocus += new EventHandler(AccountCodes_LostFocus);
            this.nat_ac_id_netpay_gl.Click += new EventHandler(AccountCodes_Click);
            // 
            // nat_pbu_code_whtax_gl_t
            // 
            this.nat_pbu_code_whtax_gl_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_pbu_code_whtax_gl_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_pbu_code_whtax_gl_t.ForeColor = System.Drawing.Color.Black;
            this.nat_pbu_code_whtax_gl_t.Location = new System.Drawing.Point(18, 171);
            this.nat_pbu_code_whtax_gl_t.Name = "nat_pbu_code_whtax_gl_t";
            this.nat_pbu_code_whtax_gl_t.Size = new System.Drawing.Size(183, 14);
            this.nat_pbu_code_whtax_gl_t.TabIndex = 8;
            this.nat_pbu_code_whtax_gl_t.Text = "PBU for Witholding tax for GL:";
            this.nat_pbu_code_whtax_gl_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_ac_id_contprice_gl
            // 
            this.nat_ac_id_contprice_gl.AutoRetrieve = true;
            this.nat_ac_id_contprice_gl.BackColor = System.Drawing.Color.White;
            this.nat_ac_id_contprice_gl.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatAcIdContpriceGl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_ac_id_contprice_gl.DisplayMember = "AcDescription";
            this.nat_ac_id_contprice_gl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_ac_id_contprice_gl.DropDownWidth = 273;
            this.nat_ac_id_contprice_gl.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_ac_id_contprice_gl.ForeColor = System.Drawing.Color.Black;
            this.nat_ac_id_contprice_gl.Location = new System.Drawing.Point(203, 78);
            this.nat_ac_id_contprice_gl.Name = "nat_ac_id_contprice_gl";
            this.nat_ac_id_contprice_gl.Size = new System.Drawing.Size(109, 22);
            this.nat_ac_id_contprice_gl.TabIndex = 40;
            this.nat_ac_id_contprice_gl.Value = null;
            this.nat_ac_id_contprice_gl.ValueMember = "AcId";
            this.nat_ac_id_contprice_gl.SelectedIndexChanged += new EventHandler(AccountCodes_SelectedIndexChanged);
            this.nat_ac_id_contprice_gl.LostFocus += new EventHandler(AccountCodes_LostFocus);
            this.nat_ac_id_contprice_gl.Click += new EventHandler(AccountCodes_Click);
            // 
            // nat_pbu_code_gst_gl_t
            // 
            this.nat_pbu_code_gst_gl_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_pbu_code_gst_gl_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_pbu_code_gst_gl_t.ForeColor = System.Drawing.Color.Black;
            this.nat_pbu_code_gst_gl_t.Location = new System.Drawing.Point(18, 193);
            this.nat_pbu_code_gst_gl_t.Name = "nat_pbu_code_gst_gl_t";
            this.nat_pbu_code_gst_gl_t.Size = new System.Drawing.Size(183, 14);
            this.nat_pbu_code_gst_gl_t.TabIndex = 9;
            this.nat_pbu_code_gst_gl_t.Text = "PBU for GST for GL:";
            this.nat_pbu_code_gst_gl_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_ac_id_postax_adj_gl
            // 
            this.nat_ac_id_postax_adj_gl.AutoRetrieve = true;
            this.nat_ac_id_postax_adj_gl.BackColor = System.Drawing.Color.White;
            this.nat_ac_id_postax_adj_gl.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatAcIdPostaxAdjGl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_ac_id_postax_adj_gl.DisplayMember = "AcDescription";
            this.nat_ac_id_postax_adj_gl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_ac_id_postax_adj_gl.DropDownWidth = 273;
            this.nat_ac_id_postax_adj_gl.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_ac_id_postax_adj_gl.ForeColor = System.Drawing.Color.Black;
            this.nat_ac_id_postax_adj_gl.Location = new System.Drawing.Point(203, 56);
            this.nat_ac_id_postax_adj_gl.Name = "nat_ac_id_postax_adj_gl";
            this.nat_ac_id_postax_adj_gl.Size = new System.Drawing.Size(109, 22);
            this.nat_ac_id_postax_adj_gl.TabIndex = 30;
            this.nat_ac_id_postax_adj_gl.Value = null;
            this.nat_ac_id_postax_adj_gl.ValueMember = "AcId";
            this.nat_ac_id_postax_adj_gl.SelectedIndexChanged += new EventHandler(AccountCodes_SelectedIndexChanged);
            this.nat_ac_id_postax_adj_gl.LostFocus += new EventHandler(AccountCodes_LostFocus);
            this.nat_ac_id_postax_adj_gl.Click += new EventHandler(AccountCodes_Click);
            // 
            // nat_pbu_code_netpay_gl_t
            // 
            this.nat_pbu_code_netpay_gl_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_pbu_code_netpay_gl_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_pbu_code_netpay_gl_t.ForeColor = System.Drawing.Color.Black;
            this.nat_pbu_code_netpay_gl_t.Location = new System.Drawing.Point(18, 214);
            this.nat_pbu_code_netpay_gl_t.Name = "nat_pbu_code_netpay_gl_t";
            this.nat_pbu_code_netpay_gl_t.Size = new System.Drawing.Size(183, 14);
            this.nat_pbu_code_netpay_gl_t.TabIndex = 10;
            this.nat_pbu_code_netpay_gl_t.Text = "PBU for Net Pay for GL:";
            this.nat_pbu_code_netpay_gl_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_1
            // 
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_1.Font = new System.Drawing.Font("Arial", 8F);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(18, 236);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(183, 14);
            this.t_1.TabIndex = 10;
            this.t_1.Text = "PBU Accrual balance for GL:";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_ac_id_whtax_gl
            // 
            this.nat_ac_id_whtax_gl.AutoRetrieve = true;
            this.nat_ac_id_whtax_gl.BackColor = System.Drawing.Color.White;
            this.nat_ac_id_whtax_gl.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatAcIdWhtaxGl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_ac_id_whtax_gl.DisplayMember = "AcDescription";
            this.nat_ac_id_whtax_gl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_ac_id_whtax_gl.DropDownWidth = 273;
            this.nat_ac_id_whtax_gl.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_ac_id_whtax_gl.ForeColor = System.Drawing.Color.Black;
            this.nat_ac_id_whtax_gl.Location = new System.Drawing.Point(203, 34);
            this.nat_ac_id_whtax_gl.Name = "nat_ac_id_whtax_gl";
            this.nat_ac_id_whtax_gl.Size = new System.Drawing.Size(109, 22);
            this.nat_ac_id_whtax_gl.TabIndex = 20;
            this.nat_ac_id_whtax_gl.Value = null;
            this.nat_ac_id_whtax_gl.ValueMember = "AcId";
            this.nat_ac_id_whtax_gl.SelectedIndexChanged += new EventHandler(AccountCodes_SelectedIndexChanged);
            this.nat_ac_id_whtax_gl.LostFocus += new EventHandler(AccountCodes_LostFocus);
            this.nat_ac_id_whtax_gl.Click += new EventHandler(AccountCodes_Click);
            // 
            // nat_ac_id_gst_gl
            // 
            this.nat_ac_id_gst_gl.AutoRetrieve = true;
            this.nat_ac_id_gst_gl.BackColor = System.Drawing.Color.White;
            this.nat_ac_id_gst_gl.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatAcIdGstGl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_ac_id_gst_gl.DisplayMember = "AcDescription";
            this.nat_ac_id_gst_gl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_ac_id_gst_gl.DropDownWidth = 273;
            this.nat_ac_id_gst_gl.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_ac_id_gst_gl.ForeColor = System.Drawing.Color.Black;
            this.nat_ac_id_gst_gl.Location = new System.Drawing.Point(203, 12);
            this.nat_ac_id_gst_gl.Name = "nat_ac_id_gst_gl";
            this.nat_ac_id_gst_gl.Size = new System.Drawing.Size(109, 22);
            this.nat_ac_id_gst_gl.TabIndex = 10;
            this.nat_ac_id_gst_gl.Value = null;
            this.nat_ac_id_gst_gl.ValueMember = "AcId";
            this.nat_ac_id_gst_gl.Click += new EventHandler(AccountCodes_Click);
            this.nat_ac_id_gst_gl.LostFocus += new EventHandler(AccountCodes_LostFocus);
            this.nat_ac_id_gst_gl.SelectedIndexChanged += new EventHandler(AccountCodes_SelectedIndexChanged);
            // 
            // t_3
            // 
            this.t_3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_3.Font = new System.Drawing.Font("Arial", 8F);
            this.t_3.ForeColor = System.Drawing.Color.Black;
            this.t_3.Location = new System.Drawing.Point(18, 21);
            this.t_3.Name = "t_3";
            this.t_3.Size = new System.Drawing.Size(183, 14);
            this.t_3.TabIndex = 6;
            this.t_3.Text = "Frequency adjustment:";
            this.t_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_7
            // 
            this.t_7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_7.Font = new System.Drawing.Font("Arial", 8F);
            this.t_7.ForeColor = System.Drawing.Color.Black;
            this.t_7.Location = new System.Drawing.Point(18, 44);
            this.t_7.Name = "t_7";
            this.t_7.Size = new System.Drawing.Size(183, 14);
            this.t_7.TabIndex = 6;
            this.t_7.Text = "Contract adjustment:";
            this.t_7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_6
            // 
            this.t_6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_6.Font = new System.Drawing.Font("Arial", 8F);
            this.t_6.ForeColor = System.Drawing.Color.Black;
            this.t_6.Location = new System.Drawing.Point(18, 65);
            this.t_6.Name = "t_6";
            this.t_6.Size = new System.Drawing.Size(183, 14);
            this.t_6.TabIndex = 6;
            this.t_6.Text = "Contract allowance:";
            this.t_6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_5
            // 
            this.t_5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_5.Font = new System.Drawing.Font("Arial", 8F);
            this.t_5.ForeColor = System.Drawing.Color.Black;
            this.t_5.Location = new System.Drawing.Point(18, 87);
            this.t_5.Name = "t_5";
            this.t_5.Size = new System.Drawing.Size(183, 14);
            this.t_5.TabIndex = 6;
            this.t_5.Text = "Deductions:";
            this.t_5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_4
            // 
            this.t_4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_4.Font = new System.Drawing.Font("Arial", 8F);
            this.t_4.ForeColor = System.Drawing.Color.Black;
            this.t_4.Location = new System.Drawing.Point(18, 109);
            this.t_4.Name = "t_4";
            this.t_4.Size = new System.Drawing.Size(183, 14);
            this.t_4.TabIndex = 6;
            this.t_4.Text = "Courierpost:";
            this.t_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_2
            // 
            this.t_2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_2.Font = new System.Drawing.Font("Arial", 8F);
            this.t_2.ForeColor = System.Drawing.Color.Black;
            this.t_2.Location = new System.Drawing.Point(18, 131);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(183, 14);
            this.t_2.TabIndex = 6;
            this.t_2.Text = "Kiwimail:";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_8
            // 
            this.t_8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_8.Font = new System.Drawing.Font("Arial", 8F);
            this.t_8.ForeColor = System.Drawing.Color.Black;
            this.t_8.Location = new System.Drawing.Point(18, 152);
            this.t_8.Name = "t_8";
            this.t_8.Size = new System.Drawing.Size(183, 14);
            this.t_8.TabIndex = 6;
            this.t_8.Text = "Default account code for contracts:";
            this.t_8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_2
            // 
            this.gb_2.Controls.Add(this.nat_gst_rate_t);
            this.gb_2.Controls.Add(this.nat_gst_rate);
            this.gb_2.Controls.Add(this.nat_ird_no);
            this.gb_2.Controls.Add(this.nat_rural_post_gst_no);
            this.gb_2.Controls.Add(this.nat_od_standard_gst_rate);
            this.gb_2.Controls.Add(this.nat_rural_post_address);
            this.gb_2.Controls.Add(this.nat_od_tax_rate_ir13);
            this.gb_2.Controls.Add(this.nat_rural_post_payer_name_t);
            this.gb_2.Controls.Add(this.nat_rural_post_gst_no_t);
            this.gb_2.Controls.Add(this.nat_message_for_invoice_t);
            this.gb_2.Controls.Add(this.nat_message_for_invoice);
            this.gb_2.Controls.Add(this.nat_ird_no_t);
            this.gb_2.Controls.Add(this.nat_rural_post_address_t);
            this.gb_2.Controls.Add(this.nat_od_standard_gst_rate_t);
            this.gb_2.Controls.Add(this.nat_rural_post_payer_name);
            this.gb_2.Controls.Add(this.nat_od_tax_rate_ir13_t);
            this.gb_2.Controls.Add(this.nat_od_tax_rate_no_ir13);
            this.gb_2.Controls.Add(this.nat_od_tax_rate_no_ir13_t);
            this.gb_2.Font = new System.Drawing.Font("Arial", 8F);
            this.gb_2.Location = new System.Drawing.Point(344, 14);
            this.gb_2.Name = "gb_2";
            this.gb_2.Size = new System.Drawing.Size(435, 259);
            this.gb_2.TabIndex = 0;
            this.gb_2.TabStop = false;
            this.gb_2.Text = "NZ Post Information:";
            // 
            // nat_gst_rate_t
            // 
            this.nat_gst_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_gst_rate_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_gst_rate_t.ForeColor = System.Drawing.Color.Black;
            this.nat_gst_rate_t.Location = new System.Drawing.Point(21, 43);
            this.nat_gst_rate_t.Name = "nat_gst_rate_t";
            this.nat_gst_rate_t.Size = new System.Drawing.Size(194, 14);
            this.nat_gst_rate_t.TabIndex = 162;
            this.nat_gst_rate_t.Text = "Standard GST Rate:";
            this.nat_gst_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_gst_rate
            // 
            this.nat_gst_rate.BackColor = System.Drawing.Color.White;
            this.nat_gst_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatGstRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_gst_rate.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_gst_rate.ForeColor = System.Drawing.Color.Black;
            this.nat_gst_rate.Location = new System.Drawing.Point(221, 33);
            this.nat_gst_rate.MaxLength = 0;
            this.nat_gst_rate.Name = "nat_gst_rate";
            this.nat_gst_rate.Size = new System.Drawing.Size(109, 20);
            this.nat_gst_rate.TabIndex = 130;
            // 
            // nat_ird_no
            // 
            this.nat_ird_no.BackColor = System.Drawing.Color.White;
            this.nat_ird_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatIrdNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_ird_no.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_ird_no.ForeColor = System.Drawing.Color.Black;
            this.nat_ird_no.Location = new System.Drawing.Point(221, 55);
            this.nat_ird_no.MaxLength = 20;
            this.nat_ird_no.Name = "nat_ird_no";
            this.nat_ird_no.Size = new System.Drawing.Size(109, 20);
            this.nat_ird_no.TabIndex = 140;
            // 
            // nat_rural_post_gst_no
            // 
            this.nat_rural_post_gst_no.BackColor = System.Drawing.Color.White;
            this.nat_rural_post_gst_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatRuralPostGstNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_rural_post_gst_no.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_rural_post_gst_no.ForeColor = System.Drawing.Color.Black;
            this.nat_rural_post_gst_no.Location = new System.Drawing.Point(221, 11);
            this.nat_rural_post_gst_no.MaxLength = 20;
            this.nat_rural_post_gst_no.Name = "nat_rural_post_gst_no";
            this.nat_rural_post_gst_no.Size = new System.Drawing.Size(109, 20);
            this.nat_rural_post_gst_no.TabIndex = 120;
            // 
            // nat_od_standard_gst_rate
            // 
            this.nat_od_standard_gst_rate.BackColor = System.Drawing.Color.White;
            this.nat_od_standard_gst_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatOdStandardGstRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_od_standard_gst_rate.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_od_standard_gst_rate.ForeColor = System.Drawing.Color.Black;
            this.nat_od_standard_gst_rate.Location = new System.Drawing.Point(221, 77);
            this.nat_od_standard_gst_rate.MaxLength = 0;
            this.nat_od_standard_gst_rate.Name = "nat_od_standard_gst_rate";
            this.nat_od_standard_gst_rate.Size = new System.Drawing.Size(109, 20);
            this.nat_od_standard_gst_rate.TabIndex = 150;
            this.nat_od_standard_gst_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nat_rural_post_address
            // 
            this.nat_rural_post_address.BackColor = System.Drawing.Color.White;
            this.nat_rural_post_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatRuralPostAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_rural_post_address.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_rural_post_address.ForeColor = System.Drawing.Color.Black;
            this.nat_rural_post_address.Location = new System.Drawing.Point(221, 168);
            this.nat_rural_post_address.MaxLength = 200;
            this.nat_rural_post_address.Name = "nat_rural_post_address";
            this.nat_rural_post_address.Size = new System.Drawing.Size(202, 40);
            this.nat_rural_post_address.TabIndex = 190;
            // 
            // nat_od_tax_rate_ir13
            // 
            this.nat_od_tax_rate_ir13.BackColor = System.Drawing.Color.White;
            this.nat_od_tax_rate_ir13.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatOdTaxRateIr13", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_od_tax_rate_ir13.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_od_tax_rate_ir13.ForeColor = System.Drawing.Color.Black;
            this.nat_od_tax_rate_ir13.Location = new System.Drawing.Point(221, 99);
            this.nat_od_tax_rate_ir13.MaxLength = 0;
            this.nat_od_tax_rate_ir13.Name = "nat_od_tax_rate_ir13";
            this.nat_od_tax_rate_ir13.Size = new System.Drawing.Size(109, 20);
            this.nat_od_tax_rate_ir13.TabIndex = 160;
            this.nat_od_tax_rate_ir13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nat_rural_post_payer_name_t
            // 
            this.nat_rural_post_payer_name_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_rural_post_payer_name_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_rural_post_payer_name_t.ForeColor = System.Drawing.Color.Black;
            this.nat_rural_post_payer_name_t.Location = new System.Drawing.Point(21, 147);
            this.nat_rural_post_payer_name_t.Name = "nat_rural_post_payer_name_t";
            this.nat_rural_post_payer_name_t.Size = new System.Drawing.Size(194, 14);
            this.nat_rural_post_payer_name_t.TabIndex = 202;
            this.nat_rural_post_payer_name_t.Text = "Rural Post Payer Name:";
            this.nat_rural_post_payer_name_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_rural_post_gst_no_t
            // 
            this.nat_rural_post_gst_no_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_rural_post_gst_no_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_rural_post_gst_no_t.ForeColor = System.Drawing.Color.Black;
            this.nat_rural_post_gst_no_t.Location = new System.Drawing.Point(21, 18);
            this.nat_rural_post_gst_no_t.Name = "nat_rural_post_gst_no_t";
            this.nat_rural_post_gst_no_t.Size = new System.Drawing.Size(194, 14);
            this.nat_rural_post_gst_no_t.TabIndex = 161;
            this.nat_rural_post_gst_no_t.Text = "Rural Post GST No:";
            this.nat_rural_post_gst_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_message_for_invoice_t
            // 
            this.nat_message_for_invoice_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_message_for_invoice_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_message_for_invoice_t.ForeColor = System.Drawing.Color.Black;
            this.nat_message_for_invoice_t.Location = new System.Drawing.Point(125, 210);
            this.nat_message_for_invoice_t.Name = "nat_message_for_invoice_t";
            this.nat_message_for_invoice_t.Size = new System.Drawing.Size(90, 34);
            this.nat_message_for_invoice_t.TabIndex = 201;
            this.nat_message_for_invoice_t.Text = "Default Message For Invoice:";
            this.nat_message_for_invoice_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_message_for_invoice
            // 
            this.nat_message_for_invoice.BackColor = System.Drawing.Color.White;
            this.nat_message_for_invoice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatMessageForInvoice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_message_for_invoice.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_message_for_invoice.ForeColor = System.Drawing.Color.Black;
            this.nat_message_for_invoice.Location = new System.Drawing.Point(221, 213);
            this.nat_message_for_invoice.MaxLength = 1000;
            this.nat_message_for_invoice.Name = "nat_message_for_invoice";
            this.nat_message_for_invoice.Size = new System.Drawing.Size(202, 40);
            this.nat_message_for_invoice.TabIndex = 200;
            // 
            // nat_ird_no_t
            // 
            this.nat_ird_no_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_ird_no_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_ird_no_t.ForeColor = System.Drawing.Color.Black;
            this.nat_ird_no_t.Location = new System.Drawing.Point(21, 61);
            this.nat_ird_no_t.Name = "nat_ird_no_t";
            this.nat_ird_no_t.Size = new System.Drawing.Size(194, 14);
            this.nat_ird_no_t.TabIndex = 163;
            this.nat_ird_no_t.Text = "NZ Post IRD No:";
            this.nat_ird_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_rural_post_address_t
            // 
            this.nat_rural_post_address_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_rural_post_address_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_rural_post_address_t.ForeColor = System.Drawing.Color.Black;
            this.nat_rural_post_address_t.Location = new System.Drawing.Point(148, 164);
            this.nat_rural_post_address_t.Name = "nat_rural_post_address_t";
            this.nat_rural_post_address_t.Size = new System.Drawing.Size(67, 40);
            this.nat_rural_post_address_t.TabIndex = 181;
            this.nat_rural_post_address_t.Text = "Rural Post Address:";
            this.nat_rural_post_address_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_od_standard_gst_rate_t
            // 
            this.nat_od_standard_gst_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_od_standard_gst_rate_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_od_standard_gst_rate_t.ForeColor = System.Drawing.Color.Black;
            this.nat_od_standard_gst_rate_t.Location = new System.Drawing.Point(21, 82);
            this.nat_od_standard_gst_rate_t.Name = "nat_od_standard_gst_rate_t";
            this.nat_od_standard_gst_rate_t.Size = new System.Drawing.Size(194, 14);
            this.nat_od_standard_gst_rate_t.TabIndex = 164;
            this.nat_od_standard_gst_rate_t.Text = "Standard GST Rate for Owner Driver:";
            this.nat_od_standard_gst_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_rural_post_payer_name
            // 
            this.nat_rural_post_payer_name.BackColor = System.Drawing.Color.White;
            this.nat_rural_post_payer_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatRuralPostPayerName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_rural_post_payer_name.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_rural_post_payer_name.ForeColor = System.Drawing.Color.Black;
            this.nat_rural_post_payer_name.Location = new System.Drawing.Point(221, 144);
            this.nat_rural_post_payer_name.MaxLength = 200;
            this.nat_rural_post_payer_name.Name = "nat_rural_post_payer_name";
            this.nat_rural_post_payer_name.Size = new System.Drawing.Size(109, 20);
            this.nat_rural_post_payer_name.TabIndex = 180;
            // 
            // nat_od_tax_rate_ir13_t
            // 
            this.nat_od_tax_rate_ir13_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_od_tax_rate_ir13_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_od_tax_rate_ir13_t.ForeColor = System.Drawing.Color.Black;
            this.nat_od_tax_rate_ir13_t.Location = new System.Drawing.Point(21, 103);
            this.nat_od_tax_rate_ir13_t.Name = "nat_od_tax_rate_ir13_t";
            this.nat_od_tax_rate_ir13_t.Size = new System.Drawing.Size(194, 14);
            this.nat_od_tax_rate_ir13_t.TabIndex = 165;
            this.nat_od_tax_rate_ir13_t.Text = "Standard Tax Rate for O/D with IR13:";
            this.nat_od_tax_rate_ir13_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_od_tax_rate_no_ir13
            // 
            this.nat_od_tax_rate_no_ir13.BackColor = System.Drawing.Color.White;
            this.nat_od_tax_rate_no_ir13.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatOdTaxRateNoIr13", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_od_tax_rate_no_ir13.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_od_tax_rate_no_ir13.ForeColor = System.Drawing.Color.Black;
            this.nat_od_tax_rate_no_ir13.Location = new System.Drawing.Point(221, 122);
            this.nat_od_tax_rate_no_ir13.MaxLength = 0;
            this.nat_od_tax_rate_no_ir13.Name = "nat_od_tax_rate_no_ir13";
            this.nat_od_tax_rate_no_ir13.Size = new System.Drawing.Size(109, 20);
            this.nat_od_tax_rate_no_ir13.TabIndex = 170;
            this.nat_od_tax_rate_no_ir13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nat_od_tax_rate_no_ir13_t
            // 
            this.nat_od_tax_rate_no_ir13_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_od_tax_rate_no_ir13_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_od_tax_rate_no_ir13_t.ForeColor = System.Drawing.Color.Black;
            this.nat_od_tax_rate_no_ir13_t.Location = new System.Drawing.Point(11, 124);
            this.nat_od_tax_rate_no_ir13_t.Name = "nat_od_tax_rate_no_ir13_t";
            this.nat_od_tax_rate_no_ir13_t.Size = new System.Drawing.Size(202, 18);
            this.nat_od_tax_rate_no_ir13_t.TabIndex = 166;
            this.nat_od_tax_rate_no_ir13_t.Text = "Standard Tax Rate for O/D without IR13:";
            this.nat_od_tax_rate_no_ir13_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_3
            // 
            this.gb_3.Controls.Add(this.nat_freqadj_defaultcomptype);
            this.gb_3.Controls.Add(this.nat_deductions_defaultcomptyp);
            this.gb_3.Controls.Add(this.ac_id);
            this.gb_3.Controls.Add(this.nat_adpost_defaultcomptype);
            this.gb_3.Controls.Add(this.nat_contallow_defaultcomptype);
            this.gb_3.Controls.Add(this.nat_contadj_defaultcomptype);
            this.gb_3.Controls.Add(this.nat_courierpost_defaultcompty);
            this.gb_3.Controls.Add(this.t_3);
            this.gb_3.Controls.Add(this.t_7);
            this.gb_3.Controls.Add(this.t_6);
            this.gb_3.Controls.Add(this.t_5);
            this.gb_3.Controls.Add(this.t_4);
            this.gb_3.Controls.Add(this.t_2);
            this.gb_3.Controls.Add(this.t_8);
            this.gb_3.Font = new System.Drawing.Font("Arial", 8F);
            this.gb_3.Location = new System.Drawing.Point(16, 279);
            this.gb_3.Name = "gb_3";
            this.gb_3.Size = new System.Drawing.Size(321, 171);
            this.gb_3.TabIndex = 0;
            this.gb_3.TabStop = false;
            this.gb_3.Text = "Default payment components:";
            // 
            // nat_freqadj_defaultcomptype
            // 
            this.nat_freqadj_defaultcomptype.AutoRetrieve = true;
            this.nat_freqadj_defaultcomptype.BackColor = System.Drawing.Color.White;
            this.nat_freqadj_defaultcomptype.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatFreqadjDefaultcomptype", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_freqadj_defaultcomptype.DisplayMember = "PctDescription";
            this.nat_freqadj_defaultcomptype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_freqadj_defaultcomptype.DropDownWidth = 273;
            this.nat_freqadj_defaultcomptype.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_freqadj_defaultcomptype.ForeColor = System.Drawing.Color.Black;
            this.nat_freqadj_defaultcomptype.Location = new System.Drawing.Point(204, 12);
            this.nat_freqadj_defaultcomptype.Name = "nat_freqadj_defaultcomptype";
            this.nat_freqadj_defaultcomptype.Size = new System.Drawing.Size(109, 22);
            this.nat_freqadj_defaultcomptype.TabIndex = 210;
            this.nat_freqadj_defaultcomptype.Value = null;
            this.nat_freqadj_defaultcomptype.ValueMember = "PctId";
            // 
            // nat_deductions_defaultcomptyp
            // 
            this.nat_deductions_defaultcomptyp.AutoRetrieve = true;
            this.nat_deductions_defaultcomptyp.BackColor = System.Drawing.Color.White;
            this.nat_deductions_defaultcomptyp.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatDeductionsDefaultcomptyp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_deductions_defaultcomptyp.DisplayMember = "PctDescription";
            this.nat_deductions_defaultcomptyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_deductions_defaultcomptyp.DropDownWidth = 270;
            this.nat_deductions_defaultcomptyp.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_deductions_defaultcomptyp.ForeColor = System.Drawing.Color.Black;
            this.nat_deductions_defaultcomptyp.Location = new System.Drawing.Point(204, 78);
            this.nat_deductions_defaultcomptyp.Name = "nat_deductions_defaultcomptyp";
            this.nat_deductions_defaultcomptyp.Size = new System.Drawing.Size(109, 22);
            this.nat_deductions_defaultcomptyp.TabIndex = 240;
            this.nat_deductions_defaultcomptyp.Value = null;
            this.nat_deductions_defaultcomptyp.ValueMember = "PctId";
            // 
            // ac_id
            // 
            this.ac_id.AutoRetrieve = true;
            this.ac_id.BackColor = System.Drawing.Color.White;
            this.ac_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "AcId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_id.DisplayMember = "AcDescription";
            this.ac_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ac_id.DropDownWidth = 109;
            this.ac_id.Font = new System.Drawing.Font("Arial", 8F);
            this.ac_id.ForeColor = System.Drawing.Color.Black;
            this.ac_id.Location = new System.Drawing.Point(204, 144);
            this.ac_id.Name = "ac_id";
            this.ac_id.Size = new System.Drawing.Size(109, 22);
            this.ac_id.TabIndex = 340;
            this.ac_id.Value = null;
            this.ac_id.ValueMember = "AcId";
            this.ac_id.SelectedIndexChanged += new EventHandler(AccountCodes_SelectedIndexChanged);
            this.ac_id.LostFocus += new EventHandler(AccountCodes_LostFocus);
            this.ac_id.Click += new EventHandler(AccountCodes_Click);
            // 
            // nat_adpost_defaultcomptype
            // 
            this.nat_adpost_defaultcomptype.AutoRetrieve = true;
            this.nat_adpost_defaultcomptype.BackColor = System.Drawing.Color.White;
            this.nat_adpost_defaultcomptype.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatAdpostDefaultcomptype", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_adpost_defaultcomptype.DisplayMember = "PctDescription";
            this.nat_adpost_defaultcomptype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_adpost_defaultcomptype.DropDownWidth = 273;
            this.nat_adpost_defaultcomptype.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_adpost_defaultcomptype.ForeColor = System.Drawing.Color.Black;
            this.nat_adpost_defaultcomptype.Location = new System.Drawing.Point(204, 122);
            this.nat_adpost_defaultcomptype.Name = "nat_adpost_defaultcomptype";
            this.nat_adpost_defaultcomptype.Size = new System.Drawing.Size(109, 22);
            this.nat_adpost_defaultcomptype.TabIndex = 260;
            this.nat_adpost_defaultcomptype.Value = null;
            this.nat_adpost_defaultcomptype.ValueMember = "PctId";
            // 
            // nat_contallow_defaultcomptype
            // 
            this.nat_contallow_defaultcomptype.AutoRetrieve = true;
            this.nat_contallow_defaultcomptype.BackColor = System.Drawing.Color.White;
            this.nat_contallow_defaultcomptype.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatContallowDefaultcomptype", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_contallow_defaultcomptype.DisplayMember = "PctDescription";
            this.nat_contallow_defaultcomptype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_contallow_defaultcomptype.DropDownWidth = 273;
            this.nat_contallow_defaultcomptype.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_contallow_defaultcomptype.ForeColor = System.Drawing.Color.Black;
            this.nat_contallow_defaultcomptype.Location = new System.Drawing.Point(204, 56);
            this.nat_contallow_defaultcomptype.Name = "nat_contallow_defaultcomptype";
            this.nat_contallow_defaultcomptype.Size = new System.Drawing.Size(109, 22);
            this.nat_contallow_defaultcomptype.TabIndex = 230;
            this.nat_contallow_defaultcomptype.Value = null;
            this.nat_contallow_defaultcomptype.ValueMember = "PctId";
            // 
            // nat_contadj_defaultcomptype
            // 
            this.nat_contadj_defaultcomptype.AutoRetrieve = true;
            this.nat_contadj_defaultcomptype.BackColor = System.Drawing.Color.White;
            this.nat_contadj_defaultcomptype.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatContadjDefaultcomptype", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_contadj_defaultcomptype.DisplayMember = "PctDescription";
            this.nat_contadj_defaultcomptype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_contadj_defaultcomptype.DropDownWidth = 270;
            this.nat_contadj_defaultcomptype.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_contadj_defaultcomptype.ForeColor = System.Drawing.Color.Black;
            this.nat_contadj_defaultcomptype.Location = new System.Drawing.Point(204, 34);
            this.nat_contadj_defaultcomptype.Name = "nat_contadj_defaultcomptype";
            this.nat_contadj_defaultcomptype.Size = new System.Drawing.Size(109, 22);
            this.nat_contadj_defaultcomptype.TabIndex = 220;
            this.nat_contadj_defaultcomptype.Value = null;
            this.nat_contadj_defaultcomptype.ValueMember = "PctId";
            // 
            // nat_courierpost_defaultcompty
            // 
            this.nat_courierpost_defaultcompty.AutoRetrieve = true;
            this.nat_courierpost_defaultcompty.BackColor = System.Drawing.Color.White;
            this.nat_courierpost_defaultcompty.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "NatCourierpostDefaultcompty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_courierpost_defaultcompty.DisplayMember = "PctDescription";
            this.nat_courierpost_defaultcompty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nat_courierpost_defaultcompty.DropDownWidth = 270;
            this.nat_courierpost_defaultcompty.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_courierpost_defaultcompty.ForeColor = System.Drawing.Color.Black;
            this.nat_courierpost_defaultcompty.Location = new System.Drawing.Point(204, 100);
            this.nat_courierpost_defaultcompty.Name = "nat_courierpost_defaultcompty";
            this.nat_courierpost_defaultcompty.Size = new System.Drawing.Size(109, 22);
            this.nat_courierpost_defaultcompty.TabIndex = 250;
            this.nat_courierpost_defaultcompty.Value = null;
            this.nat_courierpost_defaultcompty.ValueMember = "PctId";
            // 
            // gb_4
            // 
            this.gb_4.Controls.Add(this.nat_seq_no_for_keys_t);
            this.gb_4.Controls.Add(this.nat_invoice_number_prefix_t);
            this.gb_4.Controls.Add(this.nat_seq_no_for_keys);
            this.gb_4.Controls.Add(this.nat_effective_date_t);
            this.gb_4.Controls.Add(this.nat_net_pct_change_warn);
            this.gb_4.Controls.Add(this.nat_acc_percentage_t);
            this.gb_4.Controls.Add(this.nat_net_pct_change_warn_t);
            this.gb_4.Controls.Add(this.nat_standard_tax_rate_t);
            this.gb_4.Controls.Add(this.nat_day_of_month);
            this.gb_4.Controls.Add(this.nat_day_of_month_t);
            this.gb_4.Controls.Add(this.nat_standard_tax_rate);
            this.gb_4.Controls.Add(this.nat_invoice_number_prefix);
            this.gb_4.Controls.Add(this.nat_acc_percentage);
            this.gb_4.Controls.Add(this.nat_effective_date);
            this.gb_4.Font = new System.Drawing.Font("Arial", 8F);
            this.gb_4.Location = new System.Drawing.Point(345, 279);
            this.gb_4.Name = "gb_4";
            this.gb_4.Size = new System.Drawing.Size(434, 171);
            this.gb_4.TabIndex = 0;
            this.gb_4.TabStop = false;
            this.gb_4.Text = "Miscellaneous Information:";
            // 
            // nat_seq_no_for_keys_t
            // 
            this.nat_seq_no_for_keys_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_seq_no_for_keys_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_seq_no_for_keys_t.ForeColor = System.Drawing.Color.Black;
            this.nat_seq_no_for_keys_t.Location = new System.Drawing.Point(18, 38);
            this.nat_seq_no_for_keys_t.Name = "nat_seq_no_for_keys_t";
            this.nat_seq_no_for_keys_t.Size = new System.Drawing.Size(194, 14);
            this.nat_seq_no_for_keys_t.TabIndex = 332;
            this.nat_seq_no_for_keys_t.Text = "Starting Seq No for Invoice:";
            this.nat_seq_no_for_keys_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_invoice_number_prefix_t
            // 
            this.nat_invoice_number_prefix_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_invoice_number_prefix_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_invoice_number_prefix_t.ForeColor = System.Drawing.Color.Black;
            this.nat_invoice_number_prefix_t.Location = new System.Drawing.Point(18, 59);
            this.nat_invoice_number_prefix_t.Name = "nat_invoice_number_prefix_t";
            this.nat_invoice_number_prefix_t.Size = new System.Drawing.Size(194, 14);
            this.nat_invoice_number_prefix_t.TabIndex = 333;
            this.nat_invoice_number_prefix_t.Text = "Invoice Number Prefix:";
            this.nat_invoice_number_prefix_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_seq_no_for_keys
            // 
            this.nat_seq_no_for_keys.BackColor = System.Drawing.Color.White;
            this.nat_seq_no_for_keys.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatSeqNoForKeys", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_seq_no_for_keys.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_seq_no_for_keys.ForeColor = System.Drawing.Color.Black;
            this.nat_seq_no_for_keys.Location = new System.Drawing.Point(216, 33);
            this.nat_seq_no_for_keys.MaxLength = 0;
            this.nat_seq_no_for_keys.Name = "nat_seq_no_for_keys";
            this.nat_seq_no_for_keys.Size = new System.Drawing.Size(109, 20);
            this.nat_seq_no_for_keys.TabIndex = 280;
            // 
            // nat_effective_date_t
            // 
            this.nat_effective_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_effective_date_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_effective_date_t.ForeColor = System.Drawing.Color.Black;
            this.nat_effective_date_t.Location = new System.Drawing.Point(18, 79);
            this.nat_effective_date_t.Name = "nat_effective_date_t";
            this.nat_effective_date_t.Size = new System.Drawing.Size(194, 14);
            this.nat_effective_date_t.TabIndex = 203;
            this.nat_effective_date_t.Text = "Effective Date:";
            this.nat_effective_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_net_pct_change_warn
            // 
            this.nat_net_pct_change_warn.BackColor = System.Drawing.Color.White;
            this.nat_net_pct_change_warn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatNetPctChangeWarn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_net_pct_change_warn.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_net_pct_change_warn.ForeColor = System.Drawing.Color.Black;
            this.nat_net_pct_change_warn.Location = new System.Drawing.Point(216, 11);
            this.nat_net_pct_change_warn.MaxLength = 0;
            this.nat_net_pct_change_warn.Name = "nat_net_pct_change_warn";
            this.nat_net_pct_change_warn.Size = new System.Drawing.Size(109, 20);
            this.nat_net_pct_change_warn.TabIndex = 270;
            this.nat_net_pct_change_warn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nat_acc_percentage_t
            // 
            this.nat_acc_percentage_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_acc_percentage_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_acc_percentage_t.ForeColor = System.Drawing.Color.Black;
            this.nat_acc_percentage_t.Location = new System.Drawing.Point(18, 100);
            this.nat_acc_percentage_t.Name = "nat_acc_percentage_t";
            this.nat_acc_percentage_t.Size = new System.Drawing.Size(194, 14);
            this.nat_acc_percentage_t.TabIndex = 204;
            this.nat_acc_percentage_t.Text = "Standard Acc Percentage:";
            this.nat_acc_percentage_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_net_pct_change_warn_t
            // 
            this.nat_net_pct_change_warn_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_net_pct_change_warn_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_net_pct_change_warn_t.ForeColor = System.Drawing.Color.Black;
            this.nat_net_pct_change_warn_t.Location = new System.Drawing.Point(18, 18);
            this.nat_net_pct_change_warn_t.Name = "nat_net_pct_change_warn_t";
            this.nat_net_pct_change_warn_t.Size = new System.Drawing.Size(194, 14);
            this.nat_net_pct_change_warn_t.TabIndex = 331;
            this.nat_net_pct_change_warn_t.Text = "Net Pay % diff before reporting:";
            this.nat_net_pct_change_warn_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_standard_tax_rate_t
            // 
            this.nat_standard_tax_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_standard_tax_rate_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_standard_tax_rate_t.ForeColor = System.Drawing.Color.Black;
            this.nat_standard_tax_rate_t.Location = new System.Drawing.Point(18, 122);
            this.nat_standard_tax_rate_t.Name = "nat_standard_tax_rate_t";
            this.nat_standard_tax_rate_t.Size = new System.Drawing.Size(194, 14);
            this.nat_standard_tax_rate_t.TabIndex = 205;
            this.nat_standard_tax_rate_t.Text = "Standard Tax Rate:";
            this.nat_standard_tax_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_day_of_month
            // 
            this.nat_day_of_month.BackColor = System.Drawing.Color.White;
            this.nat_day_of_month.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatDayOfMonth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_day_of_month.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_day_of_month.ForeColor = System.Drawing.Color.Black;
            this.nat_day_of_month.Location = new System.Drawing.Point(216, 143);
            this.nat_day_of_month.MaxLength = 0;
            this.nat_day_of_month.Name = "nat_day_of_month";
            this.nat_day_of_month.Size = new System.Drawing.Size(109, 20);
            this.nat_day_of_month.TabIndex = 330;
            // 
            // nat_day_of_month_t
            // 
            this.nat_day_of_month_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nat_day_of_month_t.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_day_of_month_t.ForeColor = System.Drawing.Color.Black;
            this.nat_day_of_month_t.Location = new System.Drawing.Point(18, 144);
            this.nat_day_of_month_t.Name = "nat_day_of_month_t";
            this.nat_day_of_month_t.Size = new System.Drawing.Size(194, 14);
            this.nat_day_of_month_t.TabIndex = 206;
            this.nat_day_of_month_t.Text = "Day of Month for Pay Period:";
            this.nat_day_of_month_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nat_standard_tax_rate
            // 
            this.nat_standard_tax_rate.BackColor = System.Drawing.Color.White;
            this.nat_standard_tax_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatStandardTaxRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_standard_tax_rate.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_standard_tax_rate.ForeColor = System.Drawing.Color.Black;
            this.nat_standard_tax_rate.Location = new System.Drawing.Point(216, 121);
            this.nat_standard_tax_rate.MaxLength = 0;
            this.nat_standard_tax_rate.Name = "nat_standard_tax_rate";
            this.nat_standard_tax_rate.Size = new System.Drawing.Size(109, 20);
            this.nat_standard_tax_rate.TabIndex = 320;
            this.nat_standard_tax_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nat_invoice_number_prefix
            // 
            this.nat_invoice_number_prefix.BackColor = System.Drawing.Color.White;
            this.nat_invoice_number_prefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatInvoiceNumberPrefix", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_invoice_number_prefix.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_invoice_number_prefix.ForeColor = System.Drawing.Color.Black;
            this.nat_invoice_number_prefix.Location = new System.Drawing.Point(216, 55);
            this.nat_invoice_number_prefix.MaxLength = 20;
            this.nat_invoice_number_prefix.Name = "nat_invoice_number_prefix";
            this.nat_invoice_number_prefix.Size = new System.Drawing.Size(109, 20);
            this.nat_invoice_number_prefix.TabIndex = 290;
            // 
            // nat_acc_percentage
            // 
            this.nat_acc_percentage.BackColor = System.Drawing.Color.White;
            this.nat_acc_percentage.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatAccPercentage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_acc_percentage.Font = new System.Drawing.Font("Arial", 8F);
            this.nat_acc_percentage.ForeColor = System.Drawing.Color.Black;
            this.nat_acc_percentage.Location = new System.Drawing.Point(216, 99);
            this.nat_acc_percentage.MaxLength = 0;
            this.nat_acc_percentage.Name = "nat_acc_percentage";
            this.nat_acc_percentage.Size = new System.Drawing.Size(109, 20);
            this.nat_acc_percentage.TabIndex = 310;
            this.nat_acc_percentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nat_effective_date
            // 
            this.nat_effective_date.BackColor = System.Drawing.Color.White;
            this.nat_effective_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NatEffectiveDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "dd/MM/yyyy"));
            this.nat_effective_date.Location = new System.Drawing.Point(216, 77);
            this.nat_effective_date.Name = "nat_effective_date";
            this.nat_effective_date.Size = new System.Drawing.Size(109, 20);
            this.nat_effective_date.TabIndex = 300;
            // 
            // DwNationalDetailDs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_4);
            this.Controls.Add(this.gb_1);
            this.Controls.Add(this.gb_3);
            this.Controls.Add(this.gb_2);
            this.Name = "DwNationalDetailDs";
            this.Size = new System.Drawing.Size(830, 530);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.gb_1.ResumeLayout(false);
            this.gb_2.ResumeLayout(false);
            this.gb_2.PerformLayout();
            this.gb_3.ResumeLayout(false);
            this.gb_4.ResumeLayout(false);
            this.gb_4.PerformLayout();
            this.ResumeLayout(false);

        }

        void PbuCodes_Click(object sender, EventArgs e)
        {
            Metex.Windows.DataEntityCombo PbuCodes = (Metex.Windows.DataEntityCombo)sender;
            if (PbuCodes.DroppedDown)
            {
                PbuCodes.DisplayMember = "";
            }
            else
            {
                PbuCodes.DisplayMember = "PbuDescription";
            }
        }

        void PbuCodes_LostFocus(object sender, EventArgs e)
        {
            Metex.Windows.DataEntityCombo PbuCodes = (Metex.Windows.DataEntityCombo)sender;
            PbuCodes.DisplayMember = "PbuDescription";
        }

        void PbuCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Metex.Windows.DataEntityCombo PbuCodes = (Metex.Windows.DataEntityCombo)sender;
            int li_index = PbuCodes.SelectedIndex;
            PbuCodes.DisplayMember = "PbuDescription";
            PbuCodes.SelectedIndex = li_index;
            this.AcceptText();
            // if the column is not checked in itemchanged event below is not needed
            if (this.RowCount > 0)
            {
                this.OnItemChanged(PbuCodes, new System.EventArgs());
            }
        }

        void AccountCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Metex.Windows.DataEntityCombo AccountCodes = (Metex.Windows.DataEntityCombo)sender;
            int li_index = AccountCodes.SelectedIndex;
            AccountCodes.DisplayMember = "AcDescription";
            AccountCodes.SelectedIndex = li_index;
            this.AcceptText();
            // if the column is not checked in itemchanged event below is not needed
            if (this.RowCount > 0)
            {
                this.OnItemChanged(AccountCodes, new System.EventArgs());
            }
        }

        void AccountCodes_LostFocus(object sender, EventArgs e)
        {
            Metex.Windows.DataEntityCombo AccountCodes = (Metex.Windows.DataEntityCombo)sender;
            AccountCodes.DisplayMember = "AcDescription";
        }

        void AccountCodes_Click(object sender, EventArgs e)
        {
            Metex.Windows.DataEntityCombo AccountCodes = (Metex.Windows.DataEntityCombo)sender;
            if (AccountCodes.DroppedDown)
            {
                AccountCodes.DisplayMember = "";
            }
            else
            {
                AccountCodes.DisplayMember = "AcDescription";
            }
        }
        #endregion

    }
}

