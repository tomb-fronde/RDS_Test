using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralrpt;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WUnoccupiedSearch
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
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.SystemColors.Control; 
            this.Height = 335;
            this.Name = "w_unoccupied_search";
            // 
            // st_label
            // 
            st_label.Text = "RDRPTUOC";
            st_label.Top = 291;
            st_label.Left = 5;
            // 
            // dw_criteria
            // 
            dw_criteria.DataObject = new DUnoccupiedCriteria();
            dw_criteria.Height = 83;
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            //((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);

            // 
            // dw_results
            // 
            dw_results.Top = 93;
            dw_results.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            //dw_results.Constructor += new UserEventDelegate(dw_results_constructor);
            // 
            // pb_search
            // 
            // 
            // pb_open
            // 
            pb_open.Top = 93;
            this.ResumeLayout();
        }

        #endregion
    }
}