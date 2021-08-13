using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Address;
using System;

namespace Yyuri.Data.Repositories.Address
{
    public class ProvinceRepository : Repository<Province, Guid>, IProvinceRepository
    {
        public ProvinceRepository(SCDataContext context) : base(context)
        {
        }
    }
}
