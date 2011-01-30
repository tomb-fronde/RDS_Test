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
    // TJB  Jan-2011  Sequencing review
    //     Modified selection and sequencing algorithm.
    //     Added 'arror' buttons and 'Sequence at end' and 'Reverse sequence' buttons.
    //     Manages sequences for whole contract (not by frequency within contract)
    //     Called from Address tab in Contract details window.
    public partial class WCustomerSequencer : WAncestorWindow
    {
        #region Define
        public int? il_contract_no;

        public int? il_sf_key;

        public string is_delivery_days = String.Empty;

        public int il_sequence = 0;
        public int ig_sequence = 0;

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
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            string ls_con_title;
            NParameters lnv_Parameters;
            //  Window Resize Behaviour
            /*? of_setresize(true);
            inv_resize.of_register(dw_unseq, 0, 0, 50, 100);
            inv_resize.of_register(dw_seq, 50, 0, 50, 100);
            inv_resize.of_register(cb_seq, 50, 100, 0, 0);
            inv_resize.of_register(cb_unseq, 100, 100, 0, 0);
            inv_resize.of_register(gb_unseq, 0, 0, 50, 100);
            inv_resize.of_register(gb_seq, 50, 0, 50, 100);
            inv_resize.of_register(cb_save, 100, 0, 0, 0);
            inv_resize.of_register(cb_close, 100, 0, 0, 0);
            inv_resize.of_register(cb_stripmaker, 100, 0, 0, 0); */
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

        public override int pfc_save()
        {
            //  PBY 03/09/2002 SR#4417 
            //  moved the save processing from cb_save.click to here to allow
            //  save to kick in if user closes the window by pressing the "x" icon 
            int  ll_row;
            int  ll_rc;
            int? ll_rc1;
            int? ll_ind;
            int  ll_rowcount;
            int? ll_sequence_no;
            int? ll_address_id;
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
            //  unsequenced addresses  ( but this process is deathly slow!).
            if (StaticFunctions.IsDirty(dw_seq) || StaticFunctions.IsDirty(dw_unseq))
            {
                // Remove all sequenced for that contract
                //* update address set seq_num = null 
                //*  where contract_no = :il_contract_no  
                //RDSDataService dataService = RDSDataService.DeleteFromAddressFreqSeq(il_sf_key, il_contract_no, is_delivery_days);
                RDSDataService dataService = RDSDataService.ClearAddressSeq(il_contract_no);
                if (dataService.SQLCode != 0)
                {
                    MessageBox.Show("Unable to delete old route sequence.\n\n" 
                		       + "Error Code: " + dataService.SQLCode + '\n' 
                		       + "Error Text: " + dataService.SQLErrText + "\n" 
                		       + "Parameters: \n" 
                               + "   contract = " + il_contract_no.ToString() 
                		       , "Database Error"
                		       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ll_rc = FAILURE;
                }
                else
                {
                    ll_rc = SUCCESS;
                }

                ll_rowcount = dw_seq.RowCount;
                if (ll_rc == SUCCESS && ll_rowcount > 0)
                {
                    for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
                    {
                        ll_sequence_no = dw_seq.GetItem<SeqAddresses>(ll_row).SequenceNo;
                        ll_address_id = dw_seq.GetItem<SeqAddresses>(ll_row).AdrId;
                        //* update address
                        //*    set seq_num = :ll_sequence_no
                        //*  where adr_id = :ll_address_id
                        //dataService = RDSDataService.InsertAddressFreqSeq(il_sf_key, ll_sequence_no, il_contract_no, ll_address_id, is_delivery_days);
                        dataService = RDSDataService.UpdateAddressSeq(ll_sequence_no, ll_address_id);
                        if (dataService.SQLCode != 0)
                        {
                            MessageBox.Show("Unable to insert new route sequence.  \n\n" 
                            		    + "Error Code: " + dataService.SQLCode + "\n" 
                            		    + "Error Text: " + dataService.SQLErrText
                                        + "Parameters: \n"
                                        + "   adr_id = " + ll_address_id.ToString() + "\n"
                                        + "   seq_no = " + ll_sequence_no.ToString()
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

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            dw_unseq.URdsDw_GetFocus(null, null);
            dw_seq.URdsDw_GetFocus(null, null);
            is_userid = StaticVariables.LoginId;
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
            DataGridViewSelectedRowCollection rowsSelected
                         = ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).SelectedRows;
            int n1 = rowsSelected.Count;

            if (dw_unseq.RowCount == 0)
            {
                return;
            }
        }

        public virtual void dw_unseq_clicked(object sender, EventArgs e)
        {
            int row;

            if (dw_unseq.RowCount == 0)
            {
                return;
            }
            this.dw_unseq.SuspendLayout();

            // See if any previously-sequenced rows have been de-selected
            // If so, unsequence them.
            for (row = 0; row < dw_unseq.RowCount; row++)
            {
                if (!(dw_unseq.DataObject.Controls[0] as DataEntityGrid).Rows[row].Selected)
                {
                    if (dw_unseq.GetItem<UnseqAddresses>(row).Sequence != null)
                    {
                        //wf_removesequence(row);
                        int seq = (int)dw_unseq.GetItem<UnseqAddresses>(row).Sequence;
                        dw_unseq.GetItem<UnseqAddresses>(row).Sequence = null;
                    }
                }
            }

            // Add sequence numbers to the selected rows that don't have any
            for (row = 0; row < dw_unseq.RowCount; row++)
            {
                if ((dw_unseq.DataObject.Controls[0] as DataEntityGrid).Rows[row].Selected)
                {
                    if (dw_unseq.GetItem<UnseqAddresses>(row).Sequence == null)
                    {
                        il_sequence++;
                        dw_unseq.GetItem<UnseqAddresses>(row).Sequence = il_sequence;
                        dw_unseq.AcceptText();
                    }
                }
            }
            row = dw_unseq.GetRow();

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
            dw_seq.URdsDw_Clicked(sender, e);
            int nRows = ((Metex.Windows.DataEntityGrid)(this.dw_seq.GetControlByName("grid"))).SelectedRows.Count;

            //if (dw_seq.GetRow() < 0)
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

        public virtual void cb_seq_clicked(object sender, EventArgs e, bool add_sw)
        {
            //? base.clicked();
            Cursor.Current = Cursors.WaitCursor;
            this.SuspendLayout();
            dw_unseq.AcceptText();

            dw_unseq.DataObject.FilterString = "sequence > 0";

            //! sort the sequence numbers first so that we insert numbers from the smallest to biggest
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
                                      , ""
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
                        MessageBox.Show("Route saved"
                                        , ""
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information);

                        idw_seq.ResetUpdate();
                        idw_unseq.ResetUpdate();
                    }
                    else
                    {
                        MessageBox.Show("Error saving route.\n" 
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
            bool lb_route_saved;
            //  TJB SR4691  Aug 2006
            //  Handle saving of validation indicator  ( which may be the only thing changed)
            //  Note:  pfc_save will have saved the indicator  ( if it was set) 
            //         and returns SUCCESS.
            //  lb_route_saved records whether the route was successfully saved.
            //  Used at end to decide  ( partly) whether to reset dw_seq and dw_unseq
            lb_route_saved = false;
            //  TJB SR4461
            //  If the route has been modified, ask whether to save it
            if (StaticFunctions.IsDirty(idw_seq) || StaticFunctions.IsDirty(idw_unseq))
            {
                ans = MessageBox.Show("Do you want to save the modified route"
                                      , ""
                                      , MessageBoxButtons.OKCancel
                                      , MessageBoxIcon.Question
                                      , MessageBoxDefaultButton.Button1);
                //  Cancel: return to window
                if (ans == DialogResult.Cancel)
                {
                    return;
                }
                //  OK: Save it and tell the user whether it was successful or not
                Cursor.Current = Cursors.WaitCursor;
                // PBY 03/09/2002 SR#4417 
                this.pfc_save();
                if (true) // SUCCESS
                {
                    //  Disable the CLoseQuery processing
                    ib_disableclosequery = true;
                    MessageBox.Show("Route saved."
                                    , ""
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lb_route_saved = true;
                }
                else
                {
                    MessageBox.Show("Error saving route.\n" 
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
                //! idw_addr_sequence_ind.Update();
                idw_addr_sequence_ind.Save();
            }
            if (lb_route_saved)
            {
                idw_seq.Reset();
                idw_seq.Retrieve(new object[]{il_contract_no});
                idw_seq.SelectRow(0, false);
            }
            idw_unseq.ResetUpdate();
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
            string ls_inidir;
            string ls_inifilename;
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

            ls_inidir = StaticFunctions.GetCurrentDirectory();
            ls_inifilename = "stripmaker.ini";
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
                ls_inifilename = dlg.FileName;
                if (ll_dr == DialogResult.Cancel)
                {
                    return; //? return 0;
                }
                else if ((int)ll_dr < 0)
                {
                    MessageBox.Show("Error selecting inifile name"
                                    , "Error"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;//? return -1;
                }
                //  Save the filename so we don't need to ask next time
                StaticVariables.gnv_app.of_setstripmakerini(is_inifile);
                //  Make sure we haven't changed the working directory
                //? ChangeDirectory(StaticVariables.gnv_app.of_getstartupdir());
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
                ls_savedir = StaticFunctions.GetCurrentDirectory();
            }
            else if (!(File.Exists(ls_savedir)))
            {
                MessageBox.Show("Default stripmaker files directory not found:" + ls_savedir + "\n\n" 
                		        + "Please select another."
                		        , "Warning"
                		        , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ls_savedir = StaticFunctions.GetCurrentDirectory();
            }
            ls_filenamedir = ls_savedir + ls_filename;
            SaveFileDialog dlg2 = new SaveFileDialog();
            dlg2.Title = "Save Stripmaker route files to ...";
            dlg2.InitialDirectory = ls_filenamedir;
            dlg2.FileName = ls_filename;
            ll_dr = dlg2.ShowDialog();
            ls_filenamedir = dlg2.FileName;
            if (ll_dr == DialogResult.Cancel)
            {
                return; //? return 0;
            }
            else if ((int)ll_dr < 0)
            {
                MessageBox.Show("Error selecting save file name"
                               , "Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;//? return -(1);
            }
            //  Make sure we don't change the working directory
            //? ChangeDirectory(StaticVariables.gnv_app.of_getstartupdir());
            //  Strip any file extension included
            ll_rc = ls_filename.LastIndexOf('.');
            if (ll_rc > 0)
            {
                ls_filename = ls_filename.Substring(ll_rc);
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
                    return; //? return 0;
                }
            }
            //  Delete any existing stripmaker files
            lf_cleanup();
            // ---------------------------------------------------
            //  Generate the route's header file
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
                return;//? return -(1);
            }
            //  Get contract information for header file
            // select contract.con_title, outlet.o_name 
            //   into :ls_contract_title, :ls_delivery_office
            //   from contract, outlet
            //  where contract.contract_no = :il_contract_no 
            //    and contract.con_base_office = outlet.outlet_id using SQLCA; */
            RDSDataService dataService = RDSDataService.GetContractInfoByNo(il_contract_no);
            if (dataService.ContractInfoByNoList.Count > 0)
            {
                ContractInfoByNoItem item = dataService.ContractInfoByNoList[0];
                ls_contract_title = item.ConTitle;
                ls_delivery_office = item.OName;
            }
            if (dataService.SQLCode != 0)
            {
                MessageBox.Show("Contract title lookup failed\n" 
                                + dataService.SQLErrText + "\n\n"
                                + "(No Stripmaker files have been generated)"
                                , "SQL error " + dataService.SQLCode
                                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //? rollback;
                return;//? return -(1);
            }
            //? commit;
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
                if (ls_inivalue.Length < 1)
                {
                    ls_inivalue = "<look up>";
                    if (ls_inikey == "OfficeName")
                    {
                        ls_inivalue = '\"' + ls_delivery_office + '\"';
                    }
                    else if (ls_inikey == "RoundName")
                    {
                        ls_inivalue = '\"' + ls_contract_title + '\"';
                    }
                    else if (ls_inikey == "RoundNumber")
                    {
                        ls_inivalue = il_contract_no.ToString();
                    }
                }
                ll_rc = 1; li_file.WriteLine(ls_inikey + ',' + ls_inivalue);
                if (ll_rc > 0)
                    ll_written++;
                else
                    ll_errors++;
            }
            li_file.Close();
            // ---------------------------------------------------
            //  Generate the route's street file
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
                return;//? return -(1);
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
                ls_colournames.Add("Default");//[li_colours] = "Default";
                ls_colourvalues.Add("255,0");//[li_colours] = "255,0";
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
                return;//? return -(1);
            }
            else if (false)
            {
                MessageBox.Show("Failed to sort addresses by road name.\n\n" 
                		+ "(No Stripmaker files have been generated)"
                		, "Error"
                		, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lf_cleanup();
                return;//? return -(1);
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
            //  Generate the route's delivery point file
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
                return;//? return -(1);
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
                return;//? return -(1);
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
                                    + sAdrUnit + ","                        // Flat number
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
            return; //? return 0;
        }

        public virtual void dw_addr_sequence_ind_itemchanged(object sender, EventArgs e)
        {
            dw_addr_sequence_ind.URdsDw_Itemchanged(sender, e);
            //  TJB  SR4691  Aug 2006
            //  Toggle the validated indicator and update the date and userID
            // 
            //  Note: the validated indicator is the only thing selectable
            //  in this data window so we don't need to check which field
            //  was selected.
            string ls_name;
            ls_name = this.dw_addr_sequence_ind.GetColumnName();
            int rows = this.dw_addr_sequence_ind.RowCount;
            int row = this.dw_addr_sequence_ind.GetRow();
            if (ls_name == "rf_valid_ind")
            {
                if (rows > 0 && row < 0)
                    row = 0;
                if (row >= 0)
                {
                    idw_addr_sequence_ind.GetItem<AddrSequenceInd>(row).RfValidDate = System.DateTime.Today;
                    idw_addr_sequence_ind.GetItem<AddrSequenceInd>(row).RfValidUser = is_userid;
                }
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

        private void cb_up_arrow_Click(object sender, EventArgs e)
        {
            int  nPrevRow = 0;
            int? nPrevSeq = 0, nThisSeq = 0;
            int? nPrevSeqNum = 0, nThisSeqNum = 0;

            SeqAddresses thisItem = new SeqAddresses();

            int nRows = dw_seq.RowCount;
            List<int> selRows = new List<int>();
            for (int i = 1; i < nRows; i++)
            {
                if (dw_seq.IsSelected(i))
                {
                    selRows.Add(i);
                }
            }

            foreach (int nThisRow in selRows)
            {
                nPrevRow = nThisRow - 1;

                nPrevSeqNum = dw_seq.GetItem<SeqAddresses>(nPrevRow).SeqNum;
                nThisSeqNum = dw_seq.GetItem<SeqAddresses>(nThisRow).SeqNum;
                nPrevSeq = dw_seq.GetItem<SeqAddresses>(nPrevRow).Sequence;
                nThisSeq = dw_seq.GetItem<SeqAddresses>(nThisRow).Sequence;

                thisItem.AdrAlpha = dw_seq.GetItem<SeqAddresses>(nThisRow).AdrAlpha;
                thisItem.AdrId = dw_seq.GetItem<SeqAddresses>(nThisRow).AdrId;
                thisItem.AdrNo = dw_seq.GetItem<SeqAddresses>(nThisRow).AdrNo;
                thisItem.AdrNum = dw_seq.GetItem<SeqAddresses>(nThisRow).AdrNum;
                thisItem.AdrNumAlpha = dw_seq.GetItem<SeqAddresses>(nThisRow).AdrNumAlpha;
                thisItem.AdrUnit = dw_seq.GetItem<SeqAddresses>(nThisRow).AdrUnit;
                thisItem.ContractNo = dw_seq.GetItem<SeqAddresses>(nThisRow).ContractNo;
                thisItem.Customer = dw_seq.GetItem<SeqAddresses>(nThisRow).Customer;
                thisItem.RoadName = dw_seq.GetItem<SeqAddresses>(nThisRow).RoadName;
                thisItem.RoadNameId = dw_seq.GetItem<SeqAddresses>(nThisRow).RoadNameId;
                thisItem.SeqNum = dw_seq.GetItem<SeqAddresses>(nThisRow).SeqNum;
                thisItem.Sequence = dw_seq.GetItem<SeqAddresses>(nThisRow).Sequence;

                dw_seq.DeleteItemAt(nThisRow);
                dw_seq.InsertItem<SeqAddresses>(nPrevRow);

                dw_seq.GetItem<SeqAddresses>(nPrevRow).AdrAlpha = thisItem.AdrAlpha;
                dw_seq.GetItem<SeqAddresses>(nPrevRow).AdrId = thisItem.AdrId;
                dw_seq.GetItem<SeqAddresses>(nPrevRow).AdrNo = thisItem.AdrNo;
                dw_seq.GetItem<SeqAddresses>(nPrevRow).AdrNum = thisItem.AdrNum;
                dw_seq.GetItem<SeqAddresses>(nPrevRow).AdrNumAlpha = thisItem.AdrNumAlpha;
                dw_seq.GetItem<SeqAddresses>(nPrevRow).AdrUnit = thisItem.AdrUnit;
                dw_seq.GetItem<SeqAddresses>(nPrevRow).ContractNo = thisItem.ContractNo;
                dw_seq.GetItem<SeqAddresses>(nPrevRow).Customer = thisItem.Customer;
                dw_seq.GetItem<SeqAddresses>(nPrevRow).RoadName = thisItem.RoadName;
                dw_seq.GetItem<SeqAddresses>(nPrevRow).RoadNameId = thisItem.RoadNameId;
                dw_seq.GetItem<SeqAddresses>(nPrevRow).SeqNum = thisItem.SeqNum;
                dw_seq.GetItem<SeqAddresses>(nPrevRow).Sequence = thisItem.Sequence;
            }

            dw_seq.Refresh();
            dw_seq.SelectRow(0, false);

            int nFirstRow = 1;
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

            il_sequence = dw_seq.GetSelectedRow(0);
            il_sequence = (il_sequence < 0) ? 0 : il_sequence;
        }

        private void cb_down_arrow_Click(object sender, EventArgs e)
        {
            int nNextRow = 0, nLastRow = 0;
            int? nThisSeq = 0;
            int? nThisSeqNum = 0;

            SeqAddresses thisItem = new SeqAddresses();

            int nRows = dw_seq.RowCount;
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
                movedRows.Add(nNextRow+1);

                nThisSeq = dw_seq.GetItem<SeqAddresses>(nThisRow).Sequence;
                nThisSeqNum = dw_seq.GetItem<SeqAddresses>(nThisRow).SeqNum;

                thisItem.AdrAlpha = dw_seq.GetItem<SeqAddresses>(nThisRow).AdrAlpha;
                thisItem.AdrId = dw_seq.GetItem<SeqAddresses>(nThisRow).AdrId;
                thisItem.AdrNo = dw_seq.GetItem<SeqAddresses>(nThisRow).AdrNo;
                thisItem.AdrNum = dw_seq.GetItem<SeqAddresses>(nThisRow).AdrNum;
                thisItem.AdrNumAlpha = dw_seq.GetItem<SeqAddresses>(nThisRow).AdrNumAlpha;
                thisItem.AdrUnit = dw_seq.GetItem<SeqAddresses>(nThisRow).AdrUnit;
                thisItem.ContractNo = dw_seq.GetItem<SeqAddresses>(nThisRow).ContractNo;
                thisItem.Customer = dw_seq.GetItem<SeqAddresses>(nThisRow).Customer;
                thisItem.RoadName = dw_seq.GetItem<SeqAddresses>(nThisRow).RoadName;
                thisItem.RoadNameId = dw_seq.GetItem<SeqAddresses>(nThisRow).RoadNameId;
                thisItem.SeqNum = dw_seq.GetItem<SeqAddresses>(nThisRow).SeqNum;
                thisItem.Sequence = dw_seq.GetItem<SeqAddresses>(nThisRow).Sequence;

                dw_seq.DeleteItemAt(nThisRow);
                dw_seq.InsertItem<SeqAddresses>(nNextRow);

                dw_seq.GetItem<SeqAddresses>(nNextRow).AdrAlpha = thisItem.AdrAlpha;
                dw_seq.GetItem<SeqAddresses>(nNextRow).AdrId = thisItem.AdrId;
                dw_seq.GetItem<SeqAddresses>(nNextRow).AdrNo = thisItem.AdrNo;
                dw_seq.GetItem<SeqAddresses>(nNextRow).AdrNum = thisItem.AdrNum;
                dw_seq.GetItem<SeqAddresses>(nNextRow).AdrNumAlpha = thisItem.AdrNumAlpha;
                dw_seq.GetItem<SeqAddresses>(nNextRow).AdrUnit = thisItem.AdrUnit;
                dw_seq.GetItem<SeqAddresses>(nNextRow).ContractNo = thisItem.ContractNo;
                dw_seq.GetItem<SeqAddresses>(nNextRow).Customer = thisItem.Customer;
                dw_seq.GetItem<SeqAddresses>(nNextRow).RoadName = thisItem.RoadName;
                dw_seq.GetItem<SeqAddresses>(nNextRow).RoadNameId = thisItem.RoadNameId;
                dw_seq.GetItem<SeqAddresses>(nNextRow).SeqNum = thisItem.SeqNum;
                dw_seq.GetItem<SeqAddresses>(nNextRow).Sequence = thisItem.Sequence;
            }
            dw_seq.Refresh();
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

            il_sequence = dw_seq.GetSelectedRow(0);
            il_sequence = (il_sequence < 0) ? 0 : il_sequence;
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
    }
}
