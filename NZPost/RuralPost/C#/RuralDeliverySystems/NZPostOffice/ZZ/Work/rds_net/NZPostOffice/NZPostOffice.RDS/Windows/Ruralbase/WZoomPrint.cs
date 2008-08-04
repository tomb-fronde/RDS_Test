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
    public class WZoomPrint : WMaster
    {
        #region Define

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Label st_2;

        public Label st_1;

        public TextBox sle_custom;

        public RadioButton rb_custom;

        public Button cb_1;

        public Button cb_ok;

        public RadioButton rb_30;

        public RadioButton rb_65;

        public RadioButton rb_100;

        public RadioButton rb_200;

        #endregion

        public WZoomPrint()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;
        }

        public override void open()
        {
            base.open();
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            Double TestExpr = StaticMessage.DoubleParm;
            if (TestExpr == 200)
            {
                rb_200.Checked = true;
            }
            else if (TestExpr == 100)
            {
                rb_100.Checked = true;
            }
            else if (TestExpr == 65)
            {
                rb_65.Checked = true;
            }
            else if (TestExpr == 30)
            {
                rb_30.Checked = true;
            }
            else
            {
                rb_custom.Checked = true;
            }
            sle_custom.Text = StaticMessage.DoubleParm.ToString();
            StaticMessage.DoubleParm = -(1);
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.st_2 = new Label();
            this.st_1 = new Label();
            this.sle_custom = new TextBox();
            this.rb_custom = new RadioButton();
            this.cb_1 = new Button();
            this.cb_ok = new Button();
            this.rb_30 = new RadioButton();
            this.rb_65 = new RadioButton();
            this.rb_100 = new RadioButton();
            this.rb_200 = new RadioButton();
            Controls.Add(st_2);
            Controls.Add(st_1);
            Controls.Add(sle_custom);
            Controls.Add(rb_custom);
            Controls.Add(cb_1);
            Controls.Add(cb_ok);
            Controls.Add(rb_30);
            Controls.Add(rb_65);
            Controls.Add(rb_100);
            Controls.Add(rb_200);
            this.Text = "Zoom";
            this.ControlBox = true;
            this.Height = 187;
            this.Width = 225;
            this.Top = 66;
            this.Left = 147;
            // 
            // st_2
            // 
            st_2.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_2.BackColor = System.Drawing.Color.Silver;
            st_2.ForeColor = System.Drawing.SystemColors.WindowText;
            st_2.TabStop = false;
            st_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_2.Text = "%";
            st_2.Height = 18;
            st_2.Width = 16;
            st_2.Top = 127;
            st_2.Left = 124;
            // 
            // st_1
            // 
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_1.BackColor = System.Drawing.Color.Silver;
            st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            st_1.TabStop = false;
            st_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_1.Text = "Magnification";
            st_1.Height = 18;
            st_1.Width = 80;
            st_1.Top = 11;
            st_1.Left = 26;
            // 
            // sle_custom
            // 
            sle_custom.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            sle_custom.ForeColor = System.Drawing.SystemColors.WindowText;
            sle_custom.ScrollBars = ScrollBars.None;
            sle_custom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sle_custom.TabIndex = 3;
            sle_custom.Height = 19;
            sle_custom.Width = 33;
            sle_custom.Top = 124;
            sle_custom.Left = 89;
            // 
            // rb_custom
            // 
            rb_custom.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            rb_custom.BackColor = System.Drawing.Color.Silver;
            rb_custom.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_custom.Text = "Custom";
            rb_custom.Height = 18;
            rb_custom.Width = 60;
            rb_custom.Top = 123;
            rb_custom.Left = 25;
            // 
            // cb_1
            // 
            cb_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            this.CancelButton = cb_1;
            cb_1.Text = "&Cancel";
            cb_1.TabIndex = 2;
            cb_1.Height = 22;
            cb_1.Width = 59;
            cb_1.Top = 47;
            cb_1.Left = 150;
            cb_1.Click += new EventHandler(cb_1_clicked);
            // 
            // cb_ok
            // 
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&OK";
            cb_ok.TabIndex = 1;
            cb_ok.Height = 22;
            cb_ok.Width = 59;
            cb_ok.Top = 19;
            cb_ok.Left = 150;
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // rb_30
            // 
            rb_30.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            rb_30.BackColor = System.Drawing.Color.Silver;
            rb_30.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_30.Text = "30%";
            rb_30.Height = 18;
            rb_30.Width = 54;
            rb_30.Top = 99;
            rb_30.Left = 25;
            // 
            // rb_65
            // 
            rb_65.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            rb_65.BackColor = System.Drawing.Color.Silver;
            rb_65.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_65.Text = "65%";
            rb_65.Height = 18;
            rb_65.Width = 54;
            rb_65.Top = 75;
            rb_65.Left = 25;
            // 
            // rb_100
            // 
            rb_100.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            rb_100.BackColor = System.Drawing.Color.Silver;
            rb_100.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_100.Text = "100%";
            rb_100.Height = 18;
            rb_100.Width = 54;
            rb_100.Top = 51;
            rb_100.Left = 25;
            // 
            // rb_200
            // 
            rb_200.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            rb_200.BackColor = System.Drawing.Color.Silver;
            rb_200.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_200.Text = "200%";
            rb_200.Height = 18;
            rb_200.Width = 54;
            rb_200.Top = 27;
            rb_200.Left = 25;
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
        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            StaticMessage.ReturnValue = -1;
            this.Close();
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            int nReturn = 0;
            if (rb_200.Checked)
            {
                nReturn = 200;
            }
            else if (rb_100.Checked)
            {
                nReturn = 100;
            }
            else if (rb_65.Checked)
            {
                nReturn = 65;
            }
            else if (rb_30.Checked)
            {
                nReturn = 30;
            }
            else if (StaticFunctions.IsNumber(sle_custom.Text))
            {
                int.TryParse(sle_custom.Text, out nReturn);
                if (nReturn < 0 || nReturn > 500)
                {
                    Console.Beep();
                    sle_custom.Focus();
                    nReturn = -(1);
                }
            }
            else
            {
                Console.Beep();
                sle_custom.Focus();
            }
            if (nReturn > -(1))
            {
                StaticMessage.ReturnValue = nReturn;
                this.Close();
            }
        }
        #endregion
    }
}
