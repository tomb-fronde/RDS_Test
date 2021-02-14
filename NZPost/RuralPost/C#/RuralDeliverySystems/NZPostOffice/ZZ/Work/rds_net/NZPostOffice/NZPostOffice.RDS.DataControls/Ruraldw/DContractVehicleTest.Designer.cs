using System.Windows.Forms;
using System;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    // TJB  Frequencies & Vehicles  Feb-2021
    // Added bits in an unsuccessful attempt to manipulate the vertivle scrollbar

    partial class DContractVehicle
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

        private System.Windows.Forms.Label st_title;
        private System.Windows.Forms.Label st_sysadmin;
        private System.Windows.Forms.Label st_active;
        private TableLayoutPanel tbPanel;
        private Label label1;
        private bool retrieve_end;

        public TableLayoutPanel TbPanel
        {
            get
            {
                return tbPanel;
            }
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.st_title = new System.Windows.Forms.Label();
            this.st_sysadmin = new System.Windows.Forms.Label();
            this.st_active = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPanel = new System.Windows.Forms.TableLayoutPanel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // st_title
            // 
            this.st_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            this.st_title.Location = new System.Drawing.Point(0, 4);
            this.st_title.Name = "st_title";
            this.st_title.Size = new System.Drawing.Size(577, 18);
            this.st_title.TabIndex = 0;
            this.st_title.Text = "test";
            // 
            // st_sysadmin
            // 
            this.st_sysadmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_sysadmin.Location = new System.Drawing.Point(469, 1);
            this.st_sysadmin.Name = "st_sysadmin";
            this.st_sysadmin.Size = new System.Drawing.Size(12, 13);
            this.st_sysadmin.TabIndex = 0;
            this.st_sysadmin.Text = "Y";
            this.st_sysadmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // st_active
            // 
            this.st_active.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_active.Location = new System.Drawing.Point(569, 1);
            this.st_active.Name = "st_active";
            this.st_active.Size = new System.Drawing.Size(12, 13);
            this.st_active.TabIndex = 0;
            this.st_active.Text = "N";
            this.st_active.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_active.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 20);
            this.label1.TabIndex = 0;
            // 
            // tbPanel
            // 
            this.tbPanel.AutoScroll = true;
            this.tbPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tbPanel.ColumnCount = 1;
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel.Location = new System.Drawing.Point(0, 20);
            this.tbPanel.Name = "tbPanel";
            this.tbPanel.RowCount = 1;
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel.Size = new System.Drawing.Size(565, 310);
            this.tbPanel.TabIndex = 1;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(560, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(19, 320);
            this.vScrollBar1.TabIndex = 0;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // DContractVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.st_title);
            this.Controls.Add(this.st_sysadmin);
            this.Controls.Add(this.st_active);
            this.Controls.Add(this.tbPanel);
            this.Name = "DContractVehicle";
            this.Size = new System.Drawing.Size(579, 320);
            this.RetrieveEnd += new System.EventHandler(this.DContractVehicle_RetrieveEnd);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //this.tbPanel.ScrollControlIntoView(this.tbPanel.Controls[e.NewValue + 2]);
            this.tbPanel.VerticalScroll.Value = e.NewValue * 308;
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (this.RowCount == 0)
            {
                this.tbPanel.Controls.Clear();
            }

            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemDeleted)
            {
                //tbPanel.Controls.RemoveAt(e.NewIndex);
                tbPanel.AutoSize = true;
                tbPanel.Controls.Clear();
                for (int i = 0; i < this.RowCount; i++)
                {
                    DContractVehicleTest ldw_temp;
                    ldw_temp = new DContractVehicleTest();
                    ldw_temp.Size = new System.Drawing.Size(500, 200);
                    ldw_temp.BindingSource.DataSource = this.BindingSource.List[i];

                    this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                    tbPanel.SetRow(ldw_temp, i);
                    tbPanel.Controls.Add(ldw_temp, 0, 0);
                }
            }
            else if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemAdded)
            {
                if (!retrieve_end)
                    return;
                this.tbPanel.Controls.Clear();
                for (int i = 0; i < this.RowCount; i++)
                {
                    DContractVehicleTest ldw_temp;
                    ldw_temp = new DContractVehicleTest();
                    ldw_temp.Name = (e.NewIndex).ToString();
                    ldw_temp.Size = new System.Drawing.Size(535, 300);
                    ldw_temp.BindingSource.DataSource = this.BindingSource.List[i];
                    ((Metex.Windows.DataEntityCombo)ldw_temp.GetControlByName("ft_key")).SelectedValueChanged += new System.EventHandler(DContractVehicle_SelectedValueChanged);
                    ldw_temp.GetControlByName("v_vehicle_registration_number").Leave += new System.EventHandler(DContractVehicle_Leave);
                    //ldw_temp.GetControlByName("cb_active").Leave += new System.EventHandler(DContractVehicle_cb_active_Leave);
                    ldw_temp.GetControlByName("cb_active").Click += new EventHandler(DContractVehicle_cb_active_Click);

                    if (st_sysadmin.Text != "Y")
                    {
                        if (ldw_temp.GetItem<NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle>(0).VVehicleTransmission == "A"
                            || ldw_temp.GetItem<NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle>(0).VVehicleTransmission == "M"
                            || this.Enabled == false)
                        {
                            ldw_temp.GetControlByName("radioButton1").Enabled = false;
                            ldw_temp.GetControlByName("radioButton2").Enabled = false;
                        }
                    }
                    else
                    {
                        ldw_temp.GetControlByName("radioButton1").Enabled = true;
                        ldw_temp.GetControlByName("radioButton2").Enabled = true;
                    }
                    if (st_sysadmin.Text != "Y")
                    {
                        if (ldw_temp.GetItem<NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle>(0).StartKms < 5000 || ldw_temp.GetItem<NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle>(0).StartKms == null
                            || this.Enabled == false || !ldw_temp.GetItem<NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle>(0).IsNew)
                        {
                            ldw_temp.GetControlByName("v_remaining_economic_life").Enabled = false;
                        }
                    }
                    else
                    {
                        ldw_temp.GetControlByName("v_remaining_economic_life").Enabled = true;
                    }
                    if (st_sysadmin.Text != "Y")
                    {
                        if (this.Enabled == false || !ldw_temp.GetItem<NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle>(0).IsNew)
                        {
                            ldw_temp.GetControlByName("v_vehicle_registration_number").Enabled = false;
                            ldw_temp.GetControlByName("vt_key").Enabled = false;
                            ldw_temp.GetControlByName("vs_key").Enabled = false;
                            ldw_temp.GetControlByName("v_vehicle_make").Enabled = false;
                            ldw_temp.GetControlByName("ft_key").Enabled = false;
                            ldw_temp.GetControlByName("v_purchased_date").Enabled = false;

                            ldw_temp.GetControlByName("v_vehicle_model").Enabled = false;
                            ldw_temp.GetControlByName("v_vehicle_year").Enabled = false;
                            ldw_temp.GetControlByName("v_vehicle_month").Enabled = false;
                            ldw_temp.GetControlByName("v_vehicle_cc_rating").Enabled = false;
                            ldw_temp.GetControlByName("v_purchase_value").Enabled = false;
                            ldw_temp.GetControlByName("v_salvage_value").Enabled = false;
                            ldw_temp.GetControlByName("contract_vehical_start_kms").Enabled = false;
                            ldw_temp.GetControlByName("v_leased").Enabled = false;
                            ldw_temp.GetControlByName("v_road_user_charges_indicator").Enabled = false;

                        }
                    }
                    else
                    {
                        ldw_temp.GetControlByName("v_vehicle_registration_number").Enabled = true;
                        ldw_temp.GetControlByName("vt_key").Enabled = true;
                        ldw_temp.GetControlByName("vs_key").Enabled = true;
                        ldw_temp.GetControlByName("v_vehicle_make").Enabled = true;
                        ldw_temp.GetControlByName("ft_key").Enabled = true;
                        ldw_temp.GetControlByName("v_purchased_date").Enabled = true;

                        ldw_temp.GetControlByName("v_vehicle_model").Enabled = true;
                        ldw_temp.GetControlByName("v_vehicle_year").Enabled = true;
                        ldw_temp.GetControlByName("v_vehicle_month").Enabled = true;
                        ldw_temp.GetControlByName("v_vehicle_cc_rating").Enabled = true;
                        ldw_temp.GetControlByName("v_purchase_value").Enabled = true;
                        ldw_temp.GetControlByName("v_salvage_value").Enabled = true;
                        ldw_temp.GetControlByName("contract_vehical_start_kms").Enabled = true;
                        ldw_temp.GetControlByName("v_leased").Enabled = true;
                        ldw_temp.GetControlByName("v_road_user_charges_indicator").Enabled = true;

                    }
                    if (this.Enabled == false || !ldw_temp.GetItem<NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle>(0).IsNew)
                    {
                        ldw_temp.GetControlByName("v_vehicle_registration_number").BackColor = System.Drawing.SystemColors.Control;
                        ldw_temp.GetControlByName("vt_key").BackColor = System.Drawing.SystemColors.Control;
                        ldw_temp.GetControlByName("vs_key").BackColor = System.Drawing.SystemColors.Control;
                        ldw_temp.GetControlByName("v_vehicle_make").BackColor = System.Drawing.SystemColors.Control;
                        ldw_temp.GetControlByName("ft_key").BackColor = System.Drawing.SystemColors.Control;
                        ldw_temp.GetControlByName("v_purchased_date").BackColor = System.Drawing.SystemColors.Control;

                        ldw_temp.GetControlByName("v_vehicle_model").BackColor = System.Drawing.SystemColors.Control;
                        ldw_temp.GetControlByName("v_vehicle_year").BackColor = System.Drawing.SystemColors.Control;
                        ldw_temp.GetControlByName("v_vehicle_month").BackColor = System.Drawing.SystemColors.Control;
                        ldw_temp.GetControlByName("v_vehicle_cc_rating").BackColor = System.Drawing.SystemColors.Control;
                        ldw_temp.GetControlByName("v_purchase_value").BackColor = System.Drawing.SystemColors.Control;
                        ldw_temp.GetControlByName("v_salvage_value").BackColor = System.Drawing.SystemColors.Control;
                        ldw_temp.GetControlByName("contract_vehical_start_kms").BackColor = System.Drawing.SystemColors.Control;
                        ldw_temp.GetControlByName("v_remaining_economic_life").BackColor = System.Drawing.SystemColors.Control;
                        ldw_temp.GetControlByName("v_vehicle_speedo_date").BackColor = System.Drawing.SystemColors.Control;
                        ldw_temp.GetControlByName("v_vehicle_speedo_kms").BackColor = System.Drawing.SystemColors.Control;

                    }
                    else
                    {
                        ldw_temp.GetControlByName("v_vehicle_registration_number").BackColor = System.Drawing.Color.Aqua;
                        ldw_temp.GetControlByName("vt_key").BackColor = System.Drawing.Color.Aqua;
                        ldw_temp.GetControlByName("vs_key").BackColor = System.Drawing.Color.Aqua;
                        ldw_temp.GetControlByName("v_vehicle_make").BackColor = System.Drawing.Color.Aqua;
                        ldw_temp.GetControlByName("ft_key").BackColor = System.Drawing.Color.Aqua;
                        ldw_temp.GetControlByName("v_purchased_date").BackColor = System.Drawing.Color.Aqua;

                        ldw_temp.GetControlByName("v_vehicle_model").BackColor = System.Drawing.Color.White;
                        ldw_temp.GetControlByName("v_vehicle_year").BackColor = System.Drawing.Color.White;
                        ldw_temp.GetControlByName("v_vehicle_month").BackColor = System.Drawing.Color.White;
                        ldw_temp.GetControlByName("v_vehicle_cc_rating").BackColor = System.Drawing.Color.White;
                        ldw_temp.GetControlByName("v_purchase_value").BackColor = System.Drawing.Color.White;
                        ldw_temp.GetControlByName("v_salvage_value").BackColor = System.Drawing.Color.White;
                        ldw_temp.GetControlByName("contract_vehical_start_kms").BackColor = System.Drawing.Color.White;
                        ldw_temp.GetControlByName("v_remaining_economic_life").BackColor = System.Drawing.Color.White;
                        ldw_temp.GetControlByName("v_vehicle_speedo_date").BackColor = System.Drawing.Color.White;
                        ldw_temp.GetControlByName("v_vehicle_speedo_kms").BackColor = System.Drawing.Color.White;


                    }
                    this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                    tbPanel.SetRow(ldw_temp, i);
                    tbPanel.Controls.Add(ldw_temp, 0, i);
                    ldw_temp.BindingSource.CurrencyManager.Refresh();
                }
            }
            else
            {
            }
        }

        void DContractVehicle_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (((Metex.Windows.DataEntityCombo)sender).Focused)
            {
                this.GetControlByName("v_vehicle_cc_rating").Focus();
                if (SelectedItemChanged != null)
                    SelectedItemChanged(sender, e);
                this.GetControlByName("ft_key").Focus();
            }
        }

        void  DContractVehicle_Leave(object sender, System.EventArgs e)
        {
            //if (((System.Windows.Forms.TextBoxBase)(sender)).Focused)
            //{
                if (TextChanged != null)
                    TextChanged(sender, e);
            //}
        }

        void DContractVehicle_cb_active_Leave(object sender, System.EventArgs e)
        {
            if (TextChanged != null)
                TextChanged(sender, e);
        }

        void DContractVehicle_cb_active_Click(object sender, System.EventArgs e)
        {
            if (TextChanged != null)
                TextChanged(sender, e);
        }

        //void DContractFixedAssetsTest_RetrieveEnd(object sender, System.EventArgs e)
        void DContractVehicle_RetrieveEnd(object sender, System.EventArgs e)
        {
            retrieve_end = true;
            for (int i = 0; i < this.RowCount; i++)
            {
                DContractVehicleTest ldw_temp;
                ldw_temp = new DContractVehicleTest();
                ldw_temp.Name = i.ToString();
                ldw_temp.Size = new System.Drawing.Size(535, 300);
                ldw_temp.BindingSource.DataSource = this.BindingSource.List[i];

                ((Metex.Windows.DataEntityCombo)ldw_temp.GetControlByName("ft_key")).SelectedValueChanged += new System.EventHandler(DContractVehicle_SelectedValueChanged);
                ldw_temp.GetControlByName("v_vehicle_registration_number").Leave += new System.EventHandler(DContractVehicle_Leave);
                //ldw_temp.GetControlByName("cb_active").Leave += new System.EventHandler(DContractVehicle_cb_active_Leave);
                //ldw_temp.GetControlByName("cb_active").Click += new EventHandler(DContractVehicle_cb_active_Click);

                if (st_sysadmin.Text != "Y")
                {
                    if (ldw_temp.GetItem<NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle>(0).VVehicleTransmission == "A"
                        || ldw_temp.GetItem<NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle>(0).VVehicleTransmission == "M"
                        || this.Enabled == false)
                    {
                        ldw_temp.GetControlByName("radioButton1").Enabled = false;
                        ldw_temp.GetControlByName("radioButton2").Enabled = false;
                    }
                }
                else
                {
                    ldw_temp.GetControlByName("radioButton1").Enabled = true;
                    ldw_temp.GetControlByName("radioButton2").Enabled = true;
                }
                if (st_sysadmin.Text != "Y")
                {
                    if (ldw_temp.GetItem<NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle>(0).StartKms < 5000 || ldw_temp.GetItem<NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle>(0).StartKms == null
                        || this.Enabled == false 
                        || !ldw_temp.GetItem<NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle>(0).IsNew)
                    {
                        ldw_temp.GetControlByName("v_remaining_economic_life").Enabled = false;
                    }
                }
                else
                {
                    ldw_temp.GetControlByName("v_remaining_economic_life").Enabled = true;
                }
                if (st_sysadmin.Text != "Y")
                {
                    if (this.Enabled == false || !ldw_temp.GetItem<NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle>(0).IsNew)
                    {
                        ldw_temp.GetControlByName("v_vehicle_registration_number").Enabled = false;
                        ldw_temp.GetControlByName("vt_key").Enabled = false;
                        ldw_temp.GetControlByName("vs_key").Enabled = false;
                        ldw_temp.GetControlByName("v_vehicle_make").Enabled = false;
                        ldw_temp.GetControlByName("ft_key").Enabled = false;
                        ldw_temp.GetControlByName("v_purchased_date").Enabled = false;

                        ldw_temp.GetControlByName("v_vehicle_model").Enabled = false;
                        ldw_temp.GetControlByName("v_vehicle_year").Enabled = false;
                        ldw_temp.GetControlByName("v_vehicle_month").Enabled = false;
                        ldw_temp.GetControlByName("v_vehicle_cc_rating").Enabled = false;
                        ldw_temp.GetControlByName("v_purchase_value").Enabled = false;
                        ldw_temp.GetControlByName("v_salvage_value").Enabled = false;
                        ldw_temp.GetControlByName("contract_vehical_start_kms").Enabled = false;
                        ldw_temp.GetControlByName("v_leased").Enabled = false;
                        ldw_temp.GetControlByName("v_road_user_charges_indicator").Enabled = false;

                    }
                }
                else
                {
                    ldw_temp.GetControlByName("v_vehicle_registration_number").Enabled = true;
                    ldw_temp.GetControlByName("vt_key").Enabled = true;
                    ldw_temp.GetControlByName("vs_key").Enabled = true;
                    ldw_temp.GetControlByName("v_vehicle_make").Enabled = true;
                    ldw_temp.GetControlByName("ft_key").Enabled = true;
                    ldw_temp.GetControlByName("v_purchased_date").Enabled = true;

                    ldw_temp.GetControlByName("v_vehicle_model").Enabled = true;
                    ldw_temp.GetControlByName("v_vehicle_year").Enabled = true;
                    ldw_temp.GetControlByName("v_vehicle_month").Enabled = true;
                    ldw_temp.GetControlByName("v_vehicle_cc_rating").Enabled = true;
                    ldw_temp.GetControlByName("v_purchase_value").Enabled = true;
                    ldw_temp.GetControlByName("v_salvage_value").Enabled = true;
                    ldw_temp.GetControlByName("contract_vehical_start_kms").Enabled = true;
                    ldw_temp.GetControlByName("v_leased").Enabled = true;
                    ldw_temp.GetControlByName("v_road_user_charges_indicator").Enabled = true;

                }
                if (this.Enabled == false || !ldw_temp.GetItem<NZPostOffice.RDS.Entity.Ruraldw.ContractVehicle>(0).IsNew)
                {
                    ldw_temp.GetControlByName("v_vehicle_registration_number").BackColor = System.Drawing.SystemColors.Control;
                    ldw_temp.GetControlByName("vt_key").BackColor = System.Drawing.SystemColors.Control;
                    ldw_temp.GetControlByName("vs_key").BackColor = System.Drawing.SystemColors.Control;
                    ldw_temp.GetControlByName("v_vehicle_make").BackColor = System.Drawing.SystemColors.Control;
                    ldw_temp.GetControlByName("ft_key").BackColor = System.Drawing.SystemColors.Control;
                    ldw_temp.GetControlByName("v_purchased_date").BackColor = System.Drawing.SystemColors.Control;

                    ldw_temp.GetControlByName("v_vehicle_model").BackColor = System.Drawing.SystemColors.Control;
                    ldw_temp.GetControlByName("v_vehicle_year").BackColor = System.Drawing.SystemColors.Control;
                    ldw_temp.GetControlByName("v_vehicle_month").BackColor = System.Drawing.SystemColors.Control;
                    ldw_temp.GetControlByName("v_vehicle_cc_rating").BackColor = System.Drawing.SystemColors.Control;
                    ldw_temp.GetControlByName("v_purchase_value").BackColor = System.Drawing.SystemColors.Control;
                    ldw_temp.GetControlByName("v_salvage_value").BackColor = System.Drawing.SystemColors.Control;
                    ldw_temp.GetControlByName("contract_vehical_start_kms").BackColor = System.Drawing.SystemColors.Control;
                    ldw_temp.GetControlByName("v_remaining_economic_life").BackColor = System.Drawing.SystemColors.Control;
                    ldw_temp.GetControlByName("v_vehicle_speedo_date").BackColor = System.Drawing.SystemColors.Control;
                    ldw_temp.GetControlByName("v_vehicle_speedo_kms").BackColor = System.Drawing.SystemColors.Control;
                }
                else
                {
                    ldw_temp.GetControlByName("v_vehicle_registration_number").BackColor = System.Drawing.Color.Aqua;
                    ldw_temp.GetControlByName("vt_key").BackColor = System.Drawing.Color.Aqua;
                    ldw_temp.GetControlByName("vs_key").BackColor = System.Drawing.Color.Aqua;
                    ldw_temp.GetControlByName("v_vehicle_make").BackColor = System.Drawing.Color.Aqua;
                    ldw_temp.GetControlByName("ft_key").BackColor = System.Drawing.Color.Aqua;
                    ldw_temp.GetControlByName("v_purchased_date").BackColor = System.Drawing.Color.Aqua;

                    ldw_temp.GetControlByName("v_vehicle_model").BackColor = System.Drawing.Color.White;
                    ldw_temp.GetControlByName("v_vehicle_year").BackColor = System.Drawing.Color.White;
                    ldw_temp.GetControlByName("v_vehicle_month").BackColor = System.Drawing.Color.White;
                    ldw_temp.GetControlByName("v_vehicle_cc_rating").BackColor = System.Drawing.Color.White;
                    ldw_temp.GetControlByName("v_purchase_value").BackColor = System.Drawing.Color.White;
                    ldw_temp.GetControlByName("v_salvage_value").BackColor = System.Drawing.Color.White;
                    ldw_temp.GetControlByName("contract_vehical_start_kms").BackColor = System.Drawing.Color.White;
                    ldw_temp.GetControlByName("v_remaining_economic_life").BackColor = System.Drawing.Color.White;
                    ldw_temp.GetControlByName("v_vehicle_speedo_date").BackColor = System.Drawing.Color.White;
                    ldw_temp.GetControlByName("v_vehicle_speedo_kms").BackColor = System.Drawing.Color.White;

                }
                if (this.RowCount > 1)
                {
                    this.tbPanel.Width = 600;
                    this.vScrollBar1.Visible = true;
                    this.vScrollBar1.Maximum = this.RowCount - 1;
                    this.vScrollBar1.LargeChange = 1;
                    this.tbPanel.AutoScroll = true;
                }
                else
                {
                    this.tbPanel.Width = 600;
                    this.vScrollBar1.Visible = false;
                }

                this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                tbPanel.SetRow(ldw_temp, i);
                tbPanel.Controls.Add(ldw_temp, 0, i);
            }
        }

        public VScrollBar vScrollBar1;

        public event EventHandler SelectedItemChanged;
        public event EventHandler TextChanged;

        #endregion
    }
}
