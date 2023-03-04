using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DDddwOutletType
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

		private System.Windows.Forms.TextBox   ot_outlet_type;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DDddwOutletType";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.DddwOutletType);
			//
			// ot_outlet_type
			//
			ot_outlet_type = new System.Windows.Forms.TextBox();
			this.ot_outlet_type.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ot_outlet_type.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.ot_outlet_type.ForeColor = System.Drawing.Color.Black;
			this.ot_outlet_type.Location = new System.Drawing.Point(8, 1);
			this.ot_outlet_type.MaxLength = 30;
			this.ot_outlet_type.Name = "ot_outlet_type";
			this.ot_outlet_type.Size = new System.Drawing.Size(215, 13);
			this.ot_outlet_type.TextAlign = HorizontalAlignment.Left;
			this.ot_outlet_type.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.ot_outlet_type.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "OtOutletType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.ot_outlet_type.ReadOnly=true;
			this.Controls.Add(ot_outlet_type);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.ColorTranslator.FromWin32(1086902488);
		}
		#endregion

	}
}
