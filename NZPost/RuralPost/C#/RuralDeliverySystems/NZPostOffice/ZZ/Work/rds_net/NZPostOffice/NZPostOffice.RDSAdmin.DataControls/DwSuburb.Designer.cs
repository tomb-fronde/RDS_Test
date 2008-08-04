using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DwSuburb
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

		private System.Windows.Forms.TextBox   suburb_name;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DwSuburb";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.Suburb);
			//
			// suburb_name
			//
			suburb_name = new System.Windows.Forms.TextBox();
			this.suburb_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.suburb_name.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.suburb_name.ForeColor = System.Drawing.SystemColors.WindowText;
			this.suburb_name.Location = new System.Drawing.Point(7, 4);
			this.suburb_name.MaxLength = 0;
			this.suburb_name.Name = "suburb_name";
			this.suburb_name.Size = new System.Drawing.Size(184, 14);
			this.suburb_name.TextAlign = HorizontalAlignment.Left;
			this.suburb_name.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.suburb_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "SuburbName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.suburb_name.ReadOnly=true;
			this.Controls.Add(suburb_name);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
		}
		#endregion

	}
}
