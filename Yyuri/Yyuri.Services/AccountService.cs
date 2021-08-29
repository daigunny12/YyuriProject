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


        //check user name
        public bool UserNameExists(string userName)
        {
            return this.UnitOfWork.UserRepo.UserNameExists(userName);
        }

        //public User InsertForFacebook(User entity)
        //{
        //    var user = this.UnitOfWork.UserRepo.UserNameExist(entity.UserName);
        //    if (user == null)
        //    {
        //        UnitOfWork.UserRepo.Insert(entity);
        //        UnitOfWork.SaveChanges();
        //        return entity;
        //    }
        //    else
        //    {
        //        return user;
        //    }
        //}

        public Guid InsertVerificationEmail(string email, string emailCode)
        {
            var ve = this.UnitOfWork.VerificationEmailRepo.VerificationEmailExist(email);
            if (ve != null)
                UnitOfWork.VerificationEmailRepo.Delete(ve);

            var entity = new VerificationEmail()
            {
                Id = Guid.NewGuid(),
                Email = email,
                Code = emailCode
            };
            UnitOfWork.VerificationEmailRepo.Insert(entity);
            UnitOfWork.SaveChanges();
            return entity.Id;
        }

        public bool CheckVerificationEmail(string email, string code)
        {
            return UnitOfWork.VerificationEmailRepo.CheckVerificationEmail(email, code);
        }
    }
}
