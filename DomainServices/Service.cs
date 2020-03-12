using BusinesService;
using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Service : IService
    {
        IUnitOfWork database;
        public Service(IUnitOfWork db)
        {
            database = db;
        }

        public void CreateUser(User user)
        {
            database.Users.Create(user);
        }
        public void DeleteUser(int id)
        {
            database.Users.Delete(id);
        }
        public void UpdateUser(User user)
        {
            database.Users.Update(user);
        }
        public User GetUser(int id)
        {
            return database.Users.Get(id);
        }
        public User GetUserByData(string mail, string password)
        {
            return database.Users.Get(mail,password);
        }
        public IEnumerable<User> GetUsers()
        {
            return database.Users.GetAll();
        }

        public IEnumerable<Role> GetRoles()
        {
            return database.Roles.GetAll();
        }
        public void CreateRole(Role role)
        {
            database.Roles.Create(role);
        }

        public IEnumerable<Country> GetCountries()
        {
            return database.Countries.GetAll();
        }
        public Country GetCountry(int id)
        {
            return database.Countries.Get(id);
        }

        public void UpdateCountry(Country country)
        {
            database.Countries.Update(country);
        }

        public void DeleteCountry(int id)
        {
            database.Countries.Delete(id);
        }

        public void CreateCountry(Country country)
        {
            database.Countries.Create(country);
        }


        public IEnumerable<Hotel> GetHotels()
        {
            return database.Hotels.GetAll();
        }
    }
}
