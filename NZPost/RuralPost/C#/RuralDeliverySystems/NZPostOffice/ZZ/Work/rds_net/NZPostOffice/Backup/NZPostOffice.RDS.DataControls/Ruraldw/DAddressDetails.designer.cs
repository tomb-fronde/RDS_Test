using NZPostOffice.RDS.Entity.Ruraldw;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DAddressDetails
    {
        // TJB 22-Feb-2012 Release 7.1.7 fixups
        // Made contract_no ReadOnly

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DAddressDetails));
            this.post_code_id_t = new System.Windows.Forms.Label();
            this.post_code = new System.Windows.Forms.TextBox();
            this.adr_property_identification_t = new System.Windows.Forms.Label();
            this.adr_property_identification = new System.Windows.Forms.TextBox();
            this.town_name = new System.Windows.Forms.TextBox();
            this.title_address = new System.Windows.Forms.TextBox();
            this.adr_no_t = new System.Windows.Forms.Label();
            this.adr_num = new System.Windows.Forms.TextBox();
            this.road_id_t = new System.Windows.Forms.Label();
            this.sl_id_t = new System.Windows.Forms.Label();
            this.adr_rd_no_t = new System.Windows.Forms.Label();
            this.adr_rd_no = new System.Windows.Forms.TextBox();
            this.tc_id_t = new System.Windows.Forms.Label();
            this.tc_id = new Metex.Windows.DataEntityCombo();
            this.adr_id = new System.Windows.Forms.TextBox();
            this.dp_id_t = new System.Windows.Forms.Label();
            this.dp_id = new System.Windows.Forms.TextBox();
            this.adr_id_t = new System.Windows.Forms.Label();
            this.rt_id = new Metex.Windows.DataEntityCombo();
            this.t_4 = new System.Windows.Forms.Label();
            this.rs_id = new Metex.Windows.DataEntityCombo();
            this.road_suffix_t = new System.Windows.Forms.Label();
            this.contract_no_t = new System.Windows.Forms.Label();
            this.contract_no = new System.Windows.Forms.MaskedTextBox();
            this.contract_button = new System.Windows.Forms.PictureBox();
            this.gb_1 = new System.Windows.Forms.GroupBox();
            this.t_1 = new System.Windows.Forms.Label();
            this.mon = new System.Windows.Forms.TextBox();
            this.days = new System.Windows.Forms.TextBox();
            this.tue = new System.Windows.Forms.TextBox();
            this.wed = new System.Windows.Forms.TextBox();
            this.thur = new System.Windows.Forms.TextBox();
            this.fri = new System.Windows.Forms.TextBox();
            this.sat = new System.Windows.Forms.TextBox();
            this.sunday = new System.Windows.Forms.TextBox();
            this.gb_2 = new System.Windows.Forms.GroupBox();
            this.t_2 = new System.Windows.Forms.Label();
            this.compute_1 = new System.Windows.Forms.TextBox();
            this.compute_2 = new System.Windows.Forms.TextBox();
            this.compute_3 = new System.Windows.Forms.TextBox();
            this.compute_4 = new System.Windows.Forms.TextBox();
            this.compute_5 = new System.Windows.Forms.TextBox();
            this.compute_6 = new System.Windows.Forms.TextBox();
            this.compute_7 = new System.Windows.Forms.TextBox();
            this.compute_8 = new System.Windows.Forms.TextBox();
            this.road_name = new System.Windows.Forms.TextBox();
            this.sl_name = new Metex.Windows.DataEntityCombo();
            this.location_ind = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tc_name = new System.Windows.Forms.TextBox();
            this.rt_name = new System.Windows.Forms.TextBox();
            this.rs_name = new System.Windows.Forms.TextBox();
            this.adr_sl_name = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contract_button)).BeginInit();
            this.gb_1.SuspendLayout();
            this.gb_2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.AddressDetails);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // post_code_id_t
            // 
            this.post_code_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.post_code_id_t.Location = new System.Drawing.Point(59, 163);
            this.post_code_id_t.Name = "post_code_id_t";
            this.post_code_id_t.Size = new System.Drawing.Size(59, 13);
            this.post_code_id_t.TabIndex = 0;
            this.post_code_id_t.Text = "Post Code";
            this.post_code_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // post_code
            // 
            this.post_code.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PostCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.post_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.post_code.Location = new System.Drawing.Point(128, 157);
            this.post_code.Name = "post_code";
            this.post_code.ReadOnly = true;
            this.post_code.Size = new System.Drawing.Size(68, 20);
            this.post_code.TabIndex = 0;
            // 
            // adr_property_identification_t
            // 
            this.adr_property_identification_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.adr_property_identification_t.Location = new System.Drawing.Point(0, 184);
            this.adr_property_identification_t.Name = "adr_property_identification_t";
            this.adr_property_identification_t.Size = new System.Drawing.Size(118, 13);
            this.adr_property_identification_t.TabIndex = 0;
            this.adr_property_identification_t.Text = "Property Identification";
            this.adr_property_identification_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // adr_property_identification
            // 
            this.adr_property_identification.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AdrPropertyIdentification", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.adr_property_identification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.adr_property_identification.Location = new System.Drawing.Point(128, 180);
            this.adr_property_identification.MaxLength = 100;
            this.adr_property_identification.Name = "adr_property_identification";
            this.adr_property_identification.Size = new System.Drawing.Size(328, 20);
            this.adr_property_identification.TabIndex = 90;
            // 
            // town_name
            // 
            this.town_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "TownName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.town_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.town_name.Location = new System.Drawing.Point(708, 130);
            this.town_name.Name = "town_name";
            this.town_name.Size = new System.Drawing.Size(108, 20);
            this.town_name.TabIndex = 0;
            // 
            // title_address
            // 
            this.title_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "TitleAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.title_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.title_address.Location = new System.Drawing.Point(707, 165);
            this.title_address.Name = "title_address";
            this.title_address.Size = new System.Drawing.Size(174, 20);
            this.title_address.TabIndex = 0;
            // 
            // adr_no_t
            // 
            this.adr_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.adr_no_t.Location = new System.Drawing.Point(0, 40);
            this.adr_no_t.Name = "adr_no_t";
            this.adr_no_t.Size = new System.Drawing.Size(121, 13);
            this.adr_no_t.TabIndex = 0;
            this.adr_no_t.Text = "Street / Road No.";
            this.adr_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // adr_num
            // 
            this.adr_num.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AdrNum", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.adr_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.adr_num.Location = new System.Drawing.Point(128, 38);
            this.adr_num.MaxLength = 20;
            this.adr_num.Name = "adr_num";
            this.adr_num.Size = new System.Drawing.Size(68, 20);
            this.adr_num.TabIndex = 20;
            // 
            // road_id_t
            // 
            this.road_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.road_id_t.Location = new System.Drawing.Point(0, 64);
            this.road_id_t.Name = "road_id_t";
            this.road_id_t.Size = new System.Drawing.Size(121, 13);
            this.road_id_t.TabIndex = 0;
            this.road_id_t.Text = "Street / Road Name";
            this.road_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sl_id_t
            // 
            this.sl_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sl_id_t.Location = new System.Drawing.Point(0, 87);
            this.sl_id_t.Name = "sl_id_t";
            this.sl_id_t.Size = new System.Drawing.Size(120, 13);
            this.sl_id_t.TabIndex = 0;
            this.sl_id_t.Text = "Suburb / Locality";
            this.sl_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // adr_rd_no_t
            // 
            this.adr_rd_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.adr_rd_no_t.Location = new System.Drawing.Point(28, 112);
            this.adr_rd_no_t.Name = "adr_rd_no_t";
            this.adr_rd_no_t.Size = new System.Drawing.Size(90, 13);
            this.adr_rd_no_t.TabIndex = 0;
            this.adr_rd_no_t.Text = "R D Number";
            this.adr_rd_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // adr_rd_no
            // 
            this.adr_rd_no.BackColor = System.Drawing.Color.Aqua;
            this.adr_rd_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AdrRdNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.adr_rd_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.adr_rd_no.Location = new System.Drawing.Point(128, 110);
            this.adr_rd_no.MaxLength = 40;
            this.adr_rd_no.Name = "adr_rd_no";
            this.adr_rd_no.Size = new System.Drawing.Size(68, 20);
            this.adr_rd_no.TabIndex = 70;
            // 
            // tc_id_t
            // 
            this.tc_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tc_id_t.Location = new System.Drawing.Point(37, 140);
            this.tc_id_t.Name = "tc_id_t";
            this.tc_id_t.Size = new System.Drawing.Size(81, 13);
            this.tc_id_t.TabIndex = 0;
            this.tc_id_t.Text = "Town / City";
            this.tc_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tc_id
            // 
            this.tc_id.AutoRetrieve = true;
            this.tc_id.BackColor = System.Drawing.Color.Aqua;
            this.tc_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "TcId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tc_id.DisplayMember = "TcName";
            this.tc_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tc_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tc_id.Location = new System.Drawing.Point(128, 133);
            this.tc_id.Name = "tc_id";
            this.tc_id.Size = new System.Drawing.Size(248, 21);
            this.tc_id.TabIndex = 80;
            this.tc_id.Value = null;
            this.tc_id.ValueMember = "TcId";
            // 
            // adr_id
            // 
            this.adr_id.BackColor = System.Drawing.SystemColors.Control;
            this.adr_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.adr_id.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AdrId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.adr_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.adr_id.Location = new System.Drawing.Point(128, 16);
            this.adr_id.Name = "adr_id";
            this.adr_id.ReadOnly = true;
            this.adr_id.Size = new System.Drawing.Size(68, 13);
            this.adr_id.TabIndex = 0;
            // 
            // dp_id_t
            // 
            this.dp_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dp_id_t.Location = new System.Drawing.Point(221, 17);
            this.dp_id_t.Name = "dp_id_t";
            this.dp_id_t.Size = new System.Drawing.Size(40, 13);
            this.dp_id_t.TabIndex = 0;
            this.dp_id_t.Text = "DP_ID";
            this.dp_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dp_id
            // 
            this.dp_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dp_id.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DpId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dp_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dp_id.Location = new System.Drawing.Point(266, 17);
            this.dp_id.Name = "dp_id";
            this.dp_id.Size = new System.Drawing.Size(68, 13);
            this.dp_id.TabIndex = 10;
            // 
            // adr_id_t
            // 
            this.adr_id_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.adr_id_t.Location = new System.Drawing.Point(40, 16);
            this.adr_id_t.Name = "adr_id_t";
            this.adr_id_t.Size = new System.Drawing.Size(78, 13);
            this.adr_id_t.TabIndex = 0;
            this.adr_id_t.Text = "Address Id";
            this.adr_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rt_id
            // 
            this.rt_id.AutoRetrieve = true;
            this.rt_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RtId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rt_id.DisplayMember = "RtName";
            this.rt_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rt_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rt_id.Location = new System.Drawing.Point(302, 61);
            this.rt_id.Name = "rt_id";
            this.rt_id.Size = new System.Drawing.Size(72, 21);
            this.rt_id.TabIndex = 40;
            this.rt_id.Value = null;
            this.rt_id.ValueMember = "RtId";
            // 
            // t_4
            // 
            this.t_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.t_4.Location = new System.Drawing.Point(324, 45);
            this.t_4.Name = "t_4";
            this.t_4.Size = new System.Drawing.Size(31, 12);
            this.t_4.TabIndex = 0;
            this.t_4.Text = "Type";
            this.t_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rs_id
            // 
            this.rs_id.AutoRetrieve = true;
            this.rs_id.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RsId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rs_id.DisplayMember = "RsName";
            this.rs_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rs_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rs_id.Location = new System.Drawing.Point(381, 61);
            this.rs_id.Name = "rs_id";
            this.rs_id.Size = new System.Drawing.Size(72, 21);
            this.rs_id.TabIndex = 50;
            this.rs_id.Value = null;
            this.rs_id.ValueMember = "RsId";
            // 
            // road_suffix_t
            // 
            this.road_suffix_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.road_suffix_t.Location = new System.Drawing.Point(403, 45);
            this.road_suffix_t.Name = "road_suffix_t";
            this.road_suffix_t.Size = new System.Drawing.Size(33, 12);
            this.road_suffix_t.TabIndex = 0;
            this.road_suffix_t.Text = "Suffix";
            this.road_suffix_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contract_no_t
            // 
            this.contract_no_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_no_t.Location = new System.Drawing.Point(461, 5);
            this.contract_no_t.Name = "contract_no_t";
            this.contract_no_t.Size = new System.Drawing.Size(72, 13);
            this.contract_no_t.TabIndex = 0;
            this.contract_no_t.Text = "Contract No";
            this.contract_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contract_no
            // 
            this.contract_no.BackColor = System.Drawing.Color.Aqua;
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contract_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.contract_no.Location = new System.Drawing.Point(534, 5);
            this.contract_no.Mask = "########";
            this.contract_no.Name = "contract_no";
            this.contract_no.PromptChar = ' ';
            this.contract_no.ReadOnly = true;
            this.contract_no.Size = new System.Drawing.Size(78, 20);
            this.contract_no.TabIndex = 100;
            // 
            // contract_button
            // 
            this.contract_button.Image = ((System.Drawing.Image)(resources.GetObject("contract_button.Image")));
            this.contract_button.Location = new System.Drawing.Point(619, 8);
            this.contract_button.Name = "contract_button";
            this.contract_button.Size = new System.Drawing.Size(17, 15);
            this.contract_button.TabIndex = 0;
            this.contract_button.TabStop = false;
            // 
            // gb_1
            // 
            this.gb_1.Controls.Add(this.t_1);
            this.gb_1.Controls.Add(this.mon);
            this.gb_1.Controls.Add(this.days);
            this.gb_1.Controls.Add(this.tue);
            this.gb_1.Controls.Add(this.wed);
            this.gb_1.Controls.Add(this.thur);
            this.gb_1.Controls.Add(this.fri);
            this.gb_1.Controls.Add(this.sat);
            this.gb_1.Controls.Add(this.sunday);
            this.gb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_1.Location = new System.Drawing.Point(464, 46);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(178, 64);
            this.gb_1.TabIndex = 0;
            this.gb_1.TabStop = false;
            this.gb_1.Text = " Delivery Days      ";
            // 
            // t_1
            // 
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_1.Location = new System.Drawing.Point(6, 16);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(166, 13);
            this.t_1.TabIndex = 6;
            this.t_1.Text = "Mon Tue Wed Thu  Fri Sat Sun";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mon
            // 
            this.mon.BackColor = System.Drawing.SystemColors.Control;
            this.mon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mon.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Mon", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.mon.Location = new System.Drawing.Point(11, 38);
            this.mon.Name = "mon";
            this.mon.Size = new System.Drawing.Size(13, 13);
            this.mon.TabIndex = 5;
            // 
            // days
            // 
            this.days.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.days.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.days.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Days", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.days.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.days.Location = new System.Drawing.Point(82, 0);
            this.days.Name = "days";
            this.days.Size = new System.Drawing.Size(20, 13);
            this.days.TabIndex = 9;
            // 
            // tue
            // 
            this.tue.BackColor = System.Drawing.SystemColors.Control;
            this.tue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Tue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tue.Location = new System.Drawing.Point(35, 38);
            this.tue.Name = "tue";
            this.tue.Size = new System.Drawing.Size(13, 13);
            this.tue.TabIndex = 8;
            // 
            // wed
            // 
            this.wed.BackColor = System.Drawing.SystemColors.Control;
            this.wed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Wed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.wed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.wed.Location = new System.Drawing.Point(58, 38);
            this.wed.Name = "wed";
            this.wed.Size = new System.Drawing.Size(13, 13);
            this.wed.TabIndex = 7;
            // 
            // thur
            // 
            this.thur.BackColor = System.Drawing.SystemColors.Control;
            this.thur.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.thur.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Thur", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.thur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.thur.Location = new System.Drawing.Point(83, 38);
            this.thur.Name = "thur";
            this.thur.Size = new System.Drawing.Size(13, 13);
            this.thur.TabIndex = 2;
            // 
            // fri
            // 
            this.fri.BackColor = System.Drawing.SystemColors.Control;
            this.fri.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fri.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Fri", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fri.Location = new System.Drawing.Point(104, 38);
            this.fri.Name = "fri";
            this.fri.Size = new System.Drawing.Size(13, 13);
            this.fri.TabIndex = 1;
            // 
            // sat
            // 
            this.sat.BackColor = System.Drawing.SystemColors.Control;
            this.sat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sat.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Sat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sat.Location = new System.Drawing.Point(123, 38);
            this.sat.Name = "sat";
            this.sat.Size = new System.Drawing.Size(13, 13);
            this.sat.TabIndex = 4;
            // 
            // sunday
            // 
            this.sunday.BackColor = System.Drawing.SystemColors.Control;
            this.sunday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sunday.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Sunday", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sunday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sunday.Location = new System.Drawing.Point(144, 38);
            this.sunday.Name = "sunday";
            this.sunday.Size = new System.Drawing.Size(12, 13);
            this.sunday.TabIndex = 3;
            // 
            // gb_2
            // 
            this.gb_2.Controls.Add(this.t_2);
            this.gb_2.Controls.Add(this.compute_1);
            this.gb_2.Controls.Add(this.compute_2);
            this.gb_2.Controls.Add(this.compute_3);
            this.gb_2.Controls.Add(this.compute_4);
            this.gb_2.Controls.Add(this.compute_5);
            this.gb_2.Controls.Add(this.compute_6);
            this.gb_2.Controls.Add(this.compute_7);
            this.gb_2.Controls.Add(this.compute_8);
            this.gb_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_2.Location = new System.Drawing.Point(464, 141);
            this.gb_2.Name = "gb_2";
            this.gb_2.Size = new System.Drawing.Size(178, 59);
            this.gb_2.TabIndex = 0;
            this.gb_2.TabStop = false;
            this.gb_2.Text = " Terminal Point      ";
            // 
            // t_2
            // 
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_2.Location = new System.Drawing.Point(3, 14);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(161, 13);
            this.t_2.TabIndex = 6;
            this.t_2.Text = "Mon Tue Wed Thu  Fri Sat Sun";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // compute_1
            // 
            this.compute_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.compute_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_1.Location = new System.Drawing.Point(83, -1);
            this.compute_1.Name = "compute_1";
            this.compute_1.Size = new System.Drawing.Size(20, 13);
            this.compute_1.TabIndex = 9;
            // 
            // compute_2
            // 
            this.compute_2.BackColor = System.Drawing.SystemColors.Control;
            this.compute_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_2.Location = new System.Drawing.Point(11, 35);
            this.compute_2.Name = "compute_2";
            this.compute_2.Size = new System.Drawing.Size(14, 13);
            this.compute_2.TabIndex = 5;
            // 
            // compute_3
            // 
            this.compute_3.BackColor = System.Drawing.SystemColors.Control;
            this.compute_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_3.Location = new System.Drawing.Point(34, 35);
            this.compute_3.Name = "compute_3";
            this.compute_3.Size = new System.Drawing.Size(13, 13);
            this.compute_3.TabIndex = 8;
            // 
            // compute_4
            // 
            this.compute_4.BackColor = System.Drawing.SystemColors.Control;
            this.compute_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_4.Location = new System.Drawing.Point(56, 35);
            this.compute_4.Name = "compute_4";
            this.compute_4.Size = new System.Drawing.Size(14, 13);
            this.compute_4.TabIndex = 7;
            // 
            // compute_5
            // 
            this.compute_5.BackColor = System.Drawing.SystemColors.Control;
            this.compute_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_5.Location = new System.Drawing.Point(80, 35);
            this.compute_5.Name = "compute_5";
            this.compute_5.Size = new System.Drawing.Size(13, 13);
            this.compute_5.TabIndex = 2;
            // 
            // compute_6
            // 
            this.compute_6.BackColor = System.Drawing.SystemColors.Control;
            this.compute_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_6.Location = new System.Drawing.Point(102, 35);
            this.compute_6.Name = "compute_6";
            this.compute_6.Size = new System.Drawing.Size(13, 13);
            this.compute_6.TabIndex = 1;
            // 
            // compute_7
            // 
            this.compute_7.BackColor = System.Drawing.SystemColors.Control;
            this.compute_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute7", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_7.Location = new System.Drawing.Point(122, 35);
            this.compute_7.Name = "compute_7";
            this.compute_7.Size = new System.Drawing.Size(13, 13);
            this.compute_7.TabIndex = 4;
            // 
            // compute_8
            // 
            this.compute_8.BackColor = System.Drawing.SystemColors.Control;
            this.compute_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute8", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_8.Location = new System.Drawing.Point(142, 35);
            this.compute_8.Name = "compute_8";
            this.compute_8.Size = new System.Drawing.Size(14, 13);
            this.compute_8.TabIndex = 3;
            // 
            // road_name
            // 
            this.road_name.BackColor = System.Drawing.Color.Aqua;
            this.road_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RoadName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.road_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.road_name.Location = new System.Drawing.Point(128, 61);
            this.road_name.Name = "road_name";
            this.road_name.Size = new System.Drawing.Size(168, 20);
            this.road_name.TabIndex = 30;
            // 
            // sl_name
            // 
            this.sl_name.AutoRetrieve = true;
            this.sl_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "SlName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sl_name.DisplayMember = "SlName";
            this.sl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sl_name.Location = new System.Drawing.Point(128, 85);
            this.sl_name.Name = "sl_name";
            this.sl_name.Size = new System.Drawing.Size(248, 21);
            this.sl_name.TabIndex = 60;
            this.sl_name.Value = null;
            this.sl_name.ValueMember = "SlName";
            // 
            // location_ind
            // 
            this.location_ind.AutoSize = true;
            this.location_ind.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "AdrLocationInd", true));
            this.location_ind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.location_ind.Location = new System.Drawing.Point(202, 41);
            this.location_ind.Name = "location_ind";
            this.location_ind.Size = new System.Drawing.Size(15, 14);
            this.location_ind.TabIndex = 110;
            this.location_ind.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Has alternate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(223, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "delivery location";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tc_name
            // 
            this.tc_name.BackColor = System.Drawing.SystemColors.Control;
            this.tc_name.Location = new System.Drawing.Point(317, 225);
            this.tc_name.Name = "tc_name";
            this.tc_name.ReadOnly = true;
            this.tc_name.Size = new System.Drawing.Size(57, 20);
            this.tc_name.TabIndex = 111;
            this.tc_name.Visible = false;
            // 
            // rt_name
            // 
            this.rt_name.BackColor = System.Drawing.SystemColors.Control;
            this.rt_name.Location = new System.Drawing.Point(128, 225);
            this.rt_name.Name = "rt_name";
            this.rt_name.ReadOnly = true;
            this.rt_name.Size = new System.Drawing.Size(57, 20);
            this.rt_name.TabIndex = 112;
            this.rt_name.Visible = false;
            // 
            // rs_name
            // 
            this.rs_name.BackColor = System.Drawing.SystemColors.Control;
            this.rs_name.Location = new System.Drawing.Point(191, 225);
            this.rs_name.Name = "rs_name";
            this.rs_name.ReadOnly = true;
            this.rs_name.Size = new System.Drawing.Size(57, 20);
            this.rs_name.TabIndex = 113;
            this.rs_name.Visible = false;
            // 
            // adr_sl_name
            // 
            this.adr_sl_name.BackColor = System.Drawing.SystemColors.Control;
            this.adr_sl_name.Location = new System.Drawing.Point(254, 225);
            this.adr_sl_name.Name = "adr_sl_name";
            this.adr_sl_name.ReadOnly = true;
            this.adr_sl_name.Size = new System.Drawing.Size(57, 20);
            this.adr_sl_name.TabIndex = 114;
            this.adr_sl_name.Visible = false;
            // 
            // DAddressDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.adr_sl_name);
            this.Controls.Add(this.rs_name);
            this.Controls.Add(this.rt_name);
            this.Controls.Add(this.tc_name);
            this.Controls.Add(this.location_ind);
            this.Controls.Add(this.post_code_id_t);
            this.Controls.Add(this.post_code);
            this.Controls.Add(this.adr_property_identification_t);
            this.Controls.Add(this.adr_property_identification);
            this.Controls.Add(this.town_name);
            this.Controls.Add(this.title_address);
            this.Controls.Add(this.adr_no_t);
            this.Controls.Add(this.adr_num);
            this.Controls.Add(this.road_id_t);
            this.Controls.Add(this.sl_id_t);
            this.Controls.Add(this.adr_rd_no_t);
            this.Controls.Add(this.adr_rd_no);
            this.Controls.Add(this.tc_id_t);
            this.Controls.Add(this.tc_id);
            this.Controls.Add(this.adr_id);
            this.Controls.Add(this.dp_id_t);
            this.Controls.Add(this.dp_id);
            this.Controls.Add(this.adr_id_t);
            this.Controls.Add(this.rt_id);
            this.Controls.Add(this.t_4);
            this.Controls.Add(this.rs_id);
            this.Controls.Add(this.road_suffix_t);
            this.Controls.Add(this.contract_no_t);
            this.Controls.Add(this.contract_no);
            this.Controls.Add(this.contract_button);
            this.Controls.Add(this.gb_1);
            this.Controls.Add(this.gb_2);
            this.Controls.Add(this.road_name);
            this.Controls.Add(this.sl_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "DAddressDetails";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contract_button)).EndInit();
            this.gb_1.ResumeLayout(false);
            this.gb_1.PerformLayout();
            this.gb_2.ResumeLayout(false);
            this.gb_2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (this.RowCount <= 0)
                return;
            if (e.NewIndex >= 0)
            {
                
                if (this.GetColumnName() == "TcId")
                {
                    this.GetItem<AddressDetails>(e.NewIndex).TownName = ((DddwTownOnly)(this.tc_id.Items[tc_id.SelectedIndex])).TcName;
                }
            //if(pos(lower(if(isnull(adr_property_identification), '', adr_property_identification)) , 'private')>;0, adr_property_identification + ' ', '') + if(isnull(adr_num), '', adr_num+' ') + if(isnull(road_name), '', road_name) + if(lookupdisplay(rt_id)='', '', ' '+lookupdisplay(rt_id)) + if(lookupdisplay(rs_id)='', '', ' '+lookupdisplay(rs_id)) + if(lookupdisplay(sl_id)='', '', ', ' + lookupdisplay(sl_id)) + if(lookupdisplay(tc_id)='', '', ', ' + lookupdisplay(tc_id))
                AddressDetails l_temp =  this.GetItem<AddressDetails>(e.NewIndex);
                string addr_temp = string.Empty;
                if (l_temp.AdrPropertyIdentification == null )
                {
                    addr_temp = "";
                }
                else
                {
                    if (l_temp.AdrPropertyIdentification.ToLower().IndexOf("private") > 0)
                    {
                        addr_temp = l_temp.AdrPropertyIdentification + " ";
                    }
                    else
                    {
                        addr_temp = "";
                    }
                }

                if (l_temp.AdrNum == null)
                {
                    addr_temp += "";
                }
                else
                {
                    addr_temp += l_temp.AdrNum + " ";
                }

                if (l_temp.RoadName == null)
                {
                    addr_temp += "";
                }
                else
                {
                    addr_temp += l_temp.RoadName;
                }

                if (rt_id.Text =="")
                {
                    addr_temp += "";
                }
                else
                {
                    addr_temp += " " + rt_id.Text;
                }

                if (rs_id.Text == "")
                {
                    addr_temp += "";
                }
                else
                {
                    addr_temp += " " + rs_id.Text;
                }

                if (sl_name.Text == "")
                {
                    addr_temp += "";
                }
                else
                {
                    addr_temp += ", " + sl_name.Text;
                }

                if (tc_id.Text == "")
                {
                    addr_temp += "";
                }
                else
                {
                    addr_temp += ", " + tc_id.Text;
                }
                l_temp.TitleAddress = addr_temp;
            }
        }
        #endregion

        private System.Windows.Forms.Label post_code_id_t;
        private System.Windows.Forms.TextBox post_code;
        private System.Windows.Forms.Label adr_property_identification_t;
        private System.Windows.Forms.TextBox adr_property_identification;
        private System.Windows.Forms.TextBox town_name;
        private System.Windows.Forms.TextBox title_address;
        private System.Windows.Forms.Label adr_no_t;
        private System.Windows.Forms.TextBox adr_num;
        private System.Windows.Forms.Label road_id_t;
        private System.Windows.Forms.Label sl_id_t;
        private System.Windows.Forms.Label adr_rd_no_t;
        private System.Windows.Forms.TextBox adr_rd_no;
        private System.Windows.Forms.Label tc_id_t;
        private Metex.Windows.DataEntityCombo tc_id;
        private System.Windows.Forms.TextBox adr_id;
        private System.Windows.Forms.Label dp_id_t;
        private System.Windows.Forms.TextBox dp_id;
        private System.Windows.Forms.Label adr_id_t;
        private Metex.Windows.DataEntityCombo rt_id;
        private System.Windows.Forms.Label t_4;
        private Metex.Windows.DataEntityCombo rs_id;
        private System.Windows.Forms.Label road_suffix_t;
        private System.Windows.Forms.Label contract_no_t;
        private System.Windows.Forms.MaskedTextBox contract_no;
        private System.Windows.Forms.PictureBox contract_button;
        private System.Windows.Forms.GroupBox gb_1;
        private System.Windows.Forms.GroupBox gb_2;
        private System.Windows.Forms.TextBox road_name;
        private Metex.Windows.DataEntityCombo sl_name;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.TextBox compute_2;
        private System.Windows.Forms.TextBox compute_3;
        private System.Windows.Forms.TextBox compute_4;
        private System.Windows.Forms.TextBox compute_5;
        private System.Windows.Forms.TextBox compute_6;
        private System.Windows.Forms.TextBox compute_7;
        private System.Windows.Forms.TextBox compute_8;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.TextBox mon;
        private System.Windows.Forms.TextBox tue;
        private System.Windows.Forms.TextBox wed;
        private System.Windows.Forms.TextBox thur;
        private System.Windows.Forms.TextBox fri;
        private System.Windows.Forms.TextBox sat;
        private System.Windows.Forms.TextBox sunday;
        private System.Windows.Forms.TextBox days;
        private System.Windows.Forms.TextBox compute_1;
        private System.Windows.Forms.CheckBox location_ind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tc_name;
        private System.Windows.Forms.TextBox rt_name;
        private System.Windows.Forms.TextBox rs_name;
        private System.Windows.Forms.TextBox adr_sl_name;
    }
}

