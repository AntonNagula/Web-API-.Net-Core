using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
        Role Get(int id);
        void Create(Role item);
        void Update(Role item);
        void Delete(int id);
    }
}
