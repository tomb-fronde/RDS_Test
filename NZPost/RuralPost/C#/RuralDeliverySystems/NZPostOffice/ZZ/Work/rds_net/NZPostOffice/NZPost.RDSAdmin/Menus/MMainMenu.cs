namespace NZPostOffice.RDSAdmin.Menus 
{
    using System;
    using System.Windows.Forms;
    using NZPostOffice.Shared.VisualComponents;
    
    
    public class MMainMenu : MFrame 
    {
        public ToolStripMenuItem m_refresh;

        public ToolStripMenuItem m_;

        public ToolStripMenuItem m_testing;

        Form currentForm;

        public MMainMenu(Form form)
            : base()
        {
            currentForm = form;
        }

        public override void BuildMenu(Form form)
        {
            //base.BuildMenu(form);
            MenuStrip = new MenuStrip();
            form.Controls.Add(MenuStrip);
            form.MainMenuStrip = MenuStrip;
            m_file = new ToolStripMenuItem();
            m_help = new ToolStripMenuItem();
            MenuStrip.Items.Add(m_file);
            MenuStrip.Items.Add(m_help);
            m_file.Text = "File";

            m_save = new ToolStripMenuItem();
            m_refresh = new ToolStripMenuItem();
            m_testing = new ToolStripMenuItem();
            m_exit = new ToolStripMenuItem();
            m_file.DropDownItems.Add(m_save);
            m_file.DropDownItems.Add(m_refresh);
            m_file.DropDownItems.Add(new ToolStripSeparator());
            m_file.DropDownItems.Add(m_testing);
            m_file.DropDownItems.Add(m_exit);

            m_save.Text = "Save";
            m_save.ShortcutKeys = Keys.Control | Keys.S;
            m_save.Click += new EventHandler(m_save_Click);
            m_exit.Text = "Exit";
            m_exit.ShortcutKeys = Keys.Alt | Keys.F4;
            m_exit.Click += new EventHandler(m_exit_Click);
            m_refresh.Text = "Refresh";
            m_refresh.ShortcutKeys = Keys.F5;
            m_refresh.Click += new EventHandler(m_refresh_Click);

            m_testing.Tag = "Town Suburb Clean up";
            m_testing.Text = "Town/Suburb Cleanup";
            //!m_testing.microhelp = "Town Suburb Clean up";
            m_testing.Click += new EventHandler(m_testing_Click);

            // 
            // m_help
            // 
            m_help.Text = "&Help";
            m_helptopics = new ToolStripMenuItem();
            m_dash61 = new ToolStripSeparator();
            m_about = new ToolStripMenuItem();
            m_help.DropDownItems.Add(m_helptopics);
            m_help.DropDownItems.Add(new ToolStripSeparator());
            m_help.DropDownItems.Add(m_about);
            // 
            // m_helptopics
            // 
            m_helptopics.Text = "&Help Topics";
            m_helptopics.ToolTipText = "Displays help topics";
            // 
            // m_dash61
            // 
            m_dash61.Text = "-";
            // 
            // m_about
            // 
            m_about.Text = "&About";
            m_about.ToolTipText = "Displays program information";
            m_about.Click += new EventHandler(m_about_Click);
        }

        private void m_exit_Click(object sender, EventArgs e)
        {
            ((FormBase)this.currentForm).pfc_exit();
        }

        private void m_save_Click(object sender, EventArgs e)
        {
            ((FormBase)this.currentForm).pfc_save();
        }

        private void m_about_Click(object sender, EventArgs e)
        {
            new WAbout().ShowDialog(this.currentForm);
        }

        private void m_testing_Click(object sender, EventArgs e)
        {
            
            //  TWC 06/10/2003 
            //  call 4567 - will clean up town_suburb table
            /*delete from town_suburb*/
              int SQLCode=0;
              string SQLErrText=string.Empty;
            //!StaticVariables.ServiceInterface.MMainMenu_m_testing_Click_2(ref SQLErrText,ref SQLCode);
            if (SQLCode != 0) 
            {
                MessageBox.Show("There was an error deleting Town/Suburb entries. " 
                               + "Cleanup will not proceed."
                               , "Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            /*  insert into town_suburb
             *     (select distinct tc_id, sl_id from address
             *       where tc_id is not null
             *         and sl_id is not null)
             *  int SQLCode=0;
             *  string SQLErrText=string.Empty;
             */
            //!StaticVariables.ServiceInterface.MMainMenu_m_testing_Click_1(ref SQLErrText,ref SQLCode);
            if (SQLCode != 0) 
            {
                MessageBox.Show("There was an error inserting Town/Suburb entries. " 
                              + "Cleanup will not proceed."
                              , "Error"
                              , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                MessageBox.Show("Clean up process for Town/Suburb entries in the database " 
                              + "has completed successfully."
                              , "Success");
            }
             
        }

        private void m_refresh_Click(object sender, EventArgs e)
        {
            // !of_sendmessage("ue_refresh");
            of_sendmessage_ue_refresh();
        }

        public override int of_sendmessage(string as_message)
        {
            
            return ((FormBase)this.currentForm).pfc_save();

        }
        public  void of_sendmessage_ue_refresh()
        {

             ((FormBase)this.currentForm).ue_refresh();

        } 
    }
}
