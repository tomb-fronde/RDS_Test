using System.Windows.Forms;
namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    partial class WOpeningScreen
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "WOpeningScreen";
            this.SuspendLayout();
            this.dw_title = new NZPostOffice.ODPS.DataControls.Ruralbase.DSystemTitle();
            this.mle_copyright = new TextBox();
            this.p_logo = new PictureBox();
            Controls.Add(dw_title);
            Controls.Add(mle_copyright);
            Controls.Add(p_logo);
            this.BackColor = System.Drawing.Color.Silver;
            this.Size = new System.Drawing.Size(389, 351);
            this.Location = new System.Drawing.Point(115, 77);

            // 
            // dw_title
            // 
            dw_title.TabIndex = 0;
            dw_title.Size = new System.Drawing.Size(310, 65);
            dw_title.Location = new System.Drawing.Point(69, 199);

            // 
            // mle_copyright
            // 
            mle_copyright.Multiline = true;
            mle_copyright.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            mle_copyright.BackColor = System.Drawing.Color.Silver;
            mle_copyright.ForeColor = System.Drawing.SystemColors.WindowText;
            mle_copyright.Text = @" Warning: This computer program is protected by copyright law and international treaties.  Unauthorised reproduction or distribution of this program, or any portion of it, may result in severe civil and criminal penalties, and will be prosecuted to the maximum extent possible under law.";
            mle_copyright.TextAlign = HorizontalAlignment.Center;
            mle_copyright.Size = new System.Drawing.Size(377, 64);
            mle_copyright.Location = new System.Drawing.Point(5, 272);

            // 
            // p_logo
            // 
            //p_logo.originalsize = true;
            p_logo.TabStop = false;
            p_logo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            p_logo.Image = global::NZPostOffice.Shared.Properties.Resources.Logo;//new System.Drawing.Bitmap("..\\bitmaps\\logo.bmp");
            p_logo.Size = new System.Drawing.Size(378, 264);
            p_logo.Location = new System.Drawing.Point(3, 4);
            this.ResumeLayout();
        }

        public TextBox mle_copyright;
        public PictureBox p_logo;

    }
}