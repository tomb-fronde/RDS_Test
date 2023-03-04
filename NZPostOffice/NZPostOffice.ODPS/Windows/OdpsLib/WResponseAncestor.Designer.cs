using System;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    partial class WResponseAncestor
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
            this.SuspendLayout();

            this.Text = "Untitled";
            this.ControlBox = true;
            this.Location = new System.Drawing.Point(14, 10);
            this.Size = new System.Drawing.Size(560, 310);
            this.Icon = global::NZPostOffice.Shared.Properties.Resources.SAFE02;
            this.Load += new EventHandler(Catch_open);
            this.ResumeLayout();

        }
    }
}