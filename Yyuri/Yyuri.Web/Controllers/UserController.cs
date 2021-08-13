using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yyuri.Domain.Identity.Models;
using Yyuri.Services;
using Yyuri.Services.Extensions;


namespace Yyuri.Web.Controllers
{
    public class UserController : BaseController
    {
        private IAccountService _accountService;
        private IConfiguration _config;

        public UserController(UserManager<User> userManage,
                                SignInManager<User> signInManager,
                                IConfiguration config,
                                IAccountService accountService,
                                ILoggerManager logger) : base(userManage, signInManager, logger)
        {
            this._accountService = accountService;

            this._config = config;

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
