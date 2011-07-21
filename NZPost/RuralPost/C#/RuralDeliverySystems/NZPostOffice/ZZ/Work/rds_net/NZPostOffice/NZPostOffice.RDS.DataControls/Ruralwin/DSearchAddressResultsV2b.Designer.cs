using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB  RPCR_026  July-2011
    // Changed Primary indicator column to display Address sequence number (seq_num)

	partial class DSearchAddressResultsV2b
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  primary_contract;
		private System.Windows.Forms.DataGridViewTextBoxColumn  adr_num;
        private Metex.Windows.DataGridViewEntityComboColumn tc_id;
        private Metex.Windows.DataGridViewEntityComboColumn sl_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  road_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  adr_rd_no;
		private System.Windows.Forms.DataGridViewTextBoxColumn  seq_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn multiple_prime;

	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private Metex.Windows.DataEntityGrid grid;
		#region Component Designer generated code
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			grid = new Metex.Windows.DataEntityGrid();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.SuspendLayout();

			// 
			// bindingSource
			//
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.SearchAddressResultsV2b);

			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
			this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;            
			this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
			this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;            
			this.grid.ColumnHeadersHeight = 18;
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.grid.DataSource = this.bindingSource;
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.MultiSelect = true;
			this.grid.Name = "grid";
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(grid_DataError);
			this.grid.TabIndex = 0;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Window;

            System.Windows.Forms.Padding paddIt = new System.Windows.Forms.Padding();
            paddIt.Left = 5;

            //
            // multiple_prime
            //
            multiple_prime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.multiple_prime.DataPropertyName = "MultiplePrime";
            this.multiple_prime.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.multiple_prime.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.ColorTranslator.FromWin32(553648127);
            this.multiple_prime.DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
            this.multiple_prime.DefaultCellStyle.Font = new System.Drawing.Font("Wingdings", 12F);
            this.multiple_prime.DefaultCellStyle.Padding = paddIt;
            this.multiple_prime.HeaderText = "Cus";
            this.multiple_prime.Name = "multiple_prime";
            this.multiple_prime.Width = 33;
            this.multiple_prime.ReadOnly = true;
            this.grid.Columns.Add(multiple_prime);
            //
			// seq_num
			//
			seq_num= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.seq_num.DataPropertyName = "SeqNum";
            this.seq_num.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.seq_num.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.ColorTranslator.FromWin32(553648127);
            this.seq_num.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.seq_num.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.seq_num.DefaultCellStyle.Padding = paddIt;
			this.seq_num.HeaderText = "Seq";
			this.seq_num.Name = "seq_num";            
			this.seq_num.Width = 33;
            this.seq_num.ReadOnly = true;         
			this.grid.Columns.Add(seq_num);
            //
			// adr_num
			//
			adr_num= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.adr_num.DataPropertyName = "AdrNum";
			this.adr_num.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.adr_num.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.adr_num.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.adr_num.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);                       
            this.adr_num.DefaultCellStyle.Padding = paddIt;            
			this.adr_num.HeaderText = "St No";
			this.adr_num.Name = "adr_num";
			this.adr_num.ReadOnly = true;
			this.adr_num.Width = 60;
            this.adr_num.ReadOnly = true;
            this.grid.Columns.Add(adr_num);
			//
			// road_name
			//
			road_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.road_name.DataPropertyName = "RoadName";
			this.road_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.road_name.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.road_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.road_name.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.road_name.HeaderText = "Street / Road";
			this.road_name.Name = "road_name";
			this.road_name.ReadOnly = true;
			this.road_name.Width = 120;
            this.road_name.ReadOnly = true;
            this.grid.Columns.Add(road_name);
			//
			// sl_id
			//
			sl_id = new Metex.Windows.DataGridViewEntityComboColumn();
			this.sl_id.DataPropertyName = "SlId";
			this.sl_id.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.sl_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.sl_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.sl_id.HeaderText = "Suburb / Locality";
            this.sl_id.Name = "sl_id";
			this.sl_id.Width = 95;
            this.sl_id.DisplayMember = "SlName";
            this.sl_id.ValueMember = "SlId";
            this.sl_id.ReadOnly = true;
            //! do not display dropdown button if not in edit mode
            //!this.sl_id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.sl_id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.sl_id.DisplayStyleForCurrentCellOnly = true;
            this.grid.Columns.Add(sl_id);
			//
			// adr_rd_no
			//
			adr_rd_no= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.adr_rd_no.DataPropertyName = "AdrRdNo";
			this.adr_rd_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.adr_rd_no.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.adr_rd_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.adr_rd_no.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.adr_rd_no.HeaderText = "RD";
			this.adr_rd_no.Name = "adr_rd_no";
			this.adr_rd_no.ReadOnly = true;
			this.adr_rd_no.Width = 30;
            this.adr_rd_no.ReadOnly = true;
            this.grid.Columns.Add(adr_rd_no);
			//
			// tc_id
			//
            tc_id = new Metex.Windows.DataGridViewEntityComboColumn();
			this.tc_id.DataPropertyName = "TcId";
			this.tc_id.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.tc_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.tc_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.tc_id.HeaderText = "Town / City";
            this.tc_id.Name = "tc_id";
			this.tc_id.Width = 82;
            this.tc_id.DisplayMember = "TcName";
            this.tc_id.ValueMember = "TcId";
            this.tc_id.ReadOnly = true;
            //! do not display dropdown button if not in edit mode
            //!this.tc_id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.tc_id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.tc_id.DisplayStyleForCurrentCellOnly = true;
            this.grid.Columns.Add(tc_id);
			//
			// primary_contract
			//
			primary_contract= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.primary_contract.DataPropertyName = "PrimaryContract";
			this.primary_contract.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.primary_contract.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.primary_contract.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.primary_contract.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.primary_contract.HeaderText = "Primary Customer";
			this.primary_contract.Name = "primary_contract";
			this.primary_contract.Width = 130;
            this.primary_contract.ReadOnly = true;
            this.grid.Columns.Add(primary_contract);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.Color.White;//.ColorTranslator.FromWin32(1086902488);
            //this.AutoScroll = true;
			this.Controls.Add(grid);
            this.SizeChanged += new System.EventHandler(DSearchAddressResultsV2b_SizeChanged);
        }
