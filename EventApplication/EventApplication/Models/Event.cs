using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventApplication.Models
{
    public class Event : IValidatableObject
    {
        [Display(Name = "Event ID")]
        public virtual int EventId { get; set; }

        [Display(Name = "Event Type ID")]
        public virtual int EventTypeId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Start Date")]
        public virtual DateTime StartDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "End Date")]
        public virtual DateTime EndDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public virtual string City { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public virtual string State { get; set; }

        [Display(Name = "Event Type")]
        public virtual EventType EventType { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Organizer Name")]
        public virtual string OrganizerName { get; set; }

        [Display(Name = "Contact Info")]
        public virtual string OrganizerContact { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Max Tickets")]
        public virtual int TicketsMax { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Available Tickets")]
        public virtual int TicketsAvailable { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Title.Length > 50)
            {
                yield return new ValidationResult("Title should not exceed 50 characters", new[] { "Title" });
            }

            if (Description != null && Description.Length > 150)
            {
                yield return new ValidationResult("Description should not exceed 150 characters", new[] { "Description" });
            }

            if (EndDate < StartDate)
            {
                yield return new ValidationResult("Event End Date cannot be less than Event Start Date", new[] { "EndDate" });
            }

            if (StartDate < DateTime.Now)
            {
                yield return new ValidationResult("Event Start Date cannot be in the past", new[] { "StartDate" });
            }

            if (EndDate < DateTime.Now)
            {
                yield return new ValidationResult("Event End Date cannot be in the past", new[] { "EndDate" });
            }

            if (TicketsMax < 1)
            {
                yield return new ValidationResult("Max Tickets cannot be less than 1", new[] { "TicketsMax" });
            }

            if (TicketsAvailable < 1)
            {
                yield return new ValidationResult("Available Tickets cannot be less than 1", new[] { "TicketsAvailable" });
            }
        }
    }
}