using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DSearchAddress
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.CheckBox rd_contract_select;
        private System.Windows.Forms.MaskedTextBox contract_no;
        private System.Windows.Forms.Label contract_no_t;
        private System.Windows.Forms.Label adr_rd_no_t;
        private System.Windows.Forms.Label adr_no_t;
        private System.Windows.Forms.Label road_suffix_t;
        
        private System.Windows.Forms.TextBox adr_num;
        private System.Windows.Forms.Label dp_id_t;
        
        private System.Windows.Forms.Label road_type_t;
        private System.Windows.Forms.MaskedTextBox dp_id;
        
        private System.Windows.Forms.Label sl_id_t;
        
        private System.Windows.Forms.TextBox road_name;
        private System.Windows.Forms.TextBox adr_rd_no;
        private System.Windows.Forms.Label tc_id_t;
        private System.Windows.Forms.Label road_id_t;

        private Metex.Windows.DataEntityCombo rt_id;
        private Metex.Windows.DataEntityCombo rs_id;       
        //!private Metex.Windows.DataEntityCombo sl_name;
        private ComboBox sl_name;
        private Metex.Windows.DataEntityCombo tc_id;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.adr_no_t = new System.Windows.Forms.Label();
            this.road_type_t = new System.Windows.Forms.Label();
            this.road_suffix_t = new System.Windows.Forms.Label();
            this.adr_num = new System.Windows.Forms.TextBox();
            this.tc_id_t = new System.Windows.Forms.Label();
            this.sl_id_t = new System.Windows.Forms.Label();
            this.road_id_t = new System.Windows.Forms.Label();
            this.road_name = new System.Windows.Forms.TextBox();
            this.rt_id = new Metex.Windows.DataEntityCombo();
            this.rs_id = new Metex.Windows.DataEntityCombo();
            this.contract_no_t = new System.Windows.Forms.Label();
            this.contract_no = new System.Windows.Forms.MaskedTextBox();
            this.dp_id_t = new System.Windows.Forms.Label();
            this.adr_rd_no_t = new System.Windows.Forms.Label();
            this.adr_rd_no = new System.Windows.Forms.TextBox();
            this.dp_id = new System.Windows.Forms.MaskedTextBox();
            this.rd_contract_select = new System.Windows.Forms.CheckBox();
            this.tc_id = new Metex.Windows.DataEntityCombo();
            this.sl_name = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.SearchAddress);
            // 
            // adr_no_t
            // 
            this.adr_no_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.adr_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.adr_no_t.ForeColor = System.Drawing.Color.Black;
            this.adr_no_t.Location = new System.Drawing.Point(0, 4);
            this.adr_no_t.Name = "adr_no_t";
            this.adr_no_t.Size = new System.Drawing.Size(90, 13);
            this.adr_no_t.TabIndex = 0;
            this.adr_no_t.Text = "Street/Road No";
            this.adr_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // road_type_t
            // 
            this.road_type_t.Font = new System.Drawing.Font("Arial", 7F);
            this.road_type_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.road_type_t.Location = new System.Drawing.Point(266, 7);
            this.road_type_t.Name = "road_type_t";
            this.road_type_t.Size = new System.Drawing.Size(35, 11);
            this.road_type_t.TabIndex = 1;
            this.road_type_t.Text = "Type";
            this.road_type_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // road_suffix_t
            // 
            this.road_suffix_t.Font = new System.Drawing.Font("Arial", 7F);
            this.road_suffix_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.road_suffix_t.Location = new System.Drawing.Point(333, 7);
            this.road_suffix_t.Name = "road_suffix_t";
            this.road_suffix_t.Size = new System.Drawing.Size(35, 12);
            this.road_suffix_t.TabIndex = 2;
            this.road_suffix_t.Text = "Suffix";
            this.road_suffix_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // adr_num
            // 
            this.adr_num.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AdrNum", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.adr_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.adr_num.ForeColor = System.Drawing.Color.Black;
            this.adr_num.Location = new System.Drawing.Point(96, 0);
            this.adr_num.MaxLength = 10;
            this.adr_num.Name = "adr_num";
            this.adr_num.Size = new System.Drawing.Size(70, 20);
            this.adr_num.TabIndex = 10;
            // 
            // tc_id_t
            // 
            this.tc_id_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tc_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tc_id_t.ForeColor = System.Drawing.Color.Black;
            this.tc_id_t.Location = new System.Drawing.Point(0, 72);
            this.tc_id_t.Name = "tc_id_t";
            this.tc_id_t.Size = new System.Drawing.Size(90, 13);
            this.tc_id_t.TabIndex = 11;
            this.tc_id_t.Text = "Town/City";
            this.tc_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sl_id_t
            // 
            this.sl_id_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.sl_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sl_id_t.ForeColor = System.Drawing.Color.Black;
            this.sl_id_t.Location = new System.Drawing.Point(0, 49);
            this.sl_id_t.Name = "sl_id_t";
            this.sl_id_t.Size = new System.Drawing.Size(90, 13);
            this.sl_id_t.TabIndex = 12;
            this.sl_id_t.Text = "Suburb/Locality";
            this.sl_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // road_id_t
            // 
            this.road_id_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.road_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.road_id_t.ForeColor = System.Drawing.Color.Black;
            this.road_id_t.Location = new System.Drawing.Point(-4, 26);
            this.road_id_t.Name = "road_id_t";
            this.road_id_t.Size = new System.Drawing.Size(96, 13);
            this.road_id_t.TabIndex = 13;
            this.road_id_t.Text = "Street/Road Name";
            this.road_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // road_name
            // 
            this.road_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RoadName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.road_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.road_name.ForeColor = System.Drawing.Color.Black;
            this.road_name.Location = new System.Drawing.Point(96, 22);
            this.road_name.MaxLength = 0;
            this.road_name.Name = "road_name";
            this.road_name.Size = new System.Drawing.Size(147, 20);
            this.road_name.TabIndex = 20;
            this.road_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.road_name_KeyPress);
            // 
            // rt_id
            // 
            this.rt_id.AutoRetrieve = true;
            this.rt_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RtId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rt_id.DisplayMember = "RtName";
            this.rt_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.rt_id.DropDownWidth = 63;
            this.rt_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rt_id.ForeColor = System.Drawing.Color.Black;
            this.rt_id.Location = new System.Drawing.Point(247, 22);
            this.rt_id.Name = "rt_id";
            this.rt_id.Size = new System.Drawing.Size(63, 21);
            this.rt_id.TabIndex = 30;
            this.rt_id.Value = null;
            this.rt_id.ValueMember = "RtId";
            this.rt_id.KeyPress += new KeyPressEventHandler(ComboboxKeyPress);
            // 
            // rs_id
            // 
            this.rs_id.AutoRetrieve = true;
            this.rs_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RsId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rs_id.DisplayMember = "RsName";
            this.rs_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.rs_id.DropDownWidth = 63;
            this.rs_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rs_id.ForeColor = System.Drawing.Color.Black;
            this.rs_id.Location = new System.Drawing.Point(314, 22);
            this.rs_id.Name = "rs_id";
            this.rs_id.Size = new System.Drawing.Size(63, 21);
            this.rs_id.TabIndex = 40;
            this.rs_id.Value = null;
            this.rs_id.ValueMember = "RsId";
            this.rs_id.KeyPress += new KeyPressEventHandler(ComboboxKeyPress);
            // 
            // contract_no_t
            // 
            this.contract_no_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.contract_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_no_t.ForeColor = System.Drawing.Color.Black;
            this.contract_no_t.Location = new System.Drawing.Point(370, 4);
            this.contract_no_t.Name = "contract_no_t";
            this.contract_no_t.Size = new System.Drawing.Size(67, 15);
            this.contract_no_t.TabIndex = 41;
            this.contract_no_t.Text = "Contract No";
            this.contract_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contract_no
            // 
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_no.Location = new System.Drawing.Point(443, 1);
            this.contract_no.Name = "contract_no";
            this.contract_no.Size = new System.Drawing.Size(59, 20);
            this.contract_no.TabIndex = 70;
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dp_id_t
            // 
            this.dp_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dp_id_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dp_id_t.Location = new System.Drawing.Point(400, 47);
            this.dp_id_t.Name = "dp_id_t";
            this.dp_id_t.Size = new System.Drawing.Size(37, 15);
            this.dp_id_t.TabIndex = 71;
            this.dp_id_t.Text = "DP_ID";
            this.dp_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // adr_rd_no_t
            // 
            this.adr_rd_no_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.adr_rd_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.adr_rd_no_t.ForeColor = System.Drawing.Color.Black;
            this.adr_rd_no_t.Location = new System.Drawing.Point(391, 25);
            this.adr_rd_no_t.Name = "adr_rd_no_t";
            this.adr_rd_no_t.Size = new System.Drawing.Size(46, 15);
            this.adr_rd_no_t.TabIndex = 72;
            this.adr_rd_no_t.Text = "R D No";
            this.adr_rd_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // adr_rd_no
            // 
            this.adr_rd_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AdrRdNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.adr_rd_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.adr_rd_no.ForeColor = System.Drawing.Color.Black;
            this.adr_rd_no.Location = new System.Drawing.Point(443, 22);
            this.adr_rd_no.MaxLength = 40;
            this.adr_rd_no.Name = "adr_rd_no";
            this.adr_rd_no.Size = new System.Drawing.Size(59, 20);
            this.adr_rd_no.TabIndex = 80;
            // 
            // dp_id
            // 
            this.dp_id.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DpId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dp_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dp_id.Location = new System.Drawing.Point(443, 44);
            this.dp_id.Name = "dp_id";
            this.dp_id.Size = new System.Drawing.Size(59, 20);
            this.dp_id.TabIndex = 90;
            // 
            // rd_contract_select
            // 
            this.rd_contract_select.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rd_contract_select.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RdContractSelect", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rd_contract_select.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rd_contract_select.ForeColor = System.Drawing.Color.Black;
            this.rd_contract_select.Location = new System.Drawing.Point(358, 71);
            this.rd_contract_select.Name = "rd_contract_select";
            this.rd_contract_select.Size = new System.Drawing.Size(143, 15);
            this.rd_contract_select.TabIndex = 100;
            this.rd_contract_select.Text = "Rural Delivery Contracts";
            // 
            // tc_id
            // 
            this.tc_id.AutoRetrieve = true;
            this.tc_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "TcId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tc_id.DisplayMember = "TcName";
            this.tc_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.tc_id.DropDownWidth = 244;
            this.tc_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tc_id.ForeColor = System.Drawing.Color.Black;
            this.tc_id.Location = new System.Drawing.Point(96, 68);
            this.tc_id.Name = "tc_id";
            this.tc_id.Size = new System.Drawing.Size(244, 21);
            this.tc_id.TabIndex = 60;
            this.tc_id.Value = null;
            this.tc_id.ValueMember = "TcId";
            this.tc_id.KeyPress += new KeyPressEventHandler(ComboboxKeyPress);
            // 
            // sl_name
            // 
