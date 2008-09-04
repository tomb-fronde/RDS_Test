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
    public class WPreviewZoom : WMaster
    {
        #region Define

        public bool i_ldown = false;

        public int i_nprezoom = 0;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Label st_11;

        public Label st_10;

        public Label st_9;

        public Label st_8;

        public Label st_7;

        public Label st_6;

        public Label st_5;

        public Label st_4;

        public Label st_3;

        public Label st_2;

        public Label st_1;

        public Button cb_cancel;

        public Label st_percent;

        public Button cb_ok;

        public PictureBox p_slide;

        public PictureBox p_guide;

        #endregion

        public WPreviewZoom()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;
            this.Load += new EventHandler(WPreviewZoom_Load);
        }

        #region Form Events

        public  void WPreviewZoom_Load(object sender, EventArgs e)
        {
            int nPercent;
            nPercent = (int)StaticMessage.DoubleParm;
            p_slide.Top = p_guide.Height / 200 * nPercent + p_guide.Top - 7;
            if (p_slide.Top < p_guide.Top - 6)
            {
                p_slide.Top = p_guide.Top - 6;
            }
            st_percent.Text = string.Format("###", (p_slide.Top - p_guide.Top) / p_guide.Height * 200 + 8) + '%';
            StaticMessage.DoubleParm = -(1);
        }
        #endregion

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.st_11 = new Label();
            this.st_10 = new Label();
            this.st_9 = new Label();
            this.st_8 = new Label();
            this.st_7 = new Label();
            this.st_6 = new Label();
            this.st_5 = new Label();
            this.st_4 = new Label();
            this.st_3 = new Label();
            this.st_2 = new Label();
            this.st_1 = new Label();
            this.cb_cancel = new Button();
            this.st_percent = new Label();
            this.cb_ok = new Button();
            this.p_slide = new PictureBox();
            this.p_guide = new PictureBox();
           
            this.Text = "Zoom";
            this.ControlBox = true;
            this.Size = new Size(190, 236);
            this.Location = new Point(147, 66);
            // 
            // st_11
            // 
            st_11.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_11.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_11.ForeColor = System.Drawing.SystemColors.WindowText;
            st_11.TabStop = false;
            st_11.Text = "200%";
            st_11.Size = new Size(36, 18);
            st_11.Location = new Point(63, 194);
            // 
            // st_10
            // 
            st_10.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_10.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_10.ForeColor = System.Drawing.SystemColors.WindowText;
            st_10.TabStop = false;
            st_10.Text = "180%";
            st_10.Height = 18;
            st_10.Width = 36;
            st_10.Top = 176;
            st_10.Left = 63;
            // 
            // st_9
            // 
            st_9.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_9.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_9.ForeColor = System.Drawing.SystemColors.WindowText;
            st_9.TabStop = false;
            st_9.Text = "160%";
            st_9.Height = 18;
            st_9.Width = 36;
            st_9.Top = 158;
            st_9.Left = 63;
            // 
            // st_8
            // 
            st_8.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_8.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_8.ForeColor = System.Drawing.SystemColors.WindowText;
            st_8.TabStop = false;
            st_8.Text = "140%";
            st_8.Height = 18;
            st_8.Width = 36;
            st_8.Top = 140;
            st_8.Left = 63;
            // 
            // st_7
            // 
            st_7.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_7.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_7.ForeColor = System.Drawing.SystemColors.WindowText;
            st_7.TabStop = false;
            st_7.Text = "120%";
            st_7.Height = 18;
            st_7.Width = 36;
            st_7.Top = 122;
            st_7.Left = 63;
            // 
            // st_6
            // 
            st_6.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_6.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_6.ForeColor = System.Drawing.SystemColors.WindowText;
            st_6.TabStop = false;
            st_6.Text = "100%";
            st_6.Height = 18;
            st_6.Width = 36;
            st_6.Top = 104;
            st_6.Left = 63;
            // 
            // st_5
            // 
            st_5.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_5.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_5.ForeColor = System.Drawing.SystemColors.WindowText;
            st_5.TabStop = false;
            st_5.Text = "80%";
            st_5.Width = 36;
            st_5.Top = 86;
            st_5.Left = 63;
            // 
            // st_4
            // 
            st_4.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_4.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_4.ForeColor = System.Drawing.SystemColors.WindowText;
            st_4.TabStop = false;
            st_4.Text = "60%";
            st_4.Height = 18;
            st_4.Width = 36;
            st_4.Top = 68;
            st_4.Left = 63;
            // 
            // st_3
            // 
            st_3.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_3.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_3.ForeColor = System.Drawing.SystemColors.WindowText;
            st_3.TabStop = false;
            st_3.Text = "40%";
            st_3.Height = 18;
            st_3.Width = 36;
            st_3.Top = 50;
            st_3.Left = 63;
            // 
            // st_2
            // 
            st_2.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_2.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_2.ForeColor = System.Drawing.SystemColors.WindowText;
            st_2.TabStop = false;
            st_2.Text = "20%";
            st_2.Height = 18;
            st_2.Width = 36;
            st_2.Top = 32;
            st_2.Left = 63;
            // 
            // st_1
            // 
            st_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_1.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            st_1.TabStop = false;
            st_1.Text = "0%";
            st_1.Height = 18;
            st_1.Width = 36;
            st_1.Top = 14;
            st_1.Left = 63;
            // 
            // cb_cancel
            // 
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.TabIndex = 2;
            cb_cancel.Height = 22;
            cb_cancel.Width = 59;
            cb_cancel.Top = 49;
            cb_cancel.Left = 111;
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            // 
            // st_percent
            // 
            st_percent.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_percent.BackColor = System.Drawing.Color.Silver;
            st_percent.ForeColor = System.Drawing.SystemColors.WindowText;
            st_percent.TabStop = false;
            st_percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_percent.Text = "none";
            st_percent.Visible = false;
            st_percent.Height = 18;
            st_percent.Width = 54;
            st_percent.Top = 83;
            st_percent.Left = 111;
            // 
            // cb_ok
            // 
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&OK";
            cb_ok.TabIndex = 1;
            cb_ok.Height = 22;
            cb_ok.Width = 59;
            cb_ok.Top = 23;
            cb_ok.Left = 111;
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // p_slide
            // 
            p_guide.SizeMode = PictureBoxSizeMode.Normal;
            p_slide.TabStop = false;
            p_slide.Image = global::NZPostOffice.Shared.Properties.Resources.SLIDE;
            p_slide.Height = 12;
            p_slide.Width = 30;
            p_slide.Top = 176;
            p_slide.Left = 14;
            p_slide.DragOver += new DragEventHandler(p_slide_dragwithin);
            // 
            // p_guide
            // 
            p_guide.SizeMode = PictureBoxSizeMode.Normal;
            p_guide.TabStop = false;
            p_guide.Image = global::NZPostOffice.Shared.Properties.Resources.GUIDE;
            p_guide.Height = 183;
            p_guide.Width = 50;
            p_guide.Top = 18;
            p_guide.Left = 14;
            p_guide.Click += new EventHandler(p_guide_clicked);

            Controls.Add(st_11);
            Controls.Add(st_10);
            Controls.Add(st_9);
            Controls.Add(st_8);
            Controls.Add(st_7);
            Controls.Add(st_6);
            Controls.Add(st_5);
            Controls.Add(st_4);
            Controls.Add(st_3);
            Controls.Add(st_2);
            Controls.Add(st_1);
            Controls.Add(cb_cancel);
            Controls.Add(st_percent);
            Controls.Add(cb_ok);
            Controls.Add(p_slide);
            Controls.Add(p_guide);
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
            StaticMessage.ReturnValue = -1;
            this.Close();
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            int nZoom;
            nZoom = int.Parse(st_percent.Text.Substring(0, st_percent.Text.Length - 1));
            StaticMessage.ReturnValue = nZoom;
            this.Close();
        }
     
        public virtual void p_slide_dragwithin(object sender, EventArgs e)
        {
            // long nHeight
            // 
            // nHeight = p_guide.PointerY  ( ) + PixelsToUnits (  6, YPixelsToUnits! )
            // 
            // This.Top  = nHeight
            // 
        }

        public virtual void p_guide_clicked(object sender, EventArgs e)
        {
            int nHeight;
            nHeight = p_guide.Top + 12;
            p_slide.Top = nHeight;
            st_percent.Text = string.Format("###", (p_slide.Top - p_guide.Top) / p_guide.Height * 200 + 8) + "%";
        }
        #endregion

        #region Methods
        public virtual void p_slide_ue_mousemove()
        {
            // long nHeight
            // 
            // nHeight = p_guide.PointerY  ( ) + PixelsToUnits (  6, YPixelsToUnits! )
            // 
            // This.Top  = nHeight
            // 
        }

        public virtual void p_slide_ue_dragwithin()
        {
            // long nHeight
            // 
            // nHeight = p_guide.PointerY  ( ) + PixelsToUnits (  6, YPixelsToUnits! )
            // 
            // This.Top  = nHeight
            // 
        }

        public virtual void p_slide_uemovemouse()
        {
            int nheight;
            if (i_ldown)
            {
                nheight = p_guide.Top + 12;
                if (nheight > p_guide.Top - 6 && nheight < p_guide.Height + p_guide.Top - 6)
                {
                    if (p_slide.Top != nheight)
                    {
                        p_slide.Top = nheight;
                        // 			This.Postevent ( "ue_do_nothing")
                        st_percent.Text = string.Format("###", (p_slide.Top - p_guide.Top) / p_guide.Height * 200 + 8) + "%";
                        this.Show();
                    }
                }
            }
        }

        public virtual void p_slide_ue_ldown()
        {
            i_ldown = true;
        }

        public virtual void p_slide_ue_lup()
        {
            i_ldown = false;
        }

        public virtual void p_slide_ue_do_nothing()
        {
            // Parent.Show ( )
        }
        #endregion
    }
}