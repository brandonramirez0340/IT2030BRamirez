using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Enrollment
    {
        [Display(Name = "Enrollment ID")]
        public virtual int EnrollmentId { get; set; }

        [Display(Name = "Student ID")]
        public virtual int StudentId { get; set; }

        [Display(Name = "Course ID")]
        public virtual int CourseId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"[ABCDF]", ErrorMessage = "{0} must be A, B, C, D, or F")]
        public virtual string Grade { get; set; }

        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }

        public virtual bool IsActive { get; set; }

        [Display(Name = "Assigned Campus")]
        [Required(ErrorMessage = "{0} is required")]
        public virtual string AssignedCampus { get; set; }

        [Display(Name = "Enrolled in Semester")]
        [Required(ErrorMessage = "{0} is required")]
        public virtual string EnrollmentSemester { get; set; }

        [Display(Name = "Enrollment Year")]
        [Required(ErrorMessage = "{0} is required")]
        [Range(2018, Double.PositiveInfinity, ErrorMessage = "{0} must be 2018 or later")]
        public virtual int EnrollmentYear { get; set; }

        //[InvalidChars("*^")]
        [InvalidChars("*^", ErrorMessage = "{0} must not contain * or ^")]
        public virtual string Notes { get; set; }
    }
}