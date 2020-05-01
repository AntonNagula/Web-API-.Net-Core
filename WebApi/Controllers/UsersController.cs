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
        public IActionResult GetUsers()
        {
            IEnumerable<User> users = service.GetUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public User GetUser([FromRoute]int id)
        {
            User user = service.GetUser(id);
            return user;
        }
        [HttpPost("auth")]
        public AuthInfo Auth([FromBody]AuthInfo obj)
        {
            AuthInfo response = service.GetIdentityData(obj);            
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
