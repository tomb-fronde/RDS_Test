using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DDddwContractorVehicles
	{

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox vehicle_name;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DDddwContractorVehicles";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwContractorVehicles);
            //
            // vehicle_name
            //
            vehicle_name = new System.Windows.Forms.TextBox();
            this.vehicle_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vehicle_name.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.vehicle_name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.vehicle_name.Location = new System.Drawing.Point(0, 1);
            this.vehicle_name.MaxLength = 40;
            this.vehicle_name.Name = "vehicle_name";
            this.vehicle_name.Size = new System.Drawing.Size(246, 13);
            this.vehicle_name.TextAlign = HorizontalAlignment.Left;
            this.vehicle_name.BackColor = System.Drawing.SystemColors.Control;
            this.vehicle_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "VehicleName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vehicle_name.TabIndex = 20;
            this.Controls.Add(vehicle_name);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
        }
        #endregion


	}
}
