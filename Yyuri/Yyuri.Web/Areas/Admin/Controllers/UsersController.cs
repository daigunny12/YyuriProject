using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Yyuri.Domain.Identity.Models;
using Yyuri.Services.Extensions;
using Microsoft.Extensions.Configuration;
using Yyuri.Services;
using Microsoft.AspNetCore.Authorization;
using Yyuri.Models.User;
using System.Threading.Tasks;

namespace Yyuri.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UsersController : BaseController
    {
        private IAccountService _accountService;
        private IConfiguration _config;
        private int pageSize;
        public UsersController(UserManager<User> userManage,
                                SignInManager<User> signInManager,
                                IConfiguration config,
                                /*IAccountService accountService,*/
                                ILoggerManager logger) : base(userManage, signInManager, logger)
        {
           // this._accountService = accountService;
            this._config = config;

            /*pageSize = _config.GetValue<int>("PageSize")*/;
        }
        //public async Task<IActionResult> Index(string searchText, int? pageIndex)
        //{
        //    UserSearchViewModel model = new UserSearchViewModel()
        //    {
        //        SearchText = searchText,
        //        PageIndex = pageIndex != null && pageIndex != 0 ? pageIndex.Value : 1,
        //        PageSize = pageSize
        //    };
        //    var users = this._accountService.SearchWithPaging(model.SearchText, model.PageIndex);
        //    model.UsersProfile = users.UsersProfile;
        //    model.TotalItem = users.TotalItem;

        //    return View(model);
        //}

        public IActionResult Test()
        {
            return View();
        }
    }
}
