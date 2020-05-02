using System.Collections.Generic;
using BusinesService;
using Core;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get()
        {
            IEnumerable<City> cities = service.GetCities();
            return Ok(cities);
        }
        [HttpGet("country/{id}")]
        public IActionResult GetByCountry([FromRoute]int id)
        {
            IEnumerable<City> cities = service.GetCitiesByCountryId(id);
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity([FromRoute]int id)
        {
            return Ok(service.GetCity(id));
        }

        [HttpPost]
        public IActionResult CreateCity([FromBody]City city)
        {
            service.CreateCity(city);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity([FromRoute]int id)
        {
            if (service.DeleteCity(id))
                return NoContent();
            else
                return BadRequest(new { error = "Город содержит отели или туры связанные с ним" });
        }
        [HttpPut]
        public IActionResult UpdateCity([FromBody]City city)
        {
            service.UpdateCity(city);
            return Ok();
        }
    }
}