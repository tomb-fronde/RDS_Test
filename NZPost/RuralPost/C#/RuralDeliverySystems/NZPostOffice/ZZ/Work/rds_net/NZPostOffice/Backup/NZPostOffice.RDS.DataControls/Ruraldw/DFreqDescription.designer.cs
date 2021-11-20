using System.Windows.Forms;
using System.Drawing;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DFreqDescription
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  compute_1;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rf_running_total;
		private System.Windows.Forms.DataGridViewTextBoxColumn  contract_no;
		private System.Windows.Forms.DataGridViewTextBoxColumn  show_question;
		private System.Windows.Forms.DataGridViewTextBoxColumn  point_type;
		private System.Windows.Forms.DataGridViewTextBoxColumn  test;
		private Metex.Windows.DataGridViewEntityComboColumn  rfpt_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_id;
		private Metex.Windows.DataGridViewEntityComboColumn  rfv_id_2;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rd_description_of_point;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rf_delivery_days;
		private System.Windows.Forms.DataGridViewTextBoxColumn  sf_key;
		private System.Windows.Forms.DataGridViewTextBoxColumn  question_down;
		private Metex.Windows.DataGridViewEntityComboColumn  rfv_id;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn rd_time_at_point;
        private NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn rf_distance_of_leg;// System.Windows.Forms.DataGridViewTextBoxColumn rf_distance_of_leg;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rd_sequence;
        private System.Windows.Forms.DataGridViewButtonColumn dos_button2;
       //? private System.Windows.Forms.DataGridViewImageColumn dos_button;
        private DGVCustomButtonColumn dos_button;
	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.FreqDescription);
			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
			this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
			this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid.ColumnHeadersHeight = 32;
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
			this.grid.TabIndex = 0;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.grid.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            this.grid.CellPainting += new DataGridViewCellPaintingEventHandler(grid_CellPainting);
            this.grid.CurrentCellDirtyStateChanged += new System.EventHandler(grid_CurrentCellDirtyStateChanged);
            this.grid.DataError += new DataGridViewDataErrorEventHandler(grid_DataError);
            this.grid.CellLeave += new DataGridViewCellEventHandler(grid_CellLeave);
			//
			// compute_1
			//
			compute_1= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.compute_1.DataPropertyName = "Compute1";
			this.compute_1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.compute_1.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;//.ColorTranslator.FromWin32(553648127);
			this.compute_1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.compute_1.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.compute_1.HeaderText = "";
			this.compute_1.Name = "compute_1";
			this.compute_1.Width = 20;
            this.compute_1.ReadOnly = true;
            this.compute_1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
			this.grid.Columns.Add(compute_1);
            //
            // rd_time_at_point
            //
            rd_time_at_point = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
            this.rd_time_at_point.DataPropertyName = "RdTimeAtPoint";
            this.rd_time_at_point.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //this.rd_time_at_point.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.rd_time_at_point.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rd_time_at_point.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rd_time_at_point.DefaultCellStyle.Format = "HH:mm";
            this.rd_time_at_point.DefaultCellStyle.NullValue = "00:00";
            this.rd_time_at_point.Mask = "00:00";
            this.rd_time_at_point.PromptChar = ' ';
            this.rd_time_at_point.HeaderText = "Time";
            this.rd_time_at_point.Name = "rd_time_at_point";
            this.rd_time_at_point.Width = 35;
            this.rd_time_at_point.DefaultCellStyle.WrapMode = DataGridViewTriState.True; 
            this.rd_time_at_point.Mask = "00:00";
            this.rd_time_at_point.PromptChar = '0';
            this.rd_time_at_point.ValueType = typeof(System.DateTime);
            this.grid.Columns.Add(rd_time_at_point);
           
            //
            // rd_description_of_point
            //
            rd_description_of_point = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rd_description_of_point.DataPropertyName = "RdDescriptionOfPoint";
            this.rd_description_of_point.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           //this.rd_description_of_point.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.rd_description_of_point.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rd_description_of_point.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rd_description_of_point.HeaderText = "Description of Stage";
            this.rd_description_of_point.Name = "rd_description_of_point";
            this.rd_description_of_point.Width = 132;
            this.grid.Columns.Add(rd_description_of_point);
            //
            // dos_button
            //
            dos_button = new DGVCustomButtonColumn();// System.Windows.Forms.DataGridViewImageColumn();                        
            this.dos_button.Width = 18;
            dos_button.Name = "dos_button";
            dos_button.HeaderText = "";
            dos_button.Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTDN;
            dos_button.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.grid.Columns.Add(dos_button);
            //
            // rf_distance_of_leg
            //
            rf_distance_of_leg = new NZPostOffice.Shared.VisualComponents.NumericalMaskedTextBoxColumn();// System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rf_distance_of_leg.DataPropertyName = "RfDistanceOfLeg";
            this.rf_distance_of_leg.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            //this.rf_distance_of_leg.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.rf_distance_of_leg.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rf_distance_of_leg.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rf_distance_of_leg.HeaderText = "Distance";
            this.rf_distance_of_leg.Name = "rf_distance_of_leg";
            this.rf_distance_of_leg.Width = 49;
            this.rf_distance_of_leg.DefaultCellStyle.Format = "###.##";
            this.rf_distance_of_leg.Mask = "###.##";
            this.grid.Columns.Add(rf_distance_of_leg);
            //
            // rfv_id
            //
            rfv_id = new Metex.Windows.DataGridViewEntityComboColumn();
            this.rfv_id.DataPropertyName = "RfvId";
            //this.rfv_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.rfv_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rfv_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rfv_id.HeaderText = "Verb One";
            this.rfv_id.Name = "d_dddw_verbs";
            this.rfv_id.Width = 85;
            this.rfv_id.DropDownWidth = 103;
            this.rfv_id.ValueMember = "RfvId";
            this.rfv_id.DisplayMember = "RfvDescription";
            this.rfv_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            
            this.grid.Columns.Add(rfv_id);
            //
            // rfv_id_2
            //
            rfv_id_2 = new Metex.Windows.DataGridViewEntityComboColumn();
            this.rfv_id_2.DataPropertyName = "RfvId2";
            //this.rfv_id_2.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.rfv_id_2.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rfv_id_2.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.rfv_id_2.HeaderText = "Verb Two";
            this.rfv_id_2.Name = "d_dddw_verbs";
            this.rfv_id_2.Width = 85;
            this.rfv_id_2.DropDownWidth = 103;
            this.rfv_id_2.ValueMember = "RfvId";
            this.rfv_id_2.DisplayMember = "RfvDescription";
            this.grid.Columns.Add(rfv_id_2);
            //
            // rfpt_id
            //
            rfpt_id = new Metex.Windows.DataGridViewEntityComboColumn();
            //p! moved Test property here - see source code for the data window - Test property refers to 'rfpd_id'
            //! column which is 'rfpt_id' column binding property
            this.rfpt_id.DataPropertyName = "Test";
            //this.rfpt_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.rfpt_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rfpt_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rfpt_id.HeaderText = "Reference Point";
            //!this.rfpt_id.Name = "d_dddw_point_types";
            this.rfpt_id.Name = "rfpt_id";
            this.rfpt_id.Width = 80;
            this.rfpt_id.ValueMember = "RfptId";
            this.rfpt_id.DisplayMember = "RfptDescription";
            this.rfpt_id.DropDownWidth = 120;
            this.grid.Columns.Add(rfpt_id);
            //
            // rf_running_total
            //
            rf_running_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rf_running_total.DataPropertyName = "RfRunningTotal";
            this.rf_running_total.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.rf_running_total.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;//.ColorTranslator.FromWin32(553648127);
            this.rf_running_total.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rf_running_total.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rf_running_total.DefaultCellStyle.Format = "#,##0.00";
            this.rf_running_total.HeaderText = "Running Total";
            this.rf_running_total.Name = "rf_running_total";
            this.rf_running_total.ReadOnly = true;
            this.rf_running_total.Width = 50;
            this.grid.Columns.Add(rf_running_total);
			//
			// test
			//
			test= new System.Windows.Forms.DataGridViewTextBoxColumn();
            //p! removed binding for this column - see source code for the data window - Test property refers to 'rfpd_id'
            //! column which is 'rfpt_id' column binding property
