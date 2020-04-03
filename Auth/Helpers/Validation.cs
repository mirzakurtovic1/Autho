using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auth
{
    class Validation
    {


        public bool Required(object sender, CancelEventArgs e, ErrorProvider ep)
        {
            var text = "Field required !";


                var ele = ((MetroTextBox)sender);
                if (string.IsNullOrEmpty(ele.Text))
                {
                    //ele.Focus();
                    e.Cancel = true;
                    ep.SetError(ele, text);
                    return false;
                }
                else
                {
                    e.Cancel = false;
                    ep.SetError(ele, null);
                    return true;
                }
            return false;//implement
        }
        public bool MinMaxValue(object sender, CancelEventArgs e, ErrorProvider ep, int minValue, int maxValue)
        {
            var text = "Value must be between " + minValue + " & " + maxValue;


                var ele = ((MetroTextBox)sender);
                if (!string.IsNullOrWhiteSpace(ele.Text))
                {
                    if (Convert.ToInt32(ele.Text) < minValue || Convert.ToInt32(ele.Text) > maxValue)
                    {
                        //ele.Focus();
                        e.Cancel = true;
                        ep.SetError(ele, text);
                        return false;
                    }
                    else
                    {
                        e.Cancel = false;
                        ep.SetError(ele, null);
                        return true;
                    }
                }
            return false;//implement
        }
        public bool IsNumberOnly(object sender, CancelEventArgs e, ErrorProvider ep)
        {
            Regex reg = new Regex("[^0-9]");
            var text = "Only numbers";


                var ele = ((MetroTextBox)sender);
                var match = reg.IsMatch(ele.Text);
                if (match == true)
                {
                    e.Cancel = true;
                    //ele.Focus();
                    ep.SetError(ele, text);
                    return false;
                }
                else
                {

                    e.Cancel = false;
                    ep.SetError(ele, null);
                    return true;
                }

            return false;//implement
        }
        public bool IsLetterOnly(object sender, CancelEventArgs e, ErrorProvider ep)
        {
            Regex reg = new Regex("[^A-Za-z]");
            var text = "Only letters";


                var ele = ((MetroTextBox)sender);
                var match = reg.IsMatch(ele.Text);
                if (match == true)
                {
                    e.Cancel = true;
                    //ele.Focus();
                    ep.SetError(ele, text);
                    return false;
                }
                else
                {

                    e.Cancel = false;
                    ep.SetError(ele, null);
                    return true;
                }


            return false;//implement
        }

        public bool IsDecimalNumber(object sender, CancelEventArgs e, ErrorProvider ep)
        {
            //provjerit regex-e



                var ele = ((MetroTextBox)sender);
                bool isDecimal = IsDecimalFormat(ele.Text);
                var text = "Only decimal numbers";


                if (isDecimal==false)
                {
                    e.Cancel = true;
                    //ele.Focus();
                    ep.SetError(ele, text);
                    return false;
                }
                else
                {

                    e.Cancel = false;
                    ep.SetError(ele, null);
                    return true;
                }
        }
        public bool MinMaxLength(object sender, CancelEventArgs e, ErrorProvider ep, int minLength, int maxLength)
        {
            var text = "Value must be between " + minLength + " & " + maxLength;
            if (minLength == maxLength) { text = "Required " + minLength + " characters"; }

                var ele = ((MetroTextBox)sender);
                if (!string.IsNullOrWhiteSpace(ele.Text))
                {
                    if (ele.Text.Length < minLength || ele.Text.Length > maxLength)
                    {
                        //ele.Focus();
                        e.Cancel = true;
                        ep.SetError(ele, text);
                        return false;
                    }
                    else
                    {
                        e.Cancel = false;
                        ep.SetError(ele, null);
                        return true;
                    }
                }
            return false;
        }

        bool IsDecimalFormat(string input)
        {
            Decimal dummy;
            return Decimal.TryParse(input, out dummy);
            
        }

    }
}
