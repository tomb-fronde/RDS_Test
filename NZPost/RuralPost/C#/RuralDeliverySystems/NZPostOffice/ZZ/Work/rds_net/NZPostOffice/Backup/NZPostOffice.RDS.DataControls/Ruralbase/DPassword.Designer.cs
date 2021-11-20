namespace NZPostOffice.RDS.DataControls.Ruralbase
{
    partial class DPassword
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

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
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralbase.Password);
            #region old_password define
            this.old_password = new System.Windows.Forms.TextBox();
            this.old_password.Name = "old_password";
            this.old_password.Location = new System.Drawing.Point(117, 4);
            this.old_password.Size = new System.Drawing.Size(114, 13);
            this.old_password.TabIndex = 10;
            this.old_password.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.old_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.old_password.MaxLength = 20;
            this.old_password.PasswordChar = '*';
            this.old_password.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.old_password.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OldPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(old_password);
            #region new_password define
            this.new_password = new System.Windows.Forms.TextBox();
            this.new_password.Name = "new_password";
            this.new_password.Location = new System.Drawing.Point(117, 36);
            this.new_password.Size = new System.Drawing.Size(114, 13);
            this.new_password.TabIndex = 20;
            this.new_password.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.new_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.new_password.MaxLength = 20;
            this.new_password.PasswordChar = '*';
            this.new_password.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.new_password.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NewPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(new_password);
            #region new_password_check define
            this.new_password_check = new System.Windows.Forms.TextBox();
            this.new_password_check.Name = "new_password_check";
            this.new_password_check.Location = new System.Drawing.Point(117, 60);
            this.new_password_check.Size = new System.Drawing.Size(114, 13);
            this.new_password_check.TabIndex = 30;
            this.new_password_check.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.new_password_check.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.new_password_check.MaxLength = 20;
            this.new_password_check.PasswordChar = '*';
            this.new_password_check.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.new_password_check.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NewPasswordCheck", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(new_password_check);
            #region old_password_t define
            this.old_password_t = new System.Windows.Forms.Label();
            this.old_password_t.Name = "old_password_t";
            this.old_password_t.Location = new System.Drawing.Point(5, 4);
            this.old_password_t.Size = new System.Drawing.Size(94, 13);
            this.old_password_t.TabIndex = 0;
            this.old_password_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.old_password_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.old_password_t.Text = "Current Password";
            #endregion
            this.Controls.Add(old_password_t);
            #region new_password_t define
            this.new_password_t = new System.Windows.Forms.Label();
            this.new_password_t.Name = "new_password_t";
            this.new_password_t.Location = new System.Drawing.Point(5, 36);
            this.new_password_t.Size = new System.Drawing.Size(104, 13);
            this.new_password_t.TabIndex = 0;
            this.new_password_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.new_password_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.new_password_t.Text = "New Password";
            #endregion
            this.Controls.Add(new_password_t);
            #region n_10713070 define
            this.n_10713070 = new System.Windows.Forms.Label();
            this.n_10713070.Name = "n_10713070";
            this.n_10713070.Location = new System.Drawing.Point(5, 60);
            this.n_10713070.Size = new System.Drawing.Size(104, 13);
            this.n_10713070.TabIndex = 0;
            this.n_10713070.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_10713070.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_10713070.Text = "Re-Enter Password";
            #endregion
            this.Controls.Add(n_10713070);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.TextBox old_password;
        private System.Windows.Forms.TextBox new_password;
        private System.Windows.Forms.TextBox new_password_check;
        private System.Windows.Forms.Label old_password_t;
        private System.Windows.Forms.Label new_password_t;
        private System.Windows.Forms.Label n_10713070;
    }
}
