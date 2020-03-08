using System;

namespace Data.Mappers
{
    public static class Map
    {
        public static Core.User ToUserApp(this Entities.User ob)
        {
            Core.User user = new Core.User();
            user.Email = ob.Email;
            user.Id = ob.UserId.ToString();
            user.Name = ob.UserName;
            user.Password = ob.UserPassword;
            user.Role = ob.Role.RoleName;
            user.Surname = ob.UserSurname;
            return user;
        }
        public static Entities.User ToUserDB(this Core.User ob)
        {
            Entities.User user = new Entities.User();
            user.Email = ob.Email;
            user.UserName = ob.Name;
            user.UserPassword = ob.Password;
            user.RoleId = 2;
            user.UserSurname = ob.Surname;
            int id = Int32.Parse(ob.Id);
            if(id != 0)
                user.UserId = id;
            return user;
        }
        public static Core.Country ToCountryApp(this Entities.Country ob)
        {
            Core.Country user = new Core.Country();
            user.Name = ob.Name;
            user.CountryId = ob.CountryId;
            user.HasSea = ob.HasSea;
            user.Img = ob.Img;
            return user;
        }
        public static Core.Hotel ToHotelApp(this Entities.Hotel ob)
        {
            Core.Hotel hotel = new Core.Hotel();
            hotel.Name = ob.Name;
            hotel.Country = ob.Country.Name;
            hotel.facilities = ob.facilities;
            hotel.HasBeach = ob.HasBeach;
            hotel.HotelId = ob.HotelId;
            hotel.Img = ob.Img;
            hotel.PricePerDay = ob.PricePerDay;
            hotel.Stars = ob.Stars;
            return hotel;
        }

        public static Entities.Hotel ToHotelDB(this Core.Hotel ob)
        {
            Entities.Hotel hotel = new Entities.Hotel();
            hotel.Name = ob.Name;
            hotel.CountryId = ob.CountryId;
            hotel.facilities = ob.facilities;
            hotel.HasBeach = ob.HasBeach;
            hotel.HotelId = ob.HotelId;
            hotel.Img = ob.Img;
            hotel.PricePerDay = ob.PricePerDay;
            hotel.Stars = ob.Stars;
            return hotel;
        }
    }
}
