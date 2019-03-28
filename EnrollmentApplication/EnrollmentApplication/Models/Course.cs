using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Course : IValidatableObject
    {
        [Display(Name = "Course ID")]
        public virtual int CourseId { get; set; }

        [Display(Name = "Course Title")]
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(150)]
        public virtual string Title { get; set; }

        [Display(Name = "Description")]
        public virtual string Description { get; set; }

        [Display(Name = "Number of Credits")]
        [Required(ErrorMessage = "{0} is required")]
        [Range(1 , 4 , ErrorMessage = "{0} must be between 1 and 4")]
        public virtual decimal Credits { get; set; }

        public virtual string InstructorName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Credits < 1 || Credits > 4)
            {
                yield return new ValidationResult("Credits must be between 1 and 4", new[] { "Credits" });
            }

            if(Description != null && Description.Split(' ').Length > 100)
            {
                yield return new ValidationResult("Your description is too verbose", new[] { "Description" });
            }
        }
    }
}