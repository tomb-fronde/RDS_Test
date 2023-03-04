using System.Windows.Forms;
namespace NZPostOffice.ODPS.Windows.OdpsPayrun
{
    partial class WPots
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.SuspendLayout();
            this.sle_date = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.cb_import = new Button();
            this.st_date = new Label();
            Controls.Add(sle_date);
            Controls.Add(cb_import);
            Controls.Add(st_date);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimizeBox = true;
            this.Tag = "POTS import";
            this.Text = "POTS import";
            this.ControlBox = true;
            this.Location = new System.Drawing.Point(231, 121);
            this.Size = new System.Drawing.Size(254, 122);
            this.Closing += new System.ComponentModel.CancelEventHandler(close);

            // 
            // sle_date
            // 
            sle_date.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            sle_date.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_date.Mask = "00/00/0000";
           // sle_date.PromptChar = '0';
            sle_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            sle_date.TabIndex = 1;
            sle_date.Location = new System.Drawing.Point(150, 21);
            sle_date.Size = new System.Drawing.Size(68, 35);
            //this.sle_date.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;

            // 
            // cb_import
            // 
            cb_import.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);
            this.AcceptButton = cb_import;
            cb_import.Text = "Import";
            cb_import.TabIndex = 2;
            cb_import.Location = new System.Drawing.Point(85, 56);
            cb_import.Size = new System.Drawing.Size(69, 27);
            this.cb_import.Click += new System.EventHandler(cb_import_clicked);

            // 
            // st_date
            // 
            st_date.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);
            st_date.ForeColor = System.Drawing.SystemColors.WindowText;
            st_date.TabStop = false;
            st_date.Text = "Date of POTS entry";
            st_date.Location = new System.Drawing.Point(25, 24);
            st_date.Size = new System.Drawing.Size(114, 19);
            this.Icon = global::NZPostOffice.Shared.Properties.Resources.SAFE02;
            this.MaximizeBox = false;
            this.ResumeLayout();
        }

        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox sle_date;
        private Button cb_import;
        private Label st_date;

    }
}