using System.Windows.Forms;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DMailCarriedForm
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
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.MailCarriedForm);
            //panel
            tbPanel = new TableLayoutPanel();
            this.tbPanel.AutoScroll = true;
            this.tbPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tbPanel.ColumnCount = 1;
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel.Location = new System.Drawing.Point(0, 0);
            this.tbPanel.Name = "tableLayoutPanel1";
            this.tbPanel.RowCount = 1;
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel.Size = new System.Drawing.Size(538, 230);
            this.Controls.Add(tbPanel);
            this.Size = new System.Drawing.Size(600, 230);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            this.SizeChanged += new System.EventHandler(DMailCarriedForm_SizeChanged);

        }

        void DMailCarriedForm_SizeChanged(object sender, System.EventArgs e)
        {
            //this.tbPanel.Width = this.Width - tbPanel.Left;
            //this.tbPanel.Height = this.Height - this.tbPanel.Top;
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (this.RowCount == 0)
            {
                tbPanel.Controls.Clear();//return;
            }

            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemDeleted)
            {
                //tbPanel.Controls.RemoveAt(e.NewIndex);
                tbPanel.AutoSize = true;
                tbPanel.Controls.Clear();
                for (int i = 0; i < this.RowCount; i++)
                {
                    
                    DMailCarriedFormTest ldw_temp;
                    ldw_temp = new DMailCarriedFormTest();
                    ldw_temp.Size = new System.Drawing.Size(500, 200);
                    ldw_temp.BindingSource.DataSource = this.BindingSource.List[i];
                    //((TextBox)(ldw_temp.GetControlByName("fa_fixed_asset_no"))).ReadOnly = false;
                    this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                    tbPanel.SetRow(ldw_temp, i);
                    tbPanel.Controls.Add(ldw_temp, 0, 0);
                }
            }
            else if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemAdded)
            {
                DMailCarriedFormTest ldw_temp;
                ldw_temp = new DMailCarriedFormTest();
                ldw_temp.Name = (e.NewIndex).ToString();
                ldw_temp.Size = new System.Drawing.Size(500, 200);
                ldw_temp.BindingSource.DataSource = this.BindingSource.List[e.NewIndex];
                ldw_temp.CellButtonClick += new System.EventHandler(ldw_temp_CellButtonClick);
                //((TextBox)(ldw_temp.GetControlByName("fa_fixed_asset_no"))).ReadOnly = false;
                this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
                tbPanel.SetRow(ldw_temp, e.NewIndex);
                tbPanel.Controls.Add(ldw_temp, 0, e.NewIndex);
            }
            else
            {
            }
        }

        void ldw_temp_CellButtonClick(object sender, System.EventArgs e)
        {
            CellButtonClick(sender, e);
        }
        private TableLayoutPanel tbPanel;

        #endregion
    }
}
