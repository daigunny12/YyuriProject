using System.ComponentModel.DataAnnotations;

namespace Yyuri.Security.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}