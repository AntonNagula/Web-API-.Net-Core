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
        public IActionResult Get()
        {
            IEnumerable<Country> countries = service.GetCountries();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public IActionResult GetContry([FromRoute]int id)
        {            
            return Ok(service.GetCountry(id));
        }
        
        [HttpPost]
        public IActionResult CreateCountry([FromBody]Country country)
        {
            service.CreateCountry(country);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute]int id)
        {
            bool isDeleted = service.DeleteCountry(id);
            if (isDeleted)
                return NoContent();
            else
                return BadRequest(new { error = "Страна содержит отели, или туры, или города связанные с ним" });
        }
        [HttpPut]
        public IActionResult UpdateCountry([FromBody]Country country)
        {
            service.UpdateCountry(country);
            return Ok();
        }
    }
}