using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
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
            this.seq_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indicator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adr_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.road_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sl_id = new Metex.Windows.DataGridViewEntityComboColumn();
            this.adr_rd_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tc_id = new Metex.Windows.DataGridViewEntityComboColumn();
            this.primary_contract = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.seq_num,
            this.indicator,
            this.adr_num,
            this.road_name,
            this.sl_id,
            this.adr_rd_no,
            this.tc_id,
            this.primary_contract});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;
            this.grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grid_CellFormatting);
            this.grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // seq_num
            // 
            this.seq_num.DataPropertyName = "SeqNum";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.seq_num.DefaultCellStyle = dataGridViewCellStyle2;
            this.seq_num.HeaderText = "Seq";
            this.seq_num.Name = "seq_num";
            this.seq_num.ReadOnly = true;
            this.seq_num.Width = 33;
            // 
            // indicator
            // 
            this.indicator.DataPropertyName = "Indicator";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Wingdings", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.indicator.DefaultCellStyle = dataGridViewCellStyle3;
            this.indicator.HeaderText = "Adr";
            this.indicator.Name = "indicator";
            this.indicator.ReadOnly = true;
            this.indicator.Width = 33;
            // 
            // adr_num
            // 
            this.adr_num.DataPropertyName = "AdrNum";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.adr_num.DefaultCellStyle = dataGridViewCellStyle4;
            this.adr_num.HeaderText = "St No";
            this.adr_num.Name = "adr_num";
            this.adr_num.ReadOnly = true;
            this.adr_num.Width = 60;
            // 
            // road_name
            // 
            this.road_name.DataPropertyName = "RoadName";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.road_name.DefaultCellStyle = dataGridViewCellStyle5;
            this.road_name.HeaderText = "Street / Road";
            this.road_name.Name = "road_name";
            this.road_name.ReadOnly = true;
            this.road_name.Width = 120;
            // 
            // sl_id
            // 
            this.sl_id.DataPropertyName = "SlId";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.sl_id.DefaultCellStyle = dataGridViewCellStyle6;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.adr_rd_no.DefaultCellStyle = dataGridViewCellStyle7;
            this.adr_rd_no.HeaderText = "RD";
            this.adr_rd_no.Name = "adr_rd_no";
            this.adr_rd_no.ReadOnly = true;
            this.adr_rd_no.Width = 30;
            // 
            // tc_id
            // 
            this.tc_id.DataPropertyName = "TcId";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.tc_id.DefaultCellStyle = dataGridViewCellStyle8;
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.primary_contract.DefaultCellStyle = dataGridViewCellStyle9;
            this.primary_contract.HeaderText = "Primary Customer";
            this.primary_contract.Name = "primary_contract";
            this.primary_contract.ReadOnly = true;
            this.primary_contract.Width = 130;
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

        //1 - ! seq_num -  IF(road_id[-1] = road_id AND len(trim(adr_num[-1])) > 0 AND len(trim(adr_num)) > 0 AND 
        //! adr_num[-1] = adr_num AND tc_id[-1] = tc_id AND adr_rd_no[-1] =  adr_rd_no AND adr_id[-1] = adr_id, "-", '') 
        //2 !- indicator -  IF(road_id[-1] = road_id AND len(trim(adr_num[-1])) > 0 AND len(trim(adr_num)) > 0 AND 
        //! adr_num[-1] = adr_num AND tc_id[-1] = tc_id AND adr_rd_no[-1] =  adr_rd_no AND adr_id[-1] <> adr_id, "?, '') 
        void grid_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {           
            string indicatorSymbol = new string (new char [] {(char)(byte)(0xFB)});
            string multiplePrimeSymbol = new string (new char [] {(char)(byte)(0x2E)});

            if (grid.RowCount == 0 && SourceList != null)
            {
                return;
            }
            if (e.ColumnIndex == 0 && e.RowIndex != 0)//! 'seq_num' column
            {
                if (
                    SourceList[e.RowIndex - 1].RoadId == SourceList[e.RowIndex].RoadId &&                    
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
            if (e.ColumnIndex == 1 && e.RowIndex != 0)//! 'indicator' column
            {
                if (
                    SourceList[e.RowIndex - 1].RoadId == SourceList[e.RowIndex].RoadId &&                    
                    !string.IsNullOrEmpty(SourceList[e.RowIndex - 1].AdrNum) && !string.IsNullOrEmpty(SourceList[e.RowIndex].AdrNum) &&                    
                    SourceList[e.RowIndex - 1].AdrNum == SourceList[e.RowIndex].AdrNum &&                                        
                    SourceList[e.RowIndex - 1].TcId == SourceList[e.RowIndex].TcId &&                                        
                    SourceList[e.RowIndex - 1].AdrRdNo == SourceList[e.RowIndex].AdrRdNo &&                                        
                    SourceList[e.RowIndex - 1].AdrId != SourceList[e.RowIndex].AdrId  
 	               )  
                {
                    SourceList[e.RowIndex].Indicator = indicatorSymbol;                    
                }
                else
                {
                    SourceList[e.RowIndex].Indicator = "";                    
                }
            }               
        }
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

        private DataGridViewTextBoxColumn seq_num;
        private DataGridViewTextBoxColumn indicator;
        private DataGridViewTextBoxColumn adr_num;
        private DataGridViewTextBoxColumn road_name;
        private Metex.Windows.DataGridViewEntityComboColumn sl_id;
        private DataGridViewTextBoxColumn adr_rd_no;
        private Metex.Windows.DataGridViewEntityComboColumn tc_id;
        private DataGridViewTextBoxColumn primary_contract;

    }
}
