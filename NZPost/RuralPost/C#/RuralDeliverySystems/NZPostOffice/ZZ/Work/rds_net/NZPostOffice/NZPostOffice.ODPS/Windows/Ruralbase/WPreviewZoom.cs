using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using NZPostOffice.Shared;
using NZPostOffice.ODPS.Controls;

namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    public partial class WPreviewZoom : WMaster
    {
        public WPreviewZoom()
        {
            InitializeComponent();

            p_slide.Image = new System.Drawing.Bitmap("..\\bitmaps\\slide.bmp");
            p_guide.Image = new System.Drawing.Bitmap("..\\bitmaps\\guide.bmp");
        }

        public bool i_lDown = false;

        public int i_nPreZoom = 0;

        public override void open()
        {
            int nPercent;
            nPercent = (int)StaticMessage.DoubleParm;
            p_slide.Top = p_guide.Height / 200 * nPercent + p_guide.Location.Y - 7;

            if (p_slide.Top < p_guide.Top - 6)
            {
                p_slide.Top = p_guide.Location.Y - 6;
            }
            st_percent.Text = String.Format("###", (p_slide.Top - p_guide.Top) / p_guide.Height * 200 + 8) + "%";
            StaticMessage.DoubleParm = -(1);
        }

        public virtual void ue_mousemove()
        {
            // long nHeight
            // 
            // nHeight = p_guide.PointerY  ( ) + PixelsToUnits (  6, YPixelsToUnits! )
            // 
            // This.Top  = nHeight
            // 
        }

        public virtual void ue_dragwithin()
        {
            // long nHeight
            // 
            // nHeight = p_guide.PointerY  ( ) + PixelsToUnits (  6, YPixelsToUnits! )
            // 
            // This.Top  = nHeight
            // 
        }

        public virtual void uemovemouse()
        {
            int nHeight;
            if (i_lDown)
            {
                nHeight = p_guide.Top + 12;
                if (nHeight > p_guide.Location.Y - 6 && nHeight < p_guide.Height + p_guide.Location.Y - 6)
                {
                    if (p_slide.Top != nHeight)
                    {
                        p_slide.Top = nHeight;
                        // This.Postevent ( "ue_do_nothing")
                        st_percent.Text = String.Format("###", (p_slide.Top - p_guide.Top) / p_guide.Height * 200 + 8) + "%";
                        //? parent.show();
                    }
                }
            }
        }

        public virtual void ue_ldown()
        {
            i_lDown = true;
        }

        public virtual void ue_lup()
        {
            i_lDown = false;
        }

        public virtual void ue_do_nothing()
        {
            // Parent.Show ( )
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            //CloseWithReturn(parent, -(1));
            StaticMessage.StringParm = "-1";
            this.Close();
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            int nZoom;
            nZoom = Convert.ToInt32(st_percent.Text.Substring(0, st_percent.Text.Length - 1));
            //CloseWithReturn(parent, nZoom);
            StaticMessage.StringParm = nZoom.ToString();
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
            st_percent.Text = String.Format("###", (p_slide.Top - p_guide.Top) / p_guide.Height * 200 + 8) + "%";
        }
    }
}
