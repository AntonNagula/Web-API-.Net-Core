using System.Collections.Generic;
using BusinesService;
using Core;
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

        [HttpGet("{id}")]
        public Country GetUser([FromRoute]int id)
        {            
            return service.GetCountry(id);
        }
        
        [HttpPost]
        public void CreateCountry([FromBody]Country country)
        {
            service.CreateCountry(country);
        }

        [HttpDelete("{id}")]
        public void DeleteUser([FromRoute]int id)
        {
            service.DeleteCountry(id);
        }
        [HttpPut]
        public void UpdateCountry([FromBody]Country country)
        {
            service.UpdateCountry(country);
        }
    }
}