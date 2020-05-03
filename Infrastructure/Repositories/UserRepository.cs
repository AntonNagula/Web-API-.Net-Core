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
        public string CreateAndGetId(User item)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            Entities.User user = database.Users.FirstOrDefault(x => x.UserId == id);
            if (user == null)
                return true;
            database.Users.Remove(user);
            database.SaveChanges();
            return false;
        }
        public User Get(string mail, string password)
        {            
            Entities.User user = database.Users.Include(x=>x.Role).FirstOrDefault(x => x.Email == mail && x.UserPassword == password);
            User obj = user != null ? user.ToUserApp() : new User();            
            return obj;
        }
        public User Get(int id)
        {
            return database.Users.Include(x => x.Role).FirstOrDefault(x => x.UserId == id).ToUserApp();
        }
        public IEnumerable<User> GetAll()
        {
            IEnumerable<Entities.User> usersFromDatabase = database.Users.Include(c => c.Role);
            if (usersFromDatabase.Count() == 0)
                return new List<User>();
            List<User> users = usersFromDatabase.Select(x=>x.ToUserApp()).ToList();
            return users;

        }
        public User GetuserByAuthInfo(string login, string password)
        {
            return (database.Users.Include(x => x.Role).FirstOrDefault(x => x.Email == login && x.UserPassword == password)).ToUserApp();
        }
        public User GetUserByNameSurname(string name, string surname)
        {
            return (database.Users.FirstOrDefault(x => x.UserName == name && x.UserSurname == surname) ?? new Entities.User()).ToUserApp();
        }
        public void Update(User item)
        {
            int id = Int32.Parse(item.Id);
            Entities.User user = database.Users.FirstOrDefault(x => x.UserId == id);
            user.UpdateUserDB(item);
            database.Users.Update(user);
            database.SaveChanges();
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
