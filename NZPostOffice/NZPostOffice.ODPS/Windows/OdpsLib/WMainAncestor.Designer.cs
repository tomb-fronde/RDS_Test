using System.Windows.Forms;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    partial class WMainAncestor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.SuspendLayout();
            this.st_label = new Label();
            this.Controls.Add(st_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
      
            this.Text = "Untitled";
            this.ControlBox = true;
            this.Location = new System.Drawing.Point(147, 66);
            this.Size = new System.Drawing.Size(346, 266);
            
            // 
            // st_label
            // 
            st_label.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            st_label.ForeColor = System.Drawing.SystemColors.WindowText;
            st_label.TabStop = false;
            st_label.Text = "Label";
            st_label.Location = new System.Drawing.Point(3, 201);
            st_label.Size=new System.Drawing.Size(112,18);

            this.Icon = global::NZPostOffice.Shared.Properties.Resources.SAFE02;

            this.ResumeLayout();
        }

        #endregion

        public Label st_label;
    }
}