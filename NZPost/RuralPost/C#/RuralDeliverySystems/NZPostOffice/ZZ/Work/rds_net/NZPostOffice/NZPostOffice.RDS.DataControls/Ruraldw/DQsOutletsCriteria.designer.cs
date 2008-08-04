namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DQsOutletsCriteria
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
            this.n_14933841 = new System.Windows.Forms.Label();
            this.region_id_t = new System.Windows.Forms.Label();
            this.o_name_t = new System.Windows.Forms.Label();
            this.region_id = new Metex.Windows.DataEntityCombo();
            this.o_name = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.QsOutletsCriteria);
            // 
            // n_14933841
            // 
            this.n_14933841.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            this.n_14933841.Location = new System.Drawing.Point(57, 7);
            this.n_14933841.Name = "n_14933841";
            this.n_14933841.Size = new System.Drawing.Size(113, 13);
            this.n_14933841.TabIndex = 0;
            this.n_14933841.Text = "Search Criteria";
            this.n_14933841.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // region_id_t
            // 
            this.region_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id_t.Location = new System.Drawing.Point(11, 20);
            this.region_id_t.Name = "region_id_t";
            this.region_id_t.Size = new System.Drawing.Size(43, 13);
            this.region_id_t.TabIndex = 0;
            this.region_id_t.Text = "Region";
            this.region_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // o_name_t
            // 
            this.o_name_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_name_t.Location = new System.Drawing.Point(16, 41);
            this.o_name_t.Name = "o_name_t";
            this.o_name_t.Size = new System.Drawing.Size(35, 13);
            this.o_name_t.TabIndex = 0;
            this.o_name_t.Text = "Outlet";
            this.o_name_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // region_id
            // 
            this.region_id.AutoRetrieve = true;
            this.region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_id.DisplayMember = "RgnName";
            this.region_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.region_id.Location = new System.Drawing.Point(57, 20);
            this.region_id.Name = "region_id";
            this.region_id.Size = new System.Drawing.Size(229, 21);
            this.region_id.TabIndex = 10;
            this.region_id.Value = null;
            this.region_id.ValueMember = "RegionId";
            this.region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // o_name
            // 
            this.o_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.o_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.o_name.Location = new System.Drawing.Point(57, 41);
            this.o_name.MaxLength = 40;
            this.o_name.Name = "o_name";
            this.o_name.Size = new System.Drawing.Size(228, 20);
            this.o_name.TabIndex = 20;
            // 
            // DQsOutletsCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.n_14933841);
            this.Controls.Add(this.region_id_t);
            this.Controls.Add(this.o_name_t);
            this.Controls.Add(this.region_id);
            this.Controls.Add(this.o_name);
            this.Name = "DQsOutletsCriteria";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label n_14933841;
        private System.Windows.Forms.Label region_id_t;
        private System.Windows.Forms.Label o_name_t;
        private Metex.Windows.DataEntityCombo region_id;
        private System.Windows.Forms.TextBox o_name;
    }
}
