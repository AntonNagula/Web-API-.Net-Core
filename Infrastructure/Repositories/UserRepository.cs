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
            item.Role = item.Role ?? "пользователей";
            database.Users.Add(item.ToUserDB());
            database.SaveChangesAsync();
        }

        public void Delete(User item)
        {
            database.Users.Remove(item.ToUserDB());
            database.SaveChanges();
        }

        public User Get(string mail, string password)
        {            
            Entities.User user = database.Users.Include(x=>x.Role).FirstOrDefault(x => x.Email == mail && x.UserPassword == password);
            User obj = user != null ? user.ToUserApp() : new User();            
            return obj;
        }

        public User Get(int id)
        {
            return database.Users.FirstOrDefault(x => x.UserId == id).ToUserApp();
        }

        public IEnumerable<User> GetAll()
        {
            List<Entities.User> data = database.Users.Include(c => c.Role).ToList();
            List<User> users =data.Select(x=>x.ToUserApp()).ToList();
            return users;

        }

        public void Update(User item)
        {
            int id = Int32.Parse(item.Id);
            Entities.User user = database.Users.FirstOrDefault(x => x.UserId == id);
            user.Email = item.Email;
            user.UserName = item.Name;
            user.UserPassword = item.Password;
            user.RoleId = 2;
            user.UserSurname = item.Surname;
            database.Users.Update(user);
            database.SaveChanges();
        }
    }
}
