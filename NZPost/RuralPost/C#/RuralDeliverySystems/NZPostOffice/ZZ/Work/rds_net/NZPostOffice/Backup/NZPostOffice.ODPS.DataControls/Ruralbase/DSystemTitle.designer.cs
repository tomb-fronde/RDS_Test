using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.Ruralbase;

namespace NZPostOffice.ODPS.DataControls.Ruralbase
{
    partial class DSystemTitle
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null ))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private System.Windows.Forms.TextBox systemtitle;
        private System.Windows.Forms.TextBox compute_1;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DSystemTitle";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();

            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Ruralbase.SystemTitle);


            this.systemtitle = new System.Windows.Forms.TextBox();
            this.systemtitle.Name = "systemtitle";
            this.systemtitle.Location = new System.Drawing.Point(1, 1);
            this.systemtitle.Size = new System.Drawing.Size(320, 19);
            this.systemtitle.TabIndex = 0;
            this.systemtitle.Enabled = false;
            this.systemtitle.Visible = true;
            this.systemtitle.Font = new System.Drawing.Font("MS Sans Serif", 10);
            this.systemtitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.systemtitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Systemtitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.systemtitle.BorderStyle = BorderStyle.None;
            this.Controls.Add(systemtitle);

            this.compute_1 = new System.Windows.Forms.TextBox();
            this.compute_1.Name = "compute_1";
            this.compute_1.Location = new System.Drawing.Point(2, 32);
            this.compute_1.Size = new System.Drawing.Size(320, 13);
            this.compute_1.TabIndex = 0;
            this.compute_1.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.compute_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.compute_1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.compute_1.BorderStyle = BorderStyle.None;
            this.Controls.Add(compute_1);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
        #endregion

    }
}
