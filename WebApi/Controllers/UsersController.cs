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
        [HttpPost]
        public AuthInfo Post([FromBody]AuthInfo obj)
        {
            User user = service.GetUserByData(obj.name,"1");
            AuthInfo obje = new AuthInfo();
            obje.name=user.Name;
            return obje;
        }
    }
}
