using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DDeedCompRegCust
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

        private System.Windows.Forms.TextBox compute_1;
        private System.Windows.Forms.TextBox five_w;
        private System.Windows.Forms.TextBox compute_2;
        private System.Windows.Forms.TextBox compute_3;
        private System.Windows.Forms.TextBox compute_4;
        private System.Windows.Forms.TextBox compute_5;
        private System.Windows.Forms.TextBox compute_6;
        private System.Windows.Forms.TextBox compute_7;
        private System.Windows.Forms.TextBox compute_8;
        private System.Windows.Forms.TextBox compute_9;
        private System.Windows.Forms.TextBox three_ham;
        private System.Windows.Forms.TextBox five_rot;
        private System.Windows.Forms.TextBox six_ham;
        private System.Windows.Forms.TextBox pvt_three;
        private System.Windows.Forms.TextBox five_nat_1;
        private System.Windows.Forms.TextBox pvt_six;
        private System.Windows.Forms.TextBox four_rot;
        private System.Windows.Forms.TextBox one_rot;
        private System.Windows.Forms.TextBox one_ch;
        private System.Windows.Forms.TextBox u5_nat;
        private System.Windows.Forms.TextBox pvt_one;
        private System.Windows.Forms.TextBox total_rot;
        private System.Windows.Forms.TextBox two_rot;
        private System.Windows.Forms.TextBox five_nat;
        private System.Windows.Forms.TextBox six_nat_1;
        private System.Windows.Forms.TextBox two_ch;
        private System.Windows.Forms.TextBox three_dun;
        private System.Windows.Forms.TextBox four_nat;
        private System.Windows.Forms.TextBox one_nat;
        private System.Windows.Forms.TextBox six_dun;
        private System.Windows.Forms.TextBox three_nat_1;
        private System.Windows.Forms.TextBox u5_p;
        private System.Windows.Forms.TextBox pvt_five;
        private System.Windows.Forms.TextBox u5_w;
        private System.Windows.Forms.TextBox total_nat;
        private System.Windows.Forms.TextBox two_nat;
        private System.Windows.Forms.Label t_3;
        private System.Windows.Forms.Label t_4;
        private System.Windows.Forms.TextBox four_nat_1;
        private System.Windows.Forms.Label t_5;
        private System.Windows.Forms.Label t_6;
        private System.Windows.Forms.Label t_7;
        private System.Windows.Forms.Label t_8;
        private System.Windows.Forms.Label t_9;
        private System.Windows.Forms.TextBox u5_ham;
        private System.Windows.Forms.TextBox two_nat_1;
        private System.Windows.Forms.TextBox one_nat_1;
        private System.Windows.Forms.TextBox cust_1;
        private System.Windows.Forms.TextBox pvt_two;
        private System.Windows.Forms.TextBox cust_2;
        private System.Windows.Forms.TextBox cust_3;
        private System.Windows.Forms.TextBox cust_4;
        private System.Windows.Forms.Label t_10;
        private System.Windows.Forms.TextBox five_ham;
        private System.Windows.Forms.TextBox cust_5;
        private System.Windows.Forms.Label t_11;
        private System.Windows.Forms.TextBox cust_6;
        private System.Windows.Forms.Label t_12;
        private System.Windows.Forms.Label t_13;
        private System.Windows.Forms.TextBox three_rot;
        private System.Windows.Forms.Label t_14;
        private System.Windows.Forms.Label t_15;
        private System.Windows.Forms.TextBox four_ham;
        private System.Windows.Forms.Label t_16;
        private System.Windows.Forms.TextBox six_rot;
        private System.Windows.Forms.Label t_17;
        private System.Windows.Forms.TextBox one_ham;
        private System.Windows.Forms.TextBox one_p;
        private System.Windows.Forms.Label t_18;
        private System.Windows.Forms.Label t_19;
        private System.Windows.Forms.TextBox total_nat_1;
        private System.Windows.Forms.TextBox three_ch;
        private System.Windows.Forms.TextBox total_p;
        private System.Windows.Forms.TextBox one_w;
        private System.Windows.Forms.TextBox u5_dun;
        private System.Windows.Forms.TextBox total_ham;
        private System.Windows.Forms.TextBox two_ham;
        private System.Windows.Forms.TextBox four_p;
        private System.Windows.Forms.TextBox six_ch;
        private System.Windows.Forms.TextBox total_w;
        private System.Windows.Forms.TextBox three_p;
        private System.Windows.Forms.TextBox three_nat;
        private System.Windows.Forms.TextBox four_w;
        private System.Windows.Forms.TextBox five_ch;
        private System.Windows.Forms.TextBox cust_sub_5;
        private System.Windows.Forms.TextBox three_w;
        private System.Windows.Forms.TextBox cust_tot;
        private System.Windows.Forms.TextBox five_dun;
        private System.Windows.Forms.TextBox six_nat;
        private System.Windows.Forms.TextBox pvt_four;
        private System.Windows.Forms.TextBox six_p;
        private System.Windows.Forms.Label t_20;
        private System.Windows.Forms.Label t_21;
        private System.Windows.Forms.TextBox two_p;
        private System.Windows.Forms.Label t_22;
        private System.Windows.Forms.TextBox four_dun;
        private System.Windows.Forms.TextBox one_dun;
        private System.Windows.Forms.Label t_23;
        private System.Windows.Forms.Label t_24;
        private System.Windows.Forms.TextBox pvt_sub_five;
        private System.Windows.Forms.Label t_25;
        private System.Windows.Forms.Label t_26;
        private System.Windows.Forms.TextBox six_w;
        private System.Windows.Forms.TextBox two_w;
        private System.Windows.Forms.TextBox u5_ch;
        private System.Windows.Forms.TextBox four_ch;
        private System.Windows.Forms.TextBox total_dun;
        private System.Windows.Forms.TextBox two_dun;
        private System.Windows.Forms.TextBox five_p;
        private System.Windows.Forms.TextBox total_ch;
        private System.Windows.Forms.TextBox u5_rot;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DDeedCompRegCust";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.DeedCompRegCust);
            //
            // t_3
            //
            this.t_3 = new System.Windows.Forms.Label();
            this.t_3.Font = new System.Drawing.Font("Arial", 8F);
            this.t_3.ForeColor = System.Drawing.Color.Black;
            this.t_3.Location = new System.Drawing.Point(5, 2);
            this.t_3.Name = "t_3";
            this.t_3.Size = new System.Drawing.Size(184, 14);
            this.t_3.Text = "Customers per Delivery Day";
            this.t_3.TextAlign = ContentAlignment.MiddleRight;
            this.t_3.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.Controls.Add(t_3);

            //
            // t_4
            //
            this.t_4 = new System.Windows.Forms.Label();
            this.t_4.Font = new System.Drawing.Font("Arial", 8F);
            this.t_4.ForeColor = System.Drawing.Color.Black;
            this.t_4.Location = new System.Drawing.Point(5, 27);
            this.t_4.Name = "t_4";
            this.t_4.Size = new System.Drawing.Size(68, 14);
            this.t_4.Text = "Frequency";
            this.t_4.TextAlign = ContentAlignment.MiddleRight;
            this.t_4.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.Controls.Add(t_4);

            //
            // t_5
            //
            this.t_5 = new System.Windows.Forms.Label();
            this.t_5.Font = new System.Drawing.Font("Arial", 8F);
            this.t_5.ForeColor = System.Drawing.Color.Black;
            this.t_5.Location = new System.Drawing.Point(89, 27);
            this.t_5.Name = "t_5";
            this.t_5.Size = new System.Drawing.Size(57, 14);
            this.t_5.Text = "Customers";
            this.t_5.TextAlign = ContentAlignment.MiddleRight;
            this.t_5.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.Controls.Add(t_5);

            //
            // t_6
            //
            this.t_6 = new System.Windows.Forms.Label();
            this.t_6.Font = new System.Drawing.Font("Arial", 8F);
            this.t_6.ForeColor = System.Drawing.Color.Black;
            this.t_6.Location = new System.Drawing.Point(162, 27);
            this.t_6.Name = "t_6";
            this.t_6.Size = new System.Drawing.Size(71, 14);
            this.t_6.Text = "Private Bags";
            this.t_6.TextAlign = ContentAlignment.MiddleRight;
            this.t_6.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.Controls.Add(t_6);

            //
            // t_7
            //
            this.t_7 = new System.Windows.Forms.Label();
            this.t_7.Font = new System.Drawing.Font("Arial", 8F);
            this.t_7.ForeColor = System.Drawing.Color.Black;
            this.t_7.Location = new System.Drawing.Point(249, 27);
            this.t_7.Name = "t_7";
            this.t_7.Size = new System.Drawing.Size(28, 14);
            this.t_7.Text = "Total";
            this.t_7.TextAlign = ContentAlignment.MiddleRight;
            this.t_7.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.Controls.Add(t_7);

            //
            // t_16
            //
            this.t_16 = new System.Windows.Forms.Label();
            this.t_16.Font = new System.Drawing.Font("Arial", 8F);
            this.t_16.ForeColor = System.Drawing.Color.Black;
            this.t_16.Location = new System.Drawing.Point(5, 44);
            this.t_16.Name = "t_16";
            this.t_16.Size = new System.Drawing.Size(38, 14);
            this.t_16.Text = "6 Day";
            this.t_16.TextAlign = ContentAlignment.MiddleRight;
            this.t_16.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_16);

            //
            // cust_6
            //
            cust_6 = new System.Windows.Forms.TextBox();
            this.cust_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cust_6.Font = new System.Drawing.Font("Arial", 8F);
            this.cust_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cust_6.Location = new System.Drawing.Point(89, 44);
            this.cust_6.Name = "cust_6";
            this.cust_6.Size = new System.Drawing.Size(57, 14);
            this.cust_6.TextAlign = HorizontalAlignment.Left;
            this.cust_6.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.cust_6.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Cust6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(cust_6);

            //
            // pvt_six
            //
            pvt_six = new System.Windows.Forms.TextBox();
            this.pvt_six.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pvt_six.Font = new System.Drawing.Font("Arial", 8F);
            this.pvt_six.ForeColor = System.Drawing.SystemColors.WindowText;
            this.pvt_six.Location = new System.Drawing.Point(162, 44);
            this.pvt_six.MaxLength = 0;
            this.pvt_six.Name = "pvt_six";
            this.pvt_six.Size = new System.Drawing.Size(60, 14);
            this.pvt_six.TextAlign = HorizontalAlignment.Left;
            this.pvt_six.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.pvt_six.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "PvtSix", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pvt_six.ReadOnly = true;
            this.Controls.Add(pvt_six);

            //
            // six_nat
            //
            six_nat = new System.Windows.Forms.TextBox();
            this.six_nat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.six_nat.Font = new System.Drawing.Font("Arial", 8F);
            this.six_nat.ForeColor = System.Drawing.Color.Black;
            this.six_nat.Location = new System.Drawing.Point(250, 44);
            this.six_nat.MaxLength = 0;
            this.six_nat.Name = "six_nat";
            this.six_nat.Size = new System.Drawing.Size(60, 14);
            this.six_nat.TextAlign = HorizontalAlignment.Left;
            this.six_nat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.six_nat.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "SixNat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.six_nat.ReadOnly = true;
            this.Controls.Add(six_nat);

            //
            // t_18
            //
            this.t_18 = new System.Windows.Forms.Label();
            this.t_18.Font = new System.Drawing.Font("Arial", 8F);
            this.t_18.ForeColor = System.Drawing.Color.Black;
            this.t_18.Location = new System.Drawing.Point(5, 64);
            this.t_18.Name = "t_18";
            this.t_18.Size = new System.Drawing.Size(38, 14);
            this.t_18.Text = "5 Day";
            this.t_18.TextAlign = ContentAlignment.MiddleRight;
            this.t_18.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_18);

            //
            // cust_5
            //
            cust_5 = new System.Windows.Forms.TextBox();
            this.cust_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cust_5.Font = new System.Drawing.Font("Arial", 8F);
            this.cust_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cust_5.Location = new System.Drawing.Point(89, 64);
            this.cust_5.Name = "cust_5";
            this.cust_5.Size = new System.Drawing.Size(57, 14);
            this.cust_5.TextAlign = HorizontalAlignment.Left;
            this.cust_5.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.cust_5.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Cust5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(cust_5);

            //
            // pvt_five
            //
            pvt_five = new System.Windows.Forms.TextBox();
            this.pvt_five.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pvt_five.Font = new System.Drawing.Font("Arial", 8F);
            this.pvt_five.ForeColor = System.Drawing.SystemColors.WindowText;
            this.pvt_five.Location = new System.Drawing.Point(162, 64);
            this.pvt_five.MaxLength = 0;
            this.pvt_five.Name = "pvt_five";
            this.pvt_five.Size = new System.Drawing.Size(60, 14);
            this.pvt_five.TextAlign = HorizontalAlignment.Left;
            this.pvt_five.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.pvt_five.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "PvtFive", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pvt_five.ReadOnly = true;
            this.Controls.Add(pvt_five);

            //
            // five_nat
            //
            five_nat = new System.Windows.Forms.TextBox();
            this.five_nat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.five_nat.Font = new System.Drawing.Font("Arial", 8F);
            this.five_nat.ForeColor = System.Drawing.Color.Black;
            this.five_nat.Location = new System.Drawing.Point(250, 64);
            this.five_nat.MaxLength = 0;
            this.five_nat.Name = "five_nat";
            this.five_nat.Size = new System.Drawing.Size(60, 14);
            this.five_nat.TextAlign = HorizontalAlignment.Left;
            this.five_nat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.five_nat.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FiveNat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.five_nat.ReadOnly = true;
            this.Controls.Add(five_nat);

            //
            // compute_3
            //
            compute_3 = new System.Windows.Forms.TextBox();
            this.compute_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_3.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_3.ForeColor = System.Drawing.Color.Black;
            this.compute_3.Location = new System.Drawing.Point(339, 64);
            this.compute_3.Name = "compute_3";
            this.compute_3.Size = new System.Drawing.Size(40, 14);
            this.compute_3.TextAlign = HorizontalAlignment.Left;
            this.compute_3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.compute_3.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Compute3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(compute_3);

            //
            // t_19
            //
            this.t_19 = new System.Windows.Forms.Label();
            this.t_19.Font = new System.Drawing.Font("Arial", 8F);
            this.t_19.ForeColor = System.Drawing.SystemColors.WindowText;
            this.t_19.Location = new System.Drawing.Point(414, 64);
            this.t_19.Name = "t_19";
            this.t_19.Size = new System.Drawing.Size(47, 14);
            this.t_19.Text = "99.88%";
            this.t_19.TextAlign = ContentAlignment.MiddleRight;
            this.t_19.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.Controls.Add(t_19);

            //
            // five_nat_1
            //
            five_nat_1 = new System.Windows.Forms.TextBox();
            this.five_nat_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.five_nat_1.Font = new System.Drawing.Font("Arial", 8F);
            this.five_nat_1.ForeColor = System.Drawing.Color.Black;
            this.five_nat_1.Location = new System.Drawing.Point(485, 64);
            this.five_nat_1.MaxLength = 0;
            this.five_nat_1.Name = "five_nat_1";
            this.five_nat_1.Size = new System.Drawing.Size(60, 14);
            this.five_nat_1.TextAlign = HorizontalAlignment.Right;
            this.five_nat_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.five_nat_1.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FiveNat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.five_nat_1.ReadOnly = true;
            this.Controls.Add(five_nat_1);

            //
            // five_ch
            //
            five_ch = new System.Windows.Forms.TextBox();
            this.five_ch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.five_ch.Font = new System.Drawing.Font("Arial", 8F);
            this.five_ch.ForeColor = System.Drawing.Color.Black;
            this.five_ch.Location = new System.Drawing.Point(557, 64);
            this.five_ch.MaxLength = 0;
            this.five_ch.Name = "five_ch";
            this.five_ch.Size = new System.Drawing.Size(60, 14);
            this.five_ch.TextAlign = HorizontalAlignment.Right;
            this.five_ch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.five_ch.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FiveCh", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.five_ch.ReadOnly = true;
            this.Controls.Add(five_ch);

            //
            // five_dun
            //
            five_dun = new System.Windows.Forms.TextBox();
            this.five_dun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.five_dun.Font = new System.Drawing.Font("Arial", 8F);
            this.five_dun.ForeColor = System.Drawing.Color.Black;
            this.five_dun.Location = new System.Drawing.Point(622, 64);
            this.five_dun.MaxLength = 0;
            this.five_dun.Name = "five_dun";
            this.five_dun.Size = new System.Drawing.Size(60, 14);
            this.five_dun.TextAlign = HorizontalAlignment.Right;
            this.five_dun.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.five_dun.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FiveDun", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.five_dun.ReadOnly = true;
            this.Controls.Add(five_dun);

            //
            // five_ham
            //
            five_ham = new System.Windows.Forms.TextBox();
            this.five_ham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.five_ham.Font = new System.Drawing.Font("Arial", 8F);
            this.five_ham.ForeColor = System.Drawing.Color.Black;
            this.five_ham.Location = new System.Drawing.Point(687, 64);
            this.five_ham.MaxLength = 0;
            this.five_ham.Name = "five_ham";
            this.five_ham.Size = new System.Drawing.Size(60, 14);
            this.five_ham.TextAlign = HorizontalAlignment.Right;
            this.five_ham.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.five_ham.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FiveHam", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.five_ham.ReadOnly = true;
            this.Controls.Add(five_ham);

            //
            // five_p
            //
            five_p = new System.Windows.Forms.TextBox();
            this.five_p.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.five_p.Font = new System.Drawing.Font("Arial", 8F);
            this.five_p.ForeColor = System.Drawing.Color.Black;
            this.five_p.Location = new System.Drawing.Point(752, 64);
            this.five_p.MaxLength = 0;
            this.five_p.Name = "five_p";
            this.five_p.Size = new System.Drawing.Size(60, 14);
            this.five_p.TextAlign = HorizontalAlignment.Right;
            this.five_p.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.five_p.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FiveP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.five_p.ReadOnly = true;
            this.Controls.Add(five_p);

            //
            // five_rot
            //
            five_rot = new System.Windows.Forms.TextBox();
            this.five_rot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.five_rot.Font = new System.Drawing.Font("Arial", 8F);
            this.five_rot.ForeColor = System.Drawing.Color.Black;
            this.five_rot.Location = new System.Drawing.Point(817, 64);
            this.five_rot.MaxLength = 0;
            this.five_rot.Name = "five_rot";
            this.five_rot.Size = new System.Drawing.Size(60, 14);
            this.five_rot.TextAlign = HorizontalAlignment.Right;
            this.five_rot.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.five_rot.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FiveRot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.five_rot.ReadOnly = true;
            this.Controls.Add(five_rot);

            //
            // five_w
            //
            five_w = new System.Windows.Forms.TextBox();
            this.five_w.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.five_w.Font = new System.Drawing.Font("Arial", 8F);
            this.five_w.ForeColor = System.Drawing.Color.Black;
            this.five_w.Location = new System.Drawing.Point(883, 64);
            this.five_w.MaxLength = 0;
            this.five_w.Name = "five_w";
            this.five_w.Size = new System.Drawing.Size(60, 14);
            this.five_w.TextAlign = HorizontalAlignment.Right;
            this.five_w.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.five_w.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FiveW", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.five_w.ReadOnly = true;
            this.Controls.Add(five_w);

            //
            // t_20
            //
            this.t_20 = new System.Windows.Forms.Label();
            this.t_20.Font = new System.Drawing.Font("Arial", 8F);
            this.t_20.ForeColor = System.Drawing.Color.Black;
            this.t_20.Location = new System.Drawing.Point(5, 84);
            this.t_20.Name = "t_20";
            this.t_20.Size = new System.Drawing.Size(38, 14);
            this.t_20.Text = "4 Day";
            this.t_20.TextAlign = ContentAlignment.MiddleRight;
            this.t_20.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_20);

            //
            // cust_4
            //
            cust_4 = new System.Windows.Forms.TextBox();
            this.cust_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cust_4.Font = new System.Drawing.Font("Arial", 8F);
            this.cust_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cust_4.Location = new System.Drawing.Point(89, 84);
            this.cust_4.Name = "cust_4";
            this.cust_4.Size = new System.Drawing.Size(57, 14);
            this.cust_4.TextAlign = HorizontalAlignment.Left;
            this.cust_4.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.cust_4.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Cust4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(cust_4);

            //
            // pvt_four
            //
            pvt_four = new System.Windows.Forms.TextBox();
            this.pvt_four.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pvt_four.Font = new System.Drawing.Font("Arial", 8F);
            this.pvt_four.ForeColor = System.Drawing.SystemColors.WindowText;
            this.pvt_four.Location = new System.Drawing.Point(162, 84);
            this.pvt_four.MaxLength = 0;
            this.pvt_four.Name = "pvt_four";
            this.pvt_four.Size = new System.Drawing.Size(60, 14);
            this.pvt_four.TextAlign = HorizontalAlignment.Left;
            this.pvt_four.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.pvt_four.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "PvtFour", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pvt_four.ReadOnly = true;
            this.Controls.Add(pvt_four);

            //
            // four_nat
            //
            four_nat = new System.Windows.Forms.TextBox();
            this.four_nat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.four_nat.Font = new System.Drawing.Font("Arial", 8F);
            this.four_nat.ForeColor = System.Drawing.Color.Black;
            this.four_nat.Location = new System.Drawing.Point(250, 84);
            this.four_nat.MaxLength = 0;
            this.four_nat.Name = "four_nat";
            this.four_nat.Size = new System.Drawing.Size(60, 14);
            this.four_nat.TextAlign = HorizontalAlignment.Left;
            this.four_nat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.four_nat.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FourNat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.four_nat.ReadOnly = true;
            this.Controls.Add(four_nat);

            //
            // compute_4
            //
            compute_4 = new System.Windows.Forms.TextBox();
            this.compute_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_4.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_4.ForeColor = System.Drawing.Color.Black;
            this.compute_4.Location = new System.Drawing.Point(339, 84);
            this.compute_4.Name = "compute_4";
            this.compute_4.Size = new System.Drawing.Size(40, 14);
            this.compute_4.TextAlign = HorizontalAlignment.Left;
            this.compute_4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.compute_4.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Compute4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(compute_4);

            //
            // four_nat_1
            //
            four_nat_1 = new System.Windows.Forms.TextBox();
            this.four_nat_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.four_nat_1.Font = new System.Drawing.Font("Arial", 8F);
            this.four_nat_1.ForeColor = System.Drawing.Color.Black;
            this.four_nat_1.Location = new System.Drawing.Point(485, 84);
            this.four_nat_1.MaxLength = 0;
            this.four_nat_1.Name = "four_nat_1";
            this.four_nat_1.Size = new System.Drawing.Size(60, 14);
            this.four_nat_1.TextAlign = HorizontalAlignment.Right;
            this.four_nat_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.four_nat_1.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FourNat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.four_nat_1.ReadOnly = true;
            this.Controls.Add(four_nat_1);

            //
            // four_ch
            //
            four_ch = new System.Windows.Forms.TextBox();
            this.four_ch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.four_ch.Font = new System.Drawing.Font("Arial", 8F);
            this.four_ch.ForeColor = System.Drawing.Color.Black;
            this.four_ch.Location = new System.Drawing.Point(557, 84);
            this.four_ch.MaxLength = 0;
            this.four_ch.Name = "four_ch";
            this.four_ch.Size = new System.Drawing.Size(60, 14);
            this.four_ch.TextAlign = HorizontalAlignment.Right;
            this.four_ch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.four_ch.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FourCh", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.four_ch.ReadOnly = true;
            this.Controls.Add(four_ch);

            //
            // four_dun
            //
            four_dun = new System.Windows.Forms.TextBox();
            this.four_dun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.four_dun.Font = new System.Drawing.Font("Arial", 8F);
            this.four_dun.ForeColor = System.Drawing.Color.Black;
            this.four_dun.Location = new System.Drawing.Point(622, 84);
            this.four_dun.MaxLength = 0;
            this.four_dun.Name = "four_dun";
            this.four_dun.Size = new System.Drawing.Size(60, 14);
            this.four_dun.TextAlign = HorizontalAlignment.Right;
            this.four_dun.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.four_dun.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FourDun", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.four_dun.ReadOnly = true;
            this.Controls.Add(four_dun);

            //
            // four_ham
            //
            four_ham = new System.Windows.Forms.TextBox();
            this.four_ham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.four_ham.Font = new System.Drawing.Font("Arial", 8F);
            this.four_ham.ForeColor = System.Drawing.Color.Black;
            this.four_ham.Location = new System.Drawing.Point(687, 84);
            this.four_ham.MaxLength = 0;
            this.four_ham.Name = "four_ham";
            this.four_ham.Size = new System.Drawing.Size(60, 14);
            this.four_ham.TextAlign = HorizontalAlignment.Right;
            this.four_ham.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.four_ham.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FourHam", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.four_ham.ReadOnly = true;
            this.Controls.Add(four_ham);

            //
            // four_p
            //
            four_p = new System.Windows.Forms.TextBox();
            this.four_p.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.four_p.Font = new System.Drawing.Font("Arial", 8F);
            this.four_p.ForeColor = System.Drawing.Color.Black;
            this.four_p.Location = new System.Drawing.Point(752, 84);
            this.four_p.MaxLength = 0;
            this.four_p.Name = "four_p";
            this.four_p.Size = new System.Drawing.Size(60, 14);
            this.four_p.TextAlign = HorizontalAlignment.Right;
            this.four_p.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.four_p.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FourP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.four_p.ReadOnly = true;
            this.Controls.Add(four_p);

            //
            // four_rot
            //
            four_rot = new System.Windows.Forms.TextBox();
            this.four_rot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.four_rot.Font = new System.Drawing.Font("Arial", 8F);
            this.four_rot.ForeColor = System.Drawing.Color.Black;
            this.four_rot.Location = new System.Drawing.Point(817, 84);
            this.four_rot.MaxLength = 0;
            this.four_rot.Name = "four_rot";
            this.four_rot.Size = new System.Drawing.Size(60, 14);
            this.four_rot.TextAlign = HorizontalAlignment.Right;
            this.four_rot.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.four_rot.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FourRot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.four_rot.ReadOnly = true;
            this.Controls.Add(four_rot);

            //
            // four_w
            //
            four_w = new System.Windows.Forms.TextBox();
            this.four_w.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.four_w.Font = new System.Drawing.Font("Arial", 8F);
            this.four_w.ForeColor = System.Drawing.Color.Black;
            this.four_w.Location = new System.Drawing.Point(883, 84);
            this.four_w.MaxLength = 0;
            this.four_w.Name = "four_w";
            this.four_w.Size = new System.Drawing.Size(60, 14);
            this.four_w.TextAlign = HorizontalAlignment.Right;
            this.four_w.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.four_w.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "FourW", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.four_w.ReadOnly = true;
            this.Controls.Add(four_w);

            //
            // t_21
            //
            this.t_21 = new System.Windows.Forms.Label();
            this.t_21.Font = new System.Drawing.Font("Arial", 8F);
            this.t_21.ForeColor = System.Drawing.Color.Black;
            this.t_21.Location = new System.Drawing.Point(5, 104);
            this.t_21.Name = "t_21";
            this.t_21.Size = new System.Drawing.Size(38, 14);
            this.t_21.Text = "3 Day";
            this.t_21.TextAlign = ContentAlignment.MiddleRight;
            this.t_21.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_21);

            //
            // cust_3
            //
            cust_3 = new System.Windows.Forms.TextBox();
            this.cust_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cust_3.Font = new System.Drawing.Font("Arial", 8F);
            this.cust_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cust_3.Location = new System.Drawing.Point(89, 104);
            this.cust_3.Name = "cust_3";
            this.cust_3.Size = new System.Drawing.Size(57, 14);
            this.cust_3.TextAlign = HorizontalAlignment.Left;
            this.cust_3.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.cust_3.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Cust3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(cust_3);

            //
            // pvt_three
            //
            pvt_three = new System.Windows.Forms.TextBox();
            this.pvt_three.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pvt_three.Font = new System.Drawing.Font("Arial", 8F);
            this.pvt_three.ForeColor = System.Drawing.SystemColors.WindowText;
            this.pvt_three.Location = new System.Drawing.Point(162, 104);
            this.pvt_three.MaxLength = 0;
            this.pvt_three.Name = "pvt_three";
            this.pvt_three.Size = new System.Drawing.Size(60, 14);
            this.pvt_three.TextAlign = HorizontalAlignment.Left;
            this.pvt_three.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.pvt_three.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "PvtThree", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pvt_three.ReadOnly = true;
            this.Controls.Add(pvt_three);

            //
            // three_nat
            //
            three_nat = new System.Windows.Forms.TextBox();
            this.three_nat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.three_nat.Font = new System.Drawing.Font("Arial", 8F);
            this.three_nat.ForeColor = System.Drawing.Color.Black;
            this.three_nat.Location = new System.Drawing.Point(250, 104);
            this.three_nat.MaxLength = 0;
            this.three_nat.Name = "three_nat";
            this.three_nat.Size = new System.Drawing.Size(60, 14);
            this.three_nat.TextAlign = HorizontalAlignment.Left;
            this.three_nat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.three_nat.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "ThreeNat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.three_nat.ReadOnly = true;
            this.Controls.Add(three_nat);

            //
            // compute_5
            //
            compute_5 = new System.Windows.Forms.TextBox();
            this.compute_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_5.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_5.ForeColor = System.Drawing.Color.Black;
            this.compute_5.Location = new System.Drawing.Point(339, 104);
            this.compute_5.Name = "compute_5";
            this.compute_5.Size = new System.Drawing.Size(40, 14);
            this.compute_5.TextAlign = HorizontalAlignment.Left;
            this.compute_5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.compute_5.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Compute5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(compute_5);

            //
            // three_nat_1
            //
            three_nat_1 = new System.Windows.Forms.TextBox();
            this.three_nat_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.three_nat_1.Font = new System.Drawing.Font("Arial", 8F);
            this.three_nat_1.ForeColor = System.Drawing.Color.Black;
            this.three_nat_1.Location = new System.Drawing.Point(485, 104);
            this.three_nat_1.MaxLength = 0;
            this.three_nat_1.Name = "three_nat_1";
            this.three_nat_1.Size = new System.Drawing.Size(60, 14);
            this.three_nat_1.TextAlign = HorizontalAlignment.Right;
            this.three_nat_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.three_nat_1.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "ThreeNat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.three_nat_1.ReadOnly = true;
            this.Controls.Add(three_nat_1);

            //
            // three_ch
            //
            three_ch = new System.Windows.Forms.TextBox();
            this.three_ch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.three_ch.Font = new System.Drawing.Font("Arial", 8F);
            this.three_ch.ForeColor = System.Drawing.Color.Black;
            this.three_ch.Location = new System.Drawing.Point(557, 104);
            this.three_ch.MaxLength = 0;
            this.three_ch.Name = "three_ch";
            this.three_ch.Size = new System.Drawing.Size(60, 14);
            this.three_ch.TextAlign = HorizontalAlignment.Right;
            this.three_ch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.three_ch.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "ThreeCh", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.three_ch.ReadOnly = true;
            this.Controls.Add(three_ch);

            //
            // three_dun
            //
            three_dun = new System.Windows.Forms.TextBox();
            this.three_dun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.three_dun.Font = new System.Drawing.Font("Arial", 8F);
            this.three_dun.ForeColor = System.Drawing.Color.Black;
            this.three_dun.Location = new System.Drawing.Point(622, 104);
            this.three_dun.MaxLength = 0;
            this.three_dun.Name = "three_dun";
            this.three_dun.Size = new System.Drawing.Size(60, 14);
            this.three_dun.TextAlign = HorizontalAlignment.Right;
            this.three_dun.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.three_dun.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "ThreeDun", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.three_dun.ReadOnly = true;
            this.Controls.Add(three_dun);

            //
            // three_ham
            //
            three_ham = new System.Windows.Forms.TextBox();
            this.three_ham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.three_ham.Font = new System.Drawing.Font("Arial", 8F);
            this.three_ham.ForeColor = System.Drawing.Color.Black;
            this.three_ham.Location = new System.Drawing.Point(687, 104);
            this.three_ham.MaxLength = 0;
            this.three_ham.Name = "three_ham";
            this.three_ham.Size = new System.Drawing.Size(60, 14);
            this.three_ham.TextAlign = HorizontalAlignment.Right;
            this.three_ham.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.three_ham.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "ThreeHam", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.three_ham.ReadOnly = true;
            this.Controls.Add(three_ham);

            //
            // three_p
            //
            three_p = new System.Windows.Forms.TextBox();
            this.three_p.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.three_p.Font = new System.Drawing.Font("Arial", 8F);
            this.three_p.ForeColor = System.Drawing.Color.Black;
            this.three_p.Location = new System.Drawing.Point(752, 104);
            this.three_p.MaxLength = 0;
            this.three_p.Name = "three_p";
            this.three_p.Size = new System.Drawing.Size(60, 14);
            this.three_p.TextAlign = HorizontalAlignment.Right;
            this.three_p.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.three_p.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "ThreeP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.three_p.ReadOnly = true;
            this.Controls.Add(three_p);

            //
            // three_rot
            //
            three_rot = new System.Windows.Forms.TextBox();
            this.three_rot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.three_rot.Font = new System.Drawing.Font("Arial", 8F);
            this.three_rot.ForeColor = System.Drawing.Color.Black;
            this.three_rot.Location = new System.Drawing.Point(817, 104);
            this.three_rot.MaxLength = 0;
            this.three_rot.Name = "three_rot";
            this.three_rot.Size = new System.Drawing.Size(60, 14);
            this.three_rot.TextAlign = HorizontalAlignment.Right;
            this.three_rot.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.three_rot.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "ThreeRot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.three_rot.ReadOnly = true;
            this.Controls.Add(three_rot);

            //
            // three_w
            //
            three_w = new System.Windows.Forms.TextBox();
            this.three_w.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.three_w.Font = new System.Drawing.Font("Arial", 8F);
            this.three_w.ForeColor = System.Drawing.Color.Black;
            this.three_w.Location = new System.Drawing.Point(883, 104);
            this.three_w.MaxLength = 0;
            this.three_w.Name = "three_w";
            this.three_w.Size = new System.Drawing.Size(60, 14);
            this.three_w.TextAlign = HorizontalAlignment.Right;
            this.three_w.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.three_w.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "ThreeW", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.three_w.ReadOnly = true;
            this.Controls.Add(three_w);

            //
            // t_22
            //
            this.t_22 = new System.Windows.Forms.Label();
            this.t_22.Font = new System.Drawing.Font("Arial", 8F);
            this.t_22.ForeColor = System.Drawing.Color.Black;
            this.t_22.Location = new System.Drawing.Point(5, 124);
            this.t_22.Name = "t_22";
            this.t_22.Size = new System.Drawing.Size(38, 14);
            this.t_22.Text = "2 Day";
            this.t_22.TextAlign = ContentAlignment.MiddleRight;
            this.t_22.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_22);

            //
            // cust_2
            //
            cust_2 = new System.Windows.Forms.TextBox();
            this.cust_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cust_2.Font = new System.Drawing.Font("Arial", 8F);
            this.cust_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cust_2.Location = new System.Drawing.Point(89, 124);
            this.cust_2.Name = "cust_2";
            this.cust_2.Size = new System.Drawing.Size(57, 14);
            this.cust_2.TextAlign = HorizontalAlignment.Left;
            this.cust_2.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.cust_2.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Cust2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(cust_2);

            //
            // pvt_two
            //
            pvt_two = new System.Windows.Forms.TextBox();
            this.pvt_two.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pvt_two.Font = new System.Drawing.Font("Arial", 8F);
            this.pvt_two.ForeColor = System.Drawing.SystemColors.WindowText;
            this.pvt_two.Location = new System.Drawing.Point(162, 124);
            this.pvt_two.MaxLength = 0;
            this.pvt_two.Name = "pvt_two";
            this.pvt_two.Size = new System.Drawing.Size(60, 14);
            this.pvt_two.TextAlign = HorizontalAlignment.Left;
            this.pvt_two.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.pvt_two.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "PvtTwo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pvt_two.ReadOnly = true;
            this.Controls.Add(pvt_two);

            //
            // two_nat
            //
            two_nat = new System.Windows.Forms.TextBox();
            this.two_nat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.two_nat.Font = new System.Drawing.Font("Arial", 8F);
            this.two_nat.ForeColor = System.Drawing.Color.Black;
            this.two_nat.Location = new System.Drawing.Point(250, 124);
            this.two_nat.MaxLength = 0;
            this.two_nat.Name = "two_nat";
            this.two_nat.Size = new System.Drawing.Size(60, 14);
            this.two_nat.TextAlign = HorizontalAlignment.Left;
            this.two_nat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.two_nat.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TwoNat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.two_nat.ReadOnly = true;
            this.Controls.Add(two_nat);

            //
            // compute_6
            //
            compute_6 = new System.Windows.Forms.TextBox();
            this.compute_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_6.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_6.ForeColor = System.Drawing.Color.Black;
            this.compute_6.Location = new System.Drawing.Point(339, 124);
            this.compute_6.Name = "compute_6";
            this.compute_6.Size = new System.Drawing.Size(40, 14);
            this.compute_6.TextAlign = HorizontalAlignment.Left;
            this.compute_6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.compute_6.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Compute6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(compute_6);

            //
            // two_nat_1
            //
            two_nat_1 = new System.Windows.Forms.TextBox();
            this.two_nat_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.two_nat_1.Font = new System.Drawing.Font("Arial", 8F);
            this.two_nat_1.ForeColor = System.Drawing.Color.Black;
            this.two_nat_1.Location = new System.Drawing.Point(485, 124);
            this.two_nat_1.MaxLength = 0;
            this.two_nat_1.Name = "two_nat_1";
            this.two_nat_1.Size = new System.Drawing.Size(60, 14);
            this.two_nat_1.TextAlign = HorizontalAlignment.Right;
            this.two_nat_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.two_nat_1.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TwoNat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.two_nat_1.ReadOnly = true;
            this.Controls.Add(two_nat_1);

            //
            // two_ch
            //
            two_ch = new System.Windows.Forms.TextBox();
            this.two_ch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.two_ch.Font = new System.Drawing.Font("Arial", 8F);
            this.two_ch.ForeColor = System.Drawing.Color.Black;
            this.two_ch.Location = new System.Drawing.Point(557, 124);
            this.two_ch.MaxLength = 0;
            this.two_ch.Name = "two_ch";
            this.two_ch.Size = new System.Drawing.Size(60, 14);
            this.two_ch.TextAlign = HorizontalAlignment.Right;
            this.two_ch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.two_ch.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TwoCh", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.two_ch.ReadOnly = true;
            this.Controls.Add(two_ch);

            //
            // two_dun
            //
            two_dun = new System.Windows.Forms.TextBox();
            this.two_dun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.two_dun.Font = new System.Drawing.Font("Arial", 8F);
            this.two_dun.ForeColor = System.Drawing.Color.Black;
            this.two_dun.Location = new System.Drawing.Point(622, 124);
            this.two_dun.MaxLength = 0;
            this.two_dun.Name = "two_dun";
            this.two_dun.Size = new System.Drawing.Size(60, 14);
            this.two_dun.TextAlign = HorizontalAlignment.Right;
            this.two_dun.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.two_dun.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TwoDun", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.two_dun.ReadOnly = true;
            this.Controls.Add(two_dun);

            //
            // two_ham
            //
            two_ham = new System.Windows.Forms.TextBox();
            this.two_ham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.two_ham.Font = new System.Drawing.Font("Arial", 8F);
            this.two_ham.ForeColor = System.Drawing.Color.Black;
            this.two_ham.Location = new System.Drawing.Point(687, 124);
            this.two_ham.MaxLength = 0;
            this.two_ham.Name = "two_ham";
            this.two_ham.Size = new System.Drawing.Size(60, 14);
            this.two_ham.TextAlign = HorizontalAlignment.Right;
            this.two_ham.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.two_ham.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TwoHam", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.two_ham.ReadOnly = true;
            this.Controls.Add(two_ham);

            //
            // two_p
            //
            two_p = new System.Windows.Forms.TextBox();
            this.two_p.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.two_p.Font = new System.Drawing.Font("Arial", 8F);
            this.two_p.ForeColor = System.Drawing.Color.Black;
            this.two_p.Location = new System.Drawing.Point(752, 124);
            this.two_p.MaxLength = 0;
            this.two_p.Name = "two_p";
            this.two_p.Size = new System.Drawing.Size(60, 14);
            this.two_p.TextAlign = HorizontalAlignment.Right;
            this.two_p.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.two_p.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TwoP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.two_p.ReadOnly = true;
            this.Controls.Add(two_p);

            //
            // two_rot
            //
            two_rot = new System.Windows.Forms.TextBox();
            this.two_rot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.two_rot.Font = new System.Drawing.Font("Arial", 8F);
            this.two_rot.ForeColor = System.Drawing.Color.Black;
            this.two_rot.Location = new System.Drawing.Point(817, 124);
            this.two_rot.MaxLength = 0;
            this.two_rot.Name = "two_rot";
            this.two_rot.Size = new System.Drawing.Size(60, 14);
            this.two_rot.TextAlign = HorizontalAlignment.Right;
            this.two_rot.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.two_rot.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TwoRot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.two_rot.ReadOnly = true;
            this.Controls.Add(two_rot);

            //
            // two_w
            //
            two_w = new System.Windows.Forms.TextBox();
            this.two_w.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.two_w.Font = new System.Drawing.Font("Arial", 8F);
            this.two_w.ForeColor = System.Drawing.Color.Black;
            this.two_w.Location = new System.Drawing.Point(883, 124);
            this.two_w.MaxLength = 0;
            this.two_w.Name = "two_w";
            this.two_w.Size = new System.Drawing.Size(60, 14);
            this.two_w.TextAlign = HorizontalAlignment.Right;
            this.two_w.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.two_w.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TwoW", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.two_w.ReadOnly = true;
            this.Controls.Add(two_w);

            //
            // t_23
            //
            this.t_23 = new System.Windows.Forms.Label();
            this.t_23.Font = new System.Drawing.Font("Arial", 8F);
            this.t_23.ForeColor = System.Drawing.Color.Black;
            this.t_23.Location = new System.Drawing.Point(5, 144);
            this.t_23.Name = "t_23";
            this.t_23.Size = new System.Drawing.Size(38, 14);
            this.t_23.Text = "1 Day";
            this.t_23.TextAlign = ContentAlignment.MiddleRight;
            this.t_23.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_23);

            //
            // cust_1
            //
            cust_1 = new System.Windows.Forms.TextBox();
            this.cust_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cust_1.Font = new System.Drawing.Font("Arial", 8F);
            this.cust_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cust_1.Location = new System.Drawing.Point(89, 144);
            this.cust_1.Name = "cust_1";
            this.cust_1.Size = new System.Drawing.Size(57, 14);
            this.cust_1.TextAlign = HorizontalAlignment.Left;
            this.cust_1.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.cust_1.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Cust1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(cust_1);

            //
            // pvt_one
            //
            pvt_one = new System.Windows.Forms.TextBox();
            this.pvt_one.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pvt_one.Font = new System.Drawing.Font("Arial", 8F);
            this.pvt_one.ForeColor = System.Drawing.SystemColors.WindowText;
            this.pvt_one.Location = new System.Drawing.Point(162, 144);
            this.pvt_one.MaxLength = 0;
            this.pvt_one.Name = "pvt_one";
            this.pvt_one.Size = new System.Drawing.Size(60, 14);
            this.pvt_one.TextAlign = HorizontalAlignment.Left;
            this.pvt_one.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.pvt_one.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "PvtOne", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pvt_one.ReadOnly = true;
            this.Controls.Add(pvt_one);

            //
            // one_nat
            //
            one_nat = new System.Windows.Forms.TextBox();
            this.one_nat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.one_nat.Font = new System.Drawing.Font("Arial", 8F);
            this.one_nat.ForeColor = System.Drawing.Color.Black;
            this.one_nat.Location = new System.Drawing.Point(250, 144);
            this.one_nat.MaxLength = 0;
            this.one_nat.Name = "one_nat";
            this.one_nat.Size = new System.Drawing.Size(60, 14);
            this.one_nat.TextAlign = HorizontalAlignment.Left;
            this.one_nat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.one_nat.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "OneNat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.one_nat.ReadOnly = true;
            this.Controls.Add(one_nat);

            //
            // t_24
            //
            this.t_24 = new System.Windows.Forms.Label();
            this.t_24.Font = new System.Drawing.Font("Arial", 8F);
            this.t_24.ForeColor = System.Drawing.Color.Black;
            this.t_24.Location = new System.Drawing.Point(329, 144);
            this.t_24.Name = "t_24";
            this.t_24.Size = new System.Drawing.Size(50, 14);
            this.t_24.Text = "100 .00%";
            this.t_24.TextAlign = ContentAlignment.MiddleRight;
            this.t_24.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_24);

            //
            // one_nat_1
            //
            one_nat_1 = new System.Windows.Forms.TextBox();
            this.one_nat_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.one_nat_1.Font = new System.Drawing.Font("Arial", 8F);
            this.one_nat_1.ForeColor = System.Drawing.Color.Black;
            this.one_nat_1.Location = new System.Drawing.Point(485, 144);
            this.one_nat_1.MaxLength = 0;
            this.one_nat_1.Name = "one_nat_1";
            this.one_nat_1.Size = new System.Drawing.Size(60, 14);
            this.one_nat_1.TextAlign = HorizontalAlignment.Right;
            this.one_nat_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.one_nat_1.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "OneNat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.one_nat_1.ReadOnly = true;
            this.Controls.Add(one_nat_1);

            //
            // one_ch
            //
            one_ch = new System.Windows.Forms.TextBox();
            this.one_ch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.one_ch.Font = new System.Drawing.Font("Arial", 8F);
            this.one_ch.ForeColor = System.Drawing.Color.Black;
            this.one_ch.Location = new System.Drawing.Point(557, 144);
            this.one_ch.MaxLength = 0;
            this.one_ch.Name = "one_ch";
            this.one_ch.Size = new System.Drawing.Size(60, 14);
            this.one_ch.TextAlign = HorizontalAlignment.Right;
            this.one_ch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.one_ch.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "OneCh", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.one_ch.ReadOnly = true;
            this.Controls.Add(one_ch);

            //
            // one_dun
            //
            one_dun = new System.Windows.Forms.TextBox();
            this.one_dun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.one_dun.Font = new System.Drawing.Font("Arial", 8F);
            this.one_dun.ForeColor = System.Drawing.Color.Black;
            this.one_dun.Location = new System.Drawing.Point(622, 144);
            this.one_dun.MaxLength = 0;
            this.one_dun.Name = "one_dun";
            this.one_dun.Size = new System.Drawing.Size(60, 14);
            this.one_dun.TextAlign = HorizontalAlignment.Right;
            this.one_dun.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.one_dun.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "OneDun", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.one_dun.ReadOnly = true;
            this.Controls.Add(one_dun);

            //
            // one_ham
            //
            one_ham = new System.Windows.Forms.TextBox();
            this.one_ham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.one_ham.Font = new System.Drawing.Font("Arial", 8F);
            this.one_ham.ForeColor = System.Drawing.Color.Black;
            this.one_ham.Location = new System.Drawing.Point(687, 144);
            this.one_ham.MaxLength = 0;
            this.one_ham.Name = "one_ham";
            this.one_ham.Size = new System.Drawing.Size(60, 14);
            this.one_ham.TextAlign = HorizontalAlignment.Right;
            this.one_ham.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.one_ham.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "OneHam", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.one_ham.ReadOnly = true;
            this.Controls.Add(one_ham);

            //
            // one_p
            //
            one_p = new System.Windows.Forms.TextBox();
            this.one_p.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.one_p.Font = new System.Drawing.Font("Arial", 8F);
            this.one_p.ForeColor = System.Drawing.Color.Black;
            this.one_p.Location = new System.Drawing.Point(752, 144);
            this.one_p.MaxLength = 0;
            this.one_p.Name = "one_p";
            this.one_p.Size = new System.Drawing.Size(60, 14);
            this.one_p.TextAlign = HorizontalAlignment.Right;
            this.one_p.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.one_p.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "OneP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.one_p.ReadOnly = true;
            this.Controls.Add(one_p);

            //
            // one_rot
            //
            one_rot = new System.Windows.Forms.TextBox();
            this.one_rot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.one_rot.Font = new System.Drawing.Font("Arial", 8F);
            this.one_rot.ForeColor = System.Drawing.Color.Black;
            this.one_rot.Location = new System.Drawing.Point(817, 144);
            this.one_rot.MaxLength = 0;
            this.one_rot.Name = "one_rot";
            this.one_rot.Size = new System.Drawing.Size(60, 14);
            this.one_rot.TextAlign = HorizontalAlignment.Right;
            this.one_rot.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.one_rot.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "OneRot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.one_rot.ReadOnly = true;
            this.Controls.Add(one_rot);

            //
            // one_w
            //
            one_w = new System.Windows.Forms.TextBox();
            this.one_w.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.one_w.Font = new System.Drawing.Font("Arial", 8F);
            this.one_w.ForeColor = System.Drawing.Color.Black;
            this.one_w.Location = new System.Drawing.Point(883, 144);
            this.one_w.MaxLength = 0;
            this.one_w.Name = "one_w";
            this.one_w.Size = new System.Drawing.Size(60, 14);
            this.one_w.TextAlign = HorizontalAlignment.Right;
            this.one_w.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.one_w.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "OneW", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.one_w.ReadOnly = true;
            this.Controls.Add(one_w);

            //
            // cust_tot
            //
            cust_tot = new System.Windows.Forms.TextBox();
            this.cust_tot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cust_tot.Font = new System.Drawing.Font("Arial", 8F);
            this.cust_tot.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cust_tot.Location = new System.Drawing.Point(89, 168);
            this.cust_tot.Name = "cust_tot";
            this.cust_tot.Size = new System.Drawing.Size(57, 14);
            this.cust_tot.TextAlign = HorizontalAlignment.Left;
            this.cust_tot.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.cust_tot.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "CustTot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(cust_tot);

            //
            // compute_7
            //
            compute_7 = new System.Windows.Forms.TextBox();
            this.compute_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_7.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_7.ForeColor = System.Drawing.Color.Black;
            this.compute_7.Location = new System.Drawing.Point(162, 168);
            this.compute_7.Name = "compute_7";
            this.compute_7.Size = new System.Drawing.Size(60, 14);
            this.compute_7.TextAlign = HorizontalAlignment.Left;
            this.compute_7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.compute_7.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Compute7", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(compute_7);

            //
            // total_nat
            //
            total_nat = new System.Windows.Forms.TextBox();
            this.total_nat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.total_nat.Font = new System.Drawing.Font("Arial", 8F);
            this.total_nat.ForeColor = System.Drawing.Color.Black;
            this.total_nat.Location = new System.Drawing.Point(250, 168);
            this.total_nat.MaxLength = 0;
            this.total_nat.Name = "total_nat";
            this.total_nat.Size = new System.Drawing.Size(60, 14);
            this.total_nat.TextAlign = HorizontalAlignment.Left;
            this.total_nat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.total_nat.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TotalNat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.total_nat.ReadOnly = true;
            this.Controls.Add(total_nat);

            //
            // t_25
            //
            this.t_25 = new System.Windows.Forms.Label();
            this.t_25.Font = new System.Drawing.Font("Arial", 8F);
            this.t_25.ForeColor = System.Drawing.SystemColors.WindowText;
            this.t_25.Location = new System.Drawing.Point(414, 168);
            this.t_25.Name = "t_25";
            this.t_25.Size = new System.Drawing.Size(47, 14);
            this.t_25.Text = "99.88%";
            this.t_25.TextAlign = ContentAlignment.MiddleRight;
            this.t_25.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.Controls.Add(t_25);

            //
            // total_nat_1
            //
            total_nat_1 = new System.Windows.Forms.TextBox();
            this.total_nat_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.total_nat_1.Font = new System.Drawing.Font("Arial", 8F);
            this.total_nat_1.ForeColor = System.Drawing.Color.Black;
            this.total_nat_1.Location = new System.Drawing.Point(485, 168);
            this.total_nat_1.MaxLength = 0;
            this.total_nat_1.Name = "total_nat_1";
            this.total_nat_1.Size = new System.Drawing.Size(60, 14);
            this.total_nat_1.TextAlign = HorizontalAlignment.Right;
            this.total_nat_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.total_nat_1.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TotalNat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.total_nat_1.ReadOnly = true;
            this.Controls.Add(total_nat_1);

            //
            // total_ch
            //
            total_ch = new System.Windows.Forms.TextBox();
            this.total_ch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.total_ch.Font = new System.Drawing.Font("Arial", 8F);
            this.total_ch.ForeColor = System.Drawing.Color.Black;
            this.total_ch.Location = new System.Drawing.Point(557, 168);
            this.total_ch.MaxLength = 0;
            this.total_ch.Name = "total_ch";
            this.total_ch.Size = new System.Drawing.Size(60, 14);
            this.total_ch.TextAlign = HorizontalAlignment.Right;
            this.total_ch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.total_ch.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TotalCh", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.total_ch.ReadOnly = true;
            this.Controls.Add(total_ch);

            //
            // total_dun
            //
            total_dun = new System.Windows.Forms.TextBox();
            this.total_dun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.total_dun.Font = new System.Drawing.Font("Arial", 8F);
            this.total_dun.ForeColor = System.Drawing.Color.Black;
            this.total_dun.Location = new System.Drawing.Point(622, 168);
            this.total_dun.MaxLength = 0;
            this.total_dun.Name = "total_dun";
            this.total_dun.Size = new System.Drawing.Size(60, 14);
            this.total_dun.TextAlign = HorizontalAlignment.Right;
            this.total_dun.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.total_dun.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TotalDun", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.total_dun.ReadOnly = true;
            this.Controls.Add(total_dun);

            //
            // total_ham
            //
            total_ham = new System.Windows.Forms.TextBox();
            this.total_ham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.total_ham.Font = new System.Drawing.Font("Arial", 8F);
            this.total_ham.ForeColor = System.Drawing.Color.Black;
            this.total_ham.Location = new System.Drawing.Point(687, 168);
            this.total_ham.MaxLength = 0;
            this.total_ham.Name = "total_ham";
            this.total_ham.Size = new System.Drawing.Size(60, 14);
            this.total_ham.TextAlign = HorizontalAlignment.Right;
            this.total_ham.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.total_ham.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TotalHam", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.total_ham.ReadOnly = true;
            this.Controls.Add(total_ham);

            //
            // total_p
            //
            total_p = new System.Windows.Forms.TextBox();
            this.total_p.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.total_p.Font = new System.Drawing.Font("Arial", 8F);
            this.total_p.ForeColor = System.Drawing.Color.Black;
            this.total_p.Location = new System.Drawing.Point(752, 168);
            this.total_p.MaxLength = 0;
            this.total_p.Name = "total_p";
            this.total_p.Size = new System.Drawing.Size(60, 14);
            this.total_p.TextAlign = HorizontalAlignment.Right;
            this.total_p.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.total_p.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TotalP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.total_p.ReadOnly = true;
            this.Controls.Add(total_p);

            //
            // total_rot
            //
            total_rot = new System.Windows.Forms.TextBox();
            this.total_rot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.total_rot.Font = new System.Drawing.Font("Arial", 8F);
            this.total_rot.ForeColor = System.Drawing.Color.Black;
            this.total_rot.Location = new System.Drawing.Point(817, 168);
            this.total_rot.MaxLength = 0;
            this.total_rot.Name = "total_rot";
            this.total_rot.Size = new System.Drawing.Size(60, 14);
            this.total_rot.TextAlign = HorizontalAlignment.Right;
            this.total_rot.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.total_rot.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TotalRot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.total_rot.ReadOnly = true;
            this.Controls.Add(total_rot);

            //
            // total_w
            //
            total_w = new System.Windows.Forms.TextBox();
            this.total_w.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.total_w.Font = new System.Drawing.Font("Arial", 8F);
            this.total_w.ForeColor = System.Drawing.Color.Black;
            this.total_w.Location = new System.Drawing.Point(883, 168);
            this.total_w.MaxLength = 0;
            this.total_w.Name = "total_w";
            this.total_w.Size = new System.Drawing.Size(60, 14);
            this.total_w.TextAlign = HorizontalAlignment.Right;
            this.total_w.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.total_w.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "TotalW", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.total_w.ReadOnly = true;
            this.Controls.Add(total_w);

            //
            // t_26
            //
            this.t_26 = new System.Windows.Forms.Label();
            this.t_26.Font = new System.Drawing.Font("Arial", 8F);
            this.t_26.ForeColor = System.Drawing.Color.Black;
            this.t_26.Location = new System.Drawing.Point(10, 194);
            this.t_26.Name = "t_26";
            this.t_26.Size = new System.Drawing.Size(59, 14);
            this.t_26.Text = "Under 5 day";
            this.t_26.TextAlign = ContentAlignment.MiddleRight;
            this.t_26.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_26);

            //
            // cust_sub_5
            //
            cust_sub_5 = new System.Windows.Forms.TextBox();
            this.cust_sub_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cust_sub_5.Font = new System.Drawing.Font("Arial", 8F);
            this.cust_sub_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cust_sub_5.Location = new System.Drawing.Point(89, 194);
            this.cust_sub_5.Name = "cust_sub_5";
            this.cust_sub_5.Size = new System.Drawing.Size(57, 14);
            this.cust_sub_5.TextAlign = HorizontalAlignment.Left;
            this.cust_sub_5.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.cust_sub_5.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "CustSub5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(cust_sub_5);

            //
            // pvt_sub_five
            //
            pvt_sub_five = new System.Windows.Forms.TextBox();
            this.pvt_sub_five.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pvt_sub_five.Font = new System.Drawing.Font("Arial", 8F);
            this.pvt_sub_five.ForeColor = System.Drawing.SystemColors.WindowText;
            this.pvt_sub_five.Location = new System.Drawing.Point(162, 194);
            this.pvt_sub_five.Name = "pvt_sub_five";
            this.pvt_sub_five.Size = new System.Drawing.Size(60, 14);
            this.pvt_sub_five.TextAlign = HorizontalAlignment.Left;
            this.pvt_sub_five.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.pvt_sub_five.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "PvtSubFive", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(pvt_sub_five);

            //
            // compute_8
            //
            compute_8 = new System.Windows.Forms.TextBox();
            this.compute_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_8.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.compute_8.Location = new System.Drawing.Point(250, 194);
            this.compute_8.Name = "compute_8";
            this.compute_8.Size = new System.Drawing.Size(60, 14);
            this.compute_8.TextAlign = HorizontalAlignment.Left;
            this.compute_8.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.compute_8.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Compute8", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(compute_8);

            //
            // compute_9
            //
            compute_9 = new System.Windows.Forms.TextBox();
            this.compute_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_9.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_9.ForeColor = System.Drawing.Color.Black;
            this.compute_9.Location = new System.Drawing.Point(339, 194);
            this.compute_9.Name = "compute_9";
            this.compute_9.Size = new System.Drawing.Size(40, 14);
            this.compute_9.TextAlign = HorizontalAlignment.Left;
            this.compute_9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.compute_9.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Compute9", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(compute_9);

            //
            // u5_nat
            //
            u5_nat = new System.Windows.Forms.TextBox();
            this.u5_nat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.u5_nat.Font = new System.Drawing.Font("Arial", 8F);
            this.u5_nat.ForeColor = System.Drawing.SystemColors.WindowText;
            this.u5_nat.Location = new System.Drawing.Point(485, 194);
            this.u5_nat.Name = "u5_nat";
            this.u5_nat.Size = new System.Drawing.Size(60, 14);
            this.u5_nat.TextAlign = HorizontalAlignment.Right;
            this.u5_nat.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.u5_nat.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "U5Nat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(u5_nat);

            //
            // u5_ch
            //
            u5_ch = new System.Windows.Forms.TextBox();
            this.u5_ch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.u5_ch.Font = new System.Drawing.Font("Arial", 8F);
            this.u5_ch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.u5_ch.Location = new System.Drawing.Point(557, 194);
            this.u5_ch.Name = "u5_ch";
            this.u5_ch.Size = new System.Drawing.Size(60, 14);
            this.u5_ch.TextAlign = HorizontalAlignment.Right;
            this.u5_ch.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.u5_ch.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "U5Ch", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(u5_ch);

            //
            // u5_dun
            //
            u5_dun = new System.Windows.Forms.TextBox();
            this.u5_dun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.u5_dun.Font = new System.Drawing.Font("Arial", 8F);
            this.u5_dun.ForeColor = System.Drawing.SystemColors.WindowText;
            this.u5_dun.Location = new System.Drawing.Point(622, 194);
            this.u5_dun.Name = "u5_dun";
            this.u5_dun.Size = new System.Drawing.Size(60, 14);
            this.u5_dun.TextAlign = HorizontalAlignment.Right;
            this.u5_dun.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.u5_dun.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "U5Dun", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(u5_dun);

            //
            // u5_ham
            //
            u5_ham = new System.Windows.Forms.TextBox();
            this.u5_ham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.u5_ham.Font = new System.Drawing.Font("Arial", 8F);
            this.u5_ham.ForeColor = System.Drawing.SystemColors.WindowText;
            this.u5_ham.Location = new System.Drawing.Point(687, 194);
            this.u5_ham.Name = "u5_ham";
            this.u5_ham.Size = new System.Drawing.Size(60, 14);
            this.u5_ham.TextAlign = HorizontalAlignment.Right;
            this.u5_ham.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.u5_ham.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "U5Ham", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(u5_ham);

            //
            // u5_p
            //
            u5_p = new System.Windows.Forms.TextBox();
            this.u5_p.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.u5_p.Font = new System.Drawing.Font("Arial", 8F);
            this.u5_p.ForeColor = System.Drawing.SystemColors.WindowText;
            this.u5_p.Location = new System.Drawing.Point(752, 194);
            this.u5_p.Name = "u5_p";
            this.u5_p.Size = new System.Drawing.Size(60, 14);
            this.u5_p.TextAlign = HorizontalAlignment.Right;
            this.u5_p.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.u5_p.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "U5P", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(u5_p);

            //
            // u5_rot
            //
            u5_rot = new System.Windows.Forms.TextBox();
            this.u5_rot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.u5_rot.Font = new System.Drawing.Font("Arial", 8F);
            this.u5_rot.ForeColor = System.Drawing.SystemColors.WindowText;
            this.u5_rot.Location = new System.Drawing.Point(817, 194);
            this.u5_rot.Name = "u5_rot";
            this.u5_rot.Size = new System.Drawing.Size(60, 14);
            this.u5_rot.TextAlign = HorizontalAlignment.Right;
            this.u5_rot.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.u5_rot.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "U5Rot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(u5_rot);

            //
            // u5_w
            //
            u5_w = new System.Windows.Forms.TextBox();
            this.u5_w.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.u5_w.Font = new System.Drawing.Font("Arial", 8F);
            this.u5_w.ForeColor = System.Drawing.SystemColors.WindowText;
            this.u5_w.Location = new System.Drawing.Point(883, 194);
            this.u5_w.Name = "u5_w";
            this.u5_w.Size = new System.Drawing.Size(60, 14);
            this.u5_w.TextAlign = HorizontalAlignment.Right;
            this.u5_w.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.u5_w.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "U5W", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(u5_w);

            //
            // compute_1
            //
            compute_1 = new System.Windows.Forms.TextBox();
            this.compute_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_1.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_1.ForeColor = System.Drawing.Color.Black;
            this.compute_1.Location = new System.Drawing.Point(871, 3);
            this.compute_1.Name = "compute_1";
            this.compute_1.Size = new System.Drawing.Size(72, 14);
            this.compute_1.TextAlign = HorizontalAlignment.Right;
            this.compute_1.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.compute_1.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Compute1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(compute_1);

            //
            // compute_2
            //
            compute_2 = new System.Windows.Forms.TextBox();
            this.compute_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_2.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_2.ForeColor = System.Drawing.Color.Black;
            this.compute_2.Location = new System.Drawing.Point(339, 44);
            this.compute_2.Name = "compute_2";
            this.compute_2.Size = new System.Drawing.Size(40, 14);
            this.compute_2.TextAlign = HorizontalAlignment.Left;
            this.compute_2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.compute_2.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "Compute2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Controls.Add(compute_2);

            //
            // t_17
            //
            this.t_17 = new System.Windows.Forms.Label();
            this.t_17.Font = new System.Drawing.Font("Arial", 8F);
            this.t_17.ForeColor = System.Drawing.SystemColors.WindowText;
            this.t_17.Location = new System.Drawing.Point(414, 44);
            this.t_17.Name = "t_17";
            this.t_17.Size = new System.Drawing.Size(47, 14);
            this.t_17.Text = "95.00%";
            this.t_17.TextAlign = ContentAlignment.MiddleRight;
            this.t_17.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.Controls.Add(t_17);

            //
            // six_nat_1
            //
            six_nat_1 = new System.Windows.Forms.TextBox();
            this.six_nat_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.six_nat_1.Font = new System.Drawing.Font("Arial", 8F);
            this.six_nat_1.ForeColor = System.Drawing.Color.Black;
            this.six_nat_1.Location = new System.Drawing.Point(486, 44);
            this.six_nat_1.MaxLength = 0;
            this.six_nat_1.Name = "six_nat_1";
            this.six_nat_1.Size = new System.Drawing.Size(60, 14);
            this.six_nat_1.TextAlign = HorizontalAlignment.Right;
            this.six_nat_1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.six_nat_1.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "SixNat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.six_nat_1.ReadOnly = true;
            this.Controls.Add(six_nat_1);

            //
            // six_ch
            //
            six_ch = new System.Windows.Forms.TextBox();
            this.six_ch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.six_ch.Font = new System.Drawing.Font("Arial", 8F);
            this.six_ch.ForeColor = System.Drawing.Color.Black;
            this.six_ch.Location = new System.Drawing.Point(557, 44);
            this.six_ch.MaxLength = 0;
            this.six_ch.Name = "six_ch";
            this.six_ch.Size = new System.Drawing.Size(60, 14);
            this.six_ch.TextAlign = HorizontalAlignment.Right;
            this.six_ch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.six_ch.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "SixCh", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.six_ch.ReadOnly = true;
            this.Controls.Add(six_ch);

            //
            // six_dun
            //
            six_dun = new System.Windows.Forms.TextBox();
            this.six_dun.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.six_dun.Font = new System.Drawing.Font("Arial", 8F);
            this.six_dun.ForeColor = System.Drawing.Color.Black;
            this.six_dun.Location = new System.Drawing.Point(622, 44);
            this.six_dun.MaxLength = 0;
            this.six_dun.Name = "six_dun";
            this.six_dun.Size = new System.Drawing.Size(60, 14);
            this.six_dun.TextAlign = HorizontalAlignment.Right;
            this.six_dun.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.six_dun.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "SixDun", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.six_dun.ReadOnly = true;
            this.Controls.Add(six_dun);

            //
            // six_ham
            //
            six_ham = new System.Windows.Forms.TextBox();
            this.six_ham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.six_ham.Font = new System.Drawing.Font("Arial", 8F);
            this.six_ham.ForeColor = System.Drawing.Color.Black;
            this.six_ham.Location = new System.Drawing.Point(687, 44);
            this.six_ham.MaxLength = 0;
            this.six_ham.Name = "six_ham";
            this.six_ham.Size = new System.Drawing.Size(60, 14);
            this.six_ham.TextAlign = HorizontalAlignment.Right;
            this.six_ham.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.six_ham.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "SixHam", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.six_ham.ReadOnly = true;
            this.Controls.Add(six_ham);

            //
            // six_p
            //
            six_p = new System.Windows.Forms.TextBox();
            this.six_p.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.six_p.Font = new System.Drawing.Font("Arial", 8F);
            this.six_p.ForeColor = System.Drawing.Color.Black;
            this.six_p.Location = new System.Drawing.Point(752, 44);
            this.six_p.MaxLength = 0;
            this.six_p.Name = "six_p";
            this.six_p.Size = new System.Drawing.Size(60, 14);
            this.six_p.TextAlign = HorizontalAlignment.Right;
            this.six_p.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.six_p.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "SixP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.six_p.ReadOnly = true;
            this.Controls.Add(six_p);

            //
            // six_rot
            //
            six_rot = new System.Windows.Forms.TextBox();
            this.six_rot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.six_rot.Font = new System.Drawing.Font("Arial", 8F);
            this.six_rot.ForeColor = System.Drawing.Color.Black;
            this.six_rot.Location = new System.Drawing.Point(817, 44);
            this.six_rot.MaxLength = 0;
            this.six_rot.Name = "six_rot";
            this.six_rot.Size = new System.Drawing.Size(60, 14);
            this.six_rot.TextAlign = HorizontalAlignment.Right;
            this.six_rot.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.six_rot.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "SixRot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.six_rot.ReadOnly = true;
            this.Controls.Add(six_rot);

            //
            // six_w
            //
            six_w = new System.Windows.Forms.TextBox();
            this.six_w.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.six_w.Font = new System.Drawing.Font("Arial", 8F);
            this.six_w.ForeColor = System.Drawing.Color.Black;
            this.six_w.Location = new System.Drawing.Point(883, 44);
            this.six_w.MaxLength = 0;
            this.six_w.Name = "six_w";
            this.six_w.Size = new System.Drawing.Size(60, 14);
            this.six_w.TextAlign = HorizontalAlignment.Right;
            this.six_w.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.six_w.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "SixW", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.six_w.ReadOnly = true;
            this.Controls.Add(six_w);

            //
            // t_13
            //
            this.t_13 = new System.Windows.Forms.Label();
            this.t_13.Font = new System.Drawing.Font("Arial", 8F);
            this.t_13.ForeColor = System.Drawing.Color.Black;
            this.t_13.Location = new System.Drawing.Point(753, 13);
            this.t_13.Name = "t_13";
            this.t_13.Size = new System.Drawing.Size(59, 28);
            this.t_13.Text = "Palmerston North";
            this.t_13.TextAlign = ContentAlignment.MiddleRight;
            this.t_13.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_13);

            //
            // t_8
            //
            this.t_8 = new System.Windows.Forms.Label();
            this.t_8.Font = new System.Drawing.Font("Arial", 8F);
            this.t_8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.t_8.Location = new System.Drawing.Point(414, 27);
            this.t_8.Name = "t_8";
            this.t_8.Size = new System.Drawing.Size(41, 14);
            this.t_8.Text = "Target";
            this.t_8.TextAlign = ContentAlignment.MiddleRight;
            this.t_8.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.Controls.Add(t_8);

            //
            // t_9
            //
            this.t_9 = new System.Windows.Forms.Label();
            this.t_9.Font = new System.Drawing.Font("Arial", 8F);
            this.t_9.ForeColor = System.Drawing.Color.Black;
            this.t_9.Location = new System.Drawing.Point(491, 27);
            this.t_9.Name = "t_9";
            this.t_9.Size = new System.Drawing.Size(54, 14);
            this.t_9.Text = "National";
            this.t_9.TextAlign = ContentAlignment.MiddleRight;
            this.t_9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_9);

            //
            // t_10
            //
            this.t_10 = new System.Windows.Forms.Label();
            this.t_10.Font = new System.Drawing.Font("Arial", 8F);
            this.t_10.ForeColor = System.Drawing.Color.Black;
            this.t_10.Location = new System.Drawing.Point(555, 27);
            this.t_10.Name = "t_10";
            this.t_10.Size = new System.Drawing.Size(62, 14);
            this.t_10.Text = "Christchurch";
            this.t_10.TextAlign = ContentAlignment.MiddleRight;
            this.t_10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_10);

            //
            // t_11
            //
            this.t_11 = new System.Windows.Forms.Label();
            this.t_11.Font = new System.Drawing.Font("Arial", 8F);
            this.t_11.ForeColor = System.Drawing.Color.Black;
            this.t_11.Location = new System.Drawing.Point(628, 27);
            this.t_11.Name = "t_11";
            this.t_11.Size = new System.Drawing.Size(54, 14);
            this.t_11.Text = "Dunedin";
            this.t_11.TextAlign = ContentAlignment.MiddleRight;
            this.t_11.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_11);

            //
            // t_14
            //
            this.t_14 = new System.Windows.Forms.Label();
            this.t_14.Font = new System.Drawing.Font("Arial", 8F);
            this.t_14.ForeColor = System.Drawing.Color.Black;
            this.t_14.Location = new System.Drawing.Point(833, 27);
            this.t_14.Name = "t_14";
            this.t_14.Size = new System.Drawing.Size(44, 14);
            this.t_14.Text = "Rotorua";
            this.t_14.TextAlign = ContentAlignment.MiddleRight;
            this.t_14.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_14);

            //
            // t_15
            //
            this.t_15 = new System.Windows.Forms.Label();
            this.t_15.Font = new System.Drawing.Font("Arial", 8F);
            this.t_15.ForeColor = System.Drawing.Color.Black;
            this.t_15.Location = new System.Drawing.Point(888, 27);
            this.t_15.Name = "t_15";
            this.t_15.Size = new System.Drawing.Size(55, 14);
            this.t_15.Text = "Whangarei";
            this.t_15.TextAlign = ContentAlignment.MiddleRight;
            this.t_15.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_15);

            //
            // t_12
            //
            this.t_12 = new System.Windows.Forms.Label();
            this.t_12.Font = new System.Drawing.Font("Arial", 8F);
            this.t_12.ForeColor = System.Drawing.Color.Black;
            this.t_12.Location = new System.Drawing.Point(689, 27);
            this.t_12.Name = "t_12";
            this.t_12.Size = new System.Drawing.Size(58, 14);
            this.t_12.Text = "Hamilton";
            this.t_12.TextAlign = ContentAlignment.MiddleRight;
            this.t_12.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(t_12);

            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
        }
        #endregion

    }
}
