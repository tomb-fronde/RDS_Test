using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public partial class DragDropTest : Form
    {
        public DragDropTest()
        {
            InitializeComponent();

            //this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(listBox1_MouseDown);
//            listBox1.DragDrop += new DragEventHandler(listBox1_DragDrop);
//            listBox1.DragEnter += new DragEventHandler(listBox1_DragEnter);
//            listBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(listBox2_MouseDown);
            listBox2.DragDrop += new DragEventHandler(listBox2_DragDrop);
            listBox2.DragEnter += new DragEventHandler(listBox2_DragEnter);
            listBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseClick);
            this.cb_close.Click += new System.EventHandler(this.cb_close_Click);
            
            Console.WriteLine("DragDropTest started");
            listBox1.BeginUpdate();
            listBox1.Items.Add("Item 1");
            listBox1.Items.Add("Item 2");
            listBox1.Items.Add("Item 3");
            listBox1.Items.Add("Item 4");
            listBox1.Items.Add("Item 5");
            listBox1.Items.Add("Item 6");
            listBox1.Items.Add("Item 7");
            listBox1.Items.Add("Item 8");
            listBox1.Items.Add("Item 9");
            listBox1.Items.Add("Item 10");
            listBox1.EndUpdate();
        }

        private void listSelectedItems(string name)
        {
            int ndx, nSelectedItems;
            string listItem;

            nSelectedItems = listBox1.SelectedIndices.Count;
            for (int i = nSelectedItems; i > 0; i--)
            {
                ndx = listBox1.SelectedIndices[(i - 1)];
                listItem = (string)listBox1.Items[ndx];
                Console.WriteLine(name + ": Item " + i.ToString()
                                  + ", Index = " + ndx.ToString()
                                  + ", Value " + listItem);
            }
            listItem = "";
        }

        private string getSelectedItemsList()
        {
            int ndx, nSelectedItems;
            string thisItemsList = "";

            nSelectedItems = listBox1.SelectedIndices.Count;
            for (int i = 0; i < nSelectedItems; i++)
            {
                ndx = listBox1.SelectedIndices[i];
                if (i == 0)
                    thisItemsList = ndx.ToString();
                else
                    thisItemsList += "," + ndx.ToString();
            }
            return thisItemsList;
        }

        private string getSelectedItemsList1()
        {
            string thisItemsList = "";
            int [] xxx;
            xxx = new int[100];

            listBox1.SelectedIndices.CopyTo(xxx, 0);
            foreach(int ndx in xxx)
            {
                if (thisItemsList == "")
                    thisItemsList = ndx.ToString();
                else
                    thisItemsList += "," + ndx.ToString();
            }
            
            foreach(int ndx in listBox1.SelectedIndices)
            {
                if (thisItemsList == "")
                    thisItemsList = ndx.ToString();
                else
                    thisItemsList += "," + ndx.ToString();
            }
            return thisItemsList;
        }

        private string getSelectedItemsList2()
        {
            int nSelectedItems, nItems;
            string thisItemsList = "", listItem = "", t;

            nSelectedItems = 0;
            nItems = listBox1.Items.Count;
            for (int i = 0; i < nItems; i++)
            {
                if (listBox1.GetSelected(i))
                {
                    nSelectedItems++;
                    listItem = (string)listBox1.Items[i];
                    t = listItem;
                    if (nSelectedItems == 0)
                        thisItemsList = i.ToString();
                    else
                        thisItemsList += "," + i.ToString();
                }
            }
            return thisItemsList;
        }

        private void list1AddSelectedItems()
        {
            int ndx1, nSelectedItems;
            string listItem;

            nSelectedItems = listBox2.SelectedIndices.Count;

            int nRows = listBox2.Items.Count;
            for (int ndx = 0; ndx < nRows; ndx++)
            {
                if (listBox2.GetSelected(ndx))
                {
                    listItem = (string)listBox2.Items[ndx];
                    ndx1 = listBox1.SelectedIndex;
                    Console.WriteLine("listBox1: Add Item Index = " + ndx.ToString()
                                       + ", Value " + listItem);
                    if (ndx1 < 0)
                        listBox1.Items.Add(listItem);
                    else
                        listBox1.Items.Insert(ndx1, listItem);
                }
            }
        }

        private void list2AddSelectedItems()
        {
            int ndx2, nSelectedItems1, nSelectedItems2;
            string listItem;

            nSelectedItems1 = listBox1.SelectedIndices.Count;

            int nRows1 = listBox1.Items.Count;
            for (int ndx1 = 0; ndx1 < nRows1; ndx1++)
            {
                if (listBox1.GetSelected(ndx1))
                {
                    listItem = (string)listBox1.Items[ndx1];
                    ndx2 = listBox2.SelectedIndex;
                    Console.WriteLine("listBox2: Add Item Index = " + ndx1.ToString()
                                       + ", Value " + listItem);
                    if (ndx2 < 0)
                        listBox2.Items.Add(listItem);
                    else
                        listBox2.Items.Insert(ndx2, listItem);
                }
            }
        }

        private void list1RemoveSelectedItems()
        {
            string listItem;

            int nSelectedItems = listBox1.SelectedIndices.Count;
            if (nSelectedItems > 0)
            {
                int nrows = listBox1.Items.Count;
                for (int nrow = (nrows - 1); nrow >= 0; nrow--)
                {
                    if (listBox1.GetSelected(nrow))
                    {
                        listItem = (string)listBox1.Items[nrow];
                        Console.WriteLine("listBox1: Index = " + nrow.ToString()
                                           + ", Value " + listItem);
                        listBox1.Items.RemoveAt(nrow);
                    }
                }
            }
        }

        private void list2RemoveSelectedItems()
        {
            string listItem;

            int nSelectedItems = listBox2.SelectedIndices.Count;
            if (nSelectedItems > 0)
            {
                int nrows = listBox2.Items.Count;
                for (int nrow = (nrows - 1); nrow >= 0; nrow--)
                {
                    if (listBox2.GetSelected(nrow))
                    {
                        listItem = (string)listBox2.Items[nrow];
                        Console.WriteLine("listBox2: Index = " + nrow.ToString()
                                           + ", Value " + listItem);
                        listBox2.Items.RemoveAt(nrow);
                    }
                }
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int nSelectedItems;
            string selectedItemsList, selectedItemsList2;

            string mButton = "";
            string eButton = e.Button.ToString();
            if ( e.Button == MouseButtons.Left )
                mButton = "Left";
            else if ( e.Button == MouseButtons.Right )
                mButton = "Right";
            else if ( e.Button == MouseButtons.Middle )
                mButton = "Middle";
            else if ( e.Button == MouseButtons.None )
                mButton = "None";
            else
                mButton = "Unknown";
            Console.WriteLine("listBox1 MouseDown: eButton = " + eButton + "; mButton = " + mButton);

            nSelectedItems = listBox1.SelectedIndices.Count;
            Console.WriteLine("listBox1 MouseDown: " + nSelectedItems.ToString() + " rows selected.");
            //listSelectedItems("listBox1 MouseDown");
            selectedItemsList = getSelectedItemsList();
            //selectedItemsList2 = getSelectedItemsList2();
            Console.WriteLine("listBox1 MouseDown: SelectedItemsList = " + selectedItemsList);

            if (nSelectedItems > 0)
            {
                DragDropEffects effect;
                effect = listBox1.DoDragDrop(selectedItemsList
                                            , DragDropEffects.Move );
//                                            , DragDropEffects.Move | DragDropEffects.Copy );
                if (effect == DragDropEffects.Move)
                {
                    Console.WriteLine("listBox1 MouseDown - Items moved");
                    list1RemoveSelectedItems();
                }
                else if (effect == DragDropEffects.Copy)
                    Console.WriteLine("listBox1 MouseDown - Items copied");
                else
                    Console.WriteLine("listBox1 MouseDown - Items not moved or copied");
            }
            else
            {
                Console.WriteLine("listBox1 MouseDown: Nothing selected");
            }
        }

        private void listBox2_MouseDown(object sender, MouseEventArgs e)
        {
            int nSelectedItems;
            string selectedItemsList;

            string mButton = "";
            string eButton = e.Button.ToString();
            if (e.Button == MouseButtons.Left)
                mButton = "Left";
            else if (e.Button == MouseButtons.Right)
                mButton = "Right";
            else if (e.Button == MouseButtons.Middle)
                mButton = "Middle";
            else if (e.Button == MouseButtons.None)
                mButton = "None";
            else
                mButton = "Unknown";
            Console.WriteLine("listBox2 MouseDown: eButton = " + eButton + "; mButton = " + mButton);

            nSelectedItems = listBox2.SelectedIndices.Count;
            Console.WriteLine("listBox2 MouseDown: " + nSelectedItems.ToString() + " rows selected.");
            selectedItemsList = getSelectedItemsList2();
            Console.WriteLine("listBox2 MouseDown: SelectedItemsList = " + selectedItemsList);

            if (nSelectedItems > 0)
            {
                DragDropEffects effect;
                effect = listBox2.DoDragDrop(selectedItemsList
                                            , DragDropEffects.Move);
                //                                            , DragDropEffects.Move | DragDropEffects.Copy );
                if (effect == DragDropEffects.Move)
                {
                    Console.WriteLine("listBox2 MouseDown - Items moved");
                    list2RemoveSelectedItems();
                }
                else if (effect == DragDropEffects.Copy)
                    Console.WriteLine("listBox2 MouseDown - Items copied");
                else
                    Console.WriteLine("listBox2 MouseDown - Items not moved or copied");
            }
            else
            {
                Console.WriteLine("listBox2 MouseDown: Nothing selected");
            }
        }

        enum KeyPushed
        {
            // Corresponds to DragEventArgs.KeyState values
            LeftMouse      = 1,
            RightMouse     = 2,
            ShiftKey       = 4,
            CtrlKey        = 8,
            MiddleMouse    = 16,
            AltKey         = 32,
        }

        private string decode_keypush(KeyPushed key)
        {
            string sKey = "";

            if ((key & KeyPushed.LeftMouse) == KeyPushed.LeftMouse)
                sKey = sKey + "LeftMouse, ";
            if ((key & KeyPushed.RightMouse) == KeyPushed.RightMouse)
                sKey = sKey + "RightMouse,";
            if ((key & KeyPushed.MiddleMouse) == KeyPushed.MiddleMouse)
                sKey = sKey + "MiddleMouse,";
            if ((key & KeyPushed.CtrlKey) == KeyPushed.CtrlKey)
                sKey = sKey + "ControlKey,";
            if ((key & KeyPushed.ShiftKey) == KeyPushed.ShiftKey)
                sKey = sKey + "ShiftKey,";
            if ((key & KeyPushed.AltKey) == KeyPushed.AltKey)
                sKey = sKey + "AltKey,";

            return sKey;
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            int nSelectedItems;
            KeyPushed kp = (KeyPushed)e.KeyState;
            string sKeyPushed = decode_keypush(kp);

            Console.WriteLine("listBox1 DragEnter: Key = " + kp.ToString() + " (" + sKeyPushed + ")");

            string sAllowed = "";
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                sAllowed = "Copy";
            if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
                if (sAllowed == "")
                    sAllowed = "Move";
                else
                    sAllowed += ", Move";
            Console.WriteLine("listBox1 DragEnter: Allowed events = " + sAllowed);

            nSelectedItems = listBox2.SelectedIndices.Count;
            Console.WriteLine("listBox1 DragEnter: nSelectedItems = " + nSelectedItems.ToString());

            if ((kp & KeyPushed.LeftMouse) == KeyPushed.LeftMouse)
            {
                if ((kp & KeyPushed.CtrlKey) == KeyPushed.CtrlKey)
                {
                    e.Effect = DragDropEffects.Copy;
                    Console.WriteLine("listBox1 DragEnter: Copy");
                }
                else
                {
                    e.Effect = DragDropEffects.Move;
                    Console.WriteLine("listBox1 DragEnter: Move");
                }
            }
        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            int nSelectedItems;
            KeyPushed kp = (KeyPushed)e.KeyState;
            string sKeyPushed = decode_keypush(kp);

            Console.WriteLine("listBox2 DragEnter: Key = " + kp.ToString() + " (" + sKeyPushed + ")");

            string sAllowed = "";
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                sAllowed = "Copy";
            if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
                if (sAllowed == "")
                    sAllowed = "Move";
                else
                    sAllowed += ", Move";
            Console.WriteLine("listBox2 DragEnter: Allowed events = " + sAllowed);

            nSelectedItems = listBox1.SelectedIndices.Count;
            Console.WriteLine("listBox2 DragEnter: nSelectedItems = " + nSelectedItems.ToString());

            if ((kp & KeyPushed.LeftMouse) == KeyPushed.LeftMouse)
            {
                if ((kp & KeyPushed.CtrlKey) == KeyPushed.CtrlKey)
                {
                    e.Effect = DragDropEffects.Copy;
                    Console.WriteLine("listBox2 DragEnter: Copy");
                }
                else
                {
                    e.Effect = DragDropEffects.Move;
                    Console.WriteLine("listBox2 DragEnter: Move");
                }
            }
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            //            string tmp = (string)e.Data.GetData(DataFormats.Text);

            int nSelectedItems;
            nSelectedItems = listBox2.SelectedIndices.Count;
            Console.WriteLine("listBox1 DragDrop: " + nSelectedItems.ToString() + " Items selected.");
            //listSelectedItems("listBox2 DragDrop");
            list1AddSelectedItems();

            //            Console.WriteLine("listBox2 DragDrop: Drop " + tmp);
            //            listBox2.Items.Add((string)e.Data.GetData(DataFormats.Text));
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            //            string tmp = (string)e.Data.GetData(DataFormats.Text);

            int nSelectedItems;
            nSelectedItems = listBox1.SelectedIndices.Count;
            Console.WriteLine("listBox2 DragDrop: " + nSelectedItems.ToString() + " Items selected.");
            //listSelectedItems("listBox2 DragDrop");
            list2AddSelectedItems();

            //            Console.WriteLine("listBox2 DragDrop: Drop " + tmp);
            //            listBox2.Items.Add((string)e.Data.GetData(DataFormats.Text));
        }

        private void cb_close_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DragDropTest Close");
            Close();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("ListBox1 MouseClick");
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("ListBox2 MouseClick");
        }
    }
}