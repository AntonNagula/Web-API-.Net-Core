using Core;
using Interfaces;
using System.Collections.Generic;
using Data.Mappers;
using System.Linq;
using System;

namespace Data.Repositories
{
    public class TourRepository : IGenericRepository<Tour>
    {
        private ProjectDbContext database;
        public TourRepository(ProjectDbContext db)
        {
            database = db;
        }
        public void Create(Tour item)
        {
            database.Tours.Add(item.ToTourDB());
            database.SaveChanges();
        }

        public void Delete(int id)
        {
            Entities.Tour tour = database.Tours.FirstOrDefault(x => x.TourId == id);
            database.Tours.Remove(tour);
            database.SaveChanges();
        }

        public Tour Get(int id)
        {
            return database.Tours.FirstOrDefault(x => x.TourId == id).ToTourApp();
        }

        public IEnumerable<Tour> GetAll()
        {
            return database.Tours.Select(x => x.ToTourApp()).ToList();
        }

        public void Update(Tour item)
        {
            int id = Int32.Parse(item.TourId);
            Entities.Tour tour = database.Tours.FirstOrDefault(x => x.TourId == id);
            tour.UpdateTourDB(item);
            database.Tours.Update(tour);
            database.SaveChanges();
        }
    }
}
