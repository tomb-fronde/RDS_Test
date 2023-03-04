using Metex.Windows;
using System.Windows.Forms;
using System;
using NZPostOffice.ODPS.Controls;
namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    partial class WQuickSelect
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
            this.Text = "WQuickSelect";
            
            dw_search = new URdsDw();

            this.SuspendLayout();
            this.cb_cancel = new Button();
            this.cb_select = new Button();
            Controls.Add(cb_cancel);
            Controls.Add(cb_select);
            Controls.Add(dw_search);
            this.Text = "Query Mode";
            this.ControlBox = true;
            this.Height = 270;
            this.Width = 340;
            this.Top = 66;
            this.Left = 147;
            // 
            // cb_cancel
            // 
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.TabIndex = 3;
            cb_cancel.Height = 23;
            cb_cancel.Width = 59;
            cb_cancel.Left = 166;
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            // 
            // cb_select
            // 
            cb_select.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            this.AcceptButton = cb_select;
            cb_select.Text = "&Select";
            cb_select.TabIndex = 2;
            cb_select.Height = 23;
            cb_select.Width = 60;
            cb_select.Top = 215;
            cb_select.Left = 98;
            cb_select.Click += new EventHandler(cb_select_clicked);
            // 
            // dw_search
            // 
//?            dw_search.vscrollbar = true;
//?            dw_search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_search.TabIndex = 1;
            dw_search.Height = 206;
            dw_search.Width = 328;
            dw_search.Top = 4;
            dw_search.Left = 3;
            dw_search.DoubleClick += new EventHandler(dw_search_doubleclicked);
            dw_search.Click += new EventHandler(dw_search_clicked);
            dw_search.RowFocusChanged += new EventHandler(dw_search_rowfocuschanged);
//?            dw_search.SqlPreview += new SqlEventHandler(dw_search_sqlpreview);
            this.ResumeLayout();
        }

        public URdsDw idwCurrent;// DataUserControl idwCurrent;
        public Button cb_cancel;
        public Button cb_select;
        public URdsDw dw_search;// DataUserControlContainer dw_search;
        #endregion
    }
}