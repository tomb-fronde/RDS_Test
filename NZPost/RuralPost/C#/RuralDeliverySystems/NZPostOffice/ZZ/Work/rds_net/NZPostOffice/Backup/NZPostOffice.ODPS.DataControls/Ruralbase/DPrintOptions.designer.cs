using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.Ruralbase;

namespace NZPostOffice.ODPS.DataControls.Ruralbase
{
	partial class DPrintOptions
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

        private System.Windows.Forms.Label copys_t;
        private System.Windows.Forms.MaskedTextBox copys;

        private System.Windows.Forms.GroupBox pagerange_t;
        private System.Windows.Forms.RadioButton pagerange_3;
        private System.Windows.Forms.RadioButton pagerange_2;
        private System.Windows.Forms.RadioButton pagerange_1;

        private System.Windows.Forms.MaskedTextBox pagefrom;
        private System.Windows.Forms.Label pageto_t;
        private System.Windows.Forms.MaskedTextBox pageto;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
            this.copys_t = new System.Windows.Forms.Label();
            this.copys = new System.Windows.Forms.MaskedTextBox();
            this.pagerange_t = new System.Windows.Forms.GroupBox();
            this.pageto = new System.Windows.Forms.MaskedTextBox();
            this.pageto_t = new System.Windows.Forms.Label();
            this.pagerange_3 = new System.Windows.Forms.RadioButton();
            this.pagefrom = new System.Windows.Forms.MaskedTextBox();
            this.pagerange_2 = new System.Windows.Forms.RadioButton();
            this.pagerange_1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.pagerange_t.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Ruralbase.PrintOptions);
            // 
            // copys_t
            // 
            this.copys_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.copys_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.copys_t.ForeColor = System.Drawing.Color.Black;
            this.copys_t.Location = new System.Drawing.Point(0, 3);
            this.copys_t.Name = "copys_t";
            this.copys_t.Size = new System.Drawing.Size(49, 13);
            this.copys_t.TabIndex = 41;
            this.copys_t.Text = "Copies:";
            this.copys_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // copys
            // 
            this.copys.BackColor = System.Drawing.Color.White;
            this.copys.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Copys", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.copys.Location = new System.Drawing.Point(56, 4);
            this.copys.Name = "copys";
            this.copys.Size = new System.Drawing.Size(46, 20);
            this.copys.TabIndex = 10;
            // 
            // pagerange_t
            // 
            this.pagerange_t.Controls.Add(this.pageto);
            this.pagerange_t.Controls.Add(this.pageto_t);
            this.pagerange_t.Controls.Add(this.pagerange_3);
            this.pagerange_t.Controls.Add(this.pagefrom);
            this.pagerange_t.Controls.Add(this.pagerange_2);
            this.pagerange_t.Controls.Add(this.pagerange_1);
            this.pagerange_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pagerange_t.Location = new System.Drawing.Point(17, 46);
            this.pagerange_t.Name = "pagerange_t";
            this.pagerange_t.Size = new System.Drawing.Size(223, 88);
            this.pagerange_t.TabIndex = 0;
            this.pagerange_t.TabStop = false;
            this.pagerange_t.Text = "Page Range";
            // 
            // pageto
            // 
            this.pageto.BackColor = System.Drawing.Color.White;
            this.pageto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Pageto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pageto.Location = new System.Drawing.Point(156, 58);
            this.pageto.Name = "pageto";
            this.pageto.Size = new System.Drawing.Size(51, 20);
            this.pageto.TabIndex = 40;
            // 
            // pageto_t
            // 
            this.pageto_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageto_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pageto_t.ForeColor = System.Drawing.Color.Black;
            this.pageto_t.Location = new System.Drawing.Point(127, 61);
            this.pageto_t.Name = "pageto_t";
            this.pageto_t.Size = new System.Drawing.Size(22, 17);
            this.pageto_t.TabIndex = 31;
            this.pageto_t.Text = "To";
            this.pageto_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pagerange_3
            // 
            this.pagerange_3.AutoSize = true;
            this.pagerange_3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "PageRange3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pagerange_3.Location = new System.Drawing.Point(16, 61);
            this.pagerange_3.Name = "pagerange_3";
            this.pagerange_3.Size = new System.Drawing.Size(48, 17);
            this.pagerange_3.TabIndex = 43;
            this.pagerange_3.TabStop = true;
            this.pagerange_3.Text = "From";
            this.pagerange_3.UseVisualStyleBackColor = true;
            // 
            // pagefrom
            // 
            this.pagefrom.BackColor = System.Drawing.Color.White;
            this.pagefrom.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Pagefrom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pagefrom.Location = new System.Drawing.Point(70, 58);
            this.pagefrom.Name = "pagefrom";
            this.pagefrom.Size = new System.Drawing.Size(51, 20);
            this.pagefrom.TabIndex = 30;
            // 
            // pagerange_2
            // 
            this.pagerange_2.AutoSize = true;
            this.pagerange_2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "PageRange2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pagerange_2.Location = new System.Drawing.Point(16, 38);
            this.pagerange_2.Name = "pagerange_2";
            this.pagerange_2.Size = new System.Drawing.Size(87, 17);
            this.pagerange_2.TabIndex = 42;
            this.pagerange_2.TabStop = true;
            this.pagerange_2.Text = "Current Page";
            this.pagerange_2.UseVisualStyleBackColor = true;
            // 
            // pagerange_1
            // 
            this.pagerange_1.AutoSize = true;
            this.pagerange_1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "PageRange1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pagerange_1.Location = new System.Drawing.Point(16, 17);
            this.pagerange_1.Name = "pagerange_1";
            this.pagerange_1.Size = new System.Drawing.Size(36, 17);
            this.pagerange_1.TabIndex = 41;
            this.pagerange_1.TabStop = true;
            this.pagerange_1.Text = "All";
            this.pagerange_1.UseVisualStyleBackColor = true;
            // 
            // DPrintOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.Controls.Add(this.pagerange_t);
            this.Controls.Add(this.copys_t);
            this.Controls.Add(this.copys);
            this.Name = "DPrintOptions";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.pagerange_t.ResumeLayout(false);
            this.pagerange_t.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


    }
}
