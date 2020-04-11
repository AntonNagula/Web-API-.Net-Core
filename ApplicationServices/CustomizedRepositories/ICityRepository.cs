using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICityRepository : IGenericRepository<City>
    {
        public bool HasTours(int id);
        public bool HasHotels(int id);
    }
}
