using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAll();
        Country Get(int id);
        void Create(Country item);
        void Update(Country item);
        void Delete(int id);
    }
}
