using Core;
using System;

namespace Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<City> Cities { get; }
        IGenericRepository<Hotel> Hotels { get; }
        IReadRepository<Role> Roles { get; }
        ITourRepository Tours { get; }
        IGenericRepository<Voucher> Vouchers { get; }
    }
}
