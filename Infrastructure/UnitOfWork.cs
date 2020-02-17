using Interfaces;
using Data.Repositories;
using System;
using System.Collections.Generic;

namespace Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ProjectDbContext database;
        private UserRepository userRepository;

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
