using System.Data;
using NZPostOffice.ODPS.DataControls.Report;
using System;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    // TJB  RPCR_058  Jan-2014
    // Fixed bug in DwInvoiceHeaderv5_RetrieveEnd for cp subreport (table8)
    //
    // TJB  RPCR_056  June-2013
    // Add info for Allowance Breakdown subreport (table12 and table12s)

    partial class DwInvoiceHeaderv5
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
            components = new System.ComponentModel.Container();
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.reDwInvoiceHeaderv5 = new  NZPostOffice.ODPS.DataControls.Report.REDwInvoiceHeaderv5();

            // 
            // viewer
            // 
            this.viewer.ActiveViewIndex = 0;
            this.viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.DisplayGroupTree = false;
            this.viewer.DisplayStatusBar = false;
            this.viewer.Size = new System.Drawing.Size(638, 252);
            this.viewer.TabIndex = 0;
            this.viewer.ReportSource = this.reDwInvoiceHeaderv5;
            // 
            // 
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.viewer);
            this.Name = "DwInvoiceHeaderv5";
            this.Size = new System.Drawing.Size(638, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();

            this.reDwInvoiceHeaderv5.RefreshReport += new EventHandler(reDwInvoiceHeaderv5_RefreshReport);
            table = new  NZPostOffice.ODPS.DataControls.Report.InvoiceHeaderv5DataSet(this.bindingSource.DataSource);
            this.reDwInvoiceHeaderv5.SetDataSource(table);

            DataTable table2 = new  NZPostOffice.ODPS.DataControls.Report.InvoiceHeaderPostaddressDataSet(new RInvoiceHeaderPostaddress());
            this.reDwInvoiceHeaderv5.Subreports["REDwInvoiceHeaderPostaddress.rpt"].SetDataSource(table2);

            DataTable table3 = new  NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentDataSet(new RInvoiceDetailPayment());
            this.reDwInvoiceHeaderv5.Subreports["REDwInvoiceDetailPayment.rpt"].SetDataSource(table3);

            DataTable table4 = new  NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentPrDataSet(new RInvoiceDetailPaymentPr());
            this.reDwInvoiceHeaderv5.Subreports["REDInvoiceDetailPaymentPr.rpt"].SetDataSource(table4);

            DataTable table5 = new  NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentDedDataSet(new RInvoiceDetailPaymentDed());
            this.reDwInvoiceHeaderv5.Subreports["REDInvoiceDetailPaymentDed.rpt"].SetDataSource(table5);

            DataTable table6 = new  NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentPrTitleDataSet(new RInvoiceDetailPaymentPrTitle());
            this.reDwInvoiceHeaderv5.Subreports["REDInvoiceDetailPaymentPrTitle.rpt"].SetDataSource(table6);

            DataTable table7 = new  NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentPrDetailkmDataSet(new RInvoiceDetailPaymentPrDetailkm());
            //table7 = new NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentPrDetailkmDataSet(InvoiceDetailPaymentPrDetailkm.GetAllInvoiceDetailPaymentPrDetailkm());
            this.reDwInvoiceHeaderv5.Subreports["REDwInvoiceDetailPaymentPrDetailkm.rpt"].SetDataSource(table7);

            DataTable table8 = new  NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentPrDetailcpDataSet(new RInvoiceDetailPaymentPrDetailcp());
            this.reDwInvoiceHeaderv5.Subreports["REDwInvoiceDetailPaymentPrDetailcp.rpt"].SetDataSource(table8);

            DataTable table9 = new  NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentPrDetailxpDataSet(new RInvoiceDetailPaymentPrDetailxp());
            this.reDwInvoiceHeaderv5.Subreports["REDwInvoiceDetailPaymentPrDetailxp.rpt"].SetDataSource(table9);

            DataTable table10 = new  NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentPrDetailppDataSet(new RInvoiceDetailPaymentPrDetailpp());
            this.reDwInvoiceHeaderv5.Subreports["REDwInvoiceDetailPaymentPrDetailpp.rpt"].SetDataSource(table10);

            DataTable table11 = new NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentPrMessageDataSet(new RInvoiceDetailPaymentPrMessage());
            this.reDwInvoiceHeaderv5.Subreports["REDwInvoiceDetailPaymentPrMessage.rpt"].SetDataSource(table11);

            // TJB  RPCR_056  June-2013
            DataTable table12 = new NZPostOffice.ODPS.DataControls.Report.InvoiceDetailAllowanceBreakdownDataSet(new RInvoiceDetailAllowanceBreakdown());
            this.reDwInvoiceHeaderv5.Subreports["REDwInvoiceDetailAllowanceBreakdown.rpt"].SetDataSource(table12);

            // TJB note June-2013
            // This must follow all table definitions (add any new ones above)
            viewer.RefreshReport();

            this.RetrieveEnd += new System.EventHandler(DwInvoiceHeaderv5_RetrieveEnd);
            this.ResumeLayout(false);
        }

        void reDwInvoiceHeaderv5_RefreshReport(object sender, EventArgs e)
        {
            this.reDwInvoiceHeaderv5.SetParameterValue("end_date", this.eDate.GetValueOrDefault());
        }

        void DwInvoiceHeaderv5_RetrieveEnd(object sender, System.EventArgs e)
        {
            try
            {
                table = new NZPostOffice.ODPS.DataControls.Report.InvoiceHeaderv5DataSet(this.bindingSource.DataSource);
                this.reDwInvoiceHeaderv5.SetDataSource(table);

                DataTable table2 = new NZPostOffice.ODPS.DataControls.Report.InvoiceHeaderPostaddressDataSet(new Metex.Core.EntityBindingList<InvoiceHeaderPostaddress>(InvoiceHeaderPostaddress.GetAllInvoiceHeaderPostaddress(this.EndDate)));
                this.reDwInvoiceHeaderv5.Subreports["REDwInvoiceHeaderPostaddress.rpt"].SetDataSource(table2);

                System.Collections.ArrayList paymentInvoiceId = new System.Collections.ArrayList();
                System.Collections.ArrayList cInvoiceNo = new System.Collections.ArrayList();

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (!paymentInvoiceId.Contains(table.Rows[i]["PaymentInvoiceId"]) && !cInvoiceNo.Contains(table.Rows[i]["CinvoiceNo"]))
                    {
                        paymentInvoiceId.Add(table.Rows[i]["PaymentInvoiceId"]);
                        cInvoiceNo.Add(table.Rows[i]["CinvoiceNo"]);

                        DataTable table3 = new NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentDataSet(new Metex.Core.EntityBindingList<InvoiceDetailPayment>(InvoiceDetailPayment.GetAllInvoiceDetailPayment(this.GetItem<InvoiceHeaderv5>(i).PaymentInvoiceId, this.EndDate, this.GetItem<InvoiceHeaderv5>(i).ContractorContractorSupplierNo, this.GetItem<InvoiceHeaderv5>(i).ContractNo)));
                        table3S.Merge(table3);

                        DataTable table4 = new NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentPrDataSet(new Metex.Core.EntityBindingList<InvoiceDetailPaymentPr>(InvoiceDetailPaymentPr.GetAllInvoiceDetailPaymentPr(this.GetItem<InvoiceHeaderv5>(i).PaymentInvoiceId, this.EndDate)));
                        table4S.Merge(table4);

                        DataTable table5 = new NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentDedDataSet(new Metex.Core.EntityBindingList<InvoiceDetailPaymentDed>(InvoiceDetailPaymentDed.GetAllInvoiceDetailPaymentDed(this.GetItem<InvoiceHeaderv5>(i).PaymentInvoiceId)));
                        table5S.Merge(table5);

                        DataTable table7 = new NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentPrDetailkmDataSet(new Metex.Core.EntityBindingList<InvoiceDetailPaymentPrDetailkm>(InvoiceDetailPaymentPrDetailkm.GetAllInvoiceDetailPaymentPrDetailkm(this.GetItem<InvoiceHeaderv5>(i).PaymentInvoiceId, this.GetItem<InvoiceHeaderv5>(i).ContractNo, this.GetItem<InvoiceHeaderv5>(i).ContractorContractorSupplierNo, this.StartDate, this.EndDate)));
                        table7S.Merge(table7);

                        DataTable table8 = new NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentPrDetailcpDataSet(new Metex.Core.EntityBindingList<InvoiceDetailPaymentPrDetailcp>(InvoiceDetailPaymentPrDetailcp.GetAllInvoiceDetailPaymentPrDetailcp(this.GetItem<InvoiceHeaderv5>(i).PaymentInvoiceId, this.GetItem<InvoiceHeaderv5>(i).ContractNo, this.GetItem<InvoiceHeaderv5>(i).ContractorContractorSupplierNo, this.StartDate, this.EndDate)));
                        table8S.Merge(table8);

                        DataTable table9 = new NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentPrDetailxpDataSet(new Metex.Core.EntityBindingList<InvoiceDetailPaymentPrDetailxp>(InvoiceDetailPaymentPrDetailxp.GetAllInvoiceDetailPaymentPrDetailxp(this.GetItem<InvoiceHeaderv5>(i).PaymentInvoiceId, this.GetItem<InvoiceHeaderv5>(i).ContractNo, this.GetItem<InvoiceHeaderv5>(i).ContractorContractorSupplierNo, this.StartDate, this.EndDate)));
                        table9S.Merge(table9);

                        DataTable table10 = new NZPostOffice.ODPS.DataControls.Report.InvoiceDetailPaymentPrDetailppDataSet(new Metex.Core.EntityBindingList<InvoiceDetailPaymentPrDetailpp>(InvoiceDetailPaymentPrDetailpp.GetAllInvoiceDetailPaymentPrDetailpp(this.GetItem<InvoiceHeaderv5>(i).PaymentInvoiceId, this.GetItem<InvoiceHeaderv5>(i).ContractNo, this.GetItem<InvoiceHeaderv5>(i).ContractorContractorSupplierNo, this.StartDate, this.EndDate)));
                        table10S.Merge(table10);

                        // TJB  RPCR_056  June-2013
                        // Subreport parameter
                        DataTable table12 = new NZPostOffice.ODPS.DataControls.Report.InvoiceDetailAllowanceBreakdownDataSet(new Metex.Core.EntityBindingList<InvoiceDetailAllowanceBreakdown>(InvoiceDetailAllowanceBreakdown.GetAllInvoiceDetailAllowanceBreakdown(this.GetItem<InvoiceHeaderv5>(i).PaymentInvoiceId)));
                        table12S.Merge(table12);
                    }
                }
                this.reDwInvoiceHeaderv5.Subreports["REDwInvoiceDetailPayment.rpt"].SetDataSource(table3S);
                this.reDwInvoiceHeaderv5.Subreports["REDInvoiceDetailPaymentPr.rpt"].SetDataSource(table4S);
                this.reDwInvoiceHeaderv5.Subreports["REDInvoiceDetailPaymentDed.rpt"].SetDataSource(table5S);
                this.reDwInvoiceHeaderv5.Subreports["REDwInvoiceDetailPaymentPrDetailkm.rpt"].SetDataSource(table7S);
                this.reDwInvoiceHeaderv5.Subreports["REDwInvoiceDetailPaymentPrDetailcp.rpt"].SetDataSource(table8S);
                this.reDwInvoiceHeaderv5.Subreports["REDwInvoiceDetailPaymentPrDetailxp.rpt"].SetDataSource(table9S);
                this.reDwInvoiceHeaderv5.Subreports["REDwInvoiceDetailPaymentPrDetailpp.rpt"].SetDataSource(table10S);
                // TJB  RPCR_056  June-2013
                this.reDwInvoiceHeaderv5.Subreports["REDwInvoiceDetailAllowanceBreakdown.rpt"].SetDataSource(table12S);
            }
            catch (Exception ex) 
            {
                string errmsg;
                errmsg = ex.Message;
            }

            viewer.RefreshReport();
        }
        #endregion

        private DateTime? eDate;
        private System.Data.DataTable table;

        private DataTable table3S = new DataTable();
        private DataTable table4S = new DataTable();
        private DataTable table5S = new DataTable();
        private DataTable table7S = new DataTable();
        private DataTable table8S = new DataTable();
        private DataTable table9S = new DataTable();
        private DataTable table10S = new DataTable();
        // TJB  RPCR_056  June-2013
        private DataTable table12S = new DataTable();

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
        private NZPostOffice.ODPS.DataControls.Report.REDwInvoiceHeaderv5 reDwInvoiceHeaderv5;
    }
}
