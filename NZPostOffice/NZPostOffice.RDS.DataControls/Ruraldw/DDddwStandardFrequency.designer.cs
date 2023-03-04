using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DDddwStandardFrequency
	{

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //private System.Windows.Forms.DataGridViewTextBoxColumn sf_description;
        private TextBox sf_description;


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
            this.Name = "DDddwStandardFrequency";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwStandardFrequency);
            //
            // sf_description
            //
            sf_description = new System.Windows.Forms.TextBox();
            this.sf_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sf_description.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.sf_description.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sf_description.Location = new System.Drawing.Point(0, 1);
            this.sf_description.MaxLength = 40;
            this.sf_description.Name = "sf_description";
            this.sf_description.Size = new System.Drawing.Size(246, 13);
            this.sf_description.TextAlign = HorizontalAlignment.Left;
            this.sf_description.BackColor = System.Drawing.SystemColors.Control;//System.Drawing.ColorTranslator.FromWin32(553648127);
            this.sf_description.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "SfDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sf_description.TabIndex = 20;
            this.Controls.Add(sf_description);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
        }
        #endregion


	}
}
