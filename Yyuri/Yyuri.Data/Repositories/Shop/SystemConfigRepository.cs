using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;

namespace Yyuri.Data.Repositories.Shop
{
    public class SystemConfigRepository : Repository<SystemConfig, System.Guid>, ISystemConfigRepository
    {
        public SystemConfigRepository(SCDataContext context) : base(context)
        {
        }
    }
}