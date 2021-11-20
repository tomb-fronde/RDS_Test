using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DCustomerTransfer
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

		private System.Windows.Forms.MaskedTextBox   contract_no;
        private System.Windows.Forms.Label t_1;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DCustomerTransfer";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.CustomerTransfer);

            //
            // t_1
            //
            this.t_1 = new System.Windows.Forms.Label();
            this.t_1.Font = new System.Drawing.Font("Arial", 8F);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(1, 3);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(120, 14);
            this.t_1.Text = "Transfer To Contract ";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_1);

			//
			// contract_no
			//
			contract_no = new System.Windows.Forms.MaskedTextBox();
			this.contract_no.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.contract_no.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			//?this.contract_no.ForeColor = System.Drawing.ColorTranslator.FromWin32(Arial);
			this.contract_no.Location = new System.Drawing.Point(123, 3);
			this.contract_no.Name = "contract_no";
			this.contract_no.Size = new System.Drawing.Size(40, 13);
            this.contract_no.TextAlign = HorizontalAlignment.Left;// ContentAlignment.MiddleRight;
			//this.contract_no.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.contract_no.Mask = "";
			this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding( "Text", 
				this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.contract_no.TabIndex = 20;
			this.Controls.Add( contract_no );
			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
		}
		#endregion

	}
}
