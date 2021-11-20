using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using System.Collections;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DUserGroupTest : Metex.Windows.DataUserControl
	{
		public DUserGroupTest()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
            ArrayList _list = null;
            // gp_level_1
            _list = new ArrayList();
            _list.Add(new DataEntityComboxAdapter("Update",7));
            _list.Add(new DataEntityComboxAdapter("Read Only",0));
            _list.Add(new DataEntityComboxAdapter("No Access",-1));
            gp_level_1.DataSource = _list;
            gp_level_1.DisplayMember = "Key";
            gp_level_1.ValueMember = "Value";

            //gp_level_2
            _list = new ArrayList();
            _list.Add(new DataEntityComboxAdapter("Update",7));
            _list.Add(new DataEntityComboxAdapter("Read Only",0));
            _list.Add(new DataEntityComboxAdapter("No Access",-1));
            gp_level_2.DataSource = _list;
            gp_level_2.DisplayMember = "Key";
            gp_level_2.ValueMember = "Value";

            //gp_level_9
            _list = new ArrayList();
            _list.Add(new DataEntityComboxAdapter("Update",7));
            _list.Add(new DataEntityComboxAdapter("No Access",-1));
            gp_level_9.DataSource = _list;
            gp_level_9.DisplayMember = "Key";
            gp_level_9.ValueMember = "Value";

            //gp_level_6
            _list = new ArrayList();
            _list.Add(new DataEntityComboxAdapter("Access",0));
            _list.Add(new DataEntityComboxAdapter("No Access",-1));
            gp_level_6.DataSource = _list;
            gp_level_6.DisplayMember = "Key";
            gp_level_6.ValueMember = "Value";

            //gp_level_7
            _list = new ArrayList();
            _list.Add(new DataEntityComboxAdapter("Access",0));
            _list.Add(new DataEntityComboxAdapter("No Access",-1));
            gp_level_7.DataSource = _list;
            gp_level_7.DisplayMember = "Key";
            gp_level_7.ValueMember = "Value";

            //gp_level_3
            _list = new ArrayList();
            _list.Add(new DataEntityComboxAdapter("U All Regions",7));
            _list.Add(new DataEntityComboxAdapter("No U 1 Region, RO Others",4));
            _list.Add(new DataEntityComboxAdapter("RO All Regions",3));
            _list.Add(new DataEntityComboxAdapter("U 1 Region",2));
            _list.Add(new DataEntityComboxAdapter("RO 1 Region",1));
            _list.Add(new DataEntityComboxAdapter("No Access",-1));
            gp_level_3.DataSource = _list;
            gp_level_3.DisplayMember = "Key";
            gp_level_3.ValueMember = "Value";

            //gp_level_4
            _list = new ArrayList();
            _list.Add(new DataEntityComboxAdapter("Full Details",1));
            _list.Add(new DataEntityComboxAdapter("Standard Details",0));
            gp_level_4.DataSource = _list;
            gp_level_4.DisplayMember = "Key";
            gp_level_4.ValueMember = "Value";

            //gp_level_5
            _list = new ArrayList();
            _list.Add(new DataEntityComboxAdapter("Full Details",1));
            _list.Add(new DataEntityComboxAdapter("Read Only",0));
            _list.Add(new DataEntityComboxAdapter("No Access",-1));
            gp_level_5.DataSource = _list;
            gp_level_5.DisplayMember = "Key";
            gp_level_5.ValueMember = "Value";
		}

		public override int Retrieve( )
		{
			return RetrieveCore<UserGroupTest>(new List<UserGroupTest>
				(UserGroupTest.GetAllUserGroupTest()));
		}
	}

    public class DataEntityComboxAdapter
    {
        private string _key;
        private int _value;
        public DataEntityComboxAdapter(string key, int value)
        {
            _key = key;
            _value = value;
        }

        public string Key
        {
            get
            {
                return _key;
            }
         
        }

        public int Value
        {
            get
            {
                return _value;
            }
        
        }
    }
}
