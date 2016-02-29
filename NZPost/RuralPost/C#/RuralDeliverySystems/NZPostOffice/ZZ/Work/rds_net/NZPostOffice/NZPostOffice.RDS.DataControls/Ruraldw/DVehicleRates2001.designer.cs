using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DVehicleRates2001
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private System.Windows.Forms.Label   vr_sundries_k_t;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox vr_ruc;
		//private System.Windows.Forms.MaskedTextBox   vr_ruc;
		private System.Windows.Forms.Label   vr_nominal_vehicle_value_t;
		private System.Windows.Forms.Label   vr_repairs_maintenance_rate_t;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox vr_licence_rate;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox vr_nominal_vehicle_value;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox vr_livery;
		private System.Windows.Forms.Label   vr_ruc_t;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox vr_tyre_tubes_rate;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox vr_vehicle_rate_of_return_pct;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox vr_repairs_maintenance_rate;
		private System.Windows.Forms.Label   vr_salvage_ratio_t;
		private System.Windows.Forms.Label   vr_vehicle_value_insurance_pct_t;
		private System.Windows.Forms.Label   vr_vehicle_rate_of_return_pct_t;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox vr_vehicle_value_insurance_pct;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox vr_salvage_ratio;
		private System.Windows.Forms.Label   vr_licence_rate_t;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox vr_sundries_k;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox vr_vehicle_allowance_rate;
		private System.Windows.Forms.Label   vr_tyre_tubes_rate_t;
		private System.Windows.Forms.Label   vr_vehicle_allowance_rate_t;
        private System.Windows.Forms.Label t_1;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
            this.vr_nominal_vehicle_value = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.vr_repairs_maintenance_rate = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.vr_tyre_tubes_rate = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.vr_licence_rate = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.vr_vehicle_rate_of_return_pct = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.vr_salvage_ratio = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.vr_ruc = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.vr_sundries_k = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.vr_vehicle_value_insurance_pct = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.vr_livery = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.vr_vehicle_allowance_rate = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.vr_nominal_vehicle_value_t = new System.Windows.Forms.Label();
            this.vr_repairs_maintenance_rate_t = new System.Windows.Forms.Label();
            this.vr_tyre_tubes_rate_t = new System.Windows.Forms.Label();
            this.vr_licence_rate_t = new System.Windows.Forms.Label();
            this.vr_vehicle_rate_of_return_pct_t = new System.Windows.Forms.Label();
            this.vr_salvage_ratio_t = new System.Windows.Forms.Label();
            this.vr_ruc_t = new System.Windows.Forms.Label();
            this.vr_sundries_k_t = new System.Windows.Forms.Label();
            this.vr_vehicle_value_insurance_pct_t = new System.Windows.Forms.Label();
            this.vr_vehicle_allowance_rate_t = new System.Windows.Forms.Label();
            this.t_1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.VehicleRates2001);
            // 
            // vr_nominal_vehicle_value
            // 
            this.vr_nominal_vehicle_value.BackColor = System.Drawing.Color.White;
            this.vr_nominal_vehicle_value.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VrNominalVehicleValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vr_nominal_vehicle_value.EditMask = "###,##0.00";
            this.vr_nominal_vehicle_value.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.vr_nominal_vehicle_value.Location = new System.Drawing.Point(231, 13);
            this.vr_nominal_vehicle_value.Name = "vr_nominal_vehicle_value";
            this.vr_nominal_vehicle_value.PromptChar = ' ';
            this.vr_nominal_vehicle_value.Size = new System.Drawing.Size(78, 20);
            this.vr_nominal_vehicle_value.TabIndex = 10;
            this.vr_nominal_vehicle_value.Text = "0.00";
            this.vr_nominal_vehicle_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vr_nominal_vehicle_value.Value = "0.00";
            // 
            // vr_repairs_maintenance_rate
            // 
            this.vr_repairs_maintenance_rate.BackColor = System.Drawing.Color.White;
            this.vr_repairs_maintenance_rate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VrRepairsMaintenanceRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vr_repairs_maintenance_rate.EditMask = "###,##0.00";
            this.vr_repairs_maintenance_rate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.vr_repairs_maintenance_rate.Location = new System.Drawing.Point(231, 34);
            this.vr_repairs_maintenance_rate.Name = "vr_repairs_maintenance_rate";
            this.vr_repairs_maintenance_rate.PromptChar = ' ';
            this.vr_repairs_maintenance_rate.Size = new System.Drawing.Size(55, 20);
            this.vr_repairs_maintenance_rate.TabIndex = 20;
            this.vr_repairs_maintenance_rate.Text = "0.00";
            this.vr_repairs_maintenance_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vr_repairs_maintenance_rate.Value = "0.00";
            // 
            // vr_tyre_tubes_rate
            // 
            this.vr_tyre_tubes_rate.BackColor = System.Drawing.Color.White;
            this.vr_tyre_tubes_rate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VrTyreTubesRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vr_tyre_tubes_rate.EditMask = "###,##0.00";
            this.vr_tyre_tubes_rate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.vr_tyre_tubes_rate.Location = new System.Drawing.Point(231, 55);
            this.vr_tyre_tubes_rate.Name = "vr_tyre_tubes_rate";
            this.vr_tyre_tubes_rate.PromptChar = ' ';
            this.vr_tyre_tubes_rate.Size = new System.Drawing.Size(55, 20);
            this.vr_tyre_tubes_rate.TabIndex = 30;
            this.vr_tyre_tubes_rate.Text = "0.00";
            this.vr_tyre_tubes_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vr_tyre_tubes_rate.Value = "0.00";
            // 
            // vr_licence_rate
            // 
            this.vr_licence_rate.BackColor = System.Drawing.Color.White;
            this.vr_licence_rate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VrLicenceRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vr_licence_rate.EditMask = "###,##0.00";
            this.vr_licence_rate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.vr_licence_rate.Location = new System.Drawing.Point(231, 76);
            this.vr_licence_rate.Name = "vr_licence_rate";
            this.vr_licence_rate.PromptChar = ' ';
            this.vr_licence_rate.Size = new System.Drawing.Size(55, 20);
            this.vr_licence_rate.TabIndex = 40;
            this.vr_licence_rate.Text = "0.00";
            this.vr_licence_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vr_licence_rate.Value = "0.00";
            // 
            // vr_vehicle_rate_of_return_pct
            // 
            this.vr_vehicle_rate_of_return_pct.BackColor = System.Drawing.Color.White;
            this.vr_vehicle_rate_of_return_pct.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VrVehicleRateOfReturnPct", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vr_vehicle_rate_of_return_pct.EditMask = "###,##0.00";
            this.vr_vehicle_rate_of_return_pct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.vr_vehicle_rate_of_return_pct.Location = new System.Drawing.Point(231, 97);
            this.vr_vehicle_rate_of_return_pct.Name = "vr_vehicle_rate_of_return_pct";
            this.vr_vehicle_rate_of_return_pct.PromptChar = ' ';
            this.vr_vehicle_rate_of_return_pct.Size = new System.Drawing.Size(55, 20);
            this.vr_vehicle_rate_of_return_pct.TabIndex = 50;
            this.vr_vehicle_rate_of_return_pct.Text = "0.00";
            this.vr_vehicle_rate_of_return_pct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vr_vehicle_rate_of_return_pct.Value = "0.00";
            // 
            // vr_salvage_ratio
            // 
            this.vr_salvage_ratio.BackColor = System.Drawing.Color.White;
            this.vr_salvage_ratio.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VrSalvageRatio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vr_salvage_ratio.EditMask = "###,##0.00";
            this.vr_salvage_ratio.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.vr_salvage_ratio.Location = new System.Drawing.Point(231, 118);
            this.vr_salvage_ratio.Name = "vr_salvage_ratio";
            this.vr_salvage_ratio.PromptChar = ' ';
            this.vr_salvage_ratio.Size = new System.Drawing.Size(55, 20);
            this.vr_salvage_ratio.TabIndex = 60;
            this.vr_salvage_ratio.Text = "0.00";
            this.vr_salvage_ratio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vr_salvage_ratio.Value = "0.00";
            // 
            // vr_ruc
            // 
            this.vr_ruc.BackColor = System.Drawing.Color.White;
            this.vr_ruc.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VrRuc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vr_ruc.EditMask = "###,##0.00";
            this.vr_ruc.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.vr_ruc.Location = new System.Drawing.Point(231, 139);
            this.vr_ruc.Name = "vr_ruc";
            this.vr_ruc.PromptChar = ' ';
            this.vr_ruc.Size = new System.Drawing.Size(63, 20);
            this.vr_ruc.TabIndex = 70;
            this.vr_ruc.Text = "0.00";
            this.vr_ruc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vr_ruc.Value = "0.00";
            // 
            // vr_sundries_k
            // 
            this.vr_sundries_k.BackColor = System.Drawing.Color.White;
            this.vr_sundries_k.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VrSundriesK", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vr_sundries_k.EditMask = "###,##0.00";
            this.vr_sundries_k.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.vr_sundries_k.Location = new System.Drawing.Point(231, 160);
            this.vr_sundries_k.Name = "vr_sundries_k";
            this.vr_sundries_k.PromptChar = ' ';
            this.vr_sundries_k.Size = new System.Drawing.Size(63, 20);
            this.vr_sundries_k.TabIndex = 80;
            this.vr_sundries_k.Text = "0.00";
            this.vr_sundries_k.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vr_sundries_k.Value = "0.00";
            // 
            // vr_vehicle_value_insurance_pct
            // 
            this.vr_vehicle_value_insurance_pct.BackColor = System.Drawing.Color.White;
            this.vr_vehicle_value_insurance_pct.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VrVehicleValueInsurancePct", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vr_vehicle_value_insurance_pct.EditMask = "###,##0.00";
            this.vr_vehicle_value_insurance_pct.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.vr_vehicle_value_insurance_pct.Location = new System.Drawing.Point(231, 181);
            this.vr_vehicle_value_insurance_pct.Name = "vr_vehicle_value_insurance_pct";
            this.vr_vehicle_value_insurance_pct.PromptChar = ' ';
            this.vr_vehicle_value_insurance_pct.Size = new System.Drawing.Size(63, 20);
            this.vr_vehicle_value_insurance_pct.TabIndex = 90;
            this.vr_vehicle_value_insurance_pct.Text = "0.00";
            this.vr_vehicle_value_insurance_pct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vr_vehicle_value_insurance_pct.Value = "0.00";
            // 
            // vr_livery
            // 
            this.vr_livery.BackColor = System.Drawing.Color.White;
            this.vr_livery.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VrLivery", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vr_livery.EditMask = "###,##0.00";
            this.vr_livery.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.vr_livery.Location = new System.Drawing.Point(231, 203);
            this.vr_livery.Name = "vr_livery";
            this.vr_livery.PromptChar = ' ';
            this.vr_livery.Size = new System.Drawing.Size(63, 20);
            this.vr_livery.TabIndex = 100;
            this.vr_livery.Text = "0.00";
            this.vr_livery.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vr_livery.Value = "0.00";
            // 
            // vr_vehicle_allowance_rate
            // 
            this.vr_vehicle_allowance_rate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.vr_vehicle_allowance_rate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VrVehicleAllowanceRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vr_vehicle_allowance_rate.EditMask = "";
            this.vr_vehicle_allowance_rate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.vr_vehicle_allowance_rate.Location = new System.Drawing.Point(231, 225);
            this.vr_vehicle_allowance_rate.Name = "vr_vehicle_allowance_rate";
            this.vr_vehicle_allowance_rate.PromptChar = ' ';
            this.vr_vehicle_allowance_rate.ReadOnly = true;
            this.vr_vehicle_allowance_rate.Size = new System.Drawing.Size(63, 20);
            this.vr_vehicle_allowance_rate.TabIndex = 101;
            this.vr_vehicle_allowance_rate.Text = "0";
            this.vr_vehicle_allowance_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vr_vehicle_allowance_rate.Value = "0";
            // 
            // vr_nominal_vehicle_value_t
            // 
            this.vr_nominal_vehicle_value_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.vr_nominal_vehicle_value_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vr_nominal_vehicle_value_t.ForeColor = System.Drawing.Color.Black;
            this.vr_nominal_vehicle_value_t.Location = new System.Drawing.Point(91, 13);
            this.vr_nominal_vehicle_value_t.Name = "vr_nominal_vehicle_value_t";
            this.vr_nominal_vehicle_value_t.Size = new System.Drawing.Size(133, 13);
            this.vr_nominal_vehicle_value_t.TabIndex = 102;
            this.vr_nominal_vehicle_value_t.Text = "Net Vehicle Value ($)";
            this.vr_nominal_vehicle_value_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vr_repairs_maintenance_rate_t
            // 
            this.vr_repairs_maintenance_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.vr_repairs_maintenance_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vr_repairs_maintenance_rate_t.ForeColor = System.Drawing.Color.Black;
            this.vr_repairs_maintenance_rate_t.Location = new System.Drawing.Point(3, 34);
            this.vr_repairs_maintenance_rate_t.Name = "vr_repairs_maintenance_rate_t";
            this.vr_repairs_maintenance_rate_t.Size = new System.Drawing.Size(221, 13);
            this.vr_repairs_maintenance_rate_t.TabIndex = 103;
            this.vr_repairs_maintenance_rate_t.Text = "Repairs and Maintenance Rate ($/1000k)";
            this.vr_repairs_maintenance_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vr_tyre_tubes_rate_t
            // 
            this.vr_tyre_tubes_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.vr_tyre_tubes_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vr_tyre_tubes_rate_t.ForeColor = System.Drawing.Color.Black;
            this.vr_tyre_tubes_rate_t.Location = new System.Drawing.Point(124, 55);
            this.vr_tyre_tubes_rate_t.Name = "vr_tyre_tubes_rate_t";
            this.vr_tyre_tubes_rate_t.Size = new System.Drawing.Size(100, 13);
            this.vr_tyre_tubes_rate_t.TabIndex = 104;
            this.vr_tyre_tubes_rate_t.Text = "Tyres ($/1000k)";
            this.vr_tyre_tubes_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vr_licence_rate_t
            // 
            this.vr_licence_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.vr_licence_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vr_licence_rate_t.ForeColor = System.Drawing.Color.Black;
            this.vr_licence_rate_t.Location = new System.Drawing.Point(107, 76);
            this.vr_licence_rate_t.Name = "vr_licence_rate_t";
            this.vr_licence_rate_t.Size = new System.Drawing.Size(117, 13);
            this.vr_licence_rate_t.TabIndex = 105;
            this.vr_licence_rate_t.Text = "Relicensing ($ pa)";
            this.vr_licence_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vr_vehicle_rate_of_return_pct_t
            // 
            this.vr_vehicle_rate_of_return_pct_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.vr_vehicle_rate_of_return_pct_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vr_vehicle_rate_of_return_pct_t.ForeColor = System.Drawing.Color.Black;
            this.vr_vehicle_rate_of_return_pct_t.Location = new System.Drawing.Point(55, 97);
            this.vr_vehicle_rate_of_return_pct_t.Name = "vr_vehicle_rate_of_return_pct_t";
            this.vr_vehicle_rate_of_return_pct_t.Size = new System.Drawing.Size(169, 13);
            this.vr_vehicle_rate_of_return_pct_t.TabIndex = 106;
            this.vr_vehicle_rate_of_return_pct_t.Text = "Vehicle Rate Of Return (%)";
            this.vr_vehicle_rate_of_return_pct_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vr_salvage_ratio_t
            // 
            this.vr_salvage_ratio_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.vr_salvage_ratio_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vr_salvage_ratio_t.ForeColor = System.Drawing.Color.Black;
            this.vr_salvage_ratio_t.Location = new System.Drawing.Point(110, 118);
            this.vr_salvage_ratio_t.Name = "vr_salvage_ratio_t";
            this.vr_salvage_ratio_t.Size = new System.Drawing.Size(114, 13);
            this.vr_salvage_ratio_t.TabIndex = 107;
            this.vr_salvage_ratio_t.Text = "Salvage Ratio (%)";
            this.vr_salvage_ratio_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vr_ruc_t
            // 
            this.vr_ruc_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.vr_ruc_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vr_ruc_t.ForeColor = System.Drawing.Color.Black;
            this.vr_ruc_t.Location = new System.Drawing.Point(32, 139);
            this.vr_ruc_t.Name = "vr_ruc_t";
            this.vr_ruc_t.Size = new System.Drawing.Size(192, 13);
            this.vr_ruc_t.TabIndex = 108;
            this.vr_ruc_t.Text = "Road User Charges ($/1000K)";
            this.vr_ruc_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vr_sundries_k_t
            // 
            this.vr_sundries_k_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.vr_sundries_k_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vr_sundries_k_t.ForeColor = System.Drawing.Color.Black;
            this.vr_sundries_k_t.Location = new System.Drawing.Point(103, 160);
            this.vr_sundries_k_t.Name = "vr_sundries_k_t";
            this.vr_sundries_k_t.Size = new System.Drawing.Size(121, 13);
            this.vr_sundries_k_t.TabIndex = 109;
            this.vr_sundries_k_t.Text = "Sundries ($/1000k)";
            this.vr_sundries_k_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vr_vehicle_value_insurance_pct_t
            // 
            this.vr_vehicle_value_insurance_pct_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.vr_vehicle_value_insurance_pct_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vr_vehicle_value_insurance_pct_t.ForeColor = System.Drawing.Color.Black;
            this.vr_vehicle_value_insurance_pct_t.Location = new System.Drawing.Point(8, 181);
            this.vr_vehicle_value_insurance_pct_t.Name = "vr_vehicle_value_insurance_pct_t";
            this.vr_vehicle_value_insurance_pct_t.Size = new System.Drawing.Size(216, 13);
            this.vr_vehicle_value_insurance_pct_t.TabIndex = 110;
            this.vr_vehicle_value_insurance_pct_t.Text = "Vehicle Insurance (% of net vehicle value)";
            this.vr_vehicle_value_insurance_pct_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vr_vehicle_allowance_rate_t
            // 
            this.vr_vehicle_allowance_rate_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.vr_vehicle_allowance_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vr_vehicle_allowance_rate_t.ForeColor = System.Drawing.Color.Black;
            this.vr_vehicle_allowance_rate_t.Location = new System.Drawing.Point(45, 225);
            this.vr_vehicle_allowance_rate_t.Name = "vr_vehicle_allowance_rate_t";
            this.vr_vehicle_allowance_rate_t.Size = new System.Drawing.Size(179, 13);
            this.vr_vehicle_allowance_rate_t.TabIndex = 111;
            this.vr_vehicle_allowance_rate_t.Text = "Vehicle Allowance ($/1000k)";
            this.vr_vehicle_allowance_rate_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_1
            // 
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(45, 202);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(179, 13);
            this.t_1.TabIndex = 112;
            this.t_1.Text = "Vehicle Allowance ($ pa)";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DVehicleRates2001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.vr_nominal_vehicle_value);
            this.Controls.Add(this.vr_repairs_maintenance_rate);
            this.Controls.Add(this.vr_tyre_tubes_rate);
            this.Controls.Add(this.vr_licence_rate);
            this.Controls.Add(this.vr_vehicle_rate_of_return_pct);
            this.Controls.Add(this.vr_salvage_ratio);
            this.Controls.Add(this.vr_ruc);
            this.Controls.Add(this.vr_sundries_k);
            this.Controls.Add(this.vr_vehicle_value_insurance_pct);
            this.Controls.Add(this.vr_livery);
            this.Controls.Add(this.vr_vehicle_allowance_rate);
            this.Controls.Add(this.vr_nominal_vehicle_value_t);
            this.Controls.Add(this.vr_repairs_maintenance_rate_t);
            this.Controls.Add(this.vr_tyre_tubes_rate_t);
            this.Controls.Add(this.vr_licence_rate_t);
            this.Controls.Add(this.vr_vehicle_rate_of_return_pct_t);
            this.Controls.Add(this.vr_salvage_ratio_t);
            this.Controls.Add(this.vr_ruc_t);
            this.Controls.Add(this.vr_sundries_k_t);
            this.Controls.Add(this.vr_vehicle_value_insurance_pct_t);
            this.Controls.Add(this.vr_vehicle_allowance_rate_t);
            this.Controls.Add(this.t_1);
            this.Name = "DVehicleRates2001";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	}
}
