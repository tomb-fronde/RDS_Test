using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DDddwRenewalGroups
	{

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //private System.Windows.Forms.DataGridViewTextBoxColumn rg_description;
        private TextBox rg_description;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DDddwRenewalGroups";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwRenewalGroups);
            //
            // rg_description
            //
            rg_description = new System.Windows.Forms.TextBox();
            this.rg_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rg_description.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rg_description.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rg_description.Location = new System.Drawing.Point(0, 1);
            this.rg_description.MaxLength = 40;
            this.rg_description.Name = "rg_description";
            this.rg_description.Size = new System.Drawing.Size(246, 13);
            this.rg_description.TextAlign = HorizontalAlignment.Left;
            //this.rg_description.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.rg_description.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "RgDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rg_description.TabIndex = 20;
            this.Controls.Add(rg_description);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
        }
        #endregion

	}
}
