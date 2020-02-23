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
    public class ContriesController : ControllerBase
    {
        IService service;
        public ContriesController(IService service)
        {
            this.service = service;
        }
        [HttpGet]
        public Export<Country> Get()
        {
            IEnumerable<Country> users = service.GetCountries();
            Export<Country> obj = new Export<Country>();
            obj.obj = users;
            return obj;
        }
    }
}