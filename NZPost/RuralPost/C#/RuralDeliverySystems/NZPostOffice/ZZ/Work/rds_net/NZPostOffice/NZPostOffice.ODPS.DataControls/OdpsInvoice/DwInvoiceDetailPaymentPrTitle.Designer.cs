namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    partial class DwInvoiceDetailPaymentPrTitle
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DwInvoiceDetailPaymentPrTitle";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsInvoice.InvoiceDetailPaymentPrTitle);
            #region t_1 define
            this.t_1 = new System.Windows.Forms.Label();
            this.t_1.Name = "t_1";
            this.t_1.Location = new System.Drawing.Point(0, 1);
            this.t_1.Size = new System.Drawing.Size(640, 23);
            this.t_1.TabIndex = 0;
            this.t_1.Font = new System.Drawing.Font("Times New Roman", 10);
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.t_1.BackColor = System.Drawing.Color.Gray;
            this.t_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.t_1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.t_1.Text = "PIECERATE SUMMARY";
            #endregion
            this.Controls.Add(t_1);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.Label t_1;
    }
}
