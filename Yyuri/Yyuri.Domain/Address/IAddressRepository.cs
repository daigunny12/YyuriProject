using System;

namespace Yyuri.Domain.Address
{
    public interface IAddressRepository : IRepository<Address.Models.Address, Guid>
    {
    }
}
