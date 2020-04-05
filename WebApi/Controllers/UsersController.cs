using BusinesService;
using Core;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public User GetUser([FromRoute]int id)
        {
            User user = service.GetUserByData("anton@mail.ru", "1");
            return user;
        }
        [HttpPost("auth")]
        public AuthInfo Auth([FromBody]AuthInfo obj)
        {
            User user = service.GetUserByData(obj.Login, obj.Password);
            AuthInfo response = new AuthInfo();
            response.Login=user.Name;
            response.Password = user.Password;
            response.Role = user.Role;
            response.UserId = user.Id;
            return response;
        }
        [HttpPost]
        public void CreateUser([FromBody]User newUser)
        {                     
            service.CreateUser(newUser);            
        }
        [HttpDelete("{id}")]
        public void DeleteUser([FromRoute]int id)
        {
            service.DeleteUser(id);
        }
        [HttpPut]
        public void UpdateUser([FromBody]User newUser)
        {
            service.UpdateUser(newUser);            
        }
    }
}
