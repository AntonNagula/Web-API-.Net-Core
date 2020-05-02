using Core;
using Data.Mappers;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class CityRepository : ICityRepository
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
        public string CreateAndGetId(City item)
        {
            database.Cities.Add(item.ToCityDB());
            database.SaveChanges();
            return database.Cities.FirstOrDefault(x => x.RusName == item.RusName).CityId.ToString();
        }

        public void Delete(int id)
        {
            Entities.City city = database.Cities.FirstOrDefault(x => x.CityId == id);
            database.Cities.Remove(city);
            database.SaveChanges();
        }

        public City Get(int id)
        {
            return database.Cities.Include(x => x.Country).FirstOrDefault(x => x.CityId == id).ToCityApp();
        }

        public IEnumerable<City> GetAll()
        {
            return database.Cities.Include(x => x.Country).Select(x => x.ToCityApp()).ToList();
        }

        public bool HasHotels(int id)
        {
            Entities.City city = database.Cities.Include(x => x.Hotels).FirstOrDefault(x => x.CityId == id);
            return city.Hotels.Any();
        }

        public bool HasTours(int id)
        {
            Entities.City city = database.Cities.Include(x => x.Tours).FirstOrDefault(x => x.CityId == id);
            return city.Tours.Any();
        }

        public void Update(City item)
        {
            int id = Int32.Parse(item.CityId);
            Entities.City city = database.Cities.FirstOrDefault(x => x.CityId == id);
            city.UpdateCityDB(item);
            database.Cities.Update(city);
            database.SaveChanges();
        }

        private bool _disposed;

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            _disposed = true;
        }
    }
}
