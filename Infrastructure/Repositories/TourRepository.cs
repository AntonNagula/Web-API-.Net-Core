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

        public string CreateAndGetId(Tour item)
        {
            throw new NotImplementedException();
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
            var tours = from tour in database.Tours
                         join country in database.Countries on tour.CountryId equals country.CountryId
                         join city in database.Cities on tour.CityId equals city.CityId
                         join hotel in database.Hotels on tour.HotelId equals hotel.HotelId
                         select new Tour
                         {
                             CityId = city.CityId.ToString(), 
                             CountryId = country.CountryId.ToString(),
                             HotelId = hotel.HotelId.ToString(),
                             TourId = tour.TourId.ToString(),
                             Country = country.Name,
                             Hotel = hotel.Name,
                             City = city.RusName,
                             Name = tour.Name,
                             Quantity = tour.Quantity.ToString()
                         };
            return tours.ToList();
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
