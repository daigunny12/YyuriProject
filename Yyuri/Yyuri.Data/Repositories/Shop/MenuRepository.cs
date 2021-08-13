using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;

namespace Yyuri.Data.Repositories.Shop
{
    public class MenuRepository : Repository<Menu, System.Guid>, IMenuRepository
    {
        public MenuRepository(SCDataContext context) : base(context)
        {
        }
    }
}