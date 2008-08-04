using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DExtRegion
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

        private Metex.Windows.DataEntityCombo d_ext_region_id;
        private System.Windows.Forms.Label d_ext_region_name_t;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DExtRegion";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.ExtRegion);
			//
			// d_ext_region_id
			//
			d_ext_region_id = new Metex.Windows.DataEntityCombo();
			this.d_ext_region_id.AutoRetrieve = true;
			//this.d_ext_region_id.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.d_ext_region_id.DisplayMember = "RgnName";
			this.d_ext_region_id.Font = new System.Drawing.Font("Arial", 8F);
			this.d_ext_region_id.ForeColor = System.Drawing.Color.Black;
			this.d_ext_region_id.Location = new System.Drawing.Point(44, 1);
			this.d_ext_region_id.Name = "d_ext_region_id";
			this.d_ext_region_id.Size = new System.Drawing.Size(121, 22);
			this.d_ext_region_id.TabIndex = 10;
			this.d_ext_region_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.d_ext_region_id.Value = null;
			this.d_ext_region_id.ValueMember = "RegionId";
			this.d_ext_region_id.DropDownWidth = 121;
			this.d_ext_region_id.DataBindings.Add(
				new System.Windows.Forms.Binding("Value", this.bindingSource, "DExtRegionId", true,
				System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Controls.Add(d_ext_region_id);

			//
			// d_ext_region_name_t
			//
			this.d_ext_region_name_t = new System.Windows.Forms.Label();
			this.d_ext_region_name_t.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.d_ext_region_name_t.ForeColor = System.Drawing.Color.Black;
			this.d_ext_region_name_t.Location = new System.Drawing.Point(1, 6);
			this.d_ext_region_name_t.Name = "d_ext_region_name_t";
			this.d_ext_region_name_t.Size = new System.Drawing.Size(44, 13);
			this.d_ext_region_name_t.Text = "Region:";
			this.d_ext_region_name_t.TextAlign = ContentAlignment.MiddleRight;
			this.d_ext_region_name_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(d_ext_region_name_t);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;// System.Drawing.ColorTranslator.FromWin32(80269524);
		}
        #endregion

    }
}
