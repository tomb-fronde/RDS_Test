using NZPostOffice.RDS.DataControls.Ruralrpt;
using Metex.Windows;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WPieceRateSearch
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
            // dw_criteria
            // 
            this.dw_criteria.Location = new System.Drawing.Point(3, 2);
            this.dw_criteria.Size = new System.Drawing.Size(295, 163);
            // 
            // dw_results
            // 
            this.dw_results.Location = new System.Drawing.Point(3, 170);
            this.dw_results.Size = new System.Drawing.Size(295, 165);
            this.dw_results.Click += new System.EventHandler(this.dw_results_Click);
            // 
            // pb_search
            // 
            this.pb_search.Location = new System.Drawing.Point(302, 4);
            // 
            // pb_open
            // 
            this.pb_open.Location = new System.Drawing.Point(303, 171);
            // 
            // st_label
            // 
            this.st_label.ForeColor = System.Drawing.Color.Black;
            this.st_label.Location = new System.Drawing.Point(5, 342);
            this.st_label.Text = "WPieceRateSearch";
            // 
            // WPieceRateSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 356);
            this.Name = "WPieceRateSearch";
            this.Controls.SetChildIndex(this.pb_open, 0);
            this.Controls.SetChildIndex(this.pb_search, 0);
            this.Controls.SetChildIndex(this.dw_results, 0);
            this.Controls.SetChildIndex(this.dw_criteria, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}