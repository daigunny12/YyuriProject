using Yyuri.Domain;
using Yyuri.Domain.Shop.Model;
using System.Collections.Generic;
namespace Yyuri.Domain.Shop
{
    public interface IOrderRepository : IRepository<Order, System.Guid>
    {
        //IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);
    }
}