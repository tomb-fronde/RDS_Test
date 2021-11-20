using System.Windows.Forms;
using System.Drawing;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DNonVehicleOverrideRates
	{
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.nvor_delivery_wage_rate_t = new System.Windows.Forms.Label();
            this.nvor_public_liability_rate_t = new System.Windows.Forms.Label();
            this.nvor_carrier_risk_rate_t = new System.Windows.Forms.Label();
            this.nvor_item_proc_rate_per_hour_t = new System.Windows.Forms.Label();
            this.nvor_accounting_t = new System.Windows.Forms.Label();
            this.nvor_telephone_t = new System.Windows.Forms.Label();
            this.nvor_sundries_t = new System.Windows.Forms.Label();
            this.nvor_acc_rate_t = new System.Windows.Forms.Label();
            this.t_1 = new System.Windows.Forms.Label();
            this.t_2 = new System.Windows.Forms.Label();
            this.nvor_public_liability_rate = new System.Windows.Forms.TextBox();
            this.nvor_carrier_risk_rate = new System.Windows.Forms.TextBox();
            this.nvor_item_proc_rate_per_hour = new System.Windows.Forms.TextBox();
            this.nvor_accounting = new System.Windows.Forms.TextBox();
            this.nvor_telephone = new System.Windows.Forms.TextBox();
            this.nvor_sundries = new System.Windows.Forms.TextBox();
            this.nvor_acc_rate = new System.Windows.Forms.TextBox();
            this.nvor_acc_rate_amount = new System.Windows.Forms.TextBox();
            this.nvor_uniform = new System.Windows.Forms.TextBox();
            this.nvor_processing_wage_rate_t = new System.Windows.Forms.Label();
            this.nvor_processing_wage_rate = new System.Windows.Forms.TextBox();
            this.nvor_delivery_wage_rate = new System.Windows.Forms.TextBox();
            this.nvor_relief_weeks_t = new System.Windows.Forms.Label();
            this.nvor_relief_weeks = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.NonVehicleOverrideRates);
            // 
            // nvor_delivery_wage_rate_t
            // 
            this.nvor_delivery_wage_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nvor_delivery_wage_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_delivery_wage_rate_t.ForeColor = System.Drawing.Color.Black;
            this.nvor_delivery_wage_rate_t.Location = new System.Drawing.Point(31, 36);
            this.nvor_delivery_wage_rate_t.Name = "nvor_delivery_wage_rate_t";
            this.nvor_delivery_wage_rate_t.Size = new System.Drawing.Size(141, 13);
            this.nvor_delivery_wage_rate_t.TabIndex = 0;
            this.nvor_delivery_wage_rate_t.Text = "Delivery Wage Rate";
            this.nvor_delivery_wage_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_public_liability_rate_t
            // 
            this.nvor_public_liability_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nvor_public_liability_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_public_liability_rate_t.ForeColor = System.Drawing.Color.Black;
            this.nvor_public_liability_rate_t.Location = new System.Drawing.Point(36, 57);
            this.nvor_public_liability_rate_t.Name = "nvor_public_liability_rate_t";
            this.nvor_public_liability_rate_t.Size = new System.Drawing.Size(136, 13);
            this.nvor_public_liability_rate_t.TabIndex = 0;
            this.nvor_public_liability_rate_t.Text = "Public Liability ($ pa)";
            this.nvor_public_liability_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_carrier_risk_rate_t
            // 
            this.nvor_carrier_risk_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nvor_carrier_risk_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_carrier_risk_rate_t.ForeColor = System.Drawing.Color.Black;
            this.nvor_carrier_risk_rate_t.Location = new System.Drawing.Point(55, 78);
            this.nvor_carrier_risk_rate_t.Name = "nvor_carrier_risk_rate_t";
            this.nvor_carrier_risk_rate_t.Size = new System.Drawing.Size(117, 13);
            this.nvor_carrier_risk_rate_t.TabIndex = 0;
            this.nvor_carrier_risk_rate_t.Text = "Carrier Risk ($ pa)";
            this.nvor_carrier_risk_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_item_proc_rate_per_hour_t
            // 
            this.nvor_item_proc_rate_per_hour_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nvor_item_proc_rate_per_hour_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_item_proc_rate_per_hour_t.ForeColor = System.Drawing.Color.Black;
            this.nvor_item_proc_rate_per_hour_t.Location = new System.Drawing.Point(14, 99);
            this.nvor_item_proc_rate_per_hour_t.Name = "nvor_item_proc_rate_per_hour_t";
            this.nvor_item_proc_rate_per_hour_t.Size = new System.Drawing.Size(158, 13);
            this.nvor_item_proc_rate_per_hour_t.TabIndex = 0;
            this.nvor_item_proc_rate_per_hour_t.Text = "Item Processing Rate/Hr";
            this.nvor_item_proc_rate_per_hour_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_accounting_t
            // 
            this.nvor_accounting_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nvor_accounting_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_accounting_t.ForeColor = System.Drawing.Color.Black;
            this.nvor_accounting_t.Location = new System.Drawing.Point(62, 120);
            this.nvor_accounting_t.Name = "nvor_accounting_t";
            this.nvor_accounting_t.Size = new System.Drawing.Size(110, 13);
            this.nvor_accounting_t.TabIndex = 0;
            this.nvor_accounting_t.Text = "Accounting ($ pa)";
            this.nvor_accounting_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_telephone_t
            // 
            this.nvor_telephone_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nvor_telephone_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_telephone_t.ForeColor = System.Drawing.Color.Black;
            this.nvor_telephone_t.Location = new System.Drawing.Point(64, 141);
            this.nvor_telephone_t.Name = "nvor_telephone_t";
            this.nvor_telephone_t.Size = new System.Drawing.Size(108, 13);
            this.nvor_telephone_t.TabIndex = 0;
            this.nvor_telephone_t.Text = "Telephone ($ pa)";
            this.nvor_telephone_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_sundries_t
            // 
            this.nvor_sundries_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nvor_sundries_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_sundries_t.ForeColor = System.Drawing.Color.Black;
            this.nvor_sundries_t.Location = new System.Drawing.Point(74, 162);
            this.nvor_sundries_t.Name = "nvor_sundries_t";
            this.nvor_sundries_t.Size = new System.Drawing.Size(98, 13);
            this.nvor_sundries_t.TabIndex = 0;
            this.nvor_sundries_t.Text = "Sundries ($ pa)";
            this.nvor_sundries_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_acc_rate_t
            // 
            this.nvor_acc_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nvor_acc_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_acc_rate_t.ForeColor = System.Drawing.Color.Black;
            this.nvor_acc_rate_t.Location = new System.Drawing.Point(123, 183);
            this.nvor_acc_rate_t.Name = "nvor_acc_rate_t";
            this.nvor_acc_rate_t.Size = new System.Drawing.Size(49, 13);
            this.nvor_acc_rate_t.TabIndex = 0;
            this.nvor_acc_rate_t.Text = "ACC (%)";
            this.nvor_acc_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_1
            // 
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(126, 204);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(46, 13);
            this.t_1.TabIndex = 0;
            this.t_1.Text = "ACC ($)";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_2
            // 
            this.t_2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_2.ForeColor = System.Drawing.Color.Black;
            this.t_2.Location = new System.Drawing.Point(68, 227);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(104, 13);
            this.t_2.TabIndex = 0;
            this.t_2.Text = "Wardrobe ($ pa)";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_public_liability_rate
            // 
            this.nvor_public_liability_rate.BackColor = System.Drawing.SystemColors.Window;
            this.nvor_public_liability_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorPublicLiabilityRate2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_public_liability_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_public_liability_rate.Location = new System.Drawing.Point(179, 57);
            this.nvor_public_liability_rate.Name = "nvor_public_liability_rate";
            this.nvor_public_liability_rate.Size = new System.Drawing.Size(68, 20);
            this.nvor_public_liability_rate.TabIndex = 30;
            this.nvor_public_liability_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_carrier_risk_rate
            // 
            this.nvor_carrier_risk_rate.BackColor = System.Drawing.SystemColors.Window;
            this.nvor_carrier_risk_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorCarrierRiskRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_carrier_risk_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_carrier_risk_rate.Location = new System.Drawing.Point(179, 77);
            this.nvor_carrier_risk_rate.Name = "nvor_carrier_risk_rate";
            this.nvor_carrier_risk_rate.Size = new System.Drawing.Size(68, 20);
            this.nvor_carrier_risk_rate.TabIndex = 40;
            this.nvor_carrier_risk_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_item_proc_rate_per_hour
            // 
            this.nvor_item_proc_rate_per_hour.BackColor = System.Drawing.SystemColors.Window;
            this.nvor_item_proc_rate_per_hour.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorItemProcRatePerHour", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_item_proc_rate_per_hour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_item_proc_rate_per_hour.Location = new System.Drawing.Point(179, 99);
            this.nvor_item_proc_rate_per_hour.Name = "nvor_item_proc_rate_per_hour";
            this.nvor_item_proc_rate_per_hour.Size = new System.Drawing.Size(68, 20);
            this.nvor_item_proc_rate_per_hour.TabIndex = 50;
            this.nvor_item_proc_rate_per_hour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_accounting
            // 
            this.nvor_accounting.BackColor = System.Drawing.SystemColors.Window;
            this.nvor_accounting.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorAccounting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_accounting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_accounting.Location = new System.Drawing.Point(179, 120);
            this.nvor_accounting.Name = "nvor_accounting";
            this.nvor_accounting.Size = new System.Drawing.Size(68, 20);
            this.nvor_accounting.TabIndex = 60;
            this.nvor_accounting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_telephone
            // 
            this.nvor_telephone.BackColor = System.Drawing.SystemColors.Window;
            this.nvor_telephone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorTelephone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_telephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_telephone.Location = new System.Drawing.Point(179, 141);
            this.nvor_telephone.Name = "nvor_telephone";
            this.nvor_telephone.Size = new System.Drawing.Size(68, 20);
            this.nvor_telephone.TabIndex = 70;
            this.nvor_telephone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_sundries
            // 
            this.nvor_sundries.BackColor = System.Drawing.SystemColors.Window;
            this.nvor_sundries.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorSundries", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_sundries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_sundries.Location = new System.Drawing.Point(179, 162);
            this.nvor_sundries.Name = "nvor_sundries";
            this.nvor_sundries.Size = new System.Drawing.Size(68, 20);
            this.nvor_sundries.TabIndex = 80;
            this.nvor_sundries.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_acc_rate
            // 
            this.nvor_acc_rate.BackColor = System.Drawing.SystemColors.Window;
            this.nvor_acc_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorAccRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_acc_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_acc_rate.Location = new System.Drawing.Point(179, 183);
            this.nvor_acc_rate.Name = "nvor_acc_rate";
            this.nvor_acc_rate.Size = new System.Drawing.Size(68, 20);
            this.nvor_acc_rate.TabIndex = 90;
            this.nvor_acc_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_acc_rate_amount
            // 
            this.nvor_acc_rate_amount.BackColor = System.Drawing.SystemColors.Window;
            this.nvor_acc_rate_amount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorAccRateAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_acc_rate_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_acc_rate_amount.Location = new System.Drawing.Point(179, 204);
            this.nvor_acc_rate_amount.Name = "nvor_acc_rate_amount";
            this.nvor_acc_rate_amount.Size = new System.Drawing.Size(68, 20);
            this.nvor_acc_rate_amount.TabIndex = 100;
            this.nvor_acc_rate_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_uniform
            // 
            this.nvor_uniform.BackColor = System.Drawing.SystemColors.Window;
            this.nvor_uniform.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorUniform", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_uniform.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_uniform.Location = new System.Drawing.Point(179, 225);
            this.nvor_uniform.Name = "nvor_uniform";
            this.nvor_uniform.Size = new System.Drawing.Size(68, 20);
            this.nvor_uniform.TabIndex = 110;
            this.nvor_uniform.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_processing_wage_rate_t
            // 
            this.nvor_processing_wage_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nvor_processing_wage_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_processing_wage_rate_t.ForeColor = System.Drawing.Color.Black;
            this.nvor_processing_wage_rate_t.Location = new System.Drawing.Point(31, 15);
            this.nvor_processing_wage_rate_t.Name = "nvor_processing_wage_rate_t";
            this.nvor_processing_wage_rate_t.Size = new System.Drawing.Size(141, 13);
            this.nvor_processing_wage_rate_t.TabIndex = 0;
            this.nvor_processing_wage_rate_t.Text = "Processing Wage Rate";
            this.nvor_processing_wage_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nvor_processing_wage_rate
            // 
            this.nvor_processing_wage_rate.BackColor = System.Drawing.SystemColors.Window;
            this.nvor_processing_wage_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorProcessingWageRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_processing_wage_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_processing_wage_rate.ForeColor = System.Drawing.Color.Black;
            this.nvor_processing_wage_rate.Location = new System.Drawing.Point(179, 15);
            this.nvor_processing_wage_rate.Name = "nvor_processing_wage_rate";
            this.nvor_processing_wage_rate.Size = new System.Drawing.Size(68, 20);
            this.nvor_processing_wage_rate.TabIndex = 10;
            this.nvor_processing_wage_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_delivery_wage_rate
            // 
            this.nvor_delivery_wage_rate.BackColor = System.Drawing.SystemColors.Window;
            this.nvor_delivery_wage_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorDeliveryWageRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_delivery_wage_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_delivery_wage_rate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.nvor_delivery_wage_rate.Location = new System.Drawing.Point(179, 36);
            this.nvor_delivery_wage_rate.Name = "nvor_delivery_wage_rate";
            this.nvor_delivery_wage_rate.Size = new System.Drawing.Size(68, 20);
            this.nvor_delivery_wage_rate.TabIndex = 20;
            this.nvor_delivery_wage_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nvor_relief_weeks_t
            // 
            this.nvor_relief_weeks_t.AutoSize = true;
            this.nvor_relief_weeks_t.Location = new System.Drawing.Point(101, 248);
            this.nvor_relief_weeks_t.Name = "nvor_relief_weeks_t";
            this.nvor_relief_weeks_t.Size = new System.Drawing.Size(71, 13);
            this.nvor_relief_weeks_t.TabIndex = 0;
            this.nvor_relief_weeks_t.Text = "Relief Weeks";
            // 
            // nvor_relief_weeks
            // 
            this.nvor_relief_weeks.BackColor = System.Drawing.SystemColors.Window;
            this.nvor_relief_weeks.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NvorReliefWeeks", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nvor_relief_weeks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nvor_relief_weeks.ForeColor = System.Drawing.Color.Black;
            this.nvor_relief_weeks.Location = new System.Drawing.Point(178, 245);
            this.nvor_relief_weeks.Name = "nvor_relief_weeks";
            this.nvor_relief_weeks.Size = new System.Drawing.Size(68, 20);
            this.nvor_relief_weeks.TabIndex = 111;
            this.nvor_relief_weeks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DNonVehicleOverrideRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nvor_relief_weeks);
            this.Controls.Add(this.t_2);
            this.Controls.Add(this.nvor_relief_weeks_t);
            this.Controls.Add(this.nvor_delivery_wage_rate_t);
            this.Controls.Add(this.nvor_public_liability_rate_t);
            this.Controls.Add(this.nvor_carrier_risk_rate_t);
            this.Controls.Add(this.nvor_item_proc_rate_per_hour_t);
            this.Controls.Add(this.nvor_accounting_t);
            this.Controls.Add(this.nvor_telephone_t);
            this.Controls.Add(this.nvor_sundries_t);
            this.Controls.Add(this.nvor_acc_rate_t);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.nvor_public_liability_rate);
            this.Controls.Add(this.nvor_carrier_risk_rate);
            this.Controls.Add(this.nvor_item_proc_rate_per_hour);
            this.Controls.Add(this.nvor_accounting);
            this.Controls.Add(this.nvor_telephone);
            this.Controls.Add(this.nvor_sundries);
            this.Controls.Add(this.nvor_acc_rate);
            this.Controls.Add(this.nvor_acc_rate_amount);
            this.Controls.Add(this.nvor_uniform);
            this.Controls.Add(this.nvor_processing_wage_rate_t);
            this.Controls.Add(this.nvor_processing_wage_rate);
            this.Controls.Add(this.nvor_delivery_wage_rate);
            this.Name = "DNonVehicleOverrideRates";
            this.Size = new System.Drawing.Size(346, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        //private void ActiveEvent()
        //{
        //    foreach (Control var in this.Controls)
        //    {
        //        var.GotFocus += new System.EventHandler(var_GotFocus);
        //    }
        //}

        void var_GotFocus(object sender, System.EventArgs e)
        {
            this.OnGotFocus(e);
        }
        #endregion

        private System.Windows.Forms.TextBox nvor_item_proc_rate_per_hour;
        private System.Windows.Forms.Label nvor_item_proc_rate_per_hour_t;
        private System.Windows.Forms.TextBox nvor_accounting;
        private System.Windows.Forms.TextBox nvor_processing_wage_rate;
        private System.Windows.Forms.TextBox nvor_sundries;
        private System.Windows.Forms.Label nvor_carrier_risk_rate_t;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.Label nvor_telephone_t;
        private System.Windows.Forms.Label nvor_accounting_t;
        private System.Windows.Forms.Label nvor_delivery_wage_rate_t;
        private System.Windows.Forms.Label nvor_sundries_t;
        private System.Windows.Forms.TextBox nvor_telephone;
        private System.Windows.Forms.Label nvor_public_liability_rate_t;
        private System.Windows.Forms.TextBox nvor_carrier_risk_rate;
        private System.Windows.Forms.TextBox nvor_public_liability_rate;
        private System.Windows.Forms.TextBox nvor_uniform;
        private System.Windows.Forms.Label nvor_processing_wage_rate_t;
        private System.Windows.Forms.TextBox nvor_delivery_wage_rate;
        private System.Windows.Forms.TextBox nvor_acc_rate_amount;
        private System.Windows.Forms.TextBox nvor_acc_rate;
        private System.Windows.Forms.Label nvor_acc_rate_t;
        private System.Windows.Forms.Label nvor_relief_weeks_t;
        private System.Windows.Forms.TextBox nvor_relief_weeks;
	}
}
