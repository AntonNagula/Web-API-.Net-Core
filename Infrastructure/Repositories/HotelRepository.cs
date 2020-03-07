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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Hotel Get(int id)
        {
            throw new NotImplementedException();
        }
               

        public IEnumerable<Hotel> GetAll()
        {
            return database.Hotels.Include(x => x.Country).Select(x => x.ToHotelApp()).ToList();
        }

        public void Update(Hotel item)
        {
            throw new NotImplementedException();
        }
    }
}
