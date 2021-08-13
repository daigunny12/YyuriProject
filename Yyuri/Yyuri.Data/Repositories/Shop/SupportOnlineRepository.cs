using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;

namespace Yyuri.Data.Repositories.Shop
{
    public class SupportOnlineRepository : Repository<SupportOnline, System.Guid>, ISupportOnlineRepository
    {
        public SupportOnlineRepository(SCDataContext context) : base(context)
        {
        }
    }
}