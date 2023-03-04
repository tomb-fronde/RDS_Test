using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using Metex.Windows;
using NZPostOffice.Shared;
using NZPostOffice.ODPS.Controls;

namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    public partial class WQuickSelect : WResponse
    {
        #region Define
        private const string DEFAULT_ASSEMBLY = "NZPostOffice.ODPS.DataControls";
        private const string DEFAULT_VERSION = "1.0.0.0";
        #endregion

        public WQuickSelect()
        {
            InitializeComponent();
        }

        public override void open()
        {
            base.open();
            //Environment envCurrent;
            int lScreenHeight;
            int lScreenWidth;
            int nWidth = 0;
            int nLoop;
            int nColCount = 0;
            int nCurrentColumn = 0;
            idwCurrent = (URdsDw)StaticMessage.PowerObjectParm;

            dw_search.SetDataObject(DEFAULT_ASSEMBLY, DEFAULT_VERSION, idwCurrent.GetType().Name + "Listing");
            //? nColCount = StaticFunctions.ToInt32(dw_search.describe("datawindow.column.count"));

            //dw_search.Modify("datawindow.readonly=Yes");
            dw_search.Enabled = false;
            for (nLoop = 0; nLoop < nColCount; nLoop++)
            {
                //nCurrentColumn = StaticFunctions.ToInt32(dw_search.describe('#' + nLoop.ToString() + ".x")) + Metex.Common.Convert.ToInt32(dw_search.describe('#' + nLoop.ToString() + ".width"));
                nCurrentColumn = dw_search.DataObject.GetControlByName("#" + nLoop.ToString()).Location.X + dw_search.DataObject.GetControlByName("#" + nLoop.ToString()).Width;
                if (nCurrentColumn > nWidth)
                {
                    nWidth = nCurrentColumn;
                }
            }
            if (nWidth == 0)
            {
                this.Hide();
                //this.PostEvent("ue_closethis");
                this.ue_closethis();
                return;
            }
            dw_search.Width = nWidth + 120;
            //cb_select.x = dw_search.x + dw_search.width / 2 - cb_select.width - 50;
            //cb_cancel.x = dw_search.x + dw_search.width / 2 + 50;
            cb_select.Location = new Point(dw_search.Location.X + dw_search.Width / 2 - cb_select.Width - 50, 215);
            cb_cancel.Location = new Point(dw_search.Location.X + dw_search.Width / 2 + 50, 215);
            this.Width = dw_search.Location.X * 2 + dw_search.Width + 60;
            if (this.Height < StaticVariables.gnv_app.of_getframe().Height)
            {
                //this.Top  = gnv_app.of_GetFrame().y + gnv_app.of_GetFrame().height / 2 - this.Height / 2;
                this.Top = StaticVariables.gnv_app.of_getframe().Location.Y + StaticVariables.gnv_app.of_getframe().Height / 2 - this.Height / 2;
            }
            else
            {
                this.Top = 10;
            }
            if (this.Width < StaticVariables.gnv_app.of_getframe().Width)
            {
                //this.Left  = gnv_app.of_GetFrame().x + gnv_app.of_GetFrame().width / 2 - this.Width / 2;
                this.Left = StaticVariables.gnv_app.of_getframe().Location.X + StaticVariables.gnv_app.of_getframe().Width / 2 - this.Width / 2;
            }
            else
            {
                this.Left = 10;
            }
            idwCurrent.ShareData(dw_search.DataObject);
            //?            i_PageRows = Metex.Common.Convert.ToInt32(dw_search.DataObject.describe("datawindow.LastRowOnPage")) - Metex.Common.Convert.ToInt32(dw_search.describe("datawindow.FirstRowOnPage"));
            //dw_search.setrowfocusindicator(hand!);
            this.Cursor = Cursors.Hand;
            //dw_search.scrolltorow(idwCurrent.GetRow());
            dw_search.SetCurrent(idwCurrent.GetRow());
            dw_search.Focus();
            //GetEnvironment(envCurrent);
            //lScreenHeight = PixelsToUnits(envCurrent.ScreenHeight, ypixelstounits!);
            lScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            //lScreenWidth = PixelsToUnits(envCurrent.ScreenWidth, xpixelstounits!);
            lScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            this.Left = Convert.ToInt32(lScreenWidth / 2) - Convert.ToInt32(this.Width / 2);
            this.Top = Convert.ToInt32(lScreenHeight / 2) - Convert.ToInt32(this.Height / 2);
        }

        public virtual void ue_closethis()
        {
            this.Close();
        }

        #region Events
        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void cb_select_clicked(object sender, EventArgs e)
        {
            idwCurrent.SetCurrent(dw_search.GetRow());
            this.Close();
        }

        public virtual void dw_search_doubleclicked(object sender, EventArgs e)
        {
            //? if (row > 0)
            //{
            // 	This.ScrollToRow ( This.GetClickedRow ( ))
            cb_select_clicked(this, null);
            //}
        }

        public virtual void dw_search_clicked(object sender, EventArgs e)
        {
            //?if (row > 0)
            //{
            //    //dw_search.ScrollToRow(row);
            //dw_search.SetCurrent(row);
            //}
        }

        public virtual void dw_search_rowfocuschanged(object sender, EventArgs e)
        {
            // this.SelectRow ( 0,False)
            // if this.RowCount > 0 then This.SelectRow ( This.GetRow ( ),True)
        }

        //? public virtual void dw_search_sqlpreview(object sender, SqlEventArgs e)
        // {
        // string cSQLSelect;
        ////?            cSQLSelect = dw_search.GetSQLSelect();
        // cSQLSelect = cSQLSelect;
        //}   
        #endregion
    }
}