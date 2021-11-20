namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WVehicleExpiryReport
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
          
            this.BackColor = System.Drawing.SystemColors.Control;
           
            this.Tag = "Vehicle Expiry Report";
            this.Text = "Vehicle Expiry Report";
            this.ControlBox = true;
            // 
            // st_label
            // 
            st_label.Text = "RDRPTVE";
           
            st_label.Tag = "Vehicle expiry report";
            // 
            // cb_getreport
            // 
            // 
            // dw_report
            // 
            dw_report.Tag = "vehicle Expiry Report";
            //dw_report.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_report_constructor);
            this.ResumeLayout();
        }

        #endregion
    }
}