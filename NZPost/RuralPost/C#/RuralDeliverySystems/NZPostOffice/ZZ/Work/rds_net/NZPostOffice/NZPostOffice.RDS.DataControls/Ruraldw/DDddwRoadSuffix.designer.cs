using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DDddwRoadSuffix
	{

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //?private System.Windows.Forms.DataGridViewTextBoxColumn rs_name;
        private TextBox rs_name;

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
            this.Name = "DDddwRoadSuffix";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwRoadSuffix);
            //
            // rs_name
            //
            rs_name = new System.Windows.Forms.TextBox();
            this.rs_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rs_name.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rs_name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rs_name.Location = new System.Drawing.Point(0, 1);
            this.rs_name.MaxLength = 40;
            this.rs_name.Name = "rs_name";
            this.rs_name.Size = new System.Drawing.Size(246, 13);
            this.rs_name.TextAlign = HorizontalAlignment.Left;
            //this.rs_name.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.rs_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "RsName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rs_name.TabIndex = 20;
            this.Controls.Add(rs_name);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);

        }
        #endregion


	}
}
