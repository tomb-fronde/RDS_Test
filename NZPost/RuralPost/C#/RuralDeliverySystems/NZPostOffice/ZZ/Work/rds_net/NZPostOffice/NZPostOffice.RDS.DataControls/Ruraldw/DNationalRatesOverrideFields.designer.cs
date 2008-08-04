using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DNationalRatesOverrideFields
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

		private System.Windows.Forms.Label   ruc_rate_t;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ruc_rate;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DNationalRatesOverrideFields";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.NationalRatesOverrideFields);
			//
			// ruc_rate_t
			//
			this.ruc_rate_t = new System.Windows.Forms.Label();
			this.ruc_rate_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.ruc_rate_t.ForeColor = System.Drawing.SystemColors.WindowText;
			this.ruc_rate_t.Location = new System.Drawing.Point(0, 4);
			this.ruc_rate_t.Name = "ruc_rate_t";
			this.ruc_rate_t.Size = new System.Drawing.Size(160, 13);
			this.ruc_rate_t.Text = "Road User Charges ($/1000K)";
			this.ruc_rate_t.TextAlign = ContentAlignment.MiddleRight;
			this.Controls.Add(ruc_rate_t);


			//
			// ruc_rate
			//
			ruc_rate = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
			this.ruc_rate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            //?this.ruc_rate.Font = new System.Drawing.Font("", F);
            //?this.ruc_rate.ForeColor = System.Drawing.ColorTranslator.FromWin32(MS Sans Serif);
			this.ruc_rate.Location = new System.Drawing.Point(162, 2);
			this.ruc_rate.Name = "ruc_rate";
			this.ruc_rate.Size = new System.Drawing.Size(47, 13);
            this.ruc_rate.TextAlign = HorizontalAlignment.Right;// ContentAlignment.MiddleRight;
			//this.ruc_rate.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.ruc_rate.EditMask = "#0.00";
			this.ruc_rate.DataBindings.Add(new System.Windows.Forms.Binding( "Value", 
				this.bindingSource, "RucRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ruc_rate.DataBindings[0].FormatString = "#0.00";
            this.ruc_rate.PromptChar = ' ';
            this.ruc_rate.InsertKeyMode = InsertKeyMode.Overwrite;
			this.ruc_rate.TabIndex = 10;
			this.Controls.Add( ruc_rate );
			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		}
		#endregion

	}
}
