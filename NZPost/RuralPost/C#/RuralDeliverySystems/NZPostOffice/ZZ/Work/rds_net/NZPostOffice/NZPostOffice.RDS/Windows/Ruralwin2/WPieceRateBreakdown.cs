using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Menus;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WPieceRateBreakdown : WMaster
    {
        #region Define

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public int il_contract_no;

        public int il_supplier;

        public DateTime id_period = DateTime.MinValue;

        public URdsDw dw_1;

        #endregion

        public WPieceRateBreakdown()
        {
            m_sheet = new MSheet(this);
            this.InitializeComponent();

            //?m_sheet_menu.SetFunctionalPart(m_sheet);
            //?m_sheet_toolbar.SetFunctionalPart(m_sheet);

            //jlwang:moved from IC
            dw_1.Constructor += new UserEventDelegate(dw_1_constructor);
            //jlwang:end
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_1 = new URdsDw();
            dw_1.DataObject = new DPieceRateBreakdown();
            Controls.Add(dw_1);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(182, 89);
            this.Size = new System.Drawing.Size(270, 297);
            // 
            // dw_1
            // 
            dw_1.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_1.VerticalScroll.Visible = false;
            dw_1.Size = new System.Drawing.Size(265, 277);
            dw_1.Left = 1;
            dw_1.RowFocusChanged += new EventHandler(dw_1_rowfocuschanged);
            this.Deactivate += new EventHandler(dw_1_losefocus);
            //dw_1.Constructor += new UserEventDelegate(dw_1_constructor);
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

        public override void pfc_preopen()
        {
            //  TJB  SR4679  July 2006
            //  Fixed bug in piece rate breakdown 
            //  - datawindow name was misspelled???
            //   ( bug not related to SR4679, just found and fixed at same time)
            this.of_bypass_security(true);
            int ldwHeight;
            //?Environment eCurrent;
            NRdsMsg lnv_msg = new NRdsMsg();
            NCriteria lvn_Criteria = new NCriteria();
            lnv_msg = ((NRdsMsg)StaticMessage.PowerObjectParm);
            lvn_Criteria = lnv_msg.of_getcriteria();
            il_contract_no = Convert.ToInt32(lvn_Criteria.of_getcriteria("Contract_no"));
            il_supplier = Convert.ToInt32(lvn_Criteria.of_getcriteria("prs_key"));
            id_period = Convert.ToDateTime(lvn_Criteria.of_getcriteria("prd_date"));
            //?dw_1.settransobject(StaticVariables.sqlca);
            //?dw_1.setrowfocusindicator(focusrect!);
            ((DPieceRateBreakdown)dw_1.DataObject).Retrieve(il_contract_no, il_supplier, id_period);
            //ldwHeight = dw_1.RowCount * Convert.ToInt32(dw_1.Describe("datawindow.detail.height")) + Metex.Common.Convert.ToInt32(dw_1.Describe("datawindow.header.height")) + Metex.Common.Convert.ToInt32(dw_1.Describe("datawindow.summary.height")) + PixelsToUnits(4, ypixelstounits!);
            ldwHeight = dw_1.RowCount * 23 + 28 + 20 /*?+ PixelsToUnits(4, ypixelstounits!)*/;
            dw_1.Height = ldwHeight;
            dw_1.GetControlByName("compute_1").Top = ldwHeight - 20;
            dw_1.GetControlByName("compute_2").Top = ldwHeight - 20;
            this.Height = ldwHeight;
            //?GetEnvironment(eCurrent);
            this.Left = StaticVariables.MainMDI.PointToClient(Cursor.Position).X;// StaticVariables.gnv_app.of_getframe().Left;// PointerX();
            this.Top = StaticVariables.MainMDI.PointToClient(Cursor.Position).Y - 50;// StaticVariables.gnv_app.of_getframe().Top - 200;// PointerY() - 200;  
        }

        public virtual void dw_1_constructor()
        {
            dw_1.of_SetUpdateable(false);
        }

        #region Events
        public virtual void dw_1_rowfocuschanged(object sender, EventArgs e)
        {
            //dw_1.SelectRow(0, false);
            //dw_1.SelectRow(dw_1.GetRow(), true);
            dw_1.DataObject.SetCurrent(dw_1.GetRow());
        }

        public virtual void dw_1_losefocus(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}