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
    public class CitiesController : ControllerBase
    {
        IService service;
        public CitiesController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        public Export<City> Get()
        {
            IEnumerable<City> users = service.GetCities();
            Export<City> obj = new Export<City>();
            obj.obj = users;
            return obj;
        }

        [HttpGet("{id}")]
        public City GetUser([FromRoute]int id)
        {
            return service.GetCity(id);
        }

        [HttpPost]
        public void CreateCity([FromBody]City city)
        {
            service.CreateCity(city);
        }

        [HttpDelete("{id}")]
        public void DeleteCity([FromRoute]int id)
        {
            service.DeleteCity(id);
        }
        [HttpPut]
        public void UpdateCity([FromBody]City city)
        {
            service.UpdateCity(city);
        }
    }
}