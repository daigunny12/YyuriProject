using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;

namespace Yyuri.Data.Repositories.Shop
{
    public class MenuGroupRepository : Repository<MenuGroup, System.Guid>, IMenuGroupRepository
    {
        public MenuGroupRepository(SCDataContext context) : base(context)
        {
        }
    }
}