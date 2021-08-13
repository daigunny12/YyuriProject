using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;

namespace Yyuri.Data.Repositories.Shop
{

    public class FooterRepository : Repository<Footer, System.Guid>, IFooterRepository
    {
        public FooterRepository(SCDataContext context) : base(context)
        {
        }
    }
}