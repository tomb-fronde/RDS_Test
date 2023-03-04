using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DDddwAllowanceCalcType
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

		private System.Windows.Forms.TextBox alct_description;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DDddwAllowanceCalcType";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.DddwAllowanceCalcType);
			//
			// alct_description
			//
			alct_description = new System.Windows.Forms.TextBox();
			this.alct_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.alct_description.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.alct_description.ForeColor = System.Drawing.SystemColors.WindowText;
			this.alct_description.Location = new System.Drawing.Point(0, 1);
			this.alct_description.MaxLength = 40;
			this.alct_description.Name = "alct_description";
			this.alct_description.Size = new System.Drawing.Size(246, 13);
			this.alct_description.TextAlign = HorizontalAlignment.Left;
			this.alct_description.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.alct_description.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "AlctDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.alct_description.TabIndex = 20;
			this.Controls.Add(alct_description);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
		}
		#endregion

	}
}
