﻿
using Yyuri.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Yyuri.Domain.Identity.Models;

namespace Yyuri.Services
{
    public interface IAccountService : IBaseService
    {
        //UserSearchViewModel SearchWithPaging(string searchText, int pageIndex);

        bool UserNameExists(string userName);
        User InsertForFacebook(User user);
    }
}