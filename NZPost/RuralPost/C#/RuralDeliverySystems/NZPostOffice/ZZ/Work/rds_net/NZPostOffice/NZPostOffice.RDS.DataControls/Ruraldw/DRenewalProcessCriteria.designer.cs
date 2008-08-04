namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DRenewalProcessCriteria
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
            this.n_997409 = new System.Windows.Forms.Label();
            this.region_id_t = new System.Windows.Forms.Label();
            this.rg_code_t = new System.Windows.Forms.Label();
            this.contract_no_t = new System.Windows.Forms.Label();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            this.contract_no = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RenewalProcessCriteria);
            // 
            // n_997409
            // 
            this.n_997409.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            this.n_997409.Location = new System.Drawing.Point(90, 2);
            this.n_997409.Name = "n_997409";
            this.n_997409.Size = new System.Drawing.Size(98, 13);
            this.n_997409.TabIndex = 0;
            this.n_997409.Text = "Search Criteria";
            this.n_997409.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;            
            // 
            // region_id_t
            // 
            this.region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id_t.Location = new System.Drawing.Point(43, 24);
            this.region_id_t.Name = "region_id_t";
            this.region_id_t.Size = new System.Drawing.Size(42, 13);
            this.region_id_t.TabIndex = 0;
            this.region_id_t.Text = "Region";
            this.region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rg_code_t
            // 
            this.rg_code_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code_t.Location = new System.Drawing.Point(1, 46);
            this.rg_code_t.Name = "rg_code_t";
            this.rg_code_t.Size = new System.Drawing.Size(84, 13);
            this.rg_code_t.TabIndex = 0;
            this.rg_code_t.Text = "Renewal Group";
            this.rg_code_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contract_no_t
            // 
            this.contract_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_no_t.Location = new System.Drawing.Point(20, 70);
            this.contract_no_t.Name = "contract_no_t";
            this.contract_no_t.Size = new System.Drawing.Size(65, 13);
            this.contract_no_t.TabIndex = 0;
            this.contract_no.MaxLength = 8;
            this.contract_no_t.Text = "Contract No";
            this.contract_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.Location = new System.Drawing.Point(91, 22);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(187, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code.Location = new System.Drawing.Point(91, 46);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(187, 21);
            this.rg_code.TabIndex = 20;
            this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            // 
            // contract_no
            // 
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_no.Location = new System.Drawing.Point(91, 70);
            this.contract_no.Name = "contract_no";
            this.contract_no.Size = new System.Drawing.Size(62, 20);
            this.contract_no.TabIndex = 30;
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.contract_no.DataBindings[0].NullValue = "";
            
            // 
            // DRenewalProcessCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.n_997409);
            this.Controls.Add(this.region_id_t);
            this.Controls.Add(this.rg_code_t);
            this.Controls.Add(this.contract_no_t);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.rg_code);
            this.Controls.Add(this.contract_no);
            this.Name = "DRenewalProcessCriteria";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label n_997409;
        private System.Windows.Forms.Label region_id_t;
        private System.Windows.Forms.Label rg_code_t;
        private System.Windows.Forms.Label contract_no_t;
        private Metex.Windows.DataEntityCombo region_id;
        private Metex.Windows.DataEntityCombo rg_code;
        private System.Windows.Forms.TextBox contract_no;
    }
}
