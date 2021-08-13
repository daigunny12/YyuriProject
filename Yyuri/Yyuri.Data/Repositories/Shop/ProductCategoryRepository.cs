using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;
using System.Collections.Generic;
using System.Linq;

namespace Yyuri.Data.Repositories.Shop
{

    public class ProductCategoryRepository : Repository<ProductCategory, System.Guid>, IProductCategoryRepository
    {
        public ProductCategoryRepository(SCDataContext context) : base(context)
        {
        }

        //public IEnumerable<ProductCategory> GetByAlias(string alias)
        //{
        //    return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        //}
    }
}