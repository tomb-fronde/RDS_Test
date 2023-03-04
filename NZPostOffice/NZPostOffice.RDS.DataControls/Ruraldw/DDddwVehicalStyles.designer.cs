using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DDddwVehicalStyles
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox vs_description;

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
            this.Name = "DDddwVehicalStyles";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwVehicalStyles);
            //
            // vs_description
            //
            vs_description = new System.Windows.Forms.TextBox();
            this.vs_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vs_description.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.vs_description.ForeColor = System.Drawing.SystemColors.WindowText;
            this.vs_description.Location = new System.Drawing.Point(0, 1);
            this.vs_description.MaxLength = 40;
            this.vs_description.Name = "vs_description";
            this.vs_description.Size = new System.Drawing.Size(246, 13);
            this.vs_description.TextAlign = HorizontalAlignment.Left;
            //this.vs_description.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.vs_description.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "VsDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vs_description.TabIndex = 20;
            this.Controls.Add(vs_description);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
        }
        #endregion
    }
}
