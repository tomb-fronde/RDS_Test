using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    partial class DDddwSuburbNames
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //?private System.Windows.Forms.DataGridViewTextBoxColumn sl_name;
        private TextBox sl_name;

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
            this.Name = "DDddwSuburbNames";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwSuburbNames);
            //
            // sl_name
            //
            sl_name = new System.Windows.Forms.TextBox();
            this.sl_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sl_name.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.sl_name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sl_name.Location = new System.Drawing.Point(0, 1);
            this.sl_name.MaxLength = 40;
            this.sl_name.Name = "sl_name";
            this.sl_name.Size = new System.Drawing.Size(246, 13);
            this.sl_name.TextAlign = HorizontalAlignment.Left;
            //this.sl_name.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.sl_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "SlName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sl_name.TabIndex = 20;
            this.Controls.Add(sl_name);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
        }
        #endregion


    }
}
