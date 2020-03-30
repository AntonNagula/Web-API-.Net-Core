using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using Data.Mappers;
using System.Linq;

namespace Data.Repositories
{
    public class CountryRepository : IGenericRepository<Country>
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

        public string CreateAndGetId(Country item)
        {
            database.Countries.Add(item.ToCountryDB());
            database.SaveChanges();
            return database.Countries.FirstOrDefault(x => x.Name == item.Name).CountryId.ToString();
        }

        public void Delete(int id)
        {
            Entities.Country country = database.Countries.FirstOrDefault(x => x.CountryId == id);
            database.Countries.Remove(country);
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
            int id = Int32.Parse(item.CountryId);
            Entities.Country country = database.Countries.FirstOrDefault(x => x.CountryId == id);
            country.UpdateCountryDB(item);
            database.Countries.Update(country);
            database.SaveChanges();
        }
    }
}
