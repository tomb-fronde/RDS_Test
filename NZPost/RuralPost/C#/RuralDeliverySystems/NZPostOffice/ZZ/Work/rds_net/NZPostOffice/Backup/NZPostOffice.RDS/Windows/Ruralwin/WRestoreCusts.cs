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
using System.Collections.Generic;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WRestoreCusts : WMaster
    {
        // TJB  Jan-2011  RPI_027
        // cb_restore_clicked: Added check for min date value

        #region Define
        public NCriteria inv_criteria;

        public NRdsMsg inv_msg;

        public URdsDw idw_restore_custs;

        public URdsDw idw_details;

        public int? il_addrid;

        public int? il_custid;

        public int? il_master;

        public bool ib_updated = false;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_find;

        public TextBox custid;

        public Label custid_t;

        public TextBox instructions;

        public URdsDw dw_restore_custs;

        public Label st_1;

        public UCb cb_restore;

        public UCb cb_close;

        #endregion

        public WRestoreCusts()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;

            dw_restore_custs.DataObject = new DRestoreCusts();

            //jlwang:moved from IC
            dw_restore_custs.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_restore_custs_constructor);
            ((DRestoreCusts)dw_restore_custs.DataObject).CellClick += new EventHandler(dw_restore_custs_clicked);
            ((DRestoreCusts)dw_restore_custs.DataObject).CellDoubleClick += new EventHandler(dw_restore_custs_doubleclicked);
            dw_restore_custs.DataObject.BorderStyle = BorderStyle.Fixed3D;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //jlwang:end
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WRestoreCusts));
            this.cb_find = new System.Windows.Forms.Button();
            this.custid = new System.Windows.Forms.TextBox();
            this.custid_t = new System.Windows.Forms.Label();
            this.instructions = new System.Windows.Forms.TextBox();
            this.dw_restore_custs = new NZPostOffice.RDS.Controls.URdsDw();
            this.st_1 = new System.Windows.Forms.Label();
            this.cb_restore = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_close = new NZPostOffice.Shared.VisualComponents.UCb();
            this.SuspendLayout();
            // 
            // cb_find
            // 
            this.cb_find.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_find.Location = new System.Drawing.Point(264, 107);
            this.cb_find.Name = "cb_find";
            this.cb_find.Size = new System.Drawing.Size(75, 23);
            this.cb_find.TabIndex = 3;
            this.cb_find.Text = "Find";
            this.cb_find.Click += new System.EventHandler(this.cb_find_clicked);
            // 
            // custid
            // 
            this.custid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.custid.ForeColor = System.Drawing.SystemColors.WindowText;
            this.custid.Location = new System.Drawing.Point(136, 107);
            this.custid.Name = "custid";
            this.custid.Size = new System.Drawing.Size(75, 20);
            this.custid.TabIndex = 2;
            this.custid.GotFocus += new System.EventHandler(this.custid_GotFocus);
            this.custid.LostFocus += new System.EventHandler(this.custid_losefocus);
            // 
            // custid_t
            // 
            this.custid_t.BackColor = System.Drawing.SystemColors.Control;
            this.custid_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.custid_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.custid_t.Location = new System.Drawing.Point(48, 112);
            this.custid_t.Name = "custid_t";
            this.custid_t.Size = new System.Drawing.Size(75, 13);
            this.custid_t.TabIndex = 4;
            this.custid_t.Text = "Customer ID";
            this.custid_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // instructions
            // 
            this.instructions.BackColor = System.Drawing.SystemColors.Control;
            this.instructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.instructions.Location = new System.Drawing.Point(52, 16);
            this.instructions.Multiline = true;
            this.instructions.Name = "instructions";
            this.instructions.ReadOnly = true;
            this.instructions.Size = new System.Drawing.Size(336, 48);
            this.instructions.TabIndex = 1;
            this.instructions.Text = resources.GetString("instructions.Text");
            this.instructions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dw_restore_custs
            // 
            this.dw_restore_custs.BackColor = System.Drawing.Color.White;
            this.dw_restore_custs.DataObject = null;
            this.dw_restore_custs.FireConstructor = false;
            this.dw_restore_custs.Location = new System.Drawing.Point(8, 152);
            this.dw_restore_custs.Name = "dw_restore_custs";
            this.dw_restore_custs.Size = new System.Drawing.Size(426, 168);
            this.dw_restore_custs.TabIndex = 1;
            this.dw_restore_custs.Text = "none";
            // 
            // st_1
            // 
            this.st_1.BackColor = System.Drawing.SystemColors.Control;
            this.st_1.Font = new System.Drawing.Font("Arial", 8F);
            this.st_1.ForeColor = System.Drawing.Color.Gray;
            this.st_1.Location = new System.Drawing.Point(8, 336);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(88, 16);
            this.st_1.TabIndex = 5;
            this.st_1.Text = "w_restore_custs";
            // 
            // cb_restore
            // 
            this.cb_restore.Location = new System.Drawing.Point(270, 328);
            this.cb_restore.Name = "cb_restore";
            this.cb_restore.Size = new System.Drawing.Size(75, 23);
            this.cb_restore.TabIndex = 2;
            this.cb_restore.Text = "&Restore";
            this.cb_restore.Click += new System.EventHandler(this.cb_restore_clicked);
            // 
            // cb_close
            // 
            this.cb_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_close.Location = new System.Drawing.Point(358, 328);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(75, 23);
            this.cb_close.TabIndex = 3;
            this.cb_close.Text = "Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            // 
            // WRestoreCusts
            // 
            this.AcceptButton = this.cb_restore;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.cb_close;
            this.ClientSize = new System.Drawing.Size(444, 356);
            this.ControlBox = false;
            this.Controls.Add(this.dw_restore_custs);
            this.Controls.Add(this.cb_find);
            this.Controls.Add(this.custid);
            this.Controls.Add(this.custid_t);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.cb_restore);
            this.Controls.Add(this.cb_close);
            this.Name = "WRestoreCusts";
            this.Text = "Restore Customer";
            this.Controls.SetChildIndex(this.cb_close, 0);
            this.Controls.SetChildIndex(this.cb_restore, 0);
            this.Controls.SetChildIndex(this.st_1, 0);
            this.Controls.SetChildIndex(this.instructions, 0);
            this.Controls.SetChildIndex(this.custid_t, 0);
            this.Controls.SetChildIndex(this.custid, 0);
            this.Controls.SetChildIndex(this.cb_find, 0);
            this.Controls.SetChildIndex(this.dw_restore_custs, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

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
            //  TJB  SR4697  Dec-2006  New
            inv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            inv_criteria = inv_msg.of_getcriteria();
            il_addrid = (int)(inv_criteria.of_getcriteria("adr_id"));
            il_master = (int)(inv_criteria.of_getcriteria("master_cust_id"));
            if (il_master == 0)
            {
                il_master = null;
            }
            idw_details = new URdsDw();
            //? idw_details.DataObject = StaticVariables.gnv_app.of_get_parameters().dwparm;
            /*  ------------------- Debugging ------------------ //
                string	ds_addrid
                ds_addrid = il_addrid.ToString()
                if isnull(il_addrid) then ds_addrid = "NULL"
                MessageBox.Show("Addr ID = " + ds_addrid , "w_restore_custs.pfc_preopen" )
            // ------------------------------------------------  */
            idw_restore_custs.Retrieve(new object[] { il_addrid });
            // this.custid.Focus();
            idw_restore_custs.Focus();
        }

        public override void pfc_postopen()
        {
            dw_restore_custs.URdsDw_GetFocus(null, null);
        }

        public override void close()
        {
            base.close();
            //  TJB  SR4697  Dec-2006  New
            int? ll_updated;
            if (ib_updated)
            {
                ll_updated = 1;
            }
            else
            {
                ll_updated = 0;
            }
            inv_criteria.of_addcriteria("updated", ll_updated);
        }

        public virtual void dw_restore_custs_constructor()
        {
            //  NOTE:
            //  This datawindow uses two different dataobjects with similar
            //  names:
            // 		d_restore_custs		(default)
            // 		d_restore_cust
            // 
            //  The d_restore_custs object selects customers previously 
            //  associated with the current address.  The d_restore_cust 
            //  object selects a single customer given a cust_id.  The 
            //  cb_find.clicked event switches between the two.
            idw_restore_custs = dw_restore_custs;
            dw_restore_custs.of_SetUpdateable(false);
            dw_restore_custs.of_SetRowSelect(true);
            dw_restore_custs.of_SetStyle(1); //?inv_rowselect.of_SetStyle(1);
        }

        public virtual int of_update_master(int? al_custid, int? al_master)
        {
            //  TJB  SR4697  Dec-2006  New
            //  Update the master_cust_id for customer al_custid
            //  Returns status of update
            /*  ------------------------ Debugging ------------------------ //
                MessageBox.Show(& "Cust ID = "+string(al_custID)+"
                "  & +"New master = "+string(al_master,"w_restore_custs.of_update_master" )
            // -----------------------------------------------------------  */
            /* UPDATE rds_customer set master_cust_id = :al_master where cust_id = :al_custID using SQLCA; */
            RDSDataService dataService = RDSDataService.UpdateRdsCustomerById(al_master, al_custid);
            if (dataService.SQLCode != 0)
            {
                string ds_custid;
                if (al_custid == null)
                {
                    ds_custid = "NULL";
                }
                else
                {
                    ds_custid = al_custid.ToString();
                }
                MessageBox.Show("Error updating master_cust_id for customer " + ds_custid + "\n" 
                                + "Error code:  " + dataService.SQLDBCode + '\n' 
                                + "Error message: " + dataService.SQLErrText
                                , "Database Error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return SUCCESS;
        }

        #region Events
        public virtual void cb_find_clicked(object sender, EventArgs e)
        {
            //  TJB  SR4697  Dec-2006
            string ls_custid;
            int ll_rows;
            ls_custid = custid.Text;
            if (!(ls_custid == null) && StaticFunctions.IsNumber(ls_custid))
            {
                il_custid = StaticFunctions.ToInt32(ls_custid);
            }
            else
            {
                il_custid = 0;
            }
            if (il_custid > 0)
            {
                idw_restore_custs.DataObject = new DRestoreCust();
                idw_restore_custs.of_SetUpdateable(true);
                idw_restore_custs.Retrieve(new object[]{il_custid});
            }
            else
            {
                idw_restore_custs.DataObject = new DRestoreCusts();
                idw_restore_custs.of_SetUpdateable(true);
                idw_restore_custs.Retrieve(new object[]{il_addrid});
            }
            //  Check to see that the customer record has been found
            ll_rows = idw_restore_custs.RowCount;
            //  If not, tell the user
            if (ll_rows < 1)
            {
                MessageBox.Show("The customer you specified either was not found,   \n" 
                                + "or is an occupant elsewhere.\n" 
                                + "Please re-enter the customer number."
                                , "Warning"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //  NOTE: If the user chooses to restore this customer, 
            //        the address ID will be changed by the code in 
            //        the Restore button click event.
        }

        public virtual void custid_losefocus(object sender, EventArgs e)
        {
            cb_find.Focus();
            this.AcceptButton = cb_restore;
        }

        public void custid_GotFocus(object sender, EventArgs e)
        {
            this.AcceptButton = cb_find;
        }

        public virtual void dw_restore_custs_clicked(object sender, EventArgs e)
        {
            dw_restore_custs.URdsDw_Clicked(sender, e);
            cb_restore.Focus();
        }

        public virtual void dw_restore_custs_doubleclicked(object sender, EventArgs e)
        {
            dw_restore_custs.URdsDw_DoubleClick(sender, e);
            int row = dw_restore_custs.GetRow();
            dw_restore_custs.SelectRow(row + 1, true);
            BeginInvoke(new EventHandler(cb_restore_clicked));
        }

        public virtual void cb_restore_clicked(object sender, EventArgs e)
        {
            //  TJB  SR4697  Dec-2006  New
            int ll_i;
            int ll_row;
            int ll_rows;
            int ll_rc;
            int? ll_master_custid;
            int? ll_custid = 0;
            List<int?> ll_currentmasters = new List<int?>();
            int ll_restorees;
            List<int> ll_restorerow = new List<int>();
            string ls_custname;
            string ls_msg1;
            string ls_msg = "";
            string ls_them;
            bool lb_flag;
            DateTime? ldt_movein;

            //  Determine which customers have been selected to be restored
            ls_msg1 = "These customers have been selected";
            ls_them = "them";
            ll_restorees = 0;
            ll_rows = idw_restore_custs.RowCount;
            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                if (idw_restore_custs.IsSelected(ll_row))
                {
                    ls_custname = idw_restore_custs.GetValue(ll_row, "cust_name").ToString();// idw_restore_custs.GetItem<RestoreCusts>(ll_row).CustName;
                    ls_msg = ls_msg + "\n" + ls_custname;
                    ll_restorees++;
                    ll_restorerow.Add(ll_row);
                }
            }
            if (ll_restorees < 1)
            {
                MessageBox.Show("No customers were selected."
                                , "Warning"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (ll_restorees == 1)
            {
                ls_msg1 = "One customer has been selected";
                ls_them = "this customer";
            }
            DialogResult rc = MessageBox.Show(ls_msg1 + '\n' 
                                    + ls_msg + "\n\n" 
                                    + "Please confirm that you wish to restore " + ls_them 
                                    , "Confirmation"
                                    , MessageBoxButtons.OKCancel
                                    , MessageBoxIcon.Question
                                    , MessageBoxDefaultButton.Button1);
            if (!(rc == DialogResult.OK))
            {
                return;
            }
            //  Work through the list of customers being restored
            //  Set their move_out_* fields to null
            //  Check who their master customer was
            // 		if it is the current master, leave it as is
            // 		otherwise, make the current master its master.
            // 
            //  NOTE: 
            // 		1	We set the adr_id field in the record(s) because the 
            // 			selected customer's address may be a different address.
            // 		2	The customer may not have an existing customer_address_moves 
            // 			record.  In this case, the move in date will be NULL; make
            // 			it TODAY().
            // 		3	In rare cases, there may be no master at the address (no 
            // 			current occupants), in which case the first customer being 
            // 			restored will become the master.
            for (ll_i = 0; ll_i < ll_restorees; ll_i++)
            {
                ll_row = ll_restorerow[ll_i];
                idw_restore_custs.SetValue(ll_row, "MoveOutDate", null);
                idw_restore_custs.SetValue(ll_row, "MoveOutSource", null);
                idw_restore_custs.SetValue(ll_row, "MoveOutUser", null);
                idw_restore_custs.SetValue(ll_row, "AdrId", il_addrid);
                ll_custid = Convert.ToInt32(idw_restore_custs.GetValue(ll_row, "CustId"));
                //  Check whether we're changing this customer's master
                if (idw_restore_custs.DataObject is DRestoreCust)
                {
                    ll_master_custid = idw_restore_custs.GetItem<RestoreCust>(ll_row).MasterCustId;
                }
                else
                {
                    ll_master_custid = idw_restore_custs.GetItem<RestoreCusts>(ll_row).MasterCustId;
                }
                lb_flag = true;
                if (!(il_master == null))
                {
                    if (ll_master_custid == il_master)
                    {
                        //  If there is a current master and this customer is already a
                        //  recipient of that master, there'so need to change.
                        lb_flag = false;
                    }
                }
                else if (ll_master_custid == null)
                {
                    //  If there is no current master and this customer is already a
                    //  master, there'so need to change.
                    lb_flag = false;
                    //  If there was no current master, make this customer the 
                    //  current master. If there are more than one customers being 
                    //  restored, the rest will be made recipients of this customer
                    //  as we loop through the restorees.
                    if (il_master == null)
                    {
                        il_master = ll_custid;
                    }
                }
                //  If we've determined that this customer's master
                //  needs to be changed, do so.
                if (lb_flag)
                {
                    idw_restore_custs.SetValue(ll_row, "MasterCustId", il_master);
                    ll_rc = of_update_master(ll_custid, il_master);
                    if (!(ll_rc == SUCCESS))
                    {
                        return;
                    }
                }
            }
            //  Check to see if the first restoree has a customer_address_moves
            //  record; there won't be a move_in_date if not.  This situation 
            //  can only arise if the user has specified a customer to restore 
            //  (by Finding the customer by cust_id), in which case there will 
            //  only be one customer being restored.
            // 
            //  If this is the case, we need to INSERT a new customer_address_moves 
            //  record, otherwise we can update.
            ll_row = 0;
            ldt_movein = Convert.ToDateTime(idw_restore_custs.GetValue(ll_row, "MoveInDate"));
            // TJB  RPI_027  Jan-2011
            // Added check for min date value
            if (ldt_movein == null || ldt_movein == DateTime.MinValue)
            {
                idw_restore_custs.SetValue(ll_row, "MoveInDate", System.DateTime.Today);
                ldt_movein = Convert.ToDateTime(idw_restore_custs.GetValue(ll_row, "MoveInDate"));
                /* insert into customer_address_moves
                    (adr_id, cust_id, dp_id, move_in_date, move_out_date, move_out_source, move_out_user)
                    values(:il_addrid, :ll_custid, null, :ldt_movein, null, null, null )
                    using SQLCA; */
                RDSDataService dataService = RDSDataService.InsertCustomerAddressMoves(il_addrid, ll_custid, ldt_movein);
                if (dataService.SQLCode < 0)
                {
                    MessageBox.Show("A database error has occurred inserting a new customer_address_moves record. \n" 
                                    + "Address ID = " + il_addrid + '\n' 
                                    + "Cust ID    = " + ll_custid + "\n" 
                                    + "Database error code:  " + dataService.SQLDBCode + '\n' 
                                    + "Database error message:" + dataService.SQLErrText
                                    , "Database Error");
                    //? rollback;
                    ll_rc = FAILURE;
                }
                else
                {
                    //? commit;
                    ll_rc = SUCCESS;
                }
            }
            else
            {
                ll_rc = 1; idw_restore_custs.Save();
                if (!(ll_rc == SUCCESS))
                {
                    MessageBox.Show("ERROR - update returned " + ll_rc
                                    , "w_restore_custs.cb_restore_clicked"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //  Update the display with the original list of restorable customers
            //  for the address.  This means we might need to change the datawindow
            //  being used (but we'll do it anyway to save having to decide).
            idw_restore_custs.DataObject = new DRestoreCusts();
            idw_restore_custs.of_SetUpdateable(true);
            ll_rc = idw_restore_custs.Retrieve(new object[]{il_addrid });
            if (ll_rc == FAILURE)
            {
                MessageBox.Show("ERROR - retrieve returned " + ll_rc
                                , "w_restore_custs.cb_restore_clicked"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ib_updated = true;
        }

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            //  TJB  SR4697  Dec-2006  New
            this.Close();
        }
        #endregion
    }
}