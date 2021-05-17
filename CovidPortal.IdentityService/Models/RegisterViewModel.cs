using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CovidPortal.IdentityService.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; }

        public IList<string> Roles { get; set; }
    }
}
