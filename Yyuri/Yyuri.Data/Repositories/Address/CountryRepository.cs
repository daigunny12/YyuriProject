using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Address;
using System;

namespace Yyuri.Data.Repositories.Address
{
    public class CountryRepository : Repository<Country, Guid>, ICountryRepository
    {
        public CountryRepository(SCDataContext context) : base(context)
        {
        }
    }
}
