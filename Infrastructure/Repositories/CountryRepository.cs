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
            database.Countries.Add(item.ToCountryDB());
            database.SaveChanges();
        }

        public void Delete(int id)
        {
            Entities.Role role = database.Roles.FirstOrDefault(x => x.RoleId == id);
            database.Roles.Remove(role);
            database.SaveChanges();
        }

        public Country Get(int id)
        {
            return database.Countries.FirstOrDefault(x => x.CountryId == id).ToCountryApp();
        }               

        public IEnumerable<Country> GetAll()
        {
            return database.Countries.Select(x => x.ToCountryApp()).ToList();
        }

        public void Update(Country item)
        {               
            database.Countries.Update(item.ToCountryDB());
            database.SaveChanges();
        }
    }
}
