using System.Windows.Forms;
using System;
namespace NZPostOffice.ODPS.Controls
{
    partial class WValidationerror
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "WValidationerror";

            this.SuspendLayout();
            this.p_rowfocusindicator = new PictureBox();
            this.dw_error = new URdsDw();
            Controls.Add(p_rowfocusindicator);
            Controls.Add(dw_error);

            //?this.Icon = new System.Drawing.Icon("StopSign!");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Tag = "color=window;";
            this.Text = "Error/Warning Message ( s)";
            this.ControlBox = true;
            this.Visible = false;
            this.Size = new System.Drawing.Size(633, 136);
            this.Top = 1;
            this.Location = new System.Drawing.Point(1, 1);
           
            // 
            // p_rowfocusindicator
            // 
            p_rowfocusindicator.TabStop = false;
            //?p_rowfocusindicator.Image = new System.Drawing.Bitmap("light.bmp");
            p_rowfocusindicator.Enabled = false;
            p_rowfocusindicator.Visible = false;
            p_rowfocusindicator.Size = new System.Drawing.Size(17, 17);
            p_rowfocusindicator.Top = 3;
            p_rowfocusindicator.Location = new System.Drawing.Point(1, 3);
           
            // 
            // dw_error
            // 
            //?dw_error.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //?dw_error.border = false;
            dw_error.Tag = "color=window;";
            dw_error.Size = new System.Drawing.Size(627, 97);
            dw_error.Location = new System.Drawing.Point(0, 0);
            dw_error.RowFocusChanged += new EventHandler(dw_error_rowfocuschanged);
            dw_error.Click += new EventHandler(dw_error_clicked);
            this.ResumeLayout();
        }

        #endregion

        public PictureBox p_rowfocusindicator;

        public URdsDw dw_error;
    }
}