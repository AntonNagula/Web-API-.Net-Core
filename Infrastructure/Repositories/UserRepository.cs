using Core;
using Data.Mappers;
using Interfaces;
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
            //Entities.User user = database.Users.FirstOrDefault(x=>x.Email==mail && x.UserPassword==password);
            //User obj = user != null ? user.ToUserApp() : null;
            User obj = new User();
            if (mail == "anton@mail.ru")
            {                
                obj.Name = "anton";
            }
            else
            {
                obj.Name = "tony";
            }
            return obj;
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            for(int i = 0;i < 3;i++)
            {
                User user = new User();
                user.Email = "a";
                user.Id = i;
                user.Name = "a";
                user.Password = "a";
                user.Role = "a";
                user.Surname = "a";

                users.Add(user);
            }
            return users;

        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
