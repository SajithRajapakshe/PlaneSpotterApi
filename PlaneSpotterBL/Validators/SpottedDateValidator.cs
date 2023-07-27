using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotterBL.Validators
{
    /// <summary>
    /// Spotted date validation
    /// </summary>
    public class SpottedDateValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var date = Convert.ToDateTime(value);
            return date < DateTime.Now ? true : false;
        }
    }
}
