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
    public class ToursController : ControllerBase
    {
        IService service;
        public ToursController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        public Export<Tour> Get()
        {
            IEnumerable<Tour> tours = service.GetTours();
            Export<Tour> obj = new Export<Tour>();
            obj.obj = tours;
            return obj;
        }

        [HttpGet("{id}")]
        public Tour GetTour([FromRoute]int id)
        {
            return service.GetTour(id);
        }

        [HttpPost]
        public void CreateTour([FromBody]Tour tour)
        {
            service.CreateTour(tour);
        }

        [HttpDelete("{id}")]
        public void DeleteTour([FromRoute]int id)
        {
            service.DeleteTour(id);
        }
        [HttpPut]
        public void UpdateTour([FromBody]Tour tour)
        {
            service.UpdateTour(tour);
        }
    }
}