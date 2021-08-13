using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;

namespace Yyuri.Data.Repositories.Shop
{
    public class SlideRepository : Repository<Slide, System.Guid>, ISlideRepository
    {
        public SlideRepository(SCDataContext context) : base(context)
        {
        }
    }
}