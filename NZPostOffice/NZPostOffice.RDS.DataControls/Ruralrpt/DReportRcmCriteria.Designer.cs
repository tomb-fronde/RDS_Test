namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DReportRcmCriteria
    {
        // TJB  FCR_001 28-Nov-2012
        // Increased size of renewal group dropdown to include November Renewals

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DReportRcmCriteria));
            this.st_report = new System.Windows.Forms.Label();
            this.n_48445579 = new System.Windows.Forms.Label();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.outlet_picklist = new System.Windows.Forms.CheckBox();
            this.outlet_region_id_t = new System.Windows.Forms.Label();
            this.outlet_outlet_id_t = new System.Windows.Forms.Label();
            this.o_name = new System.Windows.Forms.TextBox();
            this.outlet_bmp = new System.Windows.Forms.PictureBox();
            this.n_33357028 = new System.Windows.Forms.Label();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.n_31777804 = new System.Windows.Forms.Label();
            this.ct_key = new Metex.Windows.DataEntityCombo();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.ReportRcmCriteria);
            // 
            // st_report
            // 
            this.st_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_report.Location = new System.Drawing.Point(4, 2);
            this.st_report.Name = "st_report";
            this.st_report.Size = new System.Drawing.Size(180, 13);
            this.st_report.TabIndex = 0;
            this.st_report.Text = "RCMs Statistical Report";
            this.st_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_48445579
            // 
            this.n_48445579.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_48445579.Location = new System.Drawing.Point(117, 18);
            this.n_48445579.Name = "n_48445579";
            this.n_48445579.Size = new System.Drawing.Size(113, 13);
            this.n_48445579.TabIndex = 0;
            this.n_48445579.Text = "Search Criteria";
            this.n_48445579.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.DropDownHeight = 150;
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.IntegralHeight = false;
            this.region_id.Location = new System.Drawing.Point(118, 35);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(173, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            // 
            // outlet_picklist
            // 
            this.outlet_picklist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_picklist.Enabled = false;
            this.outlet_picklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_picklist.Location = new System.Drawing.Point(5, 2);
            this.outlet_picklist.Name = "outlet_picklist";
            this.outlet_picklist.Size = new System.Drawing.Size(9, 13);
            this.outlet_picklist.TabIndex = 0;
            // 
            // outlet_region_id_t
            // 
            this.outlet_region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_region_id_t.Location = new System.Drawing.Point(58, 40);
            this.outlet_region_id_t.Name = "outlet_region_id_t";
            this.outlet_region_id_t.Size = new System.Drawing.Size(58, 13);
            this.outlet_region_id_t.TabIndex = 0;
            this.outlet_region_id_t.Text = "Region";
            this.outlet_region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // outlet_outlet_id_t
            // 
            this.outlet_outlet_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_outlet_id_t.Location = new System.Drawing.Point(30, 61);
            this.outlet_outlet_id_t.Name = "outlet_outlet_id_t";
            this.outlet_outlet_id_t.Size = new System.Drawing.Size(83, 13);
            this.outlet_outlet_id_t.TabIndex = 0;
            this.outlet_outlet_id_t.Text = "Base Office";
            this.outlet_outlet_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // o_name
            // 
            this.o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_name.Location = new System.Drawing.Point(118, 57);
            this.o_name.MaxLength = 40;
            this.o_name.Name = "o_name";
            this.o_name.Size = new System.Drawing.Size(157, 20);
            this.o_name.TabIndex = 30;
            // 
            // outlet_bmp
            // 
            this.outlet_bmp.Image = ((System.Drawing.Image)(resources.GetObject("outlet_bmp.Image")));
            this.outlet_bmp.Location = new System.Drawing.Point(276, 59);
            this.outlet_bmp.Name = "outlet_bmp";
            this.outlet_bmp.Size = new System.Drawing.Size(17, 16);
            this.outlet_bmp.TabIndex = 0;
            this.outlet_bmp.TabStop = false;
            // 
            // n_33357028
            // 
            this.n_33357028.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_33357028.Location = new System.Drawing.Point(13, 83);
            this.n_33357028.Name = "n_33357028";
            this.n_33357028.Size = new System.Drawing.Size(100, 13);
            this.n_33357028.TabIndex = 0;
            this.n_33357028.Text = "Renewal Group";
            this.n_33357028.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.DropDownHeight = 150;
            this.rg_code.Font = new System.Drawing.Font("Arial", 8F);
            this.rg_code.Location = new System.Drawing.Point(118, 77);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(173, 22);
            this.rg_code.TabIndex = 40;
            this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            // 
            // n_31777804
            // 
            this.n_31777804.Font = new System.Drawing.Font("Arial", 8F);
            this.n_31777804.Location = new System.Drawing.Point(22, 104);
            this.n_31777804.Name = "n_31777804";
            this.n_31777804.Size = new System.Drawing.Size(91, 14);
            this.n_31777804.TabIndex = 0;
            this.n_31777804.Text = "Contract Type";
            this.n_31777804.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ct_key
            // 
            this.ct_key.AutoRetrieve = true;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.DropDownHeight = 150;
            this.ct_key.Font = new System.Drawing.Font("Arial", 8F);
            this.ct_key.IntegralHeight = false;
            this.ct_key.Location = new System.Drawing.Point(118, 99);
            this.ct_key.Name = "ct_key";
            this.ct_key.Size = new System.Drawing.Size(173, 22);
            this.ct_key.TabIndex = 50;
            this.ct_key.Value = null;
            this.ct_key.ValueMember = "CtKey";
            // 
            // DReportRcmCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.st_report);
            this.Controls.Add(this.n_48445579);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.outlet_picklist);
            this.Controls.Add(this.outlet_region_id_t);
            this.Controls.Add(this.outlet_outlet_id_t);
            this.Controls.Add(this.o_name);
            this.Controls.Add(this.outlet_bmp);
            this.Controls.Add(this.n_33357028);
            this.Controls.Add(this.rg_code);
            this.Controls.Add(this.n_31777804);
            this.Controls.Add(this.ct_key);
            this.Name = "DReportRcmCriteria";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label st_report;
        private System.Windows.Forms.Label n_48445579;
        private Metex.Windows.DataEntityCombo region_id;
        private System.Windows.Forms.CheckBox outlet_picklist;
        private System.Windows.Forms.Label outlet_region_id_t;
        private System.Windows.Forms.Label outlet_outlet_id_t;
        private System.Windows.Forms.TextBox o_name;
        private System.Windows.Forms.PictureBox outlet_bmp;
        private System.Windows.Forms.Label n_33357028;
        private Metex.Windows.DataEntityCombo rg_code;
        private System.Windows.Forms.Label n_31777804;
        private Metex.Windows.DataEntityCombo ct_key;
    }
}

