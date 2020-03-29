using Core;
using System;

namespace Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<City> Cities { get; }
        IGenericRepository<Hotel> Hotels { get; }
        IReadRepository<Role> Roles { get; }
        IGenericRepository<Tour> Tours { get; }
        IGenericRepository<Voucher> Vouchers { get; }
    }
}
