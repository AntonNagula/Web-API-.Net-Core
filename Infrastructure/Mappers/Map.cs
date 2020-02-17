namespace Data.Mappers
{
    public static class Map
    {
        public static Core.User ToUserApp(this Entities.User ob)
        {
            Core.User user = new Core.User();
            user.Email = ob.Email;
            user.Id = ob.Id;
            user.Name = ob.UserName;
            user.Password = ob.UserPassword;
            user.Role = "admin";
            user.Surname = ob.UserSurname;
            return user;
        }
    }
}
