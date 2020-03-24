﻿using System;

namespace Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ICountryRepository Countries { get; }
        ICityRepository Cities { get; }
        IHotelRepository Hotels { get; }
        IRoleRepository Roles { get; }
    }
}
