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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.multiple_prime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adr_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.road_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sl_id = new Metex.Windows.DataGridViewEntityComboColumn();
            this.adr_rd_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tc_id = new Metex.Windows.DataGridViewEntityComboColumn();
            this.primary_contract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seq_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.grid.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 18;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.multiple_prime,
            this.adr_num,
            this.road_name,
            this.sl_id,
            this.adr_rd_no,
            this.tc_id,
            this.primary_contract,
            this.seq_num});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;
            this.grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // multiple_prime
            // 
            this.multiple_prime.DataPropertyName = "MultiplePrime";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Wingdings", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.multiple_prime.DefaultCellStyle = dataGridViewCellStyle2;
            this.multiple_prime.HeaderText = "Cus";
            this.multiple_prime.Name = "multiple_prime";
            this.multiple_prime.ReadOnly = true;
            this.multiple_prime.Width = 33;
            // 
            // adr_num
            // 
            this.adr_num.DataPropertyName = "AdrNum";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.adr_num.DefaultCellStyle = dataGridViewCellStyle3;
            this.adr_num.HeaderText = "St No";
            this.adr_num.Name = "adr_num";
            this.adr_num.ReadOnly = true;
            this.adr_num.Width = 60;
            // 
            // road_name
            // 
            this.road_name.DataPropertyName = "RoadName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.road_name.DefaultCellStyle = dataGridViewCellStyle4;
            this.road_name.HeaderText = "Street / Road";
            this.road_name.Name = "road_name";
            this.road_name.ReadOnly = true;
            this.road_name.Width = 120;
            // 
            // sl_id
            // 
            this.sl_id.DataPropertyName = "SlId";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.sl_id.DefaultCellStyle = dataGridViewCellStyle5;
            this.sl_id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.sl_id.DisplayStyleForCurrentCellOnly = true;
            this.sl_id.HeaderText = "Suburb / Locality";
            this.sl_id.Name = "sl_id";
            this.sl_id.ReadOnly = true;
            this.sl_id.Width = 95;
            // 
            // adr_rd_no
            // 
            this.adr_rd_no.DataPropertyName = "AdrRdNo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.adr_rd_no.DefaultCellStyle = dataGridViewCellStyle6;
            this.adr_rd_no.HeaderText = "RD";
            this.adr_rd_no.Name = "adr_rd_no";
            this.adr_rd_no.ReadOnly = true;
            this.adr_rd_no.Width = 30;
            // 
            // tc_id
            // 
            this.tc_id.DataPropertyName = "TcId";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.tc_id.DefaultCellStyle = dataGridViewCellStyle7;
            this.tc_id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.tc_id.DisplayStyleForCurrentCellOnly = true;
            this.tc_id.HeaderText = "Town / City";
            this.tc_id.Name = "tc_id";
            this.tc_id.ReadOnly = true;
            this.tc_id.Width = 82;
            // 
            // primary_contract
            // 
            this.primary_contract.DataPropertyName = "PrimaryContract";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.primary_contract.DefaultCellStyle = dataGridViewCellStyle8;
            this.primary_contract.HeaderText = "Primary Customer";
            this.primary_contract.Name = "primary_contract";
            this.primary_contract.ReadOnly = true;
            this.primary_contract.Width = 130;
            // 
            // seq_num
            // 
            this.seq_num.DataPropertyName = "SeqNum";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.seq_num.DefaultCellStyle = dataGridViewCellStyle9;
            this.seq_num.HeaderText = "Seq";
            this.seq_num.Name = "seq_num";
            this.seq_num.ReadOnly = true;
            this.seq_num.Width = 33;
            // 
            // DSearchAddressResultsV2b
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grid);
            this.Name = "DSearchAddressResultsV2b";
            this.Size = new System.Drawing.Size(638, 252);
            this.SizeChanged += new System.EventHandler(this.DSearchAddressResultsV2b_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

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

        private DataGridViewTextBoxColumn multiple_prime;
        private DataGridViewTextBoxColumn adr_num;
        private DataGridViewTextBoxColumn road_name;
        private Metex.Windows.DataGridViewEntityComboColumn sl_id;
        private DataGridViewTextBoxColumn adr_rd_no;
        private Metex.Windows.DataGridViewEntityComboColumn tc_id;
        private DataGridViewTextBoxColumn primary_contract;
        private DataGridViewTextBoxColumn seq_num;


    }
}
