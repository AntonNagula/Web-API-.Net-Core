﻿using Core;
using Data.Mappers;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class RoleRepository : IReadRepository<Role>
    {
        private ProjectDbContext database;
        public RoleRepository(ProjectDbContext db)
        {
            database = db;
        }
        public Role Get(int id)
        {
            return database.Roles.FirstOrDefault(x => x.RoleId == id).ToRoleApp();
        }
        public IEnumerable<Role> GetAll()
        {
            return database.Roles.Select(x => x.ToRoleApp()).ToList();
        }
        private bool _disposed;
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            _disposed = true;
        }
    }
}
