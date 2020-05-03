using Core;
using System.Collections.Generic;

namespace BusinesService
{
    public interface IService
    {
        AuthInfo GetIdentityData(AuthInfo authInfo);
        AuthInfo CreateAndGetIdentityData(User userinfo);
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void UpdateUser(User user);
        bool DeleteUser(int id);
        void CreateUser(User user);

        IEnumerable<Role> GetRoles();        

        IEnumerable<Country> GetCountries();
        Country GetCountry(int id);
        void UpdateCountry(Country country);
        bool DeleteCountry(int id);
        void CreateCountry(Country country);

        IEnumerable<City> GetCities();
        IEnumerable<City> GetCitiesByCountryId(int CountryId);
        City GetCity(int id);
        void UpdateCity(City country);
        bool DeleteCity(int id);
        void CreateCity(City country);

        IEnumerable<Hotel> GetHotels();
        IEnumerable<Hotel> GetHotelsByCountryId(int id);
        IEnumerable<Hotel> GetHotelsByCityId(int id);
        Hotel GetHotel(int id);
        void UpdateHotel(Hotel hotel);
        bool DeleteHotel(int id);
        void CreateHotel(Hotel hotel);

        IEnumerable<Voucher> GetVouchers();
        IEnumerable<VoucherAndTourInfo> GetVouchersByuserId(int id);
        Voucher GetVoucher(int id);
        void UpdateVoucher(Voucher voucher);
        void DeleteVoucher(int id);
        void CreateVoucher(Voucher voucher);

        IEnumerable<Tour> GetTours();
        IEnumerable<Tour> GetActualToursByCountry(int CountryId);
        IEnumerable<Tour> GetActualTour();
        IEnumerable<Tour> GetChoisenTours(ChoisenCriterials choisenCriterials);
        Tour GetTour(int id);
        void UpdateTour(Tour tour);
        bool DeleteTour(int id);
        void CreateTour(Tour tour);
    }
}
