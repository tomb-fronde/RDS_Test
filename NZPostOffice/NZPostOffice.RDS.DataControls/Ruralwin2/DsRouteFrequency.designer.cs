namespace NZPostOffice.RDS.DataControls.Ruralwin2
{
    partial class DsRouteFrequency
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
            components = new System.ComponentModel.Container();
            this.Name = "DsRouteFrequency";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin2.RouteFrequency);
            #region contract_no_t define
            this.contract_no_t = new System.Windows.Forms.Label();
            this.contract_no_t.Name = "contract_no_t";
            this.contract_no_t.Location = new System.Drawing.Point(9, 1);
            this.contract_no_t.Size = new System.Drawing.Size(96, 14);
            this.contract_no_t.TabIndex = 0;
            this.contract_no_t.Font = new System.Drawing.Font("Arial", 8);
            this.contract_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.contract_no_t.Text = "Contract No:";
            #endregion
            this.Controls.Add(contract_no_t);
            #region contract_no define
            this.contract_no = new System.Windows.Forms.TextBox();
            this.contract_no.Name = "contract_no";
            this.contract_no.Location = new System.Drawing.Point(109, 1);
            this.contract_no.Size = new System.Drawing.Size(68, 14);
            this.contract_no.TabIndex = 10;
            this.contract_no.Font = new System.Drawing.Font("Arial", 8);
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(contract_no);
            #region sf_key_t define
            this.sf_key_t = new System.Windows.Forms.Label();
            this.sf_key_t.Name = "sf_key_t";
            this.sf_key_t.Location = new System.Drawing.Point(9, 22);
            this.sf_key_t.Size = new System.Drawing.Size(96, 14);
            this.sf_key_t.TabIndex = 0;
            this.sf_key_t.Font = new System.Drawing.Font("Arial", 8);
            this.sf_key_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sf_key_t.Text = "Sf Key:";
            #endregion
            this.Controls.Add(sf_key_t);
            #region sf_key define
            this.sf_key = new System.Windows.Forms.TextBox();
            this.sf_key.Name = "sf_key";
            this.sf_key.Location = new System.Drawing.Point(109, 22);
            this.sf_key.Size = new System.Drawing.Size(68, 14);
            this.sf_key.TabIndex = 20;
            this.sf_key.Font = new System.Drawing.Font("Arial", 8);
            this.sf_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sf_key.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "SfKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(sf_key);
            #region rf_delivery_days_t define
            this.rf_delivery_days_t = new System.Windows.Forms.Label();
            this.rf_delivery_days_t.Name = "rf_delivery_days_t";
            this.rf_delivery_days_t.Location = new System.Drawing.Point(9, 44);
            this.rf_delivery_days_t.Size = new System.Drawing.Size(96, 14);
            this.rf_delivery_days_t.TabIndex = 0;
            this.rf_delivery_days_t.Font = new System.Drawing.Font("Arial", 8);
            this.rf_delivery_days_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rf_delivery_days_t.Text = "Rf Delivery Days:";
            #endregion
            this.Controls.Add(rf_delivery_days_t);
            #region rf_delivery_days define
            this.rf_delivery_days = new System.Windows.Forms.TextBox();
            this.rf_delivery_days.Name = "rf_delivery_days";
            this.rf_delivery_days.Location = new System.Drawing.Point(109, 44);
            this.rf_delivery_days.Size = new System.Drawing.Size(68, 14);
            this.rf_delivery_days.TabIndex = 30;
            this.rf_delivery_days.Font = new System.Drawing.Font("Arial", 8);
            this.rf_delivery_days.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.rf_delivery_days.MaxLength = 7;
            this.rf_delivery_days.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RfDeliveryDays", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(rf_delivery_days);
            #region rf_active_t define
            this.rf_active_t = new System.Windows.Forms.Label();
            this.rf_active_t.Name = "rf_active_t";
            this.rf_active_t.Location = new System.Drawing.Point(9, 65);
            this.rf_active_t.Size = new System.Drawing.Size(96, 14);
            this.rf_active_t.TabIndex = 0;
            this.rf_active_t.Font = new System.Drawing.Font("Arial", 8);
            this.rf_active_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rf_active_t.Text = "Rf Active:";
            #endregion
            this.Controls.Add(rf_active_t);
            #region rf_active define
            this.rf_active = new System.Windows.Forms.TextBox();
            this.rf_active.Name = "rf_active";
            this.rf_active.Location = new System.Drawing.Point(109, 65);
            this.rf_active.Size = new System.Drawing.Size(68, 14);
            this.rf_active.TabIndex = 40;
            this.rf_active.Font = new System.Drawing.Font("Arial", 8);
            this.rf_active.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.rf_active.MaxLength = 1;
            this.rf_active.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RfActive", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(rf_active);
            #region rf_distance_t define
            this.rf_distance_t = new System.Windows.Forms.Label();
            this.rf_distance_t.Name = "rf_distance_t";
            this.rf_distance_t.Location = new System.Drawing.Point(9, 86);
            this.rf_distance_t.Size = new System.Drawing.Size(96, 14);
            this.rf_distance_t.TabIndex = 0;
            this.rf_distance_t.Font = new System.Drawing.Font("Arial", 8);
            this.rf_distance_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rf_distance_t.Text = "Rf Distance:";
            #endregion
            this.Controls.Add(rf_distance_t);
            #region rf_distance define
            this.rf_distance = new System.Windows.Forms.TextBox();
            this.rf_distance.Name = "rf_distance";
            this.rf_distance.Location = new System.Drawing.Point(109, 86);
            this.rf_distance.Size = new System.Drawing.Size(68, 14);
            this.rf_distance.TabIndex = 50;
            this.rf_distance.Font = new System.Drawing.Font("Arial", 8);
            this.rf_distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rf_distance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RfDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(rf_distance);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.Label contract_no_t;
        private System.Windows.Forms.TextBox contract_no;
        private System.Windows.Forms.Label sf_key_t;
        private System.Windows.Forms.TextBox sf_key;
        private System.Windows.Forms.Label rf_delivery_days_t;
        private System.Windows.Forms.TextBox rf_delivery_days;
        private System.Windows.Forms.Label rf_active_t;
        private System.Windows.Forms.TextBox rf_active;
        private System.Windows.Forms.Label rf_distance_t;
        private System.Windows.Forms.TextBox rf_distance;
    }
}
