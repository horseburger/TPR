using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.Validators
{
    public class ValidateProductNumber : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string n = (string)value;
            if (n.Length != 7)
            {
                return new ValidationResult(false, "Value has to have 7 digits");
            }

            if (n[2] == '-' && Char.IsLetter(n[0]) && Char.IsLetter(n[1]) && Char.IsDigit(n[3]) && 
                Char.IsDigit(n[4]) && Char.IsDigit(n[5]) && Char.IsDigit(n[6]))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Wrong format (must be AA-0000");
        }
    }
}
