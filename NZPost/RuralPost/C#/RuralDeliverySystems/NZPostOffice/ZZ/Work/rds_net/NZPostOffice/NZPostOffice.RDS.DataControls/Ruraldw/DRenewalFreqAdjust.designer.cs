using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;
using System.ComponentModel;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DRenewalFreqAdjust
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  compute_1;
		private System.Windows.Forms.TextBox  compute_2;
		private System.Windows.Forms.TextBox  compute_3;
		private System.Windows.Forms.TextBox  compute_4;
		private System.Windows.Forms.DataGridViewTextBoxColumn  fd_effective_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  fd_adjustment_amount;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  fd_confirmed;
		private System.Windows.Forms.DataGridViewTextBoxColumn  fd_amount_to_pay_display_only;
		private Metex.Windows.DataGridViewEntityComboColumn  pct_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  fd_paid_to_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  fd_amount_to_pay;
		private System.Windows.Forms.DataGridViewTextBoxColumn  fd_bm_after_extn;
        private System.Windows.Forms.Label st_title;
        private System.Windows.Forms.Label line1;
        private System.Windows.Forms.Label line2;
        private System.Windows.Forms.Label line3;
        private System.Windows.Forms.TextBox st_confirm_access;

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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RenewalFreqAdjust);


			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
			this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grid.Anchor= ((System.Windows.Forms.AnchorStyles)(((( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                 | System.Windows.Forms.AnchorStyles.Left)
                 | System.Windows.Forms.AnchorStyles.Right)));

			this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
			this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			this.grid.ColumnHeadersHeight = 35;
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.grid.DataSource = this.bindingSource;
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.grid.Location = new System.Drawing.Point(0, 15);
			this.grid.MultiSelect = true;
			this.grid.Name = "grid";
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(570, 210);
			this.grid.TabIndex = 0;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            //this.grid.BorderStyle = BorderStyle.None;
            this.grid.CellBorderStyle = DataGridViewCellBorderStyle.None;
//            this.grid.BorderStyle = BorderStyle.None;
            this.Controls.Add(grid);
			//
			// fd_effective_date
			//
			fd_effective_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fd_effective_date.DataPropertyName = "FdEffectiveDate";
			this.fd_effective_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.fd_effective_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.fd_effective_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.fd_effective_date.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.fd_effective_date.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.fd_effective_date.HeaderText = "Effective Date";
			this.fd_effective_date.Name = "fd_effective_date";
			this.fd_effective_date.ReadOnly = true;
			this.fd_effective_date.Width = 67;
			this.grid.Columns.Add(fd_effective_date);


			//
			// compute_1
			//
			compute_1= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.compute_1.DataPropertyName = "Compute1";
			this.compute_1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.compute_1.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            this.compute_1.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.compute_1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.compute_1.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.compute_1.HeaderText = "Renewal";
			this.compute_1.Name = "compute_1";
			this.compute_1.Width = 52;
			this.grid.Columns.Add(compute_1);


			//
			// fd_adjustment_amount
			//
			fd_adjustment_amount= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fd_adjustment_amount.DataPropertyName = "FdAdjustmentAmount";
			this.fd_adjustment_amount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.fd_adjustment_amount.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.fd_adjustment_amount.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.fd_adjustment_amount.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.fd_adjustment_amount.DefaultCellStyle.Format = "#,##0.00;(#,##0.00)";
			this.fd_adjustment_amount.HeaderText = "Benchmark Adjustment";
			this.fd_adjustment_amount.Name = "fd_adjustment_amount";
			this.fd_adjustment_amount.ReadOnly = true;
			this.fd_adjustment_amount.Width = 68;
			this.grid.Columns.Add(fd_adjustment_amount);


			//
			// fd_amount_to_pay_display_only
			//
			fd_amount_to_pay_display_only= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fd_amount_to_pay_display_only.DataPropertyName = "FdAmountToPayDisplayOnly";
			this.fd_amount_to_pay_display_only.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			//this.fd_amount_to_pay_display_only.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
            this.fd_amount_to_pay_display_only.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.fd_amount_to_pay_display_only.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.fd_amount_to_pay_display_only.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.fd_amount_to_pay_display_only.DefaultCellStyle.Format = "#,##0.00;(#,##0.00)";
			this.fd_amount_to_pay_display_only.HeaderText = "Amount Payable";
			this.fd_amount_to_pay_display_only.Name = "fd_amount_to_pay_display_only";
			this.fd_amount_to_pay_display_only.ReadOnly = true;
            this.fd_amount_to_pay_display_only.Visible = false;
			this.fd_amount_to_pay_display_only.Width = 72;
			this.grid.Columns.Add(fd_amount_to_pay_display_only);

            //
            // fd_amount_to_pay
            //
            fd_amount_to_pay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fd_amount_to_pay.DataPropertyName = "FdAmountToPayDisplayOnly";
            this.fd_amount_to_pay.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            //this.fd_amount_to_pay.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.fd_amount_to_pay.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.fd_amount_to_pay.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.fd_amount_to_pay.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.fd_amount_to_pay.DefaultCellStyle.Format = "#,###.00;(#,###.00)";
            this.fd_amount_to_pay.HeaderText = "Amount Payable";
            this.fd_amount_to_pay.Name = "fd_amount_to_pay";
            this.fd_amount_to_pay.Width = 72;
            //this.fd_amount_to_pay.Visible = false;
            this.grid.Columns.Add(fd_amount_to_pay);


			//
			// fd_paid_to_date
			//
			fd_paid_to_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fd_paid_to_date.DataPropertyName = "FdPaidToDate";
			this.fd_paid_to_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.fd_paid_to_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.fd_paid_to_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.fd_paid_to_date.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.fd_paid_to_date.DefaultCellStyle.Format = "dd/MM/yyyy";
			this.fd_paid_to_date.HeaderText = "First Paid Date";
			this.fd_paid_to_date.Name = "fd_paid_to_date";
			this.fd_paid_to_date.ReadOnly = true;
			this.fd_paid_to_date.Width = 70;
			this.grid.Columns.Add(fd_paid_to_date);


			//
			// fd_bm_after_extn
			//
			fd_bm_after_extn= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fd_bm_after_extn.DataPropertyName = "FdBmAfterExtn";
			this.fd_bm_after_extn.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.fd_bm_after_extn.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.fd_bm_after_extn.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.fd_bm_after_extn.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.fd_bm_after_extn.DefaultCellStyle.Format = "#,##0.00;(#,##0.00)";
			this.fd_bm_after_extn.HeaderText = "BM After Extn";
			this.fd_bm_after_extn.Name = "fd_bm_after_extn";
			this.fd_bm_after_extn.ReadOnly = true;
			this.fd_bm_after_extn.Width = 65;
			this.grid.Columns.Add(fd_bm_after_extn);


			//
			// fd_confirmed
			//
			fd_confirmed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.fd_confirmed.DataPropertyName = "FdConfirmed";
			this.fd_confirmed.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			//this.fd_confirmed.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;;
			this.fd_confirmed.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.fd_confirmed.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.fd_confirmed.DefaultCellStyle.NullValue = false;
            this.fd_confirmed.HeaderText = "Confirmed";
			this.fd_confirmed.Name = "fd_confirmed";
			this.fd_confirmed.TrueValue = "Y";
			this.fd_confirmed.FalseValue = "N";
			this.fd_confirmed.Width = 58;
            //this.fd_confirmed.ReadOnly = true;
			this.grid.Columns.Add(fd_confirmed);


			//
			// pct_id
			//
			pct_id = new Metex.Windows.DataGridViewEntityComboColumn();
			this.pct_id.DataPropertyName = "PctId";
			//this.pct_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.pct_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.pct_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.pct_id.HeaderText = "Pay Component Type";
            this.pct_id.Name = "pct_id";
			this.pct_id.Width = 95;
			this.pct_id.DropDownWidth = 190;
			this.grid.Columns.Add(pct_id);


            st_title = new System.Windows.Forms.Label();
            st_title.Height = 14;
            st_title.Width = 600;
            st_title.Font = new System.Drawing.Font("MS Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
            st_title.Name = "st_title";
            st_title.Text = "text";
            this.Controls.Add(st_title);


			//
			// compute_2
			//
			compute_2= new System.Windows.Forms.TextBox();
            this.compute_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.compute_2.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_2.ForeColor = System.Drawing.Color.Black;
            this.compute_2.Location = new System.Drawing.Point(86, 230);
            this.compute_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_2.Name = "compute_2";
            this.compute_2.Size = new System.Drawing.Size(100, 20);
            //this.compute_2.TabIndex = 1;
            this.compute_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_2.BackColor = System.Drawing.SystemColors.ButtonFace;
         


			//
			// compute_3
			//
			compute_3= new System.Windows.Forms.TextBox();
			
            this.compute_3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.compute_3.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_3.ForeColor = System.Drawing.Color.Black;
            this.compute_3.Location = new System.Drawing.Point(160, 230);
            this.compute_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_3.Size = new System.Drawing.Size(100, 20);
            //this.compute_3.TabIndex = 1;
            this.compute_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.compute_3.Name = "compute_3";
            this.compute_3.BackColor = System.Drawing.SystemColors.ButtonFace;


			//
			// compute_4
			//
			compute_4= new System.Windows.Forms.TextBox();

            this.compute_4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.compute_4.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_4.ForeColor = System.Drawing.Color.Black;
            this.compute_4.Location = new System.Drawing.Point(255, 230);
            this.compute_4.Size = new System.Drawing.Size(100, 20);
            this.compute_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.compute_4.Name = "compute_4";
			this.compute_4.Width = 143;
            this.compute_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compute_4.BackColor = System.Drawing.SystemColors.ButtonFace;

            line1 = new System.Windows.Forms.Label();
            line1.Height = 1;
            line1.Width = 140;
            line1.Left = 120;
            line1.BackColor = System.Drawing.Color.Black;

            line2 = new System.Windows.Forms.Label();
            line2.Height = 1;
            line2.Width = 140;
            line2.Left = 120;
            line2.BackColor = System.Drawing.Color.Black;

            line3 = new System.Windows.Forms.Label();
            line3.Height = 1;
            line3.Width = 140;
            line3.Left = 120;
            line3.Text = "N";
            line3.BackColor = System.Drawing.Color.Black;

            st_confirm_access = new TextBox();
            st_confirm_access.Height = 1;
            st_confirm_access.Width = 140;
            st_confirm_access.Left = 120;
            st_confirm_access.BackColor = System.Drawing.Color.Black;
            st_confirm_access.Visible = false;

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(570, 352);
			this.BackColor = System.Drawing.SystemColors.Control;

            this.Controls.Add(line1);
            this.Controls.Add(line2);
            this.Controls.Add(line3);
            this.Controls.Add(st_confirm_access);
            this.Controls.Add(st_confirm_access);
            this.Controls.Add(compute_2);
            this.Controls.Add(compute_3);
            this.Controls.Add(compute_4);
            this.grid.CurrentCellDirtyStateChanged += new System.EventHandler(grid_CurrentCellDirtyStateChanged);//add by ybfan
            this.bindingSource.ListChanged += new ListChangedEventHandler(bindingSource_ListChanged);
		}

        //add by ybfan
        void grid_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            if (this.grid.CurrentColumnName == "pct_id")
            {
                this.grid.EndEdit();
            }
        }

        void bindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            //this.grid.Height = this.RowCount * 20 + 28;
            this.grid.Height = this.RowCount * this.grid.RowTemplate.Height + this.grid.ColumnHeadersHeight + 5;
            this.line1.Top = this.grid.Top + grid.Height + 3;
            this.compute_2.Top = this.grid.Top + grid.Height + 4;
            this.compute_3.Top = this.grid.Top + grid.Height + 4;
            this.compute_4.Top = this.grid.Top + grid.Height + 4;
            this.line2.Top = this.grid.Top + grid.Height + 25;
            this.line3.Top = this.grid.Top + grid.Height + 27;

            decimal? total1 = 0;
            decimal? total2 = 0;
            decimal? total3 = 0;

            if (grid.RowCount <= 0)
                return;

            for (int i = 0; i < this.RowCount; i++)
            {
                if (this.GetItem<RenewalFreqAdjust>(i).FdAdjustmentAmount != null)
                {
                    total1 += this.GetItem<RenewalFreqAdjust>(i).FdAdjustmentAmount;
                }
                if (this.GetItem<RenewalFreqAdjust>(i).FdAmountToPayDisplayOnly != null)
                {
                    total2 += this.GetItem<RenewalFreqAdjust>(i).FdAmountToPayDisplayOnly;
                }
                if (this.GetItem<RenewalFreqAdjust>(i).FdConfirmed == "Y")
                {
                    total3 += this.GetItem<RenewalFreqAdjust>(i).FdAmountToPayDisplayOnly;
                }

                //p! added code for HQ, Payroll, System Administrators
                if (st_confirm_access.Text == "N")
                {
                    grid.Rows[i].Cells["fd_confirmed"].ReadOnly = false;                    
                }
                else
                {
                    grid.Rows[i].Cells["fd_confirmed"].ReadOnly = true;
                    continue;//! if no access do not check anymore
                }//EO aded code


                //if(fd_confirmed='Y' or describe('datawindow.readonly')='yes',1,0)
                if (this.GetItem<RenewalFreqAdjust>(i).FdConfirmed == "Y" || (!this.Enabled))
                {
                    grid.Rows[i].Cells["fd_amount_to_pay"].ReadOnly = true;
                    grid.Rows[i].Cells["fd_amount_to_pay"].Style.BackColor = System.Drawing.SystemColors.Control;
                }
                else
                {
                    grid.Rows[i].Cells["fd_amount_to_pay"].ReadOnly = false;
                    grid.Rows[i].Cells["fd_amount_to_pay"].Style.BackColor = System.Drawing.Color.White;
                }
                //if( isnull( fd_paid_to_date ), 0, 1)
                  if (this.GetItem<RenewalFreqAdjust>(i).FdPaidToDate == null)
                {
                    grid.Rows[i].Cells["fd_confirmed"].ReadOnly = false;
                }
                else
                {
                    grid.Rows[i].Cells["fd_confirmed"].ReadOnly = true;
                }                
            }
            compute_2.Text = string.Format("{0:#,##0.00;(#,##0.00)}", total1);
            compute_3.Text = string.Format("{0:#,##0.00;(#,##0.00)}", total2);
            compute_4.Text = "(Confirmed:" + string.Format("{0:#,##0.00;(#,##0.00)}", total3) + ")";

        }
		#endregion

	}
}
