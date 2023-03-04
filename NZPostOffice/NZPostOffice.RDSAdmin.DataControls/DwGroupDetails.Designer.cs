using Metex.Windows;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using System;
namespace NZPostOffice.RDSAdmin.DataControls.Security
{
    partial class DwGroupDetails
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
        public Metex.Windows.DataEntityGrid Grid
        {
            get
            {
                return grid;
            }
        }

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.rds_user_rights_rc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rds_component_rc_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.component_list = new System.Windows.Forms.DataGridViewButtonColumn();
            this.rds_user_rights_region_id = new Metex.Windows.DataGridViewEntityComboColumn();

            this.rds_user_rights_rur_create = new DGVCheckBoxColumn();// System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rds_user_rights_rur_read = new DGVCheckBoxColumn();// System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rds_user_rights_rur_modify = new DGVCheckBoxColumn();// System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rds_user_rights_rur_delete = new DGVCheckBoxColumn();// System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rds_component_rc_allowcreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rds_component_rc_allowread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rds_component_rc_allowmodify = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rds_component_rc_allowdelete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.GroupDetails);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rds_user_rights_rc_id,
            this.rds_component_rc_description,
            this.component_list,
            this.rds_user_rights_region_id,
            this.rds_user_rights_rur_create,
            this.rds_user_rights_rur_read,
            this.rds_user_rights_rur_modify,
            this.rds_user_rights_rur_delete,
            this.rds_component_rc_allowcreate,
            this.rds_component_rc_allowread,
            this.rds_component_rc_allowmodify,
            this.rds_component_rc_allowdelete});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);

            this.grid.CurrentCellDirtyStateChanged += new System.EventHandler(grid_CurrentCellDirtyStateChanged);
            //this.grid.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(grid_DataBindingComplete);
            this.grid.CellValueChanged += new DataGridViewCellEventHandler(grid_CellValueChanged);
            this.grid.CellPainting += new DataGridViewCellPaintingEventHandler(grid_CellPainting);
            this.grid.TabIndex = 0;
            // 
            // rds_user_rights_rc_id
            // 
            this.rds_user_rights_rc_id.DataPropertyName = "RdsUserRightsRcId";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.rds_user_rights_rc_id.DefaultCellStyle = dataGridViewCellStyle2;
            this.rds_user_rights_rc_id.HeaderText = "";
            this.rds_user_rights_rc_id.Name = "rds_user_rights_rc_id";
            this.rds_user_rights_rc_id.ReadOnly = true;
            this.rds_user_rights_rc_id.Visible = false;
            this.rds_user_rights_rc_id.Width = 19;
            // 
            // rds_component_rc_description
            // 
            this.rds_component_rc_description.DataPropertyName = "RdsComponentRcDescription";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            this.rds_component_rc_description.DefaultCellStyle = dataGridViewCellStyle3;
            this.rds_component_rc_description.HeaderText = "Component";
            this.rds_component_rc_description.Name = "rds_component_rc_description";
            this.rds_component_rc_description.ReadOnly = true;
            this.rds_component_rc_description.Width = 259;
            // 
            // component_list
            // 
            this.component_list.DataPropertyName = "ButtonText";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.component_list.DefaultCellStyle = dataGridViewCellStyle4;
            this.component_list.HeaderText = "";
            this.component_list.Name = "component_list";
            this.component_list.ReadOnly = true;
            this.component_list.Text = "...";
            this.component_list.Width = 24;
            // 
            // rds_user_rights_region_id
            // 
            this.rds_user_rights_region_id.DataPropertyName = "RdsUserRightsRegionId";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.rds_user_rights_region_id.DefaultCellStyle = dataGridViewCellStyle5;
            this.rds_user_rights_region_id.HeaderText = "Region";
            this.rds_user_rights_region_id.Name = "rds_user_rights_region_id";
            this.rds_user_rights_region_id.Width = 133;
            // 
            // rds_user_rights_rur_create
            // 
            this.rds_user_rights_rur_create.DataPropertyName = "RdsUserRightsRurCreate";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.NullValue = false;
            this.rds_user_rights_rur_create.DefaultCellStyle = dataGridViewCellStyle6;
            this.rds_user_rights_rur_create.FalseValue = "N";
            this.rds_user_rights_rur_create.HeaderText = "C";
            this.rds_user_rights_rur_create.Name = "rds_user_rights_rur_create";
            this.rds_user_rights_rur_create.TrueValue = "Y";
            this.rds_user_rights_rur_create.Width = 24;
            this.rds_user_rights_rur_create.ReadOnly = true;
            // 
            // rds_user_rights_rur_read
            // 
            this.rds_user_rights_rur_read.DataPropertyName = "RdsUserRightsRurRead";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle7.NullValue = false;
            this.rds_user_rights_rur_read.DefaultCellStyle = dataGridViewCellStyle7;
            this.rds_user_rights_rur_read.FalseValue = "N";
            this.rds_user_rights_rur_read.HeaderText = "R";
            this.rds_user_rights_rur_read.Name = "rds_user_rights_rur_read";
            this.rds_user_rights_rur_read.TrueValue = "Y";
            this.rds_user_rights_rur_read.Width = 24;
            this.rds_user_rights_rur_read.ReadOnly = true;
            // 
            // rds_user_rights_rur_modify
            // 
            this.rds_user_rights_rur_modify.DataPropertyName = "RdsUserRightsRurModify";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle8.NullValue = false;
            this.rds_user_rights_rur_modify.DefaultCellStyle = dataGridViewCellStyle8;
            this.rds_user_rights_rur_modify.FalseValue = "N";
            this.rds_user_rights_rur_modify.HeaderText = "M";
            this.rds_user_rights_rur_modify.Name = "rds_user_rights_rur_modify";
            this.rds_user_rights_rur_modify.TrueValue = "Y";
            this.rds_user_rights_rur_modify.Width = 24;
            this.rds_user_rights_rur_modify.ReadOnly = true;
            // 
            // rds_user_rights_rur_delete
            // 
            this.rds_user_rights_rur_delete.DataPropertyName = "RdsUserRightsRurDelete";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle9.NullValue = false;
            this.rds_user_rights_rur_delete.DefaultCellStyle = dataGridViewCellStyle9;
            this.rds_user_rights_rur_delete.FalseValue = "N";
            this.rds_user_rights_rur_delete.HeaderText = "D";
            this.rds_user_rights_rur_delete.Name = "rds_user_rights_rur_delete";
            this.rds_user_rights_rur_delete.TrueValue = "Y";
            this.rds_user_rights_rur_delete.Width = 24;
            this.rds_user_rights_rur_delete.ReadOnly = true;
            // 
            // rds_component_rc_allowcreate
            // 
            this.rds_component_rc_allowcreate.DataPropertyName = "RdsComponentRcAllowcreate";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.rds_component_rc_allowcreate.DefaultCellStyle = dataGridViewCellStyle10;
            this.rds_component_rc_allowcreate.HeaderText = "";
            this.rds_component_rc_allowcreate.Name = "rds_component_rc_allowcreate";
            this.rds_component_rc_allowcreate.ReadOnly = true;
            this.rds_component_rc_allowcreate.Visible = false;
            this.rds_component_rc_allowcreate.Width = 8;
            // 
            // rds_component_rc_allowread
            // 
            this.rds_component_rc_allowread.DataPropertyName = "RdsComponentRcAllowread";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            this.rds_component_rc_allowread.DefaultCellStyle = dataGridViewCellStyle11;
            this.rds_component_rc_allowread.HeaderText = "";
            this.rds_component_rc_allowread.Name = "rds_component_rc_allowread";
            this.rds_component_rc_allowread.ReadOnly = true;
            this.rds_component_rc_allowread.Visible = false;
            this.rds_component_rc_allowread.Width = 8;
            // 
            // rds_component_rc_allowmodify
            // 
            this.rds_component_rc_allowmodify.DataPropertyName = "RdsComponentRcAllowmodify";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            this.rds_component_rc_allowmodify.DefaultCellStyle = dataGridViewCellStyle12;
            this.rds_component_rc_allowmodify.HeaderText = "";
            this.rds_component_rc_allowmodify.Name = "rds_component_rc_allowmodify";
            this.rds_component_rc_allowmodify.ReadOnly = true;
            this.rds_component_rc_allowmodify.Visible = false;
            this.rds_component_rc_allowmodify.Width = 8;
            // 
            // rds_component_rc_allowdelete
            // 
            this.rds_component_rc_allowdelete.DataPropertyName = "RdsComponentRcAllowdelete";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.rds_component_rc_allowdelete.DefaultCellStyle = dataGridViewCellStyle13;
            this.rds_component_rc_allowdelete.HeaderText = "";
            this.rds_component_rc_allowdelete.Name = "rds_component_rc_allowdelete";
            this.rds_component_rc_allowdelete.ReadOnly = true;
            this.rds_component_rc_allowdelete.Visible = false;
            this.rds_component_rc_allowdelete.Width = 8;
            // 
            // DwGroupDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.Controls.Add(this.grid);
            this.Name = "DwGroupDetails";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //create
            if (grid.Columns[e.ColumnIndex].Name == "rds_component_rc_allowcreate")
            {
                DGVCheckBoxCell checkCell = (DGVCheckBoxCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string createValue = e.Value.ToString();
                checkCell.Enabled = createValue == "Y" ? true : false;
            }
            //read
            if (grid.Columns[e.ColumnIndex].Name == "rds_component_rc_allowread")
            {
                DGVCheckBoxCell checkCell2 = (DGVCheckBoxCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string readValue = e.Value.ToString();
                checkCell2.Enabled = readValue == "Y" ? true : false;
            }

            if (grid.Columns[e.ColumnIndex].Name == "rds_component_rc_allowmodify")
            {
                //modify
                DGVCheckBoxCell checkCell3 = (DGVCheckBoxCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string modifyValue = e.Value.ToString();
                checkCell3.Enabled = modifyValue == "Y" ? true : false;
            }

            //delete
            if (grid.Columns[e.ColumnIndex].Name == "rds_component_rc_allowdelete")
            {
                DGVCheckBoxCell checkCell4 = (DGVCheckBoxCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string deleteValue = e.ToString();
                checkCell4.Enabled = deleteValue == "Y" ? true : false;
            }
        }

        private delegate void TriggerItemchanged(object sender, EventArgs args);

        void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.Parent == null)
                return;
            NZPostOffice.RDSAdmin.Entity.Security.GroupDetails entity = ((DataUserControl)grid.Parent).GetItem<NZPostOffice.RDSAdmin.Entity.Security.GroupDetails>(e.RowIndex);
            if (grid.Columns[e.ColumnIndex].Name == "rds_user_rights_rur_create" || grid.Columns[e.ColumnIndex].Name == "rds_user_rights_rur_modify" || grid.Columns[e.ColumnIndex].Name == "rds_user_rights_rur_read" || grid.Columns[e.ColumnIndex].Name == "rds_user_rights_rur_delete")
            {
                // trigger itemchanged event
                try
                {
                    System.Reflection.MethodInfo method = grid.Parent.Parent.Parent.GetType().GetMethod("dw_detail_ItemChanged");
                    method.Invoke(grid.Parent.Parent.Parent, new object[] { null, null });
                }
                catch (Exception ex)
                { }
            }

            if (grid.Columns[e.ColumnIndex].Name == "rds_component_rc_allowread")
            {
                DGVCheckBoxCell checkCell2 = (DGVCheckBoxCell)grid.Rows[e.RowIndex].Cells["rds_user_rights_rur_read"];
                string readValue = grid.Rows[e.RowIndex].Cells["rds_component_rc_allowread"].Value.ToString();
                checkCell2.Enabled = readValue == "Y" ? true : false;
            }

            if (grid.Columns[e.ColumnIndex].Name == "rds_component_rc_allowcreate")
            {
                DGVCheckBoxCell checkCell3 = (DGVCheckBoxCell)grid.Rows[e.RowIndex].Cells["rds_user_rights_rur_modify"];
                string modifyValue = grid.Rows[e.RowIndex].Cells["rds_component_rc_allowmodify"].Value.ToString();
                checkCell3.Enabled = modifyValue == "Y" ? true : false;
            }

            if (grid.Columns[e.ColumnIndex].Name == "rds_component_rc_allowcreate")
            {
                DGVCheckBoxCell checkCell4 = (DGVCheckBoxCell)grid.Rows[e.RowIndex].Cells["rds_user_rights_rur_delete"];
                string deleteValue = grid.Rows[e.RowIndex].Cells["rds_component_rc_allowdelete"].Value.ToString();
                checkCell4.Enabled = deleteValue == "Y" ? true : false;
            }
            grid.Invalidate();
        }

        void grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < this.grid.RowCount; i++)
            {
                //create
                if (grid.Rows[i].Cells["rds_component_rc_allowcreate"].Value != null)
                {
                    DGVCheckBoxCell checkCell = (DGVCheckBoxCell)grid.Rows[i].Cells["rds_user_rights_rur_create"];
                    string createValue = grid.Rows[i].Cells["rds_component_rc_allowcreate"].Value.ToString();
                    checkCell.Enabled = createValue == "Y" ? true : false;
                }
                //read
                if (grid.Rows[i].Cells["rds_component_rc_allowread"].Value != null)
                {
                    DGVCheckBoxCell checkCell2 = (DGVCheckBoxCell)grid.Rows[i].Cells["rds_user_rights_rur_read"];
                    string readValue = grid.Rows[i].Cells["rds_component_rc_allowread"].Value.ToString();
                    checkCell2.Enabled = readValue == "Y" ? true : false;
                }

                if (grid.Rows[i].Cells["rds_component_rc_allowmodify"].Value != null)
                {
                    //modify
                    DGVCheckBoxCell checkCell3 = (DGVCheckBoxCell)grid.Rows[i].Cells["rds_user_rights_rur_modify"];
                    string modifyValue = grid.Rows[i].Cells["rds_component_rc_allowmodify"].Value.ToString();
                    checkCell3.Enabled = modifyValue == "Y" ? true : false;
                }

                //delete
                if (grid.Rows[i].Cells["rds_component_rc_allowdelete"].Value != null)
                {
                    DGVCheckBoxCell checkCell4 = (DGVCheckBoxCell)grid.Rows[i].Cells["rds_user_rights_rur_delete"];
                    string deleteValue = grid.Rows[i].Cells["rds_component_rc_allowdelete"].Value.ToString();
                    checkCell4.Enabled = deleteValue == "Y" ? true : false;
                }
                grid.Invalidate();
            }
        }

        void grid_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            if (this.grid.IsCurrentCellDirty)
            {
                this.grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn rds_user_rights_rc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn rds_component_rc_description;
        private System.Windows.Forms.DataGridViewButtonColumn component_list;
        private DataGridViewEntityComboColumn rds_user_rights_region_id;

        //private System.Windows.Forms.DataGridViewCheckBoxColumn rds_user_rights_rur_create;
        private DGVCheckBoxColumn rds_user_rights_rur_create;

        //private System.Windows.Forms.DataGridViewCheckBoxColumn rds_user_rights_rur_read;
        private DGVCheckBoxColumn rds_user_rights_rur_read;

        //private System.Windows.Forms.DataGridViewCheckBoxColumn rds_user_rights_rur_modify;
        private DGVCheckBoxColumn rds_user_rights_rur_modify;

        //private System.Windows.Forms.DataGridViewCheckBoxColumn rds_user_rights_rur_delete;
        private DGVCheckBoxColumn rds_user_rights_rur_delete;

        private System.Windows.Forms.DataGridViewTextBoxColumn rds_component_rc_allowcreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn rds_component_rc_allowread;
        private System.Windows.Forms.DataGridViewTextBoxColumn rds_component_rc_allowmodify;
        private System.Windows.Forms.DataGridViewTextBoxColumn rds_component_rc_allowdelete;
    }

    //? added by jlwang for support Display "X" 

    #region DGVCheckBox
    public class DGVCheckBoxColumn : DataGridViewCheckBoxColumn
    {
        public DGVCheckBoxColumn()
        {
            this.CellTemplate = new DGVCheckBoxCell();
        }
    }

    public class DGVCheckBoxCell : DataGridViewCheckBoxCell
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

        // Override the Clone method so that the Enabled property is copied.
        public override object Clone()
        {
            DGVCheckBoxCell cell = (DGVCheckBoxCell)base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }

        // By default, enable the button cell.
        public DGVCheckBoxCell()
        {
            this.enabledValue = true;
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value, object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            if (!this.enabledValue)
            {
                // Draw the cell background, if specified.
                if ((paintParts & DataGridViewPaintParts.Background) == DataGridViewPaintParts.Background)
                {
                    SolidBrush cellBackground = new SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                if ((paintParts & DataGridViewPaintParts.Border) == DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
                }

                Rectangle buttonArea = cellBounds;
                Rectangle buttonAdjustment = this.BorderWidths(advancedBorderStyle);
                buttonArea.X += buttonAdjustment.X + 2;
                buttonArea.Y += buttonAdjustment.Y + 4;
                buttonArea.Height -= buttonAdjustment.Height + 8;
                buttonArea.Width -= buttonAdjustment.Width + 10;

                // Draw the disabled button.                
                ButtonRenderer.DrawButton(graphics, buttonArea, "X", new System.Drawing.Font("Microsoft Sans Serif", 5F), TextFormatFlags.Left, false, PushButtonState.Pressed);

                if (this.FormattedValue is String)
                {
                    TextRenderer.DrawText(graphics, (string)this.FormattedValue, this.DataGridView.Font, buttonArea, SystemColors.GrayText);
                }
            }
            else
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex,elementState, 
                    value, formattedValue, errorText,cellStyle, advancedBorderStyle, paintParts);
            }
        }
    }

#endregion

}
