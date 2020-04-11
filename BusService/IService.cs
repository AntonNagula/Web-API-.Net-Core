﻿using Core;
using System.Collections.Generic;

namespace BusinesService
{
    public interface IService
    {
        AuthInfo GetIdentityData(AuthInfo authInfo);
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void CreateUser(User user);

        IEnumerable<Role> GetRoles();
        

        IEnumerable<Country> GetCountries();
        Country GetCountry(int id);
        void UpdateCountry(Country country);
        void DeleteCountry(int id);
        void CreateCountry(Country country);

        IEnumerable<City> GetCities();
        City GetCity(int id);
        void UpdateCity(City country);
        void DeleteCity(int id);
        void CreateCity(City country);

        IEnumerable<Hotel> GetHotels();
        Hotel GetHotel(int id);
        void UpdateHotel(Hotel hotel);
        void DeleteHotel(int id);
        void CreateHotel(Hotel hotel);

        IEnumerable<Voucher> GetVouchers();
        Voucher GetVoucher(int id);
        void UpdateVoucher(Voucher voucher);
        void DeleteVoucher(int id);
        void CreateVoucher(Voucher voucher);

        IEnumerable<Tour> GetTours();
        IEnumerable<Tour> GetActualTour();
        Tour GetTour(int id);
        void UpdateTour(Tour tour);
        void DeleteTour(int id);
        void CreateTour(Tour tour);
    }
}
