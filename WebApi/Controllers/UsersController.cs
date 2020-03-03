using BusinesService;
using Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Export;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        IService service;
        public UsersController(IService service)
        {
            this.service = service;
        }
        [HttpGet]
        public Export<User> Get()
        {
            IEnumerable<User> users = service.GetUsers();
            Export<User> obj = new Export<User>();
            obj.obj = users;
            return obj;
        }
        [HttpGet("{id}")]
        public User GetUser(int id=0)
        {
            User user = service.GetUserByData("anton@mail.ru", "1");
            return user;
        }
        [HttpPost]
        public AuthInfo Post([FromBody]AuthInfo obj)
        {
            User user = service.GetUserByData(obj.name,"1");
            AuthInfo obje = new AuthInfo();
            obje.name=user.Name;
            return obje;
        }
        [HttpPost("CreateUser")]
        public void CreateUser([FromBody]User newUser)
        {                     
            service.CreateUser(newUser); ;
        }
        //[HttpPut]
        //public Export<User> UpdateUser()
        //{

        //    return obj;
        //}
        //[HttpDelete]
        //public AuthInfo DeleteUser([FromBody]User obj)
        //{

        //    return obje;
        //}
    }
}
