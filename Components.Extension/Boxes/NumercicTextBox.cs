using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components.Extension.Boxes
{
    public partial class NumericTextBox : TextBox
    {
        string DecimalSeparator;
        private bool _AllowOnlyInteger;// = false;

        [Category("TKIS Events")]
        [Description("Allow decimal seperator")]
        public bool AllowOnlyInteger
        {
            get
            {
                return _AllowOnlyInteger;
            }
            set
            {
                _AllowOnlyInteger = value;
            }
        }

        public double value
        {
            get { return Convert.ToDouble(this.Text); }
        }

        public NumericTextBox()
        {
            InitializeComponent();
            //this.ShortcutsEnabled = false;
            this.KeyPress += new KeyPressEventHandler(NumericTextBox_KeyPress);
            this.Leave += new EventHandler(NumericTextBox_Leave);
            DecimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        }


        void NumericTextBox_Leave(object sender, EventArgs e)
        {
            var value = (TextBox)sender;

            if (value.Text.Equals(DecimalSeparator))
                value.Text = "0";

            else if (value.Text.IndexOf(DecimalSeparator) == 0 && value.Text.Count() > 1)
            {
                value.Text = "0" + value.Text;
                return;
            }
            else if (value.Text.Count() == 0)
                value.Text = "0";

            else if (value.Text[0] == '0' && value.Text.Count() > 1 && !(value.Text[1] == ','))
            {
                var txt = value.Text.Substring(1);
                var txtCnt = txt.Count();
                for (int i = 0; i < txtCnt; i++)
                {
                    if (txt[0] == '0' && txt.Count() > 1 && !(txt[1] == ','))
                        txt = txt.Substring(1);

                }
                value.Text = txt;
            }

        }

        void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var value = (TextBox)sender;


            //nur ein , zulassen
            if (e.KeyChar == Convert.ToChar(DecimalSeparator) && !_AllowOnlyInteger)
            {
                if (value.Text.IndexOf(DecimalSeparator) != -1)
                    e.Handled = true;
            }

            else if ("-1234567890 \b".IndexOf(e.KeyChar.ToString()) < 0)
            {
                //Bei Abweichung Ereignis verwerfen
                e.Handled = true;
            }

            if (e.KeyChar == 13 && value.Text.Count() == 0)
                value.Text = "0";

        }
    }
}
