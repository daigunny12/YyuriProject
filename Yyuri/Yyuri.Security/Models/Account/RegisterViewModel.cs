using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yyuri.Security.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "HoTen")]
        public string HoTen { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        ////[Compare("Password", ErrorMessage = "Mật khẩu và mật khẩu xác nhận không khớp.")]
        public string Code { get; set; }
        [DefaultValue("block")]
        public string InputSlideToUnlock { get; set; } = "block";
        public string InputEmailCode { get; set; } = "none";
        public bool AcceptUserAgreement { get; set; }
        public string RegistrationInValid { get; set; }
    }
}
