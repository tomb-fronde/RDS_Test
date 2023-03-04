using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruralwin2
{
    partial class DsRouteFrequency2
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
this.contract_no_t = new System.Windows.Forms.Label();
this.contract_no = new System.Windows.Forms.TextBox();
this.sf_key_t = new System.Windows.Forms.Label();
this.sf_key = new System.Windows.Forms.TextBox();
this.rf_delivery_days_t = new System.Windows.Forms.Label();
this.rf_delivery_days = new System.Windows.Forms.TextBox();
this.rf_active_t = new System.Windows.Forms.Label();
this.rf_active = new System.Windows.Forms.TextBox();
this.rf_distance_t = new System.Windows.Forms.Label();
this.rf_distance = new System.Windows.Forms.TextBox();
this.vehicle_no_t = new System.Windows.Forms.Label();
this.Vehicle_no = new System.Windows.Forms.TextBox();
((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
this.SuspendLayout();
// 
// bindingSource
// 
this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RouteFrequency2);
// 
// contract_no_t
// 
this.contract_no_t.Font = new System.Drawing.Font("Arial", 8F);
this.contract_no_t.Location = new System.Drawing.Point(9, 1);
this.contract_no_t.Name = "contract_no_t";
this.contract_no_t.Size = new System.Drawing.Size(96, 14);
this.contract_no_t.TabIndex = 0;
this.contract_no_t.Text = "Contract No:";
this.contract_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// contract_no
// 
this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
this.contract_no.Font = new System.Drawing.Font("Arial", 8F);
this.contract_no.Location = new System.Drawing.Point(109, 1);
this.contract_no.Name = "contract_no";
this.contract_no.Size = new System.Drawing.Size(68, 20);
this.contract_no.TabIndex = 10;
this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
// 
// sf_key_t
// 
this.sf_key_t.Font = new System.Drawing.Font("Arial", 8F);
this.sf_key_t.Location = new System.Drawing.Point(9, 22);
this.sf_key_t.Name = "sf_key_t";
this.sf_key_t.Size = new System.Drawing.Size(96, 14);
this.sf_key_t.TabIndex = 0;
this.sf_key_t.Text = "Sf Key:";
this.sf_key_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// sf_key
// 
this.sf_key.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "SfKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
this.sf_key.Font = new System.Drawing.Font("Arial", 8F);
this.sf_key.Location = new System.Drawing.Point(109, 22);
this.sf_key.Name = "sf_key";
this.sf_key.Size = new System.Drawing.Size(68, 20);
this.sf_key.TabIndex = 20;
this.sf_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
// 
// rf_delivery_days_t
// 
this.rf_delivery_days_t.Font = new System.Drawing.Font("Arial", 8F);
this.rf_delivery_days_t.Location = new System.Drawing.Point(9, 44);
this.rf_delivery_days_t.Name = "rf_delivery_days_t";
this.rf_delivery_days_t.Size = new System.Drawing.Size(96, 14);
this.rf_delivery_days_t.TabIndex = 0;
this.rf_delivery_days_t.Text = "Rf Delivery Days:";
this.rf_delivery_days_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// rf_delivery_days
// 
this.rf_delivery_days.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RfDeliveryDays", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
this.rf_delivery_days.Font = new System.Drawing.Font("Arial", 8F);
this.rf_delivery_days.Location = new System.Drawing.Point(109, 44);
this.rf_delivery_days.MaxLength = 7;
this.rf_delivery_days.Name = "rf_delivery_days";
this.rf_delivery_days.Size = new System.Drawing.Size(68, 20);
this.rf_delivery_days.TabIndex = 30;
// 
// rf_active_t
// 
this.rf_active_t.Font = new System.Drawing.Font("Arial", 8F);
this.rf_active_t.Location = new System.Drawing.Point(9, 65);
this.rf_active_t.Name = "rf_active_t";
this.rf_active_t.Size = new System.Drawing.Size(96, 14);
this.rf_active_t.TabIndex = 0;
this.rf_active_t.Text = "Rf Active:";
this.rf_active_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// rf_active
// 
this.rf_active.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RfActive", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
this.rf_active.Font = new System.Drawing.Font("Arial", 8F);
this.rf_active.Location = new System.Drawing.Point(109, 65);
this.rf_active.MaxLength = 1;
this.rf_active.Name = "rf_active";
this.rf_active.Size = new System.Drawing.Size(68, 20);
this.rf_active.TabIndex = 40;
// 
// rf_distance_t
// 
this.rf_distance_t.Font = new System.Drawing.Font("Arial", 8F);
this.rf_distance_t.Location = new System.Drawing.Point(9, 86);
this.rf_distance_t.Name = "rf_distance_t";
this.rf_distance_t.Size = new System.Drawing.Size(96, 14);
this.rf_distance_t.TabIndex = 0;
this.rf_distance_t.Text = "Rf Distance:";
this.rf_distance_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// rf_distance
// 
this.rf_distance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RfDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
this.rf_distance.Font = new System.Drawing.Font("Arial", 8F);
this.rf_distance.Location = new System.Drawing.Point(109, 86);
this.rf_distance.Name = "rf_distance";
this.rf_distance.Size = new System.Drawing.Size(68, 20);
this.rf_distance.TabIndex = 50;
this.rf_distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
// 
// vehicle_no_t
// 
this.vehicle_no_t.Font = new System.Drawing.Font("Arial", 8F);
this.vehicle_no_t.Location = new System.Drawing.Point(9, 108);
this.vehicle_no_t.Name = "vehicle_no_t";
this.vehicle_no_t.Size = new System.Drawing.Size(96, 14);
this.vehicle_no_t.TabIndex = 51;
this.vehicle_no_t.Text = "Vehicle No:";
this.vehicle_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// Vehicle_no
// 
this.Vehicle_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VehicleNumber", true));
this.Vehicle_no.Font = new System.Drawing.Font("Arial", 8F);
this.Vehicle_no.Location = new System.Drawing.Point(109, 108);
this.Vehicle_no.Name = "Vehicle_no";
this.Vehicle_no.Size = new System.Drawing.Size(68, 20);
this.Vehicle_no.TabIndex = 52;
this.Vehicle_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
// 
// DsRouteFrequency2
// 
this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.Controls.Add(this.vehicle_no_t);
this.Controls.Add(this.Vehicle_no);
this.Controls.Add(this.contract_no_t);
this.Controls.Add(this.contract_no);
this.Controls.Add(this.sf_key_t);
this.Controls.Add(this.sf_key);
this.Controls.Add(this.rf_delivery_days_t);
this.Controls.Add(this.rf_delivery_days);
this.Controls.Add(this.rf_active_t);
this.Controls.Add(this.rf_active);
this.Controls.Add(this.rf_distance_t);
this.Controls.Add(this.rf_distance);
this.Name = "DsRouteFrequency2";
this.Size = new System.Drawing.Size(650, 300);
((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
this.ResumeLayout(false);
this.PerformLayout();

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
        private System.Windows.Forms.Label vehicle_no_t;
        private System.Windows.Forms.TextBox Vehicle_no;
    }
}
