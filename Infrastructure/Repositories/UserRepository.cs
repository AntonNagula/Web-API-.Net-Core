using Core;
using Data.Mappers;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ProjectDbContext database;

        public UserRepository(ProjectDbContext db)
        {
            database = db;
        }
        public void Create(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(string mail, string password)
        {            
            Entities.User user = database.Users.Include(x=>x.Role).FirstOrDefault(x => x.Email == mail && x.UserPassword == password);
            User obj = user != null ? user.ToUserApp() : new User();            
            return obj;
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            List<Entities.User> data = database.Users.Include(c => c.Role).ToList();
            List<User> users =data.Select(x=>x.ToUserApp()).ToList();
            return users;

        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
