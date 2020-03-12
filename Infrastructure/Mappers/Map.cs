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
            if(ob.RoleId != null)
                user.RoleId = Int32.Parse(ob.RoleId);
            user.UserSurname = ob.Surname;
            return user;
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
