using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public class WMailingListSearch : WAncestorWindow
    {
        #region Define
        private string is_post = String.Empty;

        private string is_occ = String.Empty;
        private string is_interest = String.Empty;
        private int il_last_click = 0;
        private int il_last_post_click = 0;
        private int il_last_occ_click = 0;
        private int il_last_int_click = 0;
        private System.ComponentModel.IContainer components = null;

        private GroupBox gb_move;
        private GroupBox gb_post;
        private Button pb_search;
        private URdsDw dw_interest;
        private RadioButton rb_specific;

        private RadioButton rb_nation;
        private URdsDw dw_occupation;
        private TextBox sle_move_in_1;
        private TextBox sle_move_in_2;
        private URdsDw dw_post;
        private GroupBox gb_occupations;
        private GroupBox gb_interests;
        private Label st_background;
        private Label st_criteria;
        private URdsDw dw_export;
        private Label st_between;

        private Label st_and;
        private RadioButton rb_and;
        private RadioButton rb_or;

        private Button cb_1;

        #endregion

        public WMailingListSearch()
        {
            this.InitializeComponent();
            this.sle_move_in_1_constructor();
            this.sle_move_in_2_constructor();
            //jlwang:removed from IC

            dw_interest.DataObject = new DInterestCriteria();
            dw_occupation.DataObject = new DOccupationCriteria();
            dw_post.DataObject = new DPostCriteria();
            dw_export.DataObject = new DMailListResult();

            //dw_interest.Constructor += new UserEventDelegate(dw_interest_constructor);
            //dw_occupation.Constructor += new UserEventDelegate(dw_occupation_constructor);
            //dw_post.Constructor += new UserEventDelegate(dw_post_constructor);
            dw_post_constructor();
            dw_occupation_constructor();
            dw_interest_constructor();
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WMailingListSearch));
            this.gb_move = new System.Windows.Forms.GroupBox();
            this.gb_post = new System.Windows.Forms.GroupBox();
            this.pb_search = new System.Windows.Forms.Button();
            this.dw_interest = new NZPostOffice.RDS.Controls.URdsDw();
            this.rb_specific = new System.Windows.Forms.RadioButton();
            this.rb_nation = new System.Windows.Forms.RadioButton();
            this.dw_occupation = new NZPostOffice.RDS.Controls.URdsDw();
            this.sle_move_in_1 = new System.Windows.Forms.TextBox();
            this.sle_move_in_2 = new System.Windows.Forms.TextBox();
            this.dw_post = new NZPostOffice.RDS.Controls.URdsDw();
            this.gb_occupations = new System.Windows.Forms.GroupBox();
            this.gb_interests = new System.Windows.Forms.GroupBox();
            this.st_background = new System.Windows.Forms.Label();
            this.st_criteria = new System.Windows.Forms.Label();
            this.dw_export = new NZPostOffice.RDS.Controls.URdsDw();
            this.st_between = new System.Windows.Forms.Label();
            this.st_and = new System.Windows.Forms.Label();
            this.cb_1 = new System.Windows.Forms.Button();
            this.rb_and = new System.Windows.Forms.RadioButton();
            this.rb_or = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(8, 541);
            this.st_label.Text = "FormBase";
            // 
            // gb_move
            // 
            this.gb_move.BackColor = System.Drawing.SystemColors.Control;
            this.gb_move.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_move.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_move.Location = new System.Drawing.Point(284, 443);
            this.gb_move.Name = "gb_move";
            this.gb_move.Size = new System.Drawing.Size(257, 81);
            this.gb_move.TabIndex = 4;
            this.gb_move.TabStop = false;
            this.gb_move.Text = "Customer Move-In Date";
            // 
            // gb_post
            // 
            this.gb_post.BackColor = System.Drawing.SystemColors.Control;
            this.gb_post.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_post.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_post.Location = new System.Drawing.Point(17, 35);
            this.gb_post.Name = "gb_post";
            this.gb_post.Size = new System.Drawing.Size(261, 489);
            this.gb_post.TabIndex = 1;
            this.gb_post.TabStop = false;
            this.gb_post.Text = "Postcodes";
            // 
            // pb_search
            // 
            this.pb_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.pb_search.Image = ((System.Drawing.Image)(resources.GetObject("pb_search.Image")));
            this.pb_search.Location = new System.Drawing.Point(557, 11);
            this.pb_search.Name = "pb_search";
            this.pb_search.Size = new System.Drawing.Size(59, 31);
            this.pb_search.TabIndex = 11;
            this.pb_search.Text = "r";
            this.pb_search.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pb_search.Click += new System.EventHandler(this.pb_search_clicked);
            // 
            // dw_interest
            // 
            this.dw_interest.FireConstructor = true;
            this.dw_interest.Location = new System.Drawing.Point(291, 279);
            this.dw_interest.Name = "dw_interest";
            this.dw_interest.Size = new System.Drawing.Size(239, 150);
            this.dw_interest.TabIndex = 9;
            this.dw_interest.Click += new System.EventHandler(this.dw_interest_clicked);
            // 
            // rb_specific
            // 
            this.rb_specific.BackColor = System.Drawing.SystemColors.Control;
            this.rb_specific.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rb_specific.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rb_specific.Location = new System.Drawing.Point(15, 33);//(28, 67);
            this.rb_specific.Name = "rb_specific";
            this.rb_specific.Size = new System.Drawing.Size(130, 19);
            this.rb_specific.TabIndex = 12;
            this.rb_specific.Checked = true;  //jlwang  11/16/2007
            this.rb_specific.Text = "Specific postcode ( s)";
            this.rb_specific.UseVisualStyleBackColor = false;
            this.rb_specific.Click += new System.EventHandler(this.rb_specific_clicked);
            // 
            // rb_nation
            // 
            this.rb_nation.BackColor = System.Drawing.SystemColors.Control;
            this.rb_nation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rb_nation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rb_nation.Location = new System.Drawing.Point(15, 15);//(28, 49);
            this.rb_nation.Name = "rb_nation";
            this.rb_nation.Size = new System.Drawing.Size(84, 19);
            this.rb_nation.TabIndex = 13;
            this.rb_nation.Text = "Nation-wide";
            this.rb_nation.UseVisualStyleBackColor = false;
            this.rb_nation.Click += new System.EventHandler(this.rb_nation_clicked);
            // 
            // dw_occupation
            // 
            this.dw_occupation.FireConstructor = true;
            this.dw_occupation.Location = new System.Drawing.Point(291, 50);
            this.dw_occupation.Name = "dw_occupation";
            this.dw_occupation.Size = new System.Drawing.Size(239, 177);
            this.dw_occupation.TabIndex = 10;
            this.dw_occupation.Click += new System.EventHandler(this.dw_occupation_clicked);
            // 
            // sle_move_in_1
            // 
            this.sle_move_in_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sle_move_in_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sle_move_in_1.Location = new System.Drawing.Point(401, 460);
            this.sle_move_in_1.Name = "sle_move_in_1";
            this.sle_move_in_1.Size = new System.Drawing.Size(97, 20);
            this.sle_move_in_1.TabIndex = 6;
            this.sle_move_in_1.Text = "01/01/1995";
            // 
            // sle_move_in_2
            // 
            this.sle_move_in_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sle_move_in_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sle_move_in_2.Location = new System.Drawing.Point(401, 490);
            this.sle_move_in_2.Name = "sle_move_in_2";
            this.sle_move_in_2.Size = new System.Drawing.Size(97, 20);
            this.sle_move_in_2.TabIndex = 7;
            this.sle_move_in_2.Text = "00/00/0000";
            // 
            // dw_post
            // 
            this.dw_post.FireConstructor = true;
            this.dw_post.Location = new System.Drawing.Point(46, 86);
            this.dw_post.Name = "dw_post";
            this.dw_post.Size = new System.Drawing.Size(222, 430);
            this.dw_post.TabIndex = 3;
            this.dw_post.Click += new System.EventHandler(this.dw_post_clicked);
            // 
            // gb_occupations
            // 
            this.gb_occupations.BackColor = System.Drawing.SystemColors.Control;
            this.gb_occupations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_occupations.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_occupations.Location = new System.Drawing.Point(282, 35);
            this.gb_occupations.Name = "gb_occupations";
            this.gb_occupations.Size = new System.Drawing.Size(257, 200);
            this.gb_occupations.TabIndex = 8;
            this.gb_occupations.TabStop = false;
            this.gb_occupations.Text = "Occupations";
            // 
            // gb_interests
            // 
            this.gb_interests.BackColor = System.Drawing.SystemColors.Control;
            this.gb_interests.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_interests.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_interests.Location = new System.Drawing.Point(283, 266);
            this.gb_interests.Name = "gb_interests";
            this.gb_interests.Size = new System.Drawing.Size(257, 170);
            this.gb_interests.TabIndex = 5;
            this.gb_interests.TabStop = false;
            this.gb_interests.Text = "Interests and Activities";
            // 
            // st_background
            // 
            this.st_background.BackColor = System.Drawing.SystemColors.Control;
            this.st_background.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_background.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_background.Location = new System.Drawing.Point(5, 11);
            this.st_background.Name = "st_background";
            this.st_background.Size = new System.Drawing.Size(544, 523);
            this.st_background.TabIndex = 17;
            // 
            // st_criteria
            // 
            this.st_criteria.BackColor = System.Drawing.SystemColors.Control;
            this.st_criteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.st_criteria.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_criteria.Location = new System.Drawing.Point(26, 15);
            this.st_criteria.Name = "st_criteria";
            this.st_criteria.Size = new System.Drawing.Size(100, 19);
            this.st_criteria.TabIndex = 14;
            this.st_criteria.Text = "Export Criteria";
            // 
            // dw_export
            // 
            this.dw_export.Enabled = false;
            this.dw_export.FireConstructor = true;
            this.dw_export.Location = new System.Drawing.Point(746, 47);
            this.dw_export.Name = "dw_export";
            this.dw_export.Size = new System.Drawing.Size(70, 69);
            this.dw_export.TabIndex = 2;
            this.dw_export.Visible = false;
            // 
            // st_between
            // 
            this.st_between.BackColor = System.Drawing.SystemColors.Control;
            this.st_between.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_between.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_between.Location = new System.Drawing.Point(321, 465);
            this.st_between.Name = "st_between";
            this.st_between.Size = new System.Drawing.Size(54, 19);
            this.st_between.TabIndex = 15;
            this.st_between.Text = "Between";
            this.st_between.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // st_and
            // 
            this.st_and.BackColor = System.Drawing.SystemColors.Control;
            this.st_and.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_and.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_and.Location = new System.Drawing.Point(321, 492);
            this.st_and.Name = "st_and";
            this.st_and.Size = new System.Drawing.Size(54, 19);
            this.st_and.TabIndex = 16;
            this.st_and.Text = "And";
            this.st_and.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb_1
            // 
            this.cb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.cb_1.Location = new System.Drawing.Point(557, 55);
            this.cb_1.Name = "cb_1";
            this.cb_1.Size = new System.Drawing.Size(59, 31);
            this.cb_1.TabIndex = 3;
            this.cb_1.Text = "Clear";
            this.cb_1.Click += new System.EventHandler(this.cb_1_clicked);
            // 
            // rb_and
            // 
            this.rb_and.AutoSize = true;
            this.rb_and.Checked = true;
            this.rb_and.Location = new System.Drawing.Point(375, 243);
            this.rb_and.Name = "rb_and";
            this.rb_and.Size = new System.Drawing.Size(44, 17);
            this.rb_and.TabIndex = 18;
            this.rb_and.TabStop = true;
            this.rb_and.Text = "And";
            this.rb_and.UseVisualStyleBackColor = true;
            // 
            // rb_or
            // 
            this.rb_or.AutoSize = true;
            this.rb_or.Location = new System.Drawing.Point(432, 243);
            this.rb_or.Name = "rb_or";
            this.rb_or.Size = new System.Drawing.Size(36, 17);
            this.rb_or.TabIndex = 19;
            this.rb_or.TabStop = true;
            this.rb_or.Text = "Or";
            this.rb_or.UseVisualStyleBackColor = true;
            // 
            // WMailingListSearch
            // 
            this.AcceptButton = this.pb_search;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(625, 561);
            this.Controls.Add(this.pb_search);
            this.Controls.Add(this.dw_interest);
            //this.Controls.Add(this.rb_specific);
            //this.Controls.Add(this.rb_nation);
            this.gb_post.Controls.Add(this.rb_specific);
            this.gb_post.Controls.Add(this.rb_nation);

            this.Controls.Add(this.rb_or);
            this.Controls.Add(this.rb_and);
            this.Controls.Add(this.dw_occupation);
            this.Controls.Add(this.sle_move_in_1);
            this.Controls.Add(this.sle_move_in_2);
            this.Controls.Add(this.dw_post);
            this.Controls.Add(this.st_criteria);
            this.Controls.Add(this.dw_export);
            this.Controls.Add(this.st_between);
            this.Controls.Add(this.st_and);
            this.Controls.Add(this.cb_1);
            this.Controls.Add(this.gb_move);
            this.Controls.Add(this.gb_post);
            this.Controls.Add(this.gb_occupations);
            this.Controls.Add(this.gb_interests);
            this.Controls.Add(this.st_background);
            this.MaximizeBox = false;
            this.Name = "WMailingListSearch";
            this.Text = "Marketing Customer Mailing List";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WMailingListSearch_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WMailingListSearch_KeyDown);
            this.Controls.SetChildIndex(this.st_background, 0);
            this.Controls.SetChildIndex(this.gb_interests, 0);
            this.Controls.SetChildIndex(this.gb_occupations, 0);

            this.Controls.SetChildIndex(this.gb_post, 0);
            this.Controls.SetChildIndex(this.gb_move, 0);
            this.Controls.SetChildIndex(this.cb_1, 0);
            this.Controls.SetChildIndex(this.st_and, 0);
            this.Controls.SetChildIndex(this.st_between, 0);
            this.Controls.SetChildIndex(this.dw_export, 0);
            this.Controls.SetChildIndex(this.st_criteria, 0);
            this.Controls.SetChildIndex(this.dw_post, 0);
            this.Controls.SetChildIndex(this.sle_move_in_2, 0);
            this.Controls.SetChildIndex(this.sle_move_in_1, 0);
            this.Controls.SetChildIndex(this.dw_occupation, 0);
            this.Controls.SetChildIndex(this.rb_and, 0);
            this.Controls.SetChildIndex(this.rb_or, 0);
            //?this.Controls.SetChildIndex(this.rb_nation, 0);
            //?this.Controls.SetChildIndex(this.rb_specific, 0);


            this.Controls.SetChildIndex(this.dw_interest, 0);
            this.Controls.SetChildIndex(this.pb_search, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Methods
        private bool KeyShift = false;

        private int of_build_post()
        {
            //  Build up the string for post codes
            string ls_post_temp;
            int ll_post_count;
            if (rb_nation.Checked == true)
            {
                is_post = null;
                return 1;
            }
            else
            {
                bool lb_first = true;
                ls_post_temp = " ( ";
                ll_post_count = dw_post.RowCount;
                int ll_selectedrow;
                ll_selectedrow = 0;
                ll_selectedrow = dw_post.GetSelectedRow(ll_selectedrow);
                // set post criteria to null if no rows selected
                if (ll_selectedrow == -1)
                {
                    is_post = null;
                    return 1;
                }
                for (int i = 0; i < ((DPostCriteria)dw_post.DataObject).PostGrid.SelectedRows.Count; i++) //while (ll_selectedrow != -1){--add mkwang 07/08/2007
                {
                    if (lb_first)
                    {
                        ls_post_temp = ls_post_temp + dw_post.GetItem<PostCriteria>(ll_selectedrow).PostId.GetValueOrDefault().ToString();
                        lb_first = false;
                    }
                    else
                    {
                        ls_post_temp = ls_post_temp + "," + dw_post.GetItem<PostCriteria>(ll_selectedrow).PostId.GetValueOrDefault().ToString();
                    }
                    ll_selectedrow = ((DPostCriteria)dw_post.DataObject).PostGrid.SelectedRows[i].Index;// dw_post.GetSelectedRow(ll_selectedrow);
                }
                ls_post_temp = ls_post_temp + " ) ";
                is_post = ls_post_temp;
            }
            return 1;
        }

        private int of_build_occ()
        {
            string ls_occ_temp;
            int ll_occ_count;
            bool lb_first = true;
            ls_occ_temp = " ( ";
            ll_occ_count = dw_occupation.RowCount;
            int ll_selectedrow;
            ll_selectedrow = 0;
            ll_selectedrow = dw_occupation.GetSelectedRow(ll_selectedrow);
            if (ll_selectedrow == -1)
            {
                is_occ = null;
                return 1;
            }
            for (int i = 0; i < ((DOccupationCriteria)dw_occupation.DataObject).OccupationGrid.SelectedRows.Count; i++) //while (ll_selectedrow != -1){--add mkwang 07/08/2007
            {
                if (lb_first)
                {
                    ls_occ_temp = ls_occ_temp + dw_occupation.GetItem<OccupationCriteria>(ll_selectedrow).OccId.GetValueOrDefault().ToString();
                    lb_first = false;
                }
                else
                {
                    ls_occ_temp = ls_occ_temp + "," + dw_occupation.GetItem<OccupationCriteria>(ll_selectedrow).OccId.GetValueOrDefault().ToString();
                }
                ll_selectedrow = ((DOccupationCriteria)dw_occupation.DataObject).OccupationGrid.SelectedRows[i].Index;//dw_occupation.GetSelectedRow(ll_selectedrow);
            }
            ls_occ_temp = ls_occ_temp + " ) ";
            is_occ = ls_occ_temp;
            return 1;
        }

        private int of_build_interest()
        {
            string ls_interest_temp;
            int ll_interest_count;
            bool lb_first = true;
            ls_interest_temp = " ( ";
            ll_interest_count = dw_interest.RowCount;
            int ll_selectedrow;
            ll_selectedrow = 0;
            ll_selectedrow = dw_interest.GetSelectedRow(ll_selectedrow);
            if (ll_selectedrow == -1)
            {
                is_interest = null;
                return 1;
            }
            for (int i = 0; i < ((DInterestCriteria)dw_interest.DataObject).InterestGrid.SelectedRows.Count; i++) //while (ll_selectedrow != -1){--add mkwang 07/08/2007
            {
                if (lb_first)
                {
                    ls_interest_temp = ls_interest_temp + dw_interest.GetItem<InterestCriteria>(ll_selectedrow).IntId.GetValueOrDefault().ToString();
                    lb_first = false;
                }
                else
                {
                    ls_interest_temp = ls_interest_temp + "," + dw_interest.GetItem<InterestCriteria>(ll_selectedrow).IntId.GetValueOrDefault().ToString();
                }
                ll_selectedrow = ((DInterestCriteria)dw_interest.DataObject).InterestGrid.SelectedRows[i].Index;//dw_interest.GetSelectedRow(ll_selectedrow);
            }
            ls_interest_temp = ls_interest_temp + " ) ";
            is_interest = ls_interest_temp;
            return 1;
        }

        private void dw_interest_constructor()
        {
            dw_interest.Retrieve();
            dw_interest.of_SetUpdateable(false);
            dw_interest.SelectAllRows(false);
        }

        private void dw_occupation_constructor()
        {
            dw_occupation.Retrieve();
            dw_occupation.of_SetUpdateable(false);
            dw_occupation.SelectAllRows(false);
        }

        private void dw_post_constructor()
        {
            dw_post.Retrieve();
            dw_post.of_SetUpdateable(false);
            dw_post.SelectAllRows(false);
        }

        private void sle_move_in_1_constructor()
        {
            //  TWC - 30/06/2003
            //  Setting the text of this to be the earliest move in date
            DateTime ld_move_in_early;
            //  get the contract title
            /*SELECT min ( date ( move_in_date)) INTO :ld_move_in_early FROM customer_address_moves WHERE move_out_date is null USING SQLCA;*/
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            ld_move_in_early = RDSDataService.GetCustomerAddressMovesMoveInDateMin(ref SQLCode, ref SQLErrText).GetValueOrDefault();
            if (SQLCode < 0)
            {
                MessageBox.Show(SQLErrText, "Error in database query", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            sle_move_in_1.Text = ld_move_in_early.ToString("dd/MM/yyyy");
        }

        private void sle_move_in_2_constructor()
        {
            sle_move_in_2.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }
        #endregion

        #region Events
        private void WMailingListSearch_KeyUp(object sender, KeyEventArgs e)
        {
            KeyShift = false;
        }

        private void WMailingListSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                KeyShift = true;
            }
            else
            {
                KeyShift = false;
            }
        }

        private void pb_search_clicked(object sender, EventArgs e)
        {
            DateTime? ld_inDate1;
            DateTime? ld_inDate2;
            int ll_exportcount;
            int ll_or;
            int li_response;
            of_build_post();
            of_build_occ();
            of_build_interest();
            //  form dates
            DateTime ld_temp;
            if (sle_move_in_1.Text.Length > 0 &&
                DateTime.TryParse(sle_move_in_1.Text,System.Globalization.CultureInfo.CreateSpecificCulture("en-NZ"),System.Globalization.DateTimeStyles.None, out ld_temp) == false ||
                sle_move_in_1.Text.Length > 0 &&
                DateTime.TryParse(sle_move_in_2.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-NZ"), System.Globalization.DateTimeStyles.None, out ld_temp) == false)//if (sle_move_in_1.Text.Length > 0 && IsDate(sle_move_in_1.Text) == false || sle_move_in_1.Text.Length > 0 && IsDate(sle_move_in_2.Text) == false) 
            {
                MessageBox.Show("Invalid dates entered. Enter valid dates or leave these fields blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (sle_move_in_1.Text.Length == 0)
            {
                ld_inDate1 = null;
            }
            else
            {
                ld_inDate1 = System.Convert.ToDateTime(sle_move_in_1.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-NZ"));
            }
            if (sle_move_in_2.Text.Length == 0)
            {
                ld_inDate2 = null;
            }
            else
            {
                ld_inDate2 = System.Convert.ToDateTime(sle_move_in_2.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-NZ"));
            }

            // TJB  SR4701  May 2007
            // If the OR radio button is checked, see whether there is anything to 
            // selected in both the Occupations and Interests.  If there's nothing 
            // selected in one or both of them, the 'or' makes no sense.  In this 
            // case, revert the search to an 'and' and tell the user why.
            //if rb_or.Checked.checked then 
            //    ll_or = 1 
            //    if isnull(is_occ) or isnull(is_interest) then
            //        ll_or = 0
            //        messagebox('Warning', &
            //                    "'Or'ing occupations and interests when one or both ~n" &
            //                    +"have no selected items doesn't make sense.  Reverting ~n" &
            //                    +"search to an 'And'." &
            //                    ,INFORMATION! )
            //        rb_and.checked = TRUE
            //    end if
            //else 
            //    ll_or = 0
            //end if
            if (rb_or.Checked)
            {
                ll_or = 1;
                if (string.IsNullOrEmpty(is_occ) || string.IsNullOrEmpty(is_interest))
                {
                    ll_or = 0;
                    MessageBox.Show("'Or'ing occupations and interests when one or both \n have no selected items doesn't make sense.  Reverting \n search to an 'And'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rb_and.Checked = true;
                }
            }
            else
            {
                ll_or = 0;
            }

            ((DMailListResult)dw_export.DataObject).Retrieve(is_post, is_occ, is_interest, ld_inDate1, ld_inDate2, ll_or);
            dw_export.of_SetUpdateable(false);
            ll_exportcount = dw_export.DataObject.RowCount;
            li_response = (MessageBox.Show(ll_exportcount.ToString() + " customer records found. Do you wish to export?", "Record Count", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 2);//MessageBox("Record Count", ll_exportcount.ToString() + " customer records found. Do you wish to export?", question!, yesno!);
            if (li_response == 1)
            {
                if (dw_export.SaveAs("", "CSV") == 1)
                {
                    MessageBox.Show("Customer Mailing List file exported successfully", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Export Failed", "Export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dw_interest_clicked(object sender, EventArgs e)
        {
            int ll_start;
            int ll_end;
            int ll_count;
            int row = dw_interest.GetRow();
            if (row >= 0)
            {
                //dw_interest.SelectRow(row,true/* !(dw_interest.IsSelected(row))*/);
            }
            if (KeyShift)//if (KeyDown(keyshift!))
            {
                //  only undertake the scrolling routine if the last row clicked was a real row number
                if (il_last_int_click == 0)
                {
                    il_last_int_click = row;
                }
                else
                {
                    //  do scroll select
                    if (il_last_int_click < row)
                    {
                        ll_start = il_last_int_click;
                        ll_end = row;
                    }
                    else
                    {
                        ll_start = row;
                        ll_end = il_last_int_click;
                    }
                    for (ll_count = ll_start; ll_count <= ll_end; ll_count++)
                    {
                        dw_interest.SelectRow(ll_count, true);
                    }
                    il_last_int_click = row;
                }
            }
            else
            {
                il_last_int_click = 0;
            }
        }

        private void rb_specific_clicked(object sender, EventArgs e)
        {
            //  select all rows
            //dw_post.SelectRow(0, false);
            dw_post.SelectAllRows(false);
            dw_occupation.SelectAllRows(false);
            dw_interest.SelectAllRows(false);
        }

        private void rb_nation_clicked(object sender, EventArgs e)
        {
            //  select all rows
            //dw_post.SelectRow(0, true);
            dw_post.SelectAllRows(true);
            //for (int i = 0; i < this.dw_post.RowCount; i++)
            //{
            //    dw_post.SelectRow(i, true);
            //}
        }

        private void dw_occupation_clicked(object sender, EventArgs e)
        {
            int ll_start;
            int ll_end;
            int ll_count;
            int row = dw_occupation.GetRow();
            if (row >= 0)
            {
                //dw_occupation.SelectRow(row, !(dw_occupation.IsSelected(row)));
            }
            if (KeyShift) //if (KeyDown(keyshift!)) {
            {
                //  only undertake the scrolling routine if the last row clicked was a real row number
                if (il_last_occ_click == 0)
                {
                    il_last_occ_click = row;
                }
                else
                {
                    //  do scroll select
                    if (il_last_occ_click < row)
                    {
                        ll_start = il_last_occ_click;
                        ll_end = row;
                    }
                    else
                    {
                        ll_start = row;
                        ll_end = il_last_occ_click;
                    }
                    for (ll_count = ll_start; ll_count <= ll_end; ll_count++)
                    {
                        dw_occupation.SelectRow(ll_count, true);
                    }
                    il_last_occ_click = row;
                }
            }
            else
            {
                il_last_occ_click = 0;
            }
        }

        private void dw_post_clicked(object sender, EventArgs e)
        {
            int ll_start;
            int ll_end;
            int ll_count;
            int row = dw_post.GetRow();
            if (row >= 0)
            {
                //dw_post.SelectRow(row + 1, !(dw_post.IsSelected(row)));
            }
            if (KeyShift) //if (KeyDown(keyshift!)) {
            {
                //  only undertake the scrolling routine if the last row clicked was a real row number
                if (il_last_post_click == 0)
                {
                    il_last_post_click = row;
                }
                else
                {
                    //  do scroll select
                    if (il_last_post_click < row)
                    {
                        ll_start = il_last_post_click;
                        ll_end = row;
                    }
                    else
                    {
                        ll_start = row;
                        ll_end = il_last_post_click;
                    }
                    for (ll_count = ll_start; ll_count <= ll_end; ll_count++)
                    {
                        dw_post.SelectRow(ll_count, true);
                    }
                    il_last_post_click = row;
                }
            }
            else
            {
                il_last_post_click = 0;
            }
        }

        private void cb_1_clicked(object sender, EventArgs e)
        {
            this.dw_occupation.SelectRow(0, false);
            this.dw_interest.SelectRow(0, false);
            this.rb_specific.Checked = true;
            this.dw_post.SelectRow(0, false);
        }

        #endregion
    }
}
