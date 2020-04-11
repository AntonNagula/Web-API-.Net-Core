using Core;
using Interfaces;
using System.Collections.Generic;
using Data.Mappers;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class TourRepository : ITourRepository
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

        public bool HasVouchers(int id)
        {
            Entities.Tour tour= database.Tours.Include(x => x.Vouchers).FirstOrDefault(x => x.TourId == id);
            return tour.Vouchers.Any();
        }

        public Tour Get(int id)
        {
            var Tours = from tour in database.Tours
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
                            EngNameOfCity = city.EngName,
                            Name = tour.Name,
                            Quantity = tour.Quantity.ToString()
                        };
            return Tours.ToList().FirstOrDefault(x => x.TourId == id.ToString());
        }
        public IEnumerable<Tour> GetActualTours()
        {
            var tours = from tour in database.Tours
                        join country in database.Countries on tour.CountryId equals country.CountryId
                        join city in database.Cities on tour.CityId equals city.CityId
                        join hotel in database.Hotels on tour.HotelId equals hotel.HotelId
                        where tour.Quantity > 0 && tour.StartDate > DateTime.Today
                        select new Tour
                        {
                            CityId = city.CityId.ToString(),
                            CountryId = country.CountryId.ToString(),
                            HotelId = hotel.HotelId.ToString(),
                            TourId = tour.TourId.ToString(),
                            Country = country.Name,
                            Hotel = hotel.Name,
                            City = city.RusName,
                            EngNameOfCity = city.EngName,
                            Name = tour.Name,
                            Quantity = tour.Quantity.ToString(),
                            EndDate = tour.EndDate.ToString(),
                            StartDate = tour.StartDate.ToString()
                        };
            return tours.ToList();
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
                             EngNameOfCity = city.EngName,
                             Name = tour.Name,
                             Quantity = tour.Quantity.ToString(),
                             EndDate = tour.EndDate.ToString(),
                             StartDate = tour.StartDate.ToString()
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
