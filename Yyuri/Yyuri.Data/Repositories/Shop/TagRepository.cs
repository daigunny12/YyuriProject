using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;

namespace Yyuri.Data.Repositories.Shop
{
    public class TagRepository : Repository<Tag, System.Guid>, ITagRepository
    {
        public TagRepository(SCDataContext context) : base(context)
        {
        }
    }
}