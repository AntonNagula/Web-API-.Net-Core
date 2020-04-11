using Interfaces;
using Data.Repositories;
using System;
using Core;

namespace Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ProjectDbContext database;

        private UserRepository userRepository;
        private CountryRepository coutryRepository;
        private CityRepository cityRepository;
        private HotelRepository hotelRepository;
        private RoleRepository roleRepository;
        private TourRepository tourRepository;
        private VoucherRepository voucherRepository;

        public UnitOfWork(ProjectDbContext db)
        {
            database = db;
        }
        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(database);
                return userRepository;
            }
        }
        public IGenericRepository<Country> Countries
        {
            get
            {
                if (coutryRepository == null)
                    coutryRepository = new CountryRepository(database);
                return coutryRepository;
            }
        }
        public IGenericRepository<City> Cities
        {
            get
            {
                if (cityRepository == null)
                    cityRepository = new CityRepository(database);
                return cityRepository;
            }
        }
        public IGenericRepository<Hotel> Hotels
        {
            get
            {
                if (hotelRepository == null)
                    hotelRepository = new HotelRepository(database);
                return hotelRepository;
            }
        }
        public IReadRepository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(database);
                return roleRepository;
            }
        }
        public ITourRepository Tours
        {
            get
            {
                if (tourRepository == null)
                    tourRepository = new TourRepository(database);
                return tourRepository;
            }
        }
        public IGenericRepository<Voucher> Vouchers
        {
            get
            {
                if (voucherRepository == null)
                    voucherRepository = new VoucherRepository(database);
                return voucherRepository;
            }
        }

        public void Save()
        {
            database.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    database.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
