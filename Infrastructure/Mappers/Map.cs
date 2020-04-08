using System;

namespace Data.Mappers
{
    public static class Map
    {
        public static Core.Role ToRoleApp(this Entities.Role ob)
        {
            Core.Role role = new Core.Role();
            role.RoleId = ob.RoleId.ToString();
            role.RoleName = ob.RoleName;
            return role;
        }
        public static Entities.Role ToRoleDB(this Core.Role ob)
        {
            Entities.Role role = new Entities.Role();
            role.RoleName = ob.RoleName;
            if(ob.RoleId != null)
                role.RoleId = Int32.Parse(ob.RoleId);
            return role;
        }
        public static Core.User ToUserApp(this Entities.User ob)
        {
            Core.User user = new Core.User();
            user.Email = ob.Email;
            user.Id = ob.UserId.ToString();
            user.Name = ob.UserName;
            user.Password = ob.UserPassword;
            user.Role = ob.Role.RoleName;
            user.RoleId = ob.RoleId.ToString();
            user.Surname = ob.UserSurname;
            return user;
        }
        public static Entities.User ToUserDB(this Core.User ob)
        {
            Entities.User user = new Entities.User();
            user.Email = ob.Email;
            user.UserName = ob.Name;
            user.UserPassword = ob.Password;
            if (ob.Id != null)
                user.UserId = Int32.Parse(ob.Id);
            if (ob.RoleId != null)
                user.RoleId = Int32.Parse(ob.RoleId);
            else
                user.RoleId = 3;
            user.UserSurname = ob.Surname;
            return user;
        }
        public static void UpdateUserDB(this Entities.User db, Core.User app)
        {
            db.Email = app.Email;
            db.UserName = app.Name;
            db.UserPassword = app.Password;
            if (app.RoleId != null)
                db.RoleId = Int32.Parse(app.RoleId);
            db.UserSurname = app.Surname;
        }
        public static Core.Country ToCountryApp(this Entities.Country ob)
        {
            Core.Country user = new Core.Country();
            user.Name = ob.Name;
            user.CountryId = ob.CountryId.ToString();
            user.HasSea = ob.HasSea;
            user.Img = ob.Img;
            return user;
        }
        public static Entities.Country ToCountryDB(this Core.Country ob)
        {
            Entities.Country user = new Entities.Country();
            if(ob.CountryId != null)
                user.CountryId = Int32.Parse(ob.CountryId);
            user.Name = ob.Name;           
            user.HasSea = ob.HasSea;
            user.Img = ob.Img;
            return user;
        }
        public static void UpdateCountryDB(this Entities.Country db, Core.Country app)
        {
            db.HasSea = app.HasSea;
            db.Name = app.Name;
            db.Img = app.Img;            
        }
        public static Core.City ToCityApp(this Entities.City ob)
        {
            Core.City city = new Core.City();
            city.EngName = ob.EngName;
            city.RusName = ob.RusName;
            city.CityId = ob.CityId.ToString();
            city.HasSea = ob.HasSea;
            city.Img = ob.Img;
            city.CountryId = ob.CountryId.ToString();
            city.Country = ob.Country.Name;
            return city;
        }
        public static Entities.City ToCityDB(this Core.City ob)
        {
            Entities.City city = new Entities.City();
            city.EngName = ob.EngName;
            city.RusName = ob.RusName;
            city.HasSea = ob.HasSea;
            city.Img = ob.Img;
            if (ob.CountryId != null)
                city.CountryId = Int32.Parse(ob.CountryId);
            return city;
        }
        public static void UpdateCityDB(this Entities.City db, Core.City app)
        {
            db.HasSea = app.HasSea;
            db.EngName = app.EngName;
            db.RusName = app.RusName;
            db.Img = app.Img;
            if (app.CountryId != null)
                db.CountryId = Int32.Parse(app.CountryId);
        }
        public static Core.Hotel ToHotelApp(this Entities.Hotel ob)
        {
            Core.Hotel hotel = new Core.Hotel();
            hotel.Name = ob.Name;
            hotel.Country = ob.Country.Name;
            hotel.City = ob.City.RusName;
            hotel.facilities = ob.facilities;
            hotel.HasBeach = ob.HasBeach;
            hotel.HotelId = ob.HotelId.ToString();
            hotel.Img = ob.Img;
            hotel.PricePerDay = ob.PricePerDay.ToString();
            hotel.Stars = ob.Stars.ToString();
            return hotel;
        }
        public static Entities.Hotel ToHotelDB(this Core.Hotel ob)
        {
            Entities.Hotel hotel = new Entities.Hotel();
            hotel.Name = ob.Name;
            if (ob.CountryId != null)
                hotel.CountryId = Int32.Parse(ob.CountryId);
            if (ob.CityId != null)
                hotel.CityId = Int32.Parse(ob.CityId);
            hotel.facilities = ob.facilities;
            hotel.HasBeach = ob.HasBeach;
            hotel.Img = ob.Img;
            if (ob.PricePerDay != null)
                hotel.PricePerDay = Decimal.Parse(ob.PricePerDay);
            if (ob.Stars != null)
                hotel.Stars = Int32.Parse(ob.Stars);
            else
                hotel.Stars = 3;
            return hotel;
        }
        public static void UpdateHotelDB(this Entities.Hotel hotel, Core.Hotel ob)
        {
            hotel.Name = ob.Name;
            if (ob.CountryId != null)
                hotel.CountryId = Int32.Parse(ob.CountryId);
            if (ob.CityId != null)
                hotel.CityId = Int32.Parse(ob.CityId);
            hotel.facilities = ob.facilities;
            hotel.HasBeach = ob.HasBeach;
            hotel.Img = ob.Img;
            if (ob.PricePerDay != null)
                hotel.PricePerDay = Decimal.Parse(ob.PricePerDay);
            if (ob.Stars != null)
                hotel.Stars = Int32.Parse(ob.Stars);
            else
                hotel.Stars = 3;
        }
        public static Core.Voucher ToVoucherApp(this Entities.Voucher ob)
        {
            Core.Voucher voucher = new Core.Voucher();
            voucher.UserName = ob.User.UserName;
            voucher.UserSurname = ob.User.UserSurname;
            voucher.VoucherId = ob.VoucherId.ToString();
            voucher.TourId = ob.TourId.ToString();
            voucher.UserId = ob.UserId.ToString();
            return voucher;
        }
        public static Entities.Voucher ToVoucherDB(this Core.Voucher ob)
        {
            Entities.Voucher voucher = new Entities.Voucher();            
            if (ob.UserId != null)
                voucher.UserId = Int32.Parse(ob.UserId);
            if (ob.TourId != null)
                voucher.TourId = Int32.Parse(ob.TourId);
            return voucher;
        }
        public static void UpdateVoucherDB(this Entities.Voucher db, Core.Voucher app)
        {
            if (app.UserId != null)
                db.UserId = Int32.Parse(app.UserId);
            if (app.TourId != null)
                db.TourId = Int32.Parse(app.TourId);
        }
        public static Core.Tour ToTourApp(this Entities.Tour ob)
        {
            Core.Tour tour = new Core.Tour();
            tour.CityId = ob.CityId.ToString();
            tour.CountryId = ob.CountryId.ToString();
            tour.HotelId = ob.HotelId.ToString();
            tour.TourId = ob.TourId.ToString();
            tour.Country = ob.Country.Name;
            tour.Hotel = ob.Hotel.Name;
            tour.City = ob.City.RusName;
            tour.EngNameOfCity = ob.City.EngName;
            tour.Name = ob.Name;
            tour.Quantity = ob.Quantity.ToString();
            return tour;
        }
        public static Entities.Tour ToTourDB(this Core.Tour ob)
        {
            Entities.Tour tour = new Entities.Tour();
            if (ob.CityId != null)
                tour.CityId = Int32.Parse(ob.CityId);
            if (ob.Quantity != null)
                tour.Quantity = Int32.Parse(ob.Quantity);
            if (ob.CountryId != null)
                tour.CountryId = Int32.Parse(ob.CountryId);
            if (ob.TourId != null)
                tour.TourId = Int32.Parse(ob.TourId);
            tour.Name = ob.Name;
            return tour;
        }
        public static void UpdateTourDB(this Entities.Tour db, Core.Tour app)
        {            
            if (app.CityId != null)
                db.CityId = Int32.Parse(app.CityId);
            if (app.Quantity != null)
                db.Quantity = Int32.Parse(app.Quantity);
            if (app.CountryId != null)
                db.CountryId = Int32.Parse(app.CountryId);
            if (app.TourId != null)
                db.TourId = Int32.Parse(app.TourId);
            db.Name = app.Name;
        }
    }
}
