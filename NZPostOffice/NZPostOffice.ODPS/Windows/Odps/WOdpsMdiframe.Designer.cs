using System.Windows.Forms;
namespace NZPostOffice.ODPS.Controls
{
    partial class WOdpsMdiframe
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
            this.SuspendLayout();
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();

            this.toolStripStatusLabel1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.AutoToolTip = true;
            this.toolStripStatusLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel1.DoubleClickEnabled = true;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeftAutoMirrorImage = true;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(this.ClientSize.Width, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            //
            //statusStrip
            //
            statusStrip = new StatusStrip();
            statusStrip.Items.Add(toolStripStatusLabel1);

            this.Controls.Add(statusStrip);
            this.IsMdiContainer = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Text = "Owner-Driver Payment System";
            this.Icon = global::NZPostOffice.Shared.Properties.Resources.SAFE02;
            this.Location = new System.Drawing.Point(221, 176);
            this.Size = new System.Drawing.Size(583, 413);
            this.Resize += new System.EventHandler(WOdpsMdiframe_Resize);
            this.ResumeLayout();
        }

        void WOdpsMdiframe_Resize(object sender, System.EventArgs e)
        {
            toolStripStatusLabel1.Width = this.ClientSize.Width - 20;
        }

        public StatusStrip statusStrip;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

        #endregion
    }
}