using System.ComponentModel.DataAnnotations;

namespace TVKetchup.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
