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
            city.Name = ob.Name;
            city.CityId = ob.CityId.ToString();
            city.HasSea = ob.HasSea;
            city.Img = ob.Img;
            return city;
        }
        public static Entities.City ToCityDB(this Core.City ob)
        {
            Entities.City city = new Entities.City();
            if (ob.CityId != null)
                city.CityId = Int32.Parse(ob.CityId);
            city.Name = ob.Name;
            city.HasSea = ob.HasSea;
            city.Img = ob.Img;
            return city;
        }
        public static void UpdateCityDB(this Entities.City db, Core.City app)
        {
            db.HasSea = app.HasSea;
            db.Name = app.Name;
            db.Img = app.Img;
        }

        public static Core.Hotel ToHotelApp(this Entities.Hotel ob)
        {
            Core.Hotel hotel = new Core.Hotel();
            hotel.Name = ob.Name;
            hotel.Country = ob.Country.Name;
            hotel.City = ob.City.Name;
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
    }
}
