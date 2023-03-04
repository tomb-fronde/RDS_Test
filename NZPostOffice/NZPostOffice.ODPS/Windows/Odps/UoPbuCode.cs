using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using NZPostOffice.ODPS.Windows.OdpsLib;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.Windows.Odps
{
    // TJB  RPCR_113  July-2018
    // Added PbuCode_validation() and reference in ue_save
    // to validate email addresses and block save until uncorrected
    //
    // TJB  RPCR_054  July-2013
    // Added ue_save

    public partial class UoPbuCode : UDrilldownList
    {
        public UoPbuCode()
        {
            InitializeComponent();
        }

        public UoPbuCode(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //added by jlwang
        public override void ue_new()
        {
            //base.ue_new();
            //MessageBox.Show("ue_new", "UoPbuCode");
            this.dw_selection.InsertItem<PbuCode>(this.dw_selection.RowCount);
            this.dw_selection.Focus();
            this.dw_selection.SetCurrent(this.dw_selection.RowCount);
        }

        // TJB  RPCR_054  July-2013: Added
        public override void ue_save()
        {
            // MessageBox.Show("Save", "UoPbuCode");
            int rc = PbuCode_validation();
            if (rc == 1)
            {
                this.dw_selection.Save();
            }
        }

        // TJB  RPCR_113  July-2018  New
        // Validates all email addresses when being saved
        // (also, individual email addresses validated as entered in WCodeTableMaintenance)
        public virtual int PbuCode_validation()
        {
            int iRet = 1;
            int nErrors = 0;
            string email_error = "";
            string sError = "";
            string pbu_code = "";
            string pbu_email_1 = "", pbu_email_2 = "", pbu_email_3 = "";

            //this.ProcessDialogKey(Keys.Tab);
            int nRows = this.dw_selection.RowCount;

            //MessageBox.Show("UoPbuCode.PbuCode_validation\n"
            //                + nRows.ToString() + " rows to check");

            for (int nRow = 0; nRow < nRows; nRow++)
            {
                pbu_code = this.dw_selection.GetItem<PbuCode>(nRow).Pbucode;
                pbu_email_1 = this.dw_selection.GetItem<PbuCode>(nRow).PbuEmail1;
                pbu_email_2 = this.dw_selection.GetItem<PbuCode>(nRow).PbuEmail2;
                pbu_email_3 = this.dw_selection.GetItem<PbuCode>(nRow).PbuEmail3;

                /* Debugging 
                    string spbu_email_1 = "", spbu_email_2 = "", spbu_email_3 = "";

                    spbu_email_1 = NullOrEmpty( pbu_email_1 );
                    spbu_email_2 = NullOrEmpty( pbu_email_2 );
                    spbu_email_3 = NullOrEmpty( pbu_email_3 );

                    if (nRow == 1 || nRow == (nRows - 1))
                    {
                        MessageBox.Show("WCodeTableMaintenance.PbuCode_validation\n"
                                    + "Row = " + nRow.ToString() + "\n"
                                    + "pbu_code = " + pbu_code + "\n"
                                    + "pbu_email_1 = " + spbu_email_1 + "\n"
                                    + "pbu_email_2 = " + spbu_email_2 + "\n"
                                    + "pbu_email_3 = " + spbu_email_3 + "\n"
                                    );
                    }
                */

                if (!string.IsNullOrEmpty(pbu_email_1)) // && !string.IsNullOrEmpty(pbu_email_1.Trim()))
                {
                    if (!Regex.IsMatch(pbu_email_1, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$"))
                    {
                        sError = NullOrEmpty( pbu_email_1 );
                        email_error += pbu_code + ": pbu_email_1 = " + sError + "\n";
                        //email_error += pbu_code + ": " + spbu_email_1 + "\n";
                        nErrors++;
                    }
                }
                if (!string.IsNullOrEmpty(pbu_email_2)) // && !string.IsNullOrEmpty(pbu_email_2.Trim()))
                {
                    if (!Regex.IsMatch(pbu_email_2, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$"))
                    {
                        sError = NullOrEmpty( pbu_email_2 );
                        email_error += pbu_code + ": pbu_email_2 = " + sError + "\n";
                        //email_error += pbu_code + ": " + spbu_email_2 + "\n";
                        nErrors++;
                    }
                }
                if (!string.IsNullOrEmpty(pbu_email_3)) // && !string.IsNullOrEmpty(pbu_email_3.Trim()))
                {
                    if (!Regex.IsMatch(pbu_email_3, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$"))
                    {
                        sError = NullOrEmpty( pbu_email_3 );
                        email_error += pbu_code + ": pbu_email_3 = " + sError + "\n";
                        //email_error += pbu_code + ": " + spbu_email_3 + "\n";
                        nErrors++;
                    }
                }
            }
            if (nErrors > 0)
            {
                string sPlural = (nErrors > 1) ? "s" : "";

                MessageBox.Show(nErrors.ToString() + " email address error" + sPlural + " found.\n\n"
                                + email_error + "\n"
                                + "Please correct before saving."
                                , "Validation Error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                iRet = -1;
            }
            /* Debugging
                else
                    MessageBox.Show("No email address errors found.\n");
            */

            return iRet;
        }

        // TJB  RPCR_113  July 2018  New
        string NullOrEmpty(string pTemp)
        {
            string sTemp;

            sTemp = pTemp;
            if (pTemp == null)
                sTemp = "null";
            else if (pTemp.Trim() == "")
                sTemp = "empty";

            return sTemp;
        }
    }
}
