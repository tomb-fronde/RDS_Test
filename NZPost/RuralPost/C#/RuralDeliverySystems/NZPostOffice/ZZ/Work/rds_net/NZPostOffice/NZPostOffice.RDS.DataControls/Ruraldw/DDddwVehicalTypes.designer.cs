using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DDddwVehicalTypes
	{

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox vt_description;


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
            this.Name = "DDddwVehicalTypes";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwVehicalTypes);
            //
            // vt_description
            //
            vt_description = new System.Windows.Forms.TextBox();
            this.vt_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vt_description.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.vt_description.ForeColor = System.Drawing.SystemColors.WindowText;
            this.vt_description.Location = new System.Drawing.Point(0, 1);
            this.vt_description.MaxLength = 40;
            this.vt_description.Name = "vt_description";
            this.vt_description.Size = new System.Drawing.Size(246, 13);
            this.vt_description.TextAlign = HorizontalAlignment.Left;
           // this.vt_description.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.vt_description.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "VtDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vt_description.TabIndex = 20;
            this.Controls.Add(vt_description);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           // this.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
        }
        #endregion

	}
}
