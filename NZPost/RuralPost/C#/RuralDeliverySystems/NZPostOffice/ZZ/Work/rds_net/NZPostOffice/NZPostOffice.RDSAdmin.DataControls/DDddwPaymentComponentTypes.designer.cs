using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DDddwPaymentComponentTypes
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

		private System.Windows.Forms.TextBox   pct_description;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DDddwPaymentComponentTypes";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.PaymentComponentTypes);
			//
			// pct_description
			//
			this.pct_description = new System.Windows.Forms.TextBox();
			this.pct_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.pct_description.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.pct_description.ForeColor = System.Drawing.Color.Black;
			this.pct_description.Location = new System.Drawing.Point(5, 1);
			this.pct_description.MaxLength = 40;
			this.pct_description.Name = "pct_description";
			this.pct_description.Size = new System.Drawing.Size(261, 14);
			this.pct_description.TextAlign = HorizontalAlignment.Left;
			this.pct_description.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.pct_description.DataBindings.Add(new System.Windows.Forms.Binding("Text",
			this.bindingSource, "PctDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.pct_description.ReadOnly=true;
			this.Controls.Add(pct_description);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
		}
		#endregion

	}
}
