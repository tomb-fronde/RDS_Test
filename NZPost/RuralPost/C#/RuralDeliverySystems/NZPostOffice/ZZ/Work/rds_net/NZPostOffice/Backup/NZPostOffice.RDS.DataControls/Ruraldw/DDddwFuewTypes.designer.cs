using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DDddwFuewTypes
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox ft_description;

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
            this.Name = "DDddwFuewTypes";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(DddwFuewTypes);
            //
            // ft_description
            //
            ft_description = new System.Windows.Forms.TextBox();
            this.ft_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ft_description.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.ft_description.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ft_description.Location = new System.Drawing.Point(0, 1);
            this.ft_description.MaxLength = 40;
            this.ft_description.Name = "ft_description";
            this.ft_description.Size = new System.Drawing.Size(246, 13);
            this.ft_description.TextAlign = HorizontalAlignment.Left;
            this.ft_description.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FtDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ft_description.TabIndex = 20;
            this.Controls.Add(ft_description);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
        #endregion
    }
}
