namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DMailCarriedFormTest
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.n_49079779 = new System.Windows.Forms.Label();
            //this.up_pcklst_bmp = new System.Windows.Forms.PictureBox();
            this.up_pcklst_bmp = new System.Windows.Forms.Button();
            this.n_39064830 = new System.Windows.Forms.Label();
            //this.dn_pcklst_bmp = new System.Windows.Forms.PictureBox();
            this.dn_pcklst_bmp = new System.Windows.Forms.Button();
            this.n_16039151 = new System.Windows.Forms.Label();
            this.next_day = new System.Windows.Forms.CheckBox();
            this.mc_dispatch_carried = new System.Windows.Forms.TextBox();
            this.mc_uplift_time = new System.Windows.Forms.MaskedTextBox();
            this.mc_up_outlet_name = new System.Windows.Forms.TextBox();
            this.mc_set_down_time = new System.Windows.Forms.MaskedTextBox();
            this.mc_dn_outlet_name = new System.Windows.Forms.TextBox();
            this.mc_disbanded_date = new System.Windows.Forms.MaskedTextBox();
            this.mc_dispatch_carried_t = new System.Windows.Forms.Label();
            this.n_10134631 = new System.Windows.Forms.Label();
            this.n_24102815 = new System.Windows.Forms.Label();
            this.n_15598744 = new System.Windows.Forms.Label();
            this.n_6170971 = new System.Windows.Forms.Label();
            this.n_55538746 = new System.Windows.Forms.Label();
            this.dn_picklist = new System.Windows.Forms.CheckBox();
            this.up_picklist = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.up_pcklst_bmp)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.dn_pcklst_bmp)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.MailCarriedForm);
            // 
            // n_49079779
            // 
            this.n_49079779.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
            this.n_49079779.Location = new System.Drawing.Point(51, 60);
            this.n_49079779.Name = "n_49079779";
            this.n_49079779.Size = new System.Drawing.Size(32, 13);
            this.n_49079779.TabIndex = 0;
            this.n_49079779.Text = "Uplift";
            this.n_49079779.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // up_pcklst_bmp
            // 
            this.up_pcklst_bmp.Location = new System.Drawing.Point(359, 83);
            this.up_pcklst_bmp.Name = "up_pcklst_bmp";
            this.up_pcklst_bmp.Size = new System.Drawing.Size(17, 15);
            this.up_pcklst_bmp.TabIndex = 0;
            this.up_pcklst_bmp.TabStop = false;
            this.up_pcklst_bmp.Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTUP;
            // 
            // n_39064830
            // 
            this.n_39064830.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
            this.n_39064830.Location = new System.Drawing.Point(30, 117);
            this.n_39064830.Name = "n_39064830";
            this.n_39064830.Size = new System.Drawing.Size(57, 13);
            this.n_39064830.TabIndex = 0;
            this.n_39064830.Text = "Set Down";
            this.n_39064830.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dn_pcklst_bmp
            // 
            this.dn_pcklst_bmp.Location = new System.Drawing.Point(360, 143);
            this.dn_pcklst_bmp.Name = "dn_pcklst_bmp";
            this.dn_pcklst_bmp.Size = new System.Drawing.Size(17, 15);
            this.dn_pcklst_bmp.TabIndex = 0;
            this.dn_pcklst_bmp.TabStop = false;
            this.dn_pcklst_bmp.Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTUP;
            // 
            // n_16039151
            // 
            this.n_16039151.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_16039151.Location = new System.Drawing.Point(170, 119);
            this.n_16039151.Name = "n_16039151";
            this.n_16039151.Size = new System.Drawing.Size(51, 13);
            this.n_16039151.TabIndex = 0;
            this.n_16039151.Text = "Next Day";
            this.n_16039151.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // next_day
            // 
            this.next_day.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "NextDay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.next_day.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.next_day.Location = new System.Drawing.Point(229, 119);
            this.next_day.Name = "next_day";
            this.next_day.Size = new System.Drawing.Size(17, 13);
            this.next_day.TabIndex = 60;
            //this.next_day.ThreeState = true;
            // 
            // mc_dispatch_carried
            // 
            this.mc_dispatch_carried.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "McDispatchCarried", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mc_dispatch_carried.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.mc_dispatch_carried.Location = new System.Drawing.Point(125, 26);
            this.mc_dispatch_carried.MaxLength = 40;
            this.mc_dispatch_carried.Name = "mc_dispatch_carried";
            this.mc_dispatch_carried.Size = new System.Drawing.Size(288, 20);
            this.mc_dispatch_carried.TabIndex = 10;
            this.mc_dispatch_carried.BackColor = System.Drawing.Color.Aqua;
            // 
            // mc_uplift_time
            // 
            this.mc_uplift_time.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "McUpliftTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mc_uplift_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.mc_uplift_time.Location = new System.Drawing.Point(125, 57);
            this.mc_uplift_time.Mask = "00:00";
            this.mc_uplift_time.PromptChar = '0';
            this.mc_uplift_time.Name = "mc_uplift_time";
            this.mc_uplift_time.Size = new System.Drawing.Size(39, 20);
            this.mc_uplift_time.TabIndex = 20;
            this.mc_uplift_time.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mc_uplift_time.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mc_uplift_time.DataBindings[0].DataSourceNullValue = null;
            this.mc_uplift_time.ValidatingType = typeof(System.DateTime);
            this.mc_uplift_time.DataBindings[0].FormatString = "HH:mm";
            this.mc_uplift_time.BackColor = System.Drawing.Color.Aqua;
            // 
            // mc_up_outlet_name
            // 
            this.mc_up_outlet_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "McUpOutletName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mc_up_outlet_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.mc_up_outlet_name.Location = new System.Drawing.Point(125, 81);
            this.mc_up_outlet_name.Name = "mc_up_outlet_name";
            this.mc_up_outlet_name.Size = new System.Drawing.Size(229, 20);
            this.mc_up_outlet_name.TabIndex = 30;
            this.mc_up_outlet_name.BackColor = System.Drawing.Color.Aqua;
            // 
            // mc_set_down_time
            // 
            this.mc_set_down_time.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "McSetDownTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mc_set_down_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.mc_set_down_time.Location = new System.Drawing.Point(125, 116);
            this.mc_set_down_time.Mask = "00:00";
            this.mc_set_down_time.PromptChar = '0';
            this.mc_set_down_time.Name = "mc_set_down_time";
            this.mc_set_down_time.Size = new System.Drawing.Size(39, 20);
            this.mc_set_down_time.TabIndex = 50;
            this.mc_set_down_time.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mc_set_down_time.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mc_set_down_time.DataBindings[0].DataSourceNullValue = null;
            this.mc_set_down_time.ValidatingType = typeof(System.DateTime);
            this.mc_set_down_time.DataBindings[0].FormatString = "HH:mm";
            this.mc_set_down_time.BackColor = System.Drawing.Color.Aqua;
            // 
            // mc_dn_outlet_name
            // 
            this.mc_dn_outlet_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "McDnOutletName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mc_dn_outlet_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.mc_dn_outlet_name.Location = new System.Drawing.Point(125, 140);
            this.mc_dn_outlet_name.Name = "mc_dn_outlet_name";
            this.mc_dn_outlet_name.Size = new System.Drawing.Size(229, 20);
            this.mc_dn_outlet_name.TabIndex = 70;
            this.mc_dn_outlet_name.BackColor = System.Drawing.Color.Aqua;
            // 
            // mc_disbanded_date
            // 
            this.mc_disbanded_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "McDisbandedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mc_disbanded_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.mc_disbanded_date.Location = new System.Drawing.Point(125, 178);
            this.mc_disbanded_date.Mask = "00/00/00";
            this.mc_disbanded_date.PromptChar = '0';
            this.mc_disbanded_date.Name = "mc_disbanded_date";
            this.mc_disbanded_date.Size = new System.Drawing.Size(58, 20);
            this.mc_disbanded_date.TabIndex = 90;
            this.mc_disbanded_date.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mc_disbanded_date.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mc_disbanded_date.DataBindings[0].DataSourceNullValue = null;
            this.mc_disbanded_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mc_disbanded_date.ValidatingType = typeof(System.DateTime);
            this.mc_disbanded_date.DataBindings[0].FormatString = "dd/MM/yy";
            // 
            // mc_dispatch_carried_t
            // 
            this.mc_dispatch_carried_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.mc_dispatch_carried_t.Location = new System.Drawing.Point(21, 29);
            this.mc_dispatch_carried_t.Name = "mc_dispatch_carried_t";
            this.mc_dispatch_carried_t.Size = new System.Drawing.Size(97, 13);
            this.mc_dispatch_carried_t.TabIndex = 0;
            this.mc_dispatch_carried_t.Text = "Dispatch Carried";
            this.mc_dispatch_carried_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_10134631
            // 
            this.n_10134631.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_10134631.Location = new System.Drawing.Point(90, 60);
            this.n_10134631.Name = "n_10134631";
            this.n_10134631.Size = new System.Drawing.Size(29, 13);
            this.n_10134631.TabIndex = 0;
            this.n_10134631.Text = "Time";
            this.n_10134631.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_24102815
            // 
            this.n_24102815.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_24102815.Location = new System.Drawing.Point(85, 85);
            this.n_24102815.Name = "n_24102815";
            this.n_24102815.Size = new System.Drawing.Size(36, 13);
            this.n_24102815.TabIndex = 0;
            this.n_24102815.Text = "Outlet";
            this.n_24102815.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_15598744
            // 
            this.n_15598744.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_15598744.Location = new System.Drawing.Point(90, 116);
            this.n_15598744.Name = "n_15598744";
            this.n_15598744.Size = new System.Drawing.Size(29, 13);
            this.n_15598744.TabIndex = 0;
            this.n_15598744.Text = "Time";
            this.n_15598744.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_6170971
            // 
            this.n_6170971.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_6170971.Location = new System.Drawing.Point(85, 143);
            this.n_6170971.Name = "n_6170971";
            this.n_6170971.Size = new System.Drawing.Size(35, 13);
            this.n_6170971.TabIndex = 0;
            this.n_6170971.Text = "Outlet";
            this.n_6170971.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_55538746
            // 
            this.n_55538746.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_55538746.Location = new System.Drawing.Point(19, 181);
            this.n_55538746.Name = "n_55538746";
            this.n_55538746.Size = new System.Drawing.Size(100, 13);
            this.n_55538746.TabIndex = 0;
            this.n_55538746.Text = "Discontinued Date";
            this.n_55538746.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dn_picklist
            // 
            this.dn_picklist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dn_picklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dn_picklist.Location = new System.Drawing.Point(237, 222);
            this.dn_picklist.Name = "dn_picklist";
            this.dn_picklist.Size = new System.Drawing.Size(1, 1);
            this.dn_picklist.TabIndex = 80;
            this.dn_picklist.ThreeState = false;
            // 
            // up_picklist
            // 
            this.up_picklist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.up_picklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.up_picklist.Location = new System.Drawing.Point(217, 220);
            this.up_picklist.Name = "up_picklist";
            this.up_picklist.Size = new System.Drawing.Size(1, 1);
            this.up_picklist.TabIndex = 40;
            // 
            // DMailCarriedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.n_49079779);
            this.Controls.Add(this.up_pcklst_bmp);
            this.Controls.Add(this.n_39064830);
            this.Controls.Add(this.dn_pcklst_bmp);
            this.Controls.Add(this.n_16039151);
            this.Controls.Add(this.next_day);
            this.Controls.Add(this.mc_dispatch_carried);
            this.Controls.Add(this.mc_uplift_time);
            this.Controls.Add(this.mc_up_outlet_name);
            this.Controls.Add(this.mc_set_down_time);
            this.Controls.Add(this.mc_dn_outlet_name);
            this.Controls.Add(this.mc_disbanded_date);
            this.Controls.Add(this.mc_dispatch_carried_t);
            this.Controls.Add(this.n_10134631);
            this.Controls.Add(this.n_24102815);
            this.Controls.Add(this.n_15598744);
            this.Controls.Add(this.n_6170971);
            this.Controls.Add(this.n_55538746);
            this.Controls.Add(this.dn_picklist);
            this.Controls.Add(this.up_picklist);
            this.Name = "DMailCarriedForm";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.up_pcklst_bmp)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.dn_pcklst_bmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label n_49079779;
        //private System.Windows.Forms.PictureBox up_pcklst_bmp;
        private System.Windows.Forms.Button up_pcklst_bmp;
        private System.Windows.Forms.Label n_39064830;
        //private System.Windows.Forms.PictureBox dn_pcklst_bmp;
        private System.Windows.Forms.Button dn_pcklst_bmp;
        private System.Windows.Forms.Label n_16039151;
        private System.Windows.Forms.CheckBox next_day;
        private System.Windows.Forms.TextBox mc_dispatch_carried;
        private System.Windows.Forms.MaskedTextBox mc_uplift_time;
        private System.Windows.Forms.TextBox mc_up_outlet_name;
        private System.Windows.Forms.MaskedTextBox mc_set_down_time;
        private System.Windows.Forms.TextBox mc_dn_outlet_name;
        private System.Windows.Forms.MaskedTextBox mc_disbanded_date;
        private System.Windows.Forms.Label mc_dispatch_carried_t;
        private System.Windows.Forms.Label n_10134631;
        private System.Windows.Forms.Label n_24102815;
        private System.Windows.Forms.Label n_15598744;
        private System.Windows.Forms.Label n_6170971;
        private System.Windows.Forms.Label n_55538746;
        private System.Windows.Forms.CheckBox dn_picklist;
        private System.Windows.Forms.CheckBox up_picklist;
    }
}
