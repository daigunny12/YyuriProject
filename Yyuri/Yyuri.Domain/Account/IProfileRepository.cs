using Yyuri.Domain;
using Yyuri.Domain.Accounts.Models;
using Yyuri.Domain.Identity.Models;
using System;

namespace Yyuri.Domain.Accounts.Repositories
{
    public interface IProfileRepository : IRepository<Profile, System.Guid>
    {
        Profile GetUserProfile(Guid userId);

        void UpdateUserProfile(Guid profileId, string firstName, string lastName, string lang, string countryCode, string timezoneCode, PROFILE_TYPE userType, string mobile, string phone);

        User GetUserByUserId(Guid userId);
    }
}
