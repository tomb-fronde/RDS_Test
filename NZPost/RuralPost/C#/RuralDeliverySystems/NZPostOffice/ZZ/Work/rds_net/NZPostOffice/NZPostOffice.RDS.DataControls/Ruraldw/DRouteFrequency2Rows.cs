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
    // TJB Frequencies Nov-2020
    // Created modelled on DContractFixedAssetsTest
    //
    // TJB Frequencies Changes 13-Nov-2020
    // Checkin sort-of-working version

    public partial class DRouteFrequency2Rows : Metex.Windows.DataUserControl
	{
        // TJB  RPCR_026  July-2011
        // Added Load and Enter event handlers
        // Added contract_no to screen

        public DRouteFrequency2Rows()
		{
			InitializeComponent();
            InitializeDropdown();
            //this.Enter += new System.EventHandler(this.rf_item_Enter);
            //this.Load += new EventHandler(rf_Load);
		}
/*
        void rf_Load(object sender, EventArgs e)
        {
            // TJB  RPCR_026  July-2011
            // The Load  event is triggered whenever an instance is loaded.  
            // This includes those instances for real assets, and empty ones. 
            // Empty ones are loaded when there are no real ones to load, 
            // and when a new asset is being created.
            // To distinguish the various instances, we examine the asset number.
            // If there is an asset number, the load is for an existing asset 
            // and can be ignored.
            //string sThisFrequency = this.sf_key.Value;
            //string sThisContract = this.contract_no.Text;
            //MessageBox.Show("Frequency  = " + sThisFrequency + "\n"
            //                + "Contract = " + sThisContract + "\n"
            //                , "rf_Load");
            if (sThisFrequency != "")
            {
                return;
            }
            // To distinguish between a new asset being created and a dummy 
            // asset that is loaded when there are no existing ones, we examine
            // the value in the new_asset location (actually a hidden label) in 
            // the tabpage of WContract2001.  When a new asset is being created, 
            // this is populated with the new asset's number.  If new_asset is
            // empty, this is a dummy asset and can be ignored.
            //
            // To find the new_asset (and new_contract) value(s), we need to find
            // them in the great-grandparent (found to be there via experimentation).
            // As long as the layers don't change, we will find the proper control
            // by scanning, looking for the control's name (see also rf_item_enter).
            // [I scan rather than using GetChildIndex because (a) the list of 
            // controls is short and (b) I don't want an exception raised if it 
            // fails]
            int nNewItemIndex = -1;
            int nNewContractIndex = -1;
            int nCurrentItemIndex = -1;

            string sControlName;
            ControlCollection cCollection3 = this.Parent.Parent.Parent.Controls;
            int nRows = cCollection3.Count;
            for (int nRow = 0; nRow < cCollection3.Count; nRow++)
            {
                sControlName = cCollection3[nRow].Name;
                if (sControlName == "new_asset") nNewAssetIndex = nRow;
                if (sControlName == "new_contract") nNewContractIndex = nRow;
                if (sControlName == "current_asset") nCurrentAssetIndex = nRow;
            }
            string sNewAsset = "";

            if (nNewAssetIndex >= 0) sNewAsset = cCollection3[nNewAssetIndex].Text;
            if (sNewAsset == "")
            {
                return;
            }

            // If this is a new asset being created, add the asset's asset number
            // and contract number to the display.
            // We need to do this because (for reasons not understood) they don't 
            // appear until the user enters something in the new contract, when the 
            // values are inserted into the datawindow in WContract2001.
            string sNewContract = "";
            if (nNewContractIndex >= 0) sNewContract = cCollection3[nNewContractIndex].Text;
                            
            //MessageBox.Show("New Fixed Asset?? \n" 
            //                + "New Asset = " + sNewAsset + "\n"
            //                + "New Contract = " + sNewContract + "\n"
            //                , "rf_Load");

            this.sf_description.Text = sNewAsset;
            this.rf_nms.Text = sNewContract;

            // Also change the current_asset value to this asset
            if (nCurrentAssetIndex >= 0) cCollection3[nCurrentAssetIndex].Text = sNewAsset;
        }
*/
        public event EventHandler TextBoxLostFocus;

        private void TextBox_LostFocus(object sender, System.EventArgs e)
        {
            if (TextBoxLostFocus != null)
            {
                TextBoxLostFocus(sender, e);
            }
        }

        private void TextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TextBoxLostFocus != null)
            {
                TextBoxLostFocus(sender, e);
            }
        }
