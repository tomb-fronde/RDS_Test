using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;
using System;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DContractFixedAssets
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractFixedAssets);
            // 
            // n_39995586
            // 
            this.n_39995586 = new Label();
            this.n_39995586.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F,System.Drawing.FontStyle.Bold);
            this.n_39995586.Location = new System.Drawing.Point(4, 4);
            this.n_39995586.Name = "n_39995586";
            this.n_39995586.Size = new System.Drawing.Size(125, 13);
            this.n_39995586.TabIndex = 0;
            this.n_39995586.Text = "Fixed Asset Register";
            this.n_39995586.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            tbPanel = new TableLayoutPanel();
            this.tbPanel.AutoScroll = true;
            this.tbPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            this.tbPanel.ColumnCount = 1;
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel.Location = new System.Drawing.Point(0, 20);
            this.tbPanel.Name = "tableLayoutPanel1";
            this.tbPanel.RowCount = 1;
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel.Size = new System.Drawing.Size(539, 274);
            this.Controls.Add(n_39995586);
            this.Controls.Add(tbPanel);
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            //this.RetrieveEnd += new System.EventHandler(DContractFixedAssetsTest_RetrieveEnd);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            this.SizeChanged += new System.EventHandler(DContractFixedAssets_SizeChanged);
            this.RetrieveStart += new Metex.Windows.RetrieveEventHandler(DContractFixedAssets_RetrieveStart);
        }

        void DContractFixedAssets_RetrieveStart(object sender, Metex.Windows.RetrieveEventArgs e)
        {
            tbPanel.Controls.Clear();
        }

        void DContractFixedAssets_SizeChanged(object sender, System.EventArgs e)
        {
            //this.tbPanel.Width = this.Width - tbPanel.Left;
            //this.tbPanel.Height = this.Height - this.tbPanel.Top;
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
                    if  (this.BindingSource.List.IndexOf(((DContractFixedAssetsTest)tbPanel.Controls[i]).DataSource) >= 0)
                    {
                    }
                    else
                    {
                        tbPanel.Controls.RemoveAt(i);
                        break;
                    }
                    
                }

            }
            else if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemAdded)
            {
                DContractFixedAssetsTest ldw_temp;
                ldw_temp = new DContractFixedAssetsTest();
                ldw_temp.Name = (e.NewIndex).ToString();
                ldw_temp.Size = new System.Drawing.Size(500, 80);
                ldw_temp.BindingSource.DataSource = this.BindingSource.List[e.NewIndex];
                ldw_temp.Click += new System.EventHandler(ldw_temp_Click);
                ldw_temp.TextBoxLostFocus += new System.EventHandler(ldw_temp_TextBoxLostFocus);
                //((TextBox)(ldw_temp.GetControlByName("fa_fixed_asset_no"))).ReadOnly = false;
                this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                tbPanel.SetRow(ldw_temp, e.NewIndex);
                tbPanel.Controls.Add(ldw_temp, 0, e.NewIndex);

                DddwFixedAssetType l_entity = new DddwFixedAssetType();
                l_entity.FatDescription = "";
                ldw_temp.GetChild("fat_id").InsertItem<DddwFixedAssetType>(0,l_entity);
                ((Metex.Windows.DataEntityCombo)ldw_temp.GetControlByName("fat_id")).Click += new System.EventHandler(DContractFixedAssets_Click);
                if (((ContractFixedAssets)ldw_temp.DataSource).ContractNo == null)
                {
                    ((Metex.Windows.DataEntityCombo)ldw_temp.GetControlByName("fat_id")).Value = "";
                }
            }
            else
            {
            }
        }

        public event EventHandler TextBoxLostFocus;

        void ldw_temp_TextBoxLostFocus(object sender, System.EventArgs e)
        {
            TextBoxLostFocus(sender, e);
        }

        void DContractFixedAssets_Click(object sender, System.EventArgs e)
        {
            if (((DddwFixedAssetType)((Metex.Windows.DataEntityCombo)sender).Items[0]).FatId == null)
            {
                ((Metex.Windows.DataEntityCombo)sender).InnerDataUserControl.DeleteItemAt(0);
            }
        }

        void ldw_temp_Click(object sender, System.EventArgs e)
        {
            this.SetCurrent(this.bindingSource.List.IndexOf(((DContractFixedAssetsTest)sender).DataSource as ContractFixedAssets));
        }

        void DContractFixedAssetsTest_RetrieveEnd(object sender, System.EventArgs e)
        {
            for (int i = 0; i < this.RowCount; i++)
            {
                DContractFixedAssetsTest ldw_temp;
                ldw_temp = new DContractFixedAssetsTest();
                ldw_temp.Name = i.ToString();
                ldw_temp.Size = new System.Drawing.Size(500, 140);
                ldw_temp.BindingSource.DataSource = this.BindingSource.List[i];
                this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                tbPanel.SetRow(ldw_temp, i);
                tbPanel.Controls.Add(ldw_temp, 0, i);
            }
        }
        private System.Windows.Forms.Label n_39995586;
        private TableLayoutPanel tbPanel;

        #endregion
    }
}
