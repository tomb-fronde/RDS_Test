using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WPostTaxDeduction : WAncestorWindow
    {
        #region Define
        public int il_contractor;

        public int il_ded_id;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_generic;

        #endregion

        public WPostTaxDeduction()
        {
            this.InitializeComponent();

            //jlwang:moved from IC
            dw_generic.DataObject = new DwPostTaxDeductions();
            dw_generic.DataObject.BorderStyle = BorderStyle.Fixed3D;
            ((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_start_balance")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);
            ((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_min_threshold_gross")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);
            ((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_max_threshold_net_pct")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);

            ((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_percent_gross")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);
            ((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_percent_net")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);
            ((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_fixed_amount")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);
            ((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_percent_start_balance")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);
            ((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_default_minimum")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);

            dw_generic.PfcValidation += new UserEventDelegate1(this.dw_generic_pfc_validation);

            //jlwang:end
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_generic = new URdsDw();
            //dw_generic.DataObject = new DwPostTaxDeductions();

            //((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_start_balance")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);
            //((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_min_threshold_gross")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);
            //((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_max_threshold_net_pct")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);

            //((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_percent_gross")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);
            //((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_percent_net")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);
            //((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_fixed_amount")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);
            //((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_percent_start_balance")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);
            //((System.Windows.Forms.TextBox)this.dw_generic.DataObject.GetControlByName("ded_default_minimum")).Validating += new System.ComponentModel.CancelEventHandler(WPostTaxDeduction_Validating);

            Controls.Add(dw_generic);
            this.Size = new System.Drawing.Size(606, 400);
            this.Name = "w_post_tax_deduction";
            // 
            // st_label
            // 
            st_label.Location = new System.Drawing.Point(7, 350);
            // 
            // dw_generic
            // 
            dw_generic.TabIndex = 1;
            dw_generic.Location = new System.Drawing.Point(3, 4);
            dw_generic.Size = new System.Drawing.Size(600, 332);
            //dw_generic.PfcValidation += new UserEventDelegate1(this.dw_generic_pfc_validation);
            this.ResumeLayout();
        }

        void WPostTaxDeduction_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Forms.TextBox tempTextBox = null;
            switch (((System.Windows.Forms.TextBox)sender).Name)
            {
                case "ded_start_balance":
                    {
                        tempTextBox = (System.Windows.Forms.TextBox)this.dw_generic.GetControlByName("ded_start_balance");
                        break;
                    }
                case
                "ded_min_threshold_gross":
                    {
                        tempTextBox = (System.Windows.Forms.TextBox)this.dw_generic.GetControlByName("ded_min_threshold_gross");
                        break;
                    }
                case "ded_max_threshold_net_pct":
                    {
                        tempTextBox = (System.Windows.Forms.TextBox)this.dw_generic.GetControlByName("ded_max_threshold_net_pct");
                        break;
                    }
                case "ded_percent_gross":
                    {
                        tempTextBox = (System.Windows.Forms.TextBox)this.dw_generic.GetControlByName("ded_percent_gross");
                        break;
                    }
                case "ded_percent_net":
                    {
                        tempTextBox = (System.Windows.Forms.TextBox)this.dw_generic.GetControlByName("ded_max_threshold_net_pct");
                        break;
                    }
                case "ded_fixed_amount":
                    {
                        tempTextBox = (System.Windows.Forms.TextBox)this.dw_generic.GetControlByName("ded_max_threshold_net_pct");
                        break;
                    }
                case "ded_percent_start_balance":
                    {
                        tempTextBox = (System.Windows.Forms.TextBox)this.dw_generic.GetControlByName("ded_max_threshold_net_pct");
                        break;
                    }
                case "ded_default_minimum":
                    {
                        tempTextBox = (System.Windows.Forms.TextBox)this.dw_generic.GetControlByName("ded_max_threshold_net_pct");
                        break;
                    }
            }
            if (tempTextBox.Text == "")
                return;
            try
            {
                double tempDouble = System.Convert.ToDouble(tempTextBox.Text);

                //double tempDou = System.Math.Round(tempDouble, 2);
                //string tempStr = tempDou.ToString();

                //if (tempStr.IndexOf('.') == -1)
                //{
                //    tempTextBox.Text = tempStr + ".00";
                //    return;
                //}

                //if (tempStr.Length - tempStr.IndexOf('.') == 2)
                //{
                //    tempTextBox.Text = tempStr + "0";
                //    return;
                //}
                //else
                //{
                //    tempTextBox.Text = tempStr;
                //}
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Item '" + tempTextBox.Text.ToString() + "'does not pass validation test.", "Rural Delivery System with NPAD Extensions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname("Post-Tax Deduction");
            string ls_Title;
            NRdsMsg lnv_msg = new NRdsMsg();
            NCriteria lvn_Criteria = new NCriteria();
            lnv_msg = ((NRdsMsg)StaticMessage.PowerObjectParm);
            lvn_Criteria = lnv_msg.of_getcriteria();
            il_contractor = Convert.ToInt32(lvn_Criteria.of_getcriteria("contractor_id"));
            il_ded_id = Convert.ToInt32(lvn_Criteria.of_getcriteria("ded_id"));
            if (il_ded_id > 0)
            {
                ((DwPostTaxDeductions)dw_generic.DataObject).Retrieve(il_ded_id);
                ls_Title = "Post Tax Deduction:  ( " + il_ded_id.ToString() + ") ";
            }
            else
            {
                dw_generic.DataObject.InsertItem<PostTaxDeductions>(0);
                dw_generic.DataObject.GetItem<PostTaxDeductions>(0).ContractorSupplierNo = il_contractor;
                ((RadioButton)dw_generic.GetControlByName("radioButton2")).Checked = true;
                //  Default the dropdown to 'Post Tax Deduction'
                ((DwPostTaxDeductions)dw_generic.DataObject).GetItem<PostTaxDeductions>(0).PctId = 6;
                ls_Title = "Post Tax Deduction: <New Post Tax Deduction> ";
                dw_generic.DataObject.BindingSource.CurrencyManager.Refresh();

            }
            this.Text = ls_Title;
            //?dw_generic.Focus();
        }

        //added by jlwang 
        public override void pfc_postopen()
        {
            dw_generic.URdsDw_GetFocus(null, null);
        }

        public virtual string wf_validate(int arow)
        {
            string sdesc;
            string sret;
            System.Decimal? ld_total;
            sdesc = dw_generic.DataObject.GetItem<PostTaxDeductions>(arow).DedDescription;//, "ded_description");
            if (sdesc == null)
            {
                MessageBox.Show("You must enter the description", base.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "ded_description";
            }
            ld_total = dw_generic.DataObject.GetItem<PostTaxDeductions>(arow).DedStartBalance;
            if ((ld_total == null) || ld_total <= 0)
            {
                MessageBox.Show("You must enter a positive total amount.", base.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "ded_start_balance";
            }
            return "";
        }

        public virtual void ue_deletestart()
        {
            int? lded;
            int lct = int.MinValue;
            lded = dw_generic.DataObject.GetItem<PostTaxDeductions>(dw_generic.GetRow()).DedId;
            /*SELECT count ( odps.post_tax_deductions_applied.pcd_id ) INTO :lct  
              FROM odps.post_tax_deductions_applied WHERE odps.post_tax_deductions_applied.ded_id = :lded   ;*/
            lct = RDSDataService.GetPostTaxDeductionsAppliedCount(lded);
            if (lct > 0)
            {
                MessageBox.Show("This deduction cannot be deleted because payment has been made", base.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                StaticMessage.ReturnValue = 1;
            }
        }

        public virtual int dw_generic_pfc_validation()
        {
            string sdesc;
            string sret;
            System.Decimal? ld_total;
            int ll_Row;
            ll_Row = dw_generic.GetRow();
            sdesc = dw_generic.DataObject.GetItem<PostTaxDeductions>(ll_Row).DedDescription;
            //ib_closestatus = true; //added by ylwang
            if (sdesc == null)
            {
                if (!ib_closestatus)
                {
                    MessageBox.Show("You must enter the description", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_generic.DataObject.GetControlByName("ded_description").Focus();
                }
                return FAILURE;
            }
            ld_total = dw_generic.DataObject.GetItem<PostTaxDeductions>(ll_Row).DedStartBalance;
            if (ld_total == null || ld_total <= 0)
            {
                if (!ib_closestatus)
                {
                    MessageBox.Show("You must enter a positive total amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_generic.DataObject.GetControlByName("ded_start_balance").Focus();
                }
                return FAILURE;
            }
            return SUCCESS;
        }
    }
}
