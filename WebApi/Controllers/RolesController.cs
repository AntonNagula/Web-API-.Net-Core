using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesService;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Export;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        IService service;
        public RolesController(IService service)
        {
            this.service = service;
        }
        [HttpGet]
        public Export<Role> GetRoles()
        {
            IEnumerable<Role> roles = service.GetRoles();
            Export<Role> obj = new Export<Role>();
            obj.obj = roles;
            return obj;
        }        
    }
}