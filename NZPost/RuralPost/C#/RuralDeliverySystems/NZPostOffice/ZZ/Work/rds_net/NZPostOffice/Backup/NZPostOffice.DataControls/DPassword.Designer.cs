using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NZPostOffice.DataControls
{
    partial class DPassword
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

        private System.Windows.Forms.Label old_password_t;
        private System.Windows.Forms.Label new_password_t;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.TextBox old_password;
        private System.Windows.Forms.TextBox new_password;
        private System.Windows.Forms.TextBox new_password_check;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DPassword";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.Entity.Password);

            //
            // old_password
            //
            old_password = new System.Windows.Forms.TextBox();
            this.old_password.Location = new System.Drawing.Point(103, 3);
            this.old_password.MaxLength = 20;
            this.old_password.Name = "old_password";
            this.old_password.Size = new System.Drawing.Size(100, 22);
            this.old_password.TextAlign = HorizontalAlignment.Left;
            this.old_password.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.old_password.PasswordChar = '*';
            this.old_password.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "OldPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(old_password);

            //
            // new_password
            //
            new_password = new System.Windows.Forms.TextBox();
            this.new_password.Location = new System.Drawing.Point(103, 27);
            this.new_password.MaxLength = 20;
            this.new_password.Name = "new_password";
            this.new_password.Size = new System.Drawing.Size(100, 22);
            this.new_password.TextAlign = HorizontalAlignment.Left;
            this.new_password.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.new_password.PasswordChar = '*';
            this.new_password.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "NewPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(new_password);

            //
            // new_password_check
            //
            new_password_check = new System.Windows.Forms.TextBox();
            this.new_password_check.Location = new System.Drawing.Point(103, 51);
            this.new_password_check.MaxLength = 20;
            this.new_password_check.Name = "new_password_check";
            this.new_password_check.Size = new System.Drawing.Size(100, 22);
            this.new_password_check.TextAlign = HorizontalAlignment.Left;
            this.new_password_check.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.new_password_check.PasswordChar = '*';
            this.new_password_check.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "NewPasswordCheck", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(new_password_check);

            //
            // old_password_t
            //
            this.old_password_t = new System.Windows.Forms.Label();
            this.old_password_t.Font = new System.Drawing.Font("Arial", 8F);
            this.old_password_t.ForeColor = System.Drawing.Color.Black;
            this.old_password_t.Location = new System.Drawing.Point(5, 3);
            this.old_password_t.Name = "old_password_t";
            this.old_password_t.Size = new System.Drawing.Size(98, 14);
            this.old_password_t.Text = "Current Password";
            this.Controls.Add(old_password_t);

            //
            // new_password_t
            //
            this.new_password_t = new System.Windows.Forms.Label();
            this.new_password_t.Font = new System.Drawing.Font("Arial", 8F);
            this.new_password_t.ForeColor = System.Drawing.Color.Black;
            this.new_password_t.Location = new System.Drawing.Point(5, 27);
            this.new_password_t.Name = "new_password_t";
            this.new_password_t.Size = new System.Drawing.Size(98, 14);
            this.new_password_t.Text = "New Password";
            this.Controls.Add(new_password_t);

            //
            // t_1
            //
            this.t_1 = new System.Windows.Forms.Label();
            this.t_1.Font = new System.Drawing.Font("Arial", 8F);
            this.t_1.ForeColor = System.Drawing.Color.Black;
            this.t_1.Location = new System.Drawing.Point(1, 51);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(102, 14);
            this.t_1.Text = "Re-Enter Password";
            this.Controls.Add(t_1);

            this.Size = new System.Drawing.Size(224, 122);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
        #endregion

    }
}
