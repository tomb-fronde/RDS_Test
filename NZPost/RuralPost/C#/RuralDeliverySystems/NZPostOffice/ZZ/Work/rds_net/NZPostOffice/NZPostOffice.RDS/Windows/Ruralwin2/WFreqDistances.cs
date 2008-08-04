using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using Metex.Windows;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WFreqDistances : WMaster
    {
        #region Define

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_1;

        #endregion

        public WFreqDistances()
        {
            this.InitializeComponent();

            //jlwang:moved from IC 
            dw_1.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_1_constructor);
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
            this.dw_1.DataObject = new DFrequenceDistancesForm();
            Controls.Add(dw_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ControlBox = false;
            this.Location = new System.Drawing.Point(182, 89);
            this.Size = new System.Drawing.Size(355, 209);
            // 
            // dw_1
            // 
            dw_1.VerticalScroll.Visible = false;
            dw_1.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //dw_1.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_1_constructor);
            dw_1.Location = new System.Drawing.Point(0, 0);
            dw_1.Size = new System.Drawing.Size(350, 206);
            this.Deactivate += new EventHandler(dw_1_losefocus);
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
            this.of_bypass_security(true);
            this.Left = Cursor.Position.X;// StaticVariables.gnv_app.of_getframe().Left;//.PointerX();
            this.Top = Cursor.Position.Y;// StaticVariables.gnv_app.of_getframe().Top - 200;//.PointerY() - 200;
        }

        public override void pfc_postopen()
        {
            int lLoop;
            int lColumnCount = int.MinValue;
            int lRow;
            int lSupplier;
            DateTime dPeriod = new DateTime();
            //?Environment eCurrent;
            WFrequencies2001 wParent = new WFrequencies2001();
            URdsDw dwParent = new URdsDw();
            //?wParent = w_main_mdi.GetActiveSheet();
            dwParent = (URdsDw)StaticMessage.PowerObjectParm;// wParent.dw_extensions;
            lRow = dwParent.GetRow();
            dw_1.DataObject.InsertItem<FrequenceDistancesForm>(0);
            /*lColumnCount = Convert.ToInt32(dw_1.describe("datawindow.column.count"));
            if (lColumnCount > 0)
            {
                for (lLoop = 0; lLoop < lColumnCount; lLoop++)
                {
                    // PowerBuilder 'Choose Case' statement converted into 'if' statement
                    long TestExpr = lLoop;
                    if (TestExpr == 1)
                    {
                        //?dw_1.SetValue(1, lLoop, Convert.ToDateTime(dwParent.DataObject.GetValue(lRow,lLoop)));//.Date);
                    }
                    else if (TestExpr == 4 || TestExpr == 14)
                    {
                        //?dw_1.SetValue(1, lLoop, dwParent.DataObject.GetValue(lRow, lLoop).ToString());
                    }
                    else if (TestExpr == 5 || TestExpr == 15 || TestExpr == 16)
                    {
                        //?dw_1.SetValue(1, lLoop, Convert.ToDecimal(dwParent.DataObject.GetValue(lRow, lLoop)));
                    }
                    else
                    {
                        //? dw_1.SetValue(1, lLoop, Convert.ToInt32(dwParent.DataObject.GetValue(lRow, lLoop)));
                    }
                }
            }*/
            dw_1.GetItem<FrequenceDistancesForm>(0).ContractNo = dwParent.GetItem<FrequenceDistances>(lRow).ContractNo;
            dw_1.GetItem<FrequenceDistancesForm>(0).FdChangeReason = dwParent.GetItem<FrequenceDistances>(lRow).FdChangeReason;
            dw_1.GetItem<FrequenceDistancesForm>(0).FdDeliveryHrsPerWeek = dwParent.GetItem<FrequenceDistances>(lRow).FdDeliveryHrsPerWeek;
            dw_1.GetItem<FrequenceDistancesForm>(0).FdDistance = dwParent.GetItem<FrequenceDistances>(lRow).FdDistance;
            dw_1.GetItem<FrequenceDistancesForm>(0).FdEffectiveDate = dwParent.GetItem<FrequenceDistances>(lRow).FdEffectiveDate;
            dw_1.GetItem<FrequenceDistancesForm>(0).FdNoCmbCustomers = dwParent.GetItem<FrequenceDistances>(lRow).FdNoCmbCustomers;
            dw_1.GetItem<FrequenceDistancesForm>(0).FdNoCmbs = dwParent.GetItem<FrequenceDistances>(lRow).FdNoCmbs;
            dw_1.GetItem<FrequenceDistancesForm>(0).FdNoOfBoxes = dwParent.GetItem<FrequenceDistances>(lRow).FdNoOfBoxes;
            dw_1.GetItem<FrequenceDistancesForm>(0).FdNoOtherBags = dwParent.GetItem<FrequenceDistances>(lRow).FdNoOtherBags;
            dw_1.GetItem<FrequenceDistancesForm>(0).FdNoPostOffices = dwParent.GetItem<FrequenceDistances>(lRow).FdNoPostOffices;
            dw_1.GetItem<FrequenceDistancesForm>(0).FdNoPrivateBags = dwParent.GetItem<FrequenceDistances>(lRow).FdNoPrivateBags;
            dw_1.GetItem<FrequenceDistancesForm>(0).FdNoRuralBags = dwParent.GetItem<FrequenceDistances>(lRow).FdNoRuralBags;
            dw_1.GetItem<FrequenceDistancesForm>(0).FdProcessingHrsWeek = dwParent.GetItem<FrequenceDistances>(lRow).FdProcessingHrsWeek;
            dw_1.GetItem<FrequenceDistancesForm>(0).FdVolume = dwParent.GetItem<FrequenceDistances>(lRow).FdVolume;
            dw_1.GetItem<FrequenceDistancesForm>(0).RfDeliveryDays = dwParent.GetItem<FrequenceDistances>(lRow).RfDeliveryDays;
            dw_1.GetItem<FrequenceDistancesForm>(0).SfKey = dwParent.GetItem<FrequenceDistances>(lRow).SfKey;
            dw_1.DataObject.BindingSource.CurrencyManager.Refresh();
            //SetRedraw(true);
            this.ResumeLayout();
        }

        public virtual void dw_1_constructor()
        {
            dw_1.of_SetUpdateable(false);
        }

        #region Events
        public override void resize(object sender, EventArgs args)
        {
            // 
        }

        public virtual void dw_1_losefocus(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}