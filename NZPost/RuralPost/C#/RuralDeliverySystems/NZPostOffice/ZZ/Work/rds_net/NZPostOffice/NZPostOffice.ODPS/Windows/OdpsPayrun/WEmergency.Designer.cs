using NZPostOffice.ODPS.DataControls.OdpsPayrun;
using System.Windows.Forms;
using System;
using NZPostOffice.ODPS.Controls;
namespace NZPostOffice.ODPS.Windows.OdpsPayrun
{
    partial class WEmergency
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
            this.Text = "WEmergency";

            this.SuspendLayout();
            this.sle_1 = new TextBox();
            this.sle_2 = new TextBox();
            this.st_1 = new Label();
            this.st_2 = new Label();
            this.cb_1 = new Button();
            this.cb_2 = new Button();
            
            dw_1 = new URdsDw();
            Controls.Add(dw_1);
            Controls.Add(sle_1);
            Controls.Add(sle_2);
            Controls.Add(st_1);
            Controls.Add(st_2);
            Controls.Add(cb_1);
            Controls.Add(cb_2);
            this.Text = "QUICK AND DIRTY";
            this.ControlBox = true;
            this.Size = new System.Drawing.Size(468, 369);
          
            // 
            // dw_1
            // 
            dw_1.DataObject  = new DwEmergency();
            dw_1.TabIndex = 5;
            dw_1.Location = new System.Drawing.Point(3, 35);
            dw_1.Size = new System.Drawing.Size(457, 300);
            
            // 
            // sle_1
            // 
            sle_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            sle_1.BackColor = System.Drawing.Color.White;
            sle_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sle_1.TabIndex = 1;
            sle_1.Location = new System.Drawing.Point(94, 7);
            sle_1.Size = new System.Drawing.Size(54, 23);
            
            // 
            // sle_2
            // 
            sle_2.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            sle_2.BackColor = System.Drawing.Color.White;
            sle_2.TabIndex = 2;
            sle_2.Location = new System.Drawing.Point(235, 7);
            sle_2.Size = new System.Drawing.Size(54, 23);
         
            // 
            // st_1
            // 
            st_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            st_1.TabStop = false;
            st_1.Text = "End date";
            st_1.Location = new System.Drawing.Point(16, 11);
            st_1.Size = new System.Drawing.Size(54, 19);
          
            // 
            // st_2
            // 
            st_2.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            st_2.TabStop = false;
            st_2.Text = "Contract";
            st_2.Location = new System.Drawing.Point(178, 11);
            st_2.Size = new System.Drawing.Size(54, 19);
        
            // 
            // cb_1
            // 
            cb_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_1.Text = "Retrieve";
            cb_1.TabIndex = 3;
            cb_1.Location = new System.Drawing.Point(336, 3);
            cb_1.Size = new System.Drawing.Size(56, 27);
            cb_1.Click += new EventHandler(cb_1_clicked);
          
            // 
            // cb_2
            // 
            cb_2.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_2.Text = "Save";
            cb_2.TabIndex = 4;
            cb_2.Location = new System.Drawing.Point(398, 3);
            cb_2.Size = new System.Drawing.Size(54, 27);
            cb_2.Click += new EventHandler(cb_2_clicked);
            this.ResumeLayout();
        }

        public URdsDw dw_1;// DwEmergency dw_1;

        public TextBox sle_1;

        public TextBox sle_2;

        public Label st_1;

        public Label st_2;

        public Button cb_1;

        public Button cb_2;

    }
}