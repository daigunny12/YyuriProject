using System;
using Yyuri.Domain.Account.Models;

namespace Yyuri.Services
{
    public interface IAccountService : IBaseService
    {
        //UserSearchViewModel SearchWithPaging(string searchText, int pageIndex);

        bool UserNameExists(string userName);

        //User InsertForFacebook(User user);
        Guid InsertVerificationEmail(string email, string emailCode);

        bool CheckVerificationEmail(string email, string code);
    }
}