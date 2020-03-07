using Core;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetAll();
        Hotel Get(int id);
        void Create(Hotel item);
        void Update(Hotel item);
        void Delete(int id);
    }
}
