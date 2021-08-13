using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;
using System.Collections.Generic;
using System.Linq;

namespace Yyuri.Data.Repositories.Shop
{
    public class PostRepository : Repository<Post, System.Guid>, IPostRepository
    {
        public PostRepository(SCDataContext context) : base(context)
        {
        }

        //public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        //{
        //    var query = from p in DataContext.Posts
        //                join pt in DataContext.PostTags
        //                on p.ID equals pt.PostID
        //                where pt.TagID == tag && p.Status
        //                orderby p.CreatedDate descending
        //                select p;
        //    totalRow = query.Count();

        //    query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //    return query;
        //}
    }
}