using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;

namespace Yyuri.Data.Repositories.Shop
{
    public class PageRepository : Repository<Page, System.Guid>, IPageRepository
    {
        public PageRepository(SCDataContext context) : base(context)
        {
        }
    }
}