using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;

namespace Yyuri.Data.Repositories.Shop
{
    public class FeedbackRepository : Repository<Feedback, System.Guid>, IFeedbackRepository
    {
        public FeedbackRepository(SCDataContext context) : base(context)
        {
        }
    }
}
