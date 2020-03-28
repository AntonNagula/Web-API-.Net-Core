using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IWriteRepository<T>: IRepository
        where T : class
    {
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
