using BusinesService;
using Core;
using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

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
        public AuthInfo GetIdentityData(AuthInfo authInfo)
        {
            User user = database.Users.GetuserByAuthInfo(authInfo.Login, authInfo.Password);
            AuthInfo response = MakeResponseAuthInfo(user);
            return response;
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
        public bool DeleteCountry(int id)
        {
            bool hasCities = database.Countries.HasCities(id);
            if(!hasCities)
                database.Countries.Delete(id);
            return !hasCities;
        }
        public void CreateCountry(Country country)
        {
            database.Countries.Create(country);
        }


        public IEnumerable<City> GetCities()
        {
            return database.Cities.GetAll();
        }
        public IEnumerable<City> GetCitiesByCountryId(int CountryId)
        {
            return database.Cities.GetAll().Where(x => x.CountryId == CountryId.ToString()).ToList();
        }
        public City GetCity(int id)
        {
            return database.Cities.Get(id);
        }
        public void UpdateCity(City city)
        {
            database.Cities.Update(city);
        }
        public bool DeleteCity(int id)
        {
            bool hasHotels = database.Cities.HasHotels(id);
            if(!hasHotels)
            {
                database.Cities.Delete(id);
            }
            return !hasHotels;
        }
        public void CreateCity(City city)
        {
            database.Cities.Create(city);
        }


        public IEnumerable<Hotel> GetHotels()
        {
            return database.Hotels.GetAll();
        }
        public IEnumerable<Hotel> GetHotelsByCountryId(int id)
        {
            return database.Hotels.GetAll().Where(x => x.CountryId == id.ToString()).ToList();
        }
        public IEnumerable<Hotel> GetHotelsByCityId(int id)
        {
            return database.Hotels.GetAll().Where(x => x.CityId == id.ToString()).ToList();
        }
        public Hotel GetHotel(int id)
        {
            return database.Hotels.Get(id);
        }
        public void UpdateHotel(Hotel hotel)
        {
            database.Hotels.Update(hotel);
        }
        public bool DeleteHotel(int id)
        {
            bool hasTours = database.Hotels.HasTours(id);
            if(!hasTours)
                database.Hotels.Delete(id);
            return !hasTours;
        }
        public void CreateHotel(Hotel hotel)
        {
            if (hotel.Country != null)
            {
                Country country = new Country { Name = hotel.Country };
                hotel.CountryId = database.Countries.CreateAndGetId(country);
            }
            if (hotel.City != null)
            {              
                City city = new City { CountryId = hotel.CountryId, EngName = GetEngWordFromYandex(hotel.City), HasSea = true, RusName = hotel.City };
                hotel.CityId = database.Cities.CreateAndGetId(city);
            }
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
            database.Vouchers.Create(voucher);
            int TourId = Int32.Parse(voucher.TourId);
            Tour tour = database.Tours.Get(TourId);
            int quantity = Int32.Parse(tour.EndQuantity);
            quantity--;
            tour.EndQuantity = quantity.ToString();
            database.Tours.Update(tour);
        }


        public IEnumerable<Tour> GetTours()
        {
            return database.Tours.GetAll();
        }
        public IEnumerable<Tour> GetActualToursByCountry(int CountryId)
        {
            Country country = database.Countries.Get(CountryId);
            return database.Tours.GetActualTours().Where(x => x.Country == country.Name).ToList();
        }
        public IEnumerable<Tour> GetActualTour()
        {
            return database.Tours.GetActualTours();
        }
        public IEnumerable<Tour> GetChoisenTours(ChoisenCriterials choisenCriterials)
        {
            return database.Tours.GetChoisenTours(choisenCriterials);
        }
        public Tour GetTour(int id)
        {
            return database.Tours.Get(id);
        }
        public void UpdateTour(Tour tour)
        {
            database.Tours.Update(tour);
        }
        public bool DeleteTour(int id)
        {
            bool existVouchers = database.Tours.HasVouchers(id);
            if(!existVouchers)
                database.Tours.Delete(id);
            return !existVouchers;
        }
        public void CreateTour(Tour tour)
        {
            database.Tours.Create(tour);
        }



        private string GetEngWordFromYandex(string ForTranslate)
        {
            string EngName;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://translate.yandex.net/api/v1.5/tr.json/translate?"
                + "key=trnsl.1.1.20200329T092748Z.9c179a9ac941bd1f.219a18997795b43a79d3e192d553568000d7a137"
                + "&text=" + ForTranslate
                + "&lang=en");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
            {
                EngName = JsonSerializer.Deserialize<YandexTranslate>(stream.ReadToEnd()).text[0];
            }
            return EngName;
        }
        private AuthInfo MakeResponseAuthInfo(User user)
        {
            AuthInfo response = new AuthInfo();
            response.Login = user.Name;
            response.Password = user.Password;
            response.Role = user.Role;
            response.UserId = user.Id;
            return response;
        }
    }
}
