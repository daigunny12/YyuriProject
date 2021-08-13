using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Shop;
using Yyuri.Domain.Shop.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Yyuri.Data.Repositories.Shop
{
    public class OrderRepository : Repository<Order, System.Guid>, IOrderRepository
    {
        public OrderRepository(SCDataContext context) : base(context)
        {

        }
        //public IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
        //{
        //    var parameters = new SqlParameter[]{
        //        new SqlParameter("@fromDate",fromDate),
        //        new SqlParameter("@toDate",toDate)
        //    };
        //    return DbContext.Database.SqlQuery<RevenueStatisticViewModel>("GetRevenueStatistic @fromDate,@toDate", parameters);
        //}
    }
}