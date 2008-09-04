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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.SuspendLayout();
            // 
            // st_label
            // 
            st_label.Visible = true;
            st_label.Text = "w_piece_rate_search";
            st_label.ForeColor = System.Drawing.Color.Black;
            st_label.Location = new System.Drawing.Point(5, 342);
            // 
            // dw_criteria
            // 
           
            dw_criteria.Height = 163;
            dw_criteria.Width = 295;
            dw_criteria.Top = 2;
          
           
            // 
            // dw_results
            // 
            //!dw_results.DataObject = new DReportGenericResults();
            dw_results.Height = 165;
            dw_results.Width = 295;
            dw_results.Top = 170;
            
           
            // 
            // pb_search
            // 
            pb_search.Top = 4;
            // 
            // pb_open
            // 
            pb_open.Top = 171;
            pb_open.Left = 303;
            this.Name = "w_piece_rate_search";
            this.Size = new System.Drawing.Size(378, 388);
            this.ResumeLayout();
        }

        #endregion
    }
}