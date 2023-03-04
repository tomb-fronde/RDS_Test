namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DRouteAudit
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
            this.Name = "DRouteAudit";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RouteAudit);
            #region contract_no_t define
            this.contract_no_t = new System.Windows.Forms.Label();
            this.contract_no_t.Name = "contract_no_t";
            this.contract_no_t.Location = new System.Drawing.Point(8, 2);
            this.contract_no_t.Size = new System.Drawing.Size(65, 13);
            this.contract_no_t.TabIndex = 0;
            this.contract_no_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.contract_no_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.contract_no_t.Text = "Contract No";
            #endregion
            this.Controls.Add(contract_no_t);
            #region ra_day_of_check_t define
            this.ra_day_of_check_t = new System.Windows.Forms.Label();
            this.ra_day_of_check_t.Name = "ra_day_of_check_t";
            this.ra_day_of_check_t.Location = new System.Drawing.Point(24, 38);
            this.ra_day_of_check_t.Size = new System.Drawing.Size(74, 13);
            this.ra_day_of_check_t.TabIndex = 0;
            this.ra_day_of_check_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_day_of_check_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_day_of_check_t.Text = "Day of Check";
            #endregion
            this.Controls.Add(ra_day_of_check_t);
            #region n_37124754 define
            this.n_37124754 = new System.Windows.Forms.Label();
            this.n_37124754.Name = "n_37124754";
            this.n_37124754.Location = new System.Drawing.Point(201, 38);
            this.n_37124754.Size = new System.Drawing.Size(78, 13);
            this.n_37124754.TabIndex = 0;
            this.n_37124754.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_37124754.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_37124754.Text = "Date of Check";
            #endregion
            this.Controls.Add(n_37124754);
            #region ra_finish_odometer_t define
            this.ra_finish_odometer_t = new System.Windows.Forms.Label();
            this.ra_finish_odometer_t.Name = "ra_finish_odometer_t";
            this.ra_finish_odometer_t.Location = new System.Drawing.Point(634, 196);
            this.ra_finish_odometer_t.Size = new System.Drawing.Size(130, 13);
            this.ra_finish_odometer_t.TabIndex = 0;
            this.ra_finish_odometer_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_finish_odometer_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_finish_odometer_t.Text = "Ra Finish Odometer:";
            #endregion
            this.Controls.Add(ra_finish_odometer_t);
            #region ra_finish_odometer define
            this.ra_finish_odometer = new System.Windows.Forms.TextBox();
            this.ra_finish_odometer.Name = "ra_finish_odometer";
            this.ra_finish_odometer.Location = new System.Drawing.Point(769, 196);
            this.ra_finish_odometer.Size = new System.Drawing.Size(85, 13);
            this.ra_finish_odometer.TabIndex = 90;
            this.ra_finish_odometer.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_finish_odometer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ra_finish_odometer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaFinishOdometer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(ra_finish_odometer);
            #region ra_start_odometer_t define
            this.ra_start_odometer_t = new System.Windows.Forms.Label();
            this.ra_start_odometer_t.Name = "ra_start_odometer_t";
            this.ra_start_odometer_t.Location = new System.Drawing.Point(634, 234);
            this.ra_start_odometer_t.Size = new System.Drawing.Size(130, 13);
            this.ra_start_odometer_t.TabIndex = 0;
            this.ra_start_odometer_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_start_odometer_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_start_odometer_t.Text = "Ra Start Odometer:";
            #endregion
            this.Controls.Add(ra_start_odometer_t);
            #region ra_start_odometer define
            this.ra_start_odometer = new System.Windows.Forms.TextBox();
            this.ra_start_odometer.Name = "ra_start_odometer";
            this.ra_start_odometer.Location = new System.Drawing.Point(769, 234);
            this.ra_start_odometer.Size = new System.Drawing.Size(85, 13);
            this.ra_start_odometer.TabIndex = 100;
            this.ra_start_odometer.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_start_odometer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ra_start_odometer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaStartOdometer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(ra_start_odometer);
            #region ra_meal_breaks_t define
            this.ra_meal_breaks_t = new System.Windows.Forms.Label();
            this.ra_meal_breaks_t.Name = "ra_meal_breaks_t";
            this.ra_meal_breaks_t.Location = new System.Drawing.Point(634, 272);
            this.ra_meal_breaks_t.Size = new System.Drawing.Size(130, 13);
            this.ra_meal_breaks_t.TabIndex = 0;
            this.ra_meal_breaks_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_meal_breaks_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_meal_breaks_t.Text = "Ra Meal Breaks:";
            #endregion
            this.Controls.Add(ra_meal_breaks_t);
            #region ra_meal_breaks define
            this.ra_meal_breaks = new System.Windows.Forms.TextBox();
            this.ra_meal_breaks.Name = "ra_meal_breaks";
            this.ra_meal_breaks.Location = new System.Drawing.Point(769, 272);
            this.ra_meal_breaks.Size = new System.Drawing.Size(62, 13);
            this.ra_meal_breaks.TabIndex = 110;
            this.ra_meal_breaks.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_meal_breaks.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ra_meal_breaks.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaMealBreaks", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(ra_meal_breaks);
            #region ra_extra_time_t define
            this.ra_extra_time_t = new System.Windows.Forms.Label();
            this.ra_extra_time_t.Name = "ra_extra_time_t";
            this.ra_extra_time_t.Location = new System.Drawing.Point(634, 310);
            this.ra_extra_time_t.Size = new System.Drawing.Size(130, 13);
            this.ra_extra_time_t.TabIndex = 0;
            this.ra_extra_time_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_extra_time_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_extra_time_t.Text = "Ra Extra Time:";
            #endregion
            this.Controls.Add(ra_extra_time_t);
            #region ra_extra_time define
            this.ra_extra_time = new System.Windows.Forms.TextBox();
            this.ra_extra_time.Name = "ra_extra_time";
            this.ra_extra_time.Location = new System.Drawing.Point(769, 310);
            this.ra_extra_time.Size = new System.Drawing.Size(62, 13);
            this.ra_extra_time.TabIndex = 120;
            this.ra_extra_time.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_extra_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ra_extra_time.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaExtraTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(ra_extra_time);
            #region ra_extra_distance_t define
            this.ra_extra_distance_t = new System.Windows.Forms.Label();
            this.ra_extra_distance_t.Name = "ra_extra_distance_t";
            this.ra_extra_distance_t.Location = new System.Drawing.Point(634, 348);
            this.ra_extra_distance_t.Size = new System.Drawing.Size(130, 13);
            this.ra_extra_distance_t.TabIndex = 0;
            this.ra_extra_distance_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_extra_distance_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_extra_distance_t.Text = "Ra Extra Distance:";
            #endregion
            this.Controls.Add(ra_extra_distance_t);
            #region ra_extra_distance define
            this.ra_extra_distance = new System.Windows.Forms.TextBox();
            this.ra_extra_distance.Name = "ra_extra_distance";
            this.ra_extra_distance.Location = new System.Drawing.Point(769, 348);
            this.ra_extra_distance.Size = new System.Drawing.Size(85, 13);
            this.ra_extra_distance.TabIndex = 130;
            this.ra_extra_distance.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_extra_distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ra_extra_distance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaExtraDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(ra_extra_distance);
            #region ra_othr_gds_before_t define
            this.ra_othr_gds_before_t = new System.Windows.Forms.Label();
            this.ra_othr_gds_before_t.Name = "ra_othr_gds_before_t";
            this.ra_othr_gds_before_t.Location = new System.Drawing.Point(634, 386);
            this.ra_othr_gds_before_t.Size = new System.Drawing.Size(130, 13);
            this.ra_othr_gds_before_t.TabIndex = 0;
            this.ra_othr_gds_before_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_othr_gds_before_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_othr_gds_before_t.Text = "Ra Other Goods Before:";
            #endregion
            this.Controls.Add(ra_othr_gds_before_t);
            #region ra_othr_gds_before define
            this.ra_othr_gds_before = new System.Windows.Forms.TextBox();
            this.ra_othr_gds_before.Name = "ra_othr_gds_before";
            this.ra_othr_gds_before.Location = new System.Drawing.Point(769, 386);
            this.ra_othr_gds_before.Size = new System.Drawing.Size(62, 13);
            this.ra_othr_gds_before.TabIndex = 140;
            this.ra_othr_gds_before.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_othr_gds_before.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ra_othr_gds_before.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaOthrGdsBefore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(ra_othr_gds_before);
            #region ra_othr_gds_during_t define
            this.ra_othr_gds_during_t = new System.Windows.Forms.Label();
            this.ra_othr_gds_during_t.Name = "ra_othr_gds_during_t";
            this.ra_othr_gds_during_t.Location = new System.Drawing.Point(634, 424);
            this.ra_othr_gds_during_t.Size = new System.Drawing.Size(130, 13);
            this.ra_othr_gds_during_t.TabIndex = 0;
            this.ra_othr_gds_during_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_othr_gds_during_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_othr_gds_during_t.Text = "Ra Othr Gds During:";
            #endregion
            this.Controls.Add(ra_othr_gds_during_t);
            #region ra_othr_gds_during define
            this.ra_othr_gds_during = new System.Windows.Forms.TextBox();
            this.ra_othr_gds_during.Name = "ra_othr_gds_during";
            this.ra_othr_gds_during.Location = new System.Drawing.Point(769, 424);
            this.ra_othr_gds_during.Size = new System.Drawing.Size(62, 13);
            this.ra_othr_gds_during.TabIndex = 150;
            this.ra_othr_gds_during.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_othr_gds_during.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ra_othr_gds_during.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaOthrGdsDuring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(ra_othr_gds_during);
            #region ra_othr_gds_after_t define
            this.ra_othr_gds_after_t = new System.Windows.Forms.Label();
            this.ra_othr_gds_after_t.Name = "ra_othr_gds_after_t";
            this.ra_othr_gds_after_t.Location = new System.Drawing.Point(634, 462);
            this.ra_othr_gds_after_t.Size = new System.Drawing.Size(130, 13);
            this.ra_othr_gds_after_t.TabIndex = 0;
            this.ra_othr_gds_after_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_othr_gds_after_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_othr_gds_after_t.Text = "Ra Othr Gds After:";
            #endregion
            this.Controls.Add(ra_othr_gds_after_t);
            #region ra_othr_gds_after define
            this.ra_othr_gds_after = new System.Windows.Forms.TextBox();
            this.ra_othr_gds_after.Name = "ra_othr_gds_after";
            this.ra_othr_gds_after.Location = new System.Drawing.Point(769, 462);
            this.ra_othr_gds_after.Size = new System.Drawing.Size(62, 13);
            this.ra_othr_gds_after.TabIndex = 160;
            this.ra_othr_gds_after.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_othr_gds_after.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ra_othr_gds_after.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaOthrGdsAfter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(ra_othr_gds_after);
            #region ra_pr_before_t define
            this.ra_pr_before_t = new System.Windows.Forms.Label();
            this.ra_pr_before_t.Name = "ra_pr_before_t";
            this.ra_pr_before_t.Location = new System.Drawing.Point(634, 500);
            this.ra_pr_before_t.Size = new System.Drawing.Size(130, 13);
            this.ra_pr_before_t.TabIndex = 0;
            this.ra_pr_before_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_pr_before_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_pr_before_t.Text = "Ra Pr Before:";
            #endregion
            this.Controls.Add(ra_pr_before_t);
            #region ra_pr_before define
            this.ra_pr_before = new System.Windows.Forms.TextBox();
            this.ra_pr_before.Name = "ra_pr_before";
            this.ra_pr_before.Location = new System.Drawing.Point(769, 500);
            this.ra_pr_before.Size = new System.Drawing.Size(62, 13);
            this.ra_pr_before.TabIndex = 170;
            this.ra_pr_before.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_pr_before.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ra_pr_before.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaPrBefore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(ra_pr_before);
            #region ra_pr_during_t define
            this.ra_pr_during_t = new System.Windows.Forms.Label();
            this.ra_pr_during_t.Name = "ra_pr_during_t";
            this.ra_pr_during_t.Location = new System.Drawing.Point(634, 538);
            this.ra_pr_during_t.Size = new System.Drawing.Size(130, 13);
            this.ra_pr_during_t.TabIndex = 0;
            this.ra_pr_during_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_pr_during_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_pr_during_t.Text = "Ra Pr During:";
            #endregion
            this.Controls.Add(ra_pr_during_t);
            #region ra_pr_during define
            this.ra_pr_during = new System.Windows.Forms.TextBox();
            this.ra_pr_during.Name = "ra_pr_during";
            this.ra_pr_during.Location = new System.Drawing.Point(769, 538);
            this.ra_pr_during.Size = new System.Drawing.Size(62, 13);
            this.ra_pr_during.TabIndex = 180;
            this.ra_pr_during.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_pr_during.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ra_pr_during.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaPrDuring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(ra_pr_during);
            #region ra_pr_after_t define
            this.ra_pr_after_t = new System.Windows.Forms.Label();
            this.ra_pr_after_t.Name = "ra_pr_after_t";
            this.ra_pr_after_t.Location = new System.Drawing.Point(634, 576);
            this.ra_pr_after_t.Size = new System.Drawing.Size(130, 13);
            this.ra_pr_after_t.TabIndex = 0;
            this.ra_pr_after_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_pr_after_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_pr_after_t.Text = "Ra Pr After:";
            #endregion
            this.Controls.Add(ra_pr_after_t);
            #region ra_pr_after define
            this.ra_pr_after = new System.Windows.Forms.TextBox();
            this.ra_pr_after.Name = "ra_pr_after";
            this.ra_pr_after.Location = new System.Drawing.Point(769, 576);
            this.ra_pr_after.Size = new System.Drawing.Size(62, 13);
            this.ra_pr_after.TabIndex = 190;
            this.ra_pr_after.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_pr_after.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ra_pr_after.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaPrAfter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(ra_pr_after);
            #region n_65687338 define
            this.n_65687338 = new System.Windows.Forms.Label();
            this.n_65687338.Name = "n_65687338";
            this.n_65687338.Location = new System.Drawing.Point(22, 84);
            this.n_65687338.Size = new System.Drawing.Size(14, 13);
            this.n_65687338.TabIndex = 0;
            this.n_65687338.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_65687338.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_65687338.Text = "1.";
            #endregion
            this.Controls.Add(n_65687338);
            #region n_54315131 define
            this.n_54315131 = new System.Windows.Forms.Label();
            this.n_54315131.Name = "n_54315131";
            this.n_54315131.Location = new System.Drawing.Point(22, 108);
            this.n_54315131.Size = new System.Drawing.Size(14, 13);
            this.n_54315131.TabIndex = 0;
            this.n_54315131.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_54315131.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_54315131.Text = "3.";
            #endregion
            this.Controls.Add(n_54315131);
            #region n_19074136 define
            this.n_19074136 = new System.Windows.Forms.Label();
            this.n_19074136.Name = "n_19074136";
            this.n_19074136.Location = new System.Drawing.Point(259, 84);
            this.n_19074136.Size = new System.Drawing.Size(14, 13);
            this.n_19074136.TabIndex = 0;
            this.n_19074136.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_19074136.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_19074136.Text = "2.";
            #endregion
            this.Controls.Add(n_19074136);
            #region ra_time_started_sort_t define
            this.ra_time_started_sort_t = new System.Windows.Forms.Label();
            this.ra_time_started_sort_t.Name = "ra_time_started_sort_t";
            this.ra_time_started_sort_t.Location = new System.Drawing.Point(48, 84);
            this.ra_time_started_sort_t.Size = new System.Drawing.Size(132, 13);
            this.ra_time_started_sort_t.TabIndex = 0;
            this.ra_time_started_sort_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_time_started_sort_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ra_time_started_sort_t.Text = "Time Started Sort";
            #endregion
            this.Controls.Add(ra_time_started_sort_t);
            #region ra_time_finished_sort_t define
            this.ra_time_finished_sort_t = new System.Windows.Forms.Label();
            this.ra_time_finished_sort_t.Name = "ra_time_finished_sort_t";
            this.ra_time_finished_sort_t.Location = new System.Drawing.Point(48, 108);
            this.ra_time_finished_sort_t.Size = new System.Drawing.Size(140, 13);
            this.ra_time_finished_sort_t.TabIndex = 0;
            this.ra_time_finished_sort_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_time_finished_sort_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ra_time_finished_sort_t.Text = "Time Finished Sort";
            #endregion
            this.Controls.Add(ra_time_finished_sort_t);
            #region ra_time_left_base_t define
            this.ra_time_left_base_t = new System.Windows.Forms.Label();
            this.ra_time_left_base_t.Name = "ra_time_left_base_t";
            this.ra_time_left_base_t.Location = new System.Drawing.Point(285, 84);
            this.ra_time_left_base_t.Size = new System.Drawing.Size(113, 13);
            this.ra_time_left_base_t.TabIndex = 0;
            this.ra_time_left_base_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_time_left_base_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ra_time_left_base_t.Text = "Time Left Base";
            #endregion
            this.Controls.Add(ra_time_left_base_t);
            #region n_37449496 define
            this.n_37449496 = new System.Windows.Forms.Label();
            this.n_37449496.Name = "n_37449496";
            this.n_37449496.Location = new System.Drawing.Point(22, 138);
            this.n_37449496.Size = new System.Drawing.Size(14, 13);
            this.n_37449496.TabIndex = 0;
            this.n_37449496.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_37449496.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_37449496.Text = "4.";
            #endregion
            this.Controls.Add(n_37449496);
            #region n_1501150 define
            this.n_1501150 = new System.Windows.Forms.Label();
            this.n_1501150.Name = "n_1501150";
            this.n_1501150.Location = new System.Drawing.Point(48, 138);
            this.n_1501150.Size = new System.Drawing.Size(126, 13);
            this.n_1501150.TabIndex = 0;
            this.n_1501150.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_1501150.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.n_1501150.Text = "Time on Delivery";
            #endregion
            this.Controls.Add(n_1501150);
            #region ra_time_departed define
            this.ra_time_departed = new System.Windows.Forms.MaskedTextBox();
            this.ra_time_departed.Name = "ra_time_departed";
            this.ra_time_departed.Location = new System.Drawing.Point(194, 188);
            this.ra_time_departed.Size = new System.Drawing.Size(33, 13);
            this.ra_time_departed.TabIndex = 80;
            this.ra_time_departed.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_time_departed.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ra_time_departed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaTimeDeparted", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_time_departed.Mask = "hh:mm";
            #endregion
            this.Controls.Add(ra_time_departed);
            #region ra_time_returned_t define
            this.ra_time_returned_t = new System.Windows.Forms.Label();
            this.ra_time_returned_t.Name = "ra_time_returned_t";
            this.ra_time_returned_t.Location = new System.Drawing.Point(128, 164);
            this.ra_time_returned_t.Size = new System.Drawing.Size(50, 13);
            this.ra_time_returned_t.TabIndex = 0;
            this.ra_time_returned_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_time_returned_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_time_returned_t.Text = "Returned";
            #endregion
            this.Controls.Add(ra_time_returned_t);
            #region ra_time_departed_t define
            this.ra_time_departed_t = new System.Windows.Forms.Label();
            this.ra_time_departed_t.Name = "ra_time_departed_t";
            this.ra_time_departed_t.Location = new System.Drawing.Point(128, 188);
            this.ra_time_departed_t.Size = new System.Drawing.Size(50, 13);
            this.ra_time_departed_t.TabIndex = 0;
            this.ra_time_departed_t.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_time_departed_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_time_departed_t.Text = "Departed";
            #endregion
            this.Controls.Add(ra_time_departed_t);
            #region n_13510354 define
            this.n_13510354 = new System.Windows.Forms.TextBox();
            this.n_13510354.Name = "n_13510354";
            this.n_13510354.Location = new System.Drawing.Point(194, 214);
            this.n_13510354.Size = new System.Drawing.Size(33, 13);
            this.n_13510354.TabIndex = 0;
            this.n_13510354.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.n_13510354.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.n_13510354.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(n_13510354);
            #region ra_time_left_base define
            this.ra_time_left_base = new System.Windows.Forms.MaskedTextBox();
            this.ra_time_left_base.Name = "ra_time_left_base";
            this.ra_time_left_base.Location = new System.Drawing.Point(403, 84);
            this.ra_time_left_base.Size = new System.Drawing.Size(33, 13);
            this.ra_time_left_base.TabIndex = 60;
            this.ra_time_left_base.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_time_left_base.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ra_time_left_base.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaTimeLeftBase", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_time_left_base.Mask = "hh:mm";
            #endregion
            this.Controls.Add(ra_time_left_base);
            #region ra_date_of_check define
            this.ra_date_of_check = new System.Windows.Forms.MaskedTextBox();
            this.ra_date_of_check.Name = "ra_date_of_check";
            this.ra_date_of_check.Location = new System.Drawing.Point(285, 38);
            this.ra_date_of_check.Size = new System.Drawing.Size(53, 13);
            this.ra_date_of_check.TabIndex = 30;
            this.ra_date_of_check.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_date_of_check.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_date_of_check.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaDateOfCheck", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_date_of_check.Mask = "dd/mm/yy";
            #endregion
            this.Controls.Add(ra_date_of_check);
            #region ra_time_started_sort define
            this.ra_time_started_sort = new System.Windows.Forms.MaskedTextBox();
            this.ra_time_started_sort.Name = "ra_time_started_sort";
            this.ra_time_started_sort.Location = new System.Drawing.Point(194, 84);
            this.ra_time_started_sort.Size = new System.Drawing.Size(33, 13);
            this.ra_time_started_sort.TabIndex = 40;
            this.ra_time_started_sort.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_time_started_sort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_time_started_sort.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaTimeStartedSort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_time_started_sort.Mask = "hh:mm";
            #endregion
            this.Controls.Add(ra_time_started_sort);
            #region ra_time_finished_sort define
            this.ra_time_finished_sort = new System.Windows.Forms.MaskedTextBox();
            this.ra_time_finished_sort.Name = "ra_time_finished_sort";
            this.ra_time_finished_sort.Location = new System.Drawing.Point(194, 108);
            this.ra_time_finished_sort.Size = new System.Drawing.Size(33, 13);
            this.ra_time_finished_sort.TabIndex = 50;
            this.ra_time_finished_sort.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_time_finished_sort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_time_finished_sort.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaTimeFinishedSort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_time_finished_sort.Mask = "hh:mm";
            #endregion
            this.Controls.Add(ra_time_finished_sort);
            #region ra_time_returned define
            this.ra_time_returned = new System.Windows.Forms.MaskedTextBox();
            this.ra_time_returned.Name = "ra_time_returned";
            this.ra_time_returned.Location = new System.Drawing.Point(194, 164);
            this.ra_time_returned.Size = new System.Drawing.Size(33, 13);
            this.ra_time_returned.TabIndex = 70;
            this.ra_time_returned.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_time_returned.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ra_time_returned.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaTimeReturned", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_time_returned.Mask = "hh:mm";
            #endregion
            this.Controls.Add(ra_time_returned);
            #region delseconds define
            this.delseconds = new System.Windows.Forms.TextBox();
            this.delseconds.Name = "delseconds";
            this.delseconds.Location = new System.Drawing.Point(68, 166);
            this.delseconds.Size = new System.Drawing.Size(45, 13);
            this.delseconds.TabIndex = 0;
            this.delseconds.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.delseconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.delseconds.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(delseconds);
            #region ra_day_of_check define
            this.ra_day_of_check = new Metex.Windows.DataEntityCombo();
            this.ra_day_of_check.Name = "ra_day_of_check";
            this.ra_day_of_check.Location = new System.Drawing.Point(102, 38);
            this.ra_day_of_check.Size = new System.Drawing.Size(88, 13);
            this.ra_day_of_check.TabIndex = 20;
            this.ra_day_of_check.Font = new System.Drawing.Font("MS Sans Serif", 8);
            //this.ra_day_of_check.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ra_day_of_check.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RaDayOfCheck", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(ra_day_of_check);
            #region contract_no define
            this.contract_no = new System.Windows.Forms.TextBox();
            this.contract_no.Name = "contract_no";
            this.contract_no.Location = new System.Drawing.Point(77, 2);
            this.contract_no.Size = new System.Drawing.Size(42, 13);
            this.contract_no.TabIndex = 10;
            this.contract_no.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.contract_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.contract_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ContractNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            #endregion
            this.Controls.Add(contract_no);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion

        private System.Windows.Forms.Label contract_no_t;
        private System.Windows.Forms.Label ra_day_of_check_t;
        private System.Windows.Forms.Label n_37124754;
        private System.Windows.Forms.Label ra_finish_odometer_t;
        private System.Windows.Forms.TextBox ra_finish_odometer;
        private System.Windows.Forms.Label ra_start_odometer_t;
        private System.Windows.Forms.TextBox ra_start_odometer;
        private System.Windows.Forms.Label ra_meal_breaks_t;
        private System.Windows.Forms.TextBox ra_meal_breaks;
        private System.Windows.Forms.Label ra_extra_time_t;
        private System.Windows.Forms.TextBox ra_extra_time;
        private System.Windows.Forms.Label ra_extra_distance_t;
        private System.Windows.Forms.TextBox ra_extra_distance;
        private System.Windows.Forms.Label ra_othr_gds_before_t;
        private System.Windows.Forms.TextBox ra_othr_gds_before;
        private System.Windows.Forms.Label ra_othr_gds_during_t;
        private System.Windows.Forms.TextBox ra_othr_gds_during;
        private System.Windows.Forms.Label ra_othr_gds_after_t;
        private System.Windows.Forms.TextBox ra_othr_gds_after;
        private System.Windows.Forms.Label ra_pr_before_t;
        private System.Windows.Forms.TextBox ra_pr_before;
        private System.Windows.Forms.Label ra_pr_during_t;
        private System.Windows.Forms.TextBox ra_pr_during;
        private System.Windows.Forms.Label ra_pr_after_t;
        private System.Windows.Forms.TextBox ra_pr_after;
        private System.Windows.Forms.Label n_65687338;
        private System.Windows.Forms.Label n_54315131;
        private System.Windows.Forms.Label n_19074136;
        private System.Windows.Forms.Label ra_time_started_sort_t;
        private System.Windows.Forms.Label ra_time_finished_sort_t;
        private System.Windows.Forms.Label ra_time_left_base_t;
        private System.Windows.Forms.Label n_37449496;
        private System.Windows.Forms.Label n_1501150;
        private System.Windows.Forms.MaskedTextBox ra_time_departed;
        private System.Windows.Forms.Label ra_time_returned_t;
        private System.Windows.Forms.Label ra_time_departed_t;
        private System.Windows.Forms.TextBox n_13510354;
        private System.Windows.Forms.MaskedTextBox ra_time_left_base;
        private System.Windows.Forms.MaskedTextBox ra_date_of_check;
        private System.Windows.Forms.MaskedTextBox ra_time_started_sort;
        private System.Windows.Forms.MaskedTextBox ra_time_finished_sort;
        private System.Windows.Forms.MaskedTextBox ra_time_returned;
        private System.Windows.Forms.TextBox delseconds;
        private Metex.Windows.DataEntityCombo ra_day_of_check;
        private System.Windows.Forms.TextBox contract_no;
    }
}
