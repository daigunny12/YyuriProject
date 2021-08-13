using System.Collections.Generic;
using Yyuri.Domain;
using Yyuri.Commons;
using System;
using System.Linq;
using System.IO;
using System.Configuration;
using Yyuri.Models;
using Yyuri.Models.User;
using Yyuri.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Yyuri.Domain.Identity.Models;
using Yyuri.Domain.Accounts.Models;
using Yyuri.Commons.Models;
using System.Threading.Tasks;
using System.Web;
using Yyuri.Domain.Account.Models;
using Yyuri.Services;

namespace Yyuri.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _hostingEnvironment;
        public AccountService(IUnitOfWork unitOfWork, UserManager<User> userManager, SignInManager<User> signInManager,
                             IHostingEnvironment environment, IConfiguration config) : base(unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _hostingEnvironment = environment;
            this._config = config;
        }


       
        //public UserSearchViewModel SearchWithPaging(string searchText, int pageIndex)
        //{
        //    int pageSize = _config.GetValue<int>("PageSize");

        //    var users = this.UnitOfWork.UserRepo.GetAll().AsEnumerable().Where(x =>
        //                    (String.IsNullOrEmpty(searchText) || (x.FirstName != null && x.FirstName.ToLower().Contains(searchText.ToLower())
        //                        || x.LastName != null && x.LastName.ToLower().Contains(searchText.ToLower())
        //                        || x.Email != null && x.Email.ToLower().Contains(searchText.ToLower()))
        //                        || x.UserName != null && x.UserName.ToLower().Contains(searchText.ToLower())
        //                        || x.PhoneNumber != null && x.PhoneNumber.Contains(searchText)
        //                        || x.Title != null && x.Title.ToLower().Contains(searchText.ToLower())
        //                        || !string.IsNullOrEmpty(x.FirstName) && !string.IsNullOrEmpty(x.FirstName) && ($"{x.FirstName} {x.LastName}").Contains(searchText.ToLower())
        //                    ))
        //                    .OrderBy(x => x.FirstName).Skip((pageIndex - 1) * pageSize).Take(pageSize);

        //    int totalItem = this.UnitOfWork.UserRepo.GetAll().Where(x =>
        //                    (String.IsNullOrEmpty(searchText) || (x.FirstName != null && x.FirstName.ToLower().Contains(searchText.ToLower())
        //                        || x.LastName != null && x.LastName.ToLower().Contains(searchText.ToLower())
        //                        || x.Email != null && x.Email.ToLower().Contains(searchText.ToLower()))
        //                    )).Count();

        //    List<UserProfileModel> userModels = new List<UserProfileModel>();
          

        //    foreach (var user in users.ToList())
        //    {
        //        userModels.Add(new UserProfileModel()
        //        {
        //            Id = user.Id,
        //            UserName = user.UserName,
        //            FirstName = user.FirstName,
        //            LastName = user.LastName,
        //            Email = user.Email,
        //            PhoneNumber = user.PhoneNumber,
        //            Title = user.Title,
        //            PhotoUrl = user.PhotoUrl,
        //        });
        //    }
        //    UserSearchViewModel model = new UserSearchViewModel()
        //    {
        //        UsersProfile = userModels,
        //        TotalItem = totalItem
        //    };
        //    return model;
        //}

        //check user name
        public bool UserNameExists(string userName)
        {
            return this.UnitOfWork.UserRepo.UserNameExists(userName);
        }
    }
}
