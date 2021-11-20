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
    public class WQuickSelect : WMaster
    {
        #region Define

        public int i_pagerows;

        public DataUserControl idwCurrent;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_cancel;

        public Button cb_select;

        public URdsDw dw_search;

        #endregion

        public WQuickSelect()
        {
            this.InitializeComponent();
        }

        public override void open()
        {
            base.open();
            /*? 
            int lScreenHeight;
            int lScreenWidth;
            int nWidth = 0;
            int nLoop;
            int nColCount;
            int nCurrentColumn;
            idwCurrent = (DataUserControl)StaticMessage.PowerObjectParm;
            dw_search.DataObject = (DataUserControl)Activator.CreateInstance(Type.GetType(idwCurrent.GetType().AssemblyQualifiedName + "Listing"));
            nColCount = StaticFunctions.ToInt32(dw_search.Ent);
            dw_search.Enabled = false;
            for (nLoop = 1; nLoop <= nColCount; nLoop++)
            {
                nCurrentColumn = StaticFunctions.ToInt32(dw_search.describe('#' + nLoop.ToString() + ".Left")) + StaticFunctions.ToInt32(dw_search.describe('#' + nLoop.ToString() + ".Width"));
                if (nCurrentColumn > nWidth)
                {
                    nWidth = nCurrentColumn;
                }
            }
            if (nWidth == 0)
            {
                this.Hide();
                this.ue_closethis();
                return;
            }
            dw_search.Width = nWidth + 120;
            cb_select.Left = dw_search.Left + dw_search.Width / 2 - cb_select.Width - 50;
            cb_cancel.Left = dw_search.Left + dw_search.Width / 2 + 50;
            this.Width = dw_search.Left * 2 + dw_search.Width + 60;
            if (this.Height < StaticVariables.gnv_app.of_getframe().Height)
            {
                this.Top = StaticVariables.gnv_app.of_getframe().Top + StaticVariables.gnv_app.of_getframe().Height / 2 - this.Height / 2;
            }
            else
            {
                this.Top = 10;
            }
            if (this.Width < StaticVariables.gnv_app.of_getframe().Width)
            {
                this.Left = StaticVariables.gnv_app.of_getframe().Left + StaticVariables.gnv_app.of_getframe().Width / 2 - this.Width / 2;
            }
            else
            {
                this.Left = 10;
            }
            idwCurrent.ShareData(dw_search);
            i_pagerows = StaticFunctions.ToInt32(dw_search.describe("datawindow.LastRowOnPage")) - StaticFunctions.ToInt32(dw_search.describe("datawindow.FirstRowOnPage"));
            //? dw_search.setrowfocusindicator(hand!);
            dw_search.SetCurrent(idwCurrent.GetRow());
            dw_search.Focus();
            lScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            lScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            this.Left = lScreenWidth / 2 - this.Width / 2;
            this.Top = lScreenHeight / 2 - this.Height / 2;
            */
        }

        public virtual void ue_closethis()
        {
            this.Close();
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
            this.cb_select = new Button();
            this.dw_search = new URdsDw();
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
            cb_cancel.Top = 215;
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
            dw_search.TabIndex = 1;
            dw_search.Height = 206;
            dw_search.Width = 328;
            dw_search.Top = 4;
            dw_search.Left = 3;
            dw_search.DoubleClick += new EventHandler(dw_search_doubleclicked);
            dw_search.Click += new EventHandler(dw_search_clicked);
            dw_search.RowFocusChanged += new EventHandler(dw_search_rowfocuschanged);
            //? dw_search.SqlPreview += new SqlEventHandler(dw_search_sqlpreview);            
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
            this.Close(); // close(parent)
        }

        public virtual void cb_select_clicked(object sender, EventArgs e)
        {
            idwCurrent.SetCurrent(dw_search.GetRow());
            this.Close(); // close(parent)
        }

        public virtual void dw_search_doubleclicked(object sender, EventArgs e)
        {
            int row = dw_search.GetRow();
            if (row > 0)
            {
                // 	This.SetCurrent ( This.GetClickedRow ( ))
                cb_select_clicked(this, null);
            }
        }

        public virtual void dw_search_clicked(object sender, EventArgs e)
        {
            int row = dw_search.GetRow();
            if (row >= 0)
            {
                dw_search.SetCurrent(row);
            }
        }

        public virtual void dw_search_rowfocuschanged(object sender, EventArgs e)
        {
            // this.SelectRow ( 0,False)
            // if this.RowCount > 0 then This.SelectRow ( This.GetRow ( ),True)
        }

        public virtual void dw_search_sqlpreview(object sender, EventArgs e)
        {
            //? string cSQLSelect;
            //? cSQLSelect = dw_search.GetSQLSelect();
            //? cSQLSelect = cSQLSelect;
        }
        #endregion
    }
}
