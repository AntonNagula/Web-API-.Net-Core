using System.Collections.Generic;
using BusinesService;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        IService service;
        public ToursController(IService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Tour> tours = service.GetTours();
            return Ok(tours);
        }
        [HttpGet("actual")]
        public IActionResult GetActual()
        {
            IEnumerable<Tour> tours = service.GetActualTour();
            return Ok(tours);
        }
        [HttpPost("choisen")]
        public IActionResult GetChoisen([FromBody]ChoisenCriterials choisenCriterials)
        {
            IEnumerable<Tour> tours = service.GetChoisenTours(choisenCriterials);
            return Ok(tours);
        }
        [HttpGet("{id}")]
        public Tour GetTour([FromRoute]int id)
        {
            return service.GetTour(id);
        }
        [HttpGet("country/{id}")]
        public IActionResult GetTourByCountryId([FromRoute]int id)
        {
            IEnumerable<Tour> tours = service.GetActualToursByCountry(id);
            return Ok(tours);
        }

        [HttpPost]
        public IActionResult CreateTour([FromBody]Tour tour)
        {
            service.CreateTour(tour);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTour([FromRoute]int id)
        {
            if (service.DeleteTour(id))
                return NoContent();
            else
                return BadRequest(new { error = "Тур содержит связанные с ним ваучеры" });
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTour([FromBody]Tour tour)
        {
            service.UpdateTour(tour);
            return Ok();
        }
    }
}