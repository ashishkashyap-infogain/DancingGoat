using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "General.FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "General.LastName")]
        public string LastName { get; set; }

        public EmailViewModel EmailViewModel { get; set; }

        public PasswordConfirmationViewModel PasswordConfirmationViewModel { get; set; }
    }
}