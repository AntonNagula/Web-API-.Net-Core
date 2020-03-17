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
        public Export<Hotel> Get()
        {
            IEnumerable<Hotel> hotels = service.GetHotels();
            Export<Hotel> obj = new Export<Hotel>();
            obj.obj = hotels;
            return obj;
        }

        [HttpGet("{id}")]
        public Country GetHotel([FromRoute]int Id)
        {
            return service.GetCountry(Id);
        }

        [HttpPost]
        public void CreateHotel([FromBody]Hotel hotel)
        {
            service.CreateHotel(hotel);
        }

        [HttpDelete("{id}")]
        public void DeleteHotel([FromRoute]int Id)
        {
            service.DeleteHotel(Id);
        }
        [HttpPut]
        public void UpdateHotel([FromBody]Hotel hotel)
        {
            service.UpdateHotel(hotel);
        }
    }
}