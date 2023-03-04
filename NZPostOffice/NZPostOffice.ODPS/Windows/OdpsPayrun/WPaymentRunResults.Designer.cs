using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.DataControls.OdpsPayrun;
using NZPostOffice.ODPS.Controls;
using System;
namespace NZPostOffice.ODPS.Windows.OdpsPayrun
{
    // TJB  RPCR_143  Sep-2019
    // Removed cb_print button and associated references

    partial class WPaymentRunResults
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.cb_accept = new Button();
            this.cb_reject = new Button();
            this.st_processingtime = new Label();
            this.cb_details = new Button();
            this.cb_deduct = new Button();
            dw_1 = new URdsDw();
            dw_2 = new URdsDw();
            dw_negative = new URdsDw();

            //!this.dw_2.DataObject = new DwAcceptRejectMainrundetailGrid();
            //!this.dw_1.DataObject = new DwAcceptRejectMainrunGrid();
            //!this.dw_negative.DataObject = new DwPaymentRunNegativepay();
            Controls.Add(cb_accept);
            Controls.Add(cb_reject);
            Controls.Add(st_processingtime);
            Controls.Add(cb_details);
            Controls.Add(cb_deduct);
            Controls.Add(dw_2);
            Controls.Add(dw_1);
            Controls.Add(dw_negative);
            this.Text = "Do You Accept?";
            this.Size = new System.Drawing.Size(603, 376);
            this.ControlBox = false;

            this.MinimizeBox = false;
            this.MinimizeBox = false;

            // 
            // cb_accept
            // 
            cb_accept.Text = "&Accept";
            cb_accept.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
            cb_accept.TabIndex = 7;
            cb_accept.Size = new System.Drawing.Size(62, 23);
            cb_accept.Location = new System.Drawing.Point(215, 320);
            cb_accept.Click += new EventHandler(cb_accept_clicked);

            // 
            // cb_reject
            // 
            cb_reject.Text = "&Reject";
            cb_reject.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
            cb_reject.TabIndex = 4;
            cb_reject.Size = new System.Drawing.Size(62, 23);
            cb_reject.Location = new System.Drawing.Point(281, 320);
            cb_reject.Click += new EventHandler(cb_reject_clicked);

            // 
            // st_processingtime
            // 
            st_processingtime.TabStop = false;
            st_processingtime.Text = "sadsdsdsds";
            st_processingtime.Font = new System.Drawing.Font("Arial Narrow", 8, System.Drawing.FontStyle.Regular);
            st_processingtime.Size = new System.Drawing.Size(203, 32);
            st_processingtime.Location = new System.Drawing.Point(5, 313);

            // 
            // cb_details
            // 
            cb_details.Text = "&Details";
            cb_details.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
            cb_details.TabIndex = 3;
            cb_details.Location = new System.Drawing.Point(450, 320);
            cb_details.Size = new System.Drawing.Size(75, 23);
            cb_details.Click += new EventHandler(cb_details_clicked);

            // 
            // cb_deduct
            // 
            cb_deduct.Text = "&Not Deducted...";
            cb_deduct.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular);
            cb_deduct.TabIndex = 6;
            cb_deduct.Location = new System.Drawing.Point(350, 320);
            cb_deduct.Size = new System.Drawing.Size(107, 23);
            cb_deduct.Visible = false;
            //cb_deduct.Click += new EventHandler(cb_deduct_clicked);

            // 
            // dw_2
            // 
            dw_2.TabIndex = 1;
            dw_2.Location = new System.Drawing.Point(3, 5);
            dw_2.Size = new System.Drawing.Size(588, 303);
            dw_2.Visible = false;

            // 
            // dw_1
            // 
            //?dw_1.HorizontalScroll.Visible = true;
            dw_1.TabIndex = 2;
            dw_1.Location = new System.Drawing.Point(5, 5);
            dw_1.Size = new System.Drawing.Size(588, 303);
            dw_1.DoubleClick += new EventHandler(dw_1_doubleclicked);

            // 
            // dw_negative
            // 
            //!dw_negative.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_negative.TabIndex = 7;
            dw_negative.Location = new System.Drawing.Point(87, 319);
            dw_negative.Size = new System.Drawing.Size(108, 90);
            dw_negative.Visible = false;
            this.ResumeLayout();
        }

        private Button cb_accept;

        private Button cb_reject;

        private Label st_processingtime;

        private Button cb_details;

        private Button cb_deduct;

        private URdsDw dw_2;// UDw dw_2;

        private URdsDw dw_1;// UDw dw_1;

        private URdsDw dw_negative;// DwPaymentRunNegativepay dw_negative;
    }
}