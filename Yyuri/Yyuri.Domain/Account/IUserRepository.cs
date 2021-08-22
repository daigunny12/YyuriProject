using Yyuri.Domain;
using System;
using System.Collections.Generic;
using Yyuri.Domain.Identity.Models;
using Yyuri.Commons.Models;
using Yyuri.Domain.Account.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Yyuri.Domain.Accounts.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        //IEnumerable<User> Search();
        //void SetRoleGroup(Guid userId, Guid roleGroupId);
        //Group GetRoleGroup(Guid userId);
        //void UpdateRoles(Guid groupId);
        //void UpdateRolesVer2(Guid groupId, IEnumerable<string> selectedRoles);
        //IEnumerable<UserRolesNameViewModel> GetUserRoles(Guid userId);
        //EmployeeSearch SearchWithPaging(string searchText, int pageIndex, int pageSize);
        ////IEnumerable<String> GetUserRoles(string userId);
        //DbSet<UserRole> GetUserRoleRepo();
        //List<Guid> GetUserIds(List<String> deviceId);
        //Guid GetUserId(string deviceCheckinUserId);

        bool UserNameExists(string userName);
        User UserNameExist(string userName);
    }
}
