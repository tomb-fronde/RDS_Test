using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using Metex.Windows;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public partial class WCustomerTransfer : WMaster
    {
        #region Define
        private WContract2001 par_con;

        public int? il_oldContractNo;
        #endregion

        public WCustomerTransfer()
        {
            this.InitializeComponent();

            this.ShowInTaskbar = false;

            //jlwang:moved from IC
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            dw_transfer.EditChanged += new EventHandler(dw_transfer_editchanged);

            //jlwang:end
        }

        public override void open()
        {
            base.open();
            //  TJB  SR4680  July 2006
            //  Fixed spelling/plural in message
            int? li_number;
            il_oldContractNo = StaticVariables.gnv_app.of_get_parameters().longparm;
            li_number = StaticVariables.gnv_app.of_get_parameters().integerparm;
            if (li_number == 1)
            {
                st_1.Text = li_number.ToString() + " address exists ";
            }
            else
            {
                st_1.Text = li_number.ToString() + " addresses exist ";
            }
            st_1.Text += "for contract " + il_oldContractNo.ToString();
            dw_transfer.InsertItem<CustomerTransfer>(0);
            //  presume transfer not successfull.
            StaticVariables.gnv_app.of_get_parameters().booleanparm = false;
            //  store away the powerobject
            par_con = (WContract2001)StaticMessage.PowerObjectParm;
        }

        public override int closequery()
        {
            base.closequery();
            //? this.of_setupdateable(false);
            return 0;
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.ib_disableclosequery = true;
        }

        #region Events
        public virtual void dw_transfer_editchanged(object sender, EventArgs e)
        {
            if (!StaticFunctions.f_isempty(((System.Windows.Forms.MaskedTextBox)(sender)).Text))//dw_transfer.GetValue<string>(0, dw_transfer.GetColumnName())))
            {
                cb_transfer.Enabled = true;
            }
            else
            {
                cb_transfer.Enabled = false;
            }
        }

        public virtual void dw_transfer_losefocus(object sender, EventArgs e)
        {
            dw_transfer.AcceptText();
        }

        public virtual void cb_transfer_clicked(object sender, EventArgs e)
        {
            int? ll_newcontractno;
            int lCount = 0;
            DateTime dDate;
            Cursor.Current = Cursors.WaitCursor;
            ll_newcontractno = dw_transfer.GetItem<CustomerTransfer>(0).ContractNo;
            // Check that the transfer TO contract number is not the same the transfer FROM contract no
            if (ll_newcontractno == il_oldContractNo)
            {
                MessageBox.Show("You can not select the same contract number as before!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            // Can not move address to contract 0
            if (ll_newcontractno == 0)
            {
                MessageBox.Show("Deleting the contract number removes the Addresses from the system.\r\r" + "Do you want to do this?", this.Text);
                return;
            }
            // Check that the contract exists
            /* SELECT Count(*) 
                INTO :lCount
                FROM contract
                WHERE contract_no = :ll_newcontractno 
                and con_date_terminated is null; */
            RDSDataService dataService = RDSDataService.GetContractCountByNo(ll_newcontractno);
            lCount = dataService.intVal;
            if (lCount < 1)
            {
                MessageBox.Show("The contract you have chosen does not \r" + "exist or has been terminated", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dw_transfer.Focus();
                dw_transfer.GetControlByName("contract_no").Focus();
                //? dw_transfer.SelectText(1,  ll_newcontractno);
                dw_transfer.GetControlByName("contract_no").Select();
                return;
            }
            // Contract exists, transfer
            if (ll_newcontractno != 0)
            {
                /* UPDATE Address SET contract_no = :ll_newcontractno
                    WHERE contract_no = :il_oldcontractno; */
                dataService = RDSDataService.UpdateAddressContractNo(ll_newcontractno, il_oldContractNo);
            }
            if (!(dataService.SQLCode == 0))
            {
                MessageBox.Show("Unable to transfer Addresses to new contract\r" + "Database Error Code " + dataService.SQLDBCode + '~' + dataService.SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //? Rollback;
                return;
            }
            // Transfer successful, remove addresses from the sequence
            /* DELETE address_frequency_sequence 
                WHERE contract_no = :il_oldcontractno ; */
            dataService = RDSDataService.DeleteAddressFreqSeqByContractNo(il_oldContractNo);
            if (!(dataService.SQLCode == 0))
            {
                MessageBox.Show("Unable to delete Addresses from Address frequency sequence table\r" + "Database Error Code " + dataService.SQLDBCode + '~' + dataService.SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //? Rollback;
                return;
            }
            //  Changing this around as this response window was opened with 
            //  an open sheet not open - there will be no waiting
            // 		gnv_App.of_Get_Parameters ( ).booleanparm = true
            // 		gnv_App.of_Get_Parameters ( ).LONGparm = lNewContractNo
            par_con.of_terminate(ll_newcontractno, true);
            //? commit;
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            par_con.of_terminate(1, false);
            this.Close();
        }
        #endregion
    }
}