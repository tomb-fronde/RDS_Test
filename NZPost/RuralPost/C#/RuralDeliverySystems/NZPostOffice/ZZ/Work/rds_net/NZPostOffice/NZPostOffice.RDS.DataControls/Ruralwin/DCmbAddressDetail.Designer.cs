using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    partial class DCmbAddressDetail
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

        private System.Windows.Forms.TextBox cmb_id;
        private System.Windows.Forms.Label post_code_id_t;
        private System.Windows.Forms.Label cmb_id_t;
        private System.Windows.Forms.Label cmb_box_no_t;
        private Metex.Windows.DataEntityCombo rd_no;
        private System.Windows.Forms.Label t_rd_no;
        private Metex.Windows.DataEntityCombo tc_id;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.TextBox cmb_cust_initials;
        private System.Windows.Forms.TextBox cmb_cust_surname;
        private System.Windows.Forms.TextBox post_code;
        private System.Windows.Forms.Label cmb_cust_details_t;
        private System.Windows.Forms.TextBox cmb_box_no;
        private System.Windows.Forms.Label cmb_cust_initials_t;
        private System.Windows.Forms.Label cmb_cust_surname_t;

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DCmbAddressDetail";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.CmbAddressDetail);
			//
			// cmb_box_no_t
			//
			this.cmb_box_no_t = new System.Windows.Forms.Label();
			this.cmb_box_no_t.Font = new System.Drawing.Font("Arial", 8F);
			this.cmb_box_no_t.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmb_box_no_t.Location = new System.Drawing.Point(14, 28);
			this.cmb_box_no_t.Name = "cmb_box_no_t";
			this.cmb_box_no_t.Size = new System.Drawing.Size(95, 14);
			this.cmb_box_no_t.Text = "Box No:";
			this.cmb_box_no_t.TextAlign = ContentAlignment.MiddleRight;
			this.cmb_box_no_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(cmb_box_no_t);

			//
			// cmb_id_t
			//
			this.cmb_id_t = new System.Windows.Forms.Label();
			this.cmb_id_t.Font = new System.Drawing.Font("Arial", 8F);
			this.cmb_id_t.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmb_id_t.Location = new System.Drawing.Point(14, 6);
			this.cmb_id_t.Name = "cmb_id_t";
			this.cmb_id_t.Size = new System.Drawing.Size(95, 14);
			this.cmb_id_t.Text = "Cmb Id:";
			this.cmb_id_t.TextAlign = ContentAlignment.MiddleRight;
			this.cmb_id_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(cmb_id_t);

			//
			// cmb_cust_initials_t
			//
			this.cmb_cust_initials_t = new System.Windows.Forms.Label();
			this.cmb_cust_initials_t.Font = new System.Drawing.Font("Arial", 8F);
			this.cmb_cust_initials_t.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmb_cust_initials_t.Location = new System.Drawing.Point(11, 184);
			this.cmb_cust_initials_t.Name = "cmb_cust_initials_t";
			this.cmb_cust_initials_t.Size = new System.Drawing.Size(99, 14);
			this.cmb_cust_initials_t.Text = "Initials / First Name";
			this.cmb_cust_initials_t.TextAlign = ContentAlignment.MiddleRight;
			this.cmb_cust_initials_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(cmb_cust_initials_t);

			//
			// cmb_cust_surname_t
			//
			this.cmb_cust_surname_t = new System.Windows.Forms.Label();
			this.cmb_cust_surname_t.Font = new System.Drawing.Font("Arial", 8F);
			this.cmb_cust_surname_t.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmb_cust_surname_t.Location = new System.Drawing.Point(5, 161);
			this.cmb_cust_surname_t.Name = "cmb_cust_surname_t";
			this.cmb_cust_surname_t.Size = new System.Drawing.Size(106, 14);
			this.cmb_cust_surname_t.Text = "Surname / Company";
			this.cmb_cust_surname_t.TextAlign = ContentAlignment.MiddleRight;
			this.cmb_cust_surname_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(cmb_cust_surname_t);

			//
			// cmb_cust_details_t
			//
			this.cmb_cust_details_t = new System.Windows.Forms.Label();
            this.cmb_cust_details_t.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmb_cust_details_t.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmb_cust_details_t.Location = new System.Drawing.Point(9, 135);
			this.cmb_cust_details_t.Name = "cmb_cust_details_t";
			this.cmb_cust_details_t.Size = new System.Drawing.Size(119, 14);
			this.cmb_cust_details_t.Text = "CMB Customer Details:";
			this.cmb_cust_details_t.TextAlign = ContentAlignment.MiddleRight;
			this.cmb_cust_details_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(cmb_cust_details_t);

			//
			// cmb_cust_surname
			//
			cmb_cust_surname = new System.Windows.Forms.TextBox();
			this.cmb_cust_surname.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.cmb_cust_surname.Font = new System.Drawing.Font("Arial", 8F);
			this.cmb_cust_surname.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmb_cust_surname.Location = new System.Drawing.Point(112, 157);
			this.cmb_cust_surname.MaxLength = 45;
			this.cmb_cust_surname.Name = "cmb_cust_surname";
			this.cmb_cust_surname.Size = new System.Drawing.Size(230, 20);
			this.cmb_cust_surname.TextAlign = HorizontalAlignment.Left;
			this.cmb_cust_surname.BackColor = System.Drawing.Color.White;
			this.cmb_cust_surname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CmbCustSurname", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cmb_cust_surname.TabIndex = 40;
			this.Controls.Add(cmb_cust_surname);

			//
			// cmb_cust_initials
			//
			cmb_cust_initials = new System.Windows.Forms.TextBox();
			this.cmb_cust_initials.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.cmb_cust_initials.Font = new System.Drawing.Font("Arial", 8F);
			this.cmb_cust_initials.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmb_cust_initials.Location = new System.Drawing.Point(112, 181);
			this.cmb_cust_initials.MaxLength = 30;
			this.cmb_cust_initials.Name = "cmb_cust_initials";
			this.cmb_cust_initials.Size = new System.Drawing.Size(230, 20);
			this.cmb_cust_initials.TextAlign = HorizontalAlignment.Left;
			this.cmb_cust_initials.BackColor = System.Drawing.Color.White;
			this.cmb_cust_initials.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "CmbCustInitials", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cmb_cust_initials.TabIndex = 50;
			this.Controls.Add(cmb_cust_initials);

			//
			// t_1
			//
			this.t_1 = new System.Windows.Forms.Label();
			this.t_1.Font = new System.Drawing.Font("Arial", 8F);
			this.t_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.t_1.Location = new System.Drawing.Point(14, 54);
			this.t_1.Name = "t_1";
			this.t_1.Size = new System.Drawing.Size(95, 14);
			this.t_1.Text = "Mailtown:";
			this.t_1.TextAlign = ContentAlignment.MiddleRight;
			this.Controls.Add(t_1);

			//
			// cmb_id
			//
			cmb_id = new System.Windows.Forms.TextBox();
			this.cmb_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cmb_id.Font = new System.Drawing.Font("Arial", 8F);
			this.cmb_id.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmb_id.Location = new System.Drawing.Point(115, 6);
			this.cmb_id.MaxLength = 0;
			this.cmb_id.Name = "cmb_id";
			this.cmb_id.Size = new System.Drawing.Size(59, 13);
			this.cmb_id.TextAlign = HorizontalAlignment.Left;
			this.cmb_id.DataBindings.Add(new System.Windows.Forms.Binding("Text",this.bindingSource, "CmbId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cmb_id.ReadOnly=true;
			this.Controls.Add(cmb_id);

			//
			// post_code_id_t
			//
			this.post_code_id_t = new System.Windows.Forms.Label();
			this.post_code_id_t.Font = new System.Drawing.Font("Arial", 8F);
			this.post_code_id_t.ForeColor = System.Drawing.SystemColors.WindowText;
			this.post_code_id_t.Location = new System.Drawing.Point(14, 77);
			this.post_code_id_t.Name = "post_code_id_t";
			this.post_code_id_t.Size = new System.Drawing.Size(95, 14);
			this.post_code_id_t.Text = "Postcode:";
			this.post_code_id_t.TextAlign = ContentAlignment.MiddleRight;
			this.post_code_id_t.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(post_code_id_t);

			//
			// tc_id
			//
			tc_id = new Metex.Windows.DataEntityCombo();
			this.tc_id.AutoRetrieve = true;
			this.tc_id.BackColor = System.Drawing.SystemColors.Window;
			this.tc_id.DisplayMember = "MailTown";
			this.tc_id.Font = new System.Drawing.Font("Arial", 8F);
			this.tc_id.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tc_id.Location = new System.Drawing.Point(115, 51);
			this.tc_id.Name = "tc_id";
			this.tc_id.Size = new System.Drawing.Size(117, 22);
			this.tc_id.TabIndex = 20;
			this.tc_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tc_id.Value = null;
			this.tc_id.ValueMember = "TcId";
			this.tc_id.DropDownWidth = 117;
			this.tc_id.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "TcId", true,System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Controls.Add(tc_id);

			//
			// cmb_box_no
			//
			cmb_box_no = new System.Windows.Forms.TextBox();
			this.cmb_box_no.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.cmb_box_no.Font = new System.Drawing.Font("Arial", 8F);
			this.cmb_box_no.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmb_box_no.Location = new System.Drawing.Point(115, 27);
			this.cmb_box_no.MaxLength = 0;
			this.cmb_box_no.Name = "cmb_box_no";
			this.cmb_box_no.Size = new System.Drawing.Size(60, 20);
			this.cmb_box_no.TextAlign = HorizontalAlignment.Left;
			this.cmb_box_no.BackColor = System.Drawing.Color.White;
			this.cmb_box_no.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CmbBoxNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.cmb_box_no.TabIndex = 10;
			this.Controls.Add(cmb_box_no);

			//
			// t_rd_no
			//
			this.t_rd_no = new System.Windows.Forms.Label();
			this.t_rd_no.Font = new System.Drawing.Font("Arial", 8F);
			this.t_rd_no.ForeColor = System.Drawing.SystemColors.WindowText;
			this.t_rd_no.Location = new System.Drawing.Point(69, 104);
			this.t_rd_no.Name = "t_rd_no";
			this.t_rd_no.Size = new System.Drawing.Size(40, 14);
			this.t_rd_no.Text = "RD No:";
			this.t_rd_no.TextAlign = ContentAlignment.MiddleRight;
			this.Controls.Add(t_rd_no);

			//
			// post_code
			//
			post_code = new System.Windows.Forms.TextBox();
			this.post_code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.post_code.Font = new System.Drawing.Font("Arial", 8F);
			this.post_code.ForeColor = System.Drawing.SystemColors.WindowText;
			this.post_code.Location = new System.Drawing.Point(115, 76);
			this.post_code.MaxLength = 0;
			this.post_code.Name = "post_code";
			this.post_code.Size = new System.Drawing.Size(47, 20);
			this.post_code.TextAlign = HorizontalAlignment.Left;
			this.post_code.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PostCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.post_code.ReadOnly=true;
            this.post_code.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.Controls.Add(post_code);

			//
			// rd_no
			//
			rd_no = new Metex.Windows.DataEntityCombo();
			this.rd_no.AutoRetrieve = true;
			this.rd_no.BackColor = System.Drawing.Color.White;
			this.rd_no.DisplayMember = "RdNo";
			this.rd_no.Font = new System.Drawing.Font("Arial", 8F);
			this.rd_no.ForeColor = System.Drawing.SystemColors.WindowText;
			this.rd_no.Location = new System.Drawing.Point(115, 99);
			this.rd_no.Name = "rd_no";
			this.rd_no.Size = new System.Drawing.Size(60, 22);
			this.rd_no.TabIndex = 30;
			this.rd_no.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.rd_no.Value = null;
			this.rd_no.ValueMember = "RdNo";
			this.rd_no.DropDownWidth = 60;
			this.rd_no.DataBindings.Add( new System.Windows.Forms.Binding("Text", this.bindingSource, "RdNo", true,System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Controls.Add(rd_no);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
//?            this.BorderStyle = BorderStyle.Fixed3D;
		}
        #endregion

    }
}
