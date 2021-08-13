using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;

namespace Yyuri.Data.Repositories.Shop
{
    public class VisitorStatisticRepository : Repository<VisitorStatistic, System.Guid>, IVisitorStatisticRepository
    {
        public VisitorStatisticRepository(SCDataContext context) : base(context)
        {
        }
    }
}