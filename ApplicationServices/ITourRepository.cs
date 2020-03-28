using Core;
using System.Collections.Generic;
namespace Interfaces
{
    public interface ITourRepository
    {
        IEnumerable<Tour> GetAll();
        Tour Get(int id);
        void Create(Tour item);
        void Update(Tour item);
        void Delete(int id);
    }
}
