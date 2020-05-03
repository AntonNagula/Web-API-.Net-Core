using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using Data.Mappers;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class VoucherRepository : IVoucherRepository
    {
        private ProjectDbContext database;
        public VoucherRepository(ProjectDbContext db)
        {
            database = db;
        }
        public void Create(Voucher item)
        {
            database.Vouchers.Add(item.ToVoucherDB());
            database.SaveChanges();
        }

        public string CreateAndGetId(Voucher item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Entities.Voucher voucher = database.Vouchers.FirstOrDefault(x => x.VoucherId == id);
            database.Vouchers.Remove(voucher);
            database.SaveChanges();
        }

        public Voucher Get(int id)
        {
            return database.Vouchers.Include(x => x.User).FirstOrDefault(x => x.VoucherId == id).ToVoucherApp();
        }

        public IEnumerable<Voucher> GetAll()
        {
            return database.Vouchers.Include(x => x.User).Select(x => x.ToVoucherApp()).ToList();
        }
        public IEnumerable<VoucherAndTourInfo> GetActualVouchersByUserId(int id)
        {
            var Vouchers = from voucher in database.Vouchers
                           join user in database.Users on voucher.UserId equals user.UserId
                           join tour in database.Tours on voucher.TourId equals tour.TourId
                           join country in database.Countries on tour.CountryId equals country.CountryId
                           join city in database.Cities on tour.CityId equals city.CityId
                           join hotel in database.Hotels on tour.HotelId equals hotel.HotelId
                           where tour.StartDate > DateTime.Today && voucher.UserId == id
                           select new VoucherAndTourInfo
                           {
                               PassportNumber = voucher.PassportNumber,
                               PassportSeries = voucher.PassportSeries,
                               Img = tour.Img,
                               HasTransfer = tour.HasTransfer,
                               VoucherId = voucher.VoucherId.ToString(),
                               UserSurname = user.UserSurname,
                               UserName = user.UserName,
                               UserId = user.UserId.ToString(),
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
            List<VoucherAndTourInfo> VouchersAndInfo = Vouchers.ToList();
            return VouchersAndInfo;
        }

        public void Update(Voucher item)
        {
            int id = Int32.Parse(item.VoucherId);
            Entities.Voucher voucher = database.Vouchers.FirstOrDefault(x => x.VoucherId == id);
            voucher.UpdateVoucherDB(item);
            database.Vouchers.Update(voucher);
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
