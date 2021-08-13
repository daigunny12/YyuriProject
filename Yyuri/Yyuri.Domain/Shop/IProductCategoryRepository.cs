
using Yyuri.Domain.Shop.Model;
using System.Collections.Generic;
using System.Linq;

namespace Yyuri.Domain.Shop
{
    public interface IProductCategoryRepository : IRepository<ProductCategory, System.Guid>
    {
        //IEnumerable<ProductCategory> GetByAlias(string alias);
    }
}