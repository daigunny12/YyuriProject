using Yyuri.Domain.Shop.Model;
using System.Collections.Generic;
using System.Linq;

namespace Yyuri.Domain.Shop
{
    public interface IPostRepository : IRepository<Post, System.Guid>
    {
        //IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }
}