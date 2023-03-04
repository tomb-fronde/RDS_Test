namespace NZPostOffice.RDS.DataControls.Ruralwin2
{
    partial class DsFrequencyDistances
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
            components = new System.ComponentModel.Container();
            this.Name = "DsFrequencyDistances";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin2.FrequencyDistances);
            #region fd_effective_date define
            this.fd_effective_date = new System.Windows.Forms.TextBox();
            this.fd_effective_date.Name = "fd_effective_date";
            this.fd_effective_date.Location = new System.Drawing.Point(157, 1);
            this.fd_effective_date.Size = new System.Drawing.Size(68, 20);
            this.fd_effective_date.TabIndex = 10;
            this.fd_effective_date.Font = new System.Drawing.Font("Arial", 8);
            this.fd_effective_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.fd_effective_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FdEffectiveDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(fd_effective_date);
            #region fd_effective_date_t define
            this.fd_effective_date_t = new System.Windows.Forms.Label();
            this.fd_effective_date_t.Name = "fd_effective_date_t";
            this.fd_effective_date_t.Location = new System.Drawing.Point(9, 4);
            this.fd_effective_date_t.Size = new System.Drawing.Size(144, 14);
            this.fd_effective_date_t.TabIndex = 0;
            this.fd_effective_date_t.Font = new System.Drawing.Font("Arial", 8);
            this.fd_effective_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fd_effective_date_t.Text = "Fd Effective Date:";
            #endregion
            this.Controls.Add(fd_effective_date_t);
            #region fd_volume_t define
            this.fd_volume_t = new System.Windows.Forms.Label();
            this.fd_volume_t.Name = "fd_volume_t";
            this.fd_volume_t.Location = new System.Drawing.Point(9, 304);
            this.fd_volume_t.Size = new System.Drawing.Size(144, 14);
            this.fd_volume_t.TabIndex = 0;
            this.fd_volume_t.Font = new System.Drawing.Font("Arial", 8);
            this.fd_volume_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fd_volume_t.Text = "Fd Volume:";
            #endregion
            this.Controls.Add(fd_volume_t);
            #region fd_volume define
            this.fd_volume = new System.Windows.Forms.TextBox();
            this.fd_volume.Name = "fd_volume";
            this.fd_volume.Location = new System.Drawing.Point(157, 301);
            this.fd_volume.Size = new System.Drawing.Size(68, 20);
            this.fd_volume.TabIndex = 160;
            this.fd_volume.Font = new System.Drawing.Font("Arial", 8);
            this.fd_volume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fd_volume.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FdVolume", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(fd_volume);
            #region fd_processing_hrs_week_t define
            this.fd_processing_hrs_week_t = new System.Windows.Forms.Label();
            this.fd_processing_hrs_week_t.Name = "fd_processing_hrs_week_t";
            this.fd_processing_hrs_week_t.Location = new System.Drawing.Point(9, 284);
            this.fd_processing_hrs_week_t.Size = new System.Drawing.Size(144, 14);
            this.fd_processing_hrs_week_t.TabIndex = 0;
            this.fd_processing_hrs_week_t.Font = new System.Drawing.Font("Arial", 8);
            this.fd_processing_hrs_week_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fd_processing_hrs_week_t.Text = "Fd Processing Hrs Week:";
            #endregion
            this.Controls.Add(fd_processing_hrs_week_t);
            #region fd_processing_hrs_week define
            this.fd_processing_hrs_week = new System.Windows.Forms.TextBox();
            this.fd_processing_hrs_week.Name = "fd_processing_hrs_week";
            this.fd_processing_hrs_week.Location = new System.Drawing.Point(157, 281);
            this.fd_processing_hrs_week.Size = new System.Drawing.Size(68, 20);
            this.fd_processing_hrs_week.TabIndex = 150;
            this.fd_processing_hrs_week.Font = new System.Drawing.Font("Arial", 8);
            this.fd_processing_hrs_week.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fd_processing_hrs_week.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FdProcessingHrsWeek", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(fd_processing_hrs_week);
            #region fd_delivery_hrs_per_week_t define
            this.fd_delivery_hrs_per_week_t = new System.Windows.Forms.Label();
            this.fd_delivery_hrs_per_week_t.Name = "fd_delivery_hrs_per_week_t";
            this.fd_delivery_hrs_per_week_t.Location = new System.Drawing.Point(9, 263);
            this.fd_delivery_hrs_per_week_t.Size = new System.Drawing.Size(144, 14);
            this.fd_delivery_hrs_per_week_t.TabIndex = 0;
            this.fd_delivery_hrs_per_week_t.Font = new System.Drawing.Font("Arial", 8);
            this.fd_delivery_hrs_per_week_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fd_delivery_hrs_per_week_t.Text = "Fd Delivery Hrs Per Week:";
            #endregion
            this.Controls.Add(fd_delivery_hrs_per_week_t);
            #region fd_delivery_hrs_per_week define
            this.fd_delivery_hrs_per_week = new System.Windows.Forms.TextBox();
            this.fd_delivery_hrs_per_week.Name = "fd_delivery_hrs_per_week";
            this.fd_delivery_hrs_per_week.Location = new System.Drawing.Point(157, 261);
            this.fd_delivery_hrs_per_week.Size = new System.Drawing.Size(68, 20);
            this.fd_delivery_hrs_per_week.TabIndex = 140;
            this.fd_delivery_hrs_per_week.Font = new System.Drawing.Font("Arial", 8);
            this.fd_delivery_hrs_per_week.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fd_delivery_hrs_per_week.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FdDeliveryHrsPerWeek", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(fd_delivery_hrs_per_week);
            #region fd_change_reason_t define
            this.fd_change_reason_t = new System.Windows.Forms.Label();
            this.fd_change_reason_t.Name = "fd_change_reason_t";
            this.fd_change_reason_t.Location = new System.Drawing.Point(9, 244);
            this.fd_change_reason_t.Size = new System.Drawing.Size(144, 14);
            this.fd_change_reason_t.TabIndex = 0;
            this.fd_change_reason_t.Font = new System.Drawing.Font("Arial", 8);
            this.fd_change_reason_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fd_change_reason_t.Text = "Fd Change Reason:";
            #endregion
            this.Controls.Add(fd_change_reason_t);
            #region fd_change_reason define
            this.fd_change_reason = new System.Windows.Forms.TextBox();
            this.fd_change_reason.Name = "fd_change_reason";
            this.fd_change_reason.Location = new System.Drawing.Point(157, 241);
            this.fd_change_reason.Size = new System.Drawing.Size(987, 20);
            this.fd_change_reason.TabIndex = 130;
            this.fd_change_reason.Font = new System.Drawing.Font("Arial", 8);
            this.fd_change_reason.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.fd_change_reason.MaxLength = 250;
            this.fd_change_reason.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FdChangeReason", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(fd_change_reason);
            #region fd_no_cmb_customers_t define
            this.fd_no_cmb_customers_t = new System.Windows.Forms.Label();
            this.fd_no_cmb_customers_t.Name = "fd_no_cmb_customers_t";
            this.fd_no_cmb_customers_t.Location = new System.Drawing.Point(9, 224);
            this.fd_no_cmb_customers_t.Size = new System.Drawing.Size(144, 14);
            this.fd_no_cmb_customers_t.TabIndex = 0;
            this.fd_no_cmb_customers_t.Font = new System.Drawing.Font("Arial", 8);
            this.fd_no_cmb_customers_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fd_no_cmb_customers_t.Text = "Fd No Cmb Customers:";
            #endregion
            this.Controls.Add(fd_no_cmb_customers_t);
            #region fd_no_cmb_customers define
            this.fd_no_cmb_customers = new System.Windows.Forms.TextBox();
            this.fd_no_cmb_customers.Name = "fd_no_cmb_customers";
            this.fd_no_cmb_customers.Location = new System.Drawing.Point(157, 221);
            this.fd_no_cmb_customers.Size = new System.Drawing.Size(68, 20);
            this.fd_no_cmb_customers.TabIndex = 120;
            this.fd_no_cmb_customers.Font = new System.Drawing.Font("Arial", 8);
            this.fd_no_cmb_customers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fd_no_cmb_customers.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FdNoCmbCustomers", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(fd_no_cmb_customers);
            #region fd_no_cmbs_t define
            this.fd_no_cmbs_t = new System.Windows.Forms.Label();
            this.fd_no_cmbs_t.Name = "fd_no_cmbs_t";
            this.fd_no_cmbs_t.Location = new System.Drawing.Point(9, 204);
            this.fd_no_cmbs_t.Size = new System.Drawing.Size(144, 14);
            this.fd_no_cmbs_t.TabIndex = 0;
            this.fd_no_cmbs_t.Font = new System.Drawing.Font("Arial", 8);
            this.fd_no_cmbs_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fd_no_cmbs_t.Text = "Fd No Cmbs:";
            #endregion
            this.Controls.Add(fd_no_cmbs_t);
            #region fd_no_cmbs define
            this.fd_no_cmbs = new System.Windows.Forms.TextBox();
            this.fd_no_cmbs.Name = "fd_no_cmbs";
            this.fd_no_cmbs.Location = new System.Drawing.Point(157, 201);
            this.fd_no_cmbs.Size = new System.Drawing.Size(68, 20);
            this.fd_no_cmbs.TabIndex = 110;
            this.fd_no_cmbs.Font = new System.Drawing.Font("Arial", 8);
            this.fd_no_cmbs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fd_no_cmbs.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FdNoCmbs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(fd_no_cmbs);
            #region fd_no_post_offices_t define
            this.fd_no_post_offices_t = new System.Windows.Forms.Label();
            this.fd_no_post_offices_t.Name = "fd_no_post_offices_t";
            this.fd_no_post_offices_t.Location = new System.Drawing.Point(9, 183);
            this.fd_no_post_offices_t.Size = new System.Drawing.Size(144, 14);
            this.fd_no_post_offices_t.TabIndex = 0;
            this.fd_no_post_offices_t.Font = new System.Drawing.Font("Arial", 8);
            this.fd_no_post_offices_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fd_no_post_offices_t.Text = "Fd No Post Offices:";
            #endregion
            this.Controls.Add(fd_no_post_offices_t);
            #region fd_no_post_offices define
            this.fd_no_post_offices = new System.Windows.Forms.TextBox();
            this.fd_no_post_offices.Name = "fd_no_post_offices";
            this.fd_no_post_offices.Location = new System.Drawing.Point(157, 181);
            this.fd_no_post_offices.Size = new System.Drawing.Size(68, 20);
            this.fd_no_post_offices.TabIndex = 100;
            this.fd_no_post_offices.Font = new System.Drawing.Font("Arial", 8);
            this.fd_no_post_offices.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fd_no_post_offices.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FdNoPostOffices", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(fd_no_post_offices);
            #region fd_no_private_bags_t define
            this.fd_no_private_bags_t = new System.Windows.Forms.Label();
            this.fd_no_private_bags_t.Name = "fd_no_private_bags_t";
            this.fd_no_private_bags_t.Location = new System.Drawing.Point(9, 164);
            this.fd_no_private_bags_t.Size = new System.Drawing.Size(144, 14);
            this.fd_no_private_bags_t.TabIndex = 0;
            this.fd_no_private_bags_t.Font = new System.Drawing.Font("Arial", 8);
            this.fd_no_private_bags_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fd_no_private_bags_t.Text = "Fd No Private Bags:";
            #endregion
            this.Controls.Add(fd_no_private_bags_t);
            #region fd_no_private_bags define
            this.fd_no_private_bags = new System.Windows.Forms.TextBox();
            this.fd_no_private_bags.Name = "fd_no_private_bags";
            this.fd_no_private_bags.Location = new System.Drawing.Point(157, 161);
            this.fd_no_private_bags.Size = new System.Drawing.Size(68, 20);
            this.fd_no_private_bags.TabIndex = 90;
            this.fd_no_private_bags.Font = new System.Drawing.Font("Arial", 8);
            this.fd_no_private_bags.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fd_no_private_bags.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FdNoPrivateBags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(fd_no_private_bags);
            #region fd_no_other_bags_t define
            this.fd_no_other_bags_t = new System.Windows.Forms.Label();
            this.fd_no_other_bags_t.Name = "fd_no_other_bags_t";
            this.fd_no_other_bags_t.Location = new System.Drawing.Point(9, 144);
            this.fd_no_other_bags_t.Size = new System.Drawing.Size(144, 14);
            this.fd_no_other_bags_t.TabIndex = 0;
            this.fd_no_other_bags_t.Font = new System.Drawing.Font("Arial", 8);
            this.fd_no_other_bags_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fd_no_other_bags_t.Text = "Fd No Other Bags:";
            #endregion
            this.Controls.Add(fd_no_other_bags_t);
            #region fd_no_other_bags define
            this.fd_no_other_bags = new System.Windows.Forms.TextBox();
            this.fd_no_other_bags.Name = "fd_no_other_bags";
            this.fd_no_other_bags.Location = new System.Drawing.Point(157, 141);
            this.fd_no_other_bags.Size = new System.Drawing.Size(68, 20);
            this.fd_no_other_bags.TabIndex = 80;
            this.fd_no_other_bags.Font = new System.Drawing.Font("Arial", 8);
            this.fd_no_other_bags.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fd_no_other_bags.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FdNoOtherBags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(fd_no_other_bags);
            #region fd_no_rural_bags_t define
            this.fd_no_rural_bags_t = new System.Windows.Forms.Label();
            this.fd_no_rural_bags_t.Name = "fd_no_rural_bags_t";
            this.fd_no_rural_bags_t.Location = new System.Drawing.Point(9, 124);
            this.fd_no_rural_bags_t.Size = new System.Drawing.Size(144, 14);
            this.fd_no_rural_bags_t.TabIndex = 0;
            this.fd_no_rural_bags_t.Font = new System.Drawing.Font("Arial", 8);
            this.fd_no_rural_bags_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fd_no_rural_bags_t.Text = "Fd No Rural Bags:";
            #endregion
            this.Controls.Add(fd_no_rural_bags_t);
            #region fd_no_rural_bags define
            this.fd_no_rural_bags = new System.Windows.Forms.TextBox();
            this.fd_no_rural_bags.Name = "fd_no_rural_bags";
            this.fd_no_rural_bags.Location = new System.Drawing.Point(157, 121);
            this.fd_no_rural_bags.Size = new System.Drawing.Size(68, 20);
            this.fd_no_rural_bags.TabIndex = 70;
            this.fd_no_rural_bags.Font = new System.Drawing.Font("Arial", 8);
            this.fd_no_rural_bags.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fd_no_rural_bags.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FdNoRuralBags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(fd_no_rural_bags);
            #region fd_no_of_boxes_t define
            this.fd_no_of_boxes_t = new System.Windows.Forms.Label();
            this.fd_no_of_boxes_t.Name = "fd_no_of_boxes_t";
            this.fd_no_of_boxes_t.Location = new System.Drawing.Point(9, 104);
            this.fd_no_of_boxes_t.Size = new System.Drawing.Size(144, 14);
            this.fd_no_of_boxes_t.TabIndex = 0;
            this.fd_no_of_boxes_t.Font = new System.Drawing.Font("Arial", 8);
            this.fd_no_of_boxes_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fd_no_of_boxes_t.Text = "Fd No Of Boxes:";
            #endregion
            this.Controls.Add(fd_no_of_boxes_t);
            #region fd_no_of_boxes define
            this.fd_no_of_boxes = new System.Windows.Forms.TextBox();
            this.fd_no_of_boxes.Name = "fd_no_of_boxes";
            this.fd_no_of_boxes.Location = new System.Drawing.Point(157, 101);
            this.fd_no_of_boxes.Size = new System.Drawing.Size(68, 20);
            this.fd_no_of_boxes.TabIndex = 60;
            this.fd_no_of_boxes.Font = new System.Drawing.Font("Arial", 8);
            this.fd_no_of_boxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fd_no_of_boxes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FdNoOfBoxes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(fd_no_of_boxes);
            #region fd_distance_t define
            this.fd_distance_t = new System.Windows.Forms.Label();
            this.fd_distance_t.Name = "fd_distance_t";
            this.fd_distance_t.Location = new System.Drawing.Point(9, 84);
            this.fd_distance_t.Size = new System.Drawing.Size(144, 14);
            this.fd_distance_t.TabIndex = 0;
            this.fd_distance_t.Font = new System.Drawing.Font("Arial", 8);
            this.fd_distance_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fd_distance_t.Text = "Fd Distance:";
            #endregion
            this.Controls.Add(fd_distance_t);
            #region fd_distance define
            this.fd_distance = new System.Windows.Forms.TextBox();
            this.fd_distance.Name = "fd_distance";
            this.fd_distance.Location = new System.Drawing.Point(157, 81);
            this.fd_distance.Size = new System.Drawing.Size(68, 20);
            this.fd_distance.TabIndex = 50;
            this.fd_distance.Font = new System.Drawing.Font("Arial", 8);
            this.fd_distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fd_distance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FdDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(fd_distance);
            #region rf_delivery_days_t define
            this.rf_delivery_days_t = new System.Windows.Forms.Label();
            this.rf_delivery_days_t.Name = "rf_delivery_days_t";
            this.rf_delivery_days_t.Location = new System.Drawing.Point(9, 64);
            this.rf_delivery_days_t.Size = new System.Drawing.Size(144, 14);
            this.rf_delivery_days_t.TabIndex = 0;
            this.rf_delivery_days_t.Font = new System.Drawing.Font("Arial", 8);
            this.rf_delivery_days_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rf_delivery_days_t.Text = "Rf Delivery Days:";
            #endregion
            this.Controls.Add(rf_delivery_days_t);
            #region rf_delivery_days define
            this.rf_delivery_days = new System.Windows.Forms.TextBox();
            this.rf_delivery_days.Name = "rf_delivery_days";
            this.rf_delivery_days.Location = new System.Drawing.Point(157, 61);
            this.rf_delivery_days.Size = new System.Drawing.Size(45, 20);
            this.rf_delivery_days.TabIndex = 40;
            this.rf_delivery_days.Font = new System.Drawing.Font("Arial", 8);
            this.rf_delivery_days.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.rf_delivery_days.MaxLength = 7;
            this.rf_delivery_days.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RfDeliveryDays", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(rf_delivery_days);
            #region sf_key_t define
            this.sf_key_t = new System.Windows.Forms.Label();
            this.sf_key_t.Name = "sf_key_t";
            this.sf_key_t.Location = new System.Drawing.Point(9, 44);
            this.sf_key_t.Size = new System.Drawing.Size(144, 14);
            this.sf_key_t.TabIndex = 0;
            this.sf_key_t.Font = new System.Drawing.Font("Arial", 8);
            this.sf_key_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sf_key_t.Text = "Sf Key:";
            #endregion
            this.Controls.Add(sf_key_t);
            #region sf_key define
            this.sf_key = new System.Windows.Forms.TextBox();
            this.sf_key.Name = "sf_key";
            this.sf_key.Location = new System.Drawing.Point(157, 41);
            this.sf_key.Size = new System.Drawing.Size(68, 20);
            this.sf_key.TabIndex = 30;
            this.sf_key.Font = new System.Drawing.Font("Arial", 8);
            this.sf_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sf_key.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "SfKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(sf_key);
            #region contract_no_t define
            this.contract_no_t = new System.Windows.Forms.Label();
            this.contract_no_t.Name = "contract_no_t";
            this.contract_no_t.Location = new System.Drawing.Point(9, 24);
            this.contract_no_t.Size = new System.Drawing.Size(144, 14);
            this.contract_no_t.TabIndex = 0;
            this.contract_no_t.Font = new System.Drawing.Font("Arial", 8);
            this.contract_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.contract_no_t.Text = "Contract No:";
            #endregion
            this.Controls.Add(contract_no_t);
            #region contract_no define
            this.contract_no = new System.Windows.Forms.TextBox();
            this.contract_no.Name = "contract_no";
            this.contract_no.Location = new System.Drawing.Point(157, 21);
            this.contract_no.Size = new System.Drawing.Size(68, 20);
            this.contract_no.TabIndex = 20;
            this.contract_no.Font = new System.Drawing.Font("Arial", 8);
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(contract_no);
            this.Size = new System.Drawing.Size(650, 331);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.TextBox fd_effective_date;
        private System.Windows.Forms.Label fd_effective_date_t;
        private System.Windows.Forms.Label fd_volume_t;
        private System.Windows.Forms.TextBox fd_volume;
        private System.Windows.Forms.Label fd_processing_hrs_week_t;
        private System.Windows.Forms.TextBox fd_processing_hrs_week;
        private System.Windows.Forms.Label fd_delivery_hrs_per_week_t;
        private System.Windows.Forms.TextBox fd_delivery_hrs_per_week;
        private System.Windows.Forms.Label fd_change_reason_t;
        private System.Windows.Forms.TextBox fd_change_reason;
        private System.Windows.Forms.Label fd_no_cmb_customers_t;
        private System.Windows.Forms.TextBox fd_no_cmb_customers;
        private System.Windows.Forms.Label fd_no_cmbs_t;
        private System.Windows.Forms.TextBox fd_no_cmbs;
        private System.Windows.Forms.Label fd_no_post_offices_t;
        private System.Windows.Forms.TextBox fd_no_post_offices;
        private System.Windows.Forms.Label fd_no_private_bags_t;
        private System.Windows.Forms.TextBox fd_no_private_bags;
        private System.Windows.Forms.Label fd_no_other_bags_t;
        private System.Windows.Forms.TextBox fd_no_other_bags;
        private System.Windows.Forms.Label fd_no_rural_bags_t;
        private System.Windows.Forms.TextBox fd_no_rural_bags;
        private System.Windows.Forms.Label fd_no_of_boxes_t;
        private System.Windows.Forms.TextBox fd_no_of_boxes;
        private System.Windows.Forms.Label fd_distance_t;
        private System.Windows.Forms.TextBox fd_distance;
        private System.Windows.Forms.Label rf_delivery_days_t;
        private System.Windows.Forms.TextBox rf_delivery_days;
        private System.Windows.Forms.Label sf_key_t;
        private System.Windows.Forms.TextBox sf_key;
        private System.Windows.Forms.Label contract_no_t;
        private System.Windows.Forms.TextBox contract_no;
    }
}
