using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace NZPostOffice.Shared.VisualComponents
{
    public class NumericalMaskedTextBox : MaskedTextBox
    {
        public NumericalMaskedTextBox()
        {
            this.PromptChar = ' ';
            this.InsertKeyMode = InsertKeyMode.Overwrite;
        }

        private int decimalIndex;
        private int dollarIndex;
        private int selectionPosition;
        private int selectionLength;

        private string editMask;
        private string val;

        private decimal defaultValue = 0m;

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

                decimalIndex = ((this.editMask.IndexOf('.') == -1) ? this.editMask.Length : this.editMask.IndexOf('.'));
                dollarIndex = this.editMask.IndexOf('$');
            }
        }
        public string Value
        {
            get
            {
                return (val = base.Text).Trim();
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = defaultValue.ToString(editMask);
                }

                if (Focused)
                {
                    value = this.PaddingMaskedText();
                }
                val = value;
                base.Text = val;
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
                base.Text = value;
                if (!string.IsNullOrEmpty(value))
                {
                    base.Text = this.PaddingMaskedText();
                }
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            this.Mask = editMask;
            this.Text = val;

            if (!string.IsNullOrEmpty(val))
            {
                val = this.PaddingMaskedText();
                this.Text = val;
            }

            base.OnEnter(e);
        }
        protected override void OnClick(EventArgs e)
        {
            if (!this.IsValidSelectionPosition())
            {
                this.FindSelectionStart();
            }
            base.OnClick(e);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (this.ReadOnly)
                return;
           
            int flag = -1;

            selectionPosition = this.SelectionStart;
            selectionLength = this.SelectionLength == 0 ? 1 : this.SelectionLength;

            if (this.MaskedTextProvider == null)
                return;

            if (e.KeyCode == Keys.Delete)
            {
                MaskedTextProvider p = (MaskedTextProvider)this.MaskedTextProvider.Clone();
                base.OnKeyDown(e);
                this.DeleteChar(p);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Back)
            {
                MaskedTextProvider p = (MaskedTextProvider)this.MaskedTextProvider.Clone();
                //base.OnKeyDown(e);

                int endPosition = selectionPosition;
                selectionPosition = (selectionPosition == dollarIndex) ? 1 : selectionPosition - 1;

                for (int i = selectionPosition; i < endPosition; i++)
                {
                    if (i > decimalIndex)
                    {
                        if (IsShowZeroAfterDecimal)
                        {
                            p.Replace('0', selectionPosition);
                        }
                        else
                        {
                            flag = -1;
                            p.RemoveAt(decimalIndex + 1);
                            this.val = p.ToString();
                        }
                        selectionPosition++;
                    }
                    else if (i < decimalIndex)
                    {
                        if (IsShowZeroAfterDecimal)
                        {
                            p.RemoveAt(selectionPosition);
                        }
                        else
                        {
                            flag = 0;
                            MoveChar2(i + 1, ref p);
                        }
                    }
                }
                if (flag == -1)
                {
                    this.Text = p.ToString();
                }
                this.Text = this.PaddingMaskedText();

                if (this.selectionPosition > decimalIndex)
                {
                    this.SelectionStart = this.selectionPosition - 1;
                }
                else
                {
                    this.SelectionStart = this.selectionPosition + 1;
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
            {
                if (selectionLength == this.MaskedTextProvider.Mask.Length)
                {
                    this.FindSelectionStart();
                    e.Handled = true;
                }
                else if (this.SelectionStart > 0 && char.IsWhiteSpace(this.MaskedTextProvider.ToDisplayString()[this.SelectionStart - 1]))
                {
                    e.Handled = true;
                }
                else
                {
                    base.OnKeyDown(e);
                }
            }
            else if (e.KeyCode == Keys.Home && e.Modifiers != Keys.Shift)
            {
                e.Handled = true;
            }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (this.ReadOnly )
                return;
            selectionPosition = this.SelectionStart;
            selectionLength = this.SelectionLength;

            if (this.MaskedTextProvider != null && selectionPosition <= decimalIndex)
            {
                if (selectionLength == 0)
                {
                    this.MoveChar(e);
                }
                else
                {
                    int sIndex = selectionPosition + selectionLength;
                    this.DeleteChar(this.MaskedTextProvider);
                    if (selectionPosition >= decimalIndex || this.SelectionStart >= decimalIndex)
                    {
                        this.SelectionStart = (selectionPosition = decimalIndex);
                    }
                    else
                    {
                        this.SelectionStart = (selectionPosition = sIndex);
                    }
                    selectionLength = (this.SelectionLength = 0);
                    this.MoveChar(e);
                }
            }
            base.OnKeyPress(e);
        }
        protected override void OnGotFocus(EventArgs e)
        {
            this.FindSelectionStart();
            base.OnGotFocus(e);
        }
        protected override void OnValidating(CancelEventArgs e)
        {
            string originalText = this.Text;
            string text = this.Text.Replace("$", string.Empty).Replace(",", string.Empty).Trim();
            string mask = this.Mask;

            this.Mask = string.Empty;
            if (text.Length == 0 || text == ".")
            {
                text = defaultValue.ToString();
            }
            this.Text = text;
            base.OnValidating(e);

            originalText = originalText.Replace(" ", "");
            if (originalText.Length > 0)
            {
                if (originalText[0] == ',')
                {
                    originalText = originalText.Substring(1);
                }
                else if (originalText[0] == '$' && originalText[1] == ',')
                {
                    originalText = originalText.Substring(0, 1) + originalText.Substring(2);
                }
            }
            this.Text = originalText;
        }
        private bool IsShowZeroAfterDecimal
        {
            get
            {
                bool isShow = true;
                if (decimalIndex > 0 && this.Mask.Substring(decimalIndex).IndexOf('#') > 0)
                {
                    isShow = false;
                }
                return isShow;
            }
        }
        private string PaddingMaskedText()
        {
            string current = this.Text;
            if (this.MaskedTextProvider != null)
            {
                current = this.MaskedTextProvider.ToString(false, false);
                if (!IsShowZeroAfterDecimal)
                {
                    int tempIndex = this.val.IndexOf('.');
                    if (tempIndex > 0 || this.val.StartsWith("."))
                    {
                        current = current + new string(' ', this.MaskedTextProvider.Mask.Length - decimalIndex - 1 - (this.val.Length - tempIndex - 1));
                    }
                    else
                    {
                        current = current + new string(' ', this.MaskedTextProvider.Mask.Length - decimalIndex - 1);
                    }
                }
                current = current.PadLeft(this.MaskedTextProvider.EditPositionCount);
            }
            return current;
        }
        private void FindSelectionStart()
        {
            if (this.MaskedTextProvider == null)
            {
                return;
            }

            this.SelectionStart = this.MaskedTextProvider.ToDisplayString().Length;

            if (!IsShowZeroAfterDecimal)
            {
                this.SelectionStart = this.MaskedTextProvider.Mask.Length - this.MaskedTextProvider.ToDisplayString().TrimStart().Length;
                return;
            }

            for (int i = this.MaskedTextProvider.ToDisplayString().Length - 1; i >= 0; i--)
            {
                if (char.IsWhiteSpace(this.MaskedTextProvider.ToDisplayString()[i]))
                {
                    this.SelectionStart = i + 1;
                    break;
                }
            }
        }
        private bool IsValidSelectionPosition()
        {
            bool valid = false;

            if (this.MaskedTextProvider != null && this.SelectionStart < this.MaskedTextProvider.ToDisplayString().Length &&
                this.MaskedTextProvider.ToDisplayString()[this.SelectionStart] != ' ' &&
                this.MaskedTextProvider.ToDisplayString()[this.SelectionStart] != '$' &&
                this.SelectionStart + 1 < this.MaskedTextProvider.ToDisplayString().Length &&
                this.MaskedTextProvider.ToDisplayString()[this.SelectionStart + 1] != ' ')
            {
                valid = true;
            }

            return valid;
        }
        private void DeleteChar(MaskedTextProvider p)
        {
            int flag = -1;

            int endPosition = (selectionLength > 0) ? ((selectionPosition + selectionLength) - 1) : selectionPosition;
            selectionPosition = (selectionPosition == dollarIndex) ? 1 : selectionPosition;

            if (selectionPosition == this.editMask.IndexOf(','))
            {
                selectionPosition = selectionPosition + 1;
                endPosition = ((endPosition + 1 == this.editMask.Length) ? endPosition : endPosition + 1);
            }

            for (int i = selectionPosition; i <= endPosition; i++)
            {
                if (i > decimalIndex && i != this.editMask.IndexOf(','))
                {
                    if (IsShowZeroAfterDecimal)
                    {
                        if (p.Replace('0', selectionPosition))
                        {
                            selectionPosition++;
                        }
                    }
                    else
                    {
                        flag = -1;
                        p.RemoveAt(decimalIndex + 1);
                        this.val = p.ToString();
                    }
                }
                else if (i < decimalIndex && i != this.editMask.IndexOf(','))
                {
                    if (IsShowZeroAfterDecimal)
                    {
                        p.RemoveAt(selectionPosition);
                    }
                    else
                    {
                        flag = 0;
                        MoveChar2(i + 1, ref p);
                    }
                }
            }
            if (flag == -1)
            {
                this.Text = p.ToString();
            }
            this.Text = this.PaddingMaskedText();

            if (this.selectionPosition > decimalIndex)
            {
                this.SelectionStart = this.selectionPosition;
            }
            else
            {
                this.SelectionStart = this.selectionPosition + 1;
            }
            if (endPosition == this.MaskedTextProvider.Mask.Length - 1 || this.selectionLength > 1)
            {
                this.FindSelectionStart();
            }
        }
        private void MoveChar(KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) && decimalIndex > 0 && this.Text.Trim().Length > decimalIndex && this.Text.Trim().Substring(0, decimalIndex).IndexOf('.') == -1 && !IsShowZeroAfterDecimal))// && selectionPosition == decimalIndex))
            {
                return;
            }

            if (char.IsDigit(e.KeyChar) && !this.MaskedTextProvider.MaskFull)
            {
                int startIndex = 1;
                if (dollarIndex != -1)
                {
                    startIndex = 2;
                }
                char[] text = this.MaskedTextProvider.ToDisplayString().ToCharArray();
                for (int i = startIndex; i < selectionPosition; i++)
                {
                    if (text[i] == ',' || text[i] == '.')
                    {

                    }
                    else if (text[i - 1] == ',' || text[i - 1] == '.')
                    {
                        text[i - 2] = text[i];
                    }
                    else
                    {
                        text[i - 1] = text[i];
                    }
                }
                this.Text = new string(text);
                if (selectionPosition - 1 >= 0)
                {
                    this.SelectionStart = selectionPosition - 1;
                }
            }
            else if (e.KeyChar == '.' && decimalIndex != this.editMask.Length)
            {
                this.Text = this.MaskedTextProvider.ToDisplayString().Substring(0, this.SelectionStart) +
                    this.MaskedTextProvider.ToDisplayString().Substring(decimalIndex + 1);
                this.SelectionStart = decimalIndex + 1;
            }
        }
        private void MoveChar2(int endPosition, ref MaskedTextProvider p)
        {
            try
            {
                char[] text = p.ToDisplayString().ToCharArray();

                for (int j = endPosition - 1; j >= 0; j--)
                {
                    if (j == 0)
                    {
                        text[j] = ' ';
                    }
                    else if (text[j] == ',' || text[j] == '.')
                    {

                    }
                    else if (text[j - 1] == ',' || text[j - 1] == '.')
                    {
                        text[j] = text[j - 2];
                    }
                    else
                    {
                        text[j] = text[j - 1];
                    }
                }
                this.Text = new string(text);
                p = this.MaskedTextProvider;
            }
            catch
            {

            }
        }
    }
}
