using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace NZPostOffice.Shared.VisualComponents
{
    public class ExtentedMaskedTextBox : MaskedTextBox
    {
        string _Format = "";
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Represnet Format of this control")]
        public string Format
        {
            get
            {
                return _Format;
            }
            set
            {
                _Format = value;
            }
        }
        private object _value;
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Represnet value of this control")]
        public virtual object Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (DBNull.Value == value || value == null)
                {
                    _value = null;
                    this.Text = "";
                }
                else
                {
                    _value = value;
                    if (this.Format != null && this.Format != "")
                    {
                        this.Text = String.Format("{0:" + this.Format + "}", _value);
                    }
                    else
                    {
                        this.Text = _value.ToString();
                    }
                }
            }
        }
        public ExtentedMaskedTextBox()
        {
            this.Validating += new System.ComponentModel.CancelEventHandler(ExtentedMaskedTextBox_Validating);
        }
        void ExtentedMaskedTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!Parse(this.Text))
            {
                e.Cancel = true;
            }
        }

        protected virtual bool Parse(string str)
        {
            MaskFormat format = this.TextMaskFormat;
            string msg = "";
            bool ret = true;

            this.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (this.Text != "")
            {
                try
                {
                    this.TextMaskFormat = MaskFormat.IncludeLiterals;
                    if (ValidatingType == typeof(double))
                    {
                        msg = "Invalid number value: ";
                        _value = double.Parse(Text);
                    }
                    else if (ValidatingType == typeof(decimal))
                    {
                        msg = "Invalid number value: ";
                        _value = decimal.Parse(Text);
                    }
                    else if (ValidatingType == typeof(int))
                    {
                        msg = "Invalid number value: ";
                        _value = int.Parse(Text);
                    }
                    else if (ValidatingType == typeof(DateTime))
                    {
                        msg = "Invalid date value: ";
                        DateTime tmpValue = DateTime.Parse(Text);
                        if (tmpValue == DateTime.MinValue)
                        {
                            _value = null;
                        }else{
                            _value = tmpValue;
                        }
                    }
                    else
                    {
                        this.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        _value = Text;
                    }
                }
                catch
                {
                    MessageBox.Show(msg + this.Text, "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ret = false;
                }
            }
            this.TextMaskFormat = format;
            return ret;
        }
    }
}

