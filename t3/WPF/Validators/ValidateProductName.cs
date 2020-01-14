using System;
using System.Globalization;
using System.Windows.Controls;

namespace WPF.Validators
{
    public class ValidateProductName : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = (string)value;
            if (s.Length == 0)
            {
                return new ValidationResult(false, "Product name must be set");
            }

            return ValidationResult.ValidResult;
        }
    }
}
