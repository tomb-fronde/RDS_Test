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
	public partial class DRenewal : Metex.Windows.DataUserControl
	{
		public DRenewal()
		{
			InitializeComponent();
			//InitializeDropdown();
            //this.con_renewal_payment_value.TextChanged += new System.EventHandler(this.con_renewal_payment_value_TextChanged);
            //this.con_renewal_benchmark_price.TextChanged += new System.EventHandler(this.con_renewal_benchmark_price_TextChanged);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }
            
            base.OnHandleCreated(e);
        }
		private void InitializeDropdown()
		{
			con_rg_code_at_renewal.AssignDropdownType<DDddwRenewalgroup>();
		}

		public int Retrieve( int? in_ContractNo, int? in_ContractSeq )
		{
			return RetrieveCore<Renewal>(new List<Renewal>
				(Renewal.GetAllRenewal( in_ContractNo, in_ContractSeq )));
		}

        public string getDisplayText(string field)
        {
            string temp = "";
            if (field == "con_renewal_benchmark_price")
                temp = this.con_renewal_benchmark_price.Text;
            else if (field == "con_renewal_payment_value")
                temp = this.con_renewal_payment_value.Text;
            else if (field == "con_volume_at_renewal")
                temp = this.con_volume_at_renewal.Text;
            else if (field == "con_distance_at_renewal")
                temp = this.con_distance_at_renewal.Text;
            else if (field == "con_processing_hours_per_week")
                temp = this.con_processing_hours_per_week.Text;
            else if (field == "con_del_hrs_week_at_renewal")
                temp = this.con_del_hrs_week_at_renewal.Text;
            return temp;
        }

        public string getDisplayEditMask(string field)
        {
            string temp = "";
            if (field == "con_renewal_benchmark_price")
                temp = this.con_renewal_benchmark_price.EditMask;
            else if (field == "con_renewal_payment_value")
                temp = this.con_renewal_payment_value.EditMask;
            else if (field == "con_volume_at_renewal")
                temp = this.con_volume_at_renewal.EditMask;
            else if (field == "con_distance_at_renewal")
                temp = this.con_distance_at_renewal.EditMask;
            else if (field == "con_processing_hours_per_week")
                temp = this.con_processing_hours_per_week.EditMask;
            else if (field == "con_del_hrs_week_at_renewal")
                temp = this.con_del_hrs_week_at_renewal.EditMask;
            return temp;
        }

        public void setDisplayEditMask(string field, string new_mask)
        {
            if (field == "con_renewal_benchmark_price")
                this.con_renewal_benchmark_price.EditMask = new_mask;
            else if (field == "con_renewal_payment_value")
                this.con_renewal_payment_value.EditMask = new_mask;
            else if (field == "con_volume_at_renewal")
                this.con_volume_at_renewal.EditMask = new_mask;
            else if (field == "con_distance_at_renewal")
                this.con_distance_at_renewal.EditMask = new_mask;
            else if (field == "con_processing_hours_per_week")
                this.con_processing_hours_per_week.EditMask = new_mask;
            else if (field == "con_del_hrs_week_at_renewal")
                this.con_del_hrs_week_at_renewal.EditMask = new_mask;
        }

        public void setDisplayText(string field, string val)
        {
            if (field == "con_renewal_benchmark_price")
                this.con_renewal_benchmark_price.Text = val;
            else if (field == "con_renewal_payment_value")
                this.con_renewal_payment_value.Text = val;
            else if (field == "con_volume_at_renewal")
                this.con_volume_at_renewal.Text = val;
            else if (field == "con_distance_at_renewal")
                this.con_distance_at_renewal.Text = val;
            else if (field == "con_processing_hours_per_week")
                this.con_processing_hours_per_week.Text = val;
            else if (field == "con_volume_at_renewal")
                this.con_del_hrs_week_at_renewal.Text = val;
        }

        private void con_renewal_benchmark_price_TextChanged(object sender, EventArgs e)
        {
            string val_text = this.con_renewal_benchmark_price.Text;
            string val_mask = this.con_renewal_benchmark_price.Mask;
            string val_value = this.con_renewal_benchmark_price.Value;
            string val_value1 = val_value;
            string msg = "TryParse worked";
            decimal bm_value = 0.00M;
            string new_text = "";
            if (val_value1.StartsWith("$"))
            {
                val_value1 = val_value1.Substring(1);
            }
            if (decimal.TryParse(val_value1, out bm_value))
            {
                msg = "TryParse worked";
                if (val_mask.EndsWith(".00") && val_value.EndsWith(".0"))
                {
                    bm_value = bm_value * 0.1M;
                }
                new_text = bm_value.ToString(val_mask);
                //if (new_text != val_text)
                //{
                //    this.con_renewal_benchmark_price.Text = new_text;
                //}
            }
            else
            {
                msg = "TryParse failed";
            }
            MessageBox.Show("con_renewal_benchmark_price.Text = " + val_text + "\n"
                           + "con_renewal_benchmark_price.Mask = " + val_mask + "\n"
                           + "con_renewal_benchmark_price.Value = " + val_value + "\n"
                           + msg + "\n"
                           + "bm_value = " + bm_value.ToString() + "\n"
                           + "new_value = " + new_text
                           , "con_renewal_benchmark_price_TextChanged");
        }

        private void con_renewal_payment_value_TextChanged(object sender, EventArgs e)
        {
            string val_text = this.con_renewal_payment_value.Text;
            string val_mask = con_renewal_payment_value.Mask;
            string val_value = con_renewal_payment_value.Value;
            //MessageBox.Show("con_renewal_payment_value.Text = " + val_text + "\n"
            //               + "con_renewal_payment_value.Mask = " + val_mask + "\n"
            //               + "con_renewal_payment_value.Value = " + val_value
            //               , "con_renewal_payment_value_TextChanged");
        }
    }
}
