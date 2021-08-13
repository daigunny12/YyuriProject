using Yyuri.Data.EntityFramework;
using Yyuri.Data.Repositories;
using Yyuri.Domain.Accounts.Repositories;
using Yyuri.Domain.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yyuri.Data.Accounts.Repositories
{
    public class RoleRepository : Repository<Role, Guid>, IRoleRepository
    {
        public RoleRepository(SCDataContext context) : base(context)
        {
        }
    }
}
