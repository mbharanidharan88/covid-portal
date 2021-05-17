using CovidPortal.Domain.Identity;
using System.ComponentModel.DataAnnotations;

namespace CovidPortal.Domain.Model
{
    public class Vendor : BaseEntity
    {
        [Required]
        public string VendorName { get; set; }

        [Required]
        public string VendorCity { get; set; }

        [Required]
        public string Product { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }

        public string ApplicationUserId { get; set; }

        //public virtual ApplicationUser User { get; set; }
    }
}
