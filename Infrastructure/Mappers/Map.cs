namespace Data.Mappers
{
    public static class Map
    {
        public static Core.User ToUserApp(this Entities.User ob)
        {
            Core.User user = new Core.User();
            user.Email = ob.Email;
            user.Id = ob.UserId;
            user.Name = ob.UserName;
            user.Password = ob.UserPassword;
            user.Role = ob.Role.RoleName;
            user.Surname = ob.UserSurname;
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
    }
}
