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
    // TJB  Frequencies & Vehicles  9-Feb-2021
    // Changed TextMaskFormat property on purchased_date
    //
    // TJB  Frequencies & Vehicles  Jan-2021
    // Added Active and Default Vehicle checkboxes (in design)

    public partial class DContractVehicleTest : Metex.Windows.DataUserControl
    {
        private bool[] safety_filled = new bool[6];
        private Button[] star = new Button[6];

        public DContractVehicleTest()
        {
            InitializeComponent();
//            this.v_vehicle_registration_number.Click += new System.EventHandler(this.v_vehicle_registration_number_Click);
//            this.v_vehicle_registration_number.Leave += new System.EventHandler(this.v_vehicle_registration_number_Leave);

            Consumption.DataBindings[0].FormatString = "###.0";
            this.v_purchase_value.DataBindings[0].FormatString = "$###,##0";
            this.v_salvage_value.DataBindings[0].FormatString = "$###,##0";
            this.contract_vehical_start_kms.DataBindings[0].FormatString = "###,##0";
            this.v_vehicle_speedo_kms.DataBindings[0].FormatString = "###,##0";
            this.v_remaining_economic_life.DataBindings[0].FormatString = "###,##0";

            // TJB  Dec-2009:  Test using stars to display Vehicle Safety Rating
            //  - For testing, use vehicle year to determine the number of stars
            Safety1.Click += new EventHandler(Safety1_Click);
            Safety2.Click += new EventHandler(Safety2_Click);
            Safety3.Click += new EventHandler(Safety3_Click);
            Safety4.Click += new EventHandler(Safety4_Click);
            Safety5.Click += new EventHandler(Safety5_Click);
            Safety_t.Click += new System.EventHandler(this.Safety_t_Click);

            initialize_stars();

            InitializeDropdown();
        }

        private void InitializeDropdown()
        {
            ft_key.AssignDropdownType<DDddwFuewTypes>();
            vt_key.AssignDropdownType<DDddwVehicalTypes>();
            vs_key.AssignDropdownType<DDddwVehicalStyles>();

            #region vehicle_v_vehicle_month
            System.Data.DataTable sourceTable1 = new System.Data.DataTable();
            sourceTable1.Columns.AddRange(new System.Data.DataColumn[]
			{
				new System.Data.DataColumn("Display", typeof(string)),
				new System.Data.DataColumn("Value", typeof(string))
			});
            sourceTable1.Rows.Add(new object[] { "January", "1" });
            sourceTable1.Rows.Add(new object[] { "February", "2" });
            sourceTable1.Rows.Add(new object[] { "March", "3" });
            sourceTable1.Rows.Add(new object[] { "April", "4" });
            sourceTable1.Rows.Add(new object[] { "May", "5" });
            sourceTable1.Rows.Add(new object[] { "June", "6" });
            sourceTable1.Rows.Add(new object[] { "July", "7" });
            sourceTable1.Rows.Add(new object[] { "August", "8" });
            sourceTable1.Rows.Add(new object[] { "September", "9" });
            sourceTable1.Rows.Add(new object[] { "October", "10" });
            sourceTable1.Rows.Add(new object[] { "November", "11" });
            sourceTable1.Rows.Add(new object[] { "December", "12" });
            this.v_vehicle_month.DataSource = sourceTable1;
            this.v_vehicle_month.DisplayMember = "Display";
            this.v_vehicle_month.ValueMember = "Value";
            #endregion
        }

        public int Retrieve(int? contract_no, int? contract_seq_number)
        {
            return RetrieveCore<ContractVehicle>(new List<ContractVehicle>
                (ContractVehicle.GetAllContractVehicle(contract_no, contract_seq_number)));
        }

        #region extraprocessing
        // TJB  Dec-2009:  Safety-stars prototype
        //  Test using stars to display Vehicle Safety Rating
        //  - For testing, use vehicle year to determine the number of stars
        void Safety1_Click(object sender, EventArgs e)
        {
            if (safety_filled[1] && safety_filled[2])
                set_stars(1);
            else if (safety_filled[1] && ! safety_filled[2])
                set_stars(0);
            else if (!safety_filled[1])
                set_stars(1);
        }

        void Safety2_Click(object sender, EventArgs e)
        {
            set_stars(2);
        }

        void Safety3_Click(object sender, EventArgs e)
        {
            set_stars(3);
        }

        void Safety4_Click(object sender, EventArgs e)
        {
            set_stars(4);
        }

        void Safety5_Click(object sender, EventArgs e)
        {
            set_stars(5);
        }

        private void initialize_stars()
        {
            for (int i = 1; i <= 5; i++)
            {
                safety_filled[i] = false;
            }
            star[1] = Safety1;
            star[2] = Safety2;
            star[3] = Safety3;
            star[4] = Safety4;
            star[5] = Safety5;
        }

        public int get_stars()
        {
            int i;
            for (i = 1; i <= 5; i++)
            {
                if (!safety_filled[i])
                    break;
            }
            return (i - 1);
        }

        public void set_stars(int star_n)
        {
            if (star_n <= 0) star_n = 0;
            if (star_n >= 5) star_n = 5;
            if (star_n >= 1)
                for (int i = 1; i <= star_n; i++)
                    if (!safety_filled[i])
                    {
                        star[i].Image = NZPostOffice.RDS.DataControls.Properties.Resources.star_filled;
                        safety_filled[i] = true;
                    }

            if (star_n < 5)
                for (int i = (star_n + 1); i <= 5; i++)
                    if (safety_filled[i])
                    {
                        star[i].Image = NZPostOffice.RDS.DataControls.Properties.Resources.star_empty;
                        safety_filled[i] = false;
                    }
            //string sStars = star_n.ToString();
            //SafetyValue.Text = sStars;
            string sStars = this.Parent.Name;
            string sT = sStars;

        }
        // TJB  Dec-2009:  END: Test using stars to display Vehicle Safety Rating

        // TJB  RPCR_001  July-2010: Added to clear all stars/set 'not known'
        private void Safety_t_Click(object sender, EventArgs e)
        {
            set_stars(0);
        }

        // TJB  RPCR_001  Aug-2010: Fixup
        // Added to allow wRenewals to determine whether Consumption 
        // can be modified by the user (eg only sysadmin)
        public void setConsumptionReadonly(bool pValue)
        {
            this.Consumption.ReadOnly = pValue;
        }

        #endregion
    }
}
