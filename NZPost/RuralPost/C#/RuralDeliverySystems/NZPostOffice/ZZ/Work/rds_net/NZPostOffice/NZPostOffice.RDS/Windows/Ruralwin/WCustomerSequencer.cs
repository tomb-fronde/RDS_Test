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
    public partial class WCustomerSequencer : WAncestorWindow
    {
        #region Define
        public int? il_contract_no;

        public int? il_sf_key;

        public string is_delivery_days = String.Empty;

        public int il_sequence = 0;

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

        //add by ybfan
        public DataGridViewSelectedRowCollection l_tempselect;

        public List<int> seqSelected = new List<int>();

        public List<int> unseqSelected = new List<int>();
        #endregion

        public WCustomerSequencer()
        {
            this.InitializeComponent();
            //jlwang:mvoed from IC
            dw_unseq.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_unseq_constructor);
            //((DUnseqAddresses)dw_unseq.DataObject).CellClick += new EventHandler(dw_unseq_clicked);
            //((DUnseqAddresses)dw_unseq.DataObject).CellMouseEnter += new DataGridViewCellEventHandler(dw_unseq_CellMouseEnter);
            ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).MouseDown += new MouseEventHandler(WCustomerSequencer_MouseDown);
            ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).Click += new EventHandler(WCustomerSequencer_Click);
            ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).Click += new EventHandler(dw_unseq_clicked);

            dw_seq.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_seq_constructor);
            ((DSeqAddresses)dw_seq.DataObject).CellClick += new EventHandler(dw_seq_clicked);
            ((DSeqAddresses)dw_seq.DataObject).CellMouseDown += new DataGridViewCellMouseEventHandler(dw_seq_RowEnter);
            dw_addr_sequence_ind.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_addr_sequence_ind_constructor);
            ((DAddrSequenceInd)dw_addr_sequence_ind.DataObject).CheckedChanged += new EventHandler(dw_addr_sequence_ind_itemchanged);
            //jlwang:end
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
            //  messagebox ( 'w_customer_sequencer.pfc_preopen',  &
            //   				'     Contract = '+il_contract_no.ToString()+'\r'  &
            //   			 + '       sf_key = '+il_sf_key.ToString()+'\r'  &
            //   			 + 'Delivery_Days = '+is_delivery_days )

            // select con_title into :ls_con_title from contract where contract_no = :il_contract_no using SQLCA; 
            RDSDataService dataService = RDSDataService.GetContractConTitle(il_contract_no);
            ls_con_title = dataService.strVal;
            this.Text = "Contract " + il_contract_no.ToString() + " - " + ls_con_title + " - " + is_delivery_days;
            //? of_setlogicalunitofwork(true);
        }

        public override void open()
        {
            base.open();
            //  TJB  SR4691  Aug 2006
            //  dw_addr_sequence_ind added
            //!idw_seq.Retrieve(new object[] { il_contract_no, il_sf_key, is_delivery_days });
            ((DSeqAddresses)idw_seq.DataObject).Retrieve(il_contract_no, il_sf_key, is_delivery_days);
            ((DUnseqAddresses)idw_unseq.DataObject).Retrieve(il_contract_no, il_sf_key, is_delivery_days);
            idw_seq.SelectRow(0, false);
            idw_unseq.SelectRow(0, false);
            ((DAddrSequenceInd)idw_addr_sequence_ind.DataObject).Retrieve(il_contract_no, il_sf_key, is_delivery_days);
        }

        public override int pfc_save()
        {
            //  PBY 03/09/2002 SR#4417 
            //  moved the save processing from cb_save.click to here to allow
            //  save to kick in if user closes the window by pressing the "x" icon 
            int ll_row;
            int ll_rc;
            int? ll_rc1;
            int? ll_ind;
            int? ll_seq1;
            int? ll_seq2;
            int ll_rowcount;
            int? ll_sequence_no;
            int? ll_address_id;
            //  TJB  SR4691  Aug 2006
            //  Add condition on saving of sequence
            //  - do only if changed  ( previously assumed any change was 
            //    to the address sequence)
            //  TJB  SR4691  fixup  ( unsequenced addresses weren't being saved)
            //  Re-wrote process to use PB's update function for sequencing
            //  and explicit delete for unsequencing.  Involved modifying 
            //  d_seq_address and d_unseq_address  ( add columns so the 
            //  update could be done by PB).
            // =====> undid change, hopefully temporarily  25 Aug 2006 <=====
            //  Used to decide whether to also save the validation indicator
            //  Also used to determine which status to return.
            ll_rc = SUCCESS;
            /* 
                if dw_unseq.modifiedCount ( ) > 0 then
                ll_rowcount = dw_unseq.RowCount
                For ll_row = 1 to ll_rowcount
                l_status = dw_unseq.getItemStatus ( ll_row,0,PRIMARY!)
                if not dw_unseq.getItemStatus ( ll_row,0,PRIMARY!) = NotModified! then
                ll_address_id  = dw_unseq.GetItemNumber ( ll_row, "adr_id")
                delete from address_frequency_sequence
                where contract_no = :il_contract_no  
                and sf_key      = :il_sf_key
                and adr_id      = :ll_address_id
                and rf_delivery_days = :is_delivery_days
                using SQLCA;
                IF SQLCA.SQLCODE <> 0 THEN
                MessageBox.Show ( & "Unable to delete address.\r\n"      & + "Error Code: " + String ( sqlca.sqlcode) + "\r\n" & + "Error Text: " + SQLCA.sqlerrtext	+"\r\n\r\n"     & + "Parameters: "                         + "\r\n" & + "contract = " + string ( il_contract_no) + "\r\n" & + "address  = " + string ( ll_address_id)  + "\r\n" & + "sf_key   = " + string ( il_sf_key)      + "\r\n" & + "delivery_days = " + is_delivery_days ,  "Database Error" )
                ll_rc = FAILURE
                exit
                END IF
                end if
                next
                end if	
                if ll_rc = SUCCESS then
                // TJB  SR4691 fixup
                // The sequence number displayed is not what needs to be saved.
                // Check for and make changes before saving.
                ll_rowcount = dw_unseq.RowCount
                For ll_row = 1 to ll_rowcount
                ll_seq1 = dw_seq.getItemNumber ( ll_row,'sequence_no')
                ll_seq2 = dw_seq.getItemNumber ( ll_row,'seq_num')
                if not ll_seq1 = ll_seq2 then
                dw_seq.setItem ( ll_row,'seq_num',ll_seq1)
                end if
                next
                if dw_seq.modifiedCount ( ) > 0 or dw_unseq.modifiedCount ( ) > 0 then
                ll_rc = dw_seq.update ( )
                end if
                end if
            */
            //  TJB  SR4691 fixup
            //  Added dw_unseq.modifiedCount to fix failure to save
            //  unsequenced addresses  ( but this process is deathly slow!).
            if (StaticFunctions.IsDirty(dw_seq) || StaticFunctions.IsDirty(dw_unseq))
            {
                // Remove all sequenced for that contract/sf_key/rf_delivery_days
                /* Delete from address_frequency_sequence where contract_no = :il_contract_no  
                    and sf_key = :il_sf_key and rf_delivery_days = :is_delivery_days using SQLCA; */
                RDSDataService dataService = RDSDataService.DeleteFromAddressFreqSeq(il_sf_key, il_contract_no, is_delivery_days);
                if (dataService.SQLCode != 0)
                {
                    MessageBox.Show("Unable to delete old route sequence.\r\n" + "Error Code: " + dataService.SQLCode + '~' + "Error Text: " + dataService.SQLErrText + "\r\n\r\n" + "Parameters: " + "contract = " + il_contract_no + ", " + "sf_key   = " + il_sf_key + ", " + "delivery_days = " + is_delivery_days, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //? RollBack;
                    ll_rc = FAILURE;
                }
                else
                {
                    //? COMMIT;
                    ll_rc = SUCCESS;
                }
                ll_rowcount = dw_seq.RowCount;
                if (ll_rc == SUCCESS && ll_rowcount > 0)
                {
                    for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
                    {
                        ll_sequence_no = dw_seq.GetItem<SeqAddresses>(ll_row).SequenceNo;
                        ll_address_id = dw_seq.GetItem<SeqAddresses>(ll_row).AdrId;
                        /* Insert Into address_frequency_sequence
                            ( adr_id, sf_key, rf_delivery_days, contract_no, seq_num)
                            Values ( :ll_address_id, :il_sf_key, :is_delivery_days, :il_contract_no, :ll_sequence_no)
                            Using SQLCA; */
                        dataService = RDSDataService.InsertAddressFreqSeq(il_sf_key, ll_sequence_no, il_contract_no, ll_address_id, is_delivery_days);
                        if (dataService.SQLCode != 0)
                        {
                            MessageBox.Show("Unable to insert new route sequence.  \r\n\r\n" + "Error Code: " + dataService.SQLCode + "\r\n" + "Error Text: " + dataService.SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //  save succeeded  ( or if there were no sequence changes to save) 
            //  save the validation indicator changes.
            //  If the sequence save failed, turn the validation indicator off
            //  if it isn't already.
            //   ( we assume either update will succeed and only return the 
            //   sequence save status)
            if (ll_rc == SUCCESS)
            {
                if (StaticFunctions.IsDirty(idw_addr_sequence_ind))
                {
                    ll_rc1 = SUCCESS;
                    idw_addr_sequence_ind.Save();

                    if (!(ll_rc1 == SUCCESS))
                    {
                        MessageBox.Show("Save of validation indicator failed - continuing.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return; //? return 1;
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
            int li_rc;
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
            int li_rc = 0;
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
                    //  Look for a section header components  ( the OpenBracket and CloseBracket  ( if any)).
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
                    //  Read one line from the file  ( validate the rc).
                    ls_line = li_file.ReadLine();
                    //  Check if any characters were read.		
                    if (ls_line != null)
                    {
                        //  Check for a "commented" line  ( skip if found).
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
            int lCount;
            int lRow = -1;
            int? lNull;
            if (al_row >= 0)
            {
                lSeq = dw_unseq.GetItem<UnseqAddresses>(al_row).Sequence;
                if (!(StaticFunctions.f_nempty(lSeq)))
                {
                    dw_unseq.SuspendLayout();
                    while (lSeq <= il_sequence)
                    {
                        lSeq++;

                        //!lRow = dw_unseq.Find("Sequence", lSeq);
                        lRow = -1;
                        for (int i = 0; i < dw_unseq.RowCount; i++)
                        {
                            if (dw_unseq.GetItem<UnseqAddresses>(i).Sequence == lSeq)
                            {
                                lRow = i;
                                break;
                            }
                        }

                        if (lRow >= 0)
                        {
                            dw_unseq.GetItem<UnseqAddresses>(lRow).Sequence = lSeq - 1;
                        }
                    }
                    if (il_sequence > 0)
                    {
                        il_sequence--;
                    }
                    lNull = null;
                    //?dw_unseq.SelectRow(al_row +1, false);
                    dw_unseq.GetItem<UnseqAddresses>(al_row).Sequence = lNull;
                    dw_unseq.ResumeLayout(false);
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
        public void WCustomerSequencer_Click(object sender, EventArgs e)
        {
            if (dw_unseq.RowCount == 0)
            {
                return;
            }
            this.dw_unseq.SuspendLayout();
            foreach (DataGridViewRow var in ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).Rows)
            {
                var.Selected = false;
            }
            //((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).CurrentRow.Selected = false;
            foreach (DataGridViewRow var in l_tempselect)
            {
                var.Selected = true;
            }
            ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).CurrentRow.Selected = !(((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).CurrentRow.Selected);
            this.dw_unseq.ResumeLayout(false);
        }

        public void WCustomerSequencer_MouseDown(object sender, MouseEventArgs e)
        {
            l_tempselect = ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).SelectedRows;
        }

        public virtual void dw_unseq_clicked(object sender, EventArgs e)
        {
            int row = dw_unseq.GetRow();

            bool result;

            if (dw_unseq.RowCount == 0)
            {
                return;
            }
            result = !(dw_unseq.DataObject.Controls[0] as DataEntityGrid).Rows[dw_unseq.GetRow()].Selected;

            if (row >= 0)
            {
                if (result)
                {
                    wf_removesequence(row);
                }
                else
                {
                    il_sequence++;
                    dw_unseq.GetItem<UnseqAddresses>(row).Sequence = il_sequence;
                    dw_unseq.AcceptText();
                }
            }

            if (this.dw_unseq.GetSelectedRow(0) < 0)
            {
                cb_seq.Enabled = false;
            }
            else
            {
                cb_seq.Enabled = true;
            }
            return;// 1;

            //// ***********************
            //// ANCESTOR OVERRIDDEN !!!
            //// ***********************
            ////!bool result = false; - made this variable class level to be accessed by CellMouseEnter and clciked events of dw_unseq
            ////p! following line moved to CellEnter to get right value
            //result = !(dw_unseq.DataObject.Controls[0] as DataEntityGrid).Rows[dw_unseq.GetRow()].Selected;

            //if (!StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyCtrl))
            //{
            //    il_sequence = 1;
            //    for (int i = 0; i < dw_unseq.RowCount; i++)
            //    {
            //        dw_unseq.GetItem<UnseqAddresses>(i).Sequence = null;
            //    }

            //    dw_unseq.GetItem<UnseqAddresses>(row).Sequence = il_sequence;
            //}
            //else
            //{
            //    if (row >= 0)
            //    {
            //        if (result)
            //        {
            //            //?dw_unseq.SetCurrent(row);
            //            //dw_unseq.SelectRow(row + 1, false);
            //            wf_removesequence(row);
            //        }
            //        else
            //        {
            //            //?dw_unseq.SelectRow(row + 1, true);
            //            dw_unseq.SetCurrent(row);
            //            il_sequence++;
            //            dw_unseq.GetItem<UnseqAddresses>(row).Sequence = il_sequence;
            //            dw_unseq.AcceptText();
            //        }
            //    }
            //}
            //dw_unseq.Refresh();
            //if (dw_unseq.GetSelectedRow(0) < 0)
            //{
            //    cb_seq.Enabled = false;
            //}
            //else
            //{
            //    cb_seq.Enabled = true;
            //}
            //return; //? return 1;
        }

        public virtual void dw_seq_clicked(object sender, EventArgs e)
        {
            dw_seq.URdsDw_Clicked(sender, e);
            if (dw_seq.GetRow()/*?dw_seq.GetSelectedRow(0)*/ < 0)
            {
                cb_unseq.Enabled = false;
            }
            else
            {
                cb_unseq.Enabled = true;
            }

            //!dw_seq.SelectAllRows(false);
            //foreach (int i in seqSelected)
            //{
            //    dw_seq.SelectRow(i, true);    
            //!}

        }

        public void dw_seq_RowEnter(object sender, DataGridViewCellMouseEventArgs e)
        {
            //!if (((Metex.Windows.DataEntityGrid)(dw_seq.DataObject.GetControlByName("grid"))).Rows[e.RowIndex].Selected)
            //{
            //    seqSelected.Remove(e.RowIndex);
            //}
            //else
            //{
            //    bool found = false;
            //    foreach (int i in seqSelected)
            //    {
            //        if (i == e.RowIndex)
            //        {
            //            found = true;
            //            break;
            //        }
            //    }
            //    if (!found)
            //    {
            //        seqSelected.Add(e.RowIndex);
            //    }
            //!}
        }

        public virtual void cb_seq_clicked(object sender, EventArgs e)
        {
            //? base.clicked();
            int? ll_unseqrowcount;
            int? ll_seq;
            int ll_rc;
            int? ll_rowloop;
            Cursor.Current = Cursors.WaitCursor;
            this.SuspendLayout();
            dw_unseq.AcceptText();
            // Filter out unseq
            dw_unseq.DataObject.FilterString = "sequence > 0";
            //dw_unseq.DataObject.Filter<UnseqAddresses>();
            //dw_unseq.DataObject.FilterOnce<UnseqAddresses>(dw_unseq_filter);
            //dw_unseq.DataObject.SortString = "sequence A";
            //dw_unseq.DataObject.Sort<UnseqAddresses>();
            ll_unseqrowcount = dw_unseq.RowCount;
            int ll_row = 0;
            int ll_selectedrow = dw_unseq.GetSelectedRow(0);
            int ll = dw_seq.GetSelectedRow(0);
            //for (ll_rowloop = 0; ll_rowloop < ll_unseqrowcount; ll_rowloop++)
            //while (ll_selectedrow >= 0)
            //{
            //    //  NOTE: MoveRow removes the row from the unseq datawindow.
            //    //        If there is more 1 row to be moved to the sequenced
            //    //        datawindow, the next one becomes row 1 in the 
            //    //        unsequenced datawindow; thus what appears to be an
            //    //        incorrect use of row 1 below is in fact correct.
            //    ll_seq = dw_unseq.GetItem<UnseqAddresses>(ll_selectedrow).Sequence;

            //    //ll_rc = dw_unseq.DataObject.RowsMove(1, 1, dw_seq, ll_seq);
            //    dw_seq.InsertItem<SeqAddresses>(0);
            //    dw_seq.GetItem<SeqAddresses>(0).AdrAlpha = dw_unseq.GetItem<UnseqAddresses>(ll_selectedrow).AdrAlpha;
            //    dw_seq.GetItem<SeqAddresses>(0).AdrId = dw_unseq.GetItem<UnseqAddresses>(ll_selectedrow).AdrId;
            //    dw_seq.GetItem<SeqAddresses>(0).AdrNo = dw_unseq.GetItem<UnseqAddresses>(ll_selectedrow).AdrNo;
            //    dw_seq.GetItem<SeqAddresses>(0).AdrNum = dw_unseq.GetItem<UnseqAddresses>(ll_selectedrow).AdrNum;
            //    dw_seq.GetItem<SeqAddresses>(0).AdrNumAlpha = dw_unseq.GetItem<UnseqAddresses>(ll_selectedrow).AdrNumAlpha;
            //    dw_seq.GetItem<SeqAddresses>(0).AdrUnit = dw_unseq.GetItem<UnseqAddresses>(ll_selectedrow).AdrUnit;
            //    dw_seq.GetItem<SeqAddresses>(0).ContractNo = dw_unseq.GetItem<UnseqAddresses>(ll_selectedrow).ContractNo;
            //    dw_seq.GetItem<SeqAddresses>(0).Customer = dw_unseq.GetItem<UnseqAddresses>(ll_selectedrow).Customer;
            //    dw_seq.GetItem<SeqAddresses>(0).RfDeliveryDays = dw_unseq.GetItem<UnseqAddresses>(ll_selectedrow).RfDeliveryDays;
            //    dw_seq.GetItem<SeqAddresses>(0).RoadName = dw_unseq.GetItem<UnseqAddresses>(ll_selectedrow).RoadName;
            //    dw_seq.GetItem<SeqAddresses>(0).RoadNameId = dw_unseq.GetItem<UnseqAddresses>(ll_selectedrow).RoadNameId;
            //    dw_seq.GetItem<SeqAddresses>(0).SeqNum = dw_unseq.GetItem<UnseqAddresses>(ll_selectedrow).SeqNum;
            //    dw_seq.GetItem<SeqAddresses>(0).Sequence = dw_unseq.GetItem<UnseqAddresses>(ll_selectedrow).Sequence;
            //    dw_seq.GetItem<SeqAddresses>(0).SfKey = dw_unseq.GetItem<UnseqAddresses>(ll_selectedrow).SfKey;

            //    ll_row = ll_selectedrow;
            //    ll_selectedrow = dw_unseq.GetSelectedRow(ll_selectedrow + 1/*0*/);
            //    dw_unseq.DeleteItemAt(ll_row);
            //    ll_selectedrow--;//p! one row is deleted - the floowing index should be reduced by one
            //}
            //modify by ybfan
            //pp! - Oct 23, 2007 - remodified by PP
            int l_count = ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).SelectedRows.Count;



            //! sort the sequence numbers first so that we insert numbers from the smllest to biggest
            List<int> DeleteIndexes = new List<int>();
            List<int> unsequencedItems = new List<int>();
            foreach (DataGridViewRow row in ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).SelectedRows)
            {
                unsequencedItems.Add(this.dw_unseq.GetValue<int?>(row.Index, "Sequence").GetValueOrDefault());
                unsequencedItems.Sort();
            }


            //!for (int i = 0; i < l_count; i++)
            foreach (int sortedSequenceNumber in unsequencedItems)
            {
                //!for (int j = 0; j < this.dw_unseq.RowCount; j++)
                foreach (DataGridViewRow row in ((Metex.Windows.DataEntityGrid)(this.dw_unseq.GetControlByName("grid"))).SelectedRows)
                {
                    int i = this.dw_unseq.GetValue<int?>(row.Index, "Sequence").GetValueOrDefault();
                    if (i == sortedSequenceNumber)
                    {
                        //!if (this.dw_unseq.GetValue<int?>(j, "Sequence").GetValueOrDefault() == i + 1)                    
                        if (i > 0)
                        {
                            if (i > dw_seq.RowCount)
                            {
                                i = dw_seq.RowCount + 1;

                            }

                            dw_seq.InsertItem<SeqAddresses>(i - 1);
                            dw_seq.GetItem<SeqAddresses>(i - 1).AdrAlpha = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrAlpha;
                            dw_seq.GetItem<SeqAddresses>(i - 1).AdrId = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrId;
                            dw_seq.GetItem<SeqAddresses>(i - 1).AdrNo = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrNo;
                            dw_seq.GetItem<SeqAddresses>(i - 1).AdrNum = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrNum;
                            dw_seq.GetItem<SeqAddresses>(i - 1).AdrNumAlpha = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrNumAlpha;
                            dw_seq.GetItem<SeqAddresses>(i - 1).AdrUnit = dw_unseq.GetItem<UnseqAddresses>(row.Index).AdrUnit;
                            dw_seq.GetItem<SeqAddresses>(i - 1).ContractNo = dw_unseq.GetItem<UnseqAddresses>(row.Index).ContractNo;
                            dw_seq.GetItem<SeqAddresses>(i - 1).Customer = dw_unseq.GetItem<UnseqAddresses>(row.Index).Customer;
                            dw_seq.GetItem<SeqAddresses>(i - 1).RfDeliveryDays = dw_unseq.GetItem<UnseqAddresses>(row.Index).RfDeliveryDays;
                            dw_seq.GetItem<SeqAddresses>(i - 1).RoadName = dw_unseq.GetItem<UnseqAddresses>(row.Index).RoadName;
                            dw_seq.GetItem<SeqAddresses>(i - 1).RoadNameId = dw_unseq.GetItem<UnseqAddresses>(row.Index).RoadNameId;
                            dw_seq.GetItem<SeqAddresses>(i - 1).SeqNum = dw_unseq.GetItem<UnseqAddresses>(row.Index).SeqNum;
                            dw_seq.GetItem<SeqAddresses>(i - 1).Sequence = dw_unseq.GetItem<UnseqAddresses>(row.Index).Sequence;
                            dw_seq.GetItem<SeqAddresses>(i - 1).SfKey = dw_unseq.GetItem<UnseqAddresses>(row.Index).SfKey;
                            //!dw_unseq.DataObject.DeleteItemAt(row.Index);
                            DeleteIndexes.Add(row.Index);
                            //!break;
                        }
                    }
                }
            }
            //! delete after all inserts are finished
            int offset = 0;
            DeleteIndexes.Sort();//! sort in order to use offset correctly
            foreach (int iDelete in DeleteIndexes)
            {
                if (dw_unseq.DataObject.RowCount > (iDelete - offset))
                {
                    dw_unseq.DataObject.DeleteItemAt(iDelete - offset);
                    offset++;
                }
            }

            il_sequence = 0;
            //dw_unseq.DataObject.FilterString = "";
            //dw_unseq.DataObject.FilterOnce<UnseqAddresses>(EmptyFilter);
            //  TJB  SR4461  Dec 2004
            //  Change definition of adr_no_numeric to strip flat number
            //         ( computed field in datawindow)
            //  Change sort order to include adr_no_alpha and customer
            //  Made sort order change in data window too
            dw_unseq.DataObject.SortString = "road_name A, adr_no_numeric A, adr_alpha A, adr_unit A, customer A";
            dw_unseq.DataObject.Sort<UnseqAddresses>();

            dw_unseq.SelectRow(0, false);
            if (ll == -1)
                dw_seq.SelectRow(0, false);
            this.ResumeLayout(false);
            cb_seq.Enabled = false;
        }

        public virtual void cb_unseq_clicked(object sender, EventArgs e)
        {
            int ll_selectedrow = -1;
            int? ll_null;
            ll_selectedrow = dw_seq.GetSelectedRow(0);
            ll_null = null;
            int ll_row = 0;
            int ll = dw_unseq.GetSelectedRow(0);

            //! get all selected rows in an array/list with indexes adjusted
            List<int> selRows = new List<int>();
            for (int i = 0; i < dw_seq.RowCount; i++)
            {
                if (dw_seq.IsSelected(i))
                {
                    selRows.Add(i - selRows.Count);//! Adjusting index for the rows that will be deleted
                }
            }

            //! delete rows with adjusted indexes - changed code because after DeleteItemAt, GetSelectedRow returned wrong results
            //!while (ll_selectedrow >= 0)
            foreach (int ll_selectedrow1 in selRows)
            {
                dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).Sequence = ll_null;
                //?dw_seq.DataObject.RowCopy<SeqAddresses>(ll_selectedrow, ll_selectedrow, dw_unseq.DataObject/*, dw_unseq.RowCount + 1*/);
                dw_unseq.InsertItem<UnseqAddresses>(0);
                dw_unseq.GetItem<UnseqAddresses>(0).AdrAlpha = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).AdrAlpha;
                dw_unseq.GetItem<UnseqAddresses>(0).AdrId = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).AdrId;
                dw_unseq.GetItem<UnseqAddresses>(0).AdrNo = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).AdrNo;
                dw_unseq.GetItem<UnseqAddresses>(0).AdrNum = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).AdrNum;
                dw_unseq.GetItem<UnseqAddresses>(0).AdrNumAlpha = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).AdrNumAlpha;
                dw_unseq.GetItem<UnseqAddresses>(0).AdrUnit = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).AdrUnit;
                dw_unseq.GetItem<UnseqAddresses>(0).ContractNo = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).ContractNo;
                dw_unseq.GetItem<UnseqAddresses>(0).Customer = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).Customer;
                dw_unseq.GetItem<UnseqAddresses>(0).RfDeliveryDays = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).RfDeliveryDays;
                dw_unseq.GetItem<UnseqAddresses>(0).RoadName = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).RoadName;
                dw_unseq.GetItem<UnseqAddresses>(0).RoadNameId = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).RoadNameId;
                dw_unseq.GetItem<UnseqAddresses>(0).SeqNum = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).SeqNum;
                dw_unseq.GetItem<UnseqAddresses>(0).Sequence = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).Sequence;
                dw_unseq.GetItem<UnseqAddresses>(0).SfKey = dw_seq.GetItem<SeqAddresses>(ll_selectedrow1).SfKey;
                //!ll_row = ll_selectedrow;
                //!ll_selectedrow = dw_seq.GetSelectedRow(ll_selectedrow + 1/*0*/);
                //!dw_seq.DeleteItemAt(ll_row);
                dw_seq.DeleteItemAt(ll_selectedrow1);
                //!ll_selectedrow--;//p! data window rows are reduced, index of the row after the deleted row should be reduced by 1
            }
            //  TJB  SR4461  Dec 2004
            //  Disabled setting unseq datawindow sort order: use whatever
            //  order is defined  ( set in datawindow and reset by cb_seq).
            //  dw_unseq.SetSort ( 'adr_no_numeric')
            dw_seq.SelectRow(0, false);
            dw_unseq.DataObject.Sort<UnseqAddresses>();
            if (ll == -1)
                dw_unseq.SelectRow(0, false);
            cb_unseq.Enabled = false;
        }

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            int? ll_ind;
            DialogResult li_ans = DialogResult.None;
            //  TJB SR4691  Aug 2006
            //  Added save of validation indicator  ( in pfc_save)
            //  TJB SR4461
            //  If the route has been modified, ask whether to save it
            if (StaticFunctions.IsDirty(idw_seq) || StaticFunctions.IsDirty(idw_unseq) || StaticFunctions.IsDirty(idw_addr_sequence_ind))
            {
                li_ans = MessageBox.Show("Do you want to save changes?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                //  Cancel: return to window
                if (li_ans == DialogResult.Cancel)
                {
                    return; //? return 0;
                }
            }
            //  Yes: If the address sequence has been changed
            //       save it and tell the user whether it was successful or not
            if (li_ans == DialogResult.Yes)
            {
                if (StaticFunctions.IsDirty(idw_seq) || StaticFunctions.IsDirty(idw_unseq))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.pfc_save();
                    if (true) // SUCCESS
                    {
                        MessageBox.Show("Route saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error saving route.~r" + "Route has not been saved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                //  TJB SR4691
                //  If the address sequence wasn't changed, the validation
                //  indicator will not yet have been saved.  If tis still 
                //  showing as having been modified, save it.
                if (StaticFunctions.IsDirty(idw_addr_sequence_ind))
                {
                    //!idw_addr_sequence_ind.Update();
                    idw_addr_sequence_ind.Save();
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
            int? ll_ind;
            DialogResult li_ans;
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
                li_ans = MessageBox.Show("Do you want to save the modified route", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                //  Cancel: return to window
                if (li_ans == DialogResult.Cancel)
                {
                    return; //? return 0;
                }
                //  OK: Save it and tell the user whether it was successful or not
                Cursor.Current = Cursors.WaitCursor;
                // PBY 03/09/2002 SR#4417 
                this.pfc_save();
                if (true) // SUCCESS
                {
                    //  Disable the CLoseQuery processing
                    ib_disableclosequery = true;
                    MessageBox.Show("Route saved.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lb_route_saved = true;
                }
                else
                {
                    MessageBox.Show("Error saving route.~r" + "Route has not been saved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                idw_seq.Retrieve(new object[] { il_contract_no, il_sf_key, is_delivery_days });
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
            int? ll_roadnameid;
            int? ll_sequence;
            int? ll_written;
            int? ll_errors;
            string ls_roadno;
            string ls_roadname;
            string ls_oldroadname;
            string ls_customer;
            string ls_roadalpha;
            string ls_roadnoalpha;
            string ls_contract_title = "";
            string ls_delivery_office = "";
            string ls_message;
            string ls_savedir = "";
            string ls_currentdir;
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
            int li_ok;
            int li_pos;

            DialogResult ll_dr = new DialogResult();

            // ---------------------------------------------------
            //  Check to see if there's anything to do
            // ---------------------------------------------------

            ll_rowcount = dw_seq.RowCount;
            if (ll_rowcount <= 0)
            {
                MessageBox.Show("No rows found in route??", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; //? return 0;
            }

            if (StaticFunctions.IsDirty(dw_seq) || StaticFunctions.IsDirty(dw_unseq))
            {
                MessageBox.Show("Please save route before creating the Stripmaker files.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; //? return 0;
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
                MessageBox.Show("Stripmaker ini file not found at " + is_inifile + "\r\r" + "Please locate it.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("Error selecting inifile name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Default stripmaker files directory not found in ini file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ls_savedir = StaticFunctions.GetCurrentDirectory();
            }
            else if (!(File.Exists(ls_savedir)))
            {
                MessageBox.Show("Default stripmaker files directory not found:" + ls_savedir + "\r\r" + "Please select another.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Error selecting save file name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                ll_rc = (int)MessageBox.Show("Stripmaker header file " + is_headerfile + " exists.\r" + "Do you want to replace it and its related files?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (ll_rc == (int)DialogResult.No)
                {
                    MessageBox.Show("No Stripmaker files have been generated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Header section not found in ini file: " + is_inifile + "\r\rUnable to continue." + "\r\r ( No Stripmaker files have been generated)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;//? return -(1);
            }
            //  Get contract information for header file
            /* select contract.con_title, outlet.o_name into :ls_contract_title, :ls_delivery_office
                from contract, outlet
                where contract.contract_no = :il_contract_no and contract.con_base_office = outlet.outlet_id using SQLCA; */
            RDSDataService dataService = RDSDataService.GetContractInfoByNo(il_contract_no);
            if (dataService.ContractInfoByNoList.Count > 0)
            {
                ContractInfoByNoItem item = dataService.ContractInfoByNoList[0];
                ls_contract_title = item.ConTitle;
                ls_delivery_office = item.OName;
            }
            if (dataService.SQLCode != 0)
            {
                MessageBox.Show("Contract title lookup failed~r" + dataService.SQLErrText + "\r\r ( No Stripmaker files have been generated)", "SQL error " + dataService.SQLCode, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Failed to open header file: " + ls_file + "\r\n" + "Return code = " + ex.Message + "\r\r ( No Stripmaker files have been generated)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            li_ok = 0;
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
                {
                    ll_written++;
                }
                else
                {
                    ll_errors++;
                }
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
                MessageBox.Show("Failed to open street file: '" + ls_file + "'" + "Return code = " + li_file + "\r\r ( No Stripmaker files have been generated)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lf_cleanup();
                return;//? return -(1);
            }
            //  Get street file parameters from the street section 
            //  in the ini file
            li_inirows = lf_getinikeyvalues(is_inifile, "Street", ref ls_inikeys, ref ls_inivalues);
            if (li_inirows < 1)
            {
                MessageBox.Show("Street section not found in ini file: " + is_inifile + "\r\rUsing defaults: Arial, 14, 18", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Street font details not found in ini file: " + is_inifile + "\r\r" + "Font Name = " + ls_font + '~' + "Street Name Font Size = " + ls_street_size + '~' + "Delivery Point Font Size = " + ls_delivery_size + "\r\rUsing defaults: Arial, 14, 18", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Street Colours section not found in ini file: " + is_inifile + "\r\rUsing default colours: 255, 0  ( Red/Black)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Failed to set address road name sort order." + "\r\r ( No Stripmaker files have been generated)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lf_cleanup();
                return;//? return -(1);
            }
            else if (false)
            {
                MessageBox.Show("Failed to sort addresses by road name." + "\r\r ( No Stripmaker files have been generated)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lf_cleanup();
                return;//? return -(1);
            }
            //  Step through the datawindow looking for the road name to
            //  change.  When it does, generate a street file entry and 
            //  save the sequence number as the street name ID in the 
            //  datawindow.
            li_ok = 0;
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
                    if (li_colour > li_colours)
                    {
                        li_colour = 0;
                    }
                    ls_oldroadname = ls_roadname;
                    ll_roadnameid = ll_roadnameid + 1;
                    dw_seq.GetItem<SeqAddresses>(ll_row).RoadNameId = ll_roadnameid;
                    ll_rc = 1; li_file.WriteLine(ll_roadnameid.ToString() + ',' + '\"' + ls_roadname + "\"," + ',' + ls_colourvalues[li_colour] + ',' + ls_font + ',' + ls_street_size + ',' + ls_delivery_size);
                    if (ll_rc > 0)
                    {
                        ll_written++;
                    }
                    else
                    {
                        ll_errors++;
                    }
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
                MessageBox.Show("Failed to open delivery file: '" + ls_file + "'" + "Return code = " + li_file + "\r\r ( No Stripmaker files have been generated)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lf_cleanup();
                return;//? return -(1);
            }
            dw_seq.DataObject.SortString = "seq_num A";
            dw_seq.DataObject.Sort<SeqAddresses>();
            if (false)
            {
                MessageBox.Show("Failed to set delivery sequence sort order." + "\r\r ( No Stripmaker files have been generated)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lf_cleanup();
                return;//? return -(1);
            }
            else if (false)
            {
                MessageBox.Show("Failed to sort addresses by delivery sequence." + "\r\r ( No Stripmaker files have been generated)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lf_cleanup();
                return;//? return -(1);
            }
            li_ok = 0;
            ll_written = 0;
            ll_errors = 0;
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                ls_roadno = dw_seq.GetItem<SeqAddresses>(ll_row).AdrNum;
                ls_roadalpha = dw_seq.GetItem<SeqAddresses>(ll_row).AdrAlpha;
                ls_roadnoalpha = dw_seq.GetItem<SeqAddresses>(ll_row).AdrNumAlpha;
                ls_roadname = dw_seq.GetItem<SeqAddresses>(ll_row).RoadName;
                ls_customer = dw_seq.GetItem<SeqAddresses>(ll_row).Customer;
                ll_roadnameid = dw_seq.GetItem<SeqAddresses>(ll_row).RoadNameId;
                if (ls_roadno == null)
                {
                    ls_roadno = "";
                }
                if (ls_roadalpha == null)
                {
                    ls_roadalpha = "";
                }
                if (ls_roadnoalpha == null)
                {
                    ls_roadnoalpha = "";
                }
                if (ls_roadname == null)
                {
                    ls_roadname = "";
                }
                if (ls_customer == null)
                {
                    ls_customer = "";
                }
                if (ll_roadnameid == null)
                {
                    ll_roadnameid = -(1);
                }
                //  Add quotes around the customer name
                ls_customer = '\"' + ls_customer + '\"';
                li_file.WriteLine((ll_row + 1).ToString() + ',' + ll_roadnameid + ',' + ',' + ls_customer + ',' + ",," + ls_roadno + ',' + ',' + ls_roadalpha + ',' + "2," + (ll_row + 1).ToString());
                if (ll_rc > 0)
                {
                    ll_written++;
                }
                else
                {
                    ll_errors++;
                }
            }
            li_file.Close();
            ls_message = '\r' + ll_written.ToString() + " Delivery file records written.";
            if (ll_errors > 0)
            {
                ls_message = ls_message + "\r\rErrors:  " + ll_errors.ToString();
            }
            MessageBox.Show(ls_message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int? ll_ind1;
            int? ll_ind2;
            string ls_name;
            ls_name = this.dw_addr_sequence_ind.GetColumnName();
            int row = this.dw_addr_sequence_ind.GetRow();
            if (ls_name == "rf_valid_ind")
            {
                idw_addr_sequence_ind.GetItem<AddrSequenceInd>(row).RfValidDate = System.DateTime.Today;
                idw_addr_sequence_ind.GetItem<AddrSequenceInd>(row).RfValidUser = is_userid;
            }
        }
        #endregion
    }
}
