using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	partial class DCustListFreq
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

		private Metex.Windows.DataEntityCombo   freq_list;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DCustListFreq";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.CustListFreq);
			//
			// freq_list
			//
			freq_list = new Metex.Windows.DataEntityCombo();
			this.freq_list.AutoRetrieve = true;
			this.freq_list.BackColor = System.Drawing.Color.White;
			this.freq_list.DisplayMember = "SfDesc";
			this.freq_list.Font = new System.Drawing.Font("Arial", 8F);
			this.freq_list.ForeColor = System.Drawing.Color.Black;
			this.freq_list.Location = new System.Drawing.Point(3, 1);
			this.freq_list.Name = "freq_list";
			this.freq_list.Size = new System.Drawing.Size(153, 17);
			this.freq_list.TabIndex = 10;
			this.freq_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.freq_list.Value = null;
			this.freq_list.ValueMember = "SfDesc";
			this.freq_list.DropDownWidth = 153;
			this.freq_list.DataBindings.Add(
				new System.Windows.Forms.Binding("Value", this.bindingSource, "FreqList", true,
				System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Controls.Add(freq_list);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
		}
		#endregion

	}
}
