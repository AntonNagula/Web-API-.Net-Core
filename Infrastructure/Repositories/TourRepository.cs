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
                            EndQuantity = tour.EndQuantity.ToString(),
                            StartQuantity = tour.StartQuantity.ToString(),
                            NumberOfNights = tour.NumberOfNights.ToString(),
                            PriceTransfer = tour.PriceTransfer.ToString(),
                            Price = tour.Price.ToString(),
                            Markup = tour.Markup.ToString(),
                            EndDate = tour.EndDate.ToString("dd/MM/yyyy"),
                            StartDate = tour.StartDate.ToString("dd/MM/yyyy"),
                            PriceHotel = hotel.PricePerDay.ToString()
                        };
            return Tours.ToList().FirstOrDefault(x => x.TourId == id.ToString());
        }
        public IEnumerable<Tour> GetChoisenTours(ChoisenCriterials choisenCriterials)
        {            
            DateTime start = choisenCriterials.StartDate != "" ? Convert.ToDateTime(choisenCriterials.StartDate + " 00:00:00") : Convert.ToDateTime("01.01.2020" + " 00:00:00");
            DateTime end = choisenCriterials.EndDate != "" ? Convert.ToDateTime(choisenCriterials.EndDate + " 23:59:59") : Convert.ToDateTime("01.01.2100" + " 23:59:59");
            int countryId = choisenCriterials.CountryId != "" ? Convert.ToInt32(choisenCriterials.CountryId) : 0;
            var tours = from tour in database.Tours
                        join country in database.Countries on tour.CountryId equals country.CountryId
                        join city in database.Cities on tour.CityId equals city.CityId
                        join hotel in database.Hotels on tour.HotelId equals hotel.HotelId
                        where tour.EndQuantity > 0 && tour.StartDate > DateTime.Today && tour.StartDate >= start && tour.StartDate <= end && (countryId != 0 ? tour.CountryId == countryId : true)
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
                            EndQuantity = tour.EndQuantity.ToString(),
                            StartQuantity = tour.StartQuantity.ToString(),
                            EndDate = tour.EndDate.ToString("dd/MM/yyyy"),
                            StartDate = tour.StartDate.ToString("dd/MM/yyyy"),
                            NumberOfNights = tour.NumberOfNights.ToString(),
                            PriceTransfer = tour.PriceTransfer.ToString(),
                            Price = tour.Price.ToString(),
                            Markup = tour.Markup.ToString(),
                            PriceHotel = hotel.PricePerDay.ToString()
                        };
            return tours.ToList();
        }
        public IEnumerable<Tour> GetActualTours()
        {
            var tours = from tour in database.Tours
                        join country in database.Countries on tour.CountryId equals country.CountryId
                        join city in database.Cities on tour.CityId equals city.CityId
                        join hotel in database.Hotels on tour.HotelId equals hotel.HotelId
                        where tour.EndQuantity > 0 && tour.StartDate > DateTime.Today
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
                            EndQuantity = tour.EndQuantity.ToString(),
                            StartQuantity = tour.StartQuantity.ToString(),
                            EndDate = tour.EndDate.ToString("dd/MM/yyyy"),
                            StartDate = tour.StartDate.ToString("dd/MM/yyyy"),
                            NumberOfNights = tour.NumberOfNights.ToString(),
                            PriceTransfer = tour.PriceTransfer.ToString(),
                            Price = tour.Price.ToString(),
                            Markup = tour.Markup.ToString(),
                            PriceHotel = hotel.PricePerDay.ToString()
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
                             EndQuantity = tour.EndQuantity.ToString(),
                             StartQuantity = tour.StartQuantity.ToString(),
                             EndDate = tour.EndDate.ToString("dd/MM/yyyy"),
                             StartDate = tour.StartDate.ToString("dd/MM/yyyy"),
                             NumberOfNights = tour.NumberOfNights.ToString(),
                             PriceTransfer = tour.PriceTransfer.ToString(),
                             Price = tour.Price.ToString(),
                             Markup = tour.Markup.ToString(),
                             PriceHotel = hotel.PricePerDay.ToString()
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
