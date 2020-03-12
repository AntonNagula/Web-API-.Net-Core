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
        void DeleteUser(int id);
        void CreateUser(User user);

        IEnumerable<Role> GetRoles();
        void CreateRole(Role role);

        IEnumerable<Country> GetCountries();
        Country GetCountry(int id);
        void UpdateCountry(Country country);
        void DeleteCountry(int id);
        void CreateCountry(Country country);

        IEnumerable<Hotel> GetHotels();
    }
}
