using System;
using System.Collections.Generic;
using Core;

namespace Interfaces
{
    public interface ICityRepository
    {
        IEnumerable<City> GetAll();
        City Get(int id);
        void Create(City item);
        void Update(City item);
        void Delete(int id);
    }
}
