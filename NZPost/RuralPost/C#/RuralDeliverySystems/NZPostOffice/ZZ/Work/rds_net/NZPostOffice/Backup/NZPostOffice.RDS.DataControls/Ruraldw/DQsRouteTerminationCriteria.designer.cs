namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DQsRouteTerminationCriteria
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
            this.n_60469192 = new System.Windows.Forms.Label();
            this.suppno_t = new System.Windows.Forms.Label();
            this.street_name = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.QsRouteTerminationCriteria);
            // 
            // n_60469192
            // 
            this.n_60469192.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.n_60469192.Location = new System.Drawing.Point(77, 2);
            this.n_60469192.Name = "n_60469192";
            this.n_60469192.Size = new System.Drawing.Size(78, 13);
            this.n_60469192.TabIndex = 0;
            this.n_60469192.Text = "Search Criteria";
            this.n_60469192.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // suppno_t
            // 
            this.suppno_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.suppno_t.Location = new System.Drawing.Point(37, 21);
            this.suppno_t.Name = "suppno_t";
            this.suppno_t.Size = new System.Drawing.Size(36, 13);
            this.suppno_t.TabIndex = 0;
            this.suppno_t.Text = "Street";
            this.suppno_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // street_name
            // 
            this.street_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "StreetName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.street_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.street_name.Location = new System.Drawing.Point(80, 18);
            this.street_name.MaxLength = 45;
            this.street_name.Name = "street_name";
            this.street_name.Size = new System.Drawing.Size(174, 20);
            this.street_name.TabIndex = 20;
            // 
            // DQsRouteTerminationCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.n_60469192);
            this.Controls.Add(this.suppno_t);
            this.Controls.Add(this.street_name);
            this.Name = "DQsRouteTerminationCriteria";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label n_60469192;
        private System.Windows.Forms.Label suppno_t;
        private System.Windows.Forms.TextBox street_name;
    }
}
