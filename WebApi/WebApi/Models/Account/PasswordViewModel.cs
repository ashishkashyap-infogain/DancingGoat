using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebApi.Models.Account
{
    public class PasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Models.Account.Password")]
        [MaxLength(100, ErrorMessage = "Models.MaxLength")]
        public string Password { get; set; }
    }
}