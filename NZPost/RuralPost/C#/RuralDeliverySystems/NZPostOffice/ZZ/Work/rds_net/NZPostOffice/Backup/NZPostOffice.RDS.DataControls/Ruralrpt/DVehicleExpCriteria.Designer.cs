namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DVehicleExpCriteria
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
            this.n_25754316 = new System.Windows.Forms.Label();
            this.o_name = new System.Windows.Forms.TextBox();
            this.outlet_picklist = new System.Windows.Forms.CheckBox();
            this.ct_key = new Metex.Windows.DataEntityCombo();
            this.outlet_region_id_t = new System.Windows.Forms.Label();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.n_30462260 = new System.Windows.Forms.Label();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.VehicleExpCriteria);
            // 
            // n_25754316
            // 
            this.n_25754316.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F,System.Drawing.FontStyle.Bold);
            this.n_25754316.Location = new System.Drawing.Point(0, 0);
            this.n_25754316.Name = "n_25754316";
            this.n_25754316.Size = new System.Drawing.Size(113, 13);
            this.n_25754316.TabIndex = 0;
            this.n_25754316.Text = "Search Criteria";
            this.n_25754316.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // o_name
            // 
            this.o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_name.Enabled = false;
            this.o_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_name.Location = new System.Drawing.Point(629, 18);
            this.o_name.MaxLength = 40;
            this.o_name.Name = "o_name";
            this.o_name.Size = new System.Drawing.Size(187, 20);
            this.o_name.TabIndex = 0;
            // 
            // outlet_picklist
            // 
            this.outlet_picklist.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outlet_picklist.Enabled = false;
            this.outlet_picklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_picklist.Location = new System.Drawing.Point(701, 53);
            this.outlet_picklist.Name = "outlet_picklist";
            this.outlet_picklist.Size = new System.Drawing.Size(30, 15);
            this.outlet_picklist.TabIndex = 0;
            // 
            // ct_key
            // 
            this.ct_key.AutoRetrieve = true;
            this.ct_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CtKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ct_key.DisplayMember = "ContractType";
            this.ct_key.Enabled = false;
            this.ct_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ct_key.Location = new System.Drawing.Point(596, 77);
            this.ct_key.Name = "ct_key";
            this.ct_key.Size = new System.Drawing.Size(206, 21);
            this.ct_key.TabIndex = 0;
            this.ct_key.Value = null;
            this.ct_key.ValueMember = "CtKey";
            this.ct_key.DataBindings[0].DataSourceNullValue = null;
            // 
            // outlet_region_id_t
            // 
            this.outlet_region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.outlet_region_id_t.Location = new System.Drawing.Point(25, 18);
            this.outlet_region_id_t.Name = "outlet_region_id_t";
            this.outlet_region_id_t.Size = new System.Drawing.Size(62, 13);
            this.outlet_region_id_t.TabIndex = 0;
            this.outlet_region_id_t.Text = "Region";
            this.outlet_region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.Location = new System.Drawing.Point(93, 16);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(177, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            this.region_id.DataBindings[0].DataSourceNullValue = null;

            // 
            // n_30462260
            // 
            this.n_30462260.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_30462260.Location = new System.Drawing.Point(0, 46);
            this.n_30462260.Name = "n_30462260";
            this.n_30462260.Size = new System.Drawing.Size(88, 13);
            this.n_30462260.TabIndex = 0;
            this.n_30462260.Text = "Renewal group";
            this.n_30462260.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code.Location = new System.Drawing.Point(93, 46);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(177, 21);
            this.rg_code.TabIndex = 20;
            this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            this.rg_code.DataBindings[0].DataSourceNullValue = null;

            // 
            // DVehicleExpCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.n_25754316);
            this.Controls.Add(this.o_name);
            this.Controls.Add(this.outlet_picklist);
            this.Controls.Add(this.ct_key);
            this.Controls.Add(this.outlet_region_id_t);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.n_30462260);
            this.Controls.Add(this.rg_code);
            this.Name = "DVehicleExpCriteria";
            this.Size = new System.Drawing.Size(839, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label n_25754316;
        private System.Windows.Forms.TextBox o_name;
        private System.Windows.Forms.CheckBox outlet_picklist;
        private Metex.Windows.DataEntityCombo ct_key;
        private System.Windows.Forms.Label outlet_region_id_t;
        private Metex.Windows.DataEntityCombo region_id;
        private System.Windows.Forms.Label n_30462260;
        private Metex.Windows.DataEntityCombo rg_code;
    }
}
