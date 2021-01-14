using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataService;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    // TJB  Frequencies & Vehicles  Jan-2021
    // Presents a list of a contract's vehicles' for the user to select from
    // Returns the vehicle_number or -1 to cancel
    //
    public class WSelectContractVehicle : WAncestorWindow
    {
        #region Define
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_selectvehicle;

        private Label label1;
        public Button cb_ok;
        public Button cb_cancel;
        private int vehicle_number = 0;
        private TextBox textBox1;

        private int il_Contract_no;

        #endregion

        public WSelectContractVehicle()
        {
            this.InitializeComponent();
            this.dw_selectvehicle.DataObject = new DSelectContractVehicle();
        }

        public override void pfc_postopen()
        {
            //dw_fixedasset.InsertItem<AddFixedAsset>(0);
            //dw_fixedasset.GetItem<AddFixedAsset>(0).FaFixedAssetNo = StaticMessage.StringParm;
            //StaticVariables.gnv_app.of_get_parameters().stringparm = "Cancelled";

            int nContractNo = (int)StaticVariables.gnv_app.of_get_parameters().integerparm;
            int nConSeqNo = (int)StaticVariables.gnv_app.of_get_parameters().intparm;
            string sConTitle = StaticVariables.gnv_app.of_get_parameters().stringparm;
            string ls_Title = "Contract: (" + nContractNo.ToString() + ") " + sConTitle;
            this.Text = ls_Title;
            il_Contract_no = nContractNo;

            dw_selectvehicle.DataObject.Reset();
            dw_selectvehicle.Retrieve(new object[] { nContractNo, nConSeqNo });
        }

        #region From Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dw_selectvehicle = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_ok = new System.Windows.Forms.Button();
            this.cb_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dw_selectvehicle
            // 
            this.dw_selectvehicle.CausesValidation = false;
            this.dw_selectvehicle.DataObject = null;
            this.dw_selectvehicle.FireConstructor = false;
            this.dw_selectvehicle.Location = new System.Drawing.Point(2, 24);
            this.dw_selectvehicle.Margin = new System.Windows.Forms.Padding(0);
            this.dw_selectvehicle.Name = "dw_selectvehicle";
            this.dw_selectvehicle.Size = new System.Drawing.Size(360, 149);
            this.dw_selectvehicle.TabIndex = 1;
            // 
            // cb_ok
            // 
            this.cb_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_ok.Location = new System.Drawing.Point(197, 179);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(75, 22);
            this.cb_ok.TabIndex = 2;
            this.cb_ok.Text = "&Ok";
            this.cb_ok.Click += new System.EventHandler(this.cb_ok_clicked);
            // 
            // cb_cancel
            // 
            this.cb_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_cancel.Location = new System.Drawing.Point(277, 179);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(75, 22);
            this.cb_cancel.TabIndex = 3;
            this.cb_cancel.Text = "&Cancel";
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_clicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(5, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "WSelectContractVehicle";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(2, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(360, 24);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Select a vehicle for overrides";
            // 
            // WSelectContractVehicle
            // 
            this.AcceptButton = this.cb_ok;
            this.CancelButton = this.cb_cancel;
            this.ClientSize = new System.Drawing.Size(364, 206);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dw_selectvehicle);
            this.Controls.Add(this.cb_cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_ok);
            this.Name = "WSelectContractVehicle";
            this.Text = "Select Vehicle";
            this.Controls.SetChildIndex(this.st_label, 0);
            this.Controls.SetChildIndex(this.cb_ok, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.dw_selectvehicle, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        public override void close()
        {

            if (StaticVariables.gnv_app.of_get_parameters().stringparm != "Ok")
            {
                MessageBox.Show("WSelectContractVehicle close()\n"
                               + "Returning -1"
                               );

                StaticVariables.gnv_app.of_get_parameters().stringparm = "Cancelled";
                StaticVariables.gnv_app.of_get_parameters().intparm = -1;
            }
            base.close();
        }
        #region Events
        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            int nRows, nRow;
            nRows = dw_selectvehicle.RowCount;
            nRow = dw_selectvehicle.GetRow();

            vehicle_number = dw_selectvehicle.GetItem<SelectContractVehicle>(nRow).VehicleNumber;

            MessageBox.Show("WSelectContractVehicle cb_ok_clicked\n"
                           + "Rowcount = " + nRows.ToString() + "\n"
                           + "GetRow() = " + nRow.ToString() + "\n\n"
                           + "vehicle_number = " + vehicle_number.ToString()
                           );
            StaticVariables.gnv_app.of_get_parameters().stringparm = "Ok";
            StaticVariables.gnv_app.of_get_parameters().intparm = vehicle_number;
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            int nRows, nRow;
            nRows = dw_selectvehicle.RowCount;
            nRow = dw_selectvehicle.GetRow();

            MessageBox.Show("WSelectContractVehicle cb_cancel_clicked\n"
                           + "Rowcount = " + nRows.ToString() + "\n"
                           + "GetRow() = " + nRow.ToString() + "\n\n"
                           + "Returning -1"
                           );

            StaticVariables.gnv_app.of_get_parameters().stringparm = "Cancelled";
            StaticVariables.gnv_app.of_get_parameters().intparm = -1;
            this.Close();
        }
        #endregion
    }
}
