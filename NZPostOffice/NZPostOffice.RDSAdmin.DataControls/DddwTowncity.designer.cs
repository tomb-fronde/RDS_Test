using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DddwTowncity
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

		private System.Windows.Forms.TextBox   tc_name;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DddwTowncity";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.Towncity);
			//
			// tc_name
			//
			tc_name = new System.Windows.Forms.TextBox();
			this.tc_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tc_name.Font = new System.Drawing.Font("Arial", 8F);
			this.tc_name.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tc_name.Location = new System.Drawing.Point(1, 0);
			this.tc_name.MaxLength = 50;
			this.tc_name.Name = "tc_name";
			this.tc_name.Size = new System.Drawing.Size(306, 13);
			this.tc_name.TextAlign = HorizontalAlignment.Left;
			this.tc_name.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.tc_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "TcName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.tc_name.TabIndex = 10;
			this.Controls.Add(tc_name);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
		}
		#endregion

	}
}
