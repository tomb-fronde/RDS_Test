using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DwTownDddw
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
		private Metex.Windows.DataEntityCombo   tc_id;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DwTownDddw";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.TownDddw);
			//
			// tc_name
			//
			tc_name = new System.Windows.Forms.TextBox();
			this.tc_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tc_name.Font = new System.Drawing.Font("Arial", 8F);
			this.tc_name.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tc_name.Location = new System.Drawing.Point(292, 3);
			this.tc_name.MaxLength = 50;
			this.tc_name.Name = "tc_name";
			this.tc_name.Size = new System.Drawing.Size(109, 16);
			this.tc_name.TextAlign = HorizontalAlignment.Left;
			this.tc_name.BackColor = System.Drawing.SystemColors.ButtonFace;
            //this.tc_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
            //    this.bindingSource, "TcName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.tc_name.ReadOnly=true;
			this.Controls.Add(tc_name);

			//
			// tc_id
			//
			tc_id = new Metex.Windows.DataEntityCombo();
            //this.tc_id.AutoRetrieve = true;
			this.tc_id.BackColor = System.Drawing.SystemColors.Window;
			this.tc_id.DisplayMember = "TcName";
			this.tc_id.Font = new System.Drawing.Font("Arial", 8F);
			this.tc_id.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tc_id.Location = new System.Drawing.Point(3, 3);
			this.tc_id.Name = "tc_id";
			this.tc_id.Size = new System.Drawing.Size(209, 18);
			this.tc_id.TabIndex = 10;
			this.tc_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tc_id.Value = null;
			this.tc_id.ValueMember = "TcId";
			this.tc_id.DropDownWidth = 209;
            //this.tc_id.DataBindings.Add(
            //    new System.Windows.Forms.Binding("Value", this.bindingSource, "TcId", true,
            //    System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Controls.Add(tc_id);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
		}
		#endregion

	}
}
