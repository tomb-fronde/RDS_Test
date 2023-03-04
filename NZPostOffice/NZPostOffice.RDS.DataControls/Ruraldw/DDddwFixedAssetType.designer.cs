using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DDddwFixedAssetType
	{

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox fat_description;


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
            this.Name = "DDddwFixedAssetType";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.DddwFixedAssetType);
            //
            // fat_description
            //
            fat_description = new System.Windows.Forms.TextBox();
            this.fat_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fat_description.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.fat_description.ForeColor = System.Drawing.Color.Black;
            this.fat_description.Location = new System.Drawing.Point(8, 1);
            this.fat_description.MaxLength = 40;
            this.fat_description.Name = "fat_description";
            this.fat_description.Size = new System.Drawing.Size(205, 14);
            this.fat_description.TextAlign = HorizontalAlignment.Left;
            this.fat_description.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.fat_description.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FatDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fat_description.ReadOnly = true;
            this.Controls.Add(fat_description);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
        }
        #endregion


	}
}
