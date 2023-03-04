using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.Entity;

namespace NZPostOffice.DataControls
{
	partial class DDddwFilteredContractTypes
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

		private System.Windows.Forms.TextBox   contract_type;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DDddwFilteredContractTypes";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.Entity.FilteredContractTypes);
			//
			// contract_type
			//
			contract_type = new System.Windows.Forms.TextBox();
			this.contract_type.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.contract_type.Font = new System.Drawing.Font("Arial", 8F);
			this.contract_type.ForeColor = System.Drawing.Color.Black;
			this.contract_type.Location = new System.Drawing.Point(1, 1);
			this.contract_type.MaxLength = 40;
			this.contract_type.Name = "contract_type";
			this.contract_type.Size = new System.Drawing.Size(246, 14);
			this.contract_type.TextAlign = HorizontalAlignment.Left;
			this.contract_type.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contract_type.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "ContractType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.contract_type.ReadOnly=true;
			this.Controls.Add(contract_type);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
		}
		#endregion

	}
}
