using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.Validators
{
    public class ValidateFloatNumberPositiveZero : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool flag = true;
            if (value == null)
            {
                return new ValidationResult(false, "Value can't be empty");
            } else
            {
                flag = decimal.TryParse((string)value, out decimal d);
                if (!flag)
                {
                    return new ValidationResult(false, "Value must be a number");
                }
                if (d < 0)
                {
                    return new ValidationResult(false, "Value can't be negative");
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}
