using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DwSearchComponent
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

		private System.Windows.Forms.TextBox   search;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DwSearchComponent";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.SearchComponent);
			//
			// search
			//
			search = new System.Windows.Forms.TextBox();
			this.search.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.search.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.search.ForeColor = System.Drawing.Color.Black;
			this.search.Location = new System.Drawing.Point(3, 2);
			this.search.MaxLength = 0;
			this.search.Name = "search";
			this.search.Size = new System.Drawing.Size(194, 15);
			this.search.TextAlign = HorizontalAlignment.Left;
			this.search.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
			this.search.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "Search", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.search.TabIndex = 10;
			this.Controls.Add(search);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
		}
		#endregion

	}
}
