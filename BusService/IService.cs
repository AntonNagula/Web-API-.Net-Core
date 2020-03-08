using Core;
using System.Collections.Generic;

namespace BusinesService
{
    public interface IService
    {
        User GetUserByData(string mail, string password);
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void UpdateUser(User user);
        void DeleteUser(User user);
        void CreateUser(User user);

        IEnumerable<Country> GetCountries();

        IEnumerable<Hotel> GetHotels();
    }
}
