namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DBenchmarkCalcCriteria
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
            this.t_1 = new System.Windows.Forms.Label();
            this.region_id_t = new System.Windows.Forms.Label();
            this.rg_code_t = new System.Windows.Forms.Label();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.rg_code = new Metex.Windows.DataEntityCombo();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.BenchmarkCalcCriteria);
            // 
            // t_1
            // 
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F,System.Drawing.FontStyle.Underline);
            this.t_1.Location = new System.Drawing.Point(90, 3);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(79, 13);
            this.t_1.TabIndex = 0;
            this.t_1.Text = "Search Criteria";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // region_id_t
            // 
            this.region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id_t.Location = new System.Drawing.Point(42, 25);
            this.region_id_t.Name = "region_id_t";
            this.region_id_t.Size = new System.Drawing.Size(42, 13);
            this.region_id_t.TabIndex = 0;
            this.region_id_t.Text = "Region";
            this.region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rg_code_t
            // 
            this.rg_code_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code_t.Location = new System.Drawing.Point(3, 46);
            this.rg_code_t.Name = "rg_code_t";
            this.rg_code_t.Size = new System.Drawing.Size(84, 13);
            this.rg_code_t.TabIndex = 0;
            this.rg_code_t.Text = "Renewal Group";
            this.rg_code_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.Location = new System.Drawing.Point(90, 17);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(154, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            this.region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // rg_code
            // 
            this.rg_code.AutoRetrieve = true;
            this.rg_code.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RgCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rg_code.Location = new System.Drawing.Point(90, 41);
            this.rg_code.Name = "rg_code";
            this.rg_code.Size = new System.Drawing.Size(154, 21);
            this.rg_code.TabIndex = 20;
            this.rg_code.Value = null;
            this.rg_code.ValueMember = "RgCode";
            this.rg_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // DBenchmarkCalcCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.region_id_t);
            this.Controls.Add(this.rg_code_t);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.rg_code);
            this.Name = "DBenchmarkCalcCriteria";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.Label region_id_t;
        private System.Windows.Forms.Label rg_code_t;
        private Metex.Windows.DataEntityCombo region_id;
        private Metex.Windows.DataEntityCombo rg_code;
    }
}
