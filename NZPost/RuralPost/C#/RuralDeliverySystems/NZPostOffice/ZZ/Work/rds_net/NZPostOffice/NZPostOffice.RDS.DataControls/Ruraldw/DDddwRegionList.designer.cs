using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;
using Metex.Windows;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DDddwRegionList
    {

        ///// <summary>
        ///// Required designer variable.
        ///// </summary>
        //private System.ComponentModel.IContainer components = null;
        //private DataGridViewEntityComboColumn region_list;
        //private System.Windows.Forms.DataGridViewTextBoxColumn region_region_id;
        //private System.Windows.Forms.DataGridViewTextBoxColumn region_rgn_name;


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private Metex.Windows.DataEntityGrid grid;
        //#region Component Designer generated code
        //private void InitializeComponent()
        //{
        //    components = new System.ComponentModel.Container();
        //    grid = new Metex.Windows.DataEntityGrid();
        //    ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
        //    this.SuspendLayout();

        //    // 
        //    // bindingSource
        //    //
        //    this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.DddwRegionList);

        //    // 
        //    // grid
        //    // 
        //    this.grid.AllowUserToAddRows = false;
        //    this.grid.AllowUserToResizeRows = false;
        //    this.grid.AutoGenerateColumns = false;
        //    this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        //    this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
        //    this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
        //    this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
        //    this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        //    this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        //    this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        //    this.grid.ColumnHeadersVisible = false;
        //    this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        //    this.grid.DataSource = this.bindingSource;
        //    this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
        //    this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
        //    this.grid.Location = new System.Drawing.Point(0, 0);
        //    this.grid.MultiSelect = true;
        //    this.grid.Name = "grid";
        //    this.grid.RowHeadersVisible = false;
        //    this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        //    this.grid.Size = new System.Drawing.Size(638, 252);
        //    this.grid.DataError += new DataGridViewDataErrorEventHandler(grid_DataError);
        //    this.grid.TabIndex = 0;

        //    //
        //    // region_list
        //    //
        //    region_list = new DataGridViewEntityComboColumn();// System.Windows.Forms.DataGridViewComboBoxColumn();
        //    this.region_list.DataPropertyName = "RegionList";
        //    this.region_list.DefaultCellStyle.BackColor = System.Drawing.Color.White;
        //    this.region_list.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
        //    this.region_list.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
        //    this.region_list.HeaderText = "";
        //    this.region_list.Name = "region_list";
        //    this.region_list.Width = 110;
        //    this.region_list.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
        //    this.region_list.DisplayStyleForCurrentCellOnly = true;

        //    this.grid.Columns.Add(region_list);


        //    //
        //    // region_region_id
        //    //
        //    region_region_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    this.region_region_id.DataPropertyName = "RegionRegionId";
        //    this.region_region_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        //    this.region_region_id.DefaultCellStyle.BackColor = System.Drawing.Color.White;
        //    this.region_region_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
        //    this.region_region_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
        //    this.region_region_id.HeaderText = "";
        //    this.region_region_id.Name = "region_region_id";
        //    this.region_region_id.ReadOnly = true;
        //    this.region_region_id.Width = 200;
        //    this.region_region_id.Visible = false;
        //    this.grid.Columns.Add(region_region_id);

        //    //
        //    // region_rgn_name
        //    //
        //    region_rgn_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
        //    this.region_rgn_name.DataPropertyName = "RegionRgnName";
        //    this.region_rgn_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        //    this.region_rgn_name.DefaultCellStyle.BackColor = System.Drawing.Color.White;
        //    this.region_rgn_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
        //    this.region_rgn_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
        //    this.region_rgn_name.HeaderText = "";
        //    this.region_rgn_name.Name = "region_rgn_name";
        //    this.region_rgn_name.ReadOnly = true;
        //    this.region_rgn_name.Width = 200;
        //    this.region_rgn_name.Visible = false;
        //    this.grid.Columns.Add(region_rgn_name);

        //    ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
        //    this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.Size = new System.Drawing.Size(638, 252);
        //    this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
        //    this.Controls.Add(grid);
        //}

        //void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    if (grid.Columns[e.ColumnIndex].Name == "region_list")
        //    {
        //        e.Cancel = false;
        //    }
        //}
        //#endregion

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

        private Metex.Windows.DataEntityCombo region_list;
        private System.Windows.Forms.TextBox region_region_id;
        private System.Windows.Forms.TextBox region_rgn_name;
        private System.Windows.Forms.TextBox region_list1;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.Name = "DDddwRegionList";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.DddwRegionList);
            //
            // region_list1
            //
            this.region_list1 = new TextBox();
            this.region_list1.Width = 110;
            this.region_list1.Name = "region_list1";
            this.region_list1.Location = new System.Drawing.Point(3, 1);
            this.Controls.Add(this.region_list1);
            //
            // region_list
            //
            region_list = new Metex.Windows.DataEntityCombo();
            this.region_list.AutoRetrieve = true;
            this.region_list.BackColor = System.Drawing.Color.White;
            this.region_list.DisplayMember = "RgnName";
            this.region_list.Font = new System.Drawing.Font("Arial", 8F);
            this.region_list.ForeColor = System.Drawing.Color.Black;
            this.region_list.Location = new System.Drawing.Point(3, 1);
            this.region_list.Name = "region_list";
            this.region_list.Size = new System.Drawing.Size(127, 17);
            this.region_list.TabIndex = 10;
            this.region_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.region_list.Value = null;
            this.region_list.ValueMember = "RegionId";
            this.region_list.DropDownWidth = 127;
            this.region_list.DataBindings.Add(
                new System.Windows.Forms.Binding("Value", this.bindingSource, "RegionList1", true,
                System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_list.DataBindings[0].DataSourceNullValue = null;
            this.Controls.Add(region_list);

            //
            // region_region_id
            //
            region_region_id = new System.Windows.Forms.TextBox();
            this.region_region_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.region_region_id.Font = new System.Drawing.Font("Arial", 8F);
            this.region_region_id.ForeColor = System.Drawing.Color.Black;
            this.region_region_id.Location = new System.Drawing.Point(257, 13);
            this.region_region_id.MaxLength = 0;
            this.region_region_id.Name = "region_region_id";
            this.region_region_id.Size = new System.Drawing.Size(217, 14);
            this.region_region_id.TextAlign = HorizontalAlignment.Left;
            this.region_region_id.BackColor = System.Drawing.Color.White;
            this.region_region_id.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "RegionRegionId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_region_id.ReadOnly = true;
            this.Controls.Add(region_region_id);

            //
            // region_rgn_name
            //
            region_rgn_name = new System.Windows.Forms.TextBox();
            this.region_rgn_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.region_rgn_name.Font = new System.Drawing.Font("Arial", 8F);
            this.region_rgn_name.ForeColor = System.Drawing.Color.Black;
            this.region_rgn_name.Location = new System.Drawing.Point(475, 13);
            this.region_rgn_name.MaxLength = 0;
            this.region_rgn_name.Name = "region_rgn_name";
            this.region_rgn_name.Size = new System.Drawing.Size(201, 14);
            this.region_rgn_name.TextAlign = HorizontalAlignment.Left;
            this.region_rgn_name.BackColor = System.Drawing.Color.White;
            this.region_rgn_name.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.bindingSource, "RegionRgnName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.region_rgn_name.ReadOnly = true;
            this.Controls.Add(region_rgn_name);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            
        }
        #endregion

    }
}