//!			this.test.DataPropertyName = "Test";
			this.test.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.test.DefaultCellStyle.BackColor = System.Drawing.Color.White;
			this.test.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.test.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.test.HeaderText = "Time";
			this.test.Name = "test";
			this.test.ReadOnly = true;
			this.test.Width = 39;
            this.test.Visible = false;
			this.grid.Columns.Add(test);
			//
			// point_type
			//
			point_type= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.point_type.DataPropertyName = "PointType";
			this.point_type.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.point_type.DefaultCellStyle.BackColor = System.Drawing.Color.White;
			this.point_type.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.point_type.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.point_type.HeaderText = "Time";
			this.point_type.Name = "point_type";
			this.point_type.ReadOnly = true;
			this.point_type.Width = 201;
            this.point_type.Visible = false;
			this.grid.Columns.Add(point_type);
			//
			// question_down
			//
			question_down= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.question_down.DataPropertyName = "QuestionDown";
			this.question_down.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.question_down.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
			this.question_down.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.question_down.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.question_down.HeaderText = "Time";
			this.question_down.Name = "question_down";
			this.question_down.ReadOnly = true;
			this.question_down.Width = 39;
            this.question_down.Visible = false;
			this.grid.Columns.Add(question_down);
			//
			// cust_id
			//
			cust_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cust_id.DataPropertyName = "CustId";
			this.cust_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cust_id.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
			this.cust_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cust_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.cust_id.HeaderText = "Time";
			this.cust_id.Name = "cust_id";
			this.cust_id.ReadOnly = true;
			this.cust_id.Width = 39;
            this.cust_id.Visible = false;
			this.grid.Columns.Add(cust_id);
			//
			// show_question
			//
			show_question= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.show_question.DataPropertyName = "ShowQuestion";
			this.show_question.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.show_question.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
			this.show_question.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.show_question.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.show_question.HeaderText = "Time";
			this.show_question.Name = "show_question";
			this.show_question.ReadOnly = true;
			this.show_question.Width = 39;
            this.show_question.Visible = false;
			this.grid.Columns.Add(show_question);
			//
			// sf_key
			//
			sf_key= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sf_key.DataPropertyName = "SfKey";
			this.sf_key.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.sf_key.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
			this.sf_key.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.sf_key.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.sf_key.HeaderText = "Time";
			this.sf_key.Name = "sf_key";
			this.sf_key.ReadOnly = true;
			this.sf_key.Width = 108;
            this.sf_key.Visible = false;
			this.grid.Columns.Add(sf_key);
			//
			// contract_no
			//
			contract_no= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contract_no.DataPropertyName = "ContractNo";
			this.contract_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.contract_no.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
			this.contract_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.contract_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.contract_no.HeaderText = "Distance";
			this.contract_no.Name = "contract_no";
			this.contract_no.ReadOnly = true;
			this.contract_no.Width = 108;
            this.contract_no.Visible = false;
			this.grid.Columns.Add(contract_no);
			//
			// rf_delivery_days
			//
			rf_delivery_days= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rf_delivery_days.DataPropertyName = "RfDeliveryDays";
			this.rf_delivery_days.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rf_delivery_days.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
			this.rf_delivery_days.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rf_delivery_days.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.rf_delivery_days.HeaderText = "Time";
			this.rf_delivery_days.Name = "rf_delivery_days";
			this.rf_delivery_days.ReadOnly = true;
			this.rf_delivery_days.Width = 108;
            this.rf_delivery_days.Visible = false;
			this.grid.Columns.Add(rf_delivery_days);
			//
			// rd_sequence
			//
			rd_sequence= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rd_sequence.DataPropertyName = "RdSequence";
			this.rd_sequence.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rd_sequence.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
			this.rd_sequence.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rd_sequence.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.rd_sequence.HeaderText = "Time";
			this.rd_sequence.Name = "rd_sequence";
            this.rd_sequence.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.rd_sequence.ReadOnly = true;
			this.rd_sequence.Width = 98;
            this.rd_sequence.Visible = false;
			this.grid.Columns.Add(rd_sequence);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(grid);
		}

        void grid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (((Metex.Windows.DataEntityGrid)sender).CurrentColumnName == "rf_distance_of_leg")
            {
                this.grid.EndEdit();
                OnItemChanged(sender, e);
            }
        }

        void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (grid.Columns[e.ColumnIndex].Name == "rf_distance_of_leg")
            {
                string createValue = grid.Rows[e.RowIndex].Cells["rf_distance_of_leg"].EditedFormattedValue.ToString();

                if (grid.Rows[e.RowIndex].Cells["rf_distance_of_leg"].Value != null)
                {
                    if (grid.Rows[e.RowIndex].Cells["rf_distance_of_leg"].Value.ToString() != "0.00")
                    {
                        try
                        {
                            int.Parse(createValue);
                        }
                        catch
                        {
                            MessageBox.Show("Item " + '"' + " does not pass validation test.", "Rural Delivery System with NPAD Extensions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grid.Rows[e.RowIndex].Cells["rf_distance_of_leg"].EditedFormattedValue.ToString();
                        }
                        e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                }
                else
                {
                    e.Cancel = false;
                }
               
            }
        }

        void grid_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            if (((Metex.Windows.DataEntityGrid)sender).CurrentColumnName =="rfv_id" ||
                ((Metex.Windows.DataEntityGrid)sender).CurrentColumnName == "rfv_id_2" ||
                ((Metex.Windows.DataEntityGrid)sender).CurrentColumnName == "rfpt_id")
            this.grid.EndEdit();
        }

        void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (grid.Columns[e.ColumnIndex].Name == "dos_button")
            {
                //if( ( show_question =1 OR (not(IsNull(cust_id))))  and  (question_down = 1),1,0)
                if ((System.Convert.ToInt32(grid.Rows[e.RowIndex].Cells["show_question"].Value) == 1 ||
                grid.Rows[e.RowIndex].Cells["cust_id"].Value != null) &&
                System.Convert.ToInt32(grid.Rows[e.RowIndex].Cells["question_down"].Value) != 1)
                {
                    DGVCustomButtonCell bCell = (DGVCustomButtonCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    bCell.Enabled = true;
                }
                else
                {
                    DGVCustomButtonCell bCell = (DGVCustomButtonCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    bCell.Enabled = false;
                }
            }
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (grid.RowCount == 0)
                return;
            for (int i = 0; i < this.RowCount; i++)
            {   //if( ( show_question =1 OR (not(IsNull(cust_id))))  and  (question_down = 1),1,0)
                //if(( show_question =1 OR (not(IsNull(cust_id)))) and not(question_down=1) ,1,0)
                if (System.Convert.ToInt32(grid.Rows[i].Cells["show_question"].Value) == 1 || grid.Rows[i].Cells["cust_id"].Value != null)
                {
                    if (System.Convert.ToInt32(grid.Rows[i].Cells["question_down"].Value) != 1)
                    {
                        grid.Rows[i].Cells["rd_description_of_point"].ReadOnly = true;
                        DGVCustomButtonCell buttonCell = (DGVCustomButtonCell)grid.Rows[i].Cells["dos_button"];
                        buttonCell.Enabled = false;
                       //? grid.Rows[i].Cells["dos_button2"].Value = false;
                    }
                    else {
                        grid.Rows[i].Cells["rd_description_of_point"].ReadOnly = false;
                        //?grid.Rows[i].Cells["dos_button"].Visible = true;
                        DGVCustomButtonCell buttonCell = (DGVCustomButtonCell)grid.Rows[i].Cells["dos_button"];
                        buttonCell.Enabled = true;
                    }
                }
                else
                {
                    grid.Rows[i].Cells["rd_description_of_point"].ReadOnly = false;
                    //?grid.Rows[i].Cells["dos_button2"].Visible = false;
                }
                grid.Rows[i].Cells["compute_1"].Value = i+1;
            }
        }
		#endregion

    }

    #region Custom Button
    public class DGVCustomButtonColumn : DataGridViewImageColumn
    {
        public DGVCustomButtonColumn()
        {
            this.CellTemplate = new DGVCustomButtonCell();
        }
    }

    public class DGVCustomButtonCell : DataGridViewImageCell
    {
        private bool enabledValue;
        public bool Enabled
        {
            get
            {
                return enabledValue;
            }
            set
            {
                enabledValue = value;
            }
        }

        
        public override object Clone()
        {
            DGVCustomButtonCell cell = (DGVCustomButtonCell)base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }

        public DGVCustomButtonCell()
        {
            this.enabledValue = true;
        }

        protected override void Paint(
            Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value, object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            if (this.enabledValue)
            {
                     base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                    elementState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, paintParts);
            }
            else
            {
                // Draw the cell background, if specified.
                if ((paintParts & DataGridViewPaintParts.Background) == DataGridViewPaintParts.Background)
                {
                    SolidBrush cellBackground = new SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                // Draw the cell borders
                if ((paintParts & DataGridViewPaintParts.Border) == DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
                }

            }
        }
    }
    #endregion

}
