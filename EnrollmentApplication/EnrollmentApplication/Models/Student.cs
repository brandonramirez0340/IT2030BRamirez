using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Student : IValidatableObject
    {
        [Display(Name ="Student ID")]
        public virtual int StudentId { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "{0} can not exceed 50 characters")]
        public virtual string LastName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "{0} can not exceed 50 characters")]
        public virtual string FirstName { get; set; }

        [MinimumAge(20)]
        public virtual int Age { get; set; }

        public virtual string Address1 { get; set; }

        public virtual string Address2 { get; set; }

        public virtual string City { get; set; }

        public virtual string Zipcode { get; set; }

        public virtual string State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (Address2 == Address1)
            {
                yield return new ValidationResult("Address2 cannot be the same as Address1");
            }

            if (State != null && State.Length != 2)
            {
                yield return new ValidationResult("Enter a 2 digit State code");
            }

            if (Zipcode != null && Zipcode.Length != 5)
            {
                yield return new ValidationResult("Enter a 5 digit Zipcode");
            }
        }
    }
}