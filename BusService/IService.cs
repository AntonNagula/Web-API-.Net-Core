using Core;
using System.Collections.Generic;

namespace BusinesService
{
    public interface IService
    {
        User GetUserByData(string mail, string password);
        IEnumerable<User> GetUsers();
    }
}
