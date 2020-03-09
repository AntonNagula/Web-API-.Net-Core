using Core;
using System.Collections.Generic;
namespace Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        User Get(string mail, string password);
        void Create(User item);
        void Update(User item);
        void Delete(int id);
    }
}
