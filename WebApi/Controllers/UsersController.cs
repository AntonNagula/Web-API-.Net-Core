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
        public Export<User> GetUsers()
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
        public AuthInfo Auth([FromBody]AuthInfo obj)
        {
            User user = service.GetUserByData(obj.name,"1");
            AuthInfo obje = new AuthInfo();
            obje.name=user.Name;
            return obje;
        }
        [HttpPost("CreateUser")]
        public void CreateUser([FromBody]User newUser)
        {                     
            service.CreateUser(newUser);            
        }
        [HttpDelete("DeleteUser")]
        public void DeleteUser([FromBody]User newUser)
        {
            service.DeleteUser(newUser);
        }
        [HttpPut("UpdateUser")]
        public void UpdateUser([FromBody]User newUser)
        {
            service.UpdateUser(newUser);            
        }
    }
}
