using Core;
using Data.Mappers;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private ProjectDbContext database;
        public RoleRepository(ProjectDbContext db)
        {
            database = db;
        }
        public void Create(Role item)
        {
            database.Roles.Add(item.ToRoleDB());
            database.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Role Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAll()
        {
            return database.Roles.Select(x => x.ToRoleApp()).ToList();
        }

        public void Update(Role item)
        {
            throw new NotImplementedException();
        }
    }
}
