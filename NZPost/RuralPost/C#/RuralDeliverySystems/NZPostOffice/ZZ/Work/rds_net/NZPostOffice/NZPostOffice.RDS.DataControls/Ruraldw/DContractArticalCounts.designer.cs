using System.Windows.Forms;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractArticalCountsTest
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
            this.compute_1 = new System.Windows.Forms.Label();
            this.ac_start_week_period = new System.Windows.Forms.Label();
            this.ac_w1_inward_mail = new TextBox();
            this.t_8 = new System.Windows.Forms.Label();
            this.ac_w1_medium_letters = new TextBox();
            this.ac_w1_other_envelopes = new TextBox();
            this.week1del = new System.Windows.Forms.Label();
            this.ac_w2_inward_mail = new TextBox();
            this.t_9 = new System.Windows.Forms.Label();
            this.ac_w2_medium_letters = new TextBox();
            this.ac_w2_other_envelopes = new TextBox();
            this.week2del = new System.Windows.Forms.Label();
            this.t_7 = new System.Windows.Forms.Label();
            this.compute_5 = new System.Windows.Forms.Label();
            this.compute_6 = new System.Windows.Forms.Label();
            this.compute_7 = new System.Windows.Forms.Label();
            this.compute_2 = new System.Windows.Forms.Label();
            this.ac_w1_small_parcels = new TextBox();
            this.ac_w2_small_parcels = new TextBox();
            this.compute_3 = new System.Windows.Forms.Label();
            this.ac_w1_large_parcels = new TextBox();
            this.ac_w2_large_parcels = new TextBox();
            this.compute_4 = new System.Windows.Forms.Label();
            this.l_1 = new Panel();
            this.l_2 = new Panel();
            this.l_3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractArticalCounts);
            
            // 
            // compute_1
            // 
            this.compute_1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_1.Location = new System.Drawing.Point(6, 0);
            this.compute_1.Name = "compute_1";
            //this.compute_1.BorderStyle = BorderStyle.None; 
            this.compute_1.Size = new System.Drawing.Size(49, 20);
            //this.compute_1.BorderStyle = BorderStyle.None;
            this.compute_1.BackColor = System.Drawing.Color.Transparent;
            this.compute_1.TabIndex = 0;
            //this.compute_1.ReadOnly = true; 
            // 
            // ac_start_week_period
            // 
            this.ac_start_week_period.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AcStartWeekPeriod", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.ac_start_week_period.ReadOnly = true;
            this.ac_start_week_period.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_start_week_period.Location = new System.Drawing.Point(66, 0);
            //this.ac_start_week_period.BorderStyle = BorderStyle.None;
            this.ac_start_week_period.Name = "ac_start_week_period";
            this.ac_start_week_period.Size = new System.Drawing.Size(85, 20);
            this.ac_start_week_period.TabIndex = 0;
            //this.ac_start_week_period.BorderStyle = BorderStyle.None;
            // 
            // ac_w1_inward_mail
            // 
            this.ac_w1_inward_mail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AcW1InwardMail", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //this.ac_w1_inward_mail.ReadOnly = true;
            this.ac_w1_inward_mail.ReadOnly = true;
            this.ac_w1_inward_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_inward_mail.Location = new System.Drawing.Point(448, 0);
            //this.ac_w1_inward_mail.EditMask = "#,###";
            this.ac_w1_inward_mail.Name = "ac_w1_inward_mail";
            this.ac_w1_inward_mail.Size = new System.Drawing.Size(44, 20);
            //this.ac_w1_inward_mail.BorderStyle = BorderStyle.None;
            this.ac_w1_inward_mail.TabIndex = 0;
            this.ac_w1_inward_mail.DataBindings[0].FormatString = "#,###";
            //this.ac_w1_inward_mail.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ac_w1_inward_mail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //this.ac_w1_inward_mail.PromptChar = ' ';
            //this.ac_w1_inward_mail.BorderStyle = BorderStyle.None;
            // 
            // t_8
            // 
            this.t_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_8.Location = new System.Drawing.Point(156, 0);
            this.t_8.Name = "t_8";
            this.t_8.Size = new System.Drawing.Size(27, 13);
            this.t_8.TabIndex = 0;
            this.t_8.Text = "One";
            this.t_8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ac_w1_medium_letters
            // 
            this.ac_w1_medium_letters.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AcW1MediumLetters", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w1_medium_letters.ReadOnly = true;
            this.ac_w1_medium_letters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_medium_letters.Location = new System.Drawing.Point(195, 0);
            //this.ac_w1_medium_letters.EditMask = "#,###";            
            //this.ac_w1_medium_letters.PromptChar = ' ';            
            this.ac_w1_medium_letters.Name = "ac_w1_medium_letters";
            this.ac_w1_medium_letters.Size = new System.Drawing.Size(44, 20);
            //this.ac_w1_medium_letters.BorderStyle = BorderStyle.None;
            this.ac_w1_medium_letters.TabIndex = 0;
            this.ac_w1_medium_letters.DataBindings[0].FormatString = "#,###";
            //this.ac_w1_medium_letters.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ac_w1_medium_letters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //this.ac_w1_medium_letters.PromptChar = ' ';
            //this.ac_w1_medium_letters.BorderStyle = BorderStyle.None;
            // 
            // ac_w1_other_envelopes
            // 
            this.ac_w1_other_envelopes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AcW1OtherEnvelopes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w1_other_envelopes.ReadOnly = true;
            this.ac_w1_other_envelopes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_other_envelopes.Location = new System.Drawing.Point(244, 0);
            //this.ac_w1_other_envelopes.EditMask = "#,###";
            this.ac_w1_other_envelopes.Name = "ac_w1_other_envelopes";
            this.ac_w1_other_envelopes.Size = new System.Drawing.Size(45, 20);
            this.ac_w1_other_envelopes.TabIndex = 0;
            this.ac_w1_other_envelopes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w1_other_envelopes.DataBindings[0].FormatString = "#,###";
            //this.ac_w1_other_envelopes.InsertKeyMode = InsertKeyMode.Overwrite;
            //this.ac_w1_other_envelopes.PromptChar = ' ';
            //this.ac_w1_other_envelopes.BorderStyle = BorderStyle.None;
            // 
            // week1del
            // 
            this.week1del.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Week1del", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.week1del.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.week1del.Location = new System.Drawing.Point(340, 0);
            this.week1del.Name = "week1del";
            this.week1del.Size = new System.Drawing.Size(51, 20);
            this.week1del.TabIndex = 0;
            this.week1del.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //this.week1del.ReadOnly = true;
            //this.week1del.BorderStyle = BorderStyle.None;
            this.week1del.DataBindings[0].FormatString = "#,##0";
            // 
            // ac_w2_inward_mail
            // 
            this.ac_w2_inward_mail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AcW2InwardMail", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w2_inward_mail.ReadOnly = true;
            this.ac_w2_inward_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_inward_mail.Location = new System.Drawing.Point(448, 25);
            //this.ac_w2_inward_mail.EditMask = "#,###";
            this.ac_w2_inward_mail.Name = "ac_w2_inward_mail";
            this.ac_w2_inward_mail.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_inward_mail.TabIndex = 0;
            this.ac_w2_inward_mail.DataBindings[0].FormatString = "#,###";
            //this.ac_w2_inward_mail.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ac_w2_inward_mail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //this.ac_w2_inward_mail.PromptChar = ' ';
            //this.ac_w2_inward_mail.BorderStyle = BorderStyle.None;
            // 
            // t_9
            // 
            this.t_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_9.Location = new System.Drawing.Point(156, 24);
            this.t_9.Name = "t_9";
            this.t_9.Size = new System.Drawing.Size(28, 13);
            this.t_9.TabIndex = 0;
            this.t_9.Text = "Two";
            this.t_9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // l_1
            // 
            l_1.Height = 1;
            l_1.Width = 342;
            //l_1.BorderStyle = BorderStyle.None;
            l_1.BackColor = System.Drawing.Color.Black;
            l_1.Location = new System.Drawing.Point(150, 40);

            // 
            // ac_w2_medium_letters
            // 
            this.ac_w2_medium_letters.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AcW2MediumLetters", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w2_medium_letters.ReadOnly = true;
            this.ac_w2_medium_letters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_medium_letters.Location = new System.Drawing.Point(195, 25);
            //this.ac_w2_medium_letters.EditMask = "#,###";
            this.ac_w2_medium_letters.Name = "ac_w2_medium_letters";
            this.ac_w2_medium_letters.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_medium_letters.TabIndex = 0;
            this.ac_w2_medium_letters.DataBindings[0].FormatString = "#,###";
            //this.ac_w2_medium_letters.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ac_w2_medium_letters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //this.ac_w2_medium_letters.PromptChar = ' ';
            //this.ac_w2_medium_letters.BorderStyle = BorderStyle.None;
            // 
            // ac_w2_other_envelopes
            // 
            this.ac_w2_other_envelopes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AcW2OtherEnvelopes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w2_other_envelopes.ReadOnly = true;
            this.ac_w2_other_envelopes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_other_envelopes.Location = new System.Drawing.Point(245, 25);
            //this.ac_w2_other_envelopes.EditMask = "#,###";
            this.ac_w2_other_envelopes.Name = "ac_w2_other_envelopes";
            this.ac_w2_other_envelopes.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_other_envelopes.TabIndex = 0;
            this.ac_w2_other_envelopes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w2_other_envelopes.DataBindings[0].FormatString = "#,###";
            //this.ac_w2_other_envelopes.InsertKeyMode = InsertKeyMode.Overwrite;
            //this.ac_w2_other_envelopes.PromptChar = ' ';
            //this.ac_w2_other_envelopes.BorderStyle = BorderStyle.None;
            // 
            // week2del
            // 
            this.week2del.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Week2del", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.week2del.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.week2del.Location = new System.Drawing.Point(340, 22);
            this.week2del.Name = "week2del";
            this.week2del.Size = new System.Drawing.Size(51, 18);
            this.week2del.TabIndex = 0;
            this.week2del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //this.week2del.ReadOnly = true;
            //this.week2del.BorderStyle = BorderStyle.None;
            //this.week2del.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //this.week2del.ReadOnly = true;
            //this.week2del.BorderStyle = BorderStyle.None;
            this.week2del.DataBindings[0].FormatString = "#,##0";
            // 
            // t_7
            // 
            this.t_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_7.Location = new System.Drawing.Point(148, 44);
            this.t_7.Name = "t_7";
            this.t_7.Size = new System.Drawing.Size(40, 13);
            this.t_7.TabIndex = 0;
            this.t_7.Text = "Annual";
            this.t_7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // l_2
            // 
            l_2.Height = 1;
            l_2.Width = 342;
            //l_2.BorderStyle = BorderStyle.None;
            l_2.BackColor = System.Drawing.Color.Black;
            l_2.Location = new System.Drawing.Point(150, 62);

            // 
            // l_3
            // 
            l_3.Height = 1;
            l_3.Width = 342;
            //l_3.BorderStyle = BorderStyle.None;
            l_3.BackColor = System.Drawing.Color.Black;
            l_3.Location = new System.Drawing.Point(150, 64);

 
            // 
            // compute_5
            // 
            this.compute_5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_5.Location = new System.Drawing.Point(448, 42);
            this.compute_5.Name = "compute_5";
            this.compute_5.DataBindings[0].FormatString = "#,##0";
            this.compute_5.Size = new System.Drawing.Size(44, 20);
            this.compute_5.TabIndex = 0;
            this.compute_5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //this.compute_5.ReadOnly = true;
            //this.compute_5.BorderStyle = BorderStyle.None;
            //this.compute_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //this.compute_5.ReadOnly = true;
            //this.compute_5.BorderStyle = BorderStyle.None;
            // 
            // compute_6
            // 
            this.compute_6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_6.Location = new System.Drawing.Point(194, 42);
            this.compute_6.Name = "compute_6";
            this.compute_6.Size = new System.Drawing.Size(45, 20);
            this.compute_6.DataBindings[0].FormatString = "#,##0";
            this.compute_6.TabIndex = 0;
            this.compute_6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //this.compute_6.ReadOnly = true;
            //this.compute_6.BorderStyle = BorderStyle.None;
            //this.compute_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //this.compute_6.ReadOnly = true;
            //this.compute_6.BorderStyle = BorderStyle.None;
            // 
            // compute_7
            // 
            this.compute_7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute7", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_7.Location = new System.Drawing.Point(245, 42);
            this.compute_7.Name = "compute_7";
            this.compute_7.DataBindings[0].FormatString = "#,##0";
            this.compute_7.Size = new System.Drawing.Size(44, 20);
            this.compute_7.TabIndex = 0;
            this.compute_7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //this.compute_7.ReadOnly = true;
            //this.compute_7.BorderStyle = BorderStyle.None;
            //this.compute_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //this.compute_7.ReadOnly = true;
            //this.compute_7.BorderStyle = BorderStyle.None;
            // 
            // compute_2
            // 
            this.compute_2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_2.Location = new System.Drawing.Point(340, 42);
            this.compute_2.Name = "compute_2";
            this.compute_2.DataBindings[0].FormatString = "#,##0";
            this.compute_2.Size = new System.Drawing.Size(51, 20);
            this.compute_2.TabIndex = 0;
            this.compute_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //this.compute_2.ReadOnly = true;
            //this.compute_2.BorderStyle = BorderStyle.None;
            //this.compute_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //this.compute_2.ReadOnly = true;
            //this.compute_2.BorderStyle = BorderStyle.None;
            // 
            // ac_w1_small_parcels
            // 
            this.ac_w1_small_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AcW1SmallParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w1_small_parcels.ReadOnly = true;
            this.ac_w1_small_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_small_parcels.Location = new System.Drawing.Point(294, 0);
            //this.ac_w1_small_parcels.EditMask = "#,###";
            this.ac_w1_small_parcels.Name = "ac_w1_small_parcels";
            this.ac_w1_small_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_small_parcels.TabIndex = 0;
            this.ac_w1_small_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w1_small_parcels.DataBindings[0].FormatString = "#,###";
            //this.ac_w1_small_parcels.InsertKeyMode = InsertKeyMode.Overwrite;
            //this.ac_w1_small_parcels.PromptChar = ' ';
            //this.ac_w1_small_parcels.BorderStyle = BorderStyle.None;
            // 
            // ac_w2_small_parcels
            // 
            this.ac_w2_small_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AcW2SmallParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w2_small_parcels.ReadOnly = true;
            this.ac_w2_small_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_small_parcels.Location = new System.Drawing.Point(294, 25);
            //this.ac_w2_small_parcels.EditMask = "#,###";
            this.ac_w2_small_parcels.Name = "ac_w2_small_parcels";
            this.ac_w2_small_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_small_parcels.TabIndex = 0;
            this.ac_w2_small_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w2_small_parcels.DataBindings[0].FormatString = "#,###";
            //this.ac_w2_small_parcels.InsertKeyMode = InsertKeyMode.Overwrite;
            //this.ac_w2_small_parcels.PromptChar = ' ';
            //this.ac_w2_small_parcels.BorderStyle = BorderStyle.None;
            // 
            // compute_3
            // 
            this.compute_3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_3.Location = new System.Drawing.Point(296, 42);
            this.compute_3.Name = "compute_3";
            this.compute_3.DataBindings[0].FormatString = "#,##0";
            this.compute_3.Size = new System.Drawing.Size(44, 20);
            this.compute_3.TabIndex = 0;
            this.compute_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //this.compute_3.ReadOnly = true;
            //this.compute_3.BorderStyle = BorderStyle.None;
            //this.compute_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //this.compute_3.ReadOnly = true;
            //this.compute_3.BorderStyle = BorderStyle.None;
            // 
            // ac_w1_large_parcels
            // 
            this.ac_w1_large_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AcW1LargeParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w1_large_parcels.ReadOnly = true;
            this.ac_w1_large_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_large_parcels.Location = new System.Drawing.Point(399, 0);
            //this.ac_w1_large_parcels.EditMask = "#,###";
            this.ac_w1_large_parcels.Name = "ac_w1_large_parcels";
            this.ac_w1_large_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w1_large_parcels.TabIndex = 0;
            this.ac_w1_large_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w1_large_parcels.DataBindings[0].FormatString = "#,###";
            //this.ac_w1_large_parcels.InsertKeyMode = InsertKeyMode.Overwrite;
            //this.ac_w1_large_parcels.PromptChar = ' ';
            //this.ac_w1_large_parcels.BorderStyle = BorderStyle.None;
            // 
            // ac_w2_large_parcels
            // 
            this.ac_w2_large_parcels.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AcW2LargeParcels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ac_w2_large_parcels.ReadOnly = true;
            this.ac_w2_large_parcels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w2_large_parcels.Location = new System.Drawing.Point(399, 25);
            //this.ac_w2_large_parcels.EditMask = "#,###";
            this.ac_w2_large_parcels.Name = "ac_w2_large_parcels";
            this.ac_w2_large_parcels.Size = new System.Drawing.Size(44, 20);
            this.ac_w2_large_parcels.TabIndex = 0;
            this.ac_w2_large_parcels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ac_w2_large_parcels.DataBindings[0].FormatString = "#,###";
            //this.ac_w2_large_parcels.InsertKeyMode = InsertKeyMode.Overwrite;
            //this.ac_w2_large_parcels.PromptChar = ' ';
            //this.ac_w2_large_parcels.BorderStyle = BorderStyle.None;
            // 
            // compute_4
            // 
            this.compute_4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.compute_4.Location = new System.Drawing.Point(400, 42);
            this.compute_4.Name = "compute_4";
            this.compute_4.DataBindings[0].FormatString = "#,##0";
            this.compute_4.Size = new System.Drawing.Size(44, 20);
            this.compute_4.TabIndex = 0;
            this.compute_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //this.compute_4.ReadOnly = true;
            //this.compute_4.BorderStyle = BorderStyle.None;
            //this.compute_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //this.compute_4.ReadOnly = true;
            //this.compute_4.BorderStyle = BorderStyle.None;
            
            // 
            // DContractArticalCounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            
            this.Controls.Add(this.compute_1);
            this.Controls.Add(this.ac_start_week_period);
            this.Controls.Add(this.ac_w1_inward_mail);
            this.Controls.Add(this.t_8);
            this.Controls.Add(this.ac_w1_medium_letters);
            this.Controls.Add(this.ac_w1_other_envelopes);
            this.Controls.Add(this.week1del);
            this.Controls.Add(this.ac_w2_inward_mail);
            this.Controls.Add(this.t_9);
            this.Controls.Add(this.ac_w2_medium_letters);
            this.Controls.Add(this.ac_w2_other_envelopes);
            this.Controls.Add(this.week2del);
            this.Controls.Add(this.t_7);
            this.Controls.Add(this.compute_5);
            this.Controls.Add(this.compute_6);
            this.Controls.Add(this.compute_7);
            this.Controls.Add(this.compute_2);
            this.Controls.Add(this.ac_w1_small_parcels);
            this.Controls.Add(this.ac_w2_small_parcels);
            this.Controls.Add(this.compute_3);
            this.Controls.Add(this.ac_w1_large_parcels);
            this.Controls.Add(this.ac_w2_large_parcels);
            this.Controls.Add(this.compute_4);
            this.Controls.Add(this.l_1);
            this.Controls.Add(this.l_2);
            this.Controls.Add(this.l_3);
            this.Name = "DContractArticalCounts";
            this.Size = new System.Drawing.Size(650, 80);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label compute_1;
        private System.Windows.Forms.Label ac_start_week_period;
        private System.Windows.Forms.TextBox ac_w1_inward_mail;//private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w1_inward_mail;
        private System.Windows.Forms.Label t_8;
        private System.Windows.Forms.TextBox ac_w1_medium_letters;//private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w1_medium_letters;
        private System.Windows.Forms.TextBox ac_w1_other_envelopes;//private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w1_other_envelopes;
        private System.Windows.Forms.Label week1del;
        private System.Windows.Forms.TextBox ac_w2_inward_mail;//private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w2_inward_mail;
        private System.Windows.Forms.Label t_9;
        private System.Windows.Forms.TextBox ac_w2_medium_letters;//private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w2_medium_letters;
        private System.Windows.Forms.TextBox ac_w2_other_envelopes;//private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w2_other_envelopes;
        private System.Windows.Forms.Label week2del;
        private System.Windows.Forms.Label t_7;
        private System.Windows.Forms.Label compute_5;
        private System.Windows.Forms.Label compute_6;
        private System.Windows.Forms.Label compute_7;
        private System.Windows.Forms.Label compute_2;
        private System.Windows.Forms.TextBox ac_w1_small_parcels;//private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w1_small_parcels;
        private System.Windows.Forms.TextBox ac_w2_small_parcels;//private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w2_small_parcels;
        private System.Windows.Forms.Label compute_3;
        private System.Windows.Forms.TextBox ac_w1_large_parcels;//private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w1_large_parcels;
        private System.Windows.Forms.TextBox ac_w2_large_parcels;//private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox ac_w2_large_parcels;
        private System.Windows.Forms.Label compute_4;
        private System.Windows.Forms.Panel l_1;
        private System.Windows.Forms.Panel l_2;
        private System.Windows.Forms.Panel l_3;
    }
}
