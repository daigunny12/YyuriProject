using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Address;
using System;

namespace Yyuri.Data.Repositories.Address
{
    public class DistrictRepository : Repository<District, Guid>, IDistrictRepository
    {
        public DistrictRepository(SCDataContext context) : base(context)
        {
        }
    }
}
