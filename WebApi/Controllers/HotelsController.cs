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
    public class HotelsController : ControllerBase
    {
        IService service;
        public HotelsController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Hotel> hotels = service.GetHotels();
            return Ok(hotels);
        }
        [HttpGet("country/{id}")]
        public IActionResult GetByCountryId([FromRoute]int id)
        {
            IEnumerable<Hotel> hotels = service.GetHotelsByCountryId(id);
            return Ok(hotels);
        }
        [HttpGet("city/{id}")]
        public IActionResult GetByCityId([FromRoute]int id)
        {
            IEnumerable<Hotel> hotels = service.GetHotelsByCityId(id);
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public IActionResult GetHotel([FromRoute]int id)
        {
            return Ok(service.GetHotel(id));
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody]Hotel hotel)
        {
            service.CreateHotel(hotel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHotel([FromRoute]int id)
        {
            bool isDeleted = service.DeleteHotel(id);
            if (isDeleted)
                return NoContent();
            else
                return BadRequest(new { error = "Отель содержит туры связанные с ним" });
        }
        [HttpPut]
        public IActionResult UpdateHotel([FromBody]Hotel hotel)
        {
            service.UpdateHotel(hotel);
            return Ok();
        }
    }
}