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

        private System.Windows.Forms.TextBox nvor_item_proc_rate_per_hour;
        private System.Windows.Forms.Label nvor_item_proc_rate_per_hour_t;
        private System.Windows.Forms.TextBox nvor_accounting;
        private System.Windows.Forms.TextBox nvor_processing_wage_rate_1;
        private System.Windows.Forms.TextBox nvor_sundries;
        private System.Windows.Forms.Label nvor_carrier_risk_rate_t;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.Label nvor_telephone_t;
        private System.Windows.Forms.Label nvor_accounting_t;
        private System.Windows.Forms.Label nvor_delivery_wage_rate_t;
        private System.Windows.Forms.Label nvor_sundries_t;
        private System.Windows.Forms.TextBox nvor_telephone;
        private System.Windows.Forms.Label nvor_public_liability_rate_2_t;
        private System.Windows.Forms.TextBox nvor_carrier_risk_rate;
        private System.Windows.Forms.TextBox nvor_public_liability_rate_2;
        private System.Windows.Forms.TextBox nvor_uniform;
        private System.Windows.Forms.Label nvor_processing_wage_rate_t;
        private System.Windows.Forms.TextBox nvor_delivery_wage_rate_1;
        private System.Windows.Forms.TextBox nvor_acc_rate_amount;
        private System.Windows.Forms.TextBox nvor_acc_rate;
        private System.Windows.Forms.Label nvor_acc_rate_t;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DNonVehicleOverrideRates";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.NonVehicleOverrideRates);
			//
			// nvor_delivery_wage_rate_t
			//
			this.nvor_delivery_wage_rate_t = new System.Windows.Forms.Label();
			this.nvor_delivery_wage_rate_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.nvor_delivery_wage_rate_t.ForeColor = System.Drawing.Color.Black;
			this.nvor_delivery_wage_rate_t.Location = new System.Drawing.Point(31, 36);
			this.nvor_delivery_wage_rate_t.Name = "nvor_delivery_wage_rate_t";
			this.nvor_delivery_wage_rate_t.Size = new System.Drawing.Size(141, 13);
			this.nvor_delivery_wage_rate_t.Text = "Delivery Wage Rate";
			this.nvor_delivery_wage_rate_t.TextAlign = ContentAlignment.MiddleRight;
			this.nvor_delivery_wage_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(nvor_delivery_wage_rate_t);

			//
			// nvor_public_liability_rate_2_t
			//
			this.nvor_public_liability_rate_2_t = new System.Windows.Forms.Label();
			this.nvor_public_liability_rate_2_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.nvor_public_liability_rate_2_t.ForeColor = System.Drawing.Color.Black;
			this.nvor_public_liability_rate_2_t.Location = new System.Drawing.Point(36, 57);
			this.nvor_public_liability_rate_2_t.Name = "nvor_public_liability_rate_2_t";
			this.nvor_public_liability_rate_2_t.Size = new System.Drawing.Size(136, 13);
			this.nvor_public_liability_rate_2_t.Text = "Public Liability ($ pa)";
			this.nvor_public_liability_rate_2_t.TextAlign = ContentAlignment.MiddleRight;
			this.nvor_public_liability_rate_2_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(nvor_public_liability_rate_2_t);

			//
			// nvor_carrier_risk_rate_t
			//
			this.nvor_carrier_risk_rate_t = new System.Windows.Forms.Label();
			this.nvor_carrier_risk_rate_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.nvor_carrier_risk_rate_t.ForeColor = System.Drawing.Color.Black;
			this.nvor_carrier_risk_rate_t.Location = new System.Drawing.Point(55, 78);
			this.nvor_carrier_risk_rate_t.Name = "nvor_carrier_risk_rate_t";
			this.nvor_carrier_risk_rate_t.Size = new System.Drawing.Size(117, 13);
			this.nvor_carrier_risk_rate_t.Text = "Carrier Risk ($ pa)";
			this.nvor_carrier_risk_rate_t.TextAlign = ContentAlignment.MiddleRight;
			this.nvor_carrier_risk_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(nvor_carrier_risk_rate_t);

			//
			// nvor_item_proc_rate_per_hour_t
			//
			this.nvor_item_proc_rate_per_hour_t = new System.Windows.Forms.Label();
			this.nvor_item_proc_rate_per_hour_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.nvor_item_proc_rate_per_hour_t.ForeColor = System.Drawing.Color.Black;
			this.nvor_item_proc_rate_per_hour_t.Location = new System.Drawing.Point(14, 99);
			this.nvor_item_proc_rate_per_hour_t.Name = "nvor_item_proc_rate_per_hour_t";
			this.nvor_item_proc_rate_per_hour_t.Size = new System.Drawing.Size(158, 13);
			this.nvor_item_proc_rate_per_hour_t.Text = "Item Processing Rate/Hr";
			this.nvor_item_proc_rate_per_hour_t.TextAlign = ContentAlignment.MiddleRight;
			this.nvor_item_proc_rate_per_hour_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(nvor_item_proc_rate_per_hour_t);

			//
			// nvor_accounting_t
			//
			this.nvor_accounting_t = new System.Windows.Forms.Label();
			this.nvor_accounting_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.nvor_accounting_t.ForeColor = System.Drawing.Color.Black;
			this.nvor_accounting_t.Location = new System.Drawing.Point(62, 120);
			this.nvor_accounting_t.Name = "nvor_accounting_t";
			this.nvor_accounting_t.Size = new System.Drawing.Size(110, 13);
			this.nvor_accounting_t.Text = "Accounting ($ pa)";
			this.nvor_accounting_t.TextAlign = ContentAlignment.MiddleRight;
			this.nvor_accounting_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(nvor_accounting_t);

			//
			// nvor_telephone_t
			//
			this.nvor_telephone_t = new System.Windows.Forms.Label();
			this.nvor_telephone_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.nvor_telephone_t.ForeColor = System.Drawing.Color.Black;
			this.nvor_telephone_t.Location = new System.Drawing.Point(64, 141);
			this.nvor_telephone_t.Name = "nvor_telephone_t";
			this.nvor_telephone_t.Size = new System.Drawing.Size(108, 13);
			this.nvor_telephone_t.Text = "Telephone ($ pa)";
			this.nvor_telephone_t.TextAlign = ContentAlignment.MiddleRight;
			this.nvor_telephone_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(nvor_telephone_t);

			//
			// nvor_sundries_t
			//
			this.nvor_sundries_t = new System.Windows.Forms.Label();
			this.nvor_sundries_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.nvor_sundries_t.ForeColor = System.Drawing.Color.Black;
			this.nvor_sundries_t.Location = new System.Drawing.Point(74, 162);
			this.nvor_sundries_t.Name = "nvor_sundries_t";
			this.nvor_sundries_t.Size = new System.Drawing.Size(98, 13);
			this.nvor_sundries_t.Text = "Sundries ($ pa)";
			this.nvor_sundries_t.TextAlign = ContentAlignment.MiddleRight;
			this.nvor_sundries_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(nvor_sundries_t);

			//
			// nvor_acc_rate_t
			//
			this.nvor_acc_rate_t = new System.Windows.Forms.Label();
			this.nvor_acc_rate_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.nvor_acc_rate_t.ForeColor = System.Drawing.Color.Black;
			this.nvor_acc_rate_t.Location = new System.Drawing.Point(123, 183);
			this.nvor_acc_rate_t.Name = "nvor_acc_rate_t";
			this.nvor_acc_rate_t.Size = new System.Drawing.Size(49, 13);
			this.nvor_acc_rate_t.Text = "ACC (%)";
			this.nvor_acc_rate_t.TextAlign = ContentAlignment.MiddleRight;
			this.nvor_acc_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(nvor_acc_rate_t);

			//
			// t_1
			//
			this.t_1 = new System.Windows.Forms.Label();
			this.t_1.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.t_1.ForeColor = System.Drawing.Color.Black;
			this.t_1.Location = new System.Drawing.Point(126, 204);
			this.t_1.Name = "t_1";
			this.t_1.Size = new System.Drawing.Size(46, 13);
			this.t_1.Text = "ACC ($)";
			this.t_1.TextAlign = ContentAlignment.MiddleRight;
			this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(t_1);

			//
			// t_2
			//
			this.t_2 = new System.Windows.Forms.Label();
			this.t_2.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.t_2.ForeColor = System.Drawing.Color.Black;
			this.t_2.Location = new System.Drawing.Point(68, 224);
			this.t_2.Name = "t_2";
			this.t_2.Size = new System.Drawing.Size(104, 13);
			this.t_2.Text = "Wardrobe ($ pa)";
			this.t_2.TextAlign = ContentAlignment.MiddleRight;
			this.t_2.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(t_2);

			//
			// nvor_public_liability_rate_2
			//
			nvor_public_liability_rate_2 = new System.Windows.Forms.TextBox();
			this.nvor_public_liability_rate_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.nvor_public_liability_rate_2.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			//?this.nvor_public_liability_rate_2.ForeColor = System.Drawing.ColorTranslator.FromWin32(0~tif ( isnull(     nvor_public_liability_rate_2 ),rgb(192,192,192) , rgb(0,0,0) ));
			this.nvor_public_liability_rate_2.Location = new System.Drawing.Point(179, 57);
			this.nvor_public_liability_rate_2.MaxLength = 0;
			this.nvor_public_liability_rate_2.Name = "nvor_public_liability_rate_2";
			this.nvor_public_liability_rate_2.Size = new System.Drawing.Size(68, 14);
			this.nvor_public_liability_rate_2.TextAlign = HorizontalAlignment.Right;
			this.nvor_public_liability_rate_2.BackColor = System.Drawing.SystemColors.Window;
			this.nvor_public_liability_rate_2.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "NvorPublicLiabilityRate2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.nvor_public_liability_rate_2.TabIndex = 30;
			this.Controls.Add(nvor_public_liability_rate_2);

			//
			// nvor_carrier_risk_rate
			//
			nvor_carrier_risk_rate = new System.Windows.Forms.TextBox();
			this.nvor_carrier_risk_rate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.nvor_carrier_risk_rate.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			//?this.nvor_carrier_risk_rate.ForeColor = System.Drawing.ColorTranslator.FromWin32(0~tif ( isnull(     nvor_carrier_risk_rate ),rgb(192,192,192) , rgb(0,0,0) ));
			this.nvor_carrier_risk_rate.Location = new System.Drawing.Point(179, 77);
			this.nvor_carrier_risk_rate.MaxLength = 0;
			this.nvor_carrier_risk_rate.Name = "nvor_carrier_risk_rate";
			this.nvor_carrier_risk_rate.Size = new System.Drawing.Size(68, 14);
			this.nvor_carrier_risk_rate.TextAlign = HorizontalAlignment.Right;
			this.nvor_carrier_risk_rate.BackColor = System.Drawing.SystemColors.Window;
			this.nvor_carrier_risk_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "NvorCarrierRiskRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.nvor_carrier_risk_rate.TabIndex = 40;
			this.Controls.Add(nvor_carrier_risk_rate);

			//
			// nvor_item_proc_rate_per_hour
			//
			nvor_item_proc_rate_per_hour = new System.Windows.Forms.TextBox();
			this.nvor_item_proc_rate_per_hour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.nvor_item_proc_rate_per_hour.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			//?this.nvor_item_proc_rate_per_hour.ForeColor = System.Drawing.ColorTranslator.FromWin32(0~tif ( isnull(     nvor_item_proc_rate_per_hour ),rgb(192,192,192) , rgb(0,0,0) ));
			this.nvor_item_proc_rate_per_hour.Location = new System.Drawing.Point(179, 99);
			this.nvor_item_proc_rate_per_hour.MaxLength = 0;
			this.nvor_item_proc_rate_per_hour.Name = "nvor_item_proc_rate_per_hour";
			this.nvor_item_proc_rate_per_hour.Size = new System.Drawing.Size(68, 14);
			this.nvor_item_proc_rate_per_hour.TextAlign = HorizontalAlignment.Right;
			this.nvor_item_proc_rate_per_hour.BackColor = System.Drawing.SystemColors.Window;
			this.nvor_item_proc_rate_per_hour.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "NvorItemProcRatePerHour", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.nvor_item_proc_rate_per_hour.TabIndex = 50;
			this.Controls.Add(nvor_item_proc_rate_per_hour);

			//
			// nvor_accounting
			//
			nvor_accounting = new System.Windows.Forms.TextBox();
			this.nvor_accounting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.nvor_accounting.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			//?this.nvor_accounting.ForeColor = System.Drawing.ColorTranslator.FromWin32(0~tif ( isnull(     nvor_accounting ),rgb(192,192,192) , rgb(0,0,0) ));
			this.nvor_accounting.Location = new System.Drawing.Point(179, 120);
			this.nvor_accounting.MaxLength = 0;
			this.nvor_accounting.Name = "nvor_accounting";
			this.nvor_accounting.Size = new System.Drawing.Size(68, 14);
			this.nvor_accounting.TextAlign = HorizontalAlignment.Right;
			this.nvor_accounting.BackColor = System.Drawing.SystemColors.Window;
			this.nvor_accounting.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "NvorAccounting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.nvor_accounting.TabIndex = 60;
			this.Controls.Add(nvor_accounting);

			//
			// nvor_telephone
			//
			nvor_telephone = new System.Windows.Forms.TextBox();
			this.nvor_telephone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.nvor_telephone.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			//?this.nvor_telephone.ForeColor = System.Drawing.ColorTranslator.FromWin32(0~tif ( isnull(       nvor_telephone ),rgb(192,192,192) , rgb(0,0,0) ));
			this.nvor_telephone.Location = new System.Drawing.Point(179, 141);
			this.nvor_telephone.MaxLength = 0;
			this.nvor_telephone.Name = "nvor_telephone";
			this.nvor_telephone.Size = new System.Drawing.Size(68, 14);
			this.nvor_telephone.TextAlign = HorizontalAlignment.Right;
			this.nvor_telephone.BackColor = System.Drawing.SystemColors.Window;
			this.nvor_telephone.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "NvorTelephone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.nvor_telephone.TabIndex = 70;
			this.Controls.Add(nvor_telephone);

			//
			// nvor_sundries
			//
			nvor_sundries = new System.Windows.Forms.TextBox();
			this.nvor_sundries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.nvor_sundries.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			//?this.nvor_sundries.ForeColor = System.Drawing.ColorTranslator.FromWin32(0~tif ( isnull(     nvor_sundries ),rgb(192,192,192) , rgb(0,0,0) ));
			this.nvor_sundries.Location = new System.Drawing.Point(179, 162);
			this.nvor_sundries.MaxLength = 0;
			this.nvor_sundries.Name = "nvor_sundries";
			this.nvor_sundries.Size = new System.Drawing.Size(68, 14);
			this.nvor_sundries.TextAlign = HorizontalAlignment.Right;
			this.nvor_sundries.BackColor = System.Drawing.SystemColors.Window;
			this.nvor_sundries.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "NvorSundries", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.nvor_sundries.TabIndex = 80;
			this.Controls.Add(nvor_sundries);

			//
			// nvor_acc_rate
			//
			nvor_acc_rate = new System.Windows.Forms.TextBox();
			this.nvor_acc_rate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.nvor_acc_rate.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			//?this.nvor_acc_rate.ForeColor = System.Drawing.ColorTranslator.FromWin32(0~tif ( isnull(      nvor_acc_rate ),rgb(192,192,192) , rgb(0,0,0) ));
			this.nvor_acc_rate.Location = new System.Drawing.Point(179, 183);
			this.nvor_acc_rate.MaxLength = 0;
			this.nvor_acc_rate.Name = "nvor_acc_rate";
			this.nvor_acc_rate.Size = new System.Drawing.Size(68, 14);
			this.nvor_acc_rate.TextAlign = HorizontalAlignment.Right;
            this.nvor_acc_rate.BackColor = System.Drawing.SystemColors.Window;
			this.nvor_acc_rate.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "NvorAccRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.nvor_acc_rate.TabIndex = 90;
			this.Controls.Add(nvor_acc_rate);

			//
			// nvor_acc_rate_amount
			//
			nvor_acc_rate_amount = new System.Windows.Forms.TextBox();
			this.nvor_acc_rate_amount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.nvor_acc_rate_amount.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			//?this.nvor_acc_rate_amount.ForeColor = System.Drawing.ColorTranslator.FromWin32(0~tif ( isnull(     nvor_acc_rate_amount ),rgb(192,192,192) , rgb(0,0,0) ));
			this.nvor_acc_rate_amount.Location = new System.Drawing.Point(179, 204);
			this.nvor_acc_rate_amount.MaxLength = 0;
			this.nvor_acc_rate_amount.Name = "nvor_acc_rate_amount";
			this.nvor_acc_rate_amount.Size = new System.Drawing.Size(68, 14);
			this.nvor_acc_rate_amount.TextAlign = HorizontalAlignment.Right;
            this.nvor_acc_rate_amount.BackColor = System.Drawing.SystemColors.Window;
			this.nvor_acc_rate_amount.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "NvorAccRateAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.nvor_acc_rate_amount.TabIndex = 100;
			this.Controls.Add(nvor_acc_rate_amount);

			//
			// nvor_uniform
			//
			nvor_uniform = new System.Windows.Forms.TextBox();
			this.nvor_uniform.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.nvor_uniform.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            //?this.nvor_uniform.ForeColor = System.Drawing.ColorTranslator.FromWin32(0~tif ( isnull(     nvor_uniform ),rgb(192,192,192) , rgb(0,0,0) ));
			this.nvor_uniform.Location = new System.Drawing.Point(179, 225);
			this.nvor_uniform.MaxLength = 0;
			this.nvor_uniform.Name = "nvor_uniform";
			this.nvor_uniform.Size = new System.Drawing.Size(68, 14);
			this.nvor_uniform.TextAlign = HorizontalAlignment.Right;
            this.nvor_uniform.BackColor = System.Drawing.SystemColors.Window;
			this.nvor_uniform.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "NvorUniform", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.nvor_uniform.TabIndex = 110;
			this.Controls.Add(nvor_uniform);

			//
			// nvor_processing_wage_rate_t
			//
			this.nvor_processing_wage_rate_t = new System.Windows.Forms.Label();
			this.nvor_processing_wage_rate_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.nvor_processing_wage_rate_t.ForeColor = System.Drawing.Color.Black;
			this.nvor_processing_wage_rate_t.Location = new System.Drawing.Point(31, 15);
			this.nvor_processing_wage_rate_t.Name = "nvor_processing_wage_rate_t";
			this.nvor_processing_wage_rate_t.Size = new System.Drawing.Size(141, 13);
			this.nvor_processing_wage_rate_t.Text = "Processing Wage Rate";
			this.nvor_processing_wage_rate_t.TextAlign = ContentAlignment.MiddleRight;
			this.nvor_processing_wage_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(nvor_processing_wage_rate_t);

			//
			// nvor_processing_wage_rate_1
			//
			nvor_processing_wage_rate_1 = new System.Windows.Forms.TextBox();
			this.nvor_processing_wage_rate_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.nvor_processing_wage_rate_1.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.nvor_processing_wage_rate_1.ForeColor = System.Drawing.Color.Black;
			this.nvor_processing_wage_rate_1.Location = new System.Drawing.Point(179, 15);
			this.nvor_processing_wage_rate_1.MaxLength = 0;
			this.nvor_processing_wage_rate_1.Name = "nvor_processing_wage_rate_1";
			this.nvor_processing_wage_rate_1.Size = new System.Drawing.Size(68, 14);
			this.nvor_processing_wage_rate_1.TextAlign = HorizontalAlignment.Right;
            this.nvor_processing_wage_rate_1.BackColor = System.Drawing.SystemColors.Window;
			this.nvor_processing_wage_rate_1.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "NvorProcessingWageRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.nvor_processing_wage_rate_1.TabIndex = 10;
			this.Controls.Add(nvor_processing_wage_rate_1);

			//
			// nvor_delivery_wage_rate_1
			//
			nvor_delivery_wage_rate_1 = new System.Windows.Forms.TextBox();
			this.nvor_delivery_wage_rate_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.nvor_delivery_wage_rate_1.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.nvor_delivery_wage_rate_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.nvor_delivery_wage_rate_1.Location = new System.Drawing.Point(179, 36);
			this.nvor_delivery_wage_rate_1.MaxLength = 0;
			this.nvor_delivery_wage_rate_1.Name = "nvor_delivery_wage_rate_1";
			this.nvor_delivery_wage_rate_1.Size = new System.Drawing.Size(68, 14);
			this.nvor_delivery_wage_rate_1.TextAlign = HorizontalAlignment.Right;
			this.nvor_delivery_wage_rate_1.BackColor = System.Drawing.SystemColors.Window;
			this.nvor_delivery_wage_rate_1.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "NvorDeliveryWageRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.nvor_delivery_wage_rate_1.TabIndex = 20;
			this.Controls.Add(nvor_delivery_wage_rate_1);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //!ActiveEvent();   - moved to constructor
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

	}
}
