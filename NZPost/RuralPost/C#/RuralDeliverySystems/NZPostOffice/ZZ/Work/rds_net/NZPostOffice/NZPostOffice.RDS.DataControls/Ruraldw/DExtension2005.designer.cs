using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DExtension2005
    {
        // TJB  Feb-2012  RPI_036
        //    Changed mask for Frequency Distances to allow negative numbers

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
            this.t_1 = new System.Windows.Forms.Label();
            this.gb_1 = new System.Windows.Forms.GroupBox();
            this.compute_1 = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.extn_distance = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.extn_boxes = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.extn_del_hrs = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.extn_rural_bags = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.extn_other_bags = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.extn_post_offices = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.extn_private_bags = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.extn_no_cmbs = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.extn_no_cmb_customers = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.gb_2 = new System.Windows.Forms.GroupBox();
            this.t_6 = new System.Windows.Forms.Label();
            this.private_bags_t = new System.Windows.Forms.Label();
            this.other_bags_t = new System.Windows.Forms.Label();
            this.rural_bags_t = new System.Windows.Forms.Label();
            this.boxes_t = new System.Windows.Forms.Label();
            this.t_13 = new System.Windows.Forms.Label();
            this.distance_t = new System.Windows.Forms.Label();
            this.post_offices_t = new System.Windows.Forms.Label();
            this.no_cmbs_t = new System.Windows.Forms.Label();
            this.no_cmb_customers_t = new System.Windows.Forms.Label();
            this.t_14 = new System.Windows.Forms.Label();
            this.del_hrs_t = new System.Windows.Forms.Label();
            this.con_title_t = new System.Windows.Forms.Label();
            this.con_title = new System.Windows.Forms.TextBox();
            this.t_2 = new System.Windows.Forms.Label();
            this.t_3 = new System.Windows.Forms.Label();
            this.gb_3 = new System.Windows.Forms.GroupBox();
            this.distance = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.st_daily_distance = new System.Windows.Forms.Label();
            this.boxes = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.rural_bags = new System.Windows.Forms.TextBox();
            this.other_bags = new System.Windows.Forms.TextBox();
            this.private_bags = new System.Windows.Forms.TextBox();
            this.post_offices = new System.Windows.Forms.TextBox();
            this.no_cmbs = new System.Windows.Forms.TextBox();
            this.no_cmb_customers = new System.Windows.Forms.TextBox();
            this.mail_volume = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.del_hrs = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.proc_hrs = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.t_9 = new System.Windows.Forms.Label();
            this.extn_effective_date = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.t_15 = new System.Windows.Forms.Label();
            this.t_16 = new System.Windows.Forms.Label();
            this.l1 = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.TextBox();
            this.t_17 = new System.Windows.Forms.Label();
            this.l3 = new System.Windows.Forms.TextBox();
            this.t_18 = new System.Windows.Forms.Label();
            this.del_days_per_week = new System.Windows.Forms.TextBox();
            this.t_19 = new System.Windows.Forms.Label();
            this.tyretubecost = new System.Windows.Forms.TextBox();
            this.t_20 = new System.Windows.Forms.Label();
            this.fuelcost = new System.Windows.Forms.TextBox();
            this.t_21 = new System.Windows.Forms.Label();
            this.repmaintcost = new System.Windows.Forms.TextBox();
            this.t_22 = new System.Windows.Forms.Label();
            this.vehicledep = new System.Windows.Forms.TextBox();
            this.ndepreciation2 = new System.Windows.Forms.TextBox();
            this.compute_2 = new System.Windows.Forms.TextBox();
            this.t_23 = new System.Windows.Forms.Label();
            this.proccost = new System.Windows.Forms.TextBox();
            this.t_24 = new System.Windows.Forms.Label();
            this.delcost = new System.Windows.Forms.TextBox();
            this.t_26 = new System.Windows.Forms.Label();
            this.acccost = new System.Windows.Forms.TextBox();
            this.compute_3 = new System.Windows.Forms.TextBox();
            this.t_27 = new System.Windows.Forms.Label();
            this.ninsurancepct = new System.Windows.Forms.TextBox();
            this.t_29 = new System.Windows.Forms.Label();
            this.nlivery = new System.Windows.Forms.TextBox();
            this.t_30 = new System.Windows.Forms.Label();
            this.ruccost = new System.Windows.Forms.TextBox();
            this.t_31 = new System.Windows.Forms.Label();
            this.nuniform = new System.Windows.Forms.TextBox();
            this.t_32 = new System.Windows.Forms.Label();
            this.nruc = new System.Windows.Forms.TextBox();
            this.t_33 = new System.Windows.Forms.Label();
            this.naccamounts = new System.Windows.Forms.TextBox();
            this.gb_4 = new System.Windows.Forms.GroupBox();
            this.accrate = new System.Windows.Forms.TextBox();
            this.t_34 = new System.Windows.Forms.Label();
            this.t_35 = new System.Windows.Forms.Label();
            this.gb_5 = new System.Windows.Forms.GroupBox();
            this.t_4 = new System.Windows.Forms.Label();
            this.cust_change = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.t_5 = new System.Windows.Forms.Label();
            this.volume_customer = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.t_7 = new System.Windows.Forms.Label();
            this.volume_change = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.t_8 = new System.Windows.Forms.Label();
            this.proc_hrs_change = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.t_10 = new System.Windows.Forms.Label();
            this.t_11 = new System.Windows.Forms.Label();
            this.t_12 = new System.Windows.Forms.Label();
            this.t_36 = new System.Windows.Forms.Label();
            this.extnamnt = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.t_37 = new System.Windows.Forms.Label();
            this.extnamount = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.t_38 = new System.Windows.Forms.Label();
            this.l_6 = new System.Windows.Forms.Panel();
            this.l_7 = new System.Windows.Forms.Panel();
            this.compute_4 = new System.Windows.Forms.TextBox();
            this.gb_6 = new System.Windows.Forms.GroupBox();
            this.extn_reason = new System.Windows.Forms.RichTextBox();
            this.t_39 = new System.Windows.Forms.Label();
            this.nuse_rucs = new System.Windows.Forms.TextBox();
            this.t_28 = new System.Windows.Forms.Label();
            this.no_del_days_year = new System.Windows.Forms.TextBox();
            this.t_25 = new System.Windows.Forms.Label();
            this.extnamnt1 = new System.Windows.Forms.TextBox();
            this.extnamnt_original = new System.Windows.Forms.TextBox();
            this.t_40 = new System.Windows.Forms.Label();
            this.reliefcost = new System.Windows.Forms.TextBox();
            this.reliefweeks = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.gb_1.SuspendLayout();
            this.gb_2.SuspendLayout();
            this.gb_3.SuspendLayout();
            this.gb_4.SuspendLayout();
            this.gb_5.SuspendLayout();
            this.gb_6.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.Extension2005);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // t_1
            // 
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_1.Location = new System.Drawing.Point(700, 5);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(74, 13);
            this.t_1.TabIndex = 0;
            this.t_1.Text = "Cust (25 sec):";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gb_1
            // 
            this.gb_1.Controls.Add(this.compute_1);
            this.gb_1.Controls.Add(this.extn_distance);
            this.gb_1.Controls.Add(this.extn_boxes);
            this.gb_1.Controls.Add(this.extn_del_hrs);
            this.gb_1.Controls.Add(this.extn_rural_bags);
            this.gb_1.Controls.Add(this.extn_other_bags);
            this.gb_1.Controls.Add(this.extn_post_offices);
            this.gb_1.Controls.Add(this.extn_private_bags);
            this.gb_1.Controls.Add(this.extn_no_cmbs);
            this.gb_1.Controls.Add(this.extn_no_cmb_customers);
            this.gb_1.Font = new System.Drawing.Font("Arial", 8F);
            this.gb_1.Location = new System.Drawing.Point(216, 70);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(115, 246);
            this.gb_1.TabIndex = 101;
            this.gb_1.TabStop = false;
            // 
            // compute_1
            // 
            this.compute_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Compute1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N2"));
            this.compute_1.EditMask = "#,##0.00";
            this.compute_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.compute_1.Location = new System.Drawing.Point(13, 10);
            this.compute_1.Name = "compute_1";
            this.compute_1.PromptChar = ' ';
            this.compute_1.ReadOnly = true;
            this.compute_1.Size = new System.Drawing.Size(70, 13);
            this.compute_1.TabIndex = 101;
            this.compute_1.TabStop = false;
            this.compute_1.Text = "0.00";
            this.compute_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.compute_1.Value = "0.00";
            // 
            // extn_distance
            // 
            this.extn_distance.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ExtnDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N2"));
            this.extn_distance.EditMask = "#####.##";
            this.extn_distance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.extn_distance.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.extn_distance.Location = new System.Drawing.Point(17, 28);
            this.extn_distance.Name = "extn_distance";
            this.extn_distance.PromptChar = ' ';
            this.extn_distance.Size = new System.Drawing.Size(68, 20);
            this.extn_distance.TabIndex = 102;
            this.extn_distance.Text = "0";
            this.extn_distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.extn_distance.Value = "0";
            this.extn_distance.Validated += new System.EventHandler(this.TextBox_LostFocus);
            // 
            // extn_boxes
            // 
            this.extn_boxes.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ExtnBoxes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.extn_boxes.EditMask = "####";
            this.extn_boxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.extn_boxes.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.extn_boxes.Location = new System.Drawing.Point(17, 48);
            this.extn_boxes.Name = "extn_boxes";
            this.extn_boxes.PromptChar = ' ';
            this.extn_boxes.Size = new System.Drawing.Size(68, 20);
            this.extn_boxes.TabIndex = 103;
            this.extn_boxes.Text = "0";
            this.extn_boxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.extn_boxes.Value = "0";
            this.extn_boxes.Validated += new System.EventHandler(this.TextBox_LostFocus);
            this.extn_boxes.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.extn_boxes_MaskInputRejected);
            // 
            // extn_del_hrs
            // 
            this.extn_del_hrs.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ExtnDelHrs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N2"));
            this.extn_del_hrs.EditMask = "#####.##";
            this.extn_del_hrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.extn_del_hrs.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.extn_del_hrs.Location = new System.Drawing.Point(17, 202);
            this.extn_del_hrs.Name = "extn_del_hrs";
            this.extn_del_hrs.PromptChar = ' ';
            this.extn_del_hrs.Size = new System.Drawing.Size(68, 20);
            this.extn_del_hrs.TabIndex = 110;
            this.extn_del_hrs.Text = "0.00";
            this.extn_del_hrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.extn_del_hrs.Value = "0.00";
            // 
            // extn_rural_bags
            // 
            this.extn_rural_bags.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ExtnRuralBags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.extn_rural_bags.EditMask = "####";
            this.extn_rural_bags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.extn_rural_bags.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.extn_rural_bags.Location = new System.Drawing.Point(17, 68);
            this.extn_rural_bags.Name = "extn_rural_bags";
            this.extn_rural_bags.PromptChar = ' ';
            this.extn_rural_bags.Size = new System.Drawing.Size(68, 20);
            this.extn_rural_bags.TabIndex = 104;
            this.extn_rural_bags.Text = "0";
            this.extn_rural_bags.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.extn_rural_bags.Value = "0";
            // 
            // extn_other_bags
            // 
            this.extn_other_bags.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ExtnOtherBags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.extn_other_bags.EditMask = "####";
            this.extn_other_bags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.extn_other_bags.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.extn_other_bags.Location = new System.Drawing.Point(17, 88);
            this.extn_other_bags.Name = "extn_other_bags";
            this.extn_other_bags.PromptChar = ' ';
            this.extn_other_bags.Size = new System.Drawing.Size(68, 20);
            this.extn_other_bags.TabIndex = 105;
            this.extn_other_bags.Text = "0";
            this.extn_other_bags.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.extn_other_bags.Value = "0";
            // 
            // extn_post_offices
            // 
            this.extn_post_offices.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ExtnPostOffices", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.extn_post_offices.EditMask = "####";
            this.extn_post_offices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.extn_post_offices.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.extn_post_offices.Location = new System.Drawing.Point(17, 127);
            this.extn_post_offices.Name = "extn_post_offices";
            this.extn_post_offices.PromptChar = ' ';
            this.extn_post_offices.Size = new System.Drawing.Size(68, 20);
            this.extn_post_offices.TabIndex = 107;
            this.extn_post_offices.Text = "0";
            this.extn_post_offices.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.extn_post_offices.Value = "0";
            // 
            // extn_private_bags
            // 
            this.extn_private_bags.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ExtnPrivateBags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.extn_private_bags.EditMask = "####";
            this.extn_private_bags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.extn_private_bags.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.extn_private_bags.Location = new System.Drawing.Point(17, 108);
            this.extn_private_bags.Name = "extn_private_bags";
            this.extn_private_bags.PromptChar = ' ';
            this.extn_private_bags.Size = new System.Drawing.Size(68, 20);
            this.extn_private_bags.TabIndex = 106;
            this.extn_private_bags.Text = "0";
            this.extn_private_bags.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.extn_private_bags.Value = "0";
            // 
            // extn_no_cmbs
            // 
            this.extn_no_cmbs.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ExtnNoCmbs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.extn_no_cmbs.EditMask = "####";
            this.extn_no_cmbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.extn_no_cmbs.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.extn_no_cmbs.Location = new System.Drawing.Point(17, 147);
            this.extn_no_cmbs.Name = "extn_no_cmbs";
            this.extn_no_cmbs.PromptChar = ' ';
            this.extn_no_cmbs.Size = new System.Drawing.Size(68, 20);
            this.extn_no_cmbs.TabIndex = 108;
            this.extn_no_cmbs.Text = "0";
            this.extn_no_cmbs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.extn_no_cmbs.Value = "0";
            // 
            // extn_no_cmb_customers
            // 
            this.extn_no_cmb_customers.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ExtnNoCmbCustomers", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.extn_no_cmb_customers.EditMask = "####";
            this.extn_no_cmb_customers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.extn_no_cmb_customers.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.extn_no_cmb_customers.Location = new System.Drawing.Point(17, 167);
            this.extn_no_cmb_customers.Name = "extn_no_cmb_customers";
            this.extn_no_cmb_customers.PromptChar = ' ';
            this.extn_no_cmb_customers.Size = new System.Drawing.Size(68, 20);
            this.extn_no_cmb_customers.TabIndex = 109;
            this.extn_no_cmb_customers.Text = "0";
            this.extn_no_cmb_customers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.extn_no_cmb_customers.Value = "0";
            this.extn_no_cmb_customers.Validated += new System.EventHandler(this.TextBox_LostFocus);
            // 
            // gb_2
            // 
            this.gb_2.Controls.Add(this.t_6);
            this.gb_2.Controls.Add(this.private_bags_t);
            this.gb_2.Controls.Add(this.other_bags_t);
            this.gb_2.Controls.Add(this.rural_bags_t);
            this.gb_2.Controls.Add(this.boxes_t);
            this.gb_2.Controls.Add(this.t_13);
            this.gb_2.Controls.Add(this.distance_t);
            this.gb_2.Controls.Add(this.post_offices_t);
            this.gb_2.Controls.Add(this.no_cmbs_t);
            this.gb_2.Controls.Add(this.no_cmb_customers_t);
            this.gb_2.Controls.Add(this.t_14);
            this.gb_2.Controls.Add(this.del_hrs_t);
            this.gb_2.Font = new System.Drawing.Font("Arial", 8F);
            this.gb_2.Location = new System.Drawing.Point(6, 70);
            this.gb_2.Name = "gb_2";
            this.gb_2.Size = new System.Drawing.Size(129, 246);
            this.gb_2.TabIndex = 0;
            this.gb_2.TabStop = false;
            // 
            // t_6
            // 
            this.t_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_6.Location = new System.Drawing.Point(1, 226);
            this.t_6.Name = "t_6";
            this.t_6.Size = new System.Drawing.Size(123, 13);
            this.t_6.TabIndex = 9;
            this.t_6.Text = "Processing Hrs/ Week";
            this.t_6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // private_bags_t
            // 
            this.private_bags_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.private_bags_t.Location = new System.Drawing.Point(12, 111);
            this.private_bags_t.Name = "private_bags_t";
            this.private_bags_t.Size = new System.Drawing.Size(110, 13);
            this.private_bags_t.TabIndex = 8;
            this.private_bags_t.Text = "No. Private Bags";
            this.private_bags_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // other_bags_t
            // 
            this.other_bags_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.other_bags_t.Location = new System.Drawing.Point(12, 92);
            this.other_bags_t.Name = "other_bags_t";
            this.other_bags_t.Size = new System.Drawing.Size(110, 13);
            this.other_bags_t.TabIndex = 7;
            this.other_bags_t.Text = "No.Other Bags";
            this.other_bags_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rural_bags_t
            // 
            this.rural_bags_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rural_bags_t.Location = new System.Drawing.Point(12, 73);
            this.rural_bags_t.Name = "rural_bags_t";
            this.rural_bags_t.Size = new System.Drawing.Size(110, 13);
            this.rural_bags_t.TabIndex = 12;
            this.rural_bags_t.Text = "No. Rural Bags";
            this.rural_bags_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // boxes_t
            // 
            this.boxes_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.boxes_t.Location = new System.Drawing.Point(12, 55);
            this.boxes_t.Name = "boxes_t";
            this.boxes_t.Size = new System.Drawing.Size(110, 13);
            this.boxes_t.TabIndex = 11;
            this.boxes_t.Text = "No. Boxes";
            this.boxes_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_13
            // 
            this.t_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_13.Location = new System.Drawing.Point(12, 35);
            this.t_13.Name = "t_13";
            this.t_13.Size = new System.Drawing.Size(110, 13);
            this.t_13.TabIndex = 10;
            this.t_13.Text = "Frequency Distance";
            this.t_13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // distance_t
            // 
            this.distance_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.distance_t.Location = new System.Drawing.Point(12, 15);
            this.distance_t.Name = "distance_t";
            this.distance_t.Size = new System.Drawing.Size(110, 13);
            this.distance_t.TabIndex = 3;
            this.distance_t.Text = "Annual Distance";
            this.distance_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // post_offices_t
            // 
            this.post_offices_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.post_offices_t.Location = new System.Drawing.Point(12, 131);
            this.post_offices_t.Name = "post_offices_t";
            this.post_offices_t.Size = new System.Drawing.Size(110, 13);
            this.post_offices_t.TabIndex = 2;
            this.post_offices_t.Text = "No. Post Offices";
            this.post_offices_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // no_cmbs_t
            // 
            this.no_cmbs_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.no_cmbs_t.Location = new System.Drawing.Point(12, 150);
            this.no_cmbs_t.Name = "no_cmbs_t";
            this.no_cmbs_t.Size = new System.Drawing.Size(110, 13);
            this.no_cmbs_t.TabIndex = 1;
            this.no_cmbs_t.Text = "No. Cmbs";
            this.no_cmbs_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // no_cmb_customers_t
            // 
            this.no_cmb_customers_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.no_cmb_customers_t.Location = new System.Drawing.Point(12, 169);
            this.no_cmb_customers_t.Name = "no_cmb_customers_t";
            this.no_cmb_customers_t.Size = new System.Drawing.Size(110, 13);
            this.no_cmb_customers_t.TabIndex = 6;
            this.no_cmb_customers_t.Text = "No. Cmb Customers";
            this.no_cmb_customers_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_14
            // 
            this.t_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_14.Location = new System.Drawing.Point(12, 188);
            this.t_14.Name = "t_14";
            this.t_14.Size = new System.Drawing.Size(110, 13);
            this.t_14.TabIndex = 5;
            this.t_14.Text = "Volume";
            this.t_14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // del_hrs_t
            // 
            this.del_hrs_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.del_hrs_t.Location = new System.Drawing.Point(12, 206);
            this.del_hrs_t.Name = "del_hrs_t";
            this.del_hrs_t.Size = new System.Drawing.Size(110, 13);
            this.del_hrs_t.TabIndex = 4;
            this.del_hrs_t.Text = "Delivery Hrs/ Week";
            this.del_hrs_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_title_t
            // 
            this.con_title_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_title_t.Location = new System.Drawing.Point(14, 2);
            this.con_title_t.Name = "con_title_t";
            this.con_title_t.Size = new System.Drawing.Size(72, 13);
            this.con_title_t.TabIndex = 0;
            this.con_title_t.Text = "Contract Title";
            this.con_title_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // con_title
            // 
            this.con_title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.con_title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ConTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.con_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.con_title.Location = new System.Drawing.Point(92, 2);
            this.con_title.MaxLength = 60;
            this.con_title.Name = "con_title";
            this.con_title.ReadOnly = true;
            this.con_title.Size = new System.Drawing.Size(210, 13);
            this.con_title.TabIndex = 0;
            // 
            // t_2
            // 
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_2.Location = new System.Drawing.Point(98, 8);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(108, 26);
            this.t_2.TabIndex = 0;
            this.t_2.Text = "Current Values\r\nfor ALL Frequencies";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_3
            // 
            this.t_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_3.Location = new System.Drawing.Point(212, 8);
            this.t_3.Name = "t_3";
            this.t_3.Size = new System.Drawing.Size(108, 26);
            this.t_3.TabIndex = 0;
            this.t_3.Text = "Increase/ Decrease\r\nfor Frequency";
            this.t_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gb_3
            // 
            this.gb_3.Controls.Add(this.distance);
            this.gb_3.Controls.Add(this.st_daily_distance);
            this.gb_3.Controls.Add(this.boxes);
            this.gb_3.Controls.Add(this.rural_bags);
            this.gb_3.Controls.Add(this.other_bags);
            this.gb_3.Controls.Add(this.private_bags);
            this.gb_3.Controls.Add(this.post_offices);
            this.gb_3.Controls.Add(this.no_cmbs);
            this.gb_3.Controls.Add(this.no_cmb_customers);
            this.gb_3.Controls.Add(this.mail_volume);
            this.gb_3.Controls.Add(this.del_hrs);
            this.gb_3.Controls.Add(this.proc_hrs);
            this.gb_3.Font = new System.Drawing.Font("Arial", 8F);
            this.gb_3.Location = new System.Drawing.Point(133, 70);
            this.gb_3.Name = "gb_3";
            this.gb_3.Size = new System.Drawing.Size(85, 246);
            this.gb_3.TabIndex = 0;
            this.gb_3.TabStop = false;
            // 
            // distance
            // 
            this.distance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.distance.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Distance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.distance.EditMask = "#,##0";
            this.distance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.distance.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.distance.Location = new System.Drawing.Point(8, 15);
            this.distance.Name = "distance";
            this.distance.PromptChar = ' ';
            this.distance.ReadOnly = true;
            this.distance.Size = new System.Drawing.Size(68, 13);
            this.distance.TabIndex = 9;
            this.distance.Text = "0";
            this.distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.distance.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.distance.Value = "0";
            // 
            // st_daily_distance
            // 
            this.st_daily_distance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_daily_distance.Location = new System.Drawing.Point(8, 31);
            this.st_daily_distance.Name = "st_daily_distance";
            this.st_daily_distance.Size = new System.Drawing.Size(68, 20);
            this.st_daily_distance.TabIndex = 8;
            this.st_daily_distance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // boxes
            // 
            this.boxes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boxes.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Boxes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.boxes.EditMask = "#,###";
            this.boxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.boxes.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.boxes.Location = new System.Drawing.Point(8, 55);
            this.boxes.Name = "boxes";
            this.boxes.PromptChar = ' ';
            this.boxes.ReadOnly = true;
            this.boxes.Size = new System.Drawing.Size(68, 13);
            this.boxes.TabIndex = 7;
            this.boxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.boxes.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.boxes.Value = "";
            // 
            // rural_bags
            // 
            this.rural_bags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rural_bags.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RuralBags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rural_bags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rural_bags.Location = new System.Drawing.Point(8, 73);
            this.rural_bags.Name = "rural_bags";
            this.rural_bags.ReadOnly = true;
            this.rural_bags.Size = new System.Drawing.Size(68, 13);
            this.rural_bags.TabIndex = 12;
            this.rural_bags.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // other_bags
            // 
            this.other_bags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.other_bags.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "OtherBags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.other_bags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.other_bags.Location = new System.Drawing.Point(8, 92);
            this.other_bags.Name = "other_bags";
            this.other_bags.ReadOnly = true;
            this.other_bags.Size = new System.Drawing.Size(68, 13);
            this.other_bags.TabIndex = 11;
            this.other_bags.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // private_bags
            // 
            this.private_bags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.private_bags.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PrivateBags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.private_bags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.private_bags.Location = new System.Drawing.Point(8, 111);
            this.private_bags.Name = "private_bags";
            this.private_bags.ReadOnly = true;
            this.private_bags.Size = new System.Drawing.Size(68, 13);
            this.private_bags.TabIndex = 10;
            this.private_bags.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // post_offices
            // 
            this.post_offices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.post_offices.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PostOffices", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.post_offices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.post_offices.Location = new System.Drawing.Point(8, 131);
            this.post_offices.Name = "post_offices";
            this.post_offices.ReadOnly = true;
            this.post_offices.Size = new System.Drawing.Size(68, 13);
            this.post_offices.TabIndex = 3;
            this.post_offices.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // no_cmbs
            // 
            this.no_cmbs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.no_cmbs.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NoCmbs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.no_cmbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.no_cmbs.Location = new System.Drawing.Point(8, 150);
            this.no_cmbs.Name = "no_cmbs";
            this.no_cmbs.ReadOnly = true;
            this.no_cmbs.Size = new System.Drawing.Size(68, 13);
            this.no_cmbs.TabIndex = 2;
            this.no_cmbs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // no_cmb_customers
            // 
            this.no_cmb_customers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.no_cmb_customers.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NoCmbCustomers", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.no_cmb_customers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.no_cmb_customers.Location = new System.Drawing.Point(8, 169);
            this.no_cmb_customers.Name = "no_cmb_customers";
            this.no_cmb_customers.ReadOnly = true;
            this.no_cmb_customers.Size = new System.Drawing.Size(68, 13);
            this.no_cmb_customers.TabIndex = 1;
            this.no_cmb_customers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mail_volume
            // 
            this.mail_volume.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mail_volume.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "MailVolume", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.mail_volume.EditMask = "#,###";
            this.mail_volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.mail_volume.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mail_volume.Location = new System.Drawing.Point(8, 188);
            this.mail_volume.Name = "mail_volume";
            this.mail_volume.PromptChar = ' ';
            this.mail_volume.ReadOnly = true;
            this.mail_volume.Size = new System.Drawing.Size(68, 13);
            this.mail_volume.TabIndex = 6;
            this.mail_volume.Text = "0";
            this.mail_volume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mail_volume.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.mail_volume.Value = "0";
            // 
            // del_hrs
            // 
            this.del_hrs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.del_hrs.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "DelHrs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N2"));
            this.del_hrs.EditMask = "#,##0.00";
            this.del_hrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.del_hrs.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.del_hrs.Location = new System.Drawing.Point(8, 206);
            this.del_hrs.Name = "del_hrs";
            this.del_hrs.PromptChar = ' ';
            this.del_hrs.ReadOnly = true;
            this.del_hrs.Size = new System.Drawing.Size(68, 13);
            this.del_hrs.TabIndex = 5;
            this.del_hrs.Text = "0.00";
            this.del_hrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.del_hrs.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.del_hrs.Value = "0.00";
            // 
            // proc_hrs
            // 
            this.proc_hrs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.proc_hrs.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ProcHrs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N2"));
            this.proc_hrs.EditMask = "#,##0.00";
            this.proc_hrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.proc_hrs.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.proc_hrs.Location = new System.Drawing.Point(8, 226);
            this.proc_hrs.Name = "proc_hrs";
            this.proc_hrs.PromptChar = ' ';
            this.proc_hrs.ReadOnly = true;
            this.proc_hrs.Size = new System.Drawing.Size(68, 13);
            this.proc_hrs.TabIndex = 4;
            this.proc_hrs.Text = "0.00";
            this.proc_hrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.proc_hrs.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.proc_hrs.Value = "0.00";
            // 
            // t_9
            // 
            this.t_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_9.Location = new System.Drawing.Point(2, 18);
            this.t_9.Name = "t_9";
            this.t_9.Size = new System.Drawing.Size(84, 13);
            this.t_9.TabIndex = 0;
            this.t_9.Text = "Effective Date";
            this.t_9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // extn_effective_date
            // 
            this.extn_effective_date.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ExtnEffectiveDate", true));
            this.extn_effective_date.EditMask = null;
            this.extn_effective_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.extn_effective_date.Location = new System.Drawing.Point(92, 18);
            this.extn_effective_date.Mask = "00/00/0000";
            this.extn_effective_date.Name = "extn_effective_date";
            this.extn_effective_date.Size = new System.Drawing.Size(75, 20);
            this.extn_effective_date.TabIndex = 100;
            this.extn_effective_date.Text = "00000000";
            this.extn_effective_date.Value = null;
            this.extn_effective_date.Validating += new System.ComponentModel.CancelEventHandler(this.extn_effective_date_Validating);
            // 
            // t_15
            // 
            this.t_15.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.t_15.Location = new System.Drawing.Point(738, 22);
            this.t_15.Name = "t_15";
            this.t_15.Size = new System.Drawing.Size(104, 15);
            this.t_15.TabIndex = 0;
            this.t_15.Text = "Cust change * 25/60";
            this.t_15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_16
            // 
            this.t_16.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.t_16.Location = new System.Drawing.Point(762, 2);
            this.t_16.Name = "t_16";
            this.t_16.Size = new System.Drawing.Size(80, 15);
            this.t_16.TabIndex = 0;
            this.t_16.Text = "Time/ Day:";
            this.t_16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l1
            // 
            this.l1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.l1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.l1.Location = new System.Drawing.Point(848, 1);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(67, 20);
            this.l1.TabIndex = 0;
            this.l1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // l2
            // 
            this.l2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.l2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.l2.Location = new System.Drawing.Point(848, 22);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(67, 20);
            this.l2.TabIndex = 0;
            this.l2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_17
            // 
            this.t_17.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.t_17.Location = new System.Drawing.Point(762, 46);
            this.t_17.Name = "t_17";
            this.t_17.Size = new System.Drawing.Size(80, 15);
            this.t_17.TabIndex = 0;
            this.t_17.Text = "Day (mins)";
            this.t_17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l3
            // 
            this.l3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.l3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.l3.Location = new System.Drawing.Point(848, 46);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(67, 20);
            this.l3.TabIndex = 0;
            this.l3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_18
            // 
            this.t_18.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.t_18.Location = new System.Drawing.Point(752, 70);
            this.t_18.Name = "t_18";
            this.t_18.Size = new System.Drawing.Size(90, 15);
            this.t_18.TabIndex = 0;
            this.t_18.Text = "Days/ Week";
            this.t_18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // del_days_per_week
            // 
            this.del_days_per_week.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DelDaysPerWeek", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.del_days_per_week.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.del_days_per_week.Location = new System.Drawing.Point(848, 70);
            this.del_days_per_week.Name = "del_days_per_week";
            this.del_days_per_week.Size = new System.Drawing.Size(67, 20);
            this.del_days_per_week.TabIndex = 0;
            this.del_days_per_week.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_19
            // 
            this.t_19.Font = new System.Drawing.Font("Arial", 8F);
            this.t_19.Location = new System.Drawing.Point(811, 93);
            this.t_19.Name = "t_19";
            this.t_19.Size = new System.Drawing.Size(30, 14);
            this.t_19.TabIndex = 0;
            this.t_19.Text = "T&&T";
            this.t_19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tyretubecost
            // 
            this.tyretubecost.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Tyretubecost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tyretubecost.Font = new System.Drawing.Font("Arial", 8F);
            this.tyretubecost.Location = new System.Drawing.Point(848, 94);
            this.tyretubecost.Name = "tyretubecost";
            this.tyretubecost.Size = new System.Drawing.Size(67, 20);
            this.tyretubecost.TabIndex = 0;
            this.tyretubecost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_20
            // 
            this.t_20.Font = new System.Drawing.Font("Arial", 8F);
            this.t_20.Location = new System.Drawing.Point(795, 116);
            this.t_20.Name = "t_20";
            this.t_20.Size = new System.Drawing.Size(46, 14);
            this.t_20.TabIndex = 0;
            this.t_20.Text = "Fuel";
            this.t_20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fuelcost
            // 
            this.fuelcost.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Fuelcost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fuelcost.Font = new System.Drawing.Font("Arial", 8F);
            this.fuelcost.Location = new System.Drawing.Point(848, 117);
            this.fuelcost.Name = "fuelcost";
            this.fuelcost.Size = new System.Drawing.Size(67, 20);
            this.fuelcost.TabIndex = 0;
            this.fuelcost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_21
            // 
            this.t_21.Font = new System.Drawing.Font("Arial", 8F);
            this.t_21.Location = new System.Drawing.Point(798, 138);
            this.t_21.Name = "t_21";
            this.t_21.Size = new System.Drawing.Size(43, 14);
            this.t_21.TabIndex = 0;
            this.t_21.Text = "Rep";
            this.t_21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // repmaintcost
            // 
            this.repmaintcost.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Repmaintcost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.repmaintcost.Font = new System.Drawing.Font("Arial", 8F);
            this.repmaintcost.Location = new System.Drawing.Point(848, 140);
            this.repmaintcost.Name = "repmaintcost";
            this.repmaintcost.Size = new System.Drawing.Size(67, 20);
            this.repmaintcost.TabIndex = 0;
            this.repmaintcost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_22
            // 
            this.t_22.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.t_22.Location = new System.Drawing.Point(748, 162);
            this.t_22.Name = "t_22";
            this.t_22.Size = new System.Drawing.Size(93, 15);
            this.t_22.TabIndex = 0;
            this.t_22.Text = "Vehicle Depr";
            this.t_22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vehicledep
            // 
            this.vehicledep.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Vehicledep", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vehicledep.Font = new System.Drawing.Font("Arial", 8F);
            this.vehicledep.Location = new System.Drawing.Point(848, 162);
            this.vehicledep.Name = "vehicledep";
            this.vehicledep.Size = new System.Drawing.Size(67, 20);
            this.vehicledep.TabIndex = 0;
            this.vehicledep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ndepreciation2
            // 
            this.ndepreciation2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Ndepreciation2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ndepreciation2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.ndepreciation2.Location = new System.Drawing.Point(930, 166);
            this.ndepreciation2.Name = "ndepreciation2";
            this.ndepreciation2.ReadOnly = true;
            this.ndepreciation2.Size = new System.Drawing.Size(45, 18);
            this.ndepreciation2.TabIndex = 0;
            // 
            // compute_2
            // 
            this.compute_2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_2.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_2.Location = new System.Drawing.Point(848, 188);
            this.compute_2.Name = "compute_2";
            this.compute_2.Size = new System.Drawing.Size(67, 20);
            this.compute_2.TabIndex = 0;
            this.compute_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_23
            // 
            this.t_23.Font = new System.Drawing.Font("Arial Narrow", 7F);
            this.t_23.Location = new System.Drawing.Point(781, 222);
            this.t_23.Name = "t_23";
            this.t_23.Size = new System.Drawing.Size(60, 13);
            this.t_23.TabIndex = 0;
            this.t_23.Text = "Processing cost";
            this.t_23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // proccost
            // 
            this.proccost.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Proccost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.proccost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.proccost.Location = new System.Drawing.Point(848, 221);
            this.proccost.Name = "proccost";
            this.proccost.Size = new System.Drawing.Size(67, 18);
            this.proccost.TabIndex = 0;
            this.proccost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_24
            // 
            this.t_24.Font = new System.Drawing.Font("Arial Narrow", 7F);
            this.t_24.Location = new System.Drawing.Point(779, 248);
            this.t_24.Name = "t_24";
            this.t_24.Size = new System.Drawing.Size(62, 13);
            this.t_24.TabIndex = 0;
            this.t_24.Text = "Delivery cost";
            this.t_24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // delcost
            // 
            this.delcost.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Delcost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.delcost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.delcost.Location = new System.Drawing.Point(848, 242);
            this.delcost.Name = "delcost";
            this.delcost.Size = new System.Drawing.Size(67, 18);
            this.delcost.TabIndex = 0;
            this.delcost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_26
            // 
            this.t_26.Font = new System.Drawing.Font("Arial Narrow", 7F);
            this.t_26.Location = new System.Drawing.Point(778, 269);
            this.t_26.Name = "t_26";
            this.t_26.Size = new System.Drawing.Size(60, 13);
            this.t_26.TabIndex = 0;
            this.t_26.Text = "ACCcost";
            this.t_26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // acccost
            // 
            this.acccost.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Acccost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.acccost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.acccost.Location = new System.Drawing.Point(849, 265);
            this.acccost.Name = "acccost";
            this.acccost.Size = new System.Drawing.Size(67, 18);
            this.acccost.TabIndex = 0;
            this.acccost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // compute_3
            // 
            this.compute_3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.compute_3.Location = new System.Drawing.Point(848, 290);
            this.compute_3.Name = "compute_3";
            this.compute_3.Size = new System.Drawing.Size(67, 18);
            this.compute_3.TabIndex = 0;
            this.compute_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_27
            // 
            this.t_27.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.t_27.Location = new System.Drawing.Point(921, 289);
            this.t_27.Name = "t_27";
            this.t_27.Size = new System.Drawing.Size(78, 15);
            this.t_27.TabIndex = 0;
            this.t_27.Text = "Insurance %";
            this.t_27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ninsurancepct
            // 
            this.ninsurancepct.BackColor = System.Drawing.Color.Yellow;
            this.ninsurancepct.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Ninsurancepct", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ninsurancepct.Font = new System.Drawing.Font("Arial", 8F);
            this.ninsurancepct.Location = new System.Drawing.Point(1004, 289);
            this.ninsurancepct.Name = "ninsurancepct";
            this.ninsurancepct.ReadOnly = true;
            this.ninsurancepct.Size = new System.Drawing.Size(46, 20);
            this.ninsurancepct.TabIndex = 0;
            this.ninsurancepct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_29
            // 
            this.t_29.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.t_29.Location = new System.Drawing.Point(939, 312);
            this.t_29.Name = "t_29";
            this.t_29.Size = new System.Drawing.Size(60, 15);
            this.t_29.TabIndex = 0;
            this.t_29.Text = "Livery $";
            this.t_29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nlivery
            // 
            this.nlivery.BackColor = System.Drawing.Color.Yellow;
            this.nlivery.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Nlivery", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nlivery.Font = new System.Drawing.Font("Arial", 8F);
            this.nlivery.Location = new System.Drawing.Point(1004, 312);
            this.nlivery.Name = "nlivery";
            this.nlivery.ReadOnly = true;
            this.nlivery.Size = new System.Drawing.Size(45, 20);
            this.nlivery.TabIndex = 0;
            this.nlivery.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_30
            // 
            this.t_30.Font = new System.Drawing.Font("Arial Narrow", 7F);
            this.t_30.Location = new System.Drawing.Point(766, 346);
            this.t_30.Name = "t_30";
            this.t_30.Size = new System.Drawing.Size(75, 13);
            this.t_30.TabIndex = 0;
            this.t_30.Text = "RUC  Cost";
            this.t_30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ruccost
            // 
            this.ruccost.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Ruccost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ruccost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.ruccost.Location = new System.Drawing.Point(846, 345);
            this.ruccost.Name = "ruccost";
            this.ruccost.Size = new System.Drawing.Size(67, 18);
            this.ruccost.TabIndex = 0;
            // 
            // t_31
            // 
            this.t_31.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.t_31.Location = new System.Drawing.Point(928, 338);
            this.t_31.Name = "t_31";
            this.t_31.Size = new System.Drawing.Size(72, 15);
            this.t_31.TabIndex = 0;
            this.t_31.Text = "Uniform $";
            this.t_31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nuniform
            // 
            this.nuniform.BackColor = System.Drawing.Color.Yellow;
            this.nuniform.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Nuniform", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nuniform.Font = new System.Drawing.Font("Arial", 8F);
            this.nuniform.Location = new System.Drawing.Point(1004, 334);
            this.nuniform.Name = "nuniform";
            this.nuniform.ReadOnly = true;
            this.nuniform.Size = new System.Drawing.Size(46, 20);
            this.nuniform.TabIndex = 0;
            this.nuniform.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_32
            // 
            this.t_32.Font = new System.Drawing.Font("Arial Narrow", 7F);
            this.t_32.Location = new System.Drawing.Point(770, 369);
            this.t_32.Name = "t_32";
            this.t_32.Size = new System.Drawing.Size(72, 13);
            this.t_32.TabIndex = 0;
            this.t_32.Text = "RUC Rate";
            this.t_32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nruc
            // 
            this.nruc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Nruc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.nruc.Location = new System.Drawing.Point(848, 368);
            this.nruc.Name = "nruc";
            this.nruc.ReadOnly = true;
            this.nruc.Size = new System.Drawing.Size(67, 18);
            this.nruc.TabIndex = 0;
            // 
            // t_33
            // 
            this.t_33.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.t_33.Location = new System.Drawing.Point(956, 360);
            this.t_33.Name = "t_33";
            this.t_33.Size = new System.Drawing.Size(43, 15);
            this.t_33.TabIndex = 0;
            this.t_33.Text = "ACC $";
            this.t_33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // naccamounts
            // 
            this.naccamounts.BackColor = System.Drawing.Color.Yellow;
            this.naccamounts.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Naccamounts", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.naccamounts.Font = new System.Drawing.Font("Arial", 8F);
            this.naccamounts.Location = new System.Drawing.Point(1004, 358);
            this.naccamounts.Name = "naccamounts";
            this.naccamounts.ReadOnly = true;
            this.naccamounts.Size = new System.Drawing.Size(45, 20);
            this.naccamounts.TabIndex = 0;
            this.naccamounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gb_4
            // 
            this.gb_4.Controls.Add(this.t_2);
            this.gb_4.Controls.Add(this.t_3);
            this.gb_4.Font = new System.Drawing.Font("Arial", 8F);
            this.gb_4.Location = new System.Drawing.Point(6, 37);
            this.gb_4.Name = "gb_4";
            this.gb_4.Size = new System.Drawing.Size(325, 39);
            this.gb_4.TabIndex = 0;
            this.gb_4.TabStop = false;
            this.gb_4.Text = "Parameters";
            // 
            // accrate
            // 
            this.accrate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Accrate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.accrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.accrate.Location = new System.Drawing.Point(1002, 269);
            this.accrate.Name = "accrate";
            this.accrate.ReadOnly = true;
            this.accrate.Size = new System.Drawing.Size(45, 18);
            this.accrate.TabIndex = 0;
            // 
            // t_34
            // 
            this.t_34.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.t_34.Location = new System.Drawing.Point(713, 292);
            this.t_34.Name = "t_34";
            this.t_34.Size = new System.Drawing.Size(130, 11);
            this.t_34.TabIndex = 0;
            this.t_34.Text = "processing + delivery + ACC";
            this.t_34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_35
            // 
            this.t_35.Font = new System.Drawing.Font("Arial Narrow", 7F);
            this.t_35.Location = new System.Drawing.Point(954, 269);
            this.t_35.Name = "t_35";
            this.t_35.Size = new System.Drawing.Size(45, 13);
            this.t_35.TabIndex = 0;
            this.t_35.Text = "ACC rate";
            this.t_35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_5
            // 
            this.gb_5.Controls.Add(this.t_4);
            this.gb_5.Controls.Add(this.cust_change);
            this.gb_5.Controls.Add(this.t_5);
            this.gb_5.Controls.Add(this.volume_customer);
            this.gb_5.Controls.Add(this.t_7);
            this.gb_5.Controls.Add(this.volume_change);
            this.gb_5.Controls.Add(this.t_8);
            this.gb_5.Controls.Add(this.proc_hrs_change);
            this.gb_5.Controls.Add(this.t_10);
            this.gb_5.Controls.Add(this.t_11);
            this.gb_5.Controls.Add(this.t_12);
            this.gb_5.Controls.Add(this.t_36);
            this.gb_5.Controls.Add(this.extnamnt);
            this.gb_5.Controls.Add(this.t_37);
            this.gb_5.Controls.Add(this.extnamount);
            this.gb_5.Controls.Add(this.t_38);
            this.gb_5.Controls.Add(this.l_6);
            this.gb_5.Controls.Add(this.l_7);
            this.gb_5.Controls.Add(this.compute_4);
            this.gb_5.Font = new System.Drawing.Font("Arial", 8F);
            this.gb_5.Location = new System.Drawing.Point(336, 37);
            this.gb_5.Name = "gb_5";
            this.gb_5.Size = new System.Drawing.Size(275, 166);
            this.gb_5.TabIndex = 0;
            this.gb_5.TabStop = false;
            this.gb_5.Text = "Net Effect on Renewal";
            // 
            // t_4
            // 
            this.t_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_4.Location = new System.Drawing.Point(115, 16);
            this.t_4.Name = "t_4";
            this.t_4.Size = new System.Drawing.Size(56, 13);
            this.t_4.TabIndex = 121;
            this.t_4.Text = "Customers";
            this.t_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cust_change
            // 
            this.cust_change.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cust_change.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CustChange", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N2"));
            this.cust_change.EditMask = "#,##0";
            this.cust_change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cust_change.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.cust_change.Location = new System.Drawing.Point(173, 16);
            this.cust_change.Name = "cust_change";
            this.cust_change.PromptChar = ' ';
            this.cust_change.ReadOnly = true;
            this.cust_change.Size = new System.Drawing.Size(45, 13);
            this.cust_change.TabIndex = 122;
            this.cust_change.Text = "0";
            this.cust_change.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cust_change.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.cust_change.Value = "0";
            // 
            // t_5
            // 
            this.t_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_5.Location = new System.Drawing.Point(70, 35);
            this.t_5.Name = "t_5";
            this.t_5.Size = new System.Drawing.Size(99, 13);
            this.t_5.TabIndex = 119;
            this.t_5.Text = "Volume/ Customer";
            this.t_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // volume_customer
            // 
            this.volume_customer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.volume_customer.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VolumeCustomer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.volume_customer.EditMask = "#,##0";
            this.volume_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.volume_customer.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.volume_customer.Location = new System.Drawing.Point(173, 34);
            this.volume_customer.Name = "volume_customer";
            this.volume_customer.PromptChar = ' ';
            this.volume_customer.ReadOnly = true;
            this.volume_customer.Size = new System.Drawing.Size(45, 13);
            this.volume_customer.TabIndex = 120;
            this.volume_customer.Text = "0";
            this.volume_customer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.volume_customer.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.volume_customer.Value = "0";
            // 
            // t_7
            // 
            this.t_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_7.Location = new System.Drawing.Point(14, 53);
            this.t_7.Name = "t_7";
            this.t_7.Size = new System.Drawing.Size(152, 13);
            this.t_7.TabIndex = 125;
            this.t_7.Text = "Volume Increase/ Decrease";
            this.t_7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // volume_change
            // 
            this.volume_change.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.volume_change.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "VolumeChange", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.volume_change.EditMask = "#,##0";
            this.volume_change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.volume_change.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.volume_change.Location = new System.Drawing.Point(173, 53);
            this.volume_change.Name = "volume_change";
            this.volume_change.PromptChar = ' ';
            this.volume_change.ReadOnly = true;
            this.volume_change.Size = new System.Drawing.Size(45, 13);
            this.volume_change.TabIndex = 126;
            this.volume_change.Text = "0";
            this.volume_change.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.volume_change.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.volume_change.Value = "0";
            // 
            // t_8
            // 
            this.t_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_8.Location = new System.Drawing.Point(70, 73);
            this.t_8.Name = "t_8";
            this.t_8.Size = new System.Drawing.Size(94, 13);
            this.t_8.TabIndex = 123;
            this.t_8.Text = "Processing Hours";
            this.t_8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // proc_hrs_change
            // 
            this.proc_hrs_change.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.proc_hrs_change.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ProcHrsChange", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N2"));
            this.proc_hrs_change.EditMask = "#,##0.00";
            this.proc_hrs_change.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.proc_hrs_change.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.proc_hrs_change.Location = new System.Drawing.Point(173, 73);
            this.proc_hrs_change.Name = "proc_hrs_change";
            this.proc_hrs_change.PromptChar = ' ';
            this.proc_hrs_change.ReadOnly = true;
            this.proc_hrs_change.Size = new System.Drawing.Size(45, 13);
            this.proc_hrs_change.TabIndex = 124;
            this.proc_hrs_change.Text = "0.00";
            this.proc_hrs_change.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.proc_hrs_change.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.proc_hrs_change.Value = "0.00";
            // 
            // t_10
            // 
            this.t_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_10.Location = new System.Drawing.Point(221, 73);
            this.t_10.Name = "t_10";
            this.t_10.Size = new System.Drawing.Size(45, 13);
            this.t_10.TabIndex = 113;
            this.t_10.Text = "/Week";
            this.t_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t_11
            // 
            this.t_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_11.Location = new System.Drawing.Point(222, 53);
            this.t_11.Name = "t_11";
            this.t_11.Size = new System.Drawing.Size(38, 13);
            this.t_11.TabIndex = 114;
            this.t_11.Text = "/Year";
            this.t_11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t_12
            // 
            this.t_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_12.Location = new System.Drawing.Point(222, 35);
            this.t_12.Name = "t_12";
            this.t_12.Size = new System.Drawing.Size(38, 13);
            this.t_12.TabIndex = 111;
            this.t_12.Text = "/Year";
            this.t_12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t_36
            // 
            this.t_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_36.Location = new System.Drawing.Point(42, 96);
            this.t_36.Name = "t_36";
            this.t_36.Size = new System.Drawing.Size(107, 13);
            this.t_36.TabIndex = 112;
            this.t_36.Text = "Benchmark Change";
            this.t_36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // extnamnt
            // 
            this.extnamnt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.extnamnt.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Extnamnt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N2"));
            this.extnamnt.EditMask = "#,##0.00";
            this.extnamnt.Font = new System.Drawing.Font("Arial", 8F);
            this.extnamnt.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.extnamnt.Location = new System.Drawing.Point(157, 96);
            this.extnamnt.Name = "extnamnt";
            this.extnamnt.PromptChar = ' ';
            this.extnamnt.ReadOnly = true;
            this.extnamnt.Size = new System.Drawing.Size(61, 13);
            this.extnamnt.TabIndex = 117;
            this.extnamnt.Text = "0.00";
            this.extnamnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.extnamnt.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.extnamnt.Value = "0.00";
            // 
            // t_37
            // 
            this.t_37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_37.Location = new System.Drawing.Point(62, 120);
            this.t_37.Name = "t_37";
            this.t_37.Size = new System.Drawing.Size(85, 13);
            this.t_37.TabIndex = 118;
            this.t_37.Text = "- Amount to Pay";
            this.t_37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // extnamount
            // 
            this.extnamount.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Extnamount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N2"));
            this.extnamount.EditMask = "###,###.##";
            this.extnamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.extnamount.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.extnamount.Location = new System.Drawing.Point(159, 118);
            this.extnamount.Name = "extnamount";
            this.extnamount.PromptChar = ' ';
            this.extnamount.Size = new System.Drawing.Size(61, 20);
            this.extnamount.TabIndex = 127;
            this.extnamount.Text = "0.00";
            this.extnamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.extnamount.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.extnamount.Value = "0.00";
            this.extnamount.Validated += new System.EventHandler(this.TextBox_LostFocus);
            // 
            // t_38
            // 
            this.t_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_38.Location = new System.Drawing.Point(89, 147);
            this.t_38.Name = "t_38";
            this.t_38.Size = new System.Drawing.Size(56, 13);
            this.t_38.TabIndex = 115;
            this.t_38.Text = "Difference";
            this.t_38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l_6
            // 
            this.l_6.BackColor = System.Drawing.Color.Black;
            this.l_6.Location = new System.Drawing.Point(60, 140);
            this.l_6.Name = "l_6";
            this.l_6.Size = new System.Drawing.Size(160, 1);
            this.l_6.TabIndex = 128;
            // 
            // l_7
            // 
            this.l_7.BackColor = System.Drawing.Color.Black;
            this.l_7.Location = new System.Drawing.Point(60, 142);
            this.l_7.Name = "l_7";
            this.l_7.Size = new System.Drawing.Size(160, 1);
            this.l_7.TabIndex = 129;
            // 
            // compute_4
            // 
            this.compute_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_4.Location = new System.Drawing.Point(157, 147);
            this.compute_4.Name = "compute_4";
            this.compute_4.ReadOnly = true;
            this.compute_4.Size = new System.Drawing.Size(61, 13);
            this.compute_4.TabIndex = 116;
            this.compute_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gb_6
            // 
            this.gb_6.Controls.Add(this.extn_reason);
            this.gb_6.Controls.Add(this.t_39);
            this.gb_6.Font = new System.Drawing.Font("Arial", 8F);
            this.gb_6.Location = new System.Drawing.Point(336, 203);
            this.gb_6.Name = "gb_6";
            this.gb_6.Size = new System.Drawing.Size(275, 113);
            this.gb_6.TabIndex = 0;
            this.gb_6.TabStop = false;
            this.gb_6.Text = "Reason";
            // 
            // extn_reason
            // 
            this.extn_reason.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ExtnReason", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.extn_reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.extn_reason.Location = new System.Drawing.Point(6, 19);
            this.extn_reason.MaxLength = 100;
            this.extn_reason.Name = "extn_reason";
            this.extn_reason.Size = new System.Drawing.Size(254, 50);
            this.extn_reason.TabIndex = 121;
            this.extn_reason.Text = "";
            // 
            // t_39
            // 
            this.t_39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_39.Location = new System.Drawing.Point(6, 70);
            this.t_39.Name = "t_39";
            this.t_39.Size = new System.Drawing.Size(235, 38);
            this.t_39.TabIndex = 0;
            this.t_39.Text = "Please use standard format\r\nie Limit upper case use.\r\nKeep brief!";
            this.t_39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nuse_rucs
            // 
            this.nuse_rucs.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NuseRucs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nuse_rucs.Font = new System.Drawing.Font("Arial", 8F);
            this.nuse_rucs.Location = new System.Drawing.Point(941, 37);
            this.nuse_rucs.Name = "nuse_rucs";
            this.nuse_rucs.ReadOnly = true;
            this.nuse_rucs.Size = new System.Drawing.Size(50, 20);
            this.nuse_rucs.TabIndex = 0;
            // 
            // t_28
            // 
            this.t_28.Font = new System.Drawing.Font("Arial Narrow", 7F);
            this.t_28.Location = new System.Drawing.Point(808, 314);
            this.t_28.Name = "t_28";
            this.t_28.Size = new System.Drawing.Size(33, 13);
            this.t_28.TabIndex = 0;
            this.t_28.Text = "Freq";
            this.t_28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // no_del_days_year
            // 
            this.no_del_days_year.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "NoDelDaysYear", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.no_del_days_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.no_del_days_year.Location = new System.Drawing.Point(848, 316);
            this.no_del_days_year.Name = "no_del_days_year";
            this.no_del_days_year.ReadOnly = true;
            this.no_del_days_year.Size = new System.Drawing.Size(67, 18);
            this.no_del_days_year.TabIndex = 0;
            // 
            // t_25
            // 
            this.t_25.Font = new System.Drawing.Font("Arial", 8F);
            this.t_25.Location = new System.Drawing.Point(921, 192);
            this.t_25.Name = "t_25";
            this.t_25.Size = new System.Drawing.Size(73, 14);
            this.t_25.TabIndex = 0;
            this.t_25.Text = "extn amount";
            this.t_25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // extnamnt1
            // 
            this.extnamnt1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Extnamnt1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.extnamnt1.Font = new System.Drawing.Font("Arial", 8F);
            this.extnamnt1.Location = new System.Drawing.Point(1006, 192);
            this.extnamnt1.Name = "extnamnt1";
            this.extnamnt1.Size = new System.Drawing.Size(61, 20);
            this.extnamnt1.TabIndex = 0;
            this.extnamnt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // extnamnt_original
            // 
            this.extnamnt_original.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ExtnamntOriginal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.extnamnt_original.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.extnamnt_original.Location = new System.Drawing.Point(1008, 168);
            this.extnamnt_original.Name = "extnamnt_original";
            this.extnamnt_original.Size = new System.Drawing.Size(66, 20);
            this.extnamnt_original.TabIndex = 0;
            // 
            // t_40
            // 
            this.t_40.Font = new System.Drawing.Font("Arial Narrow", 7F);
            this.t_40.Location = new System.Drawing.Point(928, 224);
            this.t_40.Name = "t_40";
            this.t_40.Size = new System.Drawing.Size(62, 13);
            this.t_40.TabIndex = 0;
            this.t_40.Text = "Relief cost";
            this.t_40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // reliefcost
            // 
            this.reliefcost.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Reliefcost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.reliefcost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.reliefcost.Location = new System.Drawing.Point(992, 225);
            this.reliefcost.Name = "reliefcost";
            this.reliefcost.Size = new System.Drawing.Size(67, 18);
            this.reliefcost.TabIndex = 0;
            this.reliefcost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // reliefweeks
            // 
            this.reliefweeks.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Reliefweeks", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.reliefweeks.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.reliefweeks.Location = new System.Drawing.Point(1006, 102);
            this.reliefweeks.Name = "reliefweeks";
            this.reliefweeks.Size = new System.Drawing.Size(68, 18);
            this.reliefweeks.TabIndex = 102;
            this.reliefweeks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DExtension2005
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reliefweeks);
            this.Controls.Add(this.gb_6);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.gb_4);
            this.Controls.Add(this.gb_3);
            this.Controls.Add(this.gb_2);
            this.Controls.Add(this.gb_1);
            this.Controls.Add(this.con_title_t);
            this.Controls.Add(this.con_title);
            this.Controls.Add(this.t_9);
            this.Controls.Add(this.extn_effective_date);
            this.Controls.Add(this.t_15);
            this.Controls.Add(this.t_16);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.l2);
            this.Controls.Add(this.t_17);
            this.Controls.Add(this.l3);
            this.Controls.Add(this.t_18);
            this.Controls.Add(this.del_days_per_week);
            this.Controls.Add(this.t_19);
            this.Controls.Add(this.tyretubecost);
            this.Controls.Add(this.t_20);
            this.Controls.Add(this.fuelcost);
            this.Controls.Add(this.t_21);
            this.Controls.Add(this.repmaintcost);
            this.Controls.Add(this.t_22);
            this.Controls.Add(this.vehicledep);
            this.Controls.Add(this.ndepreciation2);
            this.Controls.Add(this.compute_2);
            this.Controls.Add(this.t_23);
            this.Controls.Add(this.proccost);
            this.Controls.Add(this.t_24);
            this.Controls.Add(this.delcost);
            this.Controls.Add(this.t_26);
            this.Controls.Add(this.acccost);
            this.Controls.Add(this.compute_3);
            this.Controls.Add(this.t_27);
            this.Controls.Add(this.ninsurancepct);
            this.Controls.Add(this.t_29);
            this.Controls.Add(this.nlivery);
            this.Controls.Add(this.t_30);
            this.Controls.Add(this.ruccost);
            this.Controls.Add(this.t_31);
            this.Controls.Add(this.nuniform);
            this.Controls.Add(this.t_32);
            this.Controls.Add(this.nruc);
            this.Controls.Add(this.t_33);
            this.Controls.Add(this.naccamounts);
            this.Controls.Add(this.accrate);
            this.Controls.Add(this.t_34);
            this.Controls.Add(this.t_35);
            this.Controls.Add(this.gb_5);
            this.Controls.Add(this.nuse_rucs);
            this.Controls.Add(this.t_28);
            this.Controls.Add(this.no_del_days_year);
            this.Controls.Add(this.t_25);
            this.Controls.Add(this.extnamnt1);
            this.Controls.Add(this.extnamnt_original);
            this.Controls.Add(this.t_40);
            this.Controls.Add(this.reliefcost);
            this.Name = "DExtension2005";
            this.Size = new System.Drawing.Size(638, 401);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.gb_1.ResumeLayout(false);
            this.gb_1.PerformLayout();
            this.gb_2.ResumeLayout(false);
            this.gb_3.ResumeLayout(false);
            this.gb_3.PerformLayout();
            this.gb_4.ResumeLayout(false);
            this.gb_5.ResumeLayout(false);
            this.gb_5.PerformLayout();
            this.gb_6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void DExtension2005_Format(object sender, ConvertEventArgs e)
        {
            this.extn_effective_date.Tag = this.extn_effective_date.Text;
        }

        public event System.ComponentModel.CancelEventHandler extn_effective_date_change;
       
        void extn_effective_date_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            extn_effective_date_change(sender, e);
            if (e.Cancel == true)
            {
                //!this.extn_effective_date.Text = this.extn_effective_date.Tag as string;                
                //e.Cancel = true;
            }
            else
            {
                this.extn_effective_date.Tag = this.extn_effective_date.Text;
                
            }
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (this.RowCount == 0)
            {
                return;
            }
            if (this.GetValue<decimal?>(e.NewIndex, "volume_change").GetValueOrDefault() == 0)
            {
                this.t_11.Visible = false;
            }
            else
            {
                this.t_11.Visible = true;
            }
            if (this.GetItem<Extension2005>(e.NewIndex).ProcHrsChange.GetValueOrDefault() == 0)
            {
                this.t_10.Visible = false;
            }
            else
            {
                this.t_10.Visible = true;
            }
        }

        #endregion

        private System.Windows.Forms.GroupBox gb_1;
        private System.Windows.Forms.GroupBox gb_2;
        private System.Windows.Forms.Label con_title_t;
        private System.Windows.Forms.TextBox con_title;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.Label t_3;
        private System.Windows.Forms.GroupBox gb_3;
        private System.Windows.Forms.Label t_9;
        private NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox extn_effective_date;
        //!private DateTimePicker extn_effective_date;
        private System.Windows.Forms.Label t_15;
        private System.Windows.Forms.Label t_16;
        private System.Windows.Forms.TextBox l1;
        private System.Windows.Forms.TextBox l2;
        private System.Windows.Forms.Label t_17;
        private System.Windows.Forms.TextBox l3;
        private System.Windows.Forms.Label t_18;
        private System.Windows.Forms.TextBox del_days_per_week;
        private System.Windows.Forms.Label t_19;
        private System.Windows.Forms.TextBox tyretubecost;
        private System.Windows.Forms.Label t_20;
        private System.Windows.Forms.TextBox fuelcost;
        private System.Windows.Forms.Label t_21;
        private System.Windows.Forms.TextBox repmaintcost;
        private System.Windows.Forms.Label t_22;
        private System.Windows.Forms.TextBox vehicledep;
        private System.Windows.Forms.TextBox ndepreciation2;
        private System.Windows.Forms.TextBox compute_2;
        private System.Windows.Forms.Label t_23;
        private System.Windows.Forms.TextBox proccost;
        private System.Windows.Forms.Label t_24;
        private System.Windows.Forms.TextBox delcost;
        private System.Windows.Forms.Label t_26;
        private System.Windows.Forms.TextBox acccost;
        private System.Windows.Forms.TextBox compute_3;
        private System.Windows.Forms.Label t_27;
        private System.Windows.Forms.TextBox ninsurancepct;
        private System.Windows.Forms.Label t_29;
        private System.Windows.Forms.TextBox nlivery;
        private System.Windows.Forms.Label t_30;
        private System.Windows.Forms.TextBox ruccost;
        private System.Windows.Forms.Label t_31;
        private System.Windows.Forms.TextBox nuniform;
        private System.Windows.Forms.Label t_32;
        private System.Windows.Forms.TextBox nruc;
        private System.Windows.Forms.Label t_33;
        private System.Windows.Forms.TextBox naccamounts;
        private System.Windows.Forms.GroupBox gb_4;
        private System.Windows.Forms.TextBox accrate;
        private System.Windows.Forms.Label t_34;
        private System.Windows.Forms.Label t_35;
        private System.Windows.Forms.GroupBox gb_5;
        private System.Windows.Forms.GroupBox gb_6;
        private System.Windows.Forms.Label t_39;
        private System.Windows.Forms.TextBox nuse_rucs;
        private System.Windows.Forms.Label t_28;
        private System.Windows.Forms.TextBox no_del_days_year;
        private System.Windows.Forms.Label t_25;
        private System.Windows.Forms.TextBox extnamnt1;
        private System.Windows.Forms.TextBox extnamnt_original;
        private System.Windows.Forms.Label t_40;
        private System.Windows.Forms.TextBox reliefcost;
        private System.Windows.Forms.Label t_4;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox cust_change;
        private System.Windows.Forms.Label t_5;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox volume_customer;
        private System.Windows.Forms.Label t_7;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox volume_change;
        private System.Windows.Forms.Label t_8;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox proc_hrs_change;
        private System.Windows.Forms.Label t_10;
        private System.Windows.Forms.Label t_11;
        private System.Windows.Forms.Label t_12;
        private System.Windows.Forms.Label t_36;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox extnamnt;
        private System.Windows.Forms.Label t_37;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox extnamount;
        private System.Windows.Forms.Label t_38;
        private System.Windows.Forms.TextBox compute_4;//NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox compute_4;
        private System.Windows.Forms.RichTextBox extn_reason;
        private System.Windows.Forms.Label t_6;
        private System.Windows.Forms.Label private_bags_t;
        private System.Windows.Forms.Label other_bags_t;
        private System.Windows.Forms.Label rural_bags_t;
        private System.Windows.Forms.Label boxes_t;
        private System.Windows.Forms.Label t_13;
        private System.Windows.Forms.Label distance_t;
        private System.Windows.Forms.Label post_offices_t;
        private System.Windows.Forms.Label no_cmbs_t;
        private System.Windows.Forms.Label no_cmb_customers_t;
        private System.Windows.Forms.Label t_14;
        private System.Windows.Forms.Label del_hrs_t;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox distance;
        private System.Windows.Forms.Label st_daily_distance;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox boxes;
        private System.Windows.Forms.TextBox rural_bags;
        private System.Windows.Forms.TextBox other_bags;
        private System.Windows.Forms.TextBox private_bags;
        private System.Windows.Forms.TextBox post_offices;
        private System.Windows.Forms.TextBox no_cmbs;
        private System.Windows.Forms.TextBox no_cmb_customers;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox mail_volume;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox del_hrs;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox proc_hrs;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox compute_1;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox extn_distance;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox extn_boxes;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox extn_del_hrs;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox extn_rural_bags;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox extn_other_bags;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox extn_post_offices;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox extn_private_bags;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox extn_no_cmbs;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox extn_no_cmb_customers;
        private System.Windows.Forms.Panel l_6;
        private System.Windows.Forms.Panel l_7;
        private System.Windows.Forms.Label t_1;
        private TextBox reliefweeks;
    }
}

