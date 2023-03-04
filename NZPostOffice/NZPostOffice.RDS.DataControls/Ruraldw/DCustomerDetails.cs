using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.DataControls.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    // TJB  June-2016  RPCR_103  Bug fix
    // Added VR_number field in Designer (lost in release)
    //
    // TJB  Jan 2015  RPCR_092
    // Changed 'Date Commenced' property to read-only with no border (in designer)
    //
    // TJB  Jan-2011  Bug fix
    // Changed call to GetAllCustomerDetails2 to call to GetAllCustomerDetails
    //
    // TJB  Jan-2011  Sequencing review
    // Added Case name and Slot allocation fields

    public partial class DCustomerDetails : Metex.Windows.DataUserControl
	{
		public DCustomerDetails()
		{
			InitializeComponent();
			//InitializeDropdown();
		}

        // TJB RD7_0042 Jan-2010: added
        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }

            base.OnHandleCreated(e);
        }

        // TJB RD7_0042 Jan-2010: added
        public ComboBox CustTitleCombo
        {
            get { return this.cust_title; }
        }

        private void InitializeDropdown()
		{
            // TJB RD7_0042 Jan-2010: Changed 
            //     to list (based on sl_name in UTabAddressSearch)
            //cust_title.AssignDropdownType<DDddwCustTitle>();
/*
            List<NZPostOffice.RDS.Entity.Ruralwin.DddwCustTitle> source
                   = new List<NZPostOffice.RDS.Entity.Ruralwin.DddwCustTitle>
                           (NZPostOffice.RDS.Entity.Ruralwin.DddwCustTitle.GetAllDddwCustTitle());

            NZPostOffice.RDS.Entity.Ruralwin.DddwCustTitle emptyRow 
                   = new NZPostOffice.RDS.Entity.Ruralwin.DddwCustTitle();
*/
            List<DddwCustTitle> source = new List<DddwCustTitle>(DddwCustTitle.GetAllDddwCustTitle());

            DddwCustTitle emptyRow = new DddwCustTitle();
            emptyRow.CustomerTitle = "";
            //! Add an empy entry as dropdown cannot show empty text otherwise
            //source.Insert(0, emptyRow);
            cust_title.DataSource = source;            
		}

		public int Retrieve( int? al_cust_id )
        {
            return RetrieveCore<CustomerDetails>(new List<CustomerDetails>(CustomerDetails.GetAllCustomerDetails(al_cust_id)));
		}

	}
}
