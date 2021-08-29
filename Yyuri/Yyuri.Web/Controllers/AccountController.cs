using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Yyuri.Commons;
using Yyuri.Domain.Identity.Models;
using Yyuri.Security.Models.Account;
using Yyuri.Services;
using Yyuri.Services.EmailEngine;
using Yyuri.Services.Extensions;

namespace Yyuri.Web.Controllers
{
    public class AccountController : BaseController
    {
        private IAccountService _accountService;
        private IConfiguration _config;
        private string appid;
        private string appsecret;
        private IEmailService _emailService;

        public AccountController(UserManager<User> userManage,
                                 SignInManager<User> signInManager,
                                 IConfiguration config,
                                 IAccountService accountService,
                                 IEmailService emailService,
                                 ILoggerManager logger) : base(userManage, signInManager, logger)
        {
            this._accountService = accountService;
            _config = config;
            _emailService = emailService;
            appid = _config.GetValue<string>("Facebook:AppID");
            appsecret = _config.GetValue<string>("Facebook:AppSecret");
        }

        #region Login

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            loginModel.LoginInValid = "true";

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email,
                                                                     loginModel.Password,
                                                                     loginModel.RememberMe,
                                                                     lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    loginModel.LoginInValid = "";
                }
                else
                {
                    ViewBag.ErrorMessage = "Email hoặc mật khẩu không đúng!";
                }
            }
            return PartialView("_UserLoginPartial", loginModel);
        }

        #endregion Login

        #region Logout

        //[AllowAnonymous]
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion Logout

        #region Register

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegisterViewModel registrationModel)
        {
            registrationModel.RegistrationInValid = "true";

            if (ModelState.IsValid)
            {
                if (UserNameExists(registrationModel.Email))
                {
                    ViewBag.ErrorMessage = "Địa chỉ email này đã được đăng ký!";
                    registrationModel.InputEmailCode = "block";
                    registrationModel.InputSlideToUnlock = "none";
                }
                else
                {
                    if(!CheckVerificationEmail(registrationModel.Email, registrationModel.Code))
                    {
                        ViewBag.ErrorMessage = "Mã xác nhận không hợp lệ!";
                        registrationModel.InputEmailCode = "block";
                        registrationModel.InputSlideToUnlock = "none";
                    }
                    else
                    {
                        User user = new User
                        {
                            LastName = registrationModel.HoTen,
                            UserName = registrationModel.Email,
                            Email = registrationModel.Email,
                            EmailConfirmed = true
                        };

                        var result = await _userManager.CreateAsync(user, registrationModel.Password);

                        if (result.Succeeded)
                        {
                            registrationModel.RegistrationInValid = "";

                            await _signInManager.SignInAsync(user, isPersistent: false);

                            return PartialView("_UserRegistrationPartial", registrationModel);
                        }

                        AddErrorsToModelState(result);
                    }
                }        
            }
            return PartialView("_UserRegistrationPartial", registrationModel);
        }

        [AllowAnonymous]
        public bool UserNameExists(string userName)
        {
            bool userNameExists = this._accountService.UserNameExists(userName);

            if (userNameExists)
                return true;
            return false;
        }

        [AllowAnonymous]
        public bool CheckVerificationEmail(string email, string code)
        {
            //if (_accountService.CheckVerificationEmail(email, code))
            //    return true;
            //return false;

            //if(email == TempData["EmailRegister"].ToString() && code == TempData["CodeRegister"].ToString())
            //    return true;
            //return false;


            if (HttpContext.Session.GetString("EmailRegister") == email && HttpContext.Session.GetString("CodeRegister") == code)
                return true;
            return false;
        }

        private void AddErrorsToModelState(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }

        [AllowAnonymous]
        [HttpPost]
        public void EmailVerification(string hoTen, string email)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1000, 9999);        

            var ten  = hoTen != null ? hoTen : "User";

            HttpContext.Session.SetString("EmailRegister", email);
            HttpContext.Session.SetString("CodeRegister", randomNumber.ToString());

            //var insertVerificationEmail = _accountService.InsertVerificationEmail(email, randomNumber.ToString());
            //if (insertVerificationEmail != Guid.Empty || insertVerificationEmail != null)
            //{
            string bodyText = _emailService.ComposeVerificationEmail(ten, randomNumber.ToString());
            _emailService.SendMail(email, ten, "Xác nhận email của bạn", bodyText);
            //}
        }

        #endregion Register

        #region facebook

        [AllowAnonymous]
        public IActionResult FacebookLogin()
        {
            string redirectUrl = Url.Action("FacebookResponse", "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Facebook", redirectUrl);
            return new ChallengeResult("Facebook", properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> FacebookResponse()
        {
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return RedirectToAction(nameof(Login));

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            string[] userInfo = { info.Principal.FindFirst(ClaimTypes.Name).Value, info.Principal.FindFirst(ClaimTypes.Email).Value };
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else
            {
                User user = new User
                {
                    Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    UserName = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    EmailConfirmed = true
                };

                IdentityResult identResult = await _userManager.CreateAsync(user);
                if (identResult.Succeeded)
                {
                    identResult = await _userManager.AddLoginAsync(user, info);
                    if (identResult.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion facebook

        #region google

        [AllowAnonymous]
        public IActionResult GoogleLogin()
        {
            string redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GoogleResponse()
        {
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return RedirectToAction(nameof(Login));

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            string[] userInfo = { info.Principal.FindFirst(ClaimTypes.Name).Value, info.Principal.FindFirst(ClaimTypes.Email).Value };
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else
            {
                User user = new User
                {
                    Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    UserName = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    EmailConfirmed = true
                };

                IdentityResult identResult = await _userManager.CreateAsync(user);
                if (identResult.Succeeded)
                {
                    identResult = await _userManager.AddLoginAsync(user, info);
                    if (identResult.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion google
    }
}