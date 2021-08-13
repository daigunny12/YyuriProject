using Yyuri.Domain;
using System;
using System.Collections.Generic;
using Yyuri.Domain.Identity.Models;

namespace Yyuri.Domain.Accounts.Repositories
{
    public interface IRoleRepository : IRepository<Role, Guid>
    {
    }
}
