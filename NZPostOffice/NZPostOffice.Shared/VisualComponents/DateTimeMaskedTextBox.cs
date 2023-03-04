using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace NZPostOffice.Shared.VisualComponents
{
    public class DateTimeMaskedTextBox : MaskedTextBox
    {
        // TJB July-2010: Added EditMask for DateTimeMaskedTextBoxEditingControl

        public DateTimeMaskedTextBox()
        {
            this.Text = "00000000";
            this.Validating += new CancelEventHandler(DateTimeMaskedTextBox_Validating);
            this.Validated += new EventHandler(DateTimeMaskedTextBox_Validated);
        }

        void DateTimeMaskedTextBox_Validated(object sender, EventArgs e)
        {
            try
            {
                DateTime.Parse(this.Text);
            }
            catch
            {
                this.Value = "00000000";
            }
        }

        void DateTimeMaskedTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                DateTime.Parse(this.Text);
            }
            catch
            {
                this.Value = "00000000";
            }
        }

        private bool isDigit(Keys keys)
        {
            if (keys >= Keys.D0 && keys <= Keys.D9 || keys >= Keys.NumPad0 && keys <= Keys.NumPad9)
                return true;
            else
                return false;
        }

        private bool acceptKey(Keys keys)
        {
            if (isDigit(keys))
                return true;
            else if (keys == Keys.Delete || keys == Keys.Back)
                return true;
            return false;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //bool validateResult = false;
            if (base.ReadOnly) //for support readonly
                return;

            if ((this.SelectionLength > 0 || SelectionStart <= Text.Length) && acceptKey(e.KeyData))
            {
                int startIndex = 0;
                string selectedText = SelectedText;

                int selectionStart = SelectionStart;

                int tempStart = selectionStart;

                string result = selectedText;

                if (SelectionLength == 0)
                {
                    if ((isDigit(e.KeyData) || e.KeyData == Keys.Delete) && selectionStart < Text.Length)
                    {
                        selectedText = Text.Substring(selectionStart, 1);
                        if ((selectedText == "/") ||
                            (selectedText == "-") ||
                            (selectedText == "."))
                        {
                            selectionStart++;
                            startIndex = 0;
                            selectedText = Text.Substring(selectionStart, 1);
                        }
                    }
                    else if (e.KeyData == Keys.Back && selectionStart > 0)
                    {
                        selectionStart--;
                        selectedText = Text.Substring(selectionStart, 1);
                        if ((selectedText == "/") ||
                            (selectedText == "-") ||
                            (selectedText == "."))
                        {
                            selectionStart--;
                            startIndex = 0;
                            selectedText = Text.Substring(selectionStart, 1);
                        }
                    }
                }

                string temp = selectedText;
                tempStart = selectionStart;
                for (int index = 0; index < temp.Length; index++)
                {
                    if (char.IsDigit(temp, index))
                    {
                        temp = temp.Remove(index, 1);

                        if (index == startIndex && isDigit(e.KeyData))
                        {
                            if (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9)
                                temp = temp.Insert(index, ((Char)(e.KeyValue - 48)).ToString());
                            else
                                temp = temp.Insert(index, ((Char)e.KeyValue).ToString());
                            tempStart += index + 1;
                        }
                        else
                            temp = temp.Insert(index, "0");
                    }
                }
                result = Text.Remove(selectionStart, temp.Length).Insert(selectionStart, temp);

                Text = result;
                this.SelectionStart = tempStart;
                SelectionLength = 0;

                e.Handled = true;
            }
            else if (e.KeyValue >= 37 && e.KeyValue <= 40)
            {
                base.OnKeyDown(e);
            }
            else if (e.KeyData == Keys.Home)
            {
                base.OnKeyDown(e);
            }
            else if (e.KeyData == Keys.End)
            {
                base.OnKeyDown(e);
            }
            else
            {
                e.Handled = true;
                //return;
            }
        }

        // TJB July-2010: Added EditMask for DateTimeMaskedTextBoxEditingControl
        private string editMask;

        public string EditMask
        {
            get
            {
                return editMask;
            }
            set
            {
                if (value == null)
                {
                    value = String.Empty;
                }

                editMask = value;
            }
        }

        string val = string.Empty;

        public string Value
        {
            get
            {
                if (base.Text.Substring(0, 2) == "00")
                    return null;
                else
                {
                    string sval = (val = base.Text).Trim();
                    return sval;
                }
            }
            set
            {
                if (value == null || value == "00000000" || value == "")
                {
                    value = null;
                    val = "00000000";
                }
                else
                {
                    val = value;
                        // TJB  15-July-2009
                        //    Added to fix a problem with the entered date in
                        //    the Extentions Screen.
                        // If the value is a date (contains an "/") and its
                        // length is less than 10, assume the leading '0' from
                        // day is missing and add it.
                    if (val.IndexOf('/') > 0 && val.Length < 10)
                    {
                        val = '0' + val;
                    }
                }
                base.Text = val;
                this.Text = val; //added
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                string sval = value;
                // TJB  15-July-2009
                //    Added to fix a problem with the entered date in
                //    the Extentions Screen.
                // If the value is a date (contains an "/") and its
                // length is less than 10, assume the leading '0' from
                // day is missing and add it.
                if (sval.IndexOf('/') > 0 && sval.Length < 10)
                {
                    sval = '0' + sval;
                }
                base.Text = sval;
                if (this.Text.Replace('/', ' ').Replace('_', ' ').Trim() == "")
                    this.Text = "00000000";
            }
        }
    }
}
