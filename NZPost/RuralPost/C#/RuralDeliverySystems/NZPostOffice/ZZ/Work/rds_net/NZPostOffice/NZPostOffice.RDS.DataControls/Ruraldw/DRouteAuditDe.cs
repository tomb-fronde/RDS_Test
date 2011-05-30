using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DRouteAuditDe : Metex.Windows.DataUserControl
	{
		public DRouteAuditDe()
		{
			InitializeComponent();

            this.ra_date_of_check.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.ra_time_finished_sort.DataBindings[0].FormatString = "HH:mm";
            this.ra_time_finished_sort.ValidatingType = typeof(System.DateTime);
            this.ra_time_finished_sort.DataBindings[0].DataSourceNullValue = null;
            this.ra_time_started_sort.DataBindings[0].FormatString = "HH:mm";
            this.ra_time_started_sort.ValidatingType = typeof(System.DateTime);
            this.ra_time_started_sort.DataBindings[0].DataSourceNullValue = null;
            this.ra_time_returned.DataBindings[0].FormatString = "HH:mm";
            this.ra_time_returned.ValidatingType = typeof(System.DateTime);
            this.ra_time_departed.DataBindings[0].FormatString = "HH:mm";
            this.ra_time_departed.ValidatingType = typeof(System.DateTime);
            this.ra_total_hours.DataBindings[0].FormatString = "HH:mm";
            this.ra_total_hours.ValidatingType = typeof(System.DateTime);
            this.ra_meal_breaks.DataBindings[0].FormatString = "HH:mm";
            this.ra_meal_breaks.ValidatingType = typeof(System.DateTime);
            this.ra_extra_time.DataBindings[0].FormatString = "HH:mm";
            this.ra_extra_time.ValidatingType = typeof(System.DateTime);
            this.ra_final_hours.DataBindings[0].FormatString = "HH:mm";
            this.ra_final_hours.ValidatingType = typeof(System.DateTime);
            this.ra_start_odometer.DataBindings[0].FormatString = "######.0";
            this.ra_finish_odometer.DataBindings[0].FormatString = "######.0";
            this.ra_extra_distance.DataBindings[0].FormatString = "###.0";
            this.ra_fuel_used.DataBindings[0].FormatString = "###.0";
            this.ra_fuel_distance.DataBindings[0].FormatString = "###.0";
            this.compute_7.DataBindings[0].FormatString = "###.0";
            this.ra_othr_gds_before.DataBindings[0].FormatString = "HH:mm";
            this.ra_othr_gds_before.ValidatingType = typeof(System.DateTime);
            this.ra_pr_before.DataBindings[0].FormatString = "HH:mm";
            this.ra_pr_before.ValidatingType = typeof(System.DateTime);
            this.ra_othr_gds_during.DataBindings[0].FormatString = "HH:mm";
            this.ra_othr_gds_during.ValidatingType = typeof(System.DateTime);
            this.ra_pr_during.DataBindings[0].FormatString = "HH:mm";
            this.ra_pr_during.ValidatingType = typeof(System.DateTime);
            this.ra_othr_gds_after.DataBindings[0].FormatString = "HH:mm";
            this.ra_othr_gds_after.ValidatingType = typeof(System.DateTime);
            this.ra_pr_after.DataBindings[0].FormatString = "HH:mm";
            this.ra_pr_after.ValidatingType = typeof(System.DateTime);
		}

		public int Retrieve( int? contract, DateTime? auditdate )
		{
			return RetrieveCore<RouteAuditDe>(new List<RouteAuditDe>
				(RouteAuditDe.GetAllRouteAuditDe( contract, auditdate )));
		}
	}
}
