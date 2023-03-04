using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	partial class DCustListTown
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

		private Metex.Windows.DataEntityCombo   town_list;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DCustListTown";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.CustListTown);
			//
			// town_list
			//
			town_list = new Metex.Windows.DataEntityCombo();
			this.town_list.AutoRetrieve = true;
			this.town_list.BackColor = System.Drawing.Color.White;
			this.town_list.DisplayMember = "TcName";
			this.town_list.Font = new System.Drawing.Font("Arial", 8F);
			this.town_list.ForeColor = System.Drawing.Color.Black;
			this.town_list.Location = new System.Drawing.Point(3, 1);
			this.town_list.Name = "town_list";
			this.town_list.Size = new System.Drawing.Size(153, 17);
			this.town_list.TabIndex = 10;
			this.town_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.town_list.Value = null;
			this.town_list.ValueMember = "TcName";
            //this.town_list.DataBindings[0].DataSourceNullValue = null;
			this.town_list.DropDownWidth = 153;
			this.town_list.DataBindings.Add(
                new System.Windows.Forms.Binding("Value", this.bindingSource, "Town", true,
				System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Controls.Add(town_list);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
		}
		#endregion

	}
}
