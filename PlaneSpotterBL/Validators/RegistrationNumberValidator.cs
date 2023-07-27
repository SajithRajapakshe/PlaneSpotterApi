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
            return regNumber.Length > 0 ? true : false;
        }

    }
}
