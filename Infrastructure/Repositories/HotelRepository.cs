﻿using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using Data.Mappers;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class HotelRepository : IHotelRepository
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

        public bool Delete(int id)
        {
            Entities.Hotel hotel = database.Hotels.FirstOrDefault(x => x.HotelId == id);
            if (hotel == null)
                return false;
            database.Hotels.Remove(hotel);
            database.SaveChanges();
            return true;
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
        public bool HasTours(int id)
        {
            Entities.Hotel hotel = database.Hotels.Include(x => x.Tours).FirstOrDefault(x => x.HotelId == id);
            return hotel.Tours.Any();
        }
        public void Update(Hotel item)
        {
            int id = Int32.Parse(item.HotelId);
            Entities.Hotel hotel = database.Hotels.FirstOrDefault(x => x.HotelId == id);
            hotel.UpdateHotelDB(item);
            database.Hotels.Update(hotel);
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
