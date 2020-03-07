﻿using Interfaces;
using Data.Repositories;
using System;

namespace Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ProjectDbContext database;
        private UserRepository userRepository;
        private CountryRepository coutryRepository;
        private HotelRepository hotelRepository;

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
        public ICountryRepository Countries
        {
            get
            {
                if (coutryRepository == null)
                    coutryRepository = new CountryRepository(database);
                return coutryRepository;
            }
        }
        public IHotelRepository Hotels
        {
            get
            {
                if (hotelRepository == null)
                    hotelRepository = new HotelRepository(database);
                return hotelRepository;
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
