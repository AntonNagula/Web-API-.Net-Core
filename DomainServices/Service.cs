using BusinesService;
using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Service : IService
    {
        IUnitOfWork database;
        public Service(IUnitOfWork db)
        {
            database = db;
        }

        public void CreateUser(User user)
        {
            database.Users.Create(user);
        }
        public void DeleteUser(int id)
        {
            database.Users.Delete(id);
        }
        public void UpdateUser(User user)
        {
            database.Users.Update(user);
        }
        public User GetUser(int id)
        {
            return database.Users.Get(id);
        }
        public User GetUserByData(string mail, string password)
        {
            return database.Users.Get(mail,password);
        }
        public IEnumerable<User> GetUsers()
        {
            return database.Users.GetAll();
        }

        public IEnumerable<Role> GetRoles()
        {
            return database.Roles.GetAll();
        }        

        public IEnumerable<Country> GetCountries()
        {
            return database.Countries.GetAll();
        }
        public Country GetCountry(int id)
        {
            return database.Countries.Get(id);
        }

        public void UpdateCountry(Country country)
        {
            database.Countries.Update(country);
        }

        public void DeleteCountry(int id)
        {
            database.Countries.Delete(id);
        }

        public void CreateCountry(Country country)
        {
            database.Countries.Create(country);
        }


        public IEnumerable<City> GetCities()
        {
            return database.Cities.GetAll();
        }
        public City GetCity(int id)
        {
            return database.Cities.Get(id);
        }

        public void UpdateCity(City city)
        {
            database.Cities.Update(city);
        }

        public void DeleteCity(int id)
        {
            database.Cities.Delete(id);
        }

        public void CreateCity(City city)
        {
            database.Cities.Create(city);
        }


        public IEnumerable<Hotel> GetHotels()
        {
            return database.Hotels.GetAll();
        }
        public Hotel GetHotel(int id)
        {
            return database.Hotels.Get(id);
        }
        public void UpdateHotel(Hotel hotel)
        {
            database.Hotels.Update(hotel);
        }
        public void DeleteHotel(int id)
        {
            database.Hotels.Delete(id);
        }
        public void CreateHotel(Hotel hotel)
        {
            database.Hotels.Create(hotel);
        }

        public IEnumerable<Voucher> GetVouchers()
        {
            return database.Vouchers.GetAll();
        }

        public Voucher GetVoucher(int id)
        {
            return database.Vouchers.Get(id);
        }

        public void UpdateVoucher(Voucher voucher)
        {
            database.Vouchers.Update(voucher);
        }

        public void DeleteVoucher(int id)
        {
            database.Vouchers.Delete(id);
        }

        public void CreateVoucher(Voucher voucher)
        {
            int TourId = Int32.Parse(voucher.TourId);
            Tour tour = database.Tours.Get(TourId);
            int quantity = Int32.Parse(tour.Quantity);
            quantity--;
            tour.Quantity = quantity.ToString();
            database.Tours.Update(tour);
            database.Vouchers.Create(voucher);
        }


        public IEnumerable<Tour> GetTours()
        {
            return database.Tours.GetAll();
        }

        public Tour GetTour(int id)
        {
            return database.Tours.Get(id);
        }

        public void UpdateTour(Tour tour)
        {
            database.Tours.Update(tour);
        }

        public void DeleteTour(int id)
        {
            database.Tours.Delete(id); 
        }

        public void CreateTour(Tour tour)
        {
            database.Tours.Create(tour);
        }
    }
}
