using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DExtRegion
    {
        // TJB  FCR_001 28-Nov-2012
        // Increased size of renewal group dropdown to include November Renewals

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

        private Metex.Windows.DataEntityCombo d_ext_region_id;
        private System.Windows.Forms.Label d_ext_region_name_t;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
		{
            this.d_ext_region_id = new Metex.Windows.DataEntityCombo();
            this.d_ext_region_name_t = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.ExtRegion);
            // 
            // d_ext_region_id
            // 
            this.d_ext_region_id.AutoRetrieve = true;
            this.d_ext_region_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "DExtRegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.d_ext_region_id.DisplayMember = "RgnName";
            this.d_ext_region_id.DropDownHeight = 150;
            this.d_ext_region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.d_ext_region_id.DropDownWidth = 121;
            this.d_ext_region_id.Font = new System.Drawing.Font("Arial", 8F);
            this.d_ext_region_id.ForeColor = System.Drawing.Color.Black;
            this.d_ext_region_id.IntegralHeight = false;
            this.d_ext_region_id.Location = new System.Drawing.Point(44, 1);
            this.d_ext_region_id.Name = "d_ext_region_id";
            this.d_ext_region_id.Size = new System.Drawing.Size(121, 22);
            this.d_ext_region_id.TabIndex = 10;
            this.d_ext_region_id.Value = null;
            this.d_ext_region_id.ValueMember = "RegionId";
            // 
            // d_ext_region_name_t
            // 
            this.d_ext_region_name_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.d_ext_region_name_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.d_ext_region_name_t.ForeColor = System.Drawing.Color.Black;
            this.d_ext_region_name_t.Location = new System.Drawing.Point(1, 6);
            this.d_ext_region_name_t.Name = "d_ext_region_name_t";
            this.d_ext_region_name_t.Size = new System.Drawing.Size(44, 13);
            this.d_ext_region_name_t.TabIndex = 11;
            this.d_ext_region_name_t.Text = "Region:";
            this.d_ext_region_name_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DExtRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.d_ext_region_id);
            this.Controls.Add(this.d_ext_region_name_t);
            this.Name = "DExtRegion";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

		}
        #endregion

    }
}
