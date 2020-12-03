using NZPostOffice.RDS.Entity.Ruraldw;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    // TJB Frequencies Nov-2020
    // Created modelled on DContractFixedAssetsTest.designer
    //
    // TJB Frequencies Changes 13-Nov-2020
    // Checkin sort-of-working version

    partial class DRouteFrequency2Rows
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.n_39995586 = new System.Windows.Forms.Label();
            this.distance = new System.Windows.Forms.TextBox();
            this.rf_nms_t = new System.Windows.Forms.Label();
            this.rf_nms = new System.Windows.Forms.TextBox();
            this.rf_active = new System.Windows.Forms.CheckBox();
            this.rf_dpcount_t = new System.Windows.Forms.Label();
            this.rf_dpcount = new System.Windows.Forms.TextBox();
            this.rf_vehicle_name_t = new System.Windows.Forms.Label();
            this.Line = new System.Windows.Forms.Label();
            this.rf_sunday = new System.Windows.Forms.CheckBox();
            this.rf_monday = new System.Windows.Forms.CheckBox();
            this.rf_tuesday = new System.Windows.Forms.CheckBox();
            this.rf_wednesday = new System.Windows.Forms.CheckBox();
            this.rf_thursday = new System.Windows.Forms.CheckBox();
            this.rf_friday = new System.Windows.Forms.CheckBox();
            this.rf_saturday = new System.Windows.Forms.CheckBox();
            this.rf_adjusted = new System.Windows.Forms.TextBox();
            this.sf_key = new Metex.Windows.DataEntityCombo();
            this.vehicle_number = new Metex.Windows.DataEntityCombo();
            this.rf_contract_no = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RouteFrequency2);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // n_39995586
            // 
            this.n_39995586.Location = new System.Drawing.Point(0, 0);
            this.n_39995586.Name = "n_39995586";
            this.n_39995586.Size = new System.Drawing.Size(100, 23);
            this.n_39995586.TabIndex = 0;
            // 
            // distance
            // 
            this.distance.BackColor = System.Drawing.SystemColors.Control;
            this.distance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.distance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Distance", true));
            this.distance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.distance.Location = new System.Drawing.Point(324, 1);
            this.distance.MaxLength = 40;
            this.distance.Name = "distance";
            this.distance.ReadOnly = true;
            this.distance.Size = new System.Drawing.Size(50, 13);
            this.distance.TabIndex = 30;
            this.distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rf_nms_t
            // 
            this.rf_nms_t.BackColor = System.Drawing.SystemColors.Control;
            this.rf_nms_t.CausesValidation = false;
            this.rf_nms_t.Location = new System.Drawing.Point(23, 22);
            this.rf_nms_t.Name = "rf_nms_t";
            this.rf_nms_t.Size = new System.Drawing.Size(44, 13);
            this.rf_nms_t.TabIndex = 0;
            this.rf_nms_t.Text = "   NMS";
            this.rf_nms_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rf_nms
            // 
            this.rf_nms.BackColor = System.Drawing.SystemColors.Control;
            this.rf_nms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rf_nms.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RfNms", true));
            this.rf_nms.Location = new System.Drawing.Point(73, 22);
            this.rf_nms.MaxLength = 4;
            this.rf_nms.Name = "rf_nms";
            this.rf_nms.Size = new System.Drawing.Size(61, 13);
            this.rf_nms.TabIndex = 60;
            // 
            // rf_active
            // 
            this.rf_active.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RfActiveChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rf_active.Font = new System.Drawing.Font("Arial", 8F);
            this.rf_active.Location = new System.Drawing.Point(150, 3);
            this.rf_active.Name = "rf_active";
            this.rf_active.Size = new System.Drawing.Size(16, 13);
            this.rf_active.TabIndex = 20;
            // 
            // rf_dpcount_t
            // 
            this.rf_dpcount_t.BackColor = System.Drawing.SystemColors.Control;
            this.rf_dpcount_t.CausesValidation = false;
            this.rf_dpcount_t.Location = new System.Drawing.Point(157, 22);
            this.rf_dpcount_t.Name = "rf_dpcount_t";
            this.rf_dpcount_t.Size = new System.Drawing.Size(60, 13);
            this.rf_dpcount_t.TabIndex = 0;
            this.rf_dpcount_t.Text = "DP Count";
            this.rf_dpcount_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rf_dpcount
            // 
            this.rf_dpcount.BackColor = System.Drawing.SystemColors.Control;
            this.rf_dpcount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rf_dpcount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RfDpcount", true));
            this.rf_dpcount.Location = new System.Drawing.Point(222, 22);
            this.rf_dpcount.Name = "rf_dpcount";
            this.rf_dpcount.Size = new System.Drawing.Size(53, 13);
            this.rf_dpcount.TabIndex = 70;
            this.rf_dpcount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rf_vehicle_name_t
            // 
            this.rf_vehicle_name_t.AutoSize = true;
            this.rf_vehicle_name_t.BackColor = System.Drawing.SystemColors.Control;
            this.rf_vehicle_name_t.Location = new System.Drawing.Point(282, 22);
            this.rf_vehicle_name_t.Name = "rf_vehicle_name_t";
            this.rf_vehicle_name_t.Size = new System.Drawing.Size(42, 13);
            this.rf_vehicle_name_t.TabIndex = 0;
            this.rf_vehicle_name_t.Text = "Vehicle";
            // 
            // Line
            // 
            this.Line.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Line.Location = new System.Drawing.Point(8, 38);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(512, 1);
            this.Line.TabIndex = 66;
            // 
            // rf_sunday
            // 
            this.rf_sunday.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RfSundayChecked", true));
            this.rf_sunday.Font = new System.Drawing.Font("Arial", 8F);
            this.rf_sunday.Location = new System.Drawing.Point(302, 3);
            this.rf_sunday.Name = "rf_sunday";
            this.rf_sunday.Size = new System.Drawing.Size(16, 13);
            this.rf_sunday.TabIndex = 36;
            this.rf_sunday.UseVisualStyleBackColor = true;
            // 
            // rf_monday
            // 
            this.rf_monday.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RfMondayChecked", true));
            this.rf_monday.Font = new System.Drawing.Font("Arial", 8F);
            this.rf_monday.Location = new System.Drawing.Point(182, 3);
            this.rf_monday.Name = "rf_monday";
            this.rf_monday.Size = new System.Drawing.Size(16, 13);
            this.rf_monday.TabIndex = 30;
            this.rf_monday.UseVisualStyleBackColor = true;
            // 
            // rf_tuesday
            // 
            this.rf_tuesday.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RfTuesdayChecked", true));
            this.rf_tuesday.Font = new System.Drawing.Font("Arial", 8F);
            this.rf_tuesday.Location = new System.Drawing.Point(202, 3);
            this.rf_tuesday.Name = "rf_tuesday";
            this.rf_tuesday.Size = new System.Drawing.Size(16, 13);
            this.rf_tuesday.TabIndex = 31;
            this.rf_tuesday.UseVisualStyleBackColor = true;
            // 
            // rf_wednesday
            // 
            this.rf_wednesday.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RfWednesdayChecked", true));
            this.rf_wednesday.Font = new System.Drawing.Font("Arial", 8F);
            this.rf_wednesday.Location = new System.Drawing.Point(222, 3);
            this.rf_wednesday.Name = "rf_wednesday";
            this.rf_wednesday.Size = new System.Drawing.Size(16, 13);
            this.rf_wednesday.TabIndex = 32;
            this.rf_wednesday.UseVisualStyleBackColor = true;
            // 
            // rf_thursday
            // 
            this.rf_thursday.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RfThursdayChecked", true));
            this.rf_thursday.Font = new System.Drawing.Font("Arial", 8F);
            this.rf_thursday.Location = new System.Drawing.Point(242, 3);
            this.rf_thursday.Name = "rf_thursday";
            this.rf_thursday.Size = new System.Drawing.Size(16, 13);
            this.rf_thursday.TabIndex = 33;
            this.rf_thursday.UseVisualStyleBackColor = true;
            // 
            // rf_friday
            // 
            this.rf_friday.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RfFridayChecked", true));
            this.rf_friday.Font = new System.Drawing.Font("Arial", 8F);
            this.rf_friday.Location = new System.Drawing.Point(262, 3);
            this.rf_friday.Name = "rf_friday";
            this.rf_friday.Size = new System.Drawing.Size(16, 13);
            this.rf_friday.TabIndex = 34;
            this.rf_friday.UseVisualStyleBackColor = true;
            // 
            // rf_saturday
            // 
            this.rf_saturday.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RfSaturdayChecked", true));
            this.rf_saturday.Font = new System.Drawing.Font("Arial", 8F);
            this.rf_saturday.Location = new System.Drawing.Point(282, 3);
            this.rf_saturday.Name = "rf_saturday";
            this.rf_saturday.Size = new System.Drawing.Size(16, 13);
            this.rf_saturday.TabIndex = 35;
            this.rf_saturday.UseVisualStyleBackColor = true;
            // 
            // rf_adjusted
            // 
            this.rf_adjusted.BackColor = System.Drawing.SystemColors.Control;
            this.rf_adjusted.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rf_adjusted.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute2", true));
            this.rf_adjusted.Location = new System.Drawing.Point(436, 1);
            this.rf_adjusted.Name = "rf_adjusted";
            this.rf_adjusted.Size = new System.Drawing.Size(37, 13);
            this.rf_adjusted.TabIndex = 50;
            this.rf_adjusted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sf_key
            // 
            this.sf_key.AutoRetrieve = true;
            this.sf_key.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "SfKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sf_key.DisplayMember = "SfDescription";
            this.sf_key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sf_key.DropDownWidth = 156;
            this.sf_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sf_key.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sf_key.FormattingEnabled = true;
            this.sf_key.Location = new System.Drawing.Point(4, 0);
            this.sf_key.Name = "sf_key";
            this.sf_key.Size = new System.Drawing.Size(130, 21);
            this.sf_key.TabIndex = 10;
            this.sf_key.Value = null;
            this.sf_key.ValueMember = "SfKey";
            this.sf_key.SelectedIndexChanged += new System.EventHandler(this.sf_key_SelectedIndexChanged);
            // 
            // vehicle_number
            // 
            this.vehicle_number.AutoRetrieve = true;
            this.vehicle_number.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VehicleNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vehicle_number.DisplayMember = "VehicleName";
            this.vehicle_number.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vehicle_number.DropDownWidth = 156;
            this.vehicle_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vehicle_number.ForeColor = System.Drawing.SystemColors.WindowText;
            this.vehicle_number.FormattingEnabled = true;
            this.vehicle_number.Location = new System.Drawing.Point(330, 15);
            this.vehicle_number.Name = "vehicle_number";
            this.vehicle_number.Size = new System.Drawing.Size(130, 21);
            this.vehicle_number.TabIndex = 80;
            this.vehicle_number.Value = null;
            this.vehicle_number.ValueMember = "VehicleNumber";
            this.vehicle_number.SelectedIndexChanged += new System.EventHandler(this.vehicle_name_SelectedIndexChanged);
            // 
            // rf_contract_no
            // 
            this.rf_contract_no.BackColor = System.Drawing.SystemColors.Control;
            this.rf_contract_no.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rf_contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true));
            this.rf_contract_no.Enabled = false;
            this.rf_contract_no.Location = new System.Drawing.Point(480, 1);
            this.rf_contract_no.Name = "rf_contract_no";
            this.rf_contract_no.Size = new System.Drawing.Size(30, 13);
            this.rf_contract_no.TabIndex = 81;
            this.rf_contract_no.Visible = false;
            // 
            // DRouteFrequency2Rows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rf_contract_no);
            this.Controls.Add(this.sf_key);
            this.Controls.Add(this.vehicle_number);
            this.Controls.Add(this.rf_adjusted);
            this.Controls.Add(this.rf_saturday);
            this.Controls.Add(this.rf_friday);
            this.Controls.Add(this.rf_thursday);
            this.Controls.Add(this.rf_wednesday);
            this.Controls.Add(this.rf_tuesday);
            this.Controls.Add(this.rf_monday);
            this.Controls.Add(this.rf_sunday);
            this.Controls.Add(this.Line);
            this.Controls.Add(this.rf_vehicle_name_t);
            this.Controls.Add(this.rf_dpcount);
            this.Controls.Add(this.rf_dpcount_t);
            this.Controls.Add(this.rf_active);
            this.Controls.Add(this.rf_nms);
            this.Controls.Add(this.rf_nms_t);
            this.Controls.Add(this.distance);
            this.Name = "DRouteFrequency2Rows";
            this.Size = new System.Drawing.Size(525, 41);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void sf_key_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.AcceptText();
        }

        void vehicle_name_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.AcceptText();
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (this.RowCount == 0)
            {
                return;
            }

            if(e.NewIndex >= 0)
            {
                if (((RouteFrequency2)(bindingSource.List[e.NewIndex])).IsNew)
                {
                    //sf_key.ReadOnly = false;
                }
                else
                {
                    //sf_key.ReadOnly = true;
                }
            }
        }

        #endregion

        private System.Windows.Forms.Label n_39995586;
        private System.Windows.Forms.TextBox distance;
        private Metex.Windows.DataEntityCombo n_24415962;
        private System.Windows.Forms.Label rf_nms_t;
        private System.Windows.Forms.TextBox rf_nms;
        private System.Windows.Forms.CheckBox rf_active;
        private System.Windows.Forms.Label rf_dpcount_t;
        private System.Windows.Forms.TextBox rf_dpcount;
        private System.Windows.Forms.Label rf_vehicle_name_t;
        private System.Windows.Forms.Label Line;
        private System.Windows.Forms.CheckBox rf_sunday;
        private System.Windows.Forms.CheckBox rf_monday;
        private System.Windows.Forms.CheckBox rf_tuesday;
        private System.Windows.Forms.CheckBox rf_wednesday;
        private System.Windows.Forms.CheckBox rf_thursday;
        private System.Windows.Forms.CheckBox rf_friday;
        private System.Windows.Forms.CheckBox rf_saturday;
        private System.Windows.Forms.TextBox rf_adjusted;
        private Metex.Windows.DataEntityCombo sf_key;
        private Metex.Windows.DataEntityCombo vehicle_number;
        private System.Windows.Forms.TextBox rf_contract_no;
    }
}
