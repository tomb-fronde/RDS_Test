using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.DataControls.DropDownList;
using NZPostOffice.DataControls;
namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DCustCriteriaDelfreq : Metex.Windows.DataUserControl
	{
		public DCustCriteriaDelfreq()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
            //List<NZPostOffice.RDS.DataControls.DropDownList.DropDownList> list = new List<NZPostOffice.RDS.DataControls.DropDownList.DropDownList>();
            //list.Add(new NZPostOffice.RDS.DataControls.DropDownList.DropDownList());
            //list[0].DisplayValue = "<All Frequencies>";
            //list[0].DataValue = "0";
            //list.Add(new NZPostOffice.RDS.DataControls.DropDownList.DropDownList());
            //list[1].DisplayValue = "1 Day/ Week";
            //list[1].DataValue = "1";
            //list.Add(new NZPostOffice.RDS.DataControls.DropDownList.DropDownList());
            //list[2].DisplayValue = "2 Days/ Week";
            //list[2].DataValue = "2";
            //list.Add(new NZPostOffice.RDS.DataControls.DropDownList.DropDownList());
            //list[3].DisplayValue = "3 Days/ Week";
            //list[3].DataValue = "3";
            //list.Add(new NZPostOffice.RDS.DataControls.DropDownList.DropDownList());
            //list[4].DisplayValue = "4 Days/ Week";
            //list[4].DataValue = "4";
            //list.Add(new NZPostOffice.RDS.DataControls.DropDownList.DropDownList());
            //list[5].DisplayValue = "5 Days/ Week";
            //list[5].DataValue = "5";
            //list.Add(new NZPostOffice.RDS.DataControls.DropDownList.DropDownList());
            //list[6].DisplayValue = "6 Days/ Week";
            //list[6].DataValue = "6";
            //list.Add(new NZPostOffice.RDS.DataControls.DropDownList.DropDownList());
            //list[7].DisplayValue = "7 Days/ Week";
            //list[7].DataValue = "7";
            //this.del_days_week.AssignDropdownType<DDropDownList>();
            //this.del_days_week.DataSource = list;

            System.Data.DataTable sourceTable1 = new System.Data.DataTable();
            sourceTable1.Columns.AddRange(new System.Data.DataColumn[]
			{
				new System.Data.DataColumn("Display", typeof(string)),
				new System.Data.DataColumn("Value", typeof(int))
			});
            sourceTable1.Rows.Add(new object[] { "<All Frequencies>", 0 });
            sourceTable1.Rows.Add(new object[] { "1 Day/ Week", 1 });
            sourceTable1.Rows.Add(new object[] { "2 Days/ Week", 2 });
            sourceTable1.Rows.Add(new object[] { "3 Days/ Week", 3 });
            sourceTable1.Rows.Add(new object[] { "4 Day/ Week", 4 });
            sourceTable1.Rows.Add(new object[] { "5 Day/ Week", 5 });
            sourceTable1.Rows.Add(new object[] { "6 Days/ Week", 6 });
            sourceTable1.Rows.Add(new object[] { "7 Days/ Week", 7 });
            this.del_days_week.DataSource = sourceTable1;
            this.del_days_week.DisplayMember = "Display";
            this.del_days_week.ValueMember = "Value";


            mail_category.AssignDropdownType<DDddwMailCategoryFixed>();
            ct_key.AssignDropdownType<DDddwContractTypes>();
            region_id.AssignDropdownType<DDddwRegions>();
            rg_code.AssignDropdownType<DDddwRenewalgroup>();
             
		}

		public override int Retrieve( )
		{
			return RetrieveCore<CustCriteriaDelfreq>(new List<CustCriteriaDelfreq>
				(CustCriteriaDelfreq.GetAllCustCriteriaDelfreq(  )));
		}

	}
}
