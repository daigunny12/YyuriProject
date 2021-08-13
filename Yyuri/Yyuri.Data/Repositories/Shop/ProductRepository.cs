using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;

namespace Yyuri.Data.Repositories.Shop
{

    public class ProductRepository : Repository<Product, System.Guid>, IProductRepository
    {
        public ProductRepository(SCDataContext context) : base(context)
        {
        }
    }
}