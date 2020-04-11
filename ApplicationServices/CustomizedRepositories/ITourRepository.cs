using Core;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ITourRepository : IGenericRepository<Tour>
    {
        public IEnumerable<Tour> GetActualTours();
    }
}
