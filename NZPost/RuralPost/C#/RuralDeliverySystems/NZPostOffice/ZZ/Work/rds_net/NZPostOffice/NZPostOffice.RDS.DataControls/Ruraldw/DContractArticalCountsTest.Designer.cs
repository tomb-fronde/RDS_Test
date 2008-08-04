using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractArticalCounts
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.t_1 = new System.Windows.Forms.Label();
            this.t_2 = new System.Windows.Forms.Label();
            this.st_contract = new System.Windows.Forms.Label();
            this.t_4 = new System.Windows.Forms.Label();
            this.note = new System.Windows.Forms.Label();
            this.t_5 = new System.Windows.Forms.Label();
            this.t_6 = new System.Windows.Forms.Label();
            this.ac_w1_medium_letters_t = new System.Windows.Forms.Label();
            this.ac_w1_other_envelopes_t = new System.Windows.Forms.Label();
            this.t_11 = new System.Windows.Forms.Label();
            this.t_3 = new System.Windows.Forms.Label();
            this.t_10 = new System.Windows.Forms.Label();
            this.ac_w1_inward_mail_t = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.tbPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractArticalCounts);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // tbPanel
            // 
            this.tbPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPanel.BackColor = System.Drawing.SystemColors.Control;
            this.tbPanel.ColumnCount = 1;
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel.Location = new System.Drawing.Point(0, 45);
            this.tbPanel.Name = "tbPanel";
            this.tbPanel.RowCount = 1;
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel.Size = new System.Drawing.Size(520, 233);
            this.tbPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(520, 18);
            this.label1.TabIndex = 2;
            // 
            // t_1
            // 
            this.t_1.Font = new System.Drawing.Font("Arial", 8F);
            this.t_1.Location = new System.Drawing.Point(5, 22);
            this.t_1.Name = "t_1";
            this.t_1.Size = new System.Drawing.Size(51, 21);
            this.t_1.TabIndex = 0;
            this.t_1.Text = "Renewal";
            this.t_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t_2
            // 
            this.t_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_2.Location = new System.Drawing.Point(63, 22);
            this.t_2.Name = "t_2";
            this.t_2.Size = new System.Drawing.Size(85, 20);
            this.t_2.TabIndex = 0;
            this.t_2.Text = "Count Period";
            this.t_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // st_contract
            // 
            this.st_contract.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.st_contract.Location = new System.Drawing.Point(0, 0);
            this.st_contract.Name = "st_contract";
            this.st_contract.Size = new System.Drawing.Size(659, 12);
            this.st_contract.TabIndex = 0;
            this.st_contract.Text = "Contract No";
            this.st_contract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t_4
            // 
            this.t_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.t_4.Location = new System.Drawing.Point(5, 275);
            this.t_4.Name = "t_4";
            this.t_4.Size = new System.Drawing.Size(33, 13);
            this.t_4.TabIndex = 0;
            this.t_4.Text = "Note: ";
            this.t_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // note
            // 
            this.note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.note.Location = new System.Drawing.Point(51, 275);
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(497, 13);
            this.note.TabIndex = 0;
            this.note.Text = "Large Parcel items are not included in the Total Deliveries but are counted in th" +
                "e mailcounts.";
            this.note.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t_5
            // 
            this.t_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_5.Location = new System.Drawing.Point(158, 22);
            this.t_5.Name = "t_5";
            this.t_5.Size = new System.Drawing.Size(36, 20);
            this.t_5.TabIndex = 0;
            this.t_5.Text = "Week";
            this.t_5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_6
            // 
            this.t_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_6.Location = new System.Drawing.Point(200, 8);
            this.t_6.Name = "t_6";
            this.t_6.Size = new System.Drawing.Size(97, 20);
            this.t_6.TabIndex = 0;
            this.t_6.Text = "Letters";
            this.t_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ac_w1_medium_letters_t
            // 
            this.ac_w1_medium_letters_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_medium_letters_t.Location = new System.Drawing.Point(201, 22);
            this.ac_w1_medium_letters_t.Name = "ac_w1_medium_letters_t";
            this.ac_w1_medium_letters_t.Size = new System.Drawing.Size(45, 22);
            this.ac_w1_medium_letters_t.TabIndex = 0;
            this.ac_w1_medium_letters_t.Text = "Medium";
            this.ac_w1_medium_letters_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ac_w1_other_envelopes_t
            // 
            this.ac_w1_other_envelopes_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_other_envelopes_t.Location = new System.Drawing.Point(260, 22);
            this.ac_w1_other_envelopes_t.Name = "ac_w1_other_envelopes_t";
            this.ac_w1_other_envelopes_t.Size = new System.Drawing.Size(35, 22);
            this.ac_w1_other_envelopes_t.TabIndex = 0;
            this.ac_w1_other_envelopes_t.Text = "Other";
            this.ac_w1_other_envelopes_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_11
            // 
            this.t_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_11.Location = new System.Drawing.Point(303, 9);
            this.t_11.Name = "t_11";
            this.t_11.Size = new System.Drawing.Size(43, 33);
            this.t_11.TabIndex = 0;
            this.t_11.Text = "Small\r\nParcels";
            this.t_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // t_3
            // 
            this.t_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_3.Location = new System.Drawing.Point(351, 9);
            this.t_3.Name = "t_3";
            this.t_3.Size = new System.Drawing.Size(53, 33);
            this.t_3.TabIndex = 0;
            this.t_3.Text = "Total\r\nDeliveries";
            this.t_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // t_10
            // 
            this.t_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.t_10.Location = new System.Drawing.Point(410, 9);
            this.t_10.Name = "t_10";
            this.t_10.Size = new System.Drawing.Size(42, 33);
            this.t_10.TabIndex = 0;
            this.t_10.Text = "Large\t\nParcels";
            this.t_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ac_w1_inward_mail_t
            // 
            this.ac_w1_inward_mail_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ac_w1_inward_mail_t.Location = new System.Drawing.Point(462, 9);
            this.ac_w1_inward_mail_t.Name = "ac_w1_inward_mail_t";
            this.ac_w1_inward_mail_t.Size = new System.Drawing.Size(40, 33);
            this.ac_w1_inward_mail_t.TabIndex = 0;
            this.ac_w1_inward_mail_t.Text = "Inward\r\nMail";
            this.ac_w1_inward_mail_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(521, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(19, 290);
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.Visible = false;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // DContractArticalCounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPanel);
            this.Controls.Add(this.st_contract);
            this.Controls.Add(this.t_4);
            this.Controls.Add(this.note);
            this.Controls.Add(this.t_1);
            this.Controls.Add(this.t_2);
            this.Controls.Add(this.t_5);
            this.Controls.Add(this.t_6);
            this.Controls.Add(this.ac_w1_medium_letters_t);
            this.Controls.Add(this.ac_w1_other_envelopes_t);
            this.Controls.Add(this.t_11);
            this.Controls.Add(this.t_3);
            this.Controls.Add(this.t_10);
            this.Controls.Add(this.ac_w1_inward_mail_t);
            this.Name = "DContractArticalCounts";
            this.Size = new System.Drawing.Size(540, 290);
            this.RetrieveEnd += new System.EventHandler(this.DContractArticalCountsTest_RetrieveEnd);
            this.SizeChanged += new System.EventHandler(this.DContractArticalCounts_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.tbPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //this.tbPanel.ScrollControlIntoView(this.tbPanel.Controls[e.NewValue + 2]);
            this.tbPanel.VerticalScroll.Value = e.NewValue * 71;
        }

        void DContractArticalCounts_SizeChanged(object sender, System.EventArgs e)
        {
            //this.tbPanel.Width = this.Width - tbPanel.Left;
            //this.tbPanel.Height = this.Height - this.tbPanel.Top;
        }

        private int resultCount = 0;
        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (this.RowCount == 0)
            {
                return;
            }

            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemDeleted)
            {
                tbPanel.Controls.RemoveAt(e.NewIndex);
            }
            else if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemAdded)
            {
                DContractArticalCountsTest ldw_temp;
                ldw_temp = new DContractArticalCountsTest();
                ldw_temp.Name = (e.NewIndex).ToString();
                ldw_temp.Size = new System.Drawing.Size(500, 65);
                ldw_temp.BindingSource.DataSource = this.BindingSource.List[e.NewIndex];
                //((TextBox)(ldw_temp.GetControlByName("fa_fixed_asset_no"))).ReadOnly = false;
                ldw_temp.DoubleClick += new System.EventHandler(ldw_temp_DoubleClick);
                ldw_temp.Click += new System.EventHandler(ldw_temp_Click);
                ldw_temp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
                this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                tbPanel.SetRow(ldw_temp, e.NewIndex);
                tbPanel.Controls.Add(ldw_temp, 0, e.NewIndex);
                resultCount++;
            }
            else
            {
            }

            //HighlightCurrentRow(tbPanel.Controls[0]);
        }
        private void DefaultCurrentRow(Control contract)
        {
            contract.BackColor = System.Drawing.SystemColors.Control;
            foreach (Control c in contract.Controls)
            {
                c.BackColor = System.Drawing.SystemColors.Control;
                c.ForeColor = System.Drawing.Color.Black;
            }
        }
        
        private void clearBanckColor()                  //added by ygu
        {
            for (int i = 0; i < resultCount; i++)
            {
                if(((DContractArticalCountsTest)this.GetControlByName(i.ToString())).BackColor == System.Drawing.SystemColors.Highlight)
                {
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).BackColor = System.Drawing.SystemColors.ButtonFace;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w1_medium_letters").BackColor = System.Drawing.Color.Empty;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w1_other_envelopes").BackColor = System.Drawing.Color.Empty;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w1_small_parcels").BackColor = System.Drawing.Color.Empty;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w1_large_parcels").BackColor = System.Drawing.Color.Empty;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w1_inward_mail").BackColor = System.Drawing.Color.Empty;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w2_medium_letters").BackColor = System.Drawing.Color.Empty;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w2_other_envelopes").BackColor = System.Drawing.Color.Empty;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w2_small_parcels").BackColor = System.Drawing.Color.Empty;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w2_large_parcels").BackColor = System.Drawing.Color.Empty;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w2_inward_mail").BackColor = System.Drawing.Color.Empty;

                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w1_medium_letters").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w1_other_envelopes").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w1_small_parcels").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w1_large_parcels").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w1_inward_mail").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w2_medium_letters").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w2_other_envelopes").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w2_small_parcels").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w2_large_parcels").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_w2_inward_mail").ForeColor = System.Drawing.Color.Black;

                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("compute_1").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("ac_start_week_period").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("t_8").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("t_9").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("t_7").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("compute_6").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("compute_7").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("compute_3").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("compute_2").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("compute_4").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("compute_5").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("week1del").ForeColor = System.Drawing.Color.Black;
                    ((DContractArticalCountsTest)this.GetControlByName(i.ToString())).GetControlByName("week2del").ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        void ldw_temp_Click(object sender, System.EventArgs e)              //altered by ygu
        {
            this.SetCurrent(this.bindingSource.List.IndexOf(((DContractArticalCountsTest)sender).BindingSource.DataSource as ContractArticalCounts));
            clearBanckColor();
            ((DContractArticalCountsTest)sender).BackColor = System.Drawing.SystemColors.Highlight;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w1_medium_letters").BackColor = System.Drawing.SystemColors.Highlight;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w1_other_envelopes").BackColor = System.Drawing.SystemColors.Highlight;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w1_small_parcels").BackColor = System.Drawing.SystemColors.Highlight;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w1_large_parcels").BackColor = System.Drawing.SystemColors.Highlight;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w1_inward_mail").BackColor = System.Drawing.SystemColors.Highlight;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w2_medium_letters").BackColor = System.Drawing.SystemColors.Highlight;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w2_other_envelopes").BackColor = System.Drawing.SystemColors.Highlight;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w2_small_parcels").BackColor = System.Drawing.SystemColors.Highlight;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w2_large_parcels").BackColor = System.Drawing.SystemColors.Highlight;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w2_inward_mail").BackColor = System.Drawing.SystemColors.Highlight;

            ((DContractArticalCountsTest)sender).GetControlByName("ac_w1_medium_letters").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w1_other_envelopes").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w1_small_parcels").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w1_large_parcels").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w1_inward_mail").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w2_medium_letters").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w2_other_envelopes").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w2_small_parcels").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w2_large_parcels").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_w2_inward_mail").ForeColor = System.Drawing.Color.White;

            ((DContractArticalCountsTest)sender).GetControlByName("compute_1").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("ac_start_week_period").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("t_8").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("t_9").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("t_7").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("compute_6").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("compute_7").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("compute_3").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("compute_2").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("compute_4").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("compute_5").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("week1del").ForeColor = System.Drawing.Color.White;
            ((DContractArticalCountsTest)sender).GetControlByName("week2del").ForeColor = System.Drawing.Color.White;

        }

        private void DContractArticalCountsTest_RetrieveEnd(object sender, System.EventArgs e)
        {
            if (resultCount > 0)
            {
                ((DContractArticalCountsTest)this.GetControlByName("0")).BackColor = System.Drawing.SystemColors.Highlight;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w1_medium_letters").BackColor = System.Drawing.SystemColors.Highlight;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w1_other_envelopes").BackColor = System.Drawing.SystemColors.Highlight;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w1_small_parcels").BackColor = System.Drawing.SystemColors.Highlight;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w1_large_parcels").BackColor = System.Drawing.SystemColors.Highlight;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w1_inward_mail").BackColor = System.Drawing.SystemColors.Highlight;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w2_medium_letters").BackColor = System.Drawing.SystemColors.Highlight;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w2_other_envelopes").BackColor = System.Drawing.SystemColors.Highlight;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w2_small_parcels").BackColor = System.Drawing.SystemColors.Highlight;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w2_large_parcels").BackColor = System.Drawing.SystemColors.Highlight;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w2_inward_mail").BackColor = System.Drawing.SystemColors.Highlight;

                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w1_medium_letters").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w1_other_envelopes").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w1_small_parcels").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w1_large_parcels").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w1_inward_mail").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w2_medium_letters").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w2_other_envelopes").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w2_small_parcels").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w2_large_parcels").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_w2_inward_mail").ForeColor = System.Drawing.Color.White;

                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("compute_1").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("ac_start_week_period").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("t_8").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("t_9").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("t_7").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("compute_6").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("compute_7").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("compute_3").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("compute_2").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("compute_4").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("compute_5").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("week1del").ForeColor = System.Drawing.Color.White;
                ((DContractArticalCountsTest)this.GetControlByName("0")).GetControlByName("week2del").ForeColor = System.Drawing.Color.White;
            }

            //the setting of VerticalScroll of the tbPanel can not work
            //if (this.RowCount > 3)
            //{
            //    this.tbPanel.VerticalScroll.Visible = true;
            //    this.tbPanel.VerticalScroll.Maximum = this.RowCount;
            //    this.tbPanel.VerticalScroll.LargeChange = 3;
            //}
            if (this.RowCount > 3)
            {
                this.tbPanel.Width = 540;
                this.vScrollBar1.Visible = true;
                this.vScrollBar1.Maximum = this.RowCount - 1;
                this.vScrollBar1.LargeChange = 3;
                this.tbPanel.AutoScroll = true;
            }
            else
            {
                this.tbPanel.Width = 540;
                this.vScrollBar1.Visible = false;
            }
           
        }

        void ldw_temp_DoubleClick(object sender, System.EventArgs e)
        {
            OnDoubleClick(new System.EventArgs());
        }


        private TableLayoutPanel tbPanel;
        private System.Windows.Forms.Label st_contract;
        private System.Windows.Forms.Label t_4;
        private System.Windows.Forms.Label note;
        private System.Windows.Forms.Label t_1;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.Label t_5;
        private System.Windows.Forms.Label t_6;
        private System.Windows.Forms.Label ac_w1_medium_letters_t;
        private System.Windows.Forms.Label ac_w1_other_envelopes_t;
        private System.Windows.Forms.Label t_11;
        private System.Windows.Forms.Label t_3;
        private System.Windows.Forms.Label t_10;
        private System.Windows.Forms.Label ac_w1_inward_mail_t;
        #endregion
        private VScrollBar vScrollBar1;
        private Label label1;
    }
}
