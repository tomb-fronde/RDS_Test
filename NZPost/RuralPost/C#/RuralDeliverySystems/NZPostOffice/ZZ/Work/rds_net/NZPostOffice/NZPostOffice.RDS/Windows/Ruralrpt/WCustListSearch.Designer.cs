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
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralwin2;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.DataControls.Ruralsec;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    partial class WCustListSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Button pb_open;

        public Label st_contract;

        public RadioButton rb_town;

        public RadioButton rb_contract;

        public Label st_town;

        public URdsDw dw_town;

        public Label st_header;

        public Label st_display_options;

        public GroupBox gb_optional;

        public CheckBox cbx_recipients;

        public Label st_1;

        public CheckBox cbx_category;

        public CheckBox cbx_kiwi;

        public Label st_sort_text;

        public Button pb_search;

        public Button pb_export;

        public Label st_col_name;

        public Label st_priority;

        public Label st_descending;

        public Label st_cust_name;

        public Label st_street;

        public Label st_category;

        public TextBox sle_customer;

        public TextBox sle_street;

        public TextBox sle_cat;

        public CheckBox cbx_cust;

        public CheckBox cbx_street;

        public CheckBox cbx_cat;

        public URdsDw dw_export;

        public Label st_limit;

        public URdsDw dw_contract;

        public Label st_allcontract;

        public RadioButton rb_allcontract;

        public GroupBox gb_sort;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WCustListSearch));
            this.pb_open = new System.Windows.Forms.Button();
            this.st_contract = new System.Windows.Forms.Label();
            this.rb_town = new System.Windows.Forms.RadioButton();
            this.rb_contract = new System.Windows.Forms.RadioButton();
            this.st_town = new System.Windows.Forms.Label();
            this.dw_town = new NZPostOffice.RDS.Controls.URdsDw();
            this.dw_town.DataObject = new DCustListTown();
            this.st_header = new System.Windows.Forms.Label();
            this.st_display_options = new System.Windows.Forms.Label();
            this.gb_optional = new System.Windows.Forms.GroupBox();
            this.cbx_kiwi = new System.Windows.Forms.CheckBox();
            this.cbx_category = new System.Windows.Forms.CheckBox();
            this.cbx_recipients = new System.Windows.Forms.CheckBox();
            this.st_1 = new System.Windows.Forms.Label();
            this.gb_sort = new System.Windows.Forms.GroupBox();
            this.st_sort_text = new System.Windows.Forms.Label();
            this.pb_search = new System.Windows.Forms.Button();
            this.pb_export = new System.Windows.Forms.Button();
            this.st_col_name = new System.Windows.Forms.Label();
            this.st_priority = new System.Windows.Forms.Label();
            this.st_descending = new System.Windows.Forms.Label();
            this.st_cust_name = new System.Windows.Forms.Label();
            this.st_street = new System.Windows.Forms.Label();
            this.st_category = new System.Windows.Forms.Label();
            this.sle_customer = new System.Windows.Forms.TextBox();
            this.sle_street = new System.Windows.Forms.TextBox();
            this.sle_cat = new System.Windows.Forms.TextBox();
            this.cbx_cust = new System.Windows.Forms.CheckBox();
            this.cbx_street = new System.Windows.Forms.CheckBox();
            this.cbx_cat = new System.Windows.Forms.CheckBox();
            this.dw_export = new NZPostOffice.RDS.Controls.URdsDw();
            this.dw_export.DataObject = new RPsCustListTown();
            this.st_limit = new System.Windows.Forms.Label();
            this.dw_contract = new NZPostOffice.RDS.Controls.URdsDw();
            this.dw_contract.DataObject = new DConCriteria();
            this.st_allcontract = new System.Windows.Forms.Label();
            this.rb_allcontract = new System.Windows.Forms.RadioButton();
            this.gb_optional.SuspendLayout();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(10, 496);
            this.st_label.Size = new System.Drawing.Size(94, 23);
            this.st_label.Width = 200;
            // 
            // pb_open
            // 
            this.pb_open.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pb_open.Image = global::NZPostOffice.Shared.Properties.Resources.OPEN;
            this.pb_open.Location = new System.Drawing.Point(656, 216);
            this.pb_open.Name = "pb_open";
            this.pb_open.Size = new System.Drawing.Size(59, 31);
            this.pb_open.TabIndex = 1;
            this.pb_open.Visible = false;
            this.pb_open.Click += new System.EventHandler(this.pb_open_clicked);
            // 
            // st_contract
            // 
            this.st_contract.BackColor = System.Drawing.SystemColors.Control;
            this.st_contract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_contract.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_contract.Location = new System.Drawing.Point(23, 93);
            this.st_contract.Name = "st_contract";
            this.st_contract.Size = new System.Drawing.Size(54, 19);
            this.st_contract.TabIndex = 3;
            this.st_contract.Text = "Contract";
            // 
            // rb_town
            // 
            this.rb_town.BackColor = System.Drawing.SystemColors.Control;
            this.rb_town.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.rb_town.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rb_town.Location = new System.Drawing.Point(3, 41);
            this.rb_town.Name = "rb_town";
            this.rb_town.Size = new System.Drawing.Size(15, 19);
            this.rb_town.TabIndex = 4;
            this.rb_town.Tag = "town check";
            this.rb_town.UseVisualStyleBackColor = false;
            this.rb_town.Click += new System.EventHandler(this.rb_town_clicked);
            // 
            // rb_contract
            // 
            this.rb_contract.BackColor = System.Drawing.SystemColors.Control;
            this.rb_contract.Checked = true;
            this.rb_contract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.rb_contract.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rb_contract.Location = new System.Drawing.Point(3, 91);
            this.rb_contract.Name = "rb_contract";
            this.rb_contract.Size = new System.Drawing.Size(15, 19);
            this.rb_contract.TabIndex = 5;
            this.rb_contract.TabStop = true;
            this.rb_contract.Tag = "contract check";
            this.rb_contract.UseVisualStyleBackColor = false;
            this.rb_contract.Click += new System.EventHandler(this.rb_contract_clicked);
            // 
            // st_town
            // 
            this.st_town.BackColor = System.Drawing.SystemColors.Control;
            this.st_town.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_town.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_town.Location = new System.Drawing.Point(23, 44);
            this.st_town.Name = "st_town";
            this.st_town.Size = new System.Drawing.Size(64, 18);
            this.st_town.TabIndex = 6;
            this.st_town.Tag = "town text";
            this.st_town.Text = "Town / City";
            // 
            // dw_town
            // 
            this.dw_town.Location = new System.Drawing.Point(93, 44);
            this.dw_town.Name = "dw_town";
            this.dw_town.Size = new System.Drawing.Size(157, 24);
            this.dw_town.TabIndex = 10;
            this.dw_town.ItemChanged += new EventHandler(dw_town_itemchanged);
            //this.dw_town.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_town_constructor);

            // 
            // st_header
            // 
            this.st_header.BackColor = System.Drawing.SystemColors.Control;
            this.st_header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.st_header.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_header.Location = new System.Drawing.Point(14, 4);
            this.st_header.Name = "st_header";
            this.st_header.Size = new System.Drawing.Size(105, 17);
            this.st_header.TabIndex = 11;
            this.st_header.Text = "Search Criteria";
            // 
            // st_display_options
            // 
            this.st_display_options.BackColor = System.Drawing.SystemColors.Control;
            this.st_display_options.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.st_display_options.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_display_options.Location = new System.Drawing.Point(338, 62);
            this.st_display_options.Name = "st_display_options";
            this.st_display_options.Size = new System.Drawing.Size(121, 19);
            this.st_display_options.TabIndex = 12;
            this.st_display_options.Text = "Display Options";
            // 
            // gb_optional
            // 
            this.gb_optional.BackColor = System.Drawing.SystemColors.Control;
            this.gb_optional.Controls.Add(this.cbx_kiwi);
            this.gb_optional.Controls.Add(this.cbx_category);
            this.gb_optional.Controls.Add(this.cbx_recipients);
            this.gb_optional.Controls.Add(this.st_1);
            this.gb_optional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gb_optional.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_optional.Location = new System.Drawing.Point(334, 84);
            this.gb_optional.Name = "gb_optional";
            this.gb_optional.Size = new System.Drawing.Size(313, 156);
            this.gb_optional.TabIndex = 5;
            this.gb_optional.TabStop = false;
            this.gb_optional.Text = "Optional Columns";
            // 
            // cbx_kiwi
            // 
            this.cbx_kiwi.BackColor = System.Drawing.SystemColors.Control;
            this.cbx_kiwi.Checked = true;
            this.cbx_kiwi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_kiwi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbx_kiwi.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbx_kiwi.Location = new System.Drawing.Point(17, 131);
            this.cbx_kiwi.Name = "cbx_kiwi";
            this.cbx_kiwi.Size = new System.Drawing.Size(123, 19);
            this.cbx_kiwi.TabIndex = 16;
            this.cbx_kiwi.Text = "Kiwimail Quantity";
            this.cbx_kiwi.UseVisualStyleBackColor = false;
            this.cbx_kiwi.Click += new System.EventHandler(this.cbx_kiwi_clicked);
            // 
            // cbx_category
            // 
            this.cbx_category.BackColor = System.Drawing.SystemColors.Control;
            this.cbx_category.Checked = true;
            this.cbx_category.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbx_category.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbx_category.Location = new System.Drawing.Point(17, 96);
            this.cbx_category.Name = "cbx_category";
            this.cbx_category.Size = new System.Drawing.Size(123, 19);
            this.cbx_category.TabIndex = 15;
            this.cbx_category.Text = "Category";
            this.cbx_category.UseVisualStyleBackColor = false;
            this.cbx_category.Click += new System.EventHandler(this.cbx_category_clicked);
            // 
            // cbx_recipients
            // 
            this.cbx_recipients.BackColor = System.Drawing.SystemColors.Control;
            this.cbx_recipients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbx_recipients.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbx_recipients.Location = new System.Drawing.Point(17, 63);
            this.cbx_recipients.Name = "cbx_recipients";
            this.cbx_recipients.Size = new System.Drawing.Size(82, 19);
            this.cbx_recipients.TabIndex = 13;
            this.cbx_recipients.Text = "Recipients";
            this.cbx_recipients.UseVisualStyleBackColor = false;
            this.cbx_recipients.Click += new System.EventHandler(this.cbx_recipients_clicked);
            // 
            // st_1
            // 
            this.st_1.BackColor = System.Drawing.SystemColors.Control;
            this.st_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_1.Location = new System.Drawing.Point(18, 15);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(289, 45);
            this.st_1.TabIndex = 14;
            this.st_1.Text = "The following optional columns will be displayed in the report by default. You can uncheck the columns that you do not want to see included in the report.";
            // 
            // gb_sort
            // 
            this.gb_sort.BackColor = System.Drawing.SystemColors.Control;
            this.gb_sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gb_sort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_sort.Location = new System.Drawing.Point(334, 246);
            this.gb_sort.Name = "gb_sort";
            this.gb_sort.Size = new System.Drawing.Size(313, 218);
            this.gb_sort.TabIndex = 4;
            this.gb_sort.TabStop = false;
            this.gb_sort.Text = "Sort Columns";
            // 
            // st_sort_text
            // 
            this.st_sort_text.BackColor = System.Drawing.SystemColors.Control;
            this.st_sort_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.st_sort_text.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_sort_text.Location = new System.Drawing.Point(343, 270);
            this.st_sort_text.Name = "st_sort_text";
            this.st_sort_text.Size = new System.Drawing.Size(289, 79);
            this.st_sort_text.TabIndex = 17;
            this.st_sort_text.Text = "You can change the way data is sorted. Assign a priority level against the column you want to be sorted by. Leave the field blank if sorting is not required. Check the Descending checkbox if you want the data to be sorted in descending order.";
            // 
            // pb_search
            // 
            this.pb_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pb_search.Image = global::NZPostOffice.Shared.Properties.Resources.SEARCH;
            this.pb_search.Location = new System.Drawing.Point(656, 47);
            this.pb_search.Name = "pb_search";
            this.pb_search.Size = new System.Drawing.Size(59, 31);
            this.pb_search.TabIndex = 11;
            this.pb_search.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pb_search.Click += new System.EventHandler(this.pb_search_clicked);
            // 
            // pb_export
            // 
            this.pb_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pb_export.Location = new System.Drawing.Point(656, 257);
            this.pb_export.Name = "pb_export";
            this.pb_export.Size = new System.Drawing.Size(59, 31);
            this.pb_export.TabIndex = 3;
            this.pb_export.Text = "Export";
            this.pb_export.Visible = false;
            this.pb_export.Click += new System.EventHandler(this.pb_export_clicked);
            // 
            // st_col_name
            // 
            this.st_col_name.BackColor = System.Drawing.SystemColors.Control;
            this.st_col_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline);
            this.st_col_name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_col_name.Location = new System.Drawing.Point(341, 350);
            this.st_col_name.Name = "st_col_name";
            this.st_col_name.Size = new System.Drawing.Size(84, 19);
            this.st_col_name.TabIndex = 18;
            this.st_col_name.Text = "Column Name";
            // 
            // st_priority
            // 
            this.st_priority.BackColor = System.Drawing.SystemColors.Control;
            this.st_priority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline);
            this.st_priority.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_priority.Location = new System.Drawing.Point(431, 349);
            this.st_priority.Name = "st_priority";
            this.st_priority.Size = new System.Drawing.Size(99, 19);
            this.st_priority.TabIndex = 19;
            this.st_priority.Text = "Priority  ( 1 to 3)";
            // 
            // st_descending
            // 
            this.st_descending.BackColor = System.Drawing.SystemColors.Control;
            this.st_descending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline);
            this.st_descending.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_descending.Location = new System.Drawing.Point(549, 349);
            this.st_descending.Name = "st_descending";
            this.st_descending.Size = new System.Drawing.Size(87, 19);
            this.st_descending.TabIndex = 20;
            this.st_descending.Text = "Descending";
            // 
            // st_cust_name
            // 
            this.st_cust_name.BackColor = System.Drawing.SystemColors.Control;
            this.st_cust_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.st_cust_name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_cust_name.Location = new System.Drawing.Point(338, 402);
            this.st_cust_name.Name = "st_cust_name";
            this.st_cust_name.Size = new System.Drawing.Size(106, 19);
            this.st_cust_name.TabIndex = 21;
            this.st_cust_name.Text = "Customer Name";
            // 
            // st_street
            // 
            this.st_street.BackColor = System.Drawing.SystemColors.Control;
            this.st_street.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.st_street.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_street.Location = new System.Drawing.Point(338, 374);
            this.st_street.Name = "st_street";
            this.st_street.Size = new System.Drawing.Size(67, 19);
            this.st_street.TabIndex = 22;
            this.st_street.Text = "Address";
            // 
            // st_category
            // 
            this.st_category.BackColor = System.Drawing.SystemColors.Control;
            this.st_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.st_category.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_category.Location = new System.Drawing.Point(338, 430);
            this.st_category.Name = "st_category";
            this.st_category.Size = new System.Drawing.Size(91, 19);
            this.st_category.TabIndex = 23;
            this.st_category.Text = "Category";
            // 
            // sle_customer
            // 
            this.sle_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.sle_customer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sle_customer.Location = new System.Drawing.Point(455, 400);
            this.sle_customer.Name = "sle_customer";
            this.sle_customer.TextAlign = HorizontalAlignment.Right;
            this.sle_customer.Size = new System.Drawing.Size(54, 21);
            this.sle_customer.TabIndex = 6;
            this.sle_customer.Text = "2";
            // 
            // sle_street
            // 
            this.sle_street.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.sle_street.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sle_street.Location = new System.Drawing.Point(455, 371);
            this.sle_street.Name = "sle_street";
            this.sle_street.Size = new System.Drawing.Size(54, 21);
            this.sle_street.TabIndex = 8;
            this.sle_street.TextAlign = HorizontalAlignment.Right;
            this.sle_street.Text = "1";
            // 
            // sle_cat
            // 
            this.sle_cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.sle_cat.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sle_cat.Location = new System.Drawing.Point(455, 428);
            this.sle_cat.Name = "sle_cat";
            this.sle_cat.Size = new System.Drawing.Size(54, 21);
            this.sle_cat.TabIndex = 9;
            this.sle_cat.Text = "3";
            this.sle_cat.TextAlign = HorizontalAlignment.Right;
            // 
            // cbx_cust
            // 
            this.cbx_cust.BackColor = System.Drawing.SystemColors.Control;
            this.cbx_cust.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbx_cust.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbx_cust.Location = new System.Drawing.Point(569, 400);
            this.cbx_cust.Name = "cbx_cust";
            this.cbx_cust.Size = new System.Drawing.Size(16, 19);
            this.cbx_cust.TabIndex = 24;
            this.cbx_cust.UseVisualStyleBackColor = false;
            // 
            // cbx_street
            // 
            this.cbx_street.BackColor = System.Drawing.SystemColors.Control;
            this.cbx_street.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbx_street.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbx_street.Location = new System.Drawing.Point(569, 371);
            this.cbx_street.Name = "cbx_street";
            this.cbx_street.Size = new System.Drawing.Size(16, 19);
            this.cbx_street.TabIndex = 25;
            this.cbx_street.UseVisualStyleBackColor = false;
            // 
            // cbx_cat
            // 
            this.cbx_cat.BackColor = System.Drawing.SystemColors.Control;
            this.cbx_cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbx_cat.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbx_cat.Location = new System.Drawing.Point(569, 431);
            this.cbx_cat.Name = "cbx_cat";
            this.cbx_cat.Size = new System.Drawing.Size(16, 19);
            this.cbx_cat.TabIndex = 26;
            this.cbx_cat.UseVisualStyleBackColor = false;
            // 
            // dw_export
            // 
            this.dw_export.Location = new System.Drawing.Point(709, 326);
            this.dw_export.Name = "dw_export";
            this.dw_export.Size = new System.Drawing.Size(120, 138);
            this.dw_export.TabIndex = 7;
            this.dw_export.Visible = false;
            // 
            // st_limit
            // 
            this.st_limit.BackColor = System.Drawing.SystemColors.Control;
            this.st_limit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_limit.ForeColor = System.Drawing.Color.Red;
            this.st_limit.Location = new System.Drawing.Point(338, 465);
            this.st_limit.Name = "st_limit";
            this.st_limit.Size = new System.Drawing.Size(309, 31);
            this.st_limit.TabIndex = 27;
            this.st_limit.BorderStyle = BorderStyle.Fixed3D;
            this.st_limit.Text = "No more than 2000 records will be retrieved if no town or contract is selected.";
            // 
            // dw_contract
            // 
            this.dw_contract.Location = new System.Drawing.Point(91, 84);
            this.dw_contract.Name = "dw_contract";
            this.dw_contract.DataObject.BorderStyle = BorderStyle.Fixed3D;
            this.dw_contract.Size = new System.Drawing.Size(237, 410);
            this.dw_contract.TabIndex = 2;
            dw_contract.Click += new EventHandler(dw_contract_clicked);
            //((DConCriteria)dw_contract.DataObject).CellDoubleClick += new EventHandler(dw_contract_doubleclicked);
            //dw_contract.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_contract_constructor);
            // 
            // st_allcontract
            // 
            this.st_allcontract.BackColor = System.Drawing.SystemColors.Control;
            this.st_allcontract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_allcontract.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_allcontract.Location = new System.Drawing.Point(23, 69);
            this.st_allcontract.Name = "st_allcontract";
            this.st_allcontract.Size = new System.Drawing.Size(73, 19);
            this.st_allcontract.TabIndex = 28;
            this.st_allcontract.Text = "All Contracts";
            // 
            // rb_allcontract
            // 
            this.rb_allcontract.BackColor = System.Drawing.SystemColors.Control;
            this.rb_allcontract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.rb_allcontract.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rb_allcontract.Location = new System.Drawing.Point(3, 66);
            this.rb_allcontract.Name = "rb_allcontract";
            this.rb_allcontract.Size = new System.Drawing.Size(15, 19);
            this.rb_allcontract.TabIndex = 29;
            this.rb_allcontract.Tag = "contract check";
            this.rb_allcontract.UseVisualStyleBackColor = false;
            this.rb_allcontract.Click += new System.EventHandler(this.rb_allcontract_clicked);
            // 
            // WCustListSearch
            // 
            this.BackColor = System.Drawing.SystemColors.Control;//this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(720, 510);
            this.Controls.Add(this.pb_open);
            this.Controls.Add(this.st_contract);
            this.Controls.Add(this.rb_contract);
            this.Controls.Add(this.st_town);
            this.Controls.Add(this.st_header);
            this.Controls.Add(this.st_display_options);
            this.Controls.Add(this.rb_town);
            this.Controls.Add(this.gb_optional);
            this.Controls.Add(this.pb_export);
            this.Controls.Add(this.pb_search);
            this.Controls.Add(this.st_col_name);
            this.Controls.Add(this.st_sort_text);
            this.Controls.Add(this.st_priority);
            this.Controls.Add(this.dw_town);
            this.Controls.Add(this.st_descending);
            this.Controls.Add(this.st_street);
            this.Controls.Add(this.st_cust_name);
            this.Controls.Add(this.sle_street);
            this.Controls.Add(this.st_category);
            this.Controls.Add(this.sle_customer);
            this.Controls.Add(this.cbx_cust);
            this.Controls.Add(this.sle_cat);
            this.Controls.Add(this.dw_export);
            this.Controls.Add(this.cbx_cat);
            this.Controls.Add(this.cbx_street);
            this.Controls.Add(this.dw_contract);
            this.Controls.Add(this.rb_allcontract);
            this.Controls.Add(this.st_limit);
            this.Controls.Add(this.st_allcontract);
            this.Controls.Add(this.gb_sort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "w_cust_list_search";
            this.Tag = "Unnumbered Address Search";
            this.Text = "Customer Listing Search";
            this.Controls.SetChildIndex(this.gb_sort, 0);
            this.Controls.SetChildIndex(this.st_allcontract, 0);
            this.Controls.SetChildIndex(this.st_limit, 0);
            this.Controls.SetChildIndex(this.rb_allcontract, 0);
            this.Controls.SetChildIndex(this.dw_contract, 0);
            this.Controls.SetChildIndex(this.cbx_street, 0);
            this.Controls.SetChildIndex(this.cbx_cat, 0);
            this.Controls.SetChildIndex(this.dw_export, 0);
            this.Controls.SetChildIndex(this.sle_cat, 0);
            this.Controls.SetChildIndex(this.cbx_cust, 0);
            this.Controls.SetChildIndex(this.sle_customer, 0);
            this.Controls.SetChildIndex(this.st_category, 0);
            this.Controls.SetChildIndex(this.sle_street, 0);
            this.Controls.SetChildIndex(this.st_cust_name, 0);
            this.Controls.SetChildIndex(this.st_street, 0);
            this.Controls.SetChildIndex(this.st_descending, 0);
            this.Controls.SetChildIndex(this.dw_town, 0);
            this.Controls.SetChildIndex(this.st_priority, 0);
            this.Controls.SetChildIndex(this.st_sort_text, 0);
            this.Controls.SetChildIndex(this.st_col_name, 0);
            this.Controls.SetChildIndex(this.pb_search, 0);
            this.Controls.SetChildIndex(this.pb_export, 0);
            this.Controls.SetChildIndex(this.gb_optional, 0);
            this.Controls.SetChildIndex(this.rb_town, 0);
            this.Controls.SetChildIndex(this.st_display_options, 0);
            this.Controls.SetChildIndex(this.st_header, 0);
            this.Controls.SetChildIndex(this.st_town, 0);
            this.Controls.SetChildIndex(this.rb_contract, 0);
            this.Controls.SetChildIndex(this.st_contract, 0);
            this.Controls.SetChildIndex(this.pb_open, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.gb_optional.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(WCustListSearch_KeyDown);
            this.KeyUp += new KeyEventHandler(WCustListSearch_KeyUp);
        }

        #endregion

        #endregion
    }
}
