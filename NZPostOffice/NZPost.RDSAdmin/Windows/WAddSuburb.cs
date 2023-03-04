using System;
using System.Data;
using System.Windows.Forms;
using NZPostOffice.Shared.Windows;
using NZPostOffice.Shared;
using NZPostOffice.RDSAdmin.DataControls.Security;
using NZPostOffice.RDSAdmin.Entity.Security;
using NZPostOffice.RDSAdmin.DataService;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.RDSAdmin
{
    public class WAddSuburb : WResponse
    {
        public Metex.Windows.DataUserControl idwc_town;

        public bool ib_townadded;

        public bool ib_townchanged;

        public int il_suburbID;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_add;

        public Label st_3;

        public Label st_2;

        public DwTownDddw dw_town;

        public Label current_towns_t;

        public DwTowncity dw_current_towns;

        public Label st_1;

        public DwSuburb dw_suburb;

        public Button cb_close;

        public WAddSuburb(int ll_suburb_id)
        {
            il_suburbID = ll_suburb_id;
            this.InitializeComponent();
            //!this.of_bypass_security(true);
            idwc_town = dw_town.GetChild("tc_id");
            dw_suburb.Retrieve(il_suburbID);
            dw_town.Retrieve();
            dw_current_towns.Retrieve(il_suburbID);
            ib_townadded = false;
            dw_suburb.Enabled = false;
            ib_townchanged = false;
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            //  TJB SR4616  1-Nov-2004
            //  Whole window  ( w_add_suburb) added
            //  See also dw_towncity, dw_suburb_town, dddw_towncity
            //  Called from w_main_mdi.dw_detail.doubleclicked
        }

        public override void close()
        {
            base.close();
            //!  SetPointer(arrow);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_add = new System.Windows.Forms.Button();
            this.st_3 = new System.Windows.Forms.Label();
            this.st_2 = new System.Windows.Forms.Label();
            this.current_towns_t = new System.Windows.Forms.Label();
            this.st_1 = new System.Windows.Forms.Label();
            this.cb_close = new System.Windows.Forms.Button();
            this.dw_current_towns = new NZPostOffice.RDSAdmin.DataControls.Security.DwTowncity();
            this.dw_town = new NZPostOffice.RDSAdmin.DataControls.Security.DwTownDddw();
            this.dw_suburb = new NZPostOffice.RDSAdmin.DataControls.Security.DwSuburb();
            this.SuspendLayout();
            // 
            // cb_add
            // 
            this.cb_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_add.Location = new System.Drawing.Point(120, 170);
            this.cb_add.Name = "cb_add";
            this.cb_add.Size = new System.Drawing.Size(75, 23);
            this.cb_add.TabIndex = 5;
            this.cb_add.Text = "Add";
            this.cb_add.Click += new System.EventHandler(this.cb_add_clicked);
            // 
            // st_3
            // 
            this.st_3.BackColor = System.Drawing.SystemColors.Control;
            this.st_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_3.Location = new System.Drawing.Point(40, 16);
            this.st_3.Name = "st_3";
            this.st_3.Size = new System.Drawing.Size(44, 16);
            this.st_3.TabIndex = 6;
            this.st_3.Text = "Suburb: ";
            // 
            // st_2
            // 
            this.st_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_2.Location = new System.Drawing.Point(15, 44);
            this.st_2.Name = "st_2";
            this.st_2.Size = new System.Drawing.Size(66, 16);
            this.st_2.TabIndex = 7;
            this.st_2.Text = "Select town: ";
            this.st_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // current_towns_t
            // 
            this.current_towns_t.BackColor = System.Drawing.SystemColors.Control;
            this.current_towns_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.current_towns_t.ForeColor = System.Drawing.SystemColors.WindowText;
            this.current_towns_t.Location = new System.Drawing.Point(8, 72);
            this.current_towns_t.Name = "current_towns_t";
            this.current_towns_t.Size = new System.Drawing.Size(72, 16);
            this.current_towns_t.TabIndex = 8;
            this.current_towns_t.Text = "Current towns";
            // 
            // st_1
            // 
            this.st_1.BackColor = System.Drawing.SystemColors.Control;
            this.st_1.Font = new System.Drawing.Font("Arial", 7F);
            this.st_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_1.Location = new System.Drawing.Point(8, 182);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(76, 13);
            this.st_1.TabIndex = 9;
            this.st_1.Text = "w_add_suburb";
            // 
            // cb_close
            // 
            this.cb_close.Location = new System.Drawing.Point(216, 169);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(75, 23);
            this.cb_close.TabIndex = 4;
            this.cb_close.Text = "&Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            // 
            // dw_current_towns
            // 
            this.dw_current_towns.BackColor = System.Drawing.SystemColors.Window;
            this.dw_current_towns.FilterString = "";
            this.dw_current_towns.Location = new System.Drawing.Point(82, 72);
            this.dw_current_towns.Name = "dw_current_towns";
            this.dw_current_towns.Size = new System.Drawing.Size(211, 91);
            this.dw_current_towns.SortString = "";
            this.dw_current_towns.TabIndex = 3;
            // 
            // dw_town
            // 
            this.dw_town.BackColor = System.Drawing.SystemColors.Control;
            this.dw_town.FilterString = "";
            this.dw_town.Location = new System.Drawing.Point(80, 40);
            this.dw_town.Name = "dw_town";
            this.dw_town.Size = new System.Drawing.Size(214, 24);
            this.dw_town.SortString = "";
            this.dw_town.TabIndex = 2;
            // 
            // dw_suburb
            // 
            this.dw_suburb.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dw_suburb.FilterString = "";
            this.dw_suburb.Location = new System.Drawing.Point(80, 12);
            this.dw_suburb.Name = "dw_suburb";
            this.dw_suburb.Size = new System.Drawing.Size(216, 24);
            this.dw_suburb.SortString = "";
            this.dw_suburb.TabIndex = 1;
            // 
            // WAddSuburb
            // 
            this.ClientSize = new System.Drawing.Size(299, 205);
            this.Controls.Add(this.dw_current_towns);
            this.Controls.Add(this.cb_add);
            this.Controls.Add(this.st_3);
            this.Controls.Add(this.st_2);
            this.Controls.Add(this.dw_town);
            this.Controls.Add(this.current_towns_t);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.dw_suburb);
            this.Controls.Add(this.cb_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WAddSuburb";
            this.Text = "Link Town to Suburb";
            this.ControlBox = false;
            this.ResumeLayout(false);

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

        public virtual void cb_add_clicked(object sender, EventArgs e)
        {
            int li_rc;
            int ll_row;
            int ll_newrow;
            int? ll_newTownId;
            string ls_newTown;
            //  There is always going to be a long list of towns so this 
            //  'if' is redundant ...
            if (idwc_town.RowCount > 0)
            {
                NZPostOffice.RDSAdmin.Entity.Security.DddwTowncity
                    dddw = dw_town.GetItemFromDropDown();
                //ll_row = idwc_town.GetRow();
                ls_newTown = dddw.TcName;
                ll_newTownId = dddw.TcId;
                //  Insert a new row in the currect towns list
                //ll_newrow = dw_current_towns.InsertRow(0);
                //dw_current_towns.ScrollToRow(ll_newrow);
                //  Populate the row
                Towncity town = Towncity.NewTowncity(il_suburbID);
                town.TcId = ll_newTownId;
                town.TcName = ls_newTown;
                dw_current_towns.InsertItem<Towncity>(dw_current_towns.RowCount, town);
                dw_current_towns.SetCurrent(dw_current_towns.RowCount);
                ib_townadded = true;
            }
        }

        //!protected class DwTown : URadDW
        //{
        //    WAddSuburb window;

        //    public DwTown(DataControlPanel dcp)
        //        : base(dcp)
        //    {
        //        window = dcp.FindForm() as WAddSuburb;
        //    }

        //    public override int itemchanged(int row, DataColumn dwo, string data)
        //    {
        //        base.itemchanged(row, dwo, data);
        //        window.ib_townchanged = true;

        //        return 1;
        //    }

        //    public override int pfc_preupdate()
        //    {
        //        base.pfc_preupdate();
        //        return 0;
        //    }
        //}

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            //!  base.clicked();
            int ll_rows;
            int ll_row;
            int ll_townID;
            int ll_answer;

            int SQLCode = 0;
            string SQLErrText = string.Empty;

            //  If at least one town has been added, ask whether to
            //  save the additions.
            if (ib_townadded)
            {
                ll_answer = MessageBox.Show("Save new town list?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 2;
            }
            else
            {
                ll_answer = 2;
            }
            if (ll_answer == 1)
            {
                //  Step through the list of 'current towns' to see which 
                //  ones need to be added.
                //  There are only a few, so it doesn't matter if we
                //  examine all of them and only insert one or two.
                if (dw_current_towns.RowCount > 0)
                {
                    for (ll_row = 0; ll_row < dw_current_towns.RowCount; ll_row++)
                    {
                        ll_townID = dw_current_towns.GetValue<int>(ll_row, "TcId");
                        //  Check to see if the entry already exists
                        /*    select tc_id  into :ll_answer  from town_suburb   
                              where tc_id = :ll_townID   and sl_id = :il_suburbID;

                       if (!(ll_answer == ll_townID))
                        {
                             insert into town_suburb  (  tc_id, sl_id )  values  (  :ll_townID,  :il_suburbID );

                        }*/
                        MainMdiService.InsertTownSuburb(ll_townID, il_suburbID);
                    }
                }
            }
            //  If the town dropdown list is changed, whether or not the  
            //  new town is added to the current town list, the town window
            //  needs to be refreshed to avoid PB asking whether to save 
            //  the updated information. [There must be a better way to do 
            //  this, but I haven't found it yet - tjb]
            if (ib_townchanged)
            {
                dw_town.Retrieve();
            }
            this.Close(); // close(parent);
        }
    }
}
