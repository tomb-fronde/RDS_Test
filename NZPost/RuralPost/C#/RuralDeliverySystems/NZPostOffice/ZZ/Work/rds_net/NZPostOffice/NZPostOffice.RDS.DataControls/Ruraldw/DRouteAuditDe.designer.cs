using System.Windows.Forms;
using System.Drawing;
using NZPostOffice.Shared.VisualComponents;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DRouteAuditDe
	{
        /// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private System.Windows.Forms.MaskedTextBox   ra_total_hours;
		private System.Windows.Forms.MaskedTextBox   ra_date_of_check;
		private System.Windows.Forms.Label   ra_time_finished_sort_t;
		private System.Windows.Forms.MaskedTextBox   ra_no_circular_drops;
		private System.Windows.Forms.MaskedTextBox   ra_othr_gds_after;
		private System.Windows.Forms.Label   ra_othr_gds_before_t;
		private System.Windows.Forms.TextBox   ra_condition;
		private System.Windows.Forms.MaskedTextBox   ra_rural_private_bags;
		private System.Windows.Forms.RichTextBox   ra_route_reason;
		private System.Windows.Forms.RichTextBox   ra_sorting_comments;
		private System.Windows.Forms.MaskedTextBox   ra_other_custs;
        private System.Windows.Forms.TextBox ra_vehicle_model;
		private System.Windows.Forms.Label   ra_start_odometer_t;
		private System.Windows.Forms.Label   ra_meal_breaks_t;
		private System.Windows.Forms.Label   ra_time_returned_t;
		private System.Windows.Forms.Label   ra_employee_t;
        private System.Windows.Forms.MaskedTextBox ra_time_started_sort;
		private System.Windows.Forms.TextBox   ra_employee;
		private System.Windows.Forms.TextBox   ra_contractor;
		private System.Windows.Forms.RichTextBox   ra_commencement_reason;
        private System.Windows.Forms.Label ra_final_distance_t;
		private System.Windows.Forms.Label   ra_extra_time_t;
		private System.Windows.Forms.MaskedTextBox   ra_cc_rating;
		private System.Windows.Forms.MaskedTextBox   ra_post_centres;
		private System.Windows.Forms.RichTextBox   ra_cp_comments;
		private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox   ra_extra_distance;
		private System.Windows.Forms.MaskedTextBox   ra_time_finished_sort;
		private System.Windows.Forms.MaskedTextBox   ra_othr_gds_during;
		private System.Windows.Forms.CheckBox   ra_pl_insurance;
		private System.Windows.Forms.Label   ra_pr_during_t;
		private System.Windows.Forms.MaskedTextBox   ra_meal_breaks;
		private System.Windows.Forms.Label   ra_time_started_sort_t;
		private System.Windows.Forms.MaskedTextBox   ra_no_cmbs;
		private System.Windows.Forms.TextBox   ra_frequency;
		private System.Windows.Forms.Label   ra_total_distance_t;
		private System.Windows.Forms.RichTextBox   ra_sorting_facilities;
		private System.Windows.Forms.MaskedTextBox   ra_time_departed;
		private System.Windows.Forms.MaskedTextBox   ra_pr_after;
		private System.Windows.Forms.MaskedTextBox   ra_post_shops;
		private System.Windows.Forms.MaskedTextBox   ra_othr_gds_before;
		private System.Windows.Forms.MaskedTextBox   ra_year;
		private System.Windows.Forms.Label   ra_date_of_check_t;
		private System.Windows.Forms.MaskedTextBox   ra_rec_replace;
		private System.Windows.Forms.Label   ra_time_departed_t;
		private System.Windows.Forms.CheckBox   ra_insurance_sighted;
        private System.Windows.Forms.Label ra_othr_gds_after_t;
		private System.Windows.Forms.MaskedTextBox   ra_no_cmb_custs;
		private System.Windows.Forms.MaskedTextBox   ra_vehicle_purchased;
		private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox   ra_start_odometer;
		private System.Windows.Forms.Label   ra_extra_distance_t;
		private System.Windows.Forms.MaskedTextBox   ra_extra_time;
		private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox   ra_finish_odometer;
		private System.Windows.Forms.MaskedTextBox   ra_no_reg_custs;
		private System.Windows.Forms.Label   ra_pr_before_t;
        private System.Windows.Forms.MaskedTextBox ra_time_returned;
		private System.Windows.Forms.RichTextBox   ra_mv_comments;
		private System.Windows.Forms.TextBox   ra_vehicle_make;
		private System.Windows.Forms.Label   ra_frequency_t;
        private NumericalMaskedTextBox ra_vehicle_price;
		private System.Windows.Forms.CheckBox   ra_cr_insurance;
		private System.Windows.Forms.TextBox   ra_sorting_case;
		private System.Windows.Forms.RichTextBox   ra_road_conditions;
		private System.Windows.Forms.TextBox   ra_volume;
        private System.Windows.Forms.MaskedTextBox ra_private_bags;
		private System.Windows.Forms.MaskedTextBox   ra_pr_during;
		private System.Windows.Forms.TextBox   ra_fuel;
		private System.Windows.Forms.Label   ra_final_hours_t;
		private System.Windows.Forms.Label   ra_total_hours_t;
		private System.Windows.Forms.CheckBox   ra_new_vehicle;
		private System.Windows.Forms.Label   ra_finish_odometer_t;
        private System.Windows.Forms.TextBox ra_lenth_unsealed;
        private System.Windows.Forms.TextBox ra_registration_no;
        private System.Windows.Forms.MaskedTextBox ra_pr_before;
		private System.Windows.Forms.Label   ra_othr_gds_during_t;
		private System.Windows.Forms.MaskedTextBox   ra_closed_mails;
		private System.Windows.Forms.TextBox   ra_tyre_size;
		private System.Windows.Forms.MaskedTextBox   ra_final_hours;
		private System.Windows.Forms.CheckBox   ra_gds_service_sighted;
		private System.Windows.Forms.MaskedTextBox   ra_no_reg_custs_core_prods;
		private System.Windows.Forms.Label   ra_pr_after_t;
		private System.Windows.Forms.TextBox   ra_length_sealed;
		private System.Windows.Forms.CheckBox   ra_mv_insurance;
		private System.Windows.Forms.Label   ra_contractor_t;
		private System.Windows.Forms.RichTextBox   ra_suggested_improvements;
		private System.Windows.Forms.CheckBox   ra_gds_service;

        private System.Windows.Forms.Label st_contract;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
            this.ra_volume = new System.Windows.Forms.TextBox();
            this.ra_date_of_check_t = new System.Windows.Forms.Label();
            this.ra_time_finished_sort_t = new System.Windows.Forms.Label();
            this.ra_time_started_sort_t = new System.Windows.Forms.Label();
            this.ra_date_of_check = new System.Windows.Forms.MaskedTextBox();
            this.ra_time_finished_sort = new System.Windows.Forms.MaskedTextBox();
            this.ra_time_started_sort = new System.Windows.Forms.MaskedTextBox();
            this.ra_time_returned_t = new System.Windows.Forms.Label();
            this.ra_time_returned = new System.Windows.Forms.MaskedTextBox();
            this.ra_finish_odometer_t = new System.Windows.Forms.Label();
            this.ra_finish_odometer = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.ra_time_departed_t = new System.Windows.Forms.Label();
            this.ra_time_departed = new System.Windows.Forms.MaskedTextBox();
            this.ra_start_odometer_t = new System.Windows.Forms.Label();
            this.ra_start_odometer = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.ra_total_hours_t = new System.Windows.Forms.Label();
            this.ra_total_hours = new System.Windows.Forms.MaskedTextBox();
            this.ra_total_distance_t = new System.Windows.Forms.Label();
            this.ra_meal_breaks_t = new System.Windows.Forms.Label();
            this.ra_meal_breaks = new System.Windows.Forms.MaskedTextBox();
            this.ra_extra_time_t = new System.Windows.Forms.Label();
            this.ra_extra_time = new System.Windows.Forms.MaskedTextBox();
            this.ra_extra_distance_t = new System.Windows.Forms.Label();
            this.ra_extra_distance = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBox();
            this.ra_final_hours_t = new System.Windows.Forms.Label();
            this.ra_final_hours = new System.Windows.Forms.MaskedTextBox();
            this.ra_final_distance_t = new System.Windows.Forms.Label();
            this.ra_othr_gds_before_t = new System.Windows.Forms.Label();
            this.ra_othr_gds_before = new System.Windows.Forms.MaskedTextBox();
            this.ra_pr_before_t = new System.Windows.Forms.Label();
            this.ra_pr_before = new System.Windows.Forms.MaskedTextBox();
            this.ra_othr_gds_during_t = new System.Windows.Forms.Label();
            this.ra_othr_gds_during = new System.Windows.Forms.MaskedTextBox();
            this.ra_pr_during_t = new System.Windows.Forms.Label();
            this.ra_pr_during = new System.Windows.Forms.MaskedTextBox();
            this.ra_othr_gds_after_t = new System.Windows.Forms.Label();
            this.ra_othr_gds_after = new System.Windows.Forms.MaskedTextBox();
            this.ra_pr_after_t = new System.Windows.Forms.Label();
            this.ra_pr_after = new System.Windows.Forms.MaskedTextBox();
            this.ra_frequency_t = new System.Windows.Forms.Label();
            this.ra_frequency = new System.Windows.Forms.TextBox();
            this.ra_contractor_t = new System.Windows.Forms.Label();
            this.ra_contractor = new System.Windows.Forms.TextBox();
            this.ra_employee_t = new System.Windows.Forms.Label();
            this.ra_employee = new System.Windows.Forms.TextBox();
            this.ra_vehicle_make = new System.Windows.Forms.TextBox();
            this.ra_vehicle_model = new System.Windows.Forms.TextBox();
            this.ra_year = new System.Windows.Forms.MaskedTextBox();
            this.ra_registration_no = new System.Windows.Forms.TextBox();
            this.ra_fuel = new System.Windows.Forms.TextBox();
            this.ra_cc_rating = new System.Windows.Forms.MaskedTextBox();
            this.ra_condition = new System.Windows.Forms.TextBox();
            this.ra_tyre_size = new System.Windows.Forms.TextBox();
            this.ra_rec_replace = new System.Windows.Forms.MaskedTextBox();
            this.ra_gds_service = new System.Windows.Forms.CheckBox();
            this.ra_mv_insurance = new System.Windows.Forms.CheckBox();
            this.ra_gds_service_sighted = new System.Windows.Forms.CheckBox();
            this.ra_cr_insurance = new System.Windows.Forms.CheckBox();
            this.ra_pl_insurance = new System.Windows.Forms.CheckBox();
            this.ra_insurance_sighted = new System.Windows.Forms.CheckBox();
            this.ra_new_vehicle = new System.Windows.Forms.CheckBox();
            this.ra_vehicle_price = new NumericalMaskedTextBox();
            this.ra_vehicle_purchased = new System.Windows.Forms.MaskedTextBox();
            this.ra_mv_comments = new System.Windows.Forms.RichTextBox();
            this.ra_no_circular_drops = new System.Windows.Forms.MaskedTextBox();
            this.ra_cp_comments = new System.Windows.Forms.RichTextBox();
            this.ra_no_reg_custs = new System.Windows.Forms.MaskedTextBox();
            this.ra_no_reg_custs_core_prods = new System.Windows.Forms.MaskedTextBox();
            this.ra_other_custs = new System.Windows.Forms.MaskedTextBox();
            this.ra_rural_private_bags = new System.Windows.Forms.MaskedTextBox();
            this.ra_private_bags = new System.Windows.Forms.MaskedTextBox();
            this.ra_closed_mails = new System.Windows.Forms.MaskedTextBox();
            this.ra_post_shops = new System.Windows.Forms.MaskedTextBox();
            this.ra_post_centres = new System.Windows.Forms.MaskedTextBox();
            this.ra_no_cmbs = new System.Windows.Forms.MaskedTextBox();
            this.ra_no_cmb_custs = new System.Windows.Forms.MaskedTextBox();
            this.ra_sorting_facilities = new System.Windows.Forms.RichTextBox();
            this.ra_sorting_case = new System.Windows.Forms.TextBox();
            this.ra_sorting_comments = new System.Windows.Forms.RichTextBox();
            this.ra_length_sealed = new System.Windows.Forms.TextBox();
            this.ra_lenth_unsealed = new System.Windows.Forms.TextBox();
            this.ra_road_conditions = new System.Windows.Forms.RichTextBox();
            this.ra_suggested_improvements = new System.Windows.Forms.RichTextBox();
            this.ra_commencement_reason = new System.Windows.Forms.RichTextBox();
            this.ra_route_reason = new System.Windows.Forms.RichTextBox();
            this.t_1 = new System.Windows.Forms.Label();
            this.t_2 = new System.Windows.Forms.Label();
            this.compute_2 = new System.Windows.Forms.TextBox();
            this.t_3 = new System.Windows.Forms.Label();
            this.compute_1 = new System.Windows.Forms.TextBox();
            this.t_4 = new System.Windows.Forms.Label();
            this.t_5 = new System.Windows.Forms.Label();
            this.t_6 = new System.Windows.Forms.Label();
            this.compute_3 = new NumericalMaskedTextBox();
            this.t_7 = new System.Windows.Forms.Label();
            this.t_8 = new System.Windows.Forms.Label();
            this.t_9 = new System.Windows.Forms.Label();
            this.t_10 = new System.Windows.Forms.Label();
            this.t_11 = new System.Windows.Forms.Label();
            this.t_12 = new System.Windows.Forms.Label();
            this.t_15 = new System.Windows.Forms.Label();
            this.t_18 = new System.Windows.Forms.Label();
            this.t_20 = new System.Windows.Forms.Label();
            this.t_13 = new System.Windows.Forms.Label();
            this.t_16 = new System.Windows.Forms.Label();
            this.t_19 = new System.Windows.Forms.Label();
            this.t_14 = new System.Windows.Forms.Label();
            this.t_17 = new System.Windows.Forms.Label();
            this.t_21 = new System.Windows.Forms.Label();
            this.t_22 = new System.Windows.Forms.Label();
            this.t_23 = new System.Windows.Forms.Label();
            this.t_24 = new System.Windows.Forms.Label();
            this.t_25 = new System.Windows.Forms.Label();
            this.t_26 = new System.Windows.Forms.Label();
            this.t_27 = new System.Windows.Forms.Label();
            this.t_28 = new System.Windows.Forms.Label();
            this.t_29 = new System.Windows.Forms.Label();
            this.t_30 = new System.Windows.Forms.Label();
            this.t_31 = new System.Windows.Forms.Label();
            this.t_32 = new System.Windows.Forms.Label();
            this.t_33 = new System.Windows.Forms.Label();
            this.t_34 = new System.Windows.Forms.Label();
            this.t_35 = new System.Windows.Forms.Label();
            this.t_36 = new System.Windows.Forms.Label();
            this.t_37 = new System.Windows.Forms.Label();
            this.t_38 = new System.Windows.Forms.Label();
            this.t_39 = new System.Windows.Forms.Label();
            this.t_40 = new System.Windows.Forms.Label();
            this.compute_5 = new System.Windows.Forms.TextBox();
            this.t_41 = new System.Windows.Forms.Label();
            this.t_42 = new System.Windows.Forms.Label();
            this.t_43 = new System.Windows.Forms.Label();
            this.t_44 = new System.Windows.Forms.Label();
            this.t_45 = new System.Windows.Forms.Label();
            this.t_46 = new System.Windows.Forms.Label();
            this.t_47 = new System.Windows.Forms.Label();
            this.t_48 = new System.Windows.Forms.Label();
            this.compute_6 = new System.Windows.Forms.TextBox();
            this.t_49 = new System.Windows.Forms.Label();
            this.t_50 = new System.Windows.Forms.Label();
            this.t_51 = new System.Windows.Forms.Label();
            this.t_52 = new System.Windows.Forms.Label();
            this.t_53 = new System.Windows.Forms.Label();
            this.t_54 = new System.Windows.Forms.Label();
            this.t_55 = new System.Windows.Forms.Label();
            this.t_56 = new System.Windows.Forms.Label();
            this.t_57 = new System.Windows.Forms.Label();
            this.t_58 = new System.Windows.Forms.Label();
            this.t_59 = new System.Windows.Forms.Label();
            this.t_60 = new System.Windows.Forms.Label();
            this.compute_4 = new NumericalMaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.radioButton17 = new System.Windows.Forms.RadioButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ra_safty_practices_resolved_date = new System.Windows.Forms.MaskedTextBox();
            this.ra_safty_practices_actions = new System.Windows.Forms.RichTextBox();
            this.ra_safty_plan_completed_date = new System.Windows.Forms.MaskedTextBox();
            this.ra_safty_plan_actions = new System.Windows.Forms.RichTextBox();
            this.ra_safty_access_resolved_date = new System.Windows.Forms.MaskedTextBox();
            this.ra_saftey_access_actions = new System.Windows.Forms.RichTextBox();
            this.ra_safty_access_addresses = new System.Windows.Forms.RichTextBox();
            this.ra_deviation_reason = new System.Windows.Forms.RichTextBox();
            this.t_61 = new System.Windows.Forms.Label();
            this.t_62 = new System.Windows.Forms.Label();
            this.t_63 = new System.Windows.Forms.Label();
            this.t_64 = new System.Windows.Forms.Label();
            this.t_65 = new System.Windows.Forms.Label();
            this.t_66 = new System.Windows.Forms.Label();
            this.t_67 = new System.Windows.Forms.Label();
            this.t_68 = new System.Windows.Forms.Label();
            this.t_69 = new System.Windows.Forms.Label();
            this.t_70 = new System.Windows.Forms.Label();
            this.radioButton18 = new System.Windows.Forms.RadioButton();
            this.radioButton19 = new System.Windows.Forms.RadioButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.radioButton21 = new System.Windows.Forms.RadioButton();
            this.radioButton20 = new System.Windows.Forms.RadioButton();
            this.panel10 = new System.Windows.Forms.Panel();
            this.radioButton23 = new System.Windows.Forms.RadioButton();
            this.radioButton22 = new System.Windows.Forms.RadioButton();
            this.panel11 = new System.Windows.Forms.Panel();
            this.radioButton25 = new System.Windows.Forms.RadioButton();
            this.radioButton24 = new System.Windows.Forms.RadioButton();
            this.st_contract = new System.Windows.Forms.Label();
            components = new System.ComponentModel.Container();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RouteAuditDe);
            // 
            // st_contract
            // 
            this.st_contract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_contract.ForeColor = System.Drawing.Color.Black;
            this.st_contract.Location = new System.Drawing.Point(0, 0);
            this.st_contract.Name = "st_contract";
            this.st_contract.Size = new System.Drawing.Size(407, 19);
            this.st_contract.TabIndex = 0;
            this.st_contract.Text = "Contract: 5000 - This is the description for contract 5000";
            this.st_contract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ra_volume
            // 
            this.ra_volume.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaVolume", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_volume.ForeColor = System.Drawing.Color.Black;
            this.ra_volume.Location = new System.Drawing.Point(147, 131);
            this.ra_volume.MaxLength = 0;
            this.ra_volume.Name = "ra_volume";
            this.ra_volume.Size = new System.Drawing.Size(60, 20);
            this.ra_volume.TabIndex = 40;
            this.ra_volume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            
            // 
            // ra_date_of_check_t
            // 
            this.ra_date_of_check_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_date_of_check_t.ForeColor = System.Drawing.Color.Black;
            this.ra_date_of_check_t.Location = new System.Drawing.Point(13, 19);
            this.ra_date_of_check_t.Name = "ra_date_of_check_t";
            this.ra_date_of_check_t.Size = new System.Drawing.Size(127, 20);
            this.ra_date_of_check_t.TabIndex = 41;
            this.ra_date_of_check_t.Text = "Date of Check";
            this.ra_date_of_check_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_time_finished_sort_t
            // 
            this.ra_time_finished_sort_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_time_finished_sort_t.ForeColor = System.Drawing.Color.Black;
            this.ra_time_finished_sort_t.Location = new System.Drawing.Point(36, 71);
            this.ra_time_finished_sort_t.Name = "ra_time_finished_sort_t";
            this.ra_time_finished_sort_t.Size = new System.Drawing.Size(104, 13);
            this.ra_time_finished_sort_t.TabIndex = 42;
            this.ra_time_finished_sort_t.Text = "Time Finished Sort";
            this.ra_time_finished_sort_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_time_started_sort_t
            // 
            this.ra_time_started_sort_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_time_started_sort_t.ForeColor = System.Drawing.Color.Black;
            this.ra_time_started_sort_t.Location = new System.Drawing.Point(38, 91);
            this.ra_time_started_sort_t.Name = "ra_time_started_sort_t";
            this.ra_time_started_sort_t.Size = new System.Drawing.Size(101, 13);
            this.ra_time_started_sort_t.TabIndex = 43;
            this.ra_time_started_sort_t.Text = "Time Started Sort";
            this.ra_time_started_sort_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_date_of_check
            // 
            this.ra_date_of_check.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaDateOfCheck", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_date_of_check.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_date_of_check.Location = new System.Drawing.Point(147, 22);
            this.ra_date_of_check.Mask = "00/00/0000";
            this.ra_date_of_check.PromptChar = '0';
            this.ra_date_of_check.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_date_of_check.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ra_date_of_check.Name = "ra_date_of_check";
            this.ra_date_of_check.Size = new System.Drawing.Size(86, 20);
            this.ra_date_of_check.TabIndex = 10;
            this.ra_date_of_check.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_date_of_check.DataBindings[0].FormatString = "dd/MM/yyyy";            
            this.ra_date_of_check.ValidatingType = typeof(System.DateTime);
            // 
            // ra_time_finished_sort
            // 
            this.ra_time_finished_sort.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaTimeFinishedSort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_time_finished_sort.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_time_finished_sort.Location = new System.Drawing.Point(147, 71);
            this.ra_time_finished_sort.Mask = "00:00";
            this.ra_time_finished_sort.PromptChar = '0';
            this.ra_time_finished_sort.Name = "ra_time_finished_sort";
            this.ra_time_finished_sort.Size = new System.Drawing.Size(35, 20);
            this.ra_time_finished_sort.TabIndex = 20;
            this.ra_time_finished_sort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_time_finished_sort.DataBindings[0].FormatString = "HH:mm";
            this.ra_time_finished_sort.ValidatingType = typeof(System.DateTime);
            this.ra_time_finished_sort.DataBindings[0].DataSourceNullValue = null;
            this.ra_time_finished_sort.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_time_finished_sort.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_time_started_sort
            // 
            this.ra_time_started_sort.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaTimeStartedSort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_time_started_sort.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_time_started_sort.Location = new System.Drawing.Point(147, 91);
            this.ra_time_started_sort.Mask = "00:00";
            this.ra_time_started_sort.PromptChar = '0';
            this.ra_time_started_sort.Name = "ra_time_started_sort";
            this.ra_time_started_sort.Size = new System.Drawing.Size(35, 20);
            this.ra_time_started_sort.TabIndex = 30;
            this.ra_time_started_sort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_time_started_sort.DataBindings[0].FormatString = "HH:mm";
            this.ra_time_started_sort.ValidatingType = typeof(System.DateTime);
            this.ra_time_started_sort.DataBindings[0].DataSourceNullValue = null;
            this.ra_time_started_sort.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_time_started_sort.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_time_returned_t
            // 
            this.ra_time_returned_t.BackColor = System.Drawing.Color.Transparent;
            this.ra_time_returned_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_time_returned_t.ForeColor = System.Drawing.Color.Black;
            this.ra_time_returned_t.Location = new System.Drawing.Point(43, 192);
            this.ra_time_returned_t.Name = "ra_time_returned_t";
            this.ra_time_returned_t.Size = new System.Drawing.Size(97, 18);
            this.ra_time_returned_t.TabIndex = 44;
            this.ra_time_returned_t.Text = "Time Returned";
            this.ra_time_returned_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_time_returned
            // 
            this.ra_time_returned.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaTimeReturned", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_time_returned.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_time_returned.Location = new System.Drawing.Point(147, 189);
            this.ra_time_returned.Mask = "00:00";
            this.ra_time_returned.PromptChar = '0';
            this.ra_time_returned.Name = "ra_time_returned";
            this.ra_time_returned.Size = new System.Drawing.Size(35, 20);
            this.ra_time_returned.TabIndex = 50;
            this.ra_time_returned.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_time_returned.DataBindings[0].FormatString = "HH:mm";
            this.ra_time_returned.ValidatingType = typeof(System.DateTime);
            this.ra_time_returned.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ra_time_returned.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;

            // 
            // ra_finish_odometer_t
            // 
            this.ra_finish_odometer_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ra_finish_odometer_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_finish_odometer_t.ForeColor = System.Drawing.Color.Black;
            this.ra_finish_odometer_t.Location = new System.Drawing.Point(255, 193);
            this.ra_finish_odometer_t.Name = "ra_finish_odometer_t";
            this.ra_finish_odometer_t.Size = new System.Drawing.Size(98, 13);
            this.ra_finish_odometer_t.TabIndex = 51;
            this.ra_finish_odometer_t.Text = "Finish Odometer";
            this.ra_finish_odometer_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_finish_odometer
            // 
            this.ra_finish_odometer.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RaFinishOdometer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_finish_odometer.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_finish_odometer.Location = new System.Drawing.Point(358, 186);
            this.ra_finish_odometer.Name = "ra_finish_odometer";
            this.ra_finish_odometer.Size = new System.Drawing.Size(52, 20);
            this.ra_finish_odometer.TabIndex = 90;
            this.ra_finish_odometer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ra_finish_odometer.EditMask = "######.0";
            this.ra_finish_odometer.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ra_finish_odometer.DataBindings[0].FormatString = "######.0";
            this.ra_finish_odometer.PromptChar = ' ';
            //this.ra_finish_odometer.ValidatingType = typeof(decimal);            

            // 
            // ra_time_departed_t
            // 
            this.ra_time_departed_t.BackColor = System.Drawing.Color.Transparent;
            this.ra_time_departed_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_time_departed_t.ForeColor = System.Drawing.Color.Black;
            this.ra_time_departed_t.Location = new System.Drawing.Point(42, 207);
            this.ra_time_departed_t.Name = "ra_time_departed_t";
            this.ra_time_departed_t.Size = new System.Drawing.Size(98, 18);
            this.ra_time_departed_t.TabIndex = 91;
            this.ra_time_departed_t.Text = "Time Departed";
            this.ra_time_departed_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_time_departed
            // 
            this.ra_time_departed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaTimeDeparted", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_time_departed.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_time_departed.Location = new System.Drawing.Point(147, 208);
            this.ra_time_departed.Mask = "00:00";
            this.ra_time_departed.PromptChar = '0';
            this.ra_time_departed.Name = "ra_time_departed";
            this.ra_time_departed.Size = new System.Drawing.Size(35, 20);
            this.ra_time_departed.TabIndex = 60;
            this.ra_time_departed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_time_departed.DataBindings[0].FormatString = "HH:mm";
            this.ra_time_departed.ValidatingType = typeof(System.DateTime);
            this.ra_time_departed.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_time_departed.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_start_odometer_t
            // 
            this.ra_start_odometer_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ra_start_odometer_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_start_odometer_t.ForeColor = System.Drawing.Color.Black;
            this.ra_start_odometer_t.Location = new System.Drawing.Point(260, 208);
            this.ra_start_odometer_t.Name = "ra_start_odometer_t";
            this.ra_start_odometer_t.Size = new System.Drawing.Size(93, 16);
            this.ra_start_odometer_t.TabIndex = 92;
            this.ra_start_odometer_t.Text = "Start Odometer";
            this.ra_start_odometer_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_start_odometer
            // 
            this.ra_start_odometer.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RaStartOdometer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_start_odometer.DataBindings[0].FormatString = "######.0";
            this.ra_start_odometer.PromptChar = ' ';
            this.ra_start_odometer.EditMask = "######.0";
            this.ra_start_odometer.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ra_start_odometer.Font = new System.Drawing.Font("MS Sans Serif", 8);
            this.ra_start_odometer.Location = new System.Drawing.Point(358, 205);
            this.ra_start_odometer.Name = "ra_start_odometer";
            this.ra_start_odometer.Size = new System.Drawing.Size(52, 20);
            this.ra_start_odometer.TabIndex = 100;
            this.ra_start_odometer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ra_total_hours_t
            // 
            this.ra_total_hours_t.BackColor = System.Drawing.Color.Transparent;
            this.ra_total_hours_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_total_hours_t.ForeColor = System.Drawing.Color.Black;
            this.ra_total_hours_t.Location = new System.Drawing.Point(64, 230);
            this.ra_total_hours_t.Name = "ra_total_hours_t";
            this.ra_total_hours_t.Size = new System.Drawing.Size(76, 15);
            this.ra_total_hours_t.TabIndex = 101;
            this.ra_total_hours_t.Text = "Total Hours";
            this.ra_total_hours_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_total_hours
            // 
            this.ra_total_hours.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ra_total_hours.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaTotalHours", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_total_hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_total_hours.Location = new System.Drawing.Point(147, 230);
            this.ra_total_hours.Mask = "00:00";
            this.ra_total_hours.Name = "ra_total_hours";
            this.ra_total_hours.Enabled = false;// ReadOnly = true;
            this.ra_total_hours.Size = new System.Drawing.Size(35, 13);
            this.ra_total_hours.TabIndex = 102;
            this.ra_total_hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_total_hours.DataBindings[0].FormatString = "HH:mm";
            this.ra_total_hours.ValidatingType = typeof(System.DateTime);
            this.ra_total_hours.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_total_hours.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ra_total_hours.PromptChar = '0';
            // 
            // ra_total_distance_t
            // 
            this.ra_total_distance_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ra_total_distance_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_total_distance_t.ForeColor = System.Drawing.Color.Black;
            this.ra_total_distance_t.Location = new System.Drawing.Point(264, 233);
            this.ra_total_distance_t.Name = "ra_total_distance_t";
            this.ra_total_distance_t.Size = new System.Drawing.Size(90, 13);
            this.ra_total_distance_t.TabIndex = 103;
            this.ra_total_distance_t.Text = "Total Distance";
            this.ra_total_distance_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_meal_breaks_t
            // 
            this.ra_meal_breaks_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_meal_breaks_t.ForeColor = System.Drawing.Color.Black;
            this.ra_meal_breaks_t.Location = new System.Drawing.Point(22, 248);
            this.ra_meal_breaks_t.Name = "ra_meal_breaks_t";
            this.ra_meal_breaks_t.Size = new System.Drawing.Size(118, 16);
            this.ra_meal_breaks_t.TabIndex = 104;
            this.ra_meal_breaks_t.Text = "Less Meal Breaks";
            this.ra_meal_breaks_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_meal_breaks
            // 
            this.ra_meal_breaks.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaMealBreaks", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_meal_breaks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_meal_breaks.Location = new System.Drawing.Point(147, 248);
            this.ra_meal_breaks.Mask = "00:00";
            this.ra_meal_breaks.PromptChar = '0';
            this.ra_meal_breaks.Name = "ra_meal_breaks";
            this.ra_meal_breaks.Size = new System.Drawing.Size(35, 20);
            this.ra_meal_breaks.TabIndex = 70;
            this.ra_meal_breaks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_meal_breaks.DataBindings[0].FormatString = "HH:mm";
            this.ra_meal_breaks.ValidatingType = typeof(System.DateTime);
            this.ra_meal_breaks.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_meal_breaks.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_extra_time_t
            // 
            this.ra_extra_time_t.BackColor = System.Drawing.Color.Transparent;
            this.ra_extra_time_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_extra_time_t.ForeColor = System.Drawing.Color.Black;
            this.ra_extra_time_t.Location = new System.Drawing.Point(44, 268);
            this.ra_extra_time_t.Name = "ra_extra_time_t";
            this.ra_extra_time_t.Size = new System.Drawing.Size(96, 13);
            this.ra_extra_time_t.TabIndex = 105;
            this.ra_extra_time_t.Text = "Less Extra Time";
            this.ra_extra_time_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_extra_time
            // 
            this.ra_extra_time.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaExtraTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_extra_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_extra_time.Location = new System.Drawing.Point(147, 268);
            this.ra_extra_time.Mask = "00:00";
            this.ra_extra_time.PromptChar = '0';
            this.ra_extra_time.Name = "ra_extra_time";
            this.ra_extra_time.Size = new System.Drawing.Size(35, 20);
            this.ra_extra_time.TabIndex = 80;
            this.ra_extra_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_extra_time.DataBindings[0].FormatString = "HH:mm";
            this.ra_extra_time.ValidatingType = typeof(System.DateTime);
            this.ra_extra_time.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_extra_time.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_extra_distance_t
            // 
            this.ra_extra_distance_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ra_extra_distance_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_extra_distance_t.ForeColor = System.Drawing.Color.Black;
            this.ra_extra_distance_t.Location = new System.Drawing.Point(218, 268);
            this.ra_extra_distance_t.Name = "ra_extra_distance_t";
            this.ra_extra_distance_t.Size = new System.Drawing.Size(135, 13);
            this.ra_extra_distance_t.TabIndex = 106;
            this.ra_extra_distance_t.Text = "Less \'Extra\' Distances";
            this.ra_extra_distance_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_extra_distance
            // 
            this.ra_extra_distance.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "RaExtraDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_extra_distance.DataBindings[0].FormatString = "###.0";
            this.ra_extra_distance.PromptChar = ' ';
            this.ra_extra_distance.EditMask = "###.0";
            this.ra_extra_distance.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ra_extra_distance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_extra_distance.Location = new System.Drawing.Point(358, 268);
            this.ra_extra_distance.Name = "ra_extra_distance";
            this.ra_extra_distance.Size = new System.Drawing.Size(52, 20);
            this.ra_extra_distance.TabIndex = 110;
            this.ra_extra_distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ra_final_hours_t
            // 
            this.ra_final_hours_t.BackColor = System.Drawing.Color.Transparent;
            this.ra_final_hours_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.ra_final_hours_t.ForeColor = System.Drawing.Color.Black;
            this.ra_final_hours_t.Location = new System.Drawing.Point(42, 288);
            this.ra_final_hours_t.Name = "ra_final_hours_t";
            this.ra_final_hours_t.Size = new System.Drawing.Size(98, 17);
            this.ra_final_hours_t.TabIndex = 111;
            this.ra_final_hours_t.Text = "Total Hours";
            this.ra_final_hours_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_final_hours
            // 
            this.ra_final_hours.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ra_final_hours.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaFinalHours", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_final_hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_final_hours.Location = new System.Drawing.Point(147, 288);
            this.ra_final_hours.Mask = "00:00";
            this.ra_final_hours.Name = "ra_final_hours";
            this.ra_final_hours.Enabled = false;// ReadOnly = true;
            this.ra_final_hours.Size = new System.Drawing.Size(35, 13);
            this.ra_final_hours.TabIndex = 112;
            this.ra_final_hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_final_hours.DataBindings[0].FormatString = "HH:mm";
            this.ra_final_hours.ValidatingType = typeof(System.DateTime);
            this.ra_final_hours.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_final_hours.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.ra_final_hours.PromptChar = '0';
            // 
            // ra_final_distance_t
            // 
            this.ra_final_distance_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ra_final_distance_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.ra_final_distance_t.ForeColor = System.Drawing.Color.Black;
            this.ra_final_distance_t.Location = new System.Drawing.Point(240, 288);
            this.ra_final_distance_t.Name = "ra_final_distance_t";
            this.ra_final_distance_t.Size = new System.Drawing.Size(113, 13);
            this.ra_final_distance_t.TabIndex = 113;
            this.ra_final_distance_t.Text = "Total Distance";
            this.ra_final_distance_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_othr_gds_before_t
            // 
            this.ra_othr_gds_before_t.BackColor = System.Drawing.Color.Transparent;
            this.ra_othr_gds_before_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_othr_gds_before_t.ForeColor = System.Drawing.Color.Black;
            this.ra_othr_gds_before_t.Location = new System.Drawing.Point(47, 326);
            this.ra_othr_gds_before_t.Name = "ra_othr_gds_before_t";
            this.ra_othr_gds_before_t.Size = new System.Drawing.Size(96, 13);
            this.ra_othr_gds_before_t.TabIndex = 114;
            this.ra_othr_gds_before_t.Text = "Before Delivery";
            this.ra_othr_gds_before_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_othr_gds_before
            // 
            this.ra_othr_gds_before.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaOthrGdsBefore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_othr_gds_before.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_othr_gds_before.Location = new System.Drawing.Point(147, 324);
            this.ra_othr_gds_before.Mask = "00:00";
            this.ra_othr_gds_before.PromptChar = '0';
            this.ra_othr_gds_before.Name = "ra_othr_gds_before";
            this.ra_othr_gds_before.Size = new System.Drawing.Size(35, 20);
            this.ra_othr_gds_before.TabIndex = 120;
            this.ra_othr_gds_before.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_othr_gds_before.DataBindings[0].FormatString = "HH:mm";
            this.ra_othr_gds_before.ValidatingType = typeof(System.DateTime);
            this.ra_othr_gds_before.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_othr_gds_before.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_pr_before_t
            // 
            this.ra_pr_before_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ra_pr_before_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_pr_before_t.ForeColor = System.Drawing.Color.Black;
            this.ra_pr_before_t.Location = new System.Drawing.Point(259, 326);
            this.ra_pr_before_t.Name = "ra_pr_before_t";
            this.ra_pr_before_t.Size = new System.Drawing.Size(94, 13);
            this.ra_pr_before_t.TabIndex = 121;
            this.ra_pr_before_t.Text = "Before Delivery";
            this.ra_pr_before_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_pr_before
            // 
            this.ra_pr_before.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaPrBefore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_pr_before.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_pr_before.Location = new System.Drawing.Point(358, 326);
            this.ra_pr_before.Mask = "00:00";
            this.ra_pr_before.PromptChar = '0';
            this.ra_pr_before.Name = "ra_pr_before";
            this.ra_pr_before.Size = new System.Drawing.Size(35, 20);
            this.ra_pr_before.TabIndex = 150;
            this.ra_pr_before.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_pr_before.DataBindings[0].FormatString = "HH:mm";
            this.ra_pr_before.ValidatingType = typeof(System.DateTime);
            this.ra_pr_before.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_pr_before.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_othr_gds_during_t
            // 
            this.ra_othr_gds_during_t.BackColor = System.Drawing.Color.Transparent;
            this.ra_othr_gds_during_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_othr_gds_during_t.ForeColor = System.Drawing.Color.Black;
            this.ra_othr_gds_during_t.Location = new System.Drawing.Point(47, 344);
            this.ra_othr_gds_during_t.Name = "ra_othr_gds_during_t";
            this.ra_othr_gds_during_t.Size = new System.Drawing.Size(96, 13);
            this.ra_othr_gds_during_t.TabIndex = 151;
            this.ra_othr_gds_during_t.Text = "During Delivery";
            this.ra_othr_gds_during_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_othr_gds_during
            // 
            this.ra_othr_gds_during.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaOthrGdsDuring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_othr_gds_during.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_othr_gds_during.Location = new System.Drawing.Point(147, 344);
            this.ra_othr_gds_during.Mask = "00:00";
            this.ra_othr_gds_during.PromptChar = '0';
            this.ra_othr_gds_during.Name = "ra_othr_gds_during";
            this.ra_othr_gds_during.Size = new System.Drawing.Size(35, 20);
            this.ra_othr_gds_during.TabIndex = 130;
            this.ra_othr_gds_during.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_othr_gds_during.DataBindings[0].FormatString = "HH:mm";
            this.ra_othr_gds_during.ValidatingType = typeof(System.DateTime);
            this.ra_othr_gds_during.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_othr_gds_during.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_pr_during_t
            // 
            this.ra_pr_during_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ra_pr_during_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_pr_during_t.ForeColor = System.Drawing.Color.Black;
            this.ra_pr_during_t.Location = new System.Drawing.Point(259, 344);
            this.ra_pr_during_t.Name = "ra_pr_during_t";
            this.ra_pr_during_t.Size = new System.Drawing.Size(94, 13);
            this.ra_pr_during_t.TabIndex = 152;
            this.ra_pr_during_t.Text = "During Delivery";
            this.ra_pr_during_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_pr_during
            // 
            this.ra_pr_during.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaPrDuring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_pr_during.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_pr_during.Location = new System.Drawing.Point(358, 345);
            this.ra_pr_during.Mask = "00:00";
            this.ra_pr_during.PromptChar = '0';
            this.ra_pr_during.Name = "ra_pr_during";
            this.ra_pr_during.Size = new System.Drawing.Size(35, 20);
            this.ra_pr_during.TabIndex = 160;
            this.ra_pr_during.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_pr_during.DataBindings[0].FormatString = "HH:mm";
            this.ra_pr_during.ValidatingType = typeof(System.DateTime);
            this.ra_pr_during.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_pr_during.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_othr_gds_after_t
            // 
            this.ra_othr_gds_after_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_othr_gds_after_t.ForeColor = System.Drawing.Color.Black;
            this.ra_othr_gds_after_t.Location = new System.Drawing.Point(55, 362);
            this.ra_othr_gds_after_t.Name = "ra_othr_gds_after_t";
            this.ra_othr_gds_after_t.Size = new System.Drawing.Size(87, 13);
            this.ra_othr_gds_after_t.TabIndex = 161;
            this.ra_othr_gds_after_t.Text = "After Delivery";
            this.ra_othr_gds_after_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_othr_gds_after
            // 
            this.ra_othr_gds_after.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaOthrGdsAfter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_othr_gds_after.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_othr_gds_after.Location = new System.Drawing.Point(147, 363);
            this.ra_othr_gds_after.Mask = "00:00";
            this.ra_othr_gds_after.PromptChar = '0';
            this.ra_othr_gds_after.Name = "ra_othr_gds_after";
            this.ra_othr_gds_after.Size = new System.Drawing.Size(35, 20);
            this.ra_othr_gds_after.TabIndex = 140;
            this.ra_othr_gds_after.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_othr_gds_after.DataBindings[0].FormatString = "HH:mm";
            this.ra_othr_gds_after.ValidatingType = typeof(System.DateTime);
            this.ra_othr_gds_after.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_othr_gds_after.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_pr_after_t
            // 
            this.ra_pr_after_t.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ra_pr_after_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_pr_after_t.ForeColor = System.Drawing.Color.Black;
            this.ra_pr_after_t.Location = new System.Drawing.Point(264, 362);
            this.ra_pr_after_t.Name = "ra_pr_after_t";
            this.ra_pr_after_t.Size = new System.Drawing.Size(90, 13);
            this.ra_pr_after_t.TabIndex = 162;
            this.ra_pr_after_t.Text = "After Delivery";
            this.ra_pr_after_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_pr_after
            // 
            this.ra_pr_after.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaPrAfter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_pr_after.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_pr_after.Location = new System.Drawing.Point(358, 365);
            this.ra_pr_after.Mask = "00:00";
            this.ra_pr_after.PromptChar = '0';
            this.ra_pr_after.Name = "ra_pr_after";
            this.ra_pr_after.Size = new System.Drawing.Size(35, 20);
            this.ra_pr_after.TabIndex = 170;
            this.ra_pr_after.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_pr_after.DataBindings[0].FormatString = "HH:mm";
            this.ra_pr_after.ValidatingType = typeof(System.DateTime);
            this.ra_pr_after.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_pr_after.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_frequency_t
            // 
            this.ra_frequency_t.BackColor = System.Drawing.Color.Transparent;
            this.ra_frequency_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_frequency_t.ForeColor = System.Drawing.Color.Black;
            this.ra_frequency_t.Location = new System.Drawing.Point(68, 402);
            this.ra_frequency_t.Name = "ra_frequency_t";
            this.ra_frequency_t.Size = new System.Drawing.Size(79, 13);
            this.ra_frequency_t.TabIndex = 171;
            this.ra_frequency_t.Text = "Frequency";
            this.ra_frequency_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_frequency
            // 
            this.ra_frequency.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaFrequency", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_frequency.ForeColor = System.Drawing.Color.Black;
            this.ra_frequency.Location = new System.Drawing.Point(152, 399);
            this.ra_frequency.MaxLength = 30;
            this.ra_frequency.Name = "ra_frequency";
            this.ra_frequency.Size = new System.Drawing.Size(192, 20);
            this.ra_frequency.TabIndex = 180;
            // 
            // ra_contractor_t
            // 
            this.ra_contractor_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_contractor_t.ForeColor = System.Drawing.Color.Black;
            this.ra_contractor_t.Location = new System.Drawing.Point(62, 420);
            this.ra_contractor_t.Name = "ra_contractor_t";
            this.ra_contractor_t.Size = new System.Drawing.Size(85, 13);
            this.ra_contractor_t.TabIndex = 181;
            this.ra_contractor_t.Text = "Owner Driver";
            this.ra_contractor_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_contractor
            // 
            this.ra_contractor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaContractor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_contractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_contractor.ForeColor = System.Drawing.Color.Black;
            this.ra_contractor.Location = new System.Drawing.Point(152, 419);
            this.ra_contractor.MaxLength = 60;
            this.ra_contractor.Name = "ra_contractor";
            this.ra_contractor.Size = new System.Drawing.Size(367, 20);
            this.ra_contractor.TabIndex = 190;
            // 
            // ra_employee_t
            // 
            this.ra_employee_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_employee_t.ForeColor = System.Drawing.Color.Black;
            this.ra_employee_t.Location = new System.Drawing.Point(69, 438);
            this.ra_employee_t.Name = "ra_employee_t";
            this.ra_employee_t.Size = new System.Drawing.Size(78, 13);
            this.ra_employee_t.TabIndex = 191;
            this.ra_employee_t.Text = "Employee";
            this.ra_employee_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ra_employee
            // 
            this.ra_employee.BackColor = System.Drawing.Color.White;
            this.ra_employee.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaEmployee", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_employee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_employee.ForeColor = System.Drawing.Color.Black;
            this.ra_employee.Location = new System.Drawing.Point(152, 439);
            this.ra_employee.MaxLength = 60;
            this.ra_employee.Name = "ra_employee";
            this.ra_employee.Size = new System.Drawing.Size(367, 20);
            this.ra_employee.TabIndex = 200;
            // 
            // ra_vehicle_make
            // 
            this.ra_vehicle_make.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaVehicleMake", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_vehicle_make.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_vehicle_make.ForeColor = System.Drawing.Color.Black;
            this.ra_vehicle_make.Location = new System.Drawing.Point(141, 477);
            this.ra_vehicle_make.MaxLength = 20;
            this.ra_vehicle_make.Name = "ra_vehicle_make";
            this.ra_vehicle_make.Size = new System.Drawing.Size(117, 20);
            this.ra_vehicle_make.TabIndex = 210;
            // 
            // ra_vehicle_model
            // 
            this.ra_vehicle_model.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaVehicleModel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_vehicle_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_vehicle_model.ForeColor = System.Drawing.Color.Black;
            this.ra_vehicle_model.Location = new System.Drawing.Point(302, 477);
            this.ra_vehicle_model.MaxLength = 20;
            this.ra_vehicle_model.Name = "ra_vehicle_model";
            this.ra_vehicle_model.Size = new System.Drawing.Size(117, 20);
            this.ra_vehicle_model.TabIndex = 220;
            // 
            // ra_year
            // 
            this.ra_year.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaYear", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_year.Location = new System.Drawing.Point(479, 478);
            this.ra_year.Name = "ra_year";
            this.ra_year.Size = new System.Drawing.Size(39, 20);
            this.ra_year.TabIndex = 230;
            this.ra_year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ra_registration_no
            // 
            this.ra_registration_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaRegistrationNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_registration_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_registration_no.Location = new System.Drawing.Point(141, 496);
            this.ra_registration_no.Name = "ra_registration_no";
            //this.ra_registration_no.Mask = "??????????";
            //this.ra_registration_no.PromptChar = ' ';
            this.ra_registration_no.MaxLength = 10;
            this.ra_registration_no.Size = new System.Drawing.Size(69, 20);
            this.ra_registration_no.TabIndex = 240;
            // 
            // ra_fuel
            // 
            this.ra_fuel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaFuel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_fuel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_fuel.ForeColor = System.Drawing.Color.Black;
            this.ra_fuel.Location = new System.Drawing.Point(302, 496);
            this.ra_fuel.MaxLength = 20;
            this.ra_fuel.Name = "ra_fuel";
            this.ra_fuel.Size = new System.Drawing.Size(117, 20);
            this.ra_fuel.TabIndex = 250;
            // 
            // ra_cc_rating
            // 
            this.ra_cc_rating.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaCcRating", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_cc_rating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_cc_rating.Location = new System.Drawing.Point(479, 498);
            this.ra_cc_rating.Name = "ra_cc_rating";
            this.ra_cc_rating.Size = new System.Drawing.Size(39, 20);
            this.ra_cc_rating.TabIndex = 260;
            this.ra_cc_rating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ra_condition
            // 
            this.ra_condition.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaCondition", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_condition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_condition.ForeColor = System.Drawing.Color.Black;
            this.ra_condition.Location = new System.Drawing.Point(141, 515);
            this.ra_condition.MaxLength = 20;
            this.ra_condition.Name = "ra_condition";
            this.ra_condition.Size = new System.Drawing.Size(117, 20);
            this.ra_condition.TabIndex = 270;
            // 
            // ra_tyre_size
            // 
            this.ra_tyre_size.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaTyreSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_tyre_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_tyre_size.ForeColor = System.Drawing.Color.Black;
            this.ra_tyre_size.Location = new System.Drawing.Point(302, 515);
            this.ra_tyre_size.MaxLength = 10;
            this.ra_tyre_size.Name = "ra_tyre_size";
            this.ra_tyre_size.Size = new System.Drawing.Size(117, 20);
            this.ra_tyre_size.TabIndex = 290;
            // 
            // ra_rec_replace
            // 
            this.ra_rec_replace.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaRecReplace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_rec_replace.Location = new System.Drawing.Point(141, 535);
            this.ra_rec_replace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_rec_replace.Name = "ra_rec_replace";
            this.ra_rec_replace.Mask = "00/00/00";
            this.ra_rec_replace.PromptChar = '0';
            this.ra_rec_replace.Size = new System.Drawing.Size(54, 20);
            this.ra_rec_replace.TabIndex = 280;
            this.ra_rec_replace.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_rec_replace.DataBindings[0].FormatString = "dd/MM/yy";
            this.ra_rec_replace.ValidatingType = typeof(System.DateTime);
            this.ra_rec_replace.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_rec_replace.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_gds_service
            // 
            this.ra_gds_service.BackColor = System.Drawing.Color.Transparent;
            this.ra_gds_service.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_gds_service.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaGdsService"));
            this.ra_gds_service.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_gds_service.ForeColor = System.Drawing.Color.Black;
            this.ra_gds_service.Location = new System.Drawing.Point(73, 553);
            this.ra_gds_service.Name = "ra_gds_service";
            this.ra_gds_service.Size = new System.Drawing.Size(118, 16);
            this.ra_gds_service.TabIndex = 300;
            this.ra_gds_service.Text = "Goods Service";
            this.ra_gds_service.UseVisualStyleBackColor = false;
            // 
            // ra_mv_insurance
            // 
            this.ra_mv_insurance.BackColor = System.Drawing.Color.Transparent;
            this.ra_mv_insurance.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_mv_insurance.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaMvInsurance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_mv_insurance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_mv_insurance.ForeColor = System.Drawing.Color.Black;
            this.ra_mv_insurance.Location = new System.Drawing.Point(414, 553);
            this.ra_mv_insurance.Name = "ra_mv_insurance";
            this.ra_mv_insurance.Size = new System.Drawing.Size(107, 16);
            this.ra_mv_insurance.TabIndex = 320;
            this.ra_mv_insurance.Text = "Motor Vehicle";
            this.ra_mv_insurance.UseVisualStyleBackColor = false;
            // 
            // ra_gds_service_sighted
            // 
            this.ra_gds_service_sighted.BackColor = System.Drawing.Color.Transparent;
            this.ra_gds_service_sighted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_gds_service_sighted.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaGdsServiceSighted", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_gds_service_sighted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_gds_service_sighted.ForeColor = System.Drawing.Color.Black;
            this.ra_gds_service_sighted.Location = new System.Drawing.Point(73, 570);
            this.ra_gds_service_sighted.Name = "ra_gds_service_sighted";
            this.ra_gds_service_sighted.Size = new System.Drawing.Size(118, 16);
            this.ra_gds_service_sighted.TabIndex = 310;
            this.ra_gds_service_sighted.Text = "Sighted";
            this.ra_gds_service_sighted.UseVisualStyleBackColor = false;
            // 
            // ra_cr_insurance
            // 
            this.ra_cr_insurance.BackColor = System.Drawing.Color.Transparent;
            this.ra_cr_insurance.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_cr_insurance.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaCrInsurance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_cr_insurance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_cr_insurance.ForeColor = System.Drawing.Color.Black;
            this.ra_cr_insurance.Location = new System.Drawing.Point(414, 570);
            this.ra_cr_insurance.Name = "ra_cr_insurance";
            this.ra_cr_insurance.Size = new System.Drawing.Size(107, 16);
            this.ra_cr_insurance.TabIndex = 330;
            this.ra_cr_insurance.Text = "Carrier\'s Risk";
            this.ra_cr_insurance.UseVisualStyleBackColor = false;
            // 
            // ra_pl_insurance
            // 
            this.ra_pl_insurance.BackColor = System.Drawing.Color.Transparent;
            this.ra_pl_insurance.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_pl_insurance.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaPlInsurance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_pl_insurance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_pl_insurance.ForeColor = System.Drawing.Color.Black;
            this.ra_pl_insurance.Location = new System.Drawing.Point(414, 587);
            this.ra_pl_insurance.Name = "ra_pl_insurance";
            this.ra_pl_insurance.Size = new System.Drawing.Size(107, 20);
            this.ra_pl_insurance.TabIndex = 340;
            this.ra_pl_insurance.Text = "Public Liability";
            this.ra_pl_insurance.UseVisualStyleBackColor = false;
            // 
            // ra_insurance_sighted
            // 
            this.ra_insurance_sighted.BackColor = System.Drawing.Color.Transparent;
            this.ra_insurance_sighted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_insurance_sighted.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaInsuranceSighted", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_insurance_sighted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_insurance_sighted.ForeColor = System.Drawing.Color.Black;
            this.ra_insurance_sighted.Location = new System.Drawing.Point(414, 604);
            this.ra_insurance_sighted.Name = "ra_insurance_sighted";
            this.ra_insurance_sighted.Size = new System.Drawing.Size(107, 19);
            this.ra_insurance_sighted.TabIndex = 350;
            this.ra_insurance_sighted.Text = "Sighted";
            this.ra_insurance_sighted.UseVisualStyleBackColor = false;
            // 
            // ra_new_vehicle
            // 
            this.ra_new_vehicle.BackColor = System.Drawing.Color.Transparent;
            this.ra_new_vehicle.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ra_new_vehicle.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaNewVehicle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_new_vehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_new_vehicle.ForeColor = System.Drawing.Color.Black;
            this.ra_new_vehicle.Location = new System.Drawing.Point(62, 619);
            this.ra_new_vehicle.Name = "ra_new_vehicle";
            this.ra_new_vehicle.Size = new System.Drawing.Size(216, 16);
            this.ra_new_vehicle.TabIndex = 360;
            this.ra_new_vehicle.Text = "Vehicle changed since last renewal";
            this.ra_new_vehicle.UseVisualStyleBackColor = false;
            // 
            // ra_vehicle_price
            // 
            this.ra_vehicle_price.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaVehiclePrice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_vehicle_price.Location = new System.Drawing.Point(198, 641);
            this.ra_vehicle_price.Name = "ra_vehicle_price";
            this.ra_vehicle_price.Size = new System.Drawing.Size(45, 20);
            this.ra_vehicle_price.TabIndex = 370;
            this.ra_vehicle_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ra_vehicle_price.EditMask = "###,###";
            this.ra_vehicle_price.PromptChar = ' ';
            this.ra_vehicle_price.DataBindings[0].FormatString = "###,###";
            this.ra_vehicle_price.InsertKeyMode = InsertKeyMode.Overwrite;
            // 
            // ra_vehicle_purchased
            // 
            this.ra_vehicle_purchased.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaVehiclePurchased", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_vehicle_purchased.Location = new System.Drawing.Point(357, 640);
            this.ra_vehicle_purchased.Name = "ra_vehicle_purchased";
            this.ra_vehicle_purchased.Size = new System.Drawing.Size(54, 20);
            this.ra_vehicle_purchased.TabIndex = 380;
            this.ra_vehicle_purchased.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ra_vehicle_purchased.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_vehicle_purchased.Mask = "00/00/00";
            this.ra_vehicle_purchased.PromptChar = '0';
            this.ra_vehicle_purchased.DataBindings[0].FormatString = "dd/MM/yy";
            this.ra_vehicle_purchased.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_vehicle_purchased.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_mv_comments
            // 
            this.ra_mv_comments.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaMvComments", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_mv_comments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_mv_comments.ForeColor = System.Drawing.Color.Black;
            this.ra_mv_comments.Location = new System.Drawing.Point(28, 739);
            this.ra_mv_comments.MaxLength = 80;
            this.ra_mv_comments.Name = "ra_mv_comments";
            this.ra_mv_comments.Size = new System.Drawing.Size(181, 60);
            this.ra_mv_comments.TabIndex = 400;
            this.ra_mv_comments.Text = "";
            // 
            // ra_no_circular_drops
            // 
            this.ra_no_circular_drops.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaNoCircularDrops", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_no_circular_drops.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_no_circular_drops.Location = new System.Drawing.Point(355, 739);
            this.ra_no_circular_drops.Name = "ra_no_circular_drops";
            this.ra_no_circular_drops.Mask = "###";
            this.ra_no_circular_drops.DataBindings[0].FormatString = "###";
            this.ra_no_circular_drops.InsertKeyMode = InsertKeyMode.Overwrite;
            this.ra_no_circular_drops.DataBindings[0].DataSourceNullValue = null;
            this.ra_no_circular_drops.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            this.ra_no_circular_drops.PromptChar = ' ';
            this.ra_no_circular_drops.Size = new System.Drawing.Size(21, 20);
            this.ra_no_circular_drops.TabIndex = 420;
            this.ra_no_circular_drops.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ra_cp_comments
            // 
            this.ra_cp_comments.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaCpComments", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_cp_comments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_cp_comments.ForeColor = System.Drawing.Color.Black;
            this.ra_cp_comments.Location = new System.Drawing.Point(393, 741);
            this.ra_cp_comments.MaxLength = 80;
            this.ra_cp_comments.Name = "ra_cp_comments";
            this.ra_cp_comments.Size = new System.Drawing.Size(181, 58);
            this.ra_cp_comments.TabIndex = 440;
            this.ra_cp_comments.Text = "";
            // 
            // ra_no_reg_custs
            // 
            this.ra_no_reg_custs.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaNoRegCusts", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_no_reg_custs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_no_reg_custs.Location = new System.Drawing.Point(394, 820);
            this.ra_no_reg_custs.Name = "ra_no_reg_custs";
            this.ra_no_reg_custs.Size = new System.Drawing.Size(32, 20);
            this.ra_no_reg_custs.TabIndex = 450;
            this.ra_no_reg_custs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ra_no_reg_custs_core_prods
            // 
            this.ra_no_reg_custs_core_prods.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaNoRegCustsCoreProds", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_no_reg_custs_core_prods.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_no_reg_custs_core_prods.Location = new System.Drawing.Point(394, 840);
            this.ra_no_reg_custs_core_prods.Name = "ra_no_reg_custs_core_prods";
            this.ra_no_reg_custs_core_prods.Size = new System.Drawing.Size(32, 20);
            this.ra_no_reg_custs_core_prods.TabIndex = 460;
            this.ra_no_reg_custs_core_prods.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ra_other_custs
            // 
            this.ra_other_custs.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaOtherCusts", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_other_custs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_other_custs.Location = new System.Drawing.Point(394, 859);
            this.ra_other_custs.Name = "ra_other_custs";
            this.ra_other_custs.Size = new System.Drawing.Size(32, 20);
            this.ra_other_custs.TabIndex = 470;
            this.ra_other_custs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ra_rural_private_bags
            // 
            this.ra_rural_private_bags.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaRuralPrivateBags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_rural_private_bags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_rural_private_bags.Location = new System.Drawing.Point(394, 878);
            this.ra_rural_private_bags.Name = "ra_rural_private_bags";
            this.ra_rural_private_bags.Size = new System.Drawing.Size(32, 20);
            this.ra_rural_private_bags.TabIndex = 480;
            this.ra_rural_private_bags.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ra_private_bags
            // 
            this.ra_private_bags.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaPrivateBags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_private_bags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_private_bags.Location = new System.Drawing.Point(394, 897);
            this.ra_private_bags.Name = "ra_private_bags";
            this.ra_private_bags.Size = new System.Drawing.Size(32, 20);
            this.ra_private_bags.TabIndex = 490;
            this.ra_private_bags.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ra_closed_mails
            // 
            this.ra_closed_mails.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaClosedMails", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_closed_mails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_closed_mails.Location = new System.Drawing.Point(394, 916);
            this.ra_closed_mails.Name = "ra_closed_mails";
            this.ra_closed_mails.Size = new System.Drawing.Size(32, 20);
            this.ra_closed_mails.TabIndex = 500;
            this.ra_closed_mails.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ra_post_shops
            // 
            this.ra_post_shops.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaPostShops", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_post_shops.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_post_shops.Location = new System.Drawing.Point(394, 935);
            this.ra_post_shops.Name = "ra_post_shops";
            this.ra_post_shops.Size = new System.Drawing.Size(32, 20);
            this.ra_post_shops.TabIndex = 510;
            this.ra_post_shops.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ra_post_centres
            // 
            this.ra_post_centres.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaPostCentres", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_post_centres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_post_centres.Location = new System.Drawing.Point(394, 954);
            this.ra_post_centres.Name = "ra_post_centres";
            this.ra_post_centres.Size = new System.Drawing.Size(32, 20);
            this.ra_post_centres.TabIndex = 520;
            this.ra_post_centres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ra_no_cmbs
            // 
            this.ra_no_cmbs.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaNoCmbs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_no_cmbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_no_cmbs.Location = new System.Drawing.Point(394, 973);
            this.ra_no_cmbs.Name = "ra_no_cmbs";
            this.ra_no_cmbs.Size = new System.Drawing.Size(32, 20);
            this.ra_no_cmbs.TabIndex = 530;
            this.ra_no_cmbs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ra_no_cmb_custs
            // 
            this.ra_no_cmb_custs.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaNoCmbCusts", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_no_cmb_custs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_no_cmb_custs.Location = new System.Drawing.Point(394, 992);
            this.ra_no_cmb_custs.Name = "ra_no_cmb_custs";
            this.ra_no_cmb_custs.Size = new System.Drawing.Size(32, 20);
            this.ra_no_cmb_custs.TabIndex = 540;
            this.ra_no_cmb_custs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ra_sorting_facilities
            // 
            this.ra_sorting_facilities.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaSortingFacilities", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_sorting_facilities.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_sorting_facilities.ForeColor = System.Drawing.Color.Black;
            this.ra_sorting_facilities.Location = new System.Drawing.Point(127, 1044);
            this.ra_sorting_facilities.MaxLength = 0;
            this.ra_sorting_facilities.Name = "ra_sorting_facilities";
            this.ra_sorting_facilities.Size = new System.Drawing.Size(448, 45);
            this.ra_sorting_facilities.TabIndex = 550;
            this.ra_sorting_facilities.Text = "";
            // 
            // ra_sorting_case
            // 
            this.ra_sorting_case.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaSortingCase", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_sorting_case.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_sorting_case.ForeColor = System.Drawing.Color.Black;
            this.ra_sorting_case.Location = new System.Drawing.Point(127, 1088);
            this.ra_sorting_case.MaxLength = 0;
            this.ra_sorting_case.Name = "ra_sorting_case";
            this.ra_sorting_case.Size = new System.Drawing.Size(448, 20);
            this.ra_sorting_case.TabIndex = 560;
            // 
            // ra_sorting_comments
            // 
            this.ra_sorting_comments.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaSortingComments", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_sorting_comments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_sorting_comments.ForeColor = System.Drawing.Color.Black;
            this.ra_sorting_comments.Location = new System.Drawing.Point(127, 1107);
            this.ra_sorting_comments.MaxLength = 0;
            this.ra_sorting_comments.Name = "ra_sorting_comments";
            this.ra_sorting_comments.Size = new System.Drawing.Size(448, 53);
            this.ra_sorting_comments.TabIndex = 570;
            this.ra_sorting_comments.Text = "";
            // 
            // ra_length_sealed
            // 
            this.ra_length_sealed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaLengthSealed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_length_sealed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_length_sealed.ForeColor = System.Drawing.Color.Black;
            this.ra_length_sealed.Location = new System.Drawing.Point(216, 1170);
            this.ra_length_sealed.MaxLength = 0;
            this.ra_length_sealed.Name = "ra_length_sealed";
            this.ra_length_sealed.Size = new System.Drawing.Size(49, 20);
            this.ra_length_sealed.TabIndex = 580;
            this.ra_length_sealed.DataBindings[0].FormatString = "#.0";
            this.ra_length_sealed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ra_lenth_unsealed
            // 
            this.ra_lenth_unsealed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaLenthUnsealed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_lenth_unsealed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_lenth_unsealed.ForeColor = System.Drawing.Color.Black;
            this.ra_lenth_unsealed.Location = new System.Drawing.Point(216, 1189);
            this.ra_lenth_unsealed.MaxLength = 0;
            this.ra_lenth_unsealed.Name = "ra_lenth_unsealed";
            this.ra_lenth_unsealed.Size = new System.Drawing.Size(49, 20);
            this.ra_lenth_unsealed.TabIndex = 590;
            this.ra_lenth_unsealed.DataBindings[0].FormatString = "#.0";
            this.ra_lenth_unsealed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ra_road_conditions
            // 
            this.ra_road_conditions.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaRoadConditions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_road_conditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_road_conditions.ForeColor = System.Drawing.Color.Black;
            this.ra_road_conditions.Location = new System.Drawing.Point(125, 1226);
            this.ra_road_conditions.MaxLength = 0;
            this.ra_road_conditions.Name = "ra_road_conditions";
            this.ra_road_conditions.Size = new System.Drawing.Size(448, 47);
            this.ra_road_conditions.TabIndex = 600;
            this.ra_road_conditions.Text = "";
            // 
            // ra_suggested_improvements
            // 
            this.ra_suggested_improvements.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaSuggestedImprovements", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_suggested_improvements.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_suggested_improvements.ForeColor = System.Drawing.Color.Black;
            this.ra_suggested_improvements.Location = new System.Drawing.Point(127, 1292);
            this.ra_suggested_improvements.MaxLength = 0;
            this.ra_suggested_improvements.Name = "ra_suggested_improvements";
            this.ra_suggested_improvements.Size = new System.Drawing.Size(448, 51);
            this.ra_suggested_improvements.TabIndex = 610;
            this.ra_suggested_improvements.Text = "";
            // 
            // ra_commencement_reason
            // 
            this.ra_commencement_reason.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaCommencementReason", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_commencement_reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_commencement_reason.ForeColor = System.Drawing.Color.Black;
            this.ra_commencement_reason.Location = new System.Drawing.Point(128, 1377);
            this.ra_commencement_reason.MaxLength = 0;
            this.ra_commencement_reason.Name = "ra_commencement_reason";
            this.ra_commencement_reason.Size = new System.Drawing.Size(448, 49);
            this.ra_commencement_reason.TabIndex = 630;
            this.ra_commencement_reason.Text = "";
            // 
            // ra_route_reason
            // 
            this.ra_route_reason.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaRouteReason", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_route_reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_route_reason.ForeColor = System.Drawing.Color.Black;
            this.ra_route_reason.Location = new System.Drawing.Point(125, 1492);
            this.ra_route_reason.MaxLength = 0;
            this.ra_route_reason.Name = "ra_route_reason";
            this.ra_route_reason.Size = new System.Drawing.Size(448, 48);
            this.ra_route_reason.TabIndex = 660;
            this.ra_route_reason.Text = "";
            // 
            // t_1
            // 
            this.t_1.AutoSize = true;
            this.t_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_1.Location = new System.Drawing.Point(69, 49);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(61, 13);
            this.t_1.TabIndex = 791;
            this.t_1.Text = "Sort Time";
            // 
            // t_2
            // 
            this.t_2.AutoSize = true;
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_2.Location = new System.Drawing.Point(73, 113);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(64, 13);
            this.t_2.TabIndex = 792;
            this.t_2.Text = "Time Taken";
            // 
            // compute_2
            // 
            this.compute_2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.compute_2.Location = new System.Drawing.Point(147, 110);
            this.compute_2.Name = "compute_2";
            this.compute_2.ReadOnly = true;
            this.compute_2.Size = new System.Drawing.Size(48, 20);
            this.compute_2.TabIndex = 793;
            // 
            // t_3
            // 
            this.t_3.AutoSize = true;
            this.t_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_3.Location = new System.Drawing.Point(63, 134);
            this.t_3.Name = "t_3";
            this.t_3.Size = new System.Drawing.Size(76, 13);
            this.t_3.TabIndex = 794;
            this.t_3.Text = "Volume Sorted";
            // 
            // compute_1
            // 
            this.compute_1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.compute_1.Location = new System.Drawing.Point(147, 150);
            this.compute_1.Name = "compute_1";
            this.compute_1.ReadOnly = true;
            this.compute_1.Size = new System.Drawing.Size(60, 20);
            this.compute_1.TabIndex = 795;
            this.compute_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_1.DataBindings[0].FormatString = "#####";
            // 
            // t_4
            // 
            this.t_4.AutoSize = true;
            this.t_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_4.Location = new System.Drawing.Point(44, 150);
            this.t_4.Name = "t_4";
            this.t_4.Size = new System.Drawing.Size(96, 13);
            this.t_4.TabIndex = 796;
            this.t_4.Text = "Sort Rate per Hour";
            // 
            // t_5
            // 
            this.t_5.AutoSize = true;
            this.t_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_5.Location = new System.Drawing.Point(35, 175);
            this.t_5.Name = "t_5";
            this.t_5.Size = new System.Drawing.Size(102, 13);
            this.t_5.TabIndex = 797;
            this.t_5.Text = "Time on Delivery";
            // 
            // t_6
            // 
            this.t_6.AutoSize = true;
            this.t_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_6.Location = new System.Drawing.Point(240, 175);
            this.t_6.Name = "t_6";
            this.t_6.Size = new System.Drawing.Size(112, 13);
            this.t_6.TabIndex = 798;
            this.t_6.Text = "Odometer Reading";
            // 
            // compute_3
            // 
            this.compute_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_3.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Compute3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.compute_3.Location = new System.Drawing.Point(358, 233);
            this.compute_3.Name = "compute_3";
            this.compute_3.EditMask = "#######";
            this.compute_3.DataBindings[0].FormatString = "#####0.0";
            this.compute_3.InsertKeyMode = InsertKeyMode.Overwrite;
            this.compute_3.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            this.compute_3.PromptChar = ' ';
            this.compute_3.ReadOnly = true;
            this.compute_3.Size = new System.Drawing.Size(52, 13);
            this.compute_3.TabIndex = 799;
            this.compute_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_7
            // 
            this.t_7.AutoSize = true;
            this.t_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_7.Location = new System.Drawing.Point(49, 309);
            this.t_7.Name = "t_7";
            this.t_7.Size = new System.Drawing.Size(78, 13);
            this.t_7.TabIndex = 800;
            this.t_7.Text = "Other Goods";
            // 
            // t_8
            // 
            this.t_8.AutoSize = true;
            this.t_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_8.Location = new System.Drawing.Point(265, 309);
            this.t_8.Name = "t_8";
            this.t_8.Size = new System.Drawing.Size(76, 13);
            this.t_8.TabIndex = 801;
            this.t_8.Text = "Piece Rates";
            // 
            // t_9
            // 
            this.t_9.AutoSize = true;
            this.t_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_9.Location = new System.Drawing.Point(353, 310);
            this.t_9.Name = "t_9";
            this.t_9.Size = new System.Drawing.Size(84, 13);
            this.t_9.TabIndex = 802;
            this.t_9.Text = "(Courier/adPost)";
            // 
            // t_10
            // 
            this.t_10.AutoSize = true;
            this.t_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_10.Location = new System.Drawing.Point(40, 384);
            this.t_10.Name = "t_10";
            this.t_10.Size = new System.Drawing.Size(108, 13);
            this.t_10.TabIndex = 803;
            this.t_10.Text = "Details of Service";
            // 
            // t_11
            // 
            this.t_11.AutoSize = true;
            this.t_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_11.Location = new System.Drawing.Point(40, 461);
            this.t_11.Name = "t_11";
            this.t_11.Size = new System.Drawing.Size(151, 13);
            this.t_11.TabIndex = 804;
            this.t_11.Text = "Transport Mode/ Licence";
            // 
            // t_12
            // 
            this.t_12.AutoSize = true;
            this.t_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_12.Location = new System.Drawing.Point(56, 479);
            this.t_12.Name = "t_12";
            this.t_12.Size = new System.Drawing.Size(72, 13);
            this.t_12.TabIndex = 805;
            this.t_12.Text = "Vehicle Make";
            // 
            // t_15
            // 
            this.t_15.AutoSize = true;
            this.t_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_15.Location = new System.Drawing.Point(20, 496);
            this.t_15.Name = "t_15";
            this.t_15.Size = new System.Drawing.Size(103, 13);
            this.t_15.TabIndex = 806;
            this.t_15.Text = "Registration Number";
            // 
            // t_18
            // 
            this.t_18.AutoSize = true;
            this.t_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_18.Location = new System.Drawing.Point(80, 514);
            this.t_18.Name = "t_18";
            this.t_18.Size = new System.Drawing.Size(51, 13);
            this.t_18.TabIndex = 807;
            this.t_18.Text = "Condition";
            // 
            // t_20
            // 
            this.t_20.AutoSize = true;
            this.t_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_20.Location = new System.Drawing.Point(28, 534);
            this.t_20.Name = "t_20";
            this.t_20.Size = new System.Drawing.Size(96, 13);
            this.t_20.TabIndex = 808;
            this.t_20.Text = "Rec. Replacement";
            // 
            // t_13
            // 
            this.t_13.AutoSize = true;
            this.t_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_13.Location = new System.Drawing.Point(260, 481);
            this.t_13.Name = "t_13";
            this.t_13.Size = new System.Drawing.Size(36, 13);
            this.t_13.TabIndex = 809;
            this.t_13.Text = "Model";
            // 
            // t_16
            // 
            this.t_16.AutoSize = true;
            this.t_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_16.Location = new System.Drawing.Point(271, 497);
            this.t_16.Name = "t_16";
            this.t_16.Size = new System.Drawing.Size(27, 13);
            this.t_16.TabIndex = 810;
            this.t_16.Text = "Fuel";
            // 
            // t_19
            // 
            this.t_19.AutoSize = true;
            this.t_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_19.Location = new System.Drawing.Point(264, 514);
            this.t_19.Name = "t_19";
            this.t_19.Size = new System.Drawing.Size(33, 13);
            this.t_19.TabIndex = 811;
            this.t_19.Text = "Tyres";
            // 
            // t_14
            // 
            this.t_14.AutoSize = true;
            this.t_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_14.Location = new System.Drawing.Point(442, 481);
            this.t_14.Name = "t_14";
            this.t_14.Size = new System.Drawing.Size(29, 13);
            this.t_14.TabIndex = 812;
            this.t_14.Text = "Year";
            // 
            // t_17
            // 
            this.t_17.AutoSize = true;
            this.t_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_17.Location = new System.Drawing.Point(418, 499);
            this.t_17.Name = "t_17";
            this.t_17.Size = new System.Drawing.Size(53, 13);
            this.t_17.TabIndex = 813;
            this.t_17.Text = "cc Rating";
            // 
            // t_21
            // 
            this.t_21.AutoSize = true;
            this.t_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_21.Location = new System.Drawing.Point(345, 555);
            this.t_21.Name = "t_21";
            this.t_21.Size = new System.Drawing.Size(57, 13);
            this.t_21.TabIndex = 814;
            this.t_21.Text = "Insurance:";
            // 
            // t_22
            // 
            this.t_22.AutoSize = true;
            this.t_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_22.Location = new System.Drawing.Point(105, 643);
            this.t_22.Name = "t_22";
            this.t_22.Size = new System.Drawing.Size(79, 13);
            this.t_22.TabIndex = 815;
            this.t_22.Text = "Purchase Price";
            // 
            // t_23
            // 
            this.t_23.AutoSize = true;
            this.t_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_23.Location = new System.Drawing.Point(251, 643);
            this.t_23.Name = "t_23";
            this.t_23.Size = new System.Drawing.Size(90, 13);
            this.t_23.TabIndex = 816;
            this.t_23.Text = "Date of Purchase";
            // 
            // t_24
            // 
            this.t_24.AutoSize = true;
            this.t_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_24.Location = new System.Drawing.Point(19, 661);
            this.t_24.Name = "t_24";
            this.t_24.Size = new System.Drawing.Size(81, 13);
            this.t_24.TabIndex = 817;
            this.t_24.Text = "Mail Handled";
            // 
            // t_25
            // 
            this.t_25.AutoSize = true;
            this.t_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_25.Location = new System.Drawing.Point(35, 678);
            this.t_25.Name = "t_25";
            this.t_25.Size = new System.Drawing.Size(67, 13);
            this.t_25.TabIndex = 818;
            this.t_25.Text = "Mail Volume:";
            // 
            // t_26
            // 
            this.t_26.AutoSize = true;
            this.t_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_26.Location = new System.Drawing.Point(230, 678);
            this.t_26.Name = "t_26";
            this.t_26.Size = new System.Drawing.Size(47, 13);
            this.t_26.TabIndex = 819;
            this.t_26.Text = "Kiwimail:";
            // 
            // t_27
            // 
            this.t_27.AutoSize = true;
            this.t_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_27.Location = new System.Drawing.Point(385, 677);
            this.t_27.Name = "t_27";
            this.t_27.Size = new System.Drawing.Size(64, 13);
            this.t_27.TabIndex = 820;
            this.t_27.Text = "CourierPost:";
            // 
            // t_28
            // 
            this.t_28.AutoSize = true;
            this.t_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_28.Location = new System.Drawing.Point(224, 739);
            this.t_28.Name = "t_28";
            this.t_28.Size = new System.Drawing.Size(103, 13);
            this.t_28.TabIndex = 821;
            this.t_28.Text = "No. of Circular drops";
            // 
            // t_29
            // 
            this.t_29.AutoSize = true;
            this.t_29.Location = new System.Drawing.Point(26, 802);
            this.t_29.Name = "t_29";
            this.t_29.Size = new System.Drawing.Size(194, 13);
            this.t_29.TabIndex = 822;
            this.t_29.Text = "Delivery Points: On day of check";
            this.t_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // t_30
            // 
            this.t_30.AutoSize = true;
            this.t_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_30.Location = new System.Drawing.Point(73, 820);
            this.t_30.Name = "t_30";
            this.t_30.Size = new System.Drawing.Size(133, 13);
            this.t_30.TabIndex = 823;
            this.t_30.Text = "No. of Registed Customers";
            // 
            // t_31
            // 
            this.t_31.AutoSize = true;
            this.t_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_31.Location = new System.Drawing.Point(73, 840);
            this.t_31.Name = "t_31";
            this.t_31.Size = new System.Drawing.Size(290, 13);
            this.t_31.TabIndex = 824;
            this.t_31.Text = "No. of Registed Customers to whom core products delivered";
            // 
            // t_32
            // 
            this.t_32.AutoSize = true;
            this.t_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_32.Location = new System.Drawing.Point(73, 859);
            this.t_32.Name = "t_32";
            this.t_32.Size = new System.Drawing.Size(142, 13);
            this.t_32.TabIndex = 825;
            this.t_32.Text = "Other customers delivered to";
            // 
            // t_33
            // 
            this.t_33.AutoSize = true;
            this.t_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_33.Location = new System.Drawing.Point(73, 878);
            this.t_33.Name = "t_33";
            this.t_33.Size = new System.Drawing.Size(112, 13);
            this.t_33.TabIndex = 826;
            this.t_33.Text = "No Rural Private Bags";
            // 
            // t_34
            // 
            this.t_34.AutoSize = true;
            this.t_34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_34.Location = new System.Drawing.Point(73, 897);
            this.t_34.Name = "t_34";
            this.t_34.Size = new System.Drawing.Size(87, 13);
            this.t_34.TabIndex = 827;
            this.t_34.Text = "No. Private Bags";
            // 
            // t_35
            // 
            this.t_35.AutoSize = true;
            this.t_35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_35.Location = new System.Drawing.Point(73, 915);
            this.t_35.Name = "t_35";
            this.t_35.Size = new System.Drawing.Size(66, 13);
            this.t_35.TabIndex = 828;
            this.t_35.Text = "Closed Mails";
            // 
            // t_36
            // 
            this.t_36.AutoSize = true;
            this.t_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_36.Location = new System.Drawing.Point(73, 933);
            this.t_36.Name = "t_36";
            this.t_36.Size = new System.Drawing.Size(61, 13);
            this.t_36.TabIndex = 829;
            this.t_36.Text = "Post Shops";
            // 
            // t_37
            // 
            this.t_37.AutoSize = true;
            this.t_37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_37.Location = new System.Drawing.Point(73, 953);
            this.t_37.Name = "t_37";
            this.t_37.Size = new System.Drawing.Size(67, 13);
            this.t_37.TabIndex = 830;
            this.t_37.Text = "Post Centres";
            // 
            // t_38
            // 
            this.t_38.AutoSize = true;
            this.t_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_38.Location = new System.Drawing.Point(73, 973);
            this.t_38.Name = "t_38";
            this.t_38.Size = new System.Drawing.Size(90, 13);
            this.t_38.TabIndex = 831;
            this.t_38.Text = "No. of CMB nests";
            // 
            // t_39
            // 
            this.t_39.AutoSize = true;
            this.t_39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_39.Location = new System.Drawing.Point(73, 995);
            this.t_39.Name = "t_39";
            this.t_39.Size = new System.Drawing.Size(82, 13);
            this.t_39.TabIndex = 832;
            this.t_39.Text = "No. CMB Boxes";
            // 
            // t_40
            // 
            this.t_40.AutoSize = true;
            this.t_40.Location = new System.Drawing.Point(73, 1015);
            this.t_40.Name = "t_40";
            this.t_40.Size = new System.Drawing.Size(248, 13);
            this.t_40.TabIndex = 833;
            this.t_40.Text = "Total number of Rural Post Delivery Points";
            this.t_40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // compute_5
            // 
            this.compute_5.BackColor = System.Drawing.SystemColors.Control;
            this.compute_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.compute_5.Location = new System.Drawing.Point(394, 1015);
            this.compute_5.Name = "compute_5";
            this.compute_5.Size = new System.Drawing.Size(32, 13);
            this.compute_5.TabIndex = 834;
            // 
            // t_41
            // 
            this.t_41.AutoSize = true;
            this.t_41.Location = new System.Drawing.Point(28, 1028);
            this.t_41.Name = "t_41";
            this.t_41.Size = new System.Drawing.Size(101, 13);
            this.t_41.TabIndex = 835;
            this.t_41.Text = "Sorting Facilities";
            this.t_41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // t_42
            // 
            this.t_42.AutoSize = true;
            this.t_42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_42.Location = new System.Drawing.Point(52, 1044);
            this.t_42.Name = "t_42";
            this.t_42.Size = new System.Drawing.Size(60, 26);
            this.t_42.TabIndex = 836;
            this.t_42.Text = "Description\r\nAccom\r\n";
            // 
            // t_43
            // 
            this.t_43.AutoSize = true;
            this.t_43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_43.Location = new System.Drawing.Point(51, 1088);
            this.t_43.Name = "t_43";
            this.t_43.Size = new System.Drawing.Size(53, 13);
            this.t_43.TabIndex = 837;
            this.t_43.Text = "Sort Case";
            // 
            // t_44
            // 
            this.t_44.AutoSize = true;
            this.t_44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_44.Location = new System.Drawing.Point(51, 1109);
            this.t_44.Name = "t_44";
            this.t_44.Size = new System.Drawing.Size(56, 13);
            this.t_44.TabIndex = 838;
            this.t_44.Text = "Comments";
            // 
            // t_45
            // 
            this.t_45.AutoSize = true;
            this.t_45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_45.Location = new System.Drawing.Point(28, 1162);
            this.t_45.Name = "t_45";
            this.t_45.Size = new System.Drawing.Size(100, 13);
            this.t_45.TabIndex = 839;
            this.t_45.Text = "Road Conditions";
            // 
            // t_46
            // 
            this.t_46.AutoSize = true;
            this.t_46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_46.Location = new System.Drawing.Point(53, 1175);
            this.t_46.Name = "t_46";
            this.t_46.Size = new System.Drawing.Size(144, 13);
            this.t_46.TabIndex = 840;
            this.t_46.Text = "Total Length of Sealed Road";
            // 
            // t_47
            // 
            this.t_47.AutoSize = true;
            this.t_47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_47.Location = new System.Drawing.Point(53, 1193);
            this.t_47.Name = "t_47";
            this.t_47.Size = new System.Drawing.Size(156, 13);
            this.t_47.TabIndex = 841;
            this.t_47.Text = "Total Length of Unsealed Road";
            // 
            // t_48
            // 
            this.t_48.AutoSize = true;
            this.t_48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_48.Location = new System.Drawing.Point(53, 1209);
            this.t_48.Name = "t_48";
            this.t_48.Size = new System.Drawing.Size(138, 13);
            this.t_48.TabIndex = 842;
            this.t_48.Text = "Total KMs on Day of Check";
            // 
            // compute_6
            // 
            this.compute_6.BackColor = System.Drawing.SystemColors.Control;
            this.compute_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Compute6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.compute_6.Location = new System.Drawing.Point(216, 1207);
            this.compute_6.Name = "compute_6";
            this.compute_6.Size = new System.Drawing.Size(49, 13);
            this.compute_6.TabIndex = 843;
            this.compute_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // t_49
            // 
            this.t_49.AutoSize = true;
            this.t_49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_49.Location = new System.Drawing.Point(54, 1226);
            this.t_49.Name = "t_49";
            this.t_49.Size = new System.Drawing.Size(56, 13);
            this.t_49.TabIndex = 844;
            this.t_49.Text = "Comments";
            // 
            // t_50
            // 
            this.t_50.AutoSize = true;
            this.t_50.Location = new System.Drawing.Point(28, 1276);
            this.t_50.Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.t_50.Name = "t_50";
            this.t_50.Size = new System.Drawing.Size(149, 13);
            this.t_50.TabIndex = 845;
            this.t_50.Text = "Suggested Improvements";
            // 
            // t_51
            // 
            this.t_51.AutoSize = true;
            this.t_51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_51.Location = new System.Drawing.Point(53, 1292);
            this.t_51.Name = "t_51";
            this.t_51.Size = new System.Drawing.Size(68, 39);
            this.t_51.TabIndex = 846;
            this.t_51.Text = "Description\r\nof\r\nImprovement";
            // 
            // t_52
            // 
            this.t_52.AutoSize = true;
            this.t_52.Location = new System.Drawing.Point(28, 1346);
            this.t_52.Name = "t_52";
            this.t_52.Size = new System.Drawing.Size(123, 13);
            this.t_52.TabIndex = 847;
            this.t_52.Text = "Review of Timetable";
            this.t_52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // t_53
            // 
            this.t_53.AutoSize = true;
            this.t_53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_53.Location = new System.Drawing.Point(54, 1361);
            this.t_53.Name = "t_53";
            this.t_53.Size = new System.Drawing.Size(267, 13);
            this.t_53.TabIndex = 848;
            this.t_53.Text = "Was commencement time in accordance with timetable";
            // 
            // t_54
            // 
            this.t_54.AutoSize = true;
            this.t_54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_54.Location = new System.Drawing.Point(51, 1377);
            this.t_54.Name = "t_54";
            this.t_54.Size = new System.Drawing.Size(44, 26);
            this.t_54.TabIndex = 849;
            this.t_54.Text = "Reason\r\nif Not";
            // 
            // t_55
            // 
            this.t_55.AutoSize = true;
            this.t_55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_55.Location = new System.Drawing.Point(53, 1432);
            this.t_55.Name = "t_55";
            this.t_55.Size = new System.Drawing.Size(171, 13);
            this.t_55.TabIndex = 850;
            this.t_55.Text = "Does the timetable need amending";
            // 
            // t_56
            // 
            this.t_56.AutoSize = true;
            this.t_56.Location = new System.Drawing.Point(29, 1447);
            this.t_56.Name = "t_56";
            this.t_56.Size = new System.Drawing.Size(170, 13);
            this.t_56.TabIndex = 851;
            this.t_56.Text = "Review of Route Description";
            this.t_56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // t_57
            // 
            this.t_57.AutoSize = true;
            this.t_57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_57.Location = new System.Drawing.Point(49, 1466);
            this.t_57.Name = "t_57";
            this.t_57.Size = new System.Drawing.Size(310, 13);
            this.t_57.TabIndex = 852;
            this.t_57.Text = "Was delivery undertaken with accordance with route description";
            // 
            // t_58
            // 
            this.t_58.AutoSize = true;
            this.t_58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_58.Location = new System.Drawing.Point(50, 1493);
            this.t_58.Name = "t_58";
            this.t_58.Size = new System.Drawing.Size(44, 26);
            this.t_58.TabIndex = 853;
            this.t_58.Text = "Reason\r\nif Not";
            // 
            // t_59
            // 
            this.t_59.AutoSize = true;
            this.t_59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_59.Location = new System.Drawing.Point(47, 1548);
            this.t_59.Name = "t_59";
            this.t_59.Size = new System.Drawing.Size(204, 13);
            this.t_59.TabIndex = 854;
            this.t_59.Text = "Were any deviations made during delivery";
            // 
            // t_60
            // 
            this.t_60.AutoSize = true;
            this.t_60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_60.Location = new System.Drawing.Point(45, 1568);
            this.t_60.Name = "t_60";
            this.t_60.Size = new System.Drawing.Size(217, 13);
            this.t_60.TabIndex = 855;
            this.t_60.Text = "If yes, are these included in route description";
            // 
            // compute_4
            // 
            this.compute_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_4.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Compute4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.compute_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.compute_4.Location = new System.Drawing.Point(358, 290);
            this.compute_4.Name = "compute_4";
            this.compute_4.EditMask = "#####0.0";
            this.compute_4.DataBindings[0].FormatString = "#####0.0";
            this.compute_4.InsertKeyMode = InsertKeyMode.Overwrite;
            this.compute_4.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            this.compute_4.PromptChar = ' ';
            this.compute_4.ReadOnly = true;
            this.compute_4.Size = new System.Drawing.Size(53, 13);
            this.compute_4.TabIndex = 866;
            this.compute_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Location = new System.Drawing.Point(108, 667);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(87, 66);
            this.panel1.TabIndex = 867;
            this.panel1.BorderStyle = BorderStyle.None;
            this.panel1.TabStop = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaMailVolume3", true));
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton3.Location = new System.Drawing.Point(10, 45);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(65, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Average";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaMailVolume2", true));
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton2.Location = new System.Drawing.Point(27, 28);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton2.Size = new System.Drawing.Size(48, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Light";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaMailVolume1", true));
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.Location = new System.Drawing.Point(19, 11);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(56, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Heavy";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton6);
            this.panel2.Controls.Add(this.radioButton5);
            this.panel2.Controls.Add(this.radioButton4);
            this.panel2.Location = new System.Drawing.Point(277, 667);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(86, 66);
            this.panel2.TabIndex = 868;
            this.panel2.BorderStyle = BorderStyle.None;
            this.panel2.TabStop = false;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton6.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaAdpostVolume3", true));
            this.radioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton6.Location = new System.Drawing.Point(8, 45);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(65, 17);
            this.radioButton6.TabIndex = 2;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Average";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton5.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaAdpostVolume2", true));
            this.radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton5.Location = new System.Drawing.Point(25, 28);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(48, 17);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Light";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton4.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaAdpostVolume1", true));
            this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton4.Location = new System.Drawing.Point(17, 11);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(56, 17);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Heavy";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioButton9);
            this.panel3.Controls.Add(this.radioButton8);
            this.panel3.Controls.Add(this.radioButton7);
            this.panel3.Location = new System.Drawing.Point(455, 667);
            this.panel3.Name = "panel3";
            this.panel3.BorderStyle = BorderStyle.None;
            this.panel3.Size = new System.Drawing.Size(85, 66);
            this.panel3.TabIndex = 869;
            this.panel3.TabStop = false;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton9.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaCourierpostVolume3", true));
            this.radioButton9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton9.Location = new System.Drawing.Point(9, 43);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(65, 17);
            this.radioButton9.TabIndex = 2;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "Average";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton8.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaCourierpostVolume2", true));
            this.radioButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton8.Location = new System.Drawing.Point(26, 28);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(48, 17);
            this.radioButton8.TabIndex = 1;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Light";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton7.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaCourierpostVolume1", true));
            this.radioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton7.Location = new System.Drawing.Point(18, 10);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(56, 17);
            this.radioButton7.TabIndex = 0;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Heavy";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.radioButton11);
            this.panel4.Controls.Add(this.radioButton10);
            this.panel4.Location = new System.Drawing.Point(329, 1346);
            this.panel4.Name = "panel4";
            this.panel4.BorderStyle = BorderStyle.None;
            this.panel4.Size = new System.Drawing.Size(112, 28);
            this.panel4.TabIndex = 870;
            this.panel4.TabStop = false;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton11.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaCommencementOk2", true));
            this.radioButton11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton11.Location = new System.Drawing.Point(64, 9);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(39, 17);
            this.radioButton11.TabIndex = 1;
            this.radioButton11.TabStop = true;
            this.radioButton11.Text = "No";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton10.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaCommencementOk1", true));
            this.radioButton10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton10.Location = new System.Drawing.Point(6, 9);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(43, 17);
            this.radioButton10.TabIndex = 0;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "Yes";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.radioButton13);
            this.panel5.Controls.Add(this.radioButton12);
            this.panel5.Location = new System.Drawing.Point(333, 1424);
            this.panel5.Name = "panel5";
            this.panel5.BorderStyle = BorderStyle.None;
            this.panel5.Size = new System.Drawing.Size(112, 28);
            this.panel5.TabIndex = 871;
            this.panel5.TabStop = false;
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton13.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaTimetableChange2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton13.Location = new System.Drawing.Point(64, 9);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(39, 17);
            this.radioButton13.TabIndex = 1;
            this.radioButton13.TabStop = true;
            this.radioButton13.Text = "No";
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton12.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaTimetableChange1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton12.Location = new System.Drawing.Point(6, 9);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(43, 17);
            this.radioButton12.TabIndex = 0;
            this.radioButton12.TabStop = true;
            this.radioButton12.Text = "Yes";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.radioButton15);
            this.panel6.Controls.Add(this.radioButton14);
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel6.Location = new System.Drawing.Point(390, 1456);
            this.panel6.Name = "panel6";
            this.panel6.BorderStyle = BorderStyle.None;
            this.panel6.Size = new System.Drawing.Size(116, 33);
            this.panel6.TabIndex = 872;
            this.panel6.TabStop = false;
            // 
            // radioButton15
            // 
            this.radioButton15.AutoSize = true;
            this.radioButton15.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton15.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaRouteOk2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton15.Location = new System.Drawing.Point(65, 10);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(39, 17);
            this.radioButton15.TabIndex = 1;
            this.radioButton15.TabStop = true;
            this.radioButton15.Text = "No";
            this.radioButton15.UseVisualStyleBackColor = true;
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaRouteOk1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton14.Location = new System.Drawing.Point(6, 10);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton14.Size = new System.Drawing.Size(43, 17);
            this.radioButton14.TabIndex = 0;
            this.radioButton14.TabStop = true;
            this.radioButton14.Text = "Yes";
            this.radioButton14.UseVisualStyleBackColor = true;
            // 
            // radioButton16
            // 
            this.radioButton16.AutoSize = true;
            this.radioButton16.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton16.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaDeviations1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton16.Location = new System.Drawing.Point(6, 8);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(43, 17);
            this.radioButton16.TabIndex = 0;
            this.radioButton16.TabStop = true;
            this.radioButton16.Text = "Yes";
            this.radioButton16.UseVisualStyleBackColor = true;
            // 
            // radioButton17
            // 
            this.radioButton17.AutoSize = true;
            this.radioButton17.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton17.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaDeviations2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton17.Location = new System.Drawing.Point(72, 8);
            this.radioButton17.Name = "radioButton17";
            this.radioButton17.Size = new System.Drawing.Size(39, 17);
            this.radioButton17.TabIndex = 1;
            this.radioButton17.TabStop = true;
            this.radioButton17.Text = "No";
            this.radioButton17.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.radioButton17);
            this.panel7.Controls.Add(this.radioButton16);
            this.panel7.Location = new System.Drawing.Point(268, 1539);
            this.panel7.Name = "panel7";
            this.panel7.BorderStyle = BorderStyle.None;
            this.panel7.Size = new System.Drawing.Size(122, 27);
            this.panel7.TabIndex = 873;
            this.panel7.TabStop = false;
            // 
            // ra_safty_practices_resolved_date
            // 
            this.ra_safty_practices_resolved_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaSaftyPracticesResolvedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_safty_practices_resolved_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_safty_practices_resolved_date.Location = new System.Drawing.Point(116, 2066);
            this.ra_safty_practices_resolved_date.Mask = "00/00/00";
            this.ra_safty_practices_resolved_date.PromptChar = '0';
            this.ra_safty_practices_resolved_date.Name = "ra_safty_practices_resolved_date";
            this.ra_safty_practices_resolved_date.Size = new System.Drawing.Size(58, 20);
            this.ra_safty_practices_resolved_date.TabIndex = 790;
            this.ra_safty_practices_resolved_date.ValidatingType = typeof(System.DateTime);
            this.ra_safty_practices_resolved_date.DataBindings[0].FormatString = "dd/MM/yy";
            this.ra_safty_practices_resolved_date.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_safty_practices_resolved_date.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_safty_practices_actions
            // 
            this.ra_safty_practices_actions.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaSaftyPracticesActions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_safty_practices_actions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_safty_practices_actions.ForeColor = System.Drawing.Color.Black;
            this.ra_safty_practices_actions.Location = new System.Drawing.Point(94, 2005);
            this.ra_safty_practices_actions.MaxLength = 200;
            this.ra_safty_practices_actions.Name = "ra_safty_practices_actions";
            this.ra_safty_practices_actions.Size = new System.Drawing.Size(478, 57);
            this.ra_safty_practices_actions.TabIndex = 780;
            this.ra_safty_practices_actions.Text = "";
            // 
            // ra_safty_plan_completed_date
            // 
            this.ra_safty_plan_completed_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaSaftyPlanCompletedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_safty_plan_completed_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_safty_plan_completed_date.Location = new System.Drawing.Point(124, 1920);
            this.ra_safty_plan_completed_date.Mask = "00/00/00";
            this.ra_safty_plan_completed_date.PromptChar = '0';
            this.ra_safty_plan_completed_date.Name = "ra_safty_plan_completed_date";
            this.ra_safty_plan_completed_date.Size = new System.Drawing.Size(58, 20);
            this.ra_safty_plan_completed_date.TabIndex = 760;
            this.ra_safty_plan_completed_date.ValidatingType = typeof(System.DateTime);
            this.ra_safty_plan_completed_date.DataBindings[0].FormatString = "dd/MM/yy";
            this.ra_safty_plan_completed_date.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_safty_plan_completed_date.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_safty_plan_actions
            // 
            this.ra_safty_plan_actions.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaSaftyPlanActions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_safty_plan_actions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_safty_plan_actions.ForeColor = System.Drawing.Color.Black;
            this.ra_safty_plan_actions.Location = new System.Drawing.Point(94, 1874);
            this.ra_safty_plan_actions.MaxLength = 200;
            this.ra_safty_plan_actions.Name = "ra_safty_plan_actions";
            this.ra_safty_plan_actions.Size = new System.Drawing.Size(478, 40);
            this.ra_safty_plan_actions.TabIndex = 750;
            this.ra_safty_plan_actions.Text = "";
            // 
            // ra_safty_access_resolved_date
            // 
            this.ra_safty_access_resolved_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaSaftyAccessResolvedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_safty_access_resolved_date.Location = new System.Drawing.Point(515, 1755);
            this.ra_safty_access_resolved_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ra_safty_access_resolved_date.Name = "ra_safty_access_resolved_date";
            this.ra_safty_access_resolved_date.Size = new System.Drawing.Size(58, 20);
            this.ra_safty_access_resolved_date.TabIndex = 730;
            this.ra_safty_access_resolved_date.Mask = "00/00/00";
            this.ra_safty_access_resolved_date.PromptChar = '0';
            this.ra_safty_access_resolved_date.ValidatingType = typeof(System.DateTime);
            this.ra_safty_access_resolved_date.DataBindings[0].FormatString = "dd/MM/yy";
            this.ra_safty_access_resolved_date.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.ra_safty_access_resolved_date.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // ra_saftey_access_actions
            // 
            this.ra_saftey_access_actions.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaSafteyAccessActions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_saftey_access_actions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_saftey_access_actions.ForeColor = System.Drawing.Color.Black;
            this.ra_saftey_access_actions.Location = new System.Drawing.Point(128, 1755);
            this.ra_saftey_access_actions.MaxLength = 200;
            this.ra_saftey_access_actions.Name = "ra_saftey_access_actions";
            this.ra_saftey_access_actions.Size = new System.Drawing.Size(280, 53);
            this.ra_saftey_access_actions.TabIndex = 720;
            this.ra_saftey_access_actions.Text = "";
            // 
            // ra_safty_access_addresses
            // 
            this.ra_safty_access_addresses.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaSaftyAccessAddresses", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_safty_access_addresses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_safty_access_addresses.ForeColor = System.Drawing.Color.Black;
            this.ra_safty_access_addresses.Location = new System.Drawing.Point(51, 1699);
            this.ra_safty_access_addresses.MaxLength = 200;
            this.ra_safty_access_addresses.Name = "ra_safty_access_addresses";
            this.ra_safty_access_addresses.Size = new System.Drawing.Size(522, 50);
            this.ra_safty_access_addresses.TabIndex = 710;
            this.ra_safty_access_addresses.Text = "";
            // 
            // ra_deviation_reason
            // 
            this.ra_deviation_reason.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "RaDeviationReason", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ra_deviation_reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ra_deviation_reason.ForeColor = System.Drawing.Color.Black;
            this.ra_deviation_reason.Location = new System.Drawing.Point(123, 1598);
            this.ra_deviation_reason.MaxLength = 0;
            this.ra_deviation_reason.Name = "ra_deviation_reason";
            this.ra_deviation_reason.Size = new System.Drawing.Size(448, 53);
            this.ra_deviation_reason.TabIndex = 690;
            this.ra_deviation_reason.Text = "";
            // 
            // t_61
            // 
            this.t_61.AutoSize = true;
            this.t_61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_61.Location = new System.Drawing.Point(46, 1601);
            this.t_61.Name = "t_61";
            this.t_61.Size = new System.Drawing.Size(44, 26);
            this.t_61.TabIndex = 856;
            this.t_61.Text = "Reason\r\nif Not";
            // 
            // t_62
            // 
            this.t_62.AutoSize = true;
            this.t_62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_62.Location = new System.Drawing.Point(43, 1654);
            this.t_62.Name = "t_62";
            this.t_62.Size = new System.Drawing.Size(189, 13);
            this.t_62.TabIndex = 857;
            this.t_62.Text = "Does route description need amending";
            // 
            // t_63
            // 
            this.t_63.AutoSize = true;
            this.t_63.Location = new System.Drawing.Point(28, 1669);
            this.t_63.Name = "t_63";
            this.t_63.Size = new System.Drawing.Size(181, 13);
            this.t_63.TabIndex = 858;
            this.t_63.Text = "Review of Mailboxes and Sites";
            this.t_63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            // 
            // t_64
            // 
            this.t_64.AutoSize = true;
            this.t_64.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_64.Location = new System.Drawing.Point(46, 1683);
            this.t_64.Name = "t_64";
            this.t_64.Size = new System.Drawing.Size(305, 13);
            this.t_64.TabIndex = 859;
            this.t_64.Text = "List addresses where improvement required for access or safety";
            // 
            // t_65
            // 
            this.t_65.AutoSize = true;
            this.t_65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_65.Location = new System.Drawing.Point(49, 1755);
            this.t_65.Name = "t_65";
            this.t_65.Size = new System.Drawing.Size(67, 26);
            this.t_65.TabIndex = 860;
            this.t_65.Text = "Action taken\r\n to resolve";
            // 
            // t_66
            // 
            this.t_66.AutoSize = true;
            this.t_66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_66.Location = new System.Drawing.Point(427, 1755);
            this.t_66.Name = "t_66";
            this.t_66.Size = new System.Drawing.Size(82, 26);
            this.t_66.TabIndex = 861;
            this.t_66.Text = "Date access or \r\nsafety resolved";
            // 
            // t_67
            // 
            this.t_67.AutoSize = true;
            this.t_67.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_67.Location = new System.Drawing.Point(44, 1811);
            this.t_67.Name = "t_67";
            this.t_67.Size = new System.Drawing.Size(236, 13);
            this.t_67.TabIndex = 862;
            this.t_67.Text = "Does Owner Driver have Health and Safety Plan";
            // 
            // t_68
            // 
            this.t_68.AutoSize = true;
            this.t_68.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_68.Location = new System.Drawing.Point(43, 1923);
            this.t_68.Name = "t_68";
            this.t_68.Size = new System.Drawing.Size(82, 13);
            this.t_68.TabIndex = 863;
            this.t_68.Text = "Date completed";
            // 
            // t_69
            // 
            this.t_69.AutoSize = true;
            this.t_69.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_69.Location = new System.Drawing.Point(44, 1943);
            this.t_69.Name = "t_69";
            this.t_69.Size = new System.Drawing.Size(259, 13);
            this.t_69.TabIndex = 864;
            this.t_69.Text = "Does Owner Driver operate using safe work practices";
            // 
            // t_70
            // 
            this.t_70.AutoSize = true;
            this.t_70.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_70.Location = new System.Drawing.Point(43, 2070);
            this.t_70.Name = "t_70";
            this.t_70.Size = new System.Drawing.Size(73, 13);
            this.t_70.TabIndex = 865;
            this.t_70.Text = "Date resolved";
            // 
            // radioButton18
            // 
            this.radioButton18.AutoSize = true;
            this.radioButton18.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton18.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaDeviationInDesc1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton18.Location = new System.Drawing.Point(6, 10);
            this.radioButton18.Name = "radioButton18";
            this.radioButton18.Size = new System.Drawing.Size(43, 17);
            this.radioButton18.TabIndex = 0;
            this.radioButton18.TabStop = true;
            this.radioButton18.Text = "Yes";
            this.radioButton18.UseVisualStyleBackColor = true;
            // 
            // radioButton19
            // 
            this.radioButton19.AutoSize = true;
            this.radioButton19.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton19.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaDeviationInDesc2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton19.Location = new System.Drawing.Point(72, 10);
            this.radioButton19.Name = "radioButton19";
            this.radioButton19.Size = new System.Drawing.Size(39, 17);
            this.radioButton19.TabIndex = 1;
            this.radioButton19.TabStop = true;
            this.radioButton19.Text = "No";
            this.radioButton19.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.radioButton19);
            this.panel8.Controls.Add(this.radioButton18);
            this.panel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel8.Location = new System.Drawing.Point(268, 1563);
            this.panel8.Name = "panel8";
            this.panel8.BorderStyle = BorderStyle.None;
            this.panel8.Size = new System.Drawing.Size(122, 33);
            this.panel8.TabIndex = 874;
            this.panel8.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.radioButton21);
            this.panel9.Controls.Add(this.radioButton20);
            this.panel9.Location = new System.Drawing.Point(268, 1650);
            this.panel9.Name = "panel9";
            this.panel9.BorderStyle = BorderStyle.None;
            this.panel9.Size = new System.Drawing.Size(122, 30);
            this.panel9.TabIndex = 875;
            this.panel9.TabStop = false;
            // 
            // radioButton21
            // 
            this.radioButton21.AutoSize = true;
            this.radioButton21.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton21.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaDescriptionUotdated2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton21.Location = new System.Drawing.Point(72, 7);
            this.radioButton21.Name = "radioButton21";
            this.radioButton21.Size = new System.Drawing.Size(39, 17);
            this.radioButton21.TabIndex = 1;
            this.radioButton21.TabStop = true;
            this.radioButton21.Text = "No";
            this.radioButton21.UseVisualStyleBackColor = true;
            // 
            // radioButton20
            // 
            this.radioButton20.AutoSize = true;
            this.radioButton20.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton20.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaDescriptionUotdated1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton20.Location = new System.Drawing.Point(6, 7);
            this.radioButton20.Name = "radioButton20";
            this.radioButton20.Size = new System.Drawing.Size(43, 17);
            this.radioButton20.TabIndex = 0;
            this.radioButton20.TabStop = true;
            this.radioButton20.Text = "Yes";
            this.radioButton20.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.radioButton23);
            this.panel10.Controls.Add(this.radioButton22);
            this.panel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel10.Location = new System.Drawing.Point(49, 1827);
            this.panel10.Name = "panel10";
            this.panel10.BorderStyle = BorderStyle.None;
            this.panel10.Size = new System.Drawing.Size(167, 48);
            this.panel10.TabIndex = 876;
            this.panel10.TabStop = false;
            // 
            // radioButton23
            // 
            this.radioButton23.AutoSize = true;
            this.radioButton23.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaSaftyPlanCompleted2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton23.Location = new System.Drawing.Point(7, 28);
            this.radioButton23.Name = "radioButton23";
            this.radioButton23.Size = new System.Drawing.Size(148, 17);
            this.radioButton23.TabIndex = 1;
            this.radioButton23.TabStop = true;
            this.radioButton23.Text = "No - Detail action required";
            this.radioButton23.UseVisualStyleBackColor = true;
            // 
            // radioButton22
            // 
            this.radioButton22.AutoSize = true;
            this.radioButton22.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaSaftyPlanCompleted1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton22.Location = new System.Drawing.Point(7, 9);
            this.radioButton22.Name = "radioButton22";
            this.radioButton22.Size = new System.Drawing.Size(121, 17);
            this.radioButton22.TabIndex = 0;
            this.radioButton22.TabStop = true;
            this.radioButton22.Text = "Yes (Copy attached)";
            this.radioButton22.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.radioButton25);
            this.panel11.Controls.Add(this.radioButton24);
            this.panel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel11.Location = new System.Drawing.Point(48, 1957);
            this.panel11.Name = "panel11";
            this.panel11.BorderStyle = BorderStyle.None;
            this.panel11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel11.Size = new System.Drawing.Size(269, 48);
            this.panel11.TabIndex = 877;
            this.panel11.TabStop = false;
            // 
            // radioButton25
            // 
            this.radioButton25.AutoSize = true;
            this.radioButton25.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton25.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaSaftyPracticesExists2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton25.Location = new System.Drawing.Point(8, 27);
            this.radioButton25.Name = "radioButton25";
            this.radioButton25.Size = new System.Drawing.Size(245, 17);
            this.radioButton25.TabIndex = 1;
            this.radioButton25.TabStop = true;
            this.radioButton25.Text = "No - Detail issue and action required to resolve";
            this.radioButton25.UseVisualStyleBackColor = true;
            // 
            // radioButton24
            // 
            this.radioButton24.AutoSize = true;
            this.radioButton24.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton24.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "RaSaftyPracticesExists1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioButton24.Location = new System.Drawing.Point(8, 8);
            this.radioButton24.Name = "radioButton24";
            this.radioButton24.Size = new System.Drawing.Size(76, 17);
            this.radioButton24.TabIndex = 0;
            this.radioButton24.TabStop = true;
            this.radioButton24.Text = "Yes (Initial) ";
            this.radioButton24.UseVisualStyleBackColor = true;
            // 
            // DRouteAuditDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.compute_4);
            this.Controls.Add(this.t_70);
            this.Controls.Add(this.t_69);
            this.Controls.Add(this.t_68);
            this.Controls.Add(this.t_67);
            this.Controls.Add(this.t_66);
            this.Controls.Add(this.t_65);
            this.Controls.Add(this.t_64);
            this.Controls.Add(this.t_63);
            this.Controls.Add(this.t_62);
            this.Controls.Add(this.t_61);
            this.Controls.Add(this.t_60);
            this.Controls.Add(this.t_59);
            this.Controls.Add(this.t_58);
            this.Controls.Add(this.t_57);
            this.Controls.Add(this.t_56);
            this.Controls.Add(this.t_55);
            this.Controls.Add(this.t_54);
            this.Controls.Add(this.t_53);
            this.Controls.Add(this.t_52);
            this.Controls.Add(this.t_51);
            this.Controls.Add(this.t_50);
            this.Controls.Add(this.t_49);
            this.Controls.Add(this.compute_6);
            this.Controls.Add(this.t_48);
            this.Controls.Add(this.t_47);
            this.Controls.Add(this.t_46);
            this.Controls.Add(this.t_45);
            this.Controls.Add(this.t_44);
            this.Controls.Add(this.t_43);
            this.Controls.Add(this.t_42);
            this.Controls.Add(this.t_41);
            this.Controls.Add(this.compute_5);
            this.Controls.Add(this.t_40);
            this.Controls.Add(this.t_39);
            this.Controls.Add(this.t_38);
            this.Controls.Add(this.t_37);
            this.Controls.Add(this.t_36);
            this.Controls.Add(this.t_35);
            this.Controls.Add(this.t_34);
            this.Controls.Add(this.t_33);
            this.Controls.Add(this.t_32);
            this.Controls.Add(this.t_31);
            this.Controls.Add(this.t_30);
            this.Controls.Add(this.t_29);
            this.Controls.Add(this.t_28);
            this.Controls.Add(this.t_27);
            this.Controls.Add(this.t_26);
            this.Controls.Add(this.t_25);
            this.Controls.Add(this.t_24);
            this.Controls.Add(this.t_23);
            this.Controls.Add(this.t_22);
            this.Controls.Add(this.t_21);
            this.Controls.Add(this.t_17);
            this.Controls.Add(this.t_14);
            this.Controls.Add(this.t_19);
            this.Controls.Add(this.t_16);
            this.Controls.Add(this.t_13);
            this.Controls.Add(this.t_20);
            this.Controls.Add(this.t_18);
            this.Controls.Add(this.t_15);
            this.Controls.Add(this.t_12);
            this.Controls.Add(this.t_11);
            this.Controls.Add(this.t_10);
            this.Controls.Add(this.t_9);
            this.Controls.Add(this.t_8);
            this.Controls.Add(this.t_7);
            this.Controls.Add(this.compute_3);
            this.Controls.Add(this.t_6);
            this.Controls.Add(this.t_5);
            this.Controls.Add(this.t_4);
            this.Controls.Add(this.compute_1);
            this.Controls.Add(this.t_3);
            this.Controls.Add(this.compute_2);
            this.Controls.Add(this.t_2);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.st_contract);
            this.Controls.Add(this.ra_volume);
            this.Controls.Add(this.ra_date_of_check_t);
            this.Controls.Add(this.ra_time_finished_sort_t);
            this.Controls.Add(this.ra_time_started_sort_t);
            this.Controls.Add(this.ra_date_of_check);
            this.Controls.Add(this.ra_time_finished_sort);
            this.Controls.Add(this.ra_time_started_sort);
            this.Controls.Add(this.ra_time_returned_t);
            this.Controls.Add(this.ra_time_returned);
            this.Controls.Add(this.ra_finish_odometer_t);
            this.Controls.Add(this.ra_finish_odometer);
            this.Controls.Add(this.ra_time_departed_t);
            this.Controls.Add(this.ra_time_departed);
            this.Controls.Add(this.ra_start_odometer_t);
            this.Controls.Add(this.ra_start_odometer);
            this.Controls.Add(this.ra_total_hours_t);
            this.Controls.Add(this.ra_total_hours);
            this.Controls.Add(this.ra_total_distance_t);
            this.Controls.Add(this.ra_meal_breaks_t);
            this.Controls.Add(this.ra_meal_breaks);
            this.Controls.Add(this.ra_extra_time_t);
            this.Controls.Add(this.ra_extra_time);
            this.Controls.Add(this.ra_extra_distance_t);
            this.Controls.Add(this.ra_extra_distance);
            this.Controls.Add(this.ra_final_hours_t);
            this.Controls.Add(this.ra_final_hours);
            this.Controls.Add(this.ra_final_distance_t);
            this.Controls.Add(this.ra_othr_gds_before_t);
            this.Controls.Add(this.ra_othr_gds_before);
            this.Controls.Add(this.ra_pr_before_t);
            this.Controls.Add(this.ra_pr_before);
            this.Controls.Add(this.ra_othr_gds_during_t);
            this.Controls.Add(this.ra_othr_gds_during);
            this.Controls.Add(this.ra_pr_during_t);
            this.Controls.Add(this.ra_pr_during);
            this.Controls.Add(this.ra_othr_gds_after_t);
            this.Controls.Add(this.ra_othr_gds_after);
            this.Controls.Add(this.ra_pr_after_t);
            this.Controls.Add(this.ra_pr_after);
            this.Controls.Add(this.ra_frequency_t);
            this.Controls.Add(this.ra_frequency);
            this.Controls.Add(this.ra_contractor_t);
            this.Controls.Add(this.ra_contractor);
            this.Controls.Add(this.ra_employee_t);
            this.Controls.Add(this.ra_employee);
            this.Controls.Add(this.ra_vehicle_make);
            this.Controls.Add(this.ra_vehicle_model);
            this.Controls.Add(this.ra_year);
            this.Controls.Add(this.ra_registration_no);
            this.Controls.Add(this.ra_fuel);
            this.Controls.Add(this.ra_cc_rating);
            this.Controls.Add(this.ra_condition);
            this.Controls.Add(this.ra_tyre_size);
            this.Controls.Add(this.ra_rec_replace);
            this.Controls.Add(this.ra_gds_service);
            this.Controls.Add(this.ra_mv_insurance);
            this.Controls.Add(this.ra_gds_service_sighted);
            this.Controls.Add(this.ra_cr_insurance);
            this.Controls.Add(this.ra_pl_insurance);
            this.Controls.Add(this.ra_insurance_sighted);
            this.Controls.Add(this.ra_new_vehicle);
            this.Controls.Add(this.ra_vehicle_price);
            this.Controls.Add(this.ra_vehicle_purchased);
            this.Controls.Add(this.ra_mv_comments);
            this.Controls.Add(this.ra_no_circular_drops);
            this.Controls.Add(this.ra_cp_comments);
            this.Controls.Add(this.ra_no_reg_custs);
            this.Controls.Add(this.ra_no_reg_custs_core_prods);
            this.Controls.Add(this.ra_other_custs);
            this.Controls.Add(this.ra_rural_private_bags);
            this.Controls.Add(this.ra_private_bags);
            this.Controls.Add(this.ra_closed_mails);
            this.Controls.Add(this.ra_post_shops);
            this.Controls.Add(this.ra_post_centres);
            this.Controls.Add(this.ra_no_cmbs);
            this.Controls.Add(this.ra_no_cmb_custs);
            this.Controls.Add(this.ra_sorting_facilities);
            this.Controls.Add(this.ra_sorting_case);
            this.Controls.Add(this.ra_sorting_comments);
            this.Controls.Add(this.ra_length_sealed);
            this.Controls.Add(this.ra_lenth_unsealed);
            this.Controls.Add(this.ra_road_conditions);
            this.Controls.Add(this.ra_suggested_improvements);
            this.Controls.Add(this.ra_commencement_reason);
            this.Controls.Add(this.ra_route_reason);
            this.Controls.Add(this.ra_deviation_reason);
            this.Controls.Add(this.ra_safty_access_addresses);
            this.Controls.Add(this.ra_saftey_access_actions);
            this.Controls.Add(this.ra_safty_access_resolved_date);
            this.Controls.Add(this.ra_safty_plan_actions);
            this.Controls.Add(this.ra_safty_plan_completed_date);
            this.Controls.Add(this.ra_safty_practices_actions);
            this.Controls.Add(this.ra_safty_practices_resolved_date);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Name = "DRouteAuditDe";
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Size = new System.Drawing.Size(596, 682);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
		}

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            
        }

        #endregion

        private Label t_1;
        private Label t_2;
        private TextBox compute_2;
        private Label t_3;
        private TextBox compute_1;
        private Label t_4;
        private Label t_5;
        private Label t_6;
        private NumericalMaskedTextBox compute_3;
        private Label t_7;
        private Label t_8;
        private Label t_9;
        private Label t_10;
        private Label t_11;
        private Label t_12;
        private Label t_15;
        private Label t_18;
        private Label t_20;
        private Label t_13;
        private Label t_16;
        private Label t_19;
        private Label t_14;
        private Label t_17;
        private Label t_21;
        private Label t_22;
        private Label t_23;
        private Label t_24;
        private Label t_25;
        private Label t_26;
        private Label t_27;
        private Label t_28;
        private Label t_29;
        private Label t_30;
        private Label t_31;
        private Label t_32;
        private Label t_33;
        private Label t_34;
        private Label t_35;
        private Label t_36;
        private Label t_37;
        private Label t_38;
        private Label t_39;
        private Label t_40;
        private TextBox compute_5;
        private Label t_41;
        private Label t_42;
        private Label t_43;
        private Label t_44;
        private Label t_45;
        private Label t_46;
        private Label t_47;
        private Label t_48;
        private TextBox compute_6;
        private Label t_49;
        private Label t_50;
        private Label t_51;
        private Label t_52;
        private Label t_53;
        private Label t_54;
        private Label t_55;
        private Label t_56;
        private Label t_57;
        private Label t_58;
        private Label t_59;
        private Label t_60;
        private NumericalMaskedTextBox compute_4;
        private Panel panel1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Panel panel2;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private Panel panel3;
        private RadioButton radioButton9;
        private RadioButton radioButton8;
        private RadioButton radioButton7;
        private Panel panel4;
        private RadioButton radioButton11;
        private RadioButton radioButton10;
        private Panel panel5;
        private RadioButton radioButton12;
        private RadioButton radioButton13;
        private Panel panel6;
        private RadioButton radioButton15;
        private RadioButton radioButton14;
        private RadioButton radioButton16;
        private RadioButton radioButton17;
        private Panel panel7;
        private MaskedTextBox ra_safty_practices_resolved_date;
        private RichTextBox ra_safty_practices_actions;
        private MaskedTextBox ra_safty_plan_completed_date;
        private RichTextBox ra_safty_plan_actions;
        private MaskedTextBox ra_safty_access_resolved_date;
        private RichTextBox ra_saftey_access_actions;
        private RichTextBox ra_safty_access_addresses;
        private RichTextBox ra_deviation_reason;
        private Label t_61;
        private Label t_62;
        private Label t_63;
        private Label t_64;
        private Label t_65;
        private Label t_66;
        private Label t_67;
        private Label t_68;
        private Label t_69;
        private Label t_70;
        private RadioButton radioButton18;
        private RadioButton radioButton19;
        private Panel panel8;
        private Panel panel9;
        private RadioButton radioButton21;
        private RadioButton radioButton20;
        private Panel panel10;
        private RadioButton radioButton23;
        private RadioButton radioButton22;
        private Panel panel11;
        private RadioButton radioButton24;
        private RadioButton radioButton25;
	}
}