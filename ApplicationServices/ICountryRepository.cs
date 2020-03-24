using Core;
using System.Collections.Generic;

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
