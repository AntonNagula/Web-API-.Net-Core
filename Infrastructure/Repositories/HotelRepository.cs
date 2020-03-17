using Core;
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
        public void Delete(int id)
        {
            Entities.Hotel hotel = database.Hotels.FirstOrDefault(x => x.HotelId == id);
            database.Hotels.Remove(hotel);
            database.SaveChanges();
        }
        public Hotel Get(int id)
        {
            return database.Hotels.FirstOrDefault(x => x.HotelId == id).ToHotelApp();
        }
        public IEnumerable<Hotel> GetAll()
        {
            return database.Hotels.Include(x => x.Country).Select(x => x.ToHotelApp()).ToList();
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
