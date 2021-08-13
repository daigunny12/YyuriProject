using Yyuri.Data.EntityFramework;
using Yyuri.Domain.Address;
using System;

namespace Yyuri.Data.Repositories.Address
{
    public class AddressRepository : Repository<Yyuri.Domain.Address.Models.Address, Guid>, IAddressRepository
    {
        public AddressRepository(SCDataContext context) : base(context)
        {
        }
    }
}
