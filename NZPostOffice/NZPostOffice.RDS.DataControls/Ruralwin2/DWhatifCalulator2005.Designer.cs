using NZPostOffice.RDS.DataControls.Report;
using System.Collections.Generic;
using NZPostOffice.RDS.Entity.Ruralwin2;
namespace NZPostOffice.RDS.DataControls.Ruralwin2
{
    partial class DWhatifCalulator2005
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /*
		private System.Windows.Forms.DataGridViewTextBoxColumn  calcroutedistance;
		private System.Windows.Forms.DataGridViewTextBoxColumn  contract_no;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_sundries;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_itemprocrate;
		private System.Windows.Forms.DataGridViewTextBoxColumn  benchdiff;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_vehrateofreturn;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calcfc;
		private System.Windows.Forms.DataGridViewTextBoxColumn  nuniform;
		private System.Windows.Forms.DataGridViewTextBoxColumn  naccamount;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calccrr;
		private System.Windows.Forms.DataGridViewTextBoxColumn  contract;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rf_active;
		private System.Windows.Forms.DataGridViewTextBoxColumn  itemspercust;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_nomvehicle;
		private System.Windows.Forms.DataGridViewTextBoxColumn  variance;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calcrel;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calcrep;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calcrc;
		private System.Windows.Forms.DataGridViewTextBoxColumn  caclacct;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calcdelhours;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calcvd;
		private System.Windows.Forms.DataGridViewTextBoxColumn  nlivery;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_accounting;
		private System.Windows.Forms.DataGridViewTextBoxColumn  taccounting;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calcvi;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calcruc;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_tyretubes;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_repairsmaint;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calcacc;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_vehinsurance;
		private System.Windows.Forms.DataGridViewTextBoxColumn  nvtkey;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calcdc;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_proc_wage;
		private System.Windows.Forms.DataGridViewTextBoxColumn  firstrow;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calclic;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_sundriesk;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_telephone;
		private System.Windows.Forms.DataGridViewTextBoxColumn  vardist;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_carrierrisk;
		private System.Windows.Forms.DataGridViewTextBoxColumn  nmultiplier;
		private System.Windows.Forms.DataGridViewTextBoxColumn  vehicalallow;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_ruc;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_salvageratio;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calcpc;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_license;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_acc;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_publiclia;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_vehallow;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calctel;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rrrate_del_wage;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calcpl;
		private System.Windows.Forms.DataGridViewTextBoxColumn  opcost;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calcvolume;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calcbenchmark;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ninsurancepct;
		private System.Windows.Forms.DataGridViewTextBoxColumn  maxdaysallcontracts;
		private System.Windows.Forms.DataGridViewTextBoxColumn  calctt;
        */

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //private Metex.Windows.DataEntityGrid grid;

        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            //grid = new Metex.Windows.DataEntityGrid();
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.reWhatifCalulator2005 = new NZPostOffice.RDS.DataControls.Report.REDWhatifCalculator2005();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            // 
            // bindingSource
            //
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin2.WhatifCalulator2005);

            /*
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
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(638, 252);
			this.grid.TabIndex = 0;

			//
			// firstrow
			//
			firstrow= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.firstrow.DataPropertyName = "Firstrow";
			this.firstrow.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.firstrow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.firstrow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.firstrow.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.firstrow.HeaderText = "Uniform";
			this.firstrow.Name = "firstrow";
			this.firstrow.ReadOnly = true;
			this.firstrow.Width = 46;
			this.grid.Columns.Add(firstrow);

			//
			// rrrate_repairsmaint
			//
			rrrate_repairsmaint= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_repairsmaint.DataPropertyName = "RrrateRepairsmaint";
			this.rrrate_repairsmaint.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_repairsmaint.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_repairsmaint.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_repairsmaint.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_repairsmaint.HeaderText = "Uniform";
			this.rrrate_repairsmaint.Name = "rrrate_repairsmaint";
			this.rrrate_repairsmaint.ReadOnly = true;
			this.rrrate_repairsmaint.Width = 46;
			this.grid.Columns.Add(rrrate_repairsmaint);

			//
			// rrrate_carrierrisk
			//
			rrrate_carrierrisk= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_carrierrisk.DataPropertyName = "RrrateCarrierrisk";
			this.rrrate_carrierrisk.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_carrierrisk.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_carrierrisk.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_carrierrisk.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_carrierrisk.HeaderText = "Difference";
			this.rrrate_carrierrisk.Name = "rrrate_carrierrisk";
			this.rrrate_carrierrisk.ReadOnly = true;
			this.rrrate_carrierrisk.Width = 66;
			this.grid.Columns.Add(rrrate_carrierrisk);

			//
			// rrrate_accounting
			//
			rrrate_accounting= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_accounting.DataPropertyName = "RrrateAccounting";
			this.rrrate_accounting.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_accounting.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_accounting.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_accounting.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_accounting.HeaderText = "Uniform";
			this.rrrate_accounting.Name = "rrrate_accounting";
			this.rrrate_accounting.ReadOnly = true;
			this.rrrate_accounting.Width = 46;
			this.grid.Columns.Add(rrrate_accounting);

			//
			// rf_active
			//
			rf_active= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rf_active.DataPropertyName = "RfActive";
			this.rf_active.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rf_active.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rf_active.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromWin32(8388736);
			this.rf_active.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rf_active.HeaderText = "Uniform";
			this.rf_active.Name = "rf_active";
			this.rf_active.ReadOnly = true;
			this.rf_active.Width = 46;
			this.grid.Columns.Add(rf_active);

			//
			// rrrate_tyretubes
			//
			rrrate_tyretubes= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_tyretubes.DataPropertyName = "RrrateTyretubes";
			this.rrrate_tyretubes.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_tyretubes.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_tyretubes.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_tyretubes.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_tyretubes.HeaderText = "Uniform";
			this.rrrate_tyretubes.Name = "rrrate_tyretubes";
			this.rrrate_tyretubes.ReadOnly = true;
			this.rrrate_tyretubes.Width = 46;
			this.grid.Columns.Add(rrrate_tyretubes);

			//
			// contract_no
			//
			contract_no= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contract_no.DataPropertyName = "ContractNo";
			this.contract_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.contract_no.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.contract_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.contract_no.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.contract_no.HeaderText = "Uniform";
			this.contract_no.Name = "contract_no";
			this.contract_no.ReadOnly = true;
			this.contract_no.Width = 46;
			this.grid.Columns.Add(contract_no);

			//
			// rrrate_vehrateofreturn
			//
			rrrate_vehrateofreturn= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_vehrateofreturn.DataPropertyName = "RrrateVehrateofreturn";
			this.rrrate_vehrateofreturn.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_vehrateofreturn.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_vehrateofreturn.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_vehrateofreturn.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_vehrateofreturn.HeaderText = "Difference";
			this.rrrate_vehrateofreturn.Name = "rrrate_vehrateofreturn";
			this.rrrate_vehrateofreturn.ReadOnly = true;
			this.rrrate_vehrateofreturn.Width = 66;
			this.grid.Columns.Add(rrrate_vehrateofreturn);

			//
			// rrrate_vehallow
			//
			rrrate_vehallow= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_vehallow.DataPropertyName = "RrrateVehallow";
			this.rrrate_vehallow.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_vehallow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_vehallow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_vehallow.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_vehallow.HeaderText = "Uniform";
			this.rrrate_vehallow.Name = "rrrate_vehallow";
			this.rrrate_vehallow.ReadOnly = true;
			this.rrrate_vehallow.Width = 46;
			this.grid.Columns.Add(rrrate_vehallow);

			//
			// rrrate_itemprocrate
			//
			rrrate_itemprocrate= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_itemprocrate.DataPropertyName = "RrrateItemprocrate";
			this.rrrate_itemprocrate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_itemprocrate.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_itemprocrate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_itemprocrate.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_itemprocrate.HeaderText = "Uniform";
			this.rrrate_itemprocrate.Name = "rrrate_itemprocrate";
			this.rrrate_itemprocrate.ReadOnly = true;
			this.rrrate_itemprocrate.Width = 46;
			this.grid.Columns.Add(rrrate_itemprocrate);

			//
			// rrrate_acc
			//
			rrrate_acc= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_acc.DataPropertyName = "RrrateAcc";
			this.rrrate_acc.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_acc.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_acc.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_acc.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_acc.HeaderText = "Difference";
			this.rrrate_acc.Name = "rrrate_acc";
			this.rrrate_acc.ReadOnly = true;
			this.rrrate_acc.Width = 66;
			this.grid.Columns.Add(rrrate_acc);

			//
			// rrrate_salvageratio
			//
			rrrate_salvageratio= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_salvageratio.DataPropertyName = "RrrateSalvageratio";
			this.rrrate_salvageratio.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_salvageratio.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_salvageratio.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_salvageratio.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_salvageratio.HeaderText = "Uniform";
			this.rrrate_salvageratio.Name = "rrrate_salvageratio";
			this.rrrate_salvageratio.ReadOnly = true;
			this.rrrate_salvageratio.Width = 46;
			this.grid.Columns.Add(rrrate_salvageratio);

			//
			// rrrate_nomvehicle
			//
			rrrate_nomvehicle= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_nomvehicle.DataPropertyName = "RrrateNomvehicle";
			this.rrrate_nomvehicle.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_nomvehicle.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_nomvehicle.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_nomvehicle.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_nomvehicle.HeaderText = "Uniform";
			this.rrrate_nomvehicle.Name = "rrrate_nomvehicle";
			this.rrrate_nomvehicle.ReadOnly = true;
			this.rrrate_nomvehicle.Width = 46;
			this.grid.Columns.Add(rrrate_nomvehicle);

			//
			// rrrate_license
			//
			rrrate_license= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_license.DataPropertyName = "RrrateLicense";
			this.rrrate_license.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_license.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_license.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_license.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_license.HeaderText = "Difference";
			this.rrrate_license.Name = "rrrate_license";
			this.rrrate_license.ReadOnly = true;
			this.rrrate_license.Width = 66;
			this.grid.Columns.Add(rrrate_license);

			//
			// rrrate_telephone
			//
			rrrate_telephone= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_telephone.DataPropertyName = "RrrateTelephone";
			this.rrrate_telephone.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_telephone.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_telephone.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_telephone.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_telephone.HeaderText = "Uniform";
			this.rrrate_telephone.Name = "rrrate_telephone";
			this.rrrate_telephone.ReadOnly = true;
			this.rrrate_telephone.Width = 46;
			this.grid.Columns.Add(rrrate_telephone);

			//
			// rrrate_ruc
			//
			rrrate_ruc= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_ruc.DataPropertyName = "RrrateRuc";
			this.rrrate_ruc.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_ruc.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_ruc.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_ruc.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_ruc.HeaderText = "Uniform";
			this.rrrate_ruc.Name = "rrrate_ruc";
			this.rrrate_ruc.ReadOnly = true;
			this.rrrate_ruc.Width = 46;
			this.grid.Columns.Add(rrrate_ruc);

			//
			// rrrate_publiclia
			//
			rrrate_publiclia= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_publiclia.DataPropertyName = "RrratePubliclia";
			this.rrrate_publiclia.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_publiclia.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_publiclia.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_publiclia.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_publiclia.HeaderText = "Difference";
			this.rrrate_publiclia.Name = "rrrate_publiclia";
			this.rrrate_publiclia.ReadOnly = true;
			this.rrrate_publiclia.Width = 66;
			this.grid.Columns.Add(rrrate_publiclia);

			//
			// rrrate_del_wage
			//
			rrrate_del_wage= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_del_wage.DataPropertyName = "RrrateDelWage";
			this.rrrate_del_wage.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_del_wage.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_del_wage.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_del_wage.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_del_wage.HeaderText = "Uniform";
			this.rrrate_del_wage.Name = "rrrate_del_wage";
			this.rrrate_del_wage.ReadOnly = true;
			this.rrrate_del_wage.Width = 46;
			this.grid.Columns.Add(rrrate_del_wage);

			//
			// rrrate_vehinsurance
			//
			rrrate_vehinsurance= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_vehinsurance.DataPropertyName = "RrrateVehinsurance";
			this.rrrate_vehinsurance.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_vehinsurance.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_vehinsurance.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_vehinsurance.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_vehinsurance.HeaderText = "Uniform";
			this.rrrate_vehinsurance.Name = "rrrate_vehinsurance";
			this.rrrate_vehinsurance.ReadOnly = true;
			this.rrrate_vehinsurance.Width = 46;
			this.grid.Columns.Add(rrrate_vehinsurance);

			//
			// rrrate_proc_wage
			//
			rrrate_proc_wage= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_proc_wage.DataPropertyName = "RrrateProcWage";
			this.rrrate_proc_wage.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_proc_wage.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_proc_wage.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_proc_wage.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_proc_wage.HeaderText = "Uniform";
			this.rrrate_proc_wage.Name = "rrrate_proc_wage";
			this.rrrate_proc_wage.ReadOnly = true;
			this.rrrate_proc_wage.Width = 46;
			this.grid.Columns.Add(rrrate_proc_wage);

			//
			// naccamount
			//
			naccamount= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.naccamount.DataPropertyName = "Naccamount";
			this.naccamount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.naccamount.DefaultCellStyle.BackColor = System.Drawing.Color.Silver;
			this.naccamount.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.naccamount.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F);
			this.naccamount.HeaderText = "Uniform";
			this.naccamount.Name = "naccamount";
			this.naccamount.ReadOnly = true;
			this.naccamount.Width = 56;
			this.grid.Columns.Add(naccamount);

			//
			// rrrate_sundriesk
			//
			rrrate_sundriesk= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_sundriesk.DataPropertyName = "RrrateSundriesk";
			this.rrrate_sundriesk.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_sundriesk.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_sundriesk.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_sundriesk.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F);
			this.rrrate_sundriesk.HeaderText = "Uniform";
			this.rrrate_sundriesk.Name = "rrrate_sundriesk";
			this.rrrate_sundriesk.ReadOnly = true;
			this.rrrate_sundriesk.Width = 53;
			this.grid.Columns.Add(rrrate_sundriesk);

			//
			// nmultiplier
			//
			nmultiplier= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nmultiplier.DataPropertyName = "Nmultiplier";
			this.nmultiplier.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.nmultiplier.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.nmultiplier.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.nmultiplier.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.nmultiplier.DefaultCellStyle.Format = "#,##0.0";
			this.nmultiplier.HeaderText = "Uniform";
			this.nmultiplier.Name = "nmultiplier";
			this.nmultiplier.ReadOnly = true;
			this.nmultiplier.Width = 53;
			this.grid.Columns.Add(nmultiplier);

			//
			// rrrate_sundries
			//
			rrrate_sundries= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rrrate_sundries.DataPropertyName = "RrrateSundries";
			this.rrrate_sundries.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rrrate_sundries.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rrrate_sundries.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rrrate_sundries.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F, System.Drawing.FontStyle.Bold);
			this.rrrate_sundries.HeaderText = "Uniform";
			this.rrrate_sundries.Name = "rrrate_sundries";
			this.rrrate_sundries.ReadOnly = true;
			this.rrrate_sundries.Width = 53;
			this.grid.Columns.Add(rrrate_sundries);

			//
			// itemspercust
			//
			itemspercust= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.itemspercust.DataPropertyName = "Itemspercust";
			this.itemspercust.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.itemspercust.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.itemspercust.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.itemspercust.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F);
			this.itemspercust.HeaderText = "Uniform";
			this.itemspercust.Name = "itemspercust";
			this.itemspercust.ReadOnly = true;
			this.itemspercust.Width = 53;
			this.grid.Columns.Add(itemspercust);

			//
			// vehicalallow
			//
			vehicalallow= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vehicalallow.DataPropertyName = "Vehicalallow";
			this.vehicalallow.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.vehicalallow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.vehicalallow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.vehicalallow.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F);
			this.vehicalallow.HeaderText = "Uniform";
			this.vehicalallow.Name = "vehicalallow";
			this.vehicalallow.ReadOnly = true;
			this.vehicalallow.Width = 53;
			this.grid.Columns.Add(vehicalallow);

			//
			// nlivery
			//
			nlivery= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nlivery.DataPropertyName = "Nlivery";
			this.nlivery.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.nlivery.DefaultCellStyle.BackColor = System.Drawing.Color.Silver;
			this.nlivery.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.nlivery.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F);
			this.nlivery.HeaderText = "rrrate_carrierrisk";
			this.nlivery.Name = "nlivery";
			this.nlivery.ReadOnly = true;
			this.nlivery.Width = 89;
			this.grid.Columns.Add(nlivery);

			//
			// ninsurancepct
			//
			ninsurancepct= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ninsurancepct.DataPropertyName = "Ninsurancepct";
			this.ninsurancepct.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.ninsurancepct.DefaultCellStyle.BackColor = System.Drawing.Color.Silver;
			this.ninsurancepct.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.ninsurancepct.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F);
			this.ninsurancepct.HeaderText = "Uniform";
			this.ninsurancepct.Name = "ninsurancepct";
			this.ninsurancepct.ReadOnly = true;
			this.ninsurancepct.Width = 56;
			this.grid.Columns.Add(ninsurancepct);

			//
			// nvtkey
			//
			nvtkey= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nvtkey.DataPropertyName = "Nvtkey";
			this.nvtkey.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.nvtkey.DefaultCellStyle.BackColor = System.Drawing.Color.Silver;
			this.nvtkey.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.nvtkey.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 7F);
			this.nvtkey.HeaderText = "Distance";
			this.nvtkey.Name = "nvtkey";
			this.nvtkey.ReadOnly = true;
			this.nvtkey.Width = 56;
			this.grid.Columns.Add(nvtkey);

			//
			// nuniform
			//
			nuniform= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nuniform.DataPropertyName = "Nuniform";
			this.nuniform.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.nuniform.DefaultCellStyle.BackColor = System.Drawing.Color.Silver;
			this.nuniform.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.nuniform.DefaultCellStyle.Font = new System.Drawing.Font("Small Fonts", 7F);
			this.nuniform.HeaderText = "Uniform";
			this.nuniform.Name = "nuniform";
			this.nuniform.ReadOnly = true;
			this.nuniform.Width = 56;
			this.grid.Columns.Add(nuniform);

			//
			// calcdelhours
			//
			calcdelhours= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calcdelhours.DataPropertyName = "Calcdelhours";
			this.calcdelhours.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calcdelhours.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			//?this.calcdelhours.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromWin32(16777215~tif(long(describe('st_contract.text')) = contract_no, 16777215, 0));
			this.calcdelhours.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.calcdelhours.DefaultCellStyle.Format = "#,##0.00;(#,##0.00)";
			this.calcdelhours.HeaderText = "DeliveryHours";
			this.calcdelhours.Name = "calcdelhours";
			this.calcdelhours.Width = 49;
			this.grid.Columns.Add(calcdelhours);

			//
			// contract
			//
			contract= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contract.DataPropertyName = "Contract";
			this.contract.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.contract.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			//?this.contract.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromWin32(16777215~tif(long(describe('st_contract.text')) = contract_no, 16777215, 0));
			this.contract.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contract.HeaderText = "rrrate_nomvehicle";
			this.contract.Name = "contract";
			this.contract.Width = 77;
			this.grid.Columns.Add(contract);

			//
			// opcost
			//
			opcost= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.opcost.DataPropertyName = "Opcost";
			this.opcost.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.opcost.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			//?this.opcost.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromWin32(16777215~tif(long(describe('st_contract.text')) = contract_no, 16777215, 0));
			this.opcost.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.opcost.DefaultCellStyle.Format = "#,##0;(#,##0)";
			this.opcost.HeaderText = "Uniform";
			this.opcost.Name = "opcost";
			this.opcost.Width = 67;
			this.grid.Columns.Add(opcost);

			//
			// calcroutedistance
			//
			calcroutedistance= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calcroutedistance.DataPropertyName = "Calcroutedistance";
			this.calcroutedistance.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calcroutedistance.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			//?this.calcroutedistance.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromWin32(16777215~tif(long(describe('st_contract.text')) = contract_no, 16777215, 0));
			this.calcroutedistance.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.calcroutedistance.DefaultCellStyle.Format = "#,##0;(#,##0)";
			this.calcroutedistance.HeaderText = "Distance";
			this.calcroutedistance.Name = "calcroutedistance";
			this.calcroutedistance.Width = 49;
			this.grid.Columns.Add(calcroutedistance);

			//
			// calcacc
			//
			calcacc= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calcacc.DataPropertyName = "Calcacc";
			this.calcacc.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calcacc.DefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
			this.calcacc.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calcacc.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calcacc.DefaultCellStyle.Format = "#,##0.00";
			this.calcacc.HeaderText = "Distance";
			this.calcacc.Name = "calcacc";
			this.calcacc.Width = 46;
			this.grid.Columns.Add(calcacc);

			//
			// calcdc
			//
			calcdc= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calcdc.DataPropertyName = "Calcdc";
			this.calcdc.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calcdc.DefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
			this.calcdc.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calcdc.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calcdc.DefaultCellStyle.Format = "#,##0.00";
			this.calcdc.HeaderText = "Distance";
			this.calcdc.Name = "calcdc";
			this.calcdc.Width = 46;
			this.grid.Columns.Add(calcdc);

			//
			// calcpc
			//
			calcpc= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calcpc.DataPropertyName = "Calcpc";
			this.calcpc.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calcpc.DefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
			this.calcpc.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calcpc.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calcpc.DefaultCellStyle.Format = "#,##0.00";
			this.calcpc.HeaderText = "Distance";
			this.calcpc.Name = "calcpc";
			this.calcpc.Width = 46;
			this.grid.Columns.Add(calcpc);

			//
			// calcrc
			//
			calcrc= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calcrc.DataPropertyName = "Calcrc";
			this.calcrc.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calcrc.DefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
			this.calcrc.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calcrc.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calcrc.DefaultCellStyle.Format = "#,##0.00";
			this.calcrc.HeaderText = "Distance";
			this.calcrc.Name = "calcrc";
			this.calcrc.Width = 46;
			this.grid.Columns.Add(calcrc);

			//
			// calcvd
			//
			calcvd= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calcvd.DataPropertyName = "Calcvd";
			this.calcvd.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calcvd.DefaultCellStyle.BackColor = System.Drawing.Color.Green;
			this.calcvd.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calcvd.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calcvd.DefaultCellStyle.Format = "#,##0.00";
			this.calcvd.HeaderText = "Distance";
			this.calcvd.Name = "calcvd";
			this.calcvd.Width = 46;
			this.grid.Columns.Add(calcvd);

			//
			// calcfc
			//
			calcfc= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calcfc.DataPropertyName = "Calcfc";
			this.calcfc.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calcfc.DefaultCellStyle.BackColor = System.Drawing.Color.Green;
			this.calcfc.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calcfc.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calcfc.DefaultCellStyle.Format = "#,##0.00";
			this.calcfc.HeaderText = "Distance";
			this.calcfc.Name = "calcfc";
			this.calcfc.Width = 46;
			this.grid.Columns.Add(calcfc);

			//
			// calcrep
			//
			calcrep= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calcrep.DataPropertyName = "Calcrep";
			this.calcrep.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calcrep.DefaultCellStyle.BackColor = System.Drawing.Color.Green;
			this.calcrep.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calcrep.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calcrep.DefaultCellStyle.Format = "#,##0.00";
			this.calcrep.HeaderText = "Distance";
			this.calcrep.Name = "calcrep";
			this.calcrep.Width = 46;
			this.grid.Columns.Add(calcrep);

			//
			// calctt
			//
			calctt= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calctt.DataPropertyName = "Calctt";
			this.calctt.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calctt.DefaultCellStyle.BackColor = System.Drawing.Color.Green;
			this.calctt.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calctt.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calctt.DefaultCellStyle.Format = "#,##0.00";
			this.calctt.HeaderText = "Distance";
			this.calctt.Name = "calctt";
			this.calctt.Width = 46;
			this.grid.Columns.Add(calctt);

			//
			// calcruc
			//
			calcruc= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calcruc.DataPropertyName = "Calcruc";
			this.calcruc.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calcruc.DefaultCellStyle.BackColor = System.Drawing.Color.Green;
			this.calcruc.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calcruc.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calcruc.DefaultCellStyle.Format = "#,##0.00";
			this.calcruc.HeaderText = "Distance";
			this.calcruc.Name = "calcruc";
			this.calcruc.Width = 46;
			this.grid.Columns.Add(calcruc);

			//
			// calcpl
			//
			calcpl= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calcpl.DataPropertyName = "Calcpl";
			this.calcpl.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calcpl.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
			this.calcpl.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calcpl.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calcpl.DefaultCellStyle.Format = "#,##0.00";
			this.calcpl.HeaderText = "Uniform";
			this.calcpl.Name = "calcpl";
			this.calcpl.Width = 40;
			this.grid.Columns.Add(calcpl);

			//
			// calcvi
			//
			calcvi= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calcvi.DataPropertyName = "Calcvi";
			this.calcvi.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calcvi.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
			this.calcvi.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calcvi.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calcvi.DefaultCellStyle.Format = "#,##0.00";
			this.calcvi.HeaderText = "Uniform";
			this.calcvi.Name = "calcvi";
			this.calcvi.Width = 40;
			this.grid.Columns.Add(calcvi);

			//
			// calclic
			//
			calclic= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calclic.DataPropertyName = "Calclic";
			this.calclic.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calclic.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
			this.calclic.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calclic.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calclic.DefaultCellStyle.Format = "#,##0.00";
			this.calclic.HeaderText = "Uniform";
			this.calclic.Name = "calclic";
			this.calclic.Width = 40;
			this.grid.Columns.Add(calclic);

			//
			// calccrr
			//
			calccrr= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calccrr.DataPropertyName = "Calccrr";
			this.calccrr.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calccrr.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
			this.calccrr.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calccrr.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calccrr.DefaultCellStyle.Format = "#,##0.00";
			this.calccrr.HeaderText = "Uniform";
			this.calccrr.Name = "calccrr";
			this.calccrr.Width = 40;
			this.grid.Columns.Add(calccrr);

			//
			// calctel
			//
			calctel= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calctel.DataPropertyName = "Calctel";
			this.calctel.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calctel.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
			this.calctel.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calctel.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calctel.DefaultCellStyle.Format = "#,##0.00";
			this.calctel.HeaderText = "Uniform";
			this.calctel.Name = "calctel";
			this.calctel.Width = 40;
			this.grid.Columns.Add(calctel);

			//
			// caclacct
			//
			caclacct= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.caclacct.DataPropertyName = "Caclacct";
			this.caclacct.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.caclacct.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
			this.caclacct.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.caclacct.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.caclacct.DefaultCellStyle.Format = "#,##0.00";
			this.caclacct.HeaderText = "Uniform";
			this.caclacct.Name = "caclacct";
			this.caclacct.Width = 40;
			this.grid.Columns.Add(caclacct);

			//
			// calcbenchmark
			//
			calcbenchmark= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calcbenchmark.DataPropertyName = "Calcbenchmark";
			this.calcbenchmark.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calcbenchmark.DefaultCellStyle.BackColor = System.Drawing.Color.Lime;
			this.calcbenchmark.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calcbenchmark.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calcbenchmark.DefaultCellStyle.Format = "#,##0;(#,##0)";
			this.calcbenchmark.HeaderText = "Uniform";
			this.calcbenchmark.Name = "calcbenchmark";
			this.calcbenchmark.Width = 53;
			this.grid.Columns.Add(calcbenchmark);

			//
			// variance
			//
			variance= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.variance.DataPropertyName = "Variance";
			this.variance.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.variance.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
            //?this.variance.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromWin32(16777215~tif(long(describe('st_contract.text')) = contract_no, 16777215, 0));
			this.variance.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.variance.DefaultCellStyle.Format = "#,##0;(#,##0)";
			this.variance.HeaderText = "Difference";
			this.variance.Name = "variance";
			this.variance.Width = 66;
			this.grid.Columns.Add(variance);

			//
			// benchdiff
			//
			benchdiff= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.benchdiff.DataPropertyName = "Benchdiff";
			this.benchdiff.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.benchdiff.DefaultCellStyle.BackColor = System.Drawing.Color.Lime;
			this.benchdiff.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.benchdiff.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.benchdiff.DefaultCellStyle.Format = "#,##0;(#,##0)";
			this.benchdiff.HeaderText = "Uniform";
			this.benchdiff.Name = "benchdiff";
			this.benchdiff.Width = 53;
			this.grid.Columns.Add(benchdiff);

			//
			// calcvolume
			//
			calcvolume= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calcvolume.DataPropertyName = "Calcvolume";
			this.calcvolume.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.calcvolume.DefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
			this.calcvolume.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calcvolume.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.calcvolume.DefaultCellStyle.Format = "#,##0.00";
			this.calcvolume.HeaderText = "Distance";
			this.calcvolume.Name = "calcvolume";
			this.calcvolume.Width = 52;
			this.grid.Columns.Add(calcvolume);

			//
			// vardist
			//
			vardist= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vardist.DataPropertyName = "Vardist";
			this.vardist.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.vardist.DefaultCellStyle.BackColor = System.Drawing.Color.Lime;
			this.vardist.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.vardist.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Bold);
			this.vardist.HeaderText = "Uniform";
			this.vardist.Name = "vardist";
			this.vardist.Width = 53;
			this.grid.Columns.Add(vardist);

			//
			// calcrel
			//
			calcrel= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.calcrel.DataPropertyName = "Calcrel";
			this.calcrel.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.calcrel.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.calcrel.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.calcrel.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.calcrel.HeaderText = "Uniform";
			this.calcrel.Name = "calcrel";
			this.calcrel.Width = 40;
			this.grid.Columns.Add(calcrel);

			//
			// taccounting
			//
			taccounting= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.taccounting.DataPropertyName = "Taccounting";
			this.taccounting.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.taccounting.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.taccounting.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
			this.taccounting.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F);
			this.taccounting.HeaderText = "Uniform";
			this.taccounting.Name = "taccounting";
			this.taccounting.Width = 57;
			this.grid.Columns.Add(taccounting);

			//
			// maxdaysallcontracts
			//
			maxdaysallcontracts= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.maxdaysallcontracts.DataPropertyName = "Maxdaysallcontracts";
			this.maxdaysallcontracts.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.maxdaysallcontracts.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.maxdaysallcontracts.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.maxdaysallcontracts.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10F);
			this.maxdaysallcontracts.DefaultCellStyle.Format = "#,##0;(#,##0);#;#";
			this.maxdaysallcontracts.HeaderText = "rrrate_nomvehicle";
			this.maxdaysallcontracts.Name = "maxdaysallcontracts";
			this.maxdaysallcontracts.Width = 77;
			this.grid.Columns.Add(maxdaysallcontracts);
            */

            // 
            // viewer
            // 
            this.viewer.ActiveViewIndex = 0;
            this.viewer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.DisplayGroupTree = false;
            this.viewer.DisplayStatusBar = false;
            this.viewer.Size = new System.Drawing.Size(638, 252);
            this.viewer.TabIndex = 0;
            this.viewer.ReportSource = this.reWhatifCalulator2005;

            // 
            // DwRunningSheetHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "DWhatifCalulator2005";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();

            table = new NZPostOffice.RDS.DataControls.Report.WhatifCalulator2005DataSet(this.bindingSource.DataSource);
            this.reWhatifCalulator2005.SetDataSource(table);

            this.RetrieveEnd += new System.EventHandler(DWhatifCalulator2005_RetrieveEnd);
            this.ResumeLayout(false);
        }

        void DWhatifCalulator2005_RetrieveEnd(object sender, System.EventArgs e)
        {

        }

        public void ShowReport()
        {
            if (this.viewer.ReportSource is REDWhatifCalculator2005)
            {
                this.reWhatifCalulator2005Detail = new NZPostOffice.RDS.DataControls.Report.REDWhatifCalculator2005Detail();
                table = new NZPostOffice.RDS.DataControls.Report.WhatifCalulator2005DataSet(this.bindingSource.DataSource);
                this.reWhatifCalulator2005Detail.SetDataSource(table);
                this.viewer.ReportSource = this.reWhatifCalulator2005Detail;
            }
            else
            {
                this.viewer.ReportSource = this.reWhatifCalulator2005;
            }
        }

        #endregion

        private System.Data.DataTable table;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.RDS.DataControls.Report.REDWhatifCalculator2005 reWhatifCalulator2005;
        private NZPostOffice.RDS.DataControls.Report.REDWhatifCalculator2005Detail reWhatifCalulator2005Detail;
        private System.Data.DataTable dt = new System.Data.DataTable();
    }
}
