using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomTrivia.LessonTwo.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        // This makes the field mandatory to fill.
        [Required]
        // This tells it what label it should have. The default is the property name and does not have spaces.
        [Display(Name = "Authorization Code")]
        // This provides some rules about what the field should accept as values.
        [StringLength(
            // The maximum length of the value.
            maximumLength: 20,
            // The error message that should be displayed in case the requirements are not met.
            // {0} = display name;
            // {1} = maximum length;
            // {2} = minimum length.
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            // The minimum length of the value.
            MinimumLength = 6)]
        public string AuthorizationCode { get; set; }
    }
}
