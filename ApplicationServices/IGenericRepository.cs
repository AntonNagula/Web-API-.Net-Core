using Core;
namespace Interfaces
{
    public interface IGenericRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T:class
    {

    }
}