/*  TJB  RPCR_026 July-2011: Fixup
 *  Functionality moved to cb_search_clicked in WAddressSearch because the this
 *  didn't catch all the rows that should have been marked (not called for some??).

        void grid_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {           
            string indicatorSymbol = new string (new char [] {(char)(byte)(0xFB)});
            string multiplePrimeSymbol = new string (new char [] {(char)(byte)(0x2E)});

            if (grid.RowCount == 0 && SourceList != null)
            {
                return;
            }
            if (e.ColumnIndex == 0 && e.RowIndex != 0)   //! 'multiple_prime' column
            {
                if (SourceList[e.RowIndex - 1].RoadId == SourceList[e.RowIndex].RoadId &&                    
                    !string.IsNullOrEmpty(SourceList[e.RowIndex - 1].AdrNum) && !string.IsNullOrEmpty(SourceList[e.RowIndex].AdrNum) &&                    
                    SourceList[e.RowIndex - 1].AdrNum == SourceList[e.RowIndex].AdrNum &&                                        
                    SourceList[e.RowIndex - 1].TcId == SourceList[e.RowIndex].TcId &&                                        
                    SourceList[e.RowIndex - 1].AdrRdNo == SourceList[e.RowIndex].AdrRdNo &&                                        
                    SourceList[e.RowIndex - 1].AdrId == SourceList[e.RowIndex].AdrId                    
                    )
                {
                    SourceList[e.RowIndex].MultiplePrime = multiplePrimeSymbol;                    
                }
                else {
                    SourceList[e.RowIndex].MultiplePrime = "";                    
                }                
            }            
            //if (e.ColumnIndex == 1 && e.RowIndex != 0)//! 'indicator' column
            //{
            //    if (
            //        SourceList[e.RowIndex - 1].RoadId == SourceList[e.RowIndex].RoadId &&                    
            //        !string.IsNullOrEmpty(SourceList[e.RowIndex - 1].AdrNum) && !string.IsNullOrEmpty(SourceList[e.RowIndex].AdrNum) &&                    
            //        SourceList[e.RowIndex - 1].AdrNum == SourceList[e.RowIndex].AdrNum &&                                        
            //        SourceList[e.RowIndex - 1].TcId == SourceList[e.RowIndex].TcId &&                                        
            //        SourceList[e.RowIndex - 1].AdrRdNo == SourceList[e.RowIndex].AdrRdNo &&                                        
            //        SourceList[e.RowIndex - 1].AdrId != SourceList[e.RowIndex].AdrId  
 	        //       )  
            //    {
            //        SourceList[e.RowIndex].Indicator = indicatorSymbol;                    
            //    }
            //    else
            //    {
            //        SourceList[e.RowIndex].Indicator = "";                    
            //    }
            //}               
        }
*/
        void DSearchAddressResultsV2b_SizeChanged(object sender, System.EventArgs e)
        {
            this.grid.Width = this.Width - this.grid.Left;
            this.grid.Height = this.Height - this.grid.Top;
        }

        void grid_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            //return;
        }

		#endregion

	}
}
