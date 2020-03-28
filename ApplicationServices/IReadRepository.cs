using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IReadRepository<T> : IRepository
        where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
