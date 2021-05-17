using CovidPortal.Domain.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace CovidPortal.Domain.Model
{
    public class  Patient : BaseEntity
    {
        [Required]
        public string PatientName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public DateTime CovidTestedDate { get; set; }

        [Required]
        public string HealthComplications { get; set; }

        [Required]
        public Int16 DaysInQueue { get; set; }

        public string ApplicationUserId { get; set; }

        // public virtual ApplicationUser User { get; set; }
    }
}
