using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        public bool HasCities(int id);
        public bool HasTours(int id);
        public bool HasHotels(int id);
    }
}
