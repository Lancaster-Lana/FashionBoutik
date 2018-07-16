
using System.ComponentModel.DataAnnotations;

namespace FashionBoutik.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
