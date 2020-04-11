using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IHotelRepository : IGenericRepository<Hotel>
    {
        public bool HasTours(int id);
    }
}
