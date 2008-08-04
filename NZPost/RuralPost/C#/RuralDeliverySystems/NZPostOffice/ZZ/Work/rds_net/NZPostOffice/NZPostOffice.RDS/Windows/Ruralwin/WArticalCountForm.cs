using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralwin2;
using Metex.Windows;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WArticalCountForm : WMaster
    {
        #region Define

        public DataUserControl idw_Parent;

        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_artical_count;

        public Button cb_ok;

        public Button cb_cancel;

        public Button cb_1;

        #endregion

        public WArticalCountForm()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname("Article Count");
            int lRow;
            idw_Parent = StaticMessage.PowerObjectParm as DataUserControl;// URdsDw;
            lRow = idw_Parent.GetRow();
            //idw_Parent.DataObject.RowCopy<ContractArticalCountForm>(lRow, lRow, dw_artical_count.DataObject);//idw_Parent.RowsCopy(lRow, lRow, primary!, dw_artical_count, 10, primary!);
            dw_artical_count.InsertItem<ContractArticalCountForm>(0);
            if (idw_Parent.GetValue(lRow, "ac_scale_factor") == null)
                dw_artical_count.GetItem<ContractArticalCountForm>(0).AcScaleFactor = null;
            else
                dw_artical_count.GetItem<ContractArticalCountForm>(0).AcScaleFactor = Convert.ToDecimal(idw_Parent.GetValue(lRow, "ac_scale_factor"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcStartWeekPeriod = Convert.ToDateTime(idw_Parent.GetValue(lRow, "AcStartWeekPeriod"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1InwardMail = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW1InwardMail"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1LargeParcels = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW1LargeParcels"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1MediumLetters = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW1MediumLetters"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1OtherEnvelopes = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW1OtherEnvelopes"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1SmallParcels = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW1SmallParcels"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2InwardMail = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW2InwardMail"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2LargeParcels = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW2LargeParcels"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2MediumLetters = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW2MediumLetters"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2OtherEnvelopes = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW2OtherEnvelopes"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2SmallParcels = Convert.ToInt32(idw_Parent.GetValue(lRow, "AcW2SmallParcels"));
            dw_artical_count.GetItem<ContractArticalCountForm>(0).ContractNo = Convert.ToInt32(idw_Parent.GetValue(lRow, "ContractNo"));
            if (idw_Parent.GetValue(lRow, "ContractSeqNumber") == null)
            {
                dw_artical_count.GetItem<ContractArticalCountForm>(0).ContractSeqNumber = null;
            }
            else
            {
                dw_artical_count.GetItem<ContractArticalCountForm>(0).ContractSeqNumber = Convert.ToInt32(idw_Parent.GetValue(lRow, "ContractSeqNumber"));
            }
            dw_artical_count.GetItem<ContractArticalCountForm>(0).CustRdNumber = Convert.ToString(idw_Parent.GetValue(lRow, "CustRdNumber"));
            dw_artical_count.DataObject.GetControlByName("st_contract").Text = "";//dw_artical_count.DataControl["st_contract"].Text = "\'\'";
            ((DContractArticalCountForm)dw_artical_count.DataObject).InitializeControl();
            dw_artical_count.ResetUpdate();
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_artical_count = new URdsDw();
            this.dw_artical_count.DataObject = new DContractArticalCountForm();
            this.cb_ok = new Button();
            this.cb_cancel = new Button();
            this.cb_1 = new Button();
            Controls.Add(dw_artical_count);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            Controls.Add(cb_1);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Text = "Article Count";
            this.ControlBox = true;
            this.Size = new System.Drawing.Size(487, 172);
            // 
            // dw_artical_count
            // 
            dw_artical_count.VerticalScroll.Visible = false;
            dw_artical_count.TabIndex = 1;
            dw_artical_count.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_artical_count.Size = new System.Drawing.Size(474, 120);
            dw_artical_count.Location = new System.Drawing.Point(3, 4);

            // 
            // cb_ok
            // 
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&OK";
            cb_ok.TabIndex = 2;
            cb_ok.Size = new System.Drawing.Size(54, 22);
            cb_ok.Location = new System.Drawing.Point(121, 148);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.TabIndex = 3;
            cb_cancel.Size = new System.Drawing.Size(54, 22);
            cb_cancel.Location = new System.Drawing.Point(183, 148);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            // 
            // cb_1
            // 
            cb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_1.Text = "&View Scaling Factor";
            // Metex Migrator Warning: property tag was not converted
            cb_1.Tag = "ComponentName=View Factor;";
            cb_1.Enabled = false;
            cb_1.Visible = false;
            cb_1.TabIndex = 4;
            cb_1.Height = 22;
            cb_1.Width = 115;
            cb_1.Top = 148;
            cb_1.Left = 245;
            cb_1.Click += new EventHandler(cb_1_clicked);
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
        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            int lLoop;
            int lRow;
            lRow = idw_Parent.GetRow();
            dw_artical_count.DataObject.AcceptText();
            //for (lLoop = 2; lLoop <= 14; lLoop++) {
            //    if (lLoop == 2 || lLoop == 14) {
            //        idw_Parent.SetItem(lRow, lLoop, dw_artical_count.GetItemSystem.Conver.ToDouble(1, lLoop));
            //    }
            //    else if (lLoop > 3) {
            //        idw_Parent.SetItem(lRow, lLoop, dw_artical_count.GetItemNumber(1, lLoop));
            //    }
            //}
            if (idw_Parent is DContractArticalCounts)
            {
                idw_Parent.GetItem<ContractArticalCounts>(lRow).ContractSeqNumber = dw_artical_count.GetItem<ContractArticalCountForm>(0).ContractSeqNumber;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcScaleFactor = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcScaleFactor;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcStartWeekPeriod = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcStartWeekPeriod;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW1InwardMail = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1InwardMail;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW1LargeParcels = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1LargeParcels;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW1MediumLetters = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1MediumLetters;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW1OtherEnvelopes = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1OtherEnvelopes;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW1SmallParcels = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW1SmallParcels;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW2InwardMail = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2InwardMail;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW2LargeParcels = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2LargeParcels;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW2MediumLetters = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2MediumLetters;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW2OtherEnvelopes = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2OtherEnvelopes;
                idw_Parent.GetItem<ContractArticalCounts>(lRow).AcW2SmallParcels = dw_artical_count.GetItem<ContractArticalCountForm>(0).AcW2SmallParcels;
            }
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            double dScale;
            dScale = System.Convert.ToDouble(dw_artical_count.GetItem<ContractArticalCountForm>(0).AcScaleFactor.GetValueOrDefault());//dScale = dw_artical_count.GetItemSystem.Conver.ToDouble ( 1, "ac_scale_factor" );
            Cursor.Current = Cursors.WaitCursor;
            //OpenWithParm(w_set_artical_counts_scaling_factor, dScale);
            StaticMessage.DoubleParm = dScale;
            WSetArticalCountsScalingFactor w_set_artical_counts_scaling_factor = new WSetArticalCountsScalingFactor();
            w_set_artical_counts_scaling_factor.ShowDialog();
        }
        #endregion
    }
}