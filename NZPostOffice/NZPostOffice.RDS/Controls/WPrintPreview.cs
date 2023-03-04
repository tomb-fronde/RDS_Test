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
using NZPostOffice.RDS.Struct;
using NZPostOffice.RDS.Windows.Ruralbase;
namespace NZPostOffice.RDS.Controls
{
    public partial class WPrintPreview : WResponse
    {
        public bool bcontract;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public PictureBox p_title;

        public TextBox sle_title;

        public Button pb_prior_page;

        public Button pb_nextpage;

        public PictureBox p_date;

        public PictureBox p_pageno;

        public Button pb_exit;

        public Button pb_print;

        public Button pb_zoom;

        public DataUserControl dw_generic;

        public WPrintPreview()
        {
            this.InitializeComponent();
        }

        public override void open()
        {
            base.open();
            int nWidth;
            int nCurrentColumn;
            int nLoop;
            int nColCount;
            int nTabPos;
            int nStart = 1;
            int nNewPos;
            string cObjects;
            string cObjHolder;
            StPrintPreview stParm = new StPrintPreview();
            stParm = (StPrintPreview)StaticMessage.PowerObjectParm;
            /*? dw_generic.dataobject = stParm.dwDataObject + "_print";
             if (StaticFunctions.f_nempty (Convert.ToInt32(dw_generic.describe("datawindow.column.count")))) 
             {
                 //?dw_generic.dataobject = stParm.dwDataObject;
             }
             if (IsValid(StaticVariables.gnv_app.of_get_parameters().windowparm))
             {
                 if (dw_generic.dataobject == "d_contract_customers" && ClassName(StaticVariables.gnv_app.of_get_parameters().windowparm) == "w_contract") {
                     dw_generic.Modify("DataWindow.Footer.Height=300");
                     bcontract = true;
                 }
             }
             dw_generic.settransobject(StaticVariables.sqlca);
             dw_generic.insertrow(0);
             dw_generic.Modify("datawindow.header.height=" + Metex.Common.Convert.ToInt32(dw_generic.Describe("datawindow.header.height").ToString() + PixelsToUnits(40, ypixelstounits)));
             cObjects = dw_generic.Describe("datawindow.objects");
             nTabPos = Pos(cObjects, '~', nStart);
             while (nTabPos > 0) {
                 cObjHolder =  TextUtil.Mid (cObjects, nStart, nTabPos - nStart);
                 if (Lower(dw_generic.Describe(cObjHolder + ".Band")) == "header") {
                     nNewPos = Metex.Common.Convert.ToInt32(dw_generic.describe(cObjHolder + ".y")) + PixelsToUnits(40, ypixelstounits);
                     dw_generic.modify(cObjHolder + ".y=" + nNewPos).ToString();
                 }
                 nStart = nTabPos + 1;
                 nTabPos = Pos(cObjects, '~', nStart);
             }
             cObjHolder =  TextUtil.Mid (cObjects, nStart,  cObjects).Len();
             if (Lower(dw_generic.describe(cObjHolder + ".Band")) == "header") {
                 nNewPos = Metex.Common.Convert.ToInt32(dw_generic.describe(cObjHolder + ".y")) + PixelsToUnits(40, ypixelstounits);
                 dw_generic.modify(cObjHolder + ".y=" + nNewPos).ToString();
             }
             dw_generic.modify(@"create compute ( band=header color=""0"" alignment=""0"" border=""0"" x=""14"" y=""12"" height=""57"" width=""550"" format=""dd mmm yyyy hh:mm:ss"" expression=""today ( )"" name=comp_datetime  font.face=""MS Sans Serif"" font.height=""-8"" font.weight=""400"" font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"")");
             dw_generic.modify(@"create text ( band=header color=""0"" alignment=""2"" border=""0"" x=""14"" y=""12"" height=""65"" width=""3223"" text="""" name=st_title  font.face=""MS Sans Serif"" font.height=""-10"" font.weight=""700"" font.family=""2"" font.pitch=""2"" font.charset=""0"" font.underline=""1"" background.mode=""1""  height.autosize=yes background.color=""16777215"")");
             dw_generic.modify(@"create compute ( band=header color=""0"" alignment=""1"" border=""0"" x=""2789"" y=""12"" height=""57"" width=""449"" format=""[GENERAL]"" expression=""string ( pagecount ( ))"" name=comp_pageno  font.face=""MS Sans Serif"" font.height=""-8"" font.weight=""400"" font.family=""2"" font.pitch=""2"" font.charset=""0"" background.mode=""2"" background.color=""16777215"")");
             dw_generic.modify("comp_datetime.visible=0");
             dw_generic.modify("comp_pageno.visible=0");
             // dw_generic.modify ( 'st_title.visible=0')
             dw_generic.modify("comp_pageno.expression=\" " + "\'Page \' + string ( page ( )) + \' of \' + string ( pagecount ( ))" + '\"');
             dw_generic.modify("comp_datetime.expression=\"" + Today(ToString(), "dd/mm/yyyy ") + Now(ToString(), "hh:mm:ss") + '\"');
             nColCount = Metex.Common.Convert.ToInt32(dw_generic.describe("datawindow.column.count"));
             dw_generic.modify("datawindow.readonly=Yes");
             for (nLoop = 1; nLoop <= nColCount; nLoop++) {
                 if (dw_generic.describe('#' + nLoop.ToString() + ".border") == '5' || dw_generic.describe('#' + nLoop.ToString() + ".border") == '6') {
                     dw_generic.modify('#' + nLoop.ToString() + ".border=2");
                 }
             }
             stParm.dwDataWindow.ShareData(dw_generic);
             dw_generic.modify("datawindow.print.preview=yes");
             dw_generic.modify("datawindow.print.preview.rulers=yes");
             dw_generic.modify("st_privacy.visible = 1");*/
            if (bcontract)
            {
                wf_set_od_list();
            }
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.p_title = new PictureBox();
            this.sle_title = new TextBox();
            this.pb_prior_page = new Button();
            this.pb_nextpage = new Button();
            this.p_date = new PictureBox();
            this.p_pageno = new PictureBox();
            this.pb_exit = new Button();
            this.pb_print = new Button();
            this.pb_zoom = new Button();
            this.dw_generic = new DataUserControl();
            Controls.Add(p_title);
            Controls.Add(sle_title);
            Controls.Add(pb_prior_page);
            Controls.Add(pb_nextpage);
            Controls.Add(p_date);
            Controls.Add(p_pageno);
            Controls.Add(pb_exit);
            Controls.Add(pb_print);
            Controls.Add(pb_zoom);
            Controls.Add(dw_generic);
            this.Text = "Print Preview";
            this.ControlBox = true;
            this.Top = 86;
            this.Size = new Size(607, 353);
            // 
            // p_title
            // 
            p_title.TabStop = false;
            //p_title.Image = new System.Drawing.Bitmap("..\\bitmaps\\titleup.bmp");
            p_title.Image = global::NZPostOffice.Shared.Properties.Resources.TITLEUP;
            p_title.Location = new Point(220, 299);
            p_title.Size = new Size(22, 21);
            p_title.Click += new EventHandler(p_title_clicked);
            // 
            // sle_title
            // 
            sle_title.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            sle_title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            sle_title.Enabled = false;
            sle_title.TabIndex = 8;
            sle_title.Location = new Point(254, 299);
            sle_title.Size = new Size(304, 21);
            sle_title.TextChanged += new EventHandler(sle_title_modified);
            // 
            // pb_prior_page
            // 
            pb_prior_page.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            //pb_prior_page.Image = new System.Drawing.Bitmap("..\\bitmaps\\priorpge.bmp");
            pb_prior_page.Image = global::NZPostOffice.Shared.Properties.Resources.PRIORPGE;
            pb_prior_page.TabIndex = 5;
            pb_prior_page.Height = 21;
            pb_prior_page.Width = 22;
            pb_prior_page.Top = 299;
            pb_prior_page.Left = 130;
           
            pb_prior_page.Click += new EventHandler(pb_prior_page_clicked);
            // 
            // pb_nextpage
            // 
            pb_nextpage.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            pb_nextpage.Image = global::NZPostOffice.Shared.Properties.Resources.NEXTPAGE;// new System.Drawing.Bitmap("..\\bitmaps\\nextpage.bmp");
            pb_nextpage.TabIndex = 4;
            pb_nextpage.Height = 21;
            pb_nextpage.Width = 22;
            pb_nextpage.Top = 299;
            pb_nextpage.Left = 103;
            pb_nextpage.Click += new EventHandler(pb_nextpage_clicked);
            // 
            // p_date
            // 

            //? p_date.originalsize = true;
            p_date.TabStop = false;
            p_date.Image = global::NZPostOffice.Shared.Properties.Resources.DATEUP;// new System.Drawing.Bitmap("..\\bitmaps\\dateup.bmp");
            p_date.TabIndex = 7;
            p_date.Height = 21;
            p_date.Width = 22;
            p_date.Top = 299;
            p_date.Left = 194;
            p_date.Click += new EventHandler(p_date_clicked);
            // 
            // p_pageno
            // 

            //?  p_pageno.originalsize = true;
            p_pageno.TabStop = false;
            p_pageno.Image = global::NZPostOffice.Shared.Properties.Resources.PGEUP;// new System.Drawing.Bitmap("..\\bitmaps\\pgeup.bmp");
            p_pageno.TabIndex = 6;
            p_pageno.Height = 21;
            p_pageno.Width = 22;
            p_pageno.Top = 299;
            p_pageno.Left = 168;
            p_pageno.Click += new EventHandler(p_pageno_clicked);
            // 
            // pb_exit
            // 
            pb_exit.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            this.CancelButton = pb_exit;
            pb_exit.Image = global::NZPostOffice.Shared.Properties.Resources.EXIT1;// new System.Drawing.Bitmap("..\\bitmaps\\exit1.bmp");
            pb_exit.TabIndex = 3;
            pb_exit.Height = 21;
            pb_exit.Width = 22;
            pb_exit.Top = 299;
            pb_exit.Left = 64;
            pb_exit.Click += new EventHandler(pb_exit_clicked);
            // 
            // pb_print
            // 
            pb_print.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            pb_print.Image = global::NZPostOffice.Shared.Properties.Resources.PRINT;// new System.Drawing.Bitmap("..\\bitmaps\\print.bmp");
            pb_print.TabIndex = 2;
            pb_print.Height = 21;
            pb_print.Width = 22;
            pb_print.Top = 299;
            pb_print.Left = 38;
            pb_print.Click += new EventHandler(pb_print_clicked);
            // 
            // pb_zoom
            // 
            pb_zoom.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            //?pb_zoom.Image =  new System.Drawing.Bitmap("..\\bitmaps\\zoom.bmp");
            pb_zoom.TabIndex = 1;
            pb_zoom.Height = 21;
            pb_zoom.Width = 22;
            pb_zoom.Top = 299;
            pb_zoom.Left = 12;
            pb_zoom.Click += new EventHandler(pb_zoom_clicked);
            // 
            // dw_generic
            // 
            dw_generic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_generic.Height = 291;
            dw_generic.Width = 589;
            dw_generic.Top = 4;
            dw_generic.Left = 5;
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

        public virtual int wf_set_od_list()
        {
            // dw_generic.modify("st_title.visible=1");
            dw_generic.GetControlByName("st_title").Visible = true;
            //?  dw_generic.modify("st_title.text=\'" + StaticVariables.gnv_app.of_get_parameters().windowparm.Title + '\'');
            // dw_generic.modify("comp_pageno.visible=1");
            dw_generic.GetControlByName("comp_pageno").Visible = true;
            //  dw_generic.modify("comp_datetime.visible=1");
            dw_generic.GetControlByName("comp_datetime").Visible = true;
            return 1;
        }

        public virtual void p_title_clicked(object sender, EventArgs e)
        {
            string ctemp;
            if (p_title.Image.ToString() == "..\\bitmaps\\titleup.bmp")
            {
                p_title.Image = new System.Drawing.Bitmap("..\\bitmaps\\titledn.bmp");
                // dw_generic.Modify("st_title.visible=1");
                dw_generic.GetControlByName("st_title").Visible = true;
                sle_title.Enabled = true;
            }
            else
            {
                p_title.Image = new System.Drawing.Bitmap("..\\bitmaps\\titleup.bmp");
                //dw_generic.Modify("st_title.visible=0");
                dw_generic.GetControlByName("st_title").Visible = false;
                sle_title.Enabled = false;
            }
        }

        public virtual void sle_title_modified(object sender, EventArgs e)
        {
            dw_generic.GetControlByName("st_title").Text = "\'" + sle_title.Text + '\'';
        }

        public virtual void pb_prior_page_clicked(object sender, EventArgs e)
        {
            //?dw_generic.ScrollPriorPage();
        }

        public virtual void pb_nextpage_clicked(object sender, EventArgs e)
        {
            //? dw_generic.ScrollNextPage();
        }

        public virtual void p_date_clicked(object sender, EventArgs e)
        {
            string ctemp;
            if (p_date.Image.ToString() == "..\\bitmaps\\dateup.bmp")
            {
                p_date.Image = new System.Drawing.Bitmap("..\\bitmaps\\datedn.bmp");
                //dw_generic.Modify("comp_datetime.visible=1");
                dw_generic.GetControlByName("comp_datetime").Visible = true;
            }
            else
            {
                p_date.Image = new System.Drawing.Bitmap("..\\bitmaps\\dateup.bmp");
                // dw_generic.Modify("comp_datetime.visible=0");
                dw_generic.GetControlByName("comp_datetime").Visible = false;
            }
        }

        public virtual void p_pageno_clicked(object sender, EventArgs e)
        {
            if (p_pageno.Image.ToString() == "..\\bitmaps\\pgeup.bmp")
            {
                p_pageno.Image = new System.Drawing.Bitmap("..\\bitmaps\\pgedn.bmp");
                //dw_generic.Modify("comp_pageno.visible=1");
                dw_generic.GetControlByName("comp_pageno").Visible = true;
            }
            else
            {
                p_pageno.Image = new System.Drawing.Bitmap("..\\bitmaps\\pgeup.bmp");
                // dw_generic.Modify("comp_pageno.visible=0");
                dw_generic.GetControlByName("comp_pageno").Visible = false;
            }
        }

        public virtual void pb_exit_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void pb_print_clicked(object sender, EventArgs e)
        {
            //? dw_generic.Print();
        }

        public virtual void pb_zoom_clicked(object sender, EventArgs e)
        {
            int nZoom = 0;
            //?  nZoom = Convert.ToInt32(dw_generic.Describe("datawindow.print.preview.zoom"));
            //?  OpenWithParm(w_preview_zoom, nZoom);
            StaticMessage.IntegerParm = nZoom;
            WPreviewZoom w_preview_zoom = new WPreviewZoom();
            w_preview_zoom.ShowDialog();
            nZoom = Convert.ToInt32(StaticMessage.DoubleParm);
            //?  dw_generic.Modify("datawindow.print.preview.zoom=" + nZoom).ToString();
        }

        public virtual void printend()
        {
            // Rex migrate
            // if bcontract then
            // 	long lcontract
            // 	w_contract w
            // 	w= g_parameters.windowparm
            // 	lcontract = w.il_contract
            // //	messagebox ( lcontract),''.ToString()
            // 	  UPDATE contract
            //      SET con_date_last_prt_for_od = today ( *)  
            //    WHERE contract.contract_no =  :lcontract  ;
            // 	commit;
            // 
            // end if
        }
    }
}