using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.DataService;
using Metex.Windows;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralrpt;
using System.Collections.Generic;
using NZPostOffice.Entity;
using Metex.Core;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WAddPieceRateType : WMaster
    {
        // TJB  RPCR_054  June-2013: NEW
        // Displays the list of defined piece rate types and allows the user 
        // to add a piece rate for that type for one or more renewal groups.
        // Initial values for the rate and effective date can be entered and 
        // apply for all renewal groups.  Only rates for types/renewal groups 
        // that don't already exist in the piece_rate table will be created. 
        // Adding a new rate for a new effective date is done in WShowRates.
        // 
        #region Define

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_close;
        private Button cb_save;

        private Label label1;

        public Label st_prt;
        private Label pr_rate_t;
        private MaskedTextBox pr_rate;
        private Label pr_effective_date_t;
        private MaskedTextBox pr_effective_date;
        private Label renewal_group_t;
        private CheckBox cb_inactive;
        private ToolTip toolTip1;
        private CheckedListBox checkedListBox1;

        public URdsDw dw_prt;
        public URdsDw dw_rg;

        #endregion

        NCriteria nvCriteria;
        NRdsMsg nvMsg;
        int nRgCode;
        int nCurrentRow;

        public WAddPieceRateType()
        {
            this.InitializeComponent();
            this.dw_prt.DataObject = new DDddwPieceRateTypes();
            dw_prt.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dw_prt.Constructor += new UserEventDelegate(dw_prt_constructor);
            dw_prt.Click += new EventHandler(dw_prt_Click);
            dw_rg = new URdsDw();
            dw_rg.DataObject = new DDddwRenewalGroups();
            dw_rg.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // Changes the selection mode from double-click to single click.
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }


        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cb_close = new System.Windows.Forms.Button();
            this.dw_prt = new NZPostOffice.RDS.Controls.URdsDw();
            this.st_prt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pr_rate_t = new System.Windows.Forms.Label();
            this.pr_rate = new System.Windows.Forms.MaskedTextBox();
            this.pr_effective_date_t = new System.Windows.Forms.Label();
            this.pr_effective_date = new System.Windows.Forms.MaskedTextBox();
            this.renewal_group_t = new System.Windows.Forms.Label();
            this.cb_inactive = new System.Windows.Forms.CheckBox();
            this.cb_save = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // cb_close
            // 
            this.cb_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.cb_close.Location = new System.Drawing.Point(398, 284);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(75, 23);
            this.cb_close.TabIndex = 30;
            this.cb_close.Text = "Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            // 
            // dw_prt
            // 
            this.dw_prt.DataObject = null;
            this.dw_prt.FireConstructor = false;
            this.dw_prt.Location = new System.Drawing.Point(19, 40);
            this.dw_prt.Name = "dw_prt";
            this.dw_prt.Size = new System.Drawing.Size(273, 239);
            this.dw_prt.TabIndex = 2;
            this.dw_prt.RowFocusChanged += new System.EventHandler(this.dw_prt_RowFocusChanged);
            // 
            // st_prt
            // 
            this.st_prt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.st_prt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_prt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_prt.Location = new System.Drawing.Point(16, 18);
            this.st_prt.Name = "st_prt";
            this.st_prt.Size = new System.Drawing.Size(194, 19);
            this.st_prt.TabIndex = 0;
            this.st_prt.Text = "Select the piece rate to add";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(15, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "WAddPieceRateType";
            // 
            // pr_rate_t
            // 
            this.pr_rate_t.AutoSize = true;
            this.pr_rate_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pr_rate_t.Location = new System.Drawing.Point(309, 22);
            this.pr_rate_t.Name = "pr_rate_t";
            this.pr_rate_t.Size = new System.Drawing.Size(34, 13);
            this.pr_rate_t.TabIndex = 0;
            this.pr_rate_t.Text = "Rate";
            // 
            // pr_rate
            // 
            this.pr_rate.AllowPromptAsInput = false;
            this.pr_rate.AsciiOnly = true;
            this.pr_rate.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.pr_rate.Location = new System.Drawing.Point(397, 18);
            this.pr_rate.Mask = "###.00000";
            this.pr_rate.Name = "pr_rate";
            this.pr_rate.PromptChar = '0';
            this.pr_rate.Size = new System.Drawing.Size(67, 20);
            this.pr_rate.TabIndex = 5;
            this.pr_rate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.pr_rate.Leave += new System.EventHandler(this.pr_rate_Leave);
            // 
            // pr_effective_date_t
            // 
            this.pr_effective_date_t.AutoSize = true;
            this.pr_effective_date_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pr_effective_date_t.Location = new System.Drawing.Point(309, 46);
            this.pr_effective_date_t.Name = "pr_effective_date_t";
            this.pr_effective_date_t.Size = new System.Drawing.Size(89, 13);
            this.pr_effective_date_t.TabIndex = 0;
            this.pr_effective_date_t.Text = "Effective Date";
            // 
            // pr_effective_date
            // 
            this.pr_effective_date.AllowPromptAsInput = false;
            this.pr_effective_date.AsciiOnly = true;
            this.pr_effective_date.Location = new System.Drawing.Point(397, 41);
            this.pr_effective_date.Mask = "00/00/0000";
            this.pr_effective_date.Name = "pr_effective_date";
            this.pr_effective_date.PromptChar = '0';
            this.pr_effective_date.Size = new System.Drawing.Size(71, 20);
            this.pr_effective_date.TabIndex = 10;
            this.pr_effective_date.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.toolTip1.SetToolTip(this.pr_effective_date, "Enter date in dd/mm/yyyy format");
            this.pr_effective_date.Leave += new System.EventHandler(this.pr_effective_date_Leave);
            // 
            // renewal_group_t
            // 
            this.renewal_group_t.AutoSize = true;
            this.renewal_group_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renewal_group_t.Location = new System.Drawing.Point(309, 88);
            this.renewal_group_t.Name = "renewal_group_t";
            this.renewal_group_t.Size = new System.Drawing.Size(94, 13);
            this.renewal_group_t.TabIndex = 0;
            this.renewal_group_t.Text = "Renewal Group";
            // 
            // cb_inactive
            // 
            this.cb_inactive.AutoSize = true;
            this.cb_inactive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb_inactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_inactive.Location = new System.Drawing.Point(307, 65);
            this.cb_inactive.Name = "cb_inactive";
            this.cb_inactive.Size = new System.Drawing.Size(104, 17);
            this.cb_inactive.TabIndex = 15;
            this.cb_inactive.Text = "Inactive        ";
            this.cb_inactive.UseVisualStyleBackColor = true;
            // 
            // cb_save
            // 
            this.cb_save.Location = new System.Drawing.Point(315, 284);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(75, 23);
            this.cb_save.TabIndex = 25;
            this.cb_save.Text = "Save";
            this.cb_save.UseVisualStyleBackColor = true;
            this.cb_save.Click += new System.EventHandler(this.cb_save_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(312, 107);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(154, 169);
            this.checkedListBox1.TabIndex = 20;
            this.checkedListBox1.ThreeDCheckBoxes = true;
            // 
            // WAddPieceRateType
            // 
            this.AcceptButton = this.cb_close;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(480, 313);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.cb_save);
            this.Controls.Add(this.cb_inactive);
            this.Controls.Add(this.renewal_group_t);
            this.Controls.Add(this.pr_effective_date);
            this.Controls.Add(this.pr_effective_date_t);
            this.Controls.Add(this.pr_rate);
            this.Controls.Add(this.pr_rate_t);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_close);
            this.Controls.Add(this.dw_prt);
            this.Controls.Add(this.st_prt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "WAddPieceRateType";
            this.Text = "Add Piece Rate Type";
            this.Controls.SetChildIndex(this.st_prt, 0);
            this.Controls.SetChildIndex(this.dw_prt, 0);
            this.Controls.SetChildIndex(this.cb_close, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pr_rate_t, 0);
            this.Controls.SetChildIndex(this.pr_rate, 0);
            this.Controls.SetChildIndex(this.pr_effective_date_t, 0);
            this.Controls.SetChildIndex(this.pr_effective_date, 0);
            this.Controls.SetChildIndex(this.renewal_group_t, 0);
            this.Controls.SetChildIndex(this.cb_inactive, 0);
            this.Controls.SetChildIndex(this.cb_save, 0);
            this.Controls.SetChildIndex(this.checkedListBox1, 0);
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

        public override void open()
        {
            DateTime dtEffDate;
            string sRgDescription; 
            string sEffDate;
            int nRgCode1;

            base.open();

            nvMsg = (NRdsMsg)StaticMessage.PowerObjectParm;
            nvCriteria = nvMsg.of_getcriteria();
            nRgCode = System.Convert.ToInt32(nvCriteria.of_getcriteria("rg_code"));

            // Get the renewal groups
            // DddwRenewalGroups returns a "<select all>" item; here we remove it
            dw_rg.Retrieve();
            sRgDescription = dw_rg.GetItem<DddwRenewalGroups>(0).RgDescription;
            nRgCode1 = (int)dw_rg.GetItem<DddwRenewalGroups>(0).RgCode;
            if (nRgCode1 < 0)
            {
                dw_rg.DeleteItemAt(0);
            }

            // Set up the renewal groups as a CheckedListBox
            // with the current renewal group pre-selected
            int nRows = dw_rg.RowCount;
            for (int nRow = 0; nRow < nRows; nRow++)
            {
                nRgCode1 = (int)dw_rg.GetItem<DddwRenewalGroups>(nRow).RgCode;
                sRgDescription = dw_rg.GetItem<DddwRenewalGroups>(nRow).RgDescription;
                checkedListBox1.Items.Add(sRgDescription);
                if (nRgCode1 == nRgCode)
                    checkedListBox1.SetItemChecked(nRow, true);
            }

            // The initial rate and effective date are set to 
            // 0.0000 abd 00/00/0000 respectively
            decimal dRate = 0.00M;
            this.pr_rate.Text = dRate.ToString("0.00000");

            // Make sure no piece rate types are selected initially
            // Disable the Save button until one is selected (see dw_prt_Clicked 
            // and dw_prt_RowFocusChanged).
            dw_prt.SelectAllRows(false);
            cb_save.Enabled = false;
        }

        public virtual void dw_prt_constructor()
        {
            dw_prt.Retrieve();
            
            dw_prt.SetCurrent(0);
            dw_prt.of_SetUpdateable(false);

            nCurrentRow = dw_prt.GetRow();
        }

        #region Methods
        #endregion

        #region Events
        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            // When we close, we don't even try to save anything
            StaticVariables.gnv_app.of_get_parameters().integerparm = 0;
            Close();
        }

        private void dw_prt_Click(object sender, EventArgs e)
        {
            // Note: The first time a piece rate type is selected, if it the first
            // one, the RowFocusChanged event doesn't fire because the focus hasn't
            // changed.  This Click event does fire, so we fake it.

            dw_prt_RowFocusChanged(sender, e);
        }

        private void dw_prt_RowFocusChanged(object sender, EventArgs e)
        {
            // Hack to ensure only one piece rate type can be selected
            
            // Find the row the user has selected
            int nSelectedRow = dw_prt.GetRow();
            //MessageBox.Show("Selected row = " + nSelectedRow.ToString());

            // Unselect all rows (the user may have held the control and/or shift keys
            // down selecting more than one row - the last one clicked is the nSelectedRow)
            dw_prt.SelectAllRows(false);

            // Re-select the nSelectedRow.  NOTE: GetRow() seems to be zero-based while 
            // SelectRow() seems to be one-based, hence the "+1".
            dw_prt.SelectRow(nSelectedRow + 1, true);

            // Now we enable the Save button and shift focus to it
            cb_save.Enabled = true;
            cb_save.Select();
        }

        private void pr_effective_date_Leave(object sender, EventArgs e)
        {
            // Validate the effective date whenever we shift focus away from it
            string sEffDate = this.pr_effective_date.Text;
            bool b = validate_effective_date(sEffDate);
        }

        private void pr_rate_Leave(object sender, EventArgs e)
        {
            // Validate the rate whenever we shift focus away from it
            string sRate = this.pr_rate.Text;
            bool b = validate_rate(sRate);
        }
        #endregion

        private bool validate_effective_date(string sInDate)
        {
            // Date expected to be in "dd/mm/yyyy" format
            DateTime dtEffDate = DateTime.MinValue;
            DateTime dtMinDate = DateTime.Parse("01/01/2000");

            if (!DateTime.TryParse(sInDate, out dtEffDate))
            {
                MessageBox.Show(sInDate + "  is an invalid date." + "\n"
                    + "Please enter a date in dd/mm/yyyy format."
                    , "Error");
                return false;
            }
            if (dtEffDate < dtMinDate)
            {
                MessageBox.Show(sInDate + "  is an invalid date." + "\n"
                    + "The effective date may not be earlier than 01/01/2013."
                    , "Error");
                return false;
            }
            return true;
        }

        private bool validate_rate(string sInRate)
        {
            // Rate expected to be decimal format
            decimal dRate = decimal.MinValue;

            if (! decimal.TryParse(sInRate, out dRate))
            {
                MessageBox.Show(sInRate + "  is invalid." + "\n"
                    + "Please enter a decimal number."
                    , "Error");
                return false;
            }

            if ( dRate < 0 )
            {
                MessageBox.Show(sInRate + "  is invalid." + "\n"
                    + "The rate may not be less than 0.00."
                    , "Error");
                return false;
            }
            return true;
        }

        private void cb_save_Click(object sender, EventArgs e)
        {
            // Save the new piece rate types and exit.

            string sRate = this.pr_rate.Text;
            string sEffDate = this.pr_effective_date.Text;
            bool bInactive = cb_inactive.Checked;
            int nSelectedRow = dw_prt.GetRow();
            int nPrtKey = (int)dw_prt.GetItem<DddwPieceRateTypes>(nSelectedRow).PrtKey;
            string sPrtDescription = dw_prt.GetItem<DddwPieceRateTypes>(nSelectedRow).PrtDescription;
            bool okToGo = true;
            string sRgDescription;
            int nRGCode;
            DateTime dtPrEffectiveDate;
            decimal dPrRate;
            string sPrActive;
/*************************************************************************************
            MessageBox.Show("Selected row = " + nSelectedRow.ToString() + "\n"
                            + "Type = " + sPrtDescription + "(" + nPrtKey.ToString() + ")\n"
                            + "Rate = " + sRate + "\n"
                            + "Date = " + sEffDate + "\n"
                            + "Inactive = " + bInactive.ToString()
                            , "cb_save_clicked");
**************************************************************************************/

            if (cb_save.Enabled == false)
            {
                MessageBox.Show("Please select a new piece rate type.", "Warning");
                return;
            }

            // See how many renewal groups were selected; ask that at least one be.
            // NOTE: the current renewal group is selected initially but the user COULD unselect it.
            int nRgs = checkedListBox1.CheckedItems.Count;
            if (nRgs < 1)
            {
                MessageBox.Show("Please select at least one renewal group.", "Warning");
                return;
            }

            // Check that a rate and effective date have been entered
            // NOTE there's no check on the date range.  
            //      Note too, they have probably already been validated.
            if ((validate_rate(sRate) == false)
                || (validate_effective_date(sEffDate) == false))
                okToGo = false;

            // We can't validate the Active status, and the Save button isn't 
            // enabled unless a piece rate type has been selected.

            // If the new values haven't been validated, we won't save anything.
            // Tell the user.
            if (!okToGo)
            {
                MessageBox.Show("The new rate has not been saved.", "Warning");
                return;
            }

            // Get the data to save
            // We got the piece rate type key earlier (above)
            dtPrEffectiveDate = DateTime.Parse(sEffDate);
            dPrRate = decimal.Parse(sRate);
            sPrActive = (bInactive) ? "N" : "Y";

            // Scan the renewal group checkboxes to determine which to save this piece rate type for
            int nRowsInserted = 0, nRowsFailed = 0;
            int nRC, nRow;
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                nRow = checkedListBox1.CheckedIndices[i];
                sRgDescription = dw_rg.GetItem<DddwRenewalGroups>(nRow).RgDescription;
                nRGCode = (int)dw_rg.GetItem<DddwRenewalGroups>(nRow).RgCode;

                // Attempt to add the piece rate type for this renewal group
                nRC = RDSDataService.AddPieceRate(nPrtKey, nRGCode, dtPrEffectiveDate, sPrActive, dPrRate);

                // Check to see if we were successful
                // Only an attempt to save an already existing record is handled
                // (loss of database connection and other unlikely issues are (currently) ignored)
                if (nRC == 1)
                {
                    nRowsInserted++;
                }
                else
                {
                    MessageBox.Show("Failed to add piece rate for type " + sPrtDescription + "\n"
                            + "Renewal group " + sRgDescription + "\n"
                            + "(type/renewal group already exists)\n"
                            + "\n"
                            + " Please use the Piece Rate tab to add a new rate for this type/renewal group.\n"
                            + "\n"
                            , "Warning"
                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nRowsFailed++;
                }
            }

            // Tell the user what happened.  The details of any problems have been displayed (above);
            // here we just give a summary.  If nothing was saved, don't exit; the user may
            // want to make corrections.
            string msg, title;
            if (nRowsInserted < 1)
            {
                msg = "No new piece rate types added.";
                title = "Warning";
                return;
            }
            else
            {
                msg = nRowsInserted.ToString() + " new piece rate ";
                msg += (nRowsInserted > 1) ? "types added." :  "type added.";
                title = "Save succeeded";
                if (nRowsFailed > 0)
                {
                    msg += "\n" + nRowsFailed.ToString();
                    msg += (nRowsFailed > 1) ? " were not added." : " was not added.";
                    title = "Warning";
                }
            }
            MessageBox.Show(msg,title);

            // If at least one new record was saved, exit.
            // We return the number of saved records so the caller can update its display
            // (assumes a record was saved for the current renewal group).
            StaticVariables.gnv_app.of_get_parameters().integerparm = nRowsInserted;
            Close();
        }
    }
}