namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DReportGenericRegOutletContcriteria
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
            this.n_62019111 = new System.Windows.Forms.Label();
            this.st_report = new System.Windows.Forms.Label();
            this.outlet_picklist = new System.Windows.Forms.CheckBox();
            this.outlet_id = new System.Windows.Forms.TextBox();
            this.outlet_bmp = new System.Windows.Forms.PictureBox();
            this.outlet_region_id_t = new System.Windows.Forms.Label();
            this.outlet_outlet_id_t = new System.Windows.Forms.Label();
            this.n_21301090 = new System.Windows.Forms.Label();
            this.n_57492083 = new System.Windows.Forms.Label();
            this.region_id_ro = new Metex.Windows.DataEntityCombo();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.o_name = new System.Windows.Forms.TextBox();
            this.contract_no = new System.Windows.Forms.TextBox();
            this.date_commenced = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ReportGenericRegOutletContcriteria);
            // 
            // n_62019111
            // 
            this.n_62019111.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_62019111.Location = new System.Drawing.Point(117, 14);
            this.n_62019111.Name = "n_62019111";
            this.n_62019111.Size = new System.Drawing.Size(113, 13);
            this.n_62019111.TabIndex = 0;
            this.n_62019111.Text = "Search Criteria";
            this.n_62019111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // st_report
            // 
            this.st_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_report.Location = new System.Drawing.Point(4, 2);
            this.st_report.Name = "st_report";
            this.st_report.Size = new System.Drawing.Size(326, 13);
            this.st_report.TabIndex = 0;
            this.st_report.Text = "Report:";
            this.st_report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outlet_picklist
            // 
            this.outlet_picklist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_picklist.Enabled = false;
            this.outlet_picklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_picklist.Location = new System.Drawing.Point(30, 150);
            this.outlet_picklist.Name = "outlet_picklist";
            this.outlet_picklist.Size = new System.Drawing.Size(35, 11);
            this.outlet_picklist.TabIndex = 0;
            // 
            // outlet_id
            // 
            this.outlet_id.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OutletId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_id.Enabled = false;
            this.outlet_id.Font = new System.Drawing.Font("Arial", 12F);
            this.outlet_id.Location = new System.Drawing.Point(606, 28);
            this.outlet_id.Name = "outlet_id";
            this.outlet_id.Size = new System.Drawing.Size(33, 26);
            this.outlet_id.TabIndex = 0;
            // 
            // outlet_bmp
            // 
            this.outlet_bmp.Location = new System.Drawing.Point(315, 60);
            this.outlet_bmp.Name = "outlet_bmp";
            this.outlet_bmp.Size = new System.Drawing.Size(17, 15);
            this.outlet_bmp.TabIndex = 0;
            this.outlet_bmp.TabStop = false;
            // 
            // outlet_region_id_t
            // 
            this.outlet_region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_region_id_t.Location = new System.Drawing.Point(60, 34);
            this.outlet_region_id_t.Name = "outlet_region_id_t";
            this.outlet_region_id_t.Size = new System.Drawing.Size(57, 13);
            this.outlet_region_id_t.TabIndex = 0;
            this.outlet_region_id_t.Text = "Region";
            this.outlet_region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // outlet_outlet_id_t
            // 
            this.outlet_outlet_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_outlet_id_t.Location = new System.Drawing.Point(41, 59);
            this.outlet_outlet_id_t.Name = "outlet_outlet_id_t";
            this.outlet_outlet_id_t.Size = new System.Drawing.Size(76, 13);
            this.outlet_outlet_id_t.TabIndex = 0;
            this.outlet_outlet_id_t.Text = "Base Office";
            this.outlet_outlet_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_21301090
            // 
            this.n_21301090.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_21301090.Location = new System.Drawing.Point(26, 85);
            this.n_21301090.Name = "n_21301090";
            this.n_21301090.Size = new System.Drawing.Size(91, 13);
            this.n_21301090.TabIndex = 0;
            this.n_21301090.Text = "Contract No";
            this.n_21301090.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_57492083
            // 
            this.n_57492083.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_57492083.Location = new System.Drawing.Point(4, 113);
            this.n_57492083.Name = "n_57492083";
            this.n_57492083.Size = new System.Drawing.Size(116, 13);
            this.n_57492083.TabIndex = 0;
            this.n_57492083.Text = "Commencement Date";
            this.n_57492083.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // region_id_ro
            // 
            this.region_id_ro.AutoRetrieve = true;
            this.region_id_ro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id_ro.DisplayMember = "RgnName";
            this.region_id_ro.Enabled = false;
            this.region_id_ro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id_ro.Location = new System.Drawing.Point(124, 31);
            this.region_id_ro.Name = "region_id_ro";
            this.region_id_ro.Size = new System.Drawing.Size(208, 21);
            this.region_id_ro.TabIndex = 0;
            this.region_id_ro.Value = null;
            this.region_id_ro.ValueMember = "RegionId";
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.Location = new System.Drawing.Point(124, 33);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(208, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            // 
            // o_name
            // 
            this.o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_name.Location = new System.Drawing.Point(124, 58);
            this.o_name.MaxLength = 40;
            this.o_name.Name = "o_name";
            this.o_name.Size = new System.Drawing.Size(185, 20);
            this.o_name.TabIndex = 20;
            // 
            // contract_no
            // 
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_no.Location = new System.Drawing.Point(124, 83);
            this.contract_no.Name = "contract_no";
            this.contract_no.Size = new System.Drawing.Size(74, 20);
            this.contract_no.TabIndex = 30;
            // 
            // date_commenced
            // 
            this.date_commenced.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DateCommenced", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.date_commenced.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.date_commenced.Location = new System.Drawing.Point(124, 109);
            this.date_commenced.Name = "date_commenced";
            this.date_commenced.Size = new System.Drawing.Size(74, 20);
            this.date_commenced.TabIndex = 40;
            // 
            // DReportGenericRegOutletContcriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.n_62019111);
            this.Controls.Add(this.st_report);
            this.Controls.Add(this.outlet_picklist);
            this.Controls.Add(this.outlet_id);
            this.Controls.Add(this.outlet_bmp);
            this.Controls.Add(this.outlet_region_id_t);
            this.Controls.Add(this.outlet_outlet_id_t);
            this.Controls.Add(this.n_21301090);
            this.Controls.Add(this.n_57492083);
            this.Controls.Add(this.region_id_ro);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.o_name);
            this.Controls.Add(this.contract_no);
            this.Controls.Add(this.date_commenced);
            this.Name = "DReportGenericRegOutletContcriteria";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outlet_bmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label n_62019111;
        private System.Windows.Forms.Label st_report;
        private System.Windows.Forms.CheckBox outlet_picklist;
        private System.Windows.Forms.TextBox outlet_id;
        private System.Windows.Forms.PictureBox outlet_bmp;
        private System.Windows.Forms.Label outlet_region_id_t;
        private System.Windows.Forms.Label outlet_outlet_id_t;
        private System.Windows.Forms.Label n_21301090;
        private System.Windows.Forms.Label n_57492083;
        private Metex.Windows.DataEntityCombo region_id_ro;
        private Metex.Windows.DataEntityCombo region_id;
        private System.Windows.Forms.TextBox o_name;
        private System.Windows.Forms.TextBox contract_no;
        private System.Windows.Forms.TextBox date_commenced;
    }
}
