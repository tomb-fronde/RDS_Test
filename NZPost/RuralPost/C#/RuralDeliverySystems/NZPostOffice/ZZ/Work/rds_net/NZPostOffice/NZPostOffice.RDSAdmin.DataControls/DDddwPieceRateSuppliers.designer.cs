using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DDddwPieceRateSuppliers
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

		private System.Windows.Forms.TextBox   prs_description;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DDddwPieceRateSuppliers";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.PieceRateSuppliers);
			//
			// prs_description
			//
			prs_description = new System.Windows.Forms.TextBox();
			this.prs_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.prs_description.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.prs_description.ForeColor = System.Drawing.Color.Black;
			this.prs_description.Location = new System.Drawing.Point(5, 1);
			this.prs_description.MaxLength = 40;
			this.prs_description.Name = "prs_description";
			this.prs_description.Size = new System.Drawing.Size(261, 14);
			this.prs_description.TextAlign = HorizontalAlignment.Left;
			this.prs_description.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.prs_description.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "PrsDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.prs_description.ReadOnly=true;
			this.Controls.Add(prs_description);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
		}
		#endregion

	}
}
