using Metex.Windows;
using System.Windows.Forms;
using NZPostOffice.ODPS.DataControls.OdpsInvoice;
using System;
using NZPostOffice.ODPS.Controls;
namespace NZPostOffice.ODPS.Windows.OdpsInvoice
{
    partial class WInvoiceSearch
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Invoice";
            this.Size = new System.Drawing.Size(400, 360);
            this.SuspendLayout();
            this.st_1 = new Label();
            this.messagearea = new Label();
            this.cb_export = new Button();

            Controls.Add(st_1);
            Controls.Add(messagearea);
            Controls.Add(cb_export);

            // 
            // dw_search
            // 
            dw_search.DataObject = new DwInvoiceSearch();
            dw_search.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_search.Size = new System.Drawing.Size(302, 128);
            dw_search.Location=new System.Drawing.Point(3,8);
            //? dw_search.ItemChanged += new System.Data.DataColumnChangeEventHandler(dw_search_itemchanged);
           
            // 
            // cb_search
            // 
            cb_search.Left = 318;

            // 
            // cb_open
            // 
            cb_open.Location = new System.Drawing.Point(320, 144);
            // 
            // dw_results
            // 

            dw_results.DataObject = new DwInvoiceSearchResults();
            dw_results.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_results.Size = new System.Drawing.Size(302, 161);
            dw_results.Location = new System.Drawing.Point(3, 144);
            dw_results.DoubleClick += new EventHandler(dw_results_doubleclicked);
          
            // 
            // cb_cancel
            // 
            cb_cancel.Location = new System.Drawing.Point(331, 140);
            cb_cancel.Visible = false;
            // 
            // st_1
            // 
            st_1.TabStop = false;
            st_1.Text = "w_invoice_search";
            st_1.BackColor = System.Drawing.SystemColors.Control;
            st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            st_1.Font = new System.Drawing.Font("Arial", 7, System.Drawing.FontStyle.Regular);
            st_1.Location = new System.Drawing.Point(8, 312);
            st_1.Size = new System.Drawing.Size(101, 14);
           
            // 
            // messagearea
            // 
            //? messagearea.TabStop = false;
            messagearea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            messagearea.BackColor = System.Drawing.SystemColors.Control;
            messagearea.ForeColor = System.Drawing.SystemColors.WindowText;
            messagearea.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            messagearea.Location = new System.Drawing.Point(118, 311);
            messagearea.Size = new System.Drawing.Size(192, 14);
           
            // 
            // cb_export
            // 
            cb_export.Text = "Export";
            cb_export.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_export.TabIndex = 6;
            cb_export.Location = new System.Drawing.Point(320, 176);
            cb_export.Size = new System.Drawing.Size(61, 23);
            cb_export.Click += new EventHandler(cb_export_clicked);
            this.ResumeLayout();
        }

        public URdsDw ids_invoice;
        public URdsDw ids_detailkm;
        public URdsDw ids_detailcp;
        public URdsDw ids_detailxp;
        public URdsDw ids_detailpp;
        public URdsDw ids_payment_details;
        public URdsDw ids_payment_pr;
        public URdsDw ids_payment_ded;
        public Label st_1;
        public Label messagearea;
        public Button cb_export;

    }
}