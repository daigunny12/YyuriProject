using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Yyuri.Domain.Identity.Models;
using Yyuri.Models;
using Yyuri.Security.Models;
using Yyuri.Services.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Yyuri.Web.Models;

namespace Yyuri.Web.Controllers
{
    public class BaseController: Controller
    {
        protected UserManager<User> _userManager;
        protected SignInManager<User> _signInManager;
        protected readonly ILoggerManager _logger;

        public BaseController(UserManager<User> userManage)
        {
        }

        public BaseController(UserManager<User> userManage, SignInManager<User> signInManager, ILoggerManager logger)
        {
            _userManager = userManage;
            _signInManager = signInManager;
            _logger = logger;
        }

        //----------------------------------------------------------------------------------------------
        /////////////////////
        protected async Task<IActionResult> RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }



        protected List<string> GetModelStateErrors()
        {
            return ModelState.Values.SelectMany(v => v.Errors.Select(x => x.ErrorMessage)).ToList();
        }

        protected Guid GetUserIdLogin()
        {
            //return User.FindFirstValue(ClaimTypes.Name);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid.TryParse(userId, out var id);
            return id;
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = _userManager.GetUserAsync(HttpContext.User).Result;
                if (user != null)
                {
                    LoginSessionViewModel loginSession = new LoginSessionViewModel
                    {
                        UserName = user.FirstName + " " + user.LastName
                    };
                    loginSession.AttachmentLink = user.PhotoUrl != null ? user.PhotoUrl : "/assets/images/noimguser.png";

                    loginSession.UserTitle = user.Title != null ? user.Title : user.Email;

                    ViewBag.LoginSession = loginSession;
                }

            }

            base.OnActionExecuted(filterContext);
        }

    }
}
