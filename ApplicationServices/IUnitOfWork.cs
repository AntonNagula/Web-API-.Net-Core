using System;

namespace Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
    }
}
