using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.Validators
{
    public class ValidateIntPositive : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool flag;
            if (value == null)
            {
                return new ValidationResult(false, "Value can't be empty");
            }
            else
            {
                flag = int.TryParse((string)value, out int i);
                if (!flag)
                {
                    return new ValidationResult(false, "Input must be a number");
                } 
                if (i <= 0)
                {
                    return new ValidationResult(false, "Value must be positive");
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}
