using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotterBL.Validators
{
    /// <summary>
    /// Validating the registration number 
    /// </summary>
    public class RegistrationNumberValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var regNumber = Convert.ToString(value);
            return regNumber.Length > 0 &&
                regNumber.Contains('-') &&
                regNumber.Split('-').Length == 2 &&
                IsValidPrefix(regNumber.Split('-')[0]) &&
                IsValidSuffix(regNumber.Split('-')[1]) ? true : false;
        }

        private bool IsValidPrefix(string prefix)
        {
            return prefix.Length == 1 || prefix.Length == 2;
        }

        private bool IsValidSuffix(string suffix)
        {
            return suffix.Length >= 1 && suffix.Length <= 5;
        }

    }
}
