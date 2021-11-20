using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
    partial class DwOdpsPiecerateVolumes
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

        private System.Windows.Forms.Label prv_effective_end_date_t;
        private System.Windows.Forms.Label prv_paid_t;
        private System.Windows.Forms.Label prst_id_t;
        private System.Windows.Forms.TextBox prv_effective_end_date;
        private System.Windows.Forms.TextBox prv_paid;
        private System.Windows.Forms.TextBox prst_id;
        private System.Windows.Forms.TextBox prv_quantity;
        private System.Windows.Forms.Label prv_quantity_t;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DwOdpsPiecerateVolumes";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Odps.OdpsPiecerateVolumes);
         
            //
            // prv_effective_end_date_t
            //
            this.prv_effective_end_date_t = new System.Windows.Forms.Label();
            this.prv_effective_end_date_t.Font = new System.Drawing.Font("Arial", 10F);
            this.prv_effective_end_date_t.ForeColor = System.Drawing.Color.Black;
            this.prv_effective_end_date_t.Location = new System.Drawing.Point(-10, 6);
            this.prv_effective_end_date_t.Name = "prv_effective_end_date_t";
            this.prv_effective_end_date_t.Size = new System.Drawing.Size(165, 16);
            this.prv_effective_end_date_t.Text = "Prv Effective End Date:";
            this.prv_effective_end_date_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(prv_effective_end_date_t);

            //
            // prv_quantity_t
            //
            this.prv_quantity_t = new System.Windows.Forms.Label();
            this.prv_quantity_t.Font = new System.Drawing.Font("Arial", 10F);
            this.prv_quantity_t.ForeColor = System.Drawing.Color.Black;
            this.prv_quantity_t.Location = new System.Drawing.Point(15, 30);
            this.prv_quantity_t.Name = "prv_quantity_t";
            this.prv_quantity_t.Size = new System.Drawing.Size(135, 16);
            this.prv_quantity_t.Text = "Prv Quantity:";
            this.prv_quantity_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(prv_quantity_t);

            //
            // prv_paid_t
            //
            this.prv_paid_t = new System.Windows.Forms.Label();
            this.prv_paid_t.Font = new System.Drawing.Font("Arial", 10F);
            this.prv_paid_t.ForeColor = System.Drawing.Color.Black;
            this.prv_paid_t.Location = new System.Drawing.Point(15, 55);
            this.prv_paid_t.Name = "prv_paid_t";
            this.prv_paid_t.Size = new System.Drawing.Size(135, 16);
            this.prv_paid_t.Text = "Prv Paid:";
            this.prv_paid_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(prv_paid_t);

            //
            // prst_id_t
            //
            this.prst_id_t = new System.Windows.Forms.Label();
            this.prst_id_t.Font = new System.Drawing.Font("Arial", 10F);
            this.prst_id_t.ForeColor = System.Drawing.Color.Black;
            this.prst_id_t.Location = new System.Drawing.Point(15, 80);
            this.prst_id_t.Name = "prst_id_t";
            this.prst_id_t.Size = new System.Drawing.Size(135, 16);
            this.prst_id_t.Text = "Prst Id:";
            this.prst_id_t.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(prst_id_t);

            //
            // prv_effective_end_date
            //
            prv_effective_end_date = new System.Windows.Forms.TextBox();
            this.prv_effective_end_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.prv_effective_end_date.Font = new System.Drawing.Font("Arial", 10F);
            this.prv_effective_end_date.ForeColor = System.Drawing.Color.Black;
            this.prv_effective_end_date.Location = new System.Drawing.Point(157, 6);
            this.prv_effective_end_date.MaxLength = 0;
            this.prv_effective_end_date.Name = "prv_effective_end_date";
            this.prv_effective_end_date.Size = new System.Drawing.Size(72, 19);
            this.prv_effective_end_date.TextAlign = HorizontalAlignment.Left;
            this.prv_effective_end_date.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "PrvEffectiveEndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.prv_effective_end_date.ReadOnly = true;
            this.Controls.Add(prv_effective_end_date);

            //
            // prv_quantity
            //
            prv_quantity = new System.Windows.Forms.TextBox();
            this.prv_quantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.prv_quantity.Font = new System.Drawing.Font("Arial", 10F);
            this.prv_quantity.ForeColor = System.Drawing.Color.Black;
            this.prv_quantity.Location = new System.Drawing.Point(157, 30);
            this.prv_quantity.MaxLength = 0;
            this.prv_quantity.Name = "prv_quantity";
            this.prv_quantity.Size = new System.Drawing.Size(72, 19);
            this.prv_quantity.TextAlign = HorizontalAlignment.Right;
            this.prv_quantity.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "PrvQuantity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.prv_quantity.ReadOnly = true;
            this.Controls.Add(prv_quantity);

            //
            // prv_paid
            //
            prv_paid = new System.Windows.Forms.TextBox();
            this.prv_paid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.prv_paid.Font = new System.Drawing.Font("Arial", 10F);
            this.prv_paid.ForeColor = System.Drawing.Color.Black;
            this.prv_paid.Location = new System.Drawing.Point(157, 55);
            this.prv_paid.MaxLength = 1;
            this.prv_paid.Name = "prv_paid";
            this.prv_paid.Size = new System.Drawing.Size(12, 19);
            this.prv_paid.TextAlign = HorizontalAlignment.Left;
            this.prv_paid.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PrvPaid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.prv_paid.ReadOnly = true;
            this.Controls.Add(prv_paid);

            //
            // prst_id
            //
            prst_id = new System.Windows.Forms.TextBox();
            this.prst_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.prst_id.Font = new System.Drawing.Font("Arial", 10F);
            this.prst_id.ForeColor = System.Drawing.Color.Black;
            this.prst_id.Location = new System.Drawing.Point(157, 80);
            this.prst_id.MaxLength = 0;
            this.prst_id.Name = "prst_id";
            this.prst_id.Size = new System.Drawing.Size(72, 19);
            this.prst_id.TextAlign = HorizontalAlignment.Right;
            this.prst_id.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "PrstId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.prst_id.ReadOnly = true;
            this.Controls.Add(prst_id);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
        #endregion

    }
}
