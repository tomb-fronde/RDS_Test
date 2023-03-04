using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace NZPostOffice.Shared.VisualComponents
{
    public class FramPopMenus : ContextMenuStrip
    {
        private System.Windows.Forms.ContextMenuStrip FramPopMenu;
        private System.Windows.Forms.ToolStripMenuItem frameBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sheetBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem leftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bottomToolStripMenuItem;
        //private System.Windows.Forms.ToolStripMenuItem floatingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPowerTipToolStripMenuItem;

        private  ToolStrip toolStrip;

        private ToolStripButton t_exit;

        public FramPopMenus(ToolStrip toolstrip)
        {
            InitializeComponent();
            toolStrip = toolstrip;
        }

        void InitializeComponent()
        {
            this.frameBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sheetBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.leftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.showTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPowerTipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // FramPop
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frameBarToolStripMenuItem,
            this.sheetBarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.leftToolStripMenuItem,
            this.topToolStripMenuItem,
            this.rightToolStripMenuItem,
            this.bottomToolStripMenuItem,
            this.toolStripMenuItem2,
            this.showTextToolStripMenuItem,
            this.showPowerTipToolStripMenuItem});
            this.Name = "FramPopMenu";
            this.Size = new System.Drawing.Size(162, 214);
            // 
            // frameBarToolStripMenuItem
            // 
            this.frameBarToolStripMenuItem.Name = "frameBarToolStripMenuItem";
            this.frameBarToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.frameBarToolStripMenuItem.Text = "FrameBar";
            this.frameBarToolStripMenuItem.Click += new EventHandler(frameBarToolStripMenuItem_Click);
            // 
            // sheetBarToolStripMenuItem
            // 
            this.sheetBarToolStripMenuItem.Name = "sheetBarToolStripMenuItem";
            this.sheetBarToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.sheetBarToolStripMenuItem.Text = "SheetBar";
            this.sheetBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sheetBarToolStripMenuItem.Click += new EventHandler(sheetBarToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // leftToolStripMenuItem
            // 
            this.leftToolStripMenuItem.CheckOnClick = true;
            this.leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            this.leftToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.leftToolStripMenuItem.Text = "Left";
            this.leftToolStripMenuItem.Click += new System.EventHandler(this.leftToolStripMenuItem_Click);
            // 
            // topToolStripMenuItem
            // 
            this.topToolStripMenuItem.Checked = true;
            this.topToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topToolStripMenuItem.Name = "topToolStripMenuItem";
            this.topToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.topToolStripMenuItem.Text = "Top";
            this.topToolStripMenuItem.Click += new System.EventHandler(this.topToolStripMenuItem_Click);
            // 
            // rightToolStripMenuItem
            // 
            this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            this.rightToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.rightToolStripMenuItem.Text = "Right";
            this.rightToolStripMenuItem.Click += new System.EventHandler(this.rightToolStripMenuItem_Click);
            // 
            // bottomToolStripMenuItem
            // 
            this.bottomToolStripMenuItem.Name = "bottomToolStripMenuItem";
            this.bottomToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.bottomToolStripMenuItem.Text = "Bottom";
            this.bottomToolStripMenuItem.Click += new System.EventHandler(this.bottomToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 6);
            // 
            // showTextToolStripMenuItem
            // 
            this.showTextToolStripMenuItem.Checked = true;
            this.showTextToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTextToolStripMenuItem.Name = "showTextToolStripMenuItem";
            this.showTextToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.showTextToolStripMenuItem.Text = "Show Text";
            this.showTextToolStripMenuItem.Click += new System.EventHandler(this.showTextToolStripMenuItem_Click);
            // 
            // showPowerTipToolStripMenuItem
            // 
            this.showPowerTipToolStripMenuItem.Checked = true;
            this.showPowerTipToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPowerTipToolStripMenuItem.Name = "showPowerTipToolStripMenuItem";
            this.showPowerTipToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.showPowerTipToolStripMenuItem.Text = "Show Power Tips";
            this.showPowerTipToolStripMenuItem.Click += new System.EventHandler(this.showPowerTipToolStripMenuItem_Click);
        }

        private void sheetBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.sheetBarToolStripMenuItem.Checked = !(this.sheetBarToolStripMenuItem.Checked);
            this.toolStrip.Visible = this.sheetBarToolStripMenuItem.Checked;
        }

        private void frameBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.frameBarToolStripMenuItem.Checked = !(this.frameBarToolStripMenuItem.Checked);
            if (this.frameBarToolStripMenuItem.Checked)
            {
                toolStrip.Items[0].Visible = true;
            }
            else
            {
                if (toolStrip.Items.Count>1)
                    toolStrip.Items[0].Visible = false ;
            }
        }


        private void showPowerTipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.showPowerTipToolStripMenuItem.Checked = !(this.showPowerTipToolStripMenuItem.Checked);
            this.toolStrip.ShowItemToolTips = this.showPowerTipToolStripMenuItem.Checked;
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.rightToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.bottomToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
        }

        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.topToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rightToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.bottomToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.leftToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.bottomToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.leftToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
        }

        private void bottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.rightToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.leftToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
        }


        private void showTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.showTextToolStripMenuItem.Checked = !(this.showTextToolStripMenuItem.Checked);
            for (int i = 0; i < this.toolStrip.Items.Count; i++)
            {
                toolStrip.Items[i].DisplayStyle = this.showTextToolStripMenuItem.Checked ? ToolStripItemDisplayStyle.ImageAndText : ToolStripItemDisplayStyle.Image;
            }
        }
    }
}
