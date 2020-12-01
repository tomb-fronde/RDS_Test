using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;
using System;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DRouteFrequency2
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

        private System.Windows.Forms.Label sf_description_t;
        private System.Windows.Forms.Label rf_active_t;
        private System.Windows.Forms.Label rf_Monday_t;
        private System.Windows.Forms.Label rf_tuesday_t;
        private System.Windows.Forms.Label rf_wednesday_t;
        private System.Windows.Forms.Label rf_thursday_t;
        private System.Windows.Forms.Label rf_friday_t;
        private System.Windows.Forms.Label rf_saturday_t;
        private System.Windows.Forms.Label rf_sunday_t;
        private System.Windows.Forms.Label rf_distance_t;
        private System.Windows.Forms.Label adjusted_t;
        private System.Windows.Forms.Label st_contract;
        private TableLayoutPanel tbPanel;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sf_description_t = new System.Windows.Forms.Label();
            this.rf_active_t = new System.Windows.Forms.Label();
            this.rf_Monday_t = new System.Windows.Forms.Label();
            this.rf_tuesday_t = new System.Windows.Forms.Label();
            this.rf_wednesday_t = new System.Windows.Forms.Label();
            this.rf_thursday_t = new System.Windows.Forms.Label();
            this.rf_friday_t = new System.Windows.Forms.Label();
            this.rf_saturday_t = new System.Windows.Forms.Label();
            this.rf_sunday_t = new System.Windows.Forms.Label();
            this.rf_distance_t = new System.Windows.Forms.Label();
            this.adjusted_t = new System.Windows.Forms.Label();
            this.st_contract = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RouteFrequency2);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // tbPanel
            // 
            this.tbPanel.AutoScroll = true;
            this.tbPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbPanel.ColumnCount = 1;
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel.Location = new System.Drawing.Point(0, 34);
            this.tbPanel.Name = "tbPanel";
            this.tbPanel.RowCount = 1;
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel.Size = new System.Drawing.Size(534, 218);
            this.tbPanel.TabIndex = 1;
            // 
            // sf_description_t
            // 
            this.sf_description_t.BackColor = System.Drawing.SystemColors.Control;
            this.sf_description_t.Location = new System.Drawing.Point(8, 18);
            this.sf_description_t.Name = "sf_description_t";
            this.sf_description_t.Size = new System.Drawing.Size(128, 14);
            this.sf_description_t.TabIndex = 2;
            this.sf_description_t.Text = "Route Frequencies        ";
            this.sf_description_t.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // rf_active_t
            // 
            this.rf_active_t.BackColor = System.Drawing.SystemColors.Control;
            this.rf_active_t.Location = new System.Drawing.Point(141, 18);
            this.rf_active_t.Name = "rf_active_t";
            this.rf_active_t.Size = new System.Drawing.Size(38, 14);
            this.rf_active_t.TabIndex = 3;
            this.rf_active_t.Text = "Active";
            this.rf_active_t.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // rf_Monday_t
            // 
            this.rf_Monday_t.BackColor = System.Drawing.SystemColors.Control;
            this.rf_Monday_t.Location = new System.Drawing.Point(184, 18);
            this.rf_Monday_t.Name = "rf_Monday_t";
            this.rf_Monday_t.Size = new System.Drawing.Size(16, 14);
            this.rf_Monday_t.TabIndex = 4;
            this.rf_Monday_t.Text = "M";
            this.rf_Monday_t.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // rf_tuesday_t
            // 
            this.rf_tuesday_t.BackColor = System.Drawing.SystemColors.Control;
            this.rf_tuesday_t.Location = new System.Drawing.Point(204, 18);
            this.rf_tuesday_t.Name = "rf_tuesday_t";
            this.rf_tuesday_t.Size = new System.Drawing.Size(16, 14);
            this.rf_tuesday_t.TabIndex = 5;
            this.rf_tuesday_t.Text = "T";
            this.rf_tuesday_t.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // rf_wednesday_t
            // 
            this.rf_wednesday_t.BackColor = System.Drawing.SystemColors.Control;
            this.rf_wednesday_t.Location = new System.Drawing.Point(224, 18);
            this.rf_wednesday_t.Name = "rf_wednesday_t";
            this.rf_wednesday_t.Size = new System.Drawing.Size(16, 14);
            this.rf_wednesday_t.TabIndex = 6;
            this.rf_wednesday_t.Text = "W";
            this.rf_wednesday_t.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // rf_thursday_t
            // 
            this.rf_thursday_t.BackColor = System.Drawing.SystemColors.Control;
            this.rf_thursday_t.Location = new System.Drawing.Point(244, 18);
            this.rf_thursday_t.Name = "rf_thursday_t";
            this.rf_thursday_t.Size = new System.Drawing.Size(16, 14);
            this.rf_thursday_t.TabIndex = 7;
            this.rf_thursday_t.Text = "T";
            this.rf_thursday_t.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // rf_friday_t
            // 
            this.rf_friday_t.BackColor = System.Drawing.SystemColors.Control;
            this.rf_friday_t.Location = new System.Drawing.Point(264, 18);
            this.rf_friday_t.Name = "rf_friday_t";
            this.rf_friday_t.Size = new System.Drawing.Size(16, 14);
            this.rf_friday_t.TabIndex = 8;
            this.rf_friday_t.Text = "F";
            this.rf_friday_t.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // rf_saturday_t
            // 
            this.rf_saturday_t.BackColor = System.Drawing.SystemColors.Control;
            this.rf_saturday_t.Location = new System.Drawing.Point(284, 18);
            this.rf_saturday_t.Name = "rf_saturday_t";
            this.rf_saturday_t.Size = new System.Drawing.Size(16, 14);
            this.rf_saturday_t.TabIndex = 9;
            this.rf_saturday_t.Text = "S";
            this.rf_saturday_t.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // rf_sunday_t
            // 
            this.rf_sunday_t.BackColor = System.Drawing.SystemColors.Control;
            this.rf_sunday_t.Location = new System.Drawing.Point(304, 18);
            this.rf_sunday_t.Name = "rf_sunday_t";
            this.rf_sunday_t.Size = new System.Drawing.Size(16, 13);
            this.rf_sunday_t.TabIndex = 10;
            this.rf_sunday_t.Text = "S";
            // 
            // rf_distance_t
            // 
            this.rf_distance_t.BackColor = System.Drawing.SystemColors.Control;
            this.rf_distance_t.Location = new System.Drawing.Point(326, 18);
            this.rf_distance_t.Name = "rf_distance_t";
            this.rf_distance_t.Size = new System.Drawing.Size(50, 14);
            this.rf_distance_t.TabIndex = 11;
            this.rf_distance_t.Text = "Distance";
            this.rf_distance_t.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // adjusted_t
            // 
            this.adjusted_t.BackColor = System.Drawing.SystemColors.Control;
            this.adjusted_t.Location = new System.Drawing.Point(376, 18);
            this.adjusted_t.Name = "adjusted_t";
            this.adjusted_t.Size = new System.Drawing.Size(150, 14);
            this.adjusted_t.TabIndex = 12;
            this.adjusted_t.Text = "Adjusted in Current Renewal";
            this.adjusted_t.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // st_contract
            // 
            this.st_contract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_contract.Location = new System.Drawing.Point(0, 0);
            this.st_contract.Name = "st_contract";
            this.st_contract.Size = new System.Drawing.Size(533, 14);
            this.st_contract.TabIndex = 13;
            this.st_contract.Text = "text";
            // 
            // DRouteFrequency2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.adjusted_t);
            this.Controls.Add(this.rf_distance_t);
            this.Controls.Add(this.rf_sunday_t);
            this.Controls.Add(this.rf_saturday_t);
            this.Controls.Add(this.rf_friday_t);
            this.Controls.Add(this.rf_thursday_t);
            this.Controls.Add(this.rf_wednesday_t);
            this.Controls.Add(this.rf_tuesday_t);
            this.Controls.Add(this.rf_Monday_t);
            this.Controls.Add(this.rf_active_t);
            this.Controls.Add(this.sf_description_t);
            this.Controls.Add(this.st_contract);
            this.Controls.Add(this.tbPanel);
            this.Name = "DRouteFrequency2";
            this.Size = new System.Drawing.Size(536, 252);
            this.RetrieveStart += new Metex.Windows.RetrieveEventHandler(this.DRouteFrequency2_RetrieveStart);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        void DRouteFrequency2_RetrieveStart(object sender, Metex.Windows.RetrieveEventArgs e)
        {
            tbPanel.Controls.Clear();
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (this.RowCount == 0)
            {
                tbPanel.Controls.Clear();
                return;
            }

            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemDeleted)
            {
                
                for (int i = 0; i < tbPanel.Controls.Count; i++)
                {
                    if  (this.BindingSource.List.IndexOf(((DRouteFrequency2Rows)tbPanel.Controls[i]).DataSource) < 0)
                    {
                        tbPanel.Controls.RemoveAt(i);
                        break;
                    }
                }
            }
            else if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemAdded)
            {
                DRouteFrequency2Rows ldw_temp;
                ldw_temp = new DRouteFrequency2Rows();
                ldw_temp.Name = (e.NewIndex).ToString();
                ldw_temp.Size = new System.Drawing.Size(500, 50);
                ldw_temp.BindingSource.DataSource = this.BindingSource.List[e.NewIndex];
                ldw_temp.DoubleClick += new System.EventHandler(ldw_temp_DoubleClick);
                ldw_temp.Click += new System.EventHandler(ldw_temp_Click);
                //ldw_temp.TextBoxLostFocus += new System.EventHandler(ldw_temp_TextBoxLostFocus);
                this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                tbPanel.SetRow(ldw_temp, e.NewIndex);
                tbPanel.Controls.Add(ldw_temp, 0, e.NewIndex);
            }
        }

        public event EventHandler TextBoxLostFocus;

        void ldw_temp_TextBoxLostFocus(object sender, System.EventArgs e)
        {
            TextBoxLostFocus(sender, e);
        }

        private void clearBackColour( object prevSender )
        {
            if (!(prevSender == null))
            {
                this.SetCurrent(this.bindingSource.List.IndexOf(((DRouteFrequency2Rows)prevSender).BindingSource.DataSource as RouteFrequency2));
                ((DRouteFrequency2Rows)prevSender).BackColor = System.Drawing.SystemColors.ButtonFace;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("distance").BackColor = System.Drawing.SystemColors.Control;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("rf_nms").BackColor = System.Drawing.SystemColors.Control;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("rf_nms_t").BackColor = System.Drawing.Color.Empty;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("rf_dpcount").BackColor = System.Drawing.SystemColors.Control;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("rf_dpcount_t").BackColor = System.Drawing.Color.Empty;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("rf_vehicle_name_t").BackColor = System.Drawing.Color.Empty;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("vehicle_number").BackColor = System.Drawing.Color.Empty;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("rf_adjusted").BackColor = System.Drawing.SystemColors.Control;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("sf_key").BackColor = System.Drawing.Color.Empty;

                ((DRouteFrequency2Rows)prevSender).GetControlByName("distance").ForeColor = System.Drawing.Color.Black;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("rf_nms").ForeColor = System.Drawing.Color.Black;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("rf_nms_t").ForeColor = System.Drawing.Color.Black;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("rf_dpcount").ForeColor = System.Drawing.Color.Black;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("rf_dpcount_t").ForeColor = System.Drawing.Color.Black;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("rf_vehicle_name_t").ForeColor = System.Drawing.Color.Black;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("vehicle_number").ForeColor = System.Drawing.Color.Black;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("rf_adjusted").ForeColor = System.Drawing.Color.Black;
                ((DRouteFrequency2Rows)prevSender).GetControlByName("sf_key").ForeColor = System.Drawing.Color.Black;
            }
        }

        private int thisSenderIndex, prevSenderIndex;  // TJB used during debugging to see which row sender refers to
        private object prevSender;

        void ldw_temp_Click(object sender, System.EventArgs e)
        {
            // On Click, set the colours of the frequency to Highlight with
            // White text.  ClearBackColour is called to unset the highlighting
            // of any frequencies that have been highlighted previously.
            //
            // Note: rf_<weekdays> (rf_Sunday etc) and rf_active aren't mentioned
            //       here for colour changing, as they don't seem to be affected 
            //       by setting their BackColor and ForeColor properties.
            thisSenderIndex = this.bindingSource.List.IndexOf(((DRouteFrequency2Rows)sender).BindingSource.DataSource as RouteFrequency2);
            this.SetCurrent(this.bindingSource.List.IndexOf(((DRouteFrequency2Rows)sender).BindingSource.DataSource as RouteFrequency2));
            clearBackColour(prevSender);
            prevSender = sender;
            prevSenderIndex = thisSenderIndex;
            ((DRouteFrequency2Rows)sender).BackColor = System.Drawing.SystemColors.Highlight;
            ((DRouteFrequency2Rows)sender).GetControlByName("distance").BackColor = System.Drawing.SystemColors.Highlight;
            ((DRouteFrequency2Rows)sender).GetControlByName("rf_nms").BackColor = System.Drawing.SystemColors.Highlight;
            ((DRouteFrequency2Rows)sender).GetControlByName("rf_nms_t").BackColor = System.Drawing.SystemColors.Highlight;
            ((DRouteFrequency2Rows)sender).GetControlByName("rf_dpcount").BackColor = System.Drawing.SystemColors.Highlight;
            ((DRouteFrequency2Rows)sender).GetControlByName("rf_dpcount_t").BackColor = System.Drawing.SystemColors.Highlight;
            ((DRouteFrequency2Rows)sender).GetControlByName("rf_vehicle_name_t").BackColor = System.Drawing.SystemColors.Highlight;
            ((DRouteFrequency2Rows)sender).GetControlByName("vehicle_number").BackColor = System.Drawing.SystemColors.Highlight;
            ((DRouteFrequency2Rows)sender).GetControlByName("rf_adjusted").BackColor = System.Drawing.SystemColors.Highlight;
            ((DRouteFrequency2Rows)sender).GetControlByName("sf_key").BackColor = System.Drawing.SystemColors.Highlight;

            ((DRouteFrequency2Rows)sender).GetControlByName("distance").ForeColor = System.Drawing.Color.White;
            ((DRouteFrequency2Rows)sender).GetControlByName("rf_nms").ForeColor = System.Drawing.Color.White;
            ((DRouteFrequency2Rows)sender).GetControlByName("rf_nms_t").ForeColor = System.Drawing.Color.White;
            ((DRouteFrequency2Rows)sender).GetControlByName("rf_dpcount").ForeColor = System.Drawing.Color.White;
            ((DRouteFrequency2Rows)sender).GetControlByName("rf_dpcount_t").ForeColor = System.Drawing.Color.White;
            ((DRouteFrequency2Rows)sender).GetControlByName("rf_vehicle_name_t").ForeColor = System.Drawing.Color.White;
            ((DRouteFrequency2Rows)sender).GetControlByName("vehicle_number").ForeColor = System.Drawing.Color.White;
            ((DRouteFrequency2Rows)sender).GetControlByName("rf_adjusted").ForeColor = System.Drawing.Color.White;
            ((DRouteFrequency2Rows)sender).GetControlByName("sf_key").ForeColor = System.Drawing.Color.White;

            OnClick(new System.EventArgs());
        }

        void ldw_temp_DoubleClick(object sender, System.EventArgs e)
        {
            // (TJB) I'd never have guessed that OnDoubleClick here would somehow 
            //       link to dw_route_frequency2_DoubleClick in WContract2001!  
            //       Derived from DContractArticleCountsTest
            OnDoubleClick(new System.EventArgs());
        }

        void DRouteFrequency2Rows_RetrieveEnd(object sender, System.EventArgs e)
        {
            for (int i = 0; i < this.RowCount; i++)
            {
                DRouteFrequency2Rows ldw_temp;
                ldw_temp = new DRouteFrequency2Rows();
                ldw_temp.Name = i.ToString();
                ldw_temp.Size = new System.Drawing.Size(500, 140);
                ldw_temp.BindingSource.DataSource = this.BindingSource.List[i];
                this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                tbPanel.SetRow(ldw_temp, i);
                tbPanel.Controls.Add(ldw_temp, 0, i);
            }
        }

        #endregion
    }
}
