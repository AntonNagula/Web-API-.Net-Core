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
        public void DeleteUser(User user)
        {
            database.Users.Delete(user);
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
        

        public IEnumerable<Country> GetCountries()
        {
            return database.Countries.GetAll();
        }


        public IEnumerable<Hotel> GetHotels()
        {
            return database.Hotels.GetAll();
        }
    }
}
