using NZPostOffice.ODPS.Entity.OdpsInvoice;
namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    partial class DwInvoiceDetailPaymentPrMessage
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
            this.Name = "DwInvoiceDetailPaymentPrMessage";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(InvoiceDetailPaymentPrMessage);
            #region out_message define
            this.out_message = new System.Windows.Forms.TextBox();
            this.out_message.Name = "out_message";
            this.out_message.Location = new System.Drawing.Point(6, 2);
            this.out_message.Size = new System.Drawing.Size(355, 17);
            this.out_message.TabIndex = 0;
            this.out_message.Enabled = false;
            this.out_message.Font = new System.Drawing.Font("Times New Roman", 10);
            this.out_message.BackColor = System.Drawing.SystemColors.Window;
            this.out_message.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.out_message.MaxLength = 255;
            this.out_message.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OutMessage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(out_message);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.TextBox out_message;
    }
}
