using NZPostOffice.RDS.DataControls.Ruralrpt;
namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WCustomerDelSequence
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
            //!dw_criteria.DataObject = new DCustSequenceSearch();
            this.Text = "Contract Customer Sequence";
            this.Height = 280;
            this.Name = "w_customer_del_sequence";
            // 
            // st_label
            // 
            st_label.Text = "RDRPTCS1";
            st_label.Height = 16;
            st_label.Top = 230;
            st_label.Left = 10;
            // 
            // dw_criteria
            // 
            dw_criteria.Height = 220;
            //!dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            //((System.Windows.Forms.CheckBox)(dw_criteria.GetControlByName("summaryreport"))).CheckedChanged += new System.EventHandler(dw_criteria_CheckedChanged);
            //((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("freq_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);

            // 
            // dw_results
            // 
            dw_results.Height = 130;
            dw_results.Top = 320;
            dw_results.Visible = false;
            //!dw_results.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
             
            // pb_search
            // 
            pb_search.Visible = false;
            pb_search.Tag = "ComponentName=Disabled;";
            // 
            // pb_open
            // 
            pb_open.Top = 172;
            pb_open.Left = 303;
            this.ResumeLayout();
        }
        #endregion
    }
}