using Yyuri.Domain;
using System;
using System.Collections.Generic;
using Yyuri.Domain.Identity.Models;

namespace Yyuri.Domain.Accounts.Repositories
{
    public interface IGroupRepository : IRepository<Group, Guid>
    {
        void UpdateGroup(Guid id, String name, String desc, IEnumerable<String> selectedRoles);
        IEnumerable<Role> GetRolesByGroup(Guid groupId);
        void DeleteGroup(Guid groupId);
    }
}
