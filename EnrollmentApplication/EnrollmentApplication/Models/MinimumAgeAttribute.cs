using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        readonly int minimumAge;

        public MinimumAgeAttribute(int minimumAge) : base("{0} less than the minimum")
        {
            this.minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                if ((int)value < minimumAge)
                {
                    var errormessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errormessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}