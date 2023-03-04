using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DSetArticalCountsScalingFactor
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

		private System.Windows.Forms.MaskedTextBox   scaling_factor;
		private System.Windows.Forms.Label   scaling_factor_t;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DSetArticalCountsScalingFactor";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.SetArticalCountsScalingFactor);

			//
			// scaling_factor
			//
			scaling_factor = new System.Windows.Forms.MaskedTextBox();
			this.scaling_factor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.scaling_factor.Location = new System.Drawing.Point(80, 2);
			this.scaling_factor.Name = "scaling_factor";
			this.scaling_factor.Size = new System.Drawing.Size(57, 13);
            this.scaling_factor.TextAlign = HorizontalAlignment.Right;
			this.scaling_factor.DataBindings.Add(new System.Windows.Forms.Binding( "Text", 
				this.bindingSource, "ScalingFactor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.scaling_factor.TabIndex = 10;
            this.scaling_factor.Mask = "##.000000";
            this.scaling_factor.DataBindings[0].FormatString = "##.000000";
            this.scaling_factor.InsertKeyMode = InsertKeyMode.Overwrite;
            this.scaling_factor.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            this.scaling_factor.PromptChar = ' ';
            this.scaling_factor.DataBindings[0].DataSourceNullValue = null;
			this.Controls.Add( scaling_factor );
			//
			// scaling_factor_t
			//
			this.scaling_factor_t = new System.Windows.Forms.Label();
			this.scaling_factor_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.scaling_factor_t.ForeColor = System.Drawing.Color.Black;
			this.scaling_factor_t.Location = new System.Drawing.Point(1, 2);
			this.scaling_factor_t.Name = "scaling_factor_t";
			this.scaling_factor_t.Size = new System.Drawing.Size(75, 13);
			this.scaling_factor_t.Text = "Scaling Factor";
			this.scaling_factor_t.TextAlign = ContentAlignment.MiddleRight;
			this.scaling_factor_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(scaling_factor_t);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;//.ColorTranslator.FromWin32(80269524);
		}
		#endregion

	}
}
