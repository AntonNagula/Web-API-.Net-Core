using Core;
using Data.Mappers;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class CityRepository : IGenericRepository<City>
    {
        private ProjectDbContext database;
        public CityRepository(ProjectDbContext db)
        {
            database = db;
        }
        public void Create(City item)
        {
            database.Cities.Add(item.ToCityDB());
            database.SaveChanges();
        }

        public void Delete(int id)
        {
            Entities.City city = database.Cities.FirstOrDefault(x => x.CityId == id);
            database.Cities.Remove(city);
            database.SaveChanges();
        }

        public City Get(int id)
        {
            return database.Cities.FirstOrDefault(x => x.CityId == id).ToCityApp();
        }

        public IEnumerable<City> GetAll()
        {
            return database.Cities.Select(x => x.ToCityApp()).ToList();
        }

        public void Update(City item)
        {
            int id = Int32.Parse(item.CityId);
            Entities.City city = database.Cities.FirstOrDefault(x => x.CityId == id);
            city.UpdateCityDB(item);
            database.Cities.Update(city);
            database.SaveChanges();
        }        
    }
}
