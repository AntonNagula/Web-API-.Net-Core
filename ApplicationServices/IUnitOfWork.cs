using Core;
using System;

namespace Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ICountryRepository Countries { get; }
        ICityRepository Cities { get; }
        IHotelRepository Hotels { get; }
        IReadRepository<Role> Roles { get; }
        ITourRepository Tours { get; }
        IVoucherRepository Vouchers { get; }
    }
}
