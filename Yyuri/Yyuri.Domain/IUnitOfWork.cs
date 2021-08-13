using System;
using System.Threading.Tasks;
using Yyuri.Domain.Accounts.Repositories;
using Yyuri.Domain.Address;

namespace Yyuri.Domain
{
    public interface IUnitOfWork
    {
        void SetUser(Guid userId);
        int SaveChanges();
        Task SaveChangesAsync();
        IGroupRepository GroupRepo { get; }
        IRoleRepository RoleRepo { get; }

        IProfileRepository ProfileRepo { get; }
        IUserRepository UserRepo { get; }
        ICountryRepository CountryRepo { get; }
        IAddressRepository AddressRepo { get; }
        IProvinceRepository ProvinceRepo { get; }
        IDistrictRepository DistrictRepo { get; }
       

    }
}
