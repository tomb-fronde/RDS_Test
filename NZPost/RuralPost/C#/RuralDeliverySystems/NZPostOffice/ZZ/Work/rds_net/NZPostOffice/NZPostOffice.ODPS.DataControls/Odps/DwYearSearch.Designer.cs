using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class DwYearSearch
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.MaskedTextBox start_date;
        private System.Windows.Forms.Label start_date_t;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DwYearSearch";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.YearSearch);
            //
            // start_date_t
            //
            this.start_date_t = new System.Windows.Forms.Label();
            this.start_date_t.Font = new System.Drawing.Font("Arial", 8F);
            this.start_date_t.ForeColor = System.Drawing.Color.Black;
            this.start_date_t.Location = new System.Drawing.Point(0, 9);
            this.start_date_t.Name = "start_date_t";
            this.start_date_t.Size = new System.Drawing.Size(40, 14);
            this.start_date_t.Text = "Year:";
            this.start_date_t.TextAlign = ContentAlignment.MiddleRight;
            //this.start_date_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(start_date_t);


            //
            // start_date
            //
            start_date = new System.Windows.Forms.MaskedTextBox();
            this.start_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
//?            this.start_date.Font = new System.Drawing.Font("", F);
//?            this.start_date.ForeColor = System.Drawing.ColorTranslator.FromWin32(Arial);
            this.start_date.Location = new System.Drawing.Point(45, 9);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(50, 14);
//?            this.start_date.TextAlign = ContentAlignment.MiddleLeft;
            this.start_date.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.start_date.Mask = "";
            this.start_date.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "StartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.start_date.TabIndex = 10;
            this.Controls.Add(start_date);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.BackColor = System.Drawing.ColorTranslator.FromWin32(82439147);
        }
        #endregion

    }
}
