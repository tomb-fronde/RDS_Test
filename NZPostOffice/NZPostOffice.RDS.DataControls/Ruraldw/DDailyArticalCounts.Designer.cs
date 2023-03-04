using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    //==============================> BEWARE!! <==================================
    // To make GUI changes, change designer code BY HAND!  Saving designer changes
    // made with the GUI rearranges code and stuffs it up!!!
    //============================================================================

    partial class DDailyArticalCounts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
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
            this.ActDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acdMonCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acdTueCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acdWedCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acdThuCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acdFriCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acdSatCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeekTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.DailyArticalCounts);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 18;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.ColumnHeadersVisible = false;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ActDescription,
            this.acdMonCountDataGridViewTextBoxColumn,
            this.acdTueCountDataGridViewTextBoxColumn,
            this.acdWedCountDataGridViewTextBoxColumn,
            this.acdThuCountDataGridViewTextBoxColumn,
            this.acdFriCountDataGridViewTextBoxColumn,
            this.acdSatCountDataGridViewTextBoxColumn,
            this.WeekTotal});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(580, 96);
            this.grid.TabIndex = 0;
            this.grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // ActDescription
            // 
            this.ActDescription.DataPropertyName = "ActDescription";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ActDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.ActDescription.HeaderText = "Week 1";
            this.ActDescription.Name = "ActDescription";
            this.ActDescription.ReadOnly = true;
            this.ActDescription.Width = 120;
            // 
            // acdMonCountDataGridViewTextBoxColumn
            // 
            this.acdMonCountDataGridViewTextBoxColumn.DataPropertyName = "AcdMonCount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.acdMonCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.acdMonCountDataGridViewTextBoxColumn.HeaderText = "Mon";
            this.acdMonCountDataGridViewTextBoxColumn.Name = "acdMonCountDataGridViewTextBoxColumn";
            this.acdMonCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.acdMonCountDataGridViewTextBoxColumn.Width = 64;
            // 
            // acdTueCountDataGridViewTextBoxColumn
            // 
            this.acdTueCountDataGridViewTextBoxColumn.DataPropertyName = "AcdTueCount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.acdTueCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.acdTueCountDataGridViewTextBoxColumn.HeaderText = "Tue";
            this.acdTueCountDataGridViewTextBoxColumn.Name = "acdTueCountDataGridViewTextBoxColumn";
            this.acdTueCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.acdTueCountDataGridViewTextBoxColumn.Width = 64;
            // 
            // acdWedCountDataGridViewTextBoxColumn
            // 
            this.acdWedCountDataGridViewTextBoxColumn.DataPropertyName = "AcdWedCount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.acdWedCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.acdWedCountDataGridViewTextBoxColumn.HeaderText = "Wed";
            this.acdWedCountDataGridViewTextBoxColumn.Name = "acdWedCountDataGridViewTextBoxColumn";
            this.acdWedCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.acdWedCountDataGridViewTextBoxColumn.Width = 64;
            // 
            // acdThuCountDataGridViewTextBoxColumn
            // 
            this.acdThuCountDataGridViewTextBoxColumn.DataPropertyName = "AcdThuCount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.acdThuCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.acdThuCountDataGridViewTextBoxColumn.HeaderText = "Thu";
            this.acdThuCountDataGridViewTextBoxColumn.Name = "acdThuCountDataGridViewTextBoxColumn";
            this.acdThuCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.acdThuCountDataGridViewTextBoxColumn.Width = 64;
            // 
            // acdFriCountDataGridViewTextBoxColumn
            // 
            this.acdFriCountDataGridViewTextBoxColumn.DataPropertyName = "AcdFriCount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.acdFriCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.acdFriCountDataGridViewTextBoxColumn.HeaderText = "Fri";
            this.acdFriCountDataGridViewTextBoxColumn.Name = "acdFriCountDataGridViewTextBoxColumn";
            this.acdFriCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.acdFriCountDataGridViewTextBoxColumn.Width = 64;
            // 
            // acdSatCountDataGridViewTextBoxColumn
            // 
            this.acdSatCountDataGridViewTextBoxColumn.DataPropertyName = "AcdSatCount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.acdSatCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.acdSatCountDataGridViewTextBoxColumn.HeaderText = "Sat";
            this.acdSatCountDataGridViewTextBoxColumn.Name = "acdSatCountDataGridViewTextBoxColumn";
            this.acdSatCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.acdSatCountDataGridViewTextBoxColumn.Width = 64;
            // 
            // WeekTotal
            // 
            this.WeekTotal.DataPropertyName = "WeekTotal";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeekTotal.DefaultCellStyle = dataGridViewCellStyle9;
            this.WeekTotal.HeaderText = "Total";
            this.WeekTotal.Name = "WeekTotal";
            this.WeekTotal.ReadOnly = true;
            this.WeekTotal.Width = 64;
            // 
            // DDailyArticalCounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.grid);
            this.Name = "DDailyArticalCounts";
            this.Size = new System.Drawing.Size(580, 96);
            this.SizeChanged += new System.EventHandler(this.DDailyArticalCounts_SizeChanged);
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
        void DDailyArticalCounts_SizeChanged(object sender, System.EventArgs e)
        {
            this.grid.Width = this.Width - this.grid.Left;
            this.grid.Height = this.Height - this.grid.Top;
        }

        void grid_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            //return;
        }

        #endregion

        private DataGridViewTextBoxColumn ActDescription;
        private DataGridViewTextBoxColumn acdMonCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn acdTueCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn acdWedCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn acdThuCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn acdFriCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn acdSatCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn WeekTotal;












    }
}
