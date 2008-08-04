using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DDddwMailCategoryFixed
	{

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox desc;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DDddwMailCategoryFixed";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.DddwMailCategoryFixed);
            //
            // desc
            //
            desc = new System.Windows.Forms.TextBox();
            this.desc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.desc.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.desc.ForeColor = System.Drawing.Color.Black;
            this.desc.Location = new System.Drawing.Point(3, 1);
            this.desc.MaxLength = 0;
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(250, 14);
            this.desc.TextAlign = HorizontalAlignment.Left;
            this.desc.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.desc.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Desc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.desc.TabIndex = 20;
            this.Controls.Add(desc);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
        }


	}
}
