﻿using Core;

namespace Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public User GetUserByNameSurname(string name, string surname);
        public User GetuserByAuthInfo(string login, string password);
    }
}
