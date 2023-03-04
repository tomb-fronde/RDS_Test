using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class DwPostIrdNo
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

        private System.Windows.Forms.TextBox nat_ird_no;
        private System.Windows.Forms.Label t_1;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DwPostIrdNo";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.PostIrdNo);
            
            //
            // nat_ird_no
            //
            nat_ird_no = new System.Windows.Forms.TextBox();
            this.nat_ird_no.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nat_ird_no.Font = new System.Drawing.Font("Arial", 10F);
            this.nat_ird_no.ForeColor = System.Drawing.Color.Black;
            this.nat_ird_no.Location = new System.Drawing.Point(100, 1);
            this.nat_ird_no.MaxLength = 20;
            this.nat_ird_no.Name = "nat_ird_no";
            this.nat_ird_no.Size = new System.Drawing.Size(255, 17);
            this.nat_ird_no.TextAlign = HorizontalAlignment.Left;
            this.nat_ird_no.DataBindings.Add(new System.Windows.Forms.Binding("Text",
            this.bindingSource, "NatIrdNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nat_ird_no.ReadOnly = true;
            this.Controls.Add(nat_ird_no);

            //
            // prst_id_t
            //
            this.t_1 = new System.Windows.Forms.Label();
            this.t_1.Font = new System.Drawing.Font("Arial", 10F);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(0, 0);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(100, 16);
            this.t_1.Text = "IRD number: ";
            this.t_1.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(t_1);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
        #endregion

    }
}
