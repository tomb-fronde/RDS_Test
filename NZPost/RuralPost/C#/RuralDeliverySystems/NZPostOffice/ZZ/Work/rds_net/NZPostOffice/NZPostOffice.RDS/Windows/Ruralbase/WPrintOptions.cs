using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared;
using Metex.Windows;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralbase;
using NZPostOffice.RDS.Entity.Ruralbase;

namespace NZPostOffice.RDS.Windows.Ruralbase
{
    public class WPrintOptions : WMaster
    {
        #region Define

        public DataUserControl i_dwparent;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_cancel;

        public Button cb_select_printer;

        public Button cb_print;

        public DPrintOptions dw_options;

        public Label st_printer;
        #endregion

        public WPrintOptions()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;
        }

        public override void open()
        {
            base.open();
            //  26/04/2002 PBY Added - bypass the security
            this.of_bypass_security(true);
            i_dwparent = (DataUserControl)StaticMessage.PowerObjectParm;
            //? st_printer.Text = i_dwparent.Describe("DataWindow.Printer");
            dw_options.InsertItem<PrintOptions>(dw_options.RowCount);
            StaticMessage.StringParm = "None";
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.cb_cancel = new Button();
            this.cb_select_printer = new Button();
            this.cb_print = new Button();
            this.dw_options = new DPrintOptions();
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
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
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
            cb_select_printer.Click += new EventHandler(cb_select_printer_clicked);
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
            cb_print.Click += new EventHandler(cb_print_clicked);
            // 
            // dw_options
            // 
            dw_options.TabIndex = 2;
            dw_options.Height = 118;
            dw_options.Width = 222;
            dw_options.Top = 26;
            // 
            // st_printer
            // 
            st_printer.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
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

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Events
        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            StaticMessage.StringParm = "None";
            this.Close();
        }

        public virtual void cb_select_printer_clicked(object sender, EventArgs e)
        {
            //? PrintSetup();
            //? st_printer.Text = i_dwparent.Describe("DataWindow.Printer");
        }

        public virtual void cb_print_clicked(object sender, EventArgs e)
        {
            string sReturn = "";
            string sRow;
            dw_options.AcceptText();
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = dw_options.GetItem<PrintOptions>(0).Pagerange;
            if (TestExpr == "A")
            {
                sReturn = "1:99999";
            }
            else if (TestExpr == "C")
            {
                //? sRow = i_dwparent.Describe("DataWindow.FirstRowOnPage");
                //? sReturn = i_dwparent.Describe("Evaluate ( \'Page ( )\', " + sRow + ')');
                sReturn = sReturn + ':' + sReturn;
            }
            else if (TestExpr == "R")
            {
                //? sReturn = String(dw_options.GetItem<PrintOptions>(0).PageFrom) + ':' + String(dw_options.GetItem<PrintOptions>(0).PageTo);
            }
            //? sReturn = sReturn + ';' + String(dw_options.GetItem<PrintOptions>(0).Copys);
            StaticMessage.StringParm = sReturn;
            this.Close();
        }
        #endregion
    }
}