/*
        private void rf_item_Enter(object sender, EventArgs e)
        {
            // TJB  RPCR_026  June-2011: New
            // NOTE: Probably due to the complicated nature of how the fixed assets tab 
            // is set up (it REALLY needs to be fixed!) the row the user thinks has been 
            // selected hasn't, hence this code.
            // Ths event puts the asset number of the row the user is currently focussed 
            // on (thinks is selected) in the control current_asset (a hidden label) on 
            // the WContract2001 fixed assets tab page. Code in WContract2001 can access 
            // it to determine the actual selected row.  Currently, this is only used when 
            // the user wants to delete a row.

            // Look up the current_asset control.  It was found to be on the great-
            // grandparent.  Scan that object's controls to find thecontrol's index 
            // and use that index to find its value.
            // (Much of the commented-out code below was used for debuggung)

            int nRows;
            int nCurrentAssetIndex = -1;
            string sControlName = "";
            
            //Get the frequency key of the selected frequency
            string sSelectedAsset = sf_key.Text;

            //string sSelectedContract = contract_no.Text;
            //string sParent_1_Name = this.Parent.Name;
            //string sParent_2_Name = this.Parent.Parent.Name;
            string sParent_3_Name = this.Parent.Parent.Parent.Name;
            ControlCollection cCollection3 = this.Parent.Parent.Parent.Controls;
            nRows = cCollection3.Count;
            //string sCollectionList3 = "  Collection (" + nRows.ToString() + ") \n";
            for (int nRow = 0; nRow < nRows; nRow++)
            {
                sControlName = cCollection3[nRow].Name;
                if (sControlName == "current_asset") nCurrentAssetIndex = nRow;
                //sCollectionList3 += "    " + nRow.ToString() + "  " + sControlName + "\n";
            }

            // If the index of the current_asset control was found
            // place the selected asset's number there.
            if (nCurrentAssetIndex >= 0)
            {
                //string sCurrentAssetText = cCollection3[nCurrentAssetIndex].Text;
                //MessageBox.Show("Asset " + sSelectedAsset + "\n"
                //                + "Contract " + sSelectedContract + "\n\n"
                //                + "Parent_1_Name = " + sParent_1_Name + "\n"
                //                + "Parent_2_Name = " + sParent_2_Name + "\n"
                //                + "Parent_3_Name = " + sParent_3_Name + "\n"
                //                + sCollectionList3
                //                //+ "Parent_4_Name = " + sParent_4_Name + "\n"
                //                //+ sCollectionList4
                //                //+ "Parent_5_Name = " + sParent_5_Name + "\n"
                //                //+ sCollectionList5
                //                + "CurrentAsset Index = " + nCurrentAssetIndex.ToString() + ", "
                //                + "Text = " + sCurrentAssetText + "\n"
                //                , "DRouteFrequency2Rows rf_item_Enter");

                cCollection3[nCurrentAssetIndex].Text = sSelectedAsset;
            }
        }
*/
        private void InitializeDropdown()
        {
            sf_key.AssignDropdownType<DDddwStandardFrequency>();
        }

        public int Retrieve(int? contract_no, int? in_showall)
        {
            return RetrieveCore<RouteFrequency2>(new List<RouteFrequency2>
                (RouteFrequency2.GetAllRouteFrequency2(contract_no, in_showall)));
        }
    }
}
