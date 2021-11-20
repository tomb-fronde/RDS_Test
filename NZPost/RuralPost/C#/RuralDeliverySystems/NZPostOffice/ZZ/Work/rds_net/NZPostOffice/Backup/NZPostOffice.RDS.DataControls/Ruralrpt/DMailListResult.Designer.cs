namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
    partial class DMailListResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn postcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn town_postcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn rd_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn locality;
        private System.Windows.Forms.DataGridViewTextBoxColumn road_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_company_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn post_town;
        private System.Windows.Forms.DataGridViewTextBoxColumn road_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn initials;
        private System.Windows.Forms.DataGridViewTextBoxColumn dp_id;    //added wjtang  SR4703


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
            components = new System.ComponentModel.Container();
            grid = new Metex.Windows.DataEntityGrid();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.MailListResult);

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
            this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.ColumnHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.TabIndex = 0;

            //
            // customer_id
            //
            customer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_id.DataPropertyName = "CustomerId";
            this.customer_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.customer_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.customer_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.customer_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.customer_id.HeaderText = "";
            this.customer_id.Name = "customer_id";
            this.customer_id.ReadOnly = true;
            this.customer_id.Width = 60;
            this.grid.Columns.Add(customer_id);

            //
            // title
            //
            title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title.DataPropertyName = "Title";
            this.title.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.title.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.title.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.title.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.title.HeaderText = "";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            this.title.Width = 55;
            this.grid.Columns.Add(title);

            //
            // initials
            //
            initials = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initials.DataPropertyName = "Initials";
            this.initials.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.initials.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.initials.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.initials.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.initials.HeaderText = "";
            this.initials.Name = "initials";
            this.initials.ReadOnly = true;
            this.initials.Width = 155;
            this.grid.Columns.Add(initials);

            //
            // last_company_name
            //
            last_company_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_company_name.DataPropertyName = "LastCompanyName";
            this.last_company_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.last_company_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.last_company_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.last_company_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.last_company_name.HeaderText = "";
            this.last_company_name.Name = "last_company_name";
            this.last_company_name.ReadOnly = true;
            this.last_company_name.Width = 230;
            this.grid.Columns.Add(last_company_name);

            //
            // road_no
            //
            road_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.road_no.DataPropertyName = "RoadNo";
            this.road_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.road_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.road_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.road_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.road_no.HeaderText = "";
            this.road_no.Name = "road_no";
            this.road_no.ReadOnly = true;
            this.road_no.Width = 105;
            this.grid.Columns.Add(road_no);

            //
            // road_name
            //
            road_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.road_name.DataPropertyName = "RoadName";
            this.road_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.road_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.road_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.road_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.road_name.HeaderText = "";
            this.road_name.Name = "road_name";
            this.road_name.ReadOnly = true;
            this.road_name.Width = 507;
            this.grid.Columns.Add(road_name);

            //
            // locality
            //
            locality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locality.DataPropertyName = "Locality";
            this.locality.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.locality.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.locality.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.locality.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.locality.HeaderText = "";
            this.locality.Name = "locality";
            this.locality.ReadOnly = true;
            this.locality.Width = 256;
            this.grid.Columns.Add(locality);

            //
            // rd_no
            //
            rd_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rd_no.DataPropertyName = "RdNo";
            this.rd_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rd_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rd_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.rd_no.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.rd_no.HeaderText = "";
            this.rd_no.Name = "rd_no";
            this.rd_no.ReadOnly = true;
            this.rd_no.Width = 205;
            this.grid.Columns.Add(rd_no);

            //
            // town_postcode
            //
            town_postcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.town_postcode.DataPropertyName = "TownPostcode";
            this.town_postcode.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.town_postcode.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.town_postcode.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.town_postcode.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.town_postcode.HeaderText = "";
            this.town_postcode.Name = "town_postcode";
            this.town_postcode.ReadOnly = true;
            this.town_postcode.Width = 230;
            this.grid.Columns.Add(town_postcode);

            //
            // post_town
            //
            post_town = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.post_town.DataPropertyName = "PostTown";
            this.post_town.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //this.post_town.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.post_town.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.post_town.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.post_town.HeaderText = "";
            this.post_town.Name = "post_town";
            this.post_town.ReadOnly = true;
            this.post_town.Width = 281;
            this.grid.Columns.Add(post_town);

            //
            // postcode
            //
            postcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postcode.DataPropertyName = "Postcode";
            this.postcode.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //this.postcode.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.postcode.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.postcode.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.postcode.HeaderText = "";
            this.postcode.Name = "postcode";
            this.postcode.ReadOnly = true;
            this.postcode.Width = 52;
            this.grid.Columns.Add(postcode);

            //
            // dp_id
            //
            dp_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dp_id.DataPropertyName = "DpId";
            this.dp_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dp_id.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dp_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.dp_id.HeaderText = "";
            this.dp_id.Name = "dp_id";
            this.dp_id.ReadOnly = true;
            this.dp_id.Width = 20;
            this.grid.Columns.Add(dp_id);

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(grid);
        }
        #endregion

    }
}