//!            this.sl_name.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource, "SlName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sl_name.DisplayMember = "SlName";
            this.sl_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.sl_name.DropDownWidth = 244;
            this.sl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sl_name.ForeColor = System.Drawing.Color.Black;
            this.sl_name.Location = new System.Drawing.Point(96, 45);
            this.sl_name.Name = "sl_name";
            this.sl_name.Size = new System.Drawing.Size(244, 21);
            this.sl_name.TabIndex = 50;
            this.sl_name.ValueMember = "SlName";
            this.sl_name.KeyPress += new KeyPressEventHandler(ComboboxKeyPress);
            // 
            // DSearchAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.adr_no_t);
            this.Controls.Add(this.road_type_t);
            this.Controls.Add(this.road_suffix_t);
            this.Controls.Add(this.adr_num);
            this.Controls.Add(this.tc_id_t);
            this.Controls.Add(this.sl_id_t);
            this.Controls.Add(this.road_id_t);
            this.Controls.Add(this.road_name);
            this.Controls.Add(this.rt_id);
            this.Controls.Add(this.rs_id);
            this.Controls.Add(this.contract_no_t);
            this.Controls.Add(this.contract_no);
            this.Controls.Add(this.dp_id_t);
            this.Controls.Add(this.adr_rd_no_t);
            this.Controls.Add(this.adr_rd_no);
            this.Controls.Add(this.dp_id);
            this.Controls.Add(this.rd_contract_select);
            this.Controls.Add(this.tc_id);
            this.Controls.Add(this.sl_name);
            this.Name = "DSearchAddress";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //p! added autocomplete code
        void ComboboxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            string strFindStr = "";

            if (e.KeyChar == (char)8)
            {
                if (cb.SelectionStart <= 1)
                {
                    cb.Text = "";
                    return;
                }

                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            }
            else
            {
                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text + e.KeyChar;
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            }

            int intIdx = -1;

            // Search the string in the ComboBox list.

            intIdx = cb.FindString(strFindStr);

            if (intIdx != -1)
            {
                cb.SelectedText = "";
                cb.SelectedIndex = intIdx;
                cb.SelectionStart = strFindStr.Length;
                cb.SelectionLength = cb.Text.Length;
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }

        }
        //p! END OF added autocomplete code

        void road_name_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyData ==  Keys.D0 || e.KeyData == Keys.D1 || e.KeyData == Keys.D2 || e.KeyData == Keys.D3 || e.KeyData == Keys.D4 || e.KeyData == Keys.D5 || e.KeyData == Keys.D6 || e.KeyData == Keys.D7 || e.KeyData == Keys.D8 || e.KeyData == Keys.D9 || e.KeyData == Keys.A || e.KeyData == Keys.B || e.KeyData == Keys.C || e.KeyData == Keys.D || e.KeyData == Keys.E || e.KeyData == Keys.F || e.KeyData == Keys.G || e.KeyData == Keys.H || e.KeyData == Keys.I || e.KeyData == Keys.J || e.KeyData == Keys.K || e.KeyData == Keys.L || e.KeyData == Keys.M || e.KeyData == Keys.N || e.KeyData == Keys.O || e.KeyData == Keys.P || e.KeyData == Keys.Q || e.KeyData == Keys.R || e.KeyData == Keys.S || e.KeyData == Keys.T || e.KeyData == Keys.U || e.KeyData == Keys.V || e.KeyData == Keys.W || e.KeyData == Keys.X || e.KeyData == Keys.Y || e.KeyData == Keys.Z)
            {
                Keypress = true;
            }
            else
            {
                Keypress = false;
            }
        }

        void road_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Back)
            {
                Keyback = true;
            }
            else
            {
                Keyback = false;
            }
        }

        private void StringaToBool(object sender, ConvertEventArgs e)
        {
            if ((e.Value is bool) && (e.DesiredType == typeof(string)))
            {
                bool isTrue = (bool)e.Value;
                if (isTrue)
                    e.Value = 1;
                else
                    e.Value = 0;
            }
        }

        private void BoolToStringa(object sender, ConvertEventArgs cevent)
        {
            if (cevent.DesiredType != typeof(bool)) return;
            if (cevent.Value == null)
            {
                cevent.Value = false;
                return;
            }
            int sCheck = (int)cevent.Value;
            if (sCheck.CompareTo(1) == 0)
                cevent.Value = true;
            else
                cevent.Value = false;
        }

        #endregion
        public bool Keyback = false;
        public bool Keypress = false;       

    }
}
