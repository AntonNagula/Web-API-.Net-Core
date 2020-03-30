using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using Data.Mappers;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class HotelRepository : IGenericRepository<Hotel>
    {
        private ProjectDbContext database;
        public HotelRepository(ProjectDbContext db)
        {
            database = db;
        }
        public void Create(Hotel item)
        {
            database.Hotels.Add(item.ToHotelDB());
            database.SaveChanges();
        }

        public string CreateAndGetId(Hotel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Entities.Hotel hotel = database.Hotels.FirstOrDefault(x => x.HotelId == id);
            database.Hotels.Remove(hotel);
            database.SaveChanges();
        }
        public Hotel Get(int id)
        {
            var hotels = from hotel in database.Hotels
                         join country in database.Countries on hotel.CountryId equals country.CountryId
                         join city in database.Cities on hotel.CityId equals city.CityId
                         where hotel.HotelId == id
                         select new Hotel
                         {
                             Name = hotel.Name,
                             Country = country.Name,
                             City = city.RusName,
                             CountryId = hotel.CountryId.ToString(),
                             CityId = hotel.CityId.ToString(),
                             facilities = hotel.facilities,
                             HasBeach = hotel.HasBeach,
                             HotelId = hotel.HotelId.ToString(),
                             Img = hotel.Img,
                             PricePerDay = hotel.PricePerDay.ToString(),
                             Stars = hotel.Stars.ToString(),
                         };
            return hotels.First();
        }
        public IEnumerable<Hotel> GetAll()
        {
            var hotels = from hotel in database.Hotels
                         join country in database.Countries on hotel.CountryId equals country.CountryId
                         join city in database.Cities on hotel.CityId equals city.CityId
                         select new Hotel
                         {
                             Name = hotel.Name,
                             Country = country.Name,
                             City = city.RusName,
                             CountryId = hotel.CountryId.ToString(),
                             CityId = hotel.CityId.ToString(),
                             facilities = hotel.facilities,
                             HasBeach = hotel.HasBeach,
                             HotelId = hotel.HotelId.ToString(),
                             Img = hotel.Img,
                             PricePerDay = hotel.PricePerDay.ToString(),
                             Stars = hotel.Stars.ToString(),
                         };
            return hotels.ToList();
        }
        public void Update(Hotel item)
        {
            int id = Int32.Parse(item.HotelId);
            Entities.Hotel hotel = database.Hotels.FirstOrDefault(x => x.HotelId == id);
            hotel.UpdateHotelDB(item);
            database.Hotels.Update(hotel);
            database.SaveChanges();
        }
    }
}
