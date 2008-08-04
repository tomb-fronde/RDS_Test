using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DDddwRoadType
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		//?private System.Windows.Forms.DataGridViewTextBoxColumn  rt_id;
		//?private System.Windows.Forms.DataGridViewTextBoxColumn  rt_name;
        private TextBox rt_name;

	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code
		private void InitializeComponent()
		{
            components = new System.ComponentModel.Container();
            this.Name = "DDddwRoadType";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwRoadType);
            //
            // rt_name
            //
            rt_name = new System.Windows.Forms.TextBox();
            this.rt_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rt_name.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rt_name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rt_name.Location = new System.Drawing.Point(0, 1);
            this.rt_name.MaxLength = 40;
            this.rt_name.Name = "rt_name";
            this.rt_name.Size = new System.Drawing.Size(246, 13);
            this.rt_name.TextAlign = HorizontalAlignment.Left;
            //this.rt_name.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.rt_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "RtName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rt_name.TabIndex = 20;
            this.Controls.Add(rt_name);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
		}
		#endregion

	}
}
