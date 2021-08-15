using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yyuri.Domain.Identity.Models;
using Yyuri.Security.Models.Account;
using Yyuri.Service.EmailEngine;
using Yyuri.Services;
using Yyuri.Services.Extensions;

namespace Yyuri.Web.Controllers
{
    public class AccountController : BaseController
    {
        private IAccountService _accountService;
        private readonly IEmailSender _emailSender;
        public AccountController(UserManager<User> userManage,
                                 SignInManager<User> signInManager,
                                 IEmailSender emailSender,
                                 IAccountService accountService,
                                 ILoggerManager logger) : base(userManage, signInManager, logger)
        {
            this._accountService = accountService;
            _emailSender = emailSender;
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
                    //ModelState.AddModelError(string.Empty, "Invalid login attempt");
                    ViewBag.ErrorMessage = "Email hoặc mật khẩu không đúng";
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
                User user = new User
                {
                    UserName = registrationModel.Email,
                    Email = registrationModel.Email,
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
            return PartialView("_UserRegistrationPartial", registrationModel);

        }

        [AllowAnonymous]
        public async Task<bool> UserNameExists(string userName)
        {
            bool userNameExists = this._accountService.UserNameExists(userName);

            if (userNameExists)
                return true;

            return false;

        }

        private void AddErrorsToModelState(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }
        #endregion Register
    }
}
