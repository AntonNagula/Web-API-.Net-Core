using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using Data.Mappers;
using System.Linq;

namespace Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private ProjectDbContext database;
        public CountryRepository(ProjectDbContext db)
        {
            database = db;
        }
        public void Create(Country item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Country Get(int id)
        {
            throw new NotImplementedException();
        }

        public Country Get(string mail, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> GetAll()
        {
            return database.Countries.Select(x => x.ToCountryApp()).ToList();
        }

        public void Update(Country item)
        {
            throw new NotImplementedException();
        }
    }
}
