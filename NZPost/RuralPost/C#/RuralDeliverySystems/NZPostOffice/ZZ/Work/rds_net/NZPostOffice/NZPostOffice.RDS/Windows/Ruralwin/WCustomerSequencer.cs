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
using System.IO;
using System.Collections.Generic;
using NZPostOffice.Shared.Managers;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    // TJB  RPCR_105  May-2016
    // Add the ability to change the contract number associated with an 
    // address in the unsequenced panel.  
    // See cb_reassign_Click and WReassignContractNo
    //
    // TJB  RPCR_026  Aug-2011: Fixup
    // If the address number includes a flat number, put the value in quotes
    //
    // TJB RPCR_026  June-2011
    //     Added nContractStripHeight and GetDefaultStripHeight().
    //     Add the flat number to the address number as <flat>-<addrno> 
    //     if there is a flat number.
    //     Added frozen checkbox and functionality.
    //     Changed sequence number to display address seq_num instead of
    //     route sequence.  Changes selection to select groups of addresses
    //     with same seq_num as though one address, for moves, skipping over, etc.
    //
    // TJB Feb-2011 Release 7.1.5 fixups
    //     Fixed a couple of bugs in how filenames and directories were handled
    //     in cb_stripmaker_clicked().
    //     Added GetParentPath()
    //
    // TJB Jan-2011  Sequencing review
    //     Modified selection and sequencing algorithm.
    //     Added 'arror' buttons and 'Sequence at end' and 'Reverse sequence' buttons.
    //     Manages sequences for whole contract (not by frequency within contract)
    //     Called from Address tab in Contract details window.

    public partial class WCustomerSequencer : WAncestorWindow
    {
        #region Define
        public int? il_contract_no;
        public string is_post_code;  // TJB RPCR_105 May-2016: Added

        public int? il_sf_key;

        public string is_delivery_days = String.Empty;

        public int il_sequence = 0;
        public int ig_sequence = 0;

        public int ib_multiple_contracts;  // TJB  RPCR_105 May-2016: added

        //  Stripmaker output files directory 
        public string is_filedir = String.Empty;

        //  Stripmaker header filename 
        public string is_headerfile = String.Empty;

        //  Stripmaker street filename 
        public string is_streetfile = String.Empty;

        //  Stripmaker delivery point filename 
        public string is_deliveryfile = String.Empty;

        //  Stripmaker ini file full filename 
        public string is_inifile = String.Empty;

        public string is_userid = String.Empty;

        public URdsDw idw_seq;

        public URdsDw idw_unseq;

        public URdsDw idw_addr_sequence_ind;

        public URdsDw dw_addr_sequence_ind;

        public List<int> seqSelected = new List<int>();

        public List<int> unseqSelected = new List<int>();
        #endregion

        public WCustomerSequencer()
        {
            this.InitializeComponent();

            this.Closing += new System.ComponentModel.CancelEventHandler(this_form_closing);

            this.dw_addr_sequence_ind.DataObject = new DAddrSequenceInd();
            dw_addr_sequence_ind.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_addr_sequence_ind_constructor);
            ((DAddrSequenceInd)dw_addr_sequence_ind.DataObject).CheckedChanged += new EventHandler(dw_addr_sequence_ind_itemchanged);

            this.dw_seq.DataObject = new DSeqAddresses();
            dw_seq.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_seq.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_seq_constructor);
            //((DSeqAddresses)dw_seq.DataObject).CellMouseDown += new DataGridViewCellMouseEventHandler(dw_seq_MouseDown);
            ((Metex.Windows.DataEntityGrid)(this.dw_seq.GetControlByName("grid"))).Click += new EventHandler(dw_seq_Click);
            
            this.dw_unseq.DataObject = new DUnseqAddresses();
            dw_unseq.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_unseq.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_unseq_constructor);
            //((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).CellMouseDown += new DataGridViewCellMouseEventHandler(dw_unseq_CellMouseDown);
            ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).Click += new EventHandler(dw_unseq_clicked);

            this.cb_seq_arrow.Click += new System.EventHandler(this.cb_seq_arrow_Click);
            this.cb_unseq_arrow.Click += new System.EventHandler(this.cb_unseq_arrow_Click);

            this.cb_sequence.Click += new System.EventHandler(this.cb_sequence_Click);
            this.cb_unsequence.Click += new System.EventHandler(this.cb_unsequence_Click);
            this.cb_addseq.Click += new System.EventHandler(this.cb_addseq_Click);
            this.cb_reverse.Click += new System.EventHandler(this.cb_reverse_Click);

            this.cb_up_arrow.Click += new System.EventHandler(this.cb_up_arrow_Click);
            this.cb_down_arrow.Click += new System.EventHandler(this.cb_down_arrow_Click);
            this.cb_stripmaker.Click += new System.EventHandler(this.cb_stripmaker_clicked);

            this.cb_reassign.Click += new System.EventHandler(this.cb_reassign_Click);
        }

        public void this_form_closing(Object s, System.ComponentModel.CancelEventArgs e)
        {
            dw_seq.ResetUpdate();
            dw_unseq.ResetUpdate();
            dw_addr_sequence_ind.ResetUpdate();
            
            return;
        }

        public override void close()
        {
            base.close();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            string ls_con_title;
            NParameters lnv_Parameters;
            lnv_Parameters = (NParameters)StaticMessage.PowerObjectParm;
            il_contract_no = lnv_Parameters.longparm;
            il_sf_key = lnv_Parameters.integerparm;
            is_delivery_days = lnv_Parameters.stringparm;
            //  TJB - testing
            //  messagebox('w_customer_sequencer.pfc_preopen',  &
            //   				'     Contract = '+il_contract_no.ToString()+'\n'  &
            //   			 + '       sf_key = '+il_sf_key.ToString()+'\r'  &
            //   			 + 'Delivery_Days = '+is_delivery_days )

            // select con_title into :ls_con_title from contract where contract_no = :il_contract_no using SQLCA; 
            RDSDataService dataService = RDSDataService.GetContractConTitle(il_contract_no);
            ls_con_title = dataService.strVal;
            this.Text = "Contract " + il_contract_no.ToString() + " - " + ls_con_title; 
            //? of_setlogicalunitofwork(true);
        }

        public override void open()
        {
            base.open();
            // TJB  SR4691  Aug 2006
            // dw_addr_sequence_ind added
            //!idw_seq.Retrieve(new object[]{il_contract_no, il_sf_key, is_delivery_days });
            ((DSeqAddresses)idw_seq.DataObject).Retrieve(il_contract_no);
            ((DUnseqAddresses)idw_unseq.DataObject).Retrieve(il_contract_no);
            idw_seq.SelectRow(0, false);
            idw_unseq.SelectRow(0, false);
            ((DAddrSequenceInd)idw_addr_sequence_ind.DataObject).Retrieve(il_contract_no, null, "");
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            dw_unseq.URdsDw_GetFocus(null, null);
            dw_seq.URdsDw_GetFocus(null, null);
            is_userid = StaticVariables.LoginId;
            
            // TJB  RPCR_026  July-2011
            // Disable the frozen checkbox unless the user is a member of a group for
            // which the 'Address Sequence Freeze' Modify ('M') component/permission 
            // is set.
            string s_frozen_perms = of_getpermissions("Address Sequence Freeze");
            Control frozen_ind = dw_addr_sequence_ind.GetControlByName("rf_frozen_ind");
            //MessageBox.Show("Address Sequence Frozen permissions = " + s_frozen_perms + "\n"
            //                , "pfc_postopen");
            if ((s_frozen_perms != null) && (s_frozen_perms.IndexOf('M') >= 0))
                frozen_ind.Enabled = true;
            else
                frozen_ind.Enabled = false;

            // TJB  RPCR_105  May-2016
            // If there are any unsequenced addresses ...
            // Check to see if this any other contracts share the same post code
            // If so, check to see if any of the addresses could potentially be 
            // in either contract (this address may have been newly added and 
            // automatically assigned to the wrong contract).
            // If so, set a flag to say so.  This is used when an address is selected 
            // to check for potentially being in either contract (again) and 
            // making the cb_reassign button visible (and thus allowing the address 
            // to be reassigned to the other contract).
            cb_reassign.Enabled = false;
            if (idw_unseq.RowCount > 0)
            {
                int n = RDSDataService.GetNumPostCodeContracts((int)il_contract_no);
                if (n > 1)
                {
                    cb_reassign.Enabled = true;
                    for (int nRow = 0; nRow < idw_unseq.RowCount; nRow++)
                    {
                        int nAdrId = this.dw_unseq.GetValue<int?>(nRow, "AdrId").GetValueOrDefault();
                        RDSDataService dataService = RDSDataService.GetAddressPostCode(nAdrId);
                        is_post_code = dataService.strVal;
                        /************************** Testing ******************************
                        MessageBox.Show("Row " + nRow.ToString() + "\n"
                                       + "AdrID  " + nAdrId.ToString() + "\n"
                                       + "Contract " + il_contract_no.ToString() + "\n"
                                       + "Post Code " + is_post_code
                                       , "Testing: pfc_postopen");
                        /************************** Testing ******************************/
                        break;
                    }
                }
            }
        }

        public override int pfc_save()
        {
            int ll_rc = SUCCESS;
            int? ll_rc1;
            int? ll_ind;
            int nRow;
            int nRows;
            int? nSeqNum;
            int nAdrId;
            RDSDataService dataService;

            //  PBY 03/09/2002 SR#4417 
            //  moved the save processing from cb_save.click to here to allow
            //  save to kick in if user closes the window by pressing the "x" icon 
            //  TJB  SR4691  Aug 2006
            //  Add condition on saving of sequence
            //  - do only if changed (previously assumed any change was 
            //    to the address sequence)
            //  TJB  SR4691  fixup (unsequenced addresses weren't being saved)
            //  Re-wrote process to use PB's update function for sequencing
            //  and explicit delete for unsequencing.  Involved modifying 
            //  d_seq_address and d_unseq_address (add columns so the 
            //  update could be done by PB).
            // =====> undid change, hopefully temporarily  25 Aug 2006 <=====
            //  Used to decide whether to also save the validation indicator
            //  Also used to determine which status to return.
            ll_rc = SUCCESS;

            //  TJB  SR4691 fixup
            //  Added dw_unseq.modifiedCount to fix failure to save
            //  unsequenced addresses (but this process is deathly slow!).

           if (StaticFunctions.IsDirty(dw_seq))
            {
                nRows = dw_seq.RowCount;
                if (ll_rc == SUCCESS && nRows > 0)
                {
                    for (nRow = 0; nRow < nRows; nRow++)
                    {
                        nSeqNum = dw_seq.GetItem<SeqAddresses>(nRow).SeqNum;
                        nAdrId = (int)dw_seq.GetItem<SeqAddresses>(nRow).AdrId;
                        //* update address set seq_num = :nSeqNum
                        //*  where adr_id = :nAdrId
                        //dataService = RDSDataService.InsertAddressFreqSeq(il_sf_key, ll_sequence_no, il_contract_no, ll_address_id, is_delivery_days);
                        dataService = RDSDataService.UpdateAddressSeq(nSeqNum, nAdrId);
                        if (dataService.SQLCode != 0)
                        {
                            MessageBox.Show("Unable to update new route sequence.  \n\n"
                                        + "Error Code: " + dataService.SQLCode + "\n"
                                        + "Error Text: " + dataService.SQLErrText
                                        + "Parameters: \n"
                                        + "   adr_id = " + nAdrId.ToString() + "\n"
                                        + "   seq_no = " + nSeqNum.ToString()
                                        , "Database Error"
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //? RollBack;
                            ll_rc = FAILURE;
                            break;
                        }
                    }
                    if (ll_rc == SUCCESS)
                    {
                        //? COMMIT;
                    }
                }
            }
            if (StaticFunctions.IsDirty(dw_unseq))
            {
                nSeqNum = null;
                nRows = dw_unseq.RowCount;
                if (ll_rc == SUCCESS && nRows > 0)
                {
                    for (nRow = 0; nRow < nRows; nRow++)
                    {
                        nAdrId = (int)dw_unseq.GetItem<UnseqAddresses>(nRow).AdrId;
                        //* update address
                        //*    set seq_num = null
                        //*  where adr_id = :nAdrId
                        dataService = RDSDataService.UpdateAddressSeq(nSeqNum, nAdrId);
                        if (dataService.SQLCode != 0)
                        {
                            MessageBox.Show("Unable to update unsequenced addresses.  \n\n"
                                        + "Error Code: " + dataService.SQLCode + "\n"
                                        + "Error Text: " + dataService.SQLErrText
                                        + "Parameters: \n"
                                        + "   adr_id = " + nAdrId.ToString() + "\n"
                                        , "Database Error"
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //? RollBack;
                            ll_rc = FAILURE;
                            break;
                        }
                    }
                    if (ll_rc == SUCCESS)
                    {
                        //? COMMIT;
                    }
                }
            }

            // 
            //  TJB  SR4691
            //  If the validation indicator has been changed and the sequence 
            //  save succeeded (or if there were no sequence changes to save) 
            //  save the validation indicator changes.
            //  If the sequence save failed, turn the validation indicator off
            //  if it isn't already.
            //  (we assume either update will succeed and only return the 
            //   sequence save status)
            if (ll_rc == SUCCESS)
            {
                if (StaticFunctions.IsDirty(idw_addr_sequence_ind))
                {
                    ll_rc1 = SUCCESS;
                    idw_addr_sequence_ind.Save();

                    if (!(ll_rc1 == SUCCESS))
                    {
                        MessageBox.Show("Failed to save validation indicator - continuing."
                                        , "Warning"
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                ll_ind = idw_addr_sequence_ind.GetItem<AddrSequenceInd>(0).RfValidInd;
                if (!(ll_ind == null || ll_ind == 0))
                {
                    idw_addr_sequence_ind.GetItem<AddrSequenceInd>(0).RfValidInd = 0;
                    idw_addr_sequence_ind.GetItem<AddrSequenceInd>(0).RfValidDate = System.DateTime.Today;
                    idw_addr_sequence_ind.GetItem<AddrSequenceInd>(0).RfValidUser = is_userid;
                    idw_addr_sequence_ind.Save();
                }
            }
            return ll_rc;
        }

        public virtual void pfc_validation(object[] apo_control)
        {
            return; //? return SUCCESS;
        }

        public virtual void dw_unseq_constructor()
        {
            dw_unseq.of_SetUpdateable(true);
            dw_unseq.of_SetRowSelect(true);
            // inv_rowselect.of_SetStyle(1);
            idw_unseq = dw_unseq;
            idw_unseq.of_SetStyle(1);
        }

        public virtual void dw_unseq_itemerror()
        {
            return;
        }

        public virtual void dw_seq_constructor()
        {
            //? dw_seq.of_SetUpdateable(true);
            dw_seq.of_SetRowSelect(true);
            // inv_rowselect.of_SetStyle(1);
            idw_seq = dw_seq;
            idw_seq.of_SetStyle(1);
        }

        #region Methods
        public virtual int lf_getinisection(string as_file, ref List<string> as_sections)
        {
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Function:  		of_GetSections
            // 
            // 	Access:  		public
            // 
            // 	Arguments:	
            //  as_file			The .ini file.
            // 	as_sections[]	An array of strings passed by reference.  This will store
            // 						the section names retrieved from the .INI file
            // 
            // 	Returns:			Integer
            // 						 #	the number of sections retrieved
            // 						-1	error
            // 						-2 if .INI file does not exist or has not been specified.
            // 
            // 	Description:  	Retrieves all sections from an .INI file
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Revision History
            // 
            // 	Version
            // 	5.0   Initial version
            //  5.0.02 Initialize sections array to blanks at start of function
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Copyright © 1996-1997 Sybase, Inc. and its subsidiaries.  All rights reserved.
            // 	Any distribution of the PowerBuilder Foundation Classes  ( PFC)
            // 	source code by other than Sybase, Inc. and its subsidiaries is prohibited.
            // 
            // ////////////////////////////////////////////////////////////////////////////
            int ll_length;
            StreamReader li_file;
            int ll_pos;
            int ll_first;
            int ll_last;
            int li_section = 0;
            string ls_line = "";
            string ls_section;
            List<string> ls_sections = new List<string>();
            //? NCstString lnv_string;
            Cursor.Current = Cursors.WaitCursor;
            //  Determine if file exists
            if (!(File.Exists(as_file)))
            {
                return -(2);
            }
            //  Open file
            ll_length = (int)new FileInfo(as_file).Length;
            try
            {
                li_file = new StreamReader(as_file, false);
            }
            catch (Exception)
            {
                return -1;
            }
            //  reset the array coming in
            as_sections = ls_sections;
            // ////////////////////////////////////////////////////////////////////////////
            //  Retrieve all section names in the file
            // ////////////////////////////////////////////////////////////////////////////
            while (ls_line != null)
            {
                ls_line = li_file.ReadLine();
                ll_first = ls_line.IndexOf('[');
                ll_last = ls_line.IndexOf(']');
                if (ll_first > 0 && ll_last > 0)
                {
                    ls_line = ls_line.TrimStart();
                    if (ls_line.Substring(0, 1) == "[")
                    {
                        ll_pos = ls_line.IndexOf(']');
                        ls_section = ls_line.Substring(1, ll_pos - 2);
                        li_section++;
                        as_sections[li_section] = ls_section;
                    }
                }
            }
            //  Close file and return
            li_file.Close();
            return li_section;
        }

        public virtual int lf_getinikeyvalues(string as_file, string as_section, ref List<string> as_keys, ref List<string> as_values)
        {
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Function:  		lf_getIniKeyValues
            // 
            // 	Arguments:	
            // 	as_ini			The .ini file.
            // 	as_section		The section name to retrieve keys from
            // 	as_keys[]		An array of strings passed by reference.  This will store the 
            // 							key names retrieved from the .INI file
            // 	as_values[]		An array of strings passed by reference.  This will store the 
            // 							key values retrieved from the .INI file
            // 
            // 	Returns:			Integer
            // 						The number of keys retrieved
            // 						 0	if there are no keys that exist for section, or section does not exist
            // 						-1	file error
            // 						-2	if .INI file has not been specified or does not exist.  
            // 
            // 	Description:  	Retrieves all keys and their values from a specified section.
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Revision History
            // 
            //  Dec 2004  TJB  Adapted from the pfc of_getKeys function
            // 
            // ////////////////////////////////////////////////////////////////////////////
            bool lb_sectionfound = false;
            StreamReader li_file = null;
            int li_keys = 0;
            int ll_pos;
            int ll_first;
            int ll_last;
            int ll_equal;
            int ll_length;
            string ls_line = "";
            string ls_key;
            string ls_value;
            string ls_section;
            string ls_comment;
            List<string> ls_keys = new List<string>();
            List<string> ls_values = new List<string>();
            Cursor.Current = Cursors.WaitCursor;
            //  Verify that .INI file name has been specified.
            if (!(File.Exists(as_file)))
            {
                return -(2);
            }
            //  Open file  ( check rc).
            try
            {
                ll_length = (int)new FileInfo(as_file).Length;
                li_file = new StreamReader(as_file);
            }
            catch
            {
                return -1;
            }
            //  reset the arrays coming in
            as_keys = ls_keys;
            as_values = ls_values;
            // ////////////////////////////////////////////////////////////////////////////
            //  Find the correct section name
            // ////////////////////////////////////////////////////////////////////////////
            while (ls_line != null && !lb_sectionfound)
            {
                //  Read one line from the inifile  ( check rc).
                ls_line = li_file.ReadLine();
                //  Check if any characters were read.
                if (ls_line != null)
                {
                    //  Look for a section header components (the OpenBracket and CloseBracket (if any)).
                    ll_first = ls_line.IndexOf('[');
                    ll_last = ls_line.IndexOf(']');
                    //  Was a section header found?		
                    if (ll_first >= 0 && ll_last >= 0)
                    {
                        //  Yes, a section header has been found.
                        //  Get the name of the section.
                        ls_line = ls_line.TrimStart();
                        if (ls_line.Substring(0, 1) == "[")
                        {
                            ll_pos = ls_line.IndexOf(']');
                            ls_section = ls_line.Substring(1, ll_pos - 1);
                            //  Determine if this is the section being searched for.								
                            if (ls_section.ToLower() == as_section.ToLower())
                            {
                                //  The search for section has been found.
                                lb_sectionfound = true;
                            }
                        }
                    }
                }
            }
            // ////////////////////////////////////////////////////////////////////////////
            //  Retrieve all keys and their values for the section
            // ////////////////////////////////////////////////////////////////////////////
            if (lb_sectionfound)
            {
                lb_sectionfound = false;
                while (ls_line != null && !lb_sectionfound)
                {
                    //  Read one line from the file (validate the rc).
                    ls_line = li_file.ReadLine();
                    //  Check if any characters were read.		
                    if (ls_line != null)
                    {
                        //  Check for a "commented" line (skip if found).
                        ls_comment = ls_line.TrimStart();
                        if (ls_comment == "" || ls_comment.ToCharArray()[0] == ';')
                        {
                            continue;
                        }
                        //  Parse the line.  Look for lines like
                        // 		key = value
                        // 		[ new_section ]
                        // 		key
                        //  Blank lines will be skipped
                        ll_equal = ls_line.IndexOf('=');
                        if (ll_equal >= 0)
                        {
                            ls_key = ls_line.Substring(0, ll_equal).Trim();
                            ls_value = ls_line.Substring(ll_equal + 1).Trim();
                            if (ls_key.Length > 0)
                            {
                                li_keys++;
                                as_keys.Add(ls_key);//as_keys[li_keys] = ls_key;
                                if (ls_value.Length > 0)
                                {
                                    as_values.Add(ls_value);//as_values[li_keys] = ls_value;
                                }
                                else
                                {
                                    as_values.Add("");//as_values[li_keys] = "";
                                }
                            }
                        }
                        else if (ls_line.IndexOf('[') >= 0)
                        {
                            ll_first = ls_line.IndexOf('[');
                            ll_last = ls_line.IndexOf(']');
                            if (ll_first >= 0 && ll_last >= 0)
                            {
                                ls_line = ls_line.TrimStart();
                                if (ls_line.Substring(0, 1) == "[")
                                {
                                    lb_sectionfound = true;
                                }
                            }
                        }
                        else
                        {
                            ls_key = ls_line.Trim();
                            if (ls_key.Length > 0)
                            {
                                li_keys++;
                                as_keys[li_keys] = ls_key;
                                as_values[li_keys] = "";
                            }
                        }
                    }
                }
            }
            // ////////////////////////////////////////////////////////////////////////////
            //  Close file and return
            // ////////////////////////////////////////////////////////////////////////////
            li_file.Close();
            return li_keys;
        }

        public virtual void wf_removesequence(int al_row)
        {
            int? lSeq;
            int  nextSeq;

            if (al_row >= 0)
            {
                // Find the sequence number of the row being unsequenced
                lSeq = dw_unseq.GetItem<UnseqAddresses>(al_row).Sequence;
                if (!(StaticFunctions.f_nempty(lSeq)))
                {
                    // Clear this row's sequence number
                    dw_unseq.GetItem<UnseqAddresses>(al_row).Sequence = null;
                    //dw_unseq.SuspendLayout();
                    // While the sequence number is less than the new new one ...
                    while (lSeq <= il_sequence)
                    {
                        nextSeq = (int)lSeq + 1;
                        // Scan the unsequenced list for the row with the next sequence number
                        for (int row = 0; row < dw_unseq.RowCount; row++)
                        {
                            // If found, drop out of scan with the lRow flag set
                            if (dw_unseq.GetItem<UnseqAddresses>(row).Sequence == nextSeq)
                            {
                                dw_unseq.GetItem<UnseqAddresses>(row).Sequence = lSeq;
                                lSeq++;
                                break;
                            }
                        }
                    }
                    nextSeq = (int)lSeq + 1;
                }
            }
        }

        public virtual void lf_cleanup()
        {
            //  TJB SR4461 Dec 2004
            //  Delete any Stripmaker files that may exist
            if (File.Exists(is_filedir + is_headerfile))
            {
                new FileInfo(is_filedir + is_headerfile).Delete();
            }
            if (File.Exists(is_filedir + is_streetfile))
            {
                new FileInfo(is_filedir + is_streetfile).Delete();
            }
            if (File.Exists(is_filedir + is_deliveryfile))
            {
                new FileInfo(is_filedir + is_deliveryfile).Delete();
            }
        }

        //bool result = false;
        //void dw_unseq_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex != -1)//! catches case if enter the header or other element but a cell
        //    {
        //        result = (dw_unseq.DataObject.Controls[0] as DataEntityGrid).Rows[e.RowIndex].Selected;
        //    }
        //}

        private bool EmptyFilter(Metex.Core.IEntity item)
        {
            return true;
        }

        public virtual void dw_addr_sequence_ind_constructor()
        {
            dw_addr_sequence_ind.of_SetUpdateable(true);
            //? dw_addr_sequence_ind.SetTrans(StaticVariables.sqlca);
            idw_addr_sequence_ind = dw_addr_sequence_ind;
        }

        private Boolean dw_unseq_filter(UnseqAddresses item)
        {
            if (item.Sequence > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Events
        public void dw_unseq_Click(object sender, EventArgs e)
        {
            if (dw_unseq.RowCount == 0)
            {
                return;
            }

            DataGridViewSelectedRowCollection rowsSelected
                         = ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).SelectedRows;
            int n1 = rowsSelected.Count;
            int t1 = n1;
            int t2 = t1;
        }

        public virtual void dw_unseq_clicked(object sender, EventArgs e)
        {
            int nAdrId, nRow, nRows, rowIndex;
            // dUnSeqSelectedRows:  Index is rowIndex; value is AdrId.
            // (The AdrId can appear multiple times while the rowIndex is unique;
            //  thus nAdrId cannot be used as the dictionary's index)
            Dictionary<int, int> dUnSeqSelectedRows = new Dictionary<int, int>();

            nRows = dw_unseq.RowCount;
            if (nRows == 0)
            {
                return;
            }
            this.dw_unseq.SuspendLayout();

            //dw_seq.URdsDw_Clicked(sender, e);

            // Find unselected rows where the SeqNum for at least one row
            // has been selected.  Select the others (ie treat all addresses 
            // with the same seq_num as a group (this occurs when an address
            // has more than one primary customer).
            foreach (DataGridViewRow row in ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).SelectedRows)
            {
                rowIndex = row.Index;
                nAdrId = this.dw_unseq.GetValue<int?>(rowIndex, "AdrId").GetValueOrDefault();
                dUnSeqSelectedRows.Add(rowIndex, nAdrId);
            }

            // Scan the address list looking for rows whose SeqNum have been selected in 
            // some row but not in this row.
            for (nRow = 0; nRow < nRows; nRow++)
            {
                nAdrId = this.dw_unseq.GetValue<int?>(nRow, "AdrId").GetValueOrDefault();

                // If the row's SeqNum has been selected, but not this row, select it.
                if (dUnSeqSelectedRows.ContainsValue(nAdrId)
                    && (!dUnSeqSelectedRows.ContainsKey(nRow)))
                {
                    ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid")))[0, nRow].Selected = true;
                }
            }

            // See if any previously-sequenced rows have been de-selected
            // If so, unsequence them.
            for (nRow = 0; nRow < nRows; nRow++)
            {
                if (!(dw_unseq.DataObject.Controls[0] as DataEntityGrid).Rows[nRow].Selected)
                {
                    int? seq = dw_unseq.GetItem<UnseqAddresses>(nRow).Sequence;
                    //if (dw_unseq.GetItem<UnseqAddresses>(nRow).Sequence != null)
                    if (seq != null)
                    {
                        dw_unseq.GetItem<UnseqAddresses>(nRow).Sequence = null;
                    }
                }
            }

            // Add sequence numbers to the selected rows that don't have any
            for (nRow = 0; nRow < nRows; nRow++)
            {
                if ((dw_unseq.DataObject.Controls[0] as DataEntityGrid).Rows[nRow].Selected)
                {
                    if (dw_unseq.GetItem<UnseqAddresses>(nRow).Sequence == null)
                    {
                        il_sequence++;
                        dw_unseq.GetItem<UnseqAddresses>(nRow).Sequence = il_sequence;
                        dw_unseq.AcceptText();
                    }
                }
            }
            nRow = dw_addr_sequence_ind.GetRow();
            int? is_frozen = dw_addr_sequence_ind.GetItem<AddrSequenceInd>(nRow).RfFrozen;

            if (is_frozen == null || is_frozen == 0)
            {
                if (this.dw_unseq.GetSelectedRow(0) < 0)
                {
                    cb_seq_arrow.Enabled = false;
                    cb_sequence.Enabled = false;
                    cb_addseq.Enabled = false;
                    cb_reverse.Enabled = false;
                }
                else
                {
                    cb_seq_arrow.Enabled = true;
                    cb_sequence.Enabled = true;
                    cb_addseq.Enabled = true;
                    cb_reverse.Enabled = true;
                }
            }

            this.dw_unseq.ResumeLayout(true);
            (dw_unseq.DataObject.Controls[0] as DataEntityGrid).Refresh();
            return;
        }

        public void dw_seq_Click(object sender, EventArgs e)
        {
            dw_seq_clicked(sender, e);
        }

        public virtual void dw_seq_clicked(object sender, EventArgs e)
        {
            //string sCustomer, msg = "", msg1 = "";
            //List<int> seqSelectedRows = new List<int>();
            //int nSequence, nSequenceNo, nSeqNum, nRow = 0, rowIndex;
            int nAdrId, nRow, nRows, rowIndex;
            // dSeqSelectedRows:  Index is rowIndex; value is AdrId.
            Dictionary<int, int> dSeqSelectedRows = new Dictionary<int, int>();

            dw_seq.URdsDw_Clicked(sender, e);

            foreach (DataGridViewRow row in ((Metex.Windows.DataEntityGrid)(this.dw_seq.GetControlByName("grid"))).SelectedRows)
            {
                //seqSelectedRows.Add(row.Index);
                rowIndex = row.Index;
                nAdrId = this.dw_seq.GetValue<int?>(rowIndex, "AdrId").GetValueOrDefault();
                dSeqSelectedRows.Add(rowIndex, nAdrId);
                //nSequence = this.dw_seq.GetValue<int?>(rowIndex, "Sequence").GetValueOrDefault();
                //nSequenceNo = this.dw_seq.GetValue<int?>(rowIndex, "SequenceNo").GetValueOrDefault();
                //sCustomer = this.dw_seq.GetValue<string>(rowIndex, "Customer");
                //sCustomer = (sCustomer == null) ? "null" : sCustomer;
                //msg += "\n    Index " + rowIndex.ToString() 
                //        + ": AdrId = " + nAdrId.ToString()
                //        + ", Sequence = " + nSequence.ToString()
                //        + ", Sequence No = " + nSequenceNo.ToString()
                //        + ", Customer = " + sCustomer;
            }
            //MessageBox.Show("Selected rows: \n"
            //                + msg
            //                , "dw_seq_clicked");
            //
            //msg1 = msg = "";

            // Scan the address list looking for rows whose AdrId have been selected in 
            // some row but not in this row.
            nRows = dw_seq.RowCount;
            for (nRow = 0; nRow < nRows; nRow++)
            {
                nAdrId = this.dw_seq.GetValue<int?>(nRow, "AdrId").GetValueOrDefault();

                //msg1 = "    Row " + nRow.ToString();
                //
                //msg1 += ": AdrId " + nAdrId.ToString();
                //
                //if (dSeqSelectedRows.ContainsValue(nAdrId))
                //    msg1 += " found,";
                //else
                //    msg1 += " not found,";
                //
                //if (seqSelectedRows.Contains(nRow))
                //    msg1 += " selected ";
                //else
                //    msg1 += " not selected ";
                //
                //if (dSeqSelectedRows.ContainsValue(nAdrId)
                //    || seqSelectedRows.Contains(nRow))
                //{
                //    msg += msg1 + "\n";
                //    msg1 = "";
                //}

                // If the row's AdrId has been selected, but not this row, select it.
                if (dSeqSelectedRows.ContainsValue(nAdrId)
                    && (! dSeqSelectedRows.ContainsKey(nRow)))
                {
                    ((Metex.Windows.DataEntityGrid)(this.dw_seq.GetControlByName("grid")))[0, nRow].Selected = true;
                }
            }
            //MessageBox.Show("seqSelectedRows.Contains:\n" + msg
            //                , "dw_seq_clicked");

            // Check to see if the address sequence is frozen.
            // Set operation buttons enabled/disabled depending on its setting
            nRow = dw_addr_sequence_ind.GetRow();
            int? is_frozen = dw_addr_sequence_ind.GetItem<AddrSequenceInd>(nRow).RfFrozen;
            if (is_frozen == null || is_frozen == 0)
            {
                // Turn the arrows on and off depending on whether or not there are addresses selected.
                nRows = dSeqSelectedRows.Count;
                if (nRows <= 0)
                {
                    cb_up_arrow.Enabled = false;
                    cb_down_arrow.Enabled = false;
                    cb_unseq_arrow.Enabled = false;
                    cb_unsequence.Enabled = false;
                }
                else
                {
                    cb_up_arrow.Enabled = true;
                    cb_down_arrow.Enabled = true;
                    cb_unseq_arrow.Enabled = true;
                    cb_unsequence.Enabled = true;
                }
            }
        }

        public virtual void cb_seq_clicked(object sender, EventArgs e, bool add_sw)
        {
            //? base.clicked();
            Cursor.Current = Cursors.WaitCursor;
            this.SuspendLayout();
            dw_unseq.AcceptText();

            dw_unseq.DataObject.FilterString = "sequence > 0";

            //! Sort the sequence numbers first so that we insert numbers from the smallest to largest
            List<int> unsequencedItems = new List<int>();
            foreach (DataGridViewRow row in ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).SelectedRows)
            {
                unsequencedItems.Add(this.dw_unseq.GetValue<int?>(row.Index, "Sequence").GetValueOrDefault());
            }
            unsequencedItems.Sort();

            List<int> deleteIndexes = new List<int>();

            if (add_sw)
            {
                int newseq = dw_seq.RowCount;
                foreach (int sortedSequenceNumber in unsequencedItems)
                {
                    foreach (DataGridViewRow row in ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).SelectedRows)
                    {
                        int i = this.dw_unseq.GetValue<int?>(row.Index, "Sequence").GetValueOrDefault();
                        if (i == sortedSequenceNumber)
                        {
                            if (i > 0)
                            {
                                dw_seq.InsertItem<SeqAddresses>(newseq);
                                dw_seq.GetItem<SeqAddresses>(newseq).AdrAlpha = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrAlpha;
                                dw_seq.GetItem<SeqAddresses>(newseq).AdrId = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrId;
                                dw_seq.GetItem<SeqAddresses>(newseq).AdrNo = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrNo;
                                dw_seq.GetItem<SeqAddresses>(newseq).AdrNum = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrNum;
                                dw_seq.GetItem<SeqAddresses>(newseq).AdrNumAlpha = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrNumAlpha;
                                dw_seq.GetItem<SeqAddresses>(newseq).AdrUnit = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrUnit;
                                dw_seq.GetItem<SeqAddresses>(newseq).ContractNo = dw_unseq.GetItem<UnseqAddresses>(row.Index).ContractNo;
                                dw_seq.GetItem<SeqAddresses>(newseq).Customer = dw_unseq.GetItem<UnseqAddresses>(row.Index).Customer;
                                dw_seq.GetItem<SeqAddresses>(newseq).RoadName = dw_unseq.GetItem<UnseqAddresses>(row.Index).RoadName;
                                dw_seq.GetItem<SeqAddresses>(newseq).RoadNameId = dw_unseq.GetItem<UnseqAddresses>(row.Index).RoadNameId;
                                dw_seq.GetItem<SeqAddresses>(newseq).SeqNum = dw_unseq.GetItem<UnseqAddresses>(row.Index).SeqNum;
                                dw_seq.GetItem<SeqAddresses>(newseq).Sequence = (newseq + 1);
                                newseq++;
                                //!dw_unseq.DataObject.DeleteItemAt(row.Index);
                                deleteIndexes.Add(row.Index);
                            }
                        }
                    }
                }
                dw_seq.SetCurrent(newseq - 1);
            }
            else
            {
                int newseq = dw_seq.GetSelectedRow(0);
                newseq = (newseq < 0) ? 0 : newseq;

                foreach (int sortedSequenceNo in unsequencedItems)
                {
                    foreach (DataGridViewRow row in ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).SelectedRows)
                    {
                        int thisSequenceNo = this.dw_unseq.GetValue<int?>(row.Index, "Sequence").GetValueOrDefault();
                        if (thisSequenceNo == sortedSequenceNo)
                        {
                            if (thisSequenceNo > 0)
                            {
                                newseq = (newseq > dw_seq.RowCount) ? dw_seq.RowCount : newseq;

                                dw_seq.InsertItem<SeqAddresses>(newseq);
                                dw_seq.GetItem<SeqAddresses>(newseq).AdrAlpha = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrAlpha;
                                dw_seq.GetItem<SeqAddresses>(newseq).AdrId = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrId;
                                dw_seq.GetItem<SeqAddresses>(newseq).AdrNo = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrNo;
                                dw_seq.GetItem<SeqAddresses>(newseq).AdrNum = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrNum;
                                dw_seq.GetItem<SeqAddresses>(newseq).AdrNumAlpha = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrNumAlpha;
                                dw_seq.GetItem<SeqAddresses>(newseq).AdrUnit = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrUnit;
                                dw_seq.GetItem<SeqAddresses>(newseq).ContractNo = dw_unseq.GetItem<UnseqAddresses>(row.Index).ContractNo;
                                dw_seq.GetItem<SeqAddresses>(newseq).Customer = dw_unseq.GetItem<UnseqAddresses>(row.Index).Customer;
                                dw_seq.GetItem<SeqAddresses>(newseq).RoadName = dw_unseq.GetItem<UnseqAddresses>(row.Index).RoadName;
                                dw_seq.GetItem<SeqAddresses>(newseq).RoadNameId = dw_unseq.GetItem<UnseqAddresses>(row.Index).RoadNameId;
                                dw_seq.GetItem<SeqAddresses>(newseq).SeqNum = dw_unseq.GetItem<UnseqAddresses>(row.Index).SeqNum;
                                dw_seq.GetItem<SeqAddresses>(newseq).Sequence = dw_unseq.GetItem<UnseqAddresses>(row.Index).Sequence;
                                newseq++;
                                deleteIndexes.Add(row.Index);
                            }
                        }
                    }
                }
            }
            dw_seq.Focus();
            //! delete after all inserts are finished
            int offset = 0;
            deleteIndexes.Sort();//! sort in order to use offset correctly
            foreach (int iDelete in deleteIndexes)
            {
                if (dw_unseq.DataObject.RowCount > (iDelete - offset))
                {
                    dw_unseq.DataObject.DeleteItemAt(iDelete - offset);
                    offset++;
                }
            }

            //  TJB  SR4461  Dec 2004
            //  Change definition of adr_no_numeric to strip flat number
            //         (computed field in datawindow)
            //  Change sort order to include adr_no_alpha and customer
            //  Made sort order change in data window too
            dw_unseq.DataObject.SortString = "road_name A, adr_no_numeric A, adr_alpha A, adr_unit A, customer A";
            dw_unseq.DataObject.Sort<UnseqAddresses>();

            of_dwseq_reseqence();

            this.ResumeLayout(false);

            dw_unseq.SelectRow(0, false);
            dw_seq.SelectRow(0, false);

            cb_seq_arrow.Enabled = false;
            cb_sequence.Enabled = false;
            cb_addseq.Enabled = false;
            cb_reverse.Enabled = false;
            cb_unseq_arrow.Enabled = false;
            cb_unsequence.Enabled = false;
            cb_up_arrow.Enabled = false;
            cb_down_arrow.Enabled = false;

            il_sequence = 0;
        }

        private void of_dwseq_reseqence()
        {
            // Update the SeqNum and SequenceNo values of all records in dw_seq

            int newSeqNum, newSequenceNo;
            int nRow, nRows;
            int thisAdrId, prevAdrId;

            newSeqNum = 0;
            newSequenceNo = 0;
            prevAdrId = -1;
            nRows = dw_seq.RowCount;

            // Step through dw_seq, starting SeqNum at 1
            for (nRow = 0; nRow < nRows; nRow++)
            {
                // Increment the new SeqNum value only if this record's AdrId is
                // different than the previous record's.  We've initialised the 
                // prevAdrId to an illegal value so the first match will always 
                // say they're different.
                thisAdrId = (int)dw_seq.GetItem<SeqAddresses>(nRow).AdrId;

                if (thisAdrId != prevAdrId)
                {
                    newSeqNum++;
                    prevAdrId = thisAdrId;
                }
                newSequenceNo++;

                dw_seq.GetItem<SeqAddresses>(nRow).SeqNum = newSeqNum;
                dw_seq.GetItem<SeqAddresses>(nRow).SequenceNo = newSequenceNo;
            }
        }

        // TJB  RPCR_026  July-2011
        // Added from WAddressSearch
        public virtual string of_getpermissions(string as_name)
        {
            int ll_componentID = 0;
            int? ll_regionID;
            string ls_perms;
            ll_regionID = this.of_get_regionid();
            ll_componentID = StaticVariables.gnv_app.of_get_securitymanager().of_get_componentid(as_name);
            ls_perms = "";
            if (StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(ll_componentID, ll_regionID, "C", false))
                ls_perms += "C";

            if (StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(ll_componentID, ll_regionID, "R", false))
                ls_perms += "R";

            if (StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(ll_componentID, ll_regionID, "M", false))
                ls_perms += "M";

            if (StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(ll_componentID, ll_regionID, "D", false))
                ls_perms += "D";

            if (ls_perms == "")
                ls_perms = null;
            return ls_perms;
        }

        public virtual void cb_unseq_clicked(object sender, EventArgs e)
        {
            //! get all selected rows in an array/list with indexes adjusted
            List<int> selRows = new List<int>();
            for (int i = 0; i < dw_seq.RowCount; i++)
            {
                if (dw_seq.IsSelected(i))
                {
                    selRows.Add(i - selRows.Count);//! Adjusting index for the rows that will be deleted
                }
            }

            int newrow = dw_unseq.RowCount;
            foreach (int ll_selectedrow1 in selRows)
            {
                dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).Sequence = null;
                dw_unseq.InsertItem<UnseqAddresses>(newrow);
                dw_unseq.GetItem<UnseqAddresses>(newrow).AdrAlpha = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).AdrAlpha;
                dw_unseq.GetItem<UnseqAddresses>(newrow).AdrId = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).AdrId;
                dw_unseq.GetItem<UnseqAddresses>(newrow).AdrNo = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).AdrNo;
                dw_unseq.GetItem<UnseqAddresses>(newrow).AdrNum = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).AdrNum;
                dw_unseq.GetItem<UnseqAddresses>(newrow).AdrNumAlpha = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).AdrNumAlpha;
                dw_unseq.GetItem<UnseqAddresses>(newrow).AdrUnit = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).AdrUnit;
                dw_unseq.GetItem<UnseqAddresses>(newrow).ContractNo = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).ContractNo;
                dw_unseq.GetItem<UnseqAddresses>(newrow).Customer = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).Customer;
                dw_unseq.GetItem<UnseqAddresses>(newrow).RoadName = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).RoadName;
                dw_unseq.GetItem<UnseqAddresses>(newrow).RoadNameId = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).RoadNameId;
                dw_unseq.GetItem<UnseqAddresses>(newrow).SeqNum = null;
                dw_unseq.GetItem<UnseqAddresses>(newrow).Sequence = null;
                newrow++;

                dw_seq.DeleteItemAt(ll_selectedrow1);
            }
            dw_unseq.Focus();

            // Remove and sequence numbers on the unsequenced addresses
            for (int row = 0; row < dw_unseq.RowCount; row++)
            {
                dw_unseq.GetItem<UnseqAddresses>(row).Sequence = null;
            }

            //  TJB  SR4461  Dec 2004
            //  Disabled setting unseq datawindow sort order: use whatever
            //  order is defined (set in datawindow and reset by cb_seq).
            //  dw_unseq.SetSort('adr_no_numeric')
            dw_unseq.DataObject.Sort<UnseqAddresses>();

            dw_unseq.SelectRow(0, false);
            dw_seq.SelectRow(0, false);

            cb_seq_arrow.Enabled = false;
            cb_sequence.Enabled = false;
            cb_addseq.Enabled = false;
            cb_reverse.Enabled = false;
            cb_unseq_arrow.Enabled = false;
            cb_unsequence.Enabled = false;
            cb_up_arrow.Enabled = false;
            cb_down_arrow.Enabled = false;

            dw_unseq.Refresh();

            il_sequence = 0;
        }

        private void dump_unseq()
        {
            int rows, i_sequence, i_seqnum;
            int? sequence, seqnum;
            string s_sequence = "", s_seqnum = "";
            string msg = "Row   Seq_Num  Sequence  Road" + "\n";

            rows = dw_unseq.RowCount;
            for (int row = 0; row < rows; row++ )
            {
                seqnum = dw_unseq.GetItem<UnseqAddresses>(row).SeqNum;
                sequence = dw_unseq.GetItem<UnseqAddresses>(row).Sequence;
                if (seqnum == null)
                    s_seqnum = "null";
                else
                {
                    i_seqnum = (int)seqnum;
                    s_seqnum = i_seqnum.ToString("####");
                }
                if (sequence == null)
                    s_sequence = "null";
                else
                {
                    i_sequence = (int)sequence;
                    s_sequence = i_sequence.ToString("####");
                }

                msg += row.ToString("###") + ",  " 
                       + "N = " + s_seqnum + ",  "
                       + "S = " + s_sequence + ",  "
                       + dw_unseq.GetItem<UnseqAddresses>(row).AdrNum  + " "
                       + dw_unseq.GetItem<UnseqAddresses>(row).RoadName
                       + "\n";
            }
            MessageBox.Show(msg, "Unseq");
        }

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            DialogResult ans = DialogResult.None;
            //  TJB SR4691  Aug 2006
            //  Added save of validation indicator (in pfc_save)
            //  TJB SR4461
            //  If the route has been modified, ask whether to save it
            if (StaticFunctions.IsDirty(idw_seq) 
                || StaticFunctions.IsDirty(idw_unseq) 
                || StaticFunctions.IsDirty(idw_addr_sequence_ind))
            {
                ans = MessageBox.Show("Do you want to save changes?"
                                      , "Rural Delivery System (Close)"
                                      , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                                      , MessageBoxDefaultButton.Button1);
                //  Cancel: return to window
                if (ans == DialogResult.Cancel)
                {
                    return;
                }
            }
            //  Yes: If the address sequence has been changed
            //       save it and tell the user whether it was successful or not
            if (ans == DialogResult.Yes)
            {
                if (StaticFunctions.IsDirty(idw_seq) || StaticFunctions.IsDirty(idw_unseq))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int rc = this.pfc_save();
                    int t = rc;
                    if (true) // SUCCESS
                    {
                        MessageBox.Show("Changes saved"
                                        , ""
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information);

                        idw_seq.ResetUpdate();
                        idw_unseq.ResetUpdate();
                        idw_addr_sequence_ind.ResetUpdate();
                    }
                    else
                    {
                        MessageBox.Show("Error saving Changes.\n" 
                                        + "Route has not been saved."
                                        , "Warning"
                                        , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                //  TJB SR4691
                //  If the address sequence wasn't changed, the validation
                //  indicator will not yet have been saved.  If tis still 
                //  showing as having been modified, save it.
                if (StaticFunctions.IsDirty(idw_addr_sequence_ind))
                {
                    //!idw_addr_sequence_ind.Update();
                    int rc = idw_addr_sequence_ind.Save();
                    int t = rc;
                    idw_addr_sequence_ind.ResetUpdate();
                }
                //  TJB SR4691 fixup
                if (StaticFunctions.IsDirty(idw_unseq))
                {
                    idw_unseq.ResetUpdate();
                }
            }
            else
            {
                idw_seq.ResetUpdate();
                idw_unseq.ResetUpdate();
                idw_addr_sequence_ind.ResetUpdate();
            }
            this.Close(); // close(parent)
        }

        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            DialogResult ans;

            //  TJB SR4691  Aug 2006
            //  Handle saving of validation indicator  ( which may be the only thing changed)
            //  Note:  pfc_save will have saved the indicator  ( if it was set) 
            //         and returns SUCCESS.
            //  lb_route_saved records whether the route was successfully saved.
            //  Used at end to decide (partly) whether to reset dw_seq and dw_unseq

            //  TJB SR4461
            //  If the route has been modified, ask whether to save it
            if (StaticFunctions.IsDirty(idw_seq)
                || StaticFunctions.IsDirty(idw_unseq)
                || StaticFunctions.IsDirty(idw_addr_sequence_ind)
                )
            {
                ans = MessageBox.Show("Do you want to save changes?"
                                      , "Rural Delivery System (save)"
                                      , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                                      , MessageBoxDefaultButton.Button1);
                //  Cancel: return to window
                if (ans == DialogResult.Cancel)
                {
                    return;
                }
                if (ans == DialogResult.No)
                {
                    this.dw_seq.ResetUpdate();
                    idw_unseq.ResetUpdate();
                    idw_addr_sequence_ind.ResetUpdate();
                    return;
                }
                //  OK: Save it and tell the user whether it was successful or not
                Cursor.Current = Cursors.WaitCursor;

                // PBY 03/09/2002 SR#4417 
                int rc = this.pfc_save();
                if (rc == SUCCESS)
                {
                    //  Disable the CLoseQuery processing
                    ib_disableclosequery = true;
                    MessageBox.Show("Changes saved.", ""
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Error saving changes.\n" 
                                    + "Route has not been saved."
                                    , "Warning"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //  TJB SR4691
            //  If the address sequence wasn't changed, the validation
            //  indicator will not yet have been saved.  If tis still 
            //  showing as having been modified, save it.
            if (StaticFunctions.IsDirty(idw_addr_sequence_ind))
            {
                //! idw_addr_sequence_ind.Update();
                idw_addr_sequence_ind.Save();
            }
            //if (lb_route_saved)
            //{
            //    idw_seq.Reset();
            //    idw_seq.Retrieve(new object[]{il_contract_no});
            //    idw_seq.SelectRow(0, false);
            //}
            idw_seq.ResetUpdate();
            idw_unseq.ResetUpdate();
            idw_addr_sequence_ind.ResetUpdate();
        }

        public virtual void cb_stripmaker_clicked(object sender, EventArgs e)
        {
            //  TJB SR4461  Dec 2004
            //  Generate Stripmaker interface files
            int ll_rc = 0;
            int ll_rowcount;
            int ll_row;
            int ll_written;
            int ll_errors;
            int? ll_roadnameid;
            string ls_roadname;
            string ls_oldroadname;
            string ls_contract_title = "";
            string ls_delivery_office = "";
            string ls_message;
            string ls_savedir = "";
            string ls_filenamedir;
            string ls_filename;
            string ls_file;
            StreamWriter li_file = null;
            List<string> ls_inikeys = new List<string>();
            List<string> ls_inivalues = new List<string>();
            string ls_inikey;
            string ls_inivalue;
            int li_inirows;
            int li_inirow;
            string ls_font;
            string ls_street_size;
            string ls_delivery_size;
            List<string> ls_colournames = new List<string>();
            List<string> ls_colourvalues = new List<string>();
            int li_colour;
            int li_colours;

            DialogResult ll_dr = new DialogResult();

            // ---------------------------------------------------
            //  Check to see if there's anything to do
            // ---------------------------------------------------

            ll_rowcount = dw_seq.RowCount;
            if (ll_rowcount <= 0)
            {
                MessageBox.Show("No rows found in route??"
                                , "Error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; 
            }

            if (StaticFunctions.IsDirty(dw_seq) || StaticFunctions.IsDirty(dw_unseq))
            {
                MessageBox.Show("Please save route before creating the Stripmaker files."
                                , "Warning"
                                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; 
            }

            Cursor.Current = Cursors.WaitCursor;

            // ---------------------------------------------------
            //  Find out where the stripmaker ini file is 
            //  and what its called
            // ---------------------------------------------------
            //  Default ini file name and directory

            is_inifile = StaticVariables.gnv_app.of_getstripmakerini();
            if (!(File.Exists(is_inifile)))
            {
                MessageBox.Show("Stripmaker ini file not found at " + is_inifile + "\n\n" 
                		        + "Please locate it."
                		        , "Warning"
                		        , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Open Stripmaker ini file";
                dlg.DefaultExt = "ini";
                dlg.Filter = "All Files(*.*)|*.*";
                ll_dr = dlg.ShowDialog();
                is_inifile = dlg.FileName;
                if (ll_dr == DialogResult.Cancel)
                {
                    return;
                }
                else if ((int)ll_dr < 0)
                {
                    MessageBox.Show("Error selecting inifile name"
                                    , "Error"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //  Save the filename so we don't need to ask next time
                StaticVariables.gnv_app.of_setstripmakerini(is_inifile);
                //  Make sure we haven't changed the working directory
            }
            // ---------------------------------------------------
            //  Find out where to put the stripmaker files 
            //  and what to call them
            // ---------------------------------------------------
            //  Set the default filename to 'sm' plus the contract number
            ls_filename = "sm" + il_contract_no.ToString();
            ll_rc = StaticVariables.gnv_app.of_getinivalue(is_inifile, "General", "Default File Location", ref ls_savedir);
            if (ll_rc < 1)
            {
                MessageBox.Show("Default stripmaker files directory not found in ini file."
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // TJB Feb-2011 Release 7.1.5 fixups
                // Return the parent of the current directory
                // (expected to be C:\Program Files\Rural Post)
                //ls_savedir = StaticFunctions.GetCurrentDirectory();
                ls_savedir = GetParentPath(StaticFunctions.GetCurrentDirectory());
            }
            // TJB Feb-2011 Release 7.1.5 fixups
            // Changed test from "File.Exists" to "Directory.Exists"
            else if (!(Directory.Exists(ls_savedir)))
            {
                MessageBox.Show("Default stripmaker files directory not found: " + ls_savedir + "\n\n" 
                		        + "Please select another."
                		        , "Warning"
                		        , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // TJB Feb-2011 Release 7.1.5 fixups
                // Return the parent of the current directory
                // (expected to be C:\Program Files\Rural Post)
                //ls_savedir = StaticFunctions.GetCurrentDirectory();
                ls_savedir = GetParentPath(StaticFunctions.GetCurrentDirectory());
            }
            SaveFileDialog dlg2 = new SaveFileDialog();
            dlg2.Title = "Save Stripmaker route files to ...";
            // TJB Feb-2011 Release 7.1.5 fixups
            // Changed InitialDirectory to the directory name (was directory + filename)
            dlg2.InitialDirectory = ls_savedir;
            dlg2.FileName = ls_filename;
            ll_dr = dlg2.ShowDialog();
            ls_filenamedir = dlg2.FileName;
            if (ll_dr == DialogResult.Cancel)
            {
                return;
            }
            else if ((int)ll_dr < 0)
            {
                MessageBox.Show("Error selecting save file name"
                               , "Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // TJB  RPCR_026  July-2011: Bug fix
            // The user may have entered a different filename; extract it.
            int n = ls_filenamedir.LastIndexOf('\\');
            if (n > 0)
            {
                ls_filename = ls_filenamedir.Substring(n + 1);
                ls_filenamedir = ls_filenamedir.Substring(0, n + 1);
            }

            //  Make sure we don't change the working directory
            //  Strip any file extension included
            ll_rc = ls_filename.LastIndexOf('.');
            if (ll_rc > 0)
            {
                ls_filename = ls_filename.Substring(0,ll_rc);
            }
            //  Remove the filename from the directory name
            ll_rc = ls_filenamedir.LastIndexOf(ls_filename);
            if (ll_rc > 0)
            {
                is_filedir = ls_filenamedir.Substring(0, ll_rc);
            }
            else
            {
                is_filedir = ls_filenamedir;
            }
            is_headerfile = ls_filename + ".cps";
            is_streetfile = ls_filename + ".str";
            is_deliveryfile = ls_filename + ".dpa";
            //  Check to see if the header file already exists
            if (File.Exists(is_filedir + is_headerfile))
            {
                ll_rc = (int)MessageBox.Show("Stripmaker header file " + is_headerfile + " exists.\n" 
                                             + "Do you want to replace it and its related files?"
                                             , "Warning"
                                             , MessageBoxButtons.YesNo
                                             , MessageBoxIcon.Question
                                             , MessageBoxDefaultButton.Button1);
                if (ll_rc == (int)DialogResult.No)
                {
                    MessageBox.Show("No Stripmaker files have been generated"
                                   , "Information"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            //  Delete any existing stripmaker files
            lf_cleanup();
            // ---------------------------------------------------
            //  Generate the route's header file (<contract_no>.cps)
            // ---------------------------------------------------
            //  Look up the header section in the ini file
            li_inirows = lf_getinikeyvalues(is_inifile, "Header", ref ls_inikeys, ref ls_inivalues);
            if (li_inirows < 1)
            {
                MessageBox.Show("Header section not found in ini file: " + is_inifile + "\n\n"
                                + "Unable to continue." + "\n\n"
                                + "(No Stripmaker files have been generated)"
                                , "Error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //  Get contract information for header file
            // select contract.con_title, outlet.o_name 
            //   into :ls_contract_title, :ls_delivery_office
            //   from contract, outlet
            //  where contract.contract_no = :il_contract_no 
            //    and contract.con_base_office = outlet.outlet_id

            // TJB  RPCR_026  June-2011
            // Added nContractStripHeight and GetDefaultStripHeight()
            int? nContractStripHeight = 40;  // GetDefaultStripHeight() *should* always return a value
            string sSortFrameType = "";      // This is the current (June-2011) default value
            string sLookupError = "";
            
            RDSDataService dataService = RDSDataService.GetContractInfoByNo(il_contract_no);
            if (dataService.ContractInfoByNoList.Count > 0)
            {
                ContractInfoByNoItem item = dataService.ContractInfoByNoList[0];
                ls_contract_title = item.ConTitle;
                ls_delivery_office = item.OName;
                nContractStripHeight = item.ConStripHeight;
                sSortFrameType = item.ConFrameType;
            }
            if (dataService.SQLCode != 0)
            {
                sLookupError += "Contract title lookup failed\n";
            }
            if (nContractStripHeight == null)
            {
                nContractStripHeight = RDSDataService.GetDefaultStripHeightId();
                if (nContractStripHeight < 0)
                {
                    MessageBox.Show("Default strip height not found.  \n"
                                    + "Using 40."
                                    , "Error");
                    nContractStripHeight = 40;
                }
            }
            if (dataService.SQLCode != 0)
            {
                sLookupError += "Strip height lookup failed\n";
            }
            sSortFrameType = (sSortFrameType == null) ? "" : sSortFrameType;

            if (sLookupError != "")
            {
                MessageBox.Show(sLookupError + "\n" 
                                + dataService.SQLErrText + "\n\n"
                                + "(No Stripmaker files have been generated)"
                                , "SQL error " + dataService.SQLCode
                                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //  Open the header file
            ls_file = is_filedir + is_headerfile;
            try
            {
                li_file = new StreamWriter(ls_file, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open header file: " + ls_file + "\n" 
                               + "Return code = " + ex.Message + "\n"
                               + "(No Stripmaker files have been generated)"
                               , "Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            ll_written = 0;
            ll_errors = 0;
            for (li_inirow = 0; li_inirow < li_inirows; li_inirow++)
            {
                ls_inikey = ls_inikeys[li_inirow];
                ls_inivalue = ls_inivalues[li_inirow];
                if (ls_inikey == "OfficeName")
                {
                    ls_inivalue = '\"' + ls_delivery_office + '\"';
                }
                else if (ls_inikey == "RoundName")
                {
                    ls_inivalue = '\"' + ls_contract_title + '\"';
                }
                else if (ls_inikey == "FrameType")
                {
                    ls_inivalue = '\"' + sSortFrameType +'\"';
                }
                else if (ls_inikey == "RoundNumber")
                {
                    ls_inivalue = il_contract_no.ToString();
                }
                else if (ls_inikey == "StripHeight")
                {
                    ls_inivalue = nContractStripHeight.ToString();
                }
                li_file.WriteLine(ls_inikey + ',' + ls_inivalue);
                ll_written++;
            }
            li_file.Close();
            // ---------------------------------------------------
            //  Generate the route's street file (<contract_no>.str)
            // ---------------------------------------------------
            ls_file = is_filedir + is_streetfile;
            try
            {
                li_file = new StreamWriter(ls_file, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open street file: '" + ls_file + "'\n" 
                                + "Return code = " + li_file + "\n"
                                + "(No Stripmaker files have been generated)"
                                , "Error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lf_cleanup();
                return;
            }
            //  Get street file parameters from the street section 
            //  in the ini file
            li_inirows = lf_getinikeyvalues(is_inifile, "Street", ref ls_inikeys, ref ls_inivalues);
            if (li_inirows < 1)
            {
                MessageBox.Show("Street section not found in ini file: " + is_inifile + "\n\n"
                               + "Using defaults: Arial, 14, 18"
                               , "Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ls_font = "Arial";
                ls_street_size = "14";
                ls_delivery_size = "18";
            }
            ls_font = "<not set>";
            ls_street_size = "<not set>";
            ls_delivery_size = "<not set>";
            for (li_inirow = 0; li_inirow < li_inirows; li_inirow++)
            {
                if (ls_inikeys[li_inirow] == "Font Name")
                {
                    ls_font = ls_inivalues[li_inirow];
                }
                else if (ls_inikeys[li_inirow] == "Street Name Font Size")
                {
                    ls_street_size = ls_inivalues[li_inirow];
                }
                else if (ls_inikeys[li_inirow] == "Delivery Point Font Size")
                {
                    ls_delivery_size = ls_inivalues[li_inirow];
                }
            }
            if (ls_font == "<not set>" || ls_street_size == "<not set>" || ls_delivery_size == "<not set>")
            {
                MessageBox.Show("Street font details not found in ini file: " + is_inifile + "\n\n" 
                                + "Font Name = " + ls_font + '\n' 
                                + "Street Name Font Size = " + ls_street_size + '\n' 
                                + "Delivery Point Font Size = " + ls_delivery_size + "\n\n"
                                + "Using defaults: Arial, 14, 18"
                                , "Error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (ls_font == "<not set>")
                {
                    ls_font = "Arial";
                }
                if (ls_street_size == "<not set>")
                {
                    ls_street_size = "14";
                }
                if (ls_delivery_size == "<not set>")
                {
                    ls_delivery_size = "18";
                }
            }
            //  Get the street file colours from the Street Colours section
            //  of the ini file
            li_colours = lf_getinikeyvalues(is_inifile, "Street Colours", ref ls_colournames, ref ls_colourvalues);
            if (li_colours < 1)
            {
                MessageBox.Show("Street Colours section not found in ini file: " + is_inifile + "\n\n" 
                		+ "Using default colours: 255, 0 (Red/Black)"
                		, "Error"
                		, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                li_colours = 0;
                ls_colournames.Add("Default");
                ls_colourvalues.Add("255,0");
            }
            //  Sort the datawindow into street name order so we can easily 
            //  pick the unique names and assign round ID numbers to them.
            dw_seq.DataObject.SortString = "road_name A";
            dw_seq.DataObject.Sort<SeqAddresses>();
            if (false)
            {
                MessageBox.Show("Failed to set address road name sort order.\n\n" 
                		+ "(No Stripmaker files have been generated)"
                		, "Error"
                		, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lf_cleanup();
                return;
            }
            else if (false)
            {
                MessageBox.Show("Failed to sort addresses by road name.\n\n" 
                		+ "(No Stripmaker files have been generated)"
                		, "Error"
                		, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lf_cleanup();
                return;
            }
            //  Step through the datawindow looking for the road name to
            //  change.  When it does, generate a street file entry and 
            //  save the sequence number as the street name ID in the 
            //  datawindow.
            ll_written = 0;
            ll_errors = 0;
            ls_oldroadname = "xxxx";
            ll_roadnameid = 0;
            li_colour = -1;
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                ls_roadname = dw_seq.GetItem<SeqAddresses>(ll_row).RoadName;
                if (ls_roadname == null)
                {
                    ls_roadname = "";
                }
                if (ls_oldroadname == ls_roadname)
                {
                    dw_seq.GetItem<SeqAddresses>(ll_row).RoadNameId = ll_roadnameid;
                }
                else
                {
                    li_colour = li_colour + 1;
                    // TJB  RD7_0032  10-Jun-2009
                    //      Changed condition from '>' to '>=' to avoid using too large an index.
                    if (li_colour >= li_colours)
                    {
                        li_colour = 0;
                    }
                    ls_oldroadname = ls_roadname;
                    ll_roadnameid = ll_roadnameid + 1;
                    dw_seq.GetItem<SeqAddresses>(ll_row).RoadNameId = ll_roadnameid;
                    ll_rc = 1; li_file.WriteLine(ll_roadnameid.ToString() + ',' + '\"' + ls_roadname + "\"," + ',' + ls_colourvalues[li_colour] + ',' + ls_font + ',' + ls_street_size + ',' + ls_delivery_size);
                    if (ll_rc > 0)
                        ll_written++;
                    else
                        ll_errors++;
                }
            }
            li_file.Close();
            // ---------------------------------------------------
            //  Generate the route's delivery point file (<contract_no>.dpa)
            // ---------------------------------------------------
            ls_file = is_filedir + is_deliveryfile;
            try
            {
                li_file = new StreamWriter(ls_file, false);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open delivery file: '" + ls_file + "'" + "Return code = " + li_file + "\n\n" 
                		+ "(No Stripmaker files have been generated)"
                		, "Error"
                		, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lf_cleanup();
                return;
            }
            dw_seq.DataObject.SortString = "seq_num A";
            dw_seq.DataObject.Sort<SeqAddresses>();
            if (false)
            {
                MessageBox.Show("Failed to set delivery sequence sort order\n\n" 
                		+ "(No Stripmaker files have been generated)"
                		, "Error"
                		, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lf_cleanup();
                return;
            }
            else if (false)
            {
                MessageBox.Show("Failed to sort addresses by delivery sequence.\n\n" 
                		+ "(No Stripmaker files have been generated)"
                		, "Error"
                		, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lf_cleanup();
                return;
            }
            ll_written = 0;
            ll_errors = 0;
            string sAdrNo = "";
            string sAdrUnit = "";
            string sAdrAlpha = "";
            string sCustomer = "";
            string sCustName = "";
            string sCustSurnameCompany = "";
            string sCustInitials = "";
            string sCustCaseName = "";
            int? nRoadNameID = 0;
            int? nCustSlotAllocation = 0;
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                sAdrNo = dw_seq.GetItem<SeqAddresses>(ll_row).AdrNo;
                sAdrUnit = dw_seq.GetItem<SeqAddresses>(ll_row).AdrUnit;
                sAdrAlpha = dw_seq.GetItem<SeqAddresses>(ll_row).AdrAlpha;
                nRoadNameID = dw_seq.GetItem<SeqAddresses>(ll_row).RoadNameId;
                sCustSurnameCompany = dw_seq.GetItem<SeqAddresses>(ll_row).CustSurnameCompany;
                sCustInitials = dw_seq.GetItem<SeqAddresses>(ll_row).CustInitials;
                sCustCaseName = dw_seq.GetItem<SeqAddresses>(ll_row).CustCaseName;
                nCustSlotAllocation= dw_seq.GetItem<SeqAddresses>(ll_row).CustSlotAllocation;

                sAdrNo = (sAdrNo == null) ? "" : sAdrNo;
                sAdrUnit = (sAdrUnit == null) ? "" : sAdrUnit;
                sAdrAlpha = (sAdrAlpha == null) ? "" : sAdrAlpha;
                sCustInitials = (sCustInitials == null) ? "" : sCustInitials;
                sCustCaseName = (sCustCaseName == null) ? "" : sCustCaseName;
                sCustSurnameCompany = (sCustSurnameCompany == null) ? "" : sCustSurnameCompany;
                sCustName = (sCustInitials.Length > 0) ? sCustSurnameCompany + ", " + sCustInitials.Substring(0, 1) : sCustSurnameCompany;
                nRoadNameID = (nRoadNameID == null) ? nRoadNameID = -(1) : nRoadNameID;
                nCustSlotAllocation = (nCustSlotAllocation == null) ? nCustSlotAllocation = 2 : nCustSlotAllocation;

                // TJB  RPCR_026  June-2011
                // Add the flat number to the address number if there is a unit number.
                // Don't include the unit number as a separate field (leave blank).
                // TJB  RPCR_026  Aug-2011: Fixup
                // If the address number includes a flat number, put the value in quotes
                if (sAdrUnit != "")
                {
                    sAdrNo = '\"' + sAdrUnit + "-" + sAdrNo + '\"';
                }

                // For the customer name, use the case name; 
                //     if no case name use the customer name; 
                //     if still nothing, use a blank (not an empty string)
                sCustomer =  (sCustCaseName.Length > 0)
                                    ? sCustCaseName
                                    : (sCustName.Length > 0) ? sCustName : " ";

                //  Add quotes around the customer name
                sCustomer = '\"' + sCustomer + '\"';
                li_file.WriteLine(  (ll_row + 1).ToString() + ","           // Record number
                                    + nRoadNameID.ToString() + ","          // Street ID
                                    + ","                                   // Building
                                    + sCustomer + ","                       // Customer/Case name
                                    + ","                                   // Floor
                                    + ","                                   // Suite
                                    + sAdrNo + ","                          // House number
                                    + ","                                   // Flat number
                                    + sAdrAlpha + ","                       // Address alpha
                                    + nCustSlotAllocation.ToString() + ","  // Slots
                                    + (ll_row + 1).ToString()               // Slot order
                                 );
                if (ll_rc > 0)
                    ll_written++;
                else
                    ll_errors++;
            }
            li_file.Close();
            ls_message = '\n' + ll_written.ToString() + " delivery file records written";
            if (ll_errors > 0)
                ls_message += ".\n\nErrors:  " + ll_errors.ToString();
            else
                ls_message += " to " + ls_file + ".";

            MessageBox.Show(ls_message
                            , "Information"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
            // ---------------------------------------------------
            //  Done
            // ---------------------------------------------------
            //  Clear the update status so we don't get asked 
            //  about saving changes after sorting the data.
            dw_seq.ResetUpdate();
            dw_unseq.ResetUpdate();
            return;
        }

        public virtual void dw_addr_sequence_ind_itemchanged(object sender, EventArgs e)
        {
            dw_addr_sequence_ind.AcceptText();
            dw_addr_sequence_ind.URdsDw_Itemchanged(sender, e);

            //  TJB  SR4691  Aug 2006
            //  Toggle the validated indicator and update the date and userID
            // 
            //  Note: the validated indicator is the only thing selectable
            //  in this data window so we don't need to check which field
            //  was selected.
            string ls_name = this.dw_addr_sequence_ind.GetColumnName();
            int row = this.dw_addr_sequence_ind.GetRow();

            if (ls_name == "rf_valid_ind")
            {
                int rows = this.dw_addr_sequence_ind.RowCount;
                if (rows > 0 && row < 0)
                    row = 0;
                if (row >= 0)
                {
                    idw_addr_sequence_ind.GetItem<AddrSequenceInd>(row).RfValidDate = System.DateTime.Today;
                    idw_addr_sequence_ind.GetItem<AddrSequenceInd>(row).RfValidUser = is_userid;
                }
            }

            // TJB  RPCR_026  July-2011
            // Any change to the frozen checkbox clears any selections 
            // and turns all action buttone off.  If the frozen checkbox
            // has been cleared, the user will have to re-select any selections 
            // which will turn on any relevant action buttons.
            if (ls_name == "rf_frozen_ind")
            {
                cb_seq_arrow.Enabled = false;
                cb_sequence.Enabled = false;
                cb_addseq.Enabled = false;
                cb_reverse.Enabled = false;
                cb_unseq_arrow.Enabled = false;
                cb_unsequence.Enabled = false;
                cb_up_arrow.Enabled = false;
                cb_down_arrow.Enabled = false;

                dw_unseq.SelectRow(0, false);
                dw_seq.SelectRow(0, false);

                il_sequence = 0;
            }
        }
        #endregion

        private void cb_unseq_arrow_Click(object sender, EventArgs e)
        {
            cb_unseq_clicked(sender, e);
        }

        private void cb_unsequence_Click(object sender, EventArgs e)
        {
            cb_unseq_clicked(sender, e);
        }

        private void cb_seq_arrow_Click(object sender, EventArgs e)
        {
            cb_seq_clicked(sender, e, false);
        }

        private void cb_sequence_Click(object sender, EventArgs e)
        {
            cb_seq_clicked(sender, e, false);
        }

        private void cb_addseq_Click(object sender, EventArgs e)
        {
            cb_seq_clicked(sender, e, true);

        }

        private void of_dwseq_moverow(int nFromRow, int nToRow)
        {
            SeqAddresses thisItem = new SeqAddresses();

            thisItem.AdrAlpha = dw_seq.GetItem<SeqAddresses>(nFromRow).AdrAlpha;
            thisItem.AdrId = dw_seq.GetItem<SeqAddresses>(nFromRow).AdrId;
            thisItem.AdrNo = dw_seq.GetItem<SeqAddresses>(nFromRow).AdrNo;
            thisItem.AdrNum = dw_seq.GetItem<SeqAddresses>(nFromRow).AdrNum;
            thisItem.AdrNumAlpha = dw_seq.GetItem<SeqAddresses>(nFromRow).AdrNumAlpha;
            thisItem.AdrUnit = dw_seq.GetItem<SeqAddresses>(nFromRow).AdrUnit;
            thisItem.ContractNo = dw_seq.GetItem<SeqAddresses>(nFromRow).ContractNo;
            thisItem.Customer = dw_seq.GetItem<SeqAddresses>(nFromRow).Customer;
            thisItem.RoadName = dw_seq.GetItem<SeqAddresses>(nFromRow).RoadName;
            thisItem.RoadNameId = dw_seq.GetItem<SeqAddresses>(nFromRow).RoadNameId;
            thisItem.SeqNum = dw_seq.GetItem<SeqAddresses>(nFromRow).SeqNum;
            thisItem.Sequence = dw_seq.GetItem<SeqAddresses>(nFromRow).Sequence;

            dw_seq.DeleteItemAt(nFromRow);
            dw_seq.InsertItem<SeqAddresses>(nToRow);

            dw_seq.GetItem<SeqAddresses>(nToRow).AdrAlpha = thisItem.AdrAlpha;
            dw_seq.GetItem<SeqAddresses>(nToRow).AdrId = thisItem.AdrId;
            dw_seq.GetItem<SeqAddresses>(nToRow).AdrNo = thisItem.AdrNo;
            dw_seq.GetItem<SeqAddresses>(nToRow).AdrNum = thisItem.AdrNum;
            dw_seq.GetItem<SeqAddresses>(nToRow).AdrNumAlpha = thisItem.AdrNumAlpha;
            dw_seq.GetItem<SeqAddresses>(nToRow).AdrUnit = thisItem.AdrUnit;
            dw_seq.GetItem<SeqAddresses>(nToRow).ContractNo = thisItem.ContractNo;
            dw_seq.GetItem<SeqAddresses>(nToRow).Customer = thisItem.Customer;
            dw_seq.GetItem<SeqAddresses>(nToRow).RoadName = thisItem.RoadName;
            dw_seq.GetItem<SeqAddresses>(nToRow).RoadNameId = thisItem.RoadNameId;
            dw_seq.GetItem<SeqAddresses>(nToRow).SeqNum = thisItem.SeqNum;
            dw_seq.GetItem<SeqAddresses>(nToRow).Sequence = thisItem.Sequence;
        }

        private void cb_up_arrow_Click(object sender, EventArgs e)
        {
            int  nLastRow, nPrevRow = 0, nFirstRow = 0;
            int? nPrevSeq = 0, nThisSeq = 0;
            int? nPrevSeqNum = 0, nThisSeqNum = 0;
            int nThisAdrId, nPrevAdrId1, nPrevAdrId2;

            this.dw_seq.SuspendLayout();

            nFirstRow = 0;
            nLastRow = dw_seq.RowCount;
            List<int> selRows = new List<int>();
            for (int nThisRow = 1; nThisRow < nLastRow; nThisRow++)
            {
                if (dw_seq.IsSelected(nThisRow))
                {
                    selRows.Add(nThisRow);
                }
            }

            nFirstRow = 0;
            List<int> movedRows = new List<int>();
            foreach (int nThisRow in selRows)
            {
                nPrevRow = nThisRow - 1;

                nThisAdrId = (int)dw_seq.GetItem<SeqAddresses>(nThisRow).AdrId;
                nPrevAdrId1 = (int)dw_seq.GetItem<SeqAddresses>(nPrevRow).AdrId;
                nPrevAdrId2 = -1;

                
                while ((nPrevRow - 1) >= nFirstRow )
                {
                    nPrevAdrId2 = (int)dw_seq.GetItem<SeqAddresses>(nPrevRow - 1).AdrId;

                    if (nPrevAdrId1 == nPrevAdrId2)
                    {
                        nPrevAdrId1 = nPrevAdrId2;
                        nPrevRow--;
                    }
                    else
                        break;
                }

                if (nThisAdrId != nPrevAdrId1)
                {
                    of_dwseq_moverow(nThisRow, nPrevRow);
                    movedRows.Add(nPrevRow);
                }
            }

//            dw_seq.Refresh();
            dw_seq.SelectRow(0, false);
/*
            nFirstRow = 1;
            foreach (int nThisRow in selRows)
            {
                if (nThisRow > nFirstRow)
                    dw_seq.SelectRow(nThisRow, true);
                else
                {
                    dw_seq.SelectRow(0, false);

                    cb_up_arrow.Enabled = false;
                    cb_down_arrow.Enabled = false;
                    cb_unseq_arrow.Enabled = false;
                    cb_unsequence.Enabled = false;
                    break;  
                }
            }
*/
            movedRows.Sort();
            foreach (int nThisRow in movedRows)
            {
                if (nThisRow <= nFirstRow)
                {
                    dw_seq.SelectRow(0, false);

                    cb_up_arrow.Enabled = false;
                    cb_down_arrow.Enabled = false;
                    cb_unseq_arrow.Enabled = false;
                    cb_unsequence.Enabled = false;
                    break;
                }
                else if (nThisRow > 0)
                    dw_seq.SelectRow((nThisRow + 1), true);
            }

            of_dwseq_reseqence();

            il_sequence = dw_seq.GetSelectedRow(0);
            il_sequence = (il_sequence < 0) ? 0 : il_sequence;

            dw_seq.Refresh();
            this.dw_seq.ResumeLayout(true);
        }

        private void cb_down_arrow_Click(object sender, EventArgs e)
        {
            int  nNextRow = 0, nLastRow = 0, nRows;
            int? nThisSeq = 0;
            int? nThisSeqNum = 0;
            int  nThisAdrId = 0, nNextAdrId1 = 0, nNextAdrId2 = 0;

            this.dw_seq.SuspendLayout();

            // Get a list of the selected rows.
            // Work from the bottom up, starting with the second from the bottom
            // (since the bottom one cannot move down any further).
            nRows = dw_seq.RowCount;
            List<int> selRows = new List<int>();
            for (int i = (nRows -2); i >= 0; i--)
            {
                if (dw_seq.IsSelected(i))
                {
                    selRows.Add(i);
                }
            }

            nLastRow = dw_seq.RowCount - 1;
            List<int> movedRows = new List<int>();
            foreach (int nThisRow in selRows)
            {
                nNextRow = nThisRow + 1;

                nThisAdrId  = (int)dw_seq.GetItem<SeqAddresses>(nThisRow).AdrId;
                nNextAdrId1 = (int)dw_seq.GetItem<SeqAddresses>(nNextRow).AdrId;
                while ((nNextRow + 1) <= nLastRow)
                {
                    nNextAdrId2 = (int)dw_seq.GetItem<SeqAddresses>(nNextRow + 1).AdrId;
                    if (nNextAdrId1 != nNextAdrId2)
                        break;
                    nNextRow++;
                    nNextAdrId1 = nNextAdrId2;
                }

                if (nThisAdrId != nNextAdrId1)
                {
                    of_dwseq_moverow(nThisRow, nNextRow);
                    movedRows.Add(nNextRow + 1);
                }
            }

//            dw_seq.Refresh();
            dw_seq.SelectRow(0, false);

            movedRows.Sort();
            foreach (int nThisRow in movedRows)
            {
                if (nThisRow > nLastRow)
                {
                    dw_seq.SelectRow(0, false);

                    cb_up_arrow.Enabled = false;
                    cb_down_arrow.Enabled = false;
                    cb_unseq_arrow.Enabled = false;
                    cb_unsequence.Enabled = false;
                    break;
                }
                else if (nThisRow > 0)
                    dw_seq.SelectRow(nThisRow, true);
            }

            of_dwseq_reseqence();

            il_sequence = dw_seq.GetSelectedRow(0);
            il_sequence = (il_sequence < 0) ? 0 : il_sequence;

            dw_seq.Refresh();
            this.dw_seq.ResumeLayout(true);
        }

        public struct unseqItem
        {
            public int Seq;
            public int Row;

            public unseqItem(int _seq, int _row)
            {
                this.Seq = _seq;
                this.Row = _row;
            }
        }

        public class unseqSorter : IComparer<unseqItem>
        {
            // This sorts the unseqItem list into descending order of Seq values
            public int Compare(unseqItem obj1, unseqItem obj2)
            {
                return obj2.Seq.CompareTo(obj1.Seq);
            }
        }

        private string GetParentPath(string thisPath)
        {
            // TJB Feb-2011 Release 7.1.5 fixups: New
            // Assume receiving a Windows path with a format like
            //    C:\\Program Files\\Rural Post\\RDS.NET\\
            // Return the parent folder (C:\\Program Files\\Rural Post\\)
            int prevIndex, nextIndex;
            int len = thisPath.Length;
            // If we haven't been passed something to parse, return it
            // (what else are you going to do?)
            if (len < 1)
                return thisPath;
            // Scan through the path looking for back-slashes (doubled in the string)
            // prevIndex is the index of the previous occurrence of the slashes,
            // nextIndex is the index of the current occurrence of the slashes
            prevIndex = 0;
            nextIndex = thisPath.IndexOf("\\");
            // The scan stops when the current index is at the end of the path
            // or not found (the path doesn't end in "\\").
            while ( ((nextIndex + 1) < len) || (nextIndex < 1) )
            {
                prevIndex = nextIndex;
                nextIndex = thisPath.IndexOf("\\", (prevIndex + 1));
            }
            // If no slashes were found, return the original path
            if (prevIndex <= 0)
                return thisPath;
            // Otherwise, return the path up to the next-to-last slashes 
            // (including the slashes)
            return thisPath.Substring(0, (prevIndex + 1));
        }
        private void cb_reverse_Click(object sender, EventArgs e)
        {
//            dw_unseq.DataObject.FilterString = "sequence > 0";
            int newseq = 1;
            int oldseq = 1;
            int oldrow = 1;

            //If there's only one row (or none), there's no point reversing the order
            int nRows = (((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).SelectedRows).Count;
            if ( nRows < 2 )
            {
                return;
            }

            // Build a list of the addresses that have been assigned sequence numbers
            // Use the unseqItem structure to keep the sequence number and the row each is on
            List<unseqItem> unsequencedItems = new List<unseqItem>();
            foreach (DataGridViewRow row in ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).SelectedRows)
            {
                oldrow = row.Index;
                oldseq = this.dw_unseq.GetValue<int?>(row.Index, "Sequence").GetValueOrDefault(); 
                unsequencedItems.Add(new unseqItem(oldseq, oldrow));
            }
            // Sort the list into descending sequence number order
            unsequencedItems.Sort(new unseqSorter());

            // Assign new sequence numbers to the rows
            nRows = unsequencedItems.Count;
            newseq = 1;
            for (int nRow = 0; nRow < nRows; nRow++)
            {
                oldrow = unsequencedItems[nRow].Row;
                dw_unseq.GetItem<UnseqAddresses>(oldrow).Sequence = newseq;
                newseq++;
            }

            // Update the unsequenced panel
            (dw_unseq.DataObject.Controls[0] as DataEntityGrid).Refresh();

            // Set the 'next sequence' number
            il_sequence = newseq - 1;
        }

        // TJB  RPCR_105  May-2016
        // Open WReassignContract for the user to select a new contract number
        // for the selected customer(s)
        private void cb_reassign_Click(object sender, EventArgs e)
        {
            int n = 0;
            int rowIndex, nAdrId = 0;
            string sRoadName = "", sCustomer = "";
            Dictionary<int, int> dUnSeqSelectedRows = new Dictionary<int, int>();

            // Build a list of the selected customers/addresses from the unsequenced addresses
            foreach (DataGridViewRow row in ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).SelectedRows)
            {
                n++;
            }
            if (n <= 0)
            {
                MessageBox.Show("Select an address to reassign", "WCustomerSequencer");
                return;
            }
            foreach (DataGridViewRow row in ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).SelectedRows)
            {
                rowIndex = row.Index;
                nAdrId = this.dw_unseq.GetValue<int?>(rowIndex, "AdrId").GetValueOrDefault();
                sRoadName = this.dw_unseq.GetValue<string>(rowIndex, "RoadName");
                sCustomer = this.dw_unseq.GetValue<string>(rowIndex, "Customer");
                dUnSeqSelectedRows.Add(rowIndex, nAdrId);
            }

            /************************ Testing ****************************
            sRoadName = (sRoadName == null) ? "Null" : sRoadName;
            sCustomer = (sCustomer == null) ? "Null" : sCustomer;
            MessageBox.Show("Rows selected = " + n.ToString() + "\n"
                           + "AdrID = " + nAdrId.ToString() + "\n"
                           + "Road = " + sRoadName + "\n"
                           + "Customer = " + sCustomer + "\n\n"
                           + "Open WReassignContract", "cb_reassign_Click");
            /************************ Testing ****************************/

            // Open WReassignContractNo
            // WReassignContractNo will only offer the alternate contract numbers;
            // not the current one.
            StaticVariables.gnv_app.of_get_parameters().integerparm = il_contract_no;
            StaticVariables.gnv_app.of_get_parameters().stringparm = is_post_code;
            Cursor.Current = Cursors.WaitCursor;

            WReassignContract w_reassign_contract = new WReassignContract();
            w_reassign_contract.ShowDialog();

            // Get the selected contract_no
            // 0 indicates a cancel
            int nContractNo = (int)StaticVariables.gnv_app.of_get_parameters().integerparm;
            if (nContractNo == 0) // || nContractNo == il_contract_no)
            {
                MessageBox.Show("WReassignContract returned " + nContractNo.ToString() + "\n"
                                + "No contracts will be reassigned");
                ((DUnseqAddresses)idw_unseq.DataObject).ResetUpdate();
                return;
            }

            //Step through the selected customers/addresses, updating their contract_no
            bool rc = false;
            string msg = "Customers " + "\n\n" ;

            Cursor.Current = Cursors.WaitCursor;
            foreach (KeyValuePair<int, int> entry in dUnSeqSelectedRows)
            {
                rowIndex = entry.Key;
                nAdrId = entry.Value;
                this.dw_unseq.SetValue(rowIndex, "Contract_no", nContractNo);
                sCustomer = this.dw_unseq.GetValue<string>(rowIndex, "Customer");
                int nContract = (int)this.dw_unseq.GetValue<int?>(rowIndex, "ContractNo");
                msg += sCustomer + "\n";
                RDSDataService dataService = RDSDataService.UpdateAddrContractNo(nAdrId, nContractNo);
                rc = dataService.ret;
                if (!rc)
                {
                    MessageBox.Show("Error updating address table with new contract number. \n"
                                    + "\nError message: " + dataService.SQLErrText
                                    + "\n\nNo customers reassigned."
                                    ,"Error");
                    break;
                }
            }
            // Tell the user what was done (if successful)
            if (!rc)
            {
                ((DUnseqAddresses)idw_unseq.DataObject).ResetUpdate();
                return;
            }
            MessageBox.Show(msg + "\nReassigned to contract " + nContractNo.ToString());

            // Clear dw_unseq and re-populate it with any remaining addresses
            ((DUnseqAddresses)idw_unseq.DataObject).Reset();
            ((DUnseqAddresses)idw_unseq.DataObject).Retrieve(il_contract_no);
        }
    }
}
