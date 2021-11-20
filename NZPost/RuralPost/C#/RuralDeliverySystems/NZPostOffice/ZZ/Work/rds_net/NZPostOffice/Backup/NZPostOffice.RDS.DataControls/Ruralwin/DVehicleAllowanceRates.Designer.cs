using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB  RPCR_060  Jan-2014: NEW
    // Datacontrol for Driver 'personal' info

    partial class DVehicleAllowanceRates
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

        private System.Windows.Forms.Label var_id_t;
        private System.Windows.Forms.Label var_description_t;
        private System.Windows.Forms.Label var_carrier_pa_t;
        private System.Windows.Forms.Label var_repairs_pk_t;
        private System.Windows.Forms.Label var_licence_pa_t;

        private System.Windows.Forms.TextBox var_id;
        private System.Windows.Forms.TextBox var_description;
        private System.Windows.Forms.TextBox var_carrier_pa;
        private System.Windows.Forms.TextBox var_repairs_pk;
        private System.Windows.Forms.TextBox var_licence_pa;
        private System.Windows.Forms.TextBox var_tyres_pk;
        private System.Windows.Forms.TextBox var_allowance_pk;
        private System.Windows.Forms.TextBox var_insurance_pa;
        private System.Windows.Forms.TextBox var_ror_pa;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
		{
            this.var_id_t = new System.Windows.Forms.Label();
            this.var_description_t = new System.Windows.Forms.Label();
            this.var_carrier_pa_t = new System.Windows.Forms.Label();
            this.var_repairs_pk_t = new System.Windows.Forms.Label();
            this.var_licence_pa_t = new System.Windows.Forms.Label();
            this.var_id = new System.Windows.Forms.TextBox();
            this.var_description = new System.Windows.Forms.TextBox();
            this.var_carrier_pa = new System.Windows.Forms.TextBox();
            this.var_repairs_pk = new System.Windows.Forms.TextBox();
            this.var_licence_pa = new System.Windows.Forms.TextBox();
            this.var_tyres_pk = new System.Windows.Forms.TextBox();
            this.var_allowance_pk = new System.Windows.Forms.TextBox();
            this.var_insurance_pa = new System.Windows.Forms.TextBox();
            this.var_ror_pa = new System.Windows.Forms.TextBox();
            this.tyres_t = new System.Windows.Forms.Label();
            this.allowance_pk_t = new System.Windows.Forms.Label();
            this.insurance_pa_t = new System.Windows.Forms.Label();
            this.ror_pa_t = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.VehicleAllowanceRates);
            // 
            // var_id_t
            // 
            this.var_id_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.var_id_t.Font = new System.Drawing.Font("Arial", 8F);
            this.var_id_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.var_id_t.Location = new System.Drawing.Point(19, 2);
            this.var_id_t.Name = "var_id_t";
            this.var_id_t.Size = new System.Drawing.Size(59, 14);
            this.var_id_t.TabIndex = 0;
            this.var_id_t.Text = "Vehicle Id";
            this.var_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // var_description_t
            // 
            this.var_description_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.var_description_t.Font = new System.Drawing.Font("Arial", 8F);
            this.var_description_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.var_description_t.Location = new System.Drawing.Point(84, 2);
            this.var_description_t.Name = "var_description_t";
            this.var_description_t.Size = new System.Drawing.Size(95, 14);
            this.var_description_t.TabIndex = 0;
            this.var_description_t.Text = "Description";
            this.var_description_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // var_carrier_pa_t
            // 
            this.var_carrier_pa_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.var_carrier_pa_t.Font = new System.Drawing.Font("Arial", 8F);
            this.var_carrier_pa_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.var_carrier_pa_t.Location = new System.Drawing.Point(317, 2);
            this.var_carrier_pa_t.Name = "var_carrier_pa_t";
            this.var_carrier_pa_t.Size = new System.Drawing.Size(82, 14);
            this.var_carrier_pa_t.TabIndex = 0;
            this.var_carrier_pa_t.Text = "CarrierPa";
            this.var_carrier_pa_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // var_repairs_pk_t
            // 
            this.var_repairs_pk_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.var_repairs_pk_t.Font = new System.Drawing.Font("Arial", 8F);
            this.var_repairs_pk_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.var_repairs_pk_t.Location = new System.Drawing.Point(405, 2);
            this.var_repairs_pk_t.Name = "var_repairs_pk_t";
            this.var_repairs_pk_t.Size = new System.Drawing.Size(59, 14);
            this.var_repairs_pk_t.TabIndex = 0;
            this.var_repairs_pk_t.Text = "RepairsPk";
            this.var_repairs_pk_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // var_licence_pa_t
            // 
            this.var_licence_pa_t.AutoSize = true;
            this.var_licence_pa_t.Location = new System.Drawing.Point(509, 3);
            this.var_licence_pa_t.Name = "var_licence_pa_t";
            this.var_licence_pa_t.Size = new System.Drawing.Size(58, 13);
            this.var_licence_pa_t.TabIndex = 0;
            this.var_licence_pa_t.Text = "LicencePa";
            // 
            // var_id
            // 
            this.var_id.BackColor = System.Drawing.SystemColors.Window;
            this.var_id.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VarId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.var_id.Font = new System.Drawing.Font("Arial", 8F);
            this.var_id.ForeColor = System.Drawing.SystemColors.WindowText;
            this.var_id.Location = new System.Drawing.Point(19, 19);
            this.var_id.MaxLength = 0;
            this.var_id.Name = "var_id";
            this.var_id.Size = new System.Drawing.Size(59, 20);
            this.var_id.TabIndex = 5;
            // 
            // var_description
            // 
            this.var_description.BackColor = System.Drawing.SystemColors.Window;
            this.var_description.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VarDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.var_description.Font = new System.Drawing.Font("Arial", 8F);
            this.var_description.ForeColor = System.Drawing.SystemColors.WindowText;
            this.var_description.Location = new System.Drawing.Point(84, 19);
            this.var_description.MaxLength = 30;
            this.var_description.Name = "var_description";
            this.var_description.Size = new System.Drawing.Size(230, 20);
            this.var_description.TabIndex = 10;
            // 
            // var_carrier_pa
            // 
            this.var_carrier_pa.BackColor = System.Drawing.SystemColors.Window;
            this.var_carrier_pa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VarCarrierPa", true));
            this.var_carrier_pa.Font = new System.Drawing.Font("Arial", 8F);
            this.var_carrier_pa.ForeColor = System.Drawing.SystemColors.WindowText;
            this.var_carrier_pa.Location = new System.Drawing.Point(320, 19);
            this.var_carrier_pa.MaxLength = 45;
            this.var_carrier_pa.Name = "var_carrier_pa";
            this.var_carrier_pa.Size = new System.Drawing.Size(82, 20);
            this.var_carrier_pa.TabIndex = 15;
            // 
            // var_repairs_pk
            // 
            this.var_repairs_pk.BackColor = System.Drawing.SystemColors.Window;
            this.var_repairs_pk.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VarRepairsPa", true));
            this.var_repairs_pk.Font = new System.Drawing.Font("Arial", 8F);
            this.var_repairs_pk.ForeColor = System.Drawing.SystemColors.WindowText;
            this.var_repairs_pk.Location = new System.Drawing.Point(408, 19);
            this.var_repairs_pk.MaxLength = 0;
            this.var_repairs_pk.Name = "var_repairs_pk";
            this.var_repairs_pk.Size = new System.Drawing.Size(95, 20);
            this.var_repairs_pk.TabIndex = 20;
            // 
            // var_licence_pa
            // 
            this.var_licence_pa.BackColor = System.Drawing.SystemColors.Window;
            this.var_licence_pa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VarLicencePa", true));
            this.var_licence_pa.Font = new System.Drawing.Font("Arial", 8F);
            this.var_licence_pa.ForeColor = System.Drawing.SystemColors.WindowText;
            this.var_licence_pa.Location = new System.Drawing.Point(509, 19);
            this.var_licence_pa.MaxLength = 0;
            this.var_licence_pa.Name = "var_licence_pa";
            this.var_licence_pa.Size = new System.Drawing.Size(99, 20);
            this.var_licence_pa.TabIndex = 25;
            // 
            // var_tyres_pk
            // 
            this.var_tyres_pk.BackColor = System.Drawing.SystemColors.Window;
            this.var_tyres_pk.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VarTyresPk", true));
            this.var_tyres_pk.Font = new System.Drawing.Font("Arial", 8F);
            this.var_tyres_pk.ForeColor = System.Drawing.SystemColors.WindowText;
            this.var_tyres_pk.Location = new System.Drawing.Point(20, 59);
            this.var_tyres_pk.MaxLength = 0;
            this.var_tyres_pk.Name = "var_tyres_pk";
            this.var_tyres_pk.Size = new System.Drawing.Size(94, 20);
            this.var_tyres_pk.TabIndex = 30;
            // 
            // var_allowance_pk
            // 
            this.var_allowance_pk.BackColor = System.Drawing.SystemColors.Window;
            this.var_allowance_pk.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VarAllowancePk", true));
            this.var_allowance_pk.Font = new System.Drawing.Font("Arial", 8F);
            this.var_allowance_pk.ForeColor = System.Drawing.SystemColors.WindowText;
            this.var_allowance_pk.Location = new System.Drawing.Point(129, 59);
            this.var_allowance_pk.MaxLength = 0;
            this.var_allowance_pk.Name = "var_allowance_pk";
            this.var_allowance_pk.Size = new System.Drawing.Size(94, 20);
            this.var_allowance_pk.TabIndex = 35;
            // 
            // var_insurance_pa
            // 
            this.var_insurance_pa.BackColor = System.Drawing.SystemColors.Window;
            this.var_insurance_pa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VarInsurancePa", true));
            this.var_insurance_pa.Font = new System.Drawing.Font("Arial", 8F);
            this.var_insurance_pa.ForeColor = System.Drawing.SystemColors.WindowText;
            this.var_insurance_pa.Location = new System.Drawing.Point(237, 59);
            this.var_insurance_pa.MaxLength = 0;
            this.var_insurance_pa.Name = "var_insurance_pa";
            this.var_insurance_pa.Size = new System.Drawing.Size(94, 20);
            this.var_insurance_pa.TabIndex = 40;
            // 
            // var_ror_pa
            // 
            this.var_ror_pa.BackColor = System.Drawing.SystemColors.Window;
            this.var_ror_pa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "VarRorPa", true));
            this.var_ror_pa.Font = new System.Drawing.Font("Arial", 8F);
            this.var_ror_pa.ForeColor = System.Drawing.SystemColors.WindowText;
            this.var_ror_pa.Location = new System.Drawing.Point(346, 59);
            this.var_ror_pa.MaxLength = 0;
            this.var_ror_pa.Name = "var_ror_pa";
            this.var_ror_pa.Size = new System.Drawing.Size(94, 20);
            this.var_ror_pa.TabIndex = 45;
            // 
            // tyres_t
            // 
            this.tyres_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tyres_t.Font = new System.Drawing.Font("Arial", 8F);
            this.tyres_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tyres_t.Location = new System.Drawing.Point(23, 44);
            this.tyres_t.Name = "tyres_t";
            this.tyres_t.Size = new System.Drawing.Size(59, 14);
            this.tyres_t.TabIndex = 46;
            this.tyres_t.Text = "TyresPk";
            this.tyres_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // allowance_pk_t
            // 
            this.allowance_pk_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.allowance_pk_t.Font = new System.Drawing.Font("Arial", 8F);
            this.allowance_pk_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.allowance_pk_t.Location = new System.Drawing.Point(135, 43);
            this.allowance_pk_t.Name = "allowance_pk_t";
            this.allowance_pk_t.Size = new System.Drawing.Size(73, 14);
            this.allowance_pk_t.TabIndex = 47;
            this.allowance_pk_t.Text = "AllowancePk";
            this.allowance_pk_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // insurance_pa_t
            // 
            this.insurance_pa_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.insurance_pa_t.Font = new System.Drawing.Font("Arial", 8F);
            this.insurance_pa_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.insurance_pa_t.Location = new System.Drawing.Point(239, 43);
            this.insurance_pa_t.Name = "insurance_pa_t";
            this.insurance_pa_t.Size = new System.Drawing.Size(75, 14);
            this.insurance_pa_t.TabIndex = 48;
            this.insurance_pa_t.Text = "InsurancePa";
            this.insurance_pa_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ror_pa_t
            // 
            this.ror_pa_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ror_pa_t.Font = new System.Drawing.Font("Arial", 8F);
            this.ror_pa_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ror_pa_t.Location = new System.Drawing.Point(350, 43);
            this.ror_pa_t.Name = "ror_pa_t";
            this.ror_pa_t.Size = new System.Drawing.Size(59, 14);
            this.ror_pa_t.TabIndex = 49;
            this.ror_pa_t.Text = "ROR Pa";
            this.ror_pa_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DVehicleAllowanceRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.ror_pa_t);
            this.Controls.Add(this.insurance_pa_t);
            this.Controls.Add(this.allowance_pk_t);
            this.Controls.Add(this.tyres_t);
            this.Controls.Add(this.var_id_t);
            this.Controls.Add(this.var_description_t);
            this.Controls.Add(this.var_carrier_pa_t);
            this.Controls.Add(this.var_repairs_pk_t);
            this.Controls.Add(this.var_licence_pa_t);
            this.Controls.Add(this.var_id);
            this.Controls.Add(this.var_description);
            this.Controls.Add(this.var_carrier_pa);
            this.Controls.Add(this.var_repairs_pk);
            this.Controls.Add(this.var_licence_pa);
            this.Controls.Add(this.var_tyres_pk);
            this.Controls.Add(this.var_allowance_pk);
            this.Controls.Add(this.var_insurance_pa);
            this.Controls.Add(this.var_ror_pa);
            this.Name = "DVehicleAllowanceRates";
            this.Size = new System.Drawing.Size(650, 85);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion

        private Label tyres_t;
        private Label allowance_pk_t;
        private Label insurance_pa_t;
        private Label ror_pa_t;

    }
}
