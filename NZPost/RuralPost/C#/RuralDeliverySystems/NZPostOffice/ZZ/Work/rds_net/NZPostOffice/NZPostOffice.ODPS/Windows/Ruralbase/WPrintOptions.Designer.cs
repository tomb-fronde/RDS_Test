using System.Windows.Forms;
namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    partial class WPrintOptions
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
            this.Text = "WPrintOptions";

            this.SuspendLayout();
            this.cb_cancel = new Button();
            this.cb_select_printer = new Button();
            this.cb_print = new Button();
            this.dw_options = new NZPostOffice.ODPS.DataControls.Ruralbase.DPrintOptions();
            this.st_printer = new Label();
            Controls.Add(cb_cancel);
            Controls.Add(cb_select_printer);
            Controls.Add(cb_print);
            Controls.Add(dw_options);
            Controls.Add(st_printer);
            this.Text = "Print Options";
            this.ControlBox = true;
            this.Height = 165;
            this.Width = 343;
            this.Top = 150;
            this.Left = 140;
            // 
            // cb_cancel
            // 
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.TabIndex = 4;
            cb_cancel.Height = 22;
            cb_cancel.Width = 97;
            cb_cancel.Top = 70;
            cb_cancel.Left = 223;
//?         cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            // 
            // cb_select_printer
            // 
            cb_select_printer.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            cb_select_printer.Text = "&Select Printer";
            cb_select_printer.TabIndex = 3;
            cb_select_printer.Height = 22;
            cb_select_printer.Width = 97;
            cb_select_printer.Top = 33;
            cb_select_printer.Left = 223;
//?         cb_select_printer.Click += new EventHandler(cb_select_printer_clicked);
            // 
            // cb_print
            // 
            cb_print.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            this.AcceptButton = cb_print;
            cb_print.Text = "&Print";
            cb_print.TabIndex = 1;
            cb_print.Height = 22;
            cb_print.Width = 97;
            cb_print.Top = 6;
            cb_print.Left = 223;
//?         cb_print.Click += new EventHandler(cb_print_clicked);
            // 
            // dw_options
            // 
            // Metex Migrator Warning: property border was not converted
//?         dw_options.border = false;
            // Metex Migrator Warning: Control dw_options must be instance of Cl_"d_print_options" class
            dw_options.TabIndex = 2;
            dw_options.Height = 118;
            dw_options.Width = 222;
            dw_options.Top = 26;
            // 
            // st_printer
            // 
            st_printer.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            // Metex Migrator Warning: color 80269524 was not converted
            // st_printer.BackColor = 80269524;
            st_printer.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_printer.ForeColor = System.Drawing.SystemColors.WindowText;
            st_printer.TabStop = false;
            st_printer.Text = "none";
            st_printer.Height = 18;
            st_printer.Width = 235;
            st_printer.Top = 4;
            st_printer.Left = 5;
            this.ResumeLayout();
        }

        public Button cb_cancel;
        public Button cb_select_printer;
        public Button cb_print;
        public Label st_printer;
        #endregion
    }
}