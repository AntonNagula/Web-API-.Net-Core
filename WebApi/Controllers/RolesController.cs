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
        public IActionResult GetRoles()
        {
            IEnumerable<Role> roles = service.GetRoles();
            return Ok(roles);
        }        
    }
}