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
        public User GetUserByData(string mail, string password)
        {
            return database.Users.Get(mail,password);
        }
        public IEnumerable<User> GetUsers()
        {
            return database.Users.GetAll();
        }
    }
}
