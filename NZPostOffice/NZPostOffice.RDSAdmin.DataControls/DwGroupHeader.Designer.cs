using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DwGroupHeader
	{

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private System.Windows.Forms.TextBox   ug_name;
		private System.Windows.Forms.Label   ug_description_t;
		private System.Windows.Forms.Label   ug_name_t;
		private System.Windows.Forms.CheckBox   ug_privacy_override;
		private System.Windows.Forms.TextBox   ug_description;
        private System.Windows.Forms.GroupBox gbInfo;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
            this.ug_privacy_override = new System.Windows.Forms.CheckBox();
            this.gbInfo = new GroupBox();
            this.ug_description = new System.Windows.Forms.TextBox();
            this.ug_name = new System.Windows.Forms.TextBox();
            this.ug_name_t = new System.Windows.Forms.Label();
            this.ug_description_t = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.GroupHeader);
            // 
            // ug_privacy_override
            // 
            this.ug_privacy_override.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ug_privacy_override.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "UgPrivacyOverride", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ug_privacy_override.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ug_privacy_override.ForeColor = System.Drawing.Color.Black;
            this.ug_privacy_override.Location = new System.Drawing.Point(76, 104);
            this.ug_privacy_override.Name = "ug_privacy_override";
            this.ug_privacy_override.Size = new System.Drawing.Size(124, 17);
            this.ug_privacy_override.TabIndex = 30;
            this.ug_privacy_override.Text = "Override privacy flag";
            this.ug_privacy_override.UseVisualStyleBackColor = false;
            // 
            // ug_description
            // 
            this.ug_description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.ug_description.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "UgDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ug_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ug_description.ForeColor = System.Drawing.Color.Black;
            this.ug_description.Location = new System.Drawing.Point(76, 43);
            this.ug_description.MaxLength = 255;
            this.ug_description.Multiline = true;
            this.ug_description.Name = "ug_description";
            this.ug_description.Size = new System.Drawing.Size(373, 55);
            this.ug_description.TabIndex = 20;
            // 
            // ug_name
            // 
            this.ug_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.ug_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "UgName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ug_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ug_name.ForeColor = System.Drawing.Color.Black;
            this.ug_name.Location = new System.Drawing.Point(76, 24);
            this.ug_name.MaxLength = 50;
            this.ug_name.Name = "ug_name";
            this.ug_name.Size = new System.Drawing.Size(373, 20);
            this.ug_name.TabIndex = 10;
            // 
            // ug_name_t
            // 
            this.ug_name_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ug_name_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ug_name_t.ForeColor = System.Drawing.Color.Black;
            this.ug_name_t.Location = new System.Drawing.Point(10, 24);
            this.ug_name_t.Name = "ug_name_t";
            this.ug_name_t.Size = new System.Drawing.Size(38, 13);
            this.ug_name_t.TabIndex = 31;
            this.ug_name_t.Text = "Name";
            this.ug_name_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ug_description_t
            // 
            this.ug_description_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ug_description_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ug_description_t.ForeColor = System.Drawing.Color.Black;
            this.ug_description_t.Location = new System.Drawing.Point(10, 43);
            this.ug_description_t.Name = "ug_description_t";
            this.ug_description_t.Size = new System.Drawing.Size(60, 13);
            this.ug_description_t.TabIndex = 32;
            this.ug_description_t.Text = "Description";
            this.ug_description_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            
            this.gbInfo.Location = new System.Drawing.Point(5, 5);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(487, 130);
            this.gbInfo.TabIndex = 2;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Group Information";

            //this.gbInfo.Controls.Add(this.dataGridView1);

            // 
            // DwGroupHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.gbInfo);

            this.gbInfo.Controls.Add(this.ug_privacy_override);
            this.gbInfo.Controls.Add(this.ug_description);
            this.gbInfo.Controls.Add(this.ug_name);
            this.gbInfo.Controls.Add(this.ug_name_t);
            this.gbInfo.Controls.Add(this.ug_description_t);
            this.Name = "DwGroupHeader";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	}
}
