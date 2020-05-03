using BusinesService;
using Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IActionResult GetUser([FromRoute]int id)
        {
            User user = service.GetUser(id);
            return Ok(user);
        }
        [HttpPost("auth")]
        public IActionResult Auth([FromBody]AuthInfo obj)
        {
            AuthInfo response = service.GetIdentityData(obj);            
            return Ok(response);
        }
        [HttpPost("registration")]
        public IActionResult Registration([FromBody]User newuser)
        {
            AuthInfo response = service.CreateAndGetIdentityData(newuser);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody]User newUser)
        {                     
            service.CreateUser(newUser);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute]int id)
        {
            bool isDeleted = service.DeleteUser(id);
            if (isDeleted)
                return NoContent();
            else
                return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateUser([FromBody]User newUser)
        {
            service.UpdateUser(newUser);
            return Ok();
        }
    }
}
