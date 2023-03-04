using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
	partial class DContractTown
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

		private Metex.Windows.DataEntityCombo   tc_name;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DContractTown";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.ContractTown);
			//
			// tc_name
			//
			tc_name = new Metex.Windows.DataEntityCombo();
			this.tc_name.AutoRetrieve = true;
			this.tc_name.BackColor = System.Drawing.SystemColors.Window;
			this.tc_name.DisplayMember = "TcName";
			this.tc_name.Font = new System.Drawing.Font("Arial", 8F);
			this.tc_name.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tc_name.Location = new System.Drawing.Point(1, 3);
			this.tc_name.Name = "tc_name";
			this.tc_name.Size = new System.Drawing.Size(211, 14);
			this.tc_name.TabIndex = 10;
			this.tc_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tc_name.Value = null;
			this.tc_name.ValueMember = "TcId";
			this.tc_name.DropDownWidth = 211;
			this.tc_name.DataBindings.Add(
				new System.Windows.Forms.Binding("Value", this.bindingSource, "TcName", true,
				System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Controls.Add(tc_name);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
		}
		#endregion

	}
}
