using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB  RPCR_026  June-2011
    // Added rf_locked_ind

	partial class DAddrSequenceInd
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

		private System.Windows.Forms.Label   t_1;
		private System.Windows.Forms.Label   t_2;
		private System.Windows.Forms.TextBox   rf_valid_date;
		private System.Windows.Forms.TextBox   rf_valid_user;
		private System.Windows.Forms.CheckBox  rf_valid_ind;
        private System.Windows.Forms.CheckBox  rf_locked_ind;

        public event EventHandler CheckedChanged;

        #region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
            this.rf_valid_ind = new System.Windows.Forms.CheckBox();
            this.t_1 = new System.Windows.Forms.Label();
            this.rf_valid_user = new System.Windows.Forms.TextBox();
            this.t_2 = new System.Windows.Forms.Label();
            this.rf_valid_date = new System.Windows.Forms.TextBox();
            this.rf_locked_ind = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.AddrSequenceInd);
            // 
            // rf_valid_ind
            // 
            this.rf_valid_ind.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rf_valid_ind.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rf_valid_ind.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RfValidInd", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rf_valid_ind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rf_valid_ind.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rf_valid_ind.Location = new System.Drawing.Point(429, 2);
            this.rf_valid_ind.Name = "rf_valid_ind";
            this.rf_valid_ind.Size = new System.Drawing.Size(90, 17);
            this.rf_valid_ind.TabIndex = 10;
            this.rf_valid_ind.Text = "Validation Ind";
            this.rf_valid_ind.UseVisualStyleBackColor = false;
            this.rf_valid_ind.CheckedChanged += new System.EventHandler(this.rf_valid_ind_CheckedChanged);
            // 
            // t_1
            // 
            this.t_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_1.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.bindingSource, "isVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.t_1.Location = new System.Drawing.Point(3, 2);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(100, 14);
            this.t_1.TabIndex = 11;
            this.t_1.Text = "Last sequenced by";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rf_valid_user
            // 
            this.rf_valid_user.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rf_valid_user.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rf_valid_user.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RfValidUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rf_valid_user.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.bindingSource, "isVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rf_valid_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rf_valid_user.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rf_valid_user.Location = new System.Drawing.Point(105, 2);
            this.rf_valid_user.MaxLength = 20;
            this.rf_valid_user.Name = "rf_valid_user";
            this.rf_valid_user.ReadOnly = true;
            this.rf_valid_user.Size = new System.Drawing.Size(105, 13);
            this.rf_valid_user.TabIndex = 12;
            // 
            // t_2
            // 
            this.t_2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.t_2.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.bindingSource, "isVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.t_2.Location = new System.Drawing.Point(217, 2);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(18, 14);
            this.t_2.TabIndex = 13;
            this.t_2.Text = "on";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rf_valid_date
            // 
            this.rf_valid_date.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rf_valid_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rf_valid_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RfValidDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rf_valid_date.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.bindingSource, "isVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rf_valid_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rf_valid_date.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rf_valid_date.Location = new System.Drawing.Point(237, 2);
            this.rf_valid_date.MaxLength = 0;
            this.rf_valid_date.Name = "rf_valid_date";
            this.rf_valid_date.ReadOnly = true;
            this.rf_valid_date.Size = new System.Drawing.Size(67, 13);
            this.rf_valid_date.TabIndex = 14;
            // 
            // rf_locked_ind
            // 
            this.rf_locked_ind.AutoSize = true;
            this.rf_locked_ind.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rf_locked_ind.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RfLocked", true));
            this.rf_locked_ind.Location = new System.Drawing.Point(351, 2);
            this.rf_locked_ind.Name = "rf_locked_ind";
            this.rf_locked_ind.Size = new System.Drawing.Size(62, 17);
            this.rf_locked_ind.TabIndex = 5;
            this.rf_locked_ind.Text = "Locked";
            this.rf_locked_ind.UseVisualStyleBackColor = true;
            this.rf_locked_ind.CheckedChanged += new System.EventHandler(this.rf_valid_ind_CheckedChanged);
            // 
            // DAddrSequenceInd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.rf_locked_ind);
            this.Controls.Add(this.rf_valid_ind);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.rf_valid_user);
            this.Controls.Add(this.t_2);
            this.Controls.Add(this.rf_valid_date);
            this.Name = "DAddrSequenceInd";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        void rf_valid_ind_CheckedChanged(object sender, EventArgs e)
        {
                t_1.Visible = rf_valid_ind.Checked ? true : false;
                rf_valid_user.Visible = rf_valid_ind.Checked ? true : false;
                t_2.Visible = rf_valid_ind.Checked ? true : false;
                rf_valid_date.Visible = rf_valid_ind.Checked ? true : false;
                if (CheckedChanged != null)
                    CheckedChanged(sender, e);
            }

	}
}
