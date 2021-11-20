using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DDddwUsername
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

		private System.Windows.Forms.TextBox   u_name;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DDddwUsername";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.Username);
			//
			// u_name
			//
			u_name = new System.Windows.Forms.TextBox();
			this.u_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.u_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.u_name.ForeColor = System.Drawing.SystemColors.WindowText;
			this.u_name.Location = new System.Drawing.Point(3, 2);
			this.u_name.MaxLength = 50;
			this.u_name.Name = "u_name";
			this.u_name.Size = new System.Drawing.Size(142, 16);
			this.u_name.TextAlign = HorizontalAlignment.Left;
			this.u_name.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.u_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "UName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.u_name.ReadOnly=true;
			this.Controls.Add(u_name);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
		}
		#endregion

	}
}
