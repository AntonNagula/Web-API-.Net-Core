using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public int? IdRole { get; set; }
        public Role Role { get; set; }
    }
}
