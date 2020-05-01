﻿using System;
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

        [HttpGet("{id}")]
        public Tour GetTour([FromRoute]int id)
        {
            return service.GetTour(id);
        }
        [HttpGet("country/{id}")]
        public Export<Tour> GetTourByCountryId([FromRoute]int id)
        {
            IEnumerable<Tour> tours = service.GetActualToursByCountry(id);
            Export<Tour> obj = new Export<Tour>();
            obj.obj = tours;
            return obj;
        }

        [HttpPost]
        public void CreateTour([FromBody]Tour tour)
        {
            service.CreateTour(tour);
        }

        [HttpDelete("{id}")]
        public bool DeleteTour([FromRoute]int id)
        {
            return service.DeleteTour(id);
        }
        [HttpPut("{id}")]
        public void UpdateTour([FromBody]Tour tour)
        {
            service.UpdateTour(tour);
        }
    }
}